namespace CommonLibrary.UserControls
{
    partial class UctlParticipantList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UctlParticipantList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ui_npnlParticipantList = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.ui_tlpnlParticipantList = new System.Windows.Forms.TableLayoutPanel();
            this.ui_uctlGridParticipantList = new CommonLibrary.UserControls.UctlGrid();
            this.ui_nsbParticipantList = new Nevron.UI.WinForm.Controls.NStatusBar();
            this.ui_npnlParticipantList.SuspendLayout();
            this.ui_tlpnlParticipantList.SuspendLayout();
            this.SuspendLayout();
            // 
            // ui_npnlParticipantList
            // 
            this.ui_npnlParticipantList.Controls.Add(this.ui_tlpnlParticipantList);
            this.ui_npnlParticipantList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_npnlParticipantList.Location = new System.Drawing.Point(0, 0);
            this.ui_npnlParticipantList.Name = "ui_npnlParticipantList";
            this.ui_npnlParticipantList.Size = new System.Drawing.Size(286, 151);
            this.ui_npnlParticipantList.TabIndex = 0;
            this.ui_npnlParticipantList.Text = "nuiPanel1";
            // 
            // ui_tlpnlParticipantList
            // 
            this.ui_tlpnlParticipantList.BackColor = System.Drawing.Color.Transparent;
            this.ui_tlpnlParticipantList.ColumnCount = 1;
            this.ui_tlpnlParticipantList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ui_tlpnlParticipantList.Controls.Add(this.ui_uctlGridParticipantList, 0, 0);
            this.ui_tlpnlParticipantList.Controls.Add(this.ui_nsbParticipantList, 0, 1);
            this.ui_tlpnlParticipantList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_tlpnlParticipantList.Location = new System.Drawing.Point(0, 0);
            this.ui_tlpnlParticipantList.Name = "ui_tlpnlParticipantList";
            this.ui_tlpnlParticipantList.RowCount = 2;
            this.ui_tlpnlParticipantList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.ui_tlpnlParticipantList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.ui_tlpnlParticipantList.Size = new System.Drawing.Size(284, 149);
            this.ui_tlpnlParticipantList.TabIndex = 1;
            // 
            // ui_uctlGridParticipantList
            // 
            this.ui_uctlGridParticipantList.AllowUserToAddRows = false;
            this.ui_uctlGridParticipantList.AllowUserToDeleteRows = true;
            this.ui_uctlGridParticipantList.AllowUserToOrderColumns = false;
            this.ui_uctlGridParticipantList.AllowUserToResizeColumns = true;
            this.ui_uctlGridParticipantList.AllowUserToResizeRows = true;
            this.ui_uctlGridParticipantList.AlternatingRowStyle = dataGridViewCellStyle1;
            this.ui_uctlGridParticipantList.AutoSizeColumsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ui_uctlGridParticipantList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None;
            this.ui_uctlGridParticipantList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ui_uctlGridParticipantList.ClipBoardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithAutoHeaderText;
            this.ui_uctlGridParticipantList.ColumnHeaderHeight = 4;
            this.ui_uctlGridParticipantList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ui_uctlGridParticipantList.ColumnHeadersCellStyle = dataGridViewCellStyle2;
            this.ui_uctlGridParticipantList.ColumnHeadersHeight = 0;
            this.ui_uctlGridParticipantList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ui_uctlGridParticipantList.ColumnHeadersVisible = true;
            this.ui_uctlGridParticipantList.DataGridBorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ui_uctlGridParticipantList.DataGridCellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.ui_uctlGridParticipantList.DataGridEditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2;
            this.ui_uctlGridParticipantList.DataGridLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.ui_uctlGridParticipantList.DataGridScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ui_uctlGridParticipantList.DataGridSelectMode = System.Windows.Forms.DataGridViewSelectionMode.RowHeaderSelect;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ui_uctlGridParticipantList.DataRowStyle = dataGridViewCellStyle3;
            this.ui_uctlGridParticipantList.DataSource = null;
            this.ui_uctlGridParticipantList.DefaultCellStyle = dataGridViewCellStyle3;
            this.ui_uctlGridParticipantList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_uctlGridParticipantList.EnableCellCustomDraw = true;
            this.ui_uctlGridParticipantList.EnableHeaderCustomDraw = true;
            this.ui_uctlGridParticipantList.EnableHeadersVisualStyles = true;
            this.ui_uctlGridParticipantList.EnableMultiSelect = true;
            this.ui_uctlGridParticipantList.EnableSkinning = true;
            this.ui_uctlGridParticipantList.FirstDisplayedScrollingRowIndex = 0;
            this.ui_uctlGridParticipantList.GridForeColor = System.Drawing.SystemColors.ControlText;
            this.ui_uctlGridParticipantList.GridPalette = ((Nevron.UI.WinForm.Controls.NPalette)(resources.GetObject("ui_uctlGridParticipantList.GridPalette")));
            this.ui_uctlGridParticipantList.IColIndex = -1;
            this.ui_uctlGridParticipantList.IRowIndex = -1;
            this.ui_uctlGridParticipantList.IsGridReadOnly = true;
            this.ui_uctlGridParticipantList.IsGridVisible = true;
            this.ui_uctlGridParticipantList.IsRowHeadersVisible = false;
            this.ui_uctlGridParticipantList.Location = new System.Drawing.Point(3, 3);
            this.ui_uctlGridParticipantList.Name = "ui_uctlGridParticipantList";
            this.ui_uctlGridParticipantList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ui_uctlGridParticipantList.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.ui_uctlGridParticipantList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            this.ui_uctlGridParticipantList.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.ui_uctlGridParticipantList.Size = new System.Drawing.Size(279, 119);
            this.ui_uctlGridParticipantList.TabIndex = 0;
            this.ui_uctlGridParticipantList.Title = null;
            this.ui_uctlGridParticipantList.OnGridMouseDown += new System.Windows.Forms.MouseEventHandler(this.ui_uctlGridParticipantList_OnGridMouseDown);
            // 
            // ui_nsbParticipantList
            // 
            this.ui_nsbParticipantList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_nsbParticipantList.Location = new System.Drawing.Point(3, 128);
            this.ui_nsbParticipantList.Name = "ui_nsbParticipantList";
            this.ui_nsbParticipantList.ShowPanels = true;
            this.ui_nsbParticipantList.Size = new System.Drawing.Size(279, 20);
            this.ui_nsbParticipantList.TabIndex = 1;
            // 
            // UctlParticipantList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ui_npnlParticipantList);
            this.Name = "UctlParticipantList";
            this.Size = new System.Drawing.Size(286, 151);
            this.Load += new System.EventHandler(this.uctlParticipantList_Load);
            this.ui_npnlParticipantList.ResumeLayout(false);
            this.ui_tlpnlParticipantList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NUIPanel ui_npnlParticipantList;
        private System.Windows.Forms.TableLayoutPanel ui_tlpnlParticipantList;
        private Nevron.UI.WinForm.Controls.NStatusBar ui_nsbParticipantList;
        public UctlGrid ui_uctlGridParticipantList;

    }
}
