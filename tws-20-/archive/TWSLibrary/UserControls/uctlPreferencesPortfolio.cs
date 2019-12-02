///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION
//16/01/2012	VP          1.Designing and Coding of form	 
//31/01/2012	VP		    1.Added methods SetValues and GetValues for setting and getting the values of controls
//02/02/2012	VP		    1.Commenting of the code
//10/02/2012	VP		    1.Code for settings the protfolio values in comboxboxes
//16/02/2012	VP		    1.Correct the problem of selection of combobox
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using CommonLibrary.Cls;

namespace CommonLibrary.UserControls
{
    public partial class uctlPreferencesPortfolio : UctlBase
    {
        #region    "      MEMBERS       "

        private string _title = "Portfolio";

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

        public object PortfolioList { get; set; }

        #endregion "      PROPERTY      "

        #region "     CONSTRUCTOR    "

        /// <summary>
        /// Constructor for initilizing the components of the uctlAlertDialog 
        /// </summary>
        public uctlPreferencesPortfolio()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor for initilizing the components of the uctlAlertDialog with customised settings
        /// </summary>
        /// <param name="customizeSettings"></param>
        public uctlPreferencesPortfolio(object customizeSettings)
        {
        }

        #endregion "     CONSTRUCTOR      "

        #region    "      METHODS       "

        /// <summary>
        /// Sets the text of the controls corresponding the localize value
        /// </summary>
        public override void SetLocalization()
        {
            Title = ClsLocalizationHandler.Portfolio;

            ui_lblMarketWatch.Text = ClsLocalizationHandler.Market + " " + ClsLocalizationHandler.Watch;
            ui_lblMarketWatch2.Text = ClsLocalizationHandler.Market + " " + ClsLocalizationHandler.Watch + " :";
            ui_lblSelectInformation.Text = ClsLocalizationHandler.SelectInformationinPreferencePortolio + ".";
            ui_lblTicker.Text = ClsLocalizationHandler.Ticker;
            ui_lblTicker2.Text = ClsLocalizationHandler.Ticker + " :";
            ui_lblTicker2.Text = ClsLocalizationHandler.Ticker + "(" + ClsLocalizationHandler.Commodity + ") :";
            ui_lblDisplay.Text = ClsLocalizationHandler.Display;
            ui_lblPortfolio.Text = ClsLocalizationHandler.Portfolio;
            ui_lblSpeed.Text = ClsLocalizationHandler.Speed;
        }

        /// <summary>
        /// Sets stored values to the controls
        /// </summary>
        /// <param name="PreferencesPortfolioSettings">Sotred settings</param>
        public void SetValues(ClsPreferencesPortfolio PreferencesPortfolioSettings)
        {
            SetSelectedValueIndex();

            SetPortfolioValues();
            ui_ncmbMarketWatch.SelectedItem = PreferencesPortfolioSettings.MarketWatch;
            ui_ncmbTickerDisplay.SelectedItem = PreferencesPortfolioSettings.TickerDisplay;
            ui_ncmbTickerCommodityDisplay.SelectedItem = PreferencesPortfolioSettings.TickerComodityDisplay;
            ui_ncmbTickerPortfolio.SelectedItem = PreferencesPortfolioSettings.TickerPortfolio;
            ui_ntrkbTickerSpeed.TrackBarElement.Value = PreferencesPortfolioSettings.TickerSpeed;
            ui_ntrkbTickerCommoditySpeed.TrackBarElement.Value = PreferencesPortfolioSettings.TickerComoditySpeed;
        }

        /// <summary>
        /// Provides the current value of controls
        /// </summary>
        /// <returns>Portfolio settings</returns>
        public ClsPreferencesPortfolio GetValues()
        {
            var objclsPreferencesPortfolio = new ClsPreferencesPortfolio();

            objclsPreferencesPortfolio.MarketWatch = ui_ncmbMarketWatch.SelectedItem.ToString();
            objclsPreferencesPortfolio.TickerDisplay = ui_ncmbTickerDisplay.SelectedItem.ToString();
            objclsPreferencesPortfolio.TickerComodityDisplay = ui_ncmbTickerCommodityDisplay.SelectedItem.ToString();
            objclsPreferencesPortfolio.TickerPortfolio = ui_ncmbTickerPortfolio.SelectedItem.ToString();
            objclsPreferencesPortfolio.TickerSpeed = ui_ntrkbTickerSpeed.TrackBarElement.Value;
            objclsPreferencesPortfolio.TickerComoditySpeed = ui_ntrkbTickerCommoditySpeed.TrackBarElement.Value;

            return objclsPreferencesPortfolio;
        }

        public void SetSelectedValueIndex()
        {
            ui_ncmbMarketWatch.SelectedIndex = 0;
            ui_ncmbTickerCommodityDisplay.SelectedIndex = 0;
            ui_ncmbTickerDisplay.SelectedIndex = 0;
            ui_ncmbTickerPortfolio.SelectedIndex = 0;
        }

        #endregion "      METHODS       "

        private void uctlPreferencesPortfolio_Load(object sender, EventArgs e)
        {
        }

        public void SetPortfolioValues()
        {
            var DDPortfolio = (Dictionary<string, ClsPortfolio>) PortfolioList;
            if (DDPortfolio != null)
            {
                foreach (string item in DDPortfolio.Keys)
                {
                    if (!ui_ncmbMarketWatch.Items.Contains(item))
                    {
                        ui_ncmbMarketWatch.Items.Add(item);
                        ui_ncmbTickerPortfolio.Items.Add(item);
                    }
                }
            }
            //ui_ncmbMarketWatch.Items.AddRange(DDPortfolio.Keys.ToArray<string>());
            //ui_ncmbTickerPortfolio.Items.AddRange(DDPortfolio.Keys.ToArray<string>());
        }

        private void ui_npnlPreferencesPortfolio_Click(object sender, EventArgs e)
        {
        }
    }
}