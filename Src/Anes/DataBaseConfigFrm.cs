using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Configuration;
using System.IO;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraTab;
using Wis.Anes.Framework.Utilities;
using Wis.Anes.ServiceProxies;
using Wis.Anes.Framework;
using Wis.Anes.Framework.Configurations;
using Wis.Anes.Framework.Controls.Base;

namespace Wis.Anes
{
    public partial class DataBaseConfigFrm : XtraForm
    {

        public DataBaseConfigFrm() : this("主数据库连接串") { }
        public DataBaseConfigFrm(string connectionName)
        {
            InitializeComponent();
            Text = "数据库配置";
            StartPosition = FormStartPosition.CenterScreen;
            MinimizeBox = false;
            MaximizeBox = false;
            Width = 300;

            List<string> names = new List<string>();
            names.Add("docare");
            names.Add("PriceListConn");
            names.Add("AcsConn");
            names.Add("Com.Wis.Anes.DataSetModel.Properties.Settings.OleConnectionString");
            if (names != null && names.Count > 0)
            {
                List<string> connStrings = new List<string>();
                foreach (string text in names)
                {
                    connStrings.Add(TransConnectionStringName(text));
                }
                int topOffSet = 30;

                topOffSet = AddLine("连接串名称", connStrings.ToArray(), topOffSet, true);
                (this.Controls["连接串名称"] as ComboBoxEdit).Text = connectionName;
                //topOffSet = AddLine("数据库类型", new string[] { "SQL Server", "Oracle", "Access" }, topOffSet);
                topOffSet = AddLine("数据库类型", new string[] { "SQL Server", "Oracle" }, topOffSet);
                topOffSet = AddLine("服务器地址", topOffSet);
                topOffSet = AddLine("数据库名称", topOffSet);
                topOffSet = AddLine("集成身份验证", topOffSet, 0, true);
                topOffSet = AddLine("数据库用户", topOffSet);
                topOffSet = AddLine("登入密码  ", topOffSet);
                topOffSet = AddLine("确认密码  ", topOffSet);
                ChangeConnectionName("主数据库连接串");

                topOffSet = AddLine("默认手术间", topOffSet + 15);
                SimpleButton button = AddButton("测试", topOffSet, 20);
                button.Click += new EventHandler(delegate(object sender, EventArgs e)
                {
                    Test();
                });
                button = AddButton("导出", topOffSet, 110);
                button.Click += new EventHandler(delegate(object sender, EventArgs e)
                {
                    Export();
                });
                button = AddButton("导入", topOffSet, 200);
                button.Click += new EventHandler(delegate(object sender, EventArgs e)
                {
                    Import();
                });
                topOffSet += button.Height + 10;
                button = AddButton("确认", topOffSet, 110);
                AcceptButton = button;
                button.Click += new EventHandler(delegate(object sender, EventArgs e)
                {
                    Confirm();
                });
                button = AddButton("取消", topOffSet, 200);
                CancelButton = button;
                button.Click += new EventHandler(delegate(object sender, EventArgs e)
                {
                    Close();
                });
                Height = button.Bottom + 50;
            }
            SetValue("默认手术间", ApplicationConfiguration.OpertionRoom);
        }

        private string TransConnectionStringName(string connectionStringName)
        {
            string text = "";
            if (connectionStringName.Equals("AcsConn"))
            {
                text = "专家咨询库连接串";
            }
            else if (connectionStringName.Equals("docare"))
            {
                text = "主数据库连接串";
            }
            else if (connectionStringName.Equals("PriceListConn"))
            {
                text = "价表视图连接串";
            }
            else if (connectionStringName.Equals("Com.Wis.Anes.DataSetModel.Properties.Settings.OleConnectionString"))
            {
                text = "本地数据库连接串";
            }
            return text;
        }

        private string TransToConnectionStringName(string transString)
        {
            string text = "";
            if (transString.Equals("专家咨询库连接串"))
            {
                text = "AcsConn";
            }
            else if (transString.Equals("主数据库连接串"))
            {
                text = "docare";
            }
            else if (transString.Equals("价表视图连接串"))
            {
                text = "PriceListConn";
            }
            else if (transString.Equals("本地数据库连接串"))
            {
                text = "Com.Wis.Anes.DataSetModel.Properties.Settings.OleConnectionString";
            }
            return text;
        }

