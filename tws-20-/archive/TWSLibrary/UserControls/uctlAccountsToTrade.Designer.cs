namespace CommonLibrary.UserControls
{
    partial class UctlAccountsToTrade
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UctlAccountsToTrade));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ui_npnlControlContainer = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ui_lblDefualtAccount = new System.Windows.Forms.Label();
            this.ui_ncmbDefaultAccount = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_nbtnCancel = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nbtnApply = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_uctlGridAccountsInfo = new CommonLibrary.UserControls.UctlGrid();
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
            this.ui_npnlControlContainer.Size = new System.Drawing.Size(553, 178);
            this.ui_npnlControlContainer.TabIndex = 0;
            this.ui_npnlControlContainer.Text = "nuiPanel1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.ui_lblDefualtAccount, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ui_uctlGridAccountsInfo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ui_ncmbDefaultAccount, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.ui_nbtnCancel, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.ui_nbtnApply, 3, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(551, 176);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // ui_lblDefualtAccount
            // 
            this.ui_lblDefualtAccount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ui_lblDefualtAccount.AutoSize = true;
            this.ui_lblDefualtAccount.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblDefualtAccount.Location = new System.Drawing.Point(3, 155);
            this.ui_lblDefualtAccount.Name = "ui_lblDefualtAccount";
            this.ui_lblDefualtAccount.Size = new System.Drawing.Size(90, 13);
            this.ui_lblDefualtAccount.TabIndex = 1;
            this.ui_lblDefualtAccount.Text = "Default Account :";
            // 
            // ui_ncmbDefaultAccount
            // 
            this.ui_ncmbDefaultAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_ncmbDefaultAccount.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbDefaultAccount.Location = new System.Drawing.Point(99, 152);
            this.ui_ncmbDefaultAccount.Name = "ui_ncmbDefaultAccount";
            this.ui_ncmbDefaultAccount.Size = new System.Drawing.Size(93, 19);
            this.ui_ncmbDefaultAccount.TabIndex = 4;
            this.ui_ncmbDefaultAccount.SelectedIndexChanged += new System.EventHandler(this.ui_ncmbDefaultAccount_SelectedIndexChanged);
            // 
            // ui_nbtnCancel
            // 
            this.ui_nbtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_nbtnCancel.Location = new System.Drawing.Point(474, 150);
            this.ui_nbtnCancel.Name = "ui_nbtnCancel";
            this.ui_nbtnCancel.Size = new System.Drawing.Size(74, 23);
            this.ui_nbtnCancel.TabIndex = 3;
            this.ui_nbtnCancel.Text = "&Cancel";
            this.ui_nbtnCancel.UseVisualStyleBackColor = false;
            this.ui_nbtnCancel.Click += new System.EventHandler(this.ui_nbtnCancel_Click);
            // 
            // ui_nbtnApply
            // 
            this.ui_nbtnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_nbtnApply.Location = new System.Drawing.Point(394, 150);
            this.ui_nbtnApply.Name = "ui_nbtnApply";
            this.ui_nbtnApply.Size = new System.Drawing.Size(74, 23);
            this.ui_nbtnApply.TabIndex = 2;
            this.ui_nbtnApply.Text = "&Apply";
            this.ui_nbtnApply.UseVisualStyleBackColor = false;
            this.ui_nbtnApply.Click += new System.EventHandler(this.ui_nbtnApply_Click);
            // 
            // ui_uctlGridAccountsInfo
            // 
            this.ui_uctlGridAccountsInfo.AllowUserToAddRows = false;
            this.ui_uctlGridAccountsInfo.AllowUserToDeleteRows = false;
            this.ui_uctlGridAccountsInfo.AllowUserToOrderColumns = false;
            this.ui_uctlGridAccountsInfo.AllowUserToResizeColumns = true;
            this.ui_uctlGridAccountsInfo.AllowUserToResizeRows = true;
            this.ui_uctlGridAccountsInfo.AlternatingRowStyle = dataGridViewCellStyle1;
            this.ui_uctlGridAccountsInfo.AutoScroll = true;
            this.ui_uctlGridAccountsInfo.AutoSizeColumsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.ui_uctlGridAccountsInfo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.ui_uctlGridAccountsInfo.BackColor = System.Drawing.SystemColors.Control;
            this.ui_uctlGridAccountsInfo.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ui_uctlGridAccountsInfo.ClipBoardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithAutoHeaderText;
            this.ui_uctlGridAccountsInfo.ColumnHeaderHeight = 23;
            this.ui_uctlGridAccountsInfo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ui_uctlGridAccountsInfo.ColumnHeadersCellStyle = dataGridViewCellStyle2;
            this.ui_uctlGridAccountsInfo.ColumnHeadersHeight = 23;
            this.ui_uctlGridAccountsInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.ui_uctlGridAccountsInfo.ColumnHeadersVisible = true;
            this.tableLayoutPanel1.SetColumnSpan(this.ui_uctlGridAccountsInfo, 5);
            this.ui_uctlGridAccountsInfo.DataGridBorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ui_uctlGridAccountsInfo.DataGridCellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.ui_uctlGridAccountsInfo.DataGridEditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2;
            this.ui_uctlGridAccountsInfo.DataGridLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.ui_uctlGridAccountsInfo.DataGridScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ui_uctlGridAccountsInfo.DataGridSelectMode = System.Windows.Forms.DataGridViewSelectionMode.RowHeaderSelect;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ui_uctlGridAccountsInfo.DataRowStyle = dataGridViewCellStyle3;
            this.ui_uctlGridAccountsInfo.DataSource = null;
            this.ui_uctlGridAccountsInfo.DefaultCellStyle = dataGridViewCellStyle3;
            this.ui_uctlGridAccountsInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_uctlGridAccountsInfo.EnableCellCustomDraw = false;
            this.ui_uctlGridAccountsInfo.EnableHeaderCustomDraw = true;
            this.ui_uctlGridAccountsInfo.EnableHeadersVisualStyles = true;
            this.ui_uctlGridAccountsInfo.EnableMultiSelect = true;
            this.ui_uctlGridAccountsInfo.EnableSkinning = true;
            this.ui_uctlGridAccountsInfo.FirstDisplayedScrollingRowIndex = 0;
            this.ui_uctlGridAccountsInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_uctlGridAccountsInfo.GridForeColor = System.Drawing.SystemColors.ControlText;
            this.ui_uctlGridAccountsInfo.GridPalette = ((Nevron.UI.WinForm.Controls.NPalette)(resources.GetObject("ui_uctlGridAccountsInfo.GridPalette")));
            this.ui_uctlGridAccountsInfo.IColIndex = -1;
            this.ui_uctlGridAccountsInfo.IRowIndex = -1;
            this.ui_uctlGridAccountsInfo.IsGridReadOnly = true;
            this.ui_uctlGridAccountsInfo.IsGridVisible = true;
            this.ui_uctlGridAccountsInfo.IsRowHeadersVisible = false;
            this.ui_uctlGridAccountsInfo.Location = new System.Drawing.Point(6, 6);
            this.ui_uctlGridAccountsInfo.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.ui_uctlGridAccountsInfo.Name = "ui_uctlGridAccountsInfo";
            this.ui_uctlGridAccountsInfo.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ui_uctlGridAccountsInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.ui_uctlGridAccountsInfo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            this.ui_uctlGridAccountsInfo.RowHeight = 23;
            this.ui_uctlGridAccountsInfo.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.ui_uctlGridAccountsInfo.Size = new System.Drawing.Size(539, 135);
            this.ui_uctlGridAccountsInfo.TabIndex = 5;
            this.ui_uctlGridAccountsInfo.Title = null;
            // 
            // UctlAccountsToTrade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ui_npnlControlContainer);
            this.Name = "UctlAccountsToTrade";
            this.Size = new System.Drawing.Size(553, 178);
            this.Load += new System.EventHandler(this.UctlAccountsToTrade_Load);
            this.ui_npnlControlContainer.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NUIPanel ui_npnlControlContainer;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnCancel;
        private System.Windows.Forms.Label ui_lblDefualtAccount;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public UctlGrid ui_uctlGridAccountsInfo;
        public Nevron.UI.WinForm.Controls.NComboBox ui_ncmbDefaultAccount;
        public Nevron.UI.WinForm.Controls.NButton ui_nbtnApply;
    }
}
