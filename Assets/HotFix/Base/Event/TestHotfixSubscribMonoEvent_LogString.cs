using ETModel;
using UnityEngine;

namespace ETHotfix
{
	// 分发数值监听
	[Event(ETModel.EventIdType.TestHotfixSubscribMonoEvent)]
	public class TestHotfixSubscribMonoEvent_LogString : AEvent<string>
	{
		public override void Run(string info)
		{
			GameObject.Find("Text").GetComponent<UnityEngine.UI.Text>().text = "AAAA";
			Log.Info(info);
		}
	}
}
