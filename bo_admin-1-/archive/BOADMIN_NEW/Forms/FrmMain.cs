using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Nevron.UI.WinForm.Controls;
using System.Diagnostics;
using BOADMIN_NEW.Cls;
using BOADMIN_NEW.Forms;
using System.Threading;
using BOADMIN_NEW.BOEngineServiceTCP;
using ProtocolStructs.NewPS;

namespace BOADMIN_NEW
{
    public partial class FrmMain : NForm
    {
        private delegate void EnbleChnage(bool enable);
        SplashScreenForm sf = new SplashScreenForm();
        private static FrmMain _frmMain = null;
        //bool _csLoaded = false;
        public bool _TaxMasterLoaded = false;
        public bool _FeeMasterLoaded = false;
        bool _IPAccessLoaded = false;
        //bool _TimeSettingsLoaded = false;
        bool _HolidayLoaded = false;
        bool _TSLoaded = false;
        bool _TradingGatewayLoaded = false;
        bool _BrokerLoaded = false;
        bool _ClientLoaded = false;
        bool _CollateralLoaded = false;
        bool _TradesOrdersLoaded = false;
        bool _MapOrdersLoaded = false;
        bool _VirtualDealerLoaded = false;
        bool _CommonSettingsLoaded = false;
        bool _TradesLoaded = false;
        bool _InstClosingPriceLoaded = false;

        #region Properties
        public static FrmMain Instance
        {
            get
            {
                if (_frmMain == null)
                {
                    _frmMain = new FrmMain();
                }
                return _frmMain;
            }
        }
        public bool IsConnected
        {
            set
            {
                if (value)
                {
                    lblServerStatus.ForeColor = Color.DarkGreen;
                    lblServerStatus.Text = "Connected";
                    this.Text = " Back Office Clearing and Settlement - Broker Company: " + clsGlobal.BrokerCompany;
                }
                else
                {
                    lblServerStatus.ForeColor = Color.Red;
                    lblServerStatus.Text = "Disconnected";
                }
            }
        }

        public void startProgressBar()
        {
            Action A = () =>
            {
                ui_pbMainForm.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            };
            if (this.InvokeRequired)
            {
                this.BeginInvoke(A);
            }
            else
            {
                A();
            }
        }

        public void stopProgressBar()
        {
            Action A = () =>
            {
                ui_pbMainForm.Style = System.Windows.Forms.ProgressBarStyle.Blocks;
            };
            if (this.InvokeRequired)
            {
                this.BeginInvoke(A);
            }
            else
            {
                A();
            }
        }

        public string SetProgressBarMessage
        {
            set
            {
                ui_lblProgressBarText.Text = value;
            }
        }

        public void SetProgressMessage(object obj)
        {
            ui_lblProgressBarText.Text = obj as string;
        }

        #endregion Properties

        private FrmMain()
        {
            try
            {

                //clsLogManager.INSTANCE._syncQueue.Enqueue("FrmMain : Enter FrmMain() constructor");     

                clsLogManager.INSTANCE._syncQueue.Enqueue("FrmMain : Enter FrmMain() constructor");
                this.Hide();
                Thread splashthread = new Thread(new ThreadStart(clsSplashScreen.ShowSplashScreen));
                splashthread.IsBackground = true;
                splashthread.Start();
                InitializeComponent();
                NSkinManager.Instance.Enabled = false;
                NUIManager.SetPredefinedFrame(PredefinedFrame.Simple);
                this.UpdateFrame();
                Process.GetCurrentProcess().Disposed += new EventHandler(FrmMain_Disposed);
                clsLogManager.INSTANCE._syncQueue.Enqueue("FrmMain : Exit FrmMain() constructor");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception :FrmMain =>" + ex.InnerException + "in FrmMain() constructor");
                clsLogManager.INSTANCE._syncQueue.Enqueue("Exception :FrmMain =>" + ex.InnerException + "in FrmMain() constructor");
            }
        }


        void FrmMain_Disposed(object sender, EventArgs e)
        {

        }

        public void OpenAllChannels()
        {
            try
            {
                ThreadPool.QueueUserWorkItem(OpenAllChannel =>
                {
                    clsProxyClassManager.INSTANCE.OpenBOEngineChannel();
                    clsProxyClassManager.INSTANCE.OpenRepotsChannel();
                });
            }
            catch (Exception ex)
            {
                clsLogManager.INSTANCE._syncQueue.Enqueue("Exception :FrmMain =>" + ex.InnerException + "in OpenAllChannels() constructor");
            }

        }

