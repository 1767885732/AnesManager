--------------------1.耗材采购计划表-----------------
create table MED_MTRL_PURCHASE_PLAN
(
  PLAN_NO        NVARCHAR(6) not null,
  STORAGE_CODE   NVARCHAR(10),
  ITEM_NO        NUMERIC(4) not null,
  MTRL_CODE      NVARCHAR(16),
  MTRL_SPEC      NVARCHAR(20),
  UNITS          NVARCHAR(8),
  PACKAGE_SPEC   NVARCHAR(20),
  PACKAGE_UNITS  NVARCHAR(8),
  QUANTITY       NUMERIC(12,2),
  SUPPLIER_ID    NVARCHAR(16),
  PURCHASE_PRICE NUMERIC(10,4),
  SUPPLIER       NVARCHAR(60),
  PLANING_DATE   DATETIME,
  MEMOS          NVARCHAR(20),
  constraint PK_MED_MTRL_PURCHASE_PLAN primary key (PLAN_NO, ITEM_NO)
)
--------------2.字段含义记录表------------------------------
create table MED_TABLE_COLS_MEANINGS
(
  TABLE_NAME        NVARCHAR(100) not null,
  COLUMN_NAME       NVARCHAR(100) not null,
  HOSPITAL_NAME     NVARCHAR(100) not null,
  COLUMN_MEANINGS   NVARCHAR(100) not null,
  COL_VALUES        NVARCHAR(100),
  constraint PK_APGAR_RESULT 
  	primary key (TABLE_NAME, COLUMN_NAME, HOSPITAL_NAME)
  );
  --------------3.常用术语字典表------------------------------
create table MED_ANESTHESIA_COMM_DICT
(
  ITEM_NO    NUMERIC(3) not null,
  ITEM_CLASS NVARCHAR(2),
  ITEM_NAME  NVARCHAR(60),
  ITEM_CODE  NVARCHAR(60),
  DATA_TYPE  NVARCHAR(1),
  constraint PK_MED_ANESTHESIA_COMM_DICT primary key (ITEM_NO)
)
--------------4.麻醉事件表------------------------------
create table MED_ANESTHESIA_EVENT
(
  PATIENT_ID         NVARCHAR(20) not null,
  VISIT_ID           NUMERIC(2) not null,
  OPER_ID            NUMERIC(2) not null,
  ITEM_NO            NUMERIC(3) not null,
  ITEM_CLASS         NVARCHAR(1),
  EVENT_NO           NUMERIC(3) not null,
  ITEM_NAME          NVARCHAR(60),
  ITEM_CODE          NVARCHAR(16),
  ITEM_SPEC          NVARCHAR(20),
  DOSAGE_UNITS       NVARCHAR(8),
  DOSAGE             NUMERIC(8,4),
  ADMINISTRATOR      NVARCHAR(8),
  START_TIME         DATETIME,
  END_DATE           DATETIME,
  BILL_INDICATOR     NUMERIC(1),
  DURATIVE_INDICATOR NUMERIC(1),
  METHOD             NVARCHAR(16),
  PERFORM_SPEED      NUMERIC(8,4),
  SPEED_UNIT         NVARCHAR(10),
  PARENT_ITEM_NO     NUMERIC(3),
  EVENT_ATTR         NVARCHAR(10),
  CONCENTRATION      NUMERIC(8,4),
  CONCENTRATION_UNIT NVARCHAR(10),
  BILL_ATTR          NUMERIC(1) default 0,
  SUPPLIER_NAME      NVARCHAR(60),
  METHOD_PARENT_NO   NUMERIC(3),
  constraint PK_MED_ANESTHESIA_EVENT primary key (PATIENT_ID, VISIT_ID, OPER_ID, ITEM_NO, EVENT_NO)
)
----------------5.麻醉用药品和事件名称---------------
create table MED_ANESTHESIA_EVENT_NAME
(
  ITEM_NAME          NVARCHAR(60) not null,
  ITEM_NAME_ABBR     NVARCHAR(40),
  ITEM_NAME_ENGLISH  NVARCHAR(40),
  ITEM_NAME_STANDARD NVARCHAR(40),
  ITEM_CODE          NVARCHAR(16),
  MEMO               NVARCHAR(200),
  constraint PK_MED_ANESTHESIA_EVENT_NAME primary key (ITEM_NAME)
)
----------------6.麻醉事件定义---------------
create table MED_ANESTHESIA_EVENT_OPEN
(
  ITEM_NO            NUMERIC(3) not null,
  ITEM_CLASS         NVARCHAR(2) not null,
  ITEM_NAME          NVARCHAR(60),
  ITEM_CODE          NVARCHAR(16),
  ITEM_SPEC          NVARCHAR(20),
  DOSAGE             NUMERIC(8,4),
  DOSAGE_UNITS       NVARCHAR(8),
  ADMINISTRATOR      NVARCHAR(8),
  IN_ORDER           NUMERIC(1),
  REL_BILL           NUMERIC(1) default 0,
  OPER_CLASS         NVARCHAR(16),
  DURATIVE_INDICATOR NUMERIC(1),
  METHOD             NVARCHAR(16),
  PERFORM_SPEED      NUMERIC(8,4),
  SPEED_UNIT         NVARCHAR(10),
  EVENT_ATTR         NVARCHAR(10),
  CONCENTRATION      NUMERIC(8,4),
  CONCENTRATION_UNIT NVARCHAR(10),
  EVENT_ATTR2        NVARCHAR(20),
  SUPPLIER_NAME      NVARCHAR(60),
  constraint PK_MED_ANESTHESIA_EVENT_OPEN primary key (ITEM_CLASS, ITEM_NO)
)
----------------7.麻醉事件模板定义---------------
create table MED_ANESTHESIA_EVENT_TEMPLET
(
  TEMPLET_CLASS      NVARCHAR(1) default '1',
  ANESTHESIA_METHOD  NVARCHAR(60) default '*' not null,
  TEMPLET            NVARCHAR(40) not null,
  ITEM_CLASS         NVARCHAR(1),
  ITEM_NO            NUMERIC(3) not null,
  ITEM_NAME          NVARCHAR(40),
  ITEM_CODE          NVARCHAR(10),
  ITEM_SPEC          NVARCHAR(20),
  CONCENTRATION      NUMERIC(8,4),
  PERFORM_SPEED      NUMERIC(8,4),
  SPEED_UNIT         NVARCHAR(10),
  DOSAGE             NUMERIC(8,4),
  DOSAGE_UNITS       NVARCHAR(8),
  ADMINISTRATOR      NVARCHAR(8),
  DURATIVE_INDICATOR NUMERIC(1),
  METHOD             NVARCHAR(16),
  EVENT_ATTR         NVARCHAR(10),
  START_AFTER_INPUT  NUMERIC(4,1),
  DURATIVE           NUMERIC(4,1),
  SUB_ITEM_INDICATOR NUMERIC(1),
  CONCENTRATION_UNIT NVARCHAR(10),
  BILL_ATTR          NUMERIC(1),
  CREATE_BY          NVARCHAR(8) default '公用' not null,
  constraint PK_MED_ANESTHESIA_EVENT_TMPT primary key (TEMPLET, ITEM_NO, CREATE_BY)
)
----------------8.麻醉输入项目字典---------------
create table MED_ANESTHESIA_INPUT_DICT
(
  SERIAL_NO  NUMERIC(4),
  ITEM_CLASS NVARCHAR(16) not null,
  ITEM_NAME  NVARCHAR(1000) not null,
  ITEM_CODE  NVARCHAR(40),
  INPUT_CODE NVARCHAR(8),
  constraint PK_MED_ANESTHESIA_INPUT_DICT primary key (ITEM_CLASS, ITEM_NAME)
)
----------------9.术后麻醉随访记录---------------
create table MED_ANESTHESIA_INQUIRY
(
  PATIENT_ID                NVARCHAR(20) not null,
  VISIT_ID                  NUMERIC(2) not null,
  OPER_ID                   NUMERIC(2) not null,
  INQUIRY_DATE_TIME     DATETIME not null,
  BREATH                    NVARCHAR(10),
  THROAT_ACHE               NUMERIC(1),
  SOUND_HOARSENESS          NUMERIC(1),
  BLOOD_PRESS               NVARCHAR(20),
  CARDIOTACH                NVARCHAR(10),
  NAUSEA                    NUMERIC(1),
  CONSCIOUSNESS             NVARCHAR(8),
  HEADACHE                  NUMERIC(1),
  LIMB                      NVARCHAR(20),
  EMICTION_RETENTION        NUMERIC(1),
  PUNCTURE_POSTION_OF_ACHE  NUMERIC(1),
  PUNCTURE_POS_OF_TURGES    NUMERIC(1),
  MEMO                      NVARCHAR(100),
  ENTIRE_REVIVAL_TIME       NVARCHAR(20),
  TRAUMA_INDICATOR          NUMERIC(1),
  FOCUS_SCATTER_INDICATOR   NUMERIC(1),
  LUNG_DISTEND_INDICATOR    NUMERIC(1),
  ABDOMEN_DISTEND_INDICATOR NUMERIC(1),
  INQUIRY_DOCTOR            NVARCHAR(8),
  ENTER_DATE_TIME       DATETIME,
  ENTERED_BY                NVARCHAR(8),
  FS1                       NUMERIC(1),
  FS2                       NUMERIC(1),
  FS3                       NUMERIC(1),
  FS4                       NUMERIC(1),
  FS5                       NUMERIC(1),
  FS6                       NUMERIC(1),
  FS7                       NUMERIC(1),
  FS8                       NUMERIC(1),
  FEEL_ABNORMAL_INDICATOR   NUMERIC(1),
  MOTION_ABNORMAL_INDICATOR NUMERIC(1),
  HOURS_OF_AFTEROPER        NUMERIC(2),
  STATUS                    NUMERIC(1),
  P_R                       NVARCHAR(20),
  DAYS 						NVARCHAR(2),
  DOUBLEF 					NVARCHAR(100),
  FS9 						NUMERIC(1),
  FS10 						NUMERIC(1),
  SHZT 						NVARCHAR(100),
  PLANDATETIME 				DATETIME,
  SECUNAME 					NVARCHAR(40),
  MEMO1                     NVARCHAR(100) ,                                                                                                                             
  MEMO2                     NVARCHAR(100) ,                                                                                                                             
  MEMO3                     NVARCHAR(100) ,                                                                                                                             
  MEMO4                     NVARCHAR(100) ,                                                                                                                             
  MEMO5                     NVARCHAR(100) ,                                                                                                                             
  MEMO6                     NVARCHAR(100) ,                                                                                                                             
  MEMO7                     NVARCHAR(100) ,                                                                                                                             
  N1                        NUMERIC(2)     ,                                                                                                                             
  N2                        NUMERIC(2)     ,                                                                                                                             
  N3                        NUMERIC(2)     ,                                                                                                                             
  N4                        NUMERIC(2)     ,                                                                                                                             
  N5                        NUMERIC(2)     ,                                                                                                                             
  N6                        NUMERIC(2)     ,                                                                                                                             
  N7                        NUMERIC(2)     ,                                                                                                                             
  N8                        NUMERIC(2)     ,                                                                                                                             
  N9                        NUMERIC(2)     ,                                                                                                                             
  N10                       NUMERIC(2)     ,                                                                                                                             
  C1                        NVARCHAR(100) ,                                                                                                                             
  C2                        NVARCHAR(100) ,                                                                                                                             
  C3                        NVARCHAR(100) ,                                                                                                                             
  C4                        DATETIME   ,
  constraint PK_MED_ANESTHESIA_INQUIRY primary key (PATIENT_ID, VISIT_ID, OPER_ID, INQUIRY_DATE_TIME)       
)
----------------10.麻醉护理记录---------------
create table MED_ANESTHESIA_NURSE
(
  PATIENT_ID             NVARCHAR(20) not null,
  VISIT_ID               NUMERIC(2) not null,
  OPER_ID                NUMERIC(2) not null,
  OPER_PART              NVARCHAR(10),
  ALERGY_1               NVARCHAR(1),
  ALERGY_2               NVARCHAR(1),
  CONSCIOUSNESS          NVARCHAR(8),
  PRE_ANES_PHAM          NVARCHAR(300),
  PRE_ANES_PHAM_RESULT   NVARCHAR(1),
  BEFORE_COVER           NVARCHAR(200),
  BRING_THING            NVARCHAR(200),
  ANESTHESIA_POSITION    NVARCHAR(10),
  ANESTHESIA_PRESVER     NVARCHAR(20),
  SPECIMAN_NAME          NVARCHAR(10),
  SPECIMAN_SOUR          NVARCHAR(10),
  SPECIMAN_SEND          NVARCHAR(10),
  SPECIMAN_CHEC          NVARCHAR(10),
  TRAND_LIQU             NVARCHAR(10),
  TRAN_BLOOD             NVARCHAR(10),
  AFTER_COVER            NVARCHAR(200),
  SPECIAL_CON            NVARCHAR(40),
  AFTER_NOTIC            NVARCHAR(200),
  ENTER_DATE_TIME    DATETIME,
  ENTERED_BY             NVARCHAR(8),
  SHALLOW_VENIPUNCTURE   NVARCHAR(4),
  DEEP_VENIPUNCTURE      NVARCHAR(4),
  CATHETERIZATION        NVARCHAR(5),
  INFUSION               NUMERIC(5),
  TRANSFUSE_SELF_BLOOD   NUMERIC(4),
  TRANSFUSE_OTHERS_BLOOD NUMERIC(4),
  TRANSFUSE_LIQUID       NVARCHAR(500),
  AFTER_CONSCIOUSNESS    NVARCHAR(8),
  ASEPTIC_PACKAGE        NVARCHAR(8),
  OUT_DATE_TIME      DATETIME,
  PRESS                  NVARCHAR(20),
  PULSE                  NUMERIC(3),
  SEND_PAT_TO            NVARCHAR(8),
  ELECTRIC_KNIFE         NUMERIC(1),
  TOURNIQUET             NVARCHAR(20),
  CATHODE_PLATE          NVARCHAR(20),
  D_IN_TIME              DATETIME,
  D_OUT_TIME             DATETIME,
  D_PRESS                NUMERIC,
  S_IN_TIME              DATETIME,
  S_OUT_TIME             DATETIME,
  S_PRESS                NUMERIC,
  URETER_SIZE            NVARCHAR(10),
  IMPLANT_NAME           NVARCHAR(200),
  IMPLANT_MANUFACTORY    NVARCHAR(90),
  IMPLANT_OUT            NVARCHAR(90),
  SEND_IMPLANT_TO        NVARCHAR(40),
  SPECIMAN_SEND1         NVARCHAR(10),
  SPECIMAN_CHEC1         NVARCHAR(10),
  SPECIAL_CON_EXT        NVARCHAR(20),
  SPECIMAN_SOUR1         NVARCHAR(10),
  PERSON1 				 NVARCHAR(50),
  PERSON2 				 NVARCHAR(50),
  PERSON3 				 NVARCHAR(50),
  INFUSION_F 			 NUMERIC(1),
	INFUSION2_F 		 NUMERIC(1),
	F1 					 NUMERIC(1),
	F2 										NVARCHAR(20),
	F3 										NVARCHAR(20),
	F4 										NUMERIC(1),
	OPERATION_NAME 				NVARCHAR(200),
	SZTX 									NVARCHAR(20),
	NURSEDATETIME1 						DATETIME,
	NURSEDATETIME2 						DATETIME,
	FLUIDS 								NUMERIC(1),
	QXHS 									NVARCHAR(40),
	XXHS 									NVARCHAR(40),
	JBQXHS 								NVARCHAR(40),
	JBXHHS 								NVARCHAR(40),
	SBHD 									NVARCHAR(40),
	XHHS 									NVARCHAR(40),
	MEMO 									NVARCHAR(200),
	MJZB 									NVARCHAR(20),
	CQSJ1 								NUMERIC(3),
	CQSJ2 								NUMERIC(3),
	CQSJ3 								NUMERIC(3),
	FQSJ1 								NUMERIC(3),
	FQSJ2 								NUMERIC(3),
	FQSJ3 								NUMERIC(3),
	SHJJ1 								NVARCHAR(20),
	SHJJ2 								NVARCHAR(20),
	SHJJ3 								NVARCHAR(20),
	SHJJ4 								NVARCHAR(20),
	SHJJ5 								NVARCHAR(20),
	SHJJ6 								NVARCHAR(20),
	SHJJ7 								NVARCHAR(20),
	SHJJ8 								NVARCHAR(20),
	SHJJ9 								NVARCHAR(20),
	SHJJ10 								NVARCHAR(20),
	SHJJ11 								NVARCHAR(20),
	HIGH_EUIP 						NVARCHAR(200),

   constraint PK_MED_ANESTHESIA_NURSE primary key (PATIENT_ID, VISIT_ID, OPER_ID)
)
----------------11.病人麻醉主记录---------------
create table MED_ANESTHESIA_PLAN
(
  PATIENT_ID                  NVARCHAR(20) not null,
  VISIT_ID                    NUMERIC(2) not null,
  OPER_ID                     NUMERIC(2) not null,
  HEIGHT                      NUMERIC(3),
  WEIGHT                      NUMERIC(4,1),
  BLOOD_PRESS                 NVARCHAR(20),
  CARDIOTACH                  NUMERIC(3),
  PLUS                        NUMERIC(3),
  BREATH                      NUMERIC(3),
  TEMPETURE                   NVARCHAR(10),
  CONSCIOUSNESS               NVARCHAR(20),
  MR_ABSTRACT                 NVARCHAR(200),
  ANES_HISTORY_INDICATOR      NUMERIC(1),
  ANES_HISTORY                NVARCHAR(80),
  ALERGY_DRUGS_INDICATOR      NVARCHAR(80),
  ALERGY_DRUGS                NVARCHAR(80),
  CERVIX                      NVARCHAR(40),
  TOOTH_EXAM                  NVARCHAR(40),
  MOUTH_OPEN_WIDTH            NVARCHAR(4),
  SOUND_OF_HEART_AND_LUNG     NVARCHAR(100),
  LIMB_INDICATOR              NUMERIC(1),
  LIMB_FEEL                   NVARCHAR(20),
  DOWN_LIMB_FEEL              NVARCHAR(20),
  VEIN                        NVARCHAR(16),
  SPINE_STATUS                NVARCHAR(40),
  SPINE_STATUS_OF_MIS         NVARCHAR(40),
  HEART_GRADE                 NVARCHAR(8),
  ECG_EXAM                    NVARCHAR(100),
  LUNG                        NVARCHAR(100),
  EXAM_X                      NVARCHAR(100),
  LIVER_INDICATOR             NUMERIC(1),
  LIVER                       NVARCHAR(100),
  KIDNEY_INDICATOR            NUMERIC(1),
  KIDNEY                      NVARCHAR(100),
  HEMOGLOBIN                  NVARCHAR(20),
  LAB_A                       NVARCHAR(20),
  BLOOD_CORPUSCLE             NVARCHAR(20),
  LAB_C                       NVARCHAR(20),
  BLEEDING_TIME               NVARCHAR(20),
  CRUOR_TIME                  NVARCHAR(20),
  CRUOR_ZYMOGEN_TIME          NVARCHAR(20),
  LAB_K                       NVARCHAR(20),
  LAB_NA                      NVARCHAR(20),
  LAB_CL                      NVARCHAR(20),
  LAB_GIU                     NVARCHAR(20),
  OTHER_LABS                  NVARCHAR(40),
  ASA_GRADE                   NVARCHAR(10),
  ANES_SUMMARY                NVARCHAR(200) default '无',
  OPERATION_CLASS             NVARCHAR(10),
  ANESTHESIA_DRUGS            NVARCHAR(100),
  DRUG_IN_OPERATION           NVARCHAR(100),
  ANES_START_TIME             DATETIME,
  ANES_END_TIME               DATETIME,
  ENTER_DATE_TIME         DATETIME,
  ENTERED_BY                  NVARCHAR(8),
  PRE_ANES_PHAM               NVARCHAR(200),
  PRE_ANES_PHAM_RESULT        NVARCHAR(1),
  ANESTHESIA_METHOD           NVARCHAR(60),
  ANESTHESIA_POSITION         NVARCHAR(10),
  END_INDICATOR               NUMERIC(1),
  BED_NO                      NVARCHAR(20),
  ORDER_TRANSFER              NUMERIC(1),
  CHARGE_TRANSFER             NUMERIC(1),
  OPERATION_NAME              NVARCHAR(100),
  ALLENS                      NVARCHAR(20),
  ALIMENTATION_STATUS         NVARCHAR(8),
  LAB_W                       NVARCHAR(20),
  LAB_ALT                     NVARCHAR(20),
  LAB_AST                     NVARCHAR(20),
  LAB_CR                      NVARCHAR(20),
  LAB_BUN                     NVARCHAR(20),
  LAB_HBCAB                   NVARCHAR(20),
  LAB_HBEAB                   NVARCHAR(20),
  LAB_HBBAG                   NVARCHAR(20),
  LAB_HBSAB                   NVARCHAR(20),
  LAB_HBSAG                   NVARCHAR(20),
  LAB_ANTI_HCV                NVARCHAR(20),
  LAB_CA                      NVARCHAR(20),
  PSYCHOSIS                   NVARCHAR(40),
  SOUND_OF_HEART              NVARCHAR(100),
  SOUND_OF_LUNG               NVARCHAR(100),
  HEART_COLOR_ULTRASONIC      NVARCHAR(100),
  ANESTHESIA_OPERATION        NVARCHAR(400),
  THORACIC_CAGE               NVARCHAR(100),
  INVESTIGATE_SUGGESTION      NVARCHAR(400),
  FLUID_PATH1                 NVARCHAR(20),
  FLUID_PATH2                 NVARCHAR(20),
  FLUID_PATH3                 NVARCHAR(20),
  FASTING                     NUMERIC(1) default 1,
  OPER_HISTORY_INDICATOR      NUMERIC(1),
  SMOKE_DRINK_INDICATOR       NUMERIC(1),
  BLOOD_TRANSFER_HISTORY      NUMERIC(1),
  SLEEPING_PILL_INDICATOR     NUMERIC(1),
  INTUB_DIFICULT              NUMERIC(1),
  MALLAMPATTI                 NVARCHAR(8),
  TONSIL_TUMESCENT_INDICATOR  NUMERIC(1),
  TONSIL_TUMESCENT_LEVEL      NVARCHAR(8),
  ABDOMEN                     NVARCHAR(40),
  ARTERY_VEIN_PUNCTURE_POS    NVARCHAR(20),
  OPERATION_POSITION          NVARCHAR(40),
  IN_ROOM_STATUS              NVARCHAR(10),
  HEART_FUN                   NVARCHAR(10),
  RBC_PLOT                    NVARCHAR(20),
  URINE_CONVENTIONAL          NVARCHAR(20),
  URINE_GIU                   NVARCHAR(20),
  UREA_N                      NVARCHAR(20),
  ALBUMIN                     NVARCHAR(20),
  WBC_BALL                    NVARCHAR(20),
  LIVER_FUNCTION              NVARCHAR(20),
  ECG                         NVARCHAR(100),
  HEART_CATHETERIZATION       NVARCHAR(100),
  ECHOCARDIOGRAPHY            NVARCHAR(100),
  X_RAY_EXAMINATION           NVARCHAR(100),
  EASEPAIN_TRANSFER           NUMERIC(1),
  PRE_SPEC_ANES_PHAM          NVARCHAR(100),
  URINE_RBC                   NVARCHAR(20),
  URINE_GLOBIN                NVARCHAR(20),
  KIDNEY_ANTIGEN              NVARCHAR(20),
  LAB_KZERO                   NVARCHAR(20),
  ERP_SIFT                    NVARCHAR(20),
  LAB_BGKT                    NVARCHAR(20),
  LAB_BILIRUBIN               NVARCHAR(20),
  LAB_CHOLESTEROL             NVARCHAR(20),
  ANES_HISTORY_INDICATOR_TEXT NVARCHAR(80),
  RETAKE_PIPE                 NVARCHAR(40),
  BED_LABEL                   NVARCHAR(12),
  ANES_KEEP                   NVARCHAR(100),
  VISIT_NURSE                 NVARCHAR(40),
  VISIT_DATE              DATETIME,
  OPERATION_DOC               NVARCHAR(40),
  BODY_STATUS                 NVARCHAR(40),
  SKIN_STATUS                 NVARCHAR(40),
  ACTIVE_STATUS               NVARCHAR(40),
  PSYCH_STATUS                NVARCHAR(40),
  PSYCH_MEMO                  NVARCHAR(200),
  DEGREE_STATUS               NVARCHAR(40),
  ECONOMY_STATUS              NVARCHAR(40),
  PAY_WAY                     NVARCHAR(40),
  COMM_MEMO                   NVARCHAR(200),
  BP_STATUS                   NVARCHAR(40),
  OPERATION_HISTORY           NVARCHAR(40),
  I_BP                        NVARCHAR(40),
  I_P                         NVARCHAR(40),
  I_GIU                       NVARCHAR(40),
  V_BP                        NVARCHAR(40),
  V_P                         NVARCHAR(40),
  V_GIU                       NVARCHAR(40),
  SYPHILS                     NVARCHAR(40),
  HIV_INFO                    NVARCHAR(20),
  ALT                         NVARCHAR(20),
  TP                          NVARCHAR(20),
  ALB                         NVARCHAR(20),
  GLB                         NVARCHAR(20),
  CR                          NVARCHAR(20),
  BUN                         NVARCHAR(20),
  UA                          NVARCHAR(20),
  GLU                         NVARCHAR(20),
  TG                          NVARCHAR(20),
  CHO                         NVARCHAR(20),
  HBSAG                       NVARCHAR(100),
  PT                          NVARCHAR(20),
  APTT                        NVARCHAR(20),
  FBG                         NVARCHAR(20),
  TT                          NVARCHAR(20),
  CO2CP                       NVARCHAR(20),
  AG                          NVARCHAR(20),
  TBIL                        NVARCHAR(20),
  DBIL                        NVARCHAR(20),
  NFKY                        NVARCHAR(20),
  QMS                         NVARCHAR(20),
  BLOOD_TYPE                  NVARCHAR(20),
  PROPORTION                  NVARCHAR(20),
  PH                          NVARCHAR(20),
  ALLEN                       NVARCHAR(10),
  STATE                       NVARCHAR(20),
  PLANDATETIME                DATETIME,
  BODY_AREA                   NVARCHAR(10),
  SECUNAME                    NVARCHAR(40),
  SECUNAME_1                  NVARCHAR(40),
  STATESPEC                   NVARCHAR(100),
  P_HISTORY1                  NVARCHAR(200),
  P_HISTORY2                  NVARCHAR(200),
  C_HISTORY1                  NVARCHAR(200),
  C_HISTORY2                  NVARCHAR(200),
  P_WORRY1                    NVARCHAR(10),
  P_WORRY2                    NVARCHAR(10),
  P_WORRY3                    NVARCHAR(10),
  P_WORRY4                    NVARCHAR(10),
  P_WORRY5                    NVARCHAR(10),
  P_WORRY6                    NVARCHAR(10),
  ANES_HISTORY_FAMILY         NVARCHAR(80),
  CARDIAC                     NVARCHAR(80),
  RESPIRATORY                 NVARCHAR(80),
  ENDOCRINE                   NVARCHAR(80),
  GL_GU                       NVARCHAR(80),
  NEUR_HEMA                   NVARCHAR(80),
  MUSCULAR_SKELETAL           NVARCHAR(80),
  HEART_DESC                  NVARCHAR(80),
  MALLAMPATTI_DESC            NVARCHAR(80),
  MEDICATIONS                 NVARCHAR(80),
  NPO_SINCE                   NVARCHAR(80),
  PSCE                        NVARCHAR(80),
  P_M1                        NVARCHAR(20),
  P_M2                        NVARCHAR(20),
  P_M3                        NVARCHAR(20),
  P_T1                        NVARCHAR(20),
  P_T2                        NVARCHAR(20),
  P_T3                        NVARCHAR(20),
  P_T4                        NVARCHAR(20),
  P_T5                        NVARCHAR(20),
  P_N1                        NVARCHAR(20),
  P_N2                        NVARCHAR(20),
  P_N3                        NVARCHAR(20),
  P_N4                        NVARCHAR(20),
  P_H1                        NVARCHAR(20),
  P_H2                        NVARCHAR(20),
  P_H3                        NVARCHAR(20),
  P_H4                        NVARCHAR(20),
  P_H5                        NVARCHAR(20),
  P_H6                        NVARCHAR(20),
  P_HL1                       NVARCHAR(20),
  P_HL2                       NVARCHAR(20),
  P_HL3                       NVARCHAR(20),
  P_HL4                       NVARCHAR(20),
  P_ANES_M1                   NVARCHAR(20),
  P_ANES_M2                   NVARCHAR(20),
  P_ACTION                    NVARCHAR(20),
  constraint PK_MED_ANESTHESIA_PLAN primary key (PATIENT_ID, VISIT_ID, OPER_ID)
)
----------------12.术后复苏记录---------------
create table MED_ANESTHESIA_RECOVERY
(
  PATIENT_ID             NVARCHAR(20) not null,
  VISIT_ID               NUMERIC(2) not null,
  OPER_ID                NUMERIC(2) not null,
  NOTE                   NVARCHAR(200),
  SUMM_START_TIME        DATETIME,
  SUMM_END_TIME          DATETIME not null,
  TOTAL_TIME             NUMERIC(4,1),
  IN_FLUIDS_AMOUNT       NUMERIC(6),
  OUT_FLUIDS_AMOUNT      NUMERIC(6),
  FS1                    NVARCHAR(50),
  FS2                    NVARCHAR(50),
  FS3                    NVARCHAR(50),
  FS4                    NVARCHAR(50),
  FS5                    NVARCHAR(50),
  FS6                    NVARCHAR(50),
  FS7                    NVARCHAR(50),
  FS8                    NVARCHAR(50),
  FS9                    NVARCHAR(50),
  FS10                   NVARCHAR(50),
  FS11                   NVARCHAR(50),
  FS12                   NVARCHAR(50),
  FS13                   NVARCHAR(50),
  FS14                   NVARCHAR(50),
  FS15                   NVARCHAR(50),
  FS16                   NVARCHAR(50),
  FS17                   NVARCHAR(50),
  FS18                   NVARCHAR(50),
  FS19                   NVARCHAR(50),
  FS20                   NVARCHAR(50),
  FS21                   NVARCHAR(100),
  FS22                   NVARCHAR(100),
  FS23                   NVARCHAR(100),
  FS24                   NVARCHAR(100),
  FS25                   NVARCHAR(100),
  FS26                   NVARCHAR(100),
  FS27                   NVARCHAR(100),
  FS28                   NVARCHAR(100),
  FS29                   NVARCHAR(100),
  FS30                   NVARCHAR(100),
  ENTERED_BY             NVARCHAR(8),
  RECOVERY_HOUR          NUMERIC(2),
  RECOVERY_MINUTE        NUMERIC(2),
  BLOOD_TRANSFERED       NUMERIC(6),
  BLOODPLASMA_TRANSFERED NUMERIC(6),
  OTHER_IN_AMOUNT        NUMERIC(6),
  ANALGESIC_METHOD       NVARCHAR(40),
  ENTERED_BY1            NVARCHAR(8),
  ENTERED_BY2            NVARCHAR(8),
  constraint PK_MED_ANESTHESIA_RECOVERY primary key (PATIENT_ID, VISIT_ID, OPER_ID, SUMM_END_TIME)
)
----------------13.麻醉总结---------------
create table MED_ANESTHESIA_SUMMARY
(
  STYLE_NO              NVARCHAR(8),
  PATIENT_ID            NVARCHAR(20) not null,
  VISIT_ID              NUMERIC(2) not null,
  OPER_ID               NUMERIC(2) not null,
  A1                    NVARCHAR(12),
  A2                    NVARCHAR(12),
  A3                    NVARCHAR(20),
  A4                    NVARCHAR(12),
  A5                    NVARCHAR(20),
  A6                    NVARCHAR(12),
  A7                    NVARCHAR(12),
  A8                    NVARCHAR(200),
  B1                    NVARCHAR(12),
  B2                    NVARCHAR(12),
  B3                    NVARCHAR(12),
  B4                    NVARCHAR(12),
  B5                    NVARCHAR(12),
  B6                    NVARCHAR(12),
  B7                    NVARCHAR(12),
  B8                    NVARCHAR(12),
  B9                    NVARCHAR(12),
  B10                   NVARCHAR(12),
  B11                   NVARCHAR(12),
  B12                   NVARCHAR(12),
  B13                   NVARCHAR(12),
  B14                   NVARCHAR(120),
  B15                   NVARCHAR(12),
  B16                   NVARCHAR(120),
  B17                   NVARCHAR(12),
  B18                   NVARCHAR(12),
  B19                   NVARCHAR(12),
  B20                   NVARCHAR(100),
  C1                    NVARCHAR(12),
  C2                    NVARCHAR(12),
  C3                    NVARCHAR(12),
  C4                    NVARCHAR(12),
  C5                    NVARCHAR(12),
  C6                    NVARCHAR(50),
  C7                    NVARCHAR(12),
  C8                    NVARCHAR(12),
  C9                    NVARCHAR(12),
  C10                   NVARCHAR(120),
  C11                   NVARCHAR(12),
  F1                    NVARCHAR(12),
  F2                    NVARCHAR(30),
  F3                    NVARCHAR(120),
  F4                    NVARCHAR(12),
  F5                    NVARCHAR(12),
  F6                    NVARCHAR(12),
  F7                    NVARCHAR(12),
  F8                    NVARCHAR(12),
  G1                    NVARCHAR(50),
  G2                    NVARCHAR(50),
  G3                    NVARCHAR(50),
  G4                    NVARCHAR(50),
  G5                    NVARCHAR(50),
  G6                    NVARCHAR(50),
  G7                    NVARCHAR(50),
  G8                    NVARCHAR(50),
  G9                    NVARCHAR(50),
  G10                   NVARCHAR(30),
  BEFORE_OPER           NVARCHAR(200),
  IN_OPER               NVARCHAR(1000),
  AFTER_OPER            NVARCHAR(200),
  END_INDICATOR         NUMERIC(1),
  DOCTOR                NVARCHAR(8),
  ENTER_DATE_TIME   DATETIME,
  ENTERED_BY            NVARCHAR(8),
  MR_ABSTRACT           NVARCHAR(200),
  TOF                   NVARCHAR(20),
  A9                    NVARCHAR(8),
  A10                   NVARCHAR(8),
  A11                   NVARCHAR(4),
  A12                   NVARCHAR(40),
  B21                   NUMERIC(3),
  B22                   NUMERIC(3),
  C12                   NVARCHAR(16),
  C13                   NVARCHAR(4),
  C14                   NVARCHAR(4),
  C15                   NVARCHAR(100),
  F9                    NVARCHAR(100),
  F10                   NVARCHAR(40),
  F11                   NVARCHAR(40),
  F12                   NVARCHAR(20),
  F13                   NVARCHAR(20),
  F14                   NVARCHAR(24),
  G11                   NVARCHAR(4),
  G12                   NVARCHAR(4),
  G13                   NVARCHAR(8),
  G14                   NVARCHAR(4),
  G15                   NVARCHAR(4),
  G16                   NVARCHAR(4),
  G17                   NVARCHAR(4),
  G18                   NVARCHAR(16),
  B23                   NVARCHAR(40),
  B24                   NUMERIC(8,4),
  B25                   NVARCHAR(120),
  B26                   NVARCHAR(12),
  B27                   NVARCHAR(120),
  B28                   NVARCHAR(12),
  B29                   NVARCHAR(12),
  B30                   NVARCHAR(12),
  B31                   NVARCHAR(12),
  ANESTHESIA_NO         NVARCHAR(16),
  C16                   NVARCHAR(30),
  B32                   NVARCHAR(12),
  B33                   NVARCHAR(12),
  B34                   NVARCHAR(12),
  B35                   NVARCHAR(12),
  B36                   NVARCHAR(12),
  A13                   NVARCHAR(12),
  A14                   NVARCHAR(12),
  A15                   NUMERIC(2),
  A16                   NVARCHAR(12),
  G19                   NVARCHAR(12),
  G20                   NVARCHAR(12),
  F15                   DATETIME,
  F16                   NVARCHAR(120),
  A17                   NVARCHAR(8),
  ANAESTHETIC_MACHINE   NVARCHAR(30),
  G21                   NVARCHAR(20),
  G22                   NVARCHAR(12),
  A53                   NVARCHAR(20),
  A24                   NVARCHAR(100),
  A25                   NUMERIC(1),
  A26                   NVARCHAR(100),
  A27                   NUMERIC(1),
  A28                   NUMERIC(1),
  A29                   NUMERIC(1),
  A30                   NUMERIC(1),
  A31                   NUMERIC(1),
  A32                   NUMERIC(3),
  A33                   NUMERIC(1),
  A34                   NUMERIC(1),
  A35                   NUMERIC(1),
  A36                   NUMERIC(1),
  A37                   NUMERIC(1),
  A38                   NUMERIC(1),
  A39                   NUMERIC(1),
  A40                   NUMERIC(1),
  A41                   NUMERIC(1),
  A42                   NUMERIC(3),
  A43                   NVARCHAR(50),
  A44                   NVARCHAR(10),
  A45                   NUMERIC(3),
  A46                   NUMERIC(3),
  A47                   NUMERIC(3),
  A48                   NUMERIC(3),
  A49                   NUMERIC(1),
  A50                   NUMERIC(3),
  A51                   NUMERIC(1),
  A52                   NUMERIC(4,2),
  A54                   NUMERIC(1),
  A55                   NUMERIC(1),
  A56                   NUMERIC(1),
  A57                   NUMERIC(1),
  A58                   NUMERIC(1),
  A59                   NUMERIC(1),
  A60                   NVARCHAR(12),
  A19                   NUMERIC(1),
  A20                   NUMERIC(1),
  A61                   NUMERIC(1),
  A62                   NUMERIC(1),
  B37                   NVARCHAR(12),
  BLOCK_PRECAVA_TIME    DATETIME,
  OPEN_PRECAVA_TIME     DATETIME,
  BLOCK_POSTCAVA_TIME   DATETIME,
  OPEN_POSTCAVA_TIME    DATETIME,
  BLOCK_AAO_TIME        DATETIME,
  OPEN_AAO_TIME         DATETIME,
  BLOCK_CYCLE_TIME      NUMERIC(4),
  CPB_TIME              NUMERIC(4),
  A64                   NUMERIC(1),
  A63                   NUMERIC(4,2),
  PRIMING_FLUID_AMOUNT  NUMERIC(7,2),
  DEHYDRATION_AMOUNT    NUMERIC(7,2),
  REMAIN_BLOOD_AMOUNT   NUMERIC(7,2),
  STOPJUMP_FLUID_AMOUNT NUMERIC(7,2),
  LOSE_AMOUNT           NUMERIC(7,2),
  CONDITION_OF_HEART    NVARCHAR(20),
  A65                   NVARCHAR(200),
  A66                   NVARCHAR(100),
  A67                   NVARCHAR(150),
  PRICKING_INTERSTICE   NVARCHAR(100),
  PCIA_PCEA 			NVARCHAR(10),
  YC_BP 				NVARCHAR(2),
  CVP 					NVARCHAR(2),
  constraint PK_MED_ANESTHESIA_SUMMARY primary key (PATIENT_ID, VISIT_ID, OPER_ID)
)
----------------14.手术病人麻醉记录初始化模板---------------
create table MED_ANESTHESIA_TEMPLET
(
  TEMPLET_NAME            NVARCHAR(40) not null,
  HEIGHT                  NUMERIC(3),
  WEIGHT                  NUMERIC(4,1),
  BLOOD_PRESS             NVARCHAR(20),
  CARDIOTACH              NUMERIC(3),
  PLUS                    NUMERIC(3),
  BREATH                  NUMERIC(3),
  TEMPETURE               NVARCHAR(10),
  CONSCIOUSNESS           NVARCHAR(8),
  MR_ABSTRACT             NVARCHAR(200),
  ANES_HISTORY_INDICATOR  NUMERIC(1),
  ANES_HISTORY            NVARCHAR(80),
  ALERGY_DRUGS_INDICATOR  NUMERIC(1),
  ALERGY_DRUGS            NVARCHAR(80),
  CERVIX                  NVARCHAR(40),
  TOOTH_EXAM              NVARCHAR(40),
  MOUTH_OPEN_WIDTH        NVARCHAR(4),
  SOUND_OF_HEART_AND_LUNG NVARCHAR(100),
  LIMB_FEEL               NVARCHAR(10),
  DOWN_LIMB_FEEL          NVARCHAR(10),
  VEIN                    NVARCHAR(16),
  SPINE_STATUS            NVARCHAR(40),
  SPINE_STATUS_OF_MIS     NVARCHAR(40),
  HEART_GRADE             NVARCHAR(8),
  ECG_EXAM                NVARCHAR(40),
  LUNG                    NVARCHAR(40),
  EXAM_X                  NVARCHAR(40),
  LIVER_INDICATOR         NUMERIC(1),
  LIVER                   NVARCHAR(40),
  KIDNEY_INDICATOR        NUMERIC(1),
  KIDNEY                  NVARCHAR(40),
  HEMOGLOBIN              NVARCHAR(20),
  LAB_A                   NVARCHAR(20),
  BLOOD_CORPUSCLE         NVARCHAR(20),
  LAB_C                   NVARCHAR(20),
  BLEEDING_TIME           NVARCHAR(20),
  CRUOR_TIME              NVARCHAR(20),
  CRUOR_ZYMOGEN_TIME      NVARCHAR(20),
  LAB_K                   NVARCHAR(20),
  LAB_NA                  NVARCHAR(20),
  LAB_CL                  NVARCHAR(20),
  LAB_GIU                 NVARCHAR(20),
  OTHER_LABS              NVARCHAR(40),
  ASA_GRADE               NVARCHAR(10),
  ANES_SUMMARY            NVARCHAR(200),
  PRE_ANES_PHAM           NVARCHAR(40),
  PRE_ANES_PHAM_RESULT    NVARCHAR(1),
  ANESTHESIA_METHOD       NVARCHAR(60),
  ANESTHESIA_POSITION     NVARCHAR(10),
  ECG 						NVARCHAR(100),
  X_RAY_EXAMINATION 			NVARCHAR(100),
  PRE_SPEC_ANES_PHAM 			NVARCHAR(100),
  ECHOCARDIOGRAPHY 				NVARCHAR(100),
  HEART_CATHETERIZATION 	NVARCHAR(100),
  NFKY 										NVARCHAR(20),
  ANES_KEEP 							NVARCHAR(100),
  HBSAG 									NVARCHAR(100),
  constraint PK_MED_ANESTHESIA_TEMPLET primary key (TEMPLET_NAME)
 )
 ----------------15.麻醉同意书模板---------------
