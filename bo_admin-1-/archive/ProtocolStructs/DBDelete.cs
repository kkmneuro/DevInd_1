using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtocolStructs
{
    public class DBDelete
    {
        public int _DeleteID;
        public string _DeleteKey;

        public DBDelete()
        {
            _DeleteID = 0;
            _DeleteKey = string.Empty;
        }

        public override string ToString()
        {
            string str = "DBDelete: _DeleteID-> " + _DeleteID.ToString() +
                         "_DeleteKey-> " + _DeleteKey.ToString();
            return str;
        }
    }
}
