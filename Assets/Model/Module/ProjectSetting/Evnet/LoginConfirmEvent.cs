 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ETModel
{
    [Event(EventIdType.LoginConfirmEvent)]
    public class LoginConfirmEvent : AEvent<string, string>
    {
        public override void Run(string name, string passWord)
        {
            // Debug.Log(name+","+passWord);
            //if (name == "" || passWord == "")
            //{
            //    UIHelper.GetUI<UILoginWindowComponent>(UIType.UILoginPanel).ShowErrorInfo(LoginErrorInfo.PassWordError);
            //    return;
            //}
         }
    }
}