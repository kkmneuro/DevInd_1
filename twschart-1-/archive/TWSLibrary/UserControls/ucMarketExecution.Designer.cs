namespace CommonLibrary.UserControls
{
    partial class ucMarketExecution
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnBuy = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnSell = new System.Windows.Forms.Button();
            this.lblBidVal = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.lblAskVal = new System.Windows.Forms.Label();
            this.btnReverse = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.cmbMarkPIP = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(10, 89);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(374, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Visible = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnBuy
            // 
            this.btnBuy.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuy.Location = new System.Drawing.Point(226, 50);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(158, 23);
            this.btnBuy.TabIndex = 6;
            this.btnBuy.Text = "Buy";
            this.btnBuy.UseVisualStyleBackColor = true;
            this.btnBuy.Click += new System.EventHandler(this.btnBuy_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(10, 209);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(374, 33);
            this.lblInfo.TabIndex = 3;
            this.lblInfo.Text = "Notice! At order by market execution, the price will be quoted by dealer";
            // 
            // btnSell
            // 
            this.btnSell.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSell.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSell.Location = new System.Drawing.Point(10, 50);
            this.btnSell.Name = "btnSell";
            this.btnSell.Size = new System.Drawing.Size(158, 23);
            this.btnSell.TabIndex = 4;
            this.btnSell.Text = "Sell";
            this.btnSell.UseVisualStyleBackColor = false;
            this.btnSell.Click += new System.EventHandler(this.btnSell_Click);
            // 
            // lblBidVal
            // 
            this.lblBidVal.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBidVal.Location = new System.Drawing.Point(79, 13);
            this.lblBidVal.Name = "lblBidVal";
            this.lblBidVal.Size = new System.Drawing.Size(93, 24);
            this.lblBidVal.TabIndex = 0;
            this.lblBidVal.Text = "00.0000";
            this.lblBidVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label33
            // 
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.label33.Location = new System.Drawing.Point(189, 13);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(17, 27);
            this.label33.TabIndex = 0;
            this.label33.Text = "/";
            // 
            // lblAskVal
            // 
            this.lblAskVal.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAskVal.Location = new System.Drawing.Point(222, 13);
            this.lblAskVal.Name = "lblAskVal";
            this.lblAskVal.Size = new System.Drawing.Size(93, 24);
            this.lblAskVal.TabIndex = 0;
            this.lblAskVal.Text = "00.0000";
            this.lblAskVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnReverse
            // 
            this.btnReverse.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReverse.Location = new System.Drawing.Point(10, 122);
            this.btnReverse.Name = "btnReverse";
            this.btnReverse.Size = new System.Drawing.Size(374, 23);
            this.btnReverse.TabIndex = 5;
            this.btnReverse.Text = "Reverse";
            this.btnReverse.UseVisualStyleBackColor = true;
            this.btnReverse.Visible = false;
            this.btnReverse.Click += new System.EventHandler(this.btnReverse_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(10, 160);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(287, 17);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "Enable maximum deviation from quoted price";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // cmbMarkPIP
            // 
            this.cmbMarkPIP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMarkPIP.Enabled = false;
            this.cmbMarkPIP.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMarkPIP.FormattingEnabled = true;
            this.cmbMarkPIP.Location = new System.Drawing.Point(243, 180);
            this.cmbMarkPIP.Name = "cmbMarkPIP";
            this.cmbMarkPIP.Size = new System.Drawing.Size(50, 21);
            this.cmbMarkPIP.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(299, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "pips";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(65, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Maximum Deviation:";
            // 
            // ucMarketExecution
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbMarkPIP);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.lblAskVal);
            this.Controls.Add(this.btnReverse);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblBidVal);
            this.Controls.Add(this.btnBuy);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnSell);
            this.Name = "ucMarketExecution";
            this.Size = new System.Drawing.Size(394, 254);
            this.Load += new System.EventHandler(this.ucMarketExecution_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnBuy;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnSell;
        private System.Windows.Forms.Label lblBidVal;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label lblAskVal;
        private System.Windows.Forms.Button btnReverse;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox cmbMarkPIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;


    }
}
