using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Windows.Forms;

namespace TWS.Cls
{
 public  class AlertAction
    {       
        public MailMessage message =  null;
        SmtpClient SmtpMail = null;
        public AlertAction()
        {
            //SmtpMail = new SmtpClient(Initializer.GetReference().objSettingForm_.strSSLServer_, Int32.Parse(Initializer.GetReference().objSettingForm_.strSSLPort_));
            //SmtpMail.Credentials = new NetworkCredential(Initializer.GetReference().objSettingForm_.strSMTPLogin_, Initializer.GetReference().objSettingForm_.strSMTPPassword_);         
             //clsTWSOrderManagerJSON.INSTANCE.onMailDeliveryResponse
        }
      

        //Configuration for Mail // "smtp.gmail.com", 587, "ratan@ltechindia.com", "saumyasahu"
        //for send mail use this function
        //
        public void sendmail(string data)
        {
            try
            {
                //message = new MailMessage();
                string[] arr = data.Split('/');
                //message.From = new MailAddress("");//(Initializer.GetReference().objSettingForm_.strSSLFromAddress_);
                //message.To.Add(new MailAddress(arr[0]));
                //message.Subject = arr[1];
                //message.Body = arr[2];
                //SmtpMail.EnableSsl = true;
                //SmtpMail.SendAsync(message, SmtpMail);
                string to = arr[0];
                string from = FrmMain.INSTANCE.username;
                string subject = arr[1];
                string body = arr[2];
                //clsTWSOrderManagerJSON.INSTANCE.SendMail(DateTime.UtcNow, subject, from, to, body);
                clsTWSOrderManagerJSON.INSTANCE.SendMail(DateTime.UtcNow, "TESTING", "ecx304", "ALL", body);
            }
            catch(Exception)
            {
               // Logger.LogEx(ex, "AlertAction", "sendmail(string data)");
            }
        }

        //
        //for file firing
        //
        public void Executefile(string path)
        {
            try
            {
                string[] str = path.Split('\\');
                if (str.Length == 1)
                {
                    string filename = String.Empty;
                    string[] filePaths = Directory.GetFiles(Application.StartupPath + "\\Resx");//Directory.GetFiles(frmMainGTS.strExePath_ + @"\res");
                    foreach (string str1 in filePaths)
                    {
                        filename = str1.Remove(0, str1.LastIndexOf('\\') + 1);                        
                        filename = filename.Remove(filename.LastIndexOf('.'), 4);
                        if (filename == path)
                        {
                            path = str1;
                            break;
                        }
                    }                                  
                }     
                System.Diagnostics.Process Proc = new System.Diagnostics.Process();
                Proc.StartInfo.FileName = path;
                Proc.Start();
            }
            catch(Exception)
            {
                //Logger.LogEx(ex, "AlertAction", "Executefile(string path)");
            }
        }

        //
        //For firing sound File
        //
        ////public void PlaySound(string soundpath)
        ////{
        ////    try
        ////    {
        ////        string[] str = soundpath.Split('\\');
        ////        if (str.Length == 1)
        ////        {
        ////            string filename = String.Empty;
        ////            string[] filePaths = Directory.GetFiles(Application.StartupPath + "\\Resx");//Directory.GetFiles(frmMainGTS.strExePath_ + @"\res");
        ////            foreach (string str1 in filePaths)
        ////            {
        ////                filename = str1.Remove(0, str1.LastIndexOf('\\') + 1);
        ////                filename = filename.Remove(filename.LastIndexOf('.'), 4);
        ////                if (filename == soundpath)
        ////                {
        ////                    soundpath = str1;
        ////                    break;
        ////                }
        ////            }
        ////        }
        ////        WSounds ws = new WSounds();
        ////        ws.Play(soundpath, ws.SND_FILENAME | ws.SND_ASYNC);
        ////    }
        ////    catch(Exception ex) 
        ////    {
        ////        //Logger.LogEx(ex, "AlertAction", "PlaySound(string soundpath)");
        ////    }
        
        ////}
    }
}
