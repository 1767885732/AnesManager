namespace Wis.Anes.Framework
{
    partial class TimePointEventEditor
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.dataGridViewTarget = new System.Windows.Forms.DataGridView();
            this.ITEM_NAME1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DOSAGE1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DOSAGE_UNITS1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
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
            this.panel7 = new System.Windows.Forms.Panel();
            this.txtFilter = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.radioGroupEventTypes = new DevExpress.XtraEditors.RadioGroup();
            this.panel13 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.medButton1 = new Wis.Anes.Framework.Controls.MedButton();
            this.btnRefresh = new Wis.Anes.Framework.Controls.MedButton();
            this.btnSave = new Wis.Anes.Framework.Controls.MedButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTarget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSource)).BeginInit();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupEventTypes.Properties)).BeginInit();
            this.panel13.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel13);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(691, 527);
            this.panel1.TabIndex = 2;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.dataGridViewTarget);
            this.panel8.Controls.Add(this.splitterControl1);
            this.panel8.Controls.Add(this.dataGridViewSource);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 29);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(691, 461);
            this.panel8.TabIndex = 36;
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
            this.dataGridViewTarget.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTarget.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ITEM_NAME1,
            this.DOSAGE1,
            this.DOSAGE_UNITS1,
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
            this.dataGridViewTarget.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewTarget.Name = "dataGridViewTarget";
            this.dataGridViewTarget.RowHeadersVisible = false;
            this.dataGridViewTarget.RowHeadersWidth = 10;
            this.dataGridViewTarget.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewTarget.RowTemplate.Height = 23;
            this.dataGridViewTarget.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewTarget.Size = new System.Drawing.Size(473, 461);
            this.dataGridViewTarget.TabIndex = 40;
            this.dataGridViewTarget.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridViewSource_CellPainting);
            // 
            // ITEM_NAME1
            // 
            this.ITEM_NAME1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ITEM_NAME1.DataPropertyName = "ITEM_NAME";
            this.ITEM_NAME1.HeaderText = "已选事件列表";
            this.ITEM_NAME1.Name = "ITEM_NAME1";
            this.ITEM_NAME1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DOSAGE1
            // 
            this.DOSAGE1.DataPropertyName = "DOSAGE";
            this.DOSAGE1.HeaderText = "剂量";
            this.DOSAGE1.Name = "DOSAGE1";
            this.DOSAGE1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DOSAGE1.Visible = false;
            // 
            // DOSAGE_UNITS1
            // 
            this.DOSAGE_UNITS1.DataPropertyName = "DOSAGE_UNITS";
            this.DOSAGE_UNITS1.HeaderText = "单位";
            this.DOSAGE_UNITS1.Name = "DOSAGE_UNITS1";
            this.DOSAGE_UNITS1.ReadOnly = true;
            this.DOSAGE_UNITS1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DOSAGE_UNITS1.Visible = false;
            this.DOSAGE_UNITS1.Width = 55;
            // 
            // PERFORM_SPEED1
            // 
            this.PERFORM_SPEED1.DataPropertyName = "PERFORM_SPEED";
            this.PERFORM_SPEED1.HeaderText = "速度";
            this.PERFORM_SPEED1.Name = "PERFORM_SPEED1";
            this.PERFORM_SPEED1.Visible = false;
            this.PERFORM_SPEED1.Width = 55;
            // 
            // SPEED_UNIT1
            // 
            this.SPEED_UNIT1.DataPropertyName = "SPEED_UNITS";
            this.SPEED_UNIT1.HeaderText = "速度单位";
            this.SPEED_UNIT1.Name = "SPEED_UNIT1";
            this.SPEED_UNIT1.Visible = false;
            this.SPEED_UNIT1.Width = 80;
            // 
            // CONCENTRATION1
            // 
            this.CONCENTRATION1.DataPropertyName = "CONCENTRATION";
            this.CONCENTRATION1.HeaderText = "浓度";
            this.CONCENTRATION1.Name = "CONCENTRATION1";
            this.CONCENTRATION1.Visible = false;
            this.CONCENTRATION1.Width = 55;
            // 
            // CONCENTRATION_UNIT1
            // 
            this.CONCENTRATION_UNIT1.DataPropertyName = "CONCENTRATION_UNITS";
            this.CONCENTRATION_UNIT1.HeaderText = "浓度单位";
            this.CONCENTRATION_UNIT1.Name = "CONCENTRATION_UNIT1";
            this.CONCENTRATION_UNIT1.Visible = false;
            this.CONCENTRATION_UNIT1.Width = 80;
            // 
            // DURATIVE_INDICATOR1
            // 
            this.DURATIVE_INDICATOR1.DataPropertyName = "DURATIVE_INDICATOR";
            this.DURATIVE_INDICATOR1.HeaderText = "持续";
            this.DURATIVE_INDICATOR1.Name = "DURATIVE_INDICATOR1";
            this.DURATIVE_INDICATOR1.Visible = false;
            this.DURATIVE_INDICATOR1.Width = 55;
            // 
            // ADMINISTRATOR1
            // 
            this.ADMINISTRATOR1.DataPropertyName = "ADMINISTRATOR";
            this.ADMINISTRATOR1.HeaderText = "途径";
            this.ADMINISTRATOR1.Name = "ADMINISTRATOR1";
            this.ADMINISTRATOR1.Visible = false;
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
            // splitterControl1
            // 
            this.splitterControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitterControl1.Location = new System.Drawing.Point(473, 0);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(6, 461);
            this.splitterControl1.TabIndex = 35;
            this.splitterControl1.TabStop = false;
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
            this.dataGridViewSource.Dock = System.Windows.Forms.DockStyle.Right;
            this.dataGridViewSource.Location = new System.Drawing.Point(479, 0);
            this.dataGridViewSource.Name = "dataGridViewSource";
            this.dataGridViewSource.ReadOnly = true;
            this.dataGridViewSource.RowHeadersVisible = false;
            this.dataGridViewSource.RowHeadersWidth = 10;
            this.dataGridViewSource.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewSource.RowTemplate.Height = 23;
            this.dataGridViewSource.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSource.Size = new System.Drawing.Size(212, 461);
            this.dataGridViewSource.TabIndex = 38;
            this.dataGridViewSource.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSource_CellDoubleClick);
            this.dataGridViewSource.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridViewSource_CellPainting);
            // 
            // ITEM_NAME
            // 
            this.ITEM_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ITEM_NAME.DataPropertyName = "ITEM_NAME";
            this.ITEM_NAME.HeaderText = "可选事件字典";
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
            this.DOSAGE.Visible = false;
            // 
            // DOSAGE_UNITS
            // 
            this.DOSAGE_UNITS.DataPropertyName = "DOSAGE_UNITS";
            this.DOSAGE_UNITS.HeaderText = "单位";
            this.DOSAGE_UNITS.Name = "DOSAGE_UNITS";
            this.DOSAGE_UNITS.ReadOnly = true;
            this.DOSAGE_UNITS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DOSAGE_UNITS.Visible = false;
            this.DOSAGE_UNITS.Width = 55;
            // 
            // PERFORM_SPEED
            // 
            this.PERFORM_SPEED.DataPropertyName = "PERFORM_SPEED";
            this.PERFORM_SPEED.HeaderText = "速度";
            this.PERFORM_SPEED.Name = "PERFORM_SPEED";
            this.PERFORM_SPEED.ReadOnly = true;
            this.PERFORM_SPEED.Visible = false;
            this.PERFORM_SPEED.Width = 55;
            // 
            // SPEED_UNIT
            // 
            this.SPEED_UNIT.DataPropertyName = "SPEED_UNITS";
            this.SPEED_UNIT.HeaderText = "速度单位";
            this.SPEED_UNIT.Name = "SPEED_UNITS";
            this.SPEED_UNIT.ReadOnly = true;
            this.SPEED_UNIT.Visible = false;
            this.SPEED_UNIT.Width = 80;
            // 
            // CONCENTRATION
            // 
            this.CONCENTRATION.DataPropertyName = "CONCENTRATION";
            this.CONCENTRATION.HeaderText = "浓度";
            this.CONCENTRATION.Name = "CONCENTRATION";
            this.CONCENTRATION.ReadOnly = true;
            this.CONCENTRATION.Visible = false;
            this.CONCENTRATION.Width = 55;
            // 
            // CONCENTRATION_UNIT
            // 
            this.CONCENTRATION_UNIT.DataPropertyName = "CONCENTRATION_UNITS";
            this.CONCENTRATION_UNIT.HeaderText = "浓度单位";
            this.CONCENTRATION_UNIT.Name = "CONCENTRATION_UNITS";
            this.CONCENTRATION_UNIT.ReadOnly = true;
            this.CONCENTRATION_UNIT.Visible = false;
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
            // panel7
            // 
            this.panel7.Controls.Add(this.txtFilter);
            this.panel7.Controls.Add(this.labelControl1);
            this.panel7.Controls.Add(this.radioGroupEventTypes);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(691, 29);
            this.panel7.TabIndex = 35;
            // 
            // txtFilter
            // 
            this.txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilter.Location = new System.Drawing.Point(533, 5);
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
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Location = new System.Drawing.Point(479, 6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 9;
            this.labelControl1.Text = "字典筛选";
            // 
            // radioGroupEventTypes
            // 
            this.radioGroupEventTypes.Location = new System.Drawing.Point(10, 2);
            this.radioGroupEventTypes.Name = "radioGroupEventTypes";
            this.radioGroupEventTypes.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(0)), "插管"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(1)), "拔管"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "体外"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "诱导"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "其它")});
            this.radioGroupEventTypes.Size = new System.Drawing.Size(253, 24);
            this.radioGroupEventTypes.TabIndex = 6;
            this.radioGroupEventTypes.Visible = false;
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.label1);
            this.panel13.Controls.Add(this.medButton1);
            this.panel13.Controls.Add(this.btnRefresh);
            this.panel13.Controls.Add(this.btnSave);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel13.Location = new System.Drawing.Point(0, 490);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(691, 37);
            this.panel13.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(8, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 47;
            // 
            // medButton1
            // 
            this.medButton1.ActionName = null;
            this.medButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.medButton1.AutoImage = false;
            this.medButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.medButton1.BindControl = null;
            this.medButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.medButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.medButton1.HasBorder = true;
            this.medButton1.IsMenu = false;
            this.medButton1.IsMouseHover = true;
            this.medButton1.Location = new System.Drawing.Point(355, 6);
            this.medButton1.MenuIndex = 0;
            this.medButton1.Name = "medButton1";
            this.medButton1.PageName = null;
            this.medButton1.Parameters = null;
            this.medButton1.ShortcutKeys = null;
            this.medButton1.ShowText = true;
            this.medButton1.Size = new System.Drawing.Size(87, 25);
            this.medButton1.TabIndex = 39;
            this.medButton1.Text = "清  空";
            this.medButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.medButton1.UseVisualStyleBackColor = true;
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
            this.btnRefresh.Location = new System.Drawing.Point(582, 6);
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
            this.btnSave.Location = new System.Drawing.Point(489, 6);
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
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // TimePointEventEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "TimePointEventEditor";
            this.Size = new System.Drawing.Size(691, 527);
            this.Load += new System.EventHandler(this.WHYX_TimePointEventEditor_Load);
            this.panel1.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTarget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSource)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupEventTypes.Properties)).EndInit();
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel8;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private System.Windows.Forms.Panel panel7;
        private DevExpress.XtraEditors.RadioGroup radioGroupEventTypes;
        private System.Windows.Forms.Panel panel13;
        private Wis.Anes.Framework.Controls.MedButton medButton1;
        private Wis.Anes.Framework.Controls.MedButton btnRefresh;
        private Wis.Anes.Framework.Controls.MedButton btnSave;
        private System.Windows.Forms.DataGridView dataGridViewSource;
        private System.Windows.Forms.DataGridView dataGridViewTarget;
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
        private DevExpress.XtraEditors.TextEdit txtFilter;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ITEM_NAME1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DOSAGE1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DOSAGE_UNITS1;
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
