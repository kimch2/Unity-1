using ETModel;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using System.Threading;

namespace ETHotfix
{
    [Event(EventIdType.InitSceneStart)]
    public class InitSceneStart : AEvent
    {
         public override  void Run()
        {
             foreach (var item in SceneManager.GetSceneByName("Init").GetRootGameObjects())
            {
                item.SetActive(false);
            }
            var sceneBundle = $"{Global.LoadProjectName}_scene.unity3d";
            if (!Global.LoadSceneAssetsbundle.Contains(sceneBundle))
            {
                UnityEngine.Debug.Log(sceneBundle);
                 Global.LoadSceneAssetsbundle.Add(sceneBundle);
                ETModel.Game.Scene.GetComponent<ResourcesComponent>().LoadBundle(sceneBundle);
            }
 
            var handle = SceneManager.LoadSceneAsync($"{Global.LoadProjectName}_MainScene", LoadSceneMode.Additive);

            handle.completed += (x) => 
            {
                Load();
            };
          }

        public  void Load()
        {
            var btn = GameObject.Find("QuitBtn");
            GameObject.Find("MainSceneInfo").GetComponent<Text>().text = Global.LoadProjectName+ "  加载成功！";
            //GameObject.Find("MainSceneInfo").GetComponent<Text>().text = Global.Test;

            btn.GetComponent<Button>().onClick.AddListener(
                () => {
                    foreach (var item in SceneManager.GetSceneByName("Init").GetRootGameObjects())
                    {
                        item.SetActive(true);
                    }
                    SceneManager.UnloadSceneAsync($"{Global.LoadProjectName}_MainScene");
                      //ETModel.Game.Scene.GetComponent<ResourcesComponent>().UnloadBundle($"{Global.LoadProjectName}_scene.unity3d");
                     Game.Close();
                     ETModel.Game.EventSystem.Run(ETModel.EventIdType.ProjectQuitEvent);
                 }
            );
        }
    }
}