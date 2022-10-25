
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class ES_DiaLogWindowAwakeSystem : AwakeSystem<ES_DiaLogWindow,Transform> 
	{
		public override void Awake(ES_DiaLogWindow self,Transform transform)
		{
			self.uiTransform = transform;
		}
	}


	[ObjectSystem]
	public class ES_DiaLogWindowDestroySystem : DestroySystem<ES_DiaLogWindow> 
	{
		public override void Destroy(ES_DiaLogWindow self)
		{
			self.DestroyWidget();
		}
	}
}
