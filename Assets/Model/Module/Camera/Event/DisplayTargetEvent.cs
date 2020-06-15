using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ETModel {
    [Event(EventIdType.DisplayTargetEvent)]
    public class DisplayTargetEvent : AEvent<object,float>
    {
        public override void Run(object arg, float distance)
        {
            GameObject go=null;
            switch (arg)
            {
                case String stringArg:
                     go = GameObject.Find(stringArg);
                    //go = Game.Scene.GetComponent<UnityGameObjectComponent>().FindByKey(stringArg);
                    //if (go.Value == null)
                    //{
                    //    go= Game.Scene.GetComponent<UnityGameObjectComponent>().FindByPath(stringArg);
                    //}
                    //if (go.Value == null)
                    //{
                    //    go.Value = GameObject.Find(stringArg);
                    //}
                    break;
                case Int32 intArg:
                    //go= Game.Scene.GetComponent<UnityGameObjectComponent>().FindById(intArg);
                    break;

            }
             if (go!=null)
            {
                  Game.Scene.GetComponent<FreeLookCameraComponent>().IsChangingTarget = true;
                 Game.Scene.GetComponent<DisplayComponent>().DisplayTarget(go,distance);
            }
         }
    }
}
