

using System.Net;

namespace ET
{
    public static class SceneFactory
    {
        public static async ETTask<Scene> Create(Entity parent, string name, SceneType sceneType)
        {
            long instanceId = IdGenerater.Instance.GenerateInstanceId();
            return await Create(parent, instanceId, instanceId, parent.DomainZone(), name, sceneType);
        }
        
        public static async ETTask<Scene> Create(Entity parent, long id, long instanceId, int zone, string name, SceneType sceneType, StartSceneConfig startSceneConfig = null)
        {
            await ETTask.CompletedTask;
            Scene scene = EntitySceneFactory.CreateScene(id, instanceId, zone, sceneType, name, parent);

            scene.AddComponent<MailBoxComponent, MailboxType>(MailboxType.UnOrderMessageDispatcher);

            switch (scene.SceneType)
            {
                case SceneType.Realm:
                    scene.AddComponent<NetKcpComponent, IPEndPoint, int>(startSceneConfig.OuterIPPort, SessionStreamDispatcherType.SessionStreamDispatcherServerOuter);
                    //与账号服务器的Token管理区分开
                    scene.AddComponent<TokenComponent>();

                    break;
                case SceneType.Gate:
                    scene.AddComponent<NetKcpComponent, IPEndPoint, int>(startSceneConfig.OuterIPPort, SessionStreamDispatcherType.SessionStreamDispatcherServerOuter);
                    scene.AddComponent<PlayerComponent>();
                    scene.AddComponent<GateSessionKeyComponent>();
                    break;
                case SceneType.Map:
                    scene.AddComponent<UnitComponent>();
                    scene.AddComponent<AOIManagerComponent>();
                    break;
                case SceneType.Location:
                    scene.AddComponent<LocationComponent>();
                    break;
                case SceneType.Account:
                    //kcp
                    scene.AddComponent<NetKcpComponent, IPEndPoint, int>(startSceneConfig.OuterIPPort,
                        SessionStreamDispatcherType.SessionStreamDispatcherServerOuter);
                    //Token管理
                    scene.AddComponent<TokenComponent>();
                    //账号session管理
                    scene.AddComponent<AccountSessionsComponent>();
                    //区服信息管理
                    scene.AddComponent<ServerInfoManagerComponent>();
                    break;
                case SceneType.LoginCenter:
                    //登录中心  管理记录已经登录账户 
                    scene.AddComponent<LoginInfoRecordComponent>();
                    break;
                case SceneType.UnitCache:
                    //Unit缓存管理
                    scene.AddComponent<UnitCacheComponent>();
                    break;
            }

            return scene;
        }
    }
}