using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Data;
using System.Runtime.Serialization.Formatters.Binary;

namespace Wis.Anes.Framework.Utilities
{
    //Data处理 内部类 
    //序列化反序列化二进制到本地
    //用于单机版缓存处理
    public class DataBinaryHelper
    {

        public static byte[] DataSetToBinary(DataSet ds)
        {
            return Wis.Anes.Data.DataBinaryHelper.DataSetToBinary(ds);
        }



        public static byte[] DataTableToBinary(DataTable dt)
        {
            return Wis.Anes.Data.DataBinaryHelper.DataTableToBinary(dt);
        }



        public static void SaveToFile(byte[] value, string filePath)
        {
            Wis.Anes.Data.DataBinaryHelper.SaveToFile(value, filePath);
        }
        public static byte[] ReadFileToByteBuffer(string filePath)
        {
            return Wis.Anes.Data.DataBinaryHelper.ReadFileToByteBuffer(filePath);
        }

        public static DataSet BinaryToDataSet(byte[] binaryData)
        {
            return Wis.Anes.Data.DataBinaryHelper.BinaryToDataSet(binaryData);
        }

        public static DataTable BinaryToDataTable(byte[] binaryData, string tableName)
        {
            return Wis.Anes.Data.DataBinaryHelper.BinaryToDataTable(binaryData, tableName);
        }

        public static DataTable BinaryToDataTable(byte[] binaryData)
        {
            return BinaryToDataTable(binaryData, "");
        }

    }
}
