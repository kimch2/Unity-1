namespace wxb
{
    using System.IO;
    using System.Threading.Tasks;
    using UnityEngine;
    using UnityEngine.AddressableAssets;

    public interface IResLoad
    {
        Stream GetStream(string path);
    }

#if UNITY_EDITOR
    // 编辑器下的资源加载
    class EditorResLoad : IResLoad
    {
        public EditorResLoad()
        {
            RootPath = ResourcesPath.dataPath + "/../";
        }

        string RootPath { get; set; }

        Stream IResLoad.GetStream(string path)
        {
            string filepath = RootPath + path;

            UnityEngine.Debug.LogError(filepath);

            if (!File.Exists(filepath))
            {
                return null;
            }

            try
            {
                return new MemoryStream(File.ReadAllBytes(filepath));
            }
            catch (System.Exception ex)
            {
                wxb.L.LogException(ex);
            }

            return null;
        }
    }
#endif


    public static class ResLoad
    {
        static IResLoad current = null;

        public static void Set(IResLoad load)
        {
            current = load;
        }

        public async static Task<Stream> GetStream(string path)
        {
            var code = await Addressables.LoadAssetAsync<UnityEngine.GameObject>("Code").Task;
            byte[] assBytes = (code.GetComponent<ReferenceCollector>().Get<Object>(path) as TextAsset) .bytes;
            return new MemoryStream(assBytes);
        }
    }
}