--赵志成 2011年3月4日 麻醉单药物曲线左侧默认项目配置
CREATE TABLE MED_PATIENT_DRUG_ITEM(
  PATIENT_ID nvarchar2(20) NOT NULL,
  VISIT_ID numeric(2, 0) NOT NULL,
  OPER_ID numeric(2, 0) NOT NULL,
  SERIAL_NO numeric(4, 0) NOT NULL,
  ITEM_NAME1 nvarchar2(20) NULL,
  ITEM_UNIT1 nvarchar2(20) NULL,
  ITEM_NAME2 nvarchar2(20) NULL,
  ITEM_UNIT2 nvarchar2(20) NULL,
 CONSTRAINT PK_MED_PATIENT_DRUG_ITEM PRIMARY KEY  
(
  PATIENT_ID ,
  VISIT_ID ,
  OPER_ID ,
  SERIAL_NO 
) 
);

grant select, insert, update, delete on MED_PATIENT_DRUG_ITEM to ROLE_DOCARE;


rem==吴逸华=2011.03.10======================
--增加文书模板表区别模板所属程序字段
alter table MED_DOCUMENT_TEMPLET add EVENT_NO NUMBER(3) NOT NULL; 


rem==戴呈祥=2011.03.14麻醉事件字典常用量======================
 alter table MED_ANESTHESIA_EVENT_OPEN add STANDARD_DOSAGE1     number(8,4)         null;
  alter table MED_ANESTHESIA_EVENT_OPEN add STANDARD_DOSAGE2     number(8,4)         null;
   alter table MED_ANESTHESIA_EVENT_OPEN add STANDARD_DOSAGE3     number(8,4)         null;
    alter table MED_ANESTHESIA_EVENT_OPEN add STANDARD_DOSAGE4     number(8,4)         null;
     alter table MED_ANESTHESIA_EVENT_OPEN add STANDARD_DOSAGE5     number(8,4)         null;
      alter table MED_ANESTHESIA_EVENT_OPEN add STANDARD_DOSAGE6     number(8,4)         null;
       alter table MED_ANESTHESIA_EVENT_OPEN add STANDARD_DOSAGE7     number(8,4)         null;
        alter table MED_ANESTHESIA_EVENT_OPEN add STANDARD_DOSAGE8     number(8,4)         null;
         alter table MED_ANESTHESIA_EVENT_OPEN add STANDARD_DOSAGE9     number(8,4)         null;
          alter table MED_ANESTHESIA_EVENT_OPEN add STANDARD_DOSAGE10     number(8,4)         null;
           alter table MED_ANESTHESIA_EVENT_OPEN add STANDARD_DOSAGE11     number(8,4)         null;
            alter table MED_ANESTHESIA_EVENT_OPEN add STANDARD_DOSAGE12     number(8,4)         null;
             alter table MED_ANESTHESIA_EVENT_OPEN add STANDARD_DOSAGE13     number(8,4)         null;
              alter table MED_ANESTHESIA_EVENT_OPEN add STANDARD_DOSAGE14     number(8,4)         null;
               alter table MED_ANESTHESIA_EVENT_OPEN add STANDARD_DOSAGE15     number(8,4)         null;
               

