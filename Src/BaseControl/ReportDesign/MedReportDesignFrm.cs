/*----------------------------------------------------------------
      // Copyright (C) 2008 麦迪斯顿(北京)医疗科技发展有限公司
      // 文件名：MedReportDesignFrm.cs
      // 文件功能描述：报表设置窗体
      //
      // 
      // 创建标识：于占涛-2008-10-20
      //
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Com.MedicalSystem.Common.Utilities;
using Com.MedicalSystem.Common.Controls;

namespace Com.ICIS.Icu
{
    public partial class MedReportDesignFrm : DevExpress.XtraEditors.XtraForm
    {
        #region 私有变量
        /// <summary>
        /// 当前选中按钮
        /// </summary>
        private ToolStripItem _actionButton;
        //private MedAddDataField _medDataFieldAddFrm1 = new MedAddDataField();
        private bool _saved = false;
        /// <summary>
        /// 文书配置项明细
        /// </summary>
        DataSetModel.CareDocs.MED_DOCUMENT_DESIGN_DETAILDataTable detail = new Com.MedicalSystem.Icu.DataSetModel.CareDocs.MED_DOCUMENT_DESIGN_DETAILDataTable();
        /// <summary>
        /// 文书配置项主表
        /// </summary>
        DataSetModel.CareDocs.MED_DOCUMENT_DESIGN_MAINDataTable main = new Com.MedicalSystem.Icu.DataSetModel.CareDocs.MED_DOCUMENT_DESIGN_MAINDataTable();
        /// <summary>
        /// 文书配置项主表
        /// </summary>
        DataSetModel.CareDocs.MED_DOCUMENT_DESIGN_MAINRow selectDocument;
        /// <summary>
        /// 特护单主题配置
        /// </summary>
        HeaderSettingsFrm setting;
        #endregion

        #region 私有方法
        /// <summary>
        /// 校验是否已选择要设置的组件
        /// </summary>
        /// <returns>已选择返回真，否则返回假</returns>
        private bool CheckkSelectControl()
        {
            if (reportDesignControl1.SelectControl == null)
            {                
                //timer1.Stop();                
                Dialog.MessageBox("请先选择需要设置组件。");
                return false;
            }
            return true;
        }
        #endregion

        #region 公有方法
        /// <summary>
        /// 展现设计窗体 
        /// </summary>
        /// <returns>保存返回真，否则返回假</returns>
        public bool ShowDesign()
        {
            _saved = false;
            ShowDialog();
            return _saved;
        }

        #endregion 公有方法

        #region 构造函数

        public MedReportDesignFrm()
        {
            InitializeComponent();
            reportDesignControl1.SendToBack();
        }

        public void SetConfig(string reportName)
        {
            dbFiledSetting1.SetConfig(reportName);
            reportDesignControl1.ReportName = reportName;
            //reportDesignControl1.ConfigFileName = configFileName;
        }

        #endregion

        #region 控件事件

        private void reportDesignControl1_SelectedControlEvent(object sender, EventArgs e)
        {
            if (reportDesignControl1.SelectControls.Count == 1)
            {
                propertyGrid1.SelectedObject = new Com.MedicalSystem.Common.Controls.DesignableField(reportDesignControl1.SelectControl);
                propertyGrid1.Enabled = true;
                medPropertiesEditor1.EditObject = propertyGrid1.SelectedObject;
                medPropertiesEditor1.Enabled = true;
                lblSelectedItem.Text = reportDesignControl1.SelectControl.Name;
            }
            else
            {
                propertyGrid1.SelectedObject = null;
                lblSelectedItem.Text = "";
                propertyGrid1.Enabled = false;
                medPropertiesEditor1.EditObject = null;
                medPropertiesEditor1.Enabled = false;
            }
            txtLeft.Text = (sender as Control).Left.ToString();
            txtTop.Text = (sender as Control).Top.ToString();
            txtWidth.Text = (sender as Control).Width.ToString();
            txtHeight.Text = (sender as Control).Height.ToString();
            if (sender is MedTextBox)
            {
                txtFormat.Text = (sender as MedTextBox).Format;
                toolStripButtonMuiltLine.Checked = (sender as MedTextBox).Properties.AutoHeight;//.Multiline;
            }
            if ((sender as Control).Name.Length == 0)
            {
                toolStripStatusLabel1.Text = "当前组件：" + (sender as Control).Text;
            }
            else
            {
                toolStripStatusLabel1.Text = "当前组件：" + (sender as Control).Name;
            }
            txtText.Text = (sender as Control).Text;
            medTabControl1.SelectedTabPageIndex = 1;
        }   

        private void txtLeft_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!CheckkSelectControl())
                {
                    return;
                }
                if (txtLeft.Text.Length == 0)
                {
                    return;
                }
                if (txtLeft.Text == reportDesignControl1.SelectControl.Left.ToString())
                {
                    return;
                }
                int PX = int.Parse(txtLeft.Text);
                if ((PX < 0 || PX > reportDesignControl1.SelectControl.Parent.Width - reportDesignControl1.SelectControl.Width)
                     && reportDesignControl1.SelectControl != reportDesignControl1)
                {
                    //timer1.Stop();
                    Dialog.MessageBox("设置值超过范围，请重新设置。");
                    return;
                }
                base.OnTextChanged(e);
                reportDesignControl1.SetControlLeft(PX);
            }
            catch (Exception ex)
            {
                Dialog.MessageBox(ex.Message, MessageBoxIcon.Error);
            }
        }
        private void txtTop_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!CheckkSelectControl())
                {
                    return;
                }
                if (txtTop.Text.Length == 0)
                {
                    return;
                }
                if (txtTop.Text == reportDesignControl1.SelectControl.Top.ToString())
                {
                    return;
                }
                int PX = int.Parse(txtTop.Text);
                if ((PX < 0 || PX > reportDesignControl1.SelectControl.Parent.Height - reportDesignControl1.SelectControl.Height)
                    && reportDesignControl1.SelectControl != reportDesignControl1)
                {
                    //timer1.Stop();
                    Dialog.MessageBox("设置值超过范围，请重新设置。");
                    return;
                }
                base.OnTextChanged(e);
                reportDesignControl1.SetControlTop(PX);
            }
            catch (Exception ex)
            {
                Dialog.MessageBox(ex.Message, MessageBoxIcon.Error);
            }
 
        }
        private void txtWidth_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!CheckkSelectControl())
                {
                    return;
                }
                if (txtWidth.Text.Length == 0)
                {
                    return;
                }
                if (txtWidth.Text == reportDesignControl1.SelectControl.Width.ToString())
                {
                    return;
                }
                int PX = int.Parse(txtWidth.Text);
                if ((PX < 1 || PX + reportDesignControl1.SelectControl.Left > reportDesignControl1.SelectControl.Parent.Width)
                  && reportDesignControl1.SelectControl != reportDesignControl1)
                {
                    //timer1.Stop();
                    Dialog.MessageBox("设置值超过范围，请重新设置。");
                    return;
                }
                base.OnTextChanged(e);
                reportDesignControl1.SetControlWidth(PX);
                if (reportDesignControl1.SelectControl.Name == "reportDesignControl1")
                {
                    setScrollBar();
                }
            }
            catch (Exception ex)
            {
                Dialog.MessageBox(ex.Message, MessageBoxIcon.Error);
            }

        }

        private void txtHeight_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!CheckkSelectControl())
                {
                    return;
                }
                if (txtHeight.Text.Length == 0)
                {
                    return;
                }
                if (txtHeight.Text == reportDesignControl1.SelectControl.Height.ToString())
                {
                    return;
                }
                int PX = int.Parse(txtHeight.Text);
                //if (reportDesignControl1.SelectControl.Name == "medPrintPreview1" && PX > reportDesignControl1.Height)
                //{
                //    timer1.Stop();
                //    Dialog.MessageBox("设置值超过范围，请重新设置。");
                //    return;
                //}
                if ((PX < 1 || PX + reportDesignControl1.SelectControl.Top > reportDesignControl1.SelectControl.Parent.Height)
                    && reportDesignControl1.SelectControl != reportDesignControl1 && reportDesignControl1.SelectControl.Name != "medPrintPreview1")
                {
                    //timer1.Stop();
                    Dialog.MessageBox("设置值超过范围，请重新设置。");
                    return;
                }
                base.OnTextChanged(e);
                reportDesignControl1.SetControlHeight(PX);
                if (reportDesignControl1.SelectControl.Name == "reportDesignControl1")
                {
                    setScrollBar();
                }
            }
            catch (Exception ex)
            {
                Dialog.MessageBox(ex.Message, MessageBoxIcon.Error);
            }

        }       

        private void txtText_TextChanged(object sender, EventArgs e)
        {
            if (!CheckkSelectControl())
            {
                return;
            }            
            reportDesignControl1.SelectControl.Text = txtText.Text;            
        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {                        
            //_medDataFieldAddFrm1.ShowForm(this);
        }

        private void getDesignControl()
        {
            detail = DataOperator.GetDocumentDesignDetail(cmbDocument.Text, DataOperator.WardCode);
            main = DataOperator.GetDocumentDesignMain(DataOperator.WardCode);
        }

        private void ToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (cmbDocument.Text.Trim() == "")
            {
                Sundries.MessageBox("请选择或输入单子名称，才能保存！",5);
                return;
            }
            if (Sundries.MessageBox("确实要保存单子" + cmbDocument.Text + "吗？",Com.MedicalSystem.Common.Utilities.Sundries.CAPTION, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            detail = DataOperator.GetDocumentDesignDetail(cmbDocument.Text, DataOperator.WardCode);
            int mainTop = 0;
            for (int i = detail.Count - 1; i >= 0; i--)
            {
                detail.Rows[i].Delete();
            }
            int serial = 0;
            foreach (Control Control1 in reportDesignControl1.Controls)
            {
                if (Control1.Name == "pan5" || Control1.Name == "medPrintPreview1")
                {
                    mainTop = Control1.Top;
                    continue;
                }
                DataSetModel.CareDocs.MED_DOCUMENT_DESIGN_DETAILRow row = detail.NewMED_DOCUMENT_DESIGN_DETAILRow();
                row.DOCUMENT_NAME = cmbDocument.Text;
                row.WARD_CODE = DataOperator.WardCode;
                row.ITEM_NAME = serial.ToString();
                row.WIDTH = Control1.Width;
                row.HEIGHT = Control1.Height;
                row.TOP = Control1.Top;
                row.LEFT = Control1.Left;
                row.FORE_COLOR = Control1.ForeColor.Name;
                row.TEXT = Control1.Text;
                row.BACKCOLOR = Control1.BackColor.Name;
                row.FONT = Control1.Font.ToString().Trim();
                row.FONT_STYLE = Control1.Font.Style.ToString().Trim();
                if (Control1 is MedTextBox)
                {
                    row.BIND_TABLE_NAME = (Control1 as MedTextBox).BindTableName;
                    row.BIND_FIELD_NAME = (Control1 as MedTextBox).BindFieldName;
                    row.CELERITY_INPUT_TABLE_NAME = (Control1 as MedTextBox).CelerityInputTableName;
                    row.CELERITY_INPUT_VALUE_COLUMN = (Control1 as MedTextBox).CelerityInputValueColumnName;
                    row.CELERITY_INPUT_CODE_COMUMN = (Control1 as MedTextBox).CelerityInputCodeColumnName;
                    //row["CelerityInputSqlWhere"] = (Control1 as MedTextBox).CelerityInputSqlWhere;
                    row.BIND_LIST = (Control1 as MedTextBox).BindList;
                    //row["Format"] = (Control1 as MedTextBox).Format;
                    //row["MultiSign"] = (Control1 as MedTextBox).MultiSign;
                    row.MULTILINE = convertBoolToString((Control1 as MedTextBox).Properties.AutoHeight);//.Multiline);
                    row.CONTROL_TYPE = "MedTextBox";
                }
                else if (Control1 is MedLabel)
                {
                    //row.ITEM_NAME = Control1.Name;
                    row.CONTROL_TYPE = "MedLabel";
                }
                else if (Control1 is DevExpress.XtraEditors.PanelControl)
                {
                    row.CONTROL_TYPE = "DevExpress.XtraEditors.PanelControl";
                }
                serial++;
                detail.AddMED_DOCUMENT_DESIGN_DETAILRow(row);
            }
            
            for (int i = main.Count - 1; i >= 0; i--)
            {
                if (main.Rows[i]["DOCUMENT_NAME"].ToString() == cmbDocument.Text && main.Rows[i]["WARD_CODE"].ToString() == DataOperator.WardCode)
                {
                    main.Rows[i].Delete();
                }
            }
            DataSetModel.CareDocs.MED_DOCUMENT_DESIGN_MAINRow rowMain = main.NewMED_DOCUMENT_DESIGN_MAINRow();
            rowMain.DOCUMENT_NAME = cmbDocument.Text;
            rowMain.MAIN_TOP = mainTop;
            rowMain.WARD_CODE = DataOperator.WardCode;
            rowMain.WEIDTH = reportDesignControl1.Width;
            rowMain.HEIGHT = reportDesignControl1.Height;
            main.AddMED_DOCUMENT_DESIGN_MAINRow(rowMain);
            if (DataOperator.UpdateDocumentDesignDetail(detail) >= 0 && DataOperator.UpdateDocumentDesignMain(main) >= 0)
            {
                Sundries.MessageBox("保存成功！", 3);
            }
            getDesignControl();
            reportDesignControl1.IsChanged = false;
            //DataHelper.SaveSettings(reportDesignControl1);
            _saved = true;
        }

        private string convertBoolToString(bool source)
        {
            if (source)
                return "T";
            else
                return "F";
        }

        private void ToolStripMenuItem6_Click(object sender, EventArgs e)
        {            
            Close();
        }

        private void MedReportDesignFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (reportDesignControl1.IsChanged)
            {
                if (Dialog.MessageBox("报表属性自上次保存发生过变化,是否保存修改?", Dialog.CAPTION, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ToolStripMenuItem5.PerformClick();
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            reportDesignControl1.AlignLeft();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            reportDesignControl1.AlignRight();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            reportDesignControl1.AlignTop();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            reportDesignControl1.AlignWidth();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            reportDesignControl1.SetUprightSpace();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            reportDesignControl1.SetLevelSpace();
        }

        public void reflashData()
        {
            if (setting != null)
            {
                setting.Dispose();
                medPrintPreview1.Dispose();
                medPrintPreview1 = new MedPrintPreview();
                this.pan5.Controls.Add(this.medPrintPreview1);
                this.medPrintPreview1.AutoScroll = false;
                this.medPrintPreview1.DefaultLineHeight = 20;
                this.medPrintPreview1.Dock = System.Windows.Forms.DockStyle.Fill;
                this.medPrintPreview1.DrawContent = true;
                this.medPrintPreview1.LeftMargin = 0;
                this.medPrintPreview1.LineNumberPerPage = 30;
                this.medPrintPreview1.Location = new System.Drawing.Point(0, 0);
                this.medPrintPreview1.Name = "medPrintPreview1";
                this.medPrintPreview1.PageHeight = 1200;
                this.medPrintPreview1.PageWidth = 1600;
                this.medPrintPreview1.PrintType = Com.MedicalSystem.Common.Controls.PrintTypeEnum.All;
                this.medPrintPreview1.RightMargin = 10;
                this.medPrintPreview1.ShowPrintDialog = false;
                this.medPrintPreview1.Size = new System.Drawing.Size(660, 279);
                this.medPrintPreview1.TabIndex = 0;
                this.medPrintPreview1.TopMargin = 0;
                this.medPrintPreview1.BackColor = System.Drawing.Color.Black;
                this.medPrintPreview1.CellClick += new Com.MedicalSystem.Common.Controls.MedPrintPreview.PrintCellEventHandler(this.medPrintPreview1_CellClick);
            }
            //SetConfig(cmbDocument.Text);
            toolStripButtonBorder.Checked = reportDesignControl1.DrawBorder;
            reportDesignControl1.RefreshSettings(selectDocument, detail);

            if (selectDocument != null && !selectDocument.IsMAIN_TOPNull())
            {
                pan5.Size = new Size(reportDesignControl1.Width, reportDesignControl1.Height - (int)selectDocument.MAIN_TOP);
            }
            else
            {
                pan5.Size = new Size(reportDesignControl1.Width, reportDesignControl1.Height - 80);
            }
            pan5.SendToBack();
            
            if (!DesignMode)
            {
                foreach (Control control in reportDesignControl1.Controls)
                {
                    control.DoubleClick += new EventHandler(control_DoubleClick);
                }
                vScrollBar1.Visible = reportDesignControl1.Parent.Height < reportDesignControl1.Height;
                vScrollBar1.Maximum = reportDesignControl1.Height - reportDesignControl1.Parent.Height + 10;
                vScrollBar1.Minimum = 0;
                foreach (Control control in reportDesignControl1.Controls)
                {
                    control.DoubleClick += new EventHandler(control_DoubleClick);
                }

                hScrollBar1.Visible = reportDesignControl1.Parent.Width < reportDesignControl1.Width;
                hScrollBar1.Maximum = reportDesignControl1.Width - reportDesignControl1.Parent.Width + 35;
                hScrollBar1.Minimum = 0;

                setting = new HeaderSettingsFrm(cmbDocument.Text, medPrintPreview1);
                setting.Show();
            }
        }

        private void MedReportDesignFrm_Load(object sender, EventArgs e)
        {
            medPrintPreview1.BringToFront();
            medPrintPreview1.AutoScroll = false;
            getDesignControl();
            foreach (DataSetModel.CareDocs.MED_DOCUMENT_DESIGN_MAINRow row in main.Rows)
            {
                cmbDocument.Items.Add(row.DOCUMENT_NAME);
            }
            dbFiledSetting1.SetConfig("");
            reportDesignControl1.Parent.MouseWheel += new MouseEventHandler(Parent_MouseWheel);
            reportDesignControl1.MouseDown += new MouseEventHandler(control_MouseDown);
            reportDesignControl1.Parent.MouseDown += new MouseEventHandler(control_MouseDown);
            this.MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            this.WindowState = FormWindowState.Maximized;
        }

        private void setScrollBar()
        {
            if (reportDesignControl1.Parent.Height >= reportDesignControl1.Height)
            {
                vScrollBar1.Visible = false;
                return;
            }
            else if (reportDesignControl1.Parent.Height < reportDesignControl1.Height)
            {
                vScrollBar1.Maximum = reportDesignControl1.Height - reportDesignControl1.Parent.Height + 35;
                vScrollBar1.Visible = reportDesignControl1.Parent.Height < reportDesignControl1.Height;
            }
            if (reportDesignControl1.Parent.Width >= reportDesignControl1.Width)
            {
                hScrollBar1.Visible = false;
                return;
            }
            else if (reportDesignControl1.Parent.Width < reportDesignControl1.Width)
            {
                hScrollBar1.Maximum = reportDesignControl1.Width - reportDesignControl1.Parent.Width + 35;
                hScrollBar1.Visible = reportDesignControl1.Parent.Width < reportDesignControl1.Width;
            }
        }

        void control_DoubleClick(object sender, EventArgs e)
        {
            if ((sender is MedLabel) && (sender as MedLabel).MultiLine)
            {
                Form frm = new BaseFrm();
                MedButton btn = new MedButton();
                btn.Text = "确定";
                DevExpress.XtraEditors.PanelControl pnl = new DevExpress.XtraEditors.PanelControl();
                pnl.Controls.Add(btn);
                btn.Location = new Point(10, 10);
                frm.Controls.Add(pnl);
                pnl.Dock = DockStyle.Bottom;
                MedTextBox txtEdit = new MedTextBox();
                txtEdit.Properties.AutoHeight = true;// Multiline = true;
                txtEdit.Text = (sender as MedLabel).Text;
                txtEdit.Dock = DockStyle.Fill;
                frm.Controls.Add(txtEdit);
                btn.Click += new EventHandler(delegate(object s1, EventArgs e1)
                    {
                        (sender as MedLabel).Text = txtEdit.Text;
                        frm.Close();
                    });
                txtEdit.BringToFront();
                pnl.BringToFront();
                pnl.Height = btn.Bottom + 10;
                frm.ShowDialog();
            }
        }

        private void Parent_MouseWheel(object sender, MouseEventArgs e)
        {
            int scrollStep = 1 + (int)(vScrollBar1.Maximum / 10);
            if (e.Delta < 0)
            {
                if (vScrollBar1.Value < vScrollBar1.Maximum - scrollStep)
                {
                    vScrollBar1.Value += scrollStep;
                }
                else
                {
                    vScrollBar1.Value = vScrollBar1.Maximum;
                }
            }
            else if (e.Delta > 0)
            {
                if (vScrollBar1.Value > scrollStep - 1)
                {
                    vScrollBar1.Value -= scrollStep;
                }
                else
                {
                    vScrollBar1.Value = 0;
                }
            }
            vScrollBar1_ValueChanged(vScrollBar1, null);
        }

        private void control_MouseDown(object sender, MouseEventArgs e)
        {
            reportDesignControl1.Parent.Focus();
        }

        private void txtFormat_TextChanged(object sender, EventArgs e)
        {
            if (!CheckkSelectControl())
            {
                return;
            }
            if (reportDesignControl1.SelectControl is MedTextBox)
            {
                (reportDesignControl1.SelectControl as MedTextBox).Format = txtFormat.Text;
            }
        }



        private void MedReportDesignFrm_KeyDown(object sender, KeyEventArgs e)
        {
            if (_lockKeyMove) return;
            if (e.Shift)
            {
                switch (e.KeyCode)
                {
                    case Keys.Left:
                        AddWidth(-1);
                        break;
                    case Keys.Right:
                        AddWidth(1);
                        break;
                    case Keys.Down:
                        AddHeight(1);
                        break;
                    case Keys.Up:
                        AddHeight(-1);
                        break;
                }
            }
            else
            {
                switch (e.KeyCode)
                {
                    case Keys.Left:
                        MoveLeft(-1);
                        break;
                    case Keys.Right:
                        MoveLeft(1);
                        break;
                    case Keys.Down:
                        MoveUp(1);
                        break;
                    case Keys.Up:
                        MoveUp(-1);
                        break;
                }
            }
        }

        private void toolStripButtonLeft_Click(object sender, EventArgs e)
        {            
            MoveLeft(-1);
        }

        private void MoveLeft(int offSet)
        {
            try
            {
                if (!CheckkSelectControl())
                {
                    return;
                }
                if (txtLeft.Text.Length == 0)
                {
                    return;
                }
                int PX = int.Parse(txtLeft.Text) + offSet;
                if (reportDesignControl1.SelectControls != null)
                {
                    foreach (Control ctl in reportDesignControl1.SelectControls)
                    {
                        ctl.Left += offSet;
                    }
                }
                else
                {
                    reportDesignControl1.SelectControl.Left += offSet;
                }
                txtLeft.Text = PX.ToString();
            }
            catch (Exception ex)
            {
                Dialog.MessageBox(ex.Message, MessageBoxIcon.Error);
            }

        }

        private void toolStripButtonRight_Click(object sender, EventArgs e)
        {
            MoveLeft(1);
        }

        private void MoveUp(int offSet)
        {
            try
            {
                if (!CheckkSelectControl())
                {
                    return;
                }
                if (txtTop.Text.Length == 0)
                {
                    return;
                }
                int PX = int.Parse(txtTop.Text) + offSet;
                if (reportDesignControl1.SelectControls != null)
                {
                    foreach (Control ctl in reportDesignControl1.SelectControls)
                    {
                        ctl.Top += offSet;
                    }
                }
                else
                {
                    reportDesignControl1.SelectControl.Top += offSet;
                }
                txtTop.Text = PX.ToString();
            }
            catch (Exception ex)
            {
                Dialog.MessageBox(ex.Message, MessageBoxIcon.Error);
            }

        }


        private void toolStripButtonUp_Click(object sender, EventArgs e)
        {
            MoveUp(-1);
        }

        private void toolStripButtonDown_Click(object sender, EventArgs e)
        {
            MoveUp(1);
        }

        private void AddWidth(int offSet)
        {
            try
            {
                if (!CheckkSelectControl())
                {
                    return;
                }
                if (txtWidth.Text.Length == 0)
                {
                    return;
                }
                int PX = int.Parse(txtWidth.Text) + offSet;
                if ((PX < 1 || PX + reportDesignControl1.SelectControl.Left > reportDesignControl1.SelectControl.Parent.Width)
                    && reportDesignControl1.SelectControl != reportDesignControl1)
                {
                    //timer1.Stop();
                    Dialog.MessageBox("设置值超过范围，请重新设置。");
                    return;
                }
                reportDesignControl1.SetControlWidth(PX);
                txtWidth.Text = PX.ToString();
            }
            catch (Exception ex)
            {
                Dialog.MessageBox(ex.Message, MessageBoxIcon.Error);
            }

        }

        private void toolStripButtonXL_Click(object sender, EventArgs e)
        {
            AddWidth(-1);
        }

        private void toolStripButtonXR_Click(object sender, EventArgs e)
        {
            AddWidth(1);
        }

        private void AddHeight(int offSet)
        {
            try
            {
                if (!CheckkSelectControl())
                {
                    return;
                }
                if (txtHeight.Text.Length == 0)
                {
                    return;
                }
                int PX = int.Parse(txtHeight.Text) + offSet;
                if ((PX < 1 || PX + reportDesignControl1.SelectControl.Top > reportDesignControl1.SelectControl.Parent.Height)
                    && reportDesignControl1.SelectControl != reportDesignControl1)
                {
                    //timer1.Stop();
                    Dialog.MessageBox("设置值超过范围，请重新设置。");
                    return;
                }
                reportDesignControl1.SetControlHeight(PX);
                txtHeight.Text = PX.ToString();
            }
            catch (Exception ex)
            {
                Dialog.MessageBox(ex.Message, MessageBoxIcon.Error);
            }

        }

        private void toolStripButtonYL_Click(object sender, EventArgs e)
        {
            AddHeight(-1);
        }

        private void toolStripButtonYR_Click(object sender, EventArgs e)
        {
            AddHeight(1);
        }

        private void txtText_DoubleClick_1(object sender, EventArgs e)
        {
            List<MemberDetail> list = AssemblyHelper.GetPropertyList(typeof(MyVariables), true);
            Dialog.ShowCustomSelection(list, "Name", toolStrip1,  new Point(MousePosition.X, txtText.Height), new Size(100, 300)
                , new EventHandler(delegate(object sender1, EventArgs e1)
                {
                    if (sender1 is int)
                    {
                        int index = (int)sender1;
                        txtText.Text = "%%" + list[index].PropertyInfo.Name;
                    }
                }), ListType.PopupMenu);
        }

        private void toolStripButtonFormat_Click(object sender, EventArgs e)
        {
            FormatFrm FormatFrm1 = new FormatFrm();
            if (FormatFrm1.ShowForm() == DialogResult.OK)
            {
                txtFormat.Text = FormatFrm1.FormatResult;
                if (reportDesignControl1.SelectControl is MedTextBox)
                {
                    (reportDesignControl1.SelectControl as MedTextBox).Format = FormatFrm1.FormatResult;
                }
            }
        }

        private void toolStripButtonAutoSize_Click(object sender, EventArgs e)
        {
            if (!CheckkSelectControl())
            {
                return;
            }
            if (reportDesignControl1.SelectControls != null && reportDesignControl1.SelectControls.Count > 0)
            {
                foreach (Control control in reportDesignControl1.SelectControls)
                {
                    control.Width = (int)control.CreateGraphics().MeasureString(control.Text, control.Font).Width + 1;
                }
            }
            else
            {
                Control control = reportDesignControl1.SelectControl;
                control.Width = (int)control.CreateGraphics().MeasureString(control.Text, control.Font).Width + 1;
            }
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            if (!CheckkSelectControl())
            {
                return;
            }
            int Result = reportDesignControl1.DeleteSelectControl();
            if (Result == -1)
            {
                Dialog.MessageBox("容器不可以删除");
            }
        }

        private void toolStripButtonColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                reportDesignControl1.SetControlColor(colorDialog1.Color);
            }
        }

        private void toolStripButtonFont_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = reportDesignControl1.SelectControl.Font;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                reportDesignControl1.SetControlFont(fontDialog1.Font);
            }
        }

        private void toolStripButtonMuiltLine_Click(object sender, EventArgs e)
        {
            toolStripButtonMuiltLine.Checked = !toolStripButtonMuiltLine.Checked;
            if (reportDesignControl1.SelectControl is MedTextBox)
            {
                (reportDesignControl1.SelectControl as MedTextBox).Properties.AutoHeight = toolStripButtonMuiltLine.Checked;// .Multiline = toolStripButtonMuiltLine.Checked;
            }
        }

        private void toolStripButtonBorder_Click(object sender, EventArgs e)
        {
            toolStripButtonBorder.Checked = !toolStripButtonBorder.Checked;
            reportDesignControl1.DrawBorder = toolStripButtonBorder.Checked;
        }

        private void toolStripButtonCopy_Click(object sender, EventArgs e)
        {
            reportDesignControl1.Copy();
        }

        private void toolStripPaste_Click(object sender, EventArgs e)
        {
            reportDesignControl1.Paste();
        }

        private void vScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            if (vScrollBar1.Visible)
            {
                reportDesignControl1.Top = -vScrollBar1.Value;
            }
        }

        private void medPropertiesEditor1_ValueChanged(object sender, string key, object value)
        {
            if (reportDesignControl1.SelectControls.Count == 1)
            {
                DesignableField fld = medPropertiesEditor1.EditObject as DesignableField;
                if (fld != null)
                {
                    fld.UpdateControl(reportDesignControl1.SelectControl);
                    reportDesignControl1.IsChanged = true;
                }
            }
        }

        #endregion  控件事件

        private bool _lockKeyMove = false;
        private void medPropertiesEditor1_Enter(object sender, EventArgs e)
        {
            _lockKeyMove = true;
        }

        private void medPropertiesEditor1_Leave(object sender, EventArgs e)
        {
            _lockKeyMove = false;
        }

        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    if (_actionButton != null)
        //    {
        //        _actionButton.PerformClick(); 
        //    }
        //}
        private void TimeStart(object sender, MouseEventArgs e)
        {
            _actionButton = (sender as ToolStripItem);
            //timer1.Start();
        }
        private void TimeStop(object sender, EventArgs e)
        {
            //timer1.Stop();
        }

        private void TimeStop(object sender, MouseEventArgs e)
        {
            //timer1.Stop();
        }

        private void cmbPageBig_SelectedIndexChanged(object sender, EventArgs e)
        {
            double dpi = new Bitmap(1024, 1024, this.CreateGraphics()).VerticalResolution;
            int weight = 0, height = 0;
            if (cmbPageBig.SelectedIndex == 0)
            {
                weight = 400;
                height = 500;
            }
            else if (cmbPageBig.SelectedIndex == 1)
            {
                weight = (int)(dpi * 42 / 2.54);
                height = (int)(dpi * 29.7 / 2.54);
            }
            else if (cmbPageBig.SelectedIndex == 2)
            {
                weight = (int)(dpi * 21 / 2.54);
                height = (int)(dpi * 29.7 / 2.54);
            }
            this.txtWidth.TextChanged -= new System.EventHandler(this.txtWidth_TextChanged);
            this.txtHeight.TextChanged -= new System.EventHandler(this.txtHeight_TextChanged);
            txtWidth.Text = weight.ToString();
            txtHeight.Text = height.ToString();
            reportDesignControl1.Width = weight;
            reportDesignControl1.Height = height;
            this.txtWidth.TextChanged += new System.EventHandler(this.txtWidth_TextChanged);
            this.txtHeight.TextChanged += new System.EventHandler(this.txtHeight_TextChanged);
            setScrollBar();
        }

        private void hScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            if (hScrollBar1.Visible)
            {
                reportDesignControl1.Left = -hScrollBar1.Value;
            }
        }

        private void reportDesignControl1_DoubleClick(object sender, EventArgs e)
        {
            setting = new HeaderSettingsFrm(cmbDocument.Text, medPrintPreview1);
            setting.Show();
        }

        private void medPrintPreview1_CellClick(PrintCell cell, object sender, EventArgs e)
        {
            reportDesignControl1.SelectControl = medPrintPreview1;
            txtWidth.Text = medPrintPreview1.Width.ToString();
            txtHeight.Text = medPrintPreview1.Height.ToString();
        }

        private void cmbDocument_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRow[] row = main.Select("DOCUMENT_NAME='" + cmbDocument.Text + "' and WARD_CODE='" + DataOperator.WardCode + "'");
            if (row.Length > 0)
            {
                selectDocument = (DataSetModel.CareDocs.MED_DOCUMENT_DESIGN_MAINRow)row[0];
                detail = DataOperator.GetDocumentDesignDetail(cmbDocument.Text, DataOperator.WardCode);
            }
            else
            {
                selectDocument = null;
            }
            reflashData();
            
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cmbDocument.Text.Trim() == "")
            {
                Sundries.MessageBox("请选择或输入单子名称，才能保存！", 5);
                return;
            }
            if (Sundries.MessageBox("确实要删除单子" + cmbDocument.Text + "吗？", Com.MedicalSystem.Common.Utilities.Sundries.CAPTION, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }
            detail = DataOperator.GetDocumentDesignDetail(cmbDocument.Text, DataOperator.WardCode);
            for (int i = detail.Count - 1; i >= 0; i--)
            {
                detail.Rows[i].Delete();
            }
            for (int i = main.Count - 1; i >= 0; i--)
            {
                if (main.Rows[i]["DOCUMENT_NAME"].ToString() == cmbDocument.Text && main.Rows[i]["WARD_CODE"].ToString() == DataOperator.WardCode)
                {
                    main.Rows[i].Delete();
                }
            }
            if (DataOperator.UpdateDocumentDesignDetail(detail) >= 0 && DataOperator.UpdateDocumentDesignMain(main) >= 0)
            {
                Sundries.MessageBox("删除成功！", 3);
            }
            cmbDocument.Text = "";
            getDesignControl();
            cmbDocument.Items.Clear();
            foreach (DataSetModel.CareDocs.MED_DOCUMENT_DESIGN_MAINRow row in main.Rows)
            {
                cmbDocument.Items.Add(row.DOCUMENT_NAME);
            }
        }
    }
   
}