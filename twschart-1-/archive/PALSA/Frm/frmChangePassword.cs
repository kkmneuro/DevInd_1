using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nevron.UI.WinForm.Controls;
using PALSA.Cls;
using CommonLibrary.Cls;

namespace PALSA.Frm
{
    public partial class frmChangePassword : NForm
    {
        bool isPasswordChanged = false;
        public frmChangePassword()
        {
            InitializeComponent();
        }
        //public event Action<string> OnOnChangePassword = delegate { };
        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            isPasswordChanged = false;
            clsTWSOrderManagerJSON.INSTANCE.OnChangePasswordResponse += new Action<string, string, bool>(INSTANCE_OnChangePassword);
            uctlChangePassword1.UserCode = Properties.Settings.Default.LoginName;
        }
        private void INSTANCE_OnChangePassword(string usercode, string reason, bool isChanged)
        {
            
            if (isChanged)
            {
                if (!isPasswordChanged)
                {
                    //OnOnChangePassword(uctlChangePassword1.NewPassword);
                    Properties.Settings.Default.LoginPassword = uctlChangePassword1.NewPassword;
                    //Properties.Settings.Default.LoginPassword = obj;
                    Properties.Settings.Default.Save();
                    //ClsCommonMethods.ShowInformation("Password changed successfuly.");
                    isPasswordChanged = true;
                }
              
                this.Close();
            }
            else
            {
                this.uctlChangePassword1.ui_nbtnOk.Enabled = true;
                ClsCommonMethods.ShowInformation("Powssord change failed ..." + reason);
            }
        }
        private void uctlChangePassword1_Load(object sender, EventArgs e)
        {

        }

        private void uctlChangePassword1_OnOkClick(object arg1, EventArgs arg2)
        {
            clsTWSOrderManagerJSON.INSTANCE.ChangePassword(uctlChangePassword1.UserCode, uctlChangePassword1.Password, uctlChangePassword1.NewPassword, string.Empty);
        }

        private void uctlChangePassword1_OnCancelClick(object arg1, EventArgs arg2)
        {
            clsTWSOrderManagerJSON.INSTANCE.OnChangePasswordResponse -= new Action<string, string, bool>(INSTANCE_OnChangePassword);
            this.Close();
        }
    }
}
