//<Revision History>

//Date : 05/01/2012
//Author Name : Vijay Prakash Singh
//Description : Created uctlTerminalWindowAccountStatement control and define its functionality 

//</Revision History>

using System;
using System.Drawing;
using System.Windows.Forms;
using CommonLibrary.Cls;

namespace CommonLibrary.UserControls
{
    public partial class uctlTerminalWindowAccountStatement : UctlBase
    {
        #region    "      MEMBERS       "

        private int FixedRow;
        //int BelowAdd;
        private int TextStatusRowIndexFromTop = 1;
        private string _title = "Account Statement";

        #endregion "      MEMBERS       "

        #region    "      PROPERTY      "

        /// <summary>
        /// This property sets and gets the title of the uctlTerminalWindowAccountStatement control
        /// </summary>
        public override string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        #endregion "      PROPERTY      "

        #region "    CONSTRUCTOR     "

        /// <summary>
        /// Constructor for initilizing the components of the uctlTerminalWindowAccountStatement 
        /// </summary>
        public uctlTerminalWindowAccountStatement()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Constructor for initilizing the components of the uctlTerminalWindowAccountStatement with customised settings
        /// </summary>
        /// <param name="customizeSettings"></param>
        public uctlTerminalWindowAccountStatement(object customizeSettings)
        {
        }

        #endregion "       CONSTRUCTOR        "

        #region    "      METHODS       "

        /// <summary>
        /// this method creates the context menu in Terminal Account Statement Window control at the loading time.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_uctlGridAccountStatement_Load(object sender, EventArgs e)
        {
            CreateContextMenu();
        }

        /// <summary>
        /// Sets the text of controls corresponding to localized value
        /// </summary>
        public override void SetLocalization()
        {
            Title = ClsLocalizationHandler.Account + " " + ClsLocalizationHandler.Statement;
        }


        /// <summary>
        /// This method loads the predefined controls at loading of this user control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uctlTerminalWindowAccountStatement_Load(object sender, EventArgs e)
        {
            ui_uctlGridAccountStatement.IsRowHeadersVisible = false;
            ui_uctlGridAccountStatement.AllowUserToAddRows = false;
            AddColumnsToGrid();
            ui_uctlGridAccountStatement.Rows.Add();
            SetStatusLabelElements();
        }

        /// <summary>
        /// This method adds columns to the user grid control at run time
        /// </summary>
        public void AddColumnsToGrid()
        {
            var columnsArray = new DataGridViewColumn[14];

            columnsArray[0] = CreateGridColumn(columnsArray[0], "clmOrder", "Order");
            columnsArray[1] = CreateGridColumn(columnsArray[1], "clmEntryTime", "Entry Time");
            columnsArray[2] = CreateGridColumn(columnsArray[2], "clmType", "Type");
            columnsArray[3] = CreateGridColumn(columnsArray[3], "clmSizer", "Size");
            columnsArray[4] = CreateGridColumn(columnsArray[4], "clmSymbol", "Symbol");
            columnsArray[5] = CreateGridColumn(columnsArray[5], "clmEnteredPrice", "Entered Price");
            columnsArray[6] = CreateGridColumn(columnsArray[6], "clmSL", "S/L");
            columnsArray[7] = CreateGridColumn(columnsArray[7], "clmTP", "T/P");
            columnsArray[8] = CreateGridColumn(columnsArray[8], "clmOrder", "Close Time");
            columnsArray[9] = CreateGridColumn(columnsArray[9], "clmCloseTime", "Close Price");
            columnsArray[10] = CreateGridColumn(columnsArray[10], "clmCommission", "Commission");
            columnsArray[11] = CreateGridColumn(columnsArray[11], "clmSwap", "Swap");
            columnsArray[12] = CreateGridColumn(columnsArray[12], "clmProfitUSD", "ProfitUSD");
            columnsArray[13] = CreateGridColumn(columnsArray[13], "clmProfitPIP", "ProfitPIP");

            ui_uctlGridAccountStatement.AddColumns(columnsArray);
        }

        /// <summary>
        /// This method adds columns to the user grid control at run time
        /// </summary>
        /// <param name="column"></param>
        /// <param name="columnName"></param>
        /// <param name="headerText"></param>
        /// <returns></returns>
        public DataGridViewColumn CreateGridColumn(DataGridViewColumn column, string columnName, string headerText)
        {
            column = new DataGridViewTextBoxColumn();
            column.Name = columnName;
            column.HeaderText = headerText;

            return column;
        }

        /// <summary>
        /// This method calls SetLocationOflblStatus() to set location of ui_nrlblStatus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_uctlGridAccountStatement_Paint(object sender, PaintEventArgs e)
        {
            SetLocationOflblStatus();
        }

        /// <summary>
        /// This method set location of ui_nrlblStatus at run time
        /// </summary>
        public void SetLocationOflblStatus()
        {
            if (ui_uctlGridAccountStatement.Rows.Count > 0)
                TextStatusRowIndexFromTop = FixedRow - ui_uctlGridAccountStatement.FirstDisplayedScrollingRowIndex;
            ui_nrlblStatus.Size = new Size(ui_uctlGridAccountStatement.DisplayRectangle.Width,
                                           ui_uctlGridAccountStatement.Rows[FixedRow].Height + 1);
            //ui_nrlblStatus.Location = new Point(ui_uctlGridAccountStatement.Location.X, ui_uctlGridAccountStatement.Location.Y - 1 + (TextStatusRowIndexFromTop * (ui_uctlGridAccountStatement.Rows[FixedRow].Height) + 1) + ui_uctlGridAccountStatement.ColumnHeadersHeight);
            ui_nrlblStatus.Location = new Point(ui_uctlGridAccountStatement.Location.X,
                                                (ui_uctlGridAccountStatement.Location.Y +
                                                 ui_uctlGridAccountStatement.ColumnHeaderHeight) +
                                                (ui_uctlGridAccountStatement.Rows[FixedRow].Height*
                                                 (TextStatusRowIndexFromTop)));
        }

