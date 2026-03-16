
insert into med_applications (APP_ID, med_applications.NAME, med_applications.DESCRIPTION)
values ('ANESPERSONAL', '麻醉临床信息系统 V5.0', '麻醉5.0');
commit;

insert into Med_Roles (ROLE_ID, APP_ID, NAME, DESCRIPTION, CREATE_DATE)
values ('21ef04af-f78d-4638-92f1-eebb3efd7646', 'ANESPERSONAL', '排班麻醉医生', '使用排班系统的麻醉医生。', to_date('30-03-2011 12:48:15', 'dd-mm-yyyy hh24:mi:ss'));

insert into Med_Roles (ROLE_ID, APP_ID, NAME, DESCRIPTION, CREATE_DATE)
values ('a0280b7b-a551-4137-8cd0-4233e3c26160', 'ANESPERSONAL', '手术排班护士长', '使用排班系统的护士长', to_date('30-03-2011 12:48:56', 'dd-mm-yyyy hh24:mi:ss'));

insert into Med_Roles (ROLE_ID, APP_ID, NAME, DESCRIPTION, CREATE_DATE)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL', '管理员', '拥有最高权限', to_date('30-03-2011 12:49:22', 'dd-mm-yyyy hh24:mi:ss'));

insert into Med_Roles (ROLE_ID, APP_ID, NAME, DESCRIPTION, CREATE_DATE)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL', '麻醉医生', '使用麻醉系统的麻醉医生', to_date('01-04-2011 10:41:43', 'dd-mm-yyyy hh24:mi:ss'));

insert into Med_Roles (ROLE_ID, APP_ID, NAME, DESCRIPTION, CREATE_DATE)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL', '主任', '拥有管理员权限', to_date('01-04-2011 10:42:12', 'dd-mm-yyyy hh24:mi:ss'));

insert into Med_Roles (ROLE_ID, APP_ID, NAME, DESCRIPTION, CREATE_DATE)
values ('295f7ae2-3874-49f1-8097-ebe7d1b6dc72', 'ANESPERSONAL', '护士', '拥有护士权限', to_date('01-04-2011 10:42:35', 'dd-mm-yyyy hh24:mi:ss'));

insert into Med_Roles (ROLE_ID, APP_ID, NAME, DESCRIPTION, CREATE_DATE)
values ('c92a97ea-fd7d-417d-b432-1451ecf28a72', 'ANESPERSONAL', '统计', '拥有查询统计功能权限', to_date('01-04-2011 10:43:01', 'dd-mm-yyyy hh24:mi:ss'));


