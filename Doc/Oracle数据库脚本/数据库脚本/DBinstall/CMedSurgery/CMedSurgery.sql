rem=====================================================
rem     作    者：研发部
rem     整理时间：2008-07-11
rem     说    明：创建麻醉部分
rem=====================================================

connect &MedSurgeryConn

prompt
prompt Creating table MED_ANESTHESIA_INQUIRY_FJSL
prompt ===================================
prompt
create table MED_ANESTHESIA_INQUIRY_FJSL
(
  PATIENT_ID        VARCHAR2(20) not null,
  VISIT_ID          NUMBER(2) not null,
  OPER_ID           NUMBER(2) not null,
  INQUIRY_DATE_TIME DATE not null,
  INQUIRY_DOCTOR    VARCHAR2(8),
  A1                NUMBER(1),
  A2                NUMBER(1),
  A3                NUMBER(1),
  A4                NUMBER(1),
  A5                NUMBER(1),
  A6                NUMBER(1),
  A7                NUMBER(1),
  B1                VARCHAR2(8),
  B2                VARCHAR2(30),
  B3                VARCHAR2(8),
  B4                NUMBER(1),
  B5                NUMBER(1),
  B6                NUMBER(1),
  B7                NUMBER(1),
  B8                VARCHAR2(40),
  C1                VARCHAR2(20),
  C2                NUMBER(2),
  C3                VARCHAR2(8),
  C4                VARCHAR2(8),
  C5                VARCHAR2(8),
  C6                NUMBER(3),
  D1                VARCHAR2(400),
  ENTER_DATE_TIME   DATE,
  ENTERED_BY        VARCHAR2(8),
  A8                NUMBER(1),
  A9                NUMBER(1),
  A10               NUMBER(1),
  A11               NUMBER(1),
  A12               VARCHAR2(40),
  A13               VARCHAR2(10),
  A14               VARCHAR2(80),
  B9                NUMBER(1),
  B10               NUMBER(1),
  B11               NUMBER(1),
  B12               NUMBER(1),
  B14               NUMBER(1),
  B15               NUMBER(1),
  B16               NUMBER(1),
  B17               NUMBER(1),
  B18               NUMBER(1),
  B19               NUMBER(1),
  B20               VARCHAR2(80),
  E1                NUMBER(4),
  E2                NUMBER(4),
  E3                VARCHAR2(5),
  E4                VARCHAR2(8),
  E5                NUMBER(1),
  E6                NUMBER(1),
  E7                NUMBER(1),
  E8                NUMBER(1),
  E9                NUMBER(1),
  E10               NUMBER(1),
  E11               NUMBER(1),
  E12               NUMBER(1),
  E13               NUMBER(1),
  E14               VARCHAR2(100),
  E15               VARCHAR2(8),
  E16               NUMBER(1),
  E17               NUMBER(1),
  E18               NUMBER(1),
  E19               NUMBER(1),
  B13               NUMBER(1),
  B21               VARCHAR2(1200)
)
;
alter table MED_ANESTHESIA_INQUIRY_FJSL
  add constraint PK_ANESTHESIA_INQUIRY_FJSL primary key (PATIENT_ID, VISIT_ID, OPER_ID);
grant select, insert, update, delete on MED_ANESTHESIA_INQUIRY_FJSL to ROLE_DOCARE;

prompt
prompt Creating table MED_MTRL_PURCHASE_PLAN
prompt ===================================
prompt
create table MED_MTRL_PURCHASE_PLAN
(
  PLAN_NO        VARCHAR2(6) not null,
  STORAGE_CODE   VARCHAR2(10),
  ITEM_NO        NUMBER(4) not null,
  MTRL_CODE      VARCHAR2(16),
  MTRL_SPEC      VARCHAR2(20),
  UNITS          VARCHAR2(8),
  PACKAGE_SPEC   VARCHAR2(20),
  PACKAGE_UNITS  VARCHAR2(8),
  QUANTITY       NUMBER(12,2),
  SUPPLIER_ID    VARCHAR2(16),
  PURCHASE_PRICE NUMBER(10,4),
  SUPPLIER       VARCHAR2(60),
  PLANING_DATE   DATE,
  MEMOS          VARCHAR2(20),
  constraint PK_MED_MTRL_PURCHASE_PLAN primary key (PLAN_NO, ITEM_NO)
)
;
grant select, insert, update, delete on MED_MTRL_PURCHASE_PLAN to ROLE_DOCARE;

prompt
prompt Creating table MED_TABLE_COLS_MEANINGS
prompt ===================================
prompt
create table MED_TABLE_COLS_MEANINGS
(
  TABLE_NAME        VARCHAR2(100) not null,
  COLUMN_NAME       VARCHAR2(100) not null,
  HOSPITAL_NAME     VARCHAR2(100) not null,
  COLUMN_MEANINGS   VARCHAR2(100) not null,
  COL_VALUES        VARCHAR2(100),
  constraint PK_APGAR_RESULT 
  	primary key (TABLE_NAME, COLUMN_NAME, HOSPITAL_NAME)
  );

grant select, insert, update, delete on MED_TABLE_COLS_MEANINGS to ROLE_DOCARE;

prompt
prompt Creating table ANES_RECORD_EXT_XAXJ
prompt ===================================
prompt
create table ANES_RECORD_EXT_XAXJ
(
  PATIENT_ID VARCHAR2(20) not null,
  VISIT_ID   NUMBER(2) not null,
  OPER_ID    NUMBER(2) not null,
  A01        NUMBER(8,2),
  A02        VARCHAR2(20),
  A03        VARCHAR2(20),
  A04        VARCHAR2(20),
  A05        NUMBER(8,2),
  A06        NUMBER(8,2),
  A07        NUMBER(8,2),
  A08        NUMBER(8,2),
  A09        NUMBER(8,2),
  A10        VARCHAR2(20),
  A11        VARCHAR2(20),
  A12        VARCHAR2(20),
  A13        VARCHAR2(20),
  A14        VARCHAR2(20),
  A15        VARCHAR2(20),
  A16        VARCHAR2(20),
  A17        VARCHAR2(20),
  A18        VARCHAR2(20),
  A19        VARCHAR2(20),
  A20        VARCHAR2(20),
  A21        VARCHAR2(40),
  A22        VARCHAR2(40),
  A23        VARCHAR2(40),
  A24        VARCHAR2(40),
  A25        VARCHAR2(40),
  A26        VARCHAR2(40),
  A27        VARCHAR2(40),
  A28        VARCHAR2(40),
  A29        VARCHAR2(40),
  A30        VARCHAR2(40),
  A31        NUMBER(4,2),
  A32        VARCHAR2(20),
  A33        NUMBER(4,2),
  A34        VARCHAR2(20),
  A35        VARCHAR2(20),
  A36        NUMBER(6,2),
  A37        NUMBER(6,2),
  A38        VARCHAR2(20),
  A39        VARCHAR2(20),
  A40        VARCHAR2(20),
  A41        VARCHAR2(20),
  A42        VARCHAR2(20)
)
;
alter table ANES_RECORD_EXT_XAXJ
  add constraint PK_ANES_RECORD_EXT_XAXJ primary key (PATIENT_ID, VISIT_ID, OPER_ID);
grant select, insert, update, delete on ANES_RECORD_EXT_XAXJ to ROLE_DOCARE;

prompt
prompt Creating table MED_ANESTHESIA_COMM_DICT
prompt =======================================
prompt
create table MED_ANESTHESIA_COMM_DICT
(
  ITEM_NO    NUMBER(3) not null,
  ITEM_CLASS VARCHAR2(2),
  ITEM_NAME  VARCHAR2(60),
  ITEM_CODE  VARCHAR2(60),
  DATA_TYPE  VARCHAR2(1)
)
;
alter table MED_ANESTHESIA_COMM_DICT
  add constraint PK_MED_ANESTHESIA_COMM_DICT primary key (ITEM_NO);
grant select, insert, update, delete, alter on MED_ANESTHESIA_COMM_DICT to ROLE_DOCARE;

prompt
prompt Creating table MED_ANESTHESIA_EVENT
prompt ===================================
prompt
create table MED_ANESTHESIA_EVENT
(
  PATIENT_ID         VARCHAR2(20) not null,
  VISIT_ID           NUMBER(2) not null,
  OPER_ID            NUMBER(2) not null,
  ITEM_NO            NUMBER(3) not null,
  ITEM_CLASS         VARCHAR2(1),
  EVENT_NO           NUMBER(3) not null,
  ITEM_NAME          VARCHAR2(60),
  ITEM_CODE          VARCHAR2(16),
  ITEM_SPEC          VARCHAR2(20),
  DOSAGE_UNITS       VARCHAR2(8),
  DOSAGE             NUMBER(8,4),
  ADMINISTRATOR      VARCHAR2(8),
  START_TIME         DATE,
  END_DATE           DATE,
  BILL_INDICATOR     NUMBER(1),
  DURATIVE_INDICATOR NUMBER(1),
  METHOD             VARCHAR2(16),
  PERFORM_SPEED      NUMBER(8,4),
  SPEED_UNIT         VARCHAR2(10),
  PARENT_ITEM_NO     NUMBER(3),
  EVENT_ATTR         VARCHAR2(10),
  CONCENTRATION      NUMBER(8,4),
  CONCENTRATION_UNIT VARCHAR2(10),
  BILL_ATTR          NUMBER(1) default 0,
  SUPPLIER_NAME      VARCHAR2(60),
  METHOD_PARENT_NO 		NUMBER(3)
)
;
alter table MED_ANESTHESIA_EVENT
  add constraint PK_MED_ANESTHESIA_EVENT primary key (PATIENT_ID, VISIT_ID, OPER_ID, ITEM_NO, EVENT_NO);
grant select, insert, update, delete, alter on MED_ANESTHESIA_EVENT to ROLE_DOCARE;

prompt
prompt Creating table MED_ANESTHESIA_EVENT_NAME
prompt ========================================
prompt
create table MED_ANESTHESIA_EVENT_NAME
(
  ITEM_NAME          VARCHAR2(60) not null,
  ITEM_NAME_ABBR     VARCHAR2(40),
  ITEM_NAME_ENGLISH  VARCHAR2(40),
  ITEM_NAME_STANDARD VARCHAR2(40),
  ITEM_CODE          VARCHAR2(16),
  MEMO               VARCHAR2(200)
)
;
alter table MED_ANESTHESIA_EVENT_NAME
  add constraint PK_MED_ANESTHESIA_EVENT_NAME primary key (ITEM_NAME);
grant select, insert, update, delete on MED_ANESTHESIA_EVENT_NAME to ROLE_DOCARE;

prompt
prompt Creating table MED_ANESTHESIA_EVENT_OPEN
prompt ========================================
prompt
create table MED_ANESTHESIA_EVENT_OPEN
(
  ITEM_NO            NUMBER(3) not null,
  ITEM_CLASS         VARCHAR2(2) not null,
  ITEM_NAME          VARCHAR2(60),
  ITEM_CODE          VARCHAR2(16),
  ITEM_SPEC          VARCHAR2(20),
  DOSAGE             NUMBER(8,4),
  DOSAGE_UNITS       VARCHAR2(8),
  ADMINISTRATOR      VARCHAR2(8),
  IN_ORDER           NUMBER(1),
  REL_BILL           NUMBER(1) default 0,
  OPER_CLASS         VARCHAR2(16),
  DURATIVE_INDICATOR NUMBER(1),
  METHOD             VARCHAR2(16),
  PERFORM_SPEED      NUMBER(8,4),
  SPEED_UNIT         VARCHAR2(10),
  EVENT_ATTR         VARCHAR2(10),
  CONCENTRATION      NUMBER(8,4),
  CONCENTRATION_UNIT VARCHAR2(10),
  EVENT_ATTR2        VARCHAR2(20),
  SUPPLIER_NAME      VARCHAR2(60)
)
;
alter table MED_ANESTHESIA_EVENT_OPEN
  add constraint PK_MED_ANESTHESIA_EVENT_OPEN primary key (ITEM_CLASS, ITEM_NO);
grant select, insert, update, delete, alter on MED_ANESTHESIA_EVENT_OPEN to ROLE_DOCARE;

prompt
prompt Creating table MED_ANESTHESIA_EVENT_TEMPLET
prompt ===========================================
prompt
create table MED_ANESTHESIA_EVENT_TEMPLET
(
  TEMPLET_CLASS      VARCHAR2(1) default '1',
  ANESTHESIA_METHOD  VARCHAR2(60) default '*' not null,
  TEMPLET            VARCHAR2(40) not null,
  ITEM_CLASS         VARCHAR2(1),
  ITEM_NO            NUMBER(3) not null,
  ITEM_NAME          VARCHAR2(40),
  ITEM_CODE          VARCHAR2(10),
  ITEM_SPEC          VARCHAR2(20),
  CONCENTRATION      NUMBER(8,4),
  PERFORM_SPEED      NUMBER(8,4),
  SPEED_UNIT         VARCHAR2(10),
  DOSAGE             NUMBER(8,4),
  DOSAGE_UNITS       VARCHAR2(8),
  ADMINISTRATOR      VARCHAR2(8),
  DURATIVE_INDICATOR NUMBER(1),
  METHOD             VARCHAR2(16),
  EVENT_ATTR         VARCHAR2(10),
  START_AFTER_INPUT  NUMBER(4,1),
  DURATIVE           NUMBER(4,1),
  SUB_ITEM_INDICATOR NUMBER(1),
  CONCENTRATION_UNIT VARCHAR2(10),
  BILL_ATTR          NUMBER(1),
  CREATE_BY          VARCHAR2(8) default '公用' not null
)
;
alter table MED_ANESTHESIA_EVENT_TEMPLET
  add constraint PK_MED_ANESTHESIA_EVENT_TMPT primary key (TEMPLET, ITEM_NO, CREATE_BY);
grant select, insert, update, delete on MED_ANESTHESIA_EVENT_TEMPLET to ROLE_DOCARE;

prompt
prompt Creating table MED_ANESTHESIA_INPUT_DICT
prompt ========================================
prompt
create table MED_ANESTHESIA_INPUT_DICT
(
  SERIAL_NO  NUMBER(4),
  ITEM_CLASS VARCHAR2(16) not null,
  ITEM_NAME  VARCHAR2(1000) not null,
  ITEM_CODE  VARCHAR2(40),
  INPUT_CODE VARCHAR2(8)
)
;
alter table MED_ANESTHESIA_INPUT_DICT
  add constraint PK_MED_ANESTHESIA_INPUT_DICT primary key (ITEM_CLASS, ITEM_NAME);
grant select, insert, update, delete on MED_ANESTHESIA_INPUT_DICT to ROLE_DOCARE;

prompt
prompt Creating table MED_ANESTHESIA_INQUIRY
prompt =====================================
prompt
create table MED_ANESTHESIA_INQUIRY
(
  PATIENT_ID                VARCHAR2(20) not null,
  VISIT_ID                  NUMBER(2) not null,
  OPER_ID                   NUMBER(2) not null,
  INQUIRY_DATE_TIME         DATE not null,
  BREATH                    VARCHAR2(10),
  THROAT_ACHE               NUMBER(1),
  SOUND_HOARSENESS          NUMBER(1),
  BLOOD_PRESS               VARCHAR2(20),
  CARDIOTACH                VARCHAR2(10),
  NAUSEA                    NUMBER(1),
  CONSCIOUSNESS             VARCHAR2(8),
  HEADACHE                  NUMBER(1),
  LIMB                      VARCHAR2(20),
  EMICTION_RETENTION        NUMBER(1),
  PUNCTURE_POSTION_OF_ACHE  NUMBER(1),
  PUNCTURE_POS_OF_TURGES    NUMBER(1),
  MEMO                      VARCHAR2(100),
  ENTIRE_REVIVAL_TIME       VARCHAR2(20),
  TRAUMA_INDICATOR          NUMBER(1),
  FOCUS_SCATTER_INDICATOR   NUMBER(1),
  LUNG_DISTEND_INDICATOR    NUMBER(1),
  ABDOMEN_DISTEND_INDICATOR NUMBER(1),
  INQUIRY_DOCTOR            VARCHAR2(8),
  ENTER_DATE_TIME           DATE,
  ENTERED_BY                VARCHAR2(8),
  FS1                       NUMBER(1),
  FS2                       NUMBER(1),
  FS3                       NUMBER(1),
  FS4                       NUMBER(1),
  FS5                       NUMBER(1),
  FS6                       NUMBER(1),
  FS7                       NUMBER(1),
  FS8                       NUMBER(1),
  FEEL_ABNORMAL_INDICATOR   NUMBER(1),
  MOTION_ABNORMAL_INDICATOR NUMBER(1),
  HOURS_OF_AFTEROPER        NUMBER(2),
  STATUS                    NUMBER(1),
  P_R                       VARCHAR2(20),
  DAYS 											VARCHAR2(2),
  DOUBLEF 									VARCHAR2(100),
  FS9 											NUMBER(1),
  FS10 											NUMBER(1),
  SHZT 											VARCHAR2(100),
  PLANDATE 									DATE,
  SECUNAME 									VARCHAR2(40),
  		MEMO1                     VARCHAR2(100) ,                                                                                                                             
		MEMO2                     VARCHAR2(100) ,                                                                                                                             
		MEMO3                     VARCHAR2(100) ,                                                                                                                             
		MEMO4                     VARCHAR2(100) ,                                                                                                                             
		MEMO5                     VARCHAR2(100) ,                                                                                                                             
		MEMO6                     VARCHAR2(100) ,                                                                                                                             
		MEMO7                     VARCHAR2(100) ,                                                                                                                             
		N1                        NUMBER(2)     ,                                                                                                                             
		N2                        NUMBER(2)     ,                                                                                                                             
		N3                        NUMBER(2)     ,                                                                                                                             
		N4                        NUMBER(2)     ,                                                                                                                             
		N5                        NUMBER(2)     ,                                                                                                                             
		N6                        NUMBER(2)     ,                                                                                                                             
		N7                        NUMBER(2)     ,                                                                                                                             
		N8                        NUMBER(2)     ,                                                                                                                             
		N9                        NUMBER(2)     ,                                                                                                                             
		N10                       NUMBER(2)     ,                                                                                                                             
		C1                        VARCHAR2(100) ,                                                                                                                             
		C2                        VARCHAR2(100) ,                                                                                                                             
		C3                        VARCHAR2(100) ,                                                                                                                             
		C4                        DATE          
)
;

alter table MED_ANESTHESIA_INQUIRY
  add constraint PK_MED_ANESTHESIA_INQUIRY primary key (PATIENT_ID, VISIT_ID, OPER_ID, INQUIRY_DATE_TIME);
grant select, insert, update, delete on MED_ANESTHESIA_INQUIRY to ROLE_DOCARE;

prompt
prompt Creating table MED_ANESTHESIA_NURSE
prompt ===================================
prompt
create table MED_ANESTHESIA_NURSE
(
  PATIENT_ID             VARCHAR2(20) not null,
  VISIT_ID               NUMBER(2) not null,
  OPER_ID                NUMBER(2) not null,
  OPER_PART              VARCHAR2(10),
  ALERGY_1               VARCHAR2(1),
  ALERGY_2               VARCHAR2(1),
  CONSCIOUSNESS          VARCHAR2(8),
  PRE_ANES_PHAM          VARCHAR2(300),
  PRE_ANES_PHAM_RESULT   VARCHAR2(1),
  BEFORE_COVER           VARCHAR2(200),
  BRING_THING            VARCHAR2(200),
  ANESTHESIA_POSITION    VARCHAR2(10),
  ANESTHESIA_PRESVER     VARCHAR2(20),
  SPECIMAN_NAME          VARCHAR2(10),
  SPECIMAN_SOUR          VARCHAR2(10),
  SPECIMAN_SEND          VARCHAR2(10),
  SPECIMAN_CHEC          VARCHAR2(10),
  TRAND_LIQU             VARCHAR2(10),
  TRAN_BLOOD             VARCHAR2(10),
  AFTER_COVER            VARCHAR2(200),
  SPECIAL_CON            VARCHAR2(40),
  AFTER_NOTIC            VARCHAR2(200),
  ENTER_DATE_TIME        DATE,
  ENTERED_BY             VARCHAR2(8),
  SHALLOW_VENIPUNCTURE   VARCHAR2(4),
  DEEP_VENIPUNCTURE      VARCHAR2(4),
  CATHETERIZATION        VARCHAR2(5),
  INFUSION               NUMBER(5),
  TRANSFUSE_SELF_BLOOD   NUMBER(4),
  TRANSFUSE_OTHERS_BLOOD NUMBER(4),
  TRANSFUSE_LIQUID       VARCHAR2(500),
  AFTER_CONSCIOUSNESS    VARCHAR2(8),
  ASEPTIC_PACKAGE        VARCHAR2(8),
  OUT_DATE_TIME          DATE,
  PRESS                  VARCHAR2(20),
  PULSE                  NUMBER(3),
  SEND_PAT_TO            VARCHAR2(8),
  ELECTRIC_KNIFE         NUMBER(1),
  TOURNIQUET             VARCHAR2(20),
  CATHODE_PLATE          VARCHAR2(20),
  D_IN_TIME              DATE,
  D_OUT_TIME             DATE,
  D_PRESS                NUMBER,
  S_IN_TIME              DATE,
  S_OUT_TIME             DATE,
  S_PRESS                NUMBER,
  URETER_SIZE            VARCHAR2(10),
  IMPLANT_NAME           VARCHAR2(200),
  IMPLANT_MANUFACTORY    VARCHAR2(90),
  IMPLANT_OUT            VARCHAR2(90),
  SEND_IMPLANT_TO        VARCHAR2(40),
  SPECIMAN_SEND1         VARCHAR2(10),
  SPECIMAN_CHEC1         VARCHAR2(10),
  SPECIAL_CON_EXT        VARCHAR2(20),
  SPECIMAN_SOUR1        VARCHAR2(10),
	PERSON1 							VARCHAR2(50),
	PERSON2 							VARCHAR2(50),
	PERSON3 							VARCHAR2(50),
	INFUSION_F 						NUMBER(1),
	INFUSION2_F 					NUMBER(1),
	F1 										NUMBER(1),
	F2 										VARCHAR2(20),
	F3 										VARCHAR2(20),
	F4 										NUMBER(1),
	OPERATION_NAME 				VARCHAR2(200),
	SZTX 									VARCHAR2(20),
	NURSEDATE1 						DATE,
	NURSEDATE2 						DATE,
	FLUIDS 								NUMBER(1),
	QXHS 									VARCHAR2(40),
	XXHS 									VARCHAR2(40),
	JBQXHS 								VARCHAR2(40),
	JBXHHS 								VARCHAR2(40),
	SBHD 									VARCHAR2(40),
	XHHS 									VARCHAR2(40),
	MEMO 									VARCHAR2(200),
	MJZB 									VARCHAR2(20),
	CQSJ1 								NUMBER(3),
	CQSJ2 								NUMBER(3),
	CQSJ3 								NUMBER(3),
	FQSJ1 								NUMBER(3),
	FQSJ2 								NUMBER(3),
	FQSJ3 								NUMBER(3),
	SHJJ1 								VARCHAR2(20),
	SHJJ2 								VARCHAR2(20),
	SHJJ3 								VARCHAR2(20),
	SHJJ4 								VARCHAR2(20),
	SHJJ5 								VARCHAR2(20),
	SHJJ6 								VARCHAR2(20),
	SHJJ7 								VARCHAR2(20),
	SHJJ8 								VARCHAR2(20),
	SHJJ9 								VARCHAR2(20),
	SHJJ10 								VARCHAR2(20),
	SHJJ11 								VARCHAR2(20),
	HIGH_EUIP 						VARCHAR2(200)
)
;

alter table MED_ANESTHESIA_NURSE
  add constraint PK_MED_ANESTHESIA_NURSE primary key (PATIENT_ID, VISIT_ID, OPER_ID);
grant select, insert, update, delete on MED_ANESTHESIA_NURSE to ROLE_DOCARE;