create table MED_ANES_AGREEMENT_TEMPLET
(
  TEMPLET_NAME      NVARCHAR(40) not null,
  ANESTHESIA_METHOD NVARCHAR(60),
  CONTENTS          NVARCHAR(2000),
  CREATOR           NVARCHAR(8),
  CREATE_DATE_TIME  DATETIME,
  USE_INDICATOR     NUMERIC(1),
  constraint PK_MED_ANES_AGREEMENT_TEMPLET primary key (TEMPLET_NAME)
)
----------------16.不知道是什么表---------------
create table MED_ANES_ORDERS
(
  PATIENT_ID NVARCHAR(20) not null,
  VISIT_ID   NUMERIC(2) not null,
  OPER_ID    NUMERIC(2) not null,
  RESERVED1  NVARCHAR(200),
  RESERVED2  NVARCHAR(200),
  RESERVED3  NVARCHAR(200),
  RESERVED4  NVARCHAR(200),
  RESERVED5  NVARCHAR(200),
  RESERVED6  NVARCHAR(200),
  RESERVED7  NVARCHAR(200),
  RESERVED8  NVARCHAR(200),
  RESERVED9  NVARCHAR(200),
  RESERVED10 NVARCHAR(200),
  RESERVED11 NVARCHAR(200),
  B1         NVARCHAR(200),
  B2         NVARCHAR(200),
  B3         NVARCHAR(200),
  B5         NVARCHAR(30),
  B6         NVARCHAR(30),
  B7         NVARCHAR(30),
  B8         NVARCHAR(30),
  B9         NVARCHAR(30),
  B10        NVARCHAR(30),
  B11        NVARCHAR(30),
  B12        NVARCHAR(30),
  B13        NVARCHAR(30),
  B14        NVARCHAR(30),
  B15        NVARCHAR(30),
  B16        NVARCHAR(30),
  B17        NVARCHAR(30),
  B18        NVARCHAR(30),
  B19        NVARCHAR(30),
  C1         NVARCHAR(200),
  C2         NVARCHAR(200),
  C3         NVARCHAR(200),
  C4         NVARCHAR(200),
  C5         NVARCHAR(200),
  D1         NVARCHAR(20),
  D2         NVARCHAR(20),
  D3         NVARCHAR(20),
  D4         NVARCHAR(20),
  D5         NVARCHAR(20),
  D6         NVARCHAR(20),
  D7         NVARCHAR(20),
  D8         NVARCHAR(20),
  D9         NVARCHAR(20),
  E1         NVARCHAR(20),
  F1         NVARCHAR(20),
  G1         NVARCHAR(20),
  G2         NVARCHAR(20),
  G3         NVARCHAR(20),
  G4         NVARCHAR(20),
  H1         NVARCHAR(20),
  H2         NVARCHAR(20),
  H3         NVARCHAR(20),
  J1         NVARCHAR(20),
  J2         NVARCHAR(20),
  J3         NVARCHAR(20),
  J4         NVARCHAR(20),
  J5         NVARCHAR(20),
  J6         NVARCHAR(20),
  J7         NVARCHAR(20),
  J8         NVARCHAR(20),
  K1         NVARCHAR(30),
  L1         NVARCHAR(50),
  L2         NVARCHAR(20),
  L3         NVARCHAR(200),
  M1         NVARCHAR(200),
  N1         NVARCHAR(50),
  N2         NVARCHAR(200),
  N3         NVARCHAR(200),
  N4         NVARCHAR(200),
  N5         NVARCHAR(200),
  N6         NVARCHAR(200),
  N7         NVARCHAR(200),
  N8         NVARCHAR(200),
  P1         NVARCHAR(50),
  P2         NVARCHAR(30),
  P3         NVARCHAR(200),
  P4         NVARCHAR(30),
  P5         NVARCHAR(30),
  P6         NVARCHAR(30),
  P7         NVARCHAR(30),
  Q1         NVARCHAR(30),
  Q2         NVARCHAR(30),
  Q3         NVARCHAR(30),
  Q4         NVARCHAR(200),
  Q5         NVARCHAR(30),
  Q6         NVARCHAR(30),
  Q7         NVARCHAR(30),
  R1         NVARCHAR(100),
  R2         NVARCHAR(200),
  R3         NVARCHAR(100),
  R4         NVARCHAR(200),
  R5         NVARCHAR(200),
  R6         NVARCHAR(100),
  R7         NVARCHAR(100),
  R8         NVARCHAR(100),
  R9         NVARCHAR(100),
  B20        NVARCHAR(30),
  B4         NVARCHAR(200),
  P8         NVARCHAR(30),
  P9         NVARCHAR(30),
  A1         NVARCHAR(30),
  A2         NVARCHAR(30),
  A3         NVARCHAR(30),
  A4         NVARCHAR(30),
  A5         NVARCHAR(30),
  A6         NVARCHAR(30),
  A7         NVARCHAR(30),
  A8         NVARCHAR(30),
  A9         NVARCHAR(30),
  A10        NVARCHAR(30),
  constraint PK_MED_ANES_ORDERS primary key (PATIENT_ID, VISIT_ID, OPER_ID)
);
----------------17.不知道是什么表---------------
create table MED_ANES_ORDERS_TEMPLATE
(
  TEMPLATE_NAME NVARCHAR(40) not null,
  RESERVED1     NVARCHAR(200),
  RESERVED2     NVARCHAR(200),
  RESERVED3     NVARCHAR(200),
  RESERVED4     NVARCHAR(200),
  RESERVED5     NVARCHAR(200),
  RESERVED6     NVARCHAR(200),
  RESERVED7     NVARCHAR(200),
  RESERVED8     NVARCHAR(200),
  RESERVED9     NVARCHAR(200),
  RESERVED10    NVARCHAR(200),
  RESERVED11    NVARCHAR(200),
  constraint PK_MED_ANES_ORDERS_TEMPLATE primary key (TEMPLATE_NAME)
);
----------------18.不知道是什么表---------------
create table MED_ANES_RECORD_EXT_INFOR
(
  PATIENT_ID           NVARCHAR(10) not null,
  VISIT_ID             NUMERIC(2) not null,
  OPER_ID              NUMERIC(2) not null,
  NG                   NVARCHAR(20),
  BPAUTO               NVARCHAR(20),
  BPALINE              NVARCHAR(20),
  ECGII                NVARCHAR(20),
  ECGV5                NVARCHAR(20),
  URINEVOL             NVARCHAR(20),
  O2ANALIZER           NVARCHAR(20),
  ETCO2                NVARCHAR(20),
  SWANGANZ             NVARCHAR(20),
  PULSEOXIM            NVARCHAR(20),
  TEMP                 NVARCHAR(20),
  BIS                  NVARCHAR(20),
  TEE                  NVARCHAR(20),
  MACH                 NVARCHAR(20),
  PRESSUREPT           NVARCHAR(20),
  EYES                 NVARCHAR(20),
  HEATLAMP             NVARCHAR(20),
  HUMIDIFYER           NVARCHAR(20),
  FILTER               NVARCHAR(20),
  CELLSAVER            NVARCHAR(20),
  FLUIDWARMER          NVARCHAR(20),
  FACEMASK             NVARCHAR(20),
  LMA                  NVARCHAR(20),
  CIRCABS              NVARCHAR(20),
  INTUBATION           NVARCHAR(20),
  NASOTRACH            NVARCHAR(20),
  CDOUBLE              NVARCHAR(20),
  CUFF                 NVARCHAR(20),
  BBS                  NVARCHAR(20),
  BLADE                NVARCHAR(20),
  CO2                  NVARCHAR(20),
  LR                   NVARCHAR(20),
  PHARYNGEALVIEW       NVARCHAR(20),
  CSIZE                NVARCHAR(20),
  FIBEROPTICINTUBATION NVARCHAR(20),
  INDUCEDHYPOTHERM     NVARCHAR(20),
  INDUCEDHYPOTENS      NVARCHAR(20),
  EXTRACORPCIRC        NVARCHAR(20),
  PCIA                 NVARCHAR(20),
  PCEA                 NVARCHAR(20),
  OTHER                NVARCHAR(20),
  PAIN_MED             NVARCHAR(80),
  constraint PK_MED_ANES_RECORD_EXT_INFOR primary key (PATIENT_ID, VISIT_ID, OPER_ID)
);
----------------19.麻醉医生呼叫记录---------------
create table MED_CALL_RECORD
(
  CALL_TIME    DATETIME not null,--呼叫时间
  CALL_CONTENT NVARCHAR(40) not null,--呼叫内容
  MEMO         NVARCHAR(40),--备注
  constraint PK_MED_MED_CALL_RECORD primary key (CALL_TIME, CALL_CONTENT)
);
----------------20.不知道是什么表---------------
create table MED_DRUG_BILL
(
  PATIENT_ID NVARCHAR(20) not null,
  VISIT_ID   NUMERIC(6) not null,
  OPER_ID    NUMERIC(6) not null,
  DRUG_ID    NUMERIC(6) not null,
  DRUG_ITEM  NVARCHAR(40),
  NUM        NUMERIC(6)
);
----------------21.不知道是什么表---------------
create table MED_DRUG_INPUT_STORAGE
(
  INPUT_NO        NVARCHAR(20) not null,
  ITEM_NO         NUMERIC(3) not null,
  DRUG_CODE       NVARCHAR(40),
  DRUG_NAME       NVARCHAR(60),
  DRUG_UNITS      NVARCHAR(60),
  DRUG_SPEC       NVARCHAR(60),
  DRUG_SUPPLY     NVARCHAR(60),
  DRUG_NUM        NUMERIC(10,2),
  DRUG_COST       NUMERIC(10,2),
  INPUT_DATE  DATETIME,
  INPUT_OPER      NVARCHAR(10),
  IN_STATUS       NUMERIC(1),
  OUTPUT_NO_INHIS NVARCHAR(20),
  constraint PK_MED_DRUG_INPUT_STORAGE primary key (INPUT_NO, ITEM_NO)
);
----------------22.不知道是什么表---------------
create table MED_DRUG_STORAGE
(
  DRUG_CODE   NVARCHAR(40) not null,
  DRUG_NAME   NVARCHAR(60),
  DRUG_UNITS  NVARCHAR(60),
  DRUG_SPEC   NVARCHAR(60) not null,
  DRUG_SUPPLY NVARCHAR(60) not null,
  DRUG_NUM    NUMERIC(10,2),
  DRUG_TYPE   NUMERIC(1),
  INPUT_PY    NVARCHAR(60),
  constraint PK_MED_DRUG_STORAGE primary key (DRUG_CODE, DRUG_SPEC, DRUG_SUPPLY)
);
----------------23.麻醉收费单模板---------------
create table MED_ANES_BILL_TEMPLET
(
  TEMPLET    NVARCHAR(50) not null,
  ITEM_NO    NUMERIC(3) not null,
  ITEM_CLASS NVARCHAR(1),
  ITEM_CODE  NVARCHAR(10),
  ITEM_NAME  NVARCHAR(40),
  ITEM_SPEC  NVARCHAR(20),
  UNITS      NVARCHAR(8),
  AMOUNT     NUMERIC(6,2),
  COSTS      NUMERIC(8,2),
  constraint PK_MED_ANES_BILL_TEMPLET primary key (TEMPLET, ITEM_NO)
)
----------------24.麻醉用药单位描述---------------
create table MED_ANES_DRUG_UNITS_DESC
(
  UNITS_DESC     NVARCHAR(10) not null,
  DOSAGE         NUMERIC(8,2),
  DOSAGE_UNITS   NVARCHAR(10),
  DURATION_UNITS NVARCHAR(4),
  constraint PK_MED_ANES_DRUG_UNITS_DESC primary key (UNITS_DESC)
)
----------------25.麻醉查询结果---------------
create table MED_ANES_QUERY_RESULT_TEMP
(
  SESSION_SID NUMERIC(12) not null,
  SERIAL_NO   NUMERIC(8) not null,
  PATIENT_ID  NVARCHAR(20),
  VISIT_ID    NUMERIC(2),
  OPER_ID     NUMERIC(2),
  constraint PK_MED_ANES_QUERY_RESULT_TEMP primary key (SESSION_SID, SERIAL_NO)
)
----------------26.血气分析---------------
create table MED_BLOOD_GAS_ANALYSIS_REC
(
  PATIENT_ID      NVARCHAR(20) not null,
  VISIT_ID        NUMERIC(2) not null,
  OPER_ID         NUMERIC(2) not null,
  TIME_POINT      DATETIME not null,
  MEASURED_EVENT  NVARCHAR(16) not null,
  MEASURED_ITEM   NVARCHAR(16) not null,
  MEASURED_VALUE  NVARCHAR(16),
  UNITS           NVARCHAR(10),
  OPERATOR        NVARCHAR(8),
  MEASURED_SAMPLE NVARCHAR(30),
  constraint PK_MED_BLOOD_GAS_ANALYSIS_REC primary key (PATIENT_ID, VISIT_ID, OPER_ID, TIME_POINT, MEASURED_EVENT, MEASURED_ITEM)
)
----------------27.不知道是什么表---------------
create table MED_BLOOD_GAS_ITEM_DICT
(
  SERIAL_NO       NUMERIC(2),
  ITEM_CODE       NVARCHAR(16),
  ITEM_NAME       NVARCHAR(16) not null,
  VALID_INDICATOR NUMERIC(1),
  MUST_SELECT     NUMERIC(1),
  INPUT_CODE      NVARCHAR(8),
  UNITS           NVARCHAR(20),
  constraint PK_MED_BLOOD_GAS_ITEM_DICT primary key (ITEM_NAME)
)
----------------28.医院视频---------------
create table MED_CAMERA_DICT
(
  SERIAL_NO NUMERIC(4),
  CAM_NAME  NVARCHAR(30) not null,
  DEPT_CODE NVARCHAR(8),
  ROOM_NO   NVARCHAR(3),
  IPADDR    NVARCHAR(15),
  MACADDR   NVARCHAR(12),
  HTTP_PORT NVARCHAR(6),
  USER_NAME NVARCHAR(16),
  USER_PASS NVARCHAR(16),
  PATH_REC  NVARCHAR(28),
  constraint PK_MED_CAMERA_DICT primary key (CAM_NAME)
)
----------------29.科室基本情况---------------
create table MED_DEPT_INFO_DICT
(
  SERIAL_NO                  NUMERIC(3),
  DEPT_CODE                  NVARCHAR(8) not null,
  DEPT_NAME                  NVARCHAR(20),
  DIRECIOR_NAME              NVARCHAR(10),
  APPROVED_BED_NUM           NUMERIC(4),
  ACTUAL_BED_NUM             NUMERIC(4),
  APPROVED_DOCTOR_NUM        NUMERIC(3),
  DOCTOR_NUM_1               NUMERIC(3),
  DOCTOR_NUM_2               NUMERIC(3),
  APPROVED_NURSE_NUM         NUMERIC(3),
  HOLISTIC_NURSING_INDICATOR NUMERIC(1),
  NURSE_NUM_1                NUMERIC(3),
  NURSE_NUM_2                NUMERIC(3),
  NURSE_NUM_3                NUMERIC(3),
  DEPT_CLINIC_ATTR           NUMERIC(1),
  NURSING_INDEX_SYSTEM       NVARCHAR(30),
  HEADNURSE_NAME             NVARCHAR(10),
  INPUT_CODE                 NVARCHAR(8),
  constraint PK_MED_DEPT_INFO_DICT primary key (DEPT_CODE)
)
----------------30.药品领用明细---------------
create table MED_DRUG_BORROW_DETAIL
(
  BORROW_DATE DATETIME not null,
  BORROW_NO   NUMERIC(4) not null,
  ITEM_NO     NUMERIC(4) not null,
  DRUG_CODE   NVARCHAR(16),
  DRUG_SPEC   NVARCHAR(20),
  UNITS       NVARCHAR(8),
  SUPPLIER_ID NVARCHAR(60),
  QUANTITY    NUMERIC(12,2),
  constraint PK_MED_DRUG_BORROW_DETAIL primary key (BORROW_DATE, BORROW_NO, ITEM_NO)
)
----------------31.药品领用主记录---------------
create table MED_DRUG_BORROW_MASTER
(
  BORROW_DATE      DATETIME not null,
  BORROW_NO        NUMERIC(4) not null,
  EMP_NO           NVARCHAR(16),
  EMP_NAME         NVARCHAR(8),
  MEMOS            NVARCHAR(40),
  OPERATOR         NVARCHAR(8),
  RECORD_DATE_TIME DATETIME,
  CHECK_DATE_TIME  DATETIME,
  constraint PK_MED_DRUG_BORROW_MASTER primary key (BORROW_DATE, BORROW_NO)
)
----------------32.药品领用存量---------------
create table MED_DRUG_KEEP
(
  EMP_NO      NVARCHAR(16) not null,
  EMP_NAME    NVARCHAR(8),
  DRUG_CODE   NVARCHAR(16) not null,
  DRUG_SPEC   NVARCHAR(20) not null,
  UNITS       NVARCHAR(8),
  SUPPLIER_ID NVARCHAR(60) not null,
  QUANTITY    NUMERIC(12,2),
  constraint PK_MED_DRUG_KEEP primary key (EMP_NO, DRUG_CODE, DRUG_SPEC, SUPPLIER_ID)
)
----------------33.药品归还明细记录---------------
create table MED_DRUG_RETURN_DETAIL
(
  RETURN_DATE DATETIME not null,
  RETURN_NO   NUMERIC(4) not null,
  ITEM_NO     NUMERIC(4) not null,
  DRUG_CODE   NVARCHAR(16),
  DRUG_SPEC   NVARCHAR(20),
  UNITS       NVARCHAR(8),
  SUPPLIER_ID NVARCHAR(60),
  QUANTITY    NUMERIC(12,2),
  constraint PK_MED_DRUG_RETURN_DETAIL primary key (RETURN_DATE, RETURN_NO, ITEM_NO)
)
----------------34.麻药归还主记录---------------
create table MED_DRUG_RETURN_MASTER
(
  RETURN_DATE      DATETIME not null,
  RETURN_NO        NUMERIC(4) not null,
  EMP_NO           NVARCHAR(16),
  EMP_NAME         NVARCHAR(8),
  MEMOS            NVARCHAR(40),
  OPERATOR         NVARCHAR(8),
  RECORD_DATE_TIME DATETIME,
  CHECK_DATE_TIME  DATETIME,
  RETURN_CLASS     NVARCHAR(8),
  constraint PK_MED_DRUG_RETURN_MASTER primary key (RETURN_DATE, RETURN_NO)
)
----------------35.药品使用明细记录---------------
create table MED_DRUG_USE_DETAIL
(
  USE_DATE      DATETIME not null,
  USE_NO        NUMERIC(4) not null,
  ITEM_NO       NUMERIC(3) not null,
  DRUG_CODE     NVARCHAR(16) not null,
  DRUG_SPEC     NVARCHAR(20) not null,
  DRUG_NAME     NVARCHAR(60),
  SUPPLIER_NAME NVARCHAR(60),
  BATCH_NO      NVARCHAR(16),
  PACKAGE_SPEC  NVARCHAR(20),
  PACKAGE_UNITS NVARCHAR(8),
  QUANTITY      NUMERIC(6,2),
  COSTS         NUMERIC(8,2),
  PAYMENTS      NUMERIC(8,2),
  KEEP_INDICATOR NUMERIC(1),
  constraint PK_MED_DRUG_USE_DETAIL primary key (USE_DATE, USE_NO, ITEM_NO)
)
----------------36.不知道是什么表---------------
create table MED_MTRL_INPUT_STORAGE
(
  INPUT_NO        NVARCHAR(20) not null,
  ITEM_NO         NUMERIC(3) not null,
  MTRL_CODE       NVARCHAR(40),
  MTRL_NAME       NVARCHAR(60),
  MTRL_SPEC       NVARCHAR(60),
  MTRL_SUPPLY     NVARCHAR(60),
  MTRL_NUM        NUMERIC(10,2),
  MTRL_COST       NUMERIC(10,2),
  INPUT_DATE      DATETIME,
  INPUT_OPER      NVARCHAR(10),
  OUTPUT_NO_INHIS NVARCHAR(20),
  IN_STATUS       NUMERIC(1),
  MTRL_UNITS      NVARCHAR(60),
  constraint PK_MED_MTRL_INPUT_STORAGE primary key (INPUT_NO, ITEM_NO)
);
----------------37.耗材库存单位字典---------------
create table MED_MTRL_STORAGE
(
  MTRL_CODE   NVARCHAR(40) not null,
  MTRL_NAME   NVARCHAR(60),
  MTRL_SPEC   NVARCHAR(60) not null,
  MTRL_SUPPLY NVARCHAR(60) not null,
  MTRL_NUM    NUMERIC(10,2),
  MTRL_TYPE   NUMERIC(1),
  INPUT_PY    NVARCHAR(60),
  MTRL_UNITS  NVARCHAR(60),
  MTRL_PRICE  NUMERIC(10,2),
  constraint PK_MED_MTRL_STORAGE primary key (MTRL_CODE, MTRL_SPEC, MTRL_SUPPLY)
);
----------------38.药品使用主记录---------------
create table MED_DRUG_USE_MASTER
(
  USE_DATE        DATETIME not null,
  USE_NO          NUMERIC(4) not null,
  STORAGE_CODE    NVARCHAR(10) not null,
  PATIENT_ID      NVARCHAR(20),
  VISIT_ID        NUMERIC(2),
  OPER_ID         NUMERIC(2),
  COSTS           NUMERIC(8,2),
  PAYMENTS        NUMERIC(8,2),
  OPER_DOCTOR     NVARCHAR(8),
  ANES_DOCTOR     NVARCHAR(8),
  OPERATION_NURSE NVARCHAR(8),
  SUPPLY_NURSE    NVARCHAR(8),
  CHECK_DATE_TIME DATETIME,
  KEEP_INDICATOR  NUMERIC(1),
  constraint PK_MED_DRUG_USE_MASTER primary key (USE_DATE, USE_NO)
)
----------------39.麻醉事件对应收费信息---------------
create table MED_EVENT_VS_CHARGE
(
  EVENT_ITEM_CLASS  NVARCHAR(16),
  EVENT_ITEM_NAME   NVARCHAR(60),
  EVENT_ITEM_SPEC   NVARCHAR(20),
  CHARGE_ITEM_NO    NUMERIC(2),
  CHARGE_ITEM_CLASS NVARCHAR(16),
  CHARGE_ITEM_CODE  NVARCHAR(10),
  CHARGE_ITEM_NAME  NVARCHAR(60),
  CHARGE_ITEM_SPEC  NVARCHAR(20),
  AMOUNT            NUMERIC(4),
  UNITS             NVARCHAR(8),
  NOTE              NVARCHAR(1),
  constraint pk_MED_EVENT_VS_CHARGE primary key (EVENT_ITEM_CLASS, EVENT_ITEM_NAME, CHARGE_ITEM_NO)
)
----------------40.病人费用明细记录---------------
create table MED_INP_BILL_DETAIL
(
  PATIENT_ID             NVARCHAR(20) not null,
  VISIT_ID               NUMERIC(2) not null,
  ITEM_NO                NUMERIC(6) not null,
  ITEM_CLASS             NVARCHAR(1),
  ITEM_NAME              NVARCHAR(60),
  ITEM_CODE              NVARCHAR(16),
  ITEM_SPEC              NVARCHAR(20),
  AMOUNT                 NUMERIC(6,2),
  UNITS                  NVARCHAR(8),
  ORDERED_BY             NVARCHAR(8),
  PERFORMED_BY           NVARCHAR(8),
  COSTS                  NUMERIC(8,2),
  CHARGES                NUMERIC(8,2),
  BILLING_DATE_TIME      DATETIME,
  OPERATOR_NO            NVARCHAR(4),
  RCPT_NO                NVARCHAR(8),
  SPECIAL_FEE            NUMERIC(8,2),
  INSUR_FEE              NVARCHAR(3),
  WARD_CODE              NVARCHAR(8),
  ORDERED_DOCTOR_GROUP   NVARCHAR(8),
  ORDERED_EMP_NO         NVARCHAR(6),
  ORDERED_DOCTOR         NVARCHAR(8),
  PERFORMED_DOCTOR_GROUP NVARCHAR(8),
  PERFORMED_EMP_NO       NVARCHAR(6),
  PERFORMED_DOCTOR       NVARCHAR(8),
  REFUND_ITEM_NO         NUMERIC(6),
  constraint PK_MED_INP_BILL_DETAIL primary key (PATIENT_ID, VISIT_ID, ITEM_NO)
)
----------------41.术后麻醉随访记录初始化模板---------------
create table MED_INQUIRY_TEMPLET
(
  TEMPLET_NAME              NVARCHAR(40) not null,
  BREATH                    NVARCHAR(10),
  THROAT_ACHE               NUMERIC(1),
  SOUND_HOARSENESS          NUMERIC(1),
  BLOOD_PRESS               NVARCHAR(20),
  CARDIOTACH                NVARCHAR(10),
  NAUSEA                    NUMERIC(1),
  CONSCIOUSNESS             NVARCHAR(8),
  HEADACHE                  NUMERIC(1),
  LIMB                      NVARCHAR(20),
  EMICTION_RETENTION        NUMERIC(1),
  PUNCTURE_POSTION_OF_ACHE  NUMERIC(1),
  PUNCTURE_POS_OF_TURGES    NUMERIC(1),
  MEMO                      NVARCHAR(100),
  ENTIRE_REVIVAL_TIME       NVARCHAR(20),
  TRAUMA_INDICATOR          NUMERIC(1),
  FOCUS_SCATTER_INDICATOR   NUMERIC(1),
  LUNG_DISTEND_INDICATOR    NUMERIC(1),
  ABDOMEN_DISTEND_INDICATOR NUMERIC(1),
  INQUIRY_DOCTOR            NVARCHAR(8),
  FS1                       NUMERIC(2),
  FS2                       NUMERIC(2),
  FS3                       NUMERIC(2),
  FS4                       NUMERIC(2),
  FS5                       NUMERIC(2),
  FS6                       NUMERIC(2),
  constraint PK_MED_INQUIRY_TEMPLET primary key (TEMPLET_NAME)
)
----------------42.医院名称控制---------------
create table MED_MEDAPP_VER
(
  APPNAME NVARCHAR(30) not null,
  HISID   NVARCHAR(30) not null,
  HISNAME NVARCHAR(50) not null,
  MEMO    NVARCHAR(100),
  constraint PK_MED_MEDAPP_VER primary key (APPNAME)
)
----------------43.混合液---------------
create table MED_MIXED_DRUG
(
  MIXED_DRUG_NAME NVARCHAR(100) not null,
  SERIAL_NO       NUMERIC(2),
  DRUG_NAME       NVARCHAR(40) not null,
  ITEM_CODE       NVARCHAR(10),
  ITEM_SPEC       NVARCHAR(20),
  CONCENTRATION   NUMERIC(8,4),
  PROPORTION      NUMERIC(8,4),
  DOSAGE          NUMERIC(8,4),
  DOSAGE_UNITS    NVARCHAR(8),
  constraint PK_MED_MIXED_DRUG primary key (MIXED_DRUG_NAME, DRUG_NAME)
)
----------------44.监控项目分类---------------
create table MED_MONITOR_FUNCTION
(
  FUNCTION_NAME NVARCHAR(20) not null,
  ITEM_CODE     NVARCHAR(6) not null,
  SERIAL_NO     NUMERIC(6),
  constraint PK_MED_MONITOR_FUNCTION primary key (FUNCTION_NAME, ITEM_CODE)
)
----------------45.耗材出库明细记录--------------
create table MED_MTRL_EXPORT_DETAIL
(
  DOCUMENT_NO         NVARCHAR(10) not null,
  ITEM_NO             NUMERIC(4) not null,
  MTRL_CODE           NVARCHAR(16),
  MTRL_SPEC           NVARCHAR(20),
  UNITS               NVARCHAR(8),
  BATCH_NO            NVARCHAR(16),
  ANTISEPSIS_DATE     DATETIME,
  EXPIRE_DATE         DATETIME,
  SUPPLIER_ID         NVARCHAR(16),
  IMPORT_DOCUMENT_NO  NVARCHAR(10),
  PURCHASE_PRICE      NUMERIC(10,4),
  RETAIL_PRICE        NUMERIC(10,4),
  PACKAGE_SPEC        NVARCHAR(20),
  QUANTITY            NUMERIC(12,2),
  PACKAGE_UNITS       NVARCHAR(8),
  SUB_PACKAGE_1       NUMERIC(12,2),
  SUB_PACKAGE_UNITS_1 NVARCHAR(8),
  SUB_PACKAGE_SPEC_1  NVARCHAR(20),
  SUB_PACKAGE_2       NUMERIC(12,2),
  SUB_PACKAGE_UNITS_2 NVARCHAR(8),
  SUB_PACKAGE_SPEC_2  NVARCHAR(20),
  constraint PK_MED_MTRL_EXPORT_DETAIL primary key (DOCUMENT_NO, ITEM_NO)
)
----------------46.HIS耗材出库记录--------------
create table MED_MTRL_EXPORT_DETAIL_HIS
(
  HIS_STORAGE_CODE    NVARCHAR(32) not null,
  HIS_DOCUMENT_NO     NVARCHAR(10) not null,
  ITEM_NO             NUMERIC(4) not null,
  EXPORT_CLASS        NVARCHAR(8),
  EXPORT_DATE         DATETIME,
  MTRL_CODE           NVARCHAR(16),
  MTRL_SPEC           NVARCHAR(20),
  UNITS               NVARCHAR(8),
  BATCH_NO            NVARCHAR(16),
  ANTISEPSIS_DATE     DATETIME,
  EXPIRE_DATE         DATETIME,
  SUPPLIER_ID         NVARCHAR(16),
  PURCHASE_PRICE      NUMERIC(10,4),
  DISCOUNT            NUMERIC(5,2),
  RETAIL_PRICE        NUMERIC(10,4),
  PACKAGE_SPEC        NVARCHAR(20),
  QUANTITY            NUMERIC(12,2),
  PACKAGE_UNITS       NVARCHAR(8),
  SUB_PACKAGE_1       NUMERIC(12,2),
  SUB_PACKAGE_UNITS_1 NVARCHAR(8),
  SUB_PACKAGE_SPEC_1  NVARCHAR(20),
  SUB_PACKAGE_2       NUMERIC(12,2),
  SUB_PACKAGE_UNITS_2 NVARCHAR(8),
  SUB_PACKAGE_SPEC_2  NVARCHAR(20),
  INVOICE_NO          NVARCHAR(10),
  INVOICE_DATE        DATETIME,
  ENTER_OPERATOR      NVARCHAR(30),
  APPLY_OPERATOR      NVARCHAR(30),
  CHECK_OPERATOR      NVARCHAR(30),
  ACQUIRED_DATE       DATETIME,
  STORAGE_CODE        NVARCHAR(10),
  DOCUMENT_NO         NVARCHAR(10),
  constraint PK_MED_MTRL_EXPORT_DETAIL_HIS primary key (HIS_STORAGE_CODE, HIS_DOCUMENT_NO, ITEM_NO)
)
----------------47.不知道是什么表--------------
create table MED_MTRL_EXPORT_MASTER
(
  DOCUMENT_NO        NVARCHAR(10) not null,
  STORAGE_CODE       NVARCHAR(10),
  EXPORT_DATE    DATETIME,
  RECEIVER           NVARCHAR(60),
  ACCOUNT_RECEIVABLE NUMERIC(10,2),
  ACCOUNT_PAYED      NUMERIC(10,2),
  ADDITIONAL_FEE     NUMERIC(8,2),
  EXPORT_CLASS       NVARCHAR(8),
  SUB_STORAGE        NVARCHAR(8),
  ACCOUNT_INDICATOR  NUMERIC(1),
  MEMOS              NVARCHAR(20),
  OPERATOR           NVARCHAR(8),
  HIS_DOCUMENT_NO    NVARCHAR(16),
  constraint PK_MTRL_EXPORT_MASTER primary key (DOCUMENT_NO)
)
----------------48.耗材入库明细记录--------------
create table MED_MTRL_IMPORT_DETAIL
(
  DOCUMENT_NO         NVARCHAR(10) not null,
  ITEM_NO             NUMERIC(4) not null,
  MTRL_CODE           NVARCHAR(16),
  MTRL_SPEC           NVARCHAR(20),
  UNITS               NVARCHAR(8),
  BATCH_NO            NVARCHAR(16),
  ANTISEPSIS_DATE     DATETIME,
  EXPIRE_DATE         DATETIME,
  SUPPLIER_ID         NVARCHAR(10),
  PURCHASE_PRICE      NUMERIC(10,4),
  DISCOUNT            NUMERIC(5,2),
  RETAIL_PRICE        NUMERIC(10,4),
  PACKAGE_SPEC        NVARCHAR(20),
  QUANTITY            NUMERIC(12,2),
  PACKAGE_UNITS       NVARCHAR(8),
  SUB_PACKAGE_1       NUMERIC(12,2),
  SUB_PACKAGE_UNITS_1 NVARCHAR(8),
  SUB_PACKAGE_SPEC_1  NVARCHAR(20),
  SUB_PACKAGE_2       NUMERIC(12,2),
  SUB_PACKAGE_UNITS_2 NVARCHAR(8),
  SUB_PACKAGE_SPEC_2  NVARCHAR(20),
  INVOICE_NO          NVARCHAR(10),
  INVOICE_DATE        DATETIME,
  constraint PK_MTRL_IMPORT_DETAIL primary key (DOCUMENT_NO, ITEM_NO)
)
----------------49.耗材入库主记录--------------
create table MED_MTRL_IMPORT_MASTER
(
  DOCUMENT_NO        NVARCHAR(10) not null,
  STORAGE_CODE       NVARCHAR(10),
  IMPORT_DATE    DATETIME,
  SUPPLIER           NVARCHAR(60),
  ACCOUNT_RECEIVABLE NUMERIC(10,2),
  ACCOUNT_PAYED      NUMERIC(10,2),
  ADDITIONAL_FEE     NUMERIC(8,2),
  IMPORT_CLASS       NVARCHAR(8),
  SUB_STORAGE        NVARCHAR(8),
  ACCOUNT_INDICATOR  NUMERIC(1),
  MEMOS              NVARCHAR(20),
  OPERATOR           NVARCHAR(8),
  constraint PK_MTRL_IMPORT_MASTER primary key (DOCUMENT_NO)
)
----------------50.耗材价表--------------
create table MED_MTRL_PRICE_LIST
(
  MTRL_CODE    NVARCHAR(16) not null,
  MTRL_SPEC    NVARCHAR(20) not null,
  SUPPLIER_ID  NVARCHAR(10) not null,
  UNITS        NVARCHAR(8),
  TRADE_PRICE  NUMERIC(10,4),
  RETAIL_PRICE NUMERIC(10,4),
  START_DATE   DATETIME not null,
  STOP_DATE    DATETIME,
  MEMOS        NVARCHAR(20),
  constraint PK_MED_MTRL_PRICE_LIST primary key (MTRL_CODE, MTRL_SPEC, SUPPLIER_ID, START_DATE)
)
----------------51.耗材调价盈亏记录--------------
create table MED_MTRL_PRICE_PROFIT
(
  STORAGE_CODE        NVARCHAR(10) not null,
  PRICE_ADJUSTED_DATE DATETIME not null,
  MTRL_CODE           NVARCHAR(16) not null,
  MTRL_SPEC           NVARCHAR(20) not null,
  SUPPLIER_ID         NVARCHAR(16),
  PACKAGE_SPEC        NVARCHAR(20) not null,
  PACKAGE_UNITS       NVARCHAR(8),
  CURRENT_QUANTITY    NUMERIC(12,2),
  OLD_PRICE           NUMERIC(10,4),
  NEW_PRICE           NUMERIC(10,4),
  constraint PK_MTRL_PRICE_PROFIT primary key (STORAGE_CODE, MTRL_CODE, MTRL_SPEC, PACKAGE_SPEC, PRICE_ADJUSTED_DATE)
)
----------------52.耗材发放申请--------------
create table MED_MTRL_PROVIDE_APPLICATION
(
  APPLICANT_STORAGE   NVARCHAR(10) not null,
  PROVIDE_STORAGE     NVARCHAR(10) not null,
  ITEM_NO             NUMERIC(4) not null,
  MTRL_CODE           NVARCHAR(16),
  MTRL_SPEC           NVARCHAR(20),
  UNITS               NVARCHAR(8),
  PACKAGE_SPEC        NVARCHAR(20),
  QUANTITY            NUMERIC(12,2),
  PACKAGE_UNITS       NVARCHAR(8),
  APPLICANT_DATE_TIME DATETIME,
  constraint PK_MTRL_PROVIDE_APPLICATION primary key (APPLICANT_STORAGE, PROVIDE_STORAGE, ITEM_NO)
)
----------------53.耗材发放通知--------------
create table MED_MTRL_PROVIDE_NOTICE
(
  PROVIDE_STORAGE   NVARCHAR(10) not null,
  APPLICANT_STORAGE NVARCHAR(10) not null,
  DOCUMENT_NO       NVARCHAR(10) not null,
  constraint PK_MTRL_PROVIDE_NOTICE primary key (PROVIDE_STORAGE, DOCUMENT_NO)
)
----------------54.耗材库存--------------
create table MED_MTRL_STOCK
(
  STORAGE_CODE        NVARCHAR(10) not null,
  MTRL_CODE           NVARCHAR(16) not null,
  MTRL_SPEC           NVARCHAR(20) not null,
  UNITS               NVARCHAR(8),
  BATCH_NO            NVARCHAR(16) not null,
  ANTISEPSIS_DATE     DATETIME,
  EXPIRE_DATE         DATETIME,
  SUPPLIER_ID         NVARCHAR(10) not null,
  PURCHASE_PRICE      NUMERIC(10,4),
  DISCOUNT            NUMERIC(5,2),
  PACKAGE_SPEC        NVARCHAR(20) not null,
  QUANTITY            NUMERIC(12,2),
  PACKAGE_UNITS       NVARCHAR(8),
  SUB_PACKAGE_1       NUMERIC(12,2),
  SUB_PACKAGE_UNITS_1 NVARCHAR(8),
  SUB_PACKAGE_SPEC_1  NVARCHAR(20),
  SUB_PACKAGE_2       NUMERIC(12,2),
  SUB_PACKAGE_UNITS_2 NVARCHAR(8),
  SUB_PACKAGE_SPEC_2  NVARCHAR(20),
  SUB_STORAGE         NVARCHAR(8),
  LOCATION            NVARCHAR(20),
  DOCUMENT_NO         NVARCHAR(10),
  SUPPLY_INDICATOR    NUMERIC(1),
  constraint PK_MTRL_STOCK primary key (STORAGE_CODE, MTRL_CODE, MTRL_SPEC, SUPPLIER_ID, PACKAGE_SPEC, BATCH_NO)
)
----------------55.耗材结转记录--------------
create table MED_MTRL_STOCK_BALANCE
(
  STORAGE_CODE     NVARCHAR(10) not null,
  YEAR_MONTH       DATETIME not null,
  MTRL_CODE        NVARCHAR(16) not null,
  MTRL_SPEC        NVARCHAR(20) not null,
  SUPPLIER_ID      NVARCHAR(16) not null,
  PACKAGE_SPEC     NVARCHAR(20) not null,
  PACKAGE_UNITS    NVARCHAR(8),
  INITIAL_QUANTITY NUMERIC(12,2),
  INITIAL_MONEY    NUMERIC(10,2),
  IMPORT_QUANTITY  NUMERIC(12,2),
  IMPORT_MONEY     NUMERIC(10,2),
  EXPORT_QUANTITY  NUMERIC(12,2),
  EXPORT_MONEY     NUMERIC(10,2),
  INVENTORY        NUMERIC(12,2),
  INVENTORY_MONEY  NUMERIC(10,2),
  PROFIT           NUMERIC(10,2),
  constraint PK_MTRL_STOCK_BALANCE primary key (YEAR_MONTH, STORAGE_CODE, MTRL_CODE, MTRL_SPEC, SUPPLIER_ID, PACKAGE_SPEC)
)
----------------56.耗材库存单位字典--------------
create table MED_MTRL_STORAGE_DEPT
(
  STORAGE_CODE     NVARCHAR(10) not null,
  STORAGE_NAME     NVARCHAR(40) not null,
  IMPORT_NO_PREFIX NVARCHAR(6),
  IMPORT_NO_AVA    NUMERIC(6),
  EXPORT_NO_PREFIX NVARCHAR(6),
  EXPORT_NO_AVA    NUMERIC(6),
  EXTERNAL_STORATE NVARCHAR(1),
  CODE_IN_HIS      NVARCHAR(32),
  constraint PK_MED_MTRL_STORAGE_DEPT primary key (STORAGE_CODE)
)
----------------57.耗材库存量定义--------------
create table MED_MTRL_STORAGE_PROFILE
(
  STORAGE_CODE       NVARCHAR(8) not null,
  MTRL_CODE          NVARCHAR(20) not null,
  MTRL_SPEC          NVARCHAR(20) not null,
  UNITS              NVARCHAR(8),
  AMOUNT_PER_PACKAGE NUMERIC(5) not null,
  PACKAGE_UNITS      NVARCHAR(8),
  UPPER_LEVEL        NUMERIC(6),
  LOW_LEVEL          NUMERIC(6),
  SUB_STORAGE        NVARCHAR(8),
  constraint PK_MTRL_STORAGE_PROFILE primary key (STORAGE_CODE, MTRL_CODE, MTRL_SPEC, AMOUNT_PER_PACKAGE)
)
----------------58.耗材库存单位库房字典--------------
create table MED_MTRL_SUB_STORAGE_DICT
(
  STORAGE_CODE     NVARCHAR(10) not null,
  SUB_STORAGE      NVARCHAR(8) not null,
  IMPORT_NO_PREFIX NVARCHAR(6),
  IMPORT_NO_AVA    NUMERIC(6),
  EXPORT_NO_PREFIX NVARCHAR(6),
  EXPORT_NO_AVA    NUMERIC(6),
  constraint PK_MED_MTRL_SUB_STORAGE_DICT primary key (STORAGE_CODE, SUB_STORAGE)
)
----------------59.耗材使用明细记录--------------
create table MED_MTRL_USE_DETAIL
(
  USE_DATE  DATETIME not null,
  USE_NO        NUMERIC(4) not null,
  ITEM_NO       NUMERIC(3) not null,
  MTRL_CODE     NVARCHAR(16) not null,
  MTRL_SPEC     NVARCHAR(20) not null,
  MTRL_NAME     NVARCHAR(60),
  SUPPLIER_ID   NVARCHAR(16),
  BATCH_NO      NVARCHAR(16),
  PACKAGE_SPEC  NVARCHAR(20),
  PACKAGE_UNITS NVARCHAR(8),
  QUANTITY      NUMERIC(6,2),
  COSTS         NUMERIC(8,2),
  PAYMENTS      NUMERIC(8,2),
  MTRL_NO 			NVARCHAR(40),
  constraint PK_MED_MTRL_USE_DETAIL primary key (USE_DATE, USE_NO, ITEM_NO)
)
----------------60.术后医嘱--------------
create table MED_OPERATION_AFTER_ORDER
(
  PATIENT_ID NVARCHAR(20) not null,
  VISIT_ID   NUMERIC(2) not null,
  OPER_ID    NUMERIC(2) not null,
  A01        NVARCHAR(60),
  A02        NVARCHAR(16),
  A03        NVARCHAR(16),
  A031       NVARCHAR(16),
  A04        NVARCHAR(16),
  A041       NVARCHAR(16),
  A05        NVARCHAR(16),
  A06        NVARCHAR(16),
  A07        NVARCHAR(32),
  A09        NVARCHAR(16),
  A10        NVARCHAR(200),
  constraint PK_MED_OPERATION_AFTER_ORDER primary key (PATIENT_ID, VISIT_ID, OPER_ID)
);
----------------61.耗材使用主记录--------------
create table MED_MTRL_USE_MASTER
(
  USE_DATE    DATETIME not null,
  USE_NO          NUMERIC(4) not null,
  STORAGE_CODE    NVARCHAR(10) not null,
  PATIENT_ID      NVARCHAR(20),
  VISIT_ID        NUMERIC(2),
  OPER_ID         NUMERIC(2),
  COSTS           NUMERIC(8,2),
  PAYMENTS        NUMERIC(8,2),
  OPER_DOCTOR     NVARCHAR(8),
  ANES_DOCTOR     NVARCHAR(8),
  OPERATION_NURSE NVARCHAR(8),
  SUPPLY_NURSE    NVARCHAR(8),
  constraint PK_MED_MTRL_USE_MASTER primary key (USE_DATE, USE_NO)
)
----------------62.手术间--------------
create table MED_OPERATING_ROOM
(
  ROOM_NO      NVARCHAR(4) not null,
  DEPT_CODE    NVARCHAR(8) not null,
  LOCATION     NVARCHAR(20),
  STATUS       NVARCHAR(1),
  BED_ID       NUMERIC(4),
  BED_LABEL    NVARCHAR(12),
  MONITOR_CODE NVARCHAR(5),
  BRANCH_NO    NUMERIC(2),
  SAM_SPACE    NUMERIC(4),
  PATIENT_ID   NVARCHAR(20),
  VISIT_ID     NUMERIC(5),
  OPER_ID      NUMERIC(2),
  BED_TYPE     NVARCHAR(1) default '0',
  constraint PK_MED_OPERATING_ROOM primary key (ROOM_NO, DEPT_CODE)
)
----------------63术后镇痛记录--------------
create table MED_OPERATION_ANALGESIC
(
  PATIENT_ID                    NVARCHAR(20) not null,
  VISIT_ID                      NUMERIC(2) not null,
  OPER_ID                       NUMERIC(2) not null,
  START_DATE_TIME           DATETIME,
  ANES_NO                       NVARCHAR(10),
  MACHINE_ID                    NVARCHAR(18),
  OTHER_ILLNESS                 NVARCHAR(40),
  ANALGESIC1                    NVARCHAR(40),
  ANALGESIC1_DOSAGE             NUMERIC(8,4),
  ANALGESIC1_DOSAGE_UNITS       NVARCHAR(8),
  ANALGESIC2                    NVARCHAR(40),
  ANALGESIC2_DOSAGE             NUMERIC(8,4),
  ANALGESIC2_DOSAGE_UNITS       NVARCHAR(8),
  ANALGESIC3                    NVARCHAR(40),
  ANALGESIC3_DOSAGE             NUMERIC(8,4),
  ANALGESIC3_DOSAGE_UNITS       NVARCHAR(8),
  LAST_DRUG_DATE_TIME       DATETIME,
  ANALGESIC_METHOD              NVARCHAR(40),
  EXTRADURAL_CATHETER_LOCATION  NVARCHAR(16),
  INTRAVENOUS_CATHETER_LOCATION NVARCHAR(16),
  ANALGESIC_PUMPS_TYPE          NVARCHAR(16),
  DRUGA                         NVARCHAR(40),
  DRUGA_DOSAGE                  NUMERIC(8,4),
  DRUGA_DOSAGE_UNITS            NVARCHAR(8),
  DRUGB                         NVARCHAR(40),
  DRUGB_DOSAGE                  NUMERIC(8,4),
  DRUGB_DOSAGE_UNITS            NVARCHAR(8),
  DRUGC                         NVARCHAR(40),
  DRUGC_DOSAGE                  NUMERIC(8,4),
  DRUGC_DOSAGE_UNITS            NVARCHAR(8),
  DRUGD                         NVARCHAR(40),
  DRUGD_DOSAGE                  NUMERIC(8,4),
  DRUGD_DOSAGE_UNITS            NVARCHAR(8),
  DRUGE                         NVARCHAR(40),
  DRUGE_DOSAGE                  NUMERIC(8,4),
  DRUGE_DOSAGE_UNITS            NVARCHAR(8),
  DRUGF                         NVARCHAR(40),
  DRUGF_DOSAGE                  NUMERIC(8,4),
  DRUGF_DOSAGE_UNITS            NVARCHAR(8),
  TOTAL_CAPACITY                NUMERIC(8,4),
  PCA_START                     DATETIME,
  PCA_STOP                      DATETIME,
  FIRST_DOSAGE                  NUMERIC(8,4),
  DURATIVE_DOSAGE               NUMERIC(8,4),
  PCA_DOSAGE                    NUMERIC(8,4),
  LOCK_TIME                     NUMERIC(3),
  SPO2_1                        NUMERIC(3),
  CARDIOTACH_1                  NUMERIC(3),
  BREATH_1                      NUMERIC(2),
  VAS_SCORE_1                   NUMERIC(2),
  CALMNESS_SCORE_1              NUMERIC(1),
  SPORT_BLOCK_SCORE_1           NUMERIC(1),
  NAUSEA_SCORE_1                NUMERIC(1),
  VOMIT_SCORE_1                 NUMERIC(1),
  EMICTION_RETENTION_SCORE_1    NUMERIC(1),
  CATHETERIZATION_SCORE_1       NUMERIC(1),
  OTHER_KICKBACK_1              NVARCHAR(20),
  PRESS1_1                      NUMERIC(3),
  PRESS2_1                      NUMERIC(3),
  DRUG_USED_1                   NUMERIC(8,4),
  INQUIRY_DOCTOR_1              NVARCHAR(8),
  HOURS_AFTER_OPER              NUMERIC(3),
  SPO2_2                        NUMERIC(3),
  CARDIOTACH_2                  NUMERIC(3),
  BREATH_2                      NUMERIC(2),
  VAS_SCORE_2                   NUMERIC(2),
  CALMNESS_SCORE_2              NUMERIC(1),
  SPORT_BLOCK_SCORE_2           NUMERIC(1),
  NAUSEA_SCORE_2                NUMERIC(1),
  VOMIT_SCORE_2                 NUMERIC(1),
  EMICTION_RETENTION_SCORE_2    NUMERIC(1),
  CATHETERIZATION_SCORE_2       NUMERIC(1),
  OTHER_KICKBACK_2              NVARCHAR(20),
  PRESS1_2                      NUMERIC(3),
  PRESS2_2                      NUMERIC(3),
  DRUG_USED_2                   NUMERIC(8,4),
  INQUIRY_DOCTOR_2              NVARCHAR(8),
  SPO2_3                        NUMERIC(3),
  CARDIOTACH_3                  NUMERIC(3),
  BREATH_3                      NUMERIC(2),
  VAS_SCORE_3                   NUMERIC(2),
  CALMNESS_SCORE_3              NUMERIC(1),
  SPORT_BLOCK_SCORE_3           NUMERIC(1),
  NAUSEA_SCORE_3                NUMERIC(1),
  VOMIT_SCORE_3                 NUMERIC(1),
  EMICTION_RETENTION_SCORE_3    NUMERIC(1),
  CATHETERIZATION_SCORE_3       NUMERIC(1),
  OTHER_KICKBACK_3              NVARCHAR(20),
  PRESS1_3                      NUMERIC(3),
  PRESS2_3                      NUMERIC(3),
  DRUG_USED_3                   NUMERIC(8,4),
  INQUIRY_DOCTOR_3              NVARCHAR(8),
  SPO2_4                        NUMERIC(3),
  CARDIOTACH_4                  NUMERIC(3),
  BREATH_4                      NUMERIC(2),
  VAS_SCORE_4                   NUMERIC(2),
  CALMNESS_SCORE_4              NUMERIC(1),
  SPORT_BLOCK_SCORE_4           NUMERIC(1),
  NAUSEA_SCORE_4                NUMERIC(1),
  VOMIT_SCORE_4                 NUMERIC(1),
  EMICTION_RETENTION_SCORE_4    NUMERIC(1),
  CATHETERIZATION_SCORE_4       NUMERIC(1),
  OTHER_KICKBACK_4              NVARCHAR(20),
  PRESS1_4                      NUMERIC(3),
  PRESS2_4                      NUMERIC(3),
  DRUG_USED_4                   NUMERIC(8,4),
  INQUIRY_DOCTOR_4              NVARCHAR(8),
  SPO2_5                        NUMERIC(3),
  CARDIOTACH_5                  NUMERIC(3),
  BREATH_5                      NUMERIC(2),
  VAS_SCORE_5                   NUMERIC(2),
  CALMNESS_SCORE_5              NUMERIC(1),
  SPORT_BLOCK_SCORE_5           NUMERIC(1),
  NAUSEA_SCORE_5                NUMERIC(1),
  VOMIT_SCORE_5                 NUMERIC(1),
  EMICTION_RETENTION_SCORE_5    NUMERIC(1),
  CATHETERIZATION_SCORE_5       NUMERIC(1),
  OTHER_KICKBACK_5              NVARCHAR(20),
  PRESS1_5                      NUMERIC(3),
  PRESS2_5                      NUMERIC(3),
  DRUG_USED_5                   NUMERIC(8,4),
  INQUIRY_DOCTOR_5              NVARCHAR(8),
  ANALGESIC_CATHETER            NVARCHAR(8),
  TOTAL_SATISFACTION            NVARCHAR(16),
  MEMO                          NVARCHAR(120),
  ENTER_DATE_TIME               DATETIME,
  ENTERED_BY                    NVARCHAR(8),
  ANALGESIC4                    NVARCHAR(40),
  ANALGESIC4_DOSAGE             NUMERIC(8,4),
  ANALGESIC4_DOSAGE_UNITS       NVARCHAR(8),
  ANALGESIC5                    NVARCHAR(40),
  ANALGESIC5_DOSAGE             NUMERIC(8,4),
  ANALGESIC5_DOSAGE_UNITS       NVARCHAR(8),
  ANALGESIC6                    NVARCHAR(40),
  ANALGESIC6_DOSAGE             NUMERIC(8,4),
  ANALGESIC6_DOSAGE_UNITS       NVARCHAR(8),
  PLEXUS_CATHETER_LOCATION      NVARCHAR(16),
  DRUG_TOTAL_USED_1             NUMERIC(8,4),
  PROBLEM_1                     NVARCHAR(30),
  HANDLE_1                      NVARCHAR(30),
  MEMO_1                        NVARCHAR(100),
  DRUG_TOTAL_USED_2             NUMERIC(8,4),
  PROBLEM_2                     NVARCHAR(30),
  HANDLE_2                      NVARCHAR(30),
  MEMO_2                        NVARCHAR(100),
  DRUG_TOTAL_USED_3             NUMERIC(8,4),
  PROBLEM_3                     NVARCHAR(30),
  HANDLE_3                      NVARCHAR(30),
  MEMO_3                        NVARCHAR(100),
  DRUG_TOTAL_USED_4             NUMERIC(8,4),
  PROBLEM_4                     NVARCHAR(30),
  HANDLE_4                      NVARCHAR(30),
  MEMO_4                        NVARCHAR(100),
  DRUG_TOTAL_USED_5             NUMERIC(8,4),
  PROBLEM_5                     NVARCHAR(30),
  HANDLE_5                      NVARCHAR(30),
  MEMO_5                        NVARCHAR(100),
  SPO2_6                        NUMERIC(3),
  CARDIOTACH_6                  NUMERIC(3),
  BREATH_6                      NUMERIC(2),
  VAS_SCORE_6                   NUMERIC(2),
  CALMNESS_SCORE_6              NUMERIC(1),
  SPORT_BLOCK_SCORE_6           NUMERIC(1),
  NAUSEA_SCORE_6                NUMERIC(1),
  VOMIT_SCORE_6                 NUMERIC(1),
  EMICTION_RETENTION_SCORE_6    NUMERIC(1),
  CATHETERIZATION_SCORE_6       NUMERIC(1),
  OTHER_KICKBACK_6              NVARCHAR(20),
  PRESS1_6                      NUMERIC(3),
  PRESS2_6                      NUMERIC(3),
  DRUG_USED_6                   NUMERIC(8,4),
  INQUIRY_DOCTOR_6              NVARCHAR(8),
  DRUG_TOTAL_USED_6             NUMERIC(8,4),
  PROBLEM_6                     NVARCHAR(30),
  HANDLE_6                      NVARCHAR(30),
  MEMO_6                        NVARCHAR(100),
  DISPENSER                     NVARCHAR(8),
  SECOND_DISPANSER              NVARCHAR(8),
  constraint PK_MED_OPERATION_ANALGESIC primary key (PATIENT_ID, VISIT_ID, OPER_ID)
)
----------------64病人手术费用项目--------------
create table MED_OPERATION_BILL_ITEMS
(
  PATIENT_ID         NVARCHAR(20) not null,
  VISIT_ID           NUMERIC(2) not null,
  OPER_ID            NUMERIC(2) not null,
  ITEM_NO            NUMERIC(3) not null,
  ITEM_CLASS         NVARCHAR(16),
  ITEM_NAME          NVARCHAR(60),
  ITEM_CODE          NVARCHAR(10),
  ITEM_SPEC          NVARCHAR(20),
  AMOUNT             NUMERIC(6,2),
  UNITS              NVARCHAR(8),
  ORDERED_BY         NVARCHAR(8),
  PERFORMED_BY       NVARCHAR(8),
  COSTS              NUMERIC(8,2),
  CHARGES            NUMERIC(8,2),
  NOTES              NVARCHAR(20),
  VERIFIED_INDICATOR NUMERIC(1),
  ENTERED_BY         NVARCHAR(8),
  CLASS_ON_RECKONING NVARCHAR(3),
  INPBILL_ITEM_NO    NUMERIC(6),
  EVENT_ITEM_NO      NUMERIC(3),
  EXCHANGE_INDICATOR NUMERIC(1) default 0,
  STORAGE_INDICATOR  NUMERIC(1) default 0,
  BILL_ATTR          NUMERIC(1),
  SUPPLIER_NAME      NVARCHAR(60),
  BILL_DATE      DATETIME,
  BILL_SORT 		 NUMERIC(3),
  EVENT_ITEM_CLASS 	 NVARCHAR(16),
  EVENT_ITEM_NAME 	 NVARCHAR(60),
  MTRL_NO 			 NVARCHAR(40),
  SORT 				 NUMERIC(3),
  PRICE_MODIFY 	     NUMERIC(3),
 constraint PK_MED_OPERATION_BILL_ITEMS primary key (PATIENT_ID, VISIT_ID, OPER_ID, ITEM_NO)
)
----------------65取消手术预约记录--------------
create table MED_OPERATION_CANCELED
(
  PATIENT_ID            NVARCHAR(20) not null,
  VISIT_ID              NUMERIC(2) not null,
  CANCEL_ID             NUMERIC(2) not null,
  DEPT_STAYED           NVARCHAR(16),
  SCHEDULED_DATE_TIME   DATETIME,
  OPERATING_ROOM        NVARCHAR(16),
  OPERATING_ROOM_NO     NVARCHAR(8),
  SEQUENCE              NUMERIC(2),
  DIAG_BEFORE_OPERATION NVARCHAR(80),
  PATIENT_CONDITION     NVARCHAR(100),
  OPERATION_SCALE       NVARCHAR(2),
  ISOLATION_INDICATOR   NUMERIC(1),
  OPERATING_DEPT        NVARCHAR(16),
  SURGEON               NVARCHAR(20),
  FIRST_ASSISTANT       NVARCHAR(20),
  SECOND_ASSISTANT      NVARCHAR(20),
  THIRD_ASSISTANT       NVARCHAR(20),
  FOURTH_ASSISTANT      NVARCHAR(20),
  ANESTHESIA_METHOD     NVARCHAR(60),
  ANESTHESIA_DOCTOR     NVARCHAR(20),
  ANESTHESIA_ASSISTANT  NVARCHAR(20),
  BLOOD_TRAN_DOCTOR     NVARCHAR(20),
  NOTES_ON_OPERATION    NVARCHAR(100),
  ENTERED_BY            NVARCHAR(20),
  CANCEL_REASON         NVARCHAR(40),
  RESERVED1             NVARCHAR(10),
  OPERATION_ID          NVARCHAR(18),
  RESERVED2             NVARCHAR(20),
  RESERVED3             NVARCHAR(20),
  RESERVED4             NVARCHAR(20),
  RESERVED5             NVARCHAR(20),
  RESERVED6             NVARCHAR(20),
  RESERVED7             NVARCHAR(20),
  RESERVED8             NVARCHAR(20),
  RESERVED9             DATETIME,
  RESERVED10            DATETIME,
  RESERVED11            NUMERIC(6),
  RESERVED12            NUMERIC(6),
  constraint PK_MED_OPERATION_CANCELED primary key (PATIENT_ID, VISIT_ID, CANCEL_ID)
)
----------------66器材准备清单--------------
create table MED_OPERATION_EQIP_DETAIL
(
  PATIENT_ID         NVARCHAR(20) not null,
  VISIT_ID           NUMERIC(2) not null,
  OPER_ID            NUMERIC(2) not null,
  ITEM_NO            NUMERIC(3) not null,
  ITEM_NAME          NVARCHAR(40),
  ITEM_CLASS         NVARCHAR(1),
  ITEM_CODE          NVARCHAR(10),
  ITEM_SPEC          NVARCHAR(20),
  UNITS              NVARCHAR(10),
  AMOUNT             NUMERIC(8,2),
  COSTS              NUMERIC(8,2),
  ONE_INDICATOR      NUMERIC(1),
  VERIFIED_INDICATOR NUMERIC(1),
  OPERATOR           NVARCHAR(8),
  ENTER_DATE_TIME    DATETIME,
  AMOUNT2            NUMERIC(8,2),
  AMOUNT3            NUMERIC(8,2),
  MEMO               NVARCHAR(40),
  AMOUNT4 					NUMERIC(8,2) ,
  constraint PK_MED_OPERATION_EQIP_DETAIL primary key (PATIENT_ID, VISIT_ID, OPER_ID, ITEM_NO)
)
----------------67器材准备清单模板--------------
create table MED_OPERATION_EQIP_TEMPLET
(
  TEMPLET       NVARCHAR(40) not null,
  ITEM_NO       NUMERIC(3) not null,
  ITEM_CLASS    NVARCHAR(1),
  ITEM_NAME     NVARCHAR(40),
  ITEM_CODE     NVARCHAR(10),
  ITEM_SPEC     NVARCHAR(20),
  UNITS         NVARCHAR(10),
  AMOUNT        NUMERIC(8,2),
  COSTS         NUMERIC(8,2),
  ONE_INDICATOR NUMERIC(1),
  AMOUNT2 NUMERIC(8,2),
  AMOUNT3 NUMERIC(8,2),
  constraint PK_MED_OPERATION_EQIP_TEMPLET primary key (TEMPLET, ITEM_NO)
)
----------------68病人手术主记录--------------
create table MED_OPERATION_MASTER
(
  PATIENT_ID                  NVARCHAR(20) not null,
  VISIT_ID                    NUMERIC(2) not null,
  OPER_ID                     NUMERIC(2) not null,
  DEPT_STAYED                 NVARCHAR(16),
  OPERATING_ROOM              NVARCHAR(16),
  OPERATING_ROOM_NO           NVARCHAR(8),
  DIAG_BEFORE_OPERATION       NVARCHAR(80),
  PATIENT_CONDITION           NVARCHAR(100),
  OPERATION_SCALE             NVARCHAR(2),
  DIAG_AFTER_OPERATION        NVARCHAR(80),
  EMERGENCY_INDICATOR         NUMERIC(1),
  ISOLATION_INDICATOR         NUMERIC(1),
  OPERATION_CLASS             NVARCHAR(1),
  OPERATING_DEPT              NVARCHAR(16),
  SURGEON                     NVARCHAR(20),
  FIRST_ASSISTANT             NVARCHAR(20),
  SECOND_ASSISTANT            NVARCHAR(20),
  THIRD_ASSISTANT             NVARCHAR(20),
  FOURTH_ASSISTANT            NVARCHAR(20),
  ANESTHESIA_METHOD           NVARCHAR(60),
  ANESTHESIA_DOCTOR           NVARCHAR(20),
  ANESTHESIA_ASSISTANT        NVARCHAR(20),
  BLOOD_TRAN_DOCTOR           NVARCHAR(20),
  FIRST_OPERATION_NURSE       NVARCHAR(20),
  SECOND_OPERATION_NURSE      NVARCHAR(20),
  FIRST_SUPPLY_NURSE          NVARCHAR(20),
  SECOND_SUPPLY_NURSE         NVARCHAR(20),
  NURSE_SHIFT_INDICATOR       NUMERIC(1),
  START_DATE_TIME             DATETIME,
  END_DATE_TIME               DATETIME,
  SATISFACTION_DEGREE         NUMERIC(1),
  SMOOTH_INDICATOR            NUMERIC(1),
  IN_FLUIDS_AMOUNT            NUMERIC(6),
  OUT_FLUIDS_AMOUNT           NUMERIC(6),
  BLOOD_LOSSED                NUMERIC(6),
  BLOOD_TRANSFERED            NUMERIC(6),
  ENTERED_BY                  NVARCHAR(20),
  THIRD_SUPPLY_NURSE          NVARCHAR(20),
  ORDER_TRANSFER              NUMERIC(1),
  CHARGE_TRANSFER             NUMERIC(1),
  END_INDICATOR               NUMERIC(1),
  RECK_GROUP                  NVARCHAR(8),
  OPER_STATUS                 NUMERIC(1) default 0,
  SECOND_ANESTHESIA_ASSISTANT NVARCHAR(20),
  THIRD_ANESTHESIA_ASSISTANT  NVARCHAR(20),
  FOURTH_ANESTHESIA_ASSISTANT NVARCHAR(20),
  OPERATION_POSITION          NVARCHAR(40),
  OPERATION_EQUIP_INDICATOR   NUMERIC(1),
  SECOND_ANESTHESIA_DOCTOR    NVARCHAR(20),
  THIRD_ANESTHESIA_DOCTOR     NVARCHAR(20),
  OTHER_IN_AMOUNT             NUMERIC(6),
  OTHER_OUT_AMOUNT            NUMERIC(6),
  IN_DATE_TIME                DATETIME,
  OUT_DATE_TIME               DATETIME,
  RESERVED1                   NVARCHAR(20),
  BLOOD_WHOLE_SELF            NUMERIC(6),
  BLOOD_WHOLE                 NUMERIC(6),
  BLOOD_RBC                   NUMERIC(6),
  BLOOD_PLASM                 NUMERIC(6),
  BLOOD_OTHER                 NUMERIC(6),
  RESERVED2                   NVARCHAR(20),
  SPECIAL_EQUIPMENT           NVARCHAR(40),
  SPECIAL_INFECT              NVARCHAR(40),
  HEPATITIS_INDICATOR         NUMERIC(1),
  ANES_START_DATE_TIME        DATETIME,
  RETURN_DATE_TIME            DATETIME,
  SEQUENCE                    NUMERIC(2),
  IN_PACU_DATE_TIME           DATETIME,
  OUT_PACU_DATE_TIME          DATETIME,
  OPERATION_ID                NVARCHAR(18),
  RESERVED3                   NVARCHAR(20),
  RESERVED4                   NVARCHAR(20),
  RESERVED5                   NVARCHAR(20),
  RESERVED6                   NVARCHAR(20),
  RESERVED7                   NVARCHAR(20),
  RESERVED8                   NVARCHAR(20),
  RESERVED9                   DATETIME,
  RESERVED10                  DATETIME,
  RESERVED11                  NUMERIC(6),
  RESERVED12                  NUMERIC(6),
  BLOOD_REUSE                 NUMERIC(6),
  SELF_BLOOD                  NUMERIC(6),
  ENTERED_DATE            DATETIME,
  MEMO                        NVARCHAR(100),
  ANESTHESIA_ID               NVARCHAR(20),
  XJ                          NUMERIC(3),
  AI                          NUMERIC(1),
  AT                          NUMERIC(3),
  JT                          NUMERIC(3),
  BODY_AREA                   NVARCHAR(10),
  GAS_PIPE                    NVARCHAR(60),
  PAT_LEAVE_SHOW              NVARCHAR(20),
  WHOLE_ANES                  NVARCHAR(30),
  STOP_ANES_AREA              NVARCHAR(30),
  STOP_ANES_AREA_MED          NVARCHAR(200),
  HOLE_PIPLE_ANES             NVARCHAR(30),
  STOP_ANES_AREA_TECH         NVARCHAR(40),
  PIN_SIZE                    NVARCHAR(10),
  PIPLE_UP                    NVARCHAR(10),
  PIPLE_DOWN                  NVARCHAR(10),
  IRRITATE_NERVE              NVARCHAR(20),
  ANES_RANGE                  NVARCHAR(20),
  BAK_MED                     NVARCHAR(200),
  WATCH_ANES                  NVARCHAR(60),
  ALL_ANES_MED_LEAD1          NVARCHAR(200),
  ALL_ANES_MED_LEAD2          NVARCHAR(200),
  ALL_ANES_MED_KEEP1          NVARCHAR(200),
  ALL_ANES_MED_KEEP2          NVARCHAR(200),
  CHEST_WATER                 NVARCHAR(10),
  ABDOMEN_WATER               NVARCHAR(10),
  INQUIRY_BEFORE_DATE         DATETIME,
  INQUIRY_AFTER_DATE          DATETIME,
  THIRD_OPERATION_NURSE       NVARCHAR(8),
  PACU_DOCTOR                 NVARCHAR(20),
  WATER_JT1                   NUMERIC(6),
  WATER_JT2                   NUMERIC(6),
  BLOOD_XB                    NUMERIC(6),
  COOL_THING                  NUMERIC(6),
  CRY_WATHER                  NUMERIC(6),
  RED_BLOOD                   NUMERIC(6),
  BLOOD_AMOUNT                NUMERIC(6),
  constraint PK_MED_OPERATION_MASTER primary key (PATIENT_ID, VISIT_ID, OPER_ID)
);
----------------69手术名称--------------
create table MED_OPERATION_NAME
(
  PATIENT_ID      NVARCHAR(20) not null,
  VISIT_ID        NUMERIC(2) not null,
  OPER_ID         NUMERIC(2) not null,
  OPERATION_NO    NUMERIC(2) not null,
  OPERATION       NVARCHAR(100),
  OPERATION_CODE  NVARCHAR(8),
  OPERATION_SCALE NVARCHAR(2),
  WOUND_GRADE     NVARCHAR(2),
  RESERVED1       NVARCHAR(20),
  RESERVED2       NVARCHAR(20),
  RESERVED3       NVARCHAR(20),
  RESERVED4       NVARCHAR(20),
  RESERVED5       NUMERIC(6),
  constraint PK_MED_OPERATION_NAME primary key (PATIENT_ID, VISIT_ID, OPER_ID, OPERATION_NO)
)
----------------70取消手术名称--------------
create table MED_OPERATION_NAME_CANCELED
(
  PATIENT_ID      NVARCHAR(20) not null,
  VISIT_ID        NUMERIC(2) not null,
  CANCEL_ID       NUMERIC(2) not null,
  OPERATION_NO    NUMERIC(2) not null,
  OPERATION       NVARCHAR(100),
  OPERATION_SCALE NVARCHAR(2),
  OPERATION_CODE  NVARCHAR(8),
  RESERVED1       NVARCHAR(20),
  RESERVED2       NVARCHAR(20),
  RESERVED3       NVARCHAR(20),
  RESERVED4       NVARCHAR(20),
  RESERVED5       NUMERIC(6),
  constraint PK_MED_OPERATION_NAME_CANCELED primary key (PATIENT_ID, VISIT_ID, CANCEL_ID, OPERATION_NO)
)
----------------71术中换班护士登记--------------
create table MED_OPERATION_NURSE_SHIFT
(
  PATIENT_ID             NVARCHAR(20) not null,
  VISIT_ID               NUMERIC(2) not null,
  OPER_ID                NUMERIC(2) not null,
  SHIFT_DATE_TIME        DATETIME not null,
  FIRST_OPERATION_NURSE  NVARCHAR(8),
  SECOND_OPERATION_NURSE NVARCHAR(8),
  FIRST_SUPPLY_NURSE     NVARCHAR(8),
  SECOND_SUPPLY_NURSE    NVARCHAR(8),
  THIRD_SUPPLY_NURSE     NVARCHAR(8),
  constraint PK_MED_OPERATION_NURSE_SHIFT primary key (PATIENT_ID, VISIT_ID, OPER_ID, SHIFT_DATE_TIME)
)
----------------72手术安排--------------
create table MED_OPERATION_SCHEDULE
(
  PATIENT_ID                  NVARCHAR(20) not null,
  VISIT_ID                    NUMERIC(2) not null,
  SCHEDULE_ID                 NUMERIC(2) not null,
  DEPT_STAYED                 NVARCHAR(16),
  BED_NO                      NVARCHAR(20),
  SCHEDULED_DATE_TIME         DATETIME,
  OPERATING_ROOM              NVARCHAR(16),
  OPERATING_ROOM_NO           NVARCHAR(8),
  [SEQUENCE]                    NUMERIC(2),
  DIAG_BEFORE_OPERATION       NVARCHAR(80),
  PATIENT_CONDITION           NVARCHAR(100),
  OPERATION_SCALE             NVARCHAR(2),
  ISOLATION_INDICATOR         NUMERIC(1),
  OPERATING_DEPT              NVARCHAR(16),
  SURGEON                     NVARCHAR(20),
  FIRST_ASSISTANT             NVARCHAR(20),
  SECOND_ASSISTANT            NVARCHAR(20),
  THIRD_ASSISTANT             NVARCHAR(20),
  FOURTH_ASSISTANT            NVARCHAR(20),
  ANESTHESIA_METHOD           NVARCHAR(60),
  ANESTHESIA_DOCTOR           NVARCHAR(20),
  ANESTHESIA_ASSISTANT        NVARCHAR(20),
  BLOOD_TRAN_DOCTOR           NVARCHAR(20),
  FIRST_OPERATION_NURSE       NVARCHAR(20),
  SECOND_OPERATION_NURSE      NVARCHAR(20),
  FIRST_SUPPLY_NURSE          NVARCHAR(20),
  SECOND_SUPPLY_NURSE         NVARCHAR(20),
  NOTES_ON_OPERATION          NVARCHAR(100),
  ENTERED_BY                  NVARCHAR(20),
  REQ_DATE_TIME               DATETIME,
  THIRD_SUPPLY_NURSE          NVARCHAR(20),
  ACK_INDICATOR               NUMERIC(1),
  EMERGENCY_INDICATOR         NUMERIC(1) default 0,
  RECK_GROUP                  NVARCHAR(8),
  OPER_ID                     NUMERIC(2),
  SECOND_ANESTHESIA_ASSISTANT NVARCHAR(20),
  THIRD_ANESTHESIA_ASSISTANT  NVARCHAR(20),
  FOURTH_ANESTHESIA_ASSISTANT NVARCHAR(20),
  SECOND_ANESTHESIA_DOCTOR    NVARCHAR(20),
  THIRD_ANESTHESIA_DOCTOR     NVARCHAR(20),
  RESERVED1                   NVARCHAR(10),
  RESERVED2                   NVARCHAR(10),
  OPERATION_POSITION          NVARCHAR(32),
  SPECIAL_EQUIPMENT           NVARCHAR(40),
  SPECIAL_INFECT              NVARCHAR(40),
  HEPATITIS_INDICATOR         NUMERIC(1),
  OPERATION_ID                NVARCHAR(18),
  RESERVED3                   NVARCHAR(100),
  RESERVED4                   NVARCHAR(20),
  RESERVED5                   NVARCHAR(20),
  RESERVED6                   NVARCHAR(20),
  RESERVED7                   NVARCHAR(20),
  RESERVED8                   NVARCHAR(20),
  RESERVED9                   DATETIME,
  RESERVED10                  DATETIME,
  RESERVED11                  NUMERIC(6),
  RESERVED12                  NUMERIC(6),
  THIRD_OPERATION_NURSE       NVARCHAR(8),
  [STATE]                     NUMERIC(2),
  OPERATION_NAME              NVARCHAR(300),
 constraint PK_MED_OPERATION_SCHEDULE primary key (PATIENT_ID, VISIT_ID, SCHEDULE_ID)
)
----------------73不知道叫什么表名--------------
create table MED_OPER_SCHED_TEMPLATE
(
  SERIAL_NO                   NUMERIC(6) not null,
  DEPT_CODE                   NVARCHAR(8) not null,
  TEMPLATE_NAME               NVARCHAR(64),
  ANESTHESIA_DOCTOR           NVARCHAR(8),
  SECOND_ANESTHESIA_DOCTOR    NVARCHAR(8),
  THIRD_ANESTHESIA_DOCTOR     NVARCHAR(8),
  ANESTHESIA_ASSISTANT        NVARCHAR(8),
  SECOND_ANESTHESIA_ASSISTANT NVARCHAR(8),
  THIRD_ANESTHESIA_ASSISTANT  NVARCHAR(8),
  FOURTH_ANESTHESIA_ASSISTANT NVARCHAR(8),
  BLOOD_TRAN_DOCTOR           NVARCHAR(8),
  FIRST_OPERATION_NURSE       NVARCHAR(8),
  SECOND_OPERATION_NURSE      NVARCHAR(8),
  FIRST_SUPPLY_NURSE          NVARCHAR(8),
  SECOND_SUPPLY_NURSE         NVARCHAR(8),
  THIRD_SUPPLY_NURSE          NVARCHAR(8),
  SURGEON                     NVARCHAR(8),
  FIRST_ASSISTANT             NVARCHAR(8),
  SECOND_ASSISTANT            NVARCHAR(8),
  THIRD_ASSISTANT             NVARCHAR(8),
  FOURTH_ASSISTANT            NVARCHAR(8),
  ROOM_NO                     NVARCHAR(4),
  constraint PK_MOST primary key (SERIAL_NO)
);
----------------74术中换班登记--------------
create table MED_OPERATION_SHIFT
(
  PATIENT_ID NVARCHAR(20) not null,
  VISIT_ID   NUMERIC(2) not null,
  OPER_ID    NUMERIC(2) not null,
  DUTY       NVARCHAR(10),
  MEMO       NVARCHAR(20),
  PERSON     NVARCHAR(8),
  WORK_BEGIN DATETIME,
  WORK_END   DATETIME
)
----------------75术后镇痛记录模版--------------
create table MED_OPER_ANALGESIC_TEMPLET
(
  TEMPLET_NAME                  NVARCHAR(40) not null,
  ANALGESIC1                    NVARCHAR(40),
  ANALGESIC1_DOSAGE             NUMERIC(8,4),
  ANALGESIC1_DOSAGE_UNITS       NVARCHAR(8),
  ANALGESIC2                    NVARCHAR(40),
  ANALGESIC2_DOSAGE             NUMERIC(8,4),
  ANALGESIC2_DOSAGE_UNITS       NVARCHAR(8),
  ANALGESIC3                    NVARCHAR(40),
  ANALGESIC3_DOSAGE             NUMERIC(8,4),
  ANALGESIC3_DOSAGE_UNITS       NVARCHAR(8),
  ANALGESIC_METHOD              NVARCHAR(40),
  EXTRADURAL_CATHETER_LOCATION  NVARCHAR(4),
  INTRAVENOUS_CATHETER_LOCATION NVARCHAR(4),
  ANALGESIC_PUMPS_TYPE          NVARCHAR(16),
  DRUGA                         NVARCHAR(40),
  DRUGA_DOSAGE                  NUMERIC(8,4),
  DRUGA_DOSAGE_UNITS            NVARCHAR(8),
  DRUGB                         NVARCHAR(40),
  DRUGB_DOSAGE                  NUMERIC(8,4),
  DRUGB_DOSAGE_UNITS            NVARCHAR(8),
  DRUGC                         NVARCHAR(40),
  DRUGC_DOSAGE                  NUMERIC(8,4),
  DRUGC_DOSAGE_UNITS            NVARCHAR(8),
  DRUGD                         NVARCHAR(40),
  DRUGD_DOSAGE                  NUMERIC(8,4),
  DRUGD_DOSAGE_UNITS            NVARCHAR(8),
  DRUGE                         NVARCHAR(40),
  DRUGE_DOSAGE                  NUMERIC(8,4),
  DRUGE_DOSAGE_UNITS            NVARCHAR(8),
  DRUGF                         NVARCHAR(40),
  DRUGF_DOSAGE                  NUMERIC(8,4),
  DRUGF_DOSAGE_UNITS            NVARCHAR(8),
  TOTAL_CAPACITY                NUMERIC(8,4),
  FIRST_DOSAGE                  NUMERIC(8,4),
  DURATIVE_DOSAGE               NUMERIC(8,4),
  PCA_DOSAGE                    NUMERIC(8,4),
  LOCK_TIME                     NUMERIC(3),
  ANALGESIC4                    NVARCHAR(40),
  ANALGESIC4_DOSAGE             NUMERIC(8,4),
  ANALGESIC4_DOSAGE_UNITS       NVARCHAR(8),
  ANALGESIC5                    NVARCHAR(40),
  ANALGESIC5_DOSAGE             NUMERIC(8,4),
  ANALGESIC5_DOSAGE_UNITS       NVARCHAR(8),
  ANALGESIC6                    NVARCHAR(40),
  ANALGESIC6_DOSAGE             NUMERIC(8,4),
  ANALGESIC6_DOSAGE_UNITS       NVARCHAR(8),
  constraint PK_MED_OPER_ANALGESIC_TEMPLET primary key (TEMPLET_NAME)
)
----------------76手术收费单模板--------------
create table MED_OPER_BILL_TEMPLET
(
  TEMPLET    NVARCHAR(10) not null,
  ITEM_NO    NUMERIC(3) not null,
  ITEM_CLASS NVARCHAR(1),
  ITEM_CODE  NVARCHAR(10),
  ITEM_NAME  NVARCHAR(40),
  ITEM_SPEC  NVARCHAR(20),
  UNITS      NVARCHAR(8),
  AMOUNT     NUMERIC(6,2),
  COSTS      NUMERIC(8,2),
  constraint PK_MED_OPER_BILL_TEMPLET primary key (TEMPLET, ITEM_NO)
)
----------------77出入室信息模板--------------
create table MED_ANES_RECOVERY_TEMPLATE                          
(
	TEMPLATE NVARCHAR(40),                                                     
	FS1      NVARCHAR(50),                                                      
	FS2      NVARCHAR(50),                                                      
	FS3      NVARCHAR(50),                                                      
	FS4      NVARCHAR(50),                                                      
	FS5      NVARCHAR(50),                                                      
	FS6      NVARCHAR(50),                                                      
	FS7      NVARCHAR(50),                                                      
	FS8      NVARCHAR(50),                                                      
	FS9      NVARCHAR(50),                                                      
	FS10      NVARCHAR(50),                                                     
	FS11      NVARCHAR(50),                                                     
	FS12      NVARCHAR(50),                                                     
	FS13      NVARCHAR(50),                                                     
	FS14      NVARCHAR(50),                                                     
	FS15      NVARCHAR(50),                                                     
	FS16      NVARCHAR(50),                                                     
	FS17      NVARCHAR(50),                                                     
	FS18      NVARCHAR(50),                                                     
	FS19      NVARCHAR(50),                                                     
	FS20      NVARCHAR(50),                                                     
	FS21      NVARCHAR(50),                                                     
	FS22      NVARCHAR(50),                                                     
	FS23      NVARCHAR(50),                                                     
	FS24      NVARCHAR(50),                                                     
	FS25      NVARCHAR(50),                                                     
	FS26      NVARCHAR(50),                                                     
	FS27      NVARCHAR(50),                                                     
	FS28      NVARCHAR(50),                                                     
	FS29      NVARCHAR(50),                                                     
	FS30      NVARCHAR(50),                                                     
	NOTE      NVARCHAR(200) ,
    constraint PK_MED_ANES_RECOVERY_TEMPLATE primary key (TEMPLATE)                                                    
);  
----------------78术后复苏体征记录--------------
create table MED_PACU_VITALSIGNS
(
  PATIENT_ID        NVARCHAR(20) not null,
  VISIT_ID          NUMERIC(2) not null,
  OPER_ID           NUMERIC(2) not null,
  TIME_POINT        DATETIME not null,
  VITAL_SIGNS       NVARCHAR(16) not null,
  VITAL_SIGNS_VALUE NVARCHAR(16),
  UNITS             NVARCHAR(10),
  EXAM_METHOD       NUMERIC(1),
  constraint PK_MED_PACU_VITALSIGNS primary key (PATIENT_ID, VISIT_ID, OPER_ID, TIME_POINT, VITAL_SIGNS)
)
----------------79术后复苏体征修改记录--------------
create table MED_PACU_VITALSIGNS_CHANGED
(
  PATIENT_ID    NVARCHAR(20) not null,
  VISIT_ID      NUMERIC(2) not null,
  OPER_ID       NUMERIC(2) not null,
  TIME_POINT    DATETIME not null,
  VITAL_SIGNS   NVARCHAR(16) not null,
  OLD_VALUE     NVARCHAR(16),
  NEW_VALUE     NVARCHAR(16),
  UNITS         NVARCHAR(10),
  MEMO          NVARCHAR(40),
  OPERATOR      NVARCHAR(8),
  LOG_DATE_TIME DATETIME not null,
  constraint PK_MED_PACU_VITALSIGNS_CHANGED primary key (PATIENT_ID, VISIT_ID, OPER_ID, TIME_POINT, VITAL_SIGNS, LOG_DATE_TIME)
)
----------------80报警个性化配置字典--------------
create table MED_PAT_MONITOR_DATA
(
  PATIENT_ID    NVARCHAR(20) not null,
  VISIT_ID      NUMERIC(2) not null,
  OPER_ID       NUMERIC(2) not null,
  ITEM_NO       NUMERIC(4) not null,
  MONITOR_VALUE NVARCHAR(240),
  DATA_TYPE     NVARCHAR(1),
  NOTICE_TIME   DATETIME,
  constraint PK_MED_PAT_MONITOR_DATA primary key (PATIENT_ID, VISIT_ID, OPER_ID, ITEM_NO)
)
----------------81不知道叫什么表名--------------
create table med_pat_monitor_data_temp
	(
	PATIENT_ID        NVARCHAR(20) not null,
	VISIT_ID          NUMERIC(2) not null ,
	OPER_ID		      NUMERIC(2) not null,
	TIME_POINT        DATETIME not null,
	ITEM_CODE         NVARCHAR(6) not null,
	ITEM_NAME	 	  NVARCHAR(20),
	ITEM_VALUE		  NVARCHAR(20),
	UNITS             NVARCHAR(10),
	MEMO              NVARCHAR(100),
	EXAM_METHOD       NUMERIC(1),
	OPERATOR          NVARCHAR(8),
	LOG_DATE_TIME     DATETIME,
    constraint pk_med_pat_monitor_data_temp 	primary key	(	PATIENT_ID, VISIT_ID, OPER_ID, TIME_POINT, ITEM_CODE)
	);
