using System;
using System.Collections.Generic;
using System.Text;
using Wis.Anes.BusinessEntity;
using Wis.Anes.Interface;
using Wis.Anes.DataAccess;
using System.Data;

namespace Wis.Anes.BusinessComponent
{
    public class CPBBC:ICPB
    {
        public CPB.CPBBlgRecordDataTable GetCPBBlgRecordTable(string patient_id, decimal visit_id, decimal oper_id)
        {
            return (new CpbDA()).GetCPBBlgRecordTable(patient_id, visit_id, oper_id);
        }

        public int UpdateCPBBlgRecordTable(CPB.CPBBlgRecordDataTable CPBBlgRecordDataTable)
        {
            return (new CpbDA()).UpdateCPBBlgRecordTable(CPBBlgRecordDataTable);
        }
        public CPB.CPBPreCheckRecordDataTable GetCPBPreCheckRecord()
        {
            return (new CpbDA()).GetCPBPreCheckRecord();
        }
        public CPB.CPBPreCheckRecordDataTable GetCPBPreCheckRecord(string patient_id, decimal visit_id, decimal oper_id)
        {
            return (new CpbDA()).GetCPBPreCheckRecord(patient_id, visit_id, oper_id);
        }
        public int UpdateCPBPreCheckRecord(CPB.CPBPreCheckRecordDataTable dataTable)
        {
            return (new CpbDA()).UpdateCPBPreCheckRecord(dataTable);
        }
        public CPB.CPBPrimingDataDataTable GetCPBPrimingData(string patient_id, decimal visit_id, decimal oper_id)
        {
            return (new CpbDA()).GetCPBPrimingData(patient_id, visit_id, oper_id);
        }
        public CPB.CPBInputDictDataTable GetCPBInputDict()
        {
            return (new CpbDA()).GetCPBInputDict();
        }

        public CPB.CPBInputDictDataTable GetCPBInputDict(string itemClass)
        {
            return (new CpbDA()).GetCPBInputDict(itemClass);
        }

        public int UpdateCPBInputDict(CPB.CPBInputDictDataTable dataTable)
        {
            return (new CpbDA()).UpdateCPBInputDict(dataTable);
        }

        public CPB.CPBEventOpenDataTable GetCPBEventOpen()
        {
            return (new CpbDA()).GetCPBEventOpen();
        }

        public CPB.CPBEventOpenDataTable GetCPBEventOpen(string itemClass)
        {
            return (new CpbDA()).GetCPBEventOpen(itemClass);
        }

        public int UpdateCPBEventOpen(CPB.CPBEventOpenDataTable dataTable)
        {
            return (new CpbDA()).UpdateCPBEventOpen(dataTable);
        }

        public CPB.CPBMethodDictDataTable GetCPBMethodDict()
        {
            return (new CpbDA()).GetCPBMethodDict();
        }

        public int UpdateCPBMethodDict(CPB.CPBMethodDictDataTable dataTable)
        {
            return (new CpbDA()).UpdateCPBMethodDict(dataTable);
        }
        public void UpdateCPBEvents(DataTable data)
        {
             (new CpbDA()).UpdateCPBEvents(data);
        }
    }
}
