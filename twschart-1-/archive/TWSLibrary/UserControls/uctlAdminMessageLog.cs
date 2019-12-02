using System;
using System.Windows.Forms;
using CommonLibrary.Cls;

namespace CommonLibrary.UserControls
{
    public partial class UctlAdminMessageLog : UctlBase
    {
        #region    "        MEMBERS           "

        private string _title = "Admin Messages Log";

        #endregion "        MEMBERS           "

        #region    "        PROPERTY          "

        /// <summary>
        /// This property sets and gets the title of the uctlAdminMessageLog control
        /// </summary>
        public override string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        #endregion    "        PROPERTY          "

        #region "        CONSTRUCTOR       "

        /// <summary>
        /// Constructor for initilizing the components of the uctlAdminMessageLog 
        /// </summary>
        public UctlAdminMessageLog()
        {
            InitializeComponent();
        }

        #endregion "    CONSTRUCTOR     "

        #region   "        METHODS          "

        public void AddColumnsToGrid()
        {
            var columnsArray = new DataGridViewColumn[3];

            columnsArray[0] = ClsCommonMethods.CreateGridColumn(columnsArray[0], "Time", "Time");
            columnsArray[1] = ClsCommonMethods.CreateGridColumn(columnsArray[1], "Subject", "Subject");
            columnsArray[2] = ClsCommonMethods.CreateGridColumn(columnsArray[2], "Message", "Message");

            ui_uctlGridAdminMessageLog.AddColumns(columnsArray);
            ui_uctlGridAdminMessageLog.Columns[0].Width = 100;
            ui_uctlGridAdminMessageLog.Columns[1].Width = 120;
        }

        /// <summary>
        /// Sets the text of the controls corresponding to their localized value
        /// </summary>
        public override void SetLocalization()
        {
            _title = ClsLocalizationHandler.Admin + " " + ClsLocalizationHandler.Message + " " +
                     ClsLocalizationHandler.Log;

            ui_uctlGridAdminMessageLog.Columns[0].HeaderText = ClsLocalizationHandler.Time;
            ui_uctlGridAdminMessageLog.Columns[1].HeaderText = ClsLocalizationHandler.Subject;
            ui_uctlGridAdminMessageLog.Columns[2].HeaderText = ClsLocalizationHandler.Message;
        }

        /// <summary>
        /// Populated the items of contextmenustrip associated with the grid
        /// </summary>
        public void CreateContextMenu()
        {
            var ContextMenuItems = new ToolStripMenuItem[2];

            ContextMenuItems[0] = new ToolStripMenuItem("Title Bar");
            ContextMenuItems[0].Click += OnTitleBarClick;
            ContextMenuItems[1] = new ToolStripMenuItem("Customize");
            ContextMenuItems[1].Click += OnCustomizeClick;

            ui_uctlGridAdminMessageLog.ContextMenuStrip.Items.AddRange(ContextMenuItems);
        }

        /// <summary>
        /// Called when the Title Bar item of the contextmenustrip clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTitleBarClick(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Called when the Customize item of the contextmenustrip clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCustomizeClick(object sender, EventArgs e)
        {
        }

        #endregion   "        METHODS          "

        private void uctlAdminMessageLog_Load(object sender, EventArgs e)
        {
            CreateContextMenu();
            AddColumnsToGrid();
            SetLocalization();
        }
    }
}