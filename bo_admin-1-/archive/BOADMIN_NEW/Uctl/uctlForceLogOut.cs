using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BOADMIN_NEW.Cls;

namespace BOADMIN_NEW.Uctl
{
    public partial class uctlForceLogOut : UserControl
    {
        public uctlForceLogOut()
        {
            InitializeComponent();
        }

        private void ui_nbtnLogout_Click(object sender, EventArgs e)
        {
            if (ui_ntxtLoginId.Text == string.Empty)
            {
                clsDialogBox.ShowErrorBox("Please enter login id","Force LogOut",true);
                return;
            }

            if (ui_ntxtPassword.Text == string.Empty)
            {
                clsDialogBox.ShowErrorBox("Please enter password", "Force LogOut", true);
                return;
            }
            BOEngineServiceTCP.clsBrokerOperationsLog objclsBrokerOpLog = new BOEngineServiceTCP.clsBrokerOperationsLog();
            clsProxyClassManager.INSTANCE.LogOut(Cls.clsGlobal.userIDPwd, objclsBrokerOpLog);
            this.ParentForm.Close();
            //clsDialogBox.ShowExitMessageBox("Logout successfull", "Force Logout");
        }
    }
}
