using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ETModel
{
    /// <summary>
    /// 启动项目
    /// </summary>
    [Event(EventIdType.OpenProjectEvent)]
    public class OpenProjectEvent:AEvent
    {
        public override void Run()
        {
             Game.EventSystem.Run(EventIdType.InitSceneStart);
        }
     }
}