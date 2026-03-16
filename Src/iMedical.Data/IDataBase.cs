using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

namespace Wis.Anes.Data
{
    public interface IDatabase
    {
       DataTable Fill(string sql, DataTable data);

       DataTable Fill(string sql, DataTable data, DbParameter[] parameters);

       DataSet Fill(string sql, DataSet dataSet, string tableName);

       DataSet Fill(string sql, DbParameter parameters, DataSet dataSet, string tableName);

       DbConnection CreateConnection();

       DbDataAdapter CreateDbDataAdapter();

       DbCommandBuilder CreateDbCommandBuilder();

       int ExecuteNonQuery(string sql);

       int ExecuteNonQuery(string sql, DbWrapTransaction transaction);

       int ExecuteNonQuery(string sql, DbParameter[] parameter);

       int ExecuteNonQuery(string sql, DbParameter[] parameter, DbWrapTransaction transaction);

       int Update(DataTable data);

       int Update(DataTable data,string tableName);

       int Update(DataTable data, DbWrapTransaction transaction);

       int Update(DataTable data, string tableName, DbWrapTransaction transaction);

        object ExecuteScalar(string sql);

        object ExecuteScalar(string sql, DbParameter[] parameters);

        DbParameter BuildDbParameter(string parameterName, DbType dbType, object value);

        DbWrapTransaction CreateDbTransaction();

        T GetTable<T>(string tableName) where T:DataTable;

        int Update(string sqlWidthColmns,DataTable data);
    }
}
