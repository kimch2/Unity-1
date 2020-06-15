using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ETModel {
    public partial class EventIdType
    {
        /// <summary>
        /// 相机事件
        /// </summary>
        public const string MoveCameraEvent = "MoveCameraEvent";
        public const string DisplayTargetEvent = "DisplayTargetEvent";
        public const string CancelDisplayEvent = "CancelDisplayEvent";
        public const string MoveCameraEventByID = "MoveCameraEventByID";


        /// <summary>
        /// 确认登陆事件
        /// </summary>
        public const string LoginConfirmEvent = "LoginConfirmEvent";

        /// <summary>
        /// UI返回事件
        /// </summary>
        public const string UIReturnEvent = "UIReturnEvent";
 
        /// <summary>
        /// 设置界面
        /// </summary>
        public const string SettingPanelEvent = "SettingPanelEvent";

  
        /// <summary>
        /// 登出事件
        /// </summary>
        public const string LogOutEvent = "LogOutEvent";


        /// <summary>
        /// 退出事件
        /// </summary>
        public const string QuitEvent = "QuitEvent";

         public const string GameInitEvent = "GameInitEvent";

        public const string GameStartEvent = "GameStartEvent";

        public const string MainSceneStartEvent = "MainSceneStartEvent";
     }
}