        private void SetValue(string key, string value)
        {
            if (this.Controls.ContainsKey(key))
            {
                Control control = this.Controls[key];
                if (control is CheckEdit)
                {
                    int v = 0;
                    if (!int.TryParse(value, out v)) v = 0;
                    (control as CheckEdit).Checked = v > 0;
                }
                else
                {
                    control.Text = value;
                }
            }
        }

        private string GetValue(string key)
        {
            if (this.Controls.ContainsKey(key))
            {
                Control control = this.Controls[key];
                if (control is CheckEdit)
                {
                    return (control as CheckEdit).Checked ? "1" : "0";
                }
                else
                {
                    return control.Text;
                }
            }
            return null;
        }

        private bool CheckItem(string key)
        {
            Control control = this.Controls[key];
            if (control.Enabled && string.IsNullOrEmpty(control.Text.Trim()))
            {
                Dialog.MessageBox("没有输入" + key, MessageBoxIcon.Information);
                control.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool CheckItem(string key1, string key2)
        {
            if (this.Controls[key1].Text.Equals(this.Controls[key2].Text))
            {
                return true;
            }
            else
            {
                Dialog.MessageBox(key1 + "和" + key2 + "不匹配", MessageBoxIcon.Information);
                this.Controls[key2].Focus();
                return false;
            }
        }

        private void Export()
        {
            if (CheckInput())
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "数据库配置文件(*.dbcfg)|*.dbcfg";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter sw = new StreamWriter(dialog.FileName);
                    sw.Write(CommonProxy.EncodeConnectionString(TransToConnectionStringName(GetValue("连接串名称")), DbTypeToProviderName(GetValue("数据库类型")), GetValue("服务器地址")
                    , GetValue("数据库名称"), GetValue("数据库用户"), GetValue("登入密码"), (GetValue("集成身份验证") == "1")));
                    sw.Flush();
                    sw.Close();
                }
            }
        }

