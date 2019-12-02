namespace CommonLibrary.UserControls
{
    partial class ucModifyPending
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
            this.cmbSLValue = new System.Windows.Forms.NumericUpDown();
            this.label19 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.cmbTPValue = new System.Windows.Forms.NumericUpDown();
            this.cmbPrice = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTIF = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.dtpickerGTD = new System.Windows.Forms.DateTimePicker();
            this.lblPendingInfo = new System.Windows.Forms.Label();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSLValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTPValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbSLValue
            // 
            this.cmbSLValue.Location = new System.Drawing.Point(87, 71);
            this.cmbSLValue.Name = "cmbSLValue";
            this.cmbSLValue.Size = new System.Drawing.Size(92, 20);
            this.cmbSLValue.TabIndex = 37;
            this.cmbSLValue.ValueChanged += new System.EventHandler(this.cmbSLValue_ValueChanged);
            this.cmbSLValue.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cmbSLValue_MouseDown);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Location = new System.Drawing.Point(14, 71);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(63, 13);
            this.label19.TabIndex = 36;
            this.label19.Text = "Stop Loss : ";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.Location = new System.Drawing.Point(205, 71);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(68, 13);
            this.label24.TabIndex = 38;
            this.label24.Text = "Take Profit : ";
            // 
            // cmbTPValue
            // 
            this.cmbTPValue.Location = new System.Drawing.Point(286, 71);
            this.cmbTPValue.Name = "cmbTPValue";
            this.cmbTPValue.Size = new System.Drawing.Size(92, 20);
            this.cmbTPValue.TabIndex = 39;
            this.cmbTPValue.ValueChanged += new System.EventHandler(this.cmbTPValue_ValueChanged);
            this.cmbTPValue.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cmbTPValue_MouseDown);
            // 
            // cmbPrice
            // 
            this.cmbPrice.Location = new System.Drawing.Point(87, 27);
            this.cmbPrice.Name = "cmbPrice";
            this.cmbPrice.Size = new System.Drawing.Size(92, 20);
            this.cmbPrice.TabIndex = 41;
            this.cmbPrice.ValueChanged += new System.EventHandler(this.cmbPrice_ValueChanged);
            this.cmbPrice.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cmbPrice_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(14, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "Price:";
            // 
            // cmbTIF
            // 
            this.cmbTIF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTIF.FormattingEnabled = true;
            this.cmbTIF.Items.AddRange(new object[] {
            "Disable",
            "GTC",
            "DAY",
            "GTD"});
            this.cmbTIF.Location = new System.Drawing.Point(87, 115);
            this.cmbTIF.Name = "cmbTIF";
            this.cmbTIF.Size = new System.Drawing.Size(92, 21);
            this.cmbTIF.TabIndex = 43;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Location = new System.Drawing.Point(14, 115);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(72, 13);
            this.label17.TabIndex = 42;
            this.label17.Text = "Time In Force";
            // 
            // dtpickerGTD
            // 
            this.dtpickerGTD.Location = new System.Drawing.Point(205, 115);
            this.dtpickerGTD.Name = "dtpickerGTD";
            this.dtpickerGTD.Size = new System.Drawing.Size(173, 20);
            this.dtpickerGTD.TabIndex = 44;
            this.dtpickerGTD.Visible = false;
            // 
            // lblPendingInfo
            // 
            this.lblPendingInfo.AutoSize = true;
            this.lblPendingInfo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPendingInfo.Location = new System.Drawing.Point(35, 213);
            this.lblPendingInfo.Name = "lblPendingInfo";
            this.lblPendingInfo.Size = new System.Drawing.Size(325, 13);
            this.lblPendingInfo.TabIndex = 45;
            this.lblPendingInfo.Text = "Open price you set must differ from market price by at least 4 pips";
            // 
            // btnModify
            // 
            this.btnModify.BackColor = System.Drawing.Color.White;
            this.btnModify.Enabled = false;
            this.btnModify.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModify.Location = new System.Drawing.Point(14, 159);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(131, 23);
            this.btnModify.TabIndex = 46;
            this.btnModify.Text = "Modify";
            this.btnModify.UseVisualStyleBackColor = false;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(251, 163);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(127, 23);
            this.btnCancel.TabIndex = 47;
            this.btnCancel.Text = "Delete";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ucModifyPending
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.lblPendingInfo);
            this.Controls.Add(this.dtpickerGTD);
            this.Controls.Add(this.cmbTIF);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.cmbPrice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.cmbTPValue);
            this.Controls.Add(this.cmbSLValue);
            this.Controls.Add(this.label19);
            this.Name = "ucModifyPending";
            this.Size = new System.Drawing.Size(394, 254);
            ((System.ComponentModel.ISupportInitialize)(this.cmbSLValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTPValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown cmbSLValue;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.NumericUpDown cmbTPValue;
        private System.Windows.Forms.NumericUpDown cmbPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTIF;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DateTimePicker dtpickerGTD;
        private System.Windows.Forms.Label lblPendingInfo;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnCancel;
    }
}
