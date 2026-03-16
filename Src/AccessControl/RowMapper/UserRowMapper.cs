using System;
using System.Collections.Generic;
using System.Text;
using Wis.AccessControl.Entity;
using Wis.AccessControl.Configuration;
using System.Configuration;
using System.Data;
using iMedical.CommonLib.SimpleDataAccessObject;

namespace Wis.AccessControl.RowMapper
{
    public class UserRowMapper : IRowMapper<User>
    {
        #region IRowMapper<User> 成员

        public User MapRow(IDataReader dataReader)
        {
            User user = new User(RowMapperHelper.GetString(dataReader, ConfigurationHelper.UserSettings.UserIDColumnName));
            user.Name = RowMapperHelper.GetString(dataReader, ConfigurationHelper.UserSettings.UserNameColumnName);
            user.Password = RowMapperHelper.GetString(dataReader, ConfigurationHelper.UserSettings.UserPasswordColumnName);
            foreach (ExtendInfoItem item in ConfigurationHelper.UserSettings.ExtendInfos)
            {
                user.ExtendInfoDict[item.Name] = RowMapperHelper.GetString(dataReader, item.Name);
            }
            return user;
        }
        #endregion
    }
}
