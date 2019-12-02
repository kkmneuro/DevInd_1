//<Revision History>

//Date : 06/01/2012
//Author Name : Vijay Prakash Singh
//Description : Created uctlTerminalWindowTrade control and define its functionality 

//</Revision History>

using System;
using System.Drawing;
using System.Windows.Forms;

namespace CommonLibrary.UserControls
{
    public partial class uctlTerminalWindowTrade : UctlBase
    {
        #region   "        MEMBERS        "

        private int FixedRow;
        //int BelowAdd;
        private int TextStatusRowIndexFromTop = 1;
        private string _title = "Trade";

        #endregion"        MEMBERS        "

        #region "     CONSTRUCTOR       "

        /// <summary>
        /// Constructor for initilizing the components of the uctlTerminalWindowTrade 
        /// </summary>
        public uctlTerminalWindowTrade()
        {
            InitializeComponent();
        }

        /// <summary>
        ///  Constructor for initilizing the components of the uctlTerminalWindowTrade with customised settings
        /// </summary>
        /// <param name="cutomizeSettings"></param>
        public uctlTerminalWindowTrade(object cutomizeSettings)
        {
        }

        #endregion "    CONSTRUCTOR     "

        #region    "      PROPERTY      "

        /// <summary>
        /// This property sets and gets the title of the uctlTerminalWindowTrade control
        /// </summary>
        public override string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        #endregion "      PROPERTY      "

        #region    "      METHODS       "

        /// <summary>
        /// This method loads the predefined controls at loading of this user control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uctlTerminalWindowTrade_Load(object sender, EventArgs e)
        {
            ui_uctlGridTrade.IsRowHeadersVisible = false;
            AddColumnsToGrid();
            ui_uctlGridTrade.Rows.Add();
            SetStatusLabelElements();
        }

