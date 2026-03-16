-- Create table
create table MEDSURGERY.MED_CHANGEROOM_DICT
(
  CUPBOARD_NO      VARCHAR2(50) not null,
  USER_SEX         VARCHAR2(10) not null,
  OPERATING_ROOM   VARCHAR2(50) not null,
  USER_ID          VARCHAR2(50),
  USE_DESC         VARCHAR2(200),
  RETURN_INDICATOR VARCHAR2(1) default '0',
  MEMO             VARCHAR2(200)
)
tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 16K
    minextents 1
    maxextents unlimited
  );
-- Create/Recreate primary, unique and foreign key constraints 
alter table MEDSURGERY.MED_CHANGEROOM_DICT
  add constraint PK_MED_CHANGEROOM_DICT primary key (CUPBOARD_NO, USER_SEX, OPERATING_ROOM)
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
grant select, insert, update, delete on MEDSURGERY.MED_CHANGEROOM_DICT to ROLE_DOCARE;

create or replace public synonym MED_CHANGEROOM_DICT
  for MEDSURGERY.MED_CHANGEROOM_DICT;
