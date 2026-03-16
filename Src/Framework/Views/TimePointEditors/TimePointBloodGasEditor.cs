using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.Framework.Controls.Base;
using Wis.Anes.BusinessEntity;
using Wis.Anes.DataAccess;

namespace Wis.Anes.Framework
{
    [ToolboxItem(false)]
    public partial class TimePointBloodGasEditor1 : UserControl
    {
        public TimePointBloodGasEditor1()
        {
            InitializeComponent();
        }

        public TimePointBloodGasEditor1(string patientID, decimal visitID, decimal operID, decimal eventNo)
            : this()
        {
            _patientID = patientID;
            _visitID = visitID;
            _operID = operID;
            _eventNo = eventNo;
        }

        private string _patientID;
        private decimal _visitID, _operID;
        private decimal _eventNo = 0;
        private string _key = "";
        private DateTime _timePoint;

        public bool IsDirty
        {
            get
            {
                if (dataGridView1.IsCurrentCellDirty)
                {
                    dataGridView1.NotifyCurrentCellDirty(true);
                    btnSave.Enabled = true;
                    btnSave.Focus();
                }
                return btnSave.Enabled;
            }
        }

        private bool _isSaved = false;
        public bool IsSaved
        {
            get
            {
                return _isSaved;
            }
        }

        private bool IsDateTimeSame(DateTime dt1, DateTime dt2)
        {
            return dt1.Date.Equals(dt2.Date) && dt1.Hour.Equals(dt2.Hour) && dt2.Minute.Equals(dt1.Minute);
        }

