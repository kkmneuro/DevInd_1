namespace PALSA.FrmRadar
{
    partial class FindRadarSymbolForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FindRadarSymbolForm));
            this.radCurrentPage = new System.Windows.Forms.RadioButton();
            this.radAllPages = new System.Windows.Forms.RadioButton();
            this.btnCancel = new Nevron.UI.WinForm.Controls.NButton();
            this.btnOK = new Nevron.UI.WinForm.Controls.NButton();
            this.txtSymbol = new Nevron.UI.WinForm.Controls.NTextBox();
            this.lblFind = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // radCurrentPage
            // 
            this.radCurrentPage.AutoSize = true;
            this.radCurrentPage.Checked = true;
            this.radCurrentPage.ForeColor = System.Drawing.Color.Black;
            this.radCurrentPage.Location = new System.Drawing.Point(82, 36);
            this.radCurrentPage.Name = "radCurrentPage";
            this.radCurrentPage.Size = new System.Drawing.Size(96, 17);
            this.radCurrentPage.TabIndex = 12;
            this.radCurrentPage.TabStop = true;
            this.radCurrentPage.Text = "in current page";
            this.radCurrentPage.UseVisualStyleBackColor = false;
            // 
            // radAllPages
            // 
            this.radAllPages.AutoSize = true;
            this.radAllPages.ForeColor = System.Drawing.Color.Black;
            this.radAllPages.Location = new System.Drawing.Point(184, 36);
            this.radAllPages.Name = "radAllPages";
            this.radAllPages.Size = new System.Drawing.Size(78, 17);
            this.radAllPages.TabIndex = 11;
            this.radAllPages.Text = "in all pages";
            this.radAllPages.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.ButtonProperties.ShowFocusRect = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(194, 67);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TransparentBackground = true;
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnOK
            // 
            this.btnOK.ButtonProperties.ShowFocusRect = false;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(113, 67);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "OK";
            this.btnOK.TransparentBackground = true;
            this.btnOK.UseVisualStyleBackColor = false;
            // 
            // txtSymbol
            // 
            this.txtSymbol.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSymbol.Location = new System.Drawing.Point(69, 12);
            this.txtSymbol.Name = "txtSymbol";
            this.txtSymbol.Palette.BaseScheme = Nevron.UI.WinForm.Controls.ColorScheme.WindowsDefault;
            this.txtSymbol.Palette.Caption = System.Drawing.SystemColors.ControlDarkDark;
            this.txtSymbol.Palette.CaptionText = System.Drawing.Color.White;
            this.txtSymbol.Palette.CheckedDark = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.txtSymbol.Palette.CheckedLight = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.txtSymbol.Palette.ControlDark = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSymbol.Palette.ControlLight = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.txtSymbol.Palette.Highlight = System.Drawing.SystemColors.Highlight;
            this.txtSymbol.Palette.HighlightDark = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(215)))), ((int)(((byte)(255)))));
            this.txtSymbol.Palette.HighlightLight = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(215)))), ((int)(((byte)(255)))));
            this.txtSymbol.Palette.HighlightText = System.Drawing.SystemColors.HighlightText;
            this.txtSymbol.Palette.Menu = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.txtSymbol.Palette.PressedLight = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.txtSymbol.Palette.SelectedBorder = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.txtSymbol.Palette.Window = System.Drawing.SystemColors.Window;
            this.txtSymbol.PaletteInheritance = ((Nevron.UI.WinForm.Controls.PaletteInheritance)(Nevron.UI.WinForm.Controls.PaletteInheritance.None));
            this.txtSymbol.Size = new System.Drawing.Size(200, 18);
            this.txtSymbol.TabIndex = 8;
            // 
            // lblFind
            // 
            this.lblFind.AutoSize = true;
            this.lblFind.BackColor = System.Drawing.Color.Transparent;
            this.lblFind.ForeColor = System.Drawing.Color.Black;
            this.lblFind.Location = new System.Drawing.Point(10, 15);
            this.lblFind.Name = "lblFind";
            this.lblFind.Size = new System.Drawing.Size(53, 13);
            this.lblFind.TabIndex = 7;
            this.lblFind.Text = "Find what";
            // 
            // FindRadarSymbolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 112);
            this.Controls.Add(this.radCurrentPage);
            this.Controls.Add(this.radAllPages);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtSymbol);
            this.Controls.Add(this.lblFind);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FindRadarSymbolForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Find Radar Symbol";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radCurrentPage;
        private System.Windows.Forms.RadioButton radAllPages;
        private Nevron.UI.WinForm.Controls.NButton btnCancel;
        private Nevron.UI.WinForm.Controls.NButton btnOK;
        private Nevron.UI.WinForm.Controls.NTextBox txtSymbol;
        private System.Windows.Forms.Label lblFind;

    }
}