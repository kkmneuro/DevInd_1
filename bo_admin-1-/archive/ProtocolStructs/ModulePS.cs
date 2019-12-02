using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using clsInterface4OME;

namespace ProtocolStructs
{
    public class ModulePS:IProtocolStruct
    {
        public Module _Module;
       public ModulePS()
       {
           _Module = new Module();
       }
       public ModulePS(Module deepCopy)
       {
           _Module._id = deepCopy._id;
           _Module._ModName = deepCopy._ModName;
           
       }
      
        public override int ID
        {
            get { return ProtocolStructIDS.Module_ID; }
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
            AppendStr(_Module._id);
            AppendStr(_Module._ModName);
            EndStrW();
        }

        public override void ReadString(string Msgbfr)
        {
            StartStrR(Msgbfr);
            _Module._id = clsUtility.GetInt(SpltString[0]);
            _Module._ModName = SpltString[1]; 
        }
        public override string ToString()
        {
            return _Module == null ? base.ToString() : _Module.ToString();
        }

        public override bool ValidateData()
        {
            return true;
        }
    }
}
