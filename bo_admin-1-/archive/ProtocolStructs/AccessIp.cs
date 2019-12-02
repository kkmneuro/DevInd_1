using System;
using System.Collections.Generic;
using System.Text;

namespace ProtocolStructs
{
    public class AccessIp
    {
        public Int32 _id;
        public string _FromIp;

        public string _Comment;

        public string _ToIp;

        public string _Stauts;

        public AccessIp()
        {
            _id = 0;
            _FromIp = string.Empty;
            _Comment = string.Empty;
            _ToIp = string.Empty;
            _Stauts = string.Empty;

        }
        public override string ToString()
        {
            return
                "_id->" + _id +
                "_FromIp->" + _FromIp +
                "_Comment->" + _Comment
                 + "_ToIp->" + _ToIp
               + "_Stauts->" + _Stauts;
        }

    }
}
