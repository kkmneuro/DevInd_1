using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Nevron.UI.WinForm.Controls;
using System.Text.RegularExpressions;
using System.IO;
using PALSA.ClsAlerts;
using PALSA.Cls;


namespace PALSA.FrmScanner
{
    public partial class frmAlert : NForm
    {
        #region MEMBER
       // bool mod_status = false;
        private string strMailTo = "";
        string strFileName = "";
        uctlAlert alertGridInstance_ = null;
        Alert alert_ = null;
        ALERT_MODE alertMode_ = ALERT_MODE.CREATE;
        List<string> lstSymbol =null; 
       
        #endregion 

        #region PROPERTY
        public string PropMailTo
        {
            get
            {
                return strMailTo;
            }
            set
            {
                strMailTo = value;
            }
        }
        #endregion

        #region METHOD
        public frmAlert()
        { 
        
        }
        public frmAlert(ALERT_MODE mode,Alert alrt)
        {
            //Namo 22 March
            //lstSymbol = new List<string>();
            //List<string> productTypes = ClsTWSContractManager.INSTANCE.GetAllProductTypes();
            //if (productTypes.Contains("FOREX"))
            //{
            //    List<string> Products = ClsTWSContractManager.INSTANCE.GetAllProducts("FOREX");//(productTypes[productTypes.Count - 1]);
            //    foreach (var item in Products)
            //    {
            //        List<string> contracts = ClsTWSContractManager.INSTANCE.GetAllContracts("FOREX", item);

            //        foreach (var symbols in contracts)
            //        {
            //            lstSymbol.Add(symbols);
            //        }

            //    }
            //}

            // alertMode_ = mode;
            // if (alrt == null) alrt = new Alert();
            // alert_ = alrt;
            // InitializeComponent(); 

            // nsymbolCombao.Items.AddRange(lstSymbol.ToArray());

            //     if (alert_.imgEnable == false && alertMode_ == ALERT_MODE.MODIFY)
            //         nEnable.Checked = false;
            //     else
            //         nEnable.Checked = true;
            //     loadDefaultControlsData();
            // SetUIControls(alert_);
            this.AcceptButton = nbtnOK;
            this.CancelButton = nbtnCancel;
        }
      
        //
        //Set the frmAlert Control for each alert at the time of create/modify
        //

        void SetUIControls(Alert alert_)
        {
           
                ntxtAlertValue.Text = alert_.Value;
                if (alert_.Action.ToString() == "SOUND")
                    nActionCombo.SelectedIndex = nActionCombo.FindStringExact("Sound");
                else if (alert_.Action.ToString() == "FILE")
                    nActionCombo.SelectedIndex = nActionCombo.FindStringExact("File");
                else
                    nActionCombo.SelectedIndex = nActionCombo.FindStringExact("Mail");

                nConditionCombo.SelectedIndex = nConditionCombo.FindStringExact(alert_.Condition);
                nmaxitrCombo.SelectedIndex = nmaxitrCombo.FindStringExact(alert_.MaximumIterations.ToString());
                ntimeoutCombo.SelectedIndex = ntimeoutCombo.FindStringExact(alert_.timeout.ToString());
                if (alertMode_ == ALERT_MODE.MODIFY)
                    nSourceCombo.Text = alert_.SourcePath;
                nsymbolCombao.SelectedIndex = nsymbolCombao.FindStringExact(alert_.Symbol);
         
        }
            
        
        //
        //Load Contro Data At the time of opening form
        //
        private void loadDefaultControlsData()
        {
            //nActionCombo.Items.Clear();
            //nConditionCombo.Items.Clear();
            //nmaxitrCombo.Items.Clear();
            //ntimeoutCombo.Items.Clear();

            nActionCombo.Items.Add(("Sound"));
            //nActionCombo.Items.Add(("File"));
            nActionCombo.Items.Add(("Mail"));
            nConditionCombo.Items.Add("Bid > ");
            nConditionCombo.Items.Add("Bid < ");
            nConditionCombo.Items.Add("Ask > ");
            nConditionCombo.Items.Add("Ask < ");
            nConditionCombo.Items.Add("Time = ");
            nmaxitrCombo.Items.Add("1");
            nmaxitrCombo.Items.Add("3");
            nmaxitrCombo.Items.Add("5");
            nmaxitrCombo.Items.Add("10");
            nmaxitrCombo.Items.Add("50");
            nmaxitrCombo.Items.Add("1000");
        //    nsymbolCombao.Items.AddRange(uctlForex.GetSymbolObjectArray());
            ntimeoutCombo.Items.Add("10 sec");
            ntimeoutCombo.Items.Add("30 sec");
            ntimeoutCombo.Items.Add("60 sec");
            ntimeoutCombo.Items.Add("3 min");
            ntimeoutCombo.Items.Add("5 min");
            ntimeoutCombo.Items.Add("15 min");
            ntimeoutCombo.Items.Add("30 min");
            ntimeoutCombo.Items.Add("1 hr");

        }

