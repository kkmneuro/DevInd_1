////////////////////////////////////////////////REVISION HISTORY////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION                                                                                   //
//05/13/2015	NAMO		1. New class created for Excel data Management                                                //
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO.Pipes;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using NDde.Client;

namespace DataFeederSln.Cls
{
    /// <summary>
    /// This class manages DDE client operations
    /// </summary>
    public class ExceldataHandler
    {
        #region "    Static Fields     "

        // Singleton instance
        private static ExceldataHandler _ExceldataHandler;
        // Queue to manage DDE data

        private static Queue _queue = new Queue();

        #endregion "    Static Fields

        #region "   PRIVATE FIELDS     "

        // lock to restrict concurrent access
        private object _lockObject;

        // Flag for data send operation
        private bool sendToPipe;

        // Flag for data send operation
        private bool sendToMSMQ;

        // Flag for data send operation
        private bool sendToALL;

        DateTime dtStartPoint = DateTime.UtcNow;

        private string _ExcelSheetName = "Sheet1";
        private int _contractColIndex = 0;
        private int _AskColIndex = 0;
        private int _BidColIndex = 0;
        private int _LTPColIndex = 0;
        private int _VolumeColIndex = 0;
        private int _OpenColIndex = 0;
        private int _HighColIndex = 0;
        private int _LowColIndex = 0;
        private int _CloseColIndex = 0;
        private int _AskSizeColIndex = 0;
        private int _BidSizeColIndex = 0;
        Thread threadRowCount = null;
        private bool flag = true;
        public TextBox txtOutput;

        int _rowcount;

        #endregion "     PRIVATE FIELDS      "

        #region "   PUBLIC FIELDS      "

        // Synchronized Queue to manage DDE data
        public Queue _syncDataQueue = Queue.Synchronized(_queue);

        #endregion "     PUBLIC FIELDS      "

        #region "     PROPERTIES       "

        // Singleton exposed instance
        public static ExceldataHandler _ExceldataHandlerInstance
        {
            get { return _ExceldataHandler ?? (_ExceldataHandler = new ExceldataHandler()); }
        }

        // lock to restrict concurrent access
        public object LockObject
        {
            get { return _lockObject ?? (_lockObject = new object()); }
        }

        #endregion "     PROPERTIES       "

        #region "       METHODS        "

        /// <summary>
        ///  private Constructors
        /// </summary>
        private ExceldataHandler()
        {
            try
            {
                dtStartPoint = new System.DateTime(1970, 01, 01, 00, 00, 00);
                _ExcelSheetName = System.Configuration.ConfigurationManager.AppSettings["ExcelSheetName"].ToString();
                int.TryParse(System.Configuration.ConfigurationManager.AppSettings["contractColIndex"].ToString(), out _contractColIndex);
                int.TryParse(System.Configuration.ConfigurationManager.AppSettings["AskColIndex"].ToString(), out _AskColIndex);
                int.TryParse(System.Configuration.ConfigurationManager.AppSettings["BidColIndex"].ToString(), out _BidColIndex);
                int.TryParse(System.Configuration.ConfigurationManager.AppSettings["AskSizeColIndex"].ToString(), out _AskSizeColIndex);
                int.TryParse(System.Configuration.ConfigurationManager.AppSettings["BidSizeColIndex"].ToString(), out _BidSizeColIndex);
                int.TryParse(System.Configuration.ConfigurationManager.AppSettings["LTPColIndex"].ToString(), out _LTPColIndex);
                int.TryParse(System.Configuration.ConfigurationManager.AppSettings["VolumeColIndex"].ToString(), out _VolumeColIndex);
                int.TryParse(System.Configuration.ConfigurationManager.AppSettings["OpenColIndex"].ToString(), out _OpenColIndex);
                int.TryParse(System.Configuration.ConfigurationManager.AppSettings["HighColIndex"].ToString(), out _HighColIndex);
                int.TryParse(System.Configuration.ConfigurationManager.AppSettings["LowColIndex"].ToString(), out _LowColIndex);
                int.TryParse(System.Configuration.ConfigurationManager.AppSettings["CloseColIndex"].ToString(), out _CloseColIndex);

            }
            catch (Exception)
            {

            }

        }

