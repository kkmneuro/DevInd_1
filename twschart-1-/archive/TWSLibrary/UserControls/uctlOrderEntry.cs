///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION	
//03/01/2012	NN		    1.Desgining of user control
//02/02/2012	VP		    1.Commenting of the code
//10/02/2012	VP		    1.Define properties for controls
//24/02/2012    VP          1.Create dialog to change the background color for buy and sell OrderEntry form
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CommonLibrary.Cls;
using Nevron.UI.WinForm.Controls;

namespace CommonLibrary.UserControls
{
    public partial class UctlOrderEntry : UctlBase
    {
        #region    "        MEMBERS           "

        private Color _buyBgColor = Color.Green;
        private Color _sellBgColor = Color.Blue;
        private string _title = "Order Entry";

        public double LTP { get; set; }

        #endregion "        MEMBERS           "

        #region    "        PROPERTY          "

        private ClsGlobal.OrderMode _mode = ClsGlobal.OrderMode.NEW;

        /// <summary>
        /// Sets and gets the title of the order entry control
        /// </summary>
        public override string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public new string ProductName { get; set; }
        public string GatewayName { get; set; }

        public string AccountNo
        {
            get { return ui_ncmbAccountNos.Text; }
            set
            {
                if (ui_ncmbAccountNos.Items.Contains(value))
                    ui_ncmbAccountNos.SelectedIndex = ui_ncmbAccountNos.Items.IndexOf(value);
            }
        }

        public string Caption
        {
            get { return ui_lblOrderEntryType.Text; }
            set { ui_lblOrderEntryType.Text = value; }
        }

        /// <summary>
        /// This property sets and gets the Instrument name of the order entry control
        /// </summary>
        public string InstrumentName
        {
            get { return ui_ncmbInstrumentName.SelectedItem.ToString(); }
            set {
                if (ui_ncmbInstrumentName.Items.IndexOf(value) != -1)
                    ui_ncmbInstrumentName.SelectedItem = ui_ncmbInstrumentName.Items[ui_ncmbInstrumentName.Items.IndexOf(value)];
                else
                    ui_ncmbInstrumentName.SelectedItem = value;
            }
        }



        /// <summary>
        /// This property sets and gets the Expiry Time
        /// </summary>
        public string ExpiryDate
        {
            get { return ui_ncmbExpiryDate.Text; }
            set { ui_ncmbExpiryDate.Text = value; }
        }

        private string _key = string.Empty;
        public string Key
        {
            get { return _key; }
            set { _key = value; }
        }
        public ClsGlobal.OrderMode Mode
        {
            get { return _mode; }
            set
            {
                if (value == ClsGlobal.OrderMode.MODIFY)
                {
                    ui_ncmbAccountNos.Enabled = false;
                    //ui_ntxtClient.Enabled = false;
                    ui_ntxtClientName.Enabled = false;
                    ui_ntxtDQty.Enabled = false;
                    ui_ntxtSymbol.Enabled = false;
                    ui_ntxtUserRemark.Enabled = false;
                    ui_ncmbAccType.Enabled = false;
                    ui_ncmbExpiryDate.Enabled = false;
                    ui_ncmbInstrumentName.Enabled = false;
                    ui_ncmbOptType.Enabled = false;
                    ui_ncmbOrderType.Enabled = false;
                    ui_ntxtPartOminiId.Enabled = false;
                    ui_ncmbSeries.Enabled = false;
                    ui_ncmbStrikePrice.Enabled = false;
                    ui_ncmbValidity.Enabled = false;
                    nComboBox10.Enabled = false;
                    ui_nbtnClear.Enabled = false;
                }
                else
                {
                    ui_ncmbAccountNos.Enabled = true;
                    //ui_ntxtClient.Enabled = true;
                    ui_ntxtClientName.Enabled = true;
                    ui_ntxtDQty.Enabled = true;
                    ui_ntxtSymbol.Enabled = true;
                    ui_ntxtUserRemark.Enabled = true;
                    ui_ncmbAccType.Enabled = true;
                    ui_ncmbExpiryDate.Enabled = true;
                    ui_ncmbInstrumentName.Enabled = true;
                    ui_ncmbOptType.Enabled = true;
                    ui_ncmbOrderType.Enabled = true;
                    ui_ntxtPartOminiId.Enabled = true;
                    ui_ncmbSeries.Enabled = true;
                    ui_ncmbStrikePrice.Enabled = true;
                    ui_ncmbValidity.Enabled = true;
                    nComboBox10.Enabled = true;
                    ui_nbtnClear.Enabled = true;
                }
                _mode = value;
            }
        }

