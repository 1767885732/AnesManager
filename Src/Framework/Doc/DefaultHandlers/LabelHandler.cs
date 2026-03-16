using System;
using System.Collections.Generic;
using System.Text;
using Wis.Anes.Framework.Controls;
using Wis.Anes.BusinessEntity;
using Wis.Anes.DataAccess;
using Wis.Anes.Framework.Configurations;
using System.Data;
using System.Drawing;

namespace Wis.Anes.Framework.Documents.DefaultHandlers
{
   public class LabelHandler:UIElementHandler<MLabel>
    {
       public override void BindDataToUI(MLabel control, Dictionary<string, System.Data.DataTable> dataSources)
       {
           if (control.Text.Contains("<%=DeptName%>"))
           {
               control.Text = control.Text.Replace("<%=DeptName%>", GetDeptName());
           }
           if (control.Name == "PageIndex")
           {
               control.Text = string.Format("{0}/{1}", PagerSetting.CurrentPageIndex + 1, PagerSetting.TotalPageCount);
           }
           
       }
       public override void ControlSetting(MLabel control)
       {
           control.BackColor = Color.White;
       }
       private string GetDeptName()
       {
           string patientID = ExtendApplicationContext.Current.PatientContext.PatientID;
           decimal visitID = ExtendApplicationContext.Current.PatientContext.VisitID;
           decimal operID = ExtendApplicationContext.Current.PatientContext.OperID; 

           string deptCode = GetDeptCode(patientID, visitID, operID);
           if (string.IsNullOrEmpty(deptCode))
           {
               deptCode = "";
           }
           else
           {
              
              if (!ExtendApplicationContext.Current.CodeTables.ContainsKey("WIS_DICT_DEPT"))
                  throw new NotImplementedException(string.Format("当前上下文缓存中不存在名为{0}的字典表", "WIS_DICT_DEPT"));

                //Dict.DeptDictDataTable deptDict = ExtendApplicationContext.Current.CodeTables["WIS_DICT_DEPT"] as Dict.DeptDictDataTable;
                DataTable deptDict = ExtendApplicationContext.Current.CodeTables["WIS_DICT_DEPT"];
               DataRow[] rows = deptDict.Select("DEPT_CODE = '" + deptCode + "'");
               if (rows != null && rows.Length > 0)
               {
                   object obj = rows[0]["DEPT_NAME"];
                   if (obj != System.DBNull.Value)
                   {
                       return obj.ToString();
                   }
               }
           }
           return deptCode;
       }

       private   string GetDeptCode(string patientID, decimal visitID, decimal operID)
       {
           if (!DataSource.ContainsKey("WIS_OPER_MASTER"))
               throw new NotImplementedException(string.Format("在数据源中未找到名为{0}的表AnesInformations.OperationMasterDataTable,请添加此绑定数据源!", "WIS_OPER_MASTER"));

           AnesInformations.OperationMasterDataTable operationMaster = base.DataSource["WIS_OPER_MASTER"] as AnesInformations.OperationMasterDataTable;

           if (operationMaster != null && operationMaster.Count > 0)
           {
               PatientInformationsDA patientInformationsDA = new PatientInformationsDA();
               PatientBaseInformations.PatsInHospitalDataTable dt = patientInformationsDA.GetPatsInHospital(operationMaster[0].PAT_ID, operationMaster[0].VISIT_ID);
               if (dt != null && dt.Count > 0 && !dt[0].IsDEPT_CODENull())
               {
                   return dt[0].DEPT_CODE;
               }
           }

           return ApplicationConfiguration.OpertionDeptCode;
       }

       
    }
}
