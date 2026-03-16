CREATE TABLE MED_EQIP_CHECK_RECORD(
	PATIENT_ID nvarchar2(20) NOT NULL,
	VISIT_ID number(2,0) NOT NULL,
	OPER_ID number(2,0) NOT NULL,
	OPERATION_EQUIP_NAME nvarchar2(20) NOT NULL,
	NUM_BEFORE_OPER number(10, 0) NULL,
	NUM_ADDED_DURING_OPER number(10, 0) NULL,
	NUM_BEFORE_ABDOMINAL_CLOSURE number(10, 0) NULL,
	NUM_AFTER_ABDOMINAL_CLOSURE number(10, 0) NULL,
	RECORD_DATE DATE NULL,
	MEMO nvarchar2(200) NULL,
 CONSTRAINT EQIP_CHECK_RECORD PRIMARY KEY  
(
	PATIENT_ID ,
	VISIT_ID ,
	OPER_ID ,
	OPERATION_EQUIP_NAME
)
);
grant select, insert, update, delete on MED_EQIP_CHECK_RECORD to ROLE_DOCARE;

CREATE TABLE MED_OPERATION_EQIP_CHECK_DICT(
	SERIAL_NO number(2, 0) NULL,
	OPERATION_EQIP_CODE number(2, 0) NULL,
	OPERATION_EQIP_NAME nvarchar2(20) NOT NULL,
	INPUT_CODE nvarchar2(8) NULL,
 CONSTRAINT OPERATION_EQIP_CHECK_DICT PRIMARY KEY  
(
	OPERATION_EQIP_NAME
)
);
grant select, insert, update, delete on MED_OPERATION_EQIP_CHECK_DICT to ROLE_DOCARE;

--------------------------------
--  New table equip_material  --
--------------------------------
-- Create table
create table EQUIP_MATERIAL
(
  PATIENT_ID VARCHAR2(20) not null,
  VISIT_ID   NUMBER(2) not null,
  OPER_ID    NUMBER(2) not null,
  ITEMNO     NUMBER(3) not null,
  EQUIPNAME  VARCHAR2(100) not null,
  BEFOREOPER NUMBER(2),
  INOPER     NUMBER(2),
  BEFOREROOM NUMBER(2),
  BEFOREDOOR NUMBER(2),
  AFTERDOOR  NUMBER(2)
)
tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
-- Create/Recreate primary, unique and foreign key constraints 
alter table EQUIP_MATERIAL
  add constraint PK_EQUIP_MATERIAL primary key (PATIENT_ID, VISIT_ID, OPER_ID, ITEMNO)
  using index 
  tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );

grant select, insert, update, delete on EQUIP_MATERIAL to ROLE_DOCARE;

-----------------------------
--  New table guid_params  --
-----------------------------
-- Create table
create table GUID_PARAMS
(
  GUID  VARCHAR2(40) not null,
  PARAM VARCHAR2(40) not null
)
tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
-- Create/Recreate primary, unique and foreign key constraints 
alter table GUID_PARAMS
  add constraint PK_GUID_PARAMS primary key (GUID, PARAM)
  using index 
  tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
grant select, insert, update, delete on GUID_PARAMS to ROLE_DOCARE;

---------------------------------------
--  New table med_anesthesia_master  --
---------------------------------------
-- Create table
create table MED_ANESTHESIA_MASTER
(
  PATIENT_ID           VARCHAR2(20) not null,
  VISIT_ID             NUMBER(2) not null,
  OPER_ID              NUMBER(2) not null,
  LARYNGOSCOPE         VARCHAR2(80),
  TRACHEA_TUBE         VARCHAR2(200),
  HEART_LUNG_TIME      NUMBER(6),
  LOW_FLOW_TIME        NUMBER(6),
  STOP_LOOP_TIME       NUMBER(6),
  SEPARATE_LOOP_TIME   NUMBER(6),
  PRE_STUFF_VOLUME     NUMBER(8,4),
  REMAIN_VOLUME        NUMBER(8,4),
  FILTER_VOLUME        NUMBER(8,4),
  BACKFLOW_VOLUME      NUMBER(8,4),
  EST_BLOODLOST_VOLUME NUMBER(8,4),
  HEART_LUNG_OPERATOR  VARCHAR2(200),
  ANESTHESIA_DOCTOR    VARCHAR2(80)
)
tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_ANESTHESIA_MASTER
  add constraint PKANESTHESIAMASTER primary key (PATIENT_ID, VISIT_ID, OPER_ID)
  using index 
  tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
