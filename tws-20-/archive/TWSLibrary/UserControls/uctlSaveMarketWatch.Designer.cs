namespace CommonLibrary.UserControls
{
    partial class uctlSaveMarketWatch
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
            this.ui_npnlSaveMarketWatch = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.btnCancel = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_ncmbMarketWatchName = new Nevron.UI.WinForm.Controls.NComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_npnlSaveMarketWatch.SuspendLayout();
            this.SuspendLayout();
            // 
            // ui_npnlSaveMarketWatch
            // 
            this.ui_npnlSaveMarketWatch.Controls.Add(this.btnCancel);
            this.ui_npnlSaveMarketWatch.Controls.Add(this.ui_ncmbMarketWatchName);
            this.ui_npnlSaveMarketWatch.Controls.Add(this.label1);
            this.ui_npnlSaveMarketWatch.Controls.Add(this.btnSave);
            this.ui_npnlSaveMarketWatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_npnlSaveMarketWatch.FillInfo.Gradient1 = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(169)))), ((int)(((byte)(193)))));
            this.ui_npnlSaveMarketWatch.Location = new System.Drawing.Point(0, 0);
            this.ui_npnlSaveMarketWatch.Name = "ui_npnlSaveMarketWatch";
            this.ui_npnlSaveMarketWatch.Size = new System.Drawing.Size(271, 144);
            this.ui_npnlSaveMarketWatch.TabIndex = 1;
            this.ui_npnlSaveMarketWatch.Text = "nuiPanel1";
            this.ui_npnlSaveMarketWatch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ui_npnlSaveMarketWatch_KeyPress);
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Location = new System.Drawing.Point(159, 92);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(77, 27);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // ui_ncmbMarketWatchName
            // 
            this.ui_ncmbMarketWatchName.Editable = true;
            this.ui_ncmbMarketWatchName.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbMarketWatchName.Location = new System.Drawing.Point(77, 41);
            this.ui_ncmbMarketWatchName.Name = "ui_ncmbMarketWatchName";
            this.ui_ncmbMarketWatchName.Size = new System.Drawing.Size(159, 22);
            this.ui_ncmbMarketWatchName.TabIndex = 2;
            this.ui_ncmbMarketWatchName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ui_ncmbMarketWatchName_KeyDown);
            this.ui_ncmbMarketWatchName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ui_ncmbMarketWatchName_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name :";
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Location = new System.Drawing.Point(77, 92);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(77, 27);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // uctlSaveMarketWatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ui_npnlSaveMarketWatch);
            this.Name = "uctlSaveMarketWatch";
            this.Size = new System.Drawing.Size(271, 144);
            this.Load += new System.EventHandler(this.uctlSaveMarketWatch_Load);
            this.ui_npnlSaveMarketWatch.ResumeLayout(false);
            this.ui_npnlSaveMarketWatch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NUIPanel ui_npnlSaveMarketWatch;
        private System.Windows.Forms.Label label1;
        public Nevron.UI.WinForm.Controls.NComboBox ui_ncmbMarketWatchName;
        public Nevron.UI.WinForm.Controls.NButton btnCancel;
        public Nevron.UI.WinForm.Controls.NButton btnSave;

    }
}