        /// <summary>
        /// This property sets and gets the order type
        /// </summary>
        public string OrderType
        {
            get
            {
                if (ui_ncmbOrderType.SelectedItem != null)
                {
                    return ui_ncmbOrderType.SelectedItem.ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                if (ui_ncmbOrderType.Items.Contains(value))
                    ui_ncmbOrderType.SelectedIndex = ui_ncmbOrderType.Items.IndexOf(value);
            }
        }

        public int OrderQty
        {
            get
            {
                if (!string.IsNullOrEmpty(ui_nNUpDown.Value.ToString()))
                    return Convert.ToInt32(ui_nNUpDown.Value);
                else
                    return 0;
            }
            set { ui_nNUpDown.Value =value; }
        }

        /// <summary>
        /// This property sets and gets the option type
        /// </summary>
        //public string OptionType
        //{
        //    get
        //    {
        //        return ui_ncmbOptType.SelectedItem.ToString();
        //    }
        //    set
        //    {
        //        ui_ncmbOptType.SelectedItem = value;
        //    }
        //}
        /// <summary>
        /// Name of the symbol. If the name is invalid, no order is placed, and it displays invalid symbol.
        /// If symbol is valid then price, expired date is also populated.
        /// </summary>
        public string ContractName
        {
            get { return ui_ntxtSymbol.Text; }
            set { ui_ntxtSymbol.Text = value; }
        }

        /// <summary>
        /// This property sets and gets the text of series comboBox(ui_ncmbSeries )
        /// </summary>
        //public string Series
        //{
        //    get
        //    {
        //        return ui_ncmbSeries.SelectedItem.ToString();
        //    }
        //    set
        //    {
        //        ui_ncmbSeries.SelectedItem = value;
        //    }
        //}
        /// <summary>
        /// This property sets and gets the text of Strike Price comboBox(ui_ncmbStrikePrice )
        /// </summary>
        //public string StrikePrice
        //{
        //    get
        //    {
        //        return ui_ncmbStrikePrice.SelectedItem.ToString();
        //    }
        //    set
        //    {
        //        ui_ncmbStrikePrice.SelectedItem = value;
        //    }
        //}
        /// <summary>
        /// This property sets and gets the text of quantity comboBox(ui_Qty )
        /// </summary>
        public int Quantity
        {
            get { return Convert.ToInt32(ui_nNUpDown.Value); }
            set { ui_nNUpDown.Value = Convert.ToInt32(value); }
        }

        /// <summary>
        /// The label for price shows the price quotation unit as in the image above.
        /// This field is enabled for the modification order.
        /// </summary>
        public string Price
        {
            get { return ui_ntxtPrice.Text; }
            set { ui_ntxtPrice.Text = value; }
        }

        /// <summary>
        /// This property sets and gets the text of DQty comboBox(ui_ncmbDQty )
        /// </summary>
        public bool DQuantity
        {
            get { return ui_ntxtDQty.Enabled; }
            set { ui_ntxtDQty.Enabled = value; }
        }

        /// <summary>
        ///This option is only available to brokers and disabled for individual traders.
        /// </summary>
        public string AccountType
        {
            get
            {
                if (ui_ncmbAccType.SelectedItem != null)
                {
                    return ui_ncmbAccType.SelectedItem.ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                if (ui_ncmbAccType.Items.Contains(value))
                    ui_ncmbAccType.SelectedIndex = ui_ncmbAccType.Items.IndexOf(value);
            }
        }

        /// <summary>
        /// Enabled only when Acc type is Client. Name of the client for which order is being placed.
        /// </summary>
        public string ClientName
        {
            get { return ui_ntxtClientName.Text; }
            set { ui_ntxtClientName.Text = value; }
        }

        /// <summary>
        ///  Enabled only when Acc type is Client. Name of the client for which order is being placed.
        /// </summary>
        //public string Client
        //{
        //    get { return ui_ntxtClient.Text; }
        //    set { ui_ntxtClient.Text = value; }
        //}

        /// <summary>
        ///  This property sets and gets the text of Part. ID/Omini ID comboBox(ui_ncmbPartOminiId)
        /// </summary>
        public string PartnerOminiId
        {
            get { return ui_ntxtPartOminiId.Text; }
            set { ui_ntxtPartOminiId.Text = value; }
        }

        /// <summary>
        /// This property sets and gets the text of Trig. Price comboBox(ui_ncmbTrigPrice)
        /// </summary>
        public string TrigPrice
        {
            get { return ui_ntxtTrigPrice.Text; }
            set { ui_ntxtTrigPrice.Text = value; }
        }

        /// <summary>
        /// This property sets and gets the text of User Remark comboBox(ui_ncmbUserRemark)
        /// </summary>
        //public string UserRemark
        //{
        //    get
        //    {
        //        return ui_ntxtUserRemark.Text;
        //    }
        //    set
        //    {
        //        ui_ntxtUserRemark.Text = value;
        //    }
        //}
        /// <summary>
        /// This property sets and gets background color for buy order.
        /// </summary>
        public Color BuyBgColor
        {
            get { return _buyBgColor; }
            set { _buyBgColor = value; }
        }

        /// <summary>
        /// This property sets and gets background color for Sell order.
        /// </summary>
        public Color SellBgColor
        {
            get { return _sellBgColor; }
            set { _sellBgColor = value; }
        }

        /// <summary>
        /// This property sets and gets Font style.
        /// </summary>
        public string FontStyle { get; set; }

        /// <summary>
        ///  This property sets and gets Font size.
        /// </summary>
        public int FontSize { get; set; }

        /// <summary>
        /// Open window is used either last used layout or not.
        /// </summary>
        public bool IsLastSavedLayout { get; set; }

        /// <summary>
        /// Open window is used either default layout or not
        /// </summary>
        public bool IsDefaultLayout { get; set; }

        /// <summary>
        /// Open window should have either title bar or not
        /// </summary>
        public bool IsTitleBar { get; set; }

        /// <summary>
        /// Open window should have either status bar or not.
        /// </summary>
        public bool IsStatusBar { get; set; }

        /// <summary>
        /// Open window should have either label on or not.
        /// </summary>
        public bool IsLabelOn { get; set; }

        /// <summary>
        /// This property sets and gets the text of Validity comboBox(ui_ncmbValidity)
        /// </summary>
        public string Validity
        {
            get { return ui_ncmbValidity.SelectedItem.ToString(); }
            set { ui_ncmbValidity.SelectedItem = value; }
        }

        public bool ClientNameEnable
        {
            set { ui_ntxtClientName.Enabled = value; }
        }

        public void AddItemToExpiry(string str)
        {
            ui_ncmbExpiryDate.Items.Clear();
            ui_ncmbExpiryDate.Items.Add(str);
            ui_ncmbExpiryDate.SelectedIndex = 0;
        }

        #endregion    "        PROPERTY          "

        #region "        CONSTRUCTOR       "

        /// <summary>
        /// Constructor for initializing the components of the uctlOrderEntry 
        /// </summary>
        /// <param name="obj"></param>
        public UctlOrderEntry()
        {
            InitializeComponent();

            ui_ncmbAccType.SelectedIndex = 0;
            ////ui_ncmbExpiryDate.SelectedIndex = 0;
            ui_ncmbInstrumentName.SelectedIndex = 0;
            //ui_ncmbOptType.SelectedIndex = 0;
            //ui_ncmbOrderType.SelectedIndex = 0;
            //ui_ncmbSeries.SelectedIndex = 0;
            //ui_ncmbStrikePrice.SelectedIndex = 0;
            ui_ncmbValidity.SelectedIndex = 0;
        }

        /// <summary>
        /// Constructor for initializing the components of the uctlOrderEntry with customized settings
        /// </summary>
        /// <param name="customizeSettings"></param>
        public UctlOrderEntry(object customizeSettings)
        {
        }

        #endregion "       CONSTRUCTOR        "

        #region  "          METHODS         "

        /// <summary>
        /// Sets the text of controls corresponding to localized value
        /// </summary>
        public override void SetLocalization()
        {
            Title = ClsLocalizationHandler.Order + " " + ClsLocalizationHandler.Entry;
            ui_lblOrderEntryType.Text = ClsLocalizationHandler.Buy;
            ui_lblProductType.Text = ClsLocalizationHandler.Instrument + " " + ClsLocalizationHandler.Name;
            ui_lblOrderType.Text = ClsLocalizationHandler.Order + " " + ClsLocalizationHandler.Type;
            ui_lblContractName.Text = ClsLocalizationHandler.Symbol;
            ui_lblSeries.Text = ClsLocalizationHandler.Series;
            ui_lblExpiryDate.Text = ClsLocalizationHandler.Expiry + " " + ClsLocalizationHandler.Date;
            ui_lblStrikePrice.Text = ClsLocalizationHandler.Strike + " " + ClsLocalizationHandler.Price;
            ui_lblOptType.Text = ClsLocalizationHandler.Option + " " + ClsLocalizationHandler.Type;
            ui_lblQty.Text = ClsLocalizationHandler.Quantity;
            ui_lblPrice.Text = ClsLocalizationHandler.Price + "(10GRMS)";
            ui_lblAccType.Text = ClsLocalizationHandler.Account + " " + ClsLocalizationHandler.Type;
            ui_lblClientName.Text = ClsLocalizationHandler.Client + " " + ClsLocalizationHandler.Name;
            //ui_lblClient.Text = ClsLocalizationHandler.Client;
            ui_lblValidity.Text = ClsLocalizationHandler.Validity;
            ui_lblUserRemark.Text = ClsLocalizationHandler.User + " " + ClsLocalizationHandler.Remarks;
            ui_nbtnSubmit.Text = ClsLocalizationHandler.Submit;
            ui_nbtnClear.Text = ClsLocalizationHandler.Clear;
        }

        /// <summary>
        /// this method adds nevron contex menu to the Order Entry control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_nPanelOrderEntry_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var pt = new Point(Cursor.Position.X, Cursor.Position.Y);

                ui_ncmnuOrderEntry.Show(ui_npnlOrderEntry, pt);
            }
        }

