
 --增加麻醉方法简称字段 Add/modify columns 
 --需要用medcomm登录
alter table MEDCOMM.MED_ANAESTHESIA_DICT add ANAESTHESIA_SHORTEN varchar2(40);

-- Add/modify columns 
alter table MEDCOMM.MED_ANAESTHESIA_DICT add NEED_ANES_DOCTOR number(1) default 1;
-- Add comments to the columns 
comment on column MEDCOMM.MED_ANAESTHESIA_DICT.NEED_ANES_DOCTOR
  is '标明本麻醉方法是否需要麻醉医生默认为需要';




--用MedComm连接，给MedSurgery分配创建视图的权限
grant all on medcomm.MED_PAT_MASTER_INDEX to medsurgery;
grant all on medcomm.MED_HIS_USERS to medsurgery;
grant all on medcomm.Med_Anaesthesia_Dict to medsurgery;
grant all on medcomm.Med_Dept_Dict to medsurgery;
grant all on medcomm.MED_PATS_IN_HOSPITAL to medsurgery;