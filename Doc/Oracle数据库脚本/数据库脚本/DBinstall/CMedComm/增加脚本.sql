---¾ÆÐ¡Áú20110302


create table MED_VS_HIS_DEP_ID
(
  MED_PATIENT_ID         varchar2(20),
  MED_VISIT_ID           number(2),
  MED_DEP_ID             number(2),
  HIS_ADM_WARD_DATE_TIME date,
  HIS_PATIENT_ID         varchar2(20),
  HIS_VISIT_ID           varchar2(20)
)
;

alter table MED_VS_HIS_DEP_ID
  add constraint PK_MED_VS_HIS_DEP_ID primary key (MED_PATIENT_ID, MED_VISIT_ID, MED_DEP_ID);

grant select, insert, update, delete on MED_VS_HIS_DEP_ID to ROLE_DOCARE;

-- Create table
create table MEDCOMM.MED_HIS_USERS_INFO
(
  USER_ID     VARCHAR2(36) not null,
  PROFESSIONAL_TITLE  VARCHAR2(20),
  SIGNATURE    BLOB,
  MEMO  VARCHAR2(100)
)
tablespace TSP_MEDCOMM
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
alter table MEDCOMM.MED_HIS_USERS_INFO
  add constraint PK_MED_HIS_USERS_INFO primary key (USER_ID)
  using index 
  tablespace TSP_MEDCOMM
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
grant select, insert, update, delete on MEDCOMM.MED_HIS_USERS_INFO to ROLE_DOCARE;

-- Create table
create table MED_USERS_HISUSERS
(
  USER_ID     VARCHAR2(36) not null,
  HIS_USER_ID VARCHAR2(36) not null,
  MEMO        VARCHAR2(100)
)
tablespace TSP_MEDCOMM
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
alter table MED_USERS_HISUSERS
  add constraint PK_USERS_HISUSERS primary key (USER_ID, HIS_USER_ID)
  using index 
  tablespace TSP_MEDCOMM
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
grant select, insert, update, delete, alter on MED_USERS_HISUSERS to ROLE_DOCARE;