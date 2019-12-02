using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtocolStructs
{
    public class ParticipantTypePS : IProtocolStruct
    {
        public ParticipantType _ParticipantType;
        public ParticipantTypePS()
        {
            _ParticipantType = new ParticipantType();
        }
        public ParticipantTypePS(ParticipantType deepCopy)
        {
            _ParticipantType._ParticpantTypeName = deepCopy._ParticpantTypeName;
            _ParticipantType._PK_ParticipantTypeID = deepCopy._PK_ParticipantTypeID;
        }
        public override int ID
        {
            get { return ProtocolStructIDS.ParticipantType_ID; }
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
            AppendStr(_ParticipantType._ParticpantTypeName);
            AppendStr(_ParticipantType._PK_ParticipantTypeID);
            EndStrW();
        }

        public override void ReadString(string Msgbfr)
        {
            StartStrR(Msgbfr);
            _ParticipantType._ParticpantTypeName= SpltString[0];
            _ParticipantType._PK_ParticipantTypeID = Convert.ToInt32(SpltString[1]);

        }
    }
}
