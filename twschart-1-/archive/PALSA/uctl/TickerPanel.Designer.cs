namespace PALSA
{
    partial class TickerPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TickerPanel));
            //this.axStockTicker1 = new AxSTOCKTICKERLib.AxStockTicker();
            this.tickerTape1 = new PALSA.TickerTape();
            //((System.ComponentModel.ISupportInitialize)(this.axStockTicker1)).BeginInit();
            this.SuspendLayout();
            // 
            // axStockTicker1
            // 
            //this.axStockTicker1.Dock = System.Windows.Forms.DockStyle.Fill;
            //this.axStockTicker1.Enabled = true;
            //this.axStockTicker1.Location = new System.Drawing.Point(0, 0);
            //this.axStockTicker1.Name = "axStockTicker1";
            //this.axStockTicker1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axStockTicker1.OcxState")));
            //this.axStockTicker1.Size = new System.Drawing.Size(707, 40);
            //this.axStockTicker1.TabIndex = 9;
            // 
            // tickerTape1
            // 
            this.tickerTape1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tickerTape1.Location = new System.Drawing.Point(0, 0);
            this.tickerTape1.Name = "tickerTape1";
            this.tickerTape1.Size = new System.Drawing.Size(707, 20);
            this.tickerTape1.TabIndex = 10;
            // 
            // TickerPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tickerTape1);
            //this.Controls.Add(this.axStockTicker1);
            this.Name = "TickerPanel";
            this.Size = new System.Drawing.Size(707, 40);
            //((System.ComponentModel.ISupportInitialize)(this.axStockTicker1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        //public AxSTOCKTICKERLib.AxStockTicker axStockTicker1;
        public TickerTape tickerTape1;
    }
}
