namespace ET
{
    /// <summary>
    /// 角色状态
    /// </summary>
    public enum RoleInfoState
    {
        /// <summary>
        /// 正常
        /// </summary>
        Normal = 0,
        /// <summary>
        /// 冻结
        /// </summary>
        Freeze,
    }
    
    [ComponentOf]
    
    #if SERVER
    public class RoleInfo : Entity,IAwake,ITransfer
    #else
      public class RoleInfo : Entity,IAwake
    #endif
    {
        public string Name;

        public int ServerId;

        public int State;

        public long AccountId;

        public long LastLoginTime;

        public long CreateTime;
    }
}