----------------82术中生命体征结果--------------
create table MED_PAT_MONITOR_DATA_EXT
(
  PATIENT_ID      NVARCHAR(20) not null,
  VISIT_ID        NUMERIC(2) not null,
  OPER_ID         NUMERIC(2) not null,
  RECORDING_DATE  DATETIME not null,
  TIME_POINT      DATETIME not null,
  ITEM_CODE       NVARCHAR(6) not null,
  ITEM_NAME       NVARCHAR(20),
  ITEM_VALUE      NVARCHAR(20),
  UNITS           NVARCHAR(10),
  MEMO            NVARCHAR(100),
  EXAM_METHOD     NUMERIC(1),
  NURSE_INDICATOR NUMERIC(1),
  OPERATOR        NVARCHAR(8),
  LOG_DATE_TIME   DATETIME,
  INSTRUMENT_TYPE NVARCHAR(20),
  TIME_POINT_NOTE NVARCHAR(20),
  ITEM_NO         NUMERIC,
  MODIFIED_TYPE 	NUMERIC,
  constraint PK_MED_PAT_MONITOR_DATA_EXT primary key (PATIENT_ID, VISIT_ID, OPER_ID, RECORDING_DATE, TIME_POINT, ITEM_CODE)
)
----------------83术中生命体征结果--------------
create table MED_PAT_MONITOR_DATA_HISTORY
(
  PATIENT_ID    NVARCHAR(20) not null,
  VISIT_ID      NUMERIC(2) not null,
  OPER_ID       NUMERIC(2) not null,
  ITEM_NO       NUMERIC(4) not null,
  MONITOR_VALUE NVARCHAR(240),
  DATA_TYPE     NVARCHAR(1),
  RECORD_DATE   DATETIME,
  constraint PK_MED_MONITOR_DATA_HISTORY primary key (PATIENT_ID, VISIT_ID, OPER_ID, ITEM_NO)
)
----------------84病人监控参数定义--------------
create table MED_PAT_MONITOR_PARM_DEFINE
(
  PATIENT_ID    NVARCHAR(20) not null,
  VISIT_ID      NUMERIC(2) not null,
  OPER_ID       NUMERIC(2) not null,
  ITEM_CODE     NVARCHAR(6) not null,
  ITEM_NAME     NVARCHAR(20),
  DRAW_STYLE    NUMERIC(1),
  DRAW_INTERVAL NUMERIC(4),
  DRAW_ISVALID		NUMERIC(1) default 1,
  constraint PK_MED_PAT_MONITOR_PARM_DEFINE primary key (PATIENT_ID, VISIT_ID, OPER_ID, ITEM_CODE)
)
----------------85查询条件--------------
create table MED_QUERY_COND
(
  COND_TYPE        NVARCHAR(20),
  COND_TITLE       NVARCHAR(40) not null,
  CONDITION        NVARCHAR(1000),
  CREATOR_ID       NVARCHAR(16),
  CREATE_DATE_TIME DATETIME,
  PERMISSION       NVARCHAR(1),
  constraint PK_MED_QUERY_COND primary key (COND_TITLE)
)
----------------86查询条件选择--------------
create table MED_QUERY_COND_SELECTION
(
  USER_NAME  NVARCHAR(16) not null,
  COND_TITLE NVARCHAR(40) not null,
  constraint PK_MED_QUERY_COND_SELECTION primary key (USER_NAME, COND_TITLE)
)
----------------87安排手术名称--------------
create table MED_SCHEDULED_OPERATION_NAME
(
  PATIENT_ID      NVARCHAR(20) not null,
  VISIT_ID        NUMERIC(2) not null,
  SCHEDULE_ID     NUMERIC(2) not null,
  OPERATION_NO    NUMERIC(2) not null,
  OPERATION       NVARCHAR(100),
  OPERATION_SCALE NVARCHAR(2),
  OPERATION_CODE  NVARCHAR(8),
  RESERVED1       NVARCHAR(20),
  RESERVED2       NVARCHAR(20),
  RESERVED3       NVARCHAR(20),
  RESERVED4       NVARCHAR(20),
  RESERVED5       NUMERIC(6),
  constraint PK_MED_SCH_OPERATION_NAME primary key (PATIENT_ID, VISIT_ID, SCHEDULE_ID, OPERATION_NO)
)

