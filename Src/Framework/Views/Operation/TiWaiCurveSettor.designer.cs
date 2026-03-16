namespace Wis.Anes.Views
{
    partial class TiWaiCurveSettor
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
            this.lblFirstTime = new DevExpress.XtraEditors.LabelControl();
            this.dateEditFirst = new DevExpress.XtraEditors.DateEdit();
            this.btnCancel = new Wis.Anes.Framework.Controls.MedButton();
            this.btnOK = new Wis.Anes.Framework.Controls.MedButton();
            this.lblSecondTime = new DevExpress.XtraEditors.LabelControl();
            this.lblThirdTime = new DevExpress.XtraEditors.LabelControl();
            this.lblForthTime = new DevExpress.XtraEditors.LabelControl();
            this.dateEditSecond = new DevExpress.XtraEditors.DateEdit();
            this.dateEditFour = new DevExpress.XtraEditors.DateEdit();
            this.dateEditThird = new DevExpress.XtraEditors.DateEdit();
            this.listView1 = new System.Windows.Forms.ListView();
            this.listView2 = new System.Windows.Forms.ListView();
            this.listView3 = new System.Windows.Forms.ListView();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFirst.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFirst.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditSecond.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditSecond.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFour.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFour.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditThird.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditThird.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFirstTime
            // 
            this.lblFirstTime.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblFirstTime.Location = new System.Drawing.Point(13, 21);
            this.lblFirstTime.Name = "lblFirstTime";
            this.lblFirstTime.Size = new System.Drawing.Size(53, 28);
            this.lblFirstTime.TabIndex = 10;
            this.lblFirstTime.Text = "体外循环开始时间";
            // 
            // dateEditFirst
            // 
            this.dateEditFirst.EditValue = null;
            this.dateEditFirst.Location = new System.Drawing.Point(72, 26);
            this.dateEditFirst.Name = "dateEditFirst";
            this.dateEditFirst.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditFirst.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm";
            this.dateEditFirst.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dateEditFirst.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dateEditFirst.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEditFirst.Size = new System.Drawing.Size(124, 21);
            this.dateEditFirst.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.AutoImage = false;
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.HasBorder = true;
            this.btnCancel.IsMenu = false;
            this.btnCancel.IsMouseHover = true;
            this.btnCancel.Location = new System.Drawing.Point(541, 424);
            this.btnCancel.MenuIndex = 0;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.PageName = null;
            this.btnCancel.Parameters = null;
            this.btnCancel.ShortcutKeys = null;
            this.btnCancel.ShowText = true;
            this.btnCancel.Size = new System.Drawing.Size(87, 25);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "取  消";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.AutoImage = false;
            this.btnOK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.HasBorder = true;
            this.btnOK.IsMenu = false;
            this.btnOK.IsMouseHover = true;
            this.btnOK.Location = new System.Drawing.Point(448, 424);
            this.btnOK.MenuIndex = 0;
            this.btnOK.Name = "btnOK";
            this.btnOK.PageName = null;
            this.btnOK.Parameters = null;
            this.btnOK.ShortcutKeys = null;
            this.btnOK.ShowText = true;
            this.btnOK.Size = new System.Drawing.Size(87, 25);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "确  认";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblSecondTime
            // 
            this.lblSecondTime.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblSecondTime.Location = new System.Drawing.Point(13, 86);
            this.lblSecondTime.Name = "lblSecondTime";
            this.lblSecondTime.Size = new System.Drawing.Size(50, 14);
            this.lblSecondTime.TabIndex = 14;
            this.lblSecondTime.Text = "阻升主A";
            // 
            // lblThirdTime
            // 
            this.lblThirdTime.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblThirdTime.Location = new System.Drawing.Point(13, 145);
            this.lblThirdTime.Name = "lblThirdTime";
            this.lblThirdTime.Size = new System.Drawing.Size(50, 14);
            this.lblThirdTime.TabIndex = 16;
            this.lblThirdTime.Text = "开升主A";
            // 
            // lblForthTime
            // 
            this.lblForthTime.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblForthTime.Location = new System.Drawing.Point(13, 198);
            this.lblForthTime.Name = "lblForthTime";
            this.lblForthTime.Size = new System.Drawing.Size(50, 28);
            this.lblForthTime.TabIndex = 18;
            this.lblForthTime.Text = "体外循环结束时间";
            // 
            // dateEditSecond
            // 
            this.dateEditSecond.EditValue = null;
            this.dateEditSecond.Location = new System.Drawing.Point(72, 83);
            this.dateEditSecond.Name = "dateEditSecond";
            this.dateEditSecond.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditSecond.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm";
            this.dateEditSecond.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dateEditSecond.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dateEditSecond.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEditSecond.Size = new System.Drawing.Size(124, 21);
            this.dateEditSecond.TabIndex = 1;
            // 
            // dateEditFour
            // 
            this.dateEditFour.EditValue = null;
            this.dateEditFour.Location = new System.Drawing.Point(72, 205);
            this.dateEditFour.Name = "dateEditFour";
            this.dateEditFour.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditFour.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm";
            this.dateEditFour.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dateEditFour.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dateEditFour.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEditFour.Size = new System.Drawing.Size(124, 21);
            this.dateEditFour.TabIndex = 3;
            // 
            // dateEditThird
            // 
            this.dateEditThird.EditValue = null;
            this.dateEditThird.Location = new System.Drawing.Point(72, 142);
            this.dateEditThird.Name = "dateEditThird";
            this.dateEditThird.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditThird.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm";
            this.dateEditThird.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dateEditThird.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dateEditThird.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEditThird.Size = new System.Drawing.Size(124, 21);
            this.dateEditThird.TabIndex = 2;
            // 
            // listView1
            // 
            this.listView1.CheckBoxes = true;
            this.listView1.Location = new System.Drawing.Point(213, 49);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(134, 355);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            // 
            // listView2
            // 
            this.listView2.CheckBoxes = true;
            this.listView2.Location = new System.Drawing.Point(354, 49);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(134, 355);
            this.listView2.TabIndex = 5;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.List;
            // 
            // listView3
            // 
            this.listView3.CheckBoxes = true;
            this.listView3.Location = new System.Drawing.Point(494, 49);
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(134, 355);
            this.listView3.TabIndex = 6;
            this.listView3.UseCompatibleStateImageBehavior = false;
            this.listView3.View = System.Windows.Forms.View.List;
            // 
            // labelControl1
            // 
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl1.Location = new System.Drawing.Point(214, 29);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(50, 14);
            this.labelControl1.TabIndex = 25;
            this.labelControl1.Text = "第一阶段";
            // 
            // labelControl2
            // 
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl2.Location = new System.Drawing.Point(354, 29);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(50, 14);
            this.labelControl2.TabIndex = 26;
            this.labelControl2.Text = "第二阶段";
            // 
            // labelControl3
            // 
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl3.Location = new System.Drawing.Point(494, 29);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(50, 14);
            this.labelControl3.TabIndex = 27;
            this.labelControl3.Text = "第三阶段";
            // 
            // WHYX_TiWaiCurveSettor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.listView3);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.dateEditThird);
            this.Controls.Add(this.dateEditFour);
            this.Controls.Add(this.dateEditSecond);
            this.Controls.Add(this.lblForthTime);
            this.Controls.Add(this.lblThirdTime);
            this.Controls.Add(this.lblSecondTime);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.dateEditFirst);
            this.Controls.Add(this.lblFirstTime);
            this.Name = "WHYX_TiWaiCurveSettor";
            this.Size = new System.Drawing.Size(642, 507);
            this.Load += new System.EventHandler(this.WHYX_TiWaiCurveSettor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFirst.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFirst.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditSecond.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditSecond.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFour.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFour.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditThird.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditThird.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblFirstTime;
        private DevExpress.XtraEditors.DateEdit dateEditFirst;
        private Wis.Anes.Framework.Controls.MedButton btnCancel;
        private Wis.Anes.Framework.Controls.MedButton btnOK;
        private DevExpress.XtraEditors.LabelControl lblSecondTime;
        private DevExpress.XtraEditors.LabelControl lblThirdTime;
        private DevExpress.XtraEditors.LabelControl lblForthTime;
        private DevExpress.XtraEditors.DateEdit dateEditSecond;
        private DevExpress.XtraEditors.DateEdit dateEditFour;
        private DevExpress.XtraEditors.DateEdit dateEditThird;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ListView listView3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}
