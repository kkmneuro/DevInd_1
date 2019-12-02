using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtocolStructs;
using clsInterface4OME;
using clsInterface4OME.DSBO;

namespace BOADMIN_NEW.Cls
{
    public class clsDataFeedsManager : IclsManager
    {
        #region MEMBERS

        static clsDataFeedsManager _clsDataFeedsManager = null;
        public DS4DataFeeds _DS4DataFeeds = new DS4DataFeeds();

        #endregion MEMBERS

        #region METHODS

        private clsDataFeedsManager()
        {

        }

        private void DoHandleDataFeedsTable(DataFeeds Dat)
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("clsDataFeedsManager : Enter DoHandleDataFeedsTable()");
                DS4DataFeeds.dtDataFeedsRow DataFeedsRow = _DS4DataFeeds.dtDataFeeds.FindByDataFeedID(Dat._Id);
                if (DataFeedsRow == null)
                {
                    DataFeedsRow = _DS4DataFeeds.dtDataFeeds.NewRow() as DS4DataFeeds.dtDataFeedsRow;
                    DataFeedsRow.DataFeedID = Dat._Id;
                    DataFeedsRow.Enable = Dat._IsEnable;
                    DataFeedsRow.Name = Dat._Vendor;
                    DataFeedsRow.Source = Dat._Source;
                    DataFeedsRow.File = Dat._File;
                    DataFeedsRow.Server = Dat._Server;
                    DataFeedsRow.Login = Dat._LoginID;
                    DataFeedsRow.Password = Dat._Password;
                    DataFeedsRow.Keywords = Dat._KeyWords;
                    DataFeedsRow.IdleTimeOut = Dat._IdleTimeOut;
                    DataFeedsRow.SleepFor = Dat._SleepFor;
                    DataFeedsRow.Attempts = Dat._Attempts;
                    DataFeedsRow.ReconnectAfter = Dat._ReconnectAfter;
                    _DS4DataFeeds.dtDataFeeds.AdddtDataFeedsRow(DataFeedsRow);
                }
                else
                {
                    DataFeedsRow.DataFeedID = Dat._Id;
                    DataFeedsRow.Enable = Dat._IsEnable;
                    DataFeedsRow.Name = Dat._Vendor;
                    DataFeedsRow.Source = Dat._Source;
                    DataFeedsRow.File = Dat._File;
                    DataFeedsRow.Server = Dat._Server;
                    DataFeedsRow.Login = Dat._LoginID;
                    DataFeedsRow.Password = Dat._Password;
                    DataFeedsRow.Keywords = Dat._KeyWords;
                    DataFeedsRow.IdleTimeOut = Dat._IdleTimeOut;
                    DataFeedsRow.SleepFor = Dat._SleepFor;
                    DataFeedsRow.Attempts = Dat._Attempts;
                    DataFeedsRow.ReconnectAfter = Dat._ReconnectAfter;
                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsDataFeedsManager =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in DoHandleDataFeedsTable()");
            }
        }
        #endregion METHODS

        #region PROPERTY
        public static clsDataFeedsManager INSTANCE
        {
            get
            {
                if (_clsDataFeedsManager == null)
                {
                    _clsDataFeedsManager = new clsDataFeedsManager();
                }
                return _clsDataFeedsManager;
            }
        }
        #endregion PROPERTY

        #region IclsManaager
        public override void AddSetting(IProtocolStruct PS)
        {
            DoHandleDataFeedsTable((PS as DataFeedsPS)._DataFeeds);
        }

        public override void RemoveSetting(string DataKey)
        {
            int DataFeedsID = -999;
            try
            {
                DataFeedsID = Convert.ToInt32(DataKey);
            }
            catch (Exception ex)
            {
                FileHandling.WriteToLogEx(ex);
                return;
            }
            DS4DataFeeds.dtDataFeedsRow Row = _DS4DataFeeds.dtDataFeeds.FindByDataFeedID(DataFeedsID);
            lock (_DS4DataFeeds.dtDataFeeds)
            {
                _DS4DataFeeds.dtDataFeeds.RemovedtDataFeedsRow(Row);
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