----------------88 人员离位登记--------------
create table MED_STAFF_LEAVE_LOG
(
  STAFF_ID     NVARCHAR(10) not null,
  LEAVE_DATE   DATETIME not null,
  LEAVE_REASON NVARCHAR(20),
  BACK_DATE    DATETIME,
  constraint PK_MED_STAFF_LEAVE_LOG primary key (STAFF_ID, LEAVE_DATE)
)
----------------89 人员基本信息-------------
create table MED_STAFF_PERSONNEL_INFO
(
  DEPT_CODE              NVARCHAR(8),
  STAFF_TYPE             NVARCHAR(8),
  STAFF_ID               NVARCHAR(10) not null,
  REGISTER_NO            NVARCHAR(12),
  NAME                   NVARCHAR(8),
  NAME_PHONETIC          NVARCHAR(16),
  SEX                    NVARCHAR(4),
  DATETIME_OF_BIRTH          DATETIME,
  DATETIME_OF_SERVICE        DATETIME,
  TITLE                  NVARCHAR(26),
  DATETIME_OF_TITLE          DATETIME,
  DUTY                   NVARCHAR(10),
  DATETIME_OF_DUTY           DATETIME,
  START_DATE_OF_WORK     DATETIME,
  DATETIME_OF_HIRE           DATETIME,
  TERM_OF_HIRE           NUMERIC(4),
  BASE_PAY               NUMERIC(8,2),
  POLITICAL_FEATURE      NVARCHAR(8),
  NATIVE_PLACE           NVARCHAR(34),
  MARITAL_STATUS         NVARCHAR(4),
  ADDRESS                NVARCHAR(30),
  ZIP_CODE               NVARCHAR(6),
  PHONE_NUMERIC           NVARCHAR(16),
  RANK                   NVARCHAR(16),
  DATETIME_OF_RANK           DATETIME,
  ID_NO                  NVARCHAR(18),
  FORMER_UNIT            NVARCHAR(40),
  EDUCATIONAL_LEVEL_1    NVARCHAR(10),
  DEGREE_1               NVARCHAR(10),
  GRADUATE_DATE_1        DATETIME,
  GRADUATE_FROM_1        NVARCHAR(20),
  EDUCATION_TYPE_1       NVARCHAR(10),
  EDUCATIONAL_LEVEL_2    NVARCHAR(10),
  DEGREE_2               NVARCHAR(10),
  GRADUATE_DATE_2        DATETIME,
  GRADUATE_FROM_2        NVARCHAR(20),
  EDUCATION_TYPE_2       NVARCHAR(10),
  FOREIGN_LANGUAGE       NVARCHAR(10),
  FOREIGN_LANGUAGE_LEVEL NVARCHAR(4),
  STAFF_AGE              NUMERIC(2),
  ENTER_DATE             DATETIME,
  LEAVE_DATE             DATETIME,
  LEAVE_REASON           NVARCHAR(20),
  WORKING_STATUS         NUMERIC(1),
  EMP_NO                 NVARCHAR(6),
  INPUT_CODE             NVARCHAR(8),
  SERIAL_NO              NUMERIC(4),
  USER_NAME              NVARCHAR(16),
  PASSWORD               NVARCHAR(30),
  USER_VALID             NUMERIC(1),
  CREATE_DATE            DATETIME,
  STAFF_VALID            NUMERIC(1),
   constraint PK_MED_STAFF_PERSONNEL_INFO primary key (STAFF_ID)
)
----------------90 人员排班表-------------
create table MED_STAFF_SCHEDULE
(
  DEPT_CODE    NVARCHAR(8) not null,
  SERIAL_NO    NUMERIC(8) not null,
  STAFF_ID     NVARCHAR(10),
  STAFF_NAME   NVARCHAR(8),
  DATETIME_OF_WORK DATETIME not null,
  SCHEDULE     NVARCHAR(10),
  constraint PK_MED_STAFF_SCHEDULE primary key (DEPT_CODE, SERIAL_NO, DATETIME_OF_WORK)
)
----------------91 不知道叫什么表名-------------
create table MED_STAFF_SCHEDULE_DICT
(
  SERIAL_NO     NUMERIC(3),
  SCHEDULE_NAME NVARCHAR(10) not null,
  SCHEDULE_TYPE NVARCHAR(8),
  INPUT_CODE    NVARCHAR(8),
  constraint PK_MED_STAFF_REMARK_DETAIL primary key (SCHEDULE_NAME)
)
----------------92 人员排班备注-------------
create table MED_STAFF_SCHEDULE_REM
(
  DEPT_CODE      NVARCHAR(8) not null,
  DATETIME_OF_MONDAY DATETIME not null,
  CONTENT        NVARCHAR(200),
  constraint PK_MED_STAFF_SCH_REM primary key (DEPT_CODE, DATETIME_OF_MONDAY)
)
----------------93 人员排班详细备注-------------
create table MED_STAFF_SCHEDULE_REM_DETAIL
(
  DEPT_CODE      NVARCHAR(8) not null,
  DATETIME_OF_MONDAY DATETIME not null,
  STAFF_ID       NVARCHAR(10) not null,
  STAFF_NAME     NVARCHAR(8) not null,
  CONTENT        NVARCHAR(200),
  constraint PK_MED_STAFF_SCH_REM_DETAIL primary key (DEPT_CODE, DATETIME_OF_MONDAY, STAFF_ID, STAFF_NAME)
)
----------------94 人员调动情况-------------
create table MED_STAFF_TRANSFER
(
  STAFF_ID      NVARCHAR(10) not null,
  TRANSFER_DATE DATETIME not null,
  TRANSFER_FROM NVARCHAR(8),
  TRANSFER_TO   NVARCHAR(8),
  constraint PK_MED_STAFF_TRANSFER primary key (STAFF_ID, TRANSFER_DATE)
)
----------------95 手术麻醉费用统计表（暂时未使用）-------------
create table MED_ST_OPER_COSTS
(
  YEAR_MONTH     DATETIME not null,
  ITEM_CLASS     NVARCHAR(1) not null,
  CHARGE_TYPE    NVARCHAR(8) not null,
  TOTAL_COSTS    NUMERIC(10,2),
  TOTAL_CHARGES  NUMERIC(10,2),
  PERFORMED_BY   NVARCHAR(8) not null,
  STAT_DATE_TIME DATETIME,
  constraint PK_MED_ST_OPER_COSTS primary key (YEAR_MONTH, ITEM_CLASS, CHARGE_TYPE, PERFORMED_BY)
)
----------------96 手术室个人工作量-------------
create table MED_ST_OP_PER_WORKLOAD
(
  DUTY               NVARCHAR(16) not null,
  NAME               NVARCHAR(8) not null,
  EMP_NO             NVARCHAR(8),
  YEAR_MONTH         DATETIME not null,
  WORKLOAD_NUM       NUMERIC(3),
  WORKLOAD_NUM1      NUMERIC(3),
  WORKLOAD_NUM2      NUMERIC(3),
  WORKLOAD_NUM3      NUMERIC(3),
  WORKLOAD_NUM4      NUMERIC(3),
  WORKLOAD_TIME      NUMERIC(8,1),
  MODIFIED_BY        NVARCHAR(8),
  MODIFIED_DATE_TIME DATETIME,
  constraint PK_MED_ST_OP_PER_WORKLOAD primary key (DUTY, NAME, YEAR_MONTH)
)
----------------97 不知道表名-------------
create table MED_ST_OP_PER_WORKLOAD_TEMP
(
  DUTY             NVARCHAR(16),
  NAME             NVARCHAR(8),
  EMP_NO           NVARCHAR(8),
  START_DATE_TIME  DATETIME,
  END_DATE_TIME    DATETIME,
  PATIENT_ID       NVARCHAR(20) not null,
  VISIT_ID         NUMERIC(2) not null,
  OPER_ID          NUMERIC(2) not null,
  OPERATION_SCALE  NVARCHAR(2),
  ANALGESIC_METHOD NVARCHAR(40),
  constraint PK_MED_ST_OP_PER_WORKLOAD_TEMP primary key (PATIENT_ID, VISIT_ID, OPER_ID)
)
----------------98 麻醉总结模板-------------
create table MED_SUMMARY_TEMPLET
(
  TEMPLET_NAME NVARCHAR(40) not null,
  A1           NVARCHAR(12),
  A2           NVARCHAR(12),
  A3           NVARCHAR(20),
  A4           NVARCHAR(12),
  A5           NVARCHAR(20),
  A6           NVARCHAR(12),
  A7           NVARCHAR(12),
  A8           NVARCHAR(200),
  B1           NVARCHAR(12),
  B2           NVARCHAR(12),
  B3           NVARCHAR(12),
  B4           NVARCHAR(12),
  B5           NVARCHAR(12),
  B6           NVARCHAR(12),
  B7           NVARCHAR(12),
  B8           NVARCHAR(12),
  B9           NVARCHAR(12),
  B10          NVARCHAR(12),
  B11          NVARCHAR(12),
  B12          NVARCHAR(12),
  B13          NVARCHAR(12),
  B14          NVARCHAR(120),
  B15          NVARCHAR(12),
  B16          NVARCHAR(120),
  B17          NVARCHAR(12),
  B18          NVARCHAR(12),
  B19          NVARCHAR(12),
  B20          NVARCHAR(100),
  C1           NVARCHAR(12),
  C2           NVARCHAR(12),
  C3           NVARCHAR(12),
  C4           NVARCHAR(12),
  C5           NVARCHAR(12),
  C6           NVARCHAR(50),
  C7           NVARCHAR(12),
  C8           NVARCHAR(12),
  C9           NVARCHAR(12),
  C10          NVARCHAR(120),
  C11          NVARCHAR(12),
  F1           NVARCHAR(12),
  F2           NVARCHAR(30),
  F3           NVARCHAR(120),
  F4           NVARCHAR(12),
  F5           NVARCHAR(12),
  F6           NVARCHAR(12),
  F7           NVARCHAR(12),
  F8           NVARCHAR(12),
  G1           NVARCHAR(12),
  G2           NVARCHAR(12),
  G3           NVARCHAR(12),
  G4           NVARCHAR(12),
  G5           NVARCHAR(12),
  G6           NVARCHAR(12),
  G7           NVARCHAR(12),
  G8           NVARCHAR(12),
  G9           NVARCHAR(12),
  G10          NVARCHAR(30),
  BEFORE_OPER  NVARCHAR(200),
  IN_OPER      NVARCHAR(1000),
  AFTER_OPER   NVARCHAR(200),
  B25          NVARCHAR(120),
  G21          NVARCHAR(20),
  F16          NVARCHAR(120),
  G11          NVARCHAR(4),
  G12          NVARCHAR(4),
  G13          NVARCHAR(8),
  G14          NVARCHAR(4),
  G15          NVARCHAR(4),
  G16          NVARCHAR(4),
  G17          NVARCHAR(4),
  G18          NVARCHAR(16),
  C12          NVARCHAR(16),
  C13          NVARCHAR(4),
  C15          NVARCHAR(100),
  C14          NVARCHAR(4),
  A9           NVARCHAR(8),
  A11          NVARCHAR(4),
  A10          NVARCHAR(8),
  A12          NVARCHAR(40),
  B23          NVARCHAR(40),
  B24          NUMERIC(8,4),
  B21          NUMERIC(3),
  B22          NUMERIC(3),
  F10          NVARCHAR(40),
  F11          NVARCHAR(40),
  F12          NVARCHAR(40),
  F13          NVARCHAR(40),
  F14          NVARCHAR(40),
  F9           NVARCHAR(100),
  constraint PK_MED_SUMMARY_TEMPLET primary key (TEMPLET_NAME)
);
----------------99 自体回输记录-------------
create table MED_TRANSFER_SELF
(
  PATIENT_ID         NVARCHAR(20) not null,
  VISIT_ID           NUMERIC(2) not null,
  OPER_ID            NUMERIC(2) not null,
  ENTER_DATE     DATETIME not null,
  ENTERED_BY         NVARCHAR(8),
  ERYTHROCYTE        NVARCHAR(20),
  LEUCOCYTE          NVARCHAR(20),
  BLOOD_PLATELET     NVARCHAR(20),
  ERYTHROCYTE_VOLUME NVARCHAR(20),
  HEMACHROME         NVARCHAR(20),
  TRANSFER_SELF      NVARCHAR(20),
  constraint PK_MED_TRANSFER_SELF primary key (PATIENT_ID, VISIT_ID, OPER_ID, ENTER_DATE)
);
----------------100 医生初始化模板配置表-------------
create table MED_TEMPLET_CONFIG
(
  DB_USER            NVARCHAR(16) not null,
  ANESTHESIA_TEMPLET NVARCHAR(40),
  INQUIRY_TEMPLET    NVARCHAR(40),
  SUMMARY_TEMPLET    NVARCHAR(40),
  EQIP_TEMPLET       NVARCHAR(40),
  constraint PK_MED_TEMPLET_CONFIG primary key (DB_USER)
)
----------------101 排班备注-------------
create table MED_STAFF_SCHEDULE_REMARK
(
	DEPT_CODE      NVARCHAR(8) not null,
	DATETIME_OF_MONDAY DATETIME not null,
	CONTENT        NVARCHAR(200),
	constraint PK_MED_STAFF_SCHEDULE_REMARK primary key (DEPT_CODE, DATETIME_OF_MONDAY)
);
----------------102 人员排班详细备注-------------
create table MED_STAFF_SCHEDULE_REMARK_D
(
  DEPT_CODE      NVARCHAR(8) not null,
  DATETIME_OF_MONDAY DATETIME not null,
  STAFF_ID       NVARCHAR(10) not null,
  STAFF_NAME     NVARCHAR(8) not null,
  CONTENT        NVARCHAR(200),
  constraint PK_SCHEDULE_REMARK_DETAIL primary key (DEPT_CODE, DATETIME_OF_MONDAY, STAFF_ID, STAFF_NAME)
);
----------------103 DOCARE输入项目字典-------------
create table MED_DOCARE_INPUT_DICT
(
  SERIAL_NO  NUMERIC(5),
  CATALOG    NVARCHAR(16) not null,
  ITEM_CLASS NVARCHAR(16) not null,
  ITEM_NAME  NVARCHAR(40) not null,
  ITEM_CODE  NVARCHAR(40),
  INPUT_CODE NVARCHAR(8),
  constraint PK_MED_DOCARE_INPUT_DICT primary key (CATALOG, ITEM_CLASS, ITEM_NAME)
);
----------------104 重评分相关脚本-------------
create table APACHE2_SCORING_RESULT_DETAIL
(
  PATIENT_ID        NVARCHAR(10) not null,
  VISIT_ID          NUMERIC(2) not null,
  SCORING_DATE_TIME DATETIME not null,
  AGE               NUMERIC(3),
  HR                NUMERIC(5),
  MAP               NUMERIC(5),
  BR                NUMERIC(5),
  TMP               NUMERIC(5,2),
  AADO2             NUMERIC(6,2),
  PAO2              NUMERIC(6,2),
  FIO2              NUMERIC(6,2),
  PH                NUMERIC(6,2),
  HCT               NUMERIC(6,2),
  CR                NUMERIC(6,2),
  WBC               NUMERIC(6,2),
  K                 NUMERIC(6,2),
  NA                NUMERIC(6,2),
  EYES_REFLECT      NUMERIC(1),
  TALK_REFLECT      NUMERIC(1),
  LIMB_REFLECT      NUMERIC(1),
  HEALTH_STATUS     NUMERIC(1),
  KEY_INDICATOR     NUMERIC(1),
  MEMO              NVARCHAR(100),
  constraint PK_APACHE2_SCORING_RESULT primary key (PATIENT_ID, VISIT_ID, SCORING_DATE_TIME)
)
----------------105 重评分相关脚本-------------
create table APGAR_SCORING_RESULT_DETAIL
(
  PATIENT_ID        NVARCHAR(10) not null,
  VISIT_ID          NUMERIC(2) not null,
  SCORING_DATE_TIME DATETIME not null,
  S1                NUMERIC(1),
  S2                NUMERIC(1),
  S3                NUMERIC(1),
  S4                NUMERIC(1),
  S5                NUMERIC(1),
  MEMO              NVARCHAR(100),
  constraint PK_APGAR_SCORING_RESULT primary key (PATIENT_ID, VISIT_ID, SCORING_DATE_TIME)
)
----------------106 重评分相关脚本-------------
create table BALTH_SCORING_RESULT_DETAIL
(
  PATIENT_ID        NVARCHAR(10) not null,
  VISIT_ID          NUMERIC(2) not null,
  SCORING_DATE_TIME DATETIME not null,
  CT_CLASS          NUMERIC(1),
  PUTRE_RANGE       NUMERIC(1),
  MEMO              NVARCHAR(100),
  constraint PK_BALTH_SCORING_RESULT primary key (PATIENT_ID, VISIT_ID, SCORING_DATE_TIME)
)
----------------107 重评分相关脚本-------------
create table CG_SCORING_RESULT_DETAIL
(
  PATIENT_ID        NVARCHAR(10) not null,
  VISIT_ID          NUMERIC(2) not null,
  SCORING_DATE_TIME DATETIME not null,
  S1                NUMERIC(1),
  S2                NUMERIC(1),
  S3                NUMERIC(1),
  S4                NUMERIC(1),
  MEMO              NVARCHAR(100),
  constraint PK_CG_SCORING_RESULT primary key (PATIENT_ID, VISIT_ID, SCORING_DATE_TIME)
  )
  
  ----------------108 重评分相关脚本-------------
