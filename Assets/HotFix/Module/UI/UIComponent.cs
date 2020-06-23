using ETModel;
using System.Collections.Generic;
using UnityEngine;

namespace ETHotfix
{
    [ObjectSystem]
    public class UIComponentAwakeSystem : AwakeSystem<UIComponent>
    {
        public override void Awake(UIComponent self)
        {
            self.Awake();
        }
    }

    /// <summary>
    /// 管理所有UI
    /// </summary>
    public class UIComponent : Component
    {
        public Camera Camera;

        private Dictionary<string, GameObject> layers = new Dictionary<string, GameObject>();
        private Dictionary<string, string> hierarchys = new Dictionary<string, string>();
        private Dictionary<string, UI> uis = new Dictionary<string, UI>();
        private Dictionary<string, Dictionary<string, IEvent>> uiActions = new Dictionary<string, Dictionary<string, IEvent>>();

        public void Awake()
        {
            GenerateLayers();

            Camera = ETModel.Game.Scene.GetComponent<ETModel.UIComponent>().Camera;
        }

        public async ETTask<UI> InstantiateAsync(string uiName, string hierarchy)
        {
            GameObject go = await UnityEngine.AddressableAssets.Addressables.InstantiateAsync(uiName, this.layers[hierarchy].transform, false, true).Task;

            go.name = uiName;

            Canvas canvas = go.GetComponent<Canvas>();
            canvas.worldCamera = this.Camera;
            canvas.sortingOrder = this.layers[hierarchy].transform.GetSiblingIndex();

            this.hierarchys.Add(uiName, hierarchy);

            UI ui = ComponentFactory.CreateWithParent<UI, string, GameObject>(this, uiName, go, false);
            this.uis.Add(uiName, ui);

            return ui;
        }

        public void Remove(string uiName)
        {
            if (!this.uis.TryGetValue(uiName, out UI ui))
            {
                return;
            }
            this.uis.Remove(uiName);
            ui.Dispose();
        }

        public UI Get(string name)
        {
            this.uis.TryGetValue(name, out UI ui);
            return ui;
        }

        public T Get<T>(string name) where T : Component
        {
            this.uis.TryGetValue(name, out UI ui);
            return ui?.GetComponent<T>();
        }

        public void ResetHierarchy(string name)
        {
            Get(name).GameObject.transform.SetParent(this.layers[this.hierarchys[name]].transform, false);
        }

        public void UpdateHierarchy(string name, string layer)
        {
            Get(name).GameObject.transform.SetParent(this.layers[layer].transform, false);
        }

        #region 初始化

        /// <summary>
        /// 创建UI层级
        /// </summary>
        private void GenerateLayers()
        {
            layers[HierarchyNames.HIDDEN] = new GameObject(HierarchyNames.HIDDEN);
            layers[HierarchyNames.HIDDEN].transform.SetParent(GameObject.transform);
            layers[HierarchyNames.HIDDEN].layer = LayerNames.GetLayerInt(LayerNames.HIDDEN);
            layers[HierarchyNames.HIDDEN].SetActive(false);

            layers[HierarchyNames.BOTTOM] = new GameObject(HierarchyNames.BOTTOM);
            layers[HierarchyNames.BOTTOM].transform.SetParent(GameObject.transform);
            layers[HierarchyNames.BOTTOM].layer = LayerNames.GetLayerInt(LayerNames.UI);

            layers[HierarchyNames.MEDIUM] = new GameObject(HierarchyNames.MEDIUM);
            layers[HierarchyNames.MEDIUM].transform.SetParent(GameObject.transform);
            layers[HierarchyNames.MEDIUM].layer = LayerNames.GetLayerInt(LayerNames.UI);

            layers[HierarchyNames.TOP] = new GameObject(HierarchyNames.TOP);
            layers[HierarchyNames.TOP].transform.SetParent(GameObject.transform);
            layers[HierarchyNames.TOP].layer = LayerNames.GetLayerInt(LayerNames.UI);

            layers[HierarchyNames.TOPMOST] = new GameObject(HierarchyNames.TOPMOST);
            layers[HierarchyNames.TOPMOST].transform.SetParent(GameObject.transform);
            layers[HierarchyNames.TOPMOST].layer = LayerNames.GetLayerInt(LayerNames.UI);
        }

        #endregion 初始化
    }
}