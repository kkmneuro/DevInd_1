namespace BOADMIN_NEW.Forms
{
    partial class frmTimeSettings
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
            this.uctlTimeMain1 = new BOADMIN_NEW.Uctl.uctlTimeMain();
            this.SuspendLayout();
            // 
            // uctlTimeMain1
            // 
            this.uctlTimeMain1.AutoScroll = true;
            this.uctlTimeMain1.BackColor = System.Drawing.SystemColors.Control;
            this.uctlTimeMain1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uctlTimeMain1.Location = new System.Drawing.Point(0, 0);
            this.uctlTimeMain1.Name = "uctlTimeMain1";
            this.uctlTimeMain1.Size = new System.Drawing.Size(687, 169);
            this.uctlTimeMain1.TabIndex = 0;
            // 
            // frmTimeSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 169);
            this.Controls.Add(this.uctlTimeMain1);
            this.Name = "frmTimeSettings";
            this.Text = "Time Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTimeSettings_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private BOADMIN_NEW.Uctl.uctlTimeMain uctlTimeMain1;
    }
}