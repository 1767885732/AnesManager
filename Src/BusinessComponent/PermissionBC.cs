using System;
using System.Collections.Generic;
using System.Text;
using Wis.Anes.Interface;
using Wis.Anes.BusinessEntity;
using Wis.Anes.DataAccess;
using Wis.Anes.Framework;

namespace Wis.Anes.BusinessComponent
{

    public class PermissionBC : IPermission
    {
        public  Permissions.RolesDataTable GetRoles()
        {
            try
            {
                return (new PermissionDA()).GetRoles();
            }
            catch (Exception ex)
            {
                 throw ex;
            }
        }
        public  Permissions.RolesDataTable GetRolesByAppId(string appID)
        {
            try
            {
                return (new PermissionDA()).GetRolesByAppId(appID);
            }
            catch (Exception ex)
            {
                 throw ex;

            }
        }
        public  int UpdateRoles(Permissions.RolesDataTable dataTable)
        {
            try
            {
                return (new PermissionDA()).UpdateRoles(dataTable);
            }
            catch (Exception ex)
            {
                 throw ex;

            }
        }
        public  Permissions.PermissiosDataTable GetPermissions()
        {
            try
            {
                return (new PermissionDA()).GetPermissions();
            }
            catch (Exception ex)
            {
                 throw ex;

            }
        }
        public  Permissions.ApplicationsDataTable GetApplication()
        {
            try
            {
                return (new PermissionDA()).GetApplication();
            }
            catch (Exception ex)
            {
                 throw ex;
            }
        }
        public  Permissions.UsersDataTable GetUsers()
        {
            try
            {
                return (new PermissionDA()).GetUsers();
            }
            catch (Exception ex)
            {
                 throw ex;
            }
        }
        public  Permissions.UsersDataTable GetUserByUserAndPwd(string loginName, string password)
        {
            try
            {
                return (new PermissionDA()).GetUserByUserAndPwd(loginName, password);
            }
            catch (Exception ex)
            {
                 throw ex;
            }
        }
        public  int UpdateUsers(Permissions.UsersDataTable dataTable)
        {
            try
            {
                return (new PermissionDA()).UpdateUsers(dataTable);
            }
            catch (Exception ex)
            {
                 throw ex;
            }
        }
        public  Permissions.UsersApplicationsDataTable GetUsersApplication()
        {
            try
            {
                return (new PermissionDA()).GetUsersApplication();
            }
            catch (Exception ex)
            {
                 throw ex;
            }
        }
        public  Permissions.UsersRolesDataTable GetUserRolesByUserID(string userID)
        {
            try
            {
                return (new PermissionDA()).GetUserRolesByUserID(userID);
            }
            catch (Exception ex)
            {
                 throw ex;
            }
        }
        public  int UpdateUserRole(Permissions.UsersRolesDataTable dataTable)
        {
            try
            {
                return (new PermissionDA()).UpdateUserRole(dataTable);
            }
            catch (Exception ex)
            {
                 throw ex;
            }
        }
        public  Permissions.PermissiosDataTable GetPermissionByAppId(string appID)
        {
            try
            {
                return (new PermissionDA()).GetPermissionByAppId(appID);
            }
            catch (Exception ex)
            {
                 throw ex;
            }
        }
        public  Permissions.PermissiosDataTable GetPermissionByLoginName(string appID, string loginName, ref Exception error)
        {
            try
            {
                return (new PermissionDA()).GetPermissionByLoginName(appID, loginName);
            }
            catch (Exception ex)
            {
                error = ex;
                 throw ex;
            }
        }
        public Permissions.PermissiosDataTable GetPermissionByLoginName(string appID, string loginName)
        {
            try
            {
                return (new PermissionDA()).GetPermissionByLoginName(appID, loginName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public  int UpdatePermission(Permissions.PermissiosDataTable dataTable)
        {
            try
            {
                return (new PermissionDA()).UpdatePermission(dataTable);
            }
            catch (Exception ex)
            {
                 throw ex;
            }
        }
        public  Permissions.RolespermissionsDataTable GetRolePermissionByRoleID(string roleID)
        {
            try
            {
                return (new PermissionDA()).GetRolePermissionByRoleID(roleID);
            }
            catch (Exception ex)
            {
                 throw ex;
            }
        }
        public  int UpdateRolePermission(Permissions.RolespermissionsDataTable dataTable)
        {
            try
            {
                return (new PermissionDA()).UpdateRolePermission(dataTable);
            }
            catch (Exception ex)
            {
                 throw ex;
            }
        }
        public  int UpdateUsersPwd(string userName, string password)
        {
            try
            {
                return (new PermissionDA()).UpdateUsersPwd(userName, password);
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
        public  Permissions.WIS_PERM_KINDDataTable GetPerKindByAppId(string appID)
        {

            try
            {
                return (new PermissionDA()).GetPerKindByAppId(appID);
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
        public  int UpdatePerKind(Permissions.WIS_PERM_KINDDataTable PerKindTable)
        {
            try
            {
                return (new PermissionDA()).UpdatePerKind(PerKindTable);
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
        public  int UpdatePerKindRela(Permissions.WIS_PERM_KIND_RELADataTable PerKindRelaTable)
        {
            try
            {
                return (new PermissionDA()).UpdatePerKindRela(PerKindRelaTable);
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
        public  Permissions.WIS_PERM_KIND_RELADataTable GetPerKindRela()
        {
            try
            {
                return (new PermissionDA()).GetPerKindRela();
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
        public  Permissions.WIS_PERM_KIND_RELADataTable GetPerKindRelaByID(string Permission_ID)
        {
            try
            {
                return (new PermissionDA()).GetPerKindRelaByID(Permission_ID);
            }
            catch (Exception ex)
            {
                 throw ex;
            }
        }

        public  Permissions.UsersHisUsersDataTable GetUsersHisUsers()
        {
            try
            {
                return (new PermissionDA()).GetUsersHisUsers();
            }
            catch (Exception ex)
            {
                 throw ex;
            }
        }

        public  int UpdateUsersHisUsers(Permissions.UsersHisUsersDataTable dataTahle)
        {
            try
            {
                return (new PermissionDA()).UpdateUsersHisUsers(dataTahle);
            }
            catch (Exception ex)
            {
                 throw ex;
            }
        }

    }
}
