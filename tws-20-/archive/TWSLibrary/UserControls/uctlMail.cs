///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION
//02/01/2012	VP		    1.Added comment to properties
//02/02/2012	VP		    1.Commenting of the code
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using CommonLibrary.Cls;

namespace CommonLibrary.UserControls
{
    public partial class UctlMail : UctlBase
    {
        #region    "      MEMBERS       "

        private string _title = "E-Mail Message";
        //private bool IsAlertform = false;
        
        uctlTerminalWindowMails objctlmail_ = null;

        #endregion "      MEMBERS       "

        #region    "      EVENTS        "

        public event Action<string> OnMailSendClick = delegate { };

        #endregion "      EVENTS        "

        #region    "      PROPERTY      "

        /// <summary>
        /// Sets and gets the title of the mail control
        /// </summary>
        public override string Title
        {
            get { return _title; }
            set { _title = value; }
        }


        /// <summary>
        /// This property sets and gets the selected instrument name from ui_ncmbTo combobox . This property is both settable and gettable
        /// </summary>
        public string To
        {
            get { return ui_ncmbTo.SelectedItem.ToString(); }
            set { ui_ncmbTo.SelectedItem = value; }
        }

        /// <summary>
        /// This property sets and gets the text of ui_ntxtSubjet TextBox. This property is both settable and gettable
        /// </summary>
        public string Subject
        {
            get { return ui_ntxtSubject.Text; }
            set { ui_ntxtSubject.Text = value; }
        }

        /// <summary>
        /// This property sets and gets the text of ui_ntxtMailDetails TextBox. This property is both settable and gettable 
        /// </summary>
        public string MailDetails
        {
            get { return ui_txtMailDetails.Text; }
            set { ui_txtMailDetails.Text = value; }
        }

        #endregion "      PROPERTY      "

        #region "         CONSTRUCTOR        "

        /// <summary>
        /// Constructor for initilizing the components of the uctlMail 
        /// </summary>
        public UctlMail()
        {
            InitializeComponent();
        }

        public UctlMail(uctlTerminalWindowMails objctlmail)
        {
            InitializeComponent();
            objctlmail_ = objctlmail;
        }
        /// <summary>
        /// Constructor for initilizing the components of the uctlMail with customised settings
        /// </summary>
        /// <param name="customizeSettings"></param>
        public UctlMail(object customizeSettings)
        {
        }

        #endregion "       CONSTRUCTOR         "

        #region    "      METHODS       "

        /// <summary>
        /// Sets the text of the controls corresponding to localization value
        /// </summary>
        public override void SetLocalization()
        {
            Title = ClsLocalizationHandler.Email + " " + ClsLocalizationHandler.Message;

            ui_lblTo.Text = ClsLocalizationHandler.To + " : ";
            ui_lblSubject.Text = ClsLocalizationHandler.From + " : ";
            ui_nbtnSend.Text = ClsLocalizationHandler.Send;
        }

        #endregion "      METHODS       "

        /// <summary>
        /// Task to be performed on control load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uctlMail_Load(object sender, EventArgs e)
        {
            SetLocalization();
            //if (IsAlertform)
            //{
            //    cboTo.Visible = false;
            //    txtTo.Visible = true;
            //}
            //else
            //{
            //    txtTo.Visible = false;
            //    cboTo.Visible = true;
            //    cboTo.SelectedIndex = 0;
            //}
        }

        private void ui_nbtnSend_Click(object sender, EventArgs e)
        {
            //string data = ui_ncmbTo.Items[ui_ncmbTo.SelectedIndex].ToString() + "/" + ui_ntxtSubject.Text + "/" + ui_txtMailDetails.Text;
            string data = "Server" + "/" + ui_ntxtSubject.Text + "/" + ui_txtMailDetails.Text;
            OnMailSendClick(data);
            this.ParentForm.Close();
        }
    }
}