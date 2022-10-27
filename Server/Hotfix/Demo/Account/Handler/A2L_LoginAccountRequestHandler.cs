using System;

namespace ET
{
    [ActorMessageHandler]
    public class A2L_LoginAccountRequestHandler : AMActorRpcHandler<Scene,A2L_LoginAccountRequest,L2A_LoginAccountResponse>
    {
        protected override async ETTask Run(Scene scene, A2L_LoginAccountRequest request, L2A_LoginAccountResponse response, Action reply)
        {
            long accountId = request.AccountId;

            using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginCenterLock,accountId.GetHashCode()))
            {

                if (!scene.GetComponent<LoginInfoRecordComponent>().IsExist(accountId))
                {
                    reply();
                    return;
                }
                //这里的scene是账号登录中心服的scene  通过accountId获取保存的zone  （当前账号所登录的区服）
                int zone = scene.GetComponent<LoginInfoRecordComponent>().Get(accountId);
                //通过区服信息 获取账号所连接的具体Gate区服配置
                StartSceneConfig gateConfig = RealmGateAddressHelper.GetGate(zone,accountId);
                //发送Actor消息 登录中心服踢在线玩家下线
                 var g2LDisconnectGateUnit = (G2L_DisconnectGateUnit) await MessageHelper.CallActor(gateConfig.InstanceId, new L2G_DisconnectGateUnit() { AccountId = accountId });

                 response.Error = g2LDisconnectGateUnit.Error;
                 reply();
            }
        }
    }
}