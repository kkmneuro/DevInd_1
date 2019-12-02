namespace CommonLibrary.UserControls
{
    partial class UctlSnapQuote
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
            this.ui_ncmbProduct = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_ntxtLastTradedPrice = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_ntxtSellPrice = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_ntxtSellQuantity = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_ntxtBuyPrice = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_ntxtBuyQuantity = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_ncmbProductType = new Nevron.UI.WinForm.Controls.NComboBox();
            this.nComboBox4 = new Nevron.UI.WinForm.Controls.NComboBox();
            this.nComboBox3 = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_ncmbContract = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_ncmbExpiryDate = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_npnlControlContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // ui_npnlControlContainer
            // 
            this.ui_npnlControlContainer.Controls.Add(this.ui_ncmbProduct);
            this.ui_npnlControlContainer.Controls.Add(this.ui_ntxtLastTradedPrice);
            this.ui_npnlControlContainer.Controls.Add(this.ui_ntxtSellPrice);
            this.ui_npnlControlContainer.Controls.Add(this.ui_ntxtSellQuantity);
            this.ui_npnlControlContainer.Controls.Add(this.ui_ntxtBuyPrice);
            this.ui_npnlControlContainer.Controls.Add(this.ui_ntxtBuyQuantity);
            this.ui_npnlControlContainer.Controls.Add(this.ui_ncmbProductType);
            this.ui_npnlControlContainer.Controls.Add(this.nComboBox4);
            this.ui_npnlControlContainer.Controls.Add(this.nComboBox3);
            this.ui_npnlControlContainer.Controls.Add(this.ui_ncmbContract);
            this.ui_npnlControlContainer.Controls.Add(this.ui_ncmbExpiryDate);
            this.ui_npnlControlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_npnlControlContainer.Location = new System.Drawing.Point(0, 0);
            this.ui_npnlControlContainer.Name = "ui_npnlControlContainer";
            this.ui_npnlControlContainer.Size = new System.Drawing.Size(710, 34);
            this.ui_npnlControlContainer.TabIndex = 0;
            this.ui_npnlControlContainer.Text = "nuiPanel1";
            // 
            // ui_ncmbProduct
            // 
            this.ui_ncmbProduct.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbProduct.Location = new System.Drawing.Point(91, 7);
            this.ui_ncmbProduct.Name = "ui_ncmbProduct";
            this.ui_ncmbProduct.Size = new System.Drawing.Size(90, 18);
            this.ui_ncmbProduct.TabIndex = 11;
            this.ui_ncmbProduct.TooltipInfo.CaptionText = "Select Product";
            this.ui_ncmbProduct.SelectedIndexChanged += new System.EventHandler(this.ui_ncmbProduct_SelectedIndexChanged);
            // 
            // ui_ntxtLastTradedPrice
            // 
            this.ui_ntxtLastTradedPrice.Location = new System.Drawing.Point(638, 7);
            this.ui_ntxtLastTradedPrice.Name = "ui_ntxtLastTradedPrice";
            this.ui_ntxtLastTradedPrice.Size = new System.Drawing.Size(68, 18);
            this.ui_ntxtLastTradedPrice.TabIndex = 10;
            this.ui_ntxtLastTradedPrice.Text = "Last Traded Price";
            // 
            // ui_ntxtSellPrice
            // 
            this.ui_ntxtSellPrice.Location = new System.Drawing.Point(570, 7);
            this.ui_ntxtSellPrice.Name = "ui_ntxtSellPrice";
            this.ui_ntxtSellPrice.Size = new System.Drawing.Size(68, 18);
            this.ui_ntxtSellPrice.TabIndex = 9;
            this.ui_ntxtSellPrice.Text = "Sell Price";
            // 
            // ui_ntxtSellQuantity
            // 
            this.ui_ntxtSellQuantity.Location = new System.Drawing.Point(502, 7);
            this.ui_ntxtSellQuantity.Name = "ui_ntxtSellQuantity";
            this.ui_ntxtSellQuantity.Size = new System.Drawing.Size(68, 18);
            this.ui_ntxtSellQuantity.TabIndex = 8;
            this.ui_ntxtSellQuantity.Text = "Sell Quantity";
            // 
            // ui_ntxtBuyPrice
            // 
            this.ui_ntxtBuyPrice.Location = new System.Drawing.Point(434, 7);
            this.ui_ntxtBuyPrice.Name = "ui_ntxtBuyPrice";
            this.ui_ntxtBuyPrice.Size = new System.Drawing.Size(68, 18);
            this.ui_ntxtBuyPrice.TabIndex = 7;
            this.ui_ntxtBuyPrice.Text = "Buy Price";
            // 
            // ui_ntxtBuyQuantity
            // 
            this.ui_ntxtBuyQuantity.Location = new System.Drawing.Point(366, 7);
            this.ui_ntxtBuyQuantity.Name = "ui_ntxtBuyQuantity";
            this.ui_ntxtBuyQuantity.Size = new System.Drawing.Size(68, 18);
            this.ui_ntxtBuyQuantity.TabIndex = 6;
            this.ui_ntxtBuyQuantity.Text = "Buy Quantity";
            // 
            // ui_ncmbProductType
            // 
            this.ui_ncmbProductType.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("---SELECT---", -1, false, 0, new System.Drawing.Size(0, 0))});
            this.ui_ncmbProductType.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbProductType.Location = new System.Drawing.Point(0, 7);
            this.ui_ncmbProductType.Name = "ui_ncmbProductType";
            this.ui_ncmbProductType.Size = new System.Drawing.Size(90, 18);
            this.ui_ncmbProductType.TabIndex = 0;
            this.ui_ncmbProductType.TooltipInfo.CaptionText = "Select Product Type";
            this.ui_ncmbProductType.SelectedIndexChanged += new System.EventHandler(this.ui_ncmbProductType_SelectedIndexChanged);
            // 
            // nComboBox4
            // 
            this.nComboBox4.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("SELECT", -1, false, 0, new System.Drawing.Size(0, 0))});
            this.nComboBox4.ListProperties.ColumnOnLeft = false;
            this.nComboBox4.Location = new System.Drawing.Point(317, -5);
            this.nComboBox4.Name = "nComboBox4";
            this.nComboBox4.Size = new System.Drawing.Size(10, 10);
            this.nComboBox4.TabIndex = 5;
            this.nComboBox4.Text = "nComboBox4";
            this.nComboBox4.Visible = false;
            // 
            // nComboBox3
            // 
            this.nComboBox3.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("SELECT", -1, false, 0, new System.Drawing.Size(0, 0))});
            this.nComboBox3.ListProperties.ColumnOnLeft = false;
            this.nComboBox3.Location = new System.Drawing.Point(301, -4);
            this.nComboBox3.Name = "nComboBox3";
            this.nComboBox3.Size = new System.Drawing.Size(10, 10);
            this.nComboBox3.TabIndex = 4;
            this.nComboBox3.Text = "nComboBox3";
            this.nComboBox3.Visible = false;
            // 
            // ui_ncmbContract
            // 
            this.ui_ncmbContract.Editable = true;
            this.ui_ncmbContract.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbContract.Location = new System.Drawing.Point(183, 7);
            this.ui_ncmbContract.Name = "ui_ncmbContract";
            this.ui_ncmbContract.Size = new System.Drawing.Size(90, 18);
            this.ui_ncmbContract.TabIndex = 2;
            this.ui_ncmbContract.TooltipInfo.CaptionText = "Select Contract";
            this.ui_ncmbContract.SelectedIndexChanged += new System.EventHandler(this.ui_ncmbContract_SelectedIndexChanged);
            // 
            // ui_ncmbExpiryDate
            // 
            this.ui_ncmbExpiryDate.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("---SELECT---", -1, false, 0, new System.Drawing.Size(0, 0))});
            this.ui_ncmbExpiryDate.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbExpiryDate.Location = new System.Drawing.Point(275, 7);
            this.ui_ncmbExpiryDate.Name = "ui_ncmbExpiryDate";
            this.ui_ncmbExpiryDate.Size = new System.Drawing.Size(90, 18);
            this.ui_ncmbExpiryDate.TabIndex = 3;
            this.ui_ncmbExpiryDate.TooltipInfo.CaptionText = "Select Expiry Date";
            // 
            // uctlSnapQuote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ui_npnlControlContainer);
            this.Name = "UctlSnapQuote";
            this.Size = new System.Drawing.Size(710, 34);
            this.Load += new System.EventHandler(this.uctlSnapQuote_Load);
            this.ui_npnlControlContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NUIPanel ui_npnlControlContainer;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtLastTradedPrice;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtSellPrice;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtSellQuantity;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtBuyPrice;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtBuyQuantity;
        private Nevron.UI.WinForm.Controls.NComboBox nComboBox4;
        private Nevron.UI.WinForm.Controls.NComboBox nComboBox3;
        public Nevron.UI.WinForm.Controls.NComboBox ui_ncmbProductType;
        public Nevron.UI.WinForm.Controls.NComboBox ui_ncmbContract;
        public Nevron.UI.WinForm.Controls.NComboBox ui_ncmbExpiryDate;
        public Nevron.UI.WinForm.Controls.NComboBox ui_ncmbProduct;
    }
}
