///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION
//02/01/2012	VP		    1.Added comment to properties
//02/02/2012	VP		    1.Commenting of the code
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CommonLibrary.Cls;

namespace CommonLibrary.UserControls
{
    public partial class UctlMarketPicture : UctlBase
    {
        #region    "      MEMBERS       "

        private string _title = "Market Picture";

        #endregion "      MEMBERS       "

        #region    "      PROPERTY      "

        /// <summary>
        /// This property sets and gets the title of the market picture 
        /// </summary>
        public override string Title
        {
            get { return _title; }
            set { _title = value; }
        }


        /// <summary>
        /// This property sets and gets the selected instrument name from ui_ncmbInstrumentName combobox. This property is both settable and gettable
        /// </summary>
        //public string InstrumentName
        //{
        //    get
        //    {
        //        return ui_ncmbProductType.SelectedItem.ToString();
        //    }
        //    set
        //    {
        //        ui_ncmbProductType.SelectedItem = value;
        //    }
        //}
        /// <summary>
        /// This property sets and gets the selected instrument name from ui_ncmbSymbol combobox . This property is both settable and gettable
        /// </summary>
        //public string Symbol
        //{
        //    get
        //    {
        //        return ui_ncmbProduct.Text;
        //    }
        //    set
        //    {
        //        ui_ncmbProduct.Text = value;
        //    }
        //}
        /// <summary>
        /// This property sets and gets the selected instrument name from ui_ncmbSeries combobox. This property is both settable and gettable
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
        /// This property sets and gets the selected instrument name from ui_ncmbExpiryDate combobox. This property is both settable and gettable
        /// </summary>
        //public string ExpiryDate
        //{
        //    get
        //    {
        //        return ui_ncmbExpiryDate.SelectedItem.ToString();
        //    }
        //    set
        //    {
        //        ui_ncmbExpiryDate.SelectedItem = value;
        //    }
        //}
        /// <summary>
        /// This property sets and gets the selected instrument name from ui_ncmbStrikePrice combobox. This property is both settable and gettable
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
        /// This property sets and gets the selected instrument name from ui_ncmbOptionType combobox . This property is both settable and gettable
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
        /// This property sets and gets the text of ui_lblLTPValue label. This property is both settable and gettable
        /// </summary>
        public string LTP
        {
            get { return ui_lblLTPValue.Text; }
            set { ui_lblLTPValue.Text = value; }
        }

        /// <summary>
        /// This property sets and gets the text of ui_lblLTQValue label. This property is both settable and gettable
        /// </summary>
        public string LTQ
        {
            get { return ui_lblLTQValue.Text; }
            set { ui_lblLTQValue.Text = value; }
        }

        /// <summary>
        /// This property sets and gets the text of ui_lblVolumeValue label. This property is both settable and gettable
        /// </summary>
        public string Volume
        {
            get { return ui_lblVolumeValue.Text; }
            set { ui_lblVolumeValue.Text = value; }
        }

        /// <summary>
        /// This property sets and gets the text of ui_lblValueLabelValue label. This property is both settable and gettable
        /// </summary>
        public string Value
        {
            get { return ui_lblValueLabelValue.Text; }
            set { ui_lblValueLabelValue.Text = value; }
        }

        /// <summary>
        /// This property sets and gets the text of ui_lblATPValue label. This property is both settable and gettable
        /// </summary>
        public string ATP
        {
            get { return ui_lblATPValue.Text; }
            set { ui_lblATPValue.Text = value; }
        }

        /// <summary>
        /// This property sets and gets the text of ui_lblChangePercentageValue label. This property is both settable and gettable
        /// </summary>
        public string ChangePercentage
        {
            get { return ui_lblChangePercentageValue.Text; }
            set { ui_lblChangePercentageValue.Text = value; }
        }

        /// <summary>
        /// This property sets and gets the text of ui_lblOIValue label. This property is both settable and gettable
        /// </summary>
        public string OI
        {
            get { return ui_lblOIValue.Text; }
            set { ui_lblOIValue.Text = value; }
        }

        /// <summary>
        /// This property sets and gets the text of ui_lblOpenValue label. This property is both settable and gettable
        /// </summary>
        public string Open
        {
            get { return ui_lblOpenValue.Text; }
            set { ui_lblOpenValue.Text = value; }
        }

