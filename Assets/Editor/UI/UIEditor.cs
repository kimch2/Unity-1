using ETModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace ETEditor
{
    public class UIEditor
    {
        public const string ComponentName = "{0}Component";
        public const string ComponentFolderPath = "{0}/Model/Module/Demo/Common/UIWindow/{1}/";
 
        public static readonly StringBuilder sb = new StringBuilder();

        [MenuItem("Tools/UI工具/生成UI窗口组件")]
        public static void GenerateUIWindowComponent()
        {
            GenerateUIWindowComponent(true, true, true);
         }


        [MenuItem("Tools/UI工具/生成UI窗口文件夹")]
        public static void GenerateUIWindowFolder()
        {
            Transform transform = default(Transform);
            if (Selection.activeGameObject is UnityEngine.GameObject hierarchyObject
                && hierarchyObject.name.EndsWith("Window")
                && hierarchyObject.GetComponent<Canvas>())
            {
                transform = hierarchyObject.transform;
            }
            else if (Selection.activeObject is UnityEngine.Object projectObject
                && projectObject.name.EndsWith("Window")
                && projectObject is GameObject go
                && go.GetComponent<Canvas>())
            {
                transform = go.transform;
            }

            if (transform)
            {
                string name = string.Format(ComponentName, transform.name);
                string componentFolderPath = string.Format(ComponentFolderPath, Application.dataPath, transform.name);
                if (!System.IO.Directory.Exists(componentFolderPath))
                {
                    System.IO.Directory.CreateDirectory(componentFolderPath);
                }
 

                AssetDatabase.Refresh();
            }
        }

        [MenuItem("Tools/UI工具/打开UI窗口缓存文件夹")]
        public static void OpenUIWindowFolder()
        {
            System.IO.DirectoryInfo directoryInfo = new System.IO.DirectoryInfo("./Library/UIWindow/");
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = "explorer";
            process.StartInfo.Arguments = @"/e /root," + directoryInfo.FullName;
            process.Start();
        }

        private static void GenerateUIWindowComponent(bool awake, bool command, bool logic)
        {
            if (!awake && !logic && !command)
            {
                return;
            }

            Transform transform = default(Transform);
            if (Selection.activeGameObject is UnityEngine.GameObject hierarchyObject
                && hierarchyObject.name.EndsWith("Window")
                && hierarchyObject.GetComponent<Canvas>())
            {
                transform = hierarchyObject.transform;
            }
            else if (Selection.activeObject is UnityEngine.Object projectObject
                && projectObject.name.EndsWith("Window")
                && projectObject is GameObject go
                && go.GetComponent<Canvas>())
            {
                transform = go.transform;
            }

            if (transform)
            {
                string name = string.Format(ComponentName, transform.name);
                string componentFolderPath = string.Format(ComponentFolderPath, Application.dataPath, transform.name);
                if (!System.IO.Directory.Exists(componentFolderPath))
                {
                    System.IO.Directory.CreateDirectory(componentFolderPath);
                }
 

                sb.Clear();
                Dictionary<Transform, List<string>> fieldTargets
                    = transform.GetComponentsInChildren<Transform>(true)
                    .Where(p => p.name.Contains("_"))
                    .ToDictionary(p => p, p => p.name.Split('_').Distinct().Skip(1).OrderBy(x => x).ToList());

                #region 方法逻辑
                if (!System.IO.File.Exists($"{componentFolderPath}{name}.cs"))
                {
                    sb.Clear();
                    sb.AppendLine("namespace ETModel");
                    sb.AppendLine("{");
                    sb.AppendLine($"\tpublic partial class {name} : UIPanelComponent");
                    sb.AppendLine("\t{");
                    sb.AppendLine("\t\tprivate void RegisterEvent()");
                    sb.AppendLine("\t\t{");
                    sb.AppendLine("\t\t}");
                    sb.AppendLine("\t}");
                    sb.AppendLine("}");
 
                    sb.AppendLine();
 
                    System.IO.DirectoryInfo directoryInfo = new System.IO.DirectoryInfo("./Library/UIWindow/");
                    if (!directoryInfo.Exists)
                    {
                        directoryInfo.Create();
                    }
                    if (System.IO.File.Exists($"{componentFolderPath}{name}.cs"))
                    {
                        //System.IO.File.Copy($"{componentFolderPath}{name}_Logic.cs", $"{directoryInfo.FullName}{name}_Logic.cs");
                    }
                     System.IO.File.WriteAllText($"{componentFolderPath}{name}.cs", sb.ToString());
                }
                #endregion
                #region 属性字段自动匹配
                {
                    sb.Clear();
                    sb.AppendLine($"using System.Linq;");
                    sb.AppendLine($"using System.Collections.Generic;");
                    sb.AppendLine();
                    sb.AppendLine("namespace ETModel");
                    sb.AppendLine("{");
                    sb.AppendLine("\t[ObjectSystem]");
                    sb.AppendLine($"\tpublic class {name}AwakeSystem : AwakeSystem<{name}>");
                    sb.AppendLine("\t{");
                    sb.AppendLine($"\t\tpublic override void Awake({name} self)");
                    sb.AppendLine("\t\t{");
                    sb.AppendLine("\t\t\tself.Awake();");
                    sb.AppendLine("\t\t}");
                    sb.AppendLine("\t}");

                    sb.AppendLine($"\tpublic partial class {name} : UIPanelComponent");
                    sb.AppendLine("\t{");

                     Dictionary<string, string> data = new Dictionary<string, string>();
                    foreach (var item in transform.GetComponent<ReferenceCollector>().data)
                    {
                         var components = (item.gameObject as GameObject).GetComponents<UnityEngine.Component>();
                        string fieldType = components[0].GetType().ToString();
                        if (components.Length > 2)
                        {
                            fieldType = components[components.Length - 1].GetType().ToString();
                         }
                        if (components.Length == 2)
                        {
                             if (components[0] is RectTransform && components[1] is CanvasRenderer)
                            {
                                fieldType = components[0].GetType().ToString();
                            }
                         }

                         data.Add(item.key, fieldType);

                        sb.AppendLine($"\t\tprivate {fieldType} {item.key};");

                        sb.AppendLine();
                    }

                    sb.AppendLine($"\t\tpublic void Awake()");
                    sb.AppendLine("\t\t{");

                    sb.AppendLine("\t\t\tvar go = GetParent<UI>().GameObject;");
                    sb.AppendLine();

                    //赋值字段
                    foreach (var kv in data)
                    {
                        sb.AppendLine($"\t\t\t{kv.Key}=Collector.GetMonoComponent<{kv.Value}>(\"{kv.Key}\");");
                        sb.AppendLine();
                    }

                    sb.AppendLine($"\t\t\tthis.RegisterEvent();");

                    sb.AppendLine("\t\t}");
                    sb.AppendLine("\t}");

                    sb.AppendLine("}");

                    System.IO.DirectoryInfo directoryInfo = new System.IO.DirectoryInfo("./Library/UIWindow/");
                    if (!directoryInfo.Exists)
                    {
                        directoryInfo.Create();
                    }
                    if (System.IO.File.Exists($"{componentFolderPath}{name}_Generated.cs"))
                    {
                        //System.IO.File.Copy($"{componentFolderPath}{name}_Generated.cs", $"{directoryInfo.FullName}{name}_Generated.cs");
                    }

                    System.IO.File.WriteAllText($"{componentFolderPath}{name}_Generated.cs", sb.ToString());
                }
                #endregion
                EditorUtility.DisplayDialog("提示", "生成成功", "确定");
            }
            else
            {
                EditorUtility.DisplayDialog("警告", "当前无选中对象或者选中对象不符合规则\n生成失败", "确定");
            }

            AssetDatabase.Refresh();
        }
     }
}