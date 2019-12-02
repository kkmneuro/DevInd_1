///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION	
//05 July 2016	Namo		Module Created
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using TWS.Cls;

namespace TWS.Frm
{
    public partial class frmOrderSimulator : frmBase
    {
        int AccountOpenTrade = 0;
        int AccountCloseTrade = 0;
        int TotalOrdersPlaced = 0;
        int TotalOrders = 0;
        DateTime _startTime = DateTime.Now;
        Thread ThreadOpenTrade;
        Thread ThreadCloseTrade;
        string Contract = string.Empty;
        string Product = string.Empty;
        string ProductType = string.Empty;
        private readonly Random getrandom;
        private static Queue _queueOrders = new Queue();
        public Queue _syncOrderQueue = Queue.Synchronized(_queueOrders);
        private static Queue _queueOrderResponse = new Queue();
        public Queue _syncOrderResponse = Queue.Synchronized(_queueOrderResponse);
        Dictionary<long, int> dicOrderIdRowIndex;
        public frmOrderSimulator()
        {
            InitializeComponent();
            dicOrderIdRowIndex = new Dictionary<long, int>();
            Thread ThreadOpenOrder = new Thread(ThreadHandleOrderQueue);
            ThreadOpenOrder.IsBackground = true;
            ThreadOpenOrder.Start();
            Thread ThreadOrderResponse = new Thread(ThreadHandleOrderResponseQueue);
            ThreadOrderResponse.IsBackground = true;
            ThreadOrderResponse.Start();

            ThreadOpenTrade = new Thread(OpenTrades);
            ThreadCloseTrade = new Thread(CloseTrade);
            ThreadOpenTrade.IsBackground = true;
            ThreadCloseTrade.IsBackground = true;
            getrandom = new Random();
        }

        private void frmOrderSimulator_Load(object sender, EventArgs e)
        {
            Label.CheckForIllegalCrossThreadCalls = false;
            cmbProductType.Items.Clear();
            cmbProductType.Items.AddRange(ClsTWSContractManager.INSTANCE.LstProductTypes.ToArray());
            cmbProductType.SelectedIndexChanged += CmbProductType_SelectedIndexChanged;
            clsTWSOrderManagerJSON.INSTANCE.OnOrderResponse += INSTANCE_OnOrderResponse;

        }

        private void INSTANCE_OnOrderResponse(ExecutionReport obj)
        {
            try
            {
                Action A = () =>
                {
                    _syncOrderResponse.Enqueue(obj);
                    double ms = (DateTime.Now - _startTime).TotalMilliseconds;
                    TimeSpan t = TimeSpan.FromMilliseconds(ms);
                    string _time = string.Format("{0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms", t.Hours, t.Minutes, t.Seconds, t.Milliseconds);
                    lblEndTime.Text = _time;
                };
                if (InvokeRequired)
                {
                    BeginInvoke(A);
                }
                else
                {
                    A();
                }

            }
            catch (Exception)
            {

            }

        }

        private void ThreadHandleOrderQueue()
        {
            while (true)
            {

                if (_syncOrderQueue.Count == 0)
                {
                    Thread.Sleep(10);
                    //this will deflate the queue to size 0..
                    _syncOrderQueue.TrimToSize();
                    continue;
                }
                if (_syncOrderQueue.Count > 0)
                {
                    ClsNewOrder order = (ClsNewOrder)_syncOrderQueue.Dequeue();
                    PlaceOrder(order);
                }
                Thread.Sleep(0);

            }
        }
        private void PlaceOrder(ClsNewOrder order)
        {
            try
            {
                int OrderId = ClsGlobal.GetClientOrderID();
                order.ClOrdId = OrderId.ToString();
                order.OrderID = OrderId;
                clsTWSOrderManagerJSON.INSTANCE._syncOrderQueue.Enqueue(order);
                TotalOrdersPlaced++;
                Action A = () =>
                {
                    lblOrderCount.Text = TotalOrdersPlaced.ToString();
                };
                if (InvokeRequired)
                {
                    BeginInvoke(A);
                }
                else
                {
                    A();
                }

            }
            catch (Exception)
            {

            }
        }
        private void ThreadHandleOrderResponseQueue()
        {
            while (true)
            {

                if (_syncOrderResponse.Count == 0)
                {
                    Thread.Sleep(10);
                    //this will deflate the queue to size 0..
                    _syncOrderResponse.TrimToSize();
                    continue;
                }
                if (_syncOrderResponse.Count > 0)
                {
                    ExecutionReport order = (ExecutionReport)_syncOrderResponse.Dequeue();
                    UpdateOrderGrid(order);
                }
                Thread.Sleep(0);

            }
        }

