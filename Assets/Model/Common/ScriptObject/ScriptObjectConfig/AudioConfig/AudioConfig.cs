using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ETModel
{
    public class AudioConfig : BaseConfig
    {
        [Sirenix.OdinInspector.TableColumnWidth(60)]
        public string Name;
        public AudioClip Sorce;
     }
}