        public void ApplyUserRole(string Role)
        {
            try
            {
                clsLogManager.INSTANCE._syncQueue.Enqueue("FrmMain : Enter ApplyUserRole()");

                if (Role != string.Empty)
                {
                    foreach (NCommand command in ui_nmnuBar.Commands)
                    {
                        Recursive(command);
                    }
                }

                clsLogManager.INSTANCE._syncQueue.Enqueue("FrmMain : Exit ApplyUserRole()");
            }
            catch (Exception ex)
            {
                clsLogManager.INSTANCE._syncQueue.Enqueue("Exception :FrmMain => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                 "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in ApplyUserRole()");
            }
        }

        public void SetCommandsVisiblity()
        {
            ui_ntbFeeMaster.Properties.Visible = ui_nmnuCharges_FeesMaster.Properties.Visible;
            ui_ntbTaxMaster.Properties.Visible = ui_nmnuCharges_TaxMaster.Properties.Visible;
            ui_ntbHolidays.Properties.Visible = ui_nmnuExchange_Holidays.Properties.Visible;
            ui_ntbTimeSetting.Properties.Visible = ui_nmnuExchange_TimeSetting.Properties.Visible;
            ui_ntbIPAccess.Properties.Visible = ui_nmnuExchange_IPAccess.Properties.Visible;
            ui_ntbContractSpecification.Properties.Visible = ui_nmnuExchange_ContractSpecification.Properties.Visible;
            ui_ntbTradingGateway.Properties.Visible = ui_nmnuExchange_TradingGatway.Properties.Visible;
            ui_ntbBroker.Properties.Visible = ui_nmnuBroker_Broker.Properties.Visible;
            ui_ntbClients.Properties.Visible = ui_nmnuBroker_Clients.Properties.Visible;
            ui_ntbCollateral.Properties.Visible = ui_nmnuBroker_Collateral.Properties.Visible;
            ui_ntbTrade.Properties.Visible = ui_nmnuTrade_Trade.Properties.Visible;
            ui_ntbOrder.Properties.Visible = ui_nmnuTrade_Orders.Properties.Visible;
        }
        private void Recursive(NCommand commands)
        {
            foreach (NCommand command in commands.Commands)
            {
                if (command.Properties.ID > -1 && command.Properties.ID < clsGlobal.Role.Split('_').Count())//&& command.Properties.ID!=2)
                {
                    string[] xx = clsGlobal.Role.Split('_');
                    string x = xx[command.Properties.ID].Substring(0, 1);
                    command.Properties.Visible = Convert.ToBoolean(Convert.ToInt32(x));
                }
                Recursive(command);
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            try
            {
                this.Icon = Properties.Resources.favicon;
                clsLogManager.INSTANCE._syncQueue.Enqueue("FrmMain : Enter FrmMain_Load()");

                this.Opacity = 0;
                clsSplashScreen.UdpateStatusText("Loading Items.");
                Thread.Sleep(90);
                clsSplashScreen.UdpateStatusText("Loading Items..");
                Thread.Sleep(90);
                clsSplashScreen.UdpateStatusText("Loading Items...");
                Thread.Sleep(90);
                clsSplashScreen.UdpateStatusText("Loading Items....");
                Thread.Sleep(90);
                clsSplashScreen.UdpateStatusText("Items Loaded !!");
                Thread.Sleep(100);
                clsSplashScreen.CloseSplashScreen();

                //Icon of DAWISH
                //System.Drawing.Icon ico = new System.Drawing.Icon(Properties.Resources.myphoto, 16, 16);
                //this.Icon = ico;

                this.Show();
                this.Opacity = 100;
                SetCommandActive(false);
                SetCommandsIDs();
                LoadImages();
                nmnu_Window.Select += new CommandEventHandler(nmnu_Window_Select);
                LoginHandler();

                //ApplyUserRole();

                clsLogManager.INSTANCE._syncQueue.Enqueue("FrmMain : Exit FrmMain_Load()");
            }
            catch (Exception ex)
            {
                clsLogManager.INSTANCE._syncQueue.Enqueue("Exception :FrmMain => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                 "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in FrmMain_Load()");
            }
            //this.ui_pnlChildFormContainer.Visible = true;
            this.ui_pnlChildFormContainer.Size = this.ClientSize;
            this.ui_pnlChildFormContainer.Height = this.ui_pnlChildFormContainer.Height - 80;
            ui_ntbCollateral.Properties.Visible = false;
            ui_nmnuBroker_Collateral.Properties.Visible = false;
            ui_nmunMapOrders.Properties.Visible = false;
            ui_nmnuTrade_EditAccountsTrans.Properties.Visible = false;
        }

        private void BrokerHandler()
        {
            FrmMain.Instance.SetProgressBarMessage = "Loading Broker Details ....";

            bool flag = true;
            if (!_BrokerLoaded)
            {
                FrmMain.Instance.startProgressBar();
                flag = GetBroker();
                _BrokerLoaded = true;
            }
            if (flag)
            {
                Forms.frmBrokers objfrmBrokers = frmBrokers.INSTANCE; //new BOADMIN_NEW.Forms.frmBrokers();
                objfrmBrokers.MdiParent = this;
                //clsBrokersManagerHandler.INSTANCE._lstParentIds.Clear();
                //clsBrokersManagerHandler.INSTANCE.Recursive(clsGlobal.BrokerNameId);
                objfrmBrokers.Parent = ui_pnlChildFormContainer;
                objfrmBrokers.BringToFront();
                objfrmBrokers.Show();
            }
            else
            {
                clsDialogBox.ShowErrorBox("Not connected to server", "BOAdmin", true);
            }

            //FrmMain.Instance.stopProgressBar();
            FrmMain.Instance.SetProgressBarMessage = "Loading Broker Details Completed";
        }

        private bool GetBroker()
        {
            bool flag = true;
            try
            {
                clsLogManager.INSTANCE._syncQueue.Enqueue("FrmMain : Enter GetBroker()");

                clsProxyClassManager.INSTANCE._objBOEngineClient.HandleBrokersCompleted += new EventHandler<HandleBrokersCompletedEventArgs>(_objBrokerClient_HandleBrokersCompleted);
                clsProxyClassManager.INSTANCE._objBOEngineClient.HandleBrokersAsync(clsGlobal.userIDPwd, clsGlobal.BrokerNameId, OperationTypes.GET, null);
                // clsBrokersManagerHandler.INSTANCE.FillBrokersDataSet(clsProxyClassManager.INSTANCE.GetBrokerRecords());

                clsLogManager.INSTANCE._syncQueue.Enqueue("FrmMain : Exit GetBroker()");
            }
            catch (Exception ex)
            {
                flag = false;
                MessageBox.Show("FrmMain : GetBroker =>Error in getting Broker data");
                clsLogManager.INSTANCE._syncQueue.Enqueue("Exception :FrmMain => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in GetBroker()");
            }
            return flag;
        }

        void _objBrokerClient_HandleBrokersCompleted(object sender, HandleBrokersCompletedEventArgs e)
        {
            foreach (clsBroker item in e.Result)
            {
                clsBrokersManagerHandler.INSTANCE.DoHandleBrokersTable(item);
            }
            FrmMain.Instance.stopProgressBar();
        }

        private void ClientsHandler()
        {
            // FrmMain.Instance.SetProgressBarMessage = "Loading Client Details ....";

            //if (!_ClientLoaded)
            //{
            //    FrmMain.Instance.startProgressBar();
            //    _ClientLoaded = GetClient();                
            //}
            if (_ClientLoaded)
            {
                Forms.FrmClient_Accounts objfrmClient = BOADMIN_NEW.Forms.FrmClient_Accounts.GetInstance();
                objfrmClient.MdiParent = this;
                objfrmClient.Parent = ui_pnlChildFormContainer;
                objfrmClient.BringToFront();
                objfrmClient.Show();
                ui_nmnuTrade_Accounts.Enabled = true;
                ui_nmnuTrade_EditAccountsTrans.Enabled = true;
            }
            else
            {
                clsDialogBox.ShowErrorBox("Not connected to server", "BOAdmin", true);
            }

            // FrmMain.Instance.SetProgressBarMessage = "Loading Client Details Completed";
            //FrmMain.Instance.stopProgressBar();
        }

        public void LoadClients()
        {
            try
            {
                FrmMain.Instance.SetProgressBarMessage = "Loading Client Details ....";

                if (!_ClientLoaded)
                {
                    FrmMain.Instance.startProgressBar();
                    _ClientLoaded = GetClient();
                }
                if (!_ClientLoaded)
                {
                    clsDialogBox.ShowErrorBox("Not connected to server", "BOAdmin", true);
                }

                FrmMain.Instance.SetProgressBarMessage = "Loading Client Details Completed";
            }
            catch (Exception)
            {

            }
        }

        private bool GetClient()
        {
            bool flag = true;
            try
            {
                clsLogManager.INSTANCE._syncQueue.Enqueue("FrmMain : Enter GetClient()");

                clsProxyClassManager.INSTANCE._objBOEngineClient.GetClientInfoCompleted += new EventHandler<GetClientInfoCompletedEventArgs>(_objClientInfoClient_GetClientInfoCompleted);
                clsProxyClassManager.INSTANCE._objBOEngineClient.GetClientInfoAsync(clsGlobal.userIDPwd);

                clsLogManager.INSTANCE._syncQueue.Enqueue("FrmMain : Exit GetClient()");
            }
            catch (Exception ex)
            {
                //clsLogManager.INSTANCE._syncQueue.Enqueue("Exception :FrmMain =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in GetClient()");
                flag = false;
                MessageBox.Show("FrmMain : GetClient =>Error in getting Client data");
                clsLogManager.INSTANCE._syncQueue.Enqueue("Exception :FrmMain => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                    "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in GetClient()");
            }
            return flag;
        }

        void _objClientInfoClient_GetClientInfoCompleted(object sender, GetClientInfoCompletedEventArgs e)
        {
            foreach (clsClientInfo item in e.Result)
            {
                clsAccountManager.INSTANCE.DoHandleClientInfoTable(item);
            }

            FrmMain.Instance.stopProgressBar();
        }

        void nmnu_Window_Select(object sender, CommandEventArgs e)
        {
            Action A = () =>
                {
                    if (!ui_pnlChildFormContainer.HasChildren)//this.MdiChildren.Count() == 0)
                    {
                        foreach (NCommand item in nmnu_Window.Commands)
                        {
                            item.Enabled = false;
                        }
                    }
                    else
                    {
                        foreach (NCommand item in nmnu_Window.Commands)
                        {
                            item.Enabled = true;
                        }
                    }
                };
            if (this.InvokeRequired)
            {
                this.BeginInvoke(A);
            }
            else
            {
                A();
            }
        }

        public void LogoffMenuHandler()
        {
            try
            {
                clsLogManager.INSTANCE._syncQueue.Enqueue("FrmMain : Enter LogoffMenuHandler()");

                DialogResult result = clsDialogBox.ShowMessageBox("Are you sure want to Log Off?", "Log Off");
                if (result == DialogResult.Yes)
                {
                    FrmMain.Instance.SetProgressBarMessage = "Disconnecting from Server ....";
                    ClearAllDataSets();
                    IsConnected = false;
                    CloseAllMenuHandler();
                    //_objLoginClient.Open();   //close and open the connection for avoiding connection timeout problem
                    if (clsGlobal.Role != string.Empty)
                    {
                        clsBrokerOperationsLog objclsBrokerOpLog = new clsBrokerOperationsLog();
                        clsProxyClassManager.INSTANCE.LogOut(Cls.clsGlobal.userIDPwd, objclsBrokerOpLog);
                    }
                    //_objLoginClient.Close();
                    SetLoadedFlagsValue();
                    SetCommandActive(false);

                    FrmMain.Instance.SetProgressBarMessage = "Disconnected from Server";
                }

                clsLogManager.INSTANCE._syncQueue.Enqueue("FrmMain : Exit LogoffMenuHandler()");
            }
            catch (Exception ex)
            {
                clsLogManager.INSTANCE._syncQueue.Enqueue("Exception :FrmMain => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                  "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in LogoffMenuHandler()");
            }

        }

        public void SetLoadedFlagsValue()
        {
            Cls.clsGlobal.IsCSLoaded = false;
            //_csLoaded = false;
            _TaxMasterLoaded = false;
            _FeeMasterLoaded = false;
            _IPAccessLoaded = false;
            //_TimeSettingsLoaded = false;
            _HolidayLoaded = false;
            _TSLoaded = false;
            _TradingGatewayLoaded = false;
            _BrokerLoaded = false;
            _ClientLoaded = false;
            _CollateralLoaded = false;
            _TradesOrdersLoaded = false;
            _MapOrdersLoaded = false;
            _VirtualDealerLoaded = false;
            _CommonSettingsLoaded = false;
        }

        private void ClearAllDataSets()
        {
            try
            {
                clsLogManager.INSTANCE._syncQueue.Enqueue("FrmMain : Enter ClearAllDataSets()");

                lock (clsAccountManager.INSTANCE._DS4Account)
                {
                    clsAccountManager.INSTANCE._DS4Account.dtAccounts.Clear();
                    clsAccountManager.INSTANCE._DS4Account.dtClientInfo.Clear();
                    clsAccountManager.INSTANCE._DS4Account.dtBankInformation.Clear();

                    clsAccountManager.INSTANCE._DS4Account = new clsInterface4OME.DSBO.DS4Account();
                }
                clsAccountManager.INSTANCE._lstAccouontGroupName.Clear();
                clsAccountManager.INSTANCE._DS4AccountGroups.Clear();
                clsAccountManager.INSTANCE._DS4AccountGroups.dtAccountGroups.Clear();
                clsBrokersManagerHandler.INSTANCE._DS4Brokers.Clear();
                clsBrokersManagerHandler.INSTANCE._DS4Brokers.dtBrokers.Clear();
                clsBrokersManagerHandler.INSTANCE._DS4Brokers.dtBrokerParent.Clear();
                clsSymbolManager.INSTANCE._DS4Symbol.Clear();
                clsTradingGatewayManager.INSTANCE._DS4TradingGateway.Clear();

                clsLogManager.INSTANCE._syncQueue.Enqueue("FrmMain : Exit ClearAllDataSets()");
            }
            catch (Exception ex)
            {
                clsLogManager.INSTANCE._syncQueue.Enqueue("Exception :FrmMain => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                  "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in ClearAllDataSets()");
            }
        }


        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                DialogResult result = clsDialogBox.ShowMessageBox("Are you sure want to Exit?", "Exit");
                if (result == DialogResult.Yes)
                {
                    if (clsGlobal.Role != string.Empty)
                    {
                        clsBrokerOperationsLog objclsBrokerOpLog = new clsBrokerOperationsLog();
                        clsProxyClassManager.INSTANCE.LogOut(Cls.clsGlobal.userIDPwd, objclsBrokerOpLog);
                    }
                    Process.GetCurrentProcess().Kill();
                    Environment.Exit(1);
                }
                else
                    e.Cancel = true;
            }
            catch (Exception ex)
            {
                clsLogManager.INSTANCE._syncQueue.Enqueue("Exception :FrmMain =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in FrmMain_FormClosing()");
            }
        }

        private void ui_nmnuFile_Exit_Click(object sender, CommandEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Called when Close menu clicked
        /// </summary>
        private void CloseMenuHandler()
        {

            //if (this.ActiveMdiChild != null)
            //this.ActiveMdiChild.Close();
            if (ui_pnlChildFormContainer.Controls.Count > 0)
                ((FrmBase)ui_pnlChildFormContainer.Controls[0]).Close();
        }
        /// <summary>
        /// Called when TileVertically menu clicked
        /// </summary>
        private void TileVerticallyMenuHandler()
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        /// <summary>
        /// Called when TileHorizontally menu clicked
        /// </summary>
        private void TileHorizontallyMenuHandler()
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        /// <summary>
        /// Called when Cascade menu clicked
        /// </summary>
        private void CascadeMenuHandler()
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        /// <summary>
        /// Called when CloseAll menu clicked
        /// </summary>
        private void CloseAllMenuHandler()
        {
            //foreach (var frm in this.MdiChildren)
            //{
            //    frm.Close();
            //}
            foreach (Control item in ui_pnlChildFormContainer.Controls)
            {
                ((FrmBase)item).Close();
            }
            if (ui_pnlChildFormContainer.Controls.Count > 0)
            {
                ((FrmBase)ui_pnlChildFormContainer.Controls[0]).Close();
            }
        }
        private void TradingGatwayHandler()
        {
            FrmMain.Instance.SetProgressBarMessage = "Loading Trading Gateway Details ....";

            bool flag = true;
            if (!_TradingGatewayLoaded)
            {
                FrmMain.Instance.startProgressBar();
                flag = GetTradingGateways();
                _TradingGatewayLoaded = true;
            }
            if (flag)
            {
                Forms.frmTradingGateway objfrmTradingGateway = frmTradingGateway.INSTANCE;//new BOADMIN_NEW.Forms.frmTradingGateway();
                objfrmTradingGateway.MdiParent = this;
                objfrmTradingGateway.Parent = ui_pnlChildFormContainer;
                objfrmTradingGateway.BringToFront();
                objfrmTradingGateway.Sizable = false;
                objfrmTradingGateway.Show();
            }
            else
            {
                clsDialogBox.ShowErrorBox("Not connected to server", "BOAdmin", true);
            }


            FrmMain.Instance.SetProgressBarMessage = "Loading Trading Gateway Details Completed";
            //FrmMain.Instance.stopProgressBar();
        }

        private bool GetTradingGateways()
        {
            bool flag = true;
            try
            {
                //clsTradingGatewayManager.INSTANCE.FillDataToDataSet();
                System.Threading.ThreadPool.QueueUserWorkItem(LoadTradingGateway, null);

            }
            catch (Exception ex)
            {
                clsLogManager.INSTANCE._syncQueue.Enqueue("Exception :FrmMain =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in GetTradingGateways()");
                flag = false;
                MessageBox.Show("FrmMain : GetTradingGateways =>Error in getting TradingGateways data");
            }
            return flag;
        }

        public void LoadTradingGateway(object obj)
        {
            clsTradingGatewayManager.INSTANCE.FillDataToDataSet();
        }

        public void FeesMasterHandler()
        {
            FrmMain.Instance.SetProgressBarMessage = "Loading FeeMaster Details ....";

            bool flag = true;
            if (!_FeeMasterLoaded)
            {
                FrmMain.Instance.startProgressBar();
                flag = GetFeeMaster();
                _FeeMasterLoaded = true;
            }
            if (flag)
            {
                Forms.frmFeeMaster objfrmFeeMaster = frmFeeMaster.GetInstance(); //new BOADMIN_NEW.Forms.frmFeeMaster();
                objfrmFeeMaster.MdiParent = this;
                objfrmFeeMaster.Parent = ui_pnlChildFormContainer;
                objfrmFeeMaster.BringToFront();
                objfrmFeeMaster.Sizable = false;
                objfrmFeeMaster.Show();
            }
            else
            {
                clsDialogBox.ShowErrorBox("Not connected to server", "BOAdmin", true);
            }

            FrmMain.Instance.SetProgressBarMessage = "Loading FeeMaster Details Completed";
            //FrmMain.Instance.stopProgressBar();
        }

        public bool GetFeeMaster()
        {
            bool flag = true;
            try
            {
                clsLogManager.INSTANCE._syncQueue.Enqueue("FrmMain : Enter GetFeeMaster()");

                
                clsProxyClassManager.INSTANCE._objBOEngineClient.HandleFeeMasterCompleted += new EventHandler<HandleFeeMasterCompletedEventArgs>(_objFeeMasterClient_HandleFeeMasterCompleted);
                clsProxyClassManager.INSTANCE._objBOEngineClient.HandleFeeMasterAsync(clsGlobal.userIDPwd, OperationTypes.GET, null);
                //Cls.clsFeeMasterManager.INSTANCE.FillDataToDataSet(clsProxyClassManager.INSTANCE.GetFeeMasterRecords());

                clsLogManager.INSTANCE._syncQueue.Enqueue("FrmMain : Exit GetFeeMaster()");

            }
            catch (Exception ex)
            {
                clsLogManager.INSTANCE._syncQueue.Enqueue("Exception :FrmMain => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                   "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in GetFeeMaster()");
                flag = false;
                MessageBox.Show("FrmMain : GetFeeMaster =>Error in getting FeeMaster data");
            }
            return flag;
        }

        void _objFeeMasterClient_HandleFeeMasterCompleted(object sender, HandleFeeMasterCompletedEventArgs e)
        {
            clsFeeMasterManager.INSTANCE.FillDataToDataSet(e.Result.ToList());
                        
            FrmMain.Instance.stopProgressBar();
        }

        private void TaxMasterHandler()
        {
            FrmMain.Instance.SetProgressBarMessage = "Loading TaxMaster Details ....";

            bool flag = true;
            if (!_TaxMasterLoaded)
            {
                FrmMain.Instance.startProgressBar();
                flag = GetTaxMaster();
                _TaxMasterLoaded = true;
            }
            if (flag)
            {
                Forms.frmTaxMaster objfrmTaxMaster = frmTaxMaster.GetInstance(); //new BOADMIN_NEW.Forms.frmTaxMaster();
                objfrmTaxMaster.MdiParent = this;
                objfrmTaxMaster.Parent = ui_pnlChildFormContainer;
                objfrmTaxMaster.BringToFront();
                objfrmTaxMaster.Sizable = false;
                objfrmTaxMaster.Show();
            }
            else
            {
                clsDialogBox.ShowErrorBox("Not connected to server", "BOAdmin", true);
            }


            FrmMain.Instance.SetProgressBarMessage = "Loading TaxMaster Details Completed";
            //FrmMain.Instance.stopProgressBar();
        }

        public bool GetTaxMaster()
        {
            bool flag = true;
            try
            {
                clsLogManager.INSTANCE._syncQueue.Enqueue("FrmMain : Enter GetTaxMaster()");
                //clsTaxMasterManager.INSTANCE.FillDataToDataSet();

                clsProxyClassManager.INSTANCE._objBOEngineClient.HandleTaxMasterCompleted -= new EventHandler<HandleTaxMasterCompletedEventArgs>(_objTaxMasterClient_HandleTaxMasterCompleted);
                clsProxyClassManager.INSTANCE._objBOEngineClient.HandleTaxMasterCompleted += new EventHandler<HandleTaxMasterCompletedEventArgs>(_objTaxMasterClient_HandleTaxMasterCompleted);
                clsProxyClassManager.INSTANCE._objBOEngineClient.HandleTaxMasterAsync(clsGlobal.userIDPwd, OperationTypes.GET, null);
                clsLogManager.INSTANCE._syncQueue.Enqueue("FrmMain : Exit GetTaxMaster()");
            }
            catch (Exception ex)
            {
                clsLogManager.INSTANCE._syncQueue.Enqueue("Exception :FrmMain => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                  "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in GetTaxMaster()");
                flag = false;
                MessageBox.Show("FrmMain : GetTaxMaster =>Error in getting TaxMaster data");
            }
            return flag;
        }

        void _objTaxMasterClient_HandleTaxMasterCompleted(object sender, HandleTaxMasterCompletedEventArgs e)
        {
            clsTaxMasterManager.INSTANCE.FillDataToDataSet(e.Result.ToList());
                       
            FrmMain.Instance.stopProgressBar();
        }
        private void HolidayHandler()
        {
            FrmMain.Instance.SetProgressBarMessage = "Loading Holiday Details ....";

            bool flag = true;
            if (!_HolidayLoaded)
            {
                FrmMain.Instance.startProgressBar();
                flag = GetHoliday();
                _HolidayLoaded = true;
            }
            if (flag)
            {
                Forms.frmHolidays objfrmHoliday = frmHolidays.INSTANCE; //new BOADMIN_NEW.Forms.frmHolidays();
                objfrmHoliday.MdiParent = this;
                objfrmHoliday.Parent = ui_pnlChildFormContainer;
                objfrmHoliday.BringToFront();
                objfrmHoliday.Sizable = false;
                objfrmHoliday.Show();
            }
            else
            {
                clsDialogBox.ShowErrorBox("Not connected to server", "BOAdmin", true);
            }

            FrmMain.Instance.SetProgressBarMessage = "Loading Holiday Details Completed";
            //FrmMain.Instance.stopProgressBar();
        }

        private bool GetHoliday()
        {
            bool flag = true;
            try
            {
                clsLogManager.INSTANCE._syncQueue.Enqueue("FrmMain : Enter GetHoliday()");

                clsHolidayManager.INSTANCE.FillDataToDataSet();

                clsLogManager.INSTANCE._syncQueue.Enqueue("FrmMain : Exit GetHoliday()");
            }
            catch (Exception ex)
            {
                clsLogManager.INSTANCE._syncQueue.Enqueue("Exception :FrmMain => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                  "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in GetHoliday()");
                flag = false;
                MessageBox.Show("FrmMain : GetHoliday =>Error in getting Holiday data");
            }
            return flag;
        }

        private void TimeSettingHandler()
        {
            FrmMain.Instance.SetProgressBarMessage = "Loading Time Settings Details ....";

            bool flag = true;
            if (!_TSLoaded)
            {
                FrmMain.Instance.startProgressBar();
                flag = GetTimeSettings();
                _TSLoaded = true;
            }
            if (flag)
            {
                frmTimeSettings objfrmTimeSettings = frmTimeSettings.INSTANCE;
                objfrmTimeSettings.MdiParent = this;
                objfrmTimeSettings.Parent = ui_pnlChildFormContainer;
                objfrmTimeSettings.BringToFront();
                objfrmTimeSettings.Show();
                //Forms.frmCommonContainer objfrmCommonContainer = new BOADMIN_NEW.Forms.frmCommonContainer();
                //Uctl.uctlTimeMain objectlTimeSettingMain = new BOADMIN_NEW.Uctl.uctlTimeMain();
                //objfrmCommonContainer.Controls.Clear();
                //objfrmCommonContainer.Controls.Add(objectlTimeSettingMain);
                ////objfrmCommonContainer.MinimizeBox = true;
                //objfrmCommonContainer.Text = "Time Settings";
                ////objfrmCommonContainer.Sizable = false;
                //objfrmCommonContainer.FormBorderStyle = FormBorderStyle.Sizable;
                //objfrmCommonContainer.MdiParent = this;
                //objfrmCommonContainer.Show();
            }
            else
            {
                clsDialogBox.ShowErrorBox("Not connected to server", "BOAdmin", true);
            }

            FrmMain.Instance.SetProgressBarMessage = "Loading Time Settings Details Completed";
            //FrmMain.Instance.stopProgressBar();
        }

        private bool GetTimeSettings()
        {
            bool flag = true;
            try
            {
                clsLogManager.INSTANCE._syncQueue.Enqueue("FrmMain : Enter GetTimeSettings()");

                clsTimeManager.INSTANCE.FillDataToDataSet();

                clsLogManager.INSTANCE._syncQueue.Enqueue("FrmMain : Exit GetTimeSettings()");
            }
            catch (Exception ex)
            {
                clsLogManager.INSTANCE._syncQueue.Enqueue("Exception :FrmMain => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                 "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in GetTimeSettings()");
                flag = false;
                MessageBox.Show("FrmMain : GetTimeSettings =>Error in getting TimeSettings data");
            }
            return flag;
        }
        private void OrderHandler()
        {
            try
            {
                //FrmMain.Instance.startProgressBar();
                FrmMain.Instance.SetProgressBarMessage = "Loading Order Details ....";

                bool flag = true;
                if (!_TradesOrdersLoaded)
                {
                    clsOrdersManager.INSTANCE.FillOrderDataSet(DateTime.Now.Date, Convert.ToDateTime(DateTime.Now.Date.ToString().Replace("12:00:00 AM", "23:59:59 PM")));
                    _TradesLoaded = true;
                }
                if (flag)
                {
                    frmOrders objfrmOrders = frmOrders.INSTANCE;
                    objfrmOrders.MdiParent = this;
                    objfrmOrders.Parent = ui_pnlChildFormContainer;
                    objfrmOrders.BringToFront();
                    objfrmOrders.Show();
                    //Forms.frmCommonContainer objfrmCommonContainer = new BOADMIN_NEW.Forms.frmCommonContainer();
                    //Uctl.uctlOrderMain objectOrderMain = new BOADMIN_NEW.Uctl.uctlOrderMain();
                    //objfrmCommonContainer.Controls.Clear();
                    //objfrmCommonContainer.Controls.Add(objectOrderMain);
                    //objfrmCommonContainer.Sizable = false;
                    //objfrmCommonContainer.Text = "Orders";
                    //objfrmCommonContainer.MdiParent = this;
                    //objfrmCommonContainer.Show();
                }
                else
                {
                    clsDialogBox.ShowErrorBox("Not connected to server", "BOAdmin", true);
                }

                FrmMain.Instance.SetProgressBarMessage = "Loading Order Details Completed";
                //FrmMain.Instance.stopProgressBar();
            }
            catch (Exception ex)
            {
                clsLogManager.INSTANCE._syncQueue.Enqueue("Exception :FrmMain =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in OrderHandler()");
            }

        }
        private void CollateralHandler()
        {
            try
            {
                FrmMain.Instance.SetProgressBarMessage = "Loading Collateral Details ....";

                bool flag = true;
                if (!_CollateralLoaded)
                {
                    FrmMain.Instance.startProgressBar();
                    flag = GetCollateralInfo();
                    _CollateralLoaded = true;
                }
                if (flag)
                {
                    frmCollateral objfrmCollateral = frmCollateral.INSTANCE;
                    objfrmCollateral.MdiParent = this;
                    objfrmCollateral.Parent = ui_pnlChildFormContainer;
                    objfrmCollateral.BringToFront();
                    objfrmCollateral.Show();
                }
                else
                {
                    clsDialogBox.ShowErrorBox("Not connected to server", "BOAdmin", true);
                }

                FrmMain.Instance.SetProgressBarMessage = "Loading Collateral Details Completed";
            }
            catch (Exception ex)
            {
                clsLogManager.INSTANCE._syncQueue.Enqueue("Exception :FrmMain =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in CollateralHandler()");
            }
        }

        private bool GetCollateralInfo()
        {
            bool flag = true;
            try
            {
                clsLogManager.INSTANCE._syncQueue.Enqueue("FrmMain : Enter GetCollateralInfo()");
                                
                clsProxyClassManager.INSTANCE._objBOEngineClient.GetCollateralInfoCompleted += new EventHandler<GetCollateralInfoCompletedEventArgs>(_objCollateralInfoClient_GetCollateralInfoCompleted);
                clsProxyClassManager.INSTANCE._objBOEngineClient.GetCollateralInfoAsync(clsGlobal.userIDPwd);

                clsLogManager.INSTANCE._syncQueue.Enqueue("FrmMain : Exit GetCollateralInfo()");
            }
            catch (Exception ex)
            {
                clsLogManager.INSTANCE._syncQueue.Enqueue("Exception :FrmMain => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                  "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in GetCollateralInfo()");
                flag = false;
                MessageBox.Show("FrmMain : GetCollateralInfo =>Error in getting CollateralInfo data");
            }
            return flag;
        }

        void _objCollateralInfoClient_GetCollateralInfoCompleted(object sender, GetCollateralInfoCompletedEventArgs e)
        {
            foreach (clsCollateralInfo item in e.Result)
            {
                clsCollateralManager.INSTANCE.DoHandleBrokerCollateralTable(item);

            }
            
            FrmMain.Instance.stopProgressBar();
        }
        private void TradeHandler()
        {
            try
            {
                //FrmMain.Instance.startProgressBar();
                FrmMain.Instance.SetProgressBarMessage = "Loading Trade Details ....";

                bool flag = true;
                if (!_TradesLoaded)
                {
                    //flag =cls //GetTradesOrderData();
                    clsTradeManager.INSTANCE.FillTradeDataSet(DateTime.Now.Date, Convert.ToDateTime(DateTime.Now.Date.ToString().Replace("12:00:00 AM", "23:59:59 PM")));
                    _TradesLoaded = true;
                }
                if (flag)
                {
                    frmTrades objfrmTrades = frmTrades.INSTANCE;
                    objfrmTrades.MdiParent = this;
                    objfrmTrades.Parent = ui_pnlChildFormContainer;
                    objfrmTrades.BringToFront();
                    objfrmTrades.Show();
                }
                else
                {
                    clsDialogBox.ShowErrorBox("Not connected to server", "BOAdmin", true);
                }

                FrmMain.Instance.SetProgressBarMessage = "Loading Trade Details Completed";
            }
            catch (Exception ex)
            {
                clsLogManager.INSTANCE._syncQueue.Enqueue("Exception :FrmMain =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in TradeHandler()");
            }
        }

        private bool GetTradesOrderData()
        {
            bool flag = true;
            try
            {
                clsLogManager.INSTANCE._syncQueue.Enqueue("FrmMain : Enter GetTradesOrderData()");

                foreach (clsTrades item in clsProxyClassManager.INSTANCE.GetTradesRecords(DateTime.Now.Date, DateTime.Now.Date))
                {
                    if (item.ServerResponseID == clsGlobal.FailureID)
                    {
                        flag = false;
                        return flag;
                    }
                    OrdersPS objOrdersPS = new OrdersPS();

                    objOrdersPS._Order._AccountID = item.AccountID;
                    objOrdersPS._Order._OrderID = item.OrderID;
                    objOrdersPS._Order._OrderPrice = item.OrderPrice;
                    objOrdersPS._Order._Quantity = item.Quantity;
                    objOrdersPS._Order._Time = item.Time;
                    objOrdersPS._Order._Type = item.Type;
                    objOrdersPS._Order._Validity = item.Validity;
                    objOrdersPS._Order._TriggerPrice = item.TriggerPrice;
                    objOrdersPS._Order._SymbolID = item.SymbolID;
                    objOrdersPS._Order._Status = item.Status;
                    objOrdersPS._Order._OrderType = item.OrderType;
                    objOrdersPS._Order._Comment = item.Comment;
                    objOrdersPS._Order._BrokerName = item.BrokerName;
                    objOrdersPS._Order._Volume = item.Volume;
                    objOrdersPS._Order._FilledQuantity = item.FilledQuantity;
                    objOrdersPS._Order._LeaveQuantity = item.LeaveQuantity;
                    objOrdersPS._Order._AvgFillPrice = item.AvgFillPrice;

                    clsDataManager.INSTANCE.HandleSocketData(objOrdersPS);
                }

                clsLogManager.INSTANCE._syncQueue.Enqueue("FrmMain : Exit GetTradesOrderData()");
            }
            catch (Exception ex)
            {
                clsLogManager.INSTANCE._syncQueue.Enqueue("Exception :FrmMain => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                 "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in GetTradesOrderData()");
                flag = false;
                MessageBox.Show("FrmMain : GetTradesOrderData =>Error in getting Trades and Orders data");
            }
            return flag;
        }

        private void IPAccessHandler()
        {
            try
            {
                FrmMain.Instance.SetProgressBarMessage = "Loading IPAccess Details ....";

                bool flag = true;
                if (!_IPAccessLoaded)
                {
                    FrmMain.Instance.startProgressBar();
                    flag = GetIPAccessData();
                    _IPAccessLoaded = true;
                }
                if (flag)
                {
                    Forms.frmIPAccessList objfrmIPAccessList = frmIPAccessList.INSTANCE; //new frmIPAccessList();
                    objfrmIPAccessList.MdiParent = this;
                    objfrmIPAccessList.Parent = ui_pnlChildFormContainer;
                    objfrmIPAccessList.BringToFront();
                    objfrmIPAccessList.Show();
                }
                else
                {
                    clsDialogBox.ShowErrorBox("Not connected to server", "BOAdmin", true);
                }

                FrmMain.Instance.SetProgressBarMessage = "Loading IPAccess Details Completed";
                //FrmMain.Instance.stopProgressBar();
            }
            catch (Exception ex)
            {
                clsLogManager.INSTANCE._syncQueue.Enqueue("Exception :FrmMain =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in IPAccessHandler()");
            }

        }

        private bool GetIPAccessData()
        {
            bool flag = true;
            try
            {
                clsLogManager.INSTANCE._syncQueue.Enqueue("FrmMain : Enter GetIPAccessData()");

                clsIPAccessListManager.INSTANCE.FillDataToDataSet();

                clsLogManager.INSTANCE._syncQueue.Enqueue("FrmMain : Exit GetIPAccessData()");

            }
            catch (Exception ex)
            {
                clsLogManager.INSTANCE._syncQueue.Enqueue("Exception :FrmMain => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                  "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in GetIPAccessData()");
                flag = false;
                MessageBox.Show("FrmMain : GetIPAccessData =>Error in getting IPAccessList data");
            }
            return flag;
        }
        private void ContractSpecificationHandler()
        {
            bool flag = true;
            try
            {
                FrmMain.Instance.SetProgressBarMessage = "Loading Contract Specification Details ....";

                if (!Cls.clsGlobal.IsCSLoaded)
                {
                    FrmMain.Instance.startProgressBar();
                    flag = GetContractSpecification();
                    Cls.clsGlobal.IsCSLoaded = true;
                    //_csLoaded = true;
                }
                if (flag)
                {
                    Forms.frmContractSpecificationMain objfrmContractSpecificationMain = frmContractSpecificationMain.INSTANCE; //new BOADMIN_NEW.Forms.frmContractSpecificationMain();
                    objfrmContractSpecificationMain.MdiParent = this;
                    objfrmContractSpecificationMain.Parent = ui_pnlChildFormContainer;
                    objfrmContractSpecificationMain.BringToFront();
                    objfrmContractSpecificationMain.Show();
                }
                else
                {
                    clsDialogBox.ShowErrorBox("Not connected to server", "BOAdmin", true);
                }

                FrmMain.Instance.SetProgressBarMessage = "Loading Contract Specification Details Completed";
                //FrmMain.Instance.stopProgressBar();
            }
            catch (Exception ex)
            {
                clsLogManager.INSTANCE._syncQueue.Enqueue("Exception :FrmMain =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in ContractSpecificationHandler()");
            }
        }

        private bool GetContractSpecification()
        {
            bool flag = true;
            try
            {
                clsLogManager.INSTANCE._syncQueue.Enqueue("FrmMain : Enter GetContractSpecification()");
                                
                clsProxyClassManager.INSTANCE._objBOEngineClient.HandleContractSpecficationCompleted += new EventHandler<HandleContractSpecficationCompletedEventArgs>(_objCS_HandleContractSpecficationCompleted);
                clsProxyClassManager.INSTANCE._objBOEngineClient.HandleContractSpecficationAsync(clsGlobal.userIDPwd, OperationTypes.GET, null);
                //clsSymbolManager.INSTANCE.FillDataToDataSet();

                clsLogManager.INSTANCE._syncQueue.Enqueue("FrmMain : Exit GetContractSpecification()");
            }
            catch (Exception ex)
            {
                clsLogManager.INSTANCE._syncQueue.Enqueue("Exception :FrmMain => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                  "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in GetContractSpecification()");
                flag = false;
                MessageBox.Show("FrmMain : GetContractSpecification =>Error in getting Contract Specifiacation data");
            }
            return flag;
        }

        void _objCS_HandleContractSpecficationCompleted(object sender, HandleContractSpecficationCompletedEventArgs e)
        {
            foreach (clsContractSpecification item in e.Result)
            {
                clsSymbolManager.INSTANCE.DoHandleSymbolTable(item);
            }

            
            FrmMain.Instance.stopProgressBar();
        }

        public void LoginHandler()
        {
            Action A = () =>
                {
                    frmDataLogin LoginForm = new frmDataLogin();
                    LoginForm.ShowDialog();
                };
            if (this.InvokeRequired)
            {
                this.BeginInvoke(A);
            }
            else
            {
                A();
            }
        }

        private void LoadImages()
        {
            try
            {
                clsLogManager.INSTANCE._syncQueue.Enqueue("FrmMain : Enter LoadImages()");

                Image imgFile = new Bitmap(Properties.Resources.file_strip);
                Image imgCharges = new Bitmap(Properties.Resources.charges_strip);
                Image imgExchange = new Bitmap(Properties.Resources.exchanges_strip);
                Image imgBroker = new Bitmap(Properties.Resources.brokerstrip);
                Image imgTrade = new Bitmap(Properties.Resources.trade_strip);
                Image imgWindow = new Bitmap(Properties.Resources.windowstrip);
                Image ImgToolbar = new Bitmap(Properties.Resources.tools_strip_20_by_20);


                ImageList imList = new ImageList();
                ImageList ToolImgList = new ImageList();

                ToolImgList.ImageSize = new Size(20, 20);
                ToolImgList.Images.AddStrip(ImgToolbar);

                imList.Images.AddStrip(imgFile);
                imList.Images.AddStrip(imgCharges);
                imList.Images.AddStrip(imgExchange);
                imList.Images.AddStrip(imgBroker);
                imList.Images.AddStrip(imgTrade);
                imList.Images.AddStrip(imgWindow);

                ui_nmnuBar.ImageList = imList;
                ui_ndtToolBar.ImageList = ToolImgList;

                ui_nmnuFile_Login.Properties.ImageIndex = 0;
                ui_nmnuFile_Logoff.Properties.ImageIndex = 1;
                ui_nmnuFile_Exit.Properties.ImageIndex = 2;

                ui_nmnuCharges_FeesMaster.Properties.ImageIndex = 3;
                ui_nmnuCharges_TaxMaster.Properties.ImageIndex = 4;

                ui_nmnuExchange_Holidays.Properties.ImageIndex = 5;
                ui_nmnuExchange_TimeSetting.Properties.ImageIndex = 6;
                ui_nmnuExchange_IPAccess.Properties.ImageIndex = 7;
                ui_nmnuExchange_ContractSpecification.Properties.ImageIndex = 8;
                ui_nmnuExchange_TradingGatway.Properties.ImageIndex = 9;

                ui_nmnuBroker_Broker.Properties.ImageIndex = 10;
                ui_nmnuBroker_Clients.Properties.ImageIndex = 11;
                ui_nmnuBroker_Collateral.Properties.ImageIndex = 12;

                ui_nmnuTrade_Trade.Properties.ImageIndex = 13;
                ui_nmnuTrade_Orders.Properties.ImageIndex = 14;

                ui_nmnuWindow_Close.Properties.ImageIndex = 15;
                ui_nmnuWindow_CloseAll.Properties.ImageIndex = 16;
                ui_nmnuWindow_Cascade.Properties.ImageIndex = 17;
                ui_nmnuWindow_TileHorizontal.Properties.ImageIndex = 18;
                ui_nmnuWindow_TileVetical.Properties.ImageIndex = 19;

                ui_ntbLogin.Properties.ImageIndex = 0;
                ui_ntbLogoff.Properties.ImageIndex = 1;
                ui_ntbFeeMaster.Properties.ImageIndex = 2;
                ui_ntbTaxMaster.Properties.ImageIndex = 3;
                ui_ntbHolidays.Properties.ImageIndex = 4;
                ui_ntbTimeSetting.Properties.ImageIndex = 5;
                ui_ntbIPAccess.Properties.ImageIndex = 6;
                ui_ntbContractSpecification.Properties.ImageIndex = 7;
                ui_ntbTradingGateway.Properties.ImageIndex = 8;
                ui_ntbBroker.Properties.ImageIndex = 9;
                ui_ntbClients.Properties.ImageIndex = 10;
                ui_ntbCollateral.Properties.ImageIndex = 11;
                ui_ntbTrade.Properties.ImageIndex = 12;
                ui_ntbOrder.Properties.ImageIndex = 13;

                clsLogManager.INSTANCE._syncQueue.Enqueue("FrmMain : Exit LoadImages()");
            }
            catch (Exception ex)
            {
                clsLogManager.INSTANCE._syncQueue.Enqueue("Exception :FrmMain => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                 "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in LoadImages()");
            }

        }

        private void SetCommandsIDs()
        {
            try
            {
                clsLogManager.INSTANCE._syncQueue.Enqueue("FrmMain : Enter SetCommandsIDs()");

                ui_nmnuFile_Login.Properties.ID = (int)Cls.clsEnums.CommandIDS.LOGIN;
                ui_nmnuFile_Logoff.Properties.ID = (int)Cls.clsEnums.CommandIDS.LOGOFF;
                ui_nmnuFile_Exit.Properties.ID = (int)Cls.clsEnums.CommandIDS.EXIT;
                ui_nmnuCharges_FeesMaster.Properties.ID = (int)Cls.clsEnums.CommandIDS.FEE_MASTER;
                ui_nmnuCharges_TaxMaster.Properties.ID = (int)Cls.clsEnums.CommandIDS.TAX_MASTER;
                ui_nmnuExchange_Holidays.Properties.ID = (int)Cls.clsEnums.CommandIDS.HOLIDAYS;
                ui_nmnuExchange_TimeSetting.Properties.ID = (int)Cls.clsEnums.CommandIDS.TIME_SETTINGS;
                ui_nmnuExchange_IPAccess.Properties.ID = (int)Cls.clsEnums.CommandIDS.IP_ACCESS;
                ui_nmnuExchange_ContractSpecification.Properties.ID = (int)Cls.clsEnums.CommandIDS.CONTRACT_SPECIFICATION;
                ui_nmnuExchange_TradingGatway.Properties.ID = (int)Cls.clsEnums.CommandIDS.TRADING_GATEWAY;
                ui_nmnuBroker_Broker.Properties.ID = (int)Cls.clsEnums.CommandIDS.BROKER;
                ui_nmnuBroker_Clients.Properties.ID = (int)Cls.clsEnums.CommandIDS.CLIENTS;
                ui_nmnuBroker_Collateral.Properties.ID = (int)Cls.clsEnums.CommandIDS.COLLATERAL;
                ui_nmnuTrade_Trade.Properties.ID = (int)Cls.clsEnums.CommandIDS.TRADES;
                ui_nmnuTrade_Orders.Properties.ID = (int)Cls.clsEnums.CommandIDS.ORDERS;
                ui_nmnuWindow_Close.Properties.ID = (int)Cls.clsEnums.CommandIDS.CLOSE;
                ui_nmnuWindow_CloseAll.Properties.ID = (int)Cls.clsEnums.CommandIDS.CLOSE_ALL;
                ui_nmnuWindow_Cascade.Properties.ID = (int)Cls.clsEnums.CommandIDS.CASCADE;
                ui_nmnuWindow_TileHorizontal.Properties.ID = (int)Cls.clsEnums.CommandIDS.TILE_HORIZONTALLY;
                ui_nmnuWindow_TileVetical.Properties.ID = (int)Cls.clsEnums.CommandIDS.TILE_VERTICALLY;

                ui_ntbLogin.Properties.ID = (int)Cls.clsEnums.CommandIDS.LOGIN;
                ui_ntbLogoff.Properties.ID = (int)Cls.clsEnums.CommandIDS.LOGOFF;
                ui_ntbFeeMaster.Properties.ID = (int)Cls.clsEnums.CommandIDS.FEE_MASTER;
                ui_ntbTaxMaster.Properties.ID = (int)Cls.clsEnums.CommandIDS.TAX_MASTER;
                ui_ntbHolidays.Properties.ID = (int)Cls.clsEnums.CommandIDS.HOLIDAYS;
                ui_ntbTimeSetting.Properties.ID = (int)Cls.clsEnums.CommandIDS.TIME_SETTINGS;
                ui_ntbIPAccess.Properties.ID = (int)Cls.clsEnums.CommandIDS.IP_ACCESS;
                ui_ntbContractSpecification.Properties.ID = (int)Cls.clsEnums.CommandIDS.CONTRACT_SPECIFICATION;
                ui_ntbTradingGateway.Properties.ID = (int)Cls.clsEnums.CommandIDS.TRADING_GATEWAY;
                ui_ntbBroker.Properties.ID = (int)Cls.clsEnums.CommandIDS.BROKER;
                ui_ntbClients.Properties.ID = (int)Cls.clsEnums.CommandIDS.CLIENTS;
                ui_ntbCollateral.Properties.ID = (int)Cls.clsEnums.CommandIDS.COLLATERAL;
                ui_ntbTrade.Properties.ID = (int)Cls.clsEnums.CommandIDS.TRADES;
                ui_ntbOrder.Properties.ID = (int)Cls.clsEnums.CommandIDS.ORDERS;
                ui_nmunMapOrders.Properties.ID = (int)Cls.clsEnums.CommandIDS.MAP_ORDERS;
                ui_nmnuExchange_CommonSettings.Properties.ID = (int)Cls.clsEnums.CommandIDS.COMMON_SETTINGS;
                ui_nmnuExchange_VirtualDealer.Properties.ID = (int)Cls.clsEnums.CommandIDS.VIRTUAL_DEALER;
                ui_nmnu_ReportsTrade.Properties.ID = (int)Cls.clsEnums.CommandIDS.TRADE_REPORT;
                ui_nmnu_ReportsOpenPosition.Properties.ID = (int)Cls.clsEnums.CommandIDS.OPEN_POSITION_REPORT;
                ui_nmnu_ReportsOrder.Properties.ID = (int)Cls.clsEnums.CommandIDS.ORDER_REPORT;
                ui_nmnu_ReportsClientCommission.Properties.ID = (int)Cls.clsEnums.CommandIDS.CLIENT_COMMISSION_REPORT;
                ui_nmnu_ReportsStockLevel.Properties.ID = (int)Cls.clsEnums.CommandIDS.STOCK_LEVEL_REPORT;
                ui_nmnu_ReportsClientHoldingStock.Properties.ID = (int)Cls.clsEnums.CommandIDS.CLIENT_HOSTING_REPORT;
                ui_nmnu_ReportsMargin.Properties.ID = (int)Cls.clsEnums.CommandIDS.MARGIN_REPORT;
                ui_nmnu_ReportsTopTradedInst.Properties.ID = (int)Cls.clsEnums.CommandIDS.TOP_TRADED_INSTRUMENTS;
                ui_nmnu_ReportsNewClientInfo.Properties.ID = (int)Cls.clsEnums.CommandIDS.NEW_CLIENT_INFO_REPORT;
                ui_nmnu_ReportsAccountTrans.Properties.ID = (int)Cls.clsEnums.CommandIDS.ACCOUNT_TRANS_REPORT;
                ui_nmnuFile_ChangePassword.Properties.ID = (int)Cls.clsEnums.CommandIDS.CHANGE_PASSWORD;
                ui_nmnuExchange_ClosingPriceManagement.Properties.ID = (int)Cls.clsEnums.CommandIDS.CLOSE_PRICED_MANAGEMENT;
                ui_nmnu_ReportsDayClosing.Properties.ID = (int)Cls.clsEnums.CommandIDS.DAY_CLOSING_REPORT;
                ui_nmnuExchange_TickManager.Properties.ID = (int)Cls.clsEnums.CommandIDS.TICK_MANAGER;
                ui_nmnu_ReportsClientMargin.Properties.ID = (int)Cls.clsEnums.CommandIDS.CLIENT_MARGIN_REPORT;
                ui_nmnuTrade_Accounts.Properties.ID = (int)Cls.clsEnums.CommandIDS.ACCOUNT;
                ui_nmnuExchange_OperationsLog.Properties.ID = (int)Cls.clsEnums.CommandIDS.OPERATIONS_LOG;
                ui_nmnuTrade_EditAccountsTrans.Properties.ID = (int)Cls.clsEnums.CommandIDS.EDIT_ACCOUNT_TRANS;
                ui_nmnuFile_ForceLogout.Properties.ID = (int)Cls.clsEnums.CommandIDS.FORCE_LOGOUT;

                clsLogManager.INSTANCE._syncQueue.Enqueue("FrmMain : Exit SetCommandsIDs()");
            }
            catch (Exception ex)
            {
                clsLogManager.INSTANCE._syncQueue.Enqueue("Exception :FrmMain => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in SetCommandsIDs()");
            }
        }

        private void nCmdManager_CommandClicked(object sender, CommandEventArgs e)
        {
            int commandID = e.Command.Properties.ID;
            switch ((BOADMIN_NEW.Cls.clsEnums.CommandIDS)commandID)
            {
                case BOADMIN_NEW.Cls.clsEnums.CommandIDS.LOGIN:
                    LoginHandler();
                    break;
                case BOADMIN_NEW.Cls.clsEnums.CommandIDS.LOGOFF:
                    LogoffMenuHandler();
                    break;
                case BOADMIN_NEW.Cls.clsEnums.CommandIDS.EXIT:
                    break;
                case BOADMIN_NEW.Cls.clsEnums.CommandIDS.FEE_MASTER:
                    FeesMasterHandler();
                    break;
                case BOADMIN_NEW.Cls.clsEnums.CommandIDS.TAX_MASTER:
                    TaxMasterHandler();
                    break;
                case BOADMIN_NEW.Cls.clsEnums.CommandIDS.HOLIDAYS:
                    HolidayHandler();
                    break;
                case BOADMIN_NEW.Cls.clsEnums.CommandIDS.TIME_SETTINGS:
                    TimeSettingHandler();
                    break;
                case BOADMIN_NEW.Cls.clsEnums.CommandIDS.IP_ACCESS:
                    IPAccessHandler();
                    break;
                case BOADMIN_NEW.Cls.clsEnums.CommandIDS.CONTRACT_SPECIFICATION:
                    ContractSpecificationHandler();
                    break;
                case BOADMIN_NEW.Cls.clsEnums.CommandIDS.TRADING_GATEWAY:
                    TradingGatwayHandler();
                    break;
                case BOADMIN_NEW.Cls.clsEnums.CommandIDS.BROKER:
                    BrokerHandler();
                    break;
                case BOADMIN_NEW.Cls.clsEnums.CommandIDS.CLIENTS:
                    ClientsHandler();
                    break;
                case BOADMIN_NEW.Cls.clsEnums.CommandIDS.COLLATERAL:
                    CollateralHandler();
                    break;
                case BOADMIN_NEW.Cls.clsEnums.CommandIDS.TRADES:
                    TradeHandler();
                    break;
                case BOADMIN_NEW.Cls.clsEnums.CommandIDS.ORDERS:
                    OrderHandler();
                    break;
                case BOADMIN_NEW.Cls.clsEnums.CommandIDS.CLOSE:
                    CloseMenuHandler();
                    break;
                case BOADMIN_NEW.Cls.clsEnums.CommandIDS.CLOSE_ALL:
                    CloseAllMenuHandler();
                    break;
                case BOADMIN_NEW.Cls.clsEnums.CommandIDS.CASCADE:
                    CascadeMenuHandler();
                    break;
                case BOADMIN_NEW.Cls.clsEnums.CommandIDS.TILE_HORIZONTALLY:
                    TileHorizontallyMenuHandler();
                    break;
                case BOADMIN_NEW.Cls.clsEnums.CommandIDS.TILE_VERTICALLY:
                    TileVerticallyMenuHandler();
                    break;
                case BOADMIN_NEW.Cls.clsEnums.CommandIDS.MAP_ORDERS:
                    MapOrdersMenuHandler();
                    break;
                case BOADMIN_NEW.Cls.clsEnums.CommandIDS.COMMON_SETTINGS:
                    CommonSettingsMenuHandler();
                    break;
                case BOADMIN_NEW.Cls.clsEnums.CommandIDS.VIRTUAL_DEALER:
                    VirtualDealerMenuHandler();
                    break;
                case BOADMIN_NEW.Cls.clsEnums.CommandIDS.TRADE_REPORT:
                    TradeReportMenuHandler();
                    break;
                case BOADMIN_NEW.Cls.clsEnums.CommandIDS.OPEN_POSITION_REPORT:
                    OpenPositionReportMenuHandler();
                    break;
                case BOADMIN_NEW.Cls.clsEnums.CommandIDS.ORDER_REPORT:
                    OrderReportMenuHandler();
                    break;
                case BOADMIN_NEW.Cls.clsEnums.CommandIDS.CLIENT_COMMISSION_REPORT:
                    ClientCommissionReportMenuHandler();
                    break;
                case BOADMIN_NEW.Cls.clsEnums.CommandIDS.STOCK_LEVEL_REPORT:
                    StockLevelReportMenuHandler();
                    break;
                case BOADMIN_NEW.Cls.clsEnums.CommandIDS.CLIENT_HOSTING_REPORT:
                    ClientHostingReportMenuHandler();
                    break;
                case BOADMIN_NEW.Cls.clsEnums.CommandIDS.MARGIN_REPORT:
                    MarginReportMenuHandler();
                    break;
                case BOADMIN_NEW.Cls.clsEnums.CommandIDS.TOP_TRADED_INSTRUMENTS:
                    TopTradedInstReportMenuHandler();
                    break;
                case BOADMIN_NEW.Cls.clsEnums.CommandIDS.NEW_CLIENT_INFO_REPORT:
                    NewClientInfoReportMenuHandler();
                    break;
                case BOADMIN_NEW.Cls.clsEnums.CommandIDS.ACCOUNT_TRANS_REPORT:
                    AccountTransReportMenuHandler();
                    break;
                case BOADMIN_NEW.Cls.clsEnums.CommandIDS.CHANGE_PASSWORD:
                    ChangePasswordMenuHandler();
                    break;
                case BOADMIN_NEW.Cls.clsEnums.CommandIDS.CLOSE_PRICED_MANAGEMENT:
                    ClosgPricedMenuHandler();
                    break;
                case BOADMIN_NEW.Cls.clsEnums.CommandIDS.DAY_CLOSING_REPORT:
                    DayClosingReportMenuHandler();
                    break;
                case BOADMIN_NEW.Cls.clsEnums.CommandIDS.TICK_MANAGER:
                    TickManagerMenuHandler();
                    break;
                case BOADMIN_NEW.Cls.clsEnums.CommandIDS.CLIENT_MARGIN_REPORT:
                    ClientMarginReportMenuHandler();
                    break;
                case BOADMIN_NEW.Cls.clsEnums.CommandIDS.ACCOUNT:
                    AccountsMenuHandler();
                    break;
                case BOADMIN_NEW.Cls.clsEnums.CommandIDS.OPERATIONS_LOG:
                    OperationsLogMenuHandler();
                    break;
                case BOADMIN_NEW.Cls.clsEnums.CommandIDS.EDIT_ACCOUNT_TRANS:
                    EditAccountTransMenuHandler();
                    break;
                case BOADMIN_NEW.Cls.clsEnums.CommandIDS.FORCE_LOGOUT:
                    ForceLogOutMenuHandler();
                    break;

            }
            //Properties.Settings.Default.Save();
        }

        private void ForceLogOutMenuHandler()
        {
            Forms.FrmBase objfrmCommonContainer = new FrmBase();
            Uctl.uctlForceLogOut objuctlForceLogOut = new Uctl.uctlForceLogOut();
            objfrmCommonContainer.Text = "Force Logout";
            objfrmCommonContainer.ClientSize = objuctlForceLogOut.Size;
            objfrmCommonContainer.Controls.Add(objuctlForceLogOut);
            objfrmCommonContainer.MdiParent = this;
            objfrmCommonContainer.Parent = ui_pnlChildFormContainer;
            objuctlForceLogOut.Dock = DockStyle.Fill;
            objfrmCommonContainer.AcceptButton = objuctlForceLogOut.ui_nbtnLogout;
            objfrmCommonContainer.BringToFront();
            objfrmCommonContainer.Show();
        }

        private void EditAccountTransMenuHandler()
        {
            Forms.FrmBase objfrmCommonContainer = new FrmBase();
            Uctl.uctlEditAccountTransactions objuctlAccountTransactions = new BOADMIN_NEW.Uctl.uctlEditAccountTransactions();
            objfrmCommonContainer.Text = "Edit Account Transaction";
            objfrmCommonContainer.ClientSize = objuctlAccountTransactions.Size;
            objfrmCommonContainer.Controls.Add(objuctlAccountTransactions);
            objfrmCommonContainer.MdiParent = this;
            objfrmCommonContainer.Parent = ui_pnlChildFormContainer;
            objuctlAccountTransactions.Dock = DockStyle.Fill;
            objfrmCommonContainer.BringToFront();
            objfrmCommonContainer.Show();
        }

        private void OperationsLogMenuHandler()
        {
            clsBrokerOperationsLog BrokerOperationsLog = new clsBrokerOperationsLog();
            BrokerOperationsLog.BrokerID = clsGlobal.BrokerNameId;
            FrmBase objfrmCommonContainer = new FrmBase();
            Uctl.uctlOperationsLog objuuctlOperationsLog = new Uctl.uctlOperationsLog();
            clsProxyClassManager.INSTANCE._objBOEngineClient.HandleBrokerOperationsLogCompleted -= new EventHandler<HandleBrokerOperationsLogCompletedEventArgs>(_objLoginClient_HandleBrokerOperationsLogCompleted);
            clsProxyClassManager.INSTANCE._objBOEngineClient.HandleBrokerOperationsLogCompleted += new EventHandler<HandleBrokerOperationsLogCompletedEventArgs>(_objLoginClient_HandleBrokerOperationsLogCompleted);
            clsProxyClassManager.INSTANCE._objBOEngineClient.HandleBrokerOperationsLogAsync(clsGlobal.userIDPwd, BrokerOperationsLog, DateTime.Now.Date, Convert.ToDateTime(DateTime.Now.Date.ToString().Replace("12:00:00 AM", "23:59:59 PM")), OperationTypes.GET);
            objfrmCommonContainer.Text = "Audit Log";
            objfrmCommonContainer.ClientSize = objuuctlOperationsLog.Size;
            objfrmCommonContainer.Controls.Add(objuuctlOperationsLog);
            objfrmCommonContainer.MdiParent = this;
            objfrmCommonContainer.Parent = ui_pnlChildFormContainer;
            objuuctlOperationsLog.Dock = DockStyle.Fill;
            objfrmCommonContainer.MinimumSize = objfrmCommonContainer.Size;
            objfrmCommonContainer.BringToFront();

            objfrmCommonContainer.Show();
        }

        void _objLoginClient_HandleBrokerOperationsLogCompleted(object sender, HandleBrokerOperationsLogCompletedEventArgs e)
        {
            clsOperationsLogManager.INSTANCE.FillDataToDataSet(e.Result.ToList());            
        }

        private void AccountsMenuHandler()
        {
            Forms.FrmBase objfrmCommonContainer = new FrmBase();
            Uctl.uctlAccountTransactions objuctlAccountTransactions = new BOADMIN_NEW.Uctl.uctlAccountTransactions();
            objfrmCommonContainer.Text = "Accounts";
            objfrmCommonContainer.ClientSize = objuctlAccountTransactions.Size;
            objfrmCommonContainer.Controls.Add(objuctlAccountTransactions);
            objfrmCommonContainer.MdiParent = this;
            objfrmCommonContainer.Parent = ui_pnlChildFormContainer;
            objuctlAccountTransactions.Dock = DockStyle.Fill;
            objfrmCommonContainer.BringToFront();
            objfrmCommonContainer.Show();
        }

        private void ClientMarginReportMenuHandler()
        {
            //frmMarginReports objfrmMarginReports = new frmMarginReports();
            //objfrmMarginReports.MdiParent = this;
            //objfrmMarginReports.Parent = ui_pnlChildFormContainer;
            //objfrmMarginReports.BringToFront();
            //objfrmMarginReports.Show();
        }

        private void TickManagerMenuHandler()
        {
            Forms.FrmBase objfrmCommonContainer = new FrmBase();
            Uctl.uctlTickManagerMain objuctlTickManagerMain = new BOADMIN_NEW.Uctl.uctlTickManagerMain();
            objfrmCommonContainer.ClientSize = objuctlTickManagerMain.Size;
            objfrmCommonContainer.Controls.Add(objuctlTickManagerMain);
            objfrmCommonContainer.MdiParent = this;
            objfrmCommonContainer.Parent = ui_pnlChildFormContainer;
            objuctlTickManagerMain.Dock = DockStyle.Fill;
            objfrmCommonContainer.BringToFront();
            objfrmCommonContainer.Show();
        }

        private void DayClosingReportMenuHandler()
        {
            Forms.frmDayClosingReport objfrmDayClosingReport = new frmDayClosingReport();
            objfrmDayClosingReport.MdiParent = this;
            objfrmDayClosingReport.Parent = ui_pnlChildFormContainer;
            objfrmDayClosingReport.BringToFront();
            objfrmDayClosingReport.Show();
        }

        private void ClosgPricedMenuHandler()
        {
            FrmMain.Instance.SetProgressBarMessage = "Loading Close Priced Management Details ....";

            bool flag = true;
            if (!_InstClosingPriceLoaded)
            {
                FrmMain.Instance.startProgressBar();
                flag = GetInstClosingPrice();
                _InstClosingPriceLoaded = true;
            }
            if (flag)
            {
                Forms.frmInstrumentClosingPrice objfrmInstrumentClosingPrice = new frmInstrumentClosingPrice();
                objfrmInstrumentClosingPrice.MdiParent = this;
                objfrmInstrumentClosingPrice.Parent = ui_pnlChildFormContainer;
                objfrmInstrumentClosingPrice.BringToFront();
                objfrmInstrumentClosingPrice.Sizable = false;
                objfrmInstrumentClosingPrice.Show();
            }
            else
            {
                clsDialogBox.ShowErrorBox("Not connected to server", "BOAdmin", true);
            }

            FrmMain.Instance.SetProgressBarMessage = "Loading Close Priced Management Details Completed";
        }

        public bool GetInstClosingPrice()
        {
            bool flag = true;
            try
            {
                clsLogManager.INSTANCE._syncQueue.Enqueue("FrmMain : Enter GetInstClosingPrice()");

                clsProxyClassManager.INSTANCE._objBOEngineClient.HandleInstClosingPriceCompleted += new EventHandler<HandleInstClosingPriceCompletedEventArgs>(_objInstClosingPriceClient_HandleInstClosingPriceCompleted);
                clsProxyClassManager.INSTANCE._objBOEngineClient.HandleInstClosingPriceAsync(clsGlobal.userIDPwd, null, OperationTypes.GET);

                clsLogManager.INSTANCE._syncQueue.Enqueue("FrmMain : Exit GetInstClosingPrice()");
            }
            catch (Exception)
            {
            }
            return flag;
        }

        void _objInstClosingPriceClient_HandleInstClosingPriceCompleted(object sender, HandleInstClosingPriceCompletedEventArgs e)
        {
            foreach (clsInstrumentClosingPrice item in e.Result)
            {
                clsSymbolClosingPriceManager.INSTANCE.HandleInstClosingPrice(item);
            }
            
            FrmMain.Instance.stopProgressBar();
        }
        private void ChangePasswordMenuHandler()
        {
            frmChangePassword objfrmChangePassword = new frmChangePassword();
            objfrmChangePassword.MdiParent = this;
            objfrmChangePassword.Parent = ui_pnlChildFormContainer;
            objfrmChangePassword.BringToFront();
            objfrmChangePassword.LoginID = clsGlobal.CLietnID;
            objfrmChangePassword.Show();
        }

        private void AccountTransReportMenuHandler()
        {
            frmAccountTransReport objfrmAccountTransReport = new frmAccountTransReport();
            objfrmAccountTransReport.MdiParent = this;
            objfrmAccountTransReport.Parent = ui_pnlChildFormContainer;
            objfrmAccountTransReport.BringToFront();
            objfrmAccountTransReport.Show();
        }

        private void NewClientInfoReportMenuHandler()
        {
            //frmNewClientInfo objfrmNewClientInfo = new frmNewClientInfo();
            //objfrmNewClientInfo.MdiParent = this;
            //objfrmNewClientInfo.Show();
        }

        private void TopTradedInstReportMenuHandler()
        {
            //frmTopTradedInst objfrmTopTradedInst = new frmTopTradedInst();
            //objfrmTopTradedInst.MdiParent = this;
            //objfrmTopTradedInst.Show();
        }

        private void MarginReportMenuHandler()
        {
            //frmMarginReports objfrmMarginReports = new frmMarginReports();
            //objfrmMarginReports.MdiParent = this;
            //objfrmMarginReports.Show();
        }

        private void ClientHostingReportMenuHandler()
        {
            try
            {
                //frmClientHoldingStock objfrmClientHoldingStock = new frmClientHoldingStock();
                //objfrmClientHoldingStock.MdiParent = this;
                //objfrmClientHoldingStock.Parent = ui_pnlChildFormContainer;
                //objfrmClientHoldingStock.BringToFront();
                //objfrmClientHoldingStock.Show();


                //frmReportTest objfrmClientHoldingStock = new frmReportTest();
                //objfrmClientHoldingStock.MdiParent = this;
                //objfrmClientHoldingStock.Parent = ui_pnlChildFormContainer;
                //objfrmClientHoldingStock.BringToFront();
                //objfrmClientHoldingStock.Show();

                frmClientHoldingStock objfrmClientHoldingStock = new frmClientHoldingStock();
                objfrmClientHoldingStock.MdiParent = this;
                objfrmClientHoldingStock.Parent = ui_pnlChildFormContainer;
                objfrmClientHoldingStock.BringToFront();
                objfrmClientHoldingStock.Show();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void StockLevelReportMenuHandler()
        {
            frmStockLevel objfrmStockLevel = new frmStockLevel();
            objfrmStockLevel.MdiParent = this;
            objfrmStockLevel.Parent = ui_pnlChildFormContainer;
            objfrmStockLevel.BringToFront();
            objfrmStockLevel.Show();
        }

        private void ClientCommissionReportMenuHandler()
        {
            frmClientComm objfrmClientComm = new frmClientComm();
            objfrmClientComm.MdiParent = this;
            objfrmClientComm.Parent = ui_pnlChildFormContainer;
            objfrmClientComm.BringToFront();
            objfrmClientComm.Show();
        }

        private void OrderReportMenuHandler()
        {
            frmOrderReport objfrmOrderReport = new frmOrderReport();
            objfrmOrderReport.MdiParent = this;
            objfrmOrderReport.Parent = ui_pnlChildFormContainer;
            objfrmOrderReport.BringToFront();
            objfrmOrderReport.Show();
        }

        private void TradeReportMenuHandler()
        {
            frmTradeReport objfrmTradeReport = new frmTradeReport();
            objfrmTradeReport.MdiParent = this;
            objfrmTradeReport.Parent = ui_pnlChildFormContainer;
            objfrmTradeReport.BringToFront();
            objfrmTradeReport.Show();
        }

        private void OpenPositionReportMenuHandler()
        {
            frmOpenPositionReport objfrmOpenPositioReport = new frmOpenPositionReport();
            objfrmOpenPositioReport.MdiParent = this;
            objfrmOpenPositioReport.Parent = ui_pnlChildFormContainer;
            objfrmOpenPositioReport.BringToFront();
            objfrmOpenPositioReport.Show();
        }

        private void VirtualDealerMenuHandler()
        {
            FrmMain.Instance.SetProgressBarMessage = "Loading Virtual Dealer Details ....";
            //FrmMain.Instance.startProgressBar();

            bool flag = true;
            if (!_VirtualDealerLoaded)
            {
                flag = GetVirtualDealer();
                _VirtualDealerLoaded = true;
            }
            if (flag)
            {
                frmVirtualDealer objfrmVirtualDealer = frmVirtualDealer.INSTANCE; //new frmVirtualDealer();
                objfrmVirtualDealer.MdiParent = this;
                objfrmVirtualDealer.Parent = ui_pnlChildFormContainer;
                objfrmVirtualDealer.BringToFront();
                objfrmVirtualDealer.Show();
            }
            else
            {
                clsDialogBox.ShowErrorBox("Not connected to server", "BOAdmin", true);
            }

            FrmMain.Instance.SetProgressBarMessage = "Loading Virtual Dealer Details Completed";
            //FrmMain.Instance.stopProgressBar();
        }

        private bool GetVirtualDealer()
        {
            bool flag = true;
            try
            {
                clsLogManager.INSTANCE._syncQueue.Enqueue("FrmMain : Enter GetVirtualDealer()");

                clsVirtualDealerManager.INSTANCE.FillDataToDataSet(clsProxyClassManager.INSTANCE.GetVirtualDealerRecords());

                clsLogManager.INSTANCE._syncQueue.Enqueue("FrmMain : Exit GetVirtualDealer()");
            }
            catch (Exception ex)
            {
                clsLogManager.INSTANCE._syncQueue.Enqueue("Exception :FrmMain => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                 "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in GetVirtualDealer()");
                flag = false;
                MessageBox.Show("FrmMain : GetVirtualDealer =>Error in getting Virtual Dealer data");
            }
            return flag;
        }

        private void CommonSettingsMenuHandler()
        {
            bool flag = true;
            try
            {
                FrmMain.Instance.SetProgressBarMessage = "Loading Common Settings Details ....";
                //FrmMain.Instance.startProgressBar();

                if (!_CommonSettingsLoaded)
                {
                    flag = GetCommonSettings();
                    _CommonSettingsLoaded = true;
                }
                if (flag)
                {
                    frmCommonSetting objfrmCommonSettings = frmCommonSetting.INSTANCE; //new frmCommonSetting();
                    objfrmCommonSettings.MdiParent = this;
                    objfrmCommonSettings.Parent = ui_pnlChildFormContainer;
                    objfrmCommonSettings.Sizable = false;
                    objfrmCommonSettings.BringToFront();
                    objfrmCommonSettings.StartPosition = FormStartPosition.CenterParent;
                    objfrmCommonSettings.Show();
                }
                else
                {
                    clsDialogBox.ShowErrorBox("Not connected to server", "BOAdmin", true);
                }

                FrmMain.Instance.SetProgressBarMessage = "Loading Common Settings Details Completed";
                //FrmMain.Instance.stopProgressBar();
            }
            catch (Exception ex)
            {
                clsLogManager.INSTANCE._syncQueue.Enqueue("Exception :FrmMain =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in CommonSettingsMenuHandler()");
            }
        }

        private bool GetCommonSettings()
        {
            bool flag = true;
            try
            {
                clsLogManager.INSTANCE._syncQueue.Enqueue("FrmMain : Enter GetCommonSettings()");

                clsCommonSettingsManagerNew.INSTANCE.FillDataToDataSet(clsProxyClassManager.INSTANCE.GetCommonSettingsRecords());

                clsLogManager.INSTANCE._syncQueue.Enqueue("FrmMain : Exit GetCommonSettings()");
            }
            catch (Exception ex)
            {
                clsLogManager.INSTANCE._syncQueue.Enqueue("Exception :FrmMain => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                 "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in GetCommonSettings()");
                flag = false;
                MessageBox.Show("FrmMain : GetCommonSettings =>Error in getting Common Settings data");
            }
            return flag;
        }

        private void MapOrdersMenuHandler()
        {
            FrmMain.Instance.SetProgressBarMessage = "Loading Map Order Details ....";
            //FrmMain.Instance.startProgressBar();

            bool flag = true;
            try
            {
                if (!_MapOrdersLoaded)
                {
                    flag = GetMapOrders();
                    _MapOrdersLoaded = true;
                }
                if (flag)
                {
                    frmMapOrders objfrmMapOrders = frmMapOrders.INSTANCE; //new frmMapOrders();
                    objfrmMapOrders.MdiParent = this;
                    objfrmMapOrders.Parent = ui_pnlChildFormContainer;
                    objfrmMapOrders.BringToFront();
                    objfrmMapOrders.Show();
                }
                else
                {
                    clsDialogBox.ShowErrorBox("Not connected to server", "BOAdmin", true);
                }

                FrmMain.Instance.SetProgressBarMessage = "Loading Map Order Details Completed";
                //FrmMain.Instance.stopProgressBar();
            }
            catch (Exception ex)
            {
                clsLogManager.INSTANCE._syncQueue.Enqueue("Exception :FrmMain =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in MapOrdersMenuHandler()");
            }
        }

        private bool GetMapOrders()
        {
            bool flag = true;
            try
            {
                clsLogManager.INSTANCE._syncQueue.Enqueue("FrmMain : Enter GetMapOrders()");

                flag = clsMapOrderManager.INSTANCE.GetMapOrderInfo();

                clsLogManager.INSTANCE._syncQueue.Enqueue("FrmMain : Exit GetMapOrders()");
            }
            catch (Exception ex)
            {
                clsLogManager.INSTANCE._syncQueue.Enqueue("Exception :FrmMain => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                 "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in GetMapOrders()");
                flag = false;
                MessageBox.Show("FrmMain : GetMapOrders =>Error in getting MapOrders data");
            }
            return flag;
        }
        public void SetCommandActive(bool flag)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.BeginInvoke(new EnbleChnage(SetCommandActive), flag);
                    return;
                }
                else
                {
                    if (flag == true)
                    {
                        ui_nmnuFile_Login.Enabled = false;
                        ui_ntbLogin.Enabled = false;
                        ui_nmnuFile_Logoff.Enabled = flag;
                        ui_ntbLogoff.Enabled = flag;
                    }
                    else
                    {
                        ui_nmnuFile_Login.Enabled = true;
                        ui_ntbLogin.Enabled = true;
                        ui_nmnuFile_Logoff.Enabled = flag;
                        ui_ntbLogoff.Enabled = flag;
                    }
                    //ui_nmnuFile_Exit.Enabled = flag;
                    ui_nmnuExchange_ContractSpecification.Enabled = flag;
                    ui_nmnuExchange_Holidays.Enabled = flag;
                    ui_nmnuExchange_IPAccess.Enabled = flag;
                    ui_nmnuExchange_TimeSetting.Enabled = flag;
                    ui_nmnuExchange_TradingGatway.Enabled = flag;
                    ui_nmnuCharges_FeesMaster.Enabled = flag;
                    ui_nmnuCharges_TaxMaster.Enabled = flag;
                    ui_nmnuBroker_Broker.Enabled = flag;
                    ui_nmnuBroker_Clients.Enabled = flag;
                    ui_nmnuBroker_Collateral.Enabled = flag;
                    ui_nmnuTrade_Orders.Enabled = flag;
                    ui_nmnuTrade_Trade.Enabled = flag;
                    ui_ntbBroker.Enabled = flag;
                    ui_ntbClients.Enabled = flag;
                    ui_ntbCollateral.Enabled = flag;
                    ui_ntbContractSpecification.Enabled = flag;
                    ui_ntbFeeMaster.Enabled = flag;
                    ui_ntbHolidays.Enabled = flag;
                    ui_ntbIPAccess.Enabled = flag;
                    ui_ntbOrder.Enabled = flag;
                    ui_ntbTaxMaster.Enabled = flag;
                    ui_ntbTimeSetting.Enabled = flag;
                    ui_ntbTrade.Enabled = flag;
                    ui_ntbTradingGateway.Enabled = flag;
                    ui_nmnuExchange_CommonSettings.Enabled = flag;
                    ui_nmunMapOrders.Enabled = flag;
                    ui_nmnu_ReportsTrade.Enabled = flag;
                    ui_nmnu_ReportsOpenPosition.Enabled = flag;
                    ui_nmnu_ReportsOrder.Enabled = flag;
                    ui_nmnu_ReportsClientCommission.Enabled = flag;
                    ui_nmnuFile_ChangePassword.Enabled = flag;
                    ui_nmnu_ReportsStockLevel.Enabled = flag;
                    ui_nmnu_ReportsClientHoldingStock.Enabled = flag;
                    ui_nmnu_ReportsAccountTrans.Enabled = flag;
                    ui_nmnu_ReportsDayClosing.Enabled = flag;
                    ui_nmnuExchange_ClosingPriceManagement.Enabled = flag;
                    ui_nmnuExchange_OperationsLog.Enabled = flag;
                    if (clsGlobal.BrokerID == 1)
                    {
                        ui_nmnuExchange_ClosingPriceManagement.Properties.Visible = true;
                        ui_nmnuTrade_Trade.Properties.Visible = true;
                        ui_nmnuFile_ForceLogout.Properties.Visible = false;
                    }
                    else
                    {
                        ui_nmnuExchange_ClosingPriceManagement.Properties.Visible = false;
                        ui_nmnuTrade_Trade.Properties.Visible = false;
                        ui_nmnuFile_ForceLogout.Properties.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                clsLogManager.INSTANCE._syncQueue.Enqueue("Exception :FrmMain => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in SetCommandActive()");
            }

        }

    }
}
