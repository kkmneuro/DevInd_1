using System;
using System.Drawing;

namespace CommonLibrary.UserControls
{
    public partial class UctlAboutUs : UctlBase
    {
        public UctlAboutUs()
        {
            InitializeComponent();
        }

        public override string Title
        {
            get { return Text; }
            set { Text = value; }
        }

        public Image Logo
        {
            get { return picBox.Image; }
            set { picBox.Image = value; }
        }

        public string ContactAddText
        {
            get { return lblContactAdd.Text; }
            set { lblContactAdd.Text = value; }
        }

        public string CopyrightText
        {
            get { return lblCopyright.Text; }
            set { lblCopyright.Text = value; }
        }

        public string ProductNameText
        {
            get { return lblProductName.Text; }
            set { lblProductName.Text = value; }
        }

        public string NoticeText
        {
            get { return lblNotice.Text; }
            set { lblNotice.Text = value; }
        }

        public string VersionText
        {
            get { return lblVersion.Text; }
            set { lblVersion.Text = value; }
        }

        public event Action<object, EventArgs> OnCloseAboutUs = delegate { };

        private void nButton1_Click(object sender, EventArgs e)
        {
            OnCloseAboutUs(sender, e);
        }
    }
}