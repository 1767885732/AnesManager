rem=====================================================
rem     作    者：研发部
rem     整理时间：2008-07-11
rem     说    明：创建公共部分
rem=====================================================

connect &MedCommconn
start &sysPath\cMedcomm\cMedComm.sql
start &sysPath\cMedcomm\增加脚本.sql
start &sysPath\cMedcomm\排班InitSqlSrript.sql
start &sysPath\cMedcomm\大屏脚本MedComm.sql

rem===================================
rem 	create synonym
rem===================================

connect &SystemConn      
start &sysPath\cMedcomm\sMedComm.sql
start &sysPath\cMedcomm\增加脚本(同义词).sql
start &sysPath\cMedcomm\大屏脚本同义词.sql

