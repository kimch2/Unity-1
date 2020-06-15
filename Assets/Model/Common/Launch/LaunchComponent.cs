using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine.UI;

namespace ETModel
{
    [ObjectSystem]
    public class LaunchComponentAwakeSystem : AwakeSystem<LaunchComponent>
    {
        public override void Awake(LaunchComponent self)
        {
            self.Awake();
        }
    }

    public class LaunchComponent : Component
    {
         private UnityEngine.GameObject instance;
 
        public  void Awake()
        {
            this.instance = UnityEngine.GameObject.Find("LaunchWindow");
         }

        public void Show()
        {
            instance?.gameObject.SetActive(true);
        }

        public   void Hide()
        {
            instance?.SetActive(false);
         }

    }
}