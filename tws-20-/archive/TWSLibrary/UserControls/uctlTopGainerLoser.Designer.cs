namespace CommonLibrary.UserControls
{
    partial class UctlTopGainerLoser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UctlTopGainerLoser));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ui_npnlTopGainerLoser = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ui_lblInstrumentName = new System.Windows.Forms.Label();
            this.ui_ngbeTopLosers = new Nevron.UI.WinForm.Controls.NGroupBoxEx();
            this.ui_uctlGridTopLosers = new CommonLibrary.UserControls.UctlGrid();
            this.ui_ngbeTopGainers = new Nevron.UI.WinForm.Controls.NGroupBoxEx();
            this.ui_uctlGridTopGainers = new CommonLibrary.UserControls.UctlGrid();
            this.ui_ncmbInstrumentName = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_npnlTopGainerLoser.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ui_ngbeTopLosers)).BeginInit();
            this.ui_ngbeTopLosers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ui_ngbeTopGainers)).BeginInit();
            this.ui_ngbeTopGainers.SuspendLayout();
            this.SuspendLayout();
            // 
            // ui_npnlTopGainerLoser
            // 
            this.ui_npnlTopGainerLoser.Controls.Add(this.tableLayoutPanel1);
            this.ui_npnlTopGainerLoser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_npnlTopGainerLoser.Location = new System.Drawing.Point(0, 0);
            this.ui_npnlTopGainerLoser.Name = "ui_npnlTopGainerLoser";
            this.ui_npnlTopGainerLoser.Size = new System.Drawing.Size(643, 386);
            this.ui_npnlTopGainerLoser.TabIndex = 0;
            this.ui_npnlTopGainerLoser.Text = "nuiPanel1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.ui_lblInstrumentName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ui_ngbeTopLosers, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.ui_ngbeTopGainers, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ui_ncmbInstrumentName, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(641, 384);
            this.tableLayoutPanel1.TabIndex = 5;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // ui_lblInstrumentName
            // 
            this.ui_lblInstrumentName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ui_lblInstrumentName.AutoSize = true;
            this.ui_lblInstrumentName.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblInstrumentName.Location = new System.Drawing.Point(3, 13);
            this.ui_lblInstrumentName.Name = "ui_lblInstrumentName";
            this.ui_lblInstrumentName.Size = new System.Drawing.Size(93, 13);
            this.ui_lblInstrumentName.TabIndex = 0;
            this.ui_lblInstrumentName.Text = "Instrument Name :";
            this.ui_lblInstrumentName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ui_ngbeTopLosers
            // 
            this.ui_ngbeTopLosers.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.SetColumnSpan(this.ui_ngbeTopLosers, 2);
            this.ui_ngbeTopLosers.Controls.Add(this.ui_uctlGridTopLosers);
            this.ui_ngbeTopLosers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_ngbeTopLosers.HeaderFillInfo.Draw = false;
            this.ui_ngbeTopLosers.HeaderItem.Text = "Top Losers";
            this.ui_ngbeTopLosers.HeaderShadowInfo.Draw = false;
            this.ui_ngbeTopLosers.HeaderStrokeInfo.Draw = false;
            this.ui_ngbeTopLosers.Location = new System.Drawing.Point(3, 214);
            this.ui_ngbeTopLosers.Name = "ui_ngbeTopLosers";
            this.ui_ngbeTopLosers.Size = new System.Drawing.Size(635, 167);
            this.ui_ngbeTopLosers.StrokeInfo.Rounding = 5;
            this.ui_ngbeTopLosers.TabIndex = 4;
            this.ui_ngbeTopLosers.Text = "nGroupBoxEx2";
            // 
            // ui_uctlGridTopLosers
            // 
            this.ui_uctlGridTopLosers.AllowUserToAddRows = false;
            this.ui_uctlGridTopLosers.AllowUserToDeleteRows = true;
            this.ui_uctlGridTopLosers.AllowUserToOrderColumns = false;
            this.ui_uctlGridTopLosers.AllowUserToResizeColumns = true;
            this.ui_uctlGridTopLosers.AllowUserToResizeRows = true;
            this.ui_uctlGridTopLosers.AlternatingRowStyle = dataGridViewCellStyle1;
            this.ui_uctlGridTopLosers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_uctlGridTopLosers.AutoSizeColumsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.ui_uctlGridTopLosers.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ui_uctlGridTopLosers.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None;
            this.ui_uctlGridTopLosers.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ui_uctlGridTopLosers.ClipBoardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithAutoHeaderText;
            this.ui_uctlGridTopLosers.ColumnHeaderHeight = 23;
            this.ui_uctlGridTopLosers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ui_uctlGridTopLosers.ColumnHeadersCellStyle = dataGridViewCellStyle2;
            this.ui_uctlGridTopLosers.ColumnHeadersHeight = 0;
            this.ui_uctlGridTopLosers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.ui_uctlGridTopLosers.ColumnHeadersVisible = true;
            this.ui_uctlGridTopLosers.DataGridBorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ui_uctlGridTopLosers.DataGridCellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.ui_uctlGridTopLosers.DataGridEditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2;
            this.ui_uctlGridTopLosers.DataGridLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.ui_uctlGridTopLosers.DataGridScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ui_uctlGridTopLosers.DataGridSelectMode = System.Windows.Forms.DataGridViewSelectionMode.RowHeaderSelect;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ui_uctlGridTopLosers.DataRowStyle = dataGridViewCellStyle3;
            this.ui_uctlGridTopLosers.DataSource = null;
            this.ui_uctlGridTopLosers.DefaultCellStyle = dataGridViewCellStyle3;
            this.ui_uctlGridTopLosers.EnableCellCustomDraw = true;
            this.ui_uctlGridTopLosers.EnableHeaderCustomDraw = true;
            this.ui_uctlGridTopLosers.EnableHeadersVisualStyles = true;
            this.ui_uctlGridTopLosers.EnableMultiSelect = true;
            this.ui_uctlGridTopLosers.EnableSkinning = true;
            this.ui_uctlGridTopLosers.FirstDisplayedScrollingRowIndex = 0;
            this.ui_uctlGridTopLosers.GridForeColor = System.Drawing.SystemColors.ControlText;
            this.ui_uctlGridTopLosers.GridPalette = ((Nevron.UI.WinForm.Controls.NPalette)(resources.GetObject("ui_uctlGridTopLosers.GridPalette")));
            this.ui_uctlGridTopLosers.IColIndex = -1;
            this.ui_uctlGridTopLosers.IRowIndex = -1;
            this.ui_uctlGridTopLosers.IsGridReadOnly = true;
            this.ui_uctlGridTopLosers.IsGridVisible = true;
            this.ui_uctlGridTopLosers.IsRowHeadersVisible = false;
            this.ui_uctlGridTopLosers.Location = new System.Drawing.Point(6, 22);
            this.ui_uctlGridTopLosers.Name = "ui_uctlGridTopLosers";
            this.ui_uctlGridTopLosers.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ui_uctlGridTopLosers.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.ui_uctlGridTopLosers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            this.ui_uctlGridTopLosers.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.ui_uctlGridTopLosers.Size = new System.Drawing.Size(618, 132);
            this.ui_uctlGridTopLosers.TabIndex = 3;
            this.ui_uctlGridTopLosers.Title = null;
            // 
            // ui_ngbeTopGainers
            // 
            this.ui_ngbeTopGainers.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.SetColumnSpan(this.ui_ngbeTopGainers, 2);
            this.ui_ngbeTopGainers.Controls.Add(this.ui_uctlGridTopGainers);
            this.ui_ngbeTopGainers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_ngbeTopGainers.HeaderFillInfo.Draw = false;
            this.ui_ngbeTopGainers.HeaderItem.Text = "Top Gainers";
            this.ui_ngbeTopGainers.HeaderShadowInfo.Draw = false;
            this.ui_ngbeTopGainers.HeaderStrokeInfo.Draw = false;
            this.ui_ngbeTopGainers.Location = new System.Drawing.Point(3, 42);
            this.ui_ngbeTopGainers.Name = "ui_ngbeTopGainers";
            this.ui_ngbeTopGainers.Size = new System.Drawing.Size(635, 166);
            this.ui_ngbeTopGainers.StrokeInfo.Rounding = 5;
            this.ui_ngbeTopGainers.TabIndex = 2;
            this.ui_ngbeTopGainers.Text = "nGroupBoxEx1";
            // 
            // ui_uctlGridTopGainers
            // 
            this.ui_uctlGridTopGainers.AllowUserToAddRows = false;
            this.ui_uctlGridTopGainers.AllowUserToDeleteRows = true;
            this.ui_uctlGridTopGainers.AllowUserToOrderColumns = false;
            this.ui_uctlGridTopGainers.AllowUserToResizeColumns = true;
            this.ui_uctlGridTopGainers.AllowUserToResizeRows = true;
            this.ui_uctlGridTopGainers.AlternatingRowStyle = dataGridViewCellStyle6;
            this.ui_uctlGridTopGainers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_uctlGridTopGainers.AutoSizeColumsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.ui_uctlGridTopGainers.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ui_uctlGridTopGainers.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None;
            this.ui_uctlGridTopGainers.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ui_uctlGridTopGainers.ClipBoardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithAutoHeaderText;
            this.ui_uctlGridTopGainers.ColumnHeaderHeight = 23;
            this.ui_uctlGridTopGainers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ui_uctlGridTopGainers.ColumnHeadersCellStyle = dataGridViewCellStyle7;
            this.ui_uctlGridTopGainers.ColumnHeadersHeight = 0;
            this.ui_uctlGridTopGainers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.ui_uctlGridTopGainers.ColumnHeadersVisible = true;
            this.ui_uctlGridTopGainers.DataGridBorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ui_uctlGridTopGainers.DataGridCellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.ui_uctlGridTopGainers.DataGridEditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2;
            this.ui_uctlGridTopGainers.DataGridLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.ui_uctlGridTopGainers.DataGridScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ui_uctlGridTopGainers.DataGridSelectMode = System.Windows.Forms.DataGridViewSelectionMode.RowHeaderSelect;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ui_uctlGridTopGainers.DataRowStyle = dataGridViewCellStyle8;
            this.ui_uctlGridTopGainers.DataSource = null;
            this.ui_uctlGridTopGainers.DefaultCellStyle = dataGridViewCellStyle8;
            this.ui_uctlGridTopGainers.EnableCellCustomDraw = true;
            this.ui_uctlGridTopGainers.EnableHeaderCustomDraw = true;
            this.ui_uctlGridTopGainers.EnableHeadersVisualStyles = true;
            this.ui_uctlGridTopGainers.EnableMultiSelect = true;
            this.ui_uctlGridTopGainers.EnableSkinning = true;
            this.ui_uctlGridTopGainers.FirstDisplayedScrollingRowIndex = 0;
            this.ui_uctlGridTopGainers.GridForeColor = System.Drawing.SystemColors.ControlText;
            this.ui_uctlGridTopGainers.GridPalette = ((Nevron.UI.WinForm.Controls.NPalette)(resources.GetObject("ui_uctlGridTopGainers.GridPalette")));
            this.ui_uctlGridTopGainers.IColIndex = -1;
            this.ui_uctlGridTopGainers.IRowIndex = -1;
            this.ui_uctlGridTopGainers.IsGridReadOnly = true;
            this.ui_uctlGridTopGainers.IsGridVisible = true;
            this.ui_uctlGridTopGainers.IsRowHeadersVisible = false;
            this.ui_uctlGridTopGainers.Location = new System.Drawing.Point(6, 22);
            this.ui_uctlGridTopGainers.Name = "ui_uctlGridTopGainers";
            this.ui_uctlGridTopGainers.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ui_uctlGridTopGainers.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.ui_uctlGridTopGainers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            this.ui_uctlGridTopGainers.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.ui_uctlGridTopGainers.Size = new System.Drawing.Size(618, 132);
            this.ui_uctlGridTopGainers.TabIndex = 2;
            this.ui_uctlGridTopGainers.Title = null;
            // 
            // ui_ncmbInstrumentName
            // 
            this.ui_ncmbInstrumentName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ui_ncmbInstrumentName.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("---SELECT---", -1, false, 0, new System.Drawing.Size(0, 0))});
            this.ui_ncmbInstrumentName.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbInstrumentName.Location = new System.Drawing.Point(102, 9);
            this.ui_ncmbInstrumentName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.ui_ncmbInstrumentName.Name = "ui_ncmbInstrumentName";
            this.ui_ncmbInstrumentName.Size = new System.Drawing.Size(128, 22);
            this.ui_ncmbInstrumentName.TabIndex = 1;
            // 
            // uctlTopGainerLoser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ui_npnlTopGainerLoser);
            this.Name = "uctlTopGainerLoser";
            this.Size = new System.Drawing.Size(643, 386);
            this.Load += new System.EventHandler(this.uctlTopGainerLoser_Load);
            this.ui_npnlTopGainerLoser.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ui_ngbeTopLosers)).EndInit();
            this.ui_ngbeTopLosers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ui_ngbeTopGainers)).EndInit();
            this.ui_ngbeTopGainers.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NUIPanel ui_npnlTopGainerLoser;
        private Nevron.UI.WinForm.Controls.NGroupBoxEx ui_ngbeTopGainers;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbInstrumentName;
        private System.Windows.Forms.Label ui_lblInstrumentName;
        private UctlGrid ui_uctlGridTopGainers;
        private Nevron.UI.WinForm.Controls.NGroupBoxEx ui_ngbeTopLosers;
        private UctlGrid ui_uctlGridTopLosers;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
