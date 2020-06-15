using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public enum ToggleState
{
    IsOn,
    UnIsOn
}

public class UIToggleOrdin : UIButtonOrdin
{
    [LabelText("ToggleState")]
    public Dictionary<ToggleState, List<UIChangeItemBase>> ToggleStateDic = new Dictionary<ToggleState, List<UIChangeItemBase>>();

    [HideInInspector]
    public Action<bool> ToggleEvent;
    [HideInInspector]
    public Action<UIToggleOrdin> ToggleEventSelf;

    public UIToggleGroupOrdin Group;
    private bool _inited = false;
    public override void Init()
    {
        if (_inited)
            return;
        _inited = true;
        if (Group != null && !Group.ToggleList.Contains(this))
        {
            Group.ToggleList.Add(this);
        }
        if (m_IsOn)
        {
            IsOn=true;
            if (Group != null)
            {
                if (!Group.ActiveToggle.Contains(this))
                {
                    Group.ActiveToggle.Add(this);
                    Group.SetLastToggle(this);
                }
            }
         }
     }

    public override bool Interactable
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
                if (!IsOn)
                    ChangeState(ButtonState.Disable);
            }
            if (IsOn)
            {
                ChangeState(ToggleState.IsOn);
            }
            //else
            //{
            //    ChangeState(ToggleState.UnIsOn);
            //}
        }
    }
 
    public bool m_IsOn;
    public bool IsOn
    {
        get { return m_IsOn; }
        set
        {
            if (m_IsOn != value)
            {
                m_IsOn = value;
                SetState(m_IsOn == true ? ToggleState.IsOn : ToggleState.UnIsOn);
            }
        }
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        if (IsOn)
            return;
        base.OnPointerEnter(eventData);
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        if (IsOn)
            return;
        base.OnPointerExit(eventData);
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        if (!Interactable)
            return;
        OnValueChanged();
     }

    public void OnValueChanged()
    {
        if (Group != null)
        {
            if (!Group.ChangeState(this))
                return;
        }
        m_IsOn = !m_IsOn;
        if (m_IsOn)
        {
            ChangeState(ToggleState.IsOn);
        }
        else
        {
            ChangeState(ToggleState.UnIsOn);
        }
    }

    public void SetState(ToggleState state)
    {
        if (Group != null)
        {
            if (!Group.SetState(this))
            {
                 m_IsOn = !m_IsOn;
                return;
            }
        }
         ChangeState(state);
     }

    public void ChangeState(ToggleState state)
    {
        PlayAnimation(state);
        InvokeEvent();
    }

    public void PlayAnimation(ToggleState state)
    {
        if (!ToggleStateDic.ContainsKey(state))
            return;
        foreach (var item in ToggleStateDic[state])
        {
            item.Play();
        }
    }

    public void InvokeEvent()
    {
        ToggleEvent?.Invoke(m_IsOn);
        ToggleEventSelf?.Invoke(this);
    }
}
