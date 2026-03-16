rem=====================================================
rem     作    者：研发部
rem     整理时间：2008-07-11
rem     说    明：创建ICU部分
rem=====================================================

connect &MedIcuConn
prompt
prompt Creating table MED_VALUES_CHANGED_REC
prompt ===============================
prompt
create table MED_VALUES_CHANGED_REC
(
  PATIENT_ID       VARCHAR2(20) not null,
  VISIT_ID         NUMBER(2) not null,
  DEP_ID	   NUMBER(2) not null,
  RECORDING_DATE   DATE not null,
  TIME_POINT       DATE not null,
  CHANGE_ITEM	   VARCHAR2(16) not null,
  TYPE             NUMBER(2) not null,
  VALUES_SIGNS     VARCHAR2(100) not null,
  LOG_DATE_TIME    DATE not null,
  OLD_VALUES       VARCHAR2(40),
  NEW_VALUES       VARCHAR2(40),
  UNITS            VARCHAR2(40),
  MEMO             VARCHAR2(1000),
  OLD_MEMO         VARCHAR2(1000),
  OPERATOR         VARCHAR2(30),
  OLD_OPERATOR     VARCHAR2(30),
  ORDER_NO         VARCHAR2(20),
  ORDER_SUB_NO     NUMBER(12,0),
  DUTY_NAME        VARCHAR2(8),
  DUTY_DATE        DATE,
  ITEM_NO          NUMBER(2,0)
);
alter table MED_VALUES_CHANGED_REC
  add constraint PK_MED_VALUES_CHANGED_REC primary key (PATIENT_ID, VISIT_ID, DEP_ID, RECORDING_DATE, TIME_POINT,CHANGE_ITEM,TYPE, VALUES_SIGNS,LOG_DATE_TIME);
grant select, insert, update, delete on MED_VALUES_CHANGED_REC to ROLE_DOCARE;

