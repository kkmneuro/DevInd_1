using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using clsInterface4OME;
using DSSocket.Classes;
using DSSocket.Interfaces;

using ProtocolStructs;
using ProtocolStructs.NewPS;


namespace BOADMIN_NEW.Cls
{
    public class clsClient : iGenParam4clsClient
    {

        #region Variables

        //public clsServerUI objServer;
        public Client objSocClient = new Client();
        TimerCallback cbPingServer;
        System.Threading.Timer tmrPingServer;
        public DateTime LastHeartBeatTime = DateTime.UtcNow;
        DateTime LastTimePrevCloseFetch = DateTime.UtcNow.AddDays(-1);
        TimerCallback cbPingStatus;
        System.Threading.Timer tmrCheckPingStatus;
        int HeartBeatTolerance;
        int HeartBeatInterval;
        int ReConnectionInterval = 4000;
        //DataManager dm = null;

        public DataTable dtQuotes = new DataTable();
        public Dictionary<string, int> DDQuotes = new Dictionary<string, int>();

        //List<OleDbParameter> _struct;
        object LockTradeData = new object();

        //bool ManipulateMarketInfo = true;



        private IPAddress _ServerIPAddress;
        public IPAddress ServerIPAddress
        {
            get { return _ServerIPAddress; }
            set { _ServerIPAddress = value; }
        }

        private int _ServerPort;
        public int ServerPort
        {
            get { return _ServerPort; }
            set { _ServerPort = value; }
        }

        string UserName, Password;

        public bool IsConnected
        {
            get { return objSocClient.Connected; }
        }

        object lck4OHLC = new object();

        #endregion

        public clsClient(OleDbConnection con, string lnqConnectionString)
        {
        }

