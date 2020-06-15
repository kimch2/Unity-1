using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ETModel
{
    public class BaseConfig : IConfig
    {
        [Sirenix.OdinInspector.TableColumnWidth(20)]
        [Sirenix.OdinInspector.ShowInInspector]
         public long Id
        {
            get;
            set;
        }
    }
}
