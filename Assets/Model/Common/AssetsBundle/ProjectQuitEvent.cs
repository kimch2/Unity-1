using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ETModel
{
    [Event(EventIdType.ProjectQuitEvent)]
    public class ProjectQuitEvent : AEvent
    {
        public override void Run()
        {
            Game.Init();
            Game.EventSystem.RemoveHotFixEvent();
            //GameObject.FindObjectOfType<Init>().LoadHotFix("Platform");
        }
    }
}