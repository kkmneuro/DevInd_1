using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using ProtocolStructs;
using System.Threading;
using System.Diagnostics;
using System.Collections;
using System.Net;
using ProtocolStructs.NewPS;

namespace BOADMIN_NEW.Cls
{
    public class clsDataManager
    {

        #region MEMMBERS
        clsClient _Client = null;
        static clsDataManager _DM = null;
        #endregion MEMBERS

        #region PROPERTY
        public bool isServerConnected
        {
            get
            {
                return _Client.IsConnected;

            }

        }

        public static clsDataManager INSTANCE
        {
            get
            {
                if (_DM == null)
                {
                    _DM = new clsDataManager();
                }
                return _DM;
            }
        }
        #endregion PROPERTY
        private clsDataManager()
        {
        }




        #region THREADING
        bool isQueueStart = true;
        Queue InQue = Queue.Synchronized(new Queue());
        Thread QProcessrIn;
        bool flagQProcessrIn = false;
        ManualResetEvent mreIn = new ManualResetEvent(false);

        Queue OutQue = Queue.Synchronized(new Queue());
        Thread QProcessrOut;
        bool flagQProcessrOut = false;
        ManualResetEvent mreOut = new ManualResetEvent(false);

        public void InitQueues()
        {
            InitQProcessrIn();
            InitQProcessrOut();
            ////Logging.FileHandling.WriteInOutLog("Test");
            ////Logging.FileHandling.WriteAllLog("Test");
        }
        public void StopQueues()
        {
            isQueueStart = false;
            mreOut.Set();
            mreIn.Set();

        }
        void mreOutSet()
        {
            if (flagQProcessrOut)
            {
                InitQProcessrOut();
            }
            mreOut.Set();
        }
        void mreInSet()
        {
            if (flagQProcessrIn)
            {
                InitQProcessrIn();
            }
            mreIn.Set();
        }

        private void InitQProcessrIn()
        {
            QProcessrIn = new Thread(new ThreadStart(ProcessIncomingData));
            QProcessrIn.IsBackground = true;
            QProcessrIn.Name = "FromClient";
            QProcessrIn.Start();
        }
        private void InitQProcessrOut()
        {
            QProcessrOut = new Thread(new ThreadStart(ProcessOutGoingData));
            QProcessrOut.IsBackground = true;
            QProcessrOut.Name = "ToServer";
            QProcessrOut.Start();
        }

        void ProcessIncomingData()
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("clsDataManager : Enter ProcessIncomingData()");
                while (isQueueStart)
                {
                    mreIn.WaitOne(Timeout.Infinite, false);
                    while (InQue.Count > 0)
                    {
                        IProtocolStruct structure = null;
                        lock (InQue.SyncRoot)
                        {
                            structure = (IProtocolStruct)InQue.Dequeue();
                        }
                        try
                        {
                            //HandleSocketData(structure);
                        }
                        catch (Exception)
                        {
                            //Logging.FileHandling.WriteAllLog("Exception :clsDataManager =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in ProcessIncomingData()");
                        }
                    }

                    mreIn.Reset();
                    Thread.Sleep(0);
                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsDataManager =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in ProcessIncomingData()");
            }
            flagQProcessrIn = true;
            Thread.CurrentThread.Join();
        }

