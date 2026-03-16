using Wis.Anes.Framework.Controls;

namespace Wis.Anes.Framework.Views
{
    partial class MessageBoxFormEx
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancel = new MedButtonEx();
            this.btnNo = new MedButtonEx();
            this.btnOK = new MedButtonEx();
            this.lblInput = new MedLabelEx();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblTimeOut = new DevExpress.XtraEditors.LabelControl();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnCancel);
            this.flowLayoutPanel1.Controls.Add(this.btnNo);
            this.flowLayoutPanel1.Controls.Add(this.btnOK);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(2, 188);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(424, 45);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnCancel.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Appearance.Options.UseForeColor = true;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(334, 4);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 33);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.Visible = false;
            // 
            // btnNo
            // 
            this.btnNo.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnNo.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnNo.Appearance.Options.UseFont = true;
            this.btnNo.Appearance.Options.UseForeColor = true;
            this.btnNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNo.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnNo.Location = new System.Drawing.Point(241, 4);
            this.btnNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(87, 33);
            this.btnNo.TabIndex = 2;
            this.btnNo.Text = "否";
            this.btnNo.Visible = false;
            // 
            // btnOK
            // 
            this.btnOK.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnOK.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnOK.Appearance.Options.UseFont = true;
            this.btnOK.Appearance.Options.UseForeColor = true;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(148, 4);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(87, 33);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确定";
            this.btnOK.Visible = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblInput
            // 
            this.lblInput.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblInput.Appearance.Options.UseFont = true;
            this.lblInput.BackGroundImage = null;
            this.lblInput.BorderColor = System.Drawing.Color.LightGray;
            this.lblInput.CustomBorder = false;
            this.lblInput.DotBorder = false;
            this.lblInput.Location = new System.Drawing.Point(28, 64);
            this.lblInput.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblInput.MultiLine = false;
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(36, 17);
            this.lblInput.SymbolType = MedSymbolType.None;
            this.lblInput.TabIndex = 1;
            this.lblInput.Text = "请输入";
            this.lblInput.VarKey = null;
            this.lblInput.Visible = false;
            this.lblInput.Paint += new System.Windows.Forms.PaintEventHandler(this.lblInput_Paint);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblTimeOut
            // 
            this.lblTimeOut.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeOut.Appearance.Options.UseFont = true;
            this.lblTimeOut.Location = new System.Drawing.Point(90, 355);
            this.lblTimeOut.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblTimeOut.Name = "lblTimeOut";
            this.lblTimeOut.Size = new System.Drawing.Size(0, 17);
            this.lblTimeOut.TabIndex = 19;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.checkBox1.Location = new System.Drawing.Point(65, 146);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(87, 21);
            this.checkBox1.TabIndex = 20;
            this.checkBox1.Text = "本频次结束";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            // 
            // MessageBoxForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(428, 235);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.lblTimeOut);
            this.Controls.Add(this.lblInput);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MessageBoxForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MessageBoxForm";
            this.TitleFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Load += new System.EventHandler(this.MessageBoxForm_Load);
            this.Activated += new System.EventHandler(this.MessageBoxForm_Activated);
            this.Controls.SetChildIndex(this.flowLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.lblInput, 0);
            this.Controls.SetChildIndex(this.lblTimeOut, 0);
            this.Controls.SetChildIndex(this.checkBox1, 0);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private MedButtonEx btnCancel;
        private MedButtonEx btnOK;
        private MedButtonEx btnNo;
        private MedLabelEx lblInput;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraEditors.LabelControl lblTimeOut;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}