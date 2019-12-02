using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nevron.UI.WinForm.Controls;
using TWS.Cls;
using CommonLibrary.Cls;

namespace TWS.Frm
{
    public partial class frmChangePassword : frmBase
    {
        string _username = string.Empty;
        public frmChangePassword(string userName)
        {
            InitializeComponent();
            _username = userName;
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            clsTWSOrderManagerJSON.INSTANCE.OnChangePasswordResponse -= new Action<string, string, bool>(INSTANCE_OnChangePassword);
            clsTWSOrderManagerJSON.INSTANCE.OnChangePasswordResponse += new Action<string, string, bool>(INSTANCE_OnChangePassword);
            this.uctlChangePassword1.ui_ntxtUserCode.Text = _username;
        }
        private void INSTANCE_OnChangePassword(string usercode, string reason, bool isChanged)
        {
            if (isChanged)
            {
                ClsCommonMethods.ShowInformation("Password changed successfuly.");
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
