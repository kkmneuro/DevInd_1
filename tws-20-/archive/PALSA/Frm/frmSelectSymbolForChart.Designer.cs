namespace PALSA.Frm
{
    partial class frmSelectSymbolForChart
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
            this.ui_ncmbProductType = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_ncmbProductName = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_ncmbContractName = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_ncmbExpiryDate = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_lblProductType = new System.Windows.Forms.Label();
            this.ui_lblProductName = new System.Windows.Forms.Label();
            this.ui_lblContractName = new System.Windows.Forms.Label();
            this.ui_lblExpiryDate = new System.Windows.Forms.Label();
            this.ui_lblPeriodicity = new System.Windows.Forms.Label();
            this.ui_ncmbPeriodicity = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_nbtnOk = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nbtnCancel = new Nevron.UI.WinForm.Controls.NButton();
            this.SuspendLayout();
            // 
            // ui_ncmbProductType
            // 
            this.ui_ncmbProductType.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbProductType.Location = new System.Drawing.Point(92, 15);
            this.ui_ncmbProductType.Name = "ui_ncmbProductType";
            this.ui_ncmbProductType.Size = new System.Drawing.Size(100, 20);
            this.ui_ncmbProductType.TabIndex = 0;
            this.ui_ncmbProductType.Text = "nComboBox1";
            this.ui_ncmbProductType.SelectedIndexChanged += new System.EventHandler(this.ui_ncmbProductType_SelectedIndexChanged);
            // 
            // ui_ncmbProductName
            // 
            this.ui_ncmbProductName.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbProductName.Location = new System.Drawing.Point(280, 15);
            this.ui_ncmbProductName.Name = "ui_ncmbProductName";
            this.ui_ncmbProductName.Size = new System.Drawing.Size(100, 20);
            this.ui_ncmbProductName.TabIndex = 1;
            this.ui_ncmbProductName.Text = "nComboBox2";
            this.ui_ncmbProductName.SelectedIndexChanged += new System.EventHandler(this.ui_ncmbProductName_SelectedIndexChanged);
            // 
            // ui_ncmbContractName
            // 
            this.ui_ncmbContractName.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbContractName.Location = new System.Drawing.Point(475, 15);
            this.ui_ncmbContractName.Name = "ui_ncmbContractName";
            this.ui_ncmbContractName.Size = new System.Drawing.Size(100, 20);
            this.ui_ncmbContractName.TabIndex = 2;
            this.ui_ncmbContractName.Text = "nComboBox3";
            this.ui_ncmbContractName.SelectedIndexChanged += new System.EventHandler(this.ui_ncmbContractName_SelectedIndexChanged);
            // 
            // ui_ncmbExpiryDate
            // 
            this.ui_ncmbExpiryDate.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbExpiryDate.Location = new System.Drawing.Point(651, 15);
            this.ui_ncmbExpiryDate.Name = "ui_ncmbExpiryDate";
            this.ui_ncmbExpiryDate.Size = new System.Drawing.Size(100, 20);
            this.ui_ncmbExpiryDate.TabIndex = 3;
            this.ui_ncmbExpiryDate.Text = "nComboBox4";
            // 
            // ui_lblProductType
            // 
            this.ui_lblProductType.AutoSize = true;
            this.ui_lblProductType.Location = new System.Drawing.Point(13, 19);
            this.ui_lblProductType.Name = "ui_lblProductType";
            this.ui_lblProductType.Size = new System.Drawing.Size(77, 13);
            this.ui_lblProductType.TabIndex = 4;
            this.ui_lblProductType.Text = "Product Type :";
            // 
            // ui_lblProductName
            // 
            this.ui_lblProductName.AutoSize = true;
            this.ui_lblProductName.Location = new System.Drawing.Point(199, 19);
            this.ui_lblProductName.Name = "ui_lblProductName";
            this.ui_lblProductName.Size = new System.Drawing.Size(81, 13);
            this.ui_lblProductName.TabIndex = 5;
            this.ui_lblProductName.Text = "Product Name :";
            // 
            // ui_lblContractName
            // 
            this.ui_lblContractName.AutoSize = true;
            this.ui_lblContractName.Location = new System.Drawing.Point(388, 19);
            this.ui_lblContractName.Name = "ui_lblContractName";
            this.ui_lblContractName.Size = new System.Drawing.Size(84, 13);
            this.ui_lblContractName.TabIndex = 6;
            this.ui_lblContractName.Text = "Contract Name :";
            // 
            // ui_lblExpiryDate
            // 
            this.ui_lblExpiryDate.AutoSize = true;
            this.ui_lblExpiryDate.Location = new System.Drawing.Point(582, 19);
            this.ui_lblExpiryDate.Name = "ui_lblExpiryDate";
            this.ui_lblExpiryDate.Size = new System.Drawing.Size(67, 13);
            this.ui_lblExpiryDate.TabIndex = 7;
            this.ui_lblExpiryDate.Text = "Expiry Date :";
            // 
            // ui_lblPeriodicity
            // 
            this.ui_lblPeriodicity.AutoSize = true;
            this.ui_lblPeriodicity.Location = new System.Drawing.Point(29, 59);
            this.ui_lblPeriodicity.Name = "ui_lblPeriodicity";
            this.ui_lblPeriodicity.Size = new System.Drawing.Size(61, 13);
            this.ui_lblPeriodicity.TabIndex = 32;
            this.ui_lblPeriodicity.Text = "Periodicity :";
            // 
            // ui_ncmbPeriodicity
            // 
            this.ui_ncmbPeriodicity.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("1 Minute", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("5 Minutes", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("15 Minutes", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("30 Minutes", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("1 Hour", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("4 Hours", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("Daily", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("Weekly", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("Monthly", -1, false, 0, new System.Drawing.Size(0, 0))});
            this.ui_ncmbPeriodicity.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbPeriodicity.Location = new System.Drawing.Point(92, 55);
            this.ui_ncmbPeriodicity.Name = "ui_ncmbPeriodicity";
            this.ui_ncmbPeriodicity.Size = new System.Drawing.Size(100, 20);
            this.ui_ncmbPeriodicity.TabIndex = 31;
            // 
            // ui_nbtnOk
            // 
            this.ui_nbtnOk.Location = new System.Drawing.Point(585, 55);
            this.ui_nbtnOk.Name = "ui_nbtnOk";
            this.ui_nbtnOk.Size = new System.Drawing.Size(75, 20);
            this.ui_nbtnOk.TabIndex = 33;
            this.ui_nbtnOk.Text = "&Ok";
            this.ui_nbtnOk.UseVisualStyleBackColor = false;
            this.ui_nbtnOk.Click += new System.EventHandler(this.ui_nbtnOk_Click);
            // 
            // ui_nbtnCancel
            // 
            this.ui_nbtnCancel.Location = new System.Drawing.Point(676, 55);
            this.ui_nbtnCancel.Name = "ui_nbtnCancel";
            this.ui_nbtnCancel.Size = new System.Drawing.Size(75, 20);
            this.ui_nbtnCancel.TabIndex = 34;
            this.ui_nbtnCancel.Text = "&Cancel";
            this.ui_nbtnCancel.UseVisualStyleBackColor = false;
            this.ui_nbtnCancel.Click += new System.EventHandler(this.ui_nbtnCancel_Click);
            // 
            // frmSelectSymbolForChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 84);
            this.Controls.Add(this.ui_nbtnCancel);
            this.Controls.Add(this.ui_nbtnOk);
            this.Controls.Add(this.ui_lblPeriodicity);
            this.Controls.Add(this.ui_ncmbPeriodicity);
            this.Controls.Add(this.ui_lblExpiryDate);
            this.Controls.Add(this.ui_lblContractName);
            this.Controls.Add(this.ui_lblProductName);
            this.Controls.Add(this.ui_lblProductType);
            this.Controls.Add(this.ui_ncmbExpiryDate);
            this.Controls.Add(this.ui_ncmbContractName);
            this.Controls.Add(this.ui_ncmbProductName);
            this.Controls.Add(this.ui_ncmbProductType);
            this.Name = "frmSelectSymbolForChart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmSelectSymbolForChart";
            this.Title = "frmSelectSymbolForChart";
            this.Load += new System.EventHandler(this.frmSelectSymbolForChart_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbProductType;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbProductName;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbContractName;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbExpiryDate;
        private System.Windows.Forms.Label ui_lblProductType;
        private System.Windows.Forms.Label ui_lblProductName;
        private System.Windows.Forms.Label ui_lblContractName;
        private System.Windows.Forms.Label ui_lblExpiryDate;
        internal System.Windows.Forms.Label ui_lblPeriodicity;
        internal Nevron.UI.WinForm.Controls.NComboBox ui_ncmbPeriodicity;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnOk;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnCancel;
    }
}