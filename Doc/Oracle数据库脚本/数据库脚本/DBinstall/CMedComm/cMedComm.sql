rem=================================================
rem     作    者：研发部
rem	修改时间：2008-07-11
rem     说    明：公共部分对象
rem=================================================

prompt
prompt Creating table MED_BLOOD_GAS_DETAIL
prompt ===================================
prompt
create table MED_BLOOD_GAS_DETAIL
(
  DETAIL_ID VARCHAR2(30) not null,
  BLG_CODE  VARCHAR2(60) not null,
  BLG_VALUE VARCHAR2(20),
  OPERATOR  VARCHAR2(20),
  OP_DATE   DATE,
  ABNORMAL_INDICATOR VARCHAR2(2)
)
;
alter table MED_BLOOD_GAS_DETAIL
  add constraint BLG_DETAIL_PKEY primary key (DETAIL_ID, BLG_CODE);
grant select, insert, update, delete on MED_BLOOD_GAS_DETAIL to ROLE_DOCARE;

prompt
prompt Creating table MED_BLOOD_GAS_DICT
prompt =================================
prompt
create table MED_BLOOD_GAS_DICT
(
  BLG_CODE        VARCHAR2(20) not null,
  BLG_NAME        VARCHAR2(60) not null,
  BLG_SHOWID      NUMBER not null,
  BLG_UNIT        VARCHAR2(20),
  BLG_REFER_VALUE VARCHAR2(40),
  BLG_STATUS      VARCHAR2(2) not null,
  BLG_INPUT_CODE  VARCHAR2(20),
  BLG_ATTR_CODE   VARCHAR2(100),
  BLG_ITEM_ID     NUMBER(4)
)
;
alter table MED_BLOOD_GAS_DICT
  add constraint BLD_PRIMARY_KEY primary key (BLG_CODE, BLG_SHOWID, BLG_STATUS);
grant select, insert, update, delete on MED_BLOOD_GAS_DICT to ROLE_DOCARE;

prompt
prompt Creating table MED_BLOOD_GAS_MASTER
prompt ===================================
prompt
create table MED_BLOOD_GAS_MASTER
(
  PATIENT_ID  		VARCHAR2(20) not null,
  VISIT_ID    		NUMBER(2) not null,
  RECORD_DATE 		DATE not null,
  NURSE_MEMO1 		VARCHAR2(600),
  NURSE_MEMO2 		VARCHAR2(600),
  DETAIL_ID   		VARCHAR2(30) not null,
  OPERATOR    		VARCHAR2(20),
  OP_DATE     		DATE,
  SPECIMEN    VARCHAR2(100),
  EQUIPMENT   VARCHAR2(100),
  OPER_ID     NUMBER(2)
)
;
alter table MED_BLOOD_GAS_MASTER
  add constraint BLOD_PRIMARY_KEY primary key (DETAIL_ID);
grant select, insert, update, delete on MED_BLOOD_GAS_MASTER to ROLE_DOCARE;

prompt
prompt Creating table MED_ADADMINSTER_MODE_DICT
prompt ========================================
prompt
create table MED_ADADMINSTER_MODE_DICT
(
  ADADMINSTER_NO        NUMBER(2) not null,
  ADADMINSTER_MODE_CODE VARCHAR2(1) not null,
  ADADMINSTER_MODE_NAME VARCHAR2(8),
  INPUT_CODE            VARCHAR2(8)
)
;

alter table MED_ADADMINSTER_MODE_DICT
  add constraint PK_MED_ADADMINSTER_MODE_DICT primary key (ADADMINSTER_NO, ADADMINSTER_MODE_CODE);
grant select, insert, update, delete on MED_ADADMINSTER_MODE_DICT to ROLE_DOCARE;

prompt
prompt Creating table MED_ADMINISTRATION_DICT
prompt ======================================
prompt
create table MED_ADMINISTRATION_DICT
(
  SERIAL_NO           NUMBER(3),
  ADMINISTRATION_CODE VARCHAR2(3),
  ADMINISTRATION_NAME VARCHAR2(30) not null,
  ADMINISTRATION_ABBR VARCHAR2(8),
  INPUT_CODE          VARCHAR2(16)
)
;

alter table MED_ADMINISTRATION_DICT
  add constraint PK_MED_ADMINISTRATION_DICT primary key (ADMINISTRATION_NAME);
grant select, insert, update, delete on MED_ADMINISTRATION_DICT to ROLE_DOCARE;

prompt
prompt Creating table MED_ADMINISTRATION_STAT_DICT
prompt ===========================================
prompt
create table MED_ADMINISTRATION_STAT_DICT
(
  SERIAL_NO      NUMBER(2),
  ITEM_NAME      VARCHAR2(8) not null,
  ADMINISTRATION VARCHAR2(30) not null
)
;

alter table MED_ADMINISTRATION_STAT_DICT
  add constraint PK_ADMINISTRATION_STAT_DICT primary key (ITEM_NAME, ADMINISTRATION);
grant select, insert, update, delete on MED_ADMINISTRATION_STAT_DICT to ROLE_DOCARE;

prompt
prompt Creating table MED_ADT_LOG
prompt ==========================
prompt
create table MED_ADT_LOG
(
  WARD_CODE     VARCHAR2(16) not null,
  DEPT_CODE     VARCHAR2(16),
  LOG_DATE_TIME DATE not null,
  PATIENT_ID    VARCHAR2(20) not null,
  VISIT_ID      NUMBER(2) not null,
  ACTION        VARCHAR2(1) not null
)
;

alter table MED_ADT_LOG
  add constraint PK_MED_ADT_LOG primary key (WARD_CODE, PATIENT_ID, VISIT_ID, LOG_DATE_TIME, ACTION);
create index IND_1_ADT_LOG on MED_ADT_LOG (DEPT_CODE);
create index IND_2_ADT_LOG on MED_ADT_LOG (PATIENT_ID);
grant select, insert, update, delete on MED_ADT_LOG to ROLE_DOCARE;

prompt
prompt Creating table MED_ANAESTHESIA_DICT
prompt ===================================
prompt
create table MED_ANAESTHESIA_DICT
(
  SERIAL_NO        NUMBER(2),
  ANAESTHESIA_CODE VARCHAR2(1),
  ANAESTHESIA_NAME VARCHAR2(40) not null,
  INPUT_CODE       VARCHAR2(8),
  ANAESTHESIA_TYPE VARCHAR2(16)
)
;

alter table MED_ANAESTHESIA_DICT
  add constraint PK_MED_ANAESTHESIA_DICT primary key (ANAESTHESIA_NAME);
grant select, insert, update, delete on MED_ANAESTHESIA_DICT to ROLE_DOCARE;

prompt
prompt Creating table MED_ANESTHETIC_CLASS_DICT
prompt ========================================
prompt
create table MED_ANESTHETIC_CLASS_DICT
(
  SERIAL_NO  NUMBER(2),
  CLASS_NAME VARCHAR2(20) not null,
  INPUT_CODE VARCHAR2(8)
)
;

alter table MED_ANESTHETIC_CLASS_DICT
  add constraint PK_MED_ANESTHETIC_CLASS_DICT primary key (CLASS_NAME);
grant select, insert, update, delete on MED_ANESTHETIC_CLASS_DICT to ROLE_DOCARE;

prompt
prompt Creating table MED_APPLICATIONS
prompt ===============================
prompt
create table MED_APPLICATIONS
(
  APP_ID      VARCHAR2(36) not null,
  NAME        VARCHAR2(60) not null,
  DESCRIPTION VARCHAR2(160)
)
;

alter table MED_APPLICATIONS
  add constraint KEY_MED_APPLICATIONS primary key (APP_ID);
alter table MED_APPLICATIONS
  add constraint UNIQUE_MED_APPLICATIONS unique (NAME);
grant select, insert, update, delete on MED_APPLICATIONS to ROLE_DOCARE;

create table MED_NURSING_CLASS_DICT
(
  SERIAL_NO          NUMBER(1),
  NURSING_CLASS_CODE VARCHAR2(1) not null,
  NURSING_CLASS_NAME VARCHAR2(8),
  INPUT_CODE         VARCHAR2(8)
);

alter table MED_NURSING_CLASS_DICT
  add constraint PK_MED_NURSING_CLASS_DICT primary key (NURSING_CLASS_CODE);
  
grant select, insert, update, delete on MED_NURSING_CLASS_DICT to ROLE_DOCARE;

create table MED_OCCUPATION_DICT
(
  SERIAL_NO       NUMBER(2),
  OCCUPATION_CODE VARCHAR2(1) not null,
  OCCUPATION_NAME VARCHAR2(20),
  INPUT_CODE      VARCHAR2(8)
);


alter table MED_OCCUPATION_DICT
  add constraint PK_MED_OCCUPATION_DICT primary key (OCCUPATION_CODE);

grant select, insert, update, delete on MED_OCCUPATION_DICT to ROLE_DOCARE;

prompt
prompt Creating table MED_PATIENT_STATUS_DICT
prompt ============================
prompt
create table MED_PATIENT_STATUS_DICT
(
  SERIAL_NO           NUMBER(1),
  PATIENT_STATUS_CODE VARCHAR2(1) not null,
  PATIENT_STATUS_NAME VARCHAR2(4),
  INPUT_CODE          VARCHAR2(8)
);

alter table MED_PATIENT_STATUS_DICT
  add constraint PK_MED_PATIENT_STATUS_DICT primary key (PATIENT_STATUS_CODE);

grant select, insert, update, delete on MED_PATIENT_STATUS_DICT to ROLE_DOCARE;


prompt
prompt Creating table MED_AREA_DICT
prompt ============================
prompt
create table MED_AREA_DICT
(
  SERIAL_NO  NUMBER(4),
  AREA_CODE  VARCHAR2(6) not null,
  AREA_NAME  VARCHAR2(34),
  INPUT_CODE VARCHAR2(8),
  ZIP_CODE   VARCHAR2(6)
)
;

alter table MED_AREA_DICT
  add constraint PK_MED_AREA_DICT primary key (AREA_CODE);
grant select, insert, update, delete on MED_AREA_DICT to ROLE_DOCARE;

prompt
prompt Creating table MED_BED_REC
prompt ==========================
prompt
create table MED_BED_REC
(
  WARD_CODE         VARCHAR2(16) not null,
  BED_NO            VARCHAR2(20) not null,
  BED_LABEL         VARCHAR2(20),
  ROOM_NO           VARCHAR2(20),
  DEPT_CODE         VARCHAR2(16),
  BED_APPROVED_TYPE VARCHAR2(1),
  BED_SEX_TYPE      VARCHAR2(1),
  BED_CLASS         VARCHAR2(2),
  BED_STATUS        VARCHAR2(1),
  ICU_INDICATOR     NUMBER(1),
  MONITOR_LABEL     VARCHAR2(20),
  SERIAL_NO         NUMBER(3)
)
;

alter table MED_BED_REC
  add constraint PK_MED_BED_REC primary key (WARD_CODE, BED_NO);
create index IND_1_BED_REC on MED_BED_REC (DEPT_CODE);
grant select, insert, update, delete on MED_BED_REC to ROLE_DOCARE;

prompt
prompt Creating table MED_BILL_ITEM_CLASS_DICT
prompt =======================================
prompt
create table MED_BILL_ITEM_CLASS_DICT
(
  SERIAL_NO  NUMBER(2),
  CLASS_CODE VARCHAR2(16) not null,
  CLASS_NAME VARCHAR2(60),
  INPUT_CODE VARCHAR2(8)
)
;

alter table MED_BILL_ITEM_CLASS_DICT
  add constraint PK_MED_BILL_ITEM_CLASS_DICT primary key (CLASS_CODE);
grant select, insert, update, delete on MED_BILL_ITEM_CLASS_DICT to ROLE_DOCARE;

prompt
prompt Creating table MED_BILL_ITEM_CLASS_VS_HIS
prompt =========================================
prompt
create table MED_BILL_ITEM_CLASS_VS_HIS
(
  CLASS_CODE  VARCHAR2(16) not null,
  CODE_IN_HIS VARCHAR2(32) not null
)
;

alter table MED_BILL_ITEM_CLASS_VS_HIS
  add constraint PK_MED_BILL_ITEM_CLASS_VS_HIS primary key (CLASS_CODE, CODE_IN_HIS);
grant select, insert, update, delete on MED_BILL_ITEM_CLASS_VS_HIS to ROLE_DOCARE;

prompt
prompt Creating table MED_CHARGE_PRICE_SCHEDULE
prompt ========================================
prompt
create table MED_CHARGE_PRICE_SCHEDULE
(
  CHARGE_TYPE              VARCHAR2(8) not null,
  PRICE_COEFF_NUMERATOR    NUMBER(3),
  PRICE_COEFF_DENOMINATOR  NUMBER(3),
  CHARGE_SPECIAL_INDICATOR NUMBER(1)
)
;

alter table MED_CHARGE_PRICE_SCHEDULE
  add constraint PK_MED_CHARGE_PRICE_SCHEDULE primary key (CHARGE_TYPE);
grant select, insert, update, delete on MED_CHARGE_PRICE_SCHEDULE to ROLE_DOCARE;

prompt
prompt Creating table MED_CHARGE_TYPE_DICT
prompt ===================================
prompt
create table MED_CHARGE_TYPE_DICT
(
  SERIAL_NO              NUMBER(3),
  CHARGE_TYPE_CODE       VARCHAR2(2),
  CHARGE_TYPE_NAME       VARCHAR2(30) not null,
  CHARGE_PRICE_INDICATOR NUMBER(1),
  INPUT_CODE             VARCHAR2(16)
)
;

alter table MED_CHARGE_TYPE_DICT
  add constraint PK_MED_CHARGE_TYPE_DICT primary key (CHARGE_TYPE_NAME);
grant select, insert, update, delete on MED_CHARGE_TYPE_DICT to ROLE_DOCARE;

