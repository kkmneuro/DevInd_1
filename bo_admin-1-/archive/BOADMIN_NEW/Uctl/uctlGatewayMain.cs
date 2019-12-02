using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BOADMIN_NEW.Cls;

namespace BOADMIN_NEW.Uctl
{
    public partial class uctlGatewayMain : uctlGeneric, Interfaces.IUserCtrl
    {
        int iCurrRowIndex_ = -1;
        int iCurrColIndex_ = -1;

        private bool _isEditable = false;

        public uctlGatewayMain()
        {
            InitializeComponent();

            //Cls.clsTradingGatewayManager.INSTANCE._DS4TradingGateway.dtTradingGateway.RowDeleted += new DataRowChangeEventHandler(dtTradingGateway_RowDeleted);
            Cls.clsTradingGatewayManager.INSTANCE._DS4TradingGateway.dtTradingGateway.TableNewRow += new DataTableNewRowEventHandler(dtTradingGateway_TableNewRow);
        }

        void dtTradingGateway_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            RefreshMe();
        }

        void dtTradingGateway_RowDeleted(object sender, DataRowChangeEventArgs e)
        {
            RefreshMe();
        }

        void RefreshMe()
        {
            Action A = () =>
            {
                ////ui_ndgvGatewayMain.DataSource = Cls.clsTradingGatewayManager.INSTANCE._DS4TradingGateway.dtTradingGateway;
                ui_ndgvGatewayMain.ScrollBars = ScrollBars.None;
                ui_ndgvGatewayMain.Refresh();

                if (ui_ndgvGatewayMain.Rows.Count > 0)
                {
                    //ui_ndtgOrders.Rows[ui_ndtgOrders.Rows.Count - 1].Selected = true;
                    ui_ndgvGatewayMain.FirstDisplayedScrollingRowIndex = ui_ndgvGatewayMain.Rows.Count - 1;
                }

                ui_ndgvGatewayMain.ScrollBars = ScrollBars.Both;
            };
            if (ui_ndgvGatewayMain.InvokeRequired)
            {
                ui_ndgvGatewayMain.BeginInvoke(A);

            }
            else
            {
                A();
            }
        }

