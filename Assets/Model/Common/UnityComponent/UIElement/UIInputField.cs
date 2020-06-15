using UnityEngine;
using UnityEngine.EventSystems;

namespace ETModel
{
    public class InputFieldStates
    {
        public const string EndEdit = "EndEdit";
        public const string Submit = "Submit";
        public const string Select = "Select";
        public const string Deselect = "Deselect";
        public const string TouchScreenKeyboardStatusChanged = "TouchScreenKeyboardStatusChanged";
        public const string ValueChanged = "ValueChanged";
        public const string EndTextSelection = "EndTextSelection";
        public const string TextSelection = "TextSelection";
    }

    [RequireComponent(typeof(TMPro.TMP_InputField))]
    public class UIInputField : UIBehaviour
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

        private TMPro.TMP_InputField inputField;
        public TMPro.TMP_InputField InputField => this.inputField;

        public TouchScreenKeyboard.Status Status { get; private set; }

        public string Value => this.inputField.text;

        protected override void Awake()
        {
            base.Awake();
            this.inputField = GetComponent<TMPro.TMP_InputField>();

            this.inputField.onEndEdit.AddListener(value => this.State = InputFieldStates.EndEdit);
            this.inputField.onSubmit.AddListener(value => this.State = InputFieldStates.Submit);
            this.inputField.onSelect.AddListener(value => this.State = InputFieldStates.Select);
            this.inputField.onDeselect.AddListener(value => this.State = InputFieldStates.Deselect);
            this.inputField.onTouchScreenKeyboardStatusChanged.AddListener(state =>
            {
                this.Status = state;
                this.State = InputFieldStates.TouchScreenKeyboardStatusChanged;
            });
            this.inputField.onValueChanged.AddListener(value => this.State = InputFieldStates.ValueChanged);
            this.inputField.onEndTextSelection.AddListener((value, start, end) => this.State = InputFieldStates.EndTextSelection);
            this.inputField.onTextSelection.AddListener((value, start, end) => this.State = InputFieldStates.EndTextSelection);

            this.SetState(this.state);
        }
    }
}