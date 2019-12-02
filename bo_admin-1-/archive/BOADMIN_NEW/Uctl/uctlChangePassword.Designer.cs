namespace BOADMIN_NEW.Uctl
{
    partial class uctlChangePassword
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
            this.ui_npnlChangePassword = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.ui_nbtnClose = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nbtnChangePassword = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_ntxtConfirmNewPwd = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_lblConfirmNewPassword = new System.Windows.Forms.Label();
            this.ui_ntxtNewPassword = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_lblNewPassword = new System.Windows.Forms.Label();
            this.ui_ntxtOldPassword = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_lblOldPassword = new System.Windows.Forms.Label();
            this.ui_ntxtLoginId = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_lblLoginID = new System.Windows.Forms.Label();
            this.ui_npnlChangePassword.SuspendLayout();
            this.SuspendLayout();
            // 
            // ui_npnlChangePassword
            // 
            this.ui_npnlChangePassword.Controls.Add(this.ui_nbtnClose);
            this.ui_npnlChangePassword.Controls.Add(this.ui_nbtnChangePassword);
            this.ui_npnlChangePassword.Controls.Add(this.ui_ntxtConfirmNewPwd);
            this.ui_npnlChangePassword.Controls.Add(this.ui_lblConfirmNewPassword);
            this.ui_npnlChangePassword.Controls.Add(this.ui_ntxtNewPassword);
            this.ui_npnlChangePassword.Controls.Add(this.ui_lblNewPassword);
            this.ui_npnlChangePassword.Controls.Add(this.ui_ntxtOldPassword);
            this.ui_npnlChangePassword.Controls.Add(this.ui_lblOldPassword);
            this.ui_npnlChangePassword.Controls.Add(this.ui_ntxtLoginId);
            this.ui_npnlChangePassword.Controls.Add(this.ui_lblLoginID);
            this.ui_npnlChangePassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_npnlChangePassword.Location = new System.Drawing.Point(0, 0);
            this.ui_npnlChangePassword.Name = "ui_npnlChangePassword";
            this.ui_npnlChangePassword.Size = new System.Drawing.Size(302, 154);
            this.ui_npnlChangePassword.TabIndex = 2;
            this.ui_npnlChangePassword.Text = "nuiPanel1";
            // 
            // ui_nbtnClose
            // 
            this.ui_nbtnClose.Location = new System.Drawing.Point(211, 126);
            this.ui_nbtnClose.Name = "ui_nbtnClose";
            this.ui_nbtnClose.Size = new System.Drawing.Size(67, 22);
            this.ui_nbtnClose.TabIndex = 12;
            this.ui_nbtnClose.Text = "&Close";
            this.ui_nbtnClose.UseVisualStyleBackColor = false;
            this.ui_nbtnClose.Click += new System.EventHandler(this.ui_nbtnClose_Click);
            // 
            // ui_nbtnChangePassword
            // 
            this.ui_nbtnChangePassword.Location = new System.Drawing.Point(104, 126);
            this.ui_nbtnChangePassword.Name = "ui_nbtnChangePassword";
            this.ui_nbtnChangePassword.Size = new System.Drawing.Size(98, 22);
            this.ui_nbtnChangePassword.TabIndex = 11;
            this.ui_nbtnChangePassword.Text = "&Change Password";
            this.ui_nbtnChangePassword.UseVisualStyleBackColor = false;
            this.ui_nbtnChangePassword.Click += new System.EventHandler(this.ui_nbtnChangePassword_Click);
            // 
            // ui_ntxtConfirmNewPwd
            // 
            this.ui_ntxtConfirmNewPwd.Location = new System.Drawing.Point(141, 93);
            this.ui_ntxtConfirmNewPwd.Name = "ui_ntxtConfirmNewPwd";
            this.ui_ntxtConfirmNewPwd.PasswordChar = '*';
            this.ui_ntxtConfirmNewPwd.Size = new System.Drawing.Size(137, 18);
            this.ui_ntxtConfirmNewPwd.TabIndex = 9;
            // 
            // ui_lblConfirmNewPassword
            // 
            this.ui_lblConfirmNewPassword.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblConfirmNewPassword.Location = new System.Drawing.Point(-8, 94);
            this.ui_lblConfirmNewPassword.Name = "ui_lblConfirmNewPassword";
            this.ui_lblConfirmNewPassword.Size = new System.Drawing.Size(144, 18);
            this.ui_lblConfirmNewPassword.TabIndex = 10;
            this.ui_lblConfirmNewPassword.Text = "Confirm New Password:";
            this.ui_lblConfirmNewPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ui_ntxtNewPassword
            // 
            this.ui_ntxtNewPassword.Location = new System.Drawing.Point(141, 66);
            this.ui_ntxtNewPassword.Name = "ui_ntxtNewPassword";
            this.ui_ntxtNewPassword.PasswordChar = '*';
            this.ui_ntxtNewPassword.Size = new System.Drawing.Size(137, 18);
            this.ui_ntxtNewPassword.TabIndex = 7;
            // 
            // ui_lblNewPassword
            // 
            this.ui_lblNewPassword.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblNewPassword.Location = new System.Drawing.Point(35, 66);
            this.ui_lblNewPassword.Name = "ui_lblNewPassword";
            this.ui_lblNewPassword.Size = new System.Drawing.Size(101, 18);
            this.ui_lblNewPassword.TabIndex = 8;
            this.ui_lblNewPassword.Text = "New Password:";
            this.ui_lblNewPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ui_ntxtOldPassword
            // 
            this.ui_ntxtOldPassword.Location = new System.Drawing.Point(141, 39);
            this.ui_ntxtOldPassword.Name = "ui_ntxtOldPassword";
            this.ui_ntxtOldPassword.PasswordChar = '*';
            this.ui_ntxtOldPassword.Size = new System.Drawing.Size(137, 18);
            this.ui_ntxtOldPassword.TabIndex = 5;
            // 
            // ui_lblOldPassword
            // 
            this.ui_lblOldPassword.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblOldPassword.Location = new System.Drawing.Point(56, 40);
            this.ui_lblOldPassword.Name = "ui_lblOldPassword";
            this.ui_lblOldPassword.Size = new System.Drawing.Size(80, 16);
            this.ui_lblOldPassword.TabIndex = 6;
            this.ui_lblOldPassword.Text = "Old Password:";
            this.ui_lblOldPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ui_ntxtLoginId
            // 
            this.ui_ntxtLoginId.Enabled = false;
            this.ui_ntxtLoginId.Location = new System.Drawing.Point(141, 12);
            this.ui_ntxtLoginId.Name = "ui_ntxtLoginId";
            this.ui_ntxtLoginId.Size = new System.Drawing.Size(137, 18);
            this.ui_ntxtLoginId.TabIndex = 3;
            // 
            // ui_lblLoginID
            // 
            this.ui_lblLoginID.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblLoginID.Location = new System.Drawing.Point(56, 14);
            this.ui_lblLoginID.Name = "ui_lblLoginID";
            this.ui_lblLoginID.Size = new System.Drawing.Size(80, 16);
            this.ui_lblLoginID.TabIndex = 4;
            this.ui_lblLoginID.Text = "Login ID:";
            this.ui_lblLoginID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uctlChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ui_npnlChangePassword);
            this.Name = "uctlChangePassword";
            this.Size = new System.Drawing.Size(302, 154);
            this.Load += new System.EventHandler(this.uctlChangePassword_Load);
            this.ui_npnlChangePassword.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NUIPanel ui_npnlChangePassword;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtConfirmNewPwd;
        private System.Windows.Forms.Label ui_lblConfirmNewPassword;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtNewPassword;
        private System.Windows.Forms.Label ui_lblNewPassword;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtOldPassword;
        private System.Windows.Forms.Label ui_lblOldPassword;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtLoginId;
        private System.Windows.Forms.Label ui_lblLoginID;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnClose;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnChangePassword;
    }
}
