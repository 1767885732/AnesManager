/*==============================================================*/
/* Table: MED_CPB_BLG_RECORD                               */
/*==============================================================*/

CREATE TABLE  MED_CPB_BLG_RECORD(
	 PATIENT_ID  varchar2(50) NOT NULL,
	 VISIT_ID  number(2, 0) NOT NULL,
	 OPER_ID  number(2, 0) NOT NULL,
	 RECORD_NAME  nvarchar2(50) NOT NULL,
	 DETAIL_ID  nvarchar2(50) NULL,
	 RECORD_DATE  date NULL,
   constraint PK_MED_CPB_BLG_RECORD primary key (PATIENT_ID, VISIT_ID,OPER_ID,RECORD_NAME)
)
;
grant select, insert, update, delete on MED_CPB_BLG_RECORD to ROLE_DOCARE;

/*==============================================================*/
/* Table: MED_CPB_EVENT_OPEN                               */
/*==============================================================*/
CREATE TABLE  MED_CPB_EVENT_OPEN(
	 ITEM_NO  number(3, 0) NOT NULL,
	 ITEM_CLASS  nvarchar2(4) NOT NULL,
	 ITEM_NAME  nvarchar2(100) NULL,
	 ITEM_CODE  nvarchar2(40) NULL,
	 ITEM_SPEC  nvarchar2(40) NULL,
	 DOSAGE  number(8, 4) NULL,
	 DOSAGE_UNITS  nvarchar2(20) NULL,
	 ADMINISTRATOR  nvarchar2(20) NULL,
	 IN_ORDER  number(1, 0) NULL,
	 REL_BILL  number(1, 0) NULL,
	 OPER_CLASS  nvarchar2(40) NULL,
	 DURATIVE_INDICATOR  number(1, 0) NULL,
	 METHOD  nvarchar2(40) NULL,
	 PERFORM_SPEED  number(8, 4) NULL,
	 SPEED_UNIT  nvarchar2(20) NULL,
	 EVENT_ATTR  nvarchar2(20) NULL,
	 CONCENTRATION  number(8, 4) NULL,
	 CONCENTRATION_UNIT  nvarchar2(20) NULL,
	 EVENT_ATTR2  nvarchar2(40) NULL,
	 SUPPLIER_NAME  nvarchar2(100) NULL,
	 STANDARD_DOSAGE1  number(8, 4) NULL,
	 STANDARD_DOSAGE2  number(8, 4) NULL,
	 STANDARD_DOSAGE3  number(8, 4) NULL,
	 STANDARD_DOSAGE4  number(8, 4) NULL,
	 STANDARD_DOSAGE5  number(8, 4) NULL,
	 STANDARD_DOSAGE6  number(8, 4) NULL,
	 STANDARD_DOSAGE7  number(8, 4) NULL,
	 STANDARD_DOSAGE8  number(8, 4) NULL,
	 STANDARD_DOSAGE9  number(8, 4) NULL,
	 STANDARD_DOSAGE10  number(8, 4) NULL,
	 STANDARD_DOSAGE11  number(8, 4) NULL,
	 STANDARD_DOSAGE12  number(8, 4) NULL,
	 STANDARD_DOSAGE13  number(8, 4) NULL,
	 STANDARD_DOSAGE14  number(8, 4) NULL,
	 STANDARD_DOSAGE15  number(8, 4) NULL,
 CONSTRAINT PK_MED_CPB_EVENT_OPEN PRIMARY KEY(ITEM_NO,ITEM_CLASS)
) 
;
grant select, insert, update, delete on MED_CPB_EVENT_OPEN to ROLE_DOCARE;

/*==============================================================*/
/* Table: MED_CPB_EXAM_INFO                               */
/*==============================================================*/
CREATE TABLE  MED_CPB_EXAM_INFO(
	 PATIENT_ID  varchar2(20) NOT NULL,
	 VISIT_ID  number(2, 0) NOT NULL,
	 OPER_ID  number(2, 0) NOT NULL,
	 E1  nvarchar2(20) NULL,
	 E2  nvarchar2(20) NULL,
	 E3  nvarchar2(20) NULL,
	 E4  nvarchar2(20) NULL,
	 E5  nvarchar2(20) NULL,
	 E6  nvarchar2(20) NULL,
	 E7  nvarchar2(20) NULL,
	 E8  nvarchar2(20) NULL,
	 E9  nvarchar2(20) NULL,
	 E10  nvarchar2(20) NULL,
	 E11  nvarchar2(20) NULL,
	 E12  nvarchar2(20) NULL,
	 E13  nvarchar2(20) NULL,
	 E14  nvarchar2(20) NULL,
	 E15  nvarchar2(20) NULL,
	 E16  nvarchar2(20) NULL,
	 E17  nvarchar2(20) NULL,
	 E18  nvarchar2(20) NULL,
	 E19  nvarchar2(20) NULL,
	 E20  nvarchar2(20) NULL,
	 E21  nvarchar2(20) NULL,
	 E22  nvarchar2(20) NULL,
	 E23  nvarchar2(20) NULL,
	 E24  nvarchar2(20) NULL,
	 E25  nvarchar2(20) NULL,
	 E26  nvarchar2(20) NULL,
	 E27  nvarchar2(20) NULL,
	 E28  nvarchar2(20) NULL,
	 E29  nvarchar2(20) NULL,
	 E30  nvarchar2(20) NULL,
 CONSTRAINT  PK_MED_CPB_EXAM_INFO PRIMARY KEY(PATIENT_ID,VISIT_ID,OPER_ID)
)
;
grant select, insert, update, delete on MED_CPB_EXAM_INFO to ROLE_DOCARE;