create table CPUGH_SCORING_RESULT_DETAIL
(
  PATIENT_ID        NVARCHAR(10) not null,
  VISIT_ID          NUMERIC(2) not null,
  SCORING_DATE_TIME DATETIME not null,
  C1                NUMERIC(1),
  C2                NUMERIC(1),
  C3                NUMERIC(1),
  C4                NUMERIC(1),
  C5                NUMERIC(1),
  C6                NUMERIC(1),
  MEMO              NVARCHAR(100),
  constraint PK_CPUGH_SCORING_RESULT primary key (PATIENT_ID, VISIT_ID, SCORING_DATE_TIME)
)
----------------109 重评分相关脚本-------------
create table CRAMS_SCORING_RESULT_DETAIL
(
  PATIENT_ID        NVARCHAR(10) not null,
  VISIT_ID          NUMERIC(2) not null,
  SCORING_DATE_TIME DATETIME not null,
  CIRCLE_STATUS     NUMERIC(1),
  BREATH_STATUS     NUMERIC(1),
  BREAST_STATUS     NUMERIC(1),
  LIMB_STATUS       NUMERIC(1),
  TALK_STATUS       NUMERIC(1),
  MEMO              NVARCHAR(100),
  constraint PK_CRAMS_SCORING_RESULT primary key (PATIENT_ID, VISIT_ID, SCORING_DATE_TIME)
)
----------------110 重评分相关脚本-------------
create table CRIB_SCORING_RESULT_DETAIL
(
  PATIENT_ID        NVARCHAR(10) not null,
  VISIT_ID          NUMERIC(2) not null,
  SCORING_DATE_TIME DATETIME not null,
  S1                NUMERIC(1),
  S2                NUMERIC(1),
  S3                NUMERIC(1),
  S4                NUMERIC(1),
  S5                NUMERIC(1),
  MEMO              NVARCHAR(100),
constraint PK_CRIB_SCORING_RESULT primary key (PATIENT_ID, VISIT_ID, SCORING_DATE_TIME)
)
----------------111 重评分相关脚本-------------
create table CSSS_SCORING_RESULT_DETAIL
(
  PATIENT_ID        NVARCHAR(10) not null,
  VISIT_ID          NUMERIC(2) not null,
  SCORING_DATE_TIME DATETIME not null,
  S1                NUMERIC(1),
  S2                NUMERIC(1),
  S3                NUMERIC(1),
  S41               NUMERIC(1),
  S42               NUMERIC(1),
  S43               NUMERIC(1),
  S5                NUMERIC(1),
  S6                NUMERIC(1),
  S7                NUMERIC(1),
  S8                NUMERIC(1),
  S9                NUMERIC(1),
  S10               NUMERIC(1),
  S11               NUMERIC(1),
  S12               NUMERIC(1),
  S13               NUMERIC(1),
  S14               NUMERIC(1),
  S151              NUMERIC(1),
  S152              NUMERIC(1),
  S153              NUMERIC(1),
  S154              NUMERIC(1),
  S155              NUMERIC(1),
  S161              NUMERIC(1),
  S162              NUMERIC(1),
  S163              NUMERIC(1),
  MEMO              NVARCHAR(100),
  constraint PK_CSSS_SCORING_RESULT primary key (PATIENT_ID, VISIT_ID, SCORING_DATE_TIME)
)
----------------112 重评分相关脚本-------------
create table GCS_SCORING_RESULT_DETAIL
(
  PATIENT_ID        NVARCHAR(10) not null,
  VISIT_ID          NUMERIC(2) not null,
  SCORING_DATE_TIME DATETIME not null,
  EYES_REFLECT      NUMERIC(1),
  TALK_REFLECT      NUMERIC(1),
  LIMB_REFLECT      NUMERIC(1),
  MEMO              NVARCHAR(100),
  constraint PK_GCS_SCORING_RESULT primary key (PATIENT_ID, VISIT_ID, SCORING_DATE_TIME)
)
----------------113 重评分相关脚本-------------
create table GOLDMAN_SCORING_RESULT_DETAIL
(
  PATIENT_ID        NVARCHAR(10) not null,
  VISIT_ID          NUMERIC(2) not null,
  SCORING_DATE_TIME DATETIME not null,
  G1                NUMERIC(2),
  G2                NUMERIC(2),
  G3                NUMERIC(2),
  G4                NUMERIC(2),
  G5                NUMERIC(2),
  G6                NUMERIC(2),
  G7                NUMERIC(2),
  G8                NUMERIC(2),
  G9                NUMERIC(2),
  MEMO              NVARCHAR(100),
  constraint PK_GOLDMAN_SCORING_RESULT primary key (PATIENT_ID, VISIT_ID, SCORING_DATE_TIME)
)
----------------114 重评分相关脚本-------------
create table GP_SCORING_RESULT_DETAIL
(
  PATIENT_ID        NVARCHAR(10) not null,
  VISIT_ID          NUMERIC(2) not null,
  SCORING_DATE_TIME DATETIME not null,
  S1                NUMERIC(1),
  S2                NUMERIC(1),
  S3                NUMERIC(1),
  S4                NUMERIC(1),
  S5                NUMERIC(1),
  S6                NUMERIC(1),
  S7                NUMERIC(1),
  MEMO              NVARCHAR(100),
  constraint PK_GP_SCORING_RESULT primary key (PATIENT_ID, VISIT_ID, SCORING_DATE_TIME)
)
----------------115 重评分相关脚本-------------
create table IMP_ITEM_VS_DICT
(
  PROGRAM_NAME    NVARCHAR(20) not null,
  SCORING_METHOD  NVARCHAR(20) not null,
  ITEM_NAME       NVARCHAR(100) not null,
  CLASS_INDICATOR NUMERIC(1),
  RELATE_CODE     NVARCHAR(30),
  VALUE_TYPE      NUMERIC(1),
  constraint PK_IMP_ITEM_VS_DICT primary key (PROGRAM_NAME, SCORING_METHOD, ITEM_NAME)
)
----------------116 重评分相关脚本-------------
create table LUTZ_SCORING_RESULT_DETAIL
(
  PATIENT_ID        NVARCHAR(10) not null,
  VISIT_ID          NUMERIC(2) not null,
  SCORING_DATE_TIME DATETIME not null,
  OPERATE_TYPE      NUMERIC(1),
  OPERATE_PART      NUMERIC(1),
  OPERATE_TIME      NUMERIC(1),
  AGE               NUMERIC(1),
  BADY_STATUS       NUMERIC(1),
  CONS_STATUS       NUMERIC(1),
  HEART_STATUS      NUMERIC(1),
  ARRHYTHMIA        NUMERIC(1),
  CIRCLE_STATUS     NUMERIC(1),
  BREATH_STATUS     NUMERIC(1),
  METABOLIZE        NUMERIC(1),
  K_STATUS          NUMERIC(1),
  BLOOD_STATUS      NUMERIC(1),
  LIVER_STATUS      NUMERIC(1),
  KIDNEY_STATUS     NUMERIC(1),
  MEMO              NVARCHAR(100),
  constraint PK_LUTZ_SCORING_RESULT primary key (PATIENT_ID, VISIT_ID, SCORING_DATE_TIME)
)
----------------117 重评分相关脚本-------------
create table MODS2_SCORING_RESULT_DETAIL
(
  PATIENT_ID        NVARCHAR(10) not null,
  VISIT_ID          NUMERIC(2) not null,
  SCORING_DATE_TIME DATETIME not null,
  S1                NUMERIC(1),
  S2                NUMERIC(1),
  S3                NUMERIC(1),
  S4                NUMERIC(1),
  S5                NUMERIC(1),
  S6                NUMERIC(1),
  S7                NUMERIC(1),
  S8                NUMERIC(1),
  S9                NUMERIC(1),
  MEMO              NVARCHAR(100),
 constraint PK_MODS2_SCORING_RESULT primary key (PATIENT_ID, VISIT_ID, SCORING_DATE_TIME)
)
----------------118 重评分相关脚本-------------
create table MODS_SCORING_RESULT_DETAIL
(
  PATIENT_ID        NVARCHAR(10) not null,
  VISIT_ID          NUMERIC(2) not null,
  SCORING_DATE_TIME DATETIME not null,
  HR                NUMERIC(5),
  RAP               NUMERIC(5),
  MAP               NUMERIC(5),
  PAO2              NUMERIC(6,2),
  FIO2              NUMERIC(6,2),
  CR                NUMERIC(6,2),
  BBIL              NUMERIC(6,2),
  PLT               NUMERIC(6,2),
  EYES_REFLECT      NUMERIC(1),
  TALK_REFLECT      NUMERIC(1),
  LIMB_REFLECT      NUMERIC(1),
  MEMO              NVARCHAR(100),
  constraint PK_MODS_SCORING_RESULT primary key (PATIENT_ID, VISIT_ID, SCORING_DATE_TIME)
)
----------------119 重评分相关脚本-------------
create table NORTON_SCORING_RESULT_DETAIL
(
  PATIENT_ID        NVARCHAR(10) not null,
  VISIT_ID          NUMERIC(2) not null,
  SCORING_DATE_TIME DATETIME not null,
  S1                NUMERIC(1),
  S2                NUMERIC(1),
  S3                NUMERIC(1),
  S4                NUMERIC(1),
  S5                NUMERIC(1),
  S6                NUMERIC(1),
  S7                NUMERIC(1),
  S8                NUMERIC(1),
  S9                NUMERIC(1),
  MEMO              NVARCHAR(100),
  constraint PK_NORTON_SCORING_RESULT primary key (PATIENT_ID, VISIT_ID, SCORING_DATE_TIME)
)
---------------120 重评分相关脚本----------------
create table PARS_SCORING_RESULT_DETAIL
(
  PATIENT_ID        NVARCHAR(10) not null,
  VISIT_ID          NUMERIC(2) not null,
  SCORING_DATE_TIME DATETIME not null,
  ACTIVE_STATUS     NUMERIC(1),
  BREATH_STATUS     NUMERIC(1),
  CIRCLE_STATUS     NUMERIC(1),
  CONS_STATUS       NUMERIC(1),
  SKIN_STATUS       NUMERIC(1),
  MEMO              NVARCHAR(100),
  constraint PK_PARS_SCORING_RESULT primary key (PATIENT_ID, VISIT_ID, SCORING_DATE_TIME)
)
---------------121 重评分相关脚本----------------
create table PATIENT_SCORING_RESULT
(
  PATIENT_ID        NVARCHAR(10) not null,
  VISIT_ID          NUMERIC(2) not null,
  SCORING_DATE_TIME DATETIME not null,
  SCORING_METHOD    NVARCHAR(20) not null,
  SCORING_VALUE     NUMERIC(8),
  DEGREE            NVARCHAR(40),
  DEATH_PROBABILITY NUMERIC(5,4),
  PAT_CONDITION     NVARCHAR(80),
  WARD_CODE         NVARCHAR(8),
  OPERATOR          NVARCHAR(8),
  MEMO              NVARCHAR(1000),
  ENTER_DATE_TIME   DATETIME,
  constraint PK_PATIENT_SCORING_RESULT primary key (PATIENT_ID, VISIT_ID, SCORING_DATE_TIME, SCORING_METHOD)
)
---------------122 重评分相关脚本----------------
create table PATIENT_SCORING_RESULT_DETAIL
(
  PATIENT_ID          NVARCHAR(10) not null,
  VISIT_ID            NUMERIC(2) not null,
  SCORING_DATE_TIME   DATETIME not null,
  SCORING_METHOD      NVARCHAR(20) not null,
  ITEM_NAME           NVARCHAR(100) not null,
  ITEM_SOURCE         NUMERIC(2),
  ITEM_VALUE          NUMERIC(8,4),
  VALUE_OPTIONS       NVARCHAR(200),
  ITEM_VALUE_DESCRIBE NUMERIC(2),
  MULTIPLE            NUMERIC(2),
  MEMO                NVARCHAR(1000),
  ENTER_DATE_TIME     DATETIME,
  constraint PK_PATIENT_SCORING_DETAIL primary key (PATIENT_ID, VISIT_ID, SCORING_DATE_TIME, SCORING_METHOD, ITEM_NAME)
)
---------------123 重评分相关脚本----------------
create table SAPS2_SCORING_RESULT_DETAIL
(
  PATIENT_ID        NVARCHAR(10) not null,
  VISIT_ID          NUMERIC(2) not null,
  SCORING_DATE_TIME DATETIME not null,
  AGE               NUMERIC(3),
  HR                NUMERIC(5),
  SBP               NUMERIC(5),
  TMP               NUMERIC(5,2),
  PAO2              NUMERIC(6,2),
  FIO2              NUMERIC(6,2),
  EMICTION          NUMERIC(8,4),
  BUN               NUMERIC(6,2),
  WBC               NUMERIC(6,2),
  K                 NUMERIC(6,2),
  NA                NUMERIC(6,2),
  HCO3              NUMERIC(6,2),
  BBIL              NUMERIC(6,2),
  ICU_TYPE          NUMERIC(2),
  DISEASE1          NUMERIC(2),
  DISEASE2          NUMERIC(2),
  DISEASE3          NUMERIC(2),
  EYES_REFLECT      NUMERIC(1),
  TALK_REFLECT      NUMERIC(1),
  LIMB_REFLECT      NUMERIC(1),
  MEMO              NVARCHAR(100),
  constraint PK_SAPS2_SCORING_RESULT primary key (PATIENT_ID, VISIT_ID, SCORING_DATE_TIME)
)
---------------124 重评分相关脚本----------------
create table SCORING_ITEM_LIST
(
  SCORING_METHOD      NVARCHAR(20) not null,
  ITEM_CLASS          NVARCHAR(20) not null,
  ITEM_NAME           NVARCHAR(100) not null,
  ITEM_NO             NUMERIC(2) not null,
  ITEM_SOURCE         NUMERIC(2),
  ITEM_VALUE_DESCRIBE NUMERIC(2),
  UPPER_LEVEL         NUMERIC(8,4),
  LOW_LEVEL           NUMERIC(8,4),
  ITEM_VALUE          NUMERIC(8,4),
  VALUE_OPTIONS       NVARCHAR(200),
  MULTIPLE            NUMERIC(2),
  MEMO                NVARCHAR(1000),
  UPDATED_DATE_TIME   DATETIME,
  constraint PK_SCORING_ITEM_LIST primary key (SCORING_METHOD, ITEM_CLASS, ITEM_NAME, ITEM_NO)
)
---------------125 重评分相关脚本----------------
create table SCORING_METHOD_DICT
(
  SCORING_METHOD NVARCHAR(20) not null,
  ENGLISH_NAME   NVARCHAR(80),
  CHINESE_NAME   NVARCHAR(80),
  ARITH_FORMULA  NVARCHAR(4000),
  MEMO           NVARCHAR(1000),
  constraint PK_SCORING_METHOD_DICT primary key (SCORING_METHOD)
)
---------------126 重评分相关脚本----------------
create table SCORING_VALUE_MEMO_DICT
(
  SCORING_METHOD NVARCHAR(20) not null,
  UPPER_LEVEL    NUMERIC(8) not null,
  LOW_LEVEL      NUMERIC(8),
  DEGREE         NVARCHAR(40),
  MEMO           NVARCHAR(200),
  constraint PK_SCORING_VALUE_MEMO_DICT primary key (SCORING_METHOD, UPPER_LEVEL)
)
---------------127 重评分相关脚本----------------
create table SOFA_SCORING_RESULT_DETAIL
(
  PATIENT_ID        NVARCHAR(10) not null,
  VISIT_ID          NUMERIC(2) not null,
  SCORING_DATE_TIME DATETIME not null,
  S1                NUMERIC(6,2),
  S2                NUMERIC(6,2),
  S3                NUMERIC(1),
  S4                NUMERIC(1),
  S5                NUMERIC(1),
  S6                NUMERIC(1),
  EYES_REFLECT      NUMERIC(1),
  TALK_REFLECT      NUMERIC(1),
  LIMB_REFLECT      NUMERIC(1),
  MEMO              NVARCHAR(100),
  constraint PK_SOFA_SCORING_RESULT primary key (PATIENT_ID, VISIT_ID, SCORING_DATE_TIME)
)
---------------128 重评分相关脚本----------------
create table SSSS_SCORING_RESULT_DETAIL
(
  PATIENT_ID        NVARCHAR(10) not null,
  VISIT_ID          NUMERIC(2) not null,
  SCORING_DATE_TIME DATETIME not null,
  S1                NUMERIC(1),
  S2                NUMERIC(1),
  S3                NUMERIC(1),
  S41               NUMERIC(1),
  S42               NUMERIC(1),
  S43               NUMERIC(1),
  S5                NUMERIC(1),
  S6                NUMERIC(1),
  S7                NUMERIC(1),
  S8                NUMERIC(1),
  S9                NUMERIC(1),
  S10               NUMERIC(1),
  S11               NUMERIC(1),
  S12               NUMERIC(1),
  S13               NUMERIC(1),
  S14               NUMERIC(1),
  MEMO              NVARCHAR(100),
  constraint PK_SSSS_SCORING_RESULT primary key (PATIENT_ID, VISIT_ID, SCORING_DATE_TIME)
)
---------------129 重评分相关脚本----------------
create table SSS_SCORING_RESULT_DETAIL
(
  PATIENT_ID        NVARCHAR(10) not null,
  VISIT_ID          NUMERIC(2) not null,
  SCORING_DATE_TIME DATETIME not null,
  S1                NUMERIC(1),
  S2                NUMERIC(1),
  S3                NUMERIC(1),
  S4                NUMERIC(1),
  S5                NUMERIC(1),
  S6                NUMERIC(1),
  S7                NUMERIC(1),
  MEMO              NVARCHAR(100),
  constraint PK_SSS_SCORING_RESULT primary key (PATIENT_ID, VISIT_ID, SCORING_DATE_TIME)
)
---------------130 重评分相关脚本----------------
create table TISS_SCORING_RESULT_DETAIL
(
  PATIENT_ID        NVARCHAR(10) not null,
  VISIT_ID          NUMERIC(2) not null,
  SCORING_DATE_TIME DATETIME not null,
  T41               NUMERIC(1),
  T42               NUMERIC(1),
  T43               NUMERIC(1),
  T44               NUMERIC(1),
  T45               NUMERIC(1),
  T46               NUMERIC(1),
  T47               NUMERIC(1),
  T48               NUMERIC(1),
  T49               NUMERIC(1),
  T410              NUMERIC(1),
  T411              NUMERIC(1),
  T412              NUMERIC(1),
  T413              NUMERIC(1),
  T414              NUMERIC(1),
  T415              NUMERIC(1),
  T416              NUMERIC(1),
  T417              NUMERIC(1),
  T418              NUMERIC(1),
  T419              NUMERIC(1),
  T31               NUMERIC(1),
  T32               NUMERIC(1),
  T33               NUMERIC(1),
  T34               NUMERIC(1),
  T35               NUMERIC(1),
  T36               NUMERIC(1),
  T37               NUMERIC(1),
  T38               NUMERIC(1),
  T39               NUMERIC(1),
  T310              NUMERIC(1),
  T311              NUMERIC(1),
  T312              NUMERIC(1),
  T313              NUMERIC(1),
  T314              NUMERIC(1),
  T315              NUMERIC(1),
  T316              NUMERIC(1),
  T317              NUMERIC(1),
  T318              NUMERIC(1),
  T319              NUMERIC(1),
  T320              NUMERIC(1),
  T321              NUMERIC(1),
  T322              NUMERIC(1),
  T323              NUMERIC(1),
  T324              NUMERIC(1),
  T325              NUMERIC(1),
  T326              NUMERIC(1),
  T327              NUMERIC(1),
  T328              NUMERIC(1),
  T21               NUMERIC(1),
  T22               NUMERIC(1),
  T23               NUMERIC(1),
  T24               NUMERIC(1),
  T25               NUMERIC(1),
  T26               NUMERIC(1),
  T27               NUMERIC(1),
  T28               NUMERIC(1),
  T29               NUMERIC(1),
  T210              NUMERIC(1),
  T211              NUMERIC(1),
  T11               NUMERIC(1),
  T12               NUMERIC(1),
  T13               NUMERIC(1),
  T14               NUMERIC(1),
  T15               NUMERIC(1),
  T16               NUMERIC(1),
  T17               NUMERIC(1),
  T18               NUMERIC(1),
  T19               NUMERIC(1),
  T110              NUMERIC(1),
  T111              NUMERIC(1),
  T112              NUMERIC(1),
  T113              NUMERIC(1),
  T114              NUMERIC(1),
  T115              NUMERIC(1),
  T116              NUMERIC(1),
  T117              NUMERIC(1),
  T118              NUMERIC(1),
  MEMO              NVARCHAR(100),
  constraint PK_TISS_SCORING_RESULT primary key (PATIENT_ID, VISIT_ID, SCORING_DATE_TIME)
)
---------------131 重评分相关脚本----------------
create table pat_adm_condition_dict
	(
	serial_no				NUMERIC(1),
	pat_condition_code			NVARCHAR(1),
	pat_condition_name			NVARCHAR(10),
	input_code				NVARCHAR(8),
	constraint pk_pat_adm_condition_dict primary key	(	pat_condition_code	)
	);
