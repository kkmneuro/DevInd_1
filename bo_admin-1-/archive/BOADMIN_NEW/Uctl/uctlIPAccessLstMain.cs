using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BOADMIN_NEW.Cls;
using clsInterface4OME.DSBO;
using System.Reflection;

namespace BOADMIN_NEW.Uctl
{
    public partial class uctlIPAccessLstMain : uctlGeneric, Interfaces.IUserCtrl
    {
        #region MEMBERS
        public const string strApplyChanges_ = "Apply Changes";
        public const string strAdd_ = "Add";
        public const string strEdit_ = "Edit";
        public const string strDelete_ = "Delete";
        public const string strFind_ = "Find";
        public const string strFindNext_ = "Find Next";
        int iCurrRowIndex_ = -1;
        //int iCurrColIndex_ = -1;

        private bool _isEditable = false;
        #endregion MEMBERS


        public uctlIPAccessLstMain()
        {
            InitializeComponent();
            clsIPAccessListManager.INSTANCE._DS4IPAccesssList.dtIPAccessList.RowDeleted += new DataRowChangeEventHandler(dtgIPAccessLst_RowDeleted);
            clsIPAccessListManager.INSTANCE._DS4IPAccesssList.dtIPAccessList.TableNewRow += new DataTableNewRowEventHandler(dtgIPAccessLst_TableNewRow);
            clsIPAccessListManager.INSTANCE._DS4IPAccesssList.dtIPAccessList.RowChanging += new DataRowChangeEventHandler(dtIPAccessList_RowChanging);
            clsIPAccessListManager.INSTANCE._DS4IPAccesssList.dtIPAccessList.RowChanged += new DataRowChangeEventHandler(dtIPAccessList_RowChanged);
        }

        void dtIPAccessList_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            RefreshMe();
        }

        void dtIPAccessList_RowChanging(object sender, DataRowChangeEventArgs e)
        {
            RefreshMe();
        }


        void RefreshMe()
        {
            Action A = () =>
            {
                ////ui_dtgIPAccessLst.DataSource = clsIPAccessListManager.INSTANCE._DS4IPAccesssList.dtIPAccessList;
                ui_dtgIPAccessLst.ScrollBars = ScrollBars.None;
                ui_dtgIPAccessLst.Refresh();

                if (ui_dtgIPAccessLst.Rows.Count > 0)
                {
                    ui_dtgIPAccessLst.FirstDisplayedScrollingRowIndex = ui_dtgIPAccessLst.Rows.Count - 1;
                }

                ui_dtgIPAccessLst.ScrollBars = ScrollBars.Both;
            };
            if (ui_dtgIPAccessLst.InvokeRequired)
            {
                ui_dtgIPAccessLst.BeginInvoke(A);

            }
            else
            {
                A();
            }
        }

