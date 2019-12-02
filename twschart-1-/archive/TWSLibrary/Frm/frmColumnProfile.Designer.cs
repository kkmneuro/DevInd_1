namespace CommonLibrary.UserControls
{
    partial class FrmColumnProfile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmColumnProfile));
            this.nuiPanel1 = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.ui_nbtnSetDefaultProfile = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nbtnDelete = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nbtnSave = new Nevron.UI.WinForm.Controls.NButton();
            this.lblColumnProfileName = new System.Windows.Forms.Label();
            this.ui_ncmbColumnProfile = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_nchkSelectAll = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.ui_nbtnCancel = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nbtnOk = new Nevron.UI.WinForm.Controls.NButton();
            this.uui_nbtnHide = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nbtnShow = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nbtnMoveDown = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nbtnMoveUp = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nlstColumns = new Nevron.UI.WinForm.Controls.NListBox();
            this.ui_lblNote = new System.Windows.Forms.Label();
            this.nuiPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nuiPanel1
            // 
            this.nuiPanel1.Controls.Add(this.ui_nbtnSetDefaultProfile);
            this.nuiPanel1.Controls.Add(this.ui_nbtnDelete);
            this.nuiPanel1.Controls.Add(this.ui_nbtnSave);
            this.nuiPanel1.Controls.Add(this.lblColumnProfileName);
            this.nuiPanel1.Controls.Add(this.ui_ncmbColumnProfile);
            this.nuiPanel1.Controls.Add(this.ui_nchkSelectAll);
            this.nuiPanel1.Controls.Add(this.ui_nbtnCancel);
            this.nuiPanel1.Controls.Add(this.ui_nbtnOk);
            this.nuiPanel1.Controls.Add(this.uui_nbtnHide);
            this.nuiPanel1.Controls.Add(this.ui_nbtnShow);
            this.nuiPanel1.Controls.Add(this.ui_nbtnMoveDown);
            this.nuiPanel1.Controls.Add(this.ui_nbtnMoveUp);
            this.nuiPanel1.Controls.Add(this.ui_nlstColumns);
            this.nuiPanel1.Controls.Add(this.ui_lblNote);
            this.nuiPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nuiPanel1.Location = new System.Drawing.Point(0, 0);
            this.nuiPanel1.Name = "nuiPanel1";
            this.nuiPanel1.Size = new System.Drawing.Size(328, 293);
            this.nuiPanel1.TabIndex = 0;
            this.nuiPanel1.Text = "nuiPanel1";
            // 
            // ui_nbtnSetDefaultProfile
            // 
            this.ui_nbtnSetDefaultProfile.Location = new System.Drawing.Point(160, 6);
            this.ui_nbtnSetDefaultProfile.Name = "ui_nbtnSetDefaultProfile";
            this.ui_nbtnSetDefaultProfile.Size = new System.Drawing.Size(157, 23);
            this.ui_nbtnSetDefaultProfile.TabIndex = 13;
            this.ui_nbtnSetDefaultProfile.Text = "Set As Default Profile";
            this.ui_nbtnSetDefaultProfile.UseVisualStyleBackColor = false;
            this.ui_nbtnSetDefaultProfile.Click += new System.EventHandler(this.ui_nbtnSetDefaultProfile_Click);
            // 
            // ui_nbtnDelete
            // 
            this.ui_nbtnDelete.Location = new System.Drawing.Point(242, 36);
            this.ui_nbtnDelete.Name = "ui_nbtnDelete";
            this.ui_nbtnDelete.Size = new System.Drawing.Size(75, 23);
            this.ui_nbtnDelete.TabIndex = 12;
            this.ui_nbtnDelete.Text = "Delete";
            this.ui_nbtnDelete.UseVisualStyleBackColor = false;
            this.ui_nbtnDelete.Click += new System.EventHandler(this.ui_nbtnRemove_Click);
            // 
            // ui_nbtnSave
            // 
            this.ui_nbtnSave.Location = new System.Drawing.Point(160, 36);
            this.ui_nbtnSave.Name = "ui_nbtnSave";
            this.ui_nbtnSave.Size = new System.Drawing.Size(75, 23);
            this.ui_nbtnSave.TabIndex = 11;
            this.ui_nbtnSave.Text = "Save";
            this.ui_nbtnSave.UseVisualStyleBackColor = false;
            this.ui_nbtnSave.Click += new System.EventHandler(this.ui_nbtnSave_Click);
            // 
            // lblColumnProfileName
            // 
            this.lblColumnProfileName.AutoSize = true;
            this.lblColumnProfileName.BackColor = System.Drawing.Color.Transparent;
            this.lblColumnProfileName.Location = new System.Drawing.Point(3, 20);
            this.lblColumnProfileName.Name = "lblColumnProfileName";
            this.lblColumnProfileName.Size = new System.Drawing.Size(111, 13);
            this.lblColumnProfileName.TabIndex = 10;
            this.lblColumnProfileName.Text = "Column Profile Name :";
            // 
            // ui_ncmbColumnProfile
            // 
            this.ui_ncmbColumnProfile.Editable = true;
            this.ui_ncmbColumnProfile.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("--SELECT--", -1, false, 0, new System.Drawing.Size(0, 0))});
            this.ui_ncmbColumnProfile.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbColumnProfile.Location = new System.Drawing.Point(5, 36);
            this.ui_ncmbColumnProfile.Name = "ui_ncmbColumnProfile";
            this.ui_ncmbColumnProfile.Size = new System.Drawing.Size(142, 22);
            this.ui_ncmbColumnProfile.TabIndex = 9;
            this.ui_ncmbColumnProfile.SelectedIndexChanged += new System.EventHandler(this.ui_ncmbColumnProfile_SelectedIndexChanged);
            // 
            // ui_nchkSelectAll
            // 
            this.ui_nchkSelectAll.AutoSize = true;
            this.ui_nchkSelectAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ui_nchkSelectAll.ButtonProperties.BorderOffset = 2;
            this.ui_nchkSelectAll.Location = new System.Drawing.Point(6, 259);
            this.ui_nchkSelectAll.Name = "ui_nchkSelectAll";
            this.ui_nchkSelectAll.Size = new System.Drawing.Size(70, 17);
            this.ui_nchkSelectAll.TabIndex = 8;
            this.ui_nchkSelectAll.Text = "Select All";
            this.ui_nchkSelectAll.TransparentBackground = true;
            this.ui_nchkSelectAll.UseVisualStyleBackColor = false;
            this.ui_nchkSelectAll.CheckedChanged += new System.EventHandler(this.ui_nchkSelectAll_CheckedChanged);
            // 
            // ui_nbtnCancel
            // 
            this.ui_nbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ui_nbtnCancel.Location = new System.Drawing.Point(242, 259);
            this.ui_nbtnCancel.Name = "ui_nbtnCancel";
            this.ui_nbtnCancel.Size = new System.Drawing.Size(75, 23);
            this.ui_nbtnCancel.TabIndex = 7;
            this.ui_nbtnCancel.Text = "&Cancel";
            this.ui_nbtnCancel.UseVisualStyleBackColor = false;
            this.ui_nbtnCancel.Click += new System.EventHandler(this.ui_nbtnCancel_Click);
            // 
            // ui_nbtnOk
            // 
            this.ui_nbtnOk.Location = new System.Drawing.Point(160, 259);
            this.ui_nbtnOk.Name = "ui_nbtnOk";
            this.ui_nbtnOk.Size = new System.Drawing.Size(75, 23);
            this.ui_nbtnOk.TabIndex = 6;
            this.ui_nbtnOk.Text = "&Ok";
            this.ui_nbtnOk.UseVisualStyleBackColor = false;
            this.ui_nbtnOk.Click += new System.EventHandler(this.ui_nbtnOk_Click);
            // 
            // uui_nbtnHide
            // 
            this.uui_nbtnHide.Location = new System.Drawing.Point(242, 199);
            this.uui_nbtnHide.Name = "uui_nbtnHide";
            this.uui_nbtnHide.Size = new System.Drawing.Size(75, 23);
            this.uui_nbtnHide.TabIndex = 5;
            this.uui_nbtnHide.Text = "Hide";
            this.uui_nbtnHide.UseVisualStyleBackColor = false;
            this.uui_nbtnHide.Click += new System.EventHandler(this.uui_nbtnHide_Click);
            // 
            // ui_nbtnShow
            // 
            this.ui_nbtnShow.Location = new System.Drawing.Point(242, 166);
            this.ui_nbtnShow.Name = "ui_nbtnShow";
            this.ui_nbtnShow.Size = new System.Drawing.Size(75, 23);
            this.ui_nbtnShow.TabIndex = 4;
            this.ui_nbtnShow.Text = "Show";
            this.ui_nbtnShow.UseVisualStyleBackColor = false;
            this.ui_nbtnShow.Click += new System.EventHandler(this.ui_nbtnShow_Click);
            // 
            // ui_nbtnMoveDown
            // 
            this.ui_nbtnMoveDown.Location = new System.Drawing.Point(242, 133);
            this.ui_nbtnMoveDown.Name = "ui_nbtnMoveDown";
            this.ui_nbtnMoveDown.Size = new System.Drawing.Size(75, 23);
            this.ui_nbtnMoveDown.TabIndex = 3;
            this.ui_nbtnMoveDown.Text = "Move Down";
            this.ui_nbtnMoveDown.UseVisualStyleBackColor = false;
            this.ui_nbtnMoveDown.Click += new System.EventHandler(this.ui_nbtnMoveDown_Click);
            // 
            // ui_nbtnMoveUp
            // 
            this.ui_nbtnMoveUp.Location = new System.Drawing.Point(242, 100);
            this.ui_nbtnMoveUp.Name = "ui_nbtnMoveUp";
            this.ui_nbtnMoveUp.Size = new System.Drawing.Size(75, 23);
            this.ui_nbtnMoveUp.TabIndex = 2;
            this.ui_nbtnMoveUp.Text = "Move Up";
            this.ui_nbtnMoveUp.UseVisualStyleBackColor = false;
            this.ui_nbtnMoveUp.Click += new System.EventHandler(this.ui_nbtnMoveUp_Click);
            // 
            // ui_nlstColumns
            // 
            this.ui_nlstColumns.CheckBoxes = true;
            this.ui_nlstColumns.ColumnOnLeft = false;
            this.ui_nlstColumns.ItemHeight = 18;
            this.ui_nlstColumns.Location = new System.Drawing.Point(6, 100);
            this.ui_nlstColumns.Name = "ui_nlstColumns";
            this.ui_nlstColumns.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ui_nlstColumns.Size = new System.Drawing.Size(229, 148);
            this.ui_nlstColumns.TabIndex = 1;
            this.ui_nlstColumns.SelectedIndexChanged += new System.EventHandler(this.ui_nlstColumns_SelectedIndexChanged);
            // 
            // ui_lblNote
            // 
            this.ui_lblNote.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblNote.Location = new System.Drawing.Point(3, 67);
            this.ui_lblNote.Name = "ui_lblNote";
            this.ui_lblNote.Size = new System.Drawing.Size(325, 30);
            this.ui_lblNote.TabIndex = 0;
            this.ui_lblNote.Text = "Check the columns that you would like to make visible in the folder. Use the Move" +
    " Up and Move Down buttons to reorder the columns.";
            // 
            // FrmColumnProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ui_nbtnCancel;
            this.ClientSize = new System.Drawing.Size(328, 293);
            this.Controls.Add(this.nuiPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmColumnProfile";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Column Profile";
            this.Load += new System.EventHandler(this.frmColumnProfile_Load);
            this.nuiPanel1.ResumeLayout(false);
            this.nuiPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NUIPanel nuiPanel1;
        private Nevron.UI.WinForm.Controls.NCheckBox ui_nchkSelectAll;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnCancel;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnOk;
        private Nevron.UI.WinForm.Controls.NButton uui_nbtnHide;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnShow;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnMoveDown;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnMoveUp;
        private Nevron.UI.WinForm.Controls.NListBox ui_nlstColumns;
        private System.Windows.Forms.Label ui_lblNote;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnSetDefaultProfile;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnDelete;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnSave;
        private System.Windows.Forms.Label lblColumnProfileName;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbColumnProfile;
    }
}
