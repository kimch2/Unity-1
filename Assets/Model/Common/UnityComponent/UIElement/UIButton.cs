using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ETModel
{
    public class UIButton : UIBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IBeginDragHandler, IEndDragHandler
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
                this.SetState(this.state = value);
            }
        }

        public static long DoubleClickInterval { get; } = 400;

        public event Action OnClickedEvent;

        public event Action OnDoubleClickedEvent;

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

        /// <summary>
        /// 上一次点击时间
        /// </summary>
        protected float previousClickedTime;

        /// <summary>
        /// 当前点击时间
        /// </summary>
        protected float currentClickedTime;

        /// <summary>
        /// 鼠标按下时间
        /// </summary>
        protected float pressedTime;

        private ETCancellationTokenSource cancellationTokenSource;

        protected override void Awake()
        {
            base.Awake();
            this.SetState(this.state);
        }

        public virtual void OnPointerEnter(PointerEventData eventData)
        {
            if (this.state == UIStates.Disable)
            {
                this.isPressed = false;
                return;
            }
            this.isInside = true;
            this.State = UIStates.Hover;
        }

        public virtual void OnPointerExit(PointerEventData eventData)
        {
            if (this.state == UIStates.Disable)
            {
                this.isPressed = false;
                return;
            }
            this.isInside = false;
            this.isPressed = false;
            this.pressedTime = 0;
            this.State = UIStates.Default;
        }

        public virtual void OnPointerDown(PointerEventData eventData)
        {
            if (this.isDragging)
            {
                this.isPressed = false;
                return;
            }
            if (this.state == UIStates.Disable)
            {
                this.isPressed = false;
                return;
            }
            this.isPressed = true;
            this.pressedTime = Time.timeSinceLevelLoad;
            this.State = UIStates.Press;
        }

        public virtual void OnPointerUp(PointerEventData eventData)
        {
            if (this.isDragging || !this.isInside)
            {
                this.isPressed = false;
                return;
            }
            if (this.state == UIStates.Disable)
            {
                this.isPressed = false;
                return;
            }
            this.isPressed = false;
            this.pressedTime = 0;
            this.State = UIStates.Hover;
        }

        public virtual void OnPointerClick(PointerEventData eventData)
        {
            if (this.state == UIStates.Disable)
            {
                return;
            }
            if (this.isInside && !this.isDragging)
            {
                this.currentClickedTime = Time.realtimeSinceStartup;
                if (this.currentClickedTime - this.previousClickedTime < DoubleClickInterval * 0.001f)
                {
                    if (this.OnDoubleClickedEvent != null)
                    {
                        this.cancellationTokenSource?.Cancel();
                        this.cancellationTokenSource = null;
                        OnDoubleClickedEvent.Invoke();
                    }
                }
                else
                {
                    if (this.OnClickedEvent != null)
                    {
                        if (OnDoubleClickedEvent == null)
                        {
                            OnClickedEvent.Invoke();
                        }
                        else
                        {
                            OnClickedEventInvokeAsync().Coroutine();
                        }
                    }
                }
                this.previousClickedTime = this.currentClickedTime;
            }
        }

        private async ETVoid OnClickedEventInvokeAsync()
        {
            this.cancellationTokenSource = ComponentFactory.Create<ETCancellationTokenSource>();
            await Game.Scene.GetComponent<TimerComponent>().WaitAsync(DoubleClickInterval);
            if (this.cancellationTokenSource != null && !this.cancellationTokenSource.CancellationTokenSource.IsCancellationRequested)
            {
                OnClickedEvent.Invoke();
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