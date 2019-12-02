using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using PALSA.Cls;

namespace PALSA.ClsAlerts
{

    public enum ALERT_ACTION
    {
        SOUND,
        EMAIL,
        FILE,
        POPUP

    }

    public enum ALERT_TYPE
    {
        BIDLESSTHAN,
        BIDGREATERTHAN,
        ASKLESSTHAN,
        ASKGREATERTHAN,
        TIME
    }

    public enum ALERT_MODE
    {
        CREATE,
        MODIFY,
        DELETE
    }
    public class AlertManager
    {

        #region MEMBERS
        public List<Alert> lstAlerts_ = null;   //List for maintaing Alert object 
        //public bool modify_status = false;
        //List<string> lstWatchedSymbol_;
        Timer TickTimer_ = new System.Timers.Timer(1000.0);
        private static AlertManager alertMgr_ = null;
        public uctlAlert objAlertgrid_ = null;
        string AlertFile_ = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "GalaxyTradestation\\GalaxySetting\\Alerts.alert";


        #endregion

        #region METHODS
        public static AlertManager Getreference()
        {

            if (alertMgr_ == null)
                alertMgr_ = new AlertManager();
            return alertMgr_;

        }

        //
        // This is Constructor used initialising AlertMgr object
        //

        public AlertManager()
        {
            TickTimer_.Enabled = false;
            TickTimer_.Elapsed += new ElapsedEventHandler(TickTimer__Elapsed);
            lstAlerts_ = new List<Alert>();
            if (!System.IO.Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "LTechIndia\\LTechIndiaSetting"))//\\Alerts.alert
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "LTechIndia\\LTechIndiaSetting");
            }
        }

        //
        // This function perform enabling Timer 
        //

        public void enableTimer()
        {
            TickTimer_.Enabled = true;
        }


        //
        // This function perform adding alert in AlertList
        //
        public void AddAlert(Alert alrt)
        {
            lstAlerts_.Add(alrt);
            alrt.OnAlert += new Alert_Handler(alrt_OnAlert);
            CheckAlert(alrt);
            //Namo 21 March
            //Cls.clsTWSDataManagerJSON.INSTANCE.onPriceUpdate -= marketWatch_onPriceUpdate;
            //Cls.clsTWSDataManagerJSON.INSTANCE.onPriceUpdate += marketWatch_onPriceUpdate;

            //if (!lstWatchedSymbol_.Contains(alrt.Symbol))
            //{
            // lstWatchedSymbol_.Add(alrt.Symbol);

            // }

        }

        void INSTANCE_onPriceUpdate(Dictionary<string, Quote> obj)
        {
            lock (lstAlerts_)
            {
                foreach (var item in obj)
                {
                    string[] str = item.Key.Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                    var alrt = lstAlerts_.Find(i => i.Symbol == str[str.Count() - 1]);
                    if (alrt != null)//symbols exists in alert
                    {
                        //Namo 21 March
                        //foreach (QuoteItem quoteItem in item.Value._lstItem)
                        //{
                        //    if (quoteItem._quoteType == QuoteStreamType.ASK || quoteItem._quoteType == QuoteStreamType.BID)
                        //    {
                        //        if (!alrt.Enable)
                        //            continue;
                        //        if (quoteItem._Price != 0 )//&& quoteItem._Size != 0)
                        //        {
                        //            alrt.UpdateAlert(quoteItem);
                        //        }
                        //    }
                        //}
                    }
                }
            }
        }

        //
        //All the activity have done by this function when Alert File
        //
        public void alrt_OnAlert(Alert objAlert)
        {
            AlertManager.Getreference().objAlertgrid_.IncreaseCounterIngrid(objAlert);
            //frmMainGTS.GetReference().InsertLogInGrid("Alert" + ":" + " " + "Symbol" + " " + "=" + " " + objAlert.Symbol + " " + objAlert.Condition + " " + objAlert.Value);
            if (objAlert.Action == ALERT_ACTION.EMAIL)
                objAlert.objAlertAction.sendmail(objAlert.SourcePath);
            if (objAlert.Action == ALERT_ACTION.SOUND)
            {
                objAlert.objAlertAction.PlaySound(objAlert.SourcePath);
            }
            if (objAlert.Action == ALERT_ACTION.FILE)
            {
                objAlert.objAlertAction.Executefile(objAlert.SourcePath);
            }
        }


        //
        //This function is used to get Alert by given ID
        //
        public Alert GetAlert(string ID)
        {
            Alert FindItem = null;
            foreach (Alert item in lstAlerts_)
            {
                if (item.ALERTID == ID)
                {
                    FindItem = item;
                    break;
                }
            }
            return FindItem;

        }

        //Not Used
        public void DisableAlert(string ID)
        {
            Alert alrt = GetAlert(ID);
            if (alrt != null)
            {
                alrt.Enable = false;
            }

        }
        //
        //This function is used for Enable/disable Alert
        //
        public void EnableDisable(string ID)
        {
            Alert Ealrt = GetAlert(ID);
            int i = 0;
            foreach (Alert item in lstAlerts_)
            {
                if (item.ALERTID == Ealrt.ALERTID)
                {
                    if (Ealrt.Enable == false)
                    {
                        if (Ealrt.CheckingCounter == Ealrt.MaximumIterations)
                        {
                            if (Ealrt.imgEnable == true)
                                Ealrt.imgEnable = false;
                            else
                                Ealrt.imgEnable = true;
                        }
                        else
                            Ealrt.Enable = true;
                        break;
                    }
                    else
                    {
                        Ealrt.Enable = false;
                        break;
                    }
                }
                i++;
            }
            lstAlerts_[i] = Ealrt;
            AlertManager.Getreference().objAlertgrid_.ChangeImage(lstAlerts_[i]);
        }

        //
        //This function is used for Delete Alert when click at delete AlertmenuStripItem
        //
        public void RemoveAlert(string ID)
        {
            Alert alrt = GetAlert(ID);
            if (alrt != null)
            {
                lstAlerts_.Remove(alrt);
            }
        }

        //
        //This function is used for getting current Quote for given Symbol 
        //
        //QuoteResponse getLastQuote(string symb)
        //{
        //    return QuoteManager.getQuoteManager().getLastQuote(symb);
        //}

        void TickTimer__Elapsed(object sender, ElapsedEventArgs e)
        {
            //CheckAllAlerts();

        }

        //
        // This function is used for getting Quote of enable Alert
        //
        void CheckAllAlerts()
        {
            lock (lstAlerts_)
            {
                foreach (Alert item in lstAlerts_)
                {
                    if (!item.Enable)
                        continue;
                    //QuoteResponse quote = getLastQuote(item.Symbol);
                    //item.UpdateAlert(quote);
                }
            }

        }
        //
        //This function is used when Alert create
        //
        void CheckAlert(Alert alrt)
        {
            //QuoteResponse quote = getLastQuote(alrt.Symbol);
            //alrt.UpdateAlert(quote);
        }

        public void SaveAlerts()
        {
            TickTimer_.Enabled = false;
            TickTimer_.Dispose();
            TickTimer_ = null;
            try
            {
                //List<IProtocolStruct> lstAlert = new List<IProtocolStruct>();
                //if (lstAlerts_ == null)
                //    return;
                //lock (lstAlerts_)
                //{
                //    foreach (Alert item in lstAlerts_)
                //    {
                //        AlertResponse AD = new AlertResponse
                //        {
                //            Condition_ = item.Condition,
                //            Event_ = item.SourcePath,
                //            Action_ = item.Action.ToString(),
                //            Symbol_ = item.Symbol,
                //            Value_ = item.Value,
                //            Limit_ = item.MaximumIterations,
                //            TimeOut_ = item.CheckingInterval,
                //        };
                //        lstAlert.Add(new AlertResonsePS
                //        {
                //            AlertResponse_ = AD
                //        });
                //    }

                //}

                //OrderManager.getOrderManager().SendData(lstAlert);
            }
            catch (Exception ex)
            {
                //Logger.LogEx(ex, "AlertManager", "SaveAlerts()");
            }
        }

        #endregion

    }
}