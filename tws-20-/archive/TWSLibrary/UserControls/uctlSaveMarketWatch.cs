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
    public partial class uctlSaveMarketWatch : UctlBase
    {
        public event Action OnSaveClick = delegate { };
        public uctlSaveMarketWatch()
        {
            InitializeComponent();
        }

        private void uctlSaveMarketWatch_Load(object sender, EventArgs e)
        {
            ui_ncmbMarketWatchName.Focus();
        }
        
        private void ui_npnlSaveMarketWatch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar== 13)
            {
                OnSaveClick();
            }
           
        }

        private void ui_ncmbMarketWatchName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ui_ncmbMarketWatchName.Text.Trim()!="" && e.KeyChar== 13)
            {
                 OnSaveClick();
            }
        }

        private void ui_ncmbMarketWatchName_KeyDown(object sender, KeyEventArgs e)
        {
            if (ui_ncmbMarketWatchName.Text.Trim() != "" && e.KeyCode == Keys.Enter)
            {
                OnSaveClick();
            }
        }            
    }
}
