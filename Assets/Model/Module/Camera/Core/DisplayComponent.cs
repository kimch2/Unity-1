using UnityEngine;
using DG.Tweening;
namespace ETModel
{
    [ObjectSystem]
    public class DisplayUpdateComponent : UpdateSystem<DisplayComponent>
    {
        public override void Update(DisplayComponent self)
        {
            self.Update();
        }
    }

    [ObjectSystem]
    public class DisplayAwakeComponent : AwakeSystem<DisplayComponent>
    {
        public override void Awake(DisplayComponent self)
        {
            self.Awake();
        }
    }

    public class DisplayComponent : Component
    {
        #region parameter
        public GameObject Target;
        private float NewX, NewY, NewZ;
        private Vector2 NewPos;
        private float MaxScale;
        private float MinScale;
        #endregion
        public Camera DisplayCamera;
        public void Awake()
        {
            var go = new GameObject("[DisplayCamera]");
            go.transform.SetParent(GameObject.transform);
            DisplayCamera = go.AddComponent<Camera>();
            go.transform.localPosition = Vector3.zero;
            DisplayCamera.clearFlags = CameraClearFlags.Depth;
            DisplayCamera.nearClipPlane = 0.03f;
            DisplayCamera.depth = 10;
            DisplayCamera.cullingMask = 1 << LayerMask.NameToLayer(LayerNames.DISPLAY);
            var raycast= DisplayCamera.gameObject.AddComponent<UnityEngine.EventSystems.PhysicsRaycaster>();
            raycast.eventMask = 1 << LayerMask.NameToLayer(LayerNames.DISPLAY);
        }
        public void SetTarget(GameObject target)
        {
            Target = target;
            MaxScale = target.transform.localScale.x * 3;
            MinScale = target.transform.localScale.x * 0.5f;
            var x = -45 - Target.transform.eulerAngles.x;
            var y = 45 - Target.transform.eulerAngles.y;
            var z = 0 - Target.transform.eulerAngles.z;
            Target.transform.Rotate(new Vector3(x, 0, 0), Space.World);
            Target.transform.Rotate(new Vector3(0, y, z), Space.Self);
        }
        public void Update()
        {
            if (Target == null)
                return;
            if (Input.touchCount > 0)
            {
                TouchOperate();
            }
            else
            {
                MouseOperate();
            }
            UpdateTargetState();
        }
        public void QuitDisPlay()
        {
            if (Target != null)
            {
                var tween = Target.transform.DOScale(Vector3.zero,0.3f).SetEase(Ease.InOutQuad);
                tween.onComplete += () => { GameObject.DestroyImmediate(Target); };
            }
        }
        public void DisplayTarget(GameObject gameObject,float distance)
        {
            GameObject.DestroyImmediate(Target); 
            var go = GameObject.Instantiate(gameObject);
            go.transform.SetParent(GameObject.transform);
            SetTarget(go);
            float maxSize = 0;
            if (distance == 0)
            {
                maxSize = 1;
                  //maxSize = GetMaxSize(gameObject);
                //maxSize = Mathf.Sqrt(maxSize) * 0.2f;
            }
            else
            {
                maxSize = distance;
             }
            go.transform.localPosition = Vector3.forward * maxSize;
            foreach (var item in go.GetComponentsInChildren<Transform>())
            {
                item.gameObject.layer = LayerMask.NameToLayer("Display");
             }
            var initscale = go.transform.localScale;
            go.transform.localEulerAngles = new Vector3(10,-120,0);
            if (go.name == "ZOBZC(Clone)"||go.name== "WYBZC(Clone)")
            {
                go.transform.localEulerAngles = new Vector3(90, -90, 90);
            }
            go.transform.localScale = Vector3.zero;
            go.transform.DOScale(initscale, 0.5f).SetEase(Ease.InOutQuad);
         }

