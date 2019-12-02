using System;
using System.Collections.Generic;
using System.Text;

namespace ProtocolStructs
{
    public class Holiday
    {
        public DateTime _Day;
        public string _FromTime;
        public string _ToTime;
        public string _Symbol;
        public string _Description;
        public int _Id;
        public bool _IsEnable;
        public bool _IsEveryYear;

        public Holiday()
        {
            _Day = DateTime.Now;
            _Description = string.Empty;
            _FromTime = string.Empty;
            _Id = 0;
            _IsEnable = true;
            _IsEveryYear = true;
            _Symbol = string.Empty;
            _ToTime = string.Empty;
         
        }
        public override string ToString()
        {
            return
                "_Day->" + _Day +
                "_Description->" + _Description +
                "_FromTime->" + _FromTime +
                "_Id->" + _Id +
                "_IsEnable->" + _IsEnable +
                "_IsEveryYear->" + _IsEveryYear +
                "_Symbol->" + _Symbol +
                "_ToTime->" + _ToTime;
        }

    }
}
