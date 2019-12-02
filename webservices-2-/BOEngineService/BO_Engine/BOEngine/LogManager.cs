using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Threading;

namespace BOEngine
{
    /// <summary>
    /// This class manages service log
    /// </summary>
    public class LogManager
    {
        #region "    Static Fields     "

        // Singleton instance
        private static LogManager _LogManagerInstance;
        // Queue to manage Application log
        private static Queue _queueAppLog = new Queue();

        #endregion "    Static Fields     "

        #region "   PRIVATE FIELDS     "

        // lock to restrict concurrent access
        private object _lockObject;
        // String - path of Application Log
        private string AppLogPath = string.Empty;        

        #endregion "     PRIVATE FIELDS      "

        #region "   PUBLIC FIELDS      "

        // Synchronized Queue to manage Application log
        private Queue SyncAppLogQueue = Queue.Synchronized(_queueAppLog);
        
        #endregion "     PUBLIC FIELDS      "

        #region "     PROPERTIES       "

        // Singleton exposed instance
        internal static LogManager LogManagerInstance
        {
            get { return _LogManagerInstance ?? (_LogManagerInstance = new LogManager()); }
        }

        // lock to restrict concurrent access to Application log
        internal object LockObject
        {
            get { return _lockObject ?? (_lockObject = new object()); }
        }

        #endregion "     PROPERTIES       "

        #region "       METHODS        "
        /// <summary>
        ///  private Constructors
        /// </summary>
        private LogManager()
        {
            string _baseDirectory = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments);
            AppLogPath = _baseDirectory + "\\Logs\\BOEngine\\";           

            Thread ThreadAppLog = new Thread(ThreadHandleApplicationLogQueue);
            ThreadAppLog.IsBackground = true;
            ThreadAppLog.Start();

        }

        /// <summary>
        /// manages the Application log
        /// </summary>
        private void ThreadHandleApplicationLogQueue()
        {
            while (true)
            {
                try
                {
                    if (SyncAppLogQueue.Count == 0)
                    {
                        Thread.Sleep(10);
                        //this will deflate the queue to size 0..
                        SyncAppLogQueue.TrimToSize();
                        continue;
                    }
                    if (SyncAppLogQueue.Count > 0)
                    {
                        string msg = (string)SyncAppLogQueue.Dequeue();
                        logAppData(msg);
                    }
                }
                catch (Exception)
                {

                }


                Thread.Sleep(0);

            }
        }

        internal void syncLog(string msg)
        {
            try
            {
                SyncAppLogQueue.Enqueue(msg);
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// This method creates the log 
        /// </summary>
        /// <param name="msg">message to write in log file</param>
        /// <param name="path">path of the log file</param>
        private void logAppData(string msg)
        {
            if (!string.IsNullOrEmpty(msg))
            {
                
                lock (LockObject)  // all other threads will wait for y
                {
                    string _path = AppLogPath + "Log_" + DateTime.UtcNow.ToString("dd_MM_yyyy");
                    if (File.Exists(_path + "\\Log.txt"))
                    {
                        try
                        {
                            TextWriter tsw = new StreamWriter(_path + "\\Log.txt", true);
                            tsw.WriteLine(DateTime.UtcNow.ToString() + " : " + msg + System.Environment.NewLine);
                            tsw.Close();
                        }
                        catch (Exception)
                        {
                        }

                    }
                    else
                    {
                        try
                        {
                            Directory.CreateDirectory(_path);
                            FileStream fsDevelopmentLog = new FileStream(_path + "\\Log.txt", FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite);
                            fsDevelopmentLog.Close();

                            TextWriter tsw = new StreamWriter(_path + "\\Log.txt", true);
                            tsw.WriteLine(DateTime.UtcNow.ToString() + " : " + msg + System.Environment.NewLine);
                            tsw.Close();
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
            }
        }

        

        #endregion "     METHODS      "
    }
}