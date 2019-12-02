namespace TWS.Frm
{
    partial class AlertTestForm
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
            this.ui_nbtnFreshOrder = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nbtnOrderModification = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nbtnMarketOrder = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nbtnOrderCancellation = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nbtnTradeModification = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nbtnDiffProductOrder = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nbtnOutsideDPROrder = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nbtnQtyAlerts = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nbtnPriceAlerts = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nbtnV = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nbtnSpreadAlerts = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nbtnOpenPostionAlerts = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nbtnPendingOrderAlerts = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nbtnTradingCurrencyAlerts = new Nevron.UI.WinForm.Controls.NButton();
            this.SuspendLayout();
            // 
            // ui_nbtnFreshOrder
            // 
            this.ui_nbtnFreshOrder.Location = new System.Drawing.Point(23, 12);
            this.ui_nbtnFreshOrder.Name = "ui_nbtnFreshOrder";
            this.ui_nbtnFreshOrder.Size = new System.Drawing.Size(161, 23);
            this.ui_nbtnFreshOrder.TabIndex = 0;
            this.ui_nbtnFreshOrder.Text = "Fresh Order";
            this.ui_nbtnFreshOrder.UseVisualStyleBackColor = false;
            this.ui_nbtnFreshOrder.Click += new System.EventHandler(this.ui_nbtnFreshOrder_Click);
            // 
            // ui_nbtnOrderModification
            // 
            this.ui_nbtnOrderModification.Location = new System.Drawing.Point(192, 12);
            this.ui_nbtnOrderModification.Name = "ui_nbtnOrderModification";
            this.ui_nbtnOrderModification.Size = new System.Drawing.Size(161, 23);
            this.ui_nbtnOrderModification.TabIndex = 1;
            this.ui_nbtnOrderModification.Text = "Order Modification";
            this.ui_nbtnOrderModification.UseVisualStyleBackColor = false;
            this.ui_nbtnOrderModification.Click += new System.EventHandler(this.ui_nbtnOrderModification_Click);
            // 
            // ui_nbtnMarketOrder
            // 
            this.ui_nbtnMarketOrder.Location = new System.Drawing.Point(361, 12);
            this.ui_nbtnMarketOrder.Name = "ui_nbtnMarketOrder";
            this.ui_nbtnMarketOrder.Size = new System.Drawing.Size(161, 23);
            this.ui_nbtnMarketOrder.TabIndex = 2;
            this.ui_nbtnMarketOrder.Text = "Market Order";
            this.ui_nbtnMarketOrder.UseVisualStyleBackColor = false;
            this.ui_nbtnMarketOrder.Click += new System.EventHandler(this.ui_nbtnMarketOrder_Click);
            // 
            // ui_nbtnOrderCancellation
            // 
            this.ui_nbtnOrderCancellation.Location = new System.Drawing.Point(23, 51);
            this.ui_nbtnOrderCancellation.Name = "ui_nbtnOrderCancellation";
            this.ui_nbtnOrderCancellation.Size = new System.Drawing.Size(161, 23);
            this.ui_nbtnOrderCancellation.TabIndex = 3;
            this.ui_nbtnOrderCancellation.Text = "Order Cancellation";
            this.ui_nbtnOrderCancellation.UseVisualStyleBackColor = false;
            this.ui_nbtnOrderCancellation.ClientSizeChanged += new System.EventHandler(this.ui_nbtnOrderCancellation_Click);
            // 
            // ui_nbtnTradeModification
            // 
            this.ui_nbtnTradeModification.Location = new System.Drawing.Point(192, 51);
            this.ui_nbtnTradeModification.Name = "ui_nbtnTradeModification";
            this.ui_nbtnTradeModification.Size = new System.Drawing.Size(161, 23);
            this.ui_nbtnTradeModification.TabIndex = 4;
            this.ui_nbtnTradeModification.Text = "Trade Modification";
            this.ui_nbtnTradeModification.UseVisualStyleBackColor = false;
            this.ui_nbtnTradeModification.ClientSizeChanged += new System.EventHandler(this.ui_nbtnTradeModification_Click);
            // 
            // ui_nbtnDiffProductOrder
            // 
            this.ui_nbtnDiffProductOrder.Location = new System.Drawing.Point(361, 51);
            this.ui_nbtnDiffProductOrder.Name = "ui_nbtnDiffProductOrder";
            this.ui_nbtnDiffProductOrder.Size = new System.Drawing.Size(161, 23);
            this.ui_nbtnDiffProductOrder.TabIndex = 5;
            this.ui_nbtnDiffProductOrder.Text = "Different Product Order";
            this.ui_nbtnDiffProductOrder.UseVisualStyleBackColor = false;
            this.ui_nbtnDiffProductOrder.ClientSizeChanged += new System.EventHandler(this.ui_nbtnDiffProductOrder_Click);
            this.ui_nbtnDiffProductOrder.Click += new System.EventHandler(this.ui_nbtnDiffProductOrder_Click);
            // 
            // ui_nbtnOutsideDPROrder
            // 
            this.ui_nbtnOutsideDPROrder.Location = new System.Drawing.Point(23, 90);
            this.ui_nbtnOutsideDPROrder.Name = "ui_nbtnOutsideDPROrder";
            this.ui_nbtnOutsideDPROrder.Size = new System.Drawing.Size(161, 23);
            this.ui_nbtnOutsideDPROrder.TabIndex = 6;
            this.ui_nbtnOutsideDPROrder.Text = "Outside DPR Order";
            this.ui_nbtnOutsideDPROrder.UseVisualStyleBackColor = false;
            this.ui_nbtnOutsideDPROrder.ClientSizeChanged += new System.EventHandler(this.ui_nbtnOutsideDPROrder_Click);
            // 
            // ui_nbtnQtyAlerts
            // 
            this.ui_nbtnQtyAlerts.Location = new System.Drawing.Point(192, 90);
            this.ui_nbtnQtyAlerts.Name = "ui_nbtnQtyAlerts";
            this.ui_nbtnQtyAlerts.Size = new System.Drawing.Size(161, 23);
            this.ui_nbtnQtyAlerts.TabIndex = 7;
            this.ui_nbtnQtyAlerts.Text = "Qty Alerts";
            this.ui_nbtnQtyAlerts.UseVisualStyleBackColor = false;
            this.ui_nbtnQtyAlerts.ClientSizeChanged += new System.EventHandler(this.ui_nbtnQtyAlerts_Click);
            // 
            // ui_nbtnPriceAlerts
            // 
            this.ui_nbtnPriceAlerts.Location = new System.Drawing.Point(361, 90);
            this.ui_nbtnPriceAlerts.Name = "ui_nbtnPriceAlerts";
            this.ui_nbtnPriceAlerts.Size = new System.Drawing.Size(161, 23);
            this.ui_nbtnPriceAlerts.TabIndex = 8;
            this.ui_nbtnPriceAlerts.Text = "Price Alerts";
            this.ui_nbtnPriceAlerts.UseVisualStyleBackColor = false;
            this.ui_nbtnPriceAlerts.ClientSizeChanged += new System.EventHandler(this.ui_nbtnPriceAlerts_Click);
            // 
            // ui_nbtnV
            // 
            this.ui_nbtnV.Location = new System.Drawing.Point(23, 129);
            this.ui_nbtnV.Name = "ui_nbtnV";
            this.ui_nbtnV.Size = new System.Drawing.Size(161, 23);
            this.ui_nbtnV.TabIndex = 9;
            this.ui_nbtnV.Text = "Value Alerts";
            this.ui_nbtnV.UseVisualStyleBackColor = false;
            this.ui_nbtnV.ClientSizeChanged += new System.EventHandler(this.ui_nbtnV_Click);
            // 
            // ui_nbtnSpreadAlerts
            // 
            this.ui_nbtnSpreadAlerts.Location = new System.Drawing.Point(192, 129);
            this.ui_nbtnSpreadAlerts.Name = "ui_nbtnSpreadAlerts";
            this.ui_nbtnSpreadAlerts.Size = new System.Drawing.Size(161, 23);
            this.ui_nbtnSpreadAlerts.TabIndex = 10;
            this.ui_nbtnSpreadAlerts.Text = "Spread IOC Price Alerts";
            this.ui_nbtnSpreadAlerts.UseVisualStyleBackColor = false;
            this.ui_nbtnSpreadAlerts.Click += new System.EventHandler(this.ui_nbtnSpreadAlerts_Click);
            // 
            // ui_nbtnOpenPostionAlerts
            // 
            this.ui_nbtnOpenPostionAlerts.Location = new System.Drawing.Point(361, 129);
            this.ui_nbtnOpenPostionAlerts.Name = "ui_nbtnOpenPostionAlerts";
            this.ui_nbtnOpenPostionAlerts.Size = new System.Drawing.Size(161, 23);
            this.ui_nbtnOpenPostionAlerts.TabIndex = 11;
            this.ui_nbtnOpenPostionAlerts.Text = "Open Position Alert on logoff";
            this.ui_nbtnOpenPostionAlerts.UseVisualStyleBackColor = false;
            this.ui_nbtnOpenPostionAlerts.Click += new System.EventHandler(this.ui_nbtnOpenPostionAlerts_Click);
            // 
            // ui_nbtnPendingOrderAlerts
            // 
            this.ui_nbtnPendingOrderAlerts.Location = new System.Drawing.Point(23, 168);
            this.ui_nbtnPendingOrderAlerts.Name = "ui_nbtnPendingOrderAlerts";
            this.ui_nbtnPendingOrderAlerts.Size = new System.Drawing.Size(161, 23);
            this.ui_nbtnPendingOrderAlerts.TabIndex = 12;
            this.ui_nbtnPendingOrderAlerts.Text = "Pending Order Alerts on logoff";
            this.ui_nbtnPendingOrderAlerts.UseVisualStyleBackColor = false;
            this.ui_nbtnPendingOrderAlerts.Click += new System.EventHandler(this.ui_nbtnPendingOrderAlerts_Click);
            // 
            // ui_nbtnTradingCurrencyAlerts
            // 
            this.ui_nbtnTradingCurrencyAlerts.Location = new System.Drawing.Point(192, 168);
            this.ui_nbtnTradingCurrencyAlerts.Name = "ui_nbtnTradingCurrencyAlerts";
            this.ui_nbtnTradingCurrencyAlerts.Size = new System.Drawing.Size(161, 23);
            this.ui_nbtnTradingCurrencyAlerts.TabIndex = 13;
            this.ui_nbtnTradingCurrencyAlerts.Text = "Trading Currency Alerts";
            this.ui_nbtnTradingCurrencyAlerts.UseVisualStyleBackColor = false;
            this.ui_nbtnTradingCurrencyAlerts.Click += new System.EventHandler(this.ui_nbtnTradingCurrencyAlerts_Click);
            // 
            // AlertTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 328);
            this.Controls.Add(this.ui_nbtnTradingCurrencyAlerts);
            this.Controls.Add(this.ui_nbtnPendingOrderAlerts);
            this.Controls.Add(this.ui_nbtnOpenPostionAlerts);
            this.Controls.Add(this.ui_nbtnSpreadAlerts);
            this.Controls.Add(this.ui_nbtnV);
            this.Controls.Add(this.ui_nbtnPriceAlerts);
            this.Controls.Add(this.ui_nbtnQtyAlerts);
            this.Controls.Add(this.ui_nbtnOutsideDPROrder);
            this.Controls.Add(this.ui_nbtnDiffProductOrder);
            this.Controls.Add(this.ui_nbtnTradeModification);
            this.Controls.Add(this.ui_nbtnOrderCancellation);
            this.Controls.Add(this.ui_nbtnMarketOrder);
            this.Controls.Add(this.ui_nbtnOrderModification);
            this.Controls.Add(this.ui_nbtnFreshOrder);
            this.Name = "AlertTestForm";
            this.Text = "AlertTestForm";
            this.Title = "AlertTestForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NButton ui_nbtnFreshOrder;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnOrderModification;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnMarketOrder;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnOrderCancellation;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnTradeModification;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnDiffProductOrder;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnOutsideDPROrder;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnQtyAlerts;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnPriceAlerts;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnV;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnSpreadAlerts;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnOpenPostionAlerts;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnPendingOrderAlerts;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnTradingCurrencyAlerts;
    }
}