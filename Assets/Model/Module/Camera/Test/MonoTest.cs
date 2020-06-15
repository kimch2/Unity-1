using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ETModel;
using System;
using UnityEngine.EventSystems;
namespace ETModel
{
    public class MonoTest : MonoBehaviour
    {
        public GameObject Target;

         void Update()
        {
            if (Target != null)
            {
                transform.position = Camera.main.WorldToScreenPoint(Target.transform.position);
            }
        }
    }
}
