///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION
//03/02/2012	VP          1.Added columnProfile menu in gridmenu and defined there functionality
//07/02/2012	VP          1.Added columns to the grid of the  control
//05/03/2012	VP          1.Code for columnProfile
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CommonLibrary.Cls;

namespace CommonLibrary.UserControls
{
    public partial class UctlPendingOrder : UctlBase
    {
        #region    "        MEMBERS           "

        private readonly frmDialogForm _objfrmDialogForm = new frmDialogForm();
        public Dictionary<long, DataRow> _DDRow = new Dictionary<long, DataRow>();
        private string _title = "Pending Order";

        #endregion "        MEMBERS           "

        #region    "        PROPERTY          "

        /// <summary>
        /// Sets and gets the title of the order book control
        /// </summary>
        public override string Title
        {
            get { return _title; }
            set { _title = value; }
        }
 
        public object Profiles { get; set; }

        public string CurrentProfileName { get; set; }

        /// <summary>
        /// This property sets the colour of the current row of the grid. This property is both settable and gettable
        /// </summary>
        public Color DataRowStyle { get; set; }

        /// <summary>
        /// Apply condition in filter and accordingly, the conditional output is displayed when required.
        /// </summary>

        /// <summary>
        /// When pending order Executed then alert sound should fire
        /// </summary>
        public string AlertSound { get; set; }

        #endregion "        PROPERTY          "

        #region "        CONSTRUCTOR       "

        /// <summary>
        /// Constructor for initializing the components of the uctlOrderBook 
        /// </summary>
        public UctlPendingOrder()
        {
            InitializeComponent();
        }

        #endregion "    CONSTRUCTOR     "

        #region    "        METHODS           "
        public ToolStripMenuItem[] ContextMenuItems = new ToolStripMenuItem[5];
        /// <summary>
        /// This method adds menu items to the context menu of uctlOrderBook control
        /// </summary>
        public void CreateContextMenu()
        {
            //try
            //{        
           
            ContextMenuItems[0] = new ToolStripMenuItem("Column Profile");
            ContextMenuItems[0].Click += OnColumnProfileClick;
            ContextMenuItems[1] = new ToolStripMenuItem("Save As");
            ContextMenuItems[1].Name = "SaveAs";
            ContextMenuItems[1].Click += OnSaveAsClick;
            ContextMenuItems[2] = new ToolStripMenuItem("Cancel Order");
            ContextMenuItems[2].Name = "CancelOrder";
            ContextMenuItems[2].Click += OnCancelOrderClick; 
            ContextMenuItems[3] = new ToolStripMenuItem("Modify Order");
            ContextMenuItems[3].Name = "ModifyOrder";
            ContextMenuItems[3].ShortcutKeyDisplayString = "";
            ContextMenuItems[3].Click += OnModifyOrderClick;
            ContextMenuItems[4] = new ToolStripMenuItem("Close Order");
            ContextMenuItems[4].Name = "CloseOrder";
            ContextMenuItems[4].Click += OnCloseOrderClick;
            ui_uctlGridPendingOrder.ContextMenuStrip.Items.AddRange(ContextMenuItems);
         
            //}
            //catch(Exception ex)
            //{ }
        }


        /// <summary>
        /// This method adds functionality to the Column Profile item of context menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnColumnProfileClick(object sender, EventArgs e)
        {
            var objfrmColumnProfile = new FrmColumnProfile(ProfileTypes.PendingOrder, Profiles,
                                                           CurrentProfileName);
            objfrmColumnProfile.OnOkClick += objfrmColumnProfile_OnOkClick;
            objfrmColumnProfile.OnProfileSaveClick += objfrmColumnProfile_OnProfileSaveClick;
            objfrmColumnProfile.OnProfileRemoveClick += objfrmColumnProfile_OnProfileRemoveClick;
            objfrmColumnProfile.OnSetDefaultProfileClick += objfrmColumnProfile_OnSetDefaultProfileClick;
            objfrmColumnProfile.AddItemsToList(ui_uctlGridPendingOrder);
            objfrmColumnProfile.ShowDialog();
        }

        private void objfrmColumnProfile_OnSetDefaultProfileClick(object profiles, string profileName)
        {
            OnSetDefaultProfileClick(profiles, profileName);
        }

        private void objfrmColumnProfile_OnProfileRemoveClick(object profiles, string profileName)
        {
            OnProfileRemoveClick(profiles, profileName);
        }

