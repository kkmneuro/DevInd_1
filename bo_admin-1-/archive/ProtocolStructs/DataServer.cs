using System;
using System.Collections.Generic;
using System.Text;

namespace ProtocolStructs
{
    public class DataServer
    {
        public int _ServerID;
        public string _IP;
        public int _Port;
        public bool _IsLive;
        public string _Priority;
        public string _Description;
        public string _InternalIpServer;
        public string _Loading;

        public DataServer()
        {
            _ServerID = 0;
            _IP = string.Empty;
            _Port = 0;
            _IsLive = false;
            _Priority = string.Empty;
            _Description = string.Empty;
            _InternalIpServer = string.Empty;
            _Loading = string.Empty;
        }
        public override string ToString()
        {
            return
                "_Description->" + _Description +
                "_Internelipserver->" + _InternalIpServer +
                "_IP->" + _IP +
                "_IsLive->" + _IsLive +
                "_Port->" + _Port +
                "_Priority->" + _Priority +
                "_ServerID->" + _ServerID +
                "_Loading->" + _Loading;
        }
    }
}