using System.Linq;
using System.Collections.Generic;

namespace ETModel
{
	[ObjectSystem]
	public class UIStartWindowComponentAwakeSystem : AwakeSystem<UIStartWindowComponent>
	{
		public override void Awake(UIStartWindowComponent self)
		{
			self.Awake();
		}
	}
	public partial class UIStartWindowComponent : UIPanelComponent
	{
		private TMPro.TextMeshProUGUI tmp;

		private UnityEngine.UI.Image Center_image;

		private UIButtonOrdin button;

		private UnityEngine.RectTransform rect;

		private UnityEngine.RectTransform Image;

		public void Awake()
		{
			var go = GetParent<UI>().GameObject;

			tmp=Collector.GetMonoComponent<TMPro.TextMeshProUGUI>("tmp");

			Center_image=Collector.GetMonoComponent<UnityEngine.UI.Image>("Center_image");

			button=Collector.GetMonoComponent<UIButtonOrdin>("button");

			rect=Collector.GetMonoComponent<UnityEngine.RectTransform>("rect");

			Image=Collector.GetMonoComponent<UnityEngine.RectTransform>("Image");

			this.RegisterEvent();
		}
	}
}
