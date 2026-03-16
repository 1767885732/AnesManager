
--删除原来的字典表-重新初始化字典表
delete from med_blood_gas_dict;
insert into med_blood_gas_dict (BLG_CODE, BLG_NAME, BLG_SHOWID, BLG_UNIT, BLG_REFER_VALUE, BLG_STATUS, BLG_INPUT_CODE, BLG_ATTR_CODE, BLG_ITEM_ID)
values ('BE(B)', 'BE(B)', 1, 'mMol/L', '-25.0~25.0', '1', 'BE(B)', 'SBE|BE(B)|', 1034);

insert into med_blood_gas_dict (BLG_CODE, BLG_NAME, BLG_SHOWID, BLG_UNIT, BLG_REFER_VALUE, BLG_STATUS, BLG_INPUT_CODE, BLG_ATTR_CODE, BLG_ITEM_ID)
values ('BEecf', 'BEecf', 2, 'mMol/L', '-3~+3', '1', 'BEecf', 'BEecf|BE-ecf^|', 1017);

insert into med_blood_gas_dict (BLG_CODE, BLG_NAME, BLG_SHOWID, BLG_UNIT, BLG_REFER_VALUE, BLG_STATUS, BLG_INPUT_CODE, BLG_ATTR_CODE, BLG_ITEM_ID)
values ('Ca++', 'Ca++', 3, 'mMol/L', '0.25 ~ 5.00', '1', 'Ca++', 'Ca++|^Ca^|ICA^|', 1007);

insert into med_blood_gas_dict (BLG_CODE, BLG_NAME, BLG_SHOWID, BLG_UNIT, BLG_REFER_VALUE, BLG_STATUS, BLG_INPUT_CODE, BLG_ATTR_CODE, BLG_ITEM_ID)
values ('Ca++(7.4)', 'Ca++(7.4)', 4, 'mMol/L', '0.22 ~ 5.58', '1', 'Ca++(7.4)', 'Ca++(7.4)|', 1027);

insert into med_blood_gas_dict (BLG_CODE, BLG_NAME, BLG_SHOWID, BLG_UNIT, BLG_REFER_VALUE, BLG_STATUS, BLG_INPUT_CODE, BLG_ATTR_CODE, BLG_ITEM_ID)
values ('Glu', 'Glu', 5, 'mMol/L', '3.9~6.1', '1', 'Glu', 'Glu|', 1032);

insert into med_blood_gas_dict (BLG_CODE, BLG_NAME, BLG_SHOWID, BLG_UNIT, BLG_REFER_VALUE, BLG_STATUS, BLG_INPUT_CODE, BLG_ATTR_CODE, BLG_ITEM_ID)
values ('HCO3-', 'HCO3-', 6, 'mMol/L', '18~23', '1', 'HCO3-', 'HCO3-|HCO3^|', 1031);

insert into med_blood_gas_dict (BLG_CODE, BLG_NAME, BLG_SHOWID, BLG_UNIT, BLG_REFER_VALUE, BLG_STATUS, BLG_INPUT_CODE, BLG_ATTR_CODE, BLG_ITEM_ID)
values ('HCO3std', 'HCO3std', 7, 'mMol/L ', '21.4~27.3', '1', 'HCO3std', 'HCO3std|SBC|', 1005);

insert into med_blood_gas_dict (BLG_CODE, BLG_NAME, BLG_SHOWID, BLG_UNIT, BLG_REFER_VALUE, BLG_STATUS, BLG_INPUT_CODE, BLG_ATTR_CODE, BLG_ITEM_ID)
values ('Hct', 'Hct', 8, '%', '10 ~ 70', '1', 'Hct', 'Hct|', 1021);

insert into med_blood_gas_dict (BLG_CODE, BLG_NAME, BLG_SHOWID, BLG_UNIT, BLG_REFER_VALUE, BLG_STATUS, BLG_INPUT_CODE, BLG_ATTR_CODE, BLG_ITEM_ID)
values ('K+', 'K+', 9, 'mMol/L ', '1.0~20.0', '1', 'K+', 'K+|^K^|', 1008);

insert into med_blood_gas_dict (BLG_CODE, BLG_NAME, BLG_SHOWID, BLG_UNIT, BLG_REFER_VALUE, BLG_STATUS, BLG_INPUT_CODE, BLG_ATTR_CODE, BLG_ITEM_ID)
values ('Lac', 'Lac', 10, 'mMol/L ', '0.5~1.78', '1', 'Lac', 'Lac|', 1033);

insert into med_blood_gas_dict (BLG_CODE, BLG_NAME, BLG_SHOWID, BLG_UNIT, BLG_REFER_VALUE, BLG_STATUS, BLG_INPUT_CODE, BLG_ATTR_CODE, BLG_ITEM_ID)
values ('Na+', 'Na+', 11, 'mMol/L ', '80~200', '1', 'Na+', 'Na+|^NA^|', 1009);

