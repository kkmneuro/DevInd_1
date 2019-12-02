using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtocolStructs;
using clsInterface4OME;
using clsInterface4OME.DSBO;

namespace BOADMIN_NEW.Cls
{
    public class clsLiveUpdateManager : IclsManager
    {
        #region MEMBERS

        static clsLiveUpdateManager _clsLiveUpdateManager = null;
        public DS4LiveUpdate _DS4LiveUpdate = new DS4LiveUpdate();

        #endregion MEMBERS

        #region METHODS
        private clsLiveUpdateManager()
        {
        }



        private void DoHandleLiveUpdateTable(LiveUpdate Liv)
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("clsLiveUpdateManager : Enter DoHandleLiveUpdateTable()");
                DS4LiveUpdate.dtLiveUpdateRow LiveUpdateRow = _DS4LiveUpdate.dtLiveUpdate.FindByLiveUpdateId(Liv._LiveUpdateId);
                if (LiveUpdateRow == null)
                {
                    LiveUpdateRow = _DS4LiveUpdate.dtLiveUpdate.NewRow() as DS4LiveUpdate.dtLiveUpdateRow;
                    LiveUpdateRow.LiveUpdateId = Liv._LiveUpdateId;
                    LiveUpdateRow.Enable = Liv._IsEnable;
                    LiveUpdateRow.Company = Liv._Company;
                    LiveUpdateRow.Type = Liv._Type;
                    LiveUpdateRow.Folder = Liv._Folder;
                    LiveUpdateRow.MaximumConnections = Liv._MaximumConnections;
                    LiveUpdateRow.Version = Liv._Version;
                    _DS4LiveUpdate.dtLiveUpdate.AdddtLiveUpdateRow(LiveUpdateRow);
                }
                else
                {
                    LiveUpdateRow.LiveUpdateId = Liv._LiveUpdateId;
                    LiveUpdateRow.Enable = Liv._IsEnable;
                    LiveUpdateRow.Company = Liv._Company;
                    LiveUpdateRow.Type = Liv._Type;
                    LiveUpdateRow.Folder = Liv._Folder;
                    LiveUpdateRow.MaximumConnections = Liv._MaximumConnections;
                    LiveUpdateRow.Version = Liv._Version;
                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsLiveUpdateManager =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in DoHandleLiveUpdateTable()");
            }
        }


        #endregion METHODS

        #region PROPERTY
        public static clsLiveUpdateManager INSTANCE
        {
            get
            {
                if (_clsLiveUpdateManager == null)
                {
                    _clsLiveUpdateManager = new clsLiveUpdateManager();
                }
                return _clsLiveUpdateManager;
            }
        }

        #endregion PROPERTY
        #region IclsManaager
        public override void AddSetting(IProtocolStruct PS)
        {
            DoHandleLiveUpdateTable((PS as LiveUpdatePS)._LiveUpdate);
        }

        public override void RemoveSetting(string DataKey)
        {
            int LiveUpdateID = -999;
            try
            {
                LiveUpdateID = Convert.ToInt32(DataKey);
            }
            catch (Exception ex)
            {
                FileHandling.WriteToLogEx(ex);
                return;
            }
            DS4LiveUpdate.dtLiveUpdateRow Row = _DS4LiveUpdate.dtLiveUpdate.FindByLiveUpdateId(LiveUpdateID);
            lock (_DS4LiveUpdate.dtLiveUpdate)
            {
                _DS4LiveUpdate.dtLiveUpdate.RemovedtLiveUpdateRow(Row);
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
