using Wis.Anes.Framework.Controls;
using System.Windows.Forms;
using DevExpress.XtraEditors;
namespace Wis.Anes.Framework
{
    partial class FeeTemplet
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
            this.panel1 = new Wis.Anes.Framework.Controls.MedPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnExit = new Wis.Anes.Framework.Controls.MedButton();
            this.btnSave = new Wis.Anes.Framework.Controls.MedButton();
            this.btnClear = new Wis.Anes.Framework.Controls.MedButton();
            this.btnDelete = new Wis.Anes.Framework.Controls.MedButton();
            this.btnAdd = new Wis.Anes.Framework.Controls.MedButton();
            this.lblMessage = new Wis.Anes.Framework.Controls.MedLabel();
            this.medLabel1 = new Wis.Anes.Framework.Controls.MedLabel();
            this.medPanel1 = new Wis.Anes.Framework.Controls.MedPanel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemRename = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAdd = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.medPanel2)).BeginInit();
            this.medPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.medSplitContainer1)).BeginInit();
            this.medSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).BeginInit();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.medPanel1)).BeginInit();
            this.medPanel1.SuspendLayout();
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
            this.medPanel2.Location = new System.Drawing.Point(0, 40);
            this.medPanel2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.medPanel2.Name = "medPanel2";
            this.medPanel2.Size = new System.Drawing.Size(1014, 430);
            this.medPanel2.TabIndex = 16;
            // 
            // medSplitContainer1
            // 
            this.medSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.medSplitContainer1.Location = new System.Drawing.Point(2, 2);
            this.medSplitContainer1.Name = "medSplitContainer1";
            this.medSplitContainer1.Panel1.Controls.Add(this.treeList1);
            this.medSplitContainer1.Panel1.Text = "Panel1";
            this.medSplitContainer1.Panel2.Text = "Panel2";
            this.medSplitContainer1.Size = new System.Drawing.Size(1010, 374);
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
            this.treeList1.Size = new System.Drawing.Size(196, 374);
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
            // panel1
            // 
            this.panel1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Appearance.Options.UseBackColor = true;
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.lblMessage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(2, 376);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1010, 52);
            this.panel1.TabIndex = 19;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Controls.Add(this.btnExit);
            this.flowLayoutPanel1.Controls.Add(this.btnSave);
            this.flowLayoutPanel1.Controls.Add(this.btnClear);
            this.flowLayoutPanel1.Controls.Add(this.btnDelete);
            this.flowLayoutPanel1.Controls.Add(this.btnAdd);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(392, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(616, 48);
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
            this.btnExit.Location = new System.Drawing.Point(512, 10);
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
            this.btnSave.Location = new System.Drawing.Point(405, 10);
            this.btnSave.MenuIndex = 0;
            this.btnSave.Name = "btnSave";
            this.btnSave.PageName = null;
            this.btnSave.Parameters = null;
            this.btnSave.ShortcutKeys = null;
            this.btnSave.ShowText = true;
            this.btnSave.Size = new System.Drawing.Size(101, 29);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "保存模板(&S)";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.btnClear.Location = new System.Drawing.Point(298, 10);
            this.btnClear.MenuIndex = 0;
            this.btnClear.Name = "btnClear";
            this.btnClear.PageName = null;
            this.btnClear.Parameters = null;
            this.btnClear.ShortcutKeys = null;
            this.btnClear.ShowText = true;
            this.btnClear.Size = new System.Drawing.Size(101, 29);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "清空项目(&C)";
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.ActionName = null;
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.AutoImage = false;
            this.btnDelete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDelete.BindControl = null;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.HasBorder = true;
            this.btnDelete.IsMenu = false;
            this.btnDelete.IsMouseHover = true;
            this.btnDelete.Location = new System.Drawing.Point(191, 10);
            this.btnDelete.MenuIndex = 0;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.PageName = null;
            this.btnDelete.Parameters = null;
            this.btnDelete.ShortcutKeys = null;
            this.btnDelete.ShowText = true;
            this.btnDelete.Size = new System.Drawing.Size(101, 29);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "删除项目(&D)";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
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
            this.btnAdd.Location = new System.Drawing.Point(84, 10);
            this.btnAdd.MenuIndex = 0;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.PageName = null;
            this.btnAdd.Parameters = null;
            this.btnAdd.ShortcutKeys = null;
            this.btnAdd.ShowText = true;
            this.btnAdd.Size = new System.Drawing.Size(101, 29);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Text = "新增项目(&N)";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblMessage.Appearance.ForeColor = System.Drawing.SystemColors.ActiveCaption;
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
            // medLabel1
            // 
            this.medLabel1.Appearance.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.medLabel1.Appearance.Options.UseFont = true;
            this.medLabel1.Appearance.Options.UseTextOptions = true;
            this.medLabel1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.medLabel1.BottomLine = false;
            this.medLabel1.DotBorder = false;
            this.medLabel1.Image = null;
            this.medLabel1.Location = new System.Drawing.Point(2, 7);
            this.medLabel1.MultiLine = false;
            this.medLabel1.Name = "medLabel1";
            this.medLabel1.NoPrint = false;
            this.medLabel1.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.medLabel1.PrintXOffSet = 0F;
            this.medLabel1.PrintYOffSet = 0F;
            this.medLabel1.Size = new System.Drawing.Size(92, 20);
            this.medLabel1.SymbolType = Wis.Anes.Framework.Controls.MedSymbolType.None;
            this.medLabel1.TabIndex = 0;
            this.medLabel1.Text = "费用模板";
            this.medLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.medLabel1.VarKey = null;
            // 
            // medPanel1
            // 
            this.medPanel1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.medPanel1.Appearance.Options.UseBackColor = true;
            this.medPanel1.Controls.Add(this.medLabel1);
            this.medPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.medPanel1.Location = new System.Drawing.Point(0, 0);
            this.medPanel1.Name = "medPanel1";
            this.medPanel1.Size = new System.Drawing.Size(1014, 40);
            this.medPanel1.TabIndex = 15;
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
            // FeeTemplet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.medPanel2);
            this.Controls.Add(this.medPanel1);
            this.Name = "FeeTemplet";
            this.Size = new System.Drawing.Size(1014, 470);
            this.Load += new System.EventHandler(this.DocumentTemplet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.medPanel2)).EndInit();
            this.medPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.medSplitContainer1)).EndInit();
            this.medSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.medPanel1)).EndInit();
            this.medPanel1.ResumeLayout(false);
            this.medPanel1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MedPanel medPanel2;
        private MedLabel medLabel1;
        private MedPanel medPanel1;
        private SplitContainerControl medSplitContainer1;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private MedPanel panel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private MedButton btnExit;
        private MedButton btnSave;
        private MedButton btnClear;
        private MedLabel lblMessage;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem toolStripMenuItemRename;
        private ToolStripMenuItem toolStripMenuItemDelete;
        private ToolStripMenuItem toolStripMenuItemAdd;
        private MedButton btnDelete;
        private MedButton btnAdd;
    }
}
