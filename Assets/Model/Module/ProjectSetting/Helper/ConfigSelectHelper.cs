using ETModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

public static class ConfigHelper 
{
    public static List<string> GetListByProporty<T>(string proporty) where T: IConfig
    {
        var alldata=  Game.Scene.GetComponent<AddressableConfigComponent>().GetAll<T>();
        List<string> result = new List<string>();
 
        FieldInfo info = typeof(T).GetField(proporty);
 
        foreach (var item in alldata)
        {
           string value=  info.GetValue(item) as string;
 
            if (!result.Contains(value))
            {
                result.Add(value);
            }
        }
        return result;
    }
    public static List<string> GetListByProporty<T>(List<T> list,string proporty) where T : IConfig
    {
         List<string> result = new List<string>();

        FieldInfo info = typeof(T).GetField(proporty);

        foreach (var item in list)
        {
            string value = info.GetValue(item) as string;

            if (!result.Contains(value))
            {
                result.Add(value);
            }
        }
        return result;
    }

    public static T[] GetItemList<T>() where T:IConfig
    {
        var alldata = Game.Scene.GetComponent<AddressableConfigComponent>().GetAll<T>();
        return alldata;
    }

    public static List<T> RemoveRepeat<T>(this List<T> list)
    {
        if (list.Count == 0)
        {
            return list;
        }
        List<T> result = new List<T>();
        foreach (var item in list)
        {
            if (!result.Contains(item))
            {
                result.Add(item);
            }
        }
        return result;
    }


    public static void SetSpriteByLoadAsset(Image image,string assetName)
    {
         Addressables.LoadAssetAsync<Sprite>(assetName).Completed += (result) => { image.sprite = result.Result; };
    }




}
