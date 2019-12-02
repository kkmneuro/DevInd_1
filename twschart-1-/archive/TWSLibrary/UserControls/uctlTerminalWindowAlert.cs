//<Revision History>

//Date : 02/01/2012
//Author Name : Vijay Prakash Singh
//Description : Added comment to properties

//</Revision History>

using System;
using System.Drawing;
using System.Windows.Forms;
using CommonLibrary.Cls;

namespace CommonLibrary.UserControls
{
    public partial class uctlTerminalWindowAlert : UctlBase
    {
        #region    "      MEMBERS       "

        private string _title = "Alert";

        #endregion "      MEMBERS       "

        #region    "      PROPERTY      "

        /// <summary>
        /// Sets and gets the title of the TerminalWindowAlert control
        /// </summary>
        public override string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        #endregion "      PROPERTY      "

        #region "    CONSTRUCTOR     "

        /// <summary>
        /// Constructor for initilizing the components of the uctlTerminalWindowAlert 
        /// </summary>
        public uctlTerminalWindowAlert()
        {
            InitializeComponent();
            CreateContextMenu();
        }

        /// <summary>
        /// Constructor for initilizing the components of the uctlTerminalWindowAlert with customised settings
        /// </summary>
        /// <param name="customizeSettings"></param>
        public uctlTerminalWindowAlert(object customizeSettings)
        {
        }

        #endregion "       CONSTRUCTOR        "

        #region    "      METHODS       "

        /// <summary>
        /// Populated the items of contextmenustrip associated with the grid
        /// </summary>
        public void CreateContextMenu()
        {
            var ContextMenuItems = new ToolStripMenuItem[5];

            ContextMenuItems[0] = new ToolStripMenuItem("Create");
            ContextMenuItems[0].ShortcutKeys = Keys.Insert;
            ContextMenuItems[0].Click += OnCreateClick;
            ContextMenuItems[1] = new ToolStripMenuItem("Modify");
            ContextMenuItems[1].ShortcutKeyDisplayString = "Enter";
            ContextMenuItems[1].ShortcutKeys = Keys.None;
            ContextMenuItems[1].Click += OnModifyClick;
            ContextMenuItems[2] = new ToolStripMenuItem("Delete");
            ContextMenuItems[2].ShortcutKeys = Keys.Delete;
            ContextMenuItems[2].Click += OnDeleteClick;
            ContextMenuItems[3] = new ToolStripMenuItem("Enable On/Off");
            //ContextMenuItems[3].ShortcutKeys = Keys.Space;
            ContextMenuItems[3].Click += OnEnableOnOffClick;
            ContextMenuItems[4] = new ToolStripMenuItem("Auto Arrange");
            //ContextMenuItems[4].ShortcutKeys = Keys.A;
            ContextMenuItems[4].Click += OnAutoArrangeClick;

            ui_uctlGridAlert.ContextMenuStrip.Items.AddRange(ContextMenuItems);
        }

        /// <summary>
        /// Called when the Create item of the contextmenustrip clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCreateClick(object sender, EventArgs e)
        {
            var objuctlAlertDialog = new UctlAlertCreator();
            var objfrmDialogForm = new frmDialogForm();
            objfrmDialogForm.Controls.Clear();
            var objSize = new Size(objuctlAlertDialog.Width + 40, objuctlAlertDialog.Height + 45);
            //objfrmDialogForm.Width = objuctlAlertDialog.Width;
            //objfrmDialogForm.Height = objuctlAlertDialog.Height;
            objfrmDialogForm.Size = objSize;
            objfrmDialogForm.Controls.Add(objuctlAlertDialog);
            objuctlAlertDialog.Dock = DockStyle.Fill;
            objfrmDialogForm.Text = objuctlAlertDialog.Title;
            objfrmDialogForm.ShowDialog();
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
        /// Called when the Delete item of the contextmenustrip clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDeleteClick(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Called when the Modify item of the contextmenustrip clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnModifyClick(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Called when the Enable On/Off item of the contextmenustrip clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnEnableOnOffClick(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Sets the text of the controls of the the Alert Terminal panel tab
        /// </summary>
        public override void SetLocalization()
        {
            Title = ClsLocalizationHandler.Alert;

            ui_uctlGridAlert.Columns[0].HeaderText = ClsLocalizationHandler.Symbol;
            ui_uctlGridAlert.Columns[1].HeaderText = ClsLocalizationHandler.Condition;
            ui_uctlGridAlert.Columns[2].HeaderText = ClsLocalizationHandler.Counter;
            ui_uctlGridAlert.Columns[3].HeaderText = ClsLocalizationHandler.Limit;
            ui_uctlGridAlert.Columns[4].HeaderText = ClsLocalizationHandler.Timeout;
            ui_uctlGridAlert.Columns[5].HeaderText = ClsLocalizationHandler.PEvent;
        }

        #endregion "      METHODS       "
    }
}