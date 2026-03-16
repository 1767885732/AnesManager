using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using Wis.AccessControl.Entity;
using System.Data;
using Wis.AccessControl.Configuration;
using System.Collections.Specialized;
using System.Reflection.Emit;
using Wis.AccessControl.Provider;
using Wis.AccessControl.RowMapper;
using iMedical.CommonLib.SimpleDataAccessObject;

namespace Wis.AccessControl.Provider.SqlSeverProvider
{
    public partial class SqlSeverAccessControlProvider : AccessControlProvider
    {
        string _connectionString;
        Table _userTable;
        SqlBuilder _userSqlBuilder;
        DAOTemplate _daoTemplate;
        public string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }
        
        public override void Initialize(string name, NameValueCollection config)
        {
            base.Initialize(name, config);
            if (string.IsNullOrEmpty(config["connectionStringName"]))
            {
                throw new ConfigurationErrorsException("connectionStringName不能为空!");
            }
            if (((ConfigurationManager.ConnectionStrings.Count == 0) || 
                (ConfigurationManager.ConnectionStrings[config["connectionStringName"]] == null)) || 
                string.IsNullOrEmpty(ConfigurationManager.ConnectionStrings[config["connectionStringName"]].ConnectionString))
            {
                throw new ConfigurationErrorsException("connectionString不能为空!");
            }
            this.ConnectionString = ConfigurationManager.ConnectionStrings[config["connectionStringName"]].ConnectionString;
            BuildUserTable();
            CreateSQLCommandBuilder();
            _daoTemplate = new DAOTemplate(ConnectionString, new SqlSeverDaoProvider());
        }

        private void BuildUserTable()
        {
            _userTable = new Table(UserTableName);
            _userTable.Columns.Add(new Column(UserIDColumnName));
            _userTable.Columns.Add(new Column(UserNameColumnName));
            _userTable.Columns.Add(new Column(UserPasswordColumnName));
            foreach (ExtendInfoItem item in UserSettings.ExtendInfos)
            {
                _userTable.Columns.Add(new Column(item.Name));
            }
            _userTable.Keys.Add(new Column(UserIDColumnName));
        }

        private void CreateSQLCommandBuilder()
        {
            _userSqlBuilder = new SqlSeverSqlBuilder(_userTable);
        }
    }


}
