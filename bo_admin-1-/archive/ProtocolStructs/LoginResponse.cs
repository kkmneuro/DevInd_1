using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtocolStructs
{
    public class LoginResponse
    {
        //>> fOREX
        public int LiquidationMargin_;
        public double DailyClosedPL_;
        public int UsableCapital_;
        public int MarkUpValue_;
        public int StandardLot_;
        //<<<<
        public int TotalAccounts_;
        public string[] AccountID_;
        public string AuthenticationID;
        public decimal Balance;
        public decimal OpenBalance;
        public long LastOrderId;
        public string Leverage;

        public int TotalBuyOpen;
        public decimal TotalBuyPrice;
        public int TotalSellOpen;
        public decimal TotalSellPrice;
        public decimal UsedMargin;
        public string Reason;
        public string Reason4Failure;
        public int MaxLot;
        public string AccountHolderRoleName;
        public double ServiceFee;
        public double MarkUpCommision;
        public double StorageCharge;

        public int PingingTimeInterval;
        public int HeartBeatToleranceLevel;
        public DateTime ServerTime;
        public decimal Closed_PnL;
        public Guid SessionID;

        public LoginResponse()
        {
            TotalAccounts_ = 0;
            AccountID_ = new string[10];
            AuthenticationID = string.Empty;
            Balance = 0;
            LastOrderId = 0;
            Leverage = string.Empty;
            TotalBuyOpen = 0;
            TotalBuyPrice = 0;
            TotalSellOpen = 0;
            TotalSellPrice = 0;
            UsedMargin = 0;
            OpenBalance = 0;
            Reason = string.Empty;
            MaxLot = 0;
            AccountHolderRoleName = string.Empty;
            ServiceFee = 0;
            MarkUpCommision = 0;
            StorageCharge = 0;
            PingingTimeInterval = 11000;
            //>>>Forex
            LiquidationMargin_ = 0; ;
            DailyClosedPL_ = 0;
            UsableCapital_ = 0;
            MarkUpValue_ = 0;
            StandardLot_ = 0;
            HeartBeatToleranceLevel = 13000;
            ServerTime = DateTime.UtcNow;
            Closed_PnL = 0;
            SessionID = Guid.Empty;
        }
        public override string ToString()
        {
            return
               "AccountHolderRoleName ->" + AccountHolderRoleName
              + "AccountID_ ->" + AccountID_
              + "AuthenticationID ->" + AuthenticationID
              + "Balance ->" + Balance
              + "Closed_PnL ->" + Closed_PnL
            + "DailyClosedPL_ ->" + DailyClosedPL_
            + "HeartBeatToleranceLevel ->" + HeartBeatToleranceLevel
            + "LastOrderId ->" + LastOrderId
            + "Leverage ->" + Leverage
            + "LiquidationMargin_ ->" + LiquidationMargin_
            + "MarkUpCommision ->" + MarkUpCommision
            + "MarkUpValue_ ->" + MarkUpValue_
            + "MaxLot ->" + MaxLot
            + "OpenBalance ->" + OpenBalance
            + "PingingTimeInterval ->" + PingingTimeInterval
            + "Reason ->" + Reason
            + "ServerTime ->" + ServerTime
            + "ServiceFee ->" + ServiceFee
            + "StandardLot_ ->" + StandardLot_
            + "StorageCharge ->" + StorageCharge
            + "TotalBuyOpen ->" + TotalBuyOpen
            + "TotalBuyPrice ->" + TotalBuyPrice
            + "TotalSellOpen ->" + TotalSellOpen
            + "TotalSellPrice ->" + TotalSellPrice
            + "TotalAccounts_ ->" + TotalAccounts_
            + "UsableCapital_ ->" + UsableCapital_
            + "UsedMargin ->" + UsedMargin;
        }
    }
}