-- PACU交班医嘱表, 苏大文书中使用
create table MEDSURGERY.MED_PACU_HANDOVER_ORDERS
(
  PATIENT_ID         VARCHAR2(20) not null,
  VISIT_ID           NUMBER(2) not null,
  OPER_ID            NUMBER(2) not null,
  ITEM_NO           NUMBER(2) not null,
  ORDER_TIME            DATE ,
  PACU_ORDER            VARCHAR2(200) ,
  DOCTOR_NAME            VARCHAR2(20) ,
  EXEC_TIME              DATE ,
  EXEC_NAME              VARCHAR2(20)
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
alter table MEDSURGERY.MED_PACU_HANDOVER_ORDERS
  add constraint PK_MED_PACU_HANDOVER_ORDERS primary key (PATIENT_ID, VISIT_ID, OPER_ID, ITEM_NO)
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
-- Grant/Revoke object privileges 
grant select, insert, update, delete, alter on MEDSURGERY.MED_PACU_HANDOVER_ORDERS to ROLE_DOCARE;




-- PACU交班置管情况表, 苏大文书中使用
create table MEDSURGERY.MED_PACU_HANDOVER_PUTPIPE
(
  PATIENT_ID         VARCHAR2(20) not null,
  VISIT_ID           NUMBER(2) not null,
  OPER_ID            NUMBER(2) not null,
  ITEM_NO           NUMBER(2) not null,
  PIPE_STATUS            VARCHAR2(20) ,
  PIPE1            VARCHAR2(20) ,
  PIPE2            VARCHAR2(20) ,
  PIPE3            VARCHAR2(20) ,
  PIPE4            VARCHAR2(20) ,
  PIPE5            VARCHAR2(20) ,
  PIPE6            VARCHAR2(20) ,
  PIPE7            VARCHAR2(20) ,
  PIPE8            VARCHAR2(20) ,
  PIPE9            VARCHAR2(20) ,
  PIPE10            VARCHAR2(20)
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
alter table MEDSURGERY.MED_PACU_HANDOVER_PUTPIPE
  add constraint PK_MED_PACU_HANDOVER_PUTPIPE primary key (PATIENT_ID, VISIT_ID, OPER_ID, ITEM_NO)
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
-- Grant/Revoke object privileges 
grant select, insert, update, delete, alter on MEDSURGERY.MED_PACU_HANDOVER_PUTPIPE to ROLE_DOCARE;


-- Create table
create table MED_PACU_SORCE
(
	ORDER_ID			NUMBER(10),
  CRITERION     VARCHAR2(10) not null,
  ZERO          VARCHAR2(50),
  ONE           VARCHAR2(50),
  TWO           VARCHAR2(50),
  EVENTHAPPEN   VARCHAR2(10),
  TIME          DATE ,
  MYODYNAMIA    NUMBER(5),
  BREATH        NUMBER(5),
  CYCLE         NUMBER(5),
  SPO2          NUMBER(5),
  CONSCIOUSNESS NUMBER(5),
  TOTAL         NUMBER(5),
  SIGNATURE     VARCHAR2(10),
  PATIENT_ID    VARCHAR2(20) not null,
  VISIT_ID      NUMBER(2) not null,
  OPER_ID       NUMBER(2) not null
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
alter table MED_PACU_SORCE
  add constraint PK_PACUSORCE primary key (PATIENT_ID, VISIT_ID, OPER_ID, CRITERION)
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
grant select, insert, update, delete, alter on MEDSURGERY.MED_PACU_SORCE to ROLE_DOCARE;

-- Create table
create table MED_ANES_OPERHANDOVER
(
  PATIENT_ID             VARCHAR2(20) not null,
  VISIT_ID               NUMBER(2) not null,
  OPER_ID                NUMBER(2) not null,
  FIRST_ANES_DOCTOR      VARCHAR2(8),
  SECOND_ANES_DOCTOR     VARCHAR2(8),
  THIRD_ANES_DOCTOR      VARCHAR2(8),
  FIRST_OPERATION_NURSE  VARCHAR2(8),
  SECOND_OPERATION_NURSE VARCHAR2(8),
  THIRD_OPERATION_NURSE  VARCHAR2(8),
  OTHER                  VARCHAR2(8),
  HANDOVER_DATE_TIME     DATE,
  HANDOVER_DATE_TIME2     DATE,
  MEMO                   VARCHAR2(100)
)
tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 16
    minextents 1
    maxextents unlimited
  );
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_ANES_OPERHANDOVER
  add constraint PK_MED_ANES_OPERHANDOVER primary key (PATIENT_ID, VISIT_ID, OPER_ID)
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
-- Grant/Revoke object privileges 
grant select, insert, update, delete, alter on MED_ANES_OPERHANDOVER to ROLE_DOCARE;

create table MEDSURGERY.MED_PUNCTURE_RECORD
(
  PATIENT_ID          VARCHAR2(20) not null,
  VISIT_ID            NUMBER(2) not null,
  OPER_ID             NUMBER(2) not null,
  RECORD_TIME         DATE,
  A_PUNCTURE_PERSON   VARCHAR2(20),
  A_PUNCTURE_NEEDLE   VARCHAR2(20),
  A_PUNCTURE_POSITION VARCHAR2(20),
  A_COMPLICATIONS1    NUMBER(1),
  A_COMPLICATIONS2    NUMBER(1),
  A_COMPLICATIONS3    NUMBER(1),
  V_PUNCTURE_PERSON   VARCHAR2(20),
  V_PUNCTURE_NEEDLE   VARCHAR2(20),
  V_PUNCTURE_POSITION VARCHAR2(20),
  V_COMPLICATIONS1    NUMBER(1),
  V_COMPLICATIONS2    NUMBER(1),
  V_COMPLICATIONS3    NUMBER(1),
  V_COMPLICATIONS4    NUMBER(1),
  V_COMPLICATIONS5    NUMBER(1),
  PUNCTURE_NURSE      VARCHAR2(20),
  MEMO                VARCHAR2(80)
)
tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 16
    minextents 1
    maxextents unlimited
  );
comment on table MEDSURGERY.MED_PUNCTURE_RECORD
  is '穿刺记录表';
comment on column MEDSURGERY.MED_PUNCTURE_RECORD.RECORD_TIME
  is '登记时间';
comment on column MEDSURGERY.MED_PUNCTURE_RECORD.A_PUNCTURE_PERSON
  is '动脉穿刺者';
comment on column MEDSURGERY.MED_PUNCTURE_RECORD.A_PUNCTURE_NEEDLE
  is '动脉穿刺针';
comment on column MEDSURGERY.MED_PUNCTURE_RECORD.A_PUNCTURE_POSITION
  is '动脉穿刺点';
comment on column MEDSURGERY.MED_PUNCTURE_RECORD.V_PUNCTURE_PERSON
  is '静脉穿刺者';
comment on column MEDSURGERY.MED_PUNCTURE_RECORD.V_PUNCTURE_NEEDLE
  is '静脉穿刺针';
comment on column MEDSURGERY.MED_PUNCTURE_RECORD.V_PUNCTURE_POSITION
  is '静脉穿刺点';
comment on column MEDSURGERY.MED_PUNCTURE_RECORD.PUNCTURE_NURSE
  is '护士';
comment on column MEDSURGERY.MED_PUNCTURE_RECORD.MEMO
  is '备注';
alter table MEDSURGERY.MED_PUNCTURE_RECORD
  add constraint PK_MED_PUNCTURE_RECORD primary key (PATIENT_ID, VISIT_ID, OPER_ID)
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
grant select, insert, update, delete, alter on MEDSURGERY.MED_PUNCTURE_RECORD to ROLE_DOCARE;

-- Create table
create table MEDSURGERY.MED_OPER_SHIFT_RECORD
(
  PATIENT_ID      VARCHAR2(20) not null,
  VISIT_ID        NUMBER(2) not null,
  OPER_ID         NUMBER(2) not null,
  SHIFT_NO        NUMBER(2) not null,
  SHIFT_DATE_TIME DATE,
  SHIFTED_BY      VARCHAR2(8),
  SHIFT_PERSON    VARCHAR2(8),
  SHIFT_DUTY      VARCHAR2(8),
  MEMO            VARCHAR2(100)
)
tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 16
    minextents 1
    maxextents unlimited
  );
