using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BOADMIN_NEW.Uctl
{
    /// <summary>
    /// Accounts connection settings class
    /// </summary>
    public partial class uctlAccountConnectionSettings : UserControl
    {
        public DialogType currentyDialogType;
        public uctlAccountConnectionSettings()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Account connection settings ok click handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_nbtnOk_Click(object sender, EventArgs e)
        {
            if (ui_ntxtAccountId.Text == string.Empty)
            {
                Cls.clsDialogBox.ShowErrorBox("Account Id can't be null", "Gateway Error", true);
                return;
            }
            if (ui_ntxtPassword.Text == string.Empty)
            {
                Cls.clsDialogBox.ShowErrorBox("Password can't be null", "Gateway Error", true);
                return;
            }

            OnOkClick(ui_ntxtAccountId.Text, ui_ntxtPassword.Text, ui_nchkIsEnable.Checked,currentyDialogType);
            this.ParentForm.Close();
        }

        public void SetValues(DataGridViewRow row)
        {
            if (row != null)
            {
                ui_ntxtAccountId.Text = row.Cells["ui_clmAccountId"].Value.ToString();
                ui_ntxtAccountId.Enabled = false;
                ui_ntxtPassword.Text = row.Cells["ui_clmPassword"].Value.ToString();
                ui_nchkIsEnable.Checked = Convert.ToBoolean(row.Cells["ui_clmIsEnable"].Value);
            }
        }
        public event Action<string,string,bool,DialogType> OnOkClick=delegate{};

        private void ui_nbtnCancel_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
    }
}
