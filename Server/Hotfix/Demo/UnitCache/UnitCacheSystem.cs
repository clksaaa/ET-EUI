using System;
using System.Collections.Generic;

namespace ET
{
    [ObjectSystem]
    public class UnitCacheDestroySystem: DestroySystem<UnitCache>
    {
        public override void Destroy(UnitCache self)
        {
            foreach (Entity entity in self.CacheCompoenntsDictionary.Values)
            {
                entity.Dispose();
            }
            self.CacheCompoenntsDictionary.Clear();
            self.key = null;
        }
    }

    [FriendClass(typeof(UnitCache))]
    public static class UnitCacheSystem
    {
        public static void AddOrUpdate(this UnitCache self, Entity entity)
        {
            if (entity == null)
            {
                return;
            }

            //如果存在保存过的旧的entity  就释放掉并从字典中移除
            if (self.CacheCompoenntsDictionary.TryGetValue(entity.Id,out Entity oldEntity))
            {
                if (entity != oldEntity)
                {
                    oldEntity.Dispose();
                }

                self.CacheCompoenntsDictionary.Remove(entity.Id);
            }

            //将entity保存到字典中
            self.CacheCompoenntsDictionary.Add(entity.Id, entity);
        }

        public static async ETTask<Entity> Get(this UnitCache self, long unitId)
        {
            Entity entity = null;
            if (!self.CacheCompoenntsDictionary.TryGetValue(unitId,out entity))
            {
                //从数据库中查询
                entity = await DBManagerComponent.Instance.GetZoneDB(self.DomainZone()).Query<Entity>(unitId, self.key);
                if (entity != null)
                {
                    self.AddOrUpdate(entity);
                }
            }
            return entity;
        }
        
        public static void Delete(this UnitCache self, long id)
        {
            if (self.CacheCompoenntsDictionary.TryGetValue(id,out Entity entity))
            {
                entity.Dispose();
                self.CacheCompoenntsDictionary.Remove(id);
            }
        }
    }
}