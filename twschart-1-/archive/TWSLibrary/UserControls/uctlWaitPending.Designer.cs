namespace CommonLibrary.UserControls
{
    partial class uctlWaitPending
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
            this.btnCancel = new Nevron.UI.WinForm.Controls.NButton();
            this.label20 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
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
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label20, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label15, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(349, 226);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.SetColumnSpan(this.btnCancel, 3);
            this.btnCancel.Location = new System.Drawing.Point(7, 146);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(334, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel Order";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label20
            // 
            this.label20.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.SetColumnSpan(this.label20, 3);
            this.label20.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(19, 106);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(311, 13);
            this.label20.TabIndex = 4;
            this.label20.Text = "You can revoke your request by pressing \"Cancel order\" button";
            this.label20.Visible = false;
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.SetColumnSpan(this.label15, 3);
            this.label15.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(114, 55);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(120, 25);
            this.label15.TabIndex = 3;
            this.label15.Text = "Please Wait";
            // 
            // uctlWaitPending
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nuiPanel1);
            this.Name = "uctlWaitPending";
            this.Size = new System.Drawing.Size(351, 228);
            this.nuiPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NUIPanel nuiPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Nevron.UI.WinForm.Controls.NButton btnCancel;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label15;
    }
}
