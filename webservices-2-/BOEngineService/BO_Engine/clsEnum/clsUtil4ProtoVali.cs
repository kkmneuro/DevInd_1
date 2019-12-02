using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;



namespace clsInterface4OME
{
  public  static  class clsUtil4ProtoVali
    {
      public static bool ValidateDate(string  date)
      {
          try
          {
              if (date == string.Empty)
              {
                  return true;
              }
              else
              {
                  string regexp1 = @"^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$";
                  string regexp2 = @"^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{2}$";
                  if (Regex.IsMatch(date, regexp1) == true || Regex.IsMatch(date, regexp2) == true)
                      return true;
                  else
                      return false;
              }
          }
          catch
          {
              return false;
          }
          
      }
      public static bool ValidateCompareDate(string FromDate, string ToDate)
      {
          try
          {
              if (ValidateIsEmpty(FromDate) == false || ValidateIsEmpty(ToDate) == false || ValidateDate(FromDate) == false || ValidateDate(ToDate) == false)
                  return false;   
              string[] fromDate = FromDate.Split('-', '/', '.');
              string[] toDate = ToDate.Split('-', '/', '.');
              if (Convert.ToInt32(fromDate[2]) > Convert.ToInt32(toDate[2]))
              {
                  return false;
              }
              else if (Convert.ToInt32(fromDate[2]) < Convert.ToInt32(toDate[2]))
              {
                  return true;
              }
              else
              {
                  if (Convert.ToInt32(fromDate[1]) > Convert.ToInt32(toDate[1]))
                  {
                      return false;
                  }
                  else if (Convert.ToInt32(fromDate[1]) < Convert.ToInt32(toDate[1]))
                  {
                      return true;
                  }
                  else
                  {
                      if (Convert.ToInt32(fromDate[0]) > Convert.ToInt32(toDate[0]))
                      {
                          return false;
                      }
                      else if (Convert.ToInt32(fromDate[0]) < Convert.ToInt32(toDate[0]))
                      {
                          return true;
                      }
                      else
                      {
                          return true;
                      }
                  }
              }
          }
          catch
          {
              return false;
          }
       
      }
      public static bool ValidateIP(string IPAddress)
      {
          try
          {
              if (IPAddress == string.Empty)
                  return true;
              string regexp = @"\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b";
              return Regex.IsMatch(IPAddress, regexp);
          }
          catch
          {
              return false;
          }
      }
      public static bool ValidateEmail(string Email)
      {
          try
          {
              if (Email == string.Empty)
                  return true;
              string regexp = @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$";
              return Regex.IsMatch(Email, regexp);
          }
          catch
          {
              return false;
          }
      }
      public static bool ValidateIsEmpty(object Value)
      {
          try
          {
              if (Value == null)
                  return false;
              else if (Value.ToString() == string.Empty)
                  return false;
              else
                  return true;
          }
          catch
          {
              return false;
          }

      }
      public static bool ValidateIPPort(string IPAddressPort)
      {
          try
          {
              if (IPAddressPort == string.Empty)
                  return true;
              string regexp = @"\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b:([0-9]{1,5})$";
              return Regex.IsMatch(IPAddressPort, regexp);
          }
          catch
          {
              return false;
          }
      }
      public static bool ValidateLength(string Value)
      {
          try
          {
              string regexp = @"^\S{7}$";
              return Regex.IsMatch(Value, regexp);
          }
          catch
          {
              return false;
          }
      }
      public static bool ValidateDecimal(Object Value)
      {
          
              if (Value == null)
                  return true;
              if (Value.ToString() == string.Empty)
                  return true;
              bool res;
              try
              {
                  decimal a = Convert.ToDecimal(Value);
                  res = true;
                  return res;
              }
              catch
              {
                  res = false;
                  return res;
              }         
         
      }
      public static bool ValidateInteger(Object Value)
      {
            if (Value == null)
                  return true;
              if (Value.ToString() == string.Empty)
                  return true;
              bool res;
              try
              {
                  int a = Convert.ToInt32(Value);
                  res = true;
                  return res;
              }
              catch
              {
                  res = false;
                  return res;
              }
        }  
      public static bool ValidateNumberAndCharacter(string Value)
      {
          try
          {
              if (Value == string.Empty)
                  return true;

              string regexp = @"^\w*(?=\w*\d)(?=\w*[a-z])\w*$";
              return Regex.IsMatch(Value, regexp);
          }
          catch
          {
              return false;
          }
      }


      public static bool  ValidateCompareIp(string FromIP, string ToIP)
      {
          try
          {
              if(ValidateIsEmpty(FromIP) == false || ValidateIsEmpty(ToIP) == false || ValidateIP(FromIP)==false || ValidateIP(ToIP) == false )
                   return false;              
              String[] FromIp = FromIP.Split('.');
              String[] ToIp = ToIP.Split('.');
              if ((Convert.ToInt32(FromIp[0])) > (Convert.ToInt32(ToIp[0])))
                  return false;
              else if ((Convert.ToInt32(FromIp[0])) < (Convert.ToInt32(ToIp[0])))
                  return true;
              else
              {
                  if ((Convert.ToInt32(FromIp[1])) > (Convert.ToInt32(ToIp[1])))
                      return false;
                  else if ((Convert.ToInt32(FromIp[1])) < (Convert.ToInt32(ToIp[1])))
                      return true;
                  else
                  {
                      if ((Convert.ToInt32(FromIp[2])) > (Convert.ToInt32(ToIp[2])))
                          return false;
                      else if ((Convert.ToInt32(FromIp[2])) < (Convert.ToInt32(ToIp[2])))
                          return true;
                      else
                      {
                          if ((Convert.ToInt32(FromIp[3])) > (Convert.ToInt32(ToIp[3])))
                              return false;
                          else if ((Convert.ToInt32(FromIp[3])) < (Convert.ToInt32(ToIp[3])))
                              return true;
                          else
                          {
                              return true;
                          }
                      }
                  }
              }
          }
          catch
          {
              return false;
          }
        
      }     
     
    }
}
