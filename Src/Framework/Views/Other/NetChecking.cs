using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using Wis.Anes.Data;
using System.Threading;

namespace Wis.Anes.Framework
{
    public class NetChecking
    {

        public static void CheckNet()
        {


            if (ExtendApplicationContext.Current.ThreadNetCheck == null)
            {
                ExtendApplicationContext.Current.ThreadNetCheck = new Thread(new ThreadStart(DataBaseNetChecking));
                ExtendApplicationContext.Current.ThreadNetCheck.Name = "NetCheckingThread";
                ExtendApplicationContext.Current.ThreadNetCheck.IsBackground = true;
                ExtendApplicationContext.Current.ThreadNetCheck.Start();
            }
            else
            {
                if (ExtendApplicationContext.Current.ThreadNetCheck.IsAlive)
                {
                    ExtendApplicationContext.Current.ThreadNetCheck.Resume();
                }
            }
           
            
        }
        public static bool CheckDataBaseNetImmediately()
        {

            IDatabase database = DatabaseFactory.Create();
           // DbConnection DbConnection = database.CreateConnection();
            try
            {

                long l1 = DateTime.Now.Millisecond;
                database.ExecuteNonQuery("select * from dual ");
                ExtendApplicationContext.Current.NetStatus = NetStatus.Connected;
       

                long l2 = DateTime.Now.Millisecond;


                Console.WriteLine("CheckDataBaseNetImmediately 耗时 "+ (l2 - l1).ToString()  + "毫秒 ");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("网络连接测试，异常：" + ex.ToString());
                ExtendApplicationContext.Current.NetStatus = NetStatus.DisConnected;
                return false ;
            }

        }

        private static void DataBaseNetChecking()
        {
            IDatabase database = DatabaseFactory.Create();
            DbConnection DbConnection = database.CreateConnection();

            bool bNeedTest = true;
            int iNetConnectedCount = 0;
            while (bNeedTest)
            {
                try
                {
                    DbConnection.Open();
                    iNetConnectedCount += 1;
                    if (iNetConnectedCount >= 2)
                    {
                        ExtendApplicationContext.Current.NetStatus = NetStatus.Connected;
                        bNeedTest = false;
                        Thread.CurrentThread.Suspend();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("网络连接测试，异常："+ ex.ToString());
                    ExtendApplicationContext.Current.NetStatus = NetStatus.DisConnected;
                    iNetConnectedCount = 0;
                    bNeedTest = true;
                    Thread.Sleep(5000);
                   

                }
            }

        }
    }
}
