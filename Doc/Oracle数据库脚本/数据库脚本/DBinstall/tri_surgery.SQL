create or replace trigger PACU_DATA_INSERT
  before insert on patient_monitor_data  
  for each row
  
when (NEW.DATA_TYPE='1' AND NEW.ITEM_NO>0)
declare
  v_TIME_POINT        date; --本次采集时间点
  v_VITAL_SIGNS       varchar2(6); --用于存放本次采集某体征参数代码
  v_VITAL_SIGNS_VALUE varchar2(16); --用于存放本次采集某体征值
  v_VITAL_SIGNS_UNITS varchar2(16); --用于存放本次采集某体征值单位
  v_VITAL_FUNCS       varchar2(240); --本床采集所有体征参数串，例如：44,  89,  90, 100, 188, 112,  92,  65,  66,  71,  77,  78,
  v_cur_vitals        varchar2(240); --本床本次采集体征值串

  i number;

  -- 用于获取以delimeter为分隔符的第occurance个子字符串
  function f_substr(str       IN VARCHAR2,
                    delimeter in varchar2,
                    occurance in number) return varchar2 is
    v_start number;
    v_end   number;
  BEGIN
    if occurance <= 0 then
      return '';
    end if;
  
    if occurance = 1 then
      v_start := 1;
    else
      if Instrb(str, delimeter, 1, occurance - 1) = 0 then
        return '';
      end if;
    
      v_start := Instrb(str, delimeter, 1, occurance - 1) +
                 lengthb(delimeter);
    
    end if;
  
    if v_start = lengthb(str) then
      return '';
    end if;
  
    if Instrb(str, delimeter, 1, occurance) = 0 then
      return '';
    end if;
  
    v_end := Instrb(str, delimeter, 1, occurance);
    if v_end = 0 then
      return '';
    end if;
  
    return trim(substrb(str, v_start, v_end - v_start));
  
  END;
begin
  -- 查找本次采集头信息
  begin
  
    SELECT substr(MONITOR_VALUE, 16)
      into v_VITAL_FUNCS
      from patient_monitor_data
     where DATA_TYPE = '1'
       and monitor_value not like '%.%'
       and patient_id = :new.patient_id
       and visit_id = :new.visit_id
       and oper_id = :new.oper_id
       and data_type = '1';
  exception
    when others then
      return;
  end;

  -- 获取时间点信息，存入变量v_time_point
  v_time_point := to_date(substr(:new.MONITOR_VALUE, 1, 14),
                          'yy-mm-dd hh24:mi');

  -- 解析体征参数值
  v_cur_vitals := substr(:new.MONITOR_VALUE, 16);
  for i in 1 .. 50 loop
    v_VITAL_SIGNS_VALUE := f_substr(v_cur_vitals, ',', i);
    if v_VITAL_SIGNS_VALUE is null or v_VITAL_SIGNS_VALUE = '' then
      return;
    end if;
  
    if v_VITAL_SIGNS_VALUE not in ('0', '0.0', '0.', '.0', '0.00') then
    
      v_VITAL_SIGNS := f_substr(v_VITAL_FUNCS, ',', i);
      sys.dbms_output.put_line(v_VITAL_SIGNS);
      if v_VITAL_SIGNS is null or v_VITAL_SIGNS = '' then
        return;
      end if;
    
      begin
        select ITEM_UNIT
          into v_VITAL_SIGNS_UNITS
          FROM monitor_function_code
         WHERE ITEM_CODE = v_VITAL_SIGNS;
      exception
        when others then
          return;
      end;
    
      -- 插入术后复苏体征记录PACU_VITAL_SIGNS_REC
      begin
        insert into PACU_VITAL_SIGNS_REC
          (PATIENT_ID,
           VISIT_ID,
           OPER_ID,
           TIME_POINT,
           VITAL_SIGNS,
           VITAL_SIGNS_VALUE,
           UNITS,
           EXAM_METHOD)
        values
          (:new.patient_id,
           :new.visit_id,
           :new.oper_id,
           v_time_point,
           v_VITAL_SIGNS,
           v_VITAL_SIGNS_VALUE,
           v_VITAL_SIGNS_UNITS,
           1);
      exception
        when others then
          return;
      end;
    end if;
  end loop;

end;
/


create or replace trigger OPERATION_BILLS_ITEM_CHANGE
  after insert or update  on OPERATION_BILL_ITEMS
  for each row  --费用确认后没有修改及删除情况
when (new.VERIFIED_INDICATOR = 1)
declare
  v_patient_id  varchar2(10);
  v_visit_id    number(2);
  cnt           number(1);
begin
  v_patient_id := :new.patient_id;
  v_visit_id := :new.visit_id;
  select count(*)
    into cnt
    from PAT_FEE_CHANGED_T
   where patient_id = v_patient_id
     and visit_id = v_visit_id;
  if cnt <=0  then
    insert into PAT_FEE_CHANGED_T
      (patient_id,
       visit_id)
    values
      (v_patient_id, v_visit_id);
  end if;
