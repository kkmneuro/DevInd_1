using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using clsInterface4OME;
namespace ProtocolStructs
{
    public class LiveUpdatePS :IProtocolStruct
    {
        public LiveUpdate _LiveUpdate;
       public LiveUpdatePS()
       {
           _LiveUpdate = new LiveUpdate();
       }
       public LiveUpdatePS(LiveUpdate deepCopy)
       {
           _LiveUpdate._Company = deepCopy._Company;
           _LiveUpdate._Folder = deepCopy._Folder;
           _LiveUpdate._IsEnable = deepCopy._IsEnable;
           _LiveUpdate._LiveUpdateId = deepCopy._LiveUpdateId;
           _LiveUpdate._MaximumConnections = deepCopy._MaximumConnections;
           _LiveUpdate._Type = deepCopy._Type;
           _LiveUpdate._Version = deepCopy._Version;
       }
      
        public override int ID
        {
            get { return ProtocolStructIDS.LiveUpdate_ID ; }
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
            AppendStr(_LiveUpdate._Company  );
            AppendStr(_LiveUpdate._Folder );
            AppendStr(_LiveUpdate._IsEnable );
            AppendStr(_LiveUpdate._LiveUpdateId);
            AppendStr(_LiveUpdate._MaximumConnections);
            AppendStr(_LiveUpdate._Type );
            AppendStr(_LiveUpdate._Version);
            EndStrW();
        }

        public override void ReadString(string Msgbfr)
        {
            StartStrR(Msgbfr);

            _LiveUpdate._Company=SpltString[0];
            _LiveUpdate._Folder=SpltString[1]; 
            _LiveUpdate._IsEnable=Convert.ToBoolean(SpltString[2]);
            _LiveUpdate._LiveUpdateId = clsUtility.GetInt(SpltString[3]);
            _LiveUpdate._MaximumConnections = clsUtility.GetInt(SpltString[4]);
            _LiveUpdate._Type = SpltString[5];
            _LiveUpdate._Version = SpltString[6];


        }
        public override string ToString()
        {

            return _LiveUpdate==null?base.ToString(): _LiveUpdate.ToString();
        }

        public override bool ValidateData()
        {
            base.ValidateData();
            Add2Vld("Company", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty((_LiveUpdate._Company)));
            Add2Vld("Type", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty((_LiveUpdate._Type)));
            Add2Vld("Server", clsInterface4OME.clsUtil4ProtoVali.ValidateInteger(clsUtility.GetStr(_LiveUpdate._MaximumConnections)));
            Add2Vld("Folder Path", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty(clsUtility.GetStr(_LiveUpdate._Folder)));
            return IsValidlist();
        }
    }
}
