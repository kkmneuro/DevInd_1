////////////////////////////////////////////////REVISION HISTORY////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION                                                                                   //
//05/13/2015	NAMO		1. New class created for DDE operations                                                       //
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading;
using NDde.Client;
using System.Messaging;
using System.Globalization;
using System.IO.Pipes;
using System.Diagnostics;

namespace DataFeederSln.Cls
{
    /// <summary>
    /// This class manages DDE client operations
    /// </summary>
    public class DDEdataHandler
    {
        #region "    Static Fields     "

        // Singleton instance
        private static DDEdataHandler _DDEdataHandler;
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

        #endregion "     PRIVATE FIELDS      "

        #region "   PUBLIC FIELDS      "

        // Synchronized Queue to manage DDE data
        public Queue _syncDataQueue = Queue.Synchronized(_queue);

        #endregion "     PUBLIC FIELDS      "

        #region "     PROPERTIES       "

        // Singleton exposed instance
        public static DDEdataHandler _DDEdataHandlerInstance
        {
            get { return _DDEdataHandler ?? (_DDEdataHandler = new DDEdataHandler()); }
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
        private DDEdataHandler()
        {
            dtStartPoint = new System.DateTime(1970, 01, 01, 00, 00, 00);
        }

        public void Init(bool _sendToPipe, bool _sendToMSMQ, bool _sendToALL)
        {
            sendToPipe = _sendToPipe;
            sendToMSMQ = _sendToMSMQ;
            sendToALL = _sendToALL;
            Thread ThreadDataConsumer = new System.Threading.Thread(ThreadHandleDataConsumer);
            ThreadDataConsumer.IsBackground = true;
            ThreadDataConsumer.Start();
            Thread ThreadDataReader = new System.Threading.Thread(ThreadHandleDataReader);
            ThreadDataReader.IsBackground = true;
            ThreadDataReader.Start();
        }

        public void Stop()
        {

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
                DdeClient client = new DdeClient("MT4", "QUOTE");

                TheContainer.TheDdeClient = client;

                // Subscribe to the Disconnected event.  This event will notify the application when a conversation has been terminated.
                client.Disconnected += OnDisconnected;

                // Connect to the server.  It must be running or an exception will be thrown.
                try
                {
                    client.Connect();
                }
                catch (Exception)
                {
                    TheContainer.TheDdeClient = null;
                    Cls.Global.GlobalInstance.SyncErrorLog("An exception was thrown during DDE connection");
                    Cls.Global.GlobalInstance.SyncErrorLog("Ensure Metatrader 4 is running and DDE is enabled");
                    Cls.Global.GlobalInstance.SyncErrorLog("To activate the DDE Server go to Tools -> Options");
                    Cls.Global.GlobalInstance.SyncErrorLog("On the Server tab, ensure \"Enable DDE server\" is checked");
                }

                // Advise Loop                    

                foreach (var item in Cls.Global.GlobalInstance.lstMT4Symols)
                {
                    try
                    {
                        client.StartAdvise(item.Trim(), 1, true, 60000);
                    }
                    catch (Exception ex)
                    {
                        Cls.Global.GlobalInstance.SyncErrorLog("Error at StartQuotes() >> " + ex.Message);
                    }

                }

                client.Advise += OnAdvise;

                Cls.Global.GlobalInstance.SyncErrorLog("DDE Client Started");
            }
            else
            {
                Cls.Global.GlobalInstance.SyncErrorLog("DDE Client Already Started");
            }

        }

        private void OnDisconnected(object sender, DdeDisconnectedEventArgs args)
        {
            Cls.Global.GlobalInstance.SyncErrorLog("DDE Client Disconnected");
            TheContainer.TheDdeClient = null;
        }

        private void OnAdvise(object sender, DdeAdviseEventArgs args)
        {
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
            if (Form1.isSimDataSave && Form1.savedSimRecords < Form1.totalSimRecords)
            {
                LogData(msg);
                Form1.totalSimRecords++;
            }
        }

