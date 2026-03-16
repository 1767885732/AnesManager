using System;
using System.Collections.Generic;
using System.Text;
using Wis.Anes.Framework.Documents.DefaultHandlers;
using Wis.Anes.Framework;
using Wis.Anes.Framework.Controls;
using System.Windows.Forms;
using System.Data;
using Wis.Anes.BusinessEntity;

namespace Wis.Anes.Custom.CustomProject.Default.ShouShuQingDianHandlers
{
    public class QingDianGridViewHandler : GridViewHandler
    {
        public override void BindDataToUI(MedGridView control, Dictionary<string, System.Data.DataTable> dataSources)
        {
            control.EnableHeadersVisualStyles = false;
            base.BindDataToUI(control, dataSources);
            control.Rows.Clear();
            //自动生成列
            control.AutoCreateColumns();
            InitGridSource(control, dataSources);
            for (int j = 0; j < control.Columns.Count; j++)
            {
                control.Columns[j].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            CareDocs.WIS_INSTRUMENT_INVENTORYDataTable dataTable = dataSources["WIS_INSTRUMENT_INVENTORY"] as CareDocs.WIS_INSTRUMENT_INVENTORYDataTable;
            int rowCount = control.LinesPerPage;
            for (int i = 0; i < rowCount; i++)
            {
                int index = control.Rows.Add();
                control.Rows[i].Tag = i;
            }
            if (dataTable.Rows.Count > 0)
            {
                foreach (CareDocs.WIS_INSTRUMENT_INVENTORYRow row in dataTable.Rows)
                {
                    if (row.Y_POSITION >= rowCount || row.Y_POSITION < 0) continue;
                    int x, y;
                    x = Convert.ToInt16(row.X_POSITION);
                    y = Convert.ToInt16(row.Y_POSITION);
                    control[x, y].Value = row.POSITION_VALUE;
                    control[x, y].Tag = row.POSITION_VALUE;
                }
            }
            //control.ReadOnly = true;
        }

        private void InitGridSource(MedGridView control, Dictionary<string, System.Data.DataTable> dataSources)
        {
            CareDocs.WIS_INSTRUMENT_INVENTORYDataTable dataTable = dataSources["WIS_INSTRUMENT_INVENTORY"] as CareDocs.WIS_INSTRUMENT_INVENTORYDataTable;
            if (dataTable != null && dataTable.Count == 0)
            {
                if (string.IsNullOrEmpty(control.DefaultDatas)) return;
                string defaultDatas = control.DefaultDatas;
                string[] rows = defaultDatas.Split(new string[] { "{}" }, StringSplitOptions.RemoveEmptyEntries);
                if (dataTable.Rows.Count > 0)//如果有记录
                {

                }
                else//没有记录 读取模板
                {

                    for (int i = 0; i < rows.Length; i++)
                    {
                        string[] rowdatas = rows[i].Split(new string[] { "[]" }, StringSplitOptions.None);
                        for (int j = 0; j < rowdatas.Length; j++)
                        {
                            try
                            {
                                if (string.IsNullOrEmpty(rowdatas[j])) continue;
                                CareDocs.WIS_INSTRUMENT_INVENTORYRow row = dataTable.NewWIS_INSTRUMENT_INVENTORYRow();
                                row.PAT_ID = ExtendApplicationContext.Current.PatientContext.PatientID;
                                row.VISIT_ID = ExtendApplicationContext.Current.PatientContext.VisitID;
                                row.OPER_ID = ExtendApplicationContext.Current.PatientContext.OperID;
                                row.X_POSITION = (decimal)j;
                                row.Y_POSITION = (decimal)i;
                                row.POSITION_VALUE = rowdatas[j];
                                dataTable.AddWIS_INSTRUMENT_INVENTORYRow(row);
                            }
                            catch (Exception ex)
                            {
                                ExceptionHandler.Handle(ex);
                            }
                        }
                    }
                    dataSources["WIS_INSTRUMENT_INVENTORY"] = dataTable;
                }
            }
            //int rowCount = control.LinesPerPage;
            //if (rowCount == 0)
            //{
            //    rowCount = dataSources["MED_PACKAGE_MASTER"].Rows.Count;
            //}
            //control.LinesPerPage = rowCount;
            //for (int i = 0; i < rowCount; i++)
            //{
            //    int index = control.Rows.Add();
            //    control.Rows[i].Tag = i;
            //}
            //if (control.Name == "ShouShuQingDianFJ")
            //{
            //    DataTable dataTable = dataSources["MED_PACKAGE_MASTER"];
            //    if (dataTable != null && dataTable.Rows.Count > 0)
            //    {
            //        foreach (DataRow row in dataTable.Rows)
            //        {
            //            for (int j = 0; j < control.RowCount; j++)
            //            {
            //                if (control[0, j].Value == null || (control[0, j].Value != null && string.IsNullOrEmpty(control[0, j].Value.ToString().Trim())))
            //                {
            //                    control[0, j].Value = row["BAR_CODE"].ToString();
            //                    control[0, j].Tag = row["BAR_CODE"].ToString();
            //                    control[1, j].Value = row["PACKAGE_NAME"].ToString();
            //                    control[1, j].Tag = control[1, j].Value;
            //                    if (row["STERILIZE_DATE"] != null && row["STERILIZE_DATE"] != DBNull.Value && !row["STERILIZE_DATE"].Equals(""))
            //                    {
            //                        control[2, j].Value = DateTime.Parse(row["STERILIZE_DATE"].ToString()).ToString("yyyy/MM/dd HH:mm");
            //                        control[2, j].Tag = control[2, j].Value;
            //                    }
            //                    if (row["TODAY_USE_TIMES"] != null && row["TODAY_USE_TIMES"] != DBNull.Value && !row["TODAY_USE_TIMES"].Equals(""))
            //                    {
            //                        control[3, j].Value = row["TODAY_USE_TIMES"].ToString();
            //                        control[3, j].Tag = control[3, j].Value;
            //                    }
            //                    if (row["EXP_DATE"] != null && row["EXP_DATE"] != DBNull.Value && !row["EXP_DATE"].Equals(""))
            //                    {
            //                        control[4, j].Value = DateTime.Parse(row["EXP_DATE"].ToString()).ToString("yyyy/MM/dd HH:mm");
            //                        control[4, j].Tag = control[4, j].Value;
            //                    }
            //                    if (row["PACKAGE_OPERATOR"] != null && row["PACKAGE_OPERATOR"] != DBNull.Value && !row["PACKAGE_OPERATOR"].Equals(""))
            //                    {
            //                        control[5, j].Value = row["PACKAGE_OPERATOR"].ToString();
            //                        control[5, j].Tag = control[5, j].Value;
            //                    }
            //                    break;
            //                }
            //            }
            //        }
            //    }
            //}
            //else
            //{
            //    DataTable dataTable = dataSources["MED_OPERATING_INSTRUMENTS_DISTINCT"];
            //    if (dataTable != null && dataTable.Rows.Count > 0)
            //    {
            //        foreach (DataRow row in dataTable.Rows)
            //        {
            //            bool isOK = false;
            //            for (int i = 0; i < control.MedGridViewColumns.Count; i++)
            //            {
            //                if (control.MedGridViewColumns[i].HeaderText == control.MedGridViewColumns[0].HeaderText)
            //                {
            //                    for (int j = 0; j < control.RowCount; j++)
            //                    {
            //                        if (control[i, j].Value == null || (control[i, j].Value != null && string.IsNullOrEmpty(control[i, j].Value.ToString().Trim())))
            //                        {
            //                            control[i, j].Value = row["ITEM_NAME"].ToString();
            //                            control[i, j].Tag = row["ITEM_NAME"].ToString();
            //                            control[i + 1, j].Value = row["QUANTITY2"].ToString();
            //                            control[i + 1, j].Tag = control[i + 1, j].Value;
            //                            if (row["QUANTITY4"] != null && row["QUANTITY4"] != DBNull.Value && !row["QUANTITY3"].Equals(""))
            //                            {
            //                                control[i + 2, j].Value = row["QUANTITY4"].ToString();
            //                                control[i + 2, j].Tag = control[i + 2, j].Value;
            //                            }
            //                            if (row["QUANTITY5"] != null && row["QUANTITY5"] != DBNull.Value && !row["QUANTITY5"].Equals(""))
            //                            {
            //                                control[i + 3, j].Value = row["QUANTITY5"].ToString();
            //                                control[i + 3, j].Tag = control[i + 3, j].Value;
            //                            }
            //                            isOK = true;
            //                            break;
            //                        }
            //                    }
            //                    if (isOK)
            //                    {
            //                        break;
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
        }

        public override void RefreshData()
        {
            //base.DataSource["MED_OPERATING_INSTRUMENTS_DISTINCT"] = DataContext.GetCurrent().GetData("MED_OPERATING_INSTRUMENTS_DISTINCT");
            base.RefreshData();
        }
    }
}
