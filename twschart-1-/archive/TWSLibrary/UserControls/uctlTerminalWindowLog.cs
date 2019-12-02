//<Revision History>

//Date : 02/01/2012
//Author Name : Vijay Prakash Singh
//Description : Added comment to properties

//</Revision History>

using System;
using System.Windows.Forms;
using CommonLibrary.Cls;

namespace CommonLibrary.UserControls
{
    public partial class uctlTerminalWindowLog : UctlBase
    {
        #region    "      MEMBERS       "

        private string _title = "Log";

        #endregion "      MEMBERS       "

        #region    "      PROPERTY      "

        /// <summary>
        /// Sets and gets the title of the TerminalWindowLog control
        /// </summary>
        public override string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        #endregion "      PROPERTY      "

        #region "    CONSTRUCTOR     "

        /// <summary>
        /// Constructor for initilizing the components of the uctlTerminalWindowLog 
        /// </summary>
        public uctlTerminalWindowLog()
        {
            InitializeComponent();
            CreateContextMenu();
        }

        /// <summary>
        /// Constructor for initilizing the components of the uctlTerminalWindowLog with customised settings
        /// </summary>
        /// <param name="customizeSettings"></param>
        public uctlTerminalWindowLog(object customizeSettings)
        {
        }

        #endregion "       CONSTRUCTOR        "

        #region    "      METHODS       "

        /// <summary>
        /// Populated the items of contextmenustrip associated with the grid
        /// </summary>
        public void CreateContextMenu()
        {
            var ContextMenuItems = new ToolStripMenuItem[4];

            ContextMenuItems[0] = new ToolStripMenuItem("Open");
            ContextMenuItems[0].Click += OnOpenClick;
            ContextMenuItems[1] = new ToolStripMenuItem("Copy");
            ContextMenuItems[1].Click += OnCopyClick;
            ContextMenuItems[2] = new ToolStripMenuItem("Auto Scroll");
            ContextMenuItems[2].Click += OnAutoScrollClick;
            ContextMenuItems[3] = new ToolStripMenuItem("Auto Arrange");
            ContextMenuItems[3].Click += OnAutoArrangeClick;

            ui_uctlGridLog.ContextMenuStrip.Items.AddRange(ContextMenuItems);
        }

        /// <summary>
        /// Called when the Open item of the contextmenustrip clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnAutoScrollClick(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Called when the Copy item of the contextmenustrip clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnAutoArrangeClick(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Called when the Auto Scroll item of the contextmenustrip clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnOpenClick(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Called when the Auto Arrange item of the contextmenustrip clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCopyClick(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Sets the text of the controls corresponding to localized value
        /// </summary>
        public override void SetLocalization()
        {
            Title = ClsLocalizationHandler.Log;

            ui_uctlGridLog.Columns[0].HeaderText = ClsLocalizationHandler.Time;
            ui_uctlGridLog.Columns[1].HeaderText = ClsLocalizationHandler.Message;
        }

        #endregion "      METHODS       "
    }
}