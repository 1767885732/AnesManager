namespace Wis.Anes.Views
{
    partial class BloodGasDataEditor
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
            this.lblMsg = new System.Windows.Forms.Label();
            this.btnCancel = new Wis.Anes.Framework.Controls.MedButton();
            this.btnSave = new Wis.Anes.Framework.Controls.MedButton();
            this.btnAdd = new Wis.Anes.Framework.Controls.MedButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.medPanel1 = new Wis.Anes.Framework.Controls.MedPanel();
            this.medLabel1 = new Wis.Anes.Framework.Controls.MedLabel();
            this.medPanel2 = new Wis.Anes.Framework.Controls.MedPanel();
            this.btnRefresh = new Wis.Anes.Framework.Controls.MedButton();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.medPanel1)).BeginInit();
            this.medPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.medPanel2)).BeginInit();
            this.medPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(21, 22);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(38, 14);
            this.lblMsg.TabIndex = 42;
            this.lblMsg.Text = "label2";
            // 
            // btnCancel
            // 
            this.btnCancel.ActionName = null;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.AutoImage = false;
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.BindControl = null;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.HasBorder = true;
            this.btnCancel.IsMenu = false;
            this.btnCancel.IsMouseHover = true;
            this.btnCancel.Location = new System.Drawing.Point(258, 12);
            this.btnCancel.MenuIndex = 0;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.PageName = null;
            this.btnCancel.Parameters = null;
            this.btnCancel.ShortcutKeys = null;
            this.btnCancel.ShowText = true;
            this.btnCancel.Size = new System.Drawing.Size(101, 29);
            this.btnCancel.TabIndex = 40;
            this.btnCancel.Text = "取消";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.ActionName = null;
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.AutoImage = false;
            this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSave.BindControl = null;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Enabled = false;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.HasBorder = true;
            this.btnSave.IsMenu = false;
            this.btnSave.IsMouseHover = true;
            this.btnSave.Location = new System.Drawing.Point(475, 12);
            this.btnSave.MenuIndex = 0;
            this.btnSave.Name = "btnSave";
            this.btnSave.PageName = null;
            this.btnSave.Parameters = null;
            this.btnSave.ShortcutKeys = null;
            this.btnSave.ShowText = true;
            this.btnSave.Size = new System.Drawing.Size(101, 29);
            this.btnSave.TabIndex = 30;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.ActionName = null;
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.AutoImage = false;
            this.btnAdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAdd.BindControl = null;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.HasBorder = true;
            this.btnAdd.IsMenu = false;
            this.btnAdd.IsMouseHover = true;
            this.btnAdd.Location = new System.Drawing.Point(366, 12);
            this.btnAdd.MenuIndex = 0;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.PageName = null;
            this.btnAdd.Parameters = null;
            this.btnAdd.ShortcutKeys = null;
            this.btnAdd.ShowText = true;
            this.btnAdd.Size = new System.Drawing.Size(101, 29);
            this.btnAdd.TabIndex = 30;
            this.btnAdd.Text = "新增(&A)";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.gridControl1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 40);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(702, 482);
            this.panel3.TabIndex = 45;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(702, 482);
            this.gridControl1.TabIndex = 30;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AutoPopulateColumns = false;
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gridView1_ValidatingEditor);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.gridView1.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanging);
            this.gridView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridView1_MouseDown);
            this.gridView1.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gridView1_ShowingEditor);
            this.gridView1.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView1_RowCellClick);
            this.gridView1.ShowGridMenu += new DevExpress.XtraGrid.Views.Grid.GridMenuEventHandler(this.gridView1_ShowGridMenu);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "血气分析项目";
            this.gridColumn1.FieldName = "BLG_CODE";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 100;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "项目名称";
            this.gridColumn2.FieldName = "BLG_NAME";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 100;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn3.Caption = "参考值";
            this.gridColumn3.FieldName = "BLG_REFER_VALUE";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 100;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "BLG_CODE";
            this.dataGridViewTextBoxColumn1.HeaderText = "血气分析项目";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "BLG_NAME";
            this.dataGridViewTextBoxColumn2.HeaderText = "项目名称";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "BLG_REFER_VALUE";
            this.dataGridViewTextBoxColumn3.HeaderText = "参考值";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // medPanel1
            // 
            this.medPanel1.Controls.Add(this.medLabel1);
            this.medPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.medPanel1.Location = new System.Drawing.Point(0, 0);
            this.medPanel1.Name = "medPanel1";
            this.medPanel1.Size = new System.Drawing.Size(702, 40);
            this.medPanel1.TabIndex = 46;
            // 
            // medLabel1
            // 
            this.medLabel1.Appearance.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.medLabel1.Appearance.Options.UseFont = true;
            this.medLabel1.Appearance.Options.UseTextOptions = true;
            this.medLabel1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.medLabel1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.medLabel1.BottomLine = false;
            this.medLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.medLabel1.DotBorder = false;
            this.medLabel1.Image = null;
            this.medLabel1.Location = new System.Drawing.Point(2, 2);
            this.medLabel1.MultiLine = false;
            this.medLabel1.Name = "medLabel1";
            this.medLabel1.NoPrint = false;
            this.medLabel1.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.medLabel1.PrintXOffSet = 0F;
            this.medLabel1.PrintYOffSet = 0F;
            this.medLabel1.Size = new System.Drawing.Size(698, 36);
            this.medLabel1.SymbolType = Wis.Anes.Framework.Controls.MedSymbolType.None;
            this.medLabel1.TabIndex = 0;
            this.medLabel1.Text = "血气分析";
            this.medLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.medLabel1.VarKey = null;
            // 
            // medPanel2
            // 
            this.medPanel2.Controls.Add(this.btnRefresh);
            this.medPanel2.Controls.Add(this.btnCancel);
            this.medPanel2.Controls.Add(this.lblMsg);
            this.medPanel2.Controls.Add(this.btnSave);
            this.medPanel2.Controls.Add(this.btnAdd);
            this.medPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.medPanel2.Location = new System.Drawing.Point(0, 522);
            this.medPanel2.Name = "medPanel2";
            this.medPanel2.Size = new System.Drawing.Size(702, 52);
            this.medPanel2.TabIndex = 47;
            // 
            // btnRefresh
            // 
            this.btnRefresh.ActionName = null;
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.AutoImage = false;
            this.btnRefresh.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRefresh.BindControl = null;
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.HasBorder = true;
            this.btnRefresh.IsMenu = false;
            this.btnRefresh.IsMouseHover = true;
            this.btnRefresh.Location = new System.Drawing.Point(583, 12);
            this.btnRefresh.MenuIndex = 0;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.PageName = null;
            this.btnRefresh.Parameters = null;
            this.btnRefresh.ShortcutKeys = null;
            this.btnRefresh.ShowText = true;
            this.btnRefresh.Size = new System.Drawing.Size(101, 29);
            this.btnRefresh.TabIndex = 43;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // BloodGasDataEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.medPanel2);
            this.Controls.Add(this.medPanel1);
            this.Name = "BloodGasDataEditor";
            this.Size = new System.Drawing.Size(702, 574);
            this.Load += new System.EventHandler(this.BloodGasDataEditor_Load);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.medPanel1)).EndInit();
            this.medPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.medPanel2)).EndInit();
            this.medPanel2.ResumeLayout(false);
            this.medPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Wis.Anes.Framework.Controls.MedButton btnSave;
        private Wis.Anes.Framework.Controls.MedButton btnCancel;
        private Wis.Anes.Framework.Controls.MedButton btnAdd;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private Wis.Anes.Framework.Controls.MedPanel medPanel1;
        private Wis.Anes.Framework.Controls.MedLabel medLabel1;
        private Wis.Anes.Framework.Controls.MedPanel medPanel2;
        private Wis.Anes.Framework.Controls.MedButton btnRefresh;


    }
}
