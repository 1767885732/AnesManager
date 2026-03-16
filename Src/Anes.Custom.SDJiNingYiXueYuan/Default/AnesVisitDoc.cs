using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.Framework.Documents;
using Wis.Anes.Framework;
using Wis.Anes.DataAccess;
using Wis.Anes.BusinessEntity;
using Wis.Anes.Custom.CustomProject.Framework;
using Wis.Anes.Framework.Controls;
using Wis.Anes.Framework.Doc;

namespace Wis.Anes.Custom.CustomProject.Default
{
    /// <summary>
    /// 麻醉术前访视
    /// </summary>
    public partial class AnesVisitDoc : CustomBaseDoc
    {
        private CustomControl _nnisControl;
        private DateTime _operTime;
        private string _anesMethod;
        public AnesVisitDoc()
        {
            InitializeComponent();
            base.DocKind = DocKind.Default;
            base.ApplyDataTemplate.Visible = true;
            base.SaveDataTemplate.Visible = false;

            this.OnReportViewMouseDown += (control_MouseDown);

        }

        private void control_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip menu = new ContextMenuStrip();
                ToolStripMenuItem item = new ToolStripMenuItem("提取检验数据");
                item.Click += new EventHandler(delegate(object sender1, EventArgs e1)
                {
                    (new SyncDA()).SyncLis(ExtendApplicationContext.Current.PatientContext.PatientID, ExtendApplicationContext.Current.PatientContext.VisitID, new EventHandler(SyncLisCompelete));
                    //SyncLis();
                });
                menu.Items.Add(item);
                menu.Show(Control.MousePosition);
            }
        }
        /// <summary>
        /// 控件创建后,未被UIElementHandler处理前调用的方法
        /// </summary>
        /// <param name="control"></param>
        protected override void OnControlInitalizing(Control control)
        {
            if (control is Panel && control.Parent is Wis.Anes.Framework.Controls.MedReportView)
            {
                control.MouseDown += (control_MouseDown);
            }
            if (control is Panel && control.Name == "Panel2")
            {
                control.MouseDown += (control_MouseDown);
            }
        }
        private void SyncLisCompelete(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;

            Sync.LabQueryDataTable labQuery = (new SyncDA()).GetLabQuery(ExtendApplicationContext.Current.PatientContext.PatientID, ExtendApplicationContext.Current.PatientContext.VisitID);
            if (labQuery != null && labQuery.Count > 0)
            {

                foreach (Wis.Anes.Framework.Controls.MTextBox ctl in GetControls<Wis.Anes.Framework.Controls.MTextBox>())
                {
                    if (!string.IsNullOrEmpty(ctl.LabItemName))
                    {
                        foreach (Sync.LabQueryRow row in labQuery)
                        {
                            if (!string.IsNullOrEmpty(ctl.LabItemType))
                            {
                                if (!row.IsREPORT_ITEM_NAMENull() && !row.IsTEST_CAUSENull() && ctl.LabItemType.Trim().Equals(row.TEST_CAUSE) && ctl.LabItemName.Trim().Equals(row.REPORT_ITEM_NAME))
                                {
                                    ctl.Text = string.IsNullOrEmpty(row.RESULT) ? "" : row.RESULT.Trim();
                                    break;
                                }
                            }
                            else
                            {
                                if (!row.IsREPORT_ITEM_NAMENull() && ctl.LabItemName.Trim().Equals(row.REPORT_ITEM_NAME))
                                {
                                    ctl.Text = string.IsNullOrEmpty(row.RESULT) ? "" : row.RESULT.Trim();
                                    break;
                                }
                            }
                        }
                    }
                }

            }
        }

        protected override void BuildData(Dictionary<string, DataTable> dataSource)
        {
            var operationMaster = DataContext.GetCurrent().GetData("WIS_OPER_MASTER") as AnesInformations.OperationMasterDataTable;
            _operTime = operationMaster[0].SCHEDULED_DATE_TIME;
            _anesMethod = operationMaster[0].ANES_METHOD;

            dataSource["WIS_OPER_MASTER"] = operationMaster;
            dataSource["WIS_PAT_MASTER_INDEX"] = DataContext.GetCurrent().GetData("WIS_PAT_MASTER_INDEX");
            dataSource["WIS_PAT_IN_HOS"] = DataContext.GetCurrent().GetData("WIS_PAT_IN_HOS");
            dataSource["WIS_CUSTOM_DATA"] = DataContext.GetCurrent().GetData("WIS_CUSTOM_DATA");
            dataSource["WIS_ANES_PLAN"] = DataContext.GetCurrent().GetData("WIS_ANES_PLAN");
            dataSource["WIS_ANES_EVENT"] = DataContext.GetCurrent().GetData("WIS_ANES_EVENT");
            //List<MedRichTextBox> mrlist1 = ReportViewer.GetControls<MedRichTextBox>();
            //List<MRichTextBox> mrlist = ReportViewer.GetControls<MRichTextBox>();
            //string usid = ExtendApplicationContext.Current.LoginUserContext.UserID;
            //foreach (MRichTextBox mtext in mrlist)
            //{
            //    if (mtext.Name == "MrtMZXJ")
            //    {
            //        //mtext.DictTableName = "WIS_DICT_ANES_INPUT";
            //        mtext.DictWhereString = "INPUT_CODE='" + usid + "'";
            //        //mtext.DisplayFieldName = "ITEM_NAME";
            //        //mtext.DictValueFieldName = "ITEM_NAME";

            //    }
            //}


            //BindExtubation(dataSource["WIS_ANES_EVENT"]);
        }
        protected override void OnSaveData(Dictionary<string, DataTable> dataSource)
        {
            base.OnSaveData(dataSource);
            CommonDA commonDA = new CommonDA();
            commonDA.Update(dataSource["WIS_OPER_MASTER"], "WIS_OPER_MASTER");
            commonDA.Update(dataSource["WIS_PAT_MASTER_INDEX"], "WIS_PAT_MASTER_INDEX");
            commonDA.Update(dataSource["WIS_CUSTOM_DATA"], "WIS_CUSTOM_DATA");
            commonDA.Update(dataSource["WIS_ANES_PLAN"], "WIS_ANES_PLAN");
        }

        protected override void OnViewBuilded(List<IUIElementHandler> handlers, Dictionary<string, DataTable> dataSources)
        {
            DataTable dataTable = dataSources["WIS_ANES_EVENT"];
            DataTable dataTable1 = dataSources["WIS_CUSTOM_DATA"];

            string value = "";
            DataRow[] dr;
            DataRow[] dr1;
            List<MTextBox> list = ReportViewer.GetControls<MTextBox>();
            //List<MedRichTextBox> mrlist = ReportViewer.GetControls<MedRichTextBox>();

            List<CustomControl> listc = ReportViewer.GetControls<CustomControl>();
            //string usid=ExtendApplicationContext.Current.LoginUserContext.UserID;
            //foreach (MedRichTextBox mtext in mrlist)
            //{
            //    if(mtext.Name== "MrtMZXJ")
            //    {
            //        mtext.DictTableName = "WIS_DICT_ANES_INPUT";
            //        mtext.DictWhereString = "ITEM_CLASS='麻醉总结' and INPUT_CODE='"+ usid + "'";
            //        mtext.DisplayFieldName = "ITEM_NAME";
            //        mtext.DictValueFieldName = "ITEM_NAME";

            //    }
            //}

            //Dictionary<string, List<CustomControl>> _groupCustomControls = new Dictionary<string, List<CustomControl>>();
            List<CustomControl> controls = new List<CustomControl>();
            foreach (var item in listc)
            {
                if (item.Name == "CustomControl1")
                {
                    _nnisControl = item;
                }
                break;
            }

            foreach (MTextBox textBox in list)
            {
               //textBox.DictTableName
                value = "";
                if (textBox.Name.Trim() == "Extubation1")
                {
                    dr = dataTable.Select("ITEM_NAME like '%气管导管%' and ITEM_CLASS='8' and EVENT_NO='0'  ");
                    dr1 = dataTable1.Select("ITEM_NAME='术后随访.拔除时间'");
                    if (dr1.Length > 0)
                    {
                        if (dr1[0]["ITEM_VALUE"].ToString() != "")
                        {
                            value = dr1[0]["ITEM_VALUE"].ToString();
                        }
                        else
                        {
                            if (dr.Length > 0)
                            {
                                value = dr[0]["START_DATE_TIME"].ToString();
                            }
                        }
                    }
                    else
                    {
                        if (dr.Length > 0)
                        {
                            value = dr[0]["START_DATE_TIME"].ToString();
                        }
                    }

                    if (value != "")
                    {
                        textBox.Text = value;
                        _nnisControl.Value += "气管导管,";
                        //foreach (var ctl in _nnisControl.Controls)
                        //{
                        //    if (ctl is CheckBox)
                        //    {
                        //        CheckBox checkBox = ctl as CheckBox;
                        //        if(checkBox.Name== "气管导管")
                        //        {
                        //            checkBox.Checked = true;
                        //        }
                        //    }
                        //}
                        //_nnisControl.Value= "气管导管";
                        //SetControlValue(_groupCustomControls["气管导管"], "气管导管");
                        //controls.Add(_nnisControl["气管导管"]);
                    }
                }
                if (textBox.Name.Trim() == "Extubation2")
                {
                    dr = dataTable.Select("ITEM_NAME like '%动脉置管%' and ITEM_CLASS='8' and EVENT_NO='0'");
                    dr1 = dataTable1.Select("ITEM_NAME='术后随访.拔除时间2'");
                    if (dr1.Length > 0)
                    {
                        if (dr1[0]["ITEM_VALUE"].ToString() != "")
                        {
                            value = dr1[0]["ITEM_VALUE"].ToString();
                        }
                        else
                        {
                            if (dr.Length > 0)
                            {
                                value = dr[0]["START_DATE_TIME"].ToString();
                            }
                        }
                    }
                    else
                    {
                        if (dr.Length > 0)
                        {
                            value = dr[0]["START_DATE_TIME"].ToString();
                        }
                    }
                    if (value != "")
                    {
                        textBox.Text = value;
                        _nnisControl.Value += "动脉置管,";
                    }
                }
                if (textBox.Name.Trim() == "Extubation3")
                {
                    dr = dataTable.Select("ITEM_NAME like '中心静脉置管%' and ITEM_CLASS='8' and EVENT_NO='0'");
                    dr1 = dataTable1.Select("ITEM_NAME='术后随访.拔除时间3'");
                    if (dr1.Length > 0)
                    {
                        if (dr1[0]["ITEM_VALUE"].ToString() != "")
                        {
                            value = dr1[0]["ITEM_VALUE"].ToString();
                        }
                        else
                        {
                            if (dr.Length > 0)
                            {
                                value = dr[0]["START_DATE_TIME"].ToString();
                            }
                        }
                    }
                    else
                    {
                        if (dr.Length > 0)
                        {
                            value = dr[0]["START_DATE_TIME"].ToString();
                        }
                    }

                    if (value != "")
                    {
                        textBox.Text = value;
                        _nnisControl.Value += "中心静脉置管,";
                    }
                }
                if (textBox.Name.Trim() == "Extubation4")
                {
                    dr = dataTable.Select("ITEM_NAME like '硬膜外导管%' and ITEM_CLASS='8' and EVENT_NO='0'");
                    dr1 = dataTable1.Select("ITEM_NAME='术后随访.拔除时间4'");
                    if (dr1.Length > 0)
                    {
                        if (dr1[0]["ITEM_VALUE"].ToString() != "")
                        {
                            value = dr1[0]["ITEM_VALUE"].ToString();
                        }
                        else
                        {
                            if (dr.Length > 0)
                            {
                                value = dr[0]["START_DATE_TIME"].ToString();
                            }
                        }
                    }
                    else
                    {
                        if (dr.Length > 0)
                        {
                            value = dr[0]["START_DATE_TIME"].ToString();
                        }
                    }


                    if (value != "")
                    {
                        textBox.Text = value;
                        _nnisControl.Value += "硬膜外导管,";
                    }
                }
                if (textBox.Name.Trim() == "Extubation5")
                {
                    dr = dataTable.Select("ITEM_NAME like '喉罩拔除%' and ITEM_CLASS='8' and EVENT_NO='0'");
                    dr1 = dataTable1.Select("ITEM_NAME='术后随访.拔除时间5'");
                    if (dr1.Length > 0)
                    {
                        if (dr1[0]["ITEM_VALUE"].ToString() != "")
                        {
                            value = dr1[0]["ITEM_VALUE"].ToString();
                        }
                        else
                        {
                            if (dr.Length > 0)
                            {
                                value = dr[0]["START_DATE_TIME"].ToString();
                            }
                        }
                    }
                    else
                    {
                        if (dr.Length > 0)
                        {
                            value = dr[0]["START_DATE_TIME"].ToString();
                        }
                    }


                    if (value != "")
                    {
                        textBox.Text = value;
                        _nnisControl.Value += "喉罩,";
                    }
                }
                if (textBox.Name.Trim() == "Extubation6")
                {
                    dr = dataTable.Select("ITEM_NAME like '镇痛泵%' and EVENT_NO='0'");
                    dr1 = dataTable1.Select("ITEM_NAME='术后随访.拔除时间6'");
                    if (dr1.Length > 0)
                    {
                        if (dr1[0]["ITEM_VALUE"].ToString() != "")
                        {
                            value = dr1[0]["ITEM_VALUE"].ToString();
                        }
                        else
                        {
                            if (dr.Length > 0)
                            {
                                value = dr[0]["START_DATE_TIME"].ToString();
                            }
                        }
                    }
                    else
                    {
                        if (dr.Length > 0)
                        {
                            value = dr[0]["START_DATE_TIME"].ToString();
                        }
                    }


                    if (value != "")
                    {
                        textBox.Text = value;
                        _nnisControl.Value += "镇痛泵,";
                        //_nnisControl.DefaultItems.Add(new DefualtItem() { "镇痛泵","镇痛泵",0 }) ;
                    }

                }

            }
            ShowAnesDate();
        }

        private void ShowAnesDate()
        {
            //手术日期_operTime BuildData数据加载时赋值
            //判断日期小于2022.5.11的麻醉方法显示WIS_OPER_MASTER 中的ANES_METHOD
            if (DateTime.Compare(_operTime, DateTime.Parse("2022-05-11")) < 0)
            {
                List<MTextBox> list = ReportViewer.GetControls<MTextBox>();
                foreach (MTextBox textBox in list)
                {
                    if (textBox.Name.Trim() == "MTextBoxAnesMethod")
                    {
                        textBox.Text = _anesMethod;
                        textBox.SelectedData = _anesMethod;
                    }
                }
            }

        }
    }
}
