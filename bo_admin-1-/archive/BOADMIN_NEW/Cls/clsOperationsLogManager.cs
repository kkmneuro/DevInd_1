using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using clsInterface4OME.DSBO;
using BOADMIN_NEW.BOEngineServiceTCP;

namespace BOADMIN_NEW.Cls
{
    public class clsOperationsLogManager
    {
        #region "   MEMBERS   "

        static clsOperationsLogManager _clsOperationsLogManager = null;
        public DS4OperationsLog _DS4OperationsLog = new DS4OperationsLog();

        #endregion "    MEMBERS  "

        #region "    PROPERTY     "

        public static clsOperationsLogManager INSTANCE
        {
            get { return _clsOperationsLogManager ?? (_clsOperationsLogManager = new clsOperationsLogManager()); }
        }

        #endregion "    PROPERTY     "

        public void FillDataToDataSet(List<clsBrokerOperationsLog> lstOperationsLog)
        {
            try
            {

                foreach (clsBrokerOperationsLog operationLog in lstOperationsLog)
                {
                    DoHandleOperationsTable(operationLog);
                }

                _DS4OperationsLog.dtOperationsLog.AcceptChanges();
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsOperationsLogManager => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                    //"ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in FillDataToDataSet()");
            }
        }

        public DS4OperationsLog.dtOperationsLogRow[] GetDataByDate(DateTime fromDate, DateTime toDate)
        {
            DS4OperationsLog.dtOperationsLogRow[] rows= (DS4OperationsLog.dtOperationsLogRow[])_DS4OperationsLog.dtOperationsLog.Select("DateTime>='" + fromDate + "' and DateTime<='"+toDate+"'");
            if (!rows.Any())
                return null;
            return rows;
        }

        public DS4OperationsLog.dtOperationsLogRow[] GetDataByDateBrokerID(DateTime fromDate, DateTime toDate,int brokerId)
        {
            DS4OperationsLog.dtOperationsLogRow[] rows = (DS4OperationsLog.dtOperationsLogRow[])_DS4OperationsLog.dtOperationsLog.Select("DateTime>='" + fromDate + "' and DateTime<='" + toDate + 
                "' and BrokerID="+brokerId);
            if (!rows.Any())
                return null;
            return rows;
        }

        public DS4OperationsLog.dtOperationsLogRow[] GetDataByBrokerID(int brokerId)
        {
            DS4OperationsLog.dtOperationsLogRow[] rows = (DS4OperationsLog.dtOperationsLogRow[])_DS4OperationsLog.dtOperationsLog.Select("BrokerID=" + brokerId);
            if (!rows.Any())
                return null;
            return rows;
        }

        private void DoHandleOperationsTable(clsBrokerOperationsLog operationLog)
        {
            try
            {
                DS4OperationsLog.dtOperationsLogRow row = _DS4OperationsLog.dtOperationsLog.FindBySNo(operationLog.SNo);
                if (row != null)
                    return;

                if (clsGlobal.BrokerID != 1 && (operationLog.BrokerID == clsGlobal.BrokerNameId) ||
                        clsBrokersManagerHandler.INSTANCE._lstParentIds.Contains(operationLog.BrokerID))
                {
                    _DS4OperationsLog.dtOperationsLog.AdddtOperationsLogRow(operationLog.SNo, operationLog.BrokerName, operationLog.BrokerID, operationLog.OperationName, operationLog.DateTime, operationLog.IPAddress,
                        operationLog.Message);
                }
                else if (clsGlobal.BrokerID == 1)
                {
                    _DS4OperationsLog.dtOperationsLog.AdddtOperationsLogRow(operationLog.SNo, operationLog.BrokerName, operationLog.BrokerID, operationLog.OperationName, operationLog.DateTime, operationLog.IPAddress,
                        operationLog.Message);
                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsFeeMasterManager => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                 //   "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in DoHandleFeeMasterTable()");
            }
        }
    }
}