        /// <summary>
        /// This property sets and gets the text of ui_lblHighValue label. This property is both settable and gettable
        /// </summary>
        public string High
        {
            get { return ui_lblHighValue.Text; }
            set { ui_lblHighValue.Text = value; }
        }

        /// <summary>
        /// This property sets and gets the text of ui_lblLowValue label. This property is both settable and gettable
        /// </summary>
        public string Low
        {
            get { return ui_lblLowValue.Text; }
            set { ui_lblLowValue.Text = value; }
        }

        /// <summary>
        /// This property sets and gets the text of ui_lblCloseValue label. This property is both settable and gettable
        /// </summary>
        public string Close
        {
            get { return ui_lblCloseValue.Text; }
            set { ui_lblCloseValue.Text = value; }
        }

        /// <summary>
        /// This property sets and gets the text of ui_lblLifeTimeHighValue label. This property is both settable and gettable
        /// </summary>
        public string LifeTimeHigh
        {
            get { return ui_lblLifeTimeHighValue.Text; }
            set { ui_lblLifeTimeHighValue.Text = value; }
        }

        /// <summary>
        /// This property sets and gets the text of ui_lblLifeTimeLowValue label. This property is both settable and gettable
        /// </summary>
        public string LifeTimeLow
        {
            get { return ui_lblLifeTimeLowValue.Text; }
            set { ui_lblLifeTimeLowValue.Text = value; }
        }

        /// <summary>
        /// This property sets and gets the text of ui_lblDPRValue label. This property is both settable and gettable
        /// </summary>
        public string DPR
        {
            get { return ui_lblDPRValue.Text; }
            set { ui_lblDPRValue.Text = value; }
        }

        /// <summary>
        /// This property sets and gets the text of ui_lblLeftNumericValue label. This property is both settable and gettable
        /// </summary>
        public string LeftNumericValue
        {
            get { return ui_lblLeftNumericValue.Text; }
            set { ui_lblLeftNumericValue.Text = value; }
        }

        /// <summary>
        /// This property sets and gets the text of ui_lblRightNumericValue label. This property is both settable and gettable
        /// </summary>
        public string RightNumericValue
        {
            get { return ui_lblRightNumericValue.Text; }
            set { ui_lblRightNumericValue.Text = value; }
        }

        /// <summary>
        /// This property sets and gets the text of ui_lblVolumeLUTValue label. This property is both settable and gettable
        /// </summary>
        public string LUT
        {
            get { return ui_lblLUTValue.Text; }
            set { ui_lblLUTValue.Text = value; }
        }

        /// <summary>
        /// This property sets and gets the text of ui_lblLTTValue label. This property is both settable and gettable
        /// </summary>
        public string LTT
        {
            get { return ui_lblLTTValue.Text; }
            set { ui_lblLTTValue.Text = value; }
        }

        #endregion "      PROPERTY      "

        #region "     CONSTRUCTOR    "

        /// <summary>
        /// Constructor for initilizing the components of the uctlMarketPicture 
        /// </summary>
        public UctlMarketPicture()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor for initilizing the components of the uctlMarketPicture with customised settings
        /// </summary>
        /// <param name="customizeSettings"></param>
        public UctlMarketPicture(object customizeSettings)
        {
        }

        #endregion "    CONSTRUCTOR     "

        #region    "      METHODS       "

        /// <summary>
        /// Sets the text of the controls of the market picture corresponding to the localization value
        /// </summary>
        public override void SetLocalization()
        {
            Title = ClsLocalizationHandler.Market + " " + ClsLocalizationHandler.Picture;

            ui_lblProductType.Text = ClsLocalizationHandler.Instrument + " " + ClsLocalizationHandler.Name;
            ui_lblProduct.Text = ClsLocalizationHandler.Symbol;
            ui_lblSeries.Text = ClsLocalizationHandler.Series;
            ui_lblEpiryDate.Text = ClsLocalizationHandler.Expiry + " " + ClsLocalizationHandler.Date;
            ui_lblStrikePrice.Text = ClsLocalizationHandler.Strike + " " + ClsLocalizationHandler.Price;
            ui_lblOptType.Text = ClsLocalizationHandler.Option + " " + ClsLocalizationHandler.Type;
            ui_lblVolume.Text = ClsLocalizationHandler.Volume + " : ";
            ui_lblValue.Text = ClsLocalizationHandler.Value + "(lacs) : ";
            ui_lblPercentagechange.Text = "% " + ClsLocalizationHandler.Change + " : ";
            ui_lblOpen.Text = ClsLocalizationHandler.Open + " : ";
            ui_lblHigh.Text = ClsLocalizationHandler.High + " : ";
            ui_lblLow.Text = ClsLocalizationHandler.Low + " : ";
            ui_lblClose.Text = ClsLocalizationHandler.Close + " : ";
            ui_lblLifeTimeHigh.Text = ClsLocalizationHandler.Life + " " + ClsLocalizationHandler.Time + " " +
                                      ClsLocalizationHandler.High + " : ";
            ui_lblLifeTimeLow.Text = ClsLocalizationHandler.Life + " " + ClsLocalizationHandler.Time + " " +
                                     ClsLocalizationHandler.Low + " : ";
        }

