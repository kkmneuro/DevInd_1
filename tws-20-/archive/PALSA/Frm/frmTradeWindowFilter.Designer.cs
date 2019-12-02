namespace TWS.Frm
{
    partial class frmTradeWindowFilter
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
            this.uctlTradeWindow1 = new CommonLibrary.UserControls.uctlTradeWindowWithFilter();
            this.SuspendLayout();
            // 
            // uctlTradeWindow1
            // 
            this.uctlTradeWindow1.AccountNo = 0;
            this.uctlTradeWindow1.AutoSize = true;
            this.uctlTradeWindow1.BS = "All";
            this.uctlTradeWindow1.BuyAtp = "";
            this.uctlTradeWindow1.BuyQty = "";
            this.uctlTradeWindow1.BuyVal = "";
            this.uctlTradeWindow1.Contract = "All";
            this.uctlTradeWindow1.CurrentProfileName = null;
            this.uctlTradeWindow1.DataRowStyle = System.Drawing.Color.Empty;
            this.uctlTradeWindow1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uctlTradeWindow1.Location = new System.Drawing.Point(0, 0);
            this.uctlTradeWindow1.Name = "uctlTradeWindow1";
            this.uctlTradeWindow1.NoOfTotalOrder = "";
            this.uctlTradeWindow1.OrderFilter = null;
            this.uctlTradeWindow1.OrderStatus = "All";
            this.uctlTradeWindow1.OrderType = "All";
            this.uctlTradeWindow1.ProductType = "All";
            this.uctlTradeWindow1.Profile = null;
            this.uctlTradeWindow1.SellAtp = "";
            this.uctlTradeWindow1.SellQty = "";
            this.uctlTradeWindow1.SellVal = "";
            this.uctlTradeWindow1.ShortcutKeyFilter = System.Windows.Forms.Keys.None;
            this.uctlTradeWindow1.Size = new System.Drawing.Size(1235, 311);
            this.uctlTradeWindow1.TabIndex = 0;
            this.uctlTradeWindow1.Title = " History ";
            this.uctlTradeWindow1.OnProfileSaveClick += new System.Action<object, string>(this.uctlTradeWindow1_OnProfileSaveClick);
            this.uctlTradeWindow1.OnProfileRemoveClick += new System.Action<object, string>(this.uctlTradeWindow1_OnProfileRemoveClick);
            this.uctlTradeWindow1.OnSetDefaultProfileClick += new System.Action<object, string>(this.uctlTradeWindow1_OnSetDefaultProfileClick);
            this.uctlTradeWindow1.OnGridMouseDown += new System.Action<object, System.Windows.Forms.MouseEventArgs>(this.uctlTradeWindow1_OnGridMouseDown);
            // 
            // frmTradeWindowFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1235, 311);
            this.Controls.Add(this.uctlTradeWindow1);
            this.MaximumSize = new System.Drawing.Size(1300, 600);
            this.MinimumSize = new System.Drawing.Size(600, 150);
            this.Name = "frmTradeWindowFilter";
            this.Text = "Trade History Window";
            this.Title = "Trade History Window";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTradeWindowFilter_FormClosing);
            this.Load += new System.EventHandler(this.frmTradeWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public CommonLibrary.UserControls.uctlTradeWindowWithFilter uctlTradeWindow1;

    }
}