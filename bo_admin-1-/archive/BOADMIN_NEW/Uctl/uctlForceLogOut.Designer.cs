namespace BOADMIN_NEW.Uctl
{
    partial class uctlForceLogOut
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
            this.ui_nbtnLogout = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_ntxtPassword = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_lblNewPassword = new System.Windows.Forms.Label();
            this.ui_ntxtLoginId = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_lblLoginID = new System.Windows.Forms.Label();
            this.nuiPanel1 = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.nuiPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ui_nbtnLogout
            // 
            this.ui_nbtnLogout.Location = new System.Drawing.Point(92, 65);
            this.ui_nbtnLogout.Name = "ui_nbtnLogout";
            this.ui_nbtnLogout.Size = new System.Drawing.Size(74, 22);
            this.ui_nbtnLogout.TabIndex = 2;
            this.ui_nbtnLogout.Text = "LogOut";
            this.ui_nbtnLogout.UseVisualStyleBackColor = false;
            this.ui_nbtnLogout.Click += new System.EventHandler(this.ui_nbtnLogout_Click);
            // 
            // ui_ntxtPassword
            // 
            this.ui_ntxtPassword.Location = new System.Drawing.Point(83, 36);
            this.ui_ntxtPassword.Name = "ui_ntxtPassword";
            this.ui_ntxtPassword.PasswordChar = '*';
            this.ui_ntxtPassword.Size = new System.Drawing.Size(137, 18);
            this.ui_ntxtPassword.TabIndex = 1;
            // 
            // ui_lblNewPassword
            // 
            this.ui_lblNewPassword.AutoSize = true;
            this.ui_lblNewPassword.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblNewPassword.Location = new System.Drawing.Point(22, 38);
            this.ui_lblNewPassword.Name = "ui_lblNewPassword";
            this.ui_lblNewPassword.Size = new System.Drawing.Size(56, 13);
            this.ui_lblNewPassword.TabIndex = 15;
            this.ui_lblNewPassword.Text = "Password:";
            this.ui_lblNewPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ui_ntxtLoginId
            // 
            this.ui_ntxtLoginId.Location = new System.Drawing.Point(83, 12);
            this.ui_ntxtLoginId.Name = "ui_ntxtLoginId";
            this.ui_ntxtLoginId.Size = new System.Drawing.Size(137, 18);
            this.ui_ntxtLoginId.TabIndex = 0;
            // 
            // ui_lblLoginID
            // 
            this.ui_lblLoginID.AutoSize = true;
            this.ui_lblLoginID.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblLoginID.Location = new System.Drawing.Point(28, 14);
            this.ui_lblLoginID.Name = "ui_lblLoginID";
            this.ui_lblLoginID.Size = new System.Drawing.Size(50, 13);
            this.ui_lblLoginID.TabIndex = 13;
            this.ui_lblLoginID.Text = "Login ID:";
            this.ui_lblLoginID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nuiPanel1
            // 
            this.nuiPanel1.Controls.Add(this.ui_nbtnLogout);
            this.nuiPanel1.Controls.Add(this.ui_lblLoginID);
            this.nuiPanel1.Controls.Add(this.ui_ntxtPassword);
            this.nuiPanel1.Controls.Add(this.ui_lblNewPassword);
            this.nuiPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nuiPanel1.Location = new System.Drawing.Point(0, 0);
            this.nuiPanel1.Name = "nuiPanel1";
            this.nuiPanel1.Size = new System.Drawing.Size(245, 101);
            this.nuiPanel1.TabIndex = 17;
            this.nuiPanel1.Text = "nuiPanel1";
            // 
            // uctlForceLogOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ui_ntxtLoginId);
            this.Controls.Add(this.nuiPanel1);
            this.Name = "uctlForceLogOut";
            this.Size = new System.Drawing.Size(245, 101);
            this.nuiPanel1.ResumeLayout(false);
            this.nuiPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtPassword;
        private System.Windows.Forms.Label ui_lblNewPassword;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtLoginId;
        private System.Windows.Forms.Label ui_lblLoginID;
        private Nevron.UI.WinForm.Controls.NUIPanel nuiPanel1;
        internal Nevron.UI.WinForm.Controls.NButton ui_nbtnLogout;
    }
}