        private bool SaveBloodGas()
        {
            CareDocs.BloodGasMasterDataTable bloodGasMasterDataTable = new CareDocsDA().GetBloodGasMasterTable(_patientID, _visitID, _operID);
            string detailID = "";
            if (bloodGasMasterDataTable != null && bloodGasMasterDataTable.Count > 0)
            {
                foreach (CareDocs.BloodGasMasterRow row in bloodGasMasterDataTable)
                {
                    if (IsDateTimeSame(row.RECORD_DATE_TIME, _timePoint))
                    {
                        detailID = row.DETAIL_ID;
                        if (radioGroupBloodGasTypes.SelectedIndex == 1)
                        {
                            row.NURSE_MEMO_1 = "动脉";
                        }
                        else
                        {
                            row.SetNURSE_MEMO_1Null();
                        }
                        break;
                    }
                }
            }
            if (string.IsNullOrEmpty(detailID))
            {
                detailID = _timePoint.ToString("yyyy-MM-dd HH:mm") + "|" + Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10);
                CareDocs.BloodGasMasterRow row = bloodGasMasterDataTable.NewBloodGasMasterRow();
                row.PAT_ID = _patientID;
                row.VISIT_ID = _visitID;
                row.OPER_ID = _operID;
                row.RECORD_DATE_TIME = _timePoint;
                row.OP_DATE_TIME = DateTime.Now;
                row.OPERATOR = ExtendApplicationContext.Current.LoginUserContext.UserID + "[" + ExtendApplicationContext.Current.LoginUserContext.UserName + "]";
                row.DETAIL_ID = detailID;
                if (radioGroupBloodGasTypes.SelectedIndex == 1)
                {
                    row.NURSE_MEMO_1 = "动脉";
                }
                else
                {
                    row.SetNURSE_MEMO_1Null();
                }
                row.NURSE_MEMO_2 = "麻醉单专用";
                bloodGasMasterDataTable.AddBloodGasMasterRow(row);
            }
            if(new CareDocsDA().UpdateBloodGasMaster(bloodGasMasterDataTable) < 0)
            {
                return false;
            }
            CareDocs.BloodGasDetailDataTable detailTable = new CareDocsDA().GetBloodGasDetailTable(detailID);
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                string blgCode = row.Cells[0].Value.ToString();
                CareDocs.BloodGasDetailRow detailRow = detailTable.FindByDETAIL_IDBLG_CODE(detailID,blgCode);
                if (detailRow == null)
                {
                    detailRow = detailTable.NewBloodGasDetailRow();
                    detailRow.DETAIL_ID = detailID;
                    detailRow.BLG_CODE = blgCode;
                    detailTable.AddBloodGasDetailRow(detailRow);
                }
                detailRow.OP_DATE = DateTime.Now;
                detailRow.OPERATOR = ExtendApplicationContext.Current.LoginUserContext.UserID + "[" + ExtendApplicationContext.Current.LoginUserContext.UserName + "]";
                string value = "";
                if(row.Cells[2].Value != null && row.Cells[2].Value != System.DBNull.Value)
                {
                    value = row.Cells[2].Value.ToString();
                }
                detailRow.BLG_VALUE = value;
            }
            int ret = new CareDocsDA().UpdateBloodGasDetail(detailTable);
            if(ret > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Save()
        {
            bool saved = false;
            if (SaveBloodGas())
            {
                saved = true;
                _isSaved = true;
                btnSave.Enabled = false;
                btnRefresh.Enabled = false;
                //label1.ForeColor = Color.Blue;
                //label1.Text = "保存成功";
            }
            return saved;
        }

        public void LocateKey(string key)
        {
            _key = key;
        }

        public bool GetVitalValues(DateTime timePoint)
        {
            _timePoint = timePoint;
            dataGridView1.CellValueChanged -= new DataGridViewCellEventHandler(dataGridView1_CellValueChanged);
            LoadDefalutList();
            dataGridView1.CellValueChanged += new DataGridViewCellEventHandler(dataGridView1_CellValueChanged);
            return true;
        }

        public static List<string> BloodGasDetailList
        {
            get
            {
                //return new List<string>(new string[] { "PH", "PCO2", "PO2", "K+", "Ca", "Glu", "Lac", "Hct", "Be", "Hb", "SO2C"});
                return new List<string>(new string[] { "pH", "pCO2", "pO2", "K+", "Ca++", "Glu", "Lac", "Hct", "BE", "Hb", "SO2c" });
            }
        }

        private Dictionary<string, string> bloodGasDict = null;
        private Dictionary<string, string> BloodGasDict
        {
            get
            {
                if (bloodGasDict == null)
                {
                    bloodGasDict = new Dictionary<string, string>();
                    Dict.BloodGasDictDataTable dataTable = new DictDA().GetBloodGasDict();
                    foreach (Dict.BloodGasDictRow drow in dataTable.Rows)
                    {
                        bloodGasDict.Add(drow.BLG_CODE, drow.BLG_NAME);
                    }

                }
                return bloodGasDict;
            }
        }

        private List<BloodGasMaster> GetBloodGasItems(string patientID, decimal visitID, decimal operID)
        {
            List<BloodGasMaster> list = new List<BloodGasMaster>();
            CareDocs.BloodGasMasterDataTable bloodGasMasterDataTable = new CareDocsDA().GetBloodGasMasterTable(patientID, visitID, operID);
            if (bloodGasMasterDataTable != null)
            {
                foreach (CareDocs.BloodGasMasterRow row in bloodGasMasterDataTable)
                {
                    string typeName = "静脉";
                    if (!row.IsNURSE_MEMO_1Null() && !string.IsNullOrEmpty(row.NURSE_MEMO_1))
                    {
                        typeName = row.NURSE_MEMO_1;
                    }
                    BloodGasMaster item = GetBloodGasMaster(typeName + "血气", row.DETAIL_ID, patientID, visitID, operID);
                    if (item != null)
                    {
                        list.Add(item);
                    }
                }
            }
            return list;
        }

        private BloodGasMaster GetBloodGasMaster(string displayName, string detailID, string patientID, decimal visitID, decimal operID)
        {
            if (string.IsNullOrEmpty(displayName) || string.IsNullOrEmpty(detailID))
            {
                return null;
            }
            //DataSetModel.CareDocs.BloodGasMasterDataTable bloodGasMasterDataTable = DataHelper.GetBloodGasMasterTable(patientID, visitID, operID);
            CareDocs.BloodGasMasterDataTable bloodGasMasterDataTable = new CareDocsDA().GetBloodGasMasterTable(detailID);
            if (bloodGasMasterDataTable == null || bloodGasMasterDataTable.Count == 0)
            {
                return null;
            }
            CareDocs.BloodGasDetailDataTable bloodGasDetailDataTable = new CareDocsDA().GetBloodGasDetailTable(detailID);
            if (bloodGasDetailDataTable == null || bloodGasDetailDataTable.Count == 0)
            {
                return null;
            }
            DataRow[] rows = bloodGasMasterDataTable.Select("DETAIL_ID = '" + detailID + "'");
            if (rows == null || rows.Length != 1)
            {
                return null;
            }
            BloodGasMaster item = new BloodGasMaster();
            item.DisplayName = displayName;
            item.Recorddate = (DateTime)rows[0]["RECORD_DATE"];
            List<string> list = BloodGasDetailList;
            foreach (string itemString in list)
            {
                CareDocs.BloodGasDetailRow row = bloodGasDetailDataTable.FindByDETAIL_IDBLG_CODE(detailID, itemString);
                if (row != null && !row.IsBLG_VALUENull())
                {
                    item.Details.Add(GetBloodGasDetail(itemString, row.BLG_VALUE));
                }
                else
                {
                    item.Details.Add(GetBloodGasDetail(itemString, ""));
                }
            }
            return item;
        }

        private BloodGasDetail GetBloodGasDetail(string code, object value)
        {
            BloodGasDetail item = new BloodGasDetail();
            item.BloodGasCode = code;
            item.BloodGasValue = value.ToString();
            return item;
        }

        private BloodGasMaster GetBloodGasItem(string patientID, decimal visitID, decimal operID, DateTime timePoint)
        {
            CareDocs.BloodGasMasterDataTable bloodGasMasterDataTable = new CareDocsDA().GetBloodGasMasterTable(patientID, visitID, operID);
            if (bloodGasMasterDataTable != null)
            {
                foreach (CareDocs.BloodGasMasterRow row in bloodGasMasterDataTable)
                {
                    if (IsDateTimeSame(row.RECORD_DATE_TIME, timePoint))
                    {

                        string typeName = "静脉";
                        if (!row.IsNURSE_MEMO_1Null() && !string.IsNullOrEmpty(row.NURSE_MEMO_1))
                        {
                            typeName = row.NURSE_MEMO_1;
                        }
                        BloodGasMaster item = GetBloodGasMaster(typeName + "血气", row.DETAIL_ID, patientID, visitID, operID);
                        return item;
                    }
                }
            }
            return null;
        }

        private void LoadDefalutList()
        {
            BloodGasMaster bloodGasMaster = GetBloodGasItem(_patientID, _visitID, _operID, _timePoint);
            if (bloodGasMaster != null)
            {
                LoadDefalutList(bloodGasMaster);
            }
            else
            {
                dataGridView1.Rows.Clear();
                List<string> list = BloodGasDetailList;
                if (list != null)
                {
                    foreach (string text in list)
                    {
                        string name = text;
                        if (BloodGasDict.ContainsKey(text))
                        {
                            name = BloodGasDict[text];
                        }
                        dataGridView1.Rows.Add(new object[] { text, name, null });
                    }
                }
            }
        }

        private void LoadDefalutList(BloodGasMaster bloodGasMaster)
        {
            dataGridView1.Rows.Clear();
            foreach (BloodGasDetail detail in bloodGasMaster.Details)
            {
                string name = detail.BloodGasCode;
                if (BloodGasDict.ContainsKey(detail.BloodGasCode))
                {
                    name = BloodGasDict[detail.BloodGasCode];
                }
                dataGridView1.Rows.Add(new object[] { detail.BloodGasCode, name, detail.BloodGasValue });
            }
            if (bloodGasMaster.DisplayName.StartsWith("动脉"))
            {
                radioGroupBloodGasTypes.SelectedIndex = 1;
            }
            btnSave.Enabled = true;
        }

       private void WHYX_TimePointBloodGasEditor_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            btnSave.EnabledChanged += new EventHandler(btnSave_EnabledChanged);
        }