prompt
prompt Creating table MED_ANESTHESIA_PLAN
prompt ==================================
prompt
create table MED_ANESTHESIA_PLAN
(
  PATIENT_ID                  VARCHAR2(20) not null,
  VISIT_ID                    NUMBER(2) not null,
  OPER_ID                     NUMBER(2) not null,
  HEIGHT                      NUMBER(3),
  WEIGHT                      NUMBER(4,1),
  BLOOD_PRESS                 VARCHAR2(20),
  CARDIOTACH                  NUMBER(3),
  PLUS                        NUMBER(3),
  BREATH                      NUMBER(3),
  TEMPETURE                   VARCHAR2(10),
  CONSCIOUSNESS               VARCHAR2(20),
  MR_ABSTRACT                 VARCHAR2(200),
  ANES_HISTORY_INDICATOR      NUMBER(1),
  ANES_HISTORY                VARCHAR2(80),
  ALERGY_DRUGS_INDICATOR      VARCHAR2(80),
  ALERGY_DRUGS                VARCHAR2(80),
  CERVIX                      VARCHAR2(40),
  TOOTH_EXAM                  VARCHAR2(40),
  MOUTH_OPEN_WIDTH            VARCHAR2(4),
  SOUND_OF_HEART_AND_LUNG     VARCHAR2(100),
  LIMB_INDICATOR              NUMBER(1),
  LIMB_FEEL                   VARCHAR2(20),
  DOWN_LIMB_FEEL              VARCHAR2(20),
  VEIN                        VARCHAR2(16),
  SPINE_STATUS                VARCHAR2(40),
  SPINE_STATUS_OF_MIS         VARCHAR2(40),
  HEART_GRADE                 VARCHAR2(8),
  ECG_EXAM                    VARCHAR2(100),
  LUNG                        VARCHAR2(100),
  EXAM_X                      VARCHAR2(100),
  LIVER_INDICATOR             NUMBER(1),
  LIVER                       VARCHAR2(100),
  KIDNEY_INDICATOR            NUMBER(1),
  KIDNEY                      VARCHAR2(100),
  HEMOGLOBIN                  VARCHAR2(20),
  LAB_A                       VARCHAR2(20),
  BLOOD_CORPUSCLE             VARCHAR2(20),
  LAB_C                       VARCHAR2(20),
  BLEEDING_TIME               VARCHAR2(20),
  CRUOR_TIME                  VARCHAR2(20),
  CRUOR_ZYMOGEN_TIME          VARCHAR2(20),
  LAB_K                       VARCHAR2(20),
  LAB_NA                      VARCHAR2(20),
  LAB_CL                      VARCHAR2(20),
  LAB_GIU                     VARCHAR2(20),
  OTHER_LABS                  VARCHAR2(40),
  ASA_GRADE                   VARCHAR2(10),
  ANES_SUMMARY                VARCHAR2(200) default '无',
  OPERATION_CLASS             VARCHAR2(10),
  ANESTHESIA_DRUGS            VARCHAR2(100),
  DRUG_IN_OPERATION           VARCHAR2(100),
  ANES_START_TIME             DATE,
  ANES_END_TIME               DATE,
  ENTER_DATE_TIME             DATE,
  ENTERED_BY                  VARCHAR2(8),
  PRE_ANES_PHAM               VARCHAR2(200),
  PRE_ANES_PHAM_RESULT        VARCHAR2(1),
  ANESTHESIA_METHOD           VARCHAR2(60),
  ANESTHESIA_POSITION         VARCHAR2(10),
  END_INDICATOR               NUMBER(1),
  BED_NO                      VARCHAR2(20),
  ORDER_TRANSFER              NUMBER(1),
  CHARGE_TRANSFER             NUMBER(1),
  OPERATION_NAME              VARCHAR2(100),
  ALLENS                      VARCHAR2(20),
  ALIMENTATION_STATUS         VARCHAR2(8),
  LAB_W                       VARCHAR2(20),
  LAB_ALT                     VARCHAR2(20),
  LAB_AST                     VARCHAR2(20),
  LAB_CR                      VARCHAR2(20),
  LAB_BUN                     VARCHAR2(20),
  LAB_HBCAB                   VARCHAR2(20),
  LAB_HBEAB                   VARCHAR2(20),
  LAB_HBBAG                   VARCHAR2(20),
  LAB_HBSAB                   VARCHAR2(20),
  LAB_HBSAG                   VARCHAR2(20),
  LAB_ANTI_HCV                VARCHAR2(20),
  LAB_CA                      VARCHAR2(20),
  PSYCHOSIS                   VARCHAR2(40),
  SOUND_OF_HEART              VARCHAR2(100),
  SOUND_OF_LUNG               VARCHAR2(100),
  HEART_COLOR_ULTRASONIC      VARCHAR2(100),
  ANESTHESIA_OPERATION        VARCHAR2(400),
  THORACIC_CAGE               VARCHAR2(100),
  INVESTIGATE_SUGGESTION      VARCHAR2(400),
  FLUID_PATH1                 VARCHAR2(20),
  FLUID_PATH2                 VARCHAR2(20),
  FLUID_PATH3                 VARCHAR2(20),
  FASTING                     NUMBER(1) default 1,
  OPER_HISTORY_INDICATOR      NUMBER(1),
  SMOKE_DRINK_INDICATOR       NUMBER(1),
  BLOOD_TRANSFER_HISTORY      NUMBER(1),
  SLEEPING_PILL_INDICATOR     NUMBER(1),
  INTUB_DIFICULT              NUMBER(1),
  MALLAMPATTI                 VARCHAR2(8),
  TONSIL_TUMESCENT_INDICATOR  NUMBER(1),
  TONSIL_TUMESCENT_LEVEL      VARCHAR2(8),
  ABDOMEN                     VARCHAR2(40),
  ARTERY_VEIN_PUNCTURE_POS    VARCHAR2(20),
  OPERATION_POSITION          VARCHAR2(40),
  IN_ROOM_STATUS              VARCHAR2(10),
  HEART_FUN                   VARCHAR2(10),
  RBC_PLOT                    VARCHAR2(20),
  URINE_CONVENTIONAL          VARCHAR2(20),
  URINE_GIU                   VARCHAR2(20),
  UREA_N                      VARCHAR2(20),
  ALBUMIN                     VARCHAR2(20),
  WBC_BALL                    VARCHAR2(20),
  LIVER_FUNCTION              VARCHAR2(20),
  ECG                         VARCHAR2(100),
  HEART_CATHETERIZATION       VARCHAR2(100),
  ECHOCARDIOGRAPHY            VARCHAR2(100),
  X_RAY_EXAMINATION           VARCHAR2(100),
  EASEPAIN_TRANSFER           NUMBER(1),
  PRE_SPEC_ANES_PHAM          VARCHAR2(100),
  URINE_RBC                   VARCHAR2(20),
  URINE_GLOBIN                VARCHAR2(20),
  KIDNEY_ANTIGEN              VARCHAR2(20),
  LAB_KZERO                   VARCHAR2(20),
  ERP_SIFT                    VARCHAR2(20),
  LAB_BGKT                    VARCHAR2(20),
  LAB_BILIRUBIN               VARCHAR2(20),
  LAB_CHOLESTEROL             VARCHAR2(20),
  ANES_HISTORY_INDICATOR_TEXT VARCHAR2(80),
  RETAKE_PIPE                 VARCHAR2(40),
  BED_LABEL                   VARCHAR2(12),
  ANES_KEEP                   VARCHAR2(100),
  VISIT_NURSE                 VARCHAR2(40),
  VISIT_DATE                  DATE,
  OPERATION_DOC               VARCHAR2(40),
  BODY_STATUS                 VARCHAR2(40),
  SKIN_STATUS                 VARCHAR2(40),
  ACTIVE_STATUS               VARCHAR2(40),
  PSYCH_STATUS                VARCHAR2(40),
  PSYCH_MEMO                  VARCHAR2(200),
  DEGREE_STATUS               VARCHAR2(40),
  ECONOMY_STATUS              VARCHAR2(40),
  PAY_WAY                     VARCHAR2(40),
  COMM_MEMO                   VARCHAR2(200),
  BP_STATUS                   VARCHAR2(40),
  OPERATION_HISTORY           VARCHAR2(40),
  I_BP                        VARCHAR2(40),
  I_P                         VARCHAR2(40),
  I_GIU                       VARCHAR2(40),
  V_BP                        VARCHAR2(40),
  V_P                         VARCHAR2(40),
  V_GIU                       VARCHAR2(40),
  SYPHILS                     VARCHAR2(40),
  HIV_INFO                    VARCHAR2(20),
  ALT                         VARCHAR2(20),
  TP                          VARCHAR2(20),
  ALB                         VARCHAR2(20),
  GLB                         VARCHAR2(20),
  CR                          VARCHAR2(20),
  BUN                         VARCHAR2(20),
  UA                          VARCHAR2(20),
  GLU                         VARCHAR2(20),
  TG                          VARCHAR2(20),
  CHO                         VARCHAR2(20),
  HBSAG                       VARCHAR2(100),
  PT                          VARCHAR2(20),
  APTT                        VARCHAR2(20),
  FBG                         VARCHAR2(20),
  TT                          VARCHAR2(20),
  CO2CP                       VARCHAR2(20),
  AG                          VARCHAR2(20),
  TBIL                        VARCHAR2(20),
  DBIL                        VARCHAR2(20),
  NFKY                        VARCHAR2(20),
  QMS                         VARCHAR2(20),
  BLOOD_TYPE                  VARCHAR2(20),
  PROPORTION                  VARCHAR2(20),
  PH                          VARCHAR2(20),
  ALLEN                       VARCHAR2(10),
  STATE                       VARCHAR2(20),
  PLANDATE                    DATE,
  BODY_AREA                   VARCHAR2(10),
  SECUNAME                    VARCHAR2(40),
  SECUNAME_1                  VARCHAR2(40),
  STATESPEC                   VARCHAR2(100),
  P_HISTORY1                  VARCHAR2(200),
  P_HISTORY2                  VARCHAR2(200),
  C_HISTORY1                  VARCHAR2(200),
  C_HISTORY2                  VARCHAR2(200),
  P_WORRY1                    VARCHAR2(10),
  P_WORRY2                    VARCHAR2(10),
  P_WORRY3                    VARCHAR2(10),
  P_WORRY4                    VARCHAR2(10),
  P_WORRY5                    VARCHAR2(10),
  P_WORRY6                    VARCHAR2(10),
  ANES_HISTORY_FAMILY         VARCHAR2(80),
  CARDIAC                     VARCHAR2(80),
  RESPIRATORY                 VARCHAR2(80),
  ENDOCRINE                   VARCHAR2(80),
  GL_GU                       VARCHAR2(80),
  NEUR_HEMA                   VARCHAR2(80),
  MUSCULAR_SKELETAL           VARCHAR2(80),
  HEART_DESC                  VARCHAR2(80),
  MALLAMPATTI_DESC            VARCHAR2(80),
  MEDICATIONS                 VARCHAR2(80),
  NPO_SINCE                   VARCHAR2(80),
  PSCE                        VARCHAR2(80),
  P_M1                        VARCHAR2(20),
  P_M2                        VARCHAR2(20),
  P_M3                        VARCHAR2(20),
  P_T1                        VARCHAR2(20),
  P_T2                        VARCHAR2(20),
  P_T3                        VARCHAR2(20),
  P_T4                        VARCHAR2(20),
  P_T5                        VARCHAR2(20),
  P_N1                        VARCHAR2(20),
  P_N2                        VARCHAR2(20),
  P_N3                        VARCHAR2(20),
  P_N4                        VARCHAR2(20),
  P_H1                        VARCHAR2(20),
  P_H2                        VARCHAR2(20),
  P_H3                        VARCHAR2(20),
  P_H4                        VARCHAR2(20),
  P_H5                        VARCHAR2(20),
  P_H6                        VARCHAR2(20),
  P_HL1                       VARCHAR2(20),
  P_HL2                       VARCHAR2(20),
  P_HL3                       VARCHAR2(20),
  P_HL4                       VARCHAR2(20),
  P_ANES_M1                   VARCHAR2(20),
  P_ANES_M2                   VARCHAR2(20),
  P_ACTION                    VARCHAR2(20)
)
;
alter table MED_ANESTHESIA_PLAN
  add constraint PK_MED_ANESTHESIA_PLAN primary key (PATIENT_ID, VISIT_ID, OPER_ID);
grant select, insert, update, delete on MED_ANESTHESIA_PLAN to ROLE_DOCARE;
grant select, insert, update, delete, references, alter, index on med_anesthesia_plan to MEDCOMM with grant option;

prompt
prompt Creating table MED_ANESTHESIA_RECOVERY
prompt ======================================
prompt
create table MED_ANESTHESIA_RECOVERY
(
  PATIENT_ID             VARCHAR2(20) not null,
  VISIT_ID               NUMBER(2) not null,
  OPER_ID                NUMBER(2) not null,
  NOTE                   VARCHAR2(200),
  SUMM_START_TIME        DATE,
  SUMM_END_TIME          DATE not null,
  TOTAL_TIME             NUMBER(4,1),
  IN_FLUIDS_AMOUNT       NUMBER(6),
  OUT_FLUIDS_AMOUNT      NUMBER(6),
  FS1                    VARCHAR2(50),
  FS2                    VARCHAR2(50),
  FS3                    VARCHAR2(50),
  FS4                    VARCHAR2(50),
  FS5                    VARCHAR2(50),
  FS6                    VARCHAR2(50),
  FS7                    VARCHAR2(50),
  FS8                    VARCHAR2(50),
  FS9                    VARCHAR2(50),
  FS10                   VARCHAR2(50),
  FS11                   VARCHAR2(50),
  FS12                   VARCHAR2(50),
  FS13                   VARCHAR2(50),
  FS14                   VARCHAR2(50),
  FS15                   VARCHAR2(50),
  FS16                   VARCHAR2(50),
  FS17                   VARCHAR2(50),
  FS18                   VARCHAR2(50),
  FS19                   VARCHAR2(50),
  FS20                   VARCHAR2(50),
  FS21                   VARCHAR2(100),
  FS22                   VARCHAR2(100),
  FS23                   VARCHAR2(100),
  FS24                   VARCHAR2(100),
  FS25                   VARCHAR2(100),
  FS26                   VARCHAR2(100),
  FS27                   VARCHAR2(100),
  FS28                   VARCHAR2(100),
  FS29                   VARCHAR2(100),
  FS30                   VARCHAR2(100),
  ENTERED_BY             VARCHAR2(8),
  RECOVERY_HOUR          NUMBER(2),
  RECOVERY_MINUTE        NUMBER(2),
  BLOOD_TRANSFERED       NUMBER(6),
  BLOODPLASMA_TRANSFERED NUMBER(6),
  OTHER_IN_AMOUNT        NUMBER(6),
  ANALGESIC_METHOD       VARCHAR2(40),
  ENTERED_BY1            VARCHAR2(8),
  ENTERED_BY2            VARCHAR2(8)
)
;
alter table MED_ANESTHESIA_RECOVERY
  add constraint PK_MED_ANESTHESIA_RECOVERY primary key (PATIENT_ID, VISIT_ID, OPER_ID, SUMM_END_TIME);
grant select, insert, update, delete on MED_ANESTHESIA_RECOVERY to ROLE_DOCARE;

prompt
prompt Creating table MED_ANESTHESIA_SUMMARY
prompt =====================================
prompt
create table MED_ANESTHESIA_SUMMARY
(
  STYLE_NO              VARCHAR2(8),
  PATIENT_ID            VARCHAR2(20) not null,
  VISIT_ID              NUMBER(2) not null,
  OPER_ID               NUMBER(2) not null,
  A1                    VARCHAR2(12),
  A2                    VARCHAR2(12),
  A3                    VARCHAR2(20),
  A4                    VARCHAR2(12),
  A5                    VARCHAR2(20),
  A6                    VARCHAR2(12),
  A7                    VARCHAR2(12),
  A8                    VARCHAR2(200),
  B1                    VARCHAR2(12),
  B2                    VARCHAR2(12),
  B3                    VARCHAR2(12),
  B4                    VARCHAR2(12),
  B5                    VARCHAR2(12),
  B6                    VARCHAR2(12),
  B7                    VARCHAR2(12),
  B8                    VARCHAR2(12),
  B9                    VARCHAR2(12),
  B10                   VARCHAR2(12),
  B11                   VARCHAR2(12),
  B12                   VARCHAR2(12),
  B13                   VARCHAR2(12),
  B14                   VARCHAR2(120),
  B15                   VARCHAR2(12),
  B16                   VARCHAR2(120),
  B17                   VARCHAR2(12),
  B18                   VARCHAR2(12),
  B19                   VARCHAR2(12),
  B20                   VARCHAR2(100),
  C1                    VARCHAR2(12),
  C2                    VARCHAR2(12),
  C3                    VARCHAR2(12),
  C4                    VARCHAR2(12),
  C5                    VARCHAR2(12),
  C6                    VARCHAR2(50),
  C7                    VARCHAR2(12),
  C8                    VARCHAR2(12),
  C9                    VARCHAR2(12),
  C10                   VARCHAR2(120),
  C11                   VARCHAR2(12),
  F1                    VARCHAR2(12),
  F2                    VARCHAR2(30),
  F3                    VARCHAR2(120),
  F4                    VARCHAR2(12),
  F5                    VARCHAR2(12),
  F6                    VARCHAR2(12),
  F7                    VARCHAR2(12),
  F8                    VARCHAR2(12),
  G1                    VARCHAR2(50),
  G2                    VARCHAR2(50),
  G3                    VARCHAR2(50),
  G4                    VARCHAR2(50),
  G5                    VARCHAR2(50),
  G6                    VARCHAR2(50),
  G7                    VARCHAR2(50),
  G8                    VARCHAR2(50),
  G9                    VARCHAR2(50),
  G10                   VARCHAR2(30),
  BEFORE_OPER           VARCHAR2(200),
  IN_OPER               VARCHAR2(1000),
  AFTER_OPER            VARCHAR2(200),
  END_INDICATOR         NUMBER(1),
  DOCTOR                VARCHAR2(8),
  ENTER_DATE_TIME       DATE,
  ENTERED_BY            VARCHAR2(8),
  MR_ABSTRACT           VARCHAR2(200),
  TOF                   VARCHAR2(20),
  A9                    VARCHAR2(8),
  A10                   VARCHAR2(8),
  A11                   VARCHAR2(4),
  A12                   VARCHAR2(40),
  B21                   NUMBER(3),
  B22                   NUMBER(3),
  C12                   VARCHAR2(16),
  C13                   VARCHAR2(4),
  C14                   VARCHAR2(4),
  C15                   VARCHAR2(100),
  F9                    VARCHAR2(100),
  F10                   VARCHAR2(40),
  F11                   VARCHAR2(40),
  F12                   VARCHAR2(20),
  F13                   VARCHAR2(20),
  F14                   VARCHAR2(24),
  G11                   VARCHAR2(4),
  G12                   VARCHAR2(4),
  G13                   VARCHAR2(8),
  G14                   VARCHAR2(4),
  G15                   VARCHAR2(4),
  G16                   VARCHAR2(4),
  G17                   VARCHAR2(4),
  G18                   VARCHAR2(16),
  B23                   VARCHAR2(40),
  B24                   NUMBER(8,4),
  B25                   VARCHAR2(120),
  B26                   VARCHAR2(12),
  B27                   VARCHAR2(120),
  B28                   VARCHAR2(12),
  B29                   VARCHAR2(12),
  B30                   VARCHAR2(12),
  B31                   VARCHAR2(12),
  ANESTHESIA_NO         VARCHAR2(16),
  C16                   VARCHAR2(30),
  B32                   VARCHAR2(12),
  B33                   VARCHAR2(12),
  B34                   VARCHAR2(12),
  B35                   VARCHAR2(12),
  B36                   VARCHAR2(12),
  A13                   VARCHAR2(12),
  A14                   VARCHAR2(12),
  A15                   NUMBER(2),
  A16                   VARCHAR2(12),
  G19                   VARCHAR2(12),
  G20                   VARCHAR2(12),
  F15                   DATE,
  F16                   VARCHAR2(120),
  A17                   VARCHAR2(8),
  ANAESTHETIC_MACHINE   VARCHAR2(30),
  G21                   VARCHAR2(20),
  G22                   VARCHAR2(12),
  A53                   VARCHAR2(20),
  A24                   VARCHAR2(100),
  A25                   NUMBER(1),
  A26                   VARCHAR2(100),
  A27                   NUMBER(1),
  A28                   NUMBER(1),
  A29                   NUMBER(1),
  A30                   NUMBER(1),
  A31                   NUMBER(1),
  A32                   NUMBER(3),
  A33                   NUMBER(1),
  A34                   NUMBER(1),
  A35                   NUMBER(1),
  A36                   NUMBER(1),
  A37                   NUMBER(1),
  A38                   NUMBER(1),
  A39                   NUMBER(1),
  A40                   NUMBER(1),
  A41                   NUMBER(1),
  A42                   NUMBER(3),
  A43                   VARCHAR2(50),
  A44                   VARCHAR2(10),
  A45                   NUMBER(3),
  A46                   NUMBER(3),
  A47                   NUMBER(3),
  A48                   NUMBER(3),
  A49                   NUMBER(1),
  A50                   NUMBER(3),
  A51                   NUMBER(1),
  A52                   NUMBER(4,2),
  A54                   NUMBER(1),
  A55                   NUMBER(1),
  A56                   NUMBER(1),
  A57                   NUMBER(1),
  A58                   NUMBER(1),
  A59                   NUMBER(1),
  A60                   VARCHAR2(12),
  A19                   NUMBER(1),
  A20                   NUMBER(1),
  A61                   NUMBER(1),
  A62                   NUMBER(1),
  B37                   VARCHAR2(12),
  BLOCK_PRECAVA_TIME    DATE,
  OPEN_PRECAVA_TIME     DATE,
  BLOCK_POSTCAVA_TIME   DATE,
  OPEN_POSTCAVA_TIME    DATE,
  BLOCK_AAO_TIME        DATE,
  OPEN_AAO_TIME         DATE,
  BLOCK_CYCLE_TIME      NUMBER(4),
  CPB_TIME              NUMBER(4),
  A64                   NUMBER(1),
  A63                   NUMBER(4,2),
  PRIMING_FLUID_AMOUNT  NUMBER(7,2),
  DEHYDRATION_AMOUNT    NUMBER(7,2),
  REMAIN_BLOOD_AMOUNT   NUMBER(7,2),
  STOPJUMP_FLUID_AMOUNT NUMBER(7,2),
  LOSE_AMOUNT           NUMBER(7,2),
  CONDITION_OF_HEART    VARCHAR2(20),
  A65                   VARCHAR2(200),
  A66                   VARCHAR2(100),
  A67                   VARCHAR2(150),
  PRICKING_INTERSTICE   VARCHAR2(100),
	PCIA_PCEA 						VARCHAR2(10),
	YC_BP 								VARCHAR2(2),
	CVP 									VARCHAR2(2)
)
;
alter table MED_ANESTHESIA_SUMMARY
  add constraint PK_MED_ANESTHESIA_SUMMARY primary key (PATIENT_ID, VISIT_ID, OPER_ID);
grant select, insert, update, delete on MED_ANESTHESIA_SUMMARY to ROLE_DOCARE;

prompt
prompt Creating table MED_ANESTHESIA_TEMPLET
prompt =====================================
prompt
create table MED_ANESTHESIA_TEMPLET
(
  TEMPLET_NAME            VARCHAR2(40) not null,
  HEIGHT                  NUMBER(3),
  WEIGHT                  NUMBER(4,1),
  BLOOD_PRESS             VARCHAR2(20),
  CARDIOTACH              NUMBER(3),
  PLUS                    NUMBER(3),
  BREATH                  NUMBER(3),
  TEMPETURE               VARCHAR2(10),
  CONSCIOUSNESS           VARCHAR2(8),
  MR_ABSTRACT             VARCHAR2(200),
  ANES_HISTORY_INDICATOR  NUMBER(1),
  ANES_HISTORY            VARCHAR2(80),
  ALERGY_DRUGS_INDICATOR  NUMBER(1),
  ALERGY_DRUGS            VARCHAR2(80),
  CERVIX                  VARCHAR2(40),
  TOOTH_EXAM              VARCHAR2(40),
  MOUTH_OPEN_WIDTH        VARCHAR2(4),
  SOUND_OF_HEART_AND_LUNG VARCHAR2(100),
  LIMB_FEEL               VARCHAR2(10),
  DOWN_LIMB_FEEL          VARCHAR2(10),
  VEIN                    VARCHAR2(16),
  SPINE_STATUS            VARCHAR2(40),
  SPINE_STATUS_OF_MIS     VARCHAR2(40),
  HEART_GRADE             VARCHAR2(8),
  ECG_EXAM                VARCHAR2(40),
  LUNG                    VARCHAR2(40),
  EXAM_X                  VARCHAR2(40),
  LIVER_INDICATOR         NUMBER(1),
  LIVER                   VARCHAR2(40),
  KIDNEY_INDICATOR        NUMBER(1),
  KIDNEY                  VARCHAR2(40),
  HEMOGLOBIN              VARCHAR2(20),
  LAB_A                   VARCHAR2(20),
  BLOOD_CORPUSCLE         VARCHAR2(20),
  LAB_C                   VARCHAR2(20),
  BLEEDING_TIME           VARCHAR2(20),
  CRUOR_TIME              VARCHAR2(20),
  CRUOR_ZYMOGEN_TIME      VARCHAR2(20),
  LAB_K                   VARCHAR2(20),
  LAB_NA                  VARCHAR2(20),
  LAB_CL                  VARCHAR2(20),
  LAB_GIU                 VARCHAR2(20),
  OTHER_LABS              VARCHAR2(40),
  ASA_GRADE               VARCHAR2(10),
  ANES_SUMMARY            VARCHAR2(200),
  PRE_ANES_PHAM           VARCHAR2(40),
  PRE_ANES_PHAM_RESULT    VARCHAR2(1),
  ANESTHESIA_METHOD       VARCHAR2(60),
  ANESTHESIA_POSITION     VARCHAR2(10),
	ECG 						VARCHAR2(100),
	X_RAY_EXAMINATION 			VARCHAR2(100),
	PRE_SPEC_ANES_PHAM 			VARCHAR2(100),
	ECHOCARDIOGRAPHY 				VARCHAR2(100),
	HEART_CATHETERIZATION 	VARCHAR2(100),
	NFKY 										VARCHAR2(20),
	ANES_KEEP 							VARCHAR2(100),
	HBSAG 									VARCHAR2(100)
 )
;
alter table MED_ANESTHESIA_TEMPLET
  add constraint PK_MED_ANESTHESIA_TEMPLET primary key (TEMPLET_NAME);
grant select, insert, update, delete, alter on MED_ANESTHESIA_TEMPLET to ROLE_DOCARE;

prompt
prompt Creating table MED_ANES_AGREEMENT_TEMPLET
prompt =========================================
prompt
create table MED_ANES_AGREEMENT_TEMPLET
(
  TEMPLET_NAME      VARCHAR2(40) not null,
  ANESTHESIA_METHOD VARCHAR2(60),
  CONTENTS          VARCHAR2(2000),
  CREATOR           VARCHAR2(8),
  CREATE_DATE_TIME  DATE,
  USE_INDICATOR     NUMBER(1)
)
;
alter table MED_ANES_AGREEMENT_TEMPLET
  add constraint PK_MED_ANES_AGREEMENT_TEMPLET primary key (TEMPLET_NAME);
grant select, insert, update, delete on MED_ANES_AGREEMENT_TEMPLET to ROLE_DOCARE;

prompt
prompt Creating table MED_ANES_ORDERS
prompt =========================================
prompt
create table MED_ANES_ORDERS
(
  PATIENT_ID VARCHAR2(20) not null,
  VISIT_ID   NUMBER(2) not null,
  OPER_ID    NUMBER(2) not null,
  RESERVED1  VARCHAR2(200),
  RESERVED2  VARCHAR2(200),
  RESERVED3  VARCHAR2(200),
  RESERVED4  VARCHAR2(200),
  RESERVED5  VARCHAR2(200),
  RESERVED6  VARCHAR2(200),
  RESERVED7  VARCHAR2(200),
  RESERVED8  VARCHAR2(200),
  RESERVED9  VARCHAR2(200),
  RESERVED10 VARCHAR2(200),
  RESERVED11 VARCHAR2(200),
  B1         VARCHAR2(200),
  B2         VARCHAR2(200),
  B3         VARCHAR2(200),
  B5         VARCHAR2(30),
  B6         VARCHAR2(30),
  B7         VARCHAR2(30),
  B8         VARCHAR2(30),
  B9         VARCHAR2(30),
  B10        VARCHAR2(30),
  B11        VARCHAR2(30),
  B12        VARCHAR2(30),
  B13        VARCHAR2(30),
  B14        VARCHAR2(30),
  B15        VARCHAR2(30),
  B16        VARCHAR2(30),
  B17        VARCHAR2(30),
  B18        VARCHAR2(30),
  B19        VARCHAR2(30),
  C1         VARCHAR2(200),
  C2         VARCHAR2(200),
  C3         VARCHAR2(200),
  C4         VARCHAR2(200),
  C5         VARCHAR2(200),
  D1         VARCHAR2(20),
  D2         VARCHAR2(20),
  D3         VARCHAR2(20),
  D4         VARCHAR2(20),
  D5         VARCHAR2(20),
  D6         VARCHAR2(20),
  D7         VARCHAR2(20),
  D8         VARCHAR2(20),
  D9         VARCHAR2(20),
  E1         VARCHAR2(20),
  F1         VARCHAR2(20),
  G1         VARCHAR2(20),
  G2         VARCHAR2(20),
  G3         VARCHAR2(20),
  G4         VARCHAR2(20),
  H1         VARCHAR2(20),
  H2         VARCHAR2(20),
  H3         VARCHAR2(20),
  J1         VARCHAR2(20),
  J2         VARCHAR2(20),
  J3         VARCHAR2(20),
  J4         VARCHAR2(20),
  J5         VARCHAR2(20),
  J6         VARCHAR2(20),
  J7         VARCHAR2(20),
  J8         VARCHAR2(20),
  K1         VARCHAR2(30),
  L1         VARCHAR2(50),
  L2         VARCHAR2(20),
  L3         VARCHAR2(200),
  M1         VARCHAR2(200),
  N1         VARCHAR2(50),
  N2         VARCHAR2(200),
  N3         VARCHAR2(200),
  N4         VARCHAR2(200),
  N5         VARCHAR2(200),
  N6         VARCHAR2(200),
  N7         VARCHAR2(200),
  N8         VARCHAR2(200),
  P1         VARCHAR2(50),
  P2         VARCHAR2(30),
  P3         VARCHAR2(200),
  P4         VARCHAR2(30),
  P5         VARCHAR2(30),
  P6         VARCHAR2(30),
  P7         VARCHAR2(30),
  Q1         VARCHAR2(30),
  Q2         VARCHAR2(30),
  Q3         VARCHAR2(30),
  Q4         VARCHAR2(200),
  Q5         VARCHAR2(30),
  Q6         VARCHAR2(30),
  Q7         VARCHAR2(30),
  R1         VARCHAR2(100),
  R2         VARCHAR2(200),
  R3         VARCHAR2(100),
  R4         VARCHAR2(200),
  R5         VARCHAR2(200),
  R6         VARCHAR2(100),
  R7         VARCHAR2(100),
  R8         VARCHAR2(100),
  R9         VARCHAR2(100),
  B20        VARCHAR2(30),
  B4         VARCHAR2(200),
  P8         VARCHAR2(30),
  P9         VARCHAR2(30),
  A1         VARCHAR2(30),
  A2         VARCHAR2(30),
  A3         VARCHAR2(30),
  A4         VARCHAR2(30),
  A5         VARCHAR2(30),
  A6         VARCHAR2(30),
  A7         VARCHAR2(30),
  A8         VARCHAR2(30),
  A9         VARCHAR2(30),
  A10        VARCHAR2(30)
);
alter table MED_ANES_ORDERS
  add constraint PK_MED_ANES_ORDERS primary key (PATIENT_ID, VISIT_ID, OPER_ID);
