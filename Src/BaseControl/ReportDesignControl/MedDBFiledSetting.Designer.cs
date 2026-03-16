namespace Com.ICIS.Common.Controls
{
    partial class MedDBFiledSetting
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
            this.panelParent = new System.Windows.Forms.Panel();
            this.panelMaster = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.panelMaster.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelParent
            // 
            this.panelParent.AllowDrop = true;
            this.panelParent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelParent.BackColor = System.Drawing.Color.White;
            this.panelParent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelParent.Location = new System.Drawing.Point(0, 0);
            this.panelParent.Name = "panelParent";
            this.panelParent.Size = new System.Drawing.Size(157, 555);
            this.panelParent.TabIndex = 3;
            // 
            // panelMaster
            // 
            this.panelMaster.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMaster.Controls.Add(this.panelParent);
            this.panelMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMaster.Location = new System.Drawing.Point(0, 0);
            this.panelMaster.Name = "panelMaster";
            this.panelMaster.Size = new System.Drawing.Size(159, 557);
            this.panelMaster.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemDelete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 48);
            // 
            // ToolStripMenuItemDelete
            // 
            this.ToolStripMenuItemDelete.Name = "ToolStripMenuItemDelete";
            this.ToolStripMenuItemDelete.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItemDelete.Text = "删除";
            this.ToolStripMenuItemDelete.Click += new System.EventHandler(this.ToolStripMenuItemDelete_Click);
            // 
            // MedDBFiledSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(241)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.panelMaster);
            this.Name = "MedDBFiledSetting";
            this.Size = new System.Drawing.Size(159, 557);
            this.panelMaster.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelParent;
        private System.Windows.Forms.Panel panelMaster;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDelete;



    }
}
