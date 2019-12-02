using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using CommonLibrary.Cls;
//using Logging;
using System.Reflection;
using System.Linq;
using System.Security.Principal;

namespace TWS
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);

            // Add the event handler for handling UI thread exceptions to the event.
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);

            // Set the unhandled exception mode to force all Windows Forms errors to go through our handler.
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            // Add the event handler for handling non-UI thread exceptions to the event. 
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            //Application.Run(new FrmMain());
            //SingleInstance.SingleApplication.Run(new FrmMain());
            SingleInstance.SingleApplication.Run(FrmMain.INSTANCE);
        }
        
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs ex)
        {
            string exceptionObject=string.Empty;
            if(ex.ExceptionObject!=null)
                exceptionObject=ex.ExceptionObject.ToString();
            ////////FileHandling.WriteAllLog("Critical Error : " + sender.GetType().GetProperty("Name") +" > "+ sender.GetType().GetProperty("Parent") +" > " +exceptionObject);

            //ClsCommonMethods.ShowErrorBox("Critical Error : " + sender.GetType().GetProperty("Name") + sender.GetType().GetProperty("Parent") + ex.ExceptionObject);

            //Environment.Exit(0);
            //Application.Exit();
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs ex)
        {
            //////FileHandling.WriteAllLog("Critical Error : " + ex.Exception.Message + " Exception Generated from " + ex.Exception.Source
                                     //+ " File in " + ex.Exception.TargetSite + " Method At " +
                                     //ex.Exception.StackTrace);

            ////ClsCommonMethods.ShowErrorBox("Critical Error : " + ex.Exception.Message + " Exception Generated from" + ex.Exception.Source + " File in" + ex.Exception.TargetSite + " Method At" + ex.Exception.StackTrace);

            //Environment.Exit(0);
            //Application.Exit();
        }
    }

}