-- Grant/Revoke object privileges 
grant select, insert, update, delete on MED_ANES_ORDERS to ROLE_DOCARE;

------------------------------------------
--  New table med_anes_orders_template  --
------------------------------------------
-- Create table
create table MED_ANES_ORDERS_TEMPLATE
(
  TEMPLATE_NAME VARCHAR2(40) not null,
  RESERVED1     VARCHAR2(200),
  RESERVED2     VARCHAR2(200),
  RESERVED3     VARCHAR2(200),
  RESERVED4     VARCHAR2(200),
  RESERVED5     VARCHAR2(200),
  RESERVED6     VARCHAR2(200),
  RESERVED7     VARCHAR2(200),
  RESERVED8     VARCHAR2(200),
  RESERVED9     VARCHAR2(200),
  RESERVED10    VARCHAR2(200),
  RESERVED11    VARCHAR2(200)
);
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_ANES_ORDERS_TEMPLATE
  add constraint PK_MED_ANES_ORDERS_TEMPLATE primary key (TEMPLATE_NAME);
grant select, insert, update, delete on MED_ANES_ORDERS_TEMPLATE to ROLE_DOCARE;


-------------------------------------------
--  New table med_anes_record_ext_infor  --
-------------------------------------------
-- Create table
create table MED_ANES_RECORD_EXT_INFOR
(
  PATIENT_ID           VARCHAR2(10) not null,
  VISIT_ID             NUMBER(2) not null,
  OPER_ID              NUMBER(2) not null,
  NG                   VARCHAR2(20),
  BPAUTO               VARCHAR2(20),
  BPALINE              VARCHAR2(20),
  ECGII                VARCHAR2(20),
  ECGV5                VARCHAR2(20),
  URINEVOL             VARCHAR2(20),
  O2ANALIZER           VARCHAR2(20),
  ETCO2                VARCHAR2(20),
  SWANGANZ             VARCHAR2(20),
  PULSEOXIM            VARCHAR2(20),
  TEMP                 VARCHAR2(20),
  BIS                  VARCHAR2(20),
  TEE                  VARCHAR2(20),
  MACH                 VARCHAR2(20),
  PRESSUREPT           VARCHAR2(20),
  EYES                 VARCHAR2(20),
  HEATLAMP             VARCHAR2(20),
  HUMIDIFYER           VARCHAR2(20),
  FILTER               VARCHAR2(20),
  CELLSAVER            VARCHAR2(20),
  FLUIDWARMER          VARCHAR2(20),
  FACEMASK             VARCHAR2(20),
  LMA                  VARCHAR2(20),
  CIRCABS              VARCHAR2(20),
  INTUBATION           VARCHAR2(20),
  NASOTRACH            VARCHAR2(20),
  CDOUBLE              VARCHAR2(20),
  CUFF                 VARCHAR2(20),
  BBS                  VARCHAR2(20),
  BLADE                VARCHAR2(20),
  CO2                  VARCHAR2(20),
  LR                   VARCHAR2(20),
  PHARYNGEALVIEW       VARCHAR2(20),
  CSIZE                VARCHAR2(20),
  FIBEROPTICINTUBATION VARCHAR2(20),
  INDUCEDHYPOTHERM     VARCHAR2(20),
  INDUCEDHYPOTENS      VARCHAR2(20),
  EXTRACORPCIRC        VARCHAR2(20),
  PCIA                 VARCHAR2(20),
  PCEA                 VARCHAR2(20),
  OTHER                VARCHAR2(20),
  PAIN_MED             VARCHAR2(80)
);
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_ANES_RECORD_EXT_INFOR
  add constraint PK_MED_ANES_RECORD_EXT_INFOR primary key (PATIENT_ID, VISIT_ID, OPER_ID);
grant select, insert, update, delete on MED_ANES_RECORD_EXT_INFOR to ROLE_DOCARE;

---------------------------------
--  New table med_call_record  --
---------------------------------
-- Create table
create table MED_CALL_RECORD
(
  CALL_TIME    DATE not null,
  CALL_CONTENT VARCHAR2(40) not null,
  MEMO         VARCHAR2(40)
);
-- Add comments to the table 
comment on table MED_CALL_RECORD
  is '麻醉医生呼叫记录';
-- Add comments to the columns 
comment on column MED_CALL_RECORD.CALL_TIME
  is '呼叫时间';
comment on column MED_CALL_RECORD.CALL_CONTENT
  is '呼叫内容';
comment on column MED_CALL_RECORD.MEMO
  is '备注';
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_CALL_RECORD
  add constraint PK_MED_MED_CALL_RECORD primary key (CALL_TIME, CALL_CONTENT);
grant select, insert, update, delete on MED_CALL_RECORD to ROLE_DOCARE;

-------------------------------
--  New table med_drug_bill  --
-------------------------------
-- Create table
create table MED_DRUG_BILL
(
  PATIENT_ID VARCHAR2(20) not null,
  VISIT_ID   NUMBER(6) not null,
  OPER_ID    NUMBER(6) not null,
  DRUG_ID    NUMBER(6) not null,
  DRUG_ITEM  VARCHAR2(40),
  NUM        NUMBER(6)
);

grant select, insert, update, delete on MED_DRUG_BILL to ROLE_DOCARE;
----------------------------------------
--  New table med_drug_input_storage  --
----------------------------------------
-- Create table
create table MED_DRUG_INPUT_STORAGE
(
  INPUT_NO        VARCHAR2(20) not null,
  ITEM_NO         NUMBER(3) not null,
  DRUG_CODE       VARCHAR2(40),
  DRUG_NAME       VARCHAR2(60),
  DRUG_UNITS      VARCHAR2(60),
  DRUG_SPEC       VARCHAR2(60),
  DRUG_SUPPLY     VARCHAR2(60),
  DRUG_NUM        NUMBER(10,2),
  DRUG_COST       NUMBER(10,2),
  INPUT_DATE      DATE,
  INPUT_OPER      VARCHAR2(10),
  IN_STATUS       NUMBER(1),
  OUTPUT_NO_INHIS VARCHAR2(20)
);
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_DRUG_INPUT_STORAGE
  add constraint PK_MED_DRUG_INPUT_STORAGE primary key (INPUT_NO, ITEM_NO);
grant select, insert, update, delete on MED_DRUG_INPUT_STORAGE to ROLE_DOCARE;

----------------------------------
--  New table med_drug_storage  --
----------------------------------
-- Create table
create table MED_DRUG_STORAGE
(
  DRUG_CODE   VARCHAR2(40) not null,
  DRUG_NAME   VARCHAR2(60),
  DRUG_UNITS  VARCHAR2(60),
  DRUG_SPEC   VARCHAR2(60) not null,
  DRUG_SUPPLY VARCHAR2(60) not null,
  DRUG_NUM    NUMBER(10,2),
  DRUG_TYPE   NUMBER(1),
  INPUT_PY    VARCHAR2(60)
);
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_DRUG_STORAGE
  add constraint PK_MED_DRUG_STORAGE primary key (DRUG_CODE, DRUG_SPEC, DRUG_SUPPLY);
grant select, insert, update, delete on MED_DRUG_STORAGE to ROLE_DOCARE;


prompt
prompt Creating table MED_ANES_BILL_TEMPLET
prompt ====================================
prompt
create table MED_ANES_BILL_TEMPLET
(
  TEMPLET    VARCHAR2(50) not null,
  ITEM_NO    NUMBER(3) not null,
  ITEM_CLASS VARCHAR2(1),
  ITEM_CODE  VARCHAR2(10),
  ITEM_NAME  VARCHAR2(40),
  ITEM_SPEC  VARCHAR2(20),
  UNITS      VARCHAR2(8),
  AMOUNT     NUMBER(6,2),
  COSTS      NUMBER(8,2)
)
;
alter table MED_ANES_BILL_TEMPLET
  add constraint PK_MED_ANES_BILL_TEMPLET primary key (TEMPLET, ITEM_NO);
grant select, insert, update, delete on MED_ANES_BILL_TEMPLET to ROLE_DOCARE;

prompt
prompt Creating table MED_ANES_DRUG_UNITS_DESC
prompt =======================================
prompt
create table MED_ANES_DRUG_UNITS_DESC
(
  UNITS_DESC     VARCHAR2(10) not null,
  DOSAGE         NUMBER(8,2),
  DOSAGE_UNITS   VARCHAR2(10),
  DURATION_UNITS VARCHAR2(4)
)
;
alter table MED_ANES_DRUG_UNITS_DESC
  add constraint PK_MED_ANES_DRUG_UNITS_DESC primary key (UNITS_DESC);
grant select, insert, update, delete on MED_ANES_DRUG_UNITS_DESC to ROLE_DOCARE;

prompt
prompt Creating table MED_ANES_QUERY_RESULT_TEMP
prompt =========================================
prompt
create table MED_ANES_QUERY_RESULT_TEMP
(
  SESSION_SID NUMBER(12) not null,
  SERIAL_NO   NUMBER(8) not null,
  PATIENT_ID  VARCHAR2(20),
  VISIT_ID    NUMBER(2),
  OPER_ID     NUMBER(2)
)
;
alter table MED_ANES_QUERY_RESULT_TEMP
  add constraint PK_MED_ANES_QUERY_RESULT_TEMP primary key (SESSION_SID, SERIAL_NO);
grant select, insert, update, delete on MED_ANES_QUERY_RESULT_TEMP to ROLE_DOCARE;

prompt
prompt Creating table MED_BLOOD_GAS_ANALYSIS_REC
prompt =========================================
prompt
create table MED_BLOOD_GAS_ANALYSIS_REC
(
  PATIENT_ID      VARCHAR2(20) not null,
  VISIT_ID        NUMBER(2) not null,
  OPER_ID         NUMBER(2) not null,
  TIME_POINT      DATE not null,
  MEASURED_EVENT  VARCHAR2(16) not null,
  MEASURED_ITEM   VARCHAR2(16) not null,
  MEASURED_VALUE  VARCHAR2(16),
  UNITS           VARCHAR2(10),
  OPERATOR        VARCHAR2(8),
  MEASURED_SAMPLE VARCHAR2(30)
)
;
alter table MED_BLOOD_GAS_ANALYSIS_REC
  add constraint PK_MED_BLOOD_GAS_ANALYSIS_REC primary key (PATIENT_ID, VISIT_ID, OPER_ID, TIME_POINT, MEASURED_EVENT, MEASURED_ITEM);
grant select, insert, update, delete on MED_BLOOD_GAS_ANALYSIS_REC to ROLE_DOCARE;

prompt
prompt Creating table MED_BLOOD_GAS_ITEM_DICT
prompt ======================================
prompt
create table MED_BLOOD_GAS_ITEM_DICT
(
  SERIAL_NO       NUMBER(2),
  ITEM_CODE       VARCHAR2(16),
  ITEM_NAME       VARCHAR2(16) not null,
  VALID_INDICATOR NUMBER(1),
  MUST_SELECT     NUMBER(1),
  INPUT_CODE      VARCHAR2(8),
  UNITS           VARCHAR2(20)
)
;
alter table MED_BLOOD_GAS_ITEM_DICT
  add constraint PK_MED_BLOOD_GAS_ITEM_DICT primary key (ITEM_NAME);
grant select, insert, update, delete on MED_BLOOD_GAS_ITEM_DICT to ROLE_DOCARE;

prompt
prompt Creating table MED_CAMERA_DICT
prompt ==============================
prompt
create table MED_CAMERA_DICT
(
  SERIAL_NO NUMBER(4),
  CAM_NAME  VARCHAR2(30) not null,
  DEPT_CODE VARCHAR2(8),
  ROOM_NO   VARCHAR2(3),
  IPADDR    VARCHAR2(15),
  MACADDR   VARCHAR2(12),
  HTTP_PORT VARCHAR2(6),
  USER_NAME VARCHAR2(16),
  USER_PASS VARCHAR2(16),
  PATH_REC  VARCHAR2(28)
)
;
alter table MED_CAMERA_DICT
  add constraint PK_MED_CAMERA_DICT primary key (CAM_NAME);
grant select, insert, update, delete on MED_CAMERA_DICT to ROLE_DOCARE;

prompt
prompt Creating table MED_DEPT_INFO_DICT
prompt =================================
prompt
create table MED_DEPT_INFO_DICT
(
  SERIAL_NO                  NUMBER(3),
  DEPT_CODE                  VARCHAR2(8) not null,
  DEPT_NAME                  VARCHAR2(20),
  DIRECIOR_NAME              VARCHAR2(10),
  APPROVED_BED_NUM           NUMBER(4),
  ACTUAL_BED_NUM             NUMBER(4),
  APPROVED_DOCTOR_NUM        NUMBER(3),
  DOCTOR_NUM_1               NUMBER(3),
  DOCTOR_NUM_2               NUMBER(3),
  APPROVED_NURSE_NUM         NUMBER(3),
  HOLISTIC_NURSING_INDICATOR NUMBER(1),
  NURSE_NUM_1                NUMBER(3),
  NURSE_NUM_2                NUMBER(3),
  NURSE_NUM_3                NUMBER(3),
  DEPT_CLINIC_ATTR           NUMBER(1),
  NURSING_INDEX_SYSTEM       VARCHAR2(30),
  HEADNURSE_NAME             VARCHAR2(10),
  INPUT_CODE                 VARCHAR2(8)
)
;
alter table MED_DEPT_INFO_DICT
  add constraint PK_MED_DEPT_INFO_DICT primary key (DEPT_CODE);
grant select, insert, update, delete on MED_DEPT_INFO_DICT to ROLE_DOCARE;

prompt
prompt Creating table MED_DRUG_BORROW_DETAIL
prompt =====================================
prompt
create table MED_DRUG_BORROW_DETAIL
(
  BORROW_DATE DATE not null,
  BORROW_NO   NUMBER(4) not null,
  ITEM_NO     NUMBER(4) not null,
  DRUG_CODE   VARCHAR2(16),
  DRUG_SPEC   VARCHAR2(20),
  UNITS       VARCHAR2(8),
  SUPPLIER_ID VARCHAR2(60),
  QUANTITY    NUMBER(12,2)
)
;
alter table MED_DRUG_BORROW_DETAIL
  add constraint PK_MED_DRUG_BORROW_DETAIL primary key (BORROW_DATE, BORROW_NO, ITEM_NO);
grant select, insert, update, delete on MED_DRUG_BORROW_DETAIL to ROLE_DOCARE;

prompt
prompt Creating table MED_DRUG_BORROW_MASTER
prompt =====================================
prompt
create table MED_DRUG_BORROW_MASTER
(
  BORROW_DATE      DATE not null,
  BORROW_NO        NUMBER(4) not null,
  EMP_NO           VARCHAR2(16),
  EMP_NAME         VARCHAR2(8),
  MEMOS            VARCHAR2(40),
  OPERATOR         VARCHAR2(8),
  RECORD_DATE_TIME DATE,
  CHECK_DATE_TIME  DATE
)
;
alter table MED_DRUG_BORROW_MASTER
  add constraint PK_MED_DRUG_BORROW_MASTER primary key (BORROW_DATE, BORROW_NO);
grant select, insert, update, delete on MED_DRUG_BORROW_MASTER to ROLE_DOCARE;

prompt
prompt Creating table MED_DRUG_KEEP
prompt ============================
prompt
create table MED_DRUG_KEEP
(
  EMP_NO      VARCHAR2(16) not null,
  EMP_NAME    VARCHAR2(8),
  DRUG_CODE   VARCHAR2(16) not null,
  DRUG_SPEC   VARCHAR2(20) not null,
  UNITS       VARCHAR2(8),
  SUPPLIER_ID VARCHAR2(60) not null,
  QUANTITY    NUMBER(12,2)
)
;
alter table MED_DRUG_KEEP
  add constraint PK_MED_DRUG_KEEP primary key (EMP_NO, DRUG_CODE, DRUG_SPEC, SUPPLIER_ID);
grant select, insert, update, delete on MED_DRUG_KEEP to ROLE_DOCARE;

prompt
prompt Creating table MED_DRUG_RETURN_DETAIL
prompt =====================================
prompt
create table MED_DRUG_RETURN_DETAIL
(
  RETURN_DATE DATE not null,
  RETURN_NO   NUMBER(4) not null,
  ITEM_NO     NUMBER(4) not null,
  DRUG_CODE   VARCHAR2(16),
  DRUG_SPEC   VARCHAR2(20),
  UNITS       VARCHAR2(8),
  SUPPLIER_ID VARCHAR2(60),
  QUANTITY    NUMBER(12,2)
)
;
alter table MED_DRUG_RETURN_DETAIL
  add constraint PK_MED_DRUG_RETURN_DETAIL primary key (RETURN_DATE, RETURN_NO, ITEM_NO);
grant select, insert, update, delete on MED_DRUG_RETURN_DETAIL to ROLE_DOCARE;

prompt
prompt Creating table MED_DRUG_RETURN_MASTER
prompt =====================================
prompt
create table MED_DRUG_RETURN_MASTER
(
  RETURN_DATE      DATE not null,
  RETURN_NO        NUMBER(4) not null,
  EMP_NO           VARCHAR2(16),
  EMP_NAME         VARCHAR2(8),
  MEMOS            VARCHAR2(40),
  OPERATOR         VARCHAR2(8),
  RECORD_DATE_TIME DATE,
  CHECK_DATE_TIME  DATE,
  RETURN_CLASS     VARCHAR2(8)
)
;
alter table MED_DRUG_RETURN_MASTER
  add constraint PK_MED_DRUG_RETURN_MASTER primary key (RETURN_DATE, RETURN_NO);
grant select, insert, update, delete on MED_DRUG_RETURN_MASTER to ROLE_DOCARE;

prompt
prompt Creating table MED_DRUG_USE_DETAIL
prompt ==================================
prompt
create table MED_DRUG_USE_DETAIL
(
  USE_DATE      DATE not null,
  USE_NO        NUMBER(4) not null,
  ITEM_NO       NUMBER(3) not null,
  DRUG_CODE     VARCHAR2(16) not null,
  DRUG_SPEC     VARCHAR2(20) not null,
  DRUG_NAME     VARCHAR2(60),
  SUPPLIER_NAME VARCHAR2(60),
  BATCH_NO      VARCHAR2(16),
  PACKAGE_SPEC  VARCHAR2(20),
  PACKAGE_UNITS VARCHAR2(8),
  QUANTITY      NUMBER(6,2),
  COSTS         NUMBER(8,2),
  PAYMENTS      NUMBER(8,2),
  KEEP_INDICATOR NUMBER(1)
)
;
alter table MED_DRUG_USE_DETAIL
  add constraint PK_MED_DRUG_USE_DETAIL primary key (USE_DATE, USE_NO, ITEM_NO);
grant select, insert, update, delete on MED_DRUG_USE_DETAIL to ROLE_DOCARE;

----------------------------------------
--  New table med_mtrl_input_storage  --
----------------------------------------
-- Create table
create table MED_MTRL_INPUT_STORAGE
(
  INPUT_NO        VARCHAR2(20) not null,
  ITEM_NO         NUMBER(3) not null,
  MTRL_CODE       VARCHAR2(40),
  MTRL_NAME       VARCHAR2(60),
  MTRL_SPEC       VARCHAR2(60),
  MTRL_SUPPLY     VARCHAR2(60),
  MTRL_NUM        NUMBER(10,2),
  MTRL_COST       NUMBER(10,2),
  INPUT_DATE      DATE,
  INPUT_OPER      VARCHAR2(10),
  OUTPUT_NO_INHIS VARCHAR2(20),
  IN_STATUS       NUMBER(1),
  MTRL_UNITS      VARCHAR2(60)
);
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_MTRL_INPUT_STORAGE
  add constraint PK_MED_MTRL_INPUT_STORAGE primary key (INPUT_NO, ITEM_NO);
grant select, insert, update, delete on MED_MTRL_INPUT_STORAGE to ROLE_DOCARE;


----------------------------------
--  New table med_mtrl_storage  --
----------------------------------
-- Create table
create table MED_MTRL_STORAGE
(
  MTRL_CODE   VARCHAR2(40) not null,
  MTRL_NAME   VARCHAR2(60),
  MTRL_SPEC   VARCHAR2(60) not null,
  MTRL_SUPPLY VARCHAR2(60) not null,
  MTRL_NUM    NUMBER(10,2),
  MTRL_TYPE   NUMBER(1),
  INPUT_PY    VARCHAR2(60),
  MTRL_UNITS  VARCHAR2(60),
  MTRL_PRICE  NUMBER(10,2)
);
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_MTRL_STORAGE
  add constraint PK_MED_MTRL_STORAGE primary key (MTRL_CODE, MTRL_SPEC, MTRL_SUPPLY);
grant select, insert, update, delete on MED_MTRL_STORAGE to ROLE_DOCARE;


prompt
prompt Creating table MED_DRUG_USE_MASTER
prompt ==================================
prompt
create table MED_DRUG_USE_MASTER
(
  USE_DATE        DATE not null,
  USE_NO          NUMBER(4) not null,
  STORAGE_CODE    VARCHAR2(10) not null,
  PATIENT_ID      VARCHAR2(20),
  VISIT_ID        NUMBER(2),
  OPER_ID         NUMBER(2),
  COSTS           NUMBER(8,2),
  PAYMENTS        NUMBER(8,2),
  OPER_DOCTOR     VARCHAR2(8),
  ANES_DOCTOR     VARCHAR2(8),
  OPERATION_NURSE VARCHAR2(8),
  SUPPLY_NURSE    VARCHAR2(8),
  CHECK_DATE_TIME DATE,
  KEEP_INDICATOR  NUMBER(1)
)
;
alter table MED_DRUG_USE_MASTER
  add constraint PK_MED_DRUG_USE_MASTER primary key (USE_DATE, USE_NO);
grant select, insert, update, delete on MED_DRUG_USE_MASTER to ROLE_DOCARE;

prompt
prompt Creating table MED_EVENT_VS_CHARGE
prompt ==================================
prompt
create table MED_EVENT_VS_CHARGE
(
  EVENT_ITEM_CLASS  VARCHAR2(16),
  EVENT_ITEM_NAME   VARCHAR2(60),
  EVENT_ITEM_SPEC   VARCHAR2(20),
  CHARGE_ITEM_NO    NUMBER(2),
  CHARGE_ITEM_CLASS VARCHAR2(16),
  CHARGE_ITEM_CODE  VARCHAR2(10),
  CHARGE_ITEM_NAME  VARCHAR2(60),
  CHARGE_ITEM_SPEC  VARCHAR2(20),
  AMOUNT            NUMBER(4),
  UNITS             VARCHAR2(8),
  NOTE              VARCHAR2(1)
)
;
alter table MED_EVENT_VS_CHARGE
  add constraint pk_MED_EVENT_VS_CHARGE primary key (EVENT_ITEM_CLASS, EVENT_ITEM_NAME, CHARGE_ITEM_NO);
grant select, insert, update, delete on MED_EVENT_VS_CHARGE to PUBLIC;

prompt
prompt Creating table MED_INP_BILL_DETAIL
prompt ==================================
prompt
create table MED_INP_BILL_DETAIL
(
  PATIENT_ID             VARCHAR2(20) not null,
  VISIT_ID               NUMBER(2) not null,
  ITEM_NO                NUMBER(6) not null,
  ITEM_CLASS             VARCHAR2(1),
  ITEM_NAME              VARCHAR2(60),
  ITEM_CODE              VARCHAR2(16),
  ITEM_SPEC              VARCHAR2(20),
  AMOUNT                 NUMBER(6,2),
  UNITS                  VARCHAR2(8),
  ORDERED_BY             VARCHAR2(8),
  PERFORMED_BY           VARCHAR2(8),
  COSTS                  NUMBER(8,2),
  CHARGES                NUMBER(8,2),
  BILLING_DATE_TIME      DATE,
  OPERATOR_NO            VARCHAR2(4),
  RCPT_NO                VARCHAR2(8),
  SPECIAL_FEE            NUMBER(8,2),
  INSUR_FEE              VARCHAR2(3),
  WARD_CODE              VARCHAR2(8),
  ORDERED_DOCTOR_GROUP   VARCHAR2(8),
  ORDERED_EMP_NO         VARCHAR2(6),
  ORDERED_DOCTOR         VARCHAR2(8),
  PERFORMED_DOCTOR_GROUP VARCHAR2(8),
  PERFORMED_EMP_NO       VARCHAR2(6),
  PERFORMED_DOCTOR       VARCHAR2(8),
  REFUND_ITEM_NO         NUMBER(6)
)
;
alter table MED_INP_BILL_DETAIL
  add constraint PK_MED_INP_BILL_DETAIL primary key (PATIENT_ID, VISIT_ID, ITEM_NO);
alter table MED_INP_BILL_DETAIL
  add constraint NN_CHARGES
  check ("CHARGES" IS NOT NULL);
alter table MED_INP_BILL_DETAIL
  add constraint NN_COSTS
  check ("COSTS" IS NOT NULL);
create index IND_MED_INP_BILL_DETAIL_1 on MED_INP_BILL_DETAIL (RCPT_NO);
create index IND_MED_INP_BILL_DETAIL_2 on MED_INP_BILL_DETAIL (BILLING_DATE_TIME);
grant select, insert, update, delete on MED_INP_BILL_DETAIL to ROLE_DOCARE;

prompt
prompt Creating table MED_INQUIRY_TEMPLET
prompt ==================================
prompt
create table MED_INQUIRY_TEMPLET
(
  TEMPLET_NAME              VARCHAR2(40) not null,
  BREATH                    VARCHAR2(10),
  THROAT_ACHE               NUMBER(1),
  SOUND_HOARSENESS          NUMBER(1),
  BLOOD_PRESS               VARCHAR2(20),
  CARDIOTACH                VARCHAR2(10),
  NAUSEA                    NUMBER(1),
  CONSCIOUSNESS             VARCHAR2(8),
  HEADACHE                  NUMBER(1),
  LIMB                      VARCHAR2(20),
  EMICTION_RETENTION        NUMBER(1),
  PUNCTURE_POSTION_OF_ACHE  NUMBER(1),
  PUNCTURE_POS_OF_TURGES    NUMBER(1),
  MEMO                      VARCHAR2(100),
  ENTIRE_REVIVAL_TIME       VARCHAR2(20),
  TRAUMA_INDICATOR          NUMBER(1),
  FOCUS_SCATTER_INDICATOR   NUMBER(1),
  LUNG_DISTEND_INDICATOR    NUMBER(1),
  ABDOMEN_DISTEND_INDICATOR NUMBER(1),
  INQUIRY_DOCTOR            VARCHAR2(8),
  FS1                       NUMBER(2),
  FS2                       NUMBER(2),
  FS3                       NUMBER(2),
  FS4                       NUMBER(2),
  FS5                       NUMBER(2),
  FS6                       NUMBER(2)
)
;
alter table MED_INQUIRY_TEMPLET
  add constraint PK_MED_INQUIRY_TEMPLET primary key (TEMPLET_NAME);
