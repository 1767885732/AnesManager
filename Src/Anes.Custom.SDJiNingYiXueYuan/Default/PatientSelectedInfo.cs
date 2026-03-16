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
using Wis.Anes.Framework.Doc;
using Wis.Anes.Framework.Documents.DefaultHandlers;
using Wis.Anes.Framework.Controls;

namespace Wis.Anes.Custom.CustomProject.Default
{
    public partial class PatientSelectedInfo : BaseDoc
    {
        string _patientID;
        decimal _visitID;
        decimal _operID;

       
        public PatientSelectedInfo()
            : this(ExtendApplicationContext.Current.PatientContext.PatientID,
                ExtendApplicationContext.Current.PatientContext.VisitID,
                ExtendApplicationContext.Current.PatientContext.OperID)
        {

        }


        public PatientSelectedInfo(string patientId, decimal visitId, decimal operId)
        {
            InitializeComponent();
            _patientID = patientId;
            _visitID = visitId;
            _operID = operId;
            base.HideScrollBar();
            base.DocKind = DocKind.Default;
            Caption = "患者详情";
            base.ToolBarLayoutPanel.Height = 40;
            base.PrintButton.Visible = false;
            base.SaveButton.Visible = false;
            base.RefreshButton.Visible = false;
            //base.ToolBarLayoutPanel.Visible = ExtendApplicationContext.Current.LoginUserContext.IsMDSD;    
        }

        /// <summary>
        /// 界面生成完,所有控件都被UIElementHandler处理后调用的方法
        /// </summary>
        /// <param name="handlers"></param>
        protected override void OnViewBuilded(List<IUIElementHandler> handlers, Dictionary<string, DataTable> dataSources)
        {
            //处理 LabelHandler
            LabelHandler handlerTemp = null;
            foreach (IUIElementHandler handler in handlers)
            {
                if (handler is LabelHandler)
                {
                    handlerTemp = (LabelHandler)handler;

                    break;
                }
            }
            if (handlerTemp != null)
            {
                foreach (Control control in handlerTemp.GetAllControls)
                {
                    if (control is MLabel)
                    {
                        ((MLabel)control).BackColor = Color.Transparent;
                        //  ((MLabel)control).Parent = 
                    }

                }
            }


            TextBoxHandler textBoxHandlerTemp = null;
            foreach (IUIElementHandler handler in handlers)
            {
                if (handler is TextBoxHandler)
                {
                    textBoxHandlerTemp = (TextBoxHandler)handler;

                    break;
                }
            }
            if (textBoxHandlerTemp != null)
            {
                foreach (Control control in textBoxHandlerTemp.GetAllControls)
                {
                    if (control is MTextBox)
                    {
                        ((MTextBox)control).Enabled = true;
                        ((MTextBox)control).ReadOnly = true;

                        //((MTextBox)control).BackAlpha = 0;
                    }

                }
            }

        }
        protected override void OnControlInitalizing(Control control)
        {
            if (control is Panel)
            {
                Panel p = control as Panel;
                p.BackColor = Color.Transparent;
            }
        }
        protected override void OnRefreshSelectedPatient(Dictionary<string, DataTable> dataSource, string patientId, decimal visitId, decimal operId)
        {
            dataSource.Clear();
            AnesthesiaSheetDA anesthesiaSheetDA = new AnesthesiaSheetDA();
            PatientInformationsDA patientDA = new PatientInformationsDA();
            dataSource["WIS_OPER_MASTER"] = anesthesiaSheetDA.GetOperationMaster(patientId, visitId, operId);
            dataSource["WIS_PAT_MASTER_INDEX"] = patientDA.GetPatMasterIndexDataTable(patientId);
        }

        protected override void BuildData(Dictionary<string, DataTable> dataSource)
        {
            dataSource.Clear();
            AnesthesiaSheetDA anesthesiaSheetDA = new AnesthesiaSheetDA();
            PatientInformationsDA patientDA = new PatientInformationsDA();
            dataSource["WIS_OPER_MASTER"] = anesthesiaSheetDA.GetOperationMaster(_patientID, _visitID, _operID);
            dataSource["WIS_PAT_MASTER_INDEX"] = patientDA.GetPatMasterIndexDataTable(_patientID);



        }
    }

}
