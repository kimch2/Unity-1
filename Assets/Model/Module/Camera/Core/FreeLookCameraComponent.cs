using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Threading;
using System.Xml;

namespace ETModel {

    [ObjectSystem]
    public class FreeLookCameraUpdateSystem : UpdateSystem<FreeLookCameraComponent>
    {
        public override void Update(FreeLookCameraComponent self)
        {
            self.Update();
        }
    }

    [ObjectSystem]
    public class FreeLookCameraAwakeSystem : AwakeSystem<FreeLookCameraComponent>
    {
        public override void Awake(FreeLookCameraComponent self)
        {
            self.Awake();
        }
    }

    public class FreeLookCameraComponent : Component
    {
        public Transform Target;

        private Collider _collider;

        private Transform _targetPos;

        public Transform CurrentCamera;

        private GameObject CameraRoot;
 
        public bool IsChangingTarget;

        private List<IInputControl> inputs = new List<IInputControl>();

        private InputComponent _inputComponent;
        public void Awake()
        {
              tokenSource = new CancellationTokenSource();
            _inputComponent = Game.Scene.GetComponent<InputComponent>();
            _targetPos = new GameObject("[TargetPosition]").transform;
            _targetPos.SetParent(GameObject.transform);
            inputs.Add(new MoveInput());
            inputs.Add(new RotateInput());
            inputs.Add(new ZoomInput());
        }

        private Dictionary<string, ViewItemData> _ViewDataDic = new Dictionary<string, ViewItemData>();


        public void LoadData()
        {
            InitViewData();
        }

        public ViewItemData GetViewDataByID(string id)
        {
            _ViewDataDic.TryGetValue(id, out ViewItemData data);
            return data;
        }

        private async void InitViewData()
        {
            _ViewDataDic.Clear();
            var list = await XmlConfigHelper.LoadXml(ConfigType.ViewDataConfig);
            foreach (XmlNode item in list.NodeList)
            {
                ViewItemData data = new ViewItemData();
                data.ID = item.Attributes["ID"].Value;
                data.ValueX = float.Parse(item.Attributes["X"].Value);
                data.ValueY = float.Parse(item.Attributes["Y"].Value);
                data.Distance = float.Parse(item.Attributes["Distance"].Value);
                data.TargetID = item.Attributes["TargetID"].Value;
                data.Precondition = item.Attributes["Precondition"].Value;
                _ViewDataDic.Add(data.ID, data);
            }
        }


        public void SetCamera(Camera camera)
        {
            CurrentCamera = camera.transform;
             if (CameraRoot == null)
            {
                 GameObject go = new GameObject("[CameraRoot]");
                //_collider = GameObject.Find("[Collider]").GetComponent<Collider>();
                var parent = camera.transform.parent;
                camera.transform.SetParent(go.transform);
                go.transform.SetParent(parent);
                camera.transform.localEulerAngles = Vector3.zero;
                camera.transform.localPosition = Vector3.zero;
                CameraRoot = go;
            }
 
        }

        public void SetInputValue(ViewItemData config)
        {
            Target = GameObject.Find(config.TargetID).transform;
        }
 
        private Tween _lastMoveTargetTween;
        private CancellationTokenSource tokenSource;
        public async ETTask MoveToTarget(Camera camera ,ViewItemData config)
        {
            try
            {
                GameObject go = GameObject.Find(config.TargetID);
                 //GameObject go =Game.Scene.GetComponent<UnityGameObjectComponent>().FindById( (int)config.Id)?.Value;
                if (go == null)
                {
                    Debug.LogError($"找不到对象{config.TargetID}");
                    return;
                }
                SetCamera(camera);
                Target = go.transform;
                _targetPos.transform.position = Target.position;
                _targetPos.transform.rotation = Target.rotation;
 
                InputParameter.SetParameter(config);

                _lastMoveTargetTween.Kill();
                tokenSource.Cancel();
                tokenSource = new CancellationTokenSource();
                IsChangingTarget = true;
 

                SetInputValue(config);

                Vector3 initAngle = CurrentCamera.localEulerAngles;


                CurrentCamera.localEulerAngles = new Vector3(InputParameter.SummationX, InputParameter.SummationY);

                var endpos = CurrentCamera.rotation * new Vector3(0.0f, 0.0f, -InputParameter.SummationZ) + _targetPos.transform.position;

                CurrentCamera.localEulerAngles = initAngle;

                float time = Vector3.Distance(CurrentCamera.position, endpos) * 0.1f;

                if (time > 2)
                {
                    time = 1;
                }
                if (time < 0.5f)
                {
                    time = 0.5f;
                }

                _lastMoveTargetTween = CurrentCamera.DOLocalRotate(new Vector3(InputParameter.SummationX, InputParameter.SummationY), time);

                _lastMoveTargetTween = CurrentCamera.DOMove(endpos, time);
 
                _lastMoveTargetTween.onComplete += () =>
               {
                   if (CurrentCamera.parent.parent != null)
                   {
                       var _dragTarget = CurrentCamera.parent.parent;
                       CurrentCamera.parent.SetParent(null);
                       _dragTarget.transform.position = CurrentCamera.position;
                       _dragTarget.transform.localEulerAngles = new Vector3(0, CurrentCamera.localEulerAngles.y, 0);
                       CurrentCamera.parent.SetParent(_dragTarget.transform);
                   }
                   IsChangingTarget = false;
               };
 
                //while (IsChangingTarget)
                //{
                //     await Game.Scene.GetComponent<TimerComponent>().WaitAsync(100, tokenSource.Token);
                //}
             }
            catch (Exception ex)
            {
                Debug.LogError(ex.StackTrace);
            }
        }




