using System;
using System.IO;
using ETModel;
using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEditor.AddressableAssets.Settings;
using wxb.Editor;

namespace ETEditor
{
    [InitializeOnLoad]
    public class Startup
    {
        private const string ScriptAssembliesDir = "Data";
        private const string CodeDir = "Assets/AddressableAssets/Code/";
        private const string HotfixDll = "DyncDll.dll";
        private const string HotfixPdb = "DyncDll.pdb";

        static Startup()
        {
            Reflash();
            //AssetDatabase.Refresh();
        }

        [MenuItem("XIL/Dll生成 &s")]
        public static void Reflash()
        {
            AddressableAssetSettings settings = AssetDatabase.LoadAssetAtPath<AddressableAssetSettings>($"{AddressableAssetSettingsDefaultObject.kDefaultConfigFolder}/{AddressableAssetSettingsDefaultObject.kDefaultConfigAssetName}.asset");
            UnityEngine.Debug.Log(UnityEngine.AddressableAssets.Addressables.PlayerBuildDataPath);
            UnityEngine.Debug.Log(settings.RemoteCatalogLoadPath.GetValue(settings));
             

             File.Copy(Path.Combine(ScriptAssembliesDir, HotfixDll), Path.Combine(CodeDir, "DyncDll.dll.bytes"), true);
            File.Copy(Path.Combine(ScriptAssembliesDir, HotfixPdb), Path.Combine(CodeDir, "DyncDll.pdb.bytes"), true);
            Hotfix.Inject();
            UnityEngine.Debug.Log($"复制Hotfix.dll, Hotfix.pdb到Res/Code完成");
        }
    }
}