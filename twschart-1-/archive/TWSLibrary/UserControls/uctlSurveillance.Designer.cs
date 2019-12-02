namespace CommonLibrary.UserControls
{
    partial class UctlSurveillance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UctlSurveillance));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ui_npnlControlContainer = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ui_ncmbSide = new Nevron.UI.WinForm.Controls.NComboBox();
            this.nTextBox1 = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_uctlGridSurveillance = new CommonLibrary.UserControls.UctlGrid();
            this.ui_npnlControlContainer.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ui_npnlControlContainer
            // 
            this.ui_npnlControlContainer.Controls.Add(this.tableLayoutPanel1);
            this.ui_npnlControlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_npnlControlContainer.Location = new System.Drawing.Point(0, 0);
            this.ui_npnlControlContainer.Name = "ui_npnlControlContainer";
            this.ui_npnlControlContainer.Size = new System.Drawing.Size(691, 311);
            this.ui_npnlControlContainer.TabIndex = 0;
            this.ui_npnlControlContainer.Text = "nuiPanel1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 340F));
            this.tableLayoutPanel1.Controls.Add(this.ui_uctlGridSurveillance, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.ui_ncmbSide, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.nTextBox1, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(689, 309);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Side :";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(128, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Contract :";
            // 
            // ui_ncmbSide
            // 
            this.ui_ncmbSide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_ncmbSide.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbSide.Location = new System.Drawing.Point(51, 3);
            this.ui_ncmbSide.Name = "ui_ncmbSide";
            this.ui_ncmbSide.Size = new System.Drawing.Size(71, 22);
            this.ui_ncmbSide.TabIndex = 3;
            this.ui_ncmbSide.Text = "nComboBox1";
            // 
            // nTextBox1
            // 
            this.nTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nTextBox1.Location = new System.Drawing.Point(187, 5);
            this.nTextBox1.Name = "nTextBox1";
            this.nTextBox1.Size = new System.Drawing.Size(159, 18);
            this.nTextBox1.TabIndex = 4;
            // 
            // ui_uctlGridSurveillance
            // 
            this.ui_uctlGridSurveillance.AllowUserToAddRows = false;
            this.ui_uctlGridSurveillance.AllowUserToDeleteRows = false;
            this.ui_uctlGridSurveillance.AllowUserToOrderColumns = true;
            this.ui_uctlGridSurveillance.AllowUserToResizeColumns = true;
            this.ui_uctlGridSurveillance.AllowUserToResizeRows = true;
            this.ui_uctlGridSurveillance.AlternatingRowStyle = dataGridViewCellStyle1;
            this.ui_uctlGridSurveillance.AutoSizeColumsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.ui_uctlGridSurveillance.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.ui_uctlGridSurveillance.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ui_uctlGridSurveillance.ClipBoardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithAutoHeaderText;
            this.ui_uctlGridSurveillance.ColumnHeaderHeight = 4;
            this.ui_uctlGridSurveillance.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ui_uctlGridSurveillance.ColumnHeadersCellStyle = dataGridViewCellStyle2;
            this.ui_uctlGridSurveillance.ColumnHeadersHeight = 0;
            this.ui_uctlGridSurveillance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ui_uctlGridSurveillance.ColumnHeadersVisible = true;
            this.tableLayoutPanel1.SetColumnSpan(this.ui_uctlGridSurveillance, 5);
            this.ui_uctlGridSurveillance.DataGridBorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ui_uctlGridSurveillance.DataGridCellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.ui_uctlGridSurveillance.DataGridEditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2;
            this.ui_uctlGridSurveillance.DataGridLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.ui_uctlGridSurveillance.DataGridScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ui_uctlGridSurveillance.DataGridSelectMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ui_uctlGridSurveillance.DataRowStyle = dataGridViewCellStyle3;
            this.ui_uctlGridSurveillance.DataSource = null;
            this.ui_uctlGridSurveillance.DefaultCellStyle = dataGridViewCellStyle3;
            this.ui_uctlGridSurveillance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_uctlGridSurveillance.EnableCellCustomDraw = false;
            this.ui_uctlGridSurveillance.EnableHeaderCustomDraw = true;
            this.ui_uctlGridSurveillance.EnableHeadersVisualStyles = true;
            this.ui_uctlGridSurveillance.EnableMultiSelect = false;
            this.ui_uctlGridSurveillance.EnableSkinning = true;
            this.ui_uctlGridSurveillance.FirstDisplayedScrollingRowIndex = 0;
            this.ui_uctlGridSurveillance.GridForeColor = System.Drawing.SystemColors.ControlText;
            this.ui_uctlGridSurveillance.GridPalette = ((Nevron.UI.WinForm.Controls.NPalette)(resources.GetObject("ui_uctlGridSurveillance.GridPalette")));
            this.ui_uctlGridSurveillance.IColIndex = -1;
            this.ui_uctlGridSurveillance.IRowIndex = -1;
            this.ui_uctlGridSurveillance.IsGridReadOnly = true;
            this.ui_uctlGridSurveillance.IsGridVisible = true;
            this.ui_uctlGridSurveillance.IsRowHeadersVisible = false;
            this.ui_uctlGridSurveillance.Location = new System.Drawing.Point(3, 31);
            this.ui_uctlGridSurveillance.Name = "ui_uctlGridSurveillance";
            this.ui_uctlGridSurveillance.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ui_uctlGridSurveillance.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.ui_uctlGridSurveillance.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            this.ui_uctlGridSurveillance.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.ui_uctlGridSurveillance.Size = new System.Drawing.Size(683, 275);
            this.ui_uctlGridSurveillance.TabIndex = 0;
            this.ui_uctlGridSurveillance.Title = null;
            this.ui_uctlGridSurveillance.Load += new System.EventHandler(this.uctlGrid1_Load);
            // 
            // UctlSurveillance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ui_npnlControlContainer);
            this.Name = "UctlSurveillance";
            this.Size = new System.Drawing.Size(691, 311);
            this.ui_npnlControlContainer.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NUIPanel ui_npnlControlContainer;
        public UctlGrid ui_uctlGridSurveillance;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbSide;
        private Nevron.UI.WinForm.Controls.NTextBox nTextBox1;
    }
}
