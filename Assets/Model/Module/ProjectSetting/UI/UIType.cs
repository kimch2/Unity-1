using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ETModel
{
    public static partial  class UIType 
    {
        public static string StringToAsset(this string value)
        {
            string[] temp = value.Split('/');
            return temp[temp.Length - 1];
        }

        /// <summary>
        /// 启动界面
        /// </summary>
        public const string UIStartPanel = "UIStartPanel/UIStartWindow";
        /// <summary>
        /// 背景
        /// </summary>
        public const string UIBackGround = "UIStartPanel/UIBackGroundWindow";

        /// <summary>
        /// 任务选择
        /// </summary>
        public const string UIMissionPanel = "UIMissionPanel/UIMissionWindow";

        /// <summary>
        /// 登陆
        /// </summary>
        public const string UILoginPanel = "UILoginPanel/UILoginWindow";

        /// <summary>
        /// 加载
        /// </summary>
        public const string UILoadingPanel = "UILoadingPanel/UILoadingWindow";

        /// <summary>
        /// 模式选择
        /// </summary>
        public const string UIModeSelectPanel = "UIModeSelectPanel/UIModeSelectWindow";


        /// <summary>
        /// 功能设置界面
        /// </summary>
        public const string UIActionBarPanel = "UIActionBarPanel/UIActionBarWindow";

        /// <summary>
        /// 反馈界面
        /// </summary>
        public const string UIFeedBackPanel = "UIActionBarPanel/UIFeedBackWindow";

        /// <summary>
        /// 设置界面
        /// </summary>
        public const string UISettingPanel = "UIActionBarPanel/UISettingWindow";
        /// <summary>
        /// 关于我们
        /// </summary>
        public const string UIAboutUsPanel = "UIActionBarPanel/UIAboutUsWindow";
        /// <summary>
        /// 软件帮助
        /// </summary>
        public const string UISoftwareHelpPanel = "UIActionBarPanel/UISoftwareHelpWindow";



        /// <summary>
        /// 弹窗界面
        /// </summary>
        public const string UIConfirmPanel = "UIConfirmPanel/UIConfirmWindow";



        /// <summary>
        /// 主界面
        /// </summary>
        public const string MainScene = "MainScene";



        /// <summary>
        /// 故障选择界面
        /// </summary>
        public const string UITroubleSetWindow = "UITroubleSetWindow/UITroubleSetWindow";

        /// <summary>
        /// 装备选择界面
        /// </summary>
        public const string UIEquipSelectWindow= "UIEquipSelectWindow";

        /// <summary>
        /// 装备选择界面
        /// </summary>
        public const string UISortPartWindow = "UISortPartWindow";

    }
}