        public void AddProductType(List<string> lst)
        {
            ui_ncmbProductType.Items.Clear();
            ui_ncmbProductType.Text = "";
            ui_ncmbProductType.Items.AddRange(lst.ToArray());
        }

        public void AddExpiryDate(List<string> lst)
        {
            ui_ncmbExpiryDate.Items.Clear();
            ui_ncmbExpiryDate.Text = "";
            ui_ncmbExpiryDate.Items.AddRange(lst.ToArray());
            ui_ncmbExpiryDate.SelectedIndex = 0;
        }

        public void AddProducts(List<string> lst)
        {
            ui_ncmbProduct.Items.Clear();
            ui_ncmbProduct.Text = "";
            ui_ncmbProduct.Items.AddRange(lst.ToArray());
        }

        public void AddOptionType(List<string> lst)
        {
            ui_ncmbOptType.Items.Clear();
            ui_ncmbOptType.Items.AddRange(lst.ToArray());
        }

        public void AddSeries(List<string> lst)
        {
            ui_ncmbSeries.Items.AddRange(lst.ToArray());
        }

        public void AddStrikePrice(List<string> lst)
        {
            ui_ncmbStrikePrice.Items.AddRange(lst.ToArray());
        }

        /// <summary>
        /// This method adds columns to the user grid control at run time
        /// </summary>
        public void AddColumnsToGrid()
        {
            ui_uctlGridLeft.Columns.Clear();
            ui_uctlGridRight.Columns.Clear();
            var columnsArrayLeft = new DataGridViewColumn[5];
            var intCellStyle = new DataGridViewCellStyle();
            intCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            columnsArrayLeft[0] = ClsCommonMethods.CreateGridColumn(columnsArrayLeft[0], "ClmKey", "Key");
            columnsArrayLeft[1] = ClsCommonMethods.CreateGridColumn(columnsArrayLeft[1], "ClmNoOfOrder", "NoOfOrder");
            columnsArrayLeft[1].DefaultCellStyle = intCellStyle;
            columnsArrayLeft[2] = ClsCommonMethods.CreateGridColumn(columnsArrayLeft[2], "ClmLots", "Lots");
            columnsArrayLeft[2].DefaultCellStyle = intCellStyle;
            columnsArrayLeft[3] = ClsCommonMethods.CreateGridColumn(columnsArrayLeft[3], "ClmPrice", "Price");
            columnsArrayLeft[3].DefaultCellStyle = intCellStyle;
            columnsArrayLeft[4] = ClsCommonMethods.CreateGridColumn(columnsArrayLeft[3], "ClmMarketDepth", "Market Depth");
            columnsArrayLeft[4].DefaultCellStyle = intCellStyle;

            ui_uctlGridLeft.AddColumns(columnsArrayLeft);

            ui_uctlGridLeft.Columns[0].Visible = false;

            var columnsArrayRight = new DataGridViewColumn[5];

            columnsArrayRight[0] = ClsCommonMethods.CreateGridColumn(columnsArrayRight[0], "ClmKey", "Key");
            columnsArrayRight[1] = ClsCommonMethods.CreateGridColumn(columnsArrayRight[1], "ClmPrice", "Price");
            columnsArrayRight[1].DefaultCellStyle = intCellStyle;
            columnsArrayRight[2] = ClsCommonMethods.CreateGridColumn(columnsArrayRight[2], "ClmLots", "Lots");
            columnsArrayRight[2].DefaultCellStyle = intCellStyle;
            columnsArrayRight[3] = ClsCommonMethods.CreateGridColumn(columnsArrayRight[3], "ClmNoOfOrder", "NoOfOrder");
            columnsArrayRight[3].DefaultCellStyle = intCellStyle;
            columnsArrayLeft[4] = ClsCommonMethods.CreateGridColumn(columnsArrayLeft[3], "ClmMarketDepth", "Market Depth");
            columnsArrayLeft[4].DefaultCellStyle = intCellStyle;

            ui_uctlGridRight.AddColumns(columnsArrayRight);

            ui_uctlGridRight.Columns[0].Visible = false;
        }

