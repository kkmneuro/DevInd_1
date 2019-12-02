using System;
using System.Data;
using System.Windows.Forms;
using System.Reflection;

using BOADMIN_NEW.Cls;

namespace BOADMIN_NEW.Uctl
{
    /// <summary>
    /// FeeMaster main class
    /// </summary>
    public partial class uctlFeesMasterMain : uctlGeneric, Interfaces.IUserCtrl
    {
        #region MEMBERS

        public const string strAdd_ = "Add";
        public const string strEdit_ = "Edit";
        public const string strDelete_ = "Delete";

        int iCurrRowIndex_ = -1;

        private bool _isEditable = false;
        #endregion MEMBERS

        /// <summary>
        /// Performs operations requires at initialization time
        /// </summary>
        public uctlFeesMasterMain()
        {
            InitializeComponent();
            clsFeeMasterManager.INSTANCE._DS4FeeMaster.dtFeeMaster.TableNewRow += dtFeeMaster_TableNewRow;
            clsFeeMasterManager.INSTANCE._DS4FeeMaster.dtFeeMaster.RowChanged += dtFeeMaster_RowChanged;
            clsFeeMasterManager.INSTANCE._DS4FeeMaster.dtFeeMaster.RowDeleted += dtFeeMaster_RowDeleted;
        }

        void dtFeeMaster_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            RefreshMe();
        }


        void dtFeeMaster_RowDeleted(object sender, DataRowChangeEventArgs e)
        {
            RefreshMe();
        }

