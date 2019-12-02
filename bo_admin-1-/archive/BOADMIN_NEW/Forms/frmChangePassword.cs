using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BOADMIN_NEW.Forms
{
    public partial class frmChangePassword : FrmBase
    {
        public frmChangePassword()
        {
            InitializeComponent();
        }

        private void uctlChangePassword1_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.favicon;
        }

        public string LoginID
        {
            set
            {
               uctlChangePassword1.LoginID = value;
            }
        }

        public string OldPassword
        {
            set
            {
                uctlChangePassword1.OldPassword = value;
            }
        }
    }
}
