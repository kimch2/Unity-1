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
using System.Threading.Tasks;

namespace ETModel
{
    [CreateAssetMenu(fileName = "VersionBuilderPacked.asset", menuName = "Addressables/Content Builders/CostomBuild")]
    public class CustomBuildScript : BuildScriptPackedMode
    {
         public override string Name => "VersionBuilder";
         protected override TResult DoBuild<TResult>(AddressablesDataBuilderInput builderInput, AddressableAssetsBuildContext aaContext)
        {
            if (Directory.Exists(ETModel.PathHelper.RemoteBuildPath))
                FileHelper.CleanDirectory(ETModel.PathHelper.RemoteBuildPath);
            if (Directory.Exists(ETModel.PathHelper.BuildPath))
                FileHelper.CleanDirectory(ETModel.PathHelper.BuildPath);
            var result = base.DoBuild<TResult>(builderInput, aaContext);
            var filepath = ETModel.PathHelper.RemoteBuildPath;
            BuildVerison(filepath);
            FileHelper.CopyDirectory(PathHelper.RemoteBuildPath, PathHelper.BuildPath);
            return result;
        }
  
         public void BuildVerison(string dir)
         {
           VersionConfig versionProto = new VersionConfig();
            GenerateVersionProto(dir, versionProto, "");

            using (FileStream fileStream = new FileStream($"{dir}/Version.txt", FileMode.Create))
            {
                byte[] bytes = JsonHelper.ToJson(versionProto).ToByteArray();
                fileStream.Write(bytes, 0, bytes.Length);
            }
        }

        private static void GenerateVersionProto(string dir, VersionConfig versionProto, string relativePath)
        {
            foreach (string file in Directory.GetFiles(dir))
            {
                string md5 = MD5Helper.FileMD5(file);
                FileInfo fi = new FileInfo(file);
                long size = fi.Length;
                string filePath = relativePath == "" ? fi.Name : $"{relativePath}/{fi.Name}";

                versionProto.FileInfoDict.Add(filePath, new FileVersionInfo
                {
                    File = filePath,
                    MD5 = md5,
                    Size = size,
                });
            }

             foreach (string directory in Directory.GetDirectories(dir))
            {
                 DirectoryInfo dinfo = new DirectoryInfo(directory);
                string rel = relativePath == "" ? dinfo.Name : $"{relativePath}/{dinfo.Name}";
                GenerateVersionProto($"{dir}/{dinfo.Name}", versionProto, rel);
            }
        }
    }
}