grant select, insert, update, delete on MED_INQUIRY_TEMPLET to ROLE_DOCARE;

prompt
prompt Creating table MED_MEDAPP_VER
prompt =============================
prompt
create table MED_MEDAPP_VER
(
  APPNAME VARCHAR2(30) not null,
  HISID   VARCHAR2(30) not null,
  HISNAME VARCHAR2(50) not null,
  MEMO    VARCHAR2(100)
)
;
alter table MED_MEDAPP_VER
  add constraint PK_MED_MEDAPP_VER primary key (APPNAME);
grant select, insert, update, delete on MED_MEDAPP_VER to ROLE_DOCARE;

prompt
prompt Creating table MED_MIXED_DRUG
prompt =============================
prompt
create table MED_MIXED_DRUG
(
  MIXED_DRUG_NAME VARCHAR2(100) not null,
  SERIAL_NO       NUMBER(2),
  DRUG_NAME       VARCHAR2(40) not null,
  ITEM_CODE       VARCHAR2(10),
  ITEM_SPEC       VARCHAR2(20),
  CONCENTRATION   NUMBER(8,4),
  PROPORTION      NUMBER(8,4),
  DOSAGE          NUMBER(8,4),
  DOSAGE_UNITS    VARCHAR2(8)
)
;
alter table MED_MIXED_DRUG
  add constraint PK_MED_MIXED_DRUG primary key (MIXED_DRUG_NAME, DRUG_NAME);
grant select, insert, update, delete on MED_MIXED_DRUG to ROLE_DOCARE;

prompt
prompt Creating table MED_MONITOR_FUNCTION
prompt ===================================
prompt
create table MED_MONITOR_FUNCTION
(
  FUNCTION_NAME VARCHAR2(20) not null,
  ITEM_CODE     VARCHAR2(6) not null,
  SERIAL_NO     NUMBER(6)
)
;
alter table MED_MONITOR_FUNCTION
  add constraint PK_MED_MONITOR_FUNCTION primary key (FUNCTION_NAME, ITEM_CODE);
grant select, insert, update, delete on MED_MONITOR_FUNCTION to ROLE_DOCARE;

prompt
prompt Creating table MED_MTRL_EXPORT_DETAIL
prompt =====================================
prompt
create table MED_MTRL_EXPORT_DETAIL
(
  DOCUMENT_NO         VARCHAR2(10) not null,
  ITEM_NO             NUMBER(4) not null,
  MTRL_CODE           VARCHAR2(16),
  MTRL_SPEC           VARCHAR2(20),
  UNITS               VARCHAR2(8),
  BATCH_NO            VARCHAR2(16),
  ANTISEPSIS_DATE     DATE,
  EXPIRE_DATE         DATE,
  SUPPLIER_ID         VARCHAR2(16),
  IMPORT_DOCUMENT_NO  VARCHAR2(10),
  PURCHASE_PRICE      NUMBER(10,4),
  RETAIL_PRICE        NUMBER(10,4),
  PACKAGE_SPEC        VARCHAR2(20),
  QUANTITY            NUMBER(12,2),
  PACKAGE_UNITS       VARCHAR2(8),
  SUB_PACKAGE_1       NUMBER(12,2),
  SUB_PACKAGE_UNITS_1 VARCHAR2(8),
  SUB_PACKAGE_SPEC_1  VARCHAR2(20),
  SUB_PACKAGE_2       NUMBER(12,2),
  SUB_PACKAGE_UNITS_2 VARCHAR2(8),
  SUB_PACKAGE_SPEC_2  VARCHAR2(20)
)
;
alter table MED_MTRL_EXPORT_DETAIL
  add constraint PK_MED_MTRL_EXPORT_DETAIL primary key (DOCUMENT_NO, ITEM_NO);
grant select, insert, update, delete on MED_MTRL_EXPORT_DETAIL to ROLE_DOCARE;

prompt
prompt Creating table MED_MTRL_EXPORT_DETAIL_HIS
prompt =========================================
prompt
create table MED_MTRL_EXPORT_DETAIL_HIS
(
  HIS_STORAGE_CODE    VARCHAR2(32) not null,
  HIS_DOCUMENT_NO     VARCHAR2(10) not null,
  ITEM_NO             NUMBER(4) not null,
  EXPORT_CLASS        VARCHAR2(8),
  EXPORT_DATE         DATE,
  MTRL_CODE           VARCHAR2(16),
  MTRL_SPEC           VARCHAR2(20),
  UNITS               VARCHAR2(8),
  BATCH_NO            VARCHAR2(16),
  ANTISEPSIS_DATE     DATE,
  EXPIRE_DATE         DATE,
  SUPPLIER_ID         VARCHAR2(16),
  PURCHASE_PRICE      NUMBER(10,4),
  DISCOUNT            NUMBER(5,2),
  RETAIL_PRICE        NUMBER(10,4),
  PACKAGE_SPEC        VARCHAR2(20),
  QUANTITY            NUMBER(12,2),
  PACKAGE_UNITS       VARCHAR2(8),
  SUB_PACKAGE_1       NUMBER(12,2),
  SUB_PACKAGE_UNITS_1 VARCHAR2(8),
  SUB_PACKAGE_SPEC_1  VARCHAR2(20),
  SUB_PACKAGE_2       NUMBER(12,2),
  SUB_PACKAGE_UNITS_2 VARCHAR2(8),
  SUB_PACKAGE_SPEC_2  VARCHAR2(20),
  INVOICE_NO          VARCHAR2(10),
  INVOICE_DATE        DATE,
  ENTER_OPERATOR      VARCHAR2(30),
  APPLY_OPERATOR      VARCHAR2(30),
  CHECK_OPERATOR      VARCHAR2(30),
  ACQUIRED_DATE       DATE,
  STORAGE_CODE        VARCHAR2(10),
  DOCUMENT_NO         VARCHAR2(10)
)
;
alter table MED_MTRL_EXPORT_DETAIL_HIS
  add constraint PK_MED_MTRL_EXPORT_DETAIL_HIS primary key (HIS_STORAGE_CODE, HIS_DOCUMENT_NO, ITEM_NO);
grant select, insert, update, delete on MED_MTRL_EXPORT_DETAIL_HIS to ROLE_DOCARE;

prompt
prompt Creating table MED_MTRL_EXPORT_MASTER
prompt =====================================
prompt
create table MED_MTRL_EXPORT_MASTER
(
  DOCUMENT_NO        VARCHAR2(10) not null,
  STORAGE_CODE       VARCHAR2(10),
  EXPORT_DATE        DATE,
  RECEIVER           VARCHAR2(60),
  ACCOUNT_RECEIVABLE NUMBER(10,2),
  ACCOUNT_PAYED      NUMBER(10,2),
  ADDITIONAL_FEE     NUMBER(8,2),
  EXPORT_CLASS       VARCHAR2(8),
  SUB_STORAGE        VARCHAR2(8),
  ACCOUNT_INDICATOR  NUMBER(1),
  MEMOS              VARCHAR2(20),
  OPERATOR           VARCHAR2(8),
  HIS_DOCUMENT_NO    VARCHAR2(16)
)
;
alter table MED_MTRL_EXPORT_MASTER
  add constraint PK_MTRL_EXPORT_MASTER primary key (DOCUMENT_NO);
grant select, insert, update, delete on MED_MTRL_EXPORT_MASTER to ROLE_DOCARE;

prompt
prompt Creating table MED_MTRL_IMPORT_DETAIL
prompt =====================================
prompt
create table MED_MTRL_IMPORT_DETAIL
(
  DOCUMENT_NO         VARCHAR2(10) not null,
  ITEM_NO             NUMBER(4) not null,
  MTRL_CODE           VARCHAR2(16),
  MTRL_SPEC           VARCHAR2(20),
  UNITS               VARCHAR2(8),
  BATCH_NO            VARCHAR2(16),
  ANTISEPSIS_DATE     DATE,
  EXPIRE_DATE         DATE,
  SUPPLIER_ID         VARCHAR2(10),
  PURCHASE_PRICE      NUMBER(10,4),
  DISCOUNT            NUMBER(5,2),
  RETAIL_PRICE        NUMBER(10,4),
  PACKAGE_SPEC        VARCHAR2(20),
  QUANTITY            NUMBER(12,2),
  PACKAGE_UNITS       VARCHAR2(8),
  SUB_PACKAGE_1       NUMBER(12,2),
  SUB_PACKAGE_UNITS_1 VARCHAR2(8),
  SUB_PACKAGE_SPEC_1  VARCHAR2(20),
  SUB_PACKAGE_2       NUMBER(12,2),
  SUB_PACKAGE_UNITS_2 VARCHAR2(8),
  SUB_PACKAGE_SPEC_2  VARCHAR2(20),
  INVOICE_NO          VARCHAR2(10),
  INVOICE_DATE        DATE
)
;
alter table MED_MTRL_IMPORT_DETAIL
  add constraint PK_MTRL_IMPORT_DETAIL primary key (DOCUMENT_NO, ITEM_NO);
grant select, insert, update, delete on MED_MTRL_IMPORT_DETAIL to ROLE_DOCARE;

prompt
prompt Creating table MED_MTRL_IMPORT_MASTER
prompt =====================================
prompt
create table MED_MTRL_IMPORT_MASTER
(
  DOCUMENT_NO        VARCHAR2(10) not null,
  STORAGE_CODE       VARCHAR2(10),
  IMPORT_DATE        DATE,
  SUPPLIER           VARCHAR2(60),
  ACCOUNT_RECEIVABLE NUMBER(10,2),
  ACCOUNT_PAYED      NUMBER(10,2),
  ADDITIONAL_FEE     NUMBER(8,2),
  IMPORT_CLASS       VARCHAR2(8),
  SUB_STORAGE        VARCHAR2(8),
  ACCOUNT_INDICATOR  NUMBER(1),
  MEMOS              VARCHAR2(20),
  OPERATOR           VARCHAR2(8)
)
;
alter table MED_MTRL_IMPORT_MASTER
  add constraint PK_MTRL_IMPORT_MASTER primary key (DOCUMENT_NO);
grant select, insert, update, delete on MED_MTRL_IMPORT_MASTER to ROLE_DOCARE;

prompt
prompt Creating table MED_MTRL_PRICE_LIST
prompt ==================================
prompt
create table MED_MTRL_PRICE_LIST
(
  MTRL_CODE    VARCHAR2(16) not null,
  MTRL_SPEC    VARCHAR2(20) not null,
  SUPPLIER_ID  VARCHAR2(10) not null,
  UNITS        VARCHAR2(8),
  TRADE_PRICE  NUMBER(10,4),
  RETAIL_PRICE NUMBER(10,4),
  START_DATE   DATE not null,
  STOP_DATE    DATE,
  MEMOS        VARCHAR2(20)
)
;
alter table MED_MTRL_PRICE_LIST
  add constraint PK_MED_MTRL_PRICE_LIST primary key (MTRL_CODE, MTRL_SPEC, SUPPLIER_ID, START_DATE);
grant select, insert, update, delete on MED_MTRL_PRICE_LIST to ROLE_DOCARE;

prompt
prompt Creating table MED_MTRL_PRICE_PROFIT
prompt ====================================
prompt
create table MED_MTRL_PRICE_PROFIT
(
  STORAGE_CODE        VARCHAR2(10) not null,
  PRICE_ADJUSTED_DATE DATE not null,
  MTRL_CODE           VARCHAR2(16) not null,
  MTRL_SPEC           VARCHAR2(20) not null,
  SUPPLIER_ID         VARCHAR2(16),
  PACKAGE_SPEC        VARCHAR2(20) not null,
  PACKAGE_UNITS       VARCHAR2(8),
  CURRENT_QUANTITY    NUMBER(12,2),
  OLD_PRICE           NUMBER(10,4),
  NEW_PRICE           NUMBER(10,4)
)
;
alter table MED_MTRL_PRICE_PROFIT
  add constraint PK_MTRL_PRICE_PROFIT primary key (STORAGE_CODE, MTRL_CODE, MTRL_SPEC, PACKAGE_SPEC, PRICE_ADJUSTED_DATE);
grant select, insert, update, delete on MED_MTRL_PRICE_PROFIT to ROLE_DOCARE;

prompt
prompt Creating table MED_MTRL_PROVIDE_APPLICATION
prompt ===========================================
prompt
create table MED_MTRL_PROVIDE_APPLICATION
(
  APPLICANT_STORAGE   VARCHAR2(10) not null,
  PROVIDE_STORAGE     VARCHAR2(10) not null,
  ITEM_NO             NUMBER(4) not null,
  MTRL_CODE           VARCHAR2(16),
  MTRL_SPEC           VARCHAR2(20),
  UNITS               VARCHAR2(8),
  PACKAGE_SPEC        VARCHAR2(20),
  QUANTITY            NUMBER(12,2),
  PACKAGE_UNITS       VARCHAR2(8),
  APPLICANT_DATE_TIME DATE
)
;
alter table MED_MTRL_PROVIDE_APPLICATION
  add constraint PK_MTRL_PROVIDE_APPLICATION primary key (APPLICANT_STORAGE, PROVIDE_STORAGE, ITEM_NO);
grant select, insert, update, delete on MED_MTRL_PROVIDE_APPLICATION to ROLE_DOCARE;

prompt
prompt Creating table MED_MTRL_PROVIDE_NOTICE
prompt ======================================
prompt
create table MED_MTRL_PROVIDE_NOTICE
(
  PROVIDE_STORAGE   VARCHAR2(10) not null,
  APPLICANT_STORAGE VARCHAR2(10) not null,
  DOCUMENT_NO       VARCHAR2(10) not null
)
;
alter table MED_MTRL_PROVIDE_NOTICE
  add constraint PK_MTRL_PROVIDE_NOTICE primary key (PROVIDE_STORAGE, DOCUMENT_NO);
grant select, insert, update, delete on MED_MTRL_PROVIDE_NOTICE to ROLE_DOCARE;

prompt
prompt Creating table MED_MTRL_STOCK
prompt =============================
prompt
create table MED_MTRL_STOCK
(
  STORAGE_CODE        VARCHAR2(10) not null,
  MTRL_CODE           VARCHAR2(16) not null,
  MTRL_SPEC           VARCHAR2(20) not null,
  UNITS               VARCHAR2(8),
  BATCH_NO            VARCHAR2(16) not null,
  ANTISEPSIS_DATE     DATE,
  EXPIRE_DATE         DATE,
  SUPPLIER_ID         VARCHAR2(10) not null,
  PURCHASE_PRICE      NUMBER(10,4),
  DISCOUNT            NUMBER(5,2),
  PACKAGE_SPEC        VARCHAR2(20) not null,
  QUANTITY            NUMBER(12,2),
  PACKAGE_UNITS       VARCHAR2(8),
  SUB_PACKAGE_1       NUMBER(12,2),
  SUB_PACKAGE_UNITS_1 VARCHAR2(8),
  SUB_PACKAGE_SPEC_1  VARCHAR2(20),
  SUB_PACKAGE_2       NUMBER(12,2),
  SUB_PACKAGE_UNITS_2 VARCHAR2(8),
  SUB_PACKAGE_SPEC_2  VARCHAR2(20),
  SUB_STORAGE         VARCHAR2(8),
  LOCATION            VARCHAR2(20),
  DOCUMENT_NO         VARCHAR2(10),
  SUPPLY_INDICATOR    NUMBER(1)
)
;
alter table MED_MTRL_STOCK
  add constraint PK_MTRL_STOCK primary key (STORAGE_CODE, MTRL_CODE, MTRL_SPEC, SUPPLIER_ID, PACKAGE_SPEC, BATCH_NO);
grant select, insert, update, delete on MED_MTRL_STOCK to ROLE_DOCARE;

prompt
prompt Creating table MED_MTRL_STOCK_BALANCE
prompt =====================================
prompt
create table MED_MTRL_STOCK_BALANCE
(
  STORAGE_CODE     VARCHAR2(10) not null,
  YEAR_MONTH       DATE not null,
  MTRL_CODE        VARCHAR2(16) not null,
  MTRL_SPEC        VARCHAR2(20) not null,
  SUPPLIER_ID      VARCHAR2(16) not null,
  PACKAGE_SPEC     VARCHAR2(20) not null,
  PACKAGE_UNITS    VARCHAR2(8),
  INITIAL_QUANTITY NUMBER(12,2),
  INITIAL_MONEY    NUMBER(10,2),
  IMPORT_QUANTITY  NUMBER(12,2),
  IMPORT_MONEY     NUMBER(10,2),
  EXPORT_QUANTITY  NUMBER(12,2),
  EXPORT_MONEY     NUMBER(10,2),
  INVENTORY        NUMBER(12,2),
  INVENTORY_MONEY  NUMBER(10,2),
  PROFIT           NUMBER(10,2)
)
;
alter table MED_MTRL_STOCK_BALANCE
  add constraint PK_MTRL_STOCK_BALANCE primary key (YEAR_MONTH, STORAGE_CODE, MTRL_CODE, MTRL_SPEC, SUPPLIER_ID, PACKAGE_SPEC);
grant select, insert, update, delete on MED_MTRL_STOCK_BALANCE to ROLE_DOCARE;

prompt
prompt Creating table MED_MTRL_STORAGE_DEPT
prompt ====================================
prompt
create table MED_MTRL_STORAGE_DEPT
(
  STORAGE_CODE     VARCHAR2(10) not null,
  STORAGE_NAME     VARCHAR2(40) not null,
  IMPORT_NO_PREFIX VARCHAR2(6),
  IMPORT_NO_AVA    NUMBER(6),
  EXPORT_NO_PREFIX VARCHAR2(6),
  EXPORT_NO_AVA    NUMBER(6),
  EXTERNAL_STORATE VARCHAR2(1),
  CODE_IN_HIS      VARCHAR2(32)
)
;
alter table MED_MTRL_STORAGE_DEPT
  add constraint PK_MED_MTRL_STORAGE_DEPT primary key (STORAGE_CODE);
grant select, insert, update, delete on MED_MTRL_STORAGE_DEPT to ROLE_DOCARE;

prompt
prompt Creating table MED_MTRL_STORAGE_PROFILE
prompt =======================================
prompt
create table MED_MTRL_STORAGE_PROFILE
(
  STORAGE_CODE       VARCHAR2(8) not null,
  MTRL_CODE          VARCHAR2(20) not null,
  MTRL_SPEC          VARCHAR2(20) not null,
  UNITS              VARCHAR2(8),
  AMOUNT_PER_PACKAGE NUMBER(5) not null,
  PACKAGE_UNITS      VARCHAR2(8),
  UPPER_LEVEL        NUMBER(6),
  LOW_LEVEL          NUMBER(6),
  SUB_STORAGE        VARCHAR2(8)
)
;
alter table MED_MTRL_STORAGE_PROFILE
  add constraint PK_MTRL_STORAGE_PROFILE primary key (STORAGE_CODE, MTRL_CODE, MTRL_SPEC, AMOUNT_PER_PACKAGE);
grant select, insert, update, delete on MED_MTRL_STORAGE_PROFILE to ROLE_DOCARE;

prompt
prompt Creating table MED_MTRL_SUB_STORAGE_DICT
prompt ========================================
prompt
create table MED_MTRL_SUB_STORAGE_DICT
(
  STORAGE_CODE     VARCHAR2(10) not null,
  SUB_STORAGE      VARCHAR2(8) not null,
  IMPORT_NO_PREFIX VARCHAR2(6),
  IMPORT_NO_AVA    NUMBER(6),
  EXPORT_NO_PREFIX VARCHAR2(6),
  EXPORT_NO_AVA    NUMBER(6)
)
;
alter table MED_MTRL_SUB_STORAGE_DICT
  add constraint PK_MED_MTRL_SUB_STORAGE_DICT primary key (STORAGE_CODE, SUB_STORAGE);
grant select, insert, update, delete on MED_MTRL_SUB_STORAGE_DICT to ROLE_DOCARE;

prompt
prompt Creating table MED_MTRL_USE_DETAIL
prompt ==================================
prompt
create table MED_MTRL_USE_DETAIL
(
  USE_DATE      DATE not null,
  USE_NO        NUMBER(4) not null,
  ITEM_NO       NUMBER(3) not null,
  MTRL_CODE     VARCHAR2(16) not null,
  MTRL_SPEC     VARCHAR2(20) not null,
  MTRL_NAME     VARCHAR2(60),
  SUPPLIER_ID   VARCHAR2(16),
  BATCH_NO      VARCHAR2(16),
  PACKAGE_SPEC  VARCHAR2(20),
  PACKAGE_UNITS VARCHAR2(8),
  QUANTITY      NUMBER(6,2),
  COSTS         NUMBER(8,2),
  PAYMENTS      NUMBER(8,2),
  MTRL_NO 			VARCHAR2(40)
)
;
alter table MED_MTRL_USE_DETAIL
  add constraint PK_MED_MTRL_USE_DETAIL primary key (USE_DATE, USE_NO, ITEM_NO);
grant select, insert, update, delete on MED_MTRL_USE_DETAIL to ROLE_DOCARE;

-------------------------------------------
--  New table med_operation_after_order  --
-------------------------------------------
-- Create table
create table MED_OPERATION_AFTER_ORDER
(
  PATIENT_ID VARCHAR2(20) not null,
  VISIT_ID   NUMBER(2) not null,
  OPER_ID    NUMBER(2) not null,
  A01        VARCHAR2(60),
  A02        VARCHAR2(16),
  A03        VARCHAR2(16),
  A031       VARCHAR2(16),
  A04        VARCHAR2(16),
  A041       VARCHAR2(16),
  A05        VARCHAR2(16),
  A06        VARCHAR2(16),
  A07        VARCHAR2(32),
  A09        VARCHAR2(16),
  A10        VARCHAR2(200)
);
-- Add comments to the table 
comment on table MED_OPERATION_AFTER_ORDER
  is '术后医嘱';
-- Add comments to the columns 
comment on column MED_OPERATION_AFTER_ORDER.PATIENT_ID
  is '病人标识号;唯一确定手术病人，非空';
comment on column MED_OPERATION_AFTER_ORDER.VISIT_ID
  is '病人本次住院标识;对门诊病人为0';
comment on column MED_OPERATION_AFTER_ORDER.OPER_ID
  is '手术号;一个病人一次住院期间手术的标识，从1开始顺序排列。如果为门诊病人，则在VISIT_ID为0 的所有记录中顺序排列';
comment on column MED_OPERATION_AFTER_ORDER.A01
  is '麻醉方法 ';
comment on column MED_OPERATION_AFTER_ORDER.A02
  is '体位';
comment on column MED_OPERATION_AFTER_ORDER.A03
  is '测量血压、脉搏、呼吸频次';
comment on column MED_OPERATION_AFTER_ORDER.A031
  is '测量血压、脉搏、呼吸频次';
comment on column MED_OPERATION_AFTER_ORDER.A04
  is '给氧鼻导管';
comment on column MED_OPERATION_AFTER_ORDER.A041
  is '给氧面罩';
comment on column MED_OPERATION_AFTER_ORDER.A05
  is '吸痰';
comment on column MED_OPERATION_AFTER_ORDER.A06
  is '动静脉穿刺护理';
comment on column MED_OPERATION_AFTER_ORDER.A07
  is '机械通气';
comment on column MED_OPERATION_AFTER_ORDER.A09
  is '活动恢复情况';
comment on column MED_OPERATION_AFTER_ORDER.A10
  is '其它';
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_OPERATION_AFTER_ORDER
  add constraint PK_MED_OPERATION_AFTER_ORDER primary key (PATIENT_ID, VISIT_ID, OPER_ID);
grant select, insert, update, delete on MED_OPERATION_AFTER_ORDER to ROLE_DOCARE;


prompt
prompt Creating table MED_MTRL_USE_MASTER
prompt ==================================
prompt
create table MED_MTRL_USE_MASTER
(
  USE_DATE        DATE not null,
  USE_NO          NUMBER(4) not null,
  STORAGE_CODE    VARCHAR2(10) not null,
  PATIENT_ID      VARCHAR2(20),
  VISIT_ID        NUMBER(2),
  OPER_ID         NUMBER(2),
  COSTS           NUMBER(8,2),
  PAYMENTS        NUMBER(8,2),
  OPER_DOCTOR     VARCHAR2(8),
  ANES_DOCTOR     VARCHAR2(8),
  OPERATION_NURSE VARCHAR2(8),
  SUPPLY_NURSE    VARCHAR2(8)
)
;
alter table MED_MTRL_USE_MASTER
  add constraint PK_MED_MTRL_USE_MASTER primary key (USE_DATE, USE_NO);
grant select, insert, update, delete on MED_MTRL_USE_MASTER to ROLE_DOCARE;

prompt
prompt Creating table MED_OPERATING_ROOM
prompt =================================
prompt
create table MED_OPERATING_ROOM
(
  ROOM_NO      VARCHAR2(4) not null,
  DEPT_CODE    VARCHAR2(8) not null,
  LOCATION     VARCHAR2(20),
  STATUS       VARCHAR2(1),
  BED_ID       NUMBER(4),
  BED_LABEL    VARCHAR2(12),
  MONITOR_CODE VARCHAR2(5),
  BRANCH_NO    NUMBER(2),
  SAM_SPACE    NUMBER(4),
  PATIENT_ID   VARCHAR2(20),
  VISIT_ID     NUMBER(5),
  OPER_ID      NUMBER(2),
  BED_TYPE     VARCHAR2(1) default '0'
)
;
alter table MED_OPERATING_ROOM
  add constraint PK_MED_OPERATING_ROOM primary key (ROOM_NO, DEPT_CODE);
grant select, insert, update, delete on MED_OPERATING_ROOM to ROLE_DOCARE;

