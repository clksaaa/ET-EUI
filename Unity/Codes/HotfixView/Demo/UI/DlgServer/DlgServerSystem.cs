using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
    [FriendClass(typeof (DlgServer))]
    [FriendClass(typeof (ServerInfosComponent))]
    [FriendClass(typeof (ServerInfo))]
    public static class DlgServerSystem
    {
        public static void RegisterUIEvent(this DlgServer self)
        {
            self.View.E_ConfirmButton.AddListenerAsync(() => { return self.OnConfirmClickHandler(); });
            self.View.E_ServerInfoListLoopVerticalScrollRect.AddItemRefreshListener((transform, index) =>
            {
                self.OnScrollItemRefreshHandler(transform, index);
            });
        }

        public static void ShowWindow(this DlgServer self, Entity contextData = null)
        {
            //初始化列表
            //获取区服列表
            int count = self.ZoneScene().GetComponent<ServerInfosComponent>().ServerInfoList.Count;
            Log.Debug("区服数量 ："+count);
            //添加Item数据
            self.AddUIScrollItems(ref self.ScrollItemServerInfos,count);
            self.View.E_ServerInfoListLoopVerticalScrollRect.SetVisible(true,count);
        }

        public static void HideWindow(this DlgServer self)
        {
            //移除Item数据
            self.RemoveUIScrollItems(ref self.ScrollItemServerInfos);
        }

        public static void OnScrollItemRefreshHandler(this DlgServer self, Transform transform, int index)
        {
            //Log.Debug("数据索引:"+index);
            Scroll_Item_ServerInfo serverTest = self.ScrollItemServerInfos[index].BindTrans(transform);
            ServerInfo info = self.ZoneScene().GetComponent<ServerInfosComponent>().ServerInfoList[index];
            serverTest.E_SelectImage.color = info.Id == self.ZoneScene().GetComponent<ServerInfosComponent>().CurrentServerId? Color.red : Color.yellow;
            serverTest.E_ServerTipTextMeshProUGUI.SetText(info.ServerName);
            serverTest.E_SelectButton.AddListener(() => {  self.OnSelectServerItemHandler(info.Id);  });
        }
        public static void OnSelectServerItemHandler(this DlgServer self, long serverId)
        {
            self.ZoneScene().GetComponent<ServerInfosComponent>().CurrentServerId = int.Parse(serverId.ToString()) ;
            Log.Debug($"当前选择的服务器 Id 是:{serverId}");
            //书信列表中的Item
            self.View.E_ServerInfoListLoopVerticalScrollRect.RefillCells();
        }
        public static async ETTask OnConfirmClickHandler(this DlgServer self)
        {
            bool isSelect = self.ZoneScene().GetComponent<ServerInfosComponent>().CurrentServerId != 0;

            if (!isSelect)
            {
                Log.Error("请先选择区服");
                return;
            }

            try
            {
                int errorCode = await LoginHelper.GetRoles(self.ZoneScene());
                if (errorCode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorCode.ToString());
                    return;
                }
				//选择角色界面
                self.ZoneScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Roles);
                self.ZoneScene().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Server);
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }
        }
    }
}