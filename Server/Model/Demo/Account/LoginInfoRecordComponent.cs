using System.Collections.Generic;

namespace ET
{
    /// <summary>
    /// 登录中心服 管理组件
    /// </summary>
    [ComponentOf(typeof(Scene))]
    public class LoginInfoRecordComponent : Entity,IAwake,IDestroy
    {
        public Dictionary<long, int> AccountLoginInfoDict = new Dictionary<long, int>();
    }
}