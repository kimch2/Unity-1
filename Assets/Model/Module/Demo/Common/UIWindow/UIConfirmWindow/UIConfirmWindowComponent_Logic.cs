namespace ETModel
{
	public partial class UIConfirmWindowComponent : UIPanelComponent
    {
		private void RegisterEvent()
		{
		}

		public async ETTask InitializationAsync()
		{
		}

		public async ETTask LoadAsync()
		{
		}

		public void Show()
		{
			GetParent<UI>().SetAsLastSibling();
			GetParent<UI>().Canvas.enabled = true;
		}

		public void Hide()
		{
			GetParent<UI>().Canvas.enabled = false;
			GetParent<UI>().SetAsFirstSibling();
		}

		public void Reset()
		{
		}
	}
}
