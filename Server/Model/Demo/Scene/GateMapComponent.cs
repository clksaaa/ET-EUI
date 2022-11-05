namespace ET
{
    /// <summary>
    /// 存储player所属地的Map 
    /// </summary>
    [ComponentOf(typeof(Player))]
    public class GateMapComponent: Entity, IAwake
    {
        public Scene Scene;
    }
}