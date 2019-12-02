///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION	
//17/01/2012	VP		    1.Designing and Coding of control.
//17/01/2012	VP		    1.Added tooltip text to controls.
//02/02/2012	VP		    1.Commenting of the code
//14/02/2012	VP		    1.Added methods for setting the values of instuments and expirydate in QuoteSnap and defines properties
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using CommonLibrary.Cls;

namespace CommonLibrary.UserControls
{
    public partial class UctlSnapQuote : UctlBase
    {
        #region    "      MEMBERS       "

        private string _title = "Snap Quote";

        #endregion "      MEMBERS       "

        #region    "      PROPERTY      "

        /// <summary>
        /// Sets and gets the title of the AlertDialog control
        /// </summary>
        public override string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string BuyOrderQuantity
        {
            get { return ui_ntxtBuyQuantity.Text; }
            set { ui_ntxtBuyQuantity.Text = value; }
        }

        public string BuyPrice
        {
            get { return ui_ntxtBuyPrice.Text; }
            set { ui_ntxtBuyPrice.Text = value; }
        }


        public string SellQuantity
        {
            get { return ui_ntxtSellQuantity.Text; }
            set { ui_ntxtSellQuantity.Text = value; }
        }


        public string SellPrice
        {
            get { return ui_ntxtSellPrice.Text; }
            set { ui_ntxtSellPrice.Text = value; }
        }

        public string LastTradedPrice
        {
            get { return ui_ntxtLastTradedPrice.Text; }
            set { ui_ntxtLastTradedPrice.Text = value; }
        }

        #endregion "      PROPERTY      "

        #region "    CONSTRUCTOR     "

        /// <summary>
        /// Constructor for initilizing the components of the uctlAlertDialog 
        /// </summary>
        public UctlSnapQuote()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor for initilizing the components of the uctlAlertDialog with customised settings
        /// </summary>
        /// <param name="customizeSettings"></param>
        public UctlSnapQuote(object customizeSettings)
        {
        }

        #endregion "          CONSTRUCTOR            "

        #region    "      METHODS       "

        public void SetValues(clsSnapValue snapValue)
        {
            ui_ntxtBuyQuantity.Text = snapValue.BuyQty;
            ui_ntxtBuyPrice.Text = snapValue.BuyPrice;
            ui_ntxtSellQuantity.Text = snapValue.SellQty;
            ui_ntxtSellPrice.Text = snapValue.SellPrice;
            ui_ntxtLastTradedPrice.Text = snapValue.LastTradedPrice;
        }

        public void SetBuyValues(clsSnapValue snapValue)
        {
            ui_ntxtBuyQuantity.Text = snapValue.BuyQty;
            ui_ntxtBuyPrice.Text = snapValue.BuyPrice;
        }

        public void SetSellValues(clsSnapValue snapValue)
        {
            ui_ntxtSellQuantity.Text = snapValue.SellQty;
            ui_ntxtSellPrice.Text = snapValue.SellPrice;
        }

        public void SetLastPrice(clsSnapValue snapValue)
        {
            ui_ntxtLastTradedPrice.Text = snapValue.LastTradedPrice;
        }

        public void AddInstruments(List<string> lst)
        {
            ui_ncmbProductType.Items.AddRange(lst.ToArray());
        }

        public void AddExpiryDate(List<string> lst)
        {
            ui_ncmbExpiryDate.Items.Clear();
            ui_ncmbExpiryDate.Items.AddRange(lst.ToArray());
        }

        public void AddProducts(List<string> lst)
        {
            ui_ncmbProduct.Items.Clear();
            ui_ncmbProduct.Items.AddRange(lst.ToArray());
        }

        public void AddContracts(List<string> lst)
        {
            ui_ncmbContract.Items.Clear();
            ui_ncmbContract.Items.AddRange(lst.ToArray());
        }

        public void SetExpiryText(string str)
        {
            ui_ncmbExpiryDate.SelectedIndex = ui_ncmbExpiryDate.Items.IndexOf(str);
        }

        /// <summary>
        /// Sets the text of the controls corresponding the localize value
        /// </summary>
        public override void SetLocalization()
        {
            Title = ClsLocalizationHandler.Snap + " " + ClsLocalizationHandler.Quote;
        }

        #endregion "      METHODS       "

        /// <summary>
        /// Tasks performed on the control load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uctlSnapQuote_Load(object sender, EventArgs e)
        {
            //ui_ncmbContract.SelectedIndex = 0;
            //ui_ncmbExpiryDate.SelectedIndex = 0;
            //ui_ncmbProductType.SelectedIndex = 0;
            //ui_ncmbProduct.SelectedIndex = 0;
            //nComboBox3.SelectedIndex = 0;
            //nComboBox4.SelectedIndex = 0;

            // SetLocalization();
        }

        /// <summary>
        /// Provides information of the controls
        /// </summary>
        public void GetSnapQuoteInformation()
        {
        }

        public event Action<string> OnProductTypeSelected;
        public event Action<string, string> OnProductSelected;
        public event Action<string, string, string> OnContractSelected;

        private void ui_ncmbProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnProductTypeSelected(ui_ncmbProductType.Text);
        }

        private void ui_ncmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnProductSelected(ui_ncmbProductType.Text, ui_ncmbProduct.Text);
        }

        private void ui_ncmbContract_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnContractSelected(ui_ncmbProductType.Text, ui_ncmbProduct.Text, ui_ncmbContract.Text);
        }
    }

    public class clsSnapValue
    {
        public string BuyQty { get; set; }
        public string BuyPrice { get; set; }
        public string SellQty { get; set; }
        public string SellPrice { get; set; }
        public string LastTradedPrice { get; set; }
    }
}