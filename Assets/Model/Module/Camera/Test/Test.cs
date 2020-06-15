using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace ETModel
{
    [ObjectSystem]
    public class TestUpdateSystem : UpdateSystem<TestCompoent>
    {
        public override void Update(TestCompoent self)
        {
            self.Update();
        }
    }
    [ObjectSystem]
    public class TestAwakeSystem : AwakeSystem<TestCompoent>
    {
        public async override void Awake(TestCompoent self)
        {
             self.Awake();
        }
    }

    public class TestCompoent : Component
    {
        public void Awake()
        {
            //Game.Scene.AddComponent<UIProjectSettingComponent>().LoadProjectSettingPanel();
         }

        public void Update()
        {
            //if (Input.GetKeyDown(KeyCode.F))
            //{
            //    Game.EventSystem.Run(EventIdType.MoveCameraEvent,"Target1",Camera.main,default(Collider));
            //}
            //if (Input.GetKeyDown(KeyCode.E))
            //{
            //    Game.EventSystem.Run(EventIdType.DisplayTargetEvent, "Target1");
            //}
            //if (Input.GetKeyDown(KeyCode.C))
            //{
            //    Game.EventSystem.Run(EventIdType.CancelDisplayEvent);
            //}
 
        }
    }
}

