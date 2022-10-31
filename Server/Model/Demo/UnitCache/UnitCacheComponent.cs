using System.Collections.Generic;

namespace ET
{
    /// <summary>
    /// UnitCache管理组件
    /// </summary>
    [ComponentOf(typeof(Scene))]
    [ChildType(typeof(UnitCache))]
    public class UnitCacheComponent : Entity,IAwake,IDestroy
    {
        //key  实体组件的类型名称   value   缓存信息
        public Dictionary<string, UnitCache> UnitCaches = new Dictionary<string, UnitCache>();

        //在执行Awake方法时  会遍历程序集中继承了IUnitCache接口的类型  并记录下来  
        public List<string> UnitCacheKeyList = new List<string>();

    }
}