
---------------------------------------------------------------
--用MedCommon登录PLSQL执行以下语句 conn medcomm/medcomm
---------------------------------------------------------------
create table MED_SCREEN_COL_LIST
(
  COL        VARCHAR2(30) not null,
  COL_NAME   VARCHAR2(30) not null,
  COL_WIDTH  NUMBER(12,2) not null,
  COL_STATUS NUMBER(1),
  COL_NO     NUMBER(3)
)
;
grant select, insert, update, delete on MED_SCREEN_COL_LIST to ROLE_DOCARE;

create table MED_SCREEN_TEMPLATE
(
  SCREEN_COL_COLOR         VARCHAR2(16),
  SCREEN_BACK_COLOR        VARCHAR2(16),
  SCREEN_TITLE_COLOR       VARCHAR2(16),
  SCREEN_TIMEPAGE_COLOR    VARCHAR2(16),
  SCREEN_SHUQIAN_COLOR     VARCHAR2(16),
  SCREEN_SHUZHONG_COLOR    VARCHAR2(16),
  SCREEN_PACU_COLOR        VARCHAR2(16),
  SCREEN_SHUHOU_COLOR      VARCHAR2(16),
  SCREEN_NEIRONG_COLOR     VARCHAR2(16),
  SCREEN_NEIRONGBACK_COLOR VARCHAR2(16),
  SCREEN_TEMPBACK_COLOR    VARCHAR2(16),
  SCREEN_TEMPFOR_COLOR     VARCHAR2(16),
  SCREEN_ZDBACK_COLOR      VARCHAR2(16),
  SCREEN_TEMPLATE_NO       NUMBER(3),
  SCREEN_TEMPLATE_NAME     VARCHAR2(16) not null
)
;
alter table MED_SCREEN_TEMPLATE
  add constraint KEY primary key (SCREEN_TEMPLATE_NAME);

