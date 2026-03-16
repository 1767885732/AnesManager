using System;
using System.Collections.Generic;
using System.Text;
using Wis.AccessControl.Provider;
using Wis.AccessControl.Entity;

namespace Wis.AccessControl.API
{
    public static class RoleAPI
    {
        static AccessControlProvider Provider
        {
            get { return AccessControlProvider.DefaultProvider; }
        }
        public static void CreateRole(Role role)
        {
            Provider.CreateRole(role);
        }
        public static int DeleteRoleByID(string id)
        {
            return Provider.DeleteRoleByID(id);
        }
        public static int DeleteRoleByName(string name)
        {
            return Provider.DeleteRoleByName(name);
        }

        public static int UpdateRole(Role role)
        {
            return Provider.UpdateRole(role);
        }

        public static Role GetRoleByID(string roleID)
        {
            return Provider.GetRoleByID(roleID);
        }
        public static Role GetRoleByName(string roleName)
        {
            return Provider.GetRoleByName(roleName);
        }
        public static IList<Role> GetAllRoles()
        {
            return Provider.GetAllRoles();
        }
        public static IList<Role> GetAllRolesByAppFlag(string appFlag)
        {
            return Provider.GetAllRolesByAppFlag(appFlag);
        }
        public static IList<Role> GetUnassignedRolesByUserID(string userID)
        {
            return Provider.GetUnassignedRolesByUserID(userID);
        }
        public static IList<Role> GetUnassignedRolesByUserID(string userID, string appFlag)
        {
            return Provider.GetUnassignedRolesByUserID(userID, appFlag);
        }
        public static IList<Role> GetUnassignedRolesByUserName(string userName)
        {
            return Provider.GetUnassignedRolesByUserName(userName);
        }
        public static IList<Role> GetUnassignedRolesByUserName(string userName, string appFlag)
        {
            return Provider.GetUnassignedRolesByUserName(userName, appFlag);
        }
        public static IList<Role> GetAssignedRolesByUserID(string userID)
        {
            return Provider.GetAssignedRolesByUserID(userID);
        }
        public static IList<Role> GetAssignedRolesByUserID(string userID, string appFlag)
        {
            return Provider.GetAssignedRolesByUserID(userID, appFlag);
        }
        public static IList<Role> GetAssignedRolesByUserName(string userName)
        {
            return Provider.GetAssignedRolesByUserName(userName);
        }
        public static IList<Role> GetAssignedRolesByUserName(string userName, string appFlag)
        {
            return Provider.GetAssignedRolesByUserName(userName, appFlag);
        }
        public static int AddUserToRole(string userID, string roleID)
        {
            return Provider.AddUserToRole(userID, roleID);
        }
        public static int RemoveUserFromRole(string userID, string roleID)
        {
            return Provider.RemoveUserFromRole(userID, roleID);
        }
        public static int AddUsersToRole(string[] userIDs, string roleID)
        {
            return Provider.AddUsersToRole(userIDs, roleID);
        }
        public static int RemoveUsersFromRole(string[] userIDs, string roleID)
        {
            return Provider.RemoveUsersFromRole(userIDs, roleID);
        }
        public static int AddUserToRoles(string userID, string[] roleIDs)
        {
            return Provider.AddUserToRoles(userID, roleIDs);
        }
        public static int RemoveUserFromRoles(string userID, string[] roleIDs)
        {
            return Provider.RemoveUserFromRoles(userID, roleIDs);
        }
        public static int AddUsersToRoles(string[] userIDs, string[] roleIDs)
        {
            return Provider.AddUsersToRoles(userIDs, roleIDs);
        }
        public static int RemoveUsersFromRoles(string[] userIDs, string[] roleIDs)
        {
            return Provider.RemoveUsersFromRoles(userIDs, roleIDs);
        }
        public static int RemoveAllRoleByUserID(string userID)
        {
            return Provider.RemoveAllRoleByUserID(userID);
        }
        public static int RemoveAllUserFromRole(string roleID)
        {
            return Provider.RemoveAllUserFromRole(roleID);
        }
        public static bool IsUserInRole(string userID, string roleID)
        {
            return Provider.IsUserInRole(userID, roleID);
        }
        public static bool IsUserInRoles(string userID, string[] roleIDs)
        {
            return Provider.IsUserInRoles(userID, roleIDs);
        }
        public static bool IsUsersInRole(string[] userIDs, string roleID)
        {
            return Provider.IsUsersInRole(userIDs, roleID);
        }
        public static bool IsUsersInRoles(string[] userIDs, string[] roleIDs)
        {
            return Provider.IsUsersInRoles(userIDs, roleIDs);
        }
        public static int AddPermissionToRole(string permissionID, string roleID)
        {
            return Provider.AddPermissionToRole(permissionID, roleID);
        }
        public static int AddPermissionsToRole(string[] permissionIDs, string roleID)
        {
            return Provider.AddPermissionsToRole(permissionIDs, roleID);
        }
        public static int AddPermissionsToRoles(string[] permissionIDs, string[] roleIDs)
        {
            return Provider.AddPermissionsToRoles(permissionIDs, roleIDs);
        }
        public static int AddPermissionToRoles(string permissionID, string[] roles)
        {
            return Provider.AddPermissionToRoles(permissionID, roles);
        }
        public static int RemovePermissionFromRole(string permissionID, string roleID)
        {
            return Provider.RemovePermissionFromRole(permissionID, roleID);
        }
        public static int RemovePermissionsFromRole(string[] permissionIDs, string roleID)
        {
            return Provider.RemovePermissionsFromRole(permissionIDs, roleID);
        }
        public static int RemovePermissionsFromRoles(string[] permissionIDs, string[] roleIDs)
        {
            return Provider.RemovePermissionsFromRoles(permissionIDs, roleIDs);
        }
        public static int RemovePermissionFromRoles(string permissionID, string[] roleIDs)
        {
            return Provider.RemovePermissionFromRoles(permissionID, roleIDs);
        }
        public static int RemovePermissionFromRole(string permissionID)
        {
            return Provider.RemovePermissionFromRole(permissionID);
        }
    }
}
