namespace BOADMIN_NEW.Uctl
{
   public partial class uctlSymbolChildSession
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.nuiPanel1 = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.ui_dtpEndDate = new Nevron.UI.WinForm.Controls.NDateTimePicker();
            this.ui_dtpStartDate = new Nevron.UI.WinForm.Controls.NDateTimePicker();
            this.ui_lblTitle = new System.Windows.Forms.Label();
            this.ui_chkusetimelimit = new System.Windows.Forms.CheckBox();
            this.lblFrom = new System.Windows.Forms.Label();
            this.LblTo = new System.Windows.Forms.Label();
            this.ui_dgvSession = new Nevron.UI.WinForm.Controls.NDataGridView();
            this.nuiPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ui_dgvSession)).BeginInit();
            this.SuspendLayout();
            // 
            // nuiPanel1
            // 
            this.nuiPanel1.Controls.Add(this.ui_dtpEndDate);
            this.nuiPanel1.Controls.Add(this.ui_dtpStartDate);
            this.nuiPanel1.Controls.Add(this.ui_lblTitle);
            this.nuiPanel1.Controls.Add(this.ui_chkusetimelimit);
            this.nuiPanel1.Controls.Add(this.lblFrom);
            this.nuiPanel1.Controls.Add(this.LblTo);
            this.nuiPanel1.Controls.Add(this.ui_dgvSession);
            this.nuiPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nuiPanel1.Location = new System.Drawing.Point(0, 0);
            this.nuiPanel1.Name = "nuiPanel1";
            this.nuiPanel1.Size = new System.Drawing.Size(755, 306);
            this.nuiPanel1.TabIndex = 0;
            this.nuiPanel1.Text = "nuiPanel1";
            this.nuiPanel1.Click += new System.EventHandler(this.nuiPanel1_Click);
            // 
            // ui_dtpEndDate
            // 
            this.ui_dtpEndDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ui_dtpEndDate.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ui_dtpEndDate.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.ui_dtpEndDate.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.ui_dtpEndDate.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.ui_dtpEndDate.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.ui_dtpEndDate.CustomFormat = "MM.dd.yyyy hh:mm";
            this.ui_dtpEndDate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_dtpEndDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ui_dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ui_dtpEndDate.Location = new System.Drawing.Point(610, 280);
            this.ui_dtpEndDate.MinDate = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            this.ui_dtpEndDate.Name = "ui_dtpEndDate";
            this.ui_dtpEndDate.Size = new System.Drawing.Size(127, 22);
            this.ui_dtpEndDate.TabIndex = 1;
            this.ui_dtpEndDate.Visible = false;
            // 
            // ui_dtpStartDate
            // 
            this.ui_dtpStartDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ui_dtpStartDate.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ui_dtpStartDate.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.ui_dtpStartDate.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.ui_dtpStartDate.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.ui_dtpStartDate.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.ui_dtpStartDate.CustomFormat = "MM.dd.yyyy hh:mm";
            this.ui_dtpStartDate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_dtpStartDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ui_dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ui_dtpStartDate.Location = new System.Drawing.Point(308, 280);
            this.ui_dtpStartDate.MinDate = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            this.ui_dtpStartDate.Name = "ui_dtpStartDate";
            this.ui_dtpStartDate.Size = new System.Drawing.Size(127, 22);
            this.ui_dtpStartDate.TabIndex = 0;
            this.ui_dtpStartDate.Visible = false;
            // 
            // ui_lblTitle
            // 
            this.ui_lblTitle.AutoSize = true;
            this.ui_lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblTitle.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_lblTitle.Location = new System.Drawing.Point(18, 12);
            this.ui_lblTitle.Name = "ui_lblTitle";
            this.ui_lblTitle.Size = new System.Drawing.Size(721, 26);
            this.ui_lblTitle.TabIndex = 7;
            this.ui_lblTitle.Text = "Adjustment of working hour for symbol. it is possible to choose days of week, and" +
                " hours of trading. as well as for delivery of\r\nquotes.";
            // 
            // ui_chkusetimelimit
            // 
            this.ui_chkusetimelimit.AutoSize = true;
            this.ui_chkusetimelimit.BackColor = System.Drawing.Color.Transparent;
            this.ui_chkusetimelimit.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_chkusetimelimit.Location = new System.Drawing.Point(21, 283);
            this.ui_chkusetimelimit.Name = "ui_chkusetimelimit";
            this.ui_chkusetimelimit.Size = new System.Drawing.Size(104, 17);
            this.ui_chkusetimelimit.TabIndex = 4;
            this.ui_chkusetimelimit.TabStop = false;
            this.ui_chkusetimelimit.Text = "Use time limit";
            this.ui_chkusetimelimit.UseVisualStyleBackColor = false;
            this.ui_chkusetimelimit.Visible = false;
            this.ui_chkusetimelimit.CheckedChanged += new System.EventHandler(this.ui_chkusetimelimit_CheckedChanged);
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.BackColor = System.Drawing.Color.Transparent;
            this.lblFrom.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.Location = new System.Drawing.Point(268, 285);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(36, 13);
            this.lblFrom.TabIndex = 3;
            this.lblFrom.Text = "From";
            this.lblFrom.Visible = false;
            // 
            // LblTo
            // 
            this.LblTo.AutoSize = true;
            this.LblTo.BackColor = System.Drawing.Color.Transparent;
            this.LblTo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTo.Location = new System.Drawing.Point(584, 285);
            this.LblTo.Name = "LblTo";
            this.LblTo.Size = new System.Drawing.Size(21, 13);
            this.LblTo.TabIndex = 2;
            this.LblTo.Text = "To";
            this.LblTo.Visible = false;
            // 
            // ui_dgvSession
            // 
            this.ui_dgvSession.AllowUserToAddRows = false;
            this.ui_dgvSession.AllowUserToDeleteRows = false;
            this.ui_dgvSession.AllowUserToOrderColumns = true;
            this.ui_dgvSession.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.MediumBlue;
            this.ui_dgvSession.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ui_dgvSession.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ui_dgvSession.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ui_dgvSession.ColumnHeadersHeight = 20;
            this.ui_dgvSession.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ui_dgvSession.Cursor = System.Windows.Forms.Cursors.Default;
            this.ui_dgvSession.EnableCellCustomDraw = false;
            this.ui_dgvSession.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.ui_dgvSession.Location = new System.Drawing.Point(21, 59);
            this.ui_dgvSession.MultiSelect = false;
            this.ui_dgvSession.Name = "ui_dgvSession";
            this.ui_dgvSession.ReadOnly = true;
            this.ui_dgvSession.RowHeadersVisible = false;
            this.ui_dgvSession.RowHeadersWidth = 20;
            this.ui_dgvSession.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ui_dgvSession.Size = new System.Drawing.Size(716, 172);
            this.ui_dgvSession.TabIndex = 3;
            this.ui_dgvSession.UseColumnContextMenu = false;
            this.ui_dgvSession.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ui_dgvSession_MouseDown);
            // 
            // uctlSymbolChildSession
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nuiPanel1);
            this.Name = "uctlSymbolChildSession";
            this.Size = new System.Drawing.Size(755, 306);
            this.Load += new System.EventHandler(this.uctlSymbolChildSession_Load);
            this.nuiPanel1.ResumeLayout(false);
            this.nuiPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ui_dgvSession)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NUIPanel nuiPanel1;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label LblTo;
        private System.Windows.Forms.Label ui_lblTitle;
        internal Nevron.UI.WinForm.Controls.NDataGridView ui_dgvSession;
        internal System.Windows.Forms.CheckBox ui_chkusetimelimit;
        internal Nevron.UI.WinForm.Controls.NDateTimePicker ui_dtpEndDate;
        internal Nevron.UI.WinForm.Controls.NDateTimePicker ui_dtpStartDate;
    }
}
