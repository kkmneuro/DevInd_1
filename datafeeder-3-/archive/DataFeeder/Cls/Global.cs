////////////////////////////////////////////////REVISION HISTORY////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION                                                                                   //
//05/13/2015	NAMO		1. Global class created for common operations and global data.                                //
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Linq;
using System.IO;
using System.Data;
using System.Collections;
using System.Threading;
using System.Diagnostics;
using System.Reflection;
using System.Collections.Generic;
using System.Messaging;

namespace DataFeederSln.Cls
{
    /// <summary>
    /// This class manages global methods
    /// </summary>
    public class Global
    {
        #region "    Static Fields     "

        // Singleton instance
        private static Global _GlobalInstance;
        // Queue to manage error log
        private static Queue _queue = new Queue();
        // Queue to manage UI log
        private static Queue _queueUI = new Queue();
        // String - path of ErrorLog 
        // Queue to manage error log
        private static Queue _queueSim = new Queue();
        private string ErrorLog;
        public string SimLogPath;

        #endregion "    Static Fields     "

        #region "   PRIVATE FIELDS     "

        // lock to restrict concurrent access
        private object _lockObject;

        #endregion "     PRIVATE FIELDS      "

        #region "   PUBLIC FIELDS      "

        // Synchronized Queue to manage error log
        private Queue _syncErrorQueue = Queue.Synchronized(_queue);

        // Synchronized Queue to manage error log
        public Queue _syncSimQueue = Queue.Synchronized(_queueSim);

        // Synchronized Queue to manage UI log
        public Queue _syncUIQueue = Queue.Synchronized(_queueUI);

        // Data collection for symbol name and security Type
        public Dictionary<string, string> _dSymbolList;

        public List<string> lstMT4Symols;
        // Data collection for symbol name and respective duplicate symbol name
        public Dictionary<string, string> _dDupSymbolList;

        // MSMQ name for data transfer
        public string QueueName;

        #endregion "     PUBLIC FIELDS      "

        #region "     PROPERTIES       "

        // Singleton exposed instance
        public static Global GlobalInstance
        {
            get { return _GlobalInstance ?? (_GlobalInstance = new Global()); }
        }

        // lock to restrict concurrent access
        public object LockObject
        {
            get { return _lockObject ?? (_lockObject = new object()); }
        }

        #endregion "     PROPERTIES       "

        #region "     METHODS      "

        /// <summary>
        ///  private Constructors
        /// </summary>
        private Global()
        {
            try
            {
                string path = Assembly.GetExecutingAssembly().Location;
                FileInfo fileInfo = new FileInfo(path);
                ErrorLog = fileInfo.DirectoryName + "\\Logs\\Error\\";
                SimLogPath = fileInfo.DirectoryName + "\\SimulatorData\\";
                lstMT4Symols = new List<string>();
                _dSymbolList = new Dictionary<string, string>();
                _dDupSymbolList = new Dictionary<string, string>();
                QueueName = System.Configuration.ConfigurationManager.AppSettings["QueuePath"];          
                _dSymbolList = getSymbolsList();
                _dDupSymbolList = getDupSymbolsList();
                Thread ThreadError = new System.Threading.Thread(ThreadHandleQueue);
                ThreadError.Start();

             
            }
            catch (Exception )
            {
                throw;
            }
        }

