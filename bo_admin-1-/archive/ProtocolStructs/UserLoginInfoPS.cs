using System;
using System.Collections.Generic;
using System.Text;
using clsInterface4OME;
namespace ProtocolStructs
{
    public class UserLoginInfoPS : IProtocolStruct 
    {
       public UserLoginInfo UserLogin = new UserLoginInfo();
       public UserLoginInfoPS()
       {
           UserLogin = new UserLoginInfo();
       }

       public UserLoginInfoPS(UserLoginInfo deepCopy)
        {
            UserLogin._AccountSize = deepCopy._AccountSize;
            UserLogin._Currency = deepCopy._Currency;
            UserLogin._Email = deepCopy._Email;
            UserLogin._Investor = deepCopy._Investor;
            UserLogin._Leverage = deepCopy._Leverage;
            UserLogin._LoginID = deepCopy._LoginID;
            UserLogin._MarketType = deepCopy._MarketType;
            UserLogin._Name = deepCopy._Name;
            UserLogin._Password = deepCopy._Password;
            UserLogin._Roleid = deepCopy._Roleid;
            UserLogin._Server = deepCopy._Server;
            
        }

        public override int ID
        {
            get { return ProtocolStructIDS.UserLogin_ID; }

        }

        public override void StartWrite(byte[] buffer)
        {
            throw new NotImplementedException();
        }

        public override void StartRead(byte[] buffer)
        {
            throw new NotImplementedException();
        }
        public override void WriteString()
        {
            StartStrW();
            AppendStr(UserLogin._AccountSize );
            AppendStr(UserLogin._Currency );
            AppendStr(UserLogin._Email );
            AppendStr(UserLogin._Investor );
            AppendStr(UserLogin._Leverage );
            AppendStr(UserLogin._LoginID );
            AppendStr(UserLogin._MarketType );
            AppendStr(UserLogin._Name );
            AppendStr(UserLogin._Password );
            AppendStr(UserLogin._Roleid );
            AppendStr(UserLogin._Server );
            
            EndStrW();
        }

        public override void ReadString(string Msgbfr)
        {
            StartStrR(Msgbfr);
             UserLogin._AccountSize =clsUtility.GetDecimal(SpltString[0]);
             UserLogin._Currency =SpltString[1];
             UserLogin._Email =SpltString[2];
             UserLogin._Investor =SpltString[3];
             UserLogin._Leverage =SpltString[4];
             UserLogin._LoginID =clsUtility.GetInt(SpltString[5]);
             UserLogin._MarketType =SpltString[6];
             UserLogin._Name =SpltString[7];
             UserLogin._Password =SpltString[8];
             UserLogin._Roleid =clsUtility.GetInt(SpltString[9]);
             UserLogin._Server  = SpltString[10];
            
        }
        public override string ToString()
        {
            return UserLogin==null?base.ToString():UserLogin.ToString();
        }

        public override bool ValidateData()
        {
            throw new NotImplementedException();
        }
    }
}
