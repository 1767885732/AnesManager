namespace Wis.Anes.Framework
{
    partial class BloodGasTemplet
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.txtNewTempletName = new DevExpress.XtraEditors.TextEdit();
            this.btnAddTemplet = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.comboBoxEditSample = new DevExpress.XtraEditors.ComboBoxEdit();
            this.groupControl5 = new DevExpress.XtraEditors.GroupControl();
            this.dgvItemCanSelect = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl6 = new DevExpress.XtraEditors.GroupControl();
            this.dgvItemSelected = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelControl6 = new DevExpress.XtraEditors.PanelControl();
            this.btnMenuUp = new DevExpress.XtraEditors.SimpleButton();
            this.btnMenuDown = new DevExpress.XtraEditors.SimpleButton();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.medPanel1 = new Wis.Anes.Framework.Controls.MedPanel();
            this.medLabel1 = new Wis.Anes.Framework.Controls.MedLabel();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnDel = new Wis.Anes.Framework.Controls.MedButton();
            this.btnSave = new Wis.Anes.Framework.Controls.MedButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewTempletName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditSample.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).BeginInit();
            this.groupControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemCanSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl6)).BeginInit();
            this.groupControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemSelected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).BeginInit();
            this.panelControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.medPanel1)).BeginInit();
            this.medPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.txtNewTempletName);
            this.panelControl4.Controls.Add(this.btnAddTemplet);
            this.panelControl4.Controls.Add(this.labelControl1);
            this.panelControl4.Controls.Add(this.comboBoxEditSample);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl4.Location = new System.Drawing.Point(0, 40);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(638, 34);
            this.panelControl4.TabIndex = 50;
            // 
            // txtNewTempletName
            // 
            this.txtNewTempletName.Location = new System.Drawing.Point(287, 9);
            this.txtNewTempletName.Name = "txtNewTempletName";
            this.txtNewTempletName.Properties.MaxLength = 15;
            this.txtNewTempletName.Size = new System.Drawing.Size(188, 21);
            this.txtNewTempletName.TabIndex = 22;
            this.txtNewTempletName.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.txtNewTempletName_EditValueChanging);
            // 
            // btnAddTemplet
            // 
            this.btnAddTemplet.Location = new System.Drawing.Point(481, 7);
            this.btnAddTemplet.Name = "btnAddTemplet";
            this.btnAddTemplet.Size = new System.Drawing.Size(68, 23);
            this.btnAddTemplet.TabIndex = 21;
            this.btnAddTemplet.Text = "增加模板";
            this.btnAddTemplet.Click += new System.EventHandler(this.btnAddTemplet_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(6, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(76, 14);
            this.labelControl1.TabIndex = 20;
            this.labelControl1.Text = "选择血气模板:";
            // 
            // comboBoxEditSample
            // 
            this.comboBoxEditSample.EditValue = "";
            this.comboBoxEditSample.Location = new System.Drawing.Point(88, 9);
            this.comboBoxEditSample.Name = "comboBoxEditSample";
            this.comboBoxEditSample.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditSample.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEditSample.Size = new System.Drawing.Size(193, 21);
            this.comboBoxEditSample.TabIndex = 19;
            this.comboBoxEditSample.SelectedIndexChanged += new System.EventHandler(this.comboBoxEditSample_SelectedIndexChanged);
            // 
            // groupControl5
            // 
            this.groupControl5.Controls.Add(this.dgvItemCanSelect);
            this.groupControl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl5.Location = new System.Drawing.Point(0, 0);
            this.groupControl5.Name = "groupControl5";
            this.groupControl5.Size = new System.Drawing.Size(309, 341);
            this.groupControl5.TabIndex = 0;
            this.groupControl5.Text = "备选项目";
            // 
            // dgvItemCanSelect
            // 
            this.dgvItemCanSelect.AllowUserToAddRows = false;
            this.dgvItemCanSelect.AllowUserToDeleteRows = false;
            this.dgvItemCanSelect.AllowUserToResizeRows = false;
            this.dgvItemCanSelect.BackgroundColor = System.Drawing.Color.White;
            this.dgvItemCanSelect.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItemCanSelect.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Column1});
            this.dgvItemCanSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItemCanSelect.Location = new System.Drawing.Point(2, 23);
            this.dgvItemCanSelect.MultiSelect = false;
            this.dgvItemCanSelect.Name = "dgvItemCanSelect";
            this.dgvItemCanSelect.ReadOnly = true;
            this.dgvItemCanSelect.RowHeadersVisible = false;
            this.dgvItemCanSelect.RowHeadersWidth = 10;
            this.dgvItemCanSelect.RowTemplate.Height = 23;
            this.dgvItemCanSelect.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvItemCanSelect.Size = new System.Drawing.Size(305, 316);
            this.dgvItemCanSelect.TabIndex = 7;
            this.dgvItemCanSelect.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItemCanSelect_CellDoubleClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.HeaderText = "项目代码";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "显示名称";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 74);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.Controls.Add(this.groupControl5);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            this.splitContainerControl2.Panel2.Controls.Add(this.groupControl6);
            this.splitContainerControl2.Panel2.Controls.Add(this.panelControl6);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(638, 341);
            this.splitContainerControl2.SplitterPosition = 309;
            this.splitContainerControl2.TabIndex = 51;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // groupControl6
            // 
            this.groupControl6.Controls.Add(this.dgvItemSelected);
            this.groupControl6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl6.Location = new System.Drawing.Point(0, 0);
            this.groupControl6.Name = "groupControl6";
            this.groupControl6.Size = new System.Drawing.Size(323, 306);
            this.groupControl6.TabIndex = 0;
            this.groupControl6.Text = "当前模板项目";
            // 
            // dgvItemSelected
            // 
            this.dgvItemSelected.AllowUserToAddRows = false;
            this.dgvItemSelected.AllowUserToDeleteRows = false;
            this.dgvItemSelected.AllowUserToResizeRows = false;
            this.dgvItemSelected.BackgroundColor = System.Drawing.Color.White;
            this.dgvItemSelected.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItemSelected.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.Column2});
            this.dgvItemSelected.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItemSelected.Location = new System.Drawing.Point(2, 23);
            this.dgvItemSelected.MultiSelect = false;
            this.dgvItemSelected.Name = "dgvItemSelected";
            this.dgvItemSelected.ReadOnly = true;
            this.dgvItemSelected.RowHeadersVisible = false;
            this.dgvItemSelected.RowHeadersWidth = 10;
            this.dgvItemSelected.RowTemplate.Height = 23;
            this.dgvItemSelected.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvItemSelected.Size = new System.Drawing.Size(319, 281);
            this.dgvItemSelected.TabIndex = 7;
            this.dgvItemSelected.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItemSelected_CellDoubleClick);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "项目代码";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "显示名称";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // panelControl6
            // 
            this.panelControl6.Controls.Add(this.btnMenuUp);
            this.panelControl6.Controls.Add(this.btnMenuDown);
            this.panelControl6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl6.Location = new System.Drawing.Point(0, 306);
            this.panelControl6.Name = "panelControl6";
            this.panelControl6.Size = new System.Drawing.Size(323, 35);
            this.panelControl6.TabIndex = 1;
            // 
            // btnMenuUp
            // 
            this.btnMenuUp.Location = new System.Drawing.Point(5, 6);
            this.btnMenuUp.Name = "btnMenuUp";
            this.btnMenuUp.Size = new System.Drawing.Size(54, 23);
            this.btnMenuUp.TabIndex = 10;
            this.btnMenuUp.Text = "上移";
            this.btnMenuUp.Click += new System.EventHandler(this.btnMenuUp_Click);
            // 
            // btnMenuDown
            // 
            this.btnMenuDown.Location = new System.Drawing.Point(65, 6);
            this.btnMenuDown.Name = "btnMenuDown";
            this.btnMenuDown.Size = new System.Drawing.Size(54, 23);
            this.btnMenuDown.TabIndex = 11;
            this.btnMenuDown.Text = "下移";
            this.btnMenuDown.Click += new System.EventHandler(this.btnMenuDown_Click);
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.HeaderText = "项目代码";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.HeaderText = "显示名称";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // medPanel1
            // 
            this.medPanel1.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.medPanel1.Appearance.Options.UseBackColor = true;
            this.medPanel1.Controls.Add(this.medLabel1);
            this.medPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.medPanel1.Location = new System.Drawing.Point(0, 0);
            this.medPanel1.Name = "medPanel1";
            this.medPanel1.Size = new System.Drawing.Size(638, 40);
            this.medPanel1.TabIndex = 17;
            // 
            // medLabel1
            // 
            this.medLabel1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.medLabel1.Appearance.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.medLabel1.Appearance.Options.UseBackColor = true;
            this.medLabel1.Appearance.Options.UseFont = true;
            this.medLabel1.Appearance.Options.UseTextOptions = true;
            this.medLabel1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.medLabel1.BottomLine = false;
            this.medLabel1.DotBorder = false;
            this.medLabel1.Image = null;
            this.medLabel1.Location = new System.Drawing.Point(2, 11);
            this.medLabel1.MultiLine = false;
            this.medLabel1.Name = "medLabel1";
            this.medLabel1.NoPrint = false;
            this.medLabel1.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.medLabel1.PrintXOffSet = 0F;
            this.medLabel1.PrintYOffSet = 0F;
            this.medLabel1.Size = new System.Drawing.Size(92, 20);
            this.medLabel1.SymbolType = Wis.Anes.Framework.Controls.MedSymbolType.None;
            this.medLabel1.TabIndex = 0;
            this.medLabel1.Text = "血气模板";
            this.medLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.medLabel1.VarKey = null;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnDel);
            this.panelControl1.Controls.Add(this.btnSave);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 415);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(638, 46);
            this.panelControl1.TabIndex = 52;
            // 
            // btnDel
            // 
            this.btnDel.ActionName = null;
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDel.AutoImage = false;
            this.btnDel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDel.BindControl = null;
            this.btnDel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDel.HasBorder = true;
            this.btnDel.IsMenu = false;
            this.btnDel.IsMouseHover = true;
            this.btnDel.Location = new System.Drawing.Point(515, 9);
            this.btnDel.MenuIndex = 0;
            this.btnDel.Name = "btnDel";
            this.btnDel.PageName = null;
            this.btnDel.Parameters = null;
            this.btnDel.ShortcutKeys = null;
            this.btnDel.ShowText = true;
            this.btnDel.Size = new System.Drawing.Size(101, 29);
            this.btnDel.TabIndex = 12;
            this.btnDel.Text = "删 除(&D)";
            this.btnDel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnSave
            // 
            this.btnSave.ActionName = null;
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.AutoImage = false;
            this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSave.BindControl = null;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.HasBorder = true;
            this.btnSave.IsMenu = false;
            this.btnSave.IsMouseHover = true;
            this.btnSave.Location = new System.Drawing.Point(408, 9);
            this.btnSave.MenuIndex = 0;
            this.btnSave.Name = "btnSave";
            this.btnSave.PageName = null;
            this.btnSave.Parameters = null;
            this.btnSave.ShortcutKeys = null;
            this.btnSave.ShowText = true;
            this.btnSave.Size = new System.Drawing.Size(101, 29);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "保 存(&S)";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // BloodGasTemplet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl2);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panelControl4);
            this.Controls.Add(this.medPanel1);
            this.Name = "BloodGasTemplet";
            this.Size = new System.Drawing.Size(638, 461);
            this.Load += new System.EventHandler(this.BloodGasTemplet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            this.panelControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewTempletName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditSample.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).EndInit();
            this.groupControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemCanSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl6)).EndInit();
            this.groupControl6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemSelected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).EndInit();
            this.panelControl6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.medPanel1)).EndInit();
            this.medPanel1.ResumeLayout(false);
            this.medPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Wis.Anes.Framework.Controls.MedPanel medPanel1;
        private Wis.Anes.Framework.Controls.MedLabel medLabel1;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditSample;
        private DevExpress.XtraEditors.GroupControl groupControl5;
        private System.Windows.Forms.DataGridView dgvItemCanSelect;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private DevExpress.XtraEditors.GroupControl groupControl6;
        private System.Windows.Forms.DataGridView dgvItemSelected;
        private DevExpress.XtraEditors.PanelControl panelControl6;
        private DevExpress.XtraEditors.SimpleButton btnMenuUp;
        private DevExpress.XtraEditors.SimpleButton btnMenuDown;
        private DevExpress.XtraEditors.TextEdit txtNewTempletName;
        private DevExpress.XtraEditors.SimpleButton btnAddTemplet;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private Wis.Anes.Framework.Controls.MedButton btnSave;
        private Wis.Anes.Framework.Controls.MedButton btnDel;
    }
}
