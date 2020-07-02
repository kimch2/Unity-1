using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
namespace ETModel
{
    public enum ProjectBtnState
    {
        NeedDownLoad,
        NeedUpdate,
        Updating,
        Pause,
        Ready
    }

    public class ProjectBtn : MonoBehaviour
    {
        public UnityEngine.UI.Text Info;
        public UnityEngine.UI.Image Progress;
        public UnityEngine.UI.Button ConfirmBtn;
        public string ProjectName { get; set; }

        private bool Pause { get; set; }

        private ProjectBtnState BtnState;

        public string RemotePath
        {
            get { return Path.Combine(PathHelper.RemoteLoadPath, ProjectName); }
        }
        public string SavePath
        {
            get { return Path.Combine(PathHelper.BuildPath, ProjectName); }
        }

        public void InitProjectBtn(string projectName)
        {
            ProjectName = projectName;
            CheckDownLoadSize();
            ConfirmBtn.onClick.AddListener(DownLoadBundle);
        }

        public ProjectBtnState GetState()
        {
            return BtnState;
        }

        public void SetState(ProjectBtnState state)
        {
             switch (state)
            {
                case ProjectBtnState.Pause:
                    Info.text = "继续";
                    Progress.color = Color.yellow;
                    break;
                case ProjectBtnState.Ready:
                    Info.text = "打开";
                    Progress.fillAmount = 1;
                    Progress.color = new Color(0.6f,0.6f,0.9f);
                    Progress.transform.parent.GetComponentInChildren<UnityEngine.UI.Text>().color = Color.white;
                    break;
                case ProjectBtnState.NeedUpdate:
                    Info.text = "更新";
                    break;
                case ProjectBtnState.NeedDownLoad:
                    Info.text = "下载";
                    break;
                case ProjectBtnState.Updating:

                    Progress.color = new Color(0.5f, 0.8f, 0.44f);
                    Info.text = "暂停";
                    break;
            }
            BtnState = state;
        }

        public async void CheckDownLoadSize()
        {
            await StartAsync();

             if (TotalSize != 0)
            {
                SetState(ProjectBtnState.NeedUpdate);
            }
            else
            {
                SetState(ProjectBtnState.Ready);
            }
        }

        private VersionConfig remoteVersionConfig;

        private Dictionary<string, FileVersionInfo> hasDonwLoadedFile = new Dictionary<string, FileVersionInfo>();
        private byte[] remoteVersionConfigData;

        public Queue<string> bundles = new Queue<string>();

        public long TotalSize;

        public HashSet<string> downloadedBundles = new HashSet<string>();

        public string downloadingBundle;

        public UnityWebRequest webRequest;
        public int ProgressValue
        {
            get
            {
                if (this.TotalSize == 0)
                {
                    return 0;
                }

                long alreadyDownloadBytes = 0;
                foreach (string downloadedBundle in this.downloadedBundles)
                {
                    long size = this.remoteVersionConfig.FileInfoDict[downloadedBundle].Size;
                    alreadyDownloadBytes += size;
                }
                if (this.webRequest != null)
                {
                    alreadyDownloadBytes += (long)this.webRequest.downloadedBytes;
                }
                return (int)(alreadyDownloadBytes * 100f / this.TotalSize);
            }
        }

        public async ETTask StartAsync()
        {
            // 获取远程的Version.txt
            string versionUrl = "";
            try
            {
                using (UnityWebRequestAsync webRequestAsync = ComponentFactory.Create<UnityWebRequestAsync>())
                {
                    versionUrl = RemotePath + "/Version.txt";
                    await webRequestAsync.DownloadAsync(versionUrl);
                    remoteVersionConfigData = webRequestAsync.Request.downloadHandler.data;
                    remoteVersionConfig = JsonHelper.FromJson<VersionConfig>(webRequestAsync.Request.downloadHandler.text);
                }
            }
            catch (Exception e)
            {
                throw new Exception($"url: {versionUrl}", e);
            }
            try
            {
                // 获取streaming目录的Version.txt
                VersionConfig streamingVersionConfig;
                string versionPath = Path.Combine(SavePath, "Version.txt");
                if (File.Exists(versionPath))
                {
                    streamingVersionConfig = JsonHelper.FromJson<VersionConfig>(File.ReadAllText(versionPath));
                }
                else
                {
                    streamingVersionConfig = new VersionConfig();
                }

                // 删掉远程不存在的文件
                DirectoryInfo directoryInfo = new DirectoryInfo(SavePath);
                if (directoryInfo.Exists)
                {
                    FileInfo[] fileInfos = directoryInfo.GetFiles();
                    int directoryFolderLength = directoryInfo.FullName.Length;
                    foreach (FileInfo fileInfo in fileInfos)
                    {

                        if (remoteVersionConfig.FileInfoDict.ContainsKey(fileInfo.FullName.Substring(directoryFolderLength).Replace("\\", "")))
                        {
                            continue;
                        }

                        if (fileInfo.Name == "Version.txt")
                        {
                            continue;
                        }
                        fileInfo.Delete();
                    }
                }
                else
                {
                    directoryInfo.Create();
                }

                // 对比MD5
                foreach (FileVersionInfo fileVersionInfo in remoteVersionConfig.FileInfoDict.Values)
                {
                    // 对比md5
                    string localFileMD5 = BundleHelper.GetBundleMD5(streamingVersionConfig, fileVersionInfo.File);


                    if (fileVersionInfo.MD5 == localFileMD5)
                    {
                        hasDonwLoadedFile.Add(fileVersionInfo.File, fileVersionInfo);
                        continue;
                    }


                    this.bundles.Enqueue(fileVersionInfo.File);

                    this.TotalSize += fileVersionInfo.Size;
                }
            }
            catch (Exception ex)
            {
                UnityEngine.Debug.LogError(ex.StackTrace);
            }
        }

