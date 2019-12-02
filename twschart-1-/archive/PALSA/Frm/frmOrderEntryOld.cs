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
using ClientDLL_Model.Cls;
using ClientDLL_Model.Cls.Contract;
using CommonLibrary.Cls;
using CommonLibrary.UserControls;
using PALSA.Cls;
using ClsGlobal = CommonLibrary.Cls.ClsGlobal;
using Nevron.UI.WinForm.Controls;

namespace PALSA.Frm
{
    public partial class frmOrderEntryOld : frmBase
    {
        #region "       VARIABLES        "

        private static frmOrderEntry _instance;
        private static int count;
        private string _formkey;
        private bool _isMarketWatchOrderEntry;

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
        public frmOrderEntryOld()
        {
            InitializeComponent();
            
            uctlOrderEntry1.AddInstruments(ClsTWSContractManager.INSTANCE.GetProductTypes());

            foreach(int item in ClsTWSOrderManager.INSTANCE.GetParticipantsList().Keys)
            {
            accounts.Add(Convert.ToString(item));
            }
            uctlOrderEntry1.AddAccountNos(accounts.ToArray());
        }

        public frmOrderEntryOld(DataGridViewRow selectedRow, ClsGlobal.OrderMode mode)
        {
            _isMarketWatchOrderEntry = true;
            InitializeComponent();
            uctlOrderEntry1.AddInstruments(ClsTWSContractManager.INSTANCE.GetProductTypes());
            uctlOrderEntry1.AddAccountNos(accounts.ToArray());
            
            if (mode == ClsGlobal.OrderMode.NEW)
                FillValues(selectedRow);
            else if (mode == ClsGlobal.OrderMode.MODIFY)
                FillValuesToModify(selectedRow);
        }

        #endregion "          CONSTRUCTORS           "

        private void frmSellOrderEntry_Load(object sender, EventArgs e)
        {

            //uctlOrderEntry1.OnProductTypeChanged += new Action<string>(uctlOrderEntry1_OnProductTypeChanged);
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
            //uctlOrderEntry1.Dock = DockStyle.None;
            //this.ClientSize = uctlOrderEntry1.Size;
                        this.Width=798;
            this.Height=160;
            //this.Location = new Point(this.Location.X, this.Location.Y-this.Height);

            uctlOrderEntry1.Dock = DockStyle.Fill;

            List<string> lstString = new List<string>();

            lstString.Add("FUTURE");
            uctlOrderEntry1.AddInstruments(lstString);
            this.uctlOrderEntry1.InstrumentName = "FUTURE";

            uctlOrderEntry1.BuyBgColor = Properties.Settings.Default.BuyOrderColor;
            uctlOrderEntry1.SellBgColor = Properties.Settings.Default.SellOrderColor;
            uctlOrderEntry1.AddOrderTypes(Cls.ClsGlobal.DDOrderTypes.Keys.ToArray());
            uctlOrderEntry1.AddAccountNos(ClsTWSOrderManager.INSTANCE.GetParticipantsList().Keys.ToArray());
            uctlOrderEntry1.OrderTypesToEnableTrigerPrice.Add("STOP");
            uctlOrderEntry1.OrderTypesToEnableTrigerPrice.Add("STOP_LIMIT");
            uctlOrderEntry1.AddItemsToValidity(Cls.ClsGlobal.DDValidity.Keys.ToArray());
            uctlOrderEntry1.OrderType = "MARKET";
            //if (Properties.Settings.Default.OrderValidity != "---SELECT---")
            //    uctlOrderEntry1.Validity = Properties.Settings.Default.OrderValidity;
            //else
                uctlOrderEntry1.Validity = "DAY";
                if (Properties.Settings.Default.MinOrderQty != 0)
                    uctlOrderEntry1.OrderQty = Properties.Settings.Default.MinOrderQty;
                else
                uctlOrderEntry1.OrderQty = 1;
            //if (Properties.Settings.Default.AccountType != "---SELECT---")
            //    uctlOrderEntry1.AccountType = Properties.Settings.Default.AccountType;
            //else
                uctlOrderEntry1.AccountType = "Client";
                uctlOrderEntry1.ui_nNUpDown.Focus();
        }

        void ContextMenu_Popup(object sender, EventArgs e)
        {
            
        }


