using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using BOADMIN_NEW.BOEngineServiceTCP;
using BOADMIN_NEW.Cls;

namespace BOADMIN_NEW.Uctl
{
    public partial class uctlChangePassword : UserControl
    {
        public string LoginID
        {
            set
            {
                ui_ntxtLoginId.Text = value;
            }
        }

        public string OldPassword
        {
            set
            {
                ui_ntxtOldPassword.Text = value;
                ui_ntxtOldPassword.PasswordChar = new char();
            }
        }

        public uctlChangePassword()
        {
            InitializeComponent();
        }

        private void ui_nbtnChangePassword_Click(object sender, EventArgs e)
        {
            if (ui_ntxtNewPassword.Text!=ui_ntxtConfirmNewPwd.Text)
            {
                clsDialogBox.ShowErrorBox("Password and confirm password don't match","Change Password",true);
                return;
            }
            clsLogin objclsLogin = new clsLogin();
            objclsLogin.LoginId = ui_ntxtLoginId.Text;
            objclsLogin.Password = ui_ntxtNewPassword.Text;
            objclsLogin.BrokerCompany = ui_ntxtOldPassword.Text;
           
            objclsLogin= clsProxyClassManager.INSTANCE.Login(clsGlobal.userIDPwd, objclsLogin);

            if (objclsLogin.ServerResponseID != clsGlobal.FailureID)
            {
                clsDialogBox.ShowErrorBox("Password changed successfully", "Change Password",true);
            }
            
            this.ParentForm.Close();
        }

        private void ui_nbtnClose_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void uctlChangePassword_Load(object sender, EventArgs e)
        {
            //ui_ntxtLoginId.Text = clsGlobal.CLietnID;
        }
    }
}
