using System;

namespace Logging
{
    public class Message
    {
        private DateTime _requestTime;
        internal string txtmsg;
        internal LogType type;

        public Message(LogType logtype, DateTime dt, string msg)
        {
            type = logtype;
            txtmsg = msg;
            _requestTime = dt;
        }

        public override string ToString()
        {
            return _requestTime.ToString("hh:mm:ss tt dd/MM/yyyy") + " => " + txtmsg;
        }
    }

    public enum LogType
    {
        INFO,
        ERROR,
        IN,
        OUT,
        IN_OUT,
        LOG,
        DEVELOPMENT
    }
}