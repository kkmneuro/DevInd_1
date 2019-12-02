using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CommonLibrary.UserControls;
//using Logging;
using PALSA.Cls;
using System.Data;

namespace PALSA.Frm
{
    public partial class frmAccountsToTrade : frmBase
    {
        private readonly Dictionary<int, clsAccountsToTradeInfo> _DDAccountsInfo =
            new Dictionary<int, clsAccountsToTradeInfo>();

        public frmAccountsToTrade()
        {
            //FileHandling.WriteDevelopmentLog("AccountsToTrade : Enter into frmAccountsToTrade Contructor");

            InitializeComponent();

            //FileHandling.WriteDevelopmentLog("AccountsToTrade : Exit from frmAccountsToTrade Contructor");
        }

        private void frmAccountsToTrade_Load(object sender, EventArgs e)
        {
            //FileHandling.WriteDevelopmentLog("AccountsToTrade : Enter into frmAccountsToTrade_Load Method");
            MinimumSize = Size;
            MaximumSize = Size;
            Text = uctlAccountsToTrade1.Title;
            uctlAccountsToTrade1.ui_uctlGridAccountsInfo.DataSource = clsTWSOrderManagerJSON.INSTANCE.accountInfoDS.dtAccountInfo;
            uctlAccountsToTrade1.Init(clsTWSOrderManagerJSON.INSTANCE._DDAccounts, Properties.Settings.Default.DefaultTradingAccount);
            string defaultAcc= Properties.Settings.Default.DefaultTradingAccount;
            //uctlAccountsToTrade1.ui_ncmbDefaultAccount.Items.Clear();
            //_DDAccountsInfo = ddAccounts;
            //foreach (int item in clsTWSOrderManagerJSON.INSTANCE._DDAccounts.Keys)
            //{
            //    uctlAccountsToTrade1.ui_ncmbDefaultAccount.Items.Add(Convert.ToString(item));
            //}
            //if (!string.IsNullOrEmpty(defaultAcc) && Convert.ToInt32(defaultAcc) != 0)
            //{// uctlAccountsToTrade1.ui_ncmbDefaultAccount.Items.IndexOf(Convert.ToInt32(defaultAcc));
            //    uctlAccountsToTrade1.ui_ncmbDefaultAccount.SelectedIndex = 0;
            //}
            //else if (clsTWSOrderManagerJSON.INSTANCE._DDAccounts != null && clsTWSOrderManagerJSON.INSTANCE._DDAccounts.Keys.Count > 0)
            //{
            //    uctlAccountsToTrade1.ui_ncmbDefaultAccount.SelectedIndex = 0;
            //}
            //TopMost = true;
            
            //Dictionary<string, AccountInfo> DDAccounts = clsTWSOrderManagerJSON.INSTANCE.GetParticipantsList();

            //if (DDAccounts != null)
            //{
            //    foreach (string accId in DDAccounts.Keys)
            //    {
            //        var objclsAccountsToTradeInfo = new clsAccountsToTradeInfo();
            //        objclsAccountsToTradeInfo.AccountId = accId;
            //        objclsAccountsToTradeInfo.Balance = DDAccounts[accId].Balance.ToString();
            //        objclsAccountsToTradeInfo.Group = DDAccounts[accId].Group.ToString();
            //        objclsAccountsToTradeInfo.TraderName = DDAccounts[accId].TraderName.ToString();
            //        objclsAccountsToTradeInfo.BuySideTurnover = DDAccounts[accId].BuySideTurnOver.ToString();
            //        objclsAccountsToTradeInfo.SellSideTurnOver = DDAccounts[accId].SellSideturnOver.ToString();
            //        objclsAccountsToTradeInfo.HedgeAllowed = DDAccounts[accId].HedgeAllowed.ToString();
            //        objclsAccountsToTradeInfo.Leverage = DDAccounts[accId].Leverage.ToString();
            //        objclsAccountsToTradeInfo.FreeMargin = DDAccounts[accId].FreeMargin.ToString();
            //        objclsAccountsToTradeInfo.Margin = DDAccounts[accId].Margin.ToString();
            //        objclsAccountsToTradeInfo.MarginCall1 = DDAccounts[accId].MarginCall1.ToString();
            //        objclsAccountsToTradeInfo.MarginCall2 = DDAccounts[accId].MarginCall2.ToString();
            //        objclsAccountsToTradeInfo.MarginCall3 = DDAccounts[accId].MarginCall3.ToString();
            //        objclsAccountsToTradeInfo.UsedMargin = DDAccounts[accId].UsedMargin.ToString();
            //        objclsAccountsToTradeInfo.ReservedMargin = DDAccounts[accId].ReservedMargin.ToString();
            //        _DDAccountsInfo.Add((int) DDAccounts[accId].Account, objclsAccountsToTradeInfo);
            //    }
            //    uctlAccountsToTrade1.Init(_DDAccountsInfo, Properties.Settings.Default.DefaultTradingAccount);
            //}
            //clsTWSOrderManagerJSON.INSTANCE.OnAccountResponse += new Action<List<AccountInfo>>(INSTANCE_OnAccountResponse);

            //clsTWSOrderManagerJSON.INSTANCE.OnParticipantResponse += participants_OnParticipantResponse;
            //FileHandling.WriteDevelopmentLog("AccountsToTrade : Exit from frmAccountsToTrade_Load Method");
        }

