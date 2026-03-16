rem=====================================================
rem     作    者：研发部
rem     整理时间：2008-07-11
rem     说    明：创建ICU部分
rem=====================================================


connect &MedIcuConn
start &sysPath\cMedIcu\cMedIcu.sql

rem===================================
rem 	create synonym
rem===================================

connect &SystemConn      
start &sysPath\cMedIcu\sMedIcu.sql


