namespace ET
{
	[ComponentOf(typeof(Session))]
	public class SessionPlayerComponent : Entity, IAwake, IDestroy
	{
		public long PlayerId;
		public long PlayerInstanceId;
		public long AccountId;
		///是否是重复登录
		public bool isLoginAgain = false;
	}
}