-- Add comments to the table 
comment on table MEDSURGERY.MED_OPER_SHIFT_RECORD
  is '交班记录表';
-- Add comments to the columns 
comment on column MEDSURGERY.MED_OPER_SHIFT_RECORD.SHIFT_DATE_TIME
  is '交班时间';
comment on column MEDSURGERY.MED_OPER_SHIFT_RECORD.SHIFTED_BY
  is '交班人';
comment on column MEDSURGERY.MED_OPER_SHIFT_RECORD.SHIFT_PERSON
  is '接班人';
comment on column MEDSURGERY.MED_OPER_SHIFT_RECORD.SHIFT_DUTY
  is '工作类型';
comment on column MEDSURGERY.MED_OPER_SHIFT_RECORD.MEMO
  is '交班备注';
-- Create/Recreate primary, unique and foreign key constraints 
alter table MEDSURGERY.MED_OPER_SHIFT_RECORD
  add constraint PK_MED_OPER_SHIFT_RECORD primary key (PATIENT_ID, VISIT_ID, OPER_ID, SHIFT_NO)
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
-- Grant/Revoke object privileges 
grant select, insert, update, delete on MEDSURGERY.MED_OPER_SHIFT_RECORD to ROLE_DOCARE;

-- Create table
create table MED_QIXIE_QINGDIAN
(
  PATIENT_ID                   NVARCHAR2(20) not null,
  VISIT_ID                     NUMBER(2) not null,
  OPER_ID                      NUMBER(2) not null,
  X_POSITION         NUMBER(10) not null,
  Y_POSITION              NUMBER(10) not null,
  POSITION_VALUE        NVARCHAR2(50)
)
tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64
    minextents 1
    maxextents unlimited
  );
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_QIXIE_QINGDIAN
  add constraint MED_QIXIE_QINGDIAN primary key (PATIENT_ID, VISIT_ID, OPER_ID, X_POSITION,Y_POSITION)
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
-- Grant/Revoke object privileges 
grant select, insert, update, delete on MED_QIXIE_QINGDIAN to ROLE_DOCARE;

