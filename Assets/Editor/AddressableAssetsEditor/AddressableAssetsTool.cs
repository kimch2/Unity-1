using ETModel;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEditor.AddressableAssets.Settings;
using UnityEditor.AddressableAssets.Settings.GroupSchemas;

namespace ETEditor
{
    public class AddressableAssetsTool
    {
        private const string relativeDirPrefix = "../Release";

        private static string tempAddress = string.Empty;

        private static PropertyInfo bundleNamingPropertyInfo;

        public static bool Build(string target, string versionName, bool isClearStreamingAssetsFolder, bool isCopyToStreamingAssetsFolder, bool isBuildAssets, bool isBuildExecutor)
        {
            if (AddressableAssetSettingsDefaultObject.Settings == null)
            {
                EditorWindow.GetWindow<AddressableAssetsEditorWindow>().ShowNotification(new UnityEngine.GUIContent("请先通过\nWindow/Asset Management/Addressables/Groups\n打开面板\n并创建基础资源！"));
                return false;
            }
            AddressableAssetSettings settings = AssetDatabase.LoadAssetAtPath<AddressableAssetSettings>($"{AddressableAssetSettingsDefaultObject.kDefaultConfigFolder}/{AddressableAssetSettingsDefaultObject.kDefaultConfigAssetName}.asset");
            //if (settings.profileSettings.GetVariableNames().Contains(kStreamingLoadPath))
            //{
            //    settings.profileSettings.SetValue(settings.profileSettings.GetProfileId("Default"), kStreamingLoadPath, "{UnityEngine.Application.streamingAssetsPath}/[BuildTarget]");
            //}
            //else
            //{
            //    settings.profileSettings.CreateValue(kStreamingLoadPath, "{UnityEngine.Application.streamingAssetsPath}/[BuildTarget]");
            //}

            if (bundleNamingPropertyInfo == null)
            {
                bundleNamingPropertyInfo = typeof(BundledAssetGroupSchema).GetProperty("BundleNaming", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            }
            //更新Group模板的发布路径和加载路径
            UpdateGroupTemplateBuildAndLoadPath(settings, $"{settings.GroupTemplateFolder}/Packed Assets.asset");
            UpdateGroupBuildAndLoadPath(settings, $"{settings.GroupFolder}/Default Local Group.asset");

            //清除旧有资源
            CleanGroup(settings);

            //自动生成Group
            List<AddressableAssetGroupSchema> schemas = AssetDatabase.LoadAssetAtPath<AddressableAssetGroupTemplate>($"{settings.GroupTemplateFolder}/Packed Assets.asset").SchemaObjects;
            string[] directories = Directory.GetDirectories($"{UnityEngine.Application.dataPath}/AddressableAssets/");
            //string remoteBuildPath = $"./{settings.profileSettings.GetValueByName(settings.profileSettings.GetProfileId("Default"), AddressableAssetSettings.kRemoteBuildPath).Replace("[BuildTarget]", UnityEditor.EditorUserBuildSettings.activeBuildTarget.ToString())}";
            //string localBuildPath = $"./{settings.profileSettings.GetValueByName(settings.profileSettings.GetProfileId("Default"), AddressableAssetSettings.kLocalBuildPath).Replace("[UnityEngine.AddressableAssets.Addressables.BuildPath]", UnityEngine.AddressableAssets.Addressables.BuildPath).Replace("[BuildTarget]", UnityEditor.EditorUserBuildSettings.activeBuildTarget.ToString())}";
            string buildPath = $"./{UnityEngine.AddressableAssets.Addressables.BuildPath}";
            tempAddress = string.Empty;
            foreach (string folderPath in directories)
            {
                if (folderPath.Substring(folderPath.LastIndexOf('/') + 1).StartsWith("~"))
                {
                    continue;
                }
                BuildGroup(folderPath, settings, schemas);
            }

            //生成资源地址
            GenerateAddress(settings);

            //打包资源
            if (isBuildAssets)
            {
                FileHelper.CleanDirectory("Assets/ServerData/");
                AddressableAssetSettings.CleanPlayerContent();
                AddressableAssetSettings.BuildPlayerContent();

                if (!Directory.Exists(UnityEngine.Application.streamingAssetsPath))
                {
                    Directory.CreateDirectory(UnityEngine.Application.streamingAssetsPath);
                }

                 //复制打包资源到服务器资源文件夹
                FileHelper.CopyDirectory(buildPath.Substring(0, buildPath.IndexOf("aa")), $"../Release/{UnityEditor.EditorUserBuildSettings.activeBuildTarget}/{versionName}/");
                AssetDatabase.Refresh();
            }

            if (isBuildExecutor)
            {
                string[] levels = {
                    "Assets/Scenes/Init.unity",
                };
                DirectoryInfo directoryInfo = new System.IO.DirectoryInfo($"{relativeDirPrefix}/{UnityEditor.EditorUserBuildSettings.activeBuildTarget}/发布文件/{PlayerSettings.productName}_{UnityEngine.SystemInfo.deviceName}_{System.DateTime.Now.ToString("yyyyMMddmmHHss")}/");
                if (!directoryInfo.Exists)
                {
                    directoryInfo.Create();
                }

                Log.Info("开始打包可执行文件...");
                BuildPipeline.BuildPlayer(levels, $"{directoryInfo.FullName}{PlayerSettings.productName}.exe", EditorUserBuildSettings.activeBuildTarget, BuildOptions.None);
                Log.Info("可执行文件打包完成.");
                AssetDatabase.Refresh();

                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo.FileName = "explorer";
                process.StartInfo.Arguments = @"/e /root," + directoryInfo.FullName;
                process.Start();
            }

            Log.Info("完成");
            return true;
        }

        private static void CleanGroup(AddressableAssetSettings settings)
        {
            foreach (AddressableAssetGroup group in settings.groups.ToArray())
            {
                if (group.name == "Built In Data" || group.name == "Default Local Group")
                {
                    continue;
                }
                settings.RemoveGroup(group);
            }
        }

        private static void UpdateGroupTemplateBuildAndLoadPath(AddressableAssetSettings settings, string path)
        {
            List<AddressableAssetGroupSchema> schemas = AssetDatabase.LoadAssetAtPath<AddressableAssetGroupTemplate>(path).SchemaObjects;
            BundledAssetGroupSchema bundledAssetGroupSchema = schemas.Find(p => p.GetType() == typeof(BundledAssetGroupSchema)) as BundledAssetGroupSchema;
            if (bundledAssetGroupSchema != null)
            {
                bundledAssetGroupSchema.BuildPath.SetVariableByName(settings, AddressableAssetSettings.kRemoteBuildPath);
                bundledAssetGroupSchema.LoadPath.SetVariableByName(settings, AddressableAssetSettings.kRemoteLoadPath);

                bundleNamingPropertyInfo.SetValue(bundledAssetGroupSchema, 1);
            }
        }

        private static void UpdateGroupBuildAndLoadPath(AddressableAssetSettings settings, string path)
        {
            List<AddressableAssetGroupSchema> schemas = AssetDatabase.LoadAssetAtPath<AddressableAssetGroup>(path).Schemas;
            BundledAssetGroupSchema bundledAssetGroupSchema = schemas.Find(p => p.GetType() == typeof(BundledAssetGroupSchema)) as BundledAssetGroupSchema;
            if (bundledAssetGroupSchema != null)
            {
                bundledAssetGroupSchema.BuildPath.SetVariableByName(settings, AddressableAssetSettings.kRemoteBuildPath);
                bundledAssetGroupSchema.LoadPath.SetVariableByName(settings, AddressableAssetSettings.kRemoteLoadPath);

                bundleNamingPropertyInfo.SetValue(bundledAssetGroupSchema, 1);
            }
        }

        private static void BuildGroup(string groupFolder, AddressableAssetSettings settings, List<AddressableAssetGroupSchema> schemas)
        {
            List<string> assetPaths = Directory.EnumerateFiles(groupFolder, "*.*", SearchOption.AllDirectories)
                .Where(p => Path.GetExtension(p) != ".meta")
                .Select(p => p.Substring(UnityEngine.Application.dataPath.Length - 6))
                .ToList();
            if (assetPaths.Count < 1)
            {
                return;
            }
            string groupName = groupFolder.Substring(groupFolder.LastIndexOf('/') + 1);
            if (groupName.StartsWith("~") || groupName == "Resources")
            {
                return;
            }
            AddressableAssetGroup group = settings.FindGroup(groupName);
            if (group != null)
            {
                settings.RemoveGroup(group);
            }
            group = settings.CreateGroup(groupName, false, false, true, schemas);
            foreach (string path in assetPaths)
            {
                string address = Path.GetFileNameWithoutExtension(path);
                if (address.StartsWith("~"))
                {
                    continue;
                }
                if (address == tempAddress)
                {
                    Log.Info($"Address重复->{address}");
                }
                var enity = settings.CreateOrMoveEntry(AssetDatabase.AssetPathToGUID(path), group);
                enity.SetAddress(address);
                enity.SetLabel("default", true);


                tempAddress = address;
            }

            if (groupName == "Default Local Group")
            {
                settings.DefaultGroup = group;
            }
        }

        private static void GenerateAddress(AddressableAssetSettings settings)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("namespace ETModel");
            sb.AppendLine("{");
            sb.AppendLine("\tpublic sealed class Address");
            sb.AppendLine("\t{");
            foreach (AddressableAssetGroup group in settings.groups)
            {
                foreach (AddressableAssetEntry entry in group.entries)
                {
                    string fieldName = $"{group.Name}_{entry.address}".Replace(" ", string.Empty).Replace(".", "_").Replace("-", "_").Replace("×", "_");
                    sb.AppendLine($"\t\tpublic const string {fieldName} = \"{entry.address}\";");
                }
            }
            sb.AppendLine("\t}");
            sb.AppendLine("}");
            File.WriteAllText($"{UnityEngine.Application.dataPath}/Model/Common/Addressables/Address.cs", sb.ToString());
        }
      }
}