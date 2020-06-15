using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace ETModel
{
     public class AddressableAssetComponent : Component
    {
        public TMPro.TMP_Text Info;
        public TMPro.TMP_Text Progress;
        public TMPro.TMP_Text DownLoadSize;

        public UnityEngine.UI.Button ConfirmBtn;
        private long TotalSize;

        public async ETTask StartAsync()
        {
            await CheckUpdate();
            await CheckDownLoadSize();
        }


        public async ETTask CheckDownLoadSize()
        {
            var size = Addressables.GetDownloadSizeAsync("default");
            await size.Task;
            if (size.Result != 0)
            {
                DownLoadSize.text = ConventToSize(size.Result);
                TotalSize = size.Result;
            }
            else
            {
                Info.text = "无需更新.......";
            }
        }

        private KeyValuePair<string, string> ConventToSize(float size)
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
        private string ConventToSize(long size)
        {
            float sizef = size;
            for (int i = 0; i < 2; i++)
            {
                sizef /= 1024;
            }
            return sizef.ToString("f2") + "MB";
        }

        public void DownLoadBundle()
        {
            StartDownLoadBundle();
        }


        float speed;
        float lastSize;

        public async void StartDownLoadBundle()
        {
            var size = Addressables.DownloadDependenciesAsync("default");
            while (!size.IsDone)
            {
                float currentsize = TotalSize * size.PercentComplete;
                speed = currentsize - lastSize;
                DownLoadSize.text = $"({ConventToSize(currentsize)}  速度:{ConventToSize(speed)})";
                lastSize = currentsize;
                await Task.Delay(100);
            }
            DownLoadSize.text = "下载完成!";
        }



        public async ETTask CheckUpdate()
        {
            checkingUpdate = true;
            var init = Addressables.InitializeAsync();
            await init.Task;
            var check = Addressables.CheckForCatalogUpdates(false);
            await check.Task;
            switch (check.Status)
            {
                case AsyncOperationStatus.Succeeded:
                    if (check.Result.Count > 0)
                    {
                        needUpdateCatalogs = check.Result;
                        DownLoadUpdate();
                    }
                    break;
                default:
                    Info.text = "更新失败";
                    break;
            }
            checkingUpdate = false;
        }


        private List<string> needUpdateCatalogs;
        private AsyncOperationHandle<List<IResourceLocator>> updateHandle;

        float CHECKTIMEMAX = 10;
        float checkUpdateTime = 0;
        bool checkingUpdate;
        bool isUpdating;
        private void Update()
        {
            if (checkingUpdate)
            {
                checkUpdateTime += Time.deltaTime;
                if (checkUpdateTime > CHECKTIMEMAX)
                {
                    //自测连接超时
                    checkingUpdate = false;
                    Info.text = $"Connect Timed Out";
                }
            }

            if (isUpdating)
            {
                int progress = (int)(updateHandle.PercentComplete * 100);
                Progress.text = $"正在更新资源... {progress}%";
            }
        }

        private async void DownLoadUpdate()
        {
            isUpdating = true;
            var start = DateTime.Now;
            //开始下载资源
            updateHandle = Addressables.UpdateCatalogs(needUpdateCatalogs, false);

            await updateHandle.Task;
            Debug.Log(string.Format("UpdateFinish use {0}ms", (DateTime.Now - start).Milliseconds));
            //下载完成
            Addressables.Release(updateHandle);
            isUpdating = false;
        }
    }
}