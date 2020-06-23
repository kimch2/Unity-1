using ETModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ETHotfix
{
    [Event(EventIdType.InitSceneStart)]
    public class InitSceneStart : AEvent
    {
        public override void Run()
        {
            GameObject go = new GameObject();
            go.name = "HotFixTest";

            UnityEngine.Debug.LogError( $"{Application.productName}  热更新测试成功");
         }
    }
}