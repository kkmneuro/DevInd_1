using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using clsInterface4OME;

namespace ProtocolStructs
{
    public class CollateralCommodityPS : IProtocolStruct
    {
        public CollateralCommodity _CollateralCommodity;
        List<DatavalidationInfo> lst = new List<DatavalidationInfo>();
        DatavalidationInfo Datvali;
        public CollateralCommodityPS()
        {
            _CollateralCommodity = new CollateralCommodity();
        }
        public CollateralCommodityPS(CollateralCommodity deepCopy)
        {
            _CollateralCommodity._Haircut = deepCopy._Haircut;
            _CollateralCommodity._InstruementID = deepCopy._InstruementID;
            _CollateralCommodity._LastPrice = deepCopy._LastPrice;
            _CollateralCommodity._LastUpdateDate = deepCopy._LastUpdateDate;
            _CollateralCommodity._MaximunPercent = deepCopy._MaximunPercent;
            _CollateralCommodity._SecurityTypeID = deepCopy._SecurityTypeID;
            _CollateralCommodity._Symbol = deepCopy._Symbol;
            _CollateralCommodity._UpperValueLimit = deepCopy._UpperValueLimit;
        }


        public override int ID
        {
            get { return ProtocolStructIDS.CollateralCommodity_ID; }
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

            AppendStr(_CollateralCommodity._Haircut);
            AppendStr(_CollateralCommodity._InstruementID);
            AppendStr(_CollateralCommodity._LastPrice);
            AppendStr(_CollateralCommodity._LastUpdateDate);
            AppendStr(_CollateralCommodity._MaximunPercent);
            AppendStr(_CollateralCommodity._SecurityTypeID);
            AppendStr(_CollateralCommodity._Symbol);
            AppendStr(_CollateralCommodity._UpperValueLimit);

            EndStrW();
        }
        public override void ReadString(string Msgbfr)
        {
            StartStrR(Msgbfr);
            int ind = -1;
            _CollateralCommodity._Haircut = clsUtility.GetDecimal(SpltString[++ind]);
            _CollateralCommodity._InstruementID = clsUtility.GetInt(SpltString[++ind]);
            _CollateralCommodity._LastPrice = clsUtility.GetDecimal(SpltString[++ind]);
            _CollateralCommodity._LastUpdateDate = clsUtility.GetDate(SpltString[++ind]);
            _CollateralCommodity._MaximunPercent = clsUtility.GetDecimal(SpltString[++ind]);
            _CollateralCommodity._SecurityTypeID = clsUtility.GetInt(SpltString[++ind]);
            _CollateralCommodity._Symbol = SpltString[++ind];
            _CollateralCommodity._UpperValueLimit = clsUtility.GetDecimal(SpltString[++ind]);

        }
        public override string ToString()
        {
            return _CollateralCommodity == null ? base.ToString() : _CollateralCommodity.ToString();
        }

        public override bool ValidateData()
        {
            //throw new Exception();
            return true;
        }
    }
}
