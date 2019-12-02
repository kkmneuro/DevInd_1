namespace CommonLibrary.UserControls
{
    partial class uctlMarketExecution
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
            this.btnSell = new Nevron.UI.WinForm.Controls.NButton();
            this.btnBuy = new Nevron.UI.WinForm.Controls.NButton();
            this.label1 = new System.Windows.Forms.Label();
            this.lblBidVal = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.cmbMarkPIP = new Nevron.UI.WinForm.Controls.NComboBox();
            this.checkBox1 = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnReverse = new Nevron.UI.WinForm.Controls.NButton();
            this.lblAskVal = new System.Windows.Forms.Label();
            this.btnClose = new Nevron.UI.WinForm.Controls.NButton();
            this.label3 = new System.Windows.Forms.Label();
            this.nuiPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nuiPanel1
            // 
            this.nuiPanel1.Controls.Add(this.btnSell);
            this.nuiPanel1.Controls.Add(this.btnBuy);
            this.nuiPanel1.Controls.Add(this.label1);
            this.nuiPanel1.Controls.Add(this.lblBidVal);
            this.nuiPanel1.Controls.Add(this.label33);
            this.nuiPanel1.Controls.Add(this.cmbMarkPIP);
            this.nuiPanel1.Controls.Add(this.checkBox1);
            this.nuiPanel1.Controls.Add(this.lblInfo);
            this.nuiPanel1.Controls.Add(this.btnReverse);
            this.nuiPanel1.Controls.Add(this.lblAskVal);
            this.nuiPanel1.Controls.Add(this.btnClose);
            this.nuiPanel1.Controls.Add(this.label3);
            this.nuiPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nuiPanel1.Location = new System.Drawing.Point(0, 0);
            this.nuiPanel1.Name = "nuiPanel1";
            this.nuiPanel1.Size = new System.Drawing.Size(351, 228);
            this.nuiPanel1.TabIndex = 0;
            this.nuiPanel1.Text = "nuiPanel1";
            // 
            // btnSell
            // 
            this.btnSell.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSell.Location = new System.Drawing.Point(52, 34);
            this.btnSell.Name = "btnSell";
            this.btnSell.Size = new System.Drawing.Size(97, 23);
            this.btnSell.TabIndex = 4;
            this.btnSell.Text = "Sell";
            this.btnSell.UseVisualStyleBackColor = false;
            this.btnSell.Click += new System.EventHandler(this.btnSell_Click);
            // 
            // btnBuy
            // 
            this.btnBuy.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnBuy.Location = new System.Drawing.Point(207, 34);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(97, 23);
            this.btnBuy.TabIndex = 5;
            this.btnBuy.Text = "Buy";
            this.btnBuy.UseVisualStyleBackColor = false;
            this.btnBuy.Click += new System.EventHandler(this.btnBuy_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(204, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "pips";
            // 
            // lblBidVal
            // 
            this.lblBidVal.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblBidVal.AutoSize = true;
            this.lblBidVal.BackColor = System.Drawing.Color.Transparent;
            this.lblBidVal.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBidVal.Location = new System.Drawing.Point(57, 7);
            this.lblBidVal.Name = "lblBidVal";
            this.lblBidVal.Size = new System.Drawing.Size(89, 23);
            this.lblBidVal.TabIndex = 1;
            this.lblBidVal.Text = "00.0000";
            this.lblBidVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label33
            // 
            this.label33.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label33.BackColor = System.Drawing.Color.Transparent;
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.label33.Location = new System.Drawing.Point(171, 5);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(14, 27);
            this.label33.TabIndex = 2;
            this.label33.Text = "/";
            // 
            // cmbMarkPIP
            // 
            this.cmbMarkPIP.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbMarkPIP.ListProperties.ColumnOnLeft = false;
            this.cmbMarkPIP.Location = new System.Drawing.Point(152, 153);
            this.cmbMarkPIP.Name = "cmbMarkPIP";
            this.cmbMarkPIP.Size = new System.Drawing.Size(46, 22);
            this.cmbMarkPIP.TabIndex = 14;
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBox1.ButtonProperties.BorderOffset = 2;
            this.checkBox1.Location = new System.Drawing.Point(20, 130);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(315, 18);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "Enable maximum deviation from quoted price";
            this.checkBox1.TransparentBackground = true;
            this.checkBox1.UseCompatibleTextRendering = true;
            this.checkBox1.UseVisualStyleBackColor = false;
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblInfo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(6, 180);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(337, 41);
            this.lblInfo.TabIndex = 16;
            this.lblInfo.Text = "Notice! At order by market execution, the price will be quoted by dealer";
            // 
            // btnReverse
            // 
            this.btnReverse.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnReverse.Location = new System.Drawing.Point(20, 99);
            this.btnReverse.Name = "btnReverse";
            this.btnReverse.Size = new System.Drawing.Size(314, 23);
            this.btnReverse.TabIndex = 7;
            this.btnReverse.Text = "Reverse";
            this.btnReverse.UseVisualStyleBackColor = false;
            this.btnReverse.Click += new System.EventHandler(this.btnReverse_Click);
            // 
            // lblAskVal
            // 
            this.lblAskVal.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAskVal.AutoSize = true;
            this.lblAskVal.BackColor = System.Drawing.Color.Transparent;
            this.lblAskVal.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAskVal.Location = new System.Drawing.Point(211, 7);
            this.lblAskVal.Name = "lblAskVal";
            this.lblAskVal.Size = new System.Drawing.Size(89, 23);
            this.lblAskVal.TabIndex = 3;
            this.lblAskVal.Text = "00.0000";
            this.lblAskVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClose.Location = new System.Drawing.Point(20, 67);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(314, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Maximum Deviation:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uctlMarketExecution
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nuiPanel1);
            this.Name = "uctlMarketExecution";
            this.Size = new System.Drawing.Size(351, 228);
            this.nuiPanel1.ResumeLayout(false);
            this.nuiPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NUIPanel nuiPanel1;
        private System.Windows.Forms.Label lblBidVal;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label lblAskVal;
        private Nevron.UI.WinForm.Controls.NButton btnSell;
        private Nevron.UI.WinForm.Controls.NButton btnBuy;
        private Nevron.UI.WinForm.Controls.NButton btnClose;
        private Nevron.UI.WinForm.Controls.NButton btnReverse;
        private Nevron.UI.WinForm.Controls.NCheckBox checkBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private Nevron.UI.WinForm.Controls.NComboBox cmbMarkPIP;
        public System.Windows.Forms.Label lblInfo;
    }
}
