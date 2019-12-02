using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProtocolStructs;
using BOADMIN_NEW.Cls;

using BOADMIN_NEW.BOEngineServiceTCP;

namespace BOADMIN_NEW.Uctl
{
    public partial class uctlDelete : uctlGeneric, Interfaces.IUserCtrl
    {
        public Cls.IclsManager _MGR = null;
        public DBDelete _DBDelete = new DBDelete();
        public uctlDelete()
        {
            InitializeComponent();
        }

        private int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        private void uctlDelete_Load(object sender, EventArgs e)
        {
            //65 -90
            //97 - 122
            lblAuto.Text = string.Empty;
            Random ran = new Random();
            lblAuto.Text += Convert.ToChar(ran.Next(65, 90));
            lblAuto.Text += Convert.ToChar(ran.Next(97, 122));
            lblAuto.Text += Convert.ToChar(ran.Next(65, 90));
            lblAuto.Text += Convert.ToChar(ran.Next(97, 122));
            lblAuto.Text += Convert.ToChar(ran.Next(65, 90));
            ui_txtAuto.Focus();

        }



        private void ui_btnOK_Click(object sender, EventArgs e)
        {
            HandleDelete();
        }

        #region IUserCtrl Members

        public void Init()
        {
            throw new NotImplementedException();
        }

        public void InitControls()
        {
            throw new NotImplementedException();
        }

        public void SaveMe()
        {
            throw new NotImplementedException();
        }

        #endregion

        private void ui_btnCancel_Click(object sender, EventArgs e)
        {
            _frmCommonContainer.Close();
        }

        private void ui_txtAuto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                HandleDelete();
        }
        private void HandleDelete()
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("uctlDelete : Enter HandleDelete()");
                if (lblAuto.Text == ui_txtAuto.Text)
                {
                    HandleDeleteDB(new DBDeletePS
                    {
                        _DBDelete = _DBDelete
                    });
                    this.ParentForm.Close();
                }
                else
                {
                    DialogResult result = clsDialogBox.ShowErrorBox("The text you entered did not match the text shown,Please retype the letters", "Validation Error", true);
                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :uctlDelete =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in HandleDelete()");
            }
        }

        private void HandleDeleteDB(DBDeletePS dBDeletePS)
        {
            DBDeletePS objDBDeletePS = new DBDeletePS();
            objDBDeletePS._DBDelete._DeleteKey = dBDeletePS._DBDelete._DeleteKey;

            try
            {
                //Logging.FileHandling.WriteAllLog("uctlDelete : Enter HandleDeleteDB()");
                DBDelete DEL = dBDeletePS._DBDelete;
                string controlName=string.Empty;
                switch (DEL._DeleteID)
                {
                    case ProtocolStructIDS.DataServer_ID:
                        {

                        }
                        break;
                    case ProtocolStructIDS.AccessIp_ID:
                        {
                            controlName = "IP AccessList";
                            int returnValue = clsProxyClassManager.INSTANCE.DeleteIPAccessList(Convert.ToInt32(DEL._DeleteKey));
                            if (returnValue != clsGlobal.FailureID)
                            {
                                objDBDeletePS._DBDelete._DeleteID = ProtocolStructIDS.AccessIp_ID;
                            }
                        }
                        break;
                    case ProtocolStructIDS.Holiday_ID:
                        {
                            controlName = "Holiday";
                            int returnValue = clsProxyClassManager.INSTANCE.DeleteHoliday(Convert.ToInt32(DEL._DeleteKey));
                            if (returnValue != clsGlobal.FailureID)
                            {
                                objDBDeletePS._DBDelete._DeleteID = ProtocolStructIDS.Holiday_ID;
                            }
                        }
                        break;
                    case ProtocolStructIDS.Synchronization_ID:
                        break;
                    case ProtocolStructIDS.LiveUpdate_ID:
                        break;
                    case ProtocolStructIDS.DataFeeds_ID:
                        break;
                    case ProtocolStructIDS.ManagerRights_ID:
                        break;
                    case ProtocolStructIDS.Client_ID:
                        break;
                    case ProtocolStructIDS.Bank_ID:
                        break;
                    case ProtocolStructIDS.Country_ID:
                        break;
                    case ProtocolStructIDS.Account_ID:
                        break;
                    case ProtocolStructIDS.ParticipantOrder_ID:
                        break;
                    case ProtocolStructIDS.Symbol_ID:
                        {
                            controlName = "Contract Specification";
                            int returnValue = clsProxyClassManager.INSTANCE.DeleteCsInfo(Convert.ToInt32(DEL._DeleteKey)); //FrmMain.Instance._objContractSpec.DeleteContractSpecification(clsGlobal.userID, Convert.ToInt32(DEL._DeleteKey));
                            if (returnValue != clsGlobal.FailureID)
                            {
                                objDBDeletePS._DBDelete._DeleteID = ProtocolStructIDS.Symbol_ID;
                            }
                        }
                        break;
                    case ProtocolStructIDS.ManagerRole_ID:
                        break;
                    case ProtocolStructIDS.Group_ID:
                        break;
                    case ProtocolStructIDS.FeeMaster_ID:
                        {
                            controlName = "Fee Master";
                            int returnValue = clsProxyClassManager.INSTANCE.DeleteFeeMaster(Convert.ToInt32(DEL._DeleteKey));
                            if (returnValue != clsGlobal.FailureID)
                            {
                                objDBDeletePS._DBDelete._DeleteID = ProtocolStructIDS.FeeMaster_ID;
                            }
                        }
                        break;
                    case ProtocolStructIDS.TaxMasterID:
                        {
                            controlName = "Tax Master";
                            int returnValue = clsProxyClassManager.INSTANCE.DeleteTaxMaster(Convert.ToInt32(DEL._DeleteKey));
                            if (returnValue != clsGlobal.FailureID)
                            {
                                objDBDeletePS._DBDelete._DeleteID = ProtocolStructIDS.TaxMasterID;
                            }
                        }
                        break;
                    case ProtocolStructIDS.BrokersGroup_ID:
                        break;
                    case ProtocolStructIDS.Order_ID:
                        break;
                    case ProtocolStructIDS.VirtualDealer_ID:
                        {
                            controlName = "Virtual Dealer";
                            int returnValue = clsProxyClassManager.INSTANCE.DeleteVirtualDealer(Convert.ToInt32(DEL._DeleteKey));
                            if (returnValue != clsGlobal.FailureID)
                            {
                                clsVirtualDealerManager.INSTANCE.RemoveSetting(Convert.ToInt32(DEL._DeleteKey));
                            }
                        }
                        break;
                    default:
                        break;
                }
                clsBrokerOperationsLog objclsBrokerOpLog = new clsBrokerOperationsLog();
                objclsBrokerOpLog.OperationName = "Delete";
                //objclsBrokerOpLog.ControlName = controlName;
                objclsBrokerOpLog.Message = "Deleted from " + controlName + " ,record ID :" + DEL._DeleteKey;
                clsProxyClassManager.INSTANCE.HandleOperationsLog(OperationTypes.INSERT, objclsBrokerOpLog);

                clsDataManager.INSTANCE.HandleSocketData(objDBDeletePS);

            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :uctlDelete =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in HandleDeleteDB()");
            }
        }
    }
}
