namespace CommonLibrary.UserControls
{
    partial class uctlOrderExecutionStatus
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
            this.nuiPanel1 = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnOrderExecutionFinalOk = new Nevron.UI.WinForm.Controls.NButton();
            this.btnOrderExecutionFinalPrint = new Nevron.UI.WinForm.Controls.NButton();
            this.label10 = new System.Windows.Forms.Label();
            this.lblOrderExecutionInfo = new System.Windows.Forms.Label();
            this.nuiPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nuiPanel1
            // 
            this.nuiPanel1.Controls.Add(this.tableLayoutPanel1);
            this.nuiPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nuiPanel1.Location = new System.Drawing.Point(0, 0);
            this.nuiPanel1.Name = "nuiPanel1";
            this.nuiPanel1.Size = new System.Drawing.Size(351, 228);
            this.nuiPanel1.TabIndex = 0;
            this.nuiPanel1.Text = "nuiPanel1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lblInfo, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblOrderExecutionInfo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnOrderExecutionFinalPrint, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnOrderExecutionFinalOk, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(349, 226);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblInfo.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.SetColumnSpan(this.lblInfo, 2);
            this.lblInfo.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(3, 43);
            this.lblInfo.Name = "lblInfo";
            this.tableLayoutPanel1.SetRowSpan(this.lblInfo, 2);
            this.lblInfo.Size = new System.Drawing.Size(343, 62);
            this.lblInfo.TabIndex = 17;
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOrderExecutionFinalOk
            // 
            this.btnOrderExecutionFinalOk.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.SetColumnSpan(this.btnOrderExecutionFinalOk, 2);
            this.btnOrderExecutionFinalOk.Location = new System.Drawing.Point(37, 118);
            this.btnOrderExecutionFinalOk.Name = "btnOrderExecutionFinalOk";
            this.btnOrderExecutionFinalOk.Size = new System.Drawing.Size(274, 23);
            this.btnOrderExecutionFinalOk.TabIndex = 4;
            this.btnOrderExecutionFinalOk.Text = "OK";
            this.btnOrderExecutionFinalOk.UseVisualStyleBackColor = false;
            this.btnOrderExecutionFinalOk.Click += new System.EventHandler(this.btnOrderExecutionFinalOk_Click);
            // 
            // btnOrderExecutionFinalPrint
            // 
            this.btnOrderExecutionFinalPrint.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOrderExecutionFinalPrint.Location = new System.Drawing.Point(19, 155);
            this.btnOrderExecutionFinalPrint.Name = "btnOrderExecutionFinalPrint";
            this.btnOrderExecutionFinalPrint.Size = new System.Drawing.Size(136, 23);
            this.btnOrderExecutionFinalPrint.TabIndex = 5;
            this.btnOrderExecutionFinalPrint.Text = "Print";
            this.btnOrderExecutionFinalPrint.UseVisualStyleBackColor = false;
            this.btnOrderExecutionFinalPrint.Visible = false;
            this.btnOrderExecutionFinalPrint.Click += new System.EventHandler(this.btnOrderExecutionFinalPrint_Click);
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.SetColumnSpan(this.label10, 2);
            this.label10.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(11, 199);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(326, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "You can print this information by pressing \"Print\" Button";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label10.Visible = false;
            // 
            // lblOrderExecutionInfo
            // 
            this.lblOrderExecutionInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblOrderExecutionInfo.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.SetColumnSpan(this.lblOrderExecutionInfo, 2);
            this.lblOrderExecutionInfo.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderExecutionInfo.Location = new System.Drawing.Point(36, 0);
            this.lblOrderExecutionInfo.Name = "lblOrderExecutionInfo";
            this.lblOrderExecutionInfo.Size = new System.Drawing.Size(276, 37);
            this.lblOrderExecutionInfo.TabIndex = 3;
            this.lblOrderExecutionInfo.Text = "Order Execution Info";
            this.lblOrderExecutionInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uctlOrderExecutionStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nuiPanel1);
            this.Name = "uctlOrderExecutionStatus";
            this.Size = new System.Drawing.Size(351, 228);
            this.nuiPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NUIPanel nuiPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblOrderExecutionInfo;
        private Nevron.UI.WinForm.Controls.NButton btnOrderExecutionFinalOk;
        private Nevron.UI.WinForm.Controls.NButton btnOrderExecutionFinalPrint;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.Label lblInfo;
    }
}
