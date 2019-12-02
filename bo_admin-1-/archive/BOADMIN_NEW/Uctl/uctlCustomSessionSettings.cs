using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using clsInterface4OME.DSBO;
using BOADMIN_NEW.Cls;


namespace BOADMIN_NEW.Uctl
{
    public partial class uctlCustomSessionSettings : uctlGeneric, Interfaces.IUserCtrl
    {

        public DS4Symbol.dtSessionRow[] _row = null;

        public string strTrade = string.Empty;
        public string strQuotes = string.Empty;
        public uctlCustomSessionSettings()
        {

            InitializeComponent();
            ui_chkEnable.Checked = false;

        }
        #region IUserCtrl Members

        public void Init()
        {
            throw new NotImplementedException();
        }

        public void InitControls()
        {
            if (_row == null)
                return;
            string[] quotes;
            string day = _row[0].Day;
            strTrade = _row[0].Trade;
            strQuotes = _row[0].Quotes;
            if (_row[0].Quotes != string.Empty)
            {
                quotes = _row[0].Quotes.Split(',');
            }
            else
            {
                quotes = new string[1];
                quotes[0] = string.Empty;
            }
            FillQuotes(quotes);
            CheckEnableTrading();
        }
        private void FillQuotes(string[] quotes)
        {
            string starttime;
            string endtime;
            int start;
            int end;
            try
            {
                //Logging.FileHandling.WriteAllLog("uctlCustomSessionSettings : Enter FillQuotes()");
                foreach (string item in quotes)
                {
                    if (item == "" || item == " ")
                        break;
                    else
                    {
                        string[] timepart = item.Split('-');
                        starttime = timepart[0];
                        endtime = timepart[1];
                        string[] part1 = starttime.Split(':');
                        if (part1[0] == "" || part1[0] == " ")
                            start = 0;
                        else
                            start = Convert.ToInt32(part1[0]);
                        string[] part2 = endtime.Split(':');
                        if (part2[0] == "" || part2[0] == " ")
                            end = 0;
                        else
                            end = Convert.ToInt32(part2[0]);
                        for (int i = start; i < end; i++)
                        {
                            ui_lstQuotes.SelectedIndex = i;
                        }
                    }
                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :uctlCustomSessionSettings =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in FillQuotes()");
            }
        }
        private void FillTrade(string[] trades)
        {
            string starttime;
            string endtime;
            int start;
            int end;
            foreach (string item in trades)
            {
                if (item == "" || item == " ")
                    break;
                else
                {
                    string[] timepart = item.Split('-');
                    starttime = timepart[0];
                    endtime = timepart[1];
                    string[] part1 = starttime.Split(':');
                    if (part1[0] == "" || part1[0] == " ")
                        start = 0;
                    else
                        start = Convert.ToInt32(part1[0]);
                    string[] part2 = endtime.Split(':');
                    if (part2[0] == "" || part2[0] == " ")
                        end = 0;
                    else
                        end = Convert.ToInt32(part2[0]);
                    for (int i = start; i < end; i++)
                    {
                        ui_lstTrade.SelectedIndex = i;
                    }
                }
            }
        }
        private string generateString(Nevron.UI.WinForm.Controls.NListBox nListBox1)
        {
            int Cnt = nListBox1.SelectedItems.Count;
            string SelString = string.Empty;
            for (int iSelLoop = 0; iSelLoop < Cnt; iSelLoop++)
            {

                SelString += nListBox1.SelectedItems[iSelLoop].ToString() + ",";

            }
            if (SelString == "*,")
                return "";
            string[] selstringarr = SelString.Split(',');
            int i = 0;
            int j = 0;
            string List1String = string.Empty; ;


            ///////////////// 30-9-14

            int startindex = -1;
            int EndIndex = -1;
            string strind;
            string Endind;
            try
            {
                //Logging.FileHandling.WriteAllLog("uctlCustomSessionSettings : Enter generateString()");
                while (i < 24 && j < Cnt)
                {
                    while (i != Convert.ToInt32(selstringarr[j]) && i < 24)
                        i++;
                    if (i < 24)
                        startindex = Convert.ToInt32(selstringarr[j]);
                    if (startindex < 10)
                        strind = "0" + startindex.ToString();
                    else
                        strind = startindex.ToString();
                    while (j < Cnt && i < 24 && i == Convert.ToInt32(selstringarr[j]))
                    {
                        i++;
                        j++;
                    }
                    if (i <= 24)
                        EndIndex = i;
                    if (EndIndex < 10)
                        Endind = "0" + EndIndex.ToString();
                    else
                        Endind = EndIndex.ToString();
                    if (j < Cnt)
                    {
                        List1String += strind + ":" + "00" + " - " + Endind + ":" + "00" + " , ";
                    }
                    else
                    {
                        List1String += strind + ":" + "00" + " - " + Endind + ":" + "00";

                    }

                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :uctlCustomSessionSettings =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in generateString()");
            }
            return List1String;
        }
        private void generateQuoteString()
        {
            strQuotes = generateString(ui_lstQuotes);
        }
        private void generateTradeString()
        {
            strTrade = generateString(ui_lstTrade);
        }
        public void SaveMe()
        {
            throw new NotImplementedException();
        }

        #endregion
        private void ui_chkEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (ui_lstQuotes.SelectedIndex == 24 && ui_chkEnable.Checked == true)
            {
                clsDialogBox.ShowErrorBox("Please select Quotes Session Time.", "Session Selection Error", false);
                ui_chkEnable.Checked = false;
            }
            else
                CheckEnableTrading();
        }
        private void CheckEnableTrading()
        {
            string[] trades;
            if (strTrade == string.Empty)
            {
                trades = new string[1];
                trades[0] = string.Empty;
            }
            else
                trades = strTrade.Split(',');
            if (ui_chkEnable.Checked == true)
            {
                ui_lstTrade.Enabled = true;
                FillTrade(trades);
            }
            else
            {
                while (ui_lstTrade.SelectedItems.Count != 0)
                {
                    ui_lstTrade.SelectedItems.Remove(ui_lstTrade.SelectedItems[0]);
                }

                ui_lstTrade.Enabled = false;
            }
        }

        private void uctlCustomSessionSettings_Load(object sender, EventArgs e)
        {

        }

        private void ui_btnancel_Click(object sender, EventArgs e)
        {
            _frmCommonContainer.Close();
        }
        private void ui_lstTrade_MouseUp(object sender, MouseEventArgs e)
        {
            if (ui_lstTrade.SelectedItems.Contains(ui_lstTrade.Items[24]) && ui_lstTrade.SelectedItems.Count > 1)
                ui_lstTrade.SetSelected(24, false);
            generateTradeString();
            CheckEnableTrading();
        }

        private void ui_lstQuotes_MouseUp(object sender, MouseEventArgs e)
        {
            if (ui_lstQuotes.SelectedItems.Contains(ui_lstQuotes.Items[24]) && ui_lstQuotes.SelectedItems.Count > 1)
                ui_lstQuotes.SetSelected(24, false);
            generateQuoteString();
            string[] quotes = strQuotes.Split(',');
            FillQuotes(quotes);
        }

        private void ui_btnOK_Click(object sender, EventArgs e)
        {
            EditSessionRow();

        }

        private bool CheckTradeBoundary()
        {

            int cQuote = ui_lstQuotes.SelectedItems.Count;
            int cTrade = ui_lstTrade.SelectedItems.Count;
            if (cQuote < cTrade)
                return false;
            int[] arrQuote = new int[cQuote];
            int[] arrTrade = new int[cTrade];
            for (int i = 0; i < cQuote; i++)
            {
                if (ui_lstQuotes.SelectedItems[i].ToString() != "*")
                    arrQuote[i] = Convert.ToInt32(ui_lstQuotes.SelectedItems[i].ToString());
            }
            for (int i = 0; i < cTrade; i++)
            {
                if (ui_lstTrade.SelectedItems[i].ToString() == "*")
                {
                    return false;
                }
                else if (ui_lstQuotes.SelectedItems[i].ToString() != "*")
                    arrTrade[i] = Convert.ToInt32(ui_lstTrade.SelectedItems[i].ToString());
            }
            foreach (int item1 in arrTrade)
            {
                int check = 0;
                foreach (int item2 in arrQuote)
                {
                    if (item1 == item2)
                    {
                        check = 1;
                    }
                }
                if (check == 0)
                    return false;

            }
            return true;
        }
        private void EditSessionRow()
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("uctlCustomSessionSettings : Enter EditSessionRow()");
                if (_row == null)
                    return;
                if (ui_chkEnable.Checked == true)
                {

                    if (CheckTradeBoundary() == true)
                    {

                        _row[0].Quotes = strQuotes;
                        _row[0].Trade = strTrade;
                        _row[0].AcceptChanges();
                        _frmCommonContainer.Close();
                    }
                    else
                        clsDialogBox.ShowErrorBox("Trade Sassion Time should not beyond Quotes Session Time.", "Session Selection Error", true);
                }
                else
                {
                    _row[0].Quotes = strQuotes;
                    _row[0].Trade = strQuotes;
                    _row[0].AcceptChanges();
                    _frmCommonContainer.Close();
                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :uctlCustomSessionSettings =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in EditSessionRow()");
            }

        }

        private void nuiPanel1_Click(object sender, EventArgs e)
        {

        }

    }
}
