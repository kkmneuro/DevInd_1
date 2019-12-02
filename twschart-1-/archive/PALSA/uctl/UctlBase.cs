using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PALSA.uctl
{
    public partial class UctlBase : UserControl
    {
        public UctlBase()
        {
            InitializeComponent();
        }
        public virtual string Formkey { get; set; }

        public virtual string Title
        {
            get { return Text; }
            set { Text = value; }
        }
    }
}
