namespace BOADMIN_NEW.Uctl
{
    partial class uctlTaxMaster
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
            this.ui_npnlTaxMaster = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.ui_ntxtTaxName = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_ntxtTaxPercent = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_ncmbAmount = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_lblAmount = new System.Windows.Forms.Label();
            this.ui_nLineControl = new Nevron.UI.WinForm.Controls.NLineControl();
            this.ui_nbtnCancel = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nbtnOK = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_ntxtDescription = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_lblDescription = new System.Windows.Forms.Label();
            this.ui_lblTaxPercent = new System.Windows.Forms.Label();
            this.ui_lblTaxName = new System.Windows.Forms.Label();
            this.ui_npnlTaxMaster.SuspendLayout();
            this.SuspendLayout();
            // 
            // ui_npnlTaxMaster
            // 
            this.ui_npnlTaxMaster.Controls.Add(this.ui_ntxtTaxName);
            this.ui_npnlTaxMaster.Controls.Add(this.ui_ntxtTaxPercent);
            this.ui_npnlTaxMaster.Controls.Add(this.ui_ncmbAmount);
            this.ui_npnlTaxMaster.Controls.Add(this.ui_lblAmount);
            this.ui_npnlTaxMaster.Controls.Add(this.ui_nLineControl);
            this.ui_npnlTaxMaster.Controls.Add(this.ui_nbtnCancel);
            this.ui_npnlTaxMaster.Controls.Add(this.ui_nbtnOK);
            this.ui_npnlTaxMaster.Controls.Add(this.ui_ntxtDescription);
            this.ui_npnlTaxMaster.Controls.Add(this.ui_lblDescription);
            this.ui_npnlTaxMaster.Controls.Add(this.ui_lblTaxPercent);
            this.ui_npnlTaxMaster.Controls.Add(this.ui_lblTaxName);
            this.ui_npnlTaxMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_npnlTaxMaster.Location = new System.Drawing.Point(0, 0);
            this.ui_npnlTaxMaster.Name = "ui_npnlTaxMaster";
            this.ui_npnlTaxMaster.Size = new System.Drawing.Size(359, 199);
            this.ui_npnlTaxMaster.TabIndex = 0;
            this.ui_npnlTaxMaster.Text = "nuiPanel1";
            // 
            // ui_ntxtTaxName
            // 
            this.ui_ntxtTaxName.Location = new System.Drawing.Point(88, 19);
            this.ui_ntxtTaxName.MaxLength = 10;
            this.ui_ntxtTaxName.Multiline = true;
            this.ui_ntxtTaxName.Name = "ui_ntxtTaxName";
            this.ui_ntxtTaxName.Size = new System.Drawing.Size(256, 22);
            this.ui_ntxtTaxName.TabIndex = 0;
            // 
            // ui_ntxtTaxPercent
            // 
            this.ui_ntxtTaxPercent.Location = new System.Drawing.Point(88, 49);
            this.ui_ntxtTaxPercent.MaxLength = 10;
            this.ui_ntxtTaxPercent.Multiline = true;
            this.ui_ntxtTaxPercent.Name = "ui_ntxtTaxPercent";
            this.ui_ntxtTaxPercent.Size = new System.Drawing.Size(256, 22);
            this.ui_ntxtTaxPercent.TabIndex = 1;
            this.ui_ntxtTaxPercent.Leave += new System.EventHandler(this.ui_ntxtTaxPercent_Leave);
            this.ui_ntxtTaxPercent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ui_ntxtTaxPercent_KeyPress);
            // 
            // ui_ncmbAmount
            // 
            this.ui_ncmbAmount.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("Fees Levied", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("Profit (Like TDS)", -1, false, 0, new System.Drawing.Size(0, 0))});
            this.ui_ncmbAmount.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbAmount.Location = new System.Drawing.Point(88, 109);
            this.ui_ncmbAmount.Name = "ui_ncmbAmount";
            this.ui_ncmbAmount.Size = new System.Drawing.Size(256, 22);
            this.ui_ncmbAmount.TabIndex = 3;
            // 
            // ui_lblAmount
            // 
            this.ui_lblAmount.AutoSize = true;
            this.ui_lblAmount.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblAmount.Location = new System.Drawing.Point(14, 114);
            this.ui_lblAmount.Name = "ui_lblAmount";
            this.ui_lblAmount.Size = new System.Drawing.Size(67, 13);
            this.ui_lblAmount.TabIndex = 25;
            this.ui_lblAmount.Text = "Amount       :";
            this.ui_lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ui_nLineControl
            // 
            this.ui_nLineControl.Location = new System.Drawing.Point(15, 145);
            this.ui_nLineControl.Name = "ui_nLineControl";
            this.ui_nLineControl.Size = new System.Drawing.Size(329, 2);
            this.ui_nLineControl.Text = "nLineControl1";
            // 
            // ui_nbtnCancel
            // 
            this.ui_nbtnCancel.Location = new System.Drawing.Point(269, 158);
            this.ui_nbtnCancel.Name = "ui_nbtnCancel";
            this.ui_nbtnCancel.Size = new System.Drawing.Size(75, 23);
            this.ui_nbtnCancel.TabIndex = 5;
            this.ui_nbtnCancel.Text = "&Cancel";
            this.ui_nbtnCancel.UseVisualStyleBackColor = false;
            this.ui_nbtnCancel.Click += new System.EventHandler(this.ui_nbtnCancel_Click);
            // 
            // ui_nbtnOK
            // 
            this.ui_nbtnOK.Location = new System.Drawing.Point(186, 158);
            this.ui_nbtnOK.Name = "ui_nbtnOK";
            this.ui_nbtnOK.Size = new System.Drawing.Size(75, 23);
            this.ui_nbtnOK.TabIndex = 4;
            this.ui_nbtnOK.Text = "&OK";
            this.ui_nbtnOK.UseVisualStyleBackColor = false;
            this.ui_nbtnOK.Click += new System.EventHandler(this.ui_nbtnOK_Click);
            // 
            // ui_ntxtDescription
            // 
            this.ui_ntxtDescription.Location = new System.Drawing.Point(88, 79);
            this.ui_ntxtDescription.MaxLength = 256;
            this.ui_ntxtDescription.Name = "ui_ntxtDescription";
            this.ui_ntxtDescription.Size = new System.Drawing.Size(256, 18);
            this.ui_ntxtDescription.TabIndex = 2;
            // 
            // ui_lblDescription
            // 
            this.ui_lblDescription.AutoSize = true;
            this.ui_lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblDescription.Location = new System.Drawing.Point(14, 84);
            this.ui_lblDescription.Name = "ui_lblDescription";
            this.ui_lblDescription.Size = new System.Drawing.Size(69, 13);
            this.ui_lblDescription.TabIndex = 2;
            this.ui_lblDescription.Text = "Description  :";
            this.ui_lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ui_lblTaxPercent
            // 
            this.ui_lblTaxPercent.AutoSize = true;
            this.ui_lblTaxPercent.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblTaxPercent.Location = new System.Drawing.Point(14, 54);
            this.ui_lblTaxPercent.Name = "ui_lblTaxPercent";
            this.ui_lblTaxPercent.Size = new System.Drawing.Size(71, 13);
            this.ui_lblTaxPercent.TabIndex = 1;
            this.ui_lblTaxPercent.Text = "Tax Percent :";
            this.ui_lblTaxPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ui_lblTaxName
            // 
            this.ui_lblTaxName.AutoSize = true;
            this.ui_lblTaxName.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblTaxName.Location = new System.Drawing.Point(14, 24);
            this.ui_lblTaxName.Name = "ui_lblTaxName";
            this.ui_lblTaxName.Size = new System.Drawing.Size(71, 13);
            this.ui_lblTaxName.TabIndex = 0;
            this.ui_lblTaxName.Text = "Tax Name    :";
            this.ui_lblTaxName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uctlTaxMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ui_npnlTaxMaster);
            this.Name = "uctlTaxMaster";
            this.Size = new System.Drawing.Size(359, 199);
            this.ui_npnlTaxMaster.ResumeLayout(false);
            this.ui_npnlTaxMaster.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NUIPanel ui_npnlTaxMaster;
        private System.Windows.Forms.Label ui_lblTaxName;
        private System.Windows.Forms.Label ui_lblDescription;
        private System.Windows.Forms.Label ui_lblTaxPercent;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtDescription;
        private Nevron.UI.WinForm.Controls.NLineControl ui_nLineControl;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnCancel;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnOK;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbAmount;
        private System.Windows.Forms.Label ui_lblAmount;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtTaxPercent;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtTaxName;
    }
}
