using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.BusinessEntity;
using Wis.Anes.Framework;
using DevExpress.XtraEditors;

namespace Wis.Anes.Views.Patient
{
    [ToolboxItem(false)]
    public partial class PatientContentView : UserControl
    {
        protected Font _fontBedLabel = new Font("Verdana", 60, FontStyle.Bold);
        protected Font _fontSequence = new Font("Verdana", 36, FontStyle.Bold);
        protected Brush _brushBedLabel = new SolidBrush(Color.FromArgb(128, 128, 225));

        public PatientContentView()
        {
            InitializeComponent();
        }
        public PatientContentView(PatientInformation patientInformation)
            : this()
        {
            _patientInformation = patientInformation;

        }
        private Dict.HisUserDataTable _doctorTable;
        private Dict.HisUserDataTable _nurseTable;

        public Dict.HisUserDataTable NurseTable
        {
            get
            {
                return _nurseTable;
            }
            set
            {
                _nurseTable = value;
            }
        }

        public Dict.HisUserDataTable DoctorTable
        {
            get
            {
                return _doctorTable;
            }
            set
            {
                _doctorTable = value;
            }
        }
        private PatientInformation _patientInformation;
        public PatientInformation PatientInformation
        {
            get { return _patientInformation; }
            set { _patientInformation = value; }

        }
        private bool _selected = false;
        public bool Selected
        {
            set
            {
                _selected = value;
                if (value == true)
                {
                    //labelControl2.BackColor = Color.LightGray;
                    //labelControl4.BackColor = Color.LightGray;
                    this.BackColor = Color.FromArgb(192, 255, 192);
                }
                else
                {
                    this.BackColor = Color.FromArgb(227, 239, 255);
                    //labelControl2.BackColor = Color.Transparent;
                    //labelControl4.BackColor = Color.Transparent;
                }
            }
            get
            {
                return _selected;
            }
        }



        private Image _flagGeliImage = null;
        public Image FlagGeliImage
        {
            get
            {
                return _flagGeliImage;
            }
            set
            {
                _flagGeliImage = value;
            }
        }
        private Image _flagFangSheImage = null;
        public Image FlagFangSheImage
        {
            get
            {
                return _flagFangSheImage;
            }
            set
            {
                _flagFangSheImage = value;
            }

        }

        private Image _flagEmgerencyImage = null;
        public Image FlagEmgerencyImage
        {
            get
            {
                return _flagEmgerencyImage;
            }
            set
            {
                _flagEmgerencyImage = value;
            }

        }
        public void InitalizeUI()
        {

            this.groupControl1.Text = string.Format("手术室 {0}", _patientInformation.OperRoom);
            string s = OperationStatusHelper.OperationStatusToString((OperationStatus)(int)_patientInformation.OperStatus);
            if (!string.IsNullOrEmpty(s))
            {
                Color color = Color.Black;
                if ((int)_patientInformation.OperStatus == (int)OperationStatus.OperationStart)
                {
                    color = Color.Yellow;

                }
                else if ((int)_patientInformation.OperStatus == (int)OperationStatus.AnesthesiaStart)
                {
                    color = Color.Red;

                }
                // this.statusLabel.Text = s;
                //this.statusLabel.ForeColor = color;
            }
            this.statusLabel.Text = s;
            //Modify By xiasen.x@2014-05-28，这么显示不合理，更改下
            //labelControl2.Text = string.Format("患者 {0} {1} {2}  住院号 {3}", _patientInformation.Sex, _patientInformation.Name, _patientInformation.PatientID, _patientInformation.InpNo.Equals(_patientInformation.PatientID)?"":_patientInformation.InpNo);
            labelControl2.Text = string.Format("患者 {0} {1} {2}  住院号 {3}", _patientInformation.Sex, _patientInformation.Name, _patientInformation.PatientID, _patientInformation.InpNo);
            //End Modify
            labelControl3.Text = string.Format("手术 {0}", _patientInformation.OperationName);
            labelControl3.ToolTip = labelControl3.Text;
            labelControl4.Text = string.Format("时间 {0}", _patientInformation.OperationTime.ToString("yyyy-MM-dd HH:mm"));

            string text = _patientInformation.Surgeon;
            if (!string.IsNullOrEmpty(text))
            {
                if (_doctorTable != null)
                {
                    Dict.HisUserRow row = _doctorTable.FindByUSER_ID(text);
                    if (row != null)
                    {
                        text = row.USER_NAME;
                    }
                }

            }
            string anes = _patientInformation.AnesDoctor;
            if (!string.IsNullOrEmpty(anes))
            {
                if (_doctorTable != null)
                {
                    Dict.HisUserRow row = _doctorTable.FindByUSER_ID(anes);
                    if (row != null)
                    {
                        anes = row.USER_NAME;
                    }
                }
            }
            else
            {
                anes = "";
            }


            string anes2 = _patientInformation.AnesAssistant;
            if (!string.IsNullOrEmpty(anes2))
            {
                if (_doctorTable != null)
                {
                    Dict.HisUserRow row = _doctorTable.FindByUSER_ID(anes2);
                    if (row != null)
                    {
                        anes2 = row.USER_NAME;
                    }
                }
            }
            else
            {
                anes2 = "";
            }

            labelControl5.Text = string.Format("术者 {0}   麻醉 {1} {2}", text, anes, anes2);

            if (_patientInformation.Emgerency == 1)
            {

                picEmgerencyImage.Image = FlagEmgerencyImage;

                panelEmgerency.Visible = true;
            }
            else
            {
                panelEmgerency.Visible = false;
            }


            if (_patientInformation.Isolation == 2)
            {
                lbFlag.Text = "隔离";
                panelFlag.Visible = true;
                picFlagImage.Image = FlagGeliImage;
            }
            else if (_patientInformation.Isolation == 3)
            {
                lbFlag.Text = "放射";
                picFlagImage.Image = FlagFangSheImage;
                panelFlag.Visible = true;
            }
            else
            {
                panelFlag.Visible = false;
            }

            string strRoomAndSeq = "";
            if (_patientInformation != null && !string.IsNullOrEmpty(_patientInformation.OperRoom))
            {
                strRoomAndSeq = _patientInformation.OperRoom;
                if (!string.IsNullOrEmpty(_patientInformation.Sequence))
                    strRoomAndSeq += "-" + _patientInformation.Sequence;
            }

            lb_RoomAndSeq.Text = strRoomAndSeq;
            Refresh();
        }

