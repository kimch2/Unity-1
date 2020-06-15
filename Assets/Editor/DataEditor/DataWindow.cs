#if UNITY_EDITOR
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEditor;
using UnityEngine;
namespace ETModel
{
    public class DataWindow : OdinMenuEditorWindow
    {
        public List<string> OperateName = new List<string>();
        public Dictionary<string,List< KeyValuePair<string,string>>> NameDic = new Dictionary<string, List<KeyValuePair<string, string>>>();

        private static readonly string ScriptObjectConfig = "Assets/Model/Common/ScriptObject/ScriptObjectConfig";
        private static readonly string ScriptObjectData = "Assets/Model/Common/ScriptObject/ScriptObjectData";
        private static readonly string ScriptObjectCreator = "Assets/Model/Common/ScriptObject/ScriptObjectCreator";
        private static readonly string ComponentPath = "Assets/Model/Common/ScriptObject/ComponentManager";
        private static readonly string ComponentInfoPath = "Assets/Model/Common/ScriptObject/ComponentInfo";
         protected override OdinMenuTree BuildMenuTree()
        {
            OdinMenuTree tree = new OdinMenuTree(supportsMultiSelect: true)
            {
            };
             tree.AddAllAssetsAtPath("配置表", ScriptObjectConfig, typeof(ScriptObjectConfig), true, true)
               .AddThumbnailIcons();

            tree.AddAllAssetsAtPath("数据创建器", ScriptObjectCreator, typeof(DataCreator), true, true)
               .AddThumbnailIcons();

            tree.AddAllAssetsAtPath("数据", ScriptObjectData, typeof(CharacterBaseData), true, true)
           .AddThumbnailIcons();

             tree.AddAllAssetsAtPath("组件", ComponentPath, typeof(ComponentManager), true, true)
       .AddThumbnailIcons();
            tree.AddAllAssetsAtPath("组件列表", ComponentInfoPath, typeof(ComponentInfo), true, true)
 .AddThumbnailIcons();
            return tree;
        }

 
    }
}
#endif
