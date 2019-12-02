using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtocolStructs
{
    public class LiveUpdate
    {
        public int _LiveUpdateId;
        public bool _IsEnable;
        public string _Company;
        public string _Type;
        public int _MaximumConnections;
        public string _Folder;
        public string _Version;
        public LiveUpdate()
        {
            _Company = string.Empty;
            _Folder = string.Empty;
            _IsEnable = true;
            _LiveUpdateId = 0;
            _MaximumConnections = 0;
            _Type = string.Empty;
            _Version = string.Empty;
        }
        public override string ToString()
        {
            return
              "_Company->" + _Company +
              "_Folder->" + _Folder +
              "_IsEnable->" + _IsEnable +
              "_LiveUpdateId->" + _LiveUpdateId +
              "_MaximumConnections->" + _MaximumConnections +
              "_Type->" + _Type +
              "_Version->" + _Version;
        }
    }
}
