///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION
//16/01/2012	VP          1.Designing and Coding of form	 
//31/01/2012	VP		    1.Added methods SetValues and GetValues for setting and getting the values of controls
//01/02/2012	VP		    1.Defined functionality of Restore Default button
//02/02/2012	VP		    1.Commenting of the code
//16/02/2012	VP		    1.Correct the problem of selection of combobox
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using CommonLibrary.Cls;

namespace CommonLibrary.UserControls
{
    public partial class UctlPreferencesOrder : UctlBase
    {
        #region    "      MEMBERS       "

        private string _title = "Order";

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

        #region "            CONSTRUCTOR           "

        /// <summary>
        /// Constructor for initilizing the components of the uctlAlertDialog 
        /// </summary>
        public UctlPreferencesOrder()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor for initilizing the components of the uctlAlertDialog with customised settings
        /// </summary>
        /// <param name="customizeSettings"></param>
        public UctlPreferencesOrder(object customizeSettings)
        {
        }

        #endregion "          CONSTRUCTOR            "

        #region    "      METHODS       "

        /// <summary>
        /// Sets the text of the controls corresponding the localize value
        /// </summary>
        public override void SetLocalization()
        {
            Title = ClsLocalizationHandler.Order;

            ui_nchkAlwaysuseminqty.Text = ClsLocalizationHandler.AlwaysUseMinQtyGivenHere;
            ui_lblMinOrderQty.Text = ClsLocalizationHandler.AlwaysUseMinQtyGivenHere + " :";
            ui_nchkDisableQty.Text = ClsLocalizationHandler.Disable + " D_." + ClsLocalizationHandler.Quantity;
            ui_lblOrdervalidity.Text = ClsLocalizationHandler.OrderValidity + " :";
            ui_nchkTriggerPrice.Text = ClsLocalizationHandler.TriggerPriceSameAsLimitPrice;
            ui_lblClient.Text = ClsLocalizationHandler.Client;
            ui_lblAccountType.Text = ClsLocalizationHandler.Account + " " + ClsLocalizationHandler.Type + "(" +
                                     ClsLocalizationHandler.Default + "):";
            ui_nchkPrefixClientIDWith.Text = ClsLocalizationHandler.PrefixClientIdWith;
            ui_nchkPrefixOmniIdWith.Text = ClsLocalizationHandler.PrefixOmniIdWith;
            ui_nchkRetainLastClientID.Text = ClsLocalizationHandler.RetainLastClientId;
            ui_nchkClientNameEnable.Text = ClsLocalizationHandler.ClientNameEnable;
            ui_nchkOTROrderAlert.Text = ClsLocalizationHandler.OTROrderAlert;
            ui_nchkRetainLastParticipaintCode.Text = ClsLocalizationHandler.RetainLastParticipaintCode + "/" +
                                                     ClsLocalizationHandler.Omni + " " +
                                                     ClsLocalizationHandler.Id;
            ui_nchkUnregisteredClientAlert.Text = ClsLocalizationHandler.UnregisteredClientAlert;
            ui_lblCursorSetting.Text = ClsLocalizationHandler.CursorSetting;
            ui_lblOrderEntryOnce.Text = ClsLocalizationHandler.OrderEntryOnce + " :";
            ui_lblOrderEntryMultiple.Text = ClsLocalizationHandler.OrderEntryMultiple + " :";
            ui_nchkDisableProductDetails.Text = ClsLocalizationHandler.DisableProductDetails;
            ui_nchkCloseOrderEntryAfterSubmission.Text = ClsLocalizationHandler.CloseOrderEntryAfterSubmission;
            ui_nchkPriceDecimalSelection.Text = ClsLocalizationHandler.PriceDecimalSelection;
            ui_lblSpreadIOC_CominationOrder.Text = "SpreadIOC/" + ClsLocalizationHandler.CombinationOrder;
            ui_nbtnRestoreDefaults.Text = ClsLocalizationHandler.RestoreDefaults;
        }

        /// <summary>
        /// Puts default values to controls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_nbtnRestoreDefaults_Click(object sender, EventArgs e)
        {
            ui_nchkAlwaysuseminqty.Checked = true;
            ui_ntxtMinOrderQuntity.Text = "1";
            ui_ncmbOrderValidity.SelectedIndex = 1;
            ui_nchkDisableQty.Checked = false;
            ui_nchkTriggerPrice.Checked = false;
            ui_ncmbAccountType.SelectedIndex = 1;
            ui_nchkPrefixClientIDWith.Checked = false;
            ui_nchkPrefixOmniIdWith.Checked = false;
            ui_nchkRetainLastParticipaintCode.Checked = false;
            ui_nchkRetainLastClientID.Checked = false;
            ui_nchkClientNameEnable.Checked = false;
            ui_nchkOTROrderAlert.Checked = false;
            ui_nchkUnregisteredClientAlert.Checked = false;
            ui_ncmbOrderEntryOnce.SelectedIndex = 0;
            ui_ncmbOrderEntryMultiple.SelectedIndex = 0;
            ui_nchkDisableProductDetails.Checked = false;
            ui_nchkCloseOrderEntryAfterSubmission.Checked = true;
            ui_nchkPriceDecimalSelection.Checked = false;
            ui_ncmbSIOC.SelectedIndex = 0;
            ui_ntxtPrefixClientIDWith.Text = "";
            ui_ntxtPrefixOminiIdWith.Text = "";
        }

