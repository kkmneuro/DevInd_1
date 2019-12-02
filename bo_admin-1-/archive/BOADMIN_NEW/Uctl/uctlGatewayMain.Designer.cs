namespace BOADMIN_NEW.Uctl
{
    partial class uctlGatewayMain
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
            this.ui_ndgvGatewayMain = new Nevron.UI.WinForm.Controls.NDataGridView();
            this.ui_cmsGateway = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ui_tsmAddNew = new System.Windows.Forms.ToolStripMenuItem();
            this.ui_tsmEdit = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.ui_ndgvGatewayMain)).BeginInit();
            this.ui_cmsGateway.SuspendLayout();
            this.SuspendLayout();
            // 
            // ui_ndgvGatewayMain
            // 
            this.ui_ndgvGatewayMain.AllowUserToAddRows = false;
            this.ui_ndgvGatewayMain.AllowUserToDeleteRows = false;
            this.ui_ndgvGatewayMain.AllowUserToOrderColumns = true;
            this.ui_ndgvGatewayMain.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.MediumBlue;
            this.ui_ndgvGatewayMain.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ui_ndgvGatewayMain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ui_ndgvGatewayMain.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ui_ndgvGatewayMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ui_ndgvGatewayMain.ContextMenuStrip = this.ui_cmsGateway;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ui_ndgvGatewayMain.DefaultCellStyle = dataGridViewCellStyle2;
            this.ui_ndgvGatewayMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_ndgvGatewayMain.EnableCellCustomDraw = false;
            this.ui_ndgvGatewayMain.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.ui_ndgvGatewayMain.Location = new System.Drawing.Point(0, 0);
            this.ui_ndgvGatewayMain.Name = "ui_ndgvGatewayMain";
            this.ui_ndgvGatewayMain.ReadOnly = true;
            this.ui_ndgvGatewayMain.RowHeadersVisible = false;
            this.ui_ndgvGatewayMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ui_ndgvGatewayMain.Size = new System.Drawing.Size(874, 347);
            this.ui_ndgvGatewayMain.TabIndex = 0;
            this.ui_ndgvGatewayMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.uctlGatewayMain_MouseDown);
            // 
            // ui_cmsGateway
            // 
            this.ui_cmsGateway.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ui_tsmAddNew,
            this.ui_tsmEdit});
            this.ui_cmsGateway.Name = "ui_cmsGateway";
            this.ui_cmsGateway.Size = new System.Drawing.Size(118, 48);
            // 
            // ui_tsmAddNew
            // 
            this.ui_tsmAddNew.Name = "ui_tsmAddNew";
            this.ui_tsmAddNew.Size = new System.Drawing.Size(117, 22);
            this.ui_tsmAddNew.Text = "Add New";
            this.ui_tsmAddNew.Click += new System.EventHandler(this.ui_tsmAddNew_Click);
            // 
            // ui_tsmEdit
            // 
            this.ui_tsmEdit.Name = "ui_tsmEdit";
            this.ui_tsmEdit.Size = new System.Drawing.Size(117, 22);
            this.ui_tsmEdit.Text = "Edit";
            this.ui_tsmEdit.Click += new System.EventHandler(this.ui_tsmEdit_Click);
            // 
            // uctlGatewayMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ui_ndgvGatewayMain);
            this.Name = "uctlGatewayMain";
            this.Size = new System.Drawing.Size(874, 347);
            this.Load += new System.EventHandler(this.uctlGatewayMain_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.uctlGatewayMain_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.ui_ndgvGatewayMain)).EndInit();
            this.ui_cmsGateway.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NDataGridView ui_ndgvGatewayMain;
        private System.Windows.Forms.ContextMenuStrip ui_cmsGateway;
        private System.Windows.Forms.ToolStripMenuItem ui_tsmAddNew;
        private System.Windows.Forms.ToolStripMenuItem ui_tsmEdit;
    }
}
