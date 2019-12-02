using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nevron.UI.WinForm.Controls;
//using FundXchange.Model.ViewModels.Charts;
using PALSA.Cls;
using PALSA.uctl;

namespace PALSA.FrmScanner
{
    public partial class frmExplorationOptions : NForm
    {
        #region Properties
        private int _barInterval = 1;
        public int Interaval
        {
            get { return _barInterval;}
            set { _barInterval = value; }
        }
        private int _bars = 3;
        public int Bars
        {
            get { return _bars; }
            set { _bars = value; }
        }
        private Periodicity _periodicity = Periodicity.Minutely;
        public Periodicity Periodicity
        {
            get { return _periodicity; }
            set { _periodicity = value; }
        }
        #endregion Properties
        #region Methods
        public frmExplorationOptions()
        {
            InitializeComponent();
            cbTick.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            calculateBarIntervalAndPeriodicity();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void calculateBarIntervalAndPeriodicity()
        {
            
        }
        
        private void rbSpecificDate_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSpecificDate.Checked)
            {
                lblDate.Enabled = true;
                dtpSpecificdate.Enabled = true;
            }
            else
            {
                lblDate.Enabled = false;
                dtpSpecificdate.Enabled = false;
            }
        }

        private void rbIntraDay_CheckedChanged(object sender, EventArgs e)
        {
            if (rbIntraDay.Checked)
            {
                cbTick.Enabled = true;
            }
            else
            {
                cbTick.Enabled = false;
            }
        }
        #endregion Methods
    }
}