prompt
prompt Creating table MED_OPERATION_ANALGESIC
prompt ======================================
prompt
create table MED_OPERATION_ANALGESIC
(
  PATIENT_ID                    VARCHAR2(20) not null,
  VISIT_ID                      NUMBER(2) not null,
  OPER_ID                       NUMBER(2) not null,
  START_DATE_TIME               DATE,
  ANES_NO                       VARCHAR2(10),
  MACHINE_ID                    VARCHAR2(18),
  OTHER_ILLNESS                 VARCHAR2(40),
  ANALGESIC1                    VARCHAR2(40),
  ANALGESIC1_DOSAGE             NUMBER(8,4),
  ANALGESIC1_DOSAGE_UNITS       VARCHAR2(8),
  ANALGESIC2                    VARCHAR2(40),
  ANALGESIC2_DOSAGE             NUMBER(8,4),
  ANALGESIC2_DOSAGE_UNITS       VARCHAR2(8),
  ANALGESIC3                    VARCHAR2(40),
  ANALGESIC3_DOSAGE             NUMBER(8,4),
  ANALGESIC3_DOSAGE_UNITS       VARCHAR2(8),
  LAST_DRUG_DATE_TIME           DATE,
  ANALGESIC_METHOD              VARCHAR2(40),
  EXTRADURAL_CATHETER_LOCATION  VARCHAR2(16),
  INTRAVENOUS_CATHETER_LOCATION VARCHAR2(16),
  ANALGESIC_PUMPS_TYPE          VARCHAR2(16),
  DRUGA                         VARCHAR2(40),
  DRUGA_DOSAGE                  NUMBER(8,4),
  DRUGA_DOSAGE_UNITS            VARCHAR2(8),
  DRUGB                         VARCHAR2(40),
  DRUGB_DOSAGE                  NUMBER(8,4),
  DRUGB_DOSAGE_UNITS            VARCHAR2(8),
  DRUGC                         VARCHAR2(40),
  DRUGC_DOSAGE                  NUMBER(8,4),
  DRUGC_DOSAGE_UNITS            VARCHAR2(8),
  DRUGD                         VARCHAR2(40),
  DRUGD_DOSAGE                  NUMBER(8,4),
  DRUGD_DOSAGE_UNITS            VARCHAR2(8),
  DRUGE                         VARCHAR2(40),
  DRUGE_DOSAGE                  NUMBER(8,4),
  DRUGE_DOSAGE_UNITS            VARCHAR2(8),
  DRUGF                         VARCHAR2(40),
  DRUGF_DOSAGE                  NUMBER(8,4),
  DRUGF_DOSAGE_UNITS            VARCHAR2(8),
  TOTAL_CAPACITY                NUMBER(8,4),
  PCA_START                     DATE,
  PCA_STOP                      DATE,
  FIRST_DOSAGE                  NUMBER(8,4),
  DURATIVE_DOSAGE               NUMBER(8,4),
  PCA_DOSAGE                    NUMBER(8,4),
  LOCK_TIME                     NUMBER(3),
  SPO2_1                        NUMBER(3),
  CARDIOTACH_1                  NUMBER(3),
  BREATH_1                      NUMBER(2),
  VAS_SCORE_1                   NUMBER(2),
  CALMNESS_SCORE_1              NUMBER(1),
  SPORT_BLOCK_SCORE_1           NUMBER(1),
  NAUSEA_SCORE_1                NUMBER(1),
  VOMIT_SCORE_1                 NUMBER(1),
  EMICTION_RETENTION_SCORE_1    NUMBER(1),
  CATHETERIZATION_SCORE_1       NUMBER(1),
  OTHER_KICKBACK_1              VARCHAR2(20),
  PRESS1_1                      NUMBER(3),
  PRESS2_1                      NUMBER(3),
  DRUG_USED_1                   NUMBER(8,4),
  INQUIRY_DOCTOR_1              VARCHAR2(8),
  HOURS_AFTER_OPER              NUMBER(3),
  SPO2_2                        NUMBER(3),
  CARDIOTACH_2                  NUMBER(3),
  BREATH_2                      NUMBER(2),
  VAS_SCORE_2                   NUMBER(2),
  CALMNESS_SCORE_2              NUMBER(1),
  SPORT_BLOCK_SCORE_2           NUMBER(1),
  NAUSEA_SCORE_2                NUMBER(1),
  VOMIT_SCORE_2                 NUMBER(1),
  EMICTION_RETENTION_SCORE_2    NUMBER(1),
  CATHETERIZATION_SCORE_2       NUMBER(1),
  OTHER_KICKBACK_2              VARCHAR2(20),
  PRESS1_2                      NUMBER(3),
  PRESS2_2                      NUMBER(3),
  DRUG_USED_2                   NUMBER(8,4),
  INQUIRY_DOCTOR_2              VARCHAR2(8),
  SPO2_3                        NUMBER(3),
  CARDIOTACH_3                  NUMBER(3),
  BREATH_3                      NUMBER(2),
  VAS_SCORE_3                   NUMBER(2),
  CALMNESS_SCORE_3              NUMBER(1),
  SPORT_BLOCK_SCORE_3           NUMBER(1),
  NAUSEA_SCORE_3                NUMBER(1),
  VOMIT_SCORE_3                 NUMBER(1),
  EMICTION_RETENTION_SCORE_3    NUMBER(1),
  CATHETERIZATION_SCORE_3       NUMBER(1),
  OTHER_KICKBACK_3              VARCHAR2(20),
  PRESS1_3                      NUMBER(3),
  PRESS2_3                      NUMBER(3),
  DRUG_USED_3                   NUMBER(8,4),
  INQUIRY_DOCTOR_3              VARCHAR2(8),
  SPO2_4                        NUMBER(3),
  CARDIOTACH_4                  NUMBER(3),
  BREATH_4                      NUMBER(2),
  VAS_SCORE_4                   NUMBER(2),
  CALMNESS_SCORE_4              NUMBER(1),
  SPORT_BLOCK_SCORE_4           NUMBER(1),
  NAUSEA_SCORE_4                NUMBER(1),
  VOMIT_SCORE_4                 NUMBER(1),
  EMICTION_RETENTION_SCORE_4    NUMBER(1),
  CATHETERIZATION_SCORE_4       NUMBER(1),
  OTHER_KICKBACK_4              VARCHAR2(20),
  PRESS1_4                      NUMBER(3),
  PRESS2_4                      NUMBER(3),
  DRUG_USED_4                   NUMBER(8,4),
  INQUIRY_DOCTOR_4              VARCHAR2(8),
  SPO2_5                        NUMBER(3),
  CARDIOTACH_5                  NUMBER(3),
  BREATH_5                      NUMBER(2),
  VAS_SCORE_5                   NUMBER(2),
  CALMNESS_SCORE_5              NUMBER(1),
  SPORT_BLOCK_SCORE_5           NUMBER(1),
  NAUSEA_SCORE_5                NUMBER(1),
  VOMIT_SCORE_5                 NUMBER(1),
  EMICTION_RETENTION_SCORE_5    NUMBER(1),
  CATHETERIZATION_SCORE_5       NUMBER(1),
  OTHER_KICKBACK_5              VARCHAR2(20),
  PRESS1_5                      NUMBER(3),
  PRESS2_5                      NUMBER(3),
  DRUG_USED_5                   NUMBER(8,4),
  INQUIRY_DOCTOR_5              VARCHAR2(8),
  ANALGESIC_CATHETER            VARCHAR2(8),
  TOTAL_SATISFACTION            VARCHAR2(16),
  MEMO                          VARCHAR2(120),
  ENTER_DATE_TIME               DATE,
  ENTERED_BY                    VARCHAR2(8),
  ANALGESIC4                    VARCHAR2(40),
  ANALGESIC4_DOSAGE             NUMBER(8,4),
  ANALGESIC4_DOSAGE_UNITS       VARCHAR2(8),
  ANALGESIC5                    VARCHAR2(40),
  ANALGESIC5_DOSAGE             NUMBER(8,4),
  ANALGESIC5_DOSAGE_UNITS       VARCHAR2(8),
  ANALGESIC6                    VARCHAR2(40),
  ANALGESIC6_DOSAGE             NUMBER(8,4),
  ANALGESIC6_DOSAGE_UNITS       VARCHAR2(8),
  PLEXUS_CATHETER_LOCATION      VARCHAR2(16),
  DRUG_TOTAL_USED_1             NUMBER(8,4),
  PROBLEM_1                     VARCHAR2(30),
  HANDLE_1                      VARCHAR2(30),
  MEMO_1                        VARCHAR2(100),
  DRUG_TOTAL_USED_2             NUMBER(8,4),
  PROBLEM_2                     VARCHAR2(30),
  HANDLE_2                      VARCHAR2(30),
  MEMO_2                        VARCHAR2(100),
  DRUG_TOTAL_USED_3             NUMBER(8,4),
  PROBLEM_3                     VARCHAR2(30),
  HANDLE_3                      VARCHAR2(30),
  MEMO_3                        VARCHAR2(100),
  DRUG_TOTAL_USED_4             NUMBER(8,4),
  PROBLEM_4                     VARCHAR2(30),
  HANDLE_4                      VARCHAR2(30),
  MEMO_4                        VARCHAR2(100),
  DRUG_TOTAL_USED_5             NUMBER(8,4),
  PROBLEM_5                     VARCHAR2(30),
  HANDLE_5                      VARCHAR2(30),
  MEMO_5                        VARCHAR2(100),
  SPO2_6                        NUMBER(3),
  CARDIOTACH_6                  NUMBER(3),
  BREATH_6                      NUMBER(2),
  VAS_SCORE_6                   NUMBER(2),
  CALMNESS_SCORE_6              NUMBER(1),
  SPORT_BLOCK_SCORE_6           NUMBER(1),
  NAUSEA_SCORE_6                NUMBER(1),
  VOMIT_SCORE_6                 NUMBER(1),
  EMICTION_RETENTION_SCORE_6    NUMBER(1),
  CATHETERIZATION_SCORE_6       NUMBER(1),
  OTHER_KICKBACK_6              VARCHAR2(20),
  PRESS1_6                      NUMBER(3),
  PRESS2_6                      NUMBER(3),
  DRUG_USED_6                   NUMBER(8,4),
  INQUIRY_DOCTOR_6              VARCHAR2(8),
  DRUG_TOTAL_USED_6             NUMBER(8,4),
  PROBLEM_6                     VARCHAR2(30),
  HANDLE_6                      VARCHAR2(30),
  MEMO_6                        VARCHAR2(100),
  DISPENSER                     VARCHAR2(8),
  SECOND_DISPANSER              VARCHAR2(8)
)
;
alter table MED_OPERATION_ANALGESIC
  add constraint PK_MED_OPERATION_ANALGESIC primary key (PATIENT_ID, VISIT_ID, OPER_ID);
grant select, insert, update, delete on MED_OPERATION_ANALGESIC to ROLE_DOCARE;

prompt
prompt Creating table MED_OPERATION_BILL_ITEMS
prompt =======================================
prompt
create table MED_OPERATION_BILL_ITEMS
(
  PATIENT_ID         VARCHAR2(20) not null,
  VISIT_ID           NUMBER(2) not null,
  OPER_ID            NUMBER(2) not null,
  ITEM_NO            NUMBER(3) not null,
  ITEM_CLASS         VARCHAR2(16),
  ITEM_NAME          VARCHAR2(60),
  ITEM_CODE          VARCHAR2(10),
  ITEM_SPEC          VARCHAR2(20),
  AMOUNT             NUMBER(6,2),
  UNITS              VARCHAR2(8),
  ORDERED_BY         VARCHAR2(8),
  PERFORMED_BY       VARCHAR2(8),
  COSTS              NUMBER(8,2),
  CHARGES            NUMBER(8,2),
  NOTES              VARCHAR2(20),
  VERIFIED_INDICATOR NUMBER(1),
  ENTERED_BY         VARCHAR2(8),
  CLASS_ON_RECKONING VARCHAR2(3),
  INPBILL_ITEM_NO    NUMBER(6),
  EVENT_ITEM_NO      NUMBER(3),
  EXCHANGE_INDICATOR NUMBER(1) default 0,
  STORAGE_INDICATOR  NUMBER(1) default 0,
  BILL_ATTR          NUMBER(1),
  SUPPLIER_NAME      VARCHAR2(60),
  BILL_DATE         DATE,
	BILL_SORT 				NUMBER(3),
	EVENT_ITEM_CLASS 	VARCHAR2(16),
	EVENT_ITEM_NAME 	VARCHAR2(60),
	MTRL_NO 					VARCHAR2(40),
	SORT 							NUMBER(3),
	PRICE_MODIFY 			NUMBER(3)
)
;
alter table MED_OPERATION_BILL_ITEMS
  add constraint PK_MED_OPERATION_BILL_ITEMS primary key (PATIENT_ID, VISIT_ID, OPER_ID, ITEM_NO);
grant select, insert, update, delete on MED_OPERATION_BILL_ITEMS to ROLE_DOCARE;

prompt
prompt Creating table MED_OPERATION_CANCELED
prompt =====================================
prompt
create table MED_OPERATION_CANCELED
(
  PATIENT_ID            VARCHAR2(20) not null,
  VISIT_ID              NUMBER(2) not null,
  CANCEL_ID             NUMBER(2) not null,
  DEPT_STAYED           VARCHAR2(16),
  SCHEDULED_DATE_TIME   DATE,
  OPERATING_ROOM        VARCHAR2(16),
  OPERATING_ROOM_NO     VARCHAR2(8),
  SEQUENCE              NUMBER(2),
  DIAG_BEFORE_OPERATION VARCHAR2(80),
  PATIENT_CONDITION     VARCHAR2(100),
  OPERATION_SCALE       VARCHAR2(2),
  ISOLATION_INDICATOR   NUMBER(1),
  OPERATING_DEPT        VARCHAR2(16),
  SURGEON               VARCHAR2(20),
  FIRST_ASSISTANT       VARCHAR2(20),
  SECOND_ASSISTANT      VARCHAR2(20),
  THIRD_ASSISTANT       VARCHAR2(20),
  FOURTH_ASSISTANT      VARCHAR2(20),
  ANESTHESIA_METHOD     VARCHAR2(60),
  ANESTHESIA_DOCTOR     VARCHAR2(20),
  ANESTHESIA_ASSISTANT  VARCHAR2(20),
  BLOOD_TRAN_DOCTOR     VARCHAR2(20),
  NOTES_ON_OPERATION    VARCHAR2(100),
  ENTERED_BY            VARCHAR2(20),
  CANCEL_REASON         VARCHAR2(40),
  RESERVED1             VARCHAR2(10),
  OPERATION_ID          VARCHAR2(18),
  RESERVED2             VARCHAR2(20),
  RESERVED3             VARCHAR2(20),
  RESERVED4             VARCHAR2(20),
  RESERVED5             VARCHAR2(20),
  RESERVED6             VARCHAR2(20),
  RESERVED7             VARCHAR2(20),
  RESERVED8             VARCHAR2(20),
  RESERVED9             DATE,
  RESERVED10            DATE,
  RESERVED11            NUMBER(6),
  RESERVED12            NUMBER(6)
)
;
alter table MED_OPERATION_CANCELED
  add constraint PK_MED_OPERATION_CANCELED primary key (PATIENT_ID, VISIT_ID, CANCEL_ID);
grant select, insert, update, delete on MED_OPERATION_CANCELED to ROLE_DOCARE;

prompt
prompt Creating table MED_OPERATION_EQIP_DETAIL
prompt ========================================
prompt
create table MED_OPERATION_EQIP_DETAIL
(
  PATIENT_ID         VARCHAR2(20) not null,
  VISIT_ID           NUMBER(2) not null,
  OPER_ID            NUMBER(2) not null,
  ITEM_NO            NUMBER(3) not null,
  ITEM_NAME          VARCHAR2(40),
  ITEM_CLASS         VARCHAR2(1),
  ITEM_CODE          VARCHAR2(10),
  ITEM_SPEC          VARCHAR2(20),
  UNITS              VARCHAR2(10),
  AMOUNT             NUMBER(8,2),
  COSTS              NUMBER(8,2),
  ONE_INDICATOR      NUMBER(1),
  VERIFIED_INDICATOR NUMBER(1),
  OPERATOR           VARCHAR2(8),
  ENTER_DATE_TIME    DATE,
  AMOUNT2            NUMBER(8,2),
  AMOUNT3            NUMBER(8,2),
  MEMO               VARCHAR2(40),
  AMOUNT4 					NUMBER(8,2) 
)
;
alter table MED_OPERATION_EQIP_DETAIL
  add constraint PK_MED_OPERATION_EQIP_DETAIL primary key (PATIENT_ID, VISIT_ID, OPER_ID, ITEM_NO);
grant select, insert, update, delete on MED_OPERATION_EQIP_DETAIL to ROLE_DOCARE;

prompt
prompt Creating table MED_OPERATION_EQIP_TEMPLET
prompt =========================================
prompt
create table MED_OPERATION_EQIP_TEMPLET
(
  TEMPLET       VARCHAR2(40) not null,
  ITEM_NO       NUMBER(3) not null,
  ITEM_CLASS    VARCHAR2(1),
  ITEM_NAME     VARCHAR2(40),
  ITEM_CODE     VARCHAR2(10),
  ITEM_SPEC     VARCHAR2(20),
  UNITS         VARCHAR2(10),
  AMOUNT        NUMBER(8,2),
  COSTS         NUMBER(8,2),
  ONE_INDICATOR NUMBER(1),
  AMOUNT2 NUMBER(8,2),
  AMOUNT3 NUMBER(8,2)
)
;
alter table MED_OPERATION_EQIP_TEMPLET
  add constraint PK_MED_OPERATION_EQIP_TEMPLET primary key (TEMPLET, ITEM_NO);
grant select, insert, update, delete, alter on MED_OPERATION_EQIP_TEMPLET to ROLE_DOCARE;

prompt
prompt Creating table MED_OPERATION_MASTER
prompt ===================================
prompt
-- Create table
create table MED_OPERATION_MASTER
(
  PATIENT_ID                  VARCHAR2(20) not null,
  VISIT_ID                    NUMBER(2) not null,
  OPER_ID                     NUMBER(2) not null,
  DEPT_STAYED                 VARCHAR2(16),
  OPERATING_ROOM              VARCHAR2(16),
  OPERATING_ROOM_NO           VARCHAR2(8),
  DIAG_BEFORE_OPERATION       VARCHAR2(80),
  PATIENT_CONDITION           VARCHAR2(100),
  OPERATION_SCALE             VARCHAR2(2),
  DIAG_AFTER_OPERATION        VARCHAR2(80),
  EMERGENCY_INDICATOR         NUMBER(1),
  ISOLATION_INDICATOR         NUMBER(1),
  OPERATION_CLASS             VARCHAR2(1),
  OPERATING_DEPT              VARCHAR2(16),
  SURGEON                     VARCHAR2(20),
  FIRST_ASSISTANT             VARCHAR2(20),
  SECOND_ASSISTANT            VARCHAR2(20),
  THIRD_ASSISTANT             VARCHAR2(20),
  FOURTH_ASSISTANT            VARCHAR2(20),
  ANESTHESIA_METHOD           VARCHAR2(60),
  ANESTHESIA_DOCTOR           VARCHAR2(20),
  ANESTHESIA_ASSISTANT        VARCHAR2(20),
  BLOOD_TRAN_DOCTOR           VARCHAR2(20),
  FIRST_OPERATION_NURSE       VARCHAR2(20),
  SECOND_OPERATION_NURSE      VARCHAR2(20),
  FIRST_SUPPLY_NURSE          VARCHAR2(20),
  SECOND_SUPPLY_NURSE         VARCHAR2(20),
  NURSE_SHIFT_INDICATOR       NUMBER(1),
  START_DATE_TIME             DATE,
  END_DATE_TIME               DATE,
  SATISFACTION_DEGREE         NUMBER(1),
  SMOOTH_INDICATOR            NUMBER(1),
  IN_FLUIDS_AMOUNT            NUMBER(6),
  OUT_FLUIDS_AMOUNT           NUMBER(6),
  BLOOD_LOSSED                NUMBER(6),
  BLOOD_TRANSFERED            NUMBER(6),
  ENTERED_BY                  VARCHAR2(20),
  THIRD_SUPPLY_NURSE          VARCHAR2(20),
  ORDER_TRANSFER              NUMBER(1),
  CHARGE_TRANSFER             NUMBER(1),
  END_INDICATOR               NUMBER(1),
  RECK_GROUP                  VARCHAR2(8),
  OPER_STATUS                 NUMBER(1) default 0,
  SECOND_ANESTHESIA_ASSISTANT VARCHAR2(20),
  THIRD_ANESTHESIA_ASSISTANT  VARCHAR2(20),
  FOURTH_ANESTHESIA_ASSISTANT VARCHAR2(20),
  OPERATION_POSITION          VARCHAR2(40),
  OPERATION_EQUIP_INDICATOR   NUMBER(1),
  SECOND_ANESTHESIA_DOCTOR    VARCHAR2(20),
  THIRD_ANESTHESIA_DOCTOR     VARCHAR2(20),
  OTHER_IN_AMOUNT             NUMBER(6),
  OTHER_OUT_AMOUNT            NUMBER(6),
  IN_DATE_TIME                DATE,
  OUT_DATE_TIME               DATE,
  RESERVED1                   VARCHAR2(20),
  BLOOD_WHOLE_SELF            NUMBER(6),
  BLOOD_WHOLE                 NUMBER(6),
  BLOOD_RBC                   NUMBER(6),
  BLOOD_PLASM                 NUMBER(6),
  BLOOD_OTHER                 NUMBER(6),
  RESERVED2                   VARCHAR2(20),
  SPECIAL_EQUIPMENT           VARCHAR2(40),
  SPECIAL_INFECT              VARCHAR2(40),
  HEPATITIS_INDICATOR         NUMBER(1),
  ANES_START_DATE_TIME        DATE,
  RETURN_DATE_TIME            DATE,
  SEQUENCE                    NUMBER(2),
  IN_PACU_DATE_TIME           DATE,
  OUT_PACU_DATE_TIME          DATE,
  OPERATION_ID                VARCHAR2(18),
  RESERVED3                   VARCHAR2(20),
  RESERVED4                   VARCHAR2(20),
  RESERVED5                   VARCHAR2(20),
  RESERVED6                   VARCHAR2(20),
  RESERVED7                   VARCHAR2(20),
  RESERVED8                   VARCHAR2(20),
  RESERVED9                   DATE,
  RESERVED10                  DATE,
  RESERVED11                  NUMBER(6),
  RESERVED12                  NUMBER(6),
  BLOOD_REUSE                 NUMBER(6),
  SELF_BLOOD                  NUMBER(6),
  ENTERED_DATETIME            DATE,
  MEMO                        VARCHAR2(100),
  ANESTHESIA_ID               VARCHAR2(20),
  XJ                          NUMBER(3),
  AI                          NUMBER(1),
  AT                          NUMBER(3),
  JT                          NUMBER(3),
  BODY_AREA                   VARCHAR2(10),
  GAS_PIPE                    VARCHAR2(60),
  PAT_LEAVE_SHOW              VARCHAR2(20),
  WHOLE_ANES                  VARCHAR2(30),
  STOP_ANES_AREA              VARCHAR2(30),
  STOP_ANES_AREA_MED          VARCHAR2(200),
  HOLE_PIPLE_ANES             VARCHAR2(30),
  STOP_ANES_AREA_TECH         VARCHAR2(40),
  PIN_SIZE                    VARCHAR2(10),
  PIPLE_UP                    VARCHAR2(10),
  PIPLE_DOWN                  VARCHAR2(10),
  IRRITATE_NERVE              VARCHAR2(20),
  ANES_RANGE                  VARCHAR2(20),
  BAK_MED                     VARCHAR2(200),
  WATCH_ANES                  VARCHAR2(60),
  ALL_ANES_MED_LEAD1          VARCHAR2(200),
  ALL_ANES_MED_LEAD2          VARCHAR2(200),
  ALL_ANES_MED_KEEP1          VARCHAR2(200),
  ALL_ANES_MED_KEEP2          VARCHAR2(200),
  CHEST_WATER                 VARCHAR2(10),
  ABDOMEN_WATER               VARCHAR2(10),
  INQUIRY_BEFORE_DATE         DATE,
  INQUIRY_AFTER_DATE          DATE,
  THIRD_OPERATION_NURSE       VARCHAR2(8),
  PACU_DOCTOR                 VARCHAR2(20),
  WATER_JT1                   NUMBER(6),
  WATER_JT2                   NUMBER(6),
  BLOOD_XB                    NUMBER(6),
  COOL_THING                  NUMBER(6),
  CRY_WATHER                  NUMBER(6),
  RED_BLOOD                   NUMBER(6),
  BLOOD_AMOUNT                NUMBER(6)
);
-- Add comments to the table 
comment on table MED_OPERATION_MASTER
  is '病人手术主记录';
-- Add comments to the columns 
comment on column MED_OPERATION_MASTER.PATIENT_ID
  is '病人标识;非空，唯一确定手术病人（门急诊病人没有主索引记录的，由O+YYMMDD+流水号作为病人ID）';
comment on column MED_OPERATION_MASTER.VISIT_ID
  is '本次住院标识;对门诊病人为0';
comment on column MED_OPERATION_MASTER.OPER_ID
  is '手术号;一个病人一次住院期间手术的标识，从1开始顺序排列。如果为门诊病人，则在VISIT_ID为0 的所有记录中顺序排列';
comment on column MED_OPERATION_MASTER.DEPT_STAYED
  is '病人所在科室;病人所在科室，即申请科室 ';
comment on column MED_OPERATION_MASTER.OPERATING_ROOM
  is '手术室;手术室科室代码';
comment on column MED_OPERATION_MASTER.OPERATING_ROOM_NO
  is '手术间;手术间号，见手术间床位字典  OPERATING_BED_DICT字典';
comment on column MED_OPERATION_MASTER.DIAG_BEFORE_OPERATION
  is '术前主要诊断;病人手术前的诊断描述';
comment on column MED_OPERATION_MASTER.PATIENT_CONDITION
  is '病情说明';
comment on column MED_OPERATION_MASTER.OPERATION_SCALE
  is '手术等级;指一次手术的综合等级。取值：特、大、中、小';
comment on column MED_OPERATION_MASTER.DIAG_AFTER_OPERATION
  is '术后诊断;病人手术后的诊断描述';
comment on column MED_OPERATION_MASTER.EMERGENCY_INDICATOR
  is '急诊标志;0-择期 1-急诊';
comment on column MED_OPERATION_MASTER.ISOLATION_INDICATOR
  is '隔离标志;指手术是否需要隔离，1-正常 2-隔离 3-放射';
comment on column MED_OPERATION_MASTER.OPERATION_CLASS
  is '手术类型;1-一般手术 2-急抢救手术 3-术中急抢救';
comment on column MED_OPERATION_MASTER.OPERATING_DEPT
  is '手术科室;实施手术的科室代码';
comment on column MED_OPERATION_MASTER.SURGEON
  is '手术者;手术医师姓名';
comment on column MED_OPERATION_MASTER.FIRST_ASSISTANT
  is '第一手术助手;第一手术助手姓名';
comment on column MED_OPERATION_MASTER.SECOND_ASSISTANT
  is '第二手术助手;第二手术助手姓名';
comment on column MED_OPERATION_MASTER.THIRD_ASSISTANT
  is '第三手术助手;第三手术助手姓名';
comment on column MED_OPERATION_MASTER.FOURTH_ASSISTANT
  is '第四手术助手;第四手术助手姓名';
comment on column MED_OPERATION_MASTER.ANESTHESIA_METHOD
  is '麻醉方法';
comment on column MED_OPERATION_MASTER.ANESTHESIA_DOCTOR
  is '麻醉医师;麻醉医师姓名';
comment on column MED_OPERATION_MASTER.ANESTHESIA_ASSISTANT
  is '麻醉助手;麻醉助手姓名';
comment on column MED_OPERATION_MASTER.BLOOD_TRAN_DOCTOR
  is '输血者;输血医师姓名';
comment on column MED_OPERATION_MASTER.FIRST_OPERATION_NURSE
  is '第一台上护士;护士姓名';
comment on column MED_OPERATION_MASTER.SECOND_OPERATION_NURSE
  is '第二台上护士;护士姓名';
comment on column MED_OPERATION_MASTER.FIRST_SUPPLY_NURSE
  is '第一供应护士;护士姓名';
comment on column MED_OPERATION_MASTER.SECOND_SUPPLY_NURSE
  is '第二供应护士;护士姓名';
comment on column MED_OPERATION_MASTER.NURSE_SHIFT_INDICATOR
  is '手术护士换班标志;0-未换班 1-换班';
comment on column MED_OPERATION_MASTER.START_DATE_TIME
  is '手术开始日期及时间';
comment on column MED_OPERATION_MASTER.END_DATE_TIME
  is '手术结束日期及时间';
comment on column MED_OPERATION_MASTER.SATISFACTION_DEGREE
  is '麻醉满意程度;1-满意 2-不全满意 3-改麻醉';
comment on column MED_OPERATION_MASTER.SMOOTH_INDICATOR
  is '手术过程顺利标志;1-顺利 0-不顺利';
comment on column MED_OPERATION_MASTER.IN_FLUIDS_AMOUNT
  is '输液量;此处含义重新界定，原来指总入量，单位：毫升';
comment on column MED_OPERATION_MASTER.OUT_FLUIDS_AMOUNT
  is '尿量;此处含义重新界定，原来指总出量，单位：毫升';
comment on column MED_OPERATION_MASTER.BLOOD_LOSSED
  is '失血量;术中失血量，单位：毫升';
