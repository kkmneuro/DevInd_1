using System;
using System.Collections.Generic;
using TWS.Cls;

namespace TWS.Frm
{
    public partial class frmMails : frmBase
    {
        public frmMails()
        {
            InitializeComponent();
        }

        public override string Title
        {
            get { return Text; }
            set { Text = value; }
        }

        public void PopulateMail(List<MailData> Mails)
        {
            #region
            //uctlTerminalWindowMails1.ui_uctlGridMails.Rows.Clear();
            //if (Mails != null)
            //{
            //    foreach (MailData mail in Mails)
            //    {
            //        int x = uctlTerminalWindowMails1.ui_uctlGridMails.Rows.Add(1);
            //        //if (ndgMail.CurrentRow != null)
            //        //{

            //        uctlTerminalWindowMails1.ui_uctlGridMails.Rows[x].Cells["colmailDate"].Value = mail.MsgTime;
            //        uctlTerminalWindowMails1.ui_uctlGridMails.Rows[x].Cells["colmailSubject"].Value = mail.Subject;
            //        int strindex = mail.Discription.IndexOf("<body>");
            //        int lastindex = mail.Discription.LastIndexOf("</body>");
            //        uctlTerminalWindowMails1.ui_uctlGridMails.Rows[x].Cells["colmailBody"].Value = mail.Discription.Substring(strindex, lastindex - strindex);
            //        uctlTerminalWindowMails1.ui_uctlGridMails.Rows[x].Cells["colDescription"].Value = mail.Discription;
            //        //ndgMail.Rows[x].Cells["colmailTo"].Value = mail.Recipient;
            //        //ndgMail.Rows[x].Cells["colmailFrom"].Value = mail.Sender;
            //        //}

            //    }
            //}
#endregion
            

        }

        private void frmMails_Load(object sender, EventArgs e)
        {
            uctlTerminalWindowMails1.OnMailSendClick += new Action<string>(uctlTerminalWindowMails1_OnMailSendClick);
            uctlTerminalWindowMails1.ui_uctlGridMails.DataSource = clsTWSOrderManagerJSON.INSTANCE.accountInfoDS.dtMailData;            
        }

        void uctlTerminalWindowMails1_OnMailSendClick(string obj)
        {
            Cls.AlertAction mail_ = new Cls.AlertAction();
            mail_.sendmail(obj);
        }
    }
}
