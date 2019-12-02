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
    public partial class frmMapOrders : FrmBase
    {
        private static frmMapOrders _Instance = null;

        public static frmMapOrders INSTANCE
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new frmMapOrders();
                }
                return _Instance;
            }
        }

        public frmMapOrders()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.favicon;
        }

        private void frmMapOrders_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instance = null;
        }
    }
}
