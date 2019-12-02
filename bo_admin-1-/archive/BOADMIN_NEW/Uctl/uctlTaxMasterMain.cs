using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ProtocolStructs;
using clsInterface4OME.DSBO;
using clsInterface4OME;
using BOADMIN_NEW.Cls;
using System.Reflection;

namespace BOADMIN_NEW.Uctl
{
    public partial class uctlTaxMasterMain : uctlGeneric, Interfaces.IUserCtrl
    {
        #region MEMBERS

        public const string strAdd_ = "Add";
        public const string strEdit_ = "Edit";
        public const string strDelete_ = "Delete";

        int iCurrRowIndex_ = -1;
        //int iCurrColIndex_ = -1;

        private bool _isEditable = false;

        #endregion MEMBERS

        public uctlTaxMasterMain()
        {
            InitializeComponent();
            clsTaxMasterManager.INSTANCE._DS4TaxMaster.dtTaxMaster.RowDeleted += new DataRowChangeEventHandler(dtTaxMaster_RowDeleted);
            clsTaxMasterManager.INSTANCE._DS4TaxMaster.dtTaxMaster.TableNewRow += new DataTableNewRowEventHandler(dtgTaxMaster_TableNewRow);
            clsTaxMasterManager.INSTANCE._DS4TaxMaster.dtTaxMaster.RowChanging += new DataRowChangeEventHandler(dtTaxMaster_RowChanging);
            clsTaxMasterManager.INSTANCE._DS4TaxMaster.dtTaxMaster.RowChanged += new DataRowChangeEventHandler(dtTaxMaster_RowChanged);
        }

        void dtTaxMaster_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            RefreshMe();
        }

        void dtTaxMaster_RowChanging(object sender, DataRowChangeEventArgs e)
        {
            RefreshMe();
        }

        void dtTaxMaster_RowDeleted(object sender, DataRowChangeEventArgs e)
        {
            RefreshMe();
        }

        void RefreshMe()
        {
            Action A = () =>
            {
                ////ui_dtgTaxMaster.DataSource = clsTaxMasterManager.INSTANCE._DS4TaxMaster.dtTaxMaster;
                ui_dtgTaxMaster.ScrollBars = ScrollBars.None;
                ui_dtgTaxMaster.Refresh();

                if (ui_dtgTaxMaster.Rows.Count > 0)
                {
                    ui_dtgTaxMaster.FirstDisplayedScrollingRowIndex = ui_dtgTaxMaster.Rows.Count - 1;
                }

                ui_dtgTaxMaster.ScrollBars = ScrollBars.Both; 
            };
            if (ui_dtgTaxMaster.InvokeRequired)
            {
                ui_dtgTaxMaster.BeginInvoke(A);

            }
            else
            {
                A();
            }
        }
       
        void dtgTaxMaster_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            RefreshMe();
        }


        #region IUserCtrl Members


        public void Init()
        {
            int id = (int)clsEnums.CommandIDS.TAX_MASTER;
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
            ui_dtgTaxMaster.DataSource = clsTaxMasterManager.INSTANCE._DS4TaxMaster.dtTaxMaster;
            ui_dtgTaxMaster.Columns["PK_TaxID"].Visible = false;
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

        private void EditTax(DialogType dialogMode, string dialogText)
        {
            bool isRowClick = true;
            if (iCurrRowIndex_ < 0)
                isRowClick = false;

            uctlTaxMaster TaxMaster = new uctlTaxMaster();
            TaxMaster._mode = clsEnums.FRM_MODE.EDIT;
            if (isRowClick)
            {

                string strTaxIDColumn = (clsTaxMasterManager.INSTANCE._DS4TaxMaster.dtTaxMaster).PK_TaxIDColumn.Caption;
                if (ui_dtgTaxMaster.Rows[iCurrRowIndex_].Cells[strTaxIDColumn].Value == null)
                {
                    return;
                }

                int ID = (int)ui_dtgTaxMaster.Rows[iCurrRowIndex_].Cells[strTaxIDColumn].Value;
                TaxMaster.SetValues(Cls.clsTaxMasterManager.INSTANCE._DS4TaxMaster, Cls.clsTaxMasterManager.INSTANCE._DS4TaxMaster.dtTaxMaster.FindByPK_TaxID(ID), dialogMode);
                TaxMaster._row = clsTaxMasterManager.INSTANCE._DS4TaxMaster.dtTaxMaster.FindByPK_TaxID(ID);

            }
            TaxMaster._ContainerCaption = dialogText;
            TaxMaster.ShowDialog();
        }

        private void AddTax()
        {
            uctlTaxMaster TaxMaster = new uctlTaxMaster();
            TaxMaster._mode = clsEnums.FRM_MODE.ADD;
            TaxMaster._ContainerCaption = "Add Tax";
            TaxMaster.ShowDialog();
        }

        private void DeleteTax()
        {
            string strTaxIDColumn = (clsTaxMasterManager.INSTANCE._DS4TaxMaster.dtTaxMaster).PK_TaxIDColumn.Caption;
            if (ui_dtgTaxMaster.SelectedRows[0].Cells[strTaxIDColumn].Value == null)
            {
                return;
            }
            int ID = (int)ui_dtgTaxMaster.SelectedRows[0].Cells[strTaxIDColumn].Value;
            uctlDelete Delete = new uctlDelete();
            Delete._MGR = clsTaxMasterManager.INSTANCE;
            Delete._DBDelete._DeleteID = ProtocolStructs.ProtocolStructIDS.TaxMasterID;
            Delete._DBDelete._DeleteKey = ID.ToString();
            Delete._ContainerCaption = "Delete Tax";
            Delete.ShowDialog();

        }

        private void uctlTaxMasterMain_Load(object sender, EventArgs e)
        {
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, ui_dtgTaxMaster, new object[] { true });
            Init();
            ui_dtgTaxMaster.Columns["TaxName"].HeaderText = "Tax Name";
            ui_dtgTaxMaster.Columns["TaxPercent"].HeaderText = "Tax Percent";
            ui_dtgTaxMaster.Columns["TaxPercent"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void ui_contextmnuCommon_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {


                case strDelete_:
                    {
                        DeleteTax();

                    }
                    break;
                case strAdd_:
                    {
                        AddTax();

                    }
                    break;
                case strEdit_:
                    {
                        EditTax(DialogType.Edit, "Edit Tax Master");

                    }
                    break;
                default:
                    break;

            }
        }

        private void ui_dtgTaxMaster_MouseDown(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitinfo = ui_dtgTaxMaster.HitTest(e.X, e.Y);
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
                    ui_dtgTaxMaster.Rows[iCurrRowIndex_].Selected = true;
                    ui_contextmnuCommon.Items[1].Enabled = true;
                    ui_contextmnuCommon.Items[2].Enabled = true;
                }
            }

        }

        private void ui_dtgTaxMaster_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ui_dtgTaxMaster.Rows.Count == 0)
            {
                return;
            }
            iCurrRowIndex_ = ui_dtgTaxMaster.CurrentRow.Index;
            if (iCurrRowIndex_ == -1)
                return;
            else if(_isEditable==true)
                EditTax(DialogType.Edit, "Edit Tax Master");
        }
    }
}
