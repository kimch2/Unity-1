using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ETModel
{
    public enum GloablConfigType
    {
        DataBaseAddress,
     
    }

    public class GlobalConfig : BaseConfig
    {
        public GloablConfigType Type;
        public string Value;
    }
 }