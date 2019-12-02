namespace BOADMIN_NEW.Forms
{
    partial class frmFeeMaster
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
            this.uctlFeesMasterMain1 = new BOADMIN_NEW.Uctl.uctlFeesMasterMain();
            this.SuspendLayout();
            // 
            // uctlFeesMasterMain1
            // 
            this.uctlFeesMasterMain1.AutoScroll = true;
            this.uctlFeesMasterMain1.BackColor = System.Drawing.SystemColors.Control;
            this.uctlFeesMasterMain1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uctlFeesMasterMain1.Location = new System.Drawing.Point(0, 0);
            this.uctlFeesMasterMain1.Name = "uctlFeesMasterMain1";
            this.uctlFeesMasterMain1.Size = new System.Drawing.Size(672, 232);
            this.uctlFeesMasterMain1.TabIndex = 0;
            // 
            // frmFeeMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 232);
            this.Controls.Add(this.uctlFeesMasterMain1);
            this.Name = "frmFeeMaster";
            this.Text = "Fees Master";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFeeMaster_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private BOADMIN_NEW.Uctl.uctlFeesMasterMain uctlFeesMasterMain1;
    }
}