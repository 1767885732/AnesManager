using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;

namespace Wis.Anes.Data
{
   public class EncryptionDecryptionHelper
    {
       public string ConnectionName;
        public string ProviderName;
        public string ServerAddress;
        public string DatabaseName;
        public string UserName;
        public string Password;
        public bool IsWindowUser;

        public EncryptionDecryptionHelper() { }
        public EncryptionDecryptionHelper(string connectionName, string providerName, string serverAddress, string dataBaseName, string userName, string password, bool isWindowUser)
        {
            ConnectionName = connectionName;
            ProviderName = providerName;
            ServerAddress = serverAddress;
            DatabaseName = dataBaseName;
            UserName = userName;
            Password = password;
            IsWindowUser = isWindowUser;
        }

        public string Decode(string connectionString)
        {
            Stream stream = DecodeWithString(connectionString);
            stream.Position = 0;
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(stream);
            if (dataSet.Tables.Count > 0)
            {
                DataTable dt = dataSet.Tables[0];
                ConnectionName = dt.TableName;
                ProviderName = dt.Rows[0][0].ToString();
                ServerAddress = dt.Rows[1][0].ToString();
                DatabaseName = dt.Rows[2][0].ToString();
                UserName = dt.Rows[3][0].ToString();
                Password = dt.Rows[4][0].ToString();
                if (dt.Rows.Count > 5)
                {
                    bool isWindowUser = false;
                    if (!bool.TryParse(dt.Rows[5][0].ToString(), out isWindowUser)) isWindowUser = false;
                    IsWindowUser = isWindowUser; 
                }
                else
                {
                    IsWindowUser = false;
                }
            }

            return BuildConnectionString(this.ProviderName, this.ServerAddress, this.DatabaseName, this.UserName, this.Password, this.IsWindowUser);
        }

        public string Encode()
        {
            DataTable dt = new DataTable();
            dt.TableName = ConnectionName;
            dt.Columns.Add("Item");
            DataRow dr = dt.NewRow();
            dr[0] = ProviderName;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = ServerAddress;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = DatabaseName;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = UserName;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = Password;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = IsWindowUser.ToString();
            dt.Rows.Add(dr);
            MemoryStream stream = new MemoryStream();
            dt.WriteXml(stream, XmlWriteMode.IgnoreSchema);
            stream.Position = 0;
            return EncodeWithString(stream);
        }

        public string BuildConnectionString(string providerName, string serverAddress, string databaseName, string userID, string password, bool isWindowUser)
        {
            string connString = "";
            if (providerName.ToLower().Equals("system.data.oracleclient"))
            {
                connString = string.Format("Data Source={0};Persist Security Info=True;User ID={1};Password={2};Unicode=True", new object[] { serverAddress, userID, password });
            }
            else if (providerName.ToLower().Equals("system.data.sqlclient"))
            {
                connString = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};Integrated Security={4}", new object[] { serverAddress, databaseName, userID, password, isWindowUser.ToString() });
            }
            else if (providerName.ToLower().Equals("system.data.oledb"))
            {
                connString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}{1}.mdb;Jet OLEDB:Database Password={2};Persist Security Info={3}", new object[] { serverAddress, databaseName, password, isWindowUser.ToString() });
            }
            return connString;
        }

        private string EncodeWithString(Stream stream)
        {
            byte[] binaryData = StreamToBytes(stream);
            return System.Convert.ToBase64String(binaryData, 0, binaryData.Length);
        }

        private byte[] StreamToBytes(Stream stream)
        {
            byte[] result = new byte[stream.Length];
            stream.Read(result, 0, (int)stream.Length);
            return result;
        }

        private Stream DecodeWithString(string base64String)
        {
            byte[] binaryData;
            binaryData = System.Convert.FromBase64String(base64String);
            Stream stream = new MemoryStream(binaryData);
            return stream;
        }
    }
}
