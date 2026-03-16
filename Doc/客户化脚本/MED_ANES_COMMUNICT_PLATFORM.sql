-- Create table
create table MED_ANES_COMMUNICT_PLATFORM
(
  ID                  VARCHAR2(40) not null,
  MSG                 VARCHAR2(400),
  INSERT_TIME         DATE,
  STATE               NUMBER(2),
  USER_ID             VARCHAR2(50),
  DEPT_CODE           VARCHAR2(12),
  OPERATION_DEPT_CODE VARCHAR2(12),
  PATIENT_ID          VARCHAR2(20),
  VISIT_ID            NUMBER(2),
  OPER_ID             NUMBER(2)
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
alter table MED_ANES_COMMUNICT_PLATFORM
  add constraint PK_MED_ANES_COMMUNICT_PLATFORM primary key (ID)
  using index 
  tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 256K
    minextents 1
    maxextents unlimited
  );
-- Grant/Revoke object privileges 
grant select, insert, update, delete, references, alter, index on MED_ANES_COMMUNICT_PLATFORM to MEDCOMM with grant option;
grant select, insert, update, delete on MED_ANES_COMMUNICT_PLATFORM to ROLE_DOCARE;
