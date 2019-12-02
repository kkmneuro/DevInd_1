using System;
using System.Collections.Generic;
using System.Text;

namespace ProtocolStructs
{
   public class UserLoginInfo
    {
        public string _Name ;

        public string _Email ;

        public string _MarketType ;

        public string _Currency ;

        public decimal _AccountSize ;

        public string _Leverage ;

        public string _Server ;

        public Int32 _LoginID ;

        public string _Password ;

        public string _Investor ;

        public int _Roleid ;
        public UserLoginInfo()
        {
            _Name  = string.Empty;
            _Email  = string.Empty;
            _MarketType  = string.Empty;
            _Currency  = string.Empty;
            _AccountSize  = 0;
            _Leverage  = string.Empty;
            _Server  = string.Empty;
            _LoginID  = 0;
            _Password  = string.Empty;
            _Investor  = string.Empty;
            _Roleid  = 0;

        }
        public override string ToString()
        {
            return
                "_AccountSize->" + _AccountSize  +
                "_Currency->" + _Currency  +
                "_Email->" + _Email 
                 + "_Investor->" + _Investor 
               + "_MarketType->" + _MarketType  +
                "_Name->" + _Name  +
                "_Password->" + _Password  +
                "_Roleid->" + _Roleid 
                 + "_Server->" + _Server ;

        }

    }
}
