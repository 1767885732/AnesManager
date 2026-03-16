
 --增加麻醉方法简称字段 Add/modify columns 
 --需要用medcomm登录
alter table MEDCOMM.MED_ANAESTHESIA_DICT add ANAESTHESIA_SHORTEN varchar2(40);

-- Add/modify columns 
alter table MEDCOMM.MED_ANAESTHESIA_DICT add NEED_ANES_DOCTOR number(1) default 1;
-- Add comments to the columns 
comment on column MEDCOMM.MED_ANAESTHESIA_DICT.NEED_ANES_DOCTOR
  is '标明本麻醉方法是否需要麻醉医生默认为需要';
  

