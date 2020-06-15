using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System.IO;
using System.Linq;
using UnityEditor;
using System;
using System.Text.RegularExpressions;

namespace ETModel
{

    [CreateAssetMenu(menuName = "DataManager/Component/Manager")]
    public class ComponentManager : SerializedScriptableObject
    {
        public List<ComponentInfo> components = new List<ComponentInfo>();

        public string ComponentPath = "Assets/Model";
        public string ComponentInfoPath = "Assets/Model/Common/ScriptObject/ComponentInfo";

        [Button("扫描组件", ButtonSizes.Medium)]
        public void ScanComponentHandle()
        {
            ScanComponent(ComponentPath);
        }

        private void ScanComponent(string directory)
        {
            var directoryInfo = new DirectoryInfo(directory);
            GetFileName(directoryInfo);
            foreach (var Directories in directoryInfo.GetDirectories())
            {
                ScanComponent(Directories.FullName);
            }
#if UNITY_EDITOR
            AssetDatabase.Refresh();
#endif
        }

        private void GetFileName(DirectoryInfo directoryInfo)
        {
#if UNITY_EDITOR
            foreach (var item in directoryInfo.GetFiles())
            {
                var fullname = item.FullName;
                var temp = fullname.Split('\\');

                if (fullname.EndsWith("Component.cs"))
                {
                    var name = temp[temp.Length - 1].Split('.')[0];
                    if (components.Select(x => x).Count(y => y.name == name) == 0)
                    {
                        var data = Regex.Split(fullname, "Assets", RegexOptions.IgnoreCase);
                        var target = AssetDatabase.LoadAssetAtPath<TextAsset>("Assets" + data[1]);
                        var infopath = ComponentInfoPath + "/" + name + ".asset";
                        if (target == null)
                        {
                            if (File.Exists(infopath))
                            {
                                File.Delete(infopath);
                            }
                            continue;
                        }
                        if (!File.Exists(infopath))
                        {
                            ComponentInfo scriptableObj = CreateInstance<ComponentInfo>();
                            scriptableObj.name = name;
                            scriptableObj.Target = AssetDatabase.LoadAssetAtPath<TextAsset>("Assets" + data[1]);
                            components.Add(scriptableObj);
                            AssetDatabase.CreateAsset(scriptableObj, ComponentInfoPath + "/" + name + ".asset");
                            EditorUtility.SetDirty(scriptableObj);
                        }
                        else
                        {
                            var scriptableObj = AssetDatabase.LoadAssetAtPath<ComponentInfo>(infopath);
                            components.Add(scriptableObj);
                            EditorUtility.SetDirty(scriptableObj);
                        }
                    }
                }
            }
#endif
        }
    }
}