        private void UpdateOrderGrid(ExecutionReport executionReport)
        {

            try
            {

                Action A = () =>
                {
                    string orderStatus = string.Empty;
                    string productType = string.Empty;
                    string side = string.Empty;
                    string orderType = string.Empty;
                    string timeInForce = string.Empty;
                    decimal AvgPrice = 0;
                    decimal Price = 0;
                    decimal LastPx = 0;
                    double qty = 0;

                    if (ClsGlobal.DDReverseOrderStatus.Keys.Contains(Convert.ToSByte(executionReport.OrderStatus)))
                        orderStatus = ClsGlobal.DDReverseOrderStatus[Convert.ToSByte(executionReport.OrderStatus)].ToUpper();
                    if (ClsGlobal.DDReverseProductType.Keys.Contains(Convert.ToSByte(executionReport.ProductType)))
                        productType = ClsGlobal.DDReverseProductType[Convert.ToSByte(executionReport.ProductType)];
                    if (ClsGlobal.DDReverseSide.Keys.Contains(Convert.ToSByte(executionReport.Side)))
                        side = ClsGlobal.DDReverseSide[Convert.ToSByte(executionReport.Side)];
                    if (ClsGlobal.DDReverseOrderType.Keys.Contains(Convert.ToSByte(executionReport.OrderType)))
                        orderType = ClsGlobal.DDReverseOrderType[Convert.ToSByte(executionReport.OrderType)];

                    string pType = string.Empty;
                    switch (productType)
                    {
                        case "EQ":
                            pType = "Equity";
                            break;
                        case "FUT":
                            pType = "FUTURE";
                            break;
                        case "FX":
                            pType = "FOREX";
                            break;
                        case "OPT":
                            pType = "OPTION";
                            break;
                        case "SP":
                            pType = "SPOT";
                            break;
                        case "PH":
                            pType = "PHYSICAL";
                            break;
                        case "AU":
                            pType = "AUCTION";
                            break;
                        case "BON":
                            pType = "BOND";
                            break;
                        default:
                            break;
                    };
                    InstrumentSpec objInstrumentSpec = ClsTWSContractManager.INSTANCE.ddContractDetails[executionReport.Contract];
                    if (executionReport.AvgPx > 0)
                    {
                        if (objInstrumentSpec != null)
                            AvgPrice = executionReport.AvgPx / Convert.ToDecimal(Math.Pow(10, objInstrumentSpec.Digits));
                    }
                    else
                        AvgPrice = executionReport.AvgPx;
                    if (executionReport.LastPx > 0)
                    {
                        if (objInstrumentSpec != null)
                            LastPx = executionReport.LastPx / Convert.ToDecimal(Math.Pow(10, objInstrumentSpec.Digits));
                    }
                    else
                        LastPx = executionReport.LastPx;
                    if (executionReport.OrderQty > 0)
                    {
                        if (objInstrumentSpec != null)
                            qty = Convert.ToDouble(executionReport.OrderQty / objInstrumentSpec.ContractSize);
                    }
                    else
                        qty = (double)executionReport.OrderQty;

                    if (orderType != "STOP" && orderType != "MARKET")
                    {
                        if (executionReport.Price > 0)
                        {
                            if (objInstrumentSpec != null)
                                Price = executionReport.Price / Convert.ToDecimal(Math.Pow(10, objInstrumentSpec.Digits));
                        }
                        else
                            Price = executionReport.Price;
                    }

                    string transactTime = string.Empty;
                    double OAdate = 0;
                    double.TryParse(executionReport.TransactTime, out OAdate);
                    transactTime = clsTWSOrderManagerJSON.INSTANCE.GetDateTimeFromOAdate(OAdate).ToString();
                    if (dicOrderIdRowIndex.ContainsKey(executionReport.OrderID))
                    {
                        int rowindex = dicOrderIdRowIndex[executionReport.OrderID];
                        dgvOrders.Rows[rowindex].Cells["clmPrice"].Value = Price;
                        dgvOrders.Rows[rowindex].Cells["clmAvgPrice"].Value = AvgPrice;
                        dgvOrders.Rows[rowindex].Cells["clmLTP"].Value = LastPx;
                        dgvOrders.Rows[rowindex].Cells["clmLUT"].Value = transactTime;
                        dgvOrders.Rows[rowindex].Cells["clmStatus"].Value = orderStatus;

                    }
                    else
                    {
                        dicOrderIdRowIndex.Add(executionReport.OrderID, dgvOrders.Rows.Count);
                        dgvOrders.Rows.Add(executionReport.Account, executionReport.OrderID, executionReport.Contract, orderType, side, orderStatus,
                            Price, AvgPrice, LastPx, qty, transactTime);
                    }
                    //lblEndTime.Text = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt");
                    //double ms = (DateTime.Now - _startTime).TotalMilliseconds;
                    //TimeSpan t = TimeSpan.FromMilliseconds(ms);
                    //string _time = string.Format("{0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms", t.Hours, t.Minutes, t.Seconds, t.Milliseconds);
                    //lblEndTime.Text = _time;
                    //dgvOrders.Refresh();
                };
                if (InvokeRequired)
                {
                    BeginInvoke(A);
                }
                else
                {
                    A();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CmbProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Action A = () =>
                {
                    cmbContract.SelectedIndexChanged -= cmbProduct_SelectedIndexChanged;
                    cmbProduct.Items.Clear();
                    cmbContract.Items.Clear();
                    cmbProduct.Items.AddRange(ClsTWSContractManager.INSTANCE.ddProductTypesProductContract[cmbProductType.Text].Keys.ToArray());
                    ProductType = cmbProductType.Text;
                    cmbProduct.SelectedIndexChanged += cmbProduct_SelectedIndexChanged;
                };
                if (InvokeRequired)
                {
                    BeginInvoke(A);
                }
                else
                {
                    A();
                }
            }
            catch (Exception)
            {


            }
        }

        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                Action A = () =>
                {
                    cmbContract.SelectedIndexChanged -= CmbContract_SelectedIndexChanged;
                    cmbContract.Items.Clear();
                    List<string> lstContacts = ClsTWSContractManager.INSTANCE.ddProductTypesProductContract[cmbProductType.Text][cmbProduct.Text];
                    cmbContract.Items.AddRange(lstContacts.ToArray());
                    Product = cmbProduct.Text;
                    cmbContract.SelectedIndexChanged += CmbContract_SelectedIndexChanged;
                };
                if (InvokeRequired)
                {
                    BeginInvoke(A);
                }
                else
                {
                    A();
                }
            }
            catch (Exception)
            {
            }
        }

