using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using clsInterface4OME;

namespace ProtocolStructs.NewPS
{
  public class TaxMasterPS : IProtocolStruct
    {
        public TaxMaster _TaxMaster;
        List<DatavalidationInfo> lst = new List<DatavalidationInfo>();
        DatavalidationInfo Datvali;
        public TaxMasterPS()
        {
            _TaxMaster = new TaxMaster();
        }

        public TaxMasterPS(TaxMaster deepCopy)
        {
            _TaxMaster._TaxID = deepCopy._TaxID;
            _TaxMaster._TaxName = deepCopy._TaxName;
            _TaxMaster._TaxPercent = deepCopy._TaxPercent;
            _TaxMaster._Amount = deepCopy._Amount;
            _TaxMaster._Description = deepCopy._Description;
        }

        public override int ID
        {
            get { return ProtocolStructIDS.TaxMasterID; }
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

            AppendStr(_TaxMaster._TaxID);
            AppendStr(_TaxMaster._TaxName);
            AppendStr(_TaxMaster._TaxPercent);
            AppendStr(_TaxMaster._Amount);
            AppendStr(_TaxMaster._Description);
         
            EndStrW();
        }

        public override void ReadString(string Msgbfr)
        {
            StartStrR(Msgbfr);

            int ind = -1;

            _TaxMaster._TaxID = clsUtility.GetInt(SpltString[++ind]);
            _TaxMaster._TaxName = SpltString[++ind];
           _TaxMaster._TaxPercent=clsUtility.GetDecimal(SpltString[++ind]);
           _TaxMaster._Amount = SpltString[++ind];
           _TaxMaster._Description = SpltString[++ind];
          
        }

        public override string ToString()
        {
            return _TaxMaster == null ? base.ToString() : _TaxMaster.ToString();
        }

    }
}
