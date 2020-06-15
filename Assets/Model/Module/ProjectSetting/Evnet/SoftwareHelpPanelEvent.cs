using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ETModel
{
     public class SoftwareHelpPanelEvent : AEvent<string>
    {
        public override void Run(string mode)
        {
            Debug.Log(mode);
        }
    }
}