grant select, insert, update, delete on MED_ANESTHESIA_MASTER to ROLE_DOCARE;

------------------------------------
--  New table med_anes_type_dict  --
------------------------------------
-- Create table
create table MED_ANES_TYPE_DICT
(
  PRIMARY_KEY VARCHAR2(36) not null,
  NAME        VARCHAR2(60) not null,
  CODE        VARCHAR2(20),
  PARENT_KEY  VARCHAR2(36)
)
tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_ANES_TYPE_DICT
  add constraint PK_MED_ANES_TYPE_DICT primary key (PRIMARY_KEY)
  using index 
  tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
grant select, insert, update, delete on MED_ANES_TYPE_DICT to ROLE_DOCARE;

----------------------------
--  New table med_config  --
----------------------------
-- Create table
create table MED_CONFIG
(
  PARAKEY   VARCHAR2(50) not null,
  PARAVALUE BLOB
)
tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_CONFIG
  add constraint PK_MED_CONFIG primary key (PARAKEY)
  using index 
  tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
grant select, insert, update, delete on MED_CONFIG to ROLE_DOCARE;

--------------------------------------
--  New table med_customfield_dict  --
--------------------------------------
-- Create table
create table MED_CUSTOMFIELD_DICT
(
  FIELD_NAME VARCHAR2(60) not null,
  FIELD_TYPE VARCHAR2(16),
  FIELD_DESC VARCHAR2(200),
  ALIAS_NAME VARCHAR2(60)
)
tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_CUSTOMFIELD_DICT
  add constraint PK_MED_CUSTOMFIELD_DICT primary key (FIELD_NAME)
  using index 
  tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
grant select, insert, update, delete on MED_CUSTOMFIELD_DICT to ROLE_DOCARE;

---------------------------------
--  New table med_custom_data  --
---------------------------------
-- Create table
create table MED_CUSTOM_DATA
(
  PATIENT_ID VARCHAR2(20) not null,
  VISIT_ID   NUMBER(2) not null,
  OPER_ID    NUMBER(2) not null,
  ITEM_NAME  VARCHAR2(60) not null,
  ITEM_VALUE VARCHAR2(1000)
)
tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_CUSTOM_DATA
  add constraint PK_MED_CUSTOM_DATA primary key (PATIENT_ID, VISIT_ID, OPER_ID, ITEM_NAME)
  using index 
  tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
grant select, insert, update, delete on MED_CUSTOM_DATA to ROLE_DOCARE;

-------------------------------------
--  New table med_custom_data_ext  --
-------------------------------------
-- Create table
create table MED_CUSTOM_DATA_EXT
(
  PATIENT_ID VARCHAR2(20) not null,
  VISIT_ID   NUMBER(2) not null,
  OPER_ID    NUMBER(2) not null,
  ITEM_NAME  VARCHAR2(60) not null,
  ITEM_VALUE BLOB
)
tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_CUSTOM_DATA_EXT
  add constraint PK_MED_CUSTOM_DATA_EXT primary key (PATIENT_ID, VISIT_ID, OPER_ID, ITEM_NAME)
  using index 
  tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
grant select, insert, update, delete on MED_CUSTOM_DATA_EXT to ROLE_DOCARE;

--------------------------------------
--  New table med_dict_simpletypes  --
--------------------------------------
-- Create table
create table MED_DICT_SIMPLETYPES
(
  TYPEKEY   VARCHAR2(100) not null,
  TYPEVALUE VARCHAR2(100) not null
)
tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_DICT_SIMPLETYPES
  add constraint PK_MED_DICT_SIMPLETYPES primary key (TYPEKEY, TYPEVALUE)
  using index 
  tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
grant select, insert, update, delete on MED_DICT_SIMPLETYPES to ROLE_DOCARE;

