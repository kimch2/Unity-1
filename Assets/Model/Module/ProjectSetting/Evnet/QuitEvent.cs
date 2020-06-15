using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ETModel
{
    [Event(EventIdType.QuitEvent)]
    public class QuitEvent : AEvent
    {
        public override void Run()
        {
            UnityEngine.Debug.LogError("EventIdType.QuitEvent");
            //UIHelper.GetUI<UIConfirmWindowComponent>(UIType.UIConfirmPanel).ShowPanel(()=>Application.Quit(), "退出软件将丢失现有的操作，确认退出？");
         }
    }
}