commit;

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('397301d4-4148-48c1-8802-4c43b55eb0eb', 'ANESPERSONAL-AutoAdd-10');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('397301d4-4148-48c1-8802-4c43b55eb0eb', 'ANESPERSONAL-AutoAdd-13');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('397301d4-4148-48c1-8802-4c43b55eb0eb', 'ANESPERSONAL-AutoAdd-14');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('397301d4-4148-48c1-8802-4c43b55eb0eb', 'ANESPERSONAL-AutoAdd-15');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('397301d4-4148-48c1-8802-4c43b55eb0eb', 'ANESPERSONAL-AutoAdd-16');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('397301d4-4148-48c1-8802-4c43b55eb0eb', 'ANESPERSONAL-AutoAdd-3');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('397301d4-4148-48c1-8802-4c43b55eb0eb', 'ANESPERSONAL-AutoAdd-7');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('3c798424-f4d5-4506-9c03-6829c6adaadf', 'ANESPERSONAL-AutoAdd-1');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('3c798424-f4d5-4506-9c03-6829c6adaadf', 'ANESPERSONAL-AutoAdd-10');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('3c798424-f4d5-4506-9c03-6829c6adaadf', 'ANESPERSONAL-AutoAdd-11');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('3c798424-f4d5-4506-9c03-6829c6adaadf', 'ANESPERSONAL-AutoAdd-12');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('3c798424-f4d5-4506-9c03-6829c6adaadf', 'ANESPERSONAL-AutoAdd-13');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('3c798424-f4d5-4506-9c03-6829c6adaadf', 'ANESPERSONAL-AutoAdd-14');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('3c798424-f4d5-4506-9c03-6829c6adaadf', 'ANESPERSONAL-AutoAdd-15');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('3c798424-f4d5-4506-9c03-6829c6adaadf', 'ANESPERSONAL-AutoAdd-16');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('3c798424-f4d5-4506-9c03-6829c6adaadf', 'ANESPERSONAL-AutoAdd-17');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('3c798424-f4d5-4506-9c03-6829c6adaadf', 'ANESPERSONAL-AutoAdd-18');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('3c798424-f4d5-4506-9c03-6829c6adaadf', 'ANESPERSONAL-AutoAdd-2');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('3c798424-f4d5-4506-9c03-6829c6adaadf', 'ANESPERSONAL-AutoAdd-20');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('3c798424-f4d5-4506-9c03-6829c6adaadf', 'ANESPERSONAL-AutoAdd-21');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('3c798424-f4d5-4506-9c03-6829c6adaadf', 'ANESPERSONAL-AutoAdd-22');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('3c798424-f4d5-4506-9c03-6829c6adaadf', 'ANESPERSONAL-AutoAdd-23');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('3c798424-f4d5-4506-9c03-6829c6adaadf', 'ANESPERSONAL-AutoAdd-24');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('3c798424-f4d5-4506-9c03-6829c6adaadf', 'ANESPERSONAL-AutoAdd-25');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('3c798424-f4d5-4506-9c03-6829c6adaadf', 'ANESPERSONAL-AutoAdd-26');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('3c798424-f4d5-4506-9c03-6829c6adaadf', 'ANESPERSONAL-AutoAdd-27');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('3c798424-f4d5-4506-9c03-6829c6adaadf', 'ANESPERSONAL-AutoAdd-28');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('3c798424-f4d5-4506-9c03-6829c6adaadf', 'ANESPERSONAL-AutoAdd-29');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('3c798424-f4d5-4506-9c03-6829c6adaadf', 'ANESPERSONAL-AutoAdd-3');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('3c798424-f4d5-4506-9c03-6829c6adaadf', 'ANESPERSONAL-AutoAdd-30');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('3c798424-f4d5-4506-9c03-6829c6adaadf', 'ANESPERSONAL-AutoAdd-32');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('3c798424-f4d5-4506-9c03-6829c6adaadf', 'ANESPERSONAL-AutoAdd-33');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('3c798424-f4d5-4506-9c03-6829c6adaadf', 'ANESPERSONAL-AutoAdd-34');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('3c798424-f4d5-4506-9c03-6829c6adaadf', 'ANESPERSONAL-AutoAdd-4');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('3c798424-f4d5-4506-9c03-6829c6adaadf', 'ANESPERSONAL-AutoAdd-5');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('3c798424-f4d5-4506-9c03-6829c6adaadf', 'ANESPERSONAL-AutoAdd-6');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('3c798424-f4d5-4506-9c03-6829c6adaadf', 'ANESPERSONAL-AutoAdd-7');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('3c798424-f4d5-4506-9c03-6829c6adaadf', 'ANESPERSONAL-AutoAdd-8');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('3c798424-f4d5-4506-9c03-6829c6adaadf', 'ANESPERSONAL-AutoAdd-9');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('898346e2-3ed5-457e-ae5b-827cddb0650d', 'ANESPERSONAL-AutoAdd-1');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('898346e2-3ed5-457e-ae5b-827cddb0650d', 'ANESPERSONAL-AutoAdd-1011');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('898346e2-3ed5-457e-ae5b-827cddb0650d', 'ANESPERSONAL-AutoAdd-1012');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('898346e2-3ed5-457e-ae5b-827cddb0650d', 'ANESPERSONAL-AutoAdd-1061');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('898346e2-3ed5-457e-ae5b-827cddb0650d', 'ANESPERSONAL-AutoAdd-11');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('898346e2-3ed5-457e-ae5b-827cddb0650d', 'ANESPERSONAL-AutoAdd-16');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('898346e2-3ed5-457e-ae5b-827cddb0650d', 'ANESPERSONAL-AutoAdd-20');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('898346e2-3ed5-457e-ae5b-827cddb0650d', 'ANESPERSONAL-AutoAdd-5');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('898346e2-3ed5-457e-ae5b-827cddb0650d', 'ANESPERSONAL-AutoAdd-9');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-10');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1001');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1002');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1003');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1004');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1005');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1006');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1007');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1008');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1009');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1010');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1011');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1012');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1013');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1014');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1015');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1016');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1017');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1018');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1019');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1020');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1021');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1022');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1023');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1024');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('21ef04af-f78d-4638-92f1-eebb3efd7646', '5002');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('21ef04af-f78d-4638-92f1-eebb3efd7646', '5003');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('21ef04af-f78d-4638-92f1-eebb3efd7646', '5004');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('a0280b7b-a551-4137-8cd0-4233e3c26160', '5001');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('a0280b7b-a551-4137-8cd0-4233e3c26160', '5005');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('a0280b7b-a551-4137-8cd0-4233e3c26160', '5006');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('a0280b7b-a551-4137-8cd0-4233e3c26160', '5007');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('a0280b7b-a551-4137-8cd0-4233e3c26160', '5008');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('a0280b7b-a551-4137-8cd0-4233e3c26160', '5009');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('a0280b7b-a551-4137-8cd0-4233e3c26160', '5010');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('a0280b7b-a551-4137-8cd0-4233e3c26160', '5011');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', '5001');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', '5002');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', '5003');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', '5004');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', '5005');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', '5006');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', '5007');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', '5008');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', '5009');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', '5010');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', '5011');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-32');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-33');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-34');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-35');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-4');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-5');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-6');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-7');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-8');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-9');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-10');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1001');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1002');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1003');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1004');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1005');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1006');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1007');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1008');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1009');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1010');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1011');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1012');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1013');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1014');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1017');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1018');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1019');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1020');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1021');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1022');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1023');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1024');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1025');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1026');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1027');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1028');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1029');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1030');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1031');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1032');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1033');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1034');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1035');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1036');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1037');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1038');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1039');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1040');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1041');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1042');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1043');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1044');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1045');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1046');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1047');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1048');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1049');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1050');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1051');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1052');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1053');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1054');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1055');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1056');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1057');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1058');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1059');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1060');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1061');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1062');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1063');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1064');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1065');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1066');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1067');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1068');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1069');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1070');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1071');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1072');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1073');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-31');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1074');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1075');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1076');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1077');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1078');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1079');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1080');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1081');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1082');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1083');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1084');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1085');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1086');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1087');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1088');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1089');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1090');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1091');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1092');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1093');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1094');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1095');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1096');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1097');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1098');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1099');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-11');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1100');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1101');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1102');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1103');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1104');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1105');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1106');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1107');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1108');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1109');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1110');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1111');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1112');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1113');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1114');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1115');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1116');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1117');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1118');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1119');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1120');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1121');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1122');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1123');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1124');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1125');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-1126');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-12');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-13');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-14');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-15');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-16');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-17');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-18');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-19');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-2');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-20');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-21');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-22');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-23');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-24');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-25');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-26');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-27');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-28');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-29');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-30');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-16');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-17');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('c92a97ea-fd7d-417d-b432-1451ecf28a72', 'ANESPERSONAL-AutoAdd-1068');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('c92a97ea-fd7d-417d-b432-1451ecf28a72', 'ANESPERSONAL-AutoAdd-1069');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('c92a97ea-fd7d-417d-b432-1451ecf28a72', 'ANESPERSONAL-AutoAdd-1070');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('c92a97ea-fd7d-417d-b432-1451ecf28a72', 'ANESPERSONAL-AutoAdd-1071');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('c92a97ea-fd7d-417d-b432-1451ecf28a72', 'ANESPERSONAL-AutoAdd-1072');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('c92a97ea-fd7d-417d-b432-1451ecf28a72', 'ANESPERSONAL-AutoAdd-1073');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('c92a97ea-fd7d-417d-b432-1451ecf28a72', 'ANESPERSONAL-AutoAdd-1074');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('c92a97ea-fd7d-417d-b432-1451ecf28a72', 'ANESPERSONAL-AutoAdd-1076');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('c92a97ea-fd7d-417d-b432-1451ecf28a72', 'ANESPERSONAL-AutoAdd-1078');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('c92a97ea-fd7d-417d-b432-1451ecf28a72', 'ANESPERSONAL-AutoAdd-1079');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('c92a97ea-fd7d-417d-b432-1451ecf28a72', 'ANESPERSONAL-AutoAdd-1080');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('c92a97ea-fd7d-417d-b432-1451ecf28a72', 'ANESPERSONAL-AutoAdd-1081');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('c92a97ea-fd7d-417d-b432-1451ecf28a72', 'ANESPERSONAL-AutoAdd-1082');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('c92a97ea-fd7d-417d-b432-1451ecf28a72', 'ANESPERSONAL-AutoAdd-1083');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('c92a97ea-fd7d-417d-b432-1451ecf28a72', 'ANESPERSONAL-AutoAdd-1084');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('c92a97ea-fd7d-417d-b432-1451ecf28a72', 'ANESPERSONAL-AutoAdd-1085');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('c92a97ea-fd7d-417d-b432-1451ecf28a72', 'ANESPERSONAL-AutoAdd-1086');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('c92a97ea-fd7d-417d-b432-1451ecf28a72', 'ANESPERSONAL-AutoAdd-1087');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('c92a97ea-fd7d-417d-b432-1451ecf28a72', 'ANESPERSONAL-AutoAdd-1088');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('c92a97ea-fd7d-417d-b432-1451ecf28a72', 'ANESPERSONAL-AutoAdd-1089');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('c92a97ea-fd7d-417d-b432-1451ecf28a72', 'ANESPERSONAL-AutoAdd-1090');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1025');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1026');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1027');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1028');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1029');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1030');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1031');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1032');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1033');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1034');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1035');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1036');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1037');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1038');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1039');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1040');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1041');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1042');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1043');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1044');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1045');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1046');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1047');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1048');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1049');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1050');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1051');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1052');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1053');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1054');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1055');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1056');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1057');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1058');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1059');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1060');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1061');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1062');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1063');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1064');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1065');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1066');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1067');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1068');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1069');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1070');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1071');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1072');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1073');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1074');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1075');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1076');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1077');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1078');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1079');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1080');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1081');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1082');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1083');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1084');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1085');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1086');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1087');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1088');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1089');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1090');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1091');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1092');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1093');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1094');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1095');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1096');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1097');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1098');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1099');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1100');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1101');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1102');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1103');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1104');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1105');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1106');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1107');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1108');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1109');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1110');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1111');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1112');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1113');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1114');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1115');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1116');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1117');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1118');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1119');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1120');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1121');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1122');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1123');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1124');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1125');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-1126');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-19');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('973b1c05-fa57-44c6-a5d1-ab2ab3243e09', 'ANESPERSONAL-AutoAdd-24');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('9e115396-8e6b-43a6-8a32-e2784cea1eca', 'ANESPERSONAL-AutoAdd-35');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b13aff69-58c3-4275-bed7-a81a26d050c4', 'ANESPERSONAL-AutoAdd-1');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b13aff69-58c3-4275-bed7-a81a26d050c4', 'ANESPERSONAL-AutoAdd-10');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b13aff69-58c3-4275-bed7-a81a26d050c4', 'ANESPERSONAL-AutoAdd-11');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b13aff69-58c3-4275-bed7-a81a26d050c4', 'ANESPERSONAL-AutoAdd-12');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b13aff69-58c3-4275-bed7-a81a26d050c4', 'ANESPERSONAL-AutoAdd-13');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b13aff69-58c3-4275-bed7-a81a26d050c4', 'ANESPERSONAL-AutoAdd-14');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b13aff69-58c3-4275-bed7-a81a26d050c4', 'ANESPERSONAL-AutoAdd-15');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b13aff69-58c3-4275-bed7-a81a26d050c4', 'ANESPERSONAL-AutoAdd-16');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b13aff69-58c3-4275-bed7-a81a26d050c4', 'ANESPERSONAL-AutoAdd-17');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b13aff69-58c3-4275-bed7-a81a26d050c4', 'ANESPERSONAL-AutoAdd-18');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b13aff69-58c3-4275-bed7-a81a26d050c4', 'ANESPERSONAL-AutoAdd-19');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b13aff69-58c3-4275-bed7-a81a26d050c4', 'ANESPERSONAL-AutoAdd-2');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b13aff69-58c3-4275-bed7-a81a26d050c4', 'ANESPERSONAL-AutoAdd-20');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b13aff69-58c3-4275-bed7-a81a26d050c4', 'ANESPERSONAL-AutoAdd-21');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b13aff69-58c3-4275-bed7-a81a26d050c4', 'ANESPERSONAL-AutoAdd-22');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b13aff69-58c3-4275-bed7-a81a26d050c4', 'ANESPERSONAL-AutoAdd-23');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b13aff69-58c3-4275-bed7-a81a26d050c4', 'ANESPERSONAL-AutoAdd-24');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b13aff69-58c3-4275-bed7-a81a26d050c4', 'ANESPERSONAL-AutoAdd-25');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b13aff69-58c3-4275-bed7-a81a26d050c4', 'ANESPERSONAL-AutoAdd-26');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b13aff69-58c3-4275-bed7-a81a26d050c4', 'ANESPERSONAL-AutoAdd-27');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b13aff69-58c3-4275-bed7-a81a26d050c4', 'ANESPERSONAL-AutoAdd-28');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b13aff69-58c3-4275-bed7-a81a26d050c4', 'ANESPERSONAL-AutoAdd-29');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b13aff69-58c3-4275-bed7-a81a26d050c4', 'ANESPERSONAL-AutoAdd-3');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b13aff69-58c3-4275-bed7-a81a26d050c4', 'ANESPERSONAL-AutoAdd-30');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b13aff69-58c3-4275-bed7-a81a26d050c4', 'ANESPERSONAL-AutoAdd-32');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b13aff69-58c3-4275-bed7-a81a26d050c4', 'ANESPERSONAL-AutoAdd-33');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b13aff69-58c3-4275-bed7-a81a26d050c4', 'ANESPERSONAL-AutoAdd-34');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b13aff69-58c3-4275-bed7-a81a26d050c4', 'ANESPERSONAL-AutoAdd-4');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b13aff69-58c3-4275-bed7-a81a26d050c4', 'ANESPERSONAL-AutoAdd-5');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b13aff69-58c3-4275-bed7-a81a26d050c4', 'ANESPERSONAL-AutoAdd-9');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('cd413324-741b-42df-86dc-f97bddb1534a', 'ANESPERSONAL-AutoAdd-1');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('cd413324-741b-42df-86dc-f97bddb1534a', 'ANESPERSONAL-AutoAdd-10');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('cd413324-741b-42df-86dc-f97bddb1534a', 'ANESPERSONAL-AutoAdd-11');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('cd413324-741b-42df-86dc-f97bddb1534a', 'ANESPERSONAL-AutoAdd-12');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('cd413324-741b-42df-86dc-f97bddb1534a', 'ANESPERSONAL-AutoAdd-13');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('cd413324-741b-42df-86dc-f97bddb1534a', 'ANESPERSONAL-AutoAdd-14');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('cd413324-741b-42df-86dc-f97bddb1534a', 'ANESPERSONAL-AutoAdd-15');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('cd413324-741b-42df-86dc-f97bddb1534a', 'ANESPERSONAL-AutoAdd-16');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('cd413324-741b-42df-86dc-f97bddb1534a', 'ANESPERSONAL-AutoAdd-17');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('cd413324-741b-42df-86dc-f97bddb1534a', 'ANESPERSONAL-AutoAdd-18');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('cd413324-741b-42df-86dc-f97bddb1534a', 'ANESPERSONAL-AutoAdd-19');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('cd413324-741b-42df-86dc-f97bddb1534a', 'ANESPERSONAL-AutoAdd-2');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('cd413324-741b-42df-86dc-f97bddb1534a', 'ANESPERSONAL-AutoAdd-20');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('cd413324-741b-42df-86dc-f97bddb1534a', 'ANESPERSONAL-AutoAdd-21');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('cd413324-741b-42df-86dc-f97bddb1534a', 'ANESPERSONAL-AutoAdd-22');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('cd413324-741b-42df-86dc-f97bddb1534a', 'ANESPERSONAL-AutoAdd-23');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('cd413324-741b-42df-86dc-f97bddb1534a', 'ANESPERSONAL-AutoAdd-24');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('cd413324-741b-42df-86dc-f97bddb1534a', 'ANESPERSONAL-AutoAdd-25');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('cd413324-741b-42df-86dc-f97bddb1534a', 'ANESPERSONAL-AutoAdd-26');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('cd413324-741b-42df-86dc-f97bddb1534a', 'ANESPERSONAL-AutoAdd-27');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('cd413324-741b-42df-86dc-f97bddb1534a', 'ANESPERSONAL-AutoAdd-28');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('cd413324-741b-42df-86dc-f97bddb1534a', 'ANESPERSONAL-AutoAdd-29');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('cd413324-741b-42df-86dc-f97bddb1534a', 'ANESPERSONAL-AutoAdd-3');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('cd413324-741b-42df-86dc-f97bddb1534a', 'ANESPERSONAL-AutoAdd-4');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('cd413324-741b-42df-86dc-f97bddb1534a', 'ANESPERSONAL-AutoAdd-5');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('cd413324-741b-42df-86dc-f97bddb1534a', 'ANESPERSONAL-AutoAdd-6');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('cd413324-741b-42df-86dc-f97bddb1534a', 'ANESPERSONAL-AutoAdd-7');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('cd413324-741b-42df-86dc-f97bddb1534a', 'ANESPERSONAL-AutoAdd-8');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('cd413324-741b-42df-86dc-f97bddb1534a', 'ANESPERSONAL-AutoAdd-9');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('e4682b5a-a062-4e66-abb2-f133b6b3bbbb', 'ANESPERSONAL-AutoAdd-1');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('e4682b5a-a062-4e66-abb2-f133b6b3bbbb', 'ANESPERSONAL-AutoAdd-1061');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b319dac7-2c5c-496a-bc36-7f3e1cc066b8', '5001');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b319dac7-2c5c-496a-bc36-7f3e1cc066b8', '5002');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b319dac7-2c5c-496a-bc36-7f3e1cc066b8', '5003');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b319dac7-2c5c-496a-bc36-7f3e1cc066b8', '5004');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b319dac7-2c5c-496a-bc36-7f3e1cc066b8', '5005');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b319dac7-2c5c-496a-bc36-7f3e1cc066b8', '5006');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b319dac7-2c5c-496a-bc36-7f3e1cc066b8', '5007');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b319dac7-2c5c-496a-bc36-7f3e1cc066b8', '5008');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b319dac7-2c5c-496a-bc36-7f3e1cc066b8', '5009');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b319dac7-2c5c-496a-bc36-7f3e1cc066b8', '5010');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b319dac7-2c5c-496a-bc36-7f3e1cc066b8', '5011');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('8c67fc15-6695-468b-a1de-9144139bc8fa', '5001');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('8c67fc15-6695-468b-a1de-9144139bc8fa', '5005');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('8c67fc15-6695-468b-a1de-9144139bc8fa', '5006');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('8c67fc15-6695-468b-a1de-9144139bc8fa', '5007');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('8c67fc15-6695-468b-a1de-9144139bc8fa', '5008');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('8c67fc15-6695-468b-a1de-9144139bc8fa', '5009');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('8c67fc15-6695-468b-a1de-9144139bc8fa', '5010');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('8c67fc15-6695-468b-a1de-9144139bc8fa', '5011');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-32');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-33');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-34');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-4');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-5');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-10');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1003');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1004');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1006');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1017');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1018');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1019');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1020');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1021');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1022');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1023');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1024');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1025');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1026');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1027');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1028');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1029');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1030');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1031');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1032');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-32');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-33');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-34');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-35');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-4');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-5');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-6');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-7');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-8');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-9');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-10');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1001');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1002');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1003');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1004');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1005');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1006');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1007');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1008');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1009');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1010');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1011');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1012');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1013');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1014');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1017');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1018');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1019');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1020');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1021');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1022');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1023');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1024');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1025');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1026');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1027');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1028');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1029');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1030');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1031');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1032');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1033');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1034');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1035');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1036');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1037');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1038');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1039');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1040');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1041');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1042');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1043');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1044');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1045');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1046');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1047');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1048');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1049');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1050');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1051');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1052');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1053');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1054');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1055');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1056');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1057');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1058');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1059');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1060');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1061');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1062');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1063');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1064');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1065');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1066');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1067');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1068');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1069');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1070');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1071');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1072');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1073');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-31');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1074');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1075');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1076');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1077');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1078');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1079');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1080');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1081');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1082');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1083');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1084');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1085');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1086');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1087');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1088');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1089');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1090');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1091');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1092');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1093');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1094');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1095');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1096');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1097');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1098');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1099');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-11');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1100');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1101');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1102');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1103');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1104');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1105');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1106');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1107');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1108');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1109');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1110');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1111');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1112');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1113');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1114');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1115');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1116');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1117');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1118');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1119');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1120');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1121');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1122');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1123');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1124');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1125');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-1126');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-12');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-13');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-14');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-15');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-16');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-17');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-18');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-19');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-2');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-20');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-21');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-22');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-23');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-24');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-25');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-26');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-27');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-28');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-29');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-3');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-AutoAdd-30');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', '5001');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', '5002');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', '5003');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', '5004');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', '5005');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', '5006');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', '5007');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', '5008');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', '5009');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', '5010');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1033');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1034');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1037');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1038');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1039');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1040');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1041');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1042');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1043');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1044');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1045');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1046');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1047');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1048');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1049');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1050');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1051');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1052');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1053');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1054');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1061');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1062');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-31');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1091');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1092');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1093');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1094');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-11');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1103');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1104');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1108');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1111');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1112');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1113');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1114');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1115');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1116');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1117');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1118');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1119');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1120');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1121');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1122');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-12');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-13');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-14');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-15');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-19');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-21');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-22');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-24');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-25');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-26');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-27');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-28');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-29');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-3');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-30');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-3');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-4');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-5');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1011');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1012');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-3');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-4');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-5');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-6');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-7');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-8');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-9');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-10');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-11');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-12');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-13');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('b08581ac-7e01-45e4-bdca-e1db2ca796bc', 'ANESPERSONAL-AutoAdd-3');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-6');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-7');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-3');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-4');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-5');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-6');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-7');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-8');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-9');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-10');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-11');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-12');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('67430c46-48b7-416e-b730-c7f3f5fff70f', 'ANESPERSONAL-13');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-8');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-9');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-10');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-12');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-13');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1059');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-AutoAdd-1060');

