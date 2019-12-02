using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
//using log4net;
//using log4net;
//using log4net.Config;


namespace clsInterface4OME
{
    //using LoggerClasses;
    /////////////////////////////////////////////////////////////////////////////////
    //public class LogFactory
    //{
    //    public enum LOGGING_LEVEL
    //    {
    //        DEBUG = 0,
    //        ERROR = 1,
    //        FATAL = 2,
    //        INFO = 3,
    //        WARN = 4,
    //        CUSTOM = 5,
    //        NONE = 6,
    //        ALL = 7,
    //    }
    //    public enum LOGGING_DEST
    //    {
    //        IN_SOCK = 0,
    //        OUT_SOCK = 1,
    //        GENERAL = 2,
    //    }
    //    private static LogFactory obj_LogFactory = null;

    //    private static LogFactory CreateInstance_LogFactory()
    //    {
    //        if (obj_LogFactory == null)
    //        {
    //            obj_LogFactory = new LogFactory();
    //        }
    //        return obj_LogFactory;
    //    }


    //    private LogFactory()
    //    {

    //        XmlConfigurator.Configure(new System.IO.FileInfo("LogApp.config"));

    //        //string LoggerPath = "C:\\GalaxyTradestation\\Logs\\DAW\\";
    //        //Initialize(LoggerPath);

    //        XmlDocument doc = new XmlDocument();
    //        doc.Load("LogConfigSettings.xml");
    //        XmlNodeList list = doc.GetElementsByTagName("Logger");
    //        string loggerName = "";
    //        foreach (XmlNode logger in list)
    //        {
    //            XmlNodeList LoggerList = logger.ChildNodes;
    //            foreach (XmlNode lvl in LoggerList)
    //            {
    //                XmlNodeList internalList = lvl.ChildNodes;
    //                if (lvl.Attributes[0].Name.Equals("name"))
    //                {
    //                    loggerName = lvl.Attributes[0].Value;
    //                }
    //                foreach (XmlNode lvl2 in internalList)
    //                {
    //                    if (lvl2.Attributes[0].Name.Equals("value"))
    //                    {
    //                        string loggingLevel = lvl2.Attributes[0].Value;
    //                        SetLoggingLevel((LOGGING_DEST)Enum.Parse(typeof(LOGGING_DEST), loggerName), (LOGGING_LEVEL)Enum.Parse(typeof(LOGGING_LEVEL), loggingLevel));
    //                    }
    //                }
    //            }
    //        }//foreach (XmlNode logger in list)



    //    }

    //    public static void Initialize(string logDirectory)
    //    {
    //        //get the current logging repository for this application
    //        log4net.Repository.ILoggerRepository repository = LogManager.GetRepository();
    //        //get all of the appenders for the repository
    //        log4net.Appender.IAppender[] appenders = repository.GetAppenders();
    //        //only change the file path on the 'FileAppenders'
    //        foreach (log4net.Appender.IAppender appender in (from iAppender in appenders
    //                                                         where iAppender is log4net.Appender.RollingFileAppender
    //                                                         select iAppender))
    //        {
    //            log4net.Appender.RollingFileAppender rollingfileAppender = appender as log4net.Appender.RollingFileAppender;
    //            //set the path to your logDirectory using the original file name defined
    //            //in configuration
    //            rollingfileAppender.File = System.IO.Path.Combine(logDirectory, System.IO.Path.GetFileName(rollingfileAppender.File));
    //            //make sure to call fileAppender.ActivateOptions() to notify the logging
    //            //sub system that the configuration for this appender has changed.
    //            rollingfileAppender.ActivateOptions();
    //        }

    //    }

    //    private void SetLoggingLevel(LogFactory.LOGGING_DEST dest, LogFactory.LOGGING_LEVEL level)
    //    {
    //        string LoggerName = dest.ToString();

    //        if (string.IsNullOrEmpty(LoggerName))
    //            return;
    //        log4net.Core.Level loggingLevel = getLoggingLevel(level);
    //        log4net.Repository.ILoggerRepository[] repositories = log4net.LogManager.GetAllRepositories();

    //        //Configure all loggers to be at the debug level.
    //        foreach (log4net.Repository.ILoggerRepository repository in repositories)
    //        {
    //            log4net.Repository.Hierarchy.Hierarchy hier = (log4net.Repository.Hierarchy.Hierarchy)repository;
    //            log4net.Core.ILogger[] loggers = hier.GetCurrentLoggers();
    //            foreach (log4net.Core.ILogger logger in loggers)
    //            {
    //                if (((log4net.Repository.Hierarchy.Logger)logger).Name == LoggerName)
    //                {
    //                    ((log4net.Repository.Hierarchy.Logger)logger).Level = loggingLevel;
    //                    break;
    //                }
    //            }
    //        }
    //        //Configure the root logger.
    //        log4net.Repository.Hierarchy.Hierarchy h = (log4net.Repository.Hierarchy.Hierarchy)log4net.LogManager.GetRepository();
    //        log4net.Repository.Hierarchy.Logger rootLogger = h.Root;
    //        rootLogger.Level = loggingLevel;

