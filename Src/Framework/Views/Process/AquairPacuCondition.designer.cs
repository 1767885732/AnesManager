namespace Wis.Anes.Framework.Views.Process
{
    partial class AquairPacuCondition
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
            this.radioGroupBreath = new DevExpress.XtraEditors.RadioGroup();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupBreath.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // radioGroupBreath
            // 
            this.radioGroupBreath.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioGroupBreath.EditValue = "";
            this.radioGroupBreath.Location = new System.Drawing.Point(0, 0);
            this.radioGroupBreath.Name = "radioGroupBreath";
            this.radioGroupBreath.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("", "正常"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("带管", "带管"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("呼吸机支持", "呼吸机支持")});
            this.radioGroupBreath.Size = new System.Drawing.Size(243, 86);
            this.radioGroupBreath.TabIndex = 14;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(160, 92);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 98;
            this.btnOK.Text = "确定";
            // 
            // AquairPacuCondition
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Caption = "实时状态";
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.radioGroupBreath);
            this.Name = "AquairPacuCondition";
            this.Size = new System.Drawing.Size(243, 123);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupBreath.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.RadioGroup radioGroupBreath;
        private DevExpress.XtraEditors.SimpleButton btnOK;


    }
}