        /// <summary>
        /// Sets stored values to the controls
        /// </summary>
        /// <param name="OrderSettings">Sotred settings</param>
        public void SetValues(ClsOrder OrderSettings)
        {
            SetSelectedValueIndex();

            ui_nchkAlwaysuseminqty.Checked = OrderSettings.IsAlwaysUseMinOrderQtyGiven;
            ui_ntxtMinOrderQuntity.Text = OrderSettings.MinOrderQty.ToString();
            ui_ncmbOrderValidity.SelectedItem = OrderSettings.OrderValidity;
            ui_nchkDisableQty.Checked = OrderSettings.IsDisableDQty;
            ui_nchkTriggerPrice.Checked = OrderSettings.IsTriggerPriceSameAsLimitPrice;
            ui_ncmbAccountType.SelectedItem = OrderSettings.AccountType;
            ui_nchkPrefixClientIDWith.Checked = OrderSettings.IsPrefixClientIDWith;
            ui_nchkPrefixOmniIdWith.Checked = OrderSettings.IsPrefixOmniIdWith;
            ui_nchkRetainLastParticipaintCode.Checked = OrderSettings.IsRetainLastParticipaintCodeOmniId;
            ui_nchkRetainLastClientID.Checked = OrderSettings.IsRetainLastClientID;
            ui_nchkClientNameEnable.Checked = OrderSettings.IsClientNameEnable;
            ui_nchkOTROrderAlert.Checked = OrderSettings.IsOTROrderAlert;
            ui_nchkUnregisteredClientAlert.Checked = OrderSettings.IsUnregisteredClientAlert;
            ui_ncmbOrderEntryOnce.SelectedItem = OrderSettings.OrderEntryOnce;
            ui_ncmbOrderEntryMultiple.SelectedItem = OrderSettings.OrderEntryMultiple;
            ui_nchkDisableProductDetails.Checked = OrderSettings.IsDisableProductDetails;
            ui_nchkCloseOrderEntryAfterSubmission.Checked = OrderSettings.IsCloseOrderEntryAfterSubmission;
            ui_nchkPriceDecimalSelection.Checked = OrderSettings.IsPriceDecimalSelection;
            ui_ncmbSIOC.SelectedItem = OrderSettings.SIOC;
            ui_ntxtPrefixClientIDWith.Text = OrderSettings.PrefixClientIDWith;
            ui_ntxtPrefixOminiIdWith.Text = OrderSettings.PrefixOmniIdWith;
        }

        /// <summary>
        /// Provides the current value of controls
        /// </summary>
        /// <returns>Order settings</returns>
        public ClsOrder GetValues()
        {
            var objclsOrder = new ClsOrder();

            objclsOrder.IsAlwaysUseMinOrderQtyGiven = ui_nchkAlwaysuseminqty.Checked;
            objclsOrder.MinOrderQty = Math.Round(Convert.ToDouble(ui_ntxtMinOrderQuntity.Text),2);
            objclsOrder.OrderValidity = ui_ncmbOrderValidity.SelectedItem.ToString();
            objclsOrder.IsDisableDQty = ui_nchkDisableQty.Checked;
            objclsOrder.IsTriggerPriceSameAsLimitPrice = ui_nchkTriggerPrice.Checked;
            objclsOrder.AccountType = ui_ncmbAccountType.SelectedItem.ToString();
            objclsOrder.IsPrefixClientIDWith = ui_nchkPrefixClientIDWith.Checked;
            objclsOrder.IsPrefixOmniIdWith = ui_nchkPrefixOmniIdWith.Checked;
            objclsOrder.IsRetainLastParticipaintCodeOmniId = ui_nchkRetainLastParticipaintCode.Checked;
            objclsOrder.IsRetainLastClientID = ui_nchkRetainLastClientID.Checked;
            objclsOrder.IsClientNameEnable = ui_nchkClientNameEnable.Checked;
            objclsOrder.IsOTROrderAlert = ui_nchkOTROrderAlert.Checked;
            objclsOrder.IsUnregisteredClientAlert = ui_nchkUnregisteredClientAlert.Checked;
            objclsOrder.OrderEntryOnce = ui_ncmbOrderEntryOnce.SelectedItem.ToString();
            objclsOrder.OrderEntryMultiple = ui_ncmbOrderEntryMultiple.SelectedItem.ToString();
            objclsOrder.IsDisableProductDetails = ui_nchkDisableProductDetails.Checked;
            objclsOrder.IsCloseOrderEntryAfterSubmission = ui_nchkCloseOrderEntryAfterSubmission.Checked;
            objclsOrder.IsPriceDecimalSelection = ui_nchkPriceDecimalSelection.Checked;
            objclsOrder.SIOC = ui_ncmbSIOC.SelectedItem.ToString();
            objclsOrder.PrefixClientIDWith = ui_ntxtPrefixClientIDWith.Text;
            objclsOrder.PrefixOmniIdWith = ui_ntxtPrefixOminiIdWith.Text;

            return objclsOrder;
        }

        public void SetSelectedValueIndex()
        {
            ui_ncmbAccountType.SelectedIndex = 0;
            ui_ncmbOrderEntryMultiple.SelectedIndex = 0;
            ui_ncmbOrderEntryOnce.SelectedIndex = 0;
            ui_ncmbOrderValidity.SelectedIndex = 0;
            ui_ncmbSIOC.SelectedIndex = 0;
        }

        #endregion "      METHODS       "

        private void uctlPreferencesOrder_Load(object sender, EventArgs e)
        {

        }
        public event Action<object, System.ComponentModel.CancelEventArgs> OnMinOrderQtyValidating = delegate { };
        private void ui_ntxtMinOrderQuntity_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            OnMinOrderQtyValidating(sender,e);
        }
    }
}