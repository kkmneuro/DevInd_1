using System;
using System.Collections.Generic;
using System.Linq;
using BOADMIN_NEW.BOEngineServiceTCP;
using System.ServiceModel;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using BOADMIN_NEW.ReportService;
using System.Net;

namespace BOADMIN_NEW.Cls
{
    public class clsProxyClassManager
    {
        static clsProxyClassManager _instance = null;      
        public ReportClient _objReportClient;
        public BOEngineServiceClient _objBOEngineClient;


        public static clsProxyClassManager INSTANCE
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new clsProxyClassManager();
                }
                return _instance;
            }
        }

        public clsProxyClassManager()
        {

        }

        #region "         Handle Login Proxy      "

        public clsLogin Login(string loginId, clsLogin login)
        {
            clsLogin response = null;

            //Logging.FileHandling.WriteAllLog("clsProxyClassManager => Enter Login(string loginId,clsLogin login)");
            try
            {

                response = _objBOEngineClient.AuthenticateLogin(loginId, login, GetIP());
            }
            catch (Exception)
            {

            }

            //Logging.FileHandling.WriteAllLog("clsProxyClassManager => Exit Login(string loginId,clsLogin login)");

            return response;
        }

        private string GetIP()
        {
            string strHostName = "";
            strHostName = System.Net.Dns.GetHostName();

            IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);

            IPAddress[] addr = ipEntry.AddressList;
            foreach (IPAddress item in addr)
            {
                if (item.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    strHostName = item.ToString();
                }
            }
            return strHostName;
        }


        public void LogOut(string userId, clsBrokerOperationsLog _objclsBrokerOpLog)
        {
            try
            {
                _objclsBrokerOpLog.OperationName = "Logout";
                _objclsBrokerOpLog.BrokerID = clsGlobal.BrokerNameId;
                _objclsBrokerOpLog.BrokerName = clsGlobal.BrokerCompany;
                _objclsBrokerOpLog.Message = clsGlobal.BrokerCompany + " Logout successfully.";
                _objclsBrokerOpLog.DateTime = DateTime.Now;
                _objclsBrokerOpLog.IPAddress = GetIP();
                CloseRepotsChannel();
                _objBOEngineClient.LogOut(userId, _objclsBrokerOpLog);


            }
            catch (CommunicationException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : LogOut => Communication Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (TimeoutException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : LogOut => TimeoutException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : LogOut => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
        }

        public List<clsBrokerOperationsLog> HandleOperationsLog(OperationTypes opType, clsBrokerOperationsLog brokerOpLog)
        {
            List<clsBrokerOperationsLog> response = new List<clsBrokerOperationsLog>();
            try
            {
                brokerOpLog.BrokerID = clsGlobal.BrokerNameId;
                brokerOpLog.BrokerName = clsGlobal.BrokerCompany;
                brokerOpLog.DateTime = DateTime.Now;
                //brokerOpLog.BrokerType = clsBrokerManager.INSTANCE.GetBrokerType(clsGlobal.BrokerID);
                //brokerOpLog.BrokerParent = clsAccountManager.INSTANCE.GetBrokerParent(clsGlobal.BrokerNameId).ToString();
                brokerOpLog.IPAddress = GetIP();
                response = _objBOEngineClient.HandleBrokerOperationsLog(clsGlobal.userIDPwd, brokerOpLog, DateTime.Now, DateTime.Now, opType).ToList();

            }
            catch (CommunicationException)
            {
            }
            catch (TimeoutException)
            {
            }
            catch (Exception)
            {
            }
            return response;
        }




        #endregion "         Handle Login Proxy      "

        #region "       Handle Contract Specification   "
        public List<clsContractSpecification> GetCsRecords()
        {
            List<clsContractSpecification> response = new List<clsContractSpecification>();
            try
            {
                response = _objBOEngineClient.HandleContractSpecfication(clsGlobal.userIDPwd, OperationTypes.GET, null).ToList();
            }
            catch (CommunicationException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : GetCsRecords => CommunicationException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (TimeoutException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : GetCsRecords => TimeoutException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : GetCsRecords => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return response;
        }

        public clsContractSpecification InsertCsInfo(clsContractSpecification csInfo)
        {
            clsContractSpecification response = new clsContractSpecification();
            try
            {
                response = _objBOEngineClient.HandleContractSpecfication(clsGlobal.userIDPwd, OperationTypes.INSERT, csInfo)[0];
            }
            catch (CommunicationException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : InsertCsInfo => CommunicationException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (TimeoutException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : InsertCsInfo => TimeoutException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : InsertCsInfo => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return response;
        }

        public clsContractSpecification UpdateCsInfo(clsContractSpecification csInfo)
        {
            clsContractSpecification response = new clsContractSpecification();
            try
            {
                response = _objBOEngineClient.HandleContractSpecfication(clsGlobal.userIDPwd, OperationTypes.UPDATE, csInfo)[0];
            }
            catch (CommunicationException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : InsertCsInfo => CommunicationException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (TimeoutException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : InsertCsInfo => TimeoutException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : InsertCsInfo => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return response;
        }
        public int DeleteCsInfo(int key)
        {
            int deleteID = clsGlobal.FailureID;
            try
            {
                deleteID = _objBOEngineClient.HandleContractSpecfication(clsGlobal.userIDPwd, OperationTypes.DELETE, new clsContractSpecification { Instruement_ID = key })[0].Instruement_ID;
            }
            catch (CommunicationException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : DeleteCsInfo => CommunicationException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (TimeoutException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : DeleteCsInfo => TimeoutException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : DeleteCsInfo => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return deleteID;
        }

        #endregion "    Handle Contract Specification   "

        #region "   Handle Currency       "

        public List<clsCurrency> GetCurrencyList()
        {
            List<clsCurrency> response = new List<clsCurrency>();
            try
            {
                //OpenCurrencyChannel();
                response = _objBOEngineClient.GetCurrencyList(clsGlobal.userIDPwd).ToList(); //_objCurrencyClient.GetCurrencyList(clsGlobal.userIDPwd).ToList();
                // CloseCurrencyChannel();
            }
            catch (CommunicationException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : GetCurrencyList => CommunicationException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (TimeoutException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : GetCurrencyList => TimeoutException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : GetCurrencyList => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return response;
        }



        #endregion "Handle Currency       "

        #region "   Handle SecurityType   "

        public List<clsSecurityType> GetSecurityTypes()
        {
            List<clsSecurityType> response = new List<clsSecurityType>();
            try
            {
                //OpenSecurityTypeChannel();
                response = _objBOEngineClient.GetSecurityType(clsGlobal.userIDPwd).ToList(); //_objSecurityTypeClient.GetSecurityType(clsGlobal.userIDPwd).ToList();
                //CloseSecurityTypeChannel();
            }
            catch (CommunicationException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : GetSecurityTypes => CommunicationException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (TimeoutException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : GetSecurityTypes => TimeoutException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : GetSecurityTypes => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return response;
        }


        #endregion "Handle SecurityType   "

        #region "   Handle MasterInfo     "

        public clsMasterInfo GetMasterInfo()
        {
            clsMasterInfo response = new clsMasterInfo();
            try
            {
                //OpenMasterInfoChannel();
                response = _objBOEngineClient.GetMasterInfo(clsGlobal.userIDPwd);
                //CloseMasterInfoChannel();
            }
            catch (CommunicationException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : GetMasterInfo => CommunicationException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (TimeoutException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : GetMasterInfo => TimeoutException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : GetMasterInfo => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return response;
        }




        #endregion "Handle MasterInfo     "

        #region "    Handle Connection Status   "

        public bool IsConnectionAvailble()
        {
            bool flag = NetworkInterface.GetIsNetworkAvailable();

            if (flag == false)
            {
                clsDialogBox.ShowErrorBox("Unable to connect to server", "BOAdmin", true);
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : IsConnectionAvailble => Unable to connect to server");
            }
            return flag;
        }
        #endregion " Handle Connection Status   "

        #region "   Handle IPAccessList  "

        public List<clsIPAccessList> GetIPAccessListRecords()
        {
            List<clsIPAccessList> response = new List<clsIPAccessList>();
            try
            {
                response = _objBOEngineClient.HandleIPAccessList(clsGlobal.userIDPwd, OperationTypes.GET, null).ToList();
            }
            catch (CommunicationException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : GetIPAccessListRecords => CommunicationException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (TimeoutException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : GetIPAccessListRecords => TimeoutException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : GetIPAccessListRecords => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return response;
        }

        public clsIPAccessList InsertIPAccessList(clsIPAccessList csIPAccessList)
        {
            clsIPAccessList response = new clsIPAccessList();
            try
            {
                response = _objBOEngineClient.HandleIPAccessList(clsGlobal.userIDPwd, OperationTypes.INSERT, csIPAccessList)[0];
            }
            catch (CommunicationException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : InsertIPAccessList => CommunicationException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (TimeoutException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : InsertIPAccessList => TimeoutException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : InsertIPAccessList => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return response;
        }

        public clsIPAccessList UpdateIPAccessList(clsIPAccessList csIPAccessList)
        {
            clsIPAccessList response = new clsIPAccessList();
            try
            {
                response = _objBOEngineClient.HandleIPAccessList(clsGlobal.userIDPwd, OperationTypes.UPDATE, csIPAccessList)[0];
            }
            catch (CommunicationException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : UpdateIPAccessList => CommunicationException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (TimeoutException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : UpdateIPAccessList => TimeoutException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : UpdateIPAccessList => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return response;
        }
        public int DeleteIPAccessList(int key)
        {
            int deleteID = clsGlobal.FailureID;
            try
            {
                deleteID = _objBOEngineClient.HandleIPAccessList(clsGlobal.userIDPwd, OperationTypes.DELETE, new clsIPAccessList { ID = key })[0].ID;
            }
            catch (CommunicationException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : DeleteIPAccessList => CommunicationException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (TimeoutException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : DeleteIPAccessList => TimeoutException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : DeleteIPAccessList => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return deleteID;
        }

        #endregion "Handle IPAccessList  "

        #region "       Tax Master       "

        public List<clsTaxMaster> GetTaxMasterRecords()
        {
            List<clsTaxMaster> response = new List<clsTaxMaster>();
            try
            {
                response = _objBOEngineClient.HandleTaxMaster(clsGlobal.userIDPwd, OperationTypes.GET, null).ToList();
            }
            catch (CommunicationException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : GetTaxMasterRecords => CommunicationException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (TimeoutException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : GetTaxMasterRecords => TimeoutException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : GetTaxMasterRecords => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return response;
        }

        public clsTaxMaster InsertTaxMaster(clsTaxMaster csIPAccessList)
        {
            clsTaxMaster response = new clsTaxMaster();
            try
            {
                response = _objBOEngineClient.HandleTaxMaster(clsGlobal.userIDPwd, OperationTypes.INSERT, csIPAccessList)[0];
            }
            catch (CommunicationException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : InsertTaxMaster => CommunicationException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (TimeoutException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : InsertTaxMaster => TimeoutException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : InsertTaxMaster => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return response;
        }

        public clsTaxMaster UpdateTaxMaster(clsTaxMaster csIPAccessList)
        {
            clsTaxMaster response = null;
            try
            {
                response = _objBOEngineClient.HandleTaxMaster(clsGlobal.userIDPwd, OperationTypes.UPDATE, csIPAccessList)[0];
            }
            catch (CommunicationException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : UpdateTaxMaster => CommunicationException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (TimeoutException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : UpdateTaxMaster => TimeoutException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : UpdateTaxMaster => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return response;
        }
        public int DeleteTaxMaster(int key)
        {
            int deleteID = clsGlobal.FailureID;
            try
            {
                deleteID = _objBOEngineClient.HandleTaxMaster(clsGlobal.userIDPwd, OperationTypes.DELETE, new clsTaxMaster { TaxID = key })[0].TaxID;
            }
            catch (CommunicationException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : DeleteTaxMaster => CommunicationException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (TimeoutException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : DeleteTaxMaster => TimeoutException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : DeleteTaxMaster => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return deleteID;
        }

        #endregion "    Tax Master       "

        #region "       Fee Master       "

        public List<clsFeeMaster> GetFeeMasterRecords()
        {
            List<clsFeeMaster> response = new List<clsFeeMaster>();
            try
            {
                response = _objBOEngineClient.HandleFeeMaster(clsGlobal.userIDPwd, OperationTypes.GET, null).ToList();
            }
            catch (CommunicationException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : GetFeeMasterRecords => CommunicationException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (TimeoutException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : GetFeeMasterRecords => TimeoutException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : GetFeeMasterRecords => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return response;
        }

        public clsFeeMaster InsertFeeMaster(clsFeeMaster feeMaster)
        {
            clsFeeMaster response = null;
            try
            {
                response = _objBOEngineClient.HandleFeeMaster(clsGlobal.userIDPwd, OperationTypes.INSERT, feeMaster)[0];
            }
            catch (CommunicationException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : InsertFeeMaster => CommunicationException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (TimeoutException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : InsertFeeMaster => TimeoutException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : InsertFeeMaster => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return response;
        }

        public clsFeeMaster UpdateFeeMaster(clsFeeMaster feeMaster)
        {
            clsFeeMaster response = null;
            try
            {
                response = _objBOEngineClient.HandleFeeMaster(clsGlobal.userIDPwd, OperationTypes.UPDATE, feeMaster)[0];
            }
            catch (CommunicationException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : UpdateFeeMaster => CommunicationException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (TimeoutException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : UpdateFeeMaster => TimeoutException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : UpdateFeeMaster => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return response;
        }

        public int DeleteFeeMaster(int key)
        {
            int deleteID = clsGlobal.FailureID;
            try
            {
                deleteID = _objBOEngineClient.HandleFeeMaster(clsGlobal.userIDPwd, OperationTypes.DELETE, new clsFeeMaster { FeeId = key })[0].FeeId;
            }
            catch (CommunicationException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : DeleteFeeMaster => CommunicationException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (TimeoutException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : DeleteFeeMaster => TimeoutException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : DeleteFeeMaster => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return deleteID;
        }


        #endregion "    Fee Master       "

        #region "     Time Settings      "

        public List<clsTimeSettings> GetTimeSettingsRecords()
        {
            List<clsTimeSettings> response = new List<clsTimeSettings>();
            try
            {
                response = _objBOEngineClient.HandleTimeSettings(clsGlobal.userIDPwd, OperationTypes.GET, null).ToList();
            }
            catch (CommunicationException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : GetTimeSettingsRecords => CommunicationException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (TimeoutException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : GetTimeSettingsRecords => TimeoutException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : GetTimeSettingsRecords => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return response;
        }

        public clsTimeSettings UpdateTimeSettings(clsTimeSettings timeSetting)
        {
            clsTimeSettings response = null;
            try
            {
                response = _objBOEngineClient.HandleTimeSettings(clsGlobal.userIDPwd, OperationTypes.UPDATE, timeSetting)[0];
            }
            catch (CommunicationException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : UpdateTimeSettings => CommunicationException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (TimeoutException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : UpdateTimeSettings => TimeoutException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : UpdateTimeSettings => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return response;
        }


        #endregion "  Time Settings      "

        #region "        Holiday         "

        public List<clsHoliday> GetHolidayRecords()
        {
            List<clsHoliday> response = new List<clsHoliday>();
            try
            {
                response = _objBOEngineClient.HandleHoliday(clsGlobal.userIDPwd, OperationTypes.GET, null).ToList();
            }
            catch (CommunicationException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : GetHolidayRecords => CommunicationException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (TimeoutException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : GetHolidayRecords => TimeoutException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : GetHolidayRecords => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return response;
        }

        public clsHoliday InsertHoliday(clsHoliday holiday)
        {
            clsHoliday response = new clsHoliday();
            try
            {
                response = _objBOEngineClient.HandleHoliday(clsGlobal.userIDPwd, OperationTypes.INSERT, holiday)[0];
            }
            catch (CommunicationException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : InsertHoliday => CommunicationException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (TimeoutException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : InsertHoliday => TimeoutException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : InsertHoliday => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return response;
        }

        public clsHoliday UpdateHoliday(clsHoliday holiday)
        {
            clsHoliday response = new clsHoliday();
            try
            {
                response = _objBOEngineClient.HandleHoliday(clsGlobal.userIDPwd, OperationTypes.UPDATE, holiday)[0];
            }
            catch (CommunicationException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : UpdateHoliday => CommunicationException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (TimeoutException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : UpdateHoliday => TimeoutException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : UpdateHoliday => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return response;
        }

        public int DeleteHoliday(int key)
        {
            int deleteID = clsGlobal.FailureID;
            try
            {
                deleteID = _objBOEngineClient.HandleHoliday(clsGlobal.userIDPwd, OperationTypes.DELETE, new clsHoliday { Id = key })[0].Id;
            }
            catch (CommunicationException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : DeleteHoliday => CommunicationException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (TimeoutException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : DeleteHoliday => TimeoutException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : DeleteHoliday => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return deleteID;
        }

        #endregion "     Holiday         "

        #region "     Trading Gateway    "

        public List<clsTradingGateway> GetTradingGatewayRecords()
        {
            List<clsTradingGateway> response = new List<clsTradingGateway>();
            try
            {
                response = _objBOEngineClient.HandleTradingGateway(clsGlobal.userIDPwd, OperationTypes.GET, null).ToList();
            }
            catch (CommunicationException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : GetTradingGatewayRecords => CommunicationException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (TimeoutException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : GetTradingGatewayRecords => TimeoutException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : GetTradingGatewayRecords => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return response;
        }

        public clsTradingGateway InsertTradingGateway(clsTradingGateway tradingGateway)
        {
            clsTradingGateway response = null;
            try
            {
                response = _objBOEngineClient.HandleTradingGateway(clsGlobal.userIDPwd, OperationTypes.INSERT, tradingGateway)[0];
            }
            catch (CommunicationException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : InsertTradingGateway => CommunicationException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (TimeoutException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : InsertTradingGateway => TimeoutException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : InsertTradingGateway => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return response;
        }

        public clsTradingGateway UpdateTradingGateway(clsTradingGateway tradingGateway)
        {
            clsTradingGateway response = null;
            try
            {
                response = _objBOEngineClient.HandleTradingGateway(clsGlobal.userIDPwd, OperationTypes.UPDATE, tradingGateway)[0];
            }
            catch (CommunicationException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : UpdateTradingGateway => CommunicationException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (TimeoutException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : UpdateTradingGateway => TimeoutException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : UpdateTradingGateway => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return response;
        }


        #endregion "   Trading Gateway   "

        #region "     Brokers    "

        public List<clsBroker> GetBrokerRecords()
        {
            List<clsBroker> response = new List<clsBroker>();
            try
            {
                //OpenBrokerChannel();
                response = _objBOEngineClient.HandleBrokers(clsGlobal.userIDPwd, clsGlobal.BrokerNameId, OperationTypes.GET, null).ToList();
                //CloseBrokerChannel();
            }
            catch (CommunicationException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : GetBrokerRecords => CommunicationException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (TimeoutException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : GetBrokerRecords => TimeoutException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : GetBrokerRecords => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return response;
        }

        public clsBroker InsertBroker(clsBroker broker)
        {
            clsBroker response = new clsBroker();
            try
            {
                //OpenBrokerChannel();
                response = _objBOEngineClient.HandleBrokers(clsGlobal.userIDPwd, clsGlobal.BrokerNameId, OperationTypes.INSERT, broker)[0];
                //CloseBrokerChannel();
            }
            catch (CommunicationException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : InsertBroker => CommunicationException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (TimeoutException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : InsertBroker => TimeoutException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : InsertBroker => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return response;
        }

        public clsBroker UpdateBroker(clsBroker broker)
        {
            clsBroker response = new clsBroker();
            try
            {
                response = _objBOEngineClient.HandleBrokers(clsGlobal.userIDPwd, clsGlobal.BrokerNameId, OperationTypes.UPDATE, broker)[0];
            }
            catch (CommunicationException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : UpdateBroker => CommunicationException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (TimeoutException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : UpdateBroker => TimeoutException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : UpdateBroker => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return response;
        }


        #endregion "   Broker   "

        #region "   Handle Module   "

        public List<clsModule> GetModuleRcords()
        {
            List<clsModule> response = new List<clsModule>();
            try
            {
                //OpenModuleChannel();
                response = _objBOEngineClient.GetModules(clsGlobal.userIDPwd).ToList();//_objModuleClient.GetModules(clsGlobal.userIDPwd).ToList();
                // CloseModuleChannel();
            }
            catch (CommunicationException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : GetModuleRcords => CommunicationException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (TimeoutException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : GetModuleRcords => TimeoutException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : GetModuleRcords => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return response;
        }

        #endregion " Handle Module  "

        #region "   Handle BrokerList   "

        public List<clsBrokerList> GetBrokerListRcords()
        {
            List<clsBrokerList> response = null;
            try
            {
                //OpenBrokerListChannel();
                response = _objBOEngineClient.GetBrokerList(clsGlobal.userIDPwd).ToList(); //_objBrokerListClient.GetBrokerList(clsGlobal.userIDPwd).ToList();
                //CloseBrokerListChannel();
            }
            catch (CommunicationException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : GetBrokerListRcords => CommunicationException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (TimeoutException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : GetBrokerListRcords => TimeoutException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : GetBrokerListRcords => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return response;
        }

        #endregion " Handle BrokerList  "

        #region "   Handle Leverages   "

        public List<clsLeverage> GetLeverageRecords()
        {
            List<clsLeverage> response = new List<clsLeverage>();
            try
            {
                // OpenLeverageChannel();
                response = _objBOEngineClient.GetLeverageList(clsGlobal.userIDPwd).ToList(); //_objLeverageClient.GetLeverageList(clsGlobal.userIDPwd).ToList();
                //CloseLeverageChannel();
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : GetLeverageRecords => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return response;
        }


        #endregion " Handle Leverages  "

        #region "  Handle CountryDetail  "

        public List<clsCountryDetail> GetCountryRecords()
        {
            List<clsCountryDetail> response = null;
            try
            {
                //OpenCDChannel();
                response = _objBOEngineClient.GetCountryDetails(clsGlobal.userIDPwd).ToList(); //_objCountryDetailClient.GetCountryDetails(clsGlobal.userIDPwd).ToList();
                // CloseCDChannel();
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : GetCountryRecords => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return response;
        }


        #endregion " Handle Leverages  "

        #region "   Handle PartcipaintList   "

        public List<clsParticipaintList> GetParticipaintRecords()
        {
            List<clsParticipaintList> response = null;
            try
            {
                response = _objBOEngineClient.GetParticipaintList(clsGlobal.userIDPwd).ToList(); //_objParticipaintListClient.GetParticipaintList(clsGlobal.userIDPwd).ToList();
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : GetParticipaintRecords => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return response;
        }



        #endregion " Handle ParticipaintList  "

        #region "   Handle CollateralTypes   "

        public List<clsCollateralTypes> GetCollateralRecords()
        {
            List<clsCollateralTypes> response = new List<clsCollateralTypes>();
            try
            {
                response = _objBOEngineClient.GetCollateralTypes(clsGlobal.userIDPwd).ToList();
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : GetCollateralRecords => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return response;
        }


        #endregion " Handle CollateralTypes  "

        #region "   Handle Client Account   "

        public List<clsAccount> GetAccountRecords(int clientID, AccountOpType opType)
        {
            List<clsAccount> response = new List<clsAccount>();
            try
            {
                response = _objBOEngineClient.GetAccounts(clsGlobal.userIDPwd, clientID, opType).ToList();
            }

            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : GetAccountRecords => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return response;
        }

        public clsAccount InsertAccount(clsAccount accountInfo)
        {
            clsAccount response = null;
            try
            {
                response = _objBOEngineClient.InsertIntoAccount(clsGlobal.userIDPwd, accountInfo);
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : InsertAccount => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return response;
        }

        public clsAccount UpdateAccount(clsAccount accountInfo, AccountOpType opType)
        {
            clsAccount response = null;
            try
            {
                response = _objBOEngineClient.UpdateAccount(clsGlobal.userIDPwd, accountInfo, opType);
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : UpdateAccount => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return response;
        }


        #endregion " Handle Client Account  "

        #region "   Handle Client Bank   "

        public List<clsBank> GetBankRecords(int clientID)
        {
            List<clsBank> response = new List<clsBank>();
            try
            {
                response = _objBOEngineClient.GetBankInfo(clsGlobal.userIDPwd, clientID).ToList();
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : GetBankRecords => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return response;
        }

        public clsBank InsertBank(clsBank bankInfo)
        {
            clsBank response = null;
            try
            {
                response = _objBOEngineClient.InsertIntoBankInfo(clsGlobal.userIDPwd, bankInfo);
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : InsertBank => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return response;
        }

        public clsBank UpdateBank(clsBank bankInfo)
        {
            clsBank response = null;
            try
            {
                response = _objBOEngineClient.UpdateBankInfo(clsGlobal.userIDPwd, bankInfo);
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : UpdateBank => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return response;
        }



        #endregion " Handle Client Bank  "

        #region "   Handle ClientInfo   "

        public List<clsClientInfo> GetClientInfoRecords()
        {
            List<clsClientInfo> response = null;
            try
            {
                response = _objBOEngineClient.GetClientInfo(clsGlobal.userIDPwd).ToList();
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : GetClientInfoRecords => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return response;
        }

        public clsClientInfo InsertClientInfo(clsClientInfo clientInfo)
        {
            clsClientInfo response = null;
            try
            {
                response = _objBOEngineClient.InsertIntoClientInfo(clsGlobal.userIDPwd, clientInfo);
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : InsertClientInfo => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return response;
        }

        public clsClientInfo UpdateClientInfo(clsClientInfo broker)
        {
            clsClientInfo response = null;
            try
            {
                response = _objBOEngineClient.UpdateClientInfo(clsGlobal.userIDPwd, broker);
            }

            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : UpdateClientInfo => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return response;
        }

        public bool AuthenticateClientID(string clientId)
        {
            bool response = false;
            try
            {
                response = _objBOEngineClient.AuthenticateClientID(clsGlobal.userIDPwd, clientId);
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : InsertClientInfo => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return response;
        }


        #endregion " Handle ClientInfo  "

        #region "   Handle AccountGroup   "

        public List<clsAccountGroup> GetAccountGroupRecords()
        {
            List<clsAccountGroup> response = new List<clsAccountGroup>();
            try
            {
                response = _objBOEngineClient.GetAccountGroup(clsGlobal.userIDPwd).ToList();
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : GetAccountGroupRecords => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return response;
        }

        #endregion " Handle AccountGroup  "

        #region "   Handle CollateralInfo   "

        public List<clsCollateralInfo> GetCollateralInfoRecords()
        {
            List<clsCollateralInfo> response = null;
            try
            {
                response = _objBOEngineClient.GetCollateralInfo(clsGlobal.userIDPwd).ToList();
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : GetCollateralInfoRecords => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return response;
        }


        #endregion " Handle CollateralInfo  "

        #region "   Handle CollateralTransInfo   "

        public List<clsCollateralTransInfo> GetCollateralTransInfoRecords(int accountGroupId)
        {
            List<clsCollateralTransInfo> response = new List<clsCollateralTransInfo>();
            try
            {
                response = _objBOEngineClient.HandleCollateralTransInfo(clsGlobal.userIDPwd, accountGroupId, OperationTypes.GET, null).ToList();
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : GetCollateralTransInfoRecords => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return response;
        }

        public List<clsCollateralTransInfo> GetCollateralTransHistoryRecords(int accountGroupId, int CollateralTypeID)
        {
            List<clsCollateralTransInfo> response = new List<clsCollateralTransInfo>();
            try
            {
                response = _objBOEngineClient.GetCollateralTransactionHistory(clsGlobal.userIDPwd, accountGroupId, CollateralTypeID).ToList();
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : GetCollateralTransInfoRecords => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return response;
        }

        public clsCollateralTransInfo InsertCollateralTransInfo(clsCollateralTransInfo collateralTransInfo)
        {
            clsCollateralTransInfo response = null;
            try
            {
                response = _objBOEngineClient.HandleCollateralTransInfo(clsGlobal.userIDPwd, 0, OperationTypes.INSERT, collateralTransInfo)[0];
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : InsertCollateralTransInfo => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return response;
        }


        #endregion " Handle CollateralTransInfo  "

        #region "   Handle Trades   "

        public List<clsTrades> GetTradesRecords(DateTime _startDate, DateTime _endDate)
        {
            List<clsTrades> response = new List<clsTrades>();
            try
            {
                response = _objBOEngineClient.GetTradeOrdersDetails(clsGlobal.userIDPwd, _startDate, _endDate).ToList();
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : GetTradesRecords => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return response;
        }
        public List<clsTrades> GetTradeDetails(DateTime _startDate, DateTime _endDate)
        {
            List<clsTrades> response = new List<clsTrades>();
            try
            {
                response = _objBOEngineClient.GetTradeDetails(clsGlobal.userIDPwd, _startDate, _endDate).ToList();
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : GetTradeDetails => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return response;
        }
        public clsModifyTrades ModifyTrade(clsModifyTrades objModifyTrade)
        {
            clsModifyTrades response = null;
            try
            {
                response = _objBOEngineClient.ModifyTrade(clsGlobal.userIDPwd, objModifyTrade);
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : ModifyTrade => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return response;
        }

        public clsNewOrder NewTrade(clsNewOrder objnewtrade)
        {
            clsNewOrder response = null;
            try
            {
                response = _objBOEngineClient.NewTrade(clsGlobal.userIDPwd, objnewtrade);
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsproxyclassmanager : newtrade => exception" + ex.Message + "stacktrace" + ex.StackTrace);
            }
            return response;
        }

        public clsSettleTrade SettleTrade(clsSettleTrade objSettleTrade)
        {
            clsSettleTrade response = null;
            try
            {
                response = _objBOEngineClient.SettleTrade(clsGlobal.userIDPwd, objSettleTrade);
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : SettleTrade => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return response;
        }

        #endregion " Handle Trades  "

        #region "   Handle MapOrders   "

        public List<clsMapOrders> GetMapOrdersRecords()
        {
            List<clsMapOrders> response = null;
            try
            {
                response = _objBOEngineClient.GetMapOrders(clsGlobal.userIDPwd).ToList();
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : GetMapOrdersRecords => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return response;
        }

        public List<string> GetAccountIDsByAccountTypeID(int accountTypeID)
        {
            List<string> response = null;
            try
            {
                response = _objBOEngineClient.GetAccountIDsByAccountType(clsGlobal.userIDPwd, accountTypeID).ToList();
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : GetAccountIDsByAccountTypeID => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return response;
        }

        #endregion " Handle MapOrders  "

        #region "   Handle TGAccountConnectionSettings   "

        public List<clsTGAccountConnectionSettings> GetTGAccountConnectionSettingsRecords()
        {
            List<clsTGAccountConnectionSettings> response = new List<clsTGAccountConnectionSettings>();
            try
            {
                response = _objBOEngineClient.HandleTGAccountConnetionSettings(clsGlobal.userIDPwd, OperationTypes.GET, null).ToList();

            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : GetTGAccountConnectionSettingsRecords => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return response;
        }

        public clsTGAccountConnectionSettings InsertTGAccountConnectionSettings(clsTGAccountConnectionSettings TGACSettings)
        {
            clsTGAccountConnectionSettings response = null;
            try
            {
                response = _objBOEngineClient.HandleTGAccountConnetionSettings(clsGlobal.userIDPwd, OperationTypes.INSERT, TGACSettings)[0];
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : InsertTGAccountConnectionSettings => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return response;
        }

        public clsTGAccountConnectionSettings UpdateTGAccountConnectionSettings(clsTGAccountConnectionSettings TGACSettings)
        {
            clsTGAccountConnectionSettings response = null;
            try
            {
                response = _objBOEngineClient.HandleTGAccountConnetionSettings(clsGlobal.userIDPwd, OperationTypes.UPDATE, TGACSettings)[0];
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : UpdateTGAccountConnectionSettings => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return response;
        }


        #endregion " Handle TGAccountConnectionSettings  "

        #region "       Virtual Dealer       "

        public List<clsVirtualDealerInfo> GetVirtualDealerRecords()
        {
            List<clsVirtualDealerInfo> response = new List<clsVirtualDealerInfo>();
            try
            {
                response = _objBOEngineClient.HandleVirtualDealer(clsGlobal.userIDPwd, OperationTypes.GET, null).ToList();
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : GetVirtualDealerRecords => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return response;
        }

        public clsVirtualDealerInfo InsertVirtualDealer(clsVirtualDealerInfo feeMaster)
        {
            clsVirtualDealerInfo response = null;
            try
            {
                response = _objBOEngineClient.HandleVirtualDealer(clsGlobal.userIDPwd, OperationTypes.INSERT, feeMaster)[0];
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : InsertVirtualDealer => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return response;
        }

        public clsVirtualDealerInfo UpdateVirtualDealer(clsVirtualDealerInfo feeMaster)
        {
            clsVirtualDealerInfo response = null;
            try
            {
                response = _objBOEngineClient.HandleVirtualDealer(clsGlobal.userIDPwd, OperationTypes.UPDATE, feeMaster)[0];
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : UpdateVirtualDealer => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return response;
        }

        public int DeleteVirtualDealer(int key)
        {
            int deleteID = clsGlobal.FailureID;
            try
            {
                deleteID = _objBOEngineClient.HandleVirtualDealer(clsGlobal.userIDPwd, OperationTypes.DELETE, new clsVirtualDealerInfo { VirtualDealerID = key })[0].VirtualDealerID;
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : DeleteVirtualDealer => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return deleteID;
        }


        #endregion "    Virtual Dealer       "

        #region "    Common Settings   "

        public List<clsCommonSettings> GetCommonSettingsRecords()
        {
            List<clsCommonSettings> response = null;
            try
            {
                response = _objBOEngineClient.HandleCommonSettings(clsGlobal.userIDPwd, OperationTypes.GET, null).ToList();
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : GetCommonSettingsRecords => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return response;
        }
        public clsCommonSettings UpdateCommonSettings(clsCommonSettings TGACSettings)
        {
            clsCommonSettings response = null;
            try
            {
                response = _objBOEngineClient.HandleCommonSettings(clsGlobal.userIDPwd, OperationTypes.UPDATE, TGACSettings)[0];
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : UpdateCommonSettings => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            return response;
        }

        #endregion " Common Settings   "

        #region "    Handle Reports Data   "


        public void OpenBOEngineChannel()
        {
            try
            {
                _objBOEngineClient = new BOEngineServiceClient("WSHttpBinding_IBOEngineService");

                if (_objBOEngineClient.State == CommunicationState.Faulted)
                {
                    //Logging.FileHandling.WriteAllLog("clsProxyClassManager : Unable to connect to server");
                }
                if (!IsConnectionAvailble())
                    return;
                _objBOEngineClient.Open();
            }
            catch (TimeoutException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : OpenRepotsChannel => TimeoutException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (CommunicationException)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : OpenRepotsChannel => CommunicationException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (Exception)
            {
                _objBOEngineClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : OpenRepotsChannel => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
        }
        public void OpenRepotsChannel()
        {
            try
            {
                _objReportClient = new ReportClient("WSHttpBinding_IReport");
                //_objReportClient.ClientCredentials.UserName.UserName = Properties.Settings.Default.ServerUerID;
                //_objReportClient.ClientCredentials.UserName.Password = Properties.Settings.Default.ServerPwd;
                if (_objReportClient.State == CommunicationState.Faulted)
                {
                    //Logging.FileHandling.WriteAllLog("clsProxyClassManager : Unable to connect to server");
                }
                if (!IsConnectionAvailble())
                    return;
                _objReportClient.Open();
            }
            catch (TimeoutException)
            {
                _objReportClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : OpenRepotsChannel => TimeoutException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (CommunicationException)
            {
                _objReportClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : OpenRepotsChannel => CommunicationException Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
            catch (Exception)
            {
                _objReportClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : OpenRepotsChannel => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
        }

        public void CloseRepotsChannel()
        {
            try
            {
                if (_objReportClient.State != CommunicationState.Faulted)
                {
                    _objReportClient.Close();
                }
            }
            catch (Exception)
            {
                _objReportClient.Abort();
                //Logging.FileHandling.WriteAllLog("clsProxyClassManager : CloseRepotsChannel => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
        }

        #endregion " Handle Reports Data   "

        #region "  Handle Instrument Closing Price  "

        #endregion "Handle Instrument Closing Price "

    }
}
