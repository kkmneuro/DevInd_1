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
    public partial class uctlTerminalWindowNews : UctlBase
    {
        #region    "      MEMBERS       "

        private string _title = "News";

        #endregion "      MEMBERS       "

        #region    "      PROPERTY      "

        /// <summary>
        /// Sets and gets the title of the control
        /// </summary>
        public override string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        #endregion "      PROPERTY      "

        #region "    CONSTRUCTOR     "

        /// <summary>
        /// Constructor for initilizing the components of the uctlTerminalWindowNews 
        /// </summary>
        public uctlTerminalWindowNews()
        {
            InitializeComponent();
            CreateContextMenu();
        }

        /// <summary>
        /// Constructor for initilizing the components of the uctlTerminalWindowNews with customised settings
        /// </summary>
        /// <param name="customizeSettings"></param>
        public uctlTerminalWindowNews(object customizeSettings)
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

            ContextMenuItems[0] = new ToolStripMenuItem("View");
            ContextMenuItems[0].Click += OnViewClick;
            ContextMenuItems[1] = new ToolStripMenuItem("Copy");
            ContextMenuItems[1].Click += OnCopyClick;
            ContextMenuItems[2] = new ToolStripMenuItem("Auto Arrange");
            ContextMenuItems[2].Click += OnAutoArrangeClick;
            ContextMenuItems[3] = new ToolStripMenuItem("Hide");
            ContextMenuItems[3].Click += OnHideClick;

            ui_uctlGridNews.ContextMenuStrip.Items.AddRange(ContextMenuItems);
        }

        /// <summary>
        /// Called when the Hide item of the contextmenustrip clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnHideClick(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Called when the Auto Arrange item of the contextmenustrip clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnAutoArrangeClick(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Called when the Copy item of the contextmenustrip clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCopyClick(object sender, EventArgs e)
        {
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
        /// Sets the text of the control corresponding to localized value
        /// </summary>
        public override void SetLocalization()
        {
            Title = ClsLocalizationHandler.News;

            //ui_uctlGridNews.Columns[0].HeaderText = Cls.clsLocalizationHandler.Time;
            //ui_uctlGridNews.Columns[1].HeaderText = Cls.clsLocalizationHandler.Headline;
            //ui_uctlGridNews.Columns[2].HeaderText = Cls.clsLocalizationHandler.Description;
        }

        #endregion "      METHODS       "
    }
}