namespace CommonLibrary.UserControls
{
    partial class ucModifyFill
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
            this.label17 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.cmbMarkUp4SL = new System.Windows.Forms.ComboBox();
            this.btnCopy4TP = new System.Windows.Forms.Button();
            this.lblModifyFillInfoTxt = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.cmbMarkUp4TP = new System.Windows.Forms.ComboBox();
            this.btnCopy4SL = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.cmbSLValue = new System.Windows.Forms.NumericUpDown();
            this.label25 = new System.Windows.Forms.Label();
            this.cmbTPValue = new System.Windows.Forms.NumericUpDown();
            this.label26 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSLValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTPValue)).BeginInit();
            this.SuspendLayout();
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Location = new System.Drawing.Point(10, 28);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(50, 13);
            this.label17.TabIndex = 14;
            this.label17.Text = "Level : ";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Location = new System.Drawing.Point(10, 106);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(75, 13);
            this.label19.TabIndex = 19;
            this.label19.Text = "Stop Loss : ";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.Location = new System.Drawing.Point(209, 106);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(82, 13);
            this.label24.TabIndex = 29;
            this.label24.Text = "Take Profit : ";
            // 
            // cmbMarkUp4SL
            // 
            this.cmbMarkUp4SL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMarkUp4SL.FormattingEnabled = true;
            this.cmbMarkUp4SL.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "20"});
            this.cmbMarkUp4SL.Location = new System.Drawing.Point(83, 20);
            this.cmbMarkUp4SL.Name = "cmbMarkUp4SL";
            this.cmbMarkUp4SL.Size = new System.Drawing.Size(48, 21);
            this.cmbMarkUp4SL.TabIndex = 31;
            this.cmbMarkUp4SL.SelectedIndexChanged += new System.EventHandler(this.cmbMarkUp4SL_SelectedIndexChanged);
            // 
            // btnCopy4TP
            // 
            this.btnCopy4TP.Location = new System.Drawing.Point(293, 58);
            this.btnCopy4TP.Name = "btnCopy4TP";
            this.btnCopy4TP.Size = new System.Drawing.Size(92, 23);
            this.btnCopy4TP.TabIndex = 20;
            this.btnCopy4TP.UseVisualStyleBackColor = true;
            this.btnCopy4TP.Click += new System.EventHandler(this.btnCopy4TP_Click);
            // 
            // lblModifyFillInfoTxt
            // 
            this.lblModifyFillInfoTxt.BackColor = System.Drawing.Color.Transparent;
            this.lblModifyFillInfoTxt.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModifyFillInfoTxt.Location = new System.Drawing.Point(21, 204);
            this.lblModifyFillInfoTxt.Name = "lblModifyFillInfoTxt";
            this.lblModifyFillInfoTxt.Size = new System.Drawing.Size(353, 32);
            this.lblModifyFillInfoTxt.TabIndex = 22;
            this.lblModifyFillInfoTxt.Text = "SL or TP you set must differ from market price by at least 4 pips";
            this.lblModifyFillInfoTxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Location = new System.Drawing.Point(209, 68);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(68, 13);
            this.label22.TabIndex = 32;
            this.label22.Text = "Copy As : ";
            // 
            // cmbMarkUp4TP
            // 
            this.cmbMarkUp4TP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMarkUp4TP.FormattingEnabled = true;
            this.cmbMarkUp4TP.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "20"});
            this.cmbMarkUp4TP.Location = new System.Drawing.Point(293, 20);
            this.cmbMarkUp4TP.Name = "cmbMarkUp4TP";
            this.cmbMarkUp4TP.Size = new System.Drawing.Size(44, 21);
            this.cmbMarkUp4TP.TabIndex = 30;
            this.cmbMarkUp4TP.SelectedIndexChanged += new System.EventHandler(this.cmbMarkUp4TP_SelectedIndexChanged);
            // 
            // btnCopy4SL
            // 
            this.btnCopy4SL.Location = new System.Drawing.Point(83, 58);
            this.btnCopy4SL.Name = "btnCopy4SL";
            this.btnCopy4SL.Size = new System.Drawing.Size(92, 23);
            this.btnCopy4SL.TabIndex = 21;
            this.btnCopy4SL.UseVisualStyleBackColor = true;
            this.btnCopy4SL.Click += new System.EventHandler(this.btnCopy4SL_Click);
            // 
            // btnModify
            // 
            this.btnModify.Enabled = false;
            this.btnModify.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModify.Location = new System.Drawing.Point(10, 150);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(374, 43);
            this.btnModify.TabIndex = 23;
            this.btnModify.Text = "Modify #-- ";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Location = new System.Drawing.Point(209, 28);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(50, 13);
            this.label21.TabIndex = 26;
            this.label21.Text = "Level : ";
            // 
            // cmbSLValue
            // 
            this.cmbSLValue.Location = new System.Drawing.Point(83, 99);
            this.cmbSLValue.Name = "cmbSLValue";
            this.cmbSLValue.Size = new System.Drawing.Size(92, 21);
            this.cmbSLValue.TabIndex = 35;
            this.cmbSLValue.ValueChanged += new System.EventHandler(this.cmbSLValue_ValueChanged);
            this.cmbSLValue.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cmbSLValue_MouseDown);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.Transparent;
            this.label25.Location = new System.Drawing.Point(133, 28);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(41, 13);
            this.label25.TabIndex = 27;
            this.label25.Text = "Points";
            // 
            // cmbTPValue
            // 
            this.cmbTPValue.Location = new System.Drawing.Point(293, 99);
            this.cmbTPValue.Name = "cmbTPValue";
            this.cmbTPValue.Size = new System.Drawing.Size(92, 21);
            this.cmbTPValue.TabIndex = 34;
            this.cmbTPValue.ValueChanged += new System.EventHandler(this.cmbTPValue_ValueChanged);
            this.cmbTPValue.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cmbTPValue_MouseDown);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(339, 28);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(41, 13);
            this.label26.TabIndex = 24;
            this.label26.Text = "Points";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Location = new System.Drawing.Point(10, 68);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(68, 13);
            this.label18.TabIndex = 11;
            this.label18.Text = "Copy As : ";
            // 
            // ucModifyFill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.label24);
            this.Controls.Add(this.cmbMarkUp4SL);
            this.Controls.Add(this.btnCopy4TP);
            this.Controls.Add(this.lblModifyFillInfoTxt);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.cmbMarkUp4TP);
            this.Controls.Add(this.btnCopy4SL);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.cmbSLValue);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.cmbTPValue);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucModifyFill";
            this.Size = new System.Drawing.Size(394, 254);
            ((System.ComponentModel.ISupportInitialize)(this.cmbSLValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTPValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.ComboBox cmbMarkUp4SL;
        private System.Windows.Forms.Button btnCopy4TP;
        private System.Windows.Forms.Label lblModifyFillInfoTxt;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox cmbMarkUp4TP;
        private System.Windows.Forms.Button btnCopy4SL;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.NumericUpDown cmbSLValue;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.NumericUpDown cmbTPValue;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label18;
    }
}
