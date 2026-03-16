using System;
using System.Collections.Generic;
using System.Text;
using iMedical.CommonLib.SimpleDataAccessObject;

namespace Wis.AccessControl.Provider.OracleProvider
{
    public class OracleSqlBuilder : CommonSqlBuilder
    {

        public OracleSqlBuilder(Table table)
            : base(table)
        {
        }
    }
}