-------------------------------------------
--  New table med_dict_simpletypes_tree  --
-------------------------------------------
-- Create table
create table MED_DICT_SIMPLETYPES_TREE
(
  PARENTTYPEKEY VARCHAR2(100) not null,
  CHILDTYPEKEY  VARCHAR2(100) not null
)
tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_DICT_SIMPLETYPES_TREE
  add constraint PK_MED_DICT_SIMPLETYPES_TREE primary key (PARENTTYPEKEY, CHILDTYPEKEY)
  using index 
  tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
grant select, insert, update, delete on MED_DICT_SIMPLETYPES_TREE to ROLE_DOCARE;

------------------------------
--  New table med_document  --
------------------------------
-- Create table
create table MED_DOCUMENT
(
  DOCUMENTNAME    VARCHAR2(50) not null,
  DOCUMENTPATH    VARCHAR2(50) not null,
  DOCUMENTCONTENT BLOB,
  DOCUMENTTIME    DATE
)
tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_DOCUMENT
  add constraint PK_MED_DOCUMENT primary key (DOCUMENTNAME, DOCUMENTPATH)
  using index 
  tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
grant select, insert, update, delete on MED_DOCUMENT to ROLE_DOCARE;

--------------------------------------
--  New table med_document_templet  --
--------------------------------------
-- Create table
create table MED_DOCUMENT_TEMPLET
(
  TEMPLET_GUID  NVARCHAR2(50) not null,
  USER_ID       NVARCHAR2(50) not null,
  DOCUMENT_NAME NVARCHAR2(50) not null,
  CLASS_NAME    NVARCHAR2(50) not null,
  TEMPLET_NAME  NVARCHAR2(50) not null,
  ISJUBU        NUMBER(1) not null,
  ISPRIVATE     NUMBER(1) not null,
  TEMPLET_VALUE BLOB
)
tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_DOCUMENT_TEMPLET
  add constraint PK_MED_DOCUMENT_TEMPLET primary key (TEMPLET_GUID)
  using index 
  tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
grant select, insert, update, delete on MED_DOCUMENT_TEMPLET to ROLE_DOCARE;

-----------------------------------
--  New table med_js_mzkcaozhuo  --
-----------------------------------
-- Create table
create table MED_JS_MZKCAOZHUO
(
  PATIENT_ID    VARCHAR2(20) not null,
  VISIT_ID      NUMBER not null,
  OPER_ID       NUMBER not null,
  OPERATIONNAME VARCHAR2(50),
  OPERATIONMEMO VARCHAR2(1000),
  ADVICEOPTDATE DATE,
  ADVICECUREWAY VARCHAR2(50)
)
tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_JS_MZKCAOZHUO
  add constraint PK_MED_JS_MZKCAOZHUO primary key (PATIENT_ID, VISIT_ID, OPER_ID)
  using index 
  tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
grant select, insert, update, delete on MED_JS_MZKCAOZHUO to ROLE_DOCARE;

----------------------------------------
--  New table med_js_shouhouzhentong  --
----------------------------------------
-- Create table
create table MED_JS_SHOUHOUZHENTONG
(
  PATIENT_ID     VARCHAR2(20) not null,
  VISIT_ID       NUMBER not null,
  OPER_ID        NUMBER not null,
  ROUTE          VARCHAR2(50),
  LOADMACHINE    VARCHAR2(50),
  EXCLUDEHINDER  VARCHAR2(50),
  VAS            VARCHAR2(50),
  COMPLICATION   VARCHAR2(50),
  PRESCRIPTION   VARCHAR2(50),
  UNLOADMACHINE  VARCHAR2(50),
  ZHENTONGMETHOD VARCHAR2(50)
)
tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_JS_SHOUHOUZHENTONG
  add constraint PK_MED_JS_SHOUHOUZHENTONG primary key (PATIENT_ID, VISIT_ID, OPER_ID)
  using index 
  tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
grant select, insert, update, delete on MED_JS_SHOUHOUZHENTONG to ROLE_DOCARE;

