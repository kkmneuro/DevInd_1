namespace BOADMIN_NEW.Uctl
{
    partial class uctlTradeSettle
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
            this.nuiPanel1 = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.nLineControl1 = new Nevron.UI.WinForm.Controls.NLineControl();
            this.ui_nbtnCancel = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nbtnSettle = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_ntxtPrice = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_ntxtQty = new Nevron.UI.WinForm.Controls.NTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nuiPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nuiPanel1
            // 
            this.nuiPanel1.Controls.Add(this.nLineControl1);
            this.nuiPanel1.Controls.Add(this.ui_nbtnCancel);
            this.nuiPanel1.Controls.Add(this.ui_nbtnSettle);
            this.nuiPanel1.Controls.Add(this.ui_ntxtPrice);
            this.nuiPanel1.Controls.Add(this.ui_ntxtQty);
            this.nuiPanel1.Controls.Add(this.label6);
            this.nuiPanel1.Controls.Add(this.label5);
            this.nuiPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nuiPanel1.Location = new System.Drawing.Point(0, 0);
            this.nuiPanel1.Name = "nuiPanel1";
            this.nuiPanel1.Size = new System.Drawing.Size(316, 110);
            this.nuiPanel1.TabIndex = 0;
            this.nuiPanel1.Text = "nuiPanel1";
            // 
            // nLineControl1
            // 
            this.nLineControl1.Location = new System.Drawing.Point(9, 63);
            this.nLineControl1.Name = "nLineControl1";
            this.nLineControl1.Size = new System.Drawing.Size(301, 2);
            this.nLineControl1.Text = "nLineControl1";
            // 
            // ui_nbtnCancel
            // 
            this.ui_nbtnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ui_nbtnCancel.Location = new System.Drawing.Point(234, 80);
            this.ui_nbtnCancel.Name = "ui_nbtnCancel";
            this.ui_nbtnCancel.Size = new System.Drawing.Size(75, 23);
            this.ui_nbtnCancel.TabIndex = 21;
            this.ui_nbtnCancel.Text = "Cancel";
            this.ui_nbtnCancel.UseVisualStyleBackColor = false;
            this.ui_nbtnCancel.Click += new System.EventHandler(this.ui_nbtnCancel_Click);
            // 
            // ui_nbtnSettle
            // 
            this.ui_nbtnSettle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ui_nbtnSettle.Location = new System.Drawing.Point(152, 80);
            this.ui_nbtnSettle.Name = "ui_nbtnSettle";
            this.ui_nbtnSettle.Size = new System.Drawing.Size(75, 23);
            this.ui_nbtnSettle.TabIndex = 20;
            this.ui_nbtnSettle.Text = "Settle";
            this.ui_nbtnSettle.UseVisualStyleBackColor = false;
            this.ui_nbtnSettle.Click += new System.EventHandler(this.ui_nbtnSettle_Click);
            // 
            // ui_ntxtPrice
            // 
            this.ui_ntxtPrice.InputMode = Nevron.UI.WinForm.Controls.TextBoxInputMode.NumericInteger;
            this.ui_ntxtPrice.Location = new System.Drawing.Point(209, 21);
            this.ui_ntxtPrice.MaxLength = 8;
            this.ui_ntxtPrice.Name = "ui_ntxtPrice";
            this.ui_ntxtPrice.Size = new System.Drawing.Size(100, 18);
            this.ui_ntxtPrice.TabIndex = 18;
            this.ui_ntxtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ui_ntxtPrice_KeyPress);
            // 
            // ui_ntxtQty
            // 
            this.ui_ntxtQty.InputMode = Nevron.UI.WinForm.Controls.TextBoxInputMode.NumericInteger;
            this.ui_ntxtQty.Location = new System.Drawing.Point(60, 21);
            this.ui_ntxtQty.MaxLength = 4;
            this.ui_ntxtQty.Name = "ui_ntxtQty";
            this.ui_ntxtQty.ReadOnly = true;
            this.ui_ntxtQty.Size = new System.Drawing.Size(100, 18);
            this.ui_ntxtQty.TabIndex = 17;
            this.ui_ntxtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ui_ntxtQty_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(166, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Price :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(5, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Quantity :";
            // 
            // uctlTradeSettle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nuiPanel1);
            this.Name = "uctlTradeSettle";
            this.Size = new System.Drawing.Size(316, 110);
            this.Load += new System.EventHandler(this.uctlTradeSettle_Load);
            this.nuiPanel1.ResumeLayout(false);
            this.nuiPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NUIPanel nuiPanel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private Nevron.UI.WinForm.Controls.NLineControl nLineControl1;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnCancel;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnSettle;
        public Nevron.UI.WinForm.Controls.NTextBox ui_ntxtPrice;
        public Nevron.UI.WinForm.Controls.NTextBox ui_ntxtQty;
    }
}