        //Enable Check Status at frmAlert
        private void nEnable_CheckedChanged(object sender, EventArgs e)
        {
            CheckedStatus();
        }

        //Set the alart form according to Enable checked box
        public void CheckedStatus()
        {
            try
            {
                if (nEnable.Checked == true)
                {
                    nActionCombo.Enabled = true;
                    nsymbolCombao.Enabled = true;
                    nConditionCombo.Enabled = true;
                    ntxtAlertValue.Enabled = true;
                    nmaxitrCombo.Enabled = true;
                    ntimeoutCombo.Enabled = true;
                    nSourceCombo.Editable = true;
                    nbtnOK.Enabled = true;
                    nbtnTest.Enabled = true;
                    nbtnAction.Enabled = true;//Added by Pritika
                    TimePicker1.Enabled = true;
                }
                else
                {
                    nActionCombo.Enabled = false;
                    nsymbolCombao.Enabled = false;
                    nConditionCombo.Enabled = false;
                    ntxtAlertValue.Enabled = false;
                    nmaxitrCombo.Enabled = false;
                    ntimeoutCombo.Enabled = false;
                    nSourceCombo.Editable = false;
                    nbtnOK.Enabled = false;
                    nbtnTest.Enabled = false;
                    nbtnAction.Enabled = false;
                    TimePicker1.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                //Logger.LogEx(ex, "frmAlert", "CheckedStatus()");
            }
        }

        //Price and Time enter according to condition
        private void nConditionCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((nConditionCombo.Items[nConditionCombo.SelectedIndex].Text.Contains("Time")))
            {
                lblValue.Text = "Time:";
                TimePicker1.Visible = true;
                TimePicker1.Location = new Point(408, 111);
                ntxtAlertValue.Visible = false;
            }
            else
            {
                lblValue.Text = "Price:";
                ntxtAlertValue.Visible = true;
                ntxtAlertValue.Location = new Point(408, 111);
                TimePicker1.Visible = false;
            }
        }

        //  For Action selection       
        private void nbtnAction_Click(object sender, EventArgs e)
        {
            //Kul
            //frmAlertSendMail objAlertSendMail = null;
           
            switch (nActionCombo.Text)
            {
                case "Sound":
                    OpenFileDialog open_sdlg = new OpenFileDialog();
                    System.Environment.CurrentDirectory = Application.StartupPath;

                    open_sdlg.InitialDirectory =Application.StartupPath + "\\Resx";//KulfrmMainGTS.strExePath_ + "\\res";

                    open_sdlg.Filter = "Sound files (*.wav)|*.wav|All files (*.*)|*.*";
                    if (open_sdlg.ShowDialog() == DialogResult.OK)
                    {
                        {
                            nSourceCombo.Text = open_sdlg.FileName;
                        }
                    }
                    System.Environment.CurrentDirectory = Application.StartupPath;
                    break;
                case "File":
                    OpenFileDialog open_fdlg = new OpenFileDialog();
                    open_fdlg.InitialDirectory = Application.StartupPath + "\\Resx";//KulfrmMainGTS.strExePath_ + "\\res";
                    open_fdlg.Filter = "Executale File (*.exe,*.vbs,*.bat)|*.exe;*.vbs;*.bat|All files (*.*)|*.*";

                    if (open_fdlg.ShowDialog() == DialogResult.OK)
                    {
                        {
                            nSourceCombo.Text = open_fdlg.FileName;
                        }
                    }
                    System.Environment.CurrentDirectory = Application.StartupPath;
                    break;
                case "Mail"://Kul
                    //if (alertMode_ == ALERT_MODE.MODIFY)
                    //{
                    //    objAlertSendMail = new frmAlertSendMail(this, alert_.MailTo);
                    //}
                    //else
                    //{
                    //    objAlertSendMail = new frmAlertSendMail(this);
                    //}
                    //objAlertSendMail.Show();
                    break;
                default:
                    break;
            } 
                 
        }

