using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtocolStructs;
using clsInterface4OME;
using clsInterface4OME.DSBO;

namespace BOADMIN_NEW.Cls
{
    public class clsDataServersManager : IclsManager
    {
        #region MEMBERS
        static clsDataServersManager _clsDataServersManager = null;
        public DS4DataServers _DS4DataServers = new DS4DataServers();

        #endregion MEMBERS

        #region METHODS


        private void DoHandleDataServersTable(DataServer dataServer)
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("clsDataServersManager : Enter DoHandleDataServersTable()");
                DS4DataServers.dtDataServerRow _DataServerRow = _DS4DataServers.dtDataServer.FindByDataServerID(dataServer._ServerID);
                if (_DataServerRow == null)
                {
                    _DataServerRow = _DS4DataServers.dtDataServer.NewRow() as DS4DataServers.dtDataServerRow;
                    _DataServerRow.DataServerID = dataServer._ServerID;
                    _DataServerRow.Description = dataServer._Description;
                    _DataServerRow.InternalIPAddress = dataServer._InternalIpServer;
                    _DataServerRow.Port = dataServer._Port;
                    _DataServerRow.Priority = dataServer._Priority;
                    _DataServerRow.ProxyServer = dataServer._IsLive;
                    _DataServerRow.PublicServerAddress = dataServer._IP;
                    _DataServerRow.Loading = dataServer._Loading;
                    _DS4DataServers.dtDataServer.AdddtDataServerRow(_DataServerRow);
                }
                else
                {
                    _DataServerRow.DataServerID = dataServer._ServerID;
                    _DataServerRow.Description = dataServer._Description;
                    _DataServerRow.InternalIPAddress = dataServer._InternalIpServer;
                    _DataServerRow.Port = dataServer._Port;
                    _DataServerRow.Priority = dataServer._Priority;
                    _DataServerRow.ProxyServer = dataServer._IsLive;
                    _DataServerRow.PublicServerAddress = dataServer._IP;
                    _DataServerRow.Loading = dataServer._Loading;
                }

            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsDataServersManager =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in DoHandleDataServersTable()");
            }
        }



        #endregion METHODS
        #region PROPERTY
        public static clsDataServersManager INSTANCE
        {
            get
            {
                if (_clsDataServersManager == null)
                {
                    _clsDataServersManager = new clsDataServersManager();
                }
                return _clsDataServersManager;
            }
        }
        #endregion PROPERTY

        #region IclsManager

        public override void AddSetting(IProtocolStruct PS)
        {
            DoHandleDataServersTable((PS as DataServerPS)._DataServer);
        }

        public override void RemoveSetting(string DataKey)
        {
            int DataServerID = -999;
            try
            {
                //Logging.FileHandling.WriteAllLog("clsDataServersManager : Enter DoHandleDataServersTable()");
                DataServerID = Convert.ToInt32(DataKey);
            }
            catch (Exception ex)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsDataServersManager =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in DoHandleDataServersTable()");
                FileHandling.WriteToLogEx(ex);
                return;
            }

            DS4DataServers.dtDataServerRow Row = _DS4DataServers.dtDataServer.FindByDataServerID(DataServerID);
            lock (_DS4DataServers.dtDataServer)
            {
                _DS4DataServers.dtDataServer.RemovedtDataServerRow(Row);
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
