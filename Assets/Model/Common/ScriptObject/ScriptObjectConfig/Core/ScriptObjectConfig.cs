using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
namespace ETModel
{

    [CreateAssetMenu(menuName = "DataManager/Config/Data")]
    public class ScriptObjectConfig : Sirenix.OdinInspector.SerializedScriptableObject
    {
        [LabelText("配置表名称")]
        public string Name;
        [LabelText("描述")]
        public string Description;
        [Sirenix.OdinInspector.TableList]
        [OnValueChanged("OnItemListChanged")]
        public List<BaseConfig> ItemList;

         public void OnItemListChanged()
        {
            for (int i = 0; i < ItemList.Count; i++)
            {
                ItemList[i].Id = i + 1;
            }
        }
      }
}
