using System;
using System.Collections.Generic;
using System.Text;
using Wis.Anes.BusinessEntity;
using Wis.Anes.Interface;
using Wis.Anes.DataAccess;
using Wis.Anes.Framework;

namespace Wis.Anes.BusinessComponent
{
    public class ConfigurationBC:IConfiguration
    {
        public Configuations.UserTablesDataTable GetUserTables()
        {
            return (new ConfigurationDA()).GetUserTables();
        }
        public Configuations.DocumentDataTable GetDocument()
        {
            return (new ConfigurationDA()).GetDocument();
        }

        public int UpdateDocument(Configuations.DocumentDataTable dataTable)
        {
            return (new ConfigurationDA()).UpdateDocument(dataTable);
        }

        public Configuations.ConfigTableDataTable GetConfigTableDataTable()
        {
            return (new ConfigurationDA()).GetConfigTableDataTable();
        }

        public int UpdateConfigTableDataTable(Configuations.ConfigTableDataTable dataTable)
        {
            return (new ConfigurationDA()).UpdateConfigTableDataTable(dataTable);
        }

        public Configuations.PatientMonitorConfigDataTable GetPatientMonitorConfigDataTable(string patientID, decimal visitID, decimal operID)
        {
            return (new ConfigurationDA()).GetPatientMonitorConfigDataTable(patientID, visitID, operID);
        }

        public int UpdatePatientMonitorConfigDataTable(Configuations.PatientMonitorConfigDataTable dataTable)
        {
            return (new ConfigurationDA()).UpdatePatientMonitorConfigDataTable(dataTable);
        }
    }
}
