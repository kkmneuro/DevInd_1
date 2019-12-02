namespace CommonLibrary.UserControls
{
    partial class UctlPreferencesAlerts
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
            this.ui_npnlPreferencesAlerts = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.ui_nlstTradingCurrencyAlert = new Nevron.UI.WinForm.Controls.NListBox();
            this.ui_nchkPendingOrdersAlert = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.ui_nchkOpenPositionAlert = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.ui_ntxtIOCPriceAlert = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_ntxtPriceAlert = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_ntxtValueAlert = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_ntxtQuntityAlert = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_lblTradingCurrencyAlert = new System.Windows.Forms.Label();
            this.ui_lblIOCPriceAlert = new System.Windows.Forms.Label();
            this.ui_lblPriceAlert = new System.Windows.Forms.Label();
            this.ui_lblValueAlert = new System.Windows.Forms.Label();
            this.ui_lblQuantityAlert = new System.Windows.Forms.Label();
            this.ui_lblMessageOptions = new System.Windows.Forms.Label();
            this.ui_nchkOutsideDPROrder = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.ui_nchkDifferentProductOrder = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.ui_nchkTradeModification = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.ui_nchkOrderCancellation = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.ui_nchkMarketOrder = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.ui_nchkOrderModification = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.ui_nbtnRestoreDefault = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nchkFreshOrder = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.ui_nlcPreferencesAlert4 = new Nevron.UI.WinForm.Controls.NLineControl();
            this.ui_nlcPreferencesAlert3 = new Nevron.UI.WinForm.Controls.NLineControl();
            this.ui_nlcPreferencesAlert2 = new Nevron.UI.WinForm.Controls.NLineControl();
            this.ui_nlcPreferencesAlert1 = new Nevron.UI.WinForm.Controls.NLineControl();
            this.ui_npnlPreferencesAlerts.SuspendLayout();
            this.SuspendLayout();
            // 
            // ui_npnlPreferencesAlerts
            // 
            this.ui_npnlPreferencesAlerts.BackColor = System.Drawing.SystemColors.Control;
            this.ui_npnlPreferencesAlerts.Controls.Add(this.ui_nlstTradingCurrencyAlert);
            this.ui_npnlPreferencesAlerts.Controls.Add(this.ui_nchkPendingOrdersAlert);
            this.ui_npnlPreferencesAlerts.Controls.Add(this.ui_nchkOpenPositionAlert);
            this.ui_npnlPreferencesAlerts.Controls.Add(this.ui_ntxtIOCPriceAlert);
            this.ui_npnlPreferencesAlerts.Controls.Add(this.ui_ntxtPriceAlert);
            this.ui_npnlPreferencesAlerts.Controls.Add(this.ui_ntxtValueAlert);
            this.ui_npnlPreferencesAlerts.Controls.Add(this.ui_ntxtQuntityAlert);
            this.ui_npnlPreferencesAlerts.Controls.Add(this.ui_lblTradingCurrencyAlert);
            this.ui_npnlPreferencesAlerts.Controls.Add(this.ui_lblIOCPriceAlert);
            this.ui_npnlPreferencesAlerts.Controls.Add(this.ui_lblPriceAlert);
            this.ui_npnlPreferencesAlerts.Controls.Add(this.ui_lblValueAlert);
            this.ui_npnlPreferencesAlerts.Controls.Add(this.ui_lblQuantityAlert);
            this.ui_npnlPreferencesAlerts.Controls.Add(this.ui_lblMessageOptions);
            this.ui_npnlPreferencesAlerts.Controls.Add(this.ui_nchkOutsideDPROrder);
            this.ui_npnlPreferencesAlerts.Controls.Add(this.ui_nchkDifferentProductOrder);
            this.ui_npnlPreferencesAlerts.Controls.Add(this.ui_nchkTradeModification);
            this.ui_npnlPreferencesAlerts.Controls.Add(this.ui_nchkOrderCancellation);
            this.ui_npnlPreferencesAlerts.Controls.Add(this.ui_nchkMarketOrder);
            this.ui_npnlPreferencesAlerts.Controls.Add(this.ui_nchkOrderModification);
            this.ui_npnlPreferencesAlerts.Controls.Add(this.ui_nbtnRestoreDefault);
            this.ui_npnlPreferencesAlerts.Controls.Add(this.ui_nchkFreshOrder);
            this.ui_npnlPreferencesAlerts.Controls.Add(this.ui_nlcPreferencesAlert4);
            this.ui_npnlPreferencesAlerts.Controls.Add(this.ui_nlcPreferencesAlert3);
            this.ui_npnlPreferencesAlerts.Controls.Add(this.ui_nlcPreferencesAlert2);
            this.ui_npnlPreferencesAlerts.Controls.Add(this.ui_nlcPreferencesAlert1);
            this.ui_npnlPreferencesAlerts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_npnlPreferencesAlerts.Location = new System.Drawing.Point(0, 0);
            this.ui_npnlPreferencesAlerts.Name = "ui_npnlPreferencesAlerts";
            this.ui_npnlPreferencesAlerts.Size = new System.Drawing.Size(500, 334);
            this.ui_npnlPreferencesAlerts.TabIndex = 1;
            this.ui_npnlPreferencesAlerts.Text = "nuiPanel1";
            this.ui_npnlPreferencesAlerts.Click += new System.EventHandler(this.ui_npnlPreferencesAlerts_Click);
            // 
            // ui_nlstTradingCurrencyAlert
            // 
            this.ui_nlstTradingCurrencyAlert.CheckBoxes = true;
            this.ui_nlstTradingCurrencyAlert.ColumnOnLeft = false;
            this.ui_nlstTradingCurrencyAlert.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("NPR", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("INR", -1, false, 0, new System.Drawing.Size(0, 0))});
            this.ui_nlstTradingCurrencyAlert.Location = new System.Drawing.Point(125, 229);
            this.ui_nlstTradingCurrencyAlert.Name = "ui_nlstTradingCurrencyAlert";
            this.ui_nlstTradingCurrencyAlert.Size = new System.Drawing.Size(179, 44);
            this.ui_nlstTradingCurrencyAlert.TabIndex = 4;
            // 
            // ui_nchkPendingOrdersAlert
            // 
            this.ui_nchkPendingOrdersAlert.AutoSize = true;
            this.ui_nchkPendingOrdersAlert.ButtonProperties.BorderOffset = 2;
            this.ui_nchkPendingOrdersAlert.Location = new System.Drawing.Point(271, 177);
            this.ui_nchkPendingOrdersAlert.Name = "ui_nchkPendingOrdersAlert";
            this.ui_nchkPendingOrdersAlert.Size = new System.Drawing.Size(171, 17);
            this.ui_nchkPendingOrdersAlert.TabIndex = 13;
            this.ui_nchkPendingOrdersAlert.TabStop = false;
            this.ui_nchkPendingOrdersAlert.Text = "Pending Orders Alert on Logoff";
            this.ui_nchkPendingOrdersAlert.TransparentBackground = true;
            this.ui_nchkPendingOrdersAlert.UseVisualStyleBackColor = false;
            // 
            // ui_nchkOpenPositionAlert
            // 
            this.ui_nchkOpenPositionAlert.AutoSize = true;
            this.ui_nchkOpenPositionAlert.ButtonProperties.BorderOffset = 2;
            this.ui_nchkOpenPositionAlert.Location = new System.Drawing.Point(10, 177);
            this.ui_nchkOpenPositionAlert.Name = "ui_nchkOpenPositionAlert";
            this.ui_nchkOpenPositionAlert.Size = new System.Drawing.Size(164, 17);
            this.ui_nchkOpenPositionAlert.TabIndex = 12;
            this.ui_nchkOpenPositionAlert.TabStop = false;
            this.ui_nchkOpenPositionAlert.Text = "Open Position Alert on Logoff";
            this.ui_nchkOpenPositionAlert.TransparentBackground = true;
            this.ui_nchkOpenPositionAlert.UseVisualStyleBackColor = false;
            // 
            // ui_ntxtIOCPriceAlert
            // 
            this.ui_ntxtIOCPriceAlert.Location = new System.Drawing.Point(446, 133);
            this.ui_ntxtIOCPriceAlert.Name = "ui_ntxtIOCPriceAlert";
            this.ui_ntxtIOCPriceAlert.Size = new System.Drawing.Size(42, 18);
            this.ui_ntxtIOCPriceAlert.TabIndex = 3;
            // 
            // ui_ntxtPriceAlert
            // 
            this.ui_ntxtPriceAlert.Location = new System.Drawing.Point(375, 102);
            this.ui_ntxtPriceAlert.Name = "ui_ntxtPriceAlert";
            this.ui_ntxtPriceAlert.Size = new System.Drawing.Size(113, 18);
            this.ui_ntxtPriceAlert.TabIndex = 1;
            // 
            // ui_ntxtValueAlert
            // 
            this.ui_ntxtValueAlert.Location = new System.Drawing.Point(125, 133);
            this.ui_ntxtValueAlert.Name = "ui_ntxtValueAlert";
            this.ui_ntxtValueAlert.Size = new System.Drawing.Size(84, 18);
            this.ui_ntxtValueAlert.TabIndex = 2;
            // 
            // ui_ntxtQuntityAlert
            // 
            this.ui_ntxtQuntityAlert.Location = new System.Drawing.Point(125, 102);
            this.ui_ntxtQuntityAlert.Name = "ui_ntxtQuntityAlert";
            this.ui_ntxtQuntityAlert.Size = new System.Drawing.Size(84, 18);
            this.ui_ntxtQuntityAlert.TabIndex = 0;
            // 
            // ui_lblTradingCurrencyAlert
            // 
            this.ui_lblTradingCurrencyAlert.AutoSize = true;
            this.ui_lblTradingCurrencyAlert.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblTradingCurrencyAlert.Location = new System.Drawing.Point(7, 245);
            this.ui_lblTradingCurrencyAlert.Name = "ui_lblTradingCurrencyAlert";
            this.ui_lblTradingCurrencyAlert.Size = new System.Drawing.Size(118, 13);
            this.ui_lblTradingCurrencyAlert.TabIndex = 51;
            this.ui_lblTradingCurrencyAlert.Text = "Trading Currency Alert :";
            // 
            // ui_lblIOCPriceAlert
            // 
            this.ui_lblIOCPriceAlert.AutoSize = true;
            this.ui_lblIOCPriceAlert.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblIOCPriceAlert.Location = new System.Drawing.Point(213, 136);
            this.ui_lblIOCPriceAlert.Name = "ui_lblIOCPriceAlert";
            this.ui_lblIOCPriceAlert.Size = new System.Drawing.Size(235, 13);
            this.ui_lblIOCPriceAlert.TabIndex = 50;
            this.ui_lblIOCPriceAlert.Text = "Spread IOC Price Alert (% of NM LTP/CLP/BP) :";
            // 
            // ui_lblPriceAlert
            // 
            this.ui_lblPriceAlert.AutoSize = true;
            this.ui_lblPriceAlert.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblPriceAlert.Location = new System.Drawing.Point(213, 105);
            this.ui_lblPriceAlert.Name = "ui_lblPriceAlert";
            this.ui_lblPriceAlert.Size = new System.Drawing.Size(157, 13);
            this.ui_lblPriceAlert.TabIndex = 49;
            this.ui_lblPriceAlert.Text = "Price Alert (% of LTP/CLP/BP) :";
            // 
            // ui_lblValueAlert
            // 
            this.ui_lblValueAlert.AutoSize = true;
            this.ui_lblValueAlert.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblValueAlert.Location = new System.Drawing.Point(7, 136);
            this.ui_lblValueAlert.Name = "ui_lblValueAlert";
            this.ui_lblValueAlert.Size = new System.Drawing.Size(64, 13);
            this.ui_lblValueAlert.TabIndex = 48;
            this.ui_lblValueAlert.Text = "Value Alert :";
            // 
            // ui_lblQuantityAlert
            // 
            this.ui_lblQuantityAlert.AutoSize = true;
            this.ui_lblQuantityAlert.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblQuantityAlert.Location = new System.Drawing.Point(7, 105);
            this.ui_lblQuantityAlert.Name = "ui_lblQuantityAlert";
            this.ui_lblQuantityAlert.Size = new System.Drawing.Size(118, 13);
            this.ui_lblQuantityAlert.TabIndex = 47;
            this.ui_lblQuantityAlert.Text = "Qty Alert(in market lots):";
            // 
            // ui_lblMessageOptions
            // 
            this.ui_lblMessageOptions.AutoSize = true;
            this.ui_lblMessageOptions.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblMessageOptions.Location = new System.Drawing.Point(10, 11);
            this.ui_lblMessageOptions.Name = "ui_lblMessageOptions";
            this.ui_lblMessageOptions.Size = new System.Drawing.Size(333, 13);
            this.ui_lblMessageOptions.TabIndex = 42;
            this.ui_lblMessageOptions.Text = "Select an option to prompt for a confirmation in the form of a message";
            // 
            // ui_nchkOutsideDPROrder
            // 
            this.ui_nchkOutsideDPROrder.AutoSize = true;
            this.ui_nchkOutsideDPROrder.ButtonProperties.BorderOffset = 2;
            this.ui_nchkOutsideDPROrder.Location = new System.Drawing.Point(271, 58);
            this.ui_nchkOutsideDPROrder.Name = "ui_nchkOutsideDPROrder";
            this.ui_nchkOutsideDPROrder.Size = new System.Drawing.Size(117, 17);
            this.ui_nchkOutsideDPROrder.TabIndex = 7;
            this.ui_nchkOutsideDPROrder.TabStop = false;
            this.ui_nchkOutsideDPROrder.Text = "Outside DPR Order";
            this.ui_nchkOutsideDPROrder.TransparentBackground = true;
            this.ui_nchkOutsideDPROrder.UseVisualStyleBackColor = false;
            // 
            // ui_nchkDifferentProductOrder
            // 
            this.ui_nchkDifferentProductOrder.AutoSize = true;
            this.ui_nchkDifferentProductOrder.ButtonProperties.BorderOffset = 2;
            this.ui_nchkDifferentProductOrder.Location = new System.Drawing.Point(125, 58);
            this.ui_nchkDifferentProductOrder.Name = "ui_nchkDifferentProductOrder";
            this.ui_nchkDifferentProductOrder.Size = new System.Drawing.Size(135, 17);
            this.ui_nchkDifferentProductOrder.TabIndex = 6;
            this.ui_nchkDifferentProductOrder.TabStop = false;
            this.ui_nchkDifferentProductOrder.Text = "Different Product Order";
            this.ui_nchkDifferentProductOrder.TransparentBackground = true;
            this.ui_nchkDifferentProductOrder.UseVisualStyleBackColor = false;
            // 
            // ui_nchkTradeModification
            // 
            this.ui_nchkTradeModification.AutoSize = true;
            this.ui_nchkTradeModification.ButtonProperties.BorderOffset = 2;
            this.ui_nchkTradeModification.Location = new System.Drawing.Point(10, 58);
            this.ui_nchkTradeModification.Name = "ui_nchkTradeModification";
            this.ui_nchkTradeModification.Size = new System.Drawing.Size(114, 17);
            this.ui_nchkTradeModification.TabIndex = 5;
            this.ui_nchkTradeModification.TabStop = false;
            this.ui_nchkTradeModification.Text = "Trade Modification";
            this.ui_nchkTradeModification.TransparentBackground = true;
            this.ui_nchkTradeModification.UseVisualStyleBackColor = false;
            // 
            // ui_nchkOrderCancellation
            // 
            this.ui_nchkOrderCancellation.AutoSize = true;
            this.ui_nchkOrderCancellation.ButtonProperties.BorderOffset = 2;
            this.ui_nchkOrderCancellation.Location = new System.Drawing.Point(385, 33);
            this.ui_nchkOrderCancellation.Name = "ui_nchkOrderCancellation";
            this.ui_nchkOrderCancellation.Size = new System.Drawing.Size(113, 17);
            this.ui_nchkOrderCancellation.TabIndex = 4;
            this.ui_nchkOrderCancellation.TabStop = false;
            this.ui_nchkOrderCancellation.Text = "Order Cancellation";
            this.ui_nchkOrderCancellation.TransparentBackground = true;
            this.ui_nchkOrderCancellation.UseVisualStyleBackColor = false;
            // 
            // ui_nchkMarketOrder
            // 
            this.ui_nchkMarketOrder.AutoSize = true;
            this.ui_nchkMarketOrder.ButtonProperties.BorderOffset = 2;
            this.ui_nchkMarketOrder.Location = new System.Drawing.Point(271, 33);
            this.ui_nchkMarketOrder.Name = "ui_nchkMarketOrder";
            this.ui_nchkMarketOrder.Size = new System.Drawing.Size(88, 17);
            this.ui_nchkMarketOrder.TabIndex = 3;
            this.ui_nchkMarketOrder.TabStop = false;
            this.ui_nchkMarketOrder.Text = "Market Order";
            this.ui_nchkMarketOrder.TransparentBackground = true;
            this.ui_nchkMarketOrder.UseVisualStyleBackColor = false;
            // 
            // ui_nchkOrderModification
            // 
            this.ui_nchkOrderModification.AutoSize = true;
            this.ui_nchkOrderModification.ButtonProperties.BorderOffset = 2;
            this.ui_nchkOrderModification.Location = new System.Drawing.Point(125, 33);
            this.ui_nchkOrderModification.Name = "ui_nchkOrderModification";
            this.ui_nchkOrderModification.Size = new System.Drawing.Size(112, 17);
            this.ui_nchkOrderModification.TabIndex = 1;
            this.ui_nchkOrderModification.TabStop = false;
            this.ui_nchkOrderModification.Text = "Order Modification";
            this.ui_nchkOrderModification.TransparentBackground = true;
            this.ui_nchkOrderModification.UseVisualStyleBackColor = false;
            // 
            // ui_nbtnRestoreDefault
            // 
            this.ui_nbtnRestoreDefault.Location = new System.Drawing.Point(397, 306);
            this.ui_nbtnRestoreDefault.Name = "ui_nbtnRestoreDefault";
            this.ui_nbtnRestoreDefault.Size = new System.Drawing.Size(95, 23);
            this.ui_nbtnRestoreDefault.TabIndex = 5;
            this.ui_nbtnRestoreDefault.Text = "Restore Default";
            this.ui_nbtnRestoreDefault.UseVisualStyleBackColor = false;
            this.ui_nbtnRestoreDefault.Click += new System.EventHandler(this.ui_nbtnRestoreDefault_Click);
            // 
            // ui_nchkFreshOrder
            // 
            this.ui_nchkFreshOrder.AutoSize = true;
            this.ui_nchkFreshOrder.ButtonProperties.BorderOffset = 2;
            this.ui_nchkFreshOrder.Location = new System.Drawing.Point(10, 33);
            this.ui_nchkFreshOrder.Name = "ui_nchkFreshOrder";
            this.ui_nchkFreshOrder.Size = new System.Drawing.Size(81, 17);
            this.ui_nchkFreshOrder.TabIndex = 0;
            this.ui_nchkFreshOrder.TabStop = false;
            this.ui_nchkFreshOrder.Text = "Fresh Order";
            this.ui_nchkFreshOrder.TransparentBackground = true;
            this.ui_nchkFreshOrder.UseVisualStyleBackColor = false;
            // 
            // ui_nlcPreferencesAlert4
            // 
            this.ui_nlcPreferencesAlert4.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ui_nlcPreferencesAlert4.Location = new System.Drawing.Point(6, 297);
            this.ui_nlcPreferencesAlert4.Name = "ui_nlcPreferencesAlert4";
            this.ui_nlcPreferencesAlert4.Size = new System.Drawing.Size(486, 2);
            this.ui_nlcPreferencesAlert4.Text = "On Event..Do";
            // 
            // ui_nlcPreferencesAlert3
            // 
            this.ui_nlcPreferencesAlert3.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ui_nlcPreferencesAlert3.Location = new System.Drawing.Point(6, 207);
            this.ui_nlcPreferencesAlert3.Name = "ui_nlcPreferencesAlert3";
            this.ui_nlcPreferencesAlert3.Size = new System.Drawing.Size(486, 2);
            this.ui_nlcPreferencesAlert3.Text = "On Event..Do";
            // 
            // ui_nlcPreferencesAlert2
            // 
            this.ui_nlcPreferencesAlert2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ui_nlcPreferencesAlert2.Location = new System.Drawing.Point(6, 162);
            this.ui_nlcPreferencesAlert2.Name = "ui_nlcPreferencesAlert2";
            this.ui_nlcPreferencesAlert2.Size = new System.Drawing.Size(486, 2);
            this.ui_nlcPreferencesAlert2.Text = "On Event..Do";
            // 
            // ui_nlcPreferencesAlert1
            // 
            this.ui_nlcPreferencesAlert1.BackColor = System.Drawing.SystemColors.Control;
            this.ui_nlcPreferencesAlert1.Location = new System.Drawing.Point(6, 87);
            this.ui_nlcPreferencesAlert1.Name = "ui_nlcPreferencesAlert1";
            this.ui_nlcPreferencesAlert1.Size = new System.Drawing.Size(486, 2);
            this.ui_nlcPreferencesAlert1.Text = "On Event..Do";
            // 
            // uctlPreferencesAlerts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ui_npnlPreferencesAlerts);
            this.Name = "UctlPreferencesAlerts";
            this.Size = new System.Drawing.Size(500, 334);
            this.ui_npnlPreferencesAlerts.ResumeLayout(false);
            this.ui_npnlPreferencesAlerts.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NUIPanel ui_npnlPreferencesAlerts;
        private System.Windows.Forms.Label ui_lblMessageOptions;
        private Nevron.UI.WinForm.Controls.NCheckBox ui_nchkOutsideDPROrder;
        private Nevron.UI.WinForm.Controls.NCheckBox ui_nchkDifferentProductOrder;
        private Nevron.UI.WinForm.Controls.NCheckBox ui_nchkTradeModification;
        private Nevron.UI.WinForm.Controls.NCheckBox ui_nchkOrderCancellation;
        private Nevron.UI.WinForm.Controls.NCheckBox ui_nchkMarketOrder;
        private Nevron.UI.WinForm.Controls.NCheckBox ui_nchkOrderModification;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnRestoreDefault;
        private Nevron.UI.WinForm.Controls.NCheckBox ui_nchkFreshOrder;
        private Nevron.UI.WinForm.Controls.NLineControl ui_nlcPreferencesAlert4;
        private Nevron.UI.WinForm.Controls.NLineControl ui_nlcPreferencesAlert3;
        private Nevron.UI.WinForm.Controls.NLineControl ui_nlcPreferencesAlert2;
        private Nevron.UI.WinForm.Controls.NLineControl ui_nlcPreferencesAlert1;
        private System.Windows.Forms.Label ui_lblTradingCurrencyAlert;
        private System.Windows.Forms.Label ui_lblIOCPriceAlert;
        private System.Windows.Forms.Label ui_lblPriceAlert;
        private System.Windows.Forms.Label ui_lblValueAlert;
        private System.Windows.Forms.Label ui_lblQuantityAlert;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtIOCPriceAlert;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtPriceAlert;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtValueAlert;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtQuntityAlert;
        private Nevron.UI.WinForm.Controls.NCheckBox ui_nchkPendingOrdersAlert;
        private Nevron.UI.WinForm.Controls.NCheckBox ui_nchkOpenPositionAlert;
        private Nevron.UI.WinForm.Controls.NListBox ui_nlstTradingCurrencyAlert;
    }
}
