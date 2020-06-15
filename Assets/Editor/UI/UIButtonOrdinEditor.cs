using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UI;

[CustomEditor(typeof(UIButtonOrdin))]
public class UIButtonOrdinEditor : Sirenix.OdinInspector.Editor.OdinEditor
{
    public void Awake()
    {
        //var button = target as UIButtonOrdin;
        //if (!button.Tansition.ContainsKey(ButtonState.Press))
        //{
        //     var imagechange = new CmpositionItem();
        //    imagechange.TargetList.Add(button.GetComponentInChildren<Image>());
        //    imagechange.Color1 = new Color(0.9f, 0.9f, 0.9f, 1);
        //    button.Tansition.Add(ButtonState.Press, new List<UIChangeItemBase>() { imagechange }); ;
        //}
        //if (!button.Tansition.ContainsKey(ButtonState.HighLight))
        //{
        //    var imagechange = new CmpositionItem();
        //    imagechange.TargetList.Add(button.GetComponentInChildren<Image>());
        //    imagechange.Color1 = new Color(0.8f, 0.8f, 0.8f, 1);
        //    button.Tansition.Add(ButtonState.HighLight, new List<UIChangeItemBase>() { imagechange }); ;
        //}
      }
}
