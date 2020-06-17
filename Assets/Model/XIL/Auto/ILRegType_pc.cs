#if USE_HOT && UNITY_STANDALONE_WIN
namespace AutoIL
{
    using ILRuntime.Runtime.Enviorment;

    static class ILRegType
    {
        static public void RegisterFunctionDelegate(AppDomain appdomain)
        {
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Component, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Component, UnityEngine.Component, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.UICharInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.UICharInfo, UnityEngine.UICharInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.UILineInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.UILineInfo, UnityEngine.UILineInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.UIVertex, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.UIVertex, UnityEngine.UIVertex, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Single, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Single, System.Single, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Vector4, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Vector4, UnityEngine.Vector4, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Matrix4x4, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Matrix4x4, UnityEngine.Matrix4x4, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Vector3, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Vector3, UnityEngine.Vector3, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Color, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Color, UnityEngine.Color, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Color32, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Color32, UnityEngine.Color32, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Vector2, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Vector2, UnityEngine.Vector2, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Int32, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Int32, System.Int32, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.BoneWeight, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.BoneWeight, UnityEngine.BoneWeight, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Object>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.GameObject, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.GameObject, UnityEngine.GameObject, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.EventSystems.RaycastResult, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.EventSystems.RaycastResult, UnityEngine.EventSystems.RaycastResult, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.EventSystems.EventTrigger.Entry, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.EventSystems.EventTrigger.Entry, UnityEngine.EventSystems.EventTrigger.Entry, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Rect, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Rect, UnityEngine.Rect, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.AnimatorClipInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.AnimatorClipInfo, UnityEngine.AnimatorClipInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.UI.Selectable, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.UI.Selectable, UnityEngine.UI.Selectable, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.UI.Dropdown.OptionData, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.UI.Dropdown.OptionData, UnityEngine.UI.Dropdown.OptionData, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.String, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.String, System.String, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Sprite, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Sprite, UnityEngine.Sprite, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.String, System.Int32, System.Char, System.Char>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.UI.RectMask2D, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.UI.RectMask2D, UnityEngine.UI.RectMask2D, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.UI.ILayoutElement, System.Single>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Rendering.ReflectionProbeBlendInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Rendering.ReflectionProbeBlendInfo, UnityEngine.Rendering.ReflectionProbeBlendInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<PF.GraphNode, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<PF.GraphNode, PF.GraphNode, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Threading.Tasks.Task>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Exception, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Object, System.Threading.Tasks.Task>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.IAsyncResult, System.Threading.Tasks.Task>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Threading.Tasks.Task[], System.Threading.Tasks.Task>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Threading.Tasks.Task, System.Threading.Tasks.Task>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Object, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.IAsyncResult, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Threading.Tasks.Task[], System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Threading.Tasks.Task, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Object, System.Object>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.IAsyncResult, System.Object>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Threading.Tasks.Task[], System.Object>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Threading.Tasks.Task, System.Object>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.String>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Object, System.String>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.IAsyncResult, System.String>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Threading.Tasks.Task[], System.String>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Threading.Tasks.Task, System.String>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Object, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.IAsyncResult, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Threading.Tasks.Task[], System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Threading.Tasks.Task, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Xml.XmlNodeType>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Object, System.Xml.XmlNodeType>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.IAsyncResult, System.Xml.XmlNodeType>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Threading.Tasks.Task[], System.Xml.XmlNodeType>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Threading.Tasks.Task, System.Xml.XmlNodeType>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.UI.MaskableGraphic, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.UI.MaskableGraphic, UnityEngine.UI.MaskableGraphic, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Transform, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Transform, UnityEngine.Transform, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UIToggleOrdin, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UIToggleOrdin, UIToggleOrdin, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UIChangeItemBase, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UIChangeItemBase, UIChangeItemBase, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.TextCore.Glyph, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.TextCore.Glyph, UnityEngine.TextCore.Glyph, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<TMPro.TMP_Character, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<TMPro.TMP_Character, TMPro.TMP_Character, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<TMPro.TMP_FontAsset, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<TMPro.TMP_FontAsset, TMPro.TMP_FontAsset, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<TMPro.TMP_SpriteCharacter, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<TMPro.TMP_SpriteCharacter, TMPro.TMP_SpriteCharacter, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<TMPro.TMP_SpriteGlyph, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<TMPro.TMP_SpriteGlyph, TMPro.TMP_SpriteGlyph, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<TMPro.TMP_Sprite, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<TMPro.TMP_Sprite, TMPro.TMP_Sprite, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<TMPro.TMP_SpriteAsset, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<TMPro.TMP_SpriteAsset, TMPro.TMP_SpriteAsset, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.RectTransform, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.RectTransform, UnityEngine.RectTransform, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ReferenceCollectorData, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ReferenceCollectorData, ReferenceCollectorData, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.IO.Stream>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Object, System.IO.Stream>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.IAsyncResult, System.IO.Stream>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Threading.Tasks.Task[], System.IO.Stream>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Threading.Tasks.Task, System.IO.Stream>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Object, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Object, UnityEngine.Object, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Type, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Type, System.Type, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<PF.Int3, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<PF.Int3, PF.Int3, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<PF.Funnel.PathPart, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<PF.Funnel.PathPart, PF.Funnel.PathPart, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Object, System.Object, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ETModel.ComponentInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ETModel.ComponentInfo, ETModel.ComponentInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ETModel.BaseConfig, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ETModel.BaseConfig, ETModel.BaseConfig, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ETModel.CharacterBaseData, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ETModel.CharacterBaseData, ETModel.CharacterBaseData, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ETModel.SkillDataBase, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ETModel.SkillDataBase, ETModel.SkillDataBase, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ETModel.UIToggle, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ETModel.UIToggle, ETModel.UIToggle, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ETModel.Entity, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ETModel.Entity, ETModel.Entity, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.IntPtr, System.Int32, System.IntPtr, System.IntPtr, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Int64, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Net.WebSockets.WebSocketReceiveResult>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Object, System.Net.WebSockets.WebSocketReceiveResult>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.IAsyncResult, System.Net.WebSockets.WebSocketReceiveResult>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Threading.Tasks.Task[], System.Net.WebSockets.WebSocketReceiveResult>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Threading.Tasks.Task, System.Net.WebSockets.WebSocketReceiveResult>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ETModel.C2M_TestRequest>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Byte, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Byte, System.Byte, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ETModel.M2C_TestResponse>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ETModel.Actor_TransferRequest>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ETModel.Actor_TransferResponse>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ETModel.C2G_EnterMap>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ETModel.G2C_EnterMap>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ETModel.UnitInfo>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ETModel.M2C_CreateUnits>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ETModel.Frame_ClickMap>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ETModel.C2R_Ping>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ETModel.R2C_Ping>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ETModel.G2C_Test>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ETModel.C2M_Reload>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ETModel.M2C_Reload>();
            appdomain.DelegateManager.RegisterFunctionDelegate<DG.Tweening.Tween, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<DG.Tweening.Tween, DG.Tweening.Tween, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UIButtonOrdin, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UIButtonOrdin, UIButtonOrdin, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ETModel.AppType, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ETModel.AppType, ETModel.AppType, System.Int32>();

        }

