create view med_users_applications as
select distinct a.app_id ,b.user_id from med_roles a ,med_users_roles b
where a.role_id=b.role_id;

create view med_permission_view as
select A.PERMISSION_ID,A.APP_ID,A.NAME,A.PERMISSION_KEY,A.SORT_ID,A.IS_VALID,A.DESCRIPTION,isnull(B.PARENT_ID,0) PARENT_ID,B.CHILD_ID
    from med_permissions A left join med_permissions_anes B  ON A.PERMISSION_ID=B.PERMISSION_ID;
