///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION	
//19/01/2012	VP		    1.Created form for locking of WorkSpace.
//23/01/2012	VP		    1.Created singlton class of the class.
//02/02/2012	VP		    1.Commenting of the code
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Windows.Forms;
//using Logging;

namespace TWS.Frm
{
    /// <summary>
    /// Code for locking of the workspace
    /// </summary>
    public partial class frmLockWorkStation : Form
    {
        private static frmLockWorkStation _instance;

        /// <summary>
        /// Initializes form components
        /// </summary>
        private frmLockWorkStation()
        {
           //FileHandling.WriteDevelopmentLog("LockWorkStation : Enter into frmLockWorkStation Constructor");

            InitializeComponent();

           //FileHandling.WriteDevelopmentLog("LockWorkStation : Exit from frmLockWorkStation Constructor");
        }

        /// <summary>
        /// Provides instance of this form
        /// </summary>
        public static frmLockWorkStation INSTANCE
        {
            get
            {
                if (_instance == null)
                    _instance = new frmLockWorkStation();
                return _instance;
            }
        }

        /// <summary>
        /// Checks the password authentication
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_ntxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
           //FileHandling.WriteDevelopmentLog("LockWorkStation : Enter into ui_ntxtPassword_KeyDown Method");

            if (e.KeyData == Keys.Enter)
            {
                if (ui_ntxtPassword.Text == Properties.Settings.Default.LoginPassword)
                {
                    Close();
                }
            }

           //FileHandling.WriteDevelopmentLog("LockWorkStation : Exit from ui_ntxtPassword_KeyDown Method");
        }
    }
}