using System.Windows.Forms;
namespace CommonLibrary.UserControls
{
    partial class UctlGrid
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

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.customizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ui_mnuSizeToFit = new System.Windows.Forms.ToolStripMenuItem();
            this.ui_mnuGrid = new System.Windows.Forms.ToolStripMenuItem();
            this.ui_ndgvGrid = new Nevron.UI.WinForm.Controls.NDataGridView();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ui_ndgvGrid)).BeginInit();
            this.SuspendLayout();
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
            this.contextMenuStrip1.Size = new System.Drawing.Size(157, 70);
            // 
            // customizeToolStripMenuItem
            // 
            this.customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
            this.customizeToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.customizeToolStripMenuItem.Text = "Customize Grid";
            this.customizeToolStripMenuItem.Click += new System.EventHandler(this.customizeToolStripMenuItem_Click);
            // 
            // ui_mnuSizeToFit
            // 
            this.ui_mnuSizeToFit.Name = "ui_mnuSizeToFit";
            this.ui_mnuSizeToFit.Size = new System.Drawing.Size(156, 22);
            this.ui_mnuSizeToFit.Text = "SizeToFit";
            this.ui_mnuSizeToFit.Click += new System.EventHandler(this.ui_mnuSizeToFit_Click);
            // 
            // ui_mnuGrid
            // 
            this.ui_mnuGrid.Checked = true;
            this.ui_mnuGrid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ui_mnuGrid.Name = "ui_mnuGrid";
            this.ui_mnuGrid.Size = new System.Drawing.Size(156, 22);
            this.ui_mnuGrid.Text = "Grid";
            this.ui_mnuGrid.Click += new System.EventHandler(this.ui_mnuGrid_Click);
            // 
            // ui_ndgvGrid
            // 
            this.ui_ndgvGrid.AllowDrop = true;
            this.ui_ndgvGrid.AllowUserToOrderColumns = true;
            this.ui_ndgvGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.ui_ndgvGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.ui_ndgvGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ui_ndgvGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ui_ndgvGrid.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 1, 0, 1);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ui_ndgvGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.ui_ndgvGrid.DisplayChildRelations = false;
            this.ui_ndgvGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_ndgvGrid.EnableCellCustomDraw = false;
            this.ui_ndgvGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.ui_ndgvGrid.Location = new System.Drawing.Point(0, 0);
            this.ui_ndgvGrid.Name = "ui_ndgvGrid";
            this.ui_ndgvGrid.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ui_ndgvGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.ui_ndgvGrid.RowHeadersVisible = false;
            this.ui_ndgvGrid.RowHeadersWidth = 30;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ui_ndgvGrid.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.ui_ndgvGrid.RowTemplate.Height = 20;
            this.ui_ndgvGrid.Size = new System.Drawing.Size(614, 265);
            this.ui_ndgvGrid.TabIndex = 0;
            this.ui_ndgvGrid.UseColumnContextMenu = false;
            this.ui_ndgvGrid.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.ui_ndgvGrid_CellBeginEdit);
            this.ui_ndgvGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ui_ndgvGrid_CellClick);
            this.ui_ndgvGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ui_ndgvGrid_CellContentClick);
            this.ui_ndgvGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.ui_ndgvGrid_CellEndEdit);
            this.ui_ndgvGrid.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.ui_ndgvGrid_CellEnter);
            this.ui_ndgvGrid.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.ui_ndgvGrid_CellMouseEnter);
            this.ui_ndgvGrid.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.ui_ndgvGrid_CellValidating);
            this.ui_ndgvGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.ui_ndgvGrid_CellValueChanged);
            this.ui_ndgvGrid.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.ui_ndgvGrid_CellValueNeeded);
            this.ui_ndgvGrid.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.ui_ndgvGrid_CellValuePushed);
            this.ui_ndgvGrid.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.ui_ndgvGrid_ColumnAdded);
            this.ui_ndgvGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ui_ndgvGrid_ColumnHeaderMouseClick);
            this.ui_ndgvGrid.ColumnRemoved += new System.Windows.Forms.DataGridViewColumnEventHandler(this.ui_ndgvGrid_ColumnRemoved);
            this.ui_ndgvGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.ui_ndgvGrid_DataError);
            this.ui_ndgvGrid.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.ui_ndgvGrid_RowEnter);
            this.ui_ndgvGrid.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.ui_ndgvGrid_RowsAdded);
            this.ui_ndgvGrid.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.ui_ndgvGrid_RowsRemoved);
            this.ui_ndgvGrid.ContextMenuStripChanged += new System.EventHandler(this.ui_ndgvGrid_ContextMenuStripChanged);
            this.ui_ndgvGrid.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ui_ndgvGrid_MouseClick);
            this.ui_ndgvGrid.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ui_ndgvGrid_MouseDown);
            this.ui_ndgvGrid.MouseEnter += new System.EventHandler(this.ui_ndgvGrid_MouseEnter);
            this.ui_ndgvGrid.MouseHover += new System.EventHandler(this.ui_ndgvGrid_MouseHover);
            // 
            // UctlGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.ui_ndgvGrid);
            this.Name = "UctlGrid";
            this.Size = new System.Drawing.Size(614, 265);
            this.Load += new System.EventHandler(this.UctlGrid_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ui_ndgvGrid)).EndInit();
            this.ResumeLayout(false);

        }



        #endregion

        private ToolStripMenuItem customizeToolStripMenuItem;
        private ToolStripMenuItem ui_mnuSizeToFit;
        private ToolStripMenuItem ui_mnuGrid;
        public Nevron.UI.WinForm.Controls.NDataGridView ui_ndgvGrid;




    }
}
