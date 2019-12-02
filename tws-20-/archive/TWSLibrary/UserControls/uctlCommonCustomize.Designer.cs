namespace CommonLibrary.UserControls
{
    partial class UctlCommonCustomize
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
            this.nuiPanel1 = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.ui_nbtnOK = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nbtnCancel = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nbtnApply = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nlstSelectView = new Nevron.UI.WinForm.Controls.NListBox();
            this.ui_PropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.ui_lblSelectView = new System.Windows.Forms.Label();
            this.ui_lblControlName = new System.Windows.Forms.Label();
            this.nuiPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nuiPanel1
            // 
            this.nuiPanel1.Controls.Add(this.ui_lblControlName);
            this.nuiPanel1.Controls.Add(this.ui_lblSelectView);
            this.nuiPanel1.Controls.Add(this.ui_nbtnOK);
            this.nuiPanel1.Controls.Add(this.ui_nbtnCancel);
            this.nuiPanel1.Controls.Add(this.ui_nbtnApply);
            this.nuiPanel1.Controls.Add(this.ui_nlstSelectView);
            this.nuiPanel1.Controls.Add(this.ui_PropertyGrid);
            this.nuiPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nuiPanel1.Location = new System.Drawing.Point(0, 0);
            this.nuiPanel1.Name = "nuiPanel1";
            this.nuiPanel1.Size = new System.Drawing.Size(432, 462);
            this.nuiPanel1.TabIndex = 0;
            this.nuiPanel1.Text = "nuiPanel1";
            // 
            // ui_nbtnOK
            // 
            this.ui_nbtnOK.Location = new System.Drawing.Point(219, 427);
            this.ui_nbtnOK.Name = "ui_nbtnOK";
            this.ui_nbtnOK.Size = new System.Drawing.Size(62, 23);
            this.ui_nbtnOK.TabIndex = 11;
            this.ui_nbtnOK.Text = "&OK";
            this.ui_nbtnOK.UseVisualStyleBackColor = false;
            // 
            // ui_nbtnCancel
            // 
            this.ui_nbtnCancel.Location = new System.Drawing.Point(290, 427);
            this.ui_nbtnCancel.Name = "ui_nbtnCancel";
            this.ui_nbtnCancel.Size = new System.Drawing.Size(62, 23);
            this.ui_nbtnCancel.TabIndex = 10;
            this.ui_nbtnCancel.Text = "&Cancel";
            this.ui_nbtnCancel.UseVisualStyleBackColor = false;
            // 
            // ui_nbtnApply
            // 
            this.ui_nbtnApply.Location = new System.Drawing.Point(361, 427);
            this.ui_nbtnApply.Name = "ui_nbtnApply";
            this.ui_nbtnApply.Size = new System.Drawing.Size(62, 23);
            this.ui_nbtnApply.TabIndex = 9;
            this.ui_nbtnApply.Text = "&Apply";
            this.ui_nbtnApply.UseVisualStyleBackColor = false;
            // 
            // ui_nlstSelectView
            // 
            this.ui_nlstSelectView.Location = new System.Drawing.Point(5, 30);
            this.ui_nlstSelectView.Name = "ui_nlstSelectView";
            this.ui_nlstSelectView.Size = new System.Drawing.Size(204, 384);
            this.ui_nlstSelectView.TabIndex = 8;
            // 
            // ui_PropertyGrid
            // 
            this.ui_PropertyGrid.HelpBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.ui_PropertyGrid.HelpForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ui_PropertyGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.ui_PropertyGrid.Location = new System.Drawing.Point(219, 30);
            this.ui_PropertyGrid.Name = "ui_PropertyGrid";
            this.ui_PropertyGrid.Size = new System.Drawing.Size(204, 384);
            this.ui_PropertyGrid.TabIndex = 7;
            this.ui_PropertyGrid.ToolbarVisible = false;
            this.ui_PropertyGrid.ViewBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ui_PropertyGrid.ViewForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // ui_lblSelectView
            // 
            this.ui_lblSelectView.AutoSize = true;
            this.ui_lblSelectView.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblSelectView.Location = new System.Drawing.Point(5, 11);
            this.ui_lblSelectView.Name = "ui_lblSelectView";
            this.ui_lblSelectView.Size = new System.Drawing.Size(63, 13);
            this.ui_lblSelectView.TabIndex = 12;
            this.ui_lblSelectView.Text = "Select View";
            // 
            // ui_lblControlName
            // 
            this.ui_lblControlName.AutoSize = true;
            this.ui_lblControlName.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblControlName.Location = new System.Drawing.Point(218, 11);
            this.ui_lblControlName.Name = "ui_lblControlName";
            this.ui_lblControlName.Size = new System.Drawing.Size(85, 13);
            this.ui_lblControlName.TabIndex = 13;
            this.ui_lblControlName.Text = "Selected Control";
            // 
            // uctlCommonCustomize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nuiPanel1);
            this.Name = "UctlCommonCustomize";
            this.Size = new System.Drawing.Size(432, 462);
            this.nuiPanel1.ResumeLayout(false);
            this.nuiPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NUIPanel nuiPanel1;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnOK;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnCancel;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnApply;
        private Nevron.UI.WinForm.Controls.NListBox ui_nlstSelectView;
        private System.Windows.Forms.PropertyGrid ui_PropertyGrid;
        private System.Windows.Forms.Label ui_lblControlName;
        private System.Windows.Forms.Label ui_lblSelectView;
    }
}
