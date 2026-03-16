using System;
using System.Collections.Generic;
using System.Text;
using Wis.Anes.Interface;
using Wis.Anes.BusinessComponent;
using Wis.Anes.BusinessEntity;
using Wis.Anes.Framework;

namespace Wis.Anes.ServiceProxies
{
    public class ConfigurationProxy
    {
        static IConfiguration _iConfiguration = new ConfigurationBC();
        public static Configuations.UserTablesDataTable GetUserTables()
        {
            try
            {
                return _iConfiguration.GetUserTables();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Configuations.DocumentDataTable GetDocumentTable()
        {
            return GetDocumentTable(true);
        }

        public static Configuations.DocumentDataTable GetDocumentTable(bool showError)
        {
            try
            {
                return _iConfiguration.GetDocument();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int UpdateDocumentTable(Configuations.DocumentDataTable dataTable)
        {
            try
            {
                return _iConfiguration.UpdateDocument(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
   
        public static Configuations.PatientMonitorConfigDataTable GetPatientMonitorConfigDataTable(string patientID, decimal visitID, decimal operID)
        {
            try
            {
                return _iConfiguration.GetPatientMonitorConfigDataTable(patientID, visitID, operID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int UpdatePatientMonitorConfigDataTable(Configuations.PatientMonitorConfigDataTable dataTable)
        {
            try
            {
                return _iConfiguration.UpdatePatientMonitorConfigDataTable(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Configuations.ConfigTableDataTable GetConfigTableDataTable()
        {
            try
            {
                return _iConfiguration.GetConfigTableDataTable();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int UpdateConfigTableDataTable(Configuations.ConfigTableDataTable data)
        {
            try
            {
                return _iConfiguration.UpdateConfigTableDataTable(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
