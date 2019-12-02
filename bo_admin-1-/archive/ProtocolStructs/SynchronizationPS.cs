using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using clsInterface4OME;
namespace ProtocolStructs
{
    public class SynchronizationPS : IProtocolStruct
    {
        public Synchronization _Synchronization;
       public SynchronizationPS()
       {
           _Synchronization = new Synchronization();
       }
       public SynchronizationPS(Synchronization deepCopy)
       {
           _Synchronization._EndDate = deepCopy._EndDate;
           _Synchronization._IsEnable = deepCopy._IsEnable;
           _Synchronization._IsLimits = deepCopy._IsLimits;
           _Synchronization._Mode = deepCopy._Mode;
           _Synchronization._Server = deepCopy._Server;
           _Synchronization._StartDate = deepCopy._StartDate;
           _Synchronization._Symbols= deepCopy._Symbols;
           _Synchronization._SynchronizationId = deepCopy._SynchronizationId;

           
       }
       public override int ID
       {
           get { return ProtocolStructIDS.Synchronization_ID; }
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
           AppendStr(_Synchronization._EndDate);
           AppendStr(_Synchronization._IsEnable);
           AppendStr(_Synchronization._IsLimits);
           AppendStr(_Synchronization._Mode.ToString());
           AppendStr(_Synchronization._Server);
           AppendStr(_Synchronization._StartDate);
           AppendStr(_Synchronization._Symbols);
           AppendStr(_Synchronization._SynchronizationId);
           EndStrW();
       }

       public override void ReadString(string Msgbfr)
       {
           StartStrR(Msgbfr);

           _Synchronization._EndDate = clsUtility.GetDate4ProtoStru(SpltString[0]);
           _Synchronization._IsEnable =Convert.ToBoolean(SpltString[1]);
           _Synchronization._IsLimits = Convert.ToBoolean(SpltString[2]);
           _Synchronization._Mode = (Synchronization.MODE)Enum.Parse(typeof(Synchronization.MODE), SpltString[3], true);
           _Synchronization._Server = SpltString[4];
           _Synchronization._StartDate = clsUtility.GetDate4ProtoStru(SpltString[5]);
           _Synchronization._Symbols = SpltString[6];
           _Synchronization._SynchronizationId = clsUtility.GetInt(SpltString[7]);
           
       }
       public override string ToString()
       {
           return _Synchronization==null?base.ToString():_Synchronization.ToString();
       }

       public override bool ValidateData()
       {
           base.ValidateData();
           Add2Vld("ServerIp Empty", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty(_Synchronization._Server));
           Add2Vld("ServerIp Port not correct", clsInterface4OME.clsUtil4ProtoVali.ValidateIPPort(_Synchronization._Server));
           Add2Vld("Symbol", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty(_Synchronization._Symbols ));
           Add2Vld(" From Date", clsInterface4OME.clsUtil4ProtoVali.ValidateDate(_Synchronization._StartDate.ToString("dd/MM/yy")));
           Add2Vld(" To Date", clsInterface4OME.clsUtil4ProtoVali.ValidateDate(_Synchronization._EndDate.ToString("dd/MM/yy")));
           Add2Vld(" From Date To Date not correct", clsInterface4OME.clsUtil4ProtoVali.ValidateCompareDate(_Synchronization._StartDate.ToString("dd/MM/yy"), _Synchronization._EndDate.ToString("dd/MM/yy")));
           return IsValidlist();
       }
    }
}
