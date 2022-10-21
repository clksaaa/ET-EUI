using System;

namespace ET
{
    [FriendClass(typeof(DBManagerComponent))]
    public static class DBManagerComponentSystem
    {
        [ObjectSystem]
        public class DBManagerComponentAwakeSystem: AwakeSystem<DBManagerComponent>
        {
            public override void Awake(DBManagerComponent self)
            {
                DBManagerComponent.Instance = self;
            }
        }

        [ObjectSystem]
        public class DBManagerComponentDestroySystem: DestroySystem<DBManagerComponent>
        {
            public override void Destroy(DBManagerComponent self)
            {
                DBManagerComponent.Instance = null;
            }
        }
        
        public static DBComponent GetZoneDB(this DBManagerComponent self, int zone)
        {
            DBComponent dbComponent = self.DBComponents[zone];
            if (dbComponent != null)
            {
                return dbComponent;
            }

            StartZoneConfig startZoneConfig = StartZoneConfigCategory.Instance.Get(zone);
            if (startZoneConfig.DBConnection == "")
            {
                throw new Exception($"zone: {zone} not found mongo connect string");
            }

            dbComponent = self.AddChild<DBComponent, string, string, int>(startZoneConfig.DBConnection, startZoneConfig.DBName, zone);
            self.DBComponents[zone] = dbComponent;
            return dbComponent;
        }
        public static DBComponent GetZoneDB(this Session session)
        {
            //这里只使用了一个数据库  配置中startzoneconfig中  id是1库       客户端的session的zoneId  正好是1  
            //如果是多个数据库 可以配置一个  多个区服与单个数据库的对应关系
            return DBManagerComponent.Instance.GetZoneDB(session.DomainZone());
        }
    }
}