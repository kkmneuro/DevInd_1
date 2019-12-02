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
using System.Collections;
using System.Reflection;
using System.Runtime.InteropServices;

namespace BOADMIN_NEW.Uctl
{
    public partial class uctlSymbolMain : uctlGeneric, Interfaces.IUserCtrl
    {
        #region MEMBERS

        int iCurrRowIndex_ = -1;
        //int iCurrColIndex_ = -1;
        DS4Symbol _SymbolMainDS4Symbol = new DS4Symbol();

        private bool _isEditable = false;
        const Int32 WM_LBUTTONDOWN = 0x0201;
        private const int WM_LBUTTONUP = 0x0202;
        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, uint uMsg, Int32 wParam, Int32 lParam);
        #endregion MEMBERS

        public uctlSymbolMain()
        {
            InitializeComponent();
            //clsSymbolManager.INSTANCE._DS4Symbol.dtContractInformation.RowDeleted += new DataRowChangeEventHandler(dtSymbol_RowDeleted);
            //clsSymbolManager.INSTANCE._DS4Symbol.dtContractInformation.TableNewRow += new DataTableNewRowEventHandler(dtSymbol_TableNewRow);
            //clsSymbolManager.INSTANCE._DS4Symbol.dtContractInformation.RowChanging += new DataRowChangeEventHandler(dtSymbol_RowChanging);
            //clsSymbolManager.INSTANCE._DS4Symbol.dtContractInformation.RowChanged += new DataRowChangeEventHandler(dtContractInformation_RowChanged);
        }

