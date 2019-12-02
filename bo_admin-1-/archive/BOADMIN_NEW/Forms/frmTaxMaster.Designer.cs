namespace BOADMIN_NEW.Forms
{
    partial class frmTaxMaster
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
            this.uctlTaxMasterMain1 = new BOADMIN_NEW.Uctl.uctlTaxMasterMain();
            this.SuspendLayout();
            // 
            // uctlTaxMasterMain1
            // 
            this.uctlTaxMasterMain1.AutoScroll = true;
            this.uctlTaxMasterMain1.BackColor = System.Drawing.SystemColors.Control;
            this.uctlTaxMasterMain1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uctlTaxMasterMain1.Location = new System.Drawing.Point(0, 0);
            this.uctlTaxMasterMain1.Name = "uctlTaxMasterMain1";
            this.uctlTaxMasterMain1.Size = new System.Drawing.Size(612, 171);
            this.uctlTaxMasterMain1.TabIndex = 0;
            // 
            // frmTaxMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 171);
            this.Controls.Add(this.uctlTaxMasterMain1);
            this.Name = "frmTaxMaster";
            this.Text = "Tax Master";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTaxMaster_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private BOADMIN_NEW.Uctl.uctlTaxMasterMain uctlTaxMasterMain1;
    }
}