        /// <summary>
        /// Removes all controls values 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_nbtnClear_Click(object sender, EventArgs e)
        {
            //ui_ntxtClient.Text = "";
            ui_ntxtClientName.Text = "";
            ui_ntxtDQty.Text = "";
            ui_ntxtPrice.Text = "";
            ui_nNUpDown.Value = 1;
            ui_ntxtSymbol.Text = "";
            ui_ntxtTrigPrice.Text = "";
            ui_ntxtUserRemark.Text = "";
            ui_ncmbAccType.SelectedItem = null;
            ui_ncmbExpiryDate.SelectedItem = null;
            ui_ncmbInstrumentName.SelectedItem = null;
            ui_ncmbOptType.SelectedItem = null;
            ui_ncmbOrderType.SelectedItem = null;
            ui_ntxtPartOminiId.Text = "";
            ui_ncmbSeries.SelectedItem = null;
            ui_ncmbStrikePrice.SelectedItem = null;
            ui_ncmbValidity.SelectedItem = null;
            nComboBox10.SelectedItem = null;
        }

        #endregion  "          METHODS         "

        public List<string> OrderTypesToEnableTrigerPrice = new List<string>();

        /// <summary>
        /// Invokes OnSubmitClick click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_nbtnSubmit_Click(object sender, EventArgs e)
        {
            var objclsOrderEntryInfo = new ClsOrderEntryInfo();

            if (ui_ncmbInstrumentName.SelectedItem == null || ui_ncmbInstrumentName.Text == "---SELECT---")
            {
                ClsCommonMethods.ShowErrorBox("ProductType can't be null");
                return;
            }

            if (ui_ntxtSymbol.Text == string.Empty || ui_ntxtSymbol.Text == "---SELECT---")
            {
                ClsCommonMethods.ShowErrorBox("Contract can't be null");
                return;
            }

            if (ui_ncmbOrderType.SelectedItem == null || ui_ncmbOrderType.Text == "---SELECT---")
            {
                ClsCommonMethods.ShowErrorBox("OrderType can't be null");
                return;
            }

            if (ui_ncmbMMOType.Enabled && (ui_ncmbMMOType.SelectedItem != null && ui_ncmbMMOType.Text == "---SELECT---"))
            {
                ClsCommonMethods.ShowErrorBox("Please select correct MMO Type.");
                return;
            }

            if (ui_nNUpDown.Value == 0)
            {
                ClsCommonMethods.ShowErrorBox("Quantity can't be zero.");
                return;
            }

            if (ui_ntxtPrice.Text == string.Empty)
            {
                ClsCommonMethods.ShowErrorBox("Price can't be null");
                return;
            }

            if (ui_ncmbAccType.SelectedItem == null || ui_ncmbAccType.Text == "---SELECT---")
            {
                ClsCommonMethods.ShowErrorBox("AccountType can't be null");
                return;
            }

            if (ui_ncmbValidity.SelectedItem == null || ui_ncmbValidity.Text == "---SELECT---")
            {
                ClsCommonMethods.ShowErrorBox("Validity can't be null");
                return;
            }

            objclsOrderEntryInfo.Side = Caption;
            //if (ui_ncmbOrderType.SelectedItem != null)
            objclsOrderEntryInfo.OrderType = ui_ncmbOrderType.SelectedItem.ToString().Trim();
            //if (ui_ncmbInstrumentName.SelectedItem != null)
            objclsOrderEntryInfo.ProductType = ui_ncmbInstrumentName.SelectedItem.ToString().Trim();
            //if (ui_ncmbAccType.SelectedItem != null)
            objclsOrderEntryInfo.AccountType = ui_ncmbAccType.SelectedItem.ToString().Trim();
            //if (ui_ncmbValidity.SelectedItem != null)
            objclsOrderEntryInfo.Validity = ui_ncmbValidity.SelectedItem.ToString().Trim();
            objclsOrderEntryInfo.Symbol = ui_ntxtSymbol.Text.Trim();
            objclsOrderEntryInfo.ExpiryDate = ui_ncmbExpiryDate.Text;
            int ordQty=0;
            double ordPrice = 0;
            if (ui_nNUpDown.Value == 0)
            {
                objclsOrderEntryInfo.Quantity = 0;
            }
            else if (Int32.TryParse(Convert.ToString(ui_nNUpDown.Value), out ordQty))
            {
                objclsOrderEntryInfo.Quantity = ordQty;
            }
            else
            {
                MessageBox.Show("Quantity should be numeric value.");
                ui_nNUpDown.Focus();
                return;
            }
            if (ui_ntxtPrice.Text == string.Empty)
            {
                objclsOrderEntryInfo.Price = 0;
            }
            else if (double.TryParse(ui_ntxtPrice.Text, out ordPrice))
            {
                objclsOrderEntryInfo.Price = ordPrice;
            }
            else
            {
                MessageBox.Show("Price should be numeric or decimal value.");
                ui_ntxtPrice.Text = string.Empty;
                ui_ntxtPrice.Focus();
                return;
            }
            objclsOrderEntryInfo.ProductName =this.ProductName;
            objclsOrderEntryInfo.GatewayName = this.GatewayName;
            objclsOrderEntryInfo.ClientName = ui_ntxtClientName.Text;
            objclsOrderEntryInfo.Client = string.Empty;
            objclsOrderEntryInfo.UserRemark = ui_ntxtUserRemark.Text;
            if (ui_ntxtTrigPrice.Text == string.Empty)
            {
                objclsOrderEntryInfo.StopPrice = 0;
            }
            else
            {
                objclsOrderEntryInfo.StopPrice = Convert.ToDouble(ui_ntxtTrigPrice.Text);
            }
            if (!ValidateInfo(objclsOrderEntryInfo))
            {
                ClsCommonMethods.ShowErrorBox("Incorrect Data");
            }
            else
            {
                OnSubmitClick(objclsOrderEntryInfo, Mode);
            }
        }

