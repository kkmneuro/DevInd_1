using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtocolStructs
{
    public class Currency
    {
      public int _Currency_ID;
      public string _CurrencyName;
      public string _CurrencyDescription;

      public Currency()
      {
          _Currency_ID=0;
          _CurrencyName=string.Empty;
          _CurrencyDescription=string.Empty; 
      }

      public override string ToString()
      {
          return
            "_Currency_ID->" + _Currency_ID +
            "_CurrencyName->" + _CurrencyName +
            "_CurrencyDescription->" + _CurrencyDescription;
            
      }

    }
}
