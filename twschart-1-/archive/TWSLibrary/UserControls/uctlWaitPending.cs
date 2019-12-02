using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CommonLibrary.UserControls
{
    public partial class uctlWaitPending : UserControl
    {
        public uctlWaitPending()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }
        public event Action OnCancelClick = delegate { };
        private void btnCancel_Click(object sender, EventArgs e)
        {
            OnCancelClick();
        }


    }
}
