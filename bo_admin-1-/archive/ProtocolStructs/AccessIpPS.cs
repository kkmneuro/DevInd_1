using System;
using System.Collections.Generic;
using System.Text;
using clsInterface4OME;
namespace ProtocolStructs
{
   public class AccessIpPS:IProtocolStruct 
    {
       public AccessIp _Ipaccess;
       public AccessIpPS()
       {
           _Ipaccess = new AccessIp();
       }
       public AccessIpPS(AccessIp deepCopy)
       {
           _Ipaccess._Comment = deepCopy._Comment;
           _Ipaccess._FromIp = deepCopy._FromIp;
           _Ipaccess._id = deepCopy._id;
           _Ipaccess._Stauts = deepCopy._Stauts;
           _Ipaccess._ToIp = deepCopy._ToIp;
       }
      
        public override int ID
        {
            get { return ProtocolStructIDS.AccessIp_ID ; }
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
            AppendStr(_Ipaccess._Comment  );
            AppendStr(_Ipaccess._FromIp );
            AppendStr(_Ipaccess._id  );
            AppendStr(_Ipaccess._Stauts);
            AppendStr(_Ipaccess._ToIp );
            EndStrW();
        }

        public override void ReadString(string Msgbfr)
        {
            StartStrR(Msgbfr);

            _Ipaccess._Comment=SpltString[0];
            _Ipaccess._FromIp=SpltString[1]; 
            _Ipaccess._id=clsUtility.GetInt( SpltString[2]);
            _Ipaccess._Stauts =SpltString[3];
            _Ipaccess._ToIp = SpltString[4];


        }
        public override string ToString()
        {
            return _Ipaccess == null ? base.ToString() : _Ipaccess.ToString();
        }

        public override bool ValidateData()
        {
            base.ValidateData();
            Add2Vld("IpFrom", clsInterface4OME.clsUtil4ProtoVali.ValidateIP(_Ipaccess._FromIp));
            Add2Vld("IpTo",clsInterface4OME.clsUtil4ProtoVali.ValidateIP(_Ipaccess._ToIp));
            Add2Vld("IpFromTo", clsInterface4OME.clsUtil4ProtoVali.ValidateCompareIp(_Ipaccess._FromIp,_Ipaccess._ToIp));
            return IsValidlist();
        }
    }
}
