namespace Wis.Anes.Custom.CustomProject.Views
{
    partial class PatientBarCodePrinter
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
            this.txtPrintCountPerPage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPrintCountEveryPatient = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPrintFont = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBarCodeFont = new System.Windows.Forms.TextBox();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtPrintCountPerPage
            // 
            this.txtPrintCountPerPage.Location = new System.Drawing.Point(148, 20);
            this.txtPrintCountPerPage.Name = "txtPrintCountPerPage";
            this.txtPrintCountPerPage.Size = new System.Drawing.Size(156, 22);
            this.txtPrintCountPerPage.TabIndex = 0;
            this.txtPrintCountPerPage.Text = "8";
            this.txtPrintCountPerPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "每页打印患者数：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "每患者打印份数：";
            // 
            // txtPrintCountEveryPatient
            // 
            this.txtPrintCountEveryPatient.Location = new System.Drawing.Point(148, 48);
            this.txtPrintCountEveryPatient.Name = "txtPrintCountEveryPatient";
            this.txtPrintCountEveryPatient.Size = new System.Drawing.Size(156, 22);
            this.txtPrintCountEveryPatient.TabIndex = 2;
            this.txtPrintCountEveryPatient.Text = "2";
            this.txtPrintCountEveryPatient.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "文本打印字体：";
            // 
            // txtPrintFont
            // 
            this.txtPrintFont.BackColor = System.Drawing.Color.White;
            this.txtPrintFont.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPrintFont.Location = new System.Drawing.Point(148, 76);
            this.txtPrintFont.Name = "txtPrintFont";
            this.txtPrintFont.ReadOnly = true;
            this.txtPrintFont.Size = new System.Drawing.Size(156, 26);
            this.txtPrintFont.TabIndex = 4;
            this.txtPrintFont.Text = "文本打印字体";
            this.txtPrintFont.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPrintFont.DoubleClick += new System.EventHandler(this.txtPrintFont_DoubleClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(75, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 14);
            this.label4.TabIndex = 7;
            this.label4.Text = "条码字体：";
            // 
            // txtBarCodeFont
            // 
            this.txtBarCodeFont.BackColor = System.Drawing.Color.White;
            this.txtBarCodeFont.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBarCodeFont.Location = new System.Drawing.Point(148, 104);
            this.txtBarCodeFont.Name = "txtBarCodeFont";
            this.txtBarCodeFont.ReadOnly = true;
            this.txtBarCodeFont.Size = new System.Drawing.Size(156, 26);
            this.txtBarCodeFont.TabIndex = 6;
            this.txtBarCodeFont.Text = "条码字体";
            this.txtBarCodeFont.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBarCodeFont.DoubleClick += new System.EventHandler(this.txtBarCodeFont_DoubleClick);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(148, 136);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 8;
            this.btnPrint.Text = "打印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(229, 136);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // PatientBarCodePrinter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBarCodeFont);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPrintFont);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPrintCountEveryPatient);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPrintCountPerPage);
            this.Name = "PatientBarCodePrinter";
            this.Size = new System.Drawing.Size(335, 171);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPrintCountPerPage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPrintCountEveryPatient;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPrintFont;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBarCodeFont;
        private System.Windows.Forms.FontDialog fontDialog;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClose;
    }
}
