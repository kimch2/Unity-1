using System.Collections.Generic;
using UnityEngine.AddressableAssets;

namespace ETModel
{
    [ObjectSystem]
    public class MainCameraComponentAwakeSystem : AwakeSystem<MainCameraComponent>
    {
        public override void Awake(MainCameraComponent self)
        {
            self.Awake();
        }
    }

    public class MainCameraComponent : Entity
    {
        public UnityEngine.Camera Camera { get; private set; }

        public async void Awake()
        {
            var handle= Addressables.LoadAssetAsync<UnityEngine.GameObject>("Main Camera");
            await handle.Task;
            var go = UnityEngine.GameObject.Instantiate(handle.Result);
            this.Camera = go.GetComponent<UnityEngine.Camera>();
            this.Camera.transform.SetParent(this.GameObject.transform, false);
            //this.Camera.depth = 11;
            //this.Camera.nearClipPlane = 0.01f;
            ////移除UI层
            //this.Camera.cullingMask &= ~(1 << 5);
            ////移除Hidden显示层
            //this.Camera.cullingMask &= ~(1 << 9);

            //添加音频监听组件
            AddComponent<AudioListenerComponent>();
            //添加物理射线碰撞组件
            AddComponent<PhysicsRaycasterComponent>();
            //添加HighlightingSystem组件
            //AddComponent<HighlightingComponent, string>("Default");
         }
    }
}