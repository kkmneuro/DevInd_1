using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using clsInterface4OME;

namespace ProtocolStructs
{
    public class BrokerLastCollateralTransactionPS : IProtocolStruct
    {
        public BrokerLastCollateralTransaction _BrokerLastCollateralTrans;
       public BrokerLastCollateralTransactionPS ()
       {
           _BrokerLastCollateralTrans = new BrokerLastCollateralTransaction();
       }
       public BrokerLastCollateralTransactionPS(BrokerLastCollateralTransaction deepCopy)
       {
           _BrokerLastCollateralTrans._AccountGroupId = deepCopy._AccountGroupId;
           _BrokerLastCollateralTrans._Amount = deepCopy._Amount;
           _BrokerLastCollateralTrans._CollateralType = deepCopy._CollateralType;
           _BrokerLastCollateralTrans._CollateralTypeId = deepCopy._CollateralTypeId;
           _BrokerLastCollateralTrans._TotalAmount = deepCopy._TotalAmount;
           _BrokerLastCollateralTrans._TransactionDate = deepCopy._TransactionDate;
           _BrokerLastCollateralTrans._TransactionType = deepCopy._TransactionType;
           _BrokerLastCollateralTrans._IsNewCollateralTrans = deepCopy._IsNewCollateralTrans;


       }
       public override int ID
       {
           get { return ProtocolStructIDS.BrokerCollateralTrans_ID; }
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

           AppendStr(_BrokerLastCollateralTrans._AccountGroupId);
           AppendStr(_BrokerLastCollateralTrans._Amount);
           AppendStr(_BrokerLastCollateralTrans._CollateralType );
           AppendStr(_BrokerLastCollateralTrans._CollateralTypeId);
           AppendStr(_BrokerLastCollateralTrans._TotalAmount);
           AppendStr(_BrokerLastCollateralTrans._TransactionDate);
           AppendStr(_BrokerLastCollateralTrans._TransactionType );
           AppendStr(_BrokerLastCollateralTrans._IsNewCollateralTrans); 

           EndStrW();
       }

       public override void ReadString(string Msgbfr)
       {
           StartStrR(Msgbfr);
           _BrokerLastCollateralTrans._AccountGroupId =clsUtility.GetInt(SpltString[0]);
           _BrokerLastCollateralTrans._Amount = clsUtility.GetDecimal(SpltString[1]);
           _BrokerLastCollateralTrans._CollateralType = SpltString[2];
           _BrokerLastCollateralTrans._CollateralTypeId =clsUtility.GetInt(SpltString[3]);
           _BrokerLastCollateralTrans._TotalAmount = clsUtility.GetDecimal(SpltString[4]);
           _BrokerLastCollateralTrans._TransactionDate = SpltString[5];
           _BrokerLastCollateralTrans._TransactionType = SpltString[6];
           _BrokerLastCollateralTrans._IsNewCollateralTrans =Convert.ToBoolean(SpltString[7]);
           
       }

       public override string ToString()
       {
           return _BrokerLastCollateralTrans==null?base.ToString():_BrokerLastCollateralTrans.ToString();
       }

       public override bool ValidateData()
       {
           //throw new NotImplementedException();
           return true;
       }
    }
}
