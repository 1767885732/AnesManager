using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Wis.Anes.Framework
{
   public class ExceptionHandler
    {

       
       public static void Handle(Exception e)
       {
           Handle(e,true);
       }

       public static void Handle(Exception e,bool showError)
       {

           //Oracle SQL Server
           if (e.Message.Contains("ORA-12560") || e.Message.Contains("ORA-03113") || e.Message.Contains("ORA-12170") || e.Message.Contains("指定的网络名不再可用"))
           {
        
               ExtendApplicationContext.Current.NetStatus = NetStatus.DisConnected;
              
               Wis.Anes.Framework.Views.Other.NetCheckExceptionHandler.Handle(e, showError);
               
           }
           else if (e.Message.Contains("在位置 0 处没有任何行"))
           {
               //判断是否是网络中断之后造成的
               NetChecking.CheckDataBaseNetImmediately();

               if (ExtendApplicationContext.Current.NetStatus == NetStatus.Connected)
               {
                   if (showError)
                   {
                       DevExpress.XtraEditors.XtraMessageBox.Show(e.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   }
               }
               string logEntity = ExtractLogEntityFromException(e);
               Logger.Write(logEntity);
           }
           else
           {
               if (showError)
               {
                   DevExpress.XtraEditors.XtraMessageBox.Show(e.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
               string logEntity = ExtractLogEntityFromException(e);
               Logger.Write(logEntity);
           }

       }
       public static string ExtractLogEntityFromException(Exception e)
       {
           StringBuilder stringBuilder = new StringBuilder();

           stringBuilder.AppendLine(string.Format("Time:{0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
           stringBuilder.AppendLine(string.Format("Message:{0}",e.Message));
           stringBuilder.AppendLine(string.Format("Source:{0}", e.Source));
           stringBuilder.AppendLine(string.Format("StackTrace:{0}", e.StackTrace));
           stringBuilder.AppendLine("=========================================================================");

           if (e.InnerException != null)
           {
               stringBuilder.AppendLine(ExtractLogEntityFromException(e.InnerException));
           }
           return stringBuilder.ToString();
           
           

       }
    }
}
