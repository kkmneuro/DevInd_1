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
    public partial class uctlMarketPictureNew : UctlBase
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
     
        #endregion "      PROPERTY      "

        #region "     CONSTRUCTOR    "

        /// <summary>
        /// Constructor for initilizing the components of the uctlMarketPicture 
        /// </summary>
        public uctlMarketPictureNew()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor for initilizing the components of the uctlMarketPicture with customised settings
        /// </summary>
        /// <param name="customizeSettings"></param>
        public uctlMarketPictureNew(object customizeSettings)
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
                     
        }
    
        #endregion "      METHODS       "

        #region "      EVENTS       "
        

        #endregion "  EVENTS     "

        private void ui_uctlGridLeft_MouseEnter(object sender, EventArgs e)
        {
        }

        private void ui_uctlGridLeft_OnGridCellEnter(object arg1, DataGridViewCellEventArgs arg2)
        {
            //ui_uctlGridLeft.Rows[arg2.RowIndex].Cells[arg2.ColumnIndex].ToolTipText =
            //    "Buy Side - No of Orders, Quantity, Price";
        }

        private void ui_uctlGridRight_OnGridCellEnter(object arg1, DataGridViewCellEventArgs arg2)
        {
            //ui_uctlGridRight.Rows[arg2.RowIndex].Cells[arg2.ColumnIndex].ToolTipText =
            //    "Sell Side - Price, Quantity, No of Orders";
        }
    }
}
