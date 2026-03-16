namespace Wis.Anes.Framework
{
    partial class QiXieQingDianTemplet
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
            this.medPanel2 = new Wis.Anes.Framework.Controls.MedPanel();
            this.medSplitContainer1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new Wis.Anes.Framework.Controls.MedPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnExit = new Wis.Anes.Framework.Controls.MedButton();
            this.btnSave = new Wis.Anes.Framework.Controls.MedButton();
            this.btnApply = new Wis.Anes.Framework.Controls.MedButton();
            this.btnDel = new Wis.Anes.Framework.Controls.MedButton();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.lblMessage = new Wis.Anes.Framework.Controls.MedLabel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemRename = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.medPanel2)).BeginInit();
            this.medPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.medSplitContainer1)).BeginInit();
            this.medSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).BeginInit();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // medPanel2
            // 
            this.medPanel2.Appearance.BackColor = System.Drawing.Color.White;
            this.medPanel2.Appearance.Options.UseBackColor = true;
            this.medPanel2.Controls.Add(this.medSplitContainer1);
            this.medPanel2.Controls.Add(this.panel1);
            this.medPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.medPanel2.Location = new System.Drawing.Point(0, 0);
            this.medPanel2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.medPanel2.Name = "medPanel2";
            this.medPanel2.Size = new System.Drawing.Size(725, 529);
            this.medPanel2.TabIndex = 17;
            // 
            // medSplitContainer1
            // 
            this.medSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.medSplitContainer1.Location = new System.Drawing.Point(2, 2);
            this.medSplitContainer1.Name = "medSplitContainer1";
            this.medSplitContainer1.Panel1.Controls.Add(this.treeList1);
            this.medSplitContainer1.Panel1.Text = "Panel1";
            this.medSplitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.medSplitContainer1.Panel2.Text = "Panel2";
            this.medSplitContainer1.Size = new System.Drawing.Size(721, 473);
            this.medSplitContainer1.SplitterPosition = 196;
            this.medSplitContainer1.TabIndex = 1;
            this.medSplitContainer1.Text = "medSplitContainer1";
            // 
            // treeList1
            // 
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1});
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.Location = new System.Drawing.Point(0, 0);
            this.treeList1.Name = "treeList1";
            this.treeList1.Size = new System.Drawing.Size(196, 473);
            this.treeList1.TabIndex = 0;
            this.treeList1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeList1_MouseDown);
            this.treeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "模板名称(右键菜单操作)";
            this.treeListColumn1.FieldName = "模板名称";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.OptionsColumn.AllowEdit = false;
            this.treeListColumn1.OptionsColumn.AllowMove = false;
            this.treeListColumn1.OptionsColumn.AllowSize = false;
            this.treeListColumn1.OptionsColumn.AllowSort = false;
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(519, 473);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridView1_CellValidating);
            // 
            // panel1
            // 
            this.panel1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Appearance.Options.UseBackColor = true;
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.lblMessage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(2, 475);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(721, 52);
            this.panel1.TabIndex = 19;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Controls.Add(this.btnExit);
            this.flowLayoutPanel1.Controls.Add(this.btnSave);
            this.flowLayoutPanel1.Controls.Add(this.btnApply);
            this.flowLayoutPanel1.Controls.Add(this.btnDel);
            this.flowLayoutPanel1.Controls.Add(this.checkEdit1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(136, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(583, 48);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // btnExit
            // 
            this.btnExit.ActionName = null;
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.AutoImage = false;
            this.btnExit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnExit.BindControl = null;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.HasBorder = true;
            this.btnExit.IsMenu = false;
            this.btnExit.IsMouseHover = true;
            this.btnExit.Location = new System.Drawing.Point(479, 10);
            this.btnExit.MenuIndex = 0;
            this.btnExit.Name = "btnExit";
            this.btnExit.PageName = null;
            this.btnExit.Parameters = null;
            this.btnExit.ShortcutKeys = null;
            this.btnExit.ShowText = true;
            this.btnExit.Size = new System.Drawing.Size(101, 29);
            this.btnExit.TabIndex = 11;
            this.btnExit.Text = "取 消(&C)";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
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
            this.btnSave.Location = new System.Drawing.Point(372, 10);
            this.btnSave.MenuIndex = 0;
            this.btnSave.Name = "btnSave";
            this.btnSave.PageName = null;
            this.btnSave.Parameters = null;
            this.btnSave.ShortcutKeys = null;
            this.btnSave.ShowText = true;
            this.btnSave.Size = new System.Drawing.Size(101, 29);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "保 存(&S)";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnApply
            // 
            this.btnApply.ActionName = null;
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.AutoImage = false;
            this.btnApply.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnApply.BindControl = null;
            this.btnApply.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApply.HasBorder = true;
            this.btnApply.IsMenu = false;
            this.btnApply.IsMouseHover = true;
            this.btnApply.Location = new System.Drawing.Point(265, 10);
            this.btnApply.MenuIndex = 0;
            this.btnApply.Name = "btnApply";
            this.btnApply.PageName = null;
            this.btnApply.Parameters = null;
            this.btnApply.ShortcutKeys = null;
            this.btnApply.ShowText = true;
            this.btnApply.Size = new System.Drawing.Size(101, 29);
            this.btnApply.TabIndex = 10;
            this.btnApply.Text = "套 用(&A)";
            this.btnApply.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
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
            this.btnDel.Location = new System.Drawing.Point(158, 10);
            this.btnDel.MenuIndex = 0;
            this.btnDel.Name = "btnDel";
            this.btnDel.PageName = null;
            this.btnDel.Parameters = null;
            this.btnDel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnDel.ShortcutKeys = null;
            this.btnDel.ShowText = true;
            this.btnDel.Size = new System.Drawing.Size(101, 29);
            this.btnDel.TabIndex = 9;
            this.btnDel.Text = "删 除(&D)";
            this.btnDel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Visible = false;
            // 
            // checkEdit1
            // 
            this.checkEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkEdit1.Location = new System.Drawing.Point(56, 10);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.AutoHeight = false;
            this.checkEdit1.Properties.Caption = "模板内容叠加";
            this.checkEdit1.Size = new System.Drawing.Size(96, 30);
            this.checkEdit1.TabIndex = 14;
            this.checkEdit1.Visible = false;
            // 
            // lblMessage
            // 
            this.lblMessage.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblMessage.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Appearance.Options.UseBackColor = true;
            this.lblMessage.Appearance.Options.UseForeColor = true;
            this.lblMessage.Appearance.Options.UseTextOptions = true;
            this.lblMessage.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lblMessage.BottomLine = false;
            this.lblMessage.DotBorder = false;
            this.lblMessage.Image = null;
            this.lblMessage.Location = new System.Drawing.Point(10, 10);
            this.lblMessage.MultiLine = false;
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.NoPrint = false;
            this.lblMessage.PrintXOffSet = 0F;
            this.lblMessage.PrintYOffSet = 0F;
            this.lblMessage.Size = new System.Drawing.Size(57, 14);
            this.lblMessage.SymbolType = Wis.Anes.Framework.Controls.MedSymbolType.None;
            this.lblMessage.TabIndex = 12;
            this.lblMessage.Text = "lblMessage";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMessage.VarKey = null;
            this.lblMessage.Visible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemRename,
            this.toolStripMenuItemDelete,
            this.toolStripMenuItemAdd});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(113, 70);
            // 
            // toolStripMenuItemRename
            // 
            this.toolStripMenuItemRename.Name = "toolStripMenuItemRename";
            this.toolStripMenuItemRename.Size = new System.Drawing.Size(112, 22);
            this.toolStripMenuItemRename.Text = "重命名";
            this.toolStripMenuItemRename.Click += new System.EventHandler(this.toolStripMenuItemRename_Click);
            // 
            // toolStripMenuItemDelete
            // 
            this.toolStripMenuItemDelete.Name = "toolStripMenuItemDelete";
            this.toolStripMenuItemDelete.Size = new System.Drawing.Size(112, 22);
            this.toolStripMenuItemDelete.Text = "删除";
            this.toolStripMenuItemDelete.Click += new System.EventHandler(this.toolStripMenuItemDelete_Click);
            // 
            // toolStripMenuItemAdd
            // 
            this.toolStripMenuItemAdd.Name = "toolStripMenuItemAdd";
            this.toolStripMenuItemAdd.Size = new System.Drawing.Size(112, 22);
            this.toolStripMenuItemAdd.Text = "添加";
            this.toolStripMenuItemAdd.Click += new System.EventHandler(this.toolStripMenuItemAdd_Click);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "品名";
            this.Column1.Name = "Column1";
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "基数";
            this.Column2.Name = "Column2";
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // QiXieQingDianTemplet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.medPanel2);
            this.Name = "QiXieQingDianTemplet";
            this.Size = new System.Drawing.Size(725, 529);
            this.Load += new System.EventHandler(this.QiXieQingDianTemplet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.medPanel2)).EndInit();
            this.medPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.medSplitContainer1)).EndInit();
            this.medSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Wis.Anes.Framework.Controls.MedPanel medPanel2;
        private DevExpress.XtraEditors.SplitContainerControl medSplitContainer1;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private Wis.Anes.Framework.Controls.MedPanel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Wis.Anes.Framework.Controls.MedButton btnExit;
        private Wis.Anes.Framework.Controls.MedButton btnSave;
        private Wis.Anes.Framework.Controls.MedButton btnApply;
        private Wis.Anes.Framework.Controls.MedButton btnDel;
        private Wis.Anes.Framework.Controls.MedLabel lblMessage;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRename;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDelete;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAdd;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}
