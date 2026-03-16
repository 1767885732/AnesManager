using System;
using System.Collections.Generic;
using System.Text;
using Wis.Anes.Framework.Documents.DefaultHandlers;
using System.Data;
using Wis.Anes.Framework;
using Wis.Anes.Framework.Configurations;
using System.Windows.Forms;
using Wis.Anes.Framework.Controls;

namespace Wis.Anes.Custom.CustomProject.Default.PACUNurseRecordDocHandlers
{
    public class PACUGridViewHandler : GridViewHandler
    {
        public override void BindDataToUI(MedGridView control, Dictionary<string, System.Data.DataTable> dataSources)
        {
            control.EnableHeadersVisualStyles = false;
            control.Rows.Clear();
            control.AutoCreateColumns();
            for (int i = 0; i < control.Columns.Count; i++)
            {
                if (control != null && (control.Columns[i].HeaderText == "时间"))
                {
                    DateEditingColumn column = new DateEditingColumn();
                    column.HeaderText = control.Columns[i].HeaderText;
                    column.Width = control.Columns[i].Width;
                    column.DataPropertyName = control.Columns[i].DataPropertyName;
                    column.DisplayFormat = "MM-dd hh:mm";
                    column.Mask = "t";


                    control.Columns.RemoveAt(i);
                    control.Columns.Insert(i, column);
                    break;
                }
            }
            for (int j = 0; j < control.Columns.Count; j++)
            {
                control.Columns[j].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            InitGridSource(control, dataSources);
        }

        private void InitGridSource(MedGridView control, Dictionary<string, System.Data.DataTable> dataSources)
        {
            int rowCount = control.LinesPerPage;
            for (int i = 0; i < rowCount; i++)
            {
                int index = control.Rows.Add();
                control.Rows[i].Tag = i;
            }
            DataTable dataTable = dataSources["MED_PACU_NURSE_RECORD"];
            //if (dataTable.Rows.Count == 0)//没有记录 读取模板
            //{
            //    string defaultDatas = ApplicationConfiguration.AnesChargeDefaultItems;
            //    if (!string.IsNullOrEmpty(defaultDatas))
            //    {
            //        string[] rows = defaultDatas.Split(new string[] { "{}" }, StringSplitOptions.RemoveEmptyEntries);
            //        if (rows != null && rows.Length > 0)
            //        {
            //            for (int i = 0; i < rows.Length; i++)
            //            {
            //                string[] rowdatas = rows[i].Split(new string[] { "[]" }, StringSplitOptions.None);
            //                for (int j = 0; j < rowdatas.Length; j++)
            //                {
            //                    try
            //                    {
            //                        if (string.IsNullOrEmpty(rows[i])) continue;
            //                        DataRow row = dataTable.NewRow();
            //                        row["PAT_ID"] = ExtendApplicationContext.Current.PatientContext.PatientID;
            //                        row["VISIT_ID"] = ExtendApplicationContext.Current.PatientContext.VisitID;
            //                        row["OPER_ID"] = ExtendApplicationContext.Current.PatientContext.OperID;
            //                        row["X_POSITION"] = (decimal)j;
            //                        row["Y_POSITION"] = (decimal)i;
            //                        row["POSITION_VALUE"] = rowdatas[j];
            //                        dataTable.Rows.Add(row);
            //                    }
            //                    catch (Exception ex)
            //                    {
            //                        ExceptionHandler.Handle(ex);
            //                    }
            //                }
            //            }
            //            dataSources["MED_PACU_NURSE_RECORD"] = dataTable;
            //        }
            //    }
            //}
            if (dataTable.Rows.Count > 0)//如果有记录
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    if ((decimal)row["Y_POSITION"] >= rowCount || (decimal)row["Y_POSITION"] < 0) continue;
                    int x, y;
                    x = Convert.ToInt16(row["X_POSITION"]);
                    y = Convert.ToInt16(row["Y_POSITION"]);
                    control[x, y].Value = row["POSITION_VALUE"];
                    control[x, y].Tag = row["POSITION_VALUE"];
                }
            }
        }
    }
}
