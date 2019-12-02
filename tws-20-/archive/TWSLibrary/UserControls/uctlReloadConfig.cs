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
    public partial class uctlReloadConfig : UctlBase
    {
        #region    "      EVENTS        "

        public event Action<sbyte> OnReloadClick = delegate { };        

        #endregion "      EVENTS        "

        public uctlReloadConfig()
        {
            InitializeComponent();
        }

        private void ui_nbtnReloadConfig_Click(object sender, EventArgs e)
        {
            if (ui_ncmbConfig.SelectedIndex == 0)
            {
                Cls.ClsCommonMethods.ShowErrorBox("Please Select configuration.");
            }
            else
            {
                if (ui_ncmbConfig.Text.Trim() == "Reload Markup")
                {
                    OnReloadClick(49);
                }
                else
                {
                    OnReloadClick(50);
                }
            }
            
        }

        private void uctlReloadConfig_Load(object sender, EventArgs e)
        {
            ui_ncmbConfig.SelectedIndex = 0;
        }
    }
}
