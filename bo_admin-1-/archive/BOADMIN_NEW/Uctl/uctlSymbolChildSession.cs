using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DSSocket;
using ProtocolStructs;
using clsInterface4OME.DSBO;
using BOADMIN_NEW.Cls;

namespace BOADMIN_NEW.Uctl
{
    public partial class uctlSymbolChildSession : uctlGeneric, Interfaces.IUserCtrl
    {

        public DS4Symbol.dtSessionDataTable _dtSessionDataTable = new DS4Symbol.dtSessionDataTable();
        public uctlCustomSessionSettingsNew _uctlCustomSessionSettings;
        public DS4Symbol.dtContractInformationRow _SymbolRow = null;
        public clsEnums.FRM_MODE _mode = clsEnums.FRM_MODE.NA;
        int iCurrRowIndex_ = -1;
        int iCurrColIndex_ = -1;
        public uctlSymbolChildSession()
        {

            InitializeComponent();
        }

        private void nuiPanel1_Click(object sender, EventArgs e)
        {

        }



        #region IUserCtrl Members

        public void Init()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Initialize session grid
        /// </summary>
        public void InitializeSessionGrid()
        {
            _dtSessionDataTable.Clear();
            string[] Arr = Enum.GetNames(typeof(DAYS));
            foreach (string item in Arr)
            {
                DS4Symbol.dtSessionRow SessRow = _dtSessionDataTable.NewdtSessionRow();
                SessRow.Day = item;
                _dtSessionDataTable.AdddtSessionRow(SessRow);

            }
            ui_dgvSession.DataSource = _dtSessionDataTable;
            ui_dgvSession.Columns["FK_InstrumentID"].Visible = false;
            ui_dgvSession.Columns["UseTimeLimits"].Visible = false;
            ui_dgvSession.Columns["StartDate"].Visible = false;
            ui_dgvSession.Columns["EndDate"].Visible = false;
            ui_chkusetimelimit.Checked = false;
            ui_dtpEndDate.Value = ui_dtpEndDate.MinDate;
            ui_dtpStartDate.Value = ui_dtpStartDate.MinDate;
            EnableDateOfSession(ui_chkusetimelimit.Checked);
        }
        /// <summary>
        /// Initialize controls info
        /// </summary>
        public void InitControls()
        {
            if (_SymbolRow == null)   //commented by vijay on 08 April
            {
                InitializeSessionGrid();

                return;
            }
            DS4Symbol.dtSessionRow[] SessionRow = (DS4Symbol.dtSessionRow[])clsSymbolManager.INSTANCE.GetSession(_SymbolRow.InstrumentID);
            _dtSessionDataTable.Clear();
            InitializeSessionGrid();
            foreach (DS4Symbol.dtSessionRow item in SessionRow)
            {
                //DS4Symbol.dtSessionRow SessRow = _dtSessionDataTable.NewdtSessionRow(); //commented by vijay on 08 April
                DS4Symbol.dtSessionRow[] SessRows = (DS4Symbol.dtSessionRow[])_dtSessionDataTable.Select("Day ='" + item.Day + "'");
                DS4Symbol.dtSessionRow SessRow = SessRows[0];
                SessRow.Day = item.Day;
                SessRow.Trade = item.Trade;
                SessRow.Quotes = item.Quotes;
                SessRow.SessionEODMM = item.SessionEODMM;
                ui_chkusetimelimit.Checked = item.UseTimeLimits;
                ui_dtpEndDate.Value = item.EndDate;
                ui_dtpStartDate.Value = item.StartDate;
                //_dtSessionDataTable.AdddtSessionRow(SessRow);   //commented by vijay on 08 April
            }

            ui_dgvSession.DataSource = _dtSessionDataTable;
            ui_dgvSession.Columns["FK_InstrumentID"].Visible = false;
            ui_dgvSession.Columns["UseTimeLimits"].Visible = false;
            ui_dgvSession.Columns["StartDate"].Visible = false;
            ui_dgvSession.Columns["EndDate"].Visible = false;
            ui_dgvSession.Columns["SessionEODMM"].Visible = false;
            EnableDateOfSession(ui_chkusetimelimit.Checked);
        }

        public void SaveMe()
        {
            throw new NotImplementedException();
        }

        #endregion

        private void uctlSymbolChildSession_Load(object sender, EventArgs e)
        {
            if (ui_dgvSession.Columns.Count > 2)
                ui_dgvSession.Columns[1].Width = 120;//["Day"]
        }

        private void ui_chkusetimelimit_CheckedChanged(object sender, EventArgs e)
        {
            EnableDateOfSession(ui_chkusetimelimit.Checked);

        }

        private void EnableDateOfSession(bool boolValue)
        {
            if (boolValue == true)
            {
                ui_dtpEndDate.Enabled = true;
                ui_dtpStartDate.Enabled = true;
            }
            else
            {
                ui_dtpEndDate.Enabled = false;
                ui_dtpStartDate.Enabled = false;
            }
        }

        private void ui_dgvSession_MouseDown(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitinfo = ui_dgvSession.HitTest(e.X, e.Y);
            iCurrRowIndex_ = hitinfo.RowIndex;
            iCurrColIndex_ = hitinfo.ColumnIndex;
            if (e.Button == MouseButtons.Left && iCurrRowIndex_ >= 0)
            {
                if (e.Clicks == 2 && e.Button == MouseButtons.Left)//Double Click
                {
                    EditSession();
                }
            }
        }
        /// <summary>
        /// Edit session info
        /// </summary>
        private void EditSession()
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("uctlSymbolChildSession : Enter EditSession()");
                bool isRowClick = true;
                if (iCurrRowIndex_ < 0)
                    isRowClick = false;
                _uctlCustomSessionSettings = new uctlCustomSessionSettingsNew();
                _uctlCustomSessionSettings.OnDaySelect += new Action<object, EventArgs>(_uctlCustomSessionSettings_OnDaySelect);
                if (isRowClick)
                {
                    string ID = (string)ui_dgvSession.Rows[iCurrRowIndex_].Cells["Day"].Value;
                    _uctlCustomSessionSettings._ContainerCaption = "Session of " + _uctlCustomSessionSettings.GetDay(ID);
                    _uctlCustomSessionSettings.SetValues(ID);
                }
                _uctlCustomSessionSettings.ShowDialog();
                _uctlCustomSessionSettings.Dispose();
                ui_dgvSession.DataSource = _dtSessionDataTable;//clsGroupManager.INSTANCE._DS4Groups.dtSymbol;
                _dtSessionDataTable.AcceptChanges();
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :uctlSymbolChildSession =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in EditSession()");
            }
        }

        void _uctlCustomSessionSettings_OnDaySelect(object arg1, EventArgs arg2)
        {
            foreach (DataGridViewRow row in ui_dgvSession.Rows)
            {
                if (row.Cells["Day"].Value.ToString().Equals(arg1))
                {
                    row.Selected = true;
                    break;
                }
            }
            _uctlCustomSessionSettings._row = (DS4Symbol.dtSessionRow[])_dtSessionDataTable.Select("Day = '" + arg1 + "'");
        }

        public void ClearControlsText()
        {

        }

    }
}
