namespace BOADMIN_NEW.Forms
{
    partial class frmContractSpecificationMain
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
            this.uctlSymbolMain1 = new BOADMIN_NEW.Uctl.uctlSymbolMain();
            this.SuspendLayout();
            // 
            // uctlSymbolMain1
            // 
            this.uctlSymbolMain1.AutoScroll = true;
            this.uctlSymbolMain1.AutoSize = true;
            this.uctlSymbolMain1.BackColor = System.Drawing.SystemColors.Control;
            this.uctlSymbolMain1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uctlSymbolMain1.Location = new System.Drawing.Point(0, 0);
            this.uctlSymbolMain1.Margin = new System.Windows.Forms.Padding(4);
            this.uctlSymbolMain1.Name = "uctlSymbolMain1";
            this.uctlSymbolMain1.Size = new System.Drawing.Size(950, 436);
            this.uctlSymbolMain1.TabIndex = 0;
            // 
            // frmContractSpecificationMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 436);
            this.Controls.Add(this.uctlSymbolMain1);
            this.Name = "frmContractSpecificationMain";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Contract Specification";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmContractSpecificationMain_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BOADMIN_NEW.Uctl.uctlSymbolMain uctlSymbolMain1;
    }
}