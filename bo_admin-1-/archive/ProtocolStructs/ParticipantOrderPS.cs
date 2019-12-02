using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using clsInterface4OME;

namespace ProtocolStructs
{
    public class ParticipantOrderPS :IProtocolStruct
    {
        public ParticipantOrder _ParticipantOrder;
        public ParticipantOrderPS()
        {
            _ParticipantOrder = new ParticipantOrder();
        }
        public ParticipantOrderPS(ParticipantOrder deepCopy)
        {
            _ParticipantOrder._AgentCommission = deepCopy._AgentCommission;
            _ParticipantOrder._ClosedTime = deepCopy._ClosedTime;
            _ParticipantOrder._ClosePrice = deepCopy._ClosePrice;
            _ParticipantOrder._Comment = deepCopy._Comment;
            _ParticipantOrder._Commission = deepCopy._Commission;
            _ParticipantOrder._CumulativeQuantity = deepCopy._CumulativeQuantity;
            _ParticipantOrder._Deleted= deepCopy._Deleted;
            _ParticipantOrder._ExpirationDate = deepCopy._ExpirationDate;
            _ParticipantOrder._FK_AccountId = deepCopy._FK_AccountId;
            _ParticipantOrder._FstConvRate = deepCopy._FstConvRate;
            _ParticipantOrder._IPAddress = deepCopy._IPAddress;
            _ParticipantOrder._Lots= deepCopy._Lots;
            _ParticipantOrder._LPOrderId = deepCopy._LPOrderId;
            _ParticipantOrder._LPOrderId1 = deepCopy._LPOrderId1;
            _ParticipantOrder._MarginRate= deepCopy._MarginRate;
            _ParticipantOrder._OpenPrice = deepCopy._OpenPrice;
            _ParticipantOrder._OpenTime = deepCopy._OpenTime;
            _ParticipantOrder._OrderDateTimeFilled = deepCopy._OrderDateTimeFilled;
            _ParticipantOrder._OrderDateTimeRequested = deepCopy._OrderDateTimeRequested;
            _ParticipantOrder._OrderId2 = deepCopy._OrderId2;
            _ParticipantOrder._OrderStatusId = deepCopy._OrderStatusId;
            _ParticipantOrder._OrderType = deepCopy._OrderType;
            _ParticipantOrder._ParticipantOrderId = deepCopy._ParticipantOrderId;
            _ParticipantOrder._PositionSize = deepCopy._PositionSize;
            _ParticipantOrder._Price = deepCopy._Price;
            _ParticipantOrder._Price2 = deepCopy._Price2;
            _ParticipantOrder._Profit = deepCopy._Profit;
            _ParticipantOrder._ProfitInUSD = deepCopy._ProfitInUSD;
            _ParticipantOrder._ProfitPIP = deepCopy._ProfitPIP;
            _ParticipantOrder._RealValue = deepCopy._RealValue;
            _ParticipantOrder._SecConvRate = deepCopy._SecConvRate;
            _ParticipantOrder._Side= deepCopy._Side;
            _ParticipantOrder._Status = deepCopy._Status;
            _ParticipantOrder._StopLoss = deepCopy._StopLoss;
            _ParticipantOrder._Swap = deepCopy._Swap;
            _ParticipantOrder._Symbol = deepCopy._Symbol;
            _ParticipantOrder._TakeProfit = deepCopy._TakeProfit;
            _ParticipantOrder._Taxes = deepCopy._Taxes;
            _ParticipantOrder._TIF = deepCopy._TIF;
            _ParticipantOrder._TradingOrderId = deepCopy._TradingOrderId;
            _ParticipantOrder._ValueDate = deepCopy._ValueDate;
            _ParticipantOrder._YourMoneyUsed = deepCopy._YourMoneyUsed;
        }
        public override int ID
        {
            get { return ProtocolStructIDS.ParticipantOrder_ID ; }
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
            AppendStr(_ParticipantOrder._AgentCommission);
            AppendStr(_ParticipantOrder._ClosedTime);
            AppendStr(_ParticipantOrder._ClosePrice);
            AppendStr(_ParticipantOrder._Comment);
            AppendStr(_ParticipantOrder._Commission);
            AppendStr(_ParticipantOrder._CumulativeQuantity);
            AppendStr(_ParticipantOrder._Deleted);
            AppendStr(_ParticipantOrder._ExpirationDate);
            AppendStr(_ParticipantOrder._FK_AccountId);
            AppendStr(_ParticipantOrder._FstConvRate);
            AppendStr(_ParticipantOrder._IPAddress);
            AppendStr(_ParticipantOrder._Lots);
            AppendStr(_ParticipantOrder._LPOrderId);
            AppendStr(_ParticipantOrder._LPOrderId1);
            AppendStr(_ParticipantOrder._MarginRate);
            AppendStr(_ParticipantOrder._OpenPrice);
            AppendStr(_ParticipantOrder._OpenTime);
            AppendStr(_ParticipantOrder._OrderDateTimeFilled);
            AppendStr(_ParticipantOrder._OrderDateTimeRequested);
            AppendStr(_ParticipantOrder._OrderId2);
            AppendStr(_ParticipantOrder._OrderStatusId);
            AppendStr(_ParticipantOrder._OrderType);
            AppendStr(_ParticipantOrder._ParticipantOrderId);
            AppendStr(_ParticipantOrder._PositionSize);
            AppendStr(_ParticipantOrder._Price);
            AppendStr(_ParticipantOrder._Price2);
            AppendStr(_ParticipantOrder._Profit);
            AppendStr(_ParticipantOrder._ProfitInUSD);
            AppendStr(_ParticipantOrder._ProfitPIP);
            AppendStr(_ParticipantOrder._RealValue);
            AppendStr(_ParticipantOrder._SecConvRate);
            AppendStr(_ParticipantOrder._Side);
            AppendStr(_ParticipantOrder._Status);
            AppendStr(_ParticipantOrder._StopLoss);
            AppendStr(_ParticipantOrder._Swap);
            AppendStr(_ParticipantOrder._Symbol);
            AppendStr(_ParticipantOrder._TakeProfit);
            AppendStr(_ParticipantOrder._Taxes);
            AppendStr(_ParticipantOrder._TIF);
            AppendStr(_ParticipantOrder._TradingOrderId);
            AppendStr(_ParticipantOrder._ValueDate);
            AppendStr(_ParticipantOrder._YourMoneyUsed);
            EndStrW();
        }

