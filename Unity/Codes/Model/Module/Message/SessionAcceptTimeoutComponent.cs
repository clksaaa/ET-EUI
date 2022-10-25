namespace ET
{
    /// 刚accept的session只持续5秒，必须通过验证，否则断开 需要长时间连接的session 都需要移除这个组件
    [ComponentOf(typeof(Session))]
    public class SessionAcceptTimeoutComponent: Entity, IAwake, IDestroy
    {
        public long Timer;
    }
}