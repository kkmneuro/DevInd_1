using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonLibrary.Cls;

namespace CommonLibrary.UserControls
{
    public partial class UctlChangePassword : UctlBase
    {
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

        /// <summary>
        /// 
        /// </summary>
        public string NewPassword
        {
            get { return ui_ntxtNewPassword.Text; }
            set { ui_ntxtNewPassword.Text = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string ConfirmPassword
        {
            get { return ui_ntxtConfirmPassword.Text; }
            set { ui_ntxtConfirmPassword.Text = value; }
        }

        public UctlChangePassword()
        {
            InitializeComponent();
        }

        private void UctlChangePassword_Load(object sender, EventArgs e)
        {
            //ui_ntxtUserCode.Text = null;
            ui_ntxtPassword.Text = null;
            ui_ntxtNewPassword.Text = null;
            SetLocalization();
        }

        public event Action<object, EventArgs> OnOkClick = delegate { };
        public event Action<object, EventArgs> OnCancelClick = delegate { };

        public override void SetLocalization()
        {
           
        }
        private void ui_ntxtUserCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClsGlobal.KeyPressHandler(ui_ntxtUserCode.Text, e, TextType.All, 50, 1);
        }
        private void ui_ntxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClsGlobal.KeyPressHandler(ui_ntxtPassword.Text, e, TextType.All, 50, 1);
        }
        private void ui_ntxtNewPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClsGlobal.KeyPressHandler(ui_ntxtNewPassword.Text, e, TextType.All, 50, 1);
        }
        private void ui_ntxtConfirmPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClsGlobal.KeyPressHandler(ui_ntxtConfirmPassword.Text, e, TextType.All, 50, 1);
        }
        private void ui_nbtnOk_Click(object sender, EventArgs e)
        {
            string message=string.Empty;
            if (ValidateInput(out message))
            {
                OnOkClick(sender, e);
                ui_nbtnOk.Enabled = false;

            }
            else
            {
                if (message != string.Empty)
                    MessageBox.Show(message);
            }
        }

        private bool ValidateInput(out string msg)
        {
            msg = string.Empty;
            string x=string.Empty;
            bool newConfirm = false;
            bool oldpwd = false;
            if (ui_ntxtPassword.Text.Trim() != string.Empty)
            {
                oldpwd = true;
            }
            else
            {
                msg += "# Old Password can not be left empty." + Environment.NewLine;

                x="O";
                oldpwd = false;
            }
            if (ui_ntxtNewPassword.Text.Trim() != string.Empty)
            {
                if (ui_ntxtNewPassword.Text.Trim() == ui_ntxtConfirmPassword.Text.Trim())
                {
                    newConfirm = true;
                }
                else
                {
                   msg+="# Confirm password is not matching with new password please retype."+Environment.NewLine;
                   
                    x+="C";
                    newConfirm = false;
                }
            }
            else
            {
                msg += "# New password can not be empty."+Environment.NewLine;
                x+="N";
               
                newConfirm = false;
            }
            if (x.Contains("C"))
            {
                ui_ntxtConfirmPassword.Text = string.Empty;
                ui_ntxtConfirmPassword.Focus();
            }
            if (x.Contains("N"))
            {
                ui_ntxtNewPassword.Text = string.Empty;
                ui_ntxtNewPassword.Focus();
            }
            if (x.Contains("O"))
            {
                ui_ntxtPassword.Text = string.Empty;
                ui_ntxtPassword.Focus();
            }

            return oldpwd && newConfirm;
        }
        private void ui_nbtnCancel_Click(object sender, EventArgs e)
        {
            OnCancelClick(sender, e);
        }
   
    }
}
