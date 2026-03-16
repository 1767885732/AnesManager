rem=====================================================
rem     作    者：研发部
rem     创建时间：2008-01-25
rem	修改时间：2008-07-11
rem     说    明：系统脚本
rem	
rem		  DataFile	  数据文件存储路径	
rem     	  SystemConn      管理员用户连接字符
rem		  MedCommConn  	  公用部分连接字符
rem		  MedSurgeryConn  麻醉用户连接
rem		  MedIcuConn	  ICU用户连接
rem     注    意: 
rem		1、DataFile定义为数据文件存储路径
rem		2、@docare为网路服务名
rem		3、SysPath路径为目录路径，建议拷贝到C:盘
rem		   根目录下执行
rem		4、根据选择执行脚本(通过rem注释)
rem=====================================================

define databasename     = 'orcl'
define SysPath	  	= 'D:\Work\麻醉主版本\Anes\Doc\Oracle数据库脚本\数据库脚本\DBinstall'
define DataFile   	= 'F:\ORACLE\PRODUCT\10.2.0\ORADATA\&databasename'
define SystemConn 	= 'system/system@&databasename'
define MedCommConn  	= 'MedComm/MedComm@&databasename'
define MedSurgeryConn	= 'MedSurgery/MedSurgery@&databasename'
define MedIcuConn    	= 'MedIcu/MedIcu@&databasename'


connect &SystemConn

spool &sysPath\install.log

rem==================================
rem        创建公共角色
rem==================================

start &SysPath\CRole\CRole.sql

rem==================================
rem        创建TableSpace
rem==================================

start &SysPath\CTSP\CTSP.sql
rem start &SysPath\CTSP\CTSP8i.sql

rem==================================
rem        创建OWNER
rem==================================

start &SysPath\Cowner\Cowner.sql


rem==================================
rem      创建 麻醉 系统管理部分
rem==================================

start &SysPath\CMedSurgery\CMedSurgerySys.sql

rem==================================
rem      创建 ICU 系统管理部分
rem==================================

start &SysPath\CMedIcu\CMedIcuSys.sql

rem==================================
rem      创建MEDCOMM系统公共管理部分
rem==================================

start &SysPath\CMedComm\CMedCommSys.sql

rem==================================
rem      初始化数据
rem==================================

start &SysPath\CData\CDataSys.sql

exit;

spool off;