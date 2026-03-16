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
        const string INSERT_PERMISSION = "INSERT INTO MED_IMEDICAL_PERMISSIONS (PERMISSION_ID, PERMISSION_NAME, RESOURCE_ID, OPERATION, ALLOWED, EXTEND_INFO, APP_FLAG ) VALUES (:PERMISSION_ID, :PERMISSION_NAME, :RESOURCE_ID, :OPERATION, :ALLOWED, :EXTEND_INFO, :APP_FLAG )";
        public override void CreatePermission(Permission permission)
        {
            _daoTemplate.Insert
            (
                INSERT_PERMISSION,
                new IDataParameter[]
                {
                    new OracleParameter("PERMISSION_ID", permission.ID),
                    new OracleParameter("PERMISSION_NAME", permission.Name),
                    new OracleParameter("RESOURCE_ID", permission.ResourceID),
                    new OracleParameter("OPERATION", (int)permission.Operation),
                    new OracleParameter("ALLOWED", (permission.Allowed?1:0)),
                    new OracleParameter("EXTEND_INFO", JsonConvert.SerializeObject( permission.ExtendInfoDict)),
                    new OracleParameter("APP_FLAG", permission.AppFlag)
                }
            );
        }

        const string DELETE_PERMISSION_BY_ID = "DELETE FROM MED_IMEDICAL_PERMISSIONS WHERE PERMISSION_ID = :PERMISSION_ID";
        public override int DeletePermissionByID(string permissionID)
        {
            int rowCount = _daoTemplate.Delete
           (
               DELETE_PERMISSION_BY_ID,
               new IDataParameter[]
                    {
                        new OracleParameter("PERMISSION_ID", permissionID)
                    }
           );
            return rowCount;
        }

        const string UPDATE_PERMISSION_BY_ID = "UPDATE MED_IMEDICAL_PERMISSIONS SET PERMISSION_NAME = :PERMISSION_NAME, RESOURCE_ID = :RESOURCE_ID, OPERATION = :OPERATION, ALLOWED = :ALLOWED, EXTEND_INFO = :EXTEND_INFO, APP_FLAG = :APP_FLAG WHERE PERMISSION_ID = :PERMISSION_ID";
        public override int UpdatePermission(Permission permission)
        {
            return _daoTemplate.Update
            (
                UPDATE_PERMISSION_BY_ID,
                new IDataParameter[]
                {
                    new OracleParameter("PERMISSION_ID", permission.ID),
                    new OracleParameter("PERMISSION_NAME", permission.Name),
                    new OracleParameter("RESOURCE_ID", permission.ResourceID),
                    new OracleParameter("OPERATION", (int)permission.Operation),
                    new OracleParameter("ALLOWED", (permission.Allowed?1:0)),
                    new OracleParameter("EXTEND_INFO", JsonConvert.SerializeObject( permission.ExtendInfoDict)),
                    new OracleParameter("APP_FLAG", permission.AppFlag)
                }
            );
        }

        const string GET_PERMISSION_BY_ID = "SELECT PERMISSION_ID, PERMISSION_NAME, RESOURCE_ID, OPERATION, ALLOWED, EXTEND_INFO, APP_FLAG FROM MED_IMEDICAL_PERMISSIONS WHERE PERMISSION_ID = :PERMISSION_ID";
        public override Permission GetPermissionByID(string permissionID)
        {
            IList<Permission> permissionList = _daoTemplate.Query<Permission>
            (
                GET_PERMISSION_BY_ID,
                new IDataParameter[]
                {
                    new OracleParameter("PERMISSION_ID", permissionID)
                },
                new PermissionRowMapper()
            );
            if (permissionList.Count == 1)
                return permissionList[0];
            return null;
        }

        const string GET_ALL_PERMISSION = "SELECT PERMISSION_ID, PERMISSION_NAME, RESOURCE_ID, OPERATION, ALLOWED, EXTEND_INFO, APP_FLAG FROM MED_IMEDICAL_PERMISSIONS";
        public override IList<Permission> GetAllPermission()
        {
            return _daoTemplate.Query<Permission>
           (
               GET_ALL_PERMISSION,
               new PermissionRowMapper()
           );
        }

        const string GET_ALL_PERMISSION_BY_APP_FLAG = "SELECT PERMISSION_ID, PERMISSION_NAME, RESOURCE_ID, OPERATION, ALLOWED, EXTEND_INFO, APP_FLAG FROM MED_IMEDICAL_PERMISSIONS WHERE APP_FLAG = :APP_FLAG";
        public override IList<Permission> GetAllPermissionByAppFlag(string appFlag)
        {
            return _daoTemplate.Query<Permission>
            (
                GET_ALL_PERMISSION_BY_APP_FLAG,
                new IDataParameter[]
                {
                    new OracleParameter("APP_FLAG", appFlag)
                },
                new PermissionRowMapper()
            );
        }

        const string GET_PERMISSIONS_BY_USER_ID =
@"SELECT  t1.PERMISSION_ID, t1.PERMISSION_NAME, t1.RESOURCE_ID, 
        t1.OPERATION, t1.ALLOWED, t1.EXTEND_INFO,
        t1.APP_FLAG FROM MED_IMEDICAL_PERMISSIONS t1
JOIN MED_IMEDICAL_ROLES_PERMISSIONS t2 ON t2.PERMISSION_ID = t1.permission_id
JOIN MED_IMEDICAL_USERS_ROLES t3 ON t2.role_id = t3.role_id
WHERE t3.user_id = :USER_ID";
        public override IList<Permission> GetPermissionsByUserID(string userID)
        {
            return _daoTemplate.Query<Permission>
            (
                GET_PERMISSIONS_BY_ROLE_ID,
                new IDataParameter[]
                {
                    new OracleParameter("USER_ID", userID)
                },
                new PermissionRowMapper()
            );
        }

        const string GET_PERMISSIONS_BY_USER_ID_AND_APP_FLAG =
