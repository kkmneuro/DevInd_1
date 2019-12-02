using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

namespace BOADMIN_NEW
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           // Application.Run(new Forms.frmDataLogin());

            //Add event handler for handling UI thread exceptions to the event.
            Application.ThreadException+=new ThreadExceptionEventHandler(Application_ThreadException);

            //Set the unhandled exception mode to force all windows forms errors to go through our handler.
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            //Add the event handler for handling non-UI thread exceptions to the event.
            AppDomain.CurrentDomain.UnhandledException+=new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            Application.Run(FrmMain.Instance);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs ex)
        {
            //Logging.FileHandling.WriteAllLog("Critical Error : " + sender.GetType().GetProperty("Name").ToString()
                  //  + sender.GetType().GetProperty("Parent").ToString() + ex.ExceptionObject.ToString());
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs ex)
        {
            //Logging.FileHandling.WriteAllLog("Critical Error : " + ex.Exception.Message + " Exception Generated from" + ex.Exception.Source
                  //  + " File in" + ex.Exception.TargetSite + " Method At" + ex.Exception.StackTrace);
        }
    }
}
