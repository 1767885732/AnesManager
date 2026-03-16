namespace Wis.Anes.Layouts
{
    partial class LeftBarControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LeftBarControl));
            this.navBarControlLeft = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroupControlContainer1 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.navBarGroupControlContainer2 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.navBarGroupControlContainer3 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.navBarGroupControlContainer4 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.navBarGroupControlContainer5 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.navBarGroup2 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroup3 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroup4 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroup5 = new DevExpress.XtraNavBar.NavBarGroup();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControlLeft)).BeginInit();
            this.navBarControlLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // navBarControlLeft
            // 
            this.navBarControlLeft.ActiveGroup = this.navBarGroup1;
            this.navBarControlLeft.Controls.Add(this.navBarGroupControlContainer1);
            this.navBarControlLeft.Controls.Add(this.navBarGroupControlContainer2);
            this.navBarControlLeft.Controls.Add(this.navBarGroupControlContainer3);
            this.navBarControlLeft.Controls.Add(this.navBarGroupControlContainer4);
            this.navBarControlLeft.Controls.Add(this.navBarGroupControlContainer5);
            this.navBarControlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarControlLeft.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup1,
            this.navBarGroup2,
            this.navBarGroup3,
            this.navBarGroup4,
            this.navBarGroup5});
            this.navBarControlLeft.Location = new System.Drawing.Point(0, 0);
            this.navBarControlLeft.Name = "navBarControlLeft";
            this.navBarControlLeft.OptionsNavPane.ExpandedWidth = 140;
            this.navBarControlLeft.Size = new System.Drawing.Size(123, 489);
            this.navBarControlLeft.TabIndex = 28;
            this.navBarControlLeft.Text = "navBarControl1";
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "大事件";
            this.navBarGroup1.ControlContainer = this.navBarGroupControlContainer1;
            this.navBarGroup1.GroupCaptionUseImage = DevExpress.XtraNavBar.NavBarImage.Small;
            this.navBarGroup1.GroupClientHeight = 22;
            this.navBarGroup1.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navBarGroup1.Name = "navBarGroup1";
            this.navBarGroup1.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarGroup1.SmallImage")));
            // 
            // navBarGroupControlContainer1
            // 
            this.navBarGroupControlContainer1.Name = "navBarGroupControlContainer1";
            this.navBarGroupControlContainer1.Size = new System.Drawing.Size(122, 20);
            this.navBarGroupControlContainer1.TabIndex = 0;
            // 
            // navBarGroupControlContainer2
            // 
            this.navBarGroupControlContainer2.Name = "navBarGroupControlContainer2";
            this.navBarGroupControlContainer2.Size = new System.Drawing.Size(122, 68);
            this.navBarGroupControlContainer2.TabIndex = 1;
            // 
            // navBarGroupControlContainer3
            // 
            this.navBarGroupControlContainer3.Name = "navBarGroupControlContainer3";
            this.navBarGroupControlContainer3.Size = new System.Drawing.Size(119, 20);
            this.navBarGroupControlContainer3.TabIndex = 2;
            // 
            // navBarGroupControlContainer4
            // 
            this.navBarGroupControlContainer4.Name = "navBarGroupControlContainer4";
            this.navBarGroupControlContainer4.Size = new System.Drawing.Size(122, 20);
            this.navBarGroupControlContainer4.TabIndex = 3;
            // 
            // navBarGroupControlContainer5
            // 
            this.navBarGroupControlContainer5.Name = "navBarGroupControlContainer5";
            this.navBarGroupControlContainer5.Size = new System.Drawing.Size(122, 20);
            this.navBarGroupControlContainer5.TabIndex = 4;
            // 
            // navBarGroup2
            // 
            this.navBarGroup2.Caption = "系统集成";
            this.navBarGroup2.ControlContainer = this.navBarGroupControlContainer2;
            this.navBarGroup2.GroupClientHeight = 70;
            this.navBarGroup2.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navBarGroup2.Name = "navBarGroup2";
            this.navBarGroup2.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarGroup2.SmallImage")));
            // 
            // navBarGroup3
            // 
            this.navBarGroup3.Caption = "患者操作";
            this.navBarGroup3.ControlContainer = this.navBarGroupControlContainer3;
            this.navBarGroup3.Expanded = true;
            this.navBarGroup3.GroupClientHeight = 22;
            this.navBarGroup3.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navBarGroup3.Name = "navBarGroup3";
            this.navBarGroup3.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarGroup3.SmallImage")));
            // 
            // navBarGroup4
            // 
            this.navBarGroup4.Caption = "常用功能";
            this.navBarGroup4.ControlContainer = this.navBarGroupControlContainer4;
            this.navBarGroup4.GroupClientHeight = 22;
            this.navBarGroup4.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navBarGroup4.Name = "navBarGroup4";
            this.navBarGroup4.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarGroup4.SmallImage")));
            // 
            // navBarGroup5
            // 
            this.navBarGroup5.Caption = "其它";
            this.navBarGroup5.ControlContainer = this.navBarGroupControlContainer5;
            this.navBarGroup5.GroupClientHeight = 22;
            this.navBarGroup5.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navBarGroup5.Name = "navBarGroup5";
            this.navBarGroup5.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarGroup5.SmallImage")));
            // 
            // LeftBarControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.navBarControlLeft);
            this.Name = "LeftBarControl";
            this.Size = new System.Drawing.Size(123, 489);
            this.Load += new System.EventHandler(this.LeftBarControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControlLeft)).EndInit();
            this.navBarControlLeft.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraNavBar.NavBarControl navBarControlLeft;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup2;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup3;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup4;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup5;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainer1;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainer2;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainer3;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainer4;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainer5;

    }
}
