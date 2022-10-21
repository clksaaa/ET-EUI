using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
	[FriendClass(typeof(DlgRoles))]
	[FriendClass(typeof(RoleInfosComponent))]
	public static  class DlgRolesSystem
	{

		public static void RegisterUIEvent(this DlgRoles self)
		{
		  self.View.E_StartGameButton.AddListenerAsync(() => { return self.OnStartGameClickHandler();});
		}

		public static void ShowWindow(this DlgRoles self, Entity contextData = null)
		{
		}
		public static async ETTask OnStartGameClickHandler(this DlgRoles self)
		{

			if (self.ZoneScene().GetComponent<RoleInfosComponent>().CurrentRoleId==0)
			{
				Log.Error("请选择角色");
				return;
			}

			try
			{
				int errorCode = await LoginHelper.GetRealmKey(self.ZoneScene());
				if (errorCode!=ErrorCode.ERR_Success)
				{
					Log.Error(errorCode.ToString());
					return;
				}
				//TODO 进入游戏
			}
			catch (Exception e)
			{
				Log.Error(e.ToString());
			}
		}

		 

	}
}