---------------132 重评分相关脚本----------------
create table patient_class_dict
	(
	serial_no				NUMERIC(1),
	patient_class_code			NVARCHAR(1),
	patient_class_name			NVARCHAR(4),
	input_code				NVARCHAR(8),
	constraint pk_patient_class_dict	primary key	(	patient_class_code )
	);
---------------133 重评分相关脚本----------------
create table MED_OPERATION_CHECKED_NEW
(
  PATIENT_ID NVARCHAR(20) not null,
  VISIT_ID   NUMERIC(2) not null,
  OPER_ID    NUMERIC(2) not null,
  A1         NVARCHAR(10),
  A2         NVARCHAR(10),
  A3         NVARCHAR(10),
  A4         NVARCHAR(10),
  A5         NVARCHAR(10),
  A6         NVARCHAR(10),
  A7         NVARCHAR(10),
  A8         NVARCHAR(10),
  A9         NVARCHAR(10),
  A10        NVARCHAR(10),
  A11        NVARCHAR(10),
  A12        NVARCHAR(10),
  A13        NVARCHAR(10),
  A14        NVARCHAR(10),
  A15        NVARCHAR(10),
  A16        NVARCHAR(10),
  A17        NVARCHAR(100),
  A18        NVARCHAR(10),
  A19        NVARCHAR(10),
  A20        NVARCHAR(10),
  A21        NVARCHAR(10),
  A22        NVARCHAR(10),
  A23        NVARCHAR(10),
  A24        NVARCHAR(10),
  A25        NVARCHAR(10),
  A26        NVARCHAR(10),
  A27        NVARCHAR(10),
  A28        NVARCHAR(10),
  A29        NVARCHAR(10),
  A30        NVARCHAR(10),
  A31        NVARCHAR(10),
  A32        NVARCHAR(100),
  A33        NVARCHAR(10),
  A34        NVARCHAR(10),
  A35        NVARCHAR(10),
  A36        NVARCHAR(10),
  A37        NVARCHAR(10),
  A38        NVARCHAR(10),
  A39        NVARCHAR(10),
  A40        NVARCHAR(10),
  A41        NVARCHAR(10),
  A42        NVARCHAR(10),
  A43        NVARCHAR(10),
  A44        NVARCHAR(10),
  A45        NVARCHAR(10),
  A46        NVARCHAR(40),
  A47        NVARCHAR(10),
  A48        NVARCHAR(10),
  A49        NVARCHAR(10),
  A50        NVARCHAR(10),
  A51        NVARCHAR(10),
  A52        NVARCHAR(100),
  A53        NVARCHAR(10),
  A54        NVARCHAR(20),
  A55        NVARCHAR(20),
  A56        NVARCHAR(20),
  A57        NVARCHAR(20),
  A58        NVARCHAR(20),
  A59        NVARCHAR(20),
  A60        NVARCHAR(20),
  A61        NVARCHAR(20),
  A62        NVARCHAR(20),
  A63        NVARCHAR(20),
  A64        NVARCHAR(20),
  A65        NVARCHAR(20),
  A66        NVARCHAR(20),
  A67        NVARCHAR(20),
  A68        NVARCHAR(20),
  A69        NVARCHAR(20),
  A70        NVARCHAR(20),
  A71        NVARCHAR(20),
  A72        NVARCHAR(20),
  A73        NVARCHAR(20),
  A74        NVARCHAR(20),
  A75        NVARCHAR(20),
  A76        NVARCHAR(20),
  A77        NVARCHAR(20),
  A78        NVARCHAR(20),
  A79        NVARCHAR(20),
  A80        NVARCHAR(20),
  A81        NVARCHAR(20),
  A82        NVARCHAR(20),
  A83        NVARCHAR(20),
  A84        NVARCHAR(20),
  A85        NVARCHAR(20),
  A86        NVARCHAR(20),
  A87        NVARCHAR(20),
  A88        NVARCHAR(20),
  A89        NVARCHAR(20),
  A90        NVARCHAR(20),
  A91        NVARCHAR(20),
  A92        NVARCHAR(20),
  A93        NVARCHAR(20),
  A94        NVARCHAR(20),
  A95        NVARCHAR(20),
  A96        NVARCHAR(20),
  A97        NVARCHAR(20),
  A98        NVARCHAR(20),
  A99        NVARCHAR(20),
  A100       NVARCHAR(20),
  A101       NVARCHAR(20),
  A102       NVARCHAR(20),
  A103       NVARCHAR(20),
  A104       NVARCHAR(20),
  A105       NVARCHAR(20),
  A106       NVARCHAR(20),
  A107       NVARCHAR(20),
  A108       NVARCHAR(20),
  A109       NVARCHAR(20),
  A110       NVARCHAR(20),
  constraint PK_MED_OPERATION_CHECKED_NEW primary key (PATIENT_ID, VISIT_ID, OPER_ID)
)
---------------134 5.0专用----------------
CREATE TABLE MED_EQIP_CHECK_RECORD(
	PATIENT_ID NVARCHAR(20) NOT NULL,
	VISIT_ID NUMERIC(2,0) NOT NULL,
	OPER_ID NUMERIC(2,0) NOT NULL,
	OPERATION_EQUIP_NAME NVARCHAR(20) NOT NULL,
	NUM_BEFORE_OPER NUMERIC(10, 0) NULL,
	NUM_ADDED_DURING_OPER NUMERIC(10, 0) NULL,
	NUM_BEFORE_ABDOMINAL_CLOSURE NUMERIC(10, 0) NULL,
	NUM_AFTER_ABDOMINAL_CLOSURE NUMERIC(10, 0) NULL,
	RECORD_DATE DATETIME NULL,
	MEMO NVARCHAR(200) NULL,
 CONSTRAINT EQIP_CHECK_RECORD PRIMARY KEY  
(
	PATIENT_ID ,
	VISIT_ID ,
	OPER_ID ,
	OPERATION_EQUIP_NAME
)
);
---------------135 5.0专用----------------
CREATE TABLE MED_OPERATION_EQIP_CHECK_DICT(
	SERIAL_NO NUMERIC(2, 0) NULL,
	OPERATION_EQIP_CODE NUMERIC(2, 0) NULL,
	OPERATION_EQIP_NAME NVARCHAR(20) NOT NULL,
	INPUT_CODE NVARCHAR(8) NULL,
 CONSTRAINT OPERATION_EQIP_CHECK_DICT PRIMARY KEY  
(
	OPERATION_EQIP_NAME
)
)
---------------136 5.0专用----------------
create table EQUIP_MATERIAL
(
  PATIENT_ID NVARCHAR(20) not null,
  VISIT_ID   NUMERIC(2) not null,
  OPER_ID    NUMERIC(2) not null,
  ITEMNO     NUMERIC(3) not null,
  EQUIPNAME  NVARCHAR(100) not null,
  BEFOREOPER NUMERIC(2),
  INOPER     NUMERIC(2),
  BEFOREROOM NUMERIC(2),
  BEFOREDOOR NUMERIC(2),
  AFTERDOOR  NUMERIC(2),
  constraint PK_EQUIP_MATERIAL primary key (PATIENT_ID, VISIT_ID, OPER_ID, ITEMNO)
)
---------------137 5.0专用----------------
create table GUID_PARAMS
(
  GUID  NVARCHAR(40) not null,
  PARAM NVARCHAR(40) not null,
  constraint PK_GUID_PARAMS primary key (GUID, PARAM)
)
---------------138 5.0专用----------------
create table MED_ANESTHESIA_MASTER
(
  PATIENT_ID           NVARCHAR(20) not null,
  VISIT_ID             NUMERIC(2) not null,
  OPER_ID              NUMERIC(2) not null,
  LARYNGOSCOPE         NVARCHAR(80),
  TRACHEA_TUBE         NVARCHAR(200),
  HEART_LUNG_TIME      NUMERIC(6),
  LOW_FLOW_TIME        NUMERIC(6),
  STOP_LOOP_TIME       NUMERIC(6),
  SEPARATE_LOOP_TIME   NUMERIC(6),
  PRE_STUFF_VOLUME     NUMERIC(8,4),
  REMAIN_VOLUME        NUMERIC(8,4),
  FILTER_VOLUME        NUMERIC(8,4),
  BACKFLOW_VOLUME      NUMERIC(8,4),
  EST_BLOODLOST_VOLUME NUMERIC(8,4),
  HEART_LUNG_OPERATOR  NVARCHAR(200),
  ANESTHESIA_DOCTOR    NVARCHAR(80),
  constraint PKANESTHESIAMASTER primary key (PATIENT_ID, VISIT_ID, OPER_ID)
)
---------------139 5.0专用----------------
create table MED_ANES_TYPE_DICT
(
  PRIMARY_KEY NVARCHAR(36) not null,
  NAME        NVARCHAR(60) not null,
  CODE        NVARCHAR(20),
  PARENT_KEY  NVARCHAR(36),
  constraint PK_MED_ANES_TYPE_DICT primary key (PRIMARY_KEY)
)
---------------140 5.0专用----------------
create table MED_CONFIG
(
  PARAKEY   NVARCHAR(50) not null,
  PARAVALUE IMAGE,
   constraint PK_MED_CONFIG primary key (PARAKEY)
)
---------------141 5.0专用----------------
create table MED_CUSTOMFIELD_DICT
(
  FIELD_NAME NVARCHAR(60) not null,
  FIELD_TYPE NVARCHAR(16),
  FIELD_DESC NVARCHAR(200),
  ALIAS_NAME NVARCHAR(60),
  constraint PK_MED_CUSTOMFIELD_DICT primary key (FIELD_NAME)
)
---------------142 5.0专用----------------
create table MED_CUSTOM_DATA
(
  PATIENT_ID NVARCHAR(20) not null,
  VISIT_ID   NUMERIC(2) not null,
  OPER_ID    NUMERIC(2) not null,
  ITEM_NAME  NVARCHAR(60) not null,
  ITEM_VALUE NVARCHAR(1000),
  constraint PK_MED_CUSTOM_DATA primary key (PATIENT_ID, VISIT_ID, OPER_ID, ITEM_NAME)
)
---------------143 5.0专用----------------
create table MED_CUSTOM_DATA_EXT
(
  PATIENT_ID NVARCHAR(20) not null,
  VISIT_ID   NUMERIC(2) not null,
  OPER_ID    NUMERIC(2) not null,
  ITEM_NAME  NVARCHAR(60) not null,
  ITEM_VALUE IMAGE,
  constraint PK_MED_CUSTOM_DATA_EXT primary key (PATIENT_ID, VISIT_ID, OPER_ID, ITEM_NAME)
)
---------------144 5.0专用----------------
create table MED_DICT_SIMPLETYPES
(
  TYPEKEY   NVARCHAR(100) not null,
  TYPEVALUE NVARCHAR(100) not null,
  constraint PK_MED_DICT_SIMPLETYPES primary key (TYPEKEY, TYPEVALUE)
)
---------------145 5.0专用----------------
create table MED_DICT_SIMPLETYPES_TREE
(
  PARENTTYPEKEY NVARCHAR(100) not null,
  CHILDTYPEKEY  NVARCHAR(100) not null,
  constraint PK_MED_DICT_SIMPLETYPES_TREE primary key (PARENTTYPEKEY, CHILDTYPEKEY)
)
---------------146 5.0专用----------------
create table MED_DOCUMENT
(
  DOCUMENTNAME    NVARCHAR(50) not null,
  DOCUMENTPATH    NVARCHAR(50) not null,
  DOCUMENTCONTENT IMAGE,
  DOCUMENTTIME    DATETIME,
  constraint PK_MED_DOCUMENT primary key (DOCUMENTNAME, DOCUMENTPATH)
)
---------------147 5.0专用----------------
create table MED_DOCUMENT_TEMPLET
(
  TEMPLET_GUID  NVARCHAR(50) not null,
  USER_ID       NVARCHAR(50) not null,
  DOCUMENT_NAME NVARCHAR(50) not null,
  CLASS_NAME    NVARCHAR(50) not null,
  TEMPLET_NAME  NVARCHAR(50) not null,
  ISJUBU        NUMERIC(1) not null,
  ISPRIVATE     NUMERIC(1) not null,
  TEMPLET_VALUE IMAGE,
  constraint PK_MED_DOCUMENT_TEMPLET primary key (TEMPLET_GUID)
)
---------------148 5.0专用----------------
create table MED_JS_MZKCAOZHUO
(
  PATIENT_ID    NVARCHAR(20) not null,
  VISIT_ID      NUMERIC not null,
  OPER_ID       NUMERIC not null,
  OPERATIONNAME NVARCHAR(50),
  OPERATIONMEMO NVARCHAR(1000),
  ADVICEOPTDATE DATETIME,
  ADVICECUREWAY NVARCHAR(50),
  constraint PK_MED_JS_MZKCAOZHUO primary key (PATIENT_ID, VISIT_ID, OPER_ID)
)
---------------149 5.0专用----------------
create table MED_JS_SHOUHOUZHENTONG
(
  PATIENT_ID     NVARCHAR(20) not null,
  VISIT_ID       NUMERIC not null,
  OPER_ID        NUMERIC not null,
  ROUTE          NVARCHAR(50),
  LOADMACHINE    NVARCHAR(50),
  EXCLUDEHINDER  NVARCHAR(50),
  VAS            NVARCHAR(50),
  COMPLICATION   NVARCHAR(50),
  PRESCRIPTION   NVARCHAR(50),
  UNLOADMACHINE  NVARCHAR(50),
  ZHENTONGMETHOD NVARCHAR(50),
  constraint PK_MED_JS_SHOUHOUZHENTONG primary key (PATIENT_ID, VISIT_ID, OPER_ID)
)
---------------150 5.0专用----------------
create table MED_JS_SHUHOUBINGQING
(
  PATIENT_ID    NVARCHAR(20) not null,
  VISIT_ID      NUMERIC not null,
  OPER_ID       NUMERIC not null,
  RECORDTIME    DATETIME,
  SENSE         NVARCHAR(20),
  BLOODPRESSURE NVARCHAR(50),
  PULSE         NVARCHAR(50),
  BREATH        NVARCHAR(50),
  SPO2          NVARCHAR(50),
  ECG           NVARCHAR(50),
  OTHER         NVARCHAR(200),
  constraint PK_MED_JS_SHUHOUBINGQING primary key (PATIENT_ID, VISIT_ID, OPER_ID)
)
---------------151 5.0专用----------------
create table MED_JS_SHUQIANFANGTAN
(
  PATIENT_ID                   NVARCHAR(20) not null,
  VISIT_ID                     NUMERIC not null,
  OPER_ID                      NUMERIC not null,
  HASOPERATION                 NVARCHAR(10),
  OPERATIONNAME                NVARCHAR(50),
  HASSMOKING                   NVARCHAR(10),
  SMOKINGSTARTYEAR             NVARCHAR(4),
  SMOKINGENDYEAR               NVARCHAR(4),
  SMOKINGDAYS                  NVARCHAR(10),
  HASDRINKING                  NVARCHAR(10),
  DRINKINGAMOUNT               NVARCHAR(10),
  HASASTHMA                    NVARCHAR(10),
  ASTHMATYPE                   NVARCHAR(100),
  ASTHMARATE                   NVARCHAR(20),
  HASRECENTCOLD                NVARCHAR(10),
  HASRECENTCOUGH               NVARCHAR(10),
  COUGHMEMO                    NVARCHAR(100),
  HASCHESTPAIN                 NVARCHAR(10),
  CHESTPAINMEMO                NVARCHAR(100),
  HASHYPERTENSION              NVARCHAR(10),
  HYPERTENSIONHIGHHIGHPRESSURE NVARCHAR(10),
  HYPERTENSIONHIGHLOWPRESSURE  NVARCHAR(10),
  HYPERTENSIONLOWHIGHPRESSURE  NVARCHAR(10),
  HYPERTENSIONLOWLOWPRESSURE   NVARCHAR(10),
  HYPERTENSIONACTIVEMEMO       NVARCHAR(200),
  HASDIABETES                  NVARCHAR(10),
  DIABETESCUREWAY              NVARCHAR(50),
  BLEEDORGANS                  NVARCHAR(50),
  HASBLUEPURPLE                NVARCHAR(10),
  HASDRUGALLERGY               NVARCHAR(10),
  ALLERGYDRUG                  NVARCHAR(100),
  HASDRUG                      NVARCHAR(10),
  RECENTDRUG                   NVARCHAR(100),
  BLOODPRESSURE                NVARCHAR(100),
  PULSE                        NVARCHAR(100),
  PUPILREGULAR                 NVARCHAR(10),
  PUPILLEFT                    NVARCHAR(10),
  PUPILRIGHT                   NVARCHAR(10),
  OPENDEGREE                   NVARCHAR(20),
  HEADNECKACTIVE               NVARCHAR(20),
  FALSETEETH                   NVARCHAR(10),
  ACTVETEETH                   NVARCHAR(10),
  EASYWOUNDEDTEETH             NVARCHAR(10),
  BOTHBREATH                   NVARCHAR(10),
  SPINEPAIN                    NVARCHAR(50),
  SKINCATCH                    NVARCHAR(50),
  CANNOTCHECK                  NVARCHAR(10),
  FROBIDFOODSTART              NVARCHAR(10),
  FROBIDDRINKSTART             NVARCHAR(10),
  MORNINGDRUG                  NVARCHAR(100),
  MORNINGDRUGHOUR              NVARCHAR(10),
  STOPDRUG                     NVARCHAR(100),
  ADVICE1                      NVARCHAR(100),
  ADVICE2                      NVARCHAR(100),
  ADVICE3                      NVARCHAR(100),
  constraint PK_MED_JS_SHUQIANFANGTAN primary key (PATIENT_ID, VISIT_ID, OPER_ID)
)
---------------152 5.0专用----------------
create table MED_MODIFY_HISTORY
(
  TABLE_NAME  NVARCHAR(100) not null,
  FIELD_NAME  NVARCHAR(50) not null,
  PRIMARY_KEY NVARCHAR(200) not null,
  NEW_VALUE   NVARCHAR(100),
  OLD_VALUE   NVARCHAR(100),
  MODIFY_TIME DATETIME not null,
  OPERATOR    NVARCHAR(8) not null,
  constraint PK_MED_MODIFY_HISTORY primary key (TABLE_NAME, FIELD_NAME, PRIMARY_KEY, MODIFY_TIME)
)
---------------153 5.0专用----------------
create table MED_NORMAL_TYPE_DICT
(
  PRIMARY_KEY NVARCHAR(36) not null,
  NAME        NVARCHAR(60) not null,
  PARENT_KEY  NVARCHAR(36),
  constraint PK_MED_NORMAL_TYPE_DICT primary key (PRIMARY_KEY)
)
---------------154 5.0专用----------------
create table MED_PATIENT_MONITOR_CONFIG
(
  PATIENT_ID NVARCHAR(20) not null,
  VISIT_ID   NUMERIC(2) not null,
  OPER_ID    NUMERIC(2) not null,
  CONTENT    IMAGE,
  constraint PK_MED_PATIENT_MONITOR_CONFIG primary key (PATIENT_ID, VISIT_ID, OPER_ID)
)
---------------155 5.0专用----------------
create table MED_PATIENT_MONITOR_DATA
(
  PATIENT_ID     NVARCHAR(20) not null,
  VISIT_ID       NUMERIC(2) not null,
  OPER_ID        NUMERIC(2) not null,
  TIME_POINT     DATETIME not null,
  ITEM_NAME      NVARCHAR(20) not null,
  ITEM_VALUE     NVARCHAR(20) not null,
  RECORDING_DATE DATETIME not null,
  OPERATOR       NVARCHAR(8) not null,
  EVENT_NO       NUMERIC(3) not null,
  constraint PKPATMONITORDATA primary key (PATIENT_ID, VISIT_ID, OPER_ID, TIME_POINT, ITEM_NAME,EVENT_NO)
)
---------------156 5.0专用----------------
create table MED_PERKIND_RELA
(
  KIND_ID       NVARCHAR(36) not null,
  PERMISSION_ID NVARCHAR(36) not null,
  constraint PK_MED_PERKIND_RELA primary key (KIND_ID, PERMISSION_ID)
)
---------------157 5.0专用----------------
create table MED_PERMISSIONS_KIND
(
  KIND_ID     NVARCHAR(36) not null,
  APP_ID      NVARCHAR(36) not null,
  NAME        NVARCHAR(60) not null,
  SORT_ID     NUMERIC(38),
  IS_VALID    NVARCHAR(1) not null,
  DESCRIPTION NVARCHAR(160),
  constraint PK_MED_PERMISSIONS_KIND primary key (KIND_ID)
)
---------------158 5.0专用----------------
create table MED_PLANDRUGS
(
  PATIENT_ID NVARCHAR(20) not null,
  VISIT_ID   NUMERIC(2) not null,
  OPER_ID    NUMERIC(2) not null,
  DRUG_TYPE  NVARCHAR(50),
  ITEM_CODE  NVARCHAR(50),
  DOSAGE     NUMERIC(8,4),
  constraint PK_MED_PLANDRUGS primary key (PATIENT_ID, VISIT_ID, OPER_ID)
)
---------------159 5.0专用----------------
create table OPER_SAFE_CHECK
(
  PATIENT_ID            NVARCHAR(20) not null,
  VISIT_ID              NUMERIC(2) not null,
  OPER_ID               NUMERIC(2) not null,
  ITEM_NO               NUMERIC(2) not null,
  [IDENTITY]              NVARCHAR(20),
  AGREEMENT             NVARCHAR(20),
  DIAGNOSIS_BEFORE_OPER NVARCHAR(20),
  OPER_POSITION         NVARCHAR(20),
  OPER_POSITION1        NVARCHAR(20),
  SURGEON               NVARCHAR(20),
  ANESDOCTOR            NVARCHAR(20),
  NURSE_IN_OPERROOM     NVARCHAR(20),
  SURGEON1              NVARCHAR(20),
  MEMO                  NVARCHAR(1000),
  constraint PK_OPER_SAFE_CHECK primary key (PATIENT_ID, VISIT_ID, OPER_ID, ITEM_NO)
)
---------------160 5.0专用--------------------------------------
create table PATIENT_EXTEND_INFO
(
  PATIENT_ID NVARCHAR(20) not null,
  VISIT_ID   NUMERIC(2) not null,
  OPER_ID    NUMERIC(2) not null,
  LKEY       NVARCHAR(100) not null,
  LVALUE     NVARCHAR(1000),
  constraint PK_PATIENT_EXTEND_INFO primary key (PATIENT_ID, VISIT_ID, OPER_ID, LKEY)
)
---------------161 5.0专用---------------------------------------
alter table MED_OPERATION_MASTER add SCHEDULED_DATE_TIME DATETIME;
alter table MED_OPERATION_MASTER add BED_NO NVARCHAR(20);
alter table MED_OPERATION_MASTER add REQ_DATE_TIME DATETIME;
alter table MED_OPERATION_MASTER add QIEKOU_CLASS NVARCHAR(20);
alter table MED_OPERATION_MASTER add QIEKOU_NUMBER NUMERIC(6);
alter table MED_OPERATION_MASTER add MEMO1 NVARCHAR(200);
alter table MED_OPERATION_MASTER add OPERATION_NAME NVARCHAR(80);
alter table MED_OPERATION_MASTER add MEN_ZHEN NVARCHAR(20);
alter table MED_OPERATION_MASTER add ANESTHESIA_RESULT NVARCHAR(20);
alter table MED_OPERATION_MASTER add SIMPLE_SICK NVARCHAR(20);
alter table MED_OPERATION_MASTER add ISOLATION_NEED NVARCHAR(20);
alter table MED_OPERATION_MASTER add DANBINGZHONG NVARCHAR(20);
alter table MED_OPERATION_MASTER add YIBAO NVARCHAR(20);
alter table MED_OPERATION_MASTER add FIRST_SHIFT_SUPPLY_NURSE NVARCHAR(8);
alter table MED_OPERATION_MASTER add FIRST_SHIFT_OPERATION_NURSE NVARCHAR(8);
alter table MED_OPERATION_MASTER add FIRST_SHIFT_SUPPLY_DATE DATETIME;
alter table MED_OPERATION_MASTER add FIRST_SHIFT_OPERATION_DATE DATETIME;
alter table MED_OPERATION_MASTER add ANES_START_TIME DATETIME;
alter table MED_OPERATION_MASTER add ANES_END_TIME DATETIME;
alter table MED_OPERATION_MASTER add INDUCE_START_TIME DATETIME;
alter table MED_OPERATION_MASTER add INDUCE_END_TIME DATETIME;
alter table MED_OPERATION_MASTER add PACU_START_TIME DATETIME;
alter table MED_OPERATION_MASTER add PACU_END_TIME DATETIME;
alter table MED_OPERATION_MASTER add DONE_DATE_TIME DATETIME;
alter table MED_OPERATION_MASTER add CANCEL_DATE_TIME DATETIME;
alter table MED_OPERATION_MASTER add ANALGESIC_PUMPS NVARCHAR(100);

