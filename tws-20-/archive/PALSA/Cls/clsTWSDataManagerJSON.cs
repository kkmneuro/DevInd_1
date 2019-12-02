using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.IO;
using System.Collections;
using WebSocket4Net;
using System.Web.Script.Serialization;
using System.Globalization;
using System.Threading;
using System.Data;

namespace TWS.Cls
{
    class clsTWSDataManagerJSON
    {

        #region "    Contant members    "
        //Message Type						   
        const int LOGON_REQUEST = 1;
        const int LOGON_RESPONSE = 2;
        const int LOGOUT_REQUEST = 3;
        const int LOGOUT_RESPONSE = 32;
        const int QUOTES_STREAM = 23;
        const int SNAPSHOT_RESPONSE = 22;
        const int SUBSCRIBE = 28;
        public const string ASK = "A";
        public const string BID = "B";
        public const string LAST = "L";
        public const string VOLUME = "V";
        public const string VOLUME_PER = "P";
        public const string LOW = "M";
        public const string HIGH = "H";
        public const string OPEN = "O";
        public const string CLOSE = "C";
        private const int _MAM_MAX_REQUEST_QTY = 5;
        #endregion "    Contant members    "

        #region "        MEMBERS        "
        WebSocket websocket;
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        private string UserName;
        private string Password;
        private string webSocketHostUrl;
        private static clsTWSDataManagerJSON _instance;
        private static object _lockObject;
        private static Queue _queue = new Queue();
        public Queue _syncJSONQueue = Queue.Synchronized(_queue);
        string logPath = string.Empty;
        public Dictionary<string, Dictionary<uint, DOM>> DicDOM;
        public Dictionary<string, string> _DDMessages = new Dictionary<string, string>();
        private List<int> lstAccount = new List<int>();
        private static Queue _queueRawFeed = new Queue();
        public Queue _syncQueueRawFeed = Queue.Synchronized(_queueRawFeed);
        private System.Timers.Timer timerSocket = new System.Timers.Timer();
        #endregion "      MEMBERS          "

        #region "     PROPERTIES        "

        private clsTWSDataManagerJSON()
        {

            try
            {
                timerSocket.Elapsed += timerSocket_Elapsed;                
                timerSocket.Interval = 60000;

                DicDOM = new Dictionary<string, Dictionary<uint, DOM>>();
                string path = Assembly.GetExecutingAssembly().Location;
                FileInfo fileInfo = new FileInfo(path);
                logPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments) + "\\TWS\\WSMarketLogs\\";
                Thread _logThread = new Thread(ThreadHandleQueue);
                _logThread.IsBackground = true;
                _logThread.Start();
                Thread ThreadRawFeed = new Thread(ThreadHandleRawFeed);
                ThreadRawFeed.IsBackground = true;
                ThreadRawFeed.Start();
            }
            catch (Exception ex)
            {

                _syncJSONQueue.Enqueue("ERROR >> clsTWSDataManagerJSON >> " + ex.Message);
            }

        }

        public static object LockObject
        {
            get
            {
                return _lockObject ?? (_lockObject = new object());
            }
        }

        public static clsTWSDataManagerJSON INSTANCE
        {
            get { return _instance ?? (_instance = new clsTWSDataManagerJSON()); }
        }

        public bool IsOrderMgrLoaded { get; private set; }
        public bool IsDataMgrConnected { get; set; }

        #endregion "     PROPERTIES

        #region "        EVENTS          "

        //public event Action<Dictionary<string, Quote>> onPriceUpdate = delegate { };
        public event Action<QuotesStream> onPriceUpdate = delegate { };
        public event Action<string, string, Dictionary<uint, DOM>> onDOM_Update = delegate { };

        public Action<string, string> OnLogonResponse = delegate { };
        //public event Action<Dictionary<string, QuoteSnapshot>> onSnapShotUpdate = delegate { };
        public event Action<SnapShot> onSnapShotUpdate = delegate { };
        public event Action<List<News>> OnNews = delegate { };
        public event Action<string> OnNewQuoteRequest = delegate { };
        public event Action<string> OnDataServerConnectionEvnt = delegate { };
        public event Action<string> OnSubscribeReuqest = delegate { };
        public event Action<string, double> OnLTPChange = delegate { };
        public event Action<string, double> OnLTPChange2 = delegate { };
        public event Action<string> onMarketPriceUpdate = delegate { };
        public event Action<List<int>> OnNetPositionUpdate = delegate { };
        //public event Action<QuotesStream> OnQuotesStream = delegate { };



        #endregion "   EVENTS       "

