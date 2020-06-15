using UnityEngine.EventSystems;

namespace ETModel
{
    /// <summary>
    /// 可拖拽对象
    /// </summary>
    public class UIDraggable : UIBehaviour
        , IInitializePotentialDragHandler
        , IBeginDragHandler
        , IDragHandler
        , IEndDragHandler
    {
        #region 公开字段

        public UnityEngine.Vector2 ClampSize = new UnityEngine.Vector2(1920, 1080);

        #endregion 公开字段

        #region 私有对象

        private UnityEngine.RectTransform self;
        private UnityEngine.Vector2 offsetPosition;
        private UnityEngine.Vector2 currentPosition;

        #endregion 私有对象

        protected override void Awake()
        {
            base.Awake();
            this.self = GetComponent<UnityEngine.RectTransform>();
        }

        public void OnInitializePotentialDrag(PointerEventData eventData)
        {
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            this.offsetPosition = eventData.position - this.self.anchoredPosition;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (UnityEngine.Input.touchSupported && UnityEngine.Input.touchCount > 1)
            {
                return;
            }
            this.currentPosition = eventData.position - this.offsetPosition;
            this.currentPosition.x = UnityEngine.Mathf.Clamp(currentPosition.x, -ClampSize.x * 0.5f + this.self.rect.size.x * 0.5f, ClampSize.x * 0.5f - this.self.rect.size.x * 0.5f);
            this.currentPosition.y = UnityEngine.Mathf.Clamp(currentPosition.y, -ClampSize.y * 0.5f + this.self.rect.size.y * 0.5f, ClampSize.y * 0.5f - this.self.rect.size.y * 0.5f);
            self.anchoredPosition = currentPosition;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
        }
    }
}