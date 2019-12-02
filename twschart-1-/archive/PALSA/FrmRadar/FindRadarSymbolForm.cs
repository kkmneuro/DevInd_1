using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nevron.UI.WinForm.Controls;

namespace PALSA.FrmRadar
{
    public partial class FindRadarSymbolForm : NForm
    {
        public FindRadarSymbolForm()
        {
            InitializeComponent();
        }

        public bool SearchAllPages
        {
            get { return radAllPages.Checked; }
        }

        public string Symbol
        {
            get
            {
                return txtSymbol.Text;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }               
    }
}
