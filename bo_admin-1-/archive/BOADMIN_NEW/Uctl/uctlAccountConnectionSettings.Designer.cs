namespace BOADMIN_NEW.Uctl
{
    partial class uctlAccountConnectionSettings
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ui_npnlAccountConnectionSettings = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.ui_nchkIsEnable = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.nCheckBox1 = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.ui_nbtnCancel = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nbtnOk = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_lblPassword = new System.Windows.Forms.Label();
            this.ui_ntxtPassword = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_lblAccountId = new System.Windows.Forms.Label();
            this.ui_ntxtAccountId = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_npnlAccountConnectionSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // ui_npnlAccountConnectionSettings
            // 
            this.ui_npnlAccountConnectionSettings.Controls.Add(this.ui_nchkIsEnable);
            this.ui_npnlAccountConnectionSettings.Controls.Add(this.nCheckBox1);
            this.ui_npnlAccountConnectionSettings.Controls.Add(this.ui_nbtnCancel);
            this.ui_npnlAccountConnectionSettings.Controls.Add(this.ui_nbtnOk);
            this.ui_npnlAccountConnectionSettings.Controls.Add(this.ui_lblPassword);
            this.ui_npnlAccountConnectionSettings.Controls.Add(this.ui_ntxtPassword);
            this.ui_npnlAccountConnectionSettings.Controls.Add(this.ui_lblAccountId);
            this.ui_npnlAccountConnectionSettings.Controls.Add(this.ui_ntxtAccountId);
            this.ui_npnlAccountConnectionSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_npnlAccountConnectionSettings.Location = new System.Drawing.Point(0, 0);
            this.ui_npnlAccountConnectionSettings.Name = "ui_npnlAccountConnectionSettings";
            this.ui_npnlAccountConnectionSettings.Size = new System.Drawing.Size(219, 122);
            this.ui_npnlAccountConnectionSettings.TabIndex = 0;
            this.ui_npnlAccountConnectionSettings.Text = "nuiPanel1";
            // 
            // ui_nchkIsEnable
            // 
            this.ui_nchkIsEnable.AutoSize = true;
            this.ui_nchkIsEnable.ButtonProperties.BorderOffset = 2;
            this.ui_nchkIsEnable.Location = new System.Drawing.Point(27, 7);
            this.ui_nchkIsEnable.Name = "ui_nchkIsEnable";
            this.ui_nchkIsEnable.Size = new System.Drawing.Size(59, 17);
            this.ui_nchkIsEnable.TabIndex = 7;
            this.ui_nchkIsEnable.Text = "Enable";
            this.ui_nchkIsEnable.TransparentBackground = true;
            this.ui_nchkIsEnable.UseVisualStyleBackColor = false;
            // 
            // nCheckBox1
            // 
            this.nCheckBox1.AutoSize = true;
            this.nCheckBox1.ButtonProperties.BorderOffset = 2;
            this.nCheckBox1.Location = new System.Drawing.Point(-16, -16);
            this.nCheckBox1.Name = "nCheckBox1";
            this.nCheckBox1.Size = new System.Drawing.Size(87, 17);
            this.nCheckBox1.TabIndex = 6;
            this.nCheckBox1.Text = "nCheckBox1";
            // 
            // ui_nbtnCancel
            // 
            this.ui_nbtnCancel.Location = new System.Drawing.Point(116, 88);
            this.ui_nbtnCancel.Name = "ui_nbtnCancel";
            this.ui_nbtnCancel.Size = new System.Drawing.Size(64, 23);
            this.ui_nbtnCancel.TabIndex = 5;
            this.ui_nbtnCancel.Text = "&Cancel";
            this.ui_nbtnCancel.UseVisualStyleBackColor = false;
            this.ui_nbtnCancel.Click += new System.EventHandler(this.ui_nbtnCancel_Click);
            // 
            // ui_nbtnOk
            // 
            this.ui_nbtnOk.Location = new System.Drawing.Point(44, 88);
            this.ui_nbtnOk.Name = "ui_nbtnOk";
            this.ui_nbtnOk.Size = new System.Drawing.Size(64, 23);
            this.ui_nbtnOk.TabIndex = 4;
            this.ui_nbtnOk.Text = "&Ok";
            this.ui_nbtnOk.UseVisualStyleBackColor = false;
            this.ui_nbtnOk.Click += new System.EventHandler(this.ui_nbtnOk_Click);
            // 
            // ui_lblPassword
            // 
            this.ui_lblPassword.AutoSize = true;
            this.ui_lblPassword.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblPassword.Location = new System.Drawing.Point(30, 62);
            this.ui_lblPassword.Name = "ui_lblPassword";
            this.ui_lblPassword.Size = new System.Drawing.Size(59, 13);
            this.ui_lblPassword.TabIndex = 3;
            this.ui_lblPassword.Text = "Password :";
            // 
            // ui_ntxtPassword
            // 
            this.ui_ntxtPassword.Location = new System.Drawing.Point(95, 59);
            this.ui_ntxtPassword.Name = "ui_ntxtPassword";
            this.ui_ntxtPassword.Size = new System.Drawing.Size(100, 18);
            this.ui_ntxtPassword.TabIndex = 2;
            // 
            // ui_lblAccountId
            // 
            this.ui_lblAccountId.AutoSize = true;
            this.ui_lblAccountId.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblAccountId.Location = new System.Drawing.Point(22, 34);
            this.ui_lblAccountId.Name = "ui_lblAccountId";
            this.ui_lblAccountId.Size = new System.Drawing.Size(67, 13);
            this.ui_lblAccountId.TabIndex = 1;
            this.ui_lblAccountId.Text = "Account ID :";
            // 
            // ui_ntxtAccountId
            // 
            this.ui_ntxtAccountId.Location = new System.Drawing.Point(95, 31);
            this.ui_ntxtAccountId.Name = "ui_ntxtAccountId";
            this.ui_ntxtAccountId.Size = new System.Drawing.Size(100, 18);
            this.ui_ntxtAccountId.TabIndex = 0;
            // 
            // uctlAccountConnectionSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ui_npnlAccountConnectionSettings);
            this.Name = "uctlAccountConnectionSettings";
            this.Size = new System.Drawing.Size(219, 122);
            this.ui_npnlAccountConnectionSettings.ResumeLayout(false);
            this.ui_npnlAccountConnectionSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NUIPanel ui_npnlAccountConnectionSettings;
        private System.Windows.Forms.Label ui_lblPassword;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtPassword;
        private System.Windows.Forms.Label ui_lblAccountId;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtAccountId;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnCancel;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnOk;
        private Nevron.UI.WinForm.Controls.NCheckBox ui_nchkIsEnable;
        private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox1;
    }
}
