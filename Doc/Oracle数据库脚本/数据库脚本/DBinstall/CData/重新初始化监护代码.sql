
--删除原来的字典表-重新初始化字典表
delete from med_monitor_function_code;

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (40, '心率', '40', 'bpm', 65280, '4', '●', '1', 1, '心率', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (44, 'PULSE', '44', 'bpm', 32768, '4', '●', '1', 1, 'Pulse rate f. press.', '', '脉搏', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (49, '收缩压', '49', 'mmHg', 255, '1', '∨', '1', 1, '压力1/收缩期', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (50, '舒张压', '50', 'mmHg', 255, '2', '∧', '1', 1, '压力1/舒张期', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (51, '平均压', '51', 'mmHg', 0, '7', '△', '0', 1, '压力1/平均', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (53, '收缩压', '53', 'mmHg', 255, '1', '∨', '0', 1, '压力2/收缩期', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (54, '舒张压', '54', 'mmHg', 255, '2', '∧', '0', 1, '压力2/舒张期', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (55, '平均压', '55', 'mmHg', 0, '7', '△', '0', 1, '压力2/平均', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (57, '收缩压', '57', 'mmHg', 255, '1', '∨', '0', 1, '压力3/收缩期', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (58, '舒张压', '58', 'mmHg', 255, '2', '∧', '0', 1, '压力3/舒张期', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (59, '平均压', '59', 'mmHg', 0, '7', '△', '0', 1, '压力3/平均', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (61, '收缩压', '61', 'mmHg', 255, '1', '∨', '0', 1, '压力4/收缩期', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (62, '舒张压', '62', 'mmHg', 255, '2', '∧', '0', 1, '压力4/舒张期', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (63, '平均压', '63', 'mmHg', 0, '7', '△', '0', 1, '压力4/平均', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (65, '动脉收缩压', '65', 'mmHg', 16711680, '1', '∨', '1', 2, '动脉收缩压ARTs', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (66, '动脉舒张压', '66', 'mmHg', 16711680, '2', '∧', '1', 2, '动脉舒张压ARTd', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (67, '动脉平均压', '67', 'mmHg', 16711680, '7', '△', '0', 2, '动脉压平均ARTm', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (69, '收缩压', '69', 'mmHg', 255, '1', '∨', '0', 3, '中心静脉收缩压', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (70, '舒张压', '70', 'mmHg', 255, '2', '∧', '0', 3, '中心静脉舒张压', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (71, '中心静脉压', '71', 'mmHg', 65535, '7', '△', '1', 3, '中心静脉平均压', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (73, '左房收缩压', '73', 'mmHg', 255, '1', '∨', '0', 4, '左房收缩压LAPs', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (74, '左房舒张压', '74', 'mmHg', 255, '2', '∧', '0', 4, '左房舒张压LAPd', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (75, '左房平均压', '75', 'mmHg', 0, '7', '△', '0', 4, '左房平均压LAPm', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (77, '肺动脉收缩压', '77', 'mmHg', 16711680, '1', '∨', '1', 5, '肺动脉收缩压PAs', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (78, '肺动脉舒张压', '78', 'mmHg', 16711680, '2', '∧', '1', 5, '肺动脉舒张压PAd', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (79, '肺动脉平均压', '79', 'mmHg', 0, '7', '△', '0', 5, '肺动脉平均压PAm', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (81, '颅内收缩压', '81', 'mmHg', 255, '1', '∨', '0', 6, '颅内收缩压ICPs', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (82, '颅内舒张压', '82', 'mmHg', 255, '2', '∧', '0', 6, '颅内舒张压ICPd', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (83, '颅内平均压', '83', 'mmHg', 0, '7', '△', '0', 6, '颅内平均压ICPm', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (85, '宫内收缩压', '85', 'mmHg', 255, '1', '∨', '0', 7, '宫内收缩压', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (86, '宫内舒张压', '86', 'mmHg', 255, '2', '∧', '0', 7, '宫内舒张压', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (87, '宫内平均压', '87', 'mmHg', 0, '7', '△', '0', 7, '宫内平均压', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (89, '收缩压', '89', 'mmHg', 255, '1', '∨', '1', 1, '无创收缩压', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (90, '舒张压', '90', 'mmHg', 255, '2', '∧', '1', 1, '无创舒张压', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (91, '平均压', '91', 'mmHg', 0, '7', '△', '0', 1, '无创平均压', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (92, '呼吸', '92', 'l/min', 65280, '3', '○', '1', 1, '呼吸频率', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (93, '收缩压', '93', 'mmHg', 255, '1', '∨', '0', 1, '压力5/收缩期', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (94, '舒张压', '94', 'mmHg', 255, '2', '∧', '0', 1, '压力5/舒张期', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (95, '平均压', '95', 'mmHg', 0, '7', '△', '0', 1, '压力5/平均', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (96, 'AWRR', '96', 'l/min', 0, '7', '△', '0', 2, '气道呼吸频率', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (97, '收缩压', '97', 'mmHg', 255, '1', '∨', '0', 1, '压力6/收缩期', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (98, '舒张压', '98', 'mmHg', 255, '2', '∧', '0', 1, '压力6/舒张期', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (99, '平均压', '99', 'mmHg', 0, '7', '△', '0', 1, '压力6/平均', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (100, '体温', '100', '℃', 16711680, '5', '×', '1', 1, '温度', '', '', null, 1, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (104, '直肠温', '104', '℃', 0, '5', '×', '1', 1, '直肠温', '', '', null, 1, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (105, '鼻温', '105', '℃', 0, '5', '×', '1', 1, '鼻温', '', '', null, 1, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (106, '皮肤温', '106', '℃', 0, '5', '×', '1', 1, '皮肤温', '', '', null, 1, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (107, '食道温', '107', '℃', 0, '5', '×', '1', 1, '食道温', '', '', null, 1, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (112, 'ETCO2', '112', 'mmHg', 0, '7', '△', '1', 1, '潮气末CO2', '麻醉呼吸', '', 0, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (115, 'InCO2%', '115', '%', 0, '7', '△', '1', 1, '呼入CO2浓度', '麻醉呼吸', '', 0, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (116, 'IMCO2', '116', 'mmHg', 0, '7', '△', '0', 1, '最小吸入CO2', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (120, 'CPCO2', '120', 'mmHg', 0, '7', '△', '0', 1, '体表测定的二氧化碳分压', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (124, 'C.O.', '124', 'l/min', 0, '7', '△', '1', 1, '心输出量', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (128, 'PAWP', '128', 'mmHg', 0, '7', '△', '1', 1, '肺动脉楔压', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (132, 'TBlood', '132', '℃', 0, '5', '×', '1', 3, '血液温度', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (136, 'VPB', '136', 'l/min', 0, '7', '△', '0', 1, '室早率', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (148, 'FIO2', '148', '%', 0, '7', '△', '0', 1, '吸入氧浓度', '麻醉呼吸', '', 0, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (152, 'CPO2', '152', 'mmHg', 0, '7', '△', '0', 1, '体表测定的氧分压', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (161, '动脉收缩压', '161', 'mmHg', 255, '1', '∨', '1', 2, '动脉收缩压ABPs', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (162, '动脉舒张压', '162', 'mmHg', 255, '2', '∧', '1', 2, '动脉舒张压ABPd', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (163, '动脉平均压', '163', 'mmHg', 0, '7', '△', '0', 2, '平均动脉压ABPm', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (165, '右房收缩压', '165', 'mmHg', 255, '1', '∨', '1', 8, '右房收缩压RAPs', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (166, '右房舒张压', '166', 'mmHg', 255, '2', '∧', '1', 8, '右房舒张压RAPd', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (167, '右房平均压', '167', 'mmHg', 0, '7', '△', '0', 8, '右房平均压RAPm', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (169, '主动脉收缩压', '169', 'mmHg', 255, '1', '∨', '1', 9, '主动脉收缩压AOs', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (170, '主动脉舒张压', '170', 'mmHg', 255, '2', '∧', '1', 9, '主动脉舒张压AOs', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (171, '主动脉平均压', '171', 'mmHg', 0, '7', '△', '0', 9, '主动脉平均压AOm', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (172, 'T1-T2', '172', '℃', 0, '7', '△', '1', 1, '温度差 (T1-T2)', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (173, '右室收缩压', '173', 'mmHg', 255, '1', '∨', '1', 8, '右室收缩压RVPs', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (174, '右室舒张压', '174', 'mmHg', 255, '2', '∧', '1', 8, '右室舒张压RVPd', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (175, '右室平均压', '175', 'mmHg', 0, '7', '△', '0', 8, '右室平均压RVPm', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (176, '静脉收缩压', '176', 'mmHg', 255, '1', '∨', '1', 8, '静脉收缩压', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (177, '静脉舒张压', '177', 'mmHg', 255, '2', '∧', '1', 8, '静脉舒张压', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (178, '静脉平均压', '178', 'mmHg', 0, '7', '△', '0', 8, '静脉平均压', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (180, 'AUX', '180', '', 0, '7', '△', '0', 1, 'Auxiliary par. num.', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (184, 'ST1', '184', 'mm', 0, '7', '△', '0', 1, 'ST1', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (188, 'SpO2', '188', '%', 65280, '6', '●', '0', 1, 'SpO2', '', '血氧饱和度', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (192, 'SvO2', '192', '%', 0, '7', '△', '0', 1, 'SvO2', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (196, 'ST2', '196', 'mm', 0, '7', '△', '0', 1, 'ST2', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (200, 'ST3', '200', 'mm', 0, '7', '△', '0', 1, 'ST3', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (202, 'f', '202', 'b/min', 0, '7', '△', '0', 1, '控制呼吸频率', '呼吸机', '', 0, 1, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (203, '自主呼吸频率', '203', 'b/min', 0, '7', '△', '0', 1, '呼吸机的自主呼吸频率', '呼吸机', '', 0, 1, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (204, '吸入气温', '204', '℃', 0, '7', '△', '0', 1, '吸入气温', '呼吸机', '', 0, 1, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (205, 'I:E', '205', '', 0, '7', '△', '0', 1, '吸呼比', '呼吸机', '', 1, 1, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (206, '呼吸模式', '206', '', 0, '7', '△', '0', 1, '呼吸模式', '呼吸机', '', 1, 1, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (207, 'Pmin', '207', 'cmH2O', 0, '7', '△', '0', 1, '气道最低压', '呼吸机', '', 0, 1, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (208, 'Ppeak', '208', 'cmH2O', 0, '7', '△', '0', 1, '气道压峰值', '呼吸机', '', 0, 1, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (209, 'Pplat', '209', 'cmH2O', 0, '7', '△', '0', 1, '吸气平台压', '呼吸机', '', 0, 1, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (210, 'Pmean', '210', 'cmH2O', 0, '7', '△', '0', 1, '气道平均压', '呼吸机', '', 0, 1, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (211, 'PEEP', '211', 'cmH2O', 0, '7', '△', '0', 1, '呼气末正压', '呼吸机', '', 0, 1, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (212, 'TVE', '212', 'ml', 0, '7', '△', '0', 1, '潮气量', '呼吸机', '', 0, 1, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (213, 'Pinsp', '213', 'cmH2O', 0, '7', '△', '0', 1, '吸气压', '呼吸机', '', 0, 1, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (214, 'Pasb', '214', 'cmH2O', 0, '7', '△', '0', 1, 'Pasb', '呼吸机', '', 0, 1, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (215, 'CompL', '215', 'ml/cmH2O', 0, '7', '△', '0', 1, '肺顺应性', '呼吸机', '', 0, 1, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (216, 'Resist', '216', 'cmH2O', 0, '7', '△', '0', 1, '气道阻力', '呼吸机', '', 0, 1, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (217, '实测潮气量', '217', 'ml', 0, '7', '△', '0', 1, '实测潮气量', '呼吸机', '', null, null, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (218, '实测PEEP', '218', 'cmH2O', 0, '7', '△', '0', 1, '实测PEEP', '呼吸机', '', null, null, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (220, 'CCO', '220', 'l/min', 0, '7', '△', '0', 1, '连续心输出量', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (228, 'BIS', '228', '', 32768, '7', '●', '1', 3, 'BIS', '', '', null, null, null, null, 2, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (252, 'CPP', '252', 'mmHg', 0, '7', '△', '0', 1, '脑灌注压', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (256, 'AaDO2', '256', 'mmHg', 0, '7', '△', '0', 1, '肺泡、动脉氧含量差', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (260, 'ALVENT', '260', 'ml/min', 0, '7', '△', '0', 1, '肺泡通气量', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (264, 'avDO2', '264', 'ml/dl', 0, '7', '△', '0', 1, '动静脉O2含量差', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (268, 'BUN', '268', 'mg/dl', 0, '7', '△', '0', 1, '血尿素氮', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (272, 'BUN_Cr', '272', '', 0, '7', '△', '0', 1, '尿素氮肌酐比', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (276, 'CaO2', '276', 'ml/dl', 0, '7', '△', '0', 1, '动脉氧含量', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (280, 'CH2O', '280', 'ml/24h', 0, '7', '△', '0', 1, '自由水清除率', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (284, 'COMP', '284', 'ml/cmH2O', 0, '7', '△', '0', 1, '顺应性', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (288, 'COsm', '288', 'ml/24h', 0, '7', '△', '0', 1, '渗透清除率', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (292, 'CrCl', '292', 'ml/min/m', 0, '7', '△', '0', 1, '肌酐清除率', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (296, 'CvO2', '296', 'ml/dl', 0, '7', '△', '0', 1, '静脉氧含量', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (300, 'FeNa', '300', '%', 0, '7', '△', '0', 1, '钠排泄分数', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (304, '身高', '304', 'cm', 0, '', '', '0', 1, '身高', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (308, 'HGB', '308', 'g/dl', 0, '7', '△', '0', 1, '血红蛋白', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (316, 'LCW', '316', 'kg-m', 0, '7', '△', '0', 1, '左心功', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (317, 'LCWI', '317', 'kg-m/m2', 0, '7', '△', '0', 1, '左心功指数', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (320, 'LVSW', '320', 'g-m', 0, '7', '△', '0', 1, '左室每搏功', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (321, 'LVSWI', '321', 'g-m/m2', 0, '7', '△', '0', 1, '左室每搏功指数', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (324, 'VE', '324', 'l/min', 0, '7', '△', '0', 1, '每分通气量', '呼吸机', '', 0, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (325, 'PC', '325', 'cmH2O', 0, '7', '△', '0', 1, 'PC', '呼吸机', '', null, null, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (326, 'PS', '326', 'cmH2O', 0, '7', '△', '0', 1, 'Pressure Support', '呼吸机', '', null, null, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (327, 'Pressure Trigger', '327', 'cmH2O', 0, '7', '△', '0', 1, 'Pressure Trigger', '呼吸机', '', null, null, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (328, 'v-trigger', '328', 'cmH2O', 0, '7', '△', '0', 1, 'v-trigger', '呼吸机', '', null, null, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (329, 'SIMV频率', '329', 'b/min', 0, '7', '△', '0', 1, 'SIMV频率', '呼吸机', '', 0, 1, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (332, 'O2ER', '332', 'ml/min/m', 0, '7', '△', '0', 1, 'O2摄取率', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (336, 'PaCO2', '336', 'mmHg', 0, '7', '△', '0', 1, '二氧化碳分压', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (340, 'PB', '340', 'mmHg', 0, '7', '△', '0', 1, '大气压', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (344, 'PECO2', '344', 'mmHg', 0, '7', '△', '0', 1, '呼出CO2分压', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (348, 'PEEP', '348', 'cmH2O', 0, '7', '△', '0', 1, '呼气末正压', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (356, 'PlOsm', '356', 'mOsm/l', 0, '7', '△', '0', 1, '血浆渗透压', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (360, 'PvO2', '360', 'mmHg', 0, '7', '△', '0', 1, '静脉O2分压', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (364, 'PVR', '364', 'DS/cm5', 0, '', '', '0', 1, '肺血管阻力', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (365, 'PVRI', '365', 'DSm2/cm5', 0, '', '', '0', 0, '外周血管阻力指数', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (368, 'Qs/Qt', '368', '%', 0, '', '', '0', 0, '动静脉分流率', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (372, 'RCW', '372', 'kg-m', 0, '', '', '0', 0, '右心功', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (373, 'RCWI', '373', 'kg-m/m2', 0, '', '', '0', 0, '右心功指数', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (376, 'RVSW', '376', 'g-m', 0, '', '', '0', 0, '右室每搏功', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (377, 'RVSWI', '377', 'g-m/m2', 0, '', '', '0', 0, '右室每搏功指数', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (384, 'SCreat', '384', 'mg/dl', 0, '', '', '0', 0, '血清肌酐', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (388, 'SerNa', '388', 'mg/dl', 0, '', '', '0', 0, '血清钠', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (392, 'SV', '392', 'ml', 0, '', '', '0', 0, '每搏输出量', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (393, 'SI', '393', 'ml/m?0', null, '', '0', '0', null, '', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (400, 'SVR', '400', 'DS/cm5', 0, '', '', '0', 0, '体循环阻力', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (408, 'U_POsm', '408', '', 0, '', '', '0', 0, '尿血浆渗透压比', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (412, 'U_SCr', '412', '', 0, '', '', '0', 0, '尿肌酐清除率', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (416, 'UCreat', '416', 'mmol/l', 0, '', '', '0', 0, '尿肌酐', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (420, 'UrK', '420', 'mEq', 0, '', '', '0', 0, '尿钾', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (424, 'UrKEx', '424', 'mEq/24h', 0, '', '', '0', 0, '尿钾排泄率', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (428, 'UrNa', '428', 'mEq', 0, '', '', '0', 0, '尿钠', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (432, 'UrNa/K', '432', '', 0, '', '', '0', 0, '尿钠/钾比', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (433, 'RE', '433', '', 32768, '4', '●', '1', 3, '反应熵', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (434, 'BIS', '434', '', 32768, '7', '●', '1', 3, 'BIS', '', '', null, null, null, null, 2, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (435, 'SE', '435', '', 32768, '4', '●', '1', 3, '状态熵', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (436, 'UrNaEx', '436', 'mEq', 0, '', '', '0', 0, '尿钠排泄率', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (440, 'UrOsm', '440', 'mOsm/l', 0, '', '', '0', 0, '尿渗透压', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (444, 'UrVol', '444', 'ml', 0, '', '', '0', 0, '尿量', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (448, 'Vd', '448', 'ml', 0, '7', '△', '0', 1, '死腔', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (452, 'Vd/Vt', '452', '', 0, '7', '△', '0', 1, '死腔/潮气量', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (456, 'VO2', '456', 'ml/min', 0, '7', '△', '0', 1, '耗氧量', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (460, '体重', '460', 'kg', 0, '', '', '0', 0, '体重', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (464, 'PaO2', '464', 'mmHg', 0, '7', '△', '0', 1, '氧分压', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (472, '体表面积', '472', 'm2', 0, '', '', '0', 0, '体表面积', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (500, 'O2AVI', '500', 'ml/min/m', 0, '7', '△', '0', 1, 'O2利用率指数', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (501, 'O2AV', '501', 'ml/min', 0, '7', '△', '0', 1, 'O2利用率', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (502, '体积描记图', '502', 'bpm', 0, '7', '△', '0', 1, '体积描记图', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (512, 'PERF', '512', '', 0, '7', '△', '0', 0, 'DAP Internal Source (CS:', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (552, 'C.I.', '552', '', 0, '7', 'O', '0', null, '', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (584, 'SVRI', '584', 'DSm2/cm5', 0, '7', '△', '0', 0, '体循环阻力指数', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (588, 'VO2I', '588', '', 0, '7', '△', '0', 0, '耗氧量指数', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (600, 'Sat', '600', '%', 0, '7', '', '1', null, '', '血氧分析', '', null, null, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (601, 'pO2', '601', 'mmHg', 0, '7', '', '1', null, '', '血氧分析', '', null, null, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (602, 'Hct', '602', '%', 0, '7', '', '1', null, '', '血氧分析', '', null, null, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (603, 'Temp.1', '603', '℃', 0, '7', '', '1', null, '', '血氧分析', '', null, null, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (604, 'Temp.2', '604', '℃', 0, '7', '', '1', null, '', '血氧分析', '', null, null, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (605, 'Aux.T.', '605', '℃', 0, '7', '', '1', null, '', '血氧分析', '', null, null, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (800, '泵1流速', '800', 'L/min', 0, '7', '', '1', null, '', '体外循环', '', null, null, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (801, '泵2流速', '801', 'L/min', 0, '7', '', '1', null, '', '体外循环', '', null, null, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (802, '泵3A流速', '802', 'L/min', 0, '7', '', '1', null, '', '体外循环', '', null, null, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (803, '泵3B流速', '803', 'L/min', 0, '7', '', '1', null, '', '体外循环', '', null, null, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (804, '泵4A流速', '804', 'L/min', 0, '7', '', '1', null, '', '体外循环', '', null, null, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (805, '泵4B流速', '805', 'L/min', 0, '7', '', '1', null, '', '体外循环', '', null, null, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (806, '泵1转速', '806', 'rpm', 0, '7', '', '1', null, '', '体外循环', '', null, null, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (807, '泵2转速', '807', 'rpm', 0, '7', '', '1', null, '', '体外循环', '', null, null, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (808, '泵3A转速', '808', 'rpm', 0, '7', '', '1', null, '', '体外循环', '', null, null, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (809, '泵3B转速', '809', 'rpm', 0, '7', '', '1', null, '', '体外循环', '', null, null, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (810, '泵4A转速', '810', 'rpm', 0, '7', '', '1', null, '', '体外循环', '', null, null, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (811, '泵4B转速', '811', 'rpm', 0, '7', '', '1', null, '', '体外循环', '', null, null, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (812, '1号计时器', '812', 'Sec', 0, '7', '', '1', null, '', '体外循环', '', null, null, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (813, '2号计时器', '813', 'Sec', 0, '7', '', '1', null, '', '体外循环', '', null, null, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (814, '3号计时器', '814', 'Sec', 0, '7', '', '1', null, '', '体外循环', '', null, null, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (815, '4号计时器', '815', 'Sec', 0, '7', '', '1', null, '', '体外循环', '', null, null, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (816, '5号定时器', '816', 'Sec', 0, '7', '', '1', null, '', '体外循环', '', null, null, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (817, '6号计时器', '817', 'Sec', 0, '7', '', '1', null, '', '体外循环', '', null, null, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (818, '压力1', '818', 'mmHg', 0, '7', '', '1', null, '', '体外循环', '', null, null, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (819, '压力2', '819', 'mmHg', 0, '7', '', '1', null, '', '体外循环', '', null, null, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (820, '平均动脉压', '820', 'mmHg', 0, '7', '', '1', null, '', '体外循环', '', null, null, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (821, '灌注压', '821', 'mmHg', 0, '7', '', '1', null, '', '体外循环', '', null, null, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (822, '灌注总量', '822', 'L', 0, '7', '', '1', null, '', '体外循环', '', null, null, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (823, '每次灌注量', '823', 'L', 0, '7', '', '1', null, '', '体外循环', '', null, null, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (824, '温度', '824', '℃', 0, '7', '', '1', null, '', '体外循环', '', null, null, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (825, '水温', '825', '℃', 0, '7', '', '1', null, '', '体外循环', '', null, null, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (826, 'Bypass', '826', '', 0, '7', '', '1', null, '', '体外循环', '', null, null, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (827, 'X-Clamp', '827', '', 0, '7', '', '1', null, '', '体外循环', '', null, null, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (828, 'CPL_Deliver', '828', '', 0, '7', '', '1', null, '', '体外循环', '', null, null, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (829, 'CPL Recirc.', '829', '', 0, '7', '', '1', null, '', '体外循环', '', null, null, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (830, 'Lschaemia', '830', '', 0, '7', '', '1', null, '', '体外循环', '', null, null, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (831, 'pulsatile', '831', '', 0, '7', '', '1', null, '', '体外循环', '', null, null, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (832, 'Reperf.', '832', '', 0, '7', '', '1', null, '', '体外循环', '', null, null, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (833, 'Clamp', '833', '', 0, '7', '', '1', null, '', '体外循环', '', null, null, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (834, 'SCPC Bypass', '834', '', 0, '7', '', '1', null, '', '体外循环', '', null, null, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (835, 'SCPC X-Clamp', '835', '', 0, '7', '', '1', null, '', '体外循环', '', null, null, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (836, '搭桥计时', '836', '', 0, '7', '', '1', null, '', '体外循环', '', null, null, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (900, '血药浓度', '900', 'ug/ml', 0, '7', '', '1', null, '', '输注泵', '', null, null, null, null, null, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (901, '输注速度', '901', 'ml/h', 0, '7', '', '1', null, '', '输注泵', '', null, null, null, null, null, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (902, '药量', '902', 'ml', 0, '7', '', '1', null, '', '输注泵', '', null, null, null, null, null, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (910, '设定靶浓度', '910', 'ug/ml', 0, '7', '', '1', null, '', '输液泵', '', null, null, null, null, null, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (911, '血浆浓度', '911', 'ml/h', 0, '7', '', '1', null, '', '输液泵', '', null, null, null, null, null, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (912, '效应室浓度', '912', 'ml', 0, '7', '', '1', null, '', '输液泵', '', null, null, null, null, null, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (913, '流速', '913', 'ug/ml', 0, '7', '', '1', null, '', '输液泵', '', null, null, null, null, null, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (914, '输注速度', '914', 'ml/h', 0, '7', '', '1', null, '', '输液泵', '', null, null, null, null, null, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (915, '总量', '915', 'ml', 0, '7', '', '1', null, '', '输液泵', '', null, null, null, null, null, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (950, 'Reservoir Volume', '950', 'ml', 0, '7', '', '1', null, '', '镇痛泵', '', null, null, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (951, 'Units', '951', '', 0, '7', '', '1', null, '', '镇痛泵', '', null, null, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (952, 'Rate', '952', 'ml/hr', 0, '7', '', '1', null, '', '镇痛泵', '', null, null, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (953, 'Demand Dose', '953', 'ml', 0, '7', '', '1', null, '', '镇痛泵', '', null, null, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (954, 'Dose Lockout', '954', '', 0, '7', '', '1', null, '', '镇痛泵', '', null, null, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (955, 'Doses Per Hour', '955', 'ml/hr', 0, '7', '', '1', null, '', '镇痛泵', '', null, null, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (956, 'Dose Attempts', '956', 'ml', 0, '7', '', '1', null, '', '镇痛泵', '', null, null, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (957, 'Doses Given', '957', 'ml', 0, '7', '', '1', null, '', '镇痛泵', '', null, null, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (958, 'Given', '958', 'ml', 0, '7', '', '1', null, '', '镇痛泵', '', null, null, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (959, 'Air Detector', '959', '', 0, '7', '', '1', null, '', '镇痛泵', '', null, null, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (960, 'Upstream Sensor', '960', '', 0, '7', '', '1', null, '', '镇痛泵', '', null, null, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (961, 'Lock Level', '961', '', 0, '7', '', '1', null, '', '镇痛泵', '', null, null, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (962, 'Disposable', '962', '', 0, '7', '', '1', null, '', '镇痛泵', '', null, null, null, null, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1001, 'pO2', '1001', 'mMol/L', 0, '7', '', '1', null, '', '血气分析', '', null, null, null, 18, null, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1002, 'pCO2', '1002', 'mMol/L', 0, '7', '', '1', null, '', '血气分析', '', null, null, null, 16, null, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1003, 'Cl-', '1003', 'mmol/L', 0, '7', '', '1', null, '', '血气分析', '', null, null, null, 19, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1004, 'pH', '1004', '', 0, '7', '', '1', null, '', '血气分析', '', null, null, null, 17, null, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1005, 'HCO3std', '1005', 'mMol/L ', 0, '7', '', '1', null, '', '血气分析', '', null, null, null, 7, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1007, 'Ca++', '1007', 'mMol/L', 0, '7', '', '1', null, '', '血气分析', '', null, null, null, 3, null, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1008, 'K+', '1008', 'mMol/L ', 0, '7', '', '1', null, '', '血气分析', '', null, null, null, 9, null, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1009, 'Na+', '1009', 'mMol/L ', 0, '7', '', '1', null, '', '血气分析', '', null, null, null, 11, null, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1011, 'SO2c', '1011', '%', 0, '7', '', '1', null, '', '血气分析', '', null, null, null, 12, null, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1012, 'Temp', '1012', 'C', 0, '7', '', '1', null, '', '血气分析', '', null, null, null, 15, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1013, 'FIO2', '1013', '%', 0, '7', '', '1', null, '', '血气分析', '', null, null, null, 19, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1017, 'BEecf', '1017', 'mMol/L', 0, '7', '', '1', null, '', '血气分析', '', null, null, null, 2, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1018, 'TCO2', '1018', 'mMol/L', 0, '7', '', '1', null, '', '血气分析', '', null, null, null, 13, null, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1021, 'Hct', '1021', '%', 0, '7', '', '1', null, '', '血气分析', '', null, null, null, 8, null, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1023, 'p50', '1023', 'mmHg', 0, '7', '', '1', null, '', '血气分析', '', null, null, null, 20, null, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1024, 'AaDpO2', '1024', 'mmHg', 0, '7', '', '1', null, '', '血气分析', '', null, null, null, 21, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1025, 'a/ApO2', '1025', 'mmHg', 0, '7', '', '1', null, '', '血气分析', '', null, null, null, 22, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1026, 'tO2', '1026', 'Vol%', 0, '7', '', '1', null, '', '血气分析', '', null, null, null, 23, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1027, 'Ca++(7.4)', '1027', 'mMol/L', 0, '7', '', '1', null, '', '血气分析', '', null, null, null, 4, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1028, 'Anion gap (K+)', '1028', 'mmol/L', 0, '7', '', '1', null, '', '血气分析', '', null, null, null, 24, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1030, 'O2Hb', '1030', '%', 0, '7', '', '1', null, '', '血气分析', '', null, null, null, 25, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1031, 'HCO3-', '1031', 'mMol/L', 0, '7', '', '1', null, '', '血气分析', '', null, null, null, 6, null, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1032, 'Glu', '1032', 'mMol/L', 0, '7', '', '1', null, '', '血气分析', '', null, null, null, 5, null, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1033, 'Lac', '1033', 'mMol/L ', 0, '7', '', '1', null, '', '血气分析', '', null, null, null, 10, null, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1034, 'BE(B)', '1034', 'mMol/L', 0, '7', '', '1', null, '', '血气分析', '', null, null, null, 1, null, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1035, 'THbc', '1035', 'g/dL', 0, '7', '', '1', null, '', '血气分析', '', null, null, null, 14, null, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1036, 'COHb', '1036', '%', 0, '7', '', '1', null, '', '血气分析', '', null, null, null, 26, null, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1037, 'HHb', '1037', '%', 0, '7', '', '1', null, '', '血气分析', '', null, null, null, 27, null, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1038, 'MetHb', '1038', '%', 0, '7', '', '1', null, '', '血气分析', '', null, null, null, 28, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1039, 'ABE', '1039', 'mmol/L', 0, '7', '', '1', null, '', '血气分析', '', null, null, null, 29, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1045, 'Mg++', '1045', 'mmol/L', 0, '7', '', '1', null, '', '血气分析', '', null, null, null, 30, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1046, 'Hb', '1046', 'g/dL', 0, '7', '', '1', null, '', '血气分析', '', null, null, null, 31, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1047, 'BUN', '1047', 'mg/dL', 0, '7', '', '1', null, '', '血气分析', '', null, null, null, 32, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1050, 'BE', '1050', 'mmol/L', 0, '7', '', '1', null, '', '血气分析', '', null, null, null, 33, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1053, 'BB', '1053', 'mmol/L', 0, '7', '', '1', null, '', '血气分析', '', null, null, null, 34, null, null);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1176, 'Pplat', '1176', 'cmH2O', 0, '7', '', '0', 0, 'Draeger Julian (CS:CareN', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1184, 'etN2O', '1184', '%', 0, '7', '', '0', 0, 'Draeger Julian (CS:CareN', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1188, 'inN2O', '1188', '%', 0, '7', '', '0', 0, 'Draeger Julian (CS:CareN', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1192, 'etO2', '1192', '%', 0, '7', '', '0', 0, 'Draeger Julian (CS:CareN', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1196, 'inO2', '1196', '%', 0, '7', '', '0', 0, 'Draeger Julian (CS:CareN', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1208, 'etISO', '1208', '%', 0, '7', '', '0', 0, '呼出氧流量', '呼吸机', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1212, 'inISO', '1212', '%', 0, '7', '', '0', 0, '吸入氧流量', '呼吸机', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1216, 'etENF', '1216', '%', 0, '7', '', '0', 0, 'Draeger Julian (CS:CareN', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1220, 'inENF', '1220', '%', 0, '7', '', '0', 0, 'Draeger Julian (CS:CareN', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1280, 'BE', '1280', 'mmol/l', 0, '7', '△', '0', 0, '碱剩余', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1284, 'pH', '1284', '', 0, '7', '', '0', 0, 'Blood Analysis Mod. (CS:', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1288, 'HCO3', '1288', 'mmol/l', 0, '7', '△', '0', 0, 'HCO3', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1308, 'ApneaD', '1308', '', 0, '7', '', '0', 0, 'Draeger Julian (CS:CareN', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1348, 'HTC', '1348', '%PVC', 0, '7', '', '0', 0, '红细胞压积', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1408, 'UrUrea', '1408', 'mmol/l', 0, '7', '', '0', 0, '尿尿素', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1412, 'UrpH', '1412', '', 0, '7', '', '0', 0, '尿pH值', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1416, 'CO2T', '1416', 'mmol/l', 0, '7', '', '0', 0, '二氧化碳结合力', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1420, 'BiliT', '1420', 'mg/dl', 0, '7', '', '0', 0, '总胆红素', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1436, 'SerCa', '1436', 'umol/l', 0, '7', '', '0', 0, '血清离子钙', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1440, 'SerCaT', '1440', 'mmol/l', 0, '7', '', '0', 0, '血清钙总量', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1444, 'SerMg', '1444', 'mmol/l', 0, '7', '', '0', 0, '血清镁', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1448, 'SerP', '1448', 'mmol/l', 0, '7', '', '0', 0, '血清磷', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1452, 'SerK', '1452', 'mmol/l', 0, '7', '', '0', 0, '血清钾', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1460, 'SerAlb', '1460', 'g/l', 0, '7', '', '0', 0, '血清白蛋白', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1468, 'SerGlo', '1468', 'g/l', 0, '7', '', '0', 0, '血清球蛋白', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1472, 'SerPro', '1472', 'g/l', 0, '7', '', '0', 0, '血清总蛋白', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1476, 'SUrea', '1476', 'mmol/l', 0, '', '', '0', 0, '血清尿素', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1480, 'Leuco', '1480', '1/nl', 0, '', '', '0', 0, '白细胞', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1484, 'Ery', '1484', '', 0, '', '', '0', 0, '红细胞', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1488, 'Throm', '1488', '1/nl', 0, '7', '△', '0', 0, '血小板', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1492, 'MCV', '1492', '', 0, '7', '△', '0', 0, '红细胞平均容积', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1496, 'MCH', '1496', '', 0, '7', '△', '0', 0, '红细胞平均血红蛋白含量', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1500, 'MCHC', '1500', 'g/dl', 0, '7', '△', '0', 0, '红细胞平均血红蛋白浓度', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1504, 'PTT', '1504', 'sec', 0, '7', '△', '0', 0, '部分凝血活酶时间', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1508, 'PT', '1508', 'sec', 0, '7', '△', '0', 0, '凝血酶原时间', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1512, 'TT', '1512', 'sec', 0, '7', '△', '0', 0, '凝血酶时间', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1516, 'quick', '1516', '%', 0, '', '', '0', 0, '快速测定', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1624, 'Na', '1624', 'mmol/l', 0, '', '', '0', 0, 'Blood Analysis Mod. (CS:', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1632, 'Cl', '1632', 'mmol/l', 0, '', '', '0', 0, 'Blood Analysis Mod. (CS:', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1708, 'Patm', '1708', '', 0, '', '', '0', 0, 'Blood Analysis Mod. (CS:', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1720, 'MV', '1720', 'l/min', 0, '', '', '0', 0, 'Draeger Julian (CS:CareN', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1728, 'Pmean', '1728', 'cmH2O', 0, '', '', '0', 0, 'Draeger Julian (CS:CareN', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1732, 'RRaw', '1732', '1/min', 0, '', '', '0', 0, 'Draeger Julian (CS:CareN', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1740, 'Ppeak', '1740', 'cmH2O', 0, '', '', '0', 0, 'Draeger Julian (CS:CareN', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1748, 'Leak', '1748', 'ml/min', 0, '', '', '0', 0, 'Draeger Julian (CS:CareN', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1792, 'extHR', '1792', 'bpm', 0, '', '', '0', 0, 'Draeger Julian (CS:CareN', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (1944, 'dO2', '1944', '%', 0, '', '', '0', 0, 'Draeger Julian (CS:CareN', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (2600, 'K', '2600', 'mmol/l', 0, '', '', '0', 0, 'Blood Analysis Mod. (CS:', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (2608, 'Glu', '2608', 'mg/dl', 0, '', '', '0', 0, 'Blood Analysis Mod. (CS:', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (2612, '''Hb', '2612', 'g/dl', 0, '', '', '0', 0, 'Blood Analysis Mod. (CS:', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (2616, 'Tpat', '2616', '', 0, '', '', '0', 0, 'Blood Analysis Mod. (CS:', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (2648, 'PO2', '2648', 'mmHg', 0, '', '', '0', 0, 'Blood Analysis Mod. (CS:', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (2672, 'PCO2', '2672', 'mmHg', 0, '', '', '0', 0, 'Blood Analysis Mod. (CS:', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (2700, '''tCO2', '2700', 'mmol/l', 0, '', '', '0', 0, 'Blood Analysis Mod. (CS:', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (2704, '''SO2', '2704', '%', 0, '', '', '0', 0, 'Blood Analysis Mod. (CS:', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (2720, '''HCO3', '2720', 'mmol/l', 0, '', '', '0', 0, 'Blood Analysis Mod. (CS:', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (2724, '''BEecf', '2724', 'mmol/l', 0, '', '', '0', 0, 'Blood Analysis Mod. (CS:', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (2732, 'Sample', '2732', '', 0, '', '', '0', 0, 'Blood Analysis Mod. (CS:', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (2736, 'Cartrg', '2736', '', 0, '', '', '0', 0, 'Blood Analysis Mod. (CS:', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (2772, 'O2*', '2772', '', 0, '', '', '0', 0, 'Blood Analysis Mod. (CS:', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (2776, 'SetTmp', '2776', '', 0, '', '', '0', 0, 'Blood Analysis Mod. (CS:', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (2800, 'Sim', '2800', '', 0, '', '', '0', 0, 'Blood Analysis Mod. (CS:', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (2804, 'Error', '2804', '', 0, '', '', '0', 0, 'Blood Analysis Mod. (CS:', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (2808, 'ClwRev', '2808', '', 0, '', '', '0', 0, 'Blood Analysis Mod. (CS:', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (2820, 'UseCtr', '2820', '', 0, '', '', '0', 0, 'Blood Analysis Mod. (CS:', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (2824, 'IntPRC', '2824', '', 0, '', '', '0', 0, 'Blood Analysis Mod. (CS:', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (2828, 'IntCtr', '2828', '', 0, '', '', '0', 0, 'Blood Analysis Mod. (CS:', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (2832, 'Press1', '2832', '', 0, '', '', '0', 0, 'Blood Analysis Mod. (CS:', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (2836, 'Press2', '2836', '', 0, '', '', '0', 0, 'Blood Analysis Mod. (CS:', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (2840, 'SwRev', '2840', '', 0, '', '', '0', 0, 'Blood Analysis Mod. (CS:', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (2844, 'ModRev', '2844', '', 0, '', '', '0', 0, 'Blood Analysis Mod. (CS:', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (2848, 'SerNo', '2848', '', 0, '', '', '0', 0, 'Blood Analysis Mod. (CS:', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (2852, 'Servce', '2852', '', 0, '', '', '0', 0, 'Blood Analysis Mod. (CS:', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (2856, 'ModTmp', '2856', '', 0, '', '', '0', 0, 'Blood Analysis Mod. (CS:', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (2860, 'UnitSt', '2860', '', 0, '', '', '0', 0, 'Blood Analysis Mod. (CS:', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (2864, 'PRC', '2864', '', 0, '', '', '0', 0, 'Blood Analysis Mod. (CS:', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (2872, 'CstNam', '2872', '', 0, '', '', '0', 0, 'Blood Analysis Mod. (CS:', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (2876, 'Mesg2', '2876', '', 0, '', '', '0', 0, 'Blood Analysis Mod. (CS:', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (2884, 'TstSel', '2884', '', 0, '', '', '0', 0, 'Blood Analysis Mod. (CS:', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (3016, '年龄', '3016', 'Year(s)', 0, '', '', '0', 0, '年龄', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (3020, 'AIDS', '3020', '', 0, '', '', '0', 0, '爱滋病', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (3024, 'MetCan', '3024', '', 0, '', '', '0', 0, '转移癌', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (3028, '收纳类型', '3028', '', 0, '', '', '0', 0, '收纳类型', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (3032, 'Urine', '3032', 'l/day', 0, '', '', '0', 0, '每日尿量', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (3036, 'PtVent', '3036', '', 0, '', '', '0', 0, '患者目前予呼吸支持', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (3040, 'PaFIO2', '3040', 'mmHg/%', 0, '', '', '0', 0, '氧分压/给氧分数比', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (3044, 'HemMal', '3044', '', 0, '', '', '0', 0, '恶性血液病', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (3052, '未填值为正常', '3052', '', 0, '', '', '0', 0, '未填值为正常', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (3100, 'CDS1', '3100', '', 0, '', '', '0', 0, 'Blood Analysis Mod. (CS:', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (3104, 'CDS2', '3104', '', 0, '', '', '0', 0, 'Blood Analysis Mod. (CS:', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (3108, 'CDS3', '3108', '', 0, '', '', '0', 0, 'Blood Analysis Mod. (CS:', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (3116, 'CDS5', '3116', '', 0, '', '', '0', 0, 'Blood Analysis Mod. (CS:', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (3124, 'CDS7', '3124', '', 0, '', '', '0', 0, 'Blood Analysis Mod. (CS:', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (3176, 'CDS20', '3176', '', 0, '', '', '0', 0, 'Blood Analysis Mod. (CS:', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (4004, 'HR **', '4004', 'bpm', 0, '', '', '0', 0, 'DAP Internal Source (CS:', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (4005, 'AAI', '4005', '', 32768, '7', '●', '1', 3, 'AAI', '', '', null, null, null, null, 2, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (32768, 'sVMode', '32768', '', 0, '', '', '0', 0, 'Draeger Julian (CS:CareN', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (32792, 'sPltTi', '32792', '%', 0, '', '', '0', 0, 'Draeger Julian (CS:CareN', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (32928, 'sIPPV', '32928', '1/min', 0, '', '', '0', 0, 'Draeger Julian (CS:CareN', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (32940, 'sSPEEP', '32940', 'cmH2O', 0, '', '', '0', 0, 'Draeger Julian (CS:CareN', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (32992, 'sPmax', '32992', 'cmH2O', 0, '', '', '0', 0, 'Draeger Julian (CS:CareN', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (33004, 'sIE 1:', '33004', '-', 0, '', '', '0', 0, 'Draeger Julian (CS:CareN', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (33016, 'sFlow', '33016', 'l/min', 0, '', '', '0', 0, 'Draeger Julian (CS:CareN', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (33036, 'sO2', '33036', '%', 0, '', '', '0', 0, 'Draeger Julian (CS:CareN', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (33124, 'sPtCat', '33124', '', 0, '', '', '0', 0, 'Draeger Julian (CS:CareN', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (33140, 'loPmax', '33140', 'cmH2O', 0, '', '', '0', 0, 'Draeger Julian (CS:CareN', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (33208, 'sfgFl', '33208', 'ml/min', 0, '', '', '0', 0, 'Draeger Julian (CS:CareN', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (33228, 'sTVin', '33228', 'l', 0, '', '', '0', 0, 'Draeger Julian (CS:CareN', '', '', null, null, null, null, 1, 1);

insert into med_monitor_function_code (ITEM_ID, ITEM_NAME, ITEM_CODE, ITEM_UNIT, DIS_COLOR, PARM_CLASS, DRAW_ICON, USE_FLAG, PRIORITY_INDI, MEMO, INPUT_CODE, NAME_IN_ICU, VALUE_TYPE, EXAM_METHOD, ITEM_TYPE, PRINT_ITEM_NO, DRAW_STYLE, DRAW_ISVALID)
values (33244, 'GasCar', '33244', '', 0, '', '', '0', 0, 'Draeger Julian (CS:CareN', '', '', null, null, null, null, 1, 1);