insert into med_blood_gas_dict (BLG_CODE, BLG_NAME, BLG_SHOWID, BLG_UNIT, BLG_REFER_VALUE, BLG_STATUS, BLG_INPUT_CODE, BLG_ATTR_CODE, BLG_ITEM_ID)
values ('SO2c', 'SO2c', 12, '%', '40.0 ~100.0', '1', 'SO2c', 'sO2|', 1011);

insert into med_blood_gas_dict (BLG_CODE, BLG_NAME, BLG_SHOWID, BLG_UNIT, BLG_REFER_VALUE, BLG_STATUS, BLG_INPUT_CODE, BLG_ATTR_CODE, BLG_ITEM_ID)
values ('TCO2', 'TCO2', 13, 'mMol/L', '19~24', '1', 'TCO2', 'TCO2|', 1018);

insert into med_blood_gas_dict (BLG_CODE, BLG_NAME, BLG_SHOWID, BLG_UNIT, BLG_REFER_VALUE, BLG_STATUS, BLG_INPUT_CODE, BLG_ATTR_CODE, BLG_ITEM_ID)
values ('THbc', 'THbc', 14, 'g/dL', '12~17.5', '1', 'THbc', 'tHb|', 1035);

insert into med_blood_gas_dict (BLG_CODE, BLG_NAME, BLG_SHOWID, BLG_UNIT, BLG_REFER_VALUE, BLG_STATUS, BLG_INPUT_CODE, BLG_ATTR_CODE, BLG_ITEM_ID)
values ('Temp', 'Temp', 15, 'C', '20~ 45', '1', 'Temp', 'Temp|^T^|', 1012);

insert into med_blood_gas_dict (BLG_CODE, BLG_NAME, BLG_SHOWID, BLG_UNIT, BLG_REFER_VALUE, BLG_STATUS, BLG_INPUT_CODE, BLG_ATTR_CODE, BLG_ITEM_ID)
values ('pCO2', 'pCO2', 16, 'mMol/L', '35~45', '1', 'pCO2', 'pCO2|pCO2(T)|', 1002);

insert into med_blood_gas_dict (BLG_CODE, BLG_NAME, BLG_SHOWID, BLG_UNIT, BLG_REFER_VALUE, BLG_STATUS, BLG_INPUT_CODE, BLG_ATTR_CODE, BLG_ITEM_ID)
values ('pH', 'pH', 17, '', '7.35~7.45 ', '1', 'pH',  'pH^|pH(T)|^pH|', 1004);

insert into med_blood_gas_dict (BLG_CODE, BLG_NAME, BLG_SHOWID, BLG_UNIT, BLG_REFER_VALUE, BLG_STATUS, BLG_INPUT_CODE, BLG_ATTR_CODE, BLG_ITEM_ID)
values ('pO2', 'pO2', 18, 'mMol/L', '80~105', '1', 'pO2', 'pO2|pO2(T)|', 1001);

insert into med_blood_gas_dict (BLG_CODE, BLG_NAME, BLG_SHOWID, BLG_UNIT, BLG_REFER_VALUE, BLG_STATUS, BLG_INPUT_CODE, BLG_ATTR_CODE, BLG_ITEM_ID)
values ('Cl-', 'Cl-', 19, 'mmol/L', '', '1', 'Cl-', 'Cl^|Cl-|', 1003);

insert into med_blood_gas_dict (BLG_CODE, BLG_NAME, BLG_SHOWID, BLG_UNIT, BLG_REFER_VALUE, BLG_STATUS, BLG_INPUT_CODE, BLG_ATTR_CODE, BLG_ITEM_ID)
values ('FIO2', 'FIO2', 19, '%', '', '1', 'FIO2', '^FIO2|', 1013);

insert into med_blood_gas_dict (BLG_CODE, BLG_NAME, BLG_SHOWID, BLG_UNIT, BLG_REFER_VALUE, BLG_STATUS, BLG_INPUT_CODE, BLG_ATTR_CODE, BLG_ITEM_ID)
values ('p50', 'p50', 20, 'mmHg', '', '1', 'p50', 'p50(act)|', 1023);

insert into med_blood_gas_dict (BLG_CODE, BLG_NAME, BLG_SHOWID, BLG_UNIT, BLG_REFER_VALUE, BLG_STATUS, BLG_INPUT_CODE, BLG_ATTR_CODE, BLG_ITEM_ID)
values ('AaDpO2', 'AaDpO2', 21, 'mmHg', '', '1', 'AaDpO2', 'AaDpO2|', 1024);

insert into med_blood_gas_dict (BLG_CODE, BLG_NAME, BLG_SHOWID, BLG_UNIT, BLG_REFER_VALUE, BLG_STATUS, BLG_INPUT_CODE, BLG_ATTR_CODE, BLG_ITEM_ID)
values ('a/ApO2', 'a/ApO2', 22, 'mmHg', '', '1', 'a/ApO2', 'a/ApO2|', 1025);

