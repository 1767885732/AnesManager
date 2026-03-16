using System;
using System.Collections.Generic;
using System.Text;
using Wis.AccessControl.Entity;
using System.Data;
using Newtonsoft.Json;
using Wis.AccessControl.RowMapper;
using Devart.Data.Oracle;

namespace Wis.AccessControl.Provider.SqlSeverProvider
{
    public partial class SqlSeverAccessControlProvider
    {
        const string ROLE_INSERT = "INSERT INTO MED_IMEDICAL_ROLES (ROLE_ID, APP_FLAG, ROLE_NAME, DESCRIPTION, EXTEND_INFO) VALUES (:ROLE_ID, :APP_FLAG, :ROLE_NAME, :DESCRIPTION, :EXTEND_INFO)";
        public override void CreateRole(Role role)
        {
            _daoTemplate.Insert
            (
                ROLE_INSERT,
                new IDataParameter[]
                {
                    new OracleParameter("ROLE_ID", role.ID),
                    new OracleParameter("APP_FLAG", role.AppFlag),
                    new OracleParameter("ROLE_NAME", role.Name),
                    new OracleParameter("DESCRIPTION", role.Description),
                    new OracleParameter("EXTEND_INFO", JsonConvert.SerializeObject(role.ExtendInfoDict))
                }
            );
        }
        const string ROLE_DELETE_BY_ID = "DELETE FROM MED_IMEDICAL_ROLES WHERE ROLE_ID = :ROLE_ID";

        public override int DeleteRoleByID(string id)
        {
            int rowCount = _daoTemplate.Delete
            (
                ROLE_DELETE_BY_ID,
                new IDataParameter[]
                    {
                        new OracleParameter("ROLE_ID", id)
                    }
            );
            return rowCount;
        }

        public override int DeleteRoleByName(string name)
        {
            Role role = GetRoleByName(name);
            if (role == null) 
                return 0;
            return DeleteRoleByID(role.ID);
        }


        const string ROLE_REMOVE_ALL_ROLE_BY_USER_ID = "DELETE FROM MED_IMEDICAL_USERS_ROLES WHERE USER_ID = :USER_ID";
   
        public override int RemoveAllRoleByUserID(string userID)
        {
            return _daoTemplate.Delete
            (
                ROLE_REMOVE_ALL_ROLE_BY_USER_ID, 
                new IDataParameter[] 
                { 
                    new OracleParameter("USER_ID", userID) 
                }
            );
        }

        const string ROLE_REMOVE_ALL_USER_FROM_ROLE = "DELETE FROM MED_IMEDICAL_USERS_ROLES WHERE ROLE_ID = :ROLE_ID";
  
        public override int RemoveAllUserFromRole(string roleID)
        {
            return _daoTemplate.Delete
            (
                ROLE_REMOVE_ALL_USER_FROM_ROLE,
                new IDataParameter[] 
                { 
                    new OracleParameter("ROLE_ID", roleID) 
                }
            );
        }
        const string UPDATE_ROLE_BY_ID = "UPDATE MED_IMEDICAL_ROLES SET APP_FLAG = :APP_FLAG, ROLE_NAME=:ROLE_NAME, DESCRIPTION=:DESCRIPTION, EXTEND_INFO=:EXTEND_INFO WHERE ROLE_ID = :ROLE_ID";
        public override int UpdateRole(Role role)
        {
            return _daoTemplate.Update
            (
                UPDATE_ROLE_BY_ID,
                new IDataParameter[]
                {
                    new OracleParameter("APP_FLAG", role.AppFlag),
                    new OracleParameter("ROLE_NAME", role.Name),
                    new OracleParameter("DESCRIPTION", role.Description),
                    new OracleParameter("EXTEND_INFO", JsonConvert.SerializeObject(role.ExtendInfoDict)),
                    new OracleParameter("ROLE_ID", role.ID)
                }
            );
        }

        const string GET_ROLE_BY_ID = "SELECT ROLE_ID, APP_FLAG, ROLE_NAME, DESCRIPTION, EXTEND_INFO FROM MED_IMEDICAL_ROLES WHERE ROLE_ID =:ROLE_ID";
        public override Role GetRoleByID(string roleID)
        {
            IList<Role> roles = _daoTemplate.Query<Role>
           (
                GET_ROLE_BY_ID,
                new IDataParameter[]
                {
                    new OracleParameter("ROLE_ID", roleID)
                },
                new RoleRowMapper()
            );
            if (roles.Count == 1)
                return roles[0];
            return null;
        }

