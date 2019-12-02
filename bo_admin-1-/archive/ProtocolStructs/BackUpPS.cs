using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using clsInterface4OME;
namespace ProtocolStructs
{
    public class BackUpPS : IProtocolStruct
    {
        public BackUp _BackUp;
       public BackUpPS()
       {
           _BackUp = new BackUp();
       }
       public BackUpPS(BackUp deepCopy)
       {
           _BackUp._BackUpId = deepCopy._BackUpId;
           _BackUp._Property= deepCopy._Property;
           _BackUp._Value = deepCopy._Value;
           
           
           
       }
       public override int ID
       {
           get { return ProtocolStructIDS.BackUp_ID; }
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
           AppendStr(_BackUp._BackUpId);
           AppendStr(_BackUp._Property);
           AppendStr(_BackUp._Value);
           
          
           

           EndStrW();
       }

       public override void ReadString(string Msgbfr)
       {
           StartStrR(Msgbfr);

           _BackUp._BackUpId= clsUtility.GetInt(SpltString[0]);
           _BackUp._Property = SpltString[1];
           _BackUp._Value =SpltString[2];
           
           
           
       }
       public override string ToString()
       {
           return _BackUp==null?base.ToString():_BackUp.ToString();
       }

       public override bool ValidateData()
       {
           throw new NotImplementedException();
       }
    }
}
