using System;
using System.Collections.Generic;
using System.Text;
using Wis.Anes.BusinessEntity;
using System.Data;
using Wis.Anes.Framework.Controls;
using Wis.Anes.Framework.Doc;
using System.Windows.Forms;

namespace Wis.Anes.Custom.CustomProject.AnesDocHandlers
{
    public class CustomTextBoxHandler : Wis.Anes.Framework.Documents.DefaultHandlers.TextBoxHandler
    {
        private AnesInformations.AnesthesiaEventDataTable _allEventTable = null;
        private MTextBox niaoliangTextBox = null;
        private MTextBox ruliangTextBox = null;
        private MTextBox chuliangTextBox = null;

        public override void BindDataToUI(Wis.Anes.Framework.Controls.MTextBox control, Dictionary<string, System.Data.DataTable> dataSources)
        {
            base.BindDataToUI(control, dataSources);
            if (base.DataSource.ContainsKey("AnesAllEvent"))
            {
                _allEventTable = base.DataSource["AnesAllEvent"] as AnesInformations.AnesthesiaEventDataTable;
            }

            if (ruliangTextBox == null || niaoliangTextBox == null || chuliangTextBox==null)
            {
                foreach (IUIElementHandler handler in MedicalPaperUIElementHandlers)
                {
                    if (handler is CustomTextBoxHandler && handler.GetAllControls != null)
                    {
                        foreach (Control ctl in handler.GetAllControls)
                        {
                            if (ctl is MTextBox)
                            {
                                if (!string.IsNullOrEmpty((ctl as MTextBox).SummaryName) && (ctl as MTextBox).SummaryName == "总入量")
                                {
                                    ruliangTextBox = (ctl as MTextBox);
                                }
                                else if (!string.IsNullOrEmpty((ctl as MTextBox).SummaryName) && (ctl as MTextBox).SummaryName == "尿量")
                                {
                                    niaoliangTextBox = (ctl as MTextBox);
                                }
                                else if (!string.IsNullOrEmpty((ctl as MTextBox).SummaryName) && (ctl as MTextBox).SummaryName == "总出量")
                                {
                                    chuliangTextBox = (ctl as MTextBox);
                                }
                            }
                        }
                    }
                }
            }

            if (!string.IsNullOrEmpty(control.SummaryName)&&string.IsNullOrEmpty(control.Text.Trim()))
            {
                if (_allEventTable != null && _allEventTable.Count > 0)
                {
                    if (control.SummaryName == "总入量")
                    {
                        DataRow[] rows = _allEventTable.Select("ITEM_CLASS='3' OR ITEM_CLASS='B'");
                        double d = 0;
                        foreach (DataRow prow in rows)
                        {
                            if (prow["DOSAGE"] != null && prow["DOSAGE"] != DBNull.Value && prow["DOSAGE_UNITS"].ToString().ToLower().Equals("ml"))
                            {
                                d += double.Parse(prow["DOSAGE"].ToString());
                            }
                            else if (prow["DOSAGE"] != null && prow["DOSAGE"] != DBNull.Value && prow["DOSAGE_UNITS"].ToString().ToLower().Equals("l"))
                            {
                                d += 1000 * (double.Parse(prow["DOSAGE"].ToString()));
                            }
                        }
                        if (d > 0)
                        {
                            control.SetData(d);
                        }
                    }
                    else if (control.SummaryName == "总出量")
                    {
                        DataRow[] rows = _allEventTable.Select("ITEM_CLASS='D'");
                        double d = 0;
                        foreach (DataRow prow in rows)
                        {
                            if (prow["DOSAGE"] != null && prow["DOSAGE"] != DBNull.Value && prow["DOSAGE_UNITS"].ToString().ToLower().Equals("ml"))
                            {
                                d += double.Parse(prow["DOSAGE"].ToString());
                            }
                            else if (prow["DOSAGE"] != null && prow["DOSAGE"] != DBNull.Value && prow["DOSAGE_UNITS"].ToString().ToLower().Equals("l"))
                            {
                                d += 1000 * (double.Parse(prow["DOSAGE"].ToString()));
                            }
                        }
                        if (d > 0)
                        {
                            control.SetData(d);
                        }
                    }
                    else if (control.SummaryName == "尿量")
                    {
                        DataRow[] rows = _allEventTable.Select("ITEM_CLASS='D' AND ITEM_NAME LIKE '%尿量%'");
                        double d = 0;
                        foreach (DataRow prow in rows)
                        {
                            if (prow["DOSAGE"] != null && prow["DOSAGE"] != DBNull.Value && prow["DOSAGE_UNITS"].ToString().ToLower().Equals("ml"))
                            {
                                d += double.Parse(prow["DOSAGE"].ToString());
                            }
                            else if (prow["DOSAGE"] != null && prow["DOSAGE"] != DBNull.Value && prow["DOSAGE_UNITS"].ToString().ToLower().Equals("l"))
                            {
                                d += 1000 * (double.Parse(prow["DOSAGE"].ToString()));
                            }
                        }
                        if (d > 0)
                        {
                            control.SetData(d);
                        }
                    }
                }
            }
        }