insert into MED_SCREEN_COL_LIST (COL, COL_NAME, COL_WIDTH, COL_STATUS, COL_NO)
values ('PAT_AGE', '年龄', 50, 1, 7);
insert into MED_SCREEN_COL_LIST (COL, COL_NAME, COL_WIDTH, COL_STATUS, COL_NO)
values ('SECOND_SUPPLY_NURSE', '巡回2', 75, 1, 22);
insert into MED_SCREEN_COL_LIST (COL, COL_NAME, COL_WIDTH, COL_STATUS, COL_NO)
values ('SECOND_OPERATION_NURSE', '洗手2', 75, 1, 24);
insert into MED_SCREEN_COL_LIST (COL, COL_NAME, COL_WIDTH, COL_STATUS, COL_NO)
values ('SEX', '性别', 50, 1, 3);
insert into MED_SCREEN_COL_LIST (COL, COL_NAME, COL_WIDTH, COL_STATUS, COL_NO)
values ('TYPE', '手术状态', 150, 2, 6);
insert into MED_SCREEN_COL_LIST (COL, COL_NAME, COL_WIDTH, COL_STATUS, COL_NO)
values ('SURGEON', '手术者', 100, 1, 13);
insert into MED_SCREEN_COL_LIST (COL, COL_NAME, COL_WIDTH, COL_STATUS, COL_NO)
values ('NAME', '姓名', 200, 2, 4);
insert into MED_SCREEN_COL_LIST (COL, COL_NAME, COL_WIDTH, COL_STATUS, COL_NO)
values ('TYPE', '状态', 100, 1, 11);
insert into MED_SCREEN_COL_LIST (COL, COL_NAME, COL_WIDTH, COL_STATUS, COL_NO)
values ('FIRST_ASSISTANT', '助手1', 100, 1, 14);
insert into MED_SCREEN_COL_LIST (COL, COL_NAME, COL_WIDTH, COL_STATUS, COL_NO)
values ('OPERATING_ROOM_NO', '手术间', 120, 2, 3);
insert into MED_SCREEN_COL_LIST (COL, COL_NAME, COL_WIDTH, COL_STATUS, COL_NO)
values ('OPERATION', '手术名称', 300, 1, 12);
insert into MED_SCREEN_COL_LIST (COL, COL_NAME, COL_WIDTH, COL_STATUS, COL_NO)
values ('SECOND_ASSISTANT', '助手2', 75, 1, 15);
insert into MED_SCREEN_COL_LIST (COL, COL_NAME, COL_WIDTH, COL_STATUS, COL_NO)
values ('THIRD_ASSISTANT', '助手3', 75, 1, 16);
insert into MED_SCREEN_COL_LIST (COL, COL_NAME, COL_WIDTH, COL_STATUS, COL_NO)
values ('ANESTHESIA_METHOD', '麻醉方法', 100, 1, 17);
insert into MED_SCREEN_COL_LIST (COL, COL_NAME, COL_WIDTH, COL_STATUS, COL_NO)
values ('NAME', '床号', 80, 1, 2);
insert into MED_SCREEN_COL_LIST (COL, COL_NAME, COL_WIDTH, COL_STATUS, COL_NO)
values ('ANESTHESIA_DOCTOR', '麻醉者', 75, 1, 18);
insert into MED_SCREEN_COL_LIST (COL, COL_NAME, COL_WIDTH, COL_STATUS, COL_NO)
values ('ANESTHESIA_ASSISTANT', '麻醉者', 75, 1, 19);
insert into MED_SCREEN_COL_LIST (COL, COL_NAME, COL_WIDTH, COL_STATUS, COL_NO)
values ('OPERATING_ROOM_NO', '室别', 50, 1, 20);
insert into MED_SCREEN_COL_LIST (COL, COL_NAME, COL_WIDTH, COL_STATUS, COL_NO)
values ('FIRST_SUPPLY_NURSE', '巡回1', 75, 1, 21);
insert into MED_SCREEN_COL_LIST (COL, COL_NAME, COL_WIDTH, COL_STATUS, COL_NO)
values ('FIRST_OPERATION_NURSE', '洗手1', 75, 1, 23);
insert into MED_SCREEN_COL_LIST (COL, COL_NAME, COL_WIDTH, COL_STATUS, COL_NO)
values ('BED_NO', '床号', 120, 2, 5);
insert into MED_SCREEN_COL_LIST (COL, COL_NAME, COL_WIDTH, COL_STATUS, COL_NO)
values ('BED_NO', '床号', 60, 1, 10);
commit;

create table MED_SCREEN_CONFIG
(
  SCREEN_DEPT_CODE         VARCHAR2(16),
  SCREEN_FONT              VARCHAR2(100),
  SCREEN_TYPE              NUMBER not null,
  SCREEN_MODE              NUMBER,
  SCREEN_TIMER             NUMBER,
  SCREEN_AUTOLOGION        NUMBER,
  SCERRN_WIDTH             NUMBER,
  SCREEN_HEIGHT            NUMBER,
  SCREEN_COL_COLOR         VARCHAR2(16),
  SCREEN_BACK_COLOR        VARCHAR2(16),
  SCREEN_TITLE_COLOR       VARCHAR2(16),
  SCREEN_TIMEPAGE_COLOR    VARCHAR2(16),
  SCREEN_SHUQIAN_COLOR     VARCHAR2(16),
  SCREEN_SHUZHONG_COLOR    VARCHAR2(16),
  SCREEN_PACU_COLOR        VARCHAR2(16),
  SCREEN_SHUHOU_COLOR      VARCHAR2(16),
  SCREEN_TEMP_INFO         VARCHAR2(255),
  SCREEN_FONT_NEIRONG      VARCHAR2(100),
  SCREEN_NEIRONG_COLOR     VARCHAR2(16),
  SCREEN_TEMPBACK_COLOR    VARCHAR2(16),
  SCREEN_TEMPFOR_COLOR     VARCHAR2(16),
  SCREEN_NEIRONGBACK_COLOR VARCHAR2(16),
  SCREEN_ZDBACK_COLOR      VARCHAR2(16),
  SCREEN_TITLE             VARCHAR2(50),
  SCREEN_SORT              VARCHAR2(255),
  SCREEN_FIRSTLEFT         NUMBER,
  SCREEN_BIAOTI_HEIGHT     NUMBER,
  SCREEN_NEIRONG_HEIGHT    NUMBER
)
;
alter table MED_SCREEN_CONFIG
  add constraint TYPEKEY primary key (SCREEN_TYPE);