comment on column MED_OPERATION_MASTER.BLOOD_TRANSFERED
  is '输血量;术中输血量，单位：毫升';
comment on column MED_OPERATION_MASTER.ENTERED_BY
  is '录入者';
comment on column MED_OPERATION_MASTER.THIRD_SUPPLY_NURSE
  is '第三供应护士';
comment on column MED_OPERATION_MASTER.ORDER_TRANSFER
  is '医嘱提交';
comment on column MED_OPERATION_MASTER.CHARGE_TRANSFER
  is '费用提交';
comment on column MED_OPERATION_MASTER.END_INDICATOR
  is '完成标识;1-手术登记完成，完成后不允许再修改';
comment on column MED_OPERATION_MASTER.OPER_STATUS
  is '手术状态;0-新申请，1-已安排，2-术中，3-PACU，4-术后，5-已提交';
comment on column MED_OPERATION_MASTER.SECOND_ANESTHESIA_ASSISTANT
  is '麻醉助手2;目前解释为灌注医生1';
comment on column MED_OPERATION_MASTER.THIRD_ANESTHESIA_ASSISTANT
  is '麻醉助手3;目前解释为灌注医生1';
comment on column MED_OPERATION_MASTER.FOURTH_ANESTHESIA_ASSISTANT
  is '麻醉助手4;目前未使用';
comment on column MED_OPERATION_MASTER.OPERATION_POSITION
  is '手术体位';
comment on column MED_OPERATION_MASTER.OPERATION_EQUIP_INDICATOR
  is '器械清点结果;0-对数，1-不对数';
comment on column MED_OPERATION_MASTER.SECOND_ANESTHESIA_DOCTOR
  is '麻醉医生2';
comment on column MED_OPERATION_MASTER.THIRD_ANESTHESIA_DOCTOR
  is '麻醉医生3';
comment on column MED_OPERATION_MASTER.OTHER_IN_AMOUNT
  is '其它入量;术中其它入量，单位：毫升';
comment on column MED_OPERATION_MASTER.OTHER_OUT_AMOUNT
  is '其它出量;术中其它出量，单位：毫升';
comment on column MED_OPERATION_MASTER.IN_DATE_TIME
  is '进入手术室日期及时间';
comment on column MED_OPERATION_MASTER.OUT_DATE_TIME
  is '离开手术室日期及时间';
comment on column MED_OPERATION_MASTER.SEQUENCE
  is '台次;目前没有使用';
comment on column MED_OPERATION_MASTER.IN_PACU_DATE_TIME
  is '进入PACU日期及时间';
comment on column MED_OPERATION_MASTER.OUT_PACU_DATE_TIME
  is '离开PACU日期及时间';
comment on column MED_OPERATION_MASTER.MEMO
  is '备注';
comment on column MED_OPERATION_MASTER.ANESTHESIA_ID
  is '麻醉单编号';
comment on column MED_OPERATION_MASTER.BODY_AREA
  is '体表面积(天总)';
comment on column MED_OPERATION_MASTER.GAS_PIPE
  is '气道与通气 (天总)';
comment on column MED_OPERATION_MASTER.PAT_LEAVE_SHOW
  is '病人离开的术室情况(天总)';
comment on column MED_OPERATION_MASTER.WHOLE_ANES
  is '全麻(天总)';
comment on column MED_OPERATION_MASTER.STOP_ANES_AREA
  is '区域阻断(天总)';
comment on column MED_OPERATION_MASTER.STOP_ANES_AREA_MED
  is '阻断药物(天总)';
comment on column MED_OPERATION_MASTER.HOLE_PIPLE_ANES
  is '椎管内(天总)';
comment on column MED_OPERATION_MASTER.STOP_ANES_AREA_TECH
  is '阻断技术(天总)';
comment on column MED_OPERATION_MASTER.PIN_SIZE
  is '针号(天总)';
comment on column MED_OPERATION_MASTER.PIPLE_UP
  is '置管上(天总)';
comment on column MED_OPERATION_MASTER.PIPLE_DOWN
  is '置管下(天总)';
comment on column MED_OPERATION_MASTER.IRRITATE_NERVE
  is '刺激神经(天总)';
comment on column MED_OPERATION_MASTER.ANES_RANGE
  is '麻醉范围(天总)';
comment on column MED_OPERATION_MASTER.BAK_MED
  is '备用药物(天总)';
comment on column MED_OPERATION_MASTER.WATCH_ANES
  is '全麻监测(天总)';
comment on column MED_OPERATION_MASTER.ALL_ANES_MED_LEAD1
  is '全麻诱导药物静脉(天总)';
comment on column MED_OPERATION_MASTER.ALL_ANES_MED_LEAD2
  is '全麻诱导药物吸入(天总)';
comment on column MED_OPERATION_MASTER.ALL_ANES_MED_KEEP1
  is '全麻维持药物静脉(天总)';
comment on column MED_OPERATION_MASTER.ALL_ANES_MED_KEEP2
  is '全麻维持药物吸入(天总)';
comment on column MED_OPERATION_MASTER.CHEST_WATER
  is '胸水(天总)';
comment on column MED_OPERATION_MASTER.ABDOMEN_WATER
  is '腹水(天总)';
comment on column MED_OPERATION_MASTER.INQUIRY_BEFORE_DATE
  is '术前访视日期';
comment on column MED_OPERATION_MASTER.INQUIRY_AFTER_DATE
  is '术后随访日期';
comment on column MED_OPERATION_MASTER.PACU_DOCTOR
  is '烟台毓璜顶医院PACU医生';
comment on column MED_OPERATION_MASTER.WATER_JT1
  is '安阳 胶体液';
comment on column MED_OPERATION_MASTER.WATER_JT2
  is '安阳 晶体液';
comment on column MED_OPERATION_MASTER.BLOOD_XB
  is '安阳 血小板';
comment on column MED_OPERATION_MASTER.COOL_THING
  is '安阳 冷沉淀';
comment on column MED_OPERATION_MASTER.CRY_WATHER
  is '安阳 自体回输';
comment on column MED_OPERATION_MASTER.RED_BLOOD
  is '安阳 悬浮红细胞';
comment on column MED_OPERATION_MASTER.BLOOD_AMOUNT
  is '安阳 血浆';

alter table MED_OPERATION_MASTER
  add constraint PK_MED_OPERATION_MASTER primary key (PATIENT_ID, VISIT_ID, OPER_ID);
create index IND_MED_OPERATION_MASTER_1 on MED_OPERATION_MASTER (START_DATE_TIME);
grant select, insert, update, delete on MED_OPERATION_MASTER to ROLE_DOCARE;
grant select, insert, update, delete, references, alter, index on MED_OPERATION_MASTER to MEDCOMM with grant option;


prompt
prompt Creating table MED_OPERATION_NAME
prompt =================================
prompt
create table MED_OPERATION_NAME
(
  PATIENT_ID      VARCHAR2(20) not null,
  VISIT_ID        NUMBER(2) not null,
  OPER_ID         NUMBER(2) not null,
  OPERATION_NO    NUMBER(2) not null,
  OPERATION       VARCHAR2(100),
  OPERATION_CODE  VARCHAR2(8),
  OPERATION_SCALE VARCHAR2(2),
  WOUND_GRADE     VARCHAR2(2),
  RESERVED1       VARCHAR2(20),
  RESERVED2       VARCHAR2(20),
  RESERVED3       VARCHAR2(20),
  RESERVED4       VARCHAR2(20),
  RESERVED5       NUMBER(6)
)
;
alter table MED_OPERATION_NAME
  add constraint PK_MED_OPERATION_NAME primary key (PATIENT_ID, VISIT_ID, OPER_ID, OPERATION_NO);
grant select, insert, update, delete on MED_OPERATION_NAME to ROLE_DOCARE;
grant select, insert, update, delete, references, alter, index on MED_OPERATION_NAME to MEDCOMM with grant option;
prompt
prompt Creating table MED_OPERATION_NAME_CANCELED
prompt ==========================================
prompt
create table MED_OPERATION_NAME_CANCELED
(
  PATIENT_ID      VARCHAR2(20) not null,
  VISIT_ID        NUMBER(2) not null,
  CANCEL_ID       NUMBER(2) not null,
  OPERATION_NO    NUMBER(2) not null,
  OPERATION       VARCHAR2(100),
  OPERATION_SCALE VARCHAR2(2),
  OPERATION_CODE  VARCHAR2(8),
  RESERVED1       VARCHAR2(20),
  RESERVED2       VARCHAR2(20),
  RESERVED3       VARCHAR2(20),
  RESERVED4       VARCHAR2(20),
  RESERVED5       NUMBER(6)
)
;
alter table MED_OPERATION_NAME_CANCELED
  add constraint PK_MED_OPERATION_NAME_CANCELED primary key (PATIENT_ID, VISIT_ID, CANCEL_ID, OPERATION_NO);
grant select, insert, update, delete on MED_OPERATION_NAME_CANCELED to ROLE_DOCARE;

prompt
prompt Creating table MED_OPERATION_NURSE_SHIFT
prompt ========================================
prompt
create table MED_OPERATION_NURSE_SHIFT
(
  PATIENT_ID             VARCHAR2(20) not null,
  VISIT_ID               NUMBER(2) not null,
  OPER_ID                NUMBER(2) not null,
  SHIFT_DATE_TIME        DATE not null,
  FIRST_OPERATION_NURSE  VARCHAR2(8),
  SECOND_OPERATION_NURSE VARCHAR2(8),
  FIRST_SUPPLY_NURSE     VARCHAR2(8),
  SECOND_SUPPLY_NURSE    VARCHAR2(8),
  THIRD_SUPPLY_NURSE     VARCHAR2(8)
)
;
alter table MED_OPERATION_NURSE_SHIFT
  add constraint PK_MED_OPERATION_NURSE_SHIFT primary key (PATIENT_ID, VISIT_ID, OPER_ID, SHIFT_DATE_TIME);
grant select, insert, update, delete on MED_OPERATION_NURSE_SHIFT to ROLE_DOCARE;

prompt
prompt Creating table MED_OPERATION_SCHEDULE
prompt =====================================
prompt
create table MED_OPERATION_SCHEDULE
(
  PATIENT_ID                  VARCHAR2(20) not null,
  VISIT_ID                    NUMBER(2) not null,
  SCHEDULE_ID                 NUMBER(2) not null,
  DEPT_STAYED                 VARCHAR2(16),
  BED_NO                      VARCHAR2(20),
  SCHEDULED_DATE_TIME         DATE,
  OPERATING_ROOM              VARCHAR2(16),
  OPERATING_ROOM_NO           VARCHAR2(8),
  SEQUENCE                    NUMBER(2),
  DIAG_BEFORE_OPERATION       VARCHAR2(80),
  PATIENT_CONDITION           VARCHAR2(100),
  OPERATION_SCALE             VARCHAR2(2),
  ISOLATION_INDICATOR         NUMBER(1),
  OPERATING_DEPT              VARCHAR2(16),
  SURGEON                     VARCHAR2(20),
  FIRST_ASSISTANT             VARCHAR2(20),
  SECOND_ASSISTANT            VARCHAR2(20),
  THIRD_ASSISTANT             VARCHAR2(20),
  FOURTH_ASSISTANT            VARCHAR2(20),
  ANESTHESIA_METHOD           VARCHAR2(60),
  ANESTHESIA_DOCTOR           VARCHAR2(20),
  ANESTHESIA_ASSISTANT        VARCHAR2(20),
  BLOOD_TRAN_DOCTOR           VARCHAR2(20),
  FIRST_OPERATION_NURSE       VARCHAR2(20),
  SECOND_OPERATION_NURSE      VARCHAR2(20),
  FIRST_SUPPLY_NURSE          VARCHAR2(20),
  SECOND_SUPPLY_NURSE         VARCHAR2(20),
  NOTES_ON_OPERATION          VARCHAR2(100),
  ENTERED_BY                  VARCHAR2(20),
  REQ_DATE_TIME               DATE,
  THIRD_SUPPLY_NURSE          VARCHAR2(20),
  ACK_INDICATOR               NUMBER(1),
  EMERGENCY_INDICATOR         NUMBER(1) default 0,
  RECK_GROUP                  VARCHAR2(8),
  OPER_ID                     NUMBER(2),
  SECOND_ANESTHESIA_ASSISTANT VARCHAR2(20),
  THIRD_ANESTHESIA_ASSISTANT  VARCHAR2(20),
  FOURTH_ANESTHESIA_ASSISTANT VARCHAR2(20),
  SECOND_ANESTHESIA_DOCTOR    VARCHAR2(20),
  THIRD_ANESTHESIA_DOCTOR     VARCHAR2(20),
  RESERVED1                   VARCHAR2(10),
  RESERVED2                   VARCHAR2(10),
  OPERATION_POSITION          VARCHAR2(32),
  SPECIAL_EQUIPMENT           VARCHAR2(40),
  SPECIAL_INFECT              VARCHAR2(40),
  HEPATITIS_INDICATOR         NUMBER(1),
  OPERATION_ID                VARCHAR2(18),
  RESERVED3                   VARCHAR2(100),
  RESERVED4                   VARCHAR2(20),
  RESERVED5                   VARCHAR2(20),
  RESERVED6                   VARCHAR2(20),
  RESERVED7                   VARCHAR2(20),
  RESERVED8                   VARCHAR2(20),
  RESERVED9                   DATE,
  RESERVED10                  DATE,
  RESERVED11                  NUMBER(6),
  RESERVED12                  NUMBER(6),
  THIRD_OPERATION_NURSE 			VARCHAR2(8)
)
;
alter table MED_OPERATION_SCHEDULE
  add constraint PK_MED_OPERATION_SCHEDULE primary key (PATIENT_ID, VISIT_ID, SCHEDULE_ID);
grant select, insert, update, delete on MED_OPERATION_SCHEDULE to ROLE_DOCARE;
grant select, insert, update, delete, references, alter, index on MED_OPERATION_SCHEDULE to medcomm with grant option;

-----------------------------------------
--  New table med_oper_sched_template  --
-----------------------------------------
-- Create table
create table MED_OPER_SCHED_TEMPLATE
(
  SERIAL_NO                   NUMBER(6) not null,
  DEPT_CODE                   VARCHAR2(8) not null,
  TEMPLATE_NAME               VARCHAR2(64),
  ANESTHESIA_DOCTOR           VARCHAR2(8),
  SECOND_ANESTHESIA_DOCTOR    VARCHAR2(8),
  THIRD_ANESTHESIA_DOCTOR     VARCHAR2(8),
  ANESTHESIA_ASSISTANT        VARCHAR2(8),
  SECOND_ANESTHESIA_ASSISTANT VARCHAR2(8),
  THIRD_ANESTHESIA_ASSISTANT  VARCHAR2(8),
  FOURTH_ANESTHESIA_ASSISTANT VARCHAR2(8),
  BLOOD_TRAN_DOCTOR           VARCHAR2(8),
  FIRST_OPERATION_NURSE       VARCHAR2(8),
  SECOND_OPERATION_NURSE      VARCHAR2(8),
  FIRST_SUPPLY_NURSE          VARCHAR2(8),
  SECOND_SUPPLY_NURSE         VARCHAR2(8),
  THIRD_SUPPLY_NURSE          VARCHAR2(8),
  SURGEON                     VARCHAR2(8),
  FIRST_ASSISTANT             VARCHAR2(8),
  SECOND_ASSISTANT            VARCHAR2(8),
  THIRD_ASSISTANT             VARCHAR2(8),
  FOURTH_ASSISTANT            VARCHAR2(8),
  ROOM_NO                     VARCHAR2(4)
);
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_OPER_SCHED_TEMPLATE
  add constraint PK_MOST primary key (SERIAL_NO);
grant select, insert, update, delete on MED_OPER_SCHED_TEMPLATE to ROLE_DOCARE;
prompt
prompt Creating table MED_OPERATION_SHIFT
prompt ==================================
prompt
create table MED_OPERATION_SHIFT
(
  PATIENT_ID VARCHAR2(20) not null,
  VISIT_ID   NUMBER(2) not null,
  OPER_ID    NUMBER(2) not null,
  DUTY       VARCHAR2(10),
  MEMO       VARCHAR2(20),
  PERSON     VARCHAR2(8),
  WORK_BEGIN DATE,
  WORK_END   DATE
)
;
grant select, insert, update, delete on MED_OPERATION_SHIFT to ROLE_DOCARE;

prompt
prompt Creating table MED_OPER_ANALGESIC_TEMPLET
prompt =========================================
prompt
create table MED_OPER_ANALGESIC_TEMPLET
(
  TEMPLET_NAME                  VARCHAR2(40) not null,
  ANALGESIC1                    VARCHAR2(40),
  ANALGESIC1_DOSAGE             NUMBER(8,4),
  ANALGESIC1_DOSAGE_UNITS       VARCHAR2(8),
  ANALGESIC2                    VARCHAR2(40),
  ANALGESIC2_DOSAGE             NUMBER(8,4),
  ANALGESIC2_DOSAGE_UNITS       VARCHAR2(8),
  ANALGESIC3                    VARCHAR2(40),
  ANALGESIC3_DOSAGE             NUMBER(8,4),
  ANALGESIC3_DOSAGE_UNITS       VARCHAR2(8),
  ANALGESIC_METHOD              VARCHAR2(40),
  EXTRADURAL_CATHETER_LOCATION  VARCHAR2(4),
  INTRAVENOUS_CATHETER_LOCATION VARCHAR2(4),
  ANALGESIC_PUMPS_TYPE          VARCHAR2(16),
  DRUGA                         VARCHAR2(40),
  DRUGA_DOSAGE                  NUMBER(8,4),
  DRUGA_DOSAGE_UNITS            VARCHAR2(8),
  DRUGB                         VARCHAR2(40),
  DRUGB_DOSAGE                  NUMBER(8,4),
  DRUGB_DOSAGE_UNITS            VARCHAR2(8),
  DRUGC                         VARCHAR2(40),
  DRUGC_DOSAGE                  NUMBER(8,4),
  DRUGC_DOSAGE_UNITS            VARCHAR2(8),
  DRUGD                         VARCHAR2(40),
  DRUGD_DOSAGE                  NUMBER(8,4),
  DRUGD_DOSAGE_UNITS            VARCHAR2(8),
  DRUGE                         VARCHAR2(40),
  DRUGE_DOSAGE                  NUMBER(8,4),
  DRUGE_DOSAGE_UNITS            VARCHAR2(8),
  DRUGF                         VARCHAR2(40),
  DRUGF_DOSAGE                  NUMBER(8,4),
  DRUGF_DOSAGE_UNITS            VARCHAR2(8),
  TOTAL_CAPACITY                NUMBER(8,4),
  FIRST_DOSAGE                  NUMBER(8,4),
  DURATIVE_DOSAGE               NUMBER(8,4),
  PCA_DOSAGE                    NUMBER(8,4),
  LOCK_TIME                     NUMBER(3),
  ANALGESIC4                    VARCHAR2(40),
  ANALGESIC4_DOSAGE             NUMBER(8,4),
  ANALGESIC4_DOSAGE_UNITS       VARCHAR2(8),
  ANALGESIC5                    VARCHAR2(40),
  ANALGESIC5_DOSAGE             NUMBER(8,4),
  ANALGESIC5_DOSAGE_UNITS       VARCHAR2(8),
  ANALGESIC6                    VARCHAR2(40),
  ANALGESIC6_DOSAGE             NUMBER(8,4),
  ANALGESIC6_DOSAGE_UNITS       VARCHAR2(8)
)
;
alter table MED_OPER_ANALGESIC_TEMPLET
  add constraint PK_MED_OPER_ANALGESIC_TEMPLET primary key (TEMPLET_NAME);
grant select, insert, update, delete on MED_OPER_ANALGESIC_TEMPLET to ROLE_DOCARE;

prompt
prompt Creating table MED_OPER_BILL_TEMPLET
prompt ====================================
prompt
create table MED_OPER_BILL_TEMPLET
(
  TEMPLET    VARCHAR2(10) not null,
  ITEM_NO    NUMBER(3) not null,
  ITEM_CLASS VARCHAR2(1),
  ITEM_CODE  VARCHAR2(10),
  ITEM_NAME  VARCHAR2(40),
  ITEM_SPEC  VARCHAR2(20),
  UNITS      VARCHAR2(8),
  AMOUNT     NUMBER(6,2),
  COSTS      NUMBER(8,2)
)
;
alter table MED_OPER_BILL_TEMPLET
  add constraint PK_MED_OPER_BILL_TEMPLET primary key (TEMPLET, ITEM_NO);
grant select, insert, update, delete on MED_OPER_BILL_TEMPLET to ROLE_DOCARE;

prompt
prompt Creating table MED_ANES_RECOVERY_TEMPLATE
prompt ====================================
prompt
create table MED_ANES_RECOVERY_TEMPLATE                          
(
	TEMPLATE VARCHAR2(40),                                                     
	FS1      VARCHAR2(50),                                                      
	FS2      VARCHAR2(50),                                                      
	FS3      VARCHAR2(50),                                                      
	FS4      VARCHAR2(50),                                                      
	FS5      VARCHAR2(50),                                                      
	FS6      VARCHAR2(50),                                                      
	FS7      VARCHAR2(50),                                                      
	FS8      VARCHAR2(50),                                                      
	FS9      VARCHAR2(50),                                                      
	FS10      VARCHAR2(50),                                                     
	FS11      VARCHAR2(50),                                                     
	FS12      VARCHAR2(50),                                                     
	FS13      VARCHAR2(50),                                                     
	FS14      VARCHAR2(50),                                                     
	FS15      VARCHAR2(50),                                                     
	FS16      VARCHAR2(50),                                                     
	FS17      VARCHAR2(50),                                                     
	FS18      VARCHAR2(50),                                                     
	FS19      VARCHAR2(50),                                                     
	FS20      VARCHAR2(50),                                                     
	FS21      VARCHAR2(50),                                                     
	FS22      VARCHAR2(50),                                                     
	FS23      VARCHAR2(50),                                                     
	FS24      VARCHAR2(50),                                                     
	FS25      VARCHAR2(50),                                                     
	FS26      VARCHAR2(50),                                                     
	FS27      VARCHAR2(50),                                                     
	FS28      VARCHAR2(50),                                                     
	FS29      VARCHAR2(50),                                                     
	FS30      VARCHAR2(50),                                                     
	NOTE      VARCHAR2(200)                                                     
);                                                                          
alter table MED_ANES_RECOVERY_TEMPLATE                           
add constraint PK_MED_ANES_RECOVERY_TEMPLATE primary key (TEMPLATE); 

grant select, insert, update, delete on MED_ANES_RECOVERY_TEMPLATE to ROLE_DOCARE;

prompt
prompt Creating table MED_PACU_VITALSIGNS
prompt ==================================
prompt
create table MED_PACU_VITALSIGNS
(
  PATIENT_ID        VARCHAR2(20) not null,
  VISIT_ID          NUMBER(2) not null,
  OPER_ID           NUMBER(2) not null,
  TIME_POINT        DATE not null,
  VITAL_SIGNS       VARCHAR2(16) not null,
  VITAL_SIGNS_VALUE VARCHAR2(16),
  UNITS             VARCHAR2(10),
  EXAM_METHOD       NUMBER(1)
)
;
alter table MED_PACU_VITALSIGNS
  add constraint PK_MED_PACU_VITALSIGNS primary key (PATIENT_ID, VISIT_ID, OPER_ID, TIME_POINT, VITAL_SIGNS);
grant select, insert, update, delete on MED_PACU_VITALSIGNS to ROLE_DOCARE;

prompt
prompt Creating table MED_PACU_VITALSIGNS_CHANGED
prompt ==========================================
prompt
create table MED_PACU_VITALSIGNS_CHANGED
(
  PATIENT_ID    VARCHAR2(20) not null,
  VISIT_ID      NUMBER(2) not null,
  OPER_ID       NUMBER(2) not null,
  TIME_POINT    DATE not null,
  VITAL_SIGNS   VARCHAR2(16) not null,
  OLD_VALUE     VARCHAR2(16),
  NEW_VALUE     VARCHAR2(16),
  UNITS         VARCHAR2(10),
  MEMO          VARCHAR2(40),
  OPERATOR      VARCHAR2(8),
  LOG_DATE_TIME DATE not null
)
;
alter table MED_PACU_VITALSIGNS_CHANGED
  add constraint PK_MED_PACU_VITALSIGNS_CHANGED primary key (PATIENT_ID, VISIT_ID, OPER_ID, TIME_POINT, VITAL_SIGNS, LOG_DATE_TIME);
grant select, insert, update, delete on MED_PACU_VITALSIGNS_CHANGED to ROLE_DOCARE;

prompt
prompt Creating table MED_PAT_MONITOR_DATA
prompt ===================================
prompt
create table MED_PAT_MONITOR_DATA
(
  PATIENT_ID    VARCHAR2(20) not null,
  VISIT_ID      NUMBER(2) not null,
  OPER_ID       NUMBER(2) not null,
  ITEM_NO       NUMBER(4) not null,
  MONITOR_VALUE VARCHAR2(240),
  DATA_TYPE     VARCHAR2(1),
  NOTICE_TIME   DATE
)
;
alter table MED_PAT_MONITOR_DATA
  add constraint PK_MED_PAT_MONITOR_DATA primary key (PATIENT_ID, VISIT_ID, OPER_ID, ITEM_NO);
grant select, insert, update, delete, alter on MED_PAT_MONITOR_DATA to ROLE_DOCARE;

create table med_pat_monitor_data_temp
	(
	PATIENT_ID        VARCHAR2(20) not null,
	VISIT_ID          NUMBER(2) not null ,
	OPER_ID						NUMBER(2) not null,
	TIME_POINT        DATE not null,
	ITEM_CODE         VARCHAR2(6) not null,
	ITEM_NAME	 	      VARCHAR2(20),
	ITEM_VALUE				VARCHAR2(20),
	UNITS             VARCHAR2(10),
	MEMO              VARCHAR2(100),
	EXAM_METHOD       NUMBER(1),
	OPERATOR          VARCHAR2(8),
	LOG_DATE_TIME     DATE
	);
alter table med_pat_monitor_data_temp	
	add constraints pk_med_pat_monitor_data_temp 	primary key	(	PATIENT_ID, VISIT_ID, OPER_ID, TIME_POINT, ITEM_CODE);
grant select,insert,update,delete	on	med_pat_monitor_data_temp	to	ROLE_DOCARE;





prompt
prompt Creating table MED_PAT_MONITOR_DATA_EXT
prompt =======================================
prompt
create table MED_PAT_MONITOR_DATA_EXT
(
  PATIENT_ID      VARCHAR2(20) not null,
  VISIT_ID        NUMBER(2) not null,
  OPER_ID         NUMBER(2) not null,
  RECORDING_DATE  DATE not null,
  TIME_POINT      DATE not null,
  ITEM_CODE       VARCHAR2(6) not null,
  ITEM_NAME       VARCHAR2(20),
  ITEM_VALUE      VARCHAR2(20),
  UNITS           VARCHAR2(10),
  MEMO            VARCHAR2(100),
  EXAM_METHOD     NUMBER(1),
  NURSE_INDICATOR NUMBER(1),
  OPERATOR        VARCHAR2(8),
  LOG_DATE_TIME   DATE,
  INSTRUMENT_TYPE VARCHAR2(20),
  TIME_POINT_NOTE VARCHAR2(20),
  ITEM_NO         NUMBER,
  MODIFIED_TYPE 	NUMBER
)
;
alter table MED_PAT_MONITOR_DATA_EXT
  add constraint PK_MED_PAT_MONITOR_DATA_EXT primary key (PATIENT_ID, VISIT_ID, OPER_ID, RECORDING_DATE, TIME_POINT, ITEM_CODE);
