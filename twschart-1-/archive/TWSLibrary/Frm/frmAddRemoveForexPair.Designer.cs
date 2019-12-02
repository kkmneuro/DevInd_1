namespace CommonLibrary.UserControls
{
    partial class FrmAddRemoveForexPair
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddRemoveForexPair));
            this.ui_nlstInvisiblePairs = new Nevron.UI.WinForm.Controls.NListBox();
            this.ui_nlstvisiblePairs = new Nevron.UI.WinForm.Controls.NListBox();
            this.ui_npnlControlContainer = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.nExpanderTitle = new Nevron.UI.WinForm.Controls.NExpander();
            this.lblHelp = new System.Windows.Forms.Label();
            this.ui_nbtnAdd = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nbtnAddAll = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nbtnRemoveAll = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nbtnRemove = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nbtnApply = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nbtnCancel = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nbtnOk = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_npnlControlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nExpanderTitle)).BeginInit();
            this.nExpanderTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // ui_nlstInvisiblePairs
            // 
            this.ui_nlstInvisiblePairs.AllowDrop = true;
            this.ui_nlstInvisiblePairs.DrawMode = System.Windows.Forms.DrawMode.Normal;
            this.ui_nlstInvisiblePairs.ItemHeight = 13;
            this.ui_nlstInvisiblePairs.Location = new System.Drawing.Point(12, 34);
            this.ui_nlstInvisiblePairs.Name = "ui_nlstInvisiblePairs";
            this.ui_nlstInvisiblePairs.ScrollAlwaysVisible = true;
            this.ui_nlstInvisiblePairs.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.ui_nlstInvisiblePairs.Size = new System.Drawing.Size(101, 212);
            this.ui_nlstInvisiblePairs.TabIndex = 3;
            this.ui_nlstInvisiblePairs.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ui_nlstInvisiblePairs_MouseDown);
            // 
            // ui_nlstvisiblePairs
            // 
            this.ui_nlstvisiblePairs.AllowDrop = true;
            this.ui_nlstvisiblePairs.DrawMode = System.Windows.Forms.DrawMode.Normal;
            this.ui_nlstvisiblePairs.ItemHeight = 13;
            this.ui_nlstvisiblePairs.Location = new System.Drawing.Point(215, 34);
            this.ui_nlstvisiblePairs.Name = "ui_nlstvisiblePairs";
            this.ui_nlstvisiblePairs.ScrollAlwaysVisible = true;
            this.ui_nlstvisiblePairs.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.ui_nlstvisiblePairs.Size = new System.Drawing.Size(101, 212);
            this.ui_nlstvisiblePairs.TabIndex = 4;
            this.ui_nlstvisiblePairs.DragDrop += new System.Windows.Forms.DragEventHandler(this.ui_nlstvisiblePairs_DragDrop);
            this.ui_nlstvisiblePairs.DragOver += new System.Windows.Forms.DragEventHandler(this.ui_nlstvisiblePairs_DragOver);
            this.ui_nlstvisiblePairs.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ui_nlstvisiblePairs_MouseDown);
            // 
            // ui_npnlControlContainer
            // 
            this.ui_npnlControlContainer.Controls.Add(this.nExpanderTitle);
            this.ui_npnlControlContainer.Controls.Add(this.ui_nbtnAdd);
            this.ui_npnlControlContainer.Controls.Add(this.ui_nbtnAddAll);
            this.ui_npnlControlContainer.Controls.Add(this.ui_nbtnRemoveAll);
            this.ui_npnlControlContainer.Controls.Add(this.ui_nbtnRemove);
            this.ui_npnlControlContainer.Controls.Add(this.ui_nbtnApply);
            this.ui_npnlControlContainer.Controls.Add(this.ui_nbtnCancel);
            this.ui_npnlControlContainer.Controls.Add(this.ui_nbtnOk);
            this.ui_npnlControlContainer.Controls.Add(this.ui_nlstvisiblePairs);
            this.ui_npnlControlContainer.Controls.Add(this.ui_nlstInvisiblePairs);
            this.ui_npnlControlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_npnlControlContainer.Location = new System.Drawing.Point(0, 0);
            this.ui_npnlControlContainer.Name = "ui_npnlControlContainer";
            this.ui_npnlControlContainer.Size = new System.Drawing.Size(328, 285);
            this.ui_npnlControlContainer.TabIndex = 13;
            this.ui_npnlControlContainer.Text = "nuiPanel1";
            // 
            // nExpanderTitle
            // 
            this.nExpanderTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.nExpanderTitle.Controls.Add(this.lblHelp);
            this.nExpanderTitle.Location = new System.Drawing.Point(2, 3);
            this.nExpanderTitle.Name = "nExpanderTitle";
            this.nExpanderTitle.Size = new System.Drawing.Size(325, 88);
            this.nExpanderTitle.TabIndex = 12;
            this.nExpanderTitle.Text = "Title";
            // 
            // lblHelp
            // 
            this.lblHelp.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHelp.Location = new System.Drawing.Point(0, 24);
            this.lblHelp.Name = "lblHelp";
            this.lblHelp.Size = new System.Drawing.Size(325, 64);
            this.lblHelp.TabIndex = 0;
            this.lblHelp.Text = "label1";
            // 
            // ui_nbtnAdd
            // 
            this.ui_nbtnAdd.Location = new System.Drawing.Point(126, 73);
            this.ui_nbtnAdd.Name = "ui_nbtnAdd";
            this.ui_nbtnAdd.Size = new System.Drawing.Size(75, 23);
            this.ui_nbtnAdd.TabIndex = 14;
            this.ui_nbtnAdd.Text = "Add >";
            this.ui_nbtnAdd.UseVisualStyleBackColor = false;
            this.ui_nbtnAdd.Click += new System.EventHandler(this.ui_nbtnAdd_Click);
            // 
            // ui_nbtnAddAll
            // 
            this.ui_nbtnAddAll.Location = new System.Drawing.Point(126, 149);
            this.ui_nbtnAddAll.Name = "ui_nbtnAddAll";
            this.ui_nbtnAddAll.Size = new System.Drawing.Size(75, 23);
            this.ui_nbtnAddAll.TabIndex = 13;
            this.ui_nbtnAddAll.Text = "Add All >>";
            this.ui_nbtnAddAll.UseVisualStyleBackColor = false;
            this.ui_nbtnAddAll.Click += new System.EventHandler(this.ui_nbtnAddAll_Click);
            // 
            // ui_nbtnRemoveAll
            // 
            this.ui_nbtnRemoveAll.Location = new System.Drawing.Point(126, 187);
            this.ui_nbtnRemoveAll.Name = "ui_nbtnRemoveAll";
            this.ui_nbtnRemoveAll.Size = new System.Drawing.Size(75, 23);
            this.ui_nbtnRemoveAll.TabIndex = 12;
            this.ui_nbtnRemoveAll.Text = "<< Remove All";
            this.ui_nbtnRemoveAll.UseVisualStyleBackColor = false;
            this.ui_nbtnRemoveAll.Click += new System.EventHandler(this.ui_nbtnRemoveAll_Click);
            // 
            // ui_nbtnRemove
            // 
            this.ui_nbtnRemove.Location = new System.Drawing.Point(126, 111);
            this.ui_nbtnRemove.Name = "ui_nbtnRemove";
            this.ui_nbtnRemove.Size = new System.Drawing.Size(75, 23);
            this.ui_nbtnRemove.TabIndex = 11;
            this.ui_nbtnRemove.Text = "< Remove";
            this.ui_nbtnRemove.UseVisualStyleBackColor = false;
            this.ui_nbtnRemove.Click += new System.EventHandler(this.ui_nbtnRemove_Click);
            // 
            // ui_nbtnApply
            // 
            this.ui_nbtnApply.Location = new System.Drawing.Point(236, 254);
            this.ui_nbtnApply.Name = "ui_nbtnApply";
            this.ui_nbtnApply.Size = new System.Drawing.Size(75, 23);
            this.ui_nbtnApply.TabIndex = 2;
            this.ui_nbtnApply.Text = "&Apply";
            this.ui_nbtnApply.UseVisualStyleBackColor = false;
            this.ui_nbtnApply.Click += new System.EventHandler(this.ui_nbtnApply_Click);
            // 
            // ui_nbtnCancel
            // 
            this.ui_nbtnCancel.Location = new System.Drawing.Point(126, 254);
            this.ui_nbtnCancel.Name = "ui_nbtnCancel";
            this.ui_nbtnCancel.Size = new System.Drawing.Size(75, 23);
            this.ui_nbtnCancel.TabIndex = 1;
            this.ui_nbtnCancel.Text = "&Cancel";
            this.ui_nbtnCancel.UseVisualStyleBackColor = false;
            this.ui_nbtnCancel.Click += new System.EventHandler(this.ui_nbtnCancel_Click);
            // 
            // ui_nbtnOk
            // 
            this.ui_nbtnOk.Location = new System.Drawing.Point(16, 254);
            this.ui_nbtnOk.Name = "ui_nbtnOk";
            this.ui_nbtnOk.Size = new System.Drawing.Size(75, 23);
            this.ui_nbtnOk.TabIndex = 0;
            this.ui_nbtnOk.Text = "O&K";
            this.ui_nbtnOk.UseVisualStyleBackColor = false;
            this.ui_nbtnOk.Click += new System.EventHandler(this.ui_nbtnOk_Click);
            // 
            // frmAddRemoveForexPair
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(328, 285);
            this.ControlBox = false;
            this.Controls.Add(this.ui_npnlControlContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAddRemoveForexPair";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Remove ForexPair";
            this.Load += new System.EventHandler(this.frmAddRemoveForexPair_Load);
            this.ui_npnlControlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nExpanderTitle)).EndInit();
            this.nExpanderTitle.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NListBox ui_nlstInvisiblePairs;
        private Nevron.UI.WinForm.Controls.NListBox ui_nlstvisiblePairs;
        private Nevron.UI.WinForm.Controls.NUIPanel ui_npnlControlContainer;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnOk;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnApply;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnCancel;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnAddAll;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnRemoveAll;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnRemove;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnAdd;
        private Nevron.UI.WinForm.Controls.NExpander nExpanderTitle;
        private System.Windows.Forms.Label lblHelp;
    }
}