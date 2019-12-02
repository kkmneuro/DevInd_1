using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using clsInterface4OME;

namespace ProtocolStructs
{
    public class DBDeletePS:IProtocolStruct
    {
        public DBDelete _DBDelete;
        
        public DBDeletePS()
        {
            _DBDelete = new DBDelete();
        }

        public DBDeletePS(DBDelete deepcopy)
        {
            _DBDelete._DeleteID = deepcopy._DeleteID;
            _DBDelete._DeleteKey = deepcopy._DeleteKey;
        }

        public override int ID
        {
            get { return ProtocolStructIDS.DBDelete_ID; }
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
            AppendStr(_DBDelete._DeleteID);
            AppendStr(_DBDelete._DeleteKey);
            
            EndStrW();
        }

        public override void ReadString(string Msgbfr)
        {
            StartStrR(Msgbfr);
            _DBDelete._DeleteID = clsUtility.GetInt(SpltString[0]);
            _DBDelete._DeleteKey = SpltString[1];
        }

        public override string ToString()
        {
            return _DBDelete == null ? base.ToString() : _DBDelete.ToString();
        }

        public override bool ValidateData()
        {
            throw new NotImplementedException();
        }
    }
}
