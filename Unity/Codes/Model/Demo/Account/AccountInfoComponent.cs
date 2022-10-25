namespace ET
{
    /// <summary>
    /// 保存登陆成功后的 账户信息
    /// </summary>
    [ComponentOf(typeof(Scene))]
    public class AccountInfoComponent : Entity,IAwake,IDestroy
    {
        //token
        public string Token;
        public long AccountId;
        ///网关负载均衡服务器 令牌
        public string RealmKey;
        ///连接地址
        public string RealmAddress;
    }
}