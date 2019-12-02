using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtocolStructs
{
    public class DBResponse
    {
        public int _ResponseID;
        public bool _Status;
        public string _StatusMessage;
        public string _DataKey;

        public DBResponse()
        {
             _ResponseID = 0;
             _Status = false;
             _StatusMessage = string.Empty;
             _DataKey = string.Empty;
        }

        public override string ToString()
        {
            string str = "DBResponse: _ResponseID-> " + _ResponseID.ToString() +
                         "_Status-> " + _Status.ToString() +
                         "_DataKey-> "+_DataKey.ToString()+
                         "_StatusMessage-> " + _StatusMessage;


            return str;
        }
    }
}