        const string GET_ROLE_BY_NAME = "SELECT ROLE_ID, APP_FLAG, ROLE_NAME, DESCRIPTION, EXTEND_INFO FROM MED_IMEDICAL_ROLES WHERE ROLE_NAME =:ROLE_NAME";
        public override Role GetRoleByName(string roleName)
        {
            IList<Role> roles = _daoTemplate.Query<Role>
           (
                GET_ROLE_BY_NAME,
                new IDataParameter[]
                {
                    new OracleParameter("ROLE_NAME", roleName)
                },
                new RoleRowMapper()
            );
            if (roles.Count == 1)
                return roles[0];
            return null;
        }

        const string GET_ALL_ROLES = "SELECT ROLE_ID, APP_FLAG, ROLE_NAME, DESCRIPTION, EXTEND_INFO FROM MED_IMEDICAL_ROLES ";
        public override IList<Role> GetAllRoles()
        {
            return _daoTemplate.Query<Role>(GET_ALL_ROLES, new RoleRowMapper());
        }

        const string GET_ALL_ROLES_BY_APP_FLAG = "SELECT ROLE_ID, APP_FLAG, ROLE_NAME, DESCRIPTION, EXTEND_INFO FROM MED_IMEDICAL_ROLES WHERE APP_FLAG = :APP_FLAG";
        public override IList<Role> GetAllRolesByAppFlag(string appFlag)
        {
            return _daoTemplate.Query<Role>
            (
                GET_ALL_ROLES_BY_APP_FLAG,
                new IDataParameter[]
                {
                    new OracleParameter("APP_FLAG", appFlag)
                },
                new RoleRowMapper()
             );
        }

        const string GET_UNASSIGNED_ROLES_BY_USER_ID = "SELECT ROLE_ID, APP_FLAG, ROLE_NAME, DESCRIPTION, EXTEND_INFO FROM MED_IMEDICAL_ROLES WHERE ROLE_ID NOT IN ( SELECT ROLE_ID FROM MED_IMEDICAL_USERS_ROLES WHERE USER_ID = :USER_ID)";
        public override IList<Role> GetUnassignedRolesByUserID(string userID)
        {
            return _daoTemplate.Query<Role>
            (
                GET_UNASSIGNED_ROLES_BY_USER_ID,
                new IDataParameter[]
                {
                    new OracleParameter("USER_ID", userID)
                },
                new RoleRowMapper()
             );
        }

        const string GET_UNASSIGNED_ROLES_BY_USER_ID_AND_APP_FLAG = "SELECT ROLE_ID, APP_FLAG, ROLE_NAME, DESCRIPTION, EXTEND_INFO FROM MED_IMEDICAL_ROLES WHERE ROLE_ID NOT IN ( SELECT ROLE_ID FROM MED_IMEDICAL_USERS_ROLES WHERE USER_ID = :USER_ID) AND APP_FLAG = :APP_FLAG";
        public override IList<Role> GetUnassignedRolesByUserID(string userID, string appFlag)
        {
            return _daoTemplate.Query<Role>
            (
                GET_UNASSIGNED_ROLES_BY_USER_ID_AND_APP_FLAG,
                new IDataParameter[]
                {
                    new OracleParameter("USER_ID", userID),
                    new OracleParameter("APP_FLAG", appFlag)
                },
                new RoleRowMapper()
             );

        }

        public override IList<Role> GetUnassignedRolesByUserName(string userName)
        {
            User user = GetUserByName(userName);
            if (user == null)
                return new List<Role>();
            else
                return GetUnassignedRolesByUserID(user.ID);
        }

        public override IList<Role> GetUnassignedRolesByUserName(string userName, string appFlag)
        {
            User user = GetUserByName(userName);
            if (user == null)
                return new List<Role>();
            else
                return GetUnassignedRolesByUserID(user.ID, appFlag);
        }

