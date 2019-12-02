namespace TWS.Frm
{
    partial class frmAdminMessageLog
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
            this.uctlAdminMessageLog1 = new CommonLibrary.UserControls.UctlAdminMessageLog();
            this.SuspendLayout();
            // 
            // uctlAdminMessageLog1
            // 
            this.uctlAdminMessageLog1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uctlAdminMessageLog1.Location = new System.Drawing.Point(0, 0);
            this.uctlAdminMessageLog1.Name = "uctlAdminMessageLog1";
            this.uctlAdminMessageLog1.Size = new System.Drawing.Size(769, 276);
            this.uctlAdminMessageLog1.TabIndex = 0;
            this.uctlAdminMessageLog1.Title = "  ";
            // 
            // frmAdminMessageLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 276);
            this.Controls.Add(this.uctlAdminMessageLog1);
            this.Name = "frmAdminMessageLog";
            this.ShowCaptionImage = false;
            this.ShowIcon = false;
            this.Text = "frmAdminMessageLog";
            this.Title = "frmAdminMessageLog";
            this.Load += new System.EventHandler(this.frmAdminMessageLog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CommonLibrary.UserControls.UctlAdminMessageLog uctlAdminMessageLog1;
    }
}