namespace Score.Common.Controls
{
    partial class AnesScore
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
            this.InitializeComponent("", -1, -1);
        }

        private void InitializeComponent(string patientID, decimal visitID, decimal deptID)
        {
            this.tabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.tableBalthazar = new DevExpress.XtraTab.XtraTabPage();
            this.tabChild_pugh = new DevExpress.XtraTab.XtraTabPage();
            this.tabGoldman = new DevExpress.XtraTab.XtraTabPage();
            this.tabLutz = new DevExpress.XtraTab.XtraTabPage();
            this.tabPars = new DevExpress.XtraTab.XtraTabPage();
            this.tabAPACheII = new DevExpress.XtraTab.XtraTabPage();
            this.tabTISSP = new DevExpress.XtraTab.XtraTabPage();
            this.balthazar = new Balthazar(patientID, visitID, deptID);
            this.child_pugh = new Child_Pugh(patientID, visitID, deptID);
            this.goldman = new Goldman(patientID, visitID, deptID);
            this.lutz = new Lutz(patientID, visitID, deptID);
            this.pars = new Pars(patientID, visitID, deptID);
            this.APACheII = new ScoreAPACHEIIPanel(patientID, visitID, deptID);
            this.TISSP = new ScoreTISSPanel(patientID, visitID, deptID);

            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabChild_pugh.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedTabPage = this.tableBalthazar;
            this.tabControl1.Size = new System.Drawing.Size(943, 552);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tableBalthazar,
            this.tabChild_pugh,
            this.tabGoldman,
            this.tabLutz,
            this.tabPars,
            this.tabAPACheII,
            this.tabTISSP});
            // 
            // tableBalthazar
            // 
            this.tableBalthazar.AutoScroll = true;
            this.tableBalthazar.Controls.Add(this.balthazar);
            this.tableBalthazar.Name = "tableBalthazar";
            this.tableBalthazar.Size = new System.Drawing.Size(936, 522);
            //this.tableBalthazar.Size = new System.Drawing.Size(936, 400);
            this.tableBalthazar.Text = "Balthazar胰腺病变CT严重性指数评分";
            // 
            // tabChild_pugh
            // 
            this.tabChild_pugh.PageVisible = true;
            this.tabChild_pugh.AutoScroll = true;
            this.tabChild_pugh.Controls.Add(this.child_pugh);
            this.tabChild_pugh.Name = "tabChild_pugh";
            this.tabChild_pugh.Padding = new System.Windows.Forms.Padding(3);
            this.tabChild_pugh.Size = new System.Drawing.Size(936, 700);
            this.tabChild_pugh.Text = "Child-Pugh肝脏疾病患者手术危险性评分";

            // 
            // tabGoldman
            // 
            this.tabGoldman.PageVisible = true;
            this.tabGoldman.AutoScroll = true;
            this.tabGoldman.Controls.Add(this.goldman);
            this.tabGoldman.Name = "tabGoldman";
            this.tabGoldman.Padding = new System.Windows.Forms.Padding(3);
            this.tabGoldman.Size = new System.Drawing.Size(936, 522);
            this.tabGoldman.Text = "GOLDMAN心脏高危因素评分";
            // 
            // tabLutz
            // 
            this.tabLutz.PageVisible = true;
            this.tabLutz.AutoScroll = true;
            this.tabLutz.Controls.Add(this.lutz);
            this.tabLutz.Name = "tabLutz";
            this.tabLutz.Size = new System.Drawing.Size(936, 522);
            this.tabLutz.Text = "Lutz麻醉危险性评分";
            // 
            // tabPars
            // 
            this.tabPars.PageVisible = true;
            this.tabPars.AutoScroll = true;
            this.tabPars.Controls.Add(this.pars);
            this.tabPars.Name = "tabPars";
            this.tabPars.Size = new System.Drawing.Size(936, 522);
            this.tabPars.Text = "PARS麻醉恢复评分";
            // 
            // tabAPACheII
            // 
            this.tabAPACheII.PageVisible = true;
            this.tabAPACheII.AutoScroll = true;
            this.tabAPACheII.Controls.Add(this.APACheII);
            this.tabAPACheII.Name = "tabAPACheII";
            this.tabAPACheII.Size = new System.Drawing.Size(936, 522);
            this.tabAPACheII.Text = "APACHE2评分";
            // 
            // tabTISSP
            // 
            this.tabTISSP.PageVisible = true;
            this.tabTISSP.AutoScroll = true;
            this.tabTISSP.Controls.Add(this.TISSP);
            this.tabTISSP.Name = "tabTISSP";
            this.tabTISSP.Size = new System.Drawing.Size(936, 522);
            this.tabTISSP.Text = "TISS评分";
            // 
            // 
            // 

            this.balthazar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.balthazar.Location = new System.Drawing.Point(3, 3);
            this.balthazar.Size = new System.Drawing.Size(930, 516);
            this.balthazar.TabIndex = 0;

            this.child_pugh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.child_pugh.Location = new System.Drawing.Point(3, 3);
            this.child_pugh.Size = new System.Drawing.Size(930, 516);
            this.child_pugh.TabIndex = 0;

            this.goldman.Dock = System.Windows.Forms.DockStyle.Fill;
            this.goldman.Location = new System.Drawing.Point(3, 3);
            this.goldman.Size = new System.Drawing.Size(930, 516);
            this.goldman.TabIndex = 0;

            this.lutz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lutz.Location = new System.Drawing.Point(3, 3);
            this.lutz.Size = new System.Drawing.Size(930, 516);
            this.lutz.TabIndex = 0;

            this.pars.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pars.Location = new System.Drawing.Point(3, 3);
            this.pars.Size = new System.Drawing.Size(930, 516);
            this.pars.TabIndex = 0;

            this.APACheII.Dock = System.Windows.Forms.DockStyle.Fill;
            this.APACheII.Location = new System.Drawing.Point(3, 3);
            this.APACheII.Size = new System.Drawing.Size(930, 516);
            this.APACheII.TabIndex = 0;

            this.TISSP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TISSP.Location = new System.Drawing.Point(3, 3);
            this.TISSP.Size = new System.Drawing.Size(930, 516);
            this.TISSP.TabIndex = 0;

            // 
            // AnesScore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "AnesScore";
            this.Size = new System.Drawing.Size(943, 552);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabChild_pugh.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tabControl1;
        private DevExpress.XtraTab.XtraTabPage tableBalthazar;
        private DevExpress.XtraTab.XtraTabPage tabChild_pugh;
        private DevExpress.XtraTab.XtraTabPage tabGoldman;
        private DevExpress.XtraTab.XtraTabPage tabLutz;
        private DevExpress.XtraTab.XtraTabPage tabPars;
        private DevExpress.XtraTab.XtraTabPage tabAPACheII;
        private DevExpress.XtraTab.XtraTabPage tabTISSP;
        private Balthazar balthazar;
        private Child_Pugh child_pugh;
        private Goldman goldman;
        private Lutz lutz;
        private Pars pars;
        private ScoreAPACHEIIPanel APACheII;
        private ScoreTISSPanel TISSP;

    }
}