        public IEnumerator DownloadAsync()
        {
            if (this.bundles.Count == 0 && this.downloadingBundle == "")
            {
                SetState(ProjectBtnState.Ready);
                yield break;
            }

            while (true)
            {
                if (this.bundles.Count == 0)
                {
                    SetState(ProjectBtnState.Ready);
                    yield break;
                }

                this.downloadingBundle = this.bundles.Dequeue();
                 while (true)
                {
                    webRequest = UnityWebRequest.Get(RemotePath + "/" + this.downloadingBundle);
                    yield return webRequest.SendWebRequest();
                    while (true)
                    {
                        if (Pause)
                        {
                            yield return new WaitForSeconds(0.1f);
                        }
                        if (!Pause)
                            break;
                    }
                    byte[] data = this.webRequest.downloadHandler.data;

                    string path = Path.Combine(SavePath, this.downloadingBundle);
                    using (FileStream fs = new FileStream(path, FileMode.Create))
                    {
                        fs.Write(data, 0, data.Length);
                    }
                    hasDonwLoadedFile.Add(this.downloadingBundle, remoteVersionConfig.FileInfoDict[this.downloadingBundle]);
                    VersionConfig config = new VersionConfig();
                    config.FileInfoDict = hasDonwLoadedFile;

                    var byteArray = System.Text.Encoding.UTF8.GetBytes(JsonMapper.ToJson(config));
                    using (FileStream fs = new FileStream(Path.Combine(SavePath, "Version.txt"), FileMode.Create))
                    {
                        fs.Write(byteArray, 0, byteArray.Length);
                    }
 
                    break;
                }
                this.downloadedBundles.Add(this.downloadingBundle);
                this.downloadingBundle = "";
                this.webRequest = null;
            }
        }

        public void DownLoadBundle()
        {
             switch (BtnState)
            {
                case ProjectBtnState.Updating:
                    Pause = true;
                    SetState(ProjectBtnState.Pause);
                    break;
                case ProjectBtnState.Ready:
                     FindObjectOfType<Init>().LoadProject(ProjectName);
                    break;
                case ProjectBtnState.Pause:
                    Pause = false;
                    SetState(ProjectBtnState.Updating);
                    break;
                case ProjectBtnState.NeedUpdate:
                    Pause = false;
                    StartCoroutine(DownloadAsync());
                    SetState(ProjectBtnState.Updating);
                    break;
                case ProjectBtnState.NeedDownLoad:
                    break;
            }
        }



        private float time;
        private ulong lastByte;
        private string speed;

        private void Update()
        {
            if (TotalSize != 0)
            {
                if (webRequest != null)
                {
                    time += Time.deltaTime;

                    if (time >= 1)
                    {
                         time = 0;
                    }

                    Progress.fillAmount = ProgressValue / 100f;
                    if (ProgressValue == 100)
                    {
                        SetState(ProjectBtnState.Ready);

                        using (FileStream fs = new FileStream(Path.Combine(SavePath, "Version.txt"), FileMode.Create))
                        {
                            fs.Write(remoteVersionConfigData, 0, remoteVersionConfigData.Length);
                        }
#if UNITY_EDITOR
                        //FileHelper.CleanDirectory(RemotePath);
                        //FileHelper.CopyDirectory(PathHelper.BuildPath + "/" + ProjectName, SavePath);
#endif
                    }
                }
            }
        }
        private KeyValuePair<string, string> ConventToSize(ulong size)
        {
            KeyValuePair<string, string> pair;
            float sizef = size;
            int count = 0;
            while (size > 1024)
            {
                size /= 1024;
                count++;
            }
            string value = size.ToString("f2");
            switch (count)
            {
                case 0:
                    pair = new KeyValuePair<string, string>(value, "B");
                    break;
                case 1:
                    pair = new KeyValuePair<string, string>(value, "KB");
                    break;
                case 2:
                    pair = new KeyValuePair<string, string>(value, "MB");
                    break;
                case 3:
                    pair = new KeyValuePair<string, string>(value, "G");
                    break;
            }
            return pair;
        }
    }
}
