using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Nevron.UI.WinForm.Controls;

namespace BOADMIN_NEW.Forms
{
    public partial class frmHolidays : FrmBase
    {
        private static frmHolidays _Instance = null;

        public static frmHolidays INSTANCE
        {
            get
            {
                if (_Instance == null)
                    _Instance = new frmHolidays();
                return _Instance;
            }
        }
        public frmHolidays()
        {
            InitializeComponent();
            this.Palette.UseThemes = true;
        }

        private void frmHolidays_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instance = null;
        }

        private void frmHolidays_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.favicon;
        }
    }
}
