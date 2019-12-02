using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace clsInterface4OME
{
    public partial class frmConfirmationBox :Form
    {
        public decimal Price = 0;
        private string _Message;
        public string Message
        {
            get { return _Message; }
            set { _Message = value; }
        }

        public frmConfirmationBox()
        {
            InitializeComponent();
#if DEMO
            lblConfirm.ForeColor = Color.White;
            lblMsg.ForeColor = Color.White;
#endif
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frmConfirmationBox_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnOK;
            this.CancelButton = btnCancel;
        }
        public void VisiblePrice()
        {
            lblPrice.Visible = true;
            txtPrice.Visible = true;
        }
        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            Price = clsUtility.GetDecimal(txtPrice.Text);

        }
    }
}