exception
  when others then
    null;
end;
/


----------------------------------------
--  Changed trigger pacu_data_insert  --
----------------------------------------
create or replace trigger PACU_DATA_INSERT
  before insert on patient_monitor_data  
  for each row
  
when (NEW.DATA_TYPE='1' AND NEW.ITEM_NO>0)
declare
  v_TIME_POINT        date; --本次采集时间点
  v_VITAL_SIGNS       varchar2(6); --用于存放本次采集某体征参数代码
  v_VITAL_SIGNS_VALUE varchar2(16); --用于存放本次采集某体征值
  v_VITAL_SIGNS_UNITS varchar2(16); --用于存放本次采集某体征值单位
  v_VITAL_FUNCS       varchar2(240); --本床采集所有体征参数串，例如：44,  89,  90, 100, 188, 112,  92,  65,  66,  71,  77,  78,
  v_cur_vitals        varchar2(240); --本床本次采集体征值串

  i number;

  -- 用于获取以delimeter为分隔符的第occurance个子字符串
  function f_substr(str       IN VARCHAR2,
                    delimeter in varchar2,
                    occurance in number) return varchar2 is
    v_start number;
    v_end   number;
  BEGIN
    if occurance <= 0 then
      return '';
    end if;
  
    if occurance = 1 then
      v_start := 1;
    else
      if Instrb(str, delimeter, 1, occurance - 1) = 0 then
        return '';
      end if;
    
      v_start := Instrb(str, delimeter, 1, occurance - 1) +
                 lengthb(delimeter);
    
    end if;
  
    if v_start = lengthb(str) then
      return '';
    end if;
  
    if Instrb(str, delimeter, 1, occurance) = 0 then
      return '';
    end if;
  
    v_end := Instrb(str, delimeter, 1, occurance);
    if v_end = 0 then
      return '';
    end if;
  
    return trim(substrb(str, v_start, v_end - v_start));
  
  END;
begin
  -- 查找本次采集头信息
  begin
  
    SELECT substr(MONITOR_VALUE, 16)
      into v_VITAL_FUNCS
      from patient_monitor_data
     where DATA_TYPE = '1'
       and monitor_value not like '%.%'
       and patient_id = :new.patient_id
       and visit_id = :new.visit_id
       and oper_id = :new.oper_id;
 exception
   when no_data_found then
  begin
    SELECT substr(MONITOR_VALUE, 16)
      into v_VITAL_FUNCS
      from patient_monitor_data
     where DATA_TYPE = '0'
       and patient_id = :new.patient_id
       and visit_id = :new.visit_id
       and oper_id = :new.oper_id
       and item_no = 0;
  exception
    when others then
      return;
  end;
 end;

  -- 获取时间点信息，存入变量v_time_point
  v_time_point := to_date(substr(:new.MONITOR_VALUE, 1, 14),
                          'yy-mm-dd hh24:mi');

  -- 解析体征参数值
  v_cur_vitals := substr(:new.MONITOR_VALUE, 16);
  for i in 1 .. 50 loop
    v_VITAL_SIGNS_VALUE := f_substr(v_cur_vitals, ',', i);
    if v_VITAL_SIGNS_VALUE is null or v_VITAL_SIGNS_VALUE = '' then
      return;
    end if;
  
    if v_VITAL_SIGNS_VALUE not in ('0', '0.0', '0.', '.0', '0.00') then
    
      v_VITAL_SIGNS := f_substr(v_VITAL_FUNCS, ',', i);
      sys.dbms_output.put_line(v_VITAL_SIGNS);
      if v_VITAL_SIGNS is null or v_VITAL_SIGNS = '' then
        return;
      end if;
    
      begin
        select ITEM_UNIT
          into v_VITAL_SIGNS_UNITS
          FROM monitor_function_code
         WHERE ITEM_CODE = v_VITAL_SIGNS;
      exception
        when others then
          return;
      end;
    
      -- 插入术后复苏体征记录PACU_VITAL_SIGNS_REC
      begin
        insert into PACU_VITAL_SIGNS_REC
          (PATIENT_ID,
           VISIT_ID,
           OPER_ID,
           TIME_POINT,
           VITAL_SIGNS,
           VITAL_SIGNS_VALUE,
           UNITS,
           EXAM_METHOD)
        values
          (:new.patient_id,
           :new.visit_id,
           :new.oper_id,
           v_time_point,
           v_VITAL_SIGNS,
           v_VITAL_SIGNS_VALUE,
           v_VITAL_SIGNS_UNITS,
           1);
      exception
        when others then
          return;
      end;
    end if;
  end loop;

end;
/
