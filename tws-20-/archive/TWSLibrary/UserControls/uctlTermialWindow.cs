using System;
using CommonLibrary.Cls;

namespace CommonLibrary.UserControls
{
    public partial class uctlTermialWindow : UctlBase
    {
        #region    "      MEMBERS       "

        private string _title = "Terminal Panel";

        #endregion "      MEMBERS       "

        #region    "      PROPERTY      "

        /// <summary>
        /// Sets and gets the title of TerminalWindow control
        /// </summary>
        public override string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        #endregion "      PROPERTY      "

        #region "    CONSTRUCTOR     "

        /// <summary>
        /// Constructor for initilizing the components of the uctlTermialWindow 
        /// </summary>
        public uctlTermialWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor for initilizing the components of the uctlTermialWindow with customised settings
        /// </summary>
        /// <param name="customizeSettings"></param>
        public uctlTermialWindow(object customizeSettings)
        {
        }

        #endregion "       CONSTRUCTOR        "

        #region    "      METHODS       "

        /// <summary>
        /// Sets the text of the controls corresponding to localization values
        /// </summary>
        public override void SetLocalization()
        {
            ui_uctlTerminalWindowTrade.SetLocalization();
            ui_uctlTerminalWindowAccountStatement.SetLocalization();
            ui_uctlTerminalWindowNews.SetLocalization();
            ui_uctlTerminalWindowAlert.SetLocalization();
            ui_uctlTerminalWindowMails.SetLocalization();
            ui_uctlTerminalWindowLog.SetLocalization();

            _title = ClsLocalizationHandler.Terminal + " " + ClsLocalizationHandler.Panel;

            ui_ntcTerminalWindow.TabPages[0].Text = ClsLocalizationHandler.Trade;
            ui_ntcTerminalWindow.TabPages[1].Text = ClsLocalizationHandler.Account + " " +
                                                    ClsLocalizationHandler.Statement;
            ui_ntcTerminalWindow.TabPages[2].Text = ClsLocalizationHandler.News;
            ui_ntcTerminalWindow.TabPages[3].Text = ClsLocalizationHandler.Alert;
            ui_ntcTerminalWindow.TabPages[4].Text = ClsLocalizationHandler.Mails;
            ui_ntcTerminalWindow.TabPages[5].Text = ClsLocalizationHandler.Log;
        }

        /// <summary>
        /// Called when the control is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uctlTermialWindow_Load(object sender, EventArgs e)
        {
        }

        #endregion "      METHODS       "
    }
}