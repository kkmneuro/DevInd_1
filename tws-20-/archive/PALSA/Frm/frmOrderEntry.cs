///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION	
//04/02/2012	VP		    1.Desgining of the form
//06/02/2012	VP		    1.Added code for persistency of form
//                          2.Create property FormText and Make FormKey settable
//10/02/2012	VP		    1.Linking of Order prefences tab values to orderEntry form
//13/02/2012	VP		    1.code displaying orderentry with selected data in MarketWatch grid      
//17/02/2012	VP		    1.Code forData display for the order like Price ,Work on settings & getting information from contractmangaer class    
//23/02/2012	VP		    1.code to display values of selected row in market watch in orderEntry              
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CommonLibrary.Cls;
using CommonLibrary.UserControls;
using TWS.Cls;
using ClsGlobal = CommonLibrary.Cls.ClsGlobal;
using Nevron.UI.WinForm.Controls;
using System.Data;

namespace TWS.Frm
{
    public partial class frmOrderEntry : frmBase
    {
        #region "       VARIABLES        "

        private static frmOrderEntry _instance;
        private static int count;
        private string _formkey;
        private bool _isMarketWatchOrderEntry;
        Color StatusClr;
        double StopLevel = 5;
        private string _orderType = string.Empty;
        InstrumentSpec spec = null;
        public ClsNewOrder objclsOldOrder = new ClsNewOrder();

        #endregion "       VARIABLES        "

        #region "          PROPERTIES            "

