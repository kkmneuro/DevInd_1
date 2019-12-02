namespace PALSA.FrmScanner
{
    partial class frmScannerSecurities
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmScannerSecurities));
            this.nLineControl1 = new Nevron.UI.WinForm.Controls.NLineControl();
            this.btnOK = new Nevron.UI.WinForm.Controls.NButton();
            this.btnCancel = new Nevron.UI.WinForm.Controls.NButton();
            this.btnSave = new Nevron.UI.WinForm.Controls.NButton();
            this.btnAddSecurities = new Nevron.UI.WinForm.Controls.NButton();
            this.btnRemove = new Nevron.UI.WinForm.Controls.NButton();
            this.btnRemoveAll = new Nevron.UI.WinForm.Controls.NButton();
            this.chkUseLastExploration = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.dgvSymbol = new Nevron.UI.WinForm.Controls.NDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSymbol)).BeginInit();
            this.SuspendLayout();
            // 
            // nLineControl1
            // 
            this.nLineControl1.Location = new System.Drawing.Point(12, 288);
            this.nLineControl1.Name = "nLineControl1";
            this.nLineControl1.Size = new System.Drawing.Size(529, 2);
            this.nLineControl1.Text = "nLineControl1";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(370, 310);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(466, 310);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(466, 243);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save...";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAddSecurities
            // 
            this.btnAddSecurities.Location = new System.Drawing.Point(12, 243);
            this.btnAddSecurities.Name = "btnAddSecurities";
            this.btnAddSecurities.Size = new System.Drawing.Size(98, 23);
            this.btnAddSecurities.TabIndex = 4;
            this.btnAddSecurities.Text = "AddSecurities...";
            this.btnAddSecurities.UseVisualStyleBackColor = false;
            this.btnAddSecurities.Click += new System.EventHandler(this.btnAddSecurities_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(129, 243);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 5;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.Location = new System.Drawing.Point(224, 243);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveAll.TabIndex = 6;
            this.btnRemoveAll.Text = "RemoveAll";
            this.btnRemoveAll.UseVisualStyleBackColor = false;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // chkUseLastExploration
            // 
            this.chkUseLastExploration.AutoSize = true;
            this.chkUseLastExploration.ButtonProperties.BorderOffset = 2;
            this.chkUseLastExploration.Location = new System.Drawing.Point(12, 310);
            this.chkUseLastExploration.Name = "chkUseLastExploration";
            this.chkUseLastExploration.Size = new System.Drawing.Size(174, 17);
            this.chkUseLastExploration.TabIndex = 7;
            this.chkUseLastExploration.Text = "Use results from last exploration";
            this.chkUseLastExploration.TransparentBackground = true;
            this.chkUseLastExploration.UseVisualStyleBackColor = false;
            this.chkUseLastExploration.CheckedChanged += new System.EventHandler(this.chkUseLastExploration_CheckedChanged);
            // 
            // dgvSymbol
            // 
            this.dgvSymbol.AllowUserToAddRows = false;
            this.dgvSymbol.AllowUserToDeleteRows = false;
            this.dgvSymbol.AllowUserToResizeRows = false;
            this.dgvSymbol.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSymbol.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.dgvSymbol.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSymbol.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.dgvSymbol.Location = new System.Drawing.Point(12, 12);
            this.dgvSymbol.Name = "dgvSymbol";
            this.dgvSymbol.ReadOnly = true;
            this.dgvSymbol.RowHeadersVisible = false;
            this.dgvSymbol.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSymbol.Size = new System.Drawing.Size(529, 217);
            this.dgvSymbol.TabIndex = 9;
            // 
            // frmScannerSecurities
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 345);
            this.Controls.Add(this.dgvSymbol);
            this.Controls.Add(this.chkUseLastExploration);
            this.Controls.Add(this.btnRemoveAll);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAddSecurities);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.nLineControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmScannerSecurities";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Securities";
            this.Load += new System.EventHandler(this.frmScannerSecurities_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSymbol)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NLineControl nLineControl1;
        private Nevron.UI.WinForm.Controls.NButton btnOK;
        private Nevron.UI.WinForm.Controls.NButton btnCancel;
        private Nevron.UI.WinForm.Controls.NButton btnSave;
        private Nevron.UI.WinForm.Controls.NButton btnAddSecurities;
        private Nevron.UI.WinForm.Controls.NButton btnRemove;
        private Nevron.UI.WinForm.Controls.NButton btnRemoveAll;
        private Nevron.UI.WinForm.Controls.NCheckBox chkUseLastExploration;
        private Nevron.UI.WinForm.Controls.NDataGridView dgvSymbol;
    }
}