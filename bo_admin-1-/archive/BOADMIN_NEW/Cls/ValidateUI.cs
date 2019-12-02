using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using clsInterface4OME;
namespace BOADMIN_NEW.Cls
{
   public  class ValidateUI
    {

       public static bool ValidateIP(string IPAddress, Control uiControl)
       {
           ErrorProvider err = new ErrorProvider();
           if (clsUtil4ProtoVali.ValidateIP(IPAddress))
           {
               return true;
           }
           err.SetError(uiControl, "IP Address is not Valid");
           return false;
       }
     
    
    }
}
