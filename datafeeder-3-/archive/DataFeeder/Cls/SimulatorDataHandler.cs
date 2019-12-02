using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading;

namespace DataFeederSln.Cls
{
    /// <summary>
    /// This class manages Simulator Data
    /// </summary>
    public class SimulatorDataHandler
    {
        #region "    Static Fields     "

        // Singleton instance
        private static SimulatorDataHandler _SimulatorDataHandler;
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

        private int DelayTime = 0;
        DateTime dtStartPoint = DateTime.UtcNow;
        int firstLineIndex = 0;
        int totalLines = 0;
        Thread ThreadDataConsumer;
        Thread ThreadDataReader;
        private bool flag = true;

        int _rowcount;

        #endregion "     PRIVATE FIELDS      "

        #region "   PUBLIC FIELDS      "

        // Synchronized Queue to manage DDE data
        public Queue _syncDataQueue = Queue.Synchronized(_queue);

        public bool _isSimulatorActive = false;
        #endregion "     PUBLIC FIELDS      "

        #region "     PROPERTIES       "

        // Singleton exposed instance
        public static SimulatorDataHandler _SimulatorDataHandlerInstance
        {
            get { return _SimulatorDataHandler ?? (_SimulatorDataHandler = new SimulatorDataHandler()); }
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
        private SimulatorDataHandler()
        {
            try
            {
                dtStartPoint = new System.DateTime(1970, 01, 01, 00, 00, 00);
            }
            catch (Exception)
            {

            }

        }

        public void Init(bool _sendToPipe, bool _sendToMSMQ, bool _sendToALL, int _delay)
        {
            sendToPipe = _sendToPipe;
            sendToMSMQ = _sendToMSMQ;
            sendToALL = _sendToALL;
            DelayTime = _delay;
       
            ThreadDataConsumer = new System.Threading.Thread(ThreadHandleDataConsumer);
            ThreadDataConsumer.IsBackground = true;
            ThreadDataConsumer.Start();
            ThreadDataReader = new System.Threading.Thread(ThreadHandleDataReader);
            ThreadDataReader.IsBackground = true;
            ThreadDataReader.Start();
        }


        public void Stop()
        {
            try
            {
                //if (ThreadDataConsumer != null)
                //{
                //    ThreadDataConsumer.Abort();
                //}
                //if (ThreadDataConsumer != null)
                //{
                //    ThreadDataReader.Abort();
                //}
                //_syncDataQueue.Clear();
                //firstLineIndex = totalLines;
                //_isSimulatorActive = false;
            }
            catch (Exception ex)
            {
                Cls.Global.GlobalInstance.SyncErrorLog("SimulatorDataHandler >> Stop() : " + ex.Message);
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
            try
            {
                string simFilePath = Cls.Global.GlobalInstance.SimLogPath + "\\SimulatorData.txt";
                if (File.Exists(simFilePath))
                {

                    Cls.Global.GlobalInstance.SyncErrorLog("Simulator started at : " + DateTime.UtcNow.ToString());
                    totalLines = File.ReadLines(simFilePath).Count();
                    string[] lines = File.ReadAllLines(simFilePath);
                    //while(firstLineIndex < totalLines)
                    for (int i = 0; i < totalLines; i++)
                    {
                        string[] simFeed = lines[i].Split(',');

                        DateTime dtFeed = DateTime.UtcNow;
                        TimeSpan tsSpan = dtFeed.ToUniversalTime() - dtStartPoint;
                        MQLTick msObj = new MQLTick();
                        msObj.date = tsSpan.TotalSeconds;
                        msObj.contract = simFeed[0];
                        msObj.productType = simFeed[1];
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
                        double.TryParse(simFeed[2].Trim(), out msObj.Ask);
                        double.TryParse(simFeed[4].Trim(), out msObj.Bid);
                        double.TryParse(simFeed[5].Trim(), out msObj.dAskSize);
                        double.TryParse(simFeed[6].Trim(), out msObj.dBidSize);
                        double.TryParse(simFeed[7].Trim(), out msObj.dOpen);
                        double.TryParse(simFeed[8].Trim(), out msObj.dHigh);
                        double.TryParse(simFeed[9].Trim(), out msObj.dLow);
                        double.TryParse(simFeed[10].Trim(), out msObj.dClose);
                        double.TryParse(simFeed[11].Trim(), out msObj.LTP);
                        double.TryParse(simFeed[12].Trim(), out msObj.dLastSize);

                        _syncDataQueue.Enqueue(msObj);
                        // firstLineIndex++;

                        if (i == totalLines - 1)
                        {
                            i = 0;
                        }
                        Thread.Sleep(DelayTime);
                    }
                }
            }
            catch (Exception ex)
            {
                Cls.Global.GlobalInstance.SyncErrorLog("StartQuotes >> Stop() : " + ex.Message);
            }


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
                    MQLTick objMQLTick = (MQLTick)_syncDataQueue.Dequeue();
                    System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(ThreadPoolHandler), objMQLTick);
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
            MQLTick objMQLTick = (MQLTick)data;
            if (sendToPipe)
            {
                SendFeedToPipe(objMQLTick);
            }
            else if (sendToMSMQ)
            {
                SendFeedToMSMQ(objMQLTick);
            }
            else
            {
                SendFeedToPipe(objMQLTick);
                SendFeedToMSMQ(objMQLTick);
            }
        }

        private void SendFeedToMSMQ(MQLTick args)
        {
            try
            {
                DateTime dtFeed = DateTime.UtcNow.AddHours(5.5);

                string queueMsg = args.contract + "," + args.Bid.ToString() + "/" + (args.Bid + 1).ToString() + "," + args.Ask.ToString() + "/" + (args.Ask + 1).ToString() + "," +
                        args.LTP.ToString() + "," + dtFeed.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture);
                SendDataToMSMQ(queueMsg);
                Cls.Global.GlobalInstance._syncUIQueue.Enqueue(queueMsg);
                if (Cls.Global.GlobalInstance._dDupSymbolList.ContainsKey(args.contract))
                {
                    string queueMsgDup = Cls.Global.GlobalInstance._dDupSymbolList[args.contract.Trim()] + "," + args.Bid.ToString() + "/" + (args.Bid + 1).ToString() + "," + args.Ask.ToString() + "/" + (args.Ask + 1).ToString() + "," +
                        args.LTP.ToString() + "," + dtFeed.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture);
                    SendDataToMSMQ(queueMsgDup);
                    Cls.Global.GlobalInstance._syncUIQueue.Enqueue(queueMsgDup);
                }
            }
            catch (Exception ex)
            {
                Cls.Global.GlobalInstance.SyncErrorLog("SimulatorDataHandler >> While sending data to queue: " + ex.Message);
            }
        }

        private void SendFeedToPipe(MQLTick msObj)
        {
            try
            {
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
            catch (Exception ex)
            {
                Cls.Global.GlobalInstance.SyncErrorLog("SimulatorDataHandler >> While sending data to queue: " + ex.Message);
            }
        }

        private void SendDataToPipe(MQLTick objMQLTick)
        {
            try
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
                        //SILVERJUL2015,1,39488,1,39480,5,3,38280,39630,38253,38364,3888,1431615907.67914
                        Cls.Global.GlobalInstance.SyncErrorLog(msg);
                    }
                    catch (Exception ex)
                    {
                        Cls.Global.GlobalInstance.SyncErrorLog("SimulatorDataHandler >> While sending data to queue >> SendDataToPipe() : " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                Cls.Global.GlobalInstance.SyncErrorLog("SendDataToPipe >> SendDataToPipe() : " + ex.Message);
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
