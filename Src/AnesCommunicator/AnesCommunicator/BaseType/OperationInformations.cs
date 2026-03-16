using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnesCommunicator.BaseType
{
    /// <summary>
    /// 手术信息类
    /// </summary>
    public class OperationInformations
    {
        public EmergencyCall EmergencyCall { get; set; }
        public OperationInfo OperationInfo { get; set; }
        public PatientInfo PatientInfo { get; set; }
        public PatientSignInfo PatientSignInfo { get; set; }
    }

    /// <summary>
    /// 当前手术信息
    /// </summary>
    public class OperationInfo
    {
        /// <summary>
        /// 患者ID
        /// </summary>
        public string PatientID { get; set; }
        /// <summary>
        /// VISIT_ID访问号
        /// </summary>
        public string VisitID { get; set; }
        /// <summary>
        /// OPER_ID手术号
        /// </summary>
        public string OperID { get; set; }
        /// <summary>
        /// 手术名称
        /// </summary>
        public string OperationName { get; set; }
        /// <summary>
        /// 麻醉方法
        /// </summary>
        public string AnesthesiaMethod { get; set; }
        /// <summary>
        /// 麻醉医生
        /// </summary>
        public string AnesthesiaDoctor { get; set; }
        /// <summary>
        /// 手术医生
        /// </summary>
        public string Surgeon { get; set; }
        /// <summary>
        /// 洗手护士
        /// </summary>
        public string OperationNurse { get; set; }
        /// <summary>
        /// 巡回护士
        /// </summary>
        public string SupplyNurse { get; set; }
    }

    /// <summary>
    /// 患者信息
    /// </summary>
    public class PatientInfo
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public string Age { get; set; }
        /// <summary>
        /// 床号
        /// </summary>
        public string BedNo { get; set; }
    }
    /// <summary>
    /// 患者体征信息
    /// </summary>
    public class PatientSignInfo
    {
        /// <summary>
        /// 心率
        /// </summary>
        public string HeartRate { get; set; }
        /// <summary>
        /// 呼吸
        /// </summary>
        public string Breath { get; set; }
        /// <summary>
        /// 血压
        /// </summary>
        public string BloodPressure { get; set; }
        /// <summary>
        /// 体温
        /// </summary>
        public string Temperature { get; set; }
    }

    /// <summary>
    /// 紧急呼叫
    /// </summary>
    public class EmergencyCall
    {
        public string Message { get; set; }
        public string OperatingRoom { get; set; }
    }
}