---------------------------------------
--  New table med_js_shuhoubingqing  --
---------------------------------------
-- Create table
create table MED_JS_SHUHOUBINGQING
(
  PATIENT_ID    VARCHAR2(20) not null,
  VISIT_ID      NUMBER not null,
  OPER_ID       NUMBER not null,
  RECORDTIME    DATE,
  SENSE         VARCHAR2(20),
  BLOODPRESSURE VARCHAR2(50),
  PULSE         VARCHAR2(50),
  BREATH        VARCHAR2(50),
  SPO2          VARCHAR2(50),
  ECG           VARCHAR2(50),
  OTHER         VARCHAR2(200)
)
tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_JS_SHUHOUBINGQING
  add constraint PK_MED_JS_SHUHOUBINGQING primary key (PATIENT_ID, VISIT_ID, OPER_ID)
  using index 
  tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
grant select, insert, update, delete on MED_JS_SHUHOUBINGQING to ROLE_DOCARE;

---------------------------------------
--  New table med_js_shuqianfangtan  --
---------------------------------------
-- Create table
create table MED_JS_SHUQIANFANGTAN
(
  PATIENT_ID                   VARCHAR2(20) not null,
  VISIT_ID                     NUMBER not null,
  OPER_ID                      NUMBER not null,
  HASOPERATION                 VARCHAR2(10),
  OPERATIONNAME                VARCHAR2(50),
  HASSMOKING                   VARCHAR2(10),
  SMOKINGSTARTYEAR             VARCHAR2(4),
  SMOKINGENDYEAR               VARCHAR2(4),
  SMOKINGDAYS                  VARCHAR2(10),
  HASDRINKING                  VARCHAR2(10),
  DRINKINGAMOUNT               VARCHAR2(10),
  HASASTHMA                    VARCHAR2(10),
  ASTHMATYPE                   VARCHAR2(100),
  ASTHMARATE                   VARCHAR2(20),
  HASRECENTCOLD                VARCHAR2(10),
  HASRECENTCOUGH               VARCHAR2(10),
  COUGHMEMO                    VARCHAR2(100),
  HASCHESTPAIN                 VARCHAR2(10),
  CHESTPAINMEMO                VARCHAR2(100),
  HASHYPERTENSION              VARCHAR2(10),
  HYPERTENSIONHIGHHIGHPRESSURE VARCHAR2(10),
  HYPERTENSIONHIGHLOWPRESSURE  VARCHAR2(10),
  HYPERTENSIONLOWHIGHPRESSURE  VARCHAR2(10),
  HYPERTENSIONLOWLOWPRESSURE   VARCHAR2(10),
  HYPERTENSIONACTIVEMEMO       VARCHAR2(200),
  HASDIABETES                  VARCHAR2(10),
  DIABETESCUREWAY              VARCHAR2(50),
  BLEEDORGANS                  VARCHAR2(50),
  HASBLUEPURPLE                VARCHAR2(10),
  HASDRUGALLERGY               VARCHAR2(10),
  ALLERGYDRUG                  VARCHAR2(100),
  HASDRUG                      VARCHAR2(10),
  RECENTDRUG                   VARCHAR2(100),
  BLOODPRESSURE                VARCHAR2(100),
  PULSE                        VARCHAR2(100),
  PUPILREGULAR                 VARCHAR2(10),
  PUPILLEFT                    VARCHAR2(10),
  PUPILRIGHT                   VARCHAR2(10),
  OPENDEGREE                   VARCHAR2(20),
  HEADNECKACTIVE               VARCHAR2(20),
  FALSETEETH                   VARCHAR2(10),
  ACTVETEETH                   VARCHAR2(10),
  EASYWOUNDEDTEETH             VARCHAR2(10),
  BOTHBREATH                   VARCHAR2(10),
  SPINEPAIN                    VARCHAR2(50),
  SKINCATCH                    VARCHAR2(50),
  CANNOTCHECK                  VARCHAR2(10),
  FROBIDFOODSTART              VARCHAR2(10),
  FROBIDDRINKSTART             VARCHAR2(10),
  MORNINGDRUG                  VARCHAR2(100),
  MORNINGDRUGHOUR              VARCHAR2(10),
  STOPDRUG                     VARCHAR2(100),
  ADVICE1                      VARCHAR2(100),
  ADVICE2                      VARCHAR2(100),
  ADVICE3                      VARCHAR2(100)
)
tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_JS_SHUQIANFANGTAN
  add constraint PK_MED_JS_SHUQIANFANGTAN primary key (PATIENT_ID, VISIT_ID, OPER_ID)
  using index 
  tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
