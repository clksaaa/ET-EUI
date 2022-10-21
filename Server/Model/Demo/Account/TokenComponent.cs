using System.Collections.Generic;

namespace ET
{
    /// <summary>
    /// Token令牌管理组件 记录登录账户的令牌    
    /// </summary>
    [ComponentOf(typeof(Scene))]
    public class TokenComponent : Entity,IAwake
    {
        public readonly Dictionary<long, string> TokenDictionary = new Dictionary<long, string>();
    } 
}