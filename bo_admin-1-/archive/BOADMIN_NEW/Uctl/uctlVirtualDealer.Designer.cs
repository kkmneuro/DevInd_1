namespace BOADMIN_NEW.Uctl
{
    partial class uctlVirtualDealer
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
            this.components = new System.ComponentModel.Container();
            this.ui_ndgvVirtualDealer = new Nevron.UI.WinForm.Controls.NDataGridView();
            this.ui_cmsVirtualDealer = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ui_mnuAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.ui_mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.ui_mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.ui_ndgvVirtualDealer)).BeginInit();
            this.ui_cmsVirtualDealer.SuspendLayout();
            this.SuspendLayout();
            // 
            // ui_ndgvVirtualDealer
            // 
            this.ui_ndgvVirtualDealer.AllowUserToAddRows = false;
            this.ui_ndgvVirtualDealer.AllowUserToDeleteRows = false;
            this.ui_ndgvVirtualDealer.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ui_ndgvVirtualDealer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ui_ndgvVirtualDealer.ContextMenuStrip = this.ui_cmsVirtualDealer;
            this.ui_ndgvVirtualDealer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_ndgvVirtualDealer.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.ui_ndgvVirtualDealer.Location = new System.Drawing.Point(0, 0);
            this.ui_ndgvVirtualDealer.Name = "ui_ndgvVirtualDealer";
            this.ui_ndgvVirtualDealer.ReadOnly = true;
            this.ui_ndgvVirtualDealer.RowHeadersVisible = false;
            this.ui_ndgvVirtualDealer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ui_ndgvVirtualDealer.Size = new System.Drawing.Size(673, 241);
            this.ui_ndgvVirtualDealer.TabIndex = 0;
            this.ui_ndgvVirtualDealer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ui_ndgvVirtualDealer_MouseDown);
            // 
            // ui_cmsVirtualDealer
            // 
            this.ui_cmsVirtualDealer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ui_mnuAdd,
            this.ui_mnuEdit,
            this.ui_mnuDelete});
            this.ui_cmsVirtualDealer.Name = "ui_cmsVirtualDealer";
            this.ui_cmsVirtualDealer.Size = new System.Drawing.Size(108, 70);
            // 
            // ui_mnuAdd
            // 
            this.ui_mnuAdd.Name = "ui_mnuAdd";
            this.ui_mnuAdd.Size = new System.Drawing.Size(107, 22);
            this.ui_mnuAdd.Text = "Add";
            this.ui_mnuAdd.Click += new System.EventHandler(this.ui_mnuAdd_Click);
            // 
            // ui_mnuEdit
            // 
            this.ui_mnuEdit.Name = "ui_mnuEdit";
            this.ui_mnuEdit.Size = new System.Drawing.Size(107, 22);
            this.ui_mnuEdit.Text = "Edit";
            this.ui_mnuEdit.Click += new System.EventHandler(this.ui_mnuEdit_Click);
            // 
            // ui_mnuDelete
            // 
            this.ui_mnuDelete.Name = "ui_mnuDelete";
            this.ui_mnuDelete.Size = new System.Drawing.Size(107, 22);
            this.ui_mnuDelete.Text = "Delete";
            this.ui_mnuDelete.Click += new System.EventHandler(this.ui_mnuDelete_Click);
            // 
            // uctlVirtualDealer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ui_ndgvVirtualDealer);
            this.Name = "uctlVirtualDealer";
            this.Size = new System.Drawing.Size(673, 241);
            this.Load += new System.EventHandler(this.uctlVirtualDealer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ui_ndgvVirtualDealer)).EndInit();
            this.ui_cmsVirtualDealer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NDataGridView ui_ndgvVirtualDealer;
        private System.Windows.Forms.ContextMenuStrip ui_cmsVirtualDealer;
        private System.Windows.Forms.ToolStripMenuItem ui_mnuAdd;
        private System.Windows.Forms.ToolStripMenuItem ui_mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem ui_mnuDelete;
    }
}
