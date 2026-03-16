--用MedComm连接，给MedSurgery分配创建视图的权限
grant all on medcomm.MED_PAT_MASTER_INDEX to medsurgery;
grant all on medcomm.MED_HIS_USERS to medsurgery;
grant all on medcomm.Med_Anaesthesia_Dict to medsurgery;
grant all on medcomm.Med_Dept_Dict to medsurgery;
grant all on medcomm.MED_PATS_IN_HOSPITAL to medsurgery;


