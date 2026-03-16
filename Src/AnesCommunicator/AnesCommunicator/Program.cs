using AnesCommunicator.BaseType;
using AnesCommunicator.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnesCommunicator
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CommunicatorForm(args));
            //string strOperationInformations = "{\"EmergencyCall\":{\"Message\":\"【紧急】手术间{0}请求支援！\",\"OperatingRoom\":\"02\"},\"OperationInfo\":{\"PatientID\":\"111\",\"VisitID\":\"111\",\"OperID\":\"111\",\"OperationName\":\"111\",\"AnesthesiaMethod\":\"111\"},\"PatientInfo\":{\"Name\":\"111\",\"Sex\":\"111\",\"Age\":\"111\",\"BedNo\":\"111\"},\"PatientSignInfo\":{\"HeartRate\":\"111\",\"Breath\":\"111\",\"BloodPressure\":\"111\",\"Temperature\":\"111\"}}";
            //Application.Run(new EmergencyView(strOperationInformations));
        }
    }
}
