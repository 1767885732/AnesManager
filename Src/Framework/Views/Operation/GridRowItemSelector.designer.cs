namespace Wis.Anes.Framework
{
    partial class GridRowItemSelector
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
            this.btnCancel = new Wis.Anes.Framework.Controls.MedButton();
            this.btnOK = new Wis.Anes.Framework.Controls.MedButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnMoveUp = new DevExpress.XtraEditors.SimpleButton();
            this.btnMoveDown = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnInsert = new DevExpress.XtraEditors.SimpleButton();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.btnMoveUp1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnMoveDown1 = new DevExpress.XtraEditors.SimpleButton();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.btnMoveUp2 = new DevExpress.XtraEditors.SimpleButton();
            this.btnMoveDown2 = new DevExpress.XtraEditors.SimpleButton();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbTempletName = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTempletName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.AutoImage = false;
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.HasBorder = true;
            this.btnCancel.IsMenu = false;
            this.btnCancel.IsMouseHover = true;
            this.btnCancel.Location = new System.Drawing.Point(412, 279);
            this.btnCancel.MenuIndex = 0;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.PageName = null;
            this.btnCancel.Parameters = null;
            this.btnCancel.ShortcutKeys = null;
            this.btnCancel.ShowText = true;
            this.btnCancel.Size = new System.Drawing.Size(87, 25);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取  消";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.AutoImage = false;
            this.btnOK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.HasBorder = true;
            this.btnOK.IsMenu = false;
            this.btnOK.IsMouseHover = true;
            this.btnOK.Location = new System.Drawing.Point(319, 279);
            this.btnOK.MenuIndex = 0;
            this.btnOK.Name = "btnOK";
            this.btnOK.PageName = null;
            this.btnOK.Parameters = null;
            this.btnOK.ShortcutKeys = null;
            this.btnOK.ShowText = true;
            this.btnOK.Size = new System.Drawing.Size(87, 25);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "确  认";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 10;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(122, 267);
            this.dataGridView1.TabIndex = 31;
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Enabled = false;
            this.btnMoveUp.Location = new System.Drawing.Point(128, 63);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(39, 23);
            this.btnMoveUp.TabIndex = 32;
            this.btnMoveUp.Text = "上移";
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Enabled = false;
            this.btnMoveDown.Location = new System.Drawing.Point(128, 103);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(39, 23);
            this.btnMoveDown.TabIndex = 33;
            this.btnMoveDown.Text = "下移";
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(128, 185);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(39, 23);
            this.btnDelete.TabIndex = 35;
            this.btnDelete.Text = "删除";
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Enabled = false;
            this.btnInsert.Location = new System.Drawing.Point(128, 145);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(39, 23);
            this.btnInsert.TabIndex = 34;
            this.btnInsert.Text = "插入";
            this.btnInsert.Visible = false;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeColumns = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            this.dataGridView2.Location = new System.Drawing.Point(173, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowHeadersWidth = 10;
            this.dataGridView2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView2.Size = new System.Drawing.Size(119, 267);
            this.dataGridView2.TabIndex = 31;
            this.dataGridView2.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            this.dataGridView2.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellDoubleClick);
            this.dataGridView2.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            // 
            // btnMoveUp1
            // 
            this.btnMoveUp1.Enabled = false;
            this.btnMoveUp1.Location = new System.Drawing.Point(298, 63);
            this.btnMoveUp1.Name = "btnMoveUp1";
            this.btnMoveUp1.Size = new System.Drawing.Size(39, 23);
            this.btnMoveUp1.TabIndex = 32;
            this.btnMoveUp1.Text = "上移";
            this.btnMoveUp1.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // btnMoveDown1
            // 
            this.btnMoveDown1.Enabled = false;
            this.btnMoveDown1.Location = new System.Drawing.Point(298, 103);
            this.btnMoveDown1.Name = "btnMoveDown1";
            this.btnMoveDown1.Size = new System.Drawing.Size(39, 23);
            this.btnMoveDown1.TabIndex = 33;
            this.btnMoveDown1.Text = "下移";
            this.btnMoveDown1.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.AllowUserToResizeColumns = false;
            this.dataGridView3.AllowUserToResizeRows = false;
            this.dataGridView3.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2});
            this.dataGridView3.Location = new System.Drawing.Point(343, 0);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowHeadersVisible = false;
            this.dataGridView3.RowHeadersWidth = 10;
            this.dataGridView3.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView3.RowTemplate.Height = 23;
            this.dataGridView3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView3.Size = new System.Drawing.Size(119, 267);
            this.dataGridView3.TabIndex = 31;
            this.dataGridView3.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            this.dataGridView3.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellDoubleClick);
            this.dataGridView3.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            // 
            // btnMoveUp2
            // 
            this.btnMoveUp2.Enabled = false;
            this.btnMoveUp2.Location = new System.Drawing.Point(468, 63);
            this.btnMoveUp2.Name = "btnMoveUp2";
            this.btnMoveUp2.Size = new System.Drawing.Size(39, 23);
            this.btnMoveUp2.TabIndex = 32;
            this.btnMoveUp2.Text = "上移";
            this.btnMoveUp2.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // btnMoveDown2
            // 
            this.btnMoveDown2.Enabled = false;
            this.btnMoveDown2.Location = new System.Drawing.Point(468, 103);
            this.btnMoveDown2.Name = "btnMoveDown2";
            this.btnMoveDown2.Size = new System.Drawing.Size(39, 23);
            this.btnMoveDown2.TabIndex = 33;
            this.btnMoveDown2.Text = "下移";
            this.btnMoveDown2.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.HeaderText = "晶体显示项目";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "药物显示项目";
            this.Column1.Name = "Column1";
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cmbTempletName
            // 
            this.cmbTempletName.Location = new System.Drawing.Point(61, 283);
            this.cmbTempletName.Name = "cmbTempletName";
            this.cmbTempletName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbTempletName.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbTempletName.Size = new System.Drawing.Size(171, 21);
            this.cmbTempletName.TabIndex = 37;
            this.cmbTempletName.SelectedIndexChanged += new System.EventHandler(this.cmbTempletName_SelectedIndexChanged);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(7, 285);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(48, 14);
            this.labelControl5.TabIndex = 36;
            this.labelControl5.Text = "选择模板";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "胶体显示项目";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // WHYX_GridRowItemSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbTempletName);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnMoveDown2);
            this.Controls.Add(this.btnMoveUp2);
            this.Controls.Add(this.btnMoveDown1);
            this.Controls.Add(this.btnMoveUp1);
            this.Controls.Add(this.btnMoveDown);
            this.Controls.Add(this.btnMoveUp);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Name = "WHYX_GridRowItemSelector";
            this.Size = new System.Drawing.Size(518, 358);
            this.Load += new System.EventHandler(this.WHYX_GridRowItemSelector_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTempletName.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Wis.Anes.Framework.Controls.MedButton btnCancel;
        private Wis.Anes.Framework.Controls.MedButton btnOK;
        private System.Windows.Forms.DataGridView dataGridView1;
        private DevExpress.XtraEditors.SimpleButton btnMoveUp;
        private DevExpress.XtraEditors.SimpleButton btnMoveDown;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnInsert;
        private System.Windows.Forms.DataGridView dataGridView2;
        private DevExpress.XtraEditors.SimpleButton btnMoveUp1;
        private DevExpress.XtraEditors.SimpleButton btnMoveDown1;
        private System.Windows.Forms.DataGridView dataGridView3;
        private DevExpress.XtraEditors.SimpleButton btnMoveUp2;
        private DevExpress.XtraEditors.SimpleButton btnMoveDown2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DevExpress.XtraEditors.ComboBoxEdit cmbTempletName;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}