        private void Import()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "数据库配置文件(*.dbcfg)|*.dbcfg";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(dialog.FileName);
                string s = sr.ReadToEnd();
                sr.Close();
                ImportString(s);
            }
        }

        private void Test()
        {
            if (CheckInput())
            {
                string dbType = GetValue("数据库类型");
                string serverAD = GetValue("服务器地址");
                string dbName = GetValue("数据库名称");
                string userID = GetValue("数据库用户");
                string password = GetValue("登入密码");
                bool isWindowUser = GetValue("集成身份验证") == "1";


                Exception ex = new Exception();
                try
                {
                    if (CommonProxy.TestConnection(DbTypeToProviderName(dbType), serverAD, dbName, userID, password, isWindowUser, ref ex))
                    {

                        XtraMessageBox.Show("测试成功", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        XtraMessageBox.Show(ex.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                catch (Exception e)
                {
                    ExceptionHandler.Handle(e);
                }
            }
        }

        private bool CheckInput()
        {
            bool result = CheckItem("连接串名称");
            if (!result) return result;
            result = CheckItem("数据库类型");
            if (!result) return result;
            //result = CheckItem("服务器地址");
            //if (!result) return result;
            if (!string.IsNullOrEmpty(Controls["连接串名称"].Text) && Controls["连接串名称"].Text.ToLower().Equals("sql server"))
            {
                result = CheckItem("数据库名称");
                if (!result) return result;
            }
            result = CheckItem("数据库用户");
            if (!result) return result;
            result = CheckItem("登入密码", "确认密码");
            if (!result) return result;
            return result;
        }

        //private DataSetModel.DataBaseConfig GetDataBaseConfig()
        //{
        //    return new DataSetModel.DataBaseConfig(TransToConnectionStringName( GetValue("连接串名称")), DbTypeToProviderName(GetValue("数据库类型")), GetValue("服务器地址")
        //        , GetValue("数据库名称"), GetValue("数据库用户"), GetValue("登入密码"), (GetValue("集成身份验证") == "1"));
        //}

        private void Confirm()
        {
            if (CheckInput())
            {
                string connectionName = TransToConnectionStringName(GetValue("连接串名称"));
                string s = CommonProxy.EncodeConnectionString(connectionName, DbTypeToProviderName(GetValue("数据库类型")), GetValue("服务器地址")
                    , GetValue("数据库名称"), GetValue("数据库用户"), GetValue("登入密码"), (GetValue("集成身份验证") == "1"));
                ConfigurationHelper.Save(connectionName, s);
                if (connectionName.Equals("docare"))
                {
                    s = "Provider=MSDAORA;Data Source=" + GetValue("服务器地址") + ";Persist Security Info=True;Password="
                     + GetValue("数据库用户") + ";User ID=" + GetValue("登入密码");
                    s = Sundries.EncodeString(s);
                    ConfigurationHelper.Save("DevartOleConnection", s);
                }
                ApplicationConfiguration.OpertionRoom = GetValue("默认手术间");
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private int AddLine(string caption, int topOffSet) { return AddLine(caption, null, topOffSet); }
        private int AddLine(string caption, object[] items, int topOffSet) { return AddLine(caption, items, topOffSet, true); }
        private int AddLine(string caption, object[] items, int topOffSet, bool visible) { return AddLine(caption, caption.Trim(), items, topOffSet, -1, visible); }
        private int AddLine(string caption, int topOffSet, int checkStatus, bool visible) { return AddLine(caption, caption.Trim(), null, topOffSet, checkStatus, visible); }
        private int AddLine(string caption, object[] items, int topOffSet, int checkStatus, bool visible) { return AddLine(caption, caption.Trim(), items, topOffSet, checkStatus, visible); }
        private int AddLine(string caption, string fieldName, object[] items, int topOffSet, int checkStatus, bool visible)
        {
            int yOffSet = topOffSet;
            int xOffSet = 20;
            int span = 10;
            LabelControl label = new LabelControl();
            label.Text = caption;
            label.AutoSize = true;
            Control control;
            if (checkStatus >= 0)
            {
                control = new CheckEdit();
                CheckEdit CheckEdit = control as CheckEdit;
                CheckEdit.Checked = checkStatus > 0;
                CheckEdit.CheckedChanged += new EventHandler(CheckEdit_CheckedChanged);
            }
            else
            {
                if (items == null)
                {
                    control = new TextEdit();
                    if (caption.Contains("密码"))
                    {
                        (control as TextEdit).Properties.PasswordChar = '*';
                    }
                    else if (caption == "默认手术间")
                    {
                        //TextEdit txtOpertionRoom = control as TextEdit;
                        //if (CheckInput())
                        //{
                        //    txtOpertionRoom.Text = Configurations.OpertionRoom;
                        //}
                        //txtOpertionRoom.DoubleClick += delegate
                        //{
                        //    DataSetModel.OperatingRoom room = new DataSetModel.OperatingRoomAdapter().GetData();
                        //    Dialog.ShowCustomSelection(room, "RoomNo", txtOpertionRoom, new Point(0, txtOpertionRoom.Height), new Size(100, 300)
                        //        , new EventHandler(delegate(object s1, EventArgs e1)
                        //        {
                        //            if (s1 is int)
                        //            {
                        //                int index = (int)s1;
                        //                txtOpertionRoom.Text = room[index].RoomNo;
                        //            }
                        //            else if (s1 is int[])
                        //            {
                        //                string s = "";
                        //                foreach (int i in (s1 as int[]))
                        //                {
                        //                    s = s + "," + room[i].RoomNo;
                        //                }
                        //                txtOpertionRoom.Text = s.Substring(1);
                        //            }
                        //        }), true);
                        //};
                    }
                }
                else
                {
                    control = new ComboBoxEdit();
                    ComboBoxEdit cmbBox = control as ComboBoxEdit;

                    cmbBox.Properties.Items.AddRange(items);
                    cmbBox.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;

                    cmbBox.SelectedValueChanged += new EventHandler(cmbBox_SelectedValueChanged);
                }
            }
            label.Top = yOffSet;
            label.Left = xOffSet;
            label.Name = "L" + fieldName;
            control.Top = yOffSet - 3;
            control.Left = label.Right + span;
            control.Width = Width - control.Left - xOffSet;
            control.Name = fieldName;
            if (control is CheckEdit)
            {
                control.Text = label.Text;
                control.Left = label.Left;
            }
            else
            {
                this.Controls.Add(label);
                control.DoubleClick += new EventHandler(control_DoubleClick);
            }
            this.Controls.Add(control);
            control.Visible = visible;
            yOffSet += control.Height + span;
            return visible ? yOffSet : topOffSet;
        }

        private void control_DoubleClick(object sender, EventArgs e)
        {
            if ((sender as Control).Name.Equals("服务器地址"))
            {
                string[] tnsNames = Wis.Anes.ServiceProxies.DataBaseConfigHelperProxy.GetOracleTnsNames();
                if (tnsNames != null)
                {
                    Dialog.ShowCustomSelection(tnsNames, "", sender as Control, new Point(0, (sender as Control).Height), new Size(300, 300), new EventHandler(delegate(object sender1, EventArgs e1)
                    {
                        (sender as Control).Text = tnsNames[(int)sender1];
                    }), false);
                }
            }
        }

        private void CheckEdit_CheckedChanged(object sender, EventArgs e)
        {
            bool enable = !(sender as CheckEdit).Checked;
            if (!this.Controls["数据库类型"].Text.Equals("Access"))
            {
                this.Controls["数据库用户"].Enabled = enable;
            }
            this.Controls["登入密码"].Enabled = enable;
            this.Controls["确认密码"].Enabled = enable;
        }

        private void ImportString(string connString)
        {
            if (string.IsNullOrEmpty(connString)) return;
            try
            {
                string connectionName = "", providerName = "", serverAddress = "", dataBaseName = "", userName = "", password = "";
                bool isWindowUser = false;
                CommonProxy.DecodeConnectionString(connString, ref connectionName, ref providerName, ref serverAddress, ref dataBaseName
                    , ref userName, ref password, ref isWindowUser);
                //SetValue("连接串名称", connectionName);
                SetValue("数据库类型", ProviderNameToDbType(providerName));
                SetValue("服务器地址", serverAddress);
                SetValue("数据库名称", dataBaseName);
                SetValue("数据库用户", userName);
                SetValue("登入密码", password);
                SetValue("确认密码", password);
                SetValue("集成身份验证", isWindowUser ? "1" : "0");
            }
            catch
            {
            }
        }

        private void ClearValues()
        {
            //SetValue("连接串名称", "");
            SetValue("数据库类型", "");
            SetValue("服务器地址", "");
            SetValue("数据库名称", "");
            SetValue("数据库用户", "");
            SetValue("登入密码", "");
            SetValue("集成身份验证", "");
            SetValue("确认密码", "");
        }

        private void ChangeConnectionName(string aliasName)
        {
            ClearValues();
            ImportString(ConfigurationHelper.Read(TransToConnectionStringName(aliasName)));
        }

        private void cmbBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if ((sender as Control).Name.Equals("连接串名称"))
            {
                ChangeConnectionName(GetValue("连接串名称"));
            }
            else if ((sender as Control).Name.Equals("数据库类型"))
            {
                string dataBaseType = (sender as Control).Text;

                if (!dataBaseType.Equals("SQL Server"))
                {
                    //((CheckEdit)this.Controls["集成身份验证"]).Checked = false;
                    ((CheckEdit)this.Controls["集成身份验证"]).Visible = false;
                }
                else
                {
                    ((CheckEdit)this.Controls["集成身份验证"]).Visible = true;
                }
                if (dataBaseType.Equals("Oracle"))
                {
                    this.Controls["L服务器地址"].Text = "服务名";
                }
                else
                {
                    this.Controls["L服务器地址"].Text = "服务器地址";
                }
                this.Controls["数据库名称"].Visible = !dataBaseType.Equals("Oracle");
                this.Controls["L数据库名称"].Visible = !dataBaseType.Equals("Oracle");
                //this.Controls["集成身份验证"].Enabled = this.Controls["数据库名称"].Enabled;

                this.Controls["数据库用户"].Enabled = !dataBaseType.Equals("Access");
                //Controls["服务器地址"].Enabled = Controls["数据库用户"].Enabled;
            }
        }

        private string DbTypeToProviderName(string dbType)
        {
            string providerName;
            if (dbType.ToLower().Equals("oracle"))
            {
                providerName = "System.Data.OracleClient";
            }
            else if (dbType.ToLower().Equals("sql server"))
            {
                providerName = "System.Data.SqlClient";
            }
            else //if (dbType.ToLower().Equals("access"))
            {
                providerName = "System.Data.OleDb";
            }
            return providerName;
        }

        private string ProviderNameToDbType(string providerName)
        {
            string dbType;
            if (providerName.ToLower().Equals("system.data.oracleclient"))
            {
                dbType = "Oracle";
            }
            else if (providerName.ToLower().Equals("system.data.sqlclient"))
            {
                dbType = "SQL Server";
            }
            else //if (providerName.ToLower().Equals("system.data.oledb"))
            {
                dbType = "Access";
            }
            return dbType;
        }

        private SimpleButton AddButton(string text, int topOffSet, int leftOffSet)
        {
            SimpleButton button = new SimpleButton();
            button.Text = text;
            button.Cursor = Cursors.Hand;
            button.Left = leftOffSet;
            button.Top = topOffSet;
            button.Width = 60;
            this.Controls.Add(button);
            return button;
        }
    }

    }

