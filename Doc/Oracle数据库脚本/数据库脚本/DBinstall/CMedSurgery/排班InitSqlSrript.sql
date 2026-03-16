--系统配置建表语句及初始值

--手术间配置配置
create table MED_SYSTEM_CONFIG_OPEROOM
(
  ROOM_NO             NVARCHAR2(4) not null,--手术间号
  MAX_OPERATION_COUNT NUMBER,				--最大手术台数
  DEPT_CODE           NVARCHAR2(80)			--科室代码
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
alter table MED_SYSTEM_CONFIG_OPEROOM
  add constraint SYSTEM_CONFIG_OPEROOM_PRIMARY primary key (ROOM_NO)
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
--医生护士配置
create table MED_SYSTEM_CONFIG_USER
(
  USER_ID            NVARCHAR2(20) not null,--用户ID
  USER_JOB           NVARCHAR2(10), --用户类型（医生/护士）
  ORDER_NUMBER       NUMBER,                --排序序号
  MAX_OPEROOM_COUNT  NUMBER,                --最大手术间数
  USER_NAME          NVARCHAR2(10),         --用户名
  DEFAULT_OPEROOM_NO NVARCHAR2(20),			--默认手术间号
  USER_TYPE			 NVARCHAR2(10),			--用户类别:主麻医师/副麻医师/洗手护士/巡回护士
  NAME_SHORTEN		 NVARCHAR2(10)			--用户名称简称
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
alter table MED_SYSTEM_CONFIG_USER
  add constraint SYSTEM_CONFIG_USER_PRIMARY primary key (USER_ID)
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
  
  --医生护士模板
  create table MED_SCHEDULE_TEMPLATE
(
  TEMPLATE_ID   NVARCHAR2(40) not null,--模板ID
  TEMPLATE_NAME NVARCHAR2(30)          --模板名称
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
alter table MED_SCHEDULE_TEMPLATE
  add constraint TEMPLATE_PARIMARY_KEY primary key (TEMPLATE_ID)
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

--模板详细信息
create table MED_SCHEDULE_TEMPLATE_DETAIL
(
  TEMPLATE_ID  NVARCHAR2(40) not null,--模板ID
  ROOM_NO      NVARCHAR2(10) not null,--手术间号
  ANES_DOCTOR1 NVARCHAR2(10),	      --麻醉医师1
  ANES_DOCTOR2 NVARCHAR2(10),		  --麻醉医师2
  XS_NURSE1    NVARCHAR2(10),		  --洗手护士1
  XS_NURSE2    NVARCHAR2(10),         --洗手护士2
  XH_NURSE1    NVARCHAR2(10),		  --巡回护士1
  XH_NURSE2    NVARCHAR2(10)		  --巡回护士2
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
alter table MED_SCHEDULE_TEMPLATE_DETAIL
  add constraint TEMPLATE_DETAIL_PRIMARY_KEY primary key (TEMPLATE_ID, ROOM_NO)
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
 


-- 增加手术预约表状态字段
alter table MED_OPERATION_SCHEDULE add STATE NUMBER(2) default 0;
-- Add comments to the columns 
comment on column MED_OPERATION_SCHEDULE.STATE
  is '默认为0,已分配为1,已提交为2,已作废为-1';
  
-- Add/modify columns 
alter table MED_OPERATION_SCHEDULE add OPERATION_NAME varchar2(300);
-- Add comments to the columns 
comment on column MED_OPERATION_SCHEDULE.OPERATION_NAME
  is '手术名称，一个病人多台手术用逗号分隔';
  
--手术排班切换界面中配置grid的显示列
-- Create table
create table MED_SYSTEM_CONFIG_GRID
(
  USER_NAME NVARCHAR2(36) not null, --登录用户名
  FIELDS    NVARCHAR2(100)          --列名(用逗号隔开)
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
alter table MED_SYSTEM_CONFIG_GRID
  add constraint GRIDCONFIGPRIMARY primary key (USER_NAME)
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


  
-- 人员排班配置表
-- Create table
create table MED_PERSON_SCHEDULE_CONFIG
(
  ITEM_CODE  NUMBER not null,
  ITEM_NAME  VARCHAR2(20),
  IS_DIVIDED NUMBER(1)
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
-- Add comments to the columns 
comment on column MED_PERSON_SCHEDULE_CONFIG.IS_DIVIDED
  is '在手术通知单中是否分开显示。0：不分开，1：分开。';
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_PERSON_SCHEDULE_CONFIG
  add constraint PERSON_SCHEDULE_CONFIG_PRIMARY primary key (ITEM_CODE)
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
 --苏大附一数据，其中1代表白天需要安排到手术间的医师和护士，手术排班中的医师和护士通过该item_code=1过滤，该条数据不允许删除。
insert into MED_PERSON_SCHEDULE_CONFIG (ITEM_CODE, ITEM_NAME, IS_DIVIDED)
values (1, '白班', 0);
 insert into MED_PERSON_SCHEDULE_CONFIG (ITEM_CODE, ITEM_NAME, IS_DIVIDED)
values (2, '值班', 1);
insert into MED_PERSON_SCHEDULE_CONFIG (ITEM_CODE, ITEM_NAME, IS_DIVIDED)
values (3, '夜休', 1);
insert into MED_PERSON_SCHEDULE_CONFIG (ITEM_CODE, ITEM_NAME, IS_DIVIDED)
values (4, '11-6', 1);
insert into MED_PERSON_SCHEDULE_CONFIG (ITEM_CODE, ITEM_NAME, IS_DIVIDED)
values (5, '2-6护士', 0);
insert into MED_PERSON_SCHEDULE_CONFIG (ITEM_CODE, ITEM_NAME, IS_DIVIDED)
values (6, '器械', 0);
insert into MED_PERSON_SCHEDULE_CONFIG (ITEM_CODE, ITEM_NAME, IS_DIVIDED)
values (7, '机动', 0);
insert into MED_PERSON_SCHEDULE_CONFIG (ITEM_CODE, ITEM_NAME, IS_DIVIDED)
values (8, '产假', 0);
insert into MED_PERSON_SCHEDULE_CONFIG (ITEM_CODE, ITEM_NAME, IS_DIVIDED)
values (9, '病假', 0);
insert into MED_PERSON_SCHEDULE_CONFIG (ITEM_CODE, ITEM_NAME, IS_DIVIDED)
values (10, '休息', 0);
insert into MED_PERSON_SCHEDULE_CONFIG (ITEM_CODE, ITEM_NAME, IS_DIVIDED)
values (11, '教学', 0);
insert into MED_PERSON_SCHEDULE_CONFIG (ITEM_CODE, ITEM_NAME, IS_DIVIDED)
values (12, '门诊小手术1', 0);
insert into MED_PERSON_SCHEDULE_CONFIG (ITEM_CODE, ITEM_NAME, IS_DIVIDED)
values (13, '门诊小手术2', 0);
insert into MED_PERSON_SCHEDULE_CONFIG (ITEM_CODE, ITEM_NAME, IS_DIVIDED)
values (14, '外出开会', 0);
insert into MED_PERSON_SCHEDULE_CONFIG (ITEM_CODE, ITEM_NAME, IS_DIVIDED)
values (15, '加班', 0);
commit;
  
  
--人员排班数据
-- Create table
create table MED_PERSON_SCHEDULE
(
  ITEM_CODE     NUMBER not null,
  SCHEDULE_DATE DATE not null,
  USER_ID       VARCHAR2(20) not null,
  TEMPLATE_NAME VARCHAR2(40),
  CREAT_TIME    DATE default SYSDATE
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
alter table MED_PERSON_SCHEDULE
  add constraint PERSON_SCHEDULE_PRIMARY primary key (ITEM_CODE, SCHEDULE_DATE, USER_ID)
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
  
--手术排班配置信息表
  -- Create table
create table MED_OPERATION_SCHEDULE_CONFIG
(
  ITEM_NAME  NVARCHAR2(30) not null,
  ITEM_VALUE NVARCHAR2(30),
  ITEM_DESC  NVARCHAR2(50)
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
alter table MED_OPERATION_SCHEDULE_CONFIG
  add constraint OPE_SCHEDULE_CONFIG_PRIMARY primary key (ITEM_NAME)
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
--初始化数据  
insert into MED_OPERATION_SCHEDULE_CONFIG (ITEM_NAME, ITEM_VALUE, ITEM_DESC)
values ('OperoomRowCount', '4', '手术间行数');
insert into MED_OPERATION_SCHEDULE_CONFIG (ITEM_NAME, ITEM_VALUE, ITEM_DESC)
values ('OperoomColCount', '6', '手术间列数');
insert into MED_OPERATION_SCHEDULE_CONFIG (ITEM_NAME, ITEM_VALUE, ITEM_DESC)
values ('DefaultAnesMethod', null, '默认麻醉方法');
insert into MED_OPERATION_SCHEDULE_CONFIG (ITEM_NAME, ITEM_VALUE, ITEM_DESC)
values ('HisOperScheduleAfterDay', '3', '提取HIS手术申请日期为当前日期的后几天');
insert into MED_OPERATION_SCHEDULE_CONFIG (ITEM_NAME, ITEM_VALUE, ITEM_DESC)
values ('HisOperScheduleBeforeDay', '2', '提取HIS手术申请日期为当前日期的前几天');
insert into MED_OPERATION_SCHEDULE_CONFIG (ITEM_NAME, ITEM_VALUE, ITEM_DESC)
values ('ConcurrencyShowMessage', 'false', '并发时是否显示提示信息');
insert into MED_OPERATION_SCHEDULE_CONFIG (ITEM_NAME, ITEM_VALUE, ITEM_DESC)
values ('OperRoomDept', '1280000', '手术科室');
insert into MED_OPERATION_SCHEDULE_CONFIG (ITEM_NAME, ITEM_VALUE, ITEM_DESC)
values ('AnesDept', '1290000', '麻醉科室');
commit;



--用MedSurgery创建视图
CREATE OR REPLACE VIEW SCHEDULEREPORTVIEW AS
SELECT A.OPERATING_ROOM_NO || '-' || A.SEQUENCE AS OPERATING_ROOM_NO_SEQUENCE,A.SCHEDULED_DATE_TIME,B.NAME AS PAT_NAME,TO_CHAR(SYSDATE,'YYYY') - TO_CHAR(B.DATE_OF_BIRTH,'YYYY') AS PAT_AGE,A.PATIENT_ID, A.BED_NO AS BED_NO,B.SEX,A.DIAG_BEFORE_OPERATION,
A.OPERATION_NAME,NVL(D.USER_NAME,A.SURGEON) AS SURGEON_NAME,NVL(TRIM(E.USER_NAME),A.FIRST_ASSISTANT) AS FIRST_ASSISTANT_NAME,NVL(TRIM(F.USER_NAME),A.SECOND_ASSISTANT) AS SECOND_ASSISTANT_NAME,NVL(TRIM(G.USER_NAME),A.THIRD_ASSISTANT) AS THIRD_ASSISTANT_NAME, NVL(TRIM(H.USER_NAME), A.FOURTH_ASSISTANT) AS FOURTH_ASSISTANT_NAME,
NVL(TRIM(O.ANAESTHESIA_SHORTEN),A.ANESTHESIA_METHOD) AS ANESTHESIA_METHOD,I.USER_NAME AS ANESTHESIA_DOCTOR_NAME,A.OPERATING_DEPT,Y.DEPT_NAME AS OPERATING_DEPT_NAME,
J.USER_NAME AS ANESTHESIA_ASSISTANT_NAME, NVL(TRIM(X.NAME_SHORTEN),W.USER_NAME) AS SECOND_ANESTHESIA_NAME,A.OPERATING_ROOM_NO,
CASE WHEN NVL(TRIM(K.USER_NAME),'-1') = '-1' THEN  NVL(TRIM(R.NAME_SHORTEN),M.USER_NAME)  ELSE CASE WHEN NVL(TRIM(M.USER_NAME),'-1') = '-1' THEN  NVL(TRIM(P.NAME_SHORTEN),K.USER_NAME) ELSE NVL(TRIM(P.NAME_SHORTEN),K.USER_NAME)|| '/' || NVL(TRIM(R.NAME_SHORTEN),M.USER_NAME) END END AS FIRST_OPERATION_NURSE_NAME,
CASE WHEN NVL(TRIM(L.USER_NAME),'-1') = '-1' THEN  NVL(TRIM(S.NAME_SHORTEN),N.USER_NAME)  ELSE CASE WHEN NVL(TRIM(N.USER_NAME),'-1') = '-1' THEN  NVL(TRIM(Q.NAME_SHORTEN),L.USER_NAME) ELSE NVL(TRIM(Q.NAME_SHORTEN),L.USER_NAME)|| '/' || NVL(TRIM(S.NAME_SHORTEN),N.USER_NAME) END END AS FIRST_SUPPLY_NURSE_NAME,
V.DEPT_NAME AS WARD_CODE_NAME,B.INP_NO
FROM MED_OPERATION_SCHEDULE A LEFT OUTER JOIN MED_PAT_MASTER_INDEX B ON A.PATIENT_ID = B.PATIENT_ID
LEFT OUTER JOIN MED_HIS_USERS D ON A.SURGEON = D.USER_ID
LEFT OUTER JOIN MED_HIS_USERS E ON A.FIRST_ASSISTANT = E.USER_ID
LEFT OUTER JOIN MED_HIS_USERS F ON A.SECOND_ASSISTANT = F.USER_ID
LEFT OUTER JOIN MED_HIS_USERS G ON A.THIRD_ASSISTANT = G.USER_ID
LEFT OUTER JOIN MED_HIS_USERS H ON A.FOURTH_ASSISTANT = H.USER_ID
LEFT OUTER JOIN MED_HIS_USERS I ON A.ANESTHESIA_DOCTOR = I.USER_ID
LEFT OUTER JOIN MED_HIS_USERS J ON A.ANESTHESIA_ASSISTANT = J.USER_ID
LEFT OUTER JOIN MED_HIS_USERS K ON A.FIRST_OPERATION_NURSE = K.USER_ID
LEFT OUTER JOIN MED_HIS_USERS L ON A.FIRST_SUPPLY_NURSE = L.USER_ID
LEFT OUTER JOIN MED_HIS_USERS M ON A.SECOND_OPERATION_NURSE = M.USER_ID
LEFT OUTER JOIN MED_HIS_USERS N ON A.SECOND_SUPPLY_NURSE = N.USER_ID
LEFT OUTER JOIN MED_ANAESTHESIA_DICT O ON A.ANESTHESIA_METHOD = O.ANAESTHESIA_NAME
LEFT OUTER JOIN MED_SYSTEM_CONFIG_USER P ON K.USER_ID = P.USER_ID
LEFT OUTER JOIN MED_SYSTEM_CONFIG_USER Q ON L.USER_ID = Q.USER_ID
LEFT OUTER JOIN MED_SYSTEM_CONFIG_USER R ON M.USER_ID = R.USER_ID
LEFT OUTER JOIN MED_SYSTEM_CONFIG_USER S ON N.USER_ID = S.USER_ID
LEFT OUTER JOIN MED_DEPT_DICT T ON A.DEPT_STAYED = T.DEPT_CODE
LEFT OUTER JOIN MED_PATS_IN_HOSPITAL U ON A.PATIENT_ID = U.PATIENT_ID AND A.VISIT_ID = U.VISIT_ID
LEFT OUTER JOIN MED_DEPT_DICT V ON U.WARD_CODE = V.DEPT_CODE
LEFT OUTER JOIN MED_HIS_USERS W ON A.SECOND_ANESTHESIA_ASSISTANT = W.USER_ID
LEFT OUTER JOIN MED_SYSTEM_CONFIG_USER X ON W.USER_ID = X.USER_ID
LEFT OUTER JOIN MED_DEPT_DICT Y ON A.OPERATING_DEPT = Y.DEPT_CODE
WHERE (A.STATE = 3 OR A.STATE = 2)
ORDER BY TO_NUMBER(REPLACE(A.OPERATING_ROOM_NO,'-','.')),A.SEQUENCE



