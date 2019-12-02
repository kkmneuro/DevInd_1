using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtocolStructs
{
    public class Time
    {
        public string _Day;
        public string _TimeSpan;
        public Time()
        {
            _Day = string.Empty;
            _TimeSpan = string.Empty;
        }
        public override string ToString()
        {
            return "_Day->" + _Day +
                "_TimeSpan->" + _TimeSpan;
        }
    }
}
