using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nevron.UI.WinForm.Controls;
using BOADMIN_NEW.Cls;
using System.Diagnostics;

using BOADMIN_NEW.BOEngineServiceTCP;
using ProtocolStructs;
using System.ServiceModel;

namespace BOADMIN_NEW.Forms
{
    public partial class frmDataLogin : Form
    {
        Forms.frmLoadInitialDetails objfrmLoadInitialDetails;
        public frmDataLogin()
        {
            InitializeComponent();
        }

        private void ui_btnLogin_Click(object sender, EventArgs e)
        {
            FrmMain.Instance.SetProgressBarMessage = "Connecting to Server ....";
            ui_btnLogin.Enabled = false;
            LoginHandler();
        }

        private void ui_ntxtLoginId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoginHandler();
            }
        }

        private void ui_ntxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoginHandler();
            }
        }
        private void LoginHandler()
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("frmDataLogin : Enter LoginHandler()");

                if (!clsProxyClassManager.INSTANCE.IsConnectionAvailble())
                {
                    this.Close();
                    return;
                }

                if (ui_ntxtLoginId.Text == string.Empty)
                {
                    if (ui_ntxtPassword.Text == string.Empty)
                    {
                        DialogResult result = clsDialogBox.ShowErrorBox("Please enter Login ID & Password.", "Login Error", true);
                        ui_ntxtLoginId.Focus();
                        return;
                    }
                    else
                    {
                        DialogResult result = clsDialogBox.ShowErrorBox("Please enter Login ID.", "Login Error", true);
                        ui_ntxtLoginId.Focus();
                        return; ;
                    }
                }
                if (ui_ntxtLoginId.Text != string.Empty && ui_ntxtPassword.Text == string.Empty)
                {
                    DialogResult result = clsDialogBox.ShowErrorBox("Please enter Password.", "Login Error", true);
                    ui_ntxtPassword.Focus();
                    return;
                }
                clsLogin objclsLogin = new clsLogin();
                objclsLogin.LoginId = ui_ntxtLoginId.Text.Trim();
                objclsLogin.Password = ui_ntxtPassword.Text.Trim();

                //MessageBox.Show(ui_ntxtLoginId.Text.Trim() + "_" + ui_ntxtLoginId.Text.Trim());
                objclsLogin = clsProxyClassManager.INSTANCE.Login(ui_ntxtLoginId.Text.Trim() + "_" + ui_ntxtLoginId.Text.Trim(), objclsLogin);

                if (objclsLogin.ServerResponseMsg == "Login Unsuccessful" || objclsLogin.IsEnable == false)
                {
                    clsDialogBox.ShowErrorBox("Invalid username and password", "BOAdmin", true);
                    FrmMain.Instance.SetProgressBarMessage = "Invalid Login";
                    return;
                }

                //if (objclsLogin.IsEnable == false)
                //{
                //    clsDialogBox.ShowErrorBox("User disabled by administrator", "BOAdmin", true);
                //    FrmMain.Instance.SetProgressBarMessage = "User disabled by administrator";
                //    return;
                //}
                if (objclsLogin == null)
                    MessageBox.Show("objclsLogin null");
                else
                {
                    clsGlobal.userIDPwd = ui_ntxtLoginId.Text.Trim() + "_" + ui_ntxtLoginId.Text.Trim();
                    ResponceToLogin objResponceToLogin = new ResponceToLogin();
                    objResponceToLogin.LoginID_ = objclsLogin.LoginId;
                    objResponceToLogin.Role_ = objclsLogin.Role;
                    objResponceToLogin.BrokerId_ = objclsLogin.BrokerId;
                    objResponceToLogin.BrokerName_ = objclsLogin.BrokerName;
                    objResponceToLogin.BrokerNameID_ = objclsLogin.BrokerNameID.Value;
                    objResponceToLogin.BrokerCompany_ = objclsLogin.BrokerCompany;
                    objResponceToLogin.IsEnable_ = objclsLogin.IsEnable;
                    ResponceToLoginPS objResponceToLoginPS = new ResponceToLoginPS();
                    objResponceToLoginPS.ResponceToLogin_ = objResponceToLogin;

                    Cls.clsDataManager.INSTANCE.HandleSocketData(objResponceToLoginPS);
                    if (objclsLogin.BrokerId == -5)
                    {
                        this.Close();
                        return;
                    }
                    this.Close();

                    if (objclsLogin.Role != string.Empty && objclsLogin.ServerResponseID != -50060)
                    {
                        splash = new System.Threading.Thread(new System.Threading.ThreadStart(ShowSplash));
                        //splash.IsBackground = true;
                        splash.Start();

                        System.Threading.ThreadPool.QueueUserWorkItem(LoadInitialDetails);
                        //LoadInitialDetails(null);
                    }
                }

                //Logging.FileHandling.WriteAllLog("frmDataLogin : Exit LoginHandler()");
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :frmDataLogin => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                // "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in LoginHandler()");
            }

        }

        public void LoadInitialDetails(object obj)
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("frmDataLogin : Enter LoadInitialDetails()");

                FrmMain.Instance.SetProgressBarMessage = "Loading Initial Details ....";

                clsProxyClassManager.INSTANCE._objBOEngineClient.GetMasterInfoCompleted += new EventHandler<GetMasterInfoCompletedEventArgs>(_objMasterInfoClient_GetMasterInfoCompleted);
                clsProxyClassManager.INSTANCE._objBOEngineClient.GetMasterInfoAsync(clsGlobal.userIDPwd);
                clsSecurityManager.INSTANCE.FillDataToDataSet();
                if (!clsGlobal.IsCSLoaded)
                {
                    clsProxyClassManager.INSTANCE._objBOEngineClient.HandleContractSpecficationCompleted += new EventHandler<HandleContractSpecficationCompletedEventArgs>(_objCS_HandleContractSpecficationCompleted);
                    clsProxyClassManager.INSTANCE._objBOEngineClient.HandleContractSpecficationAsync(clsGlobal.userIDPwd, OperationTypes.GET, null);
                    clsGlobal.IsCSLoaded = true;
                }
                clsProxyClassManager.INSTANCE._objBOEngineClient.GetAccountGroupCompleted += new EventHandler<GetAccountGroupCompletedEventArgs>(_objMasterInfoClient_GetAccountGroupCompleted);
                clsProxyClassManager.INSTANCE._objBOEngineClient.GetAccountGroupAsync(clsGlobal.userIDPwd);
                clsCurrencyManager.INSTANCE.FillDataToDataSet();
                //clsSecurityManager.INSTANCE.FillDataToDataSet();
                clsBrokerManager.INSTANCE.FillDataToDataSet();
                clsLeverageManager.INSTANCE.FillDataToDataSet();
                clsParticipantTypeManager.INSTANCE.FillDataToDataSet();


                clsProxyClassManager.INSTANCE._objBOEngineClient.GetCollateralTypesCompleted += new EventHandler<GetCollateralTypesCompletedEventArgs>(_objCollateralTypesClient_GetCollateralTypesCompleted);
                clsProxyClassManager.INSTANCE._objBOEngineClient.GetCollateralTypesAsync(clsGlobal.userIDPwd);

                clsProxyClassManager.INSTANCE._objBOEngineClient.GetCountryDetailsCompleted += new EventHandler<GetCountryDetailsCompletedEventArgs>(_objMasterInfoClient_GetCountryDetailsCompleted);
                clsProxyClassManager.INSTANCE._objBOEngineClient.GetCountryDetailsAsync(clsGlobal.userIDPwd);
                //   OrderServerManager.clsOrderServerManager.INSTANCE.Init(clsGlobal.OrderServerUser, clsGlobal.OrderServerPassword, clsGlobal.OrderServerURL);
                FrmMain.Instance.LoadClients();
                //Logging.FileHandling.WriteAllLog("frmDataLogin : Exit LoadInitialDetails()");
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :frmDataLogin => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                //  "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in LoadInitialDetails()");
            }
            //clsAccountManager.INSTANCE.FillDataToAccountGroupDataSet(clsProxyClassManager.INSTANCE.GetAccountGroupRecords());
        }
        void _objCS_HandleContractSpecficationCompleted(object sender, HandleContractSpecficationCompletedEventArgs e)
        {
            foreach (clsContractSpecification item in e.Result)
            {
                clsSymbolManager.INSTANCE.DoHandleSymbolTable(item);
            }
            
            FrmMain.Instance.SetProgressBarMessage = "Initial Details Loaded";
            FrmMain.Instance.stopProgressBar();
        }

        void _objMasterInfoClient_GetCountryDetailsCompleted(object sender, GetCountryDetailsCompletedEventArgs e)
        {
            foreach (clsCountryDetail country in e.Result)
            {
                try
                {
                    clsAccountManager.INSTANCE.DoHandleCountryTable(country);
                }
                catch (Exception)
                {

                }
            }
            splash.Abort();
            FrmMain.Instance.stopProgressBar();
        }

        void _objCollateralTypesClient_GetCollateralTypesCompleted(object sender, GetCollateralTypesCompletedEventArgs e)
        {
            foreach (clsCollateralTypes collateral in e.Result)
            {
                clsCollateralManager.INSTANCE.DoHandleCollateralTypesTable(collateral);
            }
            
        }

        void _objMasterInfoClient_GetMasterInfoCompleted(object sender, GetMasterInfoCompletedEventArgs e)
        {
            try
            {
                clsMasterInfoManager.INSTANCE.HandleMasterInfo(e.Result);
            }
            catch (Exception)
            {

            }

        }
        System.Threading.Thread splash;
        void _objMasterInfoClient_GetAccountGroupCompleted(object sender, GetAccountGroupCompletedEventArgs e)
        {
            //splash = new System.Threading.Thread(new System.Threading.ThreadStart(ShowSplash));
            ////splash.IsBackground = true; 
            //splash.Start();
            FrmMain.Instance.startProgressBar();
            clsAccountManager.INSTANCE.FillDataToAccountGroupDataSet(e.Result.ToList());
        }

        public void ShowSplash()
        {
            try
            {
                objfrmLoadInitialDetails = new frmLoadInitialDetails();
                objfrmLoadInitialDetails.TopMost = true;
                objfrmLoadInitialDetails.BringToFront();
                objfrmLoadInitialDetails.StartPosition = FormStartPosition.CenterScreen;
                //objfrmLoadInitialDetails.ShowDialog();
                objfrmLoadInitialDetails.Show();
            }
            catch (Exception)
            {

            }
        }
        private void frmDataLogin_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.favicon;
            FrmMain.Instance.OpenAllChannels();
        }

        private void ui_ntxtLoginId_TextChanged(object sender, EventArgs e)
        {
            ui_btnLogin.Enabled = true;
        }

        private void ui_ntxtPassword_TextChanged(object sender, EventArgs e)
        {
            ui_btnLogin.Enabled = true;
        }

        private void frmDataLogin_Activated(object sender, EventArgs e)
        {
            ui_ntxtLoginId.Focus();
        }
    }
}
