namespace ET
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgDlalog :Entity,IAwake,IUILogic
	{

		public DlgDlalogViewComponent View { get => this.Parent.GetComponent<DlgDlalogViewComponent>();} 

		 

	}
}
