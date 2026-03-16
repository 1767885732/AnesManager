using System;
using System.Collections.Generic;
using System.Text;
using Wis.AccessControl.Entity;
using Wis.AccessControl.Provider;

namespace Wis.AccessControl.API
{
    public static class PermissionAPI
    {
        static AccessControlProvider Provider
        {
            get { return AccessControlProvider.DefaultProvider; }
        }

        public static void CreatePermission(Permission permission)
        {
            Provider.CreatePermission(permission);
        }

        public static int DeletePermissionByID(string permissionID)
        {
            return Provider.DeletePermissionByID(permissionID);
        }

        public static int UpdatePermission(Permission permission)
        {
            return Provider.UpdatePermission(permission);
        }

        public static IList<Permission> GetAllPermission()
        {
            return Provider.GetAllPermission();
        }

        public static IList<Permission> GetAllPermissionByAppFlag(string appFlag)
        {
            return Provider.GetAllPermissionByAppFlag(appFlag);
        }

        public static IList<Permission> GetPermissionsByUserID(string userID)
        {
            return Provider.GetPermissionsByUserID(userID);
        }

        public static IList<Permission> GetPermissionsByUserID(string userID, string appFlag)
        {
            return Provider.GetPermissionsByUserID(userID, appFlag);
        }

        public static IList<Permission> GetPermissionsByRoleID(string roleID)
        {
            return Provider.GetPermissionsByRoleID(roleID);
        }

        public static Permission GetPermissionByID(string permissionID)
        {
            return Provider.GetPermissionByID(permissionID);
        }

        public static IList<Permission> GetPermissionByResourceID(string resourceID)
        {
            return Provider.GetPermissionByResourceID(resourceID);
        }

        public static int RemoveRoleByPermissionID(string permissionID)
        {
            return Provider.RemoveRoleByPermissionID(permissionID);
        }

        public static bool AuthenticateUser(string userID, string resourceID, OperationEnum op)
        {
            return Provider.AuthenticateUser(userID, resourceID, op);
        }

        public static bool AuthenticateRole(string roleID, string resourceID, OperationEnum op)
        {
            return Provider.AuthenticateRole(roleID, resourceID, op);
        }
    }
}
