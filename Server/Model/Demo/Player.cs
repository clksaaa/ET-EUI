namespace ET
{


	public enum PlayerState
	{
		//断开连接
		Disconnect,
		//网关状态
		Gate,
		//进入游戏
		Game,
	}
	
	public sealed class Player : Entity,IAwake<string>, IAwake<long,long>,IDestroy
	{
		public long AccountId { get;  set; }
		
		public long UnitId { get; set; }

		public PlayerState PlayerState { get; set; }

		public Session ClientSession { get; set; }
		
		public long ChatInfoInstanceId { get; set; }



	}
}