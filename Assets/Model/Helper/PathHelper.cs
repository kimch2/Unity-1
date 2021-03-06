using UnityEngine;

namespace ETModel
{
    public static class PathHelper
    {

#if UNITY_ANDROID
        public static string RemoteLoadPath = "http://139.196.233.153/Unity/Android";
        public static string BuildPath = "Assets/ServerData/Android";
#endif
#if UNITY_IPHONE
        public static string RemoteLoadPath = "http://139.196.233.153/Unity/IOS";
        public static string BuildPath = "Assets/ServerData/IOS";
#endif

#if UNITY_STANDALONE_WIN
        public static string RemoteLoadPath = "http://139.196.233.153/Unity/StandaloneWindows64";
        public static string BuildPath = "Assets/ServerData/StandaloneWindows64";
#endif
        public static string RemoteBuildPath => UnityEngine.AddressableAssets.Addressables.BuildPath;
        public static string SavePath => UnityEngine.AddressableAssets.Addressables.RuntimePath;


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
