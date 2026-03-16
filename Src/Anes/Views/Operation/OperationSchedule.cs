
//手术排台
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Wis.Anes.DataAccess;
using Wis.Anes.BusinessEntity;
using Wis.Anes.Framework.Configurations;
using Wis.Anes.Framework.Documents;
using Wis.Anes.Framework.Views;
using Wis.Anes.Framework;
using Wis.Anes.ServiceProxies;
using Wis.Anes.Layouts;
using Wis.Anes.Framework.Utilities;

using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;



namespace Wis.Anes.Views
{
    public delegate bool UpdateStateOperationStatusDelegate(OperationStatus status);

    public partial class OperationSchedule : Wis.Anes.Framework.Views.BaseView
    {
        //protected DataRow _selectRow = null; // 操作的行 
        protected DateTime _scheduleDate;
        protected List<int> _focusRowHandle = new List<int>();

        public OperationSchedule(DateTime dt)
        {
            InitializeComponent();
            _scheduleDate = dt;

            //dt = SetLabelPosition(dt);

            dateTimePickerQuery.DateTime = dt;

            RefreshDataSource(false);
        }

        //2014-5-30 周青 设置手术排台的位置
        /// <summary>
        /// 设置手术排台的位置
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private DateTime SetLabelPosition(DateTime dt)
        {
            labelControlName.Text = dt.ToLongDateString() + "手术排台";
            labelControlName.Location.Offset(btnHisInfo.Location.X + 10, btnHisInfo.Location.Y);
            Graphics tmpG = this.CreateGraphics();
            SizeF size = tmpG.MeasureString(labelControlName.Text, labelControlName.Font);
            float StringWidth = size.Width;

            labelControlName.Width = int.Parse(Math.Ceiling(StringWidth).ToString());
            return dt;
        }

        public DateTime SelectedDate
        {
            get { return dateTimePickerQuery.DateTime.Date; }
        }

        protected void RefreshDataSource(bool holdindex)
        {
            CommonDA da = new CommonDA();
            //string sql = @"select rownum, t.* from schedulereportview t where to_char(SCHEDULED_DATE_TIME, 'yyyyMMdd') = '" + _scheduleDate.ToString("yyyyMMdd") +
            //    "' order by ANES_DOCTOR_NAME, SCHEDULED_DATE_TIME, OPERATING_ROOM_NO, OPERATING_ROOM_NO_SEQUENCE";
            string sql = @"select  row_number() over(order by ANES_DOCTOR_NAME, SCHEDULED_DATE_TIME, OPERATING_ROOM_NO, OPERATING_ROOM_NO_SEQUENCE) as rownum, t.* from WIS_VW_SCHEDULE_REPORT t where CONVERT(varchar(100), SCHEDULED_DATE_TIME, 112) = '" + _scheduleDate.ToString("yyyyMMdd") +
                "' order by ANES_DOCTOR_NAME, SCHEDULED_DATE_TIME, OPERATING_ROOM_NO, OPERATING_ROOM_NO_SEQUENCE";

            DataTable dt = da.GetDataFromSQLString(sql);


            int topindex = gridViewLeftList.TopRowIndex;

            SetFilter(dt);
            DataSource = dt;

            if (holdindex && topindex < gridViewLeftList.RowCount)
                gridViewLeftList.TopRowIndex = topindex;

            //_selectRow = null;
        }

        public DataTable DataSource
        {
            get
            {
                if (gridControlList != null && gridControlList.DataSource != null && gridControlList.DataSource is DataView)
                {
                    return (gridControlList.DataSource as DataView).Table;
                }
                return null;
            }
            set
            {
                if (gridControlList != null)
                {
                    gridControlList.DataSource = value.DefaultView;
                }
            }
        }


        private void gridViewLeftList_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            GridView view = gridControlList.MainView as GridView;
            if (view == null)
                return;
            //Console.Write(" " + e.CellValue + " ");
            //if (e.Column.Caption == "手术间")
            //    return;


