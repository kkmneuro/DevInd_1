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
    public partial class frmTimeSettings : FrmBase
    {
        private static frmTimeSettings _Instance = null;

        public static frmTimeSettings INSTANCE
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new frmTimeSettings();
                }
                return _Instance;
            }
        }

        public frmTimeSettings()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.favicon;
        }

        private void frmTimeSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instance = null;
        }
    }
}