-- Create table
create table MED_GRID_TEMPLET_MASTER
(
  TEMPLET_GUID                   NVARCHAR2(50) not null,
  GRID_TEMPLET_FLAG             NVARCHAR2(50) not null,
  CREATE_BY          VARCHAR2(50) default '公用' not null,
  CLASS_NAME    NVARCHAR2(50) not null,
  TEMPLET_NAME  NVARCHAR2(50) not null,
  EVENT_NO  NUMBER(3) default 0 not null,
  MEMO  NVARCHAR2(100)
)
tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64
    minextents 1
    maxextents unlimited
  );
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_GRID_TEMPLET_MASTER
  add constraint MED_GRID_TEMPLET_MASTER primary key (TEMPLET_GUID)
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
-- Grant/Revoke object privileges 
grant select, insert, update, delete on MED_GRID_TEMPLET_MASTER to ROLE_DOCARE;


-- Create table
create table MED_GRID_TEMPLET_DETAIL
(
  TEMPLET_GUID       NVARCHAR2(50) not null,
  X_POSITION         NUMBER(10) not null,
  Y_POSITION              NUMBER(10) not null,
  POSITION_VALUE        NVARCHAR2(50),
  POSITION_FLAG        NVARCHAR2(50)
)
tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64
    minextents 1
    maxextents unlimited
  );
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_GRID_TEMPLET_DETAIL
  add constraint MED_GRID_TEMPLET_DETAIL primary key (TEMPLET_GUID, X_POSITION,Y_POSITION)
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
-- Grant/Revoke object privileges 
grant select, insert, update, delete on MED_GRID_TEMPLET_DETAIL to ROLE_DOCARE;

-- Create table
create table MED_QIXIE_TEMPLET_MASTER
(
  TEMPLET_GUID                   NVARCHAR2(50) not null,
  OPER_BAG_FLAG             NUMBER(2) default 1 not null,
  CLASS_NAME    NVARCHAR2(50) not null,
  TEMPLET_NAME  NVARCHAR2(50) not null,
  MEMO  NVARCHAR2(200)
)
tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64
    minextents 1
    maxextents unlimited
  );
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_QIXIE_TEMPLET_MASTER
  add constraint MED_QIXIE_TEMPLET_MASTER primary key (TEMPLET_GUID)
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
-- Grant/Revoke object privileges 
grant select, insert, update, delete on MED_QIXIE_TEMPLET_MASTER to ROLE_DOCARE;


-- Create table
create table MED_QIXIE_TEMPLET_DETAIL
(
	SERIAL_NO     NUMBER(4),
  TEMPLET_GUID       NVARCHAR2(50) not null,
  ITEM_NAME  NVARCHAR2(30) not null,
  ITEM_VALUE  NVARCHAR2(10)
)
tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64
    minextents 1
    maxextents unlimited
  );
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_QIXIE_TEMPLET_DETAIL
  add constraint MED_QIXIE_TEMPLET_DETAIL primary key (TEMPLET_GUID, ITEM_NAME)
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
-- Grant/Revoke object privileges 
grant select, insert, update, delete on MED_QIXIE_TEMPLET_DETAIL to ROLE_DOCARE;