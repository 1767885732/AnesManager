using System;
using System.Collections.Generic;
using System.Text;
using Wis.Anes.Framework.Views.PatientStatus;

namespace Wis.Anes.Views
{
    public class PandectOperationStatusAction : IPatientStatusAction
    {
        #region IPatientStatusAction 成员

        public object Excute(Wis.Anes.Framework.OperationStatus operationStatus)
        {
            string roomNo = "";
            OperationRoomPandect operationRoomPandect = new OperationRoomPandect(1, true);
            Wis.Anes.Layouts.DialogHostForm dialogHostForm = new Wis.Anes.Layouts.DialogHostForm("选择床位 - 双击空床位完成选择", 800, 600);
            dialogHostForm.Child = operationRoomPandect;
            dialogHostForm.ShowDialog();
            if (operationRoomPandect.SelectedOperationRoomContent != null)
            {
                roomNo = operationRoomPandect.SelectedOperationRoomContent.OperRoomKey;
            }

            return roomNo;
        }

        #endregion
    }
}