        public override void ControlSetting(Wis.Anes.Framework.Controls.MTextBox control)
        {
            base.ControlSetting(control);
            if (!string.IsNullOrEmpty(control.SummaryName))
            {
                control.DoubleClick -= new EventHandler(control_DoubleClick);
                control.DoubleClick += new EventHandler(control_DoubleClick);
            }
        }

        private void control_DoubleClick(object sender, EventArgs e)
        {
            MTextBox control = sender as MTextBox;
            if (_allEventTable != null && _allEventTable.Count > 0)
            {
                if (control.SummaryName == "总入量")
                {
                    DataRow[] rows = _allEventTable.Select("ITEM_CLASS='3' OR ITEM_CLASS='B'");
                    double d = 0;
                    foreach (DataRow prow in rows)
                    {
                        if (prow["DOSAGE"] != null && prow["DOSAGE"] != DBNull.Value && prow["DOSAGE_UNITS"].ToString().ToLower().Equals("ml"))
                        {
                            d += double.Parse(prow["DOSAGE"].ToString());
                        }
                        else if (prow["DOSAGE"] != null && prow["DOSAGE"] != DBNull.Value && prow["DOSAGE_UNITS"].ToString().ToLower().Equals("l"))
                        {
                            d += 1000 * (double.Parse(prow["DOSAGE"].ToString()));
                        }
                    }
                    if (d > 0)
                    {
                        control.SetData(d);
                    }
                    else
                    {
                        control.SetData("");
                    }
                }
                else if (control.SummaryName == "总出量")
                {
                    DataRow[] rows = _allEventTable.Select("ITEM_CLASS='D'");
                    double d = 0;
                    foreach (DataRow prow in rows)
                    {
                        if (prow["DOSAGE"] != null && prow["DOSAGE"] != DBNull.Value && prow["DOSAGE_UNITS"].ToString().ToLower().Equals("ml"))
                        {
                            d += double.Parse(prow["DOSAGE"].ToString());
                        }
                        else if (prow["DOSAGE"] != null && prow["DOSAGE"] != DBNull.Value && prow["DOSAGE_UNITS"].ToString().ToLower().Equals("l"))
                        {
                            d += 1000 * (double.Parse(prow["DOSAGE"].ToString()));
                        }
                    }
                    if (d > 0)
                    {
                        control.SetData(d);
                    }
                    else
                    {
                        control.SetData("");
                    }
                }
                else if (control.SummaryName == "尿量")
                {
                    DataRow[] rows = _allEventTable.Select("ITEM_CLASS='D' AND ITEM_NAME LIKE '%尿量%'");
                    double d = 0;
                    foreach (DataRow prow in rows)
                    {
                        if (prow["DOSAGE"] != null && prow["DOSAGE"] != DBNull.Value && prow["DOSAGE_UNITS"].ToString().ToLower().Equals("ml"))
                        {
                            d += double.Parse(prow["DOSAGE"].ToString());
                        }
                        else if (prow["DOSAGE"] != null && prow["DOSAGE"] != DBNull.Value && prow["DOSAGE_UNITS"].ToString().ToLower().Equals("l"))
                        {
                            d += 1000 * (double.Parse(prow["DOSAGE"].ToString()));
                        }
                    }
                    if (d > 0)
                    {
                        control.SetData(d);
                    }
                    else
                    {
                        control.SetData("");
                    }
                }
            }
        }
    }
}
