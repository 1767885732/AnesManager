using System;
using System.Collections.Generic;
using System.Text;
using Wis.Anes.Interface;
using Wis.Anes.BusinessComponent;
using Wis.Anes.BusinessEntity;

namespace Wis.Anes.ServiceProxies
{
    public class PermissionProxy
    {
        static IPermission _iPermission = new PermissionBC();

        public static Permissions.RolesDataTable GetRoles()
        {
            try
            {
                return _iPermission.GetRoles();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Permissions.RolesDataTable GetRolesByAppId(string appID)
        {
            try
            {
                return _iPermission.GetRolesByAppId(appID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int UpdateRoles(Permissions.RolesDataTable dataTable)
        {
            try
            {
                return _iPermission.UpdateRoles(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Permissions.PermissiosDataTable GetPermissions()
        {
            try
            {
                return _iPermission.GetPermissions();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Permissions.ApplicationsDataTable GetApplication()
        {
            try
            {
                return _iPermission.GetApplication();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Permissions.UsersDataTable GetUsers()
        {
            try
            {
                return _iPermission.GetUsers();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Permissions.UsersDataTable GetUserByUserAndPwd(string loginName, string password)
        {
            try
            {
                return _iPermission.GetUserByUserAndPwd(loginName, password);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int UpdateUsers(Permissions.UsersDataTable dataTable)
        {
            try
            {
                return _iPermission.UpdateUsers(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Permissions.UsersApplicationsDataTable GetUsersApplication()
        {
            try
            {
                return _iPermission.GetUsersApplication();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Permissions.UsersRolesDataTable GetUserRolesByUserID(string userID)
        {
            try
            {
                return _iPermission.GetUserRolesByUserID(userID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int UpdateUserRole(Permissions.UsersRolesDataTable dataTable)
        {
            try
            {
                return _iPermission.UpdateUserRole(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Permissions.PermissiosDataTable GetPermissionByAppId(string appID)
        {
            try
            {
                return _iPermission.GetPermissionByAppId(appID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Permissions.PermissiosDataTable GetPermissionByLoginName(string appID, string loginName, ref Exception error)
        {
            try
            {
                return _iPermission.GetPermissionByLoginName(appID, loginName);
            }
            catch (Exception ex)
            {
                error = ex;
                throw ex;
            }
        }
        public static Permissions.PermissiosDataTable GetPermissionByLoginName(string appID, string loginName)
        {
            try
            {
                return _iPermission.GetPermissionByLoginName(appID, loginName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int UpdatePermission(Permissions.PermissiosDataTable dataTable)
        {
            try
            {
                return _iPermission.UpdatePermission(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public static Permissions.RolespermissionsDataTable GetRolePermissionByRoleID(string roleID)
        {
            try
            {
                return _iPermission.GetRolePermissionByRoleID(roleID);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public static int UpdateRolePermission(Permissions.RolespermissionsDataTable dataTable)
        {
            try
            {
                return _iPermission.UpdateRolePermission(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int UpdateUsersPwd(string userName, string password)
        {
            try
            {
                return _iPermission.UpdateUsersPwd(userName, password);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 得到权限分类管理表
        /// </summary>
        /// <param name="appID"></param>
        /// <returns></returns>
        public static Permissions.WIS_PERM_KINDDataTable GetPerKindByAppId(string appID)
        {

            try
            {
                return _iPermission.GetPerKindByAppId(appID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 新增修改权限分类管理表
        /// </summary>
        /// <param name="PerKindTable"></param>
        /// <returns></returns>
        public static int UpdatePerKind(Permissions.WIS_PERM_KINDDataTable PerKindTable)
        {
            try
            {
                return _iPermission.UpdatePerKind(PerKindTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 更新权限分类关系表
        /// </summary>
        /// <param name="PerKindRelaTable"></param>
        /// <returns></returns>
        public static int UpdatePerKindRela(Permissions.WIS_PERM_KIND_RELADataTable PerKindRelaTable)
        {
            try
            {
                return _iPermission.UpdatePerKindRela(PerKindRelaTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获得权限分类关系表
        /// </summary>
        /// <returns></returns>
        public static Permissions.WIS_PERM_KIND_RELADataTable GetPerKindRela()
        {
            try
            {
                return _iPermission.GetPerKindRela();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 根据权限ID得到 权限分类关系表
        /// </summary>
        /// <param name="Permission_ID"></param>
        /// <returns></returns>
        public static Permissions.WIS_PERM_KIND_RELADataTable GetPerKindRelaByID(string Permission_ID)
        {
            try
            {
                return _iPermission.GetPerKindRelaByID(Permission_ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Permissions.UsersHisUsersDataTable GetUsersHisUsers()
        {
            try
            {
                return _iPermission.GetUsersHisUsers();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int UpdateUsersHisUsers(Permissions.UsersHisUsersDataTable dataTahle)
        {
            try
            {
                return _iPermission.UpdateUsersHisUsers(dataTahle);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
