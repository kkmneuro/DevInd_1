using System;
using System.Collections.Generic;
using System.Text;
using clsInterface4OME;
namespace ProtocolStructs
{
   public  class BankPS : IProtocolStruct
    {
       public Bank _Bank;
       public BankPS ()
       {
           _Bank = new Bank();
       }
       public BankPS(Bank deepCopy)
       {
           _Bank._AccountHolderName = deepCopy._AccountHolderName;
           _Bank._BankAccountID = deepCopy._BankAccountID;
           _Bank._BankAddress = deepCopy._BankAddress;
           _Bank._BankAddress2 = deepCopy._BankAddress2;
           _Bank._BankCity = deepCopy._BankCity;
           _Bank._BankCountryID = deepCopy._BankCountryID;
           _Bank._BankFax = deepCopy._BankFax;
           _Bank._BankID = deepCopy._BankID;
           _Bank._BankName = deepCopy._BankName;
           _Bank._BankPhone = deepCopy._BankPhone;
           _Bank._BankSwiftCode = deepCopy._BankSwiftCode;
           _Bank._BankZipCode = deepCopy._BankZipCode;
           _Bank._BankAccountType = deepCopy._BankAccountType;
           _Bank._BankIFSCCode = deepCopy._BankIFSCCode;
           _Bank._ClientID = deepCopy._ClientID;
       }
       public override int ID
       {
           get { return ProtocolStructIDS.Bank_ID; }
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
           AppendStr(_Bank._AccountHolderName);
           AppendStr(_Bank._BankAccountID);
           AppendStr(_Bank._BankAddress);
           AppendStr(_Bank._BankAddress2);
           AppendStr(_Bank._BankCity);
           AppendStr(_Bank._BankCountryID);
           AppendStr(_Bank._BankFax);
           AppendStr(_Bank._BankID);
           AppendStr(_Bank._BankName);
           AppendStr(_Bank._BankPhone);
           AppendStr(_Bank._BankSwiftCode);
           AppendStr(_Bank._BankZipCode);
           AppendStr(_Bank._BankAccountType);
           AppendStr(_Bank._BankIFSCCode);
           AppendStr(_Bank._ClientID);

           EndStrW();
       }

       public override void ReadString(string Msgbfr)
       {
           StartStrR(Msgbfr);


           _Bank._AccountHolderName = SpltString[0];
           _Bank._BankAccountID = SpltString[1];
           _Bank._BankAddress = SpltString[2];
           _Bank._BankAddress2 = SpltString[3];
           _Bank._BankCity = SpltString[4];
           _Bank._BankCountryID = clsUtility.GetInt(SpltString[5]);
           _Bank._BankFax = SpltString[6];
           _Bank._BankID = clsUtility.GetInt(SpltString[7]);
           _Bank._BankName = SpltString[8];
           _Bank._BankPhone = SpltString[9];
           _Bank._BankSwiftCode = SpltString[10];
           _Bank._BankZipCode = SpltString[11];
           _Bank._BankAccountType = SpltString[12];
           _Bank._BankIFSCCode = SpltString[13];
           _Bank._ClientID = clsUtility.GetInt(SpltString[14]);

       }

       public override string ToString()
       {
           return _Bank==null?base.ToString():_Bank.ToString();
       }

       public override bool ValidateData()
       {
           //throw new NotImplementedException();
           return true;
       }
    }
}
