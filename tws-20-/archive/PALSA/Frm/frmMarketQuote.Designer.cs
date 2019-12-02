namespace TWS.Frm
{
    partial class frmMarketQuote
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
            this.uctlForex1 = new CommonLibrary.UserControls.UctlForex();
            this.SuspendLayout();
            // 
            // uctlForex1
            // 
            this.uctlForex1.AutoScroll = true;
            this.uctlForex1.BackColor = System.Drawing.Color.Transparent;
            this.uctlForex1.CurrentPortfolioName = "";
            this.uctlForex1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uctlForex1.isAmountinLot = false;
            this.uctlForex1.isAskInLeftSide = false;
            this.uctlForex1.isBuyOnSingleClick = false;
            this.uctlForex1.isLoadDefaultColor = true;
            this.uctlForex1.isSellOnSingleClick = false;
            this.uctlForex1.Location = new System.Drawing.Point(0, 0);
            this.uctlForex1.Name = "uctlForex1";
            this.uctlForex1.Portfolios = null;
            this.uctlForex1.Size = new System.Drawing.Size(673, 302);
            this.uctlForex1.TabIndex = 0;
            this.uctlForex1.Title = null;
            this.uctlForex1.OnScriptPortfolioApplyClick += new System.Action<string>(this.ui_uctlForex_OnScriptPortfolioApplyClick);
            this.uctlForex1.OnScriptPortfolioModifyClick += new System.Action<string>(this.ui_uctlForex_OnScriptPortfolioModifyClick);
            this.uctlForex1.OnScriptPortfolioRemoveClick += new System.Action<string>(this.ui_uctlForex_OnScriptPortfolioRemoveClick);
            this.uctlForex1.OnOrderEntryDialog += new System.Action<string, double, double>(this.uctlForex1_OnOrderEntryDialog);
            this.uctlForex1.OnOrderSend += new System.Action<string, double, int>(this.uctlForex1_OnOrderSend);
            // 
            // frmMarketQuote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(673, 302);
            this.Controls.Add(this.uctlForex1);
            this.MaximumSize = new System.Drawing.Size(1200, 600);
            this.MinimumSize = new System.Drawing.Size(350, 175);
            this.Name = "frmMarketQuote";
            this.Text = "Market Quote";
            this.Title = "Market Quote";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMarketQuote_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMarketQuote_FormClosed);
            this.Load += new System.EventHandler(this.ui_uctlForex_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private CommonLibrary.UserControls.UctlForex uctlForex1;
    }
}