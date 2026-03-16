using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Wis.Anes.Framework.Utilities;
using Wis.Anes.Framework.Controls;
using Wis.Anes.Framework.Views;
using Wis.Anes.Framework;
using Wis.Anes.ServiceProxies;
using Wis.Anes.Framework.Controls.Base;
using Wis.Anes.Framework.Configurations;

namespace Wis.Anes.Views
{
    public partial class AnesthesiaEventDictSelector : BaseView
    {
        public AnesthesiaEventDictSelector(decimal eventNo,bool showAnesAndOper)
        {
            InitializeComponent();
            _eventNo = eventNo;
            //if (eventNo == 1)
            //{
            //    btnAnes.Text = Globals.PACUSTART;
            //    btnOperation.Text = Globals.PACUEND;
            //}
            string[] buttons;
            //if (eventNo != 2)
            //{
                buttons = ApplicationConfiguration.AnesEventButtons.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            //}
            //else
            //{
            //    List<string> list = new List<string>();
            //    Dictionary<string, string>.Enumerator enumerator = Globals.CPBEventType.GetEnumerator();
            //    while (enumerator.MoveNext())
            //    {
            //        list.Add(enumerator.Current.Key);
            //    }
            //    buttons = list.ToArray();
            //}
            int top = btnAnes.Top;
            List<MedButton> buttonList = new List<MedButton>();
            buttonList.Add(btnAnes);
            buttonList.Add(btnOperation);
            for (int i = 0; i < buttons.Length; i++)
            {
                MedButton button;
                if (i == 0)
                {
                    button = btnOther;
                }
                else if (i == 1)
                {
                    button = btnFour;
                }
                else
                {
                    button = new MedButton();
                    switch (i % 4)
                    {
                        case 1:
                            button.Left = btnFour.Left;
                            break;
                        case 2:
                            button.Left = btnAnes.Left;
                            top += btnAnes.Height + 1;
                            break;
                        case 3:
                            button.Left = btnOperation.Left;
                            break;
                        case 0:
                            button.Left = btnOther.Left;
                            break;
                    }
                    button.Width = btnAnes.Width;
                    button.Top = top;
                    btnAnes.Parent.Controls.Add(button);
                }
                button.Text = buttons[i];
                buttonList.Add(button);
                button.Click += new EventHandler(delegate(object sender, EventArgs e)
                {
                    GetEventTypeAndBind((sender as MedButton).Text);
                });
            }
            if (!showAnesAndOper)
            {
                buttonList.Sort(new Comparison<MedButton>(delegate(MedButton p1, MedButton p2)
                {
                    int result = p1.Top.CompareTo(p2.Top);
                    if (result == 0)
                    {
                        result = p1.Left.CompareTo(p2.Left);
                    }
                    return result;
                }));
                btnOperation.Visible = false;
                btnAnes.Visible = false;
                for (int i = buttonList.Count - 1; i > 1; i--)
                {
                    buttonList[i].Left = buttonList[i - 2].Left;
                    buttonList[i].Top = buttonList[i - 2].Top;
                }
                btnAnes.Parent.Height = buttonList[buttonList.Count - 1].Bottom + 4;
            }
        }

        private DataTable _anesthesiaEventDictDataTable;
        private decimal _eventNo;

        private static readonly object _itemSelectedEventHandle = new object();
        public event EventHandler ItemSelected
        {
            add
            {
                Events.AddHandler(_itemSelectedEventHandle, value);
            }
            remove
            {
                Events.RemoveHandler(_itemSelectedEventHandle, value);
            }
        }

        private static readonly object _addAnesEventHandle = new object();
        public event EventHandler AddAnes
        {
            add
            {
                Events.AddHandler(_addAnesEventHandle, value);
            }
            remove
            {
                Events.RemoveHandler(_addAnesEventHandle, value);
            }
        }

        private static readonly object _addOperEventHandle = new object();
        public event EventHandler AddOper
        {
            add
            {
                Events.AddHandler(_addOperEventHandle, value);
            }
            remove
            {
                Events.RemoveHandler(_addOperEventHandle, value);
            }
        }

