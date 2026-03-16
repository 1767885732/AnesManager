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

        const string INSERT_RESOURCE = "INSERT INTO MED_IMEDICAL_RESOURCES (RESOURCE_ID, RESOURCE_NAME, RESOURCE_IDENTIFIER, RESOURCE_TYPE, APP_FLAG, PARENT_ID, EXTEND_INFO, SORT_INDEX) VALUES (:RESOURCE_ID, :RESOURCE_NAME, :RESOURCE_IDENTIFIER, :RESOURCE_TYPE, :APP_FLAG, :PARENT_ID, :EXTEND_INFO, :SORT_INDEX)";

        public override void CreateResource(Resource resource)
        {
            _daoTemplate.Insert
           (
                INSERT_RESOURCE,
                new IDataParameter[]
                {
                    new OracleParameter("RESOURCE_ID", resource.ID),
                    new OracleParameter("RESOURCE_NAME", resource.Name),
                    new OracleParameter("RESOURCE_IDENTIFIER", resource.ResourceIdentifier),
                    new OracleParameter("RESOURCE_TYPE", (int)resource.ResourceType),
                    new OracleParameter("APP_FLAG", resource.AppFlag),
                    new OracleParameter("PARENT_ID", resource.ParentID),
                    new OracleParameter("EXTEND_INFO", JsonConvert.SerializeObject( resource.ExtendInfoDict)),
                    new OracleParameter("SORT_INDEX", resource.SortIndex)
                }
           );
        }

        const string DELETE_RESOURCE_BY_ID = "DELETE FROM MED_IMEDICAL_RESOURCES WHERE RESOURCE_ID = :RESOURCE_ID";
        public override int DeleteResourceByID(string resourceID)
        {
            return _daoTemplate.Delete
            (
                DELETE_RESOURCE_BY_ID,
                new IDataParameter[]
                    {
                        new OracleParameter("RESOURCE_ID", resourceID)
                    }
            );
        }
        const string DELETE_CHILD_BY_PARENT_ID = "DELETE FROM MED_IMEDICAL_RESOURCES WHERE PARENT_ID = :RESOURCE_ID";
        public override int DeleteChildByParentID(string resourceID)
        {
            int rowCount = _daoTemplate.Delete
            (
                DELETE_CHILD_BY_PARENT_ID,
                new IDataParameter[]
                    {
                        new OracleParameter("RESOURCE_ID", resourceID)
                    }
            );
            return rowCount;

        }

        const string UPDATE_RESOURCE_BY_ID = "UPDATE MED_IMEDICAL_RESOURCES SET RESOURCE_NAME = :RESOURCE_NAME, RESOURCE_IDENTIFIER = :RESOURCE_IDENTIFIER, RESOURCE_TYPE = :RESOURCE_TYPE , APP_FLAG = :APP_FLAG,  PARENT_ID = :PARENT_ID, EXTEND_INFO = :EXTEND_INFO, SORT_INDEX = :SORT_INDEX WHERE RESOURCE_ID = :RESOURCE_ID";
        public override int UpdateResource(Resource resource)
        {
            return _daoTemplate.Update
            (
                UPDATE_RESOURCE_BY_ID,
                new IDataParameter[]
                {
                    new OracleParameter("RESOURCE_ID", resource.ID),
                    new OracleParameter("RESOURCE_NAME", resource.Name),
                    new OracleParameter("RESOURCE_IDENTIFIER", resource.ResourceIdentifier),
                    new OracleParameter("RESOURCE_TYPE", (int)resource.ResourceType),
                    new OracleParameter("APP_FLAG", resource.AppFlag),
                    new OracleParameter("PARENT_ID", resource.ParentID),
                    new OracleParameter("EXTEND_INFO", JsonConvert.SerializeObject( resource.ExtendInfoDict)),
                    new OracleParameter("SORT_INDEX", resource.SortIndex)
                }
             );
        }

        const string GET_RESOURCE_BY_ID = "SELECT RESOURCE_ID, RESOURCE_NAME, RESOURCE_IDENTIFIER, RESOURCE_TYPE, APP_FLAG, PARENT_ID, EXTEND_INFO, SORT_INDEX FROM MED_IMEDICAL_RESOURCES WHERE RESOURCE_ID = :RESOURCE_ID";
        public override Resource GetResourceByID(string resourceID)
        {
            IList<Resource> resourceList = _daoTemplate.Query<Resource>
           (
                GET_RESOURCE_BY_ID,
                new IDataParameter[]
                {
                    new OracleParameter("RESOURCE_ID", resourceID)
                },
                new ResourceRowMapper()
           );
            if (resourceList.Count == 1)
                return resourceList[0];
            return null;
        }


        const string GET_ALL_RESOURCE = "SELECT  RESOURCE_ID, RESOURCE_NAME, RESOURCE_IDENTIFIER, RESOURCE_TYPE, APP_FLAG, PARENT_ID, EXTEND_INFO, SORT_INDEX FROM MED_IMEDICAL_RESOURCES ORDER BY SORT_INDEX";
        public override IList<Resource> GetAllResource()
        {
            return _daoTemplate.Query<Resource>
              (
                   GET_ALL_RESOURCE,
                   new ResourceRowMapper()
              );
        }

        const string GET_ALL_RESOURCE_BY_APP_FLAG = "SELECT  RESOURCE_ID, RESOURCE_NAME, RESOURCE_IDENTIFIER, RESOURCE_TYPE, APP_FLAG, PARENT_ID, EXTEND_INFO, SORT_INDEX FROM MED_IMEDICAL_RESOURCES WHERE APP_FLAG = :APP_FLAG ORDER BY SORT_INDEX";
        public override IList<Resource> GetAllResourceByAppFlag(string appFlag)
        {
            return _daoTemplate.Query<Resource>
              (
                   GET_ALL_RESOURCE_BY_APP_FLAG,
                    new IDataParameter[]
                    {
                        new OracleParameter("APP_FLAG", appFlag)
                    },
                   new ResourceRowMapper()
              );

        }

        const string GET_RESOURCES_BY_USER_ID =
