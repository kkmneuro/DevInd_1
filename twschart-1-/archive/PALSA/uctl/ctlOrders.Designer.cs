namespace PALSA.uctl
{
    partial class ctlOrders
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
            this.components = new System.ComponentModel.Container();
            this.uctlOrders = new CommonLibrary.UserControls.UctlPendingOrder();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.tlsMarginLevelValue = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tlsBalanceValue = new System.Windows.Forms.Label();
            this.lblMarginLevel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tlsFreeMarginValue = new System.Windows.Forms.Label();
            this.tlsEquityValue = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblUsedMargin = new System.Windows.Forms.Label();
            this.tlsMarginValue = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // uctlOrders
            // 
            this.uctlOrders.AlertSound = null;
            this.uctlOrders.CurrentProfileName = null;
            this.uctlOrders.DataRowStyle = System.Drawing.Color.Empty;
            this.uctlOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uctlOrders.Location = new System.Drawing.Point(1, 1);
            this.uctlOrders.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.uctlOrders.Name = "uctlOrders";
            this.uctlOrders.Profiles = null;
            this.uctlOrders.Size = new System.Drawing.Size(803, 177);
            this.uctlOrders.TabIndex = 0;
            this.uctlOrders.Title = "Pending Order";
            this.uctlOrders.HandleModifyOrderClick += new System.Action<object, System.EventArgs>(this.uctlOrders_HandleModifyOrderClick);
            this.uctlOrders.HandleCloseOrderClick += new System.Action<object, System.EventArgs>(this.uctlOrders_HandleCloseOrderClick);
            this.uctlOrders.Load += new System.EventHandler(this.ctlOrders_Load);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 300;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.uctlOrders, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(805, 198);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 11;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.label6, 10, 0);
            this.tableLayoutPanel2.Controls.Add(this.tlsMarginLevelValue, 9, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tlsBalanceValue, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblMarginLevel, 8, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.tlsFreeMarginValue, 7, 0);
            this.tableLayoutPanel2.Controls.Add(this.tlsEquityValue, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label4, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblUsedMargin, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.tlsMarginValue, 5, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 178);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(805, 20);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(700, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "%";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlsMarginLevelValue
            // 
            this.tlsMarginLevelValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tlsMarginLevelValue.AutoSize = true;
            this.tlsMarginLevelValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlsMarginLevelValue.Location = new System.Drawing.Point(694, 3);
            this.tlsMarginLevelValue.Name = "tlsMarginLevelValue";
            this.tlsMarginLevelValue.Size = new System.Drawing.Size(0, 13);
            this.tlsMarginLevelValue.TabIndex = 9;
            this.tlsMarginLevelValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Balance:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlsBalanceValue
            // 
            this.tlsBalanceValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tlsBalanceValue.AutoSize = true;
            this.tlsBalanceValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlsBalanceValue.Location = new System.Drawing.Point(66, 3);
            this.tlsBalanceValue.Name = "tlsBalanceValue";
            this.tlsBalanceValue.Size = new System.Drawing.Size(0, 13);
            this.tlsBalanceValue.TabIndex = 1;
            this.tlsBalanceValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMarginLevel
            // 
            this.lblMarginLevel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMarginLevel.AutoSize = true;
            this.lblMarginLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarginLevel.Location = new System.Drawing.Point(608, 3);
            this.lblMarginLevel.Name = "lblMarginLevel";
            this.lblMarginLevel.Size = new System.Drawing.Size(80, 13);
            this.lblMarginLevel.TabIndex = 8;
            this.lblMarginLevel.Text = "Margin level:";
            this.lblMarginLevel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(146, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Equity:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlsFreeMarginValue
            // 
            this.tlsFreeMarginValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tlsFreeMarginValue.AutoSize = true;
            this.tlsFreeMarginValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlsFreeMarginValue.Location = new System.Drawing.Point(528, 3);
            this.tlsFreeMarginValue.Name = "tlsFreeMarginValue";
            this.tlsFreeMarginValue.Size = new System.Drawing.Size(0, 13);
            this.tlsFreeMarginValue.TabIndex = 7;
            this.tlsFreeMarginValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlsEquityValue
            // 
            this.tlsEquityValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tlsEquityValue.AutoSize = true;
            this.tlsEquityValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlsEquityValue.Location = new System.Drawing.Point(198, 3);
            this.tlsEquityValue.Name = "tlsEquityValue";
            this.tlsEquityValue.Size = new System.Drawing.Size(0, 13);
            this.tlsEquityValue.TabIndex = 3;
            this.tlsEquityValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(445, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Free margin:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUsedMargin
            // 
            this.lblUsedMargin.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblUsedMargin.AutoEllipsis = true;
            this.lblUsedMargin.AutoSize = true;
            this.lblUsedMargin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsedMargin.Location = new System.Drawing.Point(278, 3);
            this.lblUsedMargin.Name = "lblUsedMargin";
            this.lblUsedMargin.Size = new System.Drawing.Size(81, 13);
            this.lblUsedMargin.TabIndex = 4;
            this.lblUsedMargin.Text = "Used margin:";
            this.lblUsedMargin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlsMarginValue
            // 
            this.tlsMarginValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tlsMarginValue.AutoSize = true;
            this.tlsMarginValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlsMarginValue.Location = new System.Drawing.Point(365, 3);
            this.tlsMarginValue.Name = "tlsMarginValue";
            this.tlsMarginValue.Size = new System.Drawing.Size(0, 13);
            this.tlsMarginValue.TabIndex = 5;
            this.tlsMarginValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ctlOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ctlOrders";
            this.Size = new System.Drawing.Size(805, 198);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CommonLibrary.UserControls.UctlPendingOrder uctlOrders;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label tlsMarginLevelValue;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblMarginLevel;
        private System.Windows.Forms.Label tlsFreeMarginValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label tlsMarginValue;
        private System.Windows.Forms.Label lblUsedMargin;
        private System.Windows.Forms.Label tlsEquityValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label tlsBalanceValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}
