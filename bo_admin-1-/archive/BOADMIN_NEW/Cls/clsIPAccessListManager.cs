using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtocolStructs;
using clsInterface4OME;
using clsInterface4OME.DSBO;
using BOADMIN_NEW.BOEngineServiceTCP;

namespace BOADMIN_NEW.Cls
{
    public class clsIPAccessListManager : IclsManager
    {
        #region MEMBERS
        static clsIPAccessListManager _clsIPAccessListManager = null;
        public DS4IPAccesssList _DS4IPAccesssList = new DS4IPAccesssList();

        #endregion MEMBERS

        #region METHODS
        private clsIPAccessListManager()
        {

        }

        public void FillDataToDataSet()
        {
            try
            {

                clsProxyClassManager.INSTANCE._objBOEngineClient.HandleIPAccessListCompleted += new EventHandler<HandleIPAccessListCompletedEventArgs>(_objIPAccessListClient_HandleIPAccessListCompleted);
                clsProxyClassManager.INSTANCE._objBOEngineClient.HandleIPAccessListAsync(clsGlobal.userIDPwd, OperationTypes.GET, null);

            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsIPAccessListManager => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                //   "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in FillDataToDataSet()");
            }
        }

        void _objIPAccessListClient_HandleIPAccessListCompleted(object sender, HandleIPAccessListCompletedEventArgs e)
        {
            foreach (clsIPAccessList item in e.Result)
            {
                DoHandleIPAccessListTable(item);
            }

            FrmMain.Instance.stopProgressBar();
        }

        public void DoHandleIPAccessListTable(clsIPAccessList accIP)
        {
            try
            {
                DS4IPAccesssList.dtIPAccessListRow _IPAccessListRow = _DS4IPAccesssList.dtIPAccessList.FindByIPAccessID(accIP.ID);
                if (_IPAccessListRow == null)
                {
                    _DS4IPAccesssList.dtIPAccessList.AdddtIPAccessListRow(clsUtility.GetInt(accIP.ID)
                        , clsUtility.GetStr(accIP.Status), clsUtility.GetStr(accIP.FromIP), clsUtility.GetStr(accIP.ToIp),
                        clsUtility.GetStr(accIP.Comment));
                }
                else
                {
                    _IPAccessListRow.IPAccessID = clsUtility.GetInt(accIP.ID);
                    _IPAccessListRow.Action = clsUtility.GetStr(accIP.Status);
                    _IPAccessListRow.Comment = clsUtility.GetStr(accIP.Comment);
                    _IPAccessListRow.IPAddressFrom = clsUtility.GetStr(accIP.FromIP);
                    _IPAccessListRow.IPAddressTo = clsUtility.GetStr(accIP.ToIp);

                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsIPAccessListManager => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                //"ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in DoHandleIPAccessListTable()");
            }
        }
        #endregion METHODS
        #region PROPERTY
        public static clsIPAccessListManager INSTANCE
        {
            get
            {
                if (_clsIPAccessListManager == null)
                {
                    _clsIPAccessListManager = new clsIPAccessListManager();
                }
                return _clsIPAccessListManager;
            }
        }
        #endregion PROPERTY

        #region IclsManager

        public override void AddSetting(IProtocolStruct PS)
        {
            //DoHandleIPAccessListTable((PS as AccessIpPS)._Ipaccess);
        }

        public override void RemoveSetting(string DataKey)
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("clsIPAccessListManager : Enter RemoveSetting()");
                int AccessIpId = -999;
                try
                {
                    AccessIpId = Convert.ToInt32(DataKey);
                }
                catch (Exception ex)
                {
                    FileHandling.WriteToLogEx(ex);
                    return;
                }

                DS4IPAccesssList.dtIPAccessListRow Row = _DS4IPAccesssList.dtIPAccessList.FindByIPAccessID(AccessIpId);
                lock (_DS4IPAccesssList.dtIPAccessList)
                {
                    _DS4IPAccesssList.dtIPAccessList.RemovedtIPAccessListRow(Row);
                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsIPAccessListManager =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in RemoveSetting()");
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