        const string GET_ASSIGNED_ROLES_BY_USER_ID = "SELECT ROLE_ID, APP_FLAG, ROLE_NAME, DESCRIPTION, EXTEND_INFO FROM MED_IMEDICAL_ROLES WHERE ROLE_ID IN ( SELECT ROLE_ID FROM MED_IMEDICAL_USERS_ROLES WHERE USER_ID = :USER_ID)";
        public override IList<Role> GetAssignedRolesByUserID(string userID)
        {
            return _daoTemplate.Query<Role>
            (
                GET_ASSIGNED_ROLES_BY_USER_ID,
                new IDataParameter[]
                {
                    new OracleParameter("USER_ID", userID)
                },
                new RoleRowMapper()
             );
        }
        const string GET_ASSIGNED_ROLES_BY_USER_ID_AND_APP_FLAG = "SELECT ROLE_ID, APP_FLAG, ROLE_NAME, DESCRIPTION, EXTEND_INFO FROM MED_IMEDICAL_ROLES WHERE ROLE_ID IN ( SELECT ROLE_ID FROM MED_IMEDICAL_USERS_ROLES WHERE USER_ID = :USER_ID) AND APP_FLAG = :APP_FLAG";
        public override IList<Role> GetAssignedRolesByUserID(string userID, string appFlag)
        {
            return _daoTemplate.Query<Role>
            (
                GET_ASSIGNED_ROLES_BY_USER_ID_AND_APP_FLAG,
                new IDataParameter[]
                {
                    new OracleParameter("USER_ID", userID),
                    new OracleParameter("APP_FLAG", appFlag)
                },
                new RoleRowMapper()
             );
        }

        public override IList<Role> GetAssignedRolesByUserName(string userName)
        {
            User user = GetUserByName(userName);
            if (user == null)
                return new List<Role>();
            else
                return GetAssignedRolesByUserID(user.ID);
        }

        public override IList<Role> GetAssignedRolesByUserName(string userName, string appFlag)
        {
            User user = GetUserByName(userName);
            if (user == null)
                return new List<Role>();
            else
                return GetAssignedRolesByUserID(user.ID, appFlag);
        }

        const string ADD_USER_TO_ROLE = "INSERT INTO  MED_IMEDICAL_USERS_ROLES (USER_ID, ROLE_ID) VALUES (:USER_ID, :ROLE_ID) ";
        public override int AddUserToRole(string userID, string roleID)
        {
            return _daoTemplate.Insert
            (
                ADD_USER_TO_ROLE, 
                new IDataParameter[] 
                {
                    new OracleParameter("USER_ID", userID), 
                    new OracleParameter("ROLE_ID", roleID) 
                }
             );
        }
        const string REMOVE_USER_FROM_ROLE = "DELETE FROM MED_IMEDICAL_USERS_ROLES WHERE USER_ID = :USER_ID AND ROLE_ID = :ROLE_ID";
        public override int RemoveUserFromRole(string userID, string roleID)
        {
            return _daoTemplate.Delete
            (
                REMOVE_USER_FROM_ROLE,
                new IDataParameter[] 
                {
                    new OracleParameter("USER_ID", userID), 
                    new OracleParameter("ROLE_ID", roleID) 
                }
            );
        }

        public override int AddUsersToRole(string[] userIDs, string roleID)
        {
            int rowCount = 0;
            try
            {
                _daoTemplate.BeginTransaction();
                foreach (string userID in userIDs)
                {
                    rowCount += AddUserToRole(userID, roleID);
                }
                _daoTemplate.CommitTransaction();
                return rowCount;
            }
            finally
            {
                _daoTemplate.RollbackTransaction();
            }
        }

        public override int RemoveUsersFromRole(string[] userIDs, string roleID)
        {
            int rowCount = 0;
            try
            {
                _daoTemplate.BeginTransaction();
                foreach (string userID in userIDs)
                {
                    rowCount += RemoveUserFromRole(userID, roleID);
                }
                _daoTemplate.CommitTransaction();
                return rowCount;
            }
            finally
            {
                _daoTemplate.RollbackTransaction();
            }
        }

        public override int AddUserToRoles(string userID, string[] roleIDs)
        {
            int rowCount = 0;
            try
            {
                _daoTemplate.BeginTransaction();
                foreach (string roleID in roleIDs)
                {
                    rowCount += AddUserToRole(userID, roleID);
                }
                _daoTemplate.CommitTransaction();
                return rowCount;
            }
            finally
            {
                _daoTemplate.RollbackTransaction();
            }
        }