        void INSTANCE_OnAccountResponse(List<AccountInfo> obj)
        {
           
        }

        private void participants_OnParticipantResponse(Dictionary<int, DataRow> DDAccounts)
        {
            Action A = () =>
                           {
                               if (DDAccounts != null)
                               {
                                   clsTWSOrderManagerJSON.INSTANCE.accountInfoDS.dtAccountInfo.AcceptChanges();
                                   uctlAccountsToTrade1.ui_uctlGridAccountsInfo.DataSource = clsTWSOrderManagerJSON.INSTANCE.accountInfoDS.dtAccountInfo;
                                   //foreach (string accId in obj.Keys)
                                   //{
                                   //    var objclsAccountsToTradeInfo = new clsAccountsToTradeInfo();
                                   //    objclsAccountsToTradeInfo.AccountId = accId;
                                   //    objclsAccountsToTradeInfo.Balance = obj[accId].Balance.ToString();
                                   //    objclsAccountsToTradeInfo.Group = obj[accId].Group.ToString();
                                   //    objclsAccountsToTradeInfo.TraderName = obj[accId].TraderName.ToString();
                                   //    objclsAccountsToTradeInfo.BuySideTurnover = obj[accId].BuySideTurnOver.ToString();
                                   //    objclsAccountsToTradeInfo.SellSideTurnOver =obj[accId].SellSideturnOver.ToString();
                                   //    objclsAccountsToTradeInfo.HedgeAllowed = obj[accId].HedgeAllowed.ToString();
                                   //    objclsAccountsToTradeInfo.Leverage = obj[accId].Leverage.ToString();
                                   //    objclsAccountsToTradeInfo.FreeMargin = obj[accId].FreeMargin.ToString();
                                   //    objclsAccountsToTradeInfo.Margin = obj[accId].Margin.ToString();
                                   //    objclsAccountsToTradeInfo.MarginCall1 = obj[accId].MarginCall1.ToString();
                                   //    objclsAccountsToTradeInfo.MarginCall2 = obj[accId].MarginCall2.ToString();
                                   //    objclsAccountsToTradeInfo.MarginCall3 = obj[accId].MarginCall3.ToString();
                                   //    objclsAccountsToTradeInfo.UsedMargin = obj[accId].UsedMargin.ToString();
                                   //    objclsAccountsToTradeInfo.ReservedMargin = obj[accId].ReservedMargin.ToString();
                                   //    if (!_DDAccountsInfo.Keys.Contains(Convert.ToInt32(accId)))
                                   //    {
                                   //        _DDAccountsInfo.Add((int) obj[accId].Account, objclsAccountsToTradeInfo);
                                   //    }
                                   //    else
                                   //    {
                                   //        _DDAccountsInfo[(int) obj[accId].Account] = objclsAccountsToTradeInfo;
                                   //    }
                                   //}

                               }
                           };

            if (InvokeRequired)
            {
                BeginInvoke(A);
            }
            else
            {
                A();
            }
        }

        private void frmAccountsToTrade_FormClosing(object sender, FormClosingEventArgs e)
        {
            clsTWSOrderManagerJSON.INSTANCE.OnParticipantResponse -= participants_OnParticipantResponse;
        }

        private void uctlAccountsToTrade1_OnAccountsSelected(string accountNo)
        {
        }

        private void uctlAccountsToTrade1_OnApplyClick(string accountNo)
        {
            //FileHandling.WriteDevelopmentLog("AccountsToTrade : Enter into uctlAccountsToTrade1_OnApplyClick Method");

            Properties.Settings.Default.DefaultTradingAccount = accountNo;
            Properties.Settings.Default.Save();
            //FileHandling.WriteDevelopmentLog("AccountsToTrade : Exit from uctlAccountsToTrade1_OnApplyClick Method");
            Close();
        }

        private void frmAccountsToTrade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}