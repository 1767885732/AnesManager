/*----------------------------------------------------------------
 // Copyright (C) 2007 北京拓扑工厂科技发展有限公司
 // 文件名：ICPB.cs
 // 文件功能描述：
 //      体外循环接口类
 // 
 // 创建标识：
 //     XXX 2011-2-22
 // 修改标识：
 // 修改描述：
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using Wis.Anes.BusinessEntity;
using System.Data;

namespace Wis.Anes.Interface
{
    /// <summary>
    /// 体外循环接口类
    /// </summary>
    public interface ICPB
    {
        CPB.CPBBlgRecordDataTable GetCPBBlgRecordTable(string patient_id, decimal visit_id, decimal oper_id);
        int UpdateCPBBlgRecordTable(CPB.CPBBlgRecordDataTable dataTable);

        CPB.CPBPreCheckRecordDataTable GetCPBPreCheckRecord();
        CPB.CPBPreCheckRecordDataTable GetCPBPreCheckRecord(string patient_id, decimal visit_id, decimal oper_id);
        int UpdateCPBPreCheckRecord(CPB.CPBPreCheckRecordDataTable dataTable);
        CPB.CPBPrimingDataDataTable GetCPBPrimingData(string patient_id, decimal visit_id, decimal oper_id);

        CPB.CPBInputDictDataTable GetCPBInputDict();
        CPB.CPBInputDictDataTable GetCPBInputDict(string itemClass);
        int UpdateCPBInputDict(CPB.CPBInputDictDataTable dataTable);

        CPB.CPBEventOpenDataTable GetCPBEventOpen();
        CPB.CPBEventOpenDataTable GetCPBEventOpen(string itemClass);
        int UpdateCPBEventOpen(CPB.CPBEventOpenDataTable dataTable);

        CPB.CPBMethodDictDataTable GetCPBMethodDict();
        int UpdateCPBMethodDict(CPB.CPBMethodDictDataTable dataTable);

        void UpdateCPBEvents(DataTable data);
    }
}