        public void Init(bool _sendToPipe, bool _sendToMSMQ, bool _sendToALL)
        {
            sendToPipe = _sendToPipe;
            sendToMSMQ = _sendToMSMQ;
            sendToALL = _sendToALL;

            threadRowCount = new Thread(getRowCount);
            threadRowCount.IsBackground = true;
            threadRowCount.Start();

            Thread ThreadDataConsumer = new System.Threading.Thread(ThreadHandleDataConsumer);
            ThreadDataConsumer.IsBackground = true;
            ThreadDataConsumer.Start();

            Thread ThreadDataReader = new System.Threading.Thread(ThreadHandleDataReader);
            ThreadDataReader.IsBackground = true;
            ThreadDataReader.Start();
        }

        private void getRowCount()
        {
            try
            {
                if (TheContainer.DdeClient == null)
                {
                    DdeClient client1 = new DdeClient("Excel", _ExcelSheetName, txtOutput);
                    TheContainer.DdeClient = client1;

                    client1.Disconnected += OnClientDisconnected;

                    // Connect to the server.  It must be running or an exception will be thrown.
                    client1.Connect();

                    // Advise Loop

                    flag = true;
                    client1.StartAdvise("C3", 1, true, 60000);
                    client1.Advise += OnRowAdvise;

                }
                else
                {
                    Cls.Global.GlobalInstance.SyncErrorLog("ExceldataHandler >> Excel DDE Client Already Started");
                }
            }
            catch (Exception)
            {
                TheContainer.TheDdeClient = null;
                Cls.Global.GlobalInstance.SyncErrorLog("ExceldataHandler >> An exception was thrown during Excel  DDE connection");
                Cls.Global.GlobalInstance.SyncErrorLog("ExceldataHandler >> Ensure Excell is running.");

            }
        }


        public void Stop()
        {

        }
        private void OnClientDisconnected(object sender, DdeDisconnectedEventArgs args)
        {
            TheContainer.DdeClient = null;
        }
        private void OnRowAdvise(object sender, DdeAdviseEventArgs args)
        {
            if (threadRowCount.IsAlive)
            {
                threadRowCount.Abort();
            }

            if (flag && args.Item.ToString() == "C3")
            {
                if (args.Text.Trim() != "" && args.Text.Contains("\r\n"))
                {
                    string st = args.Text.Replace("\r\n", "+");
                    string[] ColData1 = st.Split('+');
                    _rowcount = ColData1.Length - 1;
                    flag = false;
                }
            }
        }
        /// <summary>
        /// manages the DDE Client
        /// </summary>
        private void ThreadHandleDataReader()
        {
            StartQuotes();
        }


        private void StartQuotes()
        {
            if (TheContainer.TheDdeClient == null)
            {
                try
                {
                    DdeClient client = new DdeClient("Excel", _ExcelSheetName, txtOutput);
                    TheContainer.TheDdeClient = client;

                    // Subscribe to the Disconnected event.  This event will notify the application when a conversation has been terminated.
                    client.Disconnected += OnDisconnected;

                    // Connect to the server.  It must be running or an exception will be thrown.
                    client.Connect();

                    // Advise Loop                 

                    if (_rowcount > 0)
                    {
                        for (int i = 1; i < _rowcount + 1; i++)
                        {
                            client.StartAdvise("R" + i.ToString(), 1, true, 60000);
                        }
                    }


                    client.Advise += OnAdvise;

                    Cls.Global.GlobalInstance.SyncErrorLog("ExceldataHandler >> Excel DDE Client Started");
                }
                catch (Exception ex)
                {
                    Cls.Global.GlobalInstance.SyncErrorLog("ExceldataHandler >> StartQuotes >> " + ex.Message);
                }

            }
            else
            {
                Cls.Global.GlobalInstance.SyncErrorLog("ExceldataHandler >> Excel DDE Client Already Started");
            }

        }

        private void OnDisconnected(object sender, DdeDisconnectedEventArgs args)
        {
            Cls.Global.GlobalInstance.SyncErrorLog("ExceldataHandler >> Excel DDE Client Disconnected");
            TheContainer.TheDdeClient = null;
        }

        private void OnAdvise(object sender, DdeAdviseEventArgs args)
        {
            Cls.Global.GlobalInstance.SyncErrorLog(args.Text);
            _syncDataQueue.Enqueue(args);
        }

        /// <summary>
        /// manages the DDE data
        /// </summary>
        private void ThreadHandleDataConsumer()
        {
            while (true)
            {
                if (_syncDataQueue.Count == 0)
                {
                    Thread.Sleep(10);
                    //this will deflate the queue to size 0..
                    _syncDataQueue.TrimToSize();
                    continue;
                }
                if (_syncDataQueue.Count > 0)
                {
                    DdeAdviseEventArgs msg = (DdeAdviseEventArgs)_syncDataQueue.Dequeue();
                    System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(ThreadPoolHandler), msg);
                    System.Threading.Thread.Sleep(0);
                }
                Thread.Sleep(0);

            }
        }

