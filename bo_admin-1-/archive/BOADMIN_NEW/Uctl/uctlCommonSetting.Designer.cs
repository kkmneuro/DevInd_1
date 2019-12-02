namespace BOADMIN_NEW.Uctl
{
    partial class uctlCommonSetting
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
            this.nuiPanel1 = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ui_ndgvCommonSettings = new Nevron.UI.WinForm.Controls.NDataGridView();
            this.ui_nbtnCancel = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nbtnOk = new Nevron.UI.WinForm.Controls.NButton();
            this.nuiPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ui_ndgvCommonSettings)).BeginInit();
            this.SuspendLayout();
            // 
            // nuiPanel1
            // 
            this.nuiPanel1.Controls.Add(this.tableLayoutPanel1);
            this.nuiPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nuiPanel1.Location = new System.Drawing.Point(0, 0);
            this.nuiPanel1.Name = "nuiPanel1";
            this.nuiPanel1.Size = new System.Drawing.Size(381, 204);
            this.nuiPanel1.TabIndex = 0;
            this.nuiPanel1.Text = "nuiPanel1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.44898F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.55102F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.tableLayoutPanel1.Controls.Add(this.ui_ndgvCommonSettings, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ui_nbtnCancel, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.ui_nbtnOk, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.60221F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.39779F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(379, 202);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // ui_ndgvCommonSettings
            // 
            this.ui_ndgvCommonSettings.AllowUserToAddRows = false;
            this.ui_ndgvCommonSettings.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.MediumBlue;
            this.ui_ndgvCommonSettings.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ui_ndgvCommonSettings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ui_ndgvCommonSettings.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ui_ndgvCommonSettings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.tableLayoutPanel1.SetColumnSpan(this.ui_ndgvCommonSettings, 3);
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(1);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ui_ndgvCommonSettings.DefaultCellStyle = dataGridViewCellStyle2;
            this.ui_ndgvCommonSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_ndgvCommonSettings.EnableCellCustomDraw = false;
            this.ui_ndgvCommonSettings.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.ui_ndgvCommonSettings.Location = new System.Drawing.Point(3, 21);
            this.ui_ndgvCommonSettings.MultiSelect = false;
            this.ui_ndgvCommonSettings.Name = "ui_ndgvCommonSettings";
            this.ui_ndgvCommonSettings.ReadOnly = true;
            this.ui_ndgvCommonSettings.RowHeadersVisible = false;
            this.ui_ndgvCommonSettings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ui_ndgvCommonSettings.Size = new System.Drawing.Size(373, 137);
            this.ui_ndgvCommonSettings.TabIndex = 0;
            this.ui_ndgvCommonSettings.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ui_ndgvCommonSettings_CellClick);
            // 
            // ui_nbtnCancel
            // 
            this.ui_nbtnCancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ui_nbtnCancel.Location = new System.Drawing.Point(297, 169);
            this.ui_nbtnCancel.Name = "ui_nbtnCancel";
            this.ui_nbtnCancel.Size = new System.Drawing.Size(76, 24);
            this.ui_nbtnCancel.TabIndex = 1;
            this.ui_nbtnCancel.Text = "&Cancel";
            this.ui_nbtnCancel.UseVisualStyleBackColor = false;
            this.ui_nbtnCancel.Click += new System.EventHandler(this.ui_nbtnCancel_Click);
            // 
            // ui_nbtnOk
            // 
            this.ui_nbtnOk.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ui_nbtnOk.Location = new System.Drawing.Point(216, 169);
            this.ui_nbtnOk.Name = "ui_nbtnOk";
            this.ui_nbtnOk.Size = new System.Drawing.Size(75, 24);
            this.ui_nbtnOk.TabIndex = 2;
            this.ui_nbtnOk.Text = "&Ok";
            this.ui_nbtnOk.UseVisualStyleBackColor = false;
            this.ui_nbtnOk.Click += new System.EventHandler(this.ui_nbtnOk_Click);
            // 
            // uctlCommonSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nuiPanel1);
            this.Name = "uctlCommonSetting";
            this.Size = new System.Drawing.Size(381, 204);
            this.Load += new System.EventHandler(this.uctlCommonSetting_Load);
            this.nuiPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ui_ndgvCommonSettings)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NUIPanel nuiPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Nevron.UI.WinForm.Controls.NDataGridView ui_ndgvCommonSettings;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnCancel;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnOk;
    }
}