        private void INSTANCE_OnLTPChange(string arg1, double arg2)
        {
            Action A = () =>
                           {
                               if (uctlOrderEntry1.ContractName == arg1)
                               {
                                   if (uctlOrderEntry1.ui_lblOrderEntryType.Text.ToUpper() == "BUY")
                                   {
                                       double price=PALSA.Cls.ClsGlobal.GetZeroLevelAskPrice(uctlOrderEntry1.ContractName);
                                       uctlOrderEntry1.Price = price!=0 ? Convert.ToString(price):string.Empty;
                                   }
                                   else if (uctlOrderEntry1.ui_lblOrderEntryType.Text.ToUpper() == "SELL")
                                   {
                                       double price = PALSA.Cls.ClsGlobal.GetZeroLevelBidPrice(uctlOrderEntry1.ContractName);
                                       uctlOrderEntry1.Price =  price!=0 ? Convert.ToString(price):string.Empty;
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
            ClsTWSDataManager.INSTANCE.OnLTPChange -= INSTANCE_OnLTPChange;
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
            string validationMessage = ValidateOrderEntry(orderEntryInfo.ProductType, orderEntryInfo.Symbol,
                                                          orderEntryInfo.Price, orderEntryInfo.StopPrice,
                                                          orderEntryInfo.Quantity, orderEntryInfo.OrderType,
                                                          orderEntryInfo.Side);
            if (validationMessage.Trim() == string.Empty)
            {
                var objclsNewOrder = new ClsNewOrder();
                //need to be changed later it will be one of trade account id from participentlist.
                if (uctlOrderEntry1.ui_ncmbAccountNos.SelectedItem != null)
                {
                    objclsNewOrder.Account = Convert.ToUInt32(uctlOrderEntry1.ui_ncmbAccountNos.SelectedItem.ToString());
                    if (mode == ClsGlobal.OrderMode.MODIFY)
                    {
                        objclsNewOrder.ClOrderID = objclsOldOrder.ClOrderID;
                    }
                    else
                    {
                        objclsNewOrder.ClOrderID = Convert.ToString(Cls.ClsGlobal.GetClientOrderID());
                    }
                    //orderEntryInfo.Client;
                    objclsNewOrder.ContractName = orderEntryInfo.Symbol;

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
                    objclsNewOrder.StrProductType = productType;
                    objclsNewOrder.SbProductType = Cls.ClsGlobal.DDProductTypes[pType];
                    objclsNewOrder.ProductName = orderEntryInfo.ProductName;
                    DateTime dtEX;
                    if (DateTime.TryParse(orderEntryInfo.ExpiryDate, out dtEX))
                    {
                        if (dtEX != null)
                            objclsNewOrder.ExpiryDate = Convert.ToDateTime(orderEntryInfo.ExpiryDate);
                    }

                    objclsNewOrder.GatewayName = orderEntryInfo.GatewayName;
                    objclsNewOrder.Qty = (uint) orderEntryInfo.Quantity;
                    objclsNewOrder.OrderType = Cls.ClsGlobal.DDOrderTypes[orderEntryInfo.OrderType];
                    objclsNewOrder.Price = orderEntryInfo.Price;
                    objclsNewOrder.StopPX = orderEntryInfo.StopPrice;
                    if (uctlOrderEntry1.ui_lblOrderEntryType.Text == "BUY")
                    {
                        objclsNewOrder.Side = (sbyte) clsHashDefine.SIDE_BUY;
                    }
                    else
                    {
                        objclsNewOrder.Side = (sbyte) clsHashDefine.SIDE_SELL;
                    }
                    objclsNewOrder.Tif = Cls.ClsGlobal.DDValidity[orderEntryInfo.Validity];
                    objclsNewOrder.MinorDisclosedQty = 0; //orderEntryInfo.Client;
                    objclsNewOrder.PositionEffect = (sbyte) clsHashDefine.POSITION_OPENING_TRADE;
                    //orderEntryInfo.Client;
                    if (mode == ClsGlobal.OrderMode.NEW)
                    {
                        if (ClsTWSOrderManager.INSTANCE.SubmitNewOrder(objclsNewOrder))
                        {
                            if (Properties.Settings.Default.IsFrshOrder)
                            {
                                DialogResult result =
                                    ClsCommonMethods.ShowMessageBox(ConfirmationMessage);
                                if (result == DialogResult.Yes)
                                {
                                    //if (Properties.Settings.Default.IsCloseOrderEntryAfterSubmission)
                                        Close();
                                }
                            }
                            else
                            {
                                //if (Properties.Settings.Default.IsCloseOrderEntryAfterSubmission)
                                    Close();
                            }
                        }
                        else
                        {
                            ClsCommonMethods.ShowInfoBox("Order server not connected.Please check.");
                        }
                    }
                    else if (mode == ClsGlobal.OrderMode.MODIFY)
                    {
                        if (ClsTWSOrderManager.INSTANCE.ModifyOrder(objclsNewOrder, objclsOldOrder))
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
        }

        private void uctlOrderEntry1_OnSymbolTextChanged(string symbolName)
        {
            var lstExpiryDate = new List<string>();
            IEnumerable<string> productLst =
                ClsTWSContractManager.INSTANCE.GetProductsInfo(uctlOrderEntry1.InstrumentName,
                                                               uctlOrderEntry1.ContractName,
                                                               eSEARCH_CRITERIA.IS);

            foreach (string product in productLst)
            {
                List<string> contractLst = ClsTWSContractManager.INSTANCE.GetAllContracts(
                    uctlOrderEntry1.InstrumentName, product);
                foreach (string contract in contractLst)
                {
                    InstrumentSpec objInstrumentSpec =
                        ClsTWSContractManager.INSTANCE.GetInstrumentSpecification(uctlOrderEntry1.InstrumentName,
                                                                                  contract, product);
                    lstExpiryDate.Add(Convert.ToString(objInstrumentSpec.ExpiryDate));
                }
                uctlOrderEntry1.AddExpiryDate(lstExpiryDate);
                lstExpiryDate.Clear();
            }
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
                int cond = ((r*299) + (g*587) + (b*114))/1000;
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
                int cond = ((r*299) + (g*587) + (b*114))/1000;
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
            if (OrderType == "MMO")
            {
                uctlOrderEntry1.ui_ntxtPrice.Enabled = true;
                var MMOTypes = new List<string> {"---SELECT---", "Market Making", "Hedging"};
                uctlOrderEntry1.AddMMOTypes(MMOTypes);
            }
            else if(OrderType.ToUpper()=="MARKET")
            {
                uctlOrderEntry1.ui_ntxtPrice.Enabled = false;
                if (uctlOrderEntry1.ui_lblOrderEntryType.Text.ToUpper() == "BUY")
                {
                    double price = PALSA.Cls.ClsGlobal.GetZeroLevelAskPrice(uctlOrderEntry1.ContractName);
                    uctlOrderEntry1.Price = price != 0 ? Convert.ToString(price) : string.Empty;
                }
                else if (uctlOrderEntry1.ui_lblOrderEntryType.Text.ToUpper() == "SELL")
                {
                    double price = PALSA.Cls.ClsGlobal.GetZeroLevelBidPrice(uctlOrderEntry1.ContractName);
                    uctlOrderEntry1.Price = price != 0 ? Convert.ToString(price) : string.Empty;
                }
                    ClsTWSDataManager.INSTANCE.OnLTPChange += INSTANCE_OnLTPChange;
                uctlOrderEntry1.ClearMMOTypes();
            }
            else
            {
                uctlOrderEntry1.ui_ntxtPrice.Enabled = true;
                ClsTWSDataManager.INSTANCE.OnLTPChange -= INSTANCE_OnLTPChange;
                uctlOrderEntry1.ClearMMOTypes();
            }
        }

        #region "          PRIVATE METHODS          "

        private void SavePreferencesSettings()
        {
            //if (Properties.Settings.Default.IsRetainLastClientID)
            //{
            //    Properties.Settings.Default.LastClientID = uctlOrderEntry1.Client;
            //}
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
            string ProductName = ClsTWSContractManager.INSTANCE.GetProductNameForContract(productType, ContractName);
            InstrumentSpec instSpec=null;
            
                
                if (ProductName == string.Empty)
                {
                    message = "# Contract name not found." + Environment.NewLine;
                    return message;
                }
                else
                {
                    instSpec = ClsTWSContractManager.INSTANCE.GetInstrumentSpecification(productType, ContractName, ProductName);
                }
            if (qty == 0)
            {
                message = "# Quantity should be greater than 0." + Environment.NewLine;
            }

            if (Side == "BUY")
            {
                double submitPrice = Cls.ClsGlobal.GetZeroLevelAskPrice(ContractName) - instSpec.Limit_Stop_Level;
                switch (OrderType.ToUpper().Trim())
                {
                    case "MMO":
                    case "LIMIT":
                        if (Price == 0)
                        {
                            message = "# Price should be greater than 0 ." + Environment.NewLine;
                        }
                        else if (submitPrice != 0 && Price >= submitPrice)
                        {
                            message = "# Price should be less than " + Convert.ToString(submitPrice) + " ." +
                                      Environment.NewLine;
                        }
                        break;
                    case "STOP":
                        if (Price == 0)
                        {
                            message = "# Price should be greater than 0 ." + Environment.NewLine;
                        }
                        if (submitPrice != 0 && Price <= submitPrice)
                        {
                            message = "# Price should be greater than " + Convert.ToString(submitPrice) + " ." +
                                      Environment.NewLine;
                        }
                        break;
                    case "MARKET":
                        //if (LTP == 0)
                        //{
                            if (ProductName != string.Empty)
                            {
                                if (Cls.ClsGlobal.DDRightZLevel.Keys.Contains(ContractName))
                                {
                                    if (!(Convert.ToDouble(Cls.ClsGlobal.DDRightZLevel[ContractName]) > 0))
                                        message = "# Order is not allowed." + Environment.NewLine;
                                }
                                else
                                {
                                    message = "# Order is not allowed." + Environment.NewLine;
                                }
                            }
                        //}
                        break;
                    default:
                        break;
                }
                ;
            }
            else
            {
                double submitPrice = Cls.ClsGlobal.GetZeroLevelBidPrice(ContractName) + instSpec.Limit_Stop_Level;
                switch (OrderType.ToUpper().Trim())
                {
                    case "MMO":
                    case "LIMIT":
                        if (Price == 0)
                        {
                            message = "# Price should be greater than 0 ." + Environment.NewLine;
                        }
                        else if (submitPrice != 0 && Price <= submitPrice)
                        {
                            message = "# Price should be greater than " + Convert.ToString(submitPrice) + " ." +
                                      Environment.NewLine;
                        }
                        break;
                    case "STOP":
                        if (Price == 0)
                        {
                            message = "# Price should be greater than 0 ." + Environment.NewLine;
                        }
                        if (submitPrice != 0 && Price >= submitPrice)
                        {
                            message = "# Price should be less than " + Convert.ToString(submitPrice) + " ." +
                                      Environment.NewLine;
                        }
                        break;
                    case "MARKET":
                        //if (LTP == 0)
                        //{
                            if (ProductName != string.Empty)
                            {
                                if (Cls.ClsGlobal.DDLeftZLevel.Keys.Contains(ContractName))
                                {
                                    if (!(Convert.ToDouble(Cls.ClsGlobal.DDLeftZLevel[ContractName]) > 0))
                                        message = "# Order is not allowd." + Environment.NewLine;
                                }
                                else
                                {
                                    message = "# Order is not allowd." + Environment.NewLine;
                                }
                            }
                        //}
                        break;
                    default:
                        break;
                }
                ;
            }

            if (OrderType.ToUpper().Trim() == "STOP_LIMIT")
            {
                if (Price == 0 || trigerPrice == 0)
                {
                    message = "# Price and TrigerPrice both should be greater than 0 ." + Environment.NewLine;
                }
            }

            return message;
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
                               uctlOrderEntry1.InstrumentName = selectedRow.Cells["ClmProductType"].Value.ToString();
                               uctlOrderEntry1.AddItemToExpiry(selectedRow.Cells["ClmExpiry"].Value.ToString());
                               if(uctlOrderEntry1.ui_lblOrderEntryType.Text.ToUpper().Trim()=="SELL")
                                   uctlOrderEntry1.Price = selectedRow.Cells["ClmBuyPrice"].Value.ToString();
                               else
                                   uctlOrderEntry1.Price = selectedRow.Cells["ClmSellPrice"].Value.ToString();
                               //if (selectedRow.Cells["ClmLTP"].Value.ToString() != string.Empty)
                               //    uctlOrderEntry1.LTP = Convert.ToDouble(selectedRow.Cells["ClmLTP"].Value.ToString());
                               //else
                               //    uctlOrderEntry1.LTP = 0;
                               Symbol sym = Symbol.GetSymbol(selectedRow.Cells["ClmInstrumentId"].Value.ToString());
                               uctlOrderEntry1.GatewayName = sym._Gateway;
                               uctlOrderEntry1.ProductName = sym._ProductName;
                               //uctlOrderEntry1.Price = selectedRow.Cells["ClmPriceQuotationUnit"].Value.ToString();
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
                               uctlOrderEntry1.Key = selectedRow.Cells["ClmInstrumentId"].Value.ToString();
                               uctlOrderEntry1.ContractName = selectedRow.Cells["clmContract"].Value.ToString();
                               uctlOrderEntry1.InstrumentName = selectedRow.Cells["clmProductType"].Value.ToString();
                               uctlOrderEntry1.AddItemToExpiry(selectedRow.Cells["clmSeriesExpiry"].Value.ToString());
                               uctlOrderEntry1.Price = selectedRow.Cells["clmPrice"].Value.ToString();
                               uctlOrderEntry1.OrderType = selectedRow.Cells["clmOrderType"].Value.ToString();
                               uctlOrderEntry1.Validity = selectedRow.Cells["clmValidity"].Value.ToString();
                               
                               if (!String.IsNullOrEmpty(selectedRow.Cells["clmOrderQuantity"].Value.ToString()))
                                   uctlOrderEntry1.OrderQty =
                                       Convert.ToInt32(selectedRow.Cells["clmOrderQuantity"].Value.ToString());

                               objclsOldOrder.Account = Convert.ToUInt32(selectedRow.Cells["clmClient"].Value.ToString());
                               objclsOldOrder.ClOrderID = selectedRow.Cells["clmOrderNumber"].Value.ToString();
                               //orderEntryInfo.Client;
                               objclsOldOrder.ContractName = selectedRow.Cells["clmContract"].Value.ToString();
                               //uctlOrderEntry1.ClOrderId = selectedRow.Cells["clmOrderNumber"].Value.ToString();
                               uctlOrderEntry1.GatewayName = selectedRow.Cells["clmGateway"].Value.ToString();
                               uctlOrderEntry1.ProductName = selectedRow.Cells["clmProductName"].Value.ToString();
                               objclsOldOrder.ProductName = selectedRow.Cells["clmProductName"].Value.ToString();
                               objclsOldOrder.GatewayName = selectedRow.Cells["clmGateway"].Value.ToString();
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
                               objclsOldOrder.StrProductType = productType;
                               objclsOldOrder.SbProductType = Cls.ClsGlobal.DDProductTypes[pType];

                               objclsOldOrder.ProductName = selectedRow.Cells["clmProductName"].Value.ToString();
                               DateTime dtEX;
                               if (DateTime.TryParse(selectedRow.Cells["clmSeriesExpiry"].Value.ToString(), out dtEX))
                               {
                                   if (dtEX != null)
                                       objclsOldOrder.ExpiryDate =
                                           Convert.ToDateTime(selectedRow.Cells["clmSeriesExpiry"].Value);
                               }

                               objclsOldOrder.Qty =
                                   Convert.ToUInt32(selectedRow.Cells["clmOrderQuantity"].Value.ToString());
                               objclsOldOrder.OrderType =
                                   Cls.ClsGlobal.DDOrderTypes[selectedRow.Cells["clmOrderType"].Value.ToString()];
                               objclsOldOrder.Price = Convert.ToDouble(selectedRow.Cells["clmPrice"].Value.ToString());
                               objclsOldOrder.StopPX = 0.0; //orderEntryInfo.Client;
                               if (uctlOrderEntry1.ui_lblOrderEntryType.Text == "BUY")
                               {
                                   objclsOldOrder.Side = (sbyte) clsHashDefine.SIDE_BUY;
                               }
                               else
                               {
                                   objclsOldOrder.Side = (sbyte) clsHashDefine.SIDE_SELL;
                               }
                               objclsOldOrder.Tif =
                                   Cls.ClsGlobal.DDValidity[selectedRow.Cells["clmValidity"].Value.ToString()];
                               objclsOldOrder.MinorDisclosedQty = 0; //orderEntryInfo.Client;
                               objclsOldOrder.PositionEffect = (sbyte) clsHashDefine.EXECUTION_TYPE_NEW;
                               //orderEntryInfo.Client;
                               //uctlOrderEntry1.Price = selectedRow.Cells["ClmPriceQuotationUnit"].Value.ToString();
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
            uctlOrderEntry1.ClientName = ClsTWSOrderManager.INSTANCE._DDAccounts[Convert.ToInt32(obj)]["TraderName"].ToString();
        }






    }
}