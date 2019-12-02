///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION
//03/01/2012	NN          1.Properties are renamed and comments are added
//07/02/2012	VP          1.Added columns to the grid of the  control
//20/02/2012	VP          1.Code for Saving Grid Data in Text format
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CommonLibrary.Cls;

namespace CommonLibrary.UserControls
{
    public partial class UctlMessagLog : UctlBase
    {
        #region    "        MEMBERS           "

        private readonly frmDialogForm _objfrmDialogForm = new frmDialogForm();
        private Keys _shortcutKeyFilter = Keys.None;
        private string _title = "Message Log";

        public Keys ShortcutKeyFilter
        {
            get { return _shortcutKeyFilter; }
            set { _shortcutKeyFilter = value; }
        }

        #endregion "        MEMBERS           "

        #region    "        PROPERTY          "

        /// <summary>
        /// This property sets and gets the title of the MessageLog control
        /// </summary>
        public override string Title
        {
            get { return _title; }
            set { _title = value; }
        }


        /// <summary>
        /// This property sets the filter information to be used with the information to be displayed in the grid
        /// </summary>
        public UctlFilter OrderFilter { get; set; }

        #endregion    "        PROPERTY          "

        #region "        CONSTRUCTOR       "

        /// <summary>
        /// Constructor for initilizing the components of the uctlMessagLog 
        /// </summary>
        public UctlMessagLog()
        {
            InitializeComponent();
        }

        #endregion "    CONSTRUCTOR     "

        #region    "        METHODS           "

        /// <summary>
        /// Populated the items of contextmenustrip associated with the grid
        /// </summary>
        public void CreateContextMenu()
        {
            var ContextMenuItems = new ToolStripMenuItem[3];
            ContextMenuItems[0] = new ToolStripMenuItem("View");
            ContextMenuItems[0].Click += OnViewClick;
            AddViewSubMenu(ContextMenuItems[0]);
            ContextMenuItems[1] = new ToolStripMenuItem("Filter");
            ContextMenuItems[1].ShortcutKeys = ShortcutKeyFilter;
            ContextMenuItems[1].Click += OnFilterClick;
            ContextMenuItems[2] = new ToolStripMenuItem("Save As");
            ContextMenuItems[2].Name = "Save As";
            AddSaveAsSubMenu(ContextMenuItems[2]);
            ui_uctlGridMessageLog.ContextMenuStrip.Items.AddRange(ContextMenuItems);
        }

        private void AddSaveAsSubMenu(ToolStripMenuItem toolStripMenuItem)
        {
            var ContextMenuItems = new ToolStripMenuItem[2];

            ContextMenuItems[0] = new ToolStripMenuItem("Excel file");
            ContextMenuItems[0].Click += OnExcelFileClick;
            ContextMenuItems[1] = new ToolStripMenuItem("Text File");
            ContextMenuItems[1].Click += OnTextFileClick;

            toolStripMenuItem.DropDownItems.AddRange(ContextMenuItems);
        }

        /// <summary>
        /// Saves grid data in Excel file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnExcelFileClick(object sender, EventArgs e)
        {
            var objSaveFileDialog = new SaveFileDialog();
            objSaveFileDialog.Filter = "Excel Files (*.xls)|*.xls";
            //"(*.xls)|*.xls |(*.xlsx)|*.xlsx";   //for all files (*.*)|*.*//for multiple file extensions  Text Files|*.txt|Image|*.png
            objSaveFileDialog.DefaultExt = ".xls";
            DialogResult objDialogResult = objSaveFileDialog.ShowDialog();
            if (objDialogResult == DialogResult.OK)
            {
                ClsCommonMethods.SaveGridDataInExcel(objSaveFileDialog.FileName, ui_uctlGridMessageLog);

                ClsCommonMethods.ShowInfoBox("Data Successfully Exported");
            }
        }

        /// <summary>
        /// Saves grid data in text file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTextFileClick(object sender, EventArgs e)
        {
            var objSaveFileDialog = new SaveFileDialog();
            objSaveFileDialog.Filter = "Text Files (*.txt)|*.txt"; //for all files (*.*)|*.*
            objSaveFileDialog.DefaultExt = ".txt";
            DialogResult objDialogResult = objSaveFileDialog.ShowDialog();
            if (objDialogResult == DialogResult.OK)
            {
                SaveGridDataInTextFile(objSaveFileDialog.FileName);
            }
        }