        static public void RegisterDelegateConvertor(AppDomain appdomain)
        {
            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.Component>>((act) =>
            {
                return new System.Predicate<UnityEngine.Component>((obj) =>
                {
                    return ((System.Func<UnityEngine.Component, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.Component>>((act) =>
            {
                return new System.Comparison<UnityEngine.Component>((x, y) =>
                {
                    return ((System.Func<UnityEngine.Component, UnityEngine.Component, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.Events.UnityAction>((act) =>
            {
                return new UnityEngine.Events.UnityAction(() =>
                {
                    ((System.Action)act)();
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.Font.FontTextureRebuildCallback>((act) =>
            {
                return new UnityEngine.Font.FontTextureRebuildCallback(() =>
                {
                    ((System.Action)act)();
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.Canvas.WillRenderCanvases>((act) =>
            {
                return new UnityEngine.Canvas.WillRenderCanvases(() =>
                {
                    ((System.Action)act)();
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Action>((act) =>
            {
                return new System.Action(() =>
                {
                    ((System.Action)act)();
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<Microsoft.IO.RecyclableMemoryStreamManager.EventHandler>((act) =>
            {
                return new Microsoft.IO.RecyclableMemoryStreamManager.EventHandler(() =>
                {
                    ((System.Action)act)();
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<DG.Tweening.TweenCallback>((act) =>
            {
                return new DG.Tweening.TweenCallback(() =>
                {
                    ((System.Action)act)();
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<ETModel.UIWindow.OpenVoid>((act) =>
            {
                return new ETModel.UIWindow.OpenVoid(() =>
                {
                    ((System.Action)act)();
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<ETModel.UIWindow.CloseVoid>((act) =>
            {
                return new ETModel.UIWindow.CloseVoid(() =>
                {
                    ((System.Action)act)();
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.UICharInfo>>((act) =>
            {
                return new System.Predicate<UnityEngine.UICharInfo>((obj) =>
                {
                    return ((System.Func<UnityEngine.UICharInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.UICharInfo>>((act) =>
            {
                return new System.Comparison<UnityEngine.UICharInfo>((x, y) =>
                {
                    return ((System.Func<UnityEngine.UICharInfo, UnityEngine.UICharInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.UILineInfo>>((act) =>
            {
                return new System.Predicate<UnityEngine.UILineInfo>((obj) =>
                {
                    return ((System.Func<UnityEngine.UILineInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.UILineInfo>>((act) =>
            {
                return new System.Comparison<UnityEngine.UILineInfo>((x, y) =>
                {
                    return ((System.Func<UnityEngine.UILineInfo, UnityEngine.UILineInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.UIVertex>>((act) =>
            {
                return new System.Predicate<UnityEngine.UIVertex>((obj) =>
                {
                    return ((System.Func<UnityEngine.UIVertex, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.UIVertex>>((act) =>
            {
                return new System.Comparison<UnityEngine.UIVertex>((x, y) =>
                {
                    return ((System.Func<UnityEngine.UIVertex, UnityEngine.UIVertex, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.Events.UnityAction<System.Boolean>>((act) =>
            {
                return new UnityEngine.Events.UnityAction<System.Boolean>((arg0) =>
                {
                    ((System.Action<System.Boolean>)act)(arg0);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.RectTransform.ReapplyDrivenProperties>((act) =>
            {
                return new UnityEngine.RectTransform.ReapplyDrivenProperties((driven) =>
                {
                    ((System.Action<UnityEngine.RectTransform>)act)(driven);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<System.Single>>((act) =>
            {
                return new System.Predicate<System.Single>((obj) =>
                {
                    return ((System.Func<System.Single, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.Events.UnityAction<System.Single>>((act) =>
            {
                return new UnityEngine.Events.UnityAction<System.Single>((arg0) =>
                {
                    ((System.Action<System.Single>)act)(arg0);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<System.Single>>((act) =>
            {
                return new System.Comparison<System.Single>((x, y) =>
                {
                    return ((System.Func<System.Single, System.Single, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.Vector4>>((act) =>
            {
                return new System.Predicate<UnityEngine.Vector4>((obj) =>
                {
                    return ((System.Func<UnityEngine.Vector4, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.Vector4>>((act) =>
            {
                return new System.Comparison<UnityEngine.Vector4>((x, y) =>
                {
                    return ((System.Func<UnityEngine.Vector4, UnityEngine.Vector4, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.Matrix4x4>>((act) =>
            {
                return new System.Predicate<UnityEngine.Matrix4x4>((obj) =>
                {
                    return ((System.Func<UnityEngine.Matrix4x4, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.Matrix4x4>>((act) =>
            {
                return new System.Comparison<UnityEngine.Matrix4x4>((x, y) =>
                {
                    return ((System.Func<UnityEngine.Matrix4x4, UnityEngine.Matrix4x4, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.Camera.CameraCallback>((act) =>
            {
                return new UnityEngine.Camera.CameraCallback((cam) =>
                {
                    ((System.Action<UnityEngine.Camera>)act)(cam);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.Vector3>>((act) =>
            {
                return new System.Predicate<UnityEngine.Vector3>((obj) =>
                {
                    return ((System.Func<UnityEngine.Vector3, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.Vector3>>((act) =>
            {
                return new System.Comparison<UnityEngine.Vector3>((x, y) =>
                {
                    return ((System.Func<UnityEngine.Vector3, UnityEngine.Vector3, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.Color>>((act) =>
            {
                return new System.Predicate<UnityEngine.Color>((obj) =>
                {
                    return ((System.Func<UnityEngine.Color, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.Color>>((act) =>
            {
                return new System.Comparison<UnityEngine.Color>((x, y) =>
                {
                    return ((System.Func<UnityEngine.Color, UnityEngine.Color, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.Color32>>((act) =>
            {
                return new System.Predicate<UnityEngine.Color32>((obj) =>
                {
                    return ((System.Func<UnityEngine.Color32, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.Color32>>((act) =>
            {
                return new System.Comparison<UnityEngine.Color32>((x, y) =>
                {
                    return ((System.Func<UnityEngine.Color32, UnityEngine.Color32, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.Vector2>>((act) =>
            {
                return new System.Predicate<UnityEngine.Vector2>((obj) =>
                {
                    return ((System.Func<UnityEngine.Vector2, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.Events.UnityAction<UnityEngine.Vector2>>((act) =>
            {
                return new UnityEngine.Events.UnityAction<UnityEngine.Vector2>((arg0) =>
                {
                    ((System.Action<UnityEngine.Vector2>)act)(arg0);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.Vector2>>((act) =>
            {
                return new System.Comparison<UnityEngine.Vector2>((x, y) =>
                {
                    return ((System.Func<UnityEngine.Vector2, UnityEngine.Vector2, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<System.Int32>>((act) =>
            {
                return new System.Predicate<System.Int32>((obj) =>
                {
                    return ((System.Func<System.Int32, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.Events.UnityAction<System.Int32>>((act) =>
            {
                return new UnityEngine.Events.UnityAction<System.Int32>((arg0) =>
                {
                    ((System.Action<System.Int32>)act)(arg0);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<DG.Tweening.TweenCallback<System.Int32>>((act) =>
            {
                return new DG.Tweening.TweenCallback<System.Int32>((value) =>
                {
                    ((System.Action<System.Int32>)act)(value);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<ETModel.UINumberSelect.UINumberSelectEvent>((act) =>
            {
                return new ETModel.UINumberSelect.UINumberSelectEvent((number) =>
                {
                    ((System.Action<System.Int32>)act)(number);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<System.Int32>>((act) =>
            {
                return new System.Comparison<System.Int32>((x, y) =>
                {
                    return ((System.Func<System.Int32, System.Int32, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.BoneWeight>>((act) =>
            {
                return new System.Predicate<UnityEngine.BoneWeight>((obj) =>
                {
                    return ((System.Func<UnityEngine.BoneWeight, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.BoneWeight>>((act) =>
            {
                return new System.Comparison<UnityEngine.BoneWeight>((x, y) =>
                {
                    return ((System.Func<UnityEngine.BoneWeight, UnityEngine.BoneWeight, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.GameObject>>((act) =>
            {
                return new System.Predicate<UnityEngine.GameObject>((obj) =>
                {
                    return ((System.Func<UnityEngine.GameObject, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.GameObject>>((act) =>
            {
                return new System.Comparison<UnityEngine.GameObject>((x, y) =>
                {
                    return ((System.Func<UnityEngine.GameObject, UnityEngine.GameObject, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.EventSystems.RaycastResult>>((act) =>
            {
                return new System.Predicate<UnityEngine.EventSystems.RaycastResult>((obj) =>
                {
                    return ((System.Func<UnityEngine.EventSystems.RaycastResult, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.EventSystems.RaycastResult>>((act) =>
            {
                return new System.Comparison<UnityEngine.EventSystems.RaycastResult>((x, y) =>
                {
                    return ((System.Func<UnityEngine.EventSystems.RaycastResult, UnityEngine.EventSystems.RaycastResult, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.EventSystems.EventTrigger.Entry>>((act) =>
            {
                return new System.Predicate<UnityEngine.EventSystems.EventTrigger.Entry>((obj) =>
                {
                    return ((System.Func<UnityEngine.EventSystems.EventTrigger.Entry, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.EventSystems.EventTrigger.Entry>>((act) =>
            {
                return new System.Comparison<UnityEngine.EventSystems.EventTrigger.Entry>((x, y) =>
                {
                    return ((System.Func<UnityEngine.EventSystems.EventTrigger.Entry, UnityEngine.EventSystems.EventTrigger.Entry, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.Events.UnityAction<UnityEngine.EventSystems.BaseEventData>>((act) =>
            {
                return new UnityEngine.Events.UnityAction<UnityEngine.EventSystems.BaseEventData>((arg0) =>
                {
                    ((System.Action<UnityEngine.EventSystems.BaseEventData>)act)(arg0);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IPointerEnterHandler>>((act) =>
            {
                return new UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IPointerEnterHandler>((handler, eventData) =>
                {
                    ((System.Action<UnityEngine.EventSystems.IPointerEnterHandler, UnityEngine.EventSystems.BaseEventData>)act)(handler, eventData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IPointerExitHandler>>((act) =>
            {
                return new UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IPointerExitHandler>((handler, eventData) =>
                {
                    ((System.Action<UnityEngine.EventSystems.IPointerExitHandler, UnityEngine.EventSystems.BaseEventData>)act)(handler, eventData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IPointerDownHandler>>((act) =>
            {
                return new UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IPointerDownHandler>((handler, eventData) =>
                {
                    ((System.Action<UnityEngine.EventSystems.IPointerDownHandler, UnityEngine.EventSystems.BaseEventData>)act)(handler, eventData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IPointerUpHandler>>((act) =>
            {
                return new UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IPointerUpHandler>((handler, eventData) =>
                {
                    ((System.Action<UnityEngine.EventSystems.IPointerUpHandler, UnityEngine.EventSystems.BaseEventData>)act)(handler, eventData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IPointerClickHandler>>((act) =>
            {
                return new UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IPointerClickHandler>((handler, eventData) =>
                {
                    ((System.Action<UnityEngine.EventSystems.IPointerClickHandler, UnityEngine.EventSystems.BaseEventData>)act)(handler, eventData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IInitializePotentialDragHandler>>((act) =>
            {
                return new UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IInitializePotentialDragHandler>((handler, eventData) =>
                {
                    ((System.Action<UnityEngine.EventSystems.IInitializePotentialDragHandler, UnityEngine.EventSystems.BaseEventData>)act)(handler, eventData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IBeginDragHandler>>((act) =>
            {
                return new UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IBeginDragHandler>((handler, eventData) =>
                {
                    ((System.Action<UnityEngine.EventSystems.IBeginDragHandler, UnityEngine.EventSystems.BaseEventData>)act)(handler, eventData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IDragHandler>>((act) =>
            {
                return new UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IDragHandler>((handler, eventData) =>
                {
                    ((System.Action<UnityEngine.EventSystems.IDragHandler, UnityEngine.EventSystems.BaseEventData>)act)(handler, eventData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IEndDragHandler>>((act) =>
            {
                return new UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IEndDragHandler>((handler, eventData) =>
                {
                    ((System.Action<UnityEngine.EventSystems.IEndDragHandler, UnityEngine.EventSystems.BaseEventData>)act)(handler, eventData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IDropHandler>>((act) =>
            {
                return new UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IDropHandler>((handler, eventData) =>
                {
                    ((System.Action<UnityEngine.EventSystems.IDropHandler, UnityEngine.EventSystems.BaseEventData>)act)(handler, eventData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IScrollHandler>>((act) =>
            {
                return new UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IScrollHandler>((handler, eventData) =>
                {
                    ((System.Action<UnityEngine.EventSystems.IScrollHandler, UnityEngine.EventSystems.BaseEventData>)act)(handler, eventData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IUpdateSelectedHandler>>((act) =>
            {
                return new UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IUpdateSelectedHandler>((handler, eventData) =>
                {
                    ((System.Action<UnityEngine.EventSystems.IUpdateSelectedHandler, UnityEngine.EventSystems.BaseEventData>)act)(handler, eventData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.ISelectHandler>>((act) =>
            {
                return new UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.ISelectHandler>((handler, eventData) =>
                {
                    ((System.Action<UnityEngine.EventSystems.ISelectHandler, UnityEngine.EventSystems.BaseEventData>)act)(handler, eventData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IDeselectHandler>>((act) =>
            {
                return new UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IDeselectHandler>((handler, eventData) =>
                {
                    ((System.Action<UnityEngine.EventSystems.IDeselectHandler, UnityEngine.EventSystems.BaseEventData>)act)(handler, eventData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IMoveHandler>>((act) =>
            {
                return new UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IMoveHandler>((handler, eventData) =>
                {
                    ((System.Action<UnityEngine.EventSystems.IMoveHandler, UnityEngine.EventSystems.BaseEventData>)act)(handler, eventData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.ISubmitHandler>>((act) =>
            {
                return new UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.ISubmitHandler>((handler, eventData) =>
                {
                    ((System.Action<UnityEngine.EventSystems.ISubmitHandler, UnityEngine.EventSystems.BaseEventData>)act)(handler, eventData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.ICancelHandler>>((act) =>
            {
                return new UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.ICancelHandler>((handler, eventData) =>
                {
                    ((System.Action<UnityEngine.EventSystems.ICancelHandler, UnityEngine.EventSystems.BaseEventData>)act)(handler, eventData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.Rect>>((act) =>
            {
                return new System.Predicate<UnityEngine.Rect>((obj) =>
                {
                    return ((System.Func<UnityEngine.Rect, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.Rect>>((act) =>
            {
                return new System.Comparison<UnityEngine.Rect>((x, y) =>
                {
                    return ((System.Func<UnityEngine.Rect, UnityEngine.Rect, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.AnimatorClipInfo>>((act) =>
            {
                return new System.Predicate<UnityEngine.AnimatorClipInfo>((obj) =>
                {
                    return ((System.Func<UnityEngine.AnimatorClipInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.AnimatorClipInfo>>((act) =>
            {
                return new System.Comparison<UnityEngine.AnimatorClipInfo>((x, y) =>
                {
                    return ((System.Func<UnityEngine.AnimatorClipInfo, UnityEngine.AnimatorClipInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.UI.Selectable>>((act) =>
            {
                return new System.Predicate<UnityEngine.UI.Selectable>((obj) =>
                {
                    return ((System.Func<UnityEngine.UI.Selectable, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.UI.Selectable>>((act) =>
            {
                return new System.Comparison<UnityEngine.UI.Selectable>((x, y) =>
                {
                    return ((System.Func<UnityEngine.UI.Selectable, UnityEngine.UI.Selectable, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.UI.Dropdown.OptionData>>((act) =>
            {
                return new System.Predicate<UnityEngine.UI.Dropdown.OptionData>((obj) =>
                {
                    return ((System.Func<UnityEngine.UI.Dropdown.OptionData, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.UI.Dropdown.OptionData>>((act) =>
            {
                return new System.Comparison<UnityEngine.UI.Dropdown.OptionData>((x, y) =>
                {
                    return ((System.Func<UnityEngine.UI.Dropdown.OptionData, UnityEngine.UI.Dropdown.OptionData, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<System.String>>((act) =>
            {
                return new System.Predicate<System.String>((obj) =>
                {
                    return ((System.Func<System.String, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.Events.UnityAction<System.String>>((act) =>
            {
                return new UnityEngine.Events.UnityAction<System.String>((arg0) =>
                {
                    ((System.Action<System.String>)act)(arg0);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<System.String>>((act) =>
            {
                return new System.Comparison<System.String>((x, y) =>
                {
                    return ((System.Func<System.String, System.String, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.Sprite>>((act) =>
            {
                return new System.Predicate<UnityEngine.Sprite>((obj) =>
                {
                    return ((System.Func<UnityEngine.Sprite, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.Sprite>>((act) =>
            {
                return new System.Comparison<UnityEngine.Sprite>((x, y) =>
                {
                    return ((System.Func<UnityEngine.Sprite, UnityEngine.Sprite, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.UI.InputField.OnValidateInput>((act) =>
            {
                return new UnityEngine.UI.InputField.OnValidateInput((text, charIndex, addedChar) =>
                {
                    return ((System.Func<System.String, System.Int32, System.Char, System.Char>)act)(text, charIndex, addedChar);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<TMPro.TMP_InputField.OnValidateInput>((act) =>
            {
                return new TMPro.TMP_InputField.OnValidateInput((text, charIndex, addedChar) =>
                {
                    return ((System.Func<System.String, System.Int32, System.Char, System.Char>)act)(text, charIndex, addedChar);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.UI.RectMask2D>>((act) =>
            {
                return new System.Predicate<UnityEngine.UI.RectMask2D>((obj) =>
                {
                    return ((System.Func<UnityEngine.UI.RectMask2D, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.UI.RectMask2D>>((act) =>
            {
                return new System.Comparison<UnityEngine.UI.RectMask2D>((x, y) =>
                {
                    return ((System.Func<UnityEngine.UI.RectMask2D, UnityEngine.UI.RectMask2D, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.Video.VideoPlayer.EventHandler>((act) =>
            {
                return new UnityEngine.Video.VideoPlayer.EventHandler((source) =>
                {
                    ((System.Action<UnityEngine.Video.VideoPlayer>)act)(source);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.Video.VideoPlayer.ErrorEventHandler>((act) =>
            {
                return new UnityEngine.Video.VideoPlayer.ErrorEventHandler((source, message) =>
                {
                    ((System.Action<UnityEngine.Video.VideoPlayer, System.String>)act)(source, message);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.Video.VideoPlayer.TimeEventHandler>((act) =>
            {
                return new UnityEngine.Video.VideoPlayer.TimeEventHandler((source, seconds) =>
                {
                    ((System.Action<UnityEngine.Video.VideoPlayer, System.Double>)act)(source, seconds);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.Video.VideoPlayer.FrameReadyEventHandler>((act) =>
            {
                return new UnityEngine.Video.VideoPlayer.FrameReadyEventHandler((source, frameIdx) =>
                {
                    ((System.Action<UnityEngine.Video.VideoPlayer, System.Int64>)act)(source, frameIdx);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.Rendering.ReflectionProbeBlendInfo>>((act) =>
            {
                return new System.Predicate<UnityEngine.Rendering.ReflectionProbeBlendInfo>((obj) =>
                {
                    return ((System.Func<UnityEngine.Rendering.ReflectionProbeBlendInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.Rendering.ReflectionProbeBlendInfo>>((act) =>
            {
                return new System.Comparison<UnityEngine.Rendering.ReflectionProbeBlendInfo>((x, y) =>
                {
                    return ((System.Func<UnityEngine.Rendering.ReflectionProbeBlendInfo, UnityEngine.Rendering.ReflectionProbeBlendInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<PF.GraphNode>>((act) =>
            {
                return new System.Predicate<PF.GraphNode>((obj) =>
                {
                    return ((System.Func<PF.GraphNode, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<PF.OnPathDelegate>((act) =>
            {
                return new PF.OnPathDelegate((p) =>
                {
                    ((System.Action<PF.Path>)act)(p);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<PF.GraphNode>>((act) =>
            {
                return new System.Comparison<PF.GraphNode>((x, y) =>
                {
                    return ((System.Func<PF.GraphNode, PF.GraphNode, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Threading.SendOrPostCallback>((act) =>
            {
                return new System.Threading.SendOrPostCallback((state) =>
                {
                    ((System.Action<System.Object>)act)(state);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.EventHandler<System.Threading.Tasks.UnobservedTaskExceptionEventArgs>>((act) =>
            {
                return new System.EventHandler<System.Threading.Tasks.UnobservedTaskExceptionEventArgs>((sender, e) =>
                {
                    ((System.Action<System.Object, System.Threading.Tasks.UnobservedTaskExceptionEventArgs>)act)(sender, e);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Xml.Schema.ValidationEventHandler>((act) =>
            {
                return new System.Xml.Schema.ValidationEventHandler((sender, e) =>
                {
                    ((System.Action<System.Object, System.Xml.Schema.ValidationEventArgs>)act)(sender, e);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Xml.XmlNodeChangedEventHandler>((act) =>
            {
                return new System.Xml.XmlNodeChangedEventHandler((sender, e) =>
                {
                    ((System.Action<System.Object, System.Xml.XmlNodeChangedEventArgs>)act)(sender, e);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<System.Object>>((act) =>
            {
                return new System.Predicate<System.Object>((obj) =>
                {
                    return ((System.Func<System.Object, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.UI.MaskableGraphic>>((act) =>
            {
                return new System.Predicate<UnityEngine.UI.MaskableGraphic>((obj) =>
                {
                    return ((System.Func<UnityEngine.UI.MaskableGraphic, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.UI.MaskableGraphic>>((act) =>
            {
                return new System.Comparison<UnityEngine.UI.MaskableGraphic>((x, y) =>
                {
                    return ((System.Func<UnityEngine.UI.MaskableGraphic, UnityEngine.UI.MaskableGraphic, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.Transform>>((act) =>
            {
                return new System.Predicate<UnityEngine.Transform>((obj) =>
                {
                    return ((System.Func<UnityEngine.Transform, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.Transform>>((act) =>
            {
                return new System.Comparison<UnityEngine.Transform>((x, y) =>
                {
                    return ((System.Func<UnityEngine.Transform, UnityEngine.Transform, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UIToggleOrdin>>((act) =>
            {
                return new System.Predicate<UIToggleOrdin>((obj) =>
                {
                    return ((System.Func<UIToggleOrdin, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UIToggleOrdin>>((act) =>
            {
                return new System.Comparison<UIToggleOrdin>((x, y) =>
                {
                    return ((System.Func<UIToggleOrdin, UIToggleOrdin, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UIChangeItemBase>>((act) =>
            {
                return new System.Predicate<UIChangeItemBase>((obj) =>
                {
                    return ((System.Func<UIChangeItemBase, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UIChangeItemBase>>((act) =>
            {
                return new System.Comparison<UIChangeItemBase>((x, y) =>
                {
                    return ((System.Func<UIChangeItemBase, UIChangeItemBase, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.TextCore.Glyph>>((act) =>
            {
                return new System.Predicate<UnityEngine.TextCore.Glyph>((obj) =>
                {
                    return ((System.Func<UnityEngine.TextCore.Glyph, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.TextCore.Glyph>>((act) =>
            {
                return new System.Comparison<UnityEngine.TextCore.Glyph>((x, y) =>
                {
                    return ((System.Func<UnityEngine.TextCore.Glyph, UnityEngine.TextCore.Glyph, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<TMPro.TMP_Character>>((act) =>
            {
                return new System.Predicate<TMPro.TMP_Character>((obj) =>
                {
                    return ((System.Func<TMPro.TMP_Character, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<TMPro.TMP_Character>>((act) =>
            {
                return new System.Comparison<TMPro.TMP_Character>((x, y) =>
                {
                    return ((System.Func<TMPro.TMP_Character, TMPro.TMP_Character, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<TMPro.TMP_FontAsset>>((act) =>
            {
                return new System.Predicate<TMPro.TMP_FontAsset>((obj) =>
                {
                    return ((System.Func<TMPro.TMP_FontAsset, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<TMPro.TMP_FontAsset>>((act) =>
            {
                return new System.Comparison<TMPro.TMP_FontAsset>((x, y) =>
                {
                    return ((System.Func<TMPro.TMP_FontAsset, TMPro.TMP_FontAsset, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<TMPro.TMP_SpriteCharacter>>((act) =>
            {
                return new System.Predicate<TMPro.TMP_SpriteCharacter>((obj) =>
                {
                    return ((System.Func<TMPro.TMP_SpriteCharacter, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<TMPro.TMP_SpriteCharacter>>((act) =>
            {
                return new System.Comparison<TMPro.TMP_SpriteCharacter>((x, y) =>
                {
                    return ((System.Func<TMPro.TMP_SpriteCharacter, TMPro.TMP_SpriteCharacter, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<TMPro.TMP_SpriteGlyph>>((act) =>
            {
                return new System.Predicate<TMPro.TMP_SpriteGlyph>((obj) =>
                {
                    return ((System.Func<TMPro.TMP_SpriteGlyph, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<TMPro.TMP_SpriteGlyph>>((act) =>
            {
                return new System.Comparison<TMPro.TMP_SpriteGlyph>((x, y) =>
                {
                    return ((System.Func<TMPro.TMP_SpriteGlyph, TMPro.TMP_SpriteGlyph, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<TMPro.TMP_Sprite>>((act) =>
            {
                return new System.Predicate<TMPro.TMP_Sprite>((obj) =>
                {
                    return ((System.Func<TMPro.TMP_Sprite, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<TMPro.TMP_Sprite>>((act) =>
            {
                return new System.Comparison<TMPro.TMP_Sprite>((x, y) =>
                {
                    return ((System.Func<TMPro.TMP_Sprite, TMPro.TMP_Sprite, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<TMPro.TMP_SpriteAsset>>((act) =>
            {
                return new System.Predicate<TMPro.TMP_SpriteAsset>((obj) =>
                {
                    return ((System.Func<TMPro.TMP_SpriteAsset, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<TMPro.TMP_SpriteAsset>>((act) =>
            {
                return new System.Comparison<TMPro.TMP_SpriteAsset>((x, y) =>
                {
                    return ((System.Func<TMPro.TMP_SpriteAsset, TMPro.TMP_SpriteAsset, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.RectTransform>>((act) =>
            {
                return new System.Predicate<UnityEngine.RectTransform>((obj) =>
                {
                    return ((System.Func<UnityEngine.RectTransform, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.RectTransform>>((act) =>
            {
                return new System.Comparison<UnityEngine.RectTransform>((x, y) =>
                {
                    return ((System.Func<UnityEngine.RectTransform, UnityEngine.RectTransform, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<ReferenceCollectorData>>((act) =>
            {
                return new System.Predicate<ReferenceCollectorData>((obj) =>
                {
                    return ((System.Func<ReferenceCollectorData, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<ReferenceCollectorData>>((act) =>
            {
                return new System.Comparison<ReferenceCollectorData>((x, y) =>
                {
                    return ((System.Func<ReferenceCollectorData, ReferenceCollectorData, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<ILRuntime.CLR.Method.IMethod>>((act) =>
            {
                return new System.Predicate<ILRuntime.CLR.Method.IMethod>((obj) =>
                {
                    return ((System.Func<ILRuntime.CLR.Method.IMethod, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<ILRuntime.CLR.Method.IMethod>>((act) =>
            {
                return new System.Comparison<ILRuntime.CLR.Method.IMethod>((x, y) =>
                {
                    return ((System.Func<ILRuntime.CLR.Method.IMethod, ILRuntime.CLR.Method.IMethod, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<ILRuntime.CLR.TypeSystem.IType>>((act) =>
            {
                return new System.Predicate<ILRuntime.CLR.TypeSystem.IType>((obj) =>
                {
                    return ((System.Func<ILRuntime.CLR.TypeSystem.IType, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<ILRuntime.CLR.TypeSystem.IType>>((act) =>
            {
                return new System.Comparison<ILRuntime.CLR.TypeSystem.IType>((x, y) =>
                {
                    return ((System.Func<ILRuntime.CLR.TypeSystem.IType, ILRuntime.CLR.TypeSystem.IType, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.Object>>((act) =>
            {
                return new System.Predicate<UnityEngine.Object>((obj) =>
                {
                    return ((System.Func<UnityEngine.Object, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.Object>>((act) =>
            {
                return new System.Comparison<UnityEngine.Object>((x, y) =>
                {
                    return ((System.Func<UnityEngine.Object, UnityEngine.Object, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<System.Type>>((act) =>
            {
                return new System.Predicate<System.Type>((obj) =>
                {
                    return ((System.Func<System.Type, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<System.Type>>((act) =>
            {
                return new System.Comparison<System.Type>((x, y) =>
                {
                    return ((System.Func<System.Type, System.Type, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<PF.Int3>>((act) =>
            {
                return new System.Predicate<PF.Int3>((obj) =>
                {
                    return ((System.Func<PF.Int3, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<PF.Int3>>((act) =>
            {
                return new System.Comparison<PF.Int3>((x, y) =>
                {
                    return ((System.Func<PF.Int3, PF.Int3, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<PF.Funnel.PathPart>>((act) =>
            {
                return new System.Predicate<PF.Funnel.PathPart>((obj) =>
                {
                    return ((System.Func<PF.Funnel.PathPart, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<PF.Funnel.PathPart>>((act) =>
            {
                return new System.Comparison<PF.Funnel.PathPart>((x, y) =>
                {
                    return ((System.Func<PF.Funnel.PathPart, PF.Funnel.PathPart, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<Microsoft.IO.RecyclableMemoryStreamManager.StreamLengthReportHandler>((act) =>
            {
                return new Microsoft.IO.RecyclableMemoryStreamManager.StreamLengthReportHandler((bytes) =>
                {
                    ((System.Action<System.Int64>)act)(bytes);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<Microsoft.IO.RecyclableMemoryStreamManager.LargeBufferDiscardedEventHandler>((act) =>
            {
                return new Microsoft.IO.RecyclableMemoryStreamManager.LargeBufferDiscardedEventHandler((reason) =>
                {
                    ((System.Action<Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamDiscardReason>)act)(reason);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<Microsoft.IO.RecyclableMemoryStreamManager.UsageReportEventHandler>((act) =>
            {
                return new Microsoft.IO.RecyclableMemoryStreamManager.UsageReportEventHandler((smallPoolInUseBytes, smallPoolFreeBytes, largePoolInUseBytes, largePoolFreeBytes) =>
                {
                    ((System.Action<System.Int64, System.Int64, System.Int64, System.Int64>)act)(smallPoolInUseBytes, smallPoolFreeBytes, largePoolInUseBytes, largePoolFreeBytes);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<System.Object>>((act) =>
            {
                return new System.Comparison<System.Object>((x, y) =>
                {
                    return ((System.Func<System.Object, System.Object, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Diagnostics.DataReceivedEventHandler>((act) =>
            {
                return new System.Diagnostics.DataReceivedEventHandler((sender, e) =>
                {
                    ((System.Action<System.Object, System.Diagnostics.DataReceivedEventArgs>)act)(sender, e);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.EventHandler>((act) =>
            {
                return new System.EventHandler((sender, e) =>
                {
                    ((System.Action<System.Object, System.EventArgs>)act)(sender, e);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<ETModel.ComponentInfo>>((act) =>
            {
                return new System.Predicate<ETModel.ComponentInfo>((obj) =>
                {
                    return ((System.Func<ETModel.ComponentInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<ETModel.ComponentInfo>>((act) =>
            {
                return new System.Comparison<ETModel.ComponentInfo>((x, y) =>
                {
                    return ((System.Func<ETModel.ComponentInfo, ETModel.ComponentInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<ETModel.BaseConfig>>((act) =>
            {
                return new System.Predicate<ETModel.BaseConfig>((obj) =>
                {
                    return ((System.Func<ETModel.BaseConfig, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<ETModel.BaseConfig>>((act) =>
            {
                return new System.Comparison<ETModel.BaseConfig>((x, y) =>
                {
                    return ((System.Func<ETModel.BaseConfig, ETModel.BaseConfig, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<ETModel.CharacterBaseData>>((act) =>
            {
                return new System.Predicate<ETModel.CharacterBaseData>((obj) =>
                {
                    return ((System.Func<ETModel.CharacterBaseData, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<ETModel.CharacterBaseData>>((act) =>
            {
                return new System.Comparison<ETModel.CharacterBaseData>((x, y) =>
                {
                    return ((System.Func<ETModel.CharacterBaseData, ETModel.CharacterBaseData, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<ETModel.SkillDataBase>>((act) =>
            {
                return new System.Predicate<ETModel.SkillDataBase>((obj) =>
                {
                    return ((System.Func<ETModel.SkillDataBase, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<ETModel.SkillDataBase>>((act) =>
            {
                return new System.Comparison<ETModel.SkillDataBase>((x, y) =>
                {
                    return ((System.Func<ETModel.SkillDataBase, ETModel.SkillDataBase, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.Events.UnityAction<System.String, System.Int32, System.Int32>>((act) =>
            {
                return new UnityEngine.Events.UnityAction<System.String, System.Int32, System.Int32>((arg0, arg1, arg2) =>
                {
                    ((System.Action<System.String, System.Int32, System.Int32>)act)(arg0, arg1, arg2);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.Events.UnityAction<UnityEngine.TouchScreenKeyboard.Status>>((act) =>
            {
                return new UnityEngine.Events.UnityAction<UnityEngine.TouchScreenKeyboard.Status>((arg0) =>
                {
                    ((System.Action<UnityEngine.TouchScreenKeyboard.Status>)act)(arg0);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<ETModel.UIToggle>>((act) =>
            {
                return new System.Predicate<ETModel.UIToggle>((obj) =>
                {
                    return ((System.Func<ETModel.UIToggle, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<ETModel.UIToggle>>((act) =>
            {
                return new System.Comparison<ETModel.UIToggle>((x, y) =>
                {
                    return ((System.Func<ETModel.UIToggle, ETModel.UIToggle, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<ETModel.Entity>>((act) =>
            {
                return new System.Predicate<ETModel.Entity>((obj) =>
                {
                    return ((System.Func<ETModel.Entity, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<ETModel.Entity>>((act) =>
            {
                return new System.Comparison<ETModel.Entity>((x, y) =>
                {
                    return ((System.Func<ETModel.Entity, ETModel.Entity, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.EventHandler<System.Net.Sockets.SocketAsyncEventArgs>>((act) =>
            {
                return new System.EventHandler<System.Net.Sockets.SocketAsyncEventArgs>((sender, e) =>
                {
                    ((System.Action<System.Object, System.Net.Sockets.SocketAsyncEventArgs>)act)(sender, e);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<ETModel.KcpOutput>((act) =>
            {
                return new ETModel.KcpOutput((buf, len, kcp, user) =>
                {
                    return ((System.Func<System.IntPtr, System.Int32, System.IntPtr, System.IntPtr, System.Int32>)act)(buf, len, kcp, user);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<System.Int64>>((act) =>
            {
                return new System.Predicate<System.Int64>((obj) =>
                {
                    return ((System.Func<System.Int64, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<System.Byte>>((act) =>
            {
                return new System.Predicate<System.Byte>((obj) =>
                {
                    return ((System.Func<System.Byte, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<System.Byte>>((act) =>
            {
                return new System.Comparison<System.Byte>((x, y) =>
                {
                    return ((System.Func<System.Byte, System.Byte, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<DG.Tweening.Tween>>((act) =>
            {
                return new System.Predicate<DG.Tweening.Tween>((obj) =>
                {
                    return ((System.Func<DG.Tweening.Tween, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<DG.Tweening.Tween>>((act) =>
            {
                return new System.Comparison<DG.Tweening.Tween>((x, y) =>
                {
                    return ((System.Func<DG.Tweening.Tween, DG.Tweening.Tween, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UIButtonOrdin>>((act) =>
            {
                return new System.Predicate<UIButtonOrdin>((obj) =>
                {
                    return ((System.Func<UIButtonOrdin, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UIButtonOrdin>>((act) =>
            {
                return new System.Comparison<UIButtonOrdin>((x, y) =>
                {
                    return ((System.Func<UIButtonOrdin, UIButtonOrdin, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<ETModel.AppType>>((act) =>
            {
                return new System.Predicate<ETModel.AppType>((obj) =>
                {
                    return ((System.Func<ETModel.AppType, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<ETModel.AppType>>((act) =>
            {
                return new System.Comparison<ETModel.AppType>((x, y) =>
                {
                    return ((System.Func<ETModel.AppType, ETModel.AppType, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.EventHandler<System.Diagnostics.Tracing.EventCommandEventArgs>>((act) =>
            {
                return new System.EventHandler<System.Diagnostics.Tracing.EventCommandEventArgs>((sender, e) =>
                {
                    ((System.Action<System.Object, System.Diagnostics.Tracing.EventCommandEventArgs>)act)(sender, e);
                });
            });


        }

        static public void RegisterMethodDelegate(AppDomain appdomain)
        {
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.Component>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.UICharInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.UILineInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.UIVertex>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.Font>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Boolean>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.RectTransform>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.Rendering.AsyncGPUReadbackRequest>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Single>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.Vector4>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.Matrix4x4>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.Camera>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.Vector3>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.Color>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.Color32>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.Vector2>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Int32>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.BoneWeight>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.GameObject>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.EventSystems.RaycastResult>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.EventSystems.EventTrigger.Entry>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.EventSystems.BaseEventData>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.EventSystems.IPointerEnterHandler, UnityEngine.EventSystems.BaseEventData>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.EventSystems.IPointerExitHandler, UnityEngine.EventSystems.BaseEventData>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.EventSystems.IPointerDownHandler, UnityEngine.EventSystems.BaseEventData>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.EventSystems.IPointerUpHandler, UnityEngine.EventSystems.BaseEventData>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.EventSystems.IPointerClickHandler, UnityEngine.EventSystems.BaseEventData>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.EventSystems.IInitializePotentialDragHandler, UnityEngine.EventSystems.BaseEventData>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.EventSystems.IBeginDragHandler, UnityEngine.EventSystems.BaseEventData>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.EventSystems.IDragHandler, UnityEngine.EventSystems.BaseEventData>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.EventSystems.IEndDragHandler, UnityEngine.EventSystems.BaseEventData>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.EventSystems.IDropHandler, UnityEngine.EventSystems.BaseEventData>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.EventSystems.IScrollHandler, UnityEngine.EventSystems.BaseEventData>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.EventSystems.IUpdateSelectedHandler, UnityEngine.EventSystems.BaseEventData>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.EventSystems.ISelectHandler, UnityEngine.EventSystems.BaseEventData>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.EventSystems.IDeselectHandler, UnityEngine.EventSystems.BaseEventData>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.EventSystems.IMoveHandler, UnityEngine.EventSystems.BaseEventData>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.EventSystems.ISubmitHandler, UnityEngine.EventSystems.BaseEventData>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.EventSystems.ICancelHandler, UnityEngine.EventSystems.BaseEventData>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.Rect>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.AnimatorClipInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.UI.Selectable>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.UI.Dropdown.OptionData>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.String>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.Sprite>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.UI.RectMask2D>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.Video.VideoPlayer>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.Video.VideoPlayer, System.String>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.Video.VideoPlayer, System.Double>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.Video.VideoPlayer, System.Int64>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.Rendering.ReflectionProbeBlendInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<PF.GraphNode>();
            appdomain.DelegateManager.RegisterMethodDelegate<PF.Path>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Object>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Threading.Tasks.Task>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Threading.Tasks.Task, System.Object>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Object, System.Threading.Tasks.UnobservedTaskExceptionEventArgs>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.IAsyncResult>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Threading.Tasks.Task[]>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Threading.Tasks.Task<System.Threading.Tasks.Task>>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Threading.Tasks.Task<System.Threading.Tasks.Task>, System.Object>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Threading.Tasks.Task<System.Int32>>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Threading.Tasks.Task<System.Int32>, System.Object>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Object, System.Xml.Schema.ValidationEventArgs>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Object, System.Xml.XmlNodeChangedEventArgs>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Threading.Tasks.Task<System.Object>>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Threading.Tasks.Task<System.Object>, System.Object>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Threading.Tasks.Task<System.String>>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Threading.Tasks.Task<System.String>, System.Object>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Threading.Tasks.Task<System.Boolean>>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Threading.Tasks.Task<System.Boolean>, System.Object>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Threading.Tasks.Task<System.Xml.XmlNodeType>>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Threading.Tasks.Task<System.Xml.XmlNodeType>, System.Object>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.UI.MaskableGraphic>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.Transform>();
            appdomain.DelegateManager.RegisterMethodDelegate<UIToggleOrdin>();
            appdomain.DelegateManager.RegisterMethodDelegate<UIChangeItemBase>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.TextCore.Glyph>();
            appdomain.DelegateManager.RegisterMethodDelegate<TMPro.TMP_Character>();
            appdomain.DelegateManager.RegisterMethodDelegate<TMPro.TMP_FontAsset>();
            appdomain.DelegateManager.RegisterMethodDelegate<TMPro.TMP_SpriteCharacter>();
            appdomain.DelegateManager.RegisterMethodDelegate<TMPro.TMP_SpriteGlyph>();
            appdomain.DelegateManager.RegisterMethodDelegate<TMPro.TMP_Sprite>();
            appdomain.DelegateManager.RegisterMethodDelegate<TMPro.TMP_SpriteAsset>();
            appdomain.DelegateManager.RegisterMethodDelegate<ReferenceCollectorData>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Threading.Tasks.Task<System.IO.Stream>>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Threading.Tasks.Task<System.IO.Stream>, System.Object>();
            appdomain.DelegateManager.RegisterMethodDelegate<wxb.BehaviourAction, System.Int32>();
            appdomain.DelegateManager.RegisterMethodDelegate<wxb.BehaviourAction>();
            appdomain.DelegateManager.RegisterMethodDelegate<wxb.BehaviourAction, System.Boolean>();
            appdomain.DelegateManager.RegisterMethodDelegate<wxb.BehaviourAction, System.Single[], System.Int32>();
            appdomain.DelegateManager.RegisterMethodDelegate<wxb.BehaviourAction, UnityEngine.Collision>();
            appdomain.DelegateManager.RegisterMethodDelegate<wxb.BehaviourAction, UnityEngine.Collision2D>();
            appdomain.DelegateManager.RegisterMethodDelegate<wxb.BehaviourAction, UnityEngine.ControllerColliderHit>();
            appdomain.DelegateManager.RegisterMethodDelegate<wxb.BehaviourAction, System.Single>();
            appdomain.DelegateManager.RegisterMethodDelegate<wxb.BehaviourAction, UnityEngine.Joint2D>();
            appdomain.DelegateManager.RegisterMethodDelegate<wxb.BehaviourAction, UnityEngine.GameObject>();
            appdomain.DelegateManager.RegisterMethodDelegate<wxb.BehaviourAction, UnityEngine.RenderTexture, UnityEngine.RenderTexture>();
            appdomain.DelegateManager.RegisterMethodDelegate<wxb.BehaviourAction, UnityEngine.Collider>();
            appdomain.DelegateManager.RegisterMethodDelegate<wxb.BehaviourAction, UnityEngine.Collider2D>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Type>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.Object>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Collections.Generic.List<System.Int32>, System.Boolean>();
            appdomain.DelegateManager.RegisterMethodDelegate<PF.Int3>();
            appdomain.DelegateManager.RegisterMethodDelegate<PF.Funnel.PathPart>();
            appdomain.DelegateManager.RegisterMethodDelegate<PF.NavmeshTile[]>();
            appdomain.DelegateManager.RegisterMethodDelegate<ETModel.AChannel, System.Int32>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.IO.MemoryStream>();
            appdomain.DelegateManager.RegisterMethodDelegate<ETModel.AChannel>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Int64>();
            appdomain.DelegateManager.RegisterMethodDelegate<Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamDiscardReason>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Int64, System.Int64, System.Int64, System.Int64>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Collections.Generic.List<System.Object>>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Object, System.Diagnostics.DataReceivedEventArgs>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Object, System.EventArgs>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.AsyncOperation>();
            appdomain.DelegateManager.RegisterMethodDelegate<ETModel.ComponentInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<ETModel.BaseConfig>();
            appdomain.DelegateManager.RegisterMethodDelegate<ETModel.CharacterBaseData>();
            appdomain.DelegateManager.RegisterMethodDelegate<ETModel.SkillDataBase>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.String, System.Int32, System.Int32>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.TouchScreenKeyboard.Status>();
            appdomain.DelegateManager.RegisterMethodDelegate<ETModel.UIToggle>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Int32[]>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Collections.Generic.List<ETModel.UIToggle>>();
            appdomain.DelegateManager.RegisterMethodDelegate<ETModel.Entity>();
            appdomain.DelegateManager.RegisterMethodDelegate<ETModel.Session, System.Object>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Object, System.Net.Sockets.SocketAsyncEventArgs>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Threading.Tasks.Task<System.Net.WebSockets.WebSocketReceiveResult>>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Threading.Tasks.Task<System.Net.WebSockets.WebSocketReceiveResult>, System.Object>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Byte>();
            appdomain.DelegateManager.RegisterMethodDelegate<ETModel.Session, System.UInt16, System.IO.MemoryStream>();
            appdomain.DelegateManager.RegisterMethodDelegate<ETModel.Session>();
            appdomain.DelegateManager.RegisterMethodDelegate<DG.Tweening.Tween>();
            appdomain.DelegateManager.RegisterMethodDelegate<UIButtonOrdin>();
            appdomain.DelegateManager.RegisterMethodDelegate<ETModel.AppType>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Object, System.Diagnostics.Tracing.EventCommandEventArgs>();

        }

        static public void Fame()
        {
            System.Type v = null;

        }
    }
}
#endif