        #region "        Methods        "

        public void Init(string username, string pwd, string hostUrl)
        {
            try
            {
                timerSocket.Enabled = true;
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

        internal void Refresh()
        {

        }

        #endregion "      Methods      "

        void websocket_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            try
            {
                _syncQueueRawFeed.Enqueue(e);
            }
            catch (Exception)
            {
            }
        }

        void websocket_Closed(object sender, EventArgs e)
        {
            try
            {
                IsDataMgrConnected = false;
                _syncJSONQueue.Enqueue("CONNECTION CLOSED" + Environment.NewLine);
                OnDataServerConnectionEvnt("DisConnected");
                IsOrderMgrLoaded = false;
                reconnect();
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
                        try
                        {
                            // Logout();
                            websocket.Close();
                            Thread.Sleep(3000);
                        }
                        catch (Exception)
                        {

                        }

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
                //OnOrderServerConnectionEvnt("DisConnected");
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
        void timerSocket_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (websocket.State == WebSocketState.Closed)
            {
                try
                {
                    reconnect();
                }
                catch (Exception)
                {

                }
            }

        }
        void websocket_Opened(object sender, EventArgs e)
        {
            try
            {
                IsDataMgrConnected = true;
                OnDataServerConnectionEvnt("CONNECTED");
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

        private void ThreadHandleRawFeed()
        {
            while (true)
            {
                try
                {
                    if (_syncQueueRawFeed.Count == 0)
                    {
                        Thread.Sleep(10);
                        //this will deflate the queue to size 0..
                        _syncQueueRawFeed.TrimToSize();
                        continue;
                    }
                    if (_syncQueueRawFeed.Count > 0)
                    {

                        MessageReceivedEventArgs _quote = (MessageReceivedEventArgs)_syncQueueRawFeed.Dequeue();
                        ManageRawFeed(_quote);
                    }
                    Thread.Sleep(0);

                }
                catch (Exception)
                {

                }
            }
        }

        private void ManageRawFeed(MessageReceivedEventArgs e)
        {
            try
            {
                _syncJSONQueue.Enqueue("FROM SERVER :" + e.Message + Environment.NewLine);
                SocketResponce _socketResponce = serializer.Deserialize<SocketResponce>(e.Message);
                if (_socketResponce.msgtype == LOGON_RESPONSE)
                {
                    logonResponce collection = serializer.Deserialize<logonResponce>(e.Message);
                    OnLogonResponse(collection.Reason, collection.BrokerName);

                }
                else if (_socketResponce.msgtype == LOGOUT_RESPONSE)
                {

                }
                else if (_socketResponce.msgtype == QUOTES_STREAM)
                {
                    QuotesStream _stream = serializer.Deserialize<QuotesStream>(e.Message);
                    UpdatePrice(_stream);

                }
                else if (_socketResponce.msgtype == SNAPSHOT_RESPONSE)
                {
                    SnapShot _snapshot = serializer.Deserialize<SnapShot>(e.Message);
                    if (_snapshot.islastPck == 0)
                    {
                        updateSnapshot(_snapshot);
                    }
                }
                //else if (_socketResponce.msgtype == NEWS)
                //{
                //}
                else
                {
                    //log(e.Message);
                }
            }
            catch (Exception ex)
            {
                _syncJSONQueue.Enqueue("Error at ManageRawFeed >> " + ex.Message);
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

        public void SubscribeForQuotes(Enum ReqType, List<Symbol> lst)
        {
            try
            {
                if (lst.Count > 0)
                {
                    List<List<Symbol>> _lstSymbols = new List<List<Symbol>>();
                    while (lst.Any())
                    {
                        _lstSymbols.Add(lst.Take(_MAM_MAX_REQUEST_QTY).ToList());
                        lst = lst.Skip(_MAM_MAX_REQUEST_QTY).ToList();
                    }
                    foreach (var itemTemp in _lstSymbols)
                    {
                        SymbolSubscribeRequest SubscribeRequest = new SymbolSubscribeRequest();
                        SubscribeRequest.Symbol = new List<SymbolInfo>();

                        foreach (Symbol item in itemTemp)
                        {
                            SymbolInfo objSymbol = new SymbolInfo();
                            objSymbol.Contract = item.Contract;
                            objSymbol.Gateway = item.Gateway;
                            objSymbol.Product = item.Product;
                            objSymbol.ProductType = '1';//item.ProductType;
                            SubscribeRequest.Symbol.Add(objSymbol);
                        }
                        SubscribeRequest.NoOfSymbols = SubscribeRequest.Symbol.Count;
                        SubscribeRequest.isForSubscribe = (SubscribeRequestType)ReqType;
                        SubscribeRequest.msgtype = SUBSCRIBE;
                        var json = new JavaScriptSerializer().Serialize(SubscribeRequest);
                        websocket.Send(json);
                        _syncJSONQueue.Enqueue("TO SERVER :" + json + Environment.NewLine);
                        //foreach (Symbol item in lst)
                        //{
                        //    OnSubscribeReuqest("// TO DO // ");               ///////////// TO DO ////
                        //}
                    }
                }
                //============================
                //SymbolSubscribeRequest SubscribeRequest = new SymbolSubscribeRequest();
                //SubscribeRequest.Symbol = new List<SymbolInfo>();

                //foreach (Symbol item in lst)
                //{
                //    SymbolInfo objSymbol = new SymbolInfo();
                //    objSymbol.Contract = item.Contract;
                //    objSymbol.Gateway = item.Gateway;
                //    objSymbol.Product = item.Product;
                //    objSymbol.ProductType = '1';//item.ProductType;
                //    SubscribeRequest.Symbol.Add(objSymbol);
                //}
                //SubscribeRequest.NoOfSymbols = SubscribeRequest.Symbol.Count;
                //SubscribeRequest.isForSubscribe = (SubscribeRequestType)ReqType;
                //SubscribeRequest.msgtype = SUBSCRIBE;
                //var json = new JavaScriptSerializer().Serialize(SubscribeRequest);
                //websocket.Send(json);
                //_syncJSONQueue.Enqueue("TO SERVER :" + json + Environment.NewLine);
                //foreach (Symbol item in lst)
                //{
                //    OnSubscribeReuqest("// TO DO // ");               ///////////// TO DO ////
                //}


            }
            catch (Exception ex)
            {
                _syncJSONQueue.Enqueue("ERROR >> Logout >> " + ex.Message);
            }
            //var json = new JavaScriptSerializer().Serialize(objSymbol);




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
        public DateTime GetDateTime(double OAdate)
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
        public void ReloadConfigurationRequest(sbyte config)
        {

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
                        tsw.WriteLine(DateTime.Now.ToString() + " : " + msg + System.Environment.NewLine);
                        tsw.Close();
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                }
                else
                {
                    System.IO.Directory.CreateDirectory(_path);
                    FileStream fsDevelopmentLog = new FileStream(_path + "\\Log.txt", FileMode.OpenOrCreate, FileAccess.Write,
                                                      FileShare.ReadWrite);
                    fsDevelopmentLog.Close();
                    try
                    {
                        TextWriter tsw = new StreamWriter(_path + "\\Log.txt", true);
                        tsw.WriteLine(DateTime.Now.ToString() + " : " + msg + System.Environment.NewLine);
                        tsw.Close();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }
        private void UpdatePrice(QuotesStream _QuotesStream)
        {
            foreach (var quotes in _QuotesStream.QuotesItem)
            {
                try
                {
                    if (ClsTWSContractManager.INSTANCE.ddContractDetails.ContainsKey(quotes.Contract))
                    {
                        InstrumentSpec spec = ClsTWSContractManager.INSTANCE.ddContractDetails[quotes.Contract];
                        double _size = quotes.Size;
                        if (spec != null && spec.ContractSize > 0)
                        {
                            _size = (double)(quotes.Size / spec.ContractSize);
                        }
                        DOM objDOM;
                        if (DicDOM.ContainsKey(quotes.Contract))
                        {
                            if (DicDOM[quotes.Contract].ContainsKey(quotes.MarketLevel))
                            {
                                objDOM = DicDOM[quotes.Contract][quotes.MarketLevel];
                                if (quotes.QuotesStreamType == ASK)
                                {
                                    objDOM.ASK = quotes.Price / Math.Pow(10, spec.Digits);
                                    objDOM.ASK_SIZE = _size;
                                }
                                else if (quotes.QuotesStreamType == BID)
                                {
                                    objDOM.BID = quotes.Price / Math.Pow(10, spec.Digits);
                                    objDOM.BID_SIZE = _size;
                                }
                                DicDOM[quotes.Contract][quotes.MarketLevel] = objDOM;
                            }
                            else
                            {
                                objDOM = new DOM();
                                if (quotes.QuotesStreamType == ASK)
                                {
                                    objDOM.ASK = quotes.Price / Math.Pow(10, spec.Digits);
                                    objDOM.ASK_SIZE = _size;
                                }
                                else if (quotes.QuotesStreamType == BID)
                                {
                                    objDOM.BID = quotes.Price / Math.Pow(10, spec.Digits);
                                    objDOM.BID_SIZE = _size;
                                }
                                DicDOM[quotes.Contract].Add(quotes.MarketLevel, objDOM);
                            }
                        }
                        else
                        {
                            Dictionary<uint, DOM> temp = new Dictionary<uint, DOM>();
                            objDOM = new DOM();
                            if (quotes.QuotesStreamType == ASK)
                            {
                                objDOM.ASK = quotes.Price / Math.Pow(10, spec.Digits);
                                objDOM.ASK_SIZE = _size;
                            }
                            else if (quotes.QuotesStreamType == BID)
                            {
                                objDOM.BID = quotes.Price / Math.Pow(10, spec.Digits);
                                objDOM.BID_SIZE = _size;
                            }
                            temp.Add(quotes.MarketLevel, objDOM);
                            DicDOM.Add(quotes.Contract, temp);
                        }
                        if (DicDOM.ContainsKey(quotes.Contract))
                        {
                            onDOM_Update(quotes.QuotesStreamType, quotes.Contract, DicDOM[quotes.Contract]);
                        }
                        if (quotes.MarketLevel >= 1)
                            continue;
                        switch (quotes.QuotesStreamType)
                        {
                            case "A":
                                {
                                    if (ClsGlobal.DDRightZLevel.Keys.Contains(quotes.Contract))
                                    {
                                        ClsGlobal.DDRightZLevel[quotes.Contract] = quotes.Price / Math.Pow(10, spec.Digits);
                                    }
                                    else
                                    {
                                        ClsGlobal.DDRightZLevel.Add(quotes.Contract, quotes.Price / Math.Pow(10, spec.Digits));
                                    }
                                }
                                OnLTPChange(quotes.Contract, quotes.Price / Math.Pow(10, spec.Digits));
                                break;
                            case "B":
                                {
                                    if (ClsGlobal.DDLeftZLevel.Keys.Contains(quotes.Contract))
                                    {
                                        ClsGlobal.DDLeftZLevel[quotes.Contract] = quotes.Price / Math.Pow(10, spec.Digits);
                                    }
                                    else
                                    {
                                        ClsGlobal.DDLeftZLevel.Add(quotes.Contract, quotes.Price / Math.Pow(10, spec.Digits));
                                    }
                                }
                                break;
                            case "L":
                                {
                                    if (ClsGlobal.DDLTP.Keys.Contains(quotes.Contract))
                                    {
                                        ClsGlobal.DDLTP[quotes.Contract] = quotes.Price / Math.Pow(10, spec.Digits);
                                    }
                                    else
                                    {
                                        ClsGlobal.DDLTP.Add(quotes.Contract, quotes.Price / Math.Pow(10, spec.Digits));
                                    }
                                    if (ClsGlobal.DDVolume.Keys.Contains(quotes.Contract))
                                    {
                                        ClsGlobal.DDVolume[quotes.Contract] = Convert.ToInt32(_size);
                                    }
                                    else
                                    {
                                        ClsGlobal.DDVolume.Add(quotes.Contract, Convert.ToInt32(_size));
                                    }
                                    OnLTPChange2(quotes.Contract, quotes.Price / Math.Pow(10, spec.Digits));
                                }
                                break;
                            case "O":
                                {
                                    if (ClsGlobal.DDOpen.Keys.Contains(quotes.Contract))
                                    {
                                        ClsGlobal.DDOpen[quotes.Contract] = quotes.Price / Math.Pow(10, spec.Digits);
                                    }
                                    else
                                    {
                                        ClsGlobal.DDOpen.Add(quotes.Contract, quotes.Price / Math.Pow(10, spec.Digits));
                                    }
                                }
                                break;
                            case "H":
                                {
                                    if (ClsGlobal.DDHigh.Keys.Contains(quotes.Contract))
                                    {
                                        ClsGlobal.DDHigh[quotes.Contract] = quotes.Price / Math.Pow(10, spec.Digits);
                                    }
                                    else
                                    {
                                        ClsGlobal.DDHigh.Add(quotes.Contract, quotes.Price / Math.Pow(10, spec.Digits));
                                    }
                                }
                                break;
                            case "M":
                                {
                                    if (ClsGlobal.DDLow.Keys.Contains(quotes.Contract))
                                    {
                                        ClsGlobal.DDLow[quotes.Contract] = quotes.Price / Math.Pow(10, spec.Digits);
                                    }
                                    else
                                    {
                                        ClsGlobal.DDLow.Add(quotes.Contract, quotes.Price / Math.Pow(10, spec.Digits));
                                    }
                                }
                                break;
                            case "C":
                                {
                                    if (ClsGlobal.DDClose.Keys.Contains(quotes.Contract))
                                    {
                                        ClsGlobal.DDClose[quotes.Contract] = quotes.Price / Math.Pow(10, spec.Digits);
                                    }
                                    else
                                    {
                                        ClsGlobal.DDClose.Add(quotes.Contract, quotes.Price / Math.Pow(10, spec.Digits));
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                        if (quotes.MarketLevel == 0)
                        {
                            onMarketPriceUpdate(quotes.Contract);
                            if (quotes.QuotesStreamType == LAST)
                            {
                                updateNetPostion(quotes.Contract, quotes.Price / Math.Pow(10, spec.Digits));
                            }

                        }

                    }


                }
                catch (Exception)
                {

                }
            }
            onPriceUpdate(_QuotesStream);
        }

        private void updateNetPostion(string ContractName, double _price)
        {
            try
            {
                if (Monitor.TryEnter(clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition, 1000))
                {
                    try
                    {
                        DataRow[] rws = null;
                        if (clsTWSOrderManagerJSON.INSTANCE.netpositionDS != null)
                            rws = clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Select("Contract = '" + ContractName + "'");

                        if (rws.Length > 0)
                        {
                            lstAccount.Clear();
                            foreach (DataRow rw in rws)
                            {
                                int AccountId = 0;
                                int BuyQty = 0;
                                int SellQty = 0;
                                string AccountNo = rw["AccountNo"].ToString().Trim();
                                double sellAvg = 0;
                                double buyAvg = 0;
                                double.TryParse(rw["SellAvg"].ToString().Trim(), out sellAvg);
                                double.TryParse(rw["BuyAvg"].ToString().Trim(), out buyAvg);
                                int.TryParse(rw["BuyQty"].ToString().Trim(), out BuyQty);
                                int.TryParse(rw["SellQty"].ToString().Trim(), out SellQty);
                                int.TryParse(AccountNo, out AccountId);
                                double price = _price;
                                if (!lstAccount.Contains(AccountId))
                                {
                                    lstAccount.Add(AccountId);
                                }

                                if (BuyQty > 0)
                                {
                                    if (Convert.ToDouble(ClsGlobal.GetZeroLevelBidPrice(rw["Contract"].ToString())) > 0)
                                    {
                                        if (rw["ProductType"].ToString().ToUpper() == "FUTURE")
                                        {
                                            rw["UR_PL"] = Math.Round(BuyQty * (price - buyAvg) * ClsGlobal.DDContractSize[rw["Contract"].ToString()], 2);
                                        }
                                        else if (rw["ProductType"].ToString().ToUpper() == "FOREX")
                                        {
                                            rw["UR_PL"] = Math.Round(BuyQty * (price - buyAvg) * ClsGlobal.DDContractSize[rw["Contract"].ToString()] * TWS.Cls.ClsGlobal.DDConversion[rw["Contract"].ToString()], 2);
                                        }
                                    }
                                }
                                else if (SellQty > 0)
                                {
                                    if (Convert.ToDouble(ClsGlobal.GetZeroLevelAskPrice(rw["Contract"].ToString())) > 0)
                                    {
                                        if (rw["ProductType"].ToString().ToUpper() == "FUTURE")
                                        {
                                            rw["UR_PL"] = Math.Round(SellQty * (sellAvg - price) * ClsGlobal.DDContractSize[rw["Contract"].ToString()], 2);
                                        }
                                        else if (rw["ProductType"].ToString().ToUpper() == "FOREX")
                                        {
                                            rw["UR_PL"] = Math.Round(SellQty * (sellAvg - price) * ClsGlobal.DDContractSize[rw["Contract"].ToString()] * TWS.Cls.ClsGlobal.DDConversion[rw["Contract"].ToString()], 2);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch
                    {
                    }
                    finally
                    {
                        Monitor.Exit(clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition);
                    }
                }
                if (lstAccount.Count > 0)
                {
                    OnNetPositionUpdate(lstAccount);
                }
            }
            catch
            {
            }
        }

        private void updateSnapshot(SnapShot _snapshot)
        {
            foreach (var item in _snapshot.OHLC)
            {
                try
                {
                    if (ClsTWSContractManager.INSTANCE.ddContractDetails.ContainsKey(item.Contract))
                    {
                        InstrumentSpec spec = ClsTWSContractManager.INSTANCE.ddContractDetails[item.Contract];
                        int vol = (int)item.Volume;
                        if (spec != null && spec.ContractSize > 0)
                        {
                            vol = (int)(item.Volume / spec.ContractSize);
                        }

                        if (ClsGlobal.DDLTP.Keys.Contains(item.Contract))
                        {
                            ClsGlobal.DDLTP[item.Contract] = item.LastPrice / Math.Pow(10, spec.Digits);
                        }
                        else
                        {
                            ClsGlobal.DDLTP.Add(item.Contract, item.LastPrice / Math.Pow(10, spec.Digits));
                        }
                        OnLTPChange2(item.Contract, item.LastPrice / Math.Pow(10, spec.Digits));
                        if (ClsGlobal.DDOpen.Keys.Contains(item.Contract))
                            ClsGlobal.DDOpen[item.Contract] = item.Open / Math.Pow(10, spec.Digits);
                        else
                            ClsGlobal.DDOpen.Add(item.Contract, item.Open / Math.Pow(10, spec.Digits));
                        if (ClsGlobal.DDLow.Keys.Contains(item.Contract))
                            ClsGlobal.DDLow[item.Contract] = item.Low / Math.Pow(10, spec.Digits);
                        else
                            ClsGlobal.DDLow.Add(item.Contract, item.Low / Math.Pow(10, spec.Digits));
                        if (ClsGlobal.DDClose.Keys.Contains(item.Contract))
                            ClsGlobal.DDClose[item.Contract] = item.Close / Math.Pow(10, spec.Digits);
                        else
                            ClsGlobal.DDClose.Add(item.Contract, item.Close / Math.Pow(10, spec.Digits));
                        if (ClsGlobal.DDHigh.Keys.Contains(item.Contract))
                            ClsGlobal.DDHigh[item.Contract] = item.High / Math.Pow(10, spec.Digits);
                        else
                            ClsGlobal.DDHigh.Add(item.Contract, item.High / Math.Pow(10, spec.Digits));
                        if (ClsGlobal.DDVolume.Keys.Contains(item.Contract))
                            ClsGlobal.DDVolume[item.Contract] = vol;
                        else
                            ClsGlobal.DDVolume.Add(item.Contract, vol);
                        ClsGlobal.Log("Snap shot Update => Contract Name : " + item.Contract + ", CTP Price : " + item.LastPrice.ToString() + ", OPEN Price : " +
                          item.Open.ToString() + ", LOW Price : " + item.Low.ToString() + ", CLOSE Price : " + item.Close.ToString() + ", HIGH Price : " + item.High.ToString() +
                          ", VOLUME : " + item.Volume.ToString() + ", Level = 0");

                        if (item.MarketDepth.Count > 0)
                        {
                            for (int i = 0; i < item.MarketDepth.Count; i++)
                            {
                                var itm = item.MarketDepth[i];

                                DOM objDOM;
                                if (DicDOM.ContainsKey(item.Contract))
                                {
                                    if (DicDOM[item.Contract].ContainsKey((uint)i))
                                    {
                                        objDOM = DicDOM[item.Contract][(uint)i];
                                        objDOM.ASK = itm.AskPrice / Math.Pow(10, spec.Digits);
                                        objDOM.BID = itm.BidPrice / Math.Pow(10, spec.Digits);
                                        objDOM.ASK_SIZE = (double)(itm.AskSize / spec.ContractSize);
                                        objDOM.BID_SIZE = (double)(itm.BidSize / spec.ContractSize);

                                        DicDOM[item.Contract][(uint)i] = objDOM;
                                    }
                                    else
                                    {
                                        objDOM = new DOM();
                                        objDOM.ASK = itm.AskPrice / Math.Pow(10, spec.Digits);
                                        objDOM.BID = itm.BidPrice / Math.Pow(10, spec.Digits);
                                        objDOM.ASK_SIZE = (double)(itm.AskSize / spec.ContractSize);
                                        objDOM.BID_SIZE = (double)(itm.BidSize / spec.ContractSize);
                                        DicDOM[item.Contract].Add((uint)i, objDOM);
                                    }
                                }
                                else
                                {
                                    Dictionary<uint, DOM> temp = new Dictionary<uint, DOM>();
                                    objDOM = new DOM();
                                    objDOM.ASK = itm.AskPrice / Math.Pow(10, spec.Digits);
                                    objDOM.BID = itm.BidPrice / Math.Pow(10, spec.Digits);
                                    objDOM.ASK_SIZE = (double)(itm.AskSize / spec.ContractSize);
                                    objDOM.BID_SIZE = (double)(itm.BidSize / spec.ContractSize);
                                    temp.Add((uint)i, objDOM);
                                    DicDOM.Add(item.Contract, temp);
                                }

                                ClsGlobal.Log("Snap shot Update for Market Depth => Contract Name : " + item.Contract + ", BID Price : " + itm.BidPrice.ToString() + ", BID Qty : " + itm.BidSize.ToString()
                                       + ", SELL Price : " + itm.AskPrice.ToString() + ", SELL Qty : " + itm.AskSize.ToString() + ", Level = " + itm.Level.ToString());
                            }

                            MarketDepthItem item1 = item.MarketDepth[0];

                            if (ClsGlobal.DDLeftZLevel.Keys.Contains(item.Contract))
                                ClsGlobal.DDLeftZLevel[item.Contract] = item1.BidPrice / Math.Pow(10, spec.Digits);
                            else
                                ClsGlobal.DDLeftZLevel.Add(item.Contract, item1.BidPrice / Math.Pow(10, spec.Digits));
                            if (ClsGlobal.DDLeftZLevelQty.Keys.Contains(item.Contract))
                            {
                                ClsGlobal.DDLeftZLevelQty[item.Contract] = (int)(item1.BidSize / spec.ContractSize);
                            }
                            else
                                ClsGlobal.DDLeftZLevelQty.Add(item.Contract, (int)(item1.BidSize / spec.ContractSize));

                            if (ClsGlobal.DDRightZLevelQty.Keys.Contains(item.Contract))
                                ClsGlobal.DDRightZLevelQty[item.Contract] = (int)(item1.AskSize / spec.ContractSize);
                            else
                                ClsGlobal.DDRightZLevelQty.Add(item.Contract, (int)(item1.AskSize / spec.ContractSize));

                            if (ClsGlobal.DDRightZLevel.Keys.Contains(item.Contract))
                                ClsGlobal.DDRightZLevel[item.Contract] = item1.AskPrice / Math.Pow(10, spec.Digits);
                            else
                                ClsGlobal.DDRightZLevel.Add(item.Contract, item1.AskPrice / Math.Pow(10, spec.Digits));
                            OnLTPChange(item.Contract, item1.AskPrice / Math.Pow(10, spec.Digits));
                        }
                    }
                }
                catch (Exception)
                {

                }
            }
            onSnapShotUpdate(_snapshot);
        }

    }



    public class SnapShot
    {
        public double NoOfSymbols;
        public List<QuoteSnapShot> OHLC;
        public uint islastPck;
        public int msgtype;
    }

    public class QuoteSnapShot
    {
        public double Close;
        public string Contract;
        public string Gateway;
        public double High;
        public double LastPrice;
        public uint LastSize;
        public double LastTime;
        public double LastUpdatedTime;
        public double Low;
        public double Open;
        public uint MarketDepthLevel;
        public string Product;
        public string ProductType;
        public string UserName;
        public uint Volume;
        public double WeeksHigh52;
        public double WeeksLow52;
        public List<MarketDepthItem> MarketDepth;
    }


    public class QuotesStream
    {
        public int NoOfSymbols;
        public int msgtype;
        public int islastPck;
        public List<Quote> QuotesItem;
    }

    public class Quote
    {
        public string Contract;
        public string Gateway;
        public string Product;
        public string ProductType;
        public string QuotesStreamType;
        public uint MarketLevel;
        public double Price;
        public long Size;
        public string Time;
        public string UserName;
    }

    public class MarketDepthItem
    {
        public uint Level;
        public double BidPrice;
        public double AskPrice;
        public uint BidSize;
        public uint AskSize;
        public string BidTime;
        public string AskTime;
    }
    public class InstrumentSpec
    {
        public string ProductType = string.Empty;
        public string Product = string.Empty;
        public string Contract = string.Empty;
        public string Gateway = string.Empty;
        public string reserved = string.Empty;
        public string Information = string.Empty;
        public string UL_Asset = string.Empty;
        public string TradingCurrency = string.Empty;
        public string SettlingCurrency = string.Empty;
        public string DeliveryUnit = string.Empty;
        public string DeliveryQuantity = string.Empty;
        public string Percentage = string.Empty;
        public string Specification = string.Empty;
        public string DeliveryType = string.Empty;
        public string ExpiryDate = string.Empty;
        public int MarketLot;
        public int PriceTick;
        public int PriceNumerator;
        public int PriceDenominator;
        public int GeneralNumerator;
        public int GeneralDenominator;
        public int PriceQuantity;
        public int InitialBuyMargin;
        public int InitialSellMargin;
        public int OtherBuyMargin;
        public int OtherSellMargin;
        public int MaxOrderSize;// (In Lots)
        public int MaxOrderValue;
        public int MinDPR;
        public int MaxDPR;
        public int Digits;
        public int MarginCurrency;
        public int MaximumLotsForIE;
        public int Orders;
        public int SpreadByDefault;
        public int BuySideTurnover;
        public int SellSideTurnover;
        public int MaximumAllowablePosition;
        public int QuotationBaseValue;
        public string StartDate = string.Empty;
        public string EndDate = string.Empty;
        public string TenderStartDate = string.Empty;
        public string TenderEndDate = string.Empty;
        public string DeliveryStartDate = string.Empty;
        public string DeliveryEndDate = string.Empty;
        public int Charges;
        public float DPRInitialPercentage;
        public int DPRIntervalSecs;
        public int Limit_Stop_Level;
        public int SpreadBalance;
        public int FreezeLevel;
        public int ContractSize;
        public int Hedged;
        public int TickSize;
        public int MarginCall1;
        public int MarginCall2;
        public int MarginCall3;
        public int LongPositions;
        public int ShortPositions;


    }
    [Serializable]
    public class Symbol
    {
        public const string _Seperator = "_";
        public string Contract = string.Empty;
        public string Product = string.Empty;
        public string ProductType = string.Empty;
        public string Gateway = string.Empty;
        public Quote QuotesItem = null;
        /// <summary>
        /// KEY = GATEWAY_PRODUCTTYPE_PRODUCT_CONTRACT
        /// </summary>
        public string KEY
        {
            get
            {

                return
                        Gateway + _Seperator + GetProductTypeinChar(ProductType).ToString() + _Seperator +
                       Product + _Seperator +
                       Contract;
            }
        }
        public static List<string> getKey(InstrumentSpec spec)
        {

            List<string> _lstKey = new List<string>();
            if (spec != null)
            {
                string gateways = string.Empty;
                gateways = spec.Gateway;
                List<string> arr = new List<string>();
                if (spec.Gateway.Contains(','))
                {
                    arr.AddRange(gateways.Split(','));
                }
                if (spec.Gateway.Contains('_'))
                {
                    arr.AddRange(gateways.Split('_'));
                }
                if (arr.Count == 0)
                {

                    _lstKey.Add(gateways + _Seperator + GetProductTypeinChar(spec.ProductType).ToString() + _Seperator +
                               spec.Product + _Seperator +
                               spec.Contract);
                }
                else
                {
                    for (int i = 0; i < arr.Count; i++)
                    {
                        _lstKey.Add(arr[i] + _Seperator + GetProductTypeinChar(spec.ProductType).ToString() + _Seperator +
                               spec.Product + _Seperator +
                               spec.Contract);
                    }
                }
                return _lstKey;

            }
            else
                return _lstKey;
        }
        /// <summary>
        /// To get the symbol object from key
        /// </summary>
        /// <param name="key"> PROVIDER_EXCHANGE_PRODUCTTYPE_PRODUCT_CONTRACT OR PRODUCTTYPE_PRODUCT_CONTRACT</param>
        /// <returns></returns>
        public static Symbol GetSymbol(string key)
        {
            Symbol sym = null;
            if (key != string.Empty)
            {
                sym = new Symbol();
                string[] arr = key.Split(new string[] { _Seperator }, StringSplitOptions.RemoveEmptyEntries);

                sym.Gateway = arr[0];
                sym.ProductType = getProductTypeInString(arr[1].ToCharArray()[0]);
                sym.Product = arr[2];
                sym.Contract = arr[3];
            }
            return sym;
        }
        public static string getProductTypeInString(char ProductType)
        {
            product prd = (product)ProductType;
            return prd.ToString();
        }
        public static char GetProductTypeinChar(string strProductType)
        {
            try
            {
                return (char)((product)Enum.Parse(typeof(product), strProductType, true));
            }
            catch
            {
                return (char)product.AUCTION;

            }
        }

    }
    [Serializable]
    public class SymbolInfo
    {

        public string Contract = string.Empty;
        public char ProductType = '0';
        public string Product = string.Empty;
        public string Gateway = string.Empty;
    }
    public enum product : int
    {
        FUTURE = '1',
        OPTION = '2',
        EQUITY = '3',
        SPOT = '4',
        BOND = '5',
        FOREX = '0',
        PHYSICAL = '6',
        AUCTION = '7',
        INDEXES = '8',
        CFD = '9',
    }
}

