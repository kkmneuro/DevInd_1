using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using clsInterface4OME;

namespace ProtocolStructs.NewPS
{
   public class FeeMasterPS : IProtocolStruct
    {
        public FeeMaster _FeeMaster;
        List<DatavalidationInfo> lst = new List<DatavalidationInfo>();
        DatavalidationInfo Datvali;

        public FeeMasterPS()
        {
            _FeeMaster = new FeeMaster();
        }

        public FeeMasterPS(FeeMaster deepCopy)
        {
            _FeeMaster._PK_FeeID = deepCopy._PK_FeeID;
            _FeeMaster._FeeName = deepCopy._FeeName;
            _FeeMaster._MinimumFeeValue = deepCopy._MinimumFeeValue;
            _FeeMaster._MaximumFeeValue = deepCopy._MaximumFeeValue;
            _FeeMaster._Interval = deepCopy._Interval;
            _FeeMaster._IsTaxable = deepCopy._IsTaxable;
            _FeeMaster._Description = deepCopy._Description;

        }

        public override int ID
        {
            get { return ProtocolStructIDS.FeeMaster_ID; }
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
            AppendStr(_FeeMaster._PK_FeeID);
            AppendStr(_FeeMaster._FeeName);
            AppendStr(_FeeMaster._MinimumFeeValue);
            AppendStr(_FeeMaster._MaximumFeeValue);
            AppendStr(_FeeMaster._Interval);
            AppendStr(_FeeMaster._IsTaxable);
            AppendStr(_FeeMaster._Description);

            EndStrW();


        }

        public override void ReadString(string Msgbfr)
        {
            StartStrR(Msgbfr);
            int ind = -1;
            _FeeMaster._PK_FeeID=clsUtility.GetInt(SpltString[++ind]);
            _FeeMaster._FeeName=SpltString[++ind];
            _FeeMaster._MinimumFeeValue=clsUtility.GetInt(SpltString[++ind]);
            _FeeMaster._MaximumFeeValue = clsUtility.GetInt(SpltString[++ind]);
            _FeeMaster._Interval=SpltString[++ind];
            _FeeMaster._IsTaxable = Convert.ToBoolean(SpltString[++ind]);
            _FeeMaster._Description = SpltString[++ind];
        }
        public override string ToString()
        {
            return _FeeMaster == null ? base.ToString() : _FeeMaster.ToString();
        }

        public override bool ValidateData()
        {
            base.ValidateData();

            Add2Vld("PK_FeeID", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty(_FeeMaster._PK_FeeID.ToString()));
            Add2Vld("FeeName", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty(_FeeMaster._FeeName.ToString()));
            Add2Vld("MinimumFeeValue", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty(_FeeMaster._MinimumFeeValue.ToString()));
            Add2Vld("MinimumFeeValue", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty(_FeeMaster._MaximumFeeValue.ToString()));
            Add2Vld("Interval", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty(_FeeMaster._Interval.ToString()));
            Add2Vld("IsTaxable", clsInterface4OME.clsUtil4ProtoVali.ValidateIPPort(_FeeMaster._IsTaxable.ToString()));
            Add2Vld("Description", clsInterface4OME.clsUtil4ProtoVali.ValidateIPPort(_FeeMaster._Description.ToString()));
            return IsValidlist();
        }
    }
}
