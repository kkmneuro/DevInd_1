namespace TWS.Frm
{
    partial class frmOrderEntry
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
            this.uctlOrderEntry1 = new CommonLibrary.UserControls.UctlOrderEntry();
            this.SuspendLayout();
            // 
            // uctlOrderEntry1
            // 
            this.uctlOrderEntry1.AccountNo = global::TWS.Properties.Settings.Default.DefaultTradingAccount;
            this.uctlOrderEntry1.AccountType = "---SELECT---";
            this.uctlOrderEntry1.AutoSize = true;
            this.uctlOrderEntry1.BuyBgColor = global::TWS.Properties.Settings.Default.BuyOrderColor;
            this.uctlOrderEntry1.Caption = "Sell";
            this.uctlOrderEntry1.ClientName = "";
            this.uctlOrderEntry1.ContractName = "";
            this.uctlOrderEntry1.DataBindings.Add(new System.Windows.Forms.Binding("AccountNo", global::TWS.Properties.Settings.Default, "DefaultTradingAccount", true, System.Windows.Forms.DataSourceUpdateMode.Never));
            this.uctlOrderEntry1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uctlOrderEntry1.DQuantity = true;
            this.uctlOrderEntry1.ExpiryDate = "---SELECT---";
            this.uctlOrderEntry1.FontSize = 0;
            this.uctlOrderEntry1.FontStyle = null;
            this.uctlOrderEntry1.GatewayName = null;
            this.uctlOrderEntry1.InstrumentName = "---SELECT---";
            this.uctlOrderEntry1.IsDefaultLayout = false;
            this.uctlOrderEntry1.IsLabelOn = false;
            this.uctlOrderEntry1.IsLastSavedLayout = false;
            this.uctlOrderEntry1.IsStatusBar = false;
            this.uctlOrderEntry1.IsTitleBar = false;
            this.uctlOrderEntry1.Key = "";
            this.uctlOrderEntry1.Location = new System.Drawing.Point(0, 0);
            this.uctlOrderEntry1.LTP = 0D;
            this.uctlOrderEntry1.Margin = new System.Windows.Forms.Padding(7);
            this.uctlOrderEntry1.Mode = CommonLibrary.Cls.ClsGlobal.OrderMode.NEW;
            this.uctlOrderEntry1.Name = "uctlOrderEntry1";
            this.uctlOrderEntry1.OrderQty = 0;
            this.uctlOrderEntry1.OrderType = "---SELECT---";
            this.uctlOrderEntry1.Padding = new System.Windows.Forms.Padding(2);
            this.uctlOrderEntry1.PartnerOminiId = "";
            this.uctlOrderEntry1.Price = "";
            this.uctlOrderEntry1.Quantity = 0;
            this.uctlOrderEntry1.SellBgColor = global::TWS.Properties.Settings.Default.SellOrderColor;
            this.uctlOrderEntry1.Size = new System.Drawing.Size(771, 107);
            this.uctlOrderEntry1.TabIndex = 0;
            this.uctlOrderEntry1.Title = "Order Entry";
            this.uctlOrderEntry1.TrigPrice = "";
            this.uctlOrderEntry1.Validity = "---SELECT---";
            this.uctlOrderEntry1.OnSymbolTextChanged += new System.Action<string>(this.uctlOrderEntry1_OnSymbolTextChanged);
            this.uctlOrderEntry1.OnBuySellColorChanged += new System.Action<System.Drawing.Color, System.Drawing.Color>(this.uctlOrderEntry1_OnBuySellColorChanged);
            this.uctlOrderEntry1.OnOrderTypeChanged += new System.Action<string>(this.uctlOrderEntry1_OnOrderTypeChanged);
            this.uctlOrderEntry1.OnAccountNoChanged += new System.Action<string>(this.uctlOrderEntry1_OnAccountNoChanged);
            this.uctlOrderEntry1.OnSubmitClick += new System.Action<CommonLibrary.UserControls.ClsOrderEntryInfo, CommonLibrary.Cls.ClsGlobal.OrderMode>(this.uctlOrderEntry1_OnSubmitClick);
            // 
            // frmOrderEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 107);
            this.Controls.Add(this.uctlOrderEntry1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(0, 375);
            this.Name = "frmOrderEntry";
            this.Text = "Order Entry";
            this.Title = "Order Entry";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmOrderEntry_FormClosed);
            this.Load += new System.EventHandler(this.frmSellOrderEntry_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public CommonLibrary.UserControls.UctlOrderEntry uctlOrderEntry1;

    }
}