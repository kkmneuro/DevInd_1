namespace BOADMIN_NEW.Uctl
{
    partial class uctlProductContracts
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
            this.ui_ntcProductContracts = new Nevron.UI.WinForm.Controls.NTabControl();
            this.ui_tpContactInformation = new Nevron.UI.WinForm.Controls.NTabPage();
            this.ui_tpSession = new Nevron.UI.WinForm.Controls.NTabPage();
            this.ui_uctlSession = new BOADMIN_NEW.Uctl.uctlSymbolChildSession();
            this.ui_ntpCharges = new Nevron.UI.WinForm.Controls.NTabPage();
            this.ui_txtLongPosition = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_pnlCharges = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.ui_txtShortPositions = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_lblSymbolName = new System.Windows.Forms.Label();
            this.ui_ntxtSymbolName = new Nevron.UI.WinForm.Controls.NTextBox();
            this.lblShortPosition = new System.Windows.Forms.Label();
            this.LblLongPosition = new System.Windows.Forms.Label();
            this.ui_chkEnable = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.ui_npnlControlContainer = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ui_nbtnCancel = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nbtSubmit = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_uctlContractInformation = new BOADMIN_NEW.Uctl.uctlContractInformation();
            this.ui_ntcProductContracts.SuspendLayout();
            this.ui_tpContactInformation.SuspendLayout();
            this.ui_tpSession.SuspendLayout();
            this.ui_ntpCharges.SuspendLayout();
            this.ui_pnlCharges.SuspendLayout();
            this.ui_npnlControlContainer.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ui_ntcProductContracts
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.ui_ntcProductContracts, 3);
            this.ui_ntcProductContracts.Controls.Add(this.ui_tpContactInformation);
            this.ui_ntcProductContracts.Controls.Add(this.ui_tpSession); //namo
            this.ui_ntcProductContracts.Controls.Add(this.ui_ntpCharges);
            this.ui_ntcProductContracts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_ntcProductContracts.Location = new System.Drawing.Point(3, 3);
            this.ui_ntcProductContracts.Name = "ui_ntcProductContracts";
            this.ui_ntcProductContracts.Padding = new System.Windows.Forms.Padding(4, 29, 4, 4);
            this.ui_ntcProductContracts.Selectable = true;
            this.ui_ntcProductContracts.SelectedIndex = 0;
            this.ui_ntcProductContracts.Size = new System.Drawing.Size(766, 391);
            this.ui_ntcProductContracts.TabIndex = 0;
            this.ui_ntcProductContracts.Load += new System.EventHandler(this.ui_ntcProductContracts_Load);
            // 
            // ui_tpContactInformation
            // 
            this.ui_tpContactInformation.Controls.Add(this.ui_uctlContractInformation);
            this.ui_tpContactInformation.Location = new System.Drawing.Point(4, 29);
            this.ui_tpContactInformation.Name = "ui_tpContactInformation";
            this.ui_tpContactInformation.Size = new System.Drawing.Size(758, 358);
            this.ui_tpContactInformation.TabIndex = 1;
            this.ui_tpContactInformation.Text = "Contract Information";
            // 
            // ui_tpSession
            // 
            this.ui_tpSession.Controls.Add(this.ui_uctlSession);
            this.ui_tpSession.Location = new System.Drawing.Point(4, 29);
            this.ui_tpSession.Name = "ui_tpSession";
            this.ui_tpSession.Size = new System.Drawing.Size(758, 358);
            this.ui_tpSession.TabIndex = 2;
            this.ui_tpSession.Text = "Session";
            // 
            // ui_uctlSession
            // 
            this.ui_uctlSession.AutoScroll = true;
            this.ui_uctlSession.BackColor = System.Drawing.SystemColors.Control;
            this.ui_uctlSession.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_uctlSession.Location = new System.Drawing.Point(0, 0);
            this.ui_uctlSession.Name = "ui_uctlSession";
            this.ui_uctlSession.Size = new System.Drawing.Size(758, 358);
            this.ui_uctlSession.TabIndex = 0;
            // 
            // ui_ntpCharges
            // 
            this.ui_ntpCharges.Controls.Add(this.ui_txtLongPosition);
            this.ui_ntpCharges.Controls.Add(this.ui_pnlCharges);
            this.ui_ntpCharges.Location = new System.Drawing.Point(4, 29);
            this.ui_ntpCharges.Name = "ui_ntpCharges";
            this.ui_ntpCharges.Size = new System.Drawing.Size(758, 358);
            this.ui_ntpCharges.TabIndex = 3;
            this.ui_ntpCharges.Text = "Charges";
            // 
            // ui_txtLongPosition
            // 
            this.ui_txtLongPosition.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_txtLongPosition.Location = new System.Drawing.Point(122, 90);
            this.ui_txtLongPosition.Name = "ui_txtLongPosition";
            this.ui_txtLongPosition.Size = new System.Drawing.Size(138, 19);
            this.ui_txtLongPosition.TabIndex = 13;
            // 
            // ui_pnlCharges
            // 
            this.ui_pnlCharges.Controls.Add(this.ui_txtShortPositions);
            this.ui_pnlCharges.Controls.Add(this.ui_lblSymbolName);
            this.ui_pnlCharges.Controls.Add(this.ui_ntxtSymbolName);
            this.ui_pnlCharges.Controls.Add(this.lblShortPosition);
            this.ui_pnlCharges.Controls.Add(this.LblLongPosition);
            this.ui_pnlCharges.Controls.Add(this.ui_chkEnable);
            this.ui_pnlCharges.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_pnlCharges.Location = new System.Drawing.Point(0, 0);
            this.ui_pnlCharges.Name = "ui_pnlCharges";
            this.ui_pnlCharges.Size = new System.Drawing.Size(758, 358);
            this.ui_pnlCharges.TabIndex = 15;
            this.ui_pnlCharges.Text = "nuiPanel1";
            // 
            // ui_txtShortPositions
            // 
            this.ui_txtShortPositions.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_txtShortPositions.Location = new System.Drawing.Point(122, 118);
            this.ui_txtShortPositions.Name = "ui_txtShortPositions";
            this.ui_txtShortPositions.Size = new System.Drawing.Size(138, 19);
            this.ui_txtShortPositions.TabIndex = 14;
            // 
            // ui_lblSymbolName
            // 
            this.ui_lblSymbolName.AutoSize = true;
            this.ui_lblSymbolName.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblSymbolName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_lblSymbolName.Location = new System.Drawing.Point(20, 65);
            this.ui_lblSymbolName.Name = "ui_lblSymbolName";
            this.ui_lblSymbolName.Size = new System.Drawing.Size(96, 13);
            this.ui_lblSymbolName.TabIndex = 14;
            this.ui_lblSymbolName.Text = "Symbol Name :";
            // 
            // ui_ntxtSymbolName
            // 
            this.ui_ntxtSymbolName.Enabled = false;
            this.ui_ntxtSymbolName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_ntxtSymbolName.Location = new System.Drawing.Point(122, 62);
            this.ui_ntxtSymbolName.Name = "ui_ntxtSymbolName";
            this.ui_ntxtSymbolName.ReadOnly = true;
            this.ui_ntxtSymbolName.Size = new System.Drawing.Size(138, 19);
            this.ui_ntxtSymbolName.TabIndex = 15;
            // 
            // lblShortPosition
            // 
            this.lblShortPosition.AutoSize = true;
            this.lblShortPosition.BackColor = System.Drawing.Color.Transparent;
            this.lblShortPosition.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShortPosition.Location = new System.Drawing.Point(19, 121);
            this.lblShortPosition.Name = "lblShortPosition";
            this.lblShortPosition.Size = new System.Drawing.Size(97, 13);
            this.lblShortPosition.TabIndex = 11;
            this.lblShortPosition.Text = "Short positions:";
            // 
            // LblLongPosition
            // 
            this.LblLongPosition.AutoSize = true;
            this.LblLongPosition.BackColor = System.Drawing.Color.Transparent;
            this.LblLongPosition.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblLongPosition.Location = new System.Drawing.Point(29, 93);
            this.LblLongPosition.Name = "LblLongPosition";
            this.LblLongPosition.Size = new System.Drawing.Size(87, 13);
            this.LblLongPosition.TabIndex = 10;
            this.LblLongPosition.Text = "Long position:";
            // 
            // ui_chkEnable
            // 
            this.ui_chkEnable.AutoSize = true;
            this.ui_chkEnable.ButtonProperties.BorderOffset = 2;
            this.ui_chkEnable.Checked = true;
            this.ui_chkEnable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ui_chkEnable.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_chkEnable.Location = new System.Drawing.Point(82, 27);
            this.ui_chkEnable.Name = "ui_chkEnable";
            this.ui_chkEnable.Size = new System.Drawing.Size(64, 17);
            this.ui_chkEnable.TabIndex = 12;
            this.ui_chkEnable.Text = "Enable";
            this.ui_chkEnable.TransparentBackground = true;
            this.ui_chkEnable.UseVisualStyleBackColor = false;
            // 
            // ui_npnlControlContainer
            // 
            this.ui_npnlControlContainer.Controls.Add(this.tableLayoutPanel1);
            this.ui_npnlControlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_npnlControlContainer.Location = new System.Drawing.Point(0, 0);
            this.ui_npnlControlContainer.Name = "ui_npnlControlContainer";
            this.ui_npnlControlContainer.Size = new System.Drawing.Size(774, 441);
            this.ui_npnlControlContainer.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85.77982F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.22018F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 124F));
            this.tableLayoutPanel1.Controls.Add(this.ui_ntcProductContracts, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ui_nbtnCancel, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.ui_nbtSubmit, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.625F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.375F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(772, 439);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // ui_nbtnCancel
            // 
            this.ui_nbtnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ui_nbtnCancel.Location = new System.Drawing.Point(672, 406);
            this.ui_nbtnCancel.Name = "ui_nbtnCancel";
            this.ui_nbtnCancel.Size = new System.Drawing.Size(75, 23);
            this.ui_nbtnCancel.TabIndex = 1;
            this.ui_nbtnCancel.Text = "Cancel";
            this.ui_nbtnCancel.UseVisualStyleBackColor = false;
            this.ui_nbtnCancel.Click += new System.EventHandler(this.ui_nbtnCancel_Click);
            // 
            // ui_nbtSubmit
            // 
            this.ui_nbtSubmit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ui_nbtSubmit.Location = new System.Drawing.Point(563, 406);
            this.ui_nbtSubmit.Name = "ui_nbtSubmit";
            this.ui_nbtSubmit.Size = new System.Drawing.Size(75, 23);
            this.ui_nbtSubmit.TabIndex = 0;
            this.ui_nbtSubmit.Text = "Submit";
            this.ui_nbtSubmit.UseVisualStyleBackColor = false;
            this.ui_nbtSubmit.Click += new System.EventHandler(this.ui_nbtSubmit_Click);
            // 
            // ui_uctlContractInformation
            // 
            this.ui_uctlContractInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_uctlContractInformation.Location = new System.Drawing.Point(0, 0);
            this.ui_uctlContractInformation.Name = "ui_uctlContractInformation";
            this.ui_uctlContractInformation.Size = new System.Drawing.Size(758, 358);
            this.ui_uctlContractInformation.TabIndex = 0;
            // 
            // uctlProductContracts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ui_npnlControlContainer);
            this.Name = "uctlProductContracts";
            this.Size = new System.Drawing.Size(774, 441);
            this.Load += new System.EventHandler(this.uctlProductContracts_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.uctlProductContracts_MouseDown);
            this.ui_ntcProductContracts.ResumeLayout(false);
            this.ui_tpContactInformation.ResumeLayout(false);
            this.ui_tpSession.ResumeLayout(false);
            this.ui_ntpCharges.ResumeLayout(false);
            this.ui_pnlCharges.ResumeLayout(false);
            this.ui_pnlCharges.PerformLayout();
            this.ui_npnlControlContainer.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NTabControl ui_ntcProductContracts;
        private Nevron.UI.WinForm.Controls.NTabPage ui_tpContactInformation;
        private Nevron.UI.WinForm.Controls.NTabPage ui_tpSession;
        private Nevron.UI.WinForm.Controls.NTabPage ui_ntpCharges;
        private uctlSymbolChildSession ui_uctlSession;
        //private uctlContractInformation ui_uctlContractInformation;
        private Nevron.UI.WinForm.Controls.NUIPanel ui_npnlControlContainer;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnCancel;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtSubmit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        internal Nevron.UI.WinForm.Controls.NTextBox ui_txtShortPositions;
        internal Nevron.UI.WinForm.Controls.NTextBox ui_txtLongPosition;
        internal Nevron.UI.WinForm.Controls.NCheckBox ui_chkEnable;
        private System.Windows.Forms.Label lblShortPosition;
        private System.Windows.Forms.Label LblLongPosition;
        private Nevron.UI.WinForm.Controls.NUIPanel ui_pnlCharges;
        private System.Windows.Forms.Label ui_lblSymbolName;
        internal Nevron.UI.WinForm.Controls.NTextBox ui_ntxtSymbolName;
        private uctlContractInformation ui_uctlContractInformation;



    }
}
