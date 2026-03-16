namespace Wis.Anes.Views
{
    partial class OperationShift
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
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.medPanel1 = new Wis.Anes.Framework.Controls.MedPanel();
            this.medLabel1 = new Wis.Anes.Framework.Controls.MedLabel();
            this.medPanel2 = new Wis.Anes.Framework.Controls.MedPanel();
            this.medPanel3 = new Wis.Anes.Framework.Controls.MedPanel();
            this.btnRefresh = new Wis.Anes.Framework.Controls.MedButton();
            this.btnAdd = new Wis.Anes.Framework.Controls.MedButton();
            this.btnClose = new Wis.Anes.Framework.Controls.MedButton();
            this.btnSave = new Wis.Anes.Framework.Controls.MedButton();
            this.btnDel = new Wis.Anes.Framework.Controls.MedButton();
            dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.medPanel1)).BeginInit();
            this.medPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.medPanel2)).BeginInit();
            this.medPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.medPanel3)).BeginInit();
            this.medPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            dataGridView1.Location = new System.Drawing.Point(2, 2);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 23;
            dataGridView1.Size = new System.Drawing.Size(796, 512);
            dataGridView1.TabIndex = 7;
            dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "SHIFT_NO";
            this.Column1.HeaderText = "序号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 60;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "SHIFT_DATE_TIME";
            this.Column2.HeaderText = "交班时间";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 120;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "SHIFTED_BY";
            this.Column3.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.Column3.HeaderText = "交班人";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "SHIFT_PERSON";
            this.Column4.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.Column4.HeaderText = "接班人";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "SHIFT_DUTY";
            this.Column5.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.Column5.HeaderText = "工作类型";
            this.Column5.Items.AddRange(new object[] {
            "麻醉医生",
            "手术医生",
            "灌注医生",
            "洗手护士",
            "巡回护士",
            "灌注护士"});
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column6.DataPropertyName = "MEMO";
            this.Column6.HeaderText = "备注";
            this.Column6.Name = "Column6";
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // medPanel1
            // 
            this.medPanel1.Controls.Add(this.medLabel1);
            this.medPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.medPanel1.Location = new System.Drawing.Point(0, 0);
            this.medPanel1.Name = "medPanel1";
            this.medPanel1.Size = new System.Drawing.Size(800, 34);
            this.medPanel1.TabIndex = 17;
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
            this.medLabel1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.medLabel1.Size = new System.Drawing.Size(796, 30);
            this.medLabel1.SymbolType = Wis.Anes.Framework.Controls.MedSymbolType.None;
            this.medLabel1.TabIndex = 0;
            this.medLabel1.Text = "手术交班";
            this.medLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.medLabel1.VarKey = null;
            // 
            // medPanel2
            // 
            this.medPanel2.Controls.Add(dataGridView1);
            this.medPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.medPanel2.Location = new System.Drawing.Point(0, 34);
            this.medPanel2.Name = "medPanel2";
            this.medPanel2.Size = new System.Drawing.Size(800, 516);
            this.medPanel2.TabIndex = 18;
            // 
            // medPanel3
            // 
            this.medPanel3.Controls.Add(this.btnRefresh);
            this.medPanel3.Controls.Add(this.btnAdd);
            this.medPanel3.Controls.Add(this.btnClose);
            this.medPanel3.Controls.Add(this.btnSave);
            this.medPanel3.Controls.Add(this.btnDel);
            this.medPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.medPanel3.Location = new System.Drawing.Point(0, 550);
            this.medPanel3.Name = "medPanel3";
            this.medPanel3.Size = new System.Drawing.Size(800, 50);
            this.medPanel3.TabIndex = 19;
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
            this.btnRefresh.Location = new System.Drawing.Point(589, 13);
            this.btnRefresh.MenuIndex = 0;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.PageName = null;
            this.btnRefresh.Parameters = null;
            this.btnRefresh.ShortcutKeys = null;
            this.btnRefresh.ShowText = true;
            this.btnRefresh.Size = new System.Drawing.Size(87, 25);
            this.btnRefresh.TabIndex = 10;
            this.btnRefresh.Text = "刷新(&R)";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
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
            this.btnAdd.Location = new System.Drawing.Point(310, 13);
            this.btnAdd.MenuIndex = 0;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.PageName = null;
            this.btnAdd.Parameters = null;
            this.btnAdd.ShortcutKeys = null;
            this.btnAdd.ShowText = true;
            this.btnAdd.Size = new System.Drawing.Size(87, 25);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "新增(&N)";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClose
            // 
            this.btnClose.ActionName = null;
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.AutoImage = false;
            this.btnClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClose.BindControl = null;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.HasBorder = true;
            this.btnClose.IsMenu = false;
            this.btnClose.IsMouseHover = true;
            this.btnClose.Location = new System.Drawing.Point(682, 13);
            this.btnClose.MenuIndex = 0;
            this.btnClose.Name = "btnClose";
            this.btnClose.PageName = null;
            this.btnClose.Parameters = null;
            this.btnClose.ShortcutKeys = null;
            this.btnClose.ShowText = true;
            this.btnClose.Size = new System.Drawing.Size(87, 25);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
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
            this.btnSave.Location = new System.Drawing.Point(496, 13);
            this.btnSave.MenuIndex = 0;
            this.btnSave.Name = "btnSave";
            this.btnSave.PageName = null;
            this.btnSave.Parameters = null;
            this.btnSave.ShortcutKeys = null;
            this.btnSave.ShowText = true;
            this.btnSave.Size = new System.Drawing.Size(87, 25);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDel
            // 
            this.btnDel.ActionName = null;
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDel.AutoImage = false;
            this.btnDel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDel.BindControl = null;
            this.btnDel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDel.Enabled = false;
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDel.HasBorder = true;
            this.btnDel.IsMenu = false;
            this.btnDel.IsMouseHover = true;
            this.btnDel.Location = new System.Drawing.Point(403, 13);
            this.btnDel.MenuIndex = 0;
            this.btnDel.Name = "btnDel";
            this.btnDel.PageName = null;
            this.btnDel.Parameters = null;
            this.btnDel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnDel.ShortcutKeys = null;
            this.btnDel.ShowText = true;
            this.btnDel.Size = new System.Drawing.Size(87, 25);
            this.btnDel.TabIndex = 9;
            this.btnDel.Text = "删除(&D)";
            this.btnDel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // OperationShift
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.medPanel2);
            this.Controls.Add(this.medPanel3);
            this.Controls.Add(this.medPanel1);
            this.Name = "OperationShift";
            this.Size = new System.Drawing.Size(800, 600);
            this.Load += new System.EventHandler(this.OperationShift_Load);
            ((System.ComponentModel.ISupportInitialize)(dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.medPanel1)).EndInit();
            this.medPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.medPanel2)).EndInit();
            this.medPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.medPanel3)).EndInit();
            this.medPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private Wis.Anes.Framework.Controls.MedPanel medPanel1;
        private Wis.Anes.Framework.Controls.MedLabel medLabel1;
        private Wis.Anes.Framework.Controls.MedPanel medPanel2;
        private Wis.Anes.Framework.Controls.MedPanel medPanel3;
        private Wis.Anes.Framework.Controls.MedButton btnRefresh;
        private Wis.Anes.Framework.Controls.MedButton btnAdd;
        private Wis.Anes.Framework.Controls.MedButton btnClose;
        private Wis.Anes.Framework.Controls.MedButton btnSave;
        private Wis.Anes.Framework.Controls.MedButton btnDel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column3;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column4;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}
