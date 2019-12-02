using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using clsInterface4OME;

namespace ProtocolStructs
{
    public class LeveragePS:IProtocolStruct
    {
        public Leverage _Leverage;
        List<DatavalidationInfo> lst = new List<DatavalidationInfo>();
        DatavalidationInfo Datvali;
        public LeveragePS()
        {
            _Leverage = new Leverage();
        }
        public LeveragePS(Leverage deepCopy)
        {
            _Leverage._Leverage = deepCopy._Leverage;
            _Leverage._LeverageId = deepCopy._LeverageId;
        }


        public override int ID
        {
            get { return ProtocolStructIDS.Leverage_ID; }
        }

        public override void StartWrite(byte[] buffer)
        {
            throw new NotImplementedException();
        }

        public override void StartRead(byte[] buffer)
        {
            throw new NotImplementedException();
        }


        public override string ToString()
        {
            return _Leverage == null ? base.ToString() : _Leverage.ToString();
        }

        public override bool ValidateData()
        {
            throw new Exception();
        }
       

       

        public override void WriteString()
        {
            StartStrW();

            AppendStr(_Leverage._Leverage);
            AppendStr(_Leverage._LeverageId );
           
            EndStrW();
        }
        public override void ReadString(string Msgbfr)
        {
            StartStrR(Msgbfr);
            int ind = -1;
            _Leverage._Leverage = SpltString[++ind];
            _Leverage._LeverageId = clsUtility.GetInt(SpltString[++ind]);
          
        }
    }
}
