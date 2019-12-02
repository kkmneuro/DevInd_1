using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using System.Collections;
using WebSocket4Net;
using TWS.DS;
using CommonLibrary.Cls;
using System.Timers;
using System.Globalization;
using System.Reflection;
using System.IO;

namespace TWS.Cls
{
    class clsTWSOrderManagerJSON
    {

        #region "    Contant members    "
        //Message Type						   
        const int LOGON_REQUEST = 1;
        const int LOGON_RESPONSE = 2;
        const int LOGOUT_REQUEST = 3;
        const int NEW_ORDER_REQUEST = 4;
        const int ORDER_CANCEL_REQUEST = 5;
        const int ORDER_REPLACE_REQUEST = 6;
        const int ACCOUNT_REQUEST = 8;
        const int POSITION_REQUEST = 9;
        const int ORDER_HISTORY_REQUEST = 10;
        const int PARTICIPANT_LIST_REQUEST = 11;
        const int ORDER_STATUS_RESPONSE = 13;
        const int ACCOUNT_RESPONSE = 16;
        const int PARTICIPANT_LIST_RESPONSE = 17;
        const int POSITION_RESPONSE = 18;
        const int BUSINESS_LEVEL_REJECT = 19;
        const int ORDER_HISTORY_RESPONSE = 27;
        const int LOGOUT_RESPONSE = 32;
        const int TRADE_HISTORY_REQUEST = 33;
        const int TRADE_HISTORY_RESPONSE = 34;
        const int LINKED_ORDER_REQUEST = 50;


        // Order Type
        const char ORDER_TYPE_MARKET_ORDER = '1';
        const char ORDER_TYPE_LIMIT_ORDER = '2';
        const char ORDER_TYPE_STOP_ORDER = '3';
        const char ORDER_TYPE_STOP_LIMIT_ORDER = '4';
        // Side
        const char SIDE_BUY = '1';
        const char SIDE_SELL = '2';
        //Time in Force
        const char TIF_DAY = '0';
        const char TIF_GOOD_TILL_CANCEL = '1';
        const char TIF_FOK = '3';
        const char TIF_GOOD_TILL_DATE = '6';

        //Security Type or Product Type
        const char SECURITY_TYPE_FUT = '1';
        const int SECURITY_TYPE_OPT = 2;
        const int SECURITY_TYPE_EQ = 3;
        const int SECURITY_TYPE_SP = 4;
        const int SECURITY_TYPE_BON = 5;
        const int SECURITY_TYPE_FX = 0;
        const int SECURITY_TYPE_PH = 6;
        const int SECURITY_TYPE_AU = 7;
        const int SECURITY_TYPE_IND = 8;
        const int SECURITY_TYPE_CFD = 9;

        //Order Status Type
        const char ORDER_STATUS_NEW = '0';
        const char ORDER_STATUS_PARTIALLY_FILLED = '1';
        const char ORDER_STATUS_FILLED = '2';
        const char ORDER_STATUS_CANCEL = '4';
        const char ORDER_STATUS_REPLACED = '5';
        const char ORDER_STATUS_PENDING_CANCEL = '6';
        const char ORDER_STATUS_REJECTED = '8';
        const char ORDER_STATUS_PENDINGNEW = 'A';
        const char ORDER_STATUS_EXPIRED = 'C';
        const char ORDER_STATUS_PENDINGREPLACE = 'E';
        const char ORDER_STATUS_UNDEFINED = 'U';
        const char ORDER_STATUS_ORDER_NOT_FOUND = 'Y';

        #endregion "    Contant members    "

        #region "        MEMBERS        "

        public string StatusMessage { get; set; }
        public readonly Dictionary<string, AccountDetails> _DDAccountInfo = new Dictionary<string, AccountDetails>();
        public Dictionary<int, DataRow> _DDAccounts = new Dictionary<int, DataRow>();
        public Dictionary<int, string> _DDAccountTraderName = new Dictionary<int, string>();
        public Dictionary<string, string> _DDMessages = new Dictionary<string, string>();
        public List<KeyValuePair<string, DataRow>> _DDNetPos = new List<KeyValuePair<string, DataRow>>();
        public Dictionary<string, DataRow> _DDNetPosRow = new Dictionary<string, DataRow>();
        public Dictionary<long, DataRow> _DDOrderRow = new Dictionary<long, DataRow>();
        public Dictionary<long, DataRow> _DDTradeRow = new Dictionary<long, DataRow>();
        public List<string> PosContracts = new List<string>();
        public DS4MessageLog messageLogDS = new DS4MessageLog();
        public DS4AccountInfo accountInfoDS = new DS4AccountInfo();
        public DS4NetPosition netpositionDS = new DS4NetPosition();
        public DS4OrderHistory orderHistoryDS = new DS4OrderHistory();
        public DS4TradeHistory tradeHistoryDS = new DS4TradeHistory();
        //MailBoxData obj = new MailBoxData(); //Namo urgent
        private static List<string> _productTypes = new List<string>();
        private bool _flagFirstParticipantListResponce;
        public bool _isTradeHistoryLoaded = true;
        public object objLock = new object();
        public List<int> _orderId = new List<int>();
        private List<int> _lstOrderHistoryAccountId = new List<int>();
        System.Timers.Timer timer = new System.Timers.Timer();
        bool _isTradeResponceReceived = false;
        private static clsTWSOrderManagerJSON _instance;
        WebSocket websocket;
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        private string UserName;
        private string Password;
        private string webSocketHostUrl;
        List<Symbol> lst = new List<Symbol>();
        bool isRelogin = false;
        bool isSpashClosed = false;
        private static object _lockObject;
        private static Queue _queue = new Queue();
        public Queue _syncJSONQueue = Queue.Synchronized(_queue);
        private static Queue _queueOrders = new Queue();
        public Queue _syncOrderQueue = Queue.Synchronized(_queueOrders);
        string logPath = string.Empty;

        #endregion "      MEMBERS          "

        #region "     PROPERTIES        "

        private clsTWSOrderManagerJSON()
        {

            try
            {
                orderHistoryDS = new DS4OrderHistory();
                tradeHistoryDS = new DS4TradeHistory();
                _DDOrderRow = new Dictionary<long, DataRow>();
                netpositionDS = new DS4NetPosition();
                _DDNetPosRow = new Dictionary<string, DataRow>();
                _DDMessages = new Dictionary<string, string>();
                string path = Assembly.GetExecutingAssembly().Location;
                FileInfo fileInfo = new FileInfo(path);
                //logPath = fileInfo.DirectoryName + "\\Logs\\WebSocket\\";
                logPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments) + "\\TWS\\WebSocketLogs\\";
                Thread ThreadLog = new System.Threading.Thread(ThreadHandleQueue);
                ThreadLog.IsBackground = true;
                ThreadLog.Start();
                Thread ThreadOrder = new System.Threading.Thread(ThreadHandleOrderQueue);
                ThreadOrder.IsBackground = true;
                ThreadOrder.Start();

            }
            catch (Exception ex)
            {

                _syncJSONQueue.Enqueue("ERROR >> clsTWSOrderManagerJSON >> " + ex.Message);
            }

        }

        public static object LockObject
        {
            get
            {
                return _lockObject ?? (_lockObject = new object());
            }
        }

        public static clsTWSOrderManagerJSON INSTANCE
        {
            get { return _instance ?? (_instance = new clsTWSOrderManagerJSON()); }
        }

        public bool IsOrderMgrLoaded { get; private set; }

        #endregion "     PROPERTIES

        #region "       EVENTS          "

        public event Action<string, string, bool> OnChangePasswordResponse = delegate { };
        public event Action<string, string, bool> OnLogonResponse = delegate { };
        public event Action<ExecutionReport> OnOrderResponse = delegate { };
        public event Action<ExecutionReport> DoHandleExecutionReport = delegate { };
        public event Action<List<ExecutionReport>> DoHandleTradeHistoryResponse = delegate { };
        public event Action<ExecutionReport> OnOrderPendingNew = delegate { };
        public event Action<string> OnOrderServerConnectionEvnt = delegate { };
        public event Action<string> OnTradeLog;
        public event Action<string> OnOrderLog = delegate { };
        public event Action<string> OnShortOrderUpdate = delegate { };
        public event Action<DataRow, BusinessReject> OnBusinessLevelReject = delegate { };
        public event Action<List<AccountDetails>> OnAccountResponse = delegate { };
        public event Action<string> OnBothServerConnectionEvnt = delegate { };
        public event Action<Dictionary<int, DataRow>> OnParticipantResponse = delegate { };
        public event Action<List<Position>> OnPositionResponse = delegate { };
        public event Action OnOrderHistoryResponse = delegate { };
        public event Action OnMailDeliveryResponse = delegate { };
        public event Action OnOrderSettle = delegate { };
        public event Action OnTradeHistoryLoaded = delegate { };
        public event Action<int> OnPositionUpdate = delegate { };
        public event Action<List<Cls.Position>> PositionResponse = delegate { };

        #endregion

        #region "        Methods        "

        public void Init(string username, string pwd, string hostUrl)
        {
            try
            {
                clsTWSDataManagerJSON.INSTANCE.OnLTPChange2 -= INSTANCE_OnLTPChange;
                clsTWSDataManagerJSON.INSTANCE.OnLTPChange2 += INSTANCE_OnLTPChange;
                if (websocket != null && websocket.State == WebSocketState.Open)
                {
                    //Logout();
                    websocket.Close();
                    websocket = null;
                }
                UserName = username;
                Password = pwd;
                webSocketHostUrl = hostUrl;
                websocket = new WebSocket(hostUrl.Trim());
                websocket.Opened -= websocket_Opened;
                websocket.Error -= websocket_Error;
                websocket.Closed -= websocket_Closed;
                websocket.MessageReceived -= websocket_MessageReceived;
                websocket.EnableAutoSendPing = false;
                websocket.Opened += websocket_Opened;
                websocket.Error += websocket_Error;
                websocket.Closed += websocket_Closed;
                websocket.MessageReceived += websocket_MessageReceived;
                websocket.Open();
            }
            catch (Exception ex)
            {
                _syncJSONQueue.Enqueue("ERROR >> Init >> " + ex.Message);
            }

        }

        public void DisconnectOrderServer()
        {
            if (websocket != null)
            {
                if (websocket.State == WebSocketState.Open)
                {
                    websocket.Close();
                }
                websocket = null;
            }
        }


