using UnityEngine.EventSystems;

namespace ETModel
{
    [ObjectSystem]
    public class PhysicsRaycasterComponentAwakeSystem : AwakeSystem<PhysicsRaycasterComponent>
    {
        public override void Awake(PhysicsRaycasterComponent self)
        {
            self.Awake();
        }
    }

    [HideInHierarchy]
    public class PhysicsRaycasterComponent : Component
    {
        public PhysicsRaycaster PhysicsRaycaster { get; private set; }

        public void Awake()
        {
            this.PhysicsRaycaster = GetParent<MainCameraComponent>().Camera.gameObject.AddComponent<PhysicsRaycaster>();
            //this.PhysicsRaycaster.eventMask = 1 << LayerNames.GetLayerInt(LayerNames.COLLIDER);
        }
    }
}