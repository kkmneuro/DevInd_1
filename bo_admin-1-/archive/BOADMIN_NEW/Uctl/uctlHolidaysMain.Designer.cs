namespace BOADMIN_NEW.Uctl
{
    partial class uctlHolidaysMain
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
            this.ui_dtgHoliday = new Nevron.UI.WinForm.Controls.NDataGridView();
            this.ui_contextmnuCommon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ui_contextmnuCommonAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.ui_contextmnuCommonEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.ui_contextmnuCommonDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.Day = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.From = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.To = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Securities = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ui_dtgHoliday)).BeginInit();
            this.ui_contextmnuCommon.SuspendLayout();
            this.SuspendLayout();
            // 
            // ui_dtgHoliday
            // 
            this.ui_dtgHoliday.AllowUserToAddRows = false;
            this.ui_dtgHoliday.AllowUserToDeleteRows = false;
            this.ui_dtgHoliday.AllowUserToOrderColumns = true;
            this.ui_dtgHoliday.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.MediumBlue;
            this.ui_dtgHoliday.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ui_dtgHoliday.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ui_dtgHoliday.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ui_dtgHoliday.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ui_dtgHoliday.ContextMenuStrip = this.ui_contextmnuCommon;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ui_dtgHoliday.DefaultCellStyle = dataGridViewCellStyle2;
            this.ui_dtgHoliday.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_dtgHoliday.EnableCellCustomDraw = false;
            this.ui_dtgHoliday.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.ui_dtgHoliday.Location = new System.Drawing.Point(0, 0);
            this.ui_dtgHoliday.MultiSelect = false;
            this.ui_dtgHoliday.Name = "ui_dtgHoliday";
            this.ui_dtgHoliday.ReadOnly = true;
            this.ui_dtgHoliday.RowHeadersVisible = false;
            this.ui_dtgHoliday.RowHeadersWidth = 20;
            this.ui_dtgHoliday.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ui_dtgHoliday.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ui_dtgHoliday.Size = new System.Drawing.Size(721, 225);
            this.ui_dtgHoliday.TabIndex = 3;
            this.ui_dtgHoliday.UseColumnContextMenu = false;
            this.ui_dtgHoliday.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ui_dtgHoliday_MouseDown);
            this.ui_dtgHoliday.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ui_dtgHoliday_CellDoubleClick);
            this.ui_dtgHoliday.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.ui_dtgHoliday_RowsAdded);
            // 
            // ui_contextmnuCommon
            // 
            this.ui_contextmnuCommon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ui_contextmnuCommonAdd,
            this.ui_contextmnuCommonEdit,
            this.ui_contextmnuCommonDelete});
            this.ui_contextmnuCommon.Name = "ui_contextmnuCommon";
            this.ui_contextmnuCommon.ShowImageMargin = false;
            this.ui_contextmnuCommon.Size = new System.Drawing.Size(124, 70);
            this.ui_contextmnuCommon.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ui_contextmnuCommon_ItemClicked);
            this.ui_contextmnuCommon.Opening += new System.ComponentModel.CancelEventHandler(this.ui_contextmnuCommon_Opening);
            // 
            // ui_contextmnuCommonAdd
            // 
            this.ui_contextmnuCommonAdd.Name = "ui_contextmnuCommonAdd";
            this.ui_contextmnuCommonAdd.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Insert)));
            this.ui_contextmnuCommonAdd.Size = new System.Drawing.Size(123, 22);
            this.ui_contextmnuCommonAdd.Text = "Add";
            // 
            // ui_contextmnuCommonEdit
            // 
            this.ui_contextmnuCommonEdit.Enabled = false;
            this.ui_contextmnuCommonEdit.Name = "ui_contextmnuCommonEdit";
            this.ui_contextmnuCommonEdit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.E)));
            this.ui_contextmnuCommonEdit.Size = new System.Drawing.Size(123, 22);
            this.ui_contextmnuCommonEdit.Text = "Edit";
            // 
            // ui_contextmnuCommonDelete
            // 
            this.ui_contextmnuCommonDelete.Enabled = false;
            this.ui_contextmnuCommonDelete.Name = "ui_contextmnuCommonDelete";
            this.ui_contextmnuCommonDelete.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Delete)));
            this.ui_contextmnuCommonDelete.Size = new System.Drawing.Size(123, 22);
            this.ui_contextmnuCommonDelete.Text = "Delete";
            // 
            // Day
            // 
            this.Day.HeaderText = "Day";
            this.Day.Name = "Day";
            this.Day.ReadOnly = true;
            // 
            // From
            // 
            this.From.HeaderText = "From";
            this.From.Name = "From";
            this.From.ReadOnly = true;
            // 
            // To
            // 
            this.To.HeaderText = "To";
            this.To.Name = "To";
            this.To.ReadOnly = true;
            // 
            // Securities
            // 
            this.Securities.HeaderText = "Securities";
            this.Securities.Name = "Securities";
            this.Securities.ReadOnly = true;
            // 
            // Description
            // 
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // uctlHolidaysMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ui_dtgHoliday);
            this.Name = "uctlHolidaysMain";
            this.Size = new System.Drawing.Size(721, 225);
            this.Load += new System.EventHandler(this.uctlHolidaysMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ui_dtgHoliday)).EndInit();
            this.ui_contextmnuCommon.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NDataGridView ui_dtgHoliday;
        private System.Windows.Forms.DataGridViewTextBoxColumn Day;
        private System.Windows.Forms.DataGridViewTextBoxColumn From;
        private System.Windows.Forms.DataGridViewTextBoxColumn To;
        private System.Windows.Forms.DataGridViewTextBoxColumn Securities;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        public System.Windows.Forms.ContextMenuStrip ui_contextmnuCommon;
        private System.Windows.Forms.ToolStripMenuItem ui_contextmnuCommonAdd;
        private System.Windows.Forms.ToolStripMenuItem ui_contextmnuCommonEdit;
        private System.Windows.Forms.ToolStripMenuItem ui_contextmnuCommonDelete;
    }
}