        private void CmbContract_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                Action A = () =>
                {
                    Contract = cmbContract.Text;
                };
                if (InvokeRequired)
                {
                    BeginInvoke(A);
                }
                else
                {
                    A();
                }
            }
            catch (Exception)
            {
            }
        }

        private void ManageControlsStatus(bool status)
        {
            try
            {

                Action A = () =>
                {

                };
                if (InvokeRequired)
                {
                    BeginInvoke(A);
                }
                else
                {
                    A();
                }
            }
            catch (Exception)
            {
            }
        }

        private void txtAccountCloseTrade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsDigit(e.KeyChar) || e.KeyChar == '\b') && txtAccountCloseTrade.Text.Length < 4)
            {
                e.Handled = false;
            }
            else
            {
                if (e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void txtAccountOpenTrade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsDigit(e.KeyChar) || e.KeyChar == '\b') && txtAccountOpenTrade.Text.Length < 4)
            {
                e.Handled = false;
            }
            else
            {
                if (e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void ui_nbtnStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cmbProductType.Text))
                {
                    MessageBox.Show("Please select Product Type.");
                    cmbProductType.Focus();
                    return;
                }
                else if (string.IsNullOrEmpty(cmbProduct.Text))
                {
                    MessageBox.Show("Please select Product.");
                    cmbProduct.Focus();
                    return;
                }
                else if (string.IsNullOrEmpty(cmbContract.Text))
                {
                    MessageBox.Show("Please select Contract.");
                    cmbContract.Focus();
                    return;
                }
                else if (string.IsNullOrEmpty(txtAccountCloseTrade.Text))
                {
                    MessageBox.Show("Please enter Account Id to close trade.");
                    txtAccountCloseTrade.Focus();
                    return;
                }
                else if (string.IsNullOrEmpty(txtAccountOpenTrade.Text))
                {
                    MessageBox.Show("Please enter Account Id to open trade.");
                    txtAccountOpenTrade.Focus();
                    return;
                }
                else
                {
                    int.TryParse(txtAccountOpenTrade.Text, out AccountOpenTrade);
                    int.TryParse(txtAccountCloseTrade.Text, out AccountCloseTrade);
                    if (AccountOpenTrade <= 0)
                    {
                        MessageBox.Show("Please enter Account Id to close trade.");
                        txtAccountCloseTrade.Focus();
                        return;
                    }
                    else if (AccountCloseTrade <= 0)
                    {
                        MessageBox.Show("Please enter Account Id to open trade.");
                        txtAccountOpenTrade.Focus();
                        return;
                    }
                    else
                    {
                        ui_nbtnStart.Enabled = false;
                        ui_nbtnStop.Enabled = true;
                        TotalOrdersPlaced = 0;
                        _startTime = DateTime.Now;
                        lblEndTime.Text = string.Empty;
                        lblStartTime.Text = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt");
                        TotalOrders = (int)nudRunTime.Value;
                        if (ThreadOpenTrade == null)
                        {
                            ThreadOpenTrade = new Thread(OpenTrades);
                            ThreadOpenTrade.IsBackground = true;
                        }
                        else
                        {
                            ThreadOpenTrade.Start();
                        }
                        if (ThreadCloseTrade == null)
                        {
                            ThreadCloseTrade = new Thread(CloseTrade);
                            ThreadCloseTrade.IsBackground = true;
                        }
                        else
                        {
                            ThreadCloseTrade.Start();
                        }
                    }
                }
            }
            catch (Exception)
            {
                //ui_nbtnStart.Enabled = true;
                //ui_nbtnStop.Enabled = false;
            }
        }

        private void OpenTrades()
        {
            try
            {
                if (ClsGlobal.DDLTP.Keys.Contains(cmbContract.Text))
                {
                    int orderQty = 1;
                    int _side = 1;
                    InstrumentSpec spec = ClsTWSContractManager.INSTANCE.ddContractDetails[Contract];
                    if (spec != null)
                    {
                        for (int i = 0; i < TotalOrders; i++)
                        {
                            orderQty = (int)getrandom.Next(1, 100);
                            // _side = (int)getrandom.Next(1, 2);                            
                            double ltp = ClsGlobal.DDLTP[cmbContract.Text];
                            var objclsNewOrder = new ClsNewOrder();
                            objclsNewOrder.Account = AccountOpenTrade;
                            objclsNewOrder.ClOrdId = string.Empty;

                            objclsNewOrder.Contract = cmbContract.Text;

                            string pType = string.Empty;
                            switch (cmbProductType.Text)
                            {
                                case "EQUITY":
                                    pType = "EQ";
                                    break;
                                case "FUTURE":
                                    pType = "FUT";
                                    break;
                                case "FOREX":
                                    pType = "FX";
                                    break;
                                case "OPTION":
                                    pType = "OPT";
                                    break;
                                case "SPOT":
                                    pType = "SP";
                                    break;
                                case "PHYSICAL":
                                    pType = "PH";
                                    break;
                                case "AUCTION":
                                    pType = "AU";
                                    break;
                                case "BOND":
                                    pType = "BON";
                                    break;
                            };

                            objclsNewOrder.ProductType = Convert.ToChar(Cls.ClsGlobal.DDProductTypes[pType]);
                            objclsNewOrder.Product = cmbProduct.Text;
                            objclsNewOrder.ExpireDate = DateTime.Now.AddHours(1).Ticks;
                            objclsNewOrder.Gateway = spec.Gateway;
                            objclsNewOrder.OrderQty = (uint)(orderQty * spec.ContractSize);
                            objclsNewOrder.OrderType = '2';
                            objclsNewOrder.StopPx = 0;
                            if (_side == 2)
                            {
                                objclsNewOrder.Side = '2';
                                objclsNewOrder.Price = (ltp + 5) * Math.Pow(10, spec.Digits);
                                _side = 1;
                            }
                            else
                            {
                                objclsNewOrder.Side = '1';
                                objclsNewOrder.Price = (ltp - 5) * Math.Pow(10, spec.Digits);
                                _side = 2;
                            }
                            objclsNewOrder.TimeInForce = '0';
                            objclsNewOrder.PositionEffect = 'O';
                            objclsNewOrder.origClOrdId = "";
                            objclsNewOrder.ExpireDate = 0;
                            objclsNewOrder.LnkdOrdId = "";
                            _syncOrderQueue.Enqueue(objclsNewOrder);

                        }
                        //lblEndTime.Text = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt");
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void CloseTrade()
        {
            try
            {
                int orderQty = 1;
                int _side = 1;
                InstrumentSpec spec = ClsTWSContractManager.INSTANCE.ddContractDetails[Contract];
                if (spec != null)
                {
                    for (int i = 0; i < TotalOrders; i++)
                    {
                        orderQty = (int)getrandom.Next(1, 100);
                        //_side = (int)getrandom.Next(1, 2);

                        double ltp = ClsGlobal.DDLTP[cmbContract.Text];
                        var objclsNewOrder = new ClsNewOrder();
                        objclsNewOrder.Account = AccountCloseTrade;
                        objclsNewOrder.ClOrdId = string.Empty;
                        objclsNewOrder.Contract = cmbContract.Text;

                        string pType = string.Empty;
                        switch (cmbProductType.Text)
                        {
                            case "EQUITY":
                                pType = "EQ";
                                break;
                            case "FUTURE":
                                pType = "FUT";
                                break;
                            case "FOREX":
                                pType = "FX";
                                break;
                            case "OPTION":
                                pType = "OPT";
                                break;
                            case "SPOT":
                                pType = "SP";
                                break;
                            case "PHYSICAL":
                                pType = "PH";
                                break;
                            case "AUCTION":
                                pType = "AU";
                                break;
                            case "BOND":
                                pType = "BON";
                                break;
                        };

                        objclsNewOrder.ProductType = Convert.ToChar(Cls.ClsGlobal.DDProductTypes[pType]);
                        objclsNewOrder.Product = cmbProduct.Text;
                        objclsNewOrder.ExpireDate = DateTime.Now.AddHours(1).Ticks;
                        objclsNewOrder.Gateway = spec.Gateway;
                        objclsNewOrder.OrderQty = (uint)(orderQty * spec.ContractSize);
                        objclsNewOrder.OrderType = '1';
                        objclsNewOrder.StopPx = 0;
                        if (_side == 2)
                        {
                            objclsNewOrder.Side = '2';

                            if (ClsGlobal.DDLeftZLevel.Keys.Contains(cmbContract.Text))
                            {
                                objclsNewOrder.Price = ClsGlobal.DDLeftZLevel[cmbContract.Text] * Math.Pow(10, spec.Digits);

                            }
                            _side = 1;
                        }
                        else
                        {
                            objclsNewOrder.Side = '1';
                            if (ClsGlobal.DDRightZLevel.Keys.Contains(cmbContract.Text))
                            {
                                objclsNewOrder.Price = ClsGlobal.DDRightZLevel[cmbContract.Text] * Math.Pow(10, spec.Digits);

                            }
                            _side = 2;
                        }
                        objclsNewOrder.TimeInForce = '0';
                        objclsNewOrder.PositionEffect = 'O';
                        objclsNewOrder.origClOrdId = "";
                        objclsNewOrder.ExpireDate = 0;
                        objclsNewOrder.LnkdOrdId = "";
                        _syncOrderQueue.Enqueue(objclsNewOrder);

                    }
                    // lblEndTime.Text = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt");
                }
            }
            catch (Exception)
            {

            }
        }

        private void ui_nbtnStop_Click(object sender, EventArgs e)
        {
            try
            {
                ui_nbtnStart.Enabled = true;
                ui_nbtnStop.Enabled = false;
                if (ThreadOpenTrade != null && ThreadOpenTrade.IsAlive)
                {
                    ThreadOpenTrade.Abort();
                }
                if (ThreadCloseTrade != null && ThreadCloseTrade.IsAlive)
                {
                    ThreadCloseTrade.Abort();
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