        private void objfrmColumnProfile_OnProfileSaveClick(object profiles, string profileName)
        {
            OnProfileSaveClick(profiles, profileName);
        }

        /// <summary>
        /// Applys the users column settings to the grid
        /// </summary>
        /// <param name="profiles"></param>
        /// <param name="currentProfile"></param>
        private void objfrmColumnProfile_OnOkClick(object profiles, string currentProfile)
        {
            CurrentProfileName = currentProfile;
            Profiles = profiles;
            ClsProfile profile =
                ((Dictionary<string, ClsProfile>) Profiles)[currentProfile + "_" + ProfileTypes.PendingOrder.ToString()];
            foreach (DataGridViewColumn col in ui_uctlGridPendingOrder.Columns)
            {
                ClsColumnSetting colsetting = profile.DDColumnSetting[col.HeaderText];
                col.DisplayIndex = colsetting.Index;
                col.Visible = colsetting.Visible;
            }
        }

        /// <summary>
        /// This method adds functionality to the Save As item of context menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnSaveAsClick(object sender, EventArgs e)
        {
            var objSaveFileDialog = new SaveFileDialog {DefaultExt = ".xls", Filter = "(*.xls)|*.xls"};
            DialogResult objDialogResult = objSaveFileDialog.ShowDialog();
            if (objDialogResult == DialogResult.OK)
            {
                string filePath = objSaveFileDialog.FileName;
                ClsCommonMethods.SaveGridDataInExcel(filePath, ui_uctlGridPendingOrder);
            }
        }

        private void OnModifyOrderClick(object sender, EventArgs e)
        {
            DialogResult result = ClsCommonMethods.ShowMessageBox("Are you sure to modify order?");
            if (result == DialogResult.Yes)
            {
                HandleModifyOrderClick(sender, e);
            }
        }

        private void OnCloseOrderClick(object sender, EventArgs e)
        {
            DialogResult result = ClsCommonMethods.ShowMessageBox("Are you sure to Close order?");
            if (result == DialogResult.Yes)
            {
                HandleCloseOrderClick(sender, e);
            }
        }
        /// <summary>
        /// This method adds functionality to the Cancel Order item of context menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCancelOrderClick(object sender, EventArgs e)
        {
            DialogResult result = ClsCommonMethods.ShowMessageBox("Are you sure to cancel order?");
            if (result == DialogResult.Yes)
            {
                HandleCancelOrderClick(sender, e);
            }
        }

        /// <summary>
        /// Sets the text of controls corresponding to localization value
        /// </summary>
        public override void SetLocalization()
        {
            _title = ClsLocalizationHandler.Pending + " " + ClsLocalizationHandler.Order;
        }

        /// <summary>
        /// this method adds context menu to the control at run time
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uctlPendingOrder_Load(object sender, EventArgs e)
        {
            ui_uctlGridPendingOrder.ColumnHeadersCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        /// <summary>
        /// This method adds columns to the user grid control at run time
        /// </summary>
        public void AddColumnsToGrid(DataGridViewColumn[] columnsArray)
        {
            ui_uctlGridPendingOrder.AddColumns(columnsArray);
        }

        #endregion   "        METHODS          "

  

        private void ui_uctlGridOrderBook_OnGridMouseDown(object sender, MouseEventArgs e)
        {
            if(OnGridMouseDown!=null)
            OnGridMouseDown(sender, e);
        }

        public event Action<object, MouseEventArgs> OnGridMouseDown;

       

        private void uctlOrderBook_Click(object sender, EventArgs e)
        {
            Click(sender, e);
        }

        public new event EventHandler Click = delegate { };

        private void uctlOrderBook_MouseClick(object sender, MouseEventArgs e)
        {
            Click(sender, e);
        }

        #region "          EVENTS         "
        public event Action<object, string> OnProfileSaveClick = delegate { };
        public event Action<object, string> OnProfileRemoveClick = delegate { };
        public event Action<object, string> OnSetDefaultProfileClick = delegate { };
        public event Action<object, EventArgs> HandleCancelOrderClick = delegate { };
        public event Action<object, EventArgs> HandleModifyOrderClick = delegate { };
        public event Action<object, EventArgs> HandleCloseOrderClick = delegate { };
        #endregion "       EVENTS         "



    }
}