namespace Wis.Anes.Framework.Views.Equipment
{
    partial class EquipmentRepair
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dateEditMaintenanceTime = new DevExpress.XtraEditors.DateEdit();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.txtInstrumentCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtSituation = new DevExpress.XtraEditors.MemoEdit();
            this.txtInstrumentName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditMaintenanceTime.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditMaintenanceTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInstrumentCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSituation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInstrumentName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dateEditMaintenanceTime
            // 
            this.dateEditMaintenanceTime.EditValue = null;
            this.dateEditMaintenanceTime.Location = new System.Drawing.Point(70, 9);
            this.dateEditMaintenanceTime.Name = "dateEditMaintenanceTime";
            this.dateEditMaintenanceTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditMaintenanceTime.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm";
            this.dateEditMaintenanceTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditMaintenanceTime.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm";
            this.dateEditMaintenanceTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditMaintenanceTime.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm";
            this.dateEditMaintenanceTime.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEditMaintenanceTime.Size = new System.Drawing.Size(140, 21);
            this.dateEditMaintenanceTime.TabIndex = 29;
            // 
            // labelControl14
            // 
            this.labelControl14.Location = new System.Drawing.Point(12, 12);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(52, 14);
            this.labelControl14.TabIndex = 32;
            this.labelControl14.Text = "维修时间:";
            // 
            // btnCancel
            // 
            this.btnCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(270, 243);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 31;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnOK.Location = new System.Drawing.Point(174, 243);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 30;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(12, 116);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(52, 14);
            this.labelControl12.TabIndex = 25;
            this.labelControl12.Text = "维修情况:";
            // 
            // txtInstrumentCode
            // 
            this.txtInstrumentCode.Enabled = false;
            this.txtInstrumentCode.Location = new System.Drawing.Point(70, 44);
            this.txtInstrumentCode.Name = "txtInstrumentCode";
            this.txtInstrumentCode.Size = new System.Drawing.Size(140, 21);
            this.txtInstrumentCode.TabIndex = 28;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 47);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 14);
            this.labelControl1.TabIndex = 26;
            this.labelControl1.Text = "仪器编号:";
            // 
            // txtSituation
            // 
            this.txtSituation.Location = new System.Drawing.Point(70, 113);
            this.txtSituation.Name = "txtSituation";
            this.txtSituation.Size = new System.Drawing.Size(275, 124);
            this.txtSituation.TabIndex = 27;
            // 
            // txtInstrumentName
            // 
            this.txtInstrumentName.Enabled = false;
            this.txtInstrumentName.Location = new System.Drawing.Point(70, 77);
            this.txtInstrumentName.Name = "txtInstrumentName";
            this.txtInstrumentName.Size = new System.Drawing.Size(140, 21);
            this.txtInstrumentName.TabIndex = 34;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 80);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(52, 14);
            this.labelControl2.TabIndex = 33;
            this.labelControl2.Text = "仪器名称:";
            // 
            // EquipmentRepair
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 281);
            this.Controls.Add(this.txtInstrumentName);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.dateEditMaintenanceTime);
            this.Controls.Add(this.labelControl14);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.labelControl12);
            this.Controls.Add(this.txtInstrumentCode);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtSituation);
            this.MaximizeBox = false;
            this.Name = "EquipmentRepair";
            this.Text = "仪器每日维修记录";
            this.Load += new System.EventHandler(this.EquipmentRepair_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dateEditMaintenanceTime.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditMaintenanceTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInstrumentCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSituation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInstrumentName.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit dateEditMaintenanceTime;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.TextEdit txtInstrumentCode;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.MemoEdit txtSituation;
        private DevExpress.XtraEditors.TextEdit txtInstrumentName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}