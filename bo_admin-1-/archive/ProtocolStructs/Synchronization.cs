using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtocolStructs
{
    public class Synchronization
    {
        public int _SynchronizationId;
        public bool _IsEnable;
        public enum MODE
        {
            Add = 1,
            Update,
            Replace,
            NA
        }
        public string _Server;
        public string _Symbols;
        public bool _IsLimits;
        public DateTime _StartDate;
        public MODE _Mode;
        public DateTime _EndDate;

        public Synchronization()
        {
            _EndDate = DateTime.Now;
            _IsEnable = true;
            _IsLimits = true;
            _Server = string.Empty;
            _StartDate = DateTime.Now;
            _Symbols = string.Empty;
            _SynchronizationId = 0;
            _Mode = MODE.NA;           

        }
        public override string ToString()
        {
            return
                "_EndDate->" + _EndDate +
                "_IsEnable->" + _IsEnable +
                "_IsLimits->" + _IsLimits +
                "_Mode->" + _Mode +
                "_Server->" + _Server +
                "_StartDate->" + _StartDate +
                "_Symbols->" + _Symbols +
                "__SynchronizationId->" + _SynchronizationId;
        }

    }
}
