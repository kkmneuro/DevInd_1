namespace BOADMIN_NEW.Forms
{
    partial class frmIPAccessList
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
            this.uctlIPAccessLstMain1 = new BOADMIN_NEW.Uctl.uctlIPAccessLstMain();
            this.SuspendLayout();
            // 
            // uctlIPAccessLstMain1
            // 
            this.uctlIPAccessLstMain1.AutoScroll = true;
            this.uctlIPAccessLstMain1.BackColor = System.Drawing.SystemColors.Control;
            this.uctlIPAccessLstMain1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uctlIPAccessLstMain1.Location = new System.Drawing.Point(0, 0);
            this.uctlIPAccessLstMain1.Name = "uctlIPAccessLstMain1";
            this.uctlIPAccessLstMain1.Size = new System.Drawing.Size(717, 199);
            this.uctlIPAccessLstMain1.TabIndex = 0;
            // 
            // frmIPAccessList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(717, 199);
            this.Controls.Add(this.uctlIPAccessLstMain1);
            this.Name = "frmIPAccessList";
            this.Sizable = false;
            this.Text = "IP Access";
            this.Load += new System.EventHandler(this.frmIPAccessList_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmIPAccessList_FormClosing);
            this.Resize += new System.EventHandler(this.frmIPAccessList_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private BOADMIN_NEW.Uctl.uctlIPAccessLstMain uctlIPAccessLstMain1;
    }
}