        private static readonly object _isDirtyChanged = new object();
        public event EventHandler IsDirtyChanged
        {
            add
            {
                Events.AddHandler(_isDirtyChanged, value);
            }
            remove
            {
                Events.RemoveHandler(_isDirtyChanged, value);
            }
        }

        private void btnSave_EnabledChanged(object sender, EventArgs e)
        {
            EventHandler eventHandle = Events[_isDirtyChanged] as EventHandler;
            if (eventHandle != null)
            {
                eventHandle(this, e);
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                Wis.Anes.Framework.Utilities.GridViewHelper.DataGridViewCellPainting(e);
            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 1 && e.RowIndex >= 0)
            {
                timer1.Enabled = true;
            }
        }

        private bool _isFirstFocus = true;
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if (_isFirstFocus)
            {
                _isFirstFocus = false;
                dataGridView1.Focus();
                dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[2];
                dataGridView1.BeginEdit(true);
            }
            try
            {
                if (dataGridView1.Focused)
                {
                    int rowIndex = dataGridView1.CurrentRow.Index;
                    dataGridView1.CurrentCell = dataGridView1.Rows[rowIndex].Cells[2];
                    dataGridView1.BeginEdit(true);
                }
            }
            catch { }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[2].Value = null;
            }
        }

        private bool ShowBloodGasSelector(ref string selectedList, string patientID, decimal visitID, decimal operID, ref Dictionary<string, bool> typeList)
        {
            return ShowBloodGasSelector(ref selectedList, patientID, visitID, operID, ref typeList, true, true, true);
        }

        private bool ShowBloodGasSelector(ref string selectedList, string patientID, decimal visitID, decimal operID, ref Dictionary<string, bool> typeList, bool allowSwitchAE, bool showTip, bool mulitSelect)
        {
            BloodGasSelector1 bloodGasSelector = new BloodGasSelector1(patientID, visitID, operID);
            bloodGasSelector.SelectedList = selectedList;
            bloodGasSelector.SetDate(DateTime.Today);
            bloodGasSelector.AllowSwitchAE = allowSwitchAE;
            bloodGasSelector.MulitSelect = mulitSelect;
            bloodGasSelector.ShowTip = showTip;
            DialogHostForm1 dialogHostForm = new DialogHostForm1("选择要显示的血气", bloodGasSelector.Width, bloodGasSelector.Height);
            dialogHostForm.Child = bloodGasSelector;
            dialogHostForm.ShowDialog();
            bool ret = bloodGasSelector.IsSelected;
            if (ret)
            {
                typeList = bloodGasSelector.TypeList;
                selectedList = bloodGasSelector.SelectedList;
            }
            return ret;
        }

        private void btnSelectBloodGas_Click(object sender, EventArgs e)
        {
            string selectedList = "";
            Dictionary<string,bool> typeList = new Dictionary<string,bool>();
            if (ShowBloodGasSelector(ref selectedList, _patientID, _visitID, _operID, ref typeList, false, false, false))
            {
                BloodGasMaster bloodGasMaster = GetBloodGasMaster("静脉", selectedList, _patientID, _visitID, _operID);
                if (bloodGasMaster != null)
                {
                    LoadDefalutList(bloodGasMaster);
                    if (!string.IsNullOrEmpty(selectedList))
                    {
                        CareDocs.BloodGasMasterDataTable bloodGasMasterDataTable = new CareDocsDA().GetBloodGasMasterTable(selectedList);
                        DataRow[] rows = bloodGasMasterDataTable.Select("DETAIL_ID = '" + selectedList + "'");
                        if (rows != null && rows.Length == 1)
                        {
                            CareDocs.BloodGasMasterRow row = rows[0] as CareDocs.BloodGasMasterRow;
                            if (row.PAT_ID.Equals("0"))
                            {
                                row.PAT_ID = _patientID;
                                new CareDocsDA().UpdateBloodGasMaster(bloodGasMasterDataTable);
                            }
                        }
                    }

                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void radioGroupBloodGasTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

    }
}
