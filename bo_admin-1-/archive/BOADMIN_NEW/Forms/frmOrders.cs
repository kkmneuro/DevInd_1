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
    public partial class frmOrders : FrmBase
    {
        private static frmOrders _Instance = null;

        public static frmOrders INSTANCE
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new frmOrders();
                }
                return _Instance;
            }
        }

        public frmOrders()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.favicon;
        }

        private void frmOrders_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instance = null;
        }
    }
}
