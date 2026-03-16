-- Create table
create table MED_EQUIPMENT_MANAGEMENT
(
  INSTRUMENT_CODE     NVARCHAR2(30) not null,
  INSTRUMENT_NAME     NVARCHAR2(50),
  SUPPLIER_NAME       NVARCHAR2(60),
  MODEL_NUMBER        NVARCHAR2(60),
  SERIAL_NUMBER       NVARCHAR2(20),
  DATE_OF_MANUFACTURE DATE,
  DEPOSIT_ADDRESS     VARCHAR2(100),
  INSTRUMENT_NO       NUMBER(6),
  DEPT_TYPE           number(2),
  ATTRIBUTE           NVARCHAR2(8)
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
alter table MED_EQUIPMENT_MANAGEMENT
  add constraint PK_MED_EQUIPMENT_MANAGEMENT primary key (INSTRUMENT_CODE)
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


-- Create table
create table MED_EQUIPMENT_REPAIR
(
  INSTRUMENT_CODE  NVARCHAR2(30) not null,
  REPAIR_COUNT     NUMBER(5) default (0) not null,
  MAINTENANCE_TIME DATE default sysdate,
  SITUATION        NVARCHAR2(100)
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
alter table MED_EQUIPMENT_REPAIR
  add constraint PK_MED_EQUIPMENT_REPAIR primary key (INSTRUMENT_CODE, REPAIR_COUNT)
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


-- Create table
create table MED_EQUIPMENT_STATUS
(
  INSTRUMENT_CODE NVARCHAR2(30) not null,
  STATUS_COUNT    NUMBER(5) default (0) not null,
  STATUS_TIME     DATE,
  STATUS          NVARCHAR2(10)
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
alter table MED_EQUIPMENT_STATUS
  add constraint PK_MED_EQUIPMENT_STATUS primary key (INSTRUMENT_CODE, STATUS_COUNT)
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
-- Create table
create table MED_GOODS_MEDICINES_MANAGEMENT
(
  STOCK_IN_TIME DATE not null,
  ITEM_NAME     VARCHAR2(50) not null,
  ITEM_SPEC     VARCHAR2(20) not null,
  ITEM_DEPOSIT  VARCHAR2(100) not null,
  ITEM_UNIT     VARCHAR2(20),
  STOCK_IN_MEN  VARCHAR2(16),
  ITEM_COUNT    NUMBER(6),
  ITEM_MEMO     VARCHAR2(200),
  ITEM_TYPE     NUMBER(2),
  ISMATERIAL    VARCHAR2(10),
  ITEM_NO       VARCHAR2(40)
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
alter table MED_GOODS_MEDICINES_MANAGEMENT
  add constraint PK_MED_GOODS_MANAGEMENT primary key (STOCK_IN_TIME, ITEM_NAME, ITEM_SPEC, ITEM_DEPOSIT)
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
-- Create table
create table MED_STOCK_OUT_MANAGEMENT
(
  STOCK_IN_TIME  DATE not null,
  ITEM_NAME      VARCHAR2(50) not null,
  ITEM_SPEC      VARCHAR2(20) not null,
  ITEM_DEPOSIT   VARCHAR2(100) not null,
  STOCK_OUT_TIME DATE not null,
  ITEM_UNIT      VARCHAR2(20),
  STOCK_OUT_MEN  VARCHAR2(16),
  ITEM_COUNT     NUMBER(6),
  ITEM_MEMO      VARCHAR2(200),
  ITEM_TYPE      NUMBER(2)
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
alter table MED_STOCK_OUT_MANAGEMENT
  add constraint PK_MED_STOCK_OUT_MANAGEMENT primary key (STOCK_IN_TIME, ITEM_NAME, ITEM_SPEC, ITEM_DEPOSIT, STOCK_OUT_TIME)
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
-- Create table
create table MED_CONSUMABLE_STOREHOUSE
(
  PATIENT_ID     VARCHAR2(20) not null,
  VISIT_ID       NUMBER(2) not null,
  OPER_ID        NUMBER(2) not null,
  ITEM_NAME      VARCHAR2(50) not null,
  ITEM_SPEC      VARCHAR2(20) not null,
  ITEM_DEPOSIT   VARCHAR2(100) not null,
  ITEM_UNIT      VARCHAR2(20) not null,
  ITEM_OUT_COUNT NUMBER(6),
  STOCK_OUT_MEN  VARCHAR2(16),
  ITEM_TYPE      NUMBER(2),
  ISCHEDKED      VARCHAR2(10)
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
alter table MED_CONSUMABLE_STOREHOUSE
  add constraint PK_MED_CONSUMABLE_STOREHOUSE primary key (PATIENT_ID, VISIT_ID, OPER_ID, ITEM_NAME, ITEM_SPEC, ITEM_DEPOSIT, ITEM_UNIT)
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
