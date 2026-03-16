using System;
using System.Collections.Generic;
using System.Text;

namespace Wis.Anes.Framework.Views.PatientStatus
{
    public interface IPatientStatusAction
    {
        object Excute(OperationStatus operationStatus);
    }
}
