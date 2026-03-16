namespace Wis.Anes.Framework.Views.BillManager
{
    partial class UserControl_BillBase
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelPatientName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveModel = new Wis.Anes.Framework.Controls.MedButton();
            this.btnClear = new Wis.Anes.Framework.Controls.MedButton();
            this.btnRefreshPrice = new Wis.Anes.Framework.Controls.MedButton();
            this.btnEnd = new Wis.Anes.Framework.Controls.MedButton();
            this.btnConfirm = new Wis.Anes.Framework.Controls.MedButton();
            this.btnSave = new Wis.Anes.Framework.Controls.MedButton();
            this.btnDelete = new Wis.Anes.Framework.Controls.MedButton();
            this.btnAdd = new Wis.Anes.Framework.Controls.MedButton();
            this.btnApplyModel = new Wis.Anes.Framework.Controls.MedButton();
            this.pnlBody = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBody)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.labelPatientName);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.btnSaveModel);
            this.panelControl1.Controls.Add(this.btnClear);
            this.panelControl1.Controls.Add(this.btnRefreshPrice);
            this.panelControl1.Controls.Add(this.btnEnd);
            this.panelControl1.Controls.Add(this.btnConfirm);
            this.panelControl1.Controls.Add(this.btnSave);
            this.panelControl1.Controls.Add(this.btnDelete);
            this.panelControl1.Controls.Add(this.btnAdd);
            this.panelControl1.Controls.Add(this.btnApplyModel);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 296);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(663, 62);
            this.panelControl1.TabIndex = 0;
            // 
            // labelPatientName
            // 
            this.labelPatientName.AutoSize = true;
            this.labelPatientName.Location = new System.Drawing.Point(70, 20);
            this.labelPatientName.Name = "labelPatientName";
            this.labelPatientName.Size = new System.Drawing.Size(101, 14);
            this.labelPatientName.TabIndex = 10;
            this.labelPatientName.Text = "labelPatientName";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label1.Location = new System.Drawing.Point(23, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 14);
            this.label1.TabIndex = 9;
            this.label1.Text = "患者：";
            // 
            // btnSaveModel
            // 
            this.btnSaveModel.ActionName = null;
            this.btnSaveModel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveModel.AutoImage = false;
            this.btnSaveModel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSaveModel.BindControl = null;
            this.btnSaveModel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveModel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveModel.HasBorder = true;
            this.btnSaveModel.IsMenu = false;
            this.btnSaveModel.IsMouseHover = true;
            this.btnSaveModel.Location = new System.Drawing.Point(273, 16);
            this.btnSaveModel.MenuIndex = 0;
            this.btnSaveModel.Name = "btnSaveModel";
            this.btnSaveModel.PageName = null;
            this.btnSaveModel.Parameters = null;
            this.btnSaveModel.ShortcutKeys = null;
            this.btnSaveModel.ShowText = true;
            this.btnSaveModel.Size = new System.Drawing.Size(63, 29);
            this.btnSaveModel.TabIndex = 8;
            this.btnSaveModel.Text = "保存模板";
            this.btnSaveModel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSaveModel.UseVisualStyleBackColor = true;
            this.btnSaveModel.Click += new System.EventHandler(this.btnSaveModel_Click);
            // 
            // btnClear
            // 
            this.btnClear.ActionName = null;
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.AutoImage = false;
            this.btnClear.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClear.BindControl = null;
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.HasBorder = true;
            this.btnClear.IsMenu = false;
            this.btnClear.IsMouseHover = true;
            this.btnClear.Location = new System.Drawing.Point(418, 16);
            this.btnClear.MenuIndex = 0;
            this.btnClear.Name = "btnClear";
            this.btnClear.PageName = null;
            this.btnClear.Parameters = null;
            this.btnClear.ShortcutKeys = null;
            this.btnClear.ShowText = true;
            this.btnClear.Size = new System.Drawing.Size(53, 29);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "清空";
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnRefreshPrice
            // 
            this.btnRefreshPrice.ActionName = null;
            this.btnRefreshPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshPrice.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshPrice.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnRefreshPrice.Appearance.Options.UseFont = true;
            this.btnRefreshPrice.Appearance.Options.UseForeColor = true;
            this.btnRefreshPrice.AutoImage = false;
            this.btnRefreshPrice.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRefreshPrice.BindControl = null;
            this.btnRefreshPrice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshPrice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshPrice.HasBorder = true;
            this.btnRefreshPrice.IsMenu = false;
            this.btnRefreshPrice.IsMouseHover = true;
            this.btnRefreshPrice.Location = new System.Drawing.Point(195, 16);
            this.btnRefreshPrice.MenuIndex = 0;
            this.btnRefreshPrice.Name = "btnRefreshPrice";
            this.btnRefreshPrice.PageName = null;
            this.btnRefreshPrice.Parameters = null;
            this.btnRefreshPrice.ShortcutKeys = null;
            this.btnRefreshPrice.ShowText = true;
            this.btnRefreshPrice.Size = new System.Drawing.Size(62, 29);
            this.btnRefreshPrice.TabIndex = 6;
            this.btnRefreshPrice.Text = "更新价格";
            this.btnRefreshPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnRefreshPrice.UseVisualStyleBackColor = true;
            this.btnRefreshPrice.Click += new System.EventHandler(this.btnRefreshPrice_Click);
            // 
            // btnEnd
            // 
            this.btnEnd.ActionName = null;
            this.btnEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnd.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnd.Appearance.ForeColor = System.Drawing.Color.Red;
            this.btnEnd.Appearance.Options.UseFont = true;
            this.btnEnd.Appearance.Options.UseForeColor = true;
            this.btnEnd.AutoImage = false;
            this.btnEnd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEnd.BindControl = null;
            this.btnEnd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnd.HasBorder = true;
            this.btnEnd.IsMenu = false;
            this.btnEnd.IsMouseHover = true;
            this.btnEnd.Location = new System.Drawing.Point(60, 16);
            this.btnEnd.MenuIndex = 0;
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.PageName = null;
            this.btnEnd.Parameters = null;
            this.btnEnd.ShortcutKeys = null;
            this.btnEnd.ShowText = true;
            this.btnEnd.Size = new System.Drawing.Size(62, 29);
            this.btnEnd.TabIndex = 6;
            this.btnEnd.Text = "收费结束";
            this.btnEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnEnd.UseVisualStyleBackColor = true;
            this.btnEnd.Visible = false;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.ActionName = null;
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Appearance.ForeColor = System.Drawing.Color.Red;
            this.btnConfirm.Appearance.Options.UseFont = true;
            this.btnConfirm.Appearance.Options.UseForeColor = true;
            this.btnConfirm.AutoImage = false;
            this.btnConfirm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnConfirm.BindControl = null;
            this.btnConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.HasBorder = true;
            this.btnConfirm.IsMenu = false;
            this.btnConfirm.IsMouseHover = true;
            this.btnConfirm.Location = new System.Drawing.Point(128, 16);
            this.btnConfirm.MenuIndex = 0;
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.PageName = null;
            this.btnConfirm.Parameters = null;
            this.btnConfirm.ShortcutKeys = null;
            this.btnConfirm.ShowText = true;
            this.btnConfirm.Size = new System.Drawing.Size(62, 29);
            this.btnConfirm.TabIndex = 6;
            this.btnConfirm.Text = "确认收费";
            this.btnConfirm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnSave
            // 
            this.btnSave.ActionName = null;
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.AutoImage = false;
            this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSave.BindControl = null;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.HasBorder = true;
            this.btnSave.IsMenu = false;
            this.btnSave.IsMouseHover = true;
            this.btnSave.Location = new System.Drawing.Point(599, 16);
            this.btnSave.MenuIndex = 0;
            this.btnSave.Name = "btnSave";
            this.btnSave.PageName = null;
            this.btnSave.Parameters = null;
            this.btnSave.ShortcutKeys = null;
            this.btnSave.ShowText = true;
            this.btnSave.Size = new System.Drawing.Size(53, 29);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "保存";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.ActionName = null;
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.AutoImage = false;
            this.btnDelete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDelete.BindControl = null;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.HasBorder = true;
            this.btnDelete.IsMenu = false;
            this.btnDelete.IsMouseHover = true;
            this.btnDelete.Location = new System.Drawing.Point(532, 16);
            this.btnDelete.MenuIndex = 0;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.PageName = null;
            this.btnDelete.Parameters = null;
            this.btnDelete.ShortcutKeys = null;
            this.btnDelete.ShowText = true;
            this.btnDelete.Size = new System.Drawing.Size(53, 29);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "删除";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.ActionName = null;
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.AutoImage = false;
            this.btnAdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAdd.BindControl = null;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.HasBorder = true;
            this.btnAdd.IsMenu = false;
            this.btnAdd.IsMouseHover = true;
            this.btnAdd.Location = new System.Drawing.Point(475, 16);
            this.btnAdd.MenuIndex = 0;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.PageName = null;
            this.btnAdd.Parameters = null;
            this.btnAdd.ShortcutKeys = null;
            this.btnAdd.ShowText = true;
            this.btnAdd.Size = new System.Drawing.Size(53, 29);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "新增";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnApplyModel
            // 
            this.btnApplyModel.ActionName = null;
            this.btnApplyModel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApplyModel.AutoImage = false;
            this.btnApplyModel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnApplyModel.BindControl = null;
            this.btnApplyModel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnApplyModel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplyModel.HasBorder = true;
            this.btnApplyModel.IsMenu = false;
            this.btnApplyModel.IsMouseHover = true;
            this.btnApplyModel.Location = new System.Drawing.Point(340, 16);
            this.btnApplyModel.MenuIndex = 0;
            this.btnApplyModel.Name = "btnApplyModel";
            this.btnApplyModel.PageName = null;
            this.btnApplyModel.Parameters = null;
            this.btnApplyModel.ShortcutKeys = null;
            this.btnApplyModel.ShowText = true;
            this.btnApplyModel.Size = new System.Drawing.Size(63, 29);
            this.btnApplyModel.TabIndex = 2;
            this.btnApplyModel.Text = "套用模板";
            this.btnApplyModel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnApplyModel.UseVisualStyleBackColor = true;
            this.btnApplyModel.Click += new System.EventHandler(this.btnApplyModel_Click);
            // 
            // pnlBody
            // 
            this.pnlBody.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 0);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(663, 296);
            this.pnlBody.TabIndex = 1;
            // 
            // UserControl_BillBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.panelControl1);
            this.Name = "UserControl_BillBase";
            this.Size = new System.Drawing.Size(663, 358);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBody)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl pnlBody;
        private Wis.Anes.Framework.Controls.MedButton btnDelete;
        private Wis.Anes.Framework.Controls.MedButton btnAdd;
        private Wis.Anes.Framework.Controls.MedButton btnApplyModel;
        private Wis.Anes.Framework.Controls.MedButton btnClear;
        private Wis.Anes.Framework.Controls.MedButton btnConfirm;
        private Wis.Anes.Framework.Controls.MedButton btnSave;
        private Wis.Anes.Framework.Controls.MedButton btnSaveModel;
        private Wis.Anes.Framework.Controls.MedButton btnRefreshPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelPatientName;
        private Wis.Anes.Framework.Controls.MedButton btnEnd;
    }
}
