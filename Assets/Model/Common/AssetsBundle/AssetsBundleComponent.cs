 using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

namespace ETModel
{

    public class ProjectConfig
    {
        public List<ProjectInfo> ProjectList = new List<ProjectInfo>();
    }

    public class ProjectInfo
    {
        public string ID;
        public string Name;
    }

    public class AssetsBundleComponent : MonoBehaviour
    {
        public Text VersionText;

        public Text Info;
        public Text Progress;
        public Text DownLoadSize;
        public GameObject ConfirmPanel;
        public UnityEngine.UI.Button ConfirmBtn;
        public UnityEngine.UI.Button AllDownLoad;

        public Init InitScript;
 
         void Start()
        {
             AllDownLoad.onClick.Add(DownLoadAll);
             ConfirmBtn.onClick.AddListener(DownLoadBundle);
             CheckDownLoadSize();
        }

        private void DownLoadAll()
        {
             foreach (var item in Grid.GetComponentsInChildren<ProjectBtn>())
            {
                if (item.GetState() == ProjectBtnState.NeedUpdate)
                {
                    item.DownLoadBundle();
                }
            }
        }

        public async void CheckDownLoadSize()
        {
            Info.text = "正在检测文件更新.......";
            await StartAsync();

            //while (!successConnect)
            //{
            //     if (time == 0)
            //    {
            //        await StartAsync();
            //    }
            //    time += 1;
            //    time =time>= 10 ? 0 : time;
            //    await Task.Delay(1000);
            //}
 
            if (TotalSize != 0)
            {
                DownLoadSize.text = FileHelper.ConventToSize(TotalSize);
                ConfirmPanel.SetActive(true);
            }
            else
            {
                Info.text = "无需更新.......";
                CheckProject();
             }
        }

        private VersionConfig remoteVersionConfig;

        private Dictionary<string, FileVersionInfo> hasDonwLoadedFile = new Dictionary<string, FileVersionInfo>();
        private byte[] remoteVersionConfigData;

        public Queue<string> bundles = new Queue<string>();

        public long TotalSize;

        public HashSet<string> downloadedBundles = new HashSet<string>();

        public string downloadingBundle;

        public UnityWebRequestAsync webRequest;
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
                    alreadyDownloadBytes += (long)this.webRequest.Request.downloadedBytes;
                }
                DownLoadSize.text =$"剩余大小: {FileHelper.ConventToSize(TotalSize- alreadyDownloadBytes)}";

