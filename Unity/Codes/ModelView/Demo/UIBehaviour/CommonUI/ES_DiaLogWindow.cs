
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[EnableMethod]
	public  class ES_DiaLogWindow : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public TMPro.TextMeshProUGUI E_TitleTextMeshProUGUI
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TitleTextMeshProUGUI == null )
     			{
		    		this.m_E_TitleTextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"E_Title");
     			}
     			return this.m_E_TitleTextMeshProUGUI;
     		}
     	}

		public TMPro.TextMeshProUGUI E_ContextTextMeshProUGUI
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ContextTextMeshProUGUI == null )
     			{
		    		this.m_E_ContextTextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"E_Context");
     			}
     			return this.m_E_ContextTextMeshProUGUI;
     		}
     	}

		public UnityEngine.UI.Button E_SureButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SureButton == null )
     			{
		    		this.m_E_SureButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Sure");
     			}
     			return this.m_E_SureButton;
     		}
     	}

		public UnityEngine.UI.Image E_SureImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SureImage == null )
     			{
		    		this.m_E_SureImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Sure");
     			}
     			return this.m_E_SureImage;
     		}
     	}

		public UnityEngine.UI.Button E_CancelButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CancelButton == null )
     			{
		    		this.m_E_CancelButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Cancel");
     			}
     			return this.m_E_CancelButton;
     		}
     	}

		public UnityEngine.UI.Image E_CancelImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CancelImage == null )
     			{
		    		this.m_E_CancelImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Cancel");
     			}
     			return this.m_E_CancelImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_TitleTextMeshProUGUI = null;
			this.m_E_ContextTextMeshProUGUI = null;
			this.m_E_SureButton = null;
			this.m_E_SureImage = null;
			this.m_E_CancelButton = null;
			this.m_E_CancelImage = null;
			this.uiTransform = null;
		}

		private TMPro.TextMeshProUGUI m_E_TitleTextMeshProUGUI = null;
		private TMPro.TextMeshProUGUI m_E_ContextTextMeshProUGUI = null;
		private UnityEngine.UI.Button m_E_SureButton = null;
		private UnityEngine.UI.Image m_E_SureImage = null;
		private UnityEngine.UI.Button m_E_CancelButton = null;
		private UnityEngine.UI.Image m_E_CancelImage = null;
		public Transform uiTransform = null;
	}
}