alter table MED_OPERATION_MASTER alter column DEPT_STAYED NVARCHAR(8);
alter table MED_OPERATION_MASTER alter column OPERATING_ROOM NVARCHAR(8);
alter table MED_OPERATION_MASTER alter column OPERATING_DEPT NVARCHAR(8);
alter table MED_OPERATION_MASTER alter column SURGEON NVARCHAR(8);
alter table MED_OPERATION_MASTER alter column FIRST_ASSISTANT NVARCHAR(8);
alter table MED_OPERATION_MASTER alter column SECOND_ASSISTANT NVARCHAR(8);
alter table MED_OPERATION_MASTER alter column THIRD_ASSISTANT NVARCHAR(8);
alter table MED_OPERATION_MASTER alter column FOURTH_ASSISTANT NVARCHAR(8);
alter table MED_OPERATION_MASTER alter column ANESTHESIA_DOCTOR NVARCHAR(8);
alter table MED_OPERATION_MASTER alter column ANESTHESIA_ASSISTANT NVARCHAR(8);
alter table MED_OPERATION_MASTER alter column BLOOD_TRAN_DOCTOR NVARCHAR(8);
alter table MED_OPERATION_MASTER alter column FIRST_OPERATION_NURSE NVARCHAR(8);
alter table MED_OPERATION_MASTER alter column SECOND_OPERATION_NURSE NVARCHAR(8);
alter table MED_OPERATION_MASTER alter column FIRST_SUPPLY_NURSE NVARCHAR(8);
alter table MED_OPERATION_MASTER alter column SECOND_SUPPLY_NURSE NVARCHAR(8);
alter table MED_OPERATION_MASTER alter column ENTERED_BY NVARCHAR(8);
alter table MED_OPERATION_MASTER alter column THIRD_SUPPLY_NURSE NVARCHAR(8);
alter table MED_OPERATION_MASTER alter column OPER_STATUS NUMERIC(2) ;
alter table MED_OPERATION_MASTER alter column SECOND_ANESTHESIA_ASSISTANT NVARCHAR(8);
alter table MED_OPERATION_MASTER alter column THIRD_ANESTHESIA_ASSISTANT NVARCHAR(8);
alter table MED_OPERATION_MASTER alter column FOURTH_ANESTHESIA_ASSISTANT NVARCHAR(8);
alter table MED_OPERATION_MASTER alter column OPERATION_POSITION NVARCHAR(16);
alter table MED_OPERATION_MASTER alter column SECOND_ANESTHESIA_DOCTOR NVARCHAR(8);
alter table MED_OPERATION_MASTER alter column THIRD_ANESTHESIA_DOCTOR NVARCHAR(8);