prompt
prompt Creating table MED_CLINIC_ITEM_NAME_DICT
prompt ========================================
prompt
create table MED_CLINIC_ITEM_NAME_DICT
(
  ITEM_CLASS    VARCHAR2(16) not null,
  ITEM_NAME     VARCHAR2(60) not null,
  ITEM_CODE     VARCHAR2(10),
  STD_INDICATOR NUMBER(1),
  INPUT_CODE    VARCHAR2(8),
  INPUT_CODE_WB VARCHAR2(8),
  EXPAND1       VARCHAR2(8),
  EXPAND2       VARCHAR2(8),
  EXPAND3       VARCHAR2(8),
  EXPAND4       VARCHAR2(8),
  EXPAND5       VARCHAR2(8)
)
;

alter table MED_CLINIC_ITEM_NAME_DICT
  add constraint PK_MED_CLINIC_ITEM_NAME_DICT primary key (ITEM_CLASS, ITEM_NAME);
create index IND_CLINIC_ITEM_NAME_DICT_1 on MED_CLINIC_ITEM_NAME_DICT (ITEM_CLASS, ITEM_CODE);
create index IND_CLINIC_ITEM_NAME_DICT_2 on MED_CLINIC_ITEM_NAME_DICT (ITEM_NAME);
grant select, insert, update, delete on MED_CLINIC_ITEM_NAME_DICT to ROLE_DOCARE;

prompt
prompt Creating table MED_CLINIC_VS_CHARGE
prompt ===================================
prompt
create table MED_CLINIC_VS_CHARGE
(
  CLINIC_ITEM_CLASS VARCHAR2(1) not null,
  CLINIC_ITEM_CODE  VARCHAR2(10) not null,
  CHARGE_ITEM_NO    NUMBER(2) not null,
  CHARGE_ITEM_CLASS VARCHAR2(16),
  CHARGE_ITEM_CODE  VARCHAR2(10),
  CHARGE_ITEM_SPEC  VARCHAR2(20),
  AMOUNT            NUMBER(4),
  UNITS             VARCHAR2(12)
)
;

alter table MED_CLINIC_VS_CHARGE
  add constraint PK_MED_CLINIC_VS_CHARGE primary key (CLINIC_ITEM_CLASS, CLINIC_ITEM_CODE, CHARGE_ITEM_NO);
grant select, insert, update, delete on MED_CLINIC_VS_CHARGE to ROLE_DOCARE;

prompt
prompt Creating table MED_DEPT_DICT
prompt ============================
prompt
create table MED_DEPT_DICT
(
  SERIAL_NO  NUMBER(3),
  DEPT_CODE  VARCHAR2(16) not null,
  DEPT_NAME  VARCHAR2(40),
  INPUT_CODE VARCHAR2(8)
)
;

alter table MED_DEPT_DICT
  add constraint PK_MED_DEPT_DICT primary key (DEPT_CODE);
grant select, insert, update, delete on MED_DEPT_DICT to ROLE_DOCARE;

prompt
prompt Creating table MED_DEPT_EQUIP_DICT
prompt ==================================
prompt
create table MED_DEPT_EQUIP_DICT
(
  WARD_CODE VARCHAR2(8) not null,
  ITEM_NAME VARCHAR2(10) not null,
  MEMO      VARCHAR2(40)
)
;

alter table MED_DEPT_EQUIP_DICT
  add constraint PK_DEPT_EQUIP_DICT primary key (WARD_CODE, ITEM_NAME);
grant select, insert, update, delete on MED_DEPT_EQUIP_DICT to ROLE_DOCARE;

prompt
prompt Creating table MED_DEPT_VS_WARD
prompt ===============================
prompt
create table MED_DEPT_VS_WARD
(
  DEPT_CODE VARCHAR2(8) not null,
  WARD_CODE VARCHAR2(8)
)
;

alter table MED_DEPT_VS_WARD
  add constraint PK_MED_DEPT_VS_WARD primary key (DEPT_CODE);
create index IND_1_MED_DEPT_VS_WARD on MED_DEPT_VS_WARD (WARD_CODE);
grant select, insert, update, delete on MED_DEPT_VS_WARD to ROLE_DOCARE;

prompt
prompt Creating table MED_DIAGNOSIS_DICT
prompt =================================
prompt
create table MED_DIAGNOSIS_DICT
(
  DIAGNOSIS_CODE     VARCHAR2(16) not null,
  DIAGNOSIS_NAME     VARCHAR2(40),
  STD_INDICATOR      NUMBER(1),
  APPROVED_INDICATOR NUMBER(1),
  CREATE_DATE        DATE,
  INPUT_CODE         VARCHAR2(8),
  INFECT_INDICATOR   VARCHAR2(1),
  HEALTH_LEVEL       VARCHAR2(2),
  INPUT_CODE_WB      VARCHAR2(8),
  DISEASE_SORT       VARCHAR2(4),
  DIAG_INDICATOR     NUMBER(1)
)
;

alter table MED_DIAGNOSIS_DICT
  add constraint PK_DIAGNOSIS_DICT primary key (DIAGNOSIS_CODE);
grant select, insert, update, delete on MED_DIAGNOSIS_DICT to ROLE_DOCARE;

prompt
prompt Creating table MED_DOSAGE_UNITS_DICT
prompt ====================================
prompt
create table MED_DOSAGE_UNITS_DICT
(
  SERIAL_NO        NUMBER(3),
  DOSAGE_UNITS     VARCHAR2(8) not null,
  BASE_UNITS       VARCHAR2(8),
  CONVERSION_RATIO NUMBER(12,6),
  INPUT_CODE       VARCHAR2(8)
)
;

alter table MED_DOSAGE_UNITS_DICT
  add constraint PK_MED_DOSAGE_UNITS_DICT primary key (DOSAGE_UNITS);
grant select, insert, update, delete on MED_DOSAGE_UNITS_DICT to ROLE_DOCARE;

prompt
prompt Creating table MED_DRUG_CLASS_DICT
prompt ==================================
prompt
create table MED_DRUG_CLASS_DICT
(
  SERIAL_NO  NUMBER(2),
  CLASS_NAME VARCHAR2(10) not null,
  INPUT_CODE VARCHAR2(8)
)
;

alter table MED_DRUG_CLASS_DICT
  add constraint PK_MED_DRUG_CLASS_DICT primary key (CLASS_NAME);
grant select, insert, update, delete on MED_DRUG_CLASS_DICT to ROLE_DOCARE;

prompt
prompt Creating table MED_DRUG_DICT
prompt ============================
prompt
create table MED_DRUG_DICT
(
  DRUG_CODE        VARCHAR2(16) not null,
  DRUG_NAME        VARCHAR2(60) not null,
  DRUG_SPEC        VARCHAR2(20) not null,
  UNITS            VARCHAR2(8),
  DRUG_FORM        VARCHAR2(20),
  SUPPLIER_NAME    VARCHAR2(60),
  DOSE_PER_UNIT    NUMBER(8,3),
  DOSE_UNITS       VARCHAR2(8),
  DRUG_CLASS       VARCHAR2(10),
  ANESTHETIC_CLASS VARCHAR2(20),
  CODE_IN_HIS      VARCHAR2(16),
  INPUT_CODE       VARCHAR2(8)
)
;

alter table MED_DRUG_DICT
  add constraint PK_MED_DRUG_DICT primary key (DRUG_CODE, DRUG_SPEC);
grant select, insert, update, delete on MED_DRUG_DICT to ROLE_DOCARE;

prompt
prompt Creating table MED_DRUG_FORM_DICT
prompt =================================
prompt
create table MED_DRUG_FORM_DICT
(
  SERIAL_NO  NUMBER(2),
  FORM_NAME  VARCHAR2(20) not null,
  INPUT_CODE VARCHAR2(8)
)
;

alter table MED_DRUG_FORM_DICT
  add constraint PK_MED_DRUG_FORM_DICT primary key (FORM_NAME);
grant select, insert, update, delete on MED_DRUG_FORM_DICT to ROLE_DOCARE;

prompt
prompt Creating table MED_DRUG_NAME_DICT
prompt =================================
prompt
create table MED_DRUG_NAME_DICT
(
  DRUG_CODE     VARCHAR2(16) not null,
  DRUG_NAME     VARCHAR2(60) not null,
  STD_INDICATOR NUMBER(1),
  INPUT_CODE    VARCHAR2(8)
)
;

alter table MED_DRUG_NAME_DICT
  add constraint PK_MED_DRUG_NAME_DICT primary key (DRUG_CODE, DRUG_NAME);
grant select, insert, update, delete on MED_DRUG_NAME_DICT to ROLE_DOCARE;

prompt
prompt Creating table MED_DRUG_RETURN_CLASS_DICT
prompt =========================================
prompt
create table MED_DRUG_RETURN_CLASS_DICT
(
  SERIAL_NO    NUMBER(2),
  RETURN_CLASS VARCHAR2(8) not null
)
;

alter table MED_DRUG_RETURN_CLASS_DICT
  add constraint PK_MED_DRUG_RETURN_CLASS_DICT primary key (RETURN_CLASS);
grant select, insert, update, delete on MED_DRUG_RETURN_CLASS_DICT to ROLE_DOCARE;

prompt
prompt Creating table MED_EXAM_ITEMS
prompt =============================
prompt
create table MED_EXAM_ITEMS
(
  EXAM_NO        VARCHAR2(20) not null,
  EXAM_ITEM_NO   NUMBER(2) not null,
  EXAM_ITEM      VARCHAR2(80),
  EXAM_ITEM_CODE VARCHAR2(10),
  COSTS          NUMBER(8,2)
)
;

alter table MED_EXAM_ITEMS
  add constraint PK_EXAM_ITEMS primary key (EXAM_NO, EXAM_ITEM_NO);
grant select, insert, update, delete on MED_EXAM_ITEMS to ROLE_DOCARE;

prompt
prompt Creating table MED_EXAM_MASTER
prompt ==============================
prompt
create table MED_EXAM_MASTER
(
  EXAM_NO             VARCHAR2(20) not null,
  LOCAL_ID_CLASS      VARCHAR2(1),
  PATIENT_LOCAL_ID    VARCHAR2(20),
  PATIENT_ID          VARCHAR2(20),
  VISIT_ID            NUMBER(2),
  NAME                VARCHAR2(30),
  SEX                 VARCHAR2(4),
  DATE_OF_BIRTH       DATE,
  EXAM_CLASS          VARCHAR2(6),
  EXAM_SUB_CLASS      VARCHAR2(8),
  SPM_RECVED_DATE     DATE,
  CLIN_SYMP           VARCHAR2(400),
  PHYS_SIGN           VARCHAR2(400),
  RELEVANT_LAB_TEST   VARCHAR2(200),
  RELEVANT_DIAG       VARCHAR2(400),
  CLIN_DIAG           VARCHAR2(80),
  EXAM_MODE           VARCHAR2(1),
  EXAM_GROUP          VARCHAR2(16),
  DEVICE              VARCHAR2(20),
  PERFORMED_BY        VARCHAR2(16),
  PATIENT_SOURCE      VARCHAR2(1),
  FACILITY            VARCHAR2(20),
  REQ_DATE_TIME       DATE,
  REQ_DEPT            VARCHAR2(16),
  REQ_PHYSICIAN       VARCHAR2(30),
  REQ_MEMO            VARCHAR2(60),
  SCHEDULED_DATE_TIME DATE,
  NOTICE              VARCHAR2(400),
  EXAM_DATE_TIME      DATE,
  REPORT_DATE_TIME    DATE,
  TECHNICIAN          VARCHAR2(30),
  REPORTER            VARCHAR2(30),
  RESULT_STATUS       VARCHAR2(1),
  VERIFIED_BY         VARCHAR2(30),
  VERIFIED_DATE_TIME  DATE
)
;

alter table MED_EXAM_MASTER
  add constraint PK_MED_EXAM_MASTER primary key (EXAM_NO);
create index IND_1_EXAM_MASTER on MED_EXAM_MASTER (PATIENT_ID, VISIT_ID, EXAM_NO);
create index IND_2_EXAM_MASTER on MED_EXAM_MASTER (EXAM_DATE_TIME);
grant select, insert, update, delete on MED_EXAM_MASTER to ROLE_DOCARE;

prompt
prompt Creating table MED_EXAM_REPORT
prompt ==============================
prompt
create table MED_EXAM_REPORT
(
  EXAM_NO        VARCHAR2(20) not null,
  EXAM_PARA      VARCHAR2(1000),
  DESCRIPTION    VARCHAR2(2000),
  IMPRESSION     VARCHAR2(2000),
  RECOMMENDATION VARCHAR2(1000),
  IS_ABNORMAL    VARCHAR2(1),
  USE_IMAGE      VARCHAR2(15),
  STUDY_UID      VARCHAR2(128),
  MEMO           VARCHAR2(40)
)
;

alter table MED_EXAM_REPORT
  add constraint PK_EXAM_REPORT primary key (EXAM_NO);
grant select, insert, update, delete on MED_EXAM_REPORT to ROLE_DOCARE;

prompt
prompt Creating table MED_HIS_USERS
prompt ============================
prompt
create table MED_HIS_USERS
(
  USER_ID     VARCHAR2(36) not null,
  USER_NAME   VARCHAR2(30) not null,
  USER_DEPT   VARCHAR2(16),
  INPUT_CODE  VARCHAR2(8),
  USER_JOB    VARCHAR2(20),
  RESERVED01  VARCHAR2(50),
  CREATE_DATE DATE
)
;

alter table MED_HIS_USERS
  add constraint PK_MED_HIS_USERS primary key (USER_ID);
grant select, insert, update, delete on MED_HIS_USERS to ROLE_DOCARE;

