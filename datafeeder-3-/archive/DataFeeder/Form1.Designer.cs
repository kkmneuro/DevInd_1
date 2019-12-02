namespace DataFeederSln
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnSimulator = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbSimSettings = new System.Windows.Forms.GroupBox();
            this.rbSimToAll = new System.Windows.Forms.RadioButton();
            this.rbSimToMSMQ = new System.Windows.Forms.RadioButton();
            this.rbSimToPipe = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbSimulator = new System.Windows.Forms.CheckBox();
            this.cbExcel = new System.Windows.Forms.CheckBox();
            this.cbMT4 = new System.Windows.Forms.CheckBox();
            this.gbExcel = new System.Windows.Forms.GroupBox();
            this.rbExceltoBoth = new System.Windows.Forms.RadioButton();
            this.rbExceltoMSMQ = new System.Windows.Forms.RadioButton();
            this.rbExceltoPipe = new System.Windows.Forms.RadioButton();
            this.gbMT4 = new System.Windows.Forms.GroupBox();
            this.rbMT4toAll = new System.Windows.Forms.RadioButton();
            this.rbMT4toMSMQ = new System.Windows.Forms.RadioButton();
            this.rbMT4toPipe = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRecord = new System.Windows.Forms.TextBox();
            this.cbSaveSimData = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDelayTime = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.gbSimSettings.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbExcel.SuspendLayout();
            this.gbMT4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(330, 409);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 36);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnStop
            // 
            this.btnStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStop.Location = new System.Drawing.Point(170, 409);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(120, 36);
            this.btnStop.TabIndex = 6;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStart.Location = new System.Drawing.Point(10, 409);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(120, 36);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "Start Live Feed";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.Color.LightBlue;
            this.txtLog.Location = new System.Drawing.Point(10, 181);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(602, 220);
            this.txtLog.TabIndex = 8;
            // 
            // btnSimulator
            // 
            this.btnSimulator.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSimulator.Enabled = false;
            this.btnSimulator.Location = new System.Drawing.Point(490, 409);
            this.btnSimulator.Name = "btnSimulator";
            this.btnSimulator.Size = new System.Drawing.Size(120, 36);
            this.btnSimulator.TabIndex = 9;
            this.btnSimulator.Text = "Start Simulator";
            this.btnSimulator.UseVisualStyleBackColor = true;
            this.btnSimulator.Click += new System.EventHandler(this.btnSimulator_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gbSimSettings);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.gbExcel);
            this.groupBox1.Controls.Add(this.gbMT4);
            this.groupBox1.Location = new System.Drawing.Point(13, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(602, 114);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // gbSimSettings
            // 
            this.gbSimSettings.Controls.Add(this.rbSimToAll);
            this.gbSimSettings.Controls.Add(this.rbSimToMSMQ);
            this.gbSimSettings.Controls.Add(this.rbSimToPipe);
            this.gbSimSettings.Enabled = false;
            this.gbSimSettings.Location = new System.Drawing.Point(456, 11);
            this.gbSimSettings.Name = "gbSimSettings";
            this.gbSimSettings.Size = new System.Drawing.Size(141, 92);
            this.gbSimSettings.TabIndex = 16;
            this.gbSimSettings.TabStop = false;
            this.gbSimSettings.Text = "Sim Settings";
            // 
            // rbSimToAll
            // 
            this.rbSimToAll.AutoSize = true;
            this.rbSimToAll.Location = new System.Drawing.Point(10, 66);
            this.rbSimToAll.Name = "rbSimToAll";
            this.rbSimToAll.Size = new System.Drawing.Size(80, 17);
            this.rbSimToAll.TabIndex = 2;
            this.rbSimToAll.Text = "Send To All";
            this.rbSimToAll.UseVisualStyleBackColor = true;
            // 
            // rbSimToMSMQ
            // 
            this.rbSimToMSMQ.AutoSize = true;
            this.rbSimToMSMQ.Checked = true;
            this.rbSimToMSMQ.Location = new System.Drawing.Point(10, 43);
            this.rbSimToMSMQ.Name = "rbSimToMSMQ";
            this.rbSimToMSMQ.Size = new System.Drawing.Size(102, 17);
            this.rbSimToMSMQ.TabIndex = 1;
            this.rbSimToMSMQ.TabStop = true;
            this.rbSimToMSMQ.Text = "Send To MSMQ";
            this.rbSimToMSMQ.UseVisualStyleBackColor = true;
            // 
            // rbSimToPipe
            // 
            this.rbSimToPipe.AutoSize = true;
            this.rbSimToPipe.Location = new System.Drawing.Point(10, 20);
            this.rbSimToPipe.Name = "rbSimToPipe";
            this.rbSimToPipe.Size = new System.Drawing.Size(90, 17);
            this.rbSimToPipe.TabIndex = 0;
            this.rbSimToPipe.Text = "Send To Pipe";
            this.rbSimToPipe.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbSimulator);
            this.groupBox2.Controls.Add(this.cbExcel);
            this.groupBox2.Controls.Add(this.cbMT4);
            this.groupBox2.Location = new System.Drawing.Point(10, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(141, 92);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data Source";
            // 
            // cbSimulator
            // 
            this.cbSimulator.AutoSize = true;
            this.cbSimulator.Location = new System.Drawing.Point(8, 66);
            this.cbSimulator.Name = "cbSimulator";
            this.cbSimulator.Size = new System.Drawing.Size(69, 17);
            this.cbSimulator.TabIndex = 17;
            this.cbSimulator.Text = "Simulator";
            this.cbSimulator.UseVisualStyleBackColor = true;
            this.cbSimulator.CheckedChanged += new System.EventHandler(this.cbSimulator_CheckedChanged);
            // 
            // cbExcel
            // 
            this.cbExcel.AutoSize = true;
            this.cbExcel.Location = new System.Drawing.Point(8, 43);
            this.cbExcel.Name = "cbExcel";
            this.cbExcel.Size = new System.Drawing.Size(83, 17);
            this.cbExcel.TabIndex = 16;
            this.cbExcel.Text = "Excel Sheet";
            this.cbExcel.UseVisualStyleBackColor = true;
            this.cbExcel.CheckedChanged += new System.EventHandler(this.cbExcel_CheckedChanged);
            // 
            // cbMT4
            // 
            this.cbMT4.AutoSize = true;
            this.cbMT4.Location = new System.Drawing.Point(8, 20);
            this.cbMT4.Name = "cbMT4";
            this.cbMT4.Size = new System.Drawing.Size(93, 17);
            this.cbMT4.TabIndex = 15;
            this.cbMT4.Text = "Meta Trader 4";
            this.cbMT4.UseVisualStyleBackColor = true;
            this.cbMT4.CheckedChanged += new System.EventHandler(this.cbMT4_CheckedChanged);
            // 
            // gbExcel
            // 
            this.gbExcel.Controls.Add(this.rbExceltoBoth);
            this.gbExcel.Controls.Add(this.rbExceltoMSMQ);
            this.gbExcel.Controls.Add(this.rbExceltoPipe);
            this.gbExcel.Enabled = false;
            this.gbExcel.Location = new System.Drawing.Point(308, 16);
            this.gbExcel.Name = "gbExcel";
            this.gbExcel.Size = new System.Drawing.Size(141, 92);
            this.gbExcel.TabIndex = 13;
            this.gbExcel.TabStop = false;
            this.gbExcel.Text = "Data Receiver";
            // 
            // rbExceltoBoth
            // 
            this.rbExceltoBoth.AutoSize = true;
            this.rbExceltoBoth.Location = new System.Drawing.Point(16, 66);
            this.rbExceltoBoth.Name = "rbExceltoBoth";
            this.rbExceltoBoth.Size = new System.Drawing.Size(78, 17);
            this.rbExceltoBoth.TabIndex = 5;
            this.rbExceltoBoth.Text = "DDE To All";
            this.rbExceltoBoth.UseVisualStyleBackColor = true;
            // 
            // rbExceltoMSMQ
            // 
            this.rbExceltoMSMQ.AutoSize = true;
            this.rbExceltoMSMQ.Checked = true;
            this.rbExceltoMSMQ.Location = new System.Drawing.Point(16, 43);
            this.rbExceltoMSMQ.Name = "rbExceltoMSMQ";
            this.rbExceltoMSMQ.Size = new System.Drawing.Size(100, 17);
            this.rbExceltoMSMQ.TabIndex = 4;
            this.rbExceltoMSMQ.TabStop = true;
            this.rbExceltoMSMQ.Text = "DDE To MSMQ";
            this.rbExceltoMSMQ.UseVisualStyleBackColor = true;
            // 
            // rbExceltoPipe
            // 
            this.rbExceltoPipe.AutoSize = true;
            this.rbExceltoPipe.Location = new System.Drawing.Point(16, 21);
            this.rbExceltoPipe.Name = "rbExceltoPipe";
            this.rbExceltoPipe.Size = new System.Drawing.Size(88, 17);
            this.rbExceltoPipe.TabIndex = 3;
            this.rbExceltoPipe.Text = "DDE To Pipe";
            this.rbExceltoPipe.UseVisualStyleBackColor = true;
            // 
            // gbMT4
            // 
            this.gbMT4.Controls.Add(this.rbMT4toAll);
            this.gbMT4.Controls.Add(this.rbMT4toMSMQ);
            this.gbMT4.Controls.Add(this.rbMT4toPipe);
            this.gbMT4.Enabled = false;
            this.gbMT4.Location = new System.Drawing.Point(159, 16);
            this.gbMT4.Name = "gbMT4";
            this.gbMT4.Size = new System.Drawing.Size(141, 92);
            this.gbMT4.TabIndex = 12;
            this.gbMT4.TabStop = false;
            this.gbMT4.Text = "MT4 Settings";
            // 
            // rbMT4toAll
            // 
            this.rbMT4toAll.AutoSize = true;
            this.rbMT4toAll.Location = new System.Drawing.Point(10, 66);
            this.rbMT4toAll.Name = "rbMT4toAll";
            this.rbMT4toAll.Size = new System.Drawing.Size(77, 17);
            this.rbMT4toAll.TabIndex = 2;
            this.rbMT4toAll.Text = "MT4 To All";
            this.rbMT4toAll.UseVisualStyleBackColor = true;
            // 
            // rbMT4toMSMQ
            // 
            this.rbMT4toMSMQ.AutoSize = true;
            this.rbMT4toMSMQ.Checked = true;
            this.rbMT4toMSMQ.Location = new System.Drawing.Point(10, 43);
            this.rbMT4toMSMQ.Name = "rbMT4toMSMQ";
            this.rbMT4toMSMQ.Size = new System.Drawing.Size(99, 17);
            this.rbMT4toMSMQ.TabIndex = 1;
            this.rbMT4toMSMQ.TabStop = true;
            this.rbMT4toMSMQ.Text = "MT4 To MSMQ";
            this.rbMT4toMSMQ.UseVisualStyleBackColor = true;
            // 
            // rbMT4toPipe
            // 
            this.rbMT4toPipe.AutoSize = true;
            this.rbMT4toPipe.Location = new System.Drawing.Point(10, 20);
            this.rbMT4toPipe.Name = "rbMT4toPipe";
            this.rbMT4toPipe.Size = new System.Drawing.Size(87, 17);
            this.rbMT4toPipe.TabIndex = 0;
            this.rbMT4toPipe.Text = "MT4 To Pipe";
            this.rbMT4toPipe.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txtRecord);
            this.groupBox3.Controls.Add(this.cbSaveSimData);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtDelayTime);
            this.groupBox3.Location = new System.Drawing.Point(13, 128);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(602, 43);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "SimulatorSettings";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(198, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Records :";
            // 
            // txtRecord
            // 
            this.txtRecord.Location = new System.Drawing.Point(257, 15);
            this.txtRecord.Name = "txtRecord";
            this.txtRecord.Size = new System.Drawing.Size(88, 20);
            this.txtRecord.TabIndex = 20;
            this.txtRecord.Text = "0";
            this.txtRecord.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // cbSaveSimData
            // 
            this.cbSaveSimData.AutoSize = true;
            this.cbSaveSimData.Location = new System.Drawing.Point(8, 17);
            this.cbSaveSimData.Name = "cbSaveSimData";
            this.cbSaveSimData.Size = new System.Drawing.Size(123, 17);
            this.cbSaveSimData.TabIndex = 18;
            this.cbSaveSimData.Text = "Save Simulator Data";
            this.cbSaveSimData.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(564, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Sec.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(404, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Delay for the feed";
            // 
            // txtDelayTime
            // 
            this.txtDelayTime.Location = new System.Drawing.Point(501, 15);
            this.txtDelayTime.Name = "txtDelayTime";
            this.txtDelayTime.Size = new System.Drawing.Size(57, 20);
            this.txtDelayTime.TabIndex = 16;
            this.txtDelayTime.Text = "1";
            this.txtDelayTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 453);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSimulator);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Data Feeder";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.gbSimSettings.ResumeLayout(false);
            this.gbSimSettings.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbExcel.ResumeLayout(false);
            this.gbExcel.PerformLayout();
            this.gbMT4.ResumeLayout(false);
            this.gbMT4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnSimulator;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gbMT4;
        private System.Windows.Forms.GroupBox gbExcel;
        private System.Windows.Forms.RadioButton rbMT4toAll;
        private System.Windows.Forms.RadioButton rbMT4toMSMQ;
        private System.Windows.Forms.RadioButton rbMT4toPipe;
        private System.Windows.Forms.RadioButton rbExceltoBoth;
        private System.Windows.Forms.RadioButton rbExceltoMSMQ;
        private System.Windows.Forms.RadioButton rbExceltoPipe;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbExcel;
        private System.Windows.Forms.CheckBox cbMT4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDelayTime;
        private System.Windows.Forms.CheckBox cbSimulator;
        private System.Windows.Forms.GroupBox gbSimSettings;
        private System.Windows.Forms.RadioButton rbSimToAll;
        private System.Windows.Forms.RadioButton rbSimToMSMQ;
        private System.Windows.Forms.RadioButton rbSimToPipe;
        private System.Windows.Forms.CheckBox cbSaveSimData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRecord;
    }
}

