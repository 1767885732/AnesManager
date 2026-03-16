using System;
using System.Collections.Generic;
using System.Text;
using iMedical.CommonLib.SimpleDataAccessObject;

namespace Wis.AccessControl.Provider.SqlSeverProvider
{
    public class SqlSeverSqlBuilder : CommonSqlBuilder
    {

        public SqlSeverSqlBuilder(Table table)
            : base(table)
        {
        }
    }
}