        //Check price at form
        private void nPricelist_KeyPress(object sender, KeyPressEventArgs e)
        {           
            int keyPressAscii = Convert.ToInt32(e.KeyChar);
            if ((keyPressAscii >= 48 && keyPressAscii <= 57) || (keyPressAscii == 8) || (keyPressAscii == 46))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        //Price and Time Validation
        private void nPricelist_Validating(object sender, CancelEventArgs e)
        {
            if ((ntxtAlertValue.Text != null) && (nConditionCombo.Items[nConditionCombo.SelectedIndex].Text.Contains("Time")))
            {
                string timeLatest = DateTime.UtcNow.ToString("hh:mm:ss");
                DateTime dt1 = DateTime.Parse(ntxtAlertValue.Text);
                DateTime dt2 = DateTime.Parse(timeLatest);
                if (dt1 < dt2)
                {
                    errorProvider1.SetError(ntxtAlertValue, "Time must be grater than or equal to current time");
                }
                else
                {
                    errorProvider1.Clear();
                }
            }

        }

        //Time Picker Validation at Alert form
        private void TimePicker1_Validating_1(object sender, CancelEventArgs e)
        {
            try
            {
                string timeLatest = DateTime.UtcNow.ToString();
                DateTime dt1 = DateTime.Parse(TimePicker1.Text);
                DateTime dt2 = DateTime.Parse(timeLatest);
                if (dt1 < dt2)
                {
                    errorProvider1.SetError(TimePicker1, "Time must be grater than current time");
                    nbtnOK.Enabled = false;
                }
                else
                {
                    nbtnOK.Enabled = true;
                    errorProvider1.Clear();
                }
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(TimePicker1, "string is not supported by dateTime");
                nbtnOK.Enabled = false;
                //Logger.LogEx(ex, "frmAlert", "TimePicker1_Validating_1(object sender, CancelEventArgs e)");
                return;
            }
        }

        //Form Load 
        private void frmAlert_Load(object sender, EventArgs e)
        {
            if (!FrmMain.LoggedInSuccess)
            {
                foreach (Control ctrl in pnlContainer.Controls)
                {
                    ctrl.Enabled = false;
                } 
                //pnlContainer.Enabled = false;
               nbtnCancel.Enabled = true;
            }
            CheckedStatus();
            SetText();
            nSourceCombo.SelectedIndex = 0;
        }

        //Set Text At time of Load Alertform
        public void SetText()
        {
            //Kul
            //label1.Text = frmMainGTS.rm.GetString("To_Add_exist_Alert");
            //nEnable.Text = frmMainGTS.rm.GetString("Enable");
            //label2.Text = frmMainGTS.rm.GetString("Action");
            //label3.Text = frmMainGTS.rm.GetString("Symbol");
            //label4.Text = frmMainGTS.rm.GetString("Condition");
            //lblValue.Text = frmMainGTS.rm.GetString("Price");
            //label8.Text = frmMainGTS.rm.GetString("Source");
            //label6.Text = frmMainGTS.rm.GetString("Timeout");
            //label7.Text = frmMainGTS.rm.GetString("Maximum_Iteration");
            //nbtnOK.Text = frmMainGTS.rm.GetString("Ok");
            //nbtnTest.Text = frmMainGTS.rm.GetString("Test");
            //nbtnCancel.Text = frmMainGTS.rm.GetString("Cancel");
        }

        //set source combobox    
        public void SetSourceComboText(string data)
        {
            nSourceCombo.Text = data;
        }
        //Set Data value of Alert1 class
        public Alert GetAlertDataValue()
        {         
            switch (nActionCombo.Items[nActionCombo.SelectedIndex].Text)
            {
                case "Sound": alert_.Action = ALERT_ACTION.SOUND;
                    break;
                case "File": alert_.Action = ALERT_ACTION.FILE;
                    break;
                case "Mail": alert_.Action = ALERT_ACTION.EMAIL;                    
                    break; 
                case "Popup": alert_.Action = ALERT_ACTION.POPUP;                    
                    break;
            }

            alert_.Symbol= nsymbolCombao.Items[nsymbolCombao.SelectedIndex].Text;
            alert_.MailTo = PropMailTo;
            if (ntxtAlertValue.Visible == false)
            {
                alert_.Value = TimePicker1.Text;
            }
            else
            {
                alert_.Value = ntxtAlertValue.Text;               
            }
            alert_.setTypeConditionTradeScript(nConditionCombo.Items[nConditionCombo.SelectedIndex].Text);            
            alert_.isFirstTime_ = true;
            alert_.Enable = true;
            alert_.Counter = 0;
            alert_.CheckingCounter = 0;             
                alert_.SourcePath = nSourceCombo.Text;           
            alert_.MaximumIterations = Convert.ToInt32(Convert.ToDouble(nmaxitrCombo.Items[nmaxitrCombo.SelectedIndex].Text));
            alert_.timeout = ntimeoutCombo.Items[ntimeoutCombo.SelectedIndex].Text;
            switch (ntimeoutCombo.Items[ntimeoutCombo.SelectedIndex].Text)
            {
                case "10 sec": alert_.CheckingInterval = 10;
                    break;
                case "30 sec": alert_.CheckingInterval = 30;
                    break;
                case "60 sec": alert_.CheckingInterval = 60;
                    break;
                case "3 min": alert_.CheckingInterval = 180;
                    break;
                case "5 min": alert_.CheckingInterval = 300;
                    break;
                case "15 min": alert_.CheckingInterval = 900;
                    break;
                case "30 min": alert_.CheckingInterval = 1800;
                    break;
                case "1 hr": alert_.CheckingInterval = 3600;
                    break;
            }                             
            return alert_;
        }

        //
        //close frmAlert form 
        //
        private void nbtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //
        //This function perform Adding and modify Alert in Grid 
        //
        private void nbtnOK_Click(object sender, EventArgs e)
        {
             double price=0.0;
            if (TimePicker1.Visible == false)
            {
               price = Double.Parse(ntxtAlertValue.Text);
            }
             if (price <= 0 && (TimePicker1.Visible == false))
            {
                MessageBox.Show("Please select valid price.");
                return;
            }
             if (nsymbolCombao.Items.Count==0)
             {
                 MessageBox.Show("Please show Symbol on Grid");
                 return;
             }

          
            try
            {
                Alert objAlert = GetAlertDataValue();
                if(alertMode_ == ALERT_MODE.CREATE)
                {
                    AlertManager.Getreference().objAlertgrid_.AddAlertIngrid(objAlert);
                }
            if (alertMode_ == ALERT_MODE.MODIFY)
                {
                    AlertManager.Getreference().objAlertgrid_.ModifyAlertIngrid(objAlert);
                }

            }
            catch (Exception ex)
            {
                //Logger.LogEx(ex, "frmAlert", "nbtnOK_Click(object sender, EventArgs e)");
            }
            this.Close();

        }

        //
        //Test the Action
        //
        private void nbtnTest_Click(object sender, EventArgs e)
        {
            AlertAction testaction = new AlertAction();
            try
            {
                switch (nActionCombo.Items[nActionCombo.SelectedIndex].Text)
                {
                    case "Sound":
                        testaction.PlaySound(nSourceCombo.Text);
                        testaction = null;
                        MessageBox.Show("Sound Tested Successfully", "Alert Test", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                    case "File":
                        testaction.Executefile(nSourceCombo.Text);
                        testaction = null;
                        MessageBox.Show("File Tested Successfully", "Alert Test", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                    case "Mail":                       
                        testaction.sendmail(nSourceCombo.Text);
                        testaction = null;
                        MessageBox.Show("Mail Sent Successfully", "Alert Test", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                    case "Popup": alert_.Action = ALERT_ACTION.POPUP;
                        break;
                }
            }
            catch (Exception ex)
            {
                //Logger.LogEx(ex, "frmAlert", "nbtnTest_Click(object sender, EventArgs e)");
            }
            testaction = null;
        }   
     
         //
        //This function perform for adding filename in source box according to action
        //

        private void nActionCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] arr;
            string filename;
            string ext;
            
            //nSourceCombo.Items.Clear();
            //switch (nActionCombo.Text)
            //{
            //    case "Sound":                   

            //        string[] filePaths = Directory.GetFiles(Application.StartupPath + "\\Resx");

            //        foreach (string str in filePaths)
            //        {
            //            filename = str.Remove(0, str.LastIndexOf('\\') + 1);                       
            //            ext = filename.Substring(filename.Length - 3);
            //            filename = filename.Remove(filename.LastIndexOf('.') ,4 );
            //            if (ext == "wav")
            //            {
            //                nSourceCombo.Items.Add(filename);
            //            }
            //        }
            //        if (nSourceCombo.Items.Count == 0)
            //            nSourceCombo.Text = "";
            //        else
            //            nSourceCombo.SelectedIndex = 0; 
                  
            //        filePaths = null;
            //        break;
            //    case "File":
            //        //string[] filePaths2 = Directory.GetFiles(Application.StartupPath + "\\Resx");
            //        //foreach (string str in filePaths2)
            //        //{
            //        //    filename = str.Remove(0, str.LastIndexOf('\\') + 1);                      
            //        //    ext = filename.Substring(filename.Length - 3);                       
            //        //    filename = filename.Remove(filename.LastIndexOf('.'), 4);
            //        //    if (ext == "exe")
            //        //    {
            //        //        nSourceCombo.Items.Add(filename);
            //        //    }
            //        //}
                    
            //        //if (nSourceCombo.Items.Count == 0)
            //        //    nSourceCombo.Text = "";
            //        //else
            //        //    nSourceCombo.SelectedIndex = 0;
            //        //filePaths2 = null;
            //        break;
            //    case "Mail":
            //        //nSourceCombo.Text="";
            //        break;
            //    default:
            //        break;
            //}

        }
        #endregion
    }
}




