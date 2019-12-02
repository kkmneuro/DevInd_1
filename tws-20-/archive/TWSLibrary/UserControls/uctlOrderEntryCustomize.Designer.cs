namespace CommonLibrary.UserControls
{
    partial class UctlOrderEntryCustomize
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
            this.ui_nbtnCancel = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nbtnOk = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_ncbBuyColor = new Nevron.UI.WinForm.Controls.NColorButton();
            this.ui_lblSell = new System.Windows.Forms.Label();
            this.ui_npnlControlContainer = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.ui_ncbSellColor = new Nevron.UI.WinForm.Controls.NColorButton();
            this.ui_lblBuy = new System.Windows.Forms.Label();
            this.ui_npnlControlContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // ui_nbtnCancel
            // 
            this.ui_nbtnCancel.Location = new System.Drawing.Point(120, 80);
            this.ui_nbtnCancel.Name = "ui_nbtnCancel";
            this.ui_nbtnCancel.Size = new System.Drawing.Size(58, 23);
            this.ui_nbtnCancel.TabIndex = 5;
            this.ui_nbtnCancel.Text = "Cancel";
            this.ui_nbtnCancel.UseVisualStyleBackColor = false;
            this.ui_nbtnCancel.Click += new System.EventHandler(this.ui_nbtnCancel_Click);
            // 
            // ui_nbtnOk
            // 
            this.ui_nbtnOk.Location = new System.Drawing.Point(36, 80);
            this.ui_nbtnOk.Name = "ui_nbtnOk";
            this.ui_nbtnOk.Size = new System.Drawing.Size(58, 23);
            this.ui_nbtnOk.TabIndex = 4;
            this.ui_nbtnOk.Text = "&Ok";
            this.ui_nbtnOk.UseVisualStyleBackColor = false;
            this.ui_nbtnOk.Click += new System.EventHandler(this.ui_nbtnOk_Click);
            // 
            // ui_ncbBuyColor
            // 
            this.ui_ncbBuyColor.ArrowClickOptions = false;
            this.ui_ncbBuyColor.ArrowWidth = 14;
            this.ui_ncbBuyColor.Location = new System.Drawing.Point(101, 11);
            this.ui_ncbBuyColor.Name = "ui_ncbBuyColor";
            this.ui_ncbBuyColor.Size = new System.Drawing.Size(99, 23);
            this.ui_ncbBuyColor.TabIndex = 2;
            this.ui_ncbBuyColor.UseVisualStyleBackColor = false;
            // 
            // ui_lblSell
            // 
            this.ui_lblSell.AutoSize = true;
            this.ui_lblSell.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblSell.Location = new System.Drawing.Point(8, 50);
            this.ui_lblSell.Name = "ui_lblSell";
            this.ui_lblSell.Size = new System.Drawing.Size(89, 13);
            this.ui_lblSell.TabIndex = 1;
            this.ui_lblSell.Text = "Sell Order Color : ";
            // 
            // ui_npnlControlContainer
            // 
            this.ui_npnlControlContainer.Controls.Add(this.ui_nbtnCancel);
            this.ui_npnlControlContainer.Controls.Add(this.ui_nbtnOk);
            this.ui_npnlControlContainer.Controls.Add(this.ui_ncbSellColor);
            this.ui_npnlControlContainer.Controls.Add(this.ui_ncbBuyColor);
            this.ui_npnlControlContainer.Controls.Add(this.ui_lblSell);
            this.ui_npnlControlContainer.Controls.Add(this.ui_lblBuy);
            this.ui_npnlControlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_npnlControlContainer.Location = new System.Drawing.Point(0, 0);
            this.ui_npnlControlContainer.Name = "ui_npnlControlContainer";
            this.ui_npnlControlContainer.Size = new System.Drawing.Size(213, 115);
            this.ui_npnlControlContainer.TabIndex = 1;
            this.ui_npnlControlContainer.Text = "nuiPanel1";
            // 
            // ui_ncbSellColor
            // 
            this.ui_ncbSellColor.ArrowClickOptions = false;
            this.ui_ncbSellColor.ArrowWidth = 14;
            this.ui_ncbSellColor.Location = new System.Drawing.Point(102, 45);
            this.ui_ncbSellColor.Name = "ui_ncbSellColor";
            this.ui_ncbSellColor.Size = new System.Drawing.Size(98, 23);
            this.ui_ncbSellColor.TabIndex = 3;
            this.ui_ncbSellColor.UseVisualStyleBackColor = false;
            // 
            // ui_lblBuy
            // 
            this.ui_lblBuy.AutoSize = true;
            this.ui_lblBuy.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblBuy.Location = new System.Drawing.Point(7, 16);
            this.ui_lblBuy.Name = "ui_lblBuy";
            this.ui_lblBuy.Size = new System.Drawing.Size(90, 13);
            this.ui_lblBuy.TabIndex = 0;
            this.ui_lblBuy.Text = "Buy Order Color : ";
            // 
            // uctlOrderEntryCustomize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ui_npnlControlContainer);
            this.Name = "UctlOrderEntryCustomize";
            this.Size = new System.Drawing.Size(213, 115);
            this.Load += new System.EventHandler(this.uctlOrderEntryCustomize_Load);
            this.ui_npnlControlContainer.ResumeLayout(false);
            this.ui_npnlControlContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NButton ui_nbtnCancel;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnOk;
        private Nevron.UI.WinForm.Controls.NColorButton ui_ncbBuyColor;
        private System.Windows.Forms.Label ui_lblSell;
        private Nevron.UI.WinForm.Controls.NUIPanel ui_npnlControlContainer;
        private Nevron.UI.WinForm.Controls.NColorButton ui_ncbSellColor;
        private System.Windows.Forms.Label ui_lblBuy;
    }
}