grant select, insert, update, delete on MED_PAT_MONITOR_DATA_EXT to ROLE_DOCARE;

prompt
prompt Creating table MED_PAT_MONITOR_DATA_HISTORY
prompt ===========================================
prompt
create table MED_PAT_MONITOR_DATA_HISTORY
(
  PATIENT_ID    VARCHAR2(20) not null,
  VISIT_ID      NUMBER(2) not null,
  OPER_ID       NUMBER(2) not null,
  ITEM_NO       NUMBER(4) not null,
  MONITOR_VALUE VARCHAR2(240),
  DATA_TYPE     VARCHAR2(1),
  RECORD_DATE   DATE
)
;
alter table MED_PAT_MONITOR_DATA_HISTORY
  add constraint PK_MED_MONITOR_DATA_HISTORY primary key (PATIENT_ID, VISIT_ID, OPER_ID, ITEM_NO);
grant select, insert, update, delete, alter on MED_PAT_MONITOR_DATA_HISTORY to ROLE_DOCARE;

prompt
prompt Creating table MED_PAT_MONITOR_PARM_DEFINE
prompt ==========================================
prompt
create table MED_PAT_MONITOR_PARM_DEFINE
(
  PATIENT_ID    VARCHAR2(20) not null,
  VISIT_ID      NUMBER(2) not null,
  OPER_ID       NUMBER(2) not null,
  ITEM_CODE     VARCHAR2(6) not null,
  ITEM_NAME     VARCHAR2(20),
  DRAW_STYLE    NUMBER(1),
  DRAW_INTERVAL NUMBER(4),
  DRAW_ISVALID		NUMBER(1) default 1
)
;
alter table MED_PAT_MONITOR_PARM_DEFINE
  add constraint PK_MED_PAT_MONITOR_PARM_DEFINE primary key (PATIENT_ID, VISIT_ID, OPER_ID, ITEM_CODE);
grant select, insert, update, delete on MED_PAT_MONITOR_PARM_DEFINE to ROLE_DOCARE;

prompt
prompt Creating table MED_QUERY_COND
prompt =============================
prompt
create table MED_QUERY_COND
(
  COND_TYPE        VARCHAR2(20),
  COND_TITLE       VARCHAR2(40) not null,
  CONDITION        VARCHAR2(1000),
  CREATOR_ID       VARCHAR2(16),
  CREATE_DATE_TIME DATE,
  PERMISSION       VARCHAR2(1)
)
;
alter table MED_QUERY_COND
  add constraint PK_MED_QUERY_COND primary key (COND_TITLE);
grant select, insert, update, delete on MED_QUERY_COND to ROLE_DOCARE;

prompt
prompt Creating table MED_QUERY_COND_SELECTION
prompt =======================================
prompt
create table MED_QUERY_COND_SELECTION
(
  USER_NAME  VARCHAR2(16) not null,
  COND_TITLE VARCHAR2(40) not null
)
;
alter table MED_QUERY_COND_SELECTION
  add constraint PK_MED_QUERY_COND_SELECTION primary key (USER_NAME, COND_TITLE);
grant select, insert, update, delete on MED_QUERY_COND_SELECTION to ROLE_DOCARE;

prompt
prompt Creating table MED_SCHEDULED_OPERATION_NAME
prompt ===========================================
prompt
create table MED_SCHEDULED_OPERATION_NAME
(
  PATIENT_ID      VARCHAR2(20) not null,
  VISIT_ID        NUMBER(2) not null,
  SCHEDULE_ID     NUMBER(2) not null,
  OPERATION_NO    NUMBER(2) not null,
  OPERATION       VARCHAR2(100),
  OPERATION_SCALE VARCHAR2(2),
  OPERATION_CODE  VARCHAR2(8),
  RESERVED1       VARCHAR2(20),
  RESERVED2       VARCHAR2(20),
  RESERVED3       VARCHAR2(20),
  RESERVED4       VARCHAR2(20),
  RESERVED5       NUMBER(6)
)
;
alter table MED_SCHEDULED_OPERATION_NAME
  add constraint PK_MED_SCH_OPERATION_NAME primary key (PATIENT_ID, VISIT_ID, SCHEDULE_ID, OPERATION_NO);
grant select, insert, update, delete on MED_SCHEDULED_OPERATION_NAME to ROLE_DOCARE;
grant select, insert, update, delete, references, alter, index on MED_SCHEDULED_OPERATION_NAME to medcomm with grant option;

prompt
prompt Creating table MED_STAFF_LEAVE_LOG
prompt ==================================
prompt
create table MED_STAFF_LEAVE_LOG
(
  STAFF_ID     VARCHAR2(10) not null,
  LEAVE_DATE   DATE not null,
  LEAVE_REASON VARCHAR2(20),
  BACK_DATE    DATE
)
;
alter table MED_STAFF_LEAVE_LOG
  add constraint PK_MED_STAFF_LEAVE_LOG primary key (STAFF_ID, LEAVE_DATE);
grant select, insert, update, delete on MED_STAFF_LEAVE_LOG to ROLE_DOCARE;

prompt
prompt Creating table MED_STAFF_PERSONNEL_INFO
prompt =======================================
prompt
create table MED_STAFF_PERSONNEL_INFO
(
  DEPT_CODE              VARCHAR2(8),
  STAFF_TYPE             VARCHAR2(8),
  STAFF_ID               VARCHAR2(10) not null,
  REGISTER_NO            VARCHAR2(12),
  NAME                   VARCHAR2(8),
  NAME_PHONETIC          VARCHAR2(16),
  SEX                    VARCHAR2(4),
  DATE_OF_BIRTH          DATE,
  DATE_OF_SERVICE        DATE,
  TITLE                  VARCHAR2(26),
  DATE_OF_TITLE          DATE,
  DUTY                   VARCHAR2(10),
  DATE_OF_DUTY           DATE,
  START_DATE_OF_WORK     DATE,
  DATE_OF_HIRE           DATE,
  TERM_OF_HIRE           NUMBER(4),
  BASE_PAY               NUMBER(8,2),
  POLITICAL_FEATURE      VARCHAR2(8),
  NATIVE_PLACE           VARCHAR2(34),
  MARITAL_STATUS         VARCHAR2(4),
  ADDRESS                VARCHAR2(30),
  ZIP_CODE               VARCHAR2(6),
  PHONE_NUMBER           VARCHAR2(16),
  RANK                   VARCHAR2(16),
  DATE_OF_RANK           DATE,
  ID_NO                  VARCHAR2(18),
  FORMER_UNIT            VARCHAR2(40),
  EDUCATIONAL_LEVEL_1    VARCHAR2(10),
  DEGREE_1               VARCHAR2(10),
  GRADUATE_DATE_1        DATE,
  GRADUATE_FROM_1        VARCHAR2(20),
  EDUCATION_TYPE_1       VARCHAR2(10),
  EDUCATIONAL_LEVEL_2    VARCHAR2(10),
  DEGREE_2               VARCHAR2(10),
  GRADUATE_DATE_2        DATE,
  GRADUATE_FROM_2        VARCHAR2(20),
  EDUCATION_TYPE_2       VARCHAR2(10),
  FOREIGN_LANGUAGE       VARCHAR2(10),
  FOREIGN_LANGUAGE_LEVEL VARCHAR2(4),
  STAFF_AGE              NUMBER(2),
  ENTER_DATE             DATE,
  LEAVE_DATE             DATE,
  LEAVE_REASON           VARCHAR2(20),
  WORKING_STATUS         NUMBER(1),
  EMP_NO                 VARCHAR2(6),
  INPUT_CODE             VARCHAR2(8),
  SERIAL_NO              NUMBER(4),
  USER_NAME              VARCHAR2(16),
  PASSWORD               VARCHAR2(30),
  USER_VALID             NUMBER(1),
  CREATE_DATE            DATE,
  STAFF_VALID            NUMBER(1)
)
;
alter table MED_STAFF_PERSONNEL_INFO
  add constraint PK_MED_STAFF_PERSONNEL_INFO primary key (STAFF_ID);
grant select, insert, update, delete on MED_STAFF_PERSONNEL_INFO to ROLE_DOCARE;

prompt
prompt Creating table MED_STAFF_SCHEDULE
prompt =================================
prompt
create table MED_STAFF_SCHEDULE
(
  DEPT_CODE    VARCHAR2(8) not null,
  SERIAL_NO    NUMBER(8) not null,
  STAFF_ID     VARCHAR2(10),
  STAFF_NAME   VARCHAR2(8),
  DATE_OF_WORK DATE not null,
  SCHEDULE     VARCHAR2(10)
)
;
alter table MED_STAFF_SCHEDULE
  add constraint PK_MED_STAFF_SCHEDULE primary key (DEPT_CODE, SERIAL_NO, DATE_OF_WORK);
grant select, insert, update, delete on MED_STAFF_SCHEDULE to ROLE_DOCARE;

prompt
prompt Creating table MED_STAFF_SCHEDULE_DICT
prompt ======================================
prompt
create table MED_STAFF_SCHEDULE_DICT
(
  SERIAL_NO     NUMBER(3),
  SCHEDULE_NAME VARCHAR2(10) not null,
  SCHEDULE_TYPE VARCHAR2(8),
  INPUT_CODE    VARCHAR2(8)
)
;
alter table MED_STAFF_SCHEDULE_DICT
  add constraint PK_MED_STAFF_REMARK_DETAIL primary key (SCHEDULE_NAME);
grant select, insert, update, delete on MED_STAFF_SCHEDULE_DICT to ROLE_DOCARE;

prompt
prompt Creating table MED_STAFF_SCHEDULE_REM
prompt =====================================
prompt
create table MED_STAFF_SCHEDULE_REM
(
  DEPT_CODE      VARCHAR2(8) not null,
  DATE_OF_MONDAY DATE not null,
  CONTENT        VARCHAR2(200)
)
;
alter table MED_STAFF_SCHEDULE_REM
  add constraint PK_MED_STAFF_SCH_REM primary key (DEPT_CODE, DATE_OF_MONDAY);
grant select, insert, update, delete on MED_STAFF_SCHEDULE_REM to ROLE_DOCARE;

prompt
prompt Creating table MED_STAFF_SCHEDULE_REM_DETAIL
prompt ============================================
prompt
create table MED_STAFF_SCHEDULE_REM_DETAIL
(
  DEPT_CODE      VARCHAR2(8) not null,
  DATE_OF_MONDAY DATE not null,
  STAFF_ID       VARCHAR2(10) not null,
  STAFF_NAME     VARCHAR2(8) not null,
  CONTENT        VARCHAR2(200)
)
;
alter table MED_STAFF_SCHEDULE_REM_DETAIL
  add constraint PK_MED_STAFF_SCH_REM_DETAIL primary key (DEPT_CODE, DATE_OF_MONDAY, STAFF_ID, STAFF_NAME);
grant select, insert, update, delete on MED_STAFF_SCHEDULE_REM_DETAIL to ROLE_DOCARE;

prompt
prompt Creating table MED_STAFF_TRANSFER
prompt =================================
prompt
create table MED_STAFF_TRANSFER
(
  STAFF_ID      VARCHAR2(10) not null,
  TRANSFER_DATE DATE not null,
  TRANSFER_FROM VARCHAR2(8),
  TRANSFER_TO   VARCHAR2(8)
)
;
alter table MED_STAFF_TRANSFER
  add constraint PK_MED_STAFF_TRANSFER primary key (STAFF_ID, TRANSFER_DATE);
grant select, insert, update, delete on MED_STAFF_TRANSFER to ROLE_DOCARE;

prompt
prompt Creating table MED_ST_OPER_COSTS
prompt ================================
prompt
create table MED_ST_OPER_COSTS
(
  YEAR_MONTH     DATE not null,
  ITEM_CLASS     VARCHAR2(1) not null,
  CHARGE_TYPE    VARCHAR2(8) not null,
  TOTAL_COSTS    NUMBER(10,2),
  TOTAL_CHARGES  NUMBER(10,2),
  PERFORMED_BY   VARCHAR2(8) not null,
  STAT_DATE_TIME DATE
)
;
alter table MED_ST_OPER_COSTS
  add constraint PK_MED_ST_OPER_COSTS primary key (YEAR_MONTH, ITEM_CLASS, CHARGE_TYPE, PERFORMED_BY);
create index IND_MED_ST_OPER_COSTS_1 on MED_ST_OPER_COSTS (PERFORMED_BY);
grant select, insert, update, delete on MED_ST_OPER_COSTS to ROLE_DOCARE;

prompt
prompt Creating table MED_ST_OP_PER_WORKLOAD
prompt =====================================
prompt
create table MED_ST_OP_PER_WORKLOAD
(
  DUTY               VARCHAR2(16) not null,
  NAME               VARCHAR2(8) not null,
  EMP_NO             VARCHAR2(8),
  YEAR_MONTH         DATE not null,
  WORKLOAD_NUM       NUMBER(3),
  WORKLOAD_NUM1      NUMBER(3),
  WORKLOAD_NUM2      NUMBER(3),
  WORKLOAD_NUM3      NUMBER(3),
  WORKLOAD_NUM4      NUMBER(3),
  WORKLOAD_TIME      NUMBER(8,1),
  MODIFIED_BY        VARCHAR2(8),
  MODIFIED_DATE_TIME DATE
)
;
alter table MED_ST_OP_PER_WORKLOAD
  add constraint PK_MED_ST_OP_PER_WORKLOAD primary key (DUTY, NAME, YEAR_MONTH);
grant select, insert, update, delete on MED_ST_OP_PER_WORKLOAD to ROLE_DOCARE;

prompt
prompt Creating table MED_ST_OP_PER_WORKLOAD_TEMP
prompt ==========================================
prompt
create table MED_ST_OP_PER_WORKLOAD_TEMP
(
  DUTY             VARCHAR2(16),
  NAME             VARCHAR2(8),
  EMP_NO           VARCHAR2(8),
  START_DATE_TIME  DATE,
  END_DATE_TIME    DATE,
  PATIENT_ID       VARCHAR2(20) not null,
  VISIT_ID         NUMBER(2) not null,
  OPER_ID          NUMBER(2) not null,
  OPERATION_SCALE  VARCHAR2(2),
  ANALGESIC_METHOD VARCHAR2(40)
)
;
alter table MED_ST_OP_PER_WORKLOAD_TEMP
  add constraint PK_MED_ST_OP_PER_WORKLOAD_TEMP primary key (PATIENT_ID, VISIT_ID, OPER_ID);
grant select, insert, update, delete on MED_ST_OP_PER_WORKLOAD_TEMP to ROLE_DOCARE;

prompt
prompt Creating table MED_SUMMARY_TEMPLET
prompt ==================================
prompt
create table MED_SUMMARY_TEMPLET
(
  TEMPLET_NAME VARCHAR2(40) not null,
  A1           VARCHAR2(12),
  A2           VARCHAR2(12),
  A3           VARCHAR2(20),
  A4           VARCHAR2(12),
  A5           VARCHAR2(20),
  A6           VARCHAR2(12),
  A7           VARCHAR2(12),
  A8           VARCHAR2(200),
  B1           VARCHAR2(12),
  B2           VARCHAR2(12),
  B3           VARCHAR2(12),
  B4           VARCHAR2(12),
  B5           VARCHAR2(12),
  B6           VARCHAR2(12),
  B7           VARCHAR2(12),
  B8           VARCHAR2(12),
  B9           VARCHAR2(12),
  B10          VARCHAR2(12),
  B11          VARCHAR2(12),
  B12          VARCHAR2(12),
  B13          VARCHAR2(12),
  B14          VARCHAR2(120),
  B15          VARCHAR2(12),
  B16          VARCHAR2(120),
  B17          VARCHAR2(12),
  B18          VARCHAR2(12),
  B19          VARCHAR2(12),
  B20          VARCHAR2(100),
  C1           VARCHAR2(12),
  C2           VARCHAR2(12),
  C3           VARCHAR2(12),
  C4           VARCHAR2(12),
  C5           VARCHAR2(12),
  C6           VARCHAR2(50),
  C7           VARCHAR2(12),
  C8           VARCHAR2(12),
  C9           VARCHAR2(12),
  C10          VARCHAR2(120),
  C11          VARCHAR2(12),
  F1           VARCHAR2(12),
  F2           VARCHAR2(30),
  F3           VARCHAR2(120),
  F4           VARCHAR2(12),
  F5           VARCHAR2(12),
  F6           VARCHAR2(12),
  F7           VARCHAR2(12),
  F8           VARCHAR2(12),
  G1           VARCHAR2(12),
  G2           VARCHAR2(12),
  G3           VARCHAR2(12),
  G4           VARCHAR2(12),
  G5           VARCHAR2(12),
  G6           VARCHAR2(12),
  G7           VARCHAR2(12),
  G8           VARCHAR2(12),
  G9           VARCHAR2(12),
  G10          VARCHAR2(30),
  BEFORE_OPER  VARCHAR2(200),
  IN_OPER      VARCHAR2(1000),
  AFTER_OPER   VARCHAR2(200),
  B25          VARCHAR2(120),
  G21          VARCHAR2(20),
  F16          VARCHAR2(120),
  G11          VARCHAR2(4),
  G12          VARCHAR2(4),
  G13          VARCHAR2(8),
  G14          VARCHAR2(4),
  G15          VARCHAR2(4),
  G16          VARCHAR2(4),
  G17          VARCHAR2(4),
  G18          VARCHAR2(16),
  C12          VARCHAR2(16),
  C13          VARCHAR2(4),
  C15          VARCHAR2(100),
  C14          VARCHAR2(4),
  A9           VARCHAR2(8),
  A11          VARCHAR2(4),
  A10          VARCHAR2(8),
  A12          VARCHAR2(40),
  B23          VARCHAR2(40),
  B24          NUMBER(8,4),
  B21          NUMBER(3),
  B22          NUMBER(3),
  F10          VARCHAR2(40),
  F11          VARCHAR2(40),
  F12          VARCHAR2(40),
  F13          VARCHAR2(40),
  F14          VARCHAR2(40),
  F9           VARCHAR2(100),
  constraint PK_MED_SUMMARY_TEMPLET primary key (TEMPLET_NAME)
);
grant select, insert, update, delete on MED_SUMMARY_TEMPLET to ROLE_DOCARE;


create table MED_TRANSFER_SELF
(
  PATIENT_ID         VARCHAR2(20) not null,
  VISIT_ID           NUMBER(2) not null,
  OPER_ID            NUMBER(2) not null,
  ENTER_DATE         DATE not null,
  ENTERED_BY         VARCHAR2(8),
  ERYTHROCYTE        VARCHAR2(20),
  LEUCOCYTE          VARCHAR2(20),
  BLOOD_PLATELET     VARCHAR2(20),
  ERYTHROCYTE_VOLUME VARCHAR2(20),
  HEMACHROME         VARCHAR2(20),
  TRANSFER_SELF      VARCHAR2(20)
);
-- Add comments to the table 
comment on table MED_TRANSFER_SELF
  is '自体回输记录';
-- Add comments to the columns 
comment on column MED_TRANSFER_SELF.PATIENT_ID
  is '病人ID';
comment on column MED_TRANSFER_SELF.VISIT_ID
  is '住院次数;门诊病人为0';
comment on column MED_TRANSFER_SELF.OPER_ID
  is '手术号;一个病人一次住院期间手术的标识，从1开始顺序排列。如果为门诊病人，则在VISIT_ID为0 的所有记录中顺序排列';
comment on column MED_TRANSFER_SELF.ENTER_DATE
  is '记录时间';
comment on column MED_TRANSFER_SELF.ENTERED_BY
  is '录入者';
comment on column MED_TRANSFER_SELF.ERYTHROCYTE
  is '红细胞';
comment on column MED_TRANSFER_SELF.LEUCOCYTE
  is '白细胞';
comment on column MED_TRANSFER_SELF.BLOOD_PLATELET
  is '血小板';
comment on column MED_TRANSFER_SELF.ERYTHROCYTE_VOLUME
  is '红细胞压积';
comment on column MED_TRANSFER_SELF.HEMACHROME
  is '血色素';
comment on column MED_TRANSFER_SELF.TRANSFER_SELF
  is '自体回输';
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_TRANSFER_SELF
  add constraint PK_MED_TRANSFER_SELF primary key (PATIENT_ID, VISIT_ID, OPER_ID, ENTER_DATE);
grant select, insert, update, delete, alter on MED_TRANSFER_SELF to ROLE_DOCARE;  
prompt
prompt Creating table MED_TEMPLET_CONFIG
prompt =================================
prompt
create table MED_TEMPLET_CONFIG
(
  DB_USER            VARCHAR2(16) not null,
  ANESTHESIA_TEMPLET VARCHAR2(40),
  INQUIRY_TEMPLET    VARCHAR2(40),
  SUMMARY_TEMPLET    VARCHAR2(40),
  EQIP_TEMPLET       VARCHAR2(40)
)
;
alter table MED_TEMPLET_CONFIG
  add constraint PK_MED_TEMPLET_CONFIG primary key (DB_USER);
grant select, insert, update, delete, alter on MED_TEMPLET_CONFIG to ROLE_DOCARE;


create table MED_STAFF_SCHEDULE_REMARK
(
	DEPT_CODE      VARCHAR2(8) not null,
	DATE_OF_MONDAY DATE not null,
	CONTENT        VARCHAR2(200),
	constraint PK_MED_STAFF_SCHEDULE_REMARK primary key (DEPT_CODE, DATE_OF_MONDAY)
);
grant select, insert, update, delete on MED_STAFF_SCHEDULE_REMARK to ROLE_DOCARE;
create table MED_STAFF_SCHEDULE_REMARK_D
(
  DEPT_CODE      VARCHAR2(8) not null,
  DATE_OF_MONDAY DATE not null,
  STAFF_ID       VARCHAR2(10) not null,
  STAFF_NAME     VARCHAR2(8) not null,
  CONTENT        VARCHAR2(200),
  constraint PK_SCHEDULE_REMARK_DETAIL primary key (DEPT_CODE, DATE_OF_MONDAY, STAFF_ID, STAFF_NAME)
);
grant select, insert, update, delete on MED_STAFF_SCHEDULE_REMARK_D to ROLE_DOCARE;

-- Create table
create table MED_DOCARE_INPUT_DICT
(
  SERIAL_NO  NUMBER(5),
  CATALOG    VARCHAR2(16) not null,
  ITEM_CLASS VARCHAR2(16) not null,
  ITEM_NAME  VARCHAR2(40) not null,
  ITEM_CODE  VARCHAR2(40),
  INPUT_CODE VARCHAR2(8)
);
alter table MED_DOCARE_INPUT_DICT
  add constraint PK_MED_DOCARE_INPUT_DICT primary key (CATALOG, ITEM_CLASS, ITEM_NAME);
grant select, insert, update, delete on MED_DOCARE_INPUT_DICT to ROLE_DOCARE;

-- Add comments to the table 
comment on table MED_DOCARE_INPUT_DICT
  is 'DOCARE输入项目字典';
-- Add comments to the columns 
comment on column MED_DOCARE_INPUT_DICT.SERIAL_NO
  is '序号';
comment on column MED_DOCARE_INPUT_DICT.CATALOG
  is '输入项目类别;例如：术前访视、麻醉总结、人员信息等';
comment on column MED_DOCARE_INPUT_DICT.ITEM_CLASS
  is '输入项目';
comment on column MED_DOCARE_INPUT_DICT.ITEM_NAME
  is '备选项目名称';
comment on column MED_DOCARE_INPUT_DICT.ITEM_CODE
  is '备选项目代码;输入项目是明文时，内容备选同项目名称';
comment on column MED_DOCARE_INPUT_DICT.INPUT_CODE
  is '输入码';


rem==================================
rem      创建 为重评分相关脚本
rem==================================



create table APACHE2_SCORING_RESULT_DETAIL
(
  PATIENT_ID        VARCHAR2(10) not null,
  VISIT_ID          NUMBER(2) not null,
  SCORING_DATE_TIME DATE not null,
  AGE               NUMBER(3),
  HR                NUMBER(5),
  MAP               NUMBER(5),
  BR                NUMBER(5),
  TMP               NUMBER(5,2),
  AADO2             NUMBER(6,2),
  PAO2              NUMBER(6,2),
  FIO2              NUMBER(6,2),
  PH                NUMBER(6,2),
  HCT               NUMBER(6,2),
  CR                NUMBER(6,2),
  WBC               NUMBER(6,2),
  K                 NUMBER(6,2),
  NA                NUMBER(6,2),
  EYES_REFLECT      NUMBER(1),
  TALK_REFLECT      NUMBER(1),
  LIMB_REFLECT      NUMBER(1),
  HEALTH_STATUS     NUMBER(1),
  KEY_INDICATOR     NUMBER(1),
  MEMO              VARCHAR2(100)
)
;
alter table APACHE2_SCORING_RESULT_DETAIL
  add constraint PK_APACHE2_SCORING_RESULT primary key (PATIENT_ID, VISIT_ID, SCORING_DATE_TIME);

grant select, insert, update, delete on APACHE2_SCORING_RESULT_DETAIL to ROLE_DOCARE;

create table APGAR_SCORING_RESULT_DETAIL
(
  PATIENT_ID        VARCHAR2(10) not null,
  VISIT_ID          NUMBER(2) not null,
  SCORING_DATE_TIME DATE not null,
  S1                NUMBER(1),
  S2                NUMBER(1),
  S3                NUMBER(1),
  S4                NUMBER(1),
  S5                NUMBER(1),
  MEMO              VARCHAR2(100)
)
;
alter table APGAR_SCORING_RESULT_DETAIL
  add constraint PK_APGAR_SCORING_RESULT primary key (PATIENT_ID, VISIT_ID, SCORING_DATE_TIME);
grant select, insert, update, delete on APGAR_SCORING_RESULT_DETAIL to ROLE_DOCARE;


create table BALTH_SCORING_RESULT_DETAIL
(
  PATIENT_ID        VARCHAR2(10) not null,
  VISIT_ID          NUMBER(2) not null,
  SCORING_DATE_TIME DATE not null,
  CT_CLASS          NUMBER(1),
  PUTRE_RANGE       NUMBER(1),
  MEMO              VARCHAR2(100)
)
;
alter table BALTH_SCORING_RESULT_DETAIL
  add constraint PK_BALTH_SCORING_RESULT primary key (PATIENT_ID, VISIT_ID, SCORING_DATE_TIME);

grant select, insert, update, delete on BALTH_SCORING_RESULT_DETAIL to ROLE_DOCARE;


create table CG_SCORING_RESULT_DETAIL
(
  PATIENT_ID        VARCHAR2(10) not null,
  VISIT_ID          NUMBER(2) not null,
  SCORING_DATE_TIME DATE not null,
  S1                NUMBER(1),
  S2                NUMBER(1),
  S3                NUMBER(1),
  S4                NUMBER(1),
  MEMO              VARCHAR2(100)
)
;
alter table CG_SCORING_RESULT_DETAIL
  add constraint PK_CG_SCORING_RESULT primary key (PATIENT_ID, VISIT_ID, SCORING_DATE_TIME);
grant select, insert, update, delete on CG_SCORING_RESULT_DETAIL to ROLE_DOCARE;


create table CPUGH_SCORING_RESULT_DETAIL
(
  PATIENT_ID        VARCHAR2(10) not null,
  VISIT_ID          NUMBER(2) not null,
  SCORING_DATE_TIME DATE not null,
  C1                NUMBER(1),
  C2                NUMBER(1),
  C3                NUMBER(1),
  C4                NUMBER(1),
  C5                NUMBER(1),
  C6                NUMBER(1),
  MEMO              VARCHAR2(100)
)
;
alter table CPUGH_SCORING_RESULT_DETAIL
  add constraint PK_CPUGH_SCORING_RESULT primary key (PATIENT_ID, VISIT_ID, SCORING_DATE_TIME);
