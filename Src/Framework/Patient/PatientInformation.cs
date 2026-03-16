using System;
using System.Collections.Generic;
using System.Text;
using Wis.Anes.BusinessEntity;

namespace Wis.Anes.Framework
{
    public class PatientInformation
    {
        public string PatientID;
        public decimal VisitID;
        public decimal OperID;
        public decimal OperStatus;
        public string OperRoom;
        public string BedNo;
        public string Name;
        public string Sex;
        public string OperationName;
        public string BedLabel;
        public string AnesDoctor;
        public string AnesAssistant;
        public DateTime OperationTime;
        public string Surgeon;
        public string OperationScale;
        public string InpNo;
        public int Emgerency;
        public int Isolation;
        public string Sequence;

        public PatientInformation(string patientID, decimal visitID, decimal operID, decimal operStatus, string name, string operRoom,
            string bedNo,string inpNo, int emger, int isolation)
        {
            PatientID = patientID;
            VisitID = visitID;
            OperID = operID;
            Name = name;
            OperStatus = operStatus;
            OperRoom = operRoom;
            BedNo = bedNo;
            InpNo = inpNo;
            Emgerency = emger;
            Isolation = isolation;
        }

        public PatientInformation(PatientInformation patientInformation)
            : this(patientInformation.PatientID, patientInformation.VisitID, patientInformation.OperID
            , patientInformation.OperStatus, patientInformation.Name, patientInformation.OperRoom, patientInformation.BedNo,
              patientInformation.InpNo, patientInformation.Emgerency, patientInformation.Isolation) { }

        //public PatientInformation(PatientBaseInformations.PatientInformationRow patientInfo)
        //    : this(patientInfo.PATIENT_ID, patientInfo.VISIT_ID,patientInfo.OPER_ID, (patientInfo.IsOPER_STATUSNull() ? 1 : patientInfo.OPER_STATUS)
        //    , (patientInfo.IsNAMENull()?"": patientInfo.NAME), (patientInfo.IsOPERATING_ROOM_NONull() ? "" : patientInfo.OPERATING_ROOM_NO)
        //    , (patientInfo.IsBED_NONull() ? "" : patientInfo.BED_NO), "")
        //{
        //}

        //public PatientInformation(PatientBaseInformations.OperationsInfoRow patientInfo)
        //    : this(patientInfo.PATIENT_ID, patientInfo.VISIT_ID, patientInfo.OPER_ID, (patientInfo.IsOPER_STATUSNull() ? 1 : patientInfo.OPER_STATUS)
        //    , (patientInfo.IsNAMENull() ? "" : patientInfo.NAME), (patientInfo.IsOPERATING_ROOM_NONull() ? "" : patientInfo.OPERATING_ROOM_NO)
        //    , (patientInfo.IsBED_NONull() ? "" : patientInfo.BED_NO),"")
        //{
        //    AnesDoctor = patientInfo.IsANES_DOCTORNull() ? "" : patientInfo.ANES_DOCTOR;
        //    OperationTime = patientInfo.START_DATE_TIME;
        //    Surgeon = patientInfo.IsSURGEONNull() ? "" : patientInfo.SURGEON;
        //    OperationName = patientInfo.IsOPER_NAMENull() ? "" : patientInfo.OPER_NAME;
        //    OperationScale = patientInfo.IsOPER_SCALENull() ? "" : patientInfo.OPER_SCALE;
        //}

        public PatientInformation(System.Data.DataRow patientInfo)
            : this(patientInfo["PAT_ID"].ToString(), decimal.Parse(patientInfo["VISIT_ID"].ToString()), decimal.Parse(patientInfo["OPER_ID"].ToString()), (patientInfo["OPER_STATUS"] == System.DBNull.Value ? 0 : decimal.Parse(patientInfo["OPER_STATUS"].ToString()))
            , (patientInfo["NAME"] == System.DBNull.Value ? "" : patientInfo["NAME"].ToString()), (patientInfo["OPERATING_ROOM_NO"] == System.DBNull.Value ? "" : patientInfo["OPERATING_ROOM_NO"].ToString())
            , (patientInfo["BED_NO"] == System.DBNull.Value ? "" : patientInfo["BED_NO"].ToString()), (patientInfo["INP_NO"] == System.DBNull.Value ? "" : patientInfo["INP_NO"].ToString())
            , (patientInfo["EMERGENCY_INDICATOR"] == System.DBNull.Value ? 0 : Convert.ToInt32(patientInfo["EMERGENCY_INDICATOR"])), (patientInfo["ISOLATION_INDICATOR"] == System.DBNull.Value ? 0 : Convert.ToInt32(patientInfo["ISOLATION_INDICATOR"])))
        {
            AnesDoctor = patientInfo["ANES_DOCTOR"] == System.DBNull.Value ? "" : patientInfo["ANES_DOCTOR"].ToString();
            AnesAssistant = patientInfo["ANES_ASSISTANT"] == System.DBNull.Value ? "" : patientInfo["ANES_ASSISTANT"].ToString();
            if (patientInfo["START_DATE_TIME"] == System.DBNull.Value)
            {
                OperationTime = DateTime.MinValue;
            }
            else
            {
                OperationTime = (DateTime)patientInfo["START_DATE_TIME"];
            }
            Surgeon = patientInfo["SURGEON"] == System.DBNull.Value ? "" : patientInfo["SURGEON"].ToString();
            OperationName = patientInfo["OPER_NAME"]== System.DBNull.Value ? "" : patientInfo["OPER_NAME"].ToString();
            OperationScale = patientInfo["OPER_SCALE"] == System.DBNull.Value ? "" : patientInfo["OPER_SCALE"].ToString();
            InpNo = (patientInfo["INP_NO"] == System.DBNull.Value ? "" : patientInfo["INP_NO"].ToString());
            Sequence = (patientInfo["SEQUENCE"] == System.DBNull.Value ? "" : patientInfo["SEQUENCE"].ToString());
        }
    }
}
