///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION	
//04/02/2012	NAMO	    1.Desgining of the form
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PALSA.Cls;
using System.Data;

namespace PALSA.Frm
{
    public partial class frmParticipaintList : frmBase
    {
        //string _title;
        private static int count;
        private string _formkey;

        public frmParticipaintList()
        {
            InitializeComponent();
            count += 1;
            _formkey = CommandIDS.PARTICIPANT_LIST.ToString() + "/" + Convert.ToString(count);
        }

        public override string Formkey
        {
            get { return _formkey; }
        }

        public override string Title
        {
            get { return Text; }
            set { Text = value; }
        }

        private void frmParticipaintList_FormClosed(object sender, FormClosedEventArgs e)
        {
            count -= 1;
            clsTWSOrderManagerJSON.INSTANCE.OnParticipantResponse -= participants_OnParticipantResponse;
            _formkey = CommandIDS.PARTICIPANT_LIST.ToString() + "/" + Convert.ToString(count);
        }

        private void frmParticipaintList_Load(object sender, EventArgs e)
        {
            Text = uctlParticipantList1.Title;
            MinimumSize = Size;
            MaximumSize = Size;
            uctlParticipantList1.ui_uctlGridParticipantList.DataSource = clsTWSOrderManagerJSON.INSTANCE.accountInfoDS.dtAccountInfo;
            //clsTWSOrderManagerJSON.INSTANCE.OnParticipantResponse += participants_OnParticipantResponse;
        }

        private void participants_OnParticipantResponse(Dictionary<int, DataRow> obj)
        {
            Action A = () =>
            {
                clsTWSOrderManagerJSON.INSTANCE.accountInfoDS.dtAccountInfo.AcceptChanges(); 
                uctlParticipantList1.ui_uctlGridParticipantList.DataSource = clsTWSOrderManagerJSON.INSTANCE.accountInfoDS.dtAccountInfo;
            };
            if (this.InvokeRequired)
            {
                this.BeginInvoke(A);
            }
            else
            {
                A();
            }
        }

        private void uctlParticipantList1_OnGridMouseDown(object arg1, MouseEventArgs arg2)
        {
            if (uctlParticipantList1.ui_uctlGridParticipantList.Rows.Count > 0)
            {
                uctlParticipantList1.ui_uctlGridParticipantList.ContextMenuStrip.Items["SaveAs"].Enabled = true;
            }
            else
            {
                uctlParticipantList1.ui_uctlGridParticipantList.ContextMenuStrip.Items["SaveAs"].Enabled = false;
            }
        }
    }
}