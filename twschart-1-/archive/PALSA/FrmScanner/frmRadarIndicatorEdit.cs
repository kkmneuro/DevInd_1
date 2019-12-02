using System;
using Nevron.UI.WinForm.Controls;

namespace PALSA.FrmScanner
{
    public partial class frmRadarIndicatorEdit : NForm
    {
        private string m_script;

        public string Script
        {
            get { return m_script; }
            set { m_script = value; }
        }

        public frmRadarIndicatorEdit(string indicator, string script)
        {
            InitializeComponent();
            lblName.Text = indicator;
            txtScript.Text = script;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            m_script = txtScript.Text;
        }
    }
}