insert into Med_Roles_Permissions (ROLE_ID, PERMISSION_ID)
values ('f1a23f15-1286-4e68-9275-c000f0d78f0f', 'ANESPERSONAL-11');
commit;

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-32', 'ANESPERSONAL', '麻醉-术前知情同意书', '术前知情同意书', 932, 't', '术前知情同意书');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-33', 'ANESPERSONAL', '麻醉-全麻知情同意书', '全麻知情同意书', 933, 't', '全麻知情同意书');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-34', 'ANESPERSONAL', '麻醉-阻滞知情同意书', '阻滞知情同意书', 934, 't', '阻滞知情同意书');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-35', 'ANESPERSONAL', '麻醉-永久可修改医疗文书', '永久可修改医疗文书', 935, 't', '永久可修改医疗文书');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-4', 'ANESPERSONAL', '麻醉-手术状态转换操作', '手术状态转换操作', 904, 't', '手术状态转换操作');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-5', 'ANESPERSONAL', '麻醉-统计功能使用', '统计功能使用', 905, 't', '统计功能使用');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-8', 'ANESPERSONAL', '麻醉-系统配置', '系统配置', 908, 't', '系统配置');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-9', 'ANESPERSONAL', '麻醉-器械清点维护', '器械清点维护', 909, 't', '器械清点维护');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1', 'ANESPERSONAL', '麻醉-术中登记', '术中登记', 901, 't', '术中登记');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-10', 'ANESPERSONAL', '麻醉-复苏登记', '复苏登记', 910, 't', '复苏登记');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1001', 'ANESPERSONAL', '麻醉-患者登记维护', 'PatientRegistration_mod', 1001, 't', '患者登记维护');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1002', 'ANESPERSONAL', '麻醉-患者登记浏览', 'PatientRegistration_bro', 1002, 't', '患者登记浏览');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1003', 'ANESPERSONAL', '麻醉-手术申请维护', 'PatientRegistration_mod', 1003, 't', '手术申请维护');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1004', 'ANESPERSONAL', '麻醉-手术申请浏览', 'PatientRegistration_bro', 1004, 't', '手术申请浏览');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1005', 'ANESPERSONAL', '麻醉-手术审批维护', 'ApprovalProcedure_mod', 1005, 't', '手术审批维护');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1006', 'ANESPERSONAL', '麻醉-手术审批浏览', 'ApprovalProcedure_bro', 1006, 't', '手术审批浏览');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1007', 'ANESPERSONAL', '麻醉-手术批量安排维护', 'BatchOperationArrangements_mod', 1007, 't', '手术批量安排维护');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1008', 'ANESPERSONAL', '麻醉-手术批量安排浏览', 'BatchOperationArrangements_bro', 1008, 't', '手术批量安排浏览');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1009', 'ANESPERSONAL', '麻醉-麻醉批量安排维护', 'AnesthesiaBulkArrangement_mod', 1009, 't', '麻醉批量安排维护');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1010', 'ANESPERSONAL', '麻醉-麻醉批量安排浏览', 'AnesthesiaBulkArrangement_bro', 1010, 't', '麻醉批量安排浏览');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1011', 'ANESPERSONAL', '麻醉-急诊管理维护', 'EmergencyManagement_mod', 1011, 't', '急诊管理维护');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1012', 'ANESPERSONAL', '麻醉-急诊管理浏览', 'EmergencyManagement_bro', 1012, 't', '急诊管理浏览');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1013', 'ANESPERSONAL', '麻醉-污染传染隔离管理维护', 'PollutionInfectionIsolation_mod', 1013, 't', '污染传染隔离管理维护');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1014', 'ANESPERSONAL', '麻醉-污染传染隔离管理浏览', 'PollutionInfectionIsolation_bro', 1014, 't', '污染传染隔离管理浏览');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1015', 'ANESPERSONAL', '麻醉-取消手术维护', 'CancelOperation_mod', 1015, 't', '取消手术维护');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1016', 'ANESPERSONAL', '麻醉-取消手术浏览', 'CancelOperation_bro', 1016, 't', '取消手术浏览');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1017', 'ANESPERSONAL', '麻醉-手术入出转维护', 'InOrOutSurgery_mod', 1017, 't', '手术入出转维护');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1018', 'ANESPERSONAL', '麻醉-手术入出转浏览', 'InOrOutSurgery_bro', 1018, 't', '手术入出转浏览');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1019', 'ANESPERSONAL', '麻醉-麻醉单附页维护', 'AnesthesiaSingleAttached_mod', 1019, 't', '麻醉单附页维护');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1020', 'ANESPERSONAL', '麻醉-麻醉单附页浏览', 'AnesthesiaSingleAttached_bro', 1020, 't', '麻醉单附页浏览');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1021', 'ANESPERSONAL', '麻醉-诱导管理维护', 'GuidanceManagement_mod', 1021, 't', '诱导管理维护');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1022', 'ANESPERSONAL', '麻醉-诱导管理浏览', 'GuidanceManagement_bro', 1022, 't', '诱导管理浏览');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1023', 'ANESPERSONAL', '麻醉-补液平衡维护', 'FluidBalance_mod', 1023, 't', '补液平衡维护');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1024', 'ANESPERSONAL', '麻醉-补液平衡浏览', 'FluidBalance_bro', 1024, 't', '补液平衡浏览');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1025', 'ANESPERSONAL', '麻醉-体外循环维护', 'CardiopulmonaryBypass_mod', 1025, 't', '体外循环维护');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1026', 'ANESPERSONAL', '麻醉-体外循环浏览', 'CardiopulmonaryBypass_bro', 1026, 't', '体外循环浏览');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1027', 'ANESPERSONAL', '麻醉-镇痛管理维护', 'PainManagement_mod', 1027, 't', '镇痛管理维护');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1028', 'ANESPERSONAL', '麻醉-镇痛管理浏览', 'PainManagement_bro', 1028, 't', '镇痛管理浏览');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1029', 'ANESPERSONAL', '麻醉-术后随访维护', 'ViewAfterOperation_mod', 1029, 't', '术后随访维护');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1030', 'ANESPERSONAL', '麻醉-术后随访浏览', 'ViewAfterOperation_bro', 1030, 't', '术后随访浏览');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1031', 'ANESPERSONAL', '麻醉-术后登记维护', 'RegisterAfterOperation_mod', 1031, 't', '术后登记维护');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1032', 'ANESPERSONAL', '麻醉-术后登记浏览', 'RegisterAfterOperation_bro', 1032, 't', '术后登记浏览');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1033', 'ANESPERSONAL', '麻醉-病案提交维护', 'LockPatient_mod', 1033, 't', '病案提交维护');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1034', 'ANESPERSONAL', '麻醉-病案提交浏览', 'LockPatient_bro', 1034, 't', '病案提交浏览');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1035', 'ANESPERSONAL', '麻醉-护理信息维护', 'NursingInfo_mod', 1035, 't', '护理信息维护');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1036', 'ANESPERSONAL', '麻醉-护理信息浏览', 'NursingInfo_bro', 1036, 't', '护理信息浏览');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL普通操作权限', 'ANESPERSONAL', '麻醉-普通操作权限(武汉亚心)', '普通操作权限', 1126, 'T', '普通操作权限');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL超级操作权限', 'ANESPERSONAL', '麻醉-超级操作权限(武汉亚心)', '超级操作权限', 1126, 'T', '超级操作权限');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1037', 'ANESPERSONAL', '麻醉-自动采集维护', 'SetMonitor_mod', 1037, 't', '自动采集维护');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1038', 'ANESPERSONAL', '麻醉-自动采集浏览', 'SetMonitor_bro', 1038, 't', '自动采集浏览');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1039', 'ANESPERSONAL', '麻醉-体征数据管理维护', 'SignsDataManagement_mod', 1039, 't', '体征数据管理维护');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1040', 'ANESPERSONAL', '麻醉-体征数据管理浏览', 'SignsDataManagement_bro', 1040, 't', '体征数据管理浏览');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1041', 'ANESPERSONAL', '麻醉-实时显示维护', 'RealTimeDisplay_mod', 1041, 't', '实时显示维护');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1042', 'ANESPERSONAL', '麻醉-实时显示浏览', 'RealTimeDisplay_bro', 1042, 't', '实时显示浏览');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1043', 'ANESPERSONAL', '麻醉-患者列表维护', 'Patientlist_mod', 1043, 't', '患者列表维护');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1044', 'ANESPERSONAL', '麻醉-患者列表浏览', 'Patientlist_bro', 1044, 't', '患者列表浏览');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1045', 'ANESPERSONAL', '麻醉-基本信息维护', 'BasicInfo_mod', 1045, 't', '基本信息维护');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1046', 'ANESPERSONAL', '麻醉-基本信息浏览', 'BasicInfo_bro', 1046, 't', '基本信息浏览');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1047', 'ANESPERSONAL', '麻醉-住院信息维护', 'InHospitalInfo_mod', 1047, 't', '住院信息维护');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1048', 'ANESPERSONAL', '麻醉-住院信息浏览', 'InHospitalInfo_bro', 1048, 't', '住院信息浏览');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1049', 'ANESPERSONAL', '麻醉-手术信息维护', 'SurgeryInfo_mod', 1049, 't', '手术信息维护');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1050', 'ANESPERSONAL', '麻醉-手术信息浏览', 'SurgeryInfo_bro', 1050, 't', '手术信息浏览');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1051', 'ANESPERSONAL', '麻醉-检查检验维护', 'CheckTest_mod', 1051, 't', '检查检验维护');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1052', 'ANESPERSONAL', '麻醉-检查检验浏览', 'CheckTest_bro', 1052, 't', '检查检验浏览');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1053', 'ANESPERSONAL', '麻醉-医嘱信息维护', 'PrescriptionInfo_mod', 1053, 't', '医嘱信息维护');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1054', 'ANESPERSONAL', '麻醉-医嘱信息浏览', 'PrescriptionInfo_bro', 1054, 't', '医嘱信息浏览');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1055', 'ANESPERSONAL', '麻醉-系统配置维护', 'ParameterConfig_mod', 1055, 't', '参数配置维护');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1056', 'ANESPERSONAL', '麻醉-系统配置浏览', 'ParameterConfig_bro', 1056, 't', '参数配置浏览');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1057', 'ANESPERSONAL', '麻醉-字典维护', 'EditDict_mod', 1057, 't', '字典维护');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1058', 'ANESPERSONAL', '麻醉-字典浏览', 'EditDict_bro', 1058, 't', '字典浏览');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1059', 'ANESPERSONAL', '麻醉-模板维护', 'NewModelManager_mod', 1059, 't', '模板维护');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1060', 'ANESPERSONAL', '麻醉-模板浏览', 'NewModelManager_bro', 1060, 't', '模板浏览');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1061', 'ANESPERSONAL', '麻醉-系统锁定维护', 'LockSystem_mod', 1061, 't', '系统锁定维护');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1062', 'ANESPERSONAL', '麻醉-修改口令维护', 'ChangePassword_mod', 1062, 't', '修改口令维护');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1063', 'ANESPERSONAL', '麻醉-科室信息维护', 'DeptInfo_mod', 1063, 't', '科室信息维护');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1064', 'ANESPERSONAL', '麻醉-科室信息浏览', 'DeptInfo_bro', 1064, 't', '科室信息浏览');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1065', 'ANESPERSONAL', '麻醉-人员信息维护', 'UserInfo_mod', 1065, 't', '人员信息维护');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1066', 'ANESPERSONAL', '麻醉-人员信息浏览', 'UserInfo_bro', 1066, 't', '人员信息浏览');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1067', 'ANESPERSONAL', '麻醉-人员情况查询', 'StaffInfoQuery_bro', 1067, 't', '人员情况查询');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1068', 'ANESPERSONAL', '麻醉-手术统计', 'SurgeryCoutQuery_bro', 1068, 't', '手术统计');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1069', 'ANESPERSONAL', '麻醉-手术日报表', 'OperDiaryQuery_bro', 1069, 't', '手术日报表');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1070', 'ANESPERSONAL', '麻醉-手术月报表', 'OperMonthQuery_bro', 1070, 't', '手术月报表');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1071', 'ANESPERSONAL', '麻醉-科室手术情况统计', 'DeprStatQuery_bro', 1071, 't', '科室手术情况统计');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1072', 'ANESPERSONAL', '麻醉-科室人员手术统计', 'WorkSumQuery_bro', 1072, 't', '科室人员手术统计');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1073', 'ANESPERSONAL', '麻醉-人员班次情况统计', 'StaffScheduleQuery_bro', 1073, 't', '人员班次情况统计');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-31', 'ANESPERSONAL', '麻醉-PACU医嘱单', 'PACU医嘱单', 931, 't', 'PACU医嘱单');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1074', 'ANESPERSONAL', '麻醉-手术查询', 'AnesQueryQuery_bro', 1074, 't', '手术查询');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1075', 'ANESPERSONAL', '麻醉-取消手术查询', 'CancelAnesQuery_bro', 1075, 't', '取消手术查询');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1076', 'ANESPERSONAL', '麻醉-麻醉科工作量查询', 'WorkloadTimeQuery_bro', 1076, 't', '麻醉科工作量查询');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1077', 'ANESPERSONAL', '麻醉-麻醉登记表', 'AnesLoginQuery_bro', 1077, 't', '麻醉登记表');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1078', 'ANESPERSONAL', '麻醉-术后统计', 'InfoAfterOperQuery_bro', 1078, 't', '术后统计');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1079', 'ANESPERSONAL', '麻醉-每日大手术预报查询', 'LargeOperReportQuery_bro', 1079, 't', '每日大手术预报查询');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1080', 'ANESPERSONAL', '麻醉-万能查询', 'OperationQuery_bro', 1080, 't', '万能查询');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1081', 'ANESPERSONAL', '麻醉-费用查询', 'CostQuery_bro', 1081, 't', '费用查询');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1082', 'ANESPERSONAL', '麻醉-药品耗材使用明细查询', 'DrugSuppliesDetailsQuery_bro', 1082, 't', '药品耗材使用明细查询');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1083', 'ANESPERSONAL', '麻醉-按患者身份手术量统计', 'IdentityQuery_bro', 1083, 't', '按患者身份手术量统计');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1084', 'ANESPERSONAL', '麻醉-科室工作量对比表', 'DeptAnesWorkQuery_bro', 1084, 't', '科室工作量对比表');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1085', 'ANESPERSONAL', '麻醉-全院麻醉方法统计', 'HospitalQueryQuery_bro', 1085, 't', '全院麻醉方法统计');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1086', 'ANESPERSONAL', '麻醉-科室麻醉方法统计', 'DeptMethodQuery_bro', 1086, 't', '科室麻醉方法统计');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1087', 'ANESPERSONAL', '麻醉-医生麻醉方法统计', 'DoctorMethodQuery_bro', 1087, 't', '医生麻醉方法统计');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1088', 'ANESPERSONAL', '麻醉-镇痛统计', 'ZhenTongStatQuery_bro', 1088, 't', '镇痛统计');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1089', 'ANESPERSONAL', '麻醉-输血统计', 'BloodStatQuery_bro', 1089, 't', '输血统计');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1090', 'ANESPERSONAL', '麻醉-药品耗材使用情况统计', 'DrugSuppliesUseQuery_bro', 1090, 't', '药品耗材使用情况统计');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1091', 'ANESPERSONAL', '麻醉-麻醉评分维护', 'AnesthesiaScore_mod', 1091, 't', '麻醉评分维护');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1092', 'ANESPERSONAL', '麻醉-麻醉评分浏览', 'AnesthesiaScore_bro', 1092, 't', '麻醉评分浏览');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1093', 'ANESPERSONAL', '麻醉-药品使用说明书维护', 'DrugManual_mod', 1093, 't', '药品使用说明书维护');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1094', 'ANESPERSONAL', '麻醉-药品使用说明书浏览', 'DrugManual_bro', 1094, 't', '药品使用说明书浏览');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1095', 'ANESPERSONAL', '麻醉-His科室维护', 'HISDept_mod', 1095, 't', 'His科室维护');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1096', 'ANESPERSONAL', '麻醉-His科室浏览', 'HISDept_bro', 1096, 't', 'His科室浏览');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1097', 'ANESPERSONAL', '麻醉-His人员维护', 'HISUser_mod', 1097, 't', 'His人员维护');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1098', 'ANESPERSONAL', '麻醉-His人员浏览', 'HISUser_bro', 1098, 't', 'His人员浏览');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1099', 'ANESPERSONAL', '麻醉-患者信息维护', 'PatientInfo_mod', 1099, 't', '患者信息维护');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-11', 'ANESPERSONAL', '麻醉-大事件', '大事件', 911, 't', '大事件');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1100', 'ANESPERSONAL', '麻醉-患者信息浏览', 'PatientInfo_bro', 1100, 't', '患者信息浏览');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1101', 'ANESPERSONAL', '麻醉-His药品耗材维护', 'HISDrugSupplies_mod', 1101, 't', 'His药品耗材维护');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1102', 'ANESPERSONAL', '麻醉-His药品耗材浏览', 'HISDrugSupplies_bro', 1102, 't', 'His药品耗材浏览');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1103', 'ANESPERSONAL', '麻醉-病历病程维护', 'MedicalCourse_mod', 1103, 't', '病历病程维护');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1104', 'ANESPERSONAL', '麻醉-病历病程浏览', 'MedicalCourse_bro', 1104, 't', '病历病程浏览');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1105', 'ANESPERSONAL', '麻醉-信息回写维护', 'InfoWriteBack_mod', 1105, 't', '信息回写维护');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1106', 'ANESPERSONAL', '麻醉-信息回写浏览', 'InfoWriteBack_bro', 1106, 't', '信息回写浏览');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1107', 'ANESPERSONAL', '麻醉-手术通知单维护', 'SurgeryNotice_mod', 1107, 't', '手术通知单维护');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1108', 'ANESPERSONAL', '麻醉-手术通知单浏览', 'SurgeryNotice_bro', 1108, 't', '手术通知单浏览');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1109', 'ANESPERSONAL', '麻醉-手术通知单导入', 'SurgeryNotice_imp', 1109, 't', '手术通知单导入');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1110', 'ANESPERSONAL', '麻醉-手术通知单导出', 'SurgeryNotice_exp', 1110, 't', '手术通知单导出');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1111', 'ANESPERSONAL', '麻醉-术前访视维护', 'ViewBeforeOperation_mod', 1111, 't', '术前访视维护');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1112', 'ANESPERSONAL', '麻醉-术前访视浏览', 'ViewBeforeOperation_bro', 1112, 't', '术前访视浏览');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1113', 'ANESPERSONAL', '麻醉-术前访视导入', 'ViewBeforeOperation_imp', 1113, 't', '术前访视导入');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1114', 'ANESPERSONAL', '麻醉-术前访视导出', 'ViewBeforeOperation_exp', 1114, 't', '术前访视导出');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1115', 'ANESPERSONAL', '麻醉-麻醉记录单维护', 'AnesthesiaRecord_mod', 1115, 't', '麻醉记录单维护');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1116', 'ANESPERSONAL', '麻醉-麻醉记录单浏览', 'AnesthesiaRecord_bro', 1116, 't', '麻醉记录单浏览');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1117', 'ANESPERSONAL', '麻醉-麻醉记录单导入', 'AnesthesiaRecord_imp', 1117, 't', '麻醉记录单导入');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1118', 'ANESPERSONAL', '麻醉-麻醉记录单导出', 'AnesthesiaRecord_exp', 1118, 't', '麻醉记录单导出');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1119', 'ANESPERSONAL', '麻醉-麻醉总结维护', 'AnesthesiaSummary_mod', 1119, 't', '麻醉总结维护');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1120', 'ANESPERSONAL', '麻醉-麻醉总结浏览', 'AnesthesiaSummary_bro', 1120, 't', '麻醉总结浏览');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1121', 'ANESPERSONAL', '麻醉-麻醉总结导入', 'AnesthesiaSummary_imp', 1121, 't', '麻醉总结导入');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1122', 'ANESPERSONAL', '麻醉-麻醉总结导出', 'AnesthesiaSummary_exp', 1122, 't', '麻醉总结导出');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1123', 'ANESPERSONAL', '麻醉-敷料器械清点维护', 'DressingEquipmentInventory_mod', 1123, 't', '敷料器械清点维护');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1124', 'ANESPERSONAL', '麻醉-敷料器械清点浏览', 'DressingEquipmentInventory_bro', 1124, 't', '敷料器械清点浏览');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1125', 'ANESPERSONAL', '麻醉-敷料器械清点导入', 'DressingEquipmentInventory_imp', 1125, 't', '敷料器械清点导入');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-1126', 'ANESPERSONAL', '麻醉-敷料器械清点导出', 'DressingEquipmentInventory_exp', 1126, 't', '敷料器械清点导出');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-12', 'ANESPERSONAL', '麻醉-监护仪配置', '监护仪配置', 912, 't', '监护仪配置');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-13', 'ANESPERSONAL', '麻醉-监护仪配置浏览', '监护仪配置浏览', 913, 't', '监护仪配置浏览');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-14', 'ANESPERSONAL', '麻醉-麻醉记录数据维护', '麻醉记录数据维护', 914, 't', '麻醉记录数据维护');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-15', 'ANESPERSONAL', '麻醉-麻醉记录数据浏览', '麻醉记录数据浏览', 915, 't', '麻醉记录数据浏览');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-16', 'ANESPERSONAL', '麻醉-查询功能', '查询功能', 916, 't', '查询功能');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-17', 'ANESPERSONAL', '麻醉-上报质控信息', '上报质控信息', 917, 't', '上报质控信息');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-18', 'ANESPERSONAL', '麻醉-提交患者信息功能', '提交患者信息功能', 918, 't', '提交患者信息功能');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-19', 'ANESPERSONAL', '麻醉-复苏单', '复苏单', 919, 't', '复苏单');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-2', 'ANESPERSONAL', '麻醉-各医疗文书维护', '各医疗文书维护', 902, 't', '各医疗文书维护');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-20', 'ANESPERSONAL', '麻醉-护理信息', '护理信息', 920, 't', '护理信息');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-21', 'ANESPERSONAL', '麻醉-麻醉单', '麻醉单', 921, 't', '麻醉单');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-22', 'ANESPERSONAL', '麻醉-麻醉单反面', '麻醉单反面', 922, 't', '麻醉单反面');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-23', 'ANESPERSONAL', '麻醉-麻醉科操作记录单', '麻醉科操作记录单', 923, 't', '麻醉科操作记录单');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-24', 'ANESPERSONAL', '麻醉-麻醉知情同意书', '麻醉知情同意书', 924, 't', '麻醉知情同意书');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-25', 'ANESPERSONAL', '麻醉-麻醉总结', '麻醉总结', 925, 't', '麻醉总结');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-26', 'ANESPERSONAL', '麻醉-气管插管同意书', '气管插管同意书', 926, 't', '气管插管同意书');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-27', 'ANESPERSONAL', '麻醉-术后镇痛记录单', '术后镇痛记录单', 927, 't', '术后镇痛记录单');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-28', 'ANESPERSONAL', '麻醉-术前访视单', '术前访视单', 928, 't', '术前访视单');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-29', 'ANESPERSONAL', '麻醉-疼痛治疗知情同意书', '疼痛治疗知情同意书', 929, 't', '疼痛治疗知情同意书');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-3', 'ANESPERSONAL', '麻醉-各医疗文书浏览', '各医疗文书浏览', 903, 't', '各医疗文书浏览');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-AutoAdd-30', 'ANESPERSONAL', '麻醉-术后随访单', '术后随访单', 930, 't', '术后随访单');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('5001', 'ANESPERSONAL', '分配手术', '手术排班-分配手术', null, 'T', '为手术分配手术间');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('5002', 'ANESPERSONAL', '主麻醉医师', '手术排班-主麻醉医师', null, 'T', '为主麻醉医师分配手术间');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('5003', 'ANESPERSONAL', '副麻醉医师', '手术排班-副麻醉医师', null, 'T', '为副麻醉医师分配手术间');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('5004', 'ANESPERSONAL', '分配麻醉方法', '手术排班-分配麻醉方法', null, 'T', '为手术分配麻醉方法');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('5005', 'ANESPERSONAL', '分配洗手护士', '手术排班-分配洗手护士', null, 'T', '为手术间分配洗手护士');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('5006', 'ANESPERSONAL', '分配巡回护士', '手术排班-分配巡回护士', null, 'T', '为手术间分配巡回护士');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('5007', 'ANESPERSONAL', '系统配置', '手术排班-系统配置', null, 'T', '系统配置');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('5008', 'ANESPERSONAL', '手术申请', '手术排班-手术申请', null, 'T', '手术申请');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('5009', 'ANESPERSONAL', '手术撤销', '手术排班-手术撤销', null, 'T', '作废或提交的手术撤销');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('5010', 'ANESPERSONAL', '手术提交', '手术排版-手术提交', null, 'T', '排班完成之后提交手术');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('5011', 'ANESPERSONAL', 'HIS同步', '手术排班-HIS同步', null, 'T', '同步HIS数据');

