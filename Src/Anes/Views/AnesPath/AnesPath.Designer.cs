namespace Wis.Anes.Views
{
    partial class AnesPath
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
            this.comboPath = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboAnesMethod = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPathDetail = new System.Windows.Forms.RichTextBox();
            this.btnCheckBeforeInPath = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.webBrowserDetail = new System.Windows.Forms.WebBrowser();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboPath
            // 
            this.comboPath.FormattingEnabled = true;
            this.comboPath.Items.AddRange(new object[] {
            "一号",
            "二号",
            "三号"});
            this.comboPath.Location = new System.Drawing.Point(78, 21);
            this.comboPath.Name = "comboPath";
            this.comboPath.Size = new System.Drawing.Size(222, 22);
            this.comboPath.TabIndex = 0;
            this.comboPath.SelectedIndexChanged += new System.EventHandler(this.comboPath_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "麻醉路径";
            // 
            // comboAnesMethod
            // 
            this.comboAnesMethod.FormattingEnabled = true;
            this.comboAnesMethod.Items.AddRange(new object[] {
            "一号",
            "二号",
            "三号"});
            this.comboAnesMethod.Location = new System.Drawing.Point(90, 65);
            this.comboAnesMethod.Name = "comboAnesMethod";
            this.comboAnesMethod.Size = new System.Drawing.Size(222, 22);
            this.comboAnesMethod.TabIndex = 3;
            this.comboAnesMethod.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "可选麻醉方法";
            // 
            // txtPathDetail
            // 
            this.txtPathDetail.Location = new System.Drawing.Point(78, 49);
            this.txtPathDetail.Name = "txtPathDetail";
            this.txtPathDetail.Size = new System.Drawing.Size(222, 88);
            this.txtPathDetail.TabIndex = 4;
            this.txtPathDetail.Text = "";
            // 
            // btnCheckBeforeInPath
            // 
            this.btnCheckBeforeInPath.Location = new System.Drawing.Point(22, 14);
            this.btnCheckBeforeInPath.Name = "btnCheckBeforeInPath";
            this.btnCheckBeforeInPath.Size = new System.Drawing.Size(75, 23);
            this.btnCheckBeforeInPath.TabIndex = 5;
            this.btnCheckBeforeInPath.Text = "入径前检查";
            this.btnCheckBeforeInPath.UseVisualStyleBackColor = true;
            this.btnCheckBeforeInPath.Click += new System.EventHandler(this.btnCheckBeforeInPath_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(357, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 14);
            this.label3.TabIndex = 7;
            this.label3.Text = "=====》";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboPath);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtPathDetail);
            this.groupBox1.Location = new System.Drawing.Point(22, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(311, 155);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "入径评估";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboAnesMethod);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(441, 43);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(327, 155);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "入径麻醉方法";
            // 
            // webBrowserDetail
            // 
            this.webBrowserDetail.Location = new System.Drawing.Point(22, 226);
            this.webBrowserDetail.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserDetail.Name = "webBrowserDetail";
            this.webBrowserDetail.Size = new System.Drawing.Size(746, 344);
            this.webBrowserDetail.TabIndex = 10;
            // 
            // AnesPath
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.Controls.Add(this.webBrowserDetail);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCheckBeforeInPath);
            this.Name = "AnesPath";
            this.Size = new System.Drawing.Size(790, 599);
            this.Load += new System.EventHandler(this.AnesPath_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboAnesMethod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox txtPathDetail;
        private System.Windows.Forms.Button btnCheckBeforeInPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.WebBrowser webBrowserDetail;
    }
}
