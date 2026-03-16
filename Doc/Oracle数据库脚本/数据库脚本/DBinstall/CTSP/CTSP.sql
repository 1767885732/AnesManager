rem=====================================================
rem     作    者：研发部
rem     整理时间：2008-07-11
rem     说    明：创建表空间
rem=====================================================

connect &SystemConn

rem===================================
rem 	create tablespace 9i or 10g
rem		MedComm
rem===================================
create tablespace tsp_MedComm
	logging
	datafile '&datafile\apMedComm.dbf'
	size 100M
	reuse
	autoextend on
	next 20M
	maxsize unlimited
	extent management local segment space management auto;

rem===================================
rem 	create tablespace 9i or 10g
rem		MedICU
rem===================================
create tablespace tsp_MedIcu
	logging
	datafile '&datafile\apMedIcu.dbf'
	size 200M
	reuse
	autoextend on
	next 20M
	maxsize unlimited
	extent management local segment space management auto;

rem===================================
rem 	create tablespace 9i or 10g
rem		MedICU
rem===================================
create tablespace tsp_Medsurgery
	logging
	datafile '&datafile\apMedsurgery.dbf'
	size 300M
	reuse
	autoextend on
	next 20M
	maxsize unlimited
	extent management local segment space management auto;