        /// <summary>
        /// Populated the items of sub menu of View item of contextmenustrip associated with the grid
        /// </summary>
        /// <param name="ViewItem">ToolStripMenuItem to which sub menu is to be added</param>
        public void AddViewSubMenu(ToolStripMenuItem ViewItem)
        {
            var ViewSubItems = new ToolStripMenuItem[12];
            ViewSubItems[0] = new ToolStripMenuItem("All Transaction Messages");
            ViewSubItems[0].Click += OnAllTransactionMessageClick;
            ViewSubItems[1] = new ToolStripMenuItem("Market Messages");
            ViewSubItems[1].Click += OnMarketMessageClick;
            ViewSubItems[2] = new ToolStripMenuItem("Order Messages");
            ViewSubItems[2].Click += OnOrderConfirmClick;
            ViewSubItems[3] = new ToolStripMenuItem("Trade Messages");
            ViewSubItems[3].Click += OnTradeConfirmClick;
            ViewSubItems[4] = new ToolStripMenuItem("Auction Messages");
            ViewSubItems[4].Click += OnAuctionMessageClick;
            ViewSubItems[4].Visible = false;
            ViewSubItems[5] = new ToolStripMenuItem("System Messages");
            ViewSubItems[5].Click += OnSystemMessageClick;
            ViewSubItems[6] = new ToolStripMenuItem("Surveillance Messages");
            ViewSubItems[6].Click += OnSurveillanceMessageClick;
            ViewSubItems[7] = new ToolStripMenuItem("Alert Messages");
            ViewSubItems[7].Click += OnAlertMessageClick;
            ViewSubItems[8] = new ToolStripMenuItem("Admin Messages");
            ViewSubItems[8].Click += OnAdminMessageClick;
            ViewSubItems[9] = new ToolStripMenuItem("Member Messages");
            ViewSubItems[9].Click += OnMemberMessagesClick;
            ViewSubItems[10] = new ToolStripMenuItem("News");
            ViewSubItems[10].Click += OnNewsClick;
            ViewSubItems[11] = new ToolStripMenuItem("Other Messages");
            ViewSubItems[11].Click += OnOtherMessagesClick;

            ViewItem.DropDownItems.AddRange(ViewSubItems);
        }


        private void OnMemberMessagesClick(object sender, EventArgs e)
        {
            OnMessageFilterItemClilck("Member");
        }

        private void OnNewsClick(object sender, EventArgs e)
        {
            OnMessageFilterItemClilck("News");
        }


        private void OnOtherMessagesClick(object sender, EventArgs e)
        {
            OnMessageFilterItemClilck("Other");
        }

        /// <summary>
        /// Called when the View_All Transaction Messages item of the contextmenustrip clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnAllTransactionMessageClick(object sender, EventArgs e)
        {
            OnMessageFilterItemClilck("All Transaction Messages");
        }

        public void SaveGridDataInTextFile(string fileName)
        {
            var objFileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            TextWriter objStreamWriter = new StreamWriter(objFileStream);
            int rowcount = ui_uctlGridMessageLog.Rows.Count;

            for (int i = 0; i < rowcount - 1; i++)
            {
                objStreamWriter.WriteLine(ui_uctlGridMessageLog.Rows[i].Cells[0].Value + "\t" +
                                          ui_uctlGridMessageLog.Rows[i].Cells[1].Value);
            }
            objStreamWriter.Close();

            ClsCommonMethods.ShowInfoBox("Data Successfully Exported");
        }

        /// <summary>
        /// Called when the View_Market Messages item of the contextmenustrip clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnMarketMessageClick(object sender, EventArgs e)
        {
            OnMessageFilterItemClilck("Market");
        }

        /// <summary>
        /// Called when the View_Order Confirm item of the contextmenustrip clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnOrderConfirmClick(object sender, EventArgs e)
        {
            OnMessageFilterItemClilck("Order");
        }

        /// <summary>
        /// Called when the View_Trade Confirm item of the contextmenustrip clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTradeConfirmClick(object sender, EventArgs e)
        {
            OnMessageFilterItemClilck("Trade");
        }

        /// <summary>
        /// Called when the View_System Messages item of the contextmenustrip clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSystemMessageClick(object sender, EventArgs e)
        {
            OnMessageFilterItemClilck("System");
        }

        /// <summary>
        /// Called when the View_Auction Messages item of the contextmenustrip clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnAuctionMessageClick(object sender, EventArgs e)
        {
            OnMessageFilterItemClilck("Auction");
        }

