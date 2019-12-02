using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Nevron.UI.WinForm.Controls;
using System.Windows.Forms;
using PALSA.uctl;
//using Microsoft.Office.Interop.Word;
//using Microsoft.Office.Core;


namespace PALSA.Frm
{
    public partial class frmViewMail : NForm
    {
        public frmViewMail()
        {
            InitializeComponent();
        }

        private void txtMail_TextChanged(object sender, EventArgs e)
        {

        }
        public void DisplayMail(string datevalue,string subject,string fromvalue, string mailinfo)
        {
            lbl_valName.Text = fromvalue;
            lbl_valDate.Text = datevalue;
            lbl_valSubject.Text = subject;
            webBrowser1.Navigate("about:blank");
            webBrowser1.Document.Write(mailinfo);
     //       webBrowser1.Document.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'><html xmlns='http://www.w3.org/1999/xhtml'><head><title></title>"+
     //"</head><body><p><strong>Dear aaaaaa! </strong></p><p>Thank you for signing up. An account has been opened for you with the following parameters: </p><p>Name : aaaaaa</p><p>Email : <a href='mailto:aaa@a.com'>aaa@a.com</a></p><p>Login : 1111785"+
     //"</p><p>Password : hsn1ilj</p><p>Investor : fkpc1wm</p></body></html>");
 //webBrowser1.Document.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'><html xmlns='http://www.w3.org/1999/xhtml'><head><title></title>"+
 //    "</head><body>"+mailinfo+"</body></html>");
            ////ratan
            //string path = frmMainGTS.strExePath_+"\\Mobile.docx";     
            //object file = path;
            //object nullobj = System.Reflection.Missing.Value;
            //ApplicationClass msapp = new ApplicationClass();
            //Microsoft.Office.Interop.Word.Document doc = msapp.Documents.Open(ref file, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj);
            //doc.ActiveWindow.Selection.WholeStory();
            //doc.ActiveWindow.Selection.Copy();
            //txtMail.Paste();
            //doc.Close(ref nullobj, ref nullobj, ref nullobj);
            //msapp.Quit(ref nullobj, ref nullobj, ref nullobj);
           
          //  ratan
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }



        private void frmViewMail_Load(object sender, EventArgs e)
        {

        }

        private void btnAnswer_Click(object sender, EventArgs e)
        {
            frmAlertSendMail objSendMail = new frmAlertSendMail(uctlMailGrid.GetReferenceMailGrid());
            objSendMail.DispalyItem(lbl_valSubject.Text);
            objSendMail.ShowDialog();
            this.Close();
        }

    }
}