        public static frmOrderEntry INSTANCE
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new frmOrderEntry();
                }
                return _instance;
            }
            set { _instance = value; }
        }

        public string ConfirmationMessage { get; set; }

        public string FormText
        {
            set { Text = value; }
        }

        public override string Formkey
        {
            get { return _formkey; }
            set { _formkey = value; }
        }

        public override string Title
        {
            get { return Text; }
            set { Text = value; }
        }

        #endregion "          PROPERTIES            "

        #region "          CONSTRUCTORS          "
        List<string> accounts = new List<string>();
        public frmOrderEntry()
        {
            InitializeComponent();

            //  uctlOrderEntry1.AddInstruments(ClsTWSContractManager.INSTANCE.GetProductTypes());

            foreach (int item in clsTWSOrderManagerJSON.INSTANCE.GetParticipantsList().Keys)
            {
                accounts.Add(Convert.ToString(item));
            }
            uctlOrderEntry1.AddAccountNos(accounts.ToArray());
        }

        public frmOrderEntry(DataGridViewRow selectedRow, ClsGlobal.OrderMode mode)
        {
            _isMarketWatchOrderEntry = true;
            InitializeComponent();
            //   uctlOrderEntry1.AddInstruments(ClsTWSContractManager.INSTANCE.GetProductTypes());
            foreach (int item in clsTWSOrderManagerJSON.INSTANCE.GetParticipantsList().Keys)
            {
                accounts.Add(Convert.ToString(item));
            }
            uctlOrderEntry1.AddAccountNos(accounts.ToArray());

            if (mode == ClsGlobal.OrderMode.NEW)
                FillValues(selectedRow);
            else if (mode == ClsGlobal.OrderMode.MODIFY)
                FillValuesToModify(selectedRow);
        }

        #endregion "          CONSTRUCTORS           "

        private void frmSellOrderEntry_Load(object sender, EventArgs e)
        {
            this.AcceptButton = uctlOrderEntry1.ui_nbtnSubmit;
            this.FormClosing += new FormClosingEventHandler(frmOrderEntry_FormClosing);
            if (!_isMarketWatchOrderEntry)
            {
                SetPreferencesSettings();
            }
            count += 1;
            if (uctlOrderEntry1.Caption == "BUY")
            {
                _formkey = CommandIDS.PLACE_BUY_ORDER.ToString() + "/" + Convert.ToString(count);
            }
            else
            {
                _formkey = CommandIDS.PLACE_SELL_ORDER.ToString() + "/" + Convert.ToString(count);
            }
            this.Width = 798;
            this.Height = 160;
            uctlOrderEntry1.Dock = DockStyle.Fill;
            List<string> lstString = new List<string>();
            lstString.AddRange(ClsTWSContractManager.INSTANCE.LstProductTypes.ToArray());
            uctlOrderEntry1.AddInstruments(lstString);
            this.uctlOrderEntry1.InstrumentName = "FOREX";
            uctlOrderEntry1.BuyBgColor = Properties.Settings.Default.BuyOrderColor;
            uctlOrderEntry1.SellBgColor = Properties.Settings.Default.SellOrderColor;
            uctlOrderEntry1.AddOrderTypes(Cls.ClsGlobal.DDOrderTypes.Keys.ToArray());
            uctlOrderEntry1.OrderTypesToEnableTrigerPrice.Add("STOP");
            uctlOrderEntry1.OrderTypesToEnableTrigerPrice.Add("STOP_LIMIT");
            uctlOrderEntry1.AddItemsToValidity(Cls.ClsGlobal.DDValidity.Keys.ToArray());
            uctlOrderEntry1.OrderType = "MARKET";
            uctlOrderEntry1.Validity = "DAY";
            if (Properties.Settings.Default.MinOrderQty != 0)
                uctlOrderEntry1.OrderQty = Properties.Settings.Default.MinOrderQty;
            else
                uctlOrderEntry1.OrderQty = 1;
            //if (Properties.Settings.Default.AccountType != "---SELECT---")
            //    uctlOrderEntry1.AccountType = Properties.Settings.Default.AccountType;
            //else
            uctlOrderEntry1.AccountType = "Client";
            //uctlOrderEntry1.ui_nNUpDown.Select();
            uctlOrderEntry1.ui_ncmbOrderType.Select();
        }

        void LoadAccounts()
        {
            try
            {
                foreach (int item in clsTWSOrderManagerJSON.INSTANCE.GetParticipantsList().Keys)
                {
                    accounts.Add(Convert.ToString(item));
                }
                uctlOrderEntry1.AddAccountNos(accounts.ToArray());

            }
            catch (Exception)
            {
            }
        }


        private void INSTANCE_OnLTPChange(string Contract, double Price)
        {
            Action A = () =>
            {
                if (uctlOrderEntry1.ContractName == Contract)
                {
                    if (uctlOrderEntry1.ui_lblOrderEntryType.Text.ToUpper() == "BUY")
                    {
                        double price = Cls.ClsGlobal.GetZeroLevelAskPrice(uctlOrderEntry1.ContractName);
                        uctlOrderEntry1.Price = price != 0 ? Convert.ToString(price) : string.Empty;

                    }
                    else if (uctlOrderEntry1.ui_lblOrderEntryType.Text.ToUpper() == "SELL")
                    {
                        double price = Cls.ClsGlobal.GetZeroLevelBidPrice(uctlOrderEntry1.ContractName);
                        uctlOrderEntry1.Price = price != 0 ? Convert.ToString(price) : string.Empty;
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

        private void frmOrderEntry_FormClosed(object sender, FormClosedEventArgs e)
        {
            SavePreferencesSettings();
            count -= 1;
            clsTWSDataManagerJSON.INSTANCE.OnLTPChange -= INSTANCE_OnLTPChange;
            if (uctlOrderEntry1.Caption == "BUY")
            {
                _formkey = CommandIDS.PLACE_BUY_ORDER.ToString() + "/" + Convert.ToString(count);
            }
            else
            {
                _formkey = CommandIDS.PLACE_SELL_ORDER.ToString() + "/" + Convert.ToString(count);
            }
        }


        private void uctlOrderEntry1_OnSubmitClick(ClsOrderEntryInfo orderEntryInfo,
                                                   ClsGlobal.OrderMode mode)
        {
            string validationMessage = string.Empty;

            validationMessage = ValidateOrderEntry(orderEntryInfo.ProductType, orderEntryInfo.Symbol,
                                                         orderEntryInfo.Price, orderEntryInfo.StopPrice,
                                                         orderEntryInfo.Quantity, orderEntryInfo.OrderType,
                                                         orderEntryInfo.Side);
            InstrumentSpec spec = ClsTWSContractManager.INSTANCE.ddContractDetails[orderEntryInfo.Symbol];
            int Account = 0;
            int.TryParse(uctlOrderEntry1.ui_ncmbAccountNos.SelectedItem.ToString(), out Account);

            if (validationMessage.Trim() == string.Empty)
            {
                var objclsNewOrder = new ClsNewOrder();

                if (uctlOrderEntry1.ui_ncmbAccountNos.SelectedItem != null)
                {
                    objclsNewOrder.Account = Account;
                    if (mode == ClsGlobal.OrderMode.MODIFY)
                    {
                        objclsNewOrder.ClOrdId = objclsOldOrder.ClOrdId;
                        objclsNewOrder.OrderID = objclsOldOrder.OrderID;
                    }
                    else
                    {
                        int OrderId = Cls.ClsGlobal.GetClientOrderID();
                        objclsNewOrder.ClOrdId = OrderId.ToString();
                        objclsNewOrder.OrderID = OrderId;
                    }

                    objclsNewOrder.Contract = orderEntryInfo.Symbol;

                    string productType = orderEntryInfo.ProductType;
                    string pType = string.Empty;
                    switch (productType)
                    {
                        case "EQUITY":
                            pType = "EQ";
                            break;
                        case "FUTURE":
                            pType = "FUT";
                            break;
                        case "FOREX":
                            pType = "FX";
                            break;
                        case "OPTION":
                            pType = "OPT";
                            break;
                        case "SPOT":
                            pType = "SP";
                            break;
                        case "PHYSICAL":
                            pType = "PH";
                            break;
                        case "AUCTION":
                            pType = "AU";
                            break;
                        case "BOND":
                            pType = "BON";
                            break;
                    }
                    ;

                    objclsNewOrder.ProductType = Convert.ToChar(Cls.ClsGlobal.DDProductTypes[pType]);
                    objclsNewOrder.Product = orderEntryInfo.ProductName;
                    DateTime dtEX;
                    if (DateTime.TryParse(orderEntryInfo.ExpiryDate, out dtEX))
                    {
                        if (dtEX != null)
                            objclsNewOrder.ExpireDate = Convert.ToDateTime(orderEntryInfo.ExpiryDate).Ticks;
                    }

                    objclsNewOrder.Gateway = orderEntryInfo.GatewayName;
                    objclsNewOrder.OrderQty = (uint)(orderEntryInfo.Quantity * spec.ContractSize);
                    objclsNewOrder.OrderType = (char)Cls.ClsGlobal.DDOrderTypes[orderEntryInfo.OrderType];
                    if (orderEntryInfo.OrderType == "STOP")
                    {
                        objclsNewOrder.Price = 0;
                    }
                    else
                        objclsNewOrder.Price = orderEntryInfo.Price * Math.Pow(10, spec.Digits);
                    objclsNewOrder.StopPx = orderEntryInfo.StopPrice * Math.Pow(10, spec.Digits);
                    if (uctlOrderEntry1.ui_lblOrderEntryType.Text == "BUY")
                    {
                        //objclsNewOrder.Side = (sbyte)clsHashDefine.SIDE_BUY;
                        objclsNewOrder.Side = clsHashDefine.SIDE_BUY;
                    }
                    else
                    {
                        objclsNewOrder.Side = clsHashDefine.SIDE_SELL;
                    }
                    objclsNewOrder.TimeInForce = Convert.ToChar(Cls.ClsGlobal.DDValidity[orderEntryInfo.Validity]);
                    //objclsNewOrder.PositionEffect = clsHashDefine.POSITION_OPENING_TRADE;
                    objclsNewOrder.PositionEffect = 'O';
                    objclsNewOrder.origClOrdId = "";
                    objclsNewOrder.ExpireDate = 0;
                    objclsNewOrder.LnkdOrdId = "";


                    if (mode == ClsGlobal.OrderMode.NEW)
                    {
                        if (clsTWSOrderManagerJSON.INSTANCE.SubmitNewOrder(objclsNewOrder))
                        {
                            if (Properties.Settings.Default.IsFrshOrder)
                            {
                                DialogResult result =
                                    ClsCommonMethods.ShowMessageBox(ConfirmationMessage);
                                if (result == DialogResult.Yes)
                                {
                                    Close();
                                }
                            }
                            else
                            {
                                Close();
                            }
                        }
                        else
                        {

                        }
                    }
                    else if (mode == ClsGlobal.OrderMode.MODIFY)
                    {
                        ClsModifyOrder objModifyOrder = new ClsModifyOrder();
                        objModifyOrder.Account = objclsNewOrder.Account;
                        objModifyOrder.ClOrdId = objclsNewOrder.ClOrdId;
                        objModifyOrder.Contract = objclsNewOrder.Contract;
                        objModifyOrder.Gateway = objclsNewOrder.Gateway;
                        objModifyOrder.OrderID = objclsNewOrder.OrderID;
                        objModifyOrder.OrderQty = objclsNewOrder.OrderQty;
                        objModifyOrder.OrderType = objclsNewOrder.OrderType;
                        objModifyOrder.origClOrdId = objclsNewOrder.ClOrdId;
                        objModifyOrder.PositionEffect = objclsNewOrder.PositionEffect;
                        objModifyOrder.Price = objclsNewOrder.Price;
                        objModifyOrder.Product = objclsNewOrder.Product;
                        objModifyOrder.ProductType = objclsNewOrder.ProductType;
                        objModifyOrder.Side = objclsNewOrder.Side;
                        objModifyOrder.StopPx = objclsNewOrder.StopPx;
                        objModifyOrder.TimeInForce = objclsNewOrder.TimeInForce;
                        objModifyOrder.OldAccount = objclsOldOrder.Account;
                        objModifyOrder.OldClOrdId = objclsOldOrder.ClOrdId;
                        objModifyOrder.OldContract = objclsOldOrder.Contract;
                        objModifyOrder.OldGateway = objclsOldOrder.Gateway;
                        objModifyOrder.OldOrderID = objclsOldOrder.OrderID;
                        objModifyOrder.OldOrderQty = objclsOldOrder.OrderQty * spec.ContractSize;
                        objModifyOrder.OldOrderType = objclsOldOrder.OrderType;
                        objModifyOrder.OldorigClOrdId = "";
                        objModifyOrder.OldPositionEffect = objclsOldOrder.PositionEffect;
                        objModifyOrder.OldPrice = objclsOldOrder.Price * Math.Pow(10, spec.Digits);
                        objModifyOrder.OldProduct = objclsOldOrder.Product;
                        objModifyOrder.OldProductType = objclsOldOrder.ProductType;
                        objModifyOrder.OldSide = objclsOldOrder.Side;
                        objModifyOrder.OldStopPx = objclsOldOrder.StopPx * Math.Pow(10, spec.Digits);
                        objModifyOrder.OldTimeInForce = objclsOldOrder.TimeInForce;

                        if (clsTWSOrderManagerJSON.INSTANCE.ModifyOrder(objModifyOrder))
                        {
                            Close();
                        }
                    }
                }
                else
                {
                    ClsCommonMethods.ShowInfoBox("Default Trading account is not set.Please check.");
                }
            }
            else
            {
                if (validationMessage.Contains("# Contract name"))
                    uctlOrderEntry1.ui_ntxtSymbol.Focus();
                ClsCommonMethods.ShowInfoBox(validationMessage);
            }
            //}
            //else
            //{
            //    FrmMain.INSTANCE.tlstrplblStatusMsg.Text = "Unable to place order, Reason : Data Server disconnected.";
            //    FrmMain.INSTANCE.tlstrplblStatusMsg.BackColor = Color.Red;
            //    //ClsCommonMethods.ShowErrorBox("Unable to place order, Reason : Data Server disconnected");
            //}
        }

        private void uctlOrderEntry1_OnSymbolTextChanged(string symbolName)
        {
            var lstExpiryDate = new List<string>();


            foreach (var instrument in ClsTWSContractManager.INSTANCE.ddContractDetails.Values)
            {
                lstExpiryDate.Add(Convert.ToString(instrument.ExpiryDate));
            }
            uctlOrderEntry1.AddExpiryDate(lstExpiryDate);
            lstExpiryDate.Clear();
        }

        private void uctlOrderEntry1_OnBuySellColorChanged(Color buyOrderColor, Color sellOrderColor)
        {
            Properties.Settings.Default.BuyOrderColor = buyOrderColor;
            Properties.Settings.Default.SellOrderColor = sellOrderColor;

            if (uctlOrderEntry1.ui_lblOrderEntryType.Text == "BUY")
            {
                uctlOrderEntry1.ui_npnlOrderEntry.BackColor = buyOrderColor;
                byte r = buyOrderColor.R;
                byte g = buyOrderColor.G;
                byte b = buyOrderColor.B;
                byte a = buyOrderColor.A;
                int cond = ((r * 299) + (g * 587) + (b * 114)) / 1000;
                if (cond < 110) //a<100 || r < 100 || g < 100 || b < 100)
                {
                    foreach (Control c in uctlOrderEntry1.ui_tblPnl.Controls)
                    {
                        if (c is Label)
                        {
                            c.ForeColor = Color.White;
                        }
                    }
                }
                else
                {
                    foreach (Control c in uctlOrderEntry1.ui_tblPnl.Controls)
                    {
                        if (c is Label)
                        {
                            c.ForeColor = Color.Black;
                        }
                    }
                }
            }
            else
            {
                uctlOrderEntry1.ui_npnlOrderEntry.BackColor = sellOrderColor;
                byte r = buyOrderColor.R;
                byte g = buyOrderColor.G;
                byte b = buyOrderColor.B;
                int cond = ((r * 299) + (g * 587) + (b * 114)) / 1000;
                if (cond < 110) //r < 100 || g < 100 || b < 100)
                {
                    foreach (Control c in uctlOrderEntry1.ui_tblPnl.Controls)
                    {
                        if (c is Label)
                        {
                            c.ForeColor = Color.White;
                        }
                    }
                }
                else
                {
                    foreach (Control c in uctlOrderEntry1.ui_tblPnl.Controls)
                    {
                        if (c is Label)
                        {
                            c.ForeColor = Color.Black;
                        }
                    }
                }
            }
            Properties.Settings.Default.Save();
        }

        private void uctlOrderEntry1_OnOrderTypeChanged(string OrderType)
        {
            try
            {
                _orderType = OrderType.Trim().ToUpper();
                if (OrderType == "MMO")
                {
                    uctlOrderEntry1.ui_ntxtPrice.Enabled = true;
                    var MMOTypes = new List<string> { "---SELECT---", "Market Making", "Hedging" };
                    uctlOrderEntry1.AddMMOTypes(MMOTypes);
                }
                else if (_orderType == "MARKET")
                {
                    uctlOrderEntry1.ui_ntxtPrice.Enabled = false;
                    uctlOrderEntry1.ui_ntxtTrigPrice.Enabled = false;
                    uctlOrderEntry1.Price = string.Empty;
                    uctlOrderEntry1.TrigPrice = string.Empty;
                    if (uctlOrderEntry1.ui_lblOrderEntryType.Text.ToUpper() == "BUY")
                    {
                        double price = Cls.ClsGlobal.GetZeroLevelAskPrice(uctlOrderEntry1.ContractName);
                        uctlOrderEntry1.Price = price != 0 ? Convert.ToString(price) : string.Empty;
                    }
                    else if (uctlOrderEntry1.ui_lblOrderEntryType.Text.ToUpper() == "SELL")
                    {
                        double price = Cls.ClsGlobal.GetZeroLevelBidPrice(uctlOrderEntry1.ContractName);
                        uctlOrderEntry1.Price = price != 0 ? Convert.ToString(price) : string.Empty;
                    }
                    clsTWSDataManagerJSON.INSTANCE.OnLTPChange -= INSTANCE_OnLTPChange;
                    clsTWSDataManagerJSON.INSTANCE.OnLTPChange += INSTANCE_OnLTPChange;
                    uctlOrderEntry1.ClearMMOTypes();
                }
                else if (_orderType == "STOP")
                {
                    if (uctlOrderEntry1.ui_ntxtPrice.Text == null || uctlOrderEntry1.ui_ntxtPrice.Text.Trim() == string.Empty)
                    {
                        uctlOrderEntry1.ui_ntxtPrice.Text = "0";
                    }
                    uctlOrderEntry1.ui_ntxtPrice.Enabled = false;
                    uctlOrderEntry1.ui_ntxtTrigPrice.Enabled = true;
                    uctlOrderEntry1.Price = string.Empty;
                    double trigPrice = Cls.ClsGlobal.GetZeroLevelLTP(uctlOrderEntry1.ContractName);
                    if (uctlOrderEntry1.ui_lblOrderEntryType.Text.ToUpper() == "BUY")
                    {
                        uctlOrderEntry1.TrigPrice = trigPrice != 0 ? Convert.ToString(trigPrice + StopLevel) : string.Empty;
                    }
                    else if (uctlOrderEntry1.ui_lblOrderEntryType.Text.ToUpper() == "SELL")
                    {
                        uctlOrderEntry1.TrigPrice = trigPrice != 0 ? Convert.ToString(trigPrice - StopLevel) : string.Empty;
                    }
                    clsTWSDataManagerJSON.INSTANCE.OnLTPChange -= INSTANCE_OnLTPChange;
                    uctlOrderEntry1.ClearMMOTypes();
                }
                else if (_orderType == "LIMIT")
                {
                    uctlOrderEntry1.ui_ntxtPrice.Enabled = true;
                    uctlOrderEntry1.ui_ntxtTrigPrice.Enabled = false;
                    uctlOrderEntry1.TrigPrice = string.Empty;
                    double price = Cls.ClsGlobal.GetZeroLevelLTP(uctlOrderEntry1.ContractName);
                    if (uctlOrderEntry1.ui_lblOrderEntryType.Text.ToUpper() == "BUY")
                    {
                        uctlOrderEntry1.Price = price != 0 ? Convert.ToString(price - StopLevel) : string.Empty;
                    }
                    else if (uctlOrderEntry1.ui_lblOrderEntryType.Text.ToUpper() == "SELL")
                    {
                        uctlOrderEntry1.Price = price != 0 ? Convert.ToString(price + StopLevel) : string.Empty;
                    }

                    clsTWSDataManagerJSON.INSTANCE.OnLTPChange -= INSTANCE_OnLTPChange;
                    uctlOrderEntry1.ClearMMOTypes();
                }
                else if (_orderType == "STOP_LIMIT")
                {
                    uctlOrderEntry1.ui_ntxtPrice.Enabled = true;
                    uctlOrderEntry1.ui_ntxtTrigPrice.Enabled = true;
                    double price = Cls.ClsGlobal.GetZeroLevelLTP(uctlOrderEntry1.ContractName);
                    if (uctlOrderEntry1.ui_lblOrderEntryType.Text.ToUpper() == "BUY")
                    {
                        uctlOrderEntry1.TrigPrice = price != 0 ? Convert.ToString(price + StopLevel) : string.Empty;
                        uctlOrderEntry1.Price = price != 0 ? Convert.ToString(price + StopLevel + 1) : string.Empty;
                    }
                    else if (uctlOrderEntry1.ui_lblOrderEntryType.Text.ToUpper() == "SELL")
                    {
                        uctlOrderEntry1.TrigPrice = price != 0 ? Convert.ToString(price - StopLevel) : string.Empty;
                        uctlOrderEntry1.Price = price != 0 ? Convert.ToString(price - StopLevel - 1) : string.Empty;
                    }

                    clsTWSDataManagerJSON.INSTANCE.OnLTPChange -= INSTANCE_OnLTPChange;
                    uctlOrderEntry1.ClearMMOTypes();
                }
                else
                {
                    uctlOrderEntry1.ui_ntxtPrice.Enabled = true;
                    uctlOrderEntry1.ui_ntxtTrigPrice.Enabled = false;
                    clsTWSDataManagerJSON.INSTANCE.OnLTPChange -= INSTANCE_OnLTPChange;
                    uctlOrderEntry1.ClearMMOTypes();
                }
            }
            catch (Exception)
            {
            }

        }

        #region "          PRIVATE METHODS          "

        private void SavePreferencesSettings()
        {
            if (Properties.Settings.Default.IsRetainLastParticipaintCodeOmniId)
            {
                Properties.Settings.Default.LastParticipaintOmniID = uctlOrderEntry1.PartnerOminiId;
            }

            Properties.Settings.Default.Save();
        }

        private string ValidateOrderEntry(string productType, string ContractName, double Price, double trigerPrice,
                                         int qty, string OrderType, string Side)
        {
            string message = string.Empty;
            string ProductName = ClsTWSContractManager.INSTANCE.ddContractDetails[ContractName].Product;
            if (Cls.ClsGlobal.DDLTP.ContainsKey(ContractName))
            {
                double _ltp = Cls.ClsGlobal.DDLTP[ContractName];
                if (_ltp <= 0)
                {
                    message = "# Oreder is not allowed, LTP should be greater than 0 ." + Environment.NewLine;
                }
                else
                {
                    InstrumentSpec spec = null;
                    if (qty == 0)
                    {
                        message = "# Quantity should be greater than 0." + Environment.NewLine;
                        return message;
                    }
                    else if (ProductName == string.Empty)
                    {
                        message = "# Contract name not found." + Environment.NewLine;
                        return message;
                    }
                    else
                    {
                        spec = ClsTWSContractManager.INSTANCE.ddContractDetails[ContractName];
                        if (spec != null)
                        {
                            int digits = spec.Digits;
                            if (spec.Digits == 3 || spec.Digits == 5)
                            {
                                digits = spec.Digits - 1;
                            }
                            double mindiff = spec.Limit_Stop_Level / Math.Pow(10, digits);
                            //double _range = spec.Limit_Stop_Level * mindiff;
                            double _range = 5 * mindiff;

                            if (Side == "BUY")
                            {
                                switch (OrderType.ToUpper().Trim())
                                {
                                    //case "MMO":
                                    case "LIMIT":
                                        if (Price <= 0)
                                        {
                                            message = "# Price should be greater than 0 ." + Environment.NewLine;
                                        }
                                        else if (!ValidateDeicmalPart(Math.Round(Price, digits).ToString(), spec.Limit_Stop_Level, digits))
                                        {
                                            message = "# Price should be multiple of " + spec.Limit_Stop_Level.ToString() + "." + Environment.NewLine;
                                        }
                                        else if (_ltp != 0 && Price > (_ltp - mindiff))
                                        {
                                            message = "# Price should be less than or equal to " + Convert.ToString(_ltp - mindiff) + " ." +
                                                      Environment.NewLine;
                                        }
                                        else if (Price < (_ltp - _range))
                                        {
                                            message = "# Price should be in range between " + Convert.ToString(_ltp - _range) + " and " + Convert.ToString(_ltp - mindiff) + " ." + Environment.NewLine;
                                        }
                                        break;
                                    case "STOP":
                                        if (trigerPrice == 0)//if (Price == 0)
                                        {
                                            message = "# Triger Price should be greater than 0 ." + Environment.NewLine;
                                        }
                                        else if (!ValidateDeicmalPart(Math.Round(trigerPrice, digits).ToString(), spec.Limit_Stop_Level, digits))
                                        {
                                            message = "# Triger Price should be multiple of " + spec.Limit_Stop_Level.ToString() + "." + Environment.NewLine;
                                        }
                                        else if (_ltp != 0 && trigerPrice < (_ltp + mindiff))
                                        {
                                            message = "#Triger Price should be greater than or equal to " + Convert.ToString(_ltp + mindiff) + " ." +
                                                      Environment.NewLine;
                                        }
                                        else if (trigerPrice > (_ltp + _range))
                                        {
                                            message = "#Triger Price should be in range between " + Convert.ToString(_ltp + _range) + " and " + Convert.ToString(_ltp + mindiff) + " ." + Environment.NewLine;
                                        }
                                        break;
                                    case "MARKET":

                                        break;
                                    case "STOP_LIMIT":
                                        if (trigerPrice == 0)
                                        {
                                            message = "# Triger Price should be greater than 0 ." + Environment.NewLine;
                                        }
                                        else if (!ValidateDeicmalPart(Math.Round(trigerPrice, digits).ToString(), spec.Limit_Stop_Level, digits))
                                        {
                                            message = "# Triger Price should be multiple of " + spec.Limit_Stop_Level.ToString() + "." + Environment.NewLine;
                                        }
                                        else if (Price == 0)
                                        {
                                            message = "# Price should be greater than 0 ." + Environment.NewLine;
                                        }
                                        else if (!ValidateDeicmalPart(Math.Round(Price, digits).ToString(), spec.Limit_Stop_Level, digits))
                                        {
                                            message = "# Price should be multiple of " + spec.Limit_Stop_Level.ToString() + "." + Environment.NewLine;
                                        }
                                        else if (_ltp != 0 && trigerPrice < (_ltp + mindiff))
                                        {
                                            message = "# Triger Price should be greater than or equal to " + Convert.ToString(_ltp + mindiff) + " ." +
                                                      Environment.NewLine;
                                        }
                                        else if (_ltp != 0 && Price <= trigerPrice)
                                        {
                                            message = "# Price should be greater than " + Convert.ToString(trigerPrice) + " ." +
                                                      Environment.NewLine;
                                        }
                                        else if (Price < (_ltp - _range))
                                        {
                                            message = "# Price should be in range between " + Convert.ToString(_ltp - _range) + " and " + Convert.ToString(_ltp - mindiff) + " ." + Environment.NewLine;
                                        }
                                        else if (trigerPrice > (_ltp + _range))
                                        {
                                            message = "#Triger Price should be in range between " + Convert.ToString(_ltp + _range) + " and " + Convert.ToString(_ltp + mindiff) + " ." + Environment.NewLine;
                                        }
                                        break;
                                    default:
                                        break;
                                };

                            }
                            else
                            {
                                switch (OrderType.ToUpper().Trim())
                                {
                                    case "LIMIT":
                                        if (Price == 0)
                                        {
                                            message = "# Price should be greater than 0 ." + Environment.NewLine;
                                        }
                                        else if (!ValidateDeicmalPart(Math.Round(Price, digits).ToString(), spec.Limit_Stop_Level, digits))
                                        {
                                            message = "# Price should be multiple of " + spec.Limit_Stop_Level.ToString() + "." + Environment.NewLine;
                                        }
                                        else if (_ltp != 0 && Price < (_ltp + mindiff))
                                        {
                                            message = "# Price should be greater than equal to " + Convert.ToString(_ltp + mindiff) + " ." +
                                                      Environment.NewLine;
                                        }
                                        else if (Price > (_ltp + _range))
                                        {
                                            message = "# Price should be in range between " + Convert.ToString(_ltp + _range) + " and " + Convert.ToString(_ltp + mindiff) + " ." + Environment.NewLine;
                                        }
                                        break;
                                    case "STOP":
                                        if (trigerPrice == 0)
                                        {
                                            message = "# Triger Price should be greater than 0 ." + Environment.NewLine;
                                        }
                                        else if (!ValidateDeicmalPart(Math.Round(trigerPrice, digits).ToString(), spec.Limit_Stop_Level, digits))
                                        {
                                            message = "# Triger Price should be multiple of " + spec.Limit_Stop_Level.ToString() + "." + Environment.NewLine;
                                        }
                                        else if (_ltp != 0 && trigerPrice > (_ltp - mindiff))
                                        {
                                            message = "# Price should be less than or equal to " + Convert.ToString(_ltp - mindiff) + " ." +
                                                      Environment.NewLine;
                                        }
                                        else if (trigerPrice < (_ltp - _range))
                                        {
                                            message = "#Triger Price should be in range between " + Convert.ToString(_ltp - _range) + " and " + Convert.ToString(_ltp - mindiff) + " ." + Environment.NewLine;
                                        }
                                        break;
                                    case "STOP_LIMIT":
                                        if (trigerPrice == 0)
                                        {
                                            message = "# Triger Price should be greater than 0 ." + Environment.NewLine;
                                        }
                                        else if (!ValidateDeicmalPart(Math.Round(trigerPrice, digits).ToString(), spec.Limit_Stop_Level, digits))
                                        {
                                            message = "# Triger Price should be multiple of " + spec.Limit_Stop_Level.ToString() + "." + Environment.NewLine;
                                        }
                                        else if (Price == 0)
                                        {
                                            message = "# Price should be greater than 0 ." + Environment.NewLine;
                                        }
                                        else if (!ValidateDeicmalPart(Math.Round(Price, digits).ToString(), spec.Limit_Stop_Level, digits))
                                        {
                                            message = "# Price should be multiple of " + spec.Limit_Stop_Level.ToString() + "." + Environment.NewLine;
                                        }
                                        else if (_ltp != 0 && trigerPrice > (_ltp - mindiff))
                                        {
                                            message = "# Triger Price should be less than or equal to " + Convert.ToString(_ltp - mindiff) + " ." +
                                                      Environment.NewLine;
                                        }
                                        else if (_ltp != 0 && Price >= _ltp)
                                        {
                                            message = "# Price should be less than " + Convert.ToString(trigerPrice) + " ." +
                                                      Environment.NewLine;
                                        }
                                        else if (Price > (_ltp + _range))
                                        {
                                            message = "# Price should be in range between " + Convert.ToString(_ltp + _range) + " and " + Convert.ToString(_ltp + mindiff) + " ." + Environment.NewLine;
                                        }
                                        else if (trigerPrice < (_ltp - _range))
                                        {
                                            message = "#Triger Price should be in range between " + Convert.ToString(_ltp - _range) + " and " + Convert.ToString(_ltp - mindiff) + " ." + Environment.NewLine;
                                        }
                                        break;
                                    case "MARKET":
                                        break;
                                    default:
                                        break;
                                };
                            }
                        }
                        else
                        {
                            message = "# Unable to get Contract Information." + Environment.NewLine;
                            return message;
                        }
                    }
                }
            }
            else
            {
                message = "# LTP not generated ." + Environment.NewLine;
            }

            return message;
        }
        private bool ValidateDeicmalPart(string price, int LimitStopLevel, int digit)
        {
            bool _result = true;
            try
            {
                if (LimitStopLevel > 0)
                {
                    if (price.Contains("."))
                    {
                        string[] ar = price.Split('.');

                        double _decimalPart = 0;
                        double.TryParse(ar[1], out _decimalPart);
                        if (digit >= 2 && _decimalPart < Math.Pow(10, digit - 1))
                        {
                            _decimalPart = _decimalPart * Math.Pow(10, digit - 1);
                        }
                        if (_decimalPart % LimitStopLevel != 0)
                        {
                            _result = false;
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
            return _result;
        }

        #endregion "          PRIVATE METHODS          "

        #region "          PUBLIC METHODS           "

        public void SetPreferencesSettings()
        {
            if (Properties.Settings.Default.IsAlwaysUseMinOrderQtyGiven)
            {
                uctlOrderEntry1.Quantity = Properties.Settings.Default.MinOrderQty;
            }
            uctlOrderEntry1.Validity = Properties.Settings.Default.OrderValidity;
            uctlOrderEntry1.DQuantity = !Properties.Settings.Default.IsDisableDQty;
            uctlOrderEntry1.AccountType = Properties.Settings.Default.AccountType;
            //uctlOrderEntry1.Client = Properties.Settings.Default.PrefixClientIDWith;
            uctlOrderEntry1.PartnerOminiId = Properties.Settings.Default.PrefixOmniIdWith;
            uctlOrderEntry1.ClientNameEnable = Properties.Settings.Default.IsClientNameEnable;
            uctlOrderEntry1.InstrumentName = Properties.Settings.Default.DefaultInstrumentName;
            //if (Properties.Settings.Default.IsRetainLastClientID)
            //{
            //    uctlOrderEntry1.Client = Properties.Settings.Default.LastClientID;
            //}
            if (Properties.Settings.Default.IsRetainLastParticipaintCodeOmniId)
            {
                uctlOrderEntry1.PartnerOminiId = Properties.Settings.Default.LastParticipaintOmniID;
            }
        }

        public void FillValues(DataGridViewRow selectedRow)
        {
            Action A = () =>
                           {
                               _isMarketWatchOrderEntry = false;
                               uctlOrderEntry1.ContractName = selectedRow.Cells["ClmContractName"].Value.ToString();
                               uctlOrderEntry1.Key = selectedRow.Cells["ClmInstrumentId"].Value.ToString();
                               //uctlOrderEntry1.Key = selectedRow.Cells["clmGateway"].Value.ToString() + Symbol._Seperator + TWS.Cls.ClsGlobal.DDProductTypes[selectedRow.Cells["clmProductType"].Value.ToString()] + Symbol._Seperator + selectedRow.Cells["clmProductName"].Value.ToString() + Symbol._Seperator + selectedRow.Cells["clmContract"].Value.ToString(); 
                               uctlOrderEntry1.InstrumentName = selectedRow.Cells["ClmProductType"].Value.ToString();
                               uctlOrderEntry1.AddItemToExpiry(selectedRow.Cells["ClmExpiry"].Value.ToString());
                               //if (uctlOrderEntry1.ui_lblOrderEntryType.Text.ToUpper().Trim() == "SELL")
                               //    uctlOrderEntry1.Price = selectedRow.Cells["ClmBuyPrice"].Value.ToString();
                               //else
                               //    uctlOrderEntry1.Price = selectedRow.Cells["ClmSellPrice"].Value.ToString();
                               //if (selectedRow.Cells["ClmLTP"].Value.ToString() != string.Empty)
                               //    uctlOrderEntry1.LTP = Convert.ToDouble(selectedRow.Cells["ClmLTP"].Value.ToString());
                               //else
                               //    uctlOrderEntry1.LTP = 0;
                               Symbol sym = Symbol.GetSymbol(uctlOrderEntry1.Key);
                               uctlOrderEntry1.GatewayName = sym.Gateway;
                               uctlOrderEntry1.ProductName = sym.Product;
                               //uctlOrderEntry1.Price = selectedRow.Cells["ClmPriceQuotationUnit"].Value.ToString();
                               //string ProductName = ClsTWSContractManager.INSTANCE.GetProductNameForContract(selectedRow.Cells["ClmProductType"].Value.ToString(), uctlOrderEntry1.ContractName); // Commented : Ajay
                               string ProductName = ClsTWSContractManager.INSTANCE.ddContractDetails[uctlOrderEntry1.ContractName].Product;   // Added : Ajay
                               // spec = ClsTWSContractManager.INSTANCE.GetContractSpec(uctlOrderEntry1.ContractName, selectedRow.Cells["ClmProductType"].Value.ToString(), ProductName);

                               if (ClsTWSContractManager.INSTANCE.ddContractDetails.ContainsKey(uctlOrderEntry1.ContractName))
                               {
                                   spec = ClsTWSContractManager.INSTANCE.ddContractDetails[uctlOrderEntry1.ContractName];
                               }
                               //StopLevel = spec.Limit_Stop_Level;                              
                               StopLevel = spec.Limit_Stop_Level / Math.Pow(10, spec.Digits);
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

        public void FillValuesToModify(DataGridViewRow selectedRow)
        {
            Action A = () =>
                           {
                               uctlOrderEntry1.AccountType = "Client";
                               uctlOrderEntry1.AccountNo = selectedRow.Cells["clmClient"].Value.ToString();
                               uctlOrderEntry1.ContractName = selectedRow.Cells["clmContract"].Value.ToString();
                               uctlOrderEntry1.InstrumentName = selectedRow.Cells["clmProductType"].Value.ToString();
                               uctlOrderEntry1.AddItemToExpiry(selectedRow.Cells["clmSeriesExpiry"].Value.ToString());
                               uctlOrderEntry1.Price = selectedRow.Cells["clmPrice"].Value.ToString();
                               uctlOrderEntry1.OrderType = selectedRow.Cells["clmOrderType"].Value.ToString();
                               uctlOrderEntry1.Validity = selectedRow.Cells["clmValidity"].Value.ToString();

                               if (!String.IsNullOrEmpty(selectedRow.Cells["clmOrderQuantity"].Value.ToString()))
                                   uctlOrderEntry1.OrderQty =
                                       Convert.ToInt32(selectedRow.Cells["clmOrderQuantity"].Value.ToString());

                               objclsOldOrder.Account = Convert.ToInt32(selectedRow.Cells["clmClient"].Value.ToString());
                               objclsOldOrder.ClOrdId = selectedRow.Cells["clmOrderNumber"].Value.ToString();
                               objclsOldOrder.OrderID = Convert.ToInt32(selectedRow.Cells["clmOrderNumber"].Value.ToString().Trim());
                               objclsOldOrder.Contract = selectedRow.Cells["clmContract"].Value.ToString();
                               uctlOrderEntry1.GatewayName = selectedRow.Cells["clmGateway"].Value.ToString();
                               uctlOrderEntry1.ProductName = selectedRow.Cells["clmProductName"].Value.ToString();
                               objclsOldOrder.Product = selectedRow.Cells["clmProductName"].Value.ToString();
                               objclsOldOrder.Gateway = selectedRow.Cells["clmGateway"].Value.ToString();
                               string productType = selectedRow.Cells["clmProductType"].Value.ToString();
                               string pType = string.Empty;
                               switch (productType)
                               {
                                   case "EQUITY":
                                       pType = "EQ";
                                       break;
                                   case "FUTURE":
                                       pType = "FUT";
                                       break;
                                   case "FOREX":
                                       pType = "FX";
                                       break;
                                   case "OPTION":
                                       pType = "OPT";
                                       break;
                                   case "SPOT":
                                       pType = "SP";
                                       break;
                                   case "PHYSICAL":
                                       pType = "PH";
                                       break;
                                   case "AUCTION":
                                       pType = "AU";
                                       break;
                                   case "BOND":
                                       pType = "BON";
                                       break;
                               }
                               ;
                               uctlOrderEntry1.Key = selectedRow.Cells["clmGateway"].Value.ToString() + Symbol._Seperator + (char)TWS.Cls.ClsGlobal.DDProductTypes[pType] + Symbol._Seperator + selectedRow.Cells["clmProductName"].Value.ToString() + Symbol._Seperator + selectedRow.Cells["clmContract"].Value.ToString();
                               //objclsOldOrder.StrProductType = productType;
                               objclsOldOrder.ProductType = Convert.ToChar(Cls.ClsGlobal.DDProductTypes[pType]);
                               objclsOldOrder.ExpireDate = 0;
                               //DateTime dtEX;
                               //if (DateTime.TryParse(selectedRow.Cells["clmSeriesExpiry"].Value.ToString(), out dtEX))
                               //{
                               //    if (dtEX != null)
                               //        objclsOldOrder.ExpireDate = Convert.ToDateTime(selectedRow.Cells["clmSeriesExpiry"].Value);
                               //}

                               objclsOldOrder.OrderQty = Convert.ToUInt32(selectedRow.Cells["clmOrderQuantity"].Value.ToString());
                               objclsOldOrder.OrderType = Convert.ToChar(Cls.ClsGlobal.DDOrderTypes[selectedRow.Cells["clmOrderType"].Value.ToString()]);
                               objclsOldOrder.Price = Convert.ToDouble(selectedRow.Cells["clmPrice"].Value.ToString());
                               objclsOldOrder.StopPx = 0.0; //orderEntryInfo.Client;
                               if (uctlOrderEntry1.ui_lblOrderEntryType.Text == "BUY")
                               {
                                   objclsOldOrder.Side = clsHashDefine.SIDE_BUY;
                               }
                               else
                               {
                                   objclsOldOrder.Side = clsHashDefine.SIDE_SELL;
                               }
                               objclsOldOrder.TimeInForce = Convert.ToChar(Cls.ClsGlobal.DDValidity[selectedRow.Cells["clmValidity"].Value.ToString()]);
                               //objclsOldOrder.MinorDisclosedQty = 0; //orderEntryInfo.Client;
                               objclsOldOrder.PositionEffect = clsHashDefine.EXECUTION_TYPE_NEW;

                               string ProductName = ClsTWSContractManager.INSTANCE.ddContractDetails[uctlOrderEntry1.ContractName].Product;// ClsTWSContractManager.INSTANCE.GetProductNameForContract(selectedRow.Cells["ClmProductType"].Value.ToString(), uctlOrderEntry1.ContractName);
                               //spec = ClsTWSContractManager.INSTANCE.GetContractSpec(uctlOrderEntry1.ContractName, selectedRow.Cells["ClmProductType"].Value.ToString(), ProductName);
                               spec = ClsTWSContractManager.INSTANCE.ddContractDetails[uctlOrderEntry1.ContractName];
                               StopLevel = spec.Limit_Stop_Level / Math.Pow(10, spec.Digits);
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

        #endregion "          PUBLIC METHODS           "

        private void uctlOrderEntry1_OnAccountNoChanged(string obj)
        {
            uctlOrderEntry1.ClientName = clsTWSOrderManagerJSON.INSTANCE._DDAccounts[Convert.ToInt32(obj)]["TraderName"].ToString();
        }

        private void frmOrderEntry_FormClosing(object sender, FormClosingEventArgs e)
        {
            //FrmMain.INSTANCE.tlstrplblStatusMsg.BackColor = StatusClr;
        }
    }
}