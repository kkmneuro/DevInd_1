///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION	
//02/01/2012	VP		    1.Added comment to properties and methods
//02/02/2012	VP		    1.Commenting of the code
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using CommonLibrary.Cls;

namespace CommonLibrary.UserControls
{
    /// <summary>
    /// Code for uctlFilter control
    /// </summary>
    public partial class UctlFilter : UctlBase
    {
        #region    "      MEMBERS       "

        private List<string> _instrumentName;
        private string _orderType;
        private string _productAsset;
        private string _title = "Filter";

        #endregion "      MEMBERS       "

        #region    "      PROPERTY      "

        /// <summary>
        /// Sets and gets the title of the Filter control
        /// </summary>
        public override string Title
        {
            get { return _title; }
            set { _title = value; }
        }


        /// <summary>
        /// This property sets and gets Name of the Instruments. It is both gettable and settable.
        /// </summary>
        public List<string> InstrumentName
        {
            get { return _instrumentName; }
            set { _instrumentName = value; }
        }

        /// <summary>
        /// This property sets and gets the type of order to be used (BUY, SELL, BUY&SELL). It is both gettable and settable.
        /// </summary>
        public string OrderType
        {
            get { return _orderType; }
            set { _orderType = value; }
        }

        /// <summary>
        /// This property sets and gets Selected value of product and Asset options. It is both gettable and settable.
        /// </summary>
        public string ProductAsset
        {
            get { return _productAsset; }
            set { _productAsset = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Symbol
        {
            get { return ui_ncmbSymbol.SelectedItem.ToString(); }
            set { ui_ncmbSymbol.SelectedItem = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Series
        {
            get { return ui_ncmbSeries.SelectedItem.ToString(); }
            set { ui_ncmbSeries.SelectedItem = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string ExpiryDate
        {
            get { return ui_ncmbExpiryDate.SelectedItem.ToString(); }
            set { ui_ncmbExpiryDate.SelectedItem = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string StrikePrice
        {
            get { return ui_ncmbStrikePrice.SelectedItem.ToString(); }
            set { ui_ncmbStrikePrice.SelectedItem = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string OptionType
        {
            get { return ui_ncmbOptType.SelectedItem.ToString(); }
            set { ui_ncmbOptType.SelectedItem = value; }
        }

        /// <summary>
        /// This property sets and gets Account Type. It is both gettable and settable.
        /// </summary>
        public string AccountType
        {
            get { return ui_ncmbAccountType.SelectedItem.ToString(); }
            set { ui_ncmbAccountType.SelectedItem = value; }
        }

        /// <summary>
        /// This property gets and gets the Name of the client. It is both gettable and settable.
        /// </summary>
        public string ClientName
        {
            get { return ui_ntxtClientName.Text; }
            set { ui_ntxtClientName.Text = value; }
        }

        /// <summary>
        /// This property gets and gets the client Id. It is both gettable and settable.
        /// </summary>
        public string Client
        {
            get { return ui_ntxtClient.Text; }
            set { ui_ntxtClient.Text = value; }
        }

        /// <summary>
        /// This property sets and gets the Partner Id .It is both gettable and settable.
        /// </summary>
        public string PartnerId
        {
            get { return ui_ncmbPartId.SelectedItem.ToString(); }
            set { ui_ncmbPartId.SelectedItem = value; }
        }

        /// <summary>
        /// This property sets and gets the Order No. It is both gettable and settable.
        /// </summary>
        public string OrderNo
        {
            get { return ui_ntxtOrdeNo.Text; }
            set { ui_ntxtOrdeNo.Text = value; }
        }

        /// <summary>
        /// This property sets and gets the Reference No. It is both gettable and settable.
        /// </summary>
        public string ReferenceNo
        {
            get { return ui_ntxtReferenceNo.Text; }
            set { ui_ntxtReferenceNo.Text = value; }
        }

        /// <summary>
        /// This property sets and gets the start value for filtering. It is both gettable and settable.
        /// </summary>
        public string TimeRangeFrom
        {
            get { return ui_ndtpFrom.Text; }
            set { ui_ndtpFrom.Text = value; }
        }

        /// <summary>
        /// This property sets and gets the end value for filtering. It is both gettable and settable.
        /// </summary>
        public string TimeRangeTo
        {
            get { return ui_ndtpTo.Text; }
            set { ui_ndtpTo.Text = value; }
        }

        /// <summary>
        /// This property sets and gets the Selected value of SpreadIOC. It is both gettable and settable.
        /// </summary>
        public string SpreadIOC
        {
            get { return ui_ncmbSpreadIOC.SelectedItem.ToString(); }
            set { ui_ncmbSpreadIOC.SelectedItem = value; }
        }

        /// <summary>
        /// This property sets and gets Selected currency code . It is both gettable and settable.
        /// </summary>
        public string CurrencyCode
        {
            get { return ui_ncmbCurrencyCode.SelectedItem.ToString(); }
            set { ui_ncmbCurrencyCode.SelectedItem = value; }
        }

        #endregion "      PROPERTY      "

        #region "     CONSTRUCTOR    "

        /// <summary>
        /// Constructor for initilizing the components of the uctlFilter 
        /// </summary>
        public UctlFilter()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor for initilizing the components of the uctlFilter with customised settings
        /// </summary>
        /// <param name="customizeSettings"></param>
        public UctlFilter(object customizeSettings)
        {
        }

        #endregion "          CONSTRUCTOR            "

        #region    "      METHODS       "

        /// <summary>
        /// Sets the text value of the controls corresponding to localization value
        /// </summary>
        public override void SetLocalization()
        {
            Title = ClsLocalizationHandler.Filter;

            ui_ngbeInstrumentName.HeaderItem.Text = ClsLocalizationHandler.Instrument + " " +
                                                    ClsLocalizationHandler.Name;
            ui_ngbeProduct.HeaderItem.Text = ClsLocalizationHandler.Product + "U/L " +
                                             ClsLocalizationHandler.Asset;
            ui_nrbProductAll.Text = ClsLocalizationHandler.All;
            ui_nrbProduct.Text = ClsLocalizationHandler.Product;
            ui_nrbULAsset.Text = "U/L " + ClsLocalizationHandler.Asset;
            ui_nrbULProduct.Text = "U/L " + ClsLocalizationHandler.Product;
            ui_lblSymbol.Text = ClsLocalizationHandler.Symbol;
            ui_lblSeries.Text = ClsLocalizationHandler.Series;
            ui_lblEpiryDate.Text = ClsLocalizationHandler.Expiry + " " + ClsLocalizationHandler.Date;
            ui_lblStrikePrice.Text = ClsLocalizationHandler.Strike + " " + ClsLocalizationHandler.Price;
            ui_lblOptType.Text = ClsLocalizationHandler.Option + " " + ClsLocalizationHandler.Type;
            ui_ngbeBuySell.HeaderItem.Text = ClsLocalizationHandler.Buy + "/" + ClsLocalizationHandler.Sell;
            ui_nrbBuy.Text = ClsLocalizationHandler.Buy;
            ui_nrbSell.Text = ClsLocalizationHandler.Sell;
            ui_nrbBoth.Text = ClsLocalizationHandler.Both;
            ui_ngbeAccountType.HeaderItem.Text = ClsLocalizationHandler.Account + " " +
                                                 ClsLocalizationHandler.Type;
            ui_lblAccountType.Text = ClsLocalizationHandler.Account + " " + ClsLocalizationHandler.Type;
            ui_lblClientName.Text = ClsLocalizationHandler.Client + " " + ClsLocalizationHandler.Name;
            ui_lblClient.Text = ClsLocalizationHandler.Client;
            ui_lblPartID.Text = "Part." + ClsLocalizationHandler.Id;
            ui_ngbeOther.HeaderItem.Text = ClsLocalizationHandler.Other;
            ui_nchkOrderNo.Text = ClsLocalizationHandler.Order + " " + ClsLocalizationHandler.Number;
            ui_nchkReferenceNo.Text = ClsLocalizationHandler.Reference + " " + ClsLocalizationHandler.Number;
            ui_ngbeTimeRange.HeaderItem.Text = ClsLocalizationHandler.Time + " " + ClsLocalizationHandler.Range;
            ui_lblFrom.Text = ClsLocalizationHandler.From;
            ui_lblTo.Text = ClsLocalizationHandler.To;
            ui_ngbeTradingCurrrency.HeaderItem.Text = ClsLocalizationHandler.Trading + " " +
                                                      ClsLocalizationHandler.Currency;
            ui_lblCurrencyCode.Text = ClsLocalizationHandler.Currency + " " + ClsLocalizationHandler.Code;
            ui_nbtnApply.Text = ClsLocalizationHandler.Apply;
            ui_nbtnCancel.Text = ClsLocalizationHandler.Cancel;
        }

        /// <summary>
        /// Used to set the value of the properties InstrumentName, ProductAsset and OrderType.
        /// </summary>
        public void SetControlProperties()
        {
            var instrumentName = new List<string>();

            if (ui_nrbBuy.Checked)
                _orderType = ui_nrbBuy.Text;
            if (ui_nrbSell.Checked)
                _orderType = ui_nrbSell.Text;
            if (ui_nrbBoth.Checked)
                _orderType = ui_nrbBoth.Text;

            if (ui_nrbProductAll.Checked)
                _productAsset = ui_nrbProductAll.Text;
            if (ui_nrbProduct.Checked)
                _productAsset = ui_nrbProduct.Text;
            if (ui_nrbULAsset.Checked)
                _productAsset = ui_nrbULAsset.Text;
            if (ui_nrbULProduct.Checked)
                _productAsset = ui_nrbULProduct.Text;

            if (ui_nchkAll.Checked)
                instrumentName.Add(ui_nchkAll.Text);
            if (ui_nchkAUCBI.Checked)
                instrumentName.Add(ui_nchkAUCBI.Text);
            if (ui_nchkAUCSO.Checked)
                instrumentName.Add(ui_nchkAUCSO.Text);
            if (ui_nchkAUCTBI.Checked)
                instrumentName.Add(ui_nchkAUCTBI.Text);
            if (ui_nchkAUCTSO.Checked)
                instrumentName.Add(ui_nchkAUCTSO.Text);
            if (ui_nchkFUTCOM.Checked)
                instrumentName.Add(ui_nchkFUTCOM.Text);

            _instrumentName = instrumentName;
        }

        private void uctlFilter_Load(object sender, EventArgs e)
        {
            //SetLocalization();
        }

        /// <summary>
        /// Called on Cancel button click to close the Filter dialog box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_nbtnCancel_Click(object sender, EventArgs e)
        {
            OnCancelClick(sender, e);
        }

        /// <summary>
        /// Called on apply button click to filter the information according to filter control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_nbtnApply_Click(object sender, EventArgs e)
        {
            object className = null; //the class contains the value of uctlFilter
            SetControlProperties();
            OnApplyClick(sender, e, className);
        }

        public void AddSymbol(List<string> lst)
        {
            ui_ncmbSymbol.Items.AddRange(lst.ToArray());
        }

        public void AddSeries(List<string> lst)
        {
            ui_ncmbSeries.Items.AddRange(lst.ToArray());
        }

        public void AddExpiryDate(List<string> lst)
        {
            ui_ncmbExpiryDate.Items.AddRange(lst.ToArray());
        }

        public void AddStrikePrice(List<string> lst)
        {
            ui_ncmbStrikePrice.Items.AddRange(lst.ToArray());
        }

        public void AddOptionType(List<string> lst)
        {
            ui_ncmbOptType.Items.AddRange(lst.ToArray());
        }

        public void AddAccountType(List<string> lst)
        {
            ui_ncmbAccountType.Items.AddRange(lst.ToArray());
        }

        public void AddPartnerID(List<string> lst)
        {
            ui_ncmbPartId.Items.AddRange(lst.ToArray());
        }

        public void AddCurrencyCode(List<string> lst)
        {
            ui_ncmbCurrencyCode.Items.AddRange(lst.ToArray());
        }

        public void AddSpreadIOC(List<string> lst)
        {
            ui_ncmbSpreadIOC.Items.AddRange(lst.ToArray());
        }

        #endregion "      METHODS       "

        /// <summary>
        /// Provides filter information
        /// </summary>
        public void GetFilterInformation()
        {
        }

        #region    "     Event          "

        public event Action<object, EventArgs, object> OnApplyClick;
        public event Action<object, EventArgs> OnCancelClick;

        #endregion "      Event         "
    }
}