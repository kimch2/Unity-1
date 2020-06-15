using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using System.Xml;

namespace ETModel
{
    [Event(EventIdType.MainSceneStartEvent)]
    public class MainSceneStartEvent : AEvent<string,List<string>>
    {
        private GameObject _lastProject;

 
        public override async void Run(string project,List<string>troublePoint)
        {
            try
            {
              }
            catch (System.Exception ex)
            {
                Debug.Log(ex.StackTrace);
            }
        }
 


        /// <summary>
        /// 释放不用的UI
        /// </summary>
        private void DisposeUI()
        {
          }
    }
}