@"SELECT * FROM MED_IMEDICAL_RESOURCES WHERE RESOURCE_ID IN
(SELECT distinct t1.RESOURCE_ID FROM MED_IMEDICAL_RESOURCES t1
JOIN MED_IMEDICAL_PERMISSIONS t2 ON t1.RESOURCE_ID = t2.resource_id
JOIN MED_IMEDICAL_ROLES_PERMISSIONS t3 ON t2.PERMISSION_ID = t3.permission_id
JOIN MED_IMEDICAL_USERS_ROLES t4 ON t3.role_id = t4.role_id
JOIN WIS_PERM_USER t5 ON t5.USER_ID = t4.user_id
WHERE t4.user_id = :USER_ID )";

        public override IList<Resource> GetResourcesByUserID(string userID)
        {
            return _daoTemplate.Query<Resource>
              (
                   GET_ALL_RESOURCE,
                    new IDataParameter[]
                    {
                        new OracleParameter("USER_ID", userID)
                    },
                   new ResourceRowMapper()
              );
        }

        const string GET_RESOURCES_BY_USER_ID_AND_APP_FLAG =
@"SELECT * FROM MED_IMEDICAL_RESOURCES WHERE RESOURCE_ID IN
(SELECT distinct MED_IMEDICAL_RESOURCES.RESOURCE_ID FROM MED_IMEDICAL_RESOURCES
JOIN MED_IMEDICAL_PERMISSIONS ON MED_IMEDICAL_RESOURCES.RESOURCE_ID = MED_IMEDICAL_PERMISSIONS.resource_id
JOIN MED_IMEDICAL_ROLES_PERMISSIONS ON MED_IMEDICAL_PERMISSIONS.PERMISSION_ID = MED_IMEDICAL_ROLES_PERMISSIONS.permission_id
JOIN MED_IMEDICAL_USERS_ROLES ON MED_IMEDICAL_ROLES_PERMISSIONS.role_id = MED_IMEDICAL_USERS_ROLES.role_id
JOIN WIS_PERM_USER ON WIS_PERM_USER.USER_ID = MED_IMEDICAL_USERS_ROLES.user_id
WHERE MED_IMEDICAL_USERS_ROLES.user_id = :USER_ID AND MED_IMEDICAL_RESOURCES.APP_FLAG = :APP_FLAG )";

        public override IList<Resource> GetResourcesByUserID(string userID, string appFlag)
        {
            return _daoTemplate.Query<Resource>
              (
                   GET_RESOURCES_BY_USER_ID_AND_APP_FLAG,
                    new IDataParameter[]
                    {
                        new OracleParameter("USER_ID", userID),
                        new OracleParameter("APP_FLAG", appFlag)
                    },
                   new ResourceRowMapper()
              );
        }

        const string GET_RESOURCES_BY_ROLE_ID =
@"SELECT  t1.RESOURCE_ID, t1.RESOURCE_NAME, t1.RESOURCE_IDENTIFIER, 
        t1.RESOURCE_TYPE, t1.APP_FLAG, t1.PARENT_ID,
        t1.EXTEND_INFO, t1.SORT_INDEX FROM MED_IMEDICAL_RESOURCES t1
JOIN MED_IMEDICAL_PERMISSIONS t2 ON t1.RESOURCE_ID = t2.resource_id
JOIN MED_IMEDICAL_ROLES_PERMISSIONS t3 ON t2.PERMISSION_ID = t3.permission_id
WHERE t3.role_id = :ROLE_ID";
        public override IList<Resource> GetResourcesByRoleID(string roleID)
        {
            return _daoTemplate.Query<Resource>
              (
                   GET_RESOURCES_BY_ROLE_ID,
                    new IDataParameter[]
                    {
                        new OracleParameter("ROLE_ID", roleID)
                    },
                   new ResourceRowMapper()
              );
        }

    }
}
