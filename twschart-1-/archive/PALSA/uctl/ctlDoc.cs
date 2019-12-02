using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PALSA.uctl
{
    public partial class ctlDoc : UserControl
    {
        private string _url;
        public string Url
        {
            get { return _url; }
            set
            {
                _url = value;
                webBrowser1.Navigate(value);
            }
        }

        public string Title;
        public ctlDoc()
        {
            InitializeComponent();
        }

        public ctlDoc(string path,string title)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            webBrowser1 = new WebBrowser();

            //webBrowser1.DocumentCompleted += WebBrowser1_DocumentCompleted;
            //webBrowser1.Navigated += WebBrowser1_Navigated;
            //webBrowser1.Navigating += WebBrowser1_Navigating;
            

            Url = path;
            this.Title = title;
        }

        //void WebBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        //{
        //    //_mainFormInstance.ShowStatus("Connected.");
        //}

        //private void WebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        //{
        //    //_mainFormInstance.ShowStatus("Connected.");
        //}

        //private void WebBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        //{
        //    //_mainFormInstance.ShowStatus("Opening " + Title + "...");
        //}
    }
}
