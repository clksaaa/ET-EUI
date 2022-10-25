namespace ET
{
    public static class ES_DiaLogWindowUISystem
    {
        public static  void SetContext(this ES_DiaLogWindow self,string title,string context )
        {
            self.E_TitleTextMeshProUGUI.text = title;
            self.E_ContextTextMeshProUGUI.text = context;
        }
    }
}