namespace Com.ICIS.Icu.ReportDesign
{
    partial class SmartReportHostControl
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
            this.panel1 = new DevExpress.XtraEditors.PanelControl();
            this.medButton5 = new Com.MedicalSystem.Common.Controls.MedButton();
            this.medButton4 = new Com.MedicalSystem.Common.Controls.MedButton();
            this.medButton3 = new Com.MedicalSystem.Common.Controls.MedButton();
            this.medButton2 = new Com.MedicalSystem.Common.Controls.MedButton();
            this.medButton1 = new Com.MedicalSystem.Common.Controls.MedButton();
            this.panel2 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.medButton5);
            this.panel1.Controls.Add(this.medButton4);
            this.panel1.Controls.Add(this.medButton3);
            this.panel1.Controls.Add(this.medButton2);
            this.panel1.Controls.Add(this.medButton1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 398);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(616, 59);
            this.panel1.TabIndex = 2;
            // 
            // medButton5
            // 
            this.medButton5.Appearance.ForeColor = System.Drawing.Color.Black;
            this.medButton5.Appearance.Options.UseForeColor = true;
            this.medButton5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.medButton5.Location = new System.Drawing.Point(315, 13);
            this.medButton5.Margin = new System.Windows.Forms.Padding(2, 9, 7, 9);
            this.medButton5.Name = "medButton5";
            this.medButton5.Size = new System.Drawing.Size(87, 27);
            this.medButton5.TabIndex = 162;
            this.medButton5.Text = "添加(&A)";
            this.medButton5.Visible = false;
            this.medButton5.Click += new System.EventHandler(this.medButton5_Click);
            // 
            // medButton4
            // 
            this.medButton4.Appearance.ForeColor = System.Drawing.Color.Black;
            this.medButton4.Appearance.Options.UseForeColor = true;
            this.medButton4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.medButton4.Location = new System.Drawing.Point(412, 13);
            this.medButton4.Margin = new System.Windows.Forms.Padding(2, 9, 7, 9);
            this.medButton4.Name = "medButton4";
            this.medButton4.Size = new System.Drawing.Size(87, 27);
            this.medButton4.TabIndex = 162;
            this.medButton4.Text = "查询(&R)";
            this.medButton4.Visible = false;
            this.medButton4.Click += new System.EventHandler(this.medButton4_Click);
            // 
            // medButton3
            // 
            this.medButton3.Appearance.ForeColor = System.Drawing.Color.Black;
            this.medButton3.Appearance.Options.UseForeColor = true;
            this.medButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.medButton3.Location = new System.Drawing.Point(121, 13);
            this.medButton3.Margin = new System.Windows.Forms.Padding(2, 9, 7, 9);
            this.medButton3.Name = "medButton3";
            this.medButton3.Size = new System.Drawing.Size(87, 27);
            this.medButton3.TabIndex = 162;
            this.medButton3.Text = "导出Pdf(&E)";
            this.medButton3.Click += new System.EventHandler(this.medButton3_Click);
            // 
            // medButton2
            // 
            this.medButton2.Appearance.ForeColor = System.Drawing.Color.Black;
            this.medButton2.Appearance.Options.UseForeColor = true;
            this.medButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.medButton2.Location = new System.Drawing.Point(24, 13);
            this.medButton2.Margin = new System.Windows.Forms.Padding(2, 9, 7, 9);
            this.medButton2.Name = "medButton2";
            this.medButton2.Size = new System.Drawing.Size(87, 27);
            this.medButton2.TabIndex = 161;
            this.medButton2.Text = "打印(&P)";
            this.medButton2.Click += new System.EventHandler(this.medButton2_Click);
            // 
            // medButton1
            // 
            this.medButton1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.medButton1.Appearance.Options.UseForeColor = true;
            this.medButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.medButton1.Location = new System.Drawing.Point(218, 13);
            this.medButton1.Margin = new System.Windows.Forms.Padding(2, 9, 7, 9);
            this.medButton1.Name = "medButton1";
            this.medButton1.Size = new System.Drawing.Size(87, 27);
            this.medButton1.TabIndex = 160;
            this.medButton1.Text = "保存(&S)";
            this.medButton1.Click += new System.EventHandler(this.medButton1_Click);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(616, 398);
            this.panel2.TabIndex = 3;
            // 
            // SmartReportHostControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "SmartReportHostControl";
            this.Size = new System.Drawing.Size(616, 457);
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panel2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panel1;
       
        private Com.MedicalSystem.Common.Controls.MedButton medButton1;
        private Com.MedicalSystem.Common.Controls.MedButton medButton3;
        private Com.MedicalSystem.Common.Controls.MedButton medButton2;
        private Com.MedicalSystem.Common.Controls.MedButton medButton4;
        private DevExpress.XtraEditors.PanelControl panel2;
        private Com.MedicalSystem.Common.Controls.MedButton medButton5;


    }
}
