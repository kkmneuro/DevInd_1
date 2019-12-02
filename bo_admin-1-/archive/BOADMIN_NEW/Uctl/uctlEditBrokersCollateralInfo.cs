using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using ProtocolStructs;
using BOADMIN_NEW.Cls;
using clsInterface4OME.DSBO;
using BOADMIN_NEW.BOEngineServiceTCP;

namespace BOADMIN_NEW.Uctl
{
    /// <summary>
    /// Edit collateral information
    /// </summary>
    public partial class uctlEditBrokersCollateralInfo : UserControl
    {
        public int _AccountGroupID = 0;
        public uctlEditBrokersCollateralInfo()
        {
            InitializeComponent();
            clsCollateralManager.INSTANCE._DS4BrokerCollateralInfo.dtLastCollateralTransaction.RowChanged += dtLastCollateralTransaction_RowChanged;
        }

        /// <summary>
        /// Refreshes data source
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void dtLastCollateralTransaction_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            try
            {
                Action a = () =>
                {
                    ui_ndgvSummeryCollateral.DataSource = Cls.clsCollateralManager.INSTANCE._DS4BrokerCollateralInfo.dtLastCollateralTransaction.Select("FK_AccountGroupID=" + _AccountGroupID);
                };
                if (this.InvokeRequired)
                {
                    this.ui_ndgvSummeryCollateral.BeginInvoke(a);
                    return;
                }
                a();
            }
            catch (Exception)
            {

            }


        }

