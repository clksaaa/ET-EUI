using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
	[FriendClass(typeof(DlgMain))]
	public static  class DlgMainSystem
	{

		public static void RegisterUIEvent(this DlgMain self)
		{
		 
		}

		public static void ShowWindow(this DlgMain self, Entity contextData = null)
		{
			self.Refrech().Coroutine();
		}

		//刷新 等级 金币  经验
		public static async ETTask Refrech(this DlgMain self)
		{
			Unit unit = UnitHelper.GetMyUnitFromCurrentScene(self.ZoneScene().CurrentScene());
			 NumericComponent numericComponent = unit.GetComponent<NumericComponent>();

			 self.View.E_RoleLevelText.SetText($"LV.{numericComponent.GetAsInt((int)NumericType.Level)}");
			 self.View.E_GoldText.SetText(numericComponent.GetAsInt((int)NumericType.Gold).ToString());
			 self.View.E_ExpText.SetText(numericComponent.GetAsInt((int)NumericType.Exp).ToString());
			 
			await ETTask.CompletedTask;
		}
	}
}
