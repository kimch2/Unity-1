using System;
using System.Linq.Expressions;
using System.Threading;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;

namespace ETModel
{
    public class Init : MonoBehaviour
    {

        public static string LoadExeName;

        void Awake()
        {
            SynchronizationContext.SetSynchronizationContext(OneThreadSynchronizationContext.Instance);
            Game.EventSystem.Add(DLLType.Model, typeof(Init).Assembly);
          }
   
        public async ETVoid StartAsync()
        {
            try
            {
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