        private bool ValidateInfo(ClsOrderEntryInfo objclsOrderEntryInfo)
        {
            bool flag;
            flag = validateStr(objclsOrderEntryInfo.ProductType);
            flag = validateStr(objclsOrderEntryInfo.OrderType);
            flag = validateStr(objclsOrderEntryInfo.Symbol);
            //flag = validateStr(objclsOrderEntryInfo.ExpiryDate);
            flag = ValidateInt(objclsOrderEntryInfo.Price);
            flag = ValidateInt(objclsOrderEntryInfo.Quantity);
            flag = validateStr(objclsOrderEntryInfo.AccountType);
            flag = validateStr(objclsOrderEntryInfo.Validity);
            return flag;
        }

        private bool ValidateInt(double value)
        {
            bool flg = true;
            if (value == 0.0)
                flg = false;
            return flg;
        }

        private bool validateStr(string str)
        {
            bool flg = true;
            if (str == string.Empty || str == "---SELECT---")
            {
                flg = false;
            }
            return flg;
        }

        /// <summary>
        /// Tasks performed on the control load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uctlOrderEntry_Load(object sender, EventArgs e)
        {

            
        }


        public void GetOrderEntryInformation()
        {
        }

        public void SetOrderEntryInformation()
        {
        }

        public void AddInstruments(List<string> lst)
        {
            ui_ncmbInstrumentName.Items.AddRange(lst.ToArray());
            ui_ncmbInstrumentName.SetItemsAsAutoCompleteSource();
        }
        public void AddAccountNos(int[] lst)
        {
            foreach (int item in lst)
            {
                ui_ncmbAccountNos.Items.Add(Convert.ToString(item));
            }
            ui_ncmbAccountNos.SetItemsAsAutoCompleteSource();
        }
        public void AddAccountNos(string[] lst)
        {
            ui_ncmbAccountNos.Items.AddRange(lst);
            ui_ncmbAccountNos.SetItemsAsAutoCompleteSource();
        }

