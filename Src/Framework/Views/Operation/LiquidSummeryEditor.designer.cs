namespace Wis.Anes.Framework
{
    partial class LiquidSummeryEditor
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
            this.btnCancel = new Wis.Anes.Framework.Controls.MedButton();
            this.btnOK = new Wis.Anes.Framework.Controls.MedButton();
            this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
            this.listBoxControl1 = new DevExpress.XtraEditors.ListBoxControl();
            this.btnReset = new Wis.Anes.Framework.Controls.MedButton();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl1)).BeginInit();
            this.SuspendLayout();
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
            this.btnCancel.Location = new System.Drawing.Point(208, 308);
            this.btnCancel.MenuIndex = 0;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.PageName = null;
            this.btnCancel.Parameters = null;
            this.btnCancel.ShortcutKeys = null;
            this.btnCancel.ShowText = true;
            this.btnCancel.Size = new System.Drawing.Size(87, 25);
            this.btnCancel.TabIndex = 7;
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
            this.btnOK.Location = new System.Drawing.Point(115, 308);
            this.btnOK.MenuIndex = 0;
            this.btnOK.Name = "btnOK";
            this.btnOK.PageName = null;
            this.btnOK.Parameters = null;
            this.btnOK.ShortcutKeys = null;
            this.btnOK.ShowText = true;
            this.btnOK.Size = new System.Drawing.Size(87, 25);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "确  认";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // memoEdit1
            // 
            this.memoEdit1.Location = new System.Drawing.Point(12, 17);
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.Size = new System.Drawing.Size(283, 96);
            this.memoEdit1.TabIndex = 8;
            // 
            // listBoxControl1
            // 
            this.listBoxControl1.Location = new System.Drawing.Point(12, 121);
            this.listBoxControl1.Name = "listBoxControl1";
            this.listBoxControl1.Size = new System.Drawing.Size(283, 170);
            this.listBoxControl1.TabIndex = 9;
            this.listBoxControl1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBoxControl1_MouseClick);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.AutoImage = false;
            this.btnReset.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.HasBorder = true;
            this.btnReset.IsMenu = false;
            this.btnReset.IsMouseHover = true;
            this.btnReset.Location = new System.Drawing.Point(22, 308);
            this.btnReset.MenuIndex = 0;
            this.btnReset.Name = "btnReset";
            this.btnReset.PageName = null;
            this.btnReset.Parameters = null;
            this.btnReset.ShortcutKeys = null;
            this.btnReset.ShowText = true;
            this.btnReset.Size = new System.Drawing.Size(87, 25);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "清  空";
            this.btnReset.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // WHYX_LiquidSummeryEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listBoxControl1);
            this.Controls.Add(this.memoEdit1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Name = "WHYX_LiquidSummeryEditor";
            this.Size = new System.Drawing.Size(314, 384);
            this.Load += new System.EventHandler(this.WHYX_LiquidSummeryEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Wis.Anes.Framework.Controls.MedButton btnCancel;
        private Wis.Anes.Framework.Controls.MedButton btnOK;
        private DevExpress.XtraEditors.MemoEdit memoEdit1;
        private DevExpress.XtraEditors.ListBoxControl listBoxControl1;
        private Wis.Anes.Framework.Controls.MedButton btnReset;
    }
}
