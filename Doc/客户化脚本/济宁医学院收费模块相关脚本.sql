
alter table MEDSURGERY.MED_OPERATION_BILL_ITEMS add PRICE NUMBER(9,3) NULL;
alter table MEDSURGERY.MED_OPERATION_BILL_ITEMS add REL_BILL NUMBER(2,0) NULL;
alter table MEDSURGERY.MED_OPERATION_BILL_ITEMS add ITEM_CLASS_NAME VARCHAR2(200) NULL;
alter table MEDSURGERY.MED_OPERATION_BILL_ITEMS add CLASS_ON_INP_RCPT VARCHAR2(20) NULL;
alter table MEDSURGERY.MED_OPERATION_BILL_ITEMS add CLASS_ON_OUTP_RCPT VARCHAR2(20) NULL;
alter table MEDSURGERY.MED_OPERATION_BILL_ITEMS add CLASS_ON_RECKONING VARCHAR2(20) NULL;
alter table MEDSURGERY.MED_OPERATION_BILL_ITEMS add SUBJ_CODE VARCHAR2(20) NULL;
alter table MEDSURGERY.MED_OPERATION_BILL_ITEMS add CLASS_ON_MR VARCHAR2(20) NULL;
alter table MEDSURGERY.MED_OPERATION_BILL_ITEMS add OPERATOR VARCHAR2(100) NULL;

--价表视图
create or replace view medcomm.current_price_list as
select
	item_class,
	item_code,
	item_name,
	item_spec,
	units,
	price,
	prefer_price,
	foreigner_price,
	performed_by,
	fee_type_mask,
	class_on_inp_rcpt,
	class_on_outp_rcpt,
	class_on_reckoning,
	subj_code,
	class_on_mr,
	memo,
	operator,
	enter_date
	from med_price_list
	where sysdate>=start_date and (sysdate<stop_date or stop_date is null);
  
  -- Create the synonym 
create or replace public synonym CURRENT_PRICE_LIST
  for MEDCOMM.CURRENT_PRICE_LIST;

--给ROLE_DOCARE角色查询权限
grant select  on CURRENT_PRICE_LIST to ROLE_DOCARE;
  
