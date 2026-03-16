namespace Wis.Anes.Papers
{
    partial class MedicalPaper
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
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.xtraScrollableControl1 = new DevExpress.XtraEditors.XtraScrollableControl();
            this.xtraScrollableControl2 = new DevExpress.XtraEditors.XtraScrollableControl();
            this.baseDoc1 = new Wis.Anes.Framework.Documents.BaseDoc();
            this.xtraScrollableControl1.SuspendLayout();
            this.xtraScrollableControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Id = 8;
            this.barStaticItem1.Name = "barStaticItem1";
            this.barStaticItem1.TextAlignment = System.Drawing.StringAlignment.Near;
            this.barStaticItem1.Width = 1;
            // 
            // xtraScrollableControl1
            // 
            this.xtraScrollableControl1.Controls.Add(this.xtraScrollableControl2);
            this.xtraScrollableControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraScrollableControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraScrollableControl1.Name = "xtraScrollableControl1";
            this.xtraScrollableControl1.Size = new System.Drawing.Size(805, 438);
            this.xtraScrollableControl1.TabIndex = 4;
            // 
            // xtraScrollableControl2
            // 
            this.xtraScrollableControl2.Controls.Add(this.baseDoc1);
            this.xtraScrollableControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraScrollableControl2.Location = new System.Drawing.Point(0, 0);
            this.xtraScrollableControl2.Name = "xtraScrollableControl2";
            this.xtraScrollableControl2.Size = new System.Drawing.Size(805, 438);
            this.xtraScrollableControl2.TabIndex = 0;
            // 
            // baseDoc1
            // 
            this.baseDoc1.Caption = "麻醉单";
            this.baseDoc1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.baseDoc1.DocKind = Wis.Anes.Framework.DocKind.Default;
            this.baseDoc1.Location = new System.Drawing.Point(0, 0);
            this.baseDoc1.Name = "baseDoc1";
            this.baseDoc1.PageWidth = 0;
            this.baseDoc1.Size = new System.Drawing.Size(805, 438);
            this.baseDoc1.TabIndex = 0;
            // 
            // MedicalPaper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.xtraScrollableControl1);
            this.Name = "MedicalPaper";
            this.Size = new System.Drawing.Size(805, 438);
            this.Load += new System.EventHandler(this.MedicalPaper_Load);
            this.xtraScrollableControl1.ResumeLayout(false);
            this.xtraScrollableControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl1;
        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl2;
        private Wis.Anes.Framework.Documents.BaseDoc baseDoc1;

    }
}