---------------162 体外循环新建表脚本--------------------
CREATE TABLE  MED_CPB_BLG_RECORD(
	 PATIENT_ID  NVARCHAR(50) NOT NULL,
	 VISIT_ID  NUMERIC(2, 0) NOT NULL,
	 OPER_ID  NUMERIC(2, 0) NOT NULL,
	 RECORD_NAME  NVARCHAR(50) NOT NULL,
	 DETAIL_ID  NVARCHAR(50) NULL,
	 RECORD_DATE  DATETIME NULL,
   constraint PK_MED_CPB_BLG_RECORD primary key (PATIENT_ID, VISIT_ID,OPER_ID,RECORD_NAME)
)
---------------163 体外循环新建表脚本--------------------
CREATE TABLE  MED_CPB_EVENT_OPEN(
	 ITEM_NO  NUMERIC(3, 0) NOT NULL,
	 ITEM_CLASS  NVARCHAR(4) NOT NULL,
	 ITEM_NAME  NVARCHAR(100) NULL,
	 ITEM_CODE  NVARCHAR(40) NULL,
	 ITEM_SPEC  NVARCHAR(40) NULL,
	 DOSAGE  NUMERIC(8, 4) NULL,
	 DOSAGE_UNITS  NVARCHAR(20) NULL,
	 ADMINISTRATOR  NVARCHAR(20) NULL,
	 IN_ORDER  NUMERIC(1, 0) NULL,
	 REL_BILL  NUMERIC(1, 0) NULL,
	 OPER_CLASS  NVARCHAR(40) NULL,
	 DURATIVE_INDICATOR  NUMERIC(1, 0) NULL,
	 METHOD  NVARCHAR(40) NULL,
	 PERFORM_SPEED  NUMERIC(8, 4) NULL,
	 SPEED_UNIT  NVARCHAR(20) NULL,
	 EVENT_ATTR  NVARCHAR(20) NULL,
	 CONCENTRATION  NUMERIC(8, 4) NULL,
	 CONCENTRATION_UNIT  NVARCHAR(20) NULL,
	 EVENT_ATTR2  NVARCHAR(40) NULL,
	 SUPPLIER_NAME  NVARCHAR(100) NULL,
	 STANDARD_DOSAGE1  NUMERIC(8, 4) NULL,
	 STANDARD_DOSAGE2  NUMERIC(8, 4) NULL,
	 STANDARD_DOSAGE3  NUMERIC(8, 4) NULL,
	 STANDARD_DOSAGE4  NUMERIC(8, 4) NULL,
	 STANDARD_DOSAGE5  NUMERIC(8, 4) NULL,
	 STANDARD_DOSAGE6  NUMERIC(8, 4) NULL,
	 STANDARD_DOSAGE7  NUMERIC(8, 4) NULL,
	 STANDARD_DOSAGE8  NUMERIC(8, 4) NULL,
	 STANDARD_DOSAGE9  NUMERIC(8, 4) NULL,
	 STANDARD_DOSAGE10  NUMERIC(8, 4) NULL,
	 STANDARD_DOSAGE11  NUMERIC(8, 4) NULL,
	 STANDARD_DOSAGE12  NUMERIC(8, 4) NULL,
	 STANDARD_DOSAGE13  NUMERIC(8, 4) NULL,
	 STANDARD_DOSAGE14  NUMERIC(8, 4) NULL,
	 STANDARD_DOSAGE15  NUMERIC(8, 4) NULL,
 CONSTRAINT PK_MED_CPB_EVENT_OPEN PRIMARY KEY(ITEM_NO,ITEM_CLASS)
) 
---------------164 体外循环新建表脚本--------------------
CREATE TABLE  MED_CPB_EXAM_INFO(
	 PATIENT_ID  NVARCHAR(20) NOT NULL,
	 VISIT_ID  NUMERIC(2, 0) NOT NULL,
	 OPER_ID  NUMERIC(2, 0) NOT NULL,
	 E1  NVARCHAR(20) NULL,
	 E2  NVARCHAR(20) NULL,
	 E3  NVARCHAR(20) NULL,
	 E4  NVARCHAR(20) NULL,
	 E5  NVARCHAR(20) NULL,
	 E6  NVARCHAR(20) NULL,
	 E7  NVARCHAR(20) NULL,
	 E8  NVARCHAR(20) NULL,
	 E9  NVARCHAR(20) NULL,
	 E10  NVARCHAR(20) NULL,
	 E11  NVARCHAR(20) NULL,
	 E12  NVARCHAR(20) NULL,
	 E13  NVARCHAR(20) NULL,
	 E14  NVARCHAR(20) NULL,
	 E15  NVARCHAR(20) NULL,
	 E16  NVARCHAR(20) NULL,
	 E17  NVARCHAR(20) NULL,
	 E18  NVARCHAR(20) NULL,
	 E19  NVARCHAR(20) NULL,
	 E20  NVARCHAR(20) NULL,
	 E21  NVARCHAR(20) NULL,
	 E22  NVARCHAR(20) NULL,
	 E23  NVARCHAR(20) NULL,
	 E24  NVARCHAR(20) NULL,
	 E25  NVARCHAR(20) NULL,
	 E26  NVARCHAR(20) NULL,
	 E27  NVARCHAR(20) NULL,
	 E28  NVARCHAR(20) NULL,
	 E29  NVARCHAR(20) NULL,
	 E30  NVARCHAR(20) NULL,
 CONSTRAINT  PK_MED_CPB_EXAM_INFO PRIMARY KEY(PATIENT_ID,VISIT_ID,OPER_ID)
)
---------------165 体外循环新建表脚本--------------------
CREATE TABLE  MED_CPB_SUMMARY(
	 PATIENT_ID  NVARCHAR(20) NOT NULL,
	 VISIT_ID  NUMERIC(2, 0) NOT NULL,
	 OPER_ID  NUMERIC(2, 0) NOT NULL,
	 PUMP_TIME  NVARCHAR(30) NULL,
	 CLAMPED_TIME  NVARCHAR(30) NULL,
	 ASSISTANT_TIME  NVARCHAR(30) NULL,
	 AVG_FLOW  NVARCHAR(10) NULL,
	 AVG_PUMP_PRESSURE  NVARCHAR(10) NULL,
	 AVG_PERFUSION_PRESSURE  NVARCHAR(10) NULL,
	 MAP  NVARCHAR(10) NULL,
	 PRIMING_VOLUME  NVARCHAR(10) NULL,
	 ADDING_VOLUME  NVARCHAR(10) NULL,
	 TOTAL_PERFUSION_VOLUME  NVARCHAR(10) NULL,
	 K_VOLUME  NVARCHAR(10) NULL,
	 FILTRATE_VOLUME  NVARCHAR(10) NULL,
	 URINARY_VOLUME  NVARCHAR(10) NULL,
	 MACHINE_BLOOD  NVARCHAR(10) NULL,
	 MACHINE_BLOOD_LAST  NVARCHAR(10) NULL,
	 EYES_STATUS  NVARCHAR(10) NULL,
	 MEMO  NVARCHAR(500) NULL,
	 CONSTRAINT  PK_MED_CPB_SUMMARY PRIMARY KEY(PATIENT_ID,VISIT_ID,OPER_ID)
);
---------------166 体外循环新建表脚本--------------------
CREATE TABLE  MED_CPB_INPUT_DICT(
	 SERIAL_NO  NUMERIC(4, 0) NULL,
	 ITEM_CLASS  NVARCHAR(40) NOT NULL,
	 ITEM_NAME  NVARCHAR(100) NOT NULL,
	 ITEM_CODE  NVARCHAR(100) NULL,
	 INPUT_CODE  NVARCHAR(20) NULL,
 CONSTRAINT  PK_MED_CPB_INPUT_DICT PRIMARY KEY(ITEM_CLASS,ITEM_NAME)
)
---------------167 体外循环新建表脚本--------------------
CREATE TABLE  MED_CPB_MASTER(
	 PATIENT_ID  NVARCHAR(20) NOT NULL,
	 VISIT_ID  NUMERIC(2, 0) NOT NULL,
	 OPER_ID  NUMERIC(2, 0) NOT NULL,
	 BLOOD_TYPE  NVARCHAR(20) NULL,
	 BSA NUMERIC(6, 5) NULL,
	 CPB_METHOD  NVARCHAR(200) NULL,
	 MP_METHOD  NVARCHAR(200) NULL,
	 PERFUSION_METHOD NVARCHAR(200) NULL,
	 REBEAT_MOTHOD  NVARCHAR(80) NULL,
	 OXYGENATOR_TYPE  NVARCHAR(50) NULL,
	 CPB_DOCTOR_FIRST  NVARCHAR(20) NULL,
	 CPB_DOCTOR_SECOND  NVARCHAR(20) NULL,
	 CPB_DOCTOR_THIRD  NVARCHAR(20) NULL,
	 CPB_NURSE_FIRST  NVARCHAR(20) NULL,
	 CPB_NURSE_SECOND  NVARCHAR(20) NULL,
	 CPB_NURSE_THIRD  NVARCHAR(20) NULL,
	 BYPASS_BEGIN_TIME  DATETIME NULL,
	 BYPASS_END_TIME  DATETIME NULL,
	 CLAMPING_TIME  DATETIME NULL,
	 OFF_CLAMPING_TIME  DATETIME NULL,
	 ARTERIAL_INTUBATTON  NVARCHAR(50) NULL,
	 VENOUS_INTUBATTON  NVARCHAR(50) NULL,
	 CARDIAC_PRESERVATION_FLUID  NVARCHAR(300) NULL,
	 MEMO  NVARCHAR(500) NULL,
 CONSTRAINT  PK_MED_CPB_MASTER PRIMARY KEY(PATIENT_ID,VISIT_ID,OPER_ID)
)
---------------168 体外循环新建表脚本--------------------
CREATE TABLE  MED_CPB_METHOD_DICT(
	 SERIAL_NO  NUMERIC(2, 0) NULL,
	 CPB_CODE  NVARCHAR(20) NULL,
	 CPB_NAME  NVARCHAR(100) NOT NULL,
	 INPUT_CODE  NVARCHAR(10) NULL,
	 CPB_TYPE  NVARCHAR(40) NULL,
CONSTRAINT PK_MED_CPB_METHOD_DICT PRIMARY KEY(CPB_NAME)
)
---------------169 体外循环新建表脚本--------------------
CREATE TABLE  MED_CPB_PRE_CHECK_RECORD(
	 PATIENT_ID  NVARCHAR(20) NOT NULL,
	 VISIT_ID  NUMERIC(2, 0) NOT NULL,
	 OPER_ID  NUMERIC(2, 0) NOT NULL,
	 CHK01  NVARCHAR(20) NULL,
	 CHK02  NVARCHAR(20) NULL,
	 CHK03  NVARCHAR(20) NULL,
	 CHK04  NVARCHAR(20) NULL,
	 CHK05  NVARCHAR(20) NULL,
	 CHK06  NVARCHAR(20) NULL,
	 CHK07  NVARCHAR(20) NULL,
	 CHK08  NVARCHAR(20) NULL,
	 CHK09  NVARCHAR(20) NULL,
	 CHK10  NVARCHAR(20) NULL,
	 CHK11  NVARCHAR(20) NULL,
	 CHK12  NVARCHAR(20) NULL,
	 CHK13  NVARCHAR(20) NULL,
	 CHK14  NVARCHAR(20) NULL,
	 CHK15  NVARCHAR(20) NULL,
	 CHK16  NVARCHAR(20) NULL,
	 CHK17  NVARCHAR(20) NULL,
	 CHK18  NVARCHAR(20) NULL,
	 CHK19  NVARCHAR(20) NULL,
	 CHK20  NVARCHAR(20) NULL,
	 CHK21  NVARCHAR(20) NULL,
	 CHK22  NVARCHAR(20) NULL,
	 CHK23  NVARCHAR(20) NULL,
	 CHK24  NVARCHAR(20) NULL,
	 CHK25  NVARCHAR(20) NULL,
	 CHK26  NVARCHAR(20) NULL,
	 CHK27  NVARCHAR(20) NULL,
	 CHK28  NVARCHAR(20) NULL,
	 CHK29  NVARCHAR(20) NULL,
	 CHK30  NVARCHAR(20) NULL,
	 CHK31  NVARCHAR(20) NULL,
	 CHK32  NVARCHAR(20) NULL,
	 CHK33  NVARCHAR(20) NULL,
	 CHK34  NVARCHAR(20) NULL,
	 CHK35  NVARCHAR(20) NULL,
	 CHK36  NVARCHAR(20) NULL,
 CONSTRAINT  PK_MED_CPB_PRE_CHECK_RECORD PRIMARY KEY(PATIENT_ID,VISIT_ID,OPER_ID)
)  
---------------170 体外循环新建表脚本--------------------
CREATE TABLE  MED_CPB_PRIMING_DATA(
	 PATIENT_ID  NVARCHAR(20) NOT NULL,
	 VISIT_ID  NUMERIC(2, 0) NOT NULL,
	 OPER_ID  NUMERIC(2, 0) NOT NULL,
	 P1  NVARCHAR(20) NULL,
	 P2  NVARCHAR(20) NULL,
	 P3  NVARCHAR(20) NULL,
	 P4  NVARCHAR(20) NULL,
	 P5  NVARCHAR(20) NULL,
	 P6  NVARCHAR(20) NULL,
	 P7  NVARCHAR(20) NULL,
	 P8  NVARCHAR(20) NULL,
	 P9  NVARCHAR(20) NULL,
	 P10  NVARCHAR(20) NULL,
	 P11  NVARCHAR(20) NULL,
	 P12  NVARCHAR(20) NULL,
	 P13  NVARCHAR(20) NULL,
	 P14  NVARCHAR(20) NULL,
	 P15  NVARCHAR(20) NULL,
	 P16  NVARCHAR(20) NULL,
 CONSTRAINT  PK_MED_CPB_PRIMING_DATA PRIMARY KEY(PATIENT_ID,VISIT_ID,OPER_ID)
)
---------------171 增量脚本--------------------
CREATE TABLE MED_PATIENT_DRUG_ITEM(
  PATIENT_ID NVARCHAR(20) NOT NULL,
  VISIT_ID numeric(2, 0) NOT NULL,
  OPER_ID numeric(2, 0) NOT NULL,
  SERIAL_NO numeric(4, 0) NOT NULL,
  ITEM_NAME1 NVARCHAR(20) NULL,
  ITEM_UNIT1 NVARCHAR(20) NULL,
  ITEM_NAME2 NVARCHAR(20) NULL,
  ITEM_UNIT2 NVARCHAR(20) NULL,
 CONSTRAINT PK_MED_PATIENT_DRUG_ITEM PRIMARY KEY  
(
  PATIENT_ID ,
  VISIT_ID ,
  OPER_ID ,
  SERIAL_NO 
) 
)
---------------172 增量脚本 增加文书模板表区别模板所属程序字段--------------------
alter table MED_DOCUMENT_TEMPLET add EVENT_NO NUMERIC(3) NOT NULL; 
---------------172 增量脚本-麻醉事件字典常用量-------------------
alter table MED_ANESTHESIA_EVENT_OPEN add STANDARD_DOSAGE1     NUMERIC(8,4)         null;
alter table MED_ANESTHESIA_EVENT_OPEN add STANDARD_DOSAGE2     NUMERIC(8,4)         null;
alter table MED_ANESTHESIA_EVENT_OPEN add STANDARD_DOSAGE3     NUMERIC(8,4)         null;
alter table MED_ANESTHESIA_EVENT_OPEN add STANDARD_DOSAGE4     NUMERIC(8,4)         null;
alter table MED_ANESTHESIA_EVENT_OPEN add STANDARD_DOSAGE5     NUMERIC(8,4)         null;
alter table MED_ANESTHESIA_EVENT_OPEN add STANDARD_DOSAGE6     NUMERIC(8,4)         null;
alter table MED_ANESTHESIA_EVENT_OPEN add STANDARD_DOSAGE7     NUMERIC(8,4)         null;
alter table MED_ANESTHESIA_EVENT_OPEN add STANDARD_DOSAGE8     NUMERIC(8,4)         null;
alter table MED_ANESTHESIA_EVENT_OPEN add STANDARD_DOSAGE9     NUMERIC(8,4)         null;
alter table MED_ANESTHESIA_EVENT_OPEN add STANDARD_DOSAGE10     NUMERIC(8,4)         null;
alter table MED_ANESTHESIA_EVENT_OPEN add STANDARD_DOSAGE11     NUMERIC(8,4)         null;
alter table MED_ANESTHESIA_EVENT_OPEN add STANDARD_DOSAGE12     NUMERIC(8,4)         null;
alter table MED_ANESTHESIA_EVENT_OPEN add STANDARD_DOSAGE13     NUMERIC(8,4)         null;
alter table MED_ANESTHESIA_EVENT_OPEN add STANDARD_DOSAGE14     NUMERIC(8,4)         null;
alter table MED_ANESTHESIA_EVENT_OPEN add STANDARD_DOSAGE15     NUMERIC(8,4)         null;
---------------173 增量脚本-PACU交班医嘱表, 苏大文书中使用-------------------
create table MED_PACU_HANDOVER_ORDERS
(
  PATIENT_ID         NVARCHAR(20) not null,
  VISIT_ID           NUMERIC(2) not null,
  OPER_ID            NUMERIC(2) not null,
  ITEM_NO           NUMERIC(2) not null,
  ORDER_TIME            DATETIME ,
  PACU_ORDER            NVARCHAR(200) ,
  DOCTOR_NAME            NVARCHAR(20) ,
  EXEC_TIME              DATETIME ,
  EXEC_NAME              NVARCHAR(20),
  constraint PK_MED_PACU_HANDOVER_ORDERS primary key (PATIENT_ID, VISIT_ID, OPER_ID, ITEM_NO)
)
---------------174 增量脚本-PACU交班医嘱表, 苏大文书中使用-------------------
create table MED_PACU_HANDOVER_PUTPIPE
(
  PATIENT_ID         NVARCHAR(20) not null,
  VISIT_ID           NUMERIC(2) not null,
  OPER_ID            NUMERIC(2) not null,
  ITEM_NO           NUMERIC(2) not null,
  PIPE_STATUS            NVARCHAR(20) ,
  PIPE1            NVARCHAR(20) ,
  PIPE2            NVARCHAR(20) ,
  PIPE3            NVARCHAR(20) ,
  PIPE4            NVARCHAR(20) ,
  PIPE5            NVARCHAR(20) ,
  PIPE6            NVARCHAR(20) ,
  PIPE7            NVARCHAR(20) ,
  PIPE8            NVARCHAR(20) ,
  PIPE9            NVARCHAR(20) ,
  PIPE10            NVARCHAR(20),
  constraint PK_MED_PACU_HANDOVER_PUTPIPE primary key (PATIENT_ID, VISIT_ID, OPER_ID, ITEM_NO)
)
---------------175 增量脚本-------------------
create table MED_PACU_SORCE
(
  ORDER_ID		NUMERIC(10),
  CRITERION     NVARCHAR(10) not null,
  ZERO          NVARCHAR(50),
  ONE           NVARCHAR(50),
  TWO           NVARCHAR(50),
  EVENTHAPPEN   NVARCHAR(10),
  TIME          DATETIME ,
  MYODYNAMIA    NUMERIC(5),
  BREATH        NUMERIC(5),
  CYCLE         NUMERIC(5),
  SPO2          NUMERIC(5),
  CONSCIOUSNESS NUMERIC(5),
  TOTAL         NUMERIC(5),
  SIGNATURE     NVARCHAR(10),
  PATIENT_ID    NVARCHAR(20) not null,
  VISIT_ID      NUMERIC(2) not null,
  OPER_ID       NUMERIC(2) not null,
  constraint PK_PACUSORCE primary key (PATIENT_ID, VISIT_ID, OPER_ID, CRITERION)
)
---------------176 增量脚本-------------------
create table MED_ANES_OPERHANDOVER
(
  PATIENT_ID             NVARCHAR(20) not null,
  VISIT_ID               NUMERIC(2) not null,
  OPER_ID                NUMERIC(2) not null,
  FIRST_ANES_DOCTOR      NVARCHAR(8),
  SECOND_ANES_DOCTOR     NVARCHAR(8),
  THIRD_ANES_DOCTOR      NVARCHAR(8),
  FIRST_OPERATION_NURSE  NVARCHAR(8),
  SECOND_OPERATION_NURSE NVARCHAR(8),
  THIRD_OPERATION_NURSE  NVARCHAR(8),
  OTHER                  NVARCHAR(8),
  HANDOVER_DATE_TIME     DATETIME,
  HANDOVER_DATE_TIME2     DATETIME,
  MEMO                   NVARCHAR(100),
  constraint PK_MED_ANES_OPERHANDOVER primary key (PATIENT_ID, VISIT_ID, OPER_ID)
)
---------------177 增量脚本穿刺记录表-------------------
create table MED_PUNCTURE_RECORD
(
  PATIENT_ID          NVARCHAR(20) not null,
  VISIT_ID            NUMERIC(2) not null,
  OPER_ID             NUMERIC(2) not null,
  RECORD_TIME         DATETIME,
  A_PUNCTURE_PERSON   NVARCHAR(20),
  A_PUNCTURE_NEEDLE   NVARCHAR(20),
  A_PUNCTURE_POSITION NVARCHAR(20),
  A_COMPLICATIONS1    NUMERIC(1),
  A_COMPLICATIONS2    NUMERIC(1),
  A_COMPLICATIONS3    NUMERIC(1),
  V_PUNCTURE_PERSON   NVARCHAR(20),
  V_PUNCTURE_NEEDLE   NVARCHAR(20),
  V_PUNCTURE_POSITION NVARCHAR(20),
  V_COMPLICATIONS1    NUMERIC(1),
  V_COMPLICATIONS2    NUMERIC(1),
  V_COMPLICATIONS3    NUMERIC(1),
  V_COMPLICATIONS4    NUMERIC(1),
  V_COMPLICATIONS5    NUMERIC(1),
  PUNCTURE_NURSE      NVARCHAR(20),
  MEMO                NVARCHAR(80),
  constraint PK_MED_PUNCTURE_RECORD primary key (PATIENT_ID, VISIT_ID, OPER_ID)
)
---------------178 增量脚本 交班记录表-------------------
create table MED_OPER_SHIFT_RECORD
(
  PATIENT_ID      NVARCHAR(20) not null,
  VISIT_ID        NUMERIC(2) not null,
  OPER_ID         NUMERIC(2) not null,
  SHIFT_NO        NUMERIC(2) not null,
  SHIFT_DATE_TIME DATETIME,
  SHIFTED_BY      NVARCHAR(8),
  SHIFT_PERSON    NVARCHAR(8),
  SHIFT_DUTY      NVARCHAR(8),
  MEMO            NVARCHAR(100),
  constraint PK_MED_OPER_SHIFT_RECORD primary key (PATIENT_ID, VISIT_ID, OPER_ID, SHIFT_NO)
)
---------------179 增量脚本 -------------------
create table MED_QIXIE_QINGDIAN
(
  PATIENT_ID                   NVARCHAR(20) not null,
  VISIT_ID                     NUMERIC(2) not null,
  OPER_ID                      NUMERIC(2) not null,
  X_POSITION         NUMERIC(10) not null,
  Y_POSITION              NUMERIC(10) not null,
  POSITION_VALUE        NVARCHAR(50),
  constraint PK_MED_QIXIE_QINGDIAN primary key (PATIENT_ID, VISIT_ID, OPER_ID, X_POSITION,Y_POSITION)
)
---------------180 增量脚本 -------------------
create table MED_GRID_TEMPLET_MASTER
(
  TEMPLET_GUID                   NVARCHAR(50) not null,
  GRID_TEMPLET_FLAG             NVARCHAR(50) not null,
  CREATE_BY          NVARCHAR(50) default '公用' not null,
  CLASS_NAME    NVARCHAR(50) not null,
  TEMPLET_NAME  NVARCHAR(50) not null,
  EVENT_NO  NUMERIC(3) default 0 not null,
  MEMO  NVARCHAR(100),
 constraint PK_MED_GRID_TEMPLET_MASTER primary key (TEMPLET_GUID)
)
---------------181 增量脚本 -------------------
create table MED_GRID_TEMPLET_DETAIL
(
  TEMPLET_GUID       NVARCHAR(50) not null,
  X_POSITION         NUMERIC(10) not null,
  Y_POSITION              NUMERIC(10) not null,
  POSITION_VALUE        NVARCHAR(50),
  POSITION_FLAG        NVARCHAR(50),
  constraint PK_MED_GRID_TEMPLET_DETAIL primary key (TEMPLET_GUID, X_POSITION,Y_POSITION)
)
---------------182 增量脚本 -------------------
create table MED_QIXIE_TEMPLET_MASTER
(
  TEMPLET_GUID                   NVARCHAR(50) not null,
  OPER_BAG_FLAG             NUMERIC(2) default 1 not null,
  CLASS_NAME    NVARCHAR(50) not null,
  TEMPLET_NAME  NVARCHAR(50) not null,
  MEMO  NVARCHAR(200),
  constraint PK_MED_QIXIE_TEMPLET_MASTER primary key (TEMPLET_GUID)
)
---------------183 增量脚本 -------------------
create table MED_QIXIE_TEMPLET_DETAIL
(
  SERIAL_NO     NUMERIC(4),
  TEMPLET_GUID       NVARCHAR(50) not null,
  ITEM_NAME  NVARCHAR(30) not null,
  ITEM_VALUE  NVARCHAR(10),
  constraint PK_MED_QIXIE_TEMPLET_DETAIL primary key (TEMPLET_GUID, ITEM_NAME)
)





	

 

