using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using clsInterface4OME;
namespace ProtocolStructs
{
    public class CommonPS :IProtocolStruct
    {
       public Common _Common;
       public CommonPS()
       {
           _Common = new Common();
       }
       public CommonPS(Common deepCopy)
       {
           _Common._CommonId = deepCopy._CommonId;
           _Common._Property= deepCopy._Property;
           _Common._Value = deepCopy._Value;
           
           
           
       }
       public override int ID
       {
           get { return ProtocolStructIDS.Common_ID; }
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
           AppendStr(_Common._CommonId);
           AppendStr(_Common._Property);
           AppendStr(_Common._Value);
           
          
           

           EndStrW();
       }

       public override void ReadString(string Msgbfr)
       {
           StartStrR(Msgbfr);

           _Common._CommonId= clsUtility.GetInt(SpltString[0]);
           _Common._Property = SpltString[1];
           _Common._Value =SpltString[2];
           
           
           
       }
       public override string ToString()
       {
           return _Common==null?base.ToString():_Common.ToString();
       }

       public override bool ValidateData()
       {
           throw new NotImplementedException();
       }
    }
}
