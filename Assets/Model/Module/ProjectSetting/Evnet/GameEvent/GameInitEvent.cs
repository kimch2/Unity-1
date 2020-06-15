using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
namespace ETModel
{
    /// <summary>
    /// 初始化事件
    /// </summary>
    [Event(EventIdType.GameInitEvent)]
    public class GameInitEvent : AEvent
    {
        public async  override void Run()
        {
            try
            {
 
                //await Game.Scene.AddComponent<LogComponent>().LoadAsync();
                Game.Scene.AddComponent<TimerComponent>();
                Game.Scene.AddComponent<UnityGameObjectComponent>();
                //Game.Scene.AddComponent<GlobalConfigComponent>();
                //Game.Scene.AddComponent<NetOuterComponent>();

                Game.Scene.AddComponent<InputComponent>();
                //Game.Scene.AddComponent<MainCameraComponent>();
                Game.Scene.AddComponent<UIComponent>();
                Game.Scene.AddComponent<LaunchComponent>();

 
                // 加载配置
                await Game.Scene.AddComponent<AddressableConfigComponent>().LoadAsync();

                // 加载UI
                foreach (var config in Game.Scene.GetComponent<AddressableConfigComponent>().GetAll<UIConfig>())
                {
                     var ui = await Game.Scene.GetComponent<UIComponent>().InstantiateAsync(config.Name, config.Hierarchy.ToString());
                     ui.AddComponent(System.Type.GetType($"ETModel.{config.Name}Component"));
                 }
                //Game.Scene.AddComponent<OpcodeTypeComponent>();
                //Game.Scene.AddComponent<MessageDispatcherComponent>();
 
                Game.Scene.RemoveComponent<LaunchComponent>();
                //声音组件
                Game.Scene.AddComponent<AudioComponent>();
                //数据组件
                Game.Scene.AddComponent<DisplayComponent>();
                //独显
                Game.Scene.AddComponent<FreeLookCameraComponent>();
                //高亮组件
                Game.Scene.AddComponent<HighLightingComponent>();
                //工具箱功能
                Game.EventSystem.Run(EventIdType.GameStartEvent);
            }
            catch (Exception ex)
            {
                Debug.LogError(ex.StackTrace);
            }
        }
    }
}
