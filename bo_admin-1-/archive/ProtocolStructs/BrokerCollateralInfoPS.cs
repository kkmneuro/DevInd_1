using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using clsInterface4OME;

namespace ProtocolStructs
{
    public class BrokerCollateralInfoPS : IProtocolStruct
    {
public BrokerCollateralInfo _BrokerCollateralinfo;
        List<DatavalidationInfo> lst = new List<DatavalidationInfo>();
        DatavalidationInfo Datvali;
        public BrokerCollateralInfoPS()
        {
            _BrokerCollateralinfo = new BrokerCollateralInfo();
        }
        public BrokerCollateralInfoPS(BrokerCollateralInfo deepCopy)
        {
            _BrokerCollateralinfo._AccountGroupID = deepCopy._AccountGroupID;
            _BrokerCollateralinfo._AccountGroupName = deepCopy._AccountGroupName;
            _BrokerCollateralinfo._BrokerType = deepCopy._BrokerType;
            _BrokerCollateralinfo._BrokerTypeID = deepCopy._BrokerTypeID;
            _BrokerCollateralinfo._CollateralforTrading = deepCopy._CollateralforTrading;
            _BrokerCollateralinfo._IsEnable = deepCopy._IsEnable;
            _BrokerCollateralinfo._Leverage = deepCopy._Leverage;
            _BrokerCollateralinfo._Owner = deepCopy._Owner;
            _BrokerCollateralinfo._ParentAccountGroupID = deepCopy._ParentAccountGroupID;
            _BrokerCollateralinfo._ParentOwner = deepCopy._ParentOwner;
            _BrokerCollateralinfo._PayInShortage = deepCopy._PayInShortage;
            _BrokerCollateralinfo._PayOutShortage =deepCopy._PayOutShortage  ;
            _BrokerCollateralinfo._TotalCollateral = deepCopy._TotalCollateral;
            _BrokerCollateralinfo._Unallocated = deepCopy._Unallocated;
            _BrokerCollateralinfo._Utilized = deepCopy._Utilized;
        }


        public override int ID
        {
            get { return ProtocolStructIDS.BrokerCollateral_ID; }
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

            AppendStr(_BrokerCollateralinfo._AccountGroupID);
            AppendStr(_BrokerCollateralinfo._AccountGroupName );
            AppendStr(_BrokerCollateralinfo._BrokerType );
            AppendStr(_BrokerCollateralinfo._BrokerTypeID );
            AppendStr(_BrokerCollateralinfo._CollateralforTrading );
            AppendStr(_BrokerCollateralinfo._IsEnable );
            AppendStr(_BrokerCollateralinfo._Leverage);
            AppendStr(_BrokerCollateralinfo._Owner );
            AppendStr(_BrokerCollateralinfo._ParentAccountGroupID); 
            AppendStr(_BrokerCollateralinfo._ParentOwner );
            AppendStr(_BrokerCollateralinfo._PayInShortage);
            AppendStr(_BrokerCollateralinfo._PayOutShortage);
            AppendStr(_BrokerCollateralinfo._TotalCollateral);
            AppendStr(_BrokerCollateralinfo._Unallocated);
            AppendStr(_BrokerCollateralinfo._Utilized);
            EndStrW();
        }
        public override void ReadString(string Msgbfr)
        {
            StartStrR(Msgbfr);
            int ind = -1;
            _BrokerCollateralinfo._AccountGroupID = clsUtility.GetInt(SpltString[++ind]);
            _BrokerCollateralinfo._AccountGroupName =SpltString[++ind];
            _BrokerCollateralinfo._BrokerType= SpltString[++ind];
            _BrokerCollateralinfo._BrokerTypeID = clsUtility.GetInt(SpltString[++ind]);
            _BrokerCollateralinfo._CollateralforTrading = clsUtility.GetDecimal(SpltString[++ind]);
            _BrokerCollateralinfo._IsEnable = Convert.ToBoolean(SpltString[++ind]);
            _BrokerCollateralinfo._Leverage = SpltString[++ind];
            _BrokerCollateralinfo._Owner = SpltString[++ind];
            _BrokerCollateralinfo._ParentAccountGroupID =clsUtility.GetInt(SpltString[++ind]);
            _BrokerCollateralinfo._ParentOwner = SpltString[++ind];
            _BrokerCollateralinfo._PayInShortage = clsUtility.GetDecimal(SpltString[++ind]);
            _BrokerCollateralinfo._PayOutShortage = clsUtility.GetDecimal(SpltString[++ind]);
            _BrokerCollateralinfo._TotalCollateral = clsUtility.GetDecimal(SpltString[++ind]);
            _BrokerCollateralinfo._Unallocated = clsUtility.GetDecimal(SpltString[++ind]);
            _BrokerCollateralinfo._Utilized = clsUtility.GetDecimal(SpltString[++ind]);
        }
        public override string ToString()
        {
            return _BrokerCollateralinfo == null ? base.ToString() : _BrokerCollateralinfo.ToString();
        }

        public override bool ValidateData()
        {
            //throw new Exception();
            return true;
        }
    }
}
