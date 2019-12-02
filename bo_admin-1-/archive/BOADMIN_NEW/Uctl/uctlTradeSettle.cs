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
    public partial class uctlTradeSettle : uctlGeneric, Interfaces.IUserCtrl
    {
        private long _settledOrderID;
        private int _accountID;
        private long _maxSettleQty;
        private char _orderType;
        private char _orderStatusID;
        private char _side;
        private string _symbol;
        private char _tif;
        private string _iPAddress;
        private float _usedMargin;
        private int _closeQty;
        private double _price;
        private long _positionSize;
        private bool _dbTransact;

        public bool DbTransact
        {
            get { return _dbTransact; }
            set { _dbTransact = value; }
        }

        public long SettledOrderID
        {
            get { return _settledOrderID; }
            set { _settledOrderID = value; }
        }

        public int AccountID
        {
            get { return _accountID; }
            set { _accountID = value; }
        }

        public long MaxSettleQty
        {
            get { return _maxSettleQty; }
            set { _maxSettleQty = value; }
        }

        public char OrderType
        {
            get { return _orderType; }
            set { _orderType = value; }
        }

        public char OrderStatusID
        {
            get { return _orderStatusID; }
            set { _orderStatusID = value; }
        }

        public char Side
        {
            get { return _side; }
            set { _side = value; }
        }

        public string Symbol
        {
            get { return _symbol; }
            set { _symbol = value; }
        }

        public char Tif
        {
            get { return _tif; }
            set { _tif = value; }
        }

        public string IPAddress
        {
            get { return _iPAddress; }
            set { _iPAddress = value; }
        }

        public float UsedMargin
        {
            get { return _usedMargin; }
            set { _usedMargin = value; }
        }

        public int CloseQty
        {
            get { return _closeQty; }
            set { _closeQty = value; }
        }

        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public long PositionSize
        {
            get { return _positionSize; }
            set { _positionSize = value; }
        }

        public uctlTradeSettle()
        {
            InitializeComponent();
        }

        private void ui_nbtnCancel_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
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

        private void ui_nbtnSettle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ui_ntxtQty.Text.Trim()))
            {
                DialogResult result = clsDialogBox.ShowErrorBox("Please provide settle quantity.", "Server Responce", true);
                ui_ntxtQty.Text = _positionSize.ToString();
                ui_ntxtQty.Focus();
                return;
            }
            if (Convert.ToInt64(ui_ntxtQty.Text) > _maxSettleQty)
            {
                DialogResult result = clsDialogBox.ShowErrorBox("Only " + _maxSettleQty + " positions can be settled for Order ID : " + _settledOrderID, "Server Responce", true);
                ui_ntxtQty.Text = _positionSize.ToString();
                ui_ntxtQty.Focus();
                return;
            }

            if (Convert.ToInt64(ui_ntxtQty.Text.Trim()) <= 0)
            {
                DialogResult result = clsDialogBox.ShowErrorBox("Please provide a valid settle quantity.", "Server Responce", true);
                ui_ntxtQty.Text = _positionSize.ToString();
                ui_ntxtQty.Focus();
                return;
            }
            if (string.IsNullOrEmpty(ui_ntxtPrice.Text.Trim()) || Convert.ToInt64(ui_ntxtQty.Text.Trim()) <= 0)
            {
                DialogResult result = clsDialogBox.ShowErrorBox("Please provide settle Price.", "Server Responce", true);
                ui_ntxtPrice.Text = _price.ToString();
                ui_ntxtPrice.Focus();
                return;
            }
            SettleTradeHandler(_settledOrderID, _accountID, Convert.ToInt64(ui_ntxtQty.Text), Convert.ToDouble(ui_ntxtPrice.Text), _orderType, _orderStatusID, _side, _symbol, _tif, _iPAddress, _usedMargin, _closeQty, Convert.ToInt32(ui_ntxtQty.Text));

            this.ParentForm.Close();
        }
        protected void SettleTradeHandler(long SettledOrderID, int AccountID, long PositionSize, double Price, char OrderType, char OrderStatusID, char Side, string Symbol, char TIF, string IPAddress, float UsedMargin, int CloseQty, int SettledQty)
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("uctlTradeSettle : Enter SettleTradeHandler()");
                string errorMsg = "Error in Settle Trade";
                clsSettleTrade objclsSettleTrade = new clsSettleTrade();

                objclsSettleTrade.SettledOrderID = SettledOrderID;
                objclsSettleTrade.AccountID = AccountID;
                objclsSettleTrade.PositionSize = PositionSize;
                objclsSettleTrade.Price = Convert.ToInt64(Price);
                objclsSettleTrade.OrderType = OrderType;
                objclsSettleTrade.OrderStatusID = OrderStatusID;
                objclsSettleTrade.Side = Side;
                objclsSettleTrade.Symbol = Symbol;
                objclsSettleTrade.TIF = TIF;
                objclsSettleTrade.IPAddress = IPAddress;
                objclsSettleTrade.UsedMargin = UsedMargin;
                objclsSettleTrade.CloseQty = CloseQty;
                objclsSettleTrade.SettledQty = SettledQty;

                objclsSettleTrade = clsProxyClassManager.INSTANCE.SettleTrade(objclsSettleTrade);

                if (objclsSettleTrade.ServerResponseMsg != clsGlobal.FailureID)
                {
                    _dbTransact = true;
                    clsTradeManager.INSTANCE.FillTradeDataSet(DateTime.Now.Date, Convert.ToDateTime(DateTime.Now.Date.ToString().Replace("12:00:00 AM", "23:59:59 PM")));

                    clsBrokerOperationsLog objclsBrokerOpLog = new clsBrokerOperationsLog();
                    objclsBrokerOpLog.OperationName = "Order Settled";
                    objclsBrokerOpLog.Message = "Order Id : " + SettledOrderID.ToString() + " of AccountID : " + AccountID.ToString() + " is settled."+
                    " ORDER DETAILS =>> Order Id : " + SettledOrderID.ToString() + ", Account : " + AccountID.ToString() + ", Qty : " + PositionSize.ToString() + ", Symbol : " +Symbol+", Price : "+Price.ToString();
                    clsProxyClassManager.INSTANCE.HandleOperationsLog(OperationTypes.INSERT, objclsBrokerOpLog);
                }
                if (objclsSettleTrade.ServerResponseMsg == clsGlobal.FailureID)
                {
                    clsDialogBox.ShowErrorBox(errorMsg, "BOAdmin", true);
                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :uctlTradeModify =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in ModifyHandler()");
            }
        }


        private void uctlTradeSettle_Load(object sender, EventArgs e)
        {
            ui_ntxtPrice.Text = _price.ToString();
            ui_ntxtQty.Text = _positionSize.ToString();
        }

        private void ui_ntxtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            //if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.' && e.KeyChar != '-')
            //{
            //    e.Handled = true;
            //}
            //else
            //{
            //    clsGlobal.KeyPressHandler(ui_ntxtPrice.Text, e, BOADMIN_NEW.Cls.clsEnums.TextType.Real, 18, 2);
            //}
        }

        private void ui_ntxtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

    }
}
