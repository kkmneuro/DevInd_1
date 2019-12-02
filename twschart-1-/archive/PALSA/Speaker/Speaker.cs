using System;
using System.Windows.Forms;
using System.ComponentModel;

namespace M4.Workspace
{
    public class Speaker
    {
        private System.ComponentModel.BackgroundWorker BackgroundWorker1;

        public Speaker()
        {
            BackgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            BackgroundWorker1.DoWork += new DoWorkEventHandler(BackgroundWorker1_DoWork);
        }

        public void Speak(string text)
        {
            try
            {
                while (BackgroundWorker1.IsBusy)
                {
                    Application.DoEvents();
                }
                BackgroundWorker1.RunWorkerAsync(text);
            }
            catch (Exception ex)
            {
                //ErrorService.LogError("frmMain", "Speak", ex.ToString());
            }
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] values = e.Argument.ToString().Split(',');
            string lastWord = "";
            foreach (string v in values)
            {
                string value = v;
                if (value.IndexOf("[") != -1)
                {
                    value = value.Substring(1, value.Length - 2);
                    if (value.Length > 1 && lastWord != "symbol" && lastWord != "news alert" && lastWord != "trade alert")
                    {
                        UnmanagedMethods.PlaySound(Application.StartupPath + @"\Res\multiple.wav", 0, UnmanagedMethods.SND_FILENAME);
                    }
                    else
                    {
                        for (int j = 0; j < value.Length; j++)
                        {
                           UnmanagedMethods.PlaySound(Application.StartupPath + @"\Res\" + value[j] + ".wav", 0, UnmanagedMethods.SND_FILENAME);
                        }
                    }
                }
                else
                {
                    UnmanagedMethods.PlaySound(Application.StartupPath + @"\Res\" + value + ".wav", 0, UnmanagedMethods.SND_FILENAME);
                }
                lastWord = value;
            }
        }
    }
}
