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
    public class AddressableAssetsComponent : MonoBehaviour
    {
 

        public TMPro.TMP_Text Info;
        public TMPro.TMP_Text Progress;
        public TMPro.TMP_Text DownLoadSize;

        public GameObject ConfirmPanel;
        public UnityEngine.UI.Button ConfirmBtn;
        private long TotalSize;

        public Init InitScript;
        IEnumerator  Start()
        {
             yield return   StartCoroutine(CheckUpdate());
            CheckDownLoadSize();
        }

        public void SetTextInfo(string info)
        {
            Info.text = info;
        }

        public async void CheckDownLoadSize()
        {
            var size = Addressables.GetDownloadSizeAsync("default");
            await size.Task;
            if (size.Result != 0)
            {
                DownLoadSize.text = FileHelper.ConventToSize(size.Result);
                TotalSize = (long)(size.Result);
                ConfirmPanel.SetActive(true);
            }
            else
            {
                Info.text = "无需更新.......";
                InitScript.StartAsync();
                gameObject.SetActive(false);
            }
        }

       

        public void DownLoadBundle()
        {
              StartCoroutine(StartDownLoadBundle());
        }


        float speed;
        float lastSize;

        public IEnumerator StartDownLoadBundle()
        {
             var size = Addressables.DownloadDependenciesAsync("default");
            float time = 0;
            while (!size.IsDone)
            {
                time += Time.deltaTime;
                float progress =float.Parse( (size.PercentComplete * 100).ToString("f2"));
                Progress.text = $"正在更新资源... {progress}%";

                if (time > 1)
                {
                    float currentsize = TotalSize * size.PercentComplete;
                    speed = currentsize - lastSize;
                    DownLoadSize.text = $" {FileHelper.ConventToSize(currentsize)}  速度: {FileHelper.ConventToSize(speed)}";
                    lastSize = currentsize;
                    time = 0;
                }
                yield return null;
            }
 
            DownLoadSize.text = "下载完成!";

            InitScript.StartAsync();
            gameObject.SetActive(false);

        }



        public IEnumerator CheckUpdate()
        {
            Info.text = "正在检测文件更新.......";

            checkingUpdate = true;
            var init = Addressables.InitializeAsync();
            yield return init;
            var check = Addressables.CheckForCatalogUpdates(false);
            yield return check;
            switch (check.Status)
            {
                case AsyncOperationStatus.Succeeded:
                    needUpdateCatalogs = check.Result;
                    yield return StartCoroutine(DownLoadUpdate());
                    break;
                default:
                    Info.text = "更新失败";
                    yield break;
            }
            checkingUpdate = false;
        }


        private List<string> needUpdateCatalogs;
        private AsyncOperationHandle<List<IResourceLocator>> updateHandle;

        float CHECKTIMEMAX = 10;
        float checkUpdateTime = 0;
        bool checkingUpdate;
        private void Update()
         {
             if (checkingUpdate)
             {
                 checkUpdateTime += Time.deltaTime;
                 if (checkUpdateTime > CHECKTIMEMAX)
                 {
                     //自测连接超时
                     checkingUpdate = false;
                     StopAllCoroutines();
                     Info.text = $"连接超时";
                     Start();
                   }
             }
        }

        private IEnumerator DownLoadUpdate()
        {
             var start = DateTime.Now;
            if (needUpdateCatalogs.Count != 0)
            {
                updateHandle = Addressables.UpdateCatalogs(needUpdateCatalogs, false);
            }
            yield return updateHandle;
            Debug.Log(string.Format("UpdateFinish use {0}ms", (DateTime.Now - start).Milliseconds));
          }
    }
}