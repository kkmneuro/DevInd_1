///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION
//16/01/2012	VP          1.Designing and Coding of form	 
//31/01/2012	VP		    1.Added methods SetValues and GetValues for setting and getting the values of controls
//01/02/2012	VP		    1.Defined functionality of Restore Default button
//02/02/2012	VP		    1.Commenting of the code
//10/02/2012	VP		    1.Method for settings the values of instrument comboboxss
//16/02/2012	VP		    1.Correct the problem of selection of comboboxes
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using CommonLibrary.Cls;
using Nevron.UI.WinForm.Controls;

namespace CommonLibrary.UserControls
{
    /// <summary>
    /// Code for General settings
    /// </summary>
    public partial class UctlPreferencesGeneral : UctlBase
    {
        #region    "      MEMBERS       "

        private string _title = "General";

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

        #region "        CONSTRUCTOR      "

        /// <summary>
        /// Constructor for initilizing the components of the uctlAlertDialog 
        /// </summary>
        public UctlPreferencesGeneral()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor for initilizing the components of the uctlAlertDialog with customised settings
        /// </summary>
        /// <param name="customizeSettings"></param>
        public UctlPreferencesGeneral(object customizeSettings)
        {
        }

        #endregion "     CONSTRUCTOR      "

        #region    "      METHODS       "

        /// <summary>
        /// Sets the text of the controls corresponding the localize value
        /// </summary>
        public override void SetLocalization()
        {
            Title = ClsLocalizationHandler.General;

            ui_nchkPrintOrderConfirmation.Text = ClsLocalizationHandler.PrintOrderConfirmation;
            ui_nchkPrintTradeConfirmation.Text = ClsLocalizationHandler.PrintTradeConfirmation;
            ui_lblMessageBarMessageType.Text = ClsLocalizationHandler.MessageBarMessageType + " :";
            ui_lblOnEventDo.Text = ClsLocalizationHandler.OnEventDo;
            ui_lblEvent.Text = ClsLocalizationHandler.PEvent + " :";
            ui_nchkBeep.Text = ClsLocalizationHandler.Beep;
            ui_nchkFlashMessageBar.Text = ClsLocalizationHandler.FlashMessageBar;
            ui_nchkMessageBox.Text = ClsLocalizationHandler.MessageBox;
            ui_lblActionMessage.Text = ClsLocalizationHandler.PreferenceGeneralLogLabelText;
            ui_lblTimeFormat.Text = ClsLocalizationHandler.TimeFormatTobeUsedInViews + " :";
            ui_lblAlwaysOpentheOrderBook.Text = ClsLocalizationHandler.AlwaysOpenTheOrderBookWith + " :";
            ui_lblDefaultInstrumentName.Text = ClsLocalizationHandler.DefaultInstrumentName + " :";
            ui_lblMaxMessageLog.Text = ClsLocalizationHandler.MaxMessageInMessageLog + " :";
            ui_lblOrders.Text = ClsLocalizationHandler.Order;
            ui_nbtnRestoreDefault.Text = ClsLocalizationHandler.RestoreDefaults;
        }

        /// <summary>
        /// Sets stored values to the controls
        /// </summary>
        /// <param name="GeneralSettings">Sotred settings</param>
        public void SetValues(ClsGeneral GeneralSettings)
        {
            SetSelectedValueIndex();

            ui_nchkPrintOrderConfirmation.Checked = GeneralSettings.IsPrintOrderConfirm;
            ui_nchkPrintTradeConfirmation.Checked = GeneralSettings.IsPrintTradeConfirm;
            ui_nchkMTMOnLineCalculation.Checked = GeneralSettings.IsMTMonLineCalculation;
            foreach (
                string item in
                    GeneralSettings.MessageBarMessageType.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
                )
            {
                ui_nlstMessageBarMessageType.Items[item].Checked = true;
            }
            ui_ncmbEvent.SelectedItem = GeneralSettings.Event;
            ui_nchkBeep.Checked = GeneralSettings.IsBeep;
            ui_nchkFlashMessageBar.Checked = GeneralSettings.IsFlashMessageBar;
            ui_nchkMessageBox.Checked = GeneralSettings.IsMessageBox;
            ui_ncmbTimeFormat.SelectedItem = GeneralSettings.TimeFormat;
            ui_ncmbOrderBook.SelectedItem = GeneralSettings.AlwaysOpenTheOrderBookWith;
            ui_ncmbDefaultInstrumentName.SelectedItem = GeneralSettings.DefaultInstrumentName;
            ui_ncmbMaxMessageLog.SelectedItem = GeneralSettings.MaxMessageInMessageBox;
        }