        /// <summary>
        /// 根据事件名称 区别标识
        /// </summary>
        /// <param name="strEventType">事件名称</param>
        private void GetEventTypeAndBind(string strEventType)
        {
            string Item_class = "";
            string Eveattr = "";
            if (_eventNo == 2)
            {
                //if (Globals.CPBEventType.ContainsKey(strEventType))
                //{
                //    Item_class = Globals.CPBEventType[strEventType];
                //}
            }
            else
            {
                //if (strEventType.Equals("诱导"))
                //{
                //    Eveattr = "诱导";
                //}
                //else 
                if (strEventType.Equals("附记项目"))
                {
                    Item_class = "附记项目";
                }
                else
                {
                    KeyPairDictionary<string, string> eventDict = EventTypeHelper.SwitchKeyValue;
                    eventDict.Add("吸入麻药", "2");
                    eventDict.Add("局部麻药", "2");
                    eventDict.Add("静脉麻药", "2");
                    Dictionary<string, string> attrDict = new Dictionary<string, string>();
                    attrDict.Add("吸入麻药", "1");
                    attrDict.Add("局部麻药", "2");
                    attrDict.Add("静脉麻药", "3");
                    attrDict.Add("呼吸", "4");
                    if (eventDict.ContainsKey(strEventType))
                    {
                        Item_class = eventDict[strEventType];
                    }
                    if (attrDict.ContainsKey(strEventType))
                    {
                        Eveattr = attrDict[strEventType];
                    }
                }
            }
            BinddgEventOpen(Item_class, Eveattr);
            if (dgSelect.Rows.Count > 0)
            {
                dgSelect.Focus();
            }
            ITEM_SPEC.Visible = strEventType.Contains("药");
        }

        /// <summary>
        /// 绑定事件选项
        /// </summary>
        private void BinddgEventOpen(string item_class, string evearrt)
        {
            dgSelect.AutoGenerateColumns = false;
            if (_eventNo == 2)
            {
                //_anesthesiaEventDictDataTable = DataHelper.GetCPBEventOpen(item_class);
            }
            else
            {
                //if (evearrt == "诱导" || item_class == "附记项目")
                if (item_class == "附记项目")
                {
                    _anesthesiaEventDictDataTable = DictProxy.GetAnesthesiaEventOpen();
                    //if (evearrt == "诱导")
                    //{
                    //    _anesthesiaEventDictDataTable.DefaultView.RowFilter = "EVENT_ATTR = '诱导'";
                    //}
                    //else
                    {
                        _anesthesiaEventDictDataTable.DefaultView.RowFilter = "EVENT_ATTR_2 = '附记项目'";
                    }
                }
                else
                {
                    if (evearrt == "" && evearrt != "4")
                    {
                        _anesthesiaEventDictDataTable = DictProxy.GetAnesthesiaEventOpen(item_class);
                    }
                    else if (item_class == "9" && evearrt == "4")//9为呼吸
                    {
                        _anesthesiaEventDictDataTable = DictProxy.GetAnesthesiaEventOpenByhuxi();
                    }
                    else
                    {
                        _anesthesiaEventDictDataTable = DictProxy.GetAnesthesiaEventOpen(item_class, evearrt);
                    }
                }
            }

            filtString = "";
            _anesthesiaEventDictDataTable.Columns.Add("keyStr");
            foreach (DataRow row in _anesthesiaEventDictDataTable.Rows)
            {
                if (row["ITEM_NAME"] != System.DBNull.Value)
                {
                    row["keyStr"] = StringManage.GetPYString(row["ITEM_NAME"].ToString());
                }
            }

            dgSelect.DataSource = _anesthesiaEventDictDataTable;
            DataTable dbTest = _anesthesiaEventDictDataTable.DefaultView.ToTable();
            dgSelect.Columns[0].DataPropertyName = "item_class";
            dgSelect.Columns[1].DataPropertyName = "SUPPLIER_NAME";
            dgSelect.Columns[2].DataPropertyName = "perform_speed";
            dgSelect.Columns[3].DataPropertyName = "SPEED_UNITS";
            dgSelect.Columns[4].DataPropertyName = "dosage";
            dgSelect.Columns[5].DataPropertyName = "dosage_units";
            dgSelect.Columns[6].DataPropertyName = "concentration";
            dgSelect.Columns[7].DataPropertyName = "CONCENTRATION_UNITS";
            dgSelect.Columns[8].DataPropertyName = "administrator";
            dgSelect.Columns[9].DataPropertyName = "item_code";
            dgSelect.Columns[10].DataPropertyName = "ITEM_NO";
            dgSelect.Columns[11].DataPropertyName = "ITEM_NAME";//事件名称
            dgSelect.Columns[12].DataPropertyName = "ITEM_SPEC";//规格
        }

