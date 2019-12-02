using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtocolStructs
{
    public class RequestToLogin
    {
        public string LoginId_;
        public string Password_;
        public int BrokerId_;
        public string Role_;
        public string IPAddress_;


        public RequestToLogin()
        {
            LoginId_ = string.Empty;
            Password_ = string.Empty;
            BrokerId_ = 0;
            Role_ = string.Empty;
            IPAddress_ = string.Empty;
            
        }
        public override string ToString()
        {
            return "LoginId : " + LoginId_+
                   " Password : " + Password_+
                   " BrokerId : " + BrokerId_+
                   " Role : " + Role_+
                   "IPAddress_ :" + IPAddress_;
                   
        }
    }
}
