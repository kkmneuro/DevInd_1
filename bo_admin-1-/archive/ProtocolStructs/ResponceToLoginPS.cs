using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using clsInterface4OME;

namespace ProtocolStructs
{
    public class ResponceToLoginPS : IProtocolStruct
    {
        public ResponceToLogin ResponceToLogin_ = null;
        public ResponceToLoginPS()
        {
            ResponceToLogin_ = new ResponceToLogin();
        }
        public override int ID
        {
            get { return ProtocolStructIDS.Login_ResponseID; }
        }

        public override void StartWrite(byte[] buffer)
        {
            //throw new NotImplementedException();
        }

        public override void StartRead(byte[] buffer)
        {
            //throw new NotImplementedException();
        }

        public override void WriteString()
        {
            StartStrW();
            AppendStr(ResponceToLogin_.BrokerId_);
            AppendStr(ResponceToLogin_.HeartBeatToleranceLevel);
            AppendStr(ResponceToLogin_.LoginID_);
            AppendStr(ResponceToLogin_.PingingTimeInterval);
            AppendStr(ResponceToLogin_.Reason4Failure_);
            AppendStr(ResponceToLogin_.Role_);
            AppendStr(ResponceToLogin_.ServerTime);
            //AppendStr(clsUtility.Object2String(ResponceToLogin_.SessionID));
            AppendStr(ResponceToLogin_.BrokerName_);
            AppendStr(ResponceToLogin_.BrokerNameID_);
            EndStrW();
        }

        public override void ReadString(string Msgbfr)
        {
            StartStrR(Msgbfr);
            ResponceToLogin_.BrokerId_ = clsUtility.GetInt(SpltString[0]);
            ResponceToLogin_.HeartBeatToleranceLevel = clsUtility.GetInt(SpltString[1]);
            ResponceToLogin_.LoginID_ = SpltString[2];
            ResponceToLogin_.PingingTimeInterval = clsUtility.GetInt(SpltString[3]);
            ResponceToLogin_.Reason4Failure_ = SpltString[4];
            ResponceToLogin_.Role_ = SpltString[5];
            ResponceToLogin_.ServerTime = clsUtility.GetDate4ProtoStru(SpltString[6]);
            //ResponceToLogin_.SessionID = new Guid(SpltString[7]);
            ResponceToLogin_.BrokerName_ = SpltString[7];
            ResponceToLogin_.BrokerNameID_ = Convert.ToInt32(SpltString[8]);
        }

        public override string ToString()
        {

            return ResponceToLogin_ == null ? base.ToString() : ResponceToLogin_.ToString();
        }

        public override bool ValidateData()
        {
            throw new NotImplementedException();
        }
    }
}
