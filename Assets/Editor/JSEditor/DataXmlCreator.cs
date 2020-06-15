using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;
using UnityEditor;
using System;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace ETModel.JSFrameWork
{

    public class ScirptObjectBaseData
    {
        public string ID;
    }

    public class DataXmlCreator : Editor
    {
        private static readonly string ScriptObjectConfig = "Assets/Model/Common/ScriptObject/ScriptObjectConfig";
         [UnityEditor.MenuItem("Data/生成ScriptObject")]
        public static  void Install()
        {
            
        }
     }
}