grant select, insert, update, delete on MED_SCREEN_CONFIG to ROLE_DOCARE;

insert into MED_SCREEN_CONFIG (SCREEN_DEPT_CODE, SCREEN_FONT, SCREEN_TYPE, SCREEN_MODE, SCREEN_TIMER, SCREEN_AUTOLOGION, SCERRN_WIDTH, SCREEN_HEIGHT, SCREEN_COL_COLOR, SCREEN_BACK_COLOR, SCREEN_TITLE_COLOR, SCREEN_TIMEPAGE_COLOR, SCREEN_SHUQIAN_COLOR, SCREEN_SHUZHONG_COLOR, SCREEN_PACU_COLOR, SCREEN_SHUHOU_COLOR, SCREEN_TEMP_INFO, SCREEN_FONT_NEIRONG, SCREEN_NEIRONG_COLOR, SCREEN_TEMPBACK_COLOR, SCREEN_TEMPFOR_COLOR, SCREEN_NEIRONGBACK_COLOR, SCREEN_ZDBACK_COLOR, SCREEN_TITLE, SCREEN_SORT, SCREEN_FIRSTLEFT, SCREEN_BIAOTI_HEIGHT, SCREEN_NEIRONG_HEIGHT)
values ('2110000', '微软雅黑,18,Bold', 2, 1, 6000, 1, 1024, 1000, '255,255,255', '0,0,0', '255,255,255', '255,255,255', '245,227,157', '175,57,22', '101,127,140', '160,111,58', '麦迪斯顿医疗科技！', '宋体,21.75,Bold', '0,0,0', '0,0,0', '255,255,128', '71,87,118', '175,238,238', '家属等待', null, 40, 40, 40);
insert into MED_SCREEN_CONFIG (SCREEN_DEPT_CODE, SCREEN_FONT, SCREEN_TYPE, SCREEN_MODE, SCREEN_TIMER, SCREEN_AUTOLOGION, SCERRN_WIDTH, SCREEN_HEIGHT, SCREEN_COL_COLOR, SCREEN_BACK_COLOR, SCREEN_TITLE_COLOR, SCREEN_TIMEPAGE_COLOR, SCREEN_SHUQIAN_COLOR, SCREEN_SHUZHONG_COLOR, SCREEN_PACU_COLOR, SCREEN_SHUHOU_COLOR, SCREEN_TEMP_INFO, SCREEN_FONT_NEIRONG, SCREEN_NEIRONG_COLOR, SCREEN_TEMPBACK_COLOR, SCREEN_TEMPFOR_COLOR, SCREEN_NEIRONGBACK_COLOR, SCREEN_ZDBACK_COLOR, SCREEN_TITLE, SCREEN_SORT, SCREEN_FIRSTLEFT, SCREEN_BIAOTI_HEIGHT, SCREEN_NEIRONG_HEIGHT)
values ('2110000', '微软雅黑,18,Bold', 1, 1, 20000, 1, 1366, 600, '255,255,255', '0,0,0', '255,255,255', '255,255,255', '245,227,157', '175,57,22', '101,127,140', '160,111,58', '麦迪斯顿医疗科技!', '微软雅黑,15,Bold', '0,0,0', '0,0,0', '255,255,128', '71,87,118', '175,238,238', '每日手术情况一览表', 'OPERATING_ROOM_NO', 30, 40, 40);
commit;