        void dtContractInformation_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            RefreshMe();
        }

        void dtSymbol_RowChanging(object sender, DataRowChangeEventArgs e)
        {
            DS4Symbol.dtContractInformationRow row = e.Row as DS4Symbol.dtContractInformationRow;
            int id = row.InstrumentID;
            int iRowLoop = 0;
            int iRowCount = ui_dtgSymbol.Rows.Count;
            bool flagcolor = false;
            for (iRowLoop = 0; iRowLoop < iRowCount; iRowLoop++)
            {
                if ((int)ui_dtgSymbol.Rows[iRowLoop].Cells["InstrumentID"].Value == id)
                {
                    flagcolor = true;
                    break;
                }

            }
            if (flagcolor)
            {
                //string strcolor = ui_dtgSymbol.Rows[iRowLoop].Cells["Background"].Value.ToString();
                //Color color = Color.FromName(strcolor);
                //for (int CellLoop = 0; CellLoop < ui_dtgSymbol.Rows[iRowLoop].Cells.Count; CellLoop++)
                //{
                //    ui_dtgSymbol.Rows[iRowLoop].Cells[CellLoop].Style.BackColor = color;
                //}
                RefreshMe();
            }
        }

        #region IUserCtrl Members
        /// <summary>
        /// Initialize info
        /// </summary>
        public void Init()
        {
            ui_dtgSymbol.DataSource = clsSymbolManager.INSTANCE._DS4Symbol.dtContractInformation;

            foreach (DataGridViewColumn item in ui_dtgSymbol.Columns)
            {
                item.Visible = false;
            }
            ui_dtgSymbol.Columns["Symbol"].Visible = true;
            ui_dtgSymbol.Columns["Description"].Visible = true;
            ui_dtgSymbol.Columns["Source"].Visible = true;
            ui_dtgSymbol.Columns["Digits"].Visible = true;
            ui_dtgSymbol.Columns["ExpiryDate"].Visible = true;
            ui_dtgSymbol.Columns["SecurityType"].Visible = true;
            ui_dtgSymbol.Columns["MarketLot"].Visible = true;
            ui_dtgSymbol.Columns["InitialBuyMargin"].Visible = true;
            ui_dtgSymbol.Columns["InitialSellMargin"].Visible = true;

            int id = (int)clsEnums.CommandIDS.CONTRACT_SPECIFICATION;
            string x = clsGlobal.Role.Split('_')[id];
            if (Convert.ToInt32(x.ToCharArray()[1].ToString()) == 0)
            {
                ui_contextmnuCommonAddContract.Visible = false;
                ui_contextmnuCommonNew.Visible = false;
            }
            else
            {
                ui_contextmnuCommonAddContract.Visible = true;
                ui_contextmnuCommonNew.Visible = true;
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

        public void InitControls()
        {
            ui_ncmbSecurityType.Items.Clear();
            ui_ncmbSecurityType.Items.Insert(0, "All");
            ui_ncmbSecurityType.Items.AddRange(Cls.clsSecurityManager.INSTANCE.GetSecurityNameArray());
            ui_ncmbSecurityType.SelectedIndex = 0;
            SetProductName();
        }

        private void SetProductName()
        {
            ui_ncmbProductName.Items.Clear();
            ui_ncmbProductName.Items.Insert(0, "All");
            //ArrayList col1Items = new ArrayList();
            //foreach (DataGridViewRow dr in ui_dtgSymbol.Rows)
            //{
            //    if (!col1Items.Contains(dr.Cells["Source"].Value))
            //    {
            //        col1Items.Add(dr.Cells["Source"].Value);
            //    }                
            //}

            //ui_ncmbProductName.Items.AddRange(col1Items.ToArray());
            ui_ncmbProductName.Items.AddRange(Cls.clsSymbolManager.INSTANCE.GetSymbolNameArray());
            ui_ncmbProductName.SelectedIndex = 0;
        }
        public void SaveMe()
        {
            throw new NotImplementedException();
        }

        #endregion
        /// <summary>
        /// Refresh grid
        /// </summary>
        void RefreshMe()
        {
            Action A = () =>
            {
                ////ui_dtgSymbol.DataSource = clsSymbolManager.INSTANCE._DS4Symbol.dtContractInformation;
                ui_dtgSymbol.ScrollBars = ScrollBars.None;
                ui_dtgSymbol.Refresh();

                if (ui_dtgSymbol.Rows.Count > 0)
                {
                    ui_dtgSymbol.FirstDisplayedScrollingRowIndex = ui_dtgSymbol.Rows.Count - 1;
                }

                ui_dtgSymbol.ScrollBars = ScrollBars.Both;
                SetProductName();
            };
            if (ui_dtgSymbol.InvokeRequired)
            {
                ui_dtgSymbol.BeginInvoke(A);

            }
            else
            {
                A();
            }
        }
        void dtSymbol_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            RefreshMe();
        }
        
        void dtSymbol_RowDeleted(object sender, DataRowChangeEventArgs e)
        {
            RefreshMe();
        }

        private void AddSymbol()
        {

        }

        private void DeleteSymbol()
        {
            // string strSymbolColumn = (clsSymbolManager.INSTANCE._DS4Symbol.dtSymbol).InstrumentIDColumn.Caption;
            // if (ui_dtgSymbol.Rows[iCurrRowIndex_].Cells[strSymbolColumn].Value == null)
            //{
            //    return;
            //}

            // int ID = (int)ui_dtgSymbol.Rows[iCurrRowIndex_].Cells[strSymbolColumn].Value;
            //uctlDelete Delete = new uctlDelete();
            //Delete._MGR = clsAccountManager.INSTANCE;
            //Delete._DBDelete._DeleteID = ProtocolStructs.ProtocolStructIDS.Symbol_ID;
            //Delete._DBDelete._DeleteKey = ID.ToString();
            //Delete._ContainerCaption = "Delete";
            //Delete.ShowDialog();
        }

        private void FindSymbol()
        {
            uctlFind Find = new uctlFind();

            Find._ContainerCaption = "Find";
            Find.ShowDialog();
        }

        private void FindNextSymbol()
        {
            uctlFind FindNext = new uctlFind();

            FindNext._ContainerCaption = "Find Next";
            FindNext.ShowDialog();
        }

        private void ui_dtgSymbol_MouseDown(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitinfo = ui_dtgSymbol.HitTest(e.X, e.Y);
            iCurrRowIndex_ = hitinfo.RowIndex;

            if (e.Button == MouseButtons.Right && e.Clicks == 1)
            {
                if (iCurrRowIndex_ < 0)
                {
                    ui_contextmnuCommon.Items[0].Enabled = false;
                    ui_contextmnuCommon.Items[1].Enabled = false;
                    ui_contextmnuCommon.Items[3].Enabled = false;
                    ui_contextmnuCommon.Items[4].Enabled = false;
                }
                else
                {
                    ui_contextmnuCommon.Items[0].Enabled = true;
                    ui_dtgSymbol.Rows[iCurrRowIndex_].Selected = true;
                    ui_contextmnuCommon.Items[1].Enabled = true;
                    ui_contextmnuCommon.Items[3].Enabled = true;
                    ui_contextmnuCommon.Items[4].Enabled = true;
                }
            }
        }
        /// <summary>
        /// Display dialog
        /// </summary>
        /// <param name="dialogType"></param>
        /// <param name="dialogTitle"></param>
        void DisplayProductContractsDialog(DialogType dialogType, string dialogTitle)
        {
            ////Forms.frmCommonContainer objfrmCommonContainer = new BOADMIN_NEW.Forms.frmCommonContainer();
            Uctl.uctlProductContracts objuctlProductContracts = new uctlProductContracts();

            bool isRowClick = true;
            if (iCurrRowIndex_ < 0)
                isRowClick = false;
            if (isRowClick)
            {
                string strSymbolColumn = (clsSymbolManager.INSTANCE._DS4Symbol.dtContractInformation).InstrumentIDColumn.Caption;
                if (ui_dtgSymbol.Rows[iCurrRowIndex_].Cells[strSymbolColumn].Value == null)
                {
                    return;
                }

                int ID = (int)ui_dtgSymbol.Rows[iCurrRowIndex_].Cells[strSymbolColumn].Value;

                objuctlProductContracts._row = clsSymbolManager.INSTANCE._DS4Symbol.dtContractInformation.FindByInstrumentID(ID);

            }
            ////objfrmCommonContainer.Controls.Clear();
            objuctlProductContracts.InitControls(dialogType);
            ////objfrmCommonContainer.Controls.Add(objuctlProductContracts);
            ////objfrmCommonContainer.Size = new Size(objuctlProductContracts.Width + 27, objuctlProductContracts.Height + 40);
            ////objfrmCommonContainer.Text = dialogTitle;

            ////objfrmCommonContainer.ShowDialog();
            objuctlProductContracts._ContainerCaption = dialogTitle;
            objuctlProductContracts.ShowDialog();
        }

        private void ui_contextmnuCommon_Opening(object sender, CancelEventArgs e)
        {
            if (iCurrRowIndex_ >= 0)
            {
                if (ui_dtgSymbol.Rows.Count > 1)
                {
                    ui_contextmnuCommonNew.Enabled = true;
                    ui_contextmnuCommonEdit.Enabled = true;
                    _isEditable = true;
                }
                ui_contextmnuCommonAddContract.Enabled = true;
                ui_contextmnuCommonDelete.Enabled = true;
                
            }
            else
            {
                ui_contextmnuCommonAddContract.Enabled = false;
                ui_contextmnuCommonDelete.Enabled = false;
                ui_contextmnuCommonNew.Enabled = false;
                ui_contextmnuCommonEdit.Enabled = false;
                
                _isEditable = false;
            }
        }
        /// <summary>
        /// Handles item checking
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_contextmnuCommon_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {


                switch (e.ClickedItem.Text)
                {
                    case "View":
                        ViewContextMenuHandler();
                        break;
                    case "Add Contract":
                        AddContractContextMenuHandler();
                        break;
                    case "New Contract":
                        NewContextMenuHandler();
                        break;
                    case "Edit":
                        EditContextMenuHandler();
                        break;
                    case "Delete":
                        DeleteContextMenuHandler();
                        break;
                }
            }
            catch (Exception)
            {

            }
        }

        private void DeleteContextMenuHandler()
        {
            string strSymbolColumn = (clsSymbolManager.INSTANCE._DS4Symbol.dtContractInformation).InstrumentIDColumn.Caption;
            if (ui_dtgSymbol.Rows[iCurrRowIndex_].Cells[strSymbolColumn].Value == null)
            {
                return;
            }

            int ID = (int)ui_dtgSymbol.Rows[iCurrRowIndex_].Cells[strSymbolColumn].Value;
            uctlDelete Delete = new uctlDelete();
            Delete._MGR = clsAccountManager.INSTANCE;
            Delete._DBDelete._DeleteID = ProtocolStructs.ProtocolStructIDS.Symbol_ID;
            Delete._DBDelete._DeleteKey = ID.ToString();
            Delete._ContainerCaption = "Delete Contract";
            Delete.ShowDialog();
        }

        private void EditContextMenuHandler()
        {
            DisplayProductContractsDialog(DialogType.Edit, "Edit Contract");
        }

        private void NewContextMenuHandler()
        {
            DisplayProductContractsDialog(DialogType.New, "New Contract");
        }

        private void AddContractContextMenuHandler()
        {
            DisplayProductContractsDialog(DialogType.AddContract, "Add Contract");
        }

        private void ViewContextMenuHandler()
        {
            DisplayProductContractsDialog(DialogType.View, "View Contract");
        }

        private void uctlSymbolMain_Load(object sender, EventArgs e)
        {
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, ui_dtgSymbol, new object[] { true });
            Init();
            InitControls();
            GridStyle();
        }
        private void GridStyle()
        {
            ui_dtgSymbol.Columns["Digits"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ui_dtgSymbol.Columns["MarketLot"].HeaderText = "Market Lot";
            ui_dtgSymbol.Columns["MarketLot"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ui_dtgSymbol.Columns["ExpiryDate"].HeaderText = "Expiry Date";
            ui_dtgSymbol.Columns["SecurityType"].HeaderText = "Security Type";
            ui_dtgSymbol.Columns["InitialBuyMargin"].HeaderText = "Initial Buy Margin";
            ui_dtgSymbol.Columns["InitialBuyMargin"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ui_dtgSymbol.Columns["InitialSellMargin"].HeaderText = "Initial Sell Margin";
            ui_dtgSymbol.Columns["InitialSellMargin"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        /// <summary>
        /// Handles security type selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_ncmbSecurityType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ui_ncmbSecurityType.Text == "All")
            {
                ui_dtgSymbol.DataSource = clsSymbolManager.INSTANCE._DS4Symbol.dtContractInformation;
                return;
            }

            if (ui_ncmbSecurityType.Text != "All" && ui_ncmbProductName.Text != "All")
            {
                DS4Symbol.dtContractInformationRow[] selectedRows = Cls.clsSymbolManager.INSTANCE.GetCSInfoByProductandSecurity(ui_ncmbSecurityType.Text, ui_ncmbProductName.Text);
                FilledSortedDataToGrid(selectedRows);
                return;
            }

            DS4Symbol.dtContractInformationRow[] rows = Cls.clsSymbolManager.INSTANCE.GetContractInformationBySecurityType(ui_ncmbSecurityType.Text);
            FilledSortedDataToGrid(rows);
        }
        /// <summary>
        /// Handles product name selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_ncmbProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ui_ncmbSecurityType.Text != "All" && ui_ncmbProductName.Text != "All")
            {
                DS4Symbol.dtContractInformationRow[] selectedRows = Cls.clsSymbolManager.INSTANCE.GetCSInfoByProductandSecurity(ui_ncmbSecurityType.Text, ui_ncmbProductName.Text);
                FilledSortedDataToGrid(selectedRows);
                return;
            }
            if (ui_ncmbSecurityType.Text != "All" && ui_ncmbProductName.Text == "All")
            {
                DS4Symbol.dtContractInformationRow[] selectedrows = Cls.clsSymbolManager.INSTANCE.GetContractInformationBySecurityType(ui_ncmbSecurityType.Text);
                FilledSortedDataToGrid(selectedrows);
                //ui_dtgSymbol.DataSource = clsSymbolManager.INSTANCE._DS4Symbol.dtContractInformation;
                return;
            }
            if (ui_ncmbSecurityType.Text == "All" && ui_ncmbProductName.Text == "All")
            {
                ui_dtgSymbol.DataSource = clsSymbolManager.INSTANCE._DS4Symbol.dtContractInformation;
                return;
            }

            DS4Symbol.dtContractInformationRow[] rows = Cls.clsSymbolManager.INSTANCE.GetContractInformationByProductName(ui_ncmbProductName.Text);
            FilledSortedDataToGrid(rows);
        }
        /// <summary>
        /// Sorts data of grid
        /// </summary>
        /// <param name="rows"></param>
        public void FilledSortedDataToGrid(DS4Symbol.dtContractInformationRow[] rows)
        {
            _SymbolMainDS4Symbol.dtContractInformation.Rows.Clear();
            if (rows != null)
            {
                foreach (DS4Symbol.dtContractInformationRow row in rows)
                {
                    DS4Symbol.dtContractInformationRow SymbolRow = _SymbolMainDS4Symbol.dtContractInformation.NewRow() as DS4Symbol.dtContractInformationRow;

                    SymbolRow.InstrumentID = row.InstrumentID;
                    SymbolRow.Symbol = row.Symbol;
                    SymbolRow.Description = row.Description;
                    SymbolRow.Source = row.Source;
                    SymbolRow.Digits = row.Digits;
                    SymbolRow.UA_Asset = row.UA_Asset;
                    SymbolRow.TradingCurrency = row.TradingCurrency;
                    SymbolRow.SettlingCurrency = row.SettlingCurrency;
                    SymbolRow.MarginCurrency = row.MarginCurrency;
                    //SymbolRow.Orders = row.Orders;
                    //SymbolRow.Spread = row.Spread;
                    SymbolRow.MaximumLots = row.MaximumLots;
                    SymbolRow.MaximumOrderValue = row.MaximumOrderValue;
                    SymbolRow.BuySideTurnover = row.BuySideTurnover;
                    SymbolRow.SellSideTurnover = row.SellSideTurnover;
                    SymbolRow.MaximumAllowablePosition = row.MaximumAllowablePosition;
                    SymbolRow.QuotationBaseValue = row.QuotationBaseValue;
                    SymbolRow.DeliveryType = row.DeliveryType;
                    SymbolRow.DeliveryUnit = row.DeliveryUnit;
                    SymbolRow.DeliveryQuantity = row.DeliveryQuantity;
                    SymbolRow.MarketLot = row.MarketLot;
                    SymbolRow.ExpiryDate = row.ExpiryDate;
                    SymbolRow.StartDate = row.StartDate;
                    SymbolRow.EndDate = row.EndDate;
                    SymbolRow.TenderStartDate = row.TenderStartDate;
                    SymbolRow.TenderEndDate = row.TenderEndDate;
                    SymbolRow.DeliveryStartDate = row.DeliveryStartDate;
                    SymbolRow.DeliveryEndDate = row.DeliveryEndDate;
                    SymbolRow.DPRInitialPercentage = row.DPRInitialPercentage;
                    SymbolRow.DPR_Range_Higher = row.DPR_Range_Higher;
                    SymbolRow.DPRInterval = row.DPRInterval;
                    SymbolRow.LimitandStopLevel = row.LimitandStopLevel;
                    //SymbolRow.SpreadBalance = row.SpreadBalance;
                    //SymbolRow.FreezeLevel = row.FreezeLevel;
                    SymbolRow.SecurityType = row.SecurityType;
                    SymbolRow.ContractSize = row.ContractSize;
                    SymbolRow.InitialBuyMargin = row.InitialBuyMargin;
                    SymbolRow.InitialSellMargin = row.InitialSellMargin;
                    SymbolRow.MaintenanceBuyMargin = row.MaintenanceBuyMargin;
                    SymbolRow.MaintenanceSellMargin = row.MaintenanceSellMargin;
                    SymbolRow.Hedged = row.Hedged;
                    SymbolRow.TickSize = row.TickSize;
                    SymbolRow.TickPrice = row.TickPrice;

                    _SymbolMainDS4Symbol.dtContractInformation.AdddtContractInformationRow(SymbolRow);
                }
            }

            ui_dtgSymbol.DataSource = _SymbolMainDS4Symbol.dtContractInformation;
        }

        private void nbtnSearch_Click(object sender, EventArgs e)
        {
            DS4Symbol.dtContractInformationRow[] SymbolRow = Cls.clsSymbolManager.INSTANCE.GetRow(ui_ncmbSecurityType.Text, ui_ncmbProductName.Text, ui_ntxtSymbol.Text, ui_ndtpExpiryDate.Value.ToString());
            FilledSortedDataToGrid(SymbolRow);

        }

        private void ui_ntxtSymbol_TextChanged(object sender, EventArgs e)
        {
            if (ui_ntxtSymbol.Text == string.Empty)
            {
                ui_dtgSymbol.DataSource = clsSymbolManager.INSTANCE._DS4Symbol.dtContractInformation;
            }
            else
            {
                DS4Symbol.dtContractInformationRow[] rows = Cls.clsSymbolManager.INSTANCE.GetRows(ui_ncmbSecurityType.Text, ui_ncmbProductName.Text, ui_ntxtSymbol.Text);
                FilledSortedDataToGrid(rows);
            }
        }

        private void ui_dtgSymbol_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ui_dtgSymbol.Rows.Count == 0)
            {
                return;
            }
            iCurrRowIndex_ = ui_dtgSymbol.CurrentRow.Index;
            if (iCurrRowIndex_ == -1)
                return;
            else if(_isEditable==true)
                EditContextMenuHandler();
        }

        private void ui_ndtpExpiryDate_ValueChanged(object sender, EventArgs e)
        {
            DS4Symbol.dtContractInformationRow[] SymbolRow = Cls.clsSymbolManager.INSTANCE.GetRows(ui_ndtpExpiryDate.Value.ToString());
            FilledSortedDataToGrid(SymbolRow);
        }

        private void ui_dtgSymbol_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void nButton1_Click(object sender, EventArgs e)
        {
            MouseEventArgs cc = new MouseEventArgs(MouseButtons.Left, 1, 204, 8, 0);
            Int32 x = this.ui_ndtpExpiryDate.Width - 10;
            Int32 y = this.ui_ndtpExpiryDate.Height / 2;
            Int32 lParam = x + y * 0x00010000;
            SendMessage(ui_ndtpExpiryDate.Handle, WM_LBUTTONDOWN, 1, lParam);
            SendMessage(ui_ndtpExpiryDate.Handle, WM_LBUTTONUP, 1, lParam);
        }

        private void ui_dtgSymbol_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

    public enum DialogType
    {
        View,
        AddContract,
        Edit,
        New
    }
}
