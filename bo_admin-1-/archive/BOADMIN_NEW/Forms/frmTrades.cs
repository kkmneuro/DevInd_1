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
    public partial class frmTrades : FrmBase
    {
        private static frmTrades _Instance = null;

        public static frmTrades INSTANCE
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new frmTrades();
                }
                return _Instance;
            }
        }

        public frmTrades()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.favicon;
        }

        private void frmTrades_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instance = null;
        }
    }
}
