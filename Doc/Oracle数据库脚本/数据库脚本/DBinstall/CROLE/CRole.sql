rem=====================================================
rem     作    者：研发部
rem     整理时间：2007-03-19
rem     说    明：基础设计(角色)
rem=====================================================

connect &SystemConn

rem===================================
rem 	create role
rem===================================

create role role_docare not identified;
grant connect,resource to role_docare;
grant create database link to role_docare;
grant create synonym to role_docare;
grant create view to role_docare;

