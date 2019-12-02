namespace CommonLibrary.UserControls
{
    partial class UctlPreferencesForexPair
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
            this.ui_npnlControlContainer = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.ui_ncbBackColor = new Nevron.UI.WinForm.Controls.NColorButton();
            this.ui_ncbDownColor = new Nevron.UI.WinForm.Controls.NColorButton();
            this.ui_ncbUpColor = new Nevron.UI.WinForm.Controls.NColorButton();
            this.ui_lblBackColor = new System.Windows.Forms.Label();
            this.ui_lblDownColor = new System.Windows.Forms.Label();
            this.ui_lblUpColor = new System.Windows.Forms.Label();
            this.ui_ngbePositionSizeType = new Nevron.UI.WinForm.Controls.NGroupBoxEx();
            this.ui_nrbLot = new Nevron.UI.WinForm.Controls.NRadioButton();
            this.ui_nrbAmount = new Nevron.UI.WinForm.Controls.NRadioButton();
            this.ui_ngpeOrderFormSettings = new Nevron.UI.WinForm.Controls.NGroupBoxEx();
            this.ui_nrbOpenOrderEntryForm = new Nevron.UI.WinForm.Controls.NRadioButton();
            this.ui_nrbSendMarketOrderWithDefaultQtyWithoutPrompt = new Nevron.UI.WinForm.Controls.NRadioButton();
            this.ui_nrbSendMarketOrderWithDefaultQty = new Nevron.UI.WinForm.Controls.NRadioButton();
            this.uctlForexPair1 = new CommonLibrary.UserControls.UctlForexPair();
            this.ui_npnlControlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ui_ngbePositionSizeType)).BeginInit();
            this.ui_ngbePositionSizeType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ui_ngpeOrderFormSettings)).BeginInit();
            this.ui_ngpeOrderFormSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // ui_npnlControlContainer
            // 
            this.ui_npnlControlContainer.Controls.Add(this.uctlForexPair1);
            this.ui_npnlControlContainer.Controls.Add(this.ui_ncbBackColor);
            this.ui_npnlControlContainer.Controls.Add(this.ui_ncbDownColor);
            this.ui_npnlControlContainer.Controls.Add(this.ui_ncbUpColor);
            this.ui_npnlControlContainer.Controls.Add(this.ui_lblBackColor);
            this.ui_npnlControlContainer.Controls.Add(this.ui_lblDownColor);
            this.ui_npnlControlContainer.Controls.Add(this.ui_lblUpColor);
            this.ui_npnlControlContainer.Controls.Add(this.ui_ngbePositionSizeType);
            this.ui_npnlControlContainer.Controls.Add(this.ui_ngpeOrderFormSettings);
            this.ui_npnlControlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_npnlControlContainer.Location = new System.Drawing.Point(0, 0);
            this.ui_npnlControlContainer.Name = "ui_npnlControlContainer";
            this.ui_npnlControlContainer.Size = new System.Drawing.Size(500, 334);
            this.ui_npnlControlContainer.TabIndex = 0;
            this.ui_npnlControlContainer.Text = "nuiPanel1";
            // 
            // ui_ncbBackColor
            // 
            this.ui_ncbBackColor.ArrowClickOptions = false;
            this.ui_ncbBackColor.ArrowWidth = 14;
            this.ui_ncbBackColor.Location = new System.Drawing.Point(114, 273);
            this.ui_ncbBackColor.Name = "ui_ncbBackColor";
            this.ui_ncbBackColor.Size = new System.Drawing.Size(208, 23);
            this.ui_ncbBackColor.TabIndex = 63;
            this.ui_ncbBackColor.UseVisualStyleBackColor = false;
            this.ui_ncbBackColor.ColorChanged += new System.EventHandler(this.ui_ncbBackColor_ColorChanged);
            // 
            // ui_ncbDownColor
            // 
            this.ui_ncbDownColor.ArrowClickOptions = false;
            this.ui_ncbDownColor.ArrowWidth = 14;
            this.ui_ncbDownColor.Location = new System.Drawing.Point(114, 236);
            this.ui_ncbDownColor.Name = "ui_ncbDownColor";
            this.ui_ncbDownColor.Size = new System.Drawing.Size(208, 23);
            this.ui_ncbDownColor.TabIndex = 62;
            this.ui_ncbDownColor.UseVisualStyleBackColor = false;
            this.ui_ncbDownColor.ColorChanged += new System.EventHandler(this.ui_ncbDownColor_ColorChanged);
            // 
            // ui_ncbUpColor
            // 
            this.ui_ncbUpColor.ArrowClickOptions = false;
            this.ui_ncbUpColor.ArrowWidth = 14;
            this.ui_ncbUpColor.Location = new System.Drawing.Point(114, 200);
            this.ui_ncbUpColor.Name = "ui_ncbUpColor";
            this.ui_ncbUpColor.Size = new System.Drawing.Size(208, 23);
            this.ui_ncbUpColor.TabIndex = 61;
            this.ui_ncbUpColor.UseVisualStyleBackColor = false;
            this.ui_ncbUpColor.ColorChanged += new System.EventHandler(this.ui_ncbUpColor_ColorChanged);
            // 
            // ui_lblBackColor
            // 
            this.ui_lblBackColor.AutoSize = true;
            this.ui_lblBackColor.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblBackColor.Location = new System.Drawing.Point(48, 278);
            this.ui_lblBackColor.Name = "ui_lblBackColor";
            this.ui_lblBackColor.Size = new System.Drawing.Size(62, 13);
            this.ui_lblBackColor.TabIndex = 60;
            this.ui_lblBackColor.Text = "BackColor :";
            // 
            // ui_lblDownColor
            // 
            this.ui_lblDownColor.AutoSize = true;
            this.ui_lblDownColor.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblDownColor.Location = new System.Drawing.Point(11, 241);
            this.ui_lblDownColor.Name = "ui_lblDownColor";
            this.ui_lblDownColor.Size = new System.Drawing.Size(99, 13);
            this.ui_lblDownColor.TabIndex = 59;
            this.ui_lblDownColor.Text = "Down Trend Color :";
            // 
            // ui_lblUpColor
            // 
            this.ui_lblUpColor.AutoSize = true;
            this.ui_lblUpColor.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblUpColor.Location = new System.Drawing.Point(25, 205);
            this.ui_lblUpColor.Name = "ui_lblUpColor";
            this.ui_lblUpColor.Size = new System.Drawing.Size(85, 13);
            this.ui_lblUpColor.TabIndex = 58;
            this.ui_lblUpColor.Text = "Up Trend Color :";
            // 
            // ui_ngbePositionSizeType
            // 
            this.ui_ngbePositionSizeType.BackColor = System.Drawing.Color.Transparent;
            this.ui_ngbePositionSizeType.Controls.Add(this.ui_nrbLot);
            this.ui_ngbePositionSizeType.Controls.Add(this.ui_nrbAmount);
            this.ui_ngbePositionSizeType.FillInfo.Gradient2 = System.Drawing.Color.White;
            this.ui_ngbePositionSizeType.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_ngbePositionSizeType.HeaderFillInfo.Gradient2 = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(238)))), ((int)(((byte)(230)))));
            this.ui_ngbePositionSizeType.HeaderItem.Text = "Position Size Type";
            this.ui_ngbePositionSizeType.Location = new System.Drawing.Point(15, 136);
            this.ui_ngbePositionSizeType.Name = "ui_ngbePositionSizeType";
            this.ui_ngbePositionSizeType.Size = new System.Drawing.Size(470, 55);
            this.ui_ngbePositionSizeType.TabIndex = 57;
            this.ui_ngbePositionSizeType.Text = "nGroupBoxEx2";
            // 
            // ui_nrbLot
            // 
            this.ui_nrbLot.AutoSize = true;
            this.ui_nrbLot.ButtonProperties.BorderOffset = 2;
            this.ui_nrbLot.Checked = true;
            this.ui_nrbLot.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_nrbLot.Location = new System.Drawing.Point(146, 23);
            this.ui_nrbLot.Name = "ui_nrbLot";
            this.ui_nrbLot.Size = new System.Drawing.Size(42, 17);
            this.ui_nrbLot.TabIndex = 36;
            this.ui_nrbLot.TabStop = true;
            this.ui_nrbLot.Text = "Lot";
            this.ui_nrbLot.TransparentBackground = true;
            this.ui_nrbLot.UseVisualStyleBackColor = false;
            // 
            // ui_nrbAmount
            // 
            this.ui_nrbAmount.AutoSize = true;
            this.ui_nrbAmount.ButtonProperties.BorderOffset = 2;
            this.ui_nrbAmount.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_nrbAmount.Location = new System.Drawing.Point(247, 23);
            this.ui_nrbAmount.Name = "ui_nrbAmount";
            this.ui_nrbAmount.Size = new System.Drawing.Size(69, 17);
            this.ui_nrbAmount.TabIndex = 36;
            this.ui_nrbAmount.Text = "Amount";
            this.ui_nrbAmount.TransparentBackground = true;
            this.ui_nrbAmount.UseVisualStyleBackColor = false;
            // 
            // ui_ngpeOrderFormSettings
            // 
            this.ui_ngpeOrderFormSettings.BackColor = System.Drawing.Color.Transparent;
            this.ui_ngpeOrderFormSettings.Controls.Add(this.ui_nrbOpenOrderEntryForm);
            this.ui_ngpeOrderFormSettings.Controls.Add(this.ui_nrbSendMarketOrderWithDefaultQtyWithoutPrompt);
            this.ui_ngpeOrderFormSettings.Controls.Add(this.ui_nrbSendMarketOrderWithDefaultQty);
            this.ui_ngpeOrderFormSettings.FillInfo.Gradient2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ui_ngpeOrderFormSettings.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_ngpeOrderFormSettings.HeaderFillInfo.Gradient2 = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(238)))), ((int)(((byte)(230)))));
            this.ui_ngpeOrderFormSettings.HeaderItem.Text = "Order Form Settings";
            this.ui_ngpeOrderFormSettings.Location = new System.Drawing.Point(15, 13);
            this.ui_ngpeOrderFormSettings.Name = "ui_ngpeOrderFormSettings";
            this.ui_ngpeOrderFormSettings.Size = new System.Drawing.Size(470, 114);
            this.ui_ngpeOrderFormSettings.TabIndex = 56;
            this.ui_ngpeOrderFormSettings.Text = "nGroupBoxEx1";
            // 
            // ui_nrbOpenOrderEntryForm
            // 
            this.ui_nrbOpenOrderEntryForm.AutoSize = true;
            this.ui_nrbOpenOrderEntryForm.ButtonProperties.BorderOffset = 2;
            this.ui_nrbOpenOrderEntryForm.Checked = true;
            this.ui_nrbOpenOrderEntryForm.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_nrbOpenOrderEntryForm.Location = new System.Drawing.Point(27, 41);
            this.ui_nrbOpenOrderEntryForm.Name = "ui_nrbOpenOrderEntryForm";
            this.ui_nrbOpenOrderEntryForm.Size = new System.Drawing.Size(163, 17);
            this.ui_nrbOpenOrderEntryForm.TabIndex = 36;
            this.ui_nrbOpenOrderEntryForm.TabStop = true;
            this.ui_nrbOpenOrderEntryForm.Text = " Open Order Entry Form";
            this.ui_nrbOpenOrderEntryForm.TransparentBackground = true;
            this.ui_nrbOpenOrderEntryForm.UseVisualStyleBackColor = false;
            // 
            // ui_nrbSendMarketOrderWithDefaultQtyWithoutPrompt
            // 
            this.ui_nrbSendMarketOrderWithDefaultQtyWithoutPrompt.AutoSize = true;
            this.ui_nrbSendMarketOrderWithDefaultQtyWithoutPrompt.ButtonProperties.BorderOffset = 2;
            this.ui_nrbSendMarketOrderWithDefaultQtyWithoutPrompt.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_nrbSendMarketOrderWithDefaultQtyWithoutPrompt.Location = new System.Drawing.Point(27, 87);
            this.ui_nrbSendMarketOrderWithDefaultQtyWithoutPrompt.Name = "ui_nrbSendMarketOrderWithDefaultQtyWithoutPrompt";
            this.ui_nrbSendMarketOrderWithDefaultQtyWithoutPrompt.Size = new System.Drawing.Size(369, 17);
            this.ui_nrbSendMarketOrderWithDefaultQtyWithoutPrompt.TabIndex = 36;
            this.ui_nrbSendMarketOrderWithDefaultQtyWithoutPrompt.Text = " Send Market Order with Default Quantity without Prompting";
            this.ui_nrbSendMarketOrderWithDefaultQtyWithoutPrompt.TransparentBackground = true;
            this.ui_nrbSendMarketOrderWithDefaultQtyWithoutPrompt.UseVisualStyleBackColor = false;
            // 
            // ui_nrbSendMarketOrderWithDefaultQty
            // 
            this.ui_nrbSendMarketOrderWithDefaultQty.AutoSize = true;
            this.ui_nrbSendMarketOrderWithDefaultQty.ButtonProperties.BorderOffset = 2;
            this.ui_nrbSendMarketOrderWithDefaultQty.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_nrbSendMarketOrderWithDefaultQty.Location = new System.Drawing.Point(27, 64);
            this.ui_nrbSendMarketOrderWithDefaultQty.Name = "ui_nrbSendMarketOrderWithDefaultQty";
            this.ui_nrbSendMarketOrderWithDefaultQty.Size = new System.Drawing.Size(262, 17);
            this.ui_nrbSendMarketOrderWithDefaultQty.TabIndex = 36;
            this.ui_nrbSendMarketOrderWithDefaultQty.Text = " Send Market Order with Default Quantity";
            this.ui_nrbSendMarketOrderWithDefaultQty.TransparentBackground = true;
            this.ui_nrbSendMarketOrderWithDefaultQty.UseVisualStyleBackColor = false;
            // 
            // uctlForexPair1
            // 
            this.uctlForexPair1.Amount = "Select";
            this.uctlForexPair1.BackColor = System.Drawing.Color.DodgerBlue;
            this.uctlForexPair1.Enabled = false;
            this.uctlForexPair1.Location = new System.Drawing.Point(333, 202);
            this.uctlForexPair1.MultipliedValue = 10000;
            this.uctlForexPair1.Name = "uctlForexPair1";
            this.uctlForexPair1.RoundOff = 4;
            this.uctlForexPair1.Size = new System.Drawing.Size(145, 91);
            this.uctlForexPair1.Symbol = "Select";
            this.uctlForexPair1.TabIndex = 64;
            this.uctlForexPair1.Title = "Forex Pair";
            // 
            // uctlPreferencesForexPair
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ui_npnlControlContainer);
            this.Name = "uctlPreferencesForexPair";
            this.Size = new System.Drawing.Size(500, 334);
            this.ui_npnlControlContainer.ResumeLayout(false);
            this.ui_npnlControlContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ui_ngbePositionSizeType)).EndInit();
            this.ui_ngbePositionSizeType.ResumeLayout(false);
            this.ui_ngbePositionSizeType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ui_ngpeOrderFormSettings)).EndInit();
            this.ui_ngpeOrderFormSettings.ResumeLayout(false);
            this.ui_ngpeOrderFormSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NUIPanel ui_npnlControlContainer;
        public Nevron.UI.WinForm.Controls.NGroupBoxEx ui_ngbePositionSizeType;
        public Nevron.UI.WinForm.Controls.NRadioButton ui_nrbLot;
        public Nevron.UI.WinForm.Controls.NRadioButton ui_nrbAmount;
        public Nevron.UI.WinForm.Controls.NGroupBoxEx ui_ngpeOrderFormSettings;
        public Nevron.UI.WinForm.Controls.NRadioButton ui_nrbOpenOrderEntryForm;
        public Nevron.UI.WinForm.Controls.NRadioButton ui_nrbSendMarketOrderWithDefaultQtyWithoutPrompt;
        public Nevron.UI.WinForm.Controls.NRadioButton ui_nrbSendMarketOrderWithDefaultQty;
        private System.Windows.Forms.Label ui_lblBackColor;
        private System.Windows.Forms.Label ui_lblDownColor;
        private System.Windows.Forms.Label ui_lblUpColor;
        private UctlForexPair uctlForexPair1;
        private Nevron.UI.WinForm.Controls.NColorButton ui_ncbBackColor;
        private Nevron.UI.WinForm.Controls.NColorButton ui_ncbDownColor;
        private Nevron.UI.WinForm.Controls.NColorButton ui_ncbUpColor;
    }
}
