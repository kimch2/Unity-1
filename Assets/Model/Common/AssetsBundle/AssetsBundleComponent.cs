
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement;
using UnityEngine.ResourceManagement.AsyncOperations;
namespace ETModel
{
    public class AssetsBundleComponent : MonoBehaviour
    {
         public TMPro.TMP_Text Info;
        public TMPro.TMP_Text Progress;
        public TMPro.TMP_Text DownLoadSize;
        public GameObject ConfirmPanel;
        public UnityEngine.UI.Button ConfirmBtn;

        public Init InitScript;
 
         void Start()
        {
             ConfirmBtn.onClick.AddListener(DownLoadBundle);
            CheckDownLoadSize();
        }


        public async void CheckDownLoadSize()
        {
            Info.text = "正在检测文件更新.......";

            await StartAsync();
            UnityEngine.Debug.LogError(TotalSize);
            if (TotalSize != 0)
            {
                DownLoadSize.text = FileHelper.ConventToSize(TotalSize);
                ConfirmPanel.SetActive(true);
            }
            else
            {
                Info.text = "无需更新.......";
                var bundle = AssetBundle.LoadFromFileAsync(scenepath);
                 gameObject.SetActive(false);
                 InitScript.StartAsync();
            }
        }

        private VersionConfig remoteVersionConfig;
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
                    versionUrl = PathHelper.RemoteLoadPath + "/Version.txt";
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
                string versionPath = PathHelper.SavePath + "Version.txt";
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
                    int directoryFolderLength = directoryInfo.FullName.Length + 1;
                    foreach (FileInfo fileInfo in fileInfos)
                    {
                        if (remoteVersionConfig.FileInfoDict.ContainsKey(fileInfo.FullName.Substring(directoryFolderLength)))
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
                                await this.webRequest.DownloadAsync(PathHelper.RemoteLoadPath + "/"+ this.downloadingBundle);
                                byte[] data = this.webRequest.Request.downloadHandler.data;

                                string path = PathHelper.SavePath+ this.downloadingBundle;
                                using (FileStream fs = new FileStream(path, FileMode.Create))
                                {
                                    fs.Write(data, 0, data.Length);
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
        }
        private string scenepath = PathHelper.SavePath+"scene";

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
                        var speedValue = lastByte - webRequest.ByteDownloaded;
                        lastByte = webRequest.ByteDownloaded;
                        var data = ConventToSize(speedValue);
                        speed = data.Key + data.Value;
                        time = 0;
                    }

                    Progress.text = $"下载中....{ProgressValue}%    速度{speed}";
                    if (ProgressValue == 100)
                    {
                        using (FileStream fs = new FileStream(PathHelper.SavePath+ "Version.txt", FileMode.Create))
                        {
                            fs.Write(remoteVersionConfigData, 0, remoteVersionConfigData.Length);
                        }
                        var bundle = AssetBundle.LoadFromFileAsync(scenepath);
                        InitScript.StartAsync();
                        gameObject.SetActive(false);
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