/*==============================================================*/
/* Table: MED_CPB_SUMMARY                               */
/*==============================================================*/
CREATE TABLE  MED_CPB_SUMMARY(
	 PATIENT_ID  varchar2(20) NOT NULL,
	 VISIT_ID  number(2, 0) NOT NULL,
	 OPER_ID  number(2, 0) NOT NULL,
	 PUMP_TIME  nvarchar2(30) NULL,
	 CLAMPED_TIME  nvarchar2(30) NULL,
	 ASSISTANT_TIME  nvarchar2(30) NULL,
	 AVG_FLOW  nvarchar2(10) NULL,
	 AVG_PUMP_PRESSURE  nvarchar2(10) NULL,
	 AVG_PERFUSION_PRESSURE  nvarchar2(10) NULL,
	 MAP  nvarchar2(10) NULL,
	 PRIMING_VOLUME  nvarchar2(10) NULL,
	 ADDING_VOLUME  nvarchar2(10) NULL,
	 TOTAL_PERFUSION_VOLUME  nvarchar2(10) NULL,
	 K_VOLUME  nvarchar2(10) NULL,
	 FILTRATE_VOLUME  nvarchar2(10) NULL,
	 URINARY_VOLUME  nvarchar2(10) NULL,
	 MACHINE_BLOOD  nvarchar2(10) NULL,
	 MACHINE_BLOOD_LAST  nvarchar2(10) NULL,
	 EYES_STATUS  nvarchar2(10) NULL,
	 MEMO  nvarchar2(500) NULL,
	 CONSTRAINT  PK_MED_CPB_SUMMARY PRIMARY KEY(PATIENT_ID,VISIT_ID,OPER_ID)
);
grant select, insert, update, delete on MED_CPB_SUMMARY to ROLE_DOCARE;

comment on table MED_CPB_SUMMARY
  is '体外循环信息总结表';
comment on column MED_CPB_SUMMARY.PUMP_TIME
  is '转机时间';
comment on column MED_CPB_SUMMARY.CLAMPED_TIME
  is '阻断时间';
comment on column MED_CPB_SUMMARY.ASSISTANT_TIME
  is '辅助时间';
comment on column MED_CPB_SUMMARY.AVG_FLOW
  is '平均流量';
comment on column MED_CPB_SUMMARY.AVG_PUMP_PRESSURE
  is '平均泵压';
comment on column MED_CPB_SUMMARY.AVG_PERFUSION_PRESSURE
  is '心肌保护灌注平均压';
comment on column MED_CPB_SUMMARY.MAP
  is '平均动脉压';
comment on column MED_CPB_SUMMARY.PRIMING_VOLUME
  is '预充量';
comment on column MED_CPB_SUMMARY.ADDING_VOLUME
  is '转中添加量';
comment on column MED_CPB_SUMMARY.TOTAL_PERFUSION_VOLUME
  is '心肌保护灌注总量';
comment on column MED_CPB_SUMMARY.K_VOLUME
  is '钾';
comment on column MED_CPB_SUMMARY.FILTRATE_VOLUME
  is '滤液量';
comment on column MED_CPB_SUMMARY.URINARY_VOLUME
  is '尿量';
comment on column MED_CPB_SUMMARY.MACHINE_BLOOD
  is '机器血';
comment on column MED_CPB_SUMMARY.MACHINE_BLOOD_LAST
  is '机器余血';
comment on column MED_CPB_SUMMARY.EYES_STATUS
  is '眼球结膜水肿情况';
comment on column MED_CPB_SUMMARY.MEMO
  is '备注'; 

