using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor.AddressableAssets.Build;
using UnityEditor.AddressableAssets.Build.DataBuilders;
using UnityEditor.AddressableAssets.Settings;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Sirenix.Serialization;
using Sirenix.OdinInspector;
using ETEditor;
using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEditor.AddressableAssets.Settings.GroupSchemas;

namespace ETModel
{
    [CreateAssetMenu(fileName = "CleanBuilderPacked.asset", menuName = "Addressables/Content Builders/CleanBuild")]
    public class CleanBuildScript : BuildScriptPackedMode
    {
         public override string Name => "CreateAuto";

        public static string tempAddress { get; private set; }

        protected override TResult DoBuild<TResult>(AddressablesDataBuilderInput builderInput, AddressableAssetsBuildContext aaContext)
        {
  
             if (Directory.Exists(ETModel.PathHelper.RemoteBuildPath))
             FileHelper.CleanDirectory(ETModel.PathHelper.RemoteBuildPath);
 

            AddressableAssetSettings settings = AssetDatabase.LoadAssetAtPath<AddressableAssetSettings>($"{AddressableAssetSettingsDefaultObject.kDefaultConfigFolder}/{AddressableAssetSettingsDefaultObject.kDefaultConfigAssetName}.asset");
             //更新Group模板的发布路径和加载路径
            UpdateGroupTemplateBuildAndLoadPath(settings, $"{settings.GroupTemplateFolder}/Packed Assets.asset");
            //UpdateGroupBuildAndLoadPath(settings, $"{settings.GroupFolder}/Default Local Group.asset");

            //清除旧有资源
            CleanGroup(settings);
            List<AddressableAssetGroupSchema> schemas = AssetDatabase.LoadAssetAtPath<AddressableAssetGroupTemplate>($"{settings.GroupTemplateFolder}/Packed Assets.asset").SchemaObjects;
            string[] directories = Directory.GetDirectories($"{UnityEngine.Application.dataPath}/AddressableAssets/");
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


            var result = base.DoBuild<TResult>(builderInput, aaContext);
             return result;
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
                enity.SetAddress(Application.productName+"_"+ address);
                enity.SetLabel("default", true);


                tempAddress = address;
            }

            if (groupName == "Default Local Group")
            {
                settings.DefaultGroup = group;
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
            }
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
     }
}
