namespace CommonLibrary.UserControls
{
    partial class uctlMarketWatchNew
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.nuiPanel1 = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.ui_ndgvMarketWatch = new Nevron.UI.WinForm.Controls.NDataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.customizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ui_mnuSizeToFit = new System.Windows.Forms.ToolStripMenuItem();
            this.ui_mnuGrid = new System.Windows.Forms.ToolStripMenuItem();
            this.nuiPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ui_ndgvMarketWatch)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nuiPanel1
            // 
            this.nuiPanel1.Controls.Add(this.ui_ndgvMarketWatch);
            this.nuiPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nuiPanel1.Location = new System.Drawing.Point(0, 0);
            this.nuiPanel1.Name = "nuiPanel1";
            this.nuiPanel1.Size = new System.Drawing.Size(759, 268);
            this.nuiPanel1.TabIndex = 2;
            this.nuiPanel1.Text = "nuiPanel1";
            // 
            // ui_ndgvMarketWatch
            // 
            this.ui_ndgvMarketWatch.AllowDrop = true;
            this.ui_ndgvMarketWatch.AllowUserToAddRows = false;
            this.ui_ndgvMarketWatch.AllowUserToDeleteRows = false;
            this.ui_ndgvMarketWatch.AllowUserToOrderColumns = true;
            this.ui_ndgvMarketWatch.AllowUserToResizeRows = false;
            this.ui_ndgvMarketWatch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.ui_ndgvMarketWatch.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.ui_ndgvMarketWatch.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ui_ndgvMarketWatch.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ui_ndgvMarketWatch.DefaultCellStyle = dataGridViewCellStyle1;
            this.ui_ndgvMarketWatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_ndgvMarketWatch.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.ui_ndgvMarketWatch.Location = new System.Drawing.Point(0, 0);
            this.ui_ndgvMarketWatch.MultiSelect = false;
            this.ui_ndgvMarketWatch.Name = "ui_ndgvMarketWatch";
            this.ui_ndgvMarketWatch.ReadOnly = true;
            this.ui_ndgvMarketWatch.RowHeadersVisible = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            this.ui_ndgvMarketWatch.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.ui_ndgvMarketWatch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ui_ndgvMarketWatch.Size = new System.Drawing.Size(757, 266);
            this.ui_ndgvMarketWatch.TabIndex = 0;
            this.ui_ndgvMarketWatch.UseColumnContextMenu = false;
            this.ui_ndgvMarketWatch.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ui_ndgvMarketWatch_CellClick);
            this.ui_ndgvMarketWatch.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.ui_ndgvMarketWatch_CellEnter);
            this.ui_ndgvMarketWatch.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.nDataGridView1_DataError);
            this.ui_ndgvMarketWatch.DragDrop += new System.Windows.Forms.DragEventHandler(this.ui_ndgvMarketWatch_DragDrop);
            this.ui_ndgvMarketWatch.DragEnter += new System.Windows.Forms.DragEventHandler(this.ui_ndgvMarketWatch_DragEnter);
            this.ui_ndgvMarketWatch.DragLeave += new System.EventHandler(this.ui_ndgvMarketWatch_DragLeave);
            this.ui_ndgvMarketWatch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ui_ndgvMarketWatch_KeyDown);
            this.ui_ndgvMarketWatch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ui_ndgvMarketWatch_KeyPress);
            this.ui_ndgvMarketWatch.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ui_ndgvMarketWatch_MouseClick);
            this.ui_ndgvMarketWatch.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ui_ndgvMarketWatch_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customizeToolStripMenuItem,
            this.ui_mnuSizeToFit,
            this.ui_mnuGrid});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ShowCheckMargin = true;
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(156, 70);
            // 
            // customizeToolStripMenuItem
            // 
            this.customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
            this.customizeToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.customizeToolStripMenuItem.Text = "Customize Grid";
            this.customizeToolStripMenuItem.Visible = false;
            this.customizeToolStripMenuItem.Click += new System.EventHandler(this.customizeToolStripMenuItem_Click);
            // 
            // ui_mnuSizeToFit
            // 
            this.ui_mnuSizeToFit.Name = "ui_mnuSizeToFit";
            this.ui_mnuSizeToFit.Size = new System.Drawing.Size(155, 22);
            this.ui_mnuSizeToFit.Text = "SizeToFit";
            this.ui_mnuSizeToFit.CheckedChanged += new System.EventHandler(this.ui_mnuSizeToFit_CheckedChanged);
            this.ui_mnuSizeToFit.Click += new System.EventHandler(this.ui_mnuSizeToFit_Click);
            // 
            // ui_mnuGrid
            // 
            this.ui_mnuGrid.Checked = true;
            this.ui_mnuGrid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ui_mnuGrid.Name = "ui_mnuGrid";
            this.ui_mnuGrid.Size = new System.Drawing.Size(155, 22);
            this.ui_mnuGrid.Text = "Grid";
            this.ui_mnuGrid.Click += new System.EventHandler(this.ui_mnuGrid_Click);
            // 
            // uctlMarketWatchNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.nuiPanel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.Name = "uctlMarketWatchNew";
            this.Size = new System.Drawing.Size(759, 268);
            this.Load += new System.EventHandler(this.uctlMarketWatchNew_Load);
            this.nuiPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ui_ndgvMarketWatch)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NUIPanel nuiPanel1;
        public Nevron.UI.WinForm.Controls.NDataGridView ui_ndgvMarketWatch;
        public System.Windows.Forms.ToolStripMenuItem customizeToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem ui_mnuSizeToFit;
        public System.Windows.Forms.ToolStripMenuItem ui_mnuGrid;
        public System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}