/*==============================================================*/
/* Table: MED_CPB_INPUT_DICT                               */
/*==============================================================*/
CREATE TABLE  MED_CPB_INPUT_DICT(
	 SERIAL_NO  number(4, 0) NULL,
	 ITEM_CLASS  nvarchar2(40) NOT NULL,
	 ITEM_NAME  nvarchar2(100) NOT NULL,
	 ITEM_CODE  nvarchar2(100) NULL,
	 INPUT_CODE  nvarchar2(20) NULL,
 CONSTRAINT  PK_MED_CPB_INPUT_DICT PRIMARY KEY(ITEM_CLASS,ITEM_NAME)
)
;
grant select, insert, update, delete on MED_CPB_INPUT_DICT to ROLE_DOCARE;

/*==============================================================*/
/* Table: MED_CPB_MASTER                               */
/*==============================================================*/
CREATE TABLE  MED_CPB_MASTER(
	 PATIENT_ID  varchar2(20) NOT NULL,
	 VISIT_ID  number(2, 0) NOT NULL,
	 OPER_ID  number(2, 0) NOT NULL,
	 BLOOD_TYPE  nvarchar2(20) NULL,
	 BSA number(6, 5) NULL,
	 CPB_METHOD  nvarchar2(200) NULL,
	 MP_METHOD  nvarchar2(200) NULL,
	 PERFUSION_METHOD nvarchar2(200) NULL,
	 REBEAT_MOTHOD  nvarchar2(80) NULL,
	 OXYGENATOR_TYPE  nvarchar2(50) NULL,
	 CPB_DOCTOR_FIRST  nvarchar2(20) NULL,
	 CPB_DOCTOR_SECOND  nvarchar2(20) NULL,
	 CPB_DOCTOR_THIRD  nvarchar2(20) NULL,
	 CPB_NURSE_FIRST  nvarchar2(20) NULL,
	 CPB_NURSE_SECOND  nvarchar2(20) NULL,
	 CPB_NURSE_THIRD  nvarchar2(20) NULL,
	 BYPASS_BEGIN_TIME  date NULL,
	 BYPASS_END_TIME  date NULL,
	 CLAMPING_TIME  date NULL,
	 OFF_CLAMPING_TIME  date NULL,
	 ARTERIAL_INTUBATTON  nvarchar2(50) NULL,
	 VENOUS_INTUBATTON  nvarchar2(50) NULL,
	 CARDIAC_PRESERVATION_FLUID  nvarchar2(300) NULL,
	 MEMO  nvarchar2(500) NULL,
 CONSTRAINT  PK_MED_CPB_MASTER PRIMARY KEY(PATIENT_ID,VISIT_ID,OPER_ID)
)  
;
grant select, insert, update, delete on MED_CPB_MASTER to ROLE_DOCARE;

comment on table MED_CPB_MASTER
  is '体外循环信息主表';
comment on column MED_CPB_MASTER.BLOOD_TYPE
  is '血型';
comment on column MED_CPB_MASTER.BSA
  is '体表面积';
comment on column MED_CPB_MASTER.CPB_METHOD
  is '体外循环方法';
comment on column MED_CPB_MASTER.MP_METHOD
  is '心肌保护方法';
comment on column MED_CPB_MASTER.PERFUSION_METHOD
  is '灌注方法(方式)';
comment on column MED_CPB_MASTER.REBEAT_MOTHOD
  is '复跳方式';
comment on column MED_CPB_MASTER.OXYGENATOR_TYPE
  is '氧合器';
comment on column MED_CPB_MASTER.CPB_DOCTOR_FIRST
  is '灌注医生1';
comment on column MED_CPB_MASTER.CPB_DOCTOR_SECOND
  is '灌注医生2';
comment on column MED_CPB_MASTER.CPB_DOCTOR_THIRD
  is '灌注医生3';
comment on column MED_CPB_MASTER.CPB_NURSE_FIRST
  is '灌注护士1';
comment on column MED_CPB_MASTER.CPB_NURSE_SECOND
  is '灌注护士2';
comment on column MED_CPB_MASTER.CPB_NURSE_THIRD
  is '灌注护士3'; 
comment on column MED_CPB_MASTER.BYPASS_BEGIN_TIME
  is '转机开始时间';
comment on column MED_CPB_MASTER.BYPASS_END_TIME
  is '转机结束时间';
comment on column MED_CPB_MASTER.CLAMPING_TIME
  is '阻断主动脉时间';
comment on column MED_CPB_MASTER.OFF_CLAMPING_TIME
  is '开放主动脉时间';
comment on column MED_CPB_MASTER.ARTERIAL_INTUBATTON
  is '动脉插管(部位、型号)';
comment on column MED_CPB_MASTER.VENOUS_INTUBATTON
  is '静脉插管(部位、型号)'; 
comment on column MED_CPB_MASTER.CARDIAC_PRESERVATION_FLUID
  is '心肌保护液'; 
comment on column MED_CPB_MASTER.MEMO
  is '备注'; 