insert into MED_SCREEN_TEMPLATE (SCREEN_COL_COLOR, SCREEN_BACK_COLOR, SCREEN_TITLE_COLOR, SCREEN_TIMEPAGE_COLOR, SCREEN_SHUQIAN_COLOR, SCREEN_SHUZHONG_COLOR, SCREEN_PACU_COLOR, SCREEN_SHUHOU_COLOR, SCREEN_NEIRONG_COLOR, SCREEN_NEIRONGBACK_COLOR, SCREEN_TEMPBACK_COLOR, SCREEN_TEMPFOR_COLOR, SCREEN_ZDBACK_COLOR, SCREEN_TEMPLATE_NO, SCREEN_TEMPLATE_NAME)
values ('255,128,64', '0,0,0', '255,255,255', '255,255,255', '0,255,0', '255,0,0', '255,128,255', '0,0,255', '255,255,255', '71,87,118', '0,0,0', '255,128,0', '175,238,238', 5, '模板一');
insert into MED_SCREEN_TEMPLATE (SCREEN_COL_COLOR, SCREEN_BACK_COLOR, SCREEN_TITLE_COLOR, SCREEN_TIMEPAGE_COLOR, SCREEN_SHUQIAN_COLOR, SCREEN_SHUZHONG_COLOR, SCREEN_PACU_COLOR, SCREEN_SHUHOU_COLOR, SCREEN_NEIRONG_COLOR, SCREEN_NEIRONGBACK_COLOR, SCREEN_TEMPBACK_COLOR, SCREEN_TEMPFOR_COLOR, SCREEN_ZDBACK_COLOR, SCREEN_TEMPLATE_NO, SCREEN_TEMPLATE_NAME)
values ('255,255,255', '0,128,128', '255,255,255', '255,255,255', '0,255,0', '255,128,0', '255,0,0', '128,255,255', '255,255,0', '0,0,0', '0,128,255', '255,255,255', '0,128,255', 3, '模板二');
insert into MED_SCREEN_TEMPLATE (SCREEN_COL_COLOR, SCREEN_BACK_COLOR, SCREEN_TITLE_COLOR, SCREEN_TIMEPAGE_COLOR, SCREEN_SHUQIAN_COLOR, SCREEN_SHUZHONG_COLOR, SCREEN_PACU_COLOR, SCREEN_SHUHOU_COLOR, SCREEN_NEIRONG_COLOR, SCREEN_NEIRONGBACK_COLOR, SCREEN_TEMPBACK_COLOR, SCREEN_TEMPFOR_COLOR, SCREEN_ZDBACK_COLOR, SCREEN_TEMPLATE_NO, SCREEN_TEMPLATE_NAME)
values ('255,255,255', '99,211,119', '255,255,255', '255,255,255', '0,255,0', '255,0,0', '255,128,255', '0,0,255', '255,255,255', '0,0,0', '22,143,50', '255,255,255', '45,145,50', 4, '模板三');
commit;


-- Create table
create table MED_SCREEN_MSG
(
  ID          VARCHAR2(40) not null,
  MSG         VARCHAR2(50),
  INSERT_TIME DATE,
  COUNTS      NUMBER(2),
  STATUS      NUMBER(1),
  OTHER1      NUMBER(5),
  USER_ID     VARCHAR2(36),
  TYPE        NUMBER(5),
  DEPT_CODE   VARCHAR2(12)
);
alter table MED_SCREEN_MSG
  add constraint KEYS primary key (ID);
  