        void websocket_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            try
            {
                _syncJSONQueue.Enqueue("FROM SERVER :" + e.Message + Environment.NewLine);
                SocketResponce _socketResponce = serializer.Deserialize<SocketResponce>(e.Message);

                if (_socketResponce.msgtype == LOGON_RESPONSE)
                {
                    logonResponce collection = serializer.Deserialize<logonResponce>(e.Message);
                    OnLogonResponse(collection.Reason, collection.BrokerName, isRelogin);
                    if (collection.Reason == "VALID")
                    {
                        IsOrderMgrLoaded = true;
                        if (!isRelogin)
                        {
                            Properties.Settings.Default.UserName = Cls.ClsGlobal.GetTWSProductName() + " " + collection.BrokerName;
                            Properties.Settings.Default.AccountType = collection.AccountType;

                            LogOrderStatus("Order Server : ConnectionStatus Connected");
                            isSpashClosed = false;
                            participantRequest();
                        }
                        OnOrderServerConnectionEvnt("Connected");
                        //isRelogin = true;
                    }
                    else
                    {
                        LogOrderStatus("Order Server : ConnectionStatus DisConnected");
                    }

                }
                else if (_socketResponce.msgtype == LOGOUT_RESPONSE)
                {


                }
                else if (_socketResponce.msgtype == PARTICIPANT_LIST_RESPONSE)
                {
                    ParticipantCollection collection = serializer.Deserialize<ParticipantCollection>(e.Message);
                    if (collection.accountInfo != null)
                    {
                        onParticipantResponse(collection.accountInfo, Convert.ToBoolean(collection.islastPck));
                    }

                }
                else if (_socketResponce.msgtype == ORDER_STATUS_RESPONSE)
                {
                    Cls.ExecutionReport objExecutionReport = serializer.Deserialize<Cls.ExecutionReport>(e.Message);
                    OnOrderResponse(objExecutionReport);
                    onExecutionReport(objExecutionReport);

                }
                else if (_socketResponce.msgtype == ACCOUNT_RESPONSE)
                {
                    AccountCollection collection = serializer.Deserialize<AccountCollection>(e.Message);
                    if (collection.AccountInfo != null)
                    {
                        onAccountResponse(collection.AccountInfo, Convert.ToBoolean(collection.islastPck));
                    }
                }
                else if (_socketResponce.msgtype == POSITION_RESPONSE)
                {
                    PositionCollection collection = serializer.Deserialize<PositionCollection>(e.Message);
                    if (collection.Position != null)
                    {
                        onPositionResponse(collection.Position, Convert.ToBoolean(collection.islastPck));
                    }
                }
                else if (_socketResponce.msgtype == BUSINESS_LEVEL_REJECT)
                {
                    BusinessReject objBusinessReject = serializer.Deserialize<BusinessReject>(e.Message);
                    onBusinessLevelReject(objBusinessReject);
                }
                else if (_socketResponce.msgtype == ORDER_HISTORY_RESPONSE)
                {
                    OrdersCollection objOrderCollection = serializer.Deserialize<OrdersCollection>(e.Message);
                    onOrderHistoryResponse(objOrderCollection.orderHistory, Convert.ToBoolean(objOrderCollection.islastPck));
                }
                else if (_socketResponce.msgtype == TRADE_HISTORY_RESPONSE)
                {
                    TradeCollection objTradeCollection = serializer.Deserialize<TradeCollection>(e.Message);
                    onTradeHistoryResponse(objTradeCollection.executionReport, Convert.ToBoolean(objTradeCollection.islastPck));
                }
                else if (_socketResponce.msgtype == LOGOUT_RESPONSE)
                {
                    OnOrderServerConnectionEvnt("DisConnected");
                }
                else if (_socketResponce.msgtype == LINKED_ORDER_REQUEST)
                {

                }
                else
                {
                    //log(e.Message);
                }


            }
            catch (Exception ex)
            {
                _syncJSONQueue.Enqueue("Error at websocket_MessageReceived >> " + ex.Message);
            }

        }

        void websocket_Closed(object sender, EventArgs e)
        {
            try
            {
                _syncJSONQueue.Enqueue("CONNECTION CLOSED" + Environment.NewLine);
                OnOrderServerConnectionEvnt("DisConnected");
                IsOrderMgrLoaded = false;
                //  recponnect();
            }
            catch (Exception ex)
            {

                _syncJSONQueue.Enqueue("ERROR >> websocket_Closed >> " + ex.Message);
            }

        }

        void reconnect()
        {
            try
            {
                if (websocket != null)
                {
                    if (websocket.State == WebSocketState.Open)
                    {
                        websocket.Close();
                    }
                    websocket = null;
                }
                websocket = new WebSocket(webSocketHostUrl);
                websocket.Opened -= websocket_Opened;
                websocket.Error -= websocket_Error;
                websocket.Closed -= websocket_Closed;
                websocket.MessageReceived -= websocket_MessageReceived;
                websocket.EnableAutoSendPing = false;
                websocket.Opened += websocket_Opened;
                websocket.Error += websocket_Error;
                websocket.Closed += websocket_Closed;
                websocket.MessageReceived += websocket_MessageReceived;
                websocket.Open();
            }
            catch (Exception ex)
            {

                _syncJSONQueue.Enqueue("ERROR >> reconnect >> " + ex.Message);
            }
        }
        void websocket_Error(object sender, SuperSocket.ClientEngine.ErrorEventArgs e)
        {
            try
            {
                _syncJSONQueue.Enqueue("websocket_Error >> " + e.Exception + Environment.NewLine);
                OnOrderServerConnectionEvnt("DisConnected");
                if (websocket.State != WebSocketState.Open)
                {
                    //recponnect();
                }
            }
            catch (Exception ex)
            {
                _syncJSONQueue.Enqueue("ERROR >> websocket_Error >> " + ex.Message);
            }

        }

        void websocket_Opened(object sender, EventArgs e)
        {
            try
            {
                _syncJSONQueue.Enqueue("CONNECTION OPENED" + Environment.NewLine);
                userDetails objUser = new userDetails();
                objUser.UserName = UserName;
                objUser.Password = Password;
                objUser.SenderID = Cls.ClsGlobal.BrokerGroupId.ToString();
                objUser.Version = 1.15;
                objUser.msgtype = LOGON_REQUEST;

                var json = new JavaScriptSerializer().Serialize(objUser);
                websocket.Send(json);
                _syncJSONQueue.Enqueue("TO SERVER :" + json + Environment.NewLine);
            }
            catch (Exception ex)
            {
                _syncJSONQueue.Enqueue("ERROR >> websocket_Opened >> " + ex.Message);
            }

        }

        public void Logout()
        {
            try
            {
                _syncJSONQueue.Enqueue("CONNECTION OPENED" + Environment.NewLine);
                LogoutRequest objUser = new LogoutRequest();
                objUser.UserName = UserName;
                objUser.msgtype = LOGOUT_REQUEST;

                var json = new JavaScriptSerializer().Serialize(objUser);
                websocket.Send(json);
                _syncJSONQueue.Enqueue("TO SERVER :" + json + Environment.NewLine);
            }
            catch (Exception ex)
            {
                _syncJSONQueue.Enqueue("ERROR >> Logout >> " + ex.Message);
            }
        }

        private void LogOrderStatus(string x)
        {
            SetOrderLog(x);
        }

        private void SetOrderLog(string msg)
        {
            try
            {
                if (OnOrderLog != null)
                {
                    OnOrderLog(msg);
                }
            }
            catch (Exception ex)
            {

                _syncJSONQueue.Enqueue("ERROR >> SetOrderLog >> " + ex.Message);
            }

        }

        public void onTradeHistoryResponse(List<ExecutionReport> lstExecutionReport, bool islastPck)
        {
            if (!_isTradeResponceReceived)
            {
                _isTradeResponceReceived = true;
            }

            if (lstExecutionReport.Count > 0)
            {
                int _accountId = 0;

                lock (tradeHistoryDS.dtTradeHistory)
                {
                    foreach (ExecutionReport item in lstExecutionReport)
                    {
                        try
                        {

                            if (_accountId == 0)
                            {
                                _accountId = Convert.ToInt32(item.Account);
                            }
                            string orderStatus = string.Empty;
                            if (ClsGlobal.DDReverseOrderStatus.Keys.Contains(Convert.ToSByte(item.OrderStatus)))
                                orderStatus = ClsGlobal.DDReverseOrderStatus[Convert.ToSByte(item.OrderStatus)].ToUpper();

                            if (!orderStatus.ToUpper().Contains("FILLED"))
                                continue;
                            string productType = string.Empty;
                            string side = string.Empty;
                            string orderType = string.Empty;
                            string timeInForce = string.Empty;
                            if (ClsGlobal.DDReverseProductType.Keys.Contains(Convert.ToSByte(item.ProductType)))
                                productType = ClsGlobal.DDReverseProductType[Convert.ToSByte(item.ProductType)];
                            if (ClsGlobal.DDReverseSide.Keys.Contains(Convert.ToSByte(item.Side)))
                                side = ClsGlobal.DDReverseSide[Convert.ToSByte(item.Side)];
                            if (ClsGlobal.DDReverseOrderType.Keys.Contains(Convert.ToSByte(item.OrderType)))
                                orderType = ClsGlobal.DDReverseOrderType[Convert.ToSByte(item.OrderType)];
                            if (ClsGlobal.DDReverseValidity.Keys.Contains(Convert.ToSByte(item.TimeInForce)))
                                timeInForce = ClsGlobal.DDReverseValidity[Convert.ToSByte(item.TimeInForce)];
                            DataRow dr = tradeHistoryDS.dtTradeHistory.NewRow();
                            string transactTime = string.Empty;
                            double OAdate = 0;
                            double.TryParse(item.TransactTime, out OAdate);
                            //  if (item.TransactTime != string.Empty)
                            {
                                transactTime = GetDateTimeFromOAdate(OAdate).ToString();
                            }
                            if (item.Account.ToString().Trim() == "")
                            {
                                _syncJSONQueue.Enqueue("Null Account");
                            }

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
                            }
                            ;

                            //InstrumentSpec objInstrumentSpec = ClsTWSContractManager.INSTANCE.GetContractSpec(item.Contract, pType, item.Product);

                            if (ClsTWSContractManager.INSTANCE.ddContractDetails.ContainsKey(item.Contract))
                            {
                                InstrumentSpec objInstrumentSpec = ClsTWSContractManager.INSTANCE.ddContractDetails[item.Contract];

                                dr["Account"] = item.Account;
                                dr["TradeNo"] = item.ExecID;
                                dr["OrderNo"] = item.ClOrdId;
                                dr["ProductType"] = pType;
                                dr["Commission"] = Math.Round(item.Comm, 2);
                                dr["Tax"] = Math.Round(item.Tax, 2);
                                dr["ProductName"] = item.Product;
                                dr["Contract"] = item.Contract;
                                dr["BS"] = side;
                                if (objInstrumentSpec.ContractSize > 0)
                                {
                                    dr["Quantity"] = item.OrderQty / objInstrumentSpec.ContractSize;
                                }
                                else
                                    dr["Quantity"] = item.OrderQty;
                                if (orderType == "STOP" || orderType == "MARKET")
                                {
                                    dr["Price"] = 0;
                                }

                                else
                                {
                                    if (item.Price > 0)
                                    {
                                        dr["Price"] = item.Price / Convert.ToDecimal(Math.Pow(10, objInstrumentSpec.Digits));
                                    }
                                    else
                                        dr["Price"] = item.Price;
                                }
                                if (item.StopPx > 0)
                                {
                                    dr["TriggerPrice"] = item.StopPx / Convert.ToDecimal(Math.Pow(10, objInstrumentSpec.Digits));
                                }
                                else
                                    dr["TriggerPrice"] = item.StopPx;
                                if (item.AvgPx > 0)
                                {
                                    dr["AvgPrice"] = item.AvgPx / Convert.ToDecimal(Math.Pow(10, objInstrumentSpec.Digits));
                                }
                                else
                                    dr["AvgPrice"] = Convert.ToDouble(item.AvgPx);
                                if (item.LastPx > 0)
                                {
                                    dr["FillPrice"] = item.LastPx / Convert.ToDecimal(Math.Pow(10, objInstrumentSpec.Digits));
                                }
                                else
                                    dr["FillPrice"] = Convert.ToDouble(item.LastPx);
                                dr["OrderType"] = orderType;
                                dr["Status"] = orderStatus;
                                dr["TradeTime"] = transactTime;//transactTime;
                                dr["LastUpdatedTime"] = transactTime;
                                if (objInstrumentSpec.ContractSize > 0)
                                {
                                    dr["LeaveQty"] = item.LeavesQty / objInstrumentSpec.ContractSize;
                                }
                                else
                                    dr["LeaveQty"] = item.LeavesQty;
                                if (objInstrumentSpec.ContractSize > 0)
                                {
                                    dr["SettledQty"] = item.ClosedQty / objInstrumentSpec.ContractSize;
                                }
                                else
                                    dr["SettledQty"] = item.ClosedQty;
                                dr["Profit"] = item.Profit;
                                DataRow[] orderRow = orderHistoryDS.dtOrderHistory.Select("ClientOrderID = '" + item.ClOrdId + "'");
                                if (orderRow.Length > 0)
                                {
                                    if (objInstrumentSpec.ContractSize > 0)
                                    {
                                        orderRow[0]["SettledQty"] = item.ClosedQty / objInstrumentSpec.ContractSize;
                                    }
                                    else
                                        orderRow[0]["SettledQty"] = item.ClosedQty;
                                }


                                double grosspl = 0;

                                dr["GrossPL"] = grosspl;
                                if (!_DDTradeRow.Keys.Contains(item.OrderID))
                                {
                                    tradeHistoryDS.dtTradeHistory.Rows.Add(dr);
                                    _DDTradeRow.Add(item.OrderID, dr);
                                }
                                else
                                {
                                    _syncJSONQueue.Enqueue(item.Contract + "," + pType + "," + item.Product);
                                }
                            }
                            else
                            {
                                //MessageBox.Show("");
                            }


                        }
                        catch (Exception ex)
                        {
                            _syncJSONQueue.Enqueue("ERROR >> onTradeHistoryResponse >> " + ex.Message);
                        }
                    }
                }

                if (tradeHistoryDS != null && islastPck)
                {
                    try
                    {
                        if (_lstOrderHistoryAccountId.Contains(_accountId))
                        {
                            _lstOrderHistoryAccountId.Remove(_accountId);
                        }


                        string message = string.Empty;
                        Color color = Color.LightGray;
                        message = "Trade History for Account >" + Convert.ToString(lstExecutionReport[0].Account) + " Received.";
                        DataRow dr1 = INSTANCE.messageLogDS.dtMessageLog.NewRow();
                        DateTime dt = DateTime.Now;
                        string str = string.Format(Properties.Settings.Default.TimeFormat.Contains("24") ? "{0:HH:mm:ss tt dd/MM/yyyy}" : "{0:hh:mm:ss tt dd/MM/yyyy}", dt);
                        dr1["Time"] = dt.ToString();
                        dr1["MessageType"] = "TRADE HISTORY";
                        dr1["Message"] = message;
                        dr1["Account"] = 0;
                        dr1["StrDateTime"] = str;
                        dr1["Color"] = color.Name;
                        if (System.Threading.Monitor.TryEnter(INSTANCE.messageLogDS.dtMessageLog, 500))
                        {
                            try
                            {
                                INSTANCE.messageLogDS.dtMessageLog.Rows.InsertAt(dr1, 0);
                                INSTANCE.messageLogDS.dtMessageLog.AcceptChanges();
                            }
                            finally
                            {
                                System.Threading.Monitor.Exit(INSTANCE.messageLogDS.dtMessageLog);
                            }
                        }
                        OnOrderLog("TRADE");
                        clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.AcceptChanges();
                        orderHistoryDS.dtOrderHistory.AcceptChanges();
                        DoHandleTradeHistoryResponse(lstExecutionReport);
                        if (_lstOrderHistoryAccountId.Count == 0)
                        {
                            _isTradeHistoryLoaded = true;
                            OnTradeHistoryLoaded();
                        }
                    }
                    catch (Exception ex)
                    {

                        _syncJSONQueue.Enqueue("ERROR >> onTradeHistoryResponse >> Check point 2 >> " + ex.Message);
                    }

                }
            }

        }

        public void onOrderHistoryResponse(List<OrderHistory> lstOrderHistory, bool islastPck)
        {
            try
            {

                _isTradeHistoryLoaded = false;
                if (lstOrderHistory.Count > 0)
                {
                    orderHistoryDS.dtOrderHistory.Columns["ClientOrderId"].DataType = Type.GetType("System.Int32");
                    int _accountId = 0;
                    foreach (OrderHistory ordH in lstOrderHistory)
                    {
                        if (_accountId == 0)
                        {
                            _accountId = Convert.ToInt32(ordH.Account);
                        }

                        if (!_orderId.Contains(Convert.ToInt32(ordH.OrderID)))
                        {
                            _orderId.Add(Convert.ToInt32(ordH.OrderID));
                            DataRow dr = orderHistoryDS.dtOrderHistory.NewRow();
                            string orderStatus = string.Empty;
                            string productType = string.Empty;
                            string side = string.Empty;
                            string orderType = string.Empty;
                            string timeInForce = string.Empty;
                            if (ClsGlobal.DDReverseOrderStatus.Keys.Contains(Convert.ToSByte(ordH.OrderStatus)))
                                orderStatus = ClsGlobal.DDReverseOrderStatus[Convert.ToSByte(ordH.OrderStatus)].ToUpper();
                            if (ClsGlobal.DDReverseProductType.Keys.Contains(Convert.ToSByte(ordH.ProductType)))
                                productType = ClsGlobal.DDReverseProductType[Convert.ToSByte(ordH.ProductType)];
                            if (ClsGlobal.DDReverseSide.Keys.Contains(Convert.ToSByte(ordH.Side)))
                                side = ClsGlobal.DDReverseSide[Convert.ToSByte(ordH.Side)];
                            if (ClsGlobal.DDReverseOrderType.Keys.Contains(Convert.ToSByte(ordH.OrderType)))
                                orderType = ClsGlobal.DDReverseOrderType[Convert.ToSByte(ordH.OrderType)];
                            if (ClsGlobal.DDReverseValidity.Keys.Contains(Convert.ToSByte(ordH.TimeInForce)))
                                timeInForce = ClsGlobal.DDReverseValidity[Convert.ToSByte(ordH.TimeInForce)];
                            string transactionTime = string.Empty;
                            double OAdate = 0;
                            double.TryParse(ordH.TransactTime, out OAdate);
                            // if (ordH.TransactTime != string.Empty)
                            {
                                transactionTime = GetDateTimeFromOAdate(OAdate).ToString();
                            }

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
                            }
                            ;
                            // InstrumentSpec objInstrumentSpec = ClsTWSContractManager.INSTANCE.GetContractSpec(ordH.Contract, pType, ordH.Product);

                            if (ClsTWSContractManager.INSTANCE.ddContractDetails.ContainsKey(ordH.Contract))
                            {
                                InstrumentSpec objInstrumentSpec = ClsTWSContractManager.INSTANCE.ddContractDetails[ordH.Contract];

                                dr["Account"] = ordH.Account;
                                dr["Author"] = 0;
                                dr["ClientOrderID"] = ordH.ClOrdId;
                                dr["Contract"] = ordH.Contract;
                                dr["Industry"] = ordH.industry;
                                dr["OrderID"] = Convert.ToInt32(ordH.OrderID);
                                dr["OrderStatus"] = orderStatus;
                                dr["OrderType"] = orderType;
                                dr["OrigClientOrderID"] = ordH.OrigClOrdId;
                                if (ordH.AvgPx > 0)
                                {
                                    dr["AvgPrice"] = ordH.AvgPx / Convert.ToDecimal(Math.Pow(10, objInstrumentSpec.Digits));
                                }
                                else
                                    dr["AvgPrice"] = ordH.AvgPx;
                                if (ordH.LeavesQty > 0)
                                {
                                    dr["LeavesQty"] = ordH.LeavesQty / objInstrumentSpec.ContractSize;
                                }
                                else
                                    dr["LeavesQty"] = ordH.LeavesQty;
                                if (ordH.CumQty > 0)
                                {
                                    dr["CumQty"] = ordH.CumQty / objInstrumentSpec.ContractSize;
                                }
                                else
                                    dr["CumQty"] = ordH.CumQty;
                                if (ordH.OrderQty > 0)
                                {
                                    dr["OrderQty"] = ordH.OrderQty / objInstrumentSpec.ContractSize;
                                }
                                else
                                    dr["OrderQty"] = ordH.OrderQty;

                                switch (orderStatus)
                                {
                                    case "PARTIALLY_FILLED":
                                    case "FILLED":
                                        dr["Commission"] = ordH.Commission;
                                        dr["Tax"] = ordH.Tax;
                                        dr["Color"] = Color.White.Name;
                                        break;
                                    case "WORKING":
                                        dr["Color"] = Color.DarkGreen.Name;
                                        break;
                                    case "PENDING_NEW":
                                        dr["Color"] = Color.LightPink.Name;
                                        break;
                                    case "CANCELED":
                                        dr["Color"] = Color.Red.Name;
                                        break;
                                    case "REJECTED":
                                        dr["Color"] = Color.LightYellow.Name;
                                        break;
                                    default:
                                        dr["Color"] = Color.White.Name;
                                        break;
                                }

                                dr["Product"] = ordH.Product;
                                dr["ProductType"] = pType;

                                double grosspl = 0;
                                grosspl = side == "BUY" ? Math.Round(Convert.ToDouble(ordH.CounterAvgPx - ordH.AvgPx) * Convert.ToDouble(ordH.OrderQty) * objInstrumentSpec.ContractSize, 2) : Math.Round(Convert.ToDouble(ordH.AvgPx - ordH.CounterAvgPx) * Convert.ToDouble(ordH.OrderQty) * objInstrumentSpec.ContractSize, 2);
                                dr["GrossPL"] = grosspl;
                                dr["Sector"] = ordH.sector;
                                dr["Side"] = side;
                                dr["TimeInForce"] = timeInForce;
                                if (objInstrumentSpec != null)
                                    dr["TradingCurrency"] = objInstrumentSpec.TradingCurrency;
                                if (orderType == "STOP" || orderType == "MARKET")
                                {
                                    dr["Price"] = 0;
                                }
                                else
                                {
                                    if (ordH.Price > 0)
                                    {
                                        dr["Price"] = ordH.Price / Convert.ToDecimal(Math.Pow(10, objInstrumentSpec.Digits));
                                    }
                                    else
                                        dr["Price"] = ordH.Price;
                                }
                                if (ordH.StopPx > 0)
                                {
                                    dr["StopPx"] = ordH.StopPx / Convert.ToDecimal(Math.Pow(10, objInstrumentSpec.Digits));
                                }
                                else
                                    dr["StopPx"] = ordH.StopPx;
                                dr["Text"] = string.Empty;
                                dr["Gateway"] = ordH.Gateway;
                                dr["TransactTime"] = transactionTime;
                                if (orderHistoryDS.dtOrderHistory != null && !orderHistoryDS.dtOrderHistory.Rows.Contains(Convert.ToInt32(ordH.OrderID)))
                                    orderHistoryDS.dtOrderHistory.Rows.Add(dr);
                                if (_DDOrderRow != null)
                                {
                                    if (!_DDOrderRow.Keys.Contains(ordH.OrderID))
                                        _DDOrderRow.Add(ordH.OrderID, dr);
                                    else
                                        _DDOrderRow[ordH.OrderID] = dr;
                                }

                                Symbol sym = Symbol.GetSymbol(ordH.Gateway + Symbol._Seperator + ordH.ProductType + Symbol._Seperator + ordH.Product + Symbol._Seperator + ordH.Contract);

                                if (!TWS.Cls.ClsGlobal.SubscibedSymbolList.ContainsKey(sym.Contract))
                                {
                                    TWS.Cls.ClsGlobal.SubscibedSymbolList.Add(sym.Contract, sym);
                                    if (!lst.Contains(sym))
                                    {
                                        lst.Add(sym);
                                    }
                                }
                            }

                        }
                    }
                    if (islastPck)
                    {
                        clsTWSDataManagerJSON.INSTANCE.SubscribeForQuotes(SubscribeRequestType.SUBSCRIBE, lst);
                        string message = string.Empty;
                        Color color = Color.White;
                        message = "Order History for Account >" + Convert.ToString(lstOrderHistory[0].Account) + " Received.";
                        DataRow dr1 = INSTANCE.messageLogDS.dtMessageLog.NewRow();
                        DateTime dt = DateTime.Now;
                        string str = string.Format(Properties.Settings.Default.TimeFormat.Contains("24") ? "{0:HH:mm:ss tt dd/MM/yyyy}" : "{0:hh:mm:ss tt dd/MM/yyyy}", dt);
                        dr1["Time"] = dt.ToString();
                        dr1["MessageType"] = "ORDER HISTORY";
                        dr1["Message"] = message;
                        dr1["Account"] = 0;
                        dr1["StrDateTime"] = str;
                        dr1["Color"] = color.Name;
                        if (System.Threading.Monitor.TryEnter(INSTANCE.messageLogDS.dtMessageLog, 500))
                        {
                            try
                            {
                                INSTANCE.messageLogDS.dtMessageLog.Rows.InsertAt(dr1, 0);
                                INSTANCE.messageLogDS.dtMessageLog.AcceptChanges();
                            }
                            finally
                            {
                                System.Threading.Monitor.Exit(INSTANCE.messageLogDS.dtMessageLog);
                            }
                        }
                        orderHistoryDS.dtOrderHistory.AcceptChanges();
                        OnOrderLog("ORDERHISTORY");

                        OnOrderHistoryResponse();
                        if (Properties.Settings.Default.AccountType.ToUpper().Trim() == "BROKER")
                        {
                            //if (Properties.Settings.Default.AccountType.ToUpper().Trim() == "BROKER")
                            //{
                            //    //Thread HistoricalDataThread = new Thread(SubscribeHistoricalData);
                            //    //HistoricalDataThread.Start();
                            //    for (int i = 0; i < _DDAccounts.Keys.Count; i++)
                            //    {
                            //        getPositionResponse((uint)_DDAccounts.Keys.ToArray()[i]);
                            //        getOrderHistoryResponse((uint)_DDAccounts.Keys.ToArray()[i]);

                            //    }
                            //}
                            if (!_lstOrderHistoryAccountId.Contains(_accountId))
                            {
                                _lstOrderHistoryAccountId.Add(_accountId);
                            }

                            //for (int i = 0; i < _DDAccounts.Keys.Count; i++)
                            //{                               
                            //    getTradeHistoryResponse((uint)_DDAccounts.Keys.ToArray()[i]);

                            //}
                            getTradeHistoryResponse((uint)_accountId);


                        }
                        else
                        {
                            getTradeHistoryResponse(
                                (uint)_DDAccounts.Keys.ToArray()[0]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _syncJSONQueue.Enqueue("OnOrderHistoryResponce" + ex.Message);
            }

        }

        public void onBusinessLevelReject(BusinessReject ptrBusinessReject)
        {
            try
            {
                DataRow drO = null;
                if (ptrBusinessReject.RefMsgType == (int)MessageTypes.NEW_ORDER_REQUEST ||
                    ptrBusinessReject.RefMsgType == (int)MessageTypes.ORDER_CANCEL_REQUEST ||
                    ptrBusinessReject.RefMsgType == (int)MessageTypes.ORDER_REPLACE_REQUEST ||
                    ptrBusinessReject.RefMsgType == (int)MessageTypes.ORDER_CANCEL_REJECT_RESPONSE)
                {

                    double num;
                    bool isNum = double.TryParse(ptrBusinessReject.BusinessRejectRefID, out num);
                    if (isNum)
                    {
                        lock (orderHistoryDS.dtOrderHistory)
                        {
                            if (_DDOrderRow.TryGetValue(Convert.ToUInt32(ptrBusinessReject.BusinessRejectRefID), out drO))
                            {
                            }
                            if (drO != null)
                            {
                                drO["Text"] = ptrBusinessReject.Text;
                                drO["Color"] = Color.LightYellow.Name;
                            }
                            else
                            {

                            }
                            orderHistoryDS.dtOrderHistory.AcceptChanges();
                        }
                        string message = string.Empty;
                        if (drO != null)
                        {

                            string orderStatus = drO["OrderStatus"].ToString();
                            string side = drO["Side"].ToString();
                            string orderid = drO["OrderId"].ToString();
                            string contract = drO["Contract"].ToString();
                            string ordQty = drO["orderQty"].ToString();
                            string price = drO["price"].ToString();
                            string reason = drO["Text"].ToString();
                            string date = drO["TransactTime"].ToString();
                            Color color = Color.FromName(drO["Color"].ToString());
                            message = "Your " + side + " Order with OrderID > " + orderid + " for Symbol > " + contract + " Qty > " + ordQty + " Price > " + price + " is " + orderStatus + " due to reason > " + reason + " on Date > " + date + " .";
                            DataRow dr = messageLogDS.dtMessageLog.NewRow();
                            DateTime dt = DateTime.Now;
                            string str = string.Format(Properties.Settings.Default.TimeFormat.Contains("24") ? "{0:HH:mm:ss tt dd/MM/yyyy}" : "{0:hh:mm:ss tt dd/MM/yyyy}", dt);
                            dr["Time"] = dt.ToString();
                            dr["MessageType"] = "ORDER RESPONSE";
                            dr["Message"] = message;
                            dr["Account"] = (int)drO["Account"];
                            dr["StrDateTime"] = str;
                            dr["Color"] = drO["Color"].ToString();
                            if (System.Threading.Monitor.TryEnter(messageLogDS.dtMessageLog, 500))
                            {
                                try
                                {
                                    messageLogDS.dtMessageLog.Rows.InsertAt(dr, 0);
                                    messageLogDS.dtMessageLog.AcceptChanges();
                                }
                                finally
                                {
                                    System.Threading.Monitor.Exit(messageLogDS.dtMessageLog);
                                }
                            }
                        }
                        else
                        {
                            DateTime date = DateTime.Now;
                            string str = string.Format(Properties.Settings.Default.TimeFormat.Contains("24") ? "{0:HH:mm:ss tt dd/MM/yyyy}" : "{0:hh:mm:ss tt dd/MM/yyyy}", date);

                            string reason = Enum.GetName(typeof(BusinessRejectReason), ptrBusinessReject.BusinessRejectReason);
                            string text = ptrBusinessReject.Text;
                            DataRow dr = messageLogDS.dtMessageLog.NewRow();
                            message = "Your New Order with OrderID > " + ptrBusinessReject.BusinessRejectRefID + " is REJECTED due to reason > " + reason + " on Date > " + str + " .";
                            dr["Time"] = date.ToString();
                            dr["MessageType"] = "ORDER RESPONSE";
                            dr["Message"] = message;
                            dr["Account"] = 0;
                            dr["StrDateTime"] = str;
                            dr["Color"] = Color.Yellow;

                            if (System.Threading.Monitor.TryEnter(messageLogDS.dtMessageLog, 500))
                            {
                                try
                                {
                                    messageLogDS.dtMessageLog.Rows.InsertAt(dr, 0);
                                    messageLogDS.dtMessageLog.AcceptChanges();
                                }
                                finally
                                {
                                    System.Threading.Monitor.Exit(messageLogDS.dtMessageLog);
                                }
                            }
                        }
                    }
                }
                else
                {
                    var message = Enum.GetName(typeof(BusinessRejectReason), ptrBusinessReject.BusinessRejectReason);
                    _syncJSONQueue.Enqueue(message);
                }
                OnBusinessLevelReject(drO, ptrBusinessReject);
            }
            catch (NullReferenceException ex)
            {
                _syncJSONQueue.Enqueue("Error >> onBusinessLevelReject >> " + ex.Message);
            }

        }

        public void UpdateShortOrderStatus(string msg)
        {
            try
            {
                OnShortOrderUpdate(msg);
            }
            catch (Exception)
            {

            }
        }

        public void onPositionResponse(List<Cls.Position> lstPosition, bool islastPck)
        {
            try
            {
                PositionResponse(lstPosition);
                if (System.Threading.Monitor.TryEnter(netpositionDS.dtNetPosition, 500))
                {
                    try
                    {

                        lock (netpositionDS.dtNetPosition)
                        {
                            foreach (Cls.Position positionInfo in lstPosition)
                            {
                                string productType = ClsGlobal.DDReverseProductType[Convert.ToSByte(positionInfo.ProductType)];

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
                                }
                                ;
                                //InstrumentSpec objInstrumentSpec = ClsTWSContractManager.INSTANCE.GetContractSpec(positionInfo.Contract, pType, positionInfo.Product);
                                if (ClsTWSContractManager.INSTANCE.ddContractDetails.ContainsKey(positionInfo.Contract))
                                {
                                    InstrumentSpec objInstrumentSpec = ClsTWSContractManager.INSTANCE.ddContractDetails[positionInfo.Contract];
                                    DataRow drT = null;

                                    double BuyQty = positionInfo.BuyQty / objInstrumentSpec.ContractSize;
                                    double SellQty = positionInfo.SellQty / objInstrumentSpec.ContractSize;
                                    double BuyAvg = Math.Round(positionInfo.BuyAvg / Convert.ToDouble(Math.Pow(10, objInstrumentSpec.Digits)), 2);
                                    double SellAvg = Math.Round(positionInfo.SellAvg / Convert.ToDouble(Math.Pow(10, objInstrumentSpec.Digits)), 2);
                                    if (_DDNetPosRow.TryGetValue(positionInfo.Account.ToString() + ":" + positionInfo.Contract, out drT))
                                    {
                                    }
                                    if (drT == null)
                                    {

                                        DataRow row = netpositionDS.dtNetPosition.NewRow();
                                        row["AccountNo"] = Convert.ToString(positionInfo.Account);
                                        row["ProductType"] = pType;
                                        row["Contract"] = Convert.ToString(positionInfo.Contract);
                                        if (objInstrumentSpec != null)
                                            row["TradingCurrency"] = objInstrumentSpec.TradingCurrency;
                                        row["ProductName"] = Convert.ToString(positionInfo.Product);
                                        row["BuyQty"] = BuyQty;
                                        row["ContractSize"] = objInstrumentSpec.ContractSize;
                                        if (objInstrumentSpec.ContractSize != 0)
                                        {
                                            row["BuyVal"] = Math.Round((positionInfo.BuyVal / objInstrumentSpec.ContractSize), 2);
                                            row["SellVal"] = Math.Round((positionInfo.SellVal / objInstrumentSpec.ContractSize), 2);
                                        }
                                        else
                                        {
                                            row["BuyVal"] = Math.Round((positionInfo.BuyVal), 2);
                                            row["SellVal"] = Math.Round((positionInfo.SellVal), 2);
                                        }
                                        row["BuyAvg"] = BuyAvg.ToString("0.00");
                                        row["SellQty"] = SellQty;
                                        row["SellAvg"] = SellAvg.ToString("0.00");

                                        if (SellQty > BuyQty)
                                        {
                                            row["NetQty"] = Convert.ToString(SellQty - BuyQty);
                                        }
                                        else
                                            row["NetQty"] = Convert.ToString(BuyQty - SellQty);
                                        row["NetVal"] = Convert.ToString(Math.Round(positionInfo.NetVal, 2));
                                        row["NetPrice"] = Math.Round(positionInfo.NetPrice, 2).ToString("0.00");
                                        if (pType != "FOREX")
                                        {
                                            if (ClsGlobal.DDLTP.Keys.Contains(row["Contract"].ToString()))
                                                row["MarketPrice"] =
                                                    Math.Round(Convert.ToDecimal(ClsGlobal.DDLTP[row["Contract"].ToString()]), 2).ToString("0.00");
                                        }
                                        else
                                        {
                                            if (positionInfo.NetQty >= 0)
                                            {
                                                if (ClsGlobal.DDLeftZLevel.Keys.Contains(row["Contract"].ToString()))
                                                    row["MarketPrice"] = Math.Round(Convert.ToDecimal(ClsGlobal.DDLeftZLevel[row["Contract"].ToString()]), 2).ToString("0.00");
                                            }
                                            else
                                            {
                                                if (ClsGlobal.DDRightZLevel.Keys.Contains(row["Contract"].ToString()))
                                                    row["MarketPrice"] = Math.Round(Convert.ToDecimal(ClsGlobal.DDRightZLevel[row["Contract"].ToString()]), 2).ToString("0.00");
                                            }
                                        }
                                        double marketPrice = 0;

                                        if (ClsGlobal.DDLTP.Keys.Contains(row["Contract"].ToString()))
                                            marketPrice = Math.Round(Convert.ToDouble(ClsGlobal.DDLTP[row["Contract"].ToString()]), 2);

                                        if (BuyQty > SellQty)
                                            row["UR_PL"] = Math.Round((BuyQty - SellQty) * (marketPrice - BuyAvg) * objInstrumentSpec.ContractSize, 2).ToString("0.00");

                                        else if (BuyQty < SellQty)
                                            row["UR_PL"] = Math.Round((SellQty - BuyQty) * (SellAvg - marketPrice) * objInstrumentSpec.ContractSize, 2).ToString("0.00");
                                        else
                                            row["UR_PL"] = Math.Round(0d, 2).ToString("0.00");

                                        if (System.Threading.Monitor.TryEnter(netpositionDS.dtNetPosition.Rows, 500))
                                        {
                                            try
                                            {

                                                if (netpositionDS.dtNetPosition.Rows.Count == 0)
                                                    netpositionDS.dtNetPosition.Rows.Add(row);
                                                else
                                                    netpositionDS.dtNetPosition.Rows.InsertAt(row, 0);

                                            }
                                            finally
                                            {
                                                System.Threading.Monitor.Exit(netpositionDS.dtNetPosition.Rows);
                                            }
                                        }

                                        if (_DDNetPosRow != null)
                                        {
                                            if (!_DDNetPosRow.Keys.Contains(positionInfo.Account.ToString() + ":" + positionInfo.Contract))
                                                _DDNetPosRow.Add(positionInfo.Account.ToString() + ":" + positionInfo.Contract, row);
                                        }

                                        Symbol sym = Symbol.GetSymbol(positionInfo.Gateway + Symbol._Seperator + positionInfo.ProductType + Symbol._Seperator + positionInfo.Product + Symbol._Seperator + positionInfo.Contract);
                                        lst.Add(sym);
                                        if (!ClsGlobal.SubscibedSymbolList.ContainsKey(sym.Contract))
                                        {
                                            ClsGlobal.SubscibedSymbolList.Add(sym.Contract, sym);
                                            List<Symbol> sl = new List<Symbol>();
                                            sl.Add(sym);
                                            clsTWSDataManagerJSON.INSTANCE.SubscribeForQuotes(SubscribeRequestType.SUBSCRIBE, sl);
                                        }

                                        var x = new KeyValuePair<string, DataRow>(positionInfo.Contract, row);
                                        if (!PosContracts.Contains(positionInfo.Contract))
                                            PosContracts.Add(positionInfo.Contract);
                                        _DDNetPos.Add(x);
                                    }
                                    else
                                    {
                                        drT["AccountNo"] = Convert.ToString(positionInfo.Account);
                                        drT["ProductType"] = pType;
                                        drT["Contract"] = Convert.ToString(positionInfo.Contract);
                                        drT["TradingCurrency"] = objInstrumentSpec.TradingCurrency;
                                        drT["ProductName"] = Convert.ToString(positionInfo.Product);
                                        drT["BuyQty"] = BuyQty;
                                        drT["BuyVal"] = Convert.ToString(Math.Round(positionInfo.BuyVal, 2));
                                        drT["BuyAvg"] = Math.Round(BuyAvg, 2).ToString("0.00");
                                        drT["SellQty"] = SellQty;
                                        drT["SellVal"] = Convert.ToString(Math.Round(positionInfo.SellVal, 2));
                                        drT["SellAvg"] = Math.Round(SellAvg, 2).ToString("0.00");
                                        if (SellQty > BuyQty)
                                        {
                                            drT["NetQty"] = Convert.ToString(SellQty - BuyQty);
                                        }
                                        else
                                            drT["NetQty"] = Convert.ToString(BuyQty - SellQty);
                                        drT["NetVal"] = Convert.ToString(Math.Round(positionInfo.NetVal, 2));
                                        drT["NetPrice"] = Math.Round(positionInfo.NetPrice, 2).ToString("0.00");
                                        double marketPrice = 0;

                                        if (ClsGlobal.DDLTP.Keys.Contains(drT["Contract"].ToString()))
                                            marketPrice = Math.Round(Convert.ToDouble(ClsGlobal.DDLTP[drT["Contract"].ToString()]), 2);

                                        if (BuyQty > SellQty)
                                            drT["UR_PL"] = Math.Round((BuyQty - SellQty) * (marketPrice - BuyAvg) * objInstrumentSpec.ContractSize, 2).ToString("0.00");

                                        else if (BuyQty < SellQty)
                                            drT["UR_PL"] = Math.Round((SellQty - BuyQty) * (SellAvg - marketPrice) * objInstrumentSpec.ContractSize, 2).ToString("0.00");
                                        else
                                            drT["UR_PL"] = Math.Round(0d, 2).ToString("0.00");

                                        drT.AcceptChanges();
                                    }
                                }


                                else
                                {
                                    //        MessageBox.Show("");
                                }


                                if (islastPck && lstPosition.Count == 1)
                                {
                                    string message = string.Empty;
                                    Color color = Color.White;
                                    message = "Net Position for Account >" + lstPosition[0].Account + " Received.";

                                    DataRow dr = messageLogDS.dtMessageLog.NewRow();
                                    DateTime dt = DateTime.Now;
                                    string str = string.Format(Properties.Settings.Default.TimeFormat.Contains("24") ? "{0:HH:mm:ss tt dd/MM/yyyy}" : "{0:hh:mm:ss tt dd/MM/yyyy}", dt);
                                    dr["Time"] = dt.ToString();
                                    dr["MessageType"] = "POSITION RESPONSE";
                                    dr["Message"] = "POSITION RESPONSE :- " + message;
                                    dr["Account"] = (int)lstPosition[0].Account;
                                    dr["StrDateTime"] = str;
                                    dr["Color"] = color.Name;
                                    if (System.Threading.Monitor.TryEnter(messageLogDS.dtMessageLog, 500))
                                    {
                                        try
                                        {
                                            messageLogDS.dtMessageLog.Rows.InsertAt(dr, 0);
                                            messageLogDS.dtMessageLog.AcceptChanges();
                                        }
                                        finally
                                        {
                                            System.Threading.Monitor.Exit(messageLogDS.dtMessageLog);
                                        }
                                    }
                                    if (lstPosition.Count > 0)
                                    {
                                        OnPositionUpdate((int)lstPosition[0].Account);
                                    }
                                }
                            }

                        }
                    }
                    finally
                    {
                        System.Threading.Monitor.Exit(netpositionDS.dtNetPosition);
                    }
                }
                netpositionDS.dtNetPosition.AcceptChanges();
                OnPositionResponse(lstPosition);
            }
            catch (Exception e)
            {
                _syncJSONQueue.Enqueue("Error at onPositionResponse >> " + e.Message);
            }
        }

        private void INSTANCE_OnLTPChange(string ContractName, double marketpriceAskBid)
        {
            try
            {
                if (System.Threading.Monitor.TryEnter(netpositionDS.dtNetPosition, 500))
                {
                    try
                    {
                        DataRow[] rws = netpositionDS.dtNetPosition.Select("Contract ='" + ContractName + "'");
                        foreach (DataRow rw in rws)
                        {
                            double LTPPrice = 0;
                            if (ClsGlobal.DDLTP.Keys.Contains(ContractName))
                            {
                                LTPPrice = Math.Round(Convert.ToDouble(ClsGlobal.DDLTP[ContractName]), 2);
                            }

                            double sellAvg = Convert.ToDouble(rw["SellAvg"].ToString());
                            double buyAvg = Convert.ToDouble(rw["BuyAvg"].ToString());
                            int netqty = Convert.ToInt32(rw["NetQty"].ToString());
                            int buyQty = Convert.ToInt32(rw["BuyQty"].ToString());
                            int sellQty = Convert.ToInt32(rw["sellQty"].ToString());
                            int ContractSize = Convert.ToInt32(rw["ContractSize"].ToString());

                            if (buyQty > sellQty)
                                rw["UR_PL"] = Math.Round((buyQty - sellQty) * (LTPPrice - buyAvg) * ContractSize, 2).ToString("0.00");

                            else if (buyQty < sellQty)
                                rw["UR_PL"] = Math.Round((sellQty - buyQty) * (sellAvg - LTPPrice) * ContractSize, 2).ToString("0.00");
                            else
                                rw["UR_PL"] = Math.Round(0d, 2).ToString("0.00");
                            rw.AcceptChanges();
                        }
                    }
                    finally
                    {
                        System.Threading.Monitor.Exit(netpositionDS.dtNetPosition);
                    }
                }
                netpositionDS.dtNetPosition.AcceptChanges();
            }
            catch (Exception)
            {


            }


        }
        public void ReloadConfigurationRequest(sbyte config)
        {
            //ReloadConfigurationRequest(config); 
        }

        public void onExecutionReport(Cls.ExecutionReport executionReport)
        {
            int _linkedOrderId = 0;
            string _status = string.Empty;

            if (System.Threading.Monitor.TryEnter(orderHistoryDS.dtOrderHistory, 1000))
            {
                try
                {
                    lock (objLock)
                    {
                        string orderStatus = string.Empty;
                        string productType = string.Empty;
                        string side = string.Empty;
                        string orderType = string.Empty;
                        string timeInForce = string.Empty;
                        if (ClsGlobal.DDReverseOrderStatus.Keys.Contains(Convert.ToSByte(executionReport.OrderStatus)))
                            orderStatus = ClsGlobal.DDReverseOrderStatus[Convert.ToSByte(executionReport.OrderStatus)].ToUpper();
                        if (ClsGlobal.DDReverseProductType.Keys.Contains(Convert.ToSByte(executionReport.ProductType)))
                            productType = ClsGlobal.DDReverseProductType[Convert.ToSByte(executionReport.ProductType)];
                        if (ClsGlobal.DDReverseSide.Keys.Contains(Convert.ToSByte(executionReport.Side)))
                            side = ClsGlobal.DDReverseSide[Convert.ToSByte(executionReport.Side)];
                        if (ClsGlobal.DDReverseOrderType.Keys.Contains(Convert.ToSByte(executionReport.OrderType)))
                            orderType = ClsGlobal.DDReverseOrderType[Convert.ToSByte(executionReport.OrderType)];
                        if (ClsGlobal.DDReverseValidity.Keys.Contains(Convert.ToSByte(executionReport.TimeInForce)))
                            timeInForce = ClsGlobal.DDReverseValidity[Convert.ToSByte(executionReport.TimeInForce)];
                        _status = orderStatus;
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
                        }
                        ;
                        // InstrumentSpec objInstrumentSpec = Cls.ClsTWSContractManager.INSTANCE.GetContractSpec(executionReport.Contract, pType, executionReport.Product);
                        InstrumentSpec objInstrumentSpec = ClsTWSContractManager.INSTANCE.ddContractDetails[executionReport.Contract];
                        if (executionReport.ExecType == 'I')
                        {
                            DataRow[] tradeRow = null;
                            try
                            {
                                if (tradeHistoryDS != null)
                                    tradeRow = clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Select("OrderNo = '" + executionReport.ClOrdId + "'");
                                else
                                {
                                    tradeHistoryDS = new DS4TradeHistory();
                                    tradeRow = clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Select("OrderNo = '" + executionReport.ClOrdId + "'");
                                }
                            }
                            catch (Exception)
                            {

                            }

                            if (tradeRow.Length > 0)
                            {
                                if (executionReport.ClosedQty > 0)
                                {
                                    if (objInstrumentSpec != null)
                                        tradeRow[0]["SettledQty"] = Convert.ToDouble(executionReport.ClosedQty / objInstrumentSpec.ContractSize);
                                }
                                else
                                    tradeRow[0]["SettledQty"] = Convert.ToDouble(executionReport.ClosedQty);
                                tradeRow[0]["PnL"] = "0.00";
                                if (executionReport.PositionEffect == 'C')
                                {
                                    tradeRow[0]["Profit"] = executionReport.Profit;
                                }
                                try
                                {
                                    tradeRow[0].AcceptChanges();
                                    if (tradeHistoryDS != null)
                                        clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.AcceptChanges();
                                    else
                                    {
                                        tradeHistoryDS = new DS4TradeHistory();
                                        clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.AcceptChanges();
                                    }
                                }
                                catch (Exception)
                                {


                                }
                                OnOrderSettle();

                            }

                            DataRow[] orderRow = null;
                            try
                            {
                                if (orderHistoryDS != null)
                                    orderRow = orderHistoryDS.dtOrderHistory.Select("ClientOrderID = '" + executionReport.ClOrdId + "'");
                                else
                                {
                                    orderHistoryDS = new DS4OrderHistory();
                                    orderRow = orderHistoryDS.dtOrderHistory.Select("ClientOrderID = '" + executionReport.ClOrdId + "'");
                                }
                            }
                            catch (Exception)
                            {

                            }
                            if (orderRow.Length > 0)
                            {
                                if (executionReport.ClosedQty > 0)
                                {
                                    if (objInstrumentSpec != null)
                                        orderRow[0]["SettledQty"] = Convert.ToDouble(executionReport.ClosedQty / objInstrumentSpec.ContractSize);
                                }
                                else
                                    orderRow[0]["SettledQty"] = Convert.ToDouble(executionReport.ClosedQty);
                            }
                            DoHandleExecutionReport(executionReport);
                            return;

                        }
                        int.TryParse(executionReport.LinkedOrdID.Trim(), out _linkedOrderId);
                        lock (orderHistoryDS.dtOrderHistory)
                        {
                            string reason = executionReport.Text;
                            DataRow drO = null;
                            DataRow drT = null;
                            string transactTime = string.Empty;
                            double OAdate = 0;
                            double.TryParse(executionReport.TransactTime, out OAdate);

                            transactTime = GetDateTimeFromOAdate(OAdate).ToString();

                            if (!TWS.Cls.ClsGlobal.SubscibedSymbolList.ContainsKey(executionReport.Contract))
                            {
                                var lst = new List<Symbol>();
                                if (objInstrumentSpec != null)
                                {
                                    var sym = Symbol.GetSymbol(Symbol.getKey(objInstrumentSpec)[0]);
                                    lst.Add(sym);

                                    TWS.Cls.ClsGlobal.SubscibedSymbolList.Add(sym.Contract, sym);
                                    clsTWSDataManagerJSON.INSTANCE.SubscribeForQuotes(SubscribeRequestType.SUBSCRIBE, lst);
                                }
                            }
                            if (orderStatus == "FILLED" || orderStatus == "PARTIALLY_FILLED")
                            {
                                if (_DDTradeRow.TryGetValue(executionReport.OrderID, out drT))
                                {
                                }
                                if (drT == null)
                                {
                                    DataRow dr = tradeHistoryDS.dtTradeHistory.NewRow();
                                    dr["Account"] = executionReport.Account;
                                    dr["TradeNo"] = executionReport.ExecID;
                                    dr["OrderNo"] = Convert.ToInt32(executionReport.ClOrdId);
                                    dr["ProductType"] = pType;
                                    dr["Commission"] = Math.Round(executionReport.Comm, 2);
                                    dr["Tax"] = Math.Round(executionReport.Tax, 2);
                                    dr["ProductName"] = executionReport.Product;
                                    dr["Contract"] = executionReport.Contract;
                                    dr["BS"] = side;
                                    if (executionReport.OrderQty > 0)
                                    {
                                        if (objInstrumentSpec != null)
                                            dr["Quantity"] = Convert.ToDouble(executionReport.OrderQty / objInstrumentSpec.ContractSize);
                                    }
                                    else
                                        dr["Quantity"] = executionReport.OrderQty;
                                    if (orderType == "STOP" || orderType == "MARKET")
                                    {
                                        dr["Price"] = 0;
                                    }
                                    else
                                    {
                                        if (executionReport.Price > 0)
                                        {
                                            if (objInstrumentSpec != null)
                                                dr["Price"] = executionReport.Price / Convert.ToDecimal(Math.Pow(10, objInstrumentSpec.Digits));
                                        }
                                        else
                                            dr["Price"] = executionReport.Price;
                                    }
                                    if (executionReport.StopPx > 0)
                                    {
                                        if (objInstrumentSpec != null)
                                            dr["TriggerPrice"] = executionReport.StopPx / Convert.ToDecimal(Math.Pow(10, objInstrumentSpec.Digits));
                                    }
                                    else
                                        dr["TriggerPrice"] = executionReport.StopPx;
                                    if (executionReport.AvgPx > 0)
                                    {
                                        if (objInstrumentSpec != null)
                                            dr["AvgPrice"] = executionReport.AvgPx / Convert.ToDecimal(Math.Pow(10, objInstrumentSpec.Digits));
                                    }
                                    else
                                        dr["AvgPrice"] = Convert.ToDouble(executionReport.AvgPx);
                                    if (executionReport.LastPx > 0)
                                    {
                                        if (objInstrumentSpec != null)
                                            dr["FillPrice"] = executionReport.LastPx / Convert.ToDecimal(Math.Pow(10, objInstrumentSpec.Digits));
                                    }
                                    else
                                        dr["FillPrice"] = Convert.ToDouble(executionReport.LastPx);
                                    dr["OrderType"] = orderType;
                                    dr["Status"] = orderStatus;
                                    dr["TradeTime"] = transactTime;
                                    dr["LastUpdatedTime"] = transactTime;
                                    if (executionReport.LeavesQty > 0)
                                    {
                                        if (objInstrumentSpec != null)
                                            dr["LeaveQty"] = Convert.ToDouble(executionReport.LeavesQty / objInstrumentSpec.ContractSize);
                                    }
                                    else
                                        dr["LeaveQty"] = executionReport.LeavesQty;
                                    if (executionReport.ClosedQty > 0)
                                    {
                                        if (objInstrumentSpec != null)
                                            dr["SettledQty"] = Convert.ToDouble(executionReport.ClosedQty / objInstrumentSpec.ContractSize);
                                    }
                                    else
                                        dr["SettledQty"] = Convert.ToDouble(executionReport.ClosedQty);
                                    if (executionReport.PositionEffect == 'C')
                                    {
                                        dr["Profit"] = executionReport.Profit;
                                    }

                                    tradeHistoryDS.dtTradeHistory.Rows.InsertAt(dr, 0);
                                    _DDTradeRow.Add(executionReport.OrderID, dr);
                                    tradeHistoryDS.dtTradeHistory.AcceptChanges();
                                }
                                else
                                {
                                    drT["Account"] = executionReport.Account;
                                    drT["TradeNo"] = executionReport.ExecID;
                                    drT["OrderNo"] = Convert.ToInt32(executionReport.ClOrdId);
                                    drT["ProductType"] = pType;
                                    drT["Commission"] = Math.Round(executionReport.Comm, 2);
                                    drT["Tax"] = Math.Round(executionReport.Tax, 2);
                                    drT["ProductName"] = executionReport.Product;
                                    drT["Contract"] = executionReport.Contract;
                                    drT["BS"] = side;
                                    if (executionReport.OrderQty > 0)
                                    {
                                        if (objInstrumentSpec != null)
                                            drT["Quantity"] = Convert.ToDouble(executionReport.OrderQty / objInstrumentSpec.ContractSize);
                                    }
                                    else
                                        drT["Quantity"] = executionReport.OrderQty;
                                    if (orderType == "STOP" || orderType == "MARKET")
                                    {
                                        drT["Price"] = 0;
                                    }
                                    else
                                    {
                                        if (executionReport.Price > 0)
                                        {
                                            if (objInstrumentSpec != null)
                                                drT["Price"] = executionReport.Price / Convert.ToDecimal(Math.Pow(10, objInstrumentSpec.Digits));
                                        }
                                        else
                                            drT["Price"] = executionReport.Price;
                                    }
                                    if (executionReport.StopPx > 0)
                                    {
                                        if (objInstrumentSpec != null)
                                            drT["TriggerPrice"] = executionReport.StopPx / Convert.ToDecimal(Math.Pow(10, objInstrumentSpec.Digits));
                                    }
                                    else
                                        drT["TriggerPrice"] = executionReport.StopPx;
                                    if (executionReport.AvgPx > 0)
                                    {
                                        if (objInstrumentSpec != null)
                                            drT["AvgPrice"] = executionReport.AvgPx / Convert.ToDecimal(Math.Pow(10, objInstrumentSpec.Digits));
                                    }
                                    else
                                        drT["AvgPrice"] = Convert.ToDouble(executionReport.AvgPx);
                                    if (executionReport.LastPx > 0)
                                    {
                                        if (objInstrumentSpec != null)
                                            drT["FillPrice"] = executionReport.LastPx / Convert.ToDecimal(Math.Pow(10, objInstrumentSpec.Digits));
                                    }
                                    else
                                        drT["FillPrice"] = Convert.ToDouble(executionReport.LastPx);
                                    drT["OrderType"] = orderType;
                                    drT["Status"] = orderStatus;
                                    drT["TradeTime"] = transactTime;//transactTime;
                                    drT["LastUpdatedTime"] = transactTime;
                                    if (executionReport.LeavesQty > 0)
                                    {
                                        if (objInstrumentSpec != null)
                                            drT["LeaveQty"] = Convert.ToDouble(executionReport.LeavesQty / objInstrumentSpec.ContractSize);
                                    }
                                    else
                                        drT["LeaveQty"] = executionReport.LeavesQty;
                                    if (executionReport.ClosedQty > 0)
                                    {
                                        drT["SettledQty"] = Convert.ToDouble(executionReport.ClosedQty / objInstrumentSpec.ContractSize);
                                    }
                                    else
                                        drT["SettledQty"] = Convert.ToDouble(executionReport.ClosedQty);


                                    if (executionReport.PositionEffect == 'C')
                                    {
                                        drT["Profit"] = executionReport.Profit;
                                    }
                                    drT.AcceptChanges();
                                    tradeHistoryDS.dtTradeHistory.AcceptChanges();
                                }

                            }

                            if (_DDOrderRow != null && _DDOrderRow.TryGetValue(executionReport.OrderID, out drO))
                            {
                            }
                            if (drO == null)
                            {
                                if (orderHistoryDS.dtOrderHistory.Rows.Contains(executionReport.ClOrdId))
                                {
                                    DataRow[] r = orderHistoryDS.dtOrderHistory.Select("ClientOrderID = " + Convert.ToInt32(executionReport.ClOrdId));
                                    r[0]["Account"] = executionReport.Account;
                                    r[0]["Author"] = executionReport.author;
                                    if (executionReport.AvgPx > 0)
                                    {
                                        if (objInstrumentSpec != null)
                                            r[0]["AvgPrice"] = executionReport.AvgPx / Convert.ToDecimal(Math.Pow(10, objInstrumentSpec.Digits));
                                    }
                                    else
                                        r[0]["AvgPrice"] = executionReport.AvgPx;

                                    if (executionReport.CumQty > 0)
                                    {
                                        if (objInstrumentSpec != null)
                                            r[0]["CumQty"] = executionReport.CumQty / objInstrumentSpec.ContractSize;
                                    }
                                    else
                                        r[0]["CumQty"] = executionReport.CumQty;

                                    r[0]["ClientOrderID"] = executionReport.ClOrdId;
                                    r[0]["Contract"] = executionReport.Contract;
                                    r[0]["ExecID"] = executionReport.ExecID;
                                    r[0]["ExecTransType"] = executionReport.ExecTransType;
                                    r[0]["ExecType"] = executionReport.ExecType;
                                    r[0]["Industry"] = executionReport.industry;
                                    r[0]["OrderID"] = Convert.ToInt32(executionReport.OrderID);
                                    r[0]["OrderType"] = orderType;
                                    if (executionReport.OrderQty > 0)
                                    {
                                        if (objInstrumentSpec != null)
                                            r[0]["OrderQty"] = Convert.ToDouble(executionReport.OrderQty / objInstrumentSpec.ContractSize);
                                    }
                                    else
                                        r[0]["OrderQty"] = executionReport.OrderQty;
                                    r[0]["TransactTime"] = transactTime;
                                    switch (orderStatus.ToUpper())
                                    {
                                        case "PARTIALLY_FILLED":
                                            r[0]["Commission"] = executionReport.Comm;
                                            r[0]["Tax"] = executionReport.Tax;
                                            r[0]["Color"] = Color.White.Name;
                                            if (executionReport.OrderQty == executionReport.CumQty)
                                            {
                                                r[0]["OrderStatus"] = "FILLED";
                                            }
                                            else
                                                r[0]["OrderStatus"] = orderStatus;
                                            break;
                                        case "FILLED":
                                            r[0]["Commission"] = executionReport.Comm;
                                            r[0]["Tax"] = executionReport.Tax;
                                            r[0]["Color"] = Color.White.Name;
                                            if (executionReport.OrderQty == executionReport.CumQty)
                                            {
                                                r[0]["OrderStatus"] = orderStatus;
                                            }
                                            else
                                                r[0]["OrderStatus"] = "PARTIALLY FILLED";
                                            break;
                                        case "WORKING":
                                            r[0]["Color"] = Color.DarkGreen.Name;
                                            r[0]["OrderStatus"] = orderStatus;
                                            break;
                                        case "PENDING_NEW":
                                            r[0]["Color"] = Color.LightPink.Name;
                                            r[0]["OrderStatus"] = orderStatus;
                                            break;
                                        case "CANCELED":
                                            r[0]["Color"] = Color.Red.Name;
                                            r[0]["OrderStatus"] = orderStatus;
                                            break;
                                        case "REJECTED":
                                            r[0]["Color"] = Color.LightYellow.Name;
                                            r[0]["Text"] = reason;
                                            r[0]["OrderStatus"] = orderStatus;
                                            break;
                                        default:
                                            r[0]["Color"] = Color.White.Name;
                                            break;
                                    }
                                    r[0]["Product"] = executionReport.Product;
                                    r[0]["ProductType"] = pType;
                                    r[0]["Sector"] = executionReport.sector;
                                    r[0]["Side"] = side;
                                    r[0]["Gateway"] = executionReport.Gateway;
                                    if (executionReport.StopPx > 0)
                                    {
                                        if (objInstrumentSpec != null)
                                            r[0]["StopPx"] = executionReport.StopPx / Convert.ToDecimal(Math.Pow(10, objInstrumentSpec.Digits));
                                    }
                                    else
                                        r[0]["StopPx"] = executionReport.StopPx;
                                    r[0]["TimeInForce"] = timeInForce;
                                    if (executionReport.ClosedQty > 0)
                                    {
                                        if (objInstrumentSpec != null)
                                            r[0]["SettledQty"] = Convert.ToDouble(executionReport.ClosedQty / objInstrumentSpec.ContractSize);
                                    }
                                    else
                                        r[0]["SettledQty"] = Convert.ToDouble(executionReport.ClosedQty);
                                    if (objInstrumentSpec != null)
                                        r[0]["TradingCurrency"] = objInstrumentSpec.TradingCurrency;
                                    if (orderType == "STOP" || orderType == "MARKET")
                                    {
                                        r[0]["Price"] = 0;
                                    }
                                    else
                                    {
                                        if (executionReport.Price > 0)
                                        {
                                            if (objInstrumentSpec != null)
                                                r[0]["Price"] = executionReport.Price / Convert.ToDecimal(Math.Pow(10, objInstrumentSpec.Digits));
                                        }
                                        else
                                            r[0]["Price"] = executionReport.Price;
                                    }
                                }
                                else
                                {
                                    drO = INSTANCE.orderHistoryDS.dtOrderHistory.NewRow();

                                    drO["Account"] = executionReport.Account;
                                    drO["Author"] = executionReport.author;
                                    if (executionReport.AvgPx > 0)
                                    {
                                        if (objInstrumentSpec != null)
                                            drO["AvgPrice"] = executionReport.AvgPx / Convert.ToDecimal(Math.Pow(10, objInstrumentSpec.Digits));
                                    }
                                    else
                                        drO["AvgPrice"] = executionReport.AvgPx;
                                    drO["ClientOrderID"] = executionReport.ClOrdId;
                                    drO["Contract"] = executionReport.Contract;
                                    if (executionReport.CumQty > 0)
                                    {
                                        if (objInstrumentSpec != null)
                                            drO["CumQty"] = executionReport.CumQty / objInstrumentSpec.ContractSize;
                                    }
                                    else
                                        drO["CumQty"] = executionReport.CumQty;
                                    drO["ExecID"] = executionReport.ExecID;
                                    drO["ExecTransType"] = executionReport.ExecTransType;
                                    drO["ExecType"] = executionReport.ExecType;
                                    drO["Industry"] = executionReport.industry;
                                    drO["OrderID"] = Convert.ToInt32(executionReport.OrderID);
                                    drO["OrderType"] = orderType;
                                    if (executionReport.OrderQty > 0)
                                    {
                                        if (objInstrumentSpec != null)
                                            drO["OrderQty"] = Convert.ToDouble(executionReport.OrderQty / objInstrumentSpec.ContractSize);
                                    }
                                    else
                                        drO["OrderQty"] = executionReport.OrderQty;

                                    drO["TransactTime"] = transactTime;
                                    switch (orderStatus.ToUpper())
                                    {
                                        case "PARTIALLY_FILLED":
                                            drO["Commission"] = executionReport.Comm;
                                            drO["Tax"] = executionReport.Tax;
                                            drO["Color"] = Color.White.Name;
                                            if (executionReport.OrderQty == executionReport.CumQty)
                                            {
                                                drO["OrderStatus"] = "FILLED";
                                            }
                                            else
                                                drO["OrderStatus"] = orderStatus;
                                            break;
                                        case "FILLED":
                                            drO["Commission"] = executionReport.Comm;
                                            drO["Tax"] = executionReport.Tax;
                                            drO["Color"] = Color.White.Name;
                                            if (executionReport.OrderQty == executionReport.CumQty)
                                            {
                                                drO["OrderStatus"] = orderStatus;
                                            }
                                            else
                                                drO["OrderStatus"] = "PARTIALLY FILLED";
                                            break;
                                        case "WORKING":
                                            drO["Color"] = Color.DarkGreen.Name;
                                            drO["OrderStatus"] = orderStatus;
                                            break;
                                        case "PENDING_NEW":
                                            drO["Color"] = Color.LightPink.Name;
                                            drO["OrderStatus"] = orderStatus;
                                            break;
                                        case "CANCELED":
                                            drO["Color"] = Color.Red.Name;
                                            drO["OrderStatus"] = orderStatus;
                                            break;
                                        case "REJECTED":
                                            drO["Color"] = Color.LightYellow.Name;
                                            drO["Text"] = reason;
                                            drO["OrderStatus"] = orderStatus;
                                            break;
                                        default:
                                            drO["Color"] = Color.White.Name;
                                            break;
                                    }


                                    drO["Product"] = executionReport.Product;
                                    drO["ProductType"] = pType;
                                    drO["Sector"] = executionReport.sector;
                                    drO["Side"] = side;
                                    drO["Gateway"] = executionReport.Gateway;
                                    if (executionReport.StopPx > 0)
                                    {
                                        if (objInstrumentSpec != null)
                                            drO["StopPx"] = executionReport.StopPx / Convert.ToDecimal(Math.Pow(10, objInstrumentSpec.Digits));
                                    }
                                    else
                                        drO["StopPx"] = executionReport.StopPx;
                                    drO["TimeInForce"] = timeInForce;
                                    if (objInstrumentSpec != null)
                                        drO["TradingCurrency"] = objInstrumentSpec.TradingCurrency;
                                    if (orderType == "STOP" || orderType == "MARKET")
                                    {
                                        drO["Price"] = 0;
                                    }
                                    else
                                    {
                                        if (executionReport.Price > 0)
                                        {
                                            if (objInstrumentSpec != null)
                                                drO["Price"] = executionReport.Price / Convert.ToDecimal(Math.Pow(10, objInstrumentSpec.Digits));
                                        }
                                        else
                                            drO["Price"] = executionReport.Price;
                                    }
                                    if (executionReport.ClosedQty > 0)
                                    {
                                        if (objInstrumentSpec != null)
                                            drO["SettledQty"] = Convert.ToDouble(executionReport.ClosedQty / objInstrumentSpec.ContractSize);
                                    }
                                    else
                                        drO["SettledQty"] = Convert.ToDouble(executionReport.ClosedQty);

                                    if (orderHistoryDS != null)
                                    {
                                        if (!orderHistoryDS.dtOrderHistory.Rows.Contains(drO["ClientOrderID"]))
                                        {
                                            orderHistoryDS.dtOrderHistory.Rows.InsertAt(drO, 0);
                                        }
                                        if (_DDOrderRow != null)
                                        {
                                            if (!_DDOrderRow.Keys.Contains(executionReport.OrderID))
                                                _DDOrderRow.Add(executionReport.OrderID, drO);
                                        }
                                    }
                                    else
                                    {
                                        if (!orderHistoryDS.dtOrderHistory.Rows.Contains(drO["ClientOrderID"]))
                                        {
                                            orderHistoryDS.dtOrderHistory.Rows.InsertAt(drO, 0);
                                        }
                                        if (_DDOrderRow != null)
                                        {
                                            if (!_DDOrderRow.Keys.Contains(executionReport.OrderID))
                                                _DDOrderRow.Add(executionReport.OrderID, drO);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                drO["TransactTime"] = transactTime;
                                if (executionReport.ClosedQty > 0)
                                {
                                    if (objInstrumentSpec != null)
                                        drO["SettledQty"] = Convert.ToDouble(executionReport.ClosedQty / objInstrumentSpec.ContractSize);
                                }
                                else
                                    drO["SettledQty"] = Convert.ToDouble(executionReport.ClosedQty);
                                double cumqty = 0;
                                double filledQty = 0;
                                double ordQty = 0;

                                if (executionReport.OrderQty > 0)
                                {
                                    if (objInstrumentSpec != null)
                                        ordQty = Convert.ToDouble(executionReport.OrderQty / objInstrumentSpec.ContractSize);
                                }
                                if (executionReport.CumQty > 0)
                                {
                                    if (objInstrumentSpec != null)
                                        cumqty = Convert.ToDouble(executionReport.CumQty / objInstrumentSpec.ContractSize);
                                }

                                if (executionReport.QtyFilled > 0)
                                {
                                    if (objInstrumentSpec != null)
                                        filledQty = Convert.ToDouble(executionReport.QtyFilled / objInstrumentSpec.ContractSize);
                                }
                                double avgpx = 0;
                                if (executionReport.AvgPx > 0)
                                {
                                    if (objInstrumentSpec != null)
                                        avgpx = (double)(executionReport.AvgPx / Convert.ToDecimal(Math.Pow(10, objInstrumentSpec.Digits)));
                                }
                                switch (orderStatus.ToUpper())
                                {

                                    case "PARTIALLY_FILLED":
                                        drO["Commission"] = executionReport.Comm;
                                        drO["Tax"] = executionReport.Tax;
                                        drO["Color"] = Color.White.Name;
                                        if (cumqty + Convert.ToDouble(drO["CumQty"].ToString()) > 0)
                                        {

                                            drO["AvgPrice"] = Math.Round(((Convert.ToDouble(drO["AvgPrice"].ToString()) *
                                                           Convert.ToDouble(drO["CumQty"].ToString())) +
                                                          (cumqty * avgpx)) /
                                                         (cumqty + Convert.ToDouble(drO["CumQty"].ToString())), 2);

                                        }

                                        drO["CumQty"] = filledQty + Convert.ToInt32(drO["CumQty"].ToString());
                                        if (ordQty == Convert.ToDouble(drO["CumQty"].ToString()))
                                        {
                                            drO["OrderStatus"] = "FILLED";
                                        }
                                        else
                                            drO["OrderStatus"] = orderStatus;
                                        break;
                                    case "FILLED":
                                        drO["Commission"] = executionReport.Comm;
                                        drO["Tax"] = executionReport.Tax;
                                        drO["Color"] = Color.White.Name;
                                        if (cumqty + Convert.ToDouble(drO["CumQty"].ToString()) > 0)
                                        {
                                            drO["AvgPrice"] = Math.Round(((Convert.ToDouble(drO["AvgPrice"].ToString()) *
                                                                Convert.ToDouble(drO["CumQty"].ToString())) +
                                                               (cumqty * avgpx)) /
                                                              (cumqty + Convert.ToDouble(drO["CumQty"].ToString())), 2);
                                        }

                                        drO["CumQty"] = filledQty + Convert.ToDouble(drO["CumQty"].ToString());

                                        if (ordQty == Convert.ToDouble(drO["CumQty"].ToString()))
                                        {
                                            drO["OrderStatus"] = orderStatus;
                                        }
                                        else
                                            drO["OrderStatus"] = "PARTIALLY FILLED";
                                        break;
                                    case "WORKING":
                                        drO["Color"] = Color.DarkGreen.Name;
                                        drO["OrderStatus"] = orderStatus;
                                        break;
                                    case "PENDING_NEW":
                                        drO["Color"] = Color.LightPink.Name;
                                        drO["OrderStatus"] = orderStatus;
                                        break;
                                    case "CANCELED":
                                        drO["Color"] = Color.Red.Name;
                                        drO["OrderStatus"] = orderStatus;
                                        break;
                                    case "REJECTED":
                                        drO["Color"] = Color.LightYellow.Name;
                                        drO["Text"] = reason;
                                        drO["OrderStatus"] = orderStatus;
                                        break;
                                    default:
                                        drO["Color"] = Color.White.Name;
                                        break;
                                };
                                double grosspl = 0;
                                grosspl = side == "BUY" ? Math.Round(Convert.ToDouble(executionReport.CounterAvgPx - executionReport.AvgPx) * Convert.ToDouble(executionReport.OrderQty), 2) : Math.Round(Convert.ToDouble(executionReport.AvgPx - executionReport.CounterAvgPx) * Convert.ToDouble(executionReport.OrderQty), 2);
                                drO["GrossPL"] = grosspl;
                            }
                            if (executionReport != null)
                            {
                                string message = string.Empty;
                                Color color = Color.White;
                                if (orderStatus.ToUpper() != "FILLED")
                                {

                                    message = "Your " + side + " " + orderType + " Order From Account >" + Convert.ToString(executionReport.Account) + " with OrderID > " + executionReport.OrderID + " for Symbol > " + executionReport.Contract + " Qty > " + (executionReport.OrderQty / objInstrumentSpec.ContractSize).ToString() + " Price > " + executionReport.Price + " is " + orderStatus + " on Date > " + transactTime + " .";
                                    if (orderType.ToUpper() == "LIMIT")
                                        color = Color.Yellow;
                                    else
                                    {
                                        if (side.ToUpper() == "BUY")
                                            color = Properties.Settings.Default.BuyOrderColor;
                                        else if (side.ToUpper() == "SELL")
                                            color = Properties.Settings.Default.SellOrderColor;
                                    }
                                }
                                else
                                {
                                    message = "Your " + side + " " + orderType + " Order From Account >" + Convert.ToString(executionReport.Account) + " with OrderID > " + executionReport.OrderID + " for Symbol > " + executionReport.Contract + " Qty > " + (executionReport.OrderQty / objInstrumentSpec.ContractSize).ToString() + " Price > " + executionReport.Price + " is " + orderStatus + " with Trade No. > " + executionReport.ExecID + " on Date > " + transactTime + " .";
                                }
                                DataRow dr = messageLogDS.dtMessageLog.NewRow();
                                DateTime dt = DateTime.Now;
                                string str = string.Format(Properties.Settings.Default.TimeFormat.Contains("24") ? "{0:HH:mm:ss tt dd/MM/yyyy}" : "{0:hh:mm:ss tt dd/MM/yyyy}", dt);
                                dr["Time"] = dt.ToString();
                                dr["MessageType"] = "ORDER RESPONSE";
                                dr["Message"] = message;
                                dr["Account"] = (int)executionReport.Account;
                                dr["StrDateTime"] = str;
                                dr["Color"] = color.Name;
                                if (System.Threading.Monitor.TryEnter(messageLogDS.dtMessageLog, 500))
                                {
                                    try
                                    {
                                        messageLogDS.dtMessageLog.Rows.InsertAt(dr, 0);
                                        messageLogDS.dtMessageLog.AcceptChanges();
                                    }
                                    finally
                                    {
                                        System.Threading.Monitor.Exit(messageLogDS.dtMessageLog);
                                    }
                                }
                            }

                            if (orderStatus.ToUpper() == "REJECTED" && reason.ToUpper() == "REQUOTE" &&
                               MessageBox.Show("Do you want to requote? Please requote at " + executionReport.LastPx + " .",
                                                "Requote Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                double expiry = 0;
                                double.TryParse(executionReport.ExpireDate, out expiry);
                                var newOrder = new ClsNewOrder
                                {
                                    msgtype = NEW_ORDER_REQUEST,
                                    Account = (int)executionReport.Account,
                                    ClOrdId = executionReport.ClOrdId,
                                    Contract = executionReport.Contract,
                                    origClOrdId = "",
                                    ExpireDate = 0,
                                    Gateway = executionReport.Gateway,
                                    OrderID = (int)executionReport.OrderID,
                                    OrderType = executionReport.OrderType,
                                    PositionEffect = 'O',
                                    Price = Convert.ToDouble(executionReport.LastPx),
                                    Product = executionReport.Product,
                                    OrderQty = (uint)executionReport.OrderQty,
                                    ProductType = executionReport.ProductType,
                                    Side = executionReport.Side,
                                    StopPx = Convert.ToDouble(executionReport.StopPx),
                                    TimeInForce = executionReport.TimeInForce,
                                    LnkdOrdId = ""
                                };
                                SubmitNewOrder(newOrder);
                            }
                        }

                        if (DoHandleExecutionReport == null) return;
                        DoHandleExecutionReport(executionReport);
                        OnOrderLog("ExecutionReport");
                    }
                }
                finally
                {
                    System.Threading.Monitor.Exit(orderHistoryDS.dtOrderHistory);
                }
            }
            if (_linkedOrderId > 0 || (_status == "FILLED" || _status == "PARTIALLY_FILLED"))
            {
                OnOrderSettle();
            }
        }

        public bool SubmitNewOrder(ClsNewOrder newOrder)
        {
            bool flag = false;
            try
            {
                if (Convert.ToUInt32(Properties.Settings.Default.DefaultTradingAccount) != 0 && IsOrderMgrLoaded && clsTWSDataManagerJSON.INSTANCE.IsDataMgrConnected)
                {
                    string oriClOrdID = string.Empty;
                    string LnkdOrdId = string.Empty;
                    string message = string.Empty;
                    string side = TWS.Cls.ClsGlobal.DDReverseSide[Convert.ToSByte(newOrder.Side)];
                    string orderType = TWS.Cls.ClsGlobal.DDReverseOrderType[Convert.ToSByte(newOrder.OrderType)];
                    newOrder.msgtype = NEW_ORDER_REQUEST;
                    newOrder.TransactTime = DateTime.UtcNow.ToOADate();
                    var json = new JavaScriptSerializer().Serialize(newOrder);
                    websocket.Send(json);
                    _syncJSONQueue.Enqueue("TO SERVER :" + json + Environment.NewLine);
                    message = "Your New Order of " + side + " " + orderType + " From Account >" + Convert.ToString(newOrder.Account) +
                        " for Symbol > " + newOrder.Contract + " Qty > " + newOrder.OrderQty + " Price > " + newOrder.Price + " is submited .";

                    DataRow dr1 = clsTWSOrderManagerJSON.INSTANCE.messageLogDS.dtMessageLog.NewRow();
                    DateTime dt = DateTime.Now;
                    string str;
                    if (Properties.Settings.Default.TimeFormat.Contains("24"))
                    {
                        str = string.Format("{0:HH:mm:ss tt dd/MM/yyyy}", dt);
                    }
                    else
                    {
                        str = string.Format("{0:hh:mm:ss tt dd/MM/yyyy}", dt);
                    }
                    dr1["Time"] = dt.ToString();
                    dr1["MessageType"] = "NEW ORDER REQUEST";
                    dr1["Message"] = message;
                    dr1["Account"] = 0;
                    dr1["StrDateTime"] = str;
                    dr1["Color"] = "White";
                    if (System.Threading.Monitor.TryEnter(clsTWSOrderManagerJSON.INSTANCE.messageLogDS.dtMessageLog, 500))
                    {
                        try
                        {
                            clsTWSOrderManagerJSON.INSTANCE.messageLogDS.dtMessageLog.Rows.InsertAt(dr1, 0);
                            clsTWSOrderManagerJSON.INSTANCE.messageLogDS.dtMessageLog.AcceptChanges();
                        }
                        finally
                        {
                            System.Threading.Monitor.Exit(clsTWSOrderManagerJSON.INSTANCE.messageLogDS.dtMessageLog);
                        }
                    }

                    flag = true;
                }
                else
                {
                    ClsCommonMethods.ShowInformation("Order server or Quote server Disconnected New Order request failed .");
                }
            }
            catch (Exception E)
            {
                _syncJSONQueue.Enqueue("Error at SubmitNewOrder >>" + E.Message);

            }
            return flag;
        }

        internal bool ModifyOrder(ClsModifyOrder objModifyOrder)
        {
            try
            {
                if (IsOrderMgrLoaded && clsTWSDataManagerJSON.INSTANCE.IsDataMgrConnected)
                {
                    string message = string.Empty;
                    string side = TWS.Cls.ClsGlobal.DDReverseSide[Convert.ToSByte(objModifyOrder.OldSide)];
                    string orderType = TWS.Cls.ClsGlobal.DDReverseOrderType[Convert.ToSByte(objModifyOrder.OldOrderType)];
                    Color color = Color.White;
                    objModifyOrder.msgtype = ORDER_REPLACE_REQUEST;
                    var json = new JavaScriptSerializer().Serialize(objModifyOrder);
                    _syncJSONQueue.Enqueue("TO SERVER :" + json + Environment.NewLine);
                    websocket.Send(json);

                    message = "Your " + side + " " + orderType + " Order From Account >" + Convert.ToString(objModifyOrder.OldAccount) + " with OrderID > " + objModifyOrder.OldOrderID + " for Symbol > " + objModifyOrder.OldContract + " Qty > " + objModifyOrder.OldOrderQty + " Price > " + objModifyOrder.OldPrice + " is requested to Modify with Qty > " + objModifyOrder.OrderQty + " Price > " + objModifyOrder.Price + " .";

                    DataRow dr1 = INSTANCE.messageLogDS.dtMessageLog.NewRow();
                    DateTime dt = DateTime.Now;
                    string str = string.Format(Properties.Settings.Default.TimeFormat.Contains("24") ? "{0:HH:mm:ss tt dd/MM/yyyy}" : "{0:hh:mm:ss tt dd/MM/yyyy}", dt);
                    dr1["Time"] = dt.ToString();
                    dr1["MessageType"] = "ORDER MODIFY REQUEST";
                    dr1["Message"] = message;
                    dr1["Account"] = 0;
                    dr1["StrDateTime"] = str;
                    dr1["Color"] = color.Name;
                    if (System.Threading.Monitor.TryEnter(INSTANCE.messageLogDS.dtMessageLog, 500))
                    {
                        try
                        {
                            INSTANCE.messageLogDS.dtMessageLog.Rows.InsertAt(dr1, 0);
                            INSTANCE.messageLogDS.dtMessageLog.AcceptChanges();
                        }
                        finally
                        {
                            System.Threading.Monitor.Exit(INSTANCE.messageLogDS.dtMessageLog);
                        }
                    }

                    return true;
                }
                else
                {
                    ClsCommonMethods.ShowInformation("Order server or Quote Server disconnected, Order modification failed.");

                    return false;
                }

            }
            catch (Exception ex)
            {
                _syncJSONQueue.Enqueue("ERROR >> ModifyOrder >> " + ex.Message);
                return false;
            }

        }

        public void SendMail(DateTime time, string subject, string username, string to, string body)
        {
            //_objOrderManager.mailRequest(time, subject, username, to, body);
        }

        public string GetDateTimeFromString(string datetime)
        {
            try
            {
                if (datetime != string.Empty)
                {
                    string[] x = datetime.Split('-');
                    string dat = x[1].ToString() + "/" + x[2].ToString() + "/" + x[0].ToString() + " " + x[3].ToString() + ":" + x[4].ToString() + ":" + x[5].ToString();
                    DateTime dtx = DateTime.MinValue;
                    if (CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern != "M/d/yyyy")
                    {
                        dtx = DateTime.Parse(dat, CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        DateTime.TryParse(dat, out dtx);
                    }

                    string date = string.Empty;
                    if (dtx != DateTime.MinValue)
                    {
                        date = string.Format(Properties.Settings.Default.TimeFormat.Contains("24") ? "{0:MM/dd/yyyy HH:mm:ss}" : "{0:MM/dd/yyyy hh:mm:ss tt}", dtx);
                    }
                    return date;
                }
                else
                    return datetime;
            }
            catch (Exception)
            {
                return DateTime.Now.ToString();
            }
        }

        public string UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime.ToString();
        }
        public DateTime GetDateTimeFromOAdate(double OAdate)
        {
            try
            {
                if (OAdate > 0)
                {
                    return DateTime.FromOADate(OAdate);
                }
                else
                    return DateTime.MinValue;
            }
            catch (Exception)
            {
                return DateTime.MinValue;
            }
        }

        public void onParticipantResponse(List<AccountDetails> lstAccountInfo, bool islastPck)
        {
            try
            {
                if (lstAccountInfo.Count > 0)
                {
                    foreach (AccountDetails accountInf in lstAccountInfo)
                    {
                        if (accountInf.MarginCall1 == 1)
                        {
                            ClsCommonMethods.ShowInformation("Account : " + accountInf.AccountID.ToString() + " => First Margin call reached.");
                        }
                        else if (accountInf.MarginCall1 == 2)
                        {
                            ClsCommonMethods.ShowInformation("Account : " + accountInf.AccountID.ToString() + " => Second Margin call reached.");
                        }
                        else if (accountInf.MarginCall1 == 3)
                        {
                            ClsCommonMethods.ShowInformation("Account : " + accountInf.AccountID.ToString() + " => Third Margin call reached.");
                        }
                        lock (accountInfoDS.dtAccountInfo)
                        {
                            if (accountInfoDS.dtAccountInfo.Select("AccountId=" + Convert.ToString(accountInf.AccountID)).Count() == 0)
                            {

                                DataRow dr = accountInfoDS.dtAccountInfo.NewRow();
                                dr["AccountId"] = (int)accountInf.AccountID;
                                dr["Balance"] = accountInf.Balance;
                                dr["Group"] = accountInf.Group;
                                dr["TraderName"] = accountInf.TraderName;
                                dr["BuySideTurnover"] = accountInf.BuySideTurnOver;
                                dr["SellSideTurnover"] = accountInf.SellSideturnOver;
                                dr["HedgeAllowed"] = accountInf.HedgingType;
                                dr["Leverage"] = accountInf.Leverage;
                                dr["FreeMargin"] = accountInf.FreeMargin;
                                dr["Margin"] = accountInf.Margin;
                                dr["MarginCall1"] = accountInf.MarginCall1;
                                dr["MarginCall2"] = accountInf.MarginCall2;
                                dr["MarginCall3"] = accountInf.MarginCall3;
                                dr["UsedMargin"] = accountInf.UsedMargin;
                                dr["ReservedMargin"] = accountInf.ReservedMargin;
                                dr["AccountType"] = accountInf.AccountType;
                                accountInfoDS.dtAccountInfo.Rows.Add(dr);
                                if (!_DDAccounts.Keys.Contains((int)accountInf.AccountID))
                                {
                                    _DDAccounts.Add((int)accountInf.AccountID, dr);
                                }
                                if (!_DDAccountTraderName.Keys.Contains((int)accountInf.AccountID))
                                {
                                    _DDAccountTraderName.Add((int)accountInf.AccountID, accountInf.TraderName);
                                }

                            }
                            else
                            {
                                DataRow[] drArr = accountInfoDS.dtAccountInfo.Select("AccountId=" + Convert.ToString(accountInf.AccountID));
                                int i = accountInfoDS.dtAccountInfo.Rows.IndexOf(drArr[0]);
                                accountInfoDS.dtAccountInfo.Rows[i]["Balance"] = accountInf.Balance;
                                accountInfoDS.dtAccountInfo.Rows[i]["BuySideTurnover"] = accountInf.BuySideTurnOver;
                                accountInfoDS.dtAccountInfo.Rows[i]["SellSideTurnover"] = accountInf.SellSideturnOver;
                                accountInfoDS.dtAccountInfo.Rows[i]["HedgeAllowed"] = accountInf.HedgingType;
                                accountInfoDS.dtAccountInfo.Rows[i]["Leverage"] = accountInf.Leverage;
                                accountInfoDS.dtAccountInfo.Rows[i]["FreeMargin"] = accountInf.FreeMargin;
                                accountInfoDS.dtAccountInfo.Rows[i]["Margin"] = accountInf.Margin;
                                accountInfoDS.dtAccountInfo.Rows[i]["MarginCall1"] = accountInf.MarginCall1;
                                accountInfoDS.dtAccountInfo.Rows[i]["MarginCall2"] = accountInf.MarginCall2;
                                accountInfoDS.dtAccountInfo.Rows[i]["MarginCall3"] = accountInf.MarginCall3;
                                accountInfoDS.dtAccountInfo.Rows[i]["UsedMargin"] = accountInf.UsedMargin;
                                DataRow dr = accountInfoDS.dtAccountInfo.Rows[i];
                                _DDAccounts[(int)accountInf.AccountID] = dr;
                            }
                        }
                    }

                    int acc = 0;
                    if (Properties.Settings.Default.DefaultTradingAccount != string.Empty)
                        acc = Convert.ToInt32(Properties.Settings.Default.DefaultTradingAccount);

                    IEnumerable<AccountDetails> lstaccounts = lstAccountInfo.Where(accInf => acc != 0 && Convert.ToInt32(accInf.AccountID) == acc);

                    if (lstaccounts.Count() == 0)
                        Properties.Settings.Default.DefaultTradingAccount = Convert.ToString(lstAccountInfo.ToArray()[0].AccountID);

                    if (islastPck)
                    {
                        if (_flagFirstParticipantListResponce == false)
                        {

                            if (Properties.Settings.Default.AccountType.ToUpper().Trim() == "BROKER")
                            {
                                //Thread HistoricalDataThread = new Thread(SubscribeHistoricalData);
                                //HistoricalDataThread.Start();
                                for (int i = 0; i < _DDAccounts.Keys.Count; i++)
                                {
                                    getPositionResponse((uint)_DDAccounts.Keys.ToArray()[i]);
                                    getOrderHistoryResponse((uint)_DDAccounts.Keys.ToArray()[i]);

                                }
                            }
                            else
                            {
                                getPositionResponse((uint)_DDAccounts.Keys.ToArray()[0]);
                                getOrderHistoryResponse((uint)_DDAccounts.Keys.ToArray()[0]);

                            }
                            int x = _DDAccounts.Keys.First();
                            _flagFirstParticipantListResponce = true;
                            timer.Elapsed -= new ElapsedEventHandler(OnElapsedTime);
                            timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
                            timer.Interval = 5000;
                            timer.Enabled = true;
                        }

                        string message = string.Empty;
                        Color color = Color.White;
                        message = "Participant list for Account >" + lstAccountInfo[0].AccountID + " Received.";
                        DataRow dr = messageLogDS.dtMessageLog.NewRow();
                        DateTime dt = DateTime.Now;
                        string str = string.Format(Properties.Settings.Default.TimeFormat.Contains("24") ? "{0:HH:mm:ss tt dd/MM/yyyy}" : "{0:hh:mm:ss tt dd/MM/yyyy}", dt);
                        dr["Time"] = dt.ToString();
                        dr["MessageType"] = "PARTICIPANT RESPONSE";
                        dr["Message"] = "PARTICIPANT RESPONSE :- " + message;
                        dr["Account"] = (int)lstAccountInfo[0].AccountID;
                        dr["StrDateTime"] = str;
                        dr["Color"] = color.Name;
                        if (System.Threading.Monitor.TryEnter(messageLogDS.dtMessageLog, 500))
                        {
                            try
                            {
                                messageLogDS.dtMessageLog.Rows.InsertAt(dr, 0);
                                messageLogDS.dtMessageLog.AcceptChanges();
                            }
                            finally
                            {
                                System.Threading.Monitor.Exit(messageLogDS.dtMessageLog);
                            }
                        }
                        foreach (KeyValuePair<int, DataRow> account in _DDAccounts)
                        {
                            switch (account.Value["AccountType"].ToString().ToUpper().Trim())
                            {
                                case "BROKER":
                                    Properties.Settings.Default.DefaultTradingAccount = Convert.ToString(account.Key);
                                    ClsGlobal.BrokerAccountId = account.Key;
                                    ClsGlobal.MarketMakerAccountId = 0;
                                    break;
                                case "MARKETMAKER":
                                    Properties.Settings.Default.DefaultTradingAccount = Convert.ToString(account.Key);
                                    ClsGlobal.MarketMakerAccountId = account.Key;
                                    ClsGlobal.BrokerAccountId = 0;
                                    break;
                            }
                        }
                        if (lstAccountInfo.Count > 1 && (ClsGlobal.BrokerAccountId > 0 || ClsGlobal.MarketMakerAccountId > 0))
                        {
                            foreach (KeyValuePair<int, DataRow> account in _DDAccounts)
                            {
                                RequestForNetPositionOfAccount(Convert.ToInt32(account.Key), false);
                            }
                        }

                        lock (accountInfoDS.dtAccountInfo)
                        {
                            accountInfoDS.dtAccountInfo.AcceptChanges();
                        }
                        OnParticipantResponse(_DDAccounts);
                    }

                }
                else
                {
                    _syncJSONQueue.Enqueue("No Trading account is associated with participant.");
                }

            }
            catch (Exception ex)
            {
                _syncJSONQueue.Enqueue("Error at onParticipantResponse >> " + ex.Message);
            }

        }

        private void SubscribeHistoricalData()
        {
            // Need to implement
        }
        internal void RequestForNetPositionOfAccount(int accountno, bool check)
        {
            try
            {
                if (check)
                {
                    netpositionDS.dtNetPosition.Clear();
                    _DDNetPosRow.Clear();
                }
                switch (accountno)
                {
                    case 0:
                        foreach (string account in _DDAccountInfo.Keys)
                        {
                            getPositionResponse(Convert.ToUInt32(account));
                        }
                        break;
                    default:
                        getPositionResponse(Convert.ToUInt32(accountno));
                        break;
                }
            }
            catch (Exception ex)
            {
                _syncJSONQueue.Enqueue("Error at RequestForNetPositionOfAccount >> " + ex.Message);
            }

        }

        internal void getPositionResponse(uint AccountId)
        {
            try
            {
                if (websocket.State == WebSocketState.Open)
                {
                    positionRequest objPosReq = new positionRequest();
                    objPosReq.Account = AccountId;
                    objPosReq.Subscribe = "Y";
                    objPosReq.SenderID = ClsGlobal.BrokerGroupId.ToString();
                    objPosReq.msgtype = POSITION_REQUEST;
                    var json = new JavaScriptSerializer().Serialize(objPosReq);
                    _syncJSONQueue.Enqueue("TO SERVER :" + json + Environment.NewLine);
                    websocket.Send(json);
                }
                else
                {
                    _syncJSONQueue.Enqueue("getPositionResponse >> websocket is Closed");
                }
            }
            catch (Exception ex)
            {
                _syncJSONQueue.Enqueue("Error at getPositionResponse >> " + ex.Message);
            }


        }

        internal void participantRequest()
        {
            try
            {
                if (websocket.State == WebSocketState.Open)
                {
                    participantRequest obj = new participantRequest();
                    obj.UserName = UserName;
                    obj.msgtype = PARTICIPANT_LIST_REQUEST;
                    var json = new JavaScriptSerializer().Serialize(obj);
                    websocket.Send(json);
                    _syncJSONQueue.Enqueue("TO SERVER :" + json + Environment.NewLine);
                }
                else
                {
                    _syncJSONQueue.Enqueue("participantRequest >> websocket is Closed");
                }
            }
            catch (Exception ex)
            {
                _syncJSONQueue.Enqueue("Error at participantRequest >> " + ex.Message);
            }


        }

        internal void RequestForOrderHistoryOfAccount(int accountno)
        {

            if (Monitor.TryEnter(orderHistoryDS.dtOrderHistory, 500))
            {
                try
                {
                    orderHistoryDS.dtOrderHistory.Clear();
                    _DDOrderRow.Clear();
                    orderHistoryDS.dtOrderHistory.AcceptChanges();
                    OnOrderHistoryResponse();
                }
                finally
                {
                    System.Threading.Monitor.Exit(orderHistoryDS.dtOrderHistory);
                }
            }
            if (accountno == 0)
            {
                foreach (int account in _DDAccounts.Keys.Where(account => websocket != null))
                {
                    getOrderHistoryResponse(Convert.ToUInt32(account));
                }
            }
            else
            {
                if (websocket != null) getOrderHistoryResponse(Convert.ToUInt32(accountno));
            }

        }

        public void onMailDeliveryResponse(string UserName, string Body, string subject, string To, string Time)
        {
            try
            {
                if (accountInfoDS != null)
                {
                    DataRow dr = accountInfoDS.dtMailData.NewRow();
                    dr["DateTime"] = Time;
                    dr["To"] = To;
                    dr["From"] = UserName;
                    dr["Subject"] = subject;
                    dr["Message"] = Body;

                    if (Monitor.TryEnter(accountInfoDS.dtMailData, 500))
                    {
                        try
                        {
                            accountInfoDS.dtMailData.Rows.InsertAt(dr, 0);
                            accountInfoDS.dtMailData.AcceptChanges();
                        }
                        finally
                        {
                            Monitor.Exit(accountInfoDS.dtMailData);
                        }
                    }
                }
                ClsCommonMethods.ShowInformation("Mail sent successfully!");
            }
            catch (Exception ex)
            {
                _syncJSONQueue.Enqueue("ERROR >> onMailDeliveryResponse >> " + ex.Message);
            }
        }

        internal void RefreshOrders()
        {
            try
            {
                _isTradeHistoryLoaded = false;
                _DDOrderRow.Clear();
                _orderId.Clear();
                _DDTradeRow.Clear();
                if (Monitor.TryEnter(INSTANCE.tradeHistoryDS.dtTradeHistory, 1000))
                {
                    try
                    {
                        tradeHistoryDS.dtTradeHistory.Rows.Clear();
                    }
                    finally
                    {
                        Monitor.Exit(INSTANCE.tradeHistoryDS.dtTradeHistory);
                    }
                }
                if (Monitor.TryEnter(INSTANCE.orderHistoryDS.dtOrderHistory, 1000))
                {
                    try
                    {
                        orderHistoryDS.dtOrderHistory.Rows.Clear();
                    }
                    finally
                    {
                        Monitor.Exit(INSTANCE.orderHistoryDS.dtOrderHistory);
                    }
                }

                if (Properties.Settings.Default.AccountType.ToUpper().Trim() == "BROKER")
                {
                    for (int i = 0; i < _DDAccounts.Keys.Count; i++)
                    {
                        getOrderHistoryResponse(
                    (uint)_DDAccounts.Keys.ToArray()[i]);
                    }
                }
                else
                {
                    getOrderHistoryResponse(
                        (uint)_DDAccounts.Keys.ToArray()[0]);
                }
            }
            catch (Exception ex)
            {

                _syncJSONQueue.Enqueue("ERROR >> RefreshOrders >> " + ex.Message);
            }

        }

        public Dictionary<int, DataRow> GetParticipantsList()
        {
            return _DDAccounts;
        }

        public List<string> GetParticipants()
        {

            var lstAccountIds = new List<int>();
            if (_DDAccounts != null && _DDAccounts.Count > 0)
            {
                lstAccountIds.AddRange(_DDAccounts.Keys);
            }
            List<string> lstAccountNos = lstAccountIds.ConvertAll<string>(delegate (int i) { return i.ToString(); });

            return lstAccountNos;
        }

        public void ChangePassword(string userName, string oldMpassword, string newMPassword, string newTpassword)
        {
            // _objOrderManager.changePassword(userName, oldMpassword, newMPassword, newTpassword);
        }

        public void CloseOrder(int account, string clOrderId, string contractName,
                    sbyte producttype, string productName, DateTime expiryDate,
                    string gatewayName, string origClOrdId, sbyte Side, double orderQty, sbyte OrderType,
                    double price, double stopPx, sbyte tif, int minorDisclosedQty, sbyte positionEffect,
                    double transactTime, double slipage, string closeClOrdId, string closeOrderId, bool ocOrder)
        {
            try
            {

                if (IsOrderMgrLoaded && clsTWSDataManagerJSON.INSTANCE.IsDataMgrConnected)
                {

                    string LnkdOrdId = string.Empty;
                    string message = string.Empty;
                    string side = ClsGlobal.DDReverseSide[Side];
                    string orderType = ClsGlobal.DDReverseOrderType[Convert.ToSByte(OrderType)];

                    ClsNewOrder objOrder = new ClsNewOrder();
                    objOrder.Account = account;
                    objOrder.ClOrdId = clOrderId;
                    objOrder.Contract = contractName;
                    objOrder.ExpireDate = 0;
                    objOrder.Gateway = gatewayName;
                    objOrder.LnkdOrdId = closeClOrdId;
                    objOrder.msgtype = NEW_ORDER_REQUEST;
                    objOrder.OrderID = Convert.ToInt32(clOrderId.Trim());
                    objOrder.OrderQty = orderQty;
                    objOrder.OrderType = '1';
                    objOrder.origClOrdId = "";
                    objOrder.PositionEffect = 'C';
                    objOrder.Price = price;
                    objOrder.Product = productName;
                    objOrder.ProductType = Convert.ToChar(producttype);
                    objOrder.Side = Convert.ToChar(Side);
                    objOrder.StopPx = stopPx;
                    objOrder.TimeInForce = Convert.ToChar(tif);
                    objOrder.TransactTime = DateTime.UtcNow.ToOADate();
                    var json = new JavaScriptSerializer().Serialize(objOrder);
                    _syncJSONQueue.Enqueue("TO SERVER :" + json + Environment.NewLine);
                    websocket.Send(json);

                    message = "Your Request to Close " + side + " " + orderType + " Order From Account >" + Convert.ToString(account) + " for Symbol > " + contractName + " Qty > " + orderQty + " Price > " + price + " is submited .";

                    DataRow dr1 = clsTWSOrderManagerJSON.INSTANCE.messageLogDS.dtMessageLog.NewRow();
                    DateTime dt = DateTime.UtcNow;
                    string str;
                    if (Properties.Settings.Default.TimeFormat.Contains("24"))
                    {
                        str = string.Format("{0:HH:mm:ss tt dd/MM/yyyy}", dt);
                    }
                    else
                    {
                        str = string.Format("{0:hh:mm:ss tt dd/MM/yyyy}", dt);
                    }
                    dr1["Time"] = dt;
                    dr1["MessageType"] = "ORDER CANCEL REQUEST";
                    dr1["Message"] = message;
                    dr1["Account"] = 0;
                    dr1["StrDateTime"] = str;
                    dr1["Color"] = "White";
                    if (Monitor.TryEnter(messageLogDS.dtMessageLog, 1000))
                    {
                        try
                        {
                            messageLogDS.dtMessageLog.Rows.InsertAt(dr1, 0);
                            messageLogDS.dtMessageLog.AcceptChanges();
                        }
                        finally
                        {
                            Monitor.Exit(messageLogDS.dtMessageLog);
                        }
                    }
                }
                else
                {
                    ClsCommonMethods.ShowInformation("Order server or Quote Server disconnected Canceling order failed .");
                }
            }
            catch (Exception ex)
            {

                _syncJSONQueue.Enqueue("ERROR >> CloseOrder >> " + ex.Message);
            }
        }

        public void CancelOrder(ClsCancelOrder objOrder)
        {
            try
            {

                if (IsOrderMgrLoaded && clsTWSDataManagerJSON.INSTANCE.IsDataMgrConnected)
                {

                    string message = string.Empty;
                    string side = ClsGlobal.DDReverseSide[Convert.ToSByte(objOrder.Side)];
                    string orderType = ClsGlobal.DDReverseOrderType[Convert.ToSByte(objOrder.OrderType)];
                    objOrder.msgtype = ORDER_CANCEL_REQUEST;
                    var json = new JavaScriptSerializer().Serialize(objOrder);
                    _syncJSONQueue.Enqueue("TO SERVER :" + json + Environment.NewLine);
                    websocket.Send(json);

                    message = "Your Request to Cancel " + side + " " + orderType + " Order From Account >" + objOrder.Account.ToString() + " for Symbol > " + objOrder.Contract + " Qty > " + objOrder.OrderQty.ToString()
                        + " Price > " + objOrder.Price.ToString() + " is submited .";

                    DataRow dr1 = messageLogDS.dtMessageLog.NewRow();
                    DateTime dt = DateTime.Now;
                    string str;
                    if (Properties.Settings.Default.TimeFormat.Contains("24"))
                    {
                        str = string.Format("{0:HH:mm:ss tt dd/MM/yyyy}", dt);
                    }
                    else
                    {
                        str = string.Format("{0:hh:mm:ss tt dd/MM/yyyy}", dt);
                    }
                    dr1["Time"] = dt.ToString();
                    dr1["MessageType"] = "ORDER CANCEL REQUEST";
                    dr1["Message"] = message;
                    dr1["Account"] = 0;
                    dr1["StrDateTime"] = str;
                    dr1["Color"] = "White";
                    if (Monitor.TryEnter(messageLogDS.dtMessageLog, 500))
                    {
                        try
                        {
                            messageLogDS.dtMessageLog.Rows.InsertAt(dr1, 0);
                            messageLogDS.dtMessageLog.AcceptChanges();
                        }
                        finally
                        {
                            Monitor.Exit(messageLogDS.dtMessageLog);
                        }
                    }

                }
                else
                {

                    ClsCommonMethods.ShowInformation("Order server or Quote Server disconnected, Canceling order failed .");
                }
            }
            catch (Exception ex)
            {

                _syncJSONQueue.Enqueue("ERROR >> CancelOrder >> " + ex.Message);
            }
        }

        internal void getOrderHistoryResponse(uint AccountId)
        {
            try
            {
                if (websocket.State == WebSocketState.Open)
                {
                    OrderRequest obj = new OrderRequest();

                    obj.Account = AccountId;
                    obj.Filter = "Y";
                    obj.SenderID = ClsGlobal.BrokerGroupId.ToString();
                    obj.msgtype = ORDER_HISTORY_REQUEST;
                    var json = new JavaScriptSerializer().Serialize(obj);
                    _syncJSONQueue.Enqueue("TO SERVER :" + json + Environment.NewLine);
                    websocket.Send(json);
                }
                else
                {
                    _syncJSONQueue.Enqueue("getOrderHistoryResponse >> websocket is Closed");
                }
            }
            catch (Exception ex)
            {
                _syncJSONQueue.Enqueue("Error at getOrderHistoryResponse >> " + ex.Message);
            }

        }

        internal void getTradeHistoryResponse(uint AccountId)
        {
            try
            {
                if (websocket.State == WebSocketState.Open)
                {
                    OrderRequest obj = new OrderRequest();
                    obj.Account = AccountId;
                    obj.Filter = "Y";
                    obj.SenderID = ClsGlobal.BrokerGroupId.ToString();
                    obj.msgtype = TRADE_HISTORY_REQUEST;
                    var json = new JavaScriptSerializer().Serialize(obj);
                    websocket.Send(json);
                }
                else
                {
                    _syncJSONQueue.Enqueue("getTradeHistoryResponse >> websocket is Closed");
                }

            }
            catch (Exception ex)
            {
                _syncJSONQueue.Enqueue("Error at getTradeHistoryResponse >> " + ex.Message);
            }

        }

        internal void onAccountResponse(List<AccountDetails> lstAccountInfo, bool islastPck)
        {
            try
            {
                if (lstAccountInfo.Count > 0)
                {

                    foreach (AccountDetails accountInf in lstAccountInfo)
                    {
                        if (_DDAccountInfo.Keys.Contains(Convert.ToString(accountInf.AccountID)))
                            _DDAccountInfo[Convert.ToString(accountInf.AccountID)] = accountInf;
                        else
                            _DDAccountInfo.Add(Convert.ToString(accountInf.AccountID), accountInf);

                    }
                    if (islastPck)
                    {
                        OnAccountResponse(lstAccountInfo);
                    }

                }
                else
                {
                    _syncJSONQueue.Enqueue("No Trading account is associated Account responce.");
                }
            }
            catch (Exception ex)
            {
                _syncJSONQueue.Enqueue("Error at onAccountResponse >> " + ex.Message);
            }

        }

        private void OnElapsedTime(object source, ElapsedEventArgs e)
        {
            if (!_isTradeResponceReceived)
            {
                _isTradeResponceReceived = true;
                _isTradeHistoryLoaded = true;

            }
            if (!isSpashClosed)
            {
                isSpashClosed = true;
                OnTradeHistoryLoaded();
            }
            timer.Enabled = false;
        }

        public List<MailData> GetMailBoxInfo(string user, string pwd, int participantId, DateTime todate, DateTime fromDate)
        {
            List<MailData> lst = new List<MailData>();
            //lst = obj.GetMailBoxInfo(user, pwd, participantId, todate, fromDate);           
            return lst;
        }

        public void onChangePasswordResponse(string userName, string reason, bool isPasswordChanged)
        {
            try
            {

                DateTime date = DateTime.Now;
                string message = string.Empty;
                string str = string.Format(Properties.Settings.Default.TimeFormat.Contains("24") ? "{0:HH:mm:ss tt dd/MM/yyyy}" : "{0:hh:mm:ss tt dd/MM/yyyy}", date);
                DataRow dr = messageLogDS.dtMessageLog.NewRow();
                if (isPasswordChanged)
                {
                    message = userName + " Your Password changed successfuly .";
                }
                else
                {
                    message = userName + " Your Powssord can not be changed due to " + reason + " .";
                }
                dr["Time"] = date.ToString();
                dr["MessageType"] = "PASSWORD CHANGE RESPONSE";
                dr["Message"] = message;
                dr["Account"] = 0;
                dr["StrDateTime"] = str;
                dr["Color"] = Color.Yellow;
                if (Monitor.TryEnter(messageLogDS.dtMessageLog, 500))
                {
                    try
                    {
                        messageLogDS.dtMessageLog.Rows.InsertAt(dr, 0);
                        messageLogDS.dtMessageLog.AcceptChanges();
                    }
                    finally
                    {
                        Monitor.Exit(messageLogDS.dtMessageLog);
                    }
                }
                OnChangePasswordResponse(userName, reason, isPasswordChanged);
            }
            catch (Exception ex)
            {

                _syncJSONQueue.Enqueue("ERROR >> onChangePasswordResponse >> " + ex.Message);
            }

        }

        internal void Refresh()
        {
            try
            {
                PosContracts.Clear();
                _flagFirstParticipantListResponce = false;
                _DDAccountInfo.Clear();
                _DDAccounts.Clear();
                _DDMessages.Clear();
                _DDNetPos.Clear();
                _DDNetPosRow.Clear();
                _DDOrderRow.Clear();
                _orderId.Clear();
                _DDTradeRow.Clear();
                accountInfoDS.dtAccountInfo.Rows.Clear();
                netpositionDS.dtNetPosition.Rows.Clear();
                orderHistoryDS.dtOrderHistory.Rows.Clear();
                tradeHistoryDS.dtTradeHistory.Rows.Clear();
            }
            catch (Exception ex)
            {

                _syncJSONQueue.Enqueue("ERROR >> Refresh >> " + ex.Message);
            }

        }

        private void ThreadHandleQueue()
        {
            while (true)
            {

                if (_syncJSONQueue.Count == 0)
                {
                    Thread.Sleep(10);
                    //this will deflate the queue to size 0..
                    _syncJSONQueue.TrimToSize();
                    continue;
                }
                if (_syncJSONQueue.Count > 0)
                {
                    string msg = (string)_syncJSONQueue.Dequeue();
                    log(msg);
                }
                Thread.Sleep(0);

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
                    SubmitNewOrder(order);
                }
                Thread.Sleep(0);

            }
        }

        /// <summary>
        /// This method creates the log 
        /// </summary>
        /// <param name="msg">message to write in log file</param>
        /// <param name="path">path of the log file</param>
        private void log(string msg)
        {
            lock (LockObject)  // all other threads will wait for y
            {
                string _path = logPath + "Log_" + DateTime.Now.ToString("dd_MM_yyyy");
                if (File.Exists(_path + "\\Log.txt"))
                {
                    try
                    {
                        TextWriter tsw = new StreamWriter(_path + "\\Log.txt", true);
                        tsw.WriteLine(DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt") + " : " + msg + System.Environment.NewLine);
                        tsw.Close();
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                }
                else
                {
                    Directory.CreateDirectory(_path);
                    FileStream fsDevelopmentLog = new FileStream(_path + "\\Log.txt", FileMode.OpenOrCreate, FileAccess.Write,
                                                      FileShare.ReadWrite);
                    fsDevelopmentLog.Close();
                    try
                    {
                        TextWriter tsw = new StreamWriter(_path + "\\Log.txt", true);
                        tsw.WriteLine(DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt") + " : " + msg + System.Environment.NewLine);
                        tsw.Close();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }
        #endregion "      Methods      "

    }

    public class BusinessReject
    {

        public int BusinessRejectReason;
        public int RefMsgType;
        public string BusinessRejectRefID = string.Empty;
        public string Text = string.Empty;

    }

    public class MailData
    {
        public DateTime MsgTime;
        public string Sender = string.Empty;
        public string Recipient = string.Empty;
        public string Subject = string.Empty;
        public string Discription = string.Empty;
    }

    public class News
    {
        public string _NewsTopic = String.Empty;
        public string _URL = String.Empty;
        public string _BodyText = String.Empty;
        public string _TimeStamp = string.Empty;
    }
    public class AccountInfo
    {

        public long Account;
        public double Balance;
        public int Leverage;
        public int Group;
        public double FreeMargin;
        public double Margin;
        public double UsedMargin;
        public int HedgingType;
        public double ReservedMargin;
        public double BuySideTurnOver;
        public double SellSideturnOver;
        public int MarginCall1;
        public int MarginCall2;
        public int MarginCall3;
        public string TraderName = string.Empty;
        public string AccountType = string.Empty;
        public double LotSize;
    }
}
