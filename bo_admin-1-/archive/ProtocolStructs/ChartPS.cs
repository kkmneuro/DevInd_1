using System;
using System.Collections.Generic;
using System.Text;
using clsInterface4OME;
namespace ProtocolStructs
{
   public class ChartPS : IProtocolStruct
    {
       public Chart _Chart;
       public ChartPS()
       {
           _Chart = new Chart();
       }
       public ChartPS(Chart deepCopy)
       {
           _Chart._Close = deepCopy._Close;
           _Chart._High = deepCopy._High;
           _Chart._Id = deepCopy._Id;
           _Chart._Low = deepCopy._Low;
           _Chart._Open = deepCopy._Open;
           _Chart._Time = deepCopy._Time;
           _Chart._Volume = deepCopy._Volume;
       }
       public override int ID
       {
           get { return ProtocolStructIDS.Chart_ID; }
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
           AppendStr(_Chart._Close);
           AppendStr(_Chart._High);
           AppendStr(_Chart._Id);
           AppendStr(_Chart._Low);
           AppendStr(_Chart._Open);
           AppendStr(_Chart._Time);
           AppendStr(_Chart._Volume);
          
         

           EndStrW();
       }

       public override void ReadString(string Msgbfr)
       {
           StartStrR(Msgbfr);

           _Chart._Close = clsUtility.GetDecimal(SpltString[0]);
           _Chart._High = clsUtility.GetDecimal(SpltString[1]);
           _Chart._Id =clsUtility.GetInt(SpltString[2]);
           _Chart._Low = clsUtility.GetDecimal(SpltString[3]);
           _Chart._Open = clsUtility.GetDecimal(SpltString[4]);
           _Chart._Time = clsUtility.GetDate4ProtoStru(SpltString[5]);
           _Chart._Volume = clsUtility.GetDecimal(SpltString[6]);
           

       }

       public override string ToString()
       {
           return _Chart==null?base.ToString():_Chart.ToString();
       }

       public override bool ValidateData()
       {
           throw new NotImplementedException();
       }
    }
}