insert into med_blood_gas_dict (BLG_CODE, BLG_NAME, BLG_SHOWID, BLG_UNIT, BLG_REFER_VALUE, BLG_STATUS, BLG_INPUT_CODE, BLG_ATTR_CODE, BLG_ITEM_ID)
values ('tO2', 'tO2', 23, 'Vol%', '', '1', 'tO2', 'tO2|', 1026);

insert into med_blood_gas_dict (BLG_CODE, BLG_NAME, BLG_SHOWID, BLG_UNIT, BLG_REFER_VALUE, BLG_STATUS, BLG_INPUT_CODE, BLG_ATTR_CODE, BLG_ITEM_ID)
values ('Anion gap (K+)', 'Anion gap (K+)', 24, 'mmol/L', '', '1', 'Anion gap (K+)', 'Anion gap (K+)|', 1028);

insert into med_blood_gas_dict (BLG_CODE, BLG_NAME, BLG_SHOWID, BLG_UNIT, BLG_REFER_VALUE, BLG_STATUS, BLG_INPUT_CODE, BLG_ATTR_CODE, BLG_ITEM_ID)
values ('O2Hb', 'O2Hb', 25, '%', '', '1', 'O2Hb', 'O2Hb|', 1030);

insert into med_blood_gas_dict (BLG_CODE, BLG_NAME, BLG_SHOWID, BLG_UNIT, BLG_REFER_VALUE, BLG_STATUS, BLG_INPUT_CODE, BLG_ATTR_CODE, BLG_ITEM_ID)
values ('COHb', 'COHb', 26, '%', '', '1', 'COHb', 'COHb|', 1036);

insert into med_blood_gas_dict (BLG_CODE, BLG_NAME, BLG_SHOWID, BLG_UNIT, BLG_REFER_VALUE, BLG_STATUS, BLG_INPUT_CODE, BLG_ATTR_CODE, BLG_ITEM_ID)
values ('HHb', 'HHb', 27, '%', '', '1', 'HHb', 'HHb|', 1037);

insert into med_blood_gas_dict (BLG_CODE, BLG_NAME, BLG_SHOWID, BLG_UNIT, BLG_REFER_VALUE, BLG_STATUS, BLG_INPUT_CODE, BLG_ATTR_CODE, BLG_ITEM_ID)
values ('MetHb', 'MetHb', 28, '%', '', '1', 'MetHb', 'MetHb|', 1038);

insert into med_blood_gas_dict (BLG_CODE, BLG_NAME, BLG_SHOWID, BLG_UNIT, BLG_REFER_VALUE, BLG_STATUS, BLG_INPUT_CODE, BLG_ATTR_CODE, BLG_ITEM_ID)
values ('ABE', 'ABE', 29, 'mmol/L', '', '1', 'ABE', 'ABE|', 1039);

insert into med_blood_gas_dict (BLG_CODE, BLG_NAME, BLG_SHOWID, BLG_UNIT, BLG_REFER_VALUE, BLG_STATUS, BLG_INPUT_CODE, BLG_ATTR_CODE, BLG_ITEM_ID)
values ('Mg++', 'Mg++', 30, 'mmol/L', '', '1', 'Mg++', 'Mg++|', 1045);

insert into med_blood_gas_dict (BLG_CODE, BLG_NAME, BLG_SHOWID, BLG_UNIT, BLG_REFER_VALUE, BLG_STATUS, BLG_INPUT_CODE, BLG_ATTR_CODE, BLG_ITEM_ID)
values ('Hb', 'Hb', 31, 'g/dL', '', '1', 'Hb', '^Hb^|', 1046);

insert into med_blood_gas_dict (BLG_CODE, BLG_NAME, BLG_SHOWID, BLG_UNIT, BLG_REFER_VALUE, BLG_STATUS, BLG_INPUT_CODE, BLG_ATTR_CODE, BLG_ITEM_ID)
values ('BUN', 'BUN', 32, 'mg/dL', '', '1', 'BUN', 'BUN|', 1047);

insert into med_blood_gas_dict (BLG_CODE, BLG_NAME, BLG_SHOWID, BLG_UNIT, BLG_REFER_VALUE, BLG_STATUS, BLG_INPUT_CODE, BLG_ATTR_CODE, BLG_ITEM_ID)
values ('BE', 'BE', 33, 'mmol/L', '', '1', 'BE', '^BE^|', 1050);

insert into med_blood_gas_dict (BLG_CODE, BLG_NAME, BLG_SHOWID, BLG_UNIT, BLG_REFER_VALUE, BLG_STATUS, BLG_INPUT_CODE, BLG_ATTR_CODE, BLG_ITEM_ID)
values ('BB', 'BB', 34, 'mmol/L', '', '1', 'BB', '^BB^|', 1053);
