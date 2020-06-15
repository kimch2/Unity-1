using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UIItemCreatorEditor
{
    [MenuItem("GameObject/UIAdditional/UIButton")]
    private static void CreateButton()
    {
        CreateUI("Assets/Res/Prefab/UI/Button.prefab");
    }


    [MenuItem("GameObject/UIAdditional/UIToggle")]
    private static void CreateToggle()
    {
        CreateUI("Assets/Res/Prefab/UI/Toggle.prefab");
     }

    [MenuItem("GameObject/UIAdditional/Text")]
    private static void CreateText()
    {
        CreateUI("Assets/Res/Prefab/UI/Text.prefab");
    }


    private static void CreateUI(string path)
    {
        if (Selection.transforms.Length == 0)
        {
            GameObject go = GameObject.Instantiate(AssetDatabase.LoadAssetAtPath(path, typeof(GameObject))as GameObject);
            go.name= go.name.Replace("(Clone)", "");
        }
        foreach (var item in Selection.transforms)
        {
            GameObject button = GameObject.Instantiate(AssetDatabase.LoadAssetAtPath(path, typeof(GameObject)) as GameObject);
            button.name=button.name.Replace("(Clone)", "");
            button.transform.SetParent(item.transform, false);
        }
    }
}