create or replace view view_operation_list as
select
       A.patient_id,                                       --病人ID (住院号)
       A.visit_id,                                         --本次住院标示
       A.schedule_id,                                      --手术申请ID
       C.NAME,                                             --名称
       c.sex,                                              --性别
       C.INP_NO,                                           --住院号
       C.DATE_OF_BIRTH,                                    --出生日期
       C.NATION,                                           --民族
       --病人所在科室
       nvl((select med_dept_dict.DEPT_NAME   from med_dept_dict where med_dept_dict.dept_code = a.dept_stayed ),a.dept_stayed ) dept_stayed,
       A.bed_no,                                           --床号
       A.scheduled_date_time,                              --手术日期及时间
       --手术室
       a.operating_room,
        nvl((select med_dept_dict.DEPT_NAME   from med_dept_dict where med_dept_dict.dept_code = a.operating_room ),a.operating_room ) operating_room_name,
        A.operating_room_no,                                --手术间
       A.sequence,                                         --台次
       A.diag_before_operation,                            --术前诊断
       A.patient_condition,                                --特殊情况
       b.operation ,                                       --手术名称
       A.operation_scale,                                  --手术等级
        --手术科室
       nvl((select med_dept_dict.DEPT_NAME   from med_dept_dict where med_dept_dict.dept_code = a.operating_dept ),a.operating_dept ) operating_dept,
       --手术者
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.surgeon ),a.surgeon ) surgeon,
       --第一手术助手
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.first_assistant ),a.first_assistant ) first_assistant,
       --第二手术助手
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.second_assistant ),a.second_assistant ) second_assistant,
       --第三手术助手
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.third_assistant ),a.third_assistant ) third_assistant,
       --第四手术助手
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.fourth_assistant ),a.fourth_assistant ) fourth_assistant,
       A.anesthesia_method,                                --麻醉方法
       --麻醉医生
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.anesthesia_doctor ),a.anesthesia_doctor ) anesthesia_doctor,
       --第麻醉助手
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.anesthesia_assistant ),a.anesthesia_assistant ) anesthesia_assistant,
       --第二麻醉助手
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.second_anesthesia_doctor ),a.second_anesthesia_doctor ) second_anesthesia_doctor,
       --第三麻醉助手
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.third_anesthesia_doctor ),a.third_anesthesia_doctor ) third_anesthesia_doctor,
       --第四麻醉助手
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.fourth_anesthesia_assistant ),a.fourth_anesthesia_assistant ) fourth_anesthesia_assistant,
       --第一洗手护士
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.first_operation_nurse ),a.first_operation_nurse ) first_operation_nurse,
       --第二洗手护士
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.second_operation_nurse ),a.second_operation_nurse ) second_operation_nurse,
       --第一巡回护士
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.first_supply_nurse ),a.first_supply_nurse ) first_supply_nurse,
       --第二巡回护士
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.second_supply_nurse ),a.second_supply_nurse ) second_supply_nurse,
       --第三巡回护士
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.third_supply_nurse ),a.third_supply_nurse ) third_supply_nurse,
       A.notes_on_operation,                               --备注
       A.entered_by,                                       --录入者
       A.req_date_time,                                    --申请日期时间
       A.emergency_indicator,                              --急诊标志
       A.operation_position,                               --体位
       A.reserved4,                                        --备血
       A.reserved5,                                         --感染情况
       case A.anesthesia_method when '局麻' then '术中' else '术前' end  type,
       1  OPER_STATUS,
       TO_CHAR(SYSDATE,'YYYY') - TO_CHAR(c.DATE_OF_BIRTH,'YYYY') AS PAT_AGE
 from med_operation_schedule a , med_scheduled_operation_name b , med_pat_master_index c
 where a.patient_id = b.patient_id                            and
       a.visit_id   = b.visit_id                              and
       a.schedule_id= b.schedule_id                           and
       a.patient_id = c.patient_id                            and
       b.operation_no = 1                                     and
       to_char(A.scheduled_date_time,'yyyymmdd') > to_char( sysdate -1  ,'yyyymmdd')                  and
       to_char(A.scheduled_date_time,'yyyymmdd') < to_char( sysdate + 1  ,'yyyymmdd')                  and
       a.state = 2
