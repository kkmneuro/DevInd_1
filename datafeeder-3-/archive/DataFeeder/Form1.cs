using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NDde.Client;
using System.Runtime.InteropServices;
using System.IO;
using System.IO.Pipes;
using System.Diagnostics;
using System.Threading;
using System.Configuration;
using System.Messaging;
using System.Reflection;
using System.Globalization;
using DataFeederSln.Cls;

namespace DataFeederSln
{
    public partial class Form1 : Form
    {

        #region "      MEMBER      "

        DateTime dtStartPoint = DateTime.UtcNow;
        
        public static bool isSimDataSave = false;
        public static int totalSimRecords = 0;
        public static int savedSimRecords = 0;
        string LogFilePath;
        string DataFilePath;
        Thread ThreadSaveSimData;

        #endregion "      MEMBER      "

        public Form1()
        {
            InitializeComponent();
            TheContainer.TheForm = this;
            dtStartPoint = new System.DateTime(1970, 01, 01, 00, 00, 00);

            try
            {
                if (!Directory.Exists(Application.StartupPath + "\\LOGS"))
                {
                    Directory.CreateDirectory(Application.StartupPath + "\\LOGS");
                }
                string path = Assembly.GetExecutingAssembly().Location;
                FileInfo fileInfo = new FileInfo(path);
                LogFilePath = fileInfo.DirectoryName + "\\LOGS\\Error\\Log_" + DateTime.Now.ToString("dd_MM_yyyy");
                DataFilePath = fileInfo.DirectoryName + "\\LOGS\\Data\\Log_" + DateTime.Now.ToString("dd_MM_yyyy");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error at Form1() >> " + ex.Message);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            Label.CheckForIllegalCrossThreadCalls = false;
            TextBox.CheckForIllegalCrossThreadCalls = false;
            cbMT4.Checked = true;
            Thread ThreadError = new System.Threading.Thread(ThreadHandleQueue);
            ThreadError.IsBackground = true;
            ThreadError.Start();

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dtResult = MessageBox.Show("Do you want to close the application", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dtResult == System.Windows.Forms.DialogResult.Yes)
            {
                Process[] processes = Process.GetProcessesByName("DataFeeder");
                if (processes.Length > 0)
                {
                    foreach (Process process in processes)
                    {
                        process.Kill();
                    }
                }
                if (TheContainer.TheDdeClient != null && TheContainer.TheDdeClient.IsConnected)
                {
                    TheContainer.TheDdeClient.Disconnect();
                }                
            }

            else
            {
                e.Cancel = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            TheContainer.TheForm.Close();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (TheContainer.TheDdeClient != null)
            {
                TheContainer.TheDdeClient.Disconnect();
            }
            else
            {
                Cls.Common.Log(txtLog, LogFilePath, DateTime.UtcNow.ToString() + " : DDE Client Not Started");
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

            if (!cbMT4.Checked && !cbExcel.Checked)
            {
                MessageBox.Show("Please select data source.");
                return;
            }
            else
            {
                isSimDataSave = cbSaveSimData.Checked;
                if (isSimDataSave)
                {                   
                    int.TryParse(txtRecord.Text.Trim(), out totalSimRecords);
                    if (File.Exists(Cls.Global.GlobalInstance.SimLogPath + "\\SimulatorData.txt"))
                    {
                        File.Delete(Cls.Global.GlobalInstance.SimLogPath + "\\SimulatorData.txt");
                    }

                    ThreadSaveSimData = new System.Threading.Thread(ThreadHandleSimData);
                    ThreadSaveSimData.Start();
                }
                if (rbMT4toMSMQ.Checked)
                {
                    try
                    {
                        if (!MessageQueue.Exists(Global.GlobalInstance.QueueName))
                        {
                            MessageQueue.Create(Global.GlobalInstance.QueueName);                            
                        }
                    }
                    catch (Exception ex)
                    {
                        Global.GlobalInstance.SyncErrorLog("Error at getSymbolsList >> Global >> " + ex.Message);
                        return;
                    }
                    

                }
                if (cbMT4.Checked && !cbExcel.Checked)
                {
                    Cls.DDEdataHandler._DDEdataHandlerInstance.Init(rbMT4toPipe.Checked, rbMT4toMSMQ.Checked, rbMT4toAll.Checked);
                }
                else if (!cbMT4.Checked && cbExcel.Checked)
                {
                    Cls.ExceldataHandler._ExceldataHandlerInstance.txtOutput = txtLog;
                    Cls.ExceldataHandler._ExceldataHandlerInstance.Init(rbExceltoPipe.Checked, rbExceltoMSMQ.Checked, rbExceltoBoth.Checked);
                }
                else
                {
                    Cls.ExceldataHandler._ExceldataHandlerInstance.txtOutput = txtLog;
                    Cls.DDEdataHandler._DDEdataHandlerInstance.Init(rbMT4toPipe.Checked, rbMT4toMSMQ.Checked, rbMT4toAll.Checked);
                    Cls.ExceldataHandler._ExceldataHandlerInstance.Init(rbExceltoPipe.Checked, rbExceltoMSMQ.Checked, rbExceltoBoth.Checked);
                }
            }

        }

        /// <summary>
        /// manages the Simulator log
        /// </summary>
        private void ThreadHandleSimData()
        {
            while (true)
            {
                try
                {
                    if (Cls.Global.GlobalInstance._syncSimQueue.Count == 0)
                    {
                        Thread.Sleep(10);
                        //this will deflate the queue to size 0..
                        Cls.Global.GlobalInstance._syncSimQueue.TrimToSize();
                        continue;
                    }
                    if (Cls.Global.GlobalInstance._syncSimQueue.Count > 0)
                    {
                        MQLTick objMQLTick = (MQLTick)Cls.Global.GlobalInstance._syncSimQueue.Dequeue();
                        string msg = objMQLTick.contract + "," + objMQLTick.productType + "," + objMQLTick.Ask.ToString() + "," + objMQLTick.Bid.ToString() + "," + objMQLTick.dAskSize.ToString() + ","
                            + objMQLTick.dBidSize.ToString() + "," + objMQLTick.dOpen.ToString() + "," + objMQLTick.dHigh.ToString() + "," + objMQLTick.dLow.ToString()
                            + "," + objMQLTick.dClose.ToString() + "," + objMQLTick.LTP.ToString() + "," + objMQLTick.dLastSize.ToString();
                        SaveSimulatorData(msg);
                        if (ThreadSaveSimData!=null && savedSimRecords >=totalSimRecords)
                        {
                            ThreadSaveSimData.Abort();
                        }
                    }
                    Thread.Sleep(0);
                }
                catch (Exception ex)
                {
                    Cls.Global.GlobalInstance.SyncErrorLog("ThreadHandleSimData >> " + ex.Message);
                }
          

            }
        }

        /// <summary>
        /// manages the UI log
        /// </summary>
        private void ThreadHandleQueue()
        {
            while (true)
            {
                if (Cls.Global.GlobalInstance._syncUIQueue.Count == 0)
                {
                    Thread.Sleep(10);
                    //this will deflate the queue to size 0..
                    Cls.Global.GlobalInstance._syncUIQueue.TrimToSize();
                    continue;
                }
                if (Cls.Global.GlobalInstance._syncUIQueue.Count > 0)
                {
                    string msg = (string)Cls.Global.GlobalInstance._syncUIQueue.Dequeue();
                    Log(msg);
                }
                Thread.Sleep(0);

            }
        }

        /// <summary>
        /// This method creates the log 
        /// </summary>
        /// <param name="msg">message to write in log file</param>   
        private void SaveSimulatorData(string msg)
        {            
            if (File.Exists(Cls.Global.GlobalInstance.SimLogPath + "\\SimulatorData.txt"))
            {
                try
                {
                    TextWriter tsw = new StreamWriter(Cls.Global.GlobalInstance.SimLogPath + "\\SimulatorData.txt", true);
                    tsw.WriteLine(msg + System.Environment.NewLine);
                    tsw.Close();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                System.IO.Directory.CreateDirectory(Cls.Global.GlobalInstance.SimLogPath);
                FileStream fsDevelopmentLog = new FileStream(Cls.Global.GlobalInstance.SimLogPath + "\\SimulatorData.txt", FileMode.OpenOrCreate, FileAccess.Write,
                                                  FileShare.ReadWrite);
                fsDevelopmentLog.Close();
                try
                {
                    TextWriter tsw = new StreamWriter(Cls.Global.GlobalInstance.SimLogPath + "\\SimulatorData.txt", true);
                    tsw.WriteLine(msg + System.Environment.NewLine);
                    tsw.Close();
                }
                catch (Exception ex)
                {
                    Cls.Global.GlobalInstance.SyncErrorLog("SaveSimulatorData >> " + ex.Message);
                }
            }
        }


        private void Log(string pText)
        {
            try
            {
                Action A = () =>
                {
                    txtLog.AppendText(pText);
                    txtLog.AppendText("\r\n");
                };
                if (InvokeRequired)
                {
                    BeginInvoke(A);
                }
                else
                {
                    A();
                }
            }
            catch (Exception)
            {
                
            }
            
        }

        private void btnSimulator_Click(object sender, EventArgs e)
        {
            if (!Cls.SimulatorDataHandler._SimulatorDataHandlerInstance._isSimulatorActive)
            {
                Cls.SimulatorDataHandler._SimulatorDataHandlerInstance._isSimulatorActive = true;
                btnSimulator.Enabled = false;
                //btnSimulator.Text = "Stop Simulator";
                int DelayTime = 0;
                if (txtDelayTime.Text.Trim() != "")
                {
                    int.TryParse(txtDelayTime.Text, out DelayTime);
                }
                if (rbSimToMSMQ.Checked)
                {
                    try
                    {
                        if (!MessageQueue.Exists(Global.GlobalInstance.QueueName))
                            MessageQueue.Create(Global.GlobalInstance.QueueName);
                    }
                    catch (Exception ex)
                    {
                        Global.GlobalInstance.SyncErrorLog("Error at getSymbolsList >> Global >> " + ex.Message);
                        return;
                    }
                }
                Cls.SimulatorDataHandler._SimulatorDataHandlerInstance.Init(rbSimToPipe.Checked, rbSimToMSMQ.Checked, rbSimToAll.Checked, DelayTime);
            }
            else
            {
                //Cls.SimulatorDataHandler._SimulatorDataHandlerInstance._isSimulatorActive = false;
              //  Cls.SimulatorDataHandler._SimulatorDataHandlerInstance.Stop();                
                //btnSimulator.Text = "Start Simulator";
            }
        }

        private void AsyncSend(IAsyncResult iar)
        {
            try
            {
                // Get the pipe
                NamedPipeClientStream pipeStream = (NamedPipeClientStream)iar.AsyncState;

                // End the write
                pipeStream.EndWrite(iar);
                pipeStream.Flush();
            }
            catch (Exception oEX)
            {
                Debug.WriteLine(oEX.Message);
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b' && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void cbMT4_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMT4.Checked)
            {
                cbSimulator.Checked = false;
                gbMT4.Enabled = true;
            }
            else
            {
                gbMT4.Enabled = false;
            }
        }

        private void cbExcel_CheckedChanged(object sender, EventArgs e)
        {
            if (cbExcel.Checked)
            {
                cbSimulator.Checked = false;
                gbExcel.Enabled = true;
            }
            else
            {
                gbExcel.Enabled = false;
            }
        }

        private void cbSimulator_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSimulator.Checked)
            {
                cbMT4.Checked = false;
                cbExcel.Checked = false;
                gbExcel.Enabled = false;
                gbMT4.Enabled = false;
                gbSimSettings.Enabled = true;
                btnSimulator.Enabled = true;
                btnStart.Enabled = false;
                cbSaveSimData.Enabled = false;
                txtRecord.Enabled = false;
            }
            else
            {
                cbMT4.Checked = true;
                gbMT4.Enabled = true;
                gbSimSettings.Enabled = false;
                btnSimulator.Enabled = false;
                btnStart.Enabled = true;
                cbSaveSimData.Enabled = true;
                txtRecord.Enabled = true;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Environment.Exit(Environment.ExitCode);
            }
            catch (Exception)
            {
            }
            
        }

    }
    public class TheContainer
    {
        public static Form1 TheForm;
        public static DdeClient DdeClient;
        public static DdeClient TheDdeClient;
    }

    public struct MQLTick
    {
        public double Ask;
        public double Bid;
        public double LTP;
        public double dOpen;
        public double dHigh;
        public double dLow;
        public double dClose;
        public double dBidSize;
        public double dAskSize;
        public double dLastSize;
        public double date;
        public String productType;
        public String contract;

    };

}