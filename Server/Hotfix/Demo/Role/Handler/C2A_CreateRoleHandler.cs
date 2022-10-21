using System;

namespace ET
{
    [FriendClass(typeof(RoleInfo))]
    public class C2A_CreateRoleHandler : AMRpcHandler<C2A_CreateRole,A2C_CreateRole>
    {
        protected override async ETTask Run(Session session, C2A_CreateRole request, A2C_CreateRole response, Action reply)
        {
            if (session.DomainScene().SceneType != SceneType.Account)
            {
                Log.Error($"请求的Scene错误，当前Scene为：{session.DomainScene().SceneType}");
                session.Dispose();
                return;
            }
            //所定session防止多次请求
            if (session.GetComponent<SessionLockingComponent>() != null)
            {
                response.Error = ErrorCode.ERR_RequestRepeatedly;
                reply();
                session.Disconnect().Coroutine();
                return;
            }
            //对比token
            string token = session.DomainScene().GetComponent<TokenComponent>().Get(request.AccountId);

            if (token == null || token != request.Token)
            {
                response.Error = ErrorCode.ERR_TokenError;
                reply();
                session?.Disconnect().Coroutine();
                return;
            }

            //判空
            if (string.IsNullOrEmpty(request.Name))
            {
                response.Error = ErrorCode.ERR_RoleNameIsNull;
                reply();
                return;
            }
            //还可以进行角色名称敏感词过滤

            using (session.AddComponent<SessionLockingComponent>())
            {
                //使用携程锁  进行数据库查询账户角色信息 防止创建时重名
                using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.CreateRole,request.AccountId))
                {
                    
                    
                    var roleInfos = await session.GetZoneDB().Query<RoleInfo>(d => d.Name == request.Name && d.ServerId == request.ServerId && d.State != (int)RoleInfoState.Freeze);

                    //区服下角色名 重名
                    if (roleInfos != null && roleInfos.Count > 0)
                    {
                        response.Error = ErrorCode.ERR_RoleNameSame;
                        reply();
                        return;
                    }
                    //这里使用 GenerateUnitId 为了进入map服务器后能正确接收actor消息
                    RoleInfo newRoleInfo = session.GetComponent<RoleInfosZone>().AddChildWithId<RoleInfo>(IdGenerater.Instance.GenerateUnitId(request.ServerId));
                    newRoleInfo.Name = request.Name;
                    newRoleInfo.State = (int)RoleInfoState.Normal;
                    newRoleInfo.ServerId = request.ServerId;
                    newRoleInfo.AccountId = request.AccountId;
                    newRoleInfo.CreateTime = TimeHelper.ServerNow();
                    newRoleInfo.LastLoginTime = 0;

                    await session.GetZoneDB().Save<RoleInfo>(newRoleInfo);

                    response.RoleInfo = newRoleInfo.ToMessage();

                    reply();

                    newRoleInfo?.Dispose();

                }
            }
           
        }
    }
}