prompt
prompt Creating table MED_HOSPITAL_CONFIG
prompt ==================================
prompt
create table MED_HOSPITAL_CONFIG
(
  HOSPITAL_ID      VARCHAR2(40) not null,
  HOSPITAL_NAME    VARCHAR2(80),
  AUTHORIZED_KEY   VARCHAR2(20),
  UNIT_CODE        VARCHAR2(11),
  LOCATION         VARCHAR2(6),
  MAILING_ADDRESS  VARCHAR2(80),
  ZIP_CODE         VARCHAR2(6),
  APPROVED_BED_NUM NUMBER(4),
  VERIFY_KEY       VARCHAR2(10),
  HOSPITAL_TYPE    NUMBER(1),
  HOSPITAL_CLASS   VARCHAR2(16)
)
;

alter table MED_HOSPITAL_CONFIG
  add constraint PK_MED_HOSPITAL_CONFIG primary key (HOSPITAL_ID);
grant select, insert, update, delete on MED_HOSPITAL_CONFIG to ROLE_DOCARE;

prompt
prompt Creating table MED_ICU_CONFIG
prompt =============================
prompt
create table MED_ICU_CONFIG
(
  CONFIG_ID          VARCHAR2(20) not null,
  AUDITING_CONDITION VARCHAR2(4000),
  DEPT               VARCHAR2(4000),
  ORDERS_IN_MOUNT    VARCHAR2(4000),
  SPECIAL_CARE       VARCHAR2(4000)
)
;

alter table MED_ICU_CONFIG
  add constraint PK_MED_ICU_CONFIG primary key (CONFIG_ID);
grant select, insert, update, delete on MED_ICU_CONFIG to ROLE_DOCARE;

prompt
prompt Creating table MED_IDENTITY_DICT
prompt ================================
prompt
create table MED_IDENTITY_DICT
(
  SERIAL_NO          NUMBER(2),
  IDENTITY_CODE      VARCHAR2(1),
  IDENTITY_NAME      VARCHAR2(10) not null,
  INPUT_CODE         VARCHAR2(8),
  PRIORITY_INDICATOR NUMBER(1),
  MILITARY_INDICATOR NUMBER(1),
  CHARGE_TYPE        VARCHAR2(1),
  INPUT_CODE_WB      VARCHAR2(8)
)
;

alter table MED_IDENTITY_DICT
  add constraint PK_MED_IDENTITY_DICT primary key (IDENTITY_NAME);
grant select, insert, update, delete on MED_IDENTITY_DICT to ROLE_DOCARE;

prompt
prompt Creating table MED_IF_RUN_CONFIG_DICT
prompt =====================================
prompt
create table MED_IF_RUN_CONFIG_DICT
(
  APP_CLASS VARCHAR2(16) not null,
  SECTION   VARCHAR2(20) not null,
  MAIN_KEY  VARCHAR2(20) not null,
  KEY_VALUE VARCHAR2(100),
  MEMO      VARCHAR2(500)
)
;

alter table MED_IF_RUN_CONFIG_DICT
  add constraint PK_MED_IF_RUN_CONFIG_DICT primary key (APP_CLASS, SECTION, MAIN_KEY);
grant select, insert, update, delete on MED_IF_RUN_CONFIG_DICT to ROLE_DOCARE;

prompt
prompt Creating table MED_IF_TRANS_DICT
prompt ================================
prompt
create table MED_IF_TRANS_DICT
(
  TRANS_NAME  VARCHAR2(20) not null,
  DBMS        VARCHAR2(40) not null,
  SERVER_NAME VARCHAR2(30),
  DATABASE    VARCHAR2(20),
  LOG_ID      VARCHAR2(20) not null,
  LOG_PASS    VARCHAR2(20) not null,
  NLS_LANG    VARCHAR2(40),
  DBPARM      VARCHAR2(80),
  MEMO        VARCHAR2(80)
)
;

alter table MED_IF_TRANS_DICT
  add constraint PK_MED_IF_TRANS_DICT primary key (TRANS_NAME);
grant select, insert, update, delete on MED_IF_TRANS_DICT to ROLE_DOCARE;

prompt
prompt Creating table MED_JOB_CLASS_DICT
prompt =================================
prompt
create table MED_JOB_CLASS_DICT
(
  SERIAL_NO      NUMBER(2),
  JOB_CLASS_CODE VARCHAR2(2),
  JOB_CLASS_NAME VARCHAR2(8) not null,
  INPUT_CODE     VARCHAR2(8)
)
;

alter table MED_JOB_CLASS_DICT
  add constraint PK_MED_JOB_CLASS_DICT primary key (JOB_CLASS_NAME);
grant select, insert, update, delete on MED_JOB_CLASS_DICT to ROLE_DOCARE;

prompt
prompt Creating table MED_LAB_REPORT_ITEM_DICT
prompt =======================================
prompt
create table MED_LAB_REPORT_ITEM_DICT
(
  SERIAL_NO      NUMBER(4),
  ITEM_CODE      VARCHAR2(10) not null,
  ITEM_NAME      VARCHAR2(40),
  RESULT_TYPE    VARCHAR2(8),
  LOWER_LIMIT    NUMBER(9,3),
  UPPER_LIMIT    NUMBER(9,3),
  UNITS          VARCHAR2(8),
  PRINT_CONTEXT  VARCHAR2(80),
  MINI_INCREMENT NUMBER(6,3),
  NOTES          VARCHAR2(40),
  DEFAULT_VALUE  VARCHAR2(20),
  INPUT_CODE     VARCHAR2(8)
)
;

alter table MED_LAB_REPORT_ITEM_DICT
  add constraint PK_MED_LAB_REPORT_ITEM_DICT primary key (ITEM_CODE);
grant select, insert, update, delete on MED_LAB_REPORT_ITEM_DICT to ROLE_DOCARE;

prompt
prompt Creating table MED_LAB_RESULT
prompt =============================
prompt
create table MED_LAB_RESULT
(
  TEST_NO            VARCHAR2(20) not null,
  ITEM_NO            NUMBER(10) not null,
  PRINT_ORDER        NUMBER(4) not null,
  REPORT_ITEM_NAME   VARCHAR2(80),
  REPORT_ITEM_CODE   VARCHAR2(10),
  RESULT             VARCHAR2(80),
  UNITS              VARCHAR2(20),
  ABNORMAL_INDICATOR VARCHAR2(1),
  INSTRUMENT_ID      VARCHAR2(8),
  RESULT_DATE_TIME   DATE,
  REFERENCE_RESULT   VARCHAR2(200)
)
;

alter table MED_LAB_RESULT
  add constraint PK_MED_LAB_RESULT primary key (TEST_NO, ITEM_NO, PRINT_ORDER);
grant select, insert, update, delete on MED_LAB_RESULT to ROLE_DOCARE;

prompt
prompt Creating table MED_LAB_TEST_ITEMS
prompt =================================
prompt
create table MED_LAB_TEST_ITEMS
(
  TEST_NO   VARCHAR2(20) not null,
  ITEM_NO   NUMBER(10) not null,
  ITEM_NAME VARCHAR2(80),
  ITEM_CODE VARCHAR2(10)
)
;

alter table MED_LAB_TEST_ITEMS
  add constraint PK_MED_LAB_TEST_ITEMS primary key (TEST_NO, ITEM_NO);
grant select, insert, update, delete on MED_LAB_TEST_ITEMS to ROLE_DOCARE;

prompt
prompt Creating table MED_LAB_TEST_MASTER
prompt ==================================
prompt
create table MED_LAB_TEST_MASTER
(
  TEST_NO                 VARCHAR2(20) not null,
  PRIORITY_INDICATOR      NUMBER(1),
  PATIENT_ID              VARCHAR2(20),
  VISIT_ID                NUMBER(2),
  WORKING_ID              VARCHAR2(20),
  EXECUTE_DATE            DATE,
  NAME                    VARCHAR2(30),
  NAME_PHONETIC           VARCHAR2(16),
  CHARGE_TYPE             VARCHAR2(30),
  SEX                     VARCHAR2(4),
  AGE                     NUMBER(3),
  TEST_CAUSE              VARCHAR2(500),
  RELEVANT_CLINIC_DIAG    VARCHAR2(200),
  SPECIMEN                VARCHAR2(100),
  NOTES_FOR_SPCM          VARCHAR2(16),
  SPCM_RECEIVED_DATE_TIME DATE,
  SPCM_SAMPLE_DATE_TIME   DATE,
  REQUESTED_DATE_TIME     DATE,
  ORDERING_DEPT           VARCHAR2(16),
  ORDERING_PROVIDER       VARCHAR2(30),
  PERFORMED_BY            VARCHAR2(16),
  RESULT_STATUS           VARCHAR2(1),
  RESULTS_RPT_DATE_TIME   DATE,
  TRANSCRIPTIONIST        VARCHAR2(30),
  VERIFIED_BY             VARCHAR2(8),
  COSTS                   NUMBER(8,2),
  CHARGES                 NUMBER(8,2),
  BILLING_INDICATOR       NUMBER(1),
  PRINT_INDICATOR         NUMBER(1),
  SUBJECT                 VARCHAR2(40),
  BARCODE                 VARCHAR2(10)
)
;

alter table MED_LAB_TEST_MASTER
  add constraint PK_MED_LAB_TEST_MASTER primary key (TEST_NO);
create index IND_1_LAB_TEST_MASTER on MED_LAB_TEST_MASTER (PATIENT_ID);
grant select, insert, update, delete on MED_LAB_TEST_MASTER to ROLE_DOCARE;

prompt
prompt Creating table MED_MEASURES_DICT
prompt ================================
prompt
create table MED_MEASURES_DICT
(
  SERIAL_NO        NUMBER(2),
  MEASURES_CLASS   VARCHAR2(10) not null,
  MEASURES_CODE    VARCHAR2(3),
  MEASURES_NAME    VARCHAR2(8) not null,
  BASE_UNITS       VARCHAR2(8),
  CONVERSION_RATIO NUMBER(12,6),
  INPUT_CODE       VARCHAR2(8)
)
;

alter table MED_MEASURES_DICT
  add constraint PK_MED_MEASURES_DICT primary key (MEASURES_CLASS, MEASURES_NAME);
grant select, insert, update, delete on MED_MEASURES_DICT to ROLE_DOCARE;

prompt
prompt Creating table MED_MONITOR_DATA_VALUES_DICT
prompt ===========================================
prompt
create table MED_MONITOR_DATA_VALUES_DICT
(
  MONITOR_DATA_NAME  VARCHAR2(40) not null,
  MONITOR_DATA_ALIAS VARCHAR2(8),
  MONITOR_DATA_VALUE VARCHAR2(40) not null,
  PRINT_VALUE        VARCHAR2(40),
  INPUT_CODE         VARCHAR2(8),
  CONTENT_ID         VARCHAR2(2)
)
;

alter table MED_MONITOR_DATA_VALUES_DICT
  add constraint PK_MED_MONITOR_VALUES_DICT primary key (MONITOR_DATA_NAME, MONITOR_DATA_VALUE);
grant select, insert, update, delete on MED_MONITOR_DATA_VALUES_DICT to ROLE_DOCARE;

prompt
prompt Creating table MED_MONITOR_DICT
prompt ===============================
prompt
create table MED_MONITOR_DICT
(
  MONITOR_LABEL             VARCHAR2(20) not null,
  MANU_FIRM_NAME            VARCHAR2(40),
  MODEL                     VARCHAR2(40),
  INTERFACE_TYPE            NUMBER(1),
  INTERFACE_DESC            VARCHAR2(20),
  IP_ADDR                   VARCHAR2(15),
  MAC_ADDR                  VARCHAR2(12),
  LAST_RECV_TIME            DATE,
  LAST_RECV_BED_ID          VARCHAR2(5),
  DUPLEX_FLAG               NUMBER(5),
  AUTOIN_FLAG               VARCHAR2(1),
  COMM_PORT                 VARCHAR2(6),
  BAUD_RATE                 NUMBER(5),
  BYTE_SIZE                 NUMBER(5),
  PARITY                    NUMBER(5),
  STOP_BITS                 NUMBER(5),
  F_OUTX                    NUMBER(5),
  F_INX                     NUMBER(5),
  F_HARDWARE                NUMBER(5),
  TX_QUEUESIZE              NUMBER(5),
  RX_QUEUESIZE              NUMBER(5),
  XON_LIM                   NUMBER(5),
  XOFF_LIM                  NUMBER(5),
  XON_CHAR                  VARCHAR2(1),
  XOFF_CHAR                 VARCHAR2(1),
  ERROR_CHAR                VARCHAR2(1),
  EVENT_CHAR                VARCHAR2(1),
  DRIVER_PROG               VARCHAR2(128),
  PRIORITY                  NUMBER(5),
  ITEM_TYPE                 VARCHAR2(1),
  AUTO_LOAD                 NUMBER(5),
  START_DATE_TIME           DATE,
  DEFAULT_RECV_FREQUENCY    NUMBER(5),
  CURRENT_RECV_FREQUENCY    NUMBER(5),
  CURRENT_RECVTIMES_UPLIMIT NUMBER(5),
  CURRENT_RECV_ITEMS        VARCHAR2(200),
  WARD_CODE                 VARCHAR2(8),
  WARD_TYPE                 NUMBER(2),
  BED_NO                    VARCHAR2(20),
  PATIENT_ID                VARCHAR2(20),
  VISIT_ID                  NUMBER(2),
  OPER_ID                   NUMBER(2),
  USING_INDICATOR           NUMBER(1),
  FREQUENCY_DISPLAY         NUMBER(5),
  MEMO                      VARCHAR2(100),
  DATALOG_START_TIME        DATE,
  PC_PORT                   NUMBER(5),
  DATALOG_STATUS            VARCHAR2(4),
  IP_PORT                   NUMBER(5),
  IN_PORT                   NUMBER(5),
  OUT_PORT                  NUMBER(5)
)
;

alter table MED_MONITOR_DICT
  add constraint PK_MED_MONITOR_DICT primary key (MONITOR_LABEL);
grant select, insert, update, delete on MED_MONITOR_DICT to ROLE_DOCARE;

