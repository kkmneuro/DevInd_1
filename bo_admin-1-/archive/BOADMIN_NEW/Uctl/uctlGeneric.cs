using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BOADMIN_NEW.Forms;
namespace BOADMIN_NEW.Uctl
{
    public partial class uctlGeneric : UserControl
    {
        public Forms.frmCommonContainer _frmCommonContainer = null;
        public string _ContainerCaption = string.Empty;
        public uctlGeneric()
        {
            InitializeComponent();
        }
        public void ShowDialog()
        {
            _frmCommonContainer = null;
            _frmCommonContainer = new BOADMIN_NEW.Forms.frmCommonContainer();
            _frmCommonContainer.Text = _ContainerCaption;
            _frmCommonContainer.Controls.Add(this);
           // _frmCommonContainer.Sizable = false;
            _frmCommonContainer.MaximizeBox = false;
            _frmCommonContainer.KeyPreview = true;
            _frmCommonContainer.ShowDialog();
           
        }
       
    }
}