            //DataRow row = view.GetDataRow(e.RowHandle);
            GridViewInfo vInfo = view.GetViewInfo() as GridViewInfo;

            try
            {
                GridCellInfo info = e.Cell as DevExpress.XtraGrid.Views.Grid.ViewInfo.GridCellInfo;

                if (_focusRowHandle.Contains(e.RowHandle))
                {
                    GridMergedCellInfo mInfo = info.RowInfo.Cells[info.Column].MergedCell;
                    if (mInfo == null)
                    {
                        e.Appearance.BackColor2 = Color.FromArgb(204, 255, 204);
                        e.Appearance.BackColor = Color.FromArgb(204, 255, 204);
                        e.Appearance.ForeColor = Color.Black;
                    }
                    else
                    {
                        // 如果有一个cell不在选中行内，则特殊显示此行
                        for (int i = 0; i < mInfo.MergedCells.Count; i++)
                        {
                            if (!_focusRowHandle.Contains(mInfo.MergedCells[i].RowHandle))
                                return;
                        }

                        e.Appearance.BackColor2 = Color.FromArgb(204, 255, 204);
                        e.Appearance.BackColor = Color.FromArgb(204, 255, 204);
                        e.Appearance.ForeColor = Color.Black;
                    }
                }
            }
            catch (Exception err)
            {
                //ExceptionHandler.Handle(err);
            }
        }

        private void OperationProcess_Load(object sender, EventArgs e)
        {

        }

        private void gridViewLeftList_RowClick(object sender, RowClickEventArgs e)
        {
            //if (e.Button == MouseButtons.Left)
            //    return;

            _focusRowHandle.Clear();


            GridView view = gridControlList.MainView as GridView;
            if (view == null)
                return;

            if (view.FocusedColumn == null)
                return;

            GridViewInfo vInfo = view.GetViewInfo() as GridViewInfo;
            GridDataRowInfo rInfo = vInfo.GetGridRowInfo(e.RowHandle) as GridDataRowInfo;
            GridCellInfo cInfo = rInfo.Cells[view.FocusedColumn];

            if (cInfo != null && cInfo.MergedCell != null)
            {
                for (int i = 0; i < cInfo.MergedCell.MergedCells.Count; i++)
                {
                    _focusRowHandle.Add(cInfo.MergedCell.MergedCells[i].RowHandle);
                }
            }
            else
            {
                _focusRowHandle.Add(e.RowHandle);
            }

            view.RefreshData();

            if (e.Button == MouseButtons.Right && _focusRowHandle.Count == 1)
                contextMenuStripInfo.Show(gridControlList, e.X, e.Y);

        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            RefreshDataSource(true);
        }


        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = DataSource;
            if (dt == null)
                return;

            SetFilter(dt);

