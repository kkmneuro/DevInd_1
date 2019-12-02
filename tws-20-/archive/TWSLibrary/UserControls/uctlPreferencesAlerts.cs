///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION
//16/01/2012	VP          1.Designing and Coding of form	 
//31/01/2012	VP		    1.Added methods SetValues and GetValues for setting and getting the values of controls
//01/02/2012	VP		    1.Defined functionality of Restore Default button
//02/02/2012	VP		    1.Commenting of the code
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using CommonLibrary.Cls;
using Nevron.UI.WinForm.Controls;

namespace CommonLibrary.UserControls
{
    public partial class UctlPreferencesAlerts : UctlBase
    {
        #region    "      MEMBERS       "

        private string _title = "Alerts";

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

        #endregion "      PROPERTY      "

        #region "      CONSTRUCTOR    "

        /// <summary>
        /// Constructor for initilizing the components of the uctlAlertDialog 
        /// </summary>
        public UctlPreferencesAlerts()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor for initilizing the components of the uctlAlertDialog with customised settings
        /// </summary>
        /// <param name="customizeSettings"></param>
        public UctlPreferencesAlerts(object customizeSettings)
        {
        }

        #endregion "     CONSTRUCTOR      "

        #region    "      METHODS       "

        /// <summary>
        /// Sets the text of the controls corresponding the localize value
        /// </summary>
        public override void SetLocalization()
        {
            Title = ClsLocalizationHandler.Alert;

            ui_lblMessageOptions.Text = ClsLocalizationHandler.PreferenceAlertTitleLabel;
            ui_nchkFreshOrder.Text = ClsLocalizationHandler.FreshOrder;
            ui_nchkOrderModification.Text = ClsLocalizationHandler.OrderModification;
            ui_nchkMarketOrder.Text = ClsLocalizationHandler.MarketOrder;
            ui_nchkOrderCancellation.Text = ClsLocalizationHandler.OrderCancellation;
            ui_nchkTradeModification.Text = ClsLocalizationHandler.TradeModification;
            ui_nchkDifferentProductOrder.Text = ClsLocalizationHandler.DifferentProductOrder;
            ui_nchkOutsideDPROrder.Text = ClsLocalizationHandler.OutsideDPROrder;
            ui_lblQuantityAlert.Text = ClsLocalizationHandler.QtyAlert + " :";
            ui_lblPriceAlert.Text = ClsLocalizationHandler.PriceAlert + " :";
            ui_lblValueAlert.Text = ClsLocalizationHandler.ValueAlert + " :";
            ui_nchkOpenPositionAlert.Text = ClsLocalizationHandler.OpenPositionAlertOnLogoff;
            ui_nchkPendingOrdersAlert.Text = ClsLocalizationHandler.PendingOrdersAlertOnLogoff;
            ui_lblTradingCurrencyAlert.Text = ClsLocalizationHandler.TradingCurrencyAlert + " :";
            ui_nbtnRestoreDefault.Text = ClsLocalizationHandler.RestoreDefaults;
        }

        /// <summary>
        /// Sets stored values to the controls
        /// </summary>
        /// <param name="AlertSettings">Sotred settings</param>
        public void SetValues(ClsAlert AlertSettings)
        {
            ui_nchkFreshOrder.Checked = AlertSettings.IsFrshOrder;
            ui_nchkOrderModification.Checked = AlertSettings.IsOrderModification;
            ui_nchkMarketOrder.Checked = AlertSettings.IsMarketOrder;
            ui_nchkOrderCancellation.Checked = AlertSettings.IsOrderCancellation;
            ui_nchkTradeModification.Checked = AlertSettings.IsTradeModification;
            ui_nchkDifferentProductOrder.Checked = AlertSettings.IsDifferentProductOrder;
            ui_nchkOutsideDPROrder.Checked = AlertSettings.IsOutsideDPROrder;
            ui_nchkOpenPositionAlert.Checked = AlertSettings.IsOpenPositionAlertOnLogoff;
            ui_nchkPendingOrdersAlert.Checked = AlertSettings.IsPendingOrdersAlertOnLogoff;
            ui_ntxtQuntityAlert.Text = AlertSettings.QuantityAlerts.ToString();
            ui_ntxtValueAlert.Text = AlertSettings.ValueAlerts.ToString();
            ui_ntxtPriceAlert.Text = AlertSettings.PriceAlerts.ToString();
            ui_ntxtIOCPriceAlert.Text = AlertSettings.SpreadIOCPriceAlerts.ToString();

            foreach (
                string item in
                    AlertSettings.TradingCurrencyAlerts.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries))
            {
                ui_nlstTradingCurrencyAlert.Items[item].Checked = true;
            }
        }

        /// <summary>
        /// Provides the current value of controls
        /// </summary>
        /// <returns>Alert settings</returns>
        public ClsAlert GetValues()
        {
            var objclsAlert = new ClsAlert();

            objclsAlert.IsFrshOrder = ui_nchkFreshOrder.Checked;
            objclsAlert.IsOrderModification = ui_nchkOrderModification.Checked;
            objclsAlert.IsMarketOrder = ui_nchkMarketOrder.Checked;
            objclsAlert.IsOrderCancellation = ui_nchkOrderCancellation.Checked;
            objclsAlert.IsTradeModification = ui_nchkTradeModification.Checked;
            objclsAlert.IsDifferentProductOrder = ui_nchkDifferentProductOrder.Checked;
            objclsAlert.IsOutsideDPROrder = ui_nchkOutsideDPROrder.Checked;
            objclsAlert.IsOpenPositionAlertOnLogoff = ui_nchkOpenPositionAlert.Checked;
            objclsAlert.IsPendingOrdersAlertOnLogoff = ui_nchkPendingOrdersAlert.Checked;
            objclsAlert.QuantityAlerts = int.Parse(ui_ntxtQuntityAlert.Text);
            objclsAlert.ValueAlerts = int.Parse(ui_ntxtValueAlert.Text);
            objclsAlert.PriceAlerts = int.Parse(ui_ntxtPriceAlert.Text);
            objclsAlert.SpreadIOCPriceAlerts = int.Parse(ui_ntxtIOCPriceAlert.Text);

            string str = string.Empty;
            foreach (string checkedItem in ui_nlstTradingCurrencyAlert.CheckedItems)
            {
                str = str + "," + checkedItem;
            }
            objclsAlert.TradingCurrencyAlerts = str;

            return objclsAlert;
        }

        private void ui_npnlPreferencesAlerts_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Puts default values to controls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_nbtnRestoreDefault_Click(object sender, EventArgs e)
        {
            ui_nchkFreshOrder.Checked = false;
            ui_nchkOrderModification.Checked = false;
            ui_nchkMarketOrder.Checked = false;
            ui_nchkOrderCancellation.Checked = false;
            ui_nchkTradeModification.Checked = false;
            ui_nchkDifferentProductOrder.Checked = false;
            ui_nchkOutsideDPROrder.Checked = false;
            ui_nchkOpenPositionAlert.Checked = false;
            ui_nchkPendingOrdersAlert.Checked = false;
            ui_ntxtQuntityAlert.Text = "";
            ui_ntxtValueAlert.Text = "";
            ui_ntxtPriceAlert.Text = "";
            ui_ntxtIOCPriceAlert.Text = "";

            foreach (NListBoxItem item in ui_nlstTradingCurrencyAlert.Items)
            {
                item.Checked = false;
            }
        }

        #endregion "      METHODS       "
    }
}