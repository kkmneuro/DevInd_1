using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtocolStructs
{
    public class BrokerType
    {
     public int _BrokerTypesID;
     public string _BrokerType;
     public string _Description;
     public BrokerType()
     { 
     _BrokerTypesID=0;
     _BrokerType=string.Empty;
     _Description=string.Empty;
     }
     public override string ToString()
     {
         return
          "_BrokerTypesID->" + _BrokerTypesID +
             "_BrokerType->" + _BrokerType +
             "_Description->" + _Description;
     }
    }
}
