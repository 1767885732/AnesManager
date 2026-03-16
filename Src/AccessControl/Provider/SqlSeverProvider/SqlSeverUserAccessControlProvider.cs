using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Wis.AccessControl.Entity;
using Wis.AccessControl.RowMapper;
using Wis.AccessControl.Configuration;
using Devart.Data.Oracle;

namespace Wis.AccessControl.Provider.SqlSeverProvider
{
    public partial class SqlSeverAccessControlProvider
    {
        public override void CreateUser(User user)
        {
            List<IDataParameter> paras = BuildUserDataParameters(user);
            _daoTemplate.Insert(_userSqlBuilder.BuildInsertSQL(), paras.ToArray());
        }

        private static List<IDataParameter> BuildUserDataParameters(User user)
        {
            List<IDataParameter> paras = new List<IDataParameter>();
            paras.Add(new OracleParameter(UserIDColumnName, user.ID));
            paras.Add(new OracleParameter(UserNameColumnName, user.Name));
            paras.Add(new OracleParameter(UserPasswordColumnName, user.Password));
            foreach (var item in user.ExtendInfoDict)
            {
                if (string.IsNullOrEmpty(UserSettings.ExtendInfos[item.Key].DbType))
                {
                    paras.Add(new OracleParameter(item.Key, item.Value));
                }
                else if(UserSettings.ExtendInfos[item.Key].DbType.ToLower() == "date")
                {
                    OracleParameter p = new OracleParameter(item.Key, OracleDbType.Date);
                    p.Value =Convert.ToDateTime(item.Value);
                    paras.Add(p);
                }

            }
            return paras;
        }

        public override IList<User> GetAllUser(string where)
        {
            return _daoTemplate.Query<User>(_userSqlBuilder.BuildSelectSQL(null), new UserRowMapper());
        }

        public override int DeleteUserByID(string userID)
        {
            try
            {
                _daoTemplate.BeginTransaction();
                int rowCount = DeleteUserBy(UserIDColumnName, userID);
                RemoveAllRoleByUserID(userID);
                _daoTemplate.CommitTransaction();
                return rowCount;
            }
            finally
            {
                _daoTemplate.RollbackTransaction();
            }
        }

        private int DeleteUserBy(string byColumn, string value)
        {
            return _daoTemplate.Delete
            (
                _userSqlBuilder.BuildDeleteSQL("WHERE " + byColumn + " = :" + byColumn),
                new OracleParameter[] 
                { 
                    new OracleParameter(byColumn, value) 
                }
            );
        }

        public override int DeleteUserByName(string userName)
        {
            User user = GetUserByName(userName);
            if (user == null)
                return 0;
            return DeleteUserByID(user.ID);
        }

        public override int UpdateUser(User user)
        {
            return UpdateUserBy(user, UserIDColumnName, user.ID);
        }

        private int UpdateUserBy(User user, string byColumn, string oldValue)
        {
            List<IDataParameter> paras = BuildUserDataParameters(user);
            paras.Add(new OracleParameter("OLD_" + byColumn, oldValue));
            return _daoTemplate.Update
            (
                _userSqlBuilder.BuildUpdateSQL("WHERE " + byColumn + " = :OLD_" + byColumn),
                paras.ToArray()
            );
        }

        public override User GetUserByID(string userID)
        {
            return GetUserBy(UserIDColumnName, userID);
        }

        private User GetUserBy(string byColumn, string value)
        {
            IList<User> list = _daoTemplate.Query<User>
            (
                _userSqlBuilder.BuildSelectSQL("WHERE " + byColumn + " = :" + byColumn),
                new IDataParameter[] 
                { 
                    new OracleParameter(byColumn, value) 
                },
                new UserRowMapper()
            );
            if (list.Count == 0)
                return list[0];
            else
                return null;
        }

        public override User GetUserByName(string userName)
        {
            return GetUserBy(UserNameColumnName, userName);
        }
    }
}
