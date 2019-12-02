namespace BOADMIN_NEW.Forms
{
    partial class frmTrades
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTrades));
            this.uctlTradeMain1 = new BOADMIN_NEW.Uctl.uctlTradeMain();
            this.SuspendLayout();
            // 
            // uctlTradeMain1
            // 
            this.uctlTradeMain1.AutoScroll = true;
            this.uctlTradeMain1.BackColor = System.Drawing.SystemColors.Control;
            this.uctlTradeMain1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uctlTradeMain1.Location = new System.Drawing.Point(0, 0);
            this.uctlTradeMain1.Name = "uctlTradeMain1";
            this.uctlTradeMain1.Size = new System.Drawing.Size(932, 356);
            this.uctlTradeMain1.TabIndex = 0;
            // 
            // frmTrades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 356);
            this.Controls.Add(this.uctlTradeMain1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTrades";
            this.Text = "Trades";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTrades_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private BOADMIN_NEW.Uctl.uctlTradeMain uctlTradeMain1;

    }
}