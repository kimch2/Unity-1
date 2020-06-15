using System;
using System.Linq.Expressions;
using System.Threading;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using wxb;

namespace ETModel
{
    public class Init : MonoBehaviour
    {
        void Awake()
        {
            SynchronizationContext.SetSynchronizationContext(OneThreadSynchronizationContext.Instance);
            Game.EventSystem.Add(DLLType.Model, typeof(Init).Assembly);
        }

        public async ETVoid StartAsync()
        {
            try
            {
                 await hotMgr.Init();
                 Game.EventSystem.Run(EventIdType.GameInitEvent);
             }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
  
         private void Update()
        {
            OneThreadSynchronizationContext.Instance.Update();
            Game.EventSystem.Update();
         }
 
         private void LateUpdate()
        {
             Game.EventSystem.LateUpdate();
        }

        private void OnApplicationQuit()
        {
             Game.Close();
        }
    }

}