        /// <summary>
        /// This method adds row in the data grid view
        /// </summary>
        /// <param name="row"></param>
        public void AddRowInGrid(DataGridViewRow row)
        {
            ui_uctlGridAccountStatement.Rows.Insert(FixedRow, row); //.SetValues("1", "USD", "5555");
            ui_uctlGridAccountStatement.Rows.Insert(FixedRow + 1, "");
            FixedRow++;
        }

        /// <summary>
        /// This method calls AddLabelToStatus() to add labels to the satus label at specified location
        /// </summary>
        private void SetStatusLabelElements()
        {
            int xLocation;

            AddLabelToStatus(ui_lblProfitLoss, 0, 5);
            xLocation = ui_lblProfitLoss.Location.X + ui_lblProfitLoss.Width;
            AddLabelToStatus(ui_lblProfitLossvalue, xLocation, 5);
            xLocation += ui_lblProfitLossvalue.Width;
            AddLabelToStatus(ui_lblCredit, xLocation, 5);
            xLocation += ui_lblCredit.Width;
            AddLabelToStatus(ui_lblCreditValue, xLocation, 5);
            xLocation += ui_lblCreditValue.Width;
            AddLabelToStatus(ui_lblDeposit, xLocation, 5);
            xLocation += ui_lblDeposit.Width;
            AddLabelToStatus(ui_lblDepositValue, xLocation, 5);
            xLocation += ui_lblDepositValue.Width;
            AddLabelToStatus(ui_lblWithdrawl, xLocation, 5);
            xLocation += ui_lblWithdrawl.Width;
            AddLabelToStatus(ui_lblWithdrawlValue, xLocation, 5);
            AddLabelToStatus(ui_lblProfitUSD, ui_uctlGridAccountStatement.Width - 90, 5);
            AddLabelToStatus(ui_lblProfitPIP, ui_uctlGridAccountStatement.Width, 5);

            //ui_nrlblStatus.Invalidate();
        }

        /// <summary>
        /// This method adds elements to status label
        /// </summary>
        /// <param name="lbl"></param>
        /// <param name="locationX"></param>
        /// <param name="locationY"></param>
        public void AddLabelToStatus(Label lbl, int locationX, int locationY)
        {
            lbl.Location = new Point(locationX, locationY);
            ui_nrlblStatus.Controls.Add(lbl);
        }

        /// <summary>
        ///  Populated the items of contextmenustrip associated with the grid
        /// </summary>
        public void CreateContextMenu()
        {
            var ContextMenuItems = new ToolStripMenuItem[10];

            ContextMenuItems[0] = new ToolStripMenuItem("All History");
            ContextMenuItems[0].Click += OnAllHistoryClick;
            ContextMenuItems[1] = new ToolStripMenuItem("Last 3 Months");
            ContextMenuItems[1].Click += OnLast3MonthsClick;
            ContextMenuItems[2] = new ToolStripMenuItem("Last Month");
            ContextMenuItems[2].Click += OnLastMonthClick;
            ContextMenuItems[3] = new ToolStripMenuItem("Custom Period");
            ContextMenuItems[3].Click += OnCustomPeriodClick;
            ContextMenuItems[4] = new ToolStripMenuItem("Save as Report");
            ContextMenuItems[4].Click += OnSaveAsReportClick;
            ContextMenuItems[5] = new ToolStripMenuItem("Save as Detailed Report");
            ContextMenuItems[5].Click += OnSaveAsDetailedReportClick;
            ContextMenuItems[6] = new ToolStripMenuItem("Commissions");
            ContextMenuItems[6].Click += OnCommissionsClick;
            ContextMenuItems[7] = new ToolStripMenuItem("Taxes");
            ContextMenuItems[7].Click += OnTaxesClick;
            ContextMenuItems[8] = new ToolStripMenuItem("Comments");
            ContextMenuItems[8].Click += OnCommentsClick;
            ContextMenuItems[9] = new ToolStripMenuItem("Auto Arrange");
            ContextMenuItems[9].Click += OnAutoArrangeClick;


            ui_uctlGridAccountStatement.ContextMenuStrip.Items.AddRange(ContextMenuItems);
        }

        /// <summary>
        /// Called when All History item of the contextmenustrip is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnAllHistoryClick(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Called when Last 3 Months item of the contextmenustrip is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLast3MonthsClick(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Called when Last Month item of the contextmenustrip is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLastMonthClick(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Called when Custom Period item of the contextmenustrip is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCustomPeriodClick(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Called when Save as Report item of the contextmenustrip is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSaveAsReportClick(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Called when Save as detaile Report item of the contextmenustrip is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSaveAsDetailedReportClick(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Called when Commissions item of the contextmenustrip is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCommissionsClick(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Called when Taxes item of the contextmenustrip is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTaxesClick(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Called when Comments item of the contextmenustrip is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCommentsClick(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Called when Auto Arrange item of the contextmenustrip is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnAutoArrangeClick(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Called when the column header is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_uctlGridAccountStatement_OnColumnHeaderClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Sort();
        }

        /// <summary>
        /// Code for sorting the rows of the grid
        /// </summary>
        private void Sort()
        {
            //Code for sorting rows of grid
        }

        #endregion "      METHODS       "
    }
}