using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BOADMIN_NEW.Cls
{
   
    /// <summary>
    /// Initiate instance of SplashScreen
    /// </summary>
    public static class clsSplashScreen
    {
      
        static SplashScreenForm sf = null;

        /// <summary>
        /// Displays the splashscreen
        /// </summary>
        public static void ShowSplashScreen()
        {
            if (sf == null)
            {
                sf = new SplashScreenForm();
                sf.ShowSplashScreen();
            }
        }

        /// <summary>
        /// Closes the SplashScreen
        /// </summary>
        public static void CloseSplashScreen()
        {
            if (sf != null)
            {
                sf.CloseSplashScreen();
                sf = null;
            }
        }

        /// <summary>
        /// Update text in default green color of success message
        /// </summary>
        /// <param name="Text">Message</param>
        public static void UdpateStatusText(string Text)
        {
            if (sf != null)
                sf.UdpateStatusText(Text);

        }
             
    }
}
