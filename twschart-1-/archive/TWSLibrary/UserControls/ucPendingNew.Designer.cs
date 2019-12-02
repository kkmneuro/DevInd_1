namespace CommonLibrary.UserControls
{
    partial class ucPendingNew
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
            this.btnPlace = new System.Windows.Forms.Button();
            this.lblPendingInfo = new System.Windows.Forms.Label();
            this.dtpickerGTD = new System.Windows.Forms.DateTimePicker();
            this.cmbTIF = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPrice = new System.Windows.Forms.NumericUpDown();
            this.label19 = new System.Windows.Forms.Label();
            this.cmbSide = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPlace
            // 
            this.btnPlace.BackColor = System.Drawing.Color.White;
            this.btnPlace.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlace.Location = new System.Drawing.Point(206, 69);
            this.btnPlace.Name = "btnPlace";
            this.btnPlace.Size = new System.Drawing.Size(173, 23);
            this.btnPlace.TabIndex = 59;
            this.btnPlace.Text = "Place";
            this.btnPlace.UseVisualStyleBackColor = false;
            this.btnPlace.Click += new System.EventHandler(this.btnPlace_Click);
            // 
            // lblPendingInfo
            // 
            this.lblPendingInfo.AutoSize = true;
            this.lblPendingInfo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPendingInfo.Location = new System.Drawing.Point(31, 172);
            this.lblPendingInfo.Name = "lblPendingInfo";
            this.lblPendingInfo.Size = new System.Drawing.Size(325, 13);
            this.lblPendingInfo.TabIndex = 57;
            this.lblPendingInfo.Text = "Open price you set must differ from market price by at least 4 pips";
            // 
            // dtpickerGTD
            // 
            this.dtpickerGTD.Location = new System.Drawing.Point(206, 116);
            this.dtpickerGTD.Name = "dtpickerGTD";
            this.dtpickerGTD.Size = new System.Drawing.Size(173, 20);
            this.dtpickerGTD.TabIndex = 56;
            this.dtpickerGTD.Visible = false;
            this.dtpickerGTD.ValueChanged += new System.EventHandler(this.dtpickerGTD_ValueChanged);
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
            this.cmbTIF.Location = new System.Drawing.Point(88, 116);
            this.cmbTIF.Name = "cmbTIF";
            this.cmbTIF.Size = new System.Drawing.Size(92, 21);
            this.cmbTIF.TabIndex = 55;
            this.cmbTIF.SelectedIndexChanged += new System.EventHandler(this.cmbTIF_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Location = new System.Drawing.Point(15, 116);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(72, 13);
            this.label17.TabIndex = 54;
            this.label17.Text = "Time In Force";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(15, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 52;
            this.label1.Text = "Type:";
            // 
            // cmbPrice
            // 
            this.cmbPrice.Location = new System.Drawing.Point(88, 72);
            this.cmbPrice.Name = "cmbPrice";
            this.cmbPrice.Size = new System.Drawing.Size(92, 20);
            this.cmbPrice.TabIndex = 49;
            this.cmbPrice.ValueChanged += new System.EventHandler(this.cmbPrice_ValueChanged);
            this.cmbPrice.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cmbPrice_MouseDown);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Location = new System.Drawing.Point(15, 72);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(34, 13);
            this.label19.TabIndex = 48;
            this.label19.Text = "Price:";
            // 
            // cmbSide
            // 
            this.cmbSide.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSide.FormattingEnabled = true;
            this.cmbSide.Items.AddRange(new object[] {
            "Buy Limit",
            "Buy Stop",
            "Sell Limit",
            "Sell Stop"});
            this.cmbSide.Location = new System.Drawing.Point(88, 20);
            this.cmbSide.Name = "cmbSide";
            this.cmbSide.Size = new System.Drawing.Size(92, 21);
            this.cmbSide.TabIndex = 60;
            this.cmbSide.SelectedIndexChanged += new System.EventHandler(this.cmbSide_SelectedIndexChanged);
            // 
            // ucPendingNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.cmbSide);
            this.Controls.Add(this.btnPlace);
            this.Controls.Add(this.lblPendingInfo);
            this.Controls.Add(this.dtpickerGTD);
            this.Controls.Add(this.cmbTIF);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbPrice);
            this.Controls.Add(this.label19);
            this.Name = "ucPendingNew";
            this.Size = new System.Drawing.Size(394, 254);
            ((System.ComponentModel.ISupportInitialize)(this.cmbPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPlace;
        private System.Windows.Forms.Label lblPendingInfo;
        private System.Windows.Forms.DateTimePicker dtpickerGTD;
        private System.Windows.Forms.ComboBox cmbTIF;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown cmbPrice;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cmbSide;

    }
}
