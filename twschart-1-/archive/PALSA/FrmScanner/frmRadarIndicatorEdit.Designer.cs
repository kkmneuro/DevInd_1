using Nevron.UI.WinForm.Controls;

namespace PALSA.FrmScanner
{
    partial class frmRadarIndicatorEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRadarIndicatorEdit));
            this.lblName = new System.Windows.Forms.Label();
            this.txtScript = new Nevron.UI.WinForm.Controls.NRichTextBox();
            this.btnOK = new Nevron.UI.WinForm.Controls.NButton();
            this.btnCancel = new Nevron.UI.WinForm.Controls.NButton();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.ForeColor = System.Drawing.Color.Black;
            this.lblName.Location = new System.Drawing.Point(28, 11);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "label1";
            // 
            // txtScript
            // 
            this.txtScript.Location = new System.Drawing.Point(31, 27);
            this.txtScript.Name = "txtScript";
            this.txtScript.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.WindowsDefault;
            this.txtScript.PaletteInheritance = ((Nevron.UI.WinForm.Controls.PaletteInheritance)(Nevron.UI.WinForm.Controls.PaletteInheritance.None));
            this.txtScript.Size = new System.Drawing.Size(233, 117);
            this.txtScript.TabIndex = 2;
            // 
            // btnOK
            // 
            this.btnOK.ButtonProperties.ShowFocusRect = false;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(58, 150);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.TransparentBackground = true;
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.ButtonProperties.ShowFocusRect = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(159, 150);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TransparentBackground = true;
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // frmRadarIndicatorEdit
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(292, 182);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtScript);
            this.Controls.Add(this.lblName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRadarIndicatorEdit";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Easy Language";
            this.UseGlassIfEnabled = Nevron.UI.WinForm.Controls.CommonTriState.False;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private Nevron.UI.WinForm.Controls.NRichTextBox txtScript;
        private Nevron.UI.WinForm.Controls.NButton btnOK;
        private Nevron.UI.WinForm.Controls.NButton btnCancel;
    }
}