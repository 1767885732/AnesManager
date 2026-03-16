-- Create table
create table MEDSURGERY.MED_OPERATING_INSTRUMENTS
(
  PATIENT_ID         VARCHAR2(20) not null,
  VISIT_ID        NUMBER(2) not null,
  OPER_ID         NUMBER(2) not null,
  ITEM_NO         NUMBER(3,0) not null,
  ITEM_NAME       VARCHAR2(50) not null,
  ITEM_CODE       VARCHAR2(50),
  BAR_CODE        VARCHAR2(50),
  QUANTITY1     NUMBER(8),
  QUANTITY2     NUMBER(8),
  QUANTITY3     VARCHAR2(50),
  QUANTITY4     NUMBER(8),
  QUANTITY5     NUMBER(8),
  MEMO        VARCHAR2(100)  
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
alter table MEDSURGERY.MED_OPERATING_INSTRUMENTS
  add constraint PK_MED_OPERATING_INSTRUMENTS primary key (PATIENT_ID,VISIT_ID,OPER_ID,ITEM_NO,ITEM_NAME)
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
-- Add comments to the table 
comment on table MEDSURGERY.MED_OPERATING_INSTRUMENTS
is '患者手术器械表';
comment on column MEDSURGERY.MED_OPERATING_INSTRUMENTS.ITEM_NO
is '项目序号';
comment on column MEDSURGERY.MED_OPERATING_INSTRUMENTS.ITEM_NAME
is '名称';
comment on column MEDSURGERY.MED_OPERATING_INSTRUMENTS.ITEM_CODE
is '代码';
comment on column MEDSURGERY.MED_OPERATING_INSTRUMENTS.BAR_CODE
is '所属器械包条形码';
comment on column MEDSURGERY.MED_OPERATING_INSTRUMENTS.QUANTITY1
is '器械包原始数量';
comment on column MEDSURGERY.MED_OPERATING_INSTRUMENTS.QUANTITY2
is '术前清点数';
comment on column MEDSURGERY.MED_OPERATING_INSTRUMENTS.QUANTITY3
is '术中增加数';
comment on column MEDSURGERY.MED_OPERATING_INSTRUMENTS.QUANTITY4
is '关前核对数';
comment on column MEDSURGERY.MED_OPERATING_INSTRUMENTS.QUANTITY5
is '关后核对数';
-- Grant/Revoke object privileges 
grant select, insert, update, delete on MEDSURGERY.MED_OPERATING_INSTRUMENTS to ROLE_DOCARE;
--同义词
Create public synonym MED_OPERATING_INSTRUMENTS for MEDSURGERY.MED_OPERATING_INSTRUMENTS;
