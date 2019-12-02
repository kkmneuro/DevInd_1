namespace TWS.Frm
{
    partial class frmSnapQuote
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
            this.ui_uctlSnapQuote = new CommonLibrary.UserControls.UctlSnapQuote();
            this.SuspendLayout();
            // 
            // ui_uctlSnapQuote
            // 
            this.ui_uctlSnapQuote.BuyOrderQuantity = "Buy Quantity";
            this.ui_uctlSnapQuote.BuyPrice = "Buy Price";
            this.ui_uctlSnapQuote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_uctlSnapQuote.LastTradedPrice = "Last Traded Price";
            this.ui_uctlSnapQuote.Location = new System.Drawing.Point(0, 0);
            this.ui_uctlSnapQuote.Name = "ui_uctlSnapQuote";
            this.ui_uctlSnapQuote.SellPrice = "Sell Price";
            this.ui_uctlSnapQuote.SellQuantity = "Sell Quantity";
            this.ui_uctlSnapQuote.Size = new System.Drawing.Size(711, 36);
            this.ui_uctlSnapQuote.TabIndex = 0;
            this.ui_uctlSnapQuote.Title = " ";
            this.ui_uctlSnapQuote.OnProductTypeSelected += new System.Action<string>(this.ui_uctlSnapQuote_OnProductTypeSelected);
            this.ui_uctlSnapQuote.OnProductSelected += new System.Action<string, string>(this.ui_uctlSnapQuote_OnProductSelected);
            this.ui_uctlSnapQuote.OnContractSelected += new System.Action<string, string, string>(this.ui_uctlSnapQuote_OnContractSelected);
            // 
            // frmSnapQuote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 36);
            this.Controls.Add(this.ui_uctlSnapQuote);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmSnapQuote";
            this.Text = "Snap Quote";
            this.Title = "Snap Quote";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSnapQuote_FormClosed);
            this.Load += new System.EventHandler(this.frmSnapQuote_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CommonLibrary.UserControls.UctlSnapQuote ui_uctlSnapQuote;
    }
}