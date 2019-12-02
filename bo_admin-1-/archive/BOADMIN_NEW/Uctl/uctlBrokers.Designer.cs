namespace BOADMIN_NEW.Uctl
{
    partial class uctlBrokers
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
            this.ui_npnlControlContainer = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ui_lblBrokerName = new System.Windows.Forms.Label();
            this.ui_ndgvBrokers = new Nevron.UI.WinForm.Controls.NDataGridView();
            this.ui_cmsBrokers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ui_mnuAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.ui_mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.ui_ncmbBrokerType = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_lblBrokerType = new System.Windows.Forms.Label();
            this.ui_ncmbBrokerName = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_lblBrokerId = new System.Windows.Forms.Label();
            this.ui_ncmbBrokerIds = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_mnuChangePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.ui_npnlControlContainer.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ui_ndgvBrokers)).BeginInit();
            this.ui_cmsBrokers.SuspendLayout();
            this.SuspendLayout();
            // 
            // ui_npnlControlContainer
            // 
            this.ui_npnlControlContainer.AutoScroll = true;
            this.ui_npnlControlContainer.Controls.Add(this.tableLayoutPanel1);
            this.ui_npnlControlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_npnlControlContainer.Location = new System.Drawing.Point(0, 0);
            this.ui_npnlControlContainer.Name = "ui_npnlControlContainer";
            this.ui_npnlControlContainer.Size = new System.Drawing.Size(749, 337);
            this.ui_npnlControlContainer.TabIndex = 0;
            this.ui_npnlControlContainer.Text = "nuiPanel1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.ui_lblBrokerName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ui_ndgvBrokers, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ui_ncmbBrokerType, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.ui_lblBrokerType, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.ui_ncmbBrokerName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.ui_lblBrokerId, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.ui_ncmbBrokerIds, 5, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(3);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(747, 335);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // ui_lblBrokerName
            // 
            this.ui_lblBrokerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_lblBrokerName.AutoSize = true;
            this.ui_lblBrokerName.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblBrokerName.Location = new System.Drawing.Point(6, 10);
            this.ui_lblBrokerName.Name = "ui_lblBrokerName";
            this.ui_lblBrokerName.Size = new System.Drawing.Size(88, 13);
            this.ui_lblBrokerName.TabIndex = 2;
            this.ui_lblBrokerName.Text = "Company Name :";
            // 
            // ui_ndgvBrokers
            // 
            this.ui_ndgvBrokers.AllowUserToAddRows = false;
            this.ui_ndgvBrokers.AllowUserToDeleteRows = false;
            this.ui_ndgvBrokers.AllowUserToOrderColumns = true;
            this.ui_ndgvBrokers.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.MediumBlue;
            this.ui_ndgvBrokers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ui_ndgvBrokers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ui_ndgvBrokers.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ui_ndgvBrokers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.tableLayoutPanel1.SetColumnSpan(this.ui_ndgvBrokers, 7);
            this.ui_ndgvBrokers.ContextMenuStrip = this.ui_cmsBrokers;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ui_ndgvBrokers.DefaultCellStyle = dataGridViewCellStyle2;
            this.ui_ndgvBrokers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_ndgvBrokers.EnableCellCustomDraw = false;
            this.ui_ndgvBrokers.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.ui_ndgvBrokers.Location = new System.Drawing.Point(6, 34);
            this.ui_ndgvBrokers.MultiSelect = false;
            this.ui_ndgvBrokers.Name = "ui_ndgvBrokers";
            this.ui_ndgvBrokers.ReadOnly = true;
            this.ui_ndgvBrokers.RowHeadersVisible = false;
            this.ui_ndgvBrokers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ui_ndgvBrokers.Size = new System.Drawing.Size(737, 295);
            this.ui_ndgvBrokers.TabIndex = 0;
            this.ui_ndgvBrokers.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ui_ndgvBrokers_MouseDown);
            this.ui_ndgvBrokers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ui_ndgvBrokers_CellDoubleClick);
            this.ui_ndgvBrokers.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.ui_ndgvBrokers_RowsAdded);
            this.ui_ndgvBrokers.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.ui_ndgvBrokers_CellMouseEnter);
            // 
            // ui_cmsBrokers
            // 
            this.ui_cmsBrokers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ui_mnuAdd,
            this.ui_mnuEdit,
            this.ui_mnuChangePassword});
            this.ui_cmsBrokers.Name = "ui_cmsBrokers";
            this.ui_cmsBrokers.Size = new System.Drawing.Size(169, 70);
            // 
            // ui_mnuAdd
            // 
            this.ui_mnuAdd.Name = "ui_mnuAdd";
            this.ui_mnuAdd.Size = new System.Drawing.Size(168, 22);
            this.ui_mnuAdd.Text = "Add";
            this.ui_mnuAdd.Click += new System.EventHandler(this.ui_mnuAdd_Click);
            // 
            // ui_mnuEdit
            // 
            this.ui_mnuEdit.Name = "ui_mnuEdit";
            this.ui_mnuEdit.Size = new System.Drawing.Size(168, 22);
            this.ui_mnuEdit.Text = "Edit";
            this.ui_mnuEdit.Click += new System.EventHandler(this.ui_mnuEdit_Click);
            // 
            // ui_ncmbBrokerType
            // 
            this.ui_ncmbBrokerType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_ncmbBrokerType.ListProperties.CheckOnClick = true;
            this.ui_ncmbBrokerType.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbBrokerType.Location = new System.Drawing.Point(346, 6);
            this.ui_ncmbBrokerType.Name = "ui_ncmbBrokerType";
            this.ui_ncmbBrokerType.Size = new System.Drawing.Size(100, 22);
            this.ui_ncmbBrokerType.TabIndex = 1;
            this.ui_ncmbBrokerType.SelectedIndexChanged += new System.EventHandler(this.ui_ncmbBrokerType_SelectedIndexChanged);
            // 
            // ui_lblBrokerType
            // 
            this.ui_lblBrokerType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_lblBrokerType.AutoSize = true;
            this.ui_lblBrokerType.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblBrokerType.Location = new System.Drawing.Point(269, 10);
            this.ui_lblBrokerType.Name = "ui_lblBrokerType";
            this.ui_lblBrokerType.Size = new System.Drawing.Size(71, 13);
            this.ui_lblBrokerType.TabIndex = 4;
            this.ui_lblBrokerType.Text = "Broker Type :";
            // 
            // ui_ncmbBrokerName
            // 
            this.ui_ncmbBrokerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_ncmbBrokerName.ListProperties.CheckOnClick = true;
            this.ui_ncmbBrokerName.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbBrokerName.Location = new System.Drawing.Point(100, 6);
            this.ui_ncmbBrokerName.Name = "ui_ncmbBrokerName";
            this.ui_ncmbBrokerName.Size = new System.Drawing.Size(163, 22);
            this.ui_ncmbBrokerName.TabIndex = 0;
            this.ui_ncmbBrokerName.SelectedIndexChanged += new System.EventHandler(this.ui_ncmbBrokerName_SelectedIndexChanged);
            // 
            // ui_lblBrokerId
            // 
            this.ui_lblBrokerId.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ui_lblBrokerId.AutoSize = true;
            this.ui_lblBrokerId.Location = new System.Drawing.Point(452, 10);
            this.ui_lblBrokerId.Name = "ui_lblBrokerId";
            this.ui_lblBrokerId.Size = new System.Drawing.Size(58, 13);
            this.ui_lblBrokerId.TabIndex = 5;
            this.ui_lblBrokerId.Text = "Broker ID :";
            // 
            // ui_ncmbBrokerIds
            // 
            this.ui_ncmbBrokerIds.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbBrokerIds.Location = new System.Drawing.Point(516, 6);
            this.ui_ncmbBrokerIds.Name = "ui_ncmbBrokerIds";
            this.ui_ncmbBrokerIds.Size = new System.Drawing.Size(100, 22);
            this.ui_ncmbBrokerIds.TabIndex = 6;
            this.ui_ncmbBrokerIds.Text = "nComboBox1";
            this.ui_ncmbBrokerIds.SelectedIndexChanged += new System.EventHandler(this.ui_ncmbBrokerIds_SelectedIndexChanged);
            // 
            // ui_mnuChangePassword
            // 
            this.ui_mnuChangePassword.Name = "ui_mnuChangePassword";
            this.ui_mnuChangePassword.Size = new System.Drawing.Size(168, 22);
            this.ui_mnuChangePassword.Text = "Change Password";
            this.ui_mnuChangePassword.Visible = false;
            this.ui_mnuChangePassword.Click += new System.EventHandler(this.ui_mnuChangePassword_Click);
            // 
            // uctlBrokers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ui_npnlControlContainer);
            this.Name = "uctlBrokers";
            this.Size = new System.Drawing.Size(749, 337);
            this.Load += new System.EventHandler(this.uctlBrokers_Load);
            this.ui_npnlControlContainer.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ui_ndgvBrokers)).EndInit();
            this.ui_cmsBrokers.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NUIPanel ui_npnlControlContainer;
        private Nevron.UI.WinForm.Controls.NDataGridView ui_ndgvBrokers;
        private System.Windows.Forms.Label ui_lblBrokerName;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbBrokerName;
        private System.Windows.Forms.ContextMenuStrip ui_cmsBrokers;
        private System.Windows.Forms.ToolStripMenuItem ui_mnuAdd;
        private System.Windows.Forms.ToolStripMenuItem ui_mnuEdit;
        private System.Windows.Forms.Label ui_lblBrokerType;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbBrokerType;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label ui_lblBrokerId;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbBrokerIds;
        private System.Windows.Forms.ToolStripMenuItem ui_mnuChangePassword;
    }
}
