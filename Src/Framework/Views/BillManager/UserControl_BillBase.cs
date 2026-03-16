/*----------------------------------------------------------------
      //北京拓扑工厂科技发展有限公司
      // 文件名：UserControl_BillBase.cs
      // 文件功能描述：收费管理基础控件
      //
      // 
      // 创建标识：XXX-2011-09-23
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.DataAccess;
using Wis.Anes.Framework.Utilities;
using Wis.Anes.Framework.Configurations;
using Wis.Anes.BusinessEntity;
using Wis.Anes.Framework.Permissions;

namespace Wis.Anes.Framework.Views.BillManager
{
    [ToolboxItem(false)]
    public partial class UserControl_BillBase : BaseView
    {
        private UserControl_BillBody _body;
        private string _patientID;
        private string _patientName;
        private decimal _visitID, _operID;
        private decimal _billType;

        public UserControl_BillBase():this(true,null,null, 0,0,1)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="showLeftList"></param>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <param name="billType">收费类别：1-麻醉，2-手术</param>
        public UserControl_BillBase(bool showLeftList,string patientID, string patientName, decimal visitID,decimal operID,decimal billType)
        {
            _patientID = patientID;
            _visitID = visitID;
            _operID = operID;
            _patientName = patientName;
            _billType = billType;

            InitializeComponent();

          

            if (patientName != null && patientID != null)
            {
                labelPatientName.Text = patientName + " " + patientID;
                if (!BillHelper.GetChargeDoctor(patientID, visitID))
                {
                    Dialog.MessageBox("没找到该患者所在科室", MessageBoxIcon.Exclamation);
                }
            }
            else
                labelPatientName.Text = "";

            if (showLeftList)
            {
                UserControl_BillLeftList leftList;
                if (!string.IsNullOrEmpty(patientID))
                {
                    leftList = new UserControl_BillLeftList(BillHelper.GetAnesthesiaEvent(patientID, visitID, operID));
                }
                else
                {
                    leftList = new UserControl_BillLeftList();
                }
                pnlBody.Controls.Add(leftList);
                leftList.Dock = DockStyle.Left;
            }
            if (!string.IsNullOrEmpty(patientID))
            {
                DataTable dtBill = BillHelper.GetAnesthesiaBill(patientID, visitID, operID, Convert.ToInt32(billType));
                _body = new UserControl_BillBody(dtBill, Convert.ToInt32(billType));
            }
            else
            {
                _body = new UserControl_BillBody(Convert.ToInt32(billType));
            }
            pnlBody.Controls.Add(_body);
            _body.BringToFront();
            _body.Dock = DockStyle.Fill;

            this.ParentChanged += new EventHandler(UserControl_BillBase_ParentChanged);

            bool HasRight = false;
            if (_billType == 1) // 麻醉收费
            {
                HasRight = ((AccessControl.PermissionProviderCustom.GetAnesBillRightType("麻醉收费") & PermissionContext.RightType.Modify) == PermissionContext.RightType.Modify);
            }
            else
            {
                HasRight = ((AccessControl.PermissionProviderCustom.GetOperBillRightType("手术收费") & PermissionContext.RightType.Modify) == PermissionContext.RightType.Modify);
            }

            _body.Enabled = HasRight;
            btnAdd.Visible = HasRight;
            btnDelete.Visible = HasRight;
            btnClear.Visible = HasRight;
            btnSave.Visible = HasRight;
            btnConfirm.Visible = HasRight;
            btnApplyModel.Visible = HasRight;
            btnRefreshPrice.Visible = HasRight;

            if (!AccessControl.CheckModifyRight("模板管理"))
            {
                btnSaveModel.Visible = false;
            }

            if (_billType == 1 && AccessControl.CheckModifyRight("麻醉退费"))
                btnEnd.Visible = true;
            else
                btnEnd.Visible = false;

        }

      
        private void btnSave_Click(object sender, EventArgs e)
        {
            _body.RefreshPrice();
            _body.CalculateSumCost();

            if (!_body.IsValidData())
            {
                Dialog.MessageBox("还有没填写完整的数据或数据有问题", MessageBoxIcon.Exclamation);
                return;
            }

            int result = BillHelper.Save(_body.DataSource);
            if (result > 0)
            {
                Dialog.MessageBox(string.Format("保存成功，共保存了{0}条数据！", result.ToString()));
            }
            else
            {
                Dialog.MessageBox("当前没有可保存数据！");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _body.DeleteRow(_patientID, _visitID, _operID, _billType);
            _body.CalculateSumCost();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if ((_billType == 1 && !AccessControl.CheckModifyRight("麻醉退费")) || _billType == 0 && !AccessControl.CheckModifyRight("手术退费"))
            {
                if (_body.HasConfirmFee())
                {
                    Dialog.MessageBox("该病人已收过费，您没有权限再次收费");
                    return;
                }
            }
            BillHelper.AddRow(_body.DataSource,_patientID,_visitID,_operID, _billType);
        }

        private void btnSaveModel_Click(object sender, EventArgs e)
        {
            if (!_body.IsValidData())
            {
                Dialog.MessageBox("还有没填写完整的数据", MessageBoxIcon.Exclamation);
                return ;
            }

            BusinessEntity.Configuations.DocumentDataTable dataTable = null;
            string strTempletName = "";
            string modelName = ShowTempletSelect(false, ref dataTable, ref strTempletName);
            if (modelName != null)
            {
                ApplicationConfiguration.ModifyDocumentTable(dataTable, strTempletName, modelName.ToString(), BillHelper.TransModelData(_body.DataSource));
                int ret = new ConfigurationDA().UpdateDocument(dataTable);
                if (ret > 0)
                {
                    Dialog.MessageBox("保存模板" + modelName.ToString() + "成功");
                }
            }
        }

        private void btnApplyModel_Click(object sender, EventArgs e)
        {
            if ((_billType == 1 && !AccessControl.CheckModifyRight("麻醉退费")) || _billType == 0 && !AccessControl.CheckModifyRight("手术退费"))
            {
                if (_body.HasConfirmFee())
                {
                    Dialog.MessageBox("该病人已收过费，您没有权限再次收费");
                    return;
                }
            }

            BusinessEntity.Configuations.DocumentDataTable dataTable = null;
            string strTempletName = "" ;
            string modelName = ShowTempletSelect(true, ref dataTable, ref strTempletName);
            if (modelName != null)
            {
                DataTable modelData = ApplicationConfiguration.GetDataTableDocumentTable(dataTable, strTempletName, modelName);
                
                
                BillHelper.CopyModelData(_body.DataSource, modelData, _patientID, _visitID, _operID, _billType);
                _body.RefreshPrice();
                _body.CalculateSumCost();
                
            }
        }


        protected string ShowTempletSelect(bool isSelect, ref BusinessEntity.Configuations.DocumentDataTable dataTable, ref string strTempletName)
        {
            // 列出所有模板
            dataTable = new ConfigurationDA().GetDocument();
            List<string> list = new List<string>();
            strTempletName = _billType == 0 ? "手术收费模板" : "麻醉收费模板";

            foreach (Wis.Anes.BusinessEntity.Configuations.DocumentRow row in dataTable)
            {
                if (row.DOCUMENTNAME.Equals(strTempletName) && !list.Contains(row.DOCUMENTPATH))
                {
                    list.Add(row.DOCUMENTPATH);
                }
            }

            string title = isSelect ? "套用模板" : "保存模板";
            UserControl_BillTempletSelect selectCtrl = new UserControl_BillTempletSelect(list, isSelect);
            DialogHostForm1 dialogHostForm = new DialogHostForm1(title, 380, 170);
            dialogHostForm.Child = selectCtrl;
            if (dialogHostForm.ShowDialog() == DialogResult.OK)
                return selectCtrl.TempletName;
            else
                return null;
        }

        // 确认收费
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if ((_billType == 1 && !AccessControl.CheckModifyRight("麻醉退费")) || _billType == 0 && !AccessControl.CheckModifyRight("手术退费"))
            {
                if (_body.HasConfirmFee())
                {
                    Dialog.MessageBox("该病人已收过费，您没有权限再次收费");
                    return;
                }
            }

            _body.RefreshPrice();
            _body.CalculateSumCost();
            if (!_body.IsValidData())
            {
                Dialog.MessageBox("还有没填写完整的数据或数据有问题", MessageBoxIcon.Exclamation);
                return;
            }

            if (Dialog.MessageBox("该病人总计费用：" + _body.FullCost + "元，是否确认收费？", "收费确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return; 

            _body.SetConfirmFlag(2, 0);
            int result = BillHelper.Save(_body.DataSource);
            if (result > 0)
            {
                SyncDA da = new SyncDA();
                string ret = da.SyncBillItems(_patientID, Convert.ToInt32(_visitID), Convert.ToInt32(_operID), Convert.ToInt32(_billType));

                if (!string.IsNullOrEmpty(ret))
                {
                    _body.SetConfirmFlag(0, 2);
                    result = BillHelper.Save(_body.DataSource);
                    ExceptionHandler.Handle(new Exception("提交收费到HIS失败\r\n" + ret));
                }
                else
                {
                    _body.SetConfirmFlag(1, 2);
                    result = BillHelper.Save(_body.DataSource);
                    if(result > 0)
                        Dialog.MessageBox("提交收费到HIS成功");
                    else
                        Dialog.MessageBox("提交收费到HIS成功，但更新标志失败，请确认数据库连接；\n\r并在下次进入时该界面时确认提交HIS成功", MessageBoxIcon.Exclamation);
                }
            }
            
        }

        private void btnRefreshPrice_Click(object sender, EventArgs e)
        {
            _body.RefreshPrice();
            _body.CalculateSumCost();
        }

    
        private void UserControl_BillBase_ParentChanged(object sender, EventArgs e)
        {
            Form formParent = Parent as Form;
            if (formParent == null)
                return;

            formParent.Shown += new EventHandler(UserControl_FormParent_Shown);
        }

        // 父窗体显示时,检查收费标志是否有异常
        private void UserControl_FormParent_Shown(object sender, EventArgs e)
        {
            if (_body.HasAbnormalConfirmFlag())
            {
                int result = 0;
                if (MessageBox.Show("上次收费提交HIS是否成功?", "数据库中有上次收费异常数据标志", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    result = 1;

                _body.SetConfirmFlag(result, 2);
                _body.Refresh();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (Dialog.MessageBox("确定要清除未收费的记录吗？", Dialog.CAPTION, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                _body.DeleteAllRowButHIS();
        }

        // 收费结束
        private void btnEnd_Click(object sender, EventArgs e)
        {
            if (Dialog.MessageBox("确认结束对该病人的收费，允许其出院吗？", "结束确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            SyncDA da = new SyncDA();
            string ret = da.SyncEndBill(_patientID, Convert.ToInt32(_visitID), Convert.ToInt32(_operID));

            if (!string.IsNullOrEmpty(ret))
            {
                ExceptionHandler.Handle(new Exception("提交结束标志到HIS失败\r\n" + ret));
            }
            else
            {
                Dialog.MessageBox("提交结束标志到HIS成功", MessageBoxIcon.Exclamation);
            }
        }
    }
}
