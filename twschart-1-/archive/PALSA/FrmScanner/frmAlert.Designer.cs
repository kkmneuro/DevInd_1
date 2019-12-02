namespace PALSA.FrmScanner
{
    partial class frmAlert
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAlert));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.nEnable = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.nActionCombo = new Nevron.UI.WinForm.Controls.NComboBox();
            this.nsymbolCombao = new Nevron.UI.WinForm.Controls.NComboBox();
            this.nConditionCombo = new Nevron.UI.WinForm.Controls.NComboBox();
            this.nSourceCombo = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ntimeoutCombo = new Nevron.UI.WinForm.Controls.NComboBox();
            this.nmaxitrCombo = new Nevron.UI.WinForm.Controls.NComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.nbtnOK = new Nevron.UI.WinForm.Controls.NButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.nbtnTest = new Nevron.UI.WinForm.Controls.NButton();
            this.nbtnCancel = new Nevron.UI.WinForm.Controls.NButton();
            this.nbtnAction = new Nevron.UI.WinForm.Controls.NButton();
            this.label8 = new System.Windows.Forms.Label();
            this.lblValue = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ntxtAlertValue = new Nevron.UI.WinForm.Controls.NTextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.TimePicker1 = new Nevron.UI.WinForm.Controls.NMaskedTextBox();
            this.pnlContainer = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.pnlContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(80, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(431, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "To add a new or modify the existing alert please define all condition and\r\n selec" +
                "t the necessary action.";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(67, 67);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // nEnable
            // 
            this.nEnable.AutoSize = true;
            this.nEnable.ButtonProperties.BorderOffset = 2;
            this.nEnable.Location = new System.Drawing.Point(82, 53);
            this.nEnable.Name = "nEnable";
            this.nEnable.Size = new System.Drawing.Size(59, 17);
            this.nEnable.TabIndex = 0;
            this.nEnable.Text = "Enable";
            this.nEnable.CheckedChanged += new System.EventHandler(this.nEnable_CheckedChanged);
            // 
            // nActionCombo
            // 
            this.nActionCombo.ListProperties.ColumnOnLeft = false;
            this.nActionCombo.Location = new System.Drawing.Point(82, 76);
            this.nActionCombo.Name = "nActionCombo";
            this.nActionCombo.Size = new System.Drawing.Size(100, 22);
            this.nActionCombo.TabIndex = 1;
            this.nActionCombo.Text = "nComboBox1";
            this.nActionCombo.SelectedIndexChanged += new System.EventHandler(this.nActionCombo_SelectedIndexChanged);
            // 
            // nsymbolCombao
            // 
            this.nsymbolCombao.ListProperties.ColumnOnLeft = false;
            this.nsymbolCombao.Location = new System.Drawing.Point(82, 110);
            this.nsymbolCombao.Name = "nsymbolCombao";
            this.nsymbolCombao.Size = new System.Drawing.Size(100, 22);
            this.nsymbolCombao.TabIndex = 2;
            this.nsymbolCombao.Text = "nComboBox2";
            // 
            // nConditionCombo
            // 
            this.nConditionCombo.ListProperties.ColumnOnLeft = false;
            this.nConditionCombo.Location = new System.Drawing.Point(248, 110);
            this.nConditionCombo.Name = "nConditionCombo";
            this.nConditionCombo.Size = new System.Drawing.Size(100, 22);
            this.nConditionCombo.TabIndex = 3;
            this.nConditionCombo.Text = "nComboBox3";
            this.nConditionCombo.SelectedIndexChanged += new System.EventHandler(this.nConditionCombo_SelectedIndexChanged);
            // 
            // nSourceCombo
            // 
            this.nSourceCombo.ListProperties.ColumnOnLeft = false;
            this.nSourceCombo.Location = new System.Drawing.Point(82, 150);
            this.nSourceCombo.Name = "nSourceCombo";
            this.nSourceCombo.Size = new System.Drawing.Size(390, 22);
            this.nSourceCombo.TabIndex = 6;
            // 
            // ntimeoutCombo
            // 
            this.ntimeoutCombo.ListProperties.ColumnOnLeft = false;
            this.ntimeoutCombo.Location = new System.Drawing.Point(82, 187);
            this.ntimeoutCombo.Name = "ntimeoutCombo";
            this.ntimeoutCombo.Size = new System.Drawing.Size(100, 22);
            this.ntimeoutCombo.TabIndex = 8;
            this.ntimeoutCombo.Text = "nComboBox5";
            // 
            // nmaxitrCombo
            // 
            this.nmaxitrCombo.ListProperties.ColumnOnLeft = false;
            this.nmaxitrCombo.Location = new System.Drawing.Point(408, 187);
            this.nmaxitrCombo.Name = "nmaxitrCombo";
            this.nmaxitrCombo.Size = new System.Drawing.Size(100, 22);
            this.nmaxitrCombo.TabIndex = 9;
            this.nmaxitrCombo.Text = "nComboBox6";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Action:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Symbol:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(188, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Condition:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 193);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Tmeout:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(298, 193);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Maximum Iteration:";
            // 
            // nbtnOK
            // 
            this.nbtnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.nbtnOK.ImageIndex = 0;
            this.nbtnOK.ImageList = this.imageList1;
            this.nbtnOK.Location = new System.Drawing.Point(123, 238);
            this.nbtnOK.Name = "nbtnOK";
            this.nbtnOK.Size = new System.Drawing.Size(75, 23);
            this.nbtnOK.TabIndex = 10;
            this.nbtnOK.Text = "OK";
            this.nbtnOK.UseVisualStyleBackColor = false;
            this.nbtnOK.Click += new System.EventHandler(this.nbtnOK_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Correct.png");
            this.imageList1.Images.SetKeyName(1, "Delete_All.png");
            // 
            // nbtnTest
            // 
            this.nbtnTest.Location = new System.Drawing.Point(222, 238);
            this.nbtnTest.Name = "nbtnTest";
            this.nbtnTest.Size = new System.Drawing.Size(75, 23);
            this.nbtnTest.TabIndex = 11;
            this.nbtnTest.Text = "Test";
            this.nbtnTest.UseVisualStyleBackColor = false;
            this.nbtnTest.Click += new System.EventHandler(this.nbtnTest_Click);
            // 
            // nbtnCancel
            // 
            this.nbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.nbtnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.nbtnCancel.ImageIndex = 1;
            this.nbtnCancel.ImageList = this.imageList1;
            this.nbtnCancel.Location = new System.Drawing.Point(321, 238);
            this.nbtnCancel.Name = "nbtnCancel";
            this.nbtnCancel.Size = new System.Drawing.Size(75, 23);
            this.nbtnCancel.TabIndex = 12;
            this.nbtnCancel.Text = "Cancel";
            this.nbtnCancel.UseVisualStyleBackColor = false;
            this.nbtnCancel.Click += new System.EventHandler(this.nbtnCancel_Click);
            // 
            // nbtnAction
            // 
            this.nbtnAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nbtnAction.Location = new System.Drawing.Point(485, 153);
            this.nbtnAction.Name = "nbtnAction";
            this.nbtnAction.Size = new System.Drawing.Size(23, 23);
            this.nbtnAction.TabIndex = 7;
            this.nbtnAction.Text = "....";
            this.nbtnAction.UseVisualStyleBackColor = false;
            this.nbtnAction.Click += new System.EventHandler(this.nbtnAction_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 156);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Source:";
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(368, 115);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(34, 13);
            this.lblValue.TabIndex = 12;
            this.lblValue.Text = "Price:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DimGray;
            this.groupBox1.Location = new System.Drawing.Point(17, 228);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(494, 3);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            // 
            // ntxtAlertValue
            // 
            this.ntxtAlertValue.Location = new System.Drawing.Point(408, 114);
            this.ntxtAlertValue.Name = "ntxtAlertValue";
            this.ntxtAlertValue.Size = new System.Drawing.Size(100, 18);
            this.ntxtAlertValue.TabIndex = 4;
            this.ntxtAlertValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nPricelist_KeyPress);
            this.ntxtAlertValue.Validating += new System.ComponentModel.CancelEventHandler(this.nPricelist_Validating);
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // TimePicker1
            // 
            this.TimePicker1.Location = new System.Drawing.Point(408, 90);
            this.TimePicker1.Mask = "90:00";
            this.TimePicker1.Name = "TimePicker1";
            this.TimePicker1.Size = new System.Drawing.Size(100, 18);
            this.TimePicker1.TabIndex = 5;
            this.TimePicker1.ValidatingType = typeof(System.DateTime);
            this.TimePicker1.Validating += new System.ComponentModel.CancelEventHandler(this.TimePicker1_Validating_1);
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.pictureBox1);
            this.pnlContainer.Controls.Add(this.TimePicker1);
            this.pnlContainer.Controls.Add(this.label1);
            this.pnlContainer.Controls.Add(this.ntxtAlertValue);
            this.pnlContainer.Controls.Add(this.nEnable);
            this.pnlContainer.Controls.Add(this.groupBox1);
            this.pnlContainer.Controls.Add(this.nActionCombo);
            this.pnlContainer.Controls.Add(this.nbtnAction);
            this.pnlContainer.Controls.Add(this.nsymbolCombao);
            this.pnlContainer.Controls.Add(this.nbtnCancel);
            this.pnlContainer.Controls.Add(this.nConditionCombo);
            this.pnlContainer.Controls.Add(this.nbtnTest);
            this.pnlContainer.Controls.Add(this.nSourceCombo);
            this.pnlContainer.Controls.Add(this.nbtnOK);
            this.pnlContainer.Controls.Add(this.ntimeoutCombo);
            this.pnlContainer.Controls.Add(this.label7);
            this.pnlContainer.Controls.Add(this.nmaxitrCombo);
            this.pnlContainer.Controls.Add(this.lblValue);
            this.pnlContainer.Controls.Add(this.label2);
            this.pnlContainer.Controls.Add(this.label8);
            this.pnlContainer.Controls.Add(this.label3);
            this.pnlContainer.Controls.Add(this.label6);
            this.pnlContainer.Controls.Add(this.label4);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(528, 266);
            this.pnlContainer.TabIndex = 21;
            // 
            // frmAlert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 266);
            this.Controls.Add(this.pnlContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAlert";
            this.ShowInTaskbar = false;
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alert Editor";
            this.UseGlassIfEnabled = Nevron.UI.WinForm.Controls.CommonTriState.False;
            this.Load += new System.EventHandler(this.frmAlert_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Nevron.UI.WinForm.Controls.NComboBox nActionCombo;
        private Nevron.UI.WinForm.Controls.NComboBox nsymbolCombao;
        private Nevron.UI.WinForm.Controls.NComboBox nConditionCombo;
        private Nevron.UI.WinForm.Controls.NComboBox nSourceCombo;
        private Nevron.UI.WinForm.Controls.NComboBox ntimeoutCombo;
        private Nevron.UI.WinForm.Controls.NComboBox nmaxitrCombo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private Nevron.UI.WinForm.Controls.NButton nbtnOK;
        private Nevron.UI.WinForm.Controls.NButton nbtnTest;
        private Nevron.UI.WinForm.Controls.NButton nbtnCancel;
        private Nevron.UI.WinForm.Controls.NButton nbtnAction;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.GroupBox groupBox1;
        private Nevron.UI.WinForm.Controls.NTextBox ntxtAlertValue;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Nevron.UI.WinForm.Controls.NMaskedTextBox TimePicker1;
        public Nevron.UI.WinForm.Controls.NCheckBox nEnable;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel pnlContainer;
    }
}