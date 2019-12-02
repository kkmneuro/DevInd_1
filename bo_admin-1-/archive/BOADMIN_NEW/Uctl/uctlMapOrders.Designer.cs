namespace BOADMIN_NEW.Uctl
{
    partial class uctlMapOrders
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
            this.ui_nbtnRefresh = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_tlpMapOrders = new System.Windows.Forms.TableLayoutPanel();
            this.ui_ndgvMapOrders = new Nevron.UI.WinForm.Controls.NDataGridView();
            this.ui_lblAccountID = new System.Windows.Forms.Label();
            this.ui_ncmbAccountID = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_ncmbAccountType = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_lblAccountType = new System.Windows.Forms.Label();
            this.ui_tlpMapOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ui_ndgvMapOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // ui_nbtnRefresh
            // 
            this.ui_nbtnRefresh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ui_nbtnRefresh.Location = new System.Drawing.Point(614, 3);
            this.ui_nbtnRefresh.Name = "ui_nbtnRefresh";
            this.ui_nbtnRefresh.Size = new System.Drawing.Size(67, 23);
            this.ui_nbtnRefresh.TabIndex = 21;
            this.ui_nbtnRefresh.Text = "&Refresh";
            this.ui_nbtnRefresh.UseVisualStyleBackColor = false;
            this.ui_nbtnRefresh.Click += new System.EventHandler(this.ui_nbtnRefresh_Click);
            // 
            // ui_tlpMapOrders
            // 
            this.ui_tlpMapOrders.ColumnCount = 6;
            this.ui_tlpMapOrders.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.42424F));
            this.ui_tlpMapOrders.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.57576F));
            this.ui_tlpMapOrders.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.ui_tlpMapOrders.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.ui_tlpMapOrders.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 233F));
            this.ui_tlpMapOrders.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 99F));
            this.ui_tlpMapOrders.Controls.Add(this.ui_ndgvMapOrders, 0, 1);
            this.ui_tlpMapOrders.Controls.Add(this.ui_nbtnRefresh, 5, 0);
            this.ui_tlpMapOrders.Controls.Add(this.ui_ncmbAccountID, 3, 0);
            this.ui_tlpMapOrders.Controls.Add(this.ui_ncmbAccountType, 1, 0);
            this.ui_tlpMapOrders.Controls.Add(this.ui_lblAccountID, 2, 0);
            this.ui_tlpMapOrders.Controls.Add(this.ui_lblAccountType, 0, 0);
            this.ui_tlpMapOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_tlpMapOrders.Location = new System.Drawing.Point(0, 0);
            this.ui_tlpMapOrders.Name = "ui_tlpMapOrders";
            this.ui_tlpMapOrders.RowCount = 2;
            this.ui_tlpMapOrders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.ui_tlpMapOrders.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ui_tlpMapOrders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ui_tlpMapOrders.Size = new System.Drawing.Size(698, 229);
            this.ui_tlpMapOrders.TabIndex = 22;
            // 
            // ui_ndgvMapOrders
            // 
            this.ui_ndgvMapOrders.AllowUserToAddRows = false;
            this.ui_ndgvMapOrders.AllowUserToDeleteRows = false;
            this.ui_ndgvMapOrders.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.MediumBlue;
            this.ui_ndgvMapOrders.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ui_ndgvMapOrders.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ui_tlpMapOrders.SetColumnSpan(this.ui_ndgvMapOrders, 6);
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ui_ndgvMapOrders.DefaultCellStyle = dataGridViewCellStyle2;
            this.ui_ndgvMapOrders.DisplayChildRelations = false;
            this.ui_ndgvMapOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_ndgvMapOrders.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.ui_ndgvMapOrders.Location = new System.Drawing.Point(3, 33);
            this.ui_ndgvMapOrders.Name = "ui_ndgvMapOrders";
            this.ui_ndgvMapOrders.ReadOnly = true;
            this.ui_ndgvMapOrders.RowHeadersVisible = false;
            this.ui_ndgvMapOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ui_ndgvMapOrders.ShowCellErrors = false;
            this.ui_ndgvMapOrders.ShowRowErrors = false;
            this.ui_ndgvMapOrders.Size = new System.Drawing.Size(692, 195);
            this.ui_ndgvMapOrders.TabIndex = 0;
            // 
            // ui_lblAccountID
            // 
            this.ui_lblAccountID.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ui_lblAccountID.AutoSize = true;
            this.ui_lblAccountID.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblAccountID.Location = new System.Drawing.Point(201, 8);
            this.ui_lblAccountID.Name = "ui_lblAccountID";
            this.ui_lblAccountID.Size = new System.Drawing.Size(67, 13);
            this.ui_lblAccountID.TabIndex = 22;
            this.ui_lblAccountID.Text = "Account ID :";
            // 
            // ui_ncmbAccountID
            // 
            this.ui_ncmbAccountID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ui_ncmbAccountID.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("All", -1, false, 0, new System.Drawing.Size(0, 0))});
            this.ui_ncmbAccountID.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbAccountID.Location = new System.Drawing.Point(274, 4);
            this.ui_ncmbAccountID.Name = "ui_ncmbAccountID";
            this.ui_ncmbAccountID.Size = new System.Drawing.Size(88, 22);
            this.ui_ncmbAccountID.TabIndex = 23;
            this.ui_ncmbAccountID.SelectedIndexChanged += new System.EventHandler(this.ui_ncmbAccountID_SelectedIndexChanged);
            // 
            // ui_ncmbAccountType
            // 
            this.ui_ncmbAccountType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ui_ncmbAccountType.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbAccountType.Location = new System.Drawing.Point(87, 4);
            this.ui_ncmbAccountType.Name = "ui_ncmbAccountType";
            this.ui_ncmbAccountType.Size = new System.Drawing.Size(100, 21);
            this.ui_ncmbAccountType.TabIndex = 24;
            this.ui_ncmbAccountType.SelectedIndexChanged += new System.EventHandler(this.ui_ncmbAccountType_SelectedIndexChanged);
            // 
            // ui_lblAccountType
            // 
            this.ui_lblAccountType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ui_lblAccountType.AutoSize = true;
            this.ui_lblAccountType.Location = new System.Drawing.Point(3, 8);
            this.ui_lblAccountType.Name = "ui_lblAccountType";
            this.ui_lblAccountType.Size = new System.Drawing.Size(74, 13);
            this.ui_lblAccountType.TabIndex = 25;
            this.ui_lblAccountType.Text = "Accont Type :";
            // 
            // uctlMapOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.ui_tlpMapOrders);
            this.Name = "uctlMapOrders";
            this.Size = new System.Drawing.Size(698, 229);
            this.Load += new System.EventHandler(this.uctlMapOrders_Load);
            this.ui_tlpMapOrders.ResumeLayout(false);
            this.ui_tlpMapOrders.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ui_ndgvMapOrders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NButton ui_nbtnRefresh;
        private System.Windows.Forms.TableLayoutPanel ui_tlpMapOrders;
        private Nevron.UI.WinForm.Controls.NDataGridView ui_ndgvMapOrders;
        private System.Windows.Forms.Label ui_lblAccountID;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbAccountID;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbAccountType;
        private System.Windows.Forms.Label ui_lblAccountType;

    }
}
