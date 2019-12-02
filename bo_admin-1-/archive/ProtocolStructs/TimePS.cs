using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using clsInterface4OME;
namespace ProtocolStructs
{
    public class TimePS : IProtocolStruct
    {
        public Time _Time;
        public TimePS()
        {
            _Time = new Time();
        }
        public TimePS(Time deepCopy)
        {
            _Time._Day = deepCopy._Day;
            _Time._TimeSpan = deepCopy._TimeSpan;
            
        }
        public override int ID
        {
            get { return ProtocolStructIDS.Time_ID; }
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
            AppendStr(_Time._Day);
            AppendStr(_Time._TimeSpan);
          
            EndStrW();
        }

        public override void ReadString(string Msgbfr)
        {
            StartStrR(Msgbfr);

            _Time._Day = SpltString[0];
            _Time._TimeSpan = SpltString[1];
         
            
        }
        public override string ToString()
        {
            return _Time==null?base.ToString():_Time.ToString();
        }

        public override bool ValidateData()
        {
            base.ValidateData();
            Add2Vld("Day", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty(_Time._Day));
            Add2Vld("TimeSpan", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty(_Time._TimeSpan));
            return IsValidlist();
        }

       
    }
}
