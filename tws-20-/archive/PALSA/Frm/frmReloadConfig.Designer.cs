namespace TWS.Frm
{
    partial class frmReloadConfig
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
            this.uctlReloadConfig1 = new CommonLibrary.UserControls.uctlReloadConfig();
            this.SuspendLayout();
            // 
            // uctlReloadConfig1
            // 
            this.uctlReloadConfig1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uctlReloadConfig1.Location = new System.Drawing.Point(0, 0);
            this.uctlReloadConfig1.Name = "uctlReloadConfig1";
            this.uctlReloadConfig1.Size = new System.Drawing.Size(277, 142);
            this.uctlReloadConfig1.TabIndex = 0;
            this.uctlReloadConfig1.Title = null;
            // 
            // frmReloadConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 142);
            this.Controls.Add(this.uctlReloadConfig1);
            this.Name = "frmReloadConfig";
            this.Text = " Reload Configuration";
            this.Title = " Reload Configuration";
            this.Load += new System.EventHandler(this.frmReloadConfig_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CommonLibrary.UserControls.uctlReloadConfig uctlReloadConfig1;
    }
}