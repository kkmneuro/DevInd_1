namespace PALSA.FrmScanner
{
    partial class frmScannerExplorer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmScannerExplorer));
            this.btnClose = new Nevron.UI.WinForm.Controls.NButton();
            this.btnNew = new Nevron.UI.WinForm.Controls.NButton();
            this.btnEdit = new Nevron.UI.WinForm.Controls.NButton();
            this.btnCopy = new Nevron.UI.WinForm.Controls.NButton();
            this.btnDelete = new Nevron.UI.WinForm.Controls.NButton();
            this.btnHelp = new Nevron.UI.WinForm.Controls.NButton();
            this.btnExplore = new Nevron.UI.WinForm.Controls.NButton();
            this.btnReports = new Nevron.UI.WinForm.Controls.NButton();
            this.btnOptions = new Nevron.UI.WinForm.Controls.NButton();
            this.lstboxScanner = new Nevron.UI.WinForm.Controls.NListBox();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(274, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.TransparentBackground = true;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(274, 51);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 1;
            this.btnNew.Text = "New...";
            this.btnNew.TransparentBackground = true;
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(274, 97);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Edit...";
            this.btnEdit.TransparentBackground = true;
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(274, 145);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(75, 23);
            this.btnCopy.TabIndex = 3;
            this.btnCopy.Text = "Copy...";
            this.btnCopy.TransparentBackground = true;
            this.btnCopy.UseVisualStyleBackColor = false;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(274, 193);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete...";
            this.btnDelete.TransparentBackground = true;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(274, 240);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 23);
            this.btnHelp.TabIndex = 7;
            this.btnHelp.Text = "Help...";
            this.btnHelp.TransparentBackground = true;
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnExplore
            // 
            this.btnExplore.Border.Style = Nevron.UI.BorderStyle3D.None;
            this.btnExplore.Location = new System.Drawing.Point(12, 404);
            this.btnExplore.Name = "btnExplore";
            this.btnExplore.Size = new System.Drawing.Size(75, 23);
            this.btnExplore.TabIndex = 8;
            this.btnExplore.Text = "Explore";
            this.btnExplore.TransparentBackground = true;
            this.btnExplore.UseVisualStyleBackColor = false;
            this.btnExplore.Click += new System.EventHandler(this.btnExplore_Click);
            // 
            // btnReports
            // 
            this.btnReports.Enabled = false;
            this.btnReports.Location = new System.Drawing.Point(143, 404);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(75, 23);
            this.btnReports.TabIndex = 9;
            this.btnReports.Text = "Reports...";
            this.btnReports.TransparentBackground = true;
            this.btnReports.UseVisualStyleBackColor = false;
            // 
            // btnOptions
            // 
            this.btnOptions.Location = new System.Drawing.Point(274, 404);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(75, 23);
            this.btnOptions.TabIndex = 10;
            this.btnOptions.Text = "Options...";
            this.btnOptions.TransparentBackground = true;
            this.btnOptions.UseVisualStyleBackColor = false;
            // 
            // lstboxScanner
            // 
            this.lstboxScanner.Location = new System.Drawing.Point(12, 9);
            this.lstboxScanner.Name = "lstboxScanner";
            this.lstboxScanner.ScrollAlwaysVisible = true;
            this.lstboxScanner.Size = new System.Drawing.Size(245, 364);
            this.lstboxScanner.TabIndex = 11;
            // 
            // frmScannerExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 449);
            this.Controls.Add(this.lstboxScanner);
            this.Controls.Add(this.btnOptions);
            this.Controls.Add(this.btnReports);
            this.Controls.Add(this.btnExplore);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnClose);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmScannerExplorer";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Scanner Explorer";
            this.ResumeLayout(false);

        }

        #endregion

        internal Nevron.UI.WinForm.Controls.NButton btnClose;
        internal Nevron.UI.WinForm.Controls.NButton btnNew;
        internal Nevron.UI.WinForm.Controls.NButton btnEdit;
        internal Nevron.UI.WinForm.Controls.NButton btnCopy;
        internal Nevron.UI.WinForm.Controls.NButton btnDelete;
        internal Nevron.UI.WinForm.Controls.NButton btnHelp;
        internal Nevron.UI.WinForm.Controls.NButton btnExplore;
        internal Nevron.UI.WinForm.Controls.NButton btnReports;
        internal Nevron.UI.WinForm.Controls.NButton btnOptions;
        private Nevron.UI.WinForm.Controls.NListBox lstboxScanner;

    }
}