grant select, insert, update, delete on CPUGH_SCORING_RESULT_DETAIL to ROLE_DOCARE;


create table CRAMS_SCORING_RESULT_DETAIL
(
  PATIENT_ID        VARCHAR2(10) not null,
  VISIT_ID          NUMBER(2) not null,
  SCORING_DATE_TIME DATE not null,
  CIRCLE_STATUS     NUMBER(1),
  BREATH_STATUS     NUMBER(1),
  BREAST_STATUS     NUMBER(1),
  LIMB_STATUS       NUMBER(1),
  TALK_STATUS       NUMBER(1),
  MEMO              VARCHAR2(100)
)
;
alter table CRAMS_SCORING_RESULT_DETAIL
  add constraint PK_CRAMS_SCORING_RESULT primary key (PATIENT_ID, VISIT_ID, SCORING_DATE_TIME);
grant select, insert, update, delete on CRAMS_SCORING_RESULT_DETAIL to ROLE_DOCARE;


create table CRIB_SCORING_RESULT_DETAIL
(
  PATIENT_ID        VARCHAR2(10) not null,
  VISIT_ID          NUMBER(2) not null,
  SCORING_DATE_TIME DATE not null,
  S1                NUMBER(1),
  S2                NUMBER(1),
  S3                NUMBER(1),
  S4                NUMBER(1),
  S5                NUMBER(1),
  MEMO              VARCHAR2(100)
)
;
alter table CRIB_SCORING_RESULT_DETAIL
  add constraint PK_CRIB_SCORING_RESULT primary key (PATIENT_ID, VISIT_ID, SCORING_DATE_TIME);
grant select, insert, update, delete on CRIB_SCORING_RESULT_DETAIL to ROLE_DOCARE;


create table CSSS_SCORING_RESULT_DETAIL
(
  PATIENT_ID        VARCHAR2(10) not null,
  VISIT_ID          NUMBER(2) not null,
  SCORING_DATE_TIME DATE not null,
  S1                NUMBER(1),
  S2                NUMBER(1),
  S3                NUMBER(1),
  S41               NUMBER(1),
  S42               NUMBER(1),
  S43               NUMBER(1),
  S5                NUMBER(1),
  S6                NUMBER(1),
  S7                NUMBER(1),
  S8                NUMBER(1),
  S9                NUMBER(1),
  S10               NUMBER(1),
  S11               NUMBER(1),
  S12               NUMBER(1),
  S13               NUMBER(1),
  S14               NUMBER(1),
  S151              NUMBER(1),
  S152              NUMBER(1),
  S153              NUMBER(1),
  S154              NUMBER(1),
  S155              NUMBER(1),
  S161              NUMBER(1),
  S162              NUMBER(1),
  S163              NUMBER(1),
  MEMO              VARCHAR2(100)
)
;
alter table CSSS_SCORING_RESULT_DETAIL
  add constraint PK_CSSS_SCORING_RESULT primary key (PATIENT_ID, VISIT_ID, SCORING_DATE_TIME);
grant select, insert, update, delete on CSSS_SCORING_RESULT_DETAIL to ROLE_DOCARE;


create table GCS_SCORING_RESULT_DETAIL
(
  PATIENT_ID        VARCHAR2(10) not null,
  VISIT_ID          NUMBER(2) not null,
  SCORING_DATE_TIME DATE not null,
  EYES_REFLECT      NUMBER(1),
  TALK_REFLECT      NUMBER(1),
  LIMB_REFLECT      NUMBER(1),
  MEMO              VARCHAR2(100)
)
;
alter table GCS_SCORING_RESULT_DETAIL
  add constraint PK_GCS_SCORING_RESULT primary key (PATIENT_ID, VISIT_ID, SCORING_DATE_TIME);
grant select, insert, update, delete on GCS_SCORING_RESULT_DETAIL to ROLE_DOCARE;


create table GOLDMAN_SCORING_RESULT_DETAIL
(
  PATIENT_ID        VARCHAR2(10) not null,
  VISIT_ID          NUMBER(2) not null,
  SCORING_DATE_TIME DATE not null,
  G1                NUMBER(2),
  G2                NUMBER(2),
  G3                NUMBER(2),
  G4                NUMBER(2),
  G5                NUMBER(2),
  G6                NUMBER(2),
  G7                NUMBER(2),
  G8                NUMBER(2),
  G9                NUMBER(2),
  MEMO              VARCHAR2(100)
)
;
alter table GOLDMAN_SCORING_RESULT_DETAIL
  add constraint PK_GOLDMAN_SCORING_RESULT primary key (PATIENT_ID, VISIT_ID, SCORING_DATE_TIME);
grant select, insert, update, delete on GOLDMAN_SCORING_RESULT_DETAIL to ROLE_DOCARE;


create table GP_SCORING_RESULT_DETAIL
(
  PATIENT_ID        VARCHAR2(10) not null,
  VISIT_ID          NUMBER(2) not null,
  SCORING_DATE_TIME DATE not null,
  S1                NUMBER(1),
  S2                NUMBER(1),
  S3                NUMBER(1),
  S4                NUMBER(1),
  S5                NUMBER(1),
  S6                NUMBER(1),
  S7                NUMBER(1),
  MEMO              VARCHAR2(100)
)
;
alter table GP_SCORING_RESULT_DETAIL
  add constraint PK_GP_SCORING_RESULT primary key (PATIENT_ID, VISIT_ID, SCORING_DATE_TIME);
grant select, insert, update, delete on GP_SCORING_RESULT_DETAIL to ROLE_DOCARE;


create table IMP_ITEM_VS_DICT
(
  PROGRAM_NAME    VARCHAR2(20) not null,
  SCORING_METHOD  VARCHAR2(20) not null,
  ITEM_NAME       VARCHAR2(100) not null,
  CLASS_INDICATOR NUMBER(1),
  RELATE_CODE     VARCHAR2(30),
  VALUE_TYPE      NUMBER(1)
)
;
alter table IMP_ITEM_VS_DICT
  add constraint PK_IMP_ITEM_VS_DICT primary key (PROGRAM_NAME, SCORING_METHOD, ITEM_NAME);
grant select, insert, update, delete on IMP_ITEM_VS_DICT to ROLE_DOCARE;


create table LUTZ_SCORING_RESULT_DETAIL
(
  PATIENT_ID        VARCHAR2(10) not null,
  VISIT_ID          NUMBER(2) not null,
  SCORING_DATE_TIME DATE not null,
  OPERATE_TYPE      NUMBER(1),
  OPERATE_PART      NUMBER(1),
  OPERATE_TIME      NUMBER(1),
  AGE               NUMBER(1),
  BADY_STATUS       NUMBER(1),
  CONS_STATUS       NUMBER(1),
  HEART_STATUS      NUMBER(1),
  ARRHYTHMIA        NUMBER(1),
  CIRCLE_STATUS     NUMBER(1),
  BREATH_STATUS     NUMBER(1),
  METABOLIZE        NUMBER(1),
  K_STATUS          NUMBER(1),
  BLOOD_STATUS      NUMBER(1),
  LIVER_STATUS      NUMBER(1),
  KIDNEY_STATUS     NUMBER(1),
  MEMO              VARCHAR2(100)
)
;
alter table LUTZ_SCORING_RESULT_DETAIL
  add constraint PK_LUTZ_SCORING_RESULT primary key (PATIENT_ID, VISIT_ID, SCORING_DATE_TIME);
grant select, insert, update, delete on LUTZ_SCORING_RESULT_DETAIL to ROLE_DOCARE;


create table MODS2_SCORING_RESULT_DETAIL
(
  PATIENT_ID        VARCHAR2(10) not null,
  VISIT_ID          NUMBER(2) not null,
  SCORING_DATE_TIME DATE not null,
  S1                NUMBER(1),
  S2                NUMBER(1),
  S3                NUMBER(1),
  S4                NUMBER(1),
  S5                NUMBER(1),
  S6                NUMBER(1),
  S7                NUMBER(1),
  S8                NUMBER(1),
  S9                NUMBER(1),
  MEMO              VARCHAR2(100)
)
;
alter table MODS2_SCORING_RESULT_DETAIL
  add constraint PK_MODS2_SCORING_RESULT primary key (PATIENT_ID, VISIT_ID, SCORING_DATE_TIME);
grant select, insert, update, delete on MODS2_SCORING_RESULT_DETAIL to ROLE_DOCARE;


create table MODS_SCORING_RESULT_DETAIL
(
  PATIENT_ID        VARCHAR2(10) not null,
  VISIT_ID          NUMBER(2) not null,
  SCORING_DATE_TIME DATE not null,
  HR                NUMBER(5),
  RAP               NUMBER(5),
  MAP               NUMBER(5),
  PAO2              NUMBER(6,2),
  FIO2              NUMBER(6,2),
  CR                NUMBER(6,2),
  BBIL              NUMBER(6,2),
  PLT               NUMBER(6,2),
  EYES_REFLECT      NUMBER(1),
  TALK_REFLECT      NUMBER(1),
  LIMB_REFLECT      NUMBER(1),
  MEMO              VARCHAR2(100)
)
;
alter table MODS_SCORING_RESULT_DETAIL
  add constraint PK_MODS_SCORING_RESULT primary key (PATIENT_ID, VISIT_ID, SCORING_DATE_TIME);
grant select, insert, update, delete on MODS_SCORING_RESULT_DETAIL to ROLE_DOCARE;


create table NORTON_SCORING_RESULT_DETAIL
(
  PATIENT_ID        VARCHAR2(10) not null,
  VISIT_ID          NUMBER(2) not null,
  SCORING_DATE_TIME DATE not null,
  S1                NUMBER(1),
  S2                NUMBER(1),
  S3                NUMBER(1),
  S4                NUMBER(1),
  S5                NUMBER(1),
  S6                NUMBER(1),
  S7                NUMBER(1),
  S8                NUMBER(1),
  S9                NUMBER(1),
  MEMO              VARCHAR2(100)
)
;
alter table NORTON_SCORING_RESULT_DETAIL
  add constraint PK_NORTON_SCORING_RESULT primary key (PATIENT_ID, VISIT_ID, SCORING_DATE_TIME);
grant select, insert, update, delete on NORTON_SCORING_RESULT_DETAIL to ROLE_DOCARE;


create table PARS_SCORING_RESULT_DETAIL
(
  PATIENT_ID        VARCHAR2(10) not null,
  VISIT_ID          NUMBER(2) not null,
  SCORING_DATE_TIME DATE not null,
  ACTIVE_STATUS     NUMBER(1),
  BREATH_STATUS     NUMBER(1),
  CIRCLE_STATUS     NUMBER(1),
  CONS_STATUS       NUMBER(1),
  SKIN_STATUS       NUMBER(1),
  MEMO              VARCHAR2(100)
)
;
alter table PARS_SCORING_RESULT_DETAIL
  add constraint PK_PARS_SCORING_RESULT primary key (PATIENT_ID, VISIT_ID, SCORING_DATE_TIME);
grant select, insert, update, delete on PARS_SCORING_RESULT_DETAIL to ROLE_DOCARE;


create table PATIENT_SCORING_RESULT
(
  PATIENT_ID        VARCHAR2(10) not null,
  VISIT_ID          NUMBER(2) not null,
  SCORING_DATE_TIME DATE not null,
  SCORING_METHOD    VARCHAR2(20) not null,
  SCORING_VALUE     NUMBER(8),
  DEGREE            VARCHAR2(40),
  DEATH_PROBABILITY NUMBER(5,4),
  PAT_CONDITION     VARCHAR2(80),
  WARD_CODE         VARCHAR2(8),
  OPERATOR          VARCHAR2(8),
  MEMO              VARCHAR2(1000),
  ENTER_DATE_TIME   DATE
)
;
alter table PATIENT_SCORING_RESULT
  add constraint PK_PATIENT_SCORING_RESULT primary key (PATIENT_ID, VISIT_ID, SCORING_DATE_TIME, SCORING_METHOD);
grant select, insert, update, delete on PATIENT_SCORING_RESULT to ROLE_DOCARE;


create table PATIENT_SCORING_RESULT_DETAIL
(
  PATIENT_ID          VARCHAR2(10) not null,
  VISIT_ID            NUMBER(2) not null,
  SCORING_DATE_TIME   DATE not null,
  SCORING_METHOD      VARCHAR2(20) not null,
  ITEM_NAME           VARCHAR2(100) not null,
  ITEM_SOURCE         NUMBER(2),
  ITEM_VALUE          NUMBER(8,4),
  VALUE_OPTIONS       VARCHAR2(200),
  ITEM_VALUE_DESCRIBE NUMBER(2),
  MULTIPLE            NUMBER(2),
  MEMO                VARCHAR2(1000),
  ENTER_DATE_TIME     DATE
)
;
alter table PATIENT_SCORING_RESULT_DETAIL
  add constraint PK_PATIENT_SCORING_DETAIL primary key (PATIENT_ID, VISIT_ID, SCORING_DATE_TIME, SCORING_METHOD, ITEM_NAME);
grant select, insert, update, delete on PATIENT_SCORING_RESULT_DETAIL to ROLE_DOCARE;


create table SAPS2_SCORING_RESULT_DETAIL
(
  PATIENT_ID        VARCHAR2(10) not null,
  VISIT_ID          NUMBER(2) not null,
  SCORING_DATE_TIME DATE not null,
  AGE               NUMBER(3),
  HR                NUMBER(5),
  SBP               NUMBER(5),
  TMP               NUMBER(5,2),
  PAO2              NUMBER(6,2),
  FIO2              NUMBER(6,2),
  EMICTION          NUMBER(8,4),
  BUN               NUMBER(6,2),
  WBC               NUMBER(6,2),
  K                 NUMBER(6,2),
  NA                NUMBER(6,2),
  HCO3              NUMBER(6,2),
  BBIL              NUMBER(6,2),
  ICU_TYPE          NUMBER(2),
  DISEASE1          NUMBER(2),
  DISEASE2          NUMBER(2),
  DISEASE3          NUMBER(2),
  EYES_REFLECT      NUMBER(1),
  TALK_REFLECT      NUMBER(1),
  LIMB_REFLECT      NUMBER(1),
  MEMO              VARCHAR2(100)
)
;
alter table SAPS2_SCORING_RESULT_DETAIL
  add constraint PK_SAPS2_SCORING_RESULT primary key (PATIENT_ID, VISIT_ID, SCORING_DATE_TIME);
grant select, insert, update, delete on SAPS2_SCORING_RESULT_DETAIL to ROLE_DOCARE;


create table SCORING_ITEM_LIST
(
  SCORING_METHOD      VARCHAR2(20) not null,
  ITEM_CLASS          VARCHAR2(20) not null,
  ITEM_NAME           VARCHAR2(100) not null,
  ITEM_NO             NUMBER(2) not null,
  ITEM_SOURCE         NUMBER(2),
  ITEM_VALUE_DESCRIBE NUMBER(2),
  UPPER_LEVEL         NUMBER(8,4),
  LOW_LEVEL           NUMBER(8,4),
  ITEM_VALUE          NUMBER(8,4),
  VALUE_OPTIONS       VARCHAR2(200),
  MULTIPLE            NUMBER(2),
  MEMO                VARCHAR2(1000),
  UPDATED_DATE_TIME   DATE
)
;
alter table SCORING_ITEM_LIST
  add constraint PK_SCORING_ITEM_LIST primary key (SCORING_METHOD, ITEM_CLASS, ITEM_NAME, ITEM_NO);
grant select, insert, update, delete on SCORING_ITEM_LIST to ROLE_DOCARE;


create table SCORING_METHOD_DICT
(
  SCORING_METHOD VARCHAR2(20) not null,
  ENGLISH_NAME   VARCHAR2(80),
  CHINESE_NAME   VARCHAR2(80),
  ARITH_FORMULA  VARCHAR2(4000),
  MEMO           VARCHAR2(1000)
)
;
alter table SCORING_METHOD_DICT
  add constraint PK_SCORING_METHOD_DICT primary key (SCORING_METHOD);
grant select, insert, update, delete on SCORING_METHOD_DICT to ROLE_DOCARE;


create table SCORING_VALUE_MEMO_DICT
(
  SCORING_METHOD VARCHAR2(20) not null,
  UPPER_LEVEL    NUMBER(8) not null,
  LOW_LEVEL      NUMBER(8),
  DEGREE         VARCHAR2(40),
  MEMO           VARCHAR2(200)
)
;
alter table SCORING_VALUE_MEMO_DICT
  add constraint PK_SCORING_VALUE_MEMO_DICT primary key (SCORING_METHOD, UPPER_LEVEL);
grant select, insert, update, delete on SCORING_VALUE_MEMO_DICT to ROLE_DOCARE;


create table SOFA_SCORING_RESULT_DETAIL
(
  PATIENT_ID        VARCHAR2(10) not null,
  VISIT_ID          NUMBER(2) not null,
  SCORING_DATE_TIME DATE not null,
  S1                NUMBER(6,2),
  S2                NUMBER(6,2),
  S3                NUMBER(1),
  S4                NUMBER(1),
  S5                NUMBER(1),
  S6                NUMBER(1),
  EYES_REFLECT      NUMBER(1),
  TALK_REFLECT      NUMBER(1),
  LIMB_REFLECT      NUMBER(1),
  MEMO              VARCHAR2(100)
)
;
alter table SOFA_SCORING_RESULT_DETAIL
  add constraint PK_SOFA_SCORING_RESULT primary key (PATIENT_ID, VISIT_ID, SCORING_DATE_TIME);
grant select, insert, update, delete on SOFA_SCORING_RESULT_DETAIL to ROLE_DOCARE;


create table SSSS_SCORING_RESULT_DETAIL
(
  PATIENT_ID        VARCHAR2(10) not null,
  VISIT_ID          NUMBER(2) not null,
  SCORING_DATE_TIME DATE not null,
  S1                NUMBER(1),
  S2                NUMBER(1),
  S3                NUMBER(1),
  S41               NUMBER(1),
  S42               NUMBER(1),
  S43               NUMBER(1),
  S5                NUMBER(1),
  S6                NUMBER(1),
  S7                NUMBER(1),
  S8                NUMBER(1),
  S9                NUMBER(1),
  S10               NUMBER(1),
  S11               NUMBER(1),
  S12               NUMBER(1),
  S13               NUMBER(1),
  S14               NUMBER(1),
  MEMO              VARCHAR2(100)
)
;
alter table SSSS_SCORING_RESULT_DETAIL
  add constraint PK_SSSS_SCORING_RESULT primary key (PATIENT_ID, VISIT_ID, SCORING_DATE_TIME);
grant select, insert, update, delete on SSSS_SCORING_RESULT_DETAIL to ROLE_DOCARE;


create table SSS_SCORING_RESULT_DETAIL
(
  PATIENT_ID        VARCHAR2(10) not null,
  VISIT_ID          NUMBER(2) not null,
  SCORING_DATE_TIME DATE not null,
  S1                NUMBER(1),
  S2                NUMBER(1),
  S3                NUMBER(1),
  S4                NUMBER(1),
  S5                NUMBER(1),
  S6                NUMBER(1),
  S7                NUMBER(1),
  MEMO              VARCHAR2(100)
)
;
alter table SSS_SCORING_RESULT_DETAIL
  add constraint PK_SSS_SCORING_RESULT primary key (PATIENT_ID, VISIT_ID, SCORING_DATE_TIME);
grant select, insert, update, delete on SSS_SCORING_RESULT_DETAIL to ROLE_DOCARE;

create table TISS_SCORING_RESULT_DETAIL
(
  PATIENT_ID        VARCHAR2(10) not null,
  VISIT_ID          NUMBER(2) not null,
  SCORING_DATE_TIME DATE not null,
  T41               NUMBER(1),
  T42               NUMBER(1),
  T43               NUMBER(1),
  T44               NUMBER(1),
  T45               NUMBER(1),
  T46               NUMBER(1),
  T47               NUMBER(1),
  T48               NUMBER(1),
  T49               NUMBER(1),
  T410              NUMBER(1),
  T411              NUMBER(1),
  T412              NUMBER(1),
  T413              NUMBER(1),
  T414              NUMBER(1),
  T415              NUMBER(1),
  T416              NUMBER(1),
  T417              NUMBER(1),
  T418              NUMBER(1),
  T419              NUMBER(1),
  T31               NUMBER(1),
  T32               NUMBER(1),
  T33               NUMBER(1),
  T34               NUMBER(1),
  T35               NUMBER(1),
  T36               NUMBER(1),
  T37               NUMBER(1),
  T38               NUMBER(1),
  T39               NUMBER(1),
  T310              NUMBER(1),
  T311              NUMBER(1),
  T312              NUMBER(1),
  T313              NUMBER(1),
  T314              NUMBER(1),
  T315              NUMBER(1),
  T316              NUMBER(1),
  T317              NUMBER(1),
  T318              NUMBER(1),
  T319              NUMBER(1),
  T320              NUMBER(1),
  T321              NUMBER(1),
  T322              NUMBER(1),
  T323              NUMBER(1),
  T324              NUMBER(1),
  T325              NUMBER(1),
  T326              NUMBER(1),
  T327              NUMBER(1),
  T328              NUMBER(1),
  T21               NUMBER(1),
  T22               NUMBER(1),
  T23               NUMBER(1),
  T24               NUMBER(1),
  T25               NUMBER(1),
  T26               NUMBER(1),
  T27               NUMBER(1),
  T28               NUMBER(1),
  T29               NUMBER(1),
  T210              NUMBER(1),
  T211              NUMBER(1),
  T11               NUMBER(1),
  T12               NUMBER(1),
  T13               NUMBER(1),
  T14               NUMBER(1),
  T15               NUMBER(1),
  T16               NUMBER(1),
  T17               NUMBER(1),
  T18               NUMBER(1),
  T19               NUMBER(1),
  T110              NUMBER(1),
  T111              NUMBER(1),
  T112              NUMBER(1),
  T113              NUMBER(1),
  T114              NUMBER(1),
  T115              NUMBER(1),
  T116              NUMBER(1),
  T117              NUMBER(1),
  T118              NUMBER(1),
  MEMO              VARCHAR2(100)
)
;
alter table TISS_SCORING_RESULT_DETAIL
  add constraint PK_TISS_SCORING_RESULT primary key (PATIENT_ID, VISIT_ID, SCORING_DATE_TIME);
grant select, insert, update, delete on TISS_SCORING_RESULT_DETAIL to ROLE_DOCARE;


create table pat_adm_condition_dict
	(
	serial_no				number(1),
	pat_condition_code			varchar2(1),
	pat_condition_name			varchar2(10),
	input_code				varchar2(8),
	constraint pk_pat_adm_condition_dict primary key	(	pat_condition_code	)
		);
grant select, insert, update, delete on 	pat_adm_condition_dict 	to ROLE_DOCARE;


create table patient_class_dict
	(
	serial_no				number(1),
	patient_class_code			varchar2(1),
	patient_class_name			varchar2(4),
	input_code				varchar2(8),
	constraint pk_patient_class_dict	primary key	(	patient_class_code )
	);
	
grant select, insert, update, delete on patient_class_dict	to ROLE_DOCARE;

create table MED_OPERATION_CHECKED_NEW
(
  PATIENT_ID VARCHAR2(20) not null,
  VISIT_ID   NUMBER(2) not null,
  OPER_ID    NUMBER(2) not null,
  A1         VARCHAR2(10),
  A2         VARCHAR2(10),
  A3         VARCHAR2(10),
  A4         VARCHAR2(10),
  A5         VARCHAR2(10),
  A6         VARCHAR2(10),
  A7         VARCHAR2(10),
  A8         VARCHAR2(10),
  A9         VARCHAR2(10),
  A10        VARCHAR2(10),
  A11        VARCHAR2(10),
  A12        VARCHAR2(10),
  A13        VARCHAR2(10),
  A14        VARCHAR2(10),
  A15        VARCHAR2(10),
  A16        VARCHAR2(10),
  A17        VARCHAR2(100),
  A18        VARCHAR2(10),
  A19        VARCHAR2(10),
  A20        VARCHAR2(10),
  A21        VARCHAR2(10),
  A22        VARCHAR2(10),
  A23        VARCHAR2(10),
  A24        VARCHAR2(10),
  A25        VARCHAR2(10),
  A26        VARCHAR2(10),
  A27        VARCHAR2(10),
  A28        VARCHAR2(10),
  A29        VARCHAR2(10),
  A30        VARCHAR2(10),
  A31        VARCHAR2(10),
  A32        VARCHAR2(100),
  A33        VARCHAR2(10),
  A34        VARCHAR2(10),
  A35        VARCHAR2(10),
  A36        VARCHAR2(10),
  A37        VARCHAR2(10),
  A38        VARCHAR2(10),
  A39        VARCHAR2(10),
  A40        VARCHAR2(10),
  A41        VARCHAR2(10),
  A42        VARCHAR2(10),
  A43        VARCHAR2(10),
  A44        VARCHAR2(10),
  A45        VARCHAR2(10),
  A46        VARCHAR2(40),
  A47        VARCHAR2(10),
  A48        VARCHAR2(10),
  A49        VARCHAR2(10),
  A50        VARCHAR2(10),
  A51        VARCHAR2(10),
  A52        VARCHAR2(100),
  A53        VARCHAR2(10),
  A54        VARCHAR2(20),
  A55        VARCHAR2(20),
  A56        VARCHAR2(20),
  A57        VARCHAR2(20),
  A58        VARCHAR2(20),
  A59        VARCHAR2(20),
  A60        VARCHAR2(20),
  A61        VARCHAR2(20),
  A62        VARCHAR2(20),
  A63        VARCHAR2(20),
  A64        VARCHAR2(20),
  A65        VARCHAR2(20),
  A66        VARCHAR2(20),
  A67        VARCHAR2(20),
  A68        VARCHAR2(20),
  A69        VARCHAR2(20),
  A70        VARCHAR2(20),
  A71        VARCHAR2(20),
  A72        VARCHAR2(20),
  A73        VARCHAR2(20),
  A74        VARCHAR2(20),
  A75        VARCHAR2(20),
  A76        VARCHAR2(20),
  A77        VARCHAR2(20),
  A78        VARCHAR2(20),
  A79        VARCHAR2(20),
  A80        VARCHAR2(20),
  A81        VARCHAR2(20),
  A82        VARCHAR2(20),
  A83        VARCHAR2(20),
  A84        VARCHAR2(20),
  A85        VARCHAR2(20),
  A86        VARCHAR2(20),
  A87        VARCHAR2(20),
  A88        VARCHAR2(20),
  A89        VARCHAR2(20),
  A90        VARCHAR2(20),
  A91        VARCHAR2(20),
  A92        VARCHAR2(20),
  A93        VARCHAR2(20),
  A94        VARCHAR2(20),
  A95        VARCHAR2(20),
  A96        VARCHAR2(20),
  A97        VARCHAR2(20),
  A98        VARCHAR2(20),
  A99        VARCHAR2(20),
  A100       VARCHAR2(20),
  A101       VARCHAR2(20),
  A102       VARCHAR2(20),
  A103       VARCHAR2(20),
  A104       VARCHAR2(20),
  A105       VARCHAR2(20),
  A106       VARCHAR2(20),
  A107       VARCHAR2(20),
  A108       VARCHAR2(20),
  A109       VARCHAR2(20),
  A110       VARCHAR2(20)
)
;
alter table MED_OPERATION_CHECKED_NEW add constraint PK_MED_OPERATION_CHECKED_NEW primary key (PATIENT_ID, VISIT_ID, OPER_ID);


grant select, insert, update, delete on MED_OPERATION_CHECKED_NEW to ROLE_DOCARE;
