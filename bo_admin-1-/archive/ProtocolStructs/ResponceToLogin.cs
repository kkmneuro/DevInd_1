using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtocolStructs
{
    public class ResponceToLogin
    {
        public int BrokerId_;
        public string LoginID_;
        public string Role_;
        public string Reason4Failure_;
        public DateTime ServerTime;
        public int PingingTimeInterval;
        public int HeartBeatToleranceLevel;
        public string BrokerName_;
        public int BrokerNameID_;
        public string BrokerCompany_;
        public bool IsEnable_;
        //public Guid SessionID;


        public ResponceToLogin()
        {
            BrokerId_ = 0;
            LoginID_ = string.Empty;
            Role_ = string.Empty;
            Reason4Failure_ = string.Empty;
            ServerTime = DateTime.UtcNow;
            PingingTimeInterval = 11000;
            HeartBeatToleranceLevel = 13000;
            BrokerName_ = string.Empty;
            BrokerNameID_ = 0;
            BrokerCompany_ = string.Empty;
            //SessionID = Guid.Empty;
        }
        public override string ToString()
        {
            return
               "BrokerId_ ->" + BrokerId_
              + "LoginID_ ->" + LoginID_
              + "Role_ ->" + Role_
              + "Reason4Failure_ ->" + Reason4Failure_
              + "ServerTime ->" + ServerTime
            + "PingingTimeInterval ->" + PingingTimeInterval
            + "HeartBeatToleranceLevel ->" + HeartBeatToleranceLevel +
            "BrokerName_ :" + BrokerName_ +
                   "BrokerNameID_ :" + BrokerNameID_+
                   "BrokerCompany_->" + BrokerCompany_;
            //+ "SessionID ->" + SessionID;

        }
    }
}
