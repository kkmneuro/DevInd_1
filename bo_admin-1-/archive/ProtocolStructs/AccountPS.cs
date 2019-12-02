using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using clsInterface4OME;

namespace ProtocolStructs
{
    public class AccountPS : IProtocolStruct
    {
        public Account _Acc;
        List<DatavalidationInfo> lst = new List<DatavalidationInfo>();
        DatavalidationInfo Datvali;
        public AccountPS()
        {
            _Acc = new Account();
        }
        public AccountPS(Account deepCopy)
        {
            _Acc._AccountId = deepCopy._AccountId;
            _Acc._ClientId = deepCopy._ClientId;
            _Acc._AccountGroupId = deepCopy._AccountGroupId;
            _Acc._Balence = deepCopy._Balence;
            _Acc._Equity = deepCopy._Equity;
            _Acc._Deleted = deepCopy._Deleted;
            _Acc._UsedMargin = deepCopy._UsedMargin;
            _Acc._LeverageId = deepCopy._LeverageId;
            _Acc._IsHedgingAllowed = deepCopy._IsHedgingAllowed;
            _Acc._IsTradeEnable = deepCopy._IsTradeEnable;
            _Acc._CurrencyId = deepCopy._CurrencyId;
            _Acc._BuySideTurnOver =deepCopy._BuySideTurnOver  ;
            _Acc._SellSideTurnOver = deepCopy._SellSideTurnOver;
            _Acc._RelatedBankId = deepCopy._RelatedBankId;
            _Acc._PaymentAmount = deepCopy._PaymentAmount;
            _Acc._PaymentType = deepCopy._PaymentType;
            _Acc._PaymentMode = deepCopy._PaymentMode;
            _Acc._PaymentDate = deepCopy._PaymentDate;
            _Acc._LPName = deepCopy._LPName;
            _Acc._LPAccountID = deepCopy._LPAccountID;
        }


        public override int ID
        {
            get { return ProtocolStructIDS.Account_ID; }
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

            AppendStr(_Acc._AccountId);
            AppendStr(_Acc._ClientId );
            AppendStr(_Acc._AccountGroupId );
            AppendStr(_Acc._Balence );
            AppendStr(_Acc._Equity );
            AppendStr(_Acc._Deleted );
            AppendStr(_Acc._UsedMargin);
            AppendStr(_Acc._LeverageId );
            AppendStr(_Acc._IsHedgingAllowed); 
            AppendStr(_Acc._IsTradeEnable );
            AppendStr(_Acc._CurrencyId);
            AppendStr(_Acc._BuySideTurnOver);
            AppendStr(_Acc._SellSideTurnOver);
            AppendStr(_Acc._RelatedBankId);
            AppendStr(_Acc._PaymentAmount);
            AppendStr(_Acc._PaymentType);
            AppendStr(_Acc._PaymentMode);
            AppendStr(_Acc._PaymentDate);
            AppendStr(_Acc._LPName);
            AppendStr(_Acc._LPAccountID);

            EndStrW();
        }
        public override void ReadString(string Msgbfr)
        {
            StartStrR(Msgbfr);
            int ind = -1;
            _Acc._AccountId = clsUtility.GetInt(SpltString[++ind]);
            _Acc._ClientId = clsUtility.GetInt(SpltString[++ind]);
            _Acc._AccountGroupId = clsUtility.GetInt(SpltString[++ind]);
            _Acc._Balence = clsUtility.GetDecimal(SpltString[++ind]);
            _Acc._Equity = clsUtility.GetDecimal(SpltString[++ind]);
            _Acc._Deleted = Convert.ToBoolean(SpltString[++ind]);
            _Acc._UsedMargin = clsUtility.GetDecimal(SpltString[++ind]);
            _Acc._LeverageId = clsUtility.GetInt(SpltString[++ind]);
            _Acc._IsHedgingAllowed = Convert.ToBoolean(SpltString[++ind]);
            _Acc._IsTradeEnable = Convert.ToBoolean(SpltString[++ind]);
            _Acc._CurrencyId = clsUtility.GetInt(SpltString[++ind]);
            _Acc._BuySideTurnOver = clsUtility.GetDecimal(SpltString[++ind]);
            _Acc._SellSideTurnOver = clsUtility.GetDecimal(SpltString[++ind]);
            _Acc._RelatedBankId = clsUtility.GetInt(SpltString[++ind]);
            _Acc._PaymentAmount = clsUtility.GetDecimal(SpltString[++ind]);
            _Acc._PaymentType =SpltString[++ind];
            _Acc._PaymentMode = SpltString[++ind];
            _Acc._PaymentDate =clsUtility.GetDate4ProtoStru(SpltString[++ind]);
            _Acc._LPName = SpltString[++ind];
            _Acc._LPAccountID = SpltString[++ind];
        }
        public override string ToString()
        {
            return _Acc == null ? base.ToString() : _Acc.ToString();
        }

        public override bool ValidateData()
        {
            //throw new Exception();
            return true;
        }
    }
}
