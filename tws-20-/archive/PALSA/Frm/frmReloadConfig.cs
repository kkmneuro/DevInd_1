using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TWS.Frm
{
    public partial class frmReloadConfig : frmBase
    {
        public frmReloadConfig()
        {
            InitializeComponent();
        }

        private void frmReloadConfig_Load(object sender, EventArgs e)
        {
            uctlReloadConfig1.OnReloadClick += new Action<sbyte>(uctlReloadConfig1_OnReloadClick);
        }

        void uctlReloadConfig1_OnReloadClick(sbyte obj)
        {
            Cls.clsTWSOrderManagerJSON.INSTANCE.ReloadConfigurationRequest(obj);
            Cls.clsTWSDataManagerJSON.INSTANCE.ReloadConfigurationRequest(obj);
            this.Close();
        }
    }
}
