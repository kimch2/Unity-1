using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;
using UnityEngine.UI;
using DG.Tweening;
namespace ETModel
{
    [ObjectSystem]
    public class UIConfirmWindowAwakeSystem : AwakeSystem<UIConfirmWindowComponent>
    {
        public override void Awake(UIConfirmWindowComponent self)
        {
            self.Init();
        }
    }

    public enum ConfirmPanelType
    {
        EventType,
        QuitPanel,
        CompeletePanel,
        WrongPanel,
        ChangeLifter,
        CompeleteMission,
        JumpStep
    }


    public partial class UIConfirmWindowComponent : UIPanelComponent
    {
        public override void Init()
        {
            Collector.Get<GameObject>("EventPanel").GetComponent<UIWindow>().Init();
            Collector.Get<GameObject>("CompeletePanel").GetComponent<UIWindow>().Init();
            Collector.Get<GameObject>("ErrorPanel").GetComponent<UIWindow>().Init();

            Collector.Get<GameObject>("CompeletePanel").GetComponent<UIWindow>().CloseEvent+= CloseHandle;
            _ConfrimBtn = Collector.GetMonoComponent<UIButtonOrdin>("ConfirmBtn");
            _CancelBtn = Collector.GetMonoComponent<UIButtonOrdin>("CancelBtn");
            _CloseBtn = Collector.GetMonoComponent<UIButtonOrdin>("CloseBtn");
            
            _BackGround = Collector.GetMonoComponent<Image>("BackGround");

            _ConfrimBtn = Collector.GetMonoComponent<UIButtonOrdin>("ConfirmBtn");
            _CancelBtn = Collector.GetMonoComponent<UIButtonOrdin>("CancelBtn");

            _ConfrimBtn.ClickEvent += CloseHandle;
            _CloseBtn.ClickEvent += CloseHandle;
            _CancelBtn.ClickEvent += CloseHandle;


            ErrorPanelCloseBtn = Collector.GetMonoComponent<UIButtonOrdin>("ErrorPanelCloseBtn");
            ErrorPanelCancelBtn = Collector.GetMonoComponent<UIButtonOrdin>("ErrorPanelCancelBtn");
            ErrorPanelReSelectBtn = Collector.GetMonoComponent<UIButtonOrdin>("ErrorPanelReSelectBtn");
            ErrorPanelCloseBtn.ClickEvent += CloseHandle;
            ErrorPanelCancelBtn.ClickEvent += CloseHandle;
            ErrorPanelReSelectBtn.ClickEvent += CloseHandle;

        }

        UIButtonOrdin ErrorPanelCloseBtn, ErrorPanelCancelBtn, ErrorPanelReSelectBtn;
        private void CloseHandle()
        {
            _BackGround.raycastTarget = false;
            _BackGround.DOFade(0, 0.3f);
        }

        private Image _BackGround;
        private Action _lastEvent;
        private Action _lastCancelEvent;
        private Action _lastErrorEvent;
        private Action _lastErrorCancelEvent;

        private UIButtonOrdin _ConfrimBtn;
        private UIButtonOrdin _CancelBtn;
        private UIButtonOrdin _CloseBtn;

        public void ShowPanel(Action act, string message, ConfirmPanelType type = ConfirmPanelType.EventType)
        {
            base.Show();
            _BackGround.raycastTarget = true;
            _BackGround.DOFade(0.3f, 0.3f);
             SetTypePanel(type, message);
            _ConfrimBtn.ClickEvent -= _lastEvent;
            _ConfrimBtn.ClickEvent += act;
            _lastEvent = act;
            GameObject.SetActive(true);
        }




        public void ShowPanel(Action act, Action act2, string message, ConfirmPanelType type = ConfirmPanelType.EventType)
        {
            base.Show();
            _BackGround.raycastTarget = true;
            _BackGround.DOFade(0.3f, 0.3f);
            SetTypePanel(type, message);
            switch (type)
            {
                case ConfirmPanelType.WrongPanel:
                    ErrorPanelReSelectBtn.ClickEvent -= _lastErrorEvent;
                    ErrorPanelReSelectBtn.ClickEvent += act;
                    ErrorPanelCancelBtn.ClickEvent -= _lastErrorCancelEvent;
                    ErrorPanelCancelBtn.ClickEvent += act2;
                    _lastErrorEvent = act;
                    _lastErrorCancelEvent = act2;
                    break;
                default:
                    _ConfrimBtn.ClickEvent -= _lastEvent;
                    _ConfrimBtn.ClickEvent += act;
                    _CancelBtn.ClickEvent -= _lastCancelEvent;
                    _CancelBtn.ClickEvent += act2;
                    _lastEvent = act;
                    _lastCancelEvent = act2;
                    break;
            }
             GameObject.SetActive(true);
        }


        private   void SetTypePanel(ConfirmPanelType type, string message)
        {
             switch (type)
            {
                case ConfirmPanelType.EventType:
                    Collector.Get<GameObject>("EventPanel").transform.localPosition = _EndPos;
                    _EndPos = Vector3.zero;
                    Collector.Get<GameObject>("EventPanel").GetComponent<UIWindow>().ShowWindow();
                    Collector.Get<GameObject>("EventPanel").GetComponentInChildren<TMPro.TMP_Text>().text = message;
                    break;
                case ConfirmPanelType.CompeletePanel:
                     Collector.Get<GameObject>("CompeletePanel").transform.localPosition = _EndPos;
                    _EndPos = Vector3.zero;
                    Collector.Get<GameObject>("CompeletePanel").GetComponentInChildren<TMPro.TMP_Text>().text = message;
                     Collector.Get<GameObject>("CompeletePanel").GetComponent<UIWindow>().ShowWindow();
                     break;
                case ConfirmPanelType.WrongPanel:
                    Collector.Get<GameObject>("ErrorPanel").transform.localPosition = _EndPos;
                    _EndPos = Vector3.zero;
                    Collector.Get<GameObject>("ErrorPanel").GetComponent<UIWindow>().ShowWindow();
                    break;

            }
        }

        private Vector3 _EndPos;
        public void SetPosition(Vector3 pos)
        {
            _EndPos = pos;
        }
    }
}