/*==============================================================*/
/* Table: MED_CPB_METHOD_DICT                               */
/*==============================================================*/
CREATE TABLE  MED_CPB_METHOD_DICT(
	 SERIAL_NO  number(2, 0) NULL,
	 CPB_CODE  nvarchar2(20) NULL,
	 CPB_NAME  nvarchar2(100) NOT NULL,
	 INPUT_CODE  nvarchar2(10) NULL,
	 CPB_TYPE  nvarchar2(40) NULL,
CONSTRAINT PK_MED_CPB_METHOD_DICT PRIMARY KEY(CPB_NAME)
)
;
grant select, insert, update, delete on MED_CPB_METHOD_DICT to ROLE_DOCARE;

/*==============================================================*/
/* Table: MED_CPB_PRE_CHECK_RECORD                               */
/*==============================================================*/
CREATE TABLE  MED_CPB_PRE_CHECK_RECORD(
	 PATIENT_ID  varchar2(20) NOT NULL,
	 VISIT_ID  number(2, 0) NOT NULL,
	 OPER_ID  number(2, 0) NOT NULL,
	 CHK01  nvarchar2(20) NULL,
	 CHK02  nvarchar2(20) NULL,
	 CHK03  nvarchar2(20) NULL,
	 CHK04  nvarchar2(20) NULL,
	 CHK05  nvarchar2(20) NULL,
	 CHK06  nvarchar2(20) NULL,
	 CHK07  nvarchar2(20) NULL,
	 CHK08  nvarchar2(20) NULL,
	 CHK09  nvarchar2(20) NULL,
	 CHK10  nvarchar2(20) NULL,
	 CHK11  nvarchar2(20) NULL,
	 CHK12  nvarchar2(20) NULL,
	 CHK13  nvarchar2(20) NULL,
	 CHK14  nvarchar2(20) NULL,
	 CHK15  nvarchar2(20) NULL,
	 CHK16  nvarchar2(20) NULL,
	 CHK17  nvarchar2(20) NULL,
	 CHK18  nvarchar2(20) NULL,
	 CHK19  nvarchar2(20) NULL,
	 CHK20  nvarchar2(20) NULL,
	 CHK21  nvarchar2(20) NULL,
	 CHK22  nvarchar2(20) NULL,
	 CHK23  nvarchar2(20) NULL,
	 CHK24  nvarchar2(20) NULL,
	 CHK25  nvarchar2(20) NULL,
	 CHK26  nvarchar2(20) NULL,
	 CHK27  nvarchar2(20) NULL,
	 CHK28  nvarchar2(20) NULL,
	 CHK29  nvarchar2(20) NULL,
	 CHK30  nvarchar2(20) NULL,
	 CHK31  nvarchar2(20) NULL,
	 CHK32  nvarchar2(20) NULL,
	 CHK33  nvarchar2(20) NULL,
	 CHK34  nvarchar2(20) NULL,
	 CHK35  nvarchar2(20) NULL,
	 CHK36  nvarchar2(20) NULL,
 CONSTRAINT  PK_MED_CPB_PRE_CHECK_RECORD PRIMARY KEY(PATIENT_ID,VISIT_ID,OPER_ID)
)  
;
grant select, insert, update, delete on MED_CPB_PRE_CHECK_RECORD to ROLE_DOCARE;

/*==============================================================*/
/* Table: MED_CPB_PRIMING_DATA                               */
/*==============================================================*/
CREATE TABLE  MED_CPB_PRIMING_DATA(
	 PATIENT_ID  varchar2(20) NOT NULL,
	 VISIT_ID  number(2, 0) NOT NULL,
	 OPER_ID  number(2, 0) NOT NULL,
	 P1  nvarchar2(20) NULL,
	 P2  nvarchar2(20) NULL,
	 P3  nvarchar2(20) NULL,
	 P4  nvarchar2(20) NULL,
	 P5  nvarchar2(20) NULL,
	 P6  nvarchar2(20) NULL,
	 P7  nvarchar2(20) NULL,
	 P8  nvarchar2(20) NULL,
	 P9  nvarchar2(20) NULL,
	 P10  nvarchar2(20) NULL,
	 P11  nvarchar2(20) NULL,
	 P12  nvarchar2(20) NULL,
	 P13  nvarchar2(20) NULL,
	 P14  nvarchar2(20) NULL,
	 P15  nvarchar2(20) NULL,
	 P16  nvarchar2(20) NULL,
 CONSTRAINT  PK_MED_CPB_PRIMING_DATA PRIMARY KEY(PATIENT_ID,VISIT_ID,OPER_ID)
) 
;
grant select, insert, update, delete on MED_CPB_PRIMING_DATA to ROLE_DOCARE;



