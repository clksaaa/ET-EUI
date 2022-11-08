﻿using UnityEngine;

namespace ET
{
    /// <summary>
    /// 在显示层 构建Unit实例   加载资源显示
    /// </summary>
    [FriendClass(typeof(GlobalComponent))]
    public class AfterUnitCreate_CreateUnitView: AEventAsync<EventType.AfterUnitCreate>
    {
        protected override async ETTask Run(EventType.AfterUnitCreate args)
        {
            // Unit View层
            // 这里可以改成异步加载，demo就不搞了
            await ResourcesComponent.Instance.LoadBundleAsync("Knight.unity3d");
            GameObject bundleGameObject = (GameObject)ResourcesComponent.Instance.GetAsset("Knight.unity3d", "Knight");
	        
            GameObject go = UnityEngine.Object.Instantiate(bundleGameObject);
            //GameObject go = UnityEngine.Object.Instantiate(bundleGameObject,GlobalComponent.Instance.Unit,true);
            go.transform.SetParent(GlobalComponent.Instance.Unit,true);

            args.Unit.AddComponent<GameObjectComponent>().GameObject = go;
            args.Unit.AddComponent<AnimatorComponent>();
            args.Unit.Position = Vector3.zero;
            await ETTask.CompletedTask;

            // go.transform.position = args.Unit.Position;
            // args.Unit.AddComponent<GameObjectComponent>().GameObject = go;
            // args.Unit.AddComponent<AnimatorComponent>();
        }
    }
}