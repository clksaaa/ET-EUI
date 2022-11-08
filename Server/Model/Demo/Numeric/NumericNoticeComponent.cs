using System.Collections.Generic;

namespace ET
{
    /// <summary>
    /// 数值组件 更新时通知客户端进行同步
    /// </summary>
    [ComponentOf(typeof(Unit))]
    public class NumericNoticeComponent : Entity,IAwake
    {
        public M2C_NoticeUnitNumeric NoticeUnitNumericMessage = new M2C_NoticeUnitNumeric();
    }
}