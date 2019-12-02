namespace BOADMIN_NEW.Forms
{
    partial class FrmClient_Accounts
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ui_lblBrokerId = new System.Windows.Forms.Label();
            this.ui_ncmbBrokerIds = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_ncmbBrokerType = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_lblBrokerType = new System.Windows.Forms.Label();
            this.uctlAccountMain1 = new BOADMIN_NEW.Uctl.uctlAccountMain();
            this.lblAccountGroup = new System.Windows.Forms.Label();
            this.ncmbAccountGroup = new Nevron.UI.WinForm.Controls.NComboBox();
            this.lblClientType = new System.Windows.Forms.Label();
            this.ncmdClientType = new Nevron.UI.WinForm.Controls.NComboBox();
            this.lblClientName = new System.Windows.Forms.Label();
            this.ui_ntxtClientName = new Nevron.UI.WinForm.Controls.NTextBox();
            this.lblClientId = new System.Windows.Forms.Label();
            this.ui_ntxtClientId = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_ndtpToRegDate = new Nevron.UI.WinForm.Controls.NDateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.ui_ndtpFromRegDate = new Nevron.UI.WinForm.Controls.NDateTimePicker();
            this.lblRegistrationDate = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tableLayoutPanel1.Controls.Add(this.ui_lblBrokerId, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.ui_ncmbBrokerIds, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.ui_ncmbBrokerType, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.ui_lblBrokerType, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.uctlAccountMain1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblAccountGroup, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ncmbAccountGroup, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblClientType, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.ncmdClientType, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblClientName, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.ui_ntxtClientName, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblClientId, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.ui_ntxtClientId, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.ui_ndtpToRegDate, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.ui_ndtpFromRegDate, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblRegistrationDate, 6, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(924, 411);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // ui_lblBrokerId
            // 
            this.ui_lblBrokerId.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ui_lblBrokerId.AutoSize = true;
            this.ui_lblBrokerId.Location = new System.Drawing.Point(618, 14);
            this.ui_lblBrokerId.Name = "ui_lblBrokerId";
            this.ui_lblBrokerId.Size = new System.Drawing.Size(58, 13);
            this.ui_lblBrokerId.TabIndex = 16;
            this.ui_lblBrokerId.Text = "Broker ID :";
            // 
            // ui_ncmbBrokerIds
            // 
            this.ui_ncmbBrokerIds.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_ncmbBrokerIds.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbBrokerIds.Location = new System.Drawing.Point(618, 40);
            this.ui_ncmbBrokerIds.Name = "ui_ncmbBrokerIds";
            this.ui_ncmbBrokerIds.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ui_ncmbBrokerIds.Size = new System.Drawing.Size(116, 18);
            this.ui_ncmbBrokerIds.TabIndex = 15;
            this.ui_ncmbBrokerIds.Text = "nComboBox1";
            this.ui_ncmbBrokerIds.SelectedIndexChanged += new System.EventHandler(this.ui_ncmbBrokerIds_SelectedIndexChanged);
            // 
            // ui_ncmbBrokerType
            // 
            this.ui_ncmbBrokerType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_ncmbBrokerType.ListProperties.CheckOnClick = true;
            this.ui_ncmbBrokerType.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbBrokerType.Location = new System.Drawing.Point(496, 40);
            this.ui_ncmbBrokerType.Name = "ui_ncmbBrokerType";
            this.ui_ncmbBrokerType.Size = new System.Drawing.Size(116, 18);
            this.ui_ncmbBrokerType.TabIndex = 14;
            this.ui_ncmbBrokerType.SelectedIndexChanged += new System.EventHandler(this.ui_ncmbBrokerType_SelectedIndexChanged);
            // 
            // ui_lblBrokerType
            // 
            this.ui_lblBrokerType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ui_lblBrokerType.AutoSize = true;
            this.ui_lblBrokerType.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblBrokerType.Location = new System.Drawing.Point(518, 14);
            this.ui_lblBrokerType.Name = "ui_lblBrokerType";
            this.ui_lblBrokerType.Size = new System.Drawing.Size(71, 13);
            this.ui_lblBrokerType.TabIndex = 13;
            this.ui_lblBrokerType.Text = "Broker Type :";
            // 
            // uctlAccountMain1
            // 
            this.uctlAccountMain1.AutoScroll = true;
            this.uctlAccountMain1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.SetColumnSpan(this.uctlAccountMain1, 8);
            this.uctlAccountMain1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uctlAccountMain1.Location = new System.Drawing.Point(8, 66);
            this.uctlAccountMain1.Name = "uctlAccountMain1";
            this.uctlAccountMain1.Size = new System.Drawing.Size(908, 337);
            this.uctlAccountMain1.TabIndex = 11;
            // 
            // lblAccountGroup
            // 
            this.lblAccountGroup.AutoSize = true;
            this.lblAccountGroup.Location = new System.Drawing.Point(8, 10);
            this.lblAccountGroup.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lblAccountGroup.Name = "lblAccountGroup";
            this.lblAccountGroup.Size = new System.Drawing.Size(116, 26);
            this.lblAccountGroup.TabIndex = 2;
            this.lblAccountGroup.Text = "Broker Company Name :";
            this.lblAccountGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ncmbAccountGroup
            // 
            this.ncmbAccountGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ncmbAccountGroup.ListProperties.ColumnOnLeft = false;
            this.ncmbAccountGroup.ListProperties.ItemHeight = 18;
            this.ncmbAccountGroup.Location = new System.Drawing.Point(8, 40);
            this.ncmbAccountGroup.Name = "ncmbAccountGroup";
            this.ncmbAccountGroup.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ncmbAccountGroup.Size = new System.Drawing.Size(116, 18);
            this.ncmbAccountGroup.TabIndex = 2;
            this.ncmbAccountGroup.SelectedIndexChanged += new System.EventHandler(this.ncmbAccountGroup_SelectedIndexChanged);
            // 
            // lblClientType
            // 
            this.lblClientType.AutoSize = true;
            this.lblClientType.Location = new System.Drawing.Point(130, 10);
            this.lblClientType.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lblClientType.Name = "lblClientType";
            this.lblClientType.Size = new System.Drawing.Size(66, 13);
            this.lblClientType.TabIndex = 3;
            this.lblClientType.Text = "Client Type :";
            this.lblClientType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ncmdClientType
            // 
            this.ncmdClientType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ncmdClientType.ListProperties.ColumnOnLeft = false;
            this.ncmdClientType.ListProperties.ItemHeight = 18;
            this.ncmdClientType.Location = new System.Drawing.Point(130, 40);
            this.ncmdClientType.Name = "ncmdClientType";
            this.ncmdClientType.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ncmdClientType.Size = new System.Drawing.Size(116, 18);
            this.ncmdClientType.TabIndex = 3;
            this.ncmdClientType.SelectedIndexChanged += new System.EventHandler(this.ncmdClientType_SelectedIndexChanged);
            // 
            // lblClientName
            // 
            this.lblClientName.AutoSize = true;
            this.lblClientName.Location = new System.Drawing.Point(374, 10);
            this.lblClientName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lblClientName.Name = "lblClientName";
            this.lblClientName.Size = new System.Drawing.Size(70, 13);
            this.lblClientName.TabIndex = 1;
            this.lblClientName.Text = "Client Name :";
            this.lblClientName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ui_ntxtClientName
            // 
            this.ui_ntxtClientName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_ntxtClientName.Location = new System.Drawing.Point(374, 40);
            this.ui_ntxtClientName.Name = "ui_ntxtClientName";
            this.ui_ntxtClientName.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_ntxtClientName.Size = new System.Drawing.Size(116, 18);
            this.ui_ntxtClientName.TabIndex = 1;
            this.ui_ntxtClientName.TextChanged += new System.EventHandler(this.ui_ntxtClientName_TextChanged);
            // 
            // lblClientId
            // 
            this.lblClientId.AutoSize = true;
            this.lblClientId.Location = new System.Drawing.Point(252, 10);
            this.lblClientId.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lblClientId.Name = "lblClientId";
            this.lblClientId.Size = new System.Drawing.Size(51, 13);
            this.lblClientId.TabIndex = 0;
            this.lblClientId.Text = "Client Id :";
            this.lblClientId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ui_ntxtClientId
            // 
            this.ui_ntxtClientId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_ntxtClientId.Location = new System.Drawing.Point(252, 40);
            this.ui_ntxtClientId.Name = "ui_ntxtClientId";
            this.ui_ntxtClientId.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_ntxtClientId.Size = new System.Drawing.Size(116, 18);
            this.ui_ntxtClientId.TabIndex = 0;
            this.ui_ntxtClientId.TextChanged += new System.EventHandler(this.ui_ntxtClientId_TextChanged);
            this.ui_ntxtClientId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ui_ntxtClientId_KeyPress);
            // 
            // ui_ndtpToRegDate
            // 
            this.ui_ndtpToRegDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ui_ndtpToRegDate.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(65)))), ((int)(((byte)(181)))));
            this.ui_ndtpToRegDate.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(227)))), ((int)(((byte)(255)))));
            this.ui_ndtpToRegDate.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(149)))));
            this.ui_ndtpToRegDate.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(255)))));
            this.ui_ndtpToRegDate.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.ui_ndtpToRegDate.CustomFormat = "ddMMMyyyy";
            this.ui_ndtpToRegDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(65)))), ((int)(((byte)(181)))));
            this.ui_ndtpToRegDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ui_ndtpToRegDate.Location = new System.Drawing.Point(862, 39);
            this.ui_ndtpToRegDate.Name = "ui_ndtpToRegDate";
            this.ui_ndtpToRegDate.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_ndtpToRegDate.Size = new System.Drawing.Size(19, 21);
            this.ui_ndtpToRegDate.TabIndex = 5;
            this.ui_ndtpToRegDate.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(889, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 12;
            this.label1.Visible = false;
            // 
            // ui_ndtpFromRegDate
            // 
            this.ui_ndtpFromRegDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_ndtpFromRegDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ui_ndtpFromRegDate.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(65)))), ((int)(((byte)(181)))));
            this.ui_ndtpFromRegDate.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(227)))), ((int)(((byte)(255)))));
            this.ui_ndtpFromRegDate.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(149)))));
            this.ui_ndtpFromRegDate.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(255)))));
            this.ui_ndtpFromRegDate.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.ui_ndtpFromRegDate.CustomFormat = "ddMMMyyyy";
            this.ui_ndtpFromRegDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(65)))), ((int)(((byte)(181)))));
            this.ui_ndtpFromRegDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ui_ndtpFromRegDate.Location = new System.Drawing.Point(740, 39);
            this.ui_ndtpFromRegDate.Name = "ui_ndtpFromRegDate";
            this.ui_ndtpFromRegDate.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_ndtpFromRegDate.Size = new System.Drawing.Size(116, 21);
            this.ui_ndtpFromRegDate.TabIndex = 4;
            this.ui_ndtpFromRegDate.Visible = false;
            // 
            // lblRegistrationDate
            // 
            this.lblRegistrationDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRegistrationDate.AutoSize = true;
            this.lblRegistrationDate.Location = new System.Drawing.Point(755, 16);
            this.lblRegistrationDate.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lblRegistrationDate.Name = "lblRegistrationDate";
            this.lblRegistrationDate.Size = new System.Drawing.Size(85, 13);
            this.lblRegistrationDate.TabIndex = 4;
            this.lblRegistrationDate.Text = "From Reg Date :";
            this.lblRegistrationDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblRegistrationDate.Visible = false;
            // 
            // FrmClient_Accounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 411);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmClient_Accounts";
            this.Text = " Client Accounts";
            this.Load += new System.EventHandler(this.FrmClient_Accounts_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmClient_Accounts_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblClientName;
        private System.Windows.Forms.Label lblAccountGroup;
        private System.Windows.Forms.Label lblClientType;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtClientId;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtClientName;
        private Nevron.UI.WinForm.Controls.NComboBox ncmbAccountGroup;
        private Nevron.UI.WinForm.Controls.NComboBox ncmdClientType;
        private BOADMIN_NEW.Uctl.uctlAccountMain uctlAccountMain1;
        private System.Windows.Forms.Label label1;
        private Nevron.UI.WinForm.Controls.NDateTimePicker ui_ndtpToRegDate;
        private System.Windows.Forms.Label lblClientId;
        private System.Windows.Forms.Label lblRegistrationDate;
        private Nevron.UI.WinForm.Controls.NDateTimePicker ui_ndtpFromRegDate;
        private System.Windows.Forms.Label ui_lblBrokerType;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbBrokerType;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbBrokerIds;
        private System.Windows.Forms.Label ui_lblBrokerId;
    }
}