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
    public partial class frmCommonSetting : FrmBase
    {
        private static frmCommonSetting _Instance = null;

        public static frmCommonSetting INSTANCE
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new frmCommonSetting();
                }
                return _Instance;
            }
        }
        public frmCommonSetting()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.favicon;
        }

        private void frmCommonSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instance = null;
        }
    }
}
