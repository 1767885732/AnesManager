using Wis.Anes.Framework.Controls;
namespace Wis.Anes.Framework
{
    partial class VitalSignShowEditor
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new Wis.Anes.Framework.Controls.MedButton();
            this.btnOK = new Wis.Anes.Framework.Controls.MedButton();
            this.btnAdd = new Wis.Anes.Framework.Controls.MedButton();
            this.btnMoveUp = new Wis.Anes.Framework.Controls.MedButton();
            this.btnMoveDown = new Wis.Anes.Framework.Controls.MedButton();
            this.btnDelete = new Wis.Anes.Framework.Controls.MedButton();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column11,
            this.Column13,
            this.Column10});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 10;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1041, 527);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            this.dataGridView1.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridView1_CellValidating);
            this.dataGridView1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView1_EditingControlShowing);
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "ShowType";
            this.Column2.HeaderText = "显示类型";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.Width = 80;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Visible";
            this.Column3.HeaderText = "是否显示";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column3.Width = 80;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "SymbolType";
            this.Column4.HeaderText = "标示类型";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 80;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "YAxisIndex";
            this.Column7.HeaderText = "Y轴索引";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.Width = 80;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "ShowTimeInterval";
            this.Column9.HeaderText = "时间间隔";
            this.Column9.MinimumWidth = 6;
            this.Column9.Name = "Column9";
            this.Column9.Width = 80;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.checkEdit1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnOK);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Controls.Add(this.btnMoveUp);
            this.panel2.Controls.Add(this.btnMoveDown);
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 527);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.panel2.Size = new System.Drawing.Size(1041, 73);
            this.panel2.TabIndex = 7;
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(655, 24);
            this.checkEdit1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "通用";
            this.checkEdit1.Size = new System.Drawing.Size(53, 22);
            this.checkEdit1.TabIndex = 9;
            this.checkEdit1.Visible = false;
            this.checkEdit1.CheckedChanged += new System.EventHandler(this.checkEdit1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(235, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 18);
            this.label1.TabIndex = 8;
            this.label1.Text = "label1";
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
            this.btnCancel.Location = new System.Drawing.Point(899, 17);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.MenuIndex = 0;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.PageName = null;
            this.btnCancel.Parameters = null;
            this.btnCancel.ShortcutKeys = null;
            this.btnCancel.ShowText = true;
            this.btnCancel.Size = new System.Drawing.Size(99, 35);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.ActionName = null;
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.AutoImage = false;
            this.btnOK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOK.BindControl = null;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.HasBorder = true;
            this.btnOK.IsMenu = false;
            this.btnOK.IsMouseHover = true;
            this.btnOK.Location = new System.Drawing.Point(792, 17);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOK.MenuIndex = 0;
            this.btnOK.Name = "btnOK";
            this.btnOK.PageName = null;
            this.btnOK.Parameters = null;
            this.btnOK.ShortcutKeys = null;
            this.btnOK.ShowText = true;
            this.btnOK.Size = new System.Drawing.Size(99, 35);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "确定(&O)";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
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
            this.btnAdd.Location = new System.Drawing.Point(354, 17);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAdd.MenuIndex = 0;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.PageName = null;
            this.btnAdd.Parameters = null;
            this.btnAdd.ShortcutKeys = null;
            this.btnAdd.ShowText = true;
            this.btnAdd.Size = new System.Drawing.Size(99, 35);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "添加(&A)";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Visible = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.ActionName = null;
            this.btnMoveUp.AutoImage = false;
            this.btnMoveUp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMoveUp.BindControl = null;
            this.btnMoveUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMoveUp.Enabled = false;
            this.btnMoveUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoveUp.HasBorder = true;
            this.btnMoveUp.IsMenu = false;
            this.btnMoveUp.IsMouseHover = true;
            this.btnMoveUp.Location = new System.Drawing.Point(17, 17);
            this.btnMoveUp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMoveUp.MenuIndex = 0;
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.PageName = null;
            this.btnMoveUp.Parameters = null;
            this.btnMoveUp.ShortcutKeys = null;
            this.btnMoveUp.ShowText = true;
            this.btnMoveUp.Size = new System.Drawing.Size(99, 35);
            this.btnMoveUp.TabIndex = 2;
            this.btnMoveUp.Text = "上移(&P)";
            this.btnMoveUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Visible = false;
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.ActionName = null;
            this.btnMoveDown.AutoImage = false;
            this.btnMoveDown.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMoveDown.BindControl = null;
            this.btnMoveDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMoveDown.Enabled = false;
            this.btnMoveDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoveDown.HasBorder = true;
            this.btnMoveDown.IsMenu = false;
            this.btnMoveDown.IsMouseHover = true;
            this.btnMoveDown.Location = new System.Drawing.Point(126, 17);
            this.btnMoveDown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMoveDown.MenuIndex = 0;
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.PageName = null;
            this.btnMoveDown.Parameters = null;
            this.btnMoveDown.ShortcutKeys = null;
            this.btnMoveDown.ShowText = true;
            this.btnMoveDown.Size = new System.Drawing.Size(99, 35);
            this.btnMoveDown.TabIndex = 3;
            this.btnMoveDown.Text = "下移(&N)";
            this.btnMoveDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.ActionName = null;
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.AutoImage = false;
            this.btnDelete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDelete.BindControl = null;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Enabled = false;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.HasBorder = true;
            this.btnDelete.IsMenu = false;
            this.btnDelete.IsMouseHover = true;
            this.btnDelete.Location = new System.Drawing.Point(462, 17);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDelete.MenuIndex = 0;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.PageName = null;
            this.btnDelete.Parameters = null;
            this.btnDelete.ShortcutKeys = null;
            this.btnDelete.ShowText = true;
            this.btnDelete.Size = new System.Drawing.Size(99, 35);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "删除(&D)";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "CurveName";
            this.dataGridViewTextBoxColumn1.HeaderText = "曲线名称";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "SymbolEntry";
            this.dataGridViewTextBoxColumn2.HeaderText = "标示实体";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Color";
            this.dataGridViewTextBoxColumn3.HeaderText = "颜色";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Width = 50;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "DotNumber";
            this.dataGridViewTextBoxColumn4.HeaderText = "小数位数";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Width = 60;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "HideStartTime";
            this.dataGridViewTextBoxColumn5.HeaderText = "开始隐藏时间";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn5.Width = 125;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "HideEndTim";
            this.dataGridViewTextBoxColumn6.HeaderText = "结束隐藏时间";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn6.Width = 125;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "CurveCode";
            this.dataGridViewTextBoxColumn7.HeaderText = "曲线代码";
            this.dataGridViewTextBoxColumn7.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn7.Visible = false;
            this.dataGridViewTextBoxColumn7.Width = 50;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.DataPropertyName = "CurveName";
            this.Column1.HeaderText = "曲线名称";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "SymbolEntry";
            this.Column5.HeaderText = "标示实体";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column5.Width = 80;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Color";
            this.Column6.HeaderText = "颜色";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column6.Width = 50;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "DotNumber";
            this.Column8.HeaderText = "小数位数";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            this.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column8.Width = 60;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "HideStartTime";
            this.Column11.HeaderText = "开始隐藏时间";
            this.Column11.MinimumWidth = 6;
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column11.Width = 110;
            // 
            // Column13
            // 
            this.Column13.DataPropertyName = "HideEndTime";
            this.Column13.HeaderText = "结束隐藏时间";
            this.Column13.MinimumWidth = 6;
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            this.Column13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column13.Width = 110;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "CurveCode";
            this.Column10.HeaderText = "曲线代码";
            this.Column10.MinimumWidth = 6;
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column10.Visible = false;
            this.Column10.Width = 50;
            // 
            // VitalSignShowEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "VitalSignShowEditor";
            this.Size = new System.Drawing.Size(1041, 600);
            this.Load += new System.EventHandler(this.VitalSignShowEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel2;
        private MedButton btnCancel;
        private MedButton btnOK;
        private MedButton btnAdd;
        private MedButton btnMoveUp;
        private MedButton btnMoveDown;
        private MedButton btnDelete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column2;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column3;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
    }
}
