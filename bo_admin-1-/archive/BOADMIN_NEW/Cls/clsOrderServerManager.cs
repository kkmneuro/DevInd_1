//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Threading;
//using System.Windows.Forms;
//using System.Web.Script.Serialization;
//using System.Collections;
//using WebSocket4Net;
//using System.Timers;
//using System.Globalization;
//using System.Reflection;
//using System.IO;

//namespace BOADMIN_NEW.Cls
//{
//    class clsOrderServerManager
//    {

//        #region "    Contant members    "
//        //Message Type						   
//        const int LOGON_REQUEST = 1;
//        const int LOGON_RESPONSE = 2;
//        const int LOGOUT_REQUEST = 3;
//        const int LOGOUT_RESPONSE = 32;
//        #endregion "    Contant members    "

//        #region "        MEMBERS        "

//        private static clsOrderServerManager _instance;
//        WebSocket websocket;
//        JavaScriptSerializer serializer = new JavaScriptSerializer();
//        private string UserName;
//        private string Password;
//        private string webSocketHostUrl;
//        private static object _lockObject;
//        private static Queue _queue = new Queue();
//        public Queue _syncJSONQueue = Queue.Synchronized(_queue);
//        private static Queue _queueOrders = new Queue();
//        public Queue _syncOrderQueue = Queue.Synchronized(_queueOrders);
//        string logPath = string.Empty;

//        #endregion "      MEMBERS          "

//        #region "     PROPERTIES        "

//        private clsOrderServerManager()
//        {

//            try
//            {
//                string path = Assembly.GetExecutingAssembly().Location;
//                FileInfo fileInfo = new FileInfo(path);

//                logPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\BOC&S\\WebSocketLogs\\";
//                Thread ThreadLog = new System.Threading.Thread(ThreadHandleQueue);
//                ThreadLog.IsBackground = true;
//                ThreadLog.Start();

//            }
//            catch (Exception)
//            {

//                _syncJSONQueue.Enqueue("ERROR >> clsOrderServerManager >> " + ex.Message);
//            }

//        }

//        public static object LockObject
//        {
//            get
//            {
//                return _lockObject ?? (_lockObject = new object());
//            }
//        }

//        public static clsOrderServerManager INSTANCE
//        {
//            get { return _instance ?? (_instance = new clsOrderServerManager()); }
//        }

//        #endregion "     PROPERTIES

//        #region "       EVENTS          "


//        public event Action<string, string, bool> OnLogonResponse = delegate { };
//        public event Action<string> OnOrderServerConnectionEvnt = delegate { };

//        #endregion

//        #region "        Methods        "

//        public void Init(string username, string pwd, string hostUrl)
//        {
//            try
//            {
//                if (websocket != null && websocket.State == WebSocketState.Open)
//                {
//                    websocket.Close();
//                    websocket = null;
//                }
//                UserName = username.Trim();
//                Password = pwd.Trim();
//                webSocketHostUrl = hostUrl;
//                websocket = new WebSocket(hostUrl.Trim());
//                websocket.Opened -= websocket_Opened;
//                websocket.Error -= websocket_Error;
//                websocket.Closed -= websocket_Closed;
//                websocket.MessageReceived -= websocket_MessageReceived;
//                websocket.EnableAutoSendPing = false;
//                websocket.Opened += websocket_Opened;
//                websocket.Error += websocket_Error;
//                websocket.Closed += websocket_Closed;
//                websocket.MessageReceived += websocket_MessageReceived;
//                websocket.Open();
//            }
//            catch (Exception)
//            {
//                _syncJSONQueue.Enqueue("ERROR >> Init >> " + ex.Message);
//            }

//        }

//        public void DisconnectOrderServer()
//        {
//            if (websocket != null)
//            {
//                if (websocket.State == WebSocketState.Open)
//                {
//                    websocket.Close();
//                }
//                websocket = null;
//            }
//        }


//        #endregion "      Methods      "



