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
    public partial class frmVirtualDealer : FrmBase
    {
        private static frmVirtualDealer _Instance = null;

        public static frmVirtualDealer INSTANCE
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new frmVirtualDealer();
                }
                return _Instance;
            }
        }

        public frmVirtualDealer()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.favicon;
        }

        private void frmVirtualDealer_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instance = null;
        }
    }
}
