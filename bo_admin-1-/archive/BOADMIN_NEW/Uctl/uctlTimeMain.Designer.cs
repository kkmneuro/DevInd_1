namespace BOADMIN_NEW.Uctl
{
    partial class uctlTimeMain
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
            this.ui_dtgTime = new Nevron.UI.WinForm.Controls.NDataGridView();
            this.ui_contextmnuCommon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ui_contextmnuCommonEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.Day = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ui_dtgTime)).BeginInit();
            this.ui_contextmnuCommon.SuspendLayout();
            this.SuspendLayout();
            // 
            // ui_dtgTime
            // 
            this.ui_dtgTime.AllowUserToAddRows = false;
            this.ui_dtgTime.AllowUserToDeleteRows = false;
            this.ui_dtgTime.AllowUserToOrderColumns = true;
            this.ui_dtgTime.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.MediumBlue;
            this.ui_dtgTime.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ui_dtgTime.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ui_dtgTime.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ui_dtgTime.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ui_dtgTime.ContextMenuStrip = this.ui_contextmnuCommon;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ui_dtgTime.DefaultCellStyle = dataGridViewCellStyle2;
            this.ui_dtgTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_dtgTime.EnableCellCustomDraw = false;
            this.ui_dtgTime.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.ui_dtgTime.Location = new System.Drawing.Point(0, 0);
            this.ui_dtgTime.MultiSelect = false;
            this.ui_dtgTime.Name = "ui_dtgTime";
            this.ui_dtgTime.ReadOnly = true;
            this.ui_dtgTime.RowHeadersVisible = false;
            this.ui_dtgTime.RowHeadersWidth = 20;
            this.ui_dtgTime.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ui_dtgTime.Size = new System.Drawing.Size(683, 165);
            this.ui_dtgTime.TabIndex = 2;
            this.ui_dtgTime.UseColumnContextMenu = false;
            this.ui_dtgTime.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ui_dtgTime_MouseDown);
            this.ui_dtgTime.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ui_dtgTime_CellDoubleClick);
            // 
            // ui_contextmnuCommon
            // 
            this.ui_contextmnuCommon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ui_contextmnuCommonEdit});
            this.ui_contextmnuCommon.Name = "ui_contextmnuCommon";
            this.ui_contextmnuCommon.ShowImageMargin = false;
            this.ui_contextmnuCommon.Size = new System.Drawing.Size(102, 26);
            this.ui_contextmnuCommon.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ui_contextmnuCommon_ItemClicked);
            this.ui_contextmnuCommon.Opening += new System.ComponentModel.CancelEventHandler(this.ui_contextmnuCommon_Opening);
            // 
            // ui_contextmnuCommonEdit
            // 
            this.ui_contextmnuCommonEdit.Enabled = false;
            this.ui_contextmnuCommonEdit.Name = "ui_contextmnuCommonEdit";
            this.ui_contextmnuCommonEdit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.E)));
            this.ui_contextmnuCommonEdit.Size = new System.Drawing.Size(101, 22);
            this.ui_contextmnuCommonEdit.Text = "Edit";
            // 
            // Day
            // 
            this.Day.HeaderText = "Day";
            this.Day.Name = "Day";
            this.Day.ReadOnly = true;
            // 
            // Time
            // 
            this.Time.HeaderText = "Time";
            this.Time.Name = "Time";
            this.Time.ReadOnly = true;
            // 
            // uctlTimeMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ui_dtgTime);
            this.Name = "uctlTimeMain";
            this.Size = new System.Drawing.Size(683, 165);
            this.Load += new System.EventHandler(this.uctlTimeMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ui_dtgTime)).EndInit();
            this.ui_contextmnuCommon.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NDataGridView ui_dtgTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Day;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        public System.Windows.Forms.ContextMenuStrip ui_contextmnuCommon;
        private System.Windows.Forms.ToolStripMenuItem ui_contextmnuCommonEdit;
    }
}
