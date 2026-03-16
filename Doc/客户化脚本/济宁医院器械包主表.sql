-- Create table
create table MEDSURGERY.MED_PACKAGE_MASTER
(
  BAR_CODE           VARCHAR2(50) not null,
  PACKAGE_NAME       VARCHAR2(50),
  STERILIZE_DATE     DATE,
  TODAY_USE_TIMES    VARCHAR2(20),
  EXP_DATE           DATE,
  PACKAGE_OPERATOR   VARCHAR2(50),
  MEMO               VARCHAR2(100)
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
alter table MEDSURGERY.MED_PACKAGE_MASTER
  add constraint PK_MED_PACKAGE_MASTER primary key (BAR_CODE)
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
comment on table MEDSURGERY.MED_PACKAGE_MASTER
is '器械包主表';
comment on column MEDSURGERY.MED_PACKAGE_MASTER.BAR_CODE
is '器械包条形码';
comment on column MEDSURGERY.MED_PACKAGE_MASTER.PACKAGE_NAME
is '器械包名称';
comment on column MEDSURGERY.MED_PACKAGE_MASTER.STERILIZE_DATE
is '灭菌日期';
comment on column MEDSURGERY.MED_PACKAGE_MASTER.TODAY_USE_TIMES
is '锅次';
comment on column MEDSURGERY.MED_PACKAGE_MASTER.EXP_DATE
is '有效日期';
comment on column MEDSURGERY.MED_PACKAGE_MASTER.PACKAGE_OPERATOR
is '打包人';
comment on column MEDSURGERY.MED_PACKAGE_MASTER.MEMO
is '备注';
-- Grant/Revoke object privileges 
grant select, insert, update, delete on MEDSURGERY.MED_PACKAGE_MASTER to ROLE_DOCARE;
--同义词
Create public synonym MED_PACKAGE_MASTER for MEDSURGERY.MED_PACKAGE_MASTER;
