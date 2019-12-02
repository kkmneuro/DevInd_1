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

namespace BOADMIN_NEW.Uctl
{
    public partial class uctlTimeMain : uctlGeneric, Interfaces.IUserCtrl
    {

        #region MEMBERS

        public const string strEdit_ = "Edit";

        int iCurrRowIndex_ = -1;
      //  int iCurrColIndex_ = -1;

        private bool _isEditable = false;
        #endregion MEMBERS



        public uctlTimeMain()
        {
            InitializeComponent();
            //ui_dtgTime.Rows.Add(4);
            //ui_dtgTime.Rows[0].Cells["Day"].Value = "Sunday";
            //ui_dtgTime.Rows[0].Cells["Time"].Value = "00:24";
            //ui_dtgTime.Rows[1].Cells["Day"].Value = "Monaday";
            //ui_dtgTime.Rows[1].Cells["Time"].Value = "00:24";


        }

        #region IUserCtrl Members

        public void Init()
        {
            int id = (int)clsEnums.CommandIDS.TIME_SETTINGS;
            string x = clsGlobal.Role.Split('_')[id];

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

            ui_dtgTime.DataSource = clsTimeManager.INSTANCE._DS4Time.dtTime;
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


        private void AddTime()
        {
            uctlTime Time = new uctlTime();
            Time._mode = clsEnums.FRM_MODE.ADD;
            Time._ContainerCaption = "TIME";
            Time.ShowDialog();
        }

        private void ui_dtgTime_MouseDown(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitinfo = ui_dtgTime.HitTest(e.X, e.Y);
            iCurrRowIndex_ = hitinfo.RowIndex;
            if (e.Button == MouseButtons.Right && e.Clicks == 1)
            {
                if (iCurrRowIndex_ < 0)
                {
                    ui_contextmnuCommon.Items[0].Enabled = false;

                }
                else
                {
                    ui_dtgTime.Rows[iCurrRowIndex_].Selected = true;
                    ui_contextmnuCommon.Items[0].Enabled = true;
                }
            }

        }


        //private void EditTime()
        //{
        //    bool isRowClick = true;
        //    if (iCurrRowIndex_ < 0)
        //        isRowClick = false;
        //    uctlTime Time = new uctlTime();
        //    Time._mode = clsEnums.FRM_MODE.EDIT;
        //    if (isRowClick)
        //    {
        //        string strDayColumn = (clsTimeManager.INSTANCE._DS4Time.dtTime).DayColumn.Caption;
        //        if (ui_dtgTime.Rows[iCurrRowIndex_].Cells[strDayColumn].Value == null)
        //        {
        //            return;
        //        }


        //        string ID = (string)ui_dtgTime.Rows[iCurrRowIndex_].Cells[strDayColumn].Value;
        //    }

        //    Time._ContainerCaption = "Edit Time Settings ";
        //    Time.ShowDialog();

        //}

        /// <summary>
        /// edit time handler
        /// </summary>
        private void EditTime()
        {
            bool isRowClick = true;
            if (iCurrRowIndex_ < 0)
                isRowClick = false;
            uctlTimeNew Time = new uctlTimeNew();
            Time.OnDaySelect += new Action<object, EventArgs>(Time_OnDaySelect);
            Time._mode = clsEnums.FRM_MODE.EDIT;
            try
            {
                //Logging.FileHandling.WriteAllLog("uctlTimeMain : Enter EditTime()");
                if (isRowClick)
                {
                    string strDayColumn = (clsTimeManager.INSTANCE._DS4Time.dtTime).DayColumn.Caption;
                    if (ui_dtgTime.Rows[iCurrRowIndex_].Cells[strDayColumn].Value == null)
                    {
                        return;
                    }

                    string ID = (string)ui_dtgTime.Rows[iCurrRowIndex_].Cells[strDayColumn].Value;
                    Time.SetValues(Cls.clsTimeManager.INSTANCE._DS4Time, Cls.clsTimeManager.INSTANCE._DS4Time.dtTime.FindByDay(ID));
                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :uctlTimeMain =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in EditTime()");
            }
            Time._ContainerCaption = "Edit Time Settings ";
            Time.ShowDialog();

        }

        void Time_OnDaySelect(object arg1, EventArgs arg2)
        {
            foreach (DataGridViewRow row in ui_dtgTime.Rows)
            {
                if (row.Cells["Day"].Value.ToString().Equals(arg1))
                {
                    row.Selected = true;
                    break;
                }
            }
        }

        private void ui_contextmnuCommon_Opening(object sender, CancelEventArgs e)
        {
            if (iCurrRowIndex_ >= 0)
            {
                if (ui_dtgTime.Rows.Count > 1)
                {

                }
                ui_contextmnuCommonEdit.Enabled = true;

            }
            else
            {
                ui_contextmnuCommonEdit.Enabled = false;

            }
        }

        private void ui_contextmnuCommon_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {

                case strEdit_:
                    {
                        EditTime();
                    }
                    break;
                default:
                    break;
            }
        }

        private void uctlTimeMain_Load(object sender, EventArgs e)
        {
            Init();
            ui_dtgTime.Columns["Day"].Width = 150;
            ui_dtgTime.Columns["TimeSpan"].HeaderText = "Time Span";
        }

        #region IUserCtrl Members

        void BOADMIN_NEW.Interfaces.IUserCtrl.Init()
        {
            throw new NotImplementedException();
        }

        void BOADMIN_NEW.Interfaces.IUserCtrl.InitControls()
        {
            throw new NotImplementedException();
        }

        void BOADMIN_NEW.Interfaces.IUserCtrl.SaveMe()
        {
            throw new NotImplementedException();
        }

        #endregion

        private void ui_dtgTime_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            iCurrRowIndex_ = ui_dtgTime.CurrentRow.Index;
            if (iCurrRowIndex_ == -1)
                return;
            else if (_isEditable == true)
                EditTime();
        }
    }
}