        private Dictionary<string, string> getSymbolsList()
        {
            Dictionary<string, string> DSymbolList = new Dictionary<string, string>();

            try
            {
                string futureSymbols = System.Configuration.ConfigurationManager.AppSettings["FutureSymbolList"];
                if (futureSymbols.Trim() != "")
                {
                    if (futureSymbols.Contains(','))
                    {
                        string[] futureSymbolList = futureSymbols.Split(',');
                        foreach (string item in futureSymbolList)
                        {
                            if (!DSymbolList.ContainsKey(item.Trim()))
                            {
                                DSymbolList.Add(item.Trim(), "1");
                            }
                        }
                    }
                    else
                    {
                        DSymbolList.Add(futureSymbols.Trim(), "1");
                    }
                }
            }
            catch (Exception ex)
            {
                SyncErrorLog("Error at getSymbolsList >> FutureSymbolList >> " + ex.Message);

            }
            try
            {
                string forexSymbols = System.Configuration.ConfigurationManager.AppSettings["ForexSymbolList"];
                if (forexSymbols.Trim() != "")
                {
                    if (forexSymbols.Contains(','))
                    {
                        string[] forexSymbolList = forexSymbols.Split(',');
                        foreach (string item in forexSymbolList)
                        {
                            if (!DSymbolList.ContainsKey(item.Trim()))
                            {
                                DSymbolList.Add(item.Trim(), "0");
                            }
                        }
                    }
                    else
                    {
                        DSymbolList.Add(forexSymbols.Trim(), "0");
                    }
                }
            }
            catch (Exception ex)
            {
                SyncErrorLog("Error at getSymbolsList >> ForexSymbolList >> " + ex.Message);

            }
            try
            {

                string[] mt5SymbolList;
                string mt4Symbols = System.Configuration.ConfigurationManager.AppSettings["MT4SymbolList"];
                if (mt4Symbols.Trim() != "")
                {
                    if (mt4Symbols.Contains(','))
                    {
                        mt5SymbolList = mt4Symbols.Split(',');
                        foreach (string sym in mt5SymbolList)
                        {
                            if (!lstMT4Symols.Contains(sym.Trim()))
                            {
                                lstMT4Symols.Add(sym.Trim());
                            }
                        }
                    }
                    else
                    {
                        lstMT4Symols.Add(mt4Symbols.Trim());

                    }
                }
            }
            catch (Exception ex)
            {
                SyncErrorLog("Error at getSymbolsList >> MT4SymbolList >> " + ex.Message);

            }

            return DSymbolList;
        }

        //private Dictionary<string, string> getSymbolsList()
        //{
        //    Dictionary<string, string> DSymbolList = new Dictionary<string, string>();
        //    try
        //    {
        //        string[] SymbolList;
        //        string symbols = System.Configuration.ConfigurationManager.AppSettings["SymbolList"];

        //        if (symbols.Contains(','))
        //        {
        //            SymbolList = symbols.Split(',');
        //        }
        //        else
        //        {
        //            SymbolList = new string[1];
        //            SymbolList[0] = symbols.Trim();
        //        }
        //        foreach (string item in SymbolList)
        //        {
        //            string[] s = item.Split('_');
        //            string pType = string.Empty;
        //            switch (s[1].Trim())
        //            {
        //                case "FOREX":
        //                    pType = "0";
        //                    break;
        //                case "FUTURE":
        //                    pType = "1";
        //                    break;
        //                case "Equity":
        //                    pType = "3";
        //                    break;
        //                case "OPTION":
        //                    pType = "2";
        //                    break;
        //                case "SPOT":
        //                    pType = "4";
        //                    break;
        //                case "PHYSICAL":
        //                    pType = "6";
        //                    break;
        //                case "AUCTION":
        //                    pType = "7";
        //                    break;
        //                case "BOND":
        //                    pType = "5";
        //                    break;
        //                default:
        //                    break;
        //            }
        //            DSymbolList.Add(s[0].Trim(), pType);
        //        }
        //        string[] mt5SymbolList;
        //        string mt4Symbols = System.Configuration.ConfigurationManager.AppSettings["MT4SymbolList"];
        //        if (mt4Symbols.Trim() != "")
        //        {
        //            if (mt4Symbols.Contains(','))
        //            {
        //                mt5SymbolList = mt4Symbols.Split(',');
        //                foreach (string sym in mt5SymbolList)
        //                {
        //                    if (!lstMT4Symols.Contains(sym.Trim()))
        //                    {
        //                        lstMT4Symols.Add(sym.Trim());
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                lstMT4Symols.Add(mt4Symbols.Trim());

        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _syncErrorQueue.Enqueue("Error at getSymbolsList" + ex.Message);

        //    }           

        //    return DSymbolList;
        //}

        private Dictionary<string, string> getDupSymbolsList()
        {
            Dictionary<string, string> DdupSymbolList = new Dictionary<string, string>();
            try
            {
                string[] SymbolList;
                string symbols = System.Configuration.ConfigurationManager.AppSettings["DupSymbolList"];

                if (symbols.Contains(','))
                {
                    SymbolList = symbols.Split(',');
                }
                else
                {
                    SymbolList = new string[1];
                    SymbolList[0] = symbols.Trim();
                }
                foreach (string item in SymbolList)
                {
                    if (item.Contains('_'))
                    {
                        string[] s = item.Split('_');

                        DdupSymbolList.Add(s[0].Trim(), s[1].Trim());
                    }

                }
            }
            catch (Exception ex)
            {
                log("Error at getDupSymbolsList() " + ex.Message);
            }

            return DdupSymbolList;
        }

