rem=====================================================
rem     作    者：研发部
rem     整理时间：2008-07-11
rem     说    明：创建用户
rem=====================================================

connect &SystemConn

rem===================================
rem 	create owner
rem===================================
create user MedComm
	identified by MedComm
	default tablespace tsp_MedComm
	temporary tablespace temp
	quota unlimited on tsp_MedComm;
grant connect,resource to MedComm;
grant role_docare to MedComm;

create user Medsurgery
	identified by Medsurgery
	default tablespace tsp_Medsurgery
	temporary tablespace temp
	quota unlimited on tsp_Medsurgery;
grant connect,resource to Medsurgery;
grant role_docare to Medsurgery;

create user MedIcu
	identified by MedIcu
	default tablespace tsp_MedIcu
	temporary tablespace temp
	quota unlimited on tsp_MedIcu;
grant connect,resource to MedIcu;
grant role_docare to MedIcu;