                return (int)(alreadyDownloadBytes * 100f / this.TotalSize);
            }
        }

        bool successConnect;
        public async ETTask StartAsync()
        {
            // 获取远程的Version.txt
            string versionUrl = "";
            try
            {
                using (UnityWebRequestAsync webRequestAsync = ComponentFactory.Create<UnityWebRequestAsync>())
                {
                     versionUrl = PathHelper.RemoteLoadPath + "/platform/Version.txt";
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
                string versionPath =Path.Combine( PathHelper.SavePath , "Version.txt");
                if (File.Exists(versionPath))
                {
                     streamingVersionConfig = JsonHelper.FromJson<VersionConfig>(File.ReadAllText(versionPath));
                }
                else
                {
                     streamingVersionConfig = new VersionConfig();
                }

                // 删掉远程不存在的文件
                DirectoryInfo directoryInfo = new DirectoryInfo(PathHelper.SavePath);
                if (directoryInfo.Exists)
                {
                    FileInfo[] fileInfos = directoryInfo.GetFiles();
                    int directoryFolderLength = directoryInfo.FullName.Length;
                     foreach (FileInfo fileInfo in fileInfos)
                    {
 
                         if (remoteVersionConfig.FileInfoDict.ContainsKey(fileInfo.FullName.Substring(directoryFolderLength).Replace("\\","")))
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
            successConnect = true;
         }

        public async ETTask DownloadAsync()
        {
             if (this.bundles.Count == 0 && this.downloadingBundle == "")
            {
                return;
            }

            try
            {
                while (true)
                {
                    if (this.bundles.Count == 0)
                    {
                        break;
                    }

                    this.downloadingBundle = this.bundles.Dequeue();

                    while (true)
                    {
                        try
                        {
                             using (this.webRequest = ComponentFactory.Create<UnityWebRequestAsync>())
                            {
                                 await this.webRequest.DownloadAsync(PathHelper.RemoteLoadPath + "/platform/" + this.downloadingBundle);
                                byte[] data = this.webRequest.Request.downloadHandler.data;

                                string path =Path.Combine( PathHelper.SavePath, this.downloadingBundle);
                                using (FileStream fs = new FileStream(path, FileMode.Create))
                                {
                                    fs.Write(data, 0, data.Length);
                                }
                                hasDonwLoadedFile.Add(this.downloadingBundle, remoteVersionConfig.FileInfoDict[this.downloadingBundle]);
                                VersionConfig config = new VersionConfig();
                                config.FileInfoDict = hasDonwLoadedFile;
                  
                                var byteArray = System.Text.Encoding.UTF8.GetBytes(JsonMapper.ToJson(config));
                                using (FileStream fs = new FileStream(Path.Combine( PathHelper.SavePath , "Version.txt"), FileMode.Create))
                                {
                                    fs.Write(byteArray, 0, byteArray.Length);
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            Log.Error($"download bundle error: {this.downloadingBundle}\n{e}");
                            continue;
                        }

                        break;
                    }
                    this.downloadedBundles.Add(this.downloadingBundle);
                    this.downloadingBundle = "";
                    this.webRequest = null;
                }
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }

        public void DownLoadBundle()
        {
            DownloadAsync();
            ConfirmBtn.gameObject.SetActive(false);
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
                    Progress.text = $"下载中....{ProgressValue}%   ";
                    if (ProgressValue == 100)
                    {
                        using (FileStream fs = new FileStream(Path.Combine(PathHelper.SavePath, "Version.txt"), FileMode.Create))
                        {
                            fs.Write(remoteVersionConfigData, 0, remoteVersionConfigData.Length);
                        }
                         CheckProject();
                    }
                }
            }
        }


        public UIGrid Grid;
        private async void CheckProject()
        {
            try
            {
                VersionConfig streamingVersionConfig;
                string versionPath = Path.Combine(PathHelper.SavePath, "Version.txt");
                UnityEngine.Debug.Log(versionPath);
                streamingVersionConfig = JsonHelper.FromJson<VersionConfig>(File.ReadAllText(versionPath));
                VersionText.text = streamingVersionConfig.Version;

                transform.Find("UpdateWindow").gameObject.SetActive(false);
                transform.Find("ProjectSelectWindow").gameObject.SetActive(true);

                using (UnityWebRequestAsync webRequestAsync = ComponentFactory.Create<UnityWebRequestAsync>())
                {
                    await webRequestAsync.DownloadAsync(PathHelper.RemoteLoadPath + "/ProductConfig.txt");
                    remoteVersionConfigData = webRequestAsync.Request.downloadHandler.data;
 
                    var data = JsonHelper.FromJson<ProjectConfig>(webRequestAsync.Request.downloadHandler.text);

                    var namelist = data.ProjectList.Select(x => x.Name).ToList();
                    var idlist = data.ProjectList.Select(x => x.ID).ToList();
                    for (int i = 0; i < namelist.Count; i++)
                    {
                        var bytes = namelist[i].ToByteArray();
                        namelist[i] = Encoding.UTF8.GetString(bytes);
                    }
                    Grid.Show(namelist);
                    for (int i = 0; i < idlist.Count; i++)
                    {
                        Grid.m_ShowList[i].GetComponent<ProjectBtn>().InitProjectBtn(idlist[i]);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Log(ex.StackTrace);
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
