using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtocolStructs;
using clsInterface4OME;
using clsInterface4OME.DSBO;

namespace BOADMIN_NEW.Cls
{
    public class clsSynchronizationManager : IclsManager
    {
        #region MEMBERS

        static clsSynchronizationManager _clsSynchronizationManger = null;
        public DS4Synchronization _DS4Synchronization = new DS4Synchronization();

        #endregion MEMBERS

        #region METHODS
        private clsSynchronizationManager()
        {

        }
        private void DoHandleSynchronizationTable(Synchronization Syn)
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("clsSynchronizationManager : Enter DoHandleSynchronizationTable()");
                DS4Synchronization.dtSynchronizationRow SynchronizationRow = _DS4Synchronization.dtSynchronization.FindBySynchronizationId(Syn._SynchronizationId);
                if (SynchronizationRow == null)
                {
                    SynchronizationRow = _DS4Synchronization.dtSynchronization.NewRow() as DS4Synchronization.dtSynchronizationRow;
                    SynchronizationRow.SynchronizationId = Syn._SynchronizationId;
                    SynchronizationRow.Enable = Syn._IsEnable;
                    SynchronizationRow.Server = Syn._Server;
                    SynchronizationRow.Symbols = Syn._Symbols;
                    SynchronizationRow.Limits = Syn._IsLimits;
                    SynchronizationRow.StartDate = Syn._StartDate;
                    SynchronizationRow.EndDate = Syn._EndDate;
                    SynchronizationRow.Mode = Syn._Mode.ToString();
                    _DS4Synchronization.dtSynchronization.AdddtSynchronizationRow(SynchronizationRow);

                }
                else
                {
                    SynchronizationRow.SynchronizationId = Syn._SynchronizationId;
                    SynchronizationRow.Enable = Syn._IsEnable;
                    SynchronizationRow.Server = Syn._Server;
                    SynchronizationRow.Symbols = Syn._Symbols;
                    SynchronizationRow.Limits = Syn._IsLimits;
                    SynchronizationRow.StartDate = Syn._StartDate;
                    SynchronizationRow.EndDate = Syn._EndDate;
                    SynchronizationRow.Mode = Syn._Mode.ToString();

                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsSynchronizationManager =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in DoHandleSynchronizationTable()");
            }
        }
        #endregion METHODS
        #region PROPERTY

        public static clsSynchronizationManager INSTANCE
        {
            get
            {
                if (_clsSynchronizationManger == null)
                {
                    _clsSynchronizationManger = new clsSynchronizationManager();
                }
                return _clsSynchronizationManger;
            }
        }

        #endregion PROPERTY

        #region IclsManaager
        public override void AddSetting(IProtocolStruct PS)
        {
            DoHandleSynchronizationTable((PS as SynchronizationPS)._Synchronization);
        }

        public override void RemoveSetting(string DataKey)
        {
            int SynchronizationID = -999;
            try
            {
                SynchronizationID = Convert.ToInt32(DataKey);
            }
            catch (Exception ex)
            {
                FileHandling.WriteToLogEx(ex);
                return;
            }
            DS4Synchronization.dtSynchronizationRow Row = _DS4Synchronization.dtSynchronization.FindBySynchronizationId(SynchronizationID);
            lock (_DS4Synchronization.dtSynchronization)
            {
                _DS4Synchronization.dtSynchronization.RemovedtSynchronizationRow(Row);
            }

        }

        public override void ServerRequestResponse(DBResponse response)
        {
            if (!response._Status)
            {
                ShowErrorMessage(response.ToString());
            }
        }
        #endregion IclsManager
    }
}
