using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ETModel
{
    public class UIToggleGroup : UIBehaviour
    {
        [SerializeField]
        private bool allowMultipleChecked = true;
        public bool AllowMultipleChecked
        {
            get => this.allowMultipleChecked;
            set
            {
                if (this.allowMultipleChecked == value)
                {
                    return;
                }
                this.allowMultipleChecked = value;
            }
        }

        [SerializeField]
        private float multipleCheckedCount = -1;
        public float MultipleCheckedCount
        {
            get => this.multipleCheckedCount;
            set
            {
                if (this.multipleCheckedCount == value)
                {
                    return;
                }
                this.multipleCheckedCount = value;
            }
        }

        [SerializeField]
        private bool allowSwitchOff = true;
        public bool AllowSwitchOff
        {
            get => this.allowSwitchOff;
            set
            {
                if (this.allowSwitchOff == value)
                {
                    return;
                }
                this.allowSwitchOff = value;
            }
        }

        public event Action<int[]> OnValuesChangedEvent;

        public event Action<List<UIToggle>> OnTogglesChangedEvent;

        private List<UIToggle> toggles = new List<UIToggle>();

        public List<UIToggle> Toggles => this.toggles;

        public void UnregisterToggle(UIToggle toggle)
        {
            if (this.toggles.Contains(toggle))
            {
                this.toggles.Remove(toggle);
            }
        }

        public void RegisterToggle(UIToggle toggle)
        {
            if (!this.toggles.Contains(toggle))
            {
                this.toggles.Add(toggle);
            }
        }

        public void NotifyToggle(UIToggle toggle)
        {
            if (this.allowMultipleChecked)
            {
                if (!this.allowSwitchOff && this.ActiveToggles().Count() < 1)
                {
                    toggle.IsOn = true;
                }

                if (this.multipleCheckedCount > 0)
                {
                    if (this.ActiveToggles().Count() >= this.multipleCheckedCount)
                    {
                        foreach (var item in this.toggles.Where(p => !p.IsOn))
                        {
                            item.State = UIStates.Disable;
                        }
                    }
                    else
                    {
                        foreach (var item in this.toggles.Where(p => p.State == UIStates.Disable))
                        {
                            item.State = item.PreviousState;
                        }
                    }
                }
            }
            else
            {
                if (this.ActiveToggles().Count() > 1)
                {
                    this.ActiveToggles().First(p => p != toggle).IsOn = false;
                }
                if (!this.allowSwitchOff && !toggle.IsOn)
                {
                    toggle.IsOn = true;
                }
            }

            OnValuesChangedEvent?.Invoke(this.toggles.Select((item, index) => item.IsOn ? index : -1).Where(p => p > -1).ToArray());
            OnTogglesChangedEvent?.Invoke(this.toggles.Where(p => p.IsOn).ToList());
        }

        public IEnumerable<UIToggle> ActiveToggles()
        {
            return this.toggles.Where(p => p.IsOn);
        }
        public bool AnyTogglesOn()
        {
            return this.toggles.Any(p => p.IsOn);
        }

        public void SetAllTogglesOff()
        {
            this.toggles.ForEach(p =>
            {
                p.State = UIStates.Default;
                p.IsOn = false;
            });
        }
    }
}