            RefreshData();
        }

        protected void SetFilter(DataTable dt)
        {
            string filter = string.Format("Operating_Room = '{0}'", ApplicationConfiguration.OpertionDeptCode);

            if (!string.IsNullOrEmpty(txtOtherUse.Text))
            {
                filter += " and " + string.Format(@"ANES_DOCTOR_NAME = '{0}' or ANES_ASSISTANT_NAME = '{0}' or ANES_ASSISTANT_NAME2 = '{0}' 
                 or FIRST_OPER_NURSE_NAME like '%{0}%' or FIRST_SUPPLY_NURSE_NAME like '%{0}%'", txtOtherUse.Text);

            }
            else if (radioType.SelectedIndex == 1)
            {
                filter += " and " + string.Format(@"ANES_DOCTOR_NAME = '{0}' or ANES_ASSISTANT_NAME = '{0}' or ANES_ASSISTANT_NAME2 = '{0}' 
                 or FIRST_OPER_NURSE_NAME like '%{0}%' or FIRST_SUPPLY_NURSE_NAME like '%{0}%'", ExtendApplicationContext.Current.LoginUserContext.UserName);
            }

            dt.DefaultView.RowFilter = filter;
            dt.DefaultView.Sort = "SCHEDULED_DATE_TIME, OPERATING_ROOM_NO, OPERATING_ROOM_NO_SEQUENCE, ANES_DOCTOR_NAME ";

            //int index = 1;
            //foreach (DataRowView rowv in dt.DefaultView)
            //{
            //    rowv["ROWNUM"] = index++;
            //}
        }

        private void txtOtherUse_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = DataSource;
            if (dt == null)
                return;

            SetFilter(dt);

            RefreshData();
        }

        private void dateTimePickerQuery_EditValueChanged(object sender, EventArgs e)
        {
            _scheduleDate = dateTimePickerQuery.DateTime;

            //设置手术排台的位置
            SetLabelPosition(_scheduleDate); 
            //labelControlName.Text = _scheduleDate.ToLongDateString() + "手术排台";

            RefreshDataSource(false);
        }

        private void gridViewLeftList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                GridView view = gridControlList.MainView as GridView;
                if (view == null)
                    return;

                if (view.FocusedRowHandle < 0)
                    return;

                DataRow row = view.GetDataRow(view.FocusedRowHandle);

                AnesInformations.OperationMasterDataTable mt = (new AnesthesiaSheetDA()).GetOperationMaster(row["PAT_ID"].ToString());
                mt.Columns.Add("NAME");
                mt.Columns.Add("INP_NO");
                mt.DefaultView.Sort = "VISIT_ID,OPER_ID";
                if (mt.DefaultView.Count == 0)
                {
                    return;
                }


                DataRowView rowView = mt.DefaultView[mt.DefaultView.Count - 1];
                rowView["NAME"] = row["PAT_NAME"];
                rowView["INP_NO"] = row["INP_NO"];
                PatientInformation patientInformation = new PatientInformation(rowView.Row);

                ExtendApplicationContext.Current.PatientContext.PatientID = patientInformation.PatientID;
                ExtendApplicationContext.Current.PatientContext.VisitID = patientInformation.VisitID;
                ExtendApplicationContext.Current.PatientContext.OperID = patientInformation.OperID;

                ExtendApplicationContext.Current.PatientInformation = patientInformation;
                ParentForm.DialogResult = DialogResult.OK;
                FirePatientSelectedEvent();
            }
            catch (Exception err)
            {
                ExceptionHandler.Handle(err);
            }
        }

        public event EventHandler PatientSelected;

        public void FirePatientSelectedEvent()
        {
            if (PatientSelected != null)
                PatientSelected(null, EventArgs.Empty);
        }


        protected void ShowPatientInfo()
        {
            try
            {
                if (_focusRowHandle.Count != 1)
                {
                    Dialog.MessageBox("没有选择患者，或者选择的患者不唯一");
                    return;
                }


                DataRow row = gridViewLeftList.GetDataRow(_focusRowHandle[0]);
                if (row == null)
                    return;

                string pateintId = row["PAT_ID"].ToString();
                decimal visitId = Convert.ToDecimal(row["VISIT_ID"]);
                decimal operId = Convert.ToDecimal(row["SCHEDULE_ID"]);

                if (!string.IsNullOrEmpty(pateintId))
                {
                    PatientEMRInfo info = new PatientEMRInfo(pateintId, visitId);
                    DialogHostForm dialogHostForm = new DialogHostForm("患者信息", 900, 720);
                    dialogHostForm.Child = info;
                    //info.Initial();
                    dialogHostForm.ShowDialog();
                }
            }
            catch (Exception err)
            {
                ExceptionHandler.Handle(err);
            }
        }

        private void btnHisInfo_Click(object sender, EventArgs e)
        {
            ShowPatientInfo();
        }

        private void menuInfo_Click(object sender, EventArgs e)
        {
            ShowPatientInfo();
        }



    }
}
