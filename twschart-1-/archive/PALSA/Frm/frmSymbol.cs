using System;
using System.Windows.Forms;
using Nevron.UI.WinForm.Controls;

namespace PALSA.Frm
{
    public partial class frmSymbol : Nevron.UI.WinForm.Controls.NForm
    {
        public string SelectedSymbol
        {
            get
            {
                return txtSymbol.Text;
            }
        }

        public frmSymbol()
        {
            InitializeComponent();
            txtSymbol.GotFocus += (sender, e) => txtSymbol.SelectAll();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            txtSymbol.Text = txtSymbol.Text.Trim();
            DialogResult = DialogResult.OK;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void frmSymbol_Load(object sender, EventArgs e)
        {
            txtSymbol.Focus();
        }

        //Returns a symbol. Returns OriginalSymbol if no symbol is selected.
        public string GetSymbol(string defaultSymbol, string formCaption)
        {
            txtSymbol.Text = defaultSymbol.Trim();
            Text = formCaption;
            return ShowDialog() == DialogResult.OK ? SelectedSymbol : string.Empty;
        }
    }
}
