namespace CommonLibrary.UserControls
{
    partial class UctlMostActiveProducts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UctlMostActiveProducts));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ui_npnlControlContainer = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.ui_ncmbInstrumentName = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_ngbUpper = new Nevron.UI.WinForm.Controls.NGroupBox();
            this.ui_uctlGridUpGrid = new CommonLibrary.UserControls.UctlGrid();
            this.ui_ngbDown = new Nevron.UI.WinForm.Controls.NGroupBox();
            this.ui_uctlGridDownGrid = new CommonLibrary.UserControls.UctlGrid();
            this.ui_lblInstrumentName = new System.Windows.Forms.Label();
            this.ui_npnlControlContainer.SuspendLayout();
            this.ui_ngbUpper.SuspendLayout();
            this.ui_ngbDown.SuspendLayout();
            this.SuspendLayout();
            // 
            // ui_npnlControlContainer
            // 
            this.ui_npnlControlContainer.Controls.Add(this.ui_ncmbInstrumentName);
            this.ui_npnlControlContainer.Controls.Add(this.ui_ngbUpper);
            this.ui_npnlControlContainer.Controls.Add(this.ui_ngbDown);
            this.ui_npnlControlContainer.Controls.Add(this.ui_lblInstrumentName);
            this.ui_npnlControlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_npnlControlContainer.Location = new System.Drawing.Point(0, 0);
            this.ui_npnlControlContainer.Name = "ui_npnlControlContainer";
            this.ui_npnlControlContainer.Size = new System.Drawing.Size(710, 341);
            this.ui_npnlControlContainer.TabIndex = 0;
            this.ui_npnlControlContainer.Text = "nuiPanel1";
            // 
            // ui_ncmbInstrumentName
            // 
            this.ui_ncmbInstrumentName.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("---SELECT---", -1, false, 0, new System.Drawing.Size(0, 0))});
            this.ui_ncmbInstrumentName.Location = new System.Drawing.Point(110, 7);
            this.ui_ncmbInstrumentName.Name = "ui_ncmbInstrumentName";
            this.ui_ncmbInstrumentName.Size = new System.Drawing.Size(158, 22);
            this.ui_ncmbInstrumentName.TabIndex = 0;
            this.ui_ncmbInstrumentName.Text = "nComboBox1";
            // 
            // ui_ngbUpper
            // 
            this.ui_ngbUpper.BackColor = System.Drawing.Color.Transparent;
            this.ui_ngbUpper.Controls.Add(this.ui_uctlGridUpGrid);
            this.ui_ngbUpper.Location = new System.Drawing.Point(7, 35);
            this.ui_ngbUpper.Name = "ui_ngbUpper";
            this.ui_ngbUpper.Size = new System.Drawing.Size(694, 144);
            this.ui_ngbUpper.Style = Nevron.UI.WinForm.Controls.GroupBoxStyle.Default;
            this.ui_ngbUpper.TabIndex = 2;
            this.ui_ngbUpper.TabStop = false;
            this.ui_ngbUpper.Text = "Most Active Products by Value";
            // 
            // ui_uctlGridUpGrid
            // 
            this.ui_uctlGridUpGrid.AllowUserToAddRows = false;
            this.ui_uctlGridUpGrid.AllowUserToDeleteRows = true;
            this.ui_uctlGridUpGrid.AllowUserToOrderColumns = false;
            this.ui_uctlGridUpGrid.AllowUserToResizeColumns = true;
            this.ui_uctlGridUpGrid.AllowUserToResizeRows = true;
            this.ui_uctlGridUpGrid.AlternatingRowStyle = dataGridViewCellStyle1;
            this.ui_uctlGridUpGrid.AutoSizeColumsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.ui_uctlGridUpGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None;
            this.ui_uctlGridUpGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ui_uctlGridUpGrid.ClipBoardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithAutoHeaderText;
            this.ui_uctlGridUpGrid.ColumnHeaderHeight = 18;
            this.ui_uctlGridUpGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ui_uctlGridUpGrid.ColumnHeadersCellStyle = dataGridViewCellStyle2;
            this.ui_uctlGridUpGrid.ColumnHeadersHeight = 0;
            this.ui_uctlGridUpGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ui_uctlGridUpGrid.ColumnHeadersVisible = true;
            this.ui_uctlGridUpGrid.DataGridBorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ui_uctlGridUpGrid.DataGridCellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.ui_uctlGridUpGrid.DataGridEditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2;
            this.ui_uctlGridUpGrid.DataGridLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.ui_uctlGridUpGrid.DataGridScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ui_uctlGridUpGrid.DataGridSelectMode = System.Windows.Forms.DataGridViewSelectionMode.RowHeaderSelect;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ui_uctlGridUpGrid.DataRowStyle = dataGridViewCellStyle3;
            this.ui_uctlGridUpGrid.DataSource = null;
            this.ui_uctlGridUpGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.ui_uctlGridUpGrid.EnableCellCustomDraw = true;
            this.ui_uctlGridUpGrid.EnableHeaderCustomDraw = true;
            this.ui_uctlGridUpGrid.EnableHeadersVisualStyles = true;
            this.ui_uctlGridUpGrid.EnableMultiSelect = true;
            this.ui_uctlGridUpGrid.EnableSkinning = true;
            this.ui_uctlGridUpGrid.FirstDisplayedScrollingRowIndex = 0;
            this.ui_uctlGridUpGrid.GridForeColor = System.Drawing.SystemColors.ControlText;
            this.ui_uctlGridUpGrid.GridPalette = ((Nevron.UI.WinForm.Controls.NPalette)(resources.GetObject("ui_uctlGridUpGrid.GridPalette")));
            this.ui_uctlGridUpGrid.IColIndex = -1;
            this.ui_uctlGridUpGrid.IRowIndex = -1;
            this.ui_uctlGridUpGrid.IsGridReadOnly = false;
            this.ui_uctlGridUpGrid.IsGridVisible = true;
            this.ui_uctlGridUpGrid.IsRowHeadersVisible = true;
            this.ui_uctlGridUpGrid.Location = new System.Drawing.Point(7, 17);
            this.ui_uctlGridUpGrid.Name = "ui_uctlGridUpGrid";
            this.ui_uctlGridUpGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ui_uctlGridUpGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.ui_uctlGridUpGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            this.ui_uctlGridUpGrid.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.ui_uctlGridUpGrid.Size = new System.Drawing.Size(681, 119);
            this.ui_uctlGridUpGrid.TabIndex = 0;
            this.ui_uctlGridUpGrid.Title = null;
            // 
            // ui_ngbDown
            // 
            this.ui_ngbDown.BackColor = System.Drawing.Color.Transparent;
            this.ui_ngbDown.Controls.Add(this.ui_uctlGridDownGrid);
            this.ui_ngbDown.Location = new System.Drawing.Point(7, 184);
            this.ui_ngbDown.Name = "ui_ngbDown";
            this.ui_ngbDown.Size = new System.Drawing.Size(694, 144);
            this.ui_ngbDown.Style = Nevron.UI.WinForm.Controls.GroupBoxStyle.Default;
            this.ui_ngbDown.TabIndex = 1;
            this.ui_ngbDown.TabStop = false;
            this.ui_ngbDown.Text = "Most Active Products by Volume";
            // 
            // ui_uctlGridDownGrid
            // 
            this.ui_uctlGridDownGrid.AllowUserToAddRows = false;
            this.ui_uctlGridDownGrid.AllowUserToDeleteRows = true;
            this.ui_uctlGridDownGrid.AllowUserToOrderColumns = false;
            this.ui_uctlGridDownGrid.AllowUserToResizeColumns = true;
            this.ui_uctlGridDownGrid.AllowUserToResizeRows = true;
            this.ui_uctlGridDownGrid.AlternatingRowStyle = dataGridViewCellStyle6;
            this.ui_uctlGridDownGrid.AutoSizeColumsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.ui_uctlGridDownGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None;
            this.ui_uctlGridDownGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ui_uctlGridDownGrid.ClipBoardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithAutoHeaderText;
            this.ui_uctlGridDownGrid.ColumnHeaderHeight = 18;
            this.ui_uctlGridDownGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ui_uctlGridDownGrid.ColumnHeadersCellStyle = dataGridViewCellStyle7;
            this.ui_uctlGridDownGrid.ColumnHeadersHeight = 0;
            this.ui_uctlGridDownGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ui_uctlGridDownGrid.ColumnHeadersVisible = true;
            this.ui_uctlGridDownGrid.DataGridBorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ui_uctlGridDownGrid.DataGridCellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.ui_uctlGridDownGrid.DataGridEditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2;
            this.ui_uctlGridDownGrid.DataGridLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.ui_uctlGridDownGrid.DataGridScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ui_uctlGridDownGrid.DataGridSelectMode = System.Windows.Forms.DataGridViewSelectionMode.RowHeaderSelect;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ui_uctlGridDownGrid.DataRowStyle = dataGridViewCellStyle8;
            this.ui_uctlGridDownGrid.DataSource = null;
            this.ui_uctlGridDownGrid.DefaultCellStyle = dataGridViewCellStyle8;
            this.ui_uctlGridDownGrid.EnableCellCustomDraw = true;
            this.ui_uctlGridDownGrid.EnableHeaderCustomDraw = true;
            this.ui_uctlGridDownGrid.EnableHeadersVisualStyles = true;
            this.ui_uctlGridDownGrid.EnableMultiSelect = true;
            this.ui_uctlGridDownGrid.EnableSkinning = true;
            this.ui_uctlGridDownGrid.FirstDisplayedScrollingRowIndex = 0;
            this.ui_uctlGridDownGrid.GridForeColor = System.Drawing.SystemColors.ControlText;
            this.ui_uctlGridDownGrid.GridPalette = ((Nevron.UI.WinForm.Controls.NPalette)(resources.GetObject("ui_uctlGridDownGrid.GridPalette")));
            this.ui_uctlGridDownGrid.IColIndex = -1;
            this.ui_uctlGridDownGrid.IRowIndex = -1;
            this.ui_uctlGridDownGrid.IsGridReadOnly = false;
            this.ui_uctlGridDownGrid.IsGridVisible = true;
            this.ui_uctlGridDownGrid.IsRowHeadersVisible = true;
            this.ui_uctlGridDownGrid.Location = new System.Drawing.Point(7, 16);
            this.ui_uctlGridDownGrid.Name = "ui_uctlGridDownGrid";
            this.ui_uctlGridDownGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ui_uctlGridDownGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.ui_uctlGridDownGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            this.ui_uctlGridDownGrid.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.ui_uctlGridDownGrid.Size = new System.Drawing.Size(681, 119);
            this.ui_uctlGridDownGrid.TabIndex = 0;
            this.ui_uctlGridDownGrid.Title = null;
            // 
            // ui_lblInstrumentName
            // 
            this.ui_lblInstrumentName.AutoSize = true;
            this.ui_lblInstrumentName.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblInstrumentName.Location = new System.Drawing.Point(11, 12);
            this.ui_lblInstrumentName.Name = "ui_lblInstrumentName";
            this.ui_lblInstrumentName.Size = new System.Drawing.Size(93, 13);
            this.ui_lblInstrumentName.TabIndex = 0;
            this.ui_lblInstrumentName.Text = "Instrument Name :";
            // 
            // UctlMostActiveProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ui_npnlControlContainer);
            this.Name = "UctlMostActiveProducts";
            this.Size = new System.Drawing.Size(710, 341);
            this.ui_npnlControlContainer.ResumeLayout(false);
            this.ui_npnlControlContainer.PerformLayout();
            this.ui_ngbUpper.ResumeLayout(false);
            this.ui_ngbDown.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NUIPanel ui_npnlControlContainer;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbInstrumentName;
        private Nevron.UI.WinForm.Controls.NGroupBox ui_ngbUpper;
        private Nevron.UI.WinForm.Controls.NGroupBox ui_ngbDown;
        private System.Windows.Forms.Label ui_lblInstrumentName;
        private UctlGrid ui_uctlGridUpGrid;
        private UctlGrid ui_uctlGridDownGrid;
    }
}
