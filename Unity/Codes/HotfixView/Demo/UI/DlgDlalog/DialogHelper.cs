namespace ET
{
    public static class DialogHelper
    {
        public static async void ShowDialogMessage(this Entity self, string title, string context)
        {
            var data = new DialogShowData();
            data.title = title;
            data.context = context;
            self.ZoneScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Dlalog, new ShowWindowData() { contextData = data });
            await TimerComponent.Instance.WaitAsync(1000);
            self.ZoneScene().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Dlalog);
        }
    }
}