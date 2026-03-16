using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Newtonsoft.Json;
using Wis.AccessControl.Entity;

namespace Wis.AccessControl.RowMapper
{
    public static class RowMapperHelper
    {
        public static string GetString(IDataReader dataReader, string columnName)
        {
            int idx = dataReader.GetOrdinal(columnName);
            if (dataReader.IsDBNull(idx))
                return null;
            else
                return dataReader.GetString(idx);
        }

        public static int GetInt32(IDataReader dataReader, string columnName)
        {
            int idx = dataReader.GetOrdinal(columnName);
            return dataReader.GetInt32(idx);
        }

        public static void FillExtendInfo(IDataReader dataReader, ExtendInfo extendInfo)
        {
            string extendInfoStr = GetString(dataReader, "EXTEND_INFO");
            if (string.IsNullOrEmpty(extendInfoStr))
                return;
            IDictionary<string, string> dict = JsonConvert.DeserializeObject<IDictionary<string, string>>(extendInfoStr);
            foreach (var item in dict)
            {
                extendInfo.ExtendInfoDict.Add(item);
            }
        }
    }
}
