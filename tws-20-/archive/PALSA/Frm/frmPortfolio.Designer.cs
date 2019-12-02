namespace TWS.Frm
{
    partial class frmPortfolio
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
            this.ui_uctlPortfolio = new CommonLibrary.UserControls.UctlPortfolio();
            this.SuspendLayout();
            // 
            // ui_uctlPortfolio
            // 
            this.ui_uctlPortfolio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_uctlPortfolio.Location = new System.Drawing.Point(0, 0);
            this.ui_uctlPortfolio.Name = "ui_uctlPortfolio";
            this.ui_uctlPortfolio.SearchedProducts = null;
            this.ui_uctlPortfolio.Size = new System.Drawing.Size(737, 488);
            this.ui_uctlPortfolio.Symbol = "";
            this.ui_uctlPortfolio.TabIndex = 0;
            this.ui_uctlPortfolio.Title = "Portfolio";
            this.ui_uctlPortfolio.OnSearchClick += new System.Action<object, System.EventArgs>(this.ui_uctlPortfolio_OnSearchClick);
            this.ui_uctlPortfolio.OnRemovePortfolioClick += new System.Action<object>(this.ui_uctlPortfolio_OnRemovePortfolioClick);
            this.ui_uctlPortfolio.OnSelectedProductTypeChanged += new System.Action<object, System.EventArgs>(this.ui_uctlPortfolio_OnSelectedProductTypeChanged);
            this.ui_uctlPortfolio.OnSelectedProductChanged += new System.Action<object, System.EventArgs>(this.ui_uctlPortfolio_OnSelectedProductChanged);
            this.ui_uctlPortfolio.OnExpiryDateSelected += new System.Action<object, System.EventArgs>(this.ui_uctlPortfolio_OnExpiryDateSelected);
            this.ui_uctlPortfolio.OnSymbolTextChanged += new System.Action<object, System.EventArgs>(this.ui_uctlPortfolio_OnSymbolTextChanged);
            this.ui_uctlPortfolio.OnSelectedOptTypesChanged += new System.Action<object, System.EventArgs>(this.ui_uctlPortfolio_OnSelectedOptTypesChanged);
            this.ui_uctlPortfolio.OnSelectedProviderChanged += new System.Action<object, System.EventArgs>(this.ui_uctlPortfolio_OnSelectedProviderChanged);
            this.ui_uctlPortfolio.OnSelectedExchangeChanged += new System.Action<object, System.EventArgs>(this.ui_uctlPortfolio_OnSelectedExchangeChanged);
            this.ui_uctlPortfolio.Load += new System.EventHandler(this.ui_uctlPortfolio_Load);
            // 
            // frmPortfolio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 488);
            this.Controls.Add(this.ui_uctlPortfolio);
            this.KeyPreview = true;
            this.Name = "frmPortfolio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPortfolio";
            this.Title = "frmPortfolio";
            this.Load += new System.EventHandler(this.frmPortfolio_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPortfolio_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private CommonLibrary.UserControls.UctlPortfolio ui_uctlPortfolio;

    }
}