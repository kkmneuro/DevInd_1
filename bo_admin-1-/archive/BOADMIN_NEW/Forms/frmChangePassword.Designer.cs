namespace BOADMIN_NEW.Forms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChangePassword));
            this.uctlChangePassword1 = new BOADMIN_NEW.Uctl.uctlChangePassword();
            this.SuspendLayout();
            // 
            // uctlChangePassword1
            // 
            this.uctlChangePassword1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uctlChangePassword1.Location = new System.Drawing.Point(0, 0);
            this.uctlChangePassword1.Name = "uctlChangePassword1";
            this.uctlChangePassword1.Size = new System.Drawing.Size(302, 153);
            this.uctlChangePassword1.TabIndex = 0;
            this.uctlChangePassword1.Load += new System.EventHandler(this.uctlChangePassword1_Load);
            // 
            // frmChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 153);
            this.Controls.Add(this.uctlChangePassword1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmChangePassword";
            this.Text = "Change Password";
            this.ResumeLayout(false);

        }

        #endregion

        private BOADMIN_NEW.Uctl.uctlChangePassword uctlChangePassword1;
    }
}