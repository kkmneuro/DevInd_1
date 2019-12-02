///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION
//17/01/2012	VP		    1.Designing and Coding of control
//02/02/2012	VP		    1.Commenting of the code
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Windows.Forms;
using CommonLibrary.Cls;

namespace CommonLibrary.UserControls
{
    public partial class UctlIndexView : UctlBase
    {
        #region    "      MEMBERS       "

        private string _title = "Index View";

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
        public UctlIndexView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor for initilizing the components of the uctlAlertDialog with customised settings
        /// </summary>
        /// <param name="customizeSettings"></param>
        public UctlIndexView(object customizeSettings)
        {
        }

        #endregion "          CONSTRUCTOR            "

        #region    "      METHODS       "

        /// <summary>
        /// Sets the text of the controls corresponding the localize value
        /// </summary>
        public override void SetLocalization()
        {
            Title = ClsLocalizationHandler.Index + " " + ClsLocalizationHandler.View;
        }

        /// <summary>
        /// Task to be performed on control load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uctlIndexView_Load(object sender, EventArgs e)
        {
            SetLocalization();
            AddColumnsToGrid();
        }

        /// <summary>
        /// This method adds columns to the user grid control at run time
        /// </summary>
        public void AddColumnsToGrid()
        {
            var columnsArray = new DataGridViewColumn[13];

            columnsArray[0] = ClsCommonMethods.CreateGridColumn(columnsArray[0], "clmIndex", "Index");
            columnsArray[1] = ClsCommonMethods.CreateGridColumn(columnsArray[1], "clmType", "Type");
            columnsArray[2] = ClsCommonMethods.CreateGridColumn(columnsArray[2], "clmCurrent", "Current");
            columnsArray[3] = ClsCommonMethods.CreateGridColumn(columnsArray[3], "clmChangeInAmmount",
                                                                "Change in Ammount");
            columnsArray[4] = ClsCommonMethods.CreateGridColumn(columnsArray[4], "clmChange", "%Change");
            columnsArray[5] = ClsCommonMethods.CreateGridColumn(columnsArray[5], "clmOpen", "Open");
            columnsArray[6] = ClsCommonMethods.CreateGridColumn(columnsArray[6], "clmHigh", "High");
            columnsArray[7] = ClsCommonMethods.CreateGridColumn(columnsArray[7], "clmLow", "Low");
            columnsArray[8] = ClsCommonMethods.CreateGridColumn(columnsArray[8], "clmClose", "Close");
            columnsArray[9] = ClsCommonMethods.CreateGridColumn(columnsArray[9], "clmWeeksHigh", "52 Weeks High");
            columnsArray[10] = ClsCommonMethods.CreateGridColumn(columnsArray[10], "clmWeeksLow", "52 Weeks Low");
            columnsArray[11] = ClsCommonMethods.CreateGridColumn(columnsArray[11], "clmLastUpdateTime",
                                                                 "Last Update Time");
            columnsArray[12] = ClsCommonMethods.CreateGridColumn(columnsArray[12], "clmImage", "",
                                                                 new DataGridViewImageColumn());

            ui_uctlGridIndexView.AddColumns(columnsArray);
        }

        #endregion "      METHODS       "
    }
}