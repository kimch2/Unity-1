using System.Linq;

namespace ETModel
{
    [ObjectSystem]
    public class UnityGameObjectAwakeSystem : AwakeSystem<UnityGameObject, UnityEngine.GameObject>
    {
        public override void Awake(UnityGameObject self, UnityEngine.GameObject gameObject)
        {
            self.Awake(gameObject);
        }
    }

    public class UnityGameObject : Entity
    {
        public string Path => Value.GetHierarchyPath();
        public string Key => Value?.name ?? string.Empty;
        public UnityEngine.GameObject Value { get; set; }

        public void Awake(UnityEngine.GameObject gameObject)
        {
            Value = gameObject;
        }

        public void SetState(bool state)
        {
            if (Value != null && Value.activeInHierarchy != state)
            {
                Value.SetActive(state);
            }
        }

        public override void Dispose()
        {
            base.Dispose();
            Value = null;
        }

        public static bool IsChildOf(UnityGameObject a, UnityGameObject b)
        {
            if (a == null || b == null || a.Value == null || b.Value == null || a.Value == b.Value)
            {
                return false;
            }

            return a.Value.transform.IsChildOf(b.Value.transform);
        }

        public static bool IsChildOfAny(UnityGameObject a, UnityGameObject[] targets)
        {
            return targets != null && targets.Length > 0 && targets.Any(b => IsChildOf(a, b));
        }
    }
}