///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION	
//04/02/2012	NAMO	    1.Desgining of the form
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Windows.Forms;
//using Logging;
using PALSA.Cls;

namespace PALSA.Frm
{
    public partial class frmMarketStatus : frmBase
    {
        //string _title;


        private static int count;
        private string _formkey;

        public frmMarketStatus()
        {
            //FileHandling.WriteDevelopmentLog("MarketStatus" + count +" : Enter into frmMarketStatus Constructor");

            InitializeComponent();
            count += 1;
            _formkey = CommandIDS.MARKET_STATUS.ToString() + "/" + Convert.ToString(count);

            //FileHandling.WriteDevelopmentLog("MarketStatus" + count + " : Exit from frmMarketStatus Constructor");
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

        private void frmMarketStatus_Load(object sender, EventArgs e)
        {
            //FileHandling.WriteDevelopmentLog("MarketStatus" + count +" : Enter into frmMarketStatus_Load Method");
            MinimumSize = Size;
            MaximumSize = Size;
            Title = uctlMarketStatus1.Title;
            string DConnection = "Disconnected";
            string OConnection = "Disconnected";
            if (clsTWSOrderManagerJSON.INSTANCE.IsOrderMgrLoaded)
                OConnection = "Connected";
            if (clsTWSDataManagerJSON.INSTANCE.IsDataMgrConnected)
                DConnection = "Connected";
            uctlMarketStatus1.ui_uctlGridMarketStatus.Rows.Add("Data Server", DConnection);
            uctlMarketStatus1.ui_uctlGridMarketStatus.Rows.Add("Order Server", OConnection);
            clsTWSDataManagerJSON.INSTANCE.OnDataServerConnectionEvnt -= INSTANCE_OnDataServerConnectionEvnt;
            clsTWSDataManagerJSON.INSTANCE.OnDataServerConnectionEvnt += INSTANCE_OnDataServerConnectionEvnt;
            clsTWSOrderManagerJSON.INSTANCE.OnOrderServerConnectionEvnt -= INSTANCE_OnOrderServerConnectionEvnt;
            clsTWSOrderManagerJSON.INSTANCE.OnOrderServerConnectionEvnt += INSTANCE_OnOrderServerConnectionEvnt;
            clsTWSOrderManagerJSON.INSTANCE.OnBothServerConnectionEvnt -= INSTANCE_OnBothServerConnectionEvnt;
            clsTWSOrderManagerJSON.INSTANCE.OnBothServerConnectionEvnt += INSTANCE_OnBothServerConnectionEvnt;
            //AddDataToGrid(null, null);
            //FileHandling.WriteDevelopmentLog("MarketStatus" + count + " : Exit from frmMarketStatus_Load Method");
        }

        void INSTANCE_OnBothServerConnectionEvnt(string obj)
        {
            //_DDMessages["Order Server"] = obj;
            uctlMarketStatus1.ui_uctlGridMarketStatus.Rows[1].Cells["clmStatus"].Value = obj;
            //_DDMessages["Data Server"] = obj;
            uctlMarketStatus1.ui_uctlGridMarketStatus.Rows[0].Cells["clmStatus"].Value = obj;
        }

        private void INSTANCE_OnOrderServerConnectionEvnt(string msg)
        {
            //FileHandling.WriteDevelopmentLog("MarketStatus" + count +" : Enter into INSTANCE_OnOrderServerConnectionEvnt Method");

            //AddDataToGrid("Order Server", msg);
            //_DDMessages["Order Server"] = msg;

            uctlMarketStatus1.ui_uctlGridMarketStatus.Rows[1].Cells["clmStatus"].Value = msg;
            //FileHandling.WriteDevelopmentLog("MarketStatus" + count +" : Exit from INSTANCE_OnOrderServerConnectionEvnt Method");
        }

        private void INSTANCE_OnDataServerConnectionEvnt(string msg)
        {
            //FileHandling.WriteDevelopmentLog("MarketStatus" + count +" : Enter into INSTANCE_OnDataServerConnectionEvnt Method");

            //AddDataToGrid("Data Server",msg);
            //_DDMessages["Data Server"] = msg;
            uctlMarketStatus1.ui_uctlGridMarketStatus.Rows[0].Cells["clmStatus"].Value = msg;
            //FileHandling.WriteDevelopmentLog("MarketStatus" + count +" : Exit from INSTANCE_OnDataServerConnectionEvnt Method");
        }

        public void AddDataToGrid(string mrkt, string msg)
        {
            //FileHandling.WriteDevelopmentLog("MarketStatus" + count + " : Enter into AddDataToGrid Method");

            Action A = () =>
                           {
                               foreach (var item in clsTWSDataManagerJSON.INSTANCE._DDMessages)
                               {
                                   uctlMarketStatus1.ui_uctlGridMarketStatus.Rows[0].Cells["clmStatus"].Value = item.Key;
                                   //uctlMarketStatus1.ui_uctlGridMarketStatus.Rows.Add(item.Value,item.Key);
                               }

                               foreach (var item2 in clsTWSOrderManagerJSON.INSTANCE._DDMessages)
                               {
                                   uctlMarketStatus1.ui_uctlGridMarketStatus.Rows[1].Cells["clmStatus"].Value = item2.Key;
                               }
                           };
            if (InvokeRequired)
            {
                BeginInvoke(A);
            }
            else
            {
                A();
            }

            //FileHandling.WriteDevelopmentLog("MarketStatus" + count + " : Exit from AddDataToGrid Method");
        }

        private void frmMarketStatus_FormClosed(object sender, FormClosedEventArgs e)
        {
            //FileHandling.WriteDevelopmentLog("MarketStatus" + count +" : Enter into frmMarketStatus_FormClosed Method");

            count -= 1;
            clsTWSDataManagerJSON.INSTANCE.OnDataServerConnectionEvnt -= INSTANCE_OnDataServerConnectionEvnt;
            clsTWSOrderManagerJSON.INSTANCE.OnOrderServerConnectionEvnt -= INSTANCE_OnOrderServerConnectionEvnt;
            clsTWSOrderManagerJSON.INSTANCE.OnBothServerConnectionEvnt -= INSTANCE_OnBothServerConnectionEvnt;
            _formkey = CommandIDS.MARKET_STATUS.ToString() + "/" + Convert.ToString(count);

            //FileHandling.WriteDevelopmentLog("MarketStatus" + count +" : Exit from frmMarketStatus_FormClosed Method");
        }
    }
}