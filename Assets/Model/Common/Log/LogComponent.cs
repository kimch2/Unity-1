using DG.Tweening;
using System;
using System.IO;
using UnityEngine;

namespace ETModel
{
    [ObjectSystem]
    public class LogComponentUpdateSystem : UpdateSystem<LogComponent>
    {
        public override void Update(LogComponent self)
        {
            self.Update();
        }
    }

    public class LogComponent : Component, ILogHandler
    {
        private StreamWriter streamWriter;

#if UNITY_EDITOR
        private ILogHandler unityDefaultLogHandler;
#endif

        private int currentPage;
        private UnityEngine.GameObject logWindow;
        private TMPro.TextMeshProUGUI logTMPU;
        private TMPro.TextMeshProUGUI pageInfoTMPU;
        private UnityEngine.UI.Button previousPageButton;
        private UnityEngine.UI.Button nextPageButton;

        private bool state = true;

        public async ETTask LoadAsync()
        {
            await InitializeAsync();

            string filePath = $"./Logs/{DateTime.Now.ToString("yyyy-MM-dd")}.txt";
            string directoryPath = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            streamWriter = new StreamWriter(filePath, true);

#if UNITY_EDITOR
            unityDefaultLogHandler = Debug.unityLogger.logHandler;
#endif
            Debug.unityLogger.logHandler = this;

            streamWriter.WriteLine($"{System.DateTime.Now.ToString("HH:mm:ss:ffff")}|{UnityEngine.LogType.Log}|程序启动");
            streamWriter.Flush();

            PushLogIntoLogWindow($"{System.DateTime.Now.ToString("HH:mm:ss:ffff")}|{UnityEngine.LogType.Log}|程序启动");

#if !UNITY_EDITOR
            this.state = !this.state;
            this.logTMPU.GetComponent<RectTransform>().DOAnchorPosX(this.state ? 20 : -640, 0.2f);
#endif
        }

        public void Update()
        {
            if (UnityEngine.Input.GetKeyUp(KeyCode.F11))
            {
                this.state = !this.state;
                this.logTMPU.GetComponent<RectTransform>().DOAnchorPosX(this.state ? 20 : -640, 0.2f);
            }
        }

        private async ETTask InitializeAsync()
        {
            using (UnityResourceLoadAsync unityResourceLoadAsync = ComponentFactory.Create<UnityResourceLoadAsync>())
            {
                this.logWindow = UnityEngine.GameObject.Instantiate(await unityResourceLoadAsync.LoadAsync("Launch/LogWindow") as UnityEngine.GameObject);
            }

            this.logTMPU = this.logWindow.transform.Find("Info").GetComponent<TMPro.TextMeshProUGUI>();
            this.pageInfoTMPU = this.logWindow.transform.Find("Info/PageInfo").GetComponent<TMPro.TextMeshProUGUI>();
            this.previousPageButton = this.logWindow.transform.Find("Info/PagePrevious").GetComponent<UnityEngine.UI.Button>();
            this.nextPageButton = this.logWindow.transform.Find("Info/PageNext").GetComponent<UnityEngine.UI.Button>();

            this.currentPage = 1;

            this.previousPageButton.onClick.AddListener(() =>
            {
                this.currentPage = Mathf.Max(1, this.currentPage - 1);
                this.logTMPU.pageToDisplay = this.currentPage;
                this.pageInfoTMPU.text = $"{this.currentPage}/{this.logTMPU.textInfo.pageCount}";
            });
            this.nextPageButton.onClick.AddListener(() =>
            {
                this.currentPage = Mathf.Min(this.logTMPU.textInfo.pageCount, this.currentPage + 1);
                this.logTMPU.pageToDisplay = this.currentPage;
                this.pageInfoTMPU.text = $"{this.currentPage}/{this.logTMPU.textInfo.pageCount}";
            });
        }

        private void PushLogIntoLogWindow(string input)
        {
            this.logTMPU.text += $"\n{input}";
            this.logTMPU.pageToDisplay = this.currentPage = this.logTMPU.textInfo.pageCount;
            this.pageInfoTMPU.text = $"{this.currentPage}/{this.logTMPU.textInfo.pageCount}";
        }

        public void LogFormat(UnityEngine.LogType logType, UnityEngine.Object context, string format, params object[] args)
        {
            streamWriter.WriteLine($"{System.DateTime.Now.ToString("HH:mm:ss:ffff")}|{logType}|{string.Format(format, args)}");
            streamWriter.Flush();

            PushLogIntoLogWindow($"{System.DateTime.Now.ToString("HH:mm:ss:ffff")}|{logType}|{string.Format(format, args)}");
#if UNITY_EDITOR
            //unityDefaultLogHandler.LogFormat(logType, context, format, args);
#endif
        }

        public void LogException(Exception exception, UnityEngine.Object context)
        {
            streamWriter.WriteLine($"{System.DateTime.Now.ToString("HH:mm:ss:ffff")}|{UnityEngine.LogType.Exception}|{exception}");
            streamWriter.Flush();

            PushLogIntoLogWindow($"{System.DateTime.Now.ToString("HH:mm:ss:ffff")}|{UnityEngine.LogType.Exception}|{exception}");
#if UNITY_EDITOR
            //unityDefaultLogHandler.LogException(exception, context);
#endif
        }

        public override void Dispose()
        {
            base.Dispose();

            streamWriter.WriteLine($"{System.DateTime.Now.ToString("HH:mm:ss:ffff")}|{UnityEngine.LogType.Log}|程序关闭");
            streamWriter.WriteLine();
            streamWriter.Flush();

            streamWriter.Dispose();
            streamWriter = null;

            PushLogIntoLogWindow($"{System.DateTime.Now.ToString("HH:mm:ss:ffff")}|{UnityEngine.LogType.Log}|程序关闭");

            UnityEngine.GameObject.Destroy(this.logWindow);
            this.logWindow = null;
            this.logTMPU = null;
            this.pageInfoTMPU = null;
            this.previousPageButton = null;
            this.nextPageButton = null;
#if UNITY_EDITOR
            Debug.unityLogger.logHandler = unityDefaultLogHandler;
            unityDefaultLogHandler = null;
#endif
        }
    }
}