INSERT INTO MED_PERMISSIONS(PERMISSION_ID,APP_ID,NAME,PERMISSION_KEY,IS_VALID,DESCRIPTION)
VALUES('5012','ANESPERSONAL','人员排班-麻醉医师','人员排班-麻醉医师','T','麻醉医师排班');

INSERT INTO MED_PERMISSIONS(PERMISSION_ID,APP_ID,NAME,PERMISSION_KEY,IS_VALID,DESCRIPTION)
VALUES('5013','ANESPERSONAL','人员排班-护士','人员排班-护士','T','护士排班');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-1', 'ANESPERSONAL', '麻醉-穿刺管理维护(武汉亚心)', 'PunctureManager_mod', null, 'T', '穿刺管理维护');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-2', 'ANESPERSONAL', '麻醉-穿刺管理浏览(武汉亚心)', 'PunctureManager_bro', null, 'T', '穿刺管理浏览');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-3', 'ANESPERSONAL', '麻醉-麻醉前小结维护', 'SummaryBeforeAnes_mod', null, 't', '麻醉前小结维护');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-4', 'ANESPERSONAL', '麻醉-麻醉前小结浏览', 'SummaryBeforeAnes_bro', null, 't', '麻醉前小结浏览');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-5', 'ANESPERSONAL', '麻醉-麻醉前小结导入', 'SummaryBeforeAnes_imp', null, 't', '麻醉前小结导入');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-6', 'ANESPERSONAL', '麻醉-麻醉前小结导出', 'SummaryBeforeAnes_exp', null, 't', '麻醉前小结导出');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-7', 'ANESPERSONAL', '麻醉-手术收费记录维护', 'OperationChargeRecord_mod', null, 't', '手术收费记录维护');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-8', 'ANESPERSONAL', '麻醉-手术收费记录浏览', 'OperationChargeRecord_bro', null, 't', '手术收费记录浏览');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-9', 'ANESPERSONAL', '麻醉-手术收费记录导入', 'OperationChargeRecord_imp', null, 't', '手术收费记录导入');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-10', 'ANESPERSONAL', '麻醉-手术收费记录导出', 'OperationChargeRecord_exp', null, 't', '手术收费记录导出');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-11', 'ANESPERSONAL', '麻醉-血液动力学', '血液动力学', null, 't', '血液动力学');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-12', 'ANESPERSONAL', '麻醉-血气分析维护', 'BloodGasDataEditor_mod', null, 't', '血气分析维护');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-13', 'ANESPERSONAL', '麻醉-血气分析浏览', 'BloodGasDataEditor_bro', null, 't', '血气分析浏览');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-14', 'ANESPERSONAL', '麻醉-手术交班维护', 'OperationShift_mod', null, 't', '手术交班维护');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-15', 'ANESPERSONAL', '麻醉-手术交班浏览', 'OperationShift_bro', null, 't', '手术交班浏览');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-16', 'ANESPERSONAL', '麻醉-手术室概览维护', 'OperationRoomPandect_mod', null, 't', '手术室概览维护');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-17', 'ANESPERSONAL', '麻醉-手术室概览浏览', 'OperationRoomPandect_bro', null, 't', '手术室概览浏览');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-19', 'ANESPERSONAL', '麻醉-公有模板维护', '公有模板维护', null, 't', '公有模板维护');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-20', 'ANESPERSONAL', '麻醉-复苏床位', '复苏床位', null, 't', '复苏床位');

insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('ANESPERSONAL-21', 'ANESPERSONAL', '麻醉-修改已打印的医疗文书', '修改已打印的医疗文书', null, 't', '修改已打印的医疗文书');
insert into Med_Permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION) 
values ('ANESPERSONAL-22', 'ANESPERSONAL', '麻醉-HIS同步', '麻醉HIS同步', null, 't', '麻醉HIS同步');
commit;

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('5b55fb10-53cb-488d-bc83-63778728a116', 'ANESPERSONAL-AutoAdd-1001');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('5b55fb10-53cb-488d-bc83-63778728a116', 'ANESPERSONAL-AutoAdd-1002');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('5b55fb10-53cb-488d-bc83-63778728a116', 'ANESPERSONAL-AutoAdd-1003');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('5b55fb10-53cb-488d-bc83-63778728a116', 'ANESPERSONAL-AutoAdd-1004');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('5b55fb10-53cb-488d-bc83-63778728a116', 'ANESPERSONAL-AutoAdd-1005');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('5b55fb10-53cb-488d-bc83-63778728a116', 'ANESPERSONAL-AutoAdd-1006');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('5b55fb10-53cb-488d-bc83-63778728a116', 'ANESPERSONAL-AutoAdd-1007');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('5b55fb10-53cb-488d-bc83-63778728a116', 'ANESPERSONAL-AutoAdd-1008');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('5b55fb10-53cb-488d-bc83-63778728a116', 'ANESPERSONAL-AutoAdd-1009');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('5b55fb10-53cb-488d-bc83-63778728a116', 'ANESPERSONAL-AutoAdd-1010');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('5b55fb10-53cb-488d-bc83-63778728a116', 'ANESPERSONAL-AutoAdd-1011');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('5b55fb10-53cb-488d-bc83-63778728a116', 'ANESPERSONAL-AutoAdd-1012');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('5b55fb10-53cb-488d-bc83-63778728a116', 'ANESPERSONAL-AutoAdd-1013');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('5b55fb10-53cb-488d-bc83-63778728a116', 'ANESPERSONAL-AutoAdd-1014');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('5b55fb10-53cb-488d-bc83-63778728a116', 'ANESPERSONAL-AutoAdd-1015');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('5b55fb10-53cb-488d-bc83-63778728a116', 'ANESPERSONAL-AutoAdd-1016');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('caac245f-c18c-4f32-b33d-5fc0d6b8a820', 'ANESPERSONAL-AutoAdd-1017');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('caac245f-c18c-4f32-b33d-5fc0d6b8a820', 'ANESPERSONAL-AutoAdd-1018');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('caac245f-c18c-4f32-b33d-5fc0d6b8a820', 'ANESPERSONAL-AutoAdd-1019');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('caac245f-c18c-4f32-b33d-5fc0d6b8a820', 'ANESPERSONAL-AutoAdd-1020');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('caac245f-c18c-4f32-b33d-5fc0d6b8a820', 'ANESPERSONAL-AutoAdd-1021');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('caac245f-c18c-4f32-b33d-5fc0d6b8a820', 'ANESPERSONAL-AutoAdd-1022');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('caac245f-c18c-4f32-b33d-5fc0d6b8a820', 'ANESPERSONAL-AutoAdd-1023');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('caac245f-c18c-4f32-b33d-5fc0d6b8a820', 'ANESPERSONAL-AutoAdd-1024');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('caac245f-c18c-4f32-b33d-5fc0d6b8a820', 'ANESPERSONAL-AutoAdd-1025');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('caac245f-c18c-4f32-b33d-5fc0d6b8a820', 'ANESPERSONAL-AutoAdd-1026');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('caac245f-c18c-4f32-b33d-5fc0d6b8a820', 'ANESPERSONAL-AutoAdd-1027');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('caac245f-c18c-4f32-b33d-5fc0d6b8a820', 'ANESPERSONAL-AutoAdd-1028');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('caac245f-c18c-4f32-b33d-5fc0d6b8a820', 'ANESPERSONAL-AutoAdd-1029');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('caac245f-c18c-4f32-b33d-5fc0d6b8a820', 'ANESPERSONAL-AutoAdd-1030');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('caac245f-c18c-4f32-b33d-5fc0d6b8a820', 'ANESPERSONAL-AutoAdd-1031');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('caac245f-c18c-4f32-b33d-5fc0d6b8a820', 'ANESPERSONAL-AutoAdd-1032');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('caac245f-c18c-4f32-b33d-5fc0d6b8a820', 'ANESPERSONAL-AutoAdd-1033');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('caac245f-c18c-4f32-b33d-5fc0d6b8a820', 'ANESPERSONAL-AutoAdd-1034');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('d22f35b4-71e8-4555-9c19-ff44fbc2fc78', 'ANESPERSONAL-AutoAdd-1035');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('d22f35b4-71e8-4555-9c19-ff44fbc2fc78', 'ANESPERSONAL-AutoAdd-1036');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('17d0de61-cc86-40d7-be47-40b43091e48e', 'ANESPERSONAL-AutoAdd-1037');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('17d0de61-cc86-40d7-be47-40b43091e48e', 'ANESPERSONAL-AutoAdd-1038');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('17d0de61-cc86-40d7-be47-40b43091e48e', 'ANESPERSONAL-AutoAdd-1039');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('17d0de61-cc86-40d7-be47-40b43091e48e', 'ANESPERSONAL-AutoAdd-1040');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('17d0de61-cc86-40d7-be47-40b43091e48e', 'ANESPERSONAL-AutoAdd-1041');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('17d0de61-cc86-40d7-be47-40b43091e48e', 'ANESPERSONAL-AutoAdd-1042');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('5536ab53-19bd-4df2-a254-fea6a354c3c8', 'ANESPERSONAL-AutoAdd-1043');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('5536ab53-19bd-4df2-a254-fea6a354c3c8', 'ANESPERSONAL-AutoAdd-1044');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('5536ab53-19bd-4df2-a254-fea6a354c3c8', 'ANESPERSONAL-AutoAdd-1045');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('5536ab53-19bd-4df2-a254-fea6a354c3c8', 'ANESPERSONAL-AutoAdd-1046');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('5536ab53-19bd-4df2-a254-fea6a354c3c8', 'ANESPERSONAL-AutoAdd-1047');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('5536ab53-19bd-4df2-a254-fea6a354c3c8', 'ANESPERSONAL-AutoAdd-1048');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('5536ab53-19bd-4df2-a254-fea6a354c3c8', 'ANESPERSONAL-AutoAdd-1049');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('5536ab53-19bd-4df2-a254-fea6a354c3c8', 'ANESPERSONAL-AutoAdd-1050');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('5536ab53-19bd-4df2-a254-fea6a354c3c8', 'ANESPERSONAL-AutoAdd-1051');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('5536ab53-19bd-4df2-a254-fea6a354c3c8', 'ANESPERSONAL-AutoAdd-1052');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('5536ab53-19bd-4df2-a254-fea6a354c3c8', 'ANESPERSONAL-AutoAdd-1053');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('5536ab53-19bd-4df2-a254-fea6a354c3c8', 'ANESPERSONAL-AutoAdd-1054');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('13283f8f-4b51-4e17-85d8-be5a76397145', 'ANESPERSONAL-AutoAdd-1055');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('13283f8f-4b51-4e17-85d8-be5a76397145', 'ANESPERSONAL-AutoAdd-1056');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('13283f8f-4b51-4e17-85d8-be5a76397145', 'ANESPERSONAL-AutoAdd-1057');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('13283f8f-4b51-4e17-85d8-be5a76397145', 'ANESPERSONAL-AutoAdd-1058');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('13283f8f-4b51-4e17-85d8-be5a76397145', 'ANESPERSONAL-AutoAdd-1059');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('13283f8f-4b51-4e17-85d8-be5a76397145', 'ANESPERSONAL-AutoAdd-1060');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('13283f8f-4b51-4e17-85d8-be5a76397145', 'ANESPERSONAL-AutoAdd-1061');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('13283f8f-4b51-4e17-85d8-be5a76397145', 'ANESPERSONAL-AutoAdd-1062');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('0651ec78-a21d-493a-bf60-b4221a64214a', 'ANESPERSONAL-AutoAdd-1063');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('0651ec78-a21d-493a-bf60-b4221a64214a', 'ANESPERSONAL-AutoAdd-1064');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('0651ec78-a21d-493a-bf60-b4221a64214a', 'ANESPERSONAL-AutoAdd-1065');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('0651ec78-a21d-493a-bf60-b4221a64214a', 'ANESPERSONAL-AutoAdd-1066');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('8f95e262-1f6a-4397-ba30-2dcc8ff8b840', 'ANESPERSONAL-AutoAdd-1067');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('8f95e262-1f6a-4397-ba30-2dcc8ff8b840', 'ANESPERSONAL-AutoAdd-1068');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('8f95e262-1f6a-4397-ba30-2dcc8ff8b840', 'ANESPERSONAL-AutoAdd-1069');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('8f95e262-1f6a-4397-ba30-2dcc8ff8b840', 'ANESPERSONAL-AutoAdd-1070');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('8f95e262-1f6a-4397-ba30-2dcc8ff8b840', 'ANESPERSONAL-AutoAdd-1071');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('8f95e262-1f6a-4397-ba30-2dcc8ff8b840', 'ANESPERSONAL-AutoAdd-1072');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('8f95e262-1f6a-4397-ba30-2dcc8ff8b840', 'ANESPERSONAL-AutoAdd-1073');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('8f95e262-1f6a-4397-ba30-2dcc8ff8b840', 'ANESPERSONAL-AutoAdd-1074');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('8f95e262-1f6a-4397-ba30-2dcc8ff8b840', 'ANESPERSONAL-AutoAdd-1075');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('8f95e262-1f6a-4397-ba30-2dcc8ff8b840', 'ANESPERSONAL-AutoAdd-1076');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('8f95e262-1f6a-4397-ba30-2dcc8ff8b840', 'ANESPERSONAL-AutoAdd-1077');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('8f95e262-1f6a-4397-ba30-2dcc8ff8b840', 'ANESPERSONAL-AutoAdd-1078');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('8f95e262-1f6a-4397-ba30-2dcc8ff8b840', 'ANESPERSONAL-AutoAdd-1079');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('8f95e262-1f6a-4397-ba30-2dcc8ff8b840', 'ANESPERSONAL-AutoAdd-1080');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('8f95e262-1f6a-4397-ba30-2dcc8ff8b840', 'ANESPERSONAL-AutoAdd-1081');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('8f95e262-1f6a-4397-ba30-2dcc8ff8b840', 'ANESPERSONAL-AutoAdd-1082');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('8f95e262-1f6a-4397-ba30-2dcc8ff8b840', 'ANESPERSONAL-AutoAdd-1083');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('8f95e262-1f6a-4397-ba30-2dcc8ff8b840', 'ANESPERSONAL-AutoAdd-1084');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('8f95e262-1f6a-4397-ba30-2dcc8ff8b840', 'ANESPERSONAL-AutoAdd-1085');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('8f95e262-1f6a-4397-ba30-2dcc8ff8b840', 'ANESPERSONAL-AutoAdd-1086');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('8f95e262-1f6a-4397-ba30-2dcc8ff8b840', 'ANESPERSONAL-AutoAdd-1087');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('8f95e262-1f6a-4397-ba30-2dcc8ff8b840', 'ANESPERSONAL-AutoAdd-1088');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('8f95e262-1f6a-4397-ba30-2dcc8ff8b840', 'ANESPERSONAL-AutoAdd-1089');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('8f95e262-1f6a-4397-ba30-2dcc8ff8b840', 'ANESPERSONAL-AutoAdd-1090');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('c6c4f499-b39d-4dbb-ad78-11aed20c6160', 'ANESPERSONAL-AutoAdd-1091');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('c6c4f499-b39d-4dbb-ad78-11aed20c6160', 'ANESPERSONAL-AutoAdd-1092');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('c6c4f499-b39d-4dbb-ad78-11aed20c6160', 'ANESPERSONAL-AutoAdd-1093');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('c6c4f499-b39d-4dbb-ad78-11aed20c6160', 'ANESPERSONAL-AutoAdd-1094');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('d76e800c-485c-4bad-909f-60796f595ca5', 'ANESPERSONAL-AutoAdd-1095');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('d76e800c-485c-4bad-909f-60796f595ca5', 'ANESPERSONAL-AutoAdd-1096');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('d76e800c-485c-4bad-909f-60796f595ca5', 'ANESPERSONAL-AutoAdd-1097');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('d76e800c-485c-4bad-909f-60796f595ca5', 'ANESPERSONAL-AutoAdd-1098');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('d76e800c-485c-4bad-909f-60796f595ca5', 'ANESPERSONAL-AutoAdd-1099');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('d76e800c-485c-4bad-909f-60796f595ca5', 'ANESPERSONAL-AutoAdd-1100');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('d76e800c-485c-4bad-909f-60796f595ca5', 'ANESPERSONAL-AutoAdd-1101');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('d76e800c-485c-4bad-909f-60796f595ca5', 'ANESPERSONAL-AutoAdd-1102');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('d76e800c-485c-4bad-909f-60796f595ca5', 'ANESPERSONAL-AutoAdd-1103');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('d76e800c-485c-4bad-909f-60796f595ca5', 'ANESPERSONAL-AutoAdd-1104');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('d76e800c-485c-4bad-909f-60796f595ca5', 'ANESPERSONAL-AutoAdd-1105');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('d76e800c-485c-4bad-909f-60796f595ca5', 'ANESPERSONAL-AutoAdd-1106');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('dd8e9e63-4fc7-454d-b296-80b165d4725d', 'ANESPERSONAL-AutoAdd-1107');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('dd8e9e63-4fc7-454d-b296-80b165d4725d', 'ANESPERSONAL-AutoAdd-1108');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('dd8e9e63-4fc7-454d-b296-80b165d4725d', 'ANESPERSONAL-AutoAdd-1109');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('dd8e9e63-4fc7-454d-b296-80b165d4725d', 'ANESPERSONAL-AutoAdd-1110');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('dd8e9e63-4fc7-454d-b296-80b165d4725d', 'ANESPERSONAL-AutoAdd-1111');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('dd8e9e63-4fc7-454d-b296-80b165d4725d', 'ANESPERSONAL-AutoAdd-1112');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('dd8e9e63-4fc7-454d-b296-80b165d4725d', 'ANESPERSONAL-AutoAdd-1113');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('dd8e9e63-4fc7-454d-b296-80b165d4725d', 'ANESPERSONAL-AutoAdd-1114');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('dd8e9e63-4fc7-454d-b296-80b165d4725d', 'ANESPERSONAL-AutoAdd-1115');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('dd8e9e63-4fc7-454d-b296-80b165d4725d', 'ANESPERSONAL-AutoAdd-1116');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('dd8e9e63-4fc7-454d-b296-80b165d4725d', 'ANESPERSONAL-AutoAdd-1117');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('dd8e9e63-4fc7-454d-b296-80b165d4725d', 'ANESPERSONAL-AutoAdd-1118');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('dd8e9e63-4fc7-454d-b296-80b165d4725d', 'ANESPERSONAL-AutoAdd-1119');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('dd8e9e63-4fc7-454d-b296-80b165d4725d', 'ANESPERSONAL-AutoAdd-1120');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('dd8e9e63-4fc7-454d-b296-80b165d4725d', 'ANESPERSONAL-AutoAdd-1121');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('dd8e9e63-4fc7-454d-b296-80b165d4725d', 'ANESPERSONAL-AutoAdd-1122');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('dd8e9e63-4fc7-454d-b296-80b165d4725d', 'ANESPERSONAL-AutoAdd-1123');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('dd8e9e63-4fc7-454d-b296-80b165d4725d', 'ANESPERSONAL-AutoAdd-1124');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('dd8e9e63-4fc7-454d-b296-80b165d4725d', 'ANESPERSONAL-AutoAdd-1125');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('dd8e9e63-4fc7-454d-b296-80b165d4725d', 'ANESPERSONAL-AutoAdd-1126');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('dd8e9e63-4fc7-454d-b296-80b165d4725d', 'ANESPERSONAL-AutoAdd-24');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('dd8e9e63-4fc7-454d-b296-80b165d4725d', 'ANESPERSONAL-AutoAdd-35');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('caac245f-c18c-4f32-b33d-5fc0d6b8a820', 'ANESPERSONAL-AutoAdd-1');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('caac245f-c18c-4f32-b33d-5fc0d6b8a820', 'ANESPERSONAL-AutoAdd-10');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('caac245f-c18c-4f32-b33d-5fc0d6b8a820', 'ANESPERSONAL-AutoAdd-11');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('25ed15e5-1a95-4714-9476-b8fc63d7058b', 'ANESPERSONAL-AutoAdd-9');
commit;
insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('25ed15e5-1a95-4714-9476-b8fc63d7058b', 'ANESPERSONAL-AutoAdd-8');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('25ed15e5-1a95-4714-9476-b8fc63d7058b', 'ANESPERSONAL-AutoAdd-7');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('25ed15e5-1a95-4714-9476-b8fc63d7058b', 'ANESPERSONAL-AutoAdd-6');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('25ed15e5-1a95-4714-9476-b8fc63d7058b', 'ANESPERSONAL-AutoAdd-5');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('25ed15e5-1a95-4714-9476-b8fc63d7058b', 'ANESPERSONAL-AutoAdd-4');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('25ed15e5-1a95-4714-9476-b8fc63d7058b', 'ANESPERSONAL-AutoAdd-34');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('25ed15e5-1a95-4714-9476-b8fc63d7058b', 'ANESPERSONAL-AutoAdd-33');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('25ed15e5-1a95-4714-9476-b8fc63d7058b', 'ANESPERSONAL-AutoAdd-32');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('25ed15e5-1a95-4714-9476-b8fc63d7058b', 'ANESPERSONAL-AutoAdd-31');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('25ed15e5-1a95-4714-9476-b8fc63d7058b', 'ANESPERSONAL-AutoAdd-30');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('25ed15e5-1a95-4714-9476-b8fc63d7058b', 'ANESPERSONAL-AutoAdd-3');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('25ed15e5-1a95-4714-9476-b8fc63d7058b', 'ANESPERSONAL-AutoAdd-29');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('25ed15e5-1a95-4714-9476-b8fc63d7058b', 'ANESPERSONAL-AutoAdd-28');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('25ed15e5-1a95-4714-9476-b8fc63d7058b', 'ANESPERSONAL-AutoAdd-27');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('25ed15e5-1a95-4714-9476-b8fc63d7058b', 'ANESPERSONAL-AutoAdd-26');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('25ed15e5-1a95-4714-9476-b8fc63d7058b', 'ANESPERSONAL-AutoAdd-25');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('25ed15e5-1a95-4714-9476-b8fc63d7058b', 'ANESPERSONAL-AutoAdd-23');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('25ed15e5-1a95-4714-9476-b8fc63d7058b', 'ANESPERSONAL-AutoAdd-12');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('25ed15e5-1a95-4714-9476-b8fc63d7058b', 'ANESPERSONAL-AutoAdd-13');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('25ed15e5-1a95-4714-9476-b8fc63d7058b', 'ANESPERSONAL-AutoAdd-14');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('25ed15e5-1a95-4714-9476-b8fc63d7058b', 'ANESPERSONAL-AutoAdd-15');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('dd8e9e63-4fc7-454d-b296-80b165d4725d', 'ANESPERSONAL-AutoAdd-19');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('25ed15e5-1a95-4714-9476-b8fc63d7058b', 'ANESPERSONAL-AutoAdd-18');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('25ed15e5-1a95-4714-9476-b8fc63d7058b', 'ANESPERSONAL-AutoAdd-16');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('25ed15e5-1a95-4714-9476-b8fc63d7058b', 'ANESPERSONAL-AutoAdd-17');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('25ed15e5-1a95-4714-9476-b8fc63d7058b', 'ANESPERSONAL-AutoAdd-2');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('25ed15e5-1a95-4714-9476-b8fc63d7058b', 'ANESPERSONAL-AutoAdd-20');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('25ed15e5-1a95-4714-9476-b8fc63d7058b', 'ANESPERSONAL-AutoAdd-21');

