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
  
--为权限表增加初始化记录SQL脚本
INSERT INTO MED_PERMISSIONS(PERMISSION_ID,APP_ID,NAME,PERMISSION_KEY,IS_VALID,DESCRIPTION)
VALUES('5001','ANESPERSONAL','手术排班-分配手术','手术排班-分配手术','T','为手术分配手术间');
INSERT INTO MED_PERMISSIONS(PERMISSION_ID,APP_ID,NAME,PERMISSION_KEY,IS_VALID,DESCRIPTION)
VALUES('5002','ANESPERSONAL','手术排班-主麻醉医师','手术排班-主麻醉医师','T','为主麻醉医师分配手术间');
INSERT INTO MED_PERMISSIONS(PERMISSION_ID,APP_ID,NAME,PERMISSION_KEY,IS_VALID,DESCRIPTION)
VALUES('5003','ANESPERSONAL','手术排班-副麻醉医师','手术排班-副麻醉医师','T','为副麻醉医师分配手术间');
INSERT INTO MED_PERMISSIONS(PERMISSION_ID,APP_ID,NAME,PERMISSION_KEY,IS_VALID,DESCRIPTION)
VALUES('5004','ANESPERSONAL','手术排班-分配麻醉方法','手术排班-分配麻醉方法','T','为手术分配麻醉方法');
INSERT INTO MED_PERMISSIONS(PERMISSION_ID,APP_ID,NAME,PERMISSION_KEY,IS_VALID,DESCRIPTION)
VALUES('5005','ANESPERSONAL','手术排班-分配洗手护士','手术排班-分配洗手护士','T','为手术间分配洗手护士');
INSERT INTO MED_PERMISSIONS(PERMISSION_ID,APP_ID,NAME,PERMISSION_KEY,IS_VALID,DESCRIPTION)
VALUES('5006','ANESPERSONAL','手术排班-分配巡回护士','手术排班-分配巡回护士','T','为手术间分配巡回护士');
INSERT INTO MED_PERMISSIONS(PERMISSION_ID,APP_ID,NAME,PERMISSION_KEY,IS_VALID,DESCRIPTION)
VALUES('5007','ANESPERSONAL','手术排班-系统配置','手术排班-系统配置','T','系统配置');
INSERT INTO MED_PERMISSIONS(PERMISSION_ID,APP_ID,NAME,PERMISSION_KEY,IS_VALID,DESCRIPTION)
VALUES('5008','ANESPERSONAL','手术排班-手术申请','手术排班-手术申请','T','手术申请');
INSERT INTO MED_PERMISSIONS(PERMISSION_ID,APP_ID,NAME,PERMISSION_KEY,IS_VALID,DESCRIPTION)
VALUES('5009','ANESPERSONAL','手术排班-手术撤销','手术排班-手术撤销','T','作废或提交的手术撤销');
INSERT INTO MED_PERMISSIONS(PERMISSION_ID,APP_ID,NAME,PERMISSION_KEY,IS_VALID,DESCRIPTION)
VALUES('5010','ANESPERSONAL','手术排班-手术提交','手术排班-手术提交','T','排班完成之后提交手术');
INSERT INTO MED_PERMISSIONS(PERMISSION_ID,APP_ID,NAME,PERMISSION_KEY,IS_VALID,DESCRIPTION)
VALUES('5011','ANESPERSONAL','手术排班-HIS同步','手术排班-HIS同步','T','同步HIS数据');
INSERT INTO MED_PERMISSIONS(PERMISSION_ID,APP_ID,NAME,PERMISSION_KEY,IS_VALID,DESCRIPTION)
VALUES('5012','ANESPERSONAL','人员排班-麻醉医师','人员排班-麻醉医师','T','麻醉医师排班');
INSERT INTO MED_PERMISSIONS(PERMISSION_ID,APP_ID,NAME,PERMISSION_KEY,IS_VALID,DESCRIPTION)
VALUES('5013','ANESPERSONAL','人员排班-护士','人员排班-护士','T','护士排班');
COMMIT;

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

