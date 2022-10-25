
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class DlgDlalogViewComponentAwakeSystem : AwakeSystem<DlgDlalogViewComponent> 
	{
		public override void Awake(DlgDlalogViewComponent self)
		{
			self.uiTransform = self.GetParent<UIBaseWindow>().uiTransform;
		}
	}


	[ObjectSystem]
	public class DlgDlalogViewComponentDestroySystem : DestroySystem<DlgDlalogViewComponent> 
	{
		public override void Destroy(DlgDlalogViewComponent self)
		{
			self.DestroyWidget();
		}
	}
}
