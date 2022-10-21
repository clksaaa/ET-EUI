
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ComponentOf(typeof(UIBaseWindow))]
	[EnableMethod]
	public  class DlgServerViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Image E_BackGroundImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BackGroundImage == null )
     			{
		    		this.m_E_BackGroundImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_BackGround");
     			}
     			return this.m_E_BackGroundImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_ServerInfoListLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ServerInfoListLoopVerticalScrollRect == null )
     			{
		    		this.m_E_ServerInfoListLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_BackGround/E_ServerInfoList");
     			}
     			return this.m_E_ServerInfoListLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button E_ConfirmButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ConfirmButton == null )
     			{
		    		this.m_E_ConfirmButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_BackGround/E_Confirm");
     			}
     			return this.m_E_ConfirmButton;
     		}
     	}

		public UnityEngine.UI.Image E_ConfirmImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ConfirmImage == null )
     			{
		    		this.m_E_ConfirmImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_BackGround/E_Confirm");
     			}
     			return this.m_E_ConfirmImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_BackGroundImage = null;
			this.m_E_ServerInfoListLoopVerticalScrollRect = null;
			this.m_E_ConfirmButton = null;
			this.m_E_ConfirmImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Image m_E_BackGroundImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_ServerInfoListLoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_E_ConfirmButton = null;
		private UnityEngine.UI.Image m_E_ConfirmImage = null;
		public Transform uiTransform = null;
	}
}