grant select, insert, update, delete on MED_JS_SHUQIANFANGTAN to ROLE_DOCARE;

------------------------------------
--  New table med_modify_history  --
------------------------------------
-- Create table
create table MED_MODIFY_HISTORY
(
  TABLE_NAME  VARCHAR2(100) not null,
  FIELD_NAME  VARCHAR2(50) not null,
  PRIMARY_KEY VARCHAR2(200) not null,
  NEW_VALUE   VARCHAR2(100),
  OLD_VALUE   VARCHAR2(100),
  MODIFY_TIME DATE not null,
  OPERATOR    VARCHAR2(8) not null
)
tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_MODIFY_HISTORY
  add constraint PK_MED_MODIFY_HISTORY primary key (TABLE_NAME, FIELD_NAME, PRIMARY_KEY, MODIFY_TIME)
  using index 
  tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
grant select, insert, update, delete on MED_MODIFY_HISTORY to ROLE_DOCARE;

--------------------------------------
--  New table med_normal_type_dict  --
--------------------------------------
-- Create table
create table MED_NORMAL_TYPE_DICT
(
  PRIMARY_KEY VARCHAR2(36) not null,
  NAME        VARCHAR2(60) not null,
  PARENT_KEY  VARCHAR2(36)
)
tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_NORMAL_TYPE_DICT
  add constraint PK_MED_NORMAL_TYPE_DICT primary key (PRIMARY_KEY)
  using index 
  tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
grant select, insert, update, delete on MED_NORMAL_TYPE_DICT to ROLE_DOCARE;

--------------------------------------------
--  New table med_patient_monitor_config  --
--------------------------------------------
-- Create table
create table MED_PATIENT_MONITOR_CONFIG
(
  PATIENT_ID VARCHAR2(20) not null,
  VISIT_ID   NUMBER(2) not null,
  OPER_ID    NUMBER(2) not null,
  CONTENT    BLOB
)
tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_PATIENT_MONITOR_CONFIG
  add constraint PK_MED_PATIENT_MONITOR_CONFIG primary key (PATIENT_ID, VISIT_ID, OPER_ID)
  using index 
  tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
grant select, insert, update, delete on MED_PATIENT_MONITOR_CONFIG to ROLE_DOCARE;

------------------------------------------
--  New table med_patient_monitor_data  --
------------------------------------------
-- Create table
create table MED_PATIENT_MONITOR_DATA
(
  PATIENT_ID     VARCHAR2(20) not null,
  VISIT_ID       NUMBER(2) not null,
  OPER_ID        NUMBER(2) not null,
  TIME_POINT     DATE not null,
  ITEM_NAME      VARCHAR2(20) not null,
  ITEM_VALUE     VARCHAR2(20) not null,
  RECORDING_DATE DATE not null,
  OPERATOR       VARCHAR2(8) not null,
  EVENT_NO       NUMBER(3) not null
)
tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
alter table MEDSURGERY.MED_PATIENT_MONITOR_DATA
  add constraint PKPATMONITORDATA primary key (PATIENT_ID, VISIT_ID, OPER_ID, TIME_POINT, ITEM_NAME,EVENT_NO);
grant select, insert, update, delete on MED_PATIENT_MONITOR_DATA to ROLE_DOCARE;

----------------------------------
--  New table med_perkind_rela  --
----------------------------------
-- Create table
create table MED_PERKIND_RELA
(
  KIND_ID       VARCHAR2(36) not null,
  PERMISSION_ID VARCHAR2(36) not null
)
tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_PERKIND_RELA
  add constraint PK_MED_PERKIND_RELA primary key (KIND_ID, PERMISSION_ID)
  using index 
  tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
grant select, insert, update, delete on MED_PERKIND_RELA to ROLE_DOCARE;