        /// <summary>
        /// Provides the current value of controls
        /// </summary>
        /// <returns>General settings</returns>
        public ClsGeneral GetValues()
        {
            var objclsGeneral = new ClsGeneral();

            objclsGeneral.IsPrintOrderConfirm = ui_nchkPrintOrderConfirmation.Checked;
            objclsGeneral.IsPrintTradeConfirm = ui_nchkPrintTradeConfirmation.Checked;
            objclsGeneral.IsMTMonLineCalculation = ui_nchkMTMOnLineCalculation.Checked;
            string str = string.Empty;
            foreach (string checkedItem in ui_nlstMessageBarMessageType.CheckedItems)
            {
                str = str + "," + checkedItem;
            }
            objclsGeneral.MessageBarMessageType = str;
            objclsGeneral.Event = ui_ncmbEvent.SelectedItem.ToString();
            objclsGeneral.IsBeep = ui_nchkBeep.Checked;
            objclsGeneral.IsFlashMessageBar = ui_nchkFlashMessageBar.Checked;
            objclsGeneral.IsMessageBox = ui_nchkMessageBox.Checked;
            objclsGeneral.TimeFormat = ui_ncmbTimeFormat.SelectedItem.ToString();
            objclsGeneral.AlwaysOpenTheOrderBookWith = ui_ncmbOrderBook.SelectedItem.ToString();
            objclsGeneral.DefaultInstrumentName = ui_ncmbDefaultInstrumentName.SelectedItem.ToString();
            objclsGeneral.MaxMessageInMessageBox = ui_ncmbMaxMessageLog.SelectedItem.ToString();


            return objclsGeneral;
        }

        /// <summary>
        /// Restore defaults settings to controls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_nbtnRestoreDefault_Click(object sender, EventArgs e)
        {
            RestorDefault();
        }

        /// <summary>
        /// Puts default values to controls
        /// </summary>
        public void RestorDefault()
        {
            ui_nchkPrintOrderConfirmation.Checked = false;
            ui_nchkPrintTradeConfirmation.Checked = false;
            ui_nchkMTMOnLineCalculation.Checked = false;
            foreach (NListBoxItem item in ui_nlstMessageBarMessageType.Items)
            {
                item.Checked = false;
            }
            ui_ncmbEvent.SelectedIndex = 0;
            ui_nchkBeep.Checked = false;
            ui_nchkFlashMessageBar.Checked = false;
            ui_nchkMessageBox.Checked = false;
            ui_ncmbTimeFormat.SelectedIndex = 0;
            ui_ncmbOrderBook.SelectedIndex = 0;
            ui_ncmbDefaultInstrumentName.SelectedIndex = 0;
            ui_ncmbMaxMessageLog.SelectedIndex = 0;
        }

        public void SetInstruments(string str)
        {
            foreach (string item in str.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries))
            {
                if (!ui_ncmbDefaultInstrumentName.Items.Contains(item))
                {
                    ui_ncmbDefaultInstrumentName.Items.Add(item);
                }
            }
        }

        public void SetSelectedValueIndex()
        {
            ui_ncmbDefaultInstrumentName.SelectedIndex = 0;
            ui_ncmbEvent.SelectedIndex = 0;
            ui_ncmbMaxMessageLog.SelectedIndex = 0;
            ui_ncmbOrderBook.SelectedIndex = 0;
            ui_ncmbTimeFormat.SelectedIndex = 0;
        }

        #endregion "      METHODS       "

        private void uctlPreferencesGeneral_Load(object sender, EventArgs e)
        {
        }

        private void ui_nlcPreferencesGeneral5_Click(object sender, EventArgs e)
        {

        }
    }
}