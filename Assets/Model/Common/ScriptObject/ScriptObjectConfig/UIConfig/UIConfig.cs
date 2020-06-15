using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ETModel
{
    public enum HierarchyType
    { 
        TopMost,
        Top,
        Medium,
        Bottom,
        Hidden
    }
    public class UIConfig : BaseConfig
    {
        [Sirenix.OdinInspector.TableColumnWidth(60)]
        public string Name;
        public string Description;
        public HierarchyType Hierarchy;
    }
}