        /// <summary>
        /// This method adds columns to the user grid control at run time by calling CreateGridColumn()
        /// </summary>
        public void AddColumnsToGrid()
        {
            var columnsArray = new DataGridViewColumn[18];

            columnsArray[0] = CreateGridColumn(columnsArray[0], "clmOrderID", "OrderID");
            columnsArray[1] = CreateGridColumn(columnsArray[1], "clmTime", "Time");
            columnsArray[2] = CreateGridColumn(columnsArray[2], "clmType", "Type");
            columnsArray[3] = CreateGridColumn(columnsArray[3], "clmSymbol", "Symbol");
            columnsArray[4] = CreateGridColumn(columnsArray[4], "clmPositionSize", "PositionSize");
            columnsArray[5] = CreateGridColumn(columnsArray[5], "clmPrice", "Price");
            columnsArray[6] = CreateGridColumn(columnsArray[6], "clmRealValues", "Real Values");
            columnsArray[7] = CreateGridColumn(columnsArray[7], "clmYourMoneyUsed", "YourMoneyUsed");
            columnsArray[8] = CreateGridColumn(columnsArray[8], "clmCurrencyMarketPrice", "CurrentMarketPrice");
            columnsArray[9] = CreateGridColumn(columnsArray[9], "clmStopLoss", "StopLoss");
            columnsArray[10] = CreateGridColumn(columnsArray[10], "clmTakeProfit", "TakeProfit");
            columnsArray[11] = CreateGridColumn(columnsArray[11], "clmSwap", "Swap");
            columnsArray[12] = CreateGridColumn(columnsArray[12], "clmCommission", "Commission");
            columnsArray[13] = CreateGridColumn(columnsArray[13], "clmProfitUSD", "ProfitUSD");
            columnsArray[14] = CreateGridColumn(columnsArray[14], "clmProfitPIP", "ProfitPIP");
            columnsArray[15] = CreateGridColumn(columnsArray[15], "clmCheck", "Check");
            columnsArray[16] = CreateGridColumn(columnsArray[16], "clmClose", "Close");
            columnsArray[17] = CreateGridColumn(columnsArray[17], "clmReverse", "Reverse");

            ui_uctlGridTrade.AddColumns(columnsArray);
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
        private void ui_uctlGridTrade_Paint(object sender, PaintEventArgs e)
        {
            SetLocationOflblStatus();
        }

        /// <summary>
        /// This method set location of ui_nrlblStatus at run time
        /// </summary>
        public void SetLocationOflblStatus()
        {
            if (ui_uctlGridTrade.Rows.Count > 0)
                TextStatusRowIndexFromTop = FixedRow - ui_uctlGridTrade.FirstDisplayedScrollingRowIndex;
            ui_nrlblStatus.Size = new Size(ui_uctlGridTrade.DisplayRectangle.Width,
                                           ui_uctlGridTrade.Rows[FixedRow].Height + 1);
            //ui_nrlblStatus.Location = new Point(ui_uctlGridAccountStatement.Location.X, ui_uctlGridAccountStatement.Location.Y - 1 + (TextStatusRowIndexFromTop * (ui_uctlGridAccountStatement.Rows[FixedRow].Height) + 1) + ui_uctlGridAccountStatement.ColumnHeadersHeight);
            ui_nrlblStatus.Location = new Point(ui_uctlGridTrade.Location.X,
                                                (ui_uctlGridTrade.Location.Y + ui_uctlGridTrade.ColumnHeaderHeight) +
                                                (ui_uctlGridTrade.Rows[FixedRow].Height*(TextStatusRowIndexFromTop)));
        }

        /// <summary>
        /// This method adds row before status label in the data grid view
        /// </summary>
        /// <param name="row"></param>
        public void AddRowBeforeStatusInGrid(DataGridViewRow row)
        {
            ui_uctlGridTrade.Rows.Insert(FixedRow, row); //.SetValues("1", "USD", "5555");
            ui_uctlGridTrade.Rows.Insert(FixedRow + 1, "");
            FixedRow++;
        }

        /// <summary>
        /// This method adds row after status label in the data grid view
        /// </summary>
        /// <param name="row"></param>
        public void AddRowAfterStatusInGrid(DataGridViewRow row)
        {
            ui_uctlGridTrade.Rows.Insert(FixedRow + 1, row);
        }

        /// <summary>
        /// This method calls AddLabelToStatus() to add labels to the satus label at specified location
        /// </summary>
        private void SetStatusLabelElements()
        {
            AddLabelToStatus(ui_lblTotalPendingOrders, 0, 5);
            int xLocation = ui_lblTotalPendingOrders.Location.X + ui_lblTotalPendingOrders.Width;
            AddLabelToStatus(ui_lblTotalPendingOrdersValues, xLocation, 5);
            AddLabelToStatus(ui_lblProfitUSD, ui_uctlGridTrade.Width - 240, 5);
            AddLabelToStatus(ui_lblProfitPIP, ui_uctlGridTrade.Width - 180, 5);

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
            var ContextMenuItems = new ToolStripMenuItem[6];

            ContextMenuItems[0] = new ToolStripMenuItem("New Order");
            ContextMenuItems[0].Click += OnNewOrderClick;
            ContextMenuItems[1] = new ToolStripMenuItem("Close");
            ContextMenuItems[1].Click += OnCloseClick;
            ContextMenuItems[2] = new ToolStripMenuItem("Close All");
            ContextMenuItems[2].Click += OnCloseAllClick;
            ContextMenuItems[3] = new ToolStripMenuItem("Close All Checked");
            ContextMenuItems[3].Click += OnCloseAllCheckedClick;
            ContextMenuItems[4] = new ToolStripMenuItem("Modify");
            ContextMenuItems[4].Click += OnModifyClick;
            ContextMenuItems[5] = new ToolStripMenuItem("Select All");
            ContextMenuItems[5].Click += OnSelectAllClick;


            ui_uctlGridTrade.ContextMenuStrip.Items.AddRange(ContextMenuItems);
        }

        /// <summary>
        /// Called when New Order item of the contextmenustrip is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnNewOrderClick(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Called when Close item of the contextmenustrip is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCloseClick(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Called when Close All item of the contextmenustrip is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCloseAllClick(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Called when Close All Checked item of the contextmenustrip is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCloseAllCheckedClick(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Called when Modify item of the contextmenustrip is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnModifyClick(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Called when Select All item of the contextmenustrip clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSelectAllClick(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// this method creates the context menu in Terminal Trade Window control at the loading time.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_uctlGridTrade_Load(object sender, EventArgs e)
        {
            CreateContextMenu();
        }

        /// <summary>
        /// Sets the text of controls corresponding to localized value
        /// </summary>
        public override void SetLocalization()
        {
        }

        /// <summary>
        /// Called when the column header is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_uctlGridTrade_OnColumnHeaderClick(object sender, DataGridViewCellMouseEventArgs e)
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

        #endregion    "      METHODS       "  
    }
}