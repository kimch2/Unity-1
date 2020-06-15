﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ETModel
{
    /// <summary>
    /// 缩放操作
    /// </summary>
    public class ZoomInput : IInputControl
    {
        private float _deltaZ;

        private float _speed;
        private float speed { 
            get { return Mathf.Clamp(_speed, 1, 5); }
            set {
                _speed = value;
            }
        }
        public bool MouseInput()
        {
            if (Input.mouseScrollDelta != Vector2.zero)
            {
                ScaleOperate(Input.mouseScrollDelta);
                return true;
            }
            else
            if (_deltaZ == 0)
            {
                return false;
            }
            return true;
        }

        public bool TouchInput()
        {
            if (Input.touchCount == 2)
            {
                ScaleOperate(Input.GetTouch(0).position, Input.GetTouch(1).position);
                return true;
            }
            else
            {
                _lastDistance = 0;
                if (_deltaZ == 0)
                {
                    return false;
                }
            }
            return true;
        }


        private float _lastDistance;
        public void ScaleOperate(Vector2 point1, Vector2 point2)
        {
            float distance = Vector2.Distance(point1, point2);
            _lastDistance = _lastDistance == 0 ? distance : _lastDistance;
            float delta = _lastDistance - distance;
            _deltaZ = delta * 0.0005F * InputParameter.MaxDistance;
              _lastDistance = distance;
        }

        private void ScaleOperate(Vector2 mouseScrollDelta)
        {
            _deltaZ = -mouseScrollDelta.y*0.005f;
        }

 
        public void UpdatInput(Transform camera, Transform target, Collider collider)
        {
            _deltaZ = Mathf.Lerp(_deltaZ, 0, Time.deltaTime * InputParameter.ZoomSpeed * 10);
            float value = InputParameter.SummationZ <= 0.5f ? 1 : InputParameter.SummationZ * 5;
            InputParameter.SummationZ += _deltaZ * speed* value;
            InputParameter.SummationZ = Mathf.Clamp(InputParameter.SummationZ, InputParameter.MinDistance, InputParameter.MaxDistance);
            var pos = camera.rotation * (Vector3.back * InputParameter.SummationZ) + target.transform.position;
            if (collider != null && collider.bounds.Contains(pos))
            {
                camera.position = pos;
            }
         }
    }
}