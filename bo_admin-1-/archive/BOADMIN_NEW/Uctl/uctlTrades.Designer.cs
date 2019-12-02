namespace BOADMIN_NEW.Uctl
{
    partial class uctlTrades
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
            this.ui_ncmbFilling = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_lblFilling = new System.Windows.Forms.Label();
            this.ui_nnudTriggerPrice = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.ui_nnudOrderPrice = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.ui_ndtpTime = new Nevron.UI.WinForm.Controls.NDateTimePicker();
            this.ui_ndtpValidity = new Nevron.UI.WinForm.Controls.NDateTimePicker();
            this.ui_ncmbType = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_ncmbSymbol = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_btnUpdate = new Nevron.UI.WinForm.Controls.NButton();
            this.nLineControl1 = new Nevron.UI.WinForm.Controls.NLineControl();
            this.ui_btn_cancel = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_btn_restore = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_lblAccountID = new System.Windows.Forms.Label();
            this.ui_lbl_comment = new System.Windows.Forms.Label();
            this.ui_lblTime = new System.Windows.Forms.Label();
            this.lbl_type = new System.Windows.Forms.Label();
            this.ui_lblStatus = new System.Windows.Forms.Label();
            this.lbl_symbol = new System.Windows.Forms.Label();
            this.ui_lblQuantity = new System.Windows.Forms.Label();
            this.ui_lblOrderPrice = new System.Windows.Forms.Label();
            this.lbl_close_price = new System.Windows.Forms.Label();
            this.ui_lblValidity = new System.Windows.Forms.Label();
            this.ui_ntxtStatus = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_ntxtQuantity = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_ntxtComment = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_ntxtAccountID = new Nevron.UI.WinForm.Controls.NTextBox();
            this.nuiPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nnudTriggerPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nnudOrderPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // nuiPanel1
            // 
            this.nuiPanel1.BackColor = System.Drawing.Color.Transparent;
            this.nuiPanel1.Controls.Add(this.ui_ncmbFilling);
            this.nuiPanel1.Controls.Add(this.ui_lblFilling);
            this.nuiPanel1.Controls.Add(this.ui_nnudTriggerPrice);
            this.nuiPanel1.Controls.Add(this.ui_nnudOrderPrice);
            this.nuiPanel1.Controls.Add(this.ui_ndtpTime);
            this.nuiPanel1.Controls.Add(this.ui_ndtpValidity);
            this.nuiPanel1.Controls.Add(this.ui_ncmbType);
            this.nuiPanel1.Controls.Add(this.ui_ncmbSymbol);
            this.nuiPanel1.Controls.Add(this.ui_btnUpdate);
            this.nuiPanel1.Controls.Add(this.nLineControl1);
            this.nuiPanel1.Controls.Add(this.ui_btn_cancel);
            this.nuiPanel1.Controls.Add(this.ui_btn_restore);
            this.nuiPanel1.Controls.Add(this.ui_lblAccountID);
            this.nuiPanel1.Controls.Add(this.ui_lbl_comment);
            this.nuiPanel1.Controls.Add(this.ui_lblTime);
            this.nuiPanel1.Controls.Add(this.lbl_type);
            this.nuiPanel1.Controls.Add(this.ui_lblStatus);
            this.nuiPanel1.Controls.Add(this.lbl_symbol);
            this.nuiPanel1.Controls.Add(this.ui_lblQuantity);
            this.nuiPanel1.Controls.Add(this.ui_lblOrderPrice);
            this.nuiPanel1.Controls.Add(this.lbl_close_price);
            this.nuiPanel1.Controls.Add(this.ui_lblValidity);
            this.nuiPanel1.Controls.Add(this.ui_ntxtStatus);
            this.nuiPanel1.Controls.Add(this.ui_ntxtQuantity);
            this.nuiPanel1.Controls.Add(this.ui_ntxtComment);
            this.nuiPanel1.Controls.Add(this.ui_ntxtAccountID);
            this.nuiPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nuiPanel1.Location = new System.Drawing.Point(0, 0);
            this.nuiPanel1.Name = "nuiPanel1";
            this.nuiPanel1.Size = new System.Drawing.Size(610, 196);
            this.nuiPanel1.TabIndex = 2;
            this.nuiPanel1.Text = "nuiPanel1";
            // 
            // ui_ncmbFilling
            // 
            this.ui_ncmbFilling.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_ncmbFilling.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbFilling.Location = new System.Drawing.Point(489, 42);
            this.ui_ncmbFilling.Name = "ui_ncmbFilling";
            this.ui_ncmbFilling.Size = new System.Drawing.Size(100, 18);
            this.ui_ncmbFilling.TabIndex = 5;
            this.ui_ncmbFilling.TooltipInfo.ContentText = "Select Order Type";
            this.ui_ncmbFilling.TooltipInfo.InitialDelay = 300;
            // 
            // ui_lblFilling
            // 
            this.ui_lblFilling.AutoSize = true;
            this.ui_lblFilling.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblFilling.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_lblFilling.Location = new System.Drawing.Point(404, 45);
            this.ui_lblFilling.Name = "ui_lblFilling";
            this.ui_lblFilling.Size = new System.Drawing.Size(81, 13);
            this.ui_lblFilling.TabIndex = 77;
            this.ui_lblFilling.Text = "Order Type :";
            // 
            // ui_nnudTriggerPrice
            // 
            this.ui_nnudTriggerPrice.DecimalPlaces = 4;
            this.ui_nnudTriggerPrice.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_nnudTriggerPrice.Increment = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.ui_nnudTriggerPrice.Location = new System.Drawing.Point(291, 69);
            this.ui_nnudTriggerPrice.Name = "ui_nnudTriggerPrice";
            this.ui_nnudTriggerPrice.Size = new System.Drawing.Size(100, 20);
            this.ui_nnudTriggerPrice.TabIndex = 7;
            // 
            // ui_nnudOrderPrice
            // 
            this.ui_nnudOrderPrice.DecimalPlaces = 4;
            this.ui_nnudOrderPrice.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_nnudOrderPrice.Increment = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.ui_nnudOrderPrice.Location = new System.Drawing.Point(95, 69);
            this.ui_nnudOrderPrice.Name = "ui_nnudOrderPrice";
            this.ui_nnudOrderPrice.Size = new System.Drawing.Size(100, 20);
            this.ui_nnudOrderPrice.TabIndex = 6;
            // 
            // ui_ndtpTime
            // 
            this.ui_ndtpTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ui_ndtpTime.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ui_ndtpTime.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.ui_ndtpTime.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.ui_ndtpTime.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.ui_ndtpTime.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.ui_ndtpTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.ui_ndtpTime.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_ndtpTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ui_ndtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ui_ndtpTime.Location = new System.Drawing.Point(291, 13);
            this.ui_ndtpTime.Name = "ui_ndtpTime";
            this.ui_ndtpTime.Size = new System.Drawing.Size(100, 22);
            this.ui_ndtpTime.TabIndex = 1;
            // 
            // ui_ndtpValidity
            // 
            this.ui_ndtpValidity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ui_ndtpValidity.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ui_ndtpValidity.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.ui_ndtpValidity.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.ui_ndtpValidity.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.ui_ndtpValidity.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.ui_ndtpValidity.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.ui_ndtpValidity.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_ndtpValidity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ui_ndtpValidity.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ui_ndtpValidity.Location = new System.Drawing.Point(95, 97);
            this.ui_ndtpValidity.Name = "ui_ndtpValidity";
            this.ui_ndtpValidity.Size = new System.Drawing.Size(100, 22);
            this.ui_ndtpValidity.TabIndex = 9;
            // 
            // ui_ncmbType
            // 
            this.ui_ncmbType.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_ncmbType.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbType.Location = new System.Drawing.Point(489, 15);
            this.ui_ncmbType.Name = "ui_ncmbType";
            this.ui_ncmbType.Size = new System.Drawing.Size(100, 18);
            this.ui_ncmbType.TabIndex = 2;
            this.ui_ncmbType.TooltipInfo.ContentText = "Select Order Type";
            this.ui_ncmbType.TooltipInfo.InitialDelay = 300;
            // 
            // ui_ncmbSymbol
            // 
            this.ui_ncmbSymbol.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_ncmbSymbol.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbSymbol.Location = new System.Drawing.Point(291, 42);
            this.ui_ncmbSymbol.Name = "ui_ncmbSymbol";
            this.ui_ncmbSymbol.Size = new System.Drawing.Size(100, 18);
            this.ui_ncmbSymbol.TabIndex = 4;
            this.ui_ncmbSymbol.TooltipInfo.ContentText = "Select Symbol Type";
            this.ui_ncmbSymbol.TooltipInfo.InitialDelay = 300;
            // 
            // ui_btnUpdate
            // 
            this.ui_btnUpdate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_btnUpdate.Location = new System.Drawing.Point(299, 149);
            this.ui_btnUpdate.Name = "ui_btnUpdate";
            this.ui_btnUpdate.Size = new System.Drawing.Size(90, 23);
            this.ui_btnUpdate.TabIndex = 11;
            this.ui_btnUpdate.Text = "&Update";
            this.ui_btnUpdate.UseVisualStyleBackColor = false;
            this.ui_btnUpdate.Visible = false;
            // 
            // nLineControl1
            // 
            this.nLineControl1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nLineControl1.Location = new System.Drawing.Point(8, 138);
            this.nLineControl1.Name = "nLineControl1";
            this.nLineControl1.Size = new System.Drawing.Size(581, 2);
            this.nLineControl1.Text = "nLineControl1";
            // 
            // ui_btn_cancel
            // 
            this.ui_btn_cancel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_btn_cancel.Location = new System.Drawing.Point(499, 149);
            this.ui_btn_cancel.Name = "ui_btn_cancel";
            this.ui_btn_cancel.Size = new System.Drawing.Size(90, 23);
            this.ui_btn_cancel.TabIndex = 13;
            this.ui_btn_cancel.Text = "&Close";
            this.ui_btn_cancel.UseVisualStyleBackColor = false;
            this.ui_btn_cancel.Click += new System.EventHandler(this.ui_btn_cancel_Click_1);
            // 
            // ui_btn_restore
            // 
            this.ui_btn_restore.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_btn_restore.Location = new System.Drawing.Point(399, 149);
            this.ui_btn_restore.Name = "ui_btn_restore";
            this.ui_btn_restore.Size = new System.Drawing.Size(90, 23);
            this.ui_btn_restore.TabIndex = 12;
            this.ui_btn_restore.Text = "&Restore";
            this.ui_btn_restore.UseVisualStyleBackColor = false;
            this.ui_btn_restore.Visible = false;
            // 
            // ui_lblAccountID
            // 
            this.ui_lblAccountID.AutoSize = true;
            this.ui_lblAccountID.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblAccountID.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_lblAccountID.Location = new System.Drawing.Point(12, 18);
            this.ui_lblAccountID.Name = "ui_lblAccountID";
            this.ui_lblAccountID.Size = new System.Drawing.Size(79, 13);
            this.ui_lblAccountID.TabIndex = 42;
            this.ui_lblAccountID.Text = "Account ID :";
            // 
            // ui_lbl_comment
            // 
            this.ui_lbl_comment.AutoSize = true;
            this.ui_lbl_comment.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_lbl_comment.Location = new System.Drawing.Point(221, 102);
            this.ui_lbl_comment.Name = "ui_lbl_comment";
            this.ui_lbl_comment.Size = new System.Drawing.Size(68, 13);
            this.ui_lbl_comment.TabIndex = 41;
            this.ui_lbl_comment.Text = "Comment:";
            // 
            // ui_lblTime
            // 
            this.ui_lblTime.AutoSize = true;
            this.ui_lblTime.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblTime.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_lblTime.Location = new System.Drawing.Point(249, 18);
            this.ui_lblTime.Name = "ui_lblTime";
            this.ui_lblTime.Size = new System.Drawing.Size(40, 13);
            this.ui_lblTime.TabIndex = 37;
            this.ui_lblTime.Text = "Time:";
            // 
            // lbl_type
            // 
            this.lbl_type.AutoSize = true;
            this.lbl_type.BackColor = System.Drawing.Color.Transparent;
            this.lbl_type.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_type.Location = new System.Drawing.Point(445, 18);
            this.lbl_type.Name = "lbl_type";
            this.lbl_type.Size = new System.Drawing.Size(40, 13);
            this.lbl_type.TabIndex = 36;
            this.lbl_type.Text = "Type:";
            // 
            // ui_lblStatus
            // 
            this.ui_lblStatus.AutoSize = true;
            this.ui_lblStatus.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_lblStatus.Location = new System.Drawing.Point(433, 73);
            this.ui_lblStatus.Name = "ui_lblStatus";
            this.ui_lblStatus.Size = new System.Drawing.Size(52, 13);
            this.ui_lblStatus.TabIndex = 33;
            this.ui_lblStatus.Text = "Status :";
            // 
            // lbl_symbol
            // 
            this.lbl_symbol.AutoSize = true;
            this.lbl_symbol.BackColor = System.Drawing.Color.Transparent;
            this.lbl_symbol.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_symbol.Location = new System.Drawing.Point(234, 45);
            this.lbl_symbol.Name = "lbl_symbol";
            this.lbl_symbol.Size = new System.Drawing.Size(55, 13);
            this.lbl_symbol.TabIndex = 29;
            this.lbl_symbol.Text = "Symbol:";
            // 
            // ui_lblQuantity
            // 
            this.ui_lblQuantity.AutoSize = true;
            this.ui_lblQuantity.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblQuantity.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_lblQuantity.Location = new System.Drawing.Point(27, 45);
            this.ui_lblQuantity.Name = "ui_lblQuantity";
            this.ui_lblQuantity.Size = new System.Drawing.Size(64, 13);
            this.ui_lblQuantity.TabIndex = 28;
            this.ui_lblQuantity.Text = "Quantity :";
            // 
            // ui_lblOrderPrice
            // 
            this.ui_lblOrderPrice.AutoSize = true;
            this.ui_lblOrderPrice.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblOrderPrice.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_lblOrderPrice.Location = new System.Drawing.Point(10, 73);
            this.ui_lblOrderPrice.Name = "ui_lblOrderPrice";
            this.ui_lblOrderPrice.Size = new System.Drawing.Size(81, 13);
            this.ui_lblOrderPrice.TabIndex = 27;
            this.ui_lblOrderPrice.Text = "Order Price :";
            // 
            // lbl_close_price
            // 
            this.lbl_close_price.AutoSize = true;
            this.lbl_close_price.BackColor = System.Drawing.Color.Transparent;
            this.lbl_close_price.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_close_price.Location = new System.Drawing.Point(200, 73);
            this.lbl_close_price.Name = "lbl_close_price";
            this.lbl_close_price.Size = new System.Drawing.Size(89, 13);
            this.lbl_close_price.TabIndex = 26;
            this.lbl_close_price.Text = "Trigger Price :";
            // 
            // ui_lblValidity
            // 
            this.ui_lblValidity.AutoSize = true;
            this.ui_lblValidity.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblValidity.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_lblValidity.Location = new System.Drawing.Point(33, 102);
            this.ui_lblValidity.Name = "ui_lblValidity";
            this.ui_lblValidity.Size = new System.Drawing.Size(58, 13);
            this.ui_lblValidity.TabIndex = 23;
            this.ui_lblValidity.Text = "Validity :";
            // 
            // ui_ntxtStatus
            // 
            this.ui_ntxtStatus.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_ntxtStatus.Location = new System.Drawing.Point(489, 70);
            this.ui_ntxtStatus.Name = "ui_ntxtStatus";
            this.ui_ntxtStatus.Size = new System.Drawing.Size(100, 19);
            this.ui_ntxtStatus.TabIndex = 8;
            // 
            // ui_ntxtQuantity
            // 
            this.ui_ntxtQuantity.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_ntxtQuantity.Location = new System.Drawing.Point(95, 42);
            this.ui_ntxtQuantity.Name = "ui_ntxtQuantity";
            this.ui_ntxtQuantity.Size = new System.Drawing.Size(100, 19);
            this.ui_ntxtQuantity.TabIndex = 3;
            // 
            // ui_ntxtComment
            // 
            this.ui_ntxtComment.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_ntxtComment.Location = new System.Drawing.Point(291, 99);
            this.ui_ntxtComment.Name = "ui_ntxtComment";
            this.ui_ntxtComment.Size = new System.Drawing.Size(298, 19);
            this.ui_ntxtComment.TabIndex = 10;
            // 
            // ui_ntxtAccountID
            // 
            this.ui_ntxtAccountID.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_ntxtAccountID.Location = new System.Drawing.Point(95, 15);
            this.ui_ntxtAccountID.Name = "ui_ntxtAccountID";
            this.ui_ntxtAccountID.ReadOnly = true;
            this.ui_ntxtAccountID.Size = new System.Drawing.Size(100, 19);
            this.ui_ntxtAccountID.TabIndex = 0;
            this.ui_ntxtAccountID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ui_ntxtAccountID_KeyPress);
            // 
            // uctlTrades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nuiPanel1);
            this.Name = "uctlTrades";
            this.Size = new System.Drawing.Size(610, 196);
            this.nuiPanel1.ResumeLayout(false);
            this.nuiPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nnudTriggerPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nnudOrderPrice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NUIPanel nuiPanel1;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbFilling;
        private System.Windows.Forms.Label ui_lblFilling;
        private Nevron.UI.WinForm.Controls.NNumericUpDown ui_nnudTriggerPrice;
        private Nevron.UI.WinForm.Controls.NNumericUpDown ui_nnudOrderPrice;
        private Nevron.UI.WinForm.Controls.NDateTimePicker ui_ndtpTime;
        private Nevron.UI.WinForm.Controls.NDateTimePicker ui_ndtpValidity;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbType;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbSymbol;
        private Nevron.UI.WinForm.Controls.NButton ui_btnUpdate;
        private Nevron.UI.WinForm.Controls.NLineControl nLineControl1;
        private Nevron.UI.WinForm.Controls.NButton ui_btn_cancel;
        private Nevron.UI.WinForm.Controls.NButton ui_btn_restore;
        private System.Windows.Forms.Label ui_lblAccountID;
        private System.Windows.Forms.Label ui_lbl_comment;
        private System.Windows.Forms.Label ui_lblTime;
        private System.Windows.Forms.Label lbl_type;
        private System.Windows.Forms.Label ui_lblStatus;
        private System.Windows.Forms.Label lbl_symbol;
        private System.Windows.Forms.Label ui_lblQuantity;
        private System.Windows.Forms.Label ui_lblOrderPrice;
        private System.Windows.Forms.Label lbl_close_price;
        private System.Windows.Forms.Label ui_lblValidity;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtStatus;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtQuantity;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtComment;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtAccountID;
    }
}
