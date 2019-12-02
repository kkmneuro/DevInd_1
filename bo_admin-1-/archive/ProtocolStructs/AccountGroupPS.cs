using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using clsInterface4OME;

namespace ProtocolStructs
{
    public class AccountGroupPS:IProtocolStruct
    {
        public AccountGroup _AccGroup;
        List<DatavalidationInfo> lst = new List<DatavalidationInfo>();
        DatavalidationInfo Datvali;
        public AccountGroupPS()
        {
            _AccGroup = new AccountGroup();
        }
        public AccountGroupPS(AccountGroup deepCopy)
        {
            _AccGroup._AccountGroupID = deepCopy._AccountGroupID;
            _AccGroup._AccountGroupName = deepCopy._AccountGroupName;
            _AccGroup._BrokerAddress = deepCopy._BrokerAddress;
            _AccGroup._BrokerCity = deepCopy._BrokerCity;
            _AccGroup._BrokerFax= deepCopy._BrokerFax;
            _AccGroup._BrokerPhone1= deepCopy._BrokerPhone1;
            _AccGroup._BrokerPhone2 = deepCopy._BrokerPhone2;
            _AccGroup._BrokerState= deepCopy._BrokerState;
            _AccGroup._BrokerTypeID = deepCopy._BrokerTypeID;
            _AccGroup._Charges = deepCopy._Charges;
            _AccGroup._IsEnable= deepCopy._IsEnable;
            _AccGroup._LeverageId = deepCopy._LeverageId;
            _AccGroup._Owner = deepCopy._Owner;

        }


        public override int ID
        {
            get { return ProtocolStructIDS.AccountGroup_ID; }
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

            AppendStr(_AccGroup._AccountGroupID);
            AppendStr(_AccGroup._AccountGroupName);
            AppendStr(_AccGroup._BrokerAddress);
            AppendStr(_AccGroup._BrokerCity);
            AppendStr(_AccGroup._BrokerFax);
            AppendStr(_AccGroup._BrokerPhone1);
            AppendStr(_AccGroup._BrokerPhone2);
            AppendStr(_AccGroup._LeverageId );
            AppendStr(_AccGroup._BrokerState);
            AppendStr(_AccGroup._BrokerTypeID);
            AppendStr(_AccGroup._Charges);
            AppendStr(_AccGroup._IsEnable);
            AppendStr(_AccGroup._Owner);
           
            EndStrW();
        }

        public override void ReadString(string Msgbfr)
        {
            StartStrR(Msgbfr);
            int ind = -1;
            _AccGroup._AccountGroupID = clsUtility.GetInt(SpltString[++ind]);
            _AccGroup._AccountGroupName = SpltString[++ind];
            _AccGroup._BrokerAddress = SpltString[++ind];
            _AccGroup._BrokerCity = SpltString[++ind];
            _AccGroup._BrokerFax = SpltString[++ind];
            _AccGroup._BrokerPhone1 = SpltString[++ind];
            _AccGroup._BrokerPhone2 = SpltString[++ind];
            _AccGroup._LeverageId = clsUtility.GetInt(SpltString[++ind]);
            _AccGroup._BrokerState = SpltString[++ind];
            _AccGroup._BrokerTypeID = clsUtility.GetInt(SpltString[++ind]);
            _AccGroup._Charges = clsUtility.GetDecimal(SpltString[++ind]);
            _AccGroup._IsEnable = Convert.ToBoolean(SpltString[++ind]);
            _AccGroup._Owner = SpltString[++ind];
        }

        public override string ToString()
        {

            return _AccGroup == null ? base.ToString() : _AccGroup.ToString();
        }
        public override bool ValidateData()
        {
            throw new Exception();
        }
    }
}
