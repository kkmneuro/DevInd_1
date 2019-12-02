using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtocolStructs
{
    public class InsertDBPS:IProtocolStruct
    {
        public override int ID
        {
            get { throw new NotImplementedException(); }
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
            throw new NotImplementedException();
        }

        public override void ReadString(string Msgbfr)
        {
            throw new NotImplementedException();
        }

        public override bool ValidateData()
        {
            throw new NotImplementedException();
        }
    }
}
