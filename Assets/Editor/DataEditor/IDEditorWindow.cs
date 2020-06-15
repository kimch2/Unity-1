using UnityEngine;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;
using Sirenix.Utilities;
using UnityEditor;
using System.Xml.Linq;
using System.Xml;
 
using System.Collections.Generic;
using ETModel;

public class IDEditor : OdinEditorWindow
{
    public TextAsset Config;

    public GameObject Target;
    public GameObject Car;

    public string TargetElement;
    public string TargetAttribute = "Name";

    public string ResultAttribute = "ID";

    public string Title;

    [Button("赋值")]
    public async void CheckMaterialMissing()
    {

 
     }

    ////[Button("赋值")]
    ////public void CheckMaterialMissing()
    ////{
    ////    if (Target != null)
    ////    {
    ////        MeshRenderer[] meshRenderers = Target.GetComponentsInChildren<MeshRenderer>();

    ////        foreach (var item in meshRenderers)
    ////        {
    ////            if (item.gameObject.name == "Beam Geometry")
    ////                continue;
    ////            if (item.GetComponent<LiquidVolumeFX.LiquidVolume>() != null)
    ////                continue;

    ////            MeshRenderer[] meshRenderers2 = Car.GetComponentsInChildren<MeshRenderer>();

    ////            foreach (var carmesh in meshRenderers2)
    ////            {
    ////                if (carmesh.gameObject.name == item.gameObject.name)
    ////                {
    ////                    carmesh.sharedMaterials = item.sharedMaterials;
    ////                }
    ////            }
    ////        }
    ////    }
    ////}

    //[MenuItem("Data/IDHelper")]
    //private static void OpenWindow()
    //{
    //    var window = GetWindow<IDEditor>();

    //    // Nifty little trick to quickly position the window in the middle of the editor.
    //    window.position = GUIHelper.GetEditorWindowRect().AlignCenter(700, 700);
    //}

    //[Button("生成ID")]
    //public void Create()
    //{
    //    if (Config != null)
    //    {
    //        var list = XmlConfigHelper.LoadXmlLinq(Config, out XDocument doc, false,TargetElement);
    //        int index = 0;
    //        Dictionary<string, string> PartIDList = new Dictionary<string, string>();
    //        foreach (var item in list)
    //        {
    //            string target =  item.Attribute(TargetAttribute).Value;
    //            if (!PartIDList.ContainsKey(target))
    //            {
    //                index++;
    //                PartIDList.Add(target, Title + "_" + index);
    //            }
    //             item.Attribute(ResultAttribute).SetValue(PartIDList[target]);
    //        }
    //         doc.Save(AssetDatabase.GetAssetPath(Config));
    //    }
    //    Debug.Log("完成ID替换");
    //}

    //[Button("生成PartID")]
    //public void CreatePartID()
    //{
    //    if (Config != null)
    //    {
    //        var list = XmlConfigHelper.LoadXmlLinq(Config, out XDocument doc, false, "Step");
    //        int index = 0;
    //        Dictionary<string, string> PartIDList = new Dictionary<string, string>();
    //        foreach (var item in list)
    //        {
    //            string target = item.Attribute("TargetID").Value;
    //            if (!PartIDList.ContainsKey(target))
    //            {
    //                PartIDList.Add(target, "Part_" + index);
    //                index++;
    //            }
    //            item.Attribute("PartID").SetValue(PartIDList[target]);
    //        }
    //        doc.Save(AssetDatabase.GetAssetPath(Config));
    //    }
    //    Debug.Log("完成ID替换");
    //}
}