        public override int RemoveUserFromRoles(string userID, string[] roleIDs)
        {
            int rowCount = 0;
            try
            {
                _daoTemplate.BeginTransaction();
                foreach (string roleID in roleIDs)
                {
                    rowCount += RemoveUserFromRole(userID, roleID);
                }
                _daoTemplate.CommitTransaction();
                return rowCount;
            }
            finally
            {
                _daoTemplate.RollbackTransaction();
            }
        }

        public override int AddUsersToRoles(string[] userIDs, string[] roleIDs)
        {
            int rowCount = 0;
            try
            {
                _daoTemplate.BeginTransaction();
                foreach (string userID in userIDs)
                {
                    foreach (string roleID in roleIDs)
                    {
                        rowCount += AddUserToRole(userID, roleID);
                    }
                }
                _daoTemplate.CommitTransaction();
                return rowCount;
            }
            finally
            {
                _daoTemplate.RollbackTransaction();
            }
        }

        public override int RemoveUsersFromRoles(string[] userIDs, string[] roleIDs)
        {
            int rowCount = 0;
            try
            {
                _daoTemplate.BeginTransaction();
                foreach (string userID in userIDs)
                {
                    foreach (string roleID in roleIDs)
                    {
                        rowCount += RemoveUserFromRole(userID, roleID);
                    }
                }
                _daoTemplate.CommitTransaction();
                return rowCount;
            }
            finally
            {
                _daoTemplate.RollbackTransaction();
            }
        }

        const string IS_USER_IN_ROLE = "SELECT COUNT(*) FROM MED_IMEDICAL_USERS_ROLES WHERE USER_ID = :USER_ID AND ROLE_ID = :ROLE_ID";

        public override bool IsUserInRole(string userID, string roleID)
        {
            object obj = _daoTemplate.ExecuteScalar
            (
                IS_USER_IN_ROLE,
                new IDataParameter[] 
                {
                    new OracleParameter("USER_ID", userID),
                    new OracleParameter("ROLE_ID", roleID)
                }
            );
            int count = Convert.ToInt32(obj);
            return (count == 0);
        }
        const string IS_USER_IN_ROLES = "SELECT COUNT(*) FROM MED_IMEDICAL_USERS_ROLES WHERE USER_ID = '{0}' AND ROLE_ID IN ({1})";
        public override bool IsUserInRoles(string userID, string[] roleIDs)
        {
            string inSql = string.Empty;
            foreach (string roleID in roleIDs)
            {
                inSql += "'" + roleID + "'";
            }
            string sql = string.Format(IS_USER_IN_ROLES, userID, inSql);

            object obj = _daoTemplate.ExecuteScalar(sql);
            int count = Convert.ToInt32(obj);
            return (count == roleIDs.Length);

        }
        const string IS_USERS_IN_ROLE = "SELECT COUNT(*) FROM MED_IMEDICAL_USERS_ROLES WHERE USER_ID IN ({0}) AND ROLE_ID = '{1}'";
        public override bool IsUsersInRole(string[] userIDs, string roleID)
        {
            string inUserSql = string.Empty;
            foreach (string userID in userIDs)
            {
                inUserSql += "'" + userID + "'";
            }
            string sql = string.Format(IS_USERS_IN_ROLE, inUserSql, roleID);

            object obj = _daoTemplate.ExecuteScalar(sql);
            int count = Convert.ToInt32(obj);
            return (count == userIDs.Length);
        }
        const string IS_USERS_IN_ROLES = "SELECT COUNT(*) FROM MED_IMEDICAL_USERS_ROLES WHERE USER_ID IN ({0}) AND ROLE_ID IN ({1})";
        public override bool IsUsersInRoles(string[] userIDs, string[] roleIDs)
        {
            string inUserSql = string.Empty;
            foreach (string userID in userIDs)
            {
                inUserSql += "'" + userID + "'";
            }
            string inRoleSql = string.Empty;
            foreach (string roleID in roleIDs)
            {
                inRoleSql += "'" + roleID + "'";
            }
            string sql = string.Format(IS_USERS_IN_ROLES, inUserSql, inRoleSql);

            object obj = _daoTemplate.ExecuteScalar(sql);
            int count = Convert.ToInt32(obj);
            return (count == (userIDs.Length * roleIDs.Length));
        }