        /// <summary>
        /// Task to be performed on control load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uctlMarketPicture_Load(object sender, EventArgs e)
        {
            //ui_ncmbExpiryDate.SelectedIndex = 0;
            ui_ncmbProductType.SelectedIndex = 0;
            ui_ncmbOptType.SelectedIndex = 0;
            ui_ncmbSeries.SelectedIndex = 0;
            ui_ncmbStrikePrice.SelectedIndex = 0;
            ui_ncmbProduct.SelectedIndex = 0;        
            //SetLocalization();
            //AddColumnsToGrid();
        }

        private void ui_ncmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ui_ncmbProductType.SelectedItem != null && ui_ncmbProduct.SelectedItem != null)
                OnProductSelectedIndexChanged(ui_ncmbProductType.SelectedItem.ToString(),
                                              ui_ncmbProduct.SelectedItem.ToString());
        }

        private void ui_ncmbProduct_TextChanged(object sender, EventArgs e)
        {
            if (ui_ncmbProductType.SelectedItem != null && ui_ncmbProduct.SelectedItem != null)
            {
                OnProductTextChanged(ui_ncmbProductType.SelectedItem.ToString(), ui_ncmbProduct.SelectedItem.ToString());
            }
        }

        private void ui_ncmbExpiryDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ui_ncmbProductType.SelectedItem != null)
            {
                OnExpiryDateSelectedIndexChanged(ui_ncmbProductType.SelectedItem.ToString(), ui_ncmbProduct.Text,
                                                 ui_ncmbExpiryDate.SelectedItem.ToString());
            }
        }

        private void ui_ncmbProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ui_ncmbProductType.SelectedItem != null)
            {
                OnProductTypeSelectedIndexChanged(ui_ncmbProductType.SelectedItem.ToString());
            }
        }

        public void SetProductValues(string productType, string product)
        {
            if (!ui_ncmbProductType.Items.Contains(productType))
            {
                ui_ncmbProductType.Items.Add(productType);
            }
            ui_ncmbProductType.SelectedItem = productType;
            //ui_ncmbProductType.Text = productType;
            ui_ncmbProduct.Text = product;
        }

        public void SetExpiryDate(string expiryDate)
        {
            ui_ncmbExpiryDate.Items.Clear();
            ui_ncmbExpiryDate.Items.Add(expiryDate);
            ui_ncmbExpiryDate.SelectedIndex = 0;
            //ui_ncmbExpiryDate.Text =Convert.ToDateTime(expiryDate).ToShortDateString();
        }

        #endregion "      METHODS       "

        #region "      EVENTS       "

        public event Action<string, string> OnProductTextChanged = delegate { };
        public event Action<string, string> OnProductSelectedIndexChanged = delegate { };
        public event Action<string, string, string> OnExpiryDateSelectedIndexChanged = delegate { };
        public event Action<string> OnProductTypeSelectedIndexChanged = delegate { };

        #endregion "  EVENTS     "

        private void ui_uctlGridLeft_MouseEnter(object sender, EventArgs e)
        {
        }

        private void ui_uctlGridLeft_OnGridCellEnter(object arg1, DataGridViewCellEventArgs arg2)
        {
            ui_uctlGridLeft.Rows[arg2.RowIndex].Cells[arg2.ColumnIndex].ToolTipText =
                "Buy Side - No of Orders, Quantity, Price";
        }

        private void ui_uctlGridRight_OnGridCellEnter(object arg1, DataGridViewCellEventArgs arg2)
        {
            ui_uctlGridRight.Rows[arg2.RowIndex].Cells[arg2.ColumnIndex].ToolTipText =
                "Sell Side - Price, Quantity, No of Orders";
        }
    }
}