        void ProcessOutGoingData()
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("clsDataManager : Enter ProcessOutGoingData()");
                while (isQueueStart)
                {
                    mreOut.WaitOne(Timeout.Infinite);
                    while (OutQue.Count > 0)
                    {
                        IProtocolStruct PS = null;
                        lock (OutQue.SyncRoot)
                        {
                            PS = (IProtocolStruct)OutQue.Dequeue();
                        }

                        _Client.objSocClient.SendStruct(PS);

                    }
                    mreOut.Reset();
                }
                flagQProcessrOut = true;
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsDataManager =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in ProcessOutGoingData()");
            }
            Thread.CurrentThread.Join();
        }

        #endregion
        public void EnQueueSocketData(IProtocolStruct PS)
        {
            lock (InQue.SyncRoot)
            {
                InQue.Enqueue(PS);
            }
            mreInSet();
        }

        public void SubmitData(IProtocolStruct PS)
        {
            lock (OutQue.SyncRoot)
            {
                OutQue.Enqueue(PS);
            }
            mreOutSet();
        }

        public void HandleSocketData(IProtocolStruct structure)
        {
            switch (structure.ID)
            {
                case ProtocolStructIDS.Login_ResponseID:
                    DoHandleLogin(structure as ResponceToLoginPS);
                    break;
                case ProtocolStructIDS.Symbol_ID:
                    DoHandleSymbol(structure);
                    break;
                case ProtocolStructIDS.AccessIp_ID:
                    DoHandleIPAccessList(structure);
                    break;
                case ProtocolStructIDS.Holiday_ID:
                    DoHandleHoliday(structure);
                    break;

                //DoHandleBankAccount(structure);
                //break;
                case ProtocolStructIDS.Account_ID:
                case ProtocolStructIDS.Country_ID:
                case ProtocolStructIDS.Bank_ID:
                case ProtocolStructIDS.Client_ID:
                    DoHandleAccount(structure);
                    break;
                case ProtocolStructIDS.Currency_ID:
                    DoHandleCurrency(structure);
                    break;
                case ProtocolStructIDS.Leverage_ID:
                    DoHandleLeverage(structure);
                    break;
                case ProtocolStructIDS.DataFeeds_ID:
                    DoHandleDataFeeds(structure);
                    break;
                case ProtocolStructIDS.Synchronization_ID:
                    DoHandleSynchronization(structure);
                    break;
                case ProtocolStructIDS.LiveUpdate_ID:
                    DoHandleLiveUpdate(structure);
                    break;
                case ProtocolStructIDS.Common_ID:
                    DoHandleCommon(structure as CommonPS);
                    break;
                case ProtocolStructIDS.BackUp_ID:
                    DoHandleBackUp(structure as BackUpPS);
                    break;
                case ProtocolStructIDS.ParticipantOrder_ID:
                    DoHandleOrders(structure as ParticipantOrderPS);
                    break;
                case ProtocolStructIDS.Order_ID:
                    DoHandleOrders(structure as OrdersPS);
                    break;
                case ProtocolStructIDS.Security_ID:
                    DoHandleSecurity(structure);
                    break;
                case ProtocolStructIDS.Time_ID:
                    DoHandleTime(structure);
                    break;
                case ProtocolStructIDS.Group_ID:
                    DoHandleGroup(structure);
                    break;
                case ProtocolStructIDS.DataServer_ID:
                    DoHandleDataServer(structure);
                    break;
                case ProtocolStructIDS.ManagerRights_ID:
                    DoHandleManagerRights(structure);
                    break;
                case ProtocolStructIDS.DBResponse_ID:
                    ////Logging.FileHandling.WriteInOutLog(structure.ToString());
                    ////Logging.FileHandling.WriteAllLog(structure.ToString());
                    //DoHandleDBResponse(structure as DBResponsePS);
                    break;
                case ProtocolStructIDS.DBDelete_ID:
                    DoHandleDBDelete(structure as DBDeletePS);
                    break;
                case ProtocolStructIDS.ManagerRole_ID:
                    DoHandleManagerRole(structure);
                    break;
                case ProtocolStructIDS.TradingGateway_ID:
                    DoHandleTradingGateway(structure);
                    break;
                case ProtocolStructIDS.AccountGroup_ID:
                    DoHandleAccount(structure);
                    break;
                case ProtocolStructIDS.FeeMaster_ID:
                    DoHandleFeeMaster(structure);
                    break;
                case ProtocolStructIDS.BrokersGroup_ID:
                    DoHandleBrokers(structure);
                    break;
                case ProtocolStructIDS.TaxMasterID:
                    DoHandleTaxMaster(structure);
                    break;
                case ProtocolStructIDS.ParticipantType_ID:
                    DoHandleParticipantTypes(structure);
                    break;
                case ProtocolStructIDS.Broker_ID:
                    DoHandleBrokerList(structure);
                    break;
                case ProtocolStructIDS.Module_ID:
                    DoHandleModules(structure);
                    break;
                case ProtocolStructIDS.MasterInfo_ID:
                    DoHandleMasterInfo(structure);
                    break;
                case ProtocolStructIDS.CollateralType_ID:
                    DoHandleCollateralTypes(structure as CollateralTypesPS);
                    break;
                case ProtocolStructIDS.BrokerCollateralTrans_ID:
                    DoHandleBrokerCollateralTrans(structure as BrokerLastCollateralTransactionPS);
                    break;
                case ProtocolStructIDS.BrokerCollateral_ID:
                    DoHandleBrokerCollateralInfo(structure as BrokerCollateralInfoPS);
                    break;
                case ProtocolStructIDS.MapOrders_ID:
                    DoHandleMapOrdersInfo(structure as clsMapOrdersPS);
                    break;
                case ProtocolStructIDS.TGAccountConnectionSettings_ID:
                    DoHandleTGAccountConnectionSettings(structure as clsTGAccountConnectionSettingsPS);
                    break;
                default:
                    break;
            }
        }

        private void DoHandleTGAccountConnectionSettings(clsTGAccountConnectionSettingsPS clsTGAccountConnectionSettingsPS)
        {
            clsTradingGatewayManager.INSTANCE.AddSetting(clsTGAccountConnectionSettingsPS);
        }
        private void DoHandleMapOrdersInfo(clsMapOrdersPS mapOrdersPS)
        {
            clsMapOrderManager.INSTANCE.AddSetting(mapOrdersPS);
        }
        private void DoHandleModules(IProtocolStruct structure)
        {
            Cls.clsBrokerManager.INSTANCE.AddSetting(structure);
        }
        private void DoHandleBrokerCollateralTrans(IProtocolStruct structure)
        {
            Cls.clsCollateralManager.INSTANCE.AddSetting(structure);
        }

        private void DoHandleCollateralTypes(IProtocolStruct structure)
        {
            Cls.clsCollateralManager.INSTANCE.AddSetting(structure);
        }

        private void DoHandleBrokerCollateralInfo(IProtocolStruct structure)
        {
            Cls.clsCollateralManager.INSTANCE.AddSetting(structure);
        }

        private void DoHandleMasterInfo(IProtocolStruct structure)
        {
            Cls.clsMasterInfoManager.INSTANCE.AddSetting(structure);
        }

        private void DoHandleBrokerList(IProtocolStruct structure)
        {
            clsBrokerManager.INSTANCE.AddSetting(structure);
        }
        private void DoHandleParticipantTypes(IProtocolStruct structure)
        {
            clsParticipantTypeManager.INSTANCE.AddSetting(structure);
        }
        private void DoHandleBrokers(IProtocolStruct structure)
        {
            clsBrokersManagerHandler.INSTANCE.AddSetting(structure);
        }
        private void DoHandleBankAccount(IProtocolStruct structure)
        {
            clsBankAccountManager.INSTANCE.AddSetting(structure);
        }
        private void DoHandleCurrency(IProtocolStruct structure)
        {
            clsCurrencyManager.INSTANCE.AddSetting(structure);
        }

        private void DoHandleTradingGateway(IProtocolStruct structure)
        {
            clsTradingGatewayManager.INSTANCE.AddSetting(structure);
        }
        //private void DoHandleAccountPwd(IProtocolStruct structure)
        //{
        //    clsManagersManager.INSTANCE.AddSetting(structure);
        //}
        private void DoHandleManagerRole(IProtocolStruct structure)
        {
            clsManagersManager.INSTANCE.AddSetting(structure);
        }

        private void DoHandleDBDelete(DBDeletePS dBDeletePS)
        {
            int ID = dBDeletePS._DBDelete._DeleteID;
            IclsManager MGR = null;
            switch (ID)
            {
                case ProtocolStructIDS.DataServer_ID:
                    MGR = clsDataServersManager.INSTANCE;
                    break;
                case ProtocolStructIDS.AccessIp_ID:
                    MGR = clsIPAccessListManager.INSTANCE;
                    break;
                case ProtocolStructIDS.LiveUpdate_ID:
                    MGR = clsLiveUpdateManager.INSTANCE;
                    break;
                case ProtocolStructIDS.Holiday_ID:
                    MGR = clsHolidayManager.INSTANCE;
                    break;
                case ProtocolStructIDS.Synchronization_ID:
                    MGR = clsSynchronizationManager.INSTANCE;
                    break;
                case ProtocolStructIDS.DataFeeds_ID:
                    MGR = clsDataFeedsManager.INSTANCE;
                    break;

                case ProtocolStructIDS.Client_ID:
                    MGR = clsAccountManager.INSTANCE;
                    break;
                case ProtocolStructIDS.ManagerRights_ID:
                    MGR = clsManagersManager.INSTANCE;
                    break;
                case ProtocolStructIDS.ParticipantOrder_ID:
                   // MGR = clsOrdersManager.INSTANCE;
                    break;
                case ProtocolStructIDS.Security_ID:
                    MGR = clsSecurityManager.INSTANCE;
                    break;
                case ProtocolStructIDS.Symbol_ID:
                    MGR = clsSymbolManager.INSTANCE;
                    break;
                case ProtocolStructIDS.TradingGateway_ID:
                    MGR = clsTradingGatewayManager.INSTANCE;
                    break;
                case ProtocolStructIDS.FeeMaster_ID:
                    MGR = clsFeeMasterManager.INSTANCE;
                    break;
                case ProtocolStructIDS.BrokersGroup_ID:
                    MGR = clsBrokersManagerHandler.INSTANCE;
                    break;
                case ProtocolStructIDS.TaxMasterID:
                    MGR = clsTaxMasterManager.INSTANCE;
                    break;
                case ProtocolStructIDS.Order_ID:
                   // MGR = clsOrdersManager.INSTANCE;
                    break;
                default:
                    break;
            }

            if (MGR != null)
            {
                MGR.RemoveSetting(dBDeletePS._DBDelete._DeleteKey);
            }

        }

        private void DoHandleDBResponse(DBResponsePS dBResponsePS)
        {
            IclsManager.ShowSuccessMessage(dBResponsePS.ToString());
        }

        private void DoHandleManagerRights(IProtocolStruct managerRightsPS)
        {
            clsManagersManager.INSTANCE.AddSetting(managerRightsPS);
        }

        private void DoHandleLogin(ResponceToLoginPS loginResponsePS)
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("clsDataManager : Enter DoHandleLogin()");

                if (loginResponsePS.ResponceToLogin_.BrokerId_ == 0)
                {
                    FrmMain.Instance.IsConnected = false;
                    FrmMain.Instance.SetCommandActive(false);
                    clsDialogBox.ShowErrorBox("The username or password you entered is incorrect.", "Login Error", true);
                    FrmMain.Instance.LoginHandler();
                    //Process.GetCurrentProcess().Kill();
                    //Environment.Exit(1);
                }
                else if (loginResponsePS.ResponceToLogin_.BrokerId_ == -5)
                {
                    // Disconnect();
                    // _Client.Disconnect();
                    FrmMain.Instance.SetCommandActive(false);
                    clsDialogBox.ShowErrorBox("You are already login on other matchine.", "Warning", true);

                }
                else
                {
                    clsGlobal.BrokerID = loginResponsePS.ResponceToLogin_.BrokerId_;
                    clsGlobal.Role = loginResponsePS.ResponceToLogin_.Role_;
                    clsGlobal.BrokerName = loginResponsePS.ResponceToLogin_.BrokerName_;
                    clsGlobal.BrokerNameId = loginResponsePS.ResponceToLogin_.BrokerNameID_;
                    clsGlobal.CLietnID = loginResponsePS.ResponceToLogin_.LoginID_;
                    clsGlobal.BrokerCompany = loginResponsePS.ResponceToLogin_.BrokerCompany_;
                    FrmMain.Instance.ApplyUserRole(loginResponsePS.ResponceToLogin_.Role_);
                    FrmMain.Instance.SetCommandsVisiblity();
                    FrmMain.Instance.IsConnected = true;
                    FrmMain.Instance.SetCommandActive(true);
                }

                //Logging.FileHandling.WriteAllLog("clsDataManager : Exit DoHandleLogin()");
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsDataManager => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                  //  "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in DoHandleLogin()");
            }
        }
        //To display the message to UI from Server
        private void DoHandleDataServer(IProtocolStruct dataServerPS)
        {
            clsDataServersManager.INSTANCE.AddSetting(dataServerPS);
        }

        private void DoHandleGroup(IProtocolStruct groupPS)
        {

            clsGroupManager.INSTANCE.AddSetting(groupPS);

        }

        private void DoHandleTime(IProtocolStruct timePS)
        {
            clsTimeManager.INSTANCE.AddSetting(timePS);
        }

        private void DoHandleSecurity(IProtocolStruct securityPS)
        {
            clsSecurityManager.INSTANCE.AddSetting(securityPS);
        }

        private void DoHandleOrders(IProtocolStruct OrdersPS)
        {
            //clsOrdersManager.INSTANCE.AddSetting(OrdersPS);
        }

        private void DoHandleBackUp(BackUpPS backUpPS)
        {
            clsBackupManager.INSTANCE.AddBackupSettings(backUpPS._BackUp);
        }

        private void DoHandleCommon(CommonPS commonPS)
        {
            clsCommonManager.INSTANCE.AddCommonSetting(commonPS._Common);
        }

        private void DoHandleLiveUpdate(IProtocolStruct liveUpdatePS)
        {
            clsLiveUpdateManager.INSTANCE.AddSetting(liveUpdatePS);
        }

        private void DoHandleSynchronization(IProtocolStruct SynchonizationPS)
        {
            clsSynchronizationManager.INSTANCE.AddSetting(SynchonizationPS);
        }

        private void DoHandleDataFeeds(IProtocolStruct DataFeedsPs)
        {
            clsDataFeedsManager.INSTANCE.AddSetting(DataFeedsPs);
        }



        private void DoHandleAccount(IProtocolStruct accountPS)
        {
            clsAccountManager.INSTANCE.AddSetting(accountPS);
        }
        private void DoHandleLeverage(IProtocolStruct leveragePS)
        {
            clsLeverageManager.INSTANCE.AddSetting(leveragePS);
        }
        private void DoHandleHoliday(IProtocolStruct HolidayPs)
        {
            clsHolidayManager.INSTANCE.AddSetting(HolidayPs);
        }
        private void DoHandleIPAccessList(IProtocolStruct accessIpPS)
        {
            clsIPAccessListManager.INSTANCE.AddSetting(accessIpPS);
        }

        private void DoHandleSymbol(IProtocolStruct symbolPS)
        {
            clsSymbolManager.INSTANCE.AddSetting(symbolPS);
        }
        private void DoHandleFeeMaster(IProtocolStruct feesMasterPS)
        {
            clsFeeMasterManager.INSTANCE.AddSetting(feesMasterPS);
        }
        private void DoHandleTaxMaster(IProtocolStruct taxMasterPS)
        {
            clsTaxMasterManager.INSTANCE.AddSetting(taxMasterPS);
        }
    }
}
