namespace Wis.Anes.Framework
{
    partial class TimePointDrugEditor
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel16 = new System.Windows.Forms.Panel();
            this.dataGridViewTarget = new System.Windows.Forms.DataGridView();
            this.ITEM_NAME1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DOSAGE1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DOSAGE_UNITS1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.End_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PERFORM_SPEED1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SPEED_UNIT1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CONCENTRATION1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CONCENTRATION_UNIT1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DURATIVE_INDICATOR1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ADMINISTRATOR1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ITEM_CLASS1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ITEM_SPEC1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ITEM_CODE1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SUPPLIER_NAME1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitterControl2 = new DevExpress.XtraEditors.SplitterControl();
            this.panel15 = new System.Windows.Forms.Panel();
            this.btnAdd = new Wis.Anes.Framework.Controls.MedButton();
            this.label1 = new System.Windows.Forms.Label();
            this.medButton14 = new Wis.Anes.Framework.Controls.MedButton();
            this.btnRefresh = new Wis.Anes.Framework.Controls.MedButton();
            this.btnSave = new Wis.Anes.Framework.Controls.MedButton();
            this.dataGridViewSource = new System.Windows.Forms.DataGridView();
            this.ITEM_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DOSAGE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DOSAGE_UNITS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PERFORM_SPEED = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SPEED_UNIT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CONCENTRATION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CONCENTRATION_UNIT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DURATIVE_INDICATOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ADMINISTRATOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ITEM_CLASS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ITEM_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ITEM_SPEC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SUPPLIER_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel11 = new System.Windows.Forms.Panel();
            this.txtFilter = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.radioGroupTypes = new DevExpress.XtraEditors.RadioGroup();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel3.SuspendLayout();
            this.panel16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTarget)).BeginInit();
            this.panel15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSource)).BeginInit();
            this.panel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupTypes.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel16);
            this.panel3.Controls.Add(this.panel15);
            this.panel3.Controls.Add(this.dataGridViewSource);
            this.panel3.Controls.Add(this.panel11);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(706, 502);
            this.panel3.TabIndex = 3;
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.dataGridViewTarget);
            this.panel16.Controls.Add(this.splitterControl2);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel16.Location = new System.Drawing.Point(0, 168);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(706, 297);
            this.panel16.TabIndex = 42;
            // 
            // dataGridViewTarget
            // 
            this.dataGridViewTarget.AllowUserToAddRows = false;
            this.dataGridViewTarget.AllowUserToDeleteRows = false;
            this.dataGridViewTarget.AllowUserToResizeColumns = false;
            this.dataGridViewTarget.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.dataGridViewTarget.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTarget.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewTarget.ColumnHeadersHeight = 17;
            this.dataGridViewTarget.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewTarget.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ITEM_NAME1,
            this.DOSAGE1,
            this.DOSAGE_UNITS1,
            this.End_Date,
            this.PERFORM_SPEED1,
            this.SPEED_UNIT1,
            this.CONCENTRATION1,
            this.CONCENTRATION_UNIT1,
            this.DURATIVE_INDICATOR1,
            this.ADMINISTRATOR1,
            this.ITEM_CLASS1,
            this.ITEM_SPEC1,
            this.ITEM_CODE1,
            this.SUPPLIER_NAME1});
            this.dataGridViewTarget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTarget.Location = new System.Drawing.Point(0, 6);
            this.dataGridViewTarget.Name = "dataGridViewTarget";
            this.dataGridViewTarget.RowHeadersVisible = false;
            this.dataGridViewTarget.RowHeadersWidth = 10;
            this.dataGridViewTarget.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewTarget.RowTemplate.Height = 23;
            this.dataGridViewTarget.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewTarget.Size = new System.Drawing.Size(706, 291);
            this.dataGridViewTarget.TabIndex = 40;
            this.dataGridViewTarget.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTarget_CellDoubleClick);
            this.dataGridViewTarget.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridViewSource_CellPainting);
            this.dataGridViewTarget.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTarget_CellClick);
            this.dataGridViewTarget.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTarget_CellEnter);
            // 
            // ITEM_NAME1
            // 
            this.ITEM_NAME1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ITEM_NAME1.DataPropertyName = "ITEM_NAME";
            this.ITEM_NAME1.HeaderText = "已选药物列表";
            this.ITEM_NAME1.Name = "ITEM_NAME1";
            this.ITEM_NAME1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DOSAGE1
            // 
            this.DOSAGE1.DataPropertyName = "DOSAGE";
            this.DOSAGE1.HeaderText = "剂量";
            this.DOSAGE1.Name = "DOSAGE1";
            this.DOSAGE1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DOSAGE1.Width = 60;
            // 
            // DOSAGE_UNITS1
            // 
            this.DOSAGE_UNITS1.DataPropertyName = "DOSAGE_UNITS";
            this.DOSAGE_UNITS1.HeaderText = "单位";
            this.DOSAGE_UNITS1.Name = "DOSAGE_UNITS1";
            this.DOSAGE_UNITS1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DOSAGE_UNITS1.Width = 40;
            // 
            // End_Date
            // 
            this.End_Date.DataPropertyName = "END_DATE_TIME";
            this.End_Date.HeaderText = "结束时间";
            this.End_Date.Name = "End_Date";
            this.End_Date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PERFORM_SPEED1
            // 
            this.PERFORM_SPEED1.DataPropertyName = "PERFORM_SPEED";
            this.PERFORM_SPEED1.HeaderText = "速度";
            this.PERFORM_SPEED1.Name = "PERFORM_SPEED1";
            this.PERFORM_SPEED1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PERFORM_SPEED1.Width = 40;
            // 
            // SPEED_UNIT1
            // 
            this.SPEED_UNIT1.DataPropertyName = "SPEED_UNITS";
            this.SPEED_UNIT1.HeaderText = "速度单位";
            this.SPEED_UNIT1.Name = "SPEED_UNIT1";
            this.SPEED_UNIT1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SPEED_UNIT1.Width = 60;
            // 
            // CONCENTRATION1
            // 
            this.CONCENTRATION1.DataPropertyName = "CONCENTRATION";
            this.CONCENTRATION1.HeaderText = "浓度";
            this.CONCENTRATION1.Name = "CONCENTRATION1";
            this.CONCENTRATION1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CONCENTRATION1.Width = 40;
            // 
            // CONCENTRATION_UNIT1
            // 
            this.CONCENTRATION_UNIT1.DataPropertyName = "CONCENTRATION_UNITS";
            this.CONCENTRATION_UNIT1.HeaderText = "浓度单位";
            this.CONCENTRATION_UNIT1.Name = "CONCENTRATION_UNIT1";
            this.CONCENTRATION_UNIT1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CONCENTRATION_UNIT1.Width = 60;
            // 
            // DURATIVE_INDICATOR1
            // 
            this.DURATIVE_INDICATOR1.DataPropertyName = "DURATIVE_INDICATOR";
            this.DURATIVE_INDICATOR1.HeaderText = "持续";
            this.DURATIVE_INDICATOR1.Name = "DURATIVE_INDICATOR1";
            this.DURATIVE_INDICATOR1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DURATIVE_INDICATOR1.Width = 40;
            // 
            // ADMINISTRATOR1
            // 
            this.ADMINISTRATOR1.DataPropertyName = "ADMINISTRATOR";
            this.ADMINISTRATOR1.HeaderText = "途径";
            this.ADMINISTRATOR1.Name = "ADMINISTRATOR1";
            this.ADMINISTRATOR1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ADMINISTRATOR1.Width = 40;
            // 
            // ITEM_CLASS1
            // 
            this.ITEM_CLASS1.DataPropertyName = "ITEM_CLASS";
            this.ITEM_CLASS1.HeaderText = "类型";
            this.ITEM_CLASS1.Name = "ITEM_CLASS1";
            this.ITEM_CLASS1.Visible = false;
            // 
            // ITEM_SPEC1
            // 
            this.ITEM_SPEC1.HeaderText = "ITEM_SPEC";
            this.ITEM_SPEC1.Name = "ITEM_SPEC1";
            this.ITEM_SPEC1.Visible = false;
            // 
            // ITEM_CODE1
            // 
            this.ITEM_CODE1.HeaderText = "ITEM_CODE";
            this.ITEM_CODE1.Name = "ITEM_CODE1";
            this.ITEM_CODE1.Visible = false;
            // 
            // SUPPLIER_NAME1
            // 
            this.SUPPLIER_NAME1.DataPropertyName = "SUPPLIER_NAME";
            this.SUPPLIER_NAME1.HeaderText = "SUPPLIER_NAME";
            this.SUPPLIER_NAME1.Name = "SUPPLIER_NAME1";
            this.SUPPLIER_NAME1.Visible = false;
            // 
            // splitterControl2
            // 
            this.splitterControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterControl2.Location = new System.Drawing.Point(0, 0);
            this.splitterControl2.Name = "splitterControl2";
            this.splitterControl2.Size = new System.Drawing.Size(706, 6);
            this.splitterControl2.TabIndex = 36;
            this.splitterControl2.TabStop = false;
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.btnAdd);
            this.panel15.Controls.Add(this.label1);
            this.panel15.Controls.Add(this.medButton14);
            this.panel15.Controls.Add(this.btnRefresh);
            this.panel15.Controls.Add(this.btnSave);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel15.Location = new System.Drawing.Point(0, 465);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(706, 37);
            this.panel15.TabIndex = 41;
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
            this.btnAdd.Location = new System.Drawing.Point(225, 6);
            this.btnAdd.MenuIndex = 0;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.PageName = null;
            this.btnAdd.Parameters = null;
            this.btnAdd.ShortcutKeys = null;
            this.btnAdd.ShowText = true;
            this.btnAdd.Size = new System.Drawing.Size(87, 25);
            this.btnAdd.TabIndex = 48;
            this.btnAdd.Text = "新  增";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(8, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 47;
            // 
            // medButton14
            // 
            this.medButton14.ActionName = null;
            this.medButton14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.medButton14.AutoImage = false;
            this.medButton14.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.medButton14.BindControl = null;
            this.medButton14.Cursor = System.Windows.Forms.Cursors.Hand;
            this.medButton14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.medButton14.HasBorder = true;
            this.medButton14.IsMenu = false;
            this.medButton14.IsMouseHover = true;
            this.medButton14.Location = new System.Drawing.Point(370, 6);
            this.medButton14.MenuIndex = 0;
            this.medButton14.Name = "medButton14";
            this.medButton14.PageName = null;
            this.medButton14.Parameters = null;
            this.medButton14.ShortcutKeys = null;
            this.medButton14.ShowText = true;
            this.medButton14.Size = new System.Drawing.Size(87, 25);
            this.medButton14.TabIndex = 39;
            this.medButton14.Text = "清  空";
            this.medButton14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.medButton14.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.ActionName = null;
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.AutoImage = false;
            this.btnRefresh.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRefresh.BindControl = null;
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.Enabled = false;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.HasBorder = true;
            this.btnRefresh.IsMenu = false;
            this.btnRefresh.IsMouseHover = true;
            this.btnRefresh.Location = new System.Drawing.Point(597, 6);
            this.btnRefresh.MenuIndex = 0;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.PageName = null;
            this.btnRefresh.Parameters = null;
            this.btnRefresh.ShortcutKeys = null;
            this.btnRefresh.ShowText = true;
            this.btnRefresh.Size = new System.Drawing.Size(87, 25);
            this.btnRefresh.TabIndex = 38;
            this.btnRefresh.Text = "刷  新";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnRefresh.UseVisualStyleBackColor = true;
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
            this.btnSave.Location = new System.Drawing.Point(504, 6);
            this.btnSave.MenuIndex = 0;
            this.btnSave.Name = "btnSave";
            this.btnSave.PageName = null;
            this.btnSave.Parameters = null;
            this.btnSave.ShortcutKeys = null;
            this.btnSave.ShowText = true;
            this.btnSave.Size = new System.Drawing.Size(87, 25);
            this.btnSave.TabIndex = 37;
            this.btnSave.Text = "保  存";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dataGridViewSource
            // 
            this.dataGridViewSource.AllowUserToAddRows = false;
            this.dataGridViewSource.AllowUserToDeleteRows = false;
            this.dataGridViewSource.AllowUserToResizeColumns = false;
            this.dataGridViewSource.AllowUserToResizeRows = false;
            this.dataGridViewSource.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewSource.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSource.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ITEM_NAME,
            this.DOSAGE,
            this.DOSAGE_UNITS,
            this.PERFORM_SPEED,
            this.SPEED_UNIT,
            this.CONCENTRATION,
            this.CONCENTRATION_UNIT,
            this.DURATIVE_INDICATOR,
            this.ADMINISTRATOR,
            this.ITEM_CLASS,
            this.ITEM_CODE,
            this.ITEM_SPEC,
            this.SUPPLIER_NAME});
            this.dataGridViewSource.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridViewSource.Location = new System.Drawing.Point(0, 36);
            this.dataGridViewSource.Name = "dataGridViewSource";
            this.dataGridViewSource.ReadOnly = true;
            this.dataGridViewSource.RowHeadersVisible = false;
            this.dataGridViewSource.RowHeadersWidth = 10;
            this.dataGridViewSource.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewSource.RowTemplate.Height = 23;
            this.dataGridViewSource.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSource.Size = new System.Drawing.Size(706, 132);
            this.dataGridViewSource.TabIndex = 43;
            this.dataGridViewSource.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSource_CellDoubleClick);
            this.dataGridViewSource.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridViewSource_CellPainting);
            // 
            // ITEM_NAME
            // 
            this.ITEM_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ITEM_NAME.DataPropertyName = "ITEM_NAME";
            this.ITEM_NAME.HeaderText = "可选药物列表";
            this.ITEM_NAME.Name = "ITEM_NAME";
            this.ITEM_NAME.ReadOnly = true;
            // 
            // DOSAGE
            // 
            this.DOSAGE.DataPropertyName = "DOSAGE";
            this.DOSAGE.HeaderText = "剂量";
            this.DOSAGE.Name = "DOSAGE";
            this.DOSAGE.ReadOnly = true;
            this.DOSAGE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DOSAGE_UNITS
            // 
            this.DOSAGE_UNITS.DataPropertyName = "DOSAGE_UNITS";
            this.DOSAGE_UNITS.HeaderText = "单位";
            this.DOSAGE_UNITS.Name = "DOSAGE_UNITS";
            this.DOSAGE_UNITS.ReadOnly = true;
            this.DOSAGE_UNITS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DOSAGE_UNITS.Width = 55;
            // 
            // PERFORM_SPEED
            // 
            this.PERFORM_SPEED.DataPropertyName = "PERFORM_SPEED";
            this.PERFORM_SPEED.HeaderText = "速度";
            this.PERFORM_SPEED.Name = "PERFORM_SPEED";
            this.PERFORM_SPEED.ReadOnly = true;
            this.PERFORM_SPEED.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PERFORM_SPEED.Width = 55;
            // 
            // SPEED_UNIT
            // 
            this.SPEED_UNIT.DataPropertyName = "SPEED_UNITS";
            this.SPEED_UNIT.HeaderText = "速度单位";
            this.SPEED_UNIT.Name = "SPEED_UNITS";
            this.SPEED_UNIT.ReadOnly = true;
            this.SPEED_UNIT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SPEED_UNIT.Width = 80;
            // 
            // CONCENTRATION
            // 
            this.CONCENTRATION.DataPropertyName = "CONCENTRATION";
            this.CONCENTRATION.HeaderText = "浓度";
            this.CONCENTRATION.Name = "CONCENTRATION";
            this.CONCENTRATION.ReadOnly = true;
            this.CONCENTRATION.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CONCENTRATION.Width = 55;
            // 
            // CONCENTRATION_UNIT
            // 
            this.CONCENTRATION_UNIT.DataPropertyName = "CONCENTRATION_UNITS";
            this.CONCENTRATION_UNIT.HeaderText = "浓度单位";
            this.CONCENTRATION_UNIT.Name = "CONCENTRATION_UNITS";
            this.CONCENTRATION_UNIT.ReadOnly = true;
            this.CONCENTRATION_UNIT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CONCENTRATION_UNIT.Width = 80;
            // 
            // DURATIVE_INDICATOR
            // 
            this.DURATIVE_INDICATOR.DataPropertyName = "DURATIVE_INDICATOR";
            this.DURATIVE_INDICATOR.HeaderText = "持续";
            this.DURATIVE_INDICATOR.Name = "DURATIVE_INDICATOR";
            this.DURATIVE_INDICATOR.ReadOnly = true;
            this.DURATIVE_INDICATOR.Visible = false;
            this.DURATIVE_INDICATOR.Width = 55;
            // 
            // ADMINISTRATOR
            // 
            this.ADMINISTRATOR.DataPropertyName = "ADMINISTRATOR";
            this.ADMINISTRATOR.HeaderText = "途径";
            this.ADMINISTRATOR.Name = "ADMINISTRATOR";
            this.ADMINISTRATOR.ReadOnly = true;
            this.ADMINISTRATOR.Visible = false;
            // 
            // ITEM_CLASS
            // 
            this.ITEM_CLASS.DataPropertyName = "ITEM_CLASS";
            this.ITEM_CLASS.HeaderText = "类型";
            this.ITEM_CLASS.Name = "ITEM_CLASS";
            this.ITEM_CLASS.ReadOnly = true;
            this.ITEM_CLASS.Visible = false;
            // 
            // ITEM_CODE
            // 
            this.ITEM_CODE.DataPropertyName = "ITEM_CODE";
            this.ITEM_CODE.HeaderText = "ITEM_CODE";
            this.ITEM_CODE.Name = "ITEM_CODE";
            this.ITEM_CODE.ReadOnly = true;
            this.ITEM_CODE.Visible = false;
            // 
            // ITEM_SPEC
            // 
            this.ITEM_SPEC.DataPropertyName = "ITEM_SPEC";
            this.ITEM_SPEC.HeaderText = "ITEM_SPEC";
            this.ITEM_SPEC.Name = "ITEM_SPEC";
            this.ITEM_SPEC.ReadOnly = true;
            this.ITEM_SPEC.Visible = false;
            // 
            // SUPPLIER_NAME
            // 
            this.SUPPLIER_NAME.DataPropertyName = "SUPPLIER_NAME";
            this.SUPPLIER_NAME.HeaderText = "SUPPLIER_NAME";
            this.SUPPLIER_NAME.Name = "SUPPLIER_NAME";
            this.SUPPLIER_NAME.ReadOnly = true;
            this.SUPPLIER_NAME.Visible = false;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.txtFilter);
            this.panel11.Controls.Add(this.labelControl1);
            this.panel11.Controls.Add(this.radioGroupTypes);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(0, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(706, 36);
            this.panel11.TabIndex = 38;
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(306, 8);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Properties.Appearance.Options.UseTextOptions = true;
            this.txtFilter.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtFilter.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtFilter.Size = new System.Drawing.Size(149, 21);
            this.txtFilter.TabIndex = 10;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(252, 9);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 9;
            this.labelControl1.Text = "字典筛选";
            // 
            // radioGroupTypes
            // 
            this.radioGroupTypes.Location = new System.Drawing.Point(3, 6);
            this.radioGroupTypes.Name = "radioGroupTypes";
            this.radioGroupTypes.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(2)), "全部"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(0)), "麻药"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(1)), "用药")});
            this.radioGroupTypes.Size = new System.Drawing.Size(222, 24);
            this.radioGroupTypes.TabIndex = 6;
            this.radioGroupTypes.SelectedIndexChanged += new System.EventHandler(this.radioGroupTypes_SelectedIndexChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // TimePointDrugEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Name = "TimePointDrugEditor";
            this.Size = new System.Drawing.Size(706, 502);
            this.Load += new System.EventHandler(this.WHYX_TimePointDrugEditor_Load);
            this.panel3.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTarget)).EndInit();
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSource)).EndInit();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupTypes.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel16;
        private DevExpress.XtraEditors.SplitterControl splitterControl2;
        private System.Windows.Forms.Panel panel15;
        private Wis.Anes.Framework.Controls.MedButton medButton14;
        private Wis.Anes.Framework.Controls.MedButton btnRefresh;
        private Wis.Anes.Framework.Controls.MedButton btnSave;
        private System.Windows.Forms.Panel panel11;
        private DevExpress.XtraEditors.RadioGroup radioGroupTypes;
        private System.Windows.Forms.DataGridView dataGridViewTarget;
        private System.Windows.Forms.DataGridView dataGridViewSource;
        private DevExpress.XtraEditors.TextEdit txtFilter;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ITEM_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn DOSAGE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DOSAGE_UNITS;
        private System.Windows.Forms.DataGridViewTextBoxColumn PERFORM_SPEED;
        private System.Windows.Forms.DataGridViewTextBoxColumn SPEED_UNIT;
        private System.Windows.Forms.DataGridViewTextBoxColumn CONCENTRATION;
        private System.Windows.Forms.DataGridViewTextBoxColumn CONCENTRATION_UNIT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DURATIVE_INDICATOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn ADMINISTRATOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn ITEM_CLASS;
        private System.Windows.Forms.DataGridViewTextBoxColumn ITEM_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn ITEM_SPEC;
        private System.Windows.Forms.DataGridViewTextBoxColumn SUPPLIER_NAME;
        private Wis.Anes.Framework.Controls.MedButton btnAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn ITEM_NAME1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DOSAGE1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DOSAGE_UNITS1;
        private System.Windows.Forms.DataGridViewTextBoxColumn End_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn PERFORM_SPEED1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SPEED_UNIT1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CONCENTRATION1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CONCENTRATION_UNIT1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DURATIVE_INDICATOR1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ADMINISTRATOR1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ITEM_CLASS1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ITEM_SPEC1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ITEM_CODE1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SUPPLIER_NAME1;
    }
}
