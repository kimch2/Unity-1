using DG.Tweening;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Title("移动")]
[HideReferenceObjectPicker]
public class MoveItem : UIChangeItemBase
{
    [LabelText("移动对象")]
    public Transform Target;
    [LabelText("移动目标")]
    public Vector3 EndValue;
    [LabelText("移动时间")]
    public float Time;
    [LabelText("移动方式")]
    public Ease MoveType;

    private Vector3? _initPos;
    public override void Back()
    {
        if (_initPos.HasValue)
        {
            Target.DOLocalMove(_initPos.Value, Time).SetEase(MoveType);
        }
    }

    public override void Play()
    {
        if (!_initPos.HasValue)
        {
            _initPos = Target.position;
        }
        Target.DOLocalMove(EndValue, Time).SetEase(MoveType);
    }
}