        /// <summary>
        /// Called when the View_Surveillance Messages item of the contextmenustrip clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSurveillanceMessageClick(object sender, EventArgs e)
        {
            OnMessageFilterItemClilck("Surveillance");
        }

        /// <summary>
        /// Called when the View_Alert Messages item of the contextmenustrip clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnAlertMessageClick(object sender, EventArgs e)
        {
            OnMessageFilterItemClilck("Alert");
        }

        /// <summary>
        /// Called when the View_Admin Messages item of the contextmenustrip clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnAdminMessageClick(object sender, EventArgs e)
        {
            OnMessageFilterItemClilck("Admin");
        }

        /// <summary>
        /// Called when the View item of the contextmenustrip clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnViewClick(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Called when the filter item of the contextmenustrip clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void OnFilterClick(object sender, EventArgs e)
        {
            var objUctlMessageLogFilter = new UctlMessageLogFilter();

            objUctlMessageLogFilter.OnCancelClick += objUctlMessageLogFilter_OnCancelClick;
            objUctlMessageLogFilter.OnOkClick +=
                objUctlMessageLogFilter_OnOkClick;
            _objfrmDialogForm.Controls.Clear();
            var objSize = new Size(objUctlMessageLogFilter.Width + 10,
                                   objUctlMessageLogFilter.Height + 25);
            _objfrmDialogForm.Size = objSize;
            _objfrmDialogForm.Controls.Add(objUctlMessageLogFilter);
            objUctlMessageLogFilter.Dock = DockStyle.Fill;
            _objfrmDialogForm.Text = objUctlMessageLogFilter.Title;
            _objfrmDialogForm.Sizable = false;
            _objfrmDialogForm.Location = new Point(MousePosition.X, MousePosition.Y);
            _objfrmDialogForm.ShowDialog();
        }

        private void objUctlMessageLogFilter_OnOkClick(string fromDate, string fromTime, string toDate, string toTime)
        {
            OnMessageFilterOkClick(fromDate, fromTime, toDate, toTime);
            _objfrmDialogForm.Close();
        }

        private void objUctlMessageLogFilter_OnCancelClick(object arg1, EventArgs arg2)
        {
            _objfrmDialogForm.Close();
        }


        /// <summary>
        /// Sets the text of the controls corresponding to their localized value
        /// </summary>
        public override void SetLocalization()
        {
            _title = ClsLocalizationHandler.Message + " " + ClsLocalizationHandler.Log;

            //ui_uctlGridMessageLog.Columns[0].HeaderText = Cls.clsLocalizationHandler.Time;
            //ui_uctlGridMessageLog.Columns[1].HeaderText = Cls.clsLocalizationHandler.Message;
        }

        /// <summary>
        /// this method creates the context menu in Message Log control at the loading time.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uctlMessagLog_Load(object sender, EventArgs e)
        {
            AddColumnsToGrid();
            CreateContextMenu();
            SetLocalization();
        }

        /// <summary>
        /// This method adds columns to the user grid control at run time
        /// </summary>
        public void AddColumnsToGrid()
        {
            var columnsArray = new DataGridViewColumn[5];

            columnsArray[0] = ClsCommonMethods.CreateGridColumn(columnsArray[0], "Time", "Time");
            columnsArray[0].DataPropertyName = "StrDateTime";
            columnsArray[1] = ClsCommonMethods.CreateGridColumn(columnsArray[1], "MessageType", "Message Type");
            columnsArray[1].DataPropertyName = "MessageType";
            columnsArray[2] = ClsCommonMethods.CreateGridColumn(columnsArray[1], "Message", "Message");
            columnsArray[2].DataPropertyName = "Message";
            columnsArray[3] = ClsCommonMethods.CreateGridColumn(columnsArray[2], "Account", "Account",false);
            columnsArray[3].DataPropertyName = "Account";
            columnsArray[4] = ClsCommonMethods.CreateGridColumn(columnsArray[3], "Color", "Color",false);
            columnsArray[4].DataPropertyName = "Color";

            ui_uctlGridMessageLog.AddColumns(columnsArray);
            ui_uctlGridMessageLog.Columns[0].Width = 140;
        }

        #endregion   "        METHODS          "

        public event Action<object, MouseEventArgs> OnGridMouseDown = delegate { };
        public event Action<string> OnMessageFilterItemClilck = delegate { };
        public event Action<string, string, string, string> OnMessageFilterOkClick = delegate { };

        private void ui_uctlGridMessageLog_OnGridMouseDown(object sender, MouseEventArgs e)
        {
            OnGridMouseDown(sender, e);
        }
    }
}