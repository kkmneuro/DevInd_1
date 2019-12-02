using System;
using System.Collections.Generic;
using System.Text;

namespace ProtocolStructs
{
    public class DataFeeds
    {
        public bool _IsEnable;
        public int _Id;
        public string _Password;
        public Int64 _LoginID;
        public string _Vendor;
        public string _Source;
        public string _Server;
        public string _File;
        public string _KeyWords;
        public int _IdleTimeOut;
        public int _ReconnectAfter;
        public int _SleepFor;
        public int _Attempts;
        public string _Description;
        public string _Journal;

        public DataFeeds()
        {
            _IsEnable = true;
            _Id = 0;
            _LoginID = 0;
            _Vendor = string.Empty;
            _Source = string.Empty;
            _Server = string.Empty;
            _File = string.Empty;
            _KeyWords = string.Empty;
            _IdleTimeOut = 0;
            _ReconnectAfter = 0;
            _SleepFor = 0;
            _Attempts = 0;
            _Description = string.Empty;
            _Journal = string.Empty;
        }
        public override string ToString()
        {
            return
                "_Attempts->" + _Attempts +
                "_Description->" + _Description +
                "_File->" + _File +
                "_Id->" + _Id +
                "_IdleTimeOut->" + _IdleTimeOut +
                "_IsEnable->" + _IsEnable +
                "_Journal->" + _Journal +
                "_KeyWords->" + _KeyWords +
                "_LoginID->" + _LoginID +
                "_Password->" + _Password +
                "_ReconnectAfter->" + _ReconnectAfter +
                "_Server->" + _Server +
                "_SleepFor->" + _SleepFor +
                "_Source->" + _Source +
                "_Vendor->" + _Vendor;
        }
    }
}