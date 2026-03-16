/*----------------------------------------------------------------
      // Copyright (C) 2005 北京拓扑工厂科技发展有限公司
      // 文件名：OracleScriptProvider.cs
      // 文件功能描述：OracleScriptProvider
      // 创建标识：深蓝色右手-2011-01-14
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;

namespace Wis.Anes.DataAccess
{
    public partial class OracleScriptProvider
    {
        #region AnesInformations
        public string AnesInformations_GetAnesthesiaNurse
        {
            get
            {
                return
                    "SELECT PAT_ID, VISIT_ID, OPER_ID, OPER_PART, ALERGY1, ALERGY2,  PRE_OPER_CONS, PRE_ANES_PHAM, PRE_ANES_PHAM_RESULT, PRE_OPER_SKIN_STATUS, "
                     + "  BELONGINGS, ANES_POSITION, ANES_PRESVERVATION, SPECIMAN_NAME,  SPECIMEN_SOURCE_1, SPECIMEN_SENDER_1, SPECIMEN_CHECKER_1, DRAINAGE_TUBE, "
                     + " BLOOD_BAG, AFTER_OPER_SKIN_COND, DUR_OPER_SPECIAL_COND, AFTER_OPER_NOTICE, ENTER_DATE_TIME,  ENTERED_BY, SUPERFICIAL_VENIPUNCTURE, DEEP_VENIPUNCTURE, "
                     + "  CATHETERIZATION, INFUSION, TRANSFUSE_SELF,   TRANSFUSE_OTHERS, TRANSFUSE_LIQUID, AFTER_OPER_CONS, "
                     + "  ASEPTIC_PACKAGE, OUT_DATE_TIME, PRESS, PULSE, SEND_PAT_TO,  ELECTRIC_KNIFE, TOURNIQUET, CATHODE_PLATE, D_IN_TIME, D_OUT_TIME, "
                     + "  D_PRESS, S_IN_TIME, S_OUT_TIME, S_PRESS, CATHETER_SIZE, IMPLANT_NAME, IMPLANT_MANUFACTORY, IMPLANT_OUT, SEND_IMPLANT_TO "
                     + " FROM WIS_ANES_NURSE WHERE (PAT_ID = :patiendID) AND (VISIT_ID = :visitID) AND (OPER_ID = :operID) ";
            }
        }

        public string AnesInformations_GetOperationEqipDetail
        {
            get
            {
                return
                    "SELECT PAT_ID, VISIT_ID, OPER_ID, ITEM_NO, ITEM_NAME, ITEM_CLASS,   ITEM_CODE, ITEM_SPEC, UNITS, AMOUNT, COSTS, ONE_INDICATOR, "
                     + " VERIFIED_INDICATOR, OPERATOR, ENTER_DATE_TIME, AMOUNT2, AMOUNT3,  MEMO FROM WIS_OPER_EQIP_DETAIL "
                     + " WHERE (PAT_ID = :patientId) AND (VISIT_ID = :visitId) AND (OPER_ID = :operId)";
            }
        }
        public string AnesInformations_GetAnesthesiaEventBy
        {
            get
            {
                return
                    "SELECT ADMINISTRATOR, BILL_ATTR, BILL_INDICATOR, CONCENTRATION, CONCENTRATION_UNITS, DOSAGE, DOSAGE_UNITS, DURATIVE_INDICATOR, END_DATE_TIME, EVENT_ATTR, EVENT_NO, ITEM_CLASS, ITEM_CODE, ITEM_NAME, ITEM_NO, ITEM_SPEC, METHOD, OPER_ID, PARENT_ITEM_NO, PAT_ID, PERFORM_SPEED, SPEED_UNITS, START_DATE_TIME, SUPPLIER_NAME, VISIT_ID FROM WIS_ANES_EVENT WHERE (PAT_ID = :PatientID) AND (VISIT_ID = :VisitID) AND (OPER_ID = :OperID) AND(EVENT_NO = :EventNo) ORDER BY START_DATE_TIME";
            }
        }
        public string AnesInformations_GetAnesthesiaEvent
        {
            get
            {
                return
                    "SELECT PAT_ID, VISIT_ID, OPER_ID, ITEM_NO, ITEM_CLASS, EVENT_NO,   ITEM_NAME, ITEM_CODE, ITEM_SPEC, DOSAGE_UNITS, DOSAGE, ADMINISTRATOR, "
                    + " START_DATE_TIME, END_DATE_TIME, BILL_INDICATOR, DURATIVE_INDICATOR, METHOD,  PERFORM_SPEED, SPEED_UNITS, PARENT_ITEM_NO, EVENT_ATTR, "
                    + " CONCENTRATION, CONCENTRATION_UNITS, BILL_ATTR, SUPPLIER_NAME FROM WIS_ANES_EVENT ";
            }
        }

        public string AnesInformations_AnesthesiaEventByPatient
        {
            get
            {
                return
                    "SELECT ADMINISTRATOR, BILL_ATTR, BILL_INDICATOR, CONCENTRATION, CONCENTRATION_UNITS, DOSAGE, DOSAGE_UNITS, DURATIVE_INDICATOR, END_DATE_TIME, EVENT_ATTR, EVENT_NO, ITEM_CLASS, ITEM_CODE, ITEM_NAME, ITEM_NO, ITEM_SPEC, METHOD, OPER_ID, PARENT_ITEM_NO, PAT_ID, PERFORM_SPEED, SPEED_UNITS, START_DATE_TIME, SUPPLIER_NAME, VISIT_ID FROM WIS_ANES_EVENT WHERE (PAT_ID = :PatientID) AND (VISIT_ID = :VisitID)";
            }
        }

        public string AnesInformations_AnesthesiaEventByPatientAndItemClass
        {
            get
            {
                return
                    "SELECT ADMINISTRATOR, BILL_ATTR, BILL_INDICATOR, CONCENTRATION, CONCENTRATION_UNITS, DOSAGE, DOSAGE_UNITS, DURATIVE_INDICATOR, END_DATE_TIME, EVENT_ATTR, EVENT_NO, ITEM_CLASS, ITEM_CODE, ITEM_NAME, ITEM_NO, ITEM_SPEC, METHOD, OPER_ID, PARENT_ITEM_NO, PAT_ID, PERFORM_SPEED, SPEED_UNITS, START_DATE_TIME, SUPPLIER_NAME, VISIT_ID FROM WIS_ANES_EVENT WHERE (PAT_ID = :PatientID) AND (VISIT_ID = :VisitID) AND (ITEM_CLASS = :ItemClass) ORDER BY ITEM_NAME, START_DATE_TIME";
            }

        }
        public string AnesInformations_AnesthesiaEventByPatientAndOperID
        {
            get
            {
                return
                    "SELECT ADMINISTRATOR, BILL_ATTR, BILL_INDICATOR, CONCENTRATION, CONCENTRATION_UNITS, DOSAGE, DOSAGE_UNITS, DURATIVE_INDICATOR, END_DATE_TIME, EVENT_ATTR, EVENT_NO, ITEM_CLASS, ITEM_CODE, ITEM_NAME, ITEM_NO, ITEM_SPEC, METHOD, OPER_ID, PARENT_ITEM_NO, PAT_ID, PERFORM_SPEED, SPEED_UNITS, START_DATE_TIME, SUPPLIER_NAME, VISIT_ID FROM WIS_ANES_EVENT WHERE (PAT_ID = :PatientID) AND (VISIT_ID = :VisitID) AND (OPER_ID = :OperID) AND EVENT_NO<>2 ORDER BY START_DATE_TIME";
            }
        }
        public string AnesInformations_AnesthesiaEventByPatientAndItemClassAndOperID
        {
            get
            {
                return
                    "SELECT ADMINISTRATOR, BILL_ATTR, BILL_INDICATOR, CONCENTRATION, CONCENTRATION_UNITS, DOSAGE, DOSAGE_UNITS, DURATIVE_INDICATOR, END_DATE_TIME, EVENT_ATTR, EVENT_NO, ITEM_CLASS, ITEM_CODE, ITEM_NAME, ITEM_NO, ITEM_SPEC, METHOD, OPER_ID, PARENT_ITEM_NO, PAT_ID, PERFORM_SPEED, SPEED_UNITS, START_DATE_TIME, SUPPLIER_NAME, VISIT_ID FROM WIS_ANES_EVENT WHERE (PAT_ID = :PatientID) AND (VISIT_ID = :VisitID) AND (ITEM_CLASS = :ItemClass) AND (OPER_ID = :OperID) ORDER BY ITEM_NAME, START_DATE_TIME";
            }
        }


        #region "麻醉6.0  获取体征数据"

        public string AnesInformations_PatientMonitor
        {
            get
            {
                return
                    "SELECT  PAT_ID, VISIT_ID, OPER_ID, TIME_POINT, ITEM_NAME,ITEM_VALUE, lOG_DATE_TIME,ITEM_CODE,DATA_TYPE FROM WIS_PATIENT_MONITOR WHERE DATA_TYPE = 0 ";
            }
        }
        public string AnesInformations_PatientMonitorByPatient
        {
            get
            {
                return
                    "SELECT PAT_ID, VISIT_ID, OPER_ID, TIME_POINT, ITEM_NAME,ITEM_VALUE, lOG_DATE_TIME,ITEM_CODE,DATA_TYPE FROM WIS_PATIENT_MONITOR WHERE (DATA_TYPE = 0) AND (PAT_ID = :PatientID) AND (VISIT_ID = :VisitID) ORDER BY TIME_POINT ";
            }
        }

        public string AnesInformations_PatientMonitorByPatientAndOperID
        {
            get
            {
                return
                    "SELECT PAT_ID, VISIT_ID, OPER_ID, TIME_POINT, ITEM_NAME,ITEM_VALUE, lOG_DATE_TIME,ITEM_CODE,DATA_TYPE FROM WIS_PATIENT_MONITOR WHERE (PAT_ID = :PatientID) AND (VISIT_ID = :VisitID) AND (OPER_ID = :OperID) AND (DATA_TYPE = :dataType) ORDER BY TIME_POINT";
            }
        }
        public string AnesInformations_PatientMonitorByPatientAndEventNo
        {
            get
            {
                return
                    "select * from WIS_PATIENT_MONITOR where pat_id = :PatientID and visit_id = :VisitID and oper_id = :OperID and item_no = 0 and DATA_TYPE = :EventNo";
            }
        }
        public string AnesInformations_GetPatientMonitorHistory
        {
            get
            {
                return
                    "select * from WIS_PAT_MONITOR_HISTORY WHERE (PAT_ID = :PatientID) AND (VISIT_ID = :VisitID) AND (OPER_ID = :OperID) AND (DATA_TYPE = :dataType) ORDER BY TIME_POINT";
            }
        }



        #endregion
        public string AnesInformations_PatMonitorDate
        {
            get
            {
                return
                    "SELECT PAT_ID, VISIT_ID, OPER_ID, ITEM_NO, MONITOR_VALUE, DATA_TYPE,NOTICE_TIME FROM WIS_PAT_MONITOR_DATA WHERE DATA_TYPE = 0 ";
            }
        }
        public string AnesInformations_PatMonitorDateByPatient
        {
            get
            {
                return
                    "SELECT DATA_TYPE, ITEM_NO, MONITOR_VALUE, NOTICE_TIME, OPER_ID, PAT_ID, VISIT_ID FROM WIS_PAT_MONITOR_DATA WHERE (DATA_TYPE = 0) AND (PAT_ID = :PatientID) AND (VISIT_ID = :VisitID) ORDER BY ITEM_NO";
            }
        }
        public string AnesInformations_PatMonitorTitleRow
        {
            get
            {
                return
                    "SELECT DATA_TYPE, ITEM_NO, MONITOR_VALUE, NOTICE_TIME, OPER_ID, PAT_ID, VISIT_ID FROM WIS_PAT_MONITOR_DATA WHERE (ITEM_NO = 0) AND (PAT_ID = :PatientID) AND (VISIT_ID = :VisitID)  AND (OPER_ID = :OperID)  ORDER BY ITEM_NO";
            }
        }
        public string AnesInformations_PatMonitorDateByPatientAndOperID
        {
            get
            {
                return
                    "SELECT DATA_TYPE, ITEM_NO, MONITOR_VALUE, NOTICE_TIME, OPER_ID, PAT_ID, VISIT_ID FROM WIS_PAT_MONITOR_DATA WHERE (PAT_ID = :PatientID) AND (VISIT_ID = :VisitID) AND (OPER_ID = :OperID) AND (DATA_TYPE = :dataType) ORDER BY ITEM_NO";
            }
        }
        public string AnesInformations_PatMonitorDateByPatientAndEventNo
        {
            get
            {
                return
                    "select * from WIS_PAT_MONITOR_DATA where pat_id = :PatientID and visit_id = :VisitID and oper_id = :OperID and item_no = 0 and DATA_TYPE = :EventNo";
            }
        }
        public string AnesInformations_GetPatMonitorDataHistory
        {
            get
            {
                return
                    "select * from WIS_PAT_MONITOR_DATA_HISTORY WHERE (PAT_ID = :PatientID) AND (VISIT_ID = :VisitID) AND (OPER_ID = :OperID) AND (DATA_TYPE = :dataType) ORDER BY ITEM_NO";
            }
        }




        public string AnesInformations_GetMonitorFunctionCode
        {
            get
            {
                return
                    "SELECT ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNITS, DIS_COLOR, PARM_CLASS,  DRAW_ICON, USE_FLAG, PRIORITY_INDICATOR, MEMO, INPUT_CODE, NAME_IN_ICU, "
                    + " WARD_CODE, WARD_TYPE, ITEM_NAME_ALIAS, VALUE_TYPE, EXAM_METHOD,   IN_OR_OUT, ITEM_TYPE, CALC_SUM, PRINT_ITEM_NO, DRAW_STYLE FROM WIS_MONITOR_FUNC_CODE     ";
            }
        }
        public string AnesInformations_GetOperationMaster
        {
            get
            {
                return
                    "SELECT *  FROM WIS_OPER_MASTER";

            }
        }
        public string AnesInformations_GetOperationMasterByDate
        {
            get
            {
                return
                    "SELECT *  FROM WIS_OPER_MASTER WHERE  (SCHEDULED_DATE_TIME >= :startTime) AND (SCHEDULED_DATE_TIME <= :endTime)";

            }
        }
        public string AnesInformations_GetOPEREQUIPMENTRCDData
        {
            get
            {
                return
                    "SELECT *  FROM MED_ANES_OPEREQUIPMENTRCD ORDER BY ORDER_ID";

            }
        }
        public string AnesInformations_OperationMasterByPatientAndOperID
        {
            get
            {
                return
                    "SELECT * FROM WIS_OPER_MASTER WHERE (PAT_ID = :PatientID) AND (VISIT_ID = :VisitID) AND (OPER_ID = :OperID)";
            }
        }
        public string AnesInformations_OperationMasterByPatient
        {
            get
            {
                return
                    "SELECT * FROM WIS_OPER_MASTER WHERE (PAT_ID = :PatientID) ";
            }
        }
        public string AnesInformations_OperationMasterByRoom
        {
            get
            {
                return
                    "SELECT * FROM WIS_OPER_MASTER WHERE OPERATING_ROOM_NO = :roomNo AND  OPER_STATUS >= :operStatusStart AND OPER_STATUS <= :operStatusEnd";
            }
        }

        public string AnesInformations_OperationMasterByRoomANDRoomNo
        {
            get
            {
                return
                    "SELECT * FROM WIS_OPER_MASTER WHERE OPERATING_ROOM_NO = :roomNo AND OPERATING_ROOM=:OPERATING_ROOM AND OPER_STATUS >= :operStatusStart AND OPER_STATUS <= :operStatusEnd";
            }
        }

        public string AnesInformations_OperationMasterByRoomNo
        {
            get
            {
                return
                    "SELECT * FROM WIS_OPER_MASTER WHERE OPERATING_ROOM_NO = :roomNo AND OPER_STATUS = :operStatus";
            }
        }
        public string AnesInformations_GetAnesthesiaPlan
        {
            get
            {
                return
                    "SELECT * FROM WIS_ANES_PLAN WHERE PAT_ID = :PatientID AND VISIT_ID = :VisitID AND OPER_ID = :OperID";
            }
        }
        public string AnesInformations_GetAnesthesiaSummary
        {
            get
            {
                return
                    "SELECT * FROM WIS_ANES_SUMMARY WHERE PAT_ID = :PatientID AND VISIT_ID = :VisitID AND OPER_ID = :OperID";
            }

        }
        public string AnesInformations_GetJSShouHouZhenTongDanData
        {
            get
            {
                return
                    "SELECT A.BED_NO,B.NAME,DATEDIFF(YEAR, B.DATE_OF_BIRTH, GETDATE()) AS AGE,B.SEX,A.WEIGHT,C.ROUTE,C.LOADMACHINE,C.VAS,C.COMPLICATION,";
            }
        }
        public string AnesInformations_GetJSShuQianFangTanData
        {
            get
            {
                return
                    "SELECT * FROM WIS_JS_PREOPER_INTERVIEW";
            }
        }
        public string AnesInformations_GetJSShuQianFangTanBy
        {
            get
            {
                return
                    "SELECT * FROM WIS_JS_PREOPER_INTERVIEW WHERE  (Pat_ID = :PatientID) AND (Visit_ID = :VisitID) AND (Oper_ID = :OperID)";
            }
        }
        public string AnesInformations_GetJSShouHouZhenTongData
        {
            get
            {
                return
                    "SELECT Pat_ID, Visit_ID, Oper_ID, Route, Load_Machine, Exclude_Hinder, VAS,   Complication, Prescription, Unload_Machine, ANALGESIC_METHOD FROM WIS_JS_AFTEROPER_ANALGESIA";
            }
        }
        public string AnesInformations_GetJSShouHouZhenTongDataBy
        {
            get
            {
                return
                    "SELECT Complication, Exclude_Hinder, Load_Machine, Oper_ID, Pat_ID, Prescription, Route, Unload_Machine, VAS, Visit_ID, ANALGESIC_METHOD FROM WIS_JS_AFTEROPER_ANALGESIA WHERE (Pat_ID = :PatientID) AND (Visit_ID = :VisitID) AND (Oper_ID = :OperID)";
            }
        }
        public string AnesInformations_GetJSMZKCaoZhuoData
        {
            get
            {
                return
                    "SELECT     Pat_ID, Visit_ID, Oper_ID, Oper_Name, Oper_Memo, Advice_Opt_Date, Advice_Cure_Way FROM WIS_JS_ANES_OPERATION";
            }
        }
        public string AnesInformations_GetJSMZKCaoZhuoDataBy
        {
            get
            {
                return
                    "SELECT     Pat_ID, Visit_ID, Oper_ID, Oper_Name, Oper_Memo, Advice_Opt_Date, Advice_Cure_Way FROM  WIS_JS_ANES_OPERATION WHERE (Pat_ID = :PatientID) AND (Visit_ID = :VisitID) AND (Oper_ID = :OperID)";
            }
        }
        public string AnesInformations_GetJSShuHouBingQingData
        {
            get
            {
                return
                    "SELECT Pat_ID, Visit_ID, Oper_ID, Record_Time, Sense, Press, Pulse, Breath, SpO2, ECG, Others FROM WIS_JS_AFTEROPER_CONDITION ";
            }
        }
        public string AnesInformations_GetJSShuHouBingQingDataBy
        {
            get
            {
                return
                    "SELECT Pat_ID, Visit_ID, Oper_ID, Record_Time, Sense, Press, Pulse, Breath, SpO2, ECG, Others FROM WIS_JS_AFTEROPER_CONDITION WHERE (Pat_ID = :PatientID) AND (Visit_ID = :VisitID) AND (Oper_ID = :OperID)";
            }
        }
        public string AnesInformations_GetAnesthesiaInquiryData
        {

            get
            {
                return
                    "SELECT * FROM WIS_ANES_INQUIRY";
            }
        }
        public string AnesInformations_GetAnesthesiaInquiryDataBy
        {
            get
            {
                return
                    "SELECT  *  FROM WIS_ANES_INQUIRY WHERE (PAT_ID = :PatientID) AND (Visit_ID = :VisitID) AND (OPER_ID = :OperID)";
            }
        }
        public string AnesInformations_GetAnesthesiaPACUData
        {
            get
            {
                return
                    "SELECT PAT_ID, VISIT_ID, OPER_ID, NOTE, SUMM_START_TIME, SUMM_END_TIME, TOTAL_TIME, IN_FLUIDS_AMOUNT, OUT_FLUIDS_AMOUNT, FS1, FS2, FS3, FS4, FS5, FS6, ENTERED_BY, RECOVERY_HOUR, RECOVERY_MINUTE, BLOOD_TRANSFERED, BLOODPLASMA_TRANSFERED, "
                    + " OTHER_IN_AMOUNT, ANALGESIC_METHOD, FS7, FS8, FS9, FS10, FS11, FS12, FS13, FS14, FS15, FS16, FS17, FS18, FS19, FS20, FS21, FS22, FS23,  FS24, FS25, FS26, FS27, FS28, FS29, FS30, ENTERED_BY_1, ENTERED_BY_2 FROM WIS_ANES_RECOVERY";

            }
        }
        public string AnesInformations_GetAnesthesiaPACUDataBy
        {
            get
            {
                return
                    "SELECT PAT_ID, VISIT_ID, OPER_ID, NOTE, SUMM_START_TIME, SUMM_END_TIME, TOTAL_TIME, IN_FLUIDS_AMOUNT, OUT_FLUIDS_AMOUNT, FS1, FS2, FS3, FS4, FS5, FS6, ENTERED_BY, RECOVERY_HOUR, RECOVERY_MINUTE, BLOOD_TRANSFERED, BLOODPLASMA_TRANSFERED, "
                    + " OTHER_IN_AMOUNT, ANALGESIC_METHOD, FS7, FS8, FS9, FS10, FS11, FS12, FS13, FS14, FS15, FS16, FS17, FS18, FS19, FS20, FS21, FS22, FS23,  FS24, FS25, FS26, FS27, FS28, FS29, FS30, ENTERED_BY_1, ENTERED_BY_2 FROM WIS_ANES_RECOVERY"
                    + " WHERE (Pat_ID = :PatientID) AND (Visit_ID = :VisitID) AND (Oper_ID = :OperID)";

            }
        }
        public string AnesInformations_GetDeptAsaGrade
        {
            get
            {
                return
                    "SELECT C.DEPT_NAME,count(decode(ASA_GRADE,'Ⅰ',1,0)) 一级,count(decode(ASA_GRADE,'Ⅱ',1,0)) 二级,count(decode(ASA_GRADE,'Ⅲ',1,0)) 三级,count(decode(ASA_GRADE,'IV',1,0)) 四级,"
                    + " count(decode(ASA_GRADE,'V',1,0)) 五级,count(decode(ASA_GRADE,'E',1,0)) 六级,to_number(to_char(B.START_DATE_TIME,'yyyy')) YEAR,to_number(to_char(B.START_DATE_TIME,'mm')) MONTH "
                    + " FROM WIS_ANES_PLAN A, WIS_OPER_MASTER B,   WIS_DICT_DEPT C WHERE  A.PAT_ID = B.PAT_ID and A.VISIT_ID = B.VISIT_ID AND A.OPER_ID = B.OPER_ID AND  B.DEPT_STAYED = C.DEPT_CODE(+) and  "
                    + " to_number(to_char(B.START_DATE_TIME,'yyyy'))= :Year and to_number(to_char(B.START_DATE_TIME,'mm'))= :Month GROUP BY C.DEPT_NAME,to_number(to_char(B.START_DATE_TIME,'yyyy')),  to_number(to_char(B.START_DATE_TIME,'mm'))";
            }
        }

        public string AnesInformations_GetAnesMethod
        {
            get
            {
                return
                    "SELECT ANES_METHOD,COUNT(ANES_METHOD) AS COUNT ,to_number(to_char(START_DATE_TIME,'yyyy')) YEAR,to_number(to_char(START_DATE_TIME,'mm')) MONTH FROM  WIS_OPER_MASTER"
                    + " WHERE ANES_METHOD IS NOT NULL AND trim(ANES_METHOD) <> ''AND to_number(to_char(START_DATE_TIME,'yyyy')) = :Year AND to_number(to_char(START_DATE_TIME,'mm')) = :Month "
                    + " GROUP BY ANES_METHOD,to_number(to_char(START_DATE_TIME,'yyyy')), to_number(to_char(START_DATE_TIME,'mm')) ORDER BY ANES_METHOD,to_number(to_char(START_DATE_TIME,'yyyy')),to_number(to_char(START_DATE_TIME,'mm'))";

            }
        }
        public string AnesInformations_GetPunctureRecordDataTable
        {
            get
            {
                return
                    "SELECT * FROM WIS_PUNCTURE_RECORD WHERE PAT_ID=:patientID AND VISIT_ID=:visitID AND OPER_ID=:operID";
            }
        }
        public string AnesInformations_UpdateOperationScheduleStatus
        {
            get
            {
                return
                    "Update WIS_OPER_SCHEDULE set state =:Status WHERE PAT_ID=:PatientID AND VISIT_ID=:VisitID AND OPER_ID=:OperID";
            }
        }
        public string AnesInformations_GetAnesOperHandoverDataTable
        {
            get
            {
                return
                    "SELECT * FROM WIS_ANES_OPER_HANDOVER WHERE PAT_ID=:PatientID AND VISIT_ID=:VisitID AND OPER_ID=:OperID";
            }
        }
        public string AnesthesiaSheet_GetScheduledOperationName
        {
            get
            {
                return
                    "SELECT * FROM WIS_SCHEDULE_OPER_NAME WHERE PAT_ID=:PatientID AND VISIT_ID=:VisitID AND schedule_id=:OperID";
            }
        }
        public string AnesInformations_GetOperShiftRecordDataTable
        {
            get
            {
                return
                    "SELECT * FROM WIS_OPER_SHIFT_RECORD WHERE PAT_ID=:PatientID AND VISIT_ID=:VisitID AND OPER_ID=:OperID";
            }
        }
        #endregion

        #region Dict


        public string Dict_GetAssayDetails
        {
            get
            {
                return
                    " SELECT  A.TEST_NO, A.REPORT_ITEM_NAME, A.RESULT, A.REFERENCE_RESULT,A.RESULT_DATE_TIME,B.RESULTS_RPT_DATE_TIME"
                              + "  FROM     WIS_LAB_TEST_DETAIL A,  WIS_LAB_TEST_MASTER B"
                              + "  WHERE   A.TEST_NO = B.TEST_NO and  (B.PAT_ID =:patientID) AND (B.VISIT_ID = :visitID)"
                              + "  AND ( B.TEST_CAUSE like :testCause) AND B.RESULTS_RPT_DATE_TIME > :startTime "
                              + "  AND B.RESULTS_RPT_DATE_TIME < :endTime "
                              + "  ORDER BY B.RESULTS_RPT_DATE_TIME";
            }
        }
        public string Dict_GetDeptInfo
        {
            get
            {
                return
                    " SELECT SERIAL_NO, DEPT_CODE, DEPT_NAME, DIRECIOR_NAME, APPROVED_BED_NUM, ACTUAL_BED_NUM, APPROVED_DOCTOR_NUM,  DOCTOR_NUM_1, DOCTOR_NUM_2, APPROVED_NURSE_NUM,HOLISTIC_NURSING_INDICATOR, NURSE_NUM_1, NURSE_NUM_2, NURSE_NUM_3, "
                   + " DEPT_CLINIC_ATTR, NURSING_INDEX_SYSTEM, HEADNURSE_NAME, INPUT_CODE FROM WIS_DICT_DEPT_INFO";
            }
        }
        public string Dict_GetUserNameByUserID
        {
            get
            {
                return
                    " SELECT USER_ID FROM WIS_PERM_HIS_USER WHERE USER_NAME = :user_name ";
            }
        }
        public string Dict_GetOperationBillItems
        {
            get
            {
                return
                    " SELECT * FROM WIS_OPER_BILL_DETAIL WHERE PAT_ID = :patientID AND VISIT_ID = :visitID AND OPER_ID = :operID ";
            }
        }
        public string Dict_GetPatMonitorDataDict
        {
            get
            {
                return
                    "select * from WIS_DICT_PAT_MONITOR_DATA";
            }
        }
        public string Dict_GetPriceList
        {
            get
            {
                return
                    "select * from WIS_PRICE_LIST";
            }
        }
        public string Dict_GetPriceListByItemClass
        {
            get
            {
                return
                    "select * from WIS_PRICE_LIST where ITEM_CLASS = :itemClass";
            }
        }
        public string Dict_GetAnesthesiaEventTemplet
        {
            get
            {
                return
                    "SELECT TEMPLET_CLASS, ANES_METHOD, TEMPLET, ITEM_CLASS, ITEM_NO,  ITEM_NAME, ITEM_CODE, ITEM_SPEC, CONCENTRATION, PERFORM_SPEED,SPEED_UNITS, DOSAGE, DOSAGE_UNITS, ADMINISTRATOR, DURATIVE_INDICATOR, "
                   + " METHOD, EVENT_ATTR, START_AFTER_INPUT, DURATIVE, SUB_ITEM_INDICATOR,  CONCENTRATION_UNITS, BILL_ATTR, CREATE_BY FROM WIS_ANES_EVENT_TEMPLET ";
            }
        }

        public string Dict_GetAnesthesiaEventTempletByTempletName
        {
            get
            {
                return
                    "SELECT ADMINISTRATOR, ANES_METHOD, BILL_ATTR, CONCENTRATION, CONCENTRATION_UNITS, CREATE_BY, DOSAGE, DOSAGE_UNITS, DURATIVE, DURATIVE_INDICATOR, EVENT_ATTR, ITEM_CLASS, ITEM_CODE, ITEM_NAME, "
              + "  ITEM_NO, ITEM_SPEC, METHOD, PERFORM_SPEED, SPEED_UNITS, START_AFTER_INPUT, SUB_ITEM_INDICATOR, TEMPLET, TEMPLET_CLASS FROM WIS_ANES_EVENT_TEMPLET WHERE (TEMPLET = :TempletName)";
            }
        }
        public string Dict_GetMonitorDictAll
        {
            get
            {
                return
                    "SELECT *  FROM WIS_DICT_MONITOR ORDER BY TO_NUMBER(TRANSLATE(MONITOR_LABEL,'9876543210' || MONITOR_LABEL,'9876543210')),MONITOR_LABEL";
            }
        }
        public string Dict_GetMonitorDict
        {
            get
            {
                return
                    "SELECT MONITOR_LABEL, MANU_FIRM_NAME, MODEL, INTERFACE_TYPE,  INTERFACE_DESC, IP_ADDR, MAC_ADDR, LAST_RECV_TIME, LAST_RECV_BED_ID,  DUPLEX_FLAG, AUTOIN_FLAG, COMM_PORT, BAUD_RATE, BYTE_SIZE, PARITY, "
                    + " STOP_BITS, F_OUTX, F_INX, F_HARDWARE, TX_QUEUESIZE, RX_QUEUESIZE,  XON_LIM, XOFF_LIM, XON_CHAR, XOFF_CHAR, ERROR_CHAR, EVENT_CHAR,   DRIVER_PROG, PRIORITY, ITEM_TYPE, AUTO_LOAD, START_DATE_TIME,  DEFAULT_RECV_FREQUENCY, CURRENT_RECV_FREQUENCY, "
                    + " CURRENT_RECV_TIMES_UPLIMIT, CURRENT_RECV_ITEMS, WARD_CODE,  WARD_TYPE, BED_NO, PAT_ID, VISIT_ID, OPER_ID, USING_INDICATOR,  FREQUENCY_DISPLAY, MEMO, DATALOG_START_TIME, PC_PORT,  DATALOG_STATUS, IP_PORT, IN_PORT, OUT_PORT FROM WIS_DICT_MONITOR WHERE WARD_TYPE = :wardType "
                    + " ORDER BY TO_NUMBER(TRANSLATE(MONITOR_LABEL,'9876543210' || MONITOR_LABEL,'9876543210')),MONITOR_LABEL";
            }
        }
        public string Dict_GetMonitorDictByItemType
        {
            get
            {
                return
                    "SELECT MONITOR_LABEL, MANU_FIRM_NAME, MODEL, INTERFACE_TYPE,  INTERFACE_DESC, IP_ADDR, MAC_ADDR, LAST_RECV_TIME, LAST_RECV_BED_ID,  DUPLEX_FLAG, AUTOIN_FLAG, COMM_PORT, BAUD_RATE, BYTE_SIZE, PARITY, "
                    + " STOP_BITS, F_OUTX, F_INX, F_HARDWARE, TX_QUEUESIZE, RX_QUEUESIZE,  XON_LIM, XOFF_LIM, XON_CHAR, XOFF_CHAR, ERROR_CHAR, EVENT_CHAR,   DRIVER_PROG, PRIORITY, ITEM_TYPE, AUTO_LOAD, START_DATE_TIME,  DEFAULT_RECV_FREQUENCY, CURRENT_RECV_FREQUENCY, "
                    + " CURRENT_RECV_TIMES_UPLIMIT, CURRENT_RECV_ITEMS, WARD_CODE,  WARD_TYPE, BED_NO, PAT_ID, VISIT_ID, OPER_ID, USING_INDICATOR,  FREQUENCY_DISPLAY, MEMO, DATALOG_START_TIME, PC_PORT,  DATALOG_STATUS, IP_PORT, IN_PORT, OUT_PORT FROM WIS_DICT_MONITOR WHERE ITEM_TYPE=:itemType AND WARD_TYPE = :wardType "
                    + " ORDER BY TO_NUMBER(TRANSLATE(MONITOR_LABEL,'9876543210' || MONITOR_LABEL,'9876543210')),MONITOR_LABEL";
            }
        }
        public string Dict_GetAnesthesiaInputDict
        {
            get
            {
                return
                    "SELECT  SERIAL_NO, ITEM_CLASS, ITEM_NAME, ITEM_CODE FROM WIS_DICT_ANES_INPUT ORDER BY ITEM_CLASS, SERIAL_NO";
            }
        }
        public string Dict_GetAnesthesiaInputDictByItemClass
        {
            get
            {
                return
                    "SELECT ITEM_CLASS, ITEM_CODE, ITEM_NAME, SERIAL_NO FROM WIS_DICT_ANES_INPUT WHERE (ITEM_CLASS = :ITEM_CLASS) ORDER BY ITEM_CLASS, SERIAL_NO";
            }
        }
        public string Dict_GetDiagnosisDict
        {
            get
            {
                return
                    "SELECT DIAGNOSIS_CODE, DIAGNOSIS_NAME, STD_INDICATOR, APPROVED_INDICATOR, CREATE_DATE_TIME, INPUT_CODE, INFECT_INDICATOR, HEALTH_LEVEL,  INPUT_CODE_WB, DISEASE_SORT, DIAG_INDICATOR FROM   WIS_DICT_DIAGNOSIS";
            }
        }
        public string Dict_GetAnesthesiaEventOpenByItemclass
        {
            get
            {
                return
                    "SELECT * FROM WIS_ANES_EVENT_OPEN WHERE (ITEM_CLASS = :ITEM_CLASS) ORDER BY ITEM_NO";
            }
        }
        public string Dict_GetAllEventOpen
        {
            get
            {
                return
                    "SELECT ADMINISTRATOR, CONCENTRATION, CONCENTRATION_UNITS, DOSAGE, DOSAGE_UNITS, DURATIVE_INDICATOR, EVENT_ATTR, EVENT_ATTR_2, IN_ORDER, ITEM_CLASS, ITEM_CODE, ITEM_NAME, ITEM_NO, ITEM_SPEC, METHOD, OPER_CLASS, "
                   + " PERFORM_SPEED, REL_BILL, SPEED_UNITS, SUPPLIER_NAME FROM WIS_ANES_EVENT_OPEN ORDER BY ITEM_NO ";
            }
        }
        public string Dict_GetEventOpenByAttr
        {
            get
            {
                return
                    "SELECT * FROM WIS_ANES_EVENT_OPEN WHERE (ITEM_CLASS = :ITEM_CLASS) AND (EVENT_ATTR_2 = :EVENT_ATTR_2) ORDER BY ITEM_NO";
            }
        }
        public string Dict_GetEventOpenByhuxi
        {
            get
            {
                return
                    " SELECT ITEM_NO, ITEM_CLASS, ITEM_NAME, ITEM_CODE, ITEM_SPEC, DOSAGE,  DOSAGE_UNITS, ADMINISTRATOR, IN_ORDER, REL_BILL, OPER_CLASS, DURATIVE_INDICATOR, METHOD, PERFORM_SPEED, SPEED_UNITS, EVENT_ATTR, "
                   + " CONCENTRATION, CONCENTRATION_UNITS, EVENT_ATTR_2, SUPPLIER_NAME FROM WIS_ANES_EVENT_OPEN WHERE (ITEM_CLASS IN (:Param1, :Param2, :Param3)) OR (ITEM_NAME IN (:Param4, :Param5, :Param6)) ORDER BY ITEM_NO";
            }
        }
        public string Dict_GetOperationDict
        {
            get
            {
                return
                    "SELECT OPER_CODE, OPER_NAME, INPUT_CODE, OPER_SCALE, STD_INDICATOR, APPROVED_INDICATOR, CREATE_DATE_TIME FROM WIS_DICT_OPERATION";
            }

        }
        public string Dict_GetAnesDict
        {
            get
            {
                return
                    "SELECT * FROM WIS_DICT_ANES";
            }

        }
        public string Dict_GetHisUserByUserJob
        {
            get
            {
                return
                   " SELECT USER_NAME, USER_ID, USER_JOB, USER_DEPT, RESERVED01, CREATE_DATE_TIME,INPUT_CODE FROM WIS_PERM_HIS_USER WHERE (USER_JOB = :userJob)";
            }
        }
        public string Dict_GetHisUsers
        {
            get
            {
                return
                    "SELECT USER_NAME, USER_ID, USER_JOB, USER_DEPT, RESERVED01, CREATE_DATE_TIME,INPUT_CODE FROM WIS_PERM_HIS_USER";
            }
        }
        public string Dict_GetDeptDict
        {
            get
            {
                return
                    "SELECT * FROM WIS_DICT_DEPT ORDER BY DEPT_NAME";
            }
        }
        public string Dict_GetDeptDictByDeptCode
        {
            get
            {
                return
                    "SELECT * FROM WIS_DICT_DEPT WHERE DEPT_CODE = :DEPT_CODE";
            }
        }
        public string Dict_GetLabTestMaster
        {
            get
            {
                return
                    "SELECT * FROM WIS_LAB_TEST_MASTER WHERE PAT_ID = :PatientID AND VISIT_ID = :VisitID ORDER BY RESULTS_RPT_DATE_TIME";
            }

        }
        public string Dict_GetLabResult
        {
            get
            {
                return
                    "SELECT * FROM WIS_LAB_TEST_DETAIL WHERE TEST_NO = :TestNo ORDER BY TEST_NO,ITEM_NO";
            }
        }
        public string Dict_GetCustomDataExt
        {
            get
            {
                return
                    "SELECT * FROM WIS_CUSTOM_DATA_EXT";
            }
        }

        public string Dict_GetCustomDataExtByPatient
        {
            get
            {
                return
                    "SELECT * FROM WIS_CUSTOM_DATA_EXT WHERE PAT_ID = :PatientID AND VISIT_ID = :VisitID AND OPER_ID = :OperID";
            }
        }

        public string Dict_GetCustomFieldDict
        {
            get
            {
                return
                    "SELECT * FROM WIS_DICT_CUSTOM_FIELD";
            }
        }

        public string Dict_GetTableDesc
        {
            get
            {
                return
                    "SELECT * FROM WIS_DICT_CUSTOM_FIELD WHERE FIELD_DESC = 'TABLE'";
            }
        }

        public string Dict_GetTableDescByTableNames
        {
            get
            {
                return
                    "SELECT * FROM WIS_DICT_CUSTOM_FIELD WHERE (FIELD_DESC = :FIELD_DESC) OR (FIELD_DESC = 'TABLEOFALL')";
            }
        }
        public string Dict_GetDictSimpleTypes
        {
            get
            {
                return
                    "SELECT * FROM WIS_DICT_SIMPLETYPE";
            }
        }

        public string Dict_GetDictSimpleTypesByTypeKey
        {
            get
            {
                return
                    "SELECT * FROM WIS_DICT_SIMPLETYPE WHERE TYPE_KEY = :TYPEKEY";
            }
        }

        public string Dict_GetDictSimpleTypesTree
        {
            get
            {
                return
                    "SELECT * FROM WIS_DICT_SIMPLETYPE_TREE";
            }
        }
        public string Dict_GetDocumentTemplet
        {
            get
            {
                return
                    "SELECT * FROM WIS_ANES_DOC_TEMPLET";
            }
        }

        public string Dict_GetDocumentTempletByUserIDAndIsPrivate
        {
            get
            {
                return
                    "SELECT * FROM WIS_ANES_DOC_TEMPLET WHERE USER_ID=:USER_ID AND IS_PRIVATE = :ISPRIVATE AND EVENT_NO=:EVENT_NO";
            }
        }

        public string Dict_GetDocumentTempletByUserIDAndDocumentName
        {
            get
            {
                return
                    "SELECT * FROM WIS_ANES_DOC_TEMPLET WHERE USER_ID=:USER_ID AND DOC_NAME = :DOCUMENT_NAME AND EVENT_NO=:EVENT_NO";
            }
        }

        public string Dict_GetDocumentTempletByUserIDAndIsPrivateAndDocumentName
        {
            get
            {
                return
                    "SELECT * FROM WIS_ANES_DOC_TEMPLET WHERE USER_ID=:USER_ID AND IS_PRIVATE = :IsPrivate AND DOC_NAME = :DOCUMENT_NAME AND EVENT_NO=:EVENT_NO";
            }
        }

        public string Dict_GetDocumentTempletByUserIDAndIsPrivateAndDocumentNameAndIsJuBu
        {
            get
            {
                return
                    "SELECT * FROM WIS_ANES_DOC_TEMPLET WHERE USER_ID=:USER_ID AND IS_PRIVATE = :IsPrivate AND DOC_NAME = :DOCUMENT_NAME AND IS_PART = :IsJuBu AND EVENT_NO=:EVENT_NO";
            }
        }

        public string Dict_GetDocumentTempletByUserIDAndIsPrivateAndClassNameAndDocumentName
        {
            get
            {
                return
                    "SELECT * FROM WIS_ANES_DOC_TEMPLET WHERE USER_ID=:USER_ID AND IS_PRIVATE = :IsPrivate AND CLASS_NAME = :CLASS_NAME AND DOC_NAME = :DOCUMENT_NAME AND EVENT_NO=:EVENT_NO";
            }
        }

        public string Dict_GetDocumentTempletByUserIDAndIsPrivateAndClassNameAndDocumentNameAndIsJuBu
        {
            get
            {
                return
                    "SELECT * FROM WIS_ANES_DOC_TEMPLET WHERE USER_ID=:USER_ID AND IS_PRIVATE = :IsPrivate AND CLASS_NAME = :CLASS_NAME AND DOC_NAME = :DOCUMENT_NAME AND IS_PART = :IsJuBu AND EVENT_NO=:EVENT_NO";
            }
        }
        public string Dict_GetDocumentTempletPrivateAndPublicByUserID
        {
            get
            {
                return
                    "SELECT * FROM WIS_ANES_DOC_TEMPLET WHERE (USER_ID=:USER_ID or IS_PRIVATE = 0) AND EVENT_NO=:EVENT_NO";
            }
        }
        public string Dict_GetDocumentTempletPrivateAndPublicByUserIDAndDocumentName
        {
            get
            {
                return
                    "SELECT * FROM WIS_ANES_DOC_TEMPLET WHERE (USER_ID=:USER_ID or IS_PRIVATE = 0) AND DOC_NAME=:DOCUMENT_NAME AND EVENT_NO=:EVENT_NO";
            }
        }
        public string Dict_GetDocumentTempletPrivateAndPublicByUserIDAndDocumentNameAndIsJuBu
        {
            get
            {
                return
                    "SELECT * FROM WIS_ANES_DOC_TEMPLET WHERE (USER_ID=:USER_ID or IS_PRIVATE = 0) AND DOC_NAME=:DOCUMENT_NAME  AND IS_PART=:IsJuBu AND EVENT_NO=:EVENT_NO";
            }
        }
        public string Dict_GetDocumentTempletPrivateAndPublicByUserIDAndClassNameAndDocumentName
        {
            get
            {
                return
                    "SELECT * FROM WIS_ANES_DOC_TEMPLET WHERE (USER_ID=:USER_ID or IS_PRIVATE = 0) AND CLASS_NAME=:CLASS_NAME AND DOC_NAME=:DOCUMENT_NAME AND EVENT_NO=:EVENT_NO";
            }
        }
        public string Dict_GetDocumentTempletPrivateAndPublicByUserIDAndClassNameAndDocumentNameAndIsJuBu
        {
            get
            {
                return
                    "SELECT * FROM WIS_ANES_DOC_TEMPLET WHERE (USER_ID=:USER_ID or IS_PRIVATE = 0) AND CLASS_NAME=:CLASS_NAME AND DOC_NAME=:DOCUMENT_NAME  AND IS_PART=:IsJuBu AND EVENT_NO=:EVENT_NO";
            }
        }
        public string Dict_GetBloodGasDictByBlgStatus
        {
            get
            {
                return
                    "SELECT * FROM WIS_DICT_BLOOD_GAS WHERE BLG_STATUS=:BLG_STATUS";
            }
        }
        public string Dict_GetBloodGasDictPartialByBlgStatus
        {
            get
            {
                return
                    "SELECT BLG_CODE,BLG_NAME,BLG_REFER_VALUE FROM WIS_DICT_BLOOD_GAS WHERE BLG_STATUS=:BLG_STATUS";
            }
        }
        public string Dict_GetMaxDicUserId
        {
            get
            {
                return
                    "select max(USER_ID) from WIS_PERM_HIS_USER";
            }
        }

        public string Dict_GetEquipmentManagement
        {
            get
            {
                return @"SELECT A.INSTRUMENT_CODE,A.INSTRUMENT_NAME,A.SUPPLIER_NAME,A.MODEL_NUMBER,A.SERIAL_NUMBER,A.DEPOSIT_ADDRESS,
                         A.DATE_OF_MANUFACTURE,A.ATTRIBUTE FROM WIS_EQIP_MANAGEMENT A WHERE A.DEPT_TYPE=:DeptType";
            }
        }

        public string Dict_GetEquipmentByDay
        {
            get
            {
                return @"SELECT A.INSTRUMENT_CODE,A.INSTRUMENT_NO, CASE WHEN D.REPAIR_COUNT IS NULL THEN 0 ELSE D.REPAIR_COUNT END REPAIR_COUNT,
                         CASE  WHEN E.STATUS_COUNT IS NULL THEN 0 ELSE E.STATUS_COUNT END STATUS_COUNT,
                         A.INSTRUMENT_NAME, A.SUPPLIER_NAME,A.MODEL_NUMBER, A.SERIAL_NUMBER,A.DATE_OF_MANUFACTURE,A.ATTRIBUTE,
                         D.SITUATION,D.MAINTENANCE_TIME,E.STATUS FROM WIS_EQIP_MANAGEMENT A
                         LEFT OUTER JOIN (SELECT B.INSTRUMENT_CODE,B.REPAIR_COUNT,B.MAINTENANCE_TIME,B.SITUATION FROM WIS_EQIP_REPAIR B WHERE 
                         (TO_CHAR(B.maintenance_time, 'yyyy-MM-dd')) BETWEEN :dateTimePickerQuery  AND 
                          :dateTimePickerQueryEnd)D ON A.INSTRUMENT_CODE =D.INSTRUMENT_CODE
                         LEFT OUTER JOIN (SELECT C.INSTRUMENT_CODE,C.STATUS_COUNT,C.STATUS_TIME,C.STATUS FROM WIS_EQIP_STATUS C WHERE 
                         (TO_CHAR(C.STATUS_TIME, 'yyyy-MM-dd')) = :dateTimePickerQuery)E ON A.INSTRUMENT_CODE =E.INSTRUMENT_CODE WHERE A.DEPT_TYPE=:DeptType";
            }
        }

        #endregion

        #region MyDataSet

        public string MyDataSet_GetRoles
        {
            get
            {
                return
                    "SELECT ROLE_ID, APP_ID, NAME, DESCRIPTION, CREATE_DATE_TIME FROM WIS_PERM_ROLE";
            }
        }
        public string MyDataSet_GetRolesByAppId
        {
            get
            {
                return
                    "SELECT ROLE_ID, APP_ID, DESCRIPTION, NAME, CREATE_DATE_TIME FROM WIS_PERM_ROLE WHERE APP_ID=:appID";
            }
        }
        public string MyDataSet_GetApplication
        {
            get
            {
                return
                    "SELECT APP_ID, NAME, DESCRIPTION FROM WIS_CONF_APP";
            }
        }
        public string MyDataSet_GetUsersApplication
        {
            get
            {
                return
                    "SELECT APP_ID, USER_ID FROM MED_USERS_APPLICATIONS";
            }
        }
        public string MyDataSet_GetUserRolesByUserID
        {
            get
            {
                return
                    "SELECT USER_ID, ROLE_ID FROM WIS_PERM_USER_ROLE WHERE (USER_ID = :userID)";

            }
        }
        public string MyDataSet_GetPermissions
        {
            get
            {
                return
                    "SELECT PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID,DESCRIPTION FROM WIS_PERM_INDEX WHERE (UPPER(IS_VALID) = 'T')";
            }
        }
        public string MyDataSet_GetPermissionByAppId
        {
            get
            {
                return
                    "SELECT APP_ID, DESCRIPTION, IS_VALID, NAME, PERMISSION_ID, PERMISSION_KEY, SORT_ID FROM WIS_PERM_INDEX WHERE (APP_ID = :appID) AND (UPPER (IS_VALID) = 'T')";
            }
        }
        public string MyDataSet_GetPermissionByLoginName
        {
            get
            {
                return
                    "SELECT PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID,DESCRIPTION ,LOGIN_NAME FROM "
                    + " ( SELECT DISTINCT A.PERMISSION_ID, A.APP_ID, A.NAME, A.PERMISSION_KEY, A.SORT_ID, A.IS_VALID,A.DESCRIPTION ,E.LOGIN_NAME FROM WIS_PERM_INDEX A,WIS_CONF_APP B,WIS_PERM_ROLE_PERMISSION C,WIS_PERM_USER_ROLE D,WIS_PERM_USER E"
                   + " WHERE A.APP_ID = B.APP_ID AND A.PERMISSION_ID = C.PERMISSION_ID AND D.ROLE_ID = C.ROLE_ID AND D.USER_ID = E.USER_ID   ) WHERE  APP_ID = :APP_ID  AND LOGIN_NAME = :LoginName ";
            }
        }
        public string MyDataSet_GetRolePermissionByRoleID
        {
            get
            {
                return
                    "SELECT ROLE_ID, PERMISSION_ID FROM WIS_PERM_ROLE_PERMISSION WHERE (ROLE_ID = :roleID)";
            }
        }
        public string MyDataSet_GetUsers
        {
            get
            {
                return
                    "SELECT USER_ID, LOGIN_NAME, LOGIN_PWD, USER_NAME, DEPT_ID, CREATE_DATE_TIME,IS_VALID, MEMO FROM WIS_PERM_USER WHERE IS_VALID = 'T' OR IS_VALID = 't'";
            }
        }
        public string MyDataSet_GetUserByUserName
        {
            get
            {
                return
                    "SELECT CREATE_DATE_TIME, DEPT_ID, IS_VALID, LOGIN_NAME, LOGIN_PWD, MEMO, USER_ID, USER_NAME FROM WIS_PERM_USER WHERE (IS_VALID = 'T' OR IS_VALID = 't') AND (LOGIN_NAME = :LoginName)";
            }
        }
        public string MyDataSet_GetUserByUserAndPwd
        {
            get
            {
                return
                    "SELECT CREATE_DATE_TIME, DEPT_ID, IS_VALID, LOGIN_NAME, LOGIN_PWD, MEMO, USER_ID, USER_NAME FROM WIS_PERM_USER WHERE (IS_VALID = 'T' OR IS_VALID = 't') AND (LOGIN_NAME = :LoginName) AND (LOGIN_PWD = :LoginPwd)";
            }
        }
        public string MyDataSet_GetUserTables
        {
            get
            {
                return
                    "SELECT   *   FROM   Dba_Tables   WHERE  owner in('MEDCOMM','MEDSURGERY')";

            }
        }
        public string MyDataSet_GetDocument
        {
            get
            {
                return
                    "SELECT DOCUMENTNAME, DOCUMENTPATH, DOCUMENTCONTENT,DOCUMENTTIME FROM WIS_ANES_DOC";
            }
        }
        public string MyDataSet_GetPerKindByAppId
        {
            get
            {
                return
                    "select KIND_ID,APP_ID,NAME, SORT_ID,IS_VALID,DESCRIPTION from  WIS_PERM_KIND where (APP_ID = :appID) AND (UPPER(IS_VALID) = 'T') order by SORT_ID";
            }
        }
        public string MyDataSet_GetPerKindRela
        {
            get
            {
                return
                    "SELECT     KIND_ID, PERMISSION_ID FROM  WIS_PERM_KIND_RELA";
            }
        }
        public string MyDataSet_GetPerKindRelaByID
        {
            get
            {
                return
                    "SELECT     KIND_ID, PERMISSION_ID FROM  WIS_PERM_KIND_RELA where PERMISSION_ID = :PERMISSION_ID";
            }

        }
        #endregion

        #region PatientBaseInformations
        public string PatientBaseInformations_GetHistoryOpertionsInfo
        {
            get
            {
                return
                    "SELECT A.PAT_ID, A.VISIT_ID, WIS_PAT_MASTER_INDEX.SEX,  WIS_PAT_MASTER_INDEX.NAME, WIS_PAT_MASTER_INDEX.DATE_OF_BIRTH,   A.OPER_ID,  NVL(WIS_DICT_DEPT.DEPT_NAME,A.DEPT_STAYED) DEPT_NAME, A.DEPT_STAYED, A.OPERATING_ROOM, "
                   + "  A.OPERATING_ROOM_NO, A.SEQUENCE, A.DIAG_BEFORE_OPER,  A.PAT_CONDITION, A.OPER_SCALE, A.ISOLATION_INDICATOR,   A.SURGEON, A.OPERATING_DEPT, A.FIRST_ASSISTANT, A.SECOND_ASSISTANT,   A.THIRD_ASSISTANT, A.FOURTH_ASSISTANT, A.ANES_METHOD, "
                   + "  A.ANES_DOCTOR, A.ANES_ASSISTANT, A.BLOOD_TRAN_DOCTOR,  A.SECOND_OPER_NURSE, A.FIRST_SUPPLY_NURSE,   A.FIRST_OPER_NURSE, A.SECOND_SUPPLY_NURSE, A.ENTERED_BY,   A.THIRD_SUPPLY_NURSE, A.OPER_STATUS, A.EMERGENCY_INDICATOR, "
                   + "  A.THIRD_ANES_ASSISTANT, A.SECOND_ANES_ASSISTANT,   A.RECK_GROUP, A.FOURTH_ANES_ASSISTANT,  A.SECOND_ANES_DOCTOR, A.THIRD_ANES_DOCTOR,   A.OPER_POSITION, A.SPECIAL_EQUIPMENT, A.SPECIAL_INFECT,  A.HEPATITIS_INDICATOR, A.OPERATION_ID, A.SCHEDULED_DATE_TIME START_DATE_TIME, "
                   + "  WIS_ANES_PLAN.OPER_NAME,   A.BED_NO,WIS_ANES_PLAN.ASA_GRADE,A.MEMO,trunc(months_between(sysdate,WIS_PAT_MASTER_INDEX.DATE_OF_BIRTH)/12) AGE FROM WIS_OPER_MASTER  A, WIS_DICT_DEPT, WIS_PAT_MASTER_INDEX,  WIS_ANES_PLAN "
                   + " WHERE  A.DEPT_STAYED = WIS_DICT_DEPT.DEPT_CODE(+) AND  A.PAT_ID = WIS_PAT_MASTER_INDEX.PAT_ID AND A.PAT_ID = WIS_ANES_PLAN.PAT_ID(+) AND  A.VISIT_ID = WIS_ANES_PLAN.VISIT_ID(+) AND  A.OPER_ID = WIS_ANES_PLAN.OPER_ID(+)";
            }
        }

        public string PatientBaseInformations_GetOperationsInfoByOperStatus
        {
            get
            {
                return
                    "SELECT A.PAT_ID, A.VISIT_ID, WIS_PAT_MASTER_INDEX.SEX,   WIS_PAT_MASTER_INDEX.NAME, WIS_PAT_MASTER_INDEX.DATE_OF_BIRTH,   A.OPER_ID, WIS_DICT_DEPT.DEPT_NAME, A.DEPT_STAYED, A.OPERATING_ROOM,  A.OPERATING_ROOM_NO, A.SEQUENCE, A.DIAG_BEFORE_OPER, "
                  + "   A.PAT_CONDITION, A.OPER_SCALE, A.ISOLATION_INDICATOR,   NVL(USERS_SURGEON.USER_NAME,A.SURGEON) SURGEON,   A.OPERATING_DEPT, A.FIRST_ASSISTANT, A.SECOND_ASSISTANT,  A.THIRD_ASSISTANT, A.FOURTH_ASSISTANT, A.ANES_METHOD,   NVL(USRS_ANES_DOCTOR.USER_NAME,A.ANES_DOCTOR) ANES_DOCTOR, "
                  + "   A.ANES_ASSISTANT, A.BLOOD_TRAN_DOCTOR,  A.SECOND_OPER_NURSE,   NVL(USERS_FIRST_S.USER_NAME,A.FIRST_SUPPLY_NURSE) FIRST_SUPPLY_NURSE,   NVL(USERS_FIRST_O.USER_NAME,A.FIRST_OPER_NURSE) FIRST_OPER_NURSE, A.SECOND_SUPPLY_NURSE, A.ENTERED_BY, "
                  + "   A.THIRD_SUPPLY_NURSE, A.OPER_STATUS, A.EMERGENCY_INDICATOR,  A.THIRD_ANES_ASSISTANT, A.SECOND_ANES_ASSISTANT,  A.RECK_GROUP, A.FOURTH_ANES_ASSISTANT,    A.SECOND_ANES_DOCTOR, A.THIRD_ANES_DOCTOR,   A.OPER_POSITION, A.SPECIAL_EQUIPMENT, A.SPECIAL_INFECT, "
                  + "  A.HEPATITIS_INDICATOR, A.OPERATION_ID, A.SCHEDULED_DATE_TIME START_DATE_TIME,  WIS_ANES_PLAN.OPER_NAME,  A.BED_NO,WIS_ANES_PLAN.ASA_GRADE,A.MEMO,   trunc(months_between(sysdate,WIS_PAT_MASTER_INDEX.DATE_OF_BIRTH)/12) AGE FROM WIS_OPER_MASTER  A, "
                  + "  WIS_DICT_DEPT,  WIS_PAT_MASTER_INDEX,   WIS_ANES_PLAN,     WIS_PERM_HIS_USER USRS_ANES_DOCTOR, WIS_PERM_HIS_USER USERS_SURGEON,  WIS_PERM_HIS_USER USERS_FIRST_S, WIS_PERM_HIS_USER USERS_FIRST_O WHERE  A.DEPT_STAYED = WIS_DICT_DEPT.DEPT_CODE(+) AND A.PAT_ID = WIS_PAT_MASTER_INDEX.PAT_ID AND "
                  + " A.PAT_ID = WIS_ANES_PLAN.PAT_ID(+) AND  A.VISIT_ID = WIS_ANES_PLAN.VISIT_ID(+) AND  A.OPER_ID = WIS_ANES_PLAN.OPER_ID(+) AND A.ANES_DOCTOR = USRS_ANES_DOCTOR.USER_ID(+) AND A.SURGEON = USERS_SURGEON.USER_ID(+) AND "
                  + " A.FIRST_SUPPLY_NURSE = USERS_FIRST_S.USER_ID(+) AND A.FIRST_OPER_NURSE = USERS_FIRST_O.USER_ID(+) AND (A.OPER_STATUS = :OperStatus)";
            }

        }
        public string PatientBaseInformations_GetOperationsInfoByStartTime
        {
            get
            {
                return
                    "SELECT A.PAT_ID, A.VISIT_ID, WIS_PAT_MASTER_INDEX.SEX,  WIS_PAT_MASTER_INDEX.NAME, WIS_PAT_MASTER_INDEX.DATE_OF_BIRTH,  A.OPER_ID, WIS_DICT_DEPT.DEPT_NAME, A.DEPT_STAYED, A.OPERATING_ROOM,   A.OPERATING_ROOM_NO, A.SEQUENCE, A.DIAG_BEFORE_OPER, "
                  + "  A.PAT_CONDITION, A.OPER_SCALE, A.ISOLATION_INDICATOR,  A.SURGEON, A.OPERATING_DEPT, A.FIRST_ASSISTANT, A.SECOND_ASSISTANT,  A.THIRD_ASSISTANT, A.FOURTH_ASSISTANT, A.ANES_METHOD,   A.ANES_DOCTOR, A.ANES_ASSISTANT, A.BLOOD_TRAN_DOCTOR, "
                  + "  A.SECOND_OPER_NURSE, A.FIRST_SUPPLY_NURSE,  A.FIRST_OPER_NURSE, A.SECOND_SUPPLY_NURSE, A.ENTERED_BY,   A.THIRD_SUPPLY_NURSE, A.OPER_STATUS, A.EMERGENCY_INDICATOR,  A.THIRD_ANES_ASSISTANT, A.SECOND_ANES_ASSISTANT, "
                  + "  A.RECK_GROUP, A.FOURTH_ANES_ASSISTANT,   A.SECOND_ANES_DOCTOR, A.THIRD_ANES_DOCTOR,  A.OPER_POSITION, A.SPECIAL_EQUIPMENT, A.SPECIAL_INFECT,   A.HEPATITIS_INDICATOR, A.OPERATION_ID, A.SCHEDULED_DATE_TIME START_DATE_TIME, "
                  + "  WIS_ANES_PLAN.OPER_NAME,  A.BED_NO,WIS_ANES_PLAN.ASA_GRADE,A.MEMO,  trunc(months_between(sysdate,DATE_OF_BIRTH)/12) AGE FROM WIS_OPER_MASTER A, WIS_DICT_DEPT,  WIS_PAT_MASTER_INDEX, WIS_ANES_PLAN WHERE "
                  + " A.DEPT_STAYED = WIS_DICT_DEPT.DEPT_CODE(+)  and A.PAT_ID = WIS_PAT_MASTER_INDEX.PAT_ID and A.PAT_ID = WIS_ANES_PLAN.PAT_ID(+) and  A.VISIT_ID = WIS_ANES_PLAN.VISIT_ID(+) AND A.OPER_ID = WIS_ANES_PLAN.OPER_ID(+) "
                  + " and (SCHEDULED_DATE_TIME >= :startTime) AND (SCHEDULED_DATE_TIME <= :endTime) and oper_status >= 0 order by oper_status,SCHEDULED_DATE_TIME ";
            }
        }
        public string PatientBaseInformations_GetPatsInHospital
        {
            get
            {
                return
                    "SELECT PAT_ID, VISIT_ID, WARD_CODE, DEPT_CODE, BED_NO,   ADMISSION_DATE_TIME, ADM_WARD_DATE_TIME, DIAGNOSIS,   PAT_CONDITION, NURSING_CLASS, DOCTOR_IN_CHARGE, OPERATING_DATE,  BILLING_DATE_TIME, PREPAYMENTS, TOTAL_COSTS, TOTAL_CHARGES, "
                   + " GUARANTOR, GUARANTOR_ORG, GUARANTOR_PHONE_NUM,  BILL_CHECKED_DATE_TIME, SETTLED_INDICATOR, RESERVED01, RESERVED02,   RESERVED03, RESERVED04, RESERVED05, RESERVED06, RESERVED07,  RESERVED08, RESERVED09, RESERVED10, RESERVED_DATE_1,  RESERVED_DATE_2, START_DATE_TIME, FREQUENCY_NURSE, "
                   + "  NURSE_IN_CHARGE FROM WIS_PAT_IN_HOS";
            }
        }
        public string PatientBaseInformations_GetPatsInHospitalByPatientID
        {
            get
            {
                return
                    "SELECT * FROM WIS_PAT_IN_HOS  WHERE PAT_ID =:PATIENT_ID";
            }
        }
        public string PatientBaseInformations_GetPatsInHospitalBy
        {
            get
            {
                return
                    "SELECT PAT_ID, VISIT_ID, WARD_CODE, DEPT_CODE, BED_NO,   ADMISSION_DATE_TIME, ADM_WARD_DATE_TIME, DIAGNOSIS,   PAT_CONDITION, NURSING_CLASS, DOCTOR_IN_CHARGE, OPERATING_DATE,  BILLING_DATE_TIME, PREPAYMENTS, TOTAL_COSTS, TOTAL_CHARGES, "
                   + " GUARANTOR, GUARANTOR_ORG, GUARANTOR_PHONE_NUM,  BILL_CHECKED_DATE_TIME, SETTLED_INDICATOR, RESERVED01, RESERVED02,   RESERVED03, RESERVED04, RESERVED05, RESERVED06, RESERVED07,  RESERVED08, RESERVED09, RESERVED10, RESERVED_DATE_1,  RESERVED_DATE_2, START_DATE_TIME, FREQUENCY_NURSE, "
                   + "  NURSE_IN_CHARGE,DEP_ID FROM WIS_PAT_IN_HOS  WHERE PAT_ID =:PATIENT_ID AND VISIT_ID=:VISIT_ID ";
            }
        }
        public string PatientBaseInformations_PatientInformationByMinOperStauts
        {
            get
            {
                return
                    "SELECT A.PAT_ID, A.VISIT_ID, WIS_PAT_MASTER_INDEX.NAME, A.OPER_ID,  A.OPER_STATUS, WIS_ANES_PLAN.BED_NO,  A.OPERATING_ROOM_NO FROM WIS_OPER_MASTER  A, WIS_PAT_MASTER_INDEX,   WIS_ANES_PLAN     WHERE "
                   + " A.PAT_ID = WIS_PAT_MASTER_INDEX.PAT_ID and A.PAT_ID = WIS_ANES_PLAN.PAT_ID(+) and A.VISIT_ID = WIS_ANES_PLAN.VISIT_ID(+) AND A.OPER_ID = WIS_ANES_PLAN.OPER_ID(+) and (A.OPER_STATUS >= :OperStatus)";
            }

        }
        public string PatientBaseInformations_GetPatientInformation
        {
            get
            {
                return
                    "SELECT A.PAT_ID, A.VISIT_ID, WIS_PAT_MASTER_INDEX.NAME, A.OPER_ID,  A.OPER_STATUS, WIS_ANES_PLAN.BED_NO,   A.OPERATING_ROOM_NO FROM WIS_OPER_MASTER  A, WIS_PAT_MASTER_INDEX,  WIS_ANES_PLAN WHERE "
                + " A.PAT_ID = WIS_PAT_MASTER_INDEX.PAT_ID and A.PAT_ID = WIS_ANES_PLAN.PAT_ID(+) and A.VISIT_ID = WIS_ANES_PLAN.VISIT_ID(+) and A.OPER_ID = WIS_ANES_PLAN.OPER_ID(+) and (A.OPER_STATUS = :OperStatus) ";
            }
        }
        public string PatientBaseInformations_GetPatMasterIndexByPatient
        {
            get
            {
                return
                    "SELECT  BIRTH_PLACE, CHARGE_TYPE, CITIZENSHIP, CREATE_DATE_TIME,DATE_OF_BIRTH, IDENTITY, ID_NO, INP_NO, LAST_VISIT_DATE, MAILING_ADDRESS, NAME, NAME_PHONETIC, NATION, NEXT_OF_KIN, "
                   + " NEXT_OF_KIN_ADDR, NEXT_OF_KIN_PHONE, NEXT_OF_KIN_ZIP_CODE, OPERATOR, PAT_ID, PHONE_NUMBER_BUSINESS, PHONE_NUMBER_HOME,  RELATIONSHIP, SEX, UNIT_IN_CONTRACT, VIP_INDICATOR, ZIP_CODE  FROM WIS_PAT_MASTER_INDEX  WHERE (PAT_ID = :PatientID)";
            }
        }
        public string PatientBaseInformations_GetPatMasterIndex
        {
            get
            {
                return
                    " SELECT PAT_ID, INP_NO, NAME, NAME_PHONETIC, SEX, DATE_OF_BIRTH,  BIRTH_PLACE, CITIZENSHIP, NATION, ID_NO, IDENTITY, CHARGE_TYPE,  UNIT_IN_CONTRACT, MAILING_ADDRESS, ZIP_CODE, PHONE_NUMBER_HOME, "
                  + "  PHONE_NUMBER_BUSINESS, NEXT_OF_KIN, RELATIONSHIP, NEXT_OF_KIN_ADDR,   NEXT_OF_KIN_ZIP_CODE, NEXT_OF_KIN_PHONE, LAST_VISIT_DATE,  VIP_INDICATOR, CREATE_DATE_TIME, OPERATOR  FROM WIS_PAT_MASTER_INDEX WHERE ROWNUM< 2";
            }
        }
        public string PatientBaseInformations_GetVisitDataTable
        {
            get
            {
                return
                    "SELECT * FROM WIS_PAT_VISIT WHERE PAT_ID = :PatientID AND VISIT_ID = :VisitID ";
            }
        }
        public string PatientBaseInformations_GetOperationSchedule
        {
            get
            {
                return "select * from WIS_OPER_SCHEDULE WHERE PAT_ID=:PATIENT_ID AND VISIT_ID=:VISIT_ID";
            }
        }
        public string PatientBaseInformations_GetOperationScheduleByKeys
        {
            get
            {
                return "select * from WIS_OPER_SCHEDULE WHERE PAT_ID=:PATIENT_ID AND VISIT_ID=:VISIT_ID AND SCHEDULE_ID=:SCHEDULE_ID";
            }
        }
        public string PatientBaseInformations_GetPatOperation
        {
            get
            {
                return
                    "SELECT     WIS_OPER_SCHEDULE.PAT_ID, WIS_OPER_SCHEDULE.VISIT_ID, WIS_PAT_MASTER_INDEX.SEX, trunc(months_between(sysdate,WIS_PAT_MASTER_INDEX.DATE_OF_BIRTH)/12) AGE, WIS_PAT_MASTER_INDEX.NAME,  WIS_PAT_MASTER_INDEX.DATE_OF_BIRTH, "
                     + " WIS_OPER_SCHEDULE.SCHEDULE_ID, WIS_OPER_SCHEDULE.BED_NO, WIS_DICT_DEPT.dept_name,WIS_OPER_SCHEDULE.DEPT_STAYED,  WIS_OPER_SCHEDULE.SCHEDULED_DATE_TIME, WIS_OPER_SCHEDULE.OPERATING_ROOM,  WIS_OPER_SCHEDULE.OPERATING_ROOM_NO, WIS_OPER_SCHEDULE.SEQUENCE, "
                     + " WIS_OPER_SCHEDULE.DIAG_BEFORE_OPER, WIS_OPER_SCHEDULE.PAT_CONDITION,  WIS_OPER_SCHEDULE.OPER_SCALE, WIS_OPER_SCHEDULE.ISOLATION_INDICATOR, WIS_OPER_SCHEDULE.SURGEON,  WIS_OPER_SCHEDULE.OPERATING_DEPT, WIS_OPER_SCHEDULE.FIRST_ASSISTANT, "
                     + " WIS_OPER_SCHEDULE.SECOND_ASSISTANT, WIS_OPER_SCHEDULE.THIRD_ASSISTANT,  WIS_OPER_SCHEDULE.FOURTH_ASSISTANT, WIS_OPER_SCHEDULE.ANES_METHOD,  WIS_OPER_SCHEDULE.ANES_DOCTOR, WIS_OPER_SCHEDULE.ANES_ASSISTANT, "
                     + " WIS_OPER_SCHEDULE.BLOOD_TRAN_DOCTOR, WIS_OPER_SCHEDULE.SECOND_OPER_NURSE,  WIS_OPER_SCHEDULE.FIRST_SUPPLY_NURSE, WIS_OPER_SCHEDULE.FIRST_OPER_NURSE,  WIS_OPER_SCHEDULE.SECOND_SUPPLY_NURSE, WIS_OPER_SCHEDULE.NOTES_ON_OPER, "
                     + " WIS_OPER_SCHEDULE.ENTERED_BY, WIS_OPER_SCHEDULE.REQ_DATE_TIME,  WIS_OPER_SCHEDULE.THIRD_SUPPLY_NURSE, WIS_OPER_SCHEDULE.ACK_INDICATOR,   WIS_OPER_SCHEDULE.EMERGENCY_INDICATOR, WIS_OPER_SCHEDULE.OPER_ID, "
                     + " WIS_OPER_SCHEDULE.THIRD_ANES_ASSISTANT, WIS_OPER_SCHEDULE.SECOND_ANES_ASSISTANT,  WIS_OPER_SCHEDULE.RECK_GROUP, WIS_OPER_SCHEDULE.FOURTH_ANES_ASSISTANT,  WIS_OPER_SCHEDULE.SECOND_ANES_DOCTOR, WIS_OPER_SCHEDULE.THIRD_ANES_DOCTOR, "
                     + "  WIS_OPER_SCHEDULE.OPER_POSITION, WIS_OPER_SCHEDULE.SPECIAL_EQUIPMENT,  WIS_OPER_SCHEDULE.SPECIAL_INFECT, WIS_OPER_SCHEDULE.HEPATITIS_INDICATOR,   WIS_OPER_SCHEDULE.OPERATION_ID FROM   WIS_OPER_SCHEDULE,WIS_DICT_DEPT,WIS_PAT_MASTER_INDEX  "
                     + " WHERE WIS_OPER_SCHEDULE.dept_stayed = WIS_DICT_DEPT.dept_code(+) AND WIS_OPER_SCHEDULE.PAT_ID = WIS_PAT_MASTER_INDEX.PAT_ID order by WIS_OPER_SCHEDULE.scheduled_date_time desc ";
            }
        }
        public string PatientBaseInformations_GetPatOperationByPatient
        {
            get
            {
                return
                    "SELECT     WIS_OPER_SCHEDULE.PAT_ID, WIS_OPER_SCHEDULE.VISIT_ID, WIS_PAT_MASTER_INDEX.SEX,  WIS_PAT_MASTER_INDEX.NAME, WIS_PAT_MASTER_INDEX.PAT_ID AS Expr1, WIS_PAT_MASTER_INDEX.DATE_OF_BIRTH,  WIS_OPER_SCHEDULE.SCHEDULE_ID, WIS_OPER_SCHEDULE.BED_NO, WIS_OPER_SCHEDULE.DEPT_STAYED, "
                   + "  WIS_OPER_SCHEDULE.SCHEDULED_DATE_TIME, WIS_OPER_SCHEDULE.OPERATING_ROOM,  WIS_OPER_SCHEDULE.OPERATING_ROOM_NO, WIS_OPER_SCHEDULE.SEQUENCE,   WIS_OPER_SCHEDULE.DIAG_BEFORE_OPER, WIS_OPER_SCHEDULE.PAT_CONDITION,  WIS_OPER_SCHEDULE.OPER_SCALE, WIS_OPER_SCHEDULE.ISOLATION_INDICATOR, WIS_OPER_SCHEDULE.SURGEON, "
                   + "  WIS_OPER_SCHEDULE.OPERATING_DEPT, WIS_OPER_SCHEDULE.FIRST_ASSISTANT,  WIS_OPER_SCHEDULE.SECOND_ASSISTANT, WIS_OPER_SCHEDULE.THIRD_ASSISTANT,   WIS_OPER_SCHEDULE.FOURTH_ASSISTANT, WIS_OPER_SCHEDULE.ANES_METHOD,    WIS_OPER_SCHEDULE.ANES_DOCTOR, WIS_OPER_SCHEDULE.ANES_ASSISTANT, "
                   + "  WIS_OPER_SCHEDULE.BLOOD_TRAN_DOCTOR, WIS_OPER_SCHEDULE.SECOND_OPER_NURSE,   WIS_OPER_SCHEDULE.FIRST_SUPPLY_NURSE, WIS_OPER_SCHEDULE.FIRST_OPER_NURSE,   WIS_OPER_SCHEDULE.SECOND_SUPPLY_NURSE, WIS_OPER_SCHEDULE.NOTES_ON_OPER,   WIS_OPER_SCHEDULE.ENTERED_BY, WIS_OPER_SCHEDULE.REQ_DATE_TIME, "
                   + "  WIS_OPER_SCHEDULE.THIRD_SUPPLY_NURSE, WIS_OPER_SCHEDULE.ACK_INDICATOR,  WIS_OPER_SCHEDULE.EMERGENCY_INDICATOR, WIS_OPER_SCHEDULE.OPER_ID,   WIS_OPER_SCHEDULE.THIRD_ANES_ASSISTANT, WIS_OPER_SCHEDULE.SECOND_ANES_ASSISTANT,   WIS_OPER_SCHEDULE.RECK_GROUP, WIS_OPER_SCHEDULE.FOURTH_ANES_ASSISTANT, "
                   + "  WIS_OPER_SCHEDULE.SECOND_ANES_DOCTOR, WIS_OPER_SCHEDULE.THIRD_ANES_DOCTOR,    WIS_OPER_SCHEDULE.OPER_POSITION, WIS_OPER_SCHEDULE.SPECIAL_EQUIPMENT,    WIS_OPER_SCHEDULE.SPECIAL_INFECT, WIS_OPER_SCHEDULE.HEPATITIS_INDICATOR,   WIS_OPER_SCHEDULE.OPERATION_ID "
                   + " FROM WIS_OPER_SCHEDULE,  WIS_PAT_MASTER_INDEX where WIS_OPER_SCHEDULE.PAT_ID = WIS_PAT_MASTER_INDEX.PAT_ID AND WIS_OPER_SCHEDULE.pat_id=:patient_id and WIS_OPER_SCHEDULE.visit_id=:visit_id and WIS_OPER_SCHEDULE.SCHEDULE_ID=:SCHEDULE_ID";
            }
        }

        public string PatientBaseInformations_GetMaxValueOperID
        {
            get
            {

                return
                    "SELECT  MAX(OPER_ID) AS MaxValue FROM  WIS_OPER_MASTER WHERE (PAT_ID = :patient_id) AND (VISIT_ID = :visit_id)";
            }
        }
        public string PatientBaseInformations_GetMaxEventItemNo
        {
            get
            {
                return
                    "SELECT MAX(ITEM_NO) AS MaxValue FROM WIS_ANES_EVENT WHERE (PAT_ID = :PatientID) AND (VISIT_ID = :VisitID) AND (OPER_ID = :OperID)";
            }
        }
        public string PatientBaseInformations_GetMaxValueVisitID
        {
            get
            {
                return
                    "SELECT  MAX(VISIT_ID) AS MaxValue FROM  WIS_PAT_VISIT WHERE (PAT_ID = :PATIENT_ID)";
            }
        }
        public string PatientBaseInformations_GetBloodGasMasterTable
        {
            get
            {
                return
                    "SELECT * FROM WIS_BLOOD_GAS_MASTER WHERE PAT_ID=:patientID AND VISIT_ID=:visitID AND OPER_ID=:operID ";
            }
        }
        public string PatientBaseInformations_GetBloodGasMasterTableByDetailId
        {
            get
            {
                return
                    "SELECT * FROM WIS_BLOOD_GAS_MASTER WHERE DETAIL_ID=:detailId ";
            }
        }
        public string PatientBaseInformations_GetBloodGasMasterTableByDateTime
        {
            get
            {
                return
                    "SELECT * FROM WIS_BLOOD_GAS_MASTER WHERE RECORD_DATE_TIME>=:startTime AND RECORD_DATE_TIME<:endTime ";
            }
        }
        public string PatientBaseInformations_GetBloodGasDetailTable
        {
            get
            {
                return
                    "SELECT * FROM WIS_BLOOD_GAS_DETAIL WHERE DETAIL_ID=:detailId";
            }
        }
        public string PatientBaseInformations_PatientIdIsExist
        {
            get
            {
                return
                    "select * from WIS_PAT_MASTER_INDEX where pat_id=:patientId";
            }
        }
        #endregion

        #region CPB
        public string CPB_GetCPBBlgRecordTableByPatient
        {
            get
            {
                return
                    "SELECT * FROM WIS_CPB_BLG_RECORD WHERE  PAT_ID=:patientID AND VISIT_ID=:visitID AND OPER_ID=:operID";
            }
        }
        public string CPB_GetCPBPreCheckRecordByPatient
        {
            get
            {
                return
                    "SELECT * FROM WIS_CPB_PRE_CHECK_RECORD WHERE PAT_ID=:patientID AND VISIT_ID=:visitID AND OPER_ID=:operID";
            }
        }
        public string CPB_GetCPBPrimingDataByPatient
        {
            get
            {
                return
                    "SELECT * FROM WIS_CPB_PRIMING_DATA WHERE PAT_ID=:patientID AND VISIT_ID=:visitID AND OPER_ID=:operID";
            }
        }
        public string CPB_GetCPBInputDict
        {
            get
            {
                return
                    "SELECT * FROM WIS_DICT_CPB_INPUT WHERE ITEM_CLASS = :ITEM_CLASS";
            }
        }
        public string CPB_GetCPBEventOpen
        {
            get
            {
                return
                    "SELECT * FROM WIS_DICT_CPB_EVENT WHERE ITEM_CLASS= :ITEM_CLASS";
            }
        }
        public string CPB_GetCPBMasterTableByPatient
        {
            get
            {
                return "SELECT * FROM WIS_CPB_MASTER WHERE PAT_ID=:patientID AND VISIT_ID=:visitID AND OPER_ID=:operID";
            }
        }
        public string CPB_GetCPBExamInfoByPatient
        {
            get
            {
                return "SELECT * FROM WIS_CPB_EXAM_INFO WHERE PAT_ID=:patientID AND VISIT_ID=:visitID AND OPER_ID=:operID";
            }
        }
        public string CPB_GetCPBSummaryByPatient
        {
            get
            {
                return "SELECT * FROM WIS_CPB_SUMMARY WHERE PAT_ID=:patientID AND VISIT_ID=:visitID AND OPER_ID=:operID";
            }
        }
        #endregion

        #region Stat
        public string Stat_DeptStatByTime
        {
            get
            {
                return "SELECT OPERATING_DEPT, EMERGENCY_INDICATOR, decode(EMERGENCY_INDICATOR,0,'择期',1,'急诊','') EMERGENCY_INDICATOR_Name,   DEPT_NAME,  sum(decode(OPER_SCALE,'特',1,0)) spe_sum,"
                 + " sum(decode(OPER_SCALE,'大',1,0)) lar_sum, sum(decode(OPER_SCALE,'中',1,0)) mid_sum,  sum(decode(OPER_SCALE,'特',0,'大',0,'中',0,1)) lit_sum,  ( sum(decode(OPER_SCALE,'特',1,0))+ "
                 + " sum(decode(OPER_SCALE,'大',1,0)) + sum(decode(OPER_SCALE,'中',1,0)) + sum(decode(OPER_SCALE,'特',0,'大',0,'中',0,1))) total FROM WIS_OPER_MASTER ,WIS_DICT_DEPT WHERE OPERATING_DEPT=DEPT_CODE(+) and "
                 + " (START_DATE_TIME >=  :startTime) AND (START_DATE_TIME <= :endTime) GROUP BY OPERATING_DEPT,DEPT_NAME, EMERGENCY_INDICATOR ";
            }
        }
        public string Stat_GetAnesQuery
        {
            get
            {
                return
                    " SELECT WIS_PAT_MASTER_INDEX.NAME, WIS_PAT_MASTER_INDEX.SEX,  WIS_PAT_MASTER_INDEX.DATE_OF_BIRTH, WIS_PAT_MASTER_INDEX.CHARGE_TYPE,  WIS_DICT_DEPT_1.DEPT_NAME AS DEPT_NAME_1, WIS_OPER_MASTER.DIAG_BEFORE_OPER,   "
                  + "  WIS_OPER_MASTER.OPER_SCALE, WIS_OPER_MASTER.DIAG_AFTER_OPER,decode(WIS_OPER_MASTER.EMERGENCY_INDICATOR,1,'急诊',0,'择期','') EMERGENCY_INDICATOR, WIS_DICT_DEPT_2.DEPT_NAME AS DEPT_NAME_2,"
                  + "  nvl(USERS_SURGEON.USER_NAME,WIS_OPER_MASTER.SURGEON)  SURGEON, WIS_OPER_MASTER.FIRST_ASSISTANT,    WIS_OPER_MASTER.ANES_METHOD,  nvl(USRS_ANES_DOCTOR.USER_NAME,WIS_OPER_MASTER.ANES_DOCTOR) ANES_DOCTOR,"
                  + "  nvl(USERS_ASSISTANT.USER_NAME,WIS_OPER_MASTER.ANES_ASSISTANT) ANES_ASSISTANT,    WIS_OPER_MASTER.START_DATE_TIME,    WIS_PAT_MASTER_INDEX.IDENTITY,     WIS_OPER_MASTER.PAT_ID,     WIS_OPER_MASTER.VISIT_ID,   "
                  + "   WIS_OPER_MASTER.OPER_ID,     '' OPERATION, nvl(USERS_FIRST_O.USER_NAME,FIRST_OPER_NURSE) FIRST_OPER_NURSE,  nvl(USERS_SECOND_O.USER_NAME,SECOND_OPER_NURSE) SECOND_OPER_NURSE, nvl(USERS_FIRST_S.USER_NAME,FIRST_SUPPLY_NURSE) FIRST_SUPPLY_NURSE,"
                  + " nvl(USERS_SECOND_S.USER_NAME,SECOND_SUPPLY_NURSE) SECOND_SUPPLY_NURSE, nvl(USERS_THIRD_S.USER_NAME,THIRD_SUPPLY_NURSE) THIRD_SUPPLY_NURSE,OPERATING_ROOM_NO,      WIS_OPER_MASTER.OPER_NAME       FROM WIS_PAT_MASTER_INDEX,WIS_OPER_MASTER, "
                  + " WIS_DICT_DEPT WIS_DICT_DEPT_1, WIS_DICT_DEPT WIS_DICT_DEPT_2,   WIS_PERM_HIS_USER USRS_ANES_DOCTOR,   WIS_PERM_HIS_USER USERS_ASSISTANT,  WIS_PERM_HIS_USER USERS_SURGEON, WIS_PERM_HIS_USER USERS_FIRST_S,  WIS_PERM_HIS_USER USERS_SECOND_S,  WIS_PERM_HIS_USER USERS_THIRD_S,  WIS_PERM_HIS_USER USERS_FIRST_O, WIS_PERM_HIS_USER USERS_SECOND_O "

                  + " WHERE WIS_OPER_MASTER.PAT_ID = WIS_PAT_MASTER_INDEX.PAT_ID and WIS_OPER_MASTER.DEPT_STAYED = WIS_DICT_DEPT_1.DEPT_CODE(+) and WIS_OPER_MASTER.OPERATING_DEPT =  WIS_DICT_DEPT_2.DEPT_CODE and WIS_OPER_MASTER.ANES_DOCTOR = USRS_ANES_DOCTOR.USER_ID and "
                  + " WIS_OPER_MASTER.ANES_ASSISTANT = USERS_ASSISTANT.USER_ID and WIS_OPER_MASTER.SURGEON = USERS_SURGEON.USER_ID and WIS_OPER_MASTER.FIRST_SUPPLY_NURSE = USERS_FIRST_S.USER_ID and WIS_OPER_MASTER.SECOND_SUPPLY_NURSE =  USERS_SECOND_S.USER_ID and "
                  + " WIS_OPER_MASTER.THIRD_SUPPLY_NURSE = USERS_THIRD_S.USER_ID and WIS_OPER_MASTER.FIRST_OPER_NURSE = USERS_FIRST_O.USER_ID and WIS_OPER_MASTER.SECOND_OPER_NURSE = USERS_SECOND_O.USER_ID and WIS_OPER_MASTER.OPER_STATUS <> 0 "
                  + " AND (nvl(USRS_ANES_DOCTOR.USER_NAME,WIS_OPER_MASTER.ANES_DOCTOR) LIKE '%' + :ANES_DOCTOR + '%'  OR :ANES_DOCTOR = '')  AND (nvl(USERS_SURGEON.USER_NAME,WIS_OPER_MASTER.SURGEON) LIKE '%' + :SURGEON + '%' OR :SURGEON = '') "
                  + " AND (nvl(USERS_FIRST_S.USER_NAME,FIRST_SUPPLY_NURSE) LIKE '%' + :NURSE + '%' OR nvl(USERS_SECOND_S.USER_NAME,SECOND_SUPPLY_NURSE) LIKE '%' + :NURSE + '%' OR nvl(USERS_THIRD_S.USER_NAME,THIRD_SUPPLY_NURSE) LIKE '%' + :NURSE + '%'  OR nvl(USERS_FIRST_O.USER_NAME,FIRST_OPER_NURSE) LIKE '%' + :NURSE + '%'  OR  "
                  + " nvl(USERS_SECOND_O.USER_NAME,SECOND_OPER_NURSE) LIKE '%' + :NURSE + '%' or :NURSE = '') AND (WIS_DICT_DEPT_2.DEPT_NAME LIKE '%'+ :DEPT + '%' OR :DEPT = '') AND (WIS_OPER_MASTER.ANES_METHOD  LIKE '%' + :ANES_METHOD + '%' OR :ANES_METHOD = '')"
                  + " AND  (WIS_PAT_MASTER_INDEX.SEX LIKE '%' + :SEX + '%' OR :SEX  = '') and (to_number(to_char(WIS_OPER_MASTER.START_DATE_TIME,'yyyy'))-to_number(to_char(WIS_PAT_MASTER_INDEX.DATE_OF_BIRTH,'yyyy')))>= :AGESTART and (to_number(to_char(WIS_OPER_MASTER.START_DATE_TIME,'yyyy'))-to_number(to_char(WIS_PAT_MASTER_INDEX.DATE_OF_BIRTH,'yyyy'))) <= :AGEEND "

                  + " AND (WIS_OPER_MASTER.OPER_NAME LIKE '%' + :OPERNAME + '%' OR :OPERNAME = '') AND (WIS_OPER_MASTER.OPER_SCALE LIKE '%' + :OPERSCALE + '%' OR :OPERSCALE = '') AND WIS_OPER_MASTER.START_DATE_TIME >= :STARTDATE AND WIS_OPER_MASTER.START_DATE_TIME <= :ENDDATE "
                  + " AND (WIS_OPER_MASTER.EMERGENCY_INDICATOR = :INDICATOR OR :INDICATOR = -1) ORDER BY  WIS_OPER_MASTER.START_DATE_TIME ";

            }
        }
        public string Stat_GetCancelAnesQuery
        {
            get
            {
                return
                    "SELECT  WIS_OPER_CANCELED.SCHEDULED_DATE_TIME, WIS_PAT_MASTER_INDEX.NAME, WIS_OPER_NAME_CANCELED.OPER_NAME,WIS_OPER_CANCELED.SURGEON, ANES_DOCTOR, WIS_DICT_DEPT.DEPT_NAME, WIS_OPER_CANCELED.CANCEL_REASON "
                    + " FROM WIS_OPER_CANCELED ,WIS_PAT_MASTER_INDEX ,WIS_OPER_NAME_CANCELED,WIS_DICT_DEPT WHERE WIS_OPER_CANCELED.pat_id = WIS_PAT_MASTER_INDEX.pat_id(+) and WIS_OPER_CANCELED.PAT_ID = WIS_OPER_NAME_CANCELED.PAT_ID and"
                    + " WIS_OPER_CANCELED.VISIT_ID = WIS_OPER_NAME_CANCELED.VISIT_ID(+) and  WIS_OPER_CANCELED.CANCEL_ID = WIS_OPER_NAME_CANCELED.CANCEL_ID(+) and WIS_OPER_CANCELED.OPERATING_DEPT = WIS_DICT_DEPT.DEPT_CODE(+) and "

                    + " SCHEDULED_DATE_TIME >= :STATEDATE AND SCHEDULED_DATE_TIME <= :ENDDATE ";

            }
        }
        public string Stat_GetWorkloadTimeQuery
        {
            get
            {
                return
                    "SELECT WIS_OPER_MASTER.SCHEDULED_DATE_TIME, WIS_DICT_DEPT.DEPT_NAME AS OPERATING_DEPT, nvl(USERS_SURGEON.USER_NAME,WIS_OPER_MASTER.SURGEON) SURGEON,   nvl(USRS_ANES_DOCTOR.USER_NAME,WIS_OPER_MASTER.ANES_DOCTOR) ANES_DOCTOR , "
                     + " WIS_OPER_MASTER.OPER_NAME,  WIS_ANES_PLAN.ANES_END_TIME,  WIS_ANES_PLAN.ANES_START_TIME,  WIS_OPER_MASTER.END_DATE_TIME,  WIS_OPER_MASTER.START_DATE_TIME, ROUND((WIS_ANES_PLAN.ANES_END_TIME-WIS_ANES_PLAN.ANES_START_TIME)*24,1) anes_time,"
                     + " ROUND((WIS_OPER_MASTER.END_DATE_TIME-WIS_OPER_MASTER.START_DATE_TIME)*24,1) oper_time,ROUND(((WIS_ANES_PLAN.ANES_END_TIME - WIS_ANES_PLAN.ANES_START_TIME) - (WIS_OPER_MASTER.END_DATE_TIME- WIS_OPER_MASTER.START_DATE_TIME))*24,1) AS wait_time, "
                     + "  WIS_OPER_MASTER.PAT_ID, WIS_OPER_MASTER.VISIT_ID,   WIS_OPER_MASTER.OPER_ID, WIS_PAT_MASTER_INDEX.NAME,  WIS_ANES_PLAN.ASA_GRADE,  WIS_OPER_MASTER.ANES_METHOD FROM WIS_OPER_MASTER , WIS_PAT_MASTER_INDEX ,       WIS_ANES_PLAN,"
                     + "  WIS_DICT_DEPT, WIS_PERM_HIS_USER USRS_ANES_DOCTOR,WIS_PERM_HIS_USER USERS_SURGEON  WHERE WIS_OPER_MASTER.PAT_ID = WIS_PAT_MASTER_INDEX.PAT_ID and WIS_OPER_MASTER.OPER_ID = WIS_ANES_PLAN.OPER_ID(+) and WIS_OPER_MASTER.PAT_ID = WIS_ANES_PLAN.PAT_ID and"
                     + " WIS_OPER_MASTER.VISIT_ID = WIS_ANES_PLAN.VISIT_ID(+) and WIS_OPER_MASTER.OPERATING_DEPT = WIS_DICT_DEPT.DEPT_CODE(+) and WIS_OPER_MASTER.ANES_DOCTOR = USRS_ANES_DOCTOR.USER_ID(+) and WIS_OPER_MASTER.SURGEON = USERS_SURGEON.USER_ID(+)"

                     + " and (WIS_OPER_MASTER.SCHEDULED_DATE_TIME >= :STARTDATE) AND (WIS_OPER_MASTER.SCHEDULED_DATE_TIME <= :ENDDATE) AND (WIS_OPER_MASTER.OPERATING_ROOM LIKE '%' + :OPRROOM + '%' OR :OPRROOM = '') AND (WIS_DICT_DEPT.DEPT_NAME LIKE '%' + :DEPTNAME + '%' OR :DEPTNAME = '') AND   "
                     + " (nvl(USRS_ANES_DOCTOR.USER_NAME,WIS_OPER_MASTER.ANES_DOCTOR) LIKE '%' + :DOCTOR + '%' OR :DOCTOR = '') order by WIS_OPER_MASTER.START_DATE_TIME";
            }
        }
        public string Stat_GetWorkloadTimeQueryBy
        {
            get
            {
                return
                    "SELECT WIS_OPER_MASTER.START_DATE_TIME,  WIS_DICT_DEPT.DEPT_NAME AS OPERATING_DEPT,  nvl(USERS_SURGEON.USER_NAME,WIS_OPER_MASTER.SURGEON) SURGEON,  nvl(USRS_ANES_DOCTOR.USER_NAME,WIS_OPER_MASTER.ANES_DOCTOR) ANES_DOCTOR, "
                     + " WIS_OPER_MASTER.OPER_NAME,  WIS_ANES_PLAN.ANES_END_TIME,   WIS_ANES_PLAN.ANES_START_TIME,   WIS_OPER_MASTER.END_DATE_TIME,  ROUND((WIS_ANES_PLAN.ANES_END_TIME-WIS_ANES_PLAN.ANES_START_TIME)*24,1) anes_time,"
                     + " ROUND((WIS_OPER_MASTER.END_DATE_TIME-WIS_OPER_MASTER.START_DATE_TIME)*24,1) oper_time, ROUND(((WIS_ANES_PLAN.ANES_END_TIME - WIS_ANES_PLAN.ANES_START_TIME) - (WIS_OPER_MASTER.END_DATE_TIME- WIS_OPER_MASTER.START_DATE_TIME))*24,1) AS wait_time, "
                     + "  WIS_OPER_MASTER.PAT_ID, WIS_OPER_MASTER.VISIT_ID,   WIS_OPER_MASTER.OPER_ID, WIS_PAT_MASTER_INDEX.NAME FROM WIS_OPER_MASTER,  WIS_PAT_MASTER_INDEX, WIS_ANES_PLAN ,   WIS_DICT_DEPT,      WIS_PERM_HIS_USER USRS_ANES_DOCTOR ,"
                     + "  WIS_PERM_HIS_USER USERS_SURGEON WHERE  WIS_PAT_MASTER_INDEX.PAT_ID = WIS_OPER_MASTER.PAT_ID and  WIS_OPER_MASTER.OPER_ID = WIS_ANES_PLAN.OPER_ID(+) and WIS_OPER_MASTER.PAT_ID = WIS_ANES_PLAN.PAT_ID(+) and "
                     + "  WIS_OPER_MASTER.VISIT_ID = WIS_ANES_PLAN.VISIT_ID(+) and WIS_OPER_MASTER.OPERATING_DEPT = WIS_DICT_DEPT.DEPT_CODE(+) and  WIS_OPER_MASTER.ANES_DOCTOR = USRS_ANES_DOCTOR.USER_ID(+) and "
                     + "  WIS_OPER_MASTER.SURGEON = USERS_SURGEON.USER_ID(+)  and  (WIS_OPER_MASTER.IN_DATE_TIME >= :STARTDATE) AND  (WIS_OPER_MASTER.OUT_DATE_TIME <= :ENDDATE) AND (WIS_OPER_MASTER.OPERATING_ROOM LIKE '%' + :OPRROOM + '%' OR :OPRROOM = '') AND "
                     + " (WIS_DICT_DEPT.DEPT_NAME LIKE '%' + :DEPTNAME + '%' OR :DEPTNAME = '') AND    (nvl(USRS_ANES_DOCTOR.USER_NAME,WIS_OPER_MASTER.ANES_DOCTOR) LIKE '%' + :DOCTOR + '%' OR :DOCTOR = '') order by WIS_OPER_MASTER.START_DATE_TIME ";
            }
        }
        public string Stat_IdentityQuery
        {
            get
            {
                return
                    "SELECT WIS_DICT_DEPT.DEPT_NAME,WIS_PAT_MASTER_INDEX.IDENTITY, sum(decode(WIS_OPER_MASTER.OPER_SCALE,'特',1,0)) SPE_SUM, sum(decode(WIS_OPER_MASTER.OPER_SCALE,'大',1,0)) LAR_SUM,sum(decode(WIS_OPER_MASTER.OPER_SCALE,'中',1,0)) MID_SUM,"
                    + " sum(decode(WIS_OPER_MASTER.OPER_SCALE,'小',1,0)) LIT_SUM,( sum(decode(WIS_OPER_MASTER.OPER_SCALE,'特',1,0))+ sum(decode(WIS_OPER_MASTER.OPER_SCALE,'大',1,0))+ sum(decode(WIS_OPER_MASTER.OPER_SCALE,'中',1,0))+ sum(decode(WIS_OPER_MASTER.OPER_SCALE,'小',1,0))"
                    + " ) SUMVALUE FROM WIS_OPER_MASTER ,WIS_PAT_MASTER_INDEX ,WIS_DICT_DEPT  WHERE WIS_OPER_MASTER.PAT_ID = WIS_PAT_MASTER_INDEX.PAT_ID and WIS_OPER_MASTER.OPERATING_DEPT= WIS_DICT_DEPT.DEPT_CODE(+) and (WIS_OPER_MASTER.START_DATE_TIME >= :STARTDATE) AND "
                    + " (WIS_OPER_MASTER.START_DATE_TIME <= :ENDDATE) AND (WIS_DICT_DEPT.DEPT_NAME LIKE '%' + :DEPTNAME + '%' OR :DEPTNAME = '') AND (WIS_PAT_MASTER_INDEX.[IDENTITY] LIKE '%' + :IDENTITY + '%' OR :IDENTITY = '') GROUP BY  WIS_DICT_DEPT.DEPT_NAME, WIS_PAT_MASTER_INDEX.IDENTITY";
            }
        }
        public string Stat_GetDeptAnesCountQuery
        {
            get
            {
                return
                    "SELECT WIS_DICT_DEPT.DEPT_NAME,WIS_OPER_MASTER.OPER_Name,COUNT(*) AS OPER_COUNT,round(sum(ROUND((WIS_OPER_MASTER.END_DATE_TIME-WIS_OPER_MASTER.START_DATE_TIME)*24,1)),1) OPER_SUM_TIME,"
                    + " round(sum(ROUND((WIS_OPER_MASTER.END_DATE_TIME-WIS_OPER_MASTER.START_DATE_TIME)*24,1))/count(*),1) AVG_OPER_TIME FROM WIS_OPER_MASTER, WIS_DICT_DEPT  WHERE WIS_OPER_MASTER.OPERATING_DEPT = WIS_DICT_DEPT.DEPT_CODE(+) "
                    + " and WIS_OPER_MASTER.START_DATE_TIME >= :STARTDATE AND WIS_OPER_MASTER.START_DATE_TIME <=:ENDDATE AND (WIS_DICT_DEPT.DEPT_NAME LIKE '%' + :DEPTNAME + '%' OR :DEPTNAME = '') GROUP BY WIS_DICT_DEPT.DEPT_NAME,WIS_OPER_MASTER.OPER_Name"
                    + " order by WIS_DICT_DEPT.DEPT_NAME ";
            }
        }
        public string Stat_GetHospitalQuery
        {
            get
            {
                return
                    "SELECT ANES_METHOD ANES_METHOD,COUNT(*) AS ANESCOUNT FROM WIS_OPER_MASTER , WIS_DICT_DEPT WHERE WIS_OPER_MASTER.DEPT_STAYED=WIS_DICT_DEPT.DEPT_CODE(+) and START_DATE_TIME >= :STARTDATE "
              + " AND START_DATE_TIME <= :ENDDATE AND (OPERATING_ROOM LIKE '%' + :OPERATROOM + '%' OR :OPERATROOM = '') AND ((WIS_DICT_DEPT.DEPT_NAME LIKE '%' + :DEPTNAME + '%') OR (DEPT_STAYED = :DEPTNAME) OR (:DEPTNAME = '')) GROUP BY ANES_METHOD ";


            }
        }
        public string Stat_DeptAnesWorkByMonth
        {
            get
            {
                return
                    "SELECT DEPT_NAME,SPE_SUM_LAST,SPE_SUM,(SPE_SUM - SPE_SUM_LAST) AS SPE_CON,LAR_SUM_LAST,LAR_SUM,(LAR_SUM - LAR_SUM_LAST) AS LAR_CON,MID_SUM_LAST,MID_SUM,(MID_SUM - MID_SUM_LAST) AS MID_CON,"
                    + " LIT_SUM_LAST,LIT_SUM,(LIT_SUM - LIT_SUM_LAST) AS LIT_CON,(SPE_SUM_LAST + LAR_SUM_LAST + MID_SUM_LAST + LIT_SUM_LAST) AS SUM1,(SPE_SUM + LAR_SUM + MID_SUM + LIT_SUM) AS SUM2,((SPE_SUM + LAR_SUM + MID_SUM + LIT_SUM) - (SPE_SUM_LAST + LAR_SUM_LAST + MID_SUM_LAST + LIT_SUM_LAST)) AS SUM3"
                    + " FROM (SELECT nvl(B.DEPT_NAME,A.OPERATING_DEPT) AS DEPT_NAME,sum(decode(A.OPER_SCALE,'特',decode(to_number(to_char(A.START_DATE_TIME,'yyyy')),:PREVIOUSYEAR,1,0),0)) SPE_SUM_LAST,sum(decode(A.OPER_SCALE,'大',decode(to_number(to_char(A.START_DATE_TIME,'yyyy')),:PREVIOUSYEAR,1,0),0)) LAR_SUM_LAST,"
                    + " sum(decode(A.OPER_SCALE,'中',decode(to_number(to_char(A.START_DATE_TIME,'yyyy')),:PREVIOUSYEAR,1,0),0)) MID_SUM_LAST,sum(decode(A.OPER_SCALE,'小',decode(to_number(to_char(A.START_DATE_TIME,'yyyy')),:PREVIOUSYEAR,1,0),0)) LIT_SUM_LAST,"

                    + " sum(decode(A.OPER_SCALE,'特',decode(to_number(to_char(A.START_DATE_TIME,'yyyy')),:YEAR,1,0),0)) SPE_SUM,sum(decode(A.OPER_SCALE,'大',decode(to_number(to_char(A.START_DATE_TIME,'yyyy')),:YEAR,1,0),0)) LAR_SUM,"
                    + " sum(decode(A.OPER_SCALE,'中',decode(to_number(to_char(A.START_DATE_TIME,'yyyy')),:YEAR,1,0),0)) MID_SUM,sum(decode(A.OPER_SCALE,'小',decode(to_number(to_char(A.START_DATE_TIME,'yyyy')),:YEAR,1,0),0)) LIT_SUM FROM WIS_OPER_MASTER A, WIS_DICT_DEPT B "
                    + " WHERE A.OPERATING_DEPT = B.DEPT_CODE and A.OPERATING_DEPT IS NOT NULL AND to_number(to_char(A.START_DATE_TIME,'mm')) = :MONTH AND (to_number(to_char(A.START_DATE_TIME,'yyyy')) = :PREVIOUSYEAR  OR to_number(to_char(A.START_DATE_TIME,'yyyy')) = :YEAR) "
                    + " GROUP BY B.DEPT_NAME,A.OPERATING_DEPT ) C WHERE (C.SPE_SUM_LAST > 0 OR C.LAR_SUM_LAST > 0 OR C.MID_SUM_LAST > 0 OR C.LIT_SUM_LAST > 0 OR C.SPE_SUM > 0 OR C.LAR_SUM > 0 OR C.MID_SUM > 0 OR C.LIT_SUM > 0)";
            }
        }
        public string Stat_DeptAnesWorkByQuarter
        {
            get
            {
                return
                    "SELECT DEPT_NAME,SPE_SUM_LAST,SPE_SUM,(SPE_SUM - SPE_SUM_LAST) AS SPE_CON,LAR_SUM_LAST,LAR_SUM,(LAR_SUM - LAR_SUM_LAST) AS LAR_CON,MID_SUM_LAST,MID_SUM,(MID_SUM - MID_SUM_LAST) AS MID_CON,"
                    + " LIT_SUM_LAST,LIT_SUM,(LIT_SUM - LIT_SUM_LAST) AS LIT_CON,(SPE_SUM_LAST + LAR_SUM_LAST + MID_SUM_LAST + LIT_SUM_LAST) AS SUM1,(SPE_SUM + LAR_SUM + MID_SUM + LIT_SUM) AS SUM2,((SPE_SUM + LAR_SUM + MID_SUM + LIT_SUM) - (SPE_SUM_LAST + LAR_SUM_LAST + MID_SUM_LAST + LIT_SUM_LAST)) AS SUM3"
                    + " FROM (SELECT nvl(B.DEPT_NAME,A.OPERATING_DEPT) AS DEPT_NAME,sum(decode(A.OPER_SCALE,'特',decode(to_number(to_char(A.START_DATE_TIME,'yyyy')),:PREVIOUSYEAR,1,0),0)) SPE_SUM_LAST,sum(decode(A.OPER_SCALE,'大',decode(to_number(to_char(A.START_DATE_TIME,'yyyy')),:PREVIOUSYEAR,1,0),0)) LAR_SUM_LAST,"
                    + " sum(decode(A.OPER_SCALE,'中',decode(to_number(to_char(A.START_DATE_TIME,'yyyy')),:PREVIOUSYEAR,1,0),0)) MID_SUM_LAST,sum(decode(A.OPER_SCALE,'小',decode(to_number(to_char(A.START_DATE_TIME,'yyyy')),:PREVIOUSYEAR,1,0),0)) LIT_SUM_LAST,"

                    + " sum(decode(A.OPER_SCALE,'特',decode(to_number(to_char(A.START_DATE_TIME,'yyyy')),:YEAR,1,0),0)) SPE_SUM,sum(decode(A.OPER_SCALE,'大',decode(to_number(to_char(A.START_DATE_TIME,'yyyy')),:YEAR,1,0),0)) LAR_SUM,"
                    + " sum(decode(A.OPER_SCALE,'中',decode(to_number(to_char(A.START_DATE_TIME,'yyyy')),:YEAR,1,0),0)) MID_SUM,sum(decode(A.OPER_SCALE,'小',decode(to_number(to_char(A.START_DATE_TIME,'yyyy')),:YEAR,1,0),0)) LIT_SUM FROM WIS_OPER_MASTER A  , WIS_DICT_DEPT B "
                    + " WHERE A.OPERATING_DEPT = B.DEPT_CODE and A.OPERATING_DEPT IS NOT NULL AND (to_number(to_char(A.START_DATE_TIME,'mm')) >= :STARTMONTH OR to_number(to_char(A.START_DATE_TIME,'mm')) <= :ENDMONTH) "
                    + " AND (to_number(to_char(A.START_DATE_TIME,'yyyy')) = :PREVIOUSYEAR  OR to_number(to_char(A.START_DATE_TIME,'yyyy')) = :YEAR) GROUP BY B.DEPT_NAME,A.OPERATING_DEPT ) C "
                    + " WHERE (C.SPE_SUM_LAST > 0 OR C.LAR_SUM_LAST > 0 OR C.MID_SUM_LAST > 0 OR C.LIT_SUM_LAST > 0 OR C.SPE_SUM > 0 OR C.LAR_SUM > 0 OR C.MID_SUM > 0 OR C.LIT_SUM > 0) ";
            }
        }
        public string Stat_GetQueryCondByUser
        {
            get
            {
                return
                    "SELECT DISTINCT COND_TYPE, COND_TITLE, CONDITION, CREATOR_ID, CREATE_DATE_TIME, PERMISSION FROM WIS_QUERY_COND where CREATOR_ID=:CREATOR_ID and COND_TITLE=:COND_TITLE Order by CREATE_DATE_TIME desc";
            }
        }
        public string Stat_GetQueryCondSelection
        {
            get
            {
                return
                    "SELECT DISTINCT USER_NAME, COND_TITLE FROM WIS_QUERY_COND_SELECTION WHERE (USER_NAME= :USER_NAME)";
            }
        }
        public string Stat_GetPunctureQueryTable
        {
            get
            {
                return
                    "SELECT A.*,B.*,C.* FROM WIS_PUNCTURE_RECORD A,WIS_OPER_MASTER B,WIS_PAT_MASTER_INDEX C "
                    + "WHERE A.PAT_ID=B.PAT_ID AND A.PAT_ID=C.PAT_ID AND A.VISIT_ID=B.VISIT_ID AND A.OPER_ID=B.OPER_ID "
                    + "AND A.RECORD_TIME>:STARTTIME AND A.RECORD_TIME<:ENDTIME ORDER BY A.RECORD_TIME";
            }
        }
        #endregion

        #region LocalDataModelProxy

        public string LocalDataModelProxy_GetHospitalQueryDataTable
        {
            get
            {
                return
                    "SELECT {0} ANES_METHOD,COUNT(*) AS ANESCOUNT FROM WIS_OPER_MASTER LEFT OUTER JOIN WIS_DICT_DEPT ON WIS_DICT_DEPT.DEPT_CODE = WIS_OPER_MASTER.DEPT_STAYED LEFT JOIN WIS_ANES_PLAN ON WIS_OPER_MASTER.PAT_ID = WIS_ANES_PLAN.PAT_ID "
                    + "AND WIS_OPER_MASTER.VISIT_ID = WIS_ANES_PLAN.VISIT_ID  AND WIS_OPER_MASTER.OPER_ID = WIS_ANES_PLAN.OPER_ID WHERE SCHEDULED_DATE_TIME >= :STARTDATE  AND SCHEDULED_DATE_TIME <= :ENDDATE AND WIS_OPER_MASTER.OPER_STATUS>3 AND (LEN(:OPERATROOM)=0 OR OPERATING_ROOM LIKE '%' + :OPERATROOM + '%') "
                    + "AND (LEN(:DEPTNAME)=0 OR (WIS_DICT_DEPT.DEPT_NAME LIKE '%' + :DEPTNAME + '%') OR (DEPT_STAYED = :DEPTNAME)) GROUP BY {0}";
            }
        }
        public string LocalDataModelProxy_GetConfigTableDataTable
        {
            get
            {
                return
                    "select * from WIS_CONF_INDEX";
            }

        }
        public string LocalDataModelProxy_GetPatMonitorDataExtDataTable
        {
            get
            {
                return
                    "select * from WIS_PAT_MONITOR_DATA_EXT where pat_id = :pid and visit_id = :vid and oper_id = :oid";
            }
        }
        public string LocalDataModelProxy_GetPatMonitorDataExtDataTableDesc
        {
            get
            {
                return
                    "select * from WIS_PAT_MONITOR_DATA_EXT where pat_id = :pid and visit_id = :vid and oper_id = :oid order by time_point desc";
            }
        }
        public string LocalDataModelProxy_GetWIS_MONITOR_FUNC_CODE
        {
            get
            {
                return
                    "Select * from WIS_MONITOR_FUNC_CODE";
            }
        }
        public string LocalDataModelProxy_GetWIS_PAT_MONITOR_DATA_HISTORY
        {
            get
            {
                return
                    "SELECT MONITOR_VALUE FROM WIS_PAT_MONITOR_DATA_HISTORY where pat_id = :patient_id and visit_id =:visit_id and (ITEM_NO = 0) AND oper_id = :oper_id and data_type = :data_type";
            }

        }
        public string LocalDataModelProxy_WIS_PAT_MONITOR_DATA_HISTORY_MaxValue
        {
            get
            {
                return
                    "select max(monitor_value) monitor_value from WIS_PAT_MONITOR_DATA_HISTORY where pat_id =:patient_id "
                    + " and visit_id = :visit_id  and oper_id = :oper_id and data_type = :data_type";
            }
        }
        public string LocalDataModelProxy_GetPatientMonitorConfigDataTable
        {
            get
            {
                return
                    "select * from WIS_CONF_PAT_MONITOR where pat_id = :patientID and visit_id = :visitID and oper_id = :operID";

            }
        }

        public string LocalDataModelProxy_GetPatientJianCeConfigDataTable
        {
            get
            {
                return
                    "select * from WIS_CONF_ANES_MONITOR where PAT_ID = :patientID and visit_id = :visitID and oper_id = :operID";

            }
        }
        public string LocalDataModelProxy_GetWIS_OPER_NAME
        {
            get
            {
                return
                    "select * from WIS_OPER_NAME order by pat_id,visit_id,oper_id";
            }
        }
        public string LocalDataModelProxy_GetBed_No
        {
            get
            {
                return
                    "Select Bed_No From WIS_ANES_PLAN Where PAT_ID = :pid AND VISIT_ID = :vid AND OPER_ID = :oid";

            }
        }
        public string LocalDataModelProxy_GetOperation
        {
            get
            {
                return
                    "Select oper_name from WIS_OPER_NAME Where PAT_ID = :PID AND VISIT_ID = :VID AND OPER_ID = :OID order by oper_no";
            }
        }
        public string LocalDataModelProxy_GetOperationNameFromMaster
        {
            get
            {
                return
                    "Select oper_name from WIS_OPER_MASTER Where PAT_ID = :PID AND VISIT_ID = :VID AND OPER_ID = :OID";
            }
        }
        public string LocalDataModelProxy_GetOperationNameFromANESTHESIA
        {
            get
            {
                return
                    "Select OPER_NAME from WIS_ANES_PLAN Where PAT_ID = :PID AND VISIT_ID = :VID AND OPER_ID = :OID";
            }
        }
        #endregion

        #region Score

        public string Score_GetAPAInfo
        {
            get
            {
                return @"SELECT PAT_ID, VISIT_ID, SCORING_DATE_TIME, RECTAL_TEMP, MEAN_ARTERIAL_P, 
                            HEART_RATE, RESPIRATORY, OXYGENATION, ARTERIAL_BLOOD, SERUM_SODIUM, 
                            SERUM_POTAS, SERUM_CREATININE, BLOOD_CELLSTH, BLOOD_CELLCO, GLASGOW, 
                            HCO3, AGEFACTOR_SCORE, MEMO, CHRONIC_LIVER, CHRONIC_CARD, CHRONIC_RESP, 
                            CHRONIC_RENAL, CHRONIC_IMMUNE
                            FROM WIS_SCORE_APA_RESULT
                            WHERE (PAT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
                            ( SCORING_DATE_TIME = :dateTime)";
            }
        }

        public string Score_GetPatientScoringResultDt
        {
            get
            {
                return @"SELECT     PAT_ID, VISIT_ID, SCORING_DATE_TIME, SCORING_METHOD, SCORING_VALUE,
                    DEGREE, DEATH_PROBABILITY, PAT_CONDITION, 
                    WARD_CODE, OPERATOR, MEMO, ENTER_DATE_TIME, DEATH_RATE, ISS_SCORE, TRS_SCORE
                    FROM         WIS_PAT_SCORING_RESULT
                    WHERE     (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID) AND (SCORING_METHOD = :method)
                    ORDER BY PATIENT_ID, VISIT_ID, SCORING_METHOD, SCORING_DATE_TIME";
            }
        }

        #endregion Score

        #region CareDocs

        public string CareDocs_GetCustomData
        {
            get
            {
                return
                    "select * from WIS_CUSTOM_DATA";
            }
        }

        public string CareDocs_GetCustomDataByPatient
        {
            get
            {
                return
                    "select * from WIS_CUSTOM_DATA WHERE PAT_ID = :PatientID AND VISIT_ID = :VisitID AND OPER_ID = :OperID";
            }
        }

        public string CareDocs_GetPatMonitorDataHistory
        {
            get
            {
                return
                    "SELECT * FROM WIS_PAT_MONITOR_DATA_HISTORY";
            }

        }

        public string CareDocs_GetPatMonitorDataHistoryByPatient
        {
            get
            {
                return
                    "SELECT * FROM WIS_PAT_MONITOR_DATA_HISTORY WHERE PAT_ID = :PATIENT_ID AND VISIT_ID = :VISIT_ID AND OPER_ID = :OPER_ID";
            }

        }

        public string CareDocs_GetPatMonitorDataHistoryByPatientAndDataTypeAndItemNo
        {
            get
            {
                return
                    "SELECT * FROM WIS_PAT_MONITOR_DATA_HISTORY WHERE PAT_ID = :PATIENT_ID AND VISIT_ID = :VISIT_ID AND OPER_ID = :OPER_ID AND ITEM_NO = :ITEM_NO AND DATA_TYPE = :DATA_TYPE";
            }

        }

        public string CareDocs_GetOperationCanceledByPatient
        {
            get
            {
                return
                    "SELECT * FROM WIS_OPER_CANCELED WHERE PAT_ID = :PATIENT_ID AND VISIT_ID = :VISIT_ID AND CANCEL_ID = :CANCEL_ID";
            }

        }

        public string CareDocs_GetOperationCanceledByPatient1
        {
            get
            {
                return
                    "SELECT * FROM WIS_OPER_CANCELED WHERE PAT_ID = :PATIENT_ID AND VISIT_ID = :VISIT_ID";
            }

        }

        public string CareDocs_GetUserScheduleByScheduleTime
        {
            get
            {
                return
                    "SELECT * FROM MED_USER_SCHEDULE WHERE SCHEDULE_TIME >= :startTime AND SCHEDULE_TIME <= :endTime ORDER BY ORDER_NO,SCHEDULE_TIME";
            }
        }

        public string CareDocs_GetModifyedDataByPatient
        {
            get
            {
                return
                    "Select * from WIS_PATIENT_MONITOR_DATA Where PAT_ID = :PatientID AND VISIT_ID = :VisitID AND OPER_ID = :OperID";
            }
        }
        public string CareDocs_GetOperationNameByPatient
        {
            get
            {
                return
                    " SELECT * FROM WIS_OPER_NAME WHERE PAT_ID = :PatientID AND VISIT_ID = :VisitID AND OPER_ID = :OperID ";
            }

        }
        public string CareDocs_GetModifyedDataByPatientAndEventNo
        {
            get
            {
                return
                    "Select * from WIS_PATIENT_MONITOR_DATA Where PAT_ID = :PatientID AND VISIT_ID = :VisitID AND OPER_ID = :OperID AND (EVENT_NO = :EventNo OR (EVENT_NO IS NULL AND :EventNo = 0))";
            }
        }

        public string CareDocs_GetModifyedDataByPatientAndTimePointAndItemNameAndEventNo
        {
            get
            {
                return
                    "Select * from WIS_PATIENT_MONITOR_DATA Where PAT_ID = :PatientID AND VISIT_ID = :VisitID AND OPER_ID = " +
                        ":OperID AND TIME_POINT = :timepoint AND ITEM_NAME = :itemname AND (EVENT_NO = :eventno OR (EVENT_NO IS NULL AND :eventno = 0))";
            }
        }
        public string CareDocs_DeleteBloodGasMaster
        {
            get
            {
                return
                    "delete from WIS_BLOOD_GAS_MASTER where  detail_id=:detail_id";
            }

        }
        public string CareDocs_DeleteBloodGasDetails
        {
            get
            {
                return
                   "delete from WIS_BLOOD_GAS_DETAIL where  detail_id=:detail_id";
            }
        }

        public string CareDocs_GetModifyHistoryByTableNameAndFieldName
        {
            get
            {
                return
                   "SELECT * FROM WIS_MODIFY_HISTORY WHERE TABLE_NAME=:TableName AND FIELD_NAME=:FieldName";
            }
        }
        public string CareDocs_GetQiXieQingDianByPatientID
        {
            get
            {
                return
                    "Select * from WIS_INSTRUMENT_INVENTORY Where PAT_ID = :PatientID AND VISIT_ID = :VisitID AND OPER_ID = :OperID";
            }
        }
        public string CareDocs_GetGridTempletMasterByTempletGuid
        {
            get
            {
                return
                   "SELECT * FROM WIS_GRID_TEMPLET_MASTER WHERE TEMPLET_GUID=:TEMPLET_GUID";
            }
        }
        public string CareDocs_GetGridTempletMasterByTempletFlagAndClassNameAndTempletName
        {
            get
            {
                return
                   "SELECT * FROM WIS_GRID_TEMPLET_MASTER WHERE GRID_TEMPLET_FLAG=:GRID_TEMPLET_FLAG AND CLASS_NAME=:CLASS_NAME AND TEMPLET_NAME=:TEMPLET_NAME";
            }
        }
        public string CareDocs_GetGridTempletMasterByTempletFlagAndClassName
        {
            get
            {
                return
                   "SELECT * FROM WIS_GRID_TEMPLET_MASTER WHERE GRID_TEMPLET_FLAG=:GRID_TEMPLET_FLAG AND CLASS_NAME=:CLASS_NAME ";
            }
        }
        public string CareDocs_GetGridTempletDetailByTempletGuid
        {
            get
            {
                return
                   "SELECT * FROM WIS_GRID_TEMPLET_DETAIL WHERE TEMPLET_GUID=:TEMPLET_GUID";
            }
        }
        public string CareDocs_GetQiXieTempletMasterByTempletGuid
        {
            get
            {
                return
                   "SELECT * FROM WIS_INSTRUMENT_TEMPLET_MASTER WHERE TEMPLET_GUID=:TEMPLET_GUID";
            }
        }
        public string CareDocs_GetQiXieTempletDetailByTempletGuid
        {
            get
            {
                return
                   "SELECT * FROM WIS_INSTRUMENT_TEMPLET_DETAIL WHERE TEMPLET_GUID=:TEMPLET_GUID ORDER BY SERIAL_NO";
            }
        }



        public string CareDocs_GetDocCareCheckRecord
        {
            get
            {
                return " SELECT * FROM WIS_ANES_DOC_CHECK WHERE PAT_ID=:PAT_ID AND VISIT_ID = :VISIT_ID AND OPER_ID = :OPER_ID AND DOC_NAME = :DOC_NAME ";
            }
        }



        #endregion CareDocs

        #region Common

        public string Common_GetSysDateTime
        {
            get
            {
                return
                    "select sysdate from dual";
            }
        }



        public string Common_GetApplicationVision
        {
            get
            {
                return "ANES5";

            }
        }
        #endregion Common

        #region Sync

        public string Sync_GetCheckReport
        {
            get
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine("SELECT EXAM_DATE_TIME, REPORT_DATE_TIME, EXAM_PARA, DESCRIPTION, IMPRESSION, RECOMMENDATION, IS_ABNORMAL, EXAM_SUB_CLASS ");
                stringBuilder.AppendLine("FROM WIS_EXAM_REPORT_MASTER, WIS_EXAM_REPORT_DETAIL  ");
                stringBuilder.AppendLine("WHERE WIS_EXAM_REPORT_MASTER.EXAM_NO = WIS_EXAM_REPORT_DETAIL.EXAM_NO AND PAT_ID = :PATIENT_ID AND VISIT_ID = :VISIT_ID ORDER BY EXAM_DATE_TIME DESC");
                return stringBuilder.ToString();
            }

        }

        public string Sync_GetMrIndex
        {
            get
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine("SELECT PAT_ID, VISIT_ID, MR_STATUS, STORAGE_VOLUME_LABEL, ACCESS_PATH, LAST_ACCESS_DATE_TIME");
                stringBuilder.AppendLine("FROM WIS_MR_INDEX");
                stringBuilder.AppendLine("WHERE PAT_ID = :PATIENT_ID AND VISIT_ID = :VISIT_ID");
                return stringBuilder.ToString();
            }

        }

        public string Sync_GetMrFileIndex
        {
            get
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine("SELECT *");
                stringBuilder.AppendLine("FROM WIS_MR_FILE_INDEX");
                stringBuilder.AppendLine("WHERE PAT_ID = :PATIENT_ID AND VISIT_ID = :VISIT_ID and file_no=:file_no");
                return stringBuilder.ToString();
            }

        }

        public string Sync_GetLabQuery
        {
            get
            {
                return "SELECT A.REPORT_ITEM_NAME, A.RESULT, A.UNITS,B.TEST_CAUSE FROM WIS_LAB_TEST_DETAIL A,WIS_LAB_TEST_MASTER B "
                    + " WHERE A.TEST_NO = B.TEST_NO AND B.PAT_ID = :PATIENT_ID AND VISIT_ID = :VISIT_ID  ORDER BY A.Result_date_time DESC ";
            }

        }
        public string Sync_GetOrders
        {
            get
            {
                return "SELECT * FROM WIS_ORDER_INDEX WHERE PAT_ID = :PATIENT_ID AND VISIT_ID = :VISIT_ID ";
            }
        }
        #endregion Sync

        #region AnesMaster

        public string AnesMaster_GetTodayOperations
        {
            get
            {
                return "select  A.pat_id, A.visit_id, A.oper_id, B.NAME, B.sex,B.INP_NO,  B.DATE_OF_BIRTH, B.NATION, " +
                    " nvl((select WIS_DICT_DEPT.DEPT_NAME   from WIS_DICT_DEPT where WIS_DICT_DEPT.dept_code = A.dept_stayed ),A.dept_stayed ) dept_stayed," +
                    " A.bed_no, A.scheduled_date_time , A.operating_room," +
                    " nvl((select WIS_DICT_DEPT.DEPT_NAME   from WIS_DICT_DEPT where WIS_DICT_DEPT.dept_code = A.operating_room ),A.operating_room ) operating_room_name," +
                    " A.operating_room_no,  A.sequence,  A.diag_before_oper,  A.pat_condition,  A.OPER_NAME , A.oper_scale, " +
                    " nvl((select WIS_DICT_DEPT.DEPT_NAME   from WIS_DICT_DEPT where WIS_DICT_DEPT.dept_code = A.operating_dept ),A.operating_dept ) operating_dept," +
                    " nvl( ( select  WIS_PERM_HIS_USER.USER_NAME from WIS_PERM_HIS_USER where WIS_PERM_HIS_USER.USER_ID = A.surgeon ),A.surgeon ) surgeon," +
                    " nvl( ( select  WIS_PERM_HIS_USER.USER_NAME from WIS_PERM_HIS_USER where WIS_PERM_HIS_USER.USER_ID = A.first_assistant ),A.first_assistant ) first_assistant," +
                    " nvl( ( select  WIS_PERM_HIS_USER.USER_NAME from WIS_PERM_HIS_USER where WIS_PERM_HIS_USER.USER_ID = A.second_assistant ),A.second_assistant ) second_assistant," +
                    " nvl( ( select  WIS_PERM_HIS_USER.USER_NAME from WIS_PERM_HIS_USER where WIS_PERM_HIS_USER.USER_ID = A.third_assistant ),A.third_assistant ) third_assistant," +
                    " nvl( ( select  WIS_PERM_HIS_USER.USER_NAME from WIS_PERM_HIS_USER where WIS_PERM_HIS_USER.USER_ID = A.fourth_assistant ),A.fourth_assistant ) fourth_assistant," +
                    " A.anes_method,A.INCISION_CLASS,A.INCISION_NUMBER," +
                    "nvl( ( select  WIS_PERM_HIS_USER.USER_NAME from WIS_PERM_HIS_USER where WIS_PERM_HIS_USER.USER_ID = A.anes_doctor ),A.anes_doctor ) anes_doctor," +
                     " nvl( ( select  WIS_PERM_HIS_USER.USER_NAME from WIS_PERM_HIS_USER where WIS_PERM_HIS_USER.USER_ID = A.anes_assistant ),A.anes_assistant ) anes_assistant," +
                     " nvl( ( select  WIS_PERM_HIS_USER.USER_NAME from WIS_PERM_HIS_USER where WIS_PERM_HIS_USER.USER_ID = A.second_anes_doctor ),A.second_anes_doctor ) second_anes_doctor," +
                    " nvl( ( select  WIS_PERM_HIS_USER.USER_NAME from WIS_PERM_HIS_USER where WIS_PERM_HIS_USER.USER_ID = A.third_anes_doctor ),A.third_anes_doctor ) third_anes_doctor," +
                    " nvl( ( select  WIS_PERM_HIS_USER.USER_NAME from WIS_PERM_HIS_USER where WIS_PERM_HIS_USER.USER_ID = A.fourth_anes_assistant ),A.fourth_anes_assistant ) fourth_anes_assistant," +
                    " nvl( ( select  WIS_PERM_HIS_USER.USER_NAME from WIS_PERM_HIS_USER where WIS_PERM_HIS_USER.USER_ID = A.first_oper_nurse ),A.first_oper_nurse ) first_oper_nurse," +
                    " nvl( ( select  WIS_PERM_HIS_USER.USER_NAME from WIS_PERM_HIS_USER where WIS_PERM_HIS_USER.USER_ID = A.second_oper_nurse ),A.second_oper_nurse ) second_oper_nurse," +
                    " nvl( ( select  WIS_PERM_HIS_USER.USER_NAME from WIS_PERM_HIS_USER where WIS_PERM_HIS_USER.USER_ID = A.first_supply_nurse ),A.first_supply_nurse ) first_supply_nurse," +
                    " nvl( ( select  WIS_PERM_HIS_USER.USER_NAME from WIS_PERM_HIS_USER where WIS_PERM_HIS_USER.USER_ID = A.second_supply_nurse ),A.second_supply_nurse ) second_supply_nurse," +
                    " nvl( ( select  WIS_PERM_HIS_USER.USER_NAME from WIS_PERM_HIS_USER where WIS_PERM_HIS_USER.USER_ID = A.third_supply_nurse ),A.third_supply_nurse ) third_supply_nurse," +
                     " nvl( ( select  WIS_PERM_HIS_USER.USER_NAME from WIS_PERM_HIS_USER where WIS_PERM_HIS_USER.USER_ID = A.SECOND_ANES_ASSISTANT ),A.SECOND_ANES_ASSISTANT ) SECOND_ANES_ASSISTANT," +
                    " A.OPER_STATUS, TO_CHAR(SYSDATE,'YYYY') - TO_CHAR(B.DATE_OF_BIRTH,'YYYY') AS PAT_AGE, A.In_Date_Time , A.ANES_START_TIME, A.START_DATE_TIME ,A.END_DATE_TIME, A.ANES_END_TIME, A.OUT_DATE_TIME " +
                    " from WIS_OPER_MASTER A, WIS_PAT_MASTER_INDEX B where A.OPER_STATUS >=0  and " +
                    " to_char(A.scheduled_date_time , 'yyyymmdd') > to_char( sysdate - 1  ,'yyyymmdd')  and to_char(A.scheduled_date_time , 'yyyymmdd') < to_char( sysdate + 1  ,'yyyymmdd') and A.pat_id=B.pat_id ";


            }
        }
        #endregion
        #region 三甲统计
        public string Analyze_GetAnesthesiaMethod
        {
            get
            {
                return "  SELECT * FROM ( SELECT NVL( A.ANES_METHOD ,'未知' ) AS 麻醉方法  ,COUNT(1) AS 台数  FROM WIS_OPER_MASTER A "
                + " WHERE A.START_DATE_TIME>=:START_TIME AND A.START_DATE_TIME<=:END_TIME AND A.OPER_STATUS >=2 "
                + " GROUP BY ANES_METHOD  ORDER BY 台数 DESC ) "
                + " UNION ALL "
                + " SELECT '总计'AS 麻醉方法 , SUM(台数) 台数  FROM ( "
                + " SELECT NVL( A.ANES_METHOD ,'未知' ) AS 麻醉方法  ,COUNT(1) AS 台数  FROM WIS_OPER_MASTER A "
                + " WHERE A.START_DATE_TIME>=:START_TIME AND A.START_DATE_TIME<=:END_TIME AND A.OPER_STATUS >=2 "
                + " GROUP BY ANES_METHOD ) ";
            }
        }
        public string Analyze_GetASAGrade
        {
            get
            {
                return "  SELECT * FROM "
                + " ( "
                + " SELECT ASA_GRADE  级别 , COUNT(*) AS 数量 FROM  "
                + " (  "
                + " SELECT  "
                + " (  "
                + " NVL(  B.ASA_GRADE ,'未填' )   "
                + " ) AS ASA_GRADE  "
                + " FROM WIS_OPER_MASTER A LEFT JOIN WIS_ANES_PLAN B  "
                + " ON A.PAT_ID = B.PAT_ID AND A.VISIT_ID = B.VISIT_ID AND A.OPER_ID = B.OPER_ID  "
                + " WHERE  A.START_DATE_TIME>=:START_TIME AND A.START_DATE_TIME<=:END_TIME  "
                + " ) GROUP BY ASA_GRADE ORDER BY 级别 "
                + " ) "
                + " UNION ALL  "

                + " SELECT '总计' AS 级别 , SUM(ITEM_COUNT) AS 数量 FROM "
                + " ( "
                + " SELECT ASA_GRADE ITEM_NAME , COUNT(*) AS ITEM_COUNT FROM  "
                + " (  "
                + " SELECT  "
                + " (  "
                + " NVL(  B.ASA_GRADE ,'未填' )  "
                + "  ) AS ASA_GRADE  "
                + " FROM WIS_OPER_MASTER A LEFT JOIN WIS_ANES_PLAN B  "
                + " ON A.PAT_ID = B.PAT_ID AND A.VISIT_ID = B.VISIT_ID AND A.OPER_ID = B.OPER_ID  "
                + " WHERE  A.START_DATE_TIME>=:START_TIME AND A.START_DATE_TIME<=:END_TIME  "
                + "  ) GROUP BY ASA_GRADE  "
                + " )  ";
            }
        }
        public string Analyze_GetThreeReview
        {
            get
            {
                return " SELECT ITEM_NAME , COUNT(1) AS ITEM_COUNT FROM  "
                + " ( "
                + "   SELECT * FROM  "
                + "   ( "
                + "          SELECT * FROM WIS_CUSTOM_DATA  WHERE ITEM_NAME LIKE '三甲指标_%' AND ITEM_VALUE = '是' "
                + "   ) B LEFT JOIN WIS_OPER_MASTER A "
                + "   ON B.PAT_ID = A.PAT_ID AND B.VISIT_ID = A.VISIT_ID AND B.OPER_ID = A.OPER_ID "
                + "   WHERE  A.START_DATE_TIME>=:START_TIME AND A.START_DATE_TIME<=:END_TIME  "
                + " ) GROUP BY ITEM_NAME ";
            }
        }
        public string Analyze_GetInPACUCount
        {
            get
            {
                return " SELECT COUNT(1) AS ITEM_COUNT  FROM WIS_OPER_MASTER A   "
                + " WHERE A.OPER_STATUS >= 55 AND IN_PACU_DATE_TIME > START_DATE_TIME  "
                + " AND A.START_DATE_TIME>=:START_TIME AND A.START_DATE_TIME<=:END_TIME  ";
            }
        }
        public string Analyze_GetStewardScore4
        {
            get
            {
                return " SELECT ITEM_NAME , COUNT(1) AS ITEM_COUNT FROM  "
                + " ( "
                + "   SELECT * FROM  "
                + "   ( "
                + "          SELECT * FROM WIS_CUSTOM_DATA  WHERE  ITEM_NAME ='三甲指标_Steward评分' AND ITEM_VALUE >= 4 "
                + "   ) B LEFT JOIN WIS_OPER_MASTER A "
                + "   ON B.PAT_ID = A.PAT_ID AND B.VISIT_ID = A.VISIT_ID AND B.OPER_ID = A.OPER_ID "
                + "   WHERE  A.START_DATE_TIME>=:START_TIME AND A.START_DATE_TIME<=:END_TIME  "
                + " ) GROUP BY ITEM_NAME ";
            }
        }



        public string Analyze_GetAnalyzeSpec
        {
            get
            {
                return " SELECT ITEM_VALUE AS ITEM_NAME , COUNT(1) AS ITEM_COUNT FROM  "
                + " ( "
                + "   SELECT * FROM  "
                + "   ( "
                + "          SELECT * FROM WIS_CUSTOM_DATA  WHERE  ITEM_NAME =:ITEM_SPEC  "
                + "   ) B LEFT JOIN WIS_OPER_MASTER A "
                + "   ON B.PAT_ID = A.PAT_ID AND B.VISIT_ID = A.VISIT_ID AND B.OPER_ID = A.OPER_ID "
                + "   WHERE  A.START_DATE_TIME>=:START_TIME AND A.START_DATE_TIME<=:END_TIME  "
                + " ) GROUP BY ITEM_VALUE ";
            }
        }
        #endregion

        #region 设备仪器统计
        public string Analyze_SheBeiYiQi
        {
            get
            {
                return "SELECT T1.ITEM_NO AS 设备编号 , T1.ITEM_CLASS AS 类别 ,  T1.ITEM_DEPT AS  科室 , T1.ITEM_POS AS 位置  , "
                + "   T1.ITEM_NAME AS 设备名称  ,T1.ITEM_BRAND AS 品牌 ,T1.ITEM_SPEC AS 设备型号 ,NVL(T2.USECOUNT,0) AS 使用次数  FROM  "
                + "   (MEDSURGERY.MED_SHEBEIWEIHU_DETIAL )  T1 "
                + "   LEFT JOIN  "
                + "   ( "
                + "     SELECT ITEM_VALUE AS ITEM_NO ,COUNT(*) AS USECOUNT  FROM "
                + "     ( "
                + "       SELECT * FROM WIS_CUSTOM_DATA B "
                + "       LEFT JOIN  WIS_OPER_MASTER A  "
                + "       ON B.PAT_ID = A.PAT_ID AND B.VISIT_ID = A.VISIT_ID AND B.OPER_ID = A.OPER_ID  "
                + "       WHERE ITEM_NAME LIKE '手术护理单_设备仪器%' AND  NVL(ITEM_VALUE,'##') != '##'  "
                + "       AND A.START_DATE_TIME>=:START_TIME AND A.START_DATE_TIME<=:END_TIME   "
                + "     ) GROUP BY ITEM_VALUE "
                + "   ) T2 "
                + "   ON T1.ITEM_NO = T2.ITEM_NO";
            }
        }
        #endregion

        #region 专家咨询
        public string Acs_GetAcsContextByKeyWord
        {
            get
            {
                return "SELECT T1.WORD , T2.* FROM STANDARD_ARTICLE_KEYWORD T1 LEFT JOIN STANDARD_ARTICLE T2 ON T1.ART_ID = T2.ART_ID WHERE T1.WORD LIKE ";
            }
        }
        #endregion


        #region 手术等级
        public string OperationScale_GetUserList
        {
            get
            {
                return "SELECT B.USER_ID,B.USER_DEPT,B.USER_NAME,B.INPUT_CODE,(SELECT DEPT_NAME FROM WIS_DICT_DEPT C WHERE C.DEPT_CODE=B.USER_DEPT) AS DEPT_NAME FROM WIS_PERM_HIS_USER B  ";
                //return " SELECT A.USER_ID,A.DEPT_ID AS USER_DEPT,B.USER_NAME,B.INPUT_CODE,(SELECT DEPT_NAME FROM WIS_DICT_DEPT C WHERE C.DEPT_CODE=A.DEPT_ID) AS DEPT_NAME FROM WIS_PERM_USER_DEPT A JOIN WIS_PERM_HIS_USER B ON A.USER_ID=B.USER_ID ";
            }
        }
        public string OperationScale_GetOperationList
        {
            get
            {
                return " SELECT  A.OPER_CODE,A.OPER_NAME,(SELECT B.OPER_SCALE FROM MED_USER_VS_OPERSCALE B WHERE B.DEPT_CODE=:Dept_Code AND B.OPER_NAME=A.OPER_NAME) AS OPER_SCALE FROM WIS_DICT_OPERATION A ORDER BY OPER_CODE";
            }
        }
        public string OperationScale_GetOperationListByUserID
        {
            get
            {
                return " SELECT USER_ID , A.operation_code,A.operation_name from MED_OPER_SCALE_CONFIG A  where user_id=:USERID order by operation_code   ";
            }
        }
        public string OperationScale_GetOperationConfigByDeptCode
        {
            get
            {
                return " SELECT * FROM MED_USER_VS_OPERSCALE A  WHERE A.DEPT_CODE=:Dept_Code";
            }
        }
        #endregion

    }
}