--------------------------------------
--  New table med_permissions_kind  --
--------------------------------------
-- Create table
create table MED_PERMISSIONS_KIND
(
  KIND_ID     VARCHAR2(36) not null,
  APP_ID      VARCHAR2(36) not null,
  NAME        VARCHAR2(60) not null,
  SORT_ID     NUMBER(38),
  IS_VALID    VARCHAR2(1) not null,
  DESCRIPTION VARCHAR2(160)
)
tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_PERMISSIONS_KIND
  add constraint PK_MED_PERMISSIONS_KIND primary key (KIND_ID)
  using index 
  tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
grant select, insert, update, delete on MED_PERMISSIONS_KIND to ROLE_DOCARE;

-------------------------------
--  New table med_plandrugs  --
-------------------------------
-- Create table
create table MED_PLANDRUGS
(
  PATIENT_ID VARCHAR2(20) not null,
  VISIT_ID   NUMBER(2) not null,
  OPER_ID    NUMBER(2) not null,
  DRUG_TYPE  VARCHAR2(50),
  ITEM_CODE  VARCHAR2(50),
  DOSAGE     NUMBER(8,4)
)
tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_PLANDRUGS
  add constraint PK_MED_PLANDRUGS primary key (PATIENT_ID, VISIT_ID, OPER_ID)
  using index 
  tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
grant select, insert, update, delete on MED_PLANDRUGS to ROLE_DOCARE;

create table OPER_SAFE_CHECK
(
  PATIENT_ID            VARCHAR2(20) not null,
  VISIT_ID              NUMBER(2) not null,
  OPER_ID               NUMBER(2) not null,
  ITEM_NO               NUMBER(2) not null,
  IDENTITY              VARCHAR2(20),
  AGREEMENT             VARCHAR2(20),
  DIAGNOSIS_BEFORE_OPER VARCHAR2(20),
  OPER_POSITION         VARCHAR2(20),
  OPER_POSITION1        VARCHAR2(20),
  SURGEON               VARCHAR2(20),
  ANESDOCTOR            VARCHAR2(20),
  NURSE_IN_OPERROOM     VARCHAR2(20),
  SURGEON1              VARCHAR2(20),
  MEMO                  VARCHAR2(1000)
)
tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
-- Create/Recreate primary, unique and foreign key constraints 
alter table OPER_SAFE_CHECK
  add constraint PK_OPER_SAFE_CHECK primary key (PATIENT_ID, VISIT_ID, OPER_ID, ITEM_NO)
  using index 
  tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
grant select, insert, update, delete on OPER_SAFE_CHECK to ROLE_DOCARE;

-------------------------------------
--  New table patient_extend_info  --
-------------------------------------
-- Create table
create table PATIENT_EXTEND_INFO
(
  PATIENT_ID VARCHAR2(20) not null,
  VISIT_ID   NUMBER(2) not null,
  OPER_ID    NUMBER(2) not null,
  LKEY       VARCHAR2(100) not null,
  LVALUE     VARCHAR2(1000)
)
tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
-- Create/Recreate primary, unique and foreign key constraints 
alter table PATIENT_EXTEND_INFO
  add constraint PK_PATIENT_EXTEND_INFO primary key (PATIENT_ID, VISIT_ID, OPER_ID, LKEY)
  using index 
  tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
grant select, insert, update, delete on PATIENT_EXTEND_INFO to ROLE_DOCARE;

