namespace PALSA.Frm
{
    partial class frmAccountsToTrade
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
            this.uctlAccountsToTrade1 = new CommonLibrary.UserControls.UctlAccountsToTrade();
            this.SuspendLayout();
            // 
            // uctlAccountsToTrade1
            // 
            this.uctlAccountsToTrade1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uctlAccountsToTrade1.Location = new System.Drawing.Point(0, 0);
            this.uctlAccountsToTrade1.Name = "uctlAccountsToTrade1";
            this.uctlAccountsToTrade1.Size = new System.Drawing.Size(533, 178);
            this.uctlAccountsToTrade1.TabIndex = 0;
            this.uctlAccountsToTrade1.Title = "Accounts To Trade";
            this.uctlAccountsToTrade1.OnApplyClick += new System.Action<string>(this.uctlAccountsToTrade1_OnApplyClick);
            this.uctlAccountsToTrade1.OnAccountsSelected += new System.Action<string>(this.uctlAccountsToTrade1_OnAccountsSelected);
            // 
            // frmAccountsToTrade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 178);
            this.Controls.Add(this.uctlAccountsToTrade1);
            this.KeyPreview = true;
            this.Name = "frmAccountsToTrade";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Accounts Info";
            this.Title = "Accounts Info";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAccountsToTrade_FormClosing);
            this.Load += new System.EventHandler(this.frmAccountsToTrade_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAccountsToTrade_KeyDown);
            this.ResumeLayout(false);

        }

       

        #endregion

        private CommonLibrary.UserControls.UctlAccountsToTrade uctlAccountsToTrade1;
    }
}