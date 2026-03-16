insert into med_applications (APP_ID, med_applications.NAME, med_applications.DESCRIPTION)
values ('CPBMANAGER', '体外循环临床信息系统 V2.0', '灌注工作站2.0');

insert into med_permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('CPBMANAGER-AutoAdd-1000', 'CPBMANAGER', '永久可修改医疗文书', '永久可修改医疗文书', 0, 't', '永久可修改医疗文书');

insert into med_permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('CPBMANAGER-AutoAdd-1001', 'CPBMANAGER', '患者列表浏览', 'Patientlist_bro', 1, 't', '患者列表浏览');
insert into med_permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('CPBMANAGER-AutoAdd-1002', 'CPBMANAGER', '患者列表维护', 'Patientlist_mod', 2, 't', '患者列表维护');

insert into med_permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('CPBMANAGER-AutoAdd-1003', 'CPBMANAGER', '手术信息浏览', 'SurgeryInfo_bro', 3, 't', '手术信息浏览');
insert into med_permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('CPBMANAGER-AutoAdd-1004', 'CPBMANAGER', '手术信息维护', 'SurgeryInfo_mod', 4, 't', '手术信息维护');

insert into med_permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('CPBMANAGER-AutoAdd-1005', 'CPBMANAGER', '大事件', '大事件', 5, 't', '大事件');

insert into med_permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('CPBMANAGER-AutoAdd-1006', 'CPBMANAGER', '急诊维护', 'EmergencyManagement_mod', 6, 't', '急诊');

insert into med_permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('CPBMANAGER-AutoAdd-1007', 'CPBMANAGER', '系统锁定', 'LockSystem_mod', 7, 't', '系统锁定');

insert into med_permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('CPBMANAGER-AutoAdd-1008', 'CPBMANAGER', '模板管理浏览', 'NewModelManager_bro', 8, 't', '模板管理浏览');
insert into med_permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('CPBMANAGER-AutoAdd-1009', 'CPBMANAGER', '模板管理维护', 'NewModelManager_mod', 9, 't', '模板管理维护');

insert into med_permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('CPBMANAGER-AutoAdd-1010', 'CPBMANAGER', '血气分析浏览', 'BloodGasDataEditor_bro', 10, 't', '血气分析浏览');
insert into med_permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('CPBMANAGER-AutoAdd-1011', 'CPBMANAGER', '血气分析维护', 'BloodGasDataEditor_mod', 11, 't', '血气分析维护');

insert into med_permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('CPBMANAGER-AutoAdd-1012', 'CPBMANAGER', '检查检验浏览', 'CheckTestr_bro', 12, 't', '检查检验浏览');
insert into med_permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('CPBMANAGER-AutoAdd-1013', 'CPBMANAGER', '检查检验维护', 'CheckTest_mod', 13, 't', '检查检验维护');

insert into med_permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('CPBMANAGER-AutoAdd-1014', 'CPBMANAGER', '医嘱信息浏览', 'PrescriptionInfo_bro', 14, 't', '医嘱信息浏览');
insert into med_permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('CPBMANAGER-AutoAdd-1015', 'CPBMANAGER', '医嘱信息维护', 'PrescriptionInfo_mod', 15, 't', '医嘱信息维护');

insert into med_permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('CPBMANAGER-AutoAdd-1016', 'CPBMANAGER', '病历病程浏览', 'MedicalCourse_bro', 16, 't', '病历病程浏览');
insert into med_permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('CPBMANAGER-AutoAdd-1017', 'CPBMANAGER', '病历病程维护', 'MedicalCourse_mod', 17, 't', '病历病程维护');


insert into med_permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('CPBMANAGER-AutoAdd-1018', 'CPBMANAGER', '系统配置浏览', 'CPBConfig_bro', 18, 't', '系统配置浏览');
insert into med_permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('CPBMANAGER-AutoAdd-1019', 'CPBMANAGER', '系统配置维护', 'CPBConfig_mod', 19, 't', '系统配置维护');

insert into med_permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('CPBMANAGER-AutoAdd-1020', 'CPBMANAGER', '仪器设置浏览', 'SelectHLM_bro', 20, 't', '仪器设置浏览');
insert into med_permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('CPBMANAGER-AutoAdd-1021', 'CPBMANAGER', '仪器设置维护', 'SelectHLM_mod', 21, 't', '仪器设置维护');

insert into med_permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('CPBMANAGER-AutoAdd-1022', 'CPBMANAGER', '字典配置浏览', 'CPBDict_bro', 22, 't', '字典配置浏览');
insert into med_permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('CPBMANAGER-AutoAdd-1023', 'CPBMANAGER', '字典配置维护', 'CPBDict_mod', 23, 't', '字典配置维护');

insert into med_permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('CPBMANAGER-AutoAdd-1024', 'CPBMANAGER', '转中登记浏览', 'CPBEventEdit_bro', 24, 't', '转中登记浏览');
insert into med_permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('CPBMANAGER-AutoAdd-1025', 'CPBMANAGER', '转中登记维护', 'CPBEventEdit_mod', 25, 't', '转中登记维护');

insert into med_permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('CPBMANAGER-AutoAdd-1026', 'CPBMANAGER', '灌注前记录单浏览', 'CPBPreRecordt_bro', 26, 't', '灌注前记录单浏览');
insert into med_permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('CPBMANAGER-AutoAdd-1027', 'CPBMANAGER', '灌注前记录单维护', 'CPBPreRecord_mod', 27, 't', '灌注前记录单维护');

insert into med_permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('CPBMANAGER-AutoAdd-1028', 'CPBMANAGER', '灌注报告单浏览', 'CPBReport_bro', 28, 't', '体外循环报告单浏览');
insert into med_permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('CPBMANAGER-AutoAdd-1029', 'CPBMANAGER', '灌注报告单维护', 'CPBReport_mod', 29, 't', '体外循环报告单浏览');


