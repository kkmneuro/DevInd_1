
using CommonLibrary.Cls;
namespace PALSA.uctl
{
    partial class uctlMailGrid
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ndgMail = new Nevron.UI.WinForm.Controls.NDataGridView();
            this.colmailDate = new CommonLibrary.Cls.TextAndImageColumn();
            this.colmailTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colmailFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colmailSubject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colmailBody = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctmMail = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctmMailCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.ctmMailView = new System.Windows.Forms.ToolStripMenuItem();
            this.ctmMailDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.autoArrangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textAndImageColumn1 = new CommonLibrary.Cls.TextAndImageColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ndgMail)).BeginInit();
            this.ctmMail.SuspendLayout();
            this.SuspendLayout();
            // 
            // ndgMail
            // 
            this.ndgMail.AllowUserToAddRows = false;
            this.ndgMail.AllowUserToOrderColumns = true;
            this.ndgMail.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.ndgMail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ndgMail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.ndgMail.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(203)))), ((int)(((byte)(203)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ndgMail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.ndgMail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ndgMail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colmailDate,
            this.colmailTo,
            this.colmailFrom,
            this.colmailSubject,
            this.colmailBody,
            this.colDescription});
            this.ndgMail.ContextMenuStrip = this.ctmMail;
            this.ndgMail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ndgMail.EnableCellCustomDraw = false;
            this.ndgMail.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.ndgMail.Location = new System.Drawing.Point(0, 0);
            this.ndgMail.Name = "ndgMail";
            this.ndgMail.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ndgMail.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.ndgMail.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Silver;
            this.ndgMail.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.ndgMail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ndgMail.Size = new System.Drawing.Size(860, 230);
            this.ndgMail.TabIndex = 0;
            this.ndgMail.UseColumnContextMenu = false;
            this.ndgMail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ndgMail_CellContentClick);
            this.ndgMail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ndgMail_KeyDown);
            this.ndgMail.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ndgMail_MouseDoubleClick);
            this.ndgMail.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ndgMail_MouseDown);
            // 
            // colmailDate
            // 
            this.colmailDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colmailDate.HeaderText = "Date";
            this.colmailDate.Image = null;
            this.colmailDate.Name = "colmailDate";
            this.colmailDate.ReadOnly = true;
            // 
            // colmailTo
            // 
            this.colmailTo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colmailTo.HeaderText = "To";
            this.colmailTo.Name = "colmailTo";
            this.colmailTo.ReadOnly = true;
            // 
            // colmailFrom
            // 
            this.colmailFrom.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colmailFrom.HeaderText = "From";
            this.colmailFrom.Name = "colmailFrom";
            this.colmailFrom.ReadOnly = true;
            // 
            // colmailSubject
            // 
            this.colmailSubject.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colmailSubject.HeaderText = "Subject";
            this.colmailSubject.Name = "colmailSubject";
            this.colmailSubject.ReadOnly = true;
            // 
            // colmailBody
            // 
            this.colmailBody.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colmailBody.HeaderText = "Body";
            this.colmailBody.Name = "colmailBody";
            this.colmailBody.ReadOnly = true;
            // 
            // colDescription
            // 
            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.Visible = false;
            this.colDescription.Width = 85;
            // 
            // ctmMail
            // 
            this.ctmMail.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctmMailCreate,
            this.ctmMailView,
            this.ctmMailDelete,
            this.autoArrangeToolStripMenuItem,
            this.gridToolStripMenuItem});
            this.ctmMail.Name = "contextMenuStrip1";
            this.ctmMail.Size = new System.Drawing.Size(165, 114);
            this.ctmMail.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ctmMail_ItemClicked);
            // 
            // ctmMailCreate
            // 
            this.ctmMailCreate.Image = global::PALSA.Properties.Resources.file_strip;
            this.ctmMailCreate.Name = "ctmMailCreate";
            this.ctmMailCreate.ShortcutKeyDisplayString = "Insert";
            this.ctmMailCreate.Size = new System.Drawing.Size(164, 22);
            this.ctmMailCreate.Text = "Create";
            // 
            // ctmMailView
            // 
            this.ctmMailView.Image = global::PALSA.Properties.Resources.file_strip;
            this.ctmMailView.Name = "ctmMailView";
            this.ctmMailView.ShortcutKeyDisplayString = "Enter";
            this.ctmMailView.Size = new System.Drawing.Size(164, 22);
            this.ctmMailView.Text = "View";
            // 
            // ctmMailDelete
            // 
            this.ctmMailDelete.Image = global::PALSA.Properties.Resources.file_strip;
            this.ctmMailDelete.Name = "ctmMailDelete";
            this.ctmMailDelete.ShortcutKeyDisplayString = "Delete";
            this.ctmMailDelete.Size = new System.Drawing.Size(164, 22);
            this.ctmMailDelete.Text = "Delete";
            // 
            // autoArrangeToolStripMenuItem
            // 
            this.autoArrangeToolStripMenuItem.Image = global::PALSA.Properties.Resources.file_strip;
            this.autoArrangeToolStripMenuItem.Name = "autoArrangeToolStripMenuItem";
            this.autoArrangeToolStripMenuItem.ShortcutKeyDisplayString = "A";
            this.autoArrangeToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.autoArrangeToolStripMenuItem.Text = "Auto Arrange";
            // 
            // gridToolStripMenuItem
            // 
            this.gridToolStripMenuItem.Image = global::PALSA.Properties.Resources.file_strip;
            this.gridToolStripMenuItem.Name = "gridToolStripMenuItem";
            this.gridToolStripMenuItem.ShortcutKeyDisplayString = "G";
            this.gridToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.gridToolStripMenuItem.Text = "Grid";
            // 
            // textAndImageColumn1
            // 
            this.textAndImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.textAndImageColumn1.HeaderText = "mailDate";
            this.textAndImageColumn1.Image = null;
            this.textAndImageColumn1.Name = "textAndImageColumn1";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.HeaderText = "To";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "From";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.HeaderText = "Subject";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.HeaderText = "Body";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // uctlMailGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ndgMail);
            this.Name = "uctlMailGrid";
            this.Size = new System.Drawing.Size(860, 230);
            this.Load += new System.EventHandler(this.uctlMailGrid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ndgMail)).EndInit();
            this.ctmMail.ResumeLayout(false);
            this.ResumeLayout(false);

        }      
      
        #endregion

        private System.Windows.Forms.ContextMenuStrip ctmMail;
        private System.Windows.Forms.ToolStripMenuItem ctmMailCreate;
        private System.Windows.Forms.ToolStripMenuItem ctmMailView;
        private System.Windows.Forms.ToolStripMenuItem ctmMailDelete;
        private System.Windows.Forms.ToolStripMenuItem autoArrangeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gridToolStripMenuItem;
        private TextAndImageColumn textAndImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        public Nevron.UI.WinForm.Controls.NDataGridView ndgMail;
        private TextAndImageColumn colmailDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colmailTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colmailFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colmailSubject;
        private System.Windows.Forms.DataGridViewTextBoxColumn colmailBody;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
    }
}