        public event EventHandler DoubleClicked;
        public event EventHandler Clicked;
        public event EventHandler MouseEntered;

        private void groupControl1_DoubleClick(object sender, EventArgs e)
        {
            if (DoubleClicked != null)
                DoubleClicked(this, EventArgs.Empty);
        }

        private void groupControl1_Click(object sender, EventArgs e)
        {
            if (Clicked != null)
                Clicked(this, EventArgs.Empty);

            //labelControl2.BackColor = Color.FromArgb(29, 117, 181);
            //labelControl4.BackColor = labelControl2.BackColor;
            Selected = true;
            Refresh();
            this.Focus();
        }

        private void groupControl1_MouseEnter(object sender, EventArgs e)
        {
            if (MouseEntered != null)
                MouseEntered(this, EventArgs.Empty);

            //this.panel1.BackColor = Color.FromArgb(29, 117, 181);
            //this.panel3.BackColor = this.panel1.BackColor;
        }

        private void groupControl1_MouseLeave(object sender, EventArgs e)
        {
            //this.panel1.BackColor = Color.Transparent;
            //this.panel3.BackColor = this.panel1.BackColor;
        }

        public void CancelFocus()
        {
            Selected = false;
            //labelControl2.BackColor = Color.Transparent;
            //labelControl4.BackColor = Color.Transparent;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);

            if (_patientInformation != null && !string.IsNullOrEmpty(_patientInformation.OperRoom))
            {
                #region Modify @2013-02-14 如果是复苏程序并且有复苏床位就显示复苏床位号
                //e.Graphics.DrawString(_patientInformation.OperRoom, _fontBedLabel, _brushBedLabel, new PointF(150, 20));

                //if (!string.IsNullOrEmpty(_patientInformation.Sequence))
                //    e.Graphics.DrawString("-" + _patientInformation.Sequence, _fontSequence, _brushBedLabel, new PointF(275, 50));

                BusinessEntity.Dict.OperatingRoomDataTable dt = new DataAccess.DictDA().GetOperatingRoomDict();
                BusinessEntity.Dict.OperatingRoomRow[] row = null;
                if (dt != null && dt.Rows.Count > 0)
                {
                    row = dt.Select(string.Format("PAT_ID='{0}' AND VISIT_ID={1} AND OPER_ID={2}", (string)_patientInformation.PatientID,
                        _patientInformation.VisitID, _patientInformation.OperID)) as BusinessEntity.Dict.OperatingRoomRow[];
                }
                if (ExtendApplicationContext.Current.AppType == ApplicationType.PACU && row != null && row.Length > 0)
                {
                    e.Graphics.DrawString(row[0].ROOM_NO, _fontBedLabel, _brushBedLabel, new PointF(150, 20));
                }
                else
                {
                    e.Graphics.DrawString(_patientInformation.OperRoom, _fontBedLabel, _brushBedLabel, new PointF(150, 20));

                    if (!string.IsNullOrEmpty(_patientInformation.Sequence))
                        e.Graphics.DrawString("-" + _patientInformation.Sequence, _fontSequence, _brushBedLabel, new PointF(275, 50));
                }
                #endregion
            }
            //e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(128, 29, 117, 181)), 0, 25, e.ClipRectangle.Width, 35);
        }

        private void PatientContentView_Click(object sender, EventArgs e)
        {
            if (Clicked != null)
                Clicked(this, EventArgs.Empty);

            //labelControl2.BackColor = Color.FromArgb(29, 117, 181);
            //labelControl4.BackColor = labelControl2.BackColor;
            Selected = true;
            this.Focus();
        }

        private void PatientContentView_DoubleClick(object sender, EventArgs e)
        {
            if (DoubleClicked != null)
                DoubleClicked(this, EventArgs.Empty);
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelOperation_Click(object sender, EventArgs e)
        {
            PatientContentView_Click(sender, e);
        }
    }
}
