namespace ET
{
    [ObjectSystem]
    public class ServerInfoManagerComponentAwakeSystem : AwakeSystem<ServerInfoManagerComponent>
    {
        public override void Awake(ServerInfoManagerComponent self)
        {
            self.Awake().Coroutine();
        }
    }
    [ObjectSystem]
    public class ServerInfoManagerComponentDestroySystem : DestroySystem<ServerInfoManagerComponent>
    {
        public override void Destroy(ServerInfoManagerComponent self)
        {
            foreach (var serverInfo in self.ServerInfos)
            {
                serverInfo?.Dispose();
            }
            self.ServerInfos.Clear();
        }
    }
    //热重载
    [ObjectSystem]
    public class ServerInfoManagerComponentLoadSystem : LoadSystem<ServerInfoManagerComponent>
    {
        public override void Load(ServerInfoManagerComponent self)
        {
            self.Awake().Coroutine();
        }
    }

    [FriendClass(typeof(ServerInfo))]
    [FriendClass(typeof(ServerInfoManagerComponent))]
    public static class ServerInfoManagerComponentSystem
    {
        /// <summary>
        /// 初始化时 从数据库获取服务器区服信息列表
        /// </summary>
        /// <param name="self"></param>
        public static async ETTask Awake(this ServerInfoManagerComponent self)
        {
            var serverInfoList = await DBManagerComponent.Instance.GetZoneDB(self.DomainZone()).Query<ServerInfo>(d => true);

            if (serverInfoList == null || serverInfoList.Count <= 0)
            {
                Log.Error("serverInfo  count is zero");
                 self.ServerInfos.Clear();
                var serverInfoConfigs = ServerInfoConfigCategory.Instance.GetAll();
                
                foreach (var info in serverInfoConfigs.Values)
                {
                    ServerInfo newServerInfo = self.AddChildWithId<ServerInfo>(info.Id);
                    newServerInfo.ServerName = info.ServerName;
                    newServerInfo.Status = (int)ServerStatus.Normal;
                    self.ServerInfos.Add(newServerInfo);
                    await DBManagerComponent.Instance.GetZoneDB(self.DomainZone()).Save(newServerInfo);
                    Log.Warning($"从配置表中将区服-{info.ServerName}-储存到数据库中");
                }
                Log.Warning("从配置表中将区服配置信息 储存到数据库中成功");

                
                return;
            }
            self.ServerInfos.Clear();

            //将serverinfo 添加到 ServerInfoManagerComponent 子实体 进行管理
            foreach (var serverInfo in serverInfoList)
            {
                self.AddChild(serverInfo);
                self.ServerInfos.Add(serverInfo);
            }
            
            await ETTask.CompletedTask;
        }
        
    }
}