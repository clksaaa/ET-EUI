
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ComponentOf(typeof(UIBaseWindow))]
	[EnableMethod]
	public  class DlgRolesViewComponent : Entity,IAwake,IDestroy 
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

		public UnityEngine.UI.LoopHorizontalScrollRect E_RolesLoopHorizontalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RolesLoopHorizontalScrollRect == null )
     			{
		    		this.m_E_RolesLoopHorizontalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopHorizontalScrollRect>(this.uiTransform.gameObject,"E_BackGround/E_Roles");
     			}
     			return this.m_E_RolesLoopHorizontalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button E_DelectRoleButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_DelectRoleButton == null )
     			{
		    		this.m_E_DelectRoleButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_BackGround/E_DelectRole");
     			}
     			return this.m_E_DelectRoleButton;
     		}
     	}

		public UnityEngine.UI.Image E_DelectRoleImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_DelectRoleImage == null )
     			{
		    		this.m_E_DelectRoleImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_BackGround/E_DelectRole");
     			}
     			return this.m_E_DelectRoleImage;
     		}
     	}

		public UnityEngine.UI.Button E_CreateRoleButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CreateRoleButton == null )
     			{
		    		this.m_E_CreateRoleButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_BackGround/E_CreateRole");
     			}
     			return this.m_E_CreateRoleButton;
     		}
     	}

		public UnityEngine.UI.Image E_CreateRoleImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CreateRoleImage == null )
     			{
		    		this.m_E_CreateRoleImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_BackGround/E_CreateRole");
     			}
     			return this.m_E_CreateRoleImage;
     		}
     	}

		public UnityEngine.UI.Button E_StartGameButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_StartGameButton == null )
     			{
		    		this.m_E_StartGameButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_BackGround/E_StartGame");
     			}
     			return this.m_E_StartGameButton;
     		}
     	}

		public UnityEngine.UI.Image E_StartGameImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_StartGameImage == null )
     			{
		    		this.m_E_StartGameImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_BackGround/E_StartGame");
     			}
     			return this.m_E_StartGameImage;
     		}
     	}

		public TMPro.TMP_InputField E_RoleNameTMP_InputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RoleNameTMP_InputField == null )
     			{
		    		this.m_E_RoleNameTMP_InputField = UIFindHelper.FindDeepChild<TMPro.TMP_InputField>(this.uiTransform.gameObject,"E_BackGround/E_RoleName");
     			}
     			return this.m_E_RoleNameTMP_InputField;
     		}
     	}

		public UnityEngine.UI.Image E_RoleNameImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RoleNameImage == null )
     			{
		    		this.m_E_RoleNameImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_BackGround/E_RoleName");
     			}
     			return this.m_E_RoleNameImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_BackGroundImage = null;
			this.m_E_RolesLoopHorizontalScrollRect = null;
			this.m_E_DelectRoleButton = null;
			this.m_E_DelectRoleImage = null;
			this.m_E_CreateRoleButton = null;
			this.m_E_CreateRoleImage = null;
			this.m_E_StartGameButton = null;
			this.m_E_StartGameImage = null;
			this.m_E_RoleNameTMP_InputField = null;
			this.m_E_RoleNameImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Image m_E_BackGroundImage = null;
		private UnityEngine.UI.LoopHorizontalScrollRect m_E_RolesLoopHorizontalScrollRect = null;
		private UnityEngine.UI.Button m_E_DelectRoleButton = null;
		private UnityEngine.UI.Image m_E_DelectRoleImage = null;
		private UnityEngine.UI.Button m_E_CreateRoleButton = null;
		private UnityEngine.UI.Image m_E_CreateRoleImage = null;
		private UnityEngine.UI.Button m_E_StartGameButton = null;
		private UnityEngine.UI.Image m_E_StartGameImage = null;
		private TMPro.TMP_InputField m_E_RoleNameTMP_InputField = null;
		private UnityEngine.UI.Image m_E_RoleNameImage = null;
		public Transform uiTransform = null;
	}
}
