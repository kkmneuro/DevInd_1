using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BOADMIN_NEW.Cls;
using BOADMIN_NEW.BOEngineServiceTCP;

namespace BOADMIN_NEW.Uctl
{
    public partial class uctlTradeNew : uctlGeneric, Interfaces.IUserCtrl
    {
        DateTime startDate = DateTime.Now;
        List<int> lstAccounts = new List<int>();
        public uctlTradeNew(DateTime _startDate)
        {
            InitializeComponent();
            startDate = _startDate;
        }

        #region IUserCtrl Members

        public void Init()
        {

        }

        public void InitControls()
        {

        }

        public void SaveMe()
        {

        }

        #endregion

        private void ui_nbtnCancel_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void ui_nbtnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(ui_ncmbAccountID.Text))
                {
                    clsDialogBox.ShowErrorBox("Please select Account Id.", "Input Error", true);
                    ui_ncmbAccountID.Focus();
                    return;
                }
                else if (string.IsNullOrEmpty(ui_ncmbProductType.Text))
                {
                    clsDialogBox.ShowErrorBox("Please select Product Type.", "Input Error", true);
                    ui_ncmbProductType.Focus();
                    return;
                }
                else if (string.IsNullOrEmpty(ui_ncmProduct.Text))
                {
                    clsDialogBox.ShowErrorBox("Please select Product.", "Input Error", true);
                    ui_ncmProduct.Focus();
                    return;
                }
                else if (string.IsNullOrEmpty(ui_ncmbContractName.Text))
                {
                    clsDialogBox.ShowErrorBox("Please select Symbol Contract.", "Input Error", true);
                    ui_ncmbContractName.Focus();
                    return;
                }
                else if (string.IsNullOrEmpty(ui_ncmbOrderType.Text))
                {
                    clsDialogBox.ShowErrorBox("Please select Order Type.", "Input Error", true);
                    ui_ncmbOrderType.Focus();
                    return;
                }
                else if (string.IsNullOrEmpty(ui_ncmbSide.Text))
                {
                    clsDialogBox.ShowErrorBox("Please select Side.", "Input Error", true);
                    ui_ncmbSide.Focus();
                    return;
                }
                else if (string.IsNullOrEmpty(ui_ncmbValidity.Text))
                {
                    clsDialogBox.ShowErrorBox("Please select Validity.", "Input Error", true);
                    ui_ncmbValidity.Focus();
                    return;
                }
                else if (ui_ndtpExpiry.Value.Date < DateTime.Now.Date)
                {
                    clsDialogBox.ShowErrorBox("Expiry Date should be greater than current date.", "Input Error", true);
                    ui_ndtpExpiry.Focus();
                    return;
                }
                else
                {
                    long price = 0;
                    long.TryParse(ui_ntxtPrice.Text, out price);
                    if (price <= 0)
                    {
                        clsDialogBox.ShowErrorBox("Invalid Price, Price should be greater than 0.", "Input Error", true);
                        ui_ntxtPrice.Focus();
                        return;
                    }
                    else
                    {
                        int AccountId = 0;
                        int.TryParse(ui_ncmbAccountID.Text, out AccountId);

                        clsNewOrder objNewTrade = new clsNewOrder();
                        objNewTrade.AccountID = AccountId;
                        objNewTrade.ExpireDate = ui_ndtpExpiry.Value;
                        objNewTrade.IPAddress = clsGlobal.GetIPAddress();
                        objNewTrade.OrderID = 0;
                        objNewTrade.OrderStatus = '3';
                        objNewTrade.OrderType = '1';
                        objNewTrade.PositionSize = (long)ui_nNUpDown.Value;
                        objNewTrade.Symbol = ui_ncmbContractName.Text;
                        if (clsSymbolManager.INSTANCE.ddSymbolContractSize.ContainsKey(objNewTrade.Symbol))
                        {
                            objNewTrade.PositionSize= (long)(clsSymbolManager.INSTANCE.ddSymbolContractSize[objNewTrade.Symbol]* objNewTrade.PositionSize);
                        }
                        objNewTrade.Price = price;
                        if (ui_ncmbSide.Text.ToUpper().Contains("BUY"))
                        {
                            objNewTrade.Side = '1';
                        }
                        else
                        {
                            objNewTrade.Side = '2';
                        }

                        
                        objNewTrade.TIF = '1';

                        objNewTrade = clsProxyClassManager.INSTANCE.NewTrade(objNewTrade);
                        if (objNewTrade.OrderID > 0)
                        {
                            clsTradeManager.INSTANCE.FillTradeDataSet(startDate.Date, Convert.ToDateTime(DateTime.Now.Date.ToString().Replace("12:00:00 AM", "23:59:59 PM")));
                        }
                        else
                        {
                            clsDialogBox.ShowErrorBox("Unable to place new order", "BOAdmin", true);
                        }

                        this.ParentForm.Close();
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void uctlTradeNew_Load(object sender, EventArgs e)
        {
            try
            {
                Action A = () =>
                {
                    Label.CheckForIllegalCrossThreadCalls = false;
                    ui_ncmbProductType.Items.Clear();
                    ui_ncmbProductType.Items.AddRange(clsSymbolManager.INSTANCE.ddProductTypeProuctContract.Keys.ToArray());
                    if (ui_ncmbProductType.Items.Count > 0)
                    {
                        ui_ncmbProductType.SelectedIndex = 0;
                    }
                    lstAccounts.AddRange(clsAccountManager.INSTANCE.DicAccountIdName.Keys.ToList());
                    //foreach (var item in clsAccountManager.INSTANCE.DicAccountIdName.Keys.ToArray())
                    //{                        
                    //    //int _ac = 0;
                    //    //int.TryParse(item, out _ac);
                    //    //if (_ac > 0 && !lstAccounts.Contains(_ac))
                    //    //{
                    //    //    lstAccounts.Add(_ac);
                    //    //}
                    //}
                    lstAccounts.Sort();
                    foreach (var item in lstAccounts)
                    {
                        ui_ncmbAccountID.Items.Add(item.ToString());
                    }

                    if (ui_ncmbAccountID.Items.Count > 0)
                    {
                        ui_ncmbAccountID.SelectedIndex = 0;
                    }

                    ui_ncmbSide.Items.Add("BUY");
                    ui_ncmbSide.Items.Add("SELL");
                    ui_ncmbOrderType.Items.Add("MARKET");
                    ui_ncmbOrderType.SelectedIndex = 0;
                    ui_ncmbOrderType.Enabled = false;
                    ui_ncmbSide.SelectedIndex = 0;
                    ui_ncmbValidity.Items.Add("DAY");
                    ui_ncmbValidity.SelectedIndex = 0;
                    ui_ncmbValidity.Enabled = false;
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
            catch (Exception)
            {

            }
        }

        private void ui_ncmbProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Action A = () =>
                {
                    ui_ncmProduct.Items.Clear();
                    ui_ncmbContractName.Items.Clear();
                    if (clsSymbolManager.INSTANCE.ddProductTypeProuctContract.ContainsKey(ui_ncmbProductType.Text))
                    {
                        ui_ncmProduct.Items.Clear();
                        ui_ncmProduct.Items.AddRange(clsSymbolManager.INSTANCE.ddProductTypeProuctContract[ui_ncmbProductType.Text].Keys.ToArray());
                        if (ui_ncmProduct.Items.Count > 0)
                        {
                            ui_ncmProduct.SelectedIndex = 0;
                        }

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
            catch (Exception)
            {

            }

        }

        private void ui_ncmProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Action A = () =>
                {

                    ui_ncmbContractName.Items.Clear();
                    if (clsSymbolManager.INSTANCE.ddProductTypeProuctContract.ContainsKey(ui_ncmbProductType.Text)
                    && clsSymbolManager.INSTANCE.ddProductTypeProuctContract[ui_ncmbProductType.Text].ContainsKey(ui_ncmProduct.Text))
                    {
                        ui_ncmbContractName.Items.Clear();
                        ui_ncmbContractName.Items.AddRange(clsSymbolManager.INSTANCE.ddProductTypeProuctContract[ui_ncmbProductType.Text][ui_ncmProduct.Text].ToArray());
                        if (ui_ncmbContractName.Items.Count > 0)
                        {
                            ui_ncmbContractName.SelectedIndex = 0;
                        }
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
            catch (Exception)
            {

            }
        }

        private void ui_ncmbAccountID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Action A = () =>
                {
                    int Account = 0;
                    int.TryParse(ui_ncmbAccountID.Text, out Account);
                    if (clsAccountManager.INSTANCE.DicAccountIdName.ContainsKey(Account))
                    {
                        lblAccountName.Text = "Account: " + clsAccountManager.INSTANCE.DicAccountIdName[Account];
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
            catch (Exception)
            {

            }
        }

        private void ui_ntxtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == '.')
            //{
            //    if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            //    {
            //        e.Handled = true;
            //    }
            //    if (!char.IsControl(e.KeyChar))
            //    {
            //        TextBox tt = (TextBox)sender;
            //        if (tt.Text.IndexOf('.') > -1 && tt.Text.Substring(tt.Text.IndexOf('.')).Length >= 6)
            //        {
            //            e.Handled = true;
            //        }
            //    }
            //}
            //else
            //    e.Handled = true;
        }
    }
}
