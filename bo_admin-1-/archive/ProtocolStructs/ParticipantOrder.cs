using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtocolStructs
{
    public class ParticipantOrder
    {
        public Int64 _ParticipantOrderId;
        public string _TradingOrderId;
        public string _OrderId2;
        public string _LPOrderId;
        public string _LPOrderId1;
        public Int64 _FK_AccountId;
        public string _OrderDateTimeRequested;
        public string _OrderDateTimeFilled;
        public string _Symbol;
        public decimal _PositionSize;
        public decimal _Price;
        public decimal _StopLoss;
        public decimal _TakeProfit;
        public int _OrderType;
        public string _TIF;
        public decimal _Commission;
        public decimal _Swap;
        public decimal _ProfitPIP;
        public decimal _ProfitInUSD;
        public decimal _RealValue;
        public decimal _YourMoneyUsed;
        public string _IPAddress;
        public int _OrderStatusId;
        public string _Status;
        public decimal _CumulativeQuantity;
        public decimal _Price2;
        public int _Side;
        public string _Lots;
        public string _OpenTime;
        public string _ClosedTime;
        public decimal _OpenPrice;
        public decimal _ClosePrice;
        public decimal _MarginRate;
        public decimal _FstConvRate;
        public decimal _SecConvRate;
        public decimal _AgentCommission;
        public decimal _Taxes;
        public string _Comment;
        public decimal _Profit;
        public string _ExpirationDate;
        public string _ValueDate;
        public bool _Deleted;


        public ParticipantOrder()
        {
            _ParticipantOrderId = 0;
            _TradingOrderId = string.Empty;
            _OrderId2 = string.Empty;
            _LPOrderId = string.Empty;
            _LPOrderId1 = string.Empty;
            _FK_AccountId = 0;
            _OrderDateTimeRequested = string.Empty;
            _OrderDateTimeFilled = string.Empty;
            _Symbol = string.Empty;
            _PositionSize = 0;
            _Price = 0;
            _StopLoss = 0;
            _TakeProfit = 0;
            _OrderType = 0;
            _TIF = string.Empty;
            _Commission = 0;
            _Swap = 0;
            _ProfitPIP = 0;
            _ProfitInUSD = 0;
            _RealValue = 0;
            _YourMoneyUsed = 0;
            _IPAddress = string.Empty;
            _OrderStatusId = 0;
            _Status = string.Empty;
            _CumulativeQuantity = 0;
            _Price2 = 0;
            _Side = 0;
            _Lots = string.Empty;
            _OpenTime = string.Empty;
            _ClosedTime = string.Empty;
            _OpenPrice = 0;
            _ClosePrice = 0;
            _MarginRate = 0;
            _FstConvRate = 0;
            _SecConvRate = 0;
            _AgentCommission = 0;
            _Taxes = 0;
            _Comment = string.Empty;
            _Profit = 0;
            _ExpirationDate = string.Empty;
            _ValueDate = string.Empty;
            _Deleted = true;
        }
        public override string ToString()
        {
            return
                "_AgentCommission->" + _AgentCommission +
                "_ClosedTime->" + _ClosedTime +
                "_ClosePrice->" + _ClosePrice +
                "_Comment->" + _Comment +
                "_Commission->" + _Commission +
                "_CumulativeQuantity->" + _CumulativeQuantity +
                "_Deleted->" + _Deleted +
                "_ExpirationDate->" + _ExpirationDate +
                "_FK_AccountId->" + _FK_AccountId +
                "_FstConvRate->" + _FstConvRate +
                "_IPAddress->" + _IPAddress +
                "_Lots->" + _Lots +
                "_LPOrderId->" + _LPOrderId +
                "_LPOrderId1->" + _LPOrderId1 +
                "_MarginRate->" + _MarginRate +
                "_OpenPrice->" + _OpenPrice +
                "_OpenTime->" + _OpenTime +
                "_OrderDateTimeFilled->" + _OrderDateTimeFilled +
                "_OrderDateTimeRequested->" + _OrderDateTimeRequested +
                "_OrderId2->" + _OrderId2 +
                "_OrderStatusId->" + _OrderStatusId +
                "_OrderType->" + _OrderType +
                "_ParticipantOrderId->" + _ParticipantOrderId +
                "_PositionSize->" + _PositionSize +
                "_Price->" + _Price +
                "_Price2->" + _Price2 +
                "_Profit->" + _Profit +
                "_ProfitInUSD->" + _ProfitInUSD +
                "_ProfitPIP->" + _ProfitPIP +
                "_RealValue->" + _RealValue +
                "_SecConvRate->" + _SecConvRate +
                "_Side->" + _Side +
                "_Status->" + _Status +
                "_StopLoss->" + _StopLoss +
                "_Swap->" + _Swap +
                "_Symbol->" + _Symbol +
                "_TakeProfit->" + _TakeProfit +
                "_Taxes->" + _Taxes +
                "_TIF->" + _TIF +
                "_TradingOrderId->" + _TradingOrderId +
                "_ValueDate->" + _ValueDate +
                "_YourMoneyUsed->" + _YourMoneyUsed;
        }

    }
}
