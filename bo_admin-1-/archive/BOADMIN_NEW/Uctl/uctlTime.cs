using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ProtocolStructs;
using clsInterface4OME.DSBO;
using clsInterface4OME;
using BOADMIN_NEW.Cls;
using Nevron.UI.WinForm.Controls;
using BOADMIN_NEW.BOEngineServiceTCP;

namespace BOADMIN_NEW.Uctl
{
    public partial class uctlTime : uctlGeneric, Interfaces.IUserCtrl
    {

        #region MEMBERS
        #region UI_DATA
        public Cls.clsEnums.FRM_MODE _mode = clsEnums.FRM_MODE.NA;
        #endregion UI_DATA
        //Client objClient;
        #endregion MEMBERS


        public uctlTime()
        {
            InitializeComponent();


        }
        #region IUserCtrl Members

        public void Init()
        {
            throw new NotImplementedException();
        }

        public void InitControls()
        {
            //  ui_txtDescription.Text = Description_;
            // ui_txtDescription.Text = Description_;
            int start;
            int end;
            string starttime;
            string endtime;
            string[] DayArr = Enum.GetNames(typeof(BOADMIN_NEW.BOEngineServiceTCP.DAYS));
            foreach (string item2 in DayArr)
            {
                DS4Time.dtTimeRow row = clsTimeManager.INSTANCE._DS4Time.dtTime.FindByDay(item2);
                string[] str = row.TimeSpan.Split(',');
                foreach (string item in str)
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
                        if (item2 == "SUN")
                        {
                            for (int i = start; i < end; i++)
                            {
                                ui_lstSunday.SelectedIndex = i;
                            }
                        }
                        else if (item2 == "MON")
                        {
                            for (int i = start; i < end; i++)
                            {
                                ui_lstMonday.SelectedIndex = i;
                            }
                        }
                        else if (item2 == "TUE")
                        {
                            for (int i = start; i < end; i++)
                            {
                                ui_lstTuesday.SelectedIndex = i;

                            }
                        }
                        else if (item2 == "WED")
                        {
                            for (int i = start; i < end; i++)
                            {
                                ui_lstWednesday.SelectedIndex = i;
                            }
                        }
                        else if (item2 == "THU")
                        {
                            for (int i = start; i < end; i++)
                            {
                                ui_lstThursday.SelectedIndex = i;
                            }
                        }
                        else if (item2 == "FRI")
                        {
                            for (int i = start; i < end; i++)
                            {
                                ui_lstFriday.SelectedIndex = i;
                            }
                        }
                        else if (item2 == "SAT")
                        {
                            for (int i = start; i < end; i++)
                            {
                                ui_lstSaturday.SelectedIndex = i;
                            }
                        }
                    }
                }

            }

        }

        public void SaveMe()
        {
            throw new NotImplementedException();
        }

        #endregion

        private void uctlTime_Load(object sender, EventArgs e)
        {
            InitControls();
        }

        private void nListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetAllItemSelection(ui_lstSunday);
        }

        /// <summary>
        /// gets settings of the controls
        /// </summary>
        /// <param name="nListBox1"></param>
        /// <returns></returns>
        private string GetString(Nevron.UI.WinForm.Controls.NListBox nListBox1)
        {
            string List1String = string.Empty;
            try
            {
                //Logging.FileHandling.WriteAllLog("uctlTime : Enter GetString()");
                int Cnt = nListBox1.SelectedItems.Count;
                if (nListBox1.SelectedItems.Count == 25)
                {
                    Cnt = 24;
                }
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

                int startindex = -1;
                int EndIndex = -1;
                string strind;
                string Endind;
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
                        List1String += strind + ":00 - " + Endind + ":00, ";
                    }
                    else
                    {
                        List1String += strind + ":00 - " + Endind + ":00";

                    }

                }

            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :uctlTime =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in GetString()");
            }
            return List1String;
        }

        /// <summary>
        /// edit time
        /// </summary>
        private void EditTime()
        {
            int i = 0;
            string[] DayArr = Enum.GetNames(typeof(BOADMIN_NEW.BOEngineServiceTCP.DAYS));
            try
            {
                //Logging.FileHandling.WriteAllLog("uctlTime : Enter DoHandleTimeTable()");
            foreach (string item in DayArr)
            {
                TimePS objTimePS = new TimePS();
                clsTimeSettings objclsTimeSettings = new clsTimeSettings();
                objclsTimeSettings.Day = item;
                i++;
                string str = string.Empty;
                switch (i)
                {
                    case 1:
                        str = GetString(ui_lstSunday);
                        break;
                    case 2:
                        str = GetString(ui_lstMonday);
                        break;
                    case 3:
                        str = GetString(ui_lstTuesday);
                        break;
                    case 4:
                        str = GetString(ui_lstWednesday);
                        break;
                    case 5:
                        str = GetString(ui_lstThursday);
                        break;
                    case 6:
                        str = GetString(ui_lstFriday);
                        break;
                    case 7:
                        str = GetString(ui_lstSaturday);
                        break;
                    default:
                        break;

                }
                objclsTimeSettings.TimeSpan = str;
                objclsTimeSettings = clsProxyClassManager.INSTANCE.UpdateTimeSettings(objclsTimeSettings);

                if (objclsTimeSettings.ServerResponseID != clsGlobal.FailureID)
                {
                    clsTimeManager.INSTANCE.DoHandleTimeTable(objclsTimeSettings);
                }
            }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :uctlTime =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in GetString()");
            }
        }


        private void ui_btnOk_Click(object sender, EventArgs e)
        {
            EditTime();
            _frmCommonContainer.Close();

        }

        private void ui_rtlSaturday_Click(object sender, EventArgs e)
        {

        }

        private void ui_btnCancel_Click(object sender, EventArgs e)
        {
            _frmCommonContainer.Close();
        }

        private void ui_lstMonday_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetAllItemSelection(ui_lstMonday);
        }

        private void ui_lstTuesday_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetAllItemSelection(ui_lstTuesday);
        }

        private void ui_lstWednesday_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetAllItemSelection(ui_lstWednesday);
        }

        private void ui_lstThursday_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetAllItemSelection(ui_lstThursday);
        }

        private void ui_lstFriday_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetAllItemSelection(ui_lstFriday);
        }

        public void SetAllItemSelection(NListBox lstBox)
        {

            if (lstBox.SelectedItems.Count == 0)
                return;
            if (lstBox.SelectedItems.Contains(lstBox.Items[24]))
            {
                for (int index = 0; index < lstBox.Items.Count; index++)
                {
                    lstBox.SelectedItem = lstBox.Items[index];
                }
            }
        }

        private void ui_lstSaturday_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetAllItemSelection(ui_lstSaturday);
        }
    }
}
