using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using clsInterface4OME;

namespace ProtocolStructs
{
    public class LogOutPS : IProtocolStruct
    {
        //public Guid SessionID; 
        public string AccountID_;
        public SvrlMSG Msg;

        public LogOutPS()
        {
            //SessionID = Guid.Empty;
            AccountID_ = "0";
            Msg = SvrlMSG.NA;
        }

        public override int ID
        {
            get { return ProtocolStructIDS.LogOut_ID; }
        }

        public override void StartWrite(byte[] buffer)
        {
            //InitWrite(buffer);            
            //bw_.Write(logOut.GuID.ToString());
            //bw_.Write(logOut.ClientID_);
            //bw_.Write(logOut.Msg.ToString());
            //CloseWrite();
        }

        public override void StartRead(byte[] buffer)
        {
            //InitRead(buffer);
            //logOut.GuID = br_.ReadString().ToString();
            //CloseRead();
        }

        public override void ReadString(string Msgbfr)
        {
            StartStrR(Msgbfr);
            //this.SessionID = new Guid(SpltString[0]);
            this.AccountID_ = SpltString[0];
            this.Msg = (SvrlMSG)Enum.Parse(typeof(SvrlMSG), SpltString[1]);
        }

        public override void WriteString()
        {
            StartStrW();
            //AppendStr(this.SessionID.ToString());
            AppendStr(this.AccountID_);
            AppendStr(this.Msg.ToString());
            EndStrW();
        }


        public override bool ValidateData()
        {
            throw new NotImplementedException();
        }
    }
}
