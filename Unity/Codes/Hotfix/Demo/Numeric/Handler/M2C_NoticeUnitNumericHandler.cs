namespace ET
{
    /// <summary>
    /// 处理Map服务器发来的同步Unit数值的消息  
    /// </summary>
    public class M2C_NoticeUnitNumericHandler: AMHandler<M2C_NoticeUnitNumeric>
    {
        protected override  void Run(Session session, M2C_NoticeUnitNumeric message)
        {
            //更新客户端数值组件 数据
            session.ZoneScene()?.CurrentScene()?.GetComponent<UnitComponent>()?
                    .Get(message.UnitId)?.GetComponent<NumericComponent>()?.Set(message.NumericType, message.NewValue);
   
        }
    }
}