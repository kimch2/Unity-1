using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ETModel;
using System;
using System.Threading.Tasks;
using HighlightingSystem;
using System.Linq;

namespace ETModel
{
 
    public class HighLightingComponent:Component
    {
        private List<GameObject> _highlightedTarget = new List<GameObject>();

        public void HighLightObjectDirect(GameObject target, Color color)
        {
             target.GetComponent<Highlighter>()?.ConstantOn(color);
        }

        public void HighLightObject(GameObject target, Color color)
        {
            if (target == null)
                return;
            if (color == ColorHelper.HighLightColor)
                return;

            if (target.GetComponent<Highlighter>() == null)
            {
                target.AddComponent<Highlighter>();
            }
            if (target.GetComponent<Highlighter>().constantColor == ColorHelper.HighLightColor && color != ColorHelper.HighLightColor)
            {
                return;
            }
             target.GetComponent<Highlighter>()?.ConstantOn(color);
         }

        public void HighLightObject(GameObject target)
        {
            if (target == null)
                return;
            if (target.GetComponentInChildren<Highlighter>() == null)
            {
                target.AddComponent<Highlighter>();
            }
            _highlightedTarget.Add(target);
            target.GetComponentInChildren<Highlighter>().ConstantOn(ColorHelper.HighLightColor);
         }

        public void CloseHighLight(GameObject target, Color color)
        {
            if (target == null)
                return;
            if (color == ColorHelper.HighLightColor)
                return;
            if (target.GetComponent<Highlighter>() == null)
            {
                target.AddComponent<Highlighter>();
            }
            if (target.GetComponent<Highlighter>().constantColor == ColorHelper.HighLightColor && color != ColorHelper.HighLightColor)
            {
                return;
            }
            target.GetComponent<Highlighter>()?.ConstantOff();
 
        }
        public void CloseHighLightDirect(GameObject target, Color color)
        {
             target.GetComponent<Highlighter>()?.ConstantOff();
         }

        public void CloseHighLight(GameObject target)
        {
            if (target == null)
                return;
            if (target.GetComponent<Highlighter>() == null)
            {
                target.AddComponent<Highlighter>();
            }
            target.GetComponent<Highlighter>().ConstantOff();
            target.GetComponent<Highlighter>().constantColor = Color.white;
         }


        public void CloseHighLight(List<GameObject> target,List<string>list)
        {
            foreach (var item in target)
            {
                CloseHighLight(item);
            }
            if (list == null)
                return;
            foreach (var item in list)
            {
                var go = GameObject.Find(item);
                CloseHighLight(go);
            }
        }

        public void CloseAll()
        {
            foreach (var item in _highlightedTarget)
            {
                CloseHighLight(item);
            }
            _highlightedTarget.Clear();
         }

        public void HighLightObject(List<GameObject> targetlist, List<string> list)
        {
            CloseAll();
            if (targetlist != null)
            {
                foreach (var item in targetlist)
                {
                    HighLightObject(item);
                }
            }

            if (list == null)
                return;
 
          
        }
      }
}