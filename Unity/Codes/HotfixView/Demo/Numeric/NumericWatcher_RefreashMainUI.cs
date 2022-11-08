namespace ET
{
    /// <summary>
    /// 刷新主页面需要更新的数据    需要监听的数值[NumericWatcher(NumericType.Level)] 用这个标签进行标记
    /// </summary>
    [NumericWatcher(NumericType.Level)]
    [NumericWatcher(NumericType.Gold)]
    [NumericWatcher(NumericType.Exp)]
    public class NumericWatcher_RefreashMainUI: INumericWatcher
    {
        public void Run(EventType.NumbericChange args)
        {
            args.Parent.ZoneScene().GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.Refresh();
        }
    }
}