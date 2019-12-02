using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using clsInterface4OME;
using ProtocolStructs;

namespace LtechIndia.BackOffice.BOEngine.DAL
{
    class clsServer
    {
        BLBO bl = new BLBO(string.Empty);
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

        }
    }
}
