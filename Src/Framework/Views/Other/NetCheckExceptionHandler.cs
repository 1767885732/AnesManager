using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Wis.Anes.Data;
using System.Data.Common;

namespace Wis.Anes.Framework.Views.Other
{
    public class NetCheckExceptionHandler
    {
        public static bool  IsNetCheckShowFlag = false  ;
        public static void Handle(Exception e, bool showError)
        {

            
            string logEntity = ExceptionHandler.ExtractLogEntityFromException(e);
            Logger.Write(logEntity);
           
            if (!IsNetCheckShowFlag)
            {


                IsNetCheckShowFlag = true;

                if (ExtendApplicationContext.Current.SystemCurrentProcess < ProgramProcess.SystemAfterLoad)
                {
                    NetCheck netCheck = new NetCheck();
                    netCheck.ShowDialog();
                }
                else
                {
                    NetChecking.CheckNet();
                }
                
                IsNetCheckShowFlag = false;


            }
        }


       
    }
}
