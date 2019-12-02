using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtocolStructs
{
    public class RequestToLoginPS : IProtocolStruct
    {
        public RequestToLogin LoginRequest_ = new RequestToLogin();
        public override int ID
        {
            get { return ProtocolStructIDS.Login_RequestID; }
        }

        public override void StartWrite(byte[] buffer)
        {
            InitWrite(buffer);
            bw_.Write(LoginRequest_.BrokerId_);
            bw_.Write(LoginRequest_.LoginId_);
            bw_.Write(LoginRequest_.Password_);
            bw_.Write(LoginRequest_.Role_);
            CloseWrite();
        }

        public override void StartRead(byte[] buffer)
        {
            InitRead(buffer);
            LoginRequest_.BrokerId_ =Convert.ToInt32(br_.ReadString());
            LoginRequest_.LoginId_ = br_.ReadString();
            LoginRequest_.Password_ = br_.ReadString();
            LoginRequest_.Role_ = br_.ReadString();
            CloseRead();
        }

        public override void WriteString()
        {
            StartStrW();
            AppendStr(LoginRequest_.BrokerId_);
            AppendStr(LoginRequest_.LoginId_);
            AppendStr(LoginRequest_.Password_);
            AppendStr(LoginRequest_.Role_);
            AppendStr(LoginRequest_.IPAddress_);
            EndStrW();
        }

        public override void ReadString(string Msgbfr)
        {
            StartStrR(Msgbfr);
            LoginRequest_.BrokerId_ = Convert.ToInt32(SpltString[0]);
            LoginRequest_.LoginId_ = SpltString[1];
            LoginRequest_.Password_ = SpltString[2];
            LoginRequest_.Role_ = SpltString[3];
            LoginRequest_.IPAddress_ = SpltString[4];
        }

        public override string ToString()
        {
            return LoginRequest_.ToString();
        }

    }
}
