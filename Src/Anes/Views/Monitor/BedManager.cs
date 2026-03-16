using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.Framework;
using Wis.Anes.BusinessEntity;
using Wis.Anes.ServiceProxies;

namespace Wis.Anes.Views
{
    [ToolboxItem(false)]
    public partial class BedManager : UserControl
    {
        public object DialogResultData;
        private class PatInfo : Panel
        {
            private PatientInformation _patientInformation;
            public PatientInformation PatientInformation
            {
                get
                {
                    return _patientInformation;
                }
                set
                {
                    _patientInformation = value;
                }
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                byte colorOffSet = 15;
                Color color = Color.FromArgb(221,221,221);
                //if (string.IsNullOrEmpty(_PatientBaseInformations.PatientID)) color = Color.LawnGreen;
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                byte r = color.R, g = color.G, b = color.B;
                if (r > colorOffSet) r -= colorOffSet;
                if (g > colorOffSet) g -= colorOffSet;
                if (b > colorOffSet) b -= colorOffSet;
                Color bedColor = Color.FromArgb(r, g, b);
                Rectangle rect = ClientRectangle;
                e.Graphics.FillRectangle(new SolidBrush(color),rect);
                ControlPaint.DrawBorder3D(e.Graphics, rect);
                Font ft = new Font("Arial",36,FontStyle.Bold);
                string text = "";
                if (!string.IsNullOrEmpty(_patientInformation.BedLabel))
                {
                    text = _patientInformation.BedLabel;
                }
                else
                {
                    text = _patientInformation.OperRoom;
                }
                //e.Graphics.DrawString(text, ft, new SolidBrush(bedColor), (rect.Width - e.Graphics.MeasureString(text, ft).Width) / 2
                //    , (rect.Height - e.Graphics.MeasureString(text, ft).Height) / 2);
                rect.Y = (int)((rect.Height - e.Graphics.MeasureString(text, ft).Height) / 2);
                if (e.Graphics.MeasureString(text, ft).Width > (rect.Width * 2 - 60)) rect.Y = 10;//-= 3 * (int)(e.Graphics.MeasureString(text, ft).Height / 2);
                else if (e.Graphics.MeasureString(text, ft).Width > rect.Width) rect.Y -= (int)(e.Graphics.MeasureString(text, ft).Height / 2);
                e.Graphics.DrawString(text, ft, new SolidBrush(bedColor), rect, sf);
                if (!string.IsNullOrEmpty(_patientInformation.Name))
                {
                    text = _patientInformation.Name;
                    ft = new Font("黑体", 32);
                    e.Graphics.DrawString(text, ft, Brushes.Blue, (rect.Width - e.Graphics.MeasureString(text, ft).Width) / 2, 20);
                }
                if (!string.IsNullOrEmpty(_patientInformation.Sex))
                {
                    text = _patientInformation.Sex;
                    ft = new Font("黑体",32);
                    e.Graphics.DrawString(text, ft, Brushes.Blue, (rect.Width - e.Graphics.MeasureString(text, ft).Width) / 2, 70);
                }
                if (!string.IsNullOrEmpty(_patientInformation.OperationName))
                {
                    text = _patientInformation.OperationName;
                    ft = new Font("黑体", 24);
                    e.Graphics.DrawString(text, ft, Brushes.Blue,new RectangleF(3, 120,
                        rect.Width - 6,rect.Height - 120),sf);
                }
            }
        }

        private decimal _eventNo = 1;
        public BedManager(decimal eventNo)
        {
            _eventNo = eventNo;
            InitializeComponent();
        }

        public BedManager()
        {
            InitializeComponent();
        }

        private bool _isSelecting = false;
        public bool IsSelecting
        {
            get
            {
                return _isSelecting;
            }
            set
            {
                _isSelecting = value;
            }
        }

        private PatientBaseInformations.OperationsInfoDataTable _operationsInfoDataTable;

        private void ClearInfo()
        {
            foreach (PatInfo pi in beds)
            {
                Controls.Remove(pi);
            }
            beds.Clear();
        }

        private void RefreshInfo()
        {
            ClearInfo();
            DateTime dtStart = dateTimePickerQuery.Value.Date, dtEnd = dtStart.AddDays(1);
            //_operationsInfoDataTable = DataHelper.GetOpertionsInfo((decimal)(int)OperationStatus.InPACU);
            decimal operStatus = 0;
            if (_eventNo == 1)
            {
                operStatus = (decimal)(int)OperationStatus.InPACU;
            }
            else if (_eventNo == 3)
            {
                operStatus = (decimal)(int)OperationStatus.InYouDao;
            }
            _operationsInfoDataTable = PatientInformationsProxy.GetOpertionsInfo(operStatus);
            Dict.OperatingRoomDataTable room = DictProxy.GetOperatingRoomDict();
            DataRow[] rows = room.Select("BED_TYPE = 1");
            if (rows != null && rows.Length > 0)
            {
                for (int i = 0; i < rows.Length; i++)
                {
                    PatientInformation patInfo = new PatientInformation(((rows[i]["PAT_ID"] == System.DBNull.Value) ? "" : rows[i]["PAT_ID"].ToString()),
                        ((rows[i]["Visit_ID"] == System.DBNull.Value) ? 0 : (decimal)rows[i]["Visit_ID"]), ((rows[i]["Oper_ID"] == System.DBNull.Value) ? 0 : (decimal)rows[i]["Oper_ID"])
                        , operStatus, "", rows[i]["ROOM_NO"].ToString(), "", ((rows[i]["INP_NO"] == System.DBNull.Value) ? "" : rows[i]["INP_NO"].ToString()), 0, 0);
                    if (rows[i]["BED_LABEL"] != System.DBNull.Value)
                    {
                        patInfo.BedLabel = rows[i]["BED_LABEL"].ToString();
                    }
                    if (!string.IsNullOrEmpty(patInfo.PatientID) && _operationsInfoDataTable.Count > 0)
                    {
                        PatientBaseInformations.OperationsInfoRow row = _operationsInfoDataTable.FindByPAT_IDVISIT_IDOPER_ID(patInfo.PatientID
                            , patInfo.VisitID, patInfo.OperID);
                        if (row != null)
                        {
                            if (!row.IsNAMENull()) patInfo.Name = row.NAME;
                            if (!row.IsBED_NONull()) patInfo.BedNo = row.BED_NO;
                            if (!row.IsSEXNull()) patInfo.Sex = row.SEX;
                            if (!row.IsOPER_NAMENull()) patInfo.OperationName = row.OPER_NAME;
                        }
                        else
                        {
                            patInfo.PatientID = "";
                            rows[i]["PAT_ID"] = System.DBNull.Value;
                            rows[i]["Visit_ID"] = System.DBNull.Value;
                            rows[i]["Oper_ID"] = System.DBNull.Value;
                        }
                    }
                    AddPatient(patInfo);
                }
                DictProxy.UpdateOperatingRoomDict(room);
            }
            ResizeBeds();
        }

