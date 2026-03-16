-- Create table
create table MEDSURGERY.MED_OPERATING_INSTRUMENTS_ADD
(
  PATIENT_ID         VARCHAR2(20) not null,
  VISIT_ID        NUMBER(2) not null,
  OPER_ID         NUMBER(2) not null,
  ADD_NO         NUMBER(3,0) not null,
  ITEM_NAME       VARCHAR2(50) not null,
  BAR_CODE        VARCHAR2(50),
  ITEM_CODE       VARCHAR2(50),
  QUANTITY     NUMBER(8),
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
alter table MEDSURGERY.MED_OPERATING_INSTRUMENTS_ADD
  add constraint PK_MED_OPER_INSTRUMENTS_ADD primary key (PATIENT_ID,VISIT_ID,OPER_ID,ADD_NO,ITEM_NAME)
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
comment on table MEDSURGERY.MED_OPERATING_INSTRUMENTS_ADD
is '患者手术器械术中添加表';
comment on column MEDSURGERY.MED_OPERATING_INSTRUMENTS_ADD.ADD_NO
is '术中添加序号';
comment on column MEDSURGERY.MED_OPERATING_INSTRUMENTS_ADD.ITEM_NAME
is '名称';
comment on column MEDSURGERY.MED_OPERATING_INSTRUMENTS_ADD.ITEM_CODE
is '代码';
comment on column MEDSURGERY.MED_OPERATING_INSTRUMENTS.BAR_CODE
is '所属器械包条形码';
comment on column MEDSURGERY.MED_OPERATING_INSTRUMENTS_ADD.QUANTITY
is '术中增加数量';
-- Grant/Revoke object privileges 
grant select, insert, update, delete on MEDSURGERY.MED_OPERATING_INSTRUMENTS_ADD to ROLE_DOCARE;
--同义词
Create public synonym MED_OPERATING_INSTRUMENTS_ADD for MEDSURGERY.MED_OPERATING_INSTRUMENTS_ADD;
