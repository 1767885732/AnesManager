create or replace view PACU_PROCESS as
  select r.bed_label as pacu_bed_no, m.in_pacu_date_time, m.sequence, oldr.bed_label, i.inp_no, i.name, i.sex,
 to_char(floor((sysdate-m.in_pacu_date_time)*24), '09') || ':' || to_char(floor(mod((sysdate-m.in_pacu_date_time)*24,1)*60), '09')  as time_span,
 nvl(dept.dept_name, m.dept_stayed) dept_name, m.bed_no, m.operation_name, m.anesthesia_method, m.reserved7 as out_place,
 nvl(su.user_name, m.surgeon) as surgeon, nvl(a1.user_name, m.anesthesia_doctor) as anesthesia_doctor,
 nvl(a2.user_name, m.second_anesthesia_doctor) as second_anesthesia_doctor,
 nvl(n1.user_name, m.first_operation_nurse) as first_operation_nurse, 
 nvl(n2.user_name, m.first_supply_nurse) as supply_nurse,
 nvl(c1.user_name, m.pacu_doctor) as pacu_doctor, nvl(c2.user_name, m.reserved1) as pacu_nurse
from med_operating_room r 
left join med_operation_master m on r.patient_id = m.patient_id and r.visit_id = m.visit_id and r.oper_id = m.oper_id
left join med_pat_master_index i on r.patient_id = i.patient_id
left join med_operating_room oldr on m.operating_room = oldr.dept_code and m.operating_room_no = oldr.room_no
left join med_dept_dict dept on dept.dept_code = m.dept_stayed
left join med_his_users su on su.user_id = m.surgeon
left join med_his_users a1 on a1.user_id = m.anesthesia_doctor
left join med_his_users a2 on a2.user_id = m.second_anesthesia_doctor
left join med_his_users n1 on n1.user_id = m.first_operation_nurse
left join med_his_users n2 on n2.user_id = m.first_supply_nurse
left join med_his_users c1 on c1.user_id = m.pacu_doctor
left join med_his_users c2 on c2.user_id = m.reserved1
where r.bed_type = 1 
order by r.room_no;



-------------------------------------------------
create or replace view pacu_aquair as
select  * from (
select row_number() over(order by m.reserved9)  as AUQAIR_SEQUENCE,
    m.reserved9 as AQUAIR_PACU_TIME, (case JT when 6 then '√' when 4 then '×'  when 7 then '＝' else '' end) AQUAIRED,  m.reserved10 as AQUAIRED_TIME,
    r.bed_label, i.inp_no, i.name as pat_name, i.sex, extract(year from sysdate) - extract(year from i.date_of_birth) as age,
    nvl(ward.dept_name, h.ward_code) as Ward_Name, h.bed_no, m.operation_name,
    m.RESERVED7 as Out_place, nvl(su.user_name, m.surgeon) as Surgeon, m.anesthesia_method, m.oper_status,
    trim(nvl(fa.user_name, m.first_assistant) || ' ' || nvl(sa.user_name, m.second_assistant) || ' ' || nvl(ta.user_name, m.third_assistant)) as Assisatant,
    trim(nvl(a1.user_name, m.anesthesia_doctor) || ' ' || nvl(a2.user_name, m.second_anesthesia_doctor) || ' ' || nvl(a3.user_name, m.third_anesthesia_doctor)) as Anes_doctor,
    trim(nvl(on1.user_name, m.first_operation_nurse) || ' ' || nvl(on2.user_name, m.second_operation_nurse) ) as operation_nurse,
    trim(nvl(sn1.user_name, m.first_supply_nurse) || ' ' || nvl(sn2.user_name, m.second_supply_nurse) ) as supply_nurse,
    m.patient_id, m.oper_id, m.visit_id, m.in_pacu_date_time, m.operating_room_no,(case when  m.out_date_time is null then '否' else '是' end) IS_OUT,
    row_number() over(partition by JT order by m.reserved9) as DEAL_SEQUENCE, m.reserved6 Condition, pl.asa_grade
from med_operation_master m
left join med_operating_room r on m.operating_room = r.dept_code and m.operating_room_no = r.room_no and r.bed_type = 0
left join med_pat_master_index i on m.patient_id = i.patient_id
left join med_pats_in_hospital h on h.patient_id = m.patient_id and h.visit_id = m.visit_id
left join med_dept_dict dept on dept.dept_code = h.dept_code
left join med_dept_dict ward on ward.dept_code = h.ward_code
left join med_his_users su on m.surgeon = su.user_id
left join med_his_users fa on fa.user_id = m.first_assistant
left join med_his_users sa on sa.user_id = m.second_assistant
left join med_his_users ta on ta.user_id = m.third_assistant
left join med_his_users a1 on a1.user_id = m.anesthesia_doctor
left join med_his_users a2 on a2.user_id = m.second_anesthesia_doctor
left join med_his_users a3 on a3.user_id = m.third_anesthesia_doctor
left join med_his_users on1 on on1.user_id = m.first_operation_nurse
left join med_his_users on2 on on2.user_id = m.second_operation_nurse
left join med_his_users sn1 on sn1.user_id = m.first_supply_nurse
left join med_his_users sn2 on sn2.user_id = m.second_supply_nurse
left join med_anesthesia_plan pl on m.patient_id = pl.patient_id and m.visit_id = pl.visit_id and m.oper_id = pl.oper_id
where (JT = 5 or JT = 6 or JT = 7) and  to_char(m.in_date_time, 'yyyy-MM-dd') = to_char(sysdate, 'yyyy-MM-dd')
order by AQUAIR_PACU_TIME)
where in_pacu_date_time is null and AQUAIR_PACU_TIME is not null
;
;



create or replace view view_pacu_room_status as
select  ph.pacu_bed as operating_room_no, t.in_pacu_date_time, t.out_pacu_date_time, t.oper_status, e.start_time PulePipeTime,
        DECODE(t.emergency_indicator, 0 , '择期' , 1 , '急诊', 2, '加台',3,'紧急')  emergency,
        round((case when t.out_pacu_date_time is not null then t.out_pacu_date_time - t.in_pacu_date_time else 0 end)*24, 4) use_time,
        (m.inp_no || ' ' || m.name || ' ' || m.sex || ' ' || to_char(extract(year from sysdate) - extract(year from m.date_of_birth)) ||
             ' ' || nvl(dd.dept_name, ho.ward_code) ||  ho.bed_no || ' ' || nvl(su.user_name, t.surgeon)) info1,
        (nvl(a1.user_name, t.anesthesia_doctor) || '  ' || t.anesthesia_method || '  ' || t.operation_name) info2,
        (case when ph.pull_pipe = '保留' then '1' else '0' end ) HasPipe
from med_operation_master t
left join med_pat_master_index m on t.patient_id = m.patient_id
left join med_his_users su on t.surgeon = su.user_id
left join med_his_users a1 on a1.user_id = t.anesthesia_doctor
left join med_pats_in_hospital ho on ho.patient_id = t.patient_id and ho.visit_id = t.visit_id
left join med_dept_dict dd on ho.ward_code = dd.dept_code
left join med_inpacu ph on ph.patient_id = t.patient_id and ph.visit_id = t.visit_id and ph.oper_id = t.oper_id
left join med_anesthesia_event e on e.item_class = '8' and e.patient_id = t.patient_id and e.visit_id = t.visit_id and e.oper_id = t.oper_id
where t.oper_status >= 40 and ph.pacu_bed is not null
order by operating_room_no desc
;