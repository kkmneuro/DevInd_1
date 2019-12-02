namespace TWS.Frm
{
    partial class frmOrderSimulator
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.clmAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSymbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOrderType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSide = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAvgPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmLTP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmLUT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblOrderCount = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbProductType = new System.Windows.Forms.ComboBox();
            this.cmbProduct = new System.Windows.Forms.ComboBox();
            this.cmbContract = new System.Windows.Forms.ComboBox();
            this.nudRunTime = new System.Windows.Forms.NumericUpDown();
            this.txtAccountCloseTrade = new System.Windows.Forms.TextBox();
            this.txtAccountOpenTrade = new System.Windows.Forms.TextBox();
            this.ui_nbtnStart = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nbtnStop = new Nevron.UI.WinForm.Controls.NButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRunTime)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgvOrders, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 123F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1118, 614);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.AllowUserToOrderColumns = true;
            this.dgvOrders.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgvOrders.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrders.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmAccount,
            this.clmOrder,
            this.clmSymbol,
            this.clmOrderType,
            this.clmSide,
            this.clmStatus,
            this.clmPrice,
            this.clmAvgPrice,
            this.clmLTP,
            this.clmQuantity,
            this.clmLUT});
            this.dgvOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrders.Location = new System.Drawing.Point(3, 126);
            this.dgvOrders.MultiSelect = false;
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.RowHeadersVisible = false;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.Size = new System.Drawing.Size(1112, 485);
            this.dgvOrders.TabIndex = 2;
            // 
            // clmAccount
            // 
            this.clmAccount.HeaderText = "Account";
            this.clmAccount.Name = "clmAccount";
            this.clmAccount.ReadOnly = true;
            // 
            // clmOrder
            // 
            this.clmOrder.HeaderText = "Order";
            this.clmOrder.Name = "clmOrder";
            this.clmOrder.ReadOnly = true;
            // 
            // clmSymbol
            // 
            this.clmSymbol.HeaderText = "Symbol";
            this.clmSymbol.Name = "clmSymbol";
            this.clmSymbol.ReadOnly = true;
            // 
            // clmOrderType
            // 
            this.clmOrderType.HeaderText = "Order Type";
            this.clmOrderType.Name = "clmOrderType";
            this.clmOrderType.ReadOnly = true;
            // 
            // clmSide
            // 
            this.clmSide.HeaderText = "Side";
            this.clmSide.Name = "clmSide";
            this.clmSide.ReadOnly = true;
            // 
            // clmStatus
            // 
            this.clmStatus.HeaderText = "Status";
            this.clmStatus.Name = "clmStatus";
            this.clmStatus.ReadOnly = true;
            // 
            // clmPrice
            // 
            this.clmPrice.HeaderText = "Price";
            this.clmPrice.Name = "clmPrice";
            this.clmPrice.ReadOnly = true;
            // 
            // clmAvgPrice
            // 
            this.clmAvgPrice.HeaderText = "Avg. Price";
            this.clmAvgPrice.Name = "clmAvgPrice";
            this.clmAvgPrice.ReadOnly = true;
            // 
            // clmLTP
            // 
            this.clmLTP.HeaderText = "LTP";
            this.clmLTP.Name = "clmLTP";
            this.clmLTP.ReadOnly = true;
            // 
            // clmQuantity
            // 
            this.clmQuantity.HeaderText = "Quantity";
            this.clmQuantity.Name = "clmQuantity";
            this.clmQuantity.ReadOnly = true;
            // 
            // clmLUT
            // 
            this.clmLUT.HeaderText = "LUT";
            this.clmLUT.Name = "clmLUT";
            this.clmLUT.ReadOnly = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 7;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 189F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 188F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel2.Controls.Add(this.lblOrderCount, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label8, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label6, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label7, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.label2, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.cmbProductType, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.cmbProduct, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.cmbContract, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.nudRunTime, 5, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtAccountCloseTrade, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtAccountOpenTrade, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.ui_nbtnStart, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.ui_nbtnStop, 6, 1);
            this.tableLayoutPanel2.Controls.Add(this.label5, 6, 2);
            this.tableLayoutPanel2.Controls.Add(this.label9, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblStartTime, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.label11, 4, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblEndTime, 5, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1112, 117);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lblOrderCount
            // 
            this.lblOrderCount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblOrderCount.AutoSize = true;
            this.lblOrderCount.Location = new System.Drawing.Point(138, 91);
            this.lblOrderCount.Name = "lblOrderCount";
            this.lblOrderCount.Size = new System.Drawing.Size(64, 13);
            this.lblOrderCount.TabIndex = 97;
            this.lblOrderCount.Text = "Order Count";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(64, 91);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 13);
            this.label8.TabIndex = 96;
            this.label8.Text = "Total Orders:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Account to Close Trades";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Product Type:";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(424, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Product:";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(759, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Contract:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(344, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Account to Open Trades:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(737, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "No Of Orders:";
            // 
            // cmbProductType
            // 
            this.cmbProductType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbProductType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbProductType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbProductType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProductType.FormattingEnabled = true;
            this.cmbProductType.Location = new System.Drawing.Point(138, 9);
            this.cmbProductType.Name = "cmbProductType";
            this.cmbProductType.Size = new System.Drawing.Size(144, 21);
            this.cmbProductType.TabIndex = 90;
            // 
            // cmbProduct
            // 
            this.cmbProduct.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbProduct.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbProduct.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProduct.FormattingEnabled = true;
            this.cmbProduct.Location = new System.Drawing.Point(477, 9);
            this.cmbProduct.Name = "cmbProduct";
            this.cmbProduct.Size = new System.Drawing.Size(144, 21);
            this.cmbProduct.TabIndex = 91;
            // 
            // cmbContract
            // 
            this.cmbContract.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbContract.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbContract.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbContract.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbContract.FormattingEnabled = true;
            this.cmbContract.Location = new System.Drawing.Point(815, 9);
            this.cmbContract.Name = "cmbContract";
            this.cmbContract.Size = new System.Drawing.Size(144, 21);
            this.cmbContract.TabIndex = 92;
            // 
            // nudRunTime
            // 
            this.nudRunTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nudRunTime.Location = new System.Drawing.Point(815, 48);
            this.nudRunTime.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudRunTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRunTime.Name = "nudRunTime";
            this.nudRunTime.Size = new System.Drawing.Size(144, 20);
            this.nudRunTime.TabIndex = 93;
            this.nudRunTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtAccountCloseTrade
            // 
            this.txtAccountCloseTrade.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtAccountCloseTrade.Location = new System.Drawing.Point(138, 48);
            this.txtAccountCloseTrade.Name = "txtAccountCloseTrade";
            this.txtAccountCloseTrade.Size = new System.Drawing.Size(144, 20);
            this.txtAccountCloseTrade.TabIndex = 94;
            this.txtAccountCloseTrade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAccountCloseTrade_KeyPress);
            // 
            // txtAccountOpenTrade
            // 
            this.txtAccountOpenTrade.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtAccountOpenTrade.Location = new System.Drawing.Point(477, 48);
            this.txtAccountOpenTrade.Name = "txtAccountOpenTrade";
            this.txtAccountOpenTrade.Size = new System.Drawing.Size(144, 20);
            this.txtAccountOpenTrade.TabIndex = 95;
            this.txtAccountOpenTrade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAccountOpenTrade_KeyPress);
            // 
            // ui_nbtnStart
            // 
            this.ui_nbtnStart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ui_nbtnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ui_nbtnStart.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_nbtnStart.Location = new System.Drawing.Point(974, 8);
            this.ui_nbtnStart.Name = "ui_nbtnStart";
            this.ui_nbtnStart.Size = new System.Drawing.Size(126, 23);
            this.ui_nbtnStart.TabIndex = 11;
            this.ui_nbtnStart.Text = "Start";
            this.ui_nbtnStart.UseVisualStyleBackColor = false;
            this.ui_nbtnStart.Click += new System.EventHandler(this.ui_nbtnStart_Click);
            // 
            // ui_nbtnStop
            // 
            this.ui_nbtnStop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ui_nbtnStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ui_nbtnStop.Enabled = false;
            this.ui_nbtnStop.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_nbtnStop.Location = new System.Drawing.Point(974, 47);
            this.ui_nbtnStop.Name = "ui_nbtnStop";
            this.ui_nbtnStop.Size = new System.Drawing.Size(126, 23);
            this.ui_nbtnStop.TabIndex = 12;
            this.ui_nbtnStop.Text = "Stop";
            this.ui_nbtnStop.UseVisualStyleBackColor = false;
            this.ui_nbtnStop.Click += new System.EventHandler(this.ui_nbtnStop_Click);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(965, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "ms";
            this.label5.Visible = false;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(413, 91);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 98;
            this.label9.Text = "Start Time:";
            // 
            // lblStartTime
            // 
            this.lblStartTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point(477, 91);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(55, 13);
            this.lblStartTime.TabIndex = 99;
            this.lblStartTime.Text = "Start Time";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(776, 91);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 13);
            this.label11.TabIndex = 100;
            this.label11.Text = "Time:";
            // 
            // lblEndTime
            // 
            this.lblEndTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Location = new System.Drawing.Point(815, 91);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(52, 13);
            this.lblEndTime.TabIndex = 101;
            this.lblEndTime.Text = "End Time";
            // 
            // frmOrderSimulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 614);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmOrderSimulator";
            this.Text = "Order Simulator";
            this.Title = "Order Simulator";
            this.Load += new System.EventHandler(this.frmOrderSimulator_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRunTime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        public Nevron.UI.WinForm.Controls.NButton ui_nbtnStart;
        public Nevron.UI.WinForm.Controls.NButton ui_nbtnStop;
        private System.Windows.Forms.ComboBox cmbProductType;
        private System.Windows.Forms.ComboBox cmbProduct;
        private System.Windows.Forms.ComboBox cmbContract;
        private System.Windows.Forms.NumericUpDown nudRunTime;
        private System.Windows.Forms.TextBox txtAccountCloseTrade;
        private System.Windows.Forms.TextBox txtAccountOpenTrade;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblOrderCount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSymbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOrderType;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSide;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAvgPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLTP;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLUT;
    }
}