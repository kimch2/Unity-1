using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ETModel
{
    public class UIPanelComponent : Component
    {
        private   ReferenceCollector _collector;
        public   ReferenceCollector Collector
        {
            get
            {
                if (_collector == null)
                {
                      _collector = GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();
                }
                return _collector;
            }
        }
 

        private Canvas _canvas;
        public Canvas m_Canvas
        {
            get
            {
                if (_canvas == null)
                    _canvas = GetParent<UI>().GameObject.GetComponent<Canvas>();
                return _canvas;
            }
        }


        public Sprite GetSprite(string textureName)
        {
            Texture2D texture = Collector.Get<Texture2D>(textureName);
            Sprite sp = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            return sp;
        }

 
        public virtual void Show()
        {
            GetParent<UI>().SetAsLastSibling();
            GetParent<UI>().Canvas.enabled = true;
        }

        public virtual void Hide()
        {
            GetParent<UI>().Canvas.enabled = false;
            GetParent<UI>().SetAsFirstSibling();
        }

         public void SetActive(bool active)
        {
            if (active)
            {
                Show();
            }
            else
            {
                Hide();
            }
        }

        public virtual void Init() { }
    }
}