        void dtFeeMaster_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            RefreshMe();
        }
        /// <summary>
        /// Refreshes the records of the DataGridView
        /// </summary>
        void RefreshMe()
        {
            Action a = () =>
            {
                ////ui_dtgFeesMaster.DataSource = clsFeeMasterManager.INSTANCE._DS4FeeMaster.dtFeeMaster;
                ui_dtgFeesMaster.ScrollBars = ScrollBars.None;
                ui_dtgFeesMaster.Refresh();

                if (ui_dtgFeesMaster.Rows.Count > 0)
                {
                    ui_dtgFeesMaster.FirstDisplayedScrollingRowIndex = ui_dtgFeesMaster.Rows.Count - 1;
                }

                ui_dtgFeesMaster.ScrollBars = ScrollBars.Both;
            };
            if (ui_dtgFeesMaster.InvokeRequired)
            {
                ui_dtgFeesMaster.BeginInvoke(a);

            }
            else
            {
                a();
            }
        }

        #region IUserCtrl Members
        /// <summary>
        /// Initializes the basic values used by control and subcontrols values
        /// </summary>
        public void Init()
        {
            const int id = (int)clsEnums.CommandIDS.FEE_MASTER;
            string x = clsGlobal.Role.Split('_')[id];
            ui_contextmnuCommonAdd.Visible = Convert.ToInt32(x.ToCharArray()[1].ToString()) != 0;
            if (Convert.ToInt32(x.ToCharArray()[2].ToString()) == 0)
            {
                ui_contextmnuCommonEdit.Visible = false;
                _isEditable = false;
            }
            else
            {
                ui_contextmnuCommonEdit.Visible = true;
                _isEditable = true;
            }
            ui_contextmnuCommonDelete.Visible = Convert.ToInt32(x.ToCharArray()[3].ToString()) != 0;
            ui_dtgFeesMaster.DataSource = clsFeeMasterManager.INSTANCE._DS4FeeMaster.dtFeeMaster;
            ui_dtgFeesMaster.Columns["PK_FeeID"].Visible = false;
        }

        public void InitControls()
        {
        }

        public void SaveMe()
        {
        }

        #endregion

        /// <summary>
        /// Submit the values of FeeMaster for insertion and updation to server
        /// </summary>
        /// <param name="dialogMode"></param>
        /// <param name="dialogText"></param>
        private void EditFees(DialogType dialogMode, string dialogText)
        {
            const bool isRowClick = true;
            uctlFeesMaster feesMaster = new uctlFeesMaster();
            feesMaster._mode = clsEnums.FRM_MODE.EDIT;
            try
            {
                //Logging.FileHandling.WriteAllLog("uctlFeesMasterMain : Enter EditFees()");
                if (isRowClick)
                {

                    string strFeeIDColumn = (clsFeeMasterManager.INSTANCE._DS4FeeMaster.dtFeeMaster).PK_FeeIDColumn.Caption;
                    if (ui_dtgFeesMaster.SelectedRows[0].Cells[strFeeIDColumn].Value == null)
                    {
                        return;
                    }

                    int id = (int)ui_dtgFeesMaster.SelectedRows[0].Cells[strFeeIDColumn].Value;
                    feesMaster.SetValues(Cls.clsFeeMasterManager.INSTANCE._DS4FeeMaster, clsFeeMasterManager.INSTANCE._DS4FeeMaster.dtFeeMaster.FindByPK_FeeID(id), dialogMode);
                    feesMaster._row = clsFeeMasterManager.INSTANCE._DS4FeeMaster.dtFeeMaster.FindByPK_FeeID(id);

                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :uctlFeesMasterMain =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in EditFees()");
            }
            feesMaster._ContainerCaption = dialogText;
            feesMaster.ShowDialog();
        }

        private void AddFee()
        {
            uctlFeesMaster feesMaster = new uctlFeesMaster();
            feesMaster._mode = clsEnums.FRM_MODE.ADD;
            feesMaster._ContainerCaption = "Add Fee";
            feesMaster.ShowDialog();
        }

        private void DeleteFee()
        {
            string strFeeIDColumn = (clsFeeMasterManager.INSTANCE._DS4FeeMaster.dtFeeMaster).PK_FeeIDColumn.Caption;
            if (ui_dtgFeesMaster.SelectedRows[0].Cells[strFeeIDColumn].Value == null)
            {
                return;
            }
            int id = (int)ui_dtgFeesMaster.SelectedRows[0].Cells[strFeeIDColumn].Value;
            uctlDelete Delete = new uctlDelete();
            Delete._MGR = clsFeeMasterManager.INSTANCE;
            Delete._DBDelete._DeleteID = ProtocolStructs.ProtocolStructIDS.FeeMaster_ID;
            Delete._DBDelete._DeleteKey = id.ToString();
            Delete._ContainerCaption = "Delete Fee";
            Delete.ShowDialog();

        }

        private void ui_contextmnuCommon_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {


                case strDelete_:
                    {
                        DeleteFee();

                    }
                    break;
                case strAdd_:
                    {
                        AddFee();

                    }
                    break;
                case strEdit_:
                    {
                        EditFees(DialogType.Edit, "Edit Fee Master");

                    }
                    break;
            }
        }


        private void uctlFeesMasterMain_Load(object sender, EventArgs e)
        {
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, ui_dtgFeesMaster, new object[] { true });
            Init();
            ui_dtgFeesMaster.Columns["FeeName"].HeaderText = "Fee Name";
            ui_dtgFeesMaster.Columns["MinimumFeeValue"].HeaderText = "Minimum Fee Value";
            ui_dtgFeesMaster.Columns["MinimumFeeValue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ui_dtgFeesMaster.Columns["MaximunFeeValue"].HeaderText = "Maximum Fee Value";
            ui_dtgFeesMaster.Columns["MaximunFeeValue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ui_dtgFeesMaster.Columns["IsTaxable"].HeaderText = "Is Taxable";
            ui_dtgFeesMaster.Columns["FeesMode"].HeaderText = "Fees Mode";
            ui_dtgFeesMaster.Columns["LevyOn"].HeaderText = "Levy On";
        }


        private void ui_dtgFeesMaster_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (ui_dtgFeesMaster.Rows.Count == 0)
            {
                return;
            }
            iCurrRowIndex_ = ui_dtgFeesMaster.CurrentRow.Index;
            if (iCurrRowIndex_ == -1)
                return;
            else if (_isEditable == true)
                EditFees(DialogType.Edit, "Edit Fee Master");
        }
        /// <summary>
        /// Handles Mouse down event of FeeMaster Grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_dtgFeesMaster_MouseDown(object sender, MouseEventArgs e)
        {
            if (ui_dtgFeesMaster.Rows.Count == 0)
            {
                ui_contextmnuCommon.Items[1].Enabled = false;
                ui_contextmnuCommon.Items[2].Enabled = false;
                return;
            }
            DataGridView.HitTestInfo hitinfo = ui_dtgFeesMaster.HitTest(e.X, e.Y);
            iCurrRowIndex_ = hitinfo.RowIndex;
            if (e.Button == MouseButtons.Right && e.Clicks == 1)
            {
                if (iCurrRowIndex_ < 0)
                {
                    ui_contextmnuCommon.Items[1].Enabled = false;
                    ui_contextmnuCommon.Items[2].Enabled = false;
                }
                else
                {
                    ui_dtgFeesMaster.Rows[iCurrRowIndex_].Selected = true;
                    ui_contextmnuCommon.Items[1].Enabled = true;
                    ui_contextmnuCommon.Items[2].Enabled = true;
                }
            }

        }


        private void ui_dtgFeesMaster_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