    //    }

    //    private void SetLoggingLevel(LogFactory.LOGGING_LEVEL level)
    //    {
    //        log4net.Core.Level loggingLevel = getLoggingLevel(level);

    //        log4net.Repository.ILoggerRepository[] repositories = log4net.LogManager.GetAllRepositories();

    //        //Configure all loggers to be at the debug level.
    //        foreach (log4net.Repository.ILoggerRepository repository in repositories)
    //        {
    //            repository.Threshold = loggingLevel;//repository.LevelMap["DEBUG"];
    //            log4net.Repository.Hierarchy.Hierarchy hier = (log4net.Repository.Hierarchy.Hierarchy)repository;
    //            log4net.Core.ILogger[] loggers = hier.GetCurrentLoggers();
    //            foreach (log4net.Core.ILogger logger in loggers)
    //            {
    //                ((log4net.Repository.Hierarchy.Logger)logger).Level = loggingLevel;
    //            }
    //        }

    //        //Configure the root logger.
    //        log4net.Repository.Hierarchy.Hierarchy h = (log4net.Repository.Hierarchy.Hierarchy)log4net.LogManager.GetRepository();
    //        log4net.Repository.Hierarchy.Logger rootLogger = h.Root;
    //        rootLogger.Level = loggingLevel;//h.LevelMap["DEBUG"];
    //    }

    //    private log4net.Core.Level getLoggingLevel(LogFactory.LOGGING_LEVEL level)
    //    {
    //        log4net.Core.Level levelToReturn = log4net.Core.Level.Off;
    //        switch (level)
    //        {
    //            case LogFactory.LOGGING_LEVEL.DEBUG:
    //                levelToReturn = log4net.Core.Level.Debug;//LogManager.GetRepository().LevelMap["DEBUG"];
    //                break;
    //            case LogFactory.LOGGING_LEVEL.ERROR:
    //                levelToReturn = log4net.Core.Level.Error;
    //                break;
    //            case LogFactory.LOGGING_LEVEL.FATAL:
    //                levelToReturn = log4net.Core.Level.Fatal;
    //                break;
    //            case LogFactory.LOGGING_LEVEL.INFO:
    //                levelToReturn = log4net.Core.Level.Info;
    //                break;
    //            case LogFactory.LOGGING_LEVEL.WARN:
    //                levelToReturn = log4net.Core.Level.Warn;
    //                break;
    //            case LogFactory.LOGGING_LEVEL.CUSTOM:
    //                levelToReturn = log4net.Core.Level.Off;
    //                break;
    //            case LogFactory.LOGGING_LEVEL.NONE:
    //                levelToReturn = log4net.Core.Level.Off;
    //                break;
    //            case LogFactory.LOGGING_LEVEL.ALL:
    //                levelToReturn = log4net.Core.Level.All;
    //                break;
    //            default:
    //                levelToReturn = log4net.Core.Level.Off;
    //                break;
    //        }

    //        return levelToReturn;
    //    }

    //    //public void SetLoggingLevel(LogFactory.LOGGING_LEVEL level)
    //    //{
    //    //    LogManager.GetRepository().Threshold = getLoggingLevel(level);
    //    //    //switch (level)
    //    //    //{
    //    //    //    case LogFactory.LOGGING_LEVEL.DEBUG:
    //    //    //        LogManager.GetRepository().Threshold = log4net.Core.Level.Debug;//LogManager.GetRepository().LevelMap["DEBUG"];
    //    //    //        break;
    //    //    //    case LogFactory.LOGGING_LEVEL.ERROR:
    //    //    //        LogManager.GetRepository().Threshold = log4net.Core.Level.Error;
    //    //    //        break;
    //    //    //    case LogFactory.LOGGING_LEVEL.FATAL:
    //    //    //        LogManager.GetRepository().Threshold = log4net.Core.Level.Fatal;
    //    //    //        break;
    //    //    //    case LogFactory.LOGGING_LEVEL.INFO:
    //    //    //        LogManager.GetRepository().Threshold = log4net.Core.Level.Info;
    //    //    //        break;
    //    //    //    case LogFactory.LOGGING_LEVEL.WARN:
    //    //    //        LogManager.GetRepository().Threshold = log4net.Core.Level.Warn;
    //    //    //        break;
    //    //    //    case LogFactory.LOGGING_LEVEL.CUSTOM:
    //    //    //        LogManager.GetRepository().Threshold = log4net.Core.Level.Off;
    //    //    //        break;
    //    //    //    case LogFactory.LOGGING_LEVEL.NONE:
    //    //    //        LogManager.GetRepository().Threshold = log4net.Core.Level.Off;
    //    //    //        break;
    //    //    //    case LogFactory.LOGGING_LEVEL.ALL:
    //    //    //        LogManager.GetRepository().Threshold = log4net.Core.Level.All;
    //    //    //        break;
    //    //    //    default:
    //    //    //        LogManager.GetRepository().Threshold = log4net.Core.Level.Off;
    //    //    //        break;
    //    //    //}

