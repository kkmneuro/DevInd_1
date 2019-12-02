using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtocolStructs.NewPS
{
    public class DisconnectPS:IProtocolStruct
    {
        public string Msg = string.Empty;
        //
        //

        public override int ID
        {
            get { return ProtocolStructIDS.DisConnect_ID; }
        }

        public override void StartWrite(byte[] buffer)
        {
            
        }

        public override void StartRead(byte[] buffer)
        {
            
        }

        public override void ReadString(string Msgbfr)
        {
            StartStrR(Msgbfr);
            Msg = SpltString[0];
 
        }

        public override void WriteString()
        {
            StartStrW();
            AppendStr(Msg);
            EndStrW();
            
        }

        public override bool ValidateData()
        {
            throw new NotImplementedException();
        }
    }
}
