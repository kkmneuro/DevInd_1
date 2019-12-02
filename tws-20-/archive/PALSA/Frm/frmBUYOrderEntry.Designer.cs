namespace PALSA.Frm
{
    partial class frmBuyOrderEntry
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
            this.ui_uctlOrderEntry = new CommonLibrary.UserControls.uctlOrderEntry();
            this.SuspendLayout();
            // 
            // ui_uctlOrderEntry
            // 
            this.ui_uctlOrderEntry.AutoSize = true;
            this.ui_uctlOrderEntry.BuyBgColor = null;
            this.ui_uctlOrderEntry.Caption = "BUY";
            this.ui_uctlOrderEntry.Client = "";
            this.ui_uctlOrderEntry.ClientName = "";
            this.ui_uctlOrderEntry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_uctlOrderEntry.DQuantity = "";
            this.ui_uctlOrderEntry.FontSize = 0;
            this.ui_uctlOrderEntry.FontStyle = null;
            this.ui_uctlOrderEntry.IsDefaultLayout = false;
            this.ui_uctlOrderEntry.IsLabelOn = false;
            this.ui_uctlOrderEntry.IsLastSavedLayout = false;
            this.ui_uctlOrderEntry.IsStatusBar = false;
            this.ui_uctlOrderEntry.IsTitleBar = false;
            this.ui_uctlOrderEntry.Location = new System.Drawing.Point(0, 0);
            this.ui_uctlOrderEntry.Name = "ui_uctlOrderEntry";
            this.ui_uctlOrderEntry.Price = "";
            this.ui_uctlOrderEntry.Quantity = "";
            this.ui_uctlOrderEntry.SellBgColor = null;
            this.ui_uctlOrderEntry.Size = new System.Drawing.Size(818, 96);
            this.ui_uctlOrderEntry.Symbol = "";
            this.ui_uctlOrderEntry.TabIndex = 0;
            this.ui_uctlOrderEntry.Title = "BUY Order Entry";
            this.ui_uctlOrderEntry.TrigPrice = "";
            this.ui_uctlOrderEntry.UserRemark = "";
            this.ui_uctlOrderEntry.Load += new System.EventHandler(this.ui_uctlOrderEntry_Load);
            // 
            // frmBuyOrderEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 96);
            this.Controls.Add(this.ui_uctlOrderEntry);
            this.MaximizeBox = false;
            this.Name = "frmBuyOrderEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmBuyOrderEntry";
            this.Title = "frmBuyOrderEntry";
            this.Load += new System.EventHandler(this.frmOrderEntry_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public CommonLibrary.UserControls.uctlOrderEntry ui_uctlOrderEntry;
    }
}