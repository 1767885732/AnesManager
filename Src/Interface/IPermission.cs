/*----------------------------------------------------------------
 // Copyright (C) 2007 北京拓扑工厂科技发展有限公司
 // 文件名：IPermission.cs
 // 文件功能描述：
 //      用户及权限接口类
 // 
 // 创建标识：
 //     XXX 2011-2-22
 // 修改标识：
 // 修改描述：
 //
 // 修改标识：
 // 修改描述：
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using Wis.Anes.BusinessEntity;

namespace Wis.Anes.Interface
{
    /// <summary>
    /// 用户及权限接口类
    /// </summary>
    public interface IPermission
    {

        Permissions.RolesDataTable GetRoles();
        Permissions.RolesDataTable GetRolesByAppId(string appID);
        int UpdateRoles(Permissions.RolesDataTable dataTable);
        Permissions.PermissiosDataTable GetPermissions();
        Permissions.PermissiosDataTable GetPermissionByAppId(string appID);
        Permissions.PermissiosDataTable GetPermissionByLoginName(string appID, string loginName);
        int UpdatePermission(Permissions.PermissiosDataTable dataTable);
        Permissions.ApplicationsDataTable GetApplication();
        Permissions.UsersDataTable GetUsers();
        Permissions.UsersDataTable GetUserByUserAndPwd(string loginName, string password);
        int UpdateUsers(Permissions.UsersDataTable dataTable);
        Permissions.UsersApplicationsDataTable GetUsersApplication();
        Permissions.UsersRolesDataTable GetUserRolesByUserID(string userID);
        int UpdateUserRole(Permissions.UsersRolesDataTable dataTable);
        Permissions.RolespermissionsDataTable GetRolePermissionByRoleID(string roleID);
        int UpdateRolePermission(Permissions.RolespermissionsDataTable dataTable);
        int UpdateUsersPwd(string userName, string password);

        /// <summary>
        /// 得到权限分类管理表
        /// </summary>
        /// <param name="appID"></param>
        /// <returns></returns>
        Permissions.WIS_PERM_KINDDataTable GetPerKindByAppId(string appID);


        /// <summary>
        /// 新增修改权限分类管理表
        /// </summary>
        /// <param name="PerKindTable"></param>
        /// <returns></returns>
        int UpdatePerKind(Permissions.WIS_PERM_KINDDataTable PerKindTable);

        /// <summary>
        /// 更新权限分类关系表
        /// </summary>
        /// <param name="PerKindRelaTable"></param>
        /// <returns></returns>
        int UpdatePerKindRela(Permissions.WIS_PERM_KIND_RELADataTable PerKindRelaTable);

        /// <summary>
        /// 获得权限分类关系表
        /// </summary>
        /// <returns></returns>
        Permissions.WIS_PERM_KIND_RELADataTable GetPerKindRela();

        /// <summary>
        /// 根据权限ID得到 权限分类关系表
        /// </summary>
        /// <param name="Permission_ID"></param>
        /// <returns></returns>
        Permissions.WIS_PERM_KIND_RELADataTable GetPerKindRelaByID(string Permission_ID);

        Permissions.UsersHisUsersDataTable GetUsersHisUsers();
        int UpdateUsersHisUsers(Permissions.UsersHisUsersDataTable dataTahle);
    }
}
