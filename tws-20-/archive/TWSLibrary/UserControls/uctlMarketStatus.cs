///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION
//02/02/2012	VP		    1.Commenting of the code
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Windows.Forms;
using CommonLibrary.Cls;
using System.Drawing;

namespace CommonLibrary.UserControls
{
    public partial class UctlMarketStatus : UctlBase
    {
        #region    "      MEMBERS       "

        private string _title = "Market Status";

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
        public UctlMarketStatus()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor for initilizing the components of the uctlAlertDialog with customised settings
        /// </summary>
        /// <param name="customizeSettings"></param>
        public UctlMarketStatus(object customizeSettings)
        {
        }

        #endregion "          CONSTRUCTOR            "

        #region    "      METHODS       "

        /// <summary>
        /// Sets the text of the controls corresponding the localize value
        /// </summary>
        public override void SetLocalization()
        {
            Title = ClsLocalizationHandler.Market + " " + ClsLocalizationHandler.Status;
        }

        /// <summary>
        /// This method adds columns to the user grid control at run time
        /// </summary>
        public void AddColumnsToGrid()
        {
            var columnsArray = new DataGridViewColumn[3];

            columnsArray[0] = ClsCommonMethods.CreateGridColumn(columnsArray[0], "clmMarketType", "Market Type");
            columnsArray[1] = ClsCommonMethods.CreateGridColumn(columnsArray[1], "clmStatus", "Status");
            columnsArray[2] = ClsCommonMethods.CreateGridColumn(columnsArray[2], "clmSessionID", "Session ID",false);


            ui_uctlGridMarketStatus.AddColumns(columnsArray);
        }

        #endregion "      METHODS       "

        /// <summary>
        /// Task to be performed on control load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uctlMarketStatus_Load(object sender, EventArgs e)
        {
            AddColumnsToGrid();
            SetLocalization();
            ui_uctlGridMarketStatus.BackgroundColor = Color.White;
        }
    }
}