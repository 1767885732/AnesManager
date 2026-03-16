-- Create table
create table MEDSURGERY.MED_PACU_NURSE_RECORD
(
  PATIENT_ID     NVARCHAR2(20) not null,
  VISIT_ID       NUMBER(2) not null,
  OPER_ID        NUMBER(2) not null,
  X_POSITION     NUMBER(10) not null,
  Y_POSITION     NUMBER(10) not null,
  POSITION_VALUE NVARCHAR2(50)
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
alter table MEDSURGERY.MED_PACU_NURSE_RECORD
  add constraint PK_MED_PACU_NURSE_RECORD primary key (PATIENT_ID, VISIT_ID, OPER_ID, X_POSITION, Y_POSITION)
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
grant select, insert, update, delete on MEDSURGERY.MED_PACU_NURSE_RECORD to ROLE_DOCARE;

create or replace public synonym MED_PACU_NURSE_RECORD
  for MEDSURGERY.MED_PACU_NURSE_RECORD;
