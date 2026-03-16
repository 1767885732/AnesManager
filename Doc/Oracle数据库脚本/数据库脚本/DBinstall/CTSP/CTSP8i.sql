rem=====================================================
rem     作    者：研发部
rem     整理时间：2008-07-11
rem     说    明：创建表空间
rem=====================================================

connect &SystemConn

rem===================================
rem 	create tablespace 8i
rem		MedComm
rem===================================
create tablespace tsp_MedComm
	datafile '&datafile\apMedComm.dbf'
	size 100M
	reuse
	autoextend on
	next 20M
	maxsize unlimited;

rem===================================
rem 	create tablespace 8i
rem		MedIcu
rem===================================
create tablespace tsp_MedIcu
	datafile '&datafile\apMedIcu.dbf'
	size 300M
	reuse
	autoextend on
	next 20M
	maxsize unlimited;

rem===================================
rem 	create tablespace 8i
rem		MedSurgery
rem===================================
create tablespace tsp_MedSurgery
	datafile '&datafile\apMedSurgery.dbf'
	size 300M
	reuse
	autoextend on
	next 20M
	maxsize unlimited;

