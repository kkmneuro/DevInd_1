using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using PALSA.Frm;
using PALSA.Cls;
//using ProtocolStructs;

namespace PALSA.uctl
{
    public partial class uctlMailGrid : UserControl
    {
       
        private int Mailgridrowindex_;       
        private int MailCount_ = 0;
        BackgroundWorker MailBackThread = null;
        //BackgroundWorker MailViewBackThread = null;
       // MailRequestPS Mails = null;
        public string mailFile_ = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "LTechIndia\\LTechIndiaSetting\\Mails.mail";
     


        public uctlMailGrid()
        {
            if (InstanceMailGrid != null)
            {
                throw new Exception("Object already created");
            }
            InitializeComponent();
            if (!System.IO.Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "LTechIndia\\LTechIndiaSetting"))//\\Mails.mail
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "LTechIndia\\LTechIndiaSetting");
            }
             
            #region Unused code rewritten in Init()
            //    Mails = new ConnectionPlugin.Common.DataStruct.MailRequestData();

        //    MailBackThread = new BackgroundWorker();           
        //    MailBackThread.DoWork += new DoWorkEventHandler(MailBackThread_DoWork);
        //    MailBackThread.RunWorkerCompleted += new RunWorkerCompletedEventHandler(MailBackThread_RunWorkerCompleted);
        //    MailBackThread.RunWorkerAsync();

        //   // MailViewBackThread = new BackgroundWorker();
        //  //  MailViewBackThread.DoWork += new DoWorkEventHandler(MailViewBackThread_DoWork);
            //   // MailViewBackThread.RunWorkerCompleted += new RunWorkerCompletedEventHandler(MailViewBackThread_RunWorkerCompleted);
            #endregion

             InstanceMailGrid = this;
        }

        private static uctlMailGrid InstanceMailGrid =null;
        public static uctlMailGrid GetReferenceMailGrid()
        {
            if (InstanceMailGrid == null)
                InstanceMailGrid = new uctlMailGrid();

            return InstanceMailGrid;
        
        }


        public void InitMailControl()
        {
            ndgMail.Dock = DockStyle.Fill;
            MailBackThread = new BackgroundWorker();
            MailBackThread.DoWork += new DoWorkEventHandler(MailBackThread_DoWork);
            MailBackThread.RunWorkerCompleted += new RunWorkerCompletedEventHandler(MailBackThread_RunWorkerCompleted);
            MailBackThread.RunWorkerAsync();

        }
        
        #region CommentedCode
        //void MailViewBackThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
           

        //}

        //void MailViewBackThread_DoWork(object sender, DoWorkEventArgs e)
        //{

        //    lock (ndgMail)
        //    {
        //        string timeValue, subject, Headline, Body;
        //        Mailgridrowindex_ = ndgMail.SelectedRows[0].Index;
        //        ((TextAndImageCell)ndgMail.Rows[Mailgridrowindex_].Cells["colmailDate"]).Image = imgViewMail_;
        //        //ndgMail.Refresh();
        //        timeValue = ndgMail.Rows[Mailgridrowindex_].Cells["colmailDate"].Value.ToString();
        //        subject = ndgMail.Rows[Mailgridrowindex_].Cells["colmailSubject"].Value.ToString();
        //        Headline = ndgMail.Rows[Mailgridrowindex_].Cells["colmailFrom"].Value.ToString();
        //        Body = ndgMail.Rows[Mailgridrowindex_].Cells["colmailBody"].Value.ToString();
        //        frmViewMail objViewMail = new frmViewMail();
        //        objViewMail.DisplayMail(timeValue, subject, Headline, Body);
        //        objViewMail.ShowDialog();
        //    }
        //}       
        #endregion

        public void PopulateMail(List<MailData> Mails)
        {
            ndgMail.Rows.Clear();
            if (Mails != null)
            {
                foreach (MailData mail in Mails)
                {
                    int x=ndgMail.Rows.Add(1);
                    //if (ndgMail.CurrentRow != null)
                    //{

                        ndgMail.Rows[x].Cells["colmailDate"].Value = mail.MsgTime;
                        ndgMail.Rows[x].Cells["colmailSubject"].Value = mail.Subject;
                        int strindex = mail.Discription.IndexOf("<body>");
                        int lastindex = mail.Discription.LastIndexOf("</body>");
                        ndgMail.Rows[x].Cells["colmailBody"].Value = mail.Discription.Substring(strindex, lastindex - strindex);
                        ndgMail.Rows[x].Cells["colDescription"].Value = mail.Discription;
                        //ndgMail.Rows[x].Cells["colmailTo"].Value = mail.Recipient;
                        //ndgMail.Rows[x].Cells["colmailFrom"].Value = mail.Sender;
                    //}

                }
            }
        }
        void MailBackThread_DoWork(object sender, DoWorkEventArgs e)
        {

            //MailRequest mail = new MailRequest();
            //while (Thread.CurrentThread.IsAlive)
            //{
            //    if (ndgMail.RowCount != 0)
            //        mail.StartTime_ = Convert.ToDateTime(ndgMail.Rows[0].Cells["colmailDate"].Value);
            //    else
            //        mail.StartTime_ = DateTime.Today;
            //    mail.EndTime_ = DateTime.UtcNow;
            //    string[] AccID = { "" };//KulfrmMainGTS.GetReference().Text.Split(':');
            //    AccID[0] = "10098";
            //    if ((AccID[0] != String.Empty))
            //    {
            //        mail.AccountID_ = 10098;
            //        OrderManager.getOrderManager().SendData(new MailRequestPS
            //           {
            //               MailRequest_ = mail
            //           });
            //    }
            //    Thread.Sleep(1000);
            //}
        }

        void MailBackThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        //public delegate void delAddSingleMailInGrid(MailResponse value);
        //public void AddMailInGrid(MailResponse Mail)
        //{
        //    if (InvokeRequired)
        //    {
        //        BeginInvoke(new delAddSingleMailInGrid(AddMailInGrid), Mail);
        //    }
        //    else
        //    {
        //        ndgMail.Rows.Add();
        //        int rowindex = ndgMail.RowCount - 1;
        //        ndgMail.Rows[rowindex].Cells["colmailFrom"].Value = Mail.SenderEMailOrName_;
        //        ndgMail.Rows[rowindex].Cells["colmailTO"].Value = "ashutosh";
        //        ndgMail.Rows[rowindex].Cells["colmailSubject"].Value = Mail.MailSubject_;
        //        ndgMail.Rows[rowindex].Cells["colmailDate"].Value = Mail.SendingTime_;
        //        ((TextAndImageCell)ndgMail.Rows[rowindex].Cells["colmailDate"]).Image = Properties.Resources.unreadmail;
        //        ndgMail.Rows[rowindex].Cells["colmailBody"].Value = Mail.MailContents_;
        //    }
        //}
        public void SaveMails()
        {          
           
            try
            {
                //List<MailResponse> lstMail = new List<MailResponse>();
                //if(ndgMail.RowCount>0)
                //{
                //    foreach (DataRow dr in ndgMail.Rows)
                //    {
                //        MailResponse MD = new MailResponse
                //        {
                //            SenderEMailOrName_=dr["colmailFrom"].ToString(),
                //            MailSubject_= dr["colmailSubject"].ToString(),     
                //            MailContents_=dr["colmailBody"].ToString(),
                //            SendingTime_= Convert.ToDateTime(dr["colmailDate"].ToString())         
                //        };
                //        lstMail.Add(MD);
                //    }
                //     IFormatter serializer = new BinaryFormatter();
                //    FileStream saveFile = new FileStream(mailFile_, FileMode.Create, FileAccess.Write);
                //    serializer.Serialize(saveFile, lstMail);
                //    saveFile.Close();

                //}
              
            }
            catch
            {
                
            }
        }

        public void LoadMails()
        {
            //List<MailResponse> lstMail_ = null;
            //if (!System.IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "GalaxyTradestation\\GalaxySetting\\Mails.mail"))
            //{
            //    return;
            //}
            try
            {
            //    IFormatter serializer = new BinaryFormatter();
            //    FileStream loadFile = new FileStream(mailFile_, FileMode.Open, FileAccess.Read);
            //    lstMail_ = (List<MailResponse>)serializer.Deserialize(loadFile);
            //    loadFile.Close();

            }
            catch 
            {
               
            }   
        
        }

        private void InvokeAction(string action)
        {

            switch (action)
            {
                case "ctmMailCreate":
                    {
                        ctmMail.Visible = false;
                        frmAlertSendMail objSendMail = new frmAlertSendMail(this);
                        objSendMail.DispalyItem("Re:Registration");
                        objSendMail.ShowDialog();
                        break;
                    }
                case "ctmMailView":
                    {
                        ctmMail.Visible = false;
                        frmViewMail objViewMail = new frmViewMail();
                        Mailgridrowindex_ = ndgMail.SelectedRows[0].Index;
                        //((TextAndImageCell)ndgMail.Rows[Mailgridrowindex_].Cells["colmailDate"]).Image = Properties.Resources.file_strip;//Kul
                        //ndgMail.Refresh();
                        string timeValue = ndgMail.Rows[Mailgridrowindex_].Cells["colmailDate"].Value.ToString();
                        string subject = ndgMail.Rows[Mailgridrowindex_].Cells["colmailSubject"].Value.ToString();
                        string Headline = ndgMail.Rows[Mailgridrowindex_].Cells["colmailFrom"].Value.ToString();
                        string Body = ndgMail.Rows[Mailgridrowindex_].Cells["colDescription"].Value.ToString();
                        objViewMail.DisplayMail(timeValue, subject, Headline, Body);
                        objViewMail.ShowDialog();                        
                        break;
                    }
                case "ctmMailDelete":
                    {
                        ctmMail.Visible = false;
                        Mailgridrowindex_ = ndgMail.SelectedRows[0].Index;
                        ndgMail.Rows.RemoveAt(Mailgridrowindex_);
                        ndgMail.Invalidate();
                      
                        break;
                    }
                case "autoArrangeToolStripMenuItem":
                    {
                        ctmMail.Visible = false;
                        ndgMail.AutoResizeColumns();
                        break;
                    }
                case "gridToolStripMenuItem":
                    {
                        ctmMail.Visible = false;
                        if (this.ndgMail.CellBorderStyle == DataGridViewCellBorderStyle.Single)
                            this.ndgMail.CellBorderStyle = DataGridViewCellBorderStyle.None;
                        else if (this.ndgMail.CellBorderStyle == DataGridViewCellBorderStyle.None)
                            this.ndgMail.CellBorderStyle = DataGridViewCellBorderStyle.Single; 
                        break;
                    }

                default:
                    break;
            }
        
        
        }

        private void ctmMail_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            InvokeAction(e.ClickedItem.Name);
        }

        private void ndgMail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                InvokeAction("ctmMailCreate");
            }

            if (e.KeyCode == Keys.Enter)
            {
                InvokeAction("ctmMailView");
            }
            if (e.KeyCode == Keys.Delete)
            {
                InvokeAction("ctmMailDelete");
            }
            if (e.KeyCode == Keys.A)
            {
                InvokeAction("autoArrangeToolStripMenuItem");
            }
            if (e.KeyCode == Keys.G)
            {
                InvokeAction("gridToolStripMenuItem");
            }

        }

       private  void ndgMail_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (ndgMail.RowCount >= 0)
            {
                DataGridView.HitTestInfo hti = this.ndgMail.HitTest(e.X, e.Y);
                if (hti.RowIndex > -1)
                {
                    frmViewMail objViewMail = new frmViewMail();
                    string timeValue = ndgMail.Rows[hti.RowIndex].Cells["colmailDate"].Value.ToString();
                    string subject = ndgMail.Rows[hti.RowIndex].Cells["colmailSubject"].Value.ToString();
                    string Headline = ndgMail.Rows[hti.RowIndex].Cells["colmailFrom"].Value.ToString();
                    string Body = ndgMail.Rows[hti.RowIndex].Cells["colmailBody"].Value.ToString();
                    objViewMail.DisplayMail(timeValue, subject, Headline, Body);
                    objViewMail.ShowDialog();
                }
            }
        }

       private void ndgMail_MouseDown(object sender, MouseEventArgs e)
       {
               ndgMail.ClearSelection();
               DataGridView.HitTestInfo hti = this.ndgMail.HitTest(e.X, e.Y);
               if (e.Button == MouseButtons.Right)
               {
                   if (hti.RowIndex < 0)
                   {
                       if (ndgMail.RowCount > 0)
                       {
                           ctmMail.Items["ctmMailCreate"].Enabled = true;
                           ctmMail.Items["ctmMailView"].Enabled = false;
                           ctmMail.Items["ctmMailDelete"].Enabled = false;
                           ctmMail.Items["autoArrangeToolStripMenuItem"].Enabled = true;
                           ctmMail.Items["gridToolStripMenuItem"].Enabled = true;
                       }
                       else
                       {
                           ctmMail.Items["ctmMailCreate"].Enabled = true;
                           ctmMail.Items["ctmMailView"].Enabled = false;
                           ctmMail.Items["ctmMailDelete"].Enabled = false;
                           ctmMail.Items["autoArrangeToolStripMenuItem"].Enabled = false;
                           ctmMail.Items["gridToolStripMenuItem"].Enabled = false;
                       }
                   }
                   else 
                   {
                       ctmMail.Items["ctmMailCreate"].Enabled = true;
                       ctmMail.Items["ctmMailView"].Enabled = true;
                       ctmMail.Items["ctmMailDelete"].Enabled = true;
                       ctmMail.Items["autoArrangeToolStripMenuItem"].Enabled = true;
                       ctmMail.Items["gridToolStripMenuItem"].Enabled = true;
                       ndgMail.Rows[hti.RowIndex].Selected = true;
                   }
              
           }
       }
       void uctlMailGrid_Load(object sender, System.EventArgs e)
       {
           InitMailControl();
           ndgMail.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           //ndgMail.ColColumnHeadersCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
       }

        //public void OnMails(MailResponse mail)
        //{
        //    AddMailInGrid(mail);
        //}

        //public void OnNewData(MailResponse NewData)
        //{
        //    OnMails(NewData);            
        //}

        private void ndgMail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }




        
    }

}
