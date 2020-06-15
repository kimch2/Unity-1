﻿using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BarState
{
    Horizontal,
    Vertical
}
public class UIToggleGroupOrdin : MonoBehaviour
{
    public List<UIToggleOrdin> ToggleList = new List<UIToggleOrdin>();

    public bool AllowSwitchOff;

    public UIToggleOrdin lastUIToggle;

    public List<UIToggleOrdin> ActiveToggle = new List<UIToggleOrdin>();

    public UIButtonOrdin ActiveBtn;

    public Transform Bar;
    public BarState BarState;

    private void Aawke()
    {
        if (ActiveBtn != null)
            ActiveBtn.Interactable = false;
    }

    public void ResetState()
    {
        bool active = AllowSwitchOff;
        AllowSwitchOff = true;
        foreach (var item in ActiveToggle)
        {
            item.IsOn = false;
        }
        AllowSwitchOff = active;
    }

    public void SetActiveBtnState()
    {
        if (ActiveBtn == null)
            return;
        ActiveBtn.Interactable = ActiveToggle.Count > 0 ? true : false;
    }

    public void SetLastToggle(UIToggleOrdin toggle)
    {
        lastUIToggle = toggle;
    }

    public bool SetState(UIToggleOrdin target)
    {
        if (target.IsOn)
        {
            if (lastUIToggle != null)
            {
                ActiveToggle.Remove(lastUIToggle);
                lastUIToggle.IsOn = false;
            }
            ActiveToggle.Add(target);
            SetBarPos(target.transform);
            lastUIToggle = target;
        }
        else
        {
            if (AllowSwitchOff)
            {
                ActiveToggle.Remove(target);
                lastUIToggle = null;
            }
            else if(ActiveToggle.Contains(target))
            {
                 return false;
            }
        }
        return true;
    }

    public virtual bool ChangeState(UIToggleOrdin target)
    {
        if (target.IsOn)
        {
            if (AllowSwitchOff)
            {
                ActiveToggle.Remove(target);
                lastUIToggle = null;
            }
            else
            {
                target.ChangeState(ToggleState.IsOn);
                SetBarPos(target.transform);
                return false;
            }
        }
        else
        {
            if (lastUIToggle != null)
            {
                ActiveToggle.Remove(lastUIToggle);
                lastUIToggle.IsOn = false;
            }
            ActiveToggle.Add(target);
            SetBarPos(target.transform);
            lastUIToggle = target;
        }
        SetActiveBtnState();
        return true;
     }

    public void SetBarPos(Transform pos)
    {
        if (Bar != null)
        {
            Bar.SetParent(pos);
            Bar.transform.localScale = Vector3.one;
            switch (BarState)
            {
                case BarState.Horizontal:
                    Bar.DOLocalMoveX(0, 0.3f);
                    break;
                case BarState.Vertical:
                    Bar.DOLocalMoveY(0, 0.3f);
                    break;
            }
        }
    }
}
