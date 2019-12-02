namespace PALSA.FrmScanner
{
    partial class frmScannerScriptEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmScannerScriptEdit));
            this.tabcrtl = new Nevron.UI.WinForm.Controls.NTabControl();
            this.btnOk = new Nevron.UI.WinForm.Controls.NButton();
            this.btnCancel = new Nevron.UI.WinForm.Controls.NButton();
            this.SuspendLayout();
            // 
            // tabcrtl
            // 
            this.tabcrtl.Location = new System.Drawing.Point(12, 12);
            this.tabcrtl.Name = "tabcrtl";
            this.tabcrtl.Padding = new System.Windows.Forms.Padding(4, 24, 4, 4);
            this.tabcrtl.Selectable = true;
            this.tabcrtl.SelectedIndex = -1;
            this.tabcrtl.Size = new System.Drawing.Size(505, 163);
            this.tabcrtl.TabIndex = 0;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(336, 191);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(442, 191);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmScannerScriptEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 231);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.tabcrtl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmScannerScriptEdit";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Script Edit";
            this.Load += new System.EventHandler(this.frmScannerScriptEdit_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NTabControl tabcrtl;
        private Nevron.UI.WinForm.Controls.NButton btnOk;
        private Nevron.UI.WinForm.Controls.NButton btnCancel;
    }
}