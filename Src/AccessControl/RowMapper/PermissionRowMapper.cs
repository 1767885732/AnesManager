using System;
using System.Collections.Generic;
using System.Text;
using Wis.AccessControl.Entity;
using System.Data.Common;
using System.Data;
using Wis.AccessControl.Configuration;
using Newtonsoft.Json;
using iMedical.CommonLib.SimpleDataAccessObject;

namespace Wis.AccessControl.RowMapper
{
    public class PermissionRowMapper : IRowMapper<Permission>
    {
        #region IRowMapper<Permission> 成员

        public Permission MapRow(IDataReader dataReader)
        {
            Permission permission = new Permission(RowMapperHelper.GetString(dataReader, "PERMISSION_ID"));
            permission.Name = RowMapperHelper.GetString(dataReader, "PERMISSION_NAME");
            permission.AppFlag = RowMapperHelper.GetString(dataReader, "APP_FLAG");
            permission.ResourceID = RowMapperHelper.GetString(dataReader, "RESOURCE_ID");
            permission.Operation = (OperationEnum)dataReader.GetInt32(dataReader.GetOrdinal("OPERATION"));
            permission.Allowed = dataReader.GetBoolean(dataReader.GetOrdinal("ALLOWED"));
            RowMapperHelper.FillExtendInfo(dataReader, permission);
            return permission;
        }

        #endregion
    }
}
