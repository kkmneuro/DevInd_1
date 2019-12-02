using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroXChange.Model
{
    public struct userDetails
    {
        public string UserName;
        public string Password;
        public double Version;
        public string SenderID;
        public int msgtype;
    };

    public struct LogoutRequest
    {
        public string UserName;
        public int msgtype;
    };

    public struct logonResponce
    {
        public string AccountType;
        public string BrokerName;
        public int IsLive;
        public string Reason;
        public int msgtype;
    };

    public struct SocketResponce
    {
        public int msgtype;
    };
}