    //    //}

    //    public static void SendRecvLog(LogFactory.LOGGING_LEVEL level, bool isSend, string Sender_Recv_Name,
    //                                string ClassName, string MethodName, string message)
    //    {

    //        string logMessage = "";
    //        if (isSend)
    //        {
    //            logMessage = "Sent^" + Sender_Recv_Name +
    //                         "^" + ClassName + "^" +
    //                         MethodName + "^" +
    //                         message;
    //        }
    //        else
    //        {
    //            logMessage = "Recv^" + Sender_Recv_Name +
    //                         "^" + ClassName + "^" +
    //                         MethodName + "^" +
    //                         message;
    //        }

    //        LogFactory temp_LogFactory = CreateInstance_LogFactory();
    //        BaseLogger baselogger = null;
    //        baselogger = new InSocketLogger();
    //        baselogger.WriteMessage(level, logMessage);
    //    }

    //    public static void WriteLog(LogFactory.LOGGING_LEVEL level, LogFactory.LOGGING_DEST dest,  string message)
    //    {

    //        //if (message.Contains(':'))
    //        //{
    //        //    message.Replace(':', '-');
    //        //}
    //        string logMessage =  "==>" + message;
    //        LogFactory temp_LogFactory = CreateInstance_LogFactory();
    //        BaseLogger baselogger = null;
    //        switch (dest)
    //        {
    //            case LogFactory.LOGGING_DEST.GENERAL:
    //                baselogger = new MyLogger();
    //                baselogger.WriteMessage(level, logMessage);
    //                break;
    //            case LogFactory.LOGGING_DEST.IN_SOCK:
    //                baselogger = new InSocketLogger();
    //                baselogger.WriteMessage(level, logMessage);
    //                break;
    //            case LogFactory.LOGGING_DEST.OUT_SOCK:
    //                baselogger = new OutSocketLogger();
    //                baselogger.WriteMessage(level, logMessage);
    //                break;
    //            default:
    //                break;
    //        }
    //    }
    //    public static void WriteLog(LogFactory.LOGGING_LEVEL level, LogFactory.LOGGING_DEST dest, string ClassName, string MethodName, string message)
    //    {

    //        //if (message.Contains(':'))
    //        //{
    //        //    message.Replace(':', '-');
    //        //}
    //        string logMessage = ClassName + "==>" + MethodName + "==>" + message;

    //        LogFactory temp_LogFactory = CreateInstance_LogFactory();
    //        BaseLogger baselogger = null;
    //        switch (dest)
    //        {
    //            case LogFactory.LOGGING_DEST.GENERAL:
    //                baselogger = new MyLogger();
    //                baselogger.WriteMessage(level, logMessage);
    //                break;
    //            case LogFactory.LOGGING_DEST.IN_SOCK:
    //                baselogger = new InSocketLogger();
    //                baselogger.WriteMessage(level, logMessage);
    //                break;
    //            case LogFactory.LOGGING_DEST.OUT_SOCK:
    //                baselogger = new OutSocketLogger();
    //                baselogger.WriteMessage(level, logMessage);
    //                break;
    //            default:
    //                break;
    //        }
    //    }
    //    public static void WriteLog(LOGGING_LEVEL level, LogFactory.LOGGING_DEST dest, string ClassName, string MethodName, string message, Exception except)
    //    {
    //        //if (message.Contains(':'))
    //        //{
    //        //    message.Replace(':', '-');
    //        //}