        public override void ReadString(string Msgbfr)
        {
            StartStrR(Msgbfr);
             _ParticipantOrder._AgentCommission =clsUtility.GetDecimal(SpltString[0]);
             _ParticipantOrder._ClosedTime = SpltString[1];
             _ParticipantOrder._ClosePrice = clsUtility.GetDecimal(SpltString[2]);
             _ParticipantOrder._Comment = SpltString[3];
             _ParticipantOrder._Commission = clsUtility.GetDecimal(SpltString[4]);
             _ParticipantOrder._CumulativeQuantity = clsUtility.GetDecimal(SpltString[5]);
             _ParticipantOrder._Deleted = Convert.ToBoolean(SpltString[6]);
             _ParticipantOrder._ExpirationDate = SpltString[7];
             _ParticipantOrder._FK_AccountId = clsUtility.GetLong(SpltString[8]);
             _ParticipantOrder._FstConvRate = clsUtility.GetDecimal(SpltString[9]);
             _ParticipantOrder._IPAddress = SpltString[10];
             _ParticipantOrder._Lots = SpltString[11];
             _ParticipantOrder._LPOrderId =SpltString[12];
             _ParticipantOrder._LPOrderId1 = SpltString[13];
             _ParticipantOrder._MarginRate = clsUtility.GetDecimal(SpltString[14]);
             _ParticipantOrder._OpenPrice = clsUtility.GetDecimal(SpltString[15]);
             _ParticipantOrder._OpenTime= SpltString[16];
             _ParticipantOrder._OrderDateTimeFilled =SpltString[17];
             _ParticipantOrder._OrderDateTimeRequested = SpltString[18];
             _ParticipantOrder._OrderId2 = SpltString[19];
             _ParticipantOrder._OrderStatusId = clsUtility.GetInt(SpltString[20]);
             _ParticipantOrder._OrderType = clsUtility.GetInt(SpltString[21]);
             _ParticipantOrder._ParticipantOrderId =clsUtility.GetLong(SpltString[22]);
             _ParticipantOrder._PositionSize =clsUtility.GetDecimal(SpltString[23]);
             _ParticipantOrder._Price = clsUtility.GetDecimal(SpltString[24]);
             _ParticipantOrder._Price2 = clsUtility.GetDecimal(SpltString[25]);
             _ParticipantOrder._Profit = clsUtility.GetDecimal(SpltString[26]);
             _ParticipantOrder._ProfitInUSD = clsUtility.GetDecimal(SpltString[27]);
             _ParticipantOrder._ProfitPIP = clsUtility.GetDecimal(SpltString[28]);
             _ParticipantOrder._RealValue = clsUtility.GetDecimal(SpltString[29]);
             _ParticipantOrder._SecConvRate = clsUtility.GetDecimal(SpltString[30]);
             _ParticipantOrder._Side = clsUtility.GetInt(SpltString[31]);
             _ParticipantOrder._Status = SpltString[32];
             _ParticipantOrder._StopLoss = clsUtility.GetDecimal(SpltString[33]);
             _ParticipantOrder._Swap = clsUtility.GetDecimal(SpltString[34]);
             _ParticipantOrder._Symbol = SpltString[35];
             _ParticipantOrder._TakeProfit =clsUtility.GetDecimal(SpltString[36]);
             _ParticipantOrder._Taxes =clsUtility.GetDecimal(SpltString[37]);
             _ParticipantOrder._TIF = SpltString[38];
             _ParticipantOrder._TradingOrderId= SpltString[39];
             _ParticipantOrder._ValueDate = SpltString[40];
             _ParticipantOrder._YourMoneyUsed = clsUtility.GetDecimal(SpltString[41]);

        }
        public override string ToString()
        {

            return _ParticipantOrder==null?base.ToString():_ParticipantOrder.ToString();
        }

       
        public override bool ValidateData()
        {
           base.ValidateData();
           Add2Vld("Closed Time", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty(_ParticipantOrder._ClosedTime));
           Add2Vld("Comment", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty(_ParticipantOrder._Comment));
           Add2Vld("Expiration Date", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty(_ParticipantOrder._ExpirationDate));
           Add2Vld("Lots", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty(_ParticipantOrder._Lots));
           //Add2Vld("IP Address", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty(_ParticipantOrder._IPAddress));
           //Add2Vld("IP Address not valid", clsInterface4OME.clsUtil4ProtoVali.ValidateIP(_ParticipantOrder._IPAddress));
           //Add2Vld("LPOrderId", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty(_ParticipantOrder._LPOrderId));
           //Add2Vld("LPorderId1", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty(_ParticipantOrder._LPOrderId1));
           Add2Vld("Open Time", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty(_ParticipantOrder._OpenTime));
           //Add2Vld("Order Id2", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty(_ParticipantOrder._OrderId2));
           //Add2Vld("Status", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty(_ParticipantOrder._Status));
           Add2Vld("Symbol", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty(_ParticipantOrder._Symbol ));
           //Add2Vld("TIF", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty(_ParticipantOrder._TIF));
           Add2Vld("Trading Order Id", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty(_ParticipantOrder._TradingOrderId ));
           Add2Vld("Value Date", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty(_ParticipantOrder._ValueDate));
           DateTime OpenTime = clsUtility.GetDate(_ParticipantOrder._OpenTime);
           DateTime CloseTime = clsUtility.GetDate(_ParticipantOrder._ClosedTime);
           Add2Vld("Open Time to Closed Time not proper ", clsInterface4OME.clsUtil4ProtoVali.ValidateCompareDate(OpenTime.ToString("dd/MM/yy"),CloseTime.ToString("dd/MM/yy")));     

         
           return IsValidlist();
       }
       
    }
}
