///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION	
//16/01/2012	VP		    1.Coding of user control
//02/02/2012	VP		    1.Commenting of the code
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections;
using CommonLibrary.Cls;

namespace CommonLibrary.UserControls
{
    /// <summary>
    /// uctlPrferences user control code
    /// </summary>
    public partial class UctlPreferences : UctlBase
    {
        #region    "      MEMBERS       "

        private string _title = "Preferences";

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

        public Hashtable HotKeySettingsHashTable { get; set; }

        public Hashtable GetHashTable()
        {
            return ui_uctlHotKeysSettings.GetHashTable();
        }

        #endregion "      PROPERTY      "

        #region "        CONSTRUCTOR      "

        /// <summary>
        /// Constructor for initilizing the components of the uctlAlertDialog 
        /// </summary>
        public UctlPreferences()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor for initilizing the components of the uctlAlertDialog with customised settings
        /// </summary>
        /// <param name="customizeSettings"></param>
        public UctlPreferences(object customizeSettings)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public void PopulateHotKeySettings()
        {
            if (HotKeySettingsHashTable != null)
                ui_uctlHotKeysSettings.Init(HotKeySettingsHashTable);
        }

        #endregion "     CONSTRUCTOR      "

        #region    "      METHODS       "

        /// <summary>
        /// Sets the text of the controls corresponding the localize value
        /// </summary>
        public override void SetLocalization()
        {
            ui_uctlPreferencesGeneral.SetLocalization();
            ui_uctlPreferencesOrder.SetLocalization();
            ui_uctlPreferencesAlerts.SetLocalization();
            ui_uctlPreferencesWorkSpace.SetLocalization();
            ui_uctlPreferencesPortfolio.SetLocalization();
            ui_uctlHotKeysSettings.SetLocalization();

            Title = ClsLocalizationHandler.Preferences;

            ui_ntbPreferences.TabPages[0].Text = ClsLocalizationHandler.General;
            ui_ntbPreferences.TabPages[1].Text = ClsLocalizationHandler.Order;
            ui_ntbPreferences.TabPages[2].Text = ClsLocalizationHandler.Alert;
            ui_ntbPreferences.TabPages[3].Text = ClsLocalizationHandler.Portfolio;
            ui_ntbPreferences.TabPages[4].Text = ClsLocalizationHandler.WorkSpace;

            ui_nbtnOK.Text = ClsLocalizationHandler.Ok;
            ui_nbtnCancel.Text = ClsLocalizationHandler.Cancel;
            ui_nbtnApply.Text = ClsLocalizationHandler.Apply;
        }

        /// <summary>
        /// Invokes Ok click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_nbtnOK_Click(object sender, EventArgs e)
        {
            OnOkClick(sender, e);
        }

        /// <summary>
        /// Invokes Cancel click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_nbtnCancel_Click(object sender, EventArgs e)
        {
            OnCancelClick(sender, e);
        }

        /// <summary>
        /// Invokes Apply click event  and stores values to clsPreferences object
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_nbtnApply_Click(object sender, EventArgs e)
        {
            var objclsPreferences = new ClsPreferences();

            objclsPreferences.Gerneral = ui_uctlPreferencesGeneral.GetValues();
            objclsPreferences.Alert = ui_uctlPreferencesAlerts.GetValues();
            objclsPreferences.Order = ui_uctlPreferencesOrder.GetValues();
            objclsPreferences.PreferencesPortfolio = ui_uctlPreferencesPortfolio.GetValues();
            objclsPreferences.WorkSpace = ui_uctlPreferencesWorkSpace.GetValues();
            objclsPreferences.ForexPair = ui_uctlPreferencesForexPair.GetValues();
            objclsPreferences.HotKeySettings = ui_uctlHotKeysSettings.GetValues();
            objclsPreferences.MarketWatchPreferanceSettings = uctlPreferencesMarketWatch1.GetValues();
            objclsPreferences.DocumentsSettings = uctlDocumentsSetting1.GetValues();
            HotKeySettingsHashTable = ui_uctlHotKeysSettings.GetHotKeysSetting();
            OnApplyClick(sender, e, objclsPreferences);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_ntbPreferences_SelectedTabChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Tasks performed on the control load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uctlPreferences_Load(object sender, EventArgs e)
        {
            //SetLocalization();
        }

        #endregion "      METHODS       "

        #region    "      EVENTS        "

        public event Action<object, EventArgs> OnOkClick;
        public event Action<object, EventArgs> OnCancelClick;
        public event Action<object, EventArgs, ClsPreferences> OnApplyClick;
        public event Action<object, System.ComponentModel.CancelEventArgs> OnMinOrderQtyValidating = delegate { }; 

        #endregion "      EVENTS        "

        private void ui_uctlPreferencesOrder_OnMinOrderQtyValidating(object arg1, System.ComponentModel.CancelEventArgs arg2)
        {
            OnMinOrderQtyValidating(arg1,arg2);
        }
    }
}