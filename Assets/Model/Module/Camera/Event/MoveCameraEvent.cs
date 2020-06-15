using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ETModel
{
    [Event(EventIdType.MoveCameraEvent)]
    public class MoveCameraEvent : AEvent<Camera, string>
    {
        public override void Run(Camera camera, string id)
        {
            var config = Game.Scene.GetComponent<FreeLookCameraComponent>().GetViewDataByID(id);
 
            if (config != null)
            {
                 Game.Scene.GetComponent<FreeLookCameraComponent>().MoveToTarget(camera, config);
            }
        }

        public override async ETTask RunAsync(Camera camera, string id)
        {
            var config = Game.Scene.GetComponent<FreeLookCameraComponent>().GetViewDataByID(id);
            if (config != null)
            {
                 await Game.Scene.GetComponent<FreeLookCameraComponent>().MoveToTarget(camera, config);
            }
        }

        [Event(EventIdType.MoveCameraEventByID)]
        public class MoveCameraEventByID : AEvent<string>
        {
            public override void Run(string id)
            {
                 var config = Game.Scene.GetComponent<FreeLookCameraComponent>().GetViewDataByID(id);
                 if (config != null)
                {
                     Game.Scene.GetComponent<FreeLookCameraComponent>().MoveToTarget(config);
                }
            }
        }
    }
 }
