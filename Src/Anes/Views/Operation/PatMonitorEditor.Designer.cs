namespace Wis.Anes.Views
{
    partial class PatMonitorEditor
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlButtonsContainer = new System.Windows.Forms.Panel();
            this.btnDeleteItem = new Wis.Anes.Framework.Controls.MedButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnInsertColumns = new Wis.Anes.Framework.Controls.MedButton();
            this.btnAddItem = new Wis.Anes.Framework.Controls.MedButton();
            this.btnDelete = new Wis.Anes.Framework.Controls.MedButton();
            this.btnRefresh = new Wis.Anes.Framework.Controls.MedButton();
            this.btnSave = new Wis.Anes.Framework.Controls.MedButton();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.pnlTitle.SuspendLayout();
            this.pnlButtonsContainer.SuspendLayout();
            this.pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTitle
            // 
            this.pnlTitle.Controls.Add(this.lblTitle);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(984, 45);
            this.pnlTitle.TabIndex = 33;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.Location = new System.Drawing.Point(7, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(89, 20);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "体征数据";
            // 
            // pnlButtonsContainer
            // 
            this.pnlButtonsContainer.Controls.Add(this.btnDeleteItem);
            this.pnlButtonsContainer.Controls.Add(this.label1);
            this.pnlButtonsContainer.Controls.Add(this.btnInsertColumns);
            this.pnlButtonsContainer.Controls.Add(this.btnAddItem);
            this.pnlButtonsContainer.Controls.Add(this.btnDelete);
            this.pnlButtonsContainer.Controls.Add(this.btnRefresh);
            this.pnlButtonsContainer.Controls.Add(this.btnSave);
            this.pnlButtonsContainer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtonsContainer.Location = new System.Drawing.Point(0, 250);
            this.pnlButtonsContainer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlButtonsContainer.Name = "pnlButtonsContainer";
            this.pnlButtonsContainer.Size = new System.Drawing.Size(984, 57);
            this.pnlButtonsContainer.TabIndex = 34;
            // 
            // btnDeleteItem
            // 
            this.btnDeleteItem.ActionName = null;
            this.btnDeleteItem.AutoImage = false;
            this.btnDeleteItem.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDeleteItem.BindControl = null;
            this.btnDeleteItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteItem.HasBorder = true;
            this.btnDeleteItem.IsMenu = false;
            this.btnDeleteItem.IsMouseHover = true;
            this.btnDeleteItem.Location = new System.Drawing.Point(450, 9);
            this.btnDeleteItem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDeleteItem.MenuIndex = 0;
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.PageName = null;
            this.btnDeleteItem.Parameters = null;
            this.btnDeleteItem.ShortcutKeys = null;
            this.btnDeleteItem.ShowText = true;
            this.btnDeleteItem.Size = new System.Drawing.Size(80, 37);
            this.btnDeleteItem.TabIndex = 45;
            this.btnDeleteItem.Text = "删除项目";
            this.btnDeleteItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDeleteItem.ToolTip = "删除某体征项目";
            this.btnDeleteItem.UseVisualStyleBackColor = true;
            this.btnDeleteItem.Click += new System.EventHandler(this.btnDeleteItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(538, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 18);
            this.label1.TabIndex = 44;
            this.label1.Text = "要删除某时间点，必须选中整列!";
            // 
            // btnInsertColumns
            // 
            this.btnInsertColumns.ActionName = null;
            this.btnInsertColumns.AutoImage = false;
            this.btnInsertColumns.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnInsertColumns.BindControl = null;
            this.btnInsertColumns.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInsertColumns.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsertColumns.HasBorder = true;
            this.btnInsertColumns.IsMenu = false;
            this.btnInsertColumns.IsMouseHover = true;
            this.btnInsertColumns.Location = new System.Drawing.Point(363, 9);
            this.btnInsertColumns.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnInsertColumns.MenuIndex = 0;
            this.btnInsertColumns.Name = "btnInsertColumns";
            this.btnInsertColumns.PageName = null;
            this.btnInsertColumns.Parameters = null;
            this.btnInsertColumns.ShortcutKeys = null;
            this.btnInsertColumns.ShowText = true;
            this.btnInsertColumns.Size = new System.Drawing.Size(80, 37);
            this.btnInsertColumns.TabIndex = 43;
            this.btnInsertColumns.Text = "插入数据";
            this.btnInsertColumns.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnInsertColumns.ToolTip = "整列插入某时间点数据，可一次插入多列";
            this.btnInsertColumns.UseVisualStyleBackColor = true;
            this.btnInsertColumns.Click += new System.EventHandler(this.btnInsertColumns_Click);
            // 
            // btnAddItem
            // 
            this.btnAddItem.ActionName = null;
            this.btnAddItem.AutoImage = false;
            this.btnAddItem.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddItem.BindControl = null;
            this.btnAddItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddItem.HasBorder = true;
            this.btnAddItem.IsMenu = false;
            this.btnAddItem.IsMouseHover = true;
            this.btnAddItem.Location = new System.Drawing.Point(277, 9);
            this.btnAddItem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddItem.MenuIndex = 0;
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.PageName = null;
            this.btnAddItem.Parameters = null;
            this.btnAddItem.ShortcutKeys = null;
            this.btnAddItem.ShowText = true;
            this.btnAddItem.Size = new System.Drawing.Size(80, 37);
            this.btnAddItem.TabIndex = 42;
            this.btnAddItem.Text = "增加项目";
            this.btnAddItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAddItem.ToolTip = "增加手工录入项目";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.ActionName = null;
            this.btnDelete.AutoImage = false;
            this.btnDelete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDelete.BindControl = null;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Enabled = false;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.HasBorder = true;
            this.btnDelete.IsMenu = false;
            this.btnDelete.IsMouseHover = true;
            this.btnDelete.Location = new System.Drawing.Point(190, 9);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDelete.MenuIndex = 0;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.PageName = null;
            this.btnDelete.Parameters = null;
            this.btnDelete.ShortcutKeys = null;
            this.btnDelete.ShowText = true;
            this.btnDelete.Size = new System.Drawing.Size(80, 37);
            this.btnDelete.TabIndex = 41;
            this.btnDelete.Text = "删除(&D)";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDelete.ToolTip = "只有选中整列才能删除该列的数据，可选多列";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.ActionName = null;
            this.btnRefresh.AutoImage = false;
            this.btnRefresh.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRefresh.BindControl = null;
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.Enabled = false;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.HasBorder = true;
            this.btnRefresh.IsMenu = false;
            this.btnRefresh.IsMouseHover = true;
            this.btnRefresh.Location = new System.Drawing.Point(103, 9);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRefresh.MenuIndex = 0;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.PageName = null;
            this.btnRefresh.Parameters = null;
            this.btnRefresh.ShortcutKeys = null;
            this.btnRefresh.ShowText = true;
            this.btnRefresh.Size = new System.Drawing.Size(80, 37);
            this.btnRefresh.TabIndex = 40;
            this.btnRefresh.Text = "刷新(&R)";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSave
            // 
            this.btnSave.ActionName = null;
            this.btnSave.AutoImage = false;
            this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSave.BindControl = null;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Enabled = false;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.HasBorder = true;
            this.btnSave.IsMenu = false;
            this.btnSave.IsMouseHover = true;
            this.btnSave.Location = new System.Drawing.Point(16, 9);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.MenuIndex = 0;
            this.btnSave.Name = "btnSave";
            this.btnSave.PageName = null;
            this.btnSave.Parameters = null;
            this.btnSave.ShortcutKeys = null;
            this.btnSave.ShowText = true;
            this.btnSave.Size = new System.Drawing.Size(80, 37);
            this.btnSave.TabIndex = 39;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.dataGridView2);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 45);
            this.pnlBody.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Padding = new System.Windows.Forms.Padding(1);
            this.pnlBody.Size = new System.Drawing.Size(984, 205);
            this.pnlBody.TabIndex = 35;
            this.pnlBody.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBody_Paint);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeColumns = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(1, 1);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 10;
            this.dataGridView2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView2.Size = new System.Drawing.Size(982, 203);
            this.dataGridView2.TabIndex = 30;
            this.dataGridView2.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView2_CellBeginEdit);
            this.dataGridView2.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView2_CellPainting);
            this.dataGridView2.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridView2_CellValidating);
            this.dataGridView2.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellValueChanged);
            this.dataGridView2.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView2_EditingControlShowing);
            this.dataGridView2.SelectionChanged += new System.EventHandler(this.dataGridView2_SelectionChanged);
            // 
            // PatMonitorEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlButtonsContainer);
            this.Controls.Add(this.pnlTitle);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PatMonitorEditor";
            this.Size = new System.Drawing.Size(984, 307);
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            this.pnlButtonsContainer.ResumeLayout(false);
            this.pnlButtonsContainer.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlButtonsContainer;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.DataGridView dataGridView2;
        private Wis.Anes.Framework.Controls.MedButton btnDelete;
        private Wis.Anes.Framework.Controls.MedButton btnRefresh;
        private Wis.Anes.Framework.Controls.MedButton btnSave;
        private Wis.Anes.Framework.Controls.MedButton btnAddItem;
        private Wis.Anes.Framework.Controls.MedButton btnInsertColumns;
        private System.Windows.Forms.Label label1;
        private Wis.Anes.Framework.Controls.MedButton btnDeleteItem;
    }
}