        public async ETTask MoveToTarget(ViewItemData config)
        {
            GameObject go = GameObject.Find(config.TargetID);
            Debug.LogError(config.TargetID);

            if (go == null)
            {
                Debug.LogError($"找不到对象{config.TargetID}");
                return;
            }
            SetCamera(Game.Scene.GetComponent<MainCameraComponent>().Camera);
              Target = go.transform;
            _targetPos.transform.position = Target.position;
            _targetPos.transform.rotation = Target.rotation;

            InputParameter.SetParameter(config);

            _lastMoveTargetTween.Kill();
            tokenSource.Cancel();
            tokenSource = new CancellationTokenSource();
            IsChangingTarget = true;

            SetInputValue(config);

            Vector3 initAngle = CurrentCamera.localEulerAngles;


            CurrentCamera.localEulerAngles = new Vector3(InputParameter.SummationX, InputParameter.SummationY);

            var endpos = CurrentCamera.rotation * new Vector3(0.0f, 0.0f, -InputParameter.SummationZ) + _targetPos.transform.position;

            CurrentCamera.localEulerAngles = initAngle;

            float time = Vector3.Distance(CurrentCamera.position, endpos) * 0.1f;

            if (time > 2)
            {
                time = 1;
            }
            if (time < 0.5f)
            {
                time = 0.5f;
            }
            _lastMoveTargetTween = CurrentCamera.DOLocalRotate(new Vector3(InputParameter.SummationX, InputParameter.SummationY), time);

            _lastMoveTargetTween = CurrentCamera.DOMove(endpos, time);

            _lastMoveTargetTween.onComplete += () =>
            {
                if (CurrentCamera.parent.parent != null)
                {
                    var _dragTarget = CurrentCamera.parent.parent;
                    CurrentCamera.parent.SetParent(null);
                    _dragTarget.transform.position = CurrentCamera.position;
                    _dragTarget.transform.localEulerAngles = new Vector3(0, CurrentCamera.localEulerAngles.y, 0);
                    CurrentCamera.parent.SetParent(_dragTarget.transform);
                }
                IsChangingTarget = false;
            };
            while (IsChangingTarget)
            {
                await Game.Scene.GetComponent<TimerComponent>().WaitAsync(100, tokenSource.Token);
            }
        }


        public bool IsOverUI;
        public  void Update()
        {
            if (IsChangingTarget)
            {
                return;
            }
 
            if (Target == null)
            {
                return;
            }
            if (Input.GetMouseButtonDown(0))
            {
                IsOverUI = _inputComponent.IsPointerEnterUI();
            }

            if (IsOverUI)
            {
                return;
            }
            if (Input.touchCount > 0)
            {
                foreach (var item in inputs)
                {
                     item.TouchInput();
                     item.UpdatInput(CurrentCamera, _targetPos.transform, _collider);
                }
            }
            else
            {
  
                foreach (var item in inputs)
                {
                     item.MouseInput();
                     item.UpdatInput(CurrentCamera, _targetPos.transform, _collider);
                 }
            }
            CurrentCamera.position = new Vector3(Mathf.Clamp(CurrentCamera.position.x, ClampMinX, ClampMaxX), CurrentCamera.position.y, Mathf.Clamp(CurrentCamera.position.z, ClampMinZ, ClampMaxZ));
         }
        public const int ClampMaxX = 12;
        public const int ClampMinX = 3;
        public const int ClampMaxZ = -28;
        public const int ClampMinZ = -40;

    }

}