prompt
prompt Creating table MED_MONITOR_FUNCTION_CODE
prompt ========================================
prompt
create table MED_MONITOR_FUNCTION_CODE
(
  ITEM_ID         NUMBER(5),
  ITEM_NAME       VARCHAR2(40),
  ITEM_CODE       VARCHAR2(6) not null,
  ITEM_UNIT       VARCHAR2(8),
  DIS_COLOR       NUMBER(8),
  PARM_CLASS      VARCHAR2(1),
  DRAW_ICON       VARCHAR2(2),
  USE_FLAG        VARCHAR2(1),
  PRIORITY_INDI   NUMBER(1),
  MEMO            VARCHAR2(24),
  INPUT_CODE      VARCHAR2(8),
  NAME_IN_ICU     VARCHAR2(16),
  WARD_CODE       VARCHAR2(8),
  WARD_TYPE       NUMBER(2),
  ITEM_NAME_ALIAS VARCHAR2(8),
  VALUE_TYPE      NUMBER(1),
  EXAM_METHOD     NUMBER(1),
  IN_OR_OUT       NUMBER(1),
  ITEM_TYPE       NUMBER(1),
  CALC_SUM        NUMBER(1),
  PRINT_ITEM_NO   NUMBER(2),
  DRAW_STYLE      NUMBER(1) default 1,
  DRAW_ISVALID		NUMBER(1) default 1,
  SHOW_SUB_CODE   VARCHAR2(10),
  DATA_TABLE_CODE VARCHAR2(100)
)
;

alter table MED_MONITOR_FUNCTION_CODE
  add constraint PK_MED_MONITOR_FUNCTION_CODE primary key (ITEM_CODE);
grant select, insert, update, delete on MED_MONITOR_FUNCTION_CODE to ROLE_DOCARE;

prompt
prompt Creating table MED_ICU_SHOW_DICT
prompt ========================================
prompt
create table MED_ICU_SHOW_DICT
(
  SHOW_NO             NUMBER(3),
  SHOW_CODE           VARCHAR2(10) not null,
  SHOW_NAME           VARCHAR2(30),
  SHOW_ITEM_NO        NUMBER(2,0),
  SHOW_STATE          NUMBER(2)
)
;
alter table MED_ICU_SHOW_DICT
  add constraint PK_MED_ICU_SHOW_DICT primary key (SHOW_CODE);
grant select, insert, update, delete on MED_ICU_SHOW_DICT to ROLE_DOCARE;

prompt
prompt Creating table MED_ICU_SHOW_SUB_DICT
prompt ========================================
prompt
create table MED_ICU_SHOW_SUB_DICT
(
  SHOW_SUB_NO                 NUMBER(3),
  SHOW_CODE 						VARCHAR2(10),
  SHOW_SUB_CODE 					VARCHAR2(10) not null,
  SHOW_SUB_NAME 					VARCHAR2(30),
  IN_OR_OUT							NUMBER(1),
  SHOW_SUB_ITEM_NO        		NUMBER(4,0)
)
;
alter table MED_ICU_SHOW_SUB_DICT
  add constraint PK_MED_ICU_SHOW_SUB_DICT primary key (SHOW_SUB_CODE);
grant select, insert, update, delete on MED_ICU_SHOW_SUB_DICT to ROLE_DOCARE;

prompt
prompt Creating table MED_ICU_VALUE_TYPE_DICT
prompt ========================================
prompt
create table MED_ICU_VALUE_TYPE_DICT
(
  SHOW_NO     NUMBER(3),
  VALUE_TYPE      NUMBER(1) not null,
  VALUE_NAME 	VARCHAR2(20),
  VALUE_MEMO	VARCHAR2(100)
)
;
alter table MED_ICU_VALUE_TYPE_DICT
  add constraint PK_MED_ICU_VALUE_TYPE_DICT primary key (VALUE_TYPE);
grant select, insert, update, delete on MED_ICU_VALUE_TYPE_DICT to ROLE_DOCARE;

prompt
prompt Creating table MED_DATA_TABLE_CODE_DICT
prompt ========================================
prompt
create table MED_DATA_TABLE_CODE_DICT
(
  SHOW_NO			NUMBER(3),
  TABLE_CODE		VARCHAR2(20) not null,
  TABLE_VALUE 		VARCHAR2(50),
  SHOW_NAME		VARCHAR2(100)
)
;
alter table MED_DATA_TABLE_CODE_DICT
  add constraint PK_MED_DATA_TABLE_CODE_DICT primary key (TABLE_CODE);
grant select, insert, update, delete on MED_DATA_TABLE_CODE_DICT to ROLE_DOCARE;

prompt
prompt Creating table MED_MONITOR_SPECIAL_CODE
prompt ========================================
prompt
create table MED_MONITOR_SPECIAL_CODE
(
  ITEM_ID         NUMBER(5),
  ITEM_NAME       VARCHAR2(40),
  ITEM_CODE       VARCHAR2(6) not null,
  ITEM_UNIT       VARCHAR2(8),
  DIS_COLOR       NUMBER(8),
  PARM_CLASS      VARCHAR2(1),
  DRAW_ICON       VARCHAR2(2),
  USE_FLAG        VARCHAR2(1),
  PRIORITY_INDI   NUMBER(1),
  MEMO            VARCHAR2(24),
  INPUT_CODE      VARCHAR2(8),
  NAME_IN_ICU     VARCHAR2(16),
  WARD_CODE       VARCHAR2(8),
  WARD_TYPE       NUMBER(2),
  ITEM_NAME_ALIAS VARCHAR2(8),
  VALUE_TYPE      NUMBER(1),
  EXAM_METHOD     NUMBER(1),
  IN_OR_OUT       NUMBER(1),
  ITEM_TYPE       NUMBER(1),
  CALC_SUM        NUMBER(1),
  PRINT_ITEM_NO   NUMBER(2),
  DRAW_STYLE      NUMBER(1) default 1,
  DRAW_ISVALID    NUMBER(1) default 1,
  SHOW_SUB_CODE   VARCHAR2(10),
  DATA_TABLE_CODE VARCHAR2(100)
)
;
alter table MED_MONITOR_SPECIAL_CODE
  add constraint PK_MED_MONITOR_SPECIAL_CODE primary key (ITEM_CODE);
grant select, insert, update, delete on MED_MONITOR_SPECIAL_CODE to ROLE_DOCARE;

prompt
prompt Creating table MED_MR_FILE_INDEX
prompt ================================
prompt
create table MED_MR_FILE_INDEX
(
  PATIENT_ID            VARCHAR2(20) not null,
  VISIT_ID              NUMBER(2) not null,
  FILE_NO               NUMBER(2) not null,
  FILE_NAME             VARCHAR2(16),
  TOPIC                 VARCHAR2(40),
  CREATOR_NAME          VARCHAR2(30),
  CREATOR_ID            VARCHAR2(16),
  CREATE_DATE_TIME      DATE,
  LAST_MODIFY_DATE_TIME DATE,
  FILE_FLAG             VARCHAR2(4),
  FILE_ATTR             VARCHAR2(4)
)
;

alter table MED_MR_FILE_INDEX
  add constraint PK_MED_MR_FILE_INDEX primary key (PATIENT_ID, VISIT_ID, FILE_NO);
grant select, insert, update, delete on MED_MR_FILE_INDEX to ROLE_DOCARE;

prompt
prompt Creating table MED_MR_INDEX
prompt ===========================
prompt
create table MED_MR_INDEX
(
  PATIENT_ID            VARCHAR2(20) not null,
  VISIT_ID              NUMBER(2) not null,
  MR_STATUS             VARCHAR2(1),
  STORAGE_VOLUME_LABEL  VARCHAR2(32),
  ACCESS_PATH           VARCHAR2(40),
  LAST_ACCESS_DATE_TIME DATE
)
;

alter table MED_MR_INDEX
  add constraint PK_MED_MR_INDEX primary key (PATIENT_ID, VISIT_ID);
grant select, insert, update, delete on MED_MR_INDEX to ROLE_DOCARE;

prompt
prompt Creating table MED_MR_WORK_PATH
prompt ===============================
prompt
create table MED_MR_WORK_PATH
(
  MR_PATH      VARCHAR2(40) not null,
  TEMPLET_PATH VARCHAR2(40),
  FILE_USER    VARCHAR2(16),
  FILE_PWD     VARCHAR2(16),
  IP_ADDR      VARCHAR2(64)
)
;

alter table MED_MR_WORK_PATH
  add constraint PK_MED_MR_WORK_PATH primary key (MR_PATH);
grant select, insert, update, delete on MED_MR_WORK_PATH to ROLE_DOCARE;

prompt
prompt Creating table MED_MTRL_CLASS_DICT
prompt ==================================
prompt
create table MED_MTRL_CLASS_DICT
(
  SERIAL_NO  NUMBER(2),
  CLASS_NAME VARCHAR2(10) not null,
  INPUT_CODE VARCHAR2(8)
)
;

alter table MED_MTRL_CLASS_DICT
  add constraint PK_MED_MTRL_CLASS_DICT primary key (CLASS_NAME);
grant select, insert, update, delete on MED_MTRL_CLASS_DICT to ROLE_DOCARE;

prompt
prompt Creating table MED_MTRL_DICT
prompt ============================
prompt
create table MED_MTRL_DICT
(
  MTRL_CODE   VARCHAR2(16) not null,
  MTRL_NAME   VARCHAR2(60) not null,
  MTRL_SPEC   VARCHAR2(20) not null,
  UNITS       VARCHAR2(8),
  MTRL_CLASS  VARCHAR2(10),
  CODE_IN_HIS VARCHAR2(16),
  INPUT_CODE  VARCHAR2(8)
)
;

alter table MED_MTRL_DICT
  add constraint PK_MED_MTRL_DICT primary key (MTRL_CODE, MTRL_SPEC);
grant select, insert, update, delete on MED_MTRL_DICT to ROLE_DOCARE;

prompt
prompt Creating table MED_MTRL_EXPORT_CLASS_DICT
prompt =========================================
prompt
create table MED_MTRL_EXPORT_CLASS_DICT
(
  SERIAL_NO    NUMBER(2),
  EXPORT_CLASS VARCHAR2(8) not null
)
;

alter table MED_MTRL_EXPORT_CLASS_DICT
  add constraint PK_MED_MTRL_EXPORT_CLASS_DICT primary key (EXPORT_CLASS);
grant select, insert, update, delete on MED_MTRL_EXPORT_CLASS_DICT to ROLE_DOCARE;

prompt
prompt Creating table MED_MTRL_IMPORT_CLASS_DICT
prompt =========================================
prompt
create table MED_MTRL_IMPORT_CLASS_DICT
(
  SERIAL_NO    NUMBER(2),
  IMPORT_CLASS VARCHAR2(8) not null
)
;

alter table MED_MTRL_IMPORT_CLASS_DICT
  add constraint PK_MED_MTRL_IMPORT_CLASS_DICT primary key (IMPORT_CLASS);
grant select, insert, update, delete on MED_MTRL_IMPORT_CLASS_DICT to ROLE_DOCARE;

prompt
prompt Creating table MED_MTRL_NAME_DICT
prompt =================================
prompt
create table MED_MTRL_NAME_DICT
(
  MTRL_CODE     VARCHAR2(16) not null,
  MTRL_NAME     VARCHAR2(60) not null,
  STD_INDICATOR NUMBER(1),
  INPUT_CODE    VARCHAR2(8)
)
;

alter table MED_MTRL_NAME_DICT
  add constraint PK_MED_MTRL_NAME_DICT primary key (MTRL_CODE, MTRL_NAME);
grant select, insert, update, delete on MED_MTRL_NAME_DICT to ROLE_DOCARE;

prompt
prompt Creating table MED_MTRL_SUPPLIER_CATALOG
prompt ========================================
prompt
create table MED_MTRL_SUPPLIER_CATALOG
(
  SUPPLIER_ID    VARCHAR2(16) not null,
  SUPPLIER       VARCHAR2(60) not null,
  SUPPLIER_CLASS VARCHAR2(8),
  CODE_IN_HIS    VARCHAR2(16),
  INPUT_CODE     VARCHAR2(8)
)
;

alter table MED_MTRL_SUPPLIER_CATALOG
  add constraint PK_MED_MTRL_SUPPLIER_CATALOG primary key (SUPPLIER_ID);
grant select, insert, update, delete on MED_MTRL_SUPPLIER_CATALOG to ROLE_DOCARE;

prompt
prompt Creating table MED_NURSE_TEMPLETE
prompt =================================
prompt
create table MED_NURSE_TEMPLETE
(
  WARD_CODE     VARCHAR2(8) not null,
  TEMPLETE_CODE VARCHAR2(10),
  TEMPLETE_NAME VARCHAR2(40) not null,
  TEMPLETE_DESC VARCHAR2(1000),
  INPUT_CODE    VARCHAR2(8)
)
;

alter table MED_NURSE_TEMPLETE
  add constraint PK_NURSE_TEMPLETE primary key (WARD_CODE, TEMPLETE_NAME);
grant select, insert, update, delete on MED_NURSE_TEMPLETE to ROLE_DOCARE;

prompt
prompt Creating table MED_NURSING_SCHEDULE_DICT
prompt ========================================
prompt
create table MED_NURSING_SCHEDULE_DICT
(
  SERIAL_NO     NUMBER(2),
  WARD_CODE     VARCHAR2(8) not null,
  SCHEDULE_NAME VARCHAR2(8) not null,
  START_TIME    VARCHAR2(5),
  END_TIME      VARCHAR2(5)
)
;

alter table MED_NURSING_SCHEDULE_DICT
  add constraint PK_MED_NURSING_SCHEDULE_DICT primary key (WARD_CODE, SCHEDULE_NAME);
grant select, insert, update, delete on MED_NURSING_SCHEDULE_DICT to ROLE_DOCARE;

