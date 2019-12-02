namespace PALSA.FrmRadar
{
    partial class IndicatorSettingsForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IndicatorSettingsForm));
            this.txtIndicatorName = new Nevron.UI.WinForm.Controls.NTextBox();
            this.lblIndicatorName = new System.Windows.Forms.Label();
            this.btnOK = new Nevron.UI.WinForm.Controls.NButton();
            this.btnCancel = new Nevron.UI.WinForm.Controls.NButton();
            this.lblAbbreviation = new System.Windows.Forms.Label();
            this.txtAbbreviation = new Nevron.UI.WinForm.Controls.NTextBox();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.btnValidate = new Nevron.UI.WinForm.Controls.NButton();
            this.txtDefaultScript = new Nevron.UI.WinForm.Controls.NTextBox();
            this.txtBuyScript = new Nevron.UI.WinForm.Controls.NTextBox();
            this.txtSellScript = new Nevron.UI.WinForm.Controls.NTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtIndicatorName
            // 
            this.txtIndicatorName.Location = new System.Drawing.Point(12, 25);
            this.txtIndicatorName.Name = "txtIndicatorName";
            this.txtIndicatorName.PaletteInheritance = ((Nevron.UI.WinForm.Controls.PaletteInheritance)(Nevron.UI.WinForm.Controls.PaletteInheritance.None));
            this.txtIndicatorName.Size = new System.Drawing.Size(215, 18);
            this.txtIndicatorName.TabIndex = 0;
            // 
            // lblIndicatorName
            // 
            this.lblIndicatorName.AutoSize = true;
            this.lblIndicatorName.ForeColor = System.Drawing.Color.Black;
            this.lblIndicatorName.Location = new System.Drawing.Point(12, 9);
            this.lblIndicatorName.Name = "lblIndicatorName";
            this.lblIndicatorName.Size = new System.Drawing.Size(77, 13);
            this.lblIndicatorName.TabIndex = 1;
            this.lblIndicatorName.Text = "Indicator name";
            // 
            // btnOK
            // 
            this.btnOK.ButtonProperties.ShowFocusRect = false;
            this.btnOK.Location = new System.Drawing.Point(246, 344);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "&OK";
            this.btnOK.TransparentBackground = true;
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.ButtonProperties.ShowFocusRect = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(327, 344);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "C&ancel";
            this.btnCancel.TransparentBackground = true;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblAbbreviation
            // 
            this.lblAbbreviation.AutoSize = true;
            this.lblAbbreviation.ForeColor = System.Drawing.Color.Black;
            this.lblAbbreviation.Location = new System.Drawing.Point(239, 9);
            this.lblAbbreviation.Name = "lblAbbreviation";
            this.lblAbbreviation.Size = new System.Drawing.Size(66, 13);
            this.lblAbbreviation.TabIndex = 10;
            this.lblAbbreviation.Text = "Abbreviation";
            // 
            // txtAbbreviation
            // 
            this.txtAbbreviation.Location = new System.Drawing.Point(242, 25);
            this.txtAbbreviation.Name = "txtAbbreviation";
            this.txtAbbreviation.PaletteInheritance = ((Nevron.UI.WinForm.Controls.PaletteInheritance)(Nevron.UI.WinForm.Controls.PaletteInheritance.None));
            this.txtAbbreviation.Size = new System.Drawing.Size(75, 18);
            this.txtAbbreviation.TabIndex = 11;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Fuchsia;
            this.imageList.Images.SetKeyName(0, "");
            this.imageList.Images.SetKeyName(1, "");
            this.imageList.Images.SetKeyName(2, "");
            this.imageList.Images.SetKeyName(3, "");
            // 
            // btnValidate
            // 
            this.btnValidate.ButtonProperties.ShowFocusRect = false;
            this.btnValidate.Location = new System.Drawing.Point(12, 344);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(75, 23);
            this.btnValidate.TabIndex = 13;
            this.btnValidate.Text = "&Validate";
            this.btnValidate.TransparentBackground = true;
            this.btnValidate.UseVisualStyleBackColor = false;
            this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // txtDefaultScript
            // 
            this.txtDefaultScript.Location = new System.Drawing.Point(12, 73);
            this.txtDefaultScript.Multiline = true;
            this.txtDefaultScript.Name = "txtDefaultScript";
            this.txtDefaultScript.PaletteInheritance = ((Nevron.UI.WinForm.Controls.PaletteInheritance)(Nevron.UI.WinForm.Controls.PaletteInheritance.None));
            this.txtDefaultScript.Size = new System.Drawing.Size(390, 67);
            this.txtDefaultScript.TabIndex = 14;
            // 
            // txtBuyScript
            // 
            this.txtBuyScript.Location = new System.Drawing.Point(12, 166);
            this.txtBuyScript.Multiline = true;
            this.txtBuyScript.Name = "txtBuyScript";
            this.txtBuyScript.PaletteInheritance = ((Nevron.UI.WinForm.Controls.PaletteInheritance)(Nevron.UI.WinForm.Controls.PaletteInheritance.None));
            this.txtBuyScript.Size = new System.Drawing.Size(390, 67);
            this.txtBuyScript.TabIndex = 15;
            // 
            // txtSellScript
            // 
            this.txtSellScript.Location = new System.Drawing.Point(12, 259);
            this.txtSellScript.Multiline = true;
            this.txtSellScript.Name = "txtSellScript";
            this.txtSellScript.PaletteInheritance = ((Nevron.UI.WinForm.Controls.PaletteInheritance)(Nevron.UI.WinForm.Controls.PaletteInheritance.None));
            this.txtSellScript.Size = new System.Drawing.Size(390, 67);
            this.txtSellScript.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(14, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Default script";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(14, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Buy script";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(14, 243);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Sell script";
            // 
            // IndicatorSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(425, 387);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSellScript);
            this.Controls.Add(this.txtBuyScript);
            this.Controls.Add(this.txtDefaultScript);
            this.Controls.Add(this.btnValidate);
            this.Controls.Add(this.txtAbbreviation);
            this.Controls.Add(this.lblAbbreviation);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblIndicatorName);
            this.Controls.Add(this.txtIndicatorName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IndicatorSettingsForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Indicator settings";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NTextBox txtIndicatorName;
        private System.Windows.Forms.Label lblIndicatorName;
        private Nevron.UI.WinForm.Controls.NButton btnOK;
        private Nevron.UI.WinForm.Controls.NButton btnCancel;
        private System.Windows.Forms.Label lblAbbreviation;
        private Nevron.UI.WinForm.Controls.NTextBox txtAbbreviation;
        private Nevron.UI.WinForm.Controls.NButton btnValidate;
        internal System.Windows.Forms.ImageList imageList;
        private Nevron.UI.WinForm.Controls.NTextBox txtDefaultScript;
        private Nevron.UI.WinForm.Controls.NTextBox txtBuyScript;
        private Nevron.UI.WinForm.Controls.NTextBox txtSellScript;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}