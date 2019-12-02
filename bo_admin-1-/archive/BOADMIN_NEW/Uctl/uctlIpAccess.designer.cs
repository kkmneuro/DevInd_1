namespace BOADMIN_NEW.Uctl
{
    partial class uctlIpAccess
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
            this.ui_btnCancel = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_btnOk = new Nevron.UI.WinForm.Controls.NButton();
            this.nLineControl1 = new Nevron.UI.WinForm.Controls.NLineControl();
            this.ui_txtComment = new Nevron.UI.WinForm.Controls.NTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ui_txtTo = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_txtFrom = new Nevron.UI.WinForm.Controls.NTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAction = new System.Windows.Forms.Label();
            this.ui_cmbAction = new Nevron.UI.WinForm.Controls.NComboBox();
            this.lbldescription = new System.Windows.Forms.Label();
            this.nuiPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nuiPanel1
            // 
            this.nuiPanel1.Controls.Add(this.ui_btnCancel);
            this.nuiPanel1.Controls.Add(this.ui_btnOk);
            this.nuiPanel1.Controls.Add(this.nLineControl1);
            this.nuiPanel1.Controls.Add(this.ui_txtComment);
            this.nuiPanel1.Controls.Add(this.label3);
            this.nuiPanel1.Controls.Add(this.ui_txtTo);
            this.nuiPanel1.Controls.Add(this.ui_txtFrom);
            this.nuiPanel1.Controls.Add(this.label2);
            this.nuiPanel1.Controls.Add(this.label1);
            this.nuiPanel1.Controls.Add(this.lblAction);
            this.nuiPanel1.Controls.Add(this.ui_cmbAction);
            this.nuiPanel1.Controls.Add(this.lbldescription);
            this.nuiPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nuiPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nuiPanel1.Location = new System.Drawing.Point(0, 0);
            this.nuiPanel1.Name = "nuiPanel1";
            this.nuiPanel1.Size = new System.Drawing.Size(458, 211);
            this.nuiPanel1.TabIndex = 0;
            this.nuiPanel1.Text = "nuiPanel1";
            this.nuiPanel1.Click += new System.EventHandler(this.nuiPanel1_Click);
            // 
            // ui_btnCancel
            // 
            this.ui_btnCancel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_btnCancel.Location = new System.Drawing.Point(356, 172);
            this.ui_btnCancel.Name = "ui_btnCancel";
            this.ui_btnCancel.Size = new System.Drawing.Size(75, 23);
            this.ui_btnCancel.TabIndex = 5;
            this.ui_btnCancel.Text = "Cancel";
            this.ui_btnCancel.UseVisualStyleBackColor = false;
            this.ui_btnCancel.Click += new System.EventHandler(this.ui_btnCancel_Click);
            // 
            // ui_btnOk
            // 
            this.ui_btnOk.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_btnOk.Location = new System.Drawing.Point(269, 172);
            this.ui_btnOk.Name = "ui_btnOk";
            this.ui_btnOk.Size = new System.Drawing.Size(75, 23);
            this.ui_btnOk.TabIndex = 4;
            this.ui_btnOk.Text = "Ok";
            this.ui_btnOk.UseVisualStyleBackColor = false;
            this.ui_btnOk.Click += new System.EventHandler(this.ui_btnOk_Click);
            // 
            // nLineControl1
            // 
            this.nLineControl1.Location = new System.Drawing.Point(0, 157);
            this.nLineControl1.Name = "nLineControl1";
            this.nLineControl1.Size = new System.Drawing.Size(458, 2);
            this.nLineControl1.Text = "nLineControl1";
            // 
            // ui_txtComment
            // 
            this.ui_txtComment.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_txtComment.Location = new System.Drawing.Point(100, 119);
            this.ui_txtComment.MaxLength = 256;
            this.ui_txtComment.Multiline = true;
            this.ui_txtComment.Name = "ui_txtComment";
            this.ui_txtComment.Size = new System.Drawing.Size(331, 22);
            this.ui_txtComment.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Comment :";
            // 
            // ui_txtTo
            // 
            this.ui_txtTo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_txtTo.Location = new System.Drawing.Point(289, 90);
            this.ui_txtTo.MaxLength = 50;
            this.ui_txtTo.Name = "ui_txtTo";
            this.ui_txtTo.Size = new System.Drawing.Size(142, 19);
            this.ui_txtTo.TabIndex = 2;
            this.ui_txtTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ui_txtTo_KeyPress);
            // 
            // ui_txtFrom
            // 
            this.ui_txtFrom.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_txtFrom.Location = new System.Drawing.Point(100, 90);
            this.ui_txtFrom.MaxLength = 50;
            this.ui_txtFrom.Name = "ui_txtFrom";
            this.ui_txtFrom.Size = new System.Drawing.Size(142, 19);
            this.ui_txtFrom.TabIndex = 1;
            this.ui_txtFrom.Tag = "";
            this.ui_txtFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ui_txtFrom_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(260, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "To:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(45, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "From :";
            // 
            // lblAction
            // 
            this.lblAction.AutoSize = true;
            this.lblAction.BackColor = System.Drawing.Color.Transparent;
            this.lblAction.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAction.Location = new System.Drawing.Point(38, 64);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(51, 13);
            this.lblAction.TabIndex = 4;
            this.lblAction.Text = "Action :";
            // 
            // ui_cmbAction
            // 
            this.ui_cmbAction.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_cmbAction.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("Block", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("Permit", -1, false, 0, new System.Drawing.Size(0, 0))});
            this.ui_cmbAction.ListProperties.ColumnOnLeft = false;
            this.ui_cmbAction.Location = new System.Drawing.Point(100, 59);
            this.ui_cmbAction.Name = "ui_cmbAction";
            this.ui_cmbAction.Size = new System.Drawing.Size(142, 18);
            this.ui_cmbAction.TabIndex = 0;
            this.ui_cmbAction.Text = "nComboBox1";
            this.ui_cmbAction.TooltipInfo.CaptionText = "Select Specific Action";
            this.ui_cmbAction.TooltipInfo.InitialDelay = 300;
            // 
            // lbldescription
            // 
            this.lbldescription.AutoSize = true;
            this.lbldescription.BackColor = System.Drawing.Color.Transparent;
            this.lbldescription.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldescription.Location = new System.Drawing.Point(18, 13);
            this.lbldescription.Name = "lbldescription";
            this.lbldescription.Size = new System.Drawing.Size(429, 26);
            this.lbldescription.TabIndex = 1;
            this.lbldescription.Text = "Access list is used for controlling access to the server.It blocks or permits\r\nin" +
                "coming connections bassed on criteria you specified.";
            // 
            // uctlIpAccess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nuiPanel1);
            this.Name = "uctlIpAccess";
            this.Size = new System.Drawing.Size(458, 211);
            this.Load += new System.EventHandler(this.uctlIpAccess_Load);
            this.nuiPanel1.ResumeLayout(false);
            this.nuiPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NUIPanel nuiPanel1;
        private System.Windows.Forms.Label lbldescription;
        private System.Windows.Forms.Label lblAction;
        private Nevron.UI.WinForm.Controls.NComboBox ui_cmbAction;
        private Nevron.UI.WinForm.Controls.NTextBox ui_txtTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Nevron.UI.WinForm.Controls.NTextBox ui_txtComment;
        private System.Windows.Forms.Label label3;
        private Nevron.UI.WinForm.Controls.NLineControl nLineControl1;
        private Nevron.UI.WinForm.Controls.NButton ui_btnCancel;
        private Nevron.UI.WinForm.Controls.NButton ui_btnOk;
        private Nevron.UI.WinForm.Controls.NTextBox ui_txtFrom;
    }
}