prompt
prompt Creating table MED_OPERATION_DICT
prompt =================================
prompt
create table MED_OPERATION_DICT
(
  OPERATION_CODE     VARCHAR2(16),
  OPERATION_NAME     VARCHAR2(60) not null,
  OPERATION_SCALE    VARCHAR2(2),
  STD_INDICATOR      NUMBER(1),
  APPROVED_INDICATOR NUMBER(1),
  CREATE_DATE        DATE,
  INPUT_CODE         VARCHAR2(8),
  INPUT_CODE_WB      VARCHAR2(8)
)
;

alter table MED_OPERATION_DICT
  add constraint PK_MED_OPERATION_DICT primary key (OPERATION_NAME);
create index IND_1_MED_OPERATION_DICT on MED_OPERATION_DICT (OPERATION_CODE);
grant select, insert, update, delete on MED_OPERATION_DICT to ROLE_DOCARE;

prompt
prompt Creating table MED_OPERATION_SCALE_DICT
prompt =======================================
prompt
create table MED_OPERATION_SCALE_DICT
(
  SERIAL_NO            NUMBER(1),
  OPERATION_SCALE_CODE VARCHAR2(1) not null,
  OPERATION_SCALE_NAME VARCHAR2(2),
  INPUT_CODE           VARCHAR2(8)
)
;

alter table MED_OPERATION_SCALE_DICT
  add constraint PK_MED_OPERATION_SCALE_DICT primary key (OPERATION_SCALE_CODE);
grant select, insert, update on MED_OPERATION_SCALE_DICT to ROLE_DOCARE;

prompt
prompt Creating table MED_ORDERS
prompt =========================
prompt
create table MED_ORDERS
(
  PATIENT_ID             VARCHAR2(20) not null,
  VISIT_ID               NUMBER(2) not null,
  ORDER_NO               VARCHAR2(20) not null,
  ORDER_SUB_NO           NUMBER(20) not null,
  REPEAT_INDICATOR       NUMBER(1),
  ORDER_CLASS            VARCHAR2(1),
  ORDER_TEXT             VARCHAR2(200),
  ORDER_CODE             VARCHAR2(20),
  DOSAGE                 NUMBER(14,4),
  DOSAGE_UNITS           VARCHAR2(8),
  ADMINISTRATION         VARCHAR2(30),
  START_DATE_TIME        DATE,
  STOP_DATE_TIME         DATE,
  DURATION               NUMBER(8),
  DURATION_UNITS         VARCHAR2(8),
  FREQUENCY              VARCHAR2(30),
  FREQ_COUNTER           NUMBER(8),
  FREQ_INTERVAL          NUMBER(8),
  FREQ_INTERVAL_UNIT     VARCHAR2(8),
  FREQ_DETAIL            VARCHAR2(30),
  PERFORM_SCHEDULE       VARCHAR2(60),
  PERFORM_RESULT         VARCHAR2(20),
  ORDERING_DEPT          VARCHAR2(16),
  DOCTOR                 VARCHAR2(30),
  STOP_DOCTOR            VARCHAR2(30),
  NURSE                  VARCHAR2(30),
  STOP_NURSE             VARCHAR2(30),
  ENTER_DATE_TIME        DATE,
  STOP_ORDER_DATE_TIME   DATE,
  ORDER_STATUS           VARCHAR2(1),
  BILLING_ATTR           NUMBER(1),
  LAST_PERFORM_DATE_TIME DATE,
  LAST_ACCTING_DATE_TIME DATE,
  DRUG_BILLING_ATTR      NUMBER(1),
  TREAT_SHEET_FLAG       VARCHAR2(1),
  PHAM_STD_CODE          VARCHAR2(14),
  AMOUNT                 NUMBER(3),
  RESERVED1              VARCHAR2(10),
  DISPENSE_MEMOS         VARCHAR2(20),
  CURRENT_PRESC_NO       NUMBER(6),
  DRUG_SPEC              VARCHAR2(40),
  QTY                    NUMBER(10,2)
)
;
alter table MED_ORDERS
  add constraint PK_MED_ORDERS primary key (PATIENT_ID, VISIT_ID, ORDER_NO, ORDER_SUB_NO);
grant select, insert, update, delete on MED_ORDERS to ROLE_DOCARE;

prompt
prompt Creating table MED_ORDER_ATTR_DICT
prompt ==================================
prompt
create table MED_ORDER_ATTR_DICT
(
  VITAL_SIGNS       VARCHAR2(100) not null,
  ORDER_ATTR        VARCHAR2(8),
  UNIT_WEIGHT_MOUNT VARCHAR2(20)
)
;
alter table MED_ORDER_ATTR_DICT
  add constraint PK_MED_ORDER_ATTR_DICT primary key (VITAL_SIGNS);
grant select, insert, update, delete on MED_ORDER_ATTR_DICT to ROLE_DOCARE;

prompt
prompt Creating table MED_ORDER_CLASS_DICT
prompt ===================================
prompt
create table MED_ORDER_CLASS_DICT
(
  SERIAL_NO        NUMBER(2),
  ORDER_CLASS_CODE VARCHAR2(1) not null,
  ORDER_CLASS_NAME VARCHAR2(8),
  INPUT_CODE       VARCHAR2(8)
)
;
alter table MED_ORDER_CLASS_DICT
  add constraint PK_MED_ORDER_CLASS_DICT primary key (ORDER_CLASS_CODE);
grant select, insert, update, delete on MED_ORDER_CLASS_DICT to ROLE_DOCARE;

prompt
prompt Creating table MED_ORDER_STATUS_DICT
prompt ====================================
prompt
create table MED_ORDER_STATUS_DICT
(
  SERIAL_NO         NUMBER(1),
  ORDER_STATUS_CODE VARCHAR2(1) not null,
  ORDER_STATUS_NAME VARCHAR2(8),
  INPUT_CODE        VARCHAR2(8)
)
;
alter table MED_ORDER_STATUS_DICT
  add constraint PK_MED_ORDER_STATUS_DICT primary key (ORDER_STATUS_CODE);
grant select, insert, update, delete on MED_ORDER_STATUS_DICT to ROLE_DOCARE;

prompt
prompt Creating table MED_OUTER_APP_USE
prompt ================================
prompt
create table MED_OUTER_APP_USE
(
  APPLICATION    VARCHAR2(16) not null,
  DICT_FILE_NAME VARCHAR2(16) not null
)
;
alter table MED_OUTER_APP_USE
  add constraint PK_MED_OUTER_APP_USE primary key (APPLICATION, DICT_FILE_NAME);
grant select, insert, update, delete on MED_OUTER_APP_USE to ROLE_DOCARE;

prompt
prompt Creating table MED_OUTER_CODING_CONFIG
prompt ======================================
prompt
create table MED_OUTER_CODING_CONFIG
(
  TOPIC               VARCHAR2(8) not null,
  ITEM_CLASS          VARCHAR2(4),
  CODING_SCHM         VARCHAR2(4) not null,
  OUTER_CODE_LENGTH   NUMBER(2),
  TEXT_LENGTH         NUMBER(3),
  STD_CODE_LENGTH     NUMBER(2),
  DICT_FILE_NAME      VARCHAR2(16),
  LAST_UPDT_DATE_TIME DATE
)
;
alter table MED_OUTER_CODING_CONFIG
  add constraint PK_MED_OUTER_CODING_CONFIG primary key (TOPIC, CODING_SCHM);
grant select, insert, update, delete on MED_OUTER_CODING_CONFIG to ROLE_DOCARE;

prompt
prompt Creating table MED_OUTER_GENERATION
prompt ===================================
prompt
create table MED_OUTER_GENERATION
(
  DICT_FILE_NAME   VARCHAR2(16) not null,
  DATA_TABLE_NAME  VARCHAR2(32) not null,
  DATA_INPUT_FIELD VARCHAR2(32) not null,
  DATA_CODE_FIELD  VARCHAR2(32) not null,
  DATA_NAME_FIELD  VARCHAR2(32) not null,
  DATA_FILTER      VARCHAR2(128),
  UPDT_METHOD      NUMBER(3),
  DICT_TXT_FILE    LONG RAW,
  INPUT_CODE_WB    VARCHAR2(32)
)
;
alter table MED_OUTER_GENERATION
  add constraint PK_MED_OUTER_GENERATION primary key (DICT_FILE_NAME);
grant select, insert, update, delete on MED_OUTER_GENERATION to ROLE_DOCARE;

prompt
prompt Creating table MED_PATIENT_FORM_DATA_DICT
prompt =========================================
prompt
create table MED_PATIENT_FORM_DATA_DICT
(
  PATIENT_ID VARCHAR2(20) not null,
  VISIT_ID   NUMBER(2) not null,
  ITEM_NO    NUMBER(2),
  ITEM_NAME  VARCHAR2(20) not null,
  ITEM_UNIT  VARCHAR2(10)
)
;
alter table MED_PATIENT_FORM_DATA_DICT
  add constraint PK_PATIENT_FORM_DATA_DICT primary key (PATIENT_ID, VISIT_ID, ITEM_NAME);
grant select, insert, update, delete on MED_PATIENT_FORM_DATA_DICT to ROLE_DOCARE;

prompt
prompt Creating table MED_PATIENT_STATUS_CHG_DICT
prompt ==========================================
prompt
create table MED_PATIENT_STATUS_CHG_DICT
(
  SERIAL_NO               NUMBER(2),
  PATIENT_STATUS_CHG_CODE VARCHAR2(4) not null,
  PATIENT_STATUS_CHG_NAME VARCHAR2(10),
  INPUT_CODE              VARCHAR2(8)
)
;
alter table MED_PATIENT_STATUS_CHG_DICT
  add constraint PK_MED_PATIENT_STATUS_CHG_DICT primary key (PATIENT_STATUS_CHG_CODE);
grant select, insert, update, delete on MED_PATIENT_STATUS_CHG_DICT to ROLE_DOCARE;

prompt
prompt Creating table MED_PATS_IN_HOSPITAL
prompt ===================================
prompt
create table MED_PATS_IN_HOSPITAL
(
  PATIENT_ID             VARCHAR2(20) not null,
  VISIT_ID               NUMBER(2) not null,
  DEP_ID		 NUMBER(2),
  WARD_CODE              VARCHAR2(16),
  DEPT_CODE              VARCHAR2(16),
  BED_NO                 VARCHAR2(20),
  ADMISSION_DATE_TIME    DATE,
  ADM_WARD_DATE_TIME     DATE,
  DIAGNOSIS              VARCHAR2(200),
  PATIENT_CONDITION      VARCHAR2(1),
  NURSING_CLASS          VARCHAR2(1),
  DOCTOR_IN_CHARGE       VARCHAR2(30),
  OPERATING_DATE         DATE,
  BILLING_DATE_TIME      DATE,
  PREPAYMENTS            NUMBER(10,2),
  TOTAL_COSTS            NUMBER(10,2),
  TOTAL_CHARGES          NUMBER(10,2),
  GUARANTOR              VARCHAR2(8),
  GUARANTOR_ORG          VARCHAR2(40),
  GUARANTOR_PHONE_NUM    VARCHAR2(16),
  BILL_CHECKED_DATE_TIME DATE,
  SETTLED_INDICATOR      NUMBER(1),
  RESERVED01             VARCHAR2(50),
  RESERVED02             VARCHAR2(50),
  RESERVED03             VARCHAR2(50),
  RESERVED04             VARCHAR2(50),
  RESERVED05             VARCHAR2(50),
  RESERVED06             VARCHAR2(50),
  RESERVED07             VARCHAR2(50),
  RESERVED08             VARCHAR2(50),
  RESERVED09             VARCHAR2(50),
  RESERVED10             VARCHAR2(50),
  RESERVED_DATE01        DATE,
  RESERVED_DATE02        DATE,
  START_DATE_TIME        DATE,
  FREQUENCY_NURSE        NUMBER(5),
  NURSE_IN_CHARGE        VARCHAR2(30)
)
;
alter table MED_PATS_IN_HOSPITAL
  add constraint PK_MED_PATS_IN_HOSPITAL primary key (PATIENT_ID,VISIT_ID);
create index IND_1_MED_PATS_IN_HOSPITAL on MED_PATS_IN_HOSPITAL (WARD_CODE, BED_NO);
grant select, insert, update, delete on MED_PATS_IN_HOSPITAL to ROLE_DOCARE;

prompt
prompt Creating table MED_PAT_MASTER_INDEX
prompt ===================================
prompt
create table MED_PAT_MASTER_INDEX
(
  PATIENT_ID            VARCHAR2(20) not null,
  INP_NO                VARCHAR2(20),
  NAME                  VARCHAR2(30),
  NAME_PHONETIC         VARCHAR2(16),
  SEX                   VARCHAR2(4),
  DATE_OF_BIRTH         DATE,
  BIRTH_PLACE           VARCHAR2(60),
  CITIZENSHIP           VARCHAR2(30),
  NATION                VARCHAR2(30),
  ID_NO                 VARCHAR2(20),
  IDENTITY              VARCHAR2(10),
  CHARGE_TYPE           VARCHAR2(30),
  UNIT_IN_CONTRACT      VARCHAR2(11),
  MAILING_ADDRESS       VARCHAR2(80),
  ZIP_CODE              VARCHAR2(6),
  PHONE_NUMBER_HOME     VARCHAR2(40),
  PHONE_NUMBER_BUSINESS VARCHAR2(40),
  NEXT_OF_KIN           VARCHAR2(30),
  RELATIONSHIP          VARCHAR2(20),
  NEXT_OF_KIN_ADDR      VARCHAR2(80),
  NEXT_OF_KIN_ZIP_CODE  VARCHAR2(6),
  NEXT_OF_KIN_PHONE     VARCHAR2(40),
  LAST_VISIT_DATE       DATE,
  VIP_INDICATOR         NUMBER(1),
  CREATE_DATE           DATE,
  OPERATOR              VARCHAR2(30)
)
;
alter table MED_PAT_MASTER_INDEX
  add constraint PK_MED_PAT_MASTER_INDEX primary key (PATIENT_ID);
