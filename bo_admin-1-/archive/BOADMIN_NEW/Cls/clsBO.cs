using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using clsInterface4OME;
using ProtocolStructs; 


namespace BOADMIN_NEW.Cls
{
    class clsBO
    {
        public static void SendStruct(IProtocolStruct structure)
        { 
        }

        public void DataRecevied(IProtocolStruct structure)
        {
            switch (structure.ID)
            {
                case ProtocolStructIDS.AccessIp_ID:
                    Handle_AccessIp(structure as AccessIpPS);
                    break;
                default:
                    break;
            }
        }

        private void Handle_AccessIp(AccessIpPS accessIpPS)
        {
            throw new NotImplementedException();
        }
    }
}