union
select
       A.patient_id,                                       --病人ID (住院号)
       A.visit_id,                                         --本次住院标示
       A.oper_id,                                          --手术申请ID
       D.NAME,                                             --名称
       D.sex,                                              --性别
       D.INP_NO,                                           --住院号
       D.DATE_OF_BIRTH,                                    --出生日期
       D.NATION,                                           --民族
       --病人所在科室
      nvl((select med_dept_dict.DEPT_NAME   from med_dept_dict where med_dept_dict.dept_code = a.dept_stayed ),a.dept_stayed ) dept_stayed,
       --c.bed_no,                                           --床号
       a.bed_no,
       A.START_DATE_TIME,                                  --手术日期及时间
       --手术室
       a.operating_room,
      nvl((select med_dept_dict.DEPT_NAME   from med_dept_dict where med_dept_dict.dept_code = a.operating_room ),a.operating_room ) operating_room_name,
       A.operating_room_no,                                --手术间
       A.sequence,                                         --台次
       A.diag_before_operation,                            --术前诊断
       A.patient_condition,                                --特殊情况
       b.operation ,                                       --手术名称
       A.operation_scale,                                  --手术等级
       --手术科室
      nvl((select med_dept_dict.DEPT_NAME   from med_dept_dict where med_dept_dict.dept_code = a.operating_dept ),a.operating_dept ) operating_dept,
       --手术者
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.surgeon ),a.surgeon ) surgeon,
       --第一手术助手
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.first_assistant ),a.first_assistant ) first_assistant,
       --第二手术助手
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.second_assistant ),a.second_assistant ) second_assistant,
       --第三手术助手
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.third_assistant ),a.third_assistant ) third_assistant,
       --第四手术助手
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.fourth_assistant ),a.fourth_assistant ) fourth_assistant,
       A.anesthesia_method,                                --麻醉方法
       --麻醉医生
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.anesthesia_doctor ),a.anesthesia_doctor ) anesthesia_doctor,
       --第麻醉助手
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.anesthesia_assistant ),a.anesthesia_assistant ) anesthesia_assistant,
       --第二麻醉助手
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.second_anesthesia_doctor ),a.second_anesthesia_doctor ) second_anesthesia_doctor,
       --第三麻醉助手
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.third_anesthesia_doctor ),a.third_anesthesia_doctor ) third_anesthesia_doctor,
       --第四麻醉助手
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.fourth_anesthesia_assistant ),a.fourth_anesthesia_assistant ) fourth_anesthesia_assistant,
       --第一洗手护士
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.first_operation_nurse ),a.first_operation_nurse ) first_operation_nurse,
       --第二洗手护士
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.second_operation_nurse ),a.second_operation_nurse ) second_operation_nurse,
       --第一巡回护士
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.first_supply_nurse ),a.first_supply_nurse ) first_supply_nurse,
       --第二巡回护士
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.second_supply_nurse ),a.second_supply_nurse ) second_supply_nurse,
       --第三巡回护士
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.third_supply_nurse ),a.third_supply_nurse ) third_supply_nurse,
       null,                                               --备注
       A.entered_by,                                       --录入者
       to_date(null,'yyyy-mm-dd'),                         --申请日期时间
       A.emergency_indicator,                              --急诊标志
       A.operation_position,                               --体位
       A.reserved4,                                        --备血
       A.reserved5,                                         --感染情况
       --DECODE( A.OPER_STATUS, 5,'术中',10,'术中',15,'术中',25,'术中',30,'术中',35,'术后',45,'复苏室') type,
       case A.anesthesia_method when '局麻' then '术中' else
       DECODE( A.OPER_STATUS, 5,'术中',10,'术中',15,'术中',25,'术中',30,'术中',35,'术后',40,'复苏室',45,'复苏室') end  type,
       A.OPER_STATUS,
       TO_CHAR(SYSDATE,'YYYY') - TO_CHAR(D.DATE_OF_BIRTH,'YYYY') AS PAT_AGE
from med_operation_master a , med_operation_name b , med_anesthesia_plan c , med_pat_master_index d
 where a.patient_id = b.patient_id(+)                            and
       a.visit_id   = b.visit_id(+)                              and
       a.oper_id= b.oper_id(+)                                   and
       a.patient_id = d.patient_id                            and
       a.patient_id = c.patient_id(+)                            and
       a.visit_id = c.visit_id(+)                                and
       a.oper_id = c.oper_id(+)                                  and
       a.OPER_STATUS > 1                                      and
       --2011.05.31入手术室时改变的In_Date_Time，而开始手术改变的是START_DATE_TIME，所以要两个时间都判断
       ((to_char(a.START_DATE_TIME , 'yyyymmdd') > to_char( sysdate - 1  ,'yyyymmdd')  and
       to_char(a.START_DATE_TIME , 'yyyymmdd') < to_char( sysdate + 1  ,'yyyymmdd') ) or
       ( to_char(a.In_Date_Time , 'yyyymmdd') > to_char( sysdate - 1  ,'yyyymmdd')  and
       to_char(a.In_Date_Time , 'yyyymmdd') < to_char( sysdate + 1  ,'yyyymmdd'))) and
       b.operation_no(+) = 1 and A.OPER_STATUS < 50
;
grant select  on view_operation_list to ROLE_DOCARE;


;