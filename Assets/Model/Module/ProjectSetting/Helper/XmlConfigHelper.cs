using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
 using System;
using System.IO;
using ETModel;
using System.Xml.Linq;

public enum ConfigType
{
  
    /// <summary>
    /// 音频表
    /// </summary>
    AudioConfig,

    /// <summary>
    /// 视角
    /// </summary>
    ViewDataConfig,

    /// <summary>
    /// UI配置表
    /// </summary>
    UIConfig,
}

public class WorkSheetConfigDetail
{
    public List<string> Context = new List<string>();
    public List<string> TargetIDList = new List<string>();
    public List<string> RightSelectIDList = new List<string>();
    public string Descriptions;
    public string OperateType;
}

public class XmlData
{
    public XmlNodeList NodeList;
    public XmlDocument Xml;
}

public class XmlConfigHelper
{
     /// <summary>
    /// 加载数据
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static async ETTask<XmlData> LoadXml(ConfigType type, string rootname = "Config")
    {
 
        var xmldata = new XmlData();
        XmlReaderSettings set = new XmlReaderSettings();
        set.IgnoreComments = true;
        XmlDocument _xml = new XmlDocument();
        TextAsset text =await GetTextAssetAsync(type);
 

        XmlReader reader = XmlReader.Create(new MemoryStream(text.bytes), set);
        _xml.Load(reader);
        xmldata.NodeList= _xml.SelectSingleNode(rootname).ChildNodes;
        xmldata.Xml = _xml;
        return xmldata;
    }

    /// <summary>
    /// 加载数据
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static XmlNodeList LoadXml(TextAsset text, string rootname = "Config")
    {
        XmlReaderSettings set = new XmlReaderSettings();
        set.IgnoreComments = true;
        XmlDocument _xml = new XmlDocument();
        XmlReader reader = XmlReader.Create(new MemoryStream(text.bytes), set);
        _xml.Load(reader);
        return _xml.SelectSingleNode(rootname).ChildNodes;
    }
 

    /// <summary>
    /// 加载数据
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static XmlNodeList LoadXml(TextAsset text, out XmlDocument _xml, string rootname = "Config")
    {
        XmlReaderSettings set = new XmlReaderSettings();
        set.IgnoreComments = true;
        _xml = new XmlDocument();
         XmlReader reader = XmlReader.Create(new MemoryStream(text.bytes), set);
        _xml.Load(reader);
        return _xml.SelectSingleNode(rootname).ChildNodes;
    }

    /// <summary>
    /// 加载数据
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static async  ETTask< IEnumerable<XElement>> LoadXmlLinq(ConfigType type, string rootname = "Config")
    {
          XmlReaderSettings set = new XmlReaderSettings();
        set.IgnoreComments = true;
        TextAsset text = await GetTextAssetAsync(type);
        XmlReader reader = XmlReader.Create(new MemoryStream(text.bytes), set);
        XDocument _xml = XDocument.Load(reader);
        return _xml.Descendants(rootname);
    }

    /// <summary>
    /// 加载数据
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static IEnumerable<XElement> LoadXmlLinq(TextAsset text, out XDocument _xml, bool ignore=true, string rootname = "Config")
    {
        XmlReaderSettings set = new XmlReaderSettings();
        set.IgnoreComments = ignore;
        XmlReader reader = XmlReader.Create(new MemoryStream(text.bytes), set);
        _xml = XDocument.Load(reader);
        return _xml.Descendants(rootname);
    }

    private static async ETTask<TextAsset> GetTextAssetAsync(ConfigType type)
    {
          if (!Application.isPlaying)
        {
            var result =  File.ReadAllText($"Assets/Res/Config/OperateConfig/{type.ToString()}.xml");
            TextAsset text = new TextAsset(result);
             return text;
         }
        else
        {
            try
            {
                var result = UnityEngine.AddressableAssets.Addressables.LoadAssetAsync<GameObject>("Config");
                await result.Task;
                TextAsset configStr = result.Result.Get<TextAsset>(type.ToString());
                return configStr;
            }
            catch (Exception ex)
            {
                Debug.LogError(ex.StackTrace);
            }
        }
        return new TextAsset();
     }

}




