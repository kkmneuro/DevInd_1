namespace BOADMIN_NEW.Forms
{
    partial class frmInstrumentClosingPrice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInstrumentClosingPrice));
            this.uctlInstrumentClosingPrice1 = new BOADMIN_NEW.Uctl.uctlInstrumentClosingPrice();
            this.SuspendLayout();
            // 
            // uctlInstrumentClosingPrice1
            // 
            this.uctlInstrumentClosingPrice1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uctlInstrumentClosingPrice1.Location = new System.Drawing.Point(0, 0);
            this.uctlInstrumentClosingPrice1.Name = "uctlInstrumentClosingPrice1";
            this.uctlInstrumentClosingPrice1.Size = new System.Drawing.Size(659, 249);
            this.uctlInstrumentClosingPrice1.TabIndex = 0;
            // 
            // frmInstrumentClosingPrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 249);
            this.Controls.Add(this.uctlInstrumentClosingPrice1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmInstrumentClosingPrice";
            this.Text = "Instrument Closing Price";
            this.ResumeLayout(false);

        }

        #endregion

        private BOADMIN_NEW.Uctl.uctlInstrumentClosingPrice uctlInstrumentClosingPrice1;
    }
}