        #region dgSelect事件


        /// <summary>
        /// 重画表头
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgSelect_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                GridViewHelper.DataGridViewCellPainting(e);
                if (e.ColumnIndex == 11)
                {
                    e.Graphics.DrawString(filtString, e.CellStyle.Font, Brushes.Red, e.CellBounds.Right -
                        e.Graphics.MeasureString(filtString, e.CellStyle.Font).Width - 2, e.CellBounds.Y);
                }
            }
        }
        private void dgSelect_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dgSelect_CellDoubleClick(sender, null);
            }
        }

        private string filtString = "";
        private void dgSelect_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_anesthesiaEventDictDataTable == null)
                return;

            if (((int)e.KeyChar) == 8)
            {
                if (filtString.Length > 0)
                {
                    filtString = filtString.Remove(filtString.Length - 1);
                }
            }
            else
            {
                filtString += e.KeyChar;
            }
            if (filtString.Length > 0)
            {
                lbFilter.Text = filtString;
            }
            else
            {
                lbFilter.Text = "无过滤字符";
            }
           

             _anesthesiaEventDictDataTable.DefaultView.RowFilter = "keyStr like '%" + filtString + "%'";
            //dataGridView1.Refresh();
        }

        //private bool _isNew = false;
        /// <summary>
        /// 双击事件单元格  添加麻醉事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgSelect_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgSelect.SelectedRows != null && dgSelect.SelectedRows.Count > 0)
            {
                EventHandler itemSelected = Events[_itemSelectedEventHandle] as EventHandler;
                if (itemSelected != null)
                {
                    itemSelected(dgSelect.SelectedRows[0], null);
                }
            }
        }
        #endregion dgSelect事件

        /// <summary>
        /// 麻醉事件分类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, EventArgs e)
        {
            GetEventTypeAndBind((sender as MedButton).Text);
        }

        private void btnAnes_Click(object sender, EventArgs e)
        {
            EventHandler eventHandle = Events[_addAnesEventHandle] as EventHandler;
            if (eventHandle != null)
            {
                eventHandle(sender, e);
            }
        }

        private void btnOperation_Click(object sender, EventArgs e)
        {
            EventHandler eventHandle = Events[_addOperEventHandle] as EventHandler;
            if (eventHandle != null)
            {
                eventHandle(sender, e);
            }
        }

        private void btnDrugInfo_Click(object sender, EventArgs e)
        {
            AcsContent acsContent = new AcsContent();

            string strSearch = "" ;
            if (dgSelect.SelectedRows != null && dgSelect.SelectedRows.Count > 0)
            {
                if (dgSelect.SelectedRows != null && dgSelect.SelectedRows.Count >= 1)
                {
                    if (dgSelect.SelectedRows[0].Cells[11].Value != null)
                    {
                        strSearch = dgSelect.SelectedRows[0].Cells[11].Value.ToString();
                    }
                }
            }


            acsContent.SetContextKeyWords(strSearch);

            Wis.Anes.Custom.DialogHostForm dialogHostForm = new Wis.Anes.Custom.DialogHostForm("临床麻醉知识查询", acsContent.Width, acsContent.Height);
            dialogHostForm.Child = acsContent;
            dialogHostForm.ShowDialog();
        }

        private void AnesthesiaEventDictSelector_Load(object sender, EventArgs e)
        {


            if (ApplicationConfiguration.IsConnACS)
            {
                btnDrugInfo.Visible = true ;
            }
            else
            {
                btnDrugInfo.Visible = false;
            }
        }





    }
}
