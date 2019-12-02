namespace BOADMIN_NEW.Uctl
{
    partial class uctlTickManagerMain
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
            this.ui_npnlControlContainer = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.ui_tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.ui_ndgvTickManager = new Nevron.UI.WinForm.Controls.NDataGridView();
            this.ui_ntvTickManager = new Nevron.UI.WinForm.Controls.NTreeView();
            this.ui_nbtnExport = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_npnlControlContainer.SuspendLayout();
            this.ui_tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ui_ndgvTickManager)).BeginInit();
            this.SuspendLayout();
            // 
            // ui_npnlControlContainer
            // 
            this.ui_npnlControlContainer.Controls.Add(this.ui_tlpMain);
            this.ui_npnlControlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_npnlControlContainer.Location = new System.Drawing.Point(0, 0);
            this.ui_npnlControlContainer.Name = "ui_npnlControlContainer";
            this.ui_npnlControlContainer.Size = new System.Drawing.Size(726, 341);
            this.ui_npnlControlContainer.TabIndex = 0;
            // 
            // ui_tlpMain
            // 
            this.ui_tlpMain.ColumnCount = 2;
            this.ui_tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.89503F));
            this.ui_tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 76.10497F));
            this.ui_tlpMain.Controls.Add(this.ui_ndgvTickManager, 1, 0);
            this.ui_tlpMain.Controls.Add(this.ui_ntvTickManager, 0, 0);
            this.ui_tlpMain.Controls.Add(this.ui_nbtnExport, 1, 1);
            this.ui_tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_tlpMain.Location = new System.Drawing.Point(0, 0);
            this.ui_tlpMain.Name = "ui_tlpMain";
            this.ui_tlpMain.RowCount = 2;
            this.ui_tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.62537F));
            this.ui_tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.374631F));
            this.ui_tlpMain.Size = new System.Drawing.Size(724, 339);
            this.ui_tlpMain.TabIndex = 0;
            // 
            // ui_ndgvTickManager
            // 
            this.ui_ndgvTickManager.AllowUserToAddRows = false;
            this.ui_ndgvTickManager.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ui_ndgvTickManager.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ui_ndgvTickManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_ndgvTickManager.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.ui_ndgvTickManager.Location = new System.Drawing.Point(176, 3);
            this.ui_ndgvTickManager.Name = "ui_ndgvTickManager";
            this.ui_ndgvTickManager.ReadOnly = true;
            this.ui_ndgvTickManager.RowHeadersVisible = false;
            this.ui_ndgvTickManager.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ui_ndgvTickManager.Size = new System.Drawing.Size(545, 307);
            this.ui_ndgvTickManager.TabIndex = 0;
            this.ui_ndgvTickManager.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ui_ndgvTickManager_CellMouseDoubleClick);
            // 
            // ui_ntvTickManager
            // 
            this.ui_ntvTickManager.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ui_ntvTickManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_ntvTickManager.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.ui_ntvTickManager.Location = new System.Drawing.Point(3, 3);
            this.ui_ntvTickManager.Name = "ui_ntvTickManager";
            this.ui_ntvTickManager.Size = new System.Drawing.Size(167, 307);
            this.ui_ntvTickManager.TabIndex = 1;
            this.ui_ntvTickManager.DoubleClick += new System.EventHandler(this.ui_ntvTickManager_DoubleClick);
            // 
            // ui_nbtnExport
            // 
            this.ui_nbtnExport.Location = new System.Drawing.Point(176, 316);
            this.ui_nbtnExport.Name = "ui_nbtnExport";
            this.ui_nbtnExport.Size = new System.Drawing.Size(75, 20);
            this.ui_nbtnExport.TabIndex = 2;
            this.ui_nbtnExport.Text = "Export";
            this.ui_nbtnExport.Click += new System.EventHandler(this.ui_nbtnExport_Click);
            // 
            // uctlTickManagerMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ui_npnlControlContainer);
            this.Name = "uctlTickManagerMain";
            this.Size = new System.Drawing.Size(726, 341);
            this.Load += new System.EventHandler(this.uctlTickManagerMain_Load);
            this.ui_npnlControlContainer.ResumeLayout(false);
            this.ui_tlpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ui_ndgvTickManager)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NUIPanel ui_npnlControlContainer;
        private System.Windows.Forms.TableLayoutPanel ui_tlpMain;
        private Nevron.UI.WinForm.Controls.NDataGridView ui_ndgvTickManager;
        private Nevron.UI.WinForm.Controls.NTreeView ui_ntvTickManager;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnExport;
    }
}