create index IND_1_MED_PAT_MASTER_INDEX on MED_PAT_MASTER_INDEX (NAME_PHONETIC);
create index IND_2_MED_PAT_MASTER_INDEX on MED_PAT_MASTER_INDEX (NAME);
create index IND_3_MED_PAT_MASTER_INDEX on MED_PAT_MASTER_INDEX (INP_NO);
grant select, insert, update, delete on MED_PAT_MASTER_INDEX to ROLE_DOCARE;

prompt
prompt Creating table MED_PAT_MONITOR_DATA_DICT
prompt ========================================
prompt
create table MED_PAT_MONITOR_DATA_DICT
(
  PATIENT_ID        VARCHAR2(20) not null,
  VISIT_ID          NUMBER(2) not null,
  DEP_ID	    NUMBER(2),
  MONITOR_DATA_NAME VARCHAR2(40),
  DB_DATA_NAME      VARCHAR2(40) not null,
  LOW_SIGNS_VALUES  NUMBER(6,2),
  HIGH_SIGNS_VALUES NUMBER(6,2)
)
;
alter table MED_PAT_MONITOR_DATA_DICT
  add constraint PK_PAT_MONITOR_DATA_DICT primary key (PATIENT_ID, VISIT_ID, DB_DATA_NAME);
grant select, insert, update, delete on MED_PAT_MONITOR_DATA_DICT to ROLE_DOCARE;

prompt
prompt Creating table MED_PAT_VISIT
prompt ============================
prompt
create table MED_PAT_VISIT
(
  PATIENT_ID               VARCHAR2(20) not null,
  VISIT_ID                 NUMBER(2) not null,
  DEPT_ADMISSION_TO        VARCHAR2(16),
  ADMISSION_DATE_TIME      DATE,
  DEPT_DISCHARGE_FROM      VARCHAR2(16),
  DISCHARGE_DATE_TIME      DATE,
  OCCUPATION               VARCHAR2(1),
  MARITAL_STATUS           VARCHAR2(4),
  IDENTITY                 VARCHAR2(10),
  ARMED_SERVICES           VARCHAR2(4),
  DUTY                     VARCHAR2(4),
  TOP_UNIT                 VARCHAR2(1),
  SERVICE_SYSTEM_INDICATOR NUMBER(1),
  UNIT_IN_CONTRACT         VARCHAR2(11),
  CHARGE_TYPE              VARCHAR2(30),
  WORKING_STATUS           NUMBER(1),
  INSURANCE_TYPE           VARCHAR2(16),
  INSURANCE_NO             VARCHAR2(18),
  SERVICE_AGENCY           VARCHAR2(80),
  MAILING_ADDRESS          VARCHAR2(80),
  ZIP_CODE                 VARCHAR2(6),
  NEXT_OF_KIN              VARCHAR2(30),
  RELATIONSHIP             VARCHAR2(2),
  NEXT_OF_KIN_ADDR         VARCHAR2(80),
  NEXT_OF_KIN_ZIPCODE      VARCHAR2(6),
  NEXT_OF_KIN_PHONE        VARCHAR2(40),
  PATIENT_CLASS            VARCHAR2(1),
  ADMISSION_CAUSE          VARCHAR2(8),
  CONSULTING_DATE          DATE,
  PAT_ADM_CONDITION        VARCHAR2(1),
  CONSULTING_DOCTOR        VARCHAR2(30),
  ADMITTED_BY              VARCHAR2(30),
  EMER_TREAT_TIMES         NUMBER(2),
  ESC_EMER_TIMES           NUMBER(2),
  SERIOUS_COND_DAYS        NUMBER(4),
  CRITICAL_COND_DAYS       NUMBER(4),
  ICU_DAYS                 NUMBER(4),
  CCU_DAYS                 NUMBER(4),
  SPEC_LEVEL_NURS_DAYS     NUMBER(4),
  FIRST_LEVEL_NURS_DAYS    NUMBER(4),
  SECOND_LEVEL_NURS_DAYS   NUMBER(4),
  AUTOPSY_INDICATOR        NUMBER(1),
  BLOOD_TYPE               VARCHAR2(2),
  BLOOD_TYPE_RH            VARCHAR2(1),
  INFUSION_REACT_TIMES     NUMBER(2),
  BLOOD_TRAN_TIMES         NUMBER(2),
  BLOOD_TRAN_VOL           NUMBER(5),
  BLOOD_TRAN_REACT_TIMES   NUMBER(2),
  DECUBITAL_ULCER_TIMES    NUMBER(2),
  ALERGY_DRUGS             VARCHAR2(80),
  ADVERSE_REACTION_DRUGS   VARCHAR2(80),
  MR_VALUE                 VARCHAR2(4),
  MR_QUALITY               VARCHAR2(2),
  FOLLOW_INDICATOR         NUMBER(1),
  FOLLOW_INTERVAL          NUMBER(2),
  FOLLOW_INTERVAL_UNITS    VARCHAR2(2),
  DIRECTOR                 VARCHAR2(30),
  ATTENDING_DOCTOR         VARCHAR2(30),
  DOCTOR_IN_CHARGE         VARCHAR2(30),
  DISCHARGE_DISPOSITION    VARCHAR2(1),
  TOTAL_COSTS              NUMBER(10,2),
  TOTAL_PAYMENTS           NUMBER(10,2),
  CATALOG_DATE             DATE,
  CATALOGER                VARCHAR2(8),
  RESERVED01               VARCHAR2(50),
  RESERVED02               VARCHAR2(50),
  RESERVED03               VARCHAR2(50),
  RESERVED04               VARCHAR2(50),
  RESERVED05               VARCHAR2(50),
  RESERVED06               VARCHAR2(50),
  RESERVED07               VARCHAR2(50),
  RESERVED08               VARCHAR2(50),
  RESERVED09               VARCHAR2(50),
  RESERVED10               VARCHAR2(50),
  RESERVED_DATE01          DATE,
  RESERVED_DATE02          DATE,
  BODY_HEIGHT              NUMBER(4,1),
  BODY_WEIGHT              NUMBER(4,1),
  PATIENT_CONDITION        VARCHAR2(12),
  ABNORMAL                 VARCHAR2(80)
)
;
alter table MED_PAT_VISIT
  add constraint PK_MED_PAT_VISIT primary key (PATIENT_ID, VISIT_ID);
create index IND_1_PAT_VISIT on MED_PAT_VISIT (ADMISSION_DATE_TIME);
create index IND_2_PAT_VISIT on MED_PAT_VISIT (DISCHARGE_DATE_TIME);
create index IND_3_PAT_VISIT on MED_PAT_VISIT (DEPT_ADMISSION_TO);
grant select, insert, update, delete on MED_PAT_VISIT to ROLE_DOCARE;

prompt
prompt Creating table MED_PERFORM_DEFAULT_SCHEDULE
prompt ===========================================
prompt
create table MED_PERFORM_DEFAULT_SCHEDULE
(
  SERIAL_NO        NUMBER(3),
  FREQ_DESC        VARCHAR2(16) not null,
  ADMINISTRATION   VARCHAR2(16) not null,
  DEFAULT_SCHEDULE VARCHAR2(60)
)
;
alter table MED_PERFORM_DEFAULT_SCHEDULE
  add constraint PK_MED_PER_DEFAULT_SCHEDULE primary key (FREQ_DESC, ADMINISTRATION);
grant select, insert, update, delete on MED_PERFORM_DEFAULT_SCHEDULE to ROLE_DOCARE;

prompt
prompt Creating table MED_PERMISSIONS
prompt ==============================
prompt
create table MED_PERMISSIONS
(
  PERMISSION_ID  VARCHAR2(36) not null,
  APP_ID         VARCHAR2(36) not null,
  NAME           VARCHAR2(100) not null,
  PERMISSION_KEY VARCHAR2(160) not null,
  SORT_ID        number(10),
  IS_VALID       VARCHAR2(1) default 'T' not null,
  DESCRIPTION    VARCHAR2(160)
)
;
alter table MED_PERMISSIONS
  add constraint KEY_MED_PERMISSIONS primary key (PERMISSION_ID);
grant select, insert, update, delete on MED_PERMISSIONS to ROLE_DOCARE;
create table MED_PERMISSIONS_ANES
(
	PERMISSION_ID VARCHAR2(36) not null,
	TYPE          VARCHAR2(2),
	MODULE        VARCHAR2(6),
	PIC           VARCHAR2(50),
	WD_NAME		  VARCHAR2(2000),
	WD_DESC        VARCHAR2(60),
	WD_MENUNAME	  VARCHAR2(2000),
	MENU_KEY	  VARCHAR2(60),
	PARENT_ID     VARCHAR2(36),
	CHILD_ID 			VARCHAR2(36)
);
alter table MED_PERMISSIONS_ANES
  add constraint PK_MED_PERMISSIONS_ANES primary key (PERMISSION_ID);
grant select, insert, update, delete on MED_PERMISSIONS_ANES to ROLE_DOCARE;

prompt
prompt Creating table MED_RELATIONSHIP_DICT
prompt ==============================
prompt
create table MED_RELATIONSHIP_DICT
(
  SERIAL_NO         NUMBER(2),
  RELATIONSHIP_CODE VARCHAR2(2) not null,
  RELATIONSHIP_NAME VARCHAR2(10),
  INPUT_CODE        VARCHAR2(8)
);
alter table MED_RELATIONSHIP_DICT
  add constraint PK_MED_RELATIONSHIP_DICT primary key (RELATIONSHIP_CODE);

grant select, insert, update, delete on MED_RELATIONSHIP_DICT to ROLE_DOCARE;


prompt
prompt Creating table MED_PRICE_ITEM_NAME_DICT
prompt =======================================
prompt
create table MED_PRICE_ITEM_NAME_DICT
(
  ITEM_CLASS    VARCHAR2(16) not null,
  ITEM_NAME     VARCHAR2(60) not null,
  ITEM_CODE     VARCHAR2(10),
  STD_INDICATOR NUMBER(1),
  INPUT_CODE    VARCHAR2(8),
  CUSTOM_CODE   VARCHAR2(8),
  INPUT_CODE_WB VARCHAR2(8),
  STOP_FLAG     VARCHAR2(2)
)
;
alter table MED_PRICE_ITEM_NAME_DICT
  add constraint PK_MED_PRICE_ITEM_NAME_DICT primary key (ITEM_CLASS, ITEM_NAME);
grant select, insert, update, delete on MED_PRICE_ITEM_NAME_DICT to ROLE_DOCARE;

prompt
prompt Creating table MED_PRICE_LIST
prompt =============================
prompt
create table MED_PRICE_LIST
(
  ITEM_CLASS         VARCHAR2(16),
  ITEM_CODE          VARCHAR2(10),
  ITEM_NAME          VARCHAR2(60),
  ITEM_SPEC          VARCHAR2(20),
  UNITS              VARCHAR2(8),
  PRICE              NUMBER(9,3),
  PREFER_PRICE       NUMBER(9,3),
  FOREIGNER_PRICE    NUMBER(9,3),
  PERFORMED_BY       VARCHAR2(8),
  FEE_TYPE_MASK      NUMBER(1),
  CLASS_ON_INP_RCPT  VARCHAR2(1),
  CLASS_ON_OUTP_RCPT VARCHAR2(1),
  CLASS_ON_RECKONING VARCHAR2(10),
  SUBJ_CODE          VARCHAR2(3),
  CLASS_ON_MR        VARCHAR2(4),
  MEMO               VARCHAR2(40),
  START_DATE         DATE,
  STOP_DATE          DATE,
  OPERATOR           VARCHAR2(8),
  ENTER_DATE         DATE,
  INPUT_CODE         VARCHAR2(8),
  RESERVED1          VARCHAR2(50),
  RESERVED2          VARCHAR2(50),
  RESERVED3          VARCHAR2(50),
  RESERVED4          NUMBER(3),
  RESERVED5          NUMBER(3)
)
;
create unique index IND_1_MED_PRICE_LIST on MED_PRICE_LIST (ITEM_CLASS, ITEM_CODE, ITEM_SPEC, UNITS, START_DATE);
grant select, insert, update, delete on MED_PRICE_LIST to ROLE_DOCARE;

prompt
prompt Creating table MED_ROLES
prompt ========================
prompt
create table MED_ROLES
(
  ROLE_ID     VARCHAR2(36) not null,
  APP_ID      VARCHAR2(36) not null,
  NAME        VARCHAR2(60) not null,
  DESCRIPTION VARCHAR2(160),
  CREATE_DATE DATE not null
)
;
alter table MED_ROLES
  add constraint KEY_MED_ROLES primary key (ROLE_ID);
grant select, insert, update, delete on MED_ROLES to ROLE_DOCARE;

prompt
prompt Creating table MED_ROLES_PERMISSIONS
prompt ====================================
prompt
create table MED_ROLES_PERMISSIONS
(
  ROLE_ID       VARCHAR2(36) not null,
  PERMISSION_ID VARCHAR2(36) not null
)
;
alter table MED_ROLES_PERMISSIONS
  add constraint KEY_MED_ROLES_PERMISSIONS primary key (ROLE_ID, PERMISSION_ID);
grant select, insert, update, delete on MED_ROLES_PERMISSIONS to ROLE_DOCARE;

prompt
prompt Creating table MED_SPECIFIC_WORD_DICT
prompt =====================================
prompt
create table MED_SPECIFIC_WORD_DICT
(
  WORD_CODE  VARCHAR2(10),
  WORD_NAME  VARCHAR2(40) not null,
  INPUT_CODE VARCHAR2(8)
)
;

alter table MED_SPECIFIC_WORD_DICT
  add constraint PK_SPECIFIC_WORD_DICT primary key (WORD_NAME);
grant select, insert, update, delete on MED_SPECIFIC_WORD_DICT to ROLE_DOCARE;

