namespace ET
{
    /// <summary>
    /// 区服状态
    /// </summary>
    public enum ServerStatus
    {
        /// <summary>
        /// 正常
        /// </summary>
        Normal = 0,
        /// <summary>
        /// 停服
        /// </summary>
        Stop   = 1,
    }

    /// <summary>
    /// 游戏区服信息  一服 二服 三服···
    /// </summary>
    public class ServerInfo : Entity,IAwake
    {
        ///游戏服务器的状态信息
        public int Status;
        ///游戏服务器的名字
        public string ServerName;
    }
}