        /// <summary>
        /// counts the occurrence of a char in a perticular string
        /// </summary>     
        public int CountOccurrences(String myString, char needle, int i)
        {
            return ((i = myString.IndexOf(needle, i)) == -1) ? 0 : 1 + CountOccurrences(myString, needle, i + 1);
        }

        /// <summary>
        /// This method creates the log 
        /// </summary>
        /// <param name="msg">message to write in log file</param>   
        private void log(string msg)
        {
            lock (LockObject)  // all other threads will wait for y
            {
                string _path = ErrorLog + "Log_" + DateTime.Now.ToString("dd_MM_yyyy");
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


        /// <summary>
        /// manages the error log
        /// </summary>
        private void ThreadHandleQueue()
        {
            while (true)
            {
                if (_syncErrorQueue.Count == 0)
                {
                    Thread.Sleep(10);
                    //this will deflate the queue to size 0..
                    _syncErrorQueue.TrimToSize();
                    continue;
                }
                if (_syncErrorQueue.Count > 0)
                {
                    string msg = (string)_syncErrorQueue.Dequeue();
                    _syncUIQueue.Enqueue(msg);
                    log(msg);
                }
                Thread.Sleep(0);

            }
        }

        public byte[] STRUCTtoBYTESBROKER(object obj, int Flag)
        {
            byte[] result = null;
            if (Flag == 1)
            {
                System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
                MQLTick marketObj = (MQLTick)obj;

                byte[] ask = BitConverter.GetBytes(marketObj.Ask);
                byte[] bid = BitConverter.GetBytes(marketObj.Bid);
                byte[] ltp = BitConverter.GetBytes(marketObj.LTP);
                byte[] lastSize = BitConverter.GetBytes(marketObj.dLastSize);
                byte[] open = BitConverter.GetBytes(marketObj.dOpen);
                byte[] high = BitConverter.GetBytes(marketObj.dHigh);
                byte[] low = BitConverter.GetBytes(marketObj.dLow);
                byte[] close = BitConverter.GetBytes(marketObj.dClose);
                byte[] date = BitConverter.GetBytes(marketObj.date);
                byte[] mkttype = encoding.GetBytes(marketObj.productType);
                byte[] symbol;
                byte[] askSize = BitConverter.GetBytes(marketObj.dAskSize);
                byte[] bidSize = BitConverter.GetBytes(marketObj.dBidSize);
                if (marketObj.contract.Contains(' '))
                {
                    symbol = encoding.GetBytes(marketObj.contract.Replace(" ", string.Empty));
                }
                else
                {
                    symbol = encoding.GetBytes(marketObj.contract);
                }


                result = new byte[ask.Length + bid.Length + ltp.Length + open.Length + high.Length + low.Length + close.Length + date.Length + mkttype.Length + symbol.Length + bidSize.Length + askSize.Length + lastSize.Length];

                int startIndex = 0;
                System.Array.Copy(ask, 0, result, 0, ask.Length); startIndex += ask.Length;
                System.Array.Copy(bid, 0, result, startIndex, bid.Length); startIndex += bid.Length;
                System.Array.Copy(ltp, 0, result, startIndex, ltp.Length); startIndex += ltp.Length;
                System.Array.Copy(open, 0, result, startIndex, open.Length); startIndex += open.Length;
                System.Array.Copy(high, 0, result, startIndex, high.Length); startIndex += high.Length;
                System.Array.Copy(low, 0, result, startIndex, low.Length); startIndex += low.Length;
                System.Array.Copy(close, 0, result, startIndex, close.Length); startIndex += close.Length;
                System.Array.Copy(bidSize, 0, result, startIndex, bidSize.Length); startIndex += bidSize.Length;
                System.Array.Copy(askSize, 0, result, startIndex, askSize.Length); startIndex += askSize.Length;
                System.Array.Copy(lastSize, 0, result, startIndex, lastSize.Length); startIndex += lastSize.Length;
                System.Array.Copy(date, 0, result, startIndex, date.Length); startIndex += date.Length;
                System.Array.Copy(mkttype, 0, result, startIndex, mkttype.Length); startIndex += mkttype.Length;
                System.Array.Copy(symbol, 0, result, startIndex, symbol.Length); startIndex += symbol.Length;

            }
            return result;
        }

        public void SyncErrorLog(string message)
        {
            try
            {
                _syncErrorQueue.Enqueue(message);
            }
            catch (Exception)
            {
            }
            
        }

        #endregion "     METHODS      "
    }
}
