using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ETModel {
    [Event(EventIdType.CancelDisplayEvent)]
    public class CancelDisplayEvent : AEvent
    {
        public override async void Run()
        {
             Game.Scene.GetComponent<DisplayComponent>().QuitDisPlay();
            Game.Scene.GetComponent<FreeLookCameraComponent>().IsChangingTarget = false;
        }
    }
}
