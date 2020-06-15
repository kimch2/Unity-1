using IL;
using wxb;
using UnityEngine;
using System.Collections.Generic;
#pragma warning disable 169
#pragma warning disable 649

namespace hot
{
    // AutoInitAndRelease，热更模块初始化后会自动调用Init,在卸载热更模块时会调用Release
    [AutoInitAndRelease]
    // Platform属性可以只在特定平台下才会生效，默认不加是全平台生效
    //[wxb.Platform("Android")]
    // 默认替换HeloWorld类下的方法
    [ReplaceType(typeof(Player))]
    public static class HotPlayer
    {
        static Hotfix update;

        [ReplaceFunction()]
        static void Update(Player player)
        {
             if (Input.GetMouseButton(0))
            {
                 player.GetComponent<MeshRenderer>().material.color = Color.blue;
                player.transform.position += new Vector3(Input.GetAxis("Mouse X")*0.1F,Input.GetAxis("Mouse Y")*0.1F,0);
            }
            if (Input.GetMouseButtonUp(0) )
            {
                 player.GetComponent<MeshRenderer>().material.color = Color.white;
             }
          }

        public  static void Init()
        { 
           GameObject.Find("Cube").GetComponent<MeshRenderer>().material.color = Color.red;

        }


        [ReplaceFunction()]
        static void ActionW(Player player)
        {
            UnityEngine.Debug.Log(player.transform);
            player.transform.Translate(Vector3.forward);
        }

        [ReplaceFunction()]
        static void ActionS(Player player)
        {
            player.transform.Translate(Vector3.back);
         }

        [ReplaceFunction()]
        static void ActionA(Player player)
        {
            player.transform.Translate(Vector3.left);
         }

        [ReplaceFunction()]
        static void ActionD(Player player)
        {
            player.transform.Translate(Vector3.right);
         }
    }
}