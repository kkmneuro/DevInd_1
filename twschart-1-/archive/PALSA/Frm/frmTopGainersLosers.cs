///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION	
//04/02/2012	NAMO	    1.Desgining of the form
//06/02/2012	NAMO	    1.Added code for persistency of form
//14/02/2012	NAMO	    1.Code for displaying insturments in instrument combobox
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Windows.Forms;
using PALSA.Cls;

namespace PALSA.Frm
{
    public partial class frmTopGainersLosers : frmBase
    {
        private static int count;
        private string _formkey;

        public frmTopGainersLosers()
        {
            InitializeComponent();
            count += 1;
            _formkey = CommandIDS.TOP_GAINERS_LOSERS.ToString() + "/" + Convert.ToString(count);
        }

        public override string Formkey
        {
            get { return _formkey; }
        }

        public override string Title
        {
            get { return Text; }
            set { Text = value; }
        }

        private void frmTopGainersLosers_Load(object sender, EventArgs e)
        {
            Title = ui_uctlTopGainerLoser.Title;

            ui_uctlTopGainerLoser.AddInstruments(ClsTWSContractManager.INSTANCE.GetProductTypes());
        }

        private void frmTopGainersLosers_FormClosed(object sender, FormClosedEventArgs e)
        {
            count -= 1;
            _formkey = CommandIDS.TOP_GAINERS_LOSERS.ToString() + "/" + Convert.ToString(count);
        }
    }
}