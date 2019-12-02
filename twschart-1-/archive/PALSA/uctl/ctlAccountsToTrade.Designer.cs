namespace PALSA.uctl
{
    partial class ctlAccountsToTrade
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
            this.uctlAccountsToTrade1 = new CommonLibrary.UserControls.UctlAccountsToTrade();
            this.SuspendLayout();
            // 
            // uctlAccountsToTrade1
            // 
            this.uctlAccountsToTrade1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uctlAccountsToTrade1.Location = new System.Drawing.Point(0, 0);
            this.uctlAccountsToTrade1.Name = "uctlAccountsToTrade1";
            this.uctlAccountsToTrade1.Size = new System.Drawing.Size(828, 301);
            this.uctlAccountsToTrade1.TabIndex = 0;
            this.uctlAccountsToTrade1.Title = "Accounts Info";
            this.uctlAccountsToTrade1.Load += new System.EventHandler(this.uctlAccountsToTrade1_Load);
            // 
            // ctlAccountsToTrade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.uctlAccountsToTrade1);
            this.Name = "ctlAccountsToTrade";
            this.Size = new System.Drawing.Size(828, 301);
            this.Load += new System.EventHandler(this.ctlAccountsToTrade_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CommonLibrary.UserControls.UctlAccountsToTrade uctlAccountsToTrade1;
    }
}