//        void websocket_MessageReceived(object sender, MessageReceivedEventArgs e)
//        {
//            try
//            {
//                _syncJSONQueue.Enqueue("FROM SERVER :" + e.Message + Environment.NewLine);
//                SocketResponce _socketResponce = serializer.Deserialize<SocketResponce>(e.Message);

//                if (_socketResponce.msgtype == LOGON_RESPONSE)
//                {
//                    logonResponce collection = serializer.Deserialize<logonResponce>(e.Message);
//                    if (collection.Reason == "VALID")
//                    {
//                        _syncJSONQueue.Enqueue("Order Server : ConnectionStatus Connected");
//                    }
//                    else
//                    {
//                        _syncJSONQueue.Enqueue("Order Server : ConnectionStatus DisConnected");
//                    }

//                }
//                else if (_socketResponce.msgtype == LOGOUT_RESPONSE)
//                {


//                }
//                else
//                {
//                    //log(e.Message);
//                }


//            }
//            catch (Exception)
//            {
//                _syncJSONQueue.Enqueue("Error at websocket_MessageReceived >> " + ex.Message);
//            }

//        }

//        void websocket_Closed(object sender, EventArgs e)
//        {
//            try
//            {
//                _syncJSONQueue.Enqueue("CONNECTION CLOSED" + Environment.NewLine);
//                OnOrderServerConnectionEvnt("DisConnected");
//                //  recponnect();
//            }
//            catch (Exception)
//            {

//                _syncJSONQueue.Enqueue("ERROR >> websocket_Closed >> " + ex.Message);
//            }

//        }

//        void reconnect()
//        {
//            try
//            {
//                if (websocket != null)
//                {
//                    if (websocket.State == WebSocketState.Open)
//                    {
//                        websocket.Close();
//                    }
//                    websocket = null;
//                }
//                websocket = new WebSocket(webSocketHostUrl);
//                websocket.Opened -= websocket_Opened;
//                websocket.Error -= websocket_Error;
//                websocket.Closed -= websocket_Closed;
//                websocket.MessageReceived -= websocket_MessageReceived;
//                websocket.EnableAutoSendPing = false;
//                websocket.Opened += websocket_Opened;
//                websocket.Error += websocket_Error;
//                websocket.Closed += websocket_Closed;
//                websocket.MessageReceived += websocket_MessageReceived;
//                websocket.Open();
//            }
//            catch (Exception)
//            {

//                _syncJSONQueue.Enqueue("ERROR >> reconnect >> " + ex.Message);
//            }
//        }
//        void websocket_Error(object sender, SuperSocket.ClientEngine.ErrorEventArgs e)
//        {
//            try
//            {
//                _syncJSONQueue.Enqueue("websocket_Error >> " + e.Exception + Environment.NewLine);
//                OnOrderServerConnectionEvnt("DisConnected");
//                if (websocket.State != WebSocketState.Open)
//                {
//                    //recponnect();
//                }
//            }
//            catch (Exception)
//            {
//                _syncJSONQueue.Enqueue("ERROR >> websocket_Error >> " + ex.Message);
//            }

//        }

//        void websocket_Opened(object sender, EventArgs e)
//        {
//            try
//            {
//                _syncJSONQueue.Enqueue("CONNECTION OPENED" + Environment.NewLine);
//                userDetails objUser = new userDetails();
//                objUser.UserName = UserName;
//                objUser.Password = Password;
//                objUser.SenderID = "2";
//                objUser.Version = 1.15;
//                objUser.msgtype = LOGON_REQUEST;

//                var json = new JavaScriptSerializer().Serialize(objUser);
//                websocket.Send(json);
//                _syncJSONQueue.Enqueue("TO SERVER :" + json + Environment.NewLine);
//            }
//            catch (Exception)
//            {
//                _syncJSONQueue.Enqueue("ERROR >> websocket_Opened >> " + ex.Message);
//            }

//        }

