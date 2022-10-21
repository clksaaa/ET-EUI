using System.Collections.Generic;

namespace ET
{
    /// <summary>
    /// 区服信息列表组件 用来存储从（Account）服务器获取的区服信息
    /// </summary>
    [ComponentOf(typeof(Scene))]
    [ChildType(typeof(ServerInfo))]
    public class ServerInfosComponent : Entity,IAwake,IDestroy
    {
        public List<ServerInfo> ServerInfoList = new List<ServerInfo>();

        public int CurrentServerId = 0;
    }
}