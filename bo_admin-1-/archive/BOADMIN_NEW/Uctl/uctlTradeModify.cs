using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DSSocket.Classes;
using ProtocolStructs;
using clsInterface4OME.DSBO;
using clsInterface4OME;
using BOADMIN_NEW.Cls;
using ProtocolStructs.NewPS;
using System.Reflection;
using BOADMIN_NEW.BOEngineServiceTCP;

namespace BOADMIN_NEW.Uctl
{
    /// <summary>
    /// Trade modify control
    /// </summary>
    public partial class uctlTradeModify : uctlGeneric, Interfaces.IUserCtrl
    {
       private int _accountID;
       private int _orderID;
       private int _rowIndex;
       private bool _dbTransact;
       private decimal _price;

       public decimal Price
       {
           get { return _price; }
           set { _price = value; }
       }
       public bool DbTransact
       {
           get { return _dbTransact; }
           set { _dbTransact = value; }
       }
        public uctlTradeModify(int AccountID, int OrderID, int RowIndex)
        {
            InitializeComponent();
            _accountID = AccountID;
            _orderID = OrderID;
            _rowIndex = RowIndex;
        }

        #region IUserCtrl Members

        public void Init()
        {
           
        }

        public void InitControls()
        {
           
        }

        public void SaveMe()
        {
            
        }

        #endregion

        private void ui_nbtnCancel_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        /// <summary>
        /// Handles modify event of the modify button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_nbtnModify_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ui_ntxtPrice.Text.Trim()) && Convert.ToDecimal(ui_ntxtPrice.Text.Trim()) == _price )
            {
                this.ParentForm.Close();
                return;
            }
            if (ui_ntxtPrice.Text==string.Empty)
            {
                 ModifyHandler(_orderID, _accountID,0);
            }
            else
            ModifyHandler(_orderID, _accountID, Convert.ToDecimal(ui_ntxtPrice.Text));
           
            this.ParentForm.Close();
        }

        /// <summary>
        /// Modify the order
        /// </summary>
        /// <param name="OrderID"></param>
        /// <param name="AccountID"></param>
        /// <param name="Price"></param>
        protected void ModifyHandler(int OrderID, int AccountID, decimal Price)
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("uctlTradeModify : Enter ModifyHandler()");
                string errorMsg = "Error in Modifying Trade";
                clsModifyTrades objclsModifyTrades = new clsModifyTrades();
                objclsModifyTrades.OrderID = OrderID;
                objclsModifyTrades.AccountID = AccountID;
                objclsModifyTrades.LastPrice = Price;

                objclsModifyTrades = clsProxyClassManager.INSTANCE.ModifyTrade(objclsModifyTrades);

                if (objclsModifyTrades.ServerResponseMsg != clsGlobal.FailureID)
                {
                    _dbTransact = true;
                    clsTradeManager.INSTANCE.FillTradeDataSet(DateTime.Now.Date, Convert.ToDateTime(DateTime.Now.Date.ToString().Replace("12:00:00 AM", "23:59:59 PM")));
                }
                if (objclsModifyTrades.ServerResponseMsg == clsGlobal.FailureID)
                {
                    clsDialogBox.ShowErrorBox(errorMsg, "BOAdmin", true);
                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :uctlTradeModify =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in ModifyHandler()");
            }
        }

        /// <summary>
        /// handles key press event of text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_ntxtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ui_ntxtPrice.Text.Contains('.'))
            {
                string[] price = ui_ntxtPrice.Text.Split('.');
                if (price[1].Length >= 5 && e.KeyChar != '\b')
                {
                    e.Handled = true;
                    return;
                }
                if (e.KeyChar == '.')
                {
                    e.Handled = true;
                    return;
                }
            }
            else if (ui_ntxtPrice.Text.Length > 5 && e.KeyChar != '\b' && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void ui_ntxtPrice_Leave(object sender, EventArgs e)
        {
            if (ui_ntxtPrice.Text==string.Empty)
            {
                ui_ntxtPrice.Text = "0";
            }
        }
    }
}