insert into med_perkind_rela (KIND_ID, PERMISSION_ID)
values ('25ed15e5-1a95-4714-9476-b8fc63d7058b', 'ANESPERSONAL-AutoAdd-22');
commit;


insert into med_permissions_kind (KIND_ID, APP_ID, NAME, SORT_ID, IS_VALID, DESCRIPTION)
values ('0651ec78-a21d-493a-bf60-b4221a64214a', 'ANESPERSONAL', '科室管理', 7, 't', '科室管理');

insert into med_permissions_kind (KIND_ID, APP_ID, NAME, SORT_ID, IS_VALID, DESCRIPTION)
values ('13283f8f-4b51-4e17-85d8-be5a76397145', 'ANESPERSONAL', '系统维护', 6, 't', '系统维护');

insert into med_permissions_kind (KIND_ID, APP_ID, NAME, SORT_ID, IS_VALID, DESCRIPTION)
values ('17d0de61-cc86-40d7-be47-40b43091e48e', 'ANESPERSONAL', '数据采集', 4, 't', '数据采集');

insert into med_permissions_kind (KIND_ID, APP_ID, NAME, SORT_ID, IS_VALID, DESCRIPTION)
values ('5536ab53-19bd-4df2-a254-fea6a354c3c8', 'ANESPERSONAL', '患者信息平台', 5, 't', '患者信息平台');

