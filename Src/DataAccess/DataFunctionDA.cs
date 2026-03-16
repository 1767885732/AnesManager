/*----------------------------------------------------------------
 // Copyright (C) 2008 北京拓扑工厂科技发展有限公司
 // 文件名：DataFunction.cs
 // 文件功能描述：
 //      数据处理公共类
 // 
 // 创建标识：
 // 修改标识：
 // 修改描述：
 //
 // 修改标识：
 // 修改描述：
----------------------------------------------------------------*/
using System;
using System.Data.Common;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace Wis.Anes.DataAccess
{
    /// <summary>
    /// 数据处理公共类
    /// </summary>
    internal class DataFunctionDA
    {
        /// <summary>
        /// 根据一个数据适配器创建事务
        /// </summary>
        /// <param name="tableAdapter">事务的第一个数据适配器</param>
        /// <param name="isolationLevel">指定连接的事务锁定行为。 </param>
        /// <returns> 返回一个事务类</returns> 
        public static DbTransaction BeginTransaction(object tableAdapter, IsolationLevel isolationLevel)
        //internal static DbTransaction BeginTransaction(object tableAdapter, IsolationLevel isolationLevel)
        {
            Type adapterType = tableAdapter.GetType();
            DbConnection connection = GetAdpaterConnection(tableAdapter);
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            DbTransaction transaction = connection.BeginTransaction(isolationLevel);
            SetTransaction(tableAdapter, transaction);
            return transaction;
        }
        /// <summary>
        /// 根据一个数据适配器创建事务
        /// </summary>
        /// <param name="tableAdapter">事务的第一个数据适配器</param>
        /// <returns>返回一个事务类</returns> 
        public static DbTransaction BeginTransaction(object tableAdapter)
        //internal static DbTransaction BeginTransaction(object tableAdapter)
        {
            return BeginTransaction(tableAdapter, IsolationLevel.ReadCommitted);
        }
        /// <summary>
        ///  根据适配器获取数据连接类型
        /// </summary>
        /// <param name="tableAdapter">数据适配器</param>
        /// <returns>数据连接类型</returns> 
        private static DbConnection GetAdpaterConnection(object tableAdapter)
        {
            Type adapterType = tableAdapter.GetType();
            PropertyInfo connectionProperty = adapterType.GetProperty("Connection", BindingFlags.NonPublic | BindingFlags.Instance);
            DbConnection connection = (DbConnection)connectionProperty.GetValue(tableAdapter, null);
            return connection;
        }
        /// <summary>
        /// 设置数据适配器的数据连接为事务处理的数据连接
        /// </summary>
        /// <param name="tableAdapter">数据适配器</param>
        /// <param name="connection">数据连接</param> 
        private static void SetConnection(object tableAdapter, DbConnection connection)
        {
            Type type = tableAdapter.GetType();
            PropertyInfo connectionProperty = type.GetProperty("Connection", BindingFlags.NonPublic | BindingFlags.Instance);
            connectionProperty.SetValue(tableAdapter, connection, null);
        }
        /// <summary>
        /// 设置事务的其它数据适配器
        /// </summary>
        /// <param name="tableAdapter">其它数据适配器</param>
        /// <param name="transaction">已经根据数据适配器创建的事务类</param> 
        public static void SetTransaction(object tableAdapter, DbTransaction transaction)
        //internal static void SetTransaction(object tableAdapter, DbTransaction transaction)
        {
            Type adapterType = tableAdapter.GetType();
            PropertyInfo commandsProperty = adapterType.GetProperty("CommandCollection",
            BindingFlags.NonPublic | BindingFlags.Instance);
            DbCommand[] commands = (DbCommand[])commandsProperty.GetValue(tableAdapter, null);
            foreach (DbCommand command in commands)
            {
                command.Transaction = transaction;
            }
            PropertyInfo adpterProperty = adapterType.GetProperty("Adapter",
            BindingFlags.NonPublic | BindingFlags.Instance);
            DbDataAdapter dataAdapter = (DbDataAdapter)adpterProperty.GetValue(tableAdapter, null);
            if (dataAdapter.InsertCommand != null)
            {
                dataAdapter.InsertCommand.Transaction = transaction;
            }
            if (dataAdapter.DeleteCommand != null)
            {
                dataAdapter.DeleteCommand.Transaction = transaction;
            }
            if (dataAdapter.UpdateCommand != null)
            {
                dataAdapter.UpdateCommand.Transaction = transaction;
            }
            if (dataAdapter.SelectCommand != null)
            {
                dataAdapter.SelectCommand.Transaction = transaction;
            }
            SetConnection(tableAdapter, transaction.Connection);
        }
    }
}

