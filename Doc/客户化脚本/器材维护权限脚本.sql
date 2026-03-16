
insert into MED_PERMISSIONS (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-99984', 'ANESPERSONAL', '麻醉-麻醉器材-维护', 'AnesEquipmentManagement_mod', null, 'T', '护理模块');

insert into MED_PERMISSIONS_ANES (PERMISSION_ID, TYPE, MODULE, PIC, WD_NAME, WD_DESC, WD_MENUNAME, MENU_KEY, PARENT_ID, CHILD_ID)
values ('ANESPERSONAL-AutoAdd-9984', null, null, null, null, null, null, null, '护理模块', null);

insert into MED_PERMISSIONS (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-9985', 'ANESPERSONAL', '麻醉-手术器材-维护', 'OperEquipmentManagement_mod', null, 'T', '护理模块');

insert into MED_PERMISSIONS_ANES (PERMISSION_ID, TYPE, MODULE, PIC, WD_NAME, WD_DESC, WD_MENUNAME, MENU_KEY, PARENT_ID, CHILD_ID)
values ('ANESPERSONAL-AutoAdd-9985', null, null, null, null, null, null, null, '护理模块', null);
  
