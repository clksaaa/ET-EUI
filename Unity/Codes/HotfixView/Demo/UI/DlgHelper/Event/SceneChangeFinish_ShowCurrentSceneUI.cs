namespace ET
{
    
    public class SceneChangeFinish_ShowCurrentSceneUI: AEventAsync<EventType.SceneChangeFinish>
    {
        /// <summary>
        /// 场景切换完毕
        /// </summary>
        /// <param name="args"></param>
        protected override async ETTask Run(EventType.SceneChangeFinish args)
        {
           
            args.ZoneScene.GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Main);

            args.ZoneScene.GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Loading);
            await ETTask.CompletedTask;
        }
    }
    
}