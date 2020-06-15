using UnityEngine;

namespace ETModel
{
    public static class PathHelper
    {

#if UNITY_ANDROID
        public static string RemoteLoadPath = "http://songsongbeibei.com/StreamingAssets/Unity/Android";
        public static string RemoteBuildPath = "Assets/ServerData/Android";
        public static string SavePath = Application.streamingAssetsPath + "/Android/";
#endif

#if UNITY_IPHONE
        public static string RemoteLoadPath = "http://songsongbeibei.com/StreamingAssets/Unity/IOS";
        public static string RemoteBuildPath ="Assets/ServerData/IOS";
        public static string SavePath =Application.streamingAssetsPath+ "/IOS";
#endif

#if UNITY_STANDALONE_WIN
        public static string RemoteLoadPath = "http://songsongbeibei.com/StreamingAssets/Unity/StandaloneWindows64";
        public static string RemoteBuildPath = "Assets/ServerData/StandaloneWindows64";
        public static string SavePath =  Application.streamingAssetsPath+ "/StandaloneWindows64";
#endif


        /// <summary>
        ///应用程序外部资源路径存放路径(热更新资源路径)
        /// </summary>
        public static string AppHotfixResPath
        {
            get
            {
                string game = Application.productName;
                string path = AppResPath;
                if (Application.isMobilePlatform)
                {
                    path = $"{Application.persistentDataPath}/{game}/";
                }
                return path;
            }

        }
  
        /// <summary>
        /// 应用程序内部资源路径存放路径
        /// </summary>
        public static string AppResPath
        {
            get
            {
                return Application.streamingAssetsPath;
            }
        }

        /// <summary>
        /// 应用程序内部资源路径存放路径(www/webrequest专用)
        /// </summary>
        public static string AppResPath4Web
        {
            get
            {
#if UNITY_IOS || UNITY_STANDALONE_OSX
                return $"file://{Application.streamingAssetsPath}";
#else
                return Application.streamingAssetsPath;
#endif

            }
        }
    }
}