    //        string logMessage = ClassName + "==>" + MethodName + "==>" + message;
    //        LogFactory temp_LogFactory = CreateInstance_LogFactory();
    //        BaseLogger baselogger = null;
    //        switch (dest)
    //        {
    //            case LogFactory.LOGGING_DEST.GENERAL:
    //                baselogger = new MyLogger();
    //                baselogger.WriteMessage(level, logMessage, except);
    //                break;
    //            case LogFactory.LOGGING_DEST.IN_SOCK:
    //                baselogger = new InSocketLogger();
    //                baselogger.WriteMessage(level, logMessage, except);
    //                break;
    //            case LogFactory.LOGGING_DEST.OUT_SOCK:
    //                baselogger = new OutSocketLogger();
    //                baselogger.WriteMessage(level, logMessage, except);
    //                break;
    //            default:
    //                break;
    //        }
    //    }

    //    public static void ScorpioWriteLog(LOGGING_LEVEL level, LogFactory.LOGGING_DEST dest, string ClassName, string MethodName, string message, Exception except)
    //    {
    //        string logMessage = " Scorpio " + ClassName + "==>" + MethodName + "==>" + message;
    //        LogFactory temp_LogFactory = CreateInstance_LogFactory();
    //        BaseLogger baselogger = null;
    //        switch (dest)
    //        {
    //            case LogFactory.LOGGING_DEST.GENERAL:
    //                baselogger = new MyLogger();
    //                baselogger.WriteMessage(level, logMessage, except);
    //                break;
    //            case LogFactory.LOGGING_DEST.IN_SOCK:
    //                baselogger = new InSocketLogger();
    //                baselogger.WriteMessage(level, logMessage, except);
    //                break;
    //            case LogFactory.LOGGING_DEST.OUT_SOCK:
    //                baselogger = new OutSocketLogger();
    //                baselogger.WriteMessage(level, logMessage, except);
    //                break;
    //            default:
    //                break;
    //        }
    //    }
    //}


}

//namespace LoggerClasses
//{
//    using clsInterface4OME;
//    /////////////////////////////////////////////////////////////////////////////////
//    class BaseLogger
//    {
//        protected ILog log = null;

//        public void WriteMessage(LogFactory.LOGGING_LEVEL level, object message)
//        {
//            switch (level)
//            {
//                case LogFactory.LOGGING_LEVEL.DEBUG:
//                    log.Debug(message);
//                    break;
//                case LogFactory.LOGGING_LEVEL.ERROR:
//                    log.Error(message);
//                    break;
//                case LogFactory.LOGGING_LEVEL.FATAL:
//                    log.Fatal(message);
//                    break;
//                case LogFactory.LOGGING_LEVEL.INFO:
//                    log.Info(message);
//                    break;
//                case LogFactory.LOGGING_LEVEL.WARN:
//                    log.Warn(message);
//                    break;
//                case LogFactory.LOGGING_LEVEL.CUSTOM:
//                    break;
//                default:
//                    break;
//            }

//        }
//        public void WriteMessage(LogFactory.LOGGING_LEVEL level, object message, Exception exception)
//        {
//            switch (level)
//            {
//                case LogFactory.LOGGING_LEVEL.DEBUG:
//                    log.Debug(message, exception);
//                    break;
//                case LogFactory.LOGGING_LEVEL.ERROR:
//                    log.Error(message, exception);
//                    break;
//                case LogFactory.LOGGING_LEVEL.FATAL:
//                    log.Fatal(message, exception);
//                    break;
//                case LogFactory.LOGGING_LEVEL.INFO:
//                    log.Info(message, exception);
//                    break;
//                case LogFactory.LOGGING_LEVEL.WARN:
//                    log.Warn(message, exception);
//                    break;
//                case LogFactory.LOGGING_LEVEL.CUSTOM:
//                    break;
//                default:
//                    break;
//            }


//        }

//    }
//    /////////////////////////////////////////////////////////////////////////////////
//    class InSocketLogger : BaseLogger
//    {
//        public InSocketLogger()
//        {
//            log = LogManager.GetLogger(clsInterface4OME.LogFactory.LOGGING_DEST.IN_SOCK.ToString());
//        }


//    }
//    /////////////////////////////////////////////////////////////////////////////////
//    class OutSocketLogger : BaseLogger
//    {
//        public OutSocketLogger()
//        {
//            log = LogManager.GetLogger(clsInterface4OME.LogFactory.LOGGING_DEST.OUT_SOCK.ToString());
//        }



//    }
//    /////////////////////////////////////////////////////////////////////////////////
//    class MyLogger : BaseLogger
//    {
//        public MyLogger()
//        {
//            log = LogManager.GetLogger(clsInterface4OME.LogFactory.LOGGING_DEST.GENERAL.ToString());
//        }



//    }
//    /////////////////////////////////////////////////////////////////////////////////

//}

