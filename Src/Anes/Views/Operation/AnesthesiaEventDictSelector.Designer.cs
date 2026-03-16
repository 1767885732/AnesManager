namespace Wis.Anes.Views
{
    partial class AnesthesiaEventDictSelector
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
            this.dgSelect = new System.Windows.Forms.DataGridView();
            this.item_class = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SUPPLIER_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PERFORM_SPEED = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SPEED_UNITS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DOSAGE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DOSAGE_UNITS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CONCENTRATION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CONCENTRATION_UNITS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ADMINISTRATOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ITEM_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ITEM_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ITEM_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ITEM_SPEC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EVENT_ATTR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DURATIVE_INDICATOR1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlButtonsContainer = new System.Windows.Forms.Panel();
            this.btnFour = new Wis.Anes.Framework.Controls.MedButton();
            this.btnAnes = new Wis.Anes.Framework.Controls.MedButton();
            this.btnOther = new Wis.Anes.Framework.Controls.MedButton();
            this.btnOperation = new Wis.Anes.Framework.Controls.MedButton();
            this.lbFilter = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDrugInfo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgSelect)).BeginInit();
            this.pnlButtonsContainer.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgSelect
            // 
            this.dgSelect.AllowUserToAddRows = false;
            this.dgSelect.AllowUserToDeleteRows = false;
            this.dgSelect.AllowUserToResizeColumns = false;
            this.dgSelect.AllowUserToResizeRows = false;
            this.dgSelect.BackgroundColor = System.Drawing.Color.White;
            this.dgSelect.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSelect.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.item_class,
            this.SUPPLIER_NAME,
            this.PERFORM_SPEED,
            this.SPEED_UNITS,
            this.DOSAGE,
            this.DOSAGE_UNITS,
            this.CONCENTRATION,
            this.CONCENTRATION_UNITS,
            this.ADMINISTRATOR,
            this.ITEM_CODE,
            this.ITEM_NO,
            this.ITEM_NAME,
            this.ITEM_SPEC,
            this.EVENT_ATTR,
            this.DURATIVE_INDICATOR1});
            this.dgSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgSelect.Location = new System.Drawing.Point(6, 228);
            this.dgSelect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgSelect.MultiSelect = false;
            this.dgSelect.Name = "dgSelect";
            this.dgSelect.ReadOnly = true;
            this.dgSelect.RowHeadersVisible = false;
            this.dgSelect.RowHeadersWidth = 51;
            this.dgSelect.RowTemplate.Height = 23;
            this.dgSelect.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgSelect.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgSelect.Size = new System.Drawing.Size(237, 113);
            this.dgSelect.TabIndex = 21;
            this.dgSelect.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgSelect_CellDoubleClick);
            this.dgSelect.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgSelect_CellPainting);
            this.dgSelect.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgSelect_KeyDown);
            this.dgSelect.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgSelect_KeyPress);
            // 
            // item_class
            // 
            this.item_class.HeaderText = "item_class";
            this.item_class.MinimumWidth = 6;
            this.item_class.Name = "item_class";
            this.item_class.ReadOnly = true;
            this.item_class.Visible = false;
            this.item_class.Width = 125;
            // 
            // SUPPLIER_NAME
            // 
            this.SUPPLIER_NAME.HeaderText = "SUPPLIER_NAME";
            this.SUPPLIER_NAME.MinimumWidth = 6;
            this.SUPPLIER_NAME.Name = "SUPPLIER_NAME";
            this.SUPPLIER_NAME.ReadOnly = true;
            this.SUPPLIER_NAME.Visible = false;
            this.SUPPLIER_NAME.Width = 125;
            // 
            // PERFORM_SPEED
            // 
            this.PERFORM_SPEED.HeaderText = "PERFORM_SPEED";
            this.PERFORM_SPEED.MinimumWidth = 6;
            this.PERFORM_SPEED.Name = "PERFORM_SPEED";
            this.PERFORM_SPEED.ReadOnly = true;
            this.PERFORM_SPEED.Visible = false;
            this.PERFORM_SPEED.Width = 125;
            // 
            // SPEED_UNITS
            // 
            this.SPEED_UNITS.HeaderText = "SPEED_UNITS";
            this.SPEED_UNITS.MinimumWidth = 6;
            this.SPEED_UNITS.Name = "SPEED_UNITS";
            this.SPEED_UNITS.ReadOnly = true;
            this.SPEED_UNITS.Visible = false;
            this.SPEED_UNITS.Width = 125;
            // 
            // DOSAGE
            // 
            this.DOSAGE.HeaderText = "DOSAGE";
            this.DOSAGE.MinimumWidth = 6;
            this.DOSAGE.Name = "DOSAGE";
            this.DOSAGE.ReadOnly = true;
            this.DOSAGE.Visible = false;
            this.DOSAGE.Width = 125;
            // 
            // DOSAGE_UNITS
            // 
            this.DOSAGE_UNITS.HeaderText = "DOSAGE_UNITS";
            this.DOSAGE_UNITS.MinimumWidth = 6;
            this.DOSAGE_UNITS.Name = "DOSAGE_UNITS";
            this.DOSAGE_UNITS.ReadOnly = true;
            this.DOSAGE_UNITS.Visible = false;
            this.DOSAGE_UNITS.Width = 125;
            // 
            // CONCENTRATION
            // 
            this.CONCENTRATION.HeaderText = "CONCENTRATION";
            this.CONCENTRATION.MinimumWidth = 6;
            this.CONCENTRATION.Name = "CONCENTRATION";
            this.CONCENTRATION.ReadOnly = true;
            this.CONCENTRATION.Visible = false;
            this.CONCENTRATION.Width = 125;
            // 
            // CONCENTRATION_UNITS
            // 
            this.CONCENTRATION_UNITS.HeaderText = "CONCENTRATION_UNITS";
            this.CONCENTRATION_UNITS.MinimumWidth = 6;
            this.CONCENTRATION_UNITS.Name = "CONCENTRATION_UNITS";
            this.CONCENTRATION_UNITS.ReadOnly = true;
            this.CONCENTRATION_UNITS.Visible = false;
            this.CONCENTRATION_UNITS.Width = 125;
            // 
            // ADMINISTRATOR
            // 
            this.ADMINISTRATOR.HeaderText = "ADMINISTRATOR";
            this.ADMINISTRATOR.MinimumWidth = 6;
            this.ADMINISTRATOR.Name = "ADMINISTRATOR";
            this.ADMINISTRATOR.ReadOnly = true;
            this.ADMINISTRATOR.Visible = false;
            this.ADMINISTRATOR.Width = 125;
            // 
            // ITEM_CODE
            // 
            this.ITEM_CODE.HeaderText = "ITEM_CODE";
            this.ITEM_CODE.MinimumWidth = 6;
            this.ITEM_CODE.Name = "ITEM_CODE";
            this.ITEM_CODE.ReadOnly = true;
            this.ITEM_CODE.Visible = false;
            this.ITEM_CODE.Width = 125;
            // 
            // ITEM_NO
            // 
            this.ITEM_NO.HeaderText = "ITEM_NO";
            this.ITEM_NO.MinimumWidth = 6;
            this.ITEM_NO.Name = "ITEM_NO";
            this.ITEM_NO.ReadOnly = true;
            this.ITEM_NO.Visible = false;
            this.ITEM_NO.Width = 125;
            // 
            // ITEM_NAME
            // 
            this.ITEM_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ITEM_NAME.HeaderText = "事件名称";
            this.ITEM_NAME.MinimumWidth = 6;
            this.ITEM_NAME.Name = "ITEM_NAME";
            this.ITEM_NAME.ReadOnly = true;
            // 
            // ITEM_SPEC
            // 
            this.ITEM_SPEC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ITEM_SPEC.HeaderText = "规格";
            this.ITEM_SPEC.MinimumWidth = 6;
            this.ITEM_SPEC.Name = "ITEM_SPEC";
            this.ITEM_SPEC.ReadOnly = true;
            this.ITEM_SPEC.Width = 67;
            // 
            // EVENT_ATTR
            // 
            this.EVENT_ATTR.DataPropertyName = "EVENT_ATTR";
            this.EVENT_ATTR.HeaderText = "EVENT_ATTR";
            this.EVENT_ATTR.MinimumWidth = 6;
            this.EVENT_ATTR.Name = "EVENT_ATTR";
            this.EVENT_ATTR.ReadOnly = true;
            this.EVENT_ATTR.Visible = false;
            this.EVENT_ATTR.Width = 125;
            // 
            // DURATIVE_INDICATOR1
            // 
            this.DURATIVE_INDICATOR1.DataPropertyName = "DURATIVE_INDICATOR";
            this.DURATIVE_INDICATOR1.HeaderText = "DURATIVE_INDICATOR";
            this.DURATIVE_INDICATOR1.MinimumWidth = 6;
            this.DURATIVE_INDICATOR1.Name = "DURATIVE_INDICATOR1";
            this.DURATIVE_INDICATOR1.ReadOnly = true;
            this.DURATIVE_INDICATOR1.Visible = false;
            this.DURATIVE_INDICATOR1.Width = 125;
            // 
            // pnlButtonsContainer
            // 
            this.pnlButtonsContainer.Controls.Add(this.btnFour);
            this.pnlButtonsContainer.Controls.Add(this.btnAnes);
            this.pnlButtonsContainer.Controls.Add(this.btnOther);
            this.pnlButtonsContainer.Controls.Add(this.btnOperation);
            this.pnlButtonsContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlButtonsContainer.Location = new System.Drawing.Point(6, 42);
            this.pnlButtonsContainer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlButtonsContainer.Name = "pnlButtonsContainer";
            this.pnlButtonsContainer.Size = new System.Drawing.Size(237, 186);
            this.pnlButtonsContainer.TabIndex = 25;
            // 
            // btnFour
            // 
            this.btnFour.ActionName = null;
            this.btnFour.AutoImage = false;
            this.btnFour.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnFour.BindControl = null;
            this.btnFour.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFour.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFour.HasBorder = true;
            this.btnFour.IsMenu = false;
            this.btnFour.IsMouseHover = true;
            this.btnFour.Location = new System.Drawing.Point(176, 4);
            this.btnFour.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnFour.MenuIndex = 0;
            this.btnFour.Name = "btnFour";
            this.btnFour.PageName = null;
            this.btnFour.Parameters = null;
            this.btnFour.ShortcutKeys = null;
            this.btnFour.ShowText = true;
            this.btnFour.Size = new System.Drawing.Size(53, 35);
            this.btnFour.TabIndex = 15;
            this.btnFour.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnFour.UseVisualStyleBackColor = true;
            // 
            // btnAnes
            // 
            this.btnAnes.ActionName = null;
            this.btnAnes.AutoImage = false;
            this.btnAnes.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAnes.BindControl = null;
            this.btnAnes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAnes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnes.HasBorder = true;
            this.btnAnes.IsMenu = false;
            this.btnAnes.IsMouseHover = true;
            this.btnAnes.Location = new System.Drawing.Point(0, 4);
            this.btnAnes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAnes.MenuIndex = 0;
            this.btnAnes.Name = "btnAnes";
            this.btnAnes.PageName = null;
            this.btnAnes.Parameters = null;
            this.btnAnes.ShortcutKeys = null;
            this.btnAnes.ShowText = true;
            this.btnAnes.Size = new System.Drawing.Size(50, 35);
            this.btnAnes.TabIndex = 11;
            this.btnAnes.Text = "麻醉";
            this.btnAnes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAnes.UseVisualStyleBackColor = true;
            this.btnAnes.Click += new System.EventHandler(this.btnAnes_Click);
            // 
            // btnOther
            // 
            this.btnOther.ActionName = null;
            this.btnOther.AutoImage = false;
            this.btnOther.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOther.BindControl = null;
            this.btnOther.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOther.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOther.HasBorder = true;
            this.btnOther.IsMenu = false;
            this.btnOther.IsMouseHover = true;
            this.btnOther.Location = new System.Drawing.Point(117, 4);
            this.btnOther.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOther.MenuIndex = 0;
            this.btnOther.Name = "btnOther";
            this.btnOther.PageName = null;
            this.btnOther.Parameters = null;
            this.btnOther.ShortcutKeys = null;
            this.btnOther.ShowText = true;
            this.btnOther.Size = new System.Drawing.Size(53, 35);
            this.btnOther.TabIndex = 13;
            this.btnOther.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnOther.UseVisualStyleBackColor = true;
            // 
            // btnOperation
            // 
            this.btnOperation.ActionName = null;
            this.btnOperation.AutoImage = false;
            this.btnOperation.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOperation.BindControl = null;
            this.btnOperation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOperation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOperation.HasBorder = true;
            this.btnOperation.IsMenu = false;
            this.btnOperation.IsMouseHover = true;
            this.btnOperation.Location = new System.Drawing.Point(57, 4);
            this.btnOperation.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOperation.MenuIndex = 0;
            this.btnOperation.Name = "btnOperation";
            this.btnOperation.PageName = null;
            this.btnOperation.Parameters = null;
            this.btnOperation.ShortcutKeys = null;
            this.btnOperation.ShowText = true;
            this.btnOperation.Size = new System.Drawing.Size(53, 35);
            this.btnOperation.TabIndex = 6;
            this.btnOperation.Text = "手术";
            this.btnOperation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnOperation.UseVisualStyleBackColor = true;
            this.btnOperation.Click += new System.EventHandler(this.btnOperation_Click);
            // 
            // lbFilter
            // 
            this.lbFilter.AutoSize = true;
            this.lbFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbFilter.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFilter.Location = new System.Drawing.Point(0, 0);
            this.lbFilter.Name = "lbFilter";
            this.lbFilter.Size = new System.Drawing.Size(100, 22);
            this.lbFilter.TabIndex = 26;
            this.lbFilter.Text = "无过滤字符";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnDrugInfo);
            this.panel1.Controls.Add(this.lbFilter);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(6, 341);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(237, 29);
            this.panel1.TabIndex = 27;
            // 
            // btnDrugInfo
            // 
            this.btnDrugInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDrugInfo.Location = new System.Drawing.Point(150, -3);
            this.btnDrugInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDrugInfo.Name = "btnDrugInfo";
            this.btnDrugInfo.Size = new System.Drawing.Size(86, 30);
            this.btnDrugInfo.TabIndex = 27;
            this.btnDrugInfo.Text = "药品查询";
            this.btnDrugInfo.UseVisualStyleBackColor = true;
            this.btnDrugInfo.Click += new System.EventHandler(this.btnDrugInfo_Click);
            // 
            // AnesthesiaEventDictSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgSelect);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlButtonsContainer);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AnesthesiaEventDictSelector";
            this.Padding = new System.Windows.Forms.Padding(6, 42, 0, 0);
            this.Size = new System.Drawing.Size(243, 370);
            this.Load += new System.EventHandler(this.AnesthesiaEventDictSelector_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgSelect)).EndInit();
            this.pnlButtonsContainer.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_class;
        private System.Windows.Forms.DataGridViewTextBoxColumn SUPPLIER_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn PERFORM_SPEED;
        private System.Windows.Forms.DataGridViewTextBoxColumn SPEED_UNIT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DOSAGE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DOSAGE_UNITS;
        private System.Windows.Forms.DataGridViewTextBoxColumn CONCENTRATION;
        private System.Windows.Forms.DataGridViewTextBoxColumn CONCENTRATION_UNIT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ADMINISTRATOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn ITEM_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn ITEM_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ITEM_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn ITEM_SPEC;
        private System.Windows.Forms.DataGridViewTextBoxColumn EVENT_ATTR;
        private System.Windows.Forms.DataGridViewTextBoxColumn DURATIVE_INDICATOR1;
        private System.Windows.Forms.Panel pnlButtonsContainer;
        private Wis.Anes.Framework.Controls.MedButton btnFour;
        private Wis.Anes.Framework.Controls.MedButton btnAnes;
        private Wis.Anes.Framework.Controls.MedButton btnOther;
        private Wis.Anes.Framework.Controls.MedButton btnOperation;
        private System.Windows.Forms.Label lbFilter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDrugInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn SPEED_UNITS;
        private System.Windows.Forms.DataGridViewTextBoxColumn CONCENTRATION_UNITS;
    }
}