prompt
prompt Creating table MED_MEDS_SCORING_RESULT
prompt ===============================
prompt
create table MED_MEDS_SCORING_RESULT
(
  PATIENT_ID        VARCHAR2(20) not null,
  VISIT_ID          NUMBER(2) not null,
  DEP_ID	   NUMBER(2) not null,
  SCORING_DATE_TIME date not null,
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
alter table MED_MEDS_SCORING_RESULT
  add constraint pk_meds_scoring primary key (PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME);

grant select, insert, update, delete on MED_MEDS_SCORING_RESULT to ROLE_DOCARE;
prompt
prompt Creating table MED_BABYSCORE_SCORING_RESULT
prompt ===============================
prompt
create table MED_BABYSCORE_SCORING_RESULT
(
  PATIENT_ID        VARCHAR2(20) not null,
  VISIT_ID          NUMBER(2) not null,
  DEP_ID	    NUMBER(2) not null,
  SCORING_DATE_TIME DATE not null,
  S1                NUMBER,
  S2                NUMBER,
  S3                NUMBER,
  S4                NUMBER,
  S5                NUMBER,
  S6                NUMBER,
  S7                NUMBER,
  S8                NUMBER,
  S9                NUMBER,
  S10               NUMBER,
  S11               NUMBER,
  STYPE             NUMBER,
  MEMO              VARCHAR2(100)
)
;
alter table MED_BABYSCORE_SCORING_RESULT
  add constraint PK_BABYSCORE primary key (PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME);

grant select, insert, update, delete on MED_BABYSCORE_SCORING_RESULT to ROLE_DOCARE;
prompt
prompt Creating table MED_PRISM_SCORING_RESULT
prompt ===============================
prompt
create table MED_PRISM_SCORING_RESULT
(
  PATIENT_ID        VARCHAR2(20) not null,
  VISIT_ID          NUMBER(2) not null,
  DEP_ID	    NUMBER(2) not null,
  SCORING_DATE_TIME DATE not null,
  S1                NUMBER,
  S2                NUMBER,
  S3                NUMBER,
  S4                NUMBER,
  S5                NUMBER,
  S6                NUMBER,
  S7                NUMBER,
  S8                NUMBER,
  S9                NUMBER,
  S10               NUMBER,
  S11               NUMBER,
  S12               NUMBER,
  S13               NUMBER,
  S14               NUMBER,
  S15               NUMBER,
  S16               NUMBER,
  MEMO              VARCHAR2(100)
)
;
alter table MED_PRISM_SCORING_RESULT
  add constraint PK_PRISM primary key (PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME);

grant select, insert, update, delete on MED_PRISM_SCORING_RESULT to ROLE_DOCARE;
prompt
prompt Creating table MED_ISS_TRS_TRISS_SCORING
prompt ===============================
prompt
create table MED_ISS_TRS_TRISS_SCORING
(
  PATIENT_ID        VARCHAR2(20) not null,
  VISIT_ID          NUMBER(2) not null,
  DEP_ID	    NUMBER(2) not null,
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
  S10               NUMBER(1),
  MEMO              VARCHAR2(100)
)
;
alter table MED_ISS_TRS_TRISS_SCORING
  add constraint PK_ISS_TRS_TRISS primary key (PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME);

grant select, insert, update, delete on MED_ISS_TRS_TRISS_SCORING to ROLE_DOCARE;
prompt
prompt Creating table MED_TISS28_SCORING
prompt ===============================
prompt
create table MED_TISS28_SCORING
(
  PATIENT_ID        VARCHAR2(20) not null,
  VISIT_ID          NUMBER(2) not null,
  DEP_ID	    NUMBER(2) not null,
  SCORING_DATE_TIME DATE not null,
  S1                NUMBER(1),
  S2                NUMBER(1),
  S3                NUMBER(1),
  S4                NUMBER(2),
  S5                NUMBER(1),
  S6                NUMBER(1),
  S7                NUMBER(1),
  S8                NUMBER(1),
  S9                NUMBER(1),
  S10               NUMBER(1),
  S11               NUMBER(1),
  S12               NUMBER(1),
  S13               NUMBER(1),
  S14               NUMBER(2),
  S15               NUMBER(1),
  S16               NUMBER(1),
  S17               NUMBER(1),
  S18               NUMBER(1),
  S19               NUMBER(1),
  S20               NUMBER(1),
  S21               NUMBER(1),
  S22               NUMBER(1),
  S23               NUMBER(1),
  S24               NUMBER(1),
  NURSE_TIME        NUMBER(6,2),
  TISS_76           NUMBER(4)
);
alter table MED_TISS28_SCORING
  add constraint PK_TISS28_SCORING primary key (PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME);
 
grant select, insert, update, delete on MED_TISS28_SCORING to ROLE_DOCARE;
prompt
prompt Creating table MED_ICUTRAUMA
prompt ===============================
prompt
create table MED_ICUTRAUMA
(
  PATIENT_ID        VARCHAR2(20) not null,
  VISIT_ID          NUMBER(2) not null,
  DEP_ID	    NUMBER(2) not null,
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
  S10               NUMBER(1),
  MEMO              VARCHAR2(100)
);
alter table MED_ICUTRAUMA
  add constraint PK_ICU primary key (PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME);
  
grant select, insert, update, delete on MED_ICUTRAUMA to ROLE_DOCARE;
prompt
prompt Creating table MED_MPM_SCORING
prompt ===============================
prompt
create table MED_MPM_SCORING
(
  PATIENT_ID        VARCHAR2(20) not null,
  VISIT_ID          NUMBER(2) not null,
  DEP_ID	    NUMBER(2) not null,
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
  S10               NUMBER(1),
  S11               NUMBER(1),
  S12               NUMBER(1),
  S13               NUMBER(1),
  S14               VARCHAR2(10),
  MEMO              VARCHAR2(100)
);
alter table MED_MPM_SCORING
  add constraint PK_MPM primary key (PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME);

grant select, insert, update, delete on MED_MPM_SCORING to ROLE_DOCARE;
prompt
prompt Creating table MED_EURO_SCORING
prompt ===============================
prompt
create table MED_EURO_SCORING
(
  PATIENT_ID        VARCHAR2(20) not null,
  VISIT_ID          NUMBER(2) not null,
  DEP_ID	    NUMBER(2) not null,
  SCORING_DATE_TIME DATE not null,
  S1                NUMBER(1),
  S2                NUMBER(1),
  S3                NUMBER(1),
  S4                NUMBER(2),
  S5                NUMBER(1),
  S6                NUMBER(1),
  S7                NUMBER(1),
  S8                NUMBER(1),
  S9                NUMBER(1),
  S10               NUMBER(1),
  S11               NUMBER(1),
  S12               NUMBER(1),
  S13               NUMBER(1),
  S14               NUMBER(2),
  S15               NUMBER(1),
  S16               NUMBER(1),
  S17               NUMBER(1)
)
;
alter table MED_EURO_SCORING
  add constraint PK_EURO_SCORING primary key (PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME);
 
grant select, insert, update, delete on MED_EURO_SCORING to ROLE_DOCARE;
prompt
prompt Creating table MED_ACTIVE_USERS
prompt ===============================
prompt
create table MED_ACTIVE_USERS
(
  USER_NAME    VARCHAR2(30) not null,
  USER_IP      VARCHAR2(50),
  FEATURE_CODE VARCHAR2(50),
  TIME_TO_LIVE NUMBER(10)
)
;
alter table MED_ACTIVE_USERS
  add constraint PK_MED_ACTIVE_USERS primary key (USER_NAME);
grant select, insert, update, delete on MED_ACTIVE_USERS to ROLE_DOCARE;

prompt
prompt Creating table MED_AILMENTDIAGNOSIS
prompt ===================================
prompt
create table MED_AILMENTDIAGNOSIS
(
  GUID               VARCHAR2(40) not null,
  PATIENT_ID         VARCHAR2(20) not null,
  VISIT_ID           NUMBER(2) not null,
  DEP_ID	     NUMBER(2) not null,
  AILMENT_NAME       VARCHAR2(30) not null,
  CREATEDATETIME     DATE,
  LASTUPDATEDATETIME DATE
)
;
alter table MED_AILMENTDIAGNOSIS
  add constraint PRIMARYKEY primary key (PATIENT_ID, VISIT_ID, DEP_ID, AILMENT_NAME);
grant select, insert, update, delete on MED_AILMENTDIAGNOSIS to ROLE_DOCARE;
prompt
prompt Creating table MED_AILMENTDIAGNOSIS_DETAIL
prompt ==========================================
prompt
create table MED_AILMENTDIAGNOSIS_DETAIL
(
  GUID        VARCHAR2(40) not null,
  QUESTION    VARCHAR2(100) not null,
  CONTENT     VARCHAR2(400),
  CONTROLTYPE VARCHAR2(200),
  CONTROLNAME VARCHAR2(600),
  CONTROLTAG  VARCHAR2(10)
)
;
alter table MED_AILMENTDIAGNOSIS_DETAIL
  add constraint KEY primary key (GUID, QUESTION);

prompt
prompt Creating table MED_APACHE2_SCORING_RESULT
prompt =========================================
prompt
create table MED_APACHE2_SCORING_RESULT
(
  PATIENT_ID        VARCHAR2(20) not null,
  VISIT_ID          NUMBER(2) not null,
  DEP_ID	    NUMBER(2) not null,
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
  MEMO              VARCHAR2(100),
  JI_ZHEN_OPER      NUMBER(1),
  NO_OPER_PAT 	    VARCHAR2(80),
  AFTER_OPER_PAT    VARCHAR2(80)
)
;
alter table MED_APACHE2_SCORING_RESULT
  add constraint PK_APACHE2_SCORING_RESULT primary key (PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME);
grant select, insert, update, delete on MED_APACHE2_SCORING_RESULT to ROLE_DOCARE;

prompt
prompt Creating table MED_APGAR_SCORING_RESULT
prompt =======================================
prompt
create table MED_APGAR_SCORING_RESULT
(
  PATIENT_ID        VARCHAR2(20) not null,
  VISIT_ID          NUMBER(2) not null,
  DEP_ID	    NUMBER(2) not null,
  SCORING_DATE_TIME DATE not null,
  S1                NUMBER(1),
  S2                NUMBER(1),
  S3                NUMBER(1),
  S4                NUMBER(1),
  S5                NUMBER(1),
  MEMO              VARCHAR2(100)
)
;
alter table MED_APGAR_SCORING_RESULT
  add constraint PK_APGAR_RESULT primary key (PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME);
grant select, insert, update, delete on MED_APGAR_SCORING_RESULT to ROLE_DOCARE;

prompt
prompt Creating table MED_BALTHAZAR_SCORING_RESULT
prompt ===========================================
prompt
create table MED_BALTHAZAR_SCORING_RESULT
(
  PATIENT_ID        VARCHAR2(20) not null,
  VISIT_ID          NUMBER(2) not null,
  DEP_ID	    NUMBER(2) not null,
  SCORING_DATE_TIME DATE not null,
  S1                NUMBER(1),
  S2                NUMBER(1),
  MEMO              VARCHAR2(100)
)
;
alter table MED_BALTHAZAR_SCORING_RESULT
  add constraint PK_BALTHAZAR primary key (PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME);
grant select, insert, update, delete on MED_BALTHAZAR_SCORING_RESULT to ROLE_DOCARE;

prompt
prompt Creating table MED_BED_CHANGED_REC
prompt ==================================
prompt
create table MED_BED_CHANGED_REC
(
  PATIENT_ID        VARCHAR2(20) not null,
  VISIT_ID          NUMBER(2) not null,
  DEP_ID	    NUMBER(2) not null,
  WARD_CODE         VARCHAR2(8) not null,
  CHANGED_DATE_TIME DATE not null,
  BED_NO            VARCHAR2(20),
  DOCTOR_IN_CHARGE  VARCHAR2(8),
  DIAGNOSIS         VARCHAR2(80)
)
;
alter table MED_BED_CHANGED_REC
  add constraint PK_MED_BED_CHANGED_REC primary key (PATIENT_ID, VISIT_ID, DEP_ID, WARD_CODE, CHANGED_DATE_TIME);
grant select, insert, update, delete on MED_BED_CHANGED_REC to ROLE_DOCARE;

prompt
prompt Creating table MED_BLOOD_TRANS_REC
prompt ==================================
prompt
create table MED_BLOOD_TRANS_REC
(
  PATIENT_ID      VARCHAR2(20) not null,
  VISIT_ID        NUMBER(2) not null,
  DEP_ID	  NUMBER(2) not null,
  RECORDING_DATE  DATE not null,
  TIME_POINT      DATE not null,
  TRANS_INDICATOR NUMBER(1),
  OPERATOR        VARCHAR2(30),
  LOG_DATE_TIME   DATE
)
;
alter table MED_BLOOD_TRANS_REC
  add constraint PK_MED_BLOOD_TRANS_REC primary key (PATIENT_ID, VISIT_ID, DEP_ID, RECORDING_DATE, TIME_POINT);
grant select, insert, update, delete on MED_BLOOD_TRANS_REC to ROLE_DOCARE;
grant select, insert, update, delete on MED_BLOOD_TRANS_REC to medcomm with grant option;

prompt
prompt Creating table MED_BREATH_CURVE_FOR_PATIENT
prompt ===========================================
prompt
create table MED_BREATH_CURVE_FOR_PATIENT
(
  PATIENT_ID  VARCHAR2(20) not null,
  ITEM_NAME   VARCHAR2(20) not null,
  VALUE_TYPE  NUMBER(1),
  CURVE_TYPE  NUMBER(2),
  SYMBOL_TYPE NUMBER(2),
  ITEM_COLOR  NUMBER(10),
  FILL_COLOR  NUMBER(10)
)
;
alter table MED_BREATH_CURVE_FOR_PATIENT
  add constraint PK_BREATH_CURVE_FOR_PATIENT primary key (PATIENT_ID, ITEM_NAME);
grant select, insert, update, delete on MED_BREATH_CURVE_FOR_PATIENT to ROLE_DOCARE;

prompt
prompt Creating table MED_CG_SCORING_RESULT_DETAIL
prompt ===========================================
prompt
create table MED_CG_SCORING_RESULT_DETAIL
(
  PATIENT_ID        VARCHAR2(20) not null,
  VISIT_ID          NUMBER(2) not null,
  DEP_ID	    NUMBER(2) not null,
  SCORING_DATE_TIME DATE not null,
  S1                NUMBER,
  S2                NUMBER,
  S3                NUMBER,
  S4                NUMBER,
  MEMO              VARCHAR2(100)
)
;
alter table MED_CG_SCORING_RESULT_DETAIL
  add constraint PK_CG_SCORING primary key (PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME);
grant select, insert, update, delete on MED_CG_SCORING_RESULT_DETAIL to ROLE_DOCARE;

prompt
prompt Creating table MED_CHILDPUGH_SCORING_RESULT
prompt ===========================================
prompt
create table MED_CHILDPUGH_SCORING_RESULT
(
  PATIENT_ID        VARCHAR2(20) not null,
  VISIT_ID          NUMBER(2) not null,
  DEP_ID	    NUMBER(2) not null,
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
alter table MED_CHILDPUGH_SCORING_RESULT
  add constraint PK_CHILDPUGH primary key (PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME);
grant select, insert, update, delete on MED_CHILDPUGH_SCORING_RESULT to ROLE_DOCARE;

prompt
prompt Creating table MED_CONTRAST_GRAPH
prompt =================================
prompt
create table MED_CONTRAST_GRAPH
(
  CONTRAST_GRAPH_NAME VARCHAR2(100) not null,
  KEY_X               VARCHAR2(40),
  KEY_X_STEP          NUMBER(3,2),
  KEY_Y               VARCHAR2(100),
  KEY_Y_STEP          VARCHAR2(100),
  KEY_X_INIT_VALUE    NUMBER(5,2),
  KEY_Y_INIT_VALUE    VARCHAR2(100)
)
;
alter table MED_CONTRAST_GRAPH
  add constraint PRIMARY_CONTRAST_GRAPH primary key (CONTRAST_GRAPH_NAME);
grant select, insert, update, delete on MED_CONTRAST_GRAPH to ROLE_DOCARE;

prompt
prompt Creating table MED_CONTRAST_GRAPH_DETAIL
prompt ========================================
prompt
create table MED_CONTRAST_GRAPH_DETAIL
(
  ITEM_NAME           VARCHAR2(100) not null,
  VALUE               NUMBER(7,2),
  PATIENT_ID          VARCHAR2(20) not null,
  VISIT_ID            NUMBER(2) not null,
  DEP_ID	      NUMBER(2) not null,
  LOG_DATETIME        DATE not null,
  CONTRAST_GRAPH_NAME VARCHAR2(100) not null
)
;
alter table MED_CONTRAST_GRAPH_DETAIL
  add constraint PRIMARY_CONTRAST_GRAPH_DETAIL primary key (ITEM_NAME, PATIENT_ID, VISIT_ID, DEP_ID, LOG_DATETIME, CONTRAST_GRAPH_NAME);
grant select, insert, update, delete on MED_CONTRAST_GRAPH_DETAIL to ROLE_DOCARE;

prompt
prompt Creating table MED_CRAMS_SCORING_RESULT
prompt =======================================
prompt
create table MED_CRAMS_SCORING_RESULT
(
  PATIENT_ID        VARCHAR2(20) not null,
  VISIT_ID          NUMBER(2) not null,
  DEP_ID	    NUMBER(2) not null,
  SCORING_DATE_TIME DATE not null,
  CIRCLE_STATUS     NUMBER,
  BREATH_STATUS     NUMBER,
  BREAST_STATUS     NUMBER,
  LIMB_STATUS       NUMBER,
  TALK_STATUS       NUMBER,
  MEMO              VARCHAR2(100)
)
;
alter table MED_CRAMS_SCORING_RESULT
  add constraint PK_CRAMS_SCORING primary key (PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME);
grant select, insert, update, delete on MED_CRAMS_SCORING_RESULT to ROLE_DOCARE;

prompt
prompt Creating table MED_CRIB_SCORING_RESULT_DETAIL
prompt =============================================
prompt
create table MED_CRIB_SCORING_RESULT_DETAIL
(
  PATIENT_ID        VARCHAR2(20) not null,
  VISIT_ID          NUMBER not null,
  DEP_ID	    NUMBER(2) not null,
  SCORING_DATE_TIME DATE not null,
  S1                NUMBER,
  S2                NUMBER,
  S3                NUMBER,
  S4                NUMBER,
  S5                NUMBER,
  MEMO              VARCHAR2(100)
)
;
alter table MED_CRIB_SCORING_RESULT_DETAIL
  add constraint PK_CRIB_SCORING primary key (PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME);
grant select, insert, update, delete on MED_CRIB_SCORING_RESULT_DETAIL to ROLE_DOCARE;

prompt
prompt Creating table MED_CSSS_SCORING_RESULT_DETAIL
prompt =============================================
prompt
create table MED_CSSS_SCORING_RESULT_DETAIL
(
  PATIENT_ID        VARCHAR2(20) not null,
  VISIT_ID          NUMBER not null,
  DEP_ID	    NUMBER(2) not null,
  SCORING_DATE_TIME DATE not null,
  S1                NUMBER,
  S2                NUMBER,
  S3                NUMBER,
  S41               NUMBER,
  S42               NUMBER,
  S43               NUMBER,
  S5                NUMBER,
  S6                NUMBER,
  S7                NUMBER,
  S8                NUMBER,
  S9                NUMBER,
  S10               NUMBER,
  S11               NUMBER,
  S12               NUMBER,
  S13               NUMBER,
  S14               NUMBER,
  S151              NUMBER,
  S152              NUMBER,
  S153              NUMBER,
  S154              NUMBER,
  S155              NUMBER,
  S161              NUMBER,
  S162              NUMBER,
  S163              NUMBER,
  MEMO              VARCHAR2(100)
)
;
comment on table MED_CSSS_SCORING_RESULT_DETAIL
  is '感染评分csss';
alter table MED_CSSS_SCORING_RESULT_DETAIL
  add constraint PK_MED_CSSS primary key (PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME);
grant select, insert, update, delete on MED_CSSS_SCORING_RESULT_DETAIL to ROLE_DOCARE;

prompt
prompt Creating table MED_DEPT_LOAD_DAY
prompt ================================
prompt
create table MED_DEPT_LOAD_DAY
(
  ST_DATE        DATE not null,
  DEPT_CODE      VARCHAR2(8) not null,
  CRITICAL_NUM   NUMBER(4),
  SPEC_NURS_NUM  NUMBER(4),
  FIRST_NURS_NUM NUMBER(4)
)
;
comment on table MED_DEPT_LOAD_DAY
  is '这个表不明确';
alter table MED_DEPT_LOAD_DAY
  add constraint PK_MED_DEPT_LOAD_DAY primary key (ST_DATE, DEPT_CODE);
grant select, insert, update, delete on MED_DEPT_LOAD_DAY to ROLE_DOCARE;

prompt
prompt Creating table MED_DUTY_REC
prompt ===========================
prompt
create table MED_DUTY_REC
(
  EMP_NO          VARCHAR2(6) not null,
  NURSE_NAME      VARCHAR2(30),
  SCHEDULE_NAME   VARCHAR2(8) not null,
  START_DATE_TIME DATE,
  END_DATE_TIME   DATE
)
;
comment on table MED_DUTY_REC
  is '考勤记录';
comment on column MED_DUTY_REC.EMP_NO
  is '护士编号';
comment on column MED_DUTY_REC.NURSE_NAME
  is '护士姓名';
comment on column MED_DUTY_REC.SCHEDULE_NAME
  is '班次名称';
comment on column MED_DUTY_REC.START_DATE_TIME
  is '上班时间';
comment on column MED_DUTY_REC.END_DATE_TIME
  is '下班时间';
alter table MED_DUTY_REC
  add constraint PK_MED_DUTY_REC primary key (EMP_NO, SCHEDULE_NAME);
grant select, insert, update, delete on MED_DUTY_REC to ROLE_DOCARE;

prompt
prompt Creating table MED_DUTY_TRANS_REC
prompt =================================
prompt
create table MED_DUTY_TRANS_REC
(
  WARD_CODE       VARCHAR2(8) not null,
  PATIENT_ID      VARCHAR2(20) not null,
  VISIT_ID        NUMBER(2) not null,
  DEP_ID	  NUMBER(2) not null,
  TRANS_DATE_TIME DATE not null,
  SCHEDULE_NAME   VARCHAR2(8) not null,
  NURSE_IN_OFF    VARCHAR2(30),
  NURSE_IN_CHARGE VARCHAR2(30),
  TRANS_DETAIL    VARCHAR2(800),
  ACTION_DESC     VARCHAR2(10),
  DIAG_NAME       VARCHAR2(80),
  LOG_DATE_TIME   DATE
)
;
comment on table MED_DUTY_TRANS_REC
  is '交班记录';
comment on column MED_DUTY_TRANS_REC.WARD_CODE
  is '病房代码';
comment on column MED_DUTY_TRANS_REC.PATIENT_ID
  is '病人ID';
comment on column MED_DUTY_TRANS_REC.VISIT_ID
  is '病人本次住院标识';
comment on column MED_DUTY_TRANS_REC.TRANS_DATE_TIME
  is '交班日期';
comment on column MED_DUTY_TRANS_REC.SCHEDULE_NAME
  is '班次名称';
comment on column MED_DUTY_TRANS_REC.NURSE_IN_OFF
  is '交班护士';
comment on column MED_DUTY_TRANS_REC.NURSE_IN_CHARGE
  is '接班护士';
comment on column MED_DUTY_TRANS_REC.TRANS_DETAIL
  is '交班内容';
comment on column MED_DUTY_TRANS_REC.ACTION_DESC
  is '操作提示';
comment on column MED_DUTY_TRANS_REC.DIAG_NAME
  is '诊断';
comment on column MED_DUTY_TRANS_REC.LOG_DATE_TIME
  is '记录时间';
alter table MED_DUTY_TRANS_REC
  add constraint PK_DUTY_TRANS_REC primary key (WARD_CODE, PATIENT_ID, VISIT_ID, DEP_ID, TRANS_DATE_TIME, SCHEDULE_NAME);
grant select, insert, update, delete on MED_DUTY_TRANS_REC to ROLE_DOCARE;

prompt
prompt Creating table MED_GCS_SCORING_RESULT_DETAIL
prompt ============================================
prompt
create table MED_GCS_SCORING_RESULT_DETAIL
(
  PATIENT_ID        VARCHAR2(20) not null,
  VISIT_ID          NUMBER(2) not null,
  DEP_ID	    NUMBER(2) not null,
  SCORING_DATE_TIME DATE not null,
  EYES_REFLECT      NUMBER,
  TALK_REFLECT      NUMBER,
  LIMB_REFLECT      NUMBER,
  MEMO              VARCHAR2(100)
)
;
comment on table MED_GCS_SCORING_RESULT_DETAIL
  is 'GCS评分结果明细';
comment on column MED_GCS_SCORING_RESULT_DETAIL.EYES_REFLECT
  is '睁眼反应';
comment on column MED_GCS_SCORING_RESULT_DETAIL.TALK_REFLECT
  is '语言反应';
comment on column MED_GCS_SCORING_RESULT_DETAIL.LIMB_REFLECT
  is '运动反应';
alter table MED_GCS_SCORING_RESULT_DETAIL
  add constraint PK_GCS_SCORING primary key (PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME);
grant select, insert, update, delete on MED_GCS_SCORING_RESULT_DETAIL to ROLE_DOCARE;

prompt
prompt Creating table MED_GOLDMAN_SCORING_RESULT
prompt =========================================
prompt
create table MED_GOLDMAN_SCORING_RESULT
(
  PATIENT_ID        VARCHAR2(20) not null,
  VISIT_ID          NUMBER(2) not null,
  DEP_ID	    NUMBER(2) not null,
  SCORING_DATE_TIME DATE not null,
  S1                NUMBER(2),
  S2				NUMBER(1),
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
comment on table MED_GOLDMAN_SCORING_RESULT
  is 'GOLDMAN麻醉评分';
comment on column MED_GOLDMAN_SCORING_RESULT.S1
  is '年龄>70岁';
comment on column MED_GOLDMAN_SCORING_RESULT.S3
  is '6个月以内心肌梗死';
comment on column MED_GOLDMAN_SCORING_RESULT.S4
  is 'S3奔马率和颈静脉怒张';
comment on column MED_GOLDMAN_SCORING_RESULT.S5
  is '重度主动脉狭窄';
comment on column MED_GOLDMAN_SCORING_RESULT.S6
  is 'ECG显示非窦性心律伙房室性前收缩';
comment on column MED_GOLDMAN_SCORING_RESULT.S7
  is '房室前收缩5次/分';
comment on column MED_GOLDMAN_SCORING_RESULT.S8
  is '全身情况';
comment on column MED_GOLDMAN_SCORING_RESULT.S9
  is '腹腔、胸腔或主动脉手术';
comment on column MED_GOLDMAN_SCORING_RESULT.MEMO
  is '急症手术';
alter table MED_GOLDMAN_SCORING_RESULT
  add constraint PK_GOLDMAN primary key (PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME);
grant select, insert, update, delete on MED_GOLDMAN_SCORING_RESULT to ROLE_DOCARE;

prompt
prompt Creating table MED_GP_SCORING_RESULT_DETAIL
prompt ===========================================
prompt
create table MED_GP_SCORING_RESULT_DETAIL
(
  PATIENT_ID        VARCHAR2(20) not null,
  VISIT_ID          NUMBER(2) not null,
  DEP_ID	    NUMBER(2) not null,
  SCORING_DATE_TIME DATE not null,
  S1                NUMBER,
  S2                NUMBER,
  S3                NUMBER,
  S4                NUMBER,
  S5                NUMBER,
  S6                NUMBER,
  S7                NUMBER,
  MEMO              VARCHAR2(100)
)
;
comment on table MED_GP_SCORING_RESULT_DETAIL
  is 'johns嗜睡程度评分结果明细表';
comment on column MED_GP_SCORING_RESULT_DETAIL.PATIENT_ID
  is '病人ID';
comment on column MED_GP_SCORING_RESULT_DETAIL.VISIT_ID
  is '病人本次住院标识';
comment on column MED_GP_SCORING_RESULT_DETAIL.SCORING_DATE_TIME
  is '记录时间';
comment on column MED_GP_SCORING_RESULT_DETAIL.S1
  is '睁眼动作';
comment on column MED_GP_SCORING_RESULT_DETAIL.S2
  is '言语反应';
comment on column MED_GP_SCORING_RESULT_DETAIL.S3
  is '运动反应';
comment on column MED_GP_SCORING_RESULT_DETAIL.S4
  is '瞳孔光反应';
comment on column MED_GP_SCORING_RESULT_DETAIL.S5
  is '脑干反射';
comment on column MED_GP_SCORING_RESULT_DETAIL.S6
  is '抽搐';
comment on column MED_GP_SCORING_RESULT_DETAIL.S7
  is '自发性呼吸';
comment on column MED_GP_SCORING_RESULT_DETAIL.MEMO
  is '备注';
alter table MED_GP_SCORING_RESULT_DETAIL
  add constraint PK_MEMO primary key (PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME);
grant select, insert, update, delete on MED_GP_SCORING_RESULT_DETAIL to ROLE_DOCARE;

prompt
prompt Creating table MED_IN_OR_OUT_REC
prompt ================================
prompt
create table MED_IN_OR_OUT_REC
(
  PATIENT_ID         VARCHAR2(20) not null,
  VISIT_ID           NUMBER(2) not null,
  DEP_ID	     NUMBER(2) not null,
  RECORDING_DATE     DATE not null,
  TIME_POINT         DATE not null,
  VITAL_SIGNS        VARCHAR2(200) not null,
  ORDER_NO           VARCHAR2(20) not null,
  ORDER_SUB_NO       NUMBER(12) not null,
  ORDER_ATTR         VARCHAR2(8),
  DOSAGE             VARCHAR2(20),
  ADMINISTRATION     VARCHAR2(30),
  VITAL_SIGNS_VALUES NUMBER(8,2),
  UNITS              VARCHAR2(10),
  IN_OR_OUT          NUMBER(1),
  PERFORM_SPEED      NUMBER(8,4),
  SPEED_UNIT         VARCHAR2(10),
  OPERATOR           VARCHAR2(30),
  LOG_DATE_TIME      DATE,
  DEFAULT_TIME_POINT DATE,
  DUTY_NAME          VARCHAR2(8),
  DUTY_DATE          DATE,
  ITEM_NO            NUMBER(2),
  ORDER_ABBR         VARCHAR2(20),
  SKINRESPONSE       VARCHAR2(20),
  INJECTIONSITE      VARCHAR2(40),
  VEINVESSEL         VARCHAR2(4),
  MEMO	 VARCHAR2(200)
)
;
alter table MED_IN_OR_OUT_REC
  add constraint PK_MED_IN_OR_OUT_REC primary key (PATIENT_ID, VISIT_ID, DEP_ID, RECORDING_DATE, TIME_POINT, ORDER_NO, VITAL_SIGNS, ORDER_SUB_NO);
grant select, insert, update, delete on MED_IN_OR_OUT_REC to ROLE_DOCARE;
grant select, insert, update, delete on MED_IN_OR_OUT_REC to medcomm with grant option;

prompt
prompt Creating table MED_JOHNS_SCORING_RESULT
prompt =======================================
prompt
create table MED_JOHNS_SCORING_RESULT
(
  PATIENT_ID        VARCHAR2(20) not null,
  VISIT_ID          NUMBER(2) not null,
  DEP_ID	    NUMBER(2) not null,
  SCORING_DATE_TIME DATE not null,
  S1                NUMBER,
  S2                NUMBER,
  S3                NUMBER,
  S4                NUMBER,
  S5                NUMBER,
  S6                NUMBER,
  S7                NUMBER,
  S8		    NUMBER,
  MEMO              VARCHAR2(100)
)
;
alter table MED_JOHNS_SCORING_RESULT
  add constraint PK_JOHNS_SCORING primary key (PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME);
grant select, insert, update, delete on MED_JOHNS_SCORING_RESULT to ROLE_DOCARE;

prompt
prompt Creating table MED_LUTZ_SCORING_RESULT
prompt ======================================
prompt
create table MED_LUTZ_SCORING_RESULT
(
  PATIENT_ID        VARCHAR2(20) not null,
  VISIT_ID          NUMBER(2) not null,
  DEP_ID	    NUMBER(2) not null,
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
  S10               NUMBER(1),
  S11               NUMBER(1),
  S12               NUMBER(1),
  S13               NUMBER(1),
  S14               NUMBER(1),
  S15               NUMBER(1),
  MEMO              VARCHAR2(100)
)
;
alter table MED_LUTZ_SCORING_RESULT
  add constraint PK_LUTZ_SCORING_RESULT primary key (PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME);
grant select, insert, update, delete on MED_LUTZ_SCORING_RESULT to ROLE_DOCARE;

prompt
prompt Creating table MED_MODS2_SCORING_DETAIL
prompt =======================================
prompt
create table MED_MODS2_SCORING_DETAIL
(
  PATIENT_ID        VARCHAR2(20) not null,
  VISIT_ID          NUMBER(2) not null,
  DEP_ID	    NUMBER(2) not null,
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
alter table MED_MODS2_SCORING_DETAIL
  add constraint PK_MED_MODS2_SCORING_DETAIL primary key (PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME);
grant select, insert, update, delete on MED_MODS2_SCORING_DETAIL to ROLE_DOCARE;

prompt
prompt Creating table MED_MODS_SCORING_RESULT_DETAIL
prompt =============================================
prompt
create table MED_MODS_SCORING_RESULT_DETAIL
(
  PATIENT_ID        VARCHAR2(20) not null,
  VISIT_ID          NUMBER(2) not null,
  DEP_ID	    NUMBER(2) not null,
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
alter table MED_MODS_SCORING_RESULT_DETAIL
  add constraint PK_MODS_SCORING_RESULT primary key (PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME);
grant select, insert, update, delete on MED_MODS_SCORING_RESULT_DETAIL to ROLE_DOCARE;

prompt
prompt Creating table MED_MONITOR_ABNORMAL_DATA_DICT
prompt =============================================
prompt
create table MED_MONITOR_ABNORMAL_DATA_DICT
(
  MONITOR_DATA_NAME VARCHAR2(40),
  DB_DATA_NAME      VARCHAR2(40) not null,
  LOW_SIGNS_VALUES  NUMBER(6,2),
  HIGH_SIGNS_VALUES NUMBER(6,2)
)
;
alter table MED_MONITOR_ABNORMAL_DATA_DICT
  add constraint PK_MONITOR_ABNORMAL_DATA_DICT primary key (DB_DATA_NAME);
grant select, insert, update, delete on MED_MONITOR_ABNORMAL_DATA_DICT to ROLE_DOCARE;

prompt
prompt Creating table MED_NORT_SCORING_RESULT_DETAIL
prompt =============================================
prompt
create table MED_NORT_SCORING_RESULT_DETAIL
(
  PATIENT_ID        VARCHAR2(20) not null,
  VISIT_ID          NUMBER(2) not null,
  DEP_ID	    NUMBER(2) not null,
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
comment on table MED_NORT_SCORING_RESULT_DETAIL
  is 'NORT感染评分表';
comment on column MED_NORT_SCORING_RESULT_DETAIL.PATIENT_ID
  is '病人ID';
comment on column MED_NORT_SCORING_RESULT_DETAIL.VISIT_ID
  is '病人本次住院标识';
comment on column MED_NORT_SCORING_RESULT_DETAIL.SCORING_DATE_TIME
  is '记录时间';
comment on column MED_NORT_SCORING_RESULT_DETAIL.S1
  is '坐着看书';
comment on column MED_NORT_SCORING_RESULT_DETAIL.S2
  is '看电视';
comment on column MED_NORT_SCORING_RESULT_DETAIL.S3
  is '坐在公共场所';
comment on column MED_NORT_SCORING_RESULT_DETAIL.S4
  is '作为乘客坐在汽车1H内';
comment on column MED_NORT_SCORING_RESULT_DETAIL.S5
  is '环境允许下午躺下';
comment on column MED_NORT_SCORING_RESULT_DETAIL.S6
  is '与人谈话中';
comment on column MED_NORT_SCORING_RESULT_DETAIL.S7
  is '未饮酒午饭后安静坐着';
comment on column MED_NORT_SCORING_RESULT_DETAIL.S8
  is '作为司机开车时在等红灯数十秒内';
comment on column MED_NORT_SCORING_RESULT_DETAIL.S9
  is ' 依从性';
alter table MED_NORT_SCORING_RESULT_DETAIL
  add constraint PK_NORTON primary key (PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME);
grant select, insert, update, delete on MED_NORT_SCORING_RESULT_DETAIL to ROLE_DOCARE;

prompt
prompt Creating table MED_NURSE_LEAVE_LOG
prompt ==================================
prompt
create table MED_NURSE_LEAVE_LOG
(
  EMP_NO       VARCHAR2(6) not null,
  NURSE_NAME   VARCHAR2(30),
  LEAVE_DATE   DATE not null,
  LEAVE_TYPE   VARCHAR2(10),
  LEAVE_REASON VARCHAR2(20),
  BACK_DATE    DATE
)
;
comment on table MED_NURSE_LEAVE_LOG
  is '护理人员离位登记';
comment on column MED_NURSE_LEAVE_LOG.EMP_NO
  is '护士编号';
comment on column MED_NURSE_LEAVE_LOG.NURSE_NAME
  is '护士姓名';
comment on column MED_NURSE_LEAVE_LOG.LEAVE_DATE
  is '离位时间';
comment on column MED_NURSE_LEAVE_LOG.LEAVE_TYPE
  is '离位类型';
comment on column MED_NURSE_LEAVE_LOG.LEAVE_REASON
  is '离位原因';
comment on column MED_NURSE_LEAVE_LOG.BACK_DATE
  is '回位时间';
alter table MED_NURSE_LEAVE_LOG
  add constraint PK_MED_NURSE_LEAVE_LOG primary key (EMP_NO, LEAVE_DATE);
grant select, insert, update, delete on MED_NURSE_LEAVE_LOG to ROLE_DOCARE;

prompt
prompt Creating table MED_NURSE_PAGE_REC
prompt =================================
prompt
create table MED_NURSE_PAGE_REC
(
  PATIENT_ID     VARCHAR2(20) not null,
  VISIT_ID       NUMBER(2) not null,
  DEP_ID	 NUMBER(2) not null,
  RECORDING_DATE DATE not null,
  PAGES          NUMBER(5)
)
;
comment on table MED_NURSE_PAGE_REC
  is '特护单打印页码记录表';
comment on column MED_NURSE_PAGE_REC.PATIENT_ID
  is '病人标识号';
comment on column MED_NURSE_PAGE_REC.VISIT_ID
  is '病人本次住院标识';
comment on column MED_NURSE_PAGE_REC.RECORDING_DATE
  is '日期';
comment on column MED_NURSE_PAGE_REC.PAGES
  is '总页数';
alter table MED_NURSE_PAGE_REC
  add constraint PK_MED_NURSE_PAGE_REC primary key (PATIENT_ID, VISIT_ID, DEP_ID, RECORDING_DATE);
grant select, insert, update, delete on MED_NURSE_PAGE_REC to ROLE_DOCARE;

prompt
prompt Creating table MED_NURSE_SCHEDULE
prompt =================================
prompt
create table MED_NURSE_SCHEDULE
(
  WARD_CODE     VARCHAR2(8) not null,
  SERIAL_NO     NUMBER(8) not null,
  EMP_NO        VARCHAR2(6),
  NURSE_NAME    VARCHAR2(8),
  NURSE_TYPE    VARCHAR2(8),
  DATE_OF_WORK  DATE not null,
  SCHEDULE_TYPE VARCHAR2(10)
)
;
comment on table MED_NURSE_SCHEDULE
  is '护理人员排班表';
comment on column MED_NURSE_SCHEDULE.WARD_CODE
  is '病房代码';
comment on column MED_NURSE_SCHEDULE.SERIAL_NO
  is '序号';
comment on column MED_NURSE_SCHEDULE.EMP_NO
  is '护士编号';
comment on column MED_NURSE_SCHEDULE.NURSE_NAME
  is '护士姓名';
comment on column MED_NURSE_SCHEDULE.NURSE_TYPE
  is '护士类别';
comment on column MED_NURSE_SCHEDULE.DATE_OF_WORK
  is '当班日期';
comment on column MED_NURSE_SCHEDULE.SCHEDULE_TYPE
  is '班次';
alter table MED_NURSE_SCHEDULE
  add constraint PK_NURSE_SCHEDULE primary key (WARD_CODE, DATE_OF_WORK, SERIAL_NO);
grant select, insert, update, delete on MED_NURSE_SCHEDULE to ROLE_DOCARE;

prompt
prompt Creating table MED_NURSE_SCHEDULE_REM
prompt =====================================
prompt
create table MED_NURSE_SCHEDULE_REM
(
  WARD_CODE      VARCHAR2(8) not null,
  DATE_OF_MONDAY DATE not null,
  CONTENT        VARCHAR2(200)
)
;
comment on table MED_NURSE_SCHEDULE_REM
  is '护理人员排班表';
comment on column MED_NURSE_SCHEDULE_REM.WARD_CODE
  is '病房代码';
comment on column MED_NURSE_SCHEDULE_REM.DATE_OF_MONDAY
  is '星期一开始时间';
comment on column MED_NURSE_SCHEDULE_REM.CONTENT
  is '备注内容';
alter table MED_NURSE_SCHEDULE_REM
  add constraint PK_MED_NURSE_SCHEDULE_REM primary key (WARD_CODE, DATE_OF_MONDAY);
grant select, insert, update, delete on MED_NURSE_SCHEDULE_REM to ROLE_DOCARE;

prompt
prompt Creating table MED_NURSING_PLAN_DETAIL
prompt ======================================
prompt
create table MED_NURSING_PLAN_DETAIL
(
  PATIENT_ID       VARCHAR2(20) not null,
  VISIT_ID         NUMBER(2) not null,
  DEP_ID	   NUMBER(2) not null,
  CREATE_PLAN_DATE DATE not null,
  PLAN_CLASS       VARCHAR2(20) not null,
  ITEM_NO          NUMBER(2) not null,
  PLAN_DESC        VARCHAR2(500)
)
;
comment on table MED_NURSING_PLAN_DETAIL
  is '护理计划明细记录';
comment on column MED_NURSING_PLAN_DETAIL.PATIENT_ID
  is '病人ID';
comment on column MED_NURSING_PLAN_DETAIL.VISIT_ID
  is '病人住院标识';
comment on column MED_NURSING_PLAN_DETAIL.CREATE_PLAN_DATE
  is '制定日期';
comment on column MED_NURSING_PLAN_DETAIL.PLAN_CLASS
  is '计划类别';
comment on column MED_NURSING_PLAN_DETAIL.ITEM_NO
  is '序号';
comment on column MED_NURSING_PLAN_DETAIL.PLAN_DESC
  is '内容';
alter table MED_NURSING_PLAN_DETAIL
  add constraint PK_MED_NURSING_PLAN_DETAIL primary key (PATIENT_ID, VISIT_ID, DEP_ID, CREATE_PLAN_DATE, PLAN_CLASS, ITEM_NO);
grant select, insert, update, delete on MED_NURSING_PLAN_DETAIL to ROLE_DOCARE;

prompt
prompt Creating table MED_NURSING_PLAN_MASTER
prompt ======================================
prompt
create table MED_NURSING_PLAN_MASTER
(
  PATIENT_ID         VARCHAR2(20) not null,
  VISIT_ID           NUMBER(2) not null,
  DEP_ID	     NUMBER(2) not null,
  MR_DESC            VARCHAR2(2000),
  NURSE_IN_OPERATE   VARCHAR2(30),
  NURSE_IN_CHARGE    VARCHAR2(30),
  NURSE_IN_GROUP     VARCHAR2(30),
  NURSE_IN_DIRECATOR VARCHAR2(30),
  CREATE_PLAN_DATE   DATE not null,
  OPERATOR           VARCHAR2(30),
  ENTER_DATE         DATE
)
;
comment on table MED_NURSING_PLAN_MASTER
  is '护理计划主记录';
comment on column MED_NURSING_PLAN_MASTER.PATIENT_ID
  is '病人ID';
comment on column MED_NURSING_PLAN_MASTER.VISIT_ID
  is '病人住院标识';
comment on column MED_NURSING_PLAN_MASTER.MR_DESC
  is '病情摘要';
comment on column MED_NURSING_PLAN_MASTER.NURSE_IN_OPERATE
  is '当班护士';
comment on column MED_NURSING_PLAN_MASTER.NURSE_IN_CHARGE
  is '责任护士';
comment on column MED_NURSING_PLAN_MASTER.NURSE_IN_GROUP
  is '责任组长';
comment on column MED_NURSING_PLAN_MASTER.NURSE_IN_DIRECATOR
  is '护士长';
comment on column MED_NURSING_PLAN_MASTER.CREATE_PLAN_DATE
  is '制定日期';
comment on column MED_NURSING_PLAN_MASTER.OPERATOR
  is '操作员';
comment on column MED_NURSING_PLAN_MASTER.ENTER_DATE
  is '录入时间';
alter table MED_NURSING_PLAN_MASTER
  add constraint PK_NURSING_PLAN_MASTER primary key (PATIENT_ID, VISIT_ID, DEP_ID, CREATE_PLAN_DATE);
grant select, insert, update, delete on MED_NURSING_PLAN_MASTER to ROLE_DOCARE;

prompt
prompt Creating table MED_NURSING_SCHEDULE_TYPE
prompt ========================================
prompt
create table MED_NURSING_SCHEDULE_TYPE
(
  SERIAL_NO     NUMBER(2),
  WARD_CODE     VARCHAR2(8) not null,
  SCHEDULE_TYPE VARCHAR2(8) not null,
  SCHEDULE_NAME VARCHAR2(8)
)
;
comment on table MED_NURSING_SCHEDULE_TYPE
  is '班次类别描述';
comment on column MED_NURSING_SCHEDULE_TYPE.SERIAL_NO
  is '班次序号';
comment on column MED_NURSING_SCHEDULE_TYPE.WARD_CODE
  is '护理单元';
comment on column MED_NURSING_SCHEDULE_TYPE.SCHEDULE_TYPE
  is '班次类别';
comment on column MED_NURSING_SCHEDULE_TYPE.SCHEDULE_NAME
  is '班次';
alter table MED_NURSING_SCHEDULE_TYPE
  add constraint PK_MED_NURSING_SCHEDULE_TYPE primary key (WARD_CODE, SCHEDULE_TYPE);
grant select, insert, update, delete on MED_NURSING_SCHEDULE_TYPE to ROLE_DOCARE;

prompt
prompt Creating table MED_NURSING_SIGNING_REC
prompt ======================================
prompt
create table MED_NURSING_SIGNING_REC
(
  PATIENT_ID     VARCHAR2(20) not null,
  VISIT_ID       NUMBER(2) not null,
  DEP_ID	 NUMBER(2) not null,
  RECORDING_DATE DATE not null,
  TIME_POINT     DATE not null,
  WZ_INDICATOR   NUMBER(1),
  WZ_SIGN        VARCHAR2(8),
  JC_INDICATOR   NUMBER(1),
  JC_SIGN        VARCHAR2(8)
)
;
comment on table MED_NURSING_SIGNING_REC
  is '护理单签名记录';
comment on column MED_NURSING_SIGNING_REC.PATIENT_ID
  is '病人标识号';
comment on column MED_NURSING_SIGNING_REC.VISIT_ID
  is '病人住院标识';
comment on column MED_NURSING_SIGNING_REC.RECORDING_DATE
  is '记录日期';
comment on column MED_NURSING_SIGNING_REC.TIME_POINT
  is '时间点';
comment on column MED_NURSING_SIGNING_REC.WZ_INDICATOR
  is '危重单';
comment on column MED_NURSING_SIGNING_REC.WZ_SIGN
  is '危重单签名';
comment on column MED_NURSING_SIGNING_REC.JC_INDICATOR
  is '基础单';
comment on column MED_NURSING_SIGNING_REC.JC_SIGN
  is '基础单签名';
alter table MED_NURSING_SIGNING_REC
  add constraint PK_MED_NURSING_SIGNING_REC primary key (PATIENT_ID, VISIT_ID, DEP_ID, RECORDING_DATE, TIME_POINT);
grant select, insert, update, delete on MED_NURSING_SIGNING_REC to ROLE_DOCARE;

prompt
prompt Creating table MED_PARS_SCORING_RESULT
prompt ======================================
prompt
create table MED_PARS_SCORING_RESULT
(
  PATIENT_ID        VARCHAR2(20) not null,
  VISIT_ID          NUMBER(2) not null,
  DEP_ID	    NUMBER(2) not null,
  SCORING_DATE_TIME DATE not null,
  S1                NUMBER(1),
  S2                NUMBER(1),
  S3                NUMBER(1),
  S4                NUMBER(1),
  S5                NUMBER(1),
  MEMO              VARCHAR2(100)
)
;
comment on table MED_PARS_SCORING_RESULT
  is 'PARS麻醉评分';
comment on column MED_PARS_SCORING_RESULT.S1
  is '活动';
comment on column MED_PARS_SCORING_RESULT.S2
  is '呼吸';
comment on column MED_PARS_SCORING_RESULT.S3
  is '循环';
comment on column MED_PARS_SCORING_RESULT.S4
  is '意识';
comment on column MED_PARS_SCORING_RESULT.S5
  is '颜色';
comment on column MED_PARS_SCORING_RESULT.MEMO
  is '病情描述';
alter table MED_PARS_SCORING_RESULT
  add constraint PK_PARS primary key (PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME);
grant select, insert, update, delete on MED_PARS_SCORING_RESULT to ROLE_DOCARE;

prompt
prompt Creating table MED_PATIENT_ABNORMAL_DATA_REC
prompt ============================================
prompt
create table MED_PATIENT_ABNORMAL_DATA_REC
(
  PATIENT_ID        VARCHAR2(20) not null,
  NAME              VARCHAR2(30),
  TOPIC             VARCHAR2(40) not null,
  MEMO              VARCHAR2(200),
  ENTER_DATE        DATE not null,
  SENDING_INDICATOR NUMBER(1)
)
;
alter table MED_PATIENT_ABNORMAL_DATA_REC
  add constraint PK_PATIENT_ABNORMAL_DATA_REC primary key (PATIENT_ID, TOPIC, ENTER_DATE);
grant select, insert, update, delete on MED_PATIENT_ABNORMAL_DATA_REC to ROLE_DOCARE;

prompt
prompt Creating table MED_PATIENT_EQUIP_USING_REC
prompt ==========================================
prompt
create table MED_PATIENT_EQUIP_USING_REC
(
  PATIENT_ID    VARCHAR2(20) not null,
  VISIT_ID      NUMBER(2) not null,
  DEP_ID	NUMBER(2) not null,
  WARD_CODE     VARCHAR2(8) not null,
  DEPT_CODE     VARCHAR2(8),
  ITEM_NAME     VARCHAR2(10) not null,
  START_DATE    DATE not null,
  END_DATE      DATE,
  OPERATOR      VARCHAR2(30),
  LOG_DATE_TIME DATE
)
;
alter table MED_PATIENT_EQUIP_USING_REC
  add constraint PK_PATIENT_EQUIP_USING_REC primary key (PATIENT_ID, VISIT_ID, DEP_ID, WARD_CODE, ITEM_NAME, START_DATE);
grant select, insert, update, delete on MED_PATIENT_EQUIP_USING_REC to ROLE_DOCARE;

prompt
prompt Creating table MED_PATIENT_NURSING_FORM_REC
prompt ===========================================
prompt
create table MED_PATIENT_NURSING_FORM_REC
(
  PATIENT_ID 		VARCHAR2(20) not null,
  VISIT_ID   		NUMBER(2) not null,
  DEP_ID	    	NUMBER(2) not null,
  START_DATE 		DATE not null,
  END_DATE   		DATE,
  FORM_TYPE  		NUMBER(1)
)
;
alter table MED_PATIENT_NURSING_FORM_REC
  add constraint PK_PATIENT_NURSING_FORM_REC primary key (PATIENT_ID, VISIT_ID, DEP_ID, START_DATE);
grant select, insert, update, delete on MED_PATIENT_NURSING_FORM_REC to ROLE_DOCARE;

prompt
prompt Creating table MED_PATIENT_NURSING_MEMO_REC
prompt ===========================================
prompt
create table MED_PATIENT_NURSING_MEMO_REC
(
  PATIENT_ID       VARCHAR2(20) not null,
  VISIT_ID         NUMBER(2) not null,
  DEP_ID	   NUMBER(2) not null,
  RECORDING_DATE   DATE not null,
  TIME_POINT       DATE not null,
  ITEM_NO          NUMBER(2) not null,
  NURSING_DESC     VARCHAR2(1000),
  NURSE_IN_OPERATE VARCHAR2(30),
  NURSE_IN_CHARGE  VARCHAR2(30),
  LOG_DATE_TIME    DATE
)
;
alter table MED_PATIENT_NURSING_MEMO_REC
  add constraint PK_MED_PATIENT_REC primary key (PATIENT_ID, VISIT_ID, DEP_ID, RECORDING_DATE, TIME_POINT, ITEM_NO);
grant select, insert, update, delete on MED_PATIENT_NURSING_MEMO_REC to ROLE_DOCARE;
grant select, insert, update, delete on MED_PATIENT_NURSING_MEMO_REC to medcomm with grant option;

prompt
prompt Creating table MED_PATIENT_NURSING_REC
prompt ======================================
prompt
create table MED_PATIENT_NURSING_REC
(
  PATIENT_ID         VARCHAR2(20) not null,
  VISIT_ID           NUMBER(2) not null,
  DEP_ID	     NUMBER(2) not null,
  RECORDING_DATE     DATE not null,
  TIME_POINT         DATE not null,
  ORDER_NO           VARCHAR2(20) default '0',
  NURSING_TYPE       VARCHAR2(40),
  NURSING_DESC       VARCHAR2(2000),
  NURSE_IN_OPERATE   VARCHAR2(30),
  NURSE_IN_CHARGE    VARCHAR2(30),
  NURSE_IN_DIRECATOR VARCHAR2(30),
  NURSE_IN_GROUP     VARCHAR2(30),
  LOG_DATE_TIME      DATE
)
;
alter table MED_PATIENT_NURSING_REC
  add constraint PK_MED_PATIENT_NURSING_REC primary key (PATIENT_ID, VISIT_ID, DEP_ID, RECORDING_DATE, TIME_POINT,NURSING_TYPE);
grant select, insert, update, delete on MED_PATIENT_NURSING_REC to ROLE_DOCARE;
grant select, insert, update, delete on MED_PATIENT_NURSING_REC to medcomm with grant option;

prompt
prompt Creating table MED_PATIENT_NURSING_REC_LOG
prompt ==========================================
prompt
create table MED_PATIENT_NURSING_REC_LOG
(
  PATIENT_ID         VARCHAR2(20) not null,
  VISIT_ID           NUMBER(2) not null,
  DEP_ID	     NUMBER(2) not null,
  RECORDING_DATE     DATE not null,
  TIME_POINT         DATE not null,
  ORDER_NO           VARCHAR2(20) default '0' not null,
  NURSING_TYPE       VARCHAR2(20),
  NURSING_DESC       VARCHAR2(1000),
  NURSE_IN_OPERATE   VARCHAR2(30),
  NURSE_IN_CHARGE    VARCHAR2(30),
  NURSE_IN_GROUP     VARCHAR2(30),
  NURSE_IN_DIRECATOR VARCHAR2(30),
  LOG_DATE_TIME      DATE not null
)
;
alter table MED_PATIENT_NURSING_REC_LOG
  add constraint PK_PATIENT_NURSING_REC_LOG primary key (PATIENT_ID, VISIT_ID, DEP_ID, RECORDING_DATE, TIME_POINT, ORDER_NO, LOG_DATE_TIME);
grant select, insert, update, delete on MED_PATIENT_NURSING_REC_LOG to ROLE_DOCARE;
grant select, insert, update, delete on MED_PATIENT_NURSING_REC_LOG to medcomm with grant option;

prompt
prompt Creating table MED_PATIENT_ORDER_COMPL_REC
prompt ==========================================
prompt
create table MED_PATIENT_ORDER_COMPL_REC
(
  PATIENT_ID         VARCHAR2(20) not null,
  VISIT_ID           NUMBER(2) not null,
  DEP_ID	     NUMBER(2) not null,
  ORDER_NO           VARCHAR2(20) not null,
  ORDER_SUB_NO       NUMBER(12) not null,
  REPEAT_INDICATOR   NUMBER(1),
  ORDER_TEXT         VARCHAR2(200),
  FREQUENCY          VARCHAR2(30),
  PERFORM_SCHEDULE   VARCHAR2(64),
  ADMINISTRATION     VARCHAR2(30),
  DEFAULT_TIME_POINT DATE not null,
  DUTY_DATE          DATE not null,
  MEMO               VARCHAR2(400),
  MEMO_TIME_POINT    DATE,
  EXECUTE_TIME1      NUMBER(1),
  OPERATOR1          VARCHAR2(30),
  EXECUTE_TIME2      NUMBER(1),
  OPERATOR2          VARCHAR2(30),
  EXECUTE_TIME3      NUMBER(1),
  OPERATOR3          VARCHAR2(30),
  EXECUTE_TIME4      NUMBER(1),
  OPERATOR4          VARCHAR2(30),
  EXECUTE_TIME5      NUMBER(1),
  OPERATOR5          VARCHAR2(30),
  LOG_DATE_TIME      DATE,
  DUTY_NURSE         VARCHAR2(8),
  ORDER_ABBR         VARCHAR2(20),
  DUTY_DATE_TIME     DATE,
  ORDER_CLASS        VARCHAR2(1),
  EXECUTE_TIME6      NUMBER(1),
  OPERATOR6          VARCHAR2(30)
)
;
alter table MED_PATIENT_ORDER_COMPL_REC
  add constraint PK_MED_PATIENT_ORDER_COMPL_REC primary key (PATIENT_ID, VISIT_ID, DEP_ID, ORDER_NO, ORDER_SUB_NO, DEFAULT_TIME_POINT, DUTY_DATE);
grant select, insert, update, delete on MED_PATIENT_ORDER_COMPL_REC to ROLE_DOCARE;
grant select, insert, update, delete on MED_PATIENT_ORDER_COMPL_REC to medcomm with grant option;

prompt
prompt Creating table MED_PATIENT_ORDER_EXEC_REC
prompt =========================================
prompt
create table MED_PATIENT_ORDER_EXEC_REC
(
  PATIENT_ID          VARCHAR2(20) not null,
  VISIT_ID            NUMBER(2) not null,
  DEP_ID	      NUMBER(2) not null,
  ORDER_NO            VARCHAR2(20) not null,
  ORDER_SUB_NO        NUMBER(12) not null,
  REPEAT_INDICATOR    NUMBER(1),
  ORDER_TEXT          VARCHAR2(200),
  PERFORM_SCHEDULE    VARCHAR2(64),
  DOSAGE              NUMBER(14,4),
  DOSAGE_UNITS        VARCHAR2(8),
  ADMINISTRATION      VARCHAR2(30),
  DEFAULT_TIME_POINT  DATE not null,
  EXECUTE_TIME_POINT  DATE,
  COMPLETE_TIME_POINT DATE,
  PERFORM_SPEED       NUMBER(8,4),
  SPEED_UNIT          VARCHAR2(10),
  ALL_DOSAGE          NUMBER(14,4),
  EXECUTE_DOSAGE      NUMBER(14,4),
  DUTY_INDICATOR      NUMBER(1),
  DUTY_NAME           VARCHAR2(8) not null,
  DUTY_DATE           DATE not null,
  ITEM_NO             NUMBER(2) not null,
  MEMO                VARCHAR2(400),
  MEMO_TIME_POINT     DATE,
  OPERATOR            VARCHAR2(30),
  LOG_DATE_TIME       DATE,
  DUTY_NURSE          VARCHAR2(30),
  ORDER_ABBR          VARCHAR2(20),
  DUTY_DATE_TIME      DATE,
  EXECUTE_MATHOD      VARCHAR2(20),
  SKINRESPONSE        VARCHAR2(20),
  INJECTIONSITE       VARCHAR2(40),
  VEINVESSEL          VARCHAR2(4),
  UNIT_WEIGHT_MOUNT   NUMBER(10,2),
  QTY                 NUMBER(10,2)
)
;
alter table MED_PATIENT_ORDER_EXEC_REC
  add constraint PK_MED_PATIENT_ORDER_EXEC_REC primary key (PATIENT_ID, VISIT_ID, DEP_ID, ORDER_NO, ORDER_SUB_NO, DEFAULT_TIME_POINT, DUTY_NAME, DUTY_DATE, ITEM_NO);
grant select, insert, update, delete on MED_PATIENT_ORDER_EXEC_REC to ROLE_DOCARE;
grant select, insert, update, delete on MED_PATIENT_ORDER_EXEC_REC to medcomm with grant option;

prompt
prompt Creating table MED_PATIENT_QIANGJIU
prompt ===================================
prompt
create table MED_PATIENT_QIANGJIU
(
  PATIENT_ID     VARCHAR2(20) not null,
  VISIT_ID       NUMBER(2) not null,
  START_DATETIME DATE default SysDate not null,
  END_DATETIME   DATE,
  DESCRIPTION    VARCHAR2(200)
)
;
alter table MED_PATIENT_QIANGJIU
  add constraint PK_MED_PATIENT_QIANGJIU primary key (PATIENT_ID, VISIT_ID, START_DATETIME);
grant select, insert, update, delete on MED_PATIENT_QIANGJIU to ROLE_DOCARE;
grant select, insert, update, delete on MED_PATIENT_QIANGJIU to medcomm with grant option;

prompt
prompt Creating table MED_PATIENT_SCORING_RESULT
prompt =========================================
prompt
create table MED_PATIENT_SCORING_RESULT
(
  PATIENT_ID        VARCHAR2(20) not null,
  VISIT_ID          NUMBER(2) not null,
  DEP_ID	    NUMBER(2) not null,
  SCORING_DATE_TIME DATE not null,
  SCORING_METHOD    VARCHAR2(20) not null,
  SCORING_VALUE     NUMBER(8),
  DEGREE            VARCHAR2(40),
  DEATH_PROBABILITY NUMBER(5,4),
  PAT_CONDITION     VARCHAR2(80),
  WARD_CODE         VARCHAR2(8),
  OPERATOR          VARCHAR2(30),
  MEMO              VARCHAR2(1000),
  ENTER_DATE_TIME   DATE,
  DEATH_RATE		NUMBER(6,2),
  ISS_SCORE			NUMBER(6,2),
  TRS_SCORE			NUMBER(6,2)
)
;
alter table MED_PATIENT_SCORING_RESULT
  add constraint PK_PATIENT_SCORING_RESULT primary key (PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME, SCORING_METHOD);
grant select, insert, update, delete on MED_PATIENT_SCORING_RESULT to ROLE_DOCARE;
grant select, insert, update, delete on MED_PATIENT_SCORING_RESULT to medcomm with grant option;

prompt
prompt Creating table MED_PATIENT_TRANS_REC
prompt ====================================
prompt
create table MED_PATIENT_TRANS_REC
(
  WARD_CODE       VARCHAR2(8) not null,
  TRANS_DATE_TIME DATE not null,
  SCHEDULE_NAME   VARCHAR2(8) not null,
  S1              NUMBER(3),
  S2              NUMBER(3),
  S3              NUMBER(3),
  S4              NUMBER(3),
  S5              NUMBER(3),
  S6              NUMBER(3),
  S7              NUMBER(3),
  S8              NUMBER(3),
  S9              NUMBER(3),
  S10             NUMBER(3),
  S11             NUMBER(3),
  S12             NUMBER(3)
)
;
alter table MED_PATIENT_TRANS_REC
  add constraint PK_MED_PATIENT_TRANS_REC primary key (WARD_CODE, TRANS_DATE_TIME, SCHEDULE_NAME);
grant select, insert, update, delete on MED_PATIENT_TRANS_REC to ROLE_DOCARE;
grant select, insert, update, delete on MED_PATIENT_TRANS_REC to medcomm with grant option;

prompt
prompt Creating table MED_SAPS2_SCORING_RESULT
prompt =======================================
prompt
create table MED_SAPS2_SCORING_RESULT
(
  PATIENT_ID        VARCHAR2(20) not null,
  VISIT_ID          NUMBER(2) not null,
  DEP_ID	    NUMBER(2) not null,
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
alter table MED_SAPS2_SCORING_RESULT
  add constraint PK_SAPS2_SCORING_RESULT primary key (PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME);
grant select, insert, update, delete on MED_SAPS2_SCORING_RESULT to ROLE_DOCARE;
grant select, insert, update, delete on MED_SAPS2_SCORING_RESULT to medcomm with grant option;

prompt
prompt Creating table MED_SCORING_ITEM_LIST
prompt ====================================
prompt
create table MED_SCORING_ITEM_LIST
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
alter table MED_SCORING_ITEM_LIST
  add constraint PK_MED_SCORING_ITEM_LIST primary key (SCORING_METHOD, ITEM_CLASS, ITEM_NAME, ITEM_NO);
grant select, insert, update, delete on MED_SCORING_ITEM_LIST to ROLE_DOCARE;
grant select, insert, update, delete on MED_SCORING_ITEM_LIST to medcomm with grant option;

prompt
prompt Creating table MED_SCORING_METHOD_DICT
prompt ======================================
prompt
create table MED_SCORING_METHOD_DICT
(
  SCORING_METHOD VARCHAR2(20) not null,
  ENGLISH_NAME   VARCHAR2(80),
  CHINESE_NAME   VARCHAR2(80),
  ARITH_FORMULA  VARCHAR2(4000),
  MEMO           VARCHAR2(1000)
)
;
alter table MED_SCORING_METHOD_DICT
  add constraint PK_MED_SCORING_METHOD_DICT primary key (SCORING_METHOD);
grant select, insert, update, delete on MED_SCORING_METHOD_DICT to ROLE_DOCARE;
grant select, insert, update, delete on MED_SCORING_METHOD_DICT to medcomm with grant option;

prompt
prompt Creating table MED_SCORING_VALUE_MEMO_DICT
prompt ==========================================
prompt
create table MED_SCORING_VALUE_MEMO_DICT
(
  SCORING_METHOD VARCHAR2(20) not null,
  UPPER_LEVEL    NUMBER(8) not null,
  LOW_LEVEL      NUMBER(8),
  DEGREE         VARCHAR2(40),
  MEMO           VARCHAR2(200)
)
;
alter table MED_SCORING_VALUE_MEMO_DICT
  add constraint PK_MED_SCORING_VALUE_MEMO_DICT primary key (SCORING_METHOD, UPPER_LEVEL);
grant select, insert, update, delete on MED_SCORING_VALUE_MEMO_DICT to ROLE_DOCARE;
grant select, insert, update, delete on MED_SCORING_VALUE_MEMO_DICT to medcomm with grant option;

prompt
prompt Creating table MED_SOFA_SCORING_RESULT_DETAIL
prompt =============================================
prompt
create table MED_SOFA_SCORING_RESULT_DETAIL
(
  PATIENT_ID        VARCHAR2(20) not null,
  VISIT_ID          NUMBER not null,
  DEP_ID	    NUMBER(2) not null,
  SCORING_DATE_TIME DATE not null,
  S1                NUMBER(6,2),
  S2                NUMBER(6,2),
  S3                NUMBER,
  S4                NUMBER,
  S5                NUMBER,
  S6                NUMBER,
  EYES_REFLECT      NUMBER,
  TALK_REFLECT      NUMBER,
  LIMB_REFLECT      NUMBER,
  MEMO              VARCHAR2(100),
  S7                NUMBER
)
;
alter table MED_SOFA_SCORING_RESULT_DETAIL
  add constraint PK_MED_SOFA_SCORING_RESULT primary key (PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME);
grant select, insert, update, delete on MED_SOFA_SCORING_RESULT_DETAIL to ROLE_DOCARE;
grant select, insert, update, delete on MED_SOFA_SCORING_RESULT_DETAIL to medcomm with grant option;

prompt
prompt Creating table MED_SPECIAL_CURVE_FOR_PATIENT
prompt ============================================
prompt
create table MED_SPECIAL_CURVE_FOR_PATIENT
(
  PATIENT_ID  VARCHAR2(20) not null,
  ITEM_NAME   VARCHAR2(20) not null,
  VALUE_TYPE  NUMBER(1),
  CURVE_TYPE  NUMBER(2),
  SYMBOL_TYPE NUMBER(2),
  ITEM_COLOR  NUMBER(10),
  FILL_COLOR  NUMBER(10)
)
;
alter table MED_SPECIAL_CURVE_FOR_PATIENT
  add constraint PK_SPECIAL_CURVE_FOR_PATIENT primary key (PATIENT_ID, ITEM_NAME);
grant select, insert, update, delete on MED_SPECIAL_CURVE_FOR_PATIENT to ROLE_DOCARE;
grant select, insert, update, delete on MED_SPECIAL_CURVE_FOR_PATIENT to medcomm with grant option;

prompt
prompt Creating table MED_SPECIAL_MONIT_FOR_PATIENT
prompt ============================================
prompt
create table MED_SPECIAL_MONIT_FOR_PATIENT
(
  PATIENT_ID      VARCHAR2(20) not null,
  VISIT_ID        NUMBER(2) not null,
  DEP_ID	  NUMBER(2) not null,
  ITEM_CODE       VARCHAR2(6),
  ITEM_NAME       VARCHAR2(40) not null,
  ITEM_NAME_ALIAS VARCHAR2(8),
  VALUE_TYPE      NUMBER(1),
  ITEM_UNIT       VARCHAR2(10),
  EXAM_METHOD     NUMBER(1),
  IN_OR_OUT       NUMBER(1),
  ITEM_TYPE       NUMBER(1),
  PRINT_ITEM_NO   NUMBER(2),
  CALC_SUM        NUMBER(1),
  ORDER_ATTR      VARCHAR2(8),
  RESERVED1       VARCHAR2(20),
  WARD_CODE       VARCHAR2(8),
  SHOW_SUB_CODE   VARCHAR2(10),
  DATA_TABLE_CODE VARCHAR2(100)
)
;
alter table MED_SPECIAL_MONIT_FOR_PATIENT
  add constraint PK_SPECIAL_MONIT_FOR_PATIENT primary key (PATIENT_ID, VISIT_ID, DEP_ID, ITEM_NAME);
grant select, insert, update, delete on MED_SPECIAL_MONIT_FOR_PATIENT to ROLE_DOCARE;
grant select, insert, update, delete on MED_SPECIAL_MONIT_FOR_PATIENT to medcomm with grant option;

prompt
prompt Creating table MED_SSSS_SCORING_RESULT_DETAIL
prompt =============================================
prompt
create table MED_SSSS_SCORING_RESULT_DETAIL
(
  PATIENT_ID        VARCHAR2(20) not null,
  VISIT_ID          NUMBER(2) not null,
  DEP_ID	    NUMBER(2) not null,
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
alter table MED_SSSS_SCORING_RESULT_DETAIL
  add constraint PK_SSSS_SCORING_RESULT primary key (PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME);
grant select, insert, update, delete on MED_SSSS_SCORING_RESULT_DETAIL to ROLE_DOCARE;
grant select, insert, update, delete on MED_SSSS_SCORING_RESULT_DETAIL to medcomm with grant option;

prompt
prompt Creating table MED_SSS_SCORING_RESULT_DETAIL
prompt ============================================
prompt
create table MED_SSS_SCORING_RESULT_DETAIL
(
  PATIENT_ID        VARCHAR2(20) not null,
  VISIT_ID          NUMBER(2) not null,
  DEP_ID	    NUMBER(2) not null,
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
alter table MED_SSS_SCORING_RESULT_DETAIL
  add constraint PK_SSS_SCORING_RESULT primary key (PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME);
grant select, insert, update, delete on MED_SSS_SCORING_RESULT_DETAIL to ROLE_DOCARE;
grant select, insert, update, delete on MED_SSS_SCORING_RESULT_DETAIL to medcomm with grant option;

prompt
prompt Creating table MED_TISS_SCORING_RESULT_DETAIL
prompt =============================================
prompt
create table MED_TISS_SCORING_RESULT_DETAIL
(
  PATIENT_ID        VARCHAR2(20) not null,
  VISIT_ID          NUMBER(2) not null,
  DEP_ID	    NUMBER(2) not null,
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
alter table MED_TISS_SCORING_RESULT_DETAIL
  add constraint PK_TISS_SCORING_RESULT primary key (PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME);
grant select, insert, update, delete on MED_TISS_SCORING_RESULT_DETAIL to ROLE_DOCARE;
grant select, insert, update, delete on MED_TISS_SCORING_RESULT_DETAIL to medcomm with grant option;

prompt
prompt Creating table MED_VITAL_SIGNS_CHANGED_REC
prompt ==========================================
prompt
create table MED_VITAL_SIGNS_CHANGED_REC
(
  PATIENT_ID       VARCHAR2(20) not null,
  VISIT_ID         NUMBER(2) not null,
  DEP_ID	   NUMBER(2) not null,
  RECORDING_DATE   DATE not null,
  TIME_POINT       DATE not null,
  VITAL_SIGNS      VARCHAR2(40) not null,
  OLD_SIGNS_VALUES VARCHAR2(40),
  NEW_SIGNS_VALUES VARCHAR2(40),
  UNITS            VARCHAR2(40),
  MEMO             VARCHAR2(40),
  OPERATOR         VARCHAR2(30),
  LOG_DATE_TIME    DATE
)
;
alter table MED_VITAL_SIGNS_CHANGED_REC
  add constraint PK_MED_VITAL_CHANGED_REC primary key (PATIENT_ID, VISIT_ID, DEP_ID, RECORDING_DATE, TIME_POINT, VITAL_SIGNS);
grant select, insert, update, delete on MED_VITAL_SIGNS_CHANGED_REC to ROLE_DOCARE;
grant select, insert, update, delete on MED_VITAL_SIGNS_CHANGED_REC to medcomm with grant option;

prompt
prompt Creating table MED_VITAL_SIGNS_DEC_FOR_DOCTOR
prompt =============================================
prompt
create table MED_VITAL_SIGNS_DEC_FOR_DOCTOR
(
  PATIENT_ID      VARCHAR2(20) not null,
  VISIT_ID        NUMBER(2) not null,
  DEP_ID	  NUMBER(2) not null,
  RECORDING_DATE  DATE not null,
  TIME_POINT      DATE not null,
  VITAL_SIGNS_REC VARCHAR2(500),
  MEMO            VARCHAR2(1000),
  OPERATOR        VARCHAR2(30),
  LOG_DATE_TIME   DATE
)
;
alter table MED_VITAL_SIGNS_DEC_FOR_DOCTOR
  add constraint PK_VITAL_SIGNS_DEC_FOR_DOCTOR primary key (PATIENT_ID, VISIT_ID, DEP_ID, RECORDING_DATE, TIME_POINT);
grant select, insert, update, delete on MED_VITAL_SIGNS_DEC_FOR_DOCTOR to ROLE_DOCARE;
grant select, insert, update, delete on MED_VITAL_SIGNS_DEC_FOR_DOCTOR to medcomm with grant option;

prompt
prompt Creating table MED_VITAL_SIGNS_REC
prompt ==================================
prompt
create table MED_VITAL_SIGNS_REC
(
  PATIENT_ID         VARCHAR2(20) not null,
  VISIT_ID           NUMBER(2) not null,
  DEP_ID	     NUMBER(2) not null,
  RECORDING_DATE     DATE not null,
  TIME_POINT         DATE not null,
  VITAL_SIGNS        VARCHAR2(40) not null,
  VITAL_SIGNS_VALUES NUMBER(6,2),
  UNITS              VARCHAR2(40),
  MEMO               VARCHAR2(100),
  EXAM_METHOD        NUMBER(1),
  NURSE_INDICATOR    NUMBER(1),
  OPERATOR           VARCHAR2(30),
  LOG_DATE_TIME      DATE
)
;
alter table MED_VITAL_SIGNS_REC
  add constraint PK_MED_VITAL_SIGNS_REC primary key (PATIENT_ID, VISIT_ID, DEP_ID, RECORDING_DATE, TIME_POINT, VITAL_SIGNS);
grant select, insert, update, delete on MED_VITAL_SIGNS_REC to ROLE_DOCARE;
grant select, insert, update, delete on MED_VITAL_SIGNS_REC to medcomm with grant option;

prompt
prompt Creating table MED_VITAL_SIGNS_REC_TEMP
prompt =======================================
prompt
create table MED_VITAL_SIGNS_REC_TEMP
(
  PATIENT_ID         VARCHAR2(20) not null,
  VISIT_ID           NUMBER(2) not null,
  DEP_ID	     NUMBER(2) not null,
  RECORDING_DATE     DATE not null,
  TIME_POINT         DATE not null,
  VITAL_SIGNS        VARCHAR2(40) not null,
  VITAL_SIGNS_VALUES NUMBER(6,2),
  UNITS              VARCHAR2(40),
  MEMO               VARCHAR2(100),
  EXAM_METHOD        NUMBER(1),
  NURSE_INDICATOR    NUMBER(1),
  OPERATOR           VARCHAR2(30),
  LOG_DATE_TIME      DATE
)
;
alter table MED_VITAL_SIGNS_REC_TEMP
  add constraint PK_MED_VITAL_SIGNS_REC_TEMP primary key (PATIENT_ID, VISIT_ID, DEP_ID, RECORDING_DATE, TIME_POINT, VITAL_SIGNS);
grant select, insert, update, delete on MED_VITAL_SIGNS_REC_TEMP to ROLE_DOCARE;
grant select, insert, update, delete on MED_VITAL_SIGNS_REC_TEMP to medcomm with grant option;

prompt
prompt Creating table MED_PELOD_SCORING_RESULT
prompt ==================================
prompt
create table MED_PELOD_SCORING_RESULT
(
  PATIENT_ID        VARCHAR2(20) not null,
  VISIT_ID          NUMBER(2) not null,
  DEP_ID	    NUMBER(2) not null,
  SCORING_DATE_TIME DATE not null,
  S1                NUMBER,
  S2                NUMBER,
  S3                NUMBER,
  S4                NUMBER,
  S5                NUMBER,
  S6                NUMBER,
  S7                NUMBER,
  S8                NUMBER,
  S9                NUMBER,
  S10               NUMBER,
  S11               NUMBER,
  S12               NUMBER,
  MEMO              VARCHAR2(100)
)
;
alter table MED_PELOD_SCORING_RESULT
  add constraint PK_PELOD primary key (PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME);
grant select, insert, update, delete on MED_PELOD_SCORING_RESULT to ROLE_DOCARE;
grant select, insert, update, delete on MED_PELOD_SCORING_RESULT to medcomm with grant option;

prompt
prompt Creating table MED_CRIB_SCORING_RESULT
prompt ==================================
prompt
create table MED_CRIB_SCORING_RESULT
(
  PATIENT_ID        VARCHAR2(20) not null,
  VISIT_ID          NUMBER(2) not null,
  DEP_ID	    NUMBER(2) not null,
  SCORING_DATE_TIME DATE not null,
  S1                NUMBER,
  S2                NUMBER,
  S3                NUMBER,
  S4                NUMBER,
  S5                NUMBER,
  S6                NUMBER,
  MEMO              VARCHAR2(100)
)
;
alter table MED_CRIB_SCORING_RESULT
  add constraint PK_CRIB primary key (PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME);
grant select, insert, update, delete on MED_CRIB_SCORING_RESULT to ROLE_DOCARE;
grant select, insert, update, delete on MED_CRIB_SCORING_RESULT to medcomm with grant option;

prompt
prompt Creating table MED_NTISS_SCORING_RESULT
prompt ==================================
prompt
create table MED_NTISS_SCORING_RESULT
(
  PATIENT_ID        VARCHAR2(20) not null,
  VISIT_ID          NUMBER(2) not null,
  DEP_ID	    NUMBER(2) not null,
  SCORING_DATE_TIME DATE not null,
  S1                NUMBER,
  S2                NUMBER,
  S3                NUMBER,
  S4                NUMBER,
  S5                NUMBER,
  S6                NUMBER,
  S7                NUMBER,
  S8                NUMBER,
  S9                NUMBER,
  S10               NUMBER,
  S11               NUMBER,
  S12               NUMBER,
  S13               NUMBER,
  S14               NUMBER,
  S15               NUMBER,
  S16               NUMBER,
  S17               NUMBER,
  S18               NUMBER,
  S19               NUMBER,
  S20               NUMBER,
  S21               NUMBER,
  S22               NUMBER,
  S23               NUMBER,
  S24               NUMBER,
  S25               NUMBER,
  S26               NUMBER,
  S27               NUMBER,
  S28               NUMBER,
  S29               NUMBER,
  S30               NUMBER,
  S31               NUMBER,
  S32               NUMBER,
  S33               NUMBER,
  S34               NUMBER,
  S35               NUMBER,
  S36               NUMBER,
  S37               NUMBER,
  S38               NUMBER,
  S39               NUMBER,
  S40               NUMBER,
  S41               NUMBER,
  S42               NUMBER,
  S43               NUMBER,
  S44               NUMBER,
  S45               NUMBER,
  S46               NUMBER,
  S47               NUMBER,
  S48               NUMBER,
  MEMO              VARCHAR2(100)
)
;
alter table MED_NTISS_SCORING_RESULT
  add constraint PK_NTISS primary key (PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME);
grant select, insert, update, delete on MED_NTISS_SCORING_RESULT to ROLE_DOCARE;
grant select, insert, update, delete on MED_NTISS_SCORING_RESULT to medcomm with grant option;

prompt
prompt Creating table MED_PATIENT_ESTIMATE_RECORD
prompt ==================================
prompt
create table MED_PATIENT_ESTIMATE_RECORD
(
  PATIENT_ID                VARCHAR2(20) not null,
  VISIT_ID                  NUMBER(2) not null,
  DEP_ID	            NUMBER(2) not null,
  OPERATOR_CODE             VARCHAR2(16) not null,
  OPEARTOR_DATE             DATE not null,
  WAY_M	                    VARCHAR2(60),
  MAIN_DES                  VARCHAR2(200),
  INTROD_M                  VARCHAR2(200),
  INTROD_OTHER              VARCHAR2(200),
  POSITION_M                VARCHAR2(40),
  SKIN_M                    VARCHAR2(40),
  FOOD_M                    VARCHAR2(40),
  STOOL_M1                  VARCHAR2(10),
  STOOL_M2                  VARCHAR2(20),
  STOOL_2_M1                VARCHAR2(20),
  STOOL_2_M2                VARCHAR2(20),
  URINE_M                   VARCHAR2(40),
  OVERSENSITIVEM_M          VARCHAR2(40),
  OVERSENSITIVEF_1_M1       VARCHAR2(40),
  OVERSENSITIVEF_1_M2       VARCHAR2(40),
  EMOTION_M                 VARCHAR2(40),
  MOVE_M                    VARCHAR2(40),
  TOOL_M                    VARCHAR2(40),
  SLEEP_1                   VARCHAR2(40),
  HISTORY_M                 VARCHAR2(40),
  MEDICAL_M                 VARCHAR2(60),
  DOHTER                    VARCHAR2(200),
  PAIN_1_M1                 VARCHAR2(60),
  PAIN_1_M2                 VARCHAR2(60),
  PAIN_1_M3                 VARCHAR2(60),
  RELIGION_1_M              VARCHAR2(60),
  OTHERM                    VARCHAR2(200),
  ALL_CHECKED_ITEM_NAME     VARCHAR2(800)
);
alter table MED_PATIENT_ESTIMATE_RECORD
  add constraint PK_MED_PATIENT_ESTIMATE_RECORD primary key (PATIENT_ID, VISIT_ID, DEP_ID, OPERATOR_CODE, OPEARTOR_DATE);
grant select, insert, update, delete on MED_PATIENT_ESTIMATE_RECORD to ROLE_DOCARE;
grant select, insert, update, delete on MED_PATIENT_ESTIMATE_RECORD to medcomm with grant option;

prompt
prompt Creating table MED_SHORTNAME_DICT
prompt ==================================
prompt
create table MED_SHORTNAME_DICT
(
  NAME       VARCHAR2(200) not null,
  SHORT_NAME VARCHAR2(20)
);
alter table MED_SHORTNAME_DICT
  add constraint PK_SHORTNAME primary key (NAME);
grant select, insert, update, delete on MED_SHORTNAME_DICT to ROLE_DOCARE;
grant select, insert, update, delete on MED_SHORTNAME_DICT to medcomm with grant option;

prompt
prompt Creating table MED_DOCUMENT_DESIGN_DETAIL
prompt ==================================
prompt
create table MED_DOCUMENT_DESIGN_DETAIL
(
  DOCUMENT_NAME               VARCHAR2(40) not null,
  ITEM_NAME                   VARCHAR2(40) not null,
  WIDTH                       NUMBER(6),
  HEIGHT                      NUMBER(6),
  TOP                         NUMBER(6),
  LEFT                        NUMBER(6),
  FORE_COLOR                  VARCHAR2(40),
  TEXT                        VARCHAR2(80),
  BACKCOLOR                   VARCHAR2(40),
  FONT                        VARCHAR2(80),
  FONT_STYLE                  VARCHAR2(40),
  BIND_TABLE_NAME             VARCHAR2(40),
  BIND_FIELD_NAME             VARCHAR2(40),
  CELERITY_INPUT_TABLE_NAME   VARCHAR2(40),
  CELERITY_INPUT_VALUE_COLUMN VARCHAR2(40),
  CELERITY_INPUT_CODE_COMUMN  VARCHAR2(40),
  BIND_LIST                   VARCHAR2(80),
  MULTILINE                   VARCHAR2(16),
  CONTROL_TYPE                VARCHAR2(40),
  DRAW_BORDER                 VARCHAR2(40),
  WARD_CODE                   VARCHAR2(16) not null
);
alter table MED_DOCUMENT_DESIGN_DETAIL
  add constraint DOCUMENT_DESIGN_DETAIL_KEY primary key (DOCUMENT_NAME, ITEM_NAME, WARD_CODE);
grant select, insert, update, delete on MED_DOCUMENT_DESIGN_DETAIL to ROLE_DOCARE;
grant select, insert, update, delete on MED_DOCUMENT_DESIGN_DETAIL to medcomm with grant option;

prompt
prompt Creating table MED_DOCUMENT_DESIGN_MAIN
prompt ==================================
prompt
create table MED_DOCUMENT_DESIGN_MAIN
(
  DOCUMENT_NAME VARCHAR2(40) not null,
  WEIDTH        NUMBER(6),
  HEIGHT        NUMBER(6),
  WARD_CODE     VARCHAR2(16),
  MAIN_TOP      NUMBER(6)
);
alter table MED_DOCUMENT_DESIGN_MAIN
  add constraint DOCUMENT_DESIGN_MAIN_KEY primary key (DOCUMENT_NAME);
grant select, insert, update, delete on MED_DOCUMENT_DESIGN_MAIN to ROLE_DOCARE;
grant select, insert, update, delete on MED_DOCUMENT_DESIGN_MAIN to medcomm with grant option;

prompt
prompt Creating table MED_SPECIALCARE_CONFIG
prompt ==================================
prompt
create table MED_SPECIALCARE_CONFIG
(
  PROJECT_LEVEL         NUMBER(1) not null,
  PROJECT_NAME          VARCHAR2(50) not null,
  PROJECT_ATTRIBUTE     VARCHAR2(50) not null,
  ATTRIBUTE_VALUE       VARCHAR2(200),
  PROJECT_CATEGORY      VARCHAR2(30),
  START_INDEX           NUMBER(2),
  END_INDEX             NUMBER(2),
  SPECIALCARE_DOCS_NAME VARCHAR2(40) not null,
  WARD_CODE             VARCHAR2(16) not null,
  FONT                  VARCHAR2(200),
  FONT_STYLE            VARCHAR2(100)
);
alter table MED_SPECIALCARE_CONFIG
  add constraint PK_MED_SPECIALCARE_CONFIG primary key (PROJECT_LEVEL, PROJECT_NAME, PROJECT_ATTRIBUTE, SPECIALCARE_DOCS_NAME, WARD_CODE);
grant select, insert, update, delete on MED_SPECIALCARE_CONFIG to ROLE_DOCARE;
grant select, insert, update, delete on MED_SPECIALCARE_CONFIG to medcomm with grant option;

prompt
prompt Creating table MED_SPECIALCARE_DICT
prompt ==================================
prompt
create table MED_SPECIALCARE_DICT
(
  PROJECT_NAME  VARCHAR2(50) not null,
  ATTRIBUTE     VARCHAR2(200) not null,
  DEFAULT_VALUE VARCHAR2(200),
  REMARK        VARCHAR2(300)
);
alter table MED_SPECIALCARE_DICT
  add constraint PK_MED_SPECIALCARE_DICT primary key (PROJECT_NAME, ATTRIBUTE);
grant select, insert, update, delete on MED_SPECIALCARE_DICT to ROLE_DOCARE;
grant select, insert, update, delete on MED_SPECIALCARE_DICT to medcomm with grant option;

prompt
prompt Creating table MED_SPECIALCARE_FIELD_CONFIG
prompt ==================================
prompt
create table MED_SPECIALCARE_FIELD_CONFIG
(
  PARENT_ITEM                VARCHAR2(50) not null,
  CHILD_ITEM                 VARCHAR2(50) not null,
  VIEW_TEXT                  VARCHAR2(50),
  CLASS_TYPE                VARCHAR2(50),
  CELERITY_INPUT_TABLE_NAME  VARCHAR2(50),
  CELERITY_VALUE_COLUMN_NAME VARCHAR2(50),
  CELERITY_CODE_COLUMN_NAME  VARCHAR2(50),
  BIND_LIST                  VARCHAR2(300),
  MULTI_SIGN                 VARCHAR2(20)
);
alter table MED_SPECIALCARE_FIELD_CONFIG
  add constraint PK_MED_FIELDSETTING_CONFIG primary key (PARENT_ITEM, CHILD_ITEM);
grant select, insert, update, delete on MED_SPECIALCARE_FIELD_CONFIG to ROLE_DOCARE;
grant select, insert, update, delete on MED_SPECIALCARE_FIELD_CONFIG to medcomm with grant option;

prompt
prompt Creating table MED_TREND_ANALYSIS_CHART_MAIN
prompt ==================================
prompt
create table MED_TREND_ANALYSIS_CHART_MAIN
(
  GUID                VARCHAR2(60) not null,
  ANALYSIS_CHART_NAME VARCHAR2(100) not null,
  XAXIS_NAME          VARCHAR2(40),
  XAXIS_STEP          NUMBER(6,2),
  XAXIS_MIN           NUMBER(6,2),
  XAXIS_MAX           NUMBER(6,2),
  CHART_BACKCOLOR     VARCHAR2(60),
  ITEM_NAME           VARCHAR2(100),
  YAXIS               VARCHAR2(100),
  ITEM_STYLE          VARCHAR2(60),
  SHOW_TEXT           VARCHAR2(80),
  LINE_STYLE          VARCHAR2(40)
);
alter table MED_TREND_ANALYSIS_CHART_MAIN
  add constraint PRIMARY_ANALYSIS_CHART_MAIN primary key (GUID);
grant select, insert, update, delete on MED_TREND_ANALYSIS_CHART_MAIN to ROLE_DOCARE;
grant select, insert, update, delete on MED_TREND_ANALYSIS_CHART_MAIN to medcomm with grant option;

prompt
prompt Creating table MED_TREND_ANALYSIS_DETAIL
prompt ==================================
prompt
create table MED_TREND_ANALYSIS_DETAIL
(
  YAXIS_NAME        VARCHAR2(40) not null,
  YAXIS_MIN         NUMBER(6,2),
  YAXIS_MAX         NUMBER(6,2),
  YAXIS_COLOR       VARCHAR2(60),
  YAXIS_CHART_STYLE VARCHAR2(20),
  YAXIS_ITEM_STYLE  VARCHAR2(20),
  YAXIS_SHADOW      VARCHAR2(10)
);
alter table MED_TREND_ANALYSIS_DETAIL
  add constraint PRIMARY_ANALYSIS_CHART_DETAIL primary key (YAXIS_NAME);
grant select, insert, update, delete on MED_TREND_ANALYSIS_DETAIL to ROLE_DOCARE;
grant select, insert, update, delete on MED_TREND_ANALYSIS_DETAIL to medcomm with grant option;

prompt
prompt Creating table MED_TREND_ANALYSIS_TAG
prompt ==================================
prompt
create table MED_TREND_ANALYSIS_TAG
(
  PATIENT_ID      VARCHAR2(20) not null,
  VISIT_ID        NUMBER(2) not null,
  DEP_ID	  NUMBER(2) not null,
  TAG_NAME        VARCHAR2(40) not null,
  DATA_SOURCE     VARCHAR2(40),
  CHART_NAME      VARCHAR2(200) not null,
  START_DATE_TIME DATE,
  END_DATE_TIME   DATE
);
alter table MED_TREND_ANALYSIS_TAG
  add constraint PRIMARY_MED_TREND_ANALYSIS_TAG primary key (PATIENT_ID, VISIT_ID, DEP_ID, TAG_NAME, CHART_NAME);
grant select, insert, update, delete on MED_TREND_ANALYSIS_TAG to ROLE_DOCARE;
grant select, insert, update, delete on MED_TREND_ANALYSIS_TAG to medcomm with grant option;

prompt
prompt Creating table MED_SMARTREPORT_MAPPINGDATA
prompt ==================================
prompt
create table MED_SMARTREPORT_MAPPINGDATA
(
  REPORTMAPPINGID NUMBER not null,
  REPORTCLIENTID  VARCHAR2(50) not null,
  MAPPERDATA      NCLOB,
  REPORTNAME      VARCHAR2(50) not null,
  CREATEBY        VARCHAR2(20),
  CREATETIME      DATE,
  LASTUPDATEBY    VARCHAR2(20),
  LASTUPDATETIME  DATE,
  VERSION         NUMBER,
  ISVALID         NUMBER
);
alter table MED_SMARTREPORT_MAPPINGDATA
  add constraint REPORTMAPPINGID primary key (REPORTMAPPINGID);
grant select, insert, update, delete on MED_SMARTREPORT_MAPPINGDATA to ROLE_DOCARE;
grant select, insert, update, delete on MED_SMARTREPORT_MAPPINGDATA to medcomm with grant option;

prompt
prompt Creating table MED_SMARTREPORT_TEMPLATE
prompt ==================================
prompt
create table MED_SMARTREPORT_TEMPLATE
(
  REPORTTEMPLATEID NUMBER not null,
  REPORTNAME       VARCHAR2(50),
  HOSPITALNAME     VARCHAR2(50),
  REPORTTEMPLATE   NCLOB,
  CREATEBY         VARCHAR2(20),
  CREATETIME       DATE,
  LASTUPDATEBY     VARCHAR2(20),
  LASTUPDATETIME   DATE,
  VERSION          NUMBER
);
alter table MED_SMARTREPORT_TEMPLATE
  add constraint REPORTTEMPLATEID primary key (REPORTTEMPLATEID);
alter table MED_SMARTREPORT_TEMPLATE
  add constraint REPORTNAME unique (REPORTNAME);
grant select, insert, update, delete on MED_SMARTREPORT_TEMPLATE to ROLE_DOCARE;
grant select, insert, update, delete on MED_SMARTREPORT_TEMPLATE to medcomm with grant option;

prompt
prompt Creating table MED_ICU_RESCUE_TIME_REC
prompt ==================================
prompt
create table MED_ICU_RESCUE_TIME_REC
(
  PATIENT_ID       VARCHAR2(20) not null,
  VISIT_ID         NUMBER(2) not null,
  DEP_ID	   NUMBER(2) not null,
  RESCUE_STARTTIME date not null,
  RESCUE_ENDTIME   date not null,
  RESERVED01       VARCHAR2(50),
  RESERVED02       VARCHAR2(50),
  RESERVED03       VARCHAR2(50),
  RESERVED04       VARCHAR2(50),
  RESERVED05       VARCHAR2(50),
  RESERVED_DATE01  date,
  RESERVED_DATE02  date
);
alter table MED_ICU_RESCUE_TIME_REC
  add constraint PK_MED_ICU_RESCUE_TIME_REC primary key (PATIENT_ID, VISIT_ID, DEP_ID, RESCUE_STARTTIME, RESCUE_ENDTIME);
grant select, insert, update, delete on MED_ICU_RESCUE_TIME_REC to role_docare;
grant select, insert, update, delete on MED_ICU_RESCUE_TIME_REC to medcomm with grant option;

prompt
prompt Creating table MED_PAGE_COUNT
prompt ==================================
prompt
create table MED_PAGE_COUNT
(
  PATIENT_ID 	VARCHAR2(20) not null,
  VISIT_ID   	NUMBER(2) not null,
  DEP_ID	NUMBER(2) not null,
  PAGECOUNT  	VARCHAR2(100),
  DATE_TIME1 	DATE not null,
  DATE_TIME2 	DATE not null,
  RESERVED1  	VARCHAR2(50),
  RESERVED2  	VARCHAR2(50)
);
alter table MED_PAGE_COUNT
  add constraint PATKEY primary key (PATIENT_ID, VISIT_ID, DEP_ID, DATE_TIME2, DATE_TIME1);
grant select, insert, update, delete on MED_PAGE_COUNT to ROLE_DOCARE;
grant select, insert, update, delete on MED_PAGE_COUNT to medcomm with grant option;

prompt
prompt Creating table MED_UNDERWRITE
prompt ==================================
prompt
create table MED_UNDERWRITE
(
  PATIENT_ID  VARCHAR2(20) not null,
  VISIT_ID    NUMBER(2) not null,
  DEP_ID      NUMBER(2) not null,
  DATE_TIME   DATE not null,
  UNDERWRITE1 VARCHAR2(16),
  UNDERWRITE2 VARCHAR2(16),
  UNDERWRITE3 VARCHAR2(16),
  RESERVED01  VARCHAR2(50),
  RESERVED02  VARCHAR2(50),
  RESERVED03  VARCHAR2(50),
  RESERVED04  VARCHAR2(50)
);
alter table MED_UNDERWRITE
  add constraint KEYS primary key (PATIENT_ID, DATE_TIME, VISIT_ID, DEP_ID);
grant select, insert, update, delete on MED_UNDERWRITE to ROLE_DOCARE;
grant select, insert, update, delete on MED_UNDERWRITE to medcomm with grant option;

prompt
prompt Creating table MED_RTS_SCORING_RESULT
prompt ==================================
prompt
create table MED_RTS_SCORING_RESULT
(
  PATIENT_ID        VARCHAR2(20) not null,
  VISIT_ID          NUMBER(2) not null,
  DEP_ID	    NUMBER(2) not null,
  SCORING_DATE_TIME DATE not null,
  GCS               NUMBER(3),
  SBP               NUMBER(5),
  R                 NUMBER(5),
  RESERVED01        NUMBER(5),
  RESERVED02        NUMBER(5),
  RESERVED03        NUMBER(5),
  MEMO              VARCHAR2(100)
);
alter table MED_RTS_SCORING_RESULT
  add constraint PK_RTS_SCORING_RESULT primary key (PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME);
grant select, insert, update, delete on MED_RTS_SCORING_RESULT to ROLE_DOCARE;
grant select, insert, update, delete on MED_RTS_SCORING_RESULT to medcomm with grant option;

prompt
prompt Creating table MED_SIRS_S_SCORING_RESULT
prompt ==================================
prompt
create table MED_SIRS_S_SCORING_RESULT
(
  PATIENT_ID        VARCHAR2(20) not null,
  VISIT_ID          NUMBER(2) not null,
  DEP_ID	    NUMBER(2) not null,
  SCORING_DATE_TIME DATE not null,
  TEMPERATURE       NUMBER(3),
  HEART_RATE        NUMBER(5),
  BREATH_FREQUENCY  NUMBER(5),
  WBC               NUMBER(5),
  RESERVED01        NUMBER(5),
  RESERVED02        NUMBER(5),
  RESERVED03        NUMBER(5),
  MEMO              VARCHAR2(100)
);
alter table MED_SIRS_S_SCORING_RESULT
  add constraint PK_SIRS_S_SCORING_RESULT primary key (PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME);
grant select, insert, update, delete on MED_SIRS_S_SCORING_RESULT to ROLE_DOCARE;
grant select, insert, update, delete on MED_SIRS_S_SCORING_RESULT to medcomm with grant option;

prompt
prompt Creating table MED_DEPT_USER
prompt ==================================
prompt
create table MED_DEPT_USER
(
  DEPT_CODE  VARCHAR2(20) not null,
  USER_ID    VARCHAR2(20) not null,
  USER_NAME  VARCHAR2(20),
  BIRTH_DATE DATE,
  DEGREE     VARCHAR2(20),
  CAREER     VARCHAR2(20),
  GENDER     VARCHAR2(20),
  EFFECTDATE DATE,
  QUITDATE   DATE
);
alter table MED_DEPT_USER
  add constraint MED_DEPT_USER_PRIMARY primary key (DEPT_CODE, USER_ID);
grant select, insert, update, delete on MED_DEPT_USER to ROLE_DOCARE;
grant select, insert, update, delete on MED_DEPT_USER to medcomm with grant option;

prompt
prompt Creating table MED_EMPLOYEE_WORK
prompt ==================================
prompt
create table MED_EMPLOYEE_WORK
(
  ID            NVARCHAR2(40) not null,
  EMPLOYEE_ID   NVARCHAR2(25),
  WORKING_TIME  DATE,
  SCHEDULE_NAME NVARCHAR2(25)
);
alter table MED_EMPLOYEE_WORK
  add constraint ID_EMPLOYEE_WORK primary key (ID);
grant select, insert, update, delete on MED_EMPLOYEE_WORK to ROLE_DOCARE;
grant select, insert, update, delete on MED_EMPLOYEE_WORK to medcomm with grant option;

prompt
prompt Creating table MED_PAT_INICU_INFORMATION
prompt ==================================
prompt
-- Create table MED_PAT_INICU_INFORMATION
create table MED_PAT_INICU_INFORMATION
(
  PATIENT_ID       VARCHAR2(20) not null,
  VISIT_ID         NUMBER(2) not null,
  DEP_ID           NUMBER(2) not null,
  IN_ICU_TIMES     NUMBER(4) not null,
  IN_ICU_DATETIME  DATE,
  OUT_ICU_DATETIME DATE,
  DIAGNOSE         VARCHAR2(200),
  BED_NO           VARCHAR2(20),
  DOCTOR           VARCHAR2(20),
  BODY_WEIGHT      NUMBER(6),
  BODY_HEIGHT      NUMBER(6),
  WARD_CODE        VARCHAR2(16),
  COMMIT_STATUS    VARCHAR2(16),
  RESERVED01       VARCHAR2(200),
  RESERVED02       VARCHAR2(200),
  RESERVED03       VARCHAR2(200),
  RESERVED04       VARCHAR2(200),
  RESERVED05       VARCHAR2(200),
  RESERVED06       VARCHAR2(200),
  RESERVED07       VARCHAR2(200),
  RESERVED08       VARCHAR2(200),
  RESERVED09       VARCHAR2(200),
  RESERVED10       VARCHAR2(200),
  RESERVED11       VARCHAR2(200),
  RESERVED12       VARCHAR2(200),
  RESERVED13       VARCHAR2(200),
  RESERVED14       VARCHAR2(200),
  RESERVED15       VARCHAR2(200),
  RESERVED16       VARCHAR2(200),
  RESERVED17       VARCHAR2(200),
  RESERVED18       VARCHAR2(200),
  RESERVED19       VARCHAR2(200),
  RESERVED20       VARCHAR2(200)
);
alter table MED_PAT_INICU_INFORMATION
  add constraint PK_MED_PAT_INICU_INFORMATION primary key (PATIENT_ID, VISIT_ID, DEP_ID, IN_ICU_TIMES);

grant select, insert, update, delete on MED_PAT_INICU_INFORMATION to ROLE_DOCARE;
grant select, insert, update, delete on MED_PAT_INICU_INFORMATION to medcomm with grant option;

prompt
prompt Creating table MED_FLOWCONTROLLER_TEMPLATE
prompt ==================================
prompt
create table MED_FLOWCONTROLLER_TEMPLATE
(
  TEMPLATEID     NVARCHAR2(100) not null,
  TEMPLATENAME   NVARCHAR2(25) not null,
  TEMPLATE       NCLOB not null,
  CREATEBY       VARCHAR2(20),
  CREATETIME     DATE,
  LASTCREATEBY   VARCHAR2(20),
  LASTCREATETIME DATE,
  ISDEFAULT      NUMBER
);
alter table MED_FLOWCONTROLLER_TEMPLATE
  add constraint PK_TEMPLATEID primary key (TEMPLATEID);
grant select, insert, update, delete on MED_FLOWCONTROLLER_TEMPLATE to ROLE_DOCARE;
grant select, insert, update, delete on MED_FLOWCONTROLLER_TEMPLATE to medcomm with grant option;

prompt
prompt Creating table MED_FLOWCONTROLLER_DATA
prompt ==================================
prompt
create table MED_FLOWCONTROLLER_DATA
(
  ID                         NVARCHAR2(100) not null,
  PATIENTID                  VARCHAR2(25) not null,
  HOSPITALIZATION_ID         NUMBER not null,
  FLOWCONTROLLER_ID          NVARCHAR2(100) not null,
  FLOWCONTROLLER_NAME        NVARCHAR2(50),
  FLOWCONTROLLER_REASON      NVARCHAR2(50),
  FLOWCONTROLLER_REASON_INFO NVARCHAR2(150),
  FLOWCONTROLLER_TIMEPOINT   DATE,
  FLOWCONTROLLER_DATA        NVARCHAR2(200),
  DEP_ID                     NUMBER
);
alter table MED_FLOWCONTROLLER_DATA
  add constraint PRIMARY_ID primary key (ID);
grant select, insert, update, delete on MED_FLOWCONTROLLER_DATA to ROLE_DOCARE;
grant select, insert, update, delete on MED_FLOWCONTROLLER_DATA to medcomm with grant option;

prompt
prompt Creating table MED_FLOWCONTROLLER_ITEM_DATA
prompt ==================================
prompt
create table MED_FLOWCONTROLLER_ITEM_DATA
(
  ID                 VARCHAR2(10) not null,
  PATIENT_ID         VARCHAR2(25) not null,
  HOSPITALIZATION_ID NUMBER not null,
  ITEM_NAME          VARCHAR2(50),
  ITEM_UNIT          VARCHAR2(25),
  ITEM_VALUE         VARCHAR2(50),
  CREATE_BY          VARCHAR2(20),
  CREATE_TIME        DATE,
  LAST_UPDATE_BY     VARCHAR2(20),
  LAST_UPDATE_TIME   DATE,
  TEMPLATEID         VARCHAR2(100),
  TEMPLATENAME       VARCHAR2(25),
  DEP_ID             NUMBER
);
alter table MED_FLOWCONTROLLER_ITEM_DATA
  add constraint ITEM_VALUE_PRIMARYKEY primary key (ID);
grant select, insert, update, delete on MED_FLOWCONTROLLER_ITEM_DATA to ROLE_DOCARE;
grant select, insert, update, delete on MED_FLOWCONTROLLER_ITEM_DATA to medcomm with grant option;

prompt
prompt Creating table MED_FLOWCONTROLLER_CONFIG
prompt ==================================
prompt
create table MED_FLOWCONTROLLER_CONFIG
(
  ITEM_ID          NVARCHAR2(25) not null,
  ITEM_NAME        VARCHAR2(25),
  ITEM_TYPE        VARCHAR2(20),
  CREATE_BY        VARCHAR2(20),
  CREATE_TIME      DATE,
  LAST_UPDATE_BY   VARCHAR2(20),
  LAST_UPDATE_TIME DATE
);
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_FLOWCONTROLLER_CONFIG
  add constraint PK_ITEM_ID primary key (ITEM_ID);
grant select, insert, update, delete on MED_FLOWCONTROLLER_CONFIG to ROLE_DOCARE;
grant select, insert, update, delete on MED_FLOWCONTROLLER_CONFIG to medcomm with grant option;

prompt
prompt Creating table MED_FLOWCONTROLLER_CONFIG_DATA
prompt ==================================
prompt
create table MED_FLOWCONTROLLER_CONFIG_DATA
(
  ITEM_ID            NVARCHAR2(25) not null,
  PATIENT_ID         VARCHAR2(25) not null,
  HOSPITALIZATION_ID NUMBER not null,
  ITEM_VALUE         VARCHAR2(25),
  CREATE_BY          VARCHAR2(25),
  CREATE_TIME        DATE,
  LAST_UPDATE_BY     VARCHAR2(25),
  LAST_UPDATE_TIME   DATE,
  DEP_ID             NUMBER
);
alter table MED_FLOWCONTROLLER_CONFIG_DATA
  add constraint TTEMDETAILSPRIMARYKEY primary key (ITEM_ID, PATIENT_ID, HOSPITALIZATION_ID);
alter table MED_FLOWCONTROLLER_CONFIG_DATA
  add constraint ITEMDETAILSFOREIGNKEY foreign key (ITEM_ID) references MED_FLOWCONTROLLER_CONFIG (ITEM_ID);
grant select, insert, update, delete on MED_FLOWCONTROLLER_CONFIG_DATA to ROLE_DOCARE;
grant select, insert, update, delete on MED_FLOWCONTROLLER_CONFIG_DATA to medcomm with grant option;

prompt
prompt Creating table MED_MEDICINE_IN_CATEGORY
prompt ==================================
prompt
create table MED_MEDICINE_IN_CATEGORY
(
  ID            NVARCHAR2(50) not null,
  CATEGORY_ID   NVARCHAR2(50),
  MEDICINE_NAME NVARCHAR2(50)
);
alter table MED_MEDICINE_IN_CATEGORY add constraint PK_MEDICINE_IN_CATEGORY primary key (ID);
grant select, insert, update, delete on MED_MEDICINE_IN_CATEGORY to ROLE_DOCARE;
grant select, insert, update, delete on MED_MEDICINE_IN_CATEGORY to medcomm with grant option;

prompt
prompt Creating table MED_MEDICINE_CATEGORY
prompt ==================================
prompt
create table MED_MEDICINE_CATEGORY
(
  CATEGORY_ID      NVARCHAR2(50) not null,
  CATEGORY_NAME    NVARCHAR2(50),
  CREATE_BY        NVARCHAR2(20),
  CREATE_TIME      DATE,
  LAST_UPDATE_BY   NVARCHAR2(20),
  LAST_UPDATE_TIME DATE
);
alter table MED_MEDICINE_CATEGORY
  add constraint PK_MEDICINE_CATEGORY primary key (CATEGORY_ID);
grant select, insert, update, delete on MED_MEDICINE_CATEGORY to ROLE_DOCARE;
grant select, insert, update, delete on MED_MEDICINE_CATEGORY to medcomm with grant option;

prompt
prompt Creating table MED_EQUIPMENT_USAGE
prompt ==================================
prompt
create table MED_EQUIPMENT_USAGE
(
  EQUIPMENT_NAME NVARCHAR2(60) not null,
  BEGIN_TIME     DATE not null,
  END_TIME       DATE,
  PATIENT_ID     NVARCHAR2(20) not null,
  VISIT_ID       NUMBER(2),
  CATEGORY       NVARCHAR2(20) not null,
  DEP_ID 	 NUMBER(2),
  WARD_CODE 	 NVARCHAR2(16),
  ID             NVARCHAR2(40) not null
);
alter table MED_EQUIPMENT_USAGE
  add constraint PK_EQUIPMENT_ID primary key (ID);
grant select, insert, update, delete on MED_EQUIPMENT_USAGE to ROLE_DOCARE;
grant select, insert, update, delete on MED_EQUIPMENT_USAGE to medcomm with grant option;

prompt
prompt Creating table MED_EQUIPMENT_USAGE
prompt ==================================
prompt
create table MED_PAGE_XUDA_FJSL
(
  PATIENT_ID         VARCHAR2(20) not null,
  VISIT_ID           NUMBER(2) not null,
  START_TIME         DATE not null,
  REMOVE_NO          NUMBER(6),
  START_NO           NUMBER(6),
  RECORD_DATE        DATE
);
alter table MED_PAGE_XUDA_FJSL
  add constraint PK_PAGE_XUDA primary key (PATIENT_ID, VISIT_ID, START_TIME);
grant select, insert, update, delete on MED_PAGE_XUDA_FJSL to MEDCOMM with grant option;
grant select, insert, update, delete on MED_PAGE_XUDA_FJSL to ROLE_DOCARE;

prompt
prompt Creating table MED_ICU_ESPECIAL_DOCUMENT
prompt ==================================
prompt
create table MED_ICU_ESPECIAL_DOCUMENT
(
  PATIENT_ID          VARCHAR2(20) not null,
  VISIT_ID            NUMBER(2) not null,
  DEP_ID              NUMBER(2) not null,
  DOCUMENT_NAME       VARCHAR2(40) not null,
  RECORDING_DATE_TIME DATE not null,
  RESERVED01          VARCHAR2(20),
  RESERVED02          VARCHAR2(20),
  RESERVED03          VARCHAR2(20),
  RESERVED04          VARCHAR2(20),
  RESERVED05          VARCHAR2(20),
  RESERVED06          VARCHAR2(20),
  RESERVED07          VARCHAR2(20),
  RESERVED08          VARCHAR2(20),
  RESERVED09          VARCHAR2(20),
  RESERVED10          VARCHAR2(20),
  RESERVED11          VARCHAR2(20),
  RESERVED12          VARCHAR2(20),
  RESERVED13          VARCHAR2(20),
  RESERVED14          VARCHAR2(20),
  RESERVED15          VARCHAR2(20),
  RESERVED16          VARCHAR2(20),
  RESERVED17          VARCHAR2(20),
  RESERVED18          VARCHAR2(20),
  RESERVED19          VARCHAR2(20),
  RESERVED20          VARCHAR2(20),
  RESERVED21          VARCHAR2(20),
  RESERVED22          VARCHAR2(20),
  RESERVED23          VARCHAR2(20),
  RESERVED24          VARCHAR2(20),
  RESERVED25          VARCHAR2(20),
  RESERVED26          VARCHAR2(20),
  RESERVED27          VARCHAR2(20),
  RESERVED28          VARCHAR2(20),
  RESERVED29          VARCHAR2(20),
  RESERVED30          VARCHAR2(20),
  RESERVED_DATE01     DATE,
  RESERVED_DATE02     DATE,
  RESERVED_DATE03     DATE,
  RESERVED_DATE04     DATE,
  MEMO01              VARCHAR2(255),
  MEMO02              VARCHAR2(255),
  OPERATOR            VARCHAR2(30),
  LOG_DATE_TIME       DATE
);
alter table MED_ICU_ESPECIAL_DOCUMENT
  add constraint PK_MED_ICU_ESPECIAL_DOCUMENT primary key (PATIENT_ID, VISIT_ID, DEP_ID, DOCUMENT_NAME, RECORDING_DATE_TIME);
grant select, insert, update, delete on MED_ICU_ESPECIAL_DOCUMENT to ROLE_DOCARE;
grant select, insert, update, delete on MED_ICU_ESPECIAL_DOCUMENT to medcomm with grant option;

prompt
prompt Creating table MED_ORDER_SPEED
prompt ==================================
prompt
create table MED_ORDER_SPEED
(
  PATIENT_ID  VARCHAR2(20) not null,
  VISIT_ID    NUMBER(2) not null,
  DEP_ID      NUMBER(2) not null,
  ORDER_NO    VARCHAR2(20) not null,
  TIME_POINT  DATE not null,
  SPEED       NUMBER(14,4),
  SIGN_VALUE  NUMBER(14,4),
  ORDER_STATE NUMBER(2),
  RESERVED1   VARCHAR2(100),
  RESERVED2   VARCHAR2(100),
  RESERVED3   VARCHAR2(100)
);
alter table MED_ORDER_SPEED
  add constraint ORDER_SPEED_KEY primary key (PATIENT_ID, VISIT_ID, DEP_ID, ORDER_NO, TIME_POINT);
grant select, insert, update, delete on MED_ORDER_SPEED to ROLE_DOCARE;
grant select, insert, update, delete on MED_ORDER_SPEED to medcomm with grant option;