alter table MED_OPERATION_MASTER add SCHEDULED_DATE_TIME DATE;
alter table MED_OPERATION_MASTER add BED_NO VARCHAR2(20);
alter table MED_OPERATION_MASTER add REQ_DATE_TIME DATE;
alter table MED_OPERATION_MASTER add QIEKOU_CLASS VARCHAR2(20);
alter table MED_OPERATION_MASTER add QIEKOU_NUMBER NUMBER(6);
alter table MED_OPERATION_MASTER add MEMO1 VARCHAR2(200);
alter table MED_OPERATION_MASTER add OPERATION_NAME VARCHAR2(80);
alter table MED_OPERATION_MASTER add MEN_ZHEN VARCHAR2(20);
alter table MED_OPERATION_MASTER add ANESTHESIA_RESULT VARCHAR2(20);
alter table MED_OPERATION_MASTER add SIMPLE_SICK VARCHAR2(20);
alter table MED_OPERATION_MASTER add ISOLATION_NEED VARCHAR2(20);
alter table MED_OPERATION_MASTER add DANBINGZHONG VARCHAR2(20);
alter table MED_OPERATION_MASTER add YIBAO VARCHAR2(20);
alter table MED_OPERATION_MASTER add FIRST_SHIFT_SUPPLY_NURSE VARCHAR2(8);
alter table MED_OPERATION_MASTER add FIRST_SHIFT_OPERATION_NURSE VARCHAR2(8);
alter table MED_OPERATION_MASTER add FIRST_SHIFT_SUPPLY_DATETIME DATE;
alter table MED_OPERATION_MASTER add FIRST_SHIFT_OPERATION_DATETIME DATE;
alter table MED_OPERATION_MASTER add ANES_START_TIME DATE;
alter table MED_OPERATION_MASTER add ANES_END_TIME DATE;
alter table MED_OPERATION_MASTER add INDUCE_START_TIME DATE;
alter table MED_OPERATION_MASTER add INDUCE_END_TIME DATE;
alter table MED_OPERATION_MASTER add PACU_START_TIME DATE;
alter table MED_OPERATION_MASTER add PACU_END_TIME DATE;
alter table MED_OPERATION_MASTER add DONE_DATE_TIME DATE;
alter table MED_OPERATION_MASTER add CANCEL_DATE_TIME DATE;
alter table MED_OPERATION_MASTER add ANALGESIC_PUMPS VARCHAR2(100);
alter table MED_OPERATION_MASTER modify DEPT_STAYED VARCHAR2(8);
alter table MED_OPERATION_MASTER modify OPERATING_ROOM VARCHAR2(8);
alter table MED_OPERATION_MASTER modify OPERATING_DEPT VARCHAR2(8);
alter table MED_OPERATION_MASTER modify SURGEON VARCHAR2(8);
alter table MED_OPERATION_MASTER modify FIRST_ASSISTANT VARCHAR2(8);
alter table MED_OPERATION_MASTER modify SECOND_ASSISTANT VARCHAR2(8);
alter table MED_OPERATION_MASTER modify THIRD_ASSISTANT VARCHAR2(8);
alter table MED_OPERATION_MASTER modify FOURTH_ASSISTANT VARCHAR2(8);
alter table MED_OPERATION_MASTER modify ANESTHESIA_DOCTOR VARCHAR2(8);
alter table MED_OPERATION_MASTER modify ANESTHESIA_ASSISTANT VARCHAR2(8);
alter table MED_OPERATION_MASTER modify BLOOD_TRAN_DOCTOR VARCHAR2(8);
alter table MED_OPERATION_MASTER modify FIRST_OPERATION_NURSE VARCHAR2(8);
alter table MED_OPERATION_MASTER modify SECOND_OPERATION_NURSE VARCHAR2(8);
alter table MED_OPERATION_MASTER modify FIRST_SUPPLY_NURSE VARCHAR2(8);
alter table MED_OPERATION_MASTER modify SECOND_SUPPLY_NURSE VARCHAR2(8);
alter table MED_OPERATION_MASTER modify ENTERED_BY VARCHAR2(8);
alter table MED_OPERATION_MASTER modify THIRD_SUPPLY_NURSE VARCHAR2(8);
alter table MED_OPERATION_MASTER modify OPER_STATUS NUMBER(2) default null;
alter table MED_OPERATION_MASTER modify SECOND_ANESTHESIA_ASSISTANT VARCHAR2(8);
alter table MED_OPERATION_MASTER modify THIRD_ANESTHESIA_ASSISTANT VARCHAR2(8);
alter table MED_OPERATION_MASTER modify FOURTH_ANESTHESIA_ASSISTANT VARCHAR2(8);
alter table MED_OPERATION_MASTER modify OPERATION_POSITION VARCHAR2(16);
alter table MED_OPERATION_MASTER modify SECOND_ANESTHESIA_DOCTOR VARCHAR2(8);
alter table MED_OPERATION_MASTER modify THIRD_ANESTHESIA_DOCTOR VARCHAR2(8);
