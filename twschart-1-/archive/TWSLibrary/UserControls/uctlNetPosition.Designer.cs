namespace CommonLibrary.UserControls
{
    partial class UctlNetPosition
    {
        private Nevron.UI.WinForm.Controls.NUIPanel ui_npnlNetPosition;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbContracts;
        private System.Windows.Forms.Label ui_lblContracts;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnHideFilter;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbAccountNo;
        private System.Windows.Forms.Label ui_lblClient;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public UctlGrid ui_uctlGridNetPosition;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UctlNetPosition));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ui_npnlNetPosition = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ui_uctlGridNetPosition = new CommonLibrary.UserControls.UctlGrid();
            this.ui_nbtnHideFilter = new Nevron.UI.WinForm.Controls.NButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.ui_nbtnApply = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_lblClient = new System.Windows.Forms.Label();
            this.ui_ncmbContracts = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_ncmbAccountNo = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_lblContracts = new System.Windows.Forms.Label();
            this.ui_npnlNetPosition.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ui_npnlNetPosition
            // 
            this.ui_npnlNetPosition.Controls.Add(this.tableLayoutPanel1);
            this.ui_npnlNetPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_npnlNetPosition.Location = new System.Drawing.Point(0, 0);
            this.ui_npnlNetPosition.Name = "ui_npnlNetPosition";
            this.ui_npnlNetPosition.Size = new System.Drawing.Size(601, 347);
            this.ui_npnlNetPosition.TabIndex = 0;
            this.ui_npnlNetPosition.Text = "nuiPanel1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.ui_uctlGridNetPosition, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ui_nbtnHideFilter, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(599, 345);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // ui_uctlGridNetPosition
            // 
            this.ui_uctlGridNetPosition.AllowUserToAddRows = false;
            this.ui_uctlGridNetPosition.AllowUserToDeleteRows = true;
            this.ui_uctlGridNetPosition.AllowUserToOrderColumns = false;
            this.ui_uctlGridNetPosition.AllowUserToResizeColumns = true;
            this.ui_uctlGridNetPosition.AllowUserToResizeRows = true;
            this.ui_uctlGridNetPosition.AlternatingRowStyle = dataGridViewCellStyle1;
            this.ui_uctlGridNetPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_uctlGridNetPosition.AutoSizeColumsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.ui_uctlGridNetPosition.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None;
            this.ui_uctlGridNetPosition.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ui_uctlGridNetPosition.ClipBoardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithAutoHeaderText;
            this.ui_uctlGridNetPosition.ColumnHeaderHeight = 4;
            this.ui_uctlGridNetPosition.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ui_uctlGridNetPosition.ColumnHeadersCellStyle = dataGridViewCellStyle2;
            this.ui_uctlGridNetPosition.ColumnHeadersHeight = 0;
            this.ui_uctlGridNetPosition.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ui_uctlGridNetPosition.ColumnHeadersVisible = true;
            this.tableLayoutPanel1.SetColumnSpan(this.ui_uctlGridNetPosition, 2);
            this.ui_uctlGridNetPosition.DataGridBorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ui_uctlGridNetPosition.DataGridCellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.ui_uctlGridNetPosition.DataGridEditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2;
            this.ui_uctlGridNetPosition.DataGridLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.ui_uctlGridNetPosition.DataGridScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ui_uctlGridNetPosition.DataGridSelectMode = System.Windows.Forms.DataGridViewSelectionMode.RowHeaderSelect;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ui_uctlGridNetPosition.DataRowStyle = dataGridViewCellStyle3;
            this.ui_uctlGridNetPosition.DataSource = null;
            this.ui_uctlGridNetPosition.DefaultCellStyle = dataGridViewCellStyle3;
            this.ui_uctlGridNetPosition.EnableCellCustomDraw = true;
            this.ui_uctlGridNetPosition.EnableHeaderCustomDraw = true;
            this.ui_uctlGridNetPosition.EnableHeadersVisualStyles = true;
            this.ui_uctlGridNetPosition.EnableMultiSelect = true;
            this.ui_uctlGridNetPosition.EnableSkinning = true;
            this.ui_uctlGridNetPosition.FirstDisplayedScrollingRowIndex = 0;
            this.ui_uctlGridNetPosition.GridForeColor = System.Drawing.SystemColors.ControlText;
            this.ui_uctlGridNetPosition.GridPalette = ((Nevron.UI.WinForm.Controls.NPalette)(resources.GetObject("ui_uctlGridNetPosition.GridPalette")));
            this.ui_uctlGridNetPosition.IColIndex = -1;
            this.ui_uctlGridNetPosition.IRowIndex = -1;
            this.ui_uctlGridNetPosition.IsGridReadOnly = true;
            this.ui_uctlGridNetPosition.IsGridVisible = true;
            this.ui_uctlGridNetPosition.IsRowHeadersVisible = false;
            this.ui_uctlGridNetPosition.Location = new System.Drawing.Point(4, 32);
            this.ui_uctlGridNetPosition.Margin = new System.Windows.Forms.Padding(4);
            this.ui_uctlGridNetPosition.Name = "ui_uctlGridNetPosition";
            this.ui_uctlGridNetPosition.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ui_uctlGridNetPosition.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.ui_uctlGridNetPosition.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            this.ui_uctlGridNetPosition.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.ui_uctlGridNetPosition.Size = new System.Drawing.Size(651, 309);
            this.ui_uctlGridNetPosition.TabIndex = 0;
            this.ui_uctlGridNetPosition.Title = null;
            this.ui_uctlGridNetPosition.OnGridMouseDown += new System.Windows.Forms.MouseEventHandler(this.ui_uctlGridNetPosition_OnGridMouseDown);
            // 
            // ui_nbtnHideFilter
            // 
            this.ui_nbtnHideFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.ui_nbtnHideFilter.Location = new System.Drawing.Point(3, 3);
            this.ui_nbtnHideFilter.Name = "ui_nbtnHideFilter";
            this.ui_nbtnHideFilter.Size = new System.Drawing.Size(89, 22);
            this.ui_nbtnHideFilter.TabIndex = 0;
            this.ui_nbtnHideFilter.Text = "Hide &Filter >>";
            this.ui_nbtnHideFilter.UseVisualStyleBackColor = false;
            this.ui_nbtnHideFilter.Click += new System.EventHandler(this.ui_nbtnHideFilter_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.ui_nbtnApply, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.ui_lblClient, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.ui_ncmbContracts, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.ui_ncmbAccountNo, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.ui_lblContracts, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(96, 1);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(562, 26);
            this.tableLayoutPanel2.TabIndex = 9;
            this.tableLayoutPanel2.VisibleChanged += new System.EventHandler(this.tableLayoutPanel2_VisibleChanged);
            // 
            // ui_nbtnApply
            // 
            this.ui_nbtnApply.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ui_nbtnApply.Location = new System.Drawing.Point(407, 3);
            this.ui_nbtnApply.Name = "ui_nbtnApply";
            this.ui_nbtnApply.Size = new System.Drawing.Size(87, 20);
            this.ui_nbtnApply.TabIndex = 8;
            this.ui_nbtnApply.Text = "&Apply";
            this.ui_nbtnApply.UseVisualStyleBackColor = false;
            this.ui_nbtnApply.Click += new System.EventHandler(this.ui_nbtnApply_Click);
            // 
            // ui_lblClient
            // 
            this.ui_lblClient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.ui_lblClient.AutoSize = true;
            this.ui_lblClient.Location = new System.Drawing.Point(3, 0);
            this.ui_lblClient.Name = "ui_lblClient";
            this.ui_lblClient.Size = new System.Drawing.Size(70, 26);
            this.ui_lblClient.TabIndex = 4;
            this.ui_lblClient.Text = "Account No :";
            this.ui_lblClient.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ui_ncmbContracts
            // 
            this.ui_ncmbContracts.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ui_ncmbContracts.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbContracts.Location = new System.Drawing.Point(275, 3);
            this.ui_ncmbContracts.Name = "ui_ncmbContracts";
            this.ui_ncmbContracts.Size = new System.Drawing.Size(126, 20);
            this.ui_ncmbContracts.TabIndex = 1;
            // 
            // ui_ncmbAccountNo
            // 
            this.ui_ncmbAccountNo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ui_ncmbAccountNo.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("---SELECT---", -1, false, 0, new System.Drawing.Size(0, 0))});
            this.ui_ncmbAccountNo.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbAccountNo.Location = new System.Drawing.Point(79, 3);
            this.ui_ncmbAccountNo.Name = "ui_ncmbAccountNo";
            this.ui_ncmbAccountNo.Size = new System.Drawing.Size(126, 20);
            this.ui_ncmbAccountNo.TabIndex = 5;
            this.ui_ncmbAccountNo.SelectedIndexChanged += new System.EventHandler(this.ui_ncmbClient_SelectedIndexChanged);
            // 
            // ui_lblContracts
            // 
            this.ui_lblContracts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.ui_lblContracts.AutoSize = true;
            this.ui_lblContracts.Location = new System.Drawing.Point(211, 0);
            this.ui_lblContracts.Name = "ui_lblContracts";
            this.ui_lblContracts.Size = new System.Drawing.Size(58, 26);
            this.ui_lblContracts.TabIndex = 0;
            this.ui_lblContracts.Text = "Contracts :";
            this.ui_lblContracts.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // UctlNetPosition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ui_npnlNetPosition);
            this.Name = "UctlNetPosition";
            this.Size = new System.Drawing.Size(601, 347);
            this.Load += new System.EventHandler(this.uctlNetPosition_Load);
            this.ui_npnlNetPosition.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnApply;


    }
}