        #region 旋转位移缩放
        private void UpdateTargetState()
        {
            NewX = Mathf.Lerp(NewX, 0, Time.deltaTime * 10);
            NewY = Mathf.Lerp(NewY, 0, Time.deltaTime * 10);
            NewZ = Mathf.Lerp(NewZ, 0, Time.deltaTime * 10);
            NewPos = Vector2.Lerp(NewPos, Vector2.zero, Time.deltaTime * 30);
 
            Target.transform.Rotate(new Vector3(NewX, 0, 0), Space.World);
            Target.transform.Rotate(new Vector3(0, NewY, 0), Space.Self);

            //Target.transform.eulerAngles = new Vector3(Mathf.Clamp(Target.transform.eulerAngles.x, -90, 90), Target.transform.eulerAngles.y, Target.transform.localEulerAngles.z);
            Vector3 pos = Target.transform.position + new Vector3(NewPos.x, NewPos.y, 0);
            if (DisplayCamera.WorldToViewportPoint(pos).x < 0 || DisplayCamera.WorldToViewportPoint(pos).x > 1)
            {
                NewPos.x = 0;
            }
            if (DisplayCamera.WorldToViewportPoint(pos).y < 0 || DisplayCamera.WorldToViewportPoint(pos).y > 1)
            {
                NewPos.y = 0;
            }


            Target.transform.position += new Vector3(NewPos.x, NewPos.y, 0);

            if (Target.transform.localScale.x + NewZ > MaxScale || Target.transform.localScale.x + NewZ < MinScale)
            {
                return;
            }
            Target.transform.localScale += Vector3.one * NewZ;

        }

        private void MouseOperate()
        {
            if (Input.GetMouseButton(0))
            {
                RotateOperate(Input.mousePosition);
            }
            else
            if (Input.mouseScrollDelta != Vector2.zero)
            {
                ScaleOperate(Input.mouseScrollDelta);
            }
            else
            if (Input.GetMouseButton(2))
            {
                MoveOperate(Input.mousePosition);
            }
            else
            {
                ResetTouch();
            }
        }

        private void ScaleOperate(Vector2 mouseScrollDelta)
        {
            NewZ = mouseScrollDelta.y * 0.05F;
            Debug.Log(NewZ);
        }

        private int lastCount = 0;
        private void TouchOperate()
        {
            if (lastCount != Input.touchCount)
            {
                ResetTouch();
            }
            lastCount = Input.touchCount;
            if (Input.touchCount == 1)
            {
                RotateOperate(Input.GetTouch(0).position);
            }
            else
            if (Input.touchCount == 2)
            {
                ScaleOperate(Input.GetTouch(0).position, Input.GetTouch(1).position);
            }
            else
           if (Input.touchCount == 3)
            {
                MoveOperate(Input.GetTouch(0).position);
            }
        }

        private Vector2 _lastPos;
        private void MoveOperate(Vector2 position1)
        {
            if (_lastPos == Vector2.zero)
            {
                _lastPos = position1;
            }
            Vector2 pos = position1 - _lastPos;
            NewPos.x = pos.x * 0.01f;
            NewPos.y = pos.y * 0.01f;
            _lastPos = position1;
        }

        private Vector2 _lastRotatePos;
        private void RotateOperate(Vector2 position)
        {
            if (_lastRotatePos == Vector2.zero)
            {
                _lastRotatePos = position;
            }
            Vector2 pos = _lastRotatePos - position;
            NewX = -pos.y * 0.2f;
            NewY = pos.x * 0.2f;
            _lastRotatePos = position;
        }

        private float _lastDistance;
        public void ScaleOperate(Vector2 point1, Vector2 point2)
        {
            float distance = Vector2.Distance(point1, point2);
            if (_lastDistance == 0)
            {
                _lastDistance = distance;
            }
            float delta = _lastDistance - distance;
            NewZ = -delta * 0.001F;

            _lastDistance = distance;
        }
        private void ResetTouch()
        {
            _lastRotatePos = Vector2.zero;
            _lastPos = Vector2.zero;
            _lastDistance = 0;
        }
        #endregion 旋转位移缩放

        public float GetMaxSizeBoxCollider(GameObject go)
        {
            float maxSize = 0;
            var meshs = go.GetComponentInChildren<MeshFilter>().mesh;
            foreach (var item in meshs.vertices)
            {
                if (item.x > maxSize)
                    maxSize = item.x;
                else
             if (item.y > maxSize)
                    maxSize = item.y;
                else
             if (item.z > maxSize)
                    maxSize = item.z;
            }
             GameObject.DestroyImmediate(go.GetComponent<BoxCollider>());
            return maxSize;
        }

        public  float GetMaxSize(GameObject go)
        {
            float maxSize = 0;
            var meshs = go.GetComponentsInChildren<MeshFilter>();
            foreach (var item in meshs)
            {
                if (item.mesh.bounds.size.x * item.transform.localScale.x > maxSize)
                    maxSize = item.mesh.bounds.size.x*item.transform.localScale.x;
                else
                if (item.mesh.bounds.size.y * item.transform.localScale.y > maxSize)
                    maxSize = item.mesh.bounds.size.y * item.transform.localScale.y;
                else
                if (item.mesh.bounds.size.z * item.transform.localScale.z > maxSize)
                    maxSize = item.mesh.bounds.size.z * item.transform.localScale.z;
            }
            return maxSize;
         }
    }
}
