using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtocolStructs.NewPS
{
     public class TaxMaster
    {
        public int _TaxID;
        public string _TaxName;
        public decimal _TaxPercent;
        public string _Amount;
        public string _Description;

        public TaxMaster()
        {
            _TaxID = 0;
            _TaxName = string.Empty;
            _TaxPercent = 0;
            _Amount = string.Empty;
            _Description = string.Empty;

        }

        public override string ToString()
        {
            return
            "_TaxID->" + _TaxID +
            "_TaxName->" + _TaxName +
            "_TaxPercent->" + _TaxPercent +
            "_Amount->" + _Amount +
            "_Description->" + _Description;

        }
    }
}
