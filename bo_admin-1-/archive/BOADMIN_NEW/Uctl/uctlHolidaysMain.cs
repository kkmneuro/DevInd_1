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
    public partial class uctlHolidaysMain : uctlGeneric, Interfaces.IUserCtrl
    {
        #region MEMBERS

        public const string strAdd_ = "Add";
        public const string strEdit_ = "Edit";
        public const string strDelete_ = "Delete";
        public const string strFind_ = "Find";
        public const string strFindNext_ = "Find Next";
        int iCurrRowIndex_ = -1;
       // int iCurrColIndex_ = -1;

        private bool _isEditable = false;
        #endregion MEMBERS

        public uctlHolidaysMain()
        {
            InitializeComponent();
            clsHolidayManager.INSTANCE._DS4Holidays.dtHoliday.RowDeleted += new DataRowChangeEventHandler(dtHoliday_RowDeleted);
            clsHolidayManager.INSTANCE._DS4Holidays.dtHoliday.TableNewRow += new DataTableNewRowEventHandler(dtHoliday_TableNewRow);
        }

        void RefreshMe()
        {
            Action A = () =>
            {
                ////ui_dtgHoliday.DataSource = clsHolidayManager.INSTANCE._DS4Holidays.dtHoliday;
                ui_dtgHoliday.ScrollBars = ScrollBars.None;
                ui_dtgHoliday.Refresh();

                if (ui_dtgHoliday.Rows.Count > 0)
                {
                    ui_dtgHoliday.FirstDisplayedScrollingRowIndex = ui_dtgHoliday.Rows.Count - 1;
                }

                ui_dtgHoliday.ScrollBars = ScrollBars.Both;
            };
            if (ui_dtgHoliday.InvokeRequired)
            {
                ui_dtgHoliday.BeginInvoke(A);

            }
            else
            {
                A();
            }
        }

        void dtHoliday_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            RefreshMe();
        }

        void dtHoliday_RowDeleted(object sender, DataRowChangeEventArgs e)
        {
            RefreshMe();
        }


        #region IUserCtrl Members

        public void Init()
        {
            ui_dtgHoliday.DataSource = clsHolidayManager.INSTANCE._DS4Holidays.dtHoliday;
            ui_dtgHoliday.Columns["IsEveryYear"].Visible = false;
            ui_dtgHoliday.Columns["HolidayID"].Visible = false;
            ui_dtgHoliday.Columns["IsEnable"].Visible = false;

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



        private void EditHoliday(DialogType dialogMode, string dialogText)
        {
            bool isRowClick = true;
            if (iCurrRowIndex_ < 0)
                isRowClick = false;
            uctlHolidays Holidays = new uctlHolidays();
            Holidays._mode = clsEnums.FRM_MODE.EDIT;
            try
            {
                //Logging.FileHandling.WriteAllLog("uctlHolidaysMain : Enter EditHoliday()");
                if (isRowClick)
                {
                    string strHolidayIDColumn = (clsHolidayManager.INSTANCE._DS4Holidays.dtHoliday).HolidayIDColumn.Caption;
                    if (ui_dtgHoliday.SelectedRows[0].Cells[strHolidayIDColumn].Value == null)
                    {
                        return;
                    }

                    int ID = (int)ui_dtgHoliday.SelectedRows[0].Cells[strHolidayIDColumn].Value;
                    Holidays.SetValues(Cls.clsHolidayManager.INSTANCE._DS4Holidays, Cls.clsHolidayManager.INSTANCE._DS4Holidays.dtHoliday.FindByHolidayID(ID), dialogMode);
                    Holidays._row = clsHolidayManager.INSTANCE._DS4Holidays.dtHoliday.FindByHolidayID(ID);


                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :uctlHolidaysMain =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in EditHoliday()");
            }
            Holidays._ContainerCaption = dialogText;
            Holidays.ShowDialog();
        }

        private void AddHolidays()
        {
            uctlHolidays Holidays = new uctlHolidays();
            Holidays._ContainerCaption = "Add Holidays";
            Holidays.ShowDialog();
        }

        private void DeleteHoliday()
        {
            string strHolidayIDColumn = (clsHolidayManager.INSTANCE._DS4Holidays.dtHoliday).HolidayIDColumn.Caption;
            if (ui_dtgHoliday.SelectedRows[0].Cells[strHolidayIDColumn].Value == null)
            {
                return;
            }

            int ID = (int)ui_dtgHoliday.SelectedRows[0].Cells[strHolidayIDColumn].Value;
            uctlDelete Delete = new uctlDelete();
            Delete._MGR = clsHolidayManager.INSTANCE;
            Delete._DBDelete._DeleteID = ProtocolStructs.ProtocolStructIDS.Holiday_ID;
            Delete._DBDelete._DeleteKey = ID.ToString();
            Delete._ContainerCaption = "Delete Holiday";
            Delete.ShowDialog();
        }

        //private void FindHoliday()
        //{
        //    uctlFind Find = new uctlFind();

        //    Find._ContainerCaption = "Find";
        //    Find.ShowDialog();
        //}

        //private void FindNextHoliday()
        //{
        //    uctlFind FindNext = new uctlFind();

        //    FindNext._ContainerCaption = "Find Next";
        //    FindNext.ShowDialog();
        //}



        private void ui_dtgHoliday_MouseDown(object sender, MouseEventArgs e)
        {
            if (ui_dtgHoliday.Rows.Count == 0)
            {
                ui_contextmnuCommon.Items[1].Enabled = false;
                ui_contextmnuCommon.Items[2].Enabled = false;
                return;
            }
            DataGridView.HitTestInfo hitinfo = ui_dtgHoliday.HitTest(e.X, e.Y);
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
                    ui_dtgHoliday.Rows[iCurrRowIndex_].Selected = true;
                    ui_contextmnuCommon.Items[1].Enabled = true;
                    ui_contextmnuCommon.Items[2].Enabled = true;
                }
            }
        }

        private void ui_contextmnuCommon_Opening(object sender, CancelEventArgs e)
        {

            if (iCurrRowIndex_ >= 0)
            {
                //if (ui_dtgHoliday.Rows.Count > 1)
                //{
                //    ui_contextmnuCommonMoveUp.Enabled = true;
                //    ui_contextmnuCommonMoveDown.Enabled = true;
                //}
                ui_contextmnuCommonEdit.Enabled = true;
                ui_contextmnuCommonDelete.Enabled = true;
            }
            else
            {
                ui_contextmnuCommonEdit.Enabled = false;
                ui_contextmnuCommonDelete.Enabled = false;
                //ui_contextmnuCommonMoveUp.Enabled = false;
                //ui_contextmnuCommonMoveDown.Enabled = false;
            }

        }

        private void ui_contextmnuCommon_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {


                switch (e.ClickedItem.Text)
                {
                    case strFindNext_:
                        {
                            // FindNextHoliday();

                        }
                        break;
                    case strFind_:
                        {
                            // FindHoliday();

                        }
                        break;
                    case strDelete_:
                        {
                            DeleteHoliday();

                        }
                        break;
                    case strAdd_:
                        {
                            AddHolidays();

                        }
                        break;
                    case strEdit_:
                        {
                            EditHoliday(DialogType.Edit, "Edit Holiday");

                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {

            }
        }

        private void uctlHolidaysMain_Load(object sender, EventArgs e)
        {
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, ui_dtgHoliday, new object[] { true });
            Init();
            ui_dtgHoliday.Columns["WorkTimeFrom"].HeaderText = "Work Time From";
            ui_dtgHoliday.Columns["WorkTimeFrom"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ui_dtgHoliday.Columns["WorkTimeTo"].HeaderText = "Work Time To";
            ui_dtgHoliday.Columns["WorkTimeTo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void ui_dtgHoliday_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int id = (int)clsEnums.CommandIDS.HOLIDAYS;
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
        }

        private void ui_dtgHoliday_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ui_dtgHoliday.Rows.Count == 0)
            {
                return;
            }
            iCurrRowIndex_ = ui_dtgHoliday.CurrentRow.Index;
            if (iCurrRowIndex_ == -1)
                return;
            else if (_isEditable == true)
                EditHoliday(DialogType.Edit, "Edit Holiday");
        }
    }
}
