using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace ETModel
{
    /// <summary>
    /// 游戏的开始事件
    /// </summary>
    [Event(EventIdType.GameStartEvent)]
    public class GameStartEvent : AEvent
    {
        public async override void Run()
        {
         }
    }
}
