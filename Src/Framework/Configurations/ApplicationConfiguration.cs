using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Wis.Anes.DataAccess;
using System.Configuration;
using System.Drawing;
using Wis.Anes.Framework.Controls.Base;
using Wis.Anes.BusinessEntity;
using Wis.Anes.Framework.Utilities;
using System.Windows.Forms;
using System.IO;

namespace Wis.Anes.Framework.Configurations
{
    public partial class ApplicationConfiguration
    {
        public class MedicalDocucementElement
        {
            private string _key;
            /// <summary>
            /// 医疗文书的Key
            /// </summary>
            public string Key
            {
                get
                {
                    return _key;
                }
                set
                {
                    _key = value;
                }
            }

            private string _caption;
            /// <summary>
            /// 医疗文书的Key
            /// </summary>
            public string Caption
            {
                get
                {
                    return _caption;
                }
                set
                {
                    _caption = value;
                }
            }

            private string _path;
            /// <summary>
            ///模版文件相对路径
            /// </summary>
            public string Path
            {
                get
                {
                    return _path;
                }
                set
                {
                    _path = value;
                }
            }

            private string _type;
            /// <summary>
            ///医疗文书类型
            /// </summary>
            public string Type
            {
                get
                {
                    return _type;
                }
                set
                {
                    _type = value;
                }
            }

            public override string ToString()
            {
                return Caption + "," + Key + "," + Path + "," + Type;
            }

            public void FromList(List<string> list)
            {
                if (list.Count == 4 || list.Count == 5)
                {
                    Caption = list[0];
                    Key = list[1];
                    Path = list[2];
                    if (list.Count == 4)
                    {
                        Type = list[3];
                    }
                    else
                    {
                        Type = list[3] + "," + list[4];
                    }
                }
            }
        }

        static Dictionary<string, object> _configurCache = new Dictionary<string, object>();

        public static string GetFromConfigTable(string key)
        {
            BusinessEntity.Configuations.ConfigTableDataTable configTable = ExtendApplicationContext.Current.ConfigTable;
            if (!string.IsNullOrEmpty(key) && configTable != null)
            {
                BusinessEntity.Configuations.ConfigTableRow configRow = configTable.FindByPara_Key(key);
                if (configRow != null && configRow.Para_Value[0] != 0)
                {
                    string ret = StringHelper.Arr2Str(configRow.Para_Value);
                    if (ret == "�") ret = string.Empty;
                    return ret;
                }
                else
                {
                    return string.Empty;
                }
            }
            return null;
        }

        public static void ModifyConfigTable(string key, string value)
        {
            if (!string.IsNullOrEmpty(key) && ExtendApplicationContext.Current.ConfigTable != null)
            {
                BusinessEntity.Configuations.ConfigTableRow configRow = ExtendApplicationContext.Current.ConfigTable.FindByPara_Key(key);
                if (configRow == null)
                {
                    configRow = ExtendApplicationContext.Current.ConfigTable.NewConfigTableRow();
                    configRow.Para_Key = key;
                    ExtendApplicationContext.Current.ConfigTable.AddConfigTableRow(configRow);
                }
                if (string.IsNullOrEmpty(value))
                {
                    configRow.Para_Value = new byte[] { 0 };
                }
                else
                {
                    configRow.Para_Value = StringHelper.Str2Arr(value);
                }
            }
        }

        public static string GetStringDocumentTable(BusinessEntity.Configuations.DocumentDataTable dataTable, string documentName, string documentPath)
        {
            if (dataTable != null)
            {
                BusinessEntity.Configuations.DocumentRow row = dataTable.FindByDOCUMENTNAMEDOCUMENTPATH(documentName, documentPath);
                if (row != null && row.DOCUMENTCONTENT[0] != 0)
                {
                    string ret = StringHelper.Arr2Str(row.DOCUMENTCONTENT);
                    if (ret == "�") ret = string.Empty;
                    return ret;
                }
                else
                {
                    return string.Empty;
                }
            }
            return null;
        }

        public static DataTable GetDataTableDocumentTable(BusinessEntity.Configuations.DocumentDataTable dataTable, string documentName, string documentPath)
        {
            DataTable tagDataTable = null;
            if (dataTable != null)
            {
                BusinessEntity.Configuations.DocumentRow row = dataTable.FindByDOCUMENTNAMEDOCUMENTPATH(documentName, documentPath);
                if (row != null && row.DOCUMENTCONTENT[0] != 0)
                {
                    MemoryStream stream = new MemoryStream(row.DOCUMENTCONTENT);
                    stream.Position = 0;
                    DataSet ds = new DataSet();
                    ds.ReadXml(stream);
                    if (ds.Tables.Count > 0)
                    {
                        tagDataTable = ds.Tables[0];
                    }
                    ds.Dispose();
                    stream.Close();
                    stream.Dispose();
                }
            }
            return tagDataTable;
        }

        public static void ModifyDocumentTable(BusinessEntity.Configuations.DocumentDataTable dataTable, string documentName, string documentPath, DataTable souDataTable)
        {
            if (dataTable != null)
            {
                BusinessEntity.Configuations.DocumentRow row = dataTable.FindByDOCUMENTNAMEDOCUMENTPATH(documentName, documentPath);
                if (row == null)
                {
                    row = dataTable.NewDocumentRow();
                    row.DOCUMENTNAME = documentName;
                    row.DOCUMENTPATH = documentPath;
                    dataTable.AddDocumentRow(row);
                }
                if (souDataTable == null)
                {
                    row.DOCUMENTCONTENT = new byte[] { 0 };
                }
                else
                {
                    MemoryStream stream = new MemoryStream();
                    souDataTable.WriteXml(stream);
                    stream.Position = 0;
                    row.DOCUMENTCONTENT = FileHelper.StreamToBytes(stream);
                    stream.Close();
                    stream.Dispose();
                }
            }
        }

        public static void ModifyDocumentTable(BusinessEntity.Configuations.DocumentDataTable dataTable, string documentName, string documentPath, string value)
        {
            if (dataTable != null)
            {
                BusinessEntity.Configuations.DocumentRow row = dataTable.FindByDOCUMENTNAMEDOCUMENTPATH(documentName, documentPath);
                if (row == null)
                {
                    row = dataTable.NewDocumentRow();
                    row.DOCUMENTNAME = documentName;
                    row.DOCUMENTPATH = documentPath;
                    dataTable.AddDocumentRow(row);
                }
                if (string.IsNullOrEmpty(value))
                {
                    row.DOCUMENTCONTENT = new byte[] { 0 };
                }
                else
                {
                    row.DOCUMENTCONTENT = StringHelper.Str2Arr(value);
                }
            }
        }

        public static int DrugShow
        {
            get
            {
                string key = "DrugShow";

                if (_configurCache.ContainsKey(key))
                    return Convert.ToInt32(_configurCache[key]);

                string s = GetFromConfigTable(key);
                if (string.IsNullOrEmpty(s))
                {
                    s = ConfigurationManager.AppSettings[key];
                }
                int ret = 0;
                if (!int.TryParse(s, out ret))
                {
                    ret = 0;
                }

                if (!_configurCache.ContainsKey(key))
                    _configurCache.Add(key, ret);

                return ret;
            }
            set
            {
                string key = "DrugShow";
                ModifyConfigTable(key, value.ToString());
                if (_configurCache.ContainsKey(key))
                    _configurCache[key] = value;
            }
        }

        public static int DrugShowLegend
        {
            get
            {
                string key = "DrugShowLegend";

                if (_configurCache.ContainsKey(key))
                    return Convert.ToInt32(_configurCache[key]);

                string s = GetFromConfigTable(key);
                if (string.IsNullOrEmpty(s))
                {
                    s = ConfigurationManager.AppSettings[key];
                }
                int ret = 0;
                if (!int.TryParse(s, out ret))
                {
                    ret = 0;
                }

                if (!_configurCache.ContainsKey(key))
                    _configurCache.Add(key, ret);

                return ret;
            }
            set
            {
                string key = "DrugShowLegend";
                ModifyConfigTable(key, value.ToString());
                if (_configurCache.ContainsKey(key))
                    _configurCache[key] = value;
            }
        }

        public static int ProLonged
        {
            get
            {
                string key = "ProLonged";
                if (_configurCache.ContainsKey(key))
                    return Convert.ToInt32(_configurCache[key]);

                string s = GetFromConfigTable(key);
                if (string.IsNullOrEmpty(s))
                {
                    s = ConfigurationManager.AppSettings[key];
                }
                int ret = 0;
                if (!int.TryParse(s, out ret))
                {
                    ret = 0;
                }

                if (!_configurCache.ContainsKey(key))
                    _configurCache.Add(key, ret);

                return ret;
            }
            set
            {
                string key = "ProLonged";
                ModifyConfigTable(key, value.ToString());
                if (_configurCache.ContainsKey(key))
                    _configurCache[key] = value;
            }

        }

        public static int ProLongedLegend
        {
            get
            {
                string key = "ProLongedLegend";
                if (_configurCache.ContainsKey(key))
                    return Convert.ToInt32(_configurCache[key]);

                string s = GetFromConfigTable(key);
                if (string.IsNullOrEmpty(s))
                {
                    s = ConfigurationManager.AppSettings[key];
                }
                int ret = 0;
                if (!int.TryParse(s, out ret))
                {
                    ret = 0;
                }

                if (!_configurCache.ContainsKey(key))
                    _configurCache.Add(key, ret);

                return ret;
            }
            set
            {
                string key = "ProLongedLegend";
                ModifyConfigTable(key, value.ToString());
                if (_configurCache.ContainsKey(key))
                    _configurCache[key] = value;
            }

        }

        public static string GetAppSetting(string key)
        {
            return System.Configuration.ConfigurationManager.AppSettings[key];
        }

        public static Color YouDaoColor
        {
            get
            {
                string text = GetAppSetting("YouDaoColor");
                if (string.IsNullOrEmpty(text))
                {
                    text = "Brown";
                }
                return AssemblyHelper.ColorFromString(text);
            }
            set
            {
                SaveAppConfig("YouDaoColor", value.Name);
            }
        }
        /// <summary>
        /// 保存设置
        /// </summary>
        /// <param name="key">主键</param>
        /// <param name="value">对应值</param>
        public static void SaveAppConfig(string key, string value)
        {
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove(key);
            config.AppSettings.Settings.Add(key, value);
            config.Save();
        }
        /// <summary>
        /// 合并所有采集数据
        /// </summary>
        public static bool MergeMonitorData
        {
            get
            {
                string key = "MergeMonitorData";
                if (_configurCache.ContainsKey(key))
                    return Convert.ToBoolean(_configurCache[key]);

                string s = GetFromConfigTable(key);
                //if (string.IsNullOrEmpty(s))
                //{
                //    s = ConfigurationManager.AppSettings[key];
                //}

                bool result;
                if (!bool.TryParse(s, out result))
                {
                    result = false;
                }

                if (!_configurCache.ContainsKey(key))
                    _configurCache.Add(key, result);

                return result;
            }
            set
            {
                string key = "MergeMonitorData";
                ModifyConfigTable(key, value.ToString());
                if (_configurCache.ContainsKey(key))
                    _configurCache[key] = value;
            }
        }
        //public static string PermissionProvider
        // {
        //     get
        //     {
        //         string text = ConfigurationHelper.Read("PermissionProvider");
        //         return text;
        //     }
        //     set
        //     {
        //         ConfigurationHelper.Save("PermissionProvider", value.ToString());
        //     }
        // }
        public static string PermissionProvider
        {
            get
            {
                string key = "PermissionProvider";
                string text = GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                return text;
            }
            set
            {
                ModifyConfigTable("PermissionProvider", value);
                //ConfigurationHelper.Save("CustomSettingProvider", value.ToString());
            }
        }

        public static string CustomDllName
        {
            get
            {
                string key = "CustomDllName";
                string text = GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                if (string.IsNullOrEmpty(text))
                {
                    text = "";
                }
                return text;
            }
            set
            {
                ModifyConfigTable("CustomDllName", value);
                //ConfigurationHelper.Save("CustomSettingProvider", value.ToString());
            }
        }

        public static string CustomSettingProvider
        {
            get
            {
                string key = "CustomSettingProvider";
                string text = GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                return text;
            }
            set
            {
                ModifyConfigTable("CustomSettingProvider", value);
            }
        }

        public static string PostPDF_Names
        {
            get
            {
                string key = "PostPDF_Names";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }

                return text == null ? string.Empty : text;
            }
            set
            {
                string key = "PostPDF_Names";
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }


        /// <summary>
        /// PDFLocalUrl
        /// </summary>
        public static string PDFLocalUrl
        {
            get
            {
                string key = "PDFLocalUrl";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                if (!string.IsNullOrEmpty(text))
                {
                    return text;
                }
                else
                {
                    return @"D:\PDF\";
                }
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("PDFLocalUrl", value);
            }
        }