@"SELECT  t1.PERMISSION_ID, t1.PERMISSION_NAME, t1.RESOURCE_ID, 
        t1.OPERATION, t1.ALLOWED, t1.EXTEND_INFO,
        t1.APP_FLAG FROM MED_IMEDICAL_PERMISSIONS t1
JOIN MED_IMEDICAL_ROLES_PERMISSIONS t2 ON t2.PERMISSION_ID = t1.permission_id
JOIN MED_IMEDICAL_USERS_ROLES t3 ON t2.role_id = t3.role_id
WHERE t3.user_id = :USER_ID AND t1.APP_FLAG = :APP_FLAG";
        public override IList<Permission> GetPermissionsByUserID(string userID, string appFlag)
        {
            return _daoTemplate.Query<Permission>
            (
                GET_PERMISSIONS_BY_USER_ID_AND_APP_FLAG,
                new IDataParameter[]
                {
                    new OracleParameter("USER_ID", userID),
                    new OracleParameter("APP_FLAG", appFlag)
                },
                new PermissionRowMapper()
            );
        }

        const string GET_PERMISSIONS_BY_ROLE_ID =
@"SELECT  t1.PERMISSION_ID, t1.PERMISSION_NAME, t1.RESOURCE_ID, 
        t1.OPERATION, t1.ALLOWED, t1.EXTEND_INFO,
        t1.APP_FLAG FROM MED_IMEDICAL_PERMISSIONS t1
JOIN MED_IMEDICAL_ROLES_PERMISSIONS t2 ON t2.permission_id = t1.permission_id
WHERE t2.role_id = :ROLE_ID";

        public override IList<Permission> GetPermissionsByRoleID(string roleID)
        {
            return _daoTemplate.Query<Permission>
            (
                GET_PERMISSIONS_BY_ROLE_ID,
                new IDataParameter[]
                {
                    new OracleParameter("ROLE_ID", roleID)
                },
                new PermissionRowMapper()
            );
        }

        const string GET_PERMISSIONS_BY_RESOURCE_ID = "SELECT PERMISSION_ID, PERMISSION_NAME, RESOURCE_ID, OPERATION, ALLOWED, EXTEND_INFO, APP_FLAG FROM MED_IMEDICAL_PERMISSIONS WHERE RESOURCE_ID = :RESOURCE_ID";
        public override IList<Permission> GetPermissionByResourceID(string resourceID)
        {
            return _daoTemplate.Query<Permission>
            (
                GET_PERMISSIONS_BY_RESOURCE_ID,
                new IDataParameter[]
                {
                    new OracleParameter("RESOURCE_ID", resourceID),
                },
                new PermissionRowMapper()
            );
        }

        const string REMOVE_ROLE_BY_PERMISSION_ID = "DELETE FORM MED_IMEDICAL_ROLES_PERMISSIONS WHERE PERMISSION_ID = :PERMISSION_ID ";
        public override int RemoveRoleByPermissionID(string permissionID)
        {
            return _daoTemplate.Delete
            (
                REMOVE_ROLE_BY_PERMISSION_ID,
                new IDataParameter[]
                {
                    new OracleParameter("PERMISSION_ID", permissionID)
                }
             );
        }

        const string REMOVE_PERMISSION_BY_RESOURCE_ID = "DELETE FROM MED_IMEDICAL_PERMISSIONS WHERE RESOURCE_ID = :RESOURCE_ID";
        public override int RemovePermissionByResourceID(string resourceID)
        {
            return _daoTemplate.Delete
            (
                REMOVE_PERMISSION_BY_RESOURCE_ID,
                new IDataParameter[]
                {
                    new OracleParameter("RESOURCE_ID", resourceID)
                }
            );
        }
        const string AUTHENTICATE_USER = @"select count(t1.permission_id) from MED_IMEDICAL_PERMISSIONS t1
join MED_IMEDICAL_ROLES_PERMISSIONS t2 on t1.permission_id = t2.permission_id 
join MED_IMEDICAL_USERS_ROLES t3 on t2.role_id = t3.role_id
where t3.user_id = :USER_ID and t1.resource_id = :RESOURCE_ID and t1.operation = :OP and allowed = 1";

        public override bool AuthenticateUser(string userID, string resourceID, OperationEnum op)
        {
            object count = _daoTemplate.ExecuteScalar
            (
                AUTHENTICATE_USER,
                new IDataParameter[]
                {
                    new OracleParameter("USER_ID", userID),
                    new OracleParameter("RESOURCE_ID", resourceID),
                    new OracleParameter("OP", (int)op)
                }
            );

            return (Convert.ToInt32(count) == 1);
        }

        const string AUTHENTICATE_ROLE = @"select count(t1.permission_id) from MED_IMEDICAL_PERMISSIONS t1
join MED_IMEDICAL_ROLES_PERMISSIONS t2 on t1.permission_id = t2.permission_id 
join MED_IMEDICAL_USERS_ROLES t3 on t2.role_id = t3.role_id
where t3.role_id = :ROLE_ID and t1.resource_id = :RESOURCE_ID and t1.operation = :OP and allowed = 1";
        public override bool AuthenticateRole(string roleID, string resourceID, OperationEnum op)
        {
            object count = _daoTemplate.ExecuteScalar
            (
                AUTHENTICATE_ROLE,
                new IDataParameter[]
                {
                    new OracleParameter("ROLE_ID", roleID),
                    new OracleParameter("RESOURCE_ID", resourceID),
                    new OracleParameter("OP", (int)op)
                }
            );

            return (Convert.ToInt32(count) > 0);
        }
    }
}
