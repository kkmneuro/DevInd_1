using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using clsInterface4OME;

namespace ProtocolStructs
{
    public class LoginRequestPS : IProtocolStruct
    {

        public LoginRequest LoginRequest_ = new LoginRequest();
        //
        //

        public override int ID
        {
            get { return ProtocolStructIDS.Login_RequestID; }
        }

        public override void StartWrite(byte[] buffer)
        {
            InitWrite(buffer);
            bw_.Write(LoginRequest_.UserName_);
            bw_.Write(LoginRequest_.PassWord_);
            bw_.Write(LoginRequest_.SenderCompID_);
            bw_.Write(LoginRequest_.TargetCompID_);
            bw_.Write(LoginRequest_.userType_.ToString());
            bw_.Write(LoginRequest_.LP_);
            bw_.Write(LoginRequest_.ClientVersion.ToString());
            CloseWrite();
        }

        public override void StartRead(byte[] buffer)
        {
            InitRead(buffer);
            LoginRequest_.UserName_ = br_.ReadString();
            LoginRequest_.PassWord_ = br_.ReadString();
            LoginRequest_.SenderCompID_ = br_.ReadString();
            LoginRequest_.TargetCompID_ = br_.ReadString();
            LoginRequest_.userType_ = (UserType)Enum.Parse(typeof(UserType), br_.ReadString(), true);
            LoginRequest_.LP_ = br_.ReadString();
            LoginRequest_.ClientVersion = new Version(br_.ReadString());
            CloseRead();
        }
        public override void ReadString(string Msgbfr)
        {
            StartStrR(Msgbfr);
            LoginRequest_.UserName_ = SpltString[0];
            LoginRequest_.PassWord_ = SpltString[1];
            LoginRequest_.SenderCompID_ = SpltString[2];
            LoginRequest_.TargetCompID_ = SpltString[3];
            LoginRequest_.userType_ = (UserType)Enum.Parse(typeof(UserType), SpltString[4], true);
            LoginRequest_.LP_ = SpltString[5];
            LoginRequest_.ClientVersion = new Version(SpltString[6]);
        }
        public override void WriteString()
        {
            StartStrW();
            AppendStr(LoginRequest_.UserName_);
            AppendStr(LoginRequest_.PassWord_);
            AppendStr(LoginRequest_.SenderCompID_);
            AppendStr(LoginRequest_.TargetCompID_);
            AppendStr(LoginRequest_.userType_.ToString());
            AppendStr(LoginRequest_.LP_);
            AppendStr(LoginRequest_.ClientVersion);
            EndStrW();

        }
        public override string ToString()
        {
            return LoginRequest_.ToString();
        }

        public override bool ValidateData()
        {
            throw new NotImplementedException();
        }
    }
    public class LoginRequest
    {
        public string UserName_;
        public string PassWord_;
        public string SenderCompID_;
        public string TargetCompID_;
        public string LP_;
        public UserType userType_;
        public Version ClientVersion;

        public LoginRequest()
        {
            UserName_ = string.Empty;
            PassWord_ = string.Empty;
            SenderCompID_ = string.Empty;
            TargetCompID_ = string.Empty;
            LP_ = "FORTEX";
            userType_ = UserType.NA;
            ClientVersion = new Version("1.0.0.0");
        }
        public override string ToString()
        {
            return "UserName : " + UserName_+
                   " Password: " + PassWord_+
                   " SenderCompID: " + SenderCompID_+
                   "TargetCompID: " + TargetCompID_+
                   " LP: " + LP_+
                   " UserType: "+userType_.ToString();
        }
    }
}
