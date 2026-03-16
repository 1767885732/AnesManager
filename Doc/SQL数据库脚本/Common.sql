------------1.血气分析数据明细---------------
create table MED_BLOOD_GAS_DETAIL
(
  DETAIL_ID NVARCHAR(30) not null,
  BLG_CODE  NVARCHAR(60) not null,
  BLG_VALUE NVARCHAR(20),
  OPERATOR  NVARCHAR(20),
  OP_DATE   DATETIME,
  ABNORMAL_INDICATOR NVARCHAR(2),
  constraint BLG_DETAIL_PKEY primary key (DETAIL_ID, BLG_CODE)
)
----------2.血气分析字段表-------------------
create table MED_BLOOD_GAS_DICT
(
  BLG_CODE        NVARCHAR(20) not null,
  BLG_NAME        NVARCHAR(60) not null,
  BLG_SHOWID      NUMERIC not null,
  BLG_UNIT        NVARCHAR(20),
  BLG_REFER_VALUE NVARCHAR(40),
  BLG_STATUS      NVARCHAR(2) not null,
  BLG_INPUT_CODE  NVARCHAR(20),
  BLG_ATTR_CODE   NVARCHAR(100),
  BLG_ITEM_ID     NUMERIC(4),
  constraint BLD_PRIMARY_KEY primary key (BLG_CODE, BLG_SHOWID, BLG_STATUS)
)
---------------3.  -------------------
create table MED_BLOOD_GAS_MASTER
(
  PATIENT_ID  		NVARCHAR(20) not null,
  VISIT_ID    		NUMERIC(2) not null,
  RECORD_DATE 		DATETIME not null,
  NURSE_MEMO1 		NVARCHAR(600),
  NURSE_MEMO2 		NVARCHAR(600),
  DETAIL_ID   		NVARCHAR(30) not null,
  OPERATOR    		NVARCHAR(20),
  OP_DATE     		DATETIME,
  SPECIMEN    NVARCHAR(100),
  EQUIPMENT   NVARCHAR(100),
  OPER_ID     NUMERIC(2),
  constraint BLOD_PRIMARY_KEY primary key (DETAIL_ID)

)
-------------4--------------------------
create table MED_ADADMINSTER_MODE_DICT
(
  ADADMINSTER_NO        NUMERIC(2) not null,
  ADADMINSTER_MODE_CODE NVARCHAR(1) not null,
  ADADMINSTER_MODE_NAME NVARCHAR(8),
  INPUT_CODE            NVARCHAR(8),
  constraint PK_MED_ADADMINSTER_MODE_DICT primary key (ADADMINSTER_NO, ADADMINSTER_MODE_CODE)
)
-----------------5----------------------
create table MED_ADMINISTRATION_DICT
(
  SERIAL_NO           NUMERIC(3),
  ADMINISTRATION_CODE NVARCHAR(3),
  ADMINISTRATION_NAME NVARCHAR(30) not null,
  ADMINISTRATION_ABBR NVARCHAR(8),
  INPUT_CODE          NVARCHAR(16),
  constraint PK_MED_ADMINISTRATION_DICT primary key (ADMINISTRATION_NAME)
)
------------------6----------------
create table MED_ADMINISTRATION_STAT_DICT
(
  SERIAL_NO      NUMERIC(2),
  ITEM_NAME      NVARCHAR(8) not null,
  ADMINISTRATION NVARCHAR(30) not null,
  constraint PK_ADMINISTRATION_STAT_DICT primary key (ITEM_NAME, ADMINISTRATION)
)
---------------------7--------------------
create table MED_ADT_LOG
(
  WARD_CODE     NVARCHAR(16) not null,
  DEPT_CODE     NVARCHAR(16),
  LOG_DATE_TIME DATETIME not null,
  PATIENT_ID    NVARCHAR(20) not null,
  VISIT_ID      NUMERIC(2) not null,
  [ACTION]       NVARCHAR(1) not null,
  constraint PK_MED_ADT_LOG primary key (WARD_CODE, PATIENT_ID, VISIT_ID, LOG_DATE_TIME, ACTION)
)
---------------------8--------------------------
create table MED_ANAESTHESIA_DICT
(
  SERIAL_NO        NUMERIC(2),
  ANAESTHESIA_CODE NVARCHAR(1),
  ANAESTHESIA_NAME NVARCHAR(40) not null,
  INPUT_CODE       NVARCHAR(8),
  ANAESTHESIA_TYPE NVARCHAR(16),
  constraint PK_MED_ANAESTHESIA_DICT primary key (ANAESTHESIA_NAME)
)
------------------------9-----------------------
create table MED_ANESTHETIC_CLASS_DICT
(
  SERIAL_NO  NUMERIC(2),
  CLASS_NAME NVARCHAR(20) not null,
  INPUT_CODE NVARCHAR(8),
  constraint PK_MED_ANESTHETIC_CLASS_DICT primary key (CLASS_NAME)
)
-------------------10-----------------------
create table MED_APPLICATIONS
(
  APP_ID      NVARCHAR(36) not null,
  [NAME]        NVARCHAR(60) not null,
  DESCRIPTION NVARCHAR(160),
  constraint KEY_MED_APPLICATIONS primary key (APP_ID)
)
-----------------11--------------------------
create table MED_NURSING_CLASS_DICT
(
  SERIAL_NO          NUMERIC(1),
  NURSING_CLASS_CODE NVARCHAR(1) not null,
  NURSING_CLASS_NAME NVARCHAR(8),
  INPUT_CODE         NVARCHAR(8),
  constraint PK_MED_NURSING_CLASS_DICT primary key (NURSING_CLASS_CODE)
)
-------------------12--------------------------
create table MED_OCCUPATION_DICT
(
  SERIAL_NO       NUMERIC(2),
  OCCUPATION_CODE NVARCHAR(1) not null,
  OCCUPATION_NAME NVARCHAR(20),
  INPUT_CODE      NVARCHAR(8),
  constraint PK_MED_OCCUPATION_DICT primary key (OCCUPATION_CODE)
)
-------------------13-----------------------------
create table MED_PATIENT_STATUS_DICT
(
  SERIAL_NO           NUMERIC(1),
  PATIENT_STATUS_CODE NVARCHAR(1) not null,
  PATIENT_STATUS_NAME NVARCHAR(4),
  INPUT_CODE          NVARCHAR(8),
  constraint PK_MED_PATIENT_STATUS_DICT primary key (PATIENT_STATUS_CODE)
)
-----------------14----------------------------------
create table MED_AREA_DICT
(
  SERIAL_NO  NUMERIC(4),
  AREA_CODE  NVARCHAR(6) not null,
  AREA_NAME  NVARCHAR(34),
  INPUT_CODE NVARCHAR(8),
  ZIP_CODE   NVARCHAR(6),
  constraint PK_MED_AREA_DICT primary key (AREA_CODE)
)
---------------15---------------------------------------
create table MED_BED_REC
(
  WARD_CODE         NVARCHAR(16) not null,
  BED_NO            NVARCHAR(20) not null,
  BED_LABEL         NVARCHAR(20),
  ROOM_NO           NVARCHAR(20),
  DEPT_CODE         NVARCHAR(16),
  BED_APPROVED_TYPE NVARCHAR(1),
  BED_SEX_TYPE      NVARCHAR(1),
  BED_CLASS         NVARCHAR(2),
  BED_STATUS        NVARCHAR(1),
  ICU_INDICATOR     NUMERIC(1),
  MONITOR_LABEL     NVARCHAR(20),
  SERIAL_NO         NUMERIC(3),
  constraint PK_MED_BED_REC primary key (WARD_CODE, BED_NO)
)
-----------------16-----------------------------------
create table MED_BILL_ITEM_CLASS_DICT
(
  SERIAL_NO  NUMERIC(2),
  CLASS_CODE NVARCHAR(16) not null,
  CLASS_NAME NVARCHAR(60),
  INPUT_CODE NVARCHAR(8),
  constraint PK_MED_BILL_ITEM_CLASS_DICT primary key (CLASS_CODE)
)
-----------------17-------------------------------------
create table MED_BILL_ITEM_CLASS_VS_HIS
(
  CLASS_CODE  NVARCHAR(16) not null,
  CODE_IN_HIS NVARCHAR(32) not null,
  constraint PK_MED_BILL_ITEM_CLASS_VS_HIS primary key (CLASS_CODE, CODE_IN_HIS)
)
-----------------18---------------------------------------
create table MED_CHARGE_PRICE_SCHEDULE
(
  CHARGE_TYPE              NVARCHAR(8) not null,
  PRICE_COEFF_NUMERATOR    NUMERIC(3),
  PRICE_COEFF_DENOMINATOR  NUMERIC(3),
  CHARGE_SPECIAL_INDICATOR NUMERIC(1),
  constraint PK_MED_CHARGE_PRICE_SCHEDULE primary key (CHARGE_TYPE)
)
---------------19--------------------------------------------
create table MED_CHARGE_TYPE_DICT
(
  SERIAL_NO              NUMERIC(3),
  CHARGE_TYPE_CODE       NVARCHAR(2),
  CHARGE_TYPE_NAME       NVARCHAR(30) not null,
  CHARGE_PRICE_INDICATOR NUMERIC(1),
  INPUT_CODE             NVARCHAR(16),
  constraint PK_MED_CHARGE_TYPE_DICT primary key (CHARGE_TYPE_NAME)
)
----------------20-------------------------------
create table MED_CLINIC_ITEM_NAME_DICT
(
  ITEM_CLASS    NVARCHAR(16) not null,
  ITEM_NAME     NVARCHAR(60) not null,
  ITEM_CODE     NVARCHAR(10),
  STD_INDICATOR NUMERIC(1),
  INPUT_CODE    NVARCHAR(8),
  INPUT_CODE_WB NVARCHAR(8),
  EXPAND1       NVARCHAR(8),
  EXPAND2       NVARCHAR(8),
  EXPAND3       NVARCHAR(8),
  EXPAND4       NVARCHAR(8),
  EXPAND5       NVARCHAR(8),
  constraint PK_MED_CLINIC_ITEM_NAME_DICT primary key (ITEM_CLASS, ITEM_NAME)
)
------------------21-------------------------
create table MED_CLINIC_VS_CHARGE
(
  CLINIC_ITEM_CLASS NVARCHAR(1) not null,
  CLINIC_ITEM_CODE  NVARCHAR(10) not null,
  CHARGE_ITEM_NO    NUMERIC(2) not null,
  CHARGE_ITEM_CLASS NVARCHAR(16),
  CHARGE_ITEM_CODE  NVARCHAR(10),
  CHARGE_ITEM_SPEC  NVARCHAR(20),
  AMOUNT            NUMERIC(4),
  UNITS             NVARCHAR(12),
  constraint PK_MED_CLINIC_VS_CHARGE primary key (CLINIC_ITEM_CLASS, CLINIC_ITEM_CODE, CHARGE_ITEM_NO)
)
-----------------------22---------------------
create table MED_DEPT_DICT
(
  SERIAL_NO  NUMERIC(3),
  DEPT_CODE  NVARCHAR(16) not null,
  DEPT_NAME  NVARCHAR(40),
  INPUT_CODE NVARCHAR(8),
  constraint PK_MED_DEPT_DICT primary key (DEPT_CODE)
)
---------------------23--------------------------
create table MED_DEPT_EQUIP_DICT
(
  WARD_CODE NVARCHAR(8) not null,
  ITEM_NAME NVARCHAR(10) not null,
  MEMO      NVARCHAR(40),
  constraint PK_DEPT_EQUIP_DICT primary key (WARD_CODE, ITEM_NAME)
)
---------------------24------------------------
create table MED_DEPT_VS_WARD
(
  DEPT_CODE NVARCHAR(8) not null,
  WARD_CODE NVARCHAR(8),
  constraint PK_MED_DEPT_VS_WARD primary key (DEPT_CODE)
)
---------------------25---------------------------
create table MED_DIAGNOSIS_DICT
(
  DIAGNOSIS_CODE     NVARCHAR(16) not null,
  DIAGNOSIS_NAME     NVARCHAR(40),
  STD_INDICATOR      NUMERIC(1),
  APPROVED_INDICATOR NUMERIC(1),
  CREATE_DATE        DATETIME,
  INPUT_CODE         NVARCHAR(8),
  INFECT_INDICATOR   NVARCHAR(1),
  HEALTH_LEVEL       NVARCHAR(2),
  INPUT_CODE_WB      NVARCHAR(8),
  DISEASE_SORT       NVARCHAR(4),
  DIAG_INDICATOR     NUMERIC(1),
  constraint PK_DIAGNOSIS_DICT primary key (DIAGNOSIS_CODE)
)
---------------------26--------------------------------
create table MED_DOSAGE_UNITS_DICT
(
  SERIAL_NO        NUMERIC(3),
  DOSAGE_UNITS     NVARCHAR(8) not null,
  BASE_UNITS       NVARCHAR(8),
  CONVERSION_RATIO NUMERIC(12,6),
  INPUT_CODE       NVARCHAR(8),
  constraint PK_MED_DOSAGE_UNITS_DICT primary key (DOSAGE_UNITS)
)
------------------------27-----------------------------------
create table MED_DRUG_CLASS_DICT
(
  SERIAL_NO  NUMERIC(2),
  CLASS_NAME NVARCHAR(10) not null,
  INPUT_CODE NVARCHAR(8),
  constraint PK_MED_DRUG_CLASS_DICT primary key (CLASS_NAME)
)
----------------------------28---------------------------------
create table MED_DRUG_DICT
(
  DRUG_CODE        NVARCHAR(16) not null,
  DRUG_NAME        NVARCHAR(60) not null,
  DRUG_SPEC        NVARCHAR(20) not null,
  UNITS            NVARCHAR(8),
  DRUG_FORM        NVARCHAR(20),
  SUPPLIER_NAME    NVARCHAR(60),
  DOSE_PER_UNIT    NUMERIC(8,3),
  DOSE_UNITS       NVARCHAR(8),
  DRUG_CLASS       NVARCHAR(10),
  ANESTHETIC_CLASS NVARCHAR(20),
  CODE_IN_HIS      NVARCHAR(16),
  INPUT_CODE       NVARCHAR(8),
  constraint PK_MED_DRUG_DICT primary key (DRUG_CODE, DRUG_SPEC)
)
---------------------------29----------------------------------
create table MED_DRUG_FORM_DICT
(
  SERIAL_NO  NUMERIC(2),
  FORM_NAME  NVARCHAR(20) not null,
  INPUT_CODE NVARCHAR(8),
  constraint PK_MED_DRUG_FORM_DICT primary key (FORM_NAME)
)
------------------------------30---------------------------------
create table MED_DRUG_NAME_DICT
(
  DRUG_CODE     NVARCHAR(16) not null,
  DRUG_NAME     NVARCHAR(60) not null,
  STD_INDICATOR NUMERIC(1),
  INPUT_CODE    NVARCHAR(8),
  constraint PK_MED_DRUG_NAME_DICT primary key (DRUG_CODE, DRUG_NAME)
)
------------------------------31----------------------------
create table MED_DRUG_RETURN_CLASS_DICT
(
  SERIAL_NO    NUMERIC(2),
  RETURN_CLASS NVARCHAR(8) not null,
  constraint PK_MED_DRUG_RETURN_CLASS_DICT primary key (RETURN_CLASS)
)
------------------------------32------------------------------
create table MED_EXAM_ITEMS
(
  EXAM_NO        NVARCHAR(20) not null,
  EXAM_ITEM_NO   NUMERIC(2) not null,
  EXAM_ITEM      NVARCHAR(80),
  EXAM_ITEM_CODE NVARCHAR(10),
  COSTS          NUMERIC(8,2),
  constraint PK_EXAM_ITEMS primary key (EXAM_NO, EXAM_ITEM_NO)
)
-----------------------------33---------------------------------
create table MED_EXAM_MASTER
(
  EXAM_NO             NVARCHAR(20) not null,
  LOCAL_ID_CLASS      NVARCHAR(1),
  PATIENT_LOCAL_ID    NVARCHAR(20),
  PATIENT_ID          NVARCHAR(20),
  VISIT_ID            NUMERIC(2),
  [NAME]                NVARCHAR(30),
  SEX                 NVARCHAR(4),
  DATE_OF_BIRTH       DATETIME,
  EXAM_CLASS          NVARCHAR(6),
  EXAM_SUB_CLASS      NVARCHAR(8),
  SPM_RECVED_DATE     DATETIME,
  CLIN_SYMP           NVARCHAR(400),
  PHYS_SIGN           NVARCHAR(400),
  RELEVANT_LAB_TEST   NVARCHAR(200),
  RELEVANT_DIAG       NVARCHAR(400),
  CLIN_DIAG           NVARCHAR(80),
  EXAM_MODE           NVARCHAR(1),
  EXAM_GROUP          NVARCHAR(16),
  DEVICE              NVARCHAR(20),
  PERFORMED_BY        NVARCHAR(16),
  PATIENT_SOURCE      NVARCHAR(1),
  FACILITY            NVARCHAR(20),
  REQ_DATE_TIME       DATETIME,
  REQ_DEPT            NVARCHAR(16),
  REQ_PHYSICIAN       NVARCHAR(30),
  REQ_MEMO            NVARCHAR(60),
  SCHEDULED_DATE_TIME DATETIME,
  NOTICE              NVARCHAR(400),
  EXAM_DATE_TIME      DATETIME,
  REPORT_DATE_TIME    DATETIME,
  TECHNICIAN          NVARCHAR(30),
  REPORTER            NVARCHAR(30),
  RESULT_STATUS       NVARCHAR(1),
  VERIFIED_BY         NVARCHAR(30),
  VERIFIED_DATE_TIME  DATETIME,
  constraint PK_MED_EXAM_MASTER primary key (EXAM_NO)
)
------------------------34----------------------------
create table MED_EXAM_REPORT
(
  EXAM_NO        NVARCHAR(20) not null,
  EXAM_PARA      NVARCHAR(1000),
  DESCRIPTION    NVARCHAR(2000),
  IMPRESSION     NVARCHAR(2000),
  RECOMMENDATION NVARCHAR(1000),
  IS_ABNORMAL    NVARCHAR(1),
  USE_IMAGE      NVARCHAR(15),
  STUDY_UID      NVARCHAR(128),
  MEMO           NVARCHAR(40),
  constraint PK_EXAM_REPORT primary key (EXAM_NO)
)
--------------------------35------------------------------
create table MED_HIS_USERS
(
  [USER_ID]     NVARCHAR(36) not null,
  [USER_NAME]   NVARCHAR(30) not null,
  USER_DEPT   NVARCHAR(16),
  INPUT_CODE  NVARCHAR(8),
  USER_JOB    NVARCHAR(20),
  RESERVED01  NVARCHAR(50),
  CREATE_DATE DATETIME,
  constraint PK_MED_HIS_USERS primary key ([USER_ID])
)
-----------------------36--------------------------------------
create table MED_HOSPITAL_CONFIG
(
  HOSPITAL_ID      NVARCHAR(40) not null,
  HOSPITAL_NAME    NVARCHAR(80),
  AUTHORIZED_KEY   NVARCHAR(20),
  UNIT_CODE        NVARCHAR(11),
  LOCATION         NVARCHAR(6),
  MAILING_ADDRESS  NVARCHAR(80),
  ZIP_CODE         NVARCHAR(6),
  APPROVED_BED_NUM NUMERIC(4),
  VERIFY_KEY       NVARCHAR(10),
  HOSPITAL_TYPE    NUMERIC(1),
  HOSPITAL_CLASS   NVARCHAR(16),
  constraint PK_MED_HOSPITAL_CONFIG primary key (HOSPITAL_ID)
)
---------------------37---------------------------------------------
create table MED_ICU_CONFIG
(
  CONFIG_ID          NVARCHAR(20) not null,
  AUDITING_CONDITION NVARCHAR(4000),
  DEPT               NVARCHAR(4000),
  ORDERS_IN_MOUNT    NVARCHAR(4000),
  SPECIAL_CARE       NVARCHAR(4000),
  constraint PK_MED_ICU_CONFIG primary key (CONFIG_ID)
)
---------------------38-------------------------------------------
create table MED_IDENTITY_DICT
(
  SERIAL_NO          NUMERIC(2),
  IDENTITY_CODE      NVARCHAR(1),
  IDENTITY_NAME      NVARCHAR(10) not null,
  INPUT_CODE         NVARCHAR(8),
  PRIORITY_INDICATOR NUMERIC(1),
  MILITARY_INDICATOR NUMERIC(1),
  CHARGE_TYPE        NVARCHAR(1),
  INPUT_CODE_WB      NVARCHAR(8),
  constraint PK_MED_IDENTITY_DICT primary key (IDENTITY_NAME)
)
-------------------39-----------------------------------------------
create table MED_IF_RUN_CONFIG_DICT
(
  APP_CLASS NVARCHAR(16) not null,
  SECTION   NVARCHAR(20) not null,
  MAIN_KEY  NVARCHAR(20) not null,
  KEY_VALUE NVARCHAR(100),
  MEMO      NVARCHAR(500),
  constraint PK_MED_IF_RUN_CONFIG_DICT primary key (APP_CLASS, SECTION, MAIN_KEY)
)
------------------------40-------------------------------------------
create table MED_IF_TRANS_DICT
(
  TRANS_NAME  NVARCHAR(20) not null,
  DBMS        NVARCHAR(40) not null,
  SERVER_NAME NVARCHAR(30),
  [DATABASE]    NVARCHAR(20),
  LOG_ID      NVARCHAR(20) not null,
  LOG_PASS    NVARCHAR(20) not null,
  NLS_LANG    NVARCHAR(40),
  DBPARM      NVARCHAR(80),
  MEMO        NVARCHAR(80),
  constraint PK_MED_IF_TRANS_DICT primary key (TRANS_NAME)
)
---------------------41--------------------------------------------
create table MED_JOB_CLASS_DICT
(
  SERIAL_NO      NUMERIC(2),
  JOB_CLASS_CODE NVARCHAR(2),
  JOB_CLASS_NAME NVARCHAR(8) not null,
  INPUT_CODE     NVARCHAR(8),
  constraint PK_MED_JOB_CLASS_DICT primary key (JOB_CLASS_NAME)
)
----------------------42--------------------------------------------
create table MED_LAB_REPORT_ITEM_DICT
(
  SERIAL_NO      NUMERIC(4),
  ITEM_CODE      NVARCHAR(10) not null,
  ITEM_NAME      NVARCHAR(40),
  RESULT_TYPE    NVARCHAR(8),
  LOWER_LIMIT    NUMERIC(9,3),
  UPPER_LIMIT    NUMERIC(9,3),
  UNITS          NVARCHAR(8),
  PRINT_CONTEXT  NVARCHAR(80),
  MINI_INCREMENT NUMERIC(6,3),
  NOTES          NVARCHAR(40),
  DEFAULT_VALUE  NVARCHAR(20),
  INPUT_CODE     NVARCHAR(8),
  constraint PK_MED_LAB_REPORT_ITEM_DICT primary key (ITEM_CODE)
)
--------------------------43------------------------------
create table MED_LAB_RESULT
(
  TEST_NO            NVARCHAR(20) not null,
  ITEM_NO            NUMERIC(10) not null,
  PRINT_ORDER        NUMERIC(4) not null,
  REPORT_ITEM_NAME   NVARCHAR(80),
  REPORT_ITEM_CODE   NVARCHAR(10),
  RESULT             NVARCHAR(80),
  UNITS              NVARCHAR(20),
  ABNORMAL_INDICATOR NVARCHAR(1),
  INSTRUMENT_ID      NVARCHAR(8),
  RESULT_DATE_TIME   DATETIME,
  REFERENCE_RESULT   NVARCHAR(200),
  constraint PK_MED_LAB_RESULT primary key (TEST_NO, ITEM_NO, PRINT_ORDER)
)
-------------------------------44------------------------------
create table MED_LAB_TEST_ITEMS
(
  TEST_NO   NVARCHAR(20) not null,
  ITEM_NO   NUMERIC(10) not null,
  ITEM_NAME NVARCHAR(80),
  ITEM_CODE NVARCHAR(10),
  constraint PK_MED_LAB_TEST_ITEMS primary key (TEST_NO, ITEM_NO)
)
------------------------------45------------------------------------
create table MED_LAB_TEST_MASTER
(
  TEST_NO                 NVARCHAR(20) not null,
  PRIORITY_INDICATOR      NUMERIC(1),
  PATIENT_ID              NVARCHAR(20),
  VISIT_ID                NUMERIC(2),
  WORKING_ID              NVARCHAR(20),
  EXECUTE_DATE            DATETIME,
  [NAME]                  NVARCHAR(30),
  NAME_PHONETIC           NVARCHAR(16),
  CHARGE_TYPE             NVARCHAR(30),
  SEX                     NVARCHAR(4),
  AGE                     NUMERIC(3),
  TEST_CAUSE              NVARCHAR(500),
  RELEVANT_CLINIC_DIAG    NVARCHAR(200),
  SPECIMEN                NVARCHAR(100),
  NOTES_FOR_SPCM          NVARCHAR(16),
  SPCM_RECEIVED_DATE_TIME DATETIME,
  SPCM_SAMPLE_DATE_TIME   DATETIME,
  REQUESTED_DATE_TIME     DATETIME,
  ORDERING_DEPT           NVARCHAR(16),
  ORDERING_PROVIDER       NVARCHAR(30),
  PERFORMED_BY            NVARCHAR(16),
  RESULT_STATUS           NVARCHAR(1),
  RESULTS_RPT_DATE_TIME   DATETIME,
  TRANSCRIPTIONIST        NVARCHAR(30),
  VERIFIED_BY             NVARCHAR(8),
  COSTS                   NUMERIC(8,2),
  CHARGES                 NUMERIC(8,2),
  BILLING_INDICATOR       NUMERIC(1),
  PRINT_INDICATOR         NUMERIC(1),
  SUBJECT                 NVARCHAR(40),
  BARCODE                 NVARCHAR(10),
  constraint PK_MED_LAB_TEST_MASTER primary key (TEST_NO)
)
---------------------------46-----------------------------
create table MED_MEASURES_DICT
(
  SERIAL_NO        NUMERIC(2),
  MEASURES_CLASS   NVARCHAR(10) not null,
  MEASURES_CODE    NVARCHAR(3),
  MEASURES_NAME    NVARCHAR(8) not null,
  BASE_UNITS       NVARCHAR(8),
  CONVERSION_RATIO NUMERIC(12,6),
  INPUT_CODE       NVARCHAR(8),
  constraint PK_MED_MEASURES_DICT primary key (MEASURES_CLASS, MEASURES_NAME)
)
-----------------------------47------------------------------
create table MED_MONITOR_DATA_VALUES_DICT
(
  MONITOR_DATA_NAME  NVARCHAR(40) not null,
  MONITOR_DATA_ALIAS NVARCHAR(8),
  MONITOR_DATA_VALUE NVARCHAR(40) not null,
  PRINT_VALUE        NVARCHAR(40),
  INPUT_CODE         NVARCHAR(8),
  CONTENT_ID         NVARCHAR(2),
  constraint PK_MED_MONITOR_VALUES_DICT primary key (MONITOR_DATA_NAME, MONITOR_DATA_VALUE)
)
-----------------------------48-------------------------------------
create table MED_MONITOR_DICT
(
  MONITOR_LABEL             NVARCHAR(20) not null,
  MANU_FIRM_NAME            NVARCHAR(40),
  MODEL                     NVARCHAR(40),
  INTERFACE_TYPE            NUMERIC(1),
  INTERFACE_DESC            NVARCHAR(20),
  IP_ADDR                   NVARCHAR(15),
  MAC_ADDR                  NVARCHAR(12),
  LAST_RECV_TIME            DATETIME,
  LAST_RECV_BED_ID          NVARCHAR(5),
  DUPLEX_FLAG               NUMERIC(5),
  AUTOIN_FLAG               NVARCHAR(1),
  COMM_PORT                 NVARCHAR(6),
  BAUD_RATE                 NUMERIC(5),
  BYTE_SIZE                 NUMERIC(5),
  PARITY                    NUMERIC(5),
  STOP_BITS                 NUMERIC(5),
  F_OUTX                    NUMERIC(5),
  F_INX                     NUMERIC(5),
  F_HARDWARE                NUMERIC(5),
  TX_QUEUESIZE              NUMERIC(5),
  RX_QUEUESIZE              NUMERIC(5),
  XON_LIM                   NUMERIC(5),
  XOFF_LIM                  NUMERIC(5),
  XON_CHAR                  NVARCHAR(1),
  XOFF_CHAR                 NVARCHAR(1),
  ERROR_CHAR                NVARCHAR(1),
  EVENT_CHAR                NVARCHAR(1),
  DRIVER_PROG               NVARCHAR(128),
  PRIORITY                  NUMERIC(5),
  ITEM_TYPE                 NVARCHAR(1),
  AUTO_LOAD                 NUMERIC(5),
  START_DATE_TIME           DATETIME,
  DEFAULT_RECV_FREQUENCY    NUMERIC(5),
  CURRENT_RECV_FREQUENCY    NUMERIC(5),
  CURRENT_RECVTIMES_UPLIMIT NUMERIC(5),
  CURRENT_RECV_ITEMS        NVARCHAR(200),
  WARD_CODE                 NVARCHAR(8),
  WARD_TYPE                 NUMERIC(2),
  BED_NO                    NVARCHAR(20),
  PATIENT_ID                NVARCHAR(20),
  VISIT_ID                  NUMERIC(2),
  OPER_ID                   NUMERIC(2),
  USING_INDICATOR           NUMERIC(1),
  FREQUENCY_DISPLAY         NUMERIC(5),
  MEMO                      NVARCHAR(100),
  DATALOG_START_TIME        DATETIME,
  PC_PORT                   NUMERIC(5),
  DATALOG_STATUS            NVARCHAR(4),
  IP_PORT                   NUMERIC(5),
  IN_PORT                   NUMERIC(5),
  OUT_PORT                  NUMERIC(5),
  constraint PK_MED_MONITOR_DICT primary key (MONITOR_LABEL)
)
--------------------------49-------------------------------------
create table MED_MONITOR_FUNCTION_CODE
(
  ITEM_ID         NUMERIC(5),
  ITEM_NAME       NVARCHAR(40),
  ITEM_CODE       NVARCHAR(6) not null,
  ITEM_UNIT       NVARCHAR(8),
  DIS_COLOR       NUMERIC(8),
  PARM_CLASS      NVARCHAR(1),
  DRAW_ICON       NVARCHAR(2),
  USE_FLAG        NVARCHAR(1),
  PRIORITY_INDI   NUMERIC(1),
  MEMO            NVARCHAR(24),
  INPUT_CODE      NVARCHAR(8),
  NAME_IN_ICU     NVARCHAR(16),
  WARD_CODE       NVARCHAR(8),
  WARD_TYPE       NUMERIC(2),
  ITEM_NAME_ALIAS NVARCHAR(8),
  VALUE_TYPE      NUMERIC(1),
  EXAM_METHOD     NUMERIC(1),
  IN_OR_OUT       NUMERIC(1),
  ITEM_TYPE       NUMERIC(1),
  CALC_SUM        NUMERIC(1),
  PRINT_ITEM_NO   NUMERIC(2),
  DRAW_STYLE      NUMERIC(1) default 1,
  DRAW_ISVALID		NUMERIC(1) default 1,
  SHOW_SUB_CODE   NVARCHAR(10),
  DATA_TABLE_CODE NVARCHAR(100),
  constraint PK_MED_MONITOR_FUNCTION_CODE primary key (ITEM_CODE)
)
----------------------------------50--------------------------------
create table MED_ICU_SHOW_DICT
(
  SHOW_NO             NUMERIC(3),
  SHOW_CODE           NVARCHAR(10) not null,
  SHOW_NAME           NVARCHAR(30),
  SHOW_ITEM_NO        NUMERIC(2,0),
  SHOW_STATE          NUMERIC(2),
  constraint PK_MED_ICU_SHOW_DICT primary key (SHOW_CODE)
)
----------------------------------51-------------------------------------
create table MED_ICU_SHOW_SUB_DICT
(
  SHOW_SUB_NO                 NUMERIC(3),
  SHOW_CODE 						NVARCHAR(10),
  SHOW_SUB_CODE 					NVARCHAR(10) not null,
  SHOW_SUB_NAME 					NVARCHAR(30),
  IN_OR_OUT							NUMERIC(1),
  SHOW_SUB_ITEM_NO        		NUMERIC(4,0),
  constraint PK_MED_ICU_SHOW_SUB_DICT primary key (SHOW_SUB_CODE)
)
-----------------------------------52----------------------------------------
create table MED_ICU_VALUE_TYPE_DICT
(
  SHOW_NO     NUMERIC(3),
  VALUE_TYPE      NUMERIC(1) not null,
  VALUE_NAME 	NVARCHAR(20),
  VALUE_MEMO	NVARCHAR(100),
  constraint PK_MED_ICU_VALUE_TYPE_DICT primary key (VALUE_TYPE)
)
-------------------------53--------------------------------------------------
create table MED_DATA_TABLE_CODE_DICT
(
  SHOW_NO			NUMERIC(3),
  TABLE_CODE		NVARCHAR(20) not null,
  TABLE_VALUE 		NVARCHAR(50),
  SHOW_NAME		NVARCHAR(100),
  constraint PK_MED_DATA_TABLE_CODE_DICT primary key (TABLE_CODE)
)
--------------------------54--------------------------------------------------
create table MED_MONITOR_SPECIAL_CODE
(
  ITEM_ID         NUMERIC(5),
  ITEM_NAME       NVARCHAR(40),
  ITEM_CODE       NVARCHAR(6) not null,
  ITEM_UNIT       NVARCHAR(8),
  DIS_COLOR       NUMERIC(8),
  PARM_CLASS      NVARCHAR(1),
  DRAW_ICON       NVARCHAR(2),
  USE_FLAG        NVARCHAR(1),
  PRIORITY_INDI   NUMERIC(1),
  MEMO            NVARCHAR(24),
  INPUT_CODE      NVARCHAR(8),
  NAME_IN_ICU     NVARCHAR(16),
  WARD_CODE       NVARCHAR(8),
  WARD_TYPE       NUMERIC(2),
  ITEM_NAME_ALIAS NVARCHAR(8),
  VALUE_TYPE      NUMERIC(1),
  EXAM_METHOD     NUMERIC(1),
  IN_OR_OUT       NUMERIC(1),
  ITEM_TYPE       NUMERIC(1),
  CALC_SUM        NUMERIC(1),
  PRINT_ITEM_NO   NUMERIC(2),
  DRAW_STYLE      NUMERIC(1) default 1,
  DRAW_ISVALID    NUMERIC(1) default 1,
  SHOW_SUB_CODE   NVARCHAR(10),
  DATA_TABLE_CODE NVARCHAR(100),
  constraint PK_MED_MONITOR_SPECIAL_CODE primary key (ITEM_CODE)
)
------------------------------55-----------------------------------
create table MED_MR_FILE_INDEX
(
  PATIENT_ID            NVARCHAR(20) not null,
  VISIT_ID              NUMERIC(2) not null,
  FILE_NO               NUMERIC(2) not null,
  FILE_NAME             NVARCHAR(16),
  TOPIC                 NVARCHAR(40),
  CREATOR_NAME          NVARCHAR(30),
  CREATOR_ID            NVARCHAR(16),
  CREATE_DATE_TIME      DATETIME,
  LAST_MODIFY_DATE_TIME DATETIME,
  FILE_FLAG             NVARCHAR(4),
  FILE_ATTR             NVARCHAR(4),
  constraint PK_MED_MR_FILE_INDEX primary key (PATIENT_ID, VISIT_ID, FILE_NO)
)
---------------------------------56----------------------------------------
create table MED_MR_INDEX
(
  PATIENT_ID            NVARCHAR(20) not null,
  VISIT_ID              NUMERIC(2) not null,
  MR_STATUS             NVARCHAR(1),
  STORAGE_VOLUME_LABEL  NVARCHAR(32),
  ACCESS_PATH           NVARCHAR(40),
  LAST_ACCESS_DATE_TIME DATETIME,
  constraint PK_MED_MR_INDEX primary key (PATIENT_ID, VISIT_ID)
)
---------------------------------57----------------------------------------
create table MED_MR_WORK_PATH
(
  MR_PATH      NVARCHAR(40) not null,
  TEMPLET_PATH NVARCHAR(40),
  FILE_USER    NVARCHAR(16),
  FILE_PWD     NVARCHAR(16),
  IP_ADDR      NVARCHAR(64),
  constraint PK_MED_MR_WORK_PATH primary key (MR_PATH)
)
----------------------------------58---------------------------------------
create table MED_MTRL_CLASS_DICT
(
  SERIAL_NO  NUMERIC(2),
  CLASS_NAME NVARCHAR(10) not null,
  INPUT_CODE NVARCHAR(8),
  constraint PK_MED_MTRL_CLASS_DICT primary key (CLASS_NAME)
)
---------------------------------59-----------------------------------------
create table MED_MTRL_DICT
(
  MTRL_CODE   NVARCHAR(16) not null,
  MTRL_NAME   NVARCHAR(60) not null,
  MTRL_SPEC   NVARCHAR(20) not null,
  UNITS       NVARCHAR(8),
  MTRL_CLASS  NVARCHAR(10),
  CODE_IN_HIS NVARCHAR(16),
  INPUT_CODE  NVARCHAR(8),
  constraint PK_MED_MTRL_DICT primary key (MTRL_CODE, MTRL_SPEC)
)
------------------------------60----------------------------------------------
create table MED_MTRL_EXPORT_CLASS_DICT
(
  SERIAL_NO    NUMERIC(2),
  EXPORT_CLASS NVARCHAR(8) not null,
  constraint PK_MED_MTRL_EXPORT_CLASS_DICT primary key (EXPORT_CLASS)
)
-------------------------------61-------------------------------------------
create table MED_MTRL_IMPORT_CLASS_DICT
(
  SERIAL_NO    NUMERIC(2),
  IMPORT_CLASS NVARCHAR(8) not null,
  constraint PK_MED_MTRL_IMPORT_CLASS_DICT primary key (IMPORT_CLASS)
)
----------------------------------62-----------------------------------------
create table MED_MTRL_NAME_DICT
(
  MTRL_CODE     NVARCHAR(16) not null,
  MTRL_NAME     NVARCHAR(60) not null,
  STD_INDICATOR NUMERIC(1),
  INPUT_CODE    NVARCHAR(8),
  constraint PK_MED_MTRL_NAME_DICT primary key (MTRL_CODE, MTRL_NAME)
)
---------------------------------63--------------------------------
create table MED_MTRL_SUPPLIER_CATALOG
(
  SUPPLIER_ID    NVARCHAR(16) not null,
  SUPPLIER       NVARCHAR(60) not null,
  SUPPLIER_CLASS NVARCHAR(8),
  CODE_IN_HIS    NVARCHAR(16),
  INPUT_CODE     NVARCHAR(8),
  constraint PK_MED_MTRL_SUPPLIER_CATALOG primary key (SUPPLIER_ID)
)
------------------------------------64---------------------------------
create table MED_NURSE_TEMPLETE
(
  WARD_CODE     NVARCHAR(8) not null,
  TEMPLETE_CODE NVARCHAR(10),
  TEMPLETE_NAME NVARCHAR(40) not null,
  TEMPLETE_DESC NVARCHAR(1000),
  INPUT_CODE    NVARCHAR(8),
  constraint PK_NURSE_TEMPLETE primary key (WARD_CODE, TEMPLETE_NAME)
)
----------------------------------65--------------------------------------
create table MED_NURSING_SCHEDULE_DICT
(
  SERIAL_NO     NUMERIC(2),
  WARD_CODE     NVARCHAR(8) not null,
  SCHEDULE_NAME NVARCHAR(8) not null,
  START_TIME    NVARCHAR(5),
  END_TIME      NVARCHAR(5),
  constraint PK_MED_NURSING_SCHEDULE_DICT primary key (WARD_CODE, SCHEDULE_NAME)
)
----------------------------------66----------------------------------------
create table MED_OPERATION_DICT
(
  OPERATION_CODE     NVARCHAR(16),
  OPERATION_NAME     NVARCHAR(60) not null,
  OPERATION_SCALE    NVARCHAR(2),
  STD_INDICATOR      NUMERIC(1),
  APPROVED_INDICATOR NUMERIC(1),
  CREATE_DATE        DATETIME,
  INPUT_CODE         NVARCHAR(8),
  INPUT_CODE_WB      NVARCHAR(8),
  constraint PK_MED_OPERATION_DICT primary key (OPERATION_NAME)
)
------------------------------------67-------------------------------------
create table MED_OPERATION_SCALE_DICT
(
  SERIAL_NO            NUMERIC(1),
  OPERATION_SCALE_CODE NVARCHAR(1) not null,
  OPERATION_SCALE_NAME NVARCHAR(2),
  INPUT_CODE           NVARCHAR(8),
  constraint PK_MED_OPERATION_SCALE_DICT primary key (OPERATION_SCALE_CODE)
)
-------------------------------------68--------------------------------------
create table MED_ORDERS
(
  PATIENT_ID             NVARCHAR(20) not null,
  VISIT_ID               NUMERIC(2) not null,
  ORDER_NO               NVARCHAR(20) not null,
  ORDER_SUB_NO           NUMERIC(20) not null,
  REPEAT_INDICATOR       NUMERIC(1),
  ORDER_CLASS            NVARCHAR(1),
  ORDER_TEXT             NVARCHAR(200),
  ORDER_CODE             NVARCHAR(20),
  DOSAGE                 NUMERIC(14,4),
  DOSAGE_UNITS           NVARCHAR(8),
  ADMINISTRATION         NVARCHAR(30),
  START_DATE_TIME        DATETIME,
  STOP_DATE_TIME         DATETIME,
  DURATION               NUMERIC(8),
  DURATION_UNITS         NVARCHAR(8),
  FREQUENCY              NVARCHAR(30),
  FREQ_COUNTER           NUMERIC(8),
  FREQ_INTERVAL          NUMERIC(8),
  FREQ_INTERVAL_UNIT     NVARCHAR(8),
  FREQ_DETAIL            NVARCHAR(30),
  PERFORM_SCHEDULE       NVARCHAR(60),
  PERFORM_RESULT         NVARCHAR(20),
  ORDERING_DEPT          NVARCHAR(16),
  DOCTOR                 NVARCHAR(30),
  STOP_DOCTOR            NVARCHAR(30),
  NURSE                  NVARCHAR(30),
  STOP_NURSE             NVARCHAR(30),
  ENTER_DATE_TIME        DATETIME,
  STOP_ORDER_DATE_TIME   DATETIME,
  ORDER_STATUS           NVARCHAR(1),
  BILLING_ATTR           NUMERIC(1),
  LAST_PERFORM_DATE_TIME DATETIME,
  LAST_ACCTING_DATE_TIME DATETIME,
  DRUG_BILLING_ATTR      NUMERIC(1),
  TREAT_SHEET_FLAG       NVARCHAR(1),
  PHAM_STD_CODE          NVARCHAR(14),
  AMOUNT                 NUMERIC(3),
  RESERVED1              NVARCHAR(10),
  DISPENSE_MEMOS         NVARCHAR(20),
  CURRENT_PRESC_NO       NUMERIC(6),
  DRUG_SPEC              NVARCHAR(40),
  QTY                    NUMERIC(10,2),
  constraint PK_MED_ORDERS primary key (PATIENT_ID, VISIT_ID, ORDER_NO, ORDER_SUB_NO)
)
-----------------------------------69--------------------------------------------
create table MED_ORDER_ATTR_DICT
(
  VITAL_SIGNS       NVARCHAR(100) not null,
  ORDER_ATTR        NVARCHAR(8),
  UNIT_WEIGHT_MOUNT NVARCHAR(20),
  constraint PK_MED_ORDER_ATTR_DICT primary key (VITAL_SIGNS)
)
-----------------------------------70------------------------------------------
create table MED_ORDER_CLASS_DICT
(
  SERIAL_NO        NUMERIC(2),
  ORDER_CLASS_CODE NVARCHAR(1) not null,
  ORDER_CLASS_NAME NVARCHAR(8),
  INPUT_CODE       NVARCHAR(8),
  constraint PK_MED_ORDER_CLASS_DICT primary key (ORDER_CLASS_CODE)
)
-----------------------------------71--------------------------------------------
create table MED_ORDER_STATUS_DICT
(
  SERIAL_NO         NUMERIC(1),
  ORDER_STATUS_CODE NVARCHAR(1) not null,
  ORDER_STATUS_NAME NVARCHAR(8),
  INPUT_CODE        NVARCHAR(8),
  constraint PK_MED_ORDER_STATUS_DICT primary key (ORDER_STATUS_CODE)
)
-----------------------------------72---------------------------------------
create table MED_OUTER_APP_USE
(
  APPLICATION    NVARCHAR(16) not null,
  DICT_FILE_NAME NVARCHAR(16) not null,
  constraint PK_MED_OUTER_APP_USE primary key (APPLICATION, DICT_FILE_NAME)
)
-----------------------------------73------------------------------------------
create table MED_OUTER_CODING_CONFIG
(
  TOPIC               NVARCHAR(8) not null,
  ITEM_CLASS          NVARCHAR(4),
  CODING_SCHM         NVARCHAR(4) not null,
  OUTER_CODE_LENGTH   NUMERIC(2),
  TEXT_LENGTH         NUMERIC(3),
  STD_CODE_LENGTH     NUMERIC(2),
  DICT_FILE_NAME      NVARCHAR(16),
  LAST_UPDT_DATE_TIME DATETIME,
  constraint PK_MED_OUTER_CODING_CONFIG primary key (TOPIC, CODING_SCHM)
)
-------------------------------74-----------------------------------------
create table MED_OUTER_GENERATION
(
  DICT_FILE_NAME   NVARCHAR(16) not null,
  DATA_TABLE_NAME  NVARCHAR(32) not null,
  DATA_INPUT_FIELD NVARCHAR(32) not null,
  DATA_CODE_FIELD  NVARCHAR(32) not null,
  DATA_NAME_FIELD  NVARCHAR(32) not null,
  DATA_FILTER      NVARCHAR(128),
  UPDT_METHOD      NUMERIC(3),
  DICT_TXT_FILE    NTEXT,
  INPUT_CODE_WB    NVARCHAR(32),
  constraint PK_MED_OUTER_GENERATION primary key (DICT_FILE_NAME)
)
--------------------------------75------------------------------------
create table MED_PATIENT_FORM_DATA_DICT
(
  PATIENT_ID NVARCHAR(20) not null,
  VISIT_ID   NUMERIC(2) not null,
  ITEM_NO    NUMERIC(2),
  ITEM_NAME  NVARCHAR(20) not null,
  ITEM_UNIT  NVARCHAR(10),
  constraint PK_PATIENT_FORM_DATA_DICT primary key (PATIENT_ID, VISIT_ID, ITEM_NAME)
)
--------------------------------------76-------------------------------
create table MED_PATIENT_STATUS_CHG_DICT
(
  SERIAL_NO               NUMERIC(2),
  PATIENT_STATUS_CHG_CODE NVARCHAR(4) not null,
  PATIENT_STATUS_CHG_NAME NVARCHAR(10),
  INPUT_CODE              NVARCHAR(8),
  constraint PK_MED_PATIENT_STATUS_CHG_DICT primary key (PATIENT_STATUS_CHG_CODE)
)
-----------------------------------77------------------------------------
create table MED_PATS_IN_HOSPITAL
(
  PATIENT_ID             NVARCHAR(20) not null,
  VISIT_ID               NUMERIC(2) not null,
  DEP_ID		 NUMERIC(2),
  WARD_CODE              NVARCHAR(16),
  DEPT_CODE              NVARCHAR(16),
  BED_NO                 NVARCHAR(20),
  ADMISSION_DATE_TIME    DATETIME,
  ADM_WARD_DATE_TIME     DATETIME,
  DIAGNOSIS              NVARCHAR(200),
  PATIENT_CONDITION      NVARCHAR(1),
  NURSING_CLASS          NVARCHAR(1),
  DOCTOR_IN_CHARGE       NVARCHAR(30),
  OPERATING_DATE         DATETIME,
  BILLING_DATE_TIME      DATETIME,
  PREPAYMENTS            NUMERIC(10,2),
  TOTAL_COSTS            NUMERIC(10,2),
  TOTAL_CHARGES          NUMERIC(10,2),
  GUARANTOR              NVARCHAR(8),
  GUARANTOR_ORG          NVARCHAR(40),
  GUARANTOR_PHONE_NUM    NVARCHAR(16),
  BILL_CHECKED_DATE_TIME DATETIME,
  SETTLED_INDICATOR      NUMERIC(1),
  RESERVED01             NVARCHAR(50),
  RESERVED02             NVARCHAR(50),
  RESERVED03             NVARCHAR(50),
  RESERVED04             NVARCHAR(50),
  RESERVED05             NVARCHAR(50),
  RESERVED06             NVARCHAR(50),
  RESERVED07             NVARCHAR(50),
  RESERVED08             NVARCHAR(50),
  RESERVED09             NVARCHAR(50),
  RESERVED10             NVARCHAR(50),
  RESERVED_DATE01        DATETIME,
  RESERVED_DATE02        DATETIME,
  START_DATE_TIME        DATETIME,
  FREQUENCY_NURSE        NUMERIC(5),
  NURSE_IN_CHARGE        NVARCHAR(30),
  constraint PK_MED_PATS_IN_HOSPITAL primary key (PATIENT_ID,VISIT_ID)
)
-------------------------78-------------------------------------------
create table MED_PAT_MASTER_INDEX
(
  PATIENT_ID            NVARCHAR(20) not null,
  INP_NO                NVARCHAR(20),
  [NAME]                  NVARCHAR(30),
  NAME_PHONETIC         NVARCHAR(16),
  SEX                   NVARCHAR(4),
  DATE_OF_BIRTH         DATETIME,
  BIRTH_PLACE           NVARCHAR(60),
  CITIZENSHIP           NVARCHAR(30),
  NATION                NVARCHAR(30),
  ID_NO                 NVARCHAR(20),
  [IDENTITY]              NVARCHAR(10),
  CHARGE_TYPE           NVARCHAR(30),
  UNIT_IN_CONTRACT      NVARCHAR(11),
  MAILING_ADDRESS       NVARCHAR(80),
  ZIP_CODE              NVARCHAR(6),
  PHONE_NUMBER_HOME     NVARCHAR(40),
  PHONE_NUMBER_BUSINESS NVARCHAR(40),
  NEXT_OF_KIN           NVARCHAR(30),
  RELATIONSHIP          NVARCHAR(20),
  NEXT_OF_KIN_ADDR      NVARCHAR(80),
  NEXT_OF_KIN_ZIP_CODE  NVARCHAR(6),
  NEXT_OF_KIN_PHONE     NVARCHAR(40),
  LAST_VISIT_DATE       DATETIME,
  VIP_INDICATOR         NUMERIC(1),
  CREATE_DATE           DATETIME,
  OPERATOR              NVARCHAR(30),
  constraint PK_MED_PAT_MASTER_INDEX primary key (PATIENT_ID)
)
-------------------------------79-----------------------------
create table MED_PAT_MONITOR_DATA_DICT
(
  PATIENT_ID        NVARCHAR(20) not null,
  VISIT_ID          NUMERIC(2) not null,
  DEP_ID	    NUMERIC(2),
  MONITOR_DATA_NAME NVARCHAR(40),
  DB_DATA_NAME      NVARCHAR(40) not null,
  LOW_SIGNS_VALUES  NUMERIC(6,2),
  HIGH_SIGNS_VALUES NUMERIC(6,2),
  constraint PK_PAT_MONITOR_DATA_DICT primary key (PATIENT_ID, VISIT_ID, DB_DATA_NAME)
)
------------------------------------80----------------------
create table MED_PAT_VISIT
(
  PATIENT_ID               NVARCHAR(20) not null,
  VISIT_ID                 NUMERIC(2) not null,
  DEPT_ADMISSION_TO        NVARCHAR(16),
  ADMISSION_DATE_TIME      DATETIME,
  DEPT_DISCHARGE_FROM      NVARCHAR(16),
  DISCHARGE_DATE_TIME      DATETIME,
  OCCUPATION               NVARCHAR(1),
  MARITAL_STATUS           NVARCHAR(4),
  [IDENTITY]                 NVARCHAR(10),
  ARMED_SERVICES           NVARCHAR(4),
  DUTY                     NVARCHAR(4),
  TOP_UNIT                 NVARCHAR(1),
  SERVICE_SYSTEM_INDICATOR NUMERIC(1),
  UNIT_IN_CONTRACT         NVARCHAR(11),
  CHARGE_TYPE              NVARCHAR(30),
  WORKING_STATUS           NUMERIC(1),
  INSURANCE_TYPE           NVARCHAR(16),
  INSURANCE_NO             NVARCHAR(18),
  SERVICE_AGENCY           NVARCHAR(80),
  MAILING_ADDRESS          NVARCHAR(80),
  ZIP_CODE                 NVARCHAR(6),
  NEXT_OF_KIN              NVARCHAR(30),
  RELATIONSHIP             NVARCHAR(2),
  NEXT_OF_KIN_ADDR         NVARCHAR(80),
  NEXT_OF_KIN_ZIPCODE      NVARCHAR(6),
  NEXT_OF_KIN_PHONE        NVARCHAR(40),
  PATIENT_CLASS            NVARCHAR(1),
  ADMISSION_CAUSE          NVARCHAR(8),
  CONSULTING_DATE          DATETIME,
  PAT_ADM_CONDITION        NVARCHAR(1),
  CONSULTING_DOCTOR        NVARCHAR(30),
  ADMITTED_BY              NVARCHAR(30),
  EMER_TREAT_TIMES         NUMERIC(2),
  ESC_EMER_TIMES           NUMERIC(2),
  SERIOUS_COND_DAYS        NUMERIC(4),
  CRITICAL_COND_DAYS       NUMERIC(4),
  ICU_DAYS                 NUMERIC(4),
  CCU_DAYS                 NUMERIC(4),
  SPEC_LEVEL_NURS_DAYS     NUMERIC(4),
  FIRST_LEVEL_NURS_DAYS    NUMERIC(4),
  SECOND_LEVEL_NURS_DAYS   NUMERIC(4),
  AUTOPSY_INDICATOR        NUMERIC(1),
  BLOOD_TYPE               NVARCHAR(2),
  BLOOD_TYPE_RH            NVARCHAR(1),
  INFUSION_REACT_TIMES     NUMERIC(2),
  BLOOD_TRAN_TIMES         NUMERIC(2),
  BLOOD_TRAN_VOL           NUMERIC(5),
  BLOOD_TRAN_REACT_TIMES   NUMERIC(2),
  DECUBITAL_ULCER_TIMES    NUMERIC(2),
  ALERGY_DRUGS             NVARCHAR(80),
  ADVERSE_REACTION_DRUGS   NVARCHAR(80),
  MR_VALUE                 NVARCHAR(4),
  MR_QUALITY               NVARCHAR(2),
  FOLLOW_INDICATOR         NUMERIC(1),
  FOLLOW_INTERVAL          NUMERIC(2),
  FOLLOW_INTERVAL_UNITS    NVARCHAR(2),
  DIRECTOR                 NVARCHAR(30),
  ATTENDING_DOCTOR         NVARCHAR(30),
  DOCTOR_IN_CHARGE         NVARCHAR(30),
  DISCHARGE_DISPOSITION    NVARCHAR(1),
  TOTAL_COSTS              NUMERIC(10,2),
  TOTAL_PAYMENTS           NUMERIC(10,2),
  CATALOG_DATE             DATETIME,
  CATALOGER                NVARCHAR(8),
  RESERVED01               NVARCHAR(50),
  RESERVED02               NVARCHAR(50),
  RESERVED03               NVARCHAR(50),
  RESERVED04               NVARCHAR(50),
  RESERVED05               NVARCHAR(50),
  RESERVED06               NVARCHAR(50),
  RESERVED07               NVARCHAR(50),
  RESERVED08               NVARCHAR(50),
  RESERVED09               NVARCHAR(50),
  RESERVED10               NVARCHAR(50),
  RESERVED_DATE01          DATETIME,
  RESERVED_DATE02          DATETIME,
  BODY_HEIGHT              NUMERIC(4,1),
  BODY_WEIGHT              NUMERIC(4,1),
  PATIENT_CONDITION        NVARCHAR(12),
  ABNORMAL                 NVARCHAR(80),
  constraint PK_MED_PAT_VISIT primary key (PATIENT_ID, VISIT_ID)
)
----------------------------81--------------------------------
create table MED_PERFORM_DEFAULT_SCHEDULE
(
  SERIAL_NO        NUMERIC(3),
  FREQ_DESC        NVARCHAR(16) not null,
  ADMINISTRATION   NVARCHAR(16) not null,
  DEFAULT_SCHEDULE NVARCHAR(60),
  constraint PK_MED_PER_DEFAULT_SCHEDULE primary key (FREQ_DESC, ADMINISTRATION)
)
-----------------------------82---------------------------------
create table MED_PERMISSIONS
(
  PERMISSION_ID  NVARCHAR(36) not null,
  APP_ID         NVARCHAR(36) not null,
  [NAME]           NVARCHAR(100) not null,
  PERMISSION_KEY NVARCHAR(160) not null,
  SORT_ID        NUMERIC(10),
  IS_VALID       NVARCHAR(1) default 'T' not null,
  DESCRIPTION    NVARCHAR(160),
  constraint KEY_MED_PERMISSIONS primary key (PERMISSION_ID)
)
-------------------------------83-----------------------------------
create table MED_PERMISSIONS_ANES
(
	PERMISSION_ID NVARCHAR(36) not null,
	[TYPE]          NVARCHAR(2),
	MODULE        NVARCHAR(6),
	PIC           NVARCHAR(50),
	WD_NAME		  NVARCHAR(2000),
	WD_DESC        NVARCHAR(60),
	WD_MENUNAME	  NVARCHAR(2000),
	MENU_KEY	  NVARCHAR(60),
	PARENT_ID     NVARCHAR(36),
	CHILD_ID 			NVARCHAR(36),
    constraint PK_MED_PERMISSIONS_ANES primary key (PERMISSION_ID)
)
----------------------------84------------------------------------
create table MED_RELATIONSHIP_DICT
(
  SERIAL_NO         NUMERIC(2),
  RELATIONSHIP_CODE NVARCHAR(2) not null,
  RELATIONSHIP_NAME NVARCHAR(10),
  INPUT_CODE        NVARCHAR(8),
  constraint PK_MED_RELATIONSHIP_DICT primary key (RELATIONSHIP_CODE)
)
------------------------------85--------------------------------
create table MED_PRICE_ITEM_NAME_DICT
(
  ITEM_CLASS    NVARCHAR(16) not null,
  ITEM_NAME     NVARCHAR(60) not null,
  ITEM_CODE     NVARCHAR(10),
  STD_INDICATOR NUMERIC(1),
  INPUT_CODE    NVARCHAR(8),
  CUSTOM_CODE   NVARCHAR(8),
  INPUT_CODE_WB NVARCHAR(8),
  STOP_FLAG     NVARCHAR(2),
  constraint PK_MED_PRICE_ITEM_NAME_DICT primary key (ITEM_CLASS, ITEM_NAME)
)
-------------------------------86--------------------------------
create table MED_PRICE_LIST
(
  ITEM_CLASS         NVARCHAR(16),
  ITEM_CODE          NVARCHAR(10),
  ITEM_NAME          NVARCHAR(60),
  ITEM_SPEC          NVARCHAR(20),
  UNITS              NVARCHAR(8),
  PRICE              NUMERIC(9,3),
  PREFER_PRICE       NUMERIC(9,3),
  FOREIGNER_PRICE    NUMERIC(9,3),
  PERFORMED_BY       NVARCHAR(8),
  FEE_TYPE_MASK      NUMERIC(1),
  CLASS_ON_INP_RCPT  NVARCHAR(1),
  CLASS_ON_OUTP_RCPT NVARCHAR(1),
  CLASS_ON_RECKONING NVARCHAR(10),
  SUBJ_CODE          NVARCHAR(3),
  CLASS_ON_MR        NVARCHAR(4),
  MEMO               NVARCHAR(40),
  START_DATE         DATETIME,
  STOP_DATE          DATETIME,
  OPERATOR           NVARCHAR(8),
  ENTER_DATE         DATETIME,
  INPUT_CODE         NVARCHAR(8),
  RESERVED1          NVARCHAR(50),
  RESERVED2          NVARCHAR(50),
  RESERVED3          NVARCHAR(50),
  RESERVED4          NUMERIC(3),
  RESERVED5          NUMERIC(3),
constraint PK_MED_PRICE_LIST primary key (ITEM_CLASS, ITEM_CODE, ITEM_SPEC, UNITS, START_DATE)
  
)
-------------------------87----------------------------
create table MED_ROLES
(
  ROLE_ID     NVARCHAR(36) not null,
  APP_ID      NVARCHAR(36) not null,
  [NAME]        NVARCHAR(60) not null,
  DESCRIPTION NVARCHAR(160),
  CREATE_DATE DATETIME not null,
  constraint KEY_MED_ROLES primary key (ROLE_ID)
)
--------------------------88-----------------------
create table MED_ROLES_PERMISSIONS
(
  ROLE_ID       NVARCHAR(36) not null,
  PERMISSION_ID NVARCHAR(36) not null,
  constraint KEY_MED_ROLES_PERMISSIONS primary key (ROLE_ID, PERMISSION_ID)
)
-----------------------------89-----------------------
create table MED_SPECIFIC_WORD_DICT
(
  WORD_CODE  NVARCHAR(10),
  WORD_NAME  NVARCHAR(40) not null,
  INPUT_CODE NVARCHAR(8),
  constraint PK_SPECIFIC_WORD_DICT primary key (WORD_NAME)
)
-------------------------90-------------------------------
create table MED_STAFF_DICT
(
  EMP_NO      NVARCHAR(6) not null,
  DEPT_CODE   NVARCHAR(8),
  [NAME]        NVARCHAR(30),
  INPUT_CODE  NVARCHAR(8),
  JOB         NVARCHAR(8),
  TITLE       NVARCHAR(10),
  [USER_NAME]   NVARCHAR(30),
  IN_HOSPITAL NUMERIC(1),
  NURSE_TYPE  NVARCHAR(8),
  VERIFY_PW   NVARCHAR(20),
  CREATE_DATE DATETIME,
constraint PK_MED_STAFF_DICT primary key (EMP_NO)
)
------------------------91---------------------------
create table MED_STAFF_VS_GROUP
(
  GROUP_CLASS NVARCHAR(16) not null,
  GROUP_CODE  NVARCHAR(8) not null,
  EMP_NO      NVARCHAR(6) not null,
  constraint PK_MED_STAFF_VS_GROUP primary key (GROUP_CLASS, GROUP_CODE, EMP_NO)
)
------------------------92---------------------------
create table MED_TITLE_DICT
(
  SERIAL_NO  NUMERIC(3),
  TITLE_CODE NVARCHAR(3) not null,
  TITLE_NAME NVARCHAR(26),
  INPUT_CODE NVARCHAR(8),
  constraint PK_MED_TITLE_DICT primary key (TITLE_CODE)
)
----------------------93----------------------------------
create table MED_TRANSFER
(
  PATIENT_ID          NVARCHAR(20) not null,
  VISIT_ID            NUMERIC(2) not null,
  DEPT_STAYED         NVARCHAR(16),
  ADMISSION_DATE_TIME DATETIME not null,
  DISCHARGE_DATE_TIME DATETIME,
  DEPT_TRANSFERED_TO  NVARCHAR(16),
  DOCTOR_IN_CHARGE    NVARCHAR(30),
  WARD_STAYED         NVARCHAR(16),
  WARD_TRANSFERED_TO  NVARCHAR(16),
  RESERVED1           NUMERIC(3),
  BED_NO              NVARCHAR(20),
  RESERVED2           NUMERIC(3),
  RESERVED3           DATETIME,
  constraint PK_MED_TRANSFER primary key (PATIENT_ID, VISIT_ID, ADMISSION_DATE_TIME)
)
----------------------------94--------------------------
create table MED_USERS
(
  [USER_ID]     NVARCHAR(36) not null,
  LOGIN_NAME  NVARCHAR(36) not null,
  LOGIN_PWD   NVARCHAR(36) not null,
  [USER_NAME]   NVARCHAR(36),
  DEPT_ID     NVARCHAR(16),
  CREATE_DATE DATETIME,
  IS_VALID    NVARCHAR(1) default 'T' not null,
  MEMO        NVARCHAR(100),
  constraint KEY_MED_USERS primary key ([USER_ID])
)
--------------------------------95------------------------
create table MED_USERS_DEPTS
(
  [USER_ID] NVARCHAR(36) not null,
  DEPT_ID NVARCHAR(16) not null,
  constraint KEY_MED_USERS_DEPTS primary key ([USER_ID], DEPT_ID)
)
----------------------------96------------------------------
create table MED_USERS_ROLES
(
  [USER_ID] NVARCHAR(36) not null,
  ROLE_ID NVARCHAR(36) not null,
  constraint KEY_MED_USERS_ROLES primary key ([USER_ID], ROLE_ID)
)
---------------------------------97-----------------------
create table MED_VS_HIS_OPER_APPLY
(
  MED_PATIENT_ID  NVARCHAR(20) not null,
  MED_VISIT_ID    NUMERIC(2) not null,
  MED_SCHEDULE_ID NUMERIC(2) not null,
  HIS_APPLY_NO    NVARCHAR(20),
  HIS_PATIENT_ID  NVARCHAR(20),
  HIS_VISIT_ID    NUMERIC(10),
  HIS_SCHEDULE_ID NUMERIC(10),
  REQ_DATE_TIME   NVARCHAR(10) not null,
  constraint PK_MED_VS_HIS_OPER_APPLY primary key (MED_PATIENT_ID, MED_VISIT_ID, MED_SCHEDULE_ID, REQ_DATE_TIME)
)
-----------------------------98----------------------------
create table MED_VS_HIS_OPER_MASTER
(
  MED_PATIENT_ID  NVARCHAR(20) not null,
  MED_VISIT_ID    NUMERIC(2) not null,
  MED_OPER_ID     NUMERIC(2) not null,
  HIS_APPLY_NO    NVARCHAR(20),
  HIS_PATIENT_ID  NVARCHAR(20),
  HIS_VISIT_ID    NVARCHAR(20),
  HIS_SCHEDULE_ID NUMERIC(10),
  REQ_DATE_TIME   NVARCHAR(10),
  constraint PK_MED_VS_HIS_OPER_MASTER primary key (MED_PATIENT_ID, MED_VISIT_ID, MED_OPER_ID)
)
----------------------------------99---------------------------
create table MED_VS_HIS_ORDERS
(
  MED_PATIENT_ID       NVARCHAR(20) not null,
  MED_VISIT_ID         NUMERIC(2) not null,
  MED_ORDER_NO         NVARCHAR(20) not null,
  MED_ORDER_SUB_NO     NUMERIC(20) not null,
  MED_REPEAT_INDICATOR NUMERIC(1) not null,
  HIS_ORDER_NO         NVARCHAR(20),
  HIS_ORDER_SUB_NO     NVARCHAR(20),
  CREATE_DATE          DATETIME,
  RESERVED01           NVARCHAR(50),
  RESERVED02           NVARCHAR(50),
  RESERVED03           NVARCHAR(50),
  RESERVED04           NVARCHAR(50),
  RESERVED05           NVARCHAR(50),
  constraint PK_MED_VS_HIS_ORDERS primary key (MED_PATIENT_ID, MED_VISIT_ID, MED_ORDER_NO, MED_ORDER_SUB_NO, MED_REPEAT_INDICATOR)
)
------------------------100-----------------------------------
create table MED_VS_HIS_ORDER_CLASS
(
  SERIAL_NO      NUMERIC(3),
  HIS_CLASS_CODE NVARCHAR(16) not null,
  HIS_CLASS_NAME NVARCHAR(16),
  MED_CLASS_CODE NVARCHAR(1),
  MED_CLASS_NAME NVARCHAR(8),
  constraint PK_MED_VS_HIS_ORDER_CLASS primary key (HIS_CLASS_CODE)
)
------------------------101----------------------------------
create table MED_VS_HIS_PAT
(
  MED_PATIENT_ID NVARCHAR(20) not null,
  MED_VISIT_ID   NUMERIC(2) not null,
  HIS_PATIENT_ID NVARCHAR(20),
  HIS_INP_NO     NVARCHAR(20),
  HIS_VISIT_ID   NVARCHAR(20),
  CREATE_DATE    DATETIME,
  RESERVED01     NVARCHAR(50),
  RESERVED02     NVARCHAR(50),
  RESERVED03     NVARCHAR(50),
  RESERVED04     NVARCHAR(50),
  RESERVED05     NVARCHAR(50),
  RESERVED06     NVARCHAR(50),
  RESERVED07     NVARCHAR(50),
  RESERVED08     NVARCHAR(50),
  constraint PK_MED_VS_HIS_PAT primary key (MED_PATIENT_ID, MED_VISIT_ID)
)
---------------------102----------------------------
create table MED_VS_PACS_EXAM
(
  MED_EXAM_NO          NVARCHAR(20) not null,
  HIS_ITEM_CLASS       NVARCHAR(20),
  HIS_EXAM_NO          NUMERIC(10),
  HIS_PATIENT_LOCAL_ID NVARCHAR(20),
  constraint PK_MED_VS_PACS_EXAM primary key (MED_EXAM_NO)
)
-------------------103-----------------------------------
create table MED_WOUND_GRADE_DICT
(
  SERIAL_NO        NUMERIC(1),
  WOUND_GRADE_CODE NVARCHAR(1) not null,
  WOUND_GRADE_NAME NVARCHAR(2),
  INPUT_CODE       NVARCHAR(8),
  constraint PK_MED_WOUND_GRADE_DICT primary key (WOUND_GRADE_CODE)
)
------------------104-----------------------------------------
create table MED_INPUTORDER_TEMPLETE
(
  WARD_CODE     NVARCHAR(8) not null,
  TEMPLETE_CODE NVARCHAR(10),
  TEMPLETE_NAME NVARCHAR(40) not null,
  TEMPLETE_DESC NVARCHAR(1000),
  INPUT_CODE    NVARCHAR(8),
  constraint PK_ORDER_TEMPLETE primary key (WARD_CODE, TEMPLETE_NAME)
)
------------------------105---------------------------
create table MED_MARITAL_STATUS_DICT
(
  SERIAL_NO           NUMERIC(1),
  MARITAL_STATUS_CODE NVARCHAR(1),
  MARITAL_STATUS_NAME NVARCHAR(4) not null,
  INPUT_CODE          NVARCHAR(8),
  constraint PK_MED_MARITAL_STATUS_DICT primary key (MARITAL_STATUS_NAME)
)
-----------------------106------------------------------
create table MED_SEX_DICT
(
  SERIAL_NO     NUMERIC(1),
  SEX_CODE      NVARCHAR(1),
  SEX_NAME      NVARCHAR(4) not null,
  INPUT_CODE    NVARCHAR(8),
  INPUT_CODE_WB NVARCHAR(8),
  constraint PK_MED_SEX_DICT primary key (SEX_NAME)
)
---------------------------107-------------------------
create table MED_BILL_CONFIG_DICT
(
  ITEM_CLASS         NVARCHAR(16) not null,
  ITEM_NAME          NVARCHAR(60) not null,
  BILL_MODE          NVARCHAR(20),
  BILL_RESULT_RULE   NVARCHAR(20),
  BILL_TIME_RULE     NVARCHAR(20),
  BILL_STANDARD_TIME NUMERIC(5,2),
  CHARGE_ITEM_CLASS  NVARCHAR(16),
  CHARGE_ITEM_CODE   NVARCHAR(16),
  CHARGE_ITEM_NAME   NVARCHAR(60),
  CHARGE_ITEM_SPEC   NVARCHAR(20),
  UNITS              NVARCHAR(8),
  constraint PK_CLINIC_VS_CHARGE primary key (ITEM_CLASS, ITEM_NAME)
)
-----------------------------108--------------------------
create table MED_MR_CONTENT
(
  PATIENT_ID NVARCHAR(20) not null,
  VISIT_ID   NVARCHAR(2) not null,
  FILE_NO    NVARCHAR(2) not null,
  MR_CONT    NTEXT ,
  constraint PK_MED_MR_CONTENT primary key (PATIENT_ID, VISIT_ID, FILE_NO)
)
-----------------------------109---------------------------
create table MED_MR_FILE
(
  PATIENT_ID        NVARCHAR(20) not null,
  VISIT_ID          NUMERIC(2) not null,
  FILE_NO           NUMERIC(2) not null,
  TOPIC             NVARCHAR(40),
  CREATOR_ID        NVARCHAR(16),
  CREATE_DATE_TIME  DATETIME,
  TEMPLET_ID        NVARCHAR(6),
  MR_MODIFY_TIMES   NUMERIC(3),
  MR_PRINT_TIMES    NUMERIC(3),
  CURRENT_USER_NAME NVARCHAR(8),
  CAPABILITY        NVARCHAR(1),
  CHECKUP_MARK      NVARCHAR(1),
  RETURNED_MARK     NVARCHAR(1),
  LAST_MODIDATE     DATETIME,
  constraint PK_MED_MR_FILE primary key (PATIENT_ID, VISIT_ID, FILE_NO)
)
----------------------------110-----------------------------------
create table MED_OPERROOM_CUPBOARD
(
  CUPBOARD NVARCHAR(3) not null,
  MEMO     NVARCHAR(100),
  STATUS   NUMERIC(1),
  constraint PK_MED_OPERROOM_CUPBOARD primary key (CUPBOARD)
)
-----------------------------111--------------------------------
create table MED_OPER_ROOM_USERS
(
  [USER_ID]     NVARCHAR(36) not null,
  [USER_NAME]   NVARCHAR(30),
  USER_DEPT   NVARCHAR(16),
  USER_JOB    NVARCHAR(8),
  STATUS      NUMERIC(1),
  CREATE_DATE DATETIME,
  RESERVED01  NVARCHAR(50),
  INPUT_CODE  NVARCHAR(30),
  STATUS_NOW  NUMERIC(1),
  constraint PK_MED_OPER_ROOM_USERS primary key ([USER_ID])
)
--------------------------------112-------------------------------
create table MED_USERS_INOUTTIME
(
  [USER_ID]  NVARCHAR(36) not null,
  IN_TIME  DATETIME not null,
  OUT_TIME DATETIME,
  CUPBOARD NVARCHAR(3),
   constraint PK_MED_USERS_INOUTTIME primary key (USER_ID, IN_TIME)
)
-----------------------------113------------------------------------
create table MED_USERS_ZP
(
  [USER_ID] NVARCHAR(36) not null,
  ZP      ntext
)
----------------------------114-------------------------------------
create table MED_ANESTHESIA_ITEM_CLASS
(
  SERIAL_NO  NUMERIC(4)		NOT NULL,
  FUNC			 NVARCHAR(16) not null,
  ITEM_CLASS NVARCHAR(40) not null,
  ITEM_CODE  NVARCHAR(40),
  INPUT_CODE NVARCHAR(8),
  constraint PK_MED_ANESTHESIA_ITEM_CLASS primary key (SERIAL_NO)
)
-------------------------------115---------------------------
create table MED_VS_HIS_OPER_BILL_CONSTS
(
  PATIENT_ID  VARCHAR(20) not null,
  VISIT_ID    numeric(2) not null,
  OPER_ID numeric(2) not null,
  CONSTS_COUNT numeric(5) not null,
  ITEM_NO_STRING VARCHAR(200) not null,
  ITEM_NO_STRING_INDICATOR VARCHAR(200),
  RESERVED1 VARCHAR(500),
  RESERVED2 VARCHAR(20),
  RESERVED3 VARCHAR(20),
  constraint PK_MED_VS_HIS_OPER_BILL_CONSTS primary key (PATIENT_ID, VISIT_ID, OPER_ID, CONSTS_COUNT,ITEM_NO_STRING)
)
----------------------------116---------------------------------
create table MED_VS_HIS_OPER_APPLY_V2
(
  MED_PATIENT_ID  NVARCHAR(20) not null,
  MED_VISIT_ID    NUMERIC(2) not null,
  MED_SCHEDULE_ID NUMERIC(2) not null,
  HIS_APPLY_NO    NVARCHAR(20),
  HIS_PATIENT_ID  NVARCHAR(20),
  HIS_VISIT_ID    NVARCHAR(20),
  HIS_SCHEDULE_ID NUMERIC(10),
  REQ_DATE_TIME   NVARCHAR(10),
  constraint PK_MED_VS_HIS_OPER_APPLY_V2 primary key (MED_PATIENT_ID, MED_VISIT_ID, MED_SCHEDULE_ID)
)
--------------------------117------------------------------------
create table MED_EMR_ARCHIVE_DETIAL
(
  patient_id        NVARCHAR(20) not null,
  visit_id          NUMERIC(2) not null,
  mr_class          NVARCHAR(10) not null,
  mr_sub_class      NVARCHAR(100) not null,
  archive_key       NVARCHAR(20) not null,
  emr_file_index    NUMERIC(3) default 0 not null,
  archive_times     NUMERIC(2) not null,
  topic             NVARCHAR(40),
  emr_file_name     NVARCHAR(256),
  emr_type          NVARCHAR(10),
  archive_date_time DATETIME,
  archive_type      NVARCHAR(10),
  archive_status    NVARCHAR(10),
  emr_owner         NVARCHAR(16),
  operator          NVARCHAR(16),
  archive_pc        NVARCHAR(80),
  archive_mode      NVARCHAR(10),
  archive_access    NVARCHAR(256),
  memo              NVARCHAR(100),
  constraint PK_MED_EMR_ARCHIVE_DETIAL primary key (PATIENT_ID, VISIT_ID, MR_CLASS, MR_SUB_CLASS, ARCHIVE_KEY, EMR_FILE_INDEX, ARCHIVE_TIMES)
)
---------------------------------118--------------------------
create table MED_EMR_CLASS_DICT
(
  SERIAL_NO      NUMERIC(2),
  MR_CLASS       NVARCHAR(10) not null,
  MR_SUB_CLASS   NVARCHAR(10) not null,
  HIDE_INDICATOR NUMERIC(1),
  constraint PK_MED_EMR_CLASS_DICT primary key (MR_CLASS,MR_SUB_CLASS)
)
-----------------------119--------------------------------------
create table MED_EMR_WORK_PATH
(
  [APPLICATION] NVARCHAR(20) not null,
  EMR_PATH    NVARCHAR(240) not null,
  [USER_NAME]   NVARCHAR(16),
  USER_PWD    NVARCHAR(16),
  IP_ADDR     NVARCHAR(64),
   constraint PK_MED_EMR_WORK_PATH primary key (APPLICATION, EMR_PATH)
)
---------------------120-------------------------------
create table MED_EMR_USERS
(
  [USER_ID]    NVARCHAR(36) not null,
  LOGIN_NAME NVARCHAR(36),
  LOGIN_PWD  NVARCHAR(36),
  [NAME]       NVARCHAR(36),
  DEPT_CODE  NVARCHAR(16),
  INPUT_CODE NVARCHAR(8),
  JOB        NVARCHAR(16),
  TITLE      NVARCHAR(10),
  GRANT_CODE NVARCHAR(20),
  IS_VALID   NUMERIC(1),
  constraint PK_MED_EMR_USERS primary key ([USER_ID])
)
---------------------121------------------------------------
create table MED_SCREEN_COL_LIST
(
  COL        NVARCHAR(30) not null,
  [COL_NAME]   NVARCHAR(30) not null,
  COL_WIDTH  NUMERIC(12,2) not null,
  COL_STATUS NUMERIC(1),
  COL_NO     NUMERIC(3)
)
--------------------122----------------------------------------
create table MED_SCREEN_TEMPLATE
(
  SCREEN_COL_COLOR         NVARCHAR(16),
  SCREEN_BACK_COLOR        NVARCHAR(16),
  SCREEN_TITLE_COLOR       NVARCHAR(16),
  SCREEN_TIMEPAGE_COLOR    NVARCHAR(16),
  SCREEN_SHUQIAN_COLOR     NVARCHAR(16),
  SCREEN_SHUZHONG_COLOR    NVARCHAR(16),
  SCREEN_PACU_COLOR        NVARCHAR(16),
  SCREEN_SHUHOU_COLOR      NVARCHAR(16),
  SCREEN_NEIRONG_COLOR     NVARCHAR(16),
  SCREEN_NEIRONGBACK_COLOR NVARCHAR(16),
  SCREEN_TEMPBACK_COLOR    NVARCHAR(16),
  SCREEN_TEMPFOR_COLOR     NVARCHAR(16),
  SCREEN_ZDBACK_COLOR      NVARCHAR(16),
  SCREEN_TEMPLATE_NO       NUMERIC(3),
  SCREEN_TEMPLATE_NAME     NVARCHAR(16) not null,
  constraint KEY_MED_SCREEN_TEMPLATE primary key (SCREEN_TEMPLATE_NAME)
)
-----------------------------123-------------------------
create table MED_SCREEN_CONFIG
(
  SCREEN_DEPT_CODE         NVARCHAR(16),
  SCREEN_FONT              NVARCHAR(100),
  SCREEN_TYPE              NUMERIC not null,
  SCREEN_MODE              NUMERIC,
  SCREEN_TIMER             NUMERIC,
  SCREEN_AUTOLOGION        NUMERIC,
  SCERRN_WIDTH             NUMERIC,
  SCREEN_HEIGHT            NUMERIC,
  SCREEN_COL_COLOR         NVARCHAR(16),
  SCREEN_BACK_COLOR        NVARCHAR(16),
  SCREEN_TITLE_COLOR       NVARCHAR(16),
  SCREEN_TIMEPAGE_COLOR    NVARCHAR(16),
  SCREEN_SHUQIAN_COLOR     NVARCHAR(16),
  SCREEN_SHUZHONG_COLOR    NVARCHAR(16),
  SCREEN_PACU_COLOR        NVARCHAR(16),
  SCREEN_SHUHOU_COLOR      NVARCHAR(16),
  SCREEN_TEMP_INFO         NVARCHAR(255),
  SCREEN_FONT_NEIRONG      NVARCHAR(100),
  SCREEN_NEIRONG_COLOR     NVARCHAR(16),
  SCREEN_TEMPBACK_COLOR    NVARCHAR(16),
  SCREEN_TEMPFOR_COLOR     NVARCHAR(16),
  SCREEN_NEIRONGBACK_COLOR NVARCHAR(16),
  SCREEN_ZDBACK_COLOR      NVARCHAR(16),
  SCREEN_TITLE             NVARCHAR(50),
  SCREEN_SORT              NVARCHAR(255),
  SCREEN_FIRSTLEFT         INT,
  constraint TYPEKEY primary key (SCREEN_TYPE)
)
------------------------124------------------------
create table MED_VS_HIS_DEP_ID
(
  MED_PATIENT_ID         NVARCHAR(20),
  MED_VISIT_ID           NUMERIC(2),
  MED_DEP_ID             NUMERIC(2),
  HIS_ADM_WARD_DATE_TIME DATETIME,
  HIS_PATIENT_ID         NVARCHAR(20),
  HIS_VISIT_ID           NVARCHAR(20),
  constraint PK_MED_VS_HIS_DEP_ID primary key (MED_PATIENT_ID, MED_VISIT_ID, MED_DEP_ID)
)
---------------------125-----------------------
create table MED_HIS_USERS_INFO
(
  [USER_ID]     NVARCHAR(36) not null,
  PROFESSIONAL_TITLE  NVARCHAR(20),
  SIGNATURE    IMAGE,
  MEMO  NVARCHAR(100),
  constraint PK_MED_HIS_USERS_INFO primary key ([USER_ID])
)
----------------------126--------------------------
create table MED_USERS_HISUSERS
(
  [USER_ID]     NVARCHAR(36) not null,
  HIS_USER_ID NVARCHAR(36) not null,
  MEMO        NVARCHAR(100),
  constraint PK_USERS_HISUSERS primary key ([USER_ID], HIS_USER_ID)
)
----------------------127---------------------------

