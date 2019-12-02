namespace BOADMIN_NEW.Uctl
{
    partial class uctlAccountMain
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        /// 
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
            this.ui_dtgAccounts = new Nevron.UI.WinForm.Controls.NDataGridView();
            this.ui_contextmnuCommon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ui_contextmnuCommonNewAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.ui_contextmnuCommonEditAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.ui_contextmnuCommonDeleteAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.Login = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.City = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ui_dtgAccounts)).BeginInit();
            this.ui_contextmnuCommon.SuspendLayout();
            this.SuspendLayout();
            // 
            // ui_dtgAccounts
            // 
            this.ui_dtgAccounts.AllowUserToAddRows = false;
            this.ui_dtgAccounts.AllowUserToDeleteRows = false;
            this.ui_dtgAccounts.AllowUserToOrderColumns = true;
            this.ui_dtgAccounts.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.MediumBlue;
            this.ui_dtgAccounts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ui_dtgAccounts.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ui_dtgAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ui_dtgAccounts.ContextMenuStrip = this.ui_contextmnuCommon;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ui_dtgAccounts.DefaultCellStyle = dataGridViewCellStyle2;
            this.ui_dtgAccounts.DisplayChildRelations = false;
            this.ui_dtgAccounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_dtgAccounts.EnableCellCustomDraw = false;
            this.ui_dtgAccounts.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.ui_dtgAccounts.Location = new System.Drawing.Point(0, 0);
            this.ui_dtgAccounts.MultiSelect = false;
            this.ui_dtgAccounts.Name = "ui_dtgAccounts";
            this.ui_dtgAccounts.ReadOnly = true;
            this.ui_dtgAccounts.RowHeadersVisible = false;
            this.ui_dtgAccounts.RowHeadersWidth = 20;
            this.ui_dtgAccounts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ui_dtgAccounts.Size = new System.Drawing.Size(682, 150);
            this.ui_dtgAccounts.TabIndex = 8;
            this.ui_dtgAccounts.UseColumnContextMenu = false;
            this.ui_dtgAccounts.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ui_dtgAccounts_CellDoubleClick);
            this.ui_dtgAccounts.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.ui_dtgAccounts_DataError);
            this.ui_dtgAccounts.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ui_dtgAccounts_MouseDown);
            // 
            // ui_contextmnuCommon
            // 
            this.ui_contextmnuCommon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ui_contextmnuCommonNewAccount,
            this.ui_contextmnuCommonEditAccount,
            this.ui_contextmnuCommonDeleteAccount});
            this.ui_contextmnuCommon.Name = "ui_contextmnuCommon";
            this.ui_contextmnuCommon.Size = new System.Drawing.Size(203, 70);
            this.ui_contextmnuCommon.Opening += new System.ComponentModel.CancelEventHandler(this.ui_contextmnuCommon_Opening);
            // 
            // ui_contextmnuCommonNewAccount
            // 
            this.ui_contextmnuCommonNewAccount.Name = "ui_contextmnuCommonNewAccount";
            this.ui_contextmnuCommonNewAccount.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Insert)));
            this.ui_contextmnuCommonNewAccount.Size = new System.Drawing.Size(202, 22);
            this.ui_contextmnuCommonNewAccount.Text = "New Account";
            this.ui_contextmnuCommonNewAccount.Click += new System.EventHandler(this.ui_contextmnuCommonNewAccount_Click);
            // 
            // ui_contextmnuCommonEditAccount
            // 
            this.ui_contextmnuCommonEditAccount.Name = "ui_contextmnuCommonEditAccount";
            this.ui_contextmnuCommonEditAccount.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.E)));
            this.ui_contextmnuCommonEditAccount.Size = new System.Drawing.Size(202, 22);
            this.ui_contextmnuCommonEditAccount.Text = "Edit Account";
            this.ui_contextmnuCommonEditAccount.Click += new System.EventHandler(this.ui_contextmnuCommonEditAccount_Click);
            // 
            // ui_contextmnuCommonDeleteAccount
            // 
            this.ui_contextmnuCommonDeleteAccount.Enabled = false;
            this.ui_contextmnuCommonDeleteAccount.Name = "ui_contextmnuCommonDeleteAccount";
            this.ui_contextmnuCommonDeleteAccount.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Delete)));
            this.ui_contextmnuCommonDeleteAccount.Size = new System.Drawing.Size(202, 22);
            this.ui_contextmnuCommonDeleteAccount.Text = "Delete Account";
            this.ui_contextmnuCommonDeleteAccount.Visible = false;
            // 
            // Login
            // 
            this.Login.HeaderText = "Login";
            this.Login.Name = "Login";
            // 
            // colName
            // 
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            // 
            // Group
            // 
            this.Group.HeaderText = "Group";
            this.Group.Name = "Group";
            // 
            // City
            // 
            this.City.HeaderText = "City";
            this.City.Name = "City";
            // 
            // Email
            // 
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            // 
            // Balance
            // 
            this.Balance.HeaderText = "Balance";
            this.Balance.Name = "Balance";
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            // 
            // uctlAccountMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ui_dtgAccounts);
            this.Name = "uctlAccountMain";
            this.Size = new System.Drawing.Size(682, 150);
            this.Load += new System.EventHandler(this.uctlAccountMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ui_dtgAccounts)).EndInit();
            this.ui_contextmnuCommon.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        //private System.Windows.Forms.DataGridViewTextBoxColumn Name_;
        public System.Windows.Forms.ContextMenuStrip ui_contextmnuCommon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Login;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Group;
        private System.Windows.Forms.DataGridViewTextBoxColumn City;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        public Nevron.UI.WinForm.Controls.NDataGridView ui_dtgAccounts;
        public System.Windows.Forms.ToolStripMenuItem ui_contextmnuCommonNewAccount;
        public System.Windows.Forms.ToolStripMenuItem ui_contextmnuCommonEditAccount;
        public System.Windows.Forms.ToolStripMenuItem ui_contextmnuCommonDeleteAccount;
       
       
        
    }
}
