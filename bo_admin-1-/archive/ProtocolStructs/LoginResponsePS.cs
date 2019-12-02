using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using clsInterface4OME;

namespace ProtocolStructs
{
    public class LoginResponsePS : IProtocolStruct
    {
        public LoginResponse LoginResponse_ = new LoginResponse();
        //
        //

        public override int ID
        {
            get { return ProtocolStructIDS.Login_ResponseID; }
        }

        public override void StartWrite(byte[] buffer)
        {
            InitWrite(buffer);
            bw_.Write(LoginResponse_.AuthenticationID);
            bw_.Write(LoginResponse_.TotalAccounts_);
            foreach (string item in LoginResponse_.AccountID_)
            {
                bw_.Write(item);
            }
            bw_.Write(LoginResponse_.PingingTimeInterval);
            bw_.Write(LoginResponse_.HeartBeatToleranceLevel);
            bw_.Write(LoginResponse_.Balance);
            bw_.Write(LoginResponse_.LastOrderId);
            bw_.Write(LoginResponse_.Leverage);
            bw_.Write(LoginResponse_.TotalBuyOpen);
            bw_.Write(LoginResponse_.TotalBuyPrice);
            bw_.Write(LoginResponse_.TotalSellOpen);
            bw_.Write(LoginResponse_.TotalSellPrice);
            bw_.Write(LoginResponse_.UsedMargin);
            bw_.Write(LoginResponse_.OpenBalance);
            bw_.Write(LoginResponse_.Reason);
            bw_.Write(LoginResponse_.MaxLot);
            bw_.Write(LoginResponse_.AccountHolderRoleName);
            bw_.Write(LoginResponse_.ServiceFee);
            bw_.Write(LoginResponse_.MarkUpCommision);
            bw_.Write(LoginResponse_.StorageCharge);
            //>>>Forex
            bw_.Write(LoginResponse_.LiquidationMargin_);
            bw_.Write(LoginResponse_.DailyClosedPL_);
            bw_.Write(LoginResponse_.UsableCapital_);
            bw_.Write(LoginResponse_.MarkUpValue_);
            bw_.Write(LoginResponse_.StandardLot_);
            bw_.Write(LoginResponse_.ServerTime.ToBinary());
            bw_.Write(LoginResponse_.Closed_PnL);
            bw_.Write(LoginResponse_.Reason4Failure);

            CloseWrite();
        }

