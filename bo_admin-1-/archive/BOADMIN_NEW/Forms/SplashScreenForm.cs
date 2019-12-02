using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nevron.UI.WinForm.Controls;
using System.Diagnostics;
using BOADMIN_NEW.Cls;
using BOADMIN_NEW.Forms;



namespace BOADMIN_NEW
{
    public partial class SplashScreenForm : Form
    {
        delegate void StringParameterDelegate(string Text);
        delegate void SplashShowCloseDelegate();
        private Timer timer1 = new Timer();
        /// <summary>
        /// To ensure splash screen is closed using the API and not by keyboard or any other things
        /// </summary>
        bool CloseSplashScreenFlag = false;

        /// <summary>
        /// Base constructor
        /// </summary>
        public SplashScreenForm()
        {
            InitializeComponent();
            this.label1.Parent = this.pictureBox1;
            this.colorProgressBar1.Parent = this.pictureBox1;
            label1.ForeColor = Color.Red;

            colorProgressBar1.Show();
        }

        /// <summary>
        /// Displays the splashscreen
        /// </summary>
        public void ShowSplashScreen()
        {
            if (InvokeRequired)
            {
                // We're not in the UI thread, so we need to call BeginInvoke
                BeginInvoke(new SplashShowCloseDelegate(ShowSplashScreen));
                return;
            }
            this.Show();
            Application.Run(this);
        }

        /// <summary>
        /// Closes the SplashScreen
        /// </summary>
        public void CloseSplashScreen()
        {
            if (InvokeRequired)
            {
                // We're not in the UI thread, so we need to call BeginInvoke
                BeginInvoke(new SplashShowCloseDelegate(CloseSplashScreen));
                return;
            }
            CloseSplashScreenFlag = true;
            this.Close();
        }

        /// <summary>
        /// Update text in default green color of success message
        /// </summary>
        /// <param name="Text">Message</param>
        public void UdpateStatusText(string Text)
        {
            if (InvokeRequired)
            {
                // We're not in the UI thread, so we need to call BeginInvoke
                BeginInvoke(new StringParameterDelegate(UdpateStatusText), new object[] { Text });
                return;
            }
            // Must be on the UI thread if we've got this far
            label1.ForeColor = Color.Red;
            label1.Text = Text;
        }


        /// <summary>
        /// Prevents the closing of form other than by calling the CloseSplashScreen function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SplashForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CloseSplashScreenFlag == false)
                e.Cancel = true;
        }

        private void InitializeMyTimer()
        {           
            timer1.Interval = 14;

            timer1.Tick += new EventHandler(IncreaseProgressBar);

            timer1.Start();
        }

        private void IncreaseProgressBar(object sender, EventArgs e)
        {

            colorProgressBar1.Increment(2);

            if (colorProgressBar1.Value == colorProgressBar1.Maximum)

                timer1.Stop();
         
        }

        private void SplashScreenForm_Load(object sender, EventArgs e)
        {
           InitializeMyTimer();
        }
    }
}
