using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using clsInterface4OME;

namespace ProtocolStructs
{
    public class CollateralTypesPS:IProtocolStruct
    {
        public CollateralTypes _CollateralTypes;
        List<DatavalidationInfo> lst = new List<DatavalidationInfo>();
        DatavalidationInfo Datvali;
        public CollateralTypesPS()
        {
            _CollateralTypes = new CollateralTypes();
        }
        public CollateralTypesPS(CollateralTypes deepCopy)
        {
            _CollateralTypes._CollateralType = deepCopy._CollateralType;
            _CollateralTypes._CollateralTypeID = deepCopy._CollateralTypeID;
        }


        public override int ID
        {
            get { return ProtocolStructIDS.CollateralType_ID; }
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

            AppendStr(_CollateralTypes._CollateralType);
            AppendStr(_CollateralTypes._CollateralTypeID);

            EndStrW();
        }

        public override void ReadString(string Msgbfr)
        {
            StartStrR(Msgbfr);
            int ind = -1;
            _CollateralTypes._CollateralType = SpltString[++ind];
            _CollateralTypes._CollateralTypeID = clsUtility.GetInt(SpltString[++ind]);
        }
        public override string ToString()
        {
            return _CollateralTypes == null ? base.ToString() : _CollateralTypes.ToString();
        }
        public override bool ValidateData()
        {
            //throw new Exception();
            return true;
        }
    }
}
