using System;
using System.Collections.Generic;
using System.Text;
using clsInterface4OME;
namespace ProtocolStructs
{
    public class DataFeedsPS :IProtocolStruct
    {
        public DataFeeds _DataFeeds;
        List<DatavalidationInfo> lst = new List<DatavalidationInfo>();
        DatavalidationInfo Datvali;
       public DataFeedsPS()
       {
           _DataFeeds = new DataFeeds();
       }
       public DataFeedsPS(DataFeeds deepCopy)
       {
           _DataFeeds._Attempts = deepCopy._Attempts;
           _DataFeeds._Description = deepCopy._Description;
           _DataFeeds._File = deepCopy._File;
           _DataFeeds._Id = deepCopy._Id;
           _DataFeeds._IdleTimeOut = deepCopy._IdleTimeOut;
           _DataFeeds._IsEnable = deepCopy._IsEnable;
           _DataFeeds._Journal = deepCopy._Journal;
           _DataFeeds._KeyWords = deepCopy._KeyWords;
           _DataFeeds._LoginID = deepCopy._LoginID;
           _DataFeeds._Password = deepCopy._Password;
           _DataFeeds._ReconnectAfter= deepCopy._ReconnectAfter;
           _DataFeeds._Server = deepCopy._Server;
           _DataFeeds._SleepFor = deepCopy._SleepFor;
           _DataFeeds._Source = deepCopy._Source;
           _DataFeeds._Vendor = deepCopy._Vendor;
       }
       public override int ID
       {
           get { return ProtocolStructIDS.DataFeeds_ID; }
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
           AppendStr(_DataFeeds._Attempts);
           AppendStr(_DataFeeds._Description);
           AppendStr(_DataFeeds._File);
           AppendStr(_DataFeeds._Id);
           AppendStr(_DataFeeds._IdleTimeOut);
           AppendStr(_DataFeeds._IsEnable);
           AppendStr(_DataFeeds._Journal);
           AppendStr(_DataFeeds._KeyWords);
           AppendStr(_DataFeeds._LoginID);
           AppendStr(_DataFeeds._Password);
           AppendStr(_DataFeeds._ReconnectAfter);
           AppendStr(_DataFeeds._Server);
           AppendStr(_DataFeeds._SleepFor);
           AppendStr(_DataFeeds._Source);
           AppendStr(_DataFeeds._Vendor);

           EndStrW();
       }

       public override void ReadString(string Msgbfr)
       {
           StartStrR(Msgbfr);

           _DataFeeds._Attempts = clsUtility.GetInt(SpltString[0]);
           _DataFeeds._Description = SpltString[1];
           _DataFeeds._File =SpltString[2];
           _DataFeeds._Id = clsUtility.GetInt(SpltString[3]);
           _DataFeeds._IdleTimeOut = clsUtility.GetInt(SpltString[4]);
           _DataFeeds._IsEnable = Convert.ToBoolean(SpltString[5]);
           _DataFeeds._Journal = SpltString[6];
           _DataFeeds._KeyWords= SpltString[7];
           _DataFeeds._LoginID = clsUtility.GetLong(SpltString[8]);
           _DataFeeds._Password = SpltString[9];
           _DataFeeds._ReconnectAfter = clsUtility.GetInt(SpltString[10]);
           _DataFeeds._Server = SpltString[11];
           _DataFeeds._SleepFor = clsUtility.GetInt(SpltString[12]);
           _DataFeeds._Source = SpltString[13];
           _DataFeeds._Vendor = SpltString[14];
           

       }
       public override string ToString()
       {
           return _DataFeeds==null?base.ToString():_DataFeeds.ToString();
       }
     

       public override bool ValidateData()
       {
           base.ValidateData();
           Add2Vld("Name", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty(_DataFeeds._Vendor.ToString()));
           Add2Vld("Source", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty(_DataFeeds._Source .ToString()));
           Add2Vld("Server", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty(_DataFeeds._Server.ToString()));  
           Add2Vld("Server", clsInterface4OME.clsUtil4ProtoVali.ValidateIPPort(_DataFeeds._Server.ToString()));           
           Add2Vld("LoginID", clsInterface4OME.clsUtil4ProtoVali.ValidateInteger(_DataFeeds._LoginID.ToString()));
           Add2Vld("IdleTimeOut", clsInterface4OME.clsUtil4ProtoVali.ValidateInteger(_DataFeeds._IdleTimeOut.ToString()));
           Add2Vld("SleepFor", clsInterface4OME.clsUtil4ProtoVali.ValidateInteger(_DataFeeds._SleepFor.ToString()));
           Add2Vld("Attempts", clsInterface4OME.clsUtil4ProtoVali.ValidateInteger(_DataFeeds._Attempts.ToString()));
           Add2Vld("File", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty(_DataFeeds._File.ToString()));
           Add2Vld("ReconnectAfter", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty(_DataFeeds._ReconnectAfter.ToString()));
           Add2Vld("Password", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty(_DataFeeds._Password .ToString()));
           return IsValidlist();
       }
    }
}
