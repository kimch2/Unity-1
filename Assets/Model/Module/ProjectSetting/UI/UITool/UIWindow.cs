﻿ using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
  using System.Threading.Tasks;
using System.Linq;

namespace ETModel
{
    public class UIWindow : MonoBehaviour
    {
        public UIToggleOrdin ControlToggle;

        public List<UIButtonOrdin> OpenBtn;

        public List<UIButtonOrdin> CloseBtn;
  
        private List<UIButtonOrdin> _activeBtn = new List<UIButtonOrdin>();


        public delegate void OpenVoid();
        public delegate void CloseVoid();
        public event OpenVoid OpenEvent;
        public event CloseVoid CloseEvent;


        public void Init()
        {
            if (GetComponent<CanvasGroup>() == null)
            {
                gameObject.AddComponent<CanvasGroup>();
            }
            _activeBtn = GetComponentsInChildren<UIButtonOrdin>().ToList();
            CloseImmediate();
            if (ControlToggle != null)
            {
                 ControlToggle.ToggleEvent += ControlToggleHandle;
            }
            if (OpenBtn != null)
            {
                foreach (var item in OpenBtn)
                {
                    if (item != null)
                        item.ClickEvent += OpenBtnHandle;
                }
            }
            if (CloseBtn != null)
            {
 
                foreach (var item in CloseBtn)
                {
                     if (item != null)
                        item.ClickEvent += CloseBtnHandle;
                }
            }
            gameObject.SetActive(false);
        }

        public void SetOpenBtn(UIButtonOrdin btn)
        {
            if (!OpenBtn.Contains(btn))
            {
                OpenBtn.Add(btn);
            }
        }

        public void SetToggleBtn(UIToggleOrdin toggle)
        {
            ControlToggle = toggle;
        }

        public void SetUIComponent(UIPanelComponent component)
        {
            OpenEvent += component.Show;
            CloseEvent += component.Hide;
        }



        private void CloseBtnHandle()
        {
            if (ControlToggle != null)
            {
                UnityEngine.Debug.LogError("ShowWindow");

                ControlToggle.IsOn = false;
            }
            else
            {
                CloseWindow();
            }
        }

        private void OpenBtnHandle()
        {
            if (ControlToggle != null)
            {
                ControlToggle.IsOn = true;
            }
            else
            {
                ShowWindow();
            }
        }

        private void ControlToggleHandle(bool arg)
        {
             if (arg)
            {
                ShowWindow();
            }
            else
            {
                CloseWindow();
            }
        }

        public void ShowWindow()
        {
            OpenEvent?.Invoke();
            transform.SetAsLastSibling();
            gameObject.SetActive(true);
            transform.DOScale(Vector3.one * 0.8f, 0);
            GetComponent<CanvasGroup>().DOFade(1,0.3f);
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            transform.DOScale(Vector3.one, 0.3f);
             foreach (var item in _activeBtn)
            {
                item.enabled = true;
            }

        }

        public async void CloseWindow()
        {
            GetComponent<CanvasGroup>().blocksRaycasts = false;

            transform.DOScale(Vector3.one * 0.9f, 0.3f);
            GetComponent<CanvasGroup>().DOFade(0, 0.3f);
            foreach (var item in _activeBtn)
            {
                item.enabled = false;
            }
            await Task.Delay(300);
            gameObject.SetActive(false);
            CloseEvent?.Invoke();
        }

        public void CloseImmediate()
        {
            transform.DOScale(Vector3.one * 0.9f, 0);
            GetComponent<CanvasGroup>().DOFade(0, 0);
         }
    }
}