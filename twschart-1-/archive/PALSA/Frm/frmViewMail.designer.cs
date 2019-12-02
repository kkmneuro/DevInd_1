namespace PALSA.Frm
{
    partial class frmViewMail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmViewMail));
            this.lblName = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblSubject = new System.Windows.Forms.Label();
            this.lbl_valName = new System.Windows.Forms.Label();
            this.lbl_valDate = new System.Windows.Forms.Label();
            this.lbl_valSubject = new System.Windows.Forms.Label();
            this.btnAnswer = new Nevron.UI.WinForm.Controls.NButton();
            this.nStatusBar1 = new Nevron.UI.WinForm.Controls.NStatusBar();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(3, 6);
            this.lblName.Name = "lblName";
            this.lblName.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblName.Size = new System.Drawing.Size(53, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name:";
            // 
            // lblDate
            // 
            this.lblDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(3, 31);
            this.lblDate.Name = "lblDate";
            this.lblDate.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblDate.Size = new System.Drawing.Size(48, 13);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "Date:";
            // 
            // lblSubject
            // 
            this.lblSubject.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSubject.AutoSize = true;
            this.lblSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubject.Location = new System.Drawing.Point(3, 56);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblSubject.Size = new System.Drawing.Size(64, 13);
            this.lblSubject.TabIndex = 3;
            this.lblSubject.Text = "Subject:";
            // 
            // lbl_valName
            // 
            this.lbl_valName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_valName.AutoSize = true;
            this.lbl_valName.Location = new System.Drawing.Point(83, 6);
            this.lbl_valName.Name = "lbl_valName";
            this.lbl_valName.Size = new System.Drawing.Size(0, 13);
            this.lbl_valName.TabIndex = 4;
            // 
            // lbl_valDate
            // 
            this.lbl_valDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_valDate.AutoSize = true;
            this.lbl_valDate.Location = new System.Drawing.Point(83, 31);
            this.lbl_valDate.Name = "lbl_valDate";
            this.lbl_valDate.Size = new System.Drawing.Size(0, 13);
            this.lbl_valDate.TabIndex = 5;
            // 
            // lbl_valSubject
            // 
            this.lbl_valSubject.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_valSubject.AutoSize = true;
            this.lbl_valSubject.Location = new System.Drawing.Point(83, 56);
            this.lbl_valSubject.Name = "lbl_valSubject";
            this.lbl_valSubject.Size = new System.Drawing.Size(0, 13);
            this.lbl_valSubject.TabIndex = 6;
            this.lbl_valSubject.Click += new System.EventHandler(this.label6_Click);
            // 
            // btnAnswer
            // 
            this.btnAnswer.Location = new System.Drawing.Point(415, 53);
            this.btnAnswer.Name = "btnAnswer";
            this.btnAnswer.Size = new System.Drawing.Size(75, 19);
            this.btnAnswer.TabIndex = 7;
            this.btnAnswer.Text = "Answer";
            this.btnAnswer.UseVisualStyleBackColor = false;
            this.btnAnswer.Click += new System.EventHandler(this.btnAnswer_Click);
            // 
            // nStatusBar1
            // 
            this.nStatusBar1.Location = new System.Drawing.Point(0, 276);
            this.nStatusBar1.Name = "nStatusBar1";
            this.nStatusBar1.ShowPanels = true;
            this.nStatusBar1.Size = new System.Drawing.Size(503, 22);
            this.nStatusBar1.SizingGrip = false;
            this.nStatusBar1.TabIndex = 8;
            this.nStatusBar1.Text = "nStatusBar1";
            // 
            // webBrowser1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.webBrowser1, 3);
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(3, 78);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(497, 195);
            this.webBrowser1.TabIndex = 10;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78.55531F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.44469F));
            this.tableLayoutPanel1.Controls.Add(this.lblName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.webBrowser1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblDate, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblSubject, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnAnswer, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbl_valName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl_valSubject, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbl_valDate, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(503, 276);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // frmViewMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 298);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.nStatusBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmViewMail";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ViewMail";
            this.Load += new System.EventHandler(this.frmViewMail_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.Label lbl_valName;
        private System.Windows.Forms.Label lbl_valDate;
        private System.Windows.Forms.Label lbl_valSubject;
        private Nevron.UI.WinForm.Controls.NButton btnAnswer;
        private Nevron.UI.WinForm.Controls.NStatusBar nStatusBar1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}