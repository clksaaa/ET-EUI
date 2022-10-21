using System.Collections.Generic;

namespace ET
{
    /// <summary>
    /// 服务端  管理区服信信息的组件 
    /// </summary>
    [ComponentOf(typeof(Scene))]
    [ChildType(typeof(ServerInfo))]
    
    public class ServerInfoManagerComponent : Entity ,IAwake,IDestroy,ILoad
    {
        //区服列表
        public List<ServerInfo> ServerInfos = new List<ServerInfo>();
    }
}