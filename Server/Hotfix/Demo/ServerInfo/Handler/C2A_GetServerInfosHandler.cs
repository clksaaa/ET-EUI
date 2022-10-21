using System;

namespace ET
{
    /// <summary>
    /// 处理 客户端 获取服务器（区服）信息的请求
    /// </summary>
    [FriendClass(typeof(ServerInfoManagerComponent))]
    public class C2A_GetServerInfosHandler : AMRpcHandler<C2A_GetServerInfos,A2C_GetServerInfos>
    {
        protected override async ETTask Run(Session session, C2A_GetServerInfos request, A2C_GetServerInfos response, Action reply)
        {
            
            if (session.DomainScene().SceneType != SceneType.Account)
            {
                Log.Error($"请求的Scene错误，当前Scene为：{session.DomainScene().SceneType}");
                session.Dispose();
                return;
            }


            string token = session.DomainScene().GetComponent<TokenComponent>().Get(request.AccountId);
            //将从客户单发来的token 和服务器存储的这个已经登陆的账户的token进行比对
            if (token == null || token != request.Token)
            {
                response.Error = ErrorCode.ERR_TokenError;
                reply();
                session?.Disconnect().Coroutine();
                return;
            }

            foreach (var serverInfo in session.DomainScene().GetComponent<ServerInfoManagerComponent>().ServerInfos)
            {
                response.ServerInfosList.Add(serverInfo.ToMessage());
            }

            reply();
            
            await ETTask.CompletedTask;
        }
    }
}