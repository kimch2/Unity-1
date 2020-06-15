using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ETModel
{
    [ExecuteInEditMode]
    [RequireComponent(typeof(RectTransform))]
    public class CircleLayoutGroup : UIBehaviour, ILayoutElement, ILayoutGroup
    {
        [SerializeField]
        [Range(0, 360)]
        private float startAngle;
        public float StartAngle => this.startAngle;

        [SerializeField]
        [Range(0, 360)]
        private float endAngle;
        public float EndAngle => this.endAngle;

        [SerializeField]
        private float radius;
        public float Radius => this.radius;

        [SerializeField]
        [Range(0, 360)]
        private float angleOffset;
        public float AngleOffset => this.angleOffset;

        [SerializeField]
        private bool invertX;
        public bool InvertX => this.invertX;

        [SerializeField]
        private bool invertY;
        public bool InvertY => this.invertY;

        public virtual float minWidth { get { return 0; } }
        public virtual float preferredWidth { get { return 0; } }
        public virtual float flexibleWidth { get { return 0; } }
        public virtual float minHeight { get { return 0; } }
        public virtual float preferredHeight { get { return 0; } }
        public virtual float flexibleHeight { get { return 0; } }
        public virtual int layoutPriority { get { return 0; } }

        [System.NonSerialized]
        private List<RectTransform> rectChildren = new List<RectTransform>();
        protected List<RectTransform> RectChildren { get { return rectChildren; } }

        [System.NonSerialized]
        private RectTransform rectTransform;
        protected RectTransform RectTransform
        {
            get
            {
                if (rectTransform == null)
                {
                    rectTransform = GetComponent<RectTransform>();
                }
                return rectTransform;
            }
        }

        protected DrivenRectTransformTracker tracker = new DrivenRectTransformTracker();

        protected void SetDirty()
        {
            if (!IsActive())
            {
                return;
            }

            LayoutRebuilder.MarkLayoutForRebuild(rectTransform);
        }

        protected override void Awake()
        {
            base.Awake();

            CalculateLayout();
            SetLayout();
        }

#if UNITY_EDITOR
        protected override void OnValidate()
        {
            SetDirty();
        }

#endif
        protected override void OnEnable()
        {
            base.OnEnable();
            SetDirty();
        }
        protected override void OnRectTransformDimensionsChange()
        {
            base.OnRectTransformDimensionsChange();
            SetDirty();
        }

        protected virtual void OnTransformChildrenChanged()
        {
            SetDirty();
        }

        protected override void OnDidApplyAnimationProperties()
        {
            SetDirty();
        }

        private void SetLayout()
        {
            if (this.RectChildren.Count < 0)
            {
                return;
            }

            float deltaDegree = (this.endAngle - this.startAngle) / (this.RectChildren.Count - (this.endAngle >= 360f ? 0 : 1));
            float currentDegree;
            float cosA;
            float sinA;
            float length = this.RectChildren.Count;
            for (int i = 0; i < length; i++)
            {
                currentDegree = (this.startAngle + deltaDegree * i + this.angleOffset) * Mathf.Deg2Rad;
                cosA = Mathf.Cos(currentDegree);
                sinA = Mathf.Sin(currentDegree);
                this.RectChildren[i].anchorMin = Vector2.one * 0.5f;
                this.RectChildren[i].anchorMax = Vector2.one * 0.5f;
                this.RectChildren[i].pivot = Vector2.one * 0.5f;
                this.RectChildren[i].anchoredPosition = new Vector2(cosA * radius * (this.invertX ? -1 : 1), sinA * radius * (this.invertY ? -1 : 1));

                tracker.Add(this, this.RectChildren[i], DrivenTransformProperties.AnchoredPosition | DrivenTransformProperties.Anchors | DrivenTransformProperties.Pivot);
            }
        }

        public void CalculateLayoutInputHorizontal()
        {
            CalculateLayout();
        }

        public void CalculateLayoutInputVertical()
        {
            CalculateLayout();
        }

        private void CalculateLayout()
        {
            if (this.RectChildren.Count < 0)
            {
                return;
            }

            rectChildren.Clear();
            for (int i = 0; i < RectTransform.childCount; i++)
            {
                RectTransform rect = RectTransform.GetChild(i) as RectTransform;
                if (rect == null)
                {
                    continue;
                }
                ILayoutIgnorer ignorer = rect.GetComponent(typeof(ILayoutIgnorer)) as ILayoutIgnorer;
                if (rect.gameObject.activeInHierarchy && !(ignorer != null && ignorer.ignoreLayout))
                {
                    rectChildren.Add(rect);
                }
            }

            tracker.Clear();
        }

        public void SetLayoutHorizontal()
        {
            SetLayout();
        }

        public void SetLayoutVertical()
        {
            SetLayout();
        }
    }
}