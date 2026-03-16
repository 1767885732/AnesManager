connect &MedSurgeryConn


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

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

connect &SystemConn


create or replace public synonym patient_class_dict
  for MEDSURGERY.patient_class_dict;
create or replace public synonym pat_adm_condition_dict
  for MEDSURGERY.pat_adm_condition_dict;

create or replace public synonym APACHE2_SCORING_RESULT_DETAIL
  for MEDSURGERY.APACHE2_SCORING_RESULT_DETAIL;

create or replace public synonym APGAR_SCORING_RESULT_DETAIL
  for MEDSURGERY.APGAR_SCORING_RESULT_DETAIL;

create or replace public synonym BALTH_SCORING_RESULT_DETAIL
  for MEDSURGERY.BALTH_SCORING_RESULT_DETAIL;


create or replace public synonym CG_SCORING_RESULT_DETAIL
  for MEDSURGERY.CG_SCORING_RESULT_DETAIL;

create or replace public synonym CPUGH_SCORING_RESULT_DETAIL
  for MEDSURGERY.CPUGH_SCORING_RESULT_DETAIL;

create or replace public synonym CRAMS_SCORING_RESULT_DETAIL
  for MEDSURGERY.CRAMS_SCORING_RESULT_DETAIL;

create or replace public synonym CRIB_SCORING_RESULT_DETAIL
  for MEDSURGERY.CRIB_SCORING_RESULT_DETAIL;


create or replace public synonym CSSS_SCORING_RESULT_DETAIL
  for MEDSURGERY.CSSS_SCORING_RESULT_DETAIL;

create or replace public synonym GCS_SCORING_RESULT_DETAIL
  for MEDSURGERY.GCS_SCORING_RESULT_DETAIL;


create or replace public synonym GOLDMAN_SCORING_RESULT_DETAIL
  for MEDSURGERY.GOLDMAN_SCORING_RESULT_DETAIL;

create or replace public synonym GP_SCORING_RESULT_DETAIL
  for MEDSURGERY.GP_SCORING_RESULT_DETAIL;

create or replace public synonym IMP_ITEM_VS_DICT
  for MEDSURGERY.IMP_ITEM_VS_DICT;

create or replace public synonym LUTZ_SCORING_RESULT_DETAIL
  for MEDSURGERY.LUTZ_SCORING_RESULT_DETAIL;


create or replace public synonym MODS2_SCORING_RESULT_DETAIL
  for MEDSURGERY.MODS2_SCORING_RESULT_DETAIL;


create or replace public synonym MODS_SCORING_RESULT_DETAIL
  for MEDSURGERY.MODS_SCORING_RESULT_DETAIL;

create or replace public synonym NORTON_SCORING_RESULT_DETAIL
  for MEDSURGERY.NORTON_SCORING_RESULT_DETAIL;


create or replace public synonym PARS_SCORING_RESULT_DETAIL
  for MEDSURGERY.PARS_SCORING_RESULT_DETAIL;

create or replace public synonym PATIENT_SCORING_RESULT
  for MEDSURGERY.PATIENT_SCORING_RESULT;

create or replace public synonym PATIENT_SCORING_RESULT_DETAIL
  for MEDSURGERY.PATIENT_SCORING_RESULT_DETAIL;

create or replace public synonym SAPS2_SCORING_RESULT_DETAIL
  for MEDSURGERY.SAPS2_SCORING_RESULT_DETAIL;


create or replace public synonym SCORING_ITEM_LIST
  for MEDSURGERY.SCORING_ITEM_LIST;

  
  
create or replace public synonym TISS_SCORING_RESULT_DETAIL
  for MEDSURGERY.TISS_SCORING_RESULT_DETAIL;

  create or replace public synonym SSS_SCORING_RESULT_DETAIL
  for MEDSURGERY.SSS_SCORING_RESULT_DETAIL;
  
  create or replace public synonym SSSS_SCORING_RESULT_DETAIL
  for MEDSURGERY.SSSS_SCORING_RESULT_DETAIL;
  
   create or replace public synonym SOFA_SCORING_RESULT_DETAIL
  for MEDSURGERY.SOFA_SCORING_RESULT_DETAIL;
  
 create or replace public synonym SCORING_VALUE_MEMO_DICT
  for MEDSURGERY.SCORING_VALUE_MEMO_DICT;
 
 
  create or replace public synonym SCORING_METHOD_DICT
  for MEDSURGERY.SCORING_METHOD_DICT;

