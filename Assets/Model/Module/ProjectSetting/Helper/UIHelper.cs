using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ETModel
{
    public class UIHelper 
    {
        public  static Dictionary<string, UIPanelComponent> UIPanelDic = new Dictionary<string, UIPanelComponent>();

        public static T GetUI<T>(string uiName) where T :Component,new()
        {
             T ui=  Game.Scene.GetComponent<UIComponent>().Get(uiName.StringToAsset())?.GetComponent<T>();
              return ui;
        }

        public static void HideAllUI()
        {
            foreach (var item in UIPanelDic)
            {
                item.Value.Hide();
            }
        }

        public static void DestroyUI(string UIName)
        {
            UI ui=   Game.Scene.GetComponent<UIComponent>().Get(UIName);
            if (ui != null)
            {
                 ui.Dispose();
            }
        }
     }
}