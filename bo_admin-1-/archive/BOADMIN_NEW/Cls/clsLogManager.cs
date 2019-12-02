using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;

namespace BOADMIN_NEW.Cls
{
    class clsLogManager
    {
        private static clsLogManager _instance;
        private static Queue _queue = new Queue();
        public Queue _syncQueue = Queue.Synchronized(_queue);
        string logPath = string.Empty;

        public static clsLogManager INSTANCE
        {
            get { return _instance ?? (_instance = new clsLogManager()); }
        }

        private clsLogManager()
        {

            try
            {
                string path = Assembly.GetExecutingAssembly().Location;
                FileInfo fileInfo = new FileInfo(path);
                logPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\BCnS\\Log\\";
                Thread ThreadLog = new Thread(ThreadHandleQueue);
                ThreadLog.IsBackground = true;
                ThreadLog.Start();

            }
            catch (Exception)
            {

                
            }

        }

        private void ThreadHandleQueue()
        {
            while (true)
            {

                if (_syncQueue.Count == 0)
                {
                    Thread.Sleep(10);
                    //this will deflate the queue to size 0..
                    _syncQueue.TrimToSize();
                    continue;
                }
                if (_syncQueue.Count > 0)
                {
                    string msg = (string)_syncQueue.Dequeue();
                    log(msg);
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
}
