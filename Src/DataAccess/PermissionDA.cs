/*----------------------------------------------------------------
      // Copyright (C) 2008 北京拓扑工厂科技发展有限公司
      // 文件名：Permission.cs
      // 文件功能描述：用户及权限接口本地实现类
      //
      // 
      // 创建标识：XXX-2011-02-22
      //
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Wis.Anes.BusinessEntity;
using System.IO;
using Wis.Anes.Data;
using System.Data.Common;

namespace Wis.Anes.DataAccess
{
    /// <summary>
    /// 用户及权限接口本地实现类
    /// </summary>
    public partial class PermissionDA 
    {
        /// <summary>
        /// 获取角色表信息
        /// </summary>
        /// <returns></returns>
        public Permissions.RolesDataTable GetRoles()
        {
            Permissions.RolesDataTable data = new Permissions.RolesDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("MyDataSet_GetRoles");
            database.Fill(sql, data);
            return data;
        }

        public Permissions.RolesDataTable GetRolesByAppId(string appID)
        {
            Permissions.RolesDataTable data = new Permissions.RolesDataTable();
            string sql = StoredScript.Get("MyDataSet_GetRolesByAppId");

            IDatabase database = DatabaseFactory.Create();
            DbParameter appIdParameter = database.BuildDbParameter("appID", DbType.String, appID);
            database.Fill(sql, data, new DbParameter[] { appIdParameter });
            return data;
        }

        public int UpdateRoles(Permissions.RolesDataTable dataTable)
        {
            IDatabase database = DatabaseFactory.Create();
            return database.Update(dataTable, "WIS_PERM_ROLE");
        }

        public Permissions.ApplicationsDataTable GetApplication()
        {
            Permissions.ApplicationsDataTable data = new Permissions.ApplicationsDataTable();

            string sql = StoredScript.Get("MyDataSet_GetApplication");
            IDatabase database = DatabaseFactory.Create();
            database.Fill(sql, data);
            return data;
        }

        public Permissions.UsersApplicationsDataTable GetUsersApplication()
        {
            Permissions.UsersApplicationsDataTable data = new Permissions.UsersApplicationsDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("MyDataSet_GetUsersApplication");
            database.Fill(sql, data);
            return data;
        }

        public Permissions.UsersRolesDataTable GetUserRolesByUserID(string userID)
        {
            Permissions.UsersRolesDataTable data = new Permissions.UsersRolesDataTable();
            IDatabase database = DatabaseFactory.Create();

            string sql = StoredScript.Get("MyDataSet_GetUserRolesByUserID");
            DbParameter userIdParameter = database.BuildDbParameter("userID", DbType.String, userID);
            database.Fill(sql, data, new DbParameter[] { userIdParameter });
            return data;
        }

        public int UpdateUserRole(Permissions.UsersRolesDataTable dataTable)
        {
            IDatabase database = DatabaseFactory.Create();
            return database.Update(dataTable, "WIS_PERM_USER_ROLE");
        }

        public Permissions.PermissiosDataTable GetPermissions()
        {
            Permissions.PermissiosDataTable data = new Permissions.PermissiosDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("MyDataSet_GetPermissions");
            database.Fill(sql, data);
            return data;
        }

        public Permissions.PermissiosDataTable GetPermissionByAppId(string appID)
        {
            Permissions.PermissiosDataTable data = new Permissions.PermissiosDataTable();
            IDatabase database = DatabaseFactory.Create();

            string sql = StoredScript.Get("MyDataSet_GetPermissionByAppId");
            DbParameter appIdParameter = database.BuildDbParameter("appID", DbType.String, appID);
            database.Fill(sql, data, new DbParameter[] { appIdParameter });
            return data;
        }

        public Permissions.PermissiosDataTable GetPermissionByLoginName(string appID, string loginName)
        {
            Permissions.PermissiosDataTable data = new Permissions.PermissiosDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("MyDataSet_GetPermissionByLoginName");
            DbParameter appIDParameter = database.BuildDbParameter("APP_ID", DbType.String, appID);
            DbParameter loginNameParameter = database.BuildDbParameter("LoginName", DbType.String, loginName);
            database.Fill(sql, data, new DbParameter[] {appIDParameter, loginNameParameter });
            return data;
        }

        public int UpdatePermission(Permissions.PermissiosDataTable dataTable)
        {
            IDatabase database = DatabaseFactory.Create();
            return database.Update(dataTable, "WIS_PERM_INDEX ");
        }

        public Permissions.RolespermissionsDataTable GetRolePermissionByRoleID(string roleID)
        {
            Permissions.RolespermissionsDataTable data = new Permissions.RolespermissionsDataTable();
            IDatabase database = DatabaseFactory.Create();

            string sql = StoredScript.Get("MyDataSet_GetRolePermissionByRoleID");
            DbParameter roleIdParameter = database.BuildDbParameter("roleID", DbType.String, roleID);
            database.Fill(sql, data, new DbParameter[] { roleIdParameter });
            return data;
        }

        public int UpdateRolePermission(Permissions.RolespermissionsDataTable dataTable)
        {
            IDatabase database = DatabaseFactory.Create();
            return database.Update(dataTable, "WIS_PERM_ROLE_PERMISSION");
        }

        public Permissions.UsersDataTable GetUsers()
        {
            Permissions.UsersDataTable data = new Permissions.UsersDataTable();
            IDatabase database = DatabaseFactory.Create();

            string sql = StoredScript.Get("MyDataSet_GetUsers");


            database.Fill(sql, data);
            return data;
        }

        public Permissions.UsersDataTable GetUserByUserName(string userName)
        {
            Permissions.UsersDataTable data = new Permissions.UsersDataTable();
            IDatabase database = DatabaseFactory.Create();

            string sql = StoredScript.Get("MyDataSet_GetUserByUserName");
            DbParameter userNameParameter = database.BuildDbParameter("LoginName", DbType.String, userName);
            database.Fill(sql, data, new DbParameter[] { userNameParameter });
            return data;
        }

        public Permissions.UsersDataTable GetUserByUserAndPwd(string loginName, string password)
        {
            Permissions.UsersDataTable data = new Permissions.UsersDataTable();
            IDatabase database = DatabaseFactory.Create();

            string sql = StoredScript.Get("MyDataSet_GetUserByUserAndPwd");
            DbParameter loginNameParameter = database.BuildDbParameter("LoginName", DbType.String, loginName);
            DbParameter passwordParameter = database.BuildDbParameter("LoginPwd", DbType.String, password);

            database.Fill(sql, data, new DbParameter[] { loginNameParameter, passwordParameter });
            return data;
        }

        public int UpdateUsers(Permissions.UsersDataTable dataTable)
        {
            IDatabase database = DatabaseFactory.Create();
            return database.Update(dataTable, "WIS_PERM_USER");
        }

        public int UpdateUsersPwd(string userName, string password)
        {
            Permissions.UsersDataTable data = new Permissions.UsersDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("MyDataSet_GetUserByUserName");
            DbParameter userNameParameter = database.BuildDbParameter("LoginName", DbType.String, userName);
            database.Fill(sql, data, new DbParameter[] { userNameParameter });

            if (data != null && data.Count == 1)
            {
                data[0].LOGIN_PWD = password;
                return database.Update(data, "WIS_PERM_USER");
            }
            return 0;

        }
        /// <summary>
        /// 得到权限分类管理表
        /// </summary>
        /// <param name="appID"></param>
        /// <returns></returns>
        public Permissions.WIS_PERM_KINDDataTable GetPerKindByAppId(string appID)
        {
            Permissions.WIS_PERM_KINDDataTable data = new Permissions.WIS_PERM_KINDDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("MyDataSet_GetPerKindByAppId");
            DbParameter appIdParameter = database.BuildDbParameter("appID", DbType.String, appID);
            database.Fill(sql, data, new DbParameter[] { appIdParameter });

            return data;
        }

        /// <summary>
        /// 新增修改权限分类管理表
        /// </summary>
        /// <param name="PerKindTable"></param>
        /// <returns></returns>
        public int UpdatePerKind(Permissions.WIS_PERM_KINDDataTable PerKindTable)
        {
            IDatabase database = DatabaseFactory.Create();
            return database.Update(PerKindTable, "WIS_PERM_KIND ");
        }

        /// <summary>
        /// 更新权限分类关系表
        /// </summary>
        /// <param name="PerKindRelaTable"></param>
        /// <returns></returns>
        public int UpdatePerKindRela(Permissions.WIS_PERM_KIND_RELADataTable PerKindRelaTable)
        {
            IDatabase database = DatabaseFactory.Create();
            return database.Update(PerKindRelaTable, "WIS_PERM_KIND_RELA");
        }

        /// <summary>
        /// 获得权限分类关系表
        /// </summary>
        /// <returns></returns>
        public Permissions.WIS_PERM_KIND_RELADataTable GetPerKindRela()
        {
            Permissions.WIS_PERM_KIND_RELADataTable data = new Permissions.WIS_PERM_KIND_RELADataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("MyDataSet_GetPerKindRela");
            database.Fill(sql, data);
            return data;
        }

        /// <summary>
        /// 根据权限ID得到 权限分类关系表
        /// </summary>
        /// <param name="Permission_ID"></param>
        /// <returns></returns>
        public Permissions.WIS_PERM_KIND_RELADataTable GetPerKindRelaByID(string Permission_ID)
        {
            Permissions.WIS_PERM_KIND_RELADataTable data = new Permissions.WIS_PERM_KIND_RELADataTable();
            IDatabase database = DatabaseFactory.Create();

            string sql = StoredScript.Get("MyDataSet_GetPerKindRelaByID");
            DbParameter permissionId = database.BuildDbParameter("PERMISSION_ID", DbType.String, Permission_ID);
            database.Fill(sql, data, new DbParameter[] { permissionId });
            return data;
        }

        public Permissions.UsersHisUsersDataTable GetUsersHisUsers()
        {
            return DatabaseFactory.Create().GetTable<Permissions.UsersHisUsersDataTable>("WIS_PERM_USER_HISUSER");
        }

        public int UpdateUsersHisUsers(Permissions.UsersHisUsersDataTable dataTahle)
        {
            return DatabaseFactory.Create().Update(dataTahle, "WIS_PERM_USER_HISUSER");
        }










        #region 手术等级

        public DataTable GetUserList()
        {
            DataTable data = new DataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("OperationScale_GetUserList");
            database.Fill(sql, data);
            return data;
        }
        public DataTable GetOperationList(string Dept_Code)
        {
            DataTable data = new DataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("OperationScale_GetOperationList");
            DbParameter appIdParameter = database.BuildDbParameter("Dept_Code", DbType.String, Dept_Code);
            database.Fill(sql, data, new DbParameter[] { appIdParameter });
            return data;
        }



        public Common.OPER_SCALE_CONFIGDataTable GetOperationScaleConfig()
        {
            return DatabaseFactory.Create().GetTable<Common.OPER_SCALE_CONFIGDataTable>("MED_OPER_SCALE_CONFIG");
        }

        public int UpdateOperationScaleConfig(Common.OPER_SCALE_CONFIGDataTable dataTahle)
        {
            return DatabaseFactory.Create().Update(dataTahle, "MED_OPER_SCALE_CONFIG");
        }
        public int UpdateOperationScaleConfigDept(Common.MED_USER_VS_OPERSCALEDataTable dataTahle)
        {
            return DatabaseFactory.Create().Update(dataTahle, "MED_USER_VS_OPERSCALE");
        }
        public Common.OPER_SCALE_CONFIGDataTable GetOperationScaleConfigByUserID(string userID)
        {
            Common.OPER_SCALE_CONFIGDataTable data = new Common.OPER_SCALE_CONFIGDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("OperationScale_GetOperationListByUserID");
            DbParameter appIdParameter = database.BuildDbParameter("USERID", DbType.String, userID);
            database.Fill(sql, data, new DbParameter[] { appIdParameter });

            return data;
        }

        public Common.MED_USER_VS_OPERSCALEDataTable GetOperationConfigByDeptCode(string Dept_Code)
        {
            Common.MED_USER_VS_OPERSCALEDataTable data = new Common.MED_USER_VS_OPERSCALEDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("OperationScale_GetOperationConfigByDeptCode");
            DbParameter appIdParameter = database.BuildDbParameter("Dept_Code", DbType.String, Dept_Code);
            database.Fill(sql, data, new DbParameter[] { appIdParameter });

            return data;
        }

        #endregion


    }
}
