using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ETModel
{
    [ExecuteAlways]
    public class UIMaterialIcon : UIBehaviour
    {
        [SerializeField]
        private string icon = string.Empty;
        public string Icon
        {
            get => this.icon;
            set
            {
                if (this.icon == value)
                {
                    return;
                }
                this.icon = value;
                this.iconTMPU.text = Decode(this.icon);
                this.iconTMPU.SetVerticesDirty();
            }
        }

        [SerializeField]
        [Range(0, 128)]
        private float size = 16;
        public float Size
        {
            get => this.size;
            set
            {
                if (this.size == value)
                {
                    return;
                }

                this.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, this.size);
                this.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, this.size);
                this.iconTMPU.fontSize = this.size;
                this.iconTMPU.SetVerticesDirty();
                this.iconTMPU.SetLayoutDirty();
            }
        }

        [SerializeField]
        private Color color = Color.white;
        public Color Color
        {
            get => this.color;
            set
            {
                if (this.color == value)
                {
                    return;
                }
                this.color = value;
                this.iconTMPU.color = this.color;
                this.iconTMPU.SetVerticesDirty();
            }
        }

        [SerializeField]
        private bool raycastTarget = false;
        public bool RaycastTarget
        {
            get => this.raycastTarget;
            set
            {
                if (this.raycastTarget == value)
                {
                    return;
                }
                this.iconTMPU.raycastTarget = this.raycastTarget;
            }
        }

        [SerializeField]
        private TMP_FontAsset font;
        public TMP_FontAsset Font
        {
            get => this.font;
            set
            {
                if (this.font == value)
                {
                    return;
                }
                this.font = value;
                this.iconTMPU.font = this.font;
                this.iconTMPU.material = this.font.material;
                this.iconTMPU.SetVerticesDirty();
                this.iconTMPU.SetLayoutDirty();
            }
        }

        private RectTransform rectTransform;

        private TextMeshProUGUI m_iconTMPU;
        private TextMeshProUGUI iconTMPU
        {
            get
            {
                if (m_iconTMPU == null)
                {
                    m_iconTMPU = GetComponent<TextMeshProUGUI>() ?? gameObject.AddComponent<TMPro.TextMeshProUGUI>();
                }
                return m_iconTMPU;
            }
        }

        protected override void Awake()
        {
            base.Awake();

            this.rectTransform = GetComponent<RectTransform>();

#if UNITY_EDITOR
            this.iconTMPU.hideFlags = HideFlags.HideInInspector;
#endif

            this.iconTMPU.alignment = TextAlignmentOptions.Center;

#if UNITY_EDITOR
            this.font = UnityEditor.AssetDatabase.LoadAssetAtPath<TMP_FontAsset>("Assets/AddressableAssets/Icons/Material Icons.asset");
#else
            //this.font = Game.Scene.GetComponent<PreloadComponent>().MaterialIconsTMPFontAsset;
#endif

            this.iconTMPU.font = this.font;
            this.iconTMPU.material = this.font.material;

            this.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, this.size);
            this.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, this.size);
            this.iconTMPU.fontSize = this.size;

            this.iconTMPU.color = this.color;

            this.iconTMPU.raycastTarget = this.raycastTarget;

            this.iconTMPU.SetAllDirty();
        }

#if UNITY_EDITOR
        protected override void OnValidate()
        {
            base.OnValidate();

            if (this.font == null)
            {
                this.font = UnityEditor.AssetDatabase.LoadAssetAtPath<TMP_FontAsset>("Assets/AddressableAssets/Icons/Material Icons.asset");
            }
            if (this.rectTransform == null)
            {
                this.rectTransform = GetComponent<RectTransform>();
            }

            this.iconTMPU.font = this.font;
            this.iconTMPU.material = this.font.material;

            this.iconTMPU.text = Decode(this.icon);

            this.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, this.size);
            this.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, this.size);
            this.iconTMPU.fontSize = this.size;

            this.iconTMPU.raycastTarget = this.raycastTarget;

            this.iconTMPU.color = this.color;

            this.iconTMPU.font = this.font;
        }
#endif

        private string Decode(string input)
        {
            if (input.Length == 4 && int.TryParse(this.icon, NumberStyles.HexNumber, null, out int index))
            {
                return ((char)index).ToString();
            }
            return string.Empty;
        }
    }
}