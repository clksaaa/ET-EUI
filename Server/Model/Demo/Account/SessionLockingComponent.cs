namespace ET
{
    /// <summary>
    /// 锁定脚本 防止执行多次请求
    /// </summary>
    [ComponentOf(typeof(Session))]
    public class SessionLockingComponent : Entity,IAwake
    {
        
    }
}