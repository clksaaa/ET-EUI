using System.Collections.Generic;


namespace ET
{
	public static class RealmGateAddressHelper
	{
		public static StartSceneConfig GetGate(int zone,long accountId)
		{
			//每一个区服 会有很多个Gate网关
			List<StartSceneConfig> zoneGates = StartSceneConfigCategory.Instance.Gates[zone];
			//为了使同一账户 取得的Gate是同一个
			int n = accountId.GetHashCode() % zoneGates.Count;

			return zoneGates[n];
		}
	}
}
