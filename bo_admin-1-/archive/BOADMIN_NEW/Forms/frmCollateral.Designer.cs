namespace BOADMIN_NEW.Forms
{
    partial class frmCollateral
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCollateral));
            this.uctlCollateralMain1 = new BOADMIN_NEW.Uctl.uctlCollateralMain();
            this.SuspendLayout();
            // 
            // uctlCollateralMain1
            // 
            this.uctlCollateralMain1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uctlCollateralMain1.Location = new System.Drawing.Point(0, 0);
            this.uctlCollateralMain1.Name = "uctlCollateralMain1";
            this.uctlCollateralMain1.Size = new System.Drawing.Size(1020, 348);
            this.uctlCollateralMain1.TabIndex = 0;
            // 
            // frmCollateral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 348);
            this.Controls.Add(this.uctlCollateralMain1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCollateral";
            this.Text = "Collateral";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCollateral_FormClosing);
            this.Load += new System.EventHandler(this.frmCollateral_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private BOADMIN_NEW.Uctl.uctlCollateralMain uctlCollateralMain1;
    }
}