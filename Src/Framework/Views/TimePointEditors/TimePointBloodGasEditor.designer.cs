namespace Wis.Anes.Framework
{
    partial class TimePointBloodGasEditor1
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel14 = new System.Windows.Forms.Panel();
            this.radioGroupBloodGasTypes = new DevExpress.XtraEditors.RadioGroup();
            this.btnClear = new Wis.Anes.Framework.Controls.MedButton();
            this.btnSelectBloodGas = new Wis.Anes.Framework.Controls.MedButton();
            this.btnRefresh = new Wis.Anes.Framework.Controls.MedButton();
            this.btnSave = new Wis.Anes.Framework.Controls.MedButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel2.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupBloodGasTypes.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel9);
            this.panel2.Controls.Add(this.panel14);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(559, 518);
            this.panel2.TabIndex = 2;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.dataGridView1);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(559, 481);
            this.panel9.TabIndex = 37;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 10;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(559, 481);
            this.dataGridView1.TabIndex = 32;
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            this.dataGridView1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEnter);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "血气代码";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "血气名称";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "值";
            this.Column3.Name = "Column3";
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.radioGroupBloodGasTypes);
            this.panel14.Controls.Add(this.btnClear);
            this.panel14.Controls.Add(this.btnSelectBloodGas);
            this.panel14.Controls.Add(this.btnRefresh);
            this.panel14.Controls.Add(this.btnSave);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel14.Location = new System.Drawing.Point(0, 481);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(559, 37);
            this.panel14.TabIndex = 41;
            // 
            // radioGroupBloodGasTypes
            // 
            this.radioGroupBloodGasTypes.Location = new System.Drawing.Point(13, 5);
            this.radioGroupBloodGasTypes.Name = "radioGroupBloodGasTypes";
            this.radioGroupBloodGasTypes.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(0)), "静脉"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(1)), "动脉")});
            this.radioGroupBloodGasTypes.Size = new System.Drawing.Size(116, 26);
            this.radioGroupBloodGasTypes.TabIndex = 0;
            this.radioGroupBloodGasTypes.SelectedIndexChanged += new System.EventHandler(this.radioGroupBloodGasTypes_SelectedIndexChanged);
            // 
            // btnClear
            // 
            this.btnClear.ActionName = null;
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.AutoImage = false;
            this.btnClear.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClear.BindControl = null;
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.HasBorder = true;
            this.btnClear.IsMenu = false;
            this.btnClear.IsMouseHover = true;
            this.btnClear.Location = new System.Drawing.Point(249, 6);
            this.btnClear.MenuIndex = 0;
            this.btnClear.Name = "btnClear";
            this.btnClear.PageName = null;
            this.btnClear.Parameters = null;
            this.btnClear.ShortcutKeys = null;
            this.btnClear.ShowText = true;
            this.btnClear.Size = new System.Drawing.Size(87, 25);
            this.btnClear.TabIndex = 39;
            this.btnClear.Text = "清  空";
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSelectBloodGas
            // 
            this.btnSelectBloodGas.ActionName = null;
            this.btnSelectBloodGas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectBloodGas.AutoImage = false;
            this.btnSelectBloodGas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSelectBloodGas.BindControl = null;
            this.btnSelectBloodGas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelectBloodGas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectBloodGas.HasBorder = true;
            this.btnSelectBloodGas.IsMenu = false;
            this.btnSelectBloodGas.IsMouseHover = true;
            this.btnSelectBloodGas.Location = new System.Drawing.Point(139, 6);
            this.btnSelectBloodGas.MenuIndex = 0;
            this.btnSelectBloodGas.Name = "btnSelectBloodGas";
            this.btnSelectBloodGas.PageName = null;
            this.btnSelectBloodGas.Parameters = null;
            this.btnSelectBloodGas.ShortcutKeys = null;
            this.btnSelectBloodGas.ShowText = true;
            this.btnSelectBloodGas.Size = new System.Drawing.Size(87, 25);
            this.btnSelectBloodGas.TabIndex = 9;
            this.btnSelectBloodGas.Text = "选择血气";
            this.btnSelectBloodGas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSelectBloodGas.UseVisualStyleBackColor = true;
            this.btnSelectBloodGas.Click += new System.EventHandler(this.btnSelectBloodGas_Click);
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
            this.btnRefresh.Location = new System.Drawing.Point(450, 6);
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
            this.btnSave.Location = new System.Drawing.Point(357, 6);
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
            // TimePointBloodGasEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Name = "TimePointBloodGasEditor";
            this.Size = new System.Drawing.Size(559, 518);
            this.Load += new System.EventHandler(this.WHYX_TimePointBloodGasEditor_Load);
            this.panel2.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel14.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupBloodGasTypes.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel14;
        private DevExpress.XtraEditors.RadioGroup radioGroupBloodGasTypes;
        private Wis.Anes.Framework.Controls.MedButton btnClear;
        private Wis.Anes.Framework.Controls.MedButton btnSelectBloodGas;
        private Wis.Anes.Framework.Controls.MedButton btnRefresh;
        private Wis.Anes.Framework.Controls.MedButton btnSave;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}