//        public void Logout()
//        {
//            try
//            {
//                _syncJSONQueue.Enqueue("CONNECTION OPENED" + Environment.NewLine);
//                LogoutRequest objUser = new LogoutRequest();
//                objUser.UserName = UserName;
//                objUser.msgtype = LOGOUT_REQUEST;

//                var json = new JavaScriptSerializer().Serialize(objUser);
//                websocket.Send(json);
//                _syncJSONQueue.Enqueue("TO SERVER :" + json + Environment.NewLine);
//            }
//            catch (Exception)
//            {
//                _syncJSONQueue.Enqueue("ERROR >> Logout >> " + ex.Message);
//            }
//        }

//        public void ReloadDPRrange(string ProductType, string Product, string Contract, string Gateway)
//        {
//            try
//            {
//                ReloadDPR objReloadDPR = new ReloadDPR();
//                objReloadDPR.ProductType = ProductType;
//                objReloadDPR.Product = Product;
//                objReloadDPR.Contract = Contract;
//                objReloadDPR.Gateway = Gateway;
//                var json = new JavaScriptSerializer().Serialize(objReloadDPR);
//                websocket.Send(json);

//                _syncJSONQueue.Enqueue("TO SERVER :" + json + Environment.NewLine);
//            }
//            catch (Exception)
//            {
//                _syncJSONQueue.Enqueue("ERROR >> ReloadDPRrange >> " + ex.Message);
//            }

//        }


//        private void ThreadHandleQueue()
//        {
//            while (true)
//            {

//                if (_syncJSONQueue.Count == 0)
//                {
//                    Thread.Sleep(10);
//                    //this will deflate the queue to size 0..
//                    _syncJSONQueue.TrimToSize();
//                    continue;
//                }
//                if (_syncJSONQueue.Count > 0)
//                {
//                    string msg = (string)_syncJSONQueue.Dequeue();
//                    log(msg);
//                }
//                Thread.Sleep(0);

//            }
//        }

//        /// <summary>
//        /// This method creates the log 
//        /// </summary>
//        /// <param name="msg">message to write in log file</param>
//        /// <param name="path">path of the log file</param>
//        private void log(string msg)
//        {
//            lock (LockObject)  // all other threads will wait for y
//            {
//                string _path = logPath + "Log_" + DateTime.Now.ToString("dd_MM_yyyy");
//                if (File.Exists(_path + "\\Log.txt"))
//                {
//                    try
//                    {
//                        TextWriter tsw = new StreamWriter(_path + "\\Log.txt", true);
//                        tsw.WriteLine(DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt") + " : " + msg + System.Environment.NewLine);
//                        tsw.Close();
//                    }
//                    catch (Exception)
//                    {
//                        throw;
//                    }

//                }
//                else
//                {
//                    System.IO.Directory.CreateDirectory(_path);
//                    FileStream fsDevelopmentLog = new FileStream(_path + "\\Log.txt", FileMode.OpenOrCreate, FileAccess.Write,
//                                                      FileShare.ReadWrite);
//                    fsDevelopmentLog.Close();
//                    try
//                    {
//                        TextWriter tsw = new StreamWriter(_path + "\\Log.txt", true);
//                        tsw.WriteLine(DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt") + " : " + msg + System.Environment.NewLine);
//                        tsw.Close();
//                    }
//                    catch (Exception)
//                    {
//                        throw;
//                    }
//                }
//            }
//        }
//    }
    
//    public struct SocketResponce
//    {
//        public int msgtype;
//    };

//    public struct logonResponce
//    {
//        public string AccountType;
//        public string BrokerName;
//        public int IsLive;
//        public string Reason;
//        public int msgtype;
//    };

//    public struct userDetails
//    {
//        public string UserName;
//        public string Password;
//        public double Version;
//        public string SenderID;
//        public int msgtype;
//    };

//    public struct LogoutRequest
//    {
//        public string UserName;
//        public int msgtype;
//    };

//    public struct ReloadDPR
//    {
//        public string ProductType;
//        public string Product;
//        public string Contract;
//        public string Gateway;
//    };


//}
