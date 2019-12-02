using System;
using System.Collections.Generic;
using System.Text;

namespace ProtocolStructs
{
    public class Chart
    {
        public int _Id;
        public DateTime _Time;
        public decimal _Open;
        public decimal _High;
        public decimal _Low;
        public decimal _Close;
        public decimal _Volume;
        public Chart()
        {
            _Id = 0;
            _Time = DateTime.Now;
            _Open = 0;
            _High = 0;
            _Low = 0;
            _Close = 0;
            _Volume = 0;
        }
        public override string ToString()
        {
            return
                "->" + _Close +
                "->" + _High +
                "->" + _Id +
                "->" + _Low +
                "->" + _Open +
                "->" + _Time +
                "->" + _Volume;
        }
    }
}