        void dtgIPAccessLst_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            RefreshMe();
        }

        void dtgIPAccessLst_RowDeleted(object sender, DataRowChangeEventArgs e)
        {
            RefreshMe();
        }

        #region IUserCtrl Members

        public void Init()
        {
            ui_dtgIPAccessLst.DataSource = clsIPAccessListManager.INSTANCE._DS4IPAccesssList.dtIPAccessList;
            ui_dtgIPAccessLst.Columns["IPAccessID"].Visible = false;
        }

        public void InitControls()
        {
            throw new NotImplementedException();
        }

        public void SaveMe()
        {
            throw new NotImplementedException();
        }

        #endregion


        private void ui_dtgIPAccessLst_MouseDown(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitinfo = ui_dtgIPAccessLst.HitTest(e.X, e.Y);
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
                    ui_dtgIPAccessLst.Rows[iCurrRowIndex_].Selected = true;
                    ui_contextmnuCommon.Items[1].Enabled = true;
                    ui_contextmnuCommon.Items[2].Enabled = true;
                }
            }
        }

        private void EditIPAccessList()
        {
            bool isRowClick = true;
            if (iCurrRowIndex_ < 0)
                isRowClick = false;

            uctlIpAccess IpAccess = new uctlIpAccess();
            IpAccess._mode = clsEnums.FRM_MODE.EDIT;
            try
            {
                //Logging.FileHandling.WriteAllLog("uctlIPAccessLstMain : Enter EditIPAccessList()");
                if (isRowClick)
                {

                    string strIPAccessIDColumn = (clsIPAccessListManager.INSTANCE._DS4IPAccesssList.dtIPAccessList).IPAccessIDColumn.Caption;
                    if (ui_dtgIPAccessLst.Rows[iCurrRowIndex_].Cells[strIPAccessIDColumn].Value == null)
                    {
                        return;
                    }

                    int ID = (int)ui_dtgIPAccessLst.Rows[iCurrRowIndex_].Cells[strIPAccessIDColumn].Value;

                    IpAccess._row = clsIPAccessListManager.INSTANCE._DS4IPAccesssList.dtIPAccessList.FindByIPAccessID(ID);

                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :uctlIPAccessLstMain =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in EditIPAccessList()");
            }
            IpAccess._ContainerCaption = "Edit IP Access";
            IpAccess.ShowDialog();
        }

        private void AddIPAccessList()
        {
            uctlIpAccess IpAccess = new uctlIpAccess();
            IpAccess._mode = clsEnums.FRM_MODE.ADD;
            IpAccess._ContainerCaption = "Add IP Access";
            IpAccess.ShowDialog();
        }

        private void DeleteIPAccessList()
        {


            string strIPAccessIDColumn = (clsIPAccessListManager.INSTANCE._DS4IPAccesssList.dtIPAccessList).IPAccessIDColumn.Caption;
            if (ui_dtgIPAccessLst.SelectedRows[0].Cells[strIPAccessIDColumn].Value == null)
            {
                return;
            }
            int ID = (int)ui_dtgIPAccessLst.SelectedRows[0].Cells[strIPAccessIDColumn].Value;
            uctlDelete Delete = new uctlDelete();
            Delete._MGR = clsIPAccessListManager.INSTANCE;
            Delete._DBDelete._DeleteID = ProtocolStructs.ProtocolStructIDS.AccessIp_ID;
            Delete._DBDelete._DeleteKey = ID.ToString();
            Delete._ContainerCaption = "Delete IP Access";
            Delete.ShowDialog();
        }

        private void ui_contextmnuCommon_Opening(object sender, CancelEventArgs e)
        {

        }

        private void ui_contextmnuCommon_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case strDelete_:
                    {
                        DeleteIPAccessList();

                    }
                    break;
                case strAdd_:
                    {
                        AddIPAccessList();

                    }
                    break;
                case strEdit_:
                    {
                        EditIPAccessList();

                    }
                    break;
                default:
                    break;

            }

        }

        private void uctlIPAccessLstMain_Load(object sender, EventArgs e)
        {
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, ui_dtgIPAccessLst, new object[] { true });
            Init();
            ui_ncmbAction.SelectedIndex = 0;
            ui_dtgIPAccessLst.Columns["IPAddressFrom"].HeaderText = "IP Address From";
            ui_dtgIPAccessLst.Columns["IPAddressTo"].HeaderText = "IP Address To";
        }

        private void ui_ncmbAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = (int)clsEnums.CommandIDS.IP_ACCESS;
            string x = clsGlobal.Role.Split('_')[id];
            if (Convert.ToInt32(x.ToCharArray()[1].ToString()) == 0)
            {
                ui_contextmnuCommonAdd.Visible = false;
            }
            else
            {
                ui_contextmnuCommonAdd.Visible = true;
            }
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
            if (Convert.ToInt32(x.ToCharArray()[3].ToString()) == 0)
            {
                ui_contextmnuCommonDelete.Visible = false;
            }
            else
            {
                ui_contextmnuCommonDelete.Visible = true;
            }
            ui_dtgIPAccessLst.DataSource = null;
            if (ui_ncmbAction.SelectedItem.ToString() == "Permit")
            {
                ui_dtgIPAccessLst.DataSource = clsIPAccessListManager.INSTANCE._DS4IPAccesssList.dtIPAccessList.Select("Action = 'Permit'");
                ui_dtgIPAccessLst.Columns["IPAccessID"].Visible = false;
                ui_dtgIPAccessLst.Columns["RowError"].Visible = false;
                ui_dtgIPAccessLst.Columns["RowState"].Visible = false;
                ui_dtgIPAccessLst.Columns["Table"].Visible = false;
                ui_dtgIPAccessLst.Columns["HasErrors"].Visible = false;
            }
            else if (ui_ncmbAction.SelectedItem.ToString() == "Block")
            {
                ui_dtgIPAccessLst.DataSource = clsIPAccessListManager.INSTANCE._DS4IPAccesssList.dtIPAccessList.Select("Action = 'Block'");
                ui_dtgIPAccessLst.Columns["IPAccessID"].Visible = false;
                ui_dtgIPAccessLst.Columns["RowError"].Visible = false;
                ui_dtgIPAccessLst.Columns["RowState"].Visible = false;
                ui_dtgIPAccessLst.Columns["Table"].Visible = false;
                ui_dtgIPAccessLst.Columns["HasErrors"].Visible = false;
            }
            else
            {
                ui_dtgIPAccessLst.DataSource = clsIPAccessListManager.INSTANCE._DS4IPAccesssList.dtIPAccessList;
                ui_dtgIPAccessLst.Columns["IPAccessID"].Visible = false;
            }
        }

        private void ui_dtgIPAccessLst_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (ui_dtgIPAccessLst.Rows.Count == 0)
            {
                return;
            }
            iCurrRowIndex_ = ui_dtgIPAccessLst.CurrentRow.Index;
            if (iCurrRowIndex_ == -1)
                return;
            else if (_isEditable == true)
                EditIPAccessList();
        }
    }
}