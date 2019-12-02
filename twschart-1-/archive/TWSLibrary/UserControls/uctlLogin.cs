///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION
//16/01/2012	VP		    1.Designing and Coding of Login user control
//02/02/2012	VP		    1.Commenting of the code
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Windows.Forms;
using CommonLibrary.Cls;

namespace CommonLibrary.UserControls
{
    public partial class UctlLogin : UctlBase
    {
        #region    "      MEMBERS       "

        private string _title = "Login";

        #endregion "      MEMBERS       "

        #region    "      PROPERTY      "

        /// <summary>
        /// Sets and gets the title of the AlertDialog control
        /// </summary>
        public override string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string UserCode
        {
            get { return ui_ntxtUserCode.Text; }
            set { ui_ntxtUserCode.Text = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Password
        {
            get { return ui_ntxtPassword.Text; }
            set { ui_ntxtPassword.Text = value; }
        }

        public bool SavePassword
        {
            get { return ui_nChkSavePassword.Checked; }
            set { ui_nChkSavePassword.Checked = value; }
        }

        #endregion "      PROPERTY      "

        #region "        CONSTRUCTOR      "

        /// <summary>
        /// Constructor for initilizing the components of the uctlAlertDialog 
        /// </summary>
        public UctlLogin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor for initilizing the components of the uctlAlertDialog with customised settings
        /// </summary>
        /// <param name="customizeSettings"></param>
        public UctlLogin(object customizeSettings)
        {
        }

        #endregion "     CONSTRUCTOR      "

        #region    "      METHODS       "

        /// <summary>
        /// Sets the text of the controls corresponding the localize value
        /// </summary>
        public override void SetLocalization()
        {
            //Title = Cls.clsLocalizationHandler.;
        }

        /// <summary>
        /// Invokes OnOkClick click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_nbtnOk_Click(object sender, EventArgs e)
        {
            OnOkClick(sender, e);
        }

        /// <summary>
        /// Invokes OnCancelClick click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_nbtnCancel_Click(object sender, EventArgs e)
        {
            OnCancelClick(sender, e);
        }

        /// <summary>
        /// Called when the keyboard key pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_ntxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClsGlobal.KeyPressHandler(ui_ntxtUserCode.Text, e, TextType.All, 50, 1);
            //if (e.KeyChar == (char)22)
            //{
            //    e.Handled = true;
            //}
        }

        /// <summary>
        /// Called when the keyboard key pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_ntxtNewPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClsGlobal.KeyPressHandler(ui_ntxtUserCode.Text, e, TextType.All, 50, 1);
            if (e.KeyChar == (char) 22)
            {
                e.Handled = true;
            }
        }

        #endregion "      METHODS       "

        #region    "      EVENTS        "

        public event Action<object, EventArgs> OnOkClick = delegate { };
        //public event Action<object, EventArgs> OnSavePasswordCheckedChanged = delegate { };
        public event Action<object, EventArgs> OnCancelClick = delegate { };

        #endregion "      EVENTS        "

        /// <summary>
        /// Task to be performed on control load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uctlLogin_Load(object sender, EventArgs e)
        {
            SetLocalization();
        }

        private void ui_ntxtUserCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClsGlobal.KeyPressHandler(ui_ntxtUserCode.Text, e, TextType.All, 50, 1);
        }

        //private void ui_nChkSavePassword_CheckedChanged(object sender, EventArgs e)
        //{
        //    OnSavePasswordCheckedChanged(sender, e);
        //}
    }
}