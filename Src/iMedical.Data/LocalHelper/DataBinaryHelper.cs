using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;

namespace Wis.Anes.Data
{

    //Data处理 内部类 
    //序列化反序列化二进制到本地
    //用于单机版缓存处理
    public class DataBinaryHelper
    {

        public static byte[] DataSetToBinary(DataSet ds)
        {
            try
            {
                byte[] bArrayResult = null; //用于存放序列化后的数据
                ds.RemotingFormat = SerializationFormat.Binary; //指定DataSet串行化格式是二进制
                using (MemoryStream ms = new MemoryStream())//定义内存流对象，用来存放DataSet序列化后的值
                {


                    //MemoryStream ms = new MemoryStream();//定义内存流对象，用来存放DataSet序列化后的值
                    System.Runtime.Serialization.IFormatter IF = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();//产生二进制序列化格式
                    IF.Serialize(ms, ds);//串行化到内存中
                    bArrayResult = ms.ToArray(); // 将DataSet转化成byte[]


                    ms.Close();
                    ms.Dispose();
                }
                return bArrayResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static byte[] DataTableToBinary(DataTable dt)
        {
            try
            {
                DataSet ds=new DataSet();
                ds.Tables.Add(dt.Copy());
                byte[] bArrayResult = null; //用于存放序列化后的数据
                ds.RemotingFormat = SerializationFormat.Binary; //指定DataSet串行化格式是二进制
                using (MemoryStream ms = new MemoryStream())//定义内存流对象，用来存放DataSet序列化后的值
                {

                    System.Runtime.Serialization.IFormatter IF = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();//产生二进制序列化格式
                    IF.Serialize(ms, ds);//串行化到内存中
                    bArrayResult = ms.ToArray(); // 将DataSet转化成byte[]


                    ms.Close();
                    ms.Dispose();
                }
                return bArrayResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static void SaveToFile(byte[] value, string filePath)
        {
            try
            {
                if (filePath.Length > 0)
                {
                    string filePathInfo = filePath.Substring(0, filePath.LastIndexOf("\\"));
                    if (!Directory.Exists(filePathInfo))//若文件夹不存在则新建文件夹  
                    {
                        Directory.CreateDirectory(filePathInfo); //新建文件夹  
                    }
                }
                //using (System.IO.FileStream fs = new System.IO.FileStream(filePath, System.IO.FileMode.Create))
                using(System.IO.FileStream fs = new System.IO.FileStream(filePath, System.IO.FileMode.OpenOrCreate))
                {
                    //System.IO.FileStream fs = new System.IO.FileStream(filePath, System.IO.FileMode.OpenOrCreate);

                    byte byteTemp = 0x77; //加密

                    for (int i = 0; i < value.Length; i++)
                    {
                        value[i] = (byte)(value[i] ^ byteTemp);
                    }



                    fs.Write(value, 0, value.Length);
                    fs.Flush();
                    fs.Close();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static byte[] ReadFileToByteBuffer(string filePath)
        {
            try
            {

                byte[] value = null;
                using (System.IO.Stream theStream = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite))
                {
                    int b1;
                    System.IO.MemoryStream tempStream = new System.IO.MemoryStream();
                    while ((b1 = theStream.ReadByte()) != -1)
                    {
                        tempStream.WriteByte(((byte)b1));
                    }



                    byte byteTemp = 0x77; //解密
                     value = tempStream.ToArray();


                    for (int i = 0; i < value.Length; i++)
                    {
                        value[i] = (byte)(byteTemp ^ value[i]);
                    }



                    return value;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet BinaryToDataSet(byte[] binaryData)
        {
            try
            {

                using (MemoryStream ms = new MemoryStream(binaryData))//创建内存流
                {
                    System.Runtime.Serialization.IFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();//产生二进制序列化格式
                    object obj = bf.Deserialize(ms);//反串行化到内存中
                    //类型检验
                    ms.Close();

                    if (obj is DataSet)
                    {
                        return  (DataSet)obj;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable BinaryToDataTable(byte[] binaryData, string tableName)
        {
            try
            {

                using (MemoryStream ms = new MemoryStream(binaryData))//创建内存流
                {
                    System.Runtime.Serialization.IFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();//产生二进制序列化格式
                    object obj = bf.Deserialize(ms);//反串行化到内存中
                    //类型检验
                    ms.Close();
                    if (obj is DataTable)
                    {
                        DataTable dataSetResult = (DataTable)obj;
                        return dataSetResult;
                    }
                    else if (obj is DataSet)
                    {
                        DataSet dataSetResult = (DataSet)obj;
                        if (!string.IsNullOrEmpty(tableName))
                        {
                            if (dataSetResult.Tables.Count > 0 && dataSetResult.Tables.Contains(tableName))
                            {
                                return dataSetResult.Tables[tableName].Copy();
                            }
                        }
                        else
                        {
                            if (dataSetResult.Tables.Count > 0)
                            {
                                return dataSetResult.Tables[0].Copy();
                            }
                        }

                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }    
    }
}