        public void Start(string User, string Pwd)
        {
            UserName = User;
            Password = Pwd;
            objSocClient.DataReceived += new Client.DataReceivedHandler(objClient_DataReceived);
            objSocClient.OnDisconnection += new Client.OnDisconnectHandler(objClient_OnDisconnection);
            objSocClient.OnException += new Client.OnExceptionHandler(objClient_OnException);
            cbPingServer = new TimerCallback(PongServerCallBack);
            tmrPingServer = new System.Threading.Timer(cbPingServer, null, Timeout.Infinite, Timeout.Infinite);

            cbPingStatus = new TimerCallback(CheckPingStatusCallBack);
            tmrCheckPingStatus = new System.Threading.Timer(cbPingStatus, null, Timeout.Infinite, Timeout.Infinite);

            try
            {
                objSocClient.Connect(ServerIPAddress, ServerPort);
                FrmMain.Instance.IsConnected = true;
                FrmMain.Instance.SetCommandActive(true);
                RegisterStructures();
                //objSocClient.SendStruct(obj, () => { });
                objSocClient.StartReceiving();
                tmrCheckPingStatus.Change(this.ReConnectionInterval, this.ReConnectionInterval);
            }
            catch (TypeInitializationException ex)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsClient =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in Start()");
                System.Diagnostics.Trace.WriteLine(ex.ToString());
                FrmMain.Instance.IsConnected = false;
                FrmMain.Instance.SetCommandActive(false);
                System.Windows.Forms.DialogResult result = clsDialogBox.ShowMessageBox("Server is not Responding, Do you want to exit?", "Connection Error");
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    Process.GetCurrentProcess().Kill();
                    Environment.Exit(1);
                }
            }
            catch (Exception ex)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsClient =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in Start()");
                tmrCheckPingStatus.Change(this.ReConnectionInterval, this.ReConnectionInterval);
                FileHandling.WriteToLogEx(ex);
                System.Diagnostics.Trace.WriteLine(ex.ToString());
            }
        }


        void objClient_OnException(Client sender, Exception exception, bool? okToContinue)
        {
            objSocClient.Dispose();
        }

        void objClient_OnDisconnection(Client sender, Exception exception, bool isDisposing)
        {
            tmrPingServer.Change(Timeout.Infinite, Timeout.Infinite);
            objSocClient.Dispose();
        }
        void objClient_DataReceived(Client sender, IProtocolStruct structure)
        {
            clsDataManager.INSTANCE.EnQueueSocketData(structure);
        }

        public void Disconnect()
        {
            objSocClient.Dispose();
        }

        public void Reconnect()
        {
            tmrCheckPingStatus.Change(Timeout.Infinite, Timeout.Infinite);
            objSocClient = new Client();
            objSocClient.DataReceived += new Client.DataReceivedHandler(objClient_DataReceived);
            objSocClient.OnDisconnection += new Client.OnDisconnectHandler(objClient_OnDisconnection);
            objSocClient.OnException += new Client.OnExceptionHandler(objClient_OnException);
            RequestToLoginPS obj = new RequestToLoginPS();
            RequestToLogin LR = new RequestToLogin();
            IPHostEntry ip = Dns.GetHostEntry(Dns.GetHostName());
            LR.LoginId_ = UserName;
            LR.Password_ = Password;
            LR.IPAddress_ = ip.AddressList[0].ToString();
            obj.LoginRequest_ = LR;

            try
            {
                objSocClient.Connect(ServerIPAddress, ServerPort);
                System.Diagnostics.Trace.WriteLine("Connected");
                FrmMain.Instance.IsConnected = true;
                FrmMain.Instance.SetCommandActive(true);
                RegisterStructures();
                objSocClient.SendStruct(obj, () => { });
                objSocClient.StartReceiving();
                tmrCheckPingStatus.Change(this.ReConnectionInterval, this.ReConnectionInterval);
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsClient =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in Reconnect()");
                FrmMain.Instance.IsConnected = false;
                FrmMain.Instance.SetCommandActive(false);
                tmrCheckPingStatus.Change(this.ReConnectionInterval, this.ReConnectionInterval);
                FileHandling.WriteToLogEx(ex);
                System.Diagnostics.Trace.WriteLine(ex.ToString());
            }
        }

        private void RegisterStructures()
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("clsClient : Enter RegisterStructures()");
                objSocClient.RegisterStructure(ProtocolStructIDS.Currency_ID, typeof(CurrencyPS));
                objSocClient.RegisterStructure(ProtocolStructIDS.AccountPWD_ID, typeof(AccountPWDPS));
                objSocClient.RegisterStructure(ProtocolStructIDS.Login_ResponseID, typeof(ResponceToLoginPS));
                objSocClient.RegisterStructure(ProtocolStructIDS.BackUp_ID, typeof(BackUpPS));
                objSocClient.RegisterStructure(ProtocolStructIDS.Symbol_ID, typeof(SymbolPS));
                objSocClient.RegisterStructure(ProtocolStructIDS.HeartBeat_ID, typeof(HeartBeatPS));
                objSocClient.RegisterStructure(ProtocolStructIDS.AccessIp_ID, typeof(AccessIpPS));
                objSocClient.RegisterStructure(ProtocolStructIDS.Account_ID, typeof(AccountPS));
                objSocClient.RegisterStructure(ProtocolStructIDS.Bank_ID, typeof(BankPS));
                objSocClient.RegisterStructure(ProtocolStructIDS.Beneficiary_ID, typeof(BeneficiaryPS));
                objSocClient.RegisterStructure(ProtocolStructIDS.Chart_ID, typeof(ChartPS));
                objSocClient.RegisterStructure(ProtocolStructIDS.Common_ID, typeof(CommonPS));
                objSocClient.RegisterStructure(ProtocolStructIDS.DataFeeds_ID, typeof(DataFeedsPS));
                objSocClient.RegisterStructure(ProtocolStructIDS.DataServer_ID, typeof(DataServerPS));
                objSocClient.RegisterStructure(ProtocolStructIDS.Group_ID, typeof(GroupPS));
                objSocClient.RegisterStructure(ProtocolStructIDS.Holiday_ID, typeof(HolidayPS));
                objSocClient.RegisterStructure(ProtocolStructIDS.Login_RequestID, typeof(RequestToLoginPS));
                objSocClient.RegisterStructure(ProtocolStructIDS.LiveUpdate_ID, typeof(LiveUpdatePS));
                objSocClient.RegisterStructure(ProtocolStructIDS.ManagerRights_ID, typeof(ManagerRightsPS));
                objSocClient.RegisterStructure(ProtocolStructIDS.ParticipantJointDetail_ID, typeof(ParticipantJointDetailPS));
                objSocClient.RegisterStructure(ProtocolStructIDS.ParticipantOrder_ID, typeof(ParticipantOrderPS));
                objSocClient.RegisterStructure(ProtocolStructIDS.Participant_ID, typeof(ParticipantPS));
                objSocClient.RegisterStructure(ProtocolStructIDS.RegisterNewUser_ID, typeof(RegisterNewUserPS));
                objSocClient.RegisterStructure(ProtocolStructIDS.SecurityGroup_ID, typeof(SecurityGroupPS));
                objSocClient.RegisterStructure(ProtocolStructIDS.Security_ID, typeof(SecurityPS));
                objSocClient.RegisterStructure(ProtocolStructIDS.Synchronization_ID, typeof(SynchronizationPS));
                objSocClient.RegisterStructure(ProtocolStructIDS.Time_ID, typeof(TimePS));
                objSocClient.RegisterStructure(ProtocolStructIDS.UserLogin_ID, typeof(UserLoginInfoPS));
                objSocClient.RegisterStructure(ProtocolStructIDS.BrokerCollateral_ID, typeof(BrokerCollateralInfoPS));
                objSocClient.RegisterStructure(ProtocolStructIDS.BrokerCollateralTrans_ID, typeof(BrokerLastCollateralTransactionPS));
                objSocClient.RegisterStructure(ProtocolStructIDS.CollateralType_ID, typeof(CollateralTypesPS));
                objSocClient.RegisterStructure(ProtocolStructIDS.BrokersGroup_ID, typeof(BrokersPS));
                objSocClient.RegisterStructure(ProtocolStructIDS.MasterInfo_ID, typeof(clsMasterInfoPS));
                objSocClient.RegisterStructure(ProtocolStructIDS.FeeMaster_ID, typeof(FeeMasterPS));
                objSocClient.RegisterStructure(ProtocolStructIDS.Order_ID, typeof(OrdersPS));
                objSocClient.RegisterStructure(ProtocolStructIDS.TaxMasterID, typeof(TaxMasterPS));
                objSocClient.RegisterStructure(ProtocolStructIDS.TradingGateway_ID, typeof(TradingGatewayPS));
                objSocClient.RegisterStructure(ProtocolStructIDS.AccountGroup_ID, typeof(AccountGroupPS));
                objSocClient.RegisterStructure(ProtocolStructIDS.Client_ID, typeof(ClientInfoPS));
                objSocClient.RegisterStructure(ProtocolStructIDS.CollateralCommodity_ID, typeof(CollateralCommodityPS));
                objSocClient.RegisterStructure(ProtocolStructIDS.Country_ID, typeof(CountryPS));
                objSocClient.RegisterStructure(ProtocolStructIDS.DBDelete_ID, typeof(DBDeletePS));
                objSocClient.RegisterStructure(ProtocolStructIDS.DBResponse_ID, typeof(DBResponsePS));
                objSocClient.RegisterStructure(ProtocolStructIDS.Leverage_ID, typeof(LeveragePS));
                objSocClient.RegisterStructure(ProtocolStructIDS.ManagerRole_ID, typeof(ManagerRolePS));
                objSocClient.RegisterStructure(ProtocolStructIDS.ParticipantOrder_ID, typeof(ParticipantOrderPS));
                objSocClient.RegisterStructure(ProtocolStructIDS.ParticipantType_ID, typeof(ParticipantTypePS));
                objSocClient.RegisterStructure(ProtocolStructIDS.Broker_ID, typeof(BrokerTypePS));
                objSocClient.RegisterStructure(ProtocolStructIDS.Module_ID, typeof(ModulePS));
                objSocClient.RegisterStructure(ProtocolStructIDS.LogOut_ID, typeof(LogOutPS));
                objSocClient.RegisterStructure(ProtocolStructIDS.MapOrders_ID, typeof(clsMapOrdersPS));
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsClient =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in RegisterStructures()");
            }
        }

        private void DS_DOHandleHeartBeat(Client socketClient, HeartBeatPS HeartBeat)
        {
            LastHeartBeatTime = DateTime.UtcNow;
            Console.WriteLine(LastHeartBeatTime);
        }

        #region TimerForHeartBeat

        private void PongServerCallBack(object state)
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("clsClient : Enter PongServerCallBack()");
                //if (objSocClient.Connected)
                {
                    HeartBeatPS objHeartBeatPs = new HeartBeatPS();
                    objSocClient.SendStruct(objHeartBeatPs, () => { });
                }
            }
            catch (Exception ex)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsClient =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in PongServerCallBack()");
                FileHandling.WriteToLogEx(ex);
                Debug.WriteLine(ex.ToString());
            }
        }

        private void CheckPingStatusCallBack(object state)
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("clsClient : Enter CheckPingStatusCallBack()");
                TimeSpan TotalTimeElapsed = DateTime.UtcNow - LastHeartBeatTime;
                if (TotalTimeElapsed.TotalMilliseconds > HeartBeatTolerance && !IsConnected)
                {
                    LastHeartBeatTime = DateTime.UtcNow;
                    Disconnect();
                    Reconnect();
                    FrmMain.Instance.IsConnected = true;
                    FrmMain.Instance.SetCommandActive(true);
                }
            }
            catch (TypeInitializationException ex)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsClient =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in CheckPingStatusCallBack() TypeInitializationException");
                FrmMain.Instance.IsConnected = false;
                FrmMain.Instance.SetCommandActive(false);
                Trace.Write(ex.Message);
            }
            catch (ObjectDisposedException ex)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsClient =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in CheckPingStatusCallBack() ObjectDisposedException");
                Trace.Write(ex.Message); 
            }
            catch (Exception ex)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsClient =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in CheckPingStatusCallBack()");
                FileHandling.WriteToLogEx(ex);
                Debug.WriteLine(ex.ToString());
            }
        }

        #endregion

        #region iGenParam4clsClient Members

        int iGenParam4clsClient.HeartBeatTolerance
        {
            get
            {
                return this.HeartBeatTolerance;
            }
            set
            {
                this.HeartBeatTolerance = value;
            }
        }

        int iGenParam4clsClient.HeartBeatInterval
        {
            get
            {
                return this.HeartBeatInterval;
            }
            set
            {
                this.HeartBeatInterval = value;
            }
        }
        int iGenParam4clsClient.ReConnectionInterval
        {
            get
            {
                return this.ReConnectionInterval;
            }
            set
            {
                this.ReConnectionInterval = value;
            }
        }
        #endregion

        #region IDisposable Members
        private bool disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    //Do Disposition
                }
                if (tmrPingServer != null)
                {
                    tmrPingServer.Dispose();
                }
                if (tmrCheckPingStatus != null)
                {
                    tmrCheckPingStatus.Dispose();
                }
                StopProcessor();
            }

            disposed = true;
        }


        #endregion
        public void Close()
        {
            this.Dispose();
        }
        public void StopProcessor()
        {
        }
    }
}
