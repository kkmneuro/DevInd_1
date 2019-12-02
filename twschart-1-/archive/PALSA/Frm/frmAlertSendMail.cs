using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nevron.UI.WinForm.Controls;
using System.Net.Mail;
using System.Net;
using PALSA.FrmScanner;
using PALSA.ClsAlerts;
using PALSA.uctl;
namespace PALSA.Frm
{
    public partial class frmAlertSendMail : NForm
    {
        private bool IsAlertform = false;
        frmAlert objAlert = null;
        uctlMailGrid objctlmail_ = null;
        public frmAlertSendMail(uctlMailGrid objmaigrid_)
        {
        InitializeComponent();
        objctlmail_ = objmaigrid_;
        }
        public frmAlertSendMail( frmAlert obj)
        {
            InitializeComponent();
            objAlert = obj;
            IsAlertform = true;
        }
        /// <summary>
        /// in case of modify data
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="data"></param>

        public frmAlertSendMail(frmAlert obj,string data)
        {
            InitializeComponent();
            objAlert = obj;       
            txtTo.Text = data;
            IsAlertform = true;       
        }
        private void frmAlertSendMail_Load(object sender, EventArgs e)
        {
            if (IsAlertform)
            {
                cboTo.Visible = false;
                txtTo.Visible = true;
            }
            else
            {
                txtTo.Visible = false;
                 cboTo.Visible = true;
                 cboTo.SelectedIndex = 0;
            }
        }

        public void DispalyItem(string subject)
        {
            txtMail.Text = subject;
        }

        /// <summary>
        /// This function is used to Send mail
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            //return;
            if (IsAlertform)
            {
                cboTo.Visible = false;
                objAlert.SetSourceComboText(txtTo.Text + "/" + txtMail.Text + "/" + rtxtAlertmail.Text);
                objAlert.PropMailTo = txtTo.Text;
                this.Close();
            }
            else
            {
                AlertAction mail_ = new AlertAction();
                string data = cboTo.Items[cboTo.SelectedIndex].ToString() + "/" + txtMail.Text + "/" + rtxtAlertmail.Text;
                mail_.sendmail(data);
                this.Close();
            }
        }

        private void SetText()
        {
            try
            {               
                //nStatusBar1.Text = frmMainGTS.rm.GetString("");
                //rtxtAlertmail.Text = frmMainGTS.rm.GetString("");
                //txtMail.Text = frmMainGTS.rm.GetString("");
                //lblSub.Text =frmMainGTS.rm.GetString("");
                //btnSend.Text = frmMainGTS.rm.GetString("");
                //lblTo.Text = frmMainGTS.rm.GetString("");
                //txtTo.Text =frmMainGTS.rm.GetString("");
                //cboTo.Text = frmMainGTS.rm.GetString("");

            }
            catch (Exception ex)
            {
                //ServerLog.Write("frmabout::SetText" + ex.ToString() + ex.StackTrace, true);
                //Logger.LogEx(ex, "frmAlertSendMail", "nbtnTest_Click(object sender, EventArgs e)");
            }

        }
    }
}