        public override void StartRead(byte[] buffer)
        {
            InitRead(buffer);
            LoginResponse_.AuthenticationID = br_.ReadString();
            LoginResponse_.TotalAccounts_ = br_.ReadInt32();
            if (LoginResponse_.TotalAccounts_ > 0)
            {
                LoginResponse_.AccountID_ = new string[LoginResponse_.TotalAccounts_];
                for (int i = 0; i < LoginResponse_.AccountID_.Length; i++)
                {
                    LoginResponse_.AccountID_[i] = br_.ReadString();
                }
            }
            LoginResponse_.PingingTimeInterval = br_.ReadInt32();
            LoginResponse_.HeartBeatToleranceLevel = br_.ReadInt32();
            LoginResponse_.Balance = br_.ReadDecimal();
            LoginResponse_.LastOrderId = br_.ReadInt64();
            LoginResponse_.Leverage = br_.ReadString();
            LoginResponse_.TotalBuyOpen = br_.ReadInt32();
            LoginResponse_.TotalBuyPrice = br_.ReadDecimal();
            LoginResponse_.TotalSellOpen = br_.ReadInt32();
            LoginResponse_.TotalSellPrice = br_.ReadDecimal();
            LoginResponse_.UsedMargin = br_.ReadDecimal();
            LoginResponse_.OpenBalance = br_.ReadDecimal();
            LoginResponse_.Reason = br_.ReadString();
            LoginResponse_.MaxLot = br_.ReadInt32();
            LoginResponse_.AccountHolderRoleName = br_.ReadString();
            LoginResponse_.ServiceFee = br_.ReadDouble();
            LoginResponse_.MarkUpCommision = br_.ReadDouble();
            LoginResponse_.StorageCharge = br_.ReadDouble();
            LoginResponse_.LiquidationMargin_ = br_.ReadInt32();
            LoginResponse_.DailyClosedPL_ = br_.ReadDouble();
            LoginResponse_.UsableCapital_ = br_.ReadInt32();
            LoginResponse_.MarkUpValue_ = br_.ReadInt32();
            LoginResponse_.StandardLot_ = br_.ReadInt32();
            LoginResponse_.ServerTime = DateTime.FromBinary(br_.ReadInt64());
            LoginResponse_.Closed_PnL = br_.ReadDecimal();
            LoginResponse_.Reason4Failure = br_.ReadString();

            CloseRead();
        }
        public override void ReadString(string Msgbfr)
        {
            StartStrR(Msgbfr);
            LoginResponse_.AuthenticationID = SpltString[0];
            LoginResponse_.TotalAccounts_ = clsUtility.GetInt(SpltString[1]);
            LoginResponse_.AccountID_ = (string[])clsUtility.String2Object(SpltString[2]);
            LoginResponse_.PingingTimeInterval = clsUtility.GetInt(SpltString[3]);
            LoginResponse_.HeartBeatToleranceLevel = clsUtility.GetInt(SpltString[4]);
            LoginResponse_.Balance = clsUtility.GetDecimal(SpltString[5]);
            LoginResponse_.LastOrderId = clsUtility.GetLong(SpltString[6]);
            LoginResponse_.Leverage = SpltString[7];
            LoginResponse_.TotalBuyOpen = clsUtility.GetInt(SpltString[8]);
            LoginResponse_.TotalBuyPrice = clsUtility.GetDecimal(SpltString[9]);
            LoginResponse_.TotalSellOpen = clsUtility.GetInt(SpltString[10]);
            LoginResponse_.TotalSellPrice = clsUtility.GetDecimal(SpltString[11]);
            LoginResponse_.UsedMargin = clsUtility.GetDecimal(SpltString[12]);
            LoginResponse_.OpenBalance = clsUtility.GetDecimal(SpltString[13]);
            LoginResponse_.Reason = SpltString[14];
            LoginResponse_.MaxLot = clsUtility.GetInt(SpltString[15]);
            LoginResponse_.AccountHolderRoleName = SpltString[16];
            LoginResponse_.ServiceFee = clsUtility.GetDouble(SpltString[17]);
            LoginResponse_.MarkUpCommision = clsUtility.GetDouble(SpltString[18]);
            LoginResponse_.StorageCharge = clsUtility.GetDouble(SpltString[19]);
            LoginResponse_.LiquidationMargin_ = clsUtility.GetInt(SpltString[20]);
            LoginResponse_.DailyClosedPL_ = clsUtility.GetDouble(SpltString[21]);
            LoginResponse_.UsableCapital_ = clsUtility.GetInt(SpltString[22]);
            LoginResponse_.MarkUpValue_ = clsUtility.GetInt(SpltString[23]);
            LoginResponse_.StandardLot_ = clsUtility.GetInt(SpltString[24]);
            LoginResponse_.ServerTime = clsUtility.GetDate4ProtoStru(SpltString[25]);
            LoginResponse_.Closed_PnL = clsUtility.GetDecimal(SpltString[26]);
            LoginResponse_.SessionID = new Guid(SpltString[27]);
            LoginResponse_.Reason4Failure = SpltString[28];
        }
        public override void WriteString()
        {
            StartStrW();
            AppendStr(LoginResponse_.AuthenticationID);
            AppendStr(LoginResponse_.TotalAccounts_);
            AppendStr(clsUtility.Object2String(LoginResponse_.AccountID_));
            AppendStr(LoginResponse_.PingingTimeInterval);
            AppendStr(LoginResponse_.HeartBeatToleranceLevel);
            AppendStr(LoginResponse_.Balance);
            AppendStr(LoginResponse_.LastOrderId);
            AppendStr(LoginResponse_.Leverage);
            AppendStr(LoginResponse_.TotalBuyOpen);
            AppendStr(LoginResponse_.TotalBuyPrice);
            AppendStr(LoginResponse_.TotalSellOpen);
            AppendStr(LoginResponse_.TotalSellPrice);
            AppendStr(LoginResponse_.UsedMargin);
            AppendStr(LoginResponse_.OpenBalance);
            AppendStr(LoginResponse_.Reason);
            AppendStr(LoginResponse_.MaxLot);
            AppendStr(LoginResponse_.AccountHolderRoleName);
            AppendStr(LoginResponse_.ServiceFee);
            AppendStr(LoginResponse_.MarkUpCommision);
            AppendStr(LoginResponse_.StorageCharge);
            AppendStr(LoginResponse_.LiquidationMargin_);
            AppendStr(LoginResponse_.DailyClosedPL_);
            AppendStr(LoginResponse_.UsableCapital_);
            AppendStr(LoginResponse_.MarkUpValue_);
            AppendStr(LoginResponse_.StandardLot_);
            AppendStr(LoginResponse_.ServerTime);
            AppendStr(LoginResponse_.Closed_PnL);
            AppendStr(LoginResponse_.SessionID.ToString());
            AppendStr(LoginResponse_.Reason4Failure);
            EndStrW();
        }

        public override string ToString()
        {

            return LoginResponse_==null?  base.ToString(): LoginResponse_.ToString();
        }

        public override bool ValidateData()
        {
            throw new NotImplementedException();
        }
    }
}
