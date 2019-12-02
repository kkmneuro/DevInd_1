///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION	
//21/03/2012	VP		    1.Desining and coding of control
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CommonLibrary.Cls;
using System.Data;
using System.Drawing;

namespace CommonLibrary.UserControls
{
    public partial class UctlAccountsToTrade : UserControl
    {
        #region    "      MEMBERS       "

        private Dictionary<int, DataRow> _DDAccountsInfo = new Dictionary<int, DataRow>();
        private string _title = "Accounts Info";

        #endregion "      MEMBERS       "

        #region    "      PROPERTY      "

        /// <summary>
        /// Sets and gets the title of the mail control
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        #endregion "      PROPERTY      "

        #region "         METHODS       "

        public UctlAccountsToTrade()
        {
            InitializeComponent();
            AddcolumnsToGrid();
        }

        private void AddcolumnsToGrid()
        {
            var columns = new DataGridViewColumn[11];
            var dcStyle = new DataGridViewCellStyle();
            dcStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            columns[0] = ClsCommonMethods.CreateGridColumn(columns[0], "clmAccountID", "Account ID");
            columns[1] = ClsCommonMethods.CreateGridColumn(columns[1], "clmTraderName", "Name");
            columns[2] = ClsCommonMethods.CreateGridColumn(columns[2], "clmBalance", "Balance");
            columns[3] = ClsCommonMethods.CreateGridColumn(columns[3], "clmBuySideTurnOver", "Buy TurnOver");
            columns[4] = ClsCommonMethods.CreateGridColumn(columns[4], "clmSellSideTurnOver", "Sell TurnOver");
            columns[5] = ClsCommonMethods.CreateGridColumn(columns[5], "clmHedgeAllowed", "Hedge Allowed", false);
            columns[6] = ClsCommonMethods.CreateGridColumn(columns[6], "clmLeverage", "Leverage");
            columns[7] = ClsCommonMethods.CreateGridColumn(columns[7], "clmMargin", "Margin", false);
            columns[8] = ClsCommonMethods.CreateGridColumn(columns[8], "clmFreeMargin", "Free Margin", false);
            columns[9] = ClsCommonMethods.CreateGridColumn(columns[9], "clmUsedMargin", "Used Margin");
            columns[10] = ClsCommonMethods.CreateGridColumn(columns[10], "clmReservedMargin", "Reserved Margin", false);
            columns[0].DataPropertyName = "AccountId";
            columns[1].DataPropertyName = "TraderName";
            columns[2].DataPropertyName = "Balance";
            columns[3].DataPropertyName = "BuySideTurnOver";
            columns[4].DataPropertyName = "SellSideTurnOver";
            columns[5].DataPropertyName = "HedgeAllowed";
            columns[6].DataPropertyName = "Leverage";
            columns[7].DataPropertyName = "Margin";
            columns[8].DataPropertyName = "FreeMargin";
            columns[9].DataPropertyName = "UsedMargin";
            columns[10].DataPropertyName = "ReservedMargin";

            columns[0].DefaultCellStyle = dcStyle;
            columns[1].DefaultCellStyle = dcStyle;
            columns[2].DefaultCellStyle = dcStyle;
            columns[3].DefaultCellStyle = dcStyle;
            columns[5].DefaultCellStyle = dcStyle;
            columns[6].DefaultCellStyle = dcStyle;
            columns[7].DefaultCellStyle = dcStyle;
            columns[8].DefaultCellStyle = dcStyle;
            columns[9].DefaultCellStyle = dcStyle;
            columns[10].DefaultCellStyle = dcStyle;
            ui_uctlGridAccountsInfo.Columns.AddRange(columns);
        }

        private void ui_nbtnCancel_Click(object sender, EventArgs e)
        {
            ParentForm.Close();
        }

        private void ui_nbtnApply_Click(object sender, EventArgs e)
        {
            if (ui_ncmbDefaultAccount.SelectedItem == null)
            {
                ClsCommonMethods.ShowErrorBox("Account name can't null");
                return;
            }

            OnApplyClick(ui_ncmbDefaultAccount.SelectedItem.ToString());
        }

        private void ui_nlstAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (_DDAccountsInfo.ContainsKey(Convert.ToInt32(ui_ncmbDefaultAccount.SelectedItem.ToString())))
            //{
            //    SetValues(_DDAccountsInfo[Convert.ToInt32(ui_ncmbDefaultAccount.SelectedItem.ToString())]);
            //}
        }

        public void Init(Dictionary<int, DataRow> ddAccounts, string defaultTradingAccount)
        {
            //ui_uctlGridAccountsInfo.Rows.Clear();
            //ui_ncmbDefaultAccount.Items.Clear();
            //_DDAccountsInfo = ddAccounts;
            //foreach (int item in ddAccounts.Keys)
            //{
            //    ui_ncmbDefaultAccount.Items.Add(Convert.ToString(item));
            //    //SetValues(ddAccountInfo[item]);
            //}
            //if (defaultTradingAccount != null && Convert.ToInt32(defaultTradingAccount) != 0)
            //{
            //    ui_ncmbDefaultAccount.SelectedIndex= ui_ncmbDefaultAccount.Items.IndexOf(Convert.ToInt32(defaultTradingAccount));      
            //}
            //else if (_DDAccountsInfo != null && _DDAccountsInfo.Keys.Count > 0)
            //{
            //    ui_ncmbDefaultAccount.SelectedIndex = 0;
            //}
        }

        //public void SetValues(clsAccountsToTradeInfo accontsInfo)
        //{
        //    ui_uctlGridAccountsInfo.Rows.Add(accontsInfo.AccountId, accontsInfo.TraderName ,accontsInfo.Balance, accontsInfo.BuySideTurnover,
        //                                     accontsInfo.SellSideTurnOver,
        //                                     accontsInfo.HedgeAllowed, accontsInfo.Leverage, accontsInfo.Margin,
        //                                     accontsInfo.FreeMargin, accontsInfo.UsedMargin,
        //                                     accontsInfo.ReservedMargin);
        //}

        #endregion "     METHODS      "

        #region "        EVENTS        "

        public event Action<string> OnApplyClick = delegate { };
        public event Action<string> OnAccountsSelected;

        #endregion "        EVENTS        "

        private void ui_ncmbDefaultAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ui_ncmbDefaultAccount.SelectedItem != null)
            {
                OnAccountsSelected(ui_ncmbDefaultAccount.SelectedItem.ToString());
            }
        }

        private void UctlAccountsToTrade_Load(object sender, EventArgs e)
        {
            ui_uctlGridAccountsInfo.BackgroundColor = Color.White;
        }
    }

    public class clsAccountsToTradeInfo
    {
        public string AccountId { get; set; }
        public string Balance { get; set; }
        public string Group{ get; set; }
        public string Margin { get; set; }
        public string BuySideTurnover { get; set; }
        public string SellSideTurnOver { get; set; }
        public string HedgeAllowed { get; set; }
        public string Leverage { get; set; }
        public string FreeMargin { get; set; }
        public string UsedMargin { get; set; }
        public string ReservedMargin { get; set; }
        public string MarginCall1 { get; set; }
        public string MarginCall2 { get; set; }
        public string MarginCall3 { get; set; }
        public string TraderName{ get; set; }
        public string AccountType { get; set; }
    }
}