        private void LogData(DdeAdviseEventArgs args)
        {
            try
            {
                if (Cls.Global.GlobalInstance._dSymbolList.ContainsKey(args.Item.Trim()))
                {

                    string[] str = args.Text.Split(' ');
                    DateTime dtFeed = Convert.ToDateTime(str[0] + " " + str[1]);
                    TimeSpan tsSpan = dtFeed.ToUniversalTime() - dtStartPoint;

                    MQLTick msObj = new MQLTick();

                    msObj.contract = args.Item;
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
                    msObj.date = tsSpan.TotalSeconds;

                    double.TryParse(str[2].Trim(), out msObj.Bid);
                    double.TryParse(str[3].Trim(), out msObj.Ask);

                    Cls.Global.GlobalInstance._syncSimQueue.Enqueue(msObj);                    
                }
                
            }
            catch (Exception ex)
            {

            }

        }
        private void SendFeedToMSMQ(DdeAdviseEventArgs args)
        {
            string[] str = args.Text.Split(' ');
            DateTime dtFeed = Convert.ToDateTime(str[0] + " " + str[1]);

            try
            {
                double _bid = Convert.ToDouble(str[2].Trim());
                double _ask = Convert.ToDouble(str[3].Trim());
                string queueMsg = args.Item + "," + _bid.ToString() + "/" + (_bid + 1).ToString() + "," + _ask.ToString() + "/" + (_ask + 1).ToString() + "," +
                    ((_bid + _ask) / 2).ToString() + "," + dtFeed.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture);
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
            catch (Exception ex)
            {
                Cls.Global.GlobalInstance.SyncErrorLog("While sending data to queue: " + ex.Message);
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
                    Cls.Global.GlobalInstance.SyncErrorLog("While sending data to server: " + ex.Message.ToString());
                }
            }
        }


        private void SendFeedToPipe(DdeAdviseEventArgs args)
        {
            try
            {
                if (Cls.Global.GlobalInstance._dSymbolList.ContainsKey(args.Item.Trim()))
                {

                    string[] str = args.Text.Split(' ');
                    DateTime dtFeed = Convert.ToDateTime(str[0] + " " + str[1]);
                    TimeSpan tsSpan = dtFeed.ToUniversalTime() - dtStartPoint;

                    MQLTick msObj = new MQLTick();

                    msObj.contract = args.Item;
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
                    msObj.date = tsSpan.TotalSeconds;

                    double.TryParse(str[2].Trim(), out msObj.Bid);
                    double.TryParse(str[3].Trim(), out msObj.Ask);


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
            catch (Exception ex)
            {
                Cls.Global.GlobalInstance.SyncErrorLog("Error at SendFeedToPipe >> " + ex.Message);
            }

        }

        private void SendDataToPipe(MQLTick objMQLTick)
        {
            byte[] result = new byte[100];
            result = Cls.Global.GlobalInstance.STRUCTtoBYTESBROKER(objMQLTick, 1);
            try
            {
                NamedPipeClientStream pipeStream = new NamedPipeClientStream(".", "MT5", PipeDirection.Out, PipeOptions.Asynchronous);
                pipeStream.Connect(1000);
                pipeStream.BeginWrite(result, 0, result.Length, AsyncSend, pipeStream);
                string msg = objMQLTick.contract + "," + objMQLTick.productType + "," + objMQLTick.Ask.ToString() + "," + objMQLTick.Bid.ToString() + "," + objMQLTick.dAskSize.ToString() + ","
                            + objMQLTick.dBidSize.ToString() + "," + objMQLTick.dOpen.ToString() + "," + objMQLTick.dHigh.ToString() + "," + objMQLTick.dLow.ToString()
                           + "," + objMQLTick.dClose.ToString() + "," + objMQLTick.LTP.ToString() + "," + objMQLTick.dLastSize.ToString() + "," + objMQLTick.date.ToString();
                Cls.Global.GlobalInstance.SyncErrorLog(msg);
            }
            catch (Exception ex)
            {
                Cls.Global.GlobalInstance.SyncErrorLog("While sending data to server >> SendDataToPipe >> : " + ex.Message);

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
