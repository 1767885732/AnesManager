namespace Wis.Anes.Layouts
{
    partial class MecicalDocBarControl
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
            this.panelClock = new System.Windows.Forms.Panel();
            this.timer_Clock = new System.Windows.Forms.Timer(this.components);
            this.lb_Clock = new DevExpress.XtraEditors.LabelControl();
            this.docControlUpDown = new System.Windows.Forms.NumericUpDown();
            this.comboxDocType = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.docControlUpDown)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelClock
            // 
            this.panelClock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelClock.Location = new System.Drawing.Point(3, 4);
            this.panelClock.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelClock.Name = "panelClock";
            this.panelClock.Size = new System.Drawing.Size(27, 31);
            this.panelClock.TabIndex = 0;
            this.panelClock.Visible = false;
            // 
            // timer_Clock
            // 
            this.timer_Clock.Enabled = true;
            this.timer_Clock.Interval = 1000;
            this.timer_Clock.Tick += new System.EventHandler(this.timer_Clock_Tick);
            // 
            // lb_Clock
            // 
            this.lb_Clock.Appearance.ForeColor = System.Drawing.Color.White;
            this.lb_Clock.Location = new System.Drawing.Point(32, 10);
            this.lb_Clock.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lb_Clock.Name = "lb_Clock";
            this.lb_Clock.Size = new System.Drawing.Size(81, 18);
            this.lb_Clock.TabIndex = 1;
            this.lb_Clock.Text = "labelControl1";
            this.lb_Clock.Visible = false;
            // 
            // docControlUpDown
            // 
            this.docControlUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(234)))), ((int)(((byte)(255)))));
            this.docControlUpDown.Dock = System.Windows.Forms.DockStyle.Right;
            this.docControlUpDown.Font = new System.Drawing.Font("Tahoma", 12F);
            this.docControlUpDown.Location = new System.Drawing.Point(99, 10);
            this.docControlUpDown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.docControlUpDown.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.docControlUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.docControlUpDown.Name = "docControlUpDown";
            this.docControlUpDown.ReadOnly = true;
            this.docControlUpDown.Size = new System.Drawing.Size(40, 32);
            this.docControlUpDown.TabIndex = 3;
            this.docControlUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.docControlUpDown.ValueChanged += new System.EventHandler(this.docControlUpDown_ValueChanged);
            // 
            // comboxDocType
            // 
            this.comboxDocType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(234)))), ((int)(((byte)(255)))));
            this.comboxDocType.Dock = System.Windows.Forms.DockStyle.Right;
            this.comboxDocType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboxDocType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboxDocType.Font = new System.Drawing.Font("Tahoma", 12F);
            this.comboxDocType.FormattingEnabled = true;
            this.comboxDocType.Location = new System.Drawing.Point(8, 10);
            this.comboxDocType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboxDocType.Name = "comboxDocType";
            this.comboxDocType.Size = new System.Drawing.Size(91, 32);
            this.comboxDocType.TabIndex = 4;
            this.comboxDocType.SelectedIndexChanged += new System.EventHandler(this.comboxDocType_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboxDocType);
            this.panel1.Controls.Add(this.docControlUpDown);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(790, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 10, 10, 0);
            this.panel1.Size = new System.Drawing.Size(149, 45);
            this.panel1.TabIndex = 5;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(790, 45);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // MecicalDocBarControl
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(234)))), ((int)(((byte)(255)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lb_Clock);
            this.Controls.Add(this.panelClock);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MecicalDocBarControl";
            this.Size = new System.Drawing.Size(939, 45);
            this.Load += new System.EventHandler(this.MecicalDocBarControl_Load);
            this.Resize += new System.EventHandler(this.MecicalDocBarControl_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.docControlUpDown)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelClock;
        private System.Windows.Forms.Timer timer_Clock;
        private DevExpress.XtraEditors.LabelControl lb_Clock;
        private System.Windows.Forms.NumericUpDown docControlUpDown;
        private System.Windows.Forms.ComboBox comboxDocType;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
