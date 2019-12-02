
namespace PALSA.uctl
{
    partial class ctlMarketQuote
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
            //this.uctlForex1 = new CommonLibrary.UserControls.UctlForex();
            this.uctlForex1 = new CommonLibrary.UserControls.uctlQuickOrderContainer();
            this.SuspendLayout();
            // 
            // uctlForex1
            // 
            this.uctlForex1.Account ="";
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
            this.uctlForex1.Size = new System.Drawing.Size(360, 244);
            this.uctlForex1.TabIndex = 0;
            this.uctlForex1.Title = null;
            this.uctlForex1.OnSellMarketClick += new System.Action<string, string, double, double>(this.uctlForex1_OnSellMarketClick);
            this.uctlForex1.OnSellClick += new System.Action<string, string, double, double>(this.uctlForex1_OnSellClick);
            this.uctlForex1.OnCloseClick += new System.Action(this.uctlForex1_OnCloseClick);
            this.uctlForex1.OnBuyMarketClick += new System.Action<string, string, double, double>(this.uctlForex1_OnBuyMarketClick);
            this.uctlForex1.OnBuyClick += new System.Action<string, string, double, double>(this.uctlForex1_OnBuyClick);
            this.uctlForex1.OnScriptPortfolioApplyClick += new System.Action<string>(this.uctlForex1_OnScriptPortfolioApplyClick);
            this.uctlForex1.Load += new System.EventHandler(this.uctlForex1_Load);
            // 
            // ctlMarketQuote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uctlForex1);
            this.Name = "ctlMarketQuote";
            this.Size = new System.Drawing.Size(360, 244);
            this.ResumeLayout(false);

        }

       

        #endregion

        //public CommonLibrary.UserControls.UctlForex uctlForex1;
        public CommonLibrary.UserControls.uctlQuickOrderContainer uctlForex1;

    }
}
