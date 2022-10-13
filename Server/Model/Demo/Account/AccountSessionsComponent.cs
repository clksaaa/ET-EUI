using System.Collections.Generic;

namespace ET
{
    /// <summary>
    /// 从账号连接管理组件
    /// </summary>
    [ComponentOf(typeof(Scene))]
    public class AccountSessionsComponent : Entity,IAwake,IDestroy
    {
        public Dictionary<long, long> AccountSessionDictionary = new Dictionary<long, long>();
    }
}