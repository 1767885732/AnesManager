using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.Framework.Documents;
using Wis.Anes.Framework;
using Wis.Anes.Framework.Doc;
using Wis.Anes.Framework.Documents.DefaultHandlers;
using Wis.Anes.DataAccess;
using Wis.Anes.Custom.CustomProject.Default.ShouShuQingDianHandlers;
using Wis.Anes.Framework.Controls;
using Wis.Anes.BusinessEntity;
using Wis.Anes.Custom.CustomProject.Framework;

namespace Wis.Anes.Custom.CustomProject.Default
{
    public partial class ShouShuQingDian : CustomBaseDoc
    {
        public ShouShuQingDian()
        {
            InitializeComponent();
            base.DocKind = DocKind.Default;
            base.ApplyDataTemplate.Visible = true;
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
            QingDianGridViewHandler gridViewHandler = new QingDianGridViewHandler();
            //gridViewHandler.OnRefreshTotalScore += new SYRMGridViewHandler.RefreshTotalScore(OnRefreshTotalScore);
            handlers.Add(gridViewHandler);
        }

        protected override void BuildData(Dictionary<string, DataTable> dataSource)
        {
            dataSource["WIS_OPER_MASTER"] = DataContext.GetCurrent().GetData("WIS_OPER_MASTER");
            dataSource["WIS_PAT_MASTER_INDEX"] = DataContext.GetCurrent().GetData("WIS_PAT_MASTER_INDEX");
            dataSource["WIS_PAT_IN_HOS"] = DataContext.GetCurrent().GetData("WIS_PAT_IN_HOS");
            dataSource["WIS_CUSTOM_DATA"] = DataContext.GetCurrent().GetData("WIS_CUSTOM_DATA");
            dataSource["WIS_ANES_PLAN"] = DataContext.GetCurrent().GetData("WIS_ANES_PLAN");
            dataSource["WIS_ANES_SUMMARY"] = DataContext.GetCurrent().GetData("WIS_ANES_SUMMARY");
            dataSource["WIS_INSTRUMENT_INVENTORY"] = DataContext.GetCurrent().GetData("WIS_INSTRUMENT_INVENTORY");
            dataSource["WIS_ANES_OPER_HANDOVER"] = DataContext.GetCurrent().GetData("WIS_ANES_OPER_HANDOVER");
            //dataSource["MED_OPERATING_INSTRUMENTS_DISTINCT"] = DataContext.GetCurrent().GetData("MED_OPERATING_INSTRUMENTS_DISTINCT");
            //dataSource["MED_PACKAGE_MASTER"] = DataContext.GetCurrent().GetData("MED_PACKAGE_MASTER");
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
                    CareDocs.WIS_INSTRUMENT_INVENTORYDataTable dataTable = dataSource["WIS_INSTRUMENT_INVENTORY"] as CareDocs.WIS_INSTRUMENT_INVENTORYDataTable;
                    CareDocs.WIS_INSTRUMENT_INVENTORYRow row = null;
                    for (int i = 0; i < grid.RowCount; i++)
                    {
                        for (int j = 0; j < grid.ColumnCount; j++)
                        {
                            DataGridViewCell cell = grid[j, i];
                            row = dataTable.FindByPAT_IDVISIT_IDOPER_IDX_POSITIONY_POSITION(patientID, visitID, operID, (decimal)j, (decimal)i);
                            string celltext = string.Empty;
                            if (cell.Value != null && !string.IsNullOrEmpty(cell.Value.ToString().Trim()))
                            {
                                celltext = cell.Value.ToString().Trim();
                            }
                            if (string.IsNullOrEmpty(celltext))
                            {
                                if (row != null)
                                {
                                    row.Delete();
                                }
                            }
                            else
                            {
                                if (row == null)
                                {
                                    row = dataTable.NewWIS_INSTRUMENT_INVENTORYRow();
                                    row.PAT_ID = patientID;
                                    row.VISIT_ID = visitID;
                                    row.OPER_ID = operID;
                                    row.X_POSITION = (decimal)j;
                                    row.Y_POSITION = (decimal)i;
                                    dataTable.AddWIS_INSTRUMENT_INVENTORYRow(row);
                                }
                                row.POSITION_VALUE = celltext;
                            }
                        }
                    }
                    dataSource["WIS_INSTRUMENT_INVENTORY"] = dataTable;
                }
            }
            CommonDA commonDA = new CommonDA();
            commonDA.Update(dataSource["WIS_OPER_MASTER"], "WIS_OPER_MASTER");
            commonDA.Update(dataSource["WIS_PAT_MASTER_INDEX"], "WIS_PAT_MASTER_INDEX");
            commonDA.Update(dataSource["WIS_CUSTOM_DATA"], "WIS_CUSTOM_DATA");
            commonDA.Update(dataSource["WIS_ANES_PLAN"], "WIS_ANES_PLAN");
            commonDA.Update(dataSource["WIS_ANES_SUMMARY"], "WIS_ANES_SUMMARY");
            commonDA.Update(dataSource["WIS_INSTRUMENT_INVENTORY"], "WIS_INSTRUMENT_INVENTORY");
            commonDA.Update(dataSource["WIS_ANES_OPER_HANDOVER"], "WIS_ANES_OPER_HANDOVER");

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
