using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ResourcesLoadHelper
{
    /// <summary>
    /// 通过路径加载图片
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static Sprite LoadSprite(string path)
    {
        FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
        fs.Seek(0, SeekOrigin.Begin);
        byte[] bytes = new byte[fs.Length];
        fs.Read(bytes, 0, (int)fs.Length);
        fs.Close();
        fs.Dispose();
        fs = null;
        Texture2D t = new Texture2D(1, 1);
        t.LoadImage(bytes);
        var sp= Sprite.Create(t,new Rect(Vector2.zero,new Vector2(t.width, t.height)),new Vector2(0.5f,0.5f));
        return sp;
    }

 
    public static List<Sprite> LoadAllSprite(string path)
    {
        List<Sprite> spList = new List<Sprite>();
        string[] files = Directory.GetFiles(path);
        foreach (var item in files)
        {
            FileStream fs = new FileStream(item, FileMode.Open, FileAccess.Read);
            fs.Seek(0, SeekOrigin.Begin);
            byte[] bytes = new byte[fs.Length];
            fs.Read(bytes, 0, (int)fs.Length);
            fs.Close();
            fs.Dispose();
            fs = null;
            Texture2D t = new Texture2D(1, 1);
            t.LoadImage(bytes);
            var sp = Sprite.Create(t, new Rect(Vector2.zero, new Vector2(t.width, t.height)), new Vector2(0.5f, 0.5f));
            spList.Add(sp);
        }
         return spList;
    }

    public static Dictionary<string, Sprite> LoadAllSpriteWithName(string path)
    {
        Dictionary<string, Sprite> spList = new Dictionary<string, Sprite>();
        string[] files = Directory.GetFiles(path);
  
        foreach (var item in files)
        {
            if (item.EndsWith(".meta"))
                continue;
            FileStream fs = new FileStream(item, FileMode.Open, FileAccess.Read);
            fs.Seek(0, SeekOrigin.Begin);
            byte[] bytes = new byte[fs.Length];
            fs.Read(bytes, 0, (int)fs.Length);
            fs.Close();
            fs.Dispose();
            fs = null;
            Texture2D t = new Texture2D(1, 1);
            t.LoadImage(bytes);
            var sp = Sprite.Create(t, new Rect(Vector2.zero, new Vector2(t.width, t.height)), new Vector2(0.5f, 0.5f));
            spList.Add(item.Split('\\')[1].Split('.')[0], sp);
        }
        return spList;
    }
}