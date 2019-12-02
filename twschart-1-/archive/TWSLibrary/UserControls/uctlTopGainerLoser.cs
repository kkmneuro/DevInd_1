///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION	
//03/01/2012	NN		
//02/02/2012	VP		    1.Commenting of the code
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CommonLibrary.Cls;

namespace CommonLibrary.UserControls
{
    public partial class UctlTopGainerLoser : UctlBase
    {
        #region   "      MEMBERS       "

        private string _title = "Top Gainers/Losers";

        #endregion "        MEMBERS           "

        #region    "      PROPERTY      "

        /// <summary>
        /// Sets and gets the title of the TopGainerLoser control
        /// </summary>
        public override string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        //public string InstrumentList
        //{
        //    get
        //    {
        //        return ui_ncmbInstrumentName.SelectedItem.ToString();
        //    }
        //    set
        //    {
        //        ui_ncmbInstrumentName.SelectedItem = value;
        //    }
        //}

        #endregion    "      PROPERTY      "

        #region "    CONSTRUCTOR     "

        /// <summary>
        /// Constructor for initializing the components of the uctlTopGainerLoser 
        /// </summary>
        public UctlTopGainerLoser()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor for initializing the components of the uctlTopGainerLoser with customized settings
        /// </summary>
        /// <param name="customizeSettings"></param>
        public UctlTopGainerLoser(object customizeSettings)
        {
        }

        #endregion "       CONSTRUCTOR        "

        #region    "      METHODS       "

        /// <summary>
        /// Sets the text of the controls and Top gainer Grid corresponding to their localized value
        /// </summary>
        public override void SetLocalization()
        {
            Title = ClsLocalizationHandler.Top + " " + ClsLocalizationHandler.Gainers + "/" +
                    ClsLocalizationHandler.Losers;

            ui_lblInstrumentName.Text = ClsLocalizationHandler.Instrument + " " + ClsLocalizationHandler.Name +
                                        " :";
            ui_ngbeTopGainers.HeaderItem.Text = ClsLocalizationHandler.Top + " " +
                                                ClsLocalizationHandler.Gainers;
            ui_ngbeTopLosers.HeaderItem.Text = ClsLocalizationHandler.Top + " " + ClsLocalizationHandler.Losers;

            //Localization(ui_uctlGridTopGainers);
            //Localization(ui_uctlGridTopLosers);
        }

        /// <summary>
        /// Sets the text of the controls and Top loser Grid corresponding to their localized value
        /// </summary>
        /// <param name="ObjGrid">object of uctlGrid is passed to set localized value</param>
        public void Localization(UctlGrid ObjGrid)
        {
            ObjGrid.Columns[0].HeaderText = ClsLocalizationHandler.Symbol;
            ObjGrid.Columns[1].HeaderText = ClsLocalizationHandler.Series + "/" + ClsLocalizationHandler.Expiry;
            ObjGrid.Columns[2].HeaderText = ClsLocalizationHandler.Strike + " " + ClsLocalizationHandler.Price;
            ObjGrid.Columns[3].HeaderText = ClsLocalizationHandler.Option + " " + ClsLocalizationHandler.Type;
            ObjGrid.Columns[4].HeaderText = ClsLocalizationHandler.Previous + " " + ClsLocalizationHandler.Close;
            ObjGrid.Columns[5].HeaderText = "%" + ClsLocalizationHandler.Change;
            //NO loclization value ObjGrid.Columns[6].HeaderText = Cls.clsLocalizationHandler.LTP;
        }

        public void AddInstruments(List<string> lst)
        {
            ui_ncmbInstrumentName.Items.AddRange(lst.ToArray());
        }

        /// <summary>
        /// This method adds columns to the user grid control at run time
        /// </summary>
        public void AddColumnsToGrid()
        {
            var columnsArrayTopGainers = new DataGridViewColumn[7];

            var intCellStyle = new DataGridViewCellStyle();
            intCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            columnsArrayTopGainers[0] = ClsCommonMethods.CreateGridColumn(columnsArrayTopGainers[0], "ClmSymbol",
                                                                          "Symbol");
            columnsArrayTopGainers[1] = ClsCommonMethods.CreateGridColumn(columnsArrayTopGainers[1], "ClmSeriesExpiry",
                                                                          "Series/Expiry");
            columnsArrayTopGainers[2] = ClsCommonMethods.CreateGridColumn(columnsArrayTopGainers[2], "ClmStrikePrice",
                                                                          "Strike Price");
            columnsArrayTopGainers[2].DefaultCellStyle = intCellStyle;
            columnsArrayTopGainers[3] = ClsCommonMethods.CreateGridColumn(columnsArrayTopGainers[3], "ClmOptionType",
                                                                          "Option Type");
            columnsArrayTopGainers[4] = ClsCommonMethods.CreateGridColumn(columnsArrayTopGainers[4], "ClmPreviousClose",
                                                                          "Prev. Close");
            columnsArrayTopGainers[5] = ClsCommonMethods.CreateGridColumn(columnsArrayTopGainers[5], "ClmPercentChange",
                                                                          "% Change");
            columnsArrayTopGainers[5].DefaultCellStyle = intCellStyle;
            columnsArrayTopGainers[6] = ClsCommonMethods.CreateGridColumn(columnsArrayTopGainers[6], "ClmLTP", "LTP");
            columnsArrayTopGainers[6].DefaultCellStyle = intCellStyle;

            var columnsArrayTopLosers = new DataGridViewColumn[7];

            columnsArrayTopLosers[0] = ClsCommonMethods.CreateGridColumn(columnsArrayTopLosers[0], "ClmSymbol", "Symbol");
            columnsArrayTopLosers[1] = ClsCommonMethods.CreateGridColumn(columnsArrayTopLosers[1], "ClmSeriesExpiry",
                                                                         "Series/Expiry");
            columnsArrayTopLosers[2] = ClsCommonMethods.CreateGridColumn(columnsArrayTopLosers[2], "ClmStrikePrice",
                                                                         "Strike Price");
            columnsArrayTopLosers[2].DefaultCellStyle = intCellStyle;
            columnsArrayTopLosers[3] = ClsCommonMethods.CreateGridColumn(columnsArrayTopLosers[3], "ClmOptionType",
                                                                         "Option Type");
            columnsArrayTopLosers[4] = ClsCommonMethods.CreateGridColumn(columnsArrayTopLosers[4], "ClmPreviousClose",
                                                                         "Prev. Close");
            columnsArrayTopLosers[5] = ClsCommonMethods.CreateGridColumn(columnsArrayTopLosers[5], "ClmPercentChange",
                                                                         "% Change");
            columnsArrayTopLosers[5].DefaultCellStyle = intCellStyle;
            columnsArrayTopLosers[6] = ClsCommonMethods.CreateGridColumn(columnsArrayTopLosers[6], "ClmLTP", "LTP");
            columnsArrayTopLosers[6].DefaultCellStyle = intCellStyle;

            ui_uctlGridTopGainers.AddColumns(columnsArrayTopGainers);
            ui_uctlGridTopLosers.AddColumns(columnsArrayTopLosers);
        }

        #endregion    "      METHODS       "

        /// <summary>
        /// Tasks performed on the control load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uctlTopGainerLoser_Load(object sender, EventArgs e)
        {
            ui_ncmbInstrumentName.SelectedIndex = 0;

            AddColumnsToGrid();
            //SetLocalization();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}