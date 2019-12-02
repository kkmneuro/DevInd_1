namespace TWS.Frm
{
    partial class frmChangePassword
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.uctlChangePassword1 = new CommonLibrary.UserControls.UctlChangePassword();
            this.SuspendLayout();
            // 
            // uctlChangePassword1
            // 
            this.uctlChangePassword1.ConfirmPassword = "";
            this.uctlChangePassword1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uctlChangePassword1.Location = new System.Drawing.Point(0, 0);
            this.uctlChangePassword1.Name = "uctlChangePassword1";
            this.uctlChangePassword1.NewPassword = "";
            this.uctlChangePassword1.Password = "";
            this.uctlChangePassword1.Size = new System.Drawing.Size(362, 228);
            this.uctlChangePassword1.TabIndex = 0;
            this.uctlChangePassword1.Title = null;
            this.uctlChangePassword1.UserCode = "";
            this.uctlChangePassword1.OnOkClick += new System.Action<object, System.EventArgs>(this.uctlChangePassword1_OnOkClick);
            this.uctlChangePassword1.OnCancelClick += new System.Action<object, System.EventArgs>(this.uctlChangePassword1_OnCancelClick);
            this.uctlChangePassword1.Load += new System.EventHandler(this.uctlChangePassword1_Load);
            // 
            // frmChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 228);
            this.Controls.Add(this.uctlChangePassword1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChangePassword";
            this.ShowIcon = false;
            this.Sizable = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Change Password";
            this.Load += new System.EventHandler(this.frmChangePassword_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CommonLibrary.UserControls.UctlChangePassword uctlChangePassword1;
    }
}