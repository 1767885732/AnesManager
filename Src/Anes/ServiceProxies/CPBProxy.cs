using System;
using System.Collections.Generic;
using System.Text;
using Wis.Anes.Interface;
using Wis.Anes.BusinessComponent;
using Wis.Anes.BusinessEntity;

namespace Wis.Anes.ServiceProxies
{
    public class CPBProxy
    {
        static ICPB _iCPB = new CPBBC();
        public static CPB.CPBBlgRecordDataTable GetCPBBlgRecordTable(string patient_id, decimal visit_id, decimal oper_id)
        {
            try
            {
                return _iCPB.GetCPBBlgRecordTable(patient_id, visit_id, oper_id);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static int UpdateCPBBlgRecordTable(CPB.CPBBlgRecordDataTable dataTable)
        {
            try
            {
                return _iCPB.UpdateCPBBlgRecordTable(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static CPB.CPBPreCheckRecordDataTable GetCPBPreCheckRecord()
        {
            try
            {
                return _iCPB.GetCPBPreCheckRecord();
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }
        public static CPB.CPBPreCheckRecordDataTable GetCPBPreCheckRecord(string patient_id, decimal visit_id, decimal oper_id)
        {
            try
            {
                return _iCPB.GetCPBPreCheckRecord(patient_id, visit_id, oper_id);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }
        public static int UpdateCPBPreCheckRecord(CPB.CPBPreCheckRecordDataTable dataTable)
        {
            try
            {
                return _iCPB.UpdateCPBPreCheckRecord(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static CPB.CPBPrimingDataDataTable GetCPBPrimingData(string patient_id, decimal visit_id, decimal oper_id)
        {
            try
            {
                return _iCPB.GetCPBPrimingData(patient_id, visit_id, oper_id);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }
        public static CPB.CPBInputDictDataTable GetCPBInputDict()
        {
            try
            {
                return _iCPB.GetCPBInputDict();
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static CPB.CPBInputDictDataTable GetCPBInputDict(string itemClass)
        {
            try
            {
                return _iCPB.GetCPBInputDict(itemClass);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static int UpdateCPBInputDict(CPB.CPBInputDictDataTable dataTable)
        {
            try
            {
                return _iCPB.UpdateCPBInputDict(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }


        public static CPB.CPBEventOpenDataTable GetCPBEventOpen()
        {
            try
            {
                return _iCPB.GetCPBEventOpen();
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static CPB.CPBEventOpenDataTable GetCPBEventOpen(string itemClass)
        {
            try
            {
                return _iCPB.GetCPBEventOpen(itemClass);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static int UpdateCPBEventOpen(CPB.CPBEventOpenDataTable dataTable)
        {
            try
            {
                return _iCPB.UpdateCPBEventOpen(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }
        public static CPB.CPBMethodDictDataTable GetCPBMethodDict()
        {
            try
            {
                return _iCPB.GetCPBMethodDict();
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static int UpdateCPBMethodDict(CPB.CPBMethodDictDataTable dataTable)
        {
            try
            {
                return _iCPB.UpdateCPBMethodDict(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }
    }
}