insert into med_permissions_kind (KIND_ID, APP_ID, NAME, SORT_ID, IS_VALID, DESCRIPTION)
values ('5b55fb10-53cb-488d-bc83-63778728a116', 'ANESPERSONAL', '手术申请预约', 1, 't', '手术申请预约');

insert into med_permissions_kind (KIND_ID, APP_ID, NAME, SORT_ID, IS_VALID, DESCRIPTION)
values ('8f95e262-1f6a-4397-ba30-2dcc8ff8b840', 'ANESPERSONAL', '统计查询', 8, 't', '统计查询');

insert into med_permissions_kind (KIND_ID, APP_ID, NAME, SORT_ID, IS_VALID, DESCRIPTION)
values ('c6c4f499-b39d-4dbb-ad78-11aed20c6160', 'ANESPERSONAL', '辅助功能', 9, 't', '辅助功能');

insert into med_permissions_kind (KIND_ID, APP_ID, NAME, SORT_ID, IS_VALID, DESCRIPTION)
values ('caac245f-c18c-4f32-b33d-5fc0d6b8a820', 'ANESPERSONAL', '麻醉医生操作', 2, 't', '麻醉医生操作');

insert into med_permissions_kind (KIND_ID, APP_ID, NAME, SORT_ID, IS_VALID, DESCRIPTION)
values ('d22f35b4-71e8-4555-9c19-ff44fbc2fc78', 'ANESPERSONAL', '手术护理', 3, 't', '手术护理');

insert into med_permissions_kind (KIND_ID, APP_ID, NAME, SORT_ID, IS_VALID, DESCRIPTION)
values ('d76e800c-485c-4bad-909f-60796f595ca5', 'ANESPERSONAL', '接口要求', 10, 't', '接口要求');

insert into med_permissions_kind (KIND_ID, APP_ID, NAME, SORT_ID, IS_VALID, DESCRIPTION)
values ('dd8e9e63-4fc7-454d-b296-80b165d4725d', 'ANESPERSONAL', '医疗文书', 11, 't', '医疗文书');

insert into med_permissions_kind (KIND_ID, APP_ID, NAME, SORT_ID, IS_VALID, DESCRIPTION)
values ('25ed15e5-1a95-4714-9476-b8fc63d7058b', 'ANESPERSONAL', '其它', 12, 't', '其它');
commit;
