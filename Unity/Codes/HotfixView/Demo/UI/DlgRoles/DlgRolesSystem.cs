using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace ET
{
    [FriendClass(typeof (DlgRoles))]
    [FriendClass(typeof (RoleInfosComponent))]
    [FriendClass(typeof (RoleInfo))]
    public static class DlgRolesSystem
    {
        public static void RegisterUIEvent(this DlgRoles self)
        {
            self.View.E_StartGameButton.AddListenerAsync(() => { return self.OnStartGameClickHandler(); });
            self.View.E_CreateRoleButton.AddListenerAsync(() => { return self.OnCreateSoleClickHandler(); });
            self.View.E_DelectRoleButton.AddListenerAsync(() => { return self.OnDelectSoleClickHandler(); });

            self.View.E_RolesLoopHorizontalScrollRect.AddItemRefreshListener((transform, index) =>
            {
                self.OnRoleListRefreshHandler(transform, index);
            });
        }

        public static void ShowWindow(this DlgRoles self, Entity contextData = null)
        {
            self.RefreshRoleItems();
        }

        public static async void OnRoleListRefreshHandler(this DlgRoles self, Transform transform, int index)
        {
            Scroll_Item_Role scrollItemRole = self.ScrollItemRoles[index].BindTrans(transform);
            RoleInfo info = self.ZoneScene().GetComponent<RoleInfosComponent>().RoleInfos[index];

            scrollItemRole.E_RoleImage.color = info.Id == self.ZoneScene().GetComponent<RoleInfosComponent>().CurrentRoleId? Color.green : Color.gray;
            scrollItemRole.E_RoleNameTextMeshProUGUI.SetText(info.Name);
            scrollItemRole.E_RoleButton.AddListener(() => { self.OnRoleItemClickHandler(info.Id); });
        }

        //刷新需要展示的数据
        public static void RefreshRoleItems(this DlgRoles self)
        {
            int count = self.ZoneScene().GetComponent<RoleInfosComponent>().RoleInfos.Count;
            self.AddUIScrollItems(ref self.ScrollItemRoles, count);
            self.View.E_RolesLoopHorizontalScrollRect.SetVisible(true, count);
        }

        public static void OnRoleItemClickHandler(this DlgRoles self, long roleId)
        {
            self.ZoneScene().GetComponent<RoleInfosComponent>().CurrentRoleId = roleId;
            self.View.E_RolesLoopHorizontalScrollRect.RefillCells();
        }

        public static async ETTask OnDelectSoleClickHandler(this DlgRoles self)
        {
            if (self.ZoneScene().GetComponent<RoleInfosComponent>().CurrentRoleId == 0)
            {
                Log.Error("请选择需要删除的角色");
                return;
            }

            try
            {
                int errorCode = await LoginHelper.DeleteRole(self.ZoneScene());
                if (errorCode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorCode.ToString());
                    return;
                }

                self.RefreshRoleItems();
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }
        }

        public static async ETTask OnCreateSoleClickHandler(this DlgRoles self)
        {
            string name = self.View.E_RoleNameTMP_InputField.text;
            if (string.IsNullOrEmpty(name))
            {
                Log.Error("Name is Null");
                return;
            }

            try
            {
                int errorCode = await LoginHelper.CreateRole(self.ZoneScene(), name);
                if (errorCode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorCode.ToString());
                    return;
                }

                self.RefreshRoleItems();
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }
        }

        public static async ETTask OnStartGameClickHandler(this DlgRoles self)
        {
            if (self.ZoneScene().GetComponent<RoleInfosComponent>().CurrentRoleId == 0)
            {
                Log.Error("请选择角色");
                return;
            }

            try
            {
                int errorCode = await LoginHelper.GetRealmKey(self.ZoneScene());
                if (errorCode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorCode.ToString());
                    return;
                }

                // 进入游戏
                errorCode = await LoginHelper.EnterGame(self.ZoneScene());
                if (errorCode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorCode.ToString());
                    return;
                }

                await self?.ZoneScene()?.GetComponent<UIComponent>()?.ShowWindowAsync(WindowID.WindowID_Main);
                self?.ZoneScene()?.GetComponent<UIComponent>()?.CloseWindow(WindowID.WindowID_Roles);
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }
        }
    }
}