        private List<PatInfo> beds = new List<PatInfo>();
        private void AddPatient(PatientInformation patientInfo)
        {
            PatInfo patInfo = new PatInfo();
            patInfo.PatientInformation = patientInfo;
            patInfo.Height = 200;
            patInfo.Width = 190;
            Controls.Add(patInfo);
            patInfo.Click += new EventHandler(patInfo_Click);
            if (!_isSelecting)
            {
                patInfo.MouseClick += new MouseEventHandler(patInfo_MouseClick);
            }
            patInfo.DoubleClick += new EventHandler(patInfo_DoubleClick);
            if (_isSelecting)
            {
                if (string.IsNullOrEmpty(patientInfo.PatientID))
                {
                    patInfo.Cursor = Cursors.Hand;
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(patientInfo.PatientID))
                {
                    patInfo.Cursor = Cursors.Hand;
                }
            }
            beds.Add(patInfo);
        }

        private void patInfo_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PatInfo patInfo = sender as PatInfo;
                if (patInfo != null)
                {
                    if (!_isSelecting && !string.IsNullOrEmpty(patInfo.PatientInformation.PatientID))
                    {
                        SystemHelper.InformationChanged(patInfo.PatientInformation);
                        //DataHelper.ShowStatusSwitchPopup(ExtendApplicationContext.Current.PatientInformation, new EventHandler(
                        //    delegate(object s1, EventArgs e1)
                        //    {
                        //        RefreshInfo();
                        //    }));
                    }
                }

            }
        }

        private void patInfo_DoubleClick(object sender, EventArgs e)
        {
            PatInfo patInfo = sender as PatInfo;
            if (patInfo != null)
            {
                if (!_isSelecting && !string.IsNullOrEmpty(patInfo.PatientInformation.PatientID))
                {
                    //ActionFactory.ExecuteAction("ShowDocument", "PACU,1");
                }
                else if (_isSelecting && string.IsNullOrEmpty(patInfo.PatientInformation.PatientID))
                {
                    //Globals.DialogResult = patInfo.PatientInformation.OperRoom;
                    ParentForm.DialogResult = DialogResult.OK;
                }
                else if (!_isSelecting && string.IsNullOrEmpty(patInfo.PatientInformation.PatientID))
                {
                    //Operations oper = new Operations();
                    //oper.SetSelect();
                    //object result = Globals.ShowDialog(oper, new Size(800, 600), "选择要转入的患者", null, true);
                    //if (result != null && result is PatientInformation)
                    //{
                    //    PatientInformation patientInformation = result as PatientInformation;
                    //    if (DataHelper.ChangeStatus(patientInformation, OperationStatus.InPACU, patInfo.PatientInformation.OperRoom))
                    //    {
                    //        RefreshInfo();
                    //    }
                    //}
                }
            }
        }

        private void patInfo_Click(object sender, EventArgs e)
        {
            PatInfo patInfo = sender as PatInfo;
            if (patInfo != null)
            {
                if (!_isSelecting && !string.IsNullOrEmpty(patInfo.PatientInformation.PatientID))
                {
                    SystemHelper.InformationChanged(patInfo.PatientInformation);
                }
                else if (_isSelecting && string.IsNullOrEmpty(patInfo.PatientInformation.PatientID))
                {
                }
            }
        }

        private void ResizeBeds()
        {
            int left = 10, top = 10;
            if (panel4.Visible) top += panel4.Height;
            for (int i = 0; i < beds.Count; i++)
            {
                PatInfo patInfo = beds[i];
                patInfo.Left = left;
                patInfo.Top = top;
                if (patInfo.Left + patInfo.Width > Width)
                {
                    left = 10;
                    top += patInfo.Height + 10;
                    patInfo.Left = 10;
                    patInfo.Top = top;
                }
                else
                {
                    left += patInfo.Width + 10;
                }
            }
        }

        private void BedManager_Resize(object sender, EventArgs e)
        {
            ResizeBeds();
        }

        private void dateTimePickerQuery_ValueChanged(object sender, EventArgs e)
        {
            RefreshInfo();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.FillRectangle(new TextureBrush(Resource.BackgroundImage), e.ClipRectangle);
            e.Graphics.DrawString("查询日期", new Font("宋体", 9), Brushes.Black, 5, 5);
        }

        private void BedManager_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                RefreshInfo();
                timer1.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            RefreshInfo();
        }
    }

}