        /// <summary>
        /// Saves collateral information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_nbtnSave_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dr in ui_ndgvEntryCollateral.Rows)
            {
               double result;
               if (dr.Cells["EAmount"].Value != null && !double.TryParse(dr.Cells["EAmount"].Value.ToString(), out result))
               {
                   clsDialogBox.ShowErrorBox("Amount has invalid value", "Collateral", true);
                   return;
               }
                if (dr.Cells["EAmount"].Value != null && Convert.ToDecimal(dr.Cells["EAmount"].Value.ToString()) > 0)
                {
                    decimal TotalAmount = 0;
                    string TransactionType;
                    BrokerLastCollateralTransaction collateralTransaction = new BrokerLastCollateralTransaction
                                                                                {
                                                                                    _AccountGroupId = _AccountGroupID,
                                                                                    _Amount =
                                                                                        Convert.ToDecimal(
                                                                                            dr.Cells["EAmount"].Value),
                                                                                    _CollateralType =
                                                                                        Convert.ToString(
                                                                                            dr.Cells["ECollateralType"].
                                                                                                Value),
                                                                                    _CollateralTypeId =
                                                                                        Convert.ToInt32(
                                                                                            dr.Cells["CollateralTypeId"].
                                                                                                Value)
                                                                                };
                    DS4BrokerCollateralInfo.dtLastCollateralTransactionRow drLastCollateralTrans = Cls.clsCollateralManager.INSTANCE._DS4BrokerCollateralInfo.dtLastCollateralTransaction.FirstOrDefault(i => i.FK_AccountGroupId == _AccountGroupID && i.FK_CollateralTypeId == Convert.ToInt32(dr.Cells["CollateralTypeId"].Value.ToString())) as DS4BrokerCollateralInfo.dtLastCollateralTransactionRow;//.Select("FK_AccountGroupID=" + _AccountGroupID + " and FK_CollateralTypeId=" + dr.Cells["CollateralTypeId"].Value.ToString())


                    decimal oldCommulative = 0;
                    if (drLastCollateralTrans != null)
                        oldCommulative = drLastCollateralTrans.TotalAmount;
                    if (dr.Cells["TransactionType"].Value == null || dr.Cells["TransactionType"].Value.ToString() == transactionType.Deposit.ToString())
                    {
                        TransactionType = transactionType.Deposit.ToString();
                        TotalAmount = oldCommulative + Convert.ToDecimal(dr.Cells["EAmount"].Value);
                        if (TotalAmount.ToString().Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries)[0].Length > 16)
                        {
                            clsDialogBox.ShowErrorBox("Total amount exceeds the limit", "Collateral Error", true);
                            return;
                        }
                    }
                    else
                    {
                        TransactionType = transactionType.Withdraw.ToString();
                        TotalAmount = oldCommulative - Convert.ToDecimal(dr.Cells["EAmount"].Value);
                    }
                    collateralTransaction._TotalAmount = TotalAmount;

                    collateralTransaction._TransactionType = TransactionType;
                    InsertCollateralTransaction(collateralTransaction);

                }
            }
        }

        /// <summary>
        /// Insert collateral information
        /// </summary>
        /// <param name="collateralTransaction"></param>
        private void InsertCollateralTransaction(BrokerLastCollateralTransaction collateralTransaction)
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("uctlEditBrokersCollateralInfo : Enter InsertCollateralTransaction()");
                clsCollateralTransInfo objCTInfo = new clsCollateralTransInfo
                                                       {
                                                           AccountGroupId = collateralTransaction._AccountGroupId,
                                                           Amount = collateralTransaction._Amount,
                                                           CollateralType = collateralTransaction._CollateralType,
                                                           CollateralTypeId = collateralTransaction._CollateralTypeId,
                                                           TotalAmount = collateralTransaction._TotalAmount,
                                                           TransactionType = collateralTransaction._TransactionType
                                                       };

                objCTInfo = clsProxyClassManager.INSTANCE.InsertCollateralTransInfo(objCTInfo);
                const string errorMsg = "Error in inserting CollateralTransInfo";
                string opMsg;
                opMsg = "Added collateral of Broker ID : " +collateralTransaction._AccountGroupId+" Amount : "+collateralTransaction._Amount
                    +" Total Amount : "+collateralTransaction._TotalAmount+" Transaction Type : "+collateralTransaction._TransactionType;
                if (objCTInfo.ServerResponseID != clsGlobal.FailureID)
                {
                    {
                        clsBrokerOperationsLog objclsBrokerOpLog = new clsBrokerOperationsLog();
                        objclsBrokerOpLog.OperationName = "Collateral Updated";
                        //objclsBrokerOpLog.ControlName = "Collateral";
                        objclsBrokerOpLog.Message = opMsg;
                        clsProxyClassManager.INSTANCE.HandleOperationsLog(OperationTypes.INSERT, objclsBrokerOpLog);
                    }
                    System.Threading.ThreadPool.QueueUserWorkItem(ProcessCollateralTransData, objCTInfo);
                }
                else if (objCTInfo.ServerResponseID == clsGlobal.FailureID)
                {
                    clsDialogBox.ShowErrorBox(errorMsg, "BOAdmin", true);
                }

                this.ParentForm.Close();
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :uctlEditBrokersCollateralInfo =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in InsertCollateralTransaction()");
            }
        }

        public void ProcessCollateralTransData(object obj)
        {
            clsCollateralManager.INSTANCE.DoHandleBrokerCollateralTransTable(obj as clsCollateralTransInfo);
        }
        private void ui_nbtnCancel_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        public event Action<object, EventArgs> OnCancelClick = delegate { };

        enum transactionType { Deposit, Withdraw };

        /// <summary>
        /// Initializes control elements
        /// </summary>
        internal void InitControls()
        {
            clsCollateralManager.INSTANCE.FillDataToCollateralTransDataSet(clsProxyClassManager.INSTANCE.GetCollateralTransInfoRecords(_AccountGroupID));
            if (_AccountGroupID == 0) return;
            ui_ndgvSummeryCollateral.DataSource = Cls.clsCollateralManager.INSTANCE._DS4BrokerCollateralInfo.dtLastCollateralTransaction.Select("FK_AccountGroupID=" + _AccountGroupID);
            ui_ndgvEntryCollateral.DataSource = Cls.clsCollateralManager.INSTANCE._DS4BrokerCollateralInfo.dtCollateralTypeMaster;
            ui_nEBoxAccountGroup.EditControl.Text = Cls.clsCollateralManager.INSTANCE.GetGroupName(_AccountGroupID);
            ui_ntxtParent.Text = Cls.clsCollateralManager.INSTANCE._DS4BrokerCollateralInfo.dtBrokerCollateralInfo.Select("AccountGroupId=" + _AccountGroupID)[0]["ParentOwner"].ToString();
            ui_ntxtOwner.Text = Cls.clsCollateralManager.INSTANCE._DS4BrokerCollateralInfo.dtBrokerCollateralInfo.Select("AccountGroupId=" + _AccountGroupID)[0]["Owner"].ToString();
            HideAllColumns();
            StyleEntryGrid();
            StyleSummeryGrid();
        }

        private void HideAllColumns()
        {
            foreach (DataGridViewColumn dc in ui_ndgvEntryCollateral.Columns)
            {
                dc.Visible = false;
            }
            foreach (DataGridViewColumn dc in ui_ndgvSummeryCollateral.Columns)
            {
                dc.Visible = false;
            }
        }
        /// <summary>
        /// Style grid
        /// </summary>
        private void StyleSummeryGrid()
        {
            ui_ndgvSummeryCollateral.Columns["CollateralType"].Visible = true;
            ui_ndgvSummeryCollateral.Columns["Amount"].Visible = true;
            ui_ndgvSummeryCollateral.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ui_ndgvSummeryCollateral.Columns["TotalAmount"].Visible = true;
            ui_ndgvSummeryCollateral.Columns["TotalAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ui_ndgvSummeryCollateral.Columns["TransType"].Visible = true;
            ui_ndgvSummeryCollateral.Columns["TransactionDate"].Visible = true;
            ui_ndgvSummeryCollateral.Columns["ui_clmTransactionHistory"].Visible = true;
        }

        private void StyleEntryGrid()
        {
            ui_ndgvEntryCollateral.Columns["ECollateralType"].Visible = true;
            ui_ndgvEntryCollateral.Columns["EAmount"].Visible = true;
            ui_ndgvEntryCollateral.Columns["EAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ui_ndgvEntryCollateral.Columns["TransactionType"].Visible = true;
            ((DataGridViewComboBoxColumn)ui_ndgvEntryCollateral.Columns["TransactionType"]).DataSource = Enum.GetNames(typeof(transactionType));
        }

        private void ui_ndgvEntryCollateral_EditModeChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles cell click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_ndgvSummeryCollateral_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ui_ndgvSummeryCollateral.Columns[e.ColumnIndex].HeaderText != "Trans History" || e.RowIndex <= -1)
                return;
            uctlCollateralTransactionHistory objuctlCTH = new uctlCollateralTransactionHistory();
            Forms.frmCommonContainer objfrmCommonContainer = new BOADMIN_NEW.Forms.frmCommonContainer();
            objfrmCommonContainer.Controls.Add(objuctlCTH);
            objfrmCommonContainer.Text = "Transaction History";
            objfrmCommonContainer.ClientSize = objuctlCTH.Size;
            objuctlCTH.LoadHistory(_AccountGroupID, ui_ndgvSummeryCollateral.Rows[e.RowIndex].Cells["CollateralType"].Value.ToString());
            objfrmCommonContainer.ShowDialog(this.ParentForm);
        }

    }
}
