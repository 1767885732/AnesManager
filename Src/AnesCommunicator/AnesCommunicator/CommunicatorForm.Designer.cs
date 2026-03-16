namespace AnesCommunicator
{
    partial class CommunicatorForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommunicatorForm));
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition2 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.ntfIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.myMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControlMessage = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPageNormal = new DevExpress.XtraTab.XtraTabPage();
            this.grdLstUsers = new DevExpress.XtraGrid.GridControl();
            this.gridViewKind = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnReconnect = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefreshUserList = new DevExpress.XtraEditors.SimpleButton();
            this.panel1 = new DevExpress.XtraEditors.PanelControl();
            this.panel3 = new DevExpress.XtraEditors.PanelControl();
            this.btnSendAll = new DevExpress.XtraEditors.SimpleButton();
            this.btnChatRecord = new DevExpress.XtraEditors.SimpleButton();
            this.btnSend = new DevExpress.XtraEditors.SimpleButton();
            this.txtMessageForSend = new System.Windows.Forms.RichTextBox();
            this.panel2 = new DevExpress.XtraEditors.PanelControl();
            this.txtMessageReceive = new System.Windows.Forms.RichTextBox();
            this.xtraTabPageAnesEvents = new DevExpress.XtraTab.XtraTabPage();
            this.label2 = new DevExpress.XtraEditors.LabelControl();
            this.lblCurrentGroup = new DevExpress.XtraEditors.LabelControl();
            this.label3 = new DevExpress.XtraEditors.LabelControl();
            this.cmbGroupList = new System.Windows.Forms.ListBox();
            this.btnQuitGroup = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelGroup = new DevExpress.XtraEditors.SimpleButton();
            this.btnJoinGroup = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefreshGroupList = new DevExpress.XtraEditors.SimpleButton();
            this.label4 = new DevExpress.XtraEditors.LabelControl();
            this.txtGroupName = new System.Windows.Forms.RichTextBox();
            this.btnCreateGroup = new DevExpress.XtraEditors.SimpleButton();
            this.panel4 = new DevExpress.XtraEditors.PanelControl();
            this.panel5 = new DevExpress.XtraEditors.PanelControl();
            this.txtGroupMessageForSend = new System.Windows.Forms.RichTextBox();
            this.btnGroupSend = new DevExpress.XtraEditors.SimpleButton();
            this.panel6 = new DevExpress.XtraEditors.PanelControl();
            this.txtGroupMessageReceive = new System.Windows.Forms.RichTextBox();
            this.myMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlMessage)).BeginInit();
            this.tabControlMessage.SuspendLayout();
            this.xtraTabPageNormal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLstUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewKind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel3)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel2)).BeginInit();
            this.panel2.SuspendLayout();
            this.xtraTabPageAnesEvents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel4)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel5)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel6)).BeginInit();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "是否在线";
            this.gridColumn1.FieldName = "LOGIN";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // label1
            // 
            this.label1.Appearance.Font = new System.Drawing.Font("宋体", 20F);
            this.label1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.label1.Appearance.Options.UseFont = true;
            this.label1.Appearance.Options.UseForeColor = true;
            this.label1.Location = new System.Drawing.Point(10, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 27);
            this.label1.TabIndex = 3;
            this.label1.Text = "在线列表:";
            // 
            // ntfIcon
            // 
            this.ntfIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("ntfIcon.Icon")));
            this.ntfIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ntfIcon_MouseDoubleClick);
            this.ntfIcon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ntfIcon_MouseDown);
            // 
            // myMenu
            // 
            this.myMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开ToolStripMenuItem,
            this.关闭CToolStripMenuItem});
            this.myMenu.Name = "myMenu";
            this.myMenu.Size = new System.Drawing.Size(119, 48);
            // 
            // 打开ToolStripMenuItem
            // 
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            this.打开ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.打开ToolStripMenuItem.Text = "打开(&O)";
            this.打开ToolStripMenuItem.Click += new System.EventHandler(this.打开ToolStripMenuItem_Click);
            // 
            // 关闭CToolStripMenuItem
            // 
            this.关闭CToolStripMenuItem.Name = "关闭CToolStripMenuItem";
            this.关闭CToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.关闭CToolStripMenuItem.Text = "关闭(&C)";
            this.关闭CToolStripMenuItem.Click += new System.EventHandler(this.关闭CToolStripMenuItem_Click);
            // 
            // tabControlMessage
            // 
            this.tabControlMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMessage.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControlMessage.Location = new System.Drawing.Point(0, 0);
            this.tabControlMessage.Name = "tabControlMessage";
            this.tabControlMessage.SelectedTabPage = this.xtraTabPageNormal;
            this.tabControlMessage.Size = new System.Drawing.Size(806, 500);
            this.tabControlMessage.TabIndex = 9;
            this.tabControlMessage.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPageNormal,
            this.xtraTabPageAnesEvents});
            this.tabControlMessage.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.tabControlMessage_SelectedPageChanged);
            // 
            // xtraTabPageNormal
            // 
            this.xtraTabPageNormal.Controls.Add(this.grdLstUsers);
            this.xtraTabPageNormal.Controls.Add(this.btnReconnect);
            this.xtraTabPageNormal.Controls.Add(this.btnRefreshUserList);
            this.xtraTabPageNormal.Controls.Add(this.panel1);
            this.xtraTabPageNormal.Controls.Add(this.label1);
            this.xtraTabPageNormal.Name = "xtraTabPageNormal";
            this.xtraTabPageNormal.Size = new System.Drawing.Size(799, 470);
            this.xtraTabPageNormal.Text = "消息通讯";
            // 
            // grdLstUsers
            // 
            this.grdLstUsers.Font = new System.Drawing.Font("宋体", 10F);
            this.grdLstUsers.Location = new System.Drawing.Point(8, 39);
            this.grdLstUsers.MainView = this.gridViewKind;
            this.grdLstUsers.Name = "grdLstUsers";
            this.grdLstUsers.Size = new System.Drawing.Size(192, 383);
            this.grdLstUsers.TabIndex = 0;
            this.grdLstUsers.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewKind});
            // 
            // gridViewKind
            // 
            this.gridViewKind.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.White;
            this.gridViewKind.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gridViewKind.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridViewKind.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridViewKind.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn9,
            this.gridColumn1});
            styleFormatCondition2.Appearance.ForeColor = System.Drawing.Color.Blue;
            styleFormatCondition2.Appearance.Options.UseForeColor = true;
            styleFormatCondition2.ApplyToRow = true;
            styleFormatCondition2.Column = this.gridColumn1;
            styleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition2.Value1 = true;
            this.gridViewKind.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition2});
            this.gridViewKind.GridControl = this.grdLstUsers;
            this.gridViewKind.Name = "gridViewKind";
            this.gridViewKind.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.gridViewKind.OptionsCustomization.AllowColumnMoving = false;
            this.gridViewKind.OptionsCustomization.AllowFilter = false;
            this.gridViewKind.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewKind.OptionsView.ShowColumnHeaders = false;
            this.gridViewKind.OptionsView.ShowGroupPanel = false;
            this.gridViewKind.OptionsView.ShowIndicator = false;
            this.gridViewKind.RowHeight = 40;
            this.gridViewKind.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridViewKind_RowCellClick);
            this.gridViewKind.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridViewKind_CustomDrawCell);
            this.gridViewKind.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridViewKind_RowStyle);
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 16F);
            this.gridColumn9.AppearanceCell.Options.UseFont = true;
            this.gridColumn9.Caption = "用户列表";
            this.gridColumn9.FieldName = "ROOM_NO";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowMove = false;
            this.gridColumn9.OptionsColumn.AllowSize = false;
            this.gridColumn9.OptionsColumn.ReadOnly = true;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 0;
            // 
            // btnReconnect
            // 
            this.btnReconnect.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnReconnect.Appearance.Options.UseFont = true;
            this.btnReconnect.Location = new System.Drawing.Point(104, 428);
            this.btnReconnect.Name = "btnReconnect";
            this.btnReconnect.Size = new System.Drawing.Size(87, 30);
            this.btnReconnect.TabIndex = 10;
            this.btnReconnect.Text = "重连";
            this.btnReconnect.Click += new System.EventHandler(this.btnReconnect_Click);
            // 
            // btnRefreshUserList
            // 
            this.btnRefreshUserList.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnRefreshUserList.Appearance.Options.UseFont = true;
            this.btnRefreshUserList.Location = new System.Drawing.Point(11, 428);
            this.btnRefreshUserList.Name = "btnRefreshUserList";
            this.btnRefreshUserList.Size = new System.Drawing.Size(87, 30);
            this.btnRefreshUserList.TabIndex = 11;
            this.btnRefreshUserList.Text = "刷新";
            this.btnRefreshUserList.Click += new System.EventHandler(this.btnRefreshUserList_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(208, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(591, 470);
            this.panel1.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnSendAll);
            this.panel3.Controls.Add(this.btnChatRecord);
            this.panel3.Controls.Add(this.btnSend);
            this.panel3.Controls.Add(this.txtMessageForSend);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(2, 334);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(587, 134);
            this.panel3.TabIndex = 2;
            // 
            // btnSendAll
            // 
            this.btnSendAll.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnSendAll.Appearance.Options.UseFont = true;
            this.btnSendAll.Location = new System.Drawing.Point(495, 94);
            this.btnSendAll.Name = "btnSendAll";
            this.btnSendAll.Size = new System.Drawing.Size(87, 30);
            this.btnSendAll.TabIndex = 1;
            this.btnSendAll.Text = "全员发送";
            this.btnSendAll.Click += new System.EventHandler(this.btnSendAll_Click);
            // 
            // btnChatRecord
            // 
            this.btnChatRecord.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnChatRecord.Appearance.Options.UseFont = true;
            this.btnChatRecord.Location = new System.Drawing.Point(5, 94);
            this.btnChatRecord.Name = "btnChatRecord";
            this.btnChatRecord.Size = new System.Drawing.Size(87, 30);
            this.btnChatRecord.TabIndex = 1;
            this.btnChatRecord.Text = "聊天记录";
            this.btnChatRecord.Click += new System.EventHandler(this.btnChatRecord_Click);
            // 
            // btnSend
            // 
            this.btnSend.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnSend.Appearance.Options.UseFont = true;
            this.btnSend.Location = new System.Drawing.Point(402, 94);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(87, 30);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "发送";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtMessageForSend
            // 
            this.txtMessageForSend.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtMessageForSend.Location = new System.Drawing.Point(2, 2);
            this.txtMessageForSend.Name = "txtMessageForSend";
            this.txtMessageForSend.Size = new System.Drawing.Size(583, 86);
            this.txtMessageForSend.TabIndex = 1;
            this.txtMessageForSend.Text = "";
            this.txtMessageForSend.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMessageForSend_KeyDown);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtMessageReceive);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(587, 332);
            this.panel2.TabIndex = 1;
            // 
            // txtMessageReceive
            // 
            this.txtMessageReceive.BackColor = System.Drawing.Color.White;
            this.txtMessageReceive.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMessageReceive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMessageReceive.Location = new System.Drawing.Point(2, 2);
            this.txtMessageReceive.Name = "txtMessageReceive";
            this.txtMessageReceive.ReadOnly = true;
            this.txtMessageReceive.Size = new System.Drawing.Size(583, 328);
            this.txtMessageReceive.TabIndex = 3;
            this.txtMessageReceive.Text = "";
            // 
            // xtraTabPageAnesEvents
            // 
            this.xtraTabPageAnesEvents.Controls.Add(this.label2);
            this.xtraTabPageAnesEvents.Controls.Add(this.lblCurrentGroup);
            this.xtraTabPageAnesEvents.Controls.Add(this.label3);
            this.xtraTabPageAnesEvents.Controls.Add(this.cmbGroupList);
            this.xtraTabPageAnesEvents.Controls.Add(this.btnQuitGroup);
            this.xtraTabPageAnesEvents.Controls.Add(this.btnDelGroup);
            this.xtraTabPageAnesEvents.Controls.Add(this.btnJoinGroup);
            this.xtraTabPageAnesEvents.Controls.Add(this.btnRefreshGroupList);
            this.xtraTabPageAnesEvents.Controls.Add(this.label4);
            this.xtraTabPageAnesEvents.Controls.Add(this.txtGroupName);
            this.xtraTabPageAnesEvents.Controls.Add(this.btnCreateGroup);
            this.xtraTabPageAnesEvents.Controls.Add(this.panel4);
            this.xtraTabPageAnesEvents.Name = "xtraTabPageAnesEvents";
            this.xtraTabPageAnesEvents.PageVisible = false;
            this.xtraTabPageAnesEvents.Size = new System.Drawing.Size(799, 470);
            this.xtraTabPageAnesEvents.Text = "组消息";
            // 
            // label2
            // 
            this.label2.Appearance.Font = new System.Drawing.Font("宋体", 20F);
            this.label2.Appearance.Options.UseFont = true;
            this.label2.Location = new System.Drawing.Point(10, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 27);
            this.label2.TabIndex = 45;
            this.label2.Text = "讨论组列表:";
            // 
            // lblCurrentGroup
            // 
            this.lblCurrentGroup.Location = new System.Drawing.Point(315, 15);
            this.lblCurrentGroup.Name = "lblCurrentGroup";
            this.lblCurrentGroup.Size = new System.Drawing.Size(24, 14);
            this.lblCurrentGroup.TabIndex = 43;
            this.lblCurrentGroup.Text = "暂无";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(204, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 14);
            this.label3.TabIndex = 44;
            this.label3.Text = "当前所属分组：";
            // 
            // cmbGroupList
            // 
            this.cmbGroupList.BackColor = System.Drawing.SystemColors.Control;
            this.cmbGroupList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cmbGroupList.Font = new System.Drawing.Font("宋体", 15F);
            this.cmbGroupList.FormattingEnabled = true;
            this.cmbGroupList.ItemHeight = 20;
            this.cmbGroupList.Location = new System.Drawing.Point(13, 45);
            this.cmbGroupList.Name = "cmbGroupList";
            this.cmbGroupList.Size = new System.Drawing.Size(181, 280);
            this.cmbGroupList.TabIndex = 42;
            // 
            // btnQuitGroup
            // 
            this.btnQuitGroup.Location = new System.Drawing.Point(13, 430);
            this.btnQuitGroup.Name = "btnQuitGroup";
            this.btnQuitGroup.Size = new System.Drawing.Size(87, 27);
            this.btnQuitGroup.TabIndex = 41;
            this.btnQuitGroup.Text = "退出组";
            this.btnQuitGroup.Click += new System.EventHandler(this.btnQuitGroup_Click);
            // 
            // btnDelGroup
            // 
            this.btnDelGroup.Location = new System.Drawing.Point(107, 430);
            this.btnDelGroup.Name = "btnDelGroup";
            this.btnDelGroup.Size = new System.Drawing.Size(87, 27);
            this.btnDelGroup.TabIndex = 40;
            this.btnDelGroup.Text = "删除组";
            this.btnDelGroup.Click += new System.EventHandler(this.btnDelGroup_Click);
            // 
            // btnJoinGroup
            // 
            this.btnJoinGroup.Location = new System.Drawing.Point(107, 399);
            this.btnJoinGroup.Name = "btnJoinGroup";
            this.btnJoinGroup.Size = new System.Drawing.Size(87, 27);
            this.btnJoinGroup.TabIndex = 39;
            this.btnJoinGroup.Text = "加入该组";
            this.btnJoinGroup.Click += new System.EventHandler(this.btnJoinGroup_Click);
            // 
            // btnRefreshGroupList
            // 
            this.btnRefreshGroupList.Location = new System.Drawing.Point(16, 334);
            this.btnRefreshGroupList.Name = "btnRefreshGroupList";
            this.btnRefreshGroupList.Size = new System.Drawing.Size(87, 27);
            this.btnRefreshGroupList.TabIndex = 38;
            this.btnRefreshGroupList.Text = "刷新";
            this.btnRefreshGroupList.Click += new System.EventHandler(this.btnRefreshGroupList_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(13, 371);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 14);
            this.label4.TabIndex = 37;
            this.label4.Text = "组名";
            // 
            // txtGroupName
            // 
            this.txtGroupName.Location = new System.Drawing.Point(52, 368);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(142, 21);
            this.txtGroupName.TabIndex = 36;
            this.txtGroupName.Text = "";
            // 
            // btnCreateGroup
            // 
            this.btnCreateGroup.Location = new System.Drawing.Point(13, 399);
            this.btnCreateGroup.Name = "btnCreateGroup";
            this.btnCreateGroup.Size = new System.Drawing.Size(87, 27);
            this.btnCreateGroup.TabIndex = 35;
            this.btnCreateGroup.Text = "创建组";
            this.btnCreateGroup.Click += new System.EventHandler(this.btnCreateGroup_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Location = new System.Drawing.Point(200, 45);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(604, 430);
            this.panel4.TabIndex = 31;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.txtGroupMessageForSend);
            this.panel5.Controls.Add(this.btnGroupSend);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(2, 287);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(600, 141);
            this.panel5.TabIndex = 2;
            // 
            // txtGroupMessageForSend
            // 
            this.txtGroupMessageForSend.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtGroupMessageForSend.Location = new System.Drawing.Point(2, 2);
            this.txtGroupMessageForSend.Name = "txtGroupMessageForSend";
            this.txtGroupMessageForSend.Size = new System.Drawing.Size(596, 79);
            this.txtGroupMessageForSend.TabIndex = 27;
            this.txtGroupMessageForSend.Text = "";
            this.txtGroupMessageForSend.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGroupMessageForSend_KeyDown);
            // 
            // btnGroupSend
            // 
            this.btnGroupSend.Location = new System.Drawing.Point(482, 87);
            this.btnGroupSend.Name = "btnGroupSend";
            this.btnGroupSend.Size = new System.Drawing.Size(91, 36);
            this.btnGroupSend.TabIndex = 26;
            this.btnGroupSend.Text = "发送组消息";
            this.btnGroupSend.Click += new System.EventHandler(this.btnGroupSend_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.txtGroupMessageReceive);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(2, 2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(600, 285);
            this.panel6.TabIndex = 1;
            // 
            // txtGroupMessageReceive
            // 
            this.txtGroupMessageReceive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGroupMessageReceive.Enabled = false;
            this.txtGroupMessageReceive.Location = new System.Drawing.Point(2, 2);
            this.txtGroupMessageReceive.Name = "txtGroupMessageReceive";
            this.txtGroupMessageReceive.Size = new System.Drawing.Size(596, 281);
            this.txtGroupMessageReceive.TabIndex = 0;
            this.txtGroupMessageReceive.Text = "";
            this.txtGroupMessageReceive.Visible = false;
            // 
            // CommunicatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 500);
            this.Controls.Add(this.tabControlMessage);
            //this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CommunicatorForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "消息通讯";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CommunicatorForm_FormClosing);
            this.myMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabControlMessage)).EndInit();
            this.tabControlMessage.ResumeLayout(false);
            this.xtraTabPageNormal.ResumeLayout(false);
            this.xtraTabPageNormal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLstUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewKind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panel3)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panel2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.xtraTabPageAnesEvents.ResumeLayout(false);
            this.xtraTabPageAnesEvents.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel4)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panel5)).EndInit();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panel6)).EndInit();
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl label1;
        private System.Windows.Forms.NotifyIcon ntfIcon;
        private System.Windows.Forms.ContextMenuStrip myMenu;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭CToolStripMenuItem;
        private DevExpress.XtraTab.XtraTabControl tabControlMessage;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageNormal;
        private DevExpress.XtraEditors.SimpleButton btnReconnect;
        private DevExpress.XtraEditors.SimpleButton btnRefreshUserList;
        private DevExpress.XtraEditors.PanelControl panel1;
        private DevExpress.XtraEditors.PanelControl panel3;
        private DevExpress.XtraEditors.SimpleButton btnSendAll;
        private DevExpress.XtraEditors.SimpleButton btnSend;
        private System.Windows.Forms.RichTextBox txtMessageForSend;
        private DevExpress.XtraEditors.PanelControl panel2;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageAnesEvents;
        private DevExpress.XtraEditors.LabelControl label2;
        private DevExpress.XtraEditors.LabelControl lblCurrentGroup;
        private DevExpress.XtraEditors.LabelControl label3;
        private System.Windows.Forms.ListBox cmbGroupList;
        private DevExpress.XtraEditors.SimpleButton btnQuitGroup;
        private DevExpress.XtraEditors.SimpleButton btnDelGroup;
        private DevExpress.XtraEditors.SimpleButton btnJoinGroup;
        private DevExpress.XtraEditors.SimpleButton btnRefreshGroupList;
        private DevExpress.XtraEditors.LabelControl label4;
        private System.Windows.Forms.RichTextBox txtGroupName;
        private DevExpress.XtraEditors.SimpleButton btnCreateGroup;
        private DevExpress.XtraEditors.PanelControl panel4;
        private DevExpress.XtraEditors.PanelControl panel5;
        private System.Windows.Forms.RichTextBox txtGroupMessageForSend;
        private DevExpress.XtraEditors.SimpleButton btnGroupSend;
        private DevExpress.XtraEditors.PanelControl panel6;
        private System.Windows.Forms.RichTextBox txtGroupMessageReceive;
        private DevExpress.XtraGrid.GridControl grdLstUsers;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewKind;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.SimpleButton btnChatRecord;
        private System.Windows.Forms.RichTextBox txtMessageReceive;
    }
}