        const string ADD_PERMISSION_TO_ROLE = "INSERT INTO MED_IMEDICAL_ROLES_PERMISSIONS (ROLE_ID, PERMISSION_ID) VALUES  (:ROLE_ID, :PERMISSION_ID)";
        public override int AddPermissionToRole(string permissionID, string roleID)
        {
            return _daoTemplate.Insert
            (
                ADD_PERMISSION_TO_ROLE,
                new IDataParameter[]
                {
                    new OracleParameter("ROLE_ID", roleID),
                    new OracleParameter("PERMISSION_ID", permissionID),
                }
            );
        }

        public override int AddPermissionsToRole(string[] permissionIDs, string roleID)
        {
            try
            {
                _daoTemplate.BeginTransaction();
                int rowCount = 0;
                foreach (string permissionID in permissionIDs)
                {
                    rowCount += AddPermissionToRole(permissionID, roleID);
                }
                _daoTemplate.CommitTransaction();
                return rowCount;
            }
            finally
            {
                _daoTemplate.RollbackTransaction();
            }
        }

        public override int AddPermissionsToRoles(string[] permissionIDs, string[] roleIDs)
        {
            try
            {
                _daoTemplate.BeginTransaction();
                int rowCount = 0;
                foreach (string permissionID in permissionIDs)
                {
                    foreach (string roleID in roleIDs)
                    {
                        rowCount += AddPermissionToRole(permissionID, roleID);
                    }
                }
                _daoTemplate.CommitTransaction();
                return rowCount;
            }
            finally
            {
                _daoTemplate.RollbackTransaction();
            }
        }

        public override int AddPermissionToRoles(string permissionID, string[] roleIDs)
        {
            try
            {
                _daoTemplate.BeginTransaction();
                int rowCount = 0;
                foreach (string roleID in roleIDs)
                {
                    rowCount += AddPermissionToRole(permissionID, roleID);
                }
                _daoTemplate.CommitTransaction();
                return rowCount;
            }
            finally
            {
                _daoTemplate.RollbackTransaction();
            }
        }

        const string REMOVE_PERMISSION_FROM_ROLE = "DELETE FROM MED_IMEDICAL_ROLES_PERMISSIONS WHERE PERMISSION_ID = :PERMISSION_ID AND ROLE_ID = :ROLE_ID";
        public override int RemovePermissionFromRole(string permissionID, string roleID)
        {
            return _daoTemplate.Delete
            (
                REMOVE_PERMISSION_FROM_ROLE,
                new IDataParameter[]
                {
                    new OracleParameter("PERMISSION_ID", permissionID),
                    new OracleParameter("ROLE_ID", roleID)
                }
             );
        }

        public override int RemovePermissionsFromRole(string[] permissionIDs, string roleID)
        {
            try
            {
                _daoTemplate.BeginTransaction();
                int rowCount = 0;
                foreach (string permissionID in permissionIDs)
                {
                    rowCount += RemovePermissionFromRole(permissionID, roleID);
                }
                _daoTemplate.CommitTransaction();
                return rowCount;
            }
            finally
            {
                _daoTemplate.RollbackTransaction();
            }
        }

        public override int RemovePermissionsFromRoles(string[] permissionIDs, string[] roleIDs)
        {
            try
            {
                _daoTemplate.BeginTransaction();
                int rowCount = 0;
                foreach (string permissionID in permissionIDs)
                {
                    foreach (string roleID in roleIDs)
                    {
                        rowCount += RemovePermissionFromRole(permissionID, roleID);
                    }
                }
                _daoTemplate.CommitTransaction();
                return rowCount;
            }
            finally
            {
                _daoTemplate.RollbackTransaction();
            }
        }

        public override int RemovePermissionFromRoles(string permissionID, string[] roleIDs)
        {
            try
            {
                _daoTemplate.BeginTransaction();
                int rowCount = 0;
                foreach (string roleID in roleIDs)
                {
                    rowCount += RemovePermissionFromRole(permissionID, roleID);
                }
                _daoTemplate.CommitTransaction();
                return rowCount;
            }
            finally
            {
                _daoTemplate.RollbackTransaction();
            }
        }

        const string REMOVE_ALL_PERMISSION_FROM_ROLE = "DELETE FORM MED_IMEDICAL_ROLES_PERMISSIONS WHERE ROLE_ID = :ROLE_ID ";
        public override int RemovePermissionFromRole(string roleID)
        {
            return _daoTemplate.Delete
            (
                REMOVE_ALL_PERMISSION_FROM_ROLE,
                new IDataParameter[]
                {
                    new OracleParameter("ROLE_ID", roleID)
                }
             );
        }




    }
}
