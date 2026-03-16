using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.Framework.Documents;
using Wis.Anes.DataAccess;
using Wis.Anes.BusinessEntity;
using Wis.Anes.Framework;
using Wis.Anes.Custom.CustomProject.Default.PACUNurseRecordDocHandlers;
using Wis.Anes.Framework.Documents.DefaultHandlers;
using Wis.Anes.Framework.Doc;
using Wis.Anes.Framework.Controls;
using Wis.Anes.Custom.CustomProject.Framework;

namespace Wis.Anes.Custom.CustomProject.Default
{
    public partial class PACUNurseRecord : CustomBaseDoc
    {
        public PACUNurseRecord()
        {
            InitializeComponent();
            base.DocKind = DocKind.Default;
            base.ApplyDataTemplate.Visible = false;
            base.SaveDataTemplate.Visible = false;
        }

        /// <summary>
        /// 初始化自定义的UIElementHandler
        /// </summary>
        /// <param name="handlers"></param>
        protected override void AddCustomUIElementHandlers(List<IUIElementHandler> handlers)
        {
            IUIElementHandler handlerTemp = null;
            foreach (IUIElementHandler handler in handlers)
            {
                if (handler is GridViewHandler)
                {
                    handlerTemp = handler;
                    break;
                }
            }
            if (handlerTemp != null)
            {
                handlers.Remove(handlerTemp);
            }
            handlers.Add(new PACUGridViewHandler());
        }

        protected override void BuildData(Dictionary<string, DataTable> dataSource)
        {
            dataSource["WIS_OPER_MASTER"] = DataContext.GetCurrent().GetData("WIS_OPER_MASTER");
            dataSource["WIS_PAT_MASTER_INDEX"] = DataContext.GetCurrent().GetData("WIS_PAT_MASTER_INDEX");
            dataSource["WIS_PAT_IN_HOS"] = DataContext.GetCurrent().GetData("WIS_PAT_IN_HOS");
            dataSource["WIS_CUSTOM_DATA"] = DataContext.GetCurrent().GetData("WIS_CUSTOM_DATA");
            dataSource["MED_PACU_NURSE_RECORD"] = DataContext.GetCurrent().GetData("MED_PACU_NURSE_RECORD");
        }

        protected override void OnSaveData(Dictionary<string, DataTable> dataSource)
        {
            base.OnSaveData(dataSource);
            foreach (IUIElementHandler handler in _UIElementHandlers)
            {
                if (handler.GetControlType == typeof(MedGridView) && handler.GetCurrentControl != null)
                {
                    MedGridView grid = handler.GetCurrentControl as MedGridView;
                    string patientID = ExtendApplicationContext.Current.PatientContext.PatientID;
                    decimal visitID = ExtendApplicationContext.Current.PatientContext.VisitID;
                    decimal operID = ExtendApplicationContext.Current.PatientContext.OperID;
                    DataTable dataTable = dataSource["MED_PACU_NURSE_RECORD"];
                    for (int i = 0; i < grid.RowCount; i++)
                    {
                        for (int j = 0; j < grid.ColumnCount; j++)
                        {
                            DataGridViewCell cell = grid[j, i];
                            DataRow[] rows = dataTable.Select(" PATIENT_ID='" + patientID + "' AND VISIT_ID=" + visitID.ToString() + " AND OPER_ID=" + operID.ToString() + " AND X_POSITION=" + j.ToString() + " AND Y_POSITION=" + i.ToString());
                            string celltext = string.Empty;
                            if (cell.Value != null && !string.IsNullOrEmpty(cell.Value.ToString().Trim()))
                            {
                                celltext = cell.Value.ToString().Trim();
                            }
                            if (string.IsNullOrEmpty(celltext))
                            {
                                if (rows.Length == 1)
                                {
                                    rows[0].Delete();
                                }
                            }
                            else
                            {
                                DataRow row = null;
                                if (rows.Length == 0)
                                {
                                    row = dataTable.NewRow();
                                    row["PAT_ID"] = patientID;
                                    row["VISIT_ID"] = visitID;
                                    row["OPER_ID"] = operID;
                                    row["X_POSITION"] = (decimal)j;
                                    row["Y_POSITION"] = (decimal)i;
                                    dataTable.Rows.Add(row);
                                }
                                else
                                {
                                    row = rows[0];
                                }
                                row["POSITION_VALUE"] = celltext;
                            }
                        }
                    }
                    dataSource["MED_PACU_NURSE_RECORD"] = dataTable;
                }
            }
            CommonDA commonDA = new CommonDA();
            commonDA.Update(dataSource["WIS_OPER_MASTER"], "WIS_OPER_MASTER");
            commonDA.Update(dataSource["WIS_PAT_MASTER_INDEX"], "WIS_PAT_MASTER_INDEX");
            commonDA.Update(dataSource["WIS_CUSTOM_DATA"], "WIS_CUSTOM_DATA");
            commonDA.Update(dataSource["MED_PACU_NURSE_RECORD"], "MED_PACU_NURSE_RECORD");
        }

        protected override void OnViewBuilded(List<IUIElementHandler> handlers, Dictionary<string, DataTable> dataSources)
        {

            foreach (IUIElementHandler handler in _UIElementHandlers)
            {
                handler.HasDirty = false;
            }
        }

        /// <summary>
        /// 自定义刷新数据时候触发事件
        /// </summary>
        /// <param name="currentPageIndex"></param>
        /// <param name="isMasterPage"></param>
        /// <param name="dataSource"></param>
        protected override void OnAfterRefreshData()
        {
            foreach (IUIElementHandler handler in _UIElementHandlers)
            {
                handler.HasDirty = false;
            }
        }
    }
}