        /// <summary>
        /// manages the dde data
        /// </summary>
        private void ThreadPoolHandler(object data)
        {
            DdeAdviseEventArgs msg = (DdeAdviseEventArgs)data;
            if (sendToPipe)
            {
                SendFeedToPipe(msg);
            }
            else if (sendToMSMQ)
            {
                SendFeedToMSMQ(msg);
            }
            else
            {
                SendFeedToPipe(msg);
                SendFeedToMSMQ(msg);
            }
       
        }

        private void SendFeedToMSMQ(DdeAdviseEventArgs args)
        {
            try
            {
                if (args.Text.Contains('\t'))
                {
                    string[] str = args.Text.Split('\t');
                    if (str.Length > 5)
                    {
                        if (str[1].Contains(' '))
                        {
                            string[] temp = str[1].Split(' ');
                            string _contract;
                            if (temp[0].Trim().Length > 0 && temp[1].Trim().Length > 7)
                            {
                                _contract = temp[0].Trim() + temp[1].Remove(0, 2).Trim();

                                double _bid = 0;
                                double _ask = 0;
                                double _last = 0;
                                double.TryParse(str[4].Trim(), out _bid);
                                double.TryParse(str[5].Trim(), out _ask);
                                double.TryParse(str[7].Trim(), out _last);

                                DateTime dtFeed = DateTime.UtcNow.AddHours(5.5);

                                string queueMsg = _contract + "," + _bid.ToString() + "/" + (_bid + 1).ToString() + "," + _ask.ToString() + "/" + (_ask + 1).ToString() + "," +
                                        _last.ToString() + "," + dtFeed.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture);
                                SendDataToMSMQ(queueMsg);
                                Cls.Global.GlobalInstance._syncUIQueue.Enqueue(queueMsg);
                                if (Cls.Global.GlobalInstance._dDupSymbolList.ContainsKey(args.Item))
                                {
                                    string queueMsgDup = Cls.Global.GlobalInstance._dDupSymbolList[args.Item.Trim()] + "," + _bid.ToString() + "/" + (_bid + 1).ToString() + "," + _ask.ToString() + "/" + (_ask + 1).ToString() + "," +
                                    ((_bid + _ask) / 2).ToString() + "," + dtFeed.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture);
                                    SendDataToMSMQ(queueMsgDup);
                                    Cls.Global.GlobalInstance._syncUIQueue.Enqueue(queueMsgDup);
                                }

                            }

                        }

                    }

                }
            }
            catch (Exception ex)
            {
                Cls.Global.GlobalInstance.SyncErrorLog("ExceldataHandler >> While sending data to queue: " + ex.Message);
            }
        }

        private void SendFeedToPipe(DdeAdviseEventArgs args)
        {
            try
            {
                if (args.Text.Contains('\t'))
                {
                    string[] str = args.Text.Split('\t');
                    if (str.Length > 5)
                    {
                        if (str[_contractColIndex].Contains(' '))
                        {
                            string[] temp = str[_contractColIndex].Split(' ');

                            if (temp[0].Trim().Length > 0 && temp[1].Trim().Length > 7)
                            {
                                string _contract = temp[0].Trim() + temp[1].Remove(0, 2).Trim();
                                if (_contract.Length <= 20)
                                {
                                    DateTime dtFeed = DateTime.UtcNow;
                                    TimeSpan tsSpan = dtFeed.ToUniversalTime() - dtStartPoint;

                                    MQLTick msObj = new MQLTick();
                                    msObj.date = tsSpan.TotalSeconds;
                                    msObj.contract = _contract;
                                    msObj.productType = Cls.Global.GlobalInstance._dSymbolList[msObj.contract];
                                    msObj.Bid = 0;
                                    msObj.Ask = 0;
                                    msObj.LTP = 0;
                                    msObj.dOpen = 0;
                                    msObj.dHigh = 0;
                                    msObj.dLow = 0;
                                    msObj.dClose = 0;
                                    msObj.dBidSize = 0;
                                    msObj.dAskSize = 0;
                                    msObj.dLastSize = 0;
                                    double.TryParse(str[_BidColIndex].Trim(), out msObj.Bid);
                                    double.TryParse(str[_AskColIndex].Trim(), out msObj.Ask);
                                    double.TryParse(str[_LTPColIndex].Trim(), out msObj.LTP);
                                    double.TryParse(str[_VolumeColIndex].Trim(), out msObj.dLastSize);
                                    double.TryParse(str[_OpenColIndex].Trim(), out msObj.dOpen);
                                    double.TryParse(str[_HighColIndex].Trim(), out msObj.dHigh);
                                    double.TryParse(str[_LowColIndex].Trim(), out msObj.dLow);
                                    double.TryParse(str[_CloseColIndex].Trim(), out msObj.dClose);
                                    double.TryParse(str[_BidSizeColIndex].Trim(), out msObj.dBidSize);
                                    double.TryParse(str[_AskSizeColIndex].Trim(), out msObj.dAskSize);

                                    if (Cls.Global.GlobalInstance._dDupSymbolList.ContainsKey(msObj.contract.Trim()))
                                    {
                                        MQLTick msObjDup = new MQLTick();

                                        msObjDup.contract = Cls.Global.GlobalInstance._dDupSymbolList[msObj.contract.Trim()];
                                        msObjDup.Bid = msObj.Bid;
                                        msObjDup.Ask = msObj.Ask;
                                        msObjDup.date = msObj.date;
                                        msObjDup.productType = msObj.productType;
                                        msObjDup.LTP = msObj.LTP;
                                        msObjDup.dOpen = msObj.dOpen;
                                        msObjDup.dHigh = msObj.dHigh;
                                        msObjDup.dLow = msObj.dLow;
                                        msObjDup.dClose = msObj.dClose;
                                        msObjDup.dBidSize = msObj.dBidSize;
                                        msObjDup.dAskSize = msObj.dAskSize;
                                        msObjDup.dLastSize = msObj.dLastSize;
                                        SendDataToPipe(msObjDup);

                                    }
                                    SendDataToPipe(msObj);

                                }

                            }

                        }

                    }

                }
            }
            catch (Exception ex)
            {
                Cls.Global.GlobalInstance.SyncErrorLog("ExceldataHandler >> While sending data to queue: " + ex.Message);
            }

        }

        private void SendDataToPipe(MQLTick objMQLTick)
        {
            byte[] result = new byte[100];
            result = Cls.Global.GlobalInstance.STRUCTtoBYTESBROKER(objMQLTick, 1);

            lock (LockObject)
            {
                NamedPipeClientStream pipeStream = new NamedPipeClientStream(".", "MT5", PipeDirection.Out, PipeOptions.Asynchronous);
                pipeStream.Connect(1000);

                try
                {
                    pipeStream.BeginWrite(result, 0, result.Length, AsyncSend, pipeStream);
                    string msg = objMQLTick.contract + "," + objMQLTick.productType + "," + objMQLTick.Ask.ToString() + "," + objMQLTick.Bid.ToString() + "," + objMQLTick.dAskSize.ToString() + ","
                            + objMQLTick.dBidSize.ToString() + "," + objMQLTick.dOpen.ToString() + "," + objMQLTick.dHigh.ToString() + "," + objMQLTick.dLow.ToString()
                           + "," + objMQLTick.dClose.ToString() + "," + objMQLTick.LTP.ToString() + "," + objMQLTick.dLastSize.ToString() + "," + objMQLTick.date.ToString();
                    Cls.Global.GlobalInstance.SyncErrorLog(msg);
                }
                catch (Exception ex)
                {
                    Cls.Global.GlobalInstance.SyncErrorLog("ExceldataHandler >> While sending data to queue >> SendDataToPipe() : " + ex.Message);
                }
            }
        }

        
        private void SendDataToMSMQ(string tick)
        {
            lock (LockObject)
            {
                try
                {
                    MessageQueue Q1 = new MessageQueue(Cls.Global.GlobalInstance.QueueName);
                    Q1.Send(tick);
                }
                catch (Exception ex)
                {
                    Cls.Global.GlobalInstance.SyncErrorLog("ExceldataHandler >> While sending data to server: " + ex.Message.ToString());
                }
            }
        }

        private void AsyncSend(IAsyncResult iar)
        {
            try
            {
                // Get the pipe
                NamedPipeClientStream pipeStream = (NamedPipeClientStream)iar.AsyncState;

                // End the write
                pipeStream.EndWrite(iar);
                pipeStream.Flush();
            }
            catch (Exception oEX)
            {
                Debug.WriteLine(oEX.Message);
            }
        }

        #endregion "     METHODS      "
    }
}
