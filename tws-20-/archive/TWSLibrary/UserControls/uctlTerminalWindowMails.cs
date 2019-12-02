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
    public partial class uctlTerminalWindowMails : UctlBase
    {
        #region    "      MEMBERS       "

        private string _title = "Mails";

        #endregion "      MEMBERS       "

        #region    "      PROPERTY      "

        /// <summary>
        /// Sets and gets the title of control
        /// </summary>
        public override string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        #endregion "      PROPERTY      "

        #region "    CONSTRUCTOR     "

        /// <summary>
        /// Constructor for initilizing the components of the uctlTerminalWindowMails 
        /// </summary>
        public uctlTerminalWindowMails()
        {
            InitializeComponent();
            //CreateContextMenu();
        }


        /// <summary>
        /// Constructor for initilizing the components of the uctlTerminalWindowMails with customised settings
        /// </summary>
        /// <param name="customizeSettings"></param>
        public uctlTerminalWindowMails(object customizeSettings)
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

            ContextMenuItems[0] = new ToolStripMenuItem("Create");
            ContextMenuItems[0].Click += OnCreateClick;
            ContextMenuItems[1] = new ToolStripMenuItem("View");
            ContextMenuItems[1].Click += OnViewClick;
            ContextMenuItems[2] = new ToolStripMenuItem("Delete");
            ContextMenuItems[2].Click += OnDeleteClick;
            ContextMenuItems[3] = new ToolStripMenuItem("Auto Arrange");
            ContextMenuItems[3].Click += OnAutoArrangeClick;
            ui_uctlGridMails.ContextMenuStrip.Items.AddRange(ContextMenuItems);
        }

        /// <summary>
        /// This method adds columns to the user grid control at run time
        /// </summary>
        public void AddColumnsToGrid()
        {
            var columnsArray = new DataGridViewColumn[6];


            columnsArray[0] = ClsCommonMethods.CreateGridColumn(columnsArray[0], "colmailDate", "Date");
            columnsArray[0].DataPropertyName = "DateTime";
            columnsArray[0].ToolTipText = "Date";
            columnsArray[0].Width = 80;
            columnsArray[1] = ClsCommonMethods.CreateGridColumn(columnsArray[1], "colmailTo", "To");
            columnsArray[1].DataPropertyName = "To";
            columnsArray[1].ToolTipText = "To";
            columnsArray[1].Width = 80;
            columnsArray[2] = ClsCommonMethods.CreateGridColumn(columnsArray[2], "colmailFrom", "From");
            columnsArray[2].DataPropertyName = "From";
            columnsArray[2].ToolTipText = "From";
            columnsArray[2].Width = 80;
            columnsArray[3] = ClsCommonMethods.CreateGridColumn(columnsArray[3], "colmailSubject", "Subject");
            columnsArray[3].DataPropertyName = "Subject";
            columnsArray[3].ToolTipText = "Subject";
            columnsArray[3].Width = 110;
            columnsArray[4] = ClsCommonMethods.CreateGridColumn(columnsArray[3], "colmailBody", "Message");
            columnsArray[4].DataPropertyName = "Message";
            columnsArray[4].ToolTipText = "Message";
            columnsArray[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //columnsArray[4].Width = 180;
            columnsArray[5] = ClsCommonMethods.CreateGridColumn(columnsArray[3], "colDescription", "Description",false);
            columnsArray[5].ToolTipText = "Description";
            //columnsArray[5].Width = 80;

            foreach (DataGridViewColumn column in columnsArray)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            ui_uctlGridMails.AddColumns(columnsArray);
        }
        /// <summary>
        /// Called when the Create item of the contextmenustrip clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCreateClick(object sender, EventArgs e)
        {
            var objuctlMail = new UctlMail(this);
            objuctlMail.OnMailSendClick += new Action<string>(objuctlMail_OnMailSendClick);
            var objfrmDialogForm = new frmDialogForm();
            objfrmDialogForm.Controls.Clear();
            var objSize = new Size(objuctlMail.Width + 28, objuctlMail.Height + 45);
            objfrmDialogForm.Size = objSize;
            objfrmDialogForm.Controls.Add(objuctlMail);
            objuctlMail.Dock = DockStyle.Fill;
            objfrmDialogForm.Text = objuctlMail.Title;
            objfrmDialogForm.StartPosition = FormStartPosition.CenterScreen;
            objfrmDialogForm.Show();
        }
        public event Action<string> OnMailSendClick = delegate { };
        void objuctlMail_OnMailSendClick(string obj)
        {
            OnMailSendClick(obj);
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
        /// Called when the View item of the contextmenustrip clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnViewClick(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Sets the text of the controls corresponding to localized value
        /// </summary>
        public override void SetLocalization()
        {
            Title = ClsLocalizationHandler.Mails;

            //ui_uctlGridMails.Columns[0].HeaderText = Cls.clsLocalizationHandler.Date;
            //ui_uctlGridMails.Columns[1].HeaderText = Cls.clsLocalizationHandler.To;
            //ui_uctlGridMails.Columns[2].HeaderText = Cls.clsLocalizationHandler.From;
            //ui_uctlGridMails.Columns[3].HeaderText = Cls.clsLocalizationHandler.Subject;
            //ui_uctlGridMails.Columns[4].HeaderText = Cls.clsLocalizationHandler.Body;
        }

        #endregion "      METHODS       "

        private void uctlTerminalWindowMails_Load(object sender, EventArgs e)
        {
            CreateContextMenu();
            AddColumnsToGrid();
        }
    }
}