namespace Wis.Anes.Framework
{
    partial class TimePointVitalSign
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
            this.panel6 = new System.Windows.Forms.Panel();
            this.dataGridViewVitalSign = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel20 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new Wis.Anes.Framework.Controls.MedButton();
            this.btnRefresh = new Wis.Anes.Framework.Controls.MedButton();
            this.btnSave = new Wis.Anes.Framework.Controls.MedButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVitalSign)).BeginInit();
            this.panel20.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dataGridViewVitalSign);
            this.panel6.Controls.Add(this.panel20);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(594, 447);
            this.panel6.TabIndex = 4;
            // 
            // dataGridViewVitalSign
            // 
            this.dataGridViewVitalSign.AllowUserToAddRows = false;
            this.dataGridViewVitalSign.AllowUserToDeleteRows = false;
            this.dataGridViewVitalSign.AllowUserToResizeColumns = false;
            this.dataGridViewVitalSign.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.dataGridViewVitalSign.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewVitalSign.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewVitalSign.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewVitalSign.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.Column3});
            this.dataGridViewVitalSign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewVitalSign.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dataGridViewVitalSign.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewVitalSign.Name = "dataGridViewVitalSign";
            this.dataGridViewVitalSign.RowHeadersVisible = false;
            this.dataGridViewVitalSign.RowHeadersWidth = 10;
            this.dataGridViewVitalSign.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewVitalSign.RowTemplate.Height = 23;
            this.dataGridViewVitalSign.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewVitalSign.Size = new System.Drawing.Size(594, 410);
            this.dataGridViewVitalSign.TabIndex = 0;
            this.dataGridViewVitalSign.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewVitalSign_CellValueChanged);
            this.dataGridViewVitalSign.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridViewVitalSign_CellBeginEdit);
            this.dataGridViewVitalSign.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridViewVitalSign_CellPainting);
            this.dataGridViewVitalSign.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewVitalSign_CellEnter);
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.HeaderText = "名称";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "值";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "单位";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // panel20
            // 
            this.panel20.Controls.Add(this.label1);
            this.panel20.Controls.Add(this.btnAdd);
            this.panel20.Controls.Add(this.btnRefresh);
            this.panel20.Controls.Add(this.btnSave);
            this.panel20.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel20.Location = new System.Drawing.Point(0, 410);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(594, 37);
            this.panel20.TabIndex = 43;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(5, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 45;
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
            this.btnAdd.Location = new System.Drawing.Point(283, 6);
            this.btnAdd.MenuIndex = 0;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.PageName = null;
            this.btnAdd.Parameters = null;
            this.btnAdd.ShortcutKeys = null;
            this.btnAdd.ShowText = true;
            this.btnAdd.Size = new System.Drawing.Size(87, 25);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "新项目";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
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
            this.btnRefresh.Location = new System.Drawing.Point(485, 6);
            this.btnRefresh.MenuIndex = 0;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.PageName = null;
            this.btnRefresh.Parameters = null;
            this.btnRefresh.ShortcutKeys = null;
            this.btnRefresh.ShowText = true;
            this.btnRefresh.Size = new System.Drawing.Size(87, 25);
            this.btnRefresh.TabIndex = 3;
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
            this.btnSave.Location = new System.Drawing.Point(392, 6);
            this.btnSave.MenuIndex = 0;
            this.btnSave.Name = "btnSave";
            this.btnSave.PageName = null;
            this.btnSave.Parameters = null;
            this.btnSave.ShortcutKeys = null;
            this.btnSave.ShowText = true;
            this.btnSave.Size = new System.Drawing.Size(87, 25);
            this.btnSave.TabIndex = 2;
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
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.HeaderText = "名称";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "值";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "单位";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TimePointVitalSign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel6);
            this.Name = "TimePointVitalSign";
            this.Size = new System.Drawing.Size(594, 447);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVitalSign)).EndInit();
            this.panel20.ResumeLayout(false);
            this.panel20.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel20;
        private Wis.Anes.Framework.Controls.MedButton btnAdd;
        private Wis.Anes.Framework.Controls.MedButton btnRefresh;
        private Wis.Anes.Framework.Controls.MedButton btnSave;
        private System.Windows.Forms.DataGridView dataGridViewVitalSign;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Label label1;
    }
}
