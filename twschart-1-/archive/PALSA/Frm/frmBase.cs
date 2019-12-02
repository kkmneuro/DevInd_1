using System;
using Nevron.UI.WinForm.Controls;

namespace PALSA.Frm
{
    public partial class frmBase : NForm
    {
        //string _title;

        public frmBase()
        {
            InitializeComponent();
        }

        public virtual string Formkey { get; set; }

        public virtual string Title
        {
            get { return Text; }
            set { Text = value; }
        }

        private void frmBase_Load(object sender, EventArgs e)
        {
        }
    }
}