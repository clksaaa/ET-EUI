using System;
using System.Text.RegularExpressions;

namespace ET
{
    [FriendClass(typeof (Account))]
    public class C2A_LoginAccountHandler: AMRpcHandler<C2A_LoginAccount, A2C_LoginAccount>
    {
        protected override async ETTask Run(Session session, C2A_LoginAccount request, A2C_LoginAccount response, Action reply)
        {
            if (session.DomainScene().SceneType != SceneType.Account)
            {
                Log.Error($"请求的Scene错误，当前Scene为：{session.DomainScene().SceneType}");
                session.Dispose();
                return;
            }

            session.RemoveComponent<SessionAcceptTimeoutComponent>();

            if (session.GetComponent<SessionLockingComponent>() != null)
            {
                response.Error = ErrorCode.ERR_RequestRepeatedly;
                reply();
                session.Disconnect().Coroutine();
                return;
            }

            if (string.IsNullOrEmpty(request.AccountName) || string.IsNullOrEmpty(request.Password))
            {
                response.Error = ErrorCode.ERR_LoginInfoIsNull;
                reply();
                session.Disconnect().Coroutine();
                return;
            }

            //包含大写小写和数字  6-15位
            if (!Regex.IsMatch(request.AccountName.Trim(), @"^(?=.*[0-9].*)(?=.*[A-Z].*)(?=.*[a-z].*).{6,15}$"))
            {
                response.Error = ErrorCode.ERR_AccountNameFormError;
                reply();
                session.Disconnect().Coroutine();
                return;
            }

            if (!Regex.IsMatch(request.Password.Trim(), @"^[A-Za-z0-9]+$"))
            {
                response.Error = ErrorCode.ERR_PasswordFormError;
                reply();
                session.Disconnect().Coroutine();
                return;
            }

            //使用using关键字   语句块执行完毕后 会自动释放  调用SessionLockingComponent。dispose
            using (session.AddComponent<SessionLockingComponent>())
            {
                using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginAccount, request.AccountName.Trim().GetHashCode()))
                {
                    var accountInfoList = await session.GetZoneDB().Query<Account>(d => d.AccountName.Equals(request.AccountName.Trim()));
                    Account account = null;
                    //数据库 有账户信息
                    if (accountInfoList != null && accountInfoList.Count > 0)
                    {
                        account = accountInfoList[0];
                        // session.GetComponent<AccountsZone>().AddChild(account);
                        session.AddChild(account);

                        if (account.AccountType == (int)AccountType.BlackList)
                        {
                            response.Error = ErrorCode.ERR_AccountInBlackListError;
                            reply();
                            session.Disconnect().Coroutine();
                            account?.Dispose();
                            return;
                        }

                        //判断密码对不对
                        if (!account.Password.Equals(request.Password))
                        {
                            response.Error = ErrorCode.ERR_LoginPasswordError;
                            reply();
                            session.Disconnect().Coroutine();
                            account?.Dispose();
                            return;
                        }
                    }
                    else
                    {
                        Log.Debug("创建新账户:"+request.AccountName);
                        // account             = session.GetComponent<AccountsZone>().AddChild<Account>();
                        account = session.AddChild<Account>();
                        account.AccountName = request.AccountName.Trim();
                        account.Password = request.Password;
                        account.CreateTime = TimeHelper.ServerNow();
                        account.AccountType = (int)AccountType.General;
                        // await DBManagerComponent.Instance.GetZoneDB(session.DomainZone()).Save<Account>(account);
                        await session.GetZoneDB().Save<Account>(account);
                    }

                    //登录中心服的配置
                    StartSceneConfig startSceneConfig = StartSceneConfigCategory.Instance.GetBySceneName(session.DomainZone(), "LoginCenter");
                    long loginCenterInstanceId = startSceneConfig.InstanceId;
                     var  loginAccountResponse=(L2A_LoginAccountResponse)await ActorMessageSenderComponent.Instance.Call(loginCenterInstanceId, new A2L_LoginAccountRequest() { AccountId = account.Id });

                     if (loginAccountResponse.Error!=ErrorCode.ERR_Success)
                     {

                         response.Error = loginAccountResponse.Error;
                         reply();
                         session.Disconnect().Coroutine();
                         account?.Dispose();
                         return;
                     }
                     
                    //从账号连接管理组建中查找这个连接session
                    long accountSessionInstanceId =session.DomainScene().GetComponent<AccountSessionsComponent>().Get(account.Id);

                    Session otherSession =Game.EventSystem.Get(accountSessionInstanceId) as Session;
                    //如果otherSession不等于null的话  说明这个账户已经登陆过了  需要发送断开链接的消息 并执行踢下线的操作
                    otherSession?.Send(new A2C_Disconnect(){Error = 0});
                    //断开连接
                    otherSession?.Disconnect().Coroutine();
                    //将新的session连接添加到 管理组件中
                    session.DomainScene().GetComponent<AccountSessionsComponent>().Add(account.Id,session.InstanceId);
                    session.AddComponent<AccountCheckOutTimeComponent, long>(account.Id);
                    
                    //随机令牌
                    string ToKen = TimeHelper.ServerNow().ToString() + RandomHelper.RandomNumber(int.MinValue, int.MaxValue).ToString();
                    session.DomainScene().GetComponent<TokenComponent>().Remove(account.Id);
                    session.DomainScene().GetComponent<TokenComponent>().Add(account.Id, ToKen);

                    response.AccountId = account.Id;
                    response.Token = ToKen;
                    reply();
                    account.Dispose();
                }
            }
        }
    }
}