using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using clsInterface4OME;

namespace ProtocolStructs
{
    public class DBResponsePS:IProtocolStruct
    {
        public DBResponse _DBResponse;
        
        public DBResponsePS()
        {
            _DBResponse = new DBResponse();
        }

        public DBResponsePS(DBResponse deepcopy)
        {
            _DBResponse._ResponseID = deepcopy._ResponseID;
            _DBResponse._Status = deepcopy._Status;
            _DBResponse._StatusMessage = deepcopy._StatusMessage;
            _DBResponse._DataKey = deepcopy._DataKey;
        }

        public override int ID
        {
            get { return ProtocolStructIDS.DBResponse_ID; }
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
            AppendStr(_DBResponse._ResponseID);
            AppendStr(_DBResponse._Status);
            AppendStr(_DBResponse._StatusMessage);
            AppendStr(_DBResponse._DataKey);
            EndStrW();
        }

        public override void ReadString(string Msgbfr)
        {
            StartStrR(Msgbfr);
            _DBResponse._ResponseID = clsUtility.GetInt(SpltString[0]);
            _DBResponse._Status =  Convert.ToBoolean(SpltString[1]);
            _DBResponse._StatusMessage = SpltString[2];
            _DBResponse._DataKey = SpltString[3];
        }

        public override string ToString()
        {
            return _DBResponse == null ? base.ToString() : _DBResponse.ToString();
        }

        public override bool ValidateData()
        {
            throw new NotImplementedException();
        }
    }
}