        /// <summary>
        /// 打印纸张
        /// </summary>
        public static string PDFServerUrl
        {
            get
            {
                string key = "PDFServerUrl";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                if (!string.IsNullOrEmpty(text))
                {
                    return text;
                }
                else
                {
                    return "192.168.0.241";
                }
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("PDFServerUrl", value);
            }
        }
        public static bool IsDeleteAfterCommitDoc
        {
            get
            {
                string key = "IsDeleteAfterCommitDoc";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                bool result;
                if (bool.TryParse(text, out result))
                {
                    return result;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("IsDeleteAfterCommitDoc", value.ToString());
            }
        }

        /// <summary>
        /// 要集中打印的文书配置
        /// </summary>
        public static string multiPrintNames
        {
            get
            {
                string key = "multiPrintNames";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                return text;
            }
            set
            {
                string key = "multiPrintNames";
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        /// <summary>
        /// 打印纸张
        /// </summary>
        public static string PrintPageName
        {
            get
            {
                string key = "PrintPageName";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                if (!string.IsNullOrEmpty(text))
                {
                    return text;
                }
                else
                {
                    return "A4";
                }
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("PrintPageName", value);
            }
        }

        /// <summary>
        /// 打印纸张 长度
        /// </summary>
        public static float PrintPaperHeight
        {
            get
            {
                string key = "PrintPaperHeight";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                if (!string.IsNullOrEmpty(text))
                {
                    float ret = 0;
                    if (!float.TryParse(text, out ret))
                    {
                        ret = 29.7f;
                    }
                    return ret;
                }
                else
                {
                    return 29.7f;
                }
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("PrintPaperHeight", value.ToString());
            }
        }

        /// <summary>
        /// 打印纸张  宽度
        /// </summary>
        public static float PrintPaperWidth
        {
            get
            {
                string key = "PrintPaperWidth";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                if (!string.IsNullOrEmpty(text))
                {
                    float ret = 0;
                    if (!float.TryParse(text, out ret))
                    {
                        ret = 21.0f;
                    }
                    return ret;
                }
                else
                {
                    return 21.0f;
                }
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("PrintPaperWidth", value.ToString());
            }
        }
        /// <summary>
        /// 打印纸张  左侧预留
        /// </summary>
        public static float PaperLeftOff
        {
            get
            {
                string key = "PaperLeftOff";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                if (!string.IsNullOrEmpty(text))
                {
                    float ret = 0.5f;
                    if (!float.TryParse(text, out ret))
                    {
                        ret = 0.5f;
                    }
                    return ret;
                }
                else
                {
                    return 0.5f;
                }
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("PaperLeftOff", value.ToString());
            }
        }
        /// <summary>
        /// 打印纸张 上方预留
        /// </summary>
        public static float PaperTopOff
        {
            get
            {
                string key = "PaperTopOff";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                if (!string.IsNullOrEmpty(text))
                {
                    float ret = 1.0f;
                    if (!float.TryParse(text, out ret))
                    {
                        ret = 1.0f;
                    }
                    return ret;
                }
                else
                {
                    return 1.0f;
                }
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("PaperTopOff", value.ToString());
            }
        }



        /// <summary>
        /// 文书完整性检查清单
        /// </summary>
        public static string DocNameCheckList
        {
            get
            {
                string key = "DocNameCheckList";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                return text;
            }
            set
            {
                string key = "DocNameCheckList";
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }



        /// <summary>
        /// 手术科室代码
        /// </summary>
        public static string OpertionDeptCode
        {
            get
            {
                string key = "OpertionDeptCode";
                if (_configurCache.ContainsKey(key))
                    return _configurCache[key].ToString();

                string text = ConfigurationManager.AppSettings[key];
                if (string.IsNullOrEmpty(text))
                {
                    text = GetFromConfigTable(key);
                }
                if (!string.IsNullOrEmpty(text))
                {
                    _configurCache[key] = text;
                    return text;
                }
                else
                {
                    _configurCache[key] = "10003300";
                    return "10003300";
                }
            }
            set
            {
                //ModifyConfigTable("OpertionDeptCode", value);
                string key = "OpertionDeptCode";
                if (_configurCache.ContainsKey(key))
                    _configurCache[key] = value;
                ConfigurationHelper.Save("OpertionDeptCode", value);
            }
        }

        /// <summary>
        /// 麻醉单每页显示的小时数
        /// </summary>
        public static int AnesDocPageHours
        {
            get
            {
                string key = "AnesDocPageHours";
                if (_configurCache.ContainsKey(key))
                    return Convert.ToInt32(_configurCache[key].ToString());

                int text = Convert.ToInt32(ConfigurationManager.AppSettings[key]);
                if (string.IsNullOrEmpty(text.ToString()))
                {
                    text = Convert.ToInt32(GetFromConfigTable(key));
                }
                if (!string.IsNullOrEmpty(text.ToString()))
                {
                    _configurCache[key] = text;
                    return text;
                }
                else
                {
                    _configurCache[key] = 5;
                    return 5;
                }
            }
            set
            {
                //ModifyConfigTable("OpertionDeptCode", value);
                string key = "AnesDocPageHours";
                if (_configurCache.ContainsKey(key))
                    _configurCache[key] = value;
                ConfigurationHelper.Save("AnesDocPageHours", value.ToString());
            }
        }

        /// <summary>
        /// 默认体征项目
        /// </summary>
        public static string DefaultMonitorItems
        {
            get
            {
                string key = "DefaultMonitorItems";
                if (_configurCache.ContainsKey(key))
                    return _configurCache[key].ToString();

                string text = ConfigurationManager.AppSettings[key];
                if (string.IsNullOrEmpty(text))
                {
                    text = GetFromConfigTable(key);
                }
                if (!string.IsNullOrEmpty(text))
                {
                    _configurCache[key] = text;
                    return text;
                }
                else
                {
                    _configurCache[key] = "";
                    return "";
                }
            }
            set
            {
                //ModifyConfigTable("OpertionDeptCode", value);
                string key = "DefaultMonitorItems";
                if (_configurCache.ContainsKey(key))
                    _configurCache[key] = value;
                ConfigurationHelper.Save("DefaultMonitorItems", value);
            }
        }
        /// <summary>
        /// 手术进程术中清单
        /// </summary>
        public static string OpertionProgressInOperationList
        {
            get
            {
                string key = "OpertionProgressInOperationList";
                string text = GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = "切皮,探查,手术,缝合,缝皮";
                }
                return text;
            }
            set
            {
                ModifyConfigTable("OpertionProgressInOperationList", value);
            }
        }

        /// <summary>
        /// 手术进程清单
        /// </summary>
        public static string OpertionProgressList
        {
            get
            {
                string key = "OpertionProgressList";
                string text = GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = "入手术室,麻醉开始,手术开始,术中,手术结束,麻醉结束,出手术室";
                }
                return text;
            }
            set
            {
                ModifyConfigTable("OpertionProgressList", value);
            }
        }


        /// <summary>
        /// .麻醉单区域
        /// </summary>
        private static List<Control> _bands = new List<Control>();



        #region 属性




        public static Color PatientSelectBorderColor
        {
            get
            {
                string text = ConfigurationHelper.Read("PatientSelectBorderColor");
                if (string.IsNullOrEmpty(text))
                {
                    return Color.FromArgb(105, 97, 84);
                }
                return AssemblyHelper.ColorFromString(text);

            }
            set
            {
                ConfigurationHelper.Save("PatientSelectBorderColor", value.Name);
            }
        }

        public static Color PatientSelectedBackColor2
        {
            get
            {
                string text = ConfigurationHelper.Read("PatientSelectedBackColor2");
                if (string.IsNullOrEmpty(text))
                {
                    return Color.FromArgb(170, 190, 196);
                }
                return AssemblyHelper.ColorFromString(text);

            }
            set
            {
                ConfigurationHelper.Save("PatientSelectedBackColor2", value.Name);
            }
        }

        public static Color PatientSelectedBackColor
        {
            get
            {
                string text = ConfigurationHelper.Read("PatientSelectedBackColor");
                if (string.IsNullOrEmpty(text))
                {
                    return Color.FromArgb(216, 233, 249);
                }
                return AssemblyHelper.ColorFromString(text);

            }
            set
            {
                ConfigurationHelper.Save("PatientSelectedBackColor", value.Name);
            }
        }

        public static Color PatientNormalBackColor
        {
            get
            {
                string text = ConfigurationHelper.Read("PatientNormalBackColor");
                if (string.IsNullOrEmpty(text))
                {
                    return Color.FromArgb(216, 233, 249);
                }
                return AssemblyHelper.ColorFromString(text);

            }
            set
            {
                ConfigurationHelper.Save("PatientNormalBackColor", value.Name);
            }
        }

        public static Color PatientNormalBorderColor
        {
            get
            {
                string text = ConfigurationHelper.Read("PatientNormalBorderColor");
                if (string.IsNullOrEmpty(text))
                {
                    return Color.FromArgb(0, 24, 120);
                }
                return AssemblyHelper.ColorFromString(text);

            }
            set
            {
                ConfigurationHelper.Save("PatientNormalBorderColor", value.Name);
            }
        }

        public static Color SelectPatientTopColor
        {
            get
            {
                string text = ConfigurationHelper.Read("SelectPatientTopColor");
                if (string.IsNullOrEmpty(text))
                {
                    return Color.White;
                }
                return AssemblyHelper.ColorFromString(text);

            }
            set
            {
                ConfigurationHelper.Save("SelectPatientTopColor", value.Name);
            }
        }

        public static Color SelectPatientBorderColor
        {
            get
            {
                string text = ConfigurationHelper.Read("SelectPatientBorderColor");
                if (string.IsNullOrEmpty(text))
                {
                    return Color.FromArgb(0, 24, 120);
                }
                return AssemblyHelper.ColorFromString(text);

            }
            set
            {
                ConfigurationHelper.Save("SelectPatientBorderColor", value.Name);
            }
        }

        public static Color SelectPatientBackColor
        {
            get
            {
                string text = ConfigurationHelper.Read("SelectPatientBackColor");
                if (string.IsNullOrEmpty(text))
                {
                    return Color.FromArgb(29, 117, 181);
                }
                return AssemblyHelper.ColorFromString(text);

            }
            set
            {
                ConfigurationHelper.Save("SelectPatientBackColor", value.Name);
            }
        }

        public static Color ColorMainFormBackColor
        {
            get
            {
                string text = ConfigurationHelper.Read("ColorMainFormBackColor");
                if (string.IsNullOrEmpty(text))
                {
                    return Color.FromArgb(29, 117, 181);
                }
                return AssemblyHelper.ColorFromString(text);

            }
            set
            {
                ConfigurationHelper.Save("ColorMainFormBackColor", value.Name);
            }
        }

        public static Color ColorMainFormStatusBackColor
        {
            get
            {
                string text = ConfigurationHelper.Read("ColorMainFormStatusBackColor");
                if (string.IsNullOrEmpty(text))
                {
                    return Color.FromArgb(29, 117, 181);
                }
                return AssemblyHelper.ColorFromString(text);

            }
            set
            {
                ConfigurationHelper.Save("ColorMainFormStatusBackColor", value.Name);
            }
        }

        public static Color XtraBackColor
        {
            get
            {
                string text = ConfigurationHelper.Read("XtraBackColor");
                if (string.IsNullOrEmpty(text))
                {
                    return Color.FromArgb(142, 193, 238);
                }
                return AssemblyHelper.ColorFromString(text);

            }
            set
            {
                ConfigurationHelper.Save("XtraBackColor", value.Name);
            }
        }


        /// <summary>
        /// 是否可运行多个实例
        /// </summary>
        public static bool CanRunManey
        {
            get
            {
                return true;

            }
            set
            {
                //ConfigurationHelper.Save("CanRunManey", value.ToString());
            }
        }

        /// <summary>
        /// 退出程序前是否提示
        /// </summary>
        public static bool PromptBeforeExit
        {
            get
            {
                bool result;
                if (bool.TryParse(ConfigurationHelper.Read("PromptBeforeExit"), out result))
                {
                    return result;
                }
                else
                {
                    return true;
                }
            }
            set
            {
                ConfigurationHelper.Save("PromptBeforeExit", value.ToString());
            }
        }

        public static bool DisplayLastMonitorData
        {
            get
            {
                string key = "DisplayLastMonitorData";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                bool result;
                if (bool.TryParse(text, out result))
                {
                    return result;
                }
                else
                {
                    return true;
                }
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("DisplayLastMonitorData", value.ToString());
            }
        }

        public static bool CheckDictInput
        {
            get
            {
                string key = "CheckDictInput";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                bool result;
                if (bool.TryParse(text, out result))
                {
                    return result;
                }
                else
                {
                    return true;
                }
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("CheckDictInput", value.ToString());
            }
        }

        public static bool AllRights
        {
            get
            {
                string key = "AllRights";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                bool result;
                if (bool.TryParse(text, out result))
                {
                    return result;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("AllRights", value.ToString());
            }
        }

        public static bool AutoGenDocument
        {
            get
            {
                string key = "AutoGenDocument";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                //if (string.IsNullOrEmpty(text))
                //{
                //    text = ConfigurationHelper.Read(key);
                //}
                bool result;
                if (bool.TryParse(text, out result))
                {
                    return result;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("AutoGenDocument", value.ToString());
            }
        }

        public static bool AutoGenNavButtons
        {
            get
            {
                string key = "AutoGenNavButtons";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                //if (string.IsNullOrEmpty(text))
                //{
                //    text = ConfigurationHelper.Read(key);
                //}
                bool result;
                if (bool.TryParse(text, out result))
                {
                    return result;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("AutoGenNavButtons", value.ToString());
            }
        }

        public static int DosageButtonsCount
        {
            get
            {
                return 4;
                //string key = "DosageButtonsCount";
                //if (ExtendApplicationContext.Current.AppType.Equals(ApplicationType.CardiopulmonaryBypass))
                //{
                //    key = "CPBDosageButtonsCount";
                //}
                //string s = GetFromServer(key);
                //dosageButtonsCount=string.IsNullOrEmpty(s)?0:int.Parse(s);
                //if (dosageButtonsCount == 0 || dosageButtonsCount>15)
                //{
                //    dosageButtonsCount = 4;
                //}
                //return Configurations.dosageButtonsCount; 
            }
            set
            {
                //string key = "DosageButtonsCount";
                //if (ExtendApplicationContext.Current.AppType.Equals(ApplicationType.CardiopulmonaryBypass))
                //{
                //    key = "CPBDosageButtonsCount";
                //}
                //Configurations.dosageButtonsCount = value;
                //ApplicationConfiguration.ModifyConfigTable(key, dosageButtonsCount.ToString());
            }
        }

        public static string DefaultSheetName
        {
            get
            {
                return ExtendApplicationContext.Current.DocumentPath + "麻醉单";
            }
        }

        /// <summary>
        /// PDF打印机名称
        /// </summary>
        public static string PDFPrintName
        {
            get
            {
                return ConfigurationHelper.Read("PDFPrintName");
            }
            set
            {
                ConfigurationHelper.Save("PDFPrintName", value);
            }
        }

        /// <summary>
        /// PDF左边距
        /// </summary>
        public static int PDFLeftMargin
        {
            get
            {
                int leftMargin;
                if (int.TryParse(ConfigurationHelper.Read("PDFLeftMargin"), out leftMargin))
                {
                    return leftMargin;
                }
                else
                {
                    return 20;
                }
            }
            set
            {
                ConfigurationHelper.Save("PDFLeftMargin", value.ToString());
            }
        }

        public static string GetCustomConfig(string key)
        {
            Dictionary<string, MedicalDocElement> docs = MedicalDocSettings.GetCustomForms();
            foreach (KeyValuePair<string, MedicalDocElement> keyValuePair in docs)
            {
                if (keyValuePair.Key.Trim() == key)
                {
                    return keyValuePair.Value.Type;
                }
            }
            return "";
        }

        public static int ModifyDays
        {
            get
            {
                string key = "ModifyDays";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                int leftMargin;
                if (int.TryParse(text, out leftMargin))
                {
                    return leftMargin;
                }
                else
                {
                    return 1;
                }
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("ModifyDays", value.ToString());
            }
        }

        public static DateTime AppFileTime
        {
            get
            {
                string text = ConfigurationHelper.Read("AppFileTime");
                DateTime dt = DateTime.MinValue;
                if (string.IsNullOrEmpty(text))
                {
                    dt = new FileInfo(Application.ExecutablePath).LastAccessTime;
                }
                else
                {
                    if (!DateTime.TryParse(text, out dt))
                    {
                        dt = new FileInfo(Application.ExecutablePath).LastAccessTime;
                    }
                }
                return dt;
            }
            set
            {
                ConfigurationHelper.Save("AppFileTime", value.ToString());
            }
        }

        public static string MonitorLabel
        {
            get
            {
                string text = ConfigurationHelper.Read("MonitorLabel");
                if (string.IsNullOrEmpty(text))
                {
                    text = "";
                }
                return text;
            }
            set
            {
                ConfigurationHelper.Save("MonitorLabel", value);
            }
        }

        /// <summary>
        /// 前并行
        /// </summary>
        public static string QianBingXing
        {
            get
            {
                string text = ConfigurationHelper.Read("QianBingXing");
                if (string.IsNullOrEmpty(text))
                {
                    text = "前并行";
                }
                return text;
            }
            set
            {
                ConfigurationHelper.Save("QianBingXing", value);
            }
        }

        /// <summary>
        /// 后并行
        /// </summary>
        public static string HouBingXing
        {
            get
            {
                string text = ConfigurationHelper.Read("HouBingXing");
                if (string.IsNullOrEmpty(text))
                {
                    text = "后并行";
                }
                return text;
            }
            set
            {
                ConfigurationHelper.Save("HouBingXing", value);
            }
        }

        /// <summary>
        /// 全循环
        /// </summary>
        public static string QuanXunHuan
        {
            get
            {
                string text = ConfigurationHelper.Read("QuanXunHuan");
                if (string.IsNullOrEmpty(text))
                {
                    text = "全循环";
                }
                return text;
            }
            set
            {
                ConfigurationHelper.Save("QuanXunHuan", value);
            }
        }

        /// <summary>
        /// 显示主界面状态栏
        /// </summary>
        public static bool ShowMainFormStatusBar
        {
            get
            {
                string key = "ShowMainFormStatusBar";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    return true;
                }
                else
                {
                    bool result;
                    if (bool.TryParse(text, out result))
                    {
                        return result;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("ShowMainFormStatusBar", value.ToString());
            }
        }

        /// <summary>
        /// 显示主界面状态栏
        /// </summary>
        public static bool ShowDocumentScrollBar
        {
            get
            {
                string key = "ShowDocumentScrollBar";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    return true;
                }
                else
                {
                    bool result;
                    if (bool.TryParse(text, out result))
                    {
                        return result;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("ShowDocumentScrollBar", value.ToString());
            }
        }

        /// <summary>
        /// 插件文件名称
        /// </summary>
        public static string PlugFileName
        {
            get
            {
                string key = "PlugFileName";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                return text;
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("PlugFileName", value);
            }
        }
        /// <summary>
        /// 体征项显示设置
        /// </summary>
        public static string VitalSignConf
        {
            get
            {
                string key = "VitalSignConf";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text) || text == "�")
                {
                    text = "无";
                }
                return text;
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("VitalSignConf", value);
            }
        }

        /// <summary>
        /// 诱导室名称
        /// </summary>
        public static string YouDaoRoomTitle
        {
            get
            {
                string key = "YouDaoRoomTitle";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text) || text == "�")
                {
                    text = "诱导室";
                }
                return text;
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("YouDaoRoomTitle", value);
            }
        }

        public static bool ShowYouDao
        {
            get
            {
                bool result;
                if (bool.TryParse(ConfigurationHelper.Read("ShowYouDao"), out result))
                {
                    return result;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                ConfigurationHelper.Save("ShowYouDao", value.ToString());
            }
        }

        public static string SelectedMZMachineLabel
        {
            get
            {
                return ConfigurationHelper.Read("SelectedMZMachineLabel");
            }
            set
            {
                ConfigurationHelper.Save("SelectedMZMachineLabel", value);
            }
        }

        public static bool UseDefaultOperatingRoom
        {
            get
            {
                string key = "UseDefaultOperatingRoom";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    return false;
                }
                else
                {
                    bool result;
                    if (bool.TryParse(text, out result))
                    {
                        return result;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("UseDefaultOperatingRoom", value.ToString());
            }
        }

        /// <summary>
        /// 默认手术间
        /// </summary>
        public static string DefaultOperatingRoom
        {
            get
            {
                return ConfigurationHelper.Read("DefaultOperatingRoom");
            }
            set
            {
                ConfigurationHelper.Save("DefaultOperatingRoom", value);
            }
        }

        public static string OpertionRoom
        {
            get
            {
                return ConfigurationHelper.Read("OpertionRoom");
            }
            set
            {
                ConfigurationHelper.Save("OpertionRoom", value);
            }
        }

        public static string SelectedMonitorLabel
        {
            get
            {
                return ConfigurationHelper.Read("SelectedMonitorLabel");
            }
            set
            {
                ConfigurationHelper.Save("SelectedMonitorLabel", value);
            }
        }

        public static bool UseDefaultSelectedMonitorLabel
        {
            get
            {
                string key = "UseDefaultSelectedMonitorLabel";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                if (string.IsNullOrEmpty(text))
                {
                    return false;
                }
                else
                {
                    bool result = false;
                    if (!bool.TryParse(text, out result))
                    {
                        result = false;
                    }
                    return result;
                }
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("UseDefaultSelectedMonitorLabel", value.ToString());
            }
        }

        public static string NoDosage
        {
            get
            {
                string text = ConfigurationHelper.Read("NoDosage");
                if (!string.IsNullOrEmpty(text))
                {
                    return text;
                }
                else
                {
                    return "";
                }
            }
            set
            {
                ConfigurationHelper.Save("NoDosage", value);
            }
        }

        /// <summary>
        /// 麻醉科代码
        /// </summary>
        public static string AnesthesiaWardCode
        {
            //get
            //{
            //    string key = "AnesthesiaWardCode";
            //    string text = ConfigurationHelper.Read(key);
            //    if (string.IsNullOrEmpty(text))
            //    {
            //        text = ApplicationConfiguration.GetFromConfigTable(key);
            //    }
            //    if (!string.IsNullOrEmpty(text))
            //    {
            //        return text;
            //    }
            //    else
            //    {
            //        return "10003300";
            //    }
            //}
            //set
            //{
            //    string text = ConfigurationHelper.Read("AnesthesiaWardCode");
            //    if (!string.IsNullOrEmpty(text))
            //    {
            //        ConfigurationHelper.Save("AnesthesiaWardCode", value);
            //    }
            //    else
            //    {
            //        ApplicationConfiguration.ModifyConfigTable("AnesthesiaWardCode", value);
            //    }
            //}

            get
            {
                string key = "AnesthesiaWardCode";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                if (!string.IsNullOrEmpty(text))
                {
                    return text;
                }
                else
                {
                    return "10003300";
                }
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("AnesthesiaWardCode", value);
            }
        }

        /// <summary>
        /// 麻醉编号
        /// </summary>
        public static int AnesthesiaNumber
        {
            get
            {
                string key = "AnesthesiaNumber";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                if (!string.IsNullOrEmpty(text))
                {
                    int ret = 0;
                    if (!int.TryParse(text, out ret))
                    {
                        ret = 120000;
                    }
                    return ret;
                }
                else
                {
                    return 120000;
                }
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("AnesthesiaNumber", value.ToString());
            }
        }

        /// <summary>
        /// 手术申请同步方式
        /// </summary>
        public static int SyncScheduleInfoMode
        {
            get
            {
                string key = "SyncScheduleInfoMode";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                if (!string.IsNullOrEmpty(text))
                {
                    int ret = 0;
                    if (!int.TryParse(text, out ret))
                    {
                        ret = 0;
                    }
                    return ret;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("SyncScheduleInfoMode", value.ToString());
            }
        }

        /// <summary>
        /// 手术申请时间同步时时间差
        /// </summary>
        public static int SyncDateDiff
        {
            get
            {
                string key = "SyncDateDiff";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                if (!string.IsNullOrEmpty(text))
                {
                    int ret = 0;
                    if (!int.TryParse(text, out ret))
                    {
                        ret = 3;
                    }
                    return ret;
                }
                else
                {
                    return 3;
                }
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("SyncDateDiff", value.ToString());
            }
        }

        // add by shiyu.duan for 主板本升级 anes-00028 体征用药在出手术室时间填写完成后自动结束案例
        // anes-00104 持续事件可以选择结束节点 add by duanshiyu at 20190129 for 主板本升级 start
        /// <summary>
        /// 持续事件自动开始
        /// </summary>
        public static bool IsEventAutoStartEnd
        {
            get
            {
                string key = "IsEventAutoStartEnd";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                if (!string.IsNullOrEmpty(text))
                {
                    bool ret = false;
                    if (!bool.TryParse(text, out ret))
                    {
                        ret = false;
                    }
                    return ret;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("IsEventAutoStartEnd", value.ToString());
            }
        }
        /// <summary>
        /// 路径自动开始事件项目
        /// </summary>
        public static string AutoStartEndEvent
        {
            get
            {
                string key = "AutoStartEndEvent";
                string text = ConfigurationHelper.Read(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ApplicationConfiguration.GetFromConfigTable(key);
                }

                if (text == null)
                {
                    return string.Empty;
                }
                return text;
            }
            set
            {
                string key = "AutoStartEndEvent";
                ConfigurationHelper.Save(key, value);
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }
        // anes-00104 持续事件可以选择结束节点 add by duanshiyu at 20190129 for 主板本升级 end


        /// <summary>
        /// 持续用药自动结束
        /// </summary>
        public static bool DrugAutoStop
        {
            get
            {
                string key = "DrugAutoStop";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                if (!string.IsNullOrEmpty(text))
                {
                    bool ret = false;
                    if (!bool.TryParse(text, out ret))
                    {
                        ret = false;
                    }
                    return ret;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("DrugAutoStop", value.ToString());
            }
        }


        /// <summary>
        /// 持续用药自动结束时的手术状态
        /// </summary>
        public static string DrugAutoStopOperationStatus
        {
            get
            {
                string key = "DrugAutoStopOperationStatus";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                if (!string.IsNullOrEmpty(text))
                {

                    return text;
                }
                else
                {
                    return "出手术室";
                }
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("DrugAutoStopOperationStatus", value.ToString());
            }
        }

        /// <summary>
        /// 体征自动结束
        /// </summary>
        public static bool VitalSignAutoStop
        {
            get
            {
                string key = "VitalSignAutoStop";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                if (!string.IsNullOrEmpty(text))
                {
                    bool ret = false;
                    if (!bool.TryParse(text, out ret))
                    {
                        ret = false;
                    }
                    return ret;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("VitalSignAutoStop", value.ToString());
            }
        }

        /// <summary>
        /// 体征自动结束时的手术状态
        /// </summary>
        public static string VitalSignAutoStopOperationStatus
        {
            get
            {
                string key = "VitalSignAutoStopOperationStatus";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                if (!string.IsNullOrEmpty(text))
                {

                    return text;
                }
                else
                {
                    return "出手术室";
                }
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("VitalSignAutoStopOperationStatus", value.ToString());
            }
        }

        // add by shiyu.duan for 主板本升级 anes-00031 出室N天后自动归档
        /// <summary>
        /// 是否启用自动归档
        /// </summary>
        public static bool IsAutoCommitDoc
        {
            get
            {
                string key = "IsAutoCommitDoc";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                bool result;
                if (bool.TryParse(text, out result))
                {
                    return result;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("IsAutoCommitDoc", value.ToString());
            }
        }
        /// <summary>
        /// 手术结束到归档时间间隔
        /// </summary>
        public static string AnesthesiaArchiveDays
        {
            get
            {
                string key = "AnesthesiaArchiveDays";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                if (!string.IsNullOrEmpty(text))
                {
                    return text;
                }
                else
                {
                    return "7";// 24 * 7 默认7天后自动归档
                }
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("AnesthesiaArchiveDays", value);
            }
        }

        public static bool NoLogin
        {
            get
            {
                bool result;
                if (bool.TryParse(ConfigurationHelper.Read("NoLoginForm"), out result))
                {
                    return result;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                ConfigurationHelper.Save("NoLoginForm", value.ToString());
            }
        }

        public static bool IsConnACS
        {
            get
            {
                bool result;
                if (bool.TryParse(ConfigurationHelper.Read("IsConnACS"), out result))
                {
                    return result;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                ConfigurationHelper.Save("IsConnACS", value.ToString());
            }
        }

        public static string AcsAddress
        {
            get
            {
                string startAcsAddress = ConfigurationHelper.Read("AcsAddress");
                if (string.IsNullOrEmpty(startAcsAddress)) startAcsAddress = "..";
                return startAcsAddress;
            }
            set
            {
                ConfigurationHelper.Save("AcsAddress", value.ToString());
            }
        }

        public static bool RecordInterfaceLog
        {
            get
            {
                bool result;
                if (bool.TryParse(ConfigurationHelper.Read("RecordInterfaceLog"), out result))
                {
                    return result;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                ConfigurationHelper.Save("RecordInterfaceLog", value.ToString());
            }
        }
        public static DateTime ScheQueryDate
        {
            get
            {
                DateTime dt = DateTime.Now;
                if (!DateTime.TryParse(ConfigurationHelper.Read("ScheQueryDate"), out dt)) dt = DateTime.Now;
                return dt;
            }
            set
            {
                ConfigurationHelper.Save("ScheQueryDate", value.ToString());
            }
        }

        public static DateTime PatientListDate
        {
            get
            {
                DateTime dt = DateTime.Now;
                if (!DateTime.TryParse(ConfigurationHelper.Read("PatientListDate"), out dt)) dt = DateTime.Now;
                return dt;
            }
            set
            {
                ConfigurationHelper.Save("PatientListDate", value.ToString());
            }
        }

        public static bool DocareSync
        {
            get
            {
                bool result;
                if (bool.TryParse(ConfigurationHelper.Read("DocareSync"), out result))
                {
                    return result;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                ConfigurationHelper.Save("DocareSync", value.ToString());
            }
        }

        public static bool CheckOperInfo
        {
            get
            {
                bool result;
                if (bool.TryParse(ConfigurationHelper.Read("CheckOperInfo"), out result))
                {
                    return result;
                }
                else
                {
                    return true;
                }
            }
            set
            {
                ConfigurationHelper.Save("CheckOperInfo", value.ToString());
            }
        }

        public static bool CanUpload
        {
            get
            {
                bool result;
                if (bool.TryParse(ConfigurationHelper.Read("CanUpload"), out result))
                {
                    return result;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                ConfigurationHelper.Save("CanUpload", value.ToString());
            }
        }

        /// <summary>
        /// 装入状态按钮
        /// </summary>
        public static bool LoadStatusButtons
        {
            get
            {
                bool result;
                if (bool.TryParse(ConfigurationHelper.Read("LoadStatusButtons"), out result))
                {
                    return result;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                ConfigurationHelper.Save("LoadStatusButtons", value.ToString());
            }
        }

        public static bool MainButtonRight
        {
            get
            {
                bool result;
                if (bool.TryParse(ConfigurationHelper.Read("MainButtonRight"), out result))
                {
                    return result;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                ConfigurationHelper.Save("MainButtonRight", value.ToString());
            }
        }

        public static int PatientListWidth
        {
            get
            {
                int intValue;
                if (int.TryParse(ConfigurationHelper.Read("PatientListWidth"), out intValue))
                {
                    return intValue;
                }
                else
                {
                    return 240;
                }
            }
            set
            {
                ConfigurationHelper.Save("PatientListWidth", value.ToString());
            }
        }

        public static bool ShowPatientList
        {
            get
            {
                bool result;
                if (bool.TryParse(ConfigurationHelper.Read("ShowPatientList"), out result))
                {
                    return result;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                ConfigurationHelper.Save("ShowPatientList", value.ToString());
            }
        }


        /// <summary>
        /// 术后才能打印麻醉单
        /// </summary>
        public static bool PrintMZDAfterOper
        {
            get
            {
                bool result;
                if (bool.TryParse(ConfigurationHelper.Read("PrintMZDAfterOper"), out result))
                {
                    return result;
                }
                else
                {
                    return true;
                }
            }
            set
            {
                ConfigurationHelper.Save("PrintMZDAfterOper", value.ToString());
            }
        }


        /// <summary>
        /// 打印前核查麻醉起止时间
        /// </summary>
        public static bool CheckAnesTimeBeforePrint
        {
            get
            {
                bool result;
                if (bool.TryParse(ConfigurationHelper.Read("CheckAnesTimeBeforePrint"), out result))
                {
                    return result;
                }
                else
                {
                    return true;
                }
            }
            set
            {
                ConfigurationHelper.Save("CheckAnesTimeBeforePrint", value.ToString());
            }
        }

        /// <summary>
        /// 打印前核查手术起止时间
        /// </summary>
        public static bool CheckOperTimeBeforePrint
        {
            get
            {
                bool result;
                if (bool.TryParse(ConfigurationHelper.Read("CheckOperTimeBeforePrint"), out result))
                {
                    return result;
                }
                else
                {
                    return true;
                }
            }
            set
            {
                ConfigurationHelper.Save("CheckOperTimeBeforePrint", value.ToString());
            }
        }

        public static string StartFormName
        {
            get
            {
                string startFormName = ConfigurationHelper.Read("StartFormName");
                if (string.IsNullOrEmpty(startFormName)) startFormName = "InputMainFrm";
                return startFormName;
            }
            set
            {
                ConfigurationHelper.Save("StartFormName", value);
            }
        }


        public static bool PopupInOperationPanel
        {
            get
            {
                string popupInOperationPanel = ConfigurationHelper.Read("PopupInOperationPanel");
                if (string.IsNullOrEmpty(popupInOperationPanel)) popupInOperationPanel = "true";
                return bool.Parse(popupInOperationPanel);
            }
            set
            {
                ConfigurationHelper.Save("PopupInOperationPanel", value.ToString());
            }
        }

        public static bool InOperationPanelTimeH
        {
            get
            {
                string inOperationPanelTimeH = ConfigurationHelper.Read("InOperationPanelTimeH");
                if (string.IsNullOrEmpty(inOperationPanelTimeH)) inOperationPanelTimeH = "true";
                return bool.Parse(inOperationPanelTimeH);
            }
            set
            {
                ConfigurationHelper.Save("InOperationPanelTimeH", value.ToString());
            }
        }

        public static string AnesEventButtons
        {
            get
            {
                string[] buttons = new string[] { "麻药", "用药", "事件", "输液", "出量", "插管", "拔管", "输血", "输氧", "呼吸", "诱导", "其他" };//{ "输血", "输液","麻药", "吸入麻药", "局部麻药","静脉麻药", "事件", "用药", "输氧",  "呼吸", "插管",  "拔管", "诱导" , "其他"};
                string key = "AnesEventButtons" + ExtendApplicationContext.Current.EventNo.ToString();
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                if (string.IsNullOrEmpty(text))
                {
                    text = string.Join(",", buttons);
                }
                if (!ShowYouDao)
                {
                    text = text.Replace("诱导,", "").Replace(",诱导", "");
                }
                return text;
            }
            set
            {
                string key = "AnesEventButtons" + ExtendApplicationContext.Current.EventNo.ToString();
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        private static string GetAppTitleKey()
        {
            string key = "AppTitle";
            switch (ExtendApplicationContext.Current.AppType)
            {
                case ApplicationType.YouDao:
                    key = "YouDaoTitle";
                    break;
                case ApplicationType.PACU:
                    key = "PACUAppTitle";
                    break;
                case ApplicationType.Nurse:
                    key = "NurseAppTitle";
                    break;
                case ApplicationType.OperationSchedule:
                    key = "OperScheAppTitle";
                    break;
                case ApplicationType.CardiopulmonaryBypass:
                    key = "CPBAppTitle";
                    break;
                case ApplicationType.Director:
                    key = "DirectorAppTitle";
                    break;
            }
            return key;
        }

        private static string GetAppTitleDefault()
        {
            string text = "麻醉临床信息系统";
            switch (ExtendApplicationContext.Current.AppType)
            {
                case ApplicationType.YouDao:
                    text = "麻醉临床信息系统—诱导管理子系统";
                    break;
                case ApplicationType.PACU:
                    text = "麻醉系统—复苏子系统";
                    break;
                case ApplicationType.OperationSchedule:
                    text = "麻醉临床信息系统—排班子系统";
                    break;
                case ApplicationType.Nurse:
                    text = "手术护理工作站";
                    break;
                case ApplicationType.CardiopulmonaryBypass:
                    text = "体外循环临床信息系统";
                    break;
                case ApplicationType.Director:
                    text = "麻醉科主任工作站";
                    break;
            }
            return text;
        }

        //public static string AppTitle
        //{
        //    get
        //    {
        //        string key = GetAppTitleKey();
        //        string text = ApplicationConfiguration.GetFromConfigTable(key);
        //        if (string.IsNullOrEmpty(text))
        //        {
        //            text = ConfigurationHelper.Read(key);
        //        }
        //        if (string.IsNullOrEmpty(text))
        //        {
        //            text = GetAppTitleDefault();
        //        }
        //        return text;
        //    }
        //    set
        //    {
        //        string key = GetAppTitleKey();
        //        ApplicationConfiguration.ModifyConfigTable(key, value);
        //    }
        //}
        public static string AppTitle
        {
            get
            {
                //string key = GetAppTitleKey();
                //string text = ApplicationConfiguration.GetFromConfigTable(key);
                //if (string.IsNullOrEmpty(text))
                //{
                //    text = ConfigurationHelper.Read(key);
                //}
                //if (string.IsNullOrEmpty(text))
                //{
                //    text = GetAppTitleDefault();
                //}
                string text = GetAppTitleDefault();
                //if (ExtendApplicationContext.Current.AppType.Equals(ApplicationType.YouDao))
                //{
                //    text = GetAppTitleDefault();
                //}
                return text;
            }
            set
            {
                string key = GetAppTitleKey();
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        public static string CPBDepartCode
        {
            get
            {
                string key = "CPBDepartCode";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = "";
                }
                return text;
            }
            set
            {
                string key = "CPBDepartCode";
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        public static string CPBMonitorItemSetString
        {
            get
            {
                string[] items = new string[]  {"泵1流速,","泵2流速,","泵3A流速,","泵3B流速,","泵4A流速,","泵4B流速,","泵1转速,","泵2转速,",
                    "泵3A转速,","泵3B转速,","泵4A转速,","泵4B转速,","压力1,","压力2,","灌注压,","平均动脉压,","灌注总量,","每次灌注量,","温度,",
                    "水温,","Bypass,","X-Clamp,","CPL_Deliver,","CPL Recirc.,","Lschaemia,","pulsatile,","Reperf.,","Clamp,","SCPC Bypass,",
                    "SCPC X-Clamp,","搭桥计时,", "1号计时器,","2号计时器,","3号计时器,","4号计时器,","5号定时器,","6号计时器,"};//
                string key = "CPBMonitorItemSetString";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = string.Join(";", items);
                }
                return text;
            }
            set
            {
                string key = "CPBMonitorItemSetString";
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        private static string GetPatientStatusButtonsKey()
        {
            string key = "PatientStatusButtons";
            switch (ExtendApplicationContext.Current.AppType)
            {
                case ApplicationType.YouDao:
                    key = "YouDaoPatientStatusButtons";
                    break;
                case ApplicationType.PACU:
                    key = "PACUPatientStatusButtons";
                    break;
                case ApplicationType.Nurse:
                    key = "NursePatientStatusButtons";
                    break;
                case ApplicationType.Director:
                    key = "DirectorPatientStatusButtons";
                    break;
                case ApplicationType.OperationSchedule:
                    key = "OperSchePatientStatusButtons";
                    break;
                case ApplicationType.CardiopulmonaryBypass:
                    key = "CPBStatusButtons";
                    break;
            }
            return key;
        }

        private static string GetPatientStatusButtonsDefault()
        {
            string text = "入手术室,麻醉开始,手术开始,手术结束,麻醉结束,出手术室";
            switch (ExtendApplicationContext.Current.AppType)
            {
                case ApplicationType.YouDao:
                    text = "入诱导室,出诱导室";
                    break;
                case ApplicationType.PACU:
                    text = "入复苏室, 出复苏室";
                    break;
                case ApplicationType.OperationSchedule:
                    text = "";
                    break;
                case ApplicationType.CardiopulmonaryBypass:
                    text = "";
                    break;
                case ApplicationType.Nurse:
                    text = "";
                    break;
                case ApplicationType.Director:
                    text = "";
                    break;
            }
            return text;
        }

        //public static string PatientStatusButtons
        //{
        //    get
        //    {
        //        string key = GetPatientStatusButtonsKey();
        //        string text = ApplicationConfiguration.GetFromConfigTable(key);
        //        //if (string.IsNullOrEmpty(text))
        //        //{
        //        //    text = ConfigurationHelper.Read(key);
        //        //}
        //        if (string.IsNullOrEmpty(text))
        //        {
        //            text = GetPatientStatusButtonsDefault();
        //        }
        //        if (ExtendApplicationContext.Current.AppType.Equals(ApplicationType.CardiopulmonaryBypass))
        //        {
        //            text = GetPatientStatusButtonsDefault();
        //        }
        //        return text;
        //    }
        //    set
        //    {
        //        string key = GetPatientStatusButtonsKey();
        //        ApplicationConfiguration.ModifyConfigTable(key, value);
        //    }
        //}
        public static string PatientStatusButtons
        {
            get
            {
                string key = GetPatientStatusButtonsKey();
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                //if (string.IsNullOrEmpty(text))
                //{
                //    text = ConfigurationHelper.Read(key);
                //}
                if (string.IsNullOrEmpty(text))
                {
                    text = GetPatientStatusButtonsDefault();
                }
                if (ExtendApplicationContext.Current.AppType.Equals(ApplicationType.CardiopulmonaryBypass))
                {
                    text = GetPatientStatusButtonsDefault();
                }
                else if (ExtendApplicationContext.Current.AppType.Equals(ApplicationType.YouDao))
                {
                    text = GetPatientStatusButtonsDefault();
                }
                return text;
            }
            set
            {
                string key = GetPatientStatusButtonsKey();
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }
        private static string GetNoPatientButtonsKey()
        {
            string key = "NoPatientButtons";
            switch (ExtendApplicationContext.Current.AppType)
            {
                case ApplicationType.YouDao:
                    key = "YaoDaoNoPatientButtons";
                    break;
                case ApplicationType.PACU:
                    key = "PACUNoPatientButtons";
                    break;
                case ApplicationType.Nurse:
                    key = "NurseNoPatientButtons";
                    break;
                case ApplicationType.OperationSchedule:
                    key = "OperScheNoPatientButtons";
                    break;
                case ApplicationType.CardiopulmonaryBypass:
                    key = "CPBNoPatientButtons";
                    break;
                case ApplicationType.Director:
                    key = "DirectorNoPatientButtons";
                    break;
            }
            return key;
        }

        private static string GetNoPatientButtonsDefault()
        {
            string text = string.Join(";", new string[] { "", "", "", "手术概览,锁定系统,血流动力,字典,模板管理", "系统配置,关于" });
            switch (ExtendApplicationContext.Current.AppType)
            {
                case ApplicationType.OperationSchedule:
                    text = string.Join(";", new string[] { "", "", ""
                        , "手术安排,麻醉安排,批量手术,手术通知,字典,模板管理,锁定系统", "系统配置" });
                    break;
                case ApplicationType.CardiopulmonaryBypass:
                    text = string.Join(";", new string[] { "", "", "", "锁定系统,血流动力,字典,模板管理", "系统配置,关于" });
                    break;
                case ApplicationType.Nurse:
                    text = string.Join(";", new string[] { "", "", "", "锁定系统,字典,模板管理", "系统配置,关于" });
                    break;
                case ApplicationType.Director:
                    text = string.Join(";", new string[] { "", "", "", "手术概览,查询统计", "锁定系统,字典,模板管理,系统配置,关于" });
                    break;
            }
            return text;
        }

        public static string NoPatientButtons
        {
            get
            {
                string key = GetNoPatientButtonsKey();
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                //if (string.IsNullOrEmpty(text))
                //{
                //    text = ConfigurationHelper.Read(key);
                //}
                if (string.IsNullOrEmpty(text))
                {
                    text = GetNoPatientButtonsDefault();
                }
                return text;
            }
            set
            {
                string key = GetNoPatientButtonsKey();
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        private static string GetSelectPatientButtonsKey()
        {
            string key = "SelectPatientButtons";
            switch (ExtendApplicationContext.Current.AppType)
            {
                case ApplicationType.YouDao:
                    key = "YouDaoSelectPatientButtons";
                    break;
                case ApplicationType.PACU:
                    key = "PACUSelectPatientButtons";
                    break;
                case ApplicationType.Nurse:
                    key = "NurseSelectPatientButtons";
                    break;
                case ApplicationType.OperationSchedule:
                    key = "OperScheSelectPatientButtons";
                    break;
                case ApplicationType.CardiopulmonaryBypass:
                    key = "CPBSelectPatientButtons";
                    break;
                case ApplicationType.Director:
                    key = "DirectorSelectPatientButtons";
                    break;
            }
            return key;
        }

        private static string GetSelectPatientButtonsDefault()
        {
            string text = string.Join(";", new string[] { "", "检验信息,检查结果,医嘱信息,病历病程", "手术信息,血气分析,穿刺管理,术后登记,病案提交,取消手术,手术交班,手术概览"
                    , "锁定系统,血流动力,字典,模板管理", "系统配置,关于" });
            switch (ExtendApplicationContext.Current.AppType)
            {
                case ApplicationType.OperationSchedule:
                    text = string.Join(";", new string[] { "", "检验信息,检查结果,医嘱信息,病历病程", "手术信息,手术护理,器械清点,取消手术"
                    , "手术安排,麻醉安排,批量手术,手术通知,字典,模板管理,锁定系统", "系统配置" });
                    break;
                case ApplicationType.CardiopulmonaryBypass:
                    //    text = string.Join(";", new string[] { "", "检验信息,检查结果,医嘱信息,病历病程", "手术信息,转前检查,预充信息,灌注部位,器械耗材,出入量,心肌保护,气体管理,采集曲线,采集数据,转中登记,血气分析,灌注总结"
                    //, "锁定系统,修改密码,仪器设置,模板管理", "字典配置, 系统配置" });
                    text = string.Join(";", new string[] { "", "", "手术信息,转前检查,预充信息,穿刺管理,血气分析,灌注总结"
                , "锁定系统,血流动力,仪器设置,字典,模板管理", "系统配置,关于" });
                    break;
                case ApplicationType.Nurse:
                    text = string.Join(";", new string[] { "", "", "手术信息"
                , "锁定系统,字典,模板管理", "系统配置,关于" });
                    break;
                case ApplicationType.Director:
                    text = string.Join(";", new string[] { "", "", ""
                , "手术概览,查询统计,手术信息", "锁定系统,字典,模板管理,系统配置,关于" });
                    break;
            }
            return text;
        }

        public static string SelectPatientButtons
        {
            get
            {
                string key = GetSelectPatientButtonsKey();
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                //if (string.IsNullOrEmpty(text))
                //{
                //    text = ConfigurationHelper.Read(key);
                //}
                if (string.IsNullOrEmpty(text))
                {
                    text = GetSelectPatientButtonsDefault();
                }
                return text;
            }
            set
            {
                string key = GetSelectPatientButtonsKey();
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        //public static string AnesthesiaRecordButtons
        //{
        //    get
        //    {
        //        string[] buttons = new string[] { "麻    药, 用    药, 事    件, 输    氧,插    管, 拔    管, 输    液, 输    血, 呼    吸, 其    他"
        //             , "检验信息, 检查结果, 医嘱信息, 病历病程", "监 护 仪, 手术信息, 血气分析,穿刺管理,术中登记,取消手术,手术交班"
        //             , "锁定系统,血流动力,字    典,模板管理", "系统配置,关    于" };
        //        string key = "AnesthesiaRecordButtons";
        //        string text = ApplicationConfiguration.GetFromConfigTable(key);
        //        //if (string.IsNullOrEmpty(text))
        //        //{
        //        //    text = ConfigurationHelper.Read(key);
        //        //}
        //        if (string.IsNullOrEmpty(text))
        //        {
        //            text = string.Join(";", buttons);
        //        }
        //        return text;
        //    }
        //    set
        //    {
        //        string key = "AnesthesiaRecordButtons";
        //        ApplicationConfiguration.ModifyConfigTable(key, value);
        //    }
        //}

        public static string AnesthesiaRecordButtons
        {
            get
            {
                string[] buttons = new string[] { "麻药, 用药, 事件, 输氧,插管, 拔管, 输液, 输血, 呼吸,出液, 其他"
                    , "检验信息, 检查结果, 医嘱信息, 病历病程", "监护仪, 手术信息, 血气分析,术中登记,手术交班"
                    , "锁定系统,血流动力,字典,模板管理", "系统配置,关于" };
                string key = "AnesthesiaRecordButtons";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                //if (string.IsNullOrEmpty(text))
                //{
                //    text = ConfigurationHelper.Read(key);
                //}
                if (string.IsNullOrEmpty(text))
                {
                    text = string.Join(";", buttons);
                }
                if (ExtendApplicationContext.Current.AppType == ApplicationType.YouDao)
                {
                    buttons = new string[] { "麻药, 用药, 事件, 输氧,插管, 拔管, 输液, 输血, 呼吸,出液,其他"
                    , "检验信息, 检查结果, 医嘱信息, 病历病程", "复苏床位, 手术信息, 血气分析,术中登记,取消手术,手术交班"
                    , "锁定系统,血流动力,字典,模板管理", "系统配置,关于" };
                    text = string.Join(";", buttons);
                }
                return text;
            }
            set
            {
                string key = "AnesthesiaRecordButtons";
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        public static string PACUButtons
        {
            get
            {
                string[] buttons = new string[] { "麻药, 用药, 事件, 输氧,插管, 拔管, 输液, 输血, 呼吸, 其他"
                    , "检验信息, 检查结果, 医嘱信息, 病历病程", "复苏床位, 手术信息, 血气分析,穿刺管理,复苏登记,手术交班,手术概览"
                  , "锁定系统,血流动力,字典,模板管理", "系统配置,关于" };
                string key = "PACUButtons";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                if (string.IsNullOrEmpty(text))
                {
                    text = string.Join(";", buttons);
                }
                return text;
            }
            set
            {
                string key = "PACUButtons";
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        public static string CPBReportButtons
        {
            get
            {
                //string[] buttons = new string[]  {"事  件,药  剂,输 出,其 它", "检验信息,检查结果,医嘱信息,病历病程", "手术信息,转前检查,预充信息,灌注部位,器械耗材,出入量,心肌保护,气体管理,采集曲线,采集数据,转中登记,血气分析,灌注总结"
                //, "锁定系统,修改密码,仪器设置,模板管理", "字典配置, 系统配置" };
                string[] buttons = new string[]  {"事件,输液,输血,用药,灌注,出液,其他", "", "手术信息,转前检查,预充信息,转中登记,采集数据,血气分析,灌注总结"
                , "锁定系统,血流动力,仪器设置,字典,模板管理", "系统配置,关于" };
                string key = "CPBReportButtons";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                if (string.IsNullOrEmpty(text))
                {
                    text = string.Join(";", buttons);
                }
                return text;
            }
            set
            {
                string key = "CPBReportButtons";
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        public static string LiquidAttrs
        {
            get
            {
                string[] buttons = new string[] { "晶体", "胶体", "其他" };
                string text = ConfigurationHelper.Read("LiquidAttrs");
                if (string.IsNullOrEmpty(text))
                {
                    text = "晶体,胶体,其他";// string.Join(",", buttons);
                }
                return text;
            }
            set
            {
                ConfigurationHelper.Save("LiquidAttrs", value);
            }
        }

        public static string OutList
        {
            get
            {
                return ApplicationConfiguration.GetFromConfigTable("OutList");
            }
            set
            {
                ModifyConfigTable("OutList", value);
            }
        }

        //public static string ApplicationID
        //{
        //    get
        //    {
        //        string text = ConfigurationHelper.Read("ApplicationID");
        //        if (string.IsNullOrEmpty(text))
        //        {
        //            text = "ANESPERSONAL";
        //        }
        //        return text;
        //    }
        //    set
        //    {
        //        ConfigurationHelper.Save("ApplicationID", value);
        //    }
        //}

        /// <summary>
        /// 密码类型
        /// </summary>
        public enum PassWordTypes
        {
            UpCase,
            CaseSensitive,
            LowCase,
        }

        //public static ApplicationType AppType
        //{
        //    get
        //    {
        //        ApplicationType appType = ApplicationType.Anesthesia;
        //        string text = ConfigurationHelper.Read("AppType");
        //        if (!string.IsNullOrEmpty(text))
        //        {
        //            object obj = Enum.Parse(typeof(ApplicationType), text);
        //            if (obj != null && obj is ApplicationType)
        //            {
        //                appType = (ApplicationType)obj;
        //            }
        //        }
        //        return appType;
        //    }
        //    set
        //    {
        //        ConfigurationHelper.Save("AppType", value.ToString());
        //    }
        //}

        public static PassWordTypes PassWordType
        {
            get
            {
                PassWordTypes passWordType = PassWordTypes.UpCase;
                //string key = "PassWordType";
                //string text = GetFromServer(key);
                //if (string.IsNullOrEmpty(text))
                //{
                //    text = ConfigurationHelper.Read(key);
                //}
                //if (!string.IsNullOrEmpty(text))
                //{
                //    object obj = Enum.Parse(typeof(PassWordTypes), text);
                //    if (obj != null && obj is PassWordTypes)
                //    {
                //        passWordType = (PassWordTypes)obj;
                //    }
                //}
                return passWordType;
            }
            set
            {
                //ApplicationConfiguration.ModifyConfigTable("PassWordType", value.ToString());
            }
        }

        public static string PACUDesc
        {
            get
            {
                string text = ConfigurationHelper.Read("PACUDesc");
                if (string.IsNullOrEmpty(text)) text = "NoPACU";
                return text;
            }
            set
            {
                ConfigurationHelper.Save("PACUDesc", value.ToString());
            }
        }

        #endregion 属性

        #region 私有方法

        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="valName">内部变量名称</param>
        /// <param name="key">主键</param>
        /// <param name="value">值</param>
        private static void SetValue(ref string valName, string key, string value)
        {
            valName = value;
            ConfigurationHelper.Save(key, value);
        }

        #endregion 私有方法

        #region 公有方法

        ///// <summary>
        ///// 复制系统连接字符串到客户端配置表中以便用户重新配置
        ///// </summary>
        //public static void CopyConnectionStringSettings()
        //{
        //    List<ConnectionStringSettings> list = DataSetModel.Config.GetConnectionStringSettings();
        //    if (list.Count > 0)
        //    {
        //        bool isChanged = false;
        //        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        //        foreach (ConnectionStringSettings connectionStringSettings in list)
        //        {
        //            ConnectionStringSettings connectionStringSettings1 = config.ConnectionStrings.ConnectionStrings[connectionStringSettings.Name];
        //            if (connectionStringSettings1 == null)
        //            {
        //                config.ConnectionStrings.ConnectionStrings.Add(connectionStringSettings);
        //                isChanged = true;
        //            }
        //        }
        //        if (isChanged)
        //        {
        //            ConfigurationHelper.ProtectSection(config.ConnectionStrings);
        //            config.Save();
        //        }
        //    }
        //}

        #endregion 公有方法





        private static string GetAppTypeKey(string initKey)
        {
            string prefix = "";
            switch (ExtendApplicationContext.Current.AppType)
            {
                case ApplicationType.CardiopulmonaryBypass:
                    prefix = "CPB";
                    break;
                case ApplicationType.Nurse:
                    prefix = "Nurse";
                    break;
                case ApplicationType.Director:
                    prefix = "Director";
                    break;
                default:
                    break;
            }
            return prefix + initKey;
        }

        public static MedicalDocucementElement GetMedicalDocument(string documentName)
        {
            MedicalDocucementElement medicalDocElement = new MedicalDocucementElement();
            string key = "MedicalDocument." + documentName;
            string text = ApplicationConfiguration.GetFromConfigTable(key);
            if (!string.IsNullOrEmpty(text))
            {
                List<string> list = new List<string>(text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
                medicalDocElement.FromList(list);
            }
            else
            {
                List<string> list = new List<string>();
                Dictionary<string, MedicalDocElement> docKeyValuePairs = MedicalDocSettings.GetMedicalDocNameAndPath();
                foreach (KeyValuePair<string, MedicalDocElement> keyValuePair in docKeyValuePairs)
                {
                    if (keyValuePair.Key.Trim() == documentName.Trim())
                    {
                        medicalDocElement.Caption = keyValuePair.Value.Caption;
                        medicalDocElement.Key = keyValuePair.Value.Key;
                        medicalDocElement.Path = keyValuePair.Value.Path;
                        medicalDocElement.Type = keyValuePair.Value.Type;
                        break;
                    }
                }
                if (string.IsNullOrEmpty(medicalDocElement.Key))
                {
                    docKeyValuePairs = MedicalDocSettings.GetMedicalFormsNameAndPath();
                    foreach (KeyValuePair<string, MedicalDocElement> keyValuePair in docKeyValuePairs)
                    {
                        if (keyValuePair.Key.Trim() == documentName.Trim())
                        {
                            medicalDocElement.Caption = keyValuePair.Value.Caption;
                            medicalDocElement.Key = keyValuePair.Value.Key;
                            medicalDocElement.Path = keyValuePair.Value.Path;
                            medicalDocElement.Type = keyValuePair.Value.Type;
                            break;
                        }
                    }
                }
            }
            if (string.IsNullOrEmpty(medicalDocElement.Key))
            {
                medicalDocElement.Key = documentName;
            }
            return medicalDocElement;
        }

        public static void SetMedicalDocument(string documentName, string value)
        {
            MedicalDocucementElement medicalDocElement = GetMedicalDocument(documentName);
            if (!medicalDocElement.ToString().Equals(value))
            {
                ApplicationConfiguration.ModifyConfigTable("MedicalDocument." + documentName, value);
            }
        }

        public static List<string> MedicalDocumentList
        {
            get
            {
                string key = "MedicalDocumentList";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (!string.IsNullOrEmpty(text))
                {
                    return new List<string>(text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
                }
                else
                {
                    List<string> list = new List<string>();
                    Dictionary<string, MedicalDocElement> docKeyValuePairs = MedicalDocSettings.GetMedicalDocNameAndPath();
                    foreach (KeyValuePair<string, MedicalDocElement> keyValuePair in docKeyValuePairs)
                    {
                        list.Add(keyValuePair.Key);
                    }
                    return list;
                }
            }
            set
            {
                string key = "MedicalDocumentList";
                ApplicationConfiguration.ModifyConfigTable(key, string.Join(",", value.ToArray()));
            }
        }


        public static string InRoomDocuments
        {
            get
            {
                if (AutoGenDocument)
                {
                    return "术前访视单,麻醉同意书,麻醉单";
                }
                else
                {
                    string key = GetAppTypeKey("InRoomDocuments");
                    string text = ApplicationConfiguration.GetFromConfigTable(key);
                    if (string.IsNullOrEmpty(text))
                    {
                        text = ConfigurationHelper.Read(key);
                        if (string.IsNullOrEmpty(text))
                        {
                            text = "术前访视,麻醉同意书,麻醉单";
                        }
                    }                        
                    return text;
                }
            }
            set
            {
                string key = GetAppTypeKey("InRoomDocuments");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }
        public static string AnesthesiaStartDocuments
        {
            get
            {
                if (AutoGenDocument)
                {
                    return "术前访视,麻醉同意书,麻醉计划,麻醉单,手术清点记录,手术护理单";
                }
                else
                {
                    string key = GetAppTypeKey("AnesthesiaStartDocuments");
                    string text = ApplicationConfiguration.GetFromConfigTable(key);
                    if (string.IsNullOrEmpty(text))
                    {
                        text = ConfigurationHelper.Read(key);
                        if (string.IsNullOrEmpty(text))
                        {
                            text = "术前访视,麻醉同意书,麻醉计划,麻醉单,手术清点记录,手术护理单";
                        }
                    }
                    return text;
                }
            }
            set
            {
                string key = GetAppTypeKey("AnesthesiaStartDocuments");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        public static string OperationStartDocuments
        {
            get
            {
                if (AutoGenDocument)
                {
                    return "术前访视,麻醉同意书,麻醉计划,麻醉单,手术清点记录,手术护理单";
                }
                else
                {
                    string key = GetAppTypeKey("OperationStartDocuments");
                    string text = ApplicationConfiguration.GetFromConfigTable(key);
                    if (string.IsNullOrEmpty(text))
                    {
                        text = ConfigurationHelper.Read(key);
                        if (string.IsNullOrEmpty(text))
                        {
                            text = "术前访视,麻醉同意书,麻醉计划,麻醉单,手术清点记录,手术护理单";
                        }
                    }
                    return text;
                }
            }
            set
            {
                string key = GetAppTypeKey("OperationStartDocuments");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        /// <summary>
        /// 手术结束可见医疗文书
        /// </summary>
        public static string OperationEndDocuments
        {
            get
            {
                if (AutoGenDocument)
                {
                    return "术前访视,麻醉同意书,麻醉计划,麻醉单,手术清点记录,手术护理单,麻醉总结,术后随访,镇痛记录";
                }
                else
                {
                    string key = GetAppTypeKey("OperationEndDocuments");
                    string text = ApplicationConfiguration.GetFromConfigTable(key);
                    if (string.IsNullOrEmpty(text))
                    {
                        text = ConfigurationHelper.Read(key);
                        if (string.IsNullOrEmpty(text))
                        {
                            text = "术前访视,麻醉同意书,麻醉计划,麻醉单,手术清点记录,手术护理单,麻醉总结,术后随访,镇痛记录";
                        }
                    }
                    return text;
                }
            }
            set
            {
                string key = GetAppTypeKey("OperationEndDocuments");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        public static string AnesthesiaEndDocuments
        {
            get
            {
                if (AutoGenDocument)
                {
                    return "术前访视,麻醉同意书,麻醉计划,麻醉单,手术清点记录,手术护理单,麻醉总结,术后随访,镇痛记录";
                }
                else
                {
                    string key = GetAppTypeKey("AnesthesiaEndDocuments");
                    string text = ApplicationConfiguration.GetFromConfigTable(key);
                    if (string.IsNullOrEmpty(text))
                    {
                        text = ConfigurationHelper.Read(key);
                        if (string.IsNullOrEmpty(text))
                        {
                            text = "术前访视,麻醉同意书,麻醉计划,麻醉单,手术清点记录,手术护理单,麻醉总结,术后随访,镇痛记录";
                        }
                    }
                    return text;
                }
            }
            set
            {
                string key = GetAppTypeKey("AnesthesiaEndDocuments");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        public static string OutRoomDocuments
        {
            get
            {
                if (AutoGenDocument)
                {
                    //return "术前访视单,麻醉单,麻醉总结单";
                    return "术前访视,麻醉同意书,麻醉计划,麻醉单,手术清点记录,手术护理单,麻醉总结,术后随访,镇痛记录,麻醉质控单";
                }
                else
                {
                    string key = GetAppTypeKey("OutRoomDocuments");
                    string text = ApplicationConfiguration.GetFromConfigTable(key);
                    if (string.IsNullOrEmpty(text))
                    {
                        text = ConfigurationHelper.Read(key);
                        if (string.IsNullOrEmpty(text))
                        {
                            text = "术前访视,麻醉同意书,麻醉计划,麻醉单,手术清点记录,手术护理单,麻醉总结,术后随访,镇痛记录,麻醉质控单";
                        }
                    }
                    return text;
                }
            }
            set
            {
                string key = GetAppTypeKey("OutRoomDocuments");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        public static string InPACUDocuments
        {
            get
            {
                if (AutoGenDocument)
                {
                    return "复苏单";
                }
                else
                {
                    string key = GetAppTypeKey("InPACUDocuments");
                    string text = ApplicationConfiguration.GetFromConfigTable(key);
                    if (string.IsNullOrEmpty(text))
                    {
                        text = ConfigurationHelper.Read(key);
                    }
                    return text;
                }
            }
            set
            {
                string key = GetAppTypeKey("InPACUDocuments");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }
        public static string TurnToPACUDocuments
        {
            get
            {
                if (AutoGenDocument)
                {
                    return "复苏单";
                }
                else
                {
                    string key = GetAppTypeKey("TurnToPACUDocuments");
                    string text = ApplicationConfiguration.GetFromConfigTable(key);
                    if (string.IsNullOrEmpty(text))
                    {
                        text = ConfigurationHelper.Read(key);
                    }
                    return text;
                }
            }
            set
            {
                string key = GetAppTypeKey("TurnToPACUDocuments");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }
        public static string TurnToSickRoomDocuments
        {
            get
            {
                if (AutoGenDocument)
                {
                    return "术前访视,麻醉同意书,麻醉计划,麻醉单,手术清点记录,手术护理单,麻醉总结,术后随访,镇痛记录,麻醉质控单";
                }
                else
                {
                    string key = GetAppTypeKey("TurnToSickRoomDocuments");
                    string text = ApplicationConfiguration.GetFromConfigTable(key);
                    if (string.IsNullOrEmpty(text))
                    {
                        text = ConfigurationHelper.Read(key);
                        if (string.IsNullOrEmpty(text))
                        {
                            text = "术前访视,麻醉同意书,麻醉计划,麻醉单,手术清点记录,手术护理单,麻醉总结,术后随访,镇痛记录,麻醉质控单";
                        }
                    }
                    return text;
                }
            }
            set
            {
                string key = GetAppTypeKey("TurnToSickRoomDocuments");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        public static string OutPACUocuments
        {
            get
            {
                if (AutoGenDocument)
                {
                    return "";
                }
                else
                {
                    string key = GetAppTypeKey("OutPACUocuments");
                    string text = ApplicationConfiguration.GetFromConfigTable(key);
                    if (string.IsNullOrEmpty(text))
                    {
                        text = ConfigurationHelper.Read(key);
                    }
                    return text;
                }
            }
            set
            {
                string key = GetAppTypeKey("OutPACUocuments");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }
        public static string TurnToPACUActions
        {
            get
            {
                string key = GetAppTypeKey("TurnToPACUActions");
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                return text;
            }
            set
            {
                string key = GetAppTypeKey("TurnToPACUActions");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }
        public static string TurnToSickRoomActions
        {
            get
            {
                string key = GetAppTypeKey("TurnToSickRoomActions");
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                return text;
            }
            set
            {
                string key = GetAppTypeKey("TurnToSickRoomActions");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }
        public static string InRoomActions
        {
            get
            {
                if (AutoGenDocument)
                {
                    return "设备采集";
                }
                else
                {
                    string key = GetAppTypeKey("InRoomActions");
                    string text = ApplicationConfiguration.GetFromConfigTable(key);
                    if (string.IsNullOrEmpty(text))
                    {
                        text = ConfigurationHelper.Read(key);
                        if (string.IsNullOrEmpty(text))
                        {
                            text = "设备采集";
                        }
                    }
                    return text;
                }
            }
            set
            {
                string key = GetAppTypeKey("InRoomActions");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        public static string AnesthesiaStartActions
        {
            get
            {
                string key = GetAppTypeKey("AnesthesiaStartActions");
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                return text;
            }
            set
            {
                string key = GetAppTypeKey("AnesthesiaStartActions");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        public static string OperationStartActions
        {
            get
            {
                string key = GetAppTypeKey("OperationStartActions");
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                return text;
            }
            set
            {
                string key = GetAppTypeKey("OperationStartActions");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        public static string OperationEndActions
        {
            get
            {
                string key = GetAppTypeKey("OperationEndActions");
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                return text;
            }
            set
            {
                string key = GetAppTypeKey("OperationEndActions");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        public static string AnesthesiaEndActions
        {
            get
            {
                string key = GetAppTypeKey("AnesthesiaEndActions");
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                return text;
            }
            set
            {
                string key = GetAppTypeKey("AnesthesiaEndActions");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        public static string OutRoomActions
        {
            get
            {
                string key = GetAppTypeKey("OutRoomActions");
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                return text;
            }
            set
            {
                string key = GetAppTypeKey("OutRoomActions");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        public static string InPACUActions
        {
            get
            {
                string key = GetAppTypeKey("InPACUActions");
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                return text;
            }
            set
            {
                string key = GetAppTypeKey("InPACUActions");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        public static string OutPACUActions
        {
            get
            {
                string key = GetAppTypeKey("OutPACUActions");
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                return text;
            }
            set
            {
                string key = GetAppTypeKey("OutPACUActions");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        public static string InYouDaoActions
        {
            get
            {
                string key = GetAppTypeKey("InYouDaoActions");
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                return text;
            }
            set
            {
                string key = GetAppTypeKey("InYouDaoActions");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        public static string IsReadyActions
        {
            get
            {
                string key = GetAppTypeKey("IsReadyActions");
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                return text;
            }
            set
            {
                string key = GetAppTypeKey("IsReadyActions");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        public static string OutYouDaoActions
        {
            get
            {
                string key = GetAppTypeKey("OutYouDaoActions");
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                return text;
            }
            set
            {
                string key = GetAppTypeKey("OutYouDaoActions");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        public static string DoneActions
        {
            get
            {
                string key = GetAppTypeKey("DoneActions");
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                return text;
            }
            set
            {
                string key = GetAppTypeKey("DoneActions");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        public static string InYouDaoDocuments
        {
            get
            {
                string key = GetAppTypeKey("InYouDaoDocuments");
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                return text;
            }
            set
            {
                string key = GetAppTypeKey("InYouDaoDocuments");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        public static string IsReadyDocuments
        {
            get
            {
                if (AutoGenDocument)
                {
                    return "术前访视,麻醉同意书,麻醉计划,麻醉单,手术清点记录,手术护理单";
                }
                else
                {
                    string key = GetAppTypeKey("IsReadyDocuments");
                    string text = ApplicationConfiguration.GetFromConfigTable(key);
                    if (string.IsNullOrEmpty(text))
                    {
                        text = ConfigurationHelper.Read(key);
                        if (string.IsNullOrEmpty(text))
                        {
                            text = "术前访视,麻醉同意书,麻醉计划,麻醉单,手术清点记录,手术护理单";
                        }
                    }
                    return text;
                }
            }
            set
            {
                string key = GetAppTypeKey("IsReadyDocuments");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }


        public static string TurnToICUDocuments
        {
            get
            {
                if (AutoGenDocument)
                {
                    return "术前访视,麻醉同意书,麻醉计划,麻醉单,手术清点记录,手术护理单,麻醉总结,术后随访,镇痛记录,麻醉质控单";
                }
                else
                {
                    string key = GetAppTypeKey("TurnToICUDocuments");
                    string text = ApplicationConfiguration.GetFromConfigTable(key);
                    if (string.IsNullOrEmpty(text))
                    {
                        text = ConfigurationHelper.Read(key);
                        if (string.IsNullOrEmpty(text))
                        {
                            text = "术前访视,麻醉同意书,麻醉计划,麻醉单,手术清点记录,手术护理单,麻醉总结,术后随访,镇痛记录,麻醉质控单";
                        }
                    }
                    return text;
                }
            }
            set
            {
                string key = GetAppTypeKey("TurnToICUDocuments");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        public static string OutYouDaoDocuments
        {
            get
            {
                string key = GetAppTypeKey("OutYouDaoDocuments");
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                return text;
            }
            set
            {
                string key = GetAppTypeKey("OutYouDaoDocuments");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        public static string DoneDocuments
        {
            get
            {
                if (AutoGenDocument)
                {
                    return "同意书,术前访视单,麻醉单,麻醉总结单,术后随访单";
                }
                else
                {
                    string key = GetAppTypeKey("DoneDocuments");
                    string text = ApplicationConfiguration.GetFromConfigTable(key);
                    if (string.IsNullOrEmpty(text))
                    {
                        text = ConfigurationHelper.Read(key);
                    }
                    return text;
                }
            }
            set
            {
                string key = GetAppTypeKey("DoneDocuments");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        /// <summary>
        /// 是否诱导室管理程序
        /// </summary>
        public static bool IsYouDaoProgram
        {
            get
            {
                string key = "IsYouDaoProgram";
                string text = ConfigurationHelper.Read(key);
                bool result;
                if (bool.TryParse(text, out result))
                {
                    return result;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                ConfigurationHelper.Save("IsYouDaoProgram", value.ToString());
            }
        }

        public static string AnesDocName
        {
            get
            {
                //string text = ConfigurationHelper.Read("AnesDocName");
                //if (string.IsNullOrEmpty(text))
                //{
                return "麻醉单";
                //}
                //return text;
            }
            set
            {
                //ConfigurationHelper.Save("AnesDocName", value.ToString());
            }
        }


        public static bool IsShowUnDonePatientList
        {

            get
            {
                string key = "IsShowUnDonePatientList";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                bool result;
                if (bool.TryParse(text, out result))
                {
                    return result;
                }
                else
                {
                    return false;
                }
            }
            set
            {


                ApplicationConfiguration.ModifyConfigTable("IsShowUnDonePatientList", value.ToString());

            }
        }
        /// <summary>
        /// 是否复苏管理程序
        /// </summary>
        public static bool IsPACUProgram
        {
            get
            {
                string key = "IsPACUProgram";
                string text = ConfigurationHelper.Read(key);
                bool result;
                if (bool.TryParse(text, out result))
                {
                    return result;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                ConfigurationHelper.Save("IsPACUProgram", value.ToString());
            }
        }
        /// <summary>
        /// 是否护理系统
        /// </summary>
        public static bool IsNurseProgram
        {
            get
            {
                string key = "IsNurseProgram";
                string text = ConfigurationHelper.Read(key);
                bool result;
                if (bool.TryParse(text, out result))
                {
                    return result;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                ConfigurationHelper.Save("IsNurseProgram", value.ToString());
            }
        }
        /// <summary>
        /// 是否主任工作站
        /// </summary>
        public static bool IsDirectorProgram
        {
            get
            {
                string key = "IsDirectorProgram";
                string text = ConfigurationHelper.Read(key);
                bool result;
                if (bool.TryParse(text, out result))
                {
                    return result;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                ConfigurationHelper.Save("IsDirectorProgram", value.ToString());
            }
        }
        /// <summary>
        /// 是否更新排班程序状态
        /// </summary>
        public static bool IsUpdateScheduleStatus
        {
            get
            {
                string key = GetAppTypeKey("IsUpdateScheduleStatus");
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                bool result;
                if (bool.TryParse(text, out result))
                {
                    return result;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                string key = GetAppTypeKey("IsUpdateScheduleStatus");
                ApplicationConfiguration.ModifyConfigTable(key, value.ToString());
                ConfigurationHelper.Save(key, value.ToString());
            }
        }
        /// <summary>
        /// 是否更新HIS手术状态
        /// </summary>
        public static bool IsUpdateHisStatus
        {
            get
            {
                string key = GetAppTypeKey("IsUpdateHisStatus");
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                bool result;
                if (bool.TryParse(text, out result))
                {
                    return result;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                string key = GetAppTypeKey("IsUpdateHisStatus");
                ApplicationConfiguration.ModifyConfigTable(key, value.ToString());
                ConfigurationHelper.Save(key, value.ToString());
            }
        }
        /// <summary>
        /// 是否启用PACU管理
        /// </summary>
        public static bool IsPACUProcess
        {
            get
            {
                string key = GetAppTypeKey("IsPACUProcess");
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                bool result;
                if (bool.TryParse(text, out result))
                {
                    return result;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                string key = GetAppTypeKey("IsPACUProcess");
                ApplicationConfiguration.ModifyConfigTable(key, value.ToString());
                ConfigurationHelper.Save(key, value.ToString());
            }
        }
        /// <summary>
        /// 刷新时间间隔
        /// </summary>
        public static int RefreshTimeSpan
        {
            get
            {
                string key = "RefreshTimeSpan";
                string text = ConfigurationHelper.Read(key);
                int result;
                if (int.TryParse(text, out result))
                {
                    return result;
                }
                else
                {
                    return 60;
                }
            }
            set
            {
                ConfigurationHelper.Save("RefreshTimeSpan", value.ToString());
            }
        }
        public static string UserLoginName
        {
            get
            {
                string key = "UserLoginName";
                string text = ConfigurationHelper.Read(key);
                return text;
            }
            set
            {
                ConfigurationHelper.Save("UserLoginName", value.ToString());
            }
        }
        /// <summary>
        /// 选中患者后是否进转中登记
        /// </summary>
        public static bool IsCPBEditorFirst
        {
            get
            {
                string key = "IsCPBEditorFirst";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                bool result;
                if (bool.TryParse(text, out result))
                {
                    return result;
                }
                else
                {
                    return true;
                }
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("IsCPBEditorFirst", value.ToString());
            }
        }

        /// <summary>
        /// 是否双击才弹出下拉选择框
        /// </summary>
        public static bool DoubleSelect
        {
            get
            {
                string key = "DoubleSelect";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                bool result;
                if (bool.TryParse(text, out result))
                {
                    return result;
                }
                else
                {
                    return true;
                }
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("DoubleSelect", value.ToString());
            }
        }

        /// <summary>
        /// 标记修改过的体征项
        /// </summary>
        public static bool IsModifyVitalSignShowDifferent
        {
            get
            {
                string text = ConfigurationHelper.Read("IsModifyVitalSignShowDifferent");
                bool result = false;
                if (bool.TryParse(text, out result))
                {
                    return result;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                ConfigurationHelper.Save("IsModifyVitalSignShowDifferent", value.ToString());
            }
        }

        /// <summary>
        /// 是否保存麻醉单打印记录
        /// </summary>
        public static bool IsSaveAnesPrintRecord
        {
            get
            {
                string text = ConfigurationHelper.Read("IsSaveAnesPrintRecord");
                bool result = false;
                if (bool.TryParse(text, out result))
                {
                    return result;
                }
                else
                {
                    return true;
                }
            }
            set
            {
                ConfigurationHelper.Save("IsSaveAnesPrintRecord", value.ToString());
            }
        }


        public static bool IsShowMonitorData
        {
            get
            {
                string key = "IsShowMonitorData";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                bool result;
                if (bool.TryParse(text, out result))
                {
                    return result;
                }
                else
                {
                    return true;
                }
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("IsShowMonitorData", value.ToString());
            }
        }


        /// <summary>
        /// 开启主任模式
        /// </summary>
        public static bool AutoOperationRoomPandect
        {
            get
            {
                string key = "AutoOperationRoomPandect";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                bool result;
                if (bool.TryParse(text, out result))
                {
                    return result;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("AutoOperationRoomPandect", value.ToString());
            }
        }
        /// <summary>
        /// 开启同步
        /// </summary>
        public static bool SyncOpen
        {
            get
            {
                string key = "SyncOpen";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                bool result;
                if (bool.TryParse(text, out result))
                {
                    return result;
                }
                else
                {
                    return true;
                }
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("SyncOpen", value.ToString());
            }
        }

        /// <summary>
        /// 同步类
        /// </summary>
        public static string SyncAgentClassName
        {
            get
            {
                string key = GetAppTypeKey("SyncAgentClassName");
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                if (string.IsNullOrEmpty(text))
                {
                    text = "SyncLib,SyncAgent";
                }
                return text;
            }
            set
            {
                string key = GetAppTypeKey("SyncAgentClassName");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        public static Image GetSkinImage(string imgName)
        {
            string imgPath = ExtendApplicationContext.Current.AppPath + "\\Skin\\" + imgName.Trim();

            //加载皮肤
            Image image = null;
            try
            {
                image = Image.FromFile(imgPath);
            }
            catch (System.IO.FileNotFoundException ex)
            {
                ExceptionHandler.Handle(ex);
            }
            catch (System.OutOfMemoryException ex)
            {
                ExceptionHandler.Handle(ex);
            }
            return image;
        }

        //public static string AnesthesiaRecordClassName
        //{
        //    get
        //    {
        //        string key = GetAppTypeKey("AnesthesiaRecordClassName");
        //        //string text = ApplicationConfiguration.GetFromConfigTableDataTable(key);
        //        string text = "";//为了测试修改
        //        if (string.IsNullOrEmpty(text))
        //        {
        //            text = ConfigurationHelper.Read(key);
        //        }
        //        if (string.IsNullOrEmpty(text))
        //        {
        //            //text = "UILib,AnesthesiaRecordV1";
        //            text = "UILib,AnesthesiaRecordWuHanAsia";
        //        }
        //        return text;
        //    }
        //    set
        //    {

        //        string key = GetAppTypeKey("AnesthesiaRecordClassName");
        //        ApplicationConfiguration.ModifyConfigTable(key, value);
        //    }
        //}

        /// <summary>
        /// 根据表名获取配置数据表
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns>配置数据表</returns>
        public static void SaveDataTable(string dataSetFileName, DataTable dataTable)
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(dataSetFileName);
            if (dataSet.Tables.Contains(dataTable.TableName))
            {
                dataSet.Tables.Remove(dataSet.Tables[dataTable.TableName]);
            }
            if (dataTable.DataSet != null)
            {
                dataTable.DataSet.Tables.Remove(dataTable);
            }
            dataSet.Tables.Add(dataTable);
            dataSet.WriteXml(dataSetFileName);
        }

        public static string BloodGasTempletNames
        {
            get
            {
                string key = "BloodGasTempletNames";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                return text;
            }
            set
            {
                string key = "BloodGasTempletNames";
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        public static string AnesChargeDefaultItems
        {
            get
            {
                string key = "AnesChargeDefaultItems";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                return text;
            }
            set
            {
                string key = "AnesChargeDefaultItems";
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }




        /// <summary>
        /// 麻醉单单页时间长度
        /// </summary>
        public static int AnesDocRange
        {
            get
            {
                string key = "AnesDocRange";
                string text = ConfigurationHelper.Read("AnesDocRange");
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                if (!string.IsNullOrEmpty(text))
                {
                    int ret = 0;
                    if (!int.TryParse(text, out ret))
                    {
                        ret = 5;
                    }
                    if (ret <= 0)
                        ret = 5;
                    return ret;
                }
                else
                {

                    return 5;
                }
            }
            set
            {
                ConfigurationHelper.Save("AnesDocRange", value.ToString());
            }
        }

        /// <summary>
        /// PACU单单页时间长度
        /// </summary>
        public static int PACUDocRange
        {
            get
            {
                string key = "PACUDocRange";
                string text = ConfigurationHelper.Read("PACUDocRange");
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                if (!string.IsNullOrEmpty(text))
                {
                    int ret = 0;
                    if (!int.TryParse(text, out ret))
                    {
                        ret = 4;
                    }
                    if (ret <= 0)
                        ret = 4;
                    return ret;
                }
                else
                {
                    return 4;
                }
            }
            set
            {
                ConfigurationHelper.Save("PACUDocRange", value.ToString());
            }
        }


        /// <summary>
        /// 查询统计地址配置
        /// </summary>
        public static string AnesQueryAddress
        {
            get
            {
                string key = "AnesQueryAddress";
                string text = ConfigurationHelper.Read(key);
                if (!string.IsNullOrEmpty(text))
                {
                    return text;
                }
                else
                {
                    return "http://127.0.0.1/AnesQuery/Default.aspx";
                }
            }
            set
            {
                ConfigurationHelper.Save("AnesQueryAddress", value);
            }
        }

        /// <summary>
        /// 归档间隔
        /// </summary>
        public static int OperationDoneDays
        {
            get
            {
                string key = "OperationDoneDays";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                int days = 0;
                return int.TryParse(text, out days) ? days : 3;
            }
            set
            {
                string key = "OperationDoneDays";
                ApplicationConfiguration.ModifyConfigTable(key, value.ToString());
            }
        }

        /// <summary>
        /// 是否启用自动更新程序
        /// </summary>
        public static string IsAutoUpdateProgram
        {
            get
            {
                string key = "IsAutoUpdateProgram";
                string text = ConfigurationHelper.Read(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ApplicationConfiguration.GetFromConfigTable(key);
                }
                if (string.IsNullOrEmpty(text))
                {
                    text = "-1";
                }
                return text;
            }
            set
            {
                ConfigurationHelper.Save("IsAutoUpdateProgram", value);
                ApplicationConfiguration.ModifyConfigTable("IsAutoUpdateProgram", value);
            }
        }

        /// <summary>
        /// Add by LiuGuo 2018-07-11 anes-00010 复苏单是否延续麻醉单动态配置
        /// </summary>
        public static bool IsPacuLastToAnes
        {
            get
            {
                string key = "IsPacuLastToAnes";
                string text = ConfigurationHelper.Read(key);
                bool result;
                if (bool.TryParse(text, out result))
                {
                    return result;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                ConfigurationHelper.Save("IsPacuLastToAnes", value.ToString());
            }
        }

        /// <summary>
        /// 是否合并显示入出量栏
        /// </summary>
        public static bool IsTogether
        {
            get
            {
                string key = "IsTogether";
                if (_configurCache.ContainsKey(key))
                    return Convert.ToBoolean(_configurCache[key]);

                string s = GetFromConfigTable(key);
                //if (string.IsNullOrEmpty(s))
                //{
                //    s = ConfigurationManager.AppSettings[key];
                //}

                bool result;
                if (!bool.TryParse(s, out result))
                {
                    result = false;
                }

                if (!_configurCache.ContainsKey(key))
                    _configurCache.Add(key, result);

                return result;
            }
            set
            {
                string key = "IsTogether";
                ModifyConfigTable(key, value.ToString());
                if (_configurCache.ContainsKey(key))
                    _configurCache[key] = value;
            }
        }

        /// <summary>
        /// by xiaogang.zhang 处方编号当前值-精麻药(anes-00019)
        /// </summary>
        //public static string ChufangNumCurrent
        //{
        //    get
        //    {

        //        string key = "ChufangNumCurrent";
        //        string sql = string.Format("SELECT * FROM WIS_CONFIG_NOTBLOB WHERE PARAKEY='{0}'", key);
        //        DataTable dtconfig = new CommonDA().GetDataFromSQLString(sql);
        //        if (dtconfig != null && dtconfig.Rows.Count == 0)
        //        {
        //            sql = " INSERT INTO WIS_CONFIG_NOTBLOB VALUES ('ChufangNumCurrent','0')";
        //            new CommonDA().ExecuteNonQuery(sql);
        //        }
        //        DataTable configNotBlobTable = new ConfigurationDA().GetConfigTableDataTableByKey(key);
        //        int paravalue = 0;
        //        if (configNotBlobTable != null && configNotBlobTable.Rows.Count == 1)
        //        {
        //            paravalue = int.Parse(configNotBlobTable.Rows[0]["paravalue"].ToString());
        //        }
        //        paravalue++;
        //        return paravalue.ToString();
        //    }
        //    set
        //    {
        //        string key = "ChufangNumCurrent";
        //        new ConfigurationDA().UpdateConfigTableDataTableByKey(key, value);
        //    }
        //}

        /// <summary>
        /// 实时状态界面手术科室下拉选择
        /// </summary>
        public static string OperationRoom
        {
            get
            {
                string key = "OperationRoom";
                string text = ConfigurationHelper.Read(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ApplicationConfiguration.GetFromConfigTable(key);
                }

                if (text == null)
                {
                    return string.Empty;
                }
                return text;
            }
            set
            {
                string key = "OperationRoom";
                ConfigurationHelper.Save(key, value);
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        #region add by shiyu.duan for 主板本升级 anes-00055 实现各手术间文字通讯
        /// <summary>
        /// 是否开启即时通讯
        /// </summary>
        public static bool HasCommunicatorService
        {
            get
            {
                string key = "HasCommunicatorService";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                bool result;
                if (bool.TryParse(text, out result))
                {
                    return result;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("HasCommunicatorService", value.ToString());
            }
        }

        /// <summary>
        /// 通讯服务端地址
        /// </summary>
        public static string CommunicatorService
        {
            get
            {
                string key = "CommunicatorService";
                string text = ApplicationConfiguration.GetFromConfigTable(key);

                if (text == null)
                {
                    return string.Empty;
                }
                return text;
            }
            set
            {
                string key = "CommunicatorService";
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }
        #endregion

        // add by zhouxx on 20180614 for 主版本升级 anes-00046 术中事件排序
        /// <summary>
        /// 是否开始智能排序
        /// </summary>
        public static bool IsOpenAISort
        {
            get
            {
                string key = "IsOpenAISort";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                bool result;
                if (bool.TryParse(text, out result))
                {
                    return result;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("IsOpenAISort", value.ToString());
            }
        }
        // end

        // add by zhouxx on 20180622 for 主版本升级 anes-00057 注册热键
        /// <summary>
        /// 是否开启热键
        /// </summary>
        public static bool IsOpenShortCuts
        {
            get
            {
                string key = "IsOpenShortCuts";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                bool result;
                if (bool.TryParse(text, out result))
                {
                    return result;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("IsOpenShortCuts", value.ToString());
            }
        }
        // end

        /// <summary>
        /// 是否开启安全核查
        /// </summary>
        public static bool IsSafetyVerification
        {
            get
            {
                string key = "IsSafetyVerification";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                bool result;
                if (bool.TryParse(text, out result))
                {
                    return result;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("IsSafetyVerification", value.ToString());
            }
        }

        public static bool EnableProphet
        {
            get
            {
                string key = "EnableProphet";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                bool result;
                if (bool.TryParse(text, out result))
                {
                    return result;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("EnableProphet", value.ToString());
            }
        }

        public static bool EnableLocalProphet
        {
            get
            {
                string key = "EnableLocalProphet";
                string text = ConfigurationHelper.Read(key);
                bool result;
                if (bool.TryParse(text, out result))
                {
                    return result;
                }
                else
                {
                    return true;
                }
            }
            set
            {
                ConfigurationHelper.Save("EnableLocalProphet", value.ToString());
            }
        }

        public static int ProphetOverallOption
        {
            get
            {
                string key = "ProphetOverallOption";
                if (_configurCache.ContainsKey(key))
                    return Convert.ToInt32(_configurCache[key]);

                string s = GetFromConfigTable(key);
                if (string.IsNullOrEmpty(s))
                {
                    s = ConfigurationHelper.Read(key);
                }
                int ret = 0;
                if (!int.TryParse(s, out ret))
                {
                    ret = 0;
                }

                if (!_configurCache.ContainsKey(key))
                    _configurCache.Add(key, ret);

                return ret;
            }
            set
            {
                string key = "ProphetOverallOption";
                ModifyConfigTable(key, value.ToString());
                if (_configurCache.ContainsKey(key))
                    _configurCache[key] = value;
            }
        }

        public static int ButtonCandidates
        {
            get
            {
                string key = "ButtonCandidates";
                if (_configurCache.ContainsKey(key))
                    return Convert.ToInt32(_configurCache[key]);

                string s = GetFromConfigTable(key);
                if (string.IsNullOrEmpty(s))
                {
                    s = ConfigurationHelper.Read(key);
                }
                int ret = 2;
                if (!int.TryParse(s, out ret))
                {
                    ret = 2;
                }

                if (!_configurCache.ContainsKey(key))
                    _configurCache.Add(key, ret);

                return ret;
            }
            set
            {
                string key = "ButtonCandidates";
                ModifyConfigTable(key, value.ToString());
                if (_configurCache.ContainsKey(key))
                    _configurCache[key] = value;
            }
        }

        public static int ButtonMinimum
        {
            get
            {
                string key = "ButtonMinimum";
                if (_configurCache.ContainsKey(key))
                    return Convert.ToInt32(_configurCache[key]);

                string s = GetFromConfigTable(key);
                if (string.IsNullOrEmpty(s))
                {
                    s = ConfigurationHelper.Read(key);
                }
                int ret = 2;
                if (!int.TryParse(s, out ret))
                {
                    ret = 2;
                }

                if (!_configurCache.ContainsKey(key))
                    _configurCache.Add(key, ret);

                return ret;
            }
            set
            {
                string key = "ButtonMinimum";
                ModifyConfigTable(key, value.ToString());
                if (_configurCache.ContainsKey(key))
                    _configurCache[key] = value;
            }
        }

        public static int DocumentCadidates
        {
            get
            {
                string key = "DocumentCadidates";
                if (_configurCache.ContainsKey(key))
                    return Convert.ToInt32(_configurCache[key]);

                string s = GetFromConfigTable(key);
                if (string.IsNullOrEmpty(s))
                {
                    s = ConfigurationHelper.Read(key);
                }
                int ret = 2;
                if (!int.TryParse(s, out ret))
                {
                    ret = 2;
                }

                if (!_configurCache.ContainsKey(key))
                    _configurCache.Add(key, ret);

                return ret;
            }
            set
            {
                string key = "DocumentCadidates";
                ModifyConfigTable(key, value.ToString());
                if (_configurCache.ContainsKey(key))
                    _configurCache[key] = value;
            }
        }

        public static int DocumentMinimum
        {
            get
            {
                string key = "DocumentMinimum";
                if (_configurCache.ContainsKey(key))
                    return Convert.ToInt32(_configurCache[key]);

                string s = GetFromConfigTable(key);
                if (string.IsNullOrEmpty(s))
                {
                    s = ConfigurationHelper.Read(key);
                }
                int ret = 2;
                if (!int.TryParse(s, out ret))
                {
                    ret = 2;
                }

                if (!_configurCache.ContainsKey(key))
                    _configurCache.Add(key, ret);

                return ret;
            }
            set
            {
                string key = "DocumentMinimum";
                ModifyConfigTable(key, value.ToString());
                if (_configurCache.ContainsKey(key))
                    _configurCache[key] = value;
            }
        }

        public static int EventCandidates
        {
            get
            {
                string key = "EventCandidates";
                if (_configurCache.ContainsKey(key))
                    return Convert.ToInt32(_configurCache[key]);

                string s = GetFromConfigTable(key);
                if (string.IsNullOrEmpty(s))
                {
                    s = ConfigurationHelper.Read(key);
                }
                int ret = 2;
                if (!int.TryParse(s, out ret))
                {
                    ret = 2;
                }

                if (!_configurCache.ContainsKey(key))
                    _configurCache.Add(key, ret);

                return ret;
            }
            set
            {
                string key = "EventCandidates";
                ModifyConfigTable(key, value.ToString());
                if (_configurCache.ContainsKey(key))
                    _configurCache[key] = value;
            }
        }

        public static int EventMinimum
        {
            get
            {
                string key = "EventMinimum";
                if (_configurCache.ContainsKey(key))
                    return Convert.ToInt32(_configurCache[key]);

                string s = GetFromConfigTable(key);
                if (string.IsNullOrEmpty(s))
                {
                    s = ConfigurationHelper.Read(key);
                }
                int ret = 2;
                if (!int.TryParse(s, out ret))
                {
                    ret = 2;
                }

                if (!_configurCache.ContainsKey(key))
                    _configurCache.Add(key, ret);

                return ret;
            }
            set
            {
                string key = "EventMinimum";
                ModifyConfigTable(key, value.ToString());
                if (_configurCache.ContainsKey(key))
                    _configurCache[key] = value;
            }
        }

        public static int TempletCandidates
        {
            get
            {
                string key = "TempletCandidates";
                if (_configurCache.ContainsKey(key))
                    return Convert.ToInt32(_configurCache[key]);

                string s = GetFromConfigTable(key);
                if (string.IsNullOrEmpty(s))
                {
                    s = ConfigurationHelper.Read(key);
                }
                int ret = 2;
                if (!int.TryParse(s, out ret))
                {
                    ret = 2;
                }

                if (!_configurCache.ContainsKey(key))
                    _configurCache.Add(key, ret);

                return ret;
            }
            set
            {
                string key = "TempletCandidates";
                ModifyConfigTable(key, value.ToString());
                if (_configurCache.ContainsKey(key))
                    _configurCache[key] = value;
            }
        }
    }
}
