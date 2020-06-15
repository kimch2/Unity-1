using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ETModel
{
    [Event(EventIdType.SettingPanelEvent)]
    public class SettingPanelEvent : AEvent<string>
    {
        public override void Run(string mode)
        {
            Debug.Log(mode);
        }
    }
}