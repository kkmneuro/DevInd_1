///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION	
//02/02/2012	VP		    1.Commenting of the code
//07/02/2012	VP          1.Added columns to the grid of the  control
//23/02/212     VP          1.Code for saving grid data in excel file
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CommonLibrary.Cls;

namespace CommonLibrary.UserControls
{
    public partial class UctlParticipantList : UctlBase
    {
        #region    "        MEMBERS           "

        public Dictionary<string, DataGridViewRow> _DDRows = new Dictionary<string, DataGridViewRow>();
        private string _title = "Participant List";

        #endregion "        MEMBERS           "

        #region    "        PROPERTY          "

        /// <summary>
        /// Sets and gets the title of the Participant List control
        /// </summary>
        public override string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        #endregion    "        PROPERTY          "

        #region "        CONSTRUCTOR       "

        /// <summary>
        /// Constructor for initializing the components of the uctlParticipantList 
        /// </summary>
        public UctlParticipantList()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor for initializing the components of the uctlParticipantList with customised settings
        /// </summary>
        /// <param name="customizeSettings"></param>
        public UctlParticipantList(object customizeSettings)
        {
        }

        #endregion "    CONSTRUCTOR     "

        #region    "        METHODS           "

        /// <summary>
        /// This method adds menu items to the context menu of Participant List control
        /// </summary>
        public void CreateContextMenu()
        {
            var ContextMenuItems = new ToolStripMenuItem[1];

            ContextMenuItems[0] = new ToolStripMenuItem("Save As");
            ContextMenuItems[0].Click += OnSaveAsClick;
            ContextMenuItems[0].Name = "SaveAs";

            ui_uctlGridParticipantList.ContextMenuStrip.Items.AddRange(ContextMenuItems);
        }

        /// <summary>
        /// This method adds functionality to the Save As item of context menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSaveAsClick(object sender, EventArgs e)
        {
            var objSaveFileDialog = new SaveFileDialog();

            objSaveFileDialog.DefaultExt = ".xls";
            objSaveFileDialog.Filter = "(*.xls)|*.xls";
            DialogResult objDialogResult = objSaveFileDialog.ShowDialog();

            if (objDialogResult == DialogResult.OK)
            {
                string filePath = objSaveFileDialog.FileName;
                ClsCommonMethods.SaveGridDataInExcel(filePath, ui_uctlGridParticipantList);
            }
        }

        /// <summary>
        /// Sets the text of controls corresponding to localization value
        /// </summary>
        public override void SetLocalization()
        {
            _title = ClsLocalizationHandler.Participant + " " + ClsLocalizationHandler.List;
        }

        /// <summary>
        /// Tasks performed on the control load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uctlParticipantList_Load(object sender, EventArgs e)
        {
            AddColumnsToGrid();
            CreateContextMenu();
            //SetLocalization();
        }

        public void AddColumnsToGrid()
        {
            var columnsArray = new DataGridViewColumn[2];
            var intCellStyle = new DataGridViewCellStyle();
            intCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            columnsArray[0] = ClsCommonMethods.CreateGridColumn(columnsArray[0], "PartId", "Part Id");
            columnsArray[0].DefaultCellStyle = intCellStyle;
            columnsArray[0].DataPropertyName = "AccountId";
            columnsArray[1] = ClsCommonMethods.CreateGridColumn(columnsArray[1], "PartStatus", "Balance");
            columnsArray[1].DataPropertyName = "Balance";

            ui_uctlGridParticipantList.AddColumns(columnsArray);
        }

        #endregion   "        METHODS          "

        private void ui_uctlGridParticipantList_OnGridMouseDown(object sender, MouseEventArgs e)
        {
            OnGridMouseDown(sender, e);
        }

        public event Action<object, MouseEventArgs> OnGridMouseDown;
    }
}