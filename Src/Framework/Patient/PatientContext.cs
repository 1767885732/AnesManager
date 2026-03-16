using System;
using System.Collections.Generic;
using System.Text;

namespace Wis.Anes.Framework
{
   public class PatientContext
   {
       private string _patientId = string.Empty;
       private decimal _visitId = decimal.Zero;
       private decimal _operId = decimal.Zero;
       /// <summary>
       /// 患者ID
       /// </summary>
       public string PatientID
       {
           get
           {
               return _patientId;
           }
           set
           {
               _patientId = value;
           }
       }
       /// <summary>
       /// 患者VisitId
       /// </summary>
       public decimal VisitID
       {
           get
           {
               return _visitId;
           }
           set
           {
               _visitId = value;
           }
       }
       /// <summary>
       /// 患者OperId
       /// </summary>
       public decimal OperID
       {
           get
           {
               return _operId;
           }
           set
           {
               _operId = value;
           }
       }
   }
}
