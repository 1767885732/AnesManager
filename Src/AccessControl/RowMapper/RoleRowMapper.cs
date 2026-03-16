using System;
using System.Collections.Generic;
using System.Text;
using Wis.AccessControl.Entity;
using System.Data;
using Wis.AccessControl.Configuration;
using Newtonsoft.Json;
using iMedical.CommonLib.SimpleDataAccessObject;

namespace Wis.AccessControl.RowMapper
{
    public class RoleRowMapper : IRowMapper<Role>
    {
        #region IRowMapper<Role> 成员

        public Role MapRow(IDataReader dataReader)
        {
            Role role = new Role(RowMapperHelper.GetString(dataReader, "ROLE_ID"));
            role.Name = RowMapperHelper.GetString(dataReader, "ROLE_NAME");
            role.AppFlag = RowMapperHelper.GetString(dataReader, "APP_FLAG");
            role.Description = RowMapperHelper.GetString(dataReader, "DESCRIPTION");
            RowMapperHelper.FillExtendInfo(dataReader, role);
            return role;
        }
        #endregion
    }
}
