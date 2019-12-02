using System;
using System.Collections.Generic;
using System.Text;
using clsInterface4OME;
namespace ProtocolStructs
{
    public class DataServerPS :IProtocolStruct
    {
        public DataServer _DataServer;
       public DataServerPS()
       {
           _DataServer = new DataServer();
       }
       public DataServerPS(DataServer deepCopy)
       {
           _DataServer._Description = deepCopy._Description;
           _DataServer._InternalIpServer = deepCopy._InternalIpServer;
           _DataServer._IP = deepCopy._IP;
           _DataServer._IsLive = deepCopy._IsLive;
           _DataServer._Port = deepCopy._Port;
           _DataServer._Priority = deepCopy._Priority;
           _DataServer._ServerID= deepCopy._ServerID;
           _DataServer._Loading = deepCopy._Loading;
       }
       public override int ID
       {
           get { return ProtocolStructIDS.DataServer_ID; }
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
           AppendStr(_DataServer._Description);
           AppendStr(_DataServer._InternalIpServer);
           AppendStr(_DataServer._IP);
           AppendStr(_DataServer._IsLive);
           AppendStr(_DataServer._Port);
           AppendStr(_DataServer._Priority);
           AppendStr(_DataServer._ServerID);
           AppendStr(_DataServer._Loading);
         

           EndStrW();
       }

       public override void ReadString(string Msgbfr)
       {
           StartStrR(Msgbfr);

           _DataServer._Description = SpltString[0];
           _DataServer._InternalIpServer = SpltString[1];
           _DataServer._IP=SpltString[2];
           _DataServer._IsLive = Convert.ToBoolean(SpltString[3]);
           _DataServer._Port = clsUtility.GetInt(SpltString[4]);
           _DataServer._Priority = SpltString[5];
           _DataServer._ServerID = clsUtility.GetInt(SpltString[6]);
           _DataServer._Loading = SpltString[7];
           

       }
       public override string ToString()
       {

           return _DataServer==null?base.ToString():_DataServer.ToString();
       }

       public override bool ValidateData()
       {
           string ServerIPAndPort = _DataServer._IP + ":"+_DataServer._Port;
           base.ValidateData();
           Add2Vld("InternalIpAddress", clsInterface4OME.clsUtil4ProtoVali.ValidateIP(_DataServer._InternalIpServer));
           Add2Vld("ServerIPAndPort", clsInterface4OME.clsUtil4ProtoVali.ValidateIPPort(ServerIPAndPort));
           return IsValidlist();
       }
    }
}
