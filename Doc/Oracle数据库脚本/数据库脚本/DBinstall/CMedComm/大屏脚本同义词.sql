---------------------------------------------------------------
--用system登录PLSQL执行以下语句 conn system/docare
---------------------------------------------------------------
create or replace public  synonym view_operation_list for medsurgery.view_operation_list;
create or replace public  synonym med_screen_col_list for medcomm.med_screen_col_list;
create or replace public synonym MED_SCREEN_CONFIG for medcomm.MED_SCREEN_CONFIG;