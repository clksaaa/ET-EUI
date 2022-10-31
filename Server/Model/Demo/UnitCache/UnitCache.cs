using System.Collections.Generic;

namespace ET
{

    public interface IUnitCache
    {
        
    }
    
    /// <summary>
    /// unit缓存 实体
    /// </summary>
    public class UnitCache : Entity,IAwake,IDestroy
    {
        //实体类型的名称
        public string key;

        //key  unit(Entity他俩保持一致)的Id      
        public Dictionary<long, Entity> CacheCompoenntsDictionary = new Dictionary<long, Entity>();
    }
}