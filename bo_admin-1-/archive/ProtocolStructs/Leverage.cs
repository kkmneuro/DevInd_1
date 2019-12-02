using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtocolStructs
{
    public class Leverage
    {
       public int _LeverageId;
       public string _Leverage;
       public Leverage()
       {
          _LeverageId=0;
           _Leverage=string.Empty;
       }
       public override string ToString()
       {
           return
            "_LeverageId->" + _LeverageId +
            "_Leverage->" + _Leverage;
       }
    }
}