        private void uctlGatewayMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (ui_ndgvGatewayMain.Rows.Count == 0)
            {
                ui_cmsGateway.Items[1].Enabled = false;
                return;
            }
            DataGridView.HitTestInfo hitinfo = ui_ndgvGatewayMain.HitTest(e.X, e.Y);
            iCurrRowIndex_ = hitinfo.RowIndex;//ui_ndgvGatewayMain.Rows.IndexOf(ui_ndgvGatewayMain.SelectedRows[0]); //hitinfo.RowIndex;
            iCurrColIndex_ = hitinfo.ColumnIndex;
            if (e.Button == MouseButtons.Left && iCurrRowIndex_ >= 0)
            {
                if (e.Clicks == 2 && e.Button == MouseButtons.Left && _isEditable == true)//Double Click
                {
                    DisplayGatewayDialog(DialogType.Edit, "Edit");
                }
            }
            if (e.Button == MouseButtons.Right && iCurrRowIndex_ < 0)
            {
                ui_cmsGateway.Items[1].Enabled = false;
            }
            else
            {
                ui_cmsGateway.Items[1].Enabled = true;
            }
        }

        private void EditMenuHandler()
        {
            DisplayGatewayDialog(DialogType.Edit, "Edit");
        }

        private void AddNewMenuHandler()
        {
            //DisplayGatewayDialog(DialogType.New, "Add New");
            uctlGateway objuctlGateway = new uctlGateway();
            objuctlGateway.SetValues(null, null, DialogType.New);
            Forms.frmCommonContainer objfrmCommonContainer = new BOADMIN_NEW.Forms.frmCommonContainer();
            objfrmCommonContainer.Controls.Clear();
            objfrmCommonContainer.ClientSize = objuctlGateway.Size;
            objuctlGateway.Dock = DockStyle.Fill;
            objfrmCommonContainer.Text = "Add New";
            objfrmCommonContainer.Controls.Add(objuctlGateway);
            objfrmCommonContainer.ShowDialog();
        }

        public void DisplayGatewayDialog(DialogType dialogMode, string dialogText)
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("uctlGatewayMain : Enter DisplayGatewayDialog()");
                bool isRowClick = true;
                if (iCurrRowIndex_ < 0)
                    isRowClick = false;
                uctlGateway objuctlGateway = new uctlGateway();
                if (isRowClick)
                {
                    string strTradingGatewayColumn = (Cls.clsTradingGatewayManager.INSTANCE._DS4TradingGateway.dtTradingGateway).PK_TradingGateWaysIDColumn.Caption;
                    if (ui_ndgvGatewayMain.Rows[iCurrRowIndex_].Cells[strTradingGatewayColumn].Value == null)
                    {
                        return;
                    }
                    int ID = (int)ui_ndgvGatewayMain.Rows[iCurrRowIndex_].Cells[strTradingGatewayColumn].Value;
                    objuctlGateway.currentyDialogType = dialogMode;
                    objuctlGateway.SetValues(Cls.clsTradingGatewayManager.INSTANCE._DS4TradingGateway, Cls.clsTradingGatewayManager.INSTANCE._DS4TradingGateway.dtTradingGateway.FindByPK_TradingGateWaysID(ID), dialogMode);
                }
                Forms.frmCommonContainer objfrmCommonContainer = new BOADMIN_NEW.Forms.frmCommonContainer();
                objfrmCommonContainer.Controls.Clear();
                objfrmCommonContainer.ClientSize = objuctlGateway.Size; //new Size(objuctlGateway.Width, objuctlGateway.Height);
                objuctlGateway.Dock = DockStyle.Fill;
                objfrmCommonContainer.Text = dialogText;
                objfrmCommonContainer.Controls.Add(objuctlGateway);
                objfrmCommonContainer.ShowDialog();
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :uctlGatewayMain =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in DisplayGatewayDialog()");
            }
        }

        #region IUserCtrl Members

        public void Init()
        {
            int id = (int)clsEnums.CommandIDS.TRADING_GATEWAY;
            string x = clsGlobal.Role.Split('_')[id];
            if (Convert.ToInt32(x.ToCharArray()[1].ToString()) == 0)
            {
                ui_tsmAddNew.Visible = false;
            }
            else
            {
                ui_tsmAddNew.Visible = true;
            }
            if (Convert.ToInt32(x.ToCharArray()[2].ToString()) == 0)
            {
                ui_tsmEdit.Visible = false;
                _isEditable = false;
            }
            else
            {
                ui_tsmEdit.Visible = true;
                _isEditable = true;
            }

            ui_ndgvGatewayMain.DataSource = Cls.clsTradingGatewayManager.INSTANCE._DS4TradingGateway.dtTradingGateway;

            ui_ndgvGatewayMain.Columns["PK_TradingGateWaysID"].Visible = false;
            ui_ndgvGatewayMain.Columns["IdleTimeOut"].Visible = false;
            ui_ndgvGatewayMain.Columns["ReconnectAfter"].Visible = false;
            ui_ndgvGatewayMain.Columns["SleepFor"].Visible = false;
            ui_ndgvGatewayMain.Columns["Attempts"].Visible = false;
            ui_ndgvGatewayMain.Columns["IsEnable"].Visible = false;
        }

        public void InitControls()
        {

        }

        public void SaveMe()
        {

        }

        #endregion

        private void uctlGatewayMain_Load(object sender, EventArgs e)
        {
            Init();
            ui_ndgvGatewayMain.Columns["DataType"].HeaderText = "Data Type";
            ui_ndgvGatewayMain.Columns["Server_IP"].HeaderText = "Server IP";
            ui_ndgvGatewayMain.Columns["EnableRMS"].Visible = false;
            ui_ndgvGatewayMain.Columns["OrderPort"].Visible = false;
            ui_ndgvGatewayMain.Columns["Port"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void ui_tsmAddNew_Click(object sender, EventArgs e)
        {
            AddNewMenuHandler();
        }

        private void ui_tsmEdit_Click(object sender, EventArgs e)
        {
            EditMenuHandler();
        }
    }
}
