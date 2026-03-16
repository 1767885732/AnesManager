-- Create table
create table MED_ANES_MONITOR_CONFIG
(
  PATIENT_ID NVARCHAR2(20) not null,
  VISIT_ID   NUMBER(2) not null,
  OPER_ID    NUMBER(2) not null,
  CONTENT    BLOB
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
alter table MED_ANES_MONITOR_CONFIG
  add constraint PK_MED_ANES_MONITOR_CONFIG primary key (PATIENT_ID, VISIT_ID, OPER_ID)
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
grant select on MED_ANES_MONITOR_CONFIG to MEDCOMM with grant option;
grant select, insert, update, delete on MED_ANES_MONITOR_CONFIG to ROLE_DOCARE;


