namespace Com.ICIS.Icu
{
    partial class HeaderSettingsFrm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.medDGrdViewAttribute = new Com.MedicalSystem.Common.Controls.MedDataGridView();
            this.medPanel = new Com.MedicalSystem.Common.Controls.MedPanel();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.medBtnRefsh = new Com.MedicalSystem.Common.Controls.MedButton();
            this.medBtnDown = new Com.MedicalSystem.Common.Controls.MedButton();
            this.medBtnUp = new Com.MedicalSystem.Common.Controls.MedButton();
            this.btnSaveDocs = new Com.MedicalSystem.Common.Controls.MedButton();
            this.cmbBoxDocsName = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.medBtnSaveAttribute = new Com.MedicalSystem.Common.Controls.MedButton();
            this.medBtnDelete = new Com.MedicalSystem.Common.Controls.MedButton();
            this.medBtnAdd = new Com.MedicalSystem.Common.Controls.MedButton();
            this.treeViewHeader = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.medDGrdViewAttribute)).BeginInit();
            this.medPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBoxDocsName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // medDGrdViewAttribute
            // 
            this.medDGrdViewAttribute.AllowUserToAddRows = false;
            this.medDGrdViewAttribute.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(226)))), ((int)(((byte)(235)))));
            this.medDGrdViewAttribute.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.medDGrdViewAttribute.AutoDataError = true;
            this.medDGrdViewAttribute.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(182)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.medDGrdViewAttribute.DefaultCellStyle = dataGridViewCellStyle2;
            this.medDGrdViewAttribute.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.medDGrdViewAttribute.IsOwnerDrawColumnHead = true;
            this.medDGrdViewAttribute.IsOwnerDrawRownHead = false;
            this.medDGrdViewAttribute.Location = new System.Drawing.Point(521, 80);
            this.medDGrdViewAttribute.Name = "medDGrdViewAttribute";
            this.medDGrdViewAttribute.RowHeadersVisible = false;
            this.medDGrdViewAttribute.RowTemplate.Height = 23;
            this.medDGrdViewAttribute.Size = new System.Drawing.Size(301, 502);
            this.medDGrdViewAttribute.StringTrim = true;
            this.medDGrdViewAttribute.TabIndex = 23;
            this.medDGrdViewAttribute.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.medDGrdViewAttribute_CellEndEdit);
            this.medDGrdViewAttribute.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.medDGrdViewAttribute_CellMouseDoubleClick);
            this.medDGrdViewAttribute.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.medDGrdViewAttribute_EditingControlShowing);
            this.medDGrdViewAttribute.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.medDGrdViewAttribute_CellEnter);
            // 
            // medPanel
            // 
            this.medPanel.BorderColor = System.Drawing.Color.DarkGray;
            this.medPanel.Controls.Add(this.trackBar1);
            this.medPanel.Controls.Add(this.medBtnRefsh);
            this.medPanel.Controls.Add(this.medBtnDown);
            this.medPanel.Controls.Add(this.medBtnUp);
            this.medPanel.Controls.Add(this.btnSaveDocs);
            this.medPanel.Controls.Add(this.cmbBoxDocsName);
            this.medPanel.Controls.Add(this.label1);
            this.medPanel.Controls.Add(this.medBtnSaveAttribute);
            this.medPanel.Controls.Add(this.medBtnDelete);
            this.medPanel.Controls.Add(this.medBtnAdd);
            this.medPanel.Controls.Add(this.treeViewHeader);
            this.medPanel.Controls.Add(this.medDGrdViewAttribute);
            this.medPanel.CustomBorder = false;
            this.medPanel.IsTitleAtFoot = false;
            this.medPanel.Location = new System.Drawing.Point(3, 15);
            this.medPanel.Name = "medPanel";
            this.medPanel.Size = new System.Drawing.Size(987, 603);
            this.medPanel.TabIndex = 24;
            this.medPanel.Title = "";
            this.medPanel.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.medPanel.TitleFont = new System.Drawing.Font("宋体", 9F);
            this.medPanel.TitleHeight = 20;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(521, 25);
            this.trackBar1.Maximum = 50;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(301, 45);
            this.trackBar1.TabIndex = 40;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // medBtnRefsh
            // 
            this.medBtnRefsh.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.medBtnRefsh.Appearance.Options.UseFont = true;
            this.medBtnRefsh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.medBtnRefsh.Location = new System.Drawing.Point(296, 39);
            this.medBtnRefsh.Name = "medBtnRefsh";
            this.medBtnRefsh.Size = new System.Drawing.Size(51, 23);
            this.medBtnRefsh.TabIndex = 39;
            this.medBtnRefsh.Text = "刷新";
            this.medBtnRefsh.Click += new System.EventHandler(this.medBtnRefsh_Click);
            // 
            // medBtnDown
            // 
            this.medBtnDown.Appearance.Font = new System.Drawing.Font("黑体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.medBtnDown.Appearance.Options.UseFont = true;
            this.medBtnDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.medBtnDown.Location = new System.Drawing.Point(434, 194);
            this.medBtnDown.Name = "medBtnDown";
            this.medBtnDown.Size = new System.Drawing.Size(44, 33);
            this.medBtnDown.TabIndex = 38;
            this.medBtnDown.Text = "↓";
            this.medBtnDown.Visible = false;
            this.medBtnDown.Click += new System.EventHandler(this.medBtnDown_Click);
            // 
            // medBtnUp
            // 
            this.medBtnUp.Appearance.Font = new System.Drawing.Font("黑体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.medBtnUp.Appearance.Options.UseFont = true;
            this.medBtnUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.medBtnUp.Location = new System.Drawing.Point(434, 130);
            this.medBtnUp.Name = "medBtnUp";
            this.medBtnUp.Size = new System.Drawing.Size(44, 33);
            this.medBtnUp.TabIndex = 37;
            this.medBtnUp.Text = "↑";
            this.medBtnUp.Visible = false;
            this.medBtnUp.Click += new System.EventHandler(this.medBtnUp_Click);
            // 
            // btnSaveDocs
            // 
            this.btnSaveDocs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveDocs.Location = new System.Drawing.Point(855, 313);
            this.btnSaveDocs.Name = "btnSaveDocs";
            this.btnSaveDocs.Size = new System.Drawing.Size(87, 36);
            this.btnSaveDocs.TabIndex = 36;
            this.btnSaveDocs.Text = "全部保存";
            this.btnSaveDocs.Click += new System.EventHandler(this.btnSaveDocs_Click);
            // 
            // cmbBoxDocsName
            // 
            this.cmbBoxDocsName.Location = new System.Drawing.Point(124, 39);
            this.cmbBoxDocsName.Name = "cmbBoxDocsName";
            this.cmbBoxDocsName.Size = new System.Drawing.Size(141, 21);
            this.cmbBoxDocsName.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(38, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 14);
            this.label1.TabIndex = 31;
            this.label1.Text = "表单名称：";
            // 
            // medBtnSaveAttribute
            // 
            this.medBtnSaveAttribute.Cursor = System.Windows.Forms.Cursors.Hand;
            this.medBtnSaveAttribute.Location = new System.Drawing.Point(855, 251);
            this.medBtnSaveAttribute.Name = "medBtnSaveAttribute";
            this.medBtnSaveAttribute.Size = new System.Drawing.Size(87, 36);
            this.medBtnSaveAttribute.TabIndex = 30;
            this.medBtnSaveAttribute.Text = "更改属性";
            this.medBtnSaveAttribute.Click += new System.EventHandler(this.medBtnSaveAttribute_Click);
            // 
            // medBtnDelete
            // 
            this.medBtnDelete.Appearance.Font = new System.Drawing.Font("黑体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.medBtnDelete.Appearance.Options.UseFont = true;
            this.medBtnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.medBtnDelete.Location = new System.Drawing.Point(434, 316);
            this.medBtnDelete.Name = "medBtnDelete";
            this.medBtnDelete.Size = new System.Drawing.Size(44, 33);
            this.medBtnDelete.TabIndex = 28;
            this.medBtnDelete.Text = "-";
            this.medBtnDelete.Click += new System.EventHandler(this.medBtnDelete_Click);
            // 
            // medBtnAdd
            // 
            this.medBtnAdd.Appearance.Font = new System.Drawing.Font("黑体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.medBtnAdd.Appearance.Options.UseFont = true;
            this.medBtnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.medBtnAdd.Location = new System.Drawing.Point(434, 252);
            this.medBtnAdd.Name = "medBtnAdd";
            this.medBtnAdd.Size = new System.Drawing.Size(44, 33);
            this.medBtnAdd.TabIndex = 26;
            this.medBtnAdd.Text = "+";
            this.medBtnAdd.Click += new System.EventHandler(this.medBtnAdd_Click);
            // 
            // treeViewHeader
            // 
            this.treeViewHeader.Location = new System.Drawing.Point(36, 80);
            this.treeViewHeader.Name = "treeViewHeader";
            this.treeViewHeader.Size = new System.Drawing.Size(350, 502);
            this.treeViewHeader.TabIndex = 24;
            this.treeViewHeader.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewHeader_AfterSelect);
            // 
            // HeaderSettingsFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 629);
            this.Controls.Add(this.medPanel);
            this.Name = "HeaderSettingsFrm";
            this.Text = "列头设置";
            this.Load += new System.EventHandler(this.HeaderSettings_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HeaderSettings_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.medDGrdViewAttribute)).EndInit();
            this.medPanel.ResumeLayout(false);
            this.medPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBoxDocsName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Com.MedicalSystem.Common.Controls.MedDataGridView medDGrdViewAttribute;
        private Com.MedicalSystem.Common.Controls.MedPanel medPanel;
        private System.Windows.Forms.TreeView treeViewHeader;
        private Com.MedicalSystem.Common.Controls.MedButton medBtnDelete;
        private Com.MedicalSystem.Common.Controls.MedButton medBtnAdd;
        private Com.MedicalSystem.Common.Controls.MedButton medBtnSaveAttribute;
        private DevExpress.XtraEditors.LabelControl label1;
        private DevExpress.XtraEditors.ComboBoxEdit cmbBoxDocsName;
        private Com.MedicalSystem.Common.Controls.MedButton btnSaveDocs;
        private Com.MedicalSystem.Common.Controls.MedButton medBtnDown;
        private Com.MedicalSystem.Common.Controls.MedButton medBtnUp;
        private Com.MedicalSystem.Common.Controls.MedButton medBtnRefsh;
        private System.Windows.Forms.TrackBar trackBar1;
    }
}