using System;
using System.Linq.Expressions;
using System.Threading;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
 using System.Threading.Tasks;
using System.IO;
using DG.Tweening.Plugins.Core.PathCore;
using UnityEngine.UI;
using System.Collections.Generic;

namespace ETModel
{
    public class Init : MonoBehaviour
    {

       async  void Awake()
        {
            var ip = File.ReadAllText(System.IO.Path.Combine(PathHelper.BuildPath, "Config.txt"));
            PathHelper.Init(ip);
            SynchronizationContext.SetSynchronizationContext(OneThreadSynchronizationContext.Instance);
            Game.EventSystem.Add(DLLType.Model, typeof(Init).Assembly);
            Game.Scene.AddComponent<TimerComponent>();
            Game.Scene.AddComponent<ResourcesComponent>();
            LoadHotFix("platform");
            Game.Scene.GetComponent<ResourcesComponent>().LoadBundle("platform_basescene.unity3d");
            SceneManager.LoadScene("BaseScene", LoadSceneMode.Additive);
        }
        public void LoadHotFix(string Target)
        {
            Global.LoadProjectName = Target;
            PathHelper.SetProjectPath(Target);
            Game.Scene.GetComponent<ResourcesComponent>().LoadOneBundle($"{Target}".ToLower());
            ResourcesComponent.AssetBundleManifestObject =
             (AssetBundleManifest)Game.Scene.GetComponent<ResourcesComponent>().GetAsset($"{Target}".ToLower(), "AssetBundleManifest");
            Game.Hotfix.LoadHotfixAssembly();
            Game.Hotfix.GotoHotfix();
        }

         float timeCount = 0;
        public async void LoadProject(string Target)
        {
             try
            {
                ///防止多次点击
                if (Time.time - timeCount < 1)
                {
                    timeCount = Time.time;
                    return;
                }
                timeCount = Time.time;
                Game.EventSystem.Run(EventIdType.ProjectQuitEvent);
                LoadHotFix(Target);
                await Task.Delay(100);
                Game.EventSystem.Run(EventIdType.OpenProjectEvent);
            }
            catch (Exception ex)
            {
                UnityEngine.Debug.LogError(ex.StackTrace);
            }
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
            Game.Hotfix.Update?.Invoke();
            Game.EventSystem.Update();
        }

        private void LateUpdate()
        {
            Game.Hotfix.LateUpdate?.Invoke();
            Game.EventSystem.LateUpdate();
        }

        private void OnApplicationQuit()
        {
            Game.Hotfix.OnApplicationQuit?.Invoke();
            Game.Close();
        }
    }

}