rem=====================================================
rem     作    者：研发部
rem     整理时间：2008-07-11
rem     说    明：创建麻醉部分
rem=====================================================

connect &MedSurgeryConn
start &sysPath\cMedSurgery\cMedSurgery.sql
start &sysPath\cMedSurgery\5.0专用.sql
start &sysPath\cMedSurgery\体外循环新建表脚本.sql
start &sysPath\cMedSurgery\增量脚本.sql
start &sysPath\cMedSurgery\排班InitSqlSrript.sql

start &sysPath\cMedSurgery\大屏脚本MedSurgery.sql

rem===================================
rem 	create synonym
rem===================================

connect &SystemConn      
start &sysPath\cMedSurgery\sMedSurgery.sql
start &sysPath\cMedSurgery\增量脚本(同义词).sql

rem=====================================================
rem     作    者：研发部
rem     整理时间：2009-08-21
rem     说    明：增加为重评分部分脚本，一般情况下可以不创建，如果需要为重评分功能，请打开创建即可
rem=====================================================

rem start &sysPath\cMedSurgery\危重评分结构.sql


