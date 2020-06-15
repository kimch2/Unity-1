using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;


public class UIButtonOrdin : SerializedMonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    [LabelText("按钮变换")]
    public Dictionary<ButtonState, List<UIChangeItemBase>> Tansition = new Dictionary<ButtonState, List<UIChangeItemBase>>();

    public bool m_Interactable = true;

    [HideInInspector]
    public float AlpahTest = 1;
    [HideInInspector]
    public Action ClickEvent;
    [HideInInspector]
    public Action<Transform> ClickEventArg;

    [HideInInspector]
    public Action ClickDownEvent;
    [HideInInspector]
    public Action ClickUpEvent;

    public virtual bool Interactable
    {
        get { return m_Interactable; }
        set
        {
            m_Interactable = value;
            if (m_Interactable)
            {
                ChangeState(ButtonState.Normal);
            }
            else
            {
                ChangeState(ButtonState.Disable);
            }
        }
    }

    public ButtonState State;

    protected bool _isOverImage;

    private void Start()
    {
        if (AlpahTest != 1)
        {
            SetAlpahTest();
        }
        foreach (var item in Tansition)
        {
            foreach (var change in item.Value)
            {
                change.Init();
            }
        }
        SetInitState();
        Init();
        Interactable = m_Interactable;
    }

    public virtual void Init() { }
    private void SetInitState()
    {
        if (!Interactable)
        {
            ChangeState(ButtonState.Disable);
        }
        else
        {
            ChangeState(ButtonState.Normal);
        }
    }

    private void SetAlpahTest()
    {
        Image[] images = GetComponentsInChildren<Image>();
        foreach (var item in images)
        {
            item.alphaHitTestMinimumThreshold = AlpahTest;
        }
    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        _isOverImage = true;
        ChangeState(ButtonState.HighLight);
    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        _isOverImage = false;
        ChangeState(ButtonState.Normal);
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        if (Interactable)
            ClickDownEvent?.Invoke();
        ChangeState(ButtonState.Press);
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        if (Interactable)
            ClickUpEvent?.Invoke();
        ChangeState(ButtonState.PressUp);
        if (_isOverImage)
        {
            ChangeState(ButtonState.HighLight);
        }
        else
        {
            ChangeState(ButtonState.Normal);
        }
    }

    public virtual void ChangeState(ButtonState state)
    {

        if (!Interactable && state != ButtonState.Disable)
            return;
        if (!Tansition.ContainsKey(state))
        {
            switch (state)
            {
                //case ButtonState.Normal:
                //    foreach (var item in Tansition[state])
                //    {
                //        item.Back();
                //    }
                //    break;
                //case ButtonState.Press:
                //     break;
                //case ButtonState.HighLight:
                //    break;
            }
            return;
        }
        foreach (var item in Tansition[state])
        {
            item.Play();
        }
        State = state;
    }



    private void OnDisable()
    {
        if (Interactable)
        {
            ChangeState(ButtonState.Normal);
        }
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        if (Interactable)
        {
            ClickEvent?.Invoke();
            ClickEventArg?.Invoke(transform);
        }
    }
}
