
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ComponentOf(typeof(UIBaseWindow))]
	[EnableMethod]
	public  class DlgDlalogViewComponent : Entity,IAwake,IDestroy 
	{
		public ES_DiaLogWindow ES_DiaLogWindow
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_dialogwindow == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_DiaLogWindow");
		    	   this.m_es_dialogwindow = this.AddChild<ES_DiaLogWindow,Transform>(subTrans);
     			}
     			return this.m_es_dialogwindow;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_es_dialogwindow?.Dispose();
			this.m_es_dialogwindow = null;
			this.uiTransform = null;
		}

		private ES_DiaLogWindow m_es_dialogwindow = null;
		public Transform uiTransform = null;
	}
}
