using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ETModel
{
    public class UIToggle: MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IBeginDragHandler, IEndDragHandler
    {
#if UNITY_EDITOR

        [SerializeField]
#endif
        protected string state = UIStates.Default;

        public virtual string State
        {
            get => this.state;
            set
            {
                if (this.state == value)
                {
                    return;
                }
                this.PreviousState = this.state;
                this.SetState(this.state = value);
            }
        }

        public string PreviousState { get; protected set; }

        public event Action<bool> OnValueChangedEvent;

        public event Action<UIToggle> OnToggleChangedEvent;

#if UNITY_EDITOR

        [SerializeField]
#endif
        protected bool isOn = false;

        public virtual bool IsOn
        {
            get => this.isOn;
            set
            {
                if (this.isOn == value)
                {
                    return;
                }
                this.isOn = value;

                if (this.isInside)
                {
                    this.State = this.isOn ? UIStates.SelectedHover : UIStates.Hover;
                }
                else
                {
                    this.State = this.isOn ? UIStates.Selected : UIStates.Default;
                }
            }
        }

        [SerializeField]
        protected UIToggleGroup toggleGroup;
        public UIToggleGroup ToggleGroup
        {
            get => this.toggleGroup;
            set
            {
                if (this.toggleGroup == value)
                {
                    return;
                }
                this.toggleGroup?.UnregisterToggle(this);
                this.toggleGroup = value;
                this.toggleGroup?.RegisterToggle(this);
            }
        }

        /// <summary>
        /// 指针是否在内部
        /// </summary>
        protected bool isInside;

        /// <summary>
        /// 指针是否按下
        /// </summary>
        protected bool isPressed;

        /// <summary>
        /// 指针是否拖拽
        /// </summary>
        protected bool isDragging;

        protected virtual void Awake()
        {
            this.toggleGroup?.RegisterToggle(this);
            this.SetState(this.state);
        }

        public virtual void OnPointerEnter(PointerEventData eventData)
        {
            this.isInside = true;
            if (this.state == UIStates.Disable)
            {
                return;
            }
            this.State = this.isOn ? UIStates.SelectedHover : UIStates.Hover;
        }

        public virtual void OnPointerExit(PointerEventData eventData)
        {
            this.isInside = false;
            if (this.state == UIStates.Disable)
            {
                return;
            }
            this.State = this.isOn ? UIStates.Selected : UIStates.Default;
        }

        public virtual void OnPointerDown(PointerEventData eventData)
        {
            if (this.isDragging)
            {
                return;
            }
            if (this.state == UIStates.Disable)
            {
                return;
            }
            this.isPressed = true;
            this.State = this.isOn ? UIStates.SelectedPress : UIStates.Press;
        }

        public virtual void OnPointerUp(PointerEventData eventData)
        {
            if (this.isDragging || !this.isInside)
            {
                return;
            }
            if (this.state == UIStates.Disable)
            {
                return;
            }
            this.isPressed = false;
            this.State = this.isOn ? UIStates.SelectedHover : UIStates.Hover;
        }

        public virtual void OnPointerClick(PointerEventData eventData)
        {
            if (this.state == UIStates.Disable)
            {
                return;
            }
            if (this.isInside && !this.isDragging)
            {
                var previous = this.isOn;

                this.isOn = !this.isOn;
                this.State = this.isOn ? UIStates.SelectedHover : UIStates.Hover;
                this.toggleGroup?.NotifyToggle(this);

                if (!previous && this.isOn)
                {
                    this.SetState(UIStates.IsOnChangedTrue);
                }
                else if (previous && !this.isOn)
                {
                    this.SetState(UIStates.IsOnChangedFalse);
                }

                OnValueChangedEvent?.Invoke(this.isOn);
                OnToggleChangedEvent?.Invoke(this);
            }
        }

        public virtual void OnBeginDrag(PointerEventData eventData)
        {
            this.isDragging = true;
        }

        public virtual void OnEndDrag(PointerEventData eventData)
        {
            this.isDragging = false;
        }
    }
}