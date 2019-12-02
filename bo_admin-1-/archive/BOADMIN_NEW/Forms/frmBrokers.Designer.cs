namespace BOADMIN_NEW.Forms
{
    partial class frmBrokers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBrokers));
            this.uctlBrokers1 = new BOADMIN_NEW.Uctl.uctlBrokers();
            this.SuspendLayout();
            // 
            // uctlBrokers1
            // 
            this.uctlBrokers1.AutoScroll = true;
            this.uctlBrokers1.AutoSize = true;
            this.uctlBrokers1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uctlBrokers1.Location = new System.Drawing.Point(0, 0);
            this.uctlBrokers1.Name = "uctlBrokers1";
            this.uctlBrokers1.Size = new System.Drawing.Size(829, 326);
            this.uctlBrokers1.TabIndex = 0;
            // 
            // frmBrokers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(829, 326);
            this.Controls.Add(this.uctlBrokers1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBrokers";
            this.Sizable = false;
            this.Text = "Brokers";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBrokers_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BOADMIN_NEW.Uctl.uctlBrokers uctlBrokers1;

    }
}