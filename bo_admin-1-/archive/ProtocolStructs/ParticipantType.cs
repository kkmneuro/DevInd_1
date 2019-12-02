using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtocolStructs
{
    public class ParticipantType
    {
        public Int32 _PK_ParticipantTypeID;
        public string _ParticpantTypeName;
        public ParticipantType()
        {
            _PK_ParticipantTypeID = 0;
            _ParticpantTypeName = string.Empty;
        }
        public override string ToString()
        {
            return
                "_PK_ParticipantTypeID->" + _PK_ParticipantTypeID +
                "_ParticpantTypeName->" + _ParticpantTypeName;
        }
    }
}
