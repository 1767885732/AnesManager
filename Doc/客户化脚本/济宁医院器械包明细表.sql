-- Create table
create table MEDSURGERY.MED_PACKAGE_DETAIL
(
  BAR_CODE           VARCHAR2(50) not null,
  INSTRUMENT_NAME    VARCHAR2(50) not null,
  INSTRUMENT_CODE    VARCHAR2(50),
  QUANTITY           NUMBER(8)
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
alter table MEDSURGERY.MED_PACKAGE_DETAIL
  add constraint PK_MED_PACKAGE_DETAIL primary key (BAR_CODE,INSTRUMENT_NAME)
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
comment on table MEDSURGERY.MED_PACKAGE_DETAIL
is '器械包明细表';
comment on column MEDSURGERY.MED_PACKAGE_DETAIL.BAR_CODE
is '器械包条形码';
comment on column MEDSURGERY.MED_PACKAGE_DETAIL.INSTRUMENT_NAME
is '器械名称';
comment on column MEDSURGERY.MED_PACKAGE_DETAIL.INSTRUMENT_CODE
is '器械编码';
comment on column MEDSURGERY.MED_PACKAGE_DETAIL.QUANTITY
is '数量';
-- Grant/Revoke object privileges 
grant select, insert, update, delete on MEDSURGERY.MED_PACKAGE_DETAIL to ROLE_DOCARE;
--同义词
Create public synonym MED_PACKAGE_DETAIL for MEDSURGERY.MED_PACKAGE_DETAIL;
