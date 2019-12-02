using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DataFeederSln.Cls
{
    public static class Common
    {
        public static void Log(TextBox textBox1, string FilePath, string pText)
        {
            textBox1.AppendText(pText);
            textBox1.AppendText("\r\n");

            //string workingDir = string.Empty;
            //workingDir = Application.StartupPath + "\\Logs" + "\\Log_" + DateTime.Now.ToString("dd_MM_yyyy");
            string workingDir = FilePath;
            if (File.Exists(workingDir + "\\DDEPipeClientMT4Log.txt"))
            {
                TextWriter tsw = new StreamWriter(workingDir + "\\DDEPipeClientMT4Log.txt", true);
                //TextWriter tsw = new StreamWriter(@"C:\PipeClientDDEMT4Log.txt", true);
                tsw.WriteLine(pText);
                tsw.Close();
            }
            else
            {
                System.IO.Directory.CreateDirectory(workingDir);
                FileStream fsDevelopmentLog = new FileStream(workingDir + "\\DDEPipeClientMT4Log.txt", FileMode.OpenOrCreate, FileAccess.Write,
                                                  FileShare.ReadWrite);
                fsDevelopmentLog.Close();
                try
                {
                    TextWriter tsw = new StreamWriter(workingDir + "\\DDEPipeClientMT4Log.txt", true);
                    //TextWriter tsw = new StreamWriter(@"C:\PipeClientDDEMT4Log.txt", true);
                    tsw.WriteLine(pText);
                    tsw.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public static void Log(string FilePath, string pText)
        {
            string workingDir = FilePath;
          //  workingDir = Application.StartupPath + "\\Logs" + "\\Log_" + DateTime.Now.ToString("dd_MM_yyyy");

            if (File.Exists(workingDir + "\\MT4Data.txt"))
            {
                TextWriter tsw = new StreamWriter(workingDir + "\\MT4Data.txt", true);               
                tsw.WriteLine(pText);
                tsw.Close();
            }
            else
            {
                System.IO.Directory.CreateDirectory(workingDir);
                FileStream fsDevelopmentLog = new FileStream(workingDir + "\\MT4Data.txt", FileMode.OpenOrCreate, FileAccess.Write,
                                                  FileShare.ReadWrite);
                fsDevelopmentLog.Close();
                try
                {
                    TextWriter tsw = new StreamWriter(workingDir + "\\MT4Data.txt", true);                
                    tsw.WriteLine(pText);
                    tsw.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
