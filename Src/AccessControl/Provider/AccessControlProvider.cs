using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration.Provider;
using Wis.AccessControl.Configuration;
using System.Configuration;
using System.Diagnostics;
using Wis.AccessControl.Entity;

namespace Wis.AccessControl.Provider
{
    public abstract class AccessControlProvider : ProviderBase
    {

        protected static UserSettings UserSettings
        {
            get { return ConfigurationHelper.UserSettings; }
        }
        protected static RoleSettings RoleSettings
        {
            get { return ConfigurationHelper.RoleSettings; }
        }
        protected static PermissionSettings PermissionSettings
        {
            get { return ConfigurationHelper.PermissionSettings; }
        }
        protected static ResourceSettings ResourceSettings
        {
            get { return ConfigurationHelper.ResourceSettings; }
        }
        protected static string UserTableName
        {
            get { return ConfigurationHelper.UserSettings.TableName; }
        }
        protected static string UserIDColumnName
        {
            get { return ConfigurationHelper.UserSettings.UserIDColumnName; }
        }
        protected static string UserNameColumnName
        {
            get { return ConfigurationHelper.UserSettings.UserNameColumnName; }
        }
        protected static string UserPasswordColumnName
        {
            get { return ConfigurationHelper.UserSettings.UserPasswordColumnName; }
        }

        static object _syncObj = new object();
        static AccessControlProvider _defaultProvider;
        internal static AccessControlProvider DefaultProvider
        {
            get
            {
                if (_defaultProvider == null)
                {
                    lock (_syncObj)
                    {
                        if (_defaultProvider == null)
                        {
                            AccessControlSettingSection section = ConfigurationManager.GetSection("accessControlSettings") as AccessControlSettingSection;
                            ProviderSettings defaultProvider = section.Providers[section.DefaultProvider];
                            Type permissionProviderType = Type.GetType(defaultProvider.Type, false);
                            _defaultProvider = Activator.CreateInstance(permissionProviderType) as AccessControlProvider;
                            _defaultProvider.Initialize(defaultProvider.Name, defaultProvider.Parameters);
                        }
                    }
                }
                return _defaultProvider;
            }
        }

        public abstract void CreateUser(User user);
        public abstract IList<User> GetAllUser(string where);
        public abstract int DeleteUserByID(string userID);
        public abstract int DeleteUserByName(string userName);
        public abstract int UpdateUser(User user);
        public abstract User GetUserByID(string userID);
        public abstract User GetUserByName(string userName);

        public abstract void CreateRole(Role role);
        public abstract int DeleteRoleByID(string id);
        public abstract int DeleteRoleByName(string name);
        public abstract int UpdateRole(Role role);
        public abstract Role GetRoleByID(string roleID);
        public abstract Role GetRoleByName(string roleName);
        public abstract IList<Role> GetAllRoles();
        public abstract IList<Role> GetUnassignedRolesByUserID(string userID);
        public abstract IList<Role> GetUnassignedRolesByUserName(string userName);
        public abstract IList<Role> GetAssignedRolesByUserID(string userID);
        public abstract IList<Role> GetAssignedRolesByUserName(string userName);
        public abstract IList<Role> GetAllRolesByAppFlag(string appFlag);
        public abstract IList<Role> GetUnassignedRolesByUserID(string userID, string appFlag);
        public abstract IList<Role> GetUnassignedRolesByUserName(string userName, string appFlag);
        public abstract IList<Role> GetAssignedRolesByUserID(string userID, string appFlag);
        public abstract IList<Role> GetAssignedRolesByUserName(string userName, string appFlag);
        public abstract int AddUserToRole(string userID, string roleID);
        public abstract int RemoveUserFromRole(string userID, string roleID);
        public abstract int AddUsersToRole(string[] userIDs, string roleID);
        public abstract int RemoveUsersFromRole(string[] userIDs, string roleID);
        public abstract int AddUserToRoles(string userID, string[] roleIDs);
        public abstract int RemoveUserFromRoles(string userID, string[] roleIDs);
        public abstract int AddUsersToRoles(string[] userIDs, string[] roleIDs);
        public abstract int RemoveUsersFromRoles(string[] userIDs, string[] roleIDs);
        public abstract int RemoveAllRoleByUserID(string userID);
        public abstract int RemoveAllUserFromRole(string roleID);
        public abstract bool IsUserInRole(string userID, string roleID);
        public abstract bool IsUserInRoles(string userID, string[] roleIDs);
        public abstract bool IsUsersInRole(string[] userIDs, string roleID);
        public abstract bool IsUsersInRoles(string[] userIDs, string[] roleIDs);
        public abstract int AddPermissionToRole(string permissionID, string roleID);
        public abstract int AddPermissionsToRole(string[] permissionIDs, string roleID);
        public abstract int AddPermissionsToRoles(string[] permissionIDs, string[] roleIDs);
        public abstract int AddPermissionToRoles(string permissionID, string[] roles);
        public abstract int RemovePermissionFromRole(string permissionID, string roleID);
        public abstract int RemovePermissionsFromRole(string[] permissionIDs, string roleID);
        public abstract int RemovePermissionsFromRoles(string[] permissionIDs, string[] roleIDs);
        public abstract int RemovePermissionFromRoles(string permissionID, string[] roleIDs);
        public abstract int RemovePermissionFromRole(string permissionID);

        public abstract void CreateResource(Resource resource);
        public abstract int DeleteResourceByID(string resourceID);
        //public abstract int DeleteResourceByName(string resourceName);
        public abstract int DeleteChildByParentID(string resourceID);
        public abstract int UpdateResource(Resource resource);
        public abstract Resource GetResourceByID(string resourceID);
        //public abstract Resource GetResourceByName(string resourceName);
        public abstract IList<Resource> GetAllResource();
        public abstract IList<Resource> GetResourcesByUserID(string userID);
        public abstract IList<Resource> GetResourcesByRoleID(string roleID);
        public abstract int RemovePermissionByResourceID(string resourceID);
        public abstract IList<Resource> GetAllResourceByAppFlag(string appFlag);
        public abstract IList<Resource> GetResourcesByUserID(string userID, string appFlag);
        //public abstract IList<Resource> GetResourcesByRoleID(string roleID, string appFlag);

        public abstract void CreatePermission(Permission permission);
        public abstract int DeletePermissionByID(string permissionID);
        public abstract int UpdatePermission(Permission permission);
        public abstract Permission GetPermissionByID(string permissionID);
        public abstract IList<Permission> GetAllPermission();
        public abstract IList<Permission> GetPermissionsByUserID(string userID);
        public abstract IList<Permission> GetPermissionsByRoleID(string roleID);
        public abstract int RemoveRoleByPermissionID(string permissionID);
        public abstract IList<Permission> GetAllPermissionByAppFlag(string appFlag);
        public abstract IList<Permission> GetPermissionsByUserID(string userID, string appFlag);
        //public abstract IList<Permission> GetPermissionsByRoleID(string roleID, string appFlag);
        public abstract IList<Permission> GetPermissionByResourceID(string resourceID);
        public abstract bool  AuthenticateUser(string userID, string resourceID, OperationEnum op);
        public abstract bool AuthenticateRole(string roleID, string resourceID, OperationEnum op);
    }
}