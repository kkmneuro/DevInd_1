using System;
using System.Collections.Generic;
using System.Text;
using clsInterface4OME;
namespace ProtocolStructs
{
    public class HolidayPS :IProtocolStruct
    {
         public Holiday _Holiday;
       public HolidayPS()
       {
           _Holiday = new Holiday();
       }
       public HolidayPS(Holiday deepCopy)
       {
           _Holiday._Day = deepCopy._Day;
           _Holiday._Description = deepCopy._Description;
           _Holiday._FromTime = deepCopy._FromTime;
           _Holiday._Id = deepCopy._Id;
           _Holiday._IsEnable = deepCopy._IsEnable;
           _Holiday._IsEveryYear = deepCopy._IsEveryYear;
           _Holiday._Symbol= deepCopy._Symbol;
           _Holiday._ToTime = deepCopy._ToTime;
       }
       public override int ID
       {
           get { return ProtocolStructIDS.Holiday_ID; }
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
           AppendStr(_Holiday._Day);
           AppendStr(_Holiday._Description);
           AppendStr(_Holiday._FromTime);
           AppendStr(_Holiday._Id);
           AppendStr(_Holiday._IsEnable);
           AppendStr(_Holiday._IsEveryYear);
           AppendStr(_Holiday._Symbol);
           AppendStr(_Holiday._ToTime);
           EndStrW();
       }

       public override void ReadString(string Msgbfr)
       {
           StartStrR(Msgbfr);

           _Holiday._Day =clsUtility.GetDate4ProtoStru(SpltString[0]);
           _Holiday._Description = SpltString[1];
           _Holiday._FromTime=SpltString[2];
           _Holiday._Id = clsUtility.GetInt(SpltString[3]);
           _Holiday._IsEnable = Convert.ToBoolean(SpltString[4]);
           _Holiday._IsEveryYear =Convert.ToBoolean(SpltString[5]);
           _Holiday._Symbol = SpltString[6];
           _Holiday._ToTime = SpltString[7];

       }
       public override string ToString()
       {
           return _Holiday==null? base.ToString():_Holiday.ToString();
       }

       public override bool ValidateData()
       {
           throw new NotImplementedException();
       }
    }
}
