 
 select 'DROP PUBLIC SYNONYM '||OBJECT_NAME||';' from all_objects where owner in ('MEDCOMM','MEDICU','MEDSURGERY') AND OBJECT_TYPE IN ('TABLE','VIEW');
 select 'DROP '||OBJECT_TYPE||'  '||owner||'.'||OBJECT_NAME||';' from all_objects where owner in ('MEDCOMM','MEDICU','MEDSURGERY') AND OBJECT_TYPE IN ('TABLE','VIEW');
 