        public void AddMMOTypes(List<string> lst)
        {
            ui_ncmbMMOType.Items.Clear();
            ui_ncmbMMOType.Items.Clear();
            ui_ncmbMMOType.Items.AddRange(lst.ToArray());
            ui_ncmbMMOType.Enabled = true;
            ui_ncmbMMOType.SelectedIndex = 0;
        }

        public void ClearMMOTypes()
        {
            ui_ncmbMMOType.Items.Clear();
            ui_ncmbMMOType.Enabled = false;
        }

        public void AddExpiryDate(List<string> lst)
        {
            ui_ncmbExpiryDate.Items.Clear();
            ui_ncmbExpiryDate.Items.AddRange(lst.ToArray());
        }

        private void ui_ntxtSymbol_TextChanged(object sender, EventArgs e)
        {
            OnSymbolTextChanged(((TextBox) (sender)).Text);
        }

        public event Action<string> OnSymbolTextChanged;

        private void ui_ntxtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsDigit(e.KeyChar) || e.KeyChar == '\b') && ui_ntxtQty.Text.Length < 4)
            {
                e.Handled = false;
            }
            else
            {
                if (e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            //else
            //    Cls.clsGlobal.KeyPressHandler(ui_ntxtQty.Text, e, Cls.TextType.Numeric,3,0);
        }

        private void ui_ntxtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.' && e.KeyChar != '-')
            {
                e.Handled = true;
            }
            else
            {
                ClsGlobal.KeyPressHandler(ui_ntxtPrice.Text, e, TextType.Real, 20, 7);
            }
        }

        private void ui_ntxtDQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsDigit(e.KeyChar) && e.KeyChar != '\b') || e.KeyChar != '-' || e.KeyChar != '0')
            {
                e.Handled = true;
            }
        }

        private void ui_ncmnuOrderEntry_CommandClick(object sender, CommandEventArgs e)
        {
            var objfrmDialogForm = new frmDialogForm();
            objfrmDialogForm.Controls.Clear();
            var objuctlOrderEntryCustomize = new UctlOrderEntryCustomize();
            objuctlOrderEntryCustomize.BuyColor = BuyBgColor;
            objuctlOrderEntryCustomize.SellColor = SellBgColor;
            objfrmDialogForm.Controls.Add(objuctlOrderEntryCustomize);
            var objSize = new Size(objuctlOrderEntryCustomize.Width + 8, objuctlOrderEntryCustomize.Height + 28);
            objfrmDialogForm.Size = objSize;
            objfrmDialogForm.Text = "Customize";
            objuctlOrderEntryCustomize.OnOkClick += objuctlOrderEntryCustomize_OnOkClick;
            objfrmDialogForm.Location = new Point(MousePosition.X, MousePosition.Y);
            objfrmDialogForm.TopMost = false;
            objfrmDialogForm.ShowDialog();
        }

        private void objuctlOrderEntryCustomize_OnOkClick(Color buyColor, Color sellColor)
        {
            BuyBgColor = buyColor;
            SellBgColor = sellColor;
            OnBuySellColorChanged(BuyBgColor, SellBgColor);
        }


        //public void SetQuantity(double Qty)
        //{
        //    Action A = () =>
        //                   {
        //                       //ui_ntxtQty.Text = "";
        //                       //ui_ntxtQty.Text = Qty.ToString();
        //                       ui_nNUpDown.Value = Convert.ToDecimal(Qty);
        //                   };
        //    if (InvokeRequired)
        //    {
        //        BeginInvoke(A);
        //    }
        //    else
        //    {
        //        A();
        //    }
        //}

        public event Action<Color, Color> OnBuySellColorChanged;

        public void AddOrderTypes(string[] ordertypes)
        {
            ui_ncmbOrderType.Items.AddRange(ordertypes);
            //ui_ncmbOrderType.Items.RemoveAt(ui_ncmbOrderType.Items.Count - 1);
        }

        public void AddItemsToValidity(string[] validityType)
        {
            ui_ncmbValidity.Items.AddRange(validityType);
        }

        private void ui_ncmbInstrumentName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ui_ncmbInstrumentName.SelectedItem != null)
                OnProductTypeChanged(ui_ncmbInstrumentName.SelectedItem.ToString());
        }

        public event Action<string> OnProductTypeChanged = delegate { };
        public event Action<string> OnOrderTypeChanged = delegate { };
        public event Action<string> OnAccountNoChanged = delegate { };

        private void ui_ncmbOrderType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ui_ncmbOrderType.SelectedItem != null)
            {
                if (OrderTypesToEnableTrigerPrice.Contains(ui_ncmbOrderType.SelectedItem.ToString()))
                {
                    ui_ntxtTrigPrice.Enabled = true;
                }
                else
                {
                    ui_ntxtTrigPrice.Enabled = false;
                }
                OnOrderTypeChanged(ui_ncmbOrderType.SelectedItem.ToString());
            }
        }

        private void ui_ntxtTrigPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.' && e.KeyChar != '-')
            {
                e.Handled = true;
            }
            else
                ClsGlobal.KeyPressHandler(ui_ntxtTrigPrice.Text, e, TextType.Real, 20, 7);
        }

        #region    "      EVENTS        "

        public event Action<ClsOrderEntryInfo, ClsGlobal.OrderMode> OnSubmitClick = delegate { };

        #endregion "      EVENTS        "

        private void ui_ncmbAccountNos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ui_ncmbAccountNos.SelectedItem != null)
            OnAccountNoChanged(ui_ncmbAccountNos.SelectedItem.ToString());
        }

        private void ui_ntxtClientName_TextChanged(object sender, EventArgs e)
        {

        }
        public new Action<object, System.ComponentModel.CancelEventArgs> OnValidating = delegate { };
        private void ui_ncmbAccountNos_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            OnValidating(sender,e);
        }







        //public string ClOrderId { get; set; }
    }


    
}