prompt
prompt Creating table MED_STAFF_DICT
prompt =============================
prompt
create table MED_STAFF_DICT
(
  EMP_NO      VARCHAR2(6) not null,
  DEPT_CODE   VARCHAR2(8),
  NAME        VARCHAR2(30),
  INPUT_CODE  VARCHAR2(8),
  JOB         VARCHAR2(8),
  TITLE       VARCHAR2(10),
  USER_NAME   VARCHAR2(30),
  IN_HOSPITAL NUMBER(1),
  NURSE_TYPE  VARCHAR2(8),
  VERIFY_PW   VARCHAR2(20),
  CREATE_DATE DATE
)
;
alter table MED_STAFF_DICT
  add constraint PK_MED_STAFF_DICT primary key (EMP_NO);
grant select, insert, update, delete on MED_STAFF_DICT to ROLE_DOCARE;

prompt
prompt Creating table MED_STAFF_VS_GROUP
prompt =================================
prompt
create table MED_STAFF_VS_GROUP
(
  GROUP_CLASS VARCHAR2(16) not null,
  GROUP_CODE  VARCHAR2(8) not null,
  EMP_NO      VARCHAR2(6) not null
)
;
alter table MED_STAFF_VS_GROUP
  add constraint PK_MED_STAFF_VS_GROUP primary key (GROUP_CLASS, GROUP_CODE, EMP_NO);
create index IND_MED_STAFF_VS_GROUP_1 on MED_STAFF_VS_GROUP (EMP_NO);
grant select, insert, update, delete on MED_STAFF_VS_GROUP to ROLE_DOCARE;

prompt
prompt Creating table MED_TITLE_DICT
prompt =============================
prompt
create table MED_TITLE_DICT
(
  SERIAL_NO  NUMBER(3),
  TITLE_CODE VARCHAR2(3) not null,
  TITLE_NAME VARCHAR2(26),
  INPUT_CODE VARCHAR2(8)
)
;

alter table MED_TITLE_DICT
  add constraint PK_MED_TITLE_DICT primary key (TITLE_CODE);
grant select, insert, update, delete on MED_TITLE_DICT to ROLE_DOCARE;

prompt
prompt Creating table MED_TRANSFER
prompt ===========================
prompt
create table MED_TRANSFER
(
  PATIENT_ID          VARCHAR2(20) not null,
  VISIT_ID            NUMBER(2) not null,
  DEPT_STAYED         VARCHAR2(16),
  ADMISSION_DATE_TIME DATE not null,
  DISCHARGE_DATE_TIME DATE,
  DEPT_TRANSFERED_TO  VARCHAR2(16),
  DOCTOR_IN_CHARGE    VARCHAR2(30),
  WARD_STAYED         VARCHAR2(16),
  WARD_TRANSFERED_TO  VARCHAR2(16),
  RESERVED1           NUMBER(3),
  BED_NO              VARCHAR2(20),
  RESERVED2           NUMBER(3),
  RESERVED3           DATE
)
;

alter table MED_TRANSFER
  add constraint PK_MED_TRANSFER primary key (PATIENT_ID, VISIT_ID, ADMISSION_DATE_TIME);
grant select, insert, update, delete on MED_TRANSFER to ROLE_DOCARE;

prompt
prompt Creating table MED_USERS
prompt ========================
prompt
create table MED_USERS
(
  USER_ID     VARCHAR2(36) not null,
  LOGIN_NAME  VARCHAR2(36) not null,
  LOGIN_PWD   VARCHAR2(36) not null,
  USER_NAME   VARCHAR2(36),
  DEPT_ID     VARCHAR2(16),
  CREATE_DATE DATE,
  IS_VALID    VARCHAR2(1) default 'T' not null,
  MEMO        VARCHAR2(100)
)
;

alter table MED_USERS
  add constraint KEY_MED_USERS primary key (USER_ID);
alter table MED_USERS
  add constraint UNIQUE_MED_USERS unique (LOGIN_NAME);
grant select, insert, update, delete on MED_USERS to ROLE_DOCARE;


prompt
prompt Creating table MED_USERS_DEPTS
prompt ==============================
prompt
create table MED_USERS_DEPTS
(
  USER_ID VARCHAR2(36) not null,
  DEPT_ID VARCHAR2(16) not null
)
;

alter table MED_USERS_DEPTS
  add constraint KEY_MED_USERS_DEPTS primary key (USER_ID, DEPT_ID);
grant select, insert, update, delete on MED_USERS_DEPTS to ROLE_DOCARE;

prompt
prompt Creating table MED_USERS_ROLES
prompt ==============================
prompt
create table MED_USERS_ROLES
(
  USER_ID VARCHAR2(36) not null,
  ROLE_ID VARCHAR2(36) not null
)
;

alter table MED_USERS_ROLES
  add constraint KEY_MED_USERS_ROLES primary key (USER_ID, ROLE_ID);
grant select, insert, update, delete on MED_USERS_ROLES to ROLE_DOCARE;

prompt
prompt Creating table MED_VS_HIS_OPER_APPLY
prompt ====================================
prompt
create table MED_VS_HIS_OPER_APPLY
(
  MED_PATIENT_ID  VARCHAR2(20) not null,
  MED_VISIT_ID    NUMBER(2) not null,
  MED_SCHEDULE_ID NUMBER(2) not null,
  HIS_APPLY_NO    VARCHAR2(20),
  HIS_PATIENT_ID  VARCHAR2(20),
  HIS_VISIT_ID    NUMBER(10),
  HIS_SCHEDULE_ID NUMBER(10),
  REQ_DATE_TIME   VARCHAR2(10) not null
)
;

alter table MED_VS_HIS_OPER_APPLY
  add constraint PK_MED_VS_HIS_OPER_APPLY primary key (MED_PATIENT_ID, MED_VISIT_ID, MED_SCHEDULE_ID, REQ_DATE_TIME);
create index IND_1_MED_VS_HIS_OPER_APPLY on MED_VS_HIS_OPER_APPLY (HIS_APPLY_NO, HIS_PATIENT_ID, HIS_VISIT_ID, HIS_SCHEDULE_ID);
grant select, insert, update, delete on MED_VS_HIS_OPER_APPLY to ROLE_DOCARE;

prompt
prompt Creating table MED_VS_HIS_OPER_MASTER
prompt =====================================
prompt
create table MED_VS_HIS_OPER_MASTER
(
  MED_PATIENT_ID  VARCHAR2(20) not null,
  MED_VISIT_ID    NUMBER(2) not null,
  MED_OPER_ID     NUMBER(2) not null,
  HIS_APPLY_NO    VARCHAR2(20),
  HIS_PATIENT_ID  VARCHAR2(20),
  HIS_VISIT_ID    VARCHAR2(20),
  HIS_SCHEDULE_ID NUMBER(10),
  REQ_DATE_TIME   VARCHAR2(10)
)
;

alter table MED_VS_HIS_OPER_MASTER
  add constraint PK_MED_VS_HIS_OPER_MASTER primary key (MED_PATIENT_ID, MED_VISIT_ID, MED_OPER_ID);
create index IND_1_MED_VS_HIS_OPER_MASTER on MED_VS_HIS_OPER_MASTER (HIS_APPLY_NO, HIS_PATIENT_ID, HIS_VISIT_ID, HIS_SCHEDULE_ID);
grant select, insert, update, delete on MED_VS_HIS_OPER_MASTER to ROLE_DOCARE;

prompt
prompt Creating table MED_VS_HIS_ORDERS
prompt ================================
prompt
create table MED_VS_HIS_ORDERS
(
  MED_PATIENT_ID       VARCHAR2(20) not null,
  MED_VISIT_ID         NUMBER(2) not null,
  MED_ORDER_NO         VARCHAR2(20) not null,
  MED_ORDER_SUB_NO     number(20) not null,
  MED_REPEAT_INDICATOR NUMBER(1) not null,
  HIS_ORDER_NO         VARCHAR2(20),
  HIS_ORDER_SUB_NO     VARCHAR2(20),
  CREATE_DATE          DATE,
  RESERVED01           VARCHAR2(50),
  RESERVED02           VARCHAR2(50),
  RESERVED03           VARCHAR2(50),
  RESERVED04           VARCHAR2(50),
  RESERVED05           VARCHAR2(50)
)
;

alter table MED_VS_HIS_ORDERS
  add constraint PK_MED_VS_HIS_ORDERS primary key (MED_PATIENT_ID, MED_VISIT_ID, MED_ORDER_NO, MED_ORDER_SUB_NO, MED_REPEAT_INDICATOR);
grant select, insert, update, delete on MED_VS_HIS_ORDERS to ROLE_DOCARE;

prompt
prompt Creating table MED_VS_HIS_ORDER_CLASS
prompt =====================================
prompt
create table MED_VS_HIS_ORDER_CLASS
(
  SERIAL_NO      NUMBER(3),
  HIS_CLASS_CODE VARCHAR2(16) not null,
  HIS_CLASS_NAME VARCHAR2(16),
  MED_CLASS_CODE VARCHAR2(1),
  MED_CLASS_NAME VARCHAR2(8)
)
;

alter table MED_VS_HIS_ORDER_CLASS
  add constraint PK_MED_VS_HIS_ORDER_CLASS primary key (HIS_CLASS_CODE);
grant select, insert, update, delete on MED_VS_HIS_ORDER_CLASS to ROLE_DOCARE;

prompt
prompt Creating table MED_VS_HIS_PAT
prompt =============================
prompt
create table MED_VS_HIS_PAT
(
  MED_PATIENT_ID VARCHAR2(20) not null,
  MED_VISIT_ID   NUMBER(2) not null,
  HIS_PATIENT_ID VARCHAR2(20),
  HIS_INP_NO     VARCHAR2(20),
  HIS_VISIT_ID   VARCHAR2(20),
  CREATE_DATE    DATE,
  RESERVED01     VARCHAR2(50),
  RESERVED02     VARCHAR2(50),
  RESERVED03     VARCHAR2(50),
  RESERVED04     VARCHAR2(50),
  RESERVED05     VARCHAR2(50),
  RESERVED06     VARCHAR2(50),
  RESERVED07     VARCHAR2(50),
  RESERVED08     VARCHAR2(50)
)
;

alter table MED_VS_HIS_PAT
  add constraint PK_MED_VS_HIS_PAT primary key (MED_PATIENT_ID, MED_VISIT_ID);
create index IND_1_MED_VS_HIS_PAT on MED_VS_HIS_PAT (HIS_PATIENT_ID, HIS_INP_NO, HIS_VISIT_ID);
grant select, insert, update, delete on MED_VS_HIS_PAT to ROLE_DOCARE;

prompt
prompt Creating table MED_VS_PACS_EXAM
prompt ===============================
prompt
create table MED_VS_PACS_EXAM
(
  MED_EXAM_NO          VARCHAR2(20) not null,
  HIS_ITEM_CLASS       VARCHAR2(20),
  HIS_EXAM_NO          NUMBER(10),
  HIS_PATIENT_LOCAL_ID VARCHAR2(20)
)
;

alter table MED_VS_PACS_EXAM
  add constraint PK_MED_VS_PACS_EXAM primary key (MED_EXAM_NO);
grant select, insert, update, delete on MED_VS_PACS_EXAM to ROLE_DOCARE;

prompt
prompt Creating table MED_WOUND_GRADE_DICT
prompt ===================================
prompt
create table MED_WOUND_GRADE_DICT
(
  SERIAL_NO        NUMBER(1),
  WOUND_GRADE_CODE VARCHAR2(1) not null,
  WOUND_GRADE_NAME VARCHAR2(2),
  INPUT_CODE       VARCHAR2(8)
)
;

alter table MED_WOUND_GRADE_DICT
  add constraint PK_MED_WOUND_GRADE_DICT primary key (WOUND_GRADE_CODE);
grant select, insert, update, delete on MED_WOUND_GRADE_DICT to ROLE_DOCARE;


prompt
prompt Creating table MED_INPUTORDER_TEMPLETE
prompt ======================================
prompt
create table MED_INPUTORDER_TEMPLETE
(
  WARD_CODE     VARCHAR2(8) not null,
  TEMPLETE_CODE VARCHAR2(10),
  TEMPLETE_NAME VARCHAR2(40) not null,
  TEMPLETE_DESC VARCHAR2(1000),
  INPUT_CODE    VARCHAR2(8)
);
alter table MED_INPUTORDER_TEMPLETE
  add constraint PK_ORDER_TEMPLETE primary key (WARD_CODE, TEMPLETE_NAME);
grant select, insert, update, delete on MED_INPUTORDER_TEMPLETE to ROLE_DOCARE;

create table MED_MARITAL_STATUS_DICT
(
  SERIAL_NO           NUMBER(1),
  MARITAL_STATUS_CODE VARCHAR2(1),
  MARITAL_STATUS_NAME VARCHAR2(4) not null,
  INPUT_CODE          VARCHAR2(8)
)
;
alter table MED_MARITAL_STATUS_DICT
  add constraint PK_MED_MARITAL_STATUS_DICT primary key (MARITAL_STATUS_NAME);
grant select, insert, update, delete on MED_MARITAL_STATUS_DICT to ROLE_DOCARE;


create table MED_SEX_DICT
(
  SERIAL_NO     NUMBER(1),
  SEX_CODE      VARCHAR2(1),
  SEX_NAME      VARCHAR2(4) not null,
  INPUT_CODE    VARCHAR2(8),
  INPUT_CODE_WB VARCHAR2(8)
);
alter table MED_SEX_DICT
  add constraint PK_MED_SEX_DICT primary key (SEX_NAME);
grant select, insert, update, delete on MED_SEX_DICT to ROLE_DOCARE;

create table MED_BILL_CONFIG_DICT
(
  ITEM_CLASS         VARCHAR2(16) not null,
  ITEM_NAME          VARCHAR2(60) not null,
  BILL_MODE          VARCHAR2(20),
  BILL_RESULT_RULE   VARCHAR2(20),
  BILL_TIME_RULE     VARCHAR2(20),
  BILL_STANDARD_TIME NUMBER(5,2),
  CHARGE_ITEM_CLASS  VARCHAR2(16),
  CHARGE_ITEM_CODE   VARCHAR2(16),
  CHARGE_ITEM_NAME   VARCHAR2(60),
  CHARGE_ITEM_SPEC   VARCHAR2(20),
  UNITS              VARCHAR2(8)
);
alter table MED_BILL_CONFIG_DICT
  add constraint PK_CLINIC_VS_CHARGE primary key (ITEM_CLASS, ITEM_NAME);
grant select, insert, update, delete on MED_BILL_CONFIG_DICT to ROLE_DOCARE;

create table MED_MR_CONTENT
(
  PATIENT_ID VARCHAR2(20) not null,
  VISIT_ID   VARCHAR2(2) not null,
  FILE_NO    VARCHAR2(2) not null,
  MR_CONT    LONG RAW
);
alter table MED_MR_CONTENT
  add constraint PK_MED_MR_CONTENT primary key (PATIENT_ID, VISIT_ID, FILE_NO);
grant select, insert, update, delete on MED_MR_CONTENT to ROLE_DOCARE;

create table MED_MR_FILE
(
  PATIENT_ID        VARCHAR2(20) not null,
  VISIT_ID          NUMBER(2) not null,
  FILE_NO           NUMBER(2) not null,
  TOPIC             VARCHAR2(40),
  CREATOR_ID        VARCHAR2(16),
  CREATE_DATE_TIME  DATE,
  TEMPLET_ID        VARCHAR2(6),
  MR_MODIFY_TIMES   NUMBER(3),
  MR_PRINT_TIMES    NUMBER(3),
  CURRENT_USER_NAME VARCHAR2(8),
  CAPABILITY        VARCHAR2(1),
  CHECKUP_MARK      VARCHAR2(1),
  RETURNED_MARK     VARCHAR2(1),
  LAST_MODIDATE     DATE
);
alter table MED_MR_FILE
  add constraint PK_MED_MR_FILE primary key (PATIENT_ID, VISIT_ID, FILE_NO);
grant select, insert, update, delete on MED_MR_FILE to ROLE_DOCARE;

create table MED_OPERROOM_CUPBOARD
(
  CUPBOARD VARCHAR2(3) not null,
  MEMO     VARCHAR2(100),
  STATUS   NUMBER(1)
);
alter table MED_OPERROOM_CUPBOARD
  add constraint PK_MED_OPERROOM_CUPBOARD primary key (CUPBOARD);
grant select, insert, update, delete on MED_OPERROOM_CUPBOARD to ROLE_DOCARE;


create table MED_OPER_ROOM_USERS
(
  USER_ID     VARCHAR2(36) not null,
  USER_NAME   VARCHAR2(30),
  USER_DEPT   VARCHAR2(16),
  USER_JOB    VARCHAR2(8),
  STATUS      NUMBER(1),
  CREATE_DATE DATE,
  RESERVED01  VARCHAR2(50),
  INPUT_CODE  VARCHAR2(30),
  STATUS_NOW  NUMBER(1)
);
alter table MED_OPER_ROOM_USERS
  add constraint PK_MED_OPER_ROOM_USERS primary key (USER_ID);
grant select, insert, update, delete on MED_OPER_ROOM_USERS to ROLE_DOCARE;


-------------------------------------
--  New table med_users_inouttime  --
-------------------------------------
-- Create table
create table MED_USERS_INOUTTIME
(
  USER_ID  VARCHAR2(36) not null,
  IN_TIME  DATE not null,
  OUT_TIME DATE,
  CUPBOARD VARCHAR2(3)
);
alter table MED_USERS_INOUTTIME
  add constraint PK_MED_USERS_INOUTTIME primary key (USER_ID, IN_TIME);
grant select, insert, update, delete on MED_USERS_INOUTTIME to ROLE_DOCARE;

------------------------------
--  New table med_users_zp  --
------------------------------
-- Create table
create table MED_USERS_ZP
(
  USER_ID VARCHAR2(36) not null,
  ZP      BLOB
);

grant select, insert, update, delete on MED_USERS_INOUTTIME to ROLE_DOCARE;

create table MED_ANESTHESIA_ITEM_CLASS
(
  SERIAL_NO  NUMBER(4)		NOT NULL,
  FUNC			 VARCHAR2(16) not null,
  ITEM_CLASS VARCHAR2(40) not null,
  ITEM_CODE  VARCHAR2(40),
  INPUT_CODE VARCHAR2(8)
);

alter table MED_ANESTHESIA_ITEM_CLASS  add constraint PK_MED_ANESTHESIA_ITEM_CLASS primary key (SERIAL_NO);
create unique index IND_MED_ANESTHESIA_ITEM_CLASS on MED_ANESTHESIA_ITEM_CLASS (func, item_class);  

grant select, insert, update, delete on MED_ANESTHESIA_ITEM_CLASS to ROLE_DOCARE;

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
  RESERVED3 VARCHAR(20)
);

alter table MED_VS_HIS_OPER_BILL_CONSTS
  add constraint PK_MED_VS_HIS_OPER_BILL_CONSTS primary key (PATIENT_ID, VISIT_ID, OPER_ID, CONSTS_COUNT,ITEM_NO_STRING);
grant select, insert, update, delete on MED_VS_HIS_OPER_BILL_CONSTS to ROLE_DOCARE;

create table MED_VS_HIS_OPER_APPLY_V2
(
  MED_PATIENT_ID  VARCHAR2(20) not null,
  MED_VISIT_ID    NUMBER(2) not null,
  MED_SCHEDULE_ID NUMBER(2) not null,
  HIS_APPLY_NO    VARCHAR2(20),
  HIS_PATIENT_ID  VARCHAR2(20),
  HIS_VISIT_ID    VARCHAR2(20),
  HIS_SCHEDULE_ID NUMBER(10),
  REQ_DATE_TIME   VARCHAR2(10)
);

alter table MED_VS_HIS_OPER_APPLY_V2
  add constraint PK_MED_VS_HIS_OPER_APPLY_V2 primary key (MED_PATIENT_ID, MED_VISIT_ID, MED_SCHEDULE_ID);
create index IND_1_MED_VS_HIS_OPER_APPLY_V2 on MED_VS_HIS_OPER_APPLY_V2 (HIS_APPLY_NO, HIS_PATIENT_ID, HIS_VISIT_ID, HIS_SCHEDULE_ID);

grant select, insert, update, delete on MED_VS_HIS_OPER_APPLY_V2 to ROLE_DOCARE;  

create table MED_EMR_ARCHIVE_DETIAL
(
  patient_id        VARCHAR2(20) not null,
  visit_id          NUMBER(2) not null,
  mr_class          VARCHAR2(10) not null,
  mr_sub_class      VARCHAR2(100) not null,
  archive_key       VARCHAR2(20) not null,
  emr_file_index    NUMBER(3) default 0 not null,
  archive_times     NUMBER(2) not null,
  topic             VARCHAR2(40),
  emr_file_name     VARCHAR2(256),
  emr_type          VARCHAR2(10),
  archive_date_time DATE,
  archive_type      VARCHAR2(10),
  archive_status    VARCHAR2(10),
  emr_owner         VARCHAR2(16),
  operator          VARCHAR2(16),
  archive_pc        VARCHAR2(80),
  archive_mode      VARCHAR2(10),
  archive_access    VARCHAR2(256),
  memo              VARCHAR2(100)
);

alter table MED_EMR_ARCHIVE_DETIAL
  add constraint PK_MED_EMR_ARCHIVE_DETIAL primary key (PATIENT_ID, VISIT_ID, MR_CLASS, MR_SUB_CLASS, ARCHIVE_KEY, EMR_FILE_INDEX, ARCHIVE_TIMES);

grant select, insert, update, delete on MED_EMR_ARCHIVE_DETIAL to ROLE_DOCARE;

create table MED_EMR_CLASS_DICT
(
  SERIAL_NO      NUMBER(2),
  MR_CLASS       VARCHAR2(10) not null,
  MR_SUB_CLASS   VARCHAR2(10) not null,
  HIDE_INDICATOR NUMBER(1)
);
alter table MED_EMR_CLASS_DICT
  add constraint PK_MED_EMR_CLASS_DICT primary key (MR_CLASS,MR_SUB_CLASS);

grant select, insert, update, delete on MED_EMR_CLASS_DICT to ROLE_DOCARE;


create table MED_EMR_WORK_PATH
(
  APPLICATION VARCHAR2(20) not null,
  EMR_PATH    VARCHAR2(240) not null,
  USER_NAME   VARCHAR2(16),
  USER_PWD    VARCHAR2(16),
  IP_ADDR     VARCHAR2(64)
);
alter table MED_EMR_WORK_PATH
  add constraint PK_MED_EMR_WORK_PATH primary key (APPLICATION, EMR_PATH);
grant select, insert, update, delete on MED_EMR_WORK_PATH to ROLE_DOCARE;



create table MED_EMR_USERS
(
  USER_ID    VARCHAR2(36) not null,
  LOGIN_NAME VARCHAR2(36),
  LOGIN_PWD  VARCHAR2(36),
  NAME       VARCHAR2(36),
  DEPT_CODE  VARCHAR2(16),
  INPUT_CODE VARCHAR2(8),
  JOB        VARCHAR2(16),
  TITLE      VARCHAR2(10),
  GRANT_CODE VARCHAR2(20),
  IS_VALID   NUMBER(1)
);
alter table MED_EMR_USERS
  add constraint PK_MED_EMR_USERS primary key (USER_ID);

grant select, insert, update, delete on MED_EMR_USERS to ROLE_DOCARE;


/


create or replace view MED_PATIENT_ARCHIVE_INFO
as
select b.his_patient_id,
       b.his_inp_no,
       a.mr_class,
       a.mr_sub_class,
       a.topic,
       a.archive_key,
       a.archive_times,
       c.emr_path ||'\' || a.archive_access || a.emr_file_name archive_access,
       c.ip_addr,
       a.archive_status
from   med_emr_archive_detial a,
       med_vs_his_pat b,
       med_emr_work_path c
where  a.patient_id = b.med_patient_id(+) and
       a.visit_id = b.med_visit_id(+) and
       c.application = 'DOCARE'
/

grant select on MED_PATIENT_ARCHIVE_INFO to ROLE_DOCARE;

prompt
prompt Creating sequence MED_EXAM_NO_SEQ
prompt =================================
prompt
create sequence MED_EXAM_NO_SEQ
minvalue 1
maxvalue 9999999999
start with 1
increment by 1
cache 20
cycle;
grant select on MED_EXAM_NO_SEQ to ROLE_DOCARE;


prompt
prompt Creating view MED_CURRENT_PRICE_LIST
prompt ====================================
prompt
create or replace view med_current_price_list as
select
	item_class,
	item_code,
	item_name,
	item_spec,
	units,
	price,
	prefer_price,
	foreigner_price,
	performed_by,
	fee_type_mask,
	class_on_inp_rcpt,
	class_on_outp_rcpt,
	class_on_reckoning,
	subj_code,
	class_on_mr,
	memo,
	operator,
	enter_date
	from med_price_list
	where sysdate>=start_date and (sysdate<stop_date or stop_date is null)
/
grant select on MED_CURRENT_PRICE_LIST to ROLE_DOCARE;

prompt
prompt Creating view med_users_applications
prompt ====================================
prompt
create or replace view med_users_applications as
select distinct a.app_id ,b.user_id from med_roles a ,med_users_roles b
where a.role_id=b.role_id
/

grant select on med_users_applications to ROLE_DOCARE;

prompt
prompt Creating view med_user_permissions
prompt ====================================
prompt
create or replace view med_user_permissions as
select DISTINCT a.user_id,  b.role_id ,c.permission_id, c.app_id,c.name,c.sort_id,c.permission_key,c.description ,d.Login_Name
FROM MED_USERS_ROLES a , MED_ROLES_PERMISSIONS b ,MED_PERMISSIONS c ,MED_USERS d
where a.role_id=b.role_id and b.permission_id =c.permission_id and  a.user_id=d.user_id and
			c.is_valid='T'
/

grant select on med_user_permissions to ROLE_DOCARE;

prompt
prompt Creating view med_permission_view
prompt ====================================
prompt

create or replace view med_permission_view as
    select A.PERMISSION_ID,A.APP_ID,A.NAME,A.PERMISSION_KEY,A.SORT_ID,A.IS_VALID,A.DESCRIPTION,NVL(B.PARENT_ID,0) PARENT_ID,B.CHILD_ID
    from med_permissions A,med_permissions_anes B where A.PERMISSION_ID=B.PERMISSION_ID(+)
/
grant select on med_permission_view to ROLE_DOCARE;

prompt
prompt Creating view MED_TIME_POINT_LIST
prompt ====================================
prompt
create or replace view MED_TIME_POINT_LIST as
Select Distinct PATIENT_ID, VISIT_ID, DEP_ID , TIME_POINT From MED_PATIENT_NURSING_REC
  Where ORDER_NO = 0
  Union
  Select Distinct PATIENT_ID, VISIT_ID, DEP_ID, TIME_POINT From MED_PATIENT_NURSING_MEMO_REC
  Where item_no = 0
  Union
  Select Distinct PATIENT_ID, VISIT_ID, DEP_ID, TIME_POINT From MED_VITAL_SIGNS_REC_TEMP
  Union
  Select Distinct PATIENT_ID, VISIT_ID, DEP_ID, TIME_POINT From MED_IN_OR_OUT_REC
        Union
        Select Distinct PATIENT_ID, VISIT_ID, DEP_ID, TIME_POINT From MED_BLOOD_TRANS_REC
/

grant select on MED_TIME_POINT_LIST to ROLE_DOCARE;

