namespace PALSA.uctl
{
    partial class uctlSelectChartSymbol
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
            this.ui_tlpContainer = new System.Windows.Forms.TableLayoutPanel();
            this.ui_nlstSymbols = new Nevron.UI.WinForm.Controls.NListBox();
            this.ui_nbtnOK = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nbtnCancel = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nlstPeriodicity = new Nevron.UI.WinForm.Controls.NListBox();
            this.ui_npnlControlContainer.SuspendLayout();
            this.ui_tlpContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // ui_npnlControlContainer
            // 
            this.ui_npnlControlContainer.Controls.Add(this.ui_tlpContainer);
            this.ui_npnlControlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_npnlControlContainer.Location = new System.Drawing.Point(0, 0);
            this.ui_npnlControlContainer.Name = "ui_npnlControlContainer";
            this.ui_npnlControlContainer.Size = new System.Drawing.Size(279, 285);
            this.ui_npnlControlContainer.TabIndex = 0;
            this.ui_npnlControlContainer.Text = "nuiPanel1";
            // 
            // ui_tlpContainer
            // 
            this.ui_tlpContainer.ColumnCount = 2;
            this.ui_tlpContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.83582F));
            this.ui_tlpContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.16418F));
            this.ui_tlpContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ui_tlpContainer.Controls.Add(this.ui_nlstSymbols, 0, 0);
            this.ui_tlpContainer.Controls.Add(this.ui_nbtnOK, 0, 1);
            this.ui_tlpContainer.Controls.Add(this.ui_nbtnCancel, 1, 1);
            this.ui_tlpContainer.Controls.Add(this.ui_nlstPeriodicity, 1, 0);
            this.ui_tlpContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_tlpContainer.Location = new System.Drawing.Point(0, 0);
            this.ui_tlpContainer.Name = "ui_tlpContainer";
            this.ui_tlpContainer.RowCount = 2;
            this.ui_tlpContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.04594F));
            this.ui_tlpContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.95406F));
            this.ui_tlpContainer.Size = new System.Drawing.Size(277, 283);
            this.ui_tlpContainer.TabIndex = 0;
            // 
            // ui_nlstSymbols
            // 
            this.ui_nlstSymbols.ColumnOnLeft = false;
            this.ui_nlstSymbols.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_nlstSymbols.Location = new System.Drawing.Point(3, 3);
            this.ui_nlstSymbols.Name = "ui_nlstSymbols";
            this.ui_nlstSymbols.Size = new System.Drawing.Size(154, 246);
            this.ui_nlstSymbols.TabIndex = 0;
            // 
            // ui_nbtnOK
            // 
            this.ui_nbtnOK.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ui_nbtnOK.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_nbtnOK.Location = new System.Drawing.Point(66, 258);
            this.ui_nbtnOK.Name = "ui_nbtnOK";
            this.ui_nbtnOK.Size = new System.Drawing.Size(91, 19);
            this.ui_nbtnOK.TabIndex = 27;
            this.ui_nbtnOK.Text = "OK";
            this.ui_nbtnOK.UseVisualStyleBackColor = false;
            this.ui_nbtnOK.Click += new System.EventHandler(this.ui_nbtnOK_Click);
            // 
            // ui_nbtnCancel
            // 
            this.ui_nbtnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ui_nbtnCancel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_nbtnCancel.Location = new System.Drawing.Point(173, 258);
            this.ui_nbtnCancel.Name = "ui_nbtnCancel";
            this.ui_nbtnCancel.Size = new System.Drawing.Size(91, 19);
            this.ui_nbtnCancel.TabIndex = 29;
            this.ui_nbtnCancel.Text = "Cancel";
            this.ui_nbtnCancel.UseVisualStyleBackColor = false;
            this.ui_nbtnCancel.Click += new System.EventHandler(this.ui_nbtnCancel_Click);
            // 
            // ui_nlstPeriodicity
            // 
            this.ui_nlstPeriodicity.ColumnOnLeft = false;
            this.ui_nlstPeriodicity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_nlstPeriodicity.Location = new System.Drawing.Point(163, 3);
            this.ui_nlstPeriodicity.Name = "ui_nlstPeriodicity";
            this.ui_nlstPeriodicity.Size = new System.Drawing.Size(111, 246);
            this.ui_nlstPeriodicity.TabIndex = 30;
            // 
            // uctlSelectChartSymbol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ui_npnlControlContainer);
            this.Name = "uctlSelectChartSymbol";
            this.Size = new System.Drawing.Size(279, 285);
            this.Load += new System.EventHandler(this.uctlSelectChartSymbol_Load);
            this.ui_npnlControlContainer.ResumeLayout(false);
            this.ui_tlpContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NUIPanel ui_npnlControlContainer;
        private System.Windows.Forms.TableLayoutPanel ui_tlpContainer;
        private Nevron.UI.WinForm.Controls.NListBox ui_nlstSymbols;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnOK;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnCancel;
        private Nevron.UI.WinForm.Controls.NListBox ui_nlstPeriodicity;
    }
}
