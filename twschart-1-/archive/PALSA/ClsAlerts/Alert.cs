using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using TradeScriptLib;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using PALSA.Cls;

//using ProtocolStructs;



namespace PALSA.ClsAlerts
{

   
    public delegate void Alert_Handler(Alert sender);    
    public  class Alert 
    {   

        public event Alert_Handler OnAlert;
        #region MEMBERS
        double jDate;  //joolian date               
        public TradeScriptLib.Alert  OAlert_=null;     //tradescript object
        string symbol_="AUDCAD";     //Symbol for Alert
        bool isEnable_ = true;       //enable/disable for alert
        string tradeScript_=null;    //tradescript for Alert
        public DateTime dateTime_;    //date time when alert create
        public bool imgEnable=true;     //use for enable/disable image
        ALERT_ACTION action_ = ALERT_ACTION.SOUND;    //Alert Action
        ALERT_TYPE alertType_ = ALERT_TYPE.BIDLESSTHAN;   //Alert Type
        public string timeout = "10 sec";   //timeout for alert
        public string Condition="Bid < ";
        string value_="0.0";
        int CheckingInterval_ = 10;     //timeout for alert in sec
        public int CheckingCounter = 0;     //checking counter
        int MaximumIterations_ = 1;     //Maximum times for fire alert
        public int Counter = 0;
        string AlertID_ = Guid.NewGuid().ToString();    //AlertId for uniqueness
       public  bool isFirstTime_ = true;    //check for first time fore alert
        string sourcepath_ = "";   
        string mailto_ = "";
        public AlertAction objAlertAction = null;        // Handling Alert Action
        #endregion

        #region PROPERTY        

        public string Value
        {
            get
            {
                return value_;
            }
            set
            {
                value_ = value;
            }
        }

        public string ALERTID
        {
            get
            {
                return AlertID_;
            }
            set
            {
                AlertID_ = value;
            }
        }

        public string SourcePath
        {
            get
            {
                return sourcepath_;
            }
            set
            {
                sourcepath_ = value;
            }        
        }

         public string MailTo
         {
            get
            {
                return mailto_;
            }
            set
            {
                mailto_ = value;
            }
        }

        public string Symbol
        {
            get
            {
                return symbol_;
            }
            set
            {
                symbol_ = value;
                this.OAlert_.AlertName = symbol_;
                this.OAlert_.Symbol = symbol_;   
            }
        }

        public bool Enable
        {
            get
            {
                return isEnable_;
            }
            set
            {
                isEnable_ = value;
            }
        }

        public string TradeScript
        {
            get
            {
                return tradeScript_;
            }
            set
            {
                tradeScript_ = value;
                this.OAlert_.AlertScript = tradeScript_;
            }
        }

        public DateTime TimeAlertValue
        {
            get
            {
                return dateTime_;
            }
            set
            {
                dateTime_ = value;
            }
        }

        public ALERT_ACTION Action
        {
            get
            {
                return action_;
            }
            set
            {
                action_ = value;
            }
        }

        public ALERT_TYPE Alert_Type
        {
            get
            {
                return alertType_;
            }
            set
            {
                alertType_ = value;
            }
        }

        public int CheckingInterval
        {
            get
            {
                return CheckingInterval_;
            }
            set
            {
                CheckingInterval_ = value;
            }
        }

        public int MaximumIterations
        {
            get
            {
                return MaximumIterations_;
            }
            set
            {
                MaximumIterations_ = value;
            }
        }
        
        #endregion

        #region METHODS

        public void setTypeConditionTradeScript(string str)
        {
            switch (str)
            {
                case "Bid < ":
                   
                    this.Alert_Type = ALERT_TYPE.BIDLESSTHAN;
                    this.Condition="Bid < ";
                    this.TradeScript = "OPEN < ".ToString() + this.Value;
                    break;

                case "Bid > ":
                    this.Alert_Type = ALERT_TYPE.BIDGREATERTHAN;
                    this.Condition="Bid > ";
                    this.TradeScript = "OPEN > ".ToString() + this.Value;                    
                    break;

                case "Ask < ":
                    this.Alert_Type = ALERT_TYPE.ASKLESSTHAN;
                    this.Condition="Ask < ";
                    this.TradeScript = "OPEN < ".ToString() + this.Value;      
                    break;

                case "Ask > ":
                    this.Alert_Type = ALERT_TYPE.ASKGREATERTHAN;
                    this.Condition="Ask > ";
                    this.TradeScript = "OPEN > ".ToString() + this.Value;      
                    break;

                case "Time = ":
                    this.Alert_Type = ALERT_TYPE.TIME;
                    this.Condition="Time = ";
                    this.dateTime_ = DateTime.Parse(this.Value);
                    this.TradeScript = "OPEN < ".ToString() + this.Value;      
                    break;
                 default:
                    this.Alert_Type = ALERT_TYPE.TIME;
                    this.Condition = "Time = ";
                    this.dateTime_ = DateTime.Parse(this.Value);
                   break;
            }
        }

        public Alert()
        {

            objAlertAction = new AlertAction();
            isFirstTime_ = true;
            OAlert_ = new TradeScriptLib.Alert();          
            OAlert_.Alert += new _IAlertEvents_AlertEventHandler(OAlert__Alert);
            OAlert_.ScriptError += new _IAlertEvents_ScriptErrorEventHandler(OAlert__ScriptError);
            OAlert_.License = "XRT93NQR79ABTW788XR48";  //licence for activate tradescript
        }
        
        void OAlert__ScriptError(string Symbol, string AlertName, string Description)
        {
            throw new NotImplementedException();
        }

        //
        //This function perform action when Alert script condition satisfy at current quote
        //
        void OAlert__Alert(string Symbol, string AlertName)
        {
            ++CheckingCounter;
            FireAlert();
            OAlert_.ClearRecords();  //By Kul    
        }


        void AddDataInTradeScript(DateTime dt, double Price, int Volume)
        {
            //double Price1 = Price+123.0;
            //int Volume1 = Volume + 1000;
            //Volume = 1;

            jDate = OAlert_.ToJulianDate(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
            OAlert_.AppendRecord(jDate, Price, Price, Price, Price, Volume);
            OAlert_.AppendRecord(jDate, Price, Price, Price, Price, Volume);
            OAlert_.AppendRecord(jDate, Price, Price, Price, Price, Volume);
            OAlert_.AppendRecord(jDate, Price, Price, Price, Price, Volume);
            OAlert_.AppendRecord(jDate, Price, Price, Price, Price, Volume);
            //OAlert_.ClearRecords();            
        }
        
        
        private void FireAlert()
        {
            OnAlert(this);
        }
        #endregion



        internal void UpdateAlert(QuoteItem quoteItem)
        {
            if (!this.Enable)
                return;
            if (Counter == 0 && isFirstTime_ == true)
            {
                Counter += 1;
                return;
            }
            Counter += 1;
            if (Counter == CheckingInterval_ || isFirstTime_)
            {


                switch (alertType_)
                {
                    case ALERT_TYPE.TIME:
                        if (dateTime_.Hour == DateTime.UtcNow.Hour && dateTime_.Minute == DateTime.UtcNow.Minute)
                        {
                            ++CheckingCounter;
                            FireAlert();
                        }
                        break;
                    case ALERT_TYPE.BIDLESSTHAN:
                    case ALERT_TYPE.BIDGREATERTHAN:
                        if (quoteItem._quoteType == QuoteStreamType.BID)
                        {
                            AppendData(quoteItem);
                        }
                        break;
                    case ALERT_TYPE.ASKLESSTHAN:
                    case ALERT_TYPE.ASKGREATERTHAN:
                        if (quoteItem._quoteType == QuoteStreamType.ASK)
                        {
                            AppendData(quoteItem);
                        }
                        //AppendData(quoteItem);
                        //++CheckingCounter;//Kul
                        //FireAlert();
                        break;
                    default:
                        break;

                }
                Counter = 0;
                if (CheckingCounter == MaximumIterations_)
                    this.Enable = false;

            }
            if (isFirstTime_)
                isFirstTime_ = false;
        }

        private void AppendData(QuoteItem quoteItem)
        {
            switch (alertType_)
            {
                case ALERT_TYPE.BIDLESSTHAN:
                case ALERT_TYPE.BIDGREATERTHAN:
                case ALERT_TYPE.ASKLESSTHAN:
                case ALERT_TYPE.ASKGREATERTHAN:
                    AddDataInTradeScript(DateTime.UtcNow, quoteItem._Price,
                                         Convert.ToInt32(quoteItem._Size));
                    break;
                default:
                    break;
            }
        }

        //
        //This function for update Alert if it enable
        //
        //public void UpdateAlert(QuoteResponse QD)
        //{
        //    if (!this.Enable)
        //        return;
        //    if (Counter == 0 && isFirstTime_ == true)
        //    {
        //        Counter += 1;
        //        return;
        //    }
        //    Counter += 1;
        //    if (Counter == CheckingInterval_ || isFirstTime_)
        //    {


        //        switch (alertType_)
        //        {
        //            case ALERT_TYPE.TIME:
        //                if (dateTime_.Hour == DateTime.UtcNow.Hour && dateTime_.Minute == DateTime.UtcNow.Minute)
        //                {
        //                    ++CheckingCounter;
        //                    FireAlert();
        //                }
        //                break;
        //            case ALERT_TYPE.BIDLESSTHAN:
        //                AppendData(QD);
        //                break;
        //            case ALERT_TYPE.BIDGREATERTHAN:
        //                AppendData(QD);
        //                break;
        //            case ALERT_TYPE.ASKLESSTHAN:
        //                AppendData(QD);
        //                break;
        //            case ALERT_TYPE.ASKGREATERTHAN:
        //                AppendData(QD);
        //                break;
        //            default:
        //                break;

        //        }
        //        Counter = 0;
        //        if (CheckingCounter == MaximumIterations_)
        //            this.Enable = false;

        //    }
        //    if (isFirstTime_)
        //        isFirstTime_ = false;
        //}



        //This function used for adding quotedata in tradescript object

        //void AppendData(QuoteResponse QD)
        //{
        //    switch (alertType_)
        //    {
        //        case ALERT_TYPE.BIDLESSTHAN:
        //            AddDataInTradeScript(DateTime.UtcNow, QD.BidPx_,
        //                                 Convert.ToInt32(QD.BidSize_));
        //            break;
        //        case ALERT_TYPE.BIDGREATERTHAN:
        //            AddDataInTradeScript(DateTime.UtcNow, QD.BidPx_,
        //                                 Convert.ToInt32(QD.BidSize_));

        //            break;

        //        case ALERT_TYPE.ASKLESSTHAN:
        //            AddDataInTradeScript(DateTime.UtcNow, Convert.ToDouble(QD.AskPx_),
        //                                 Convert.ToInt32(QD.AskSize_));

        //            break;
        //        case ALERT_TYPE.ASKGREATERTHAN:
        //            AddDataInTradeScript(DateTime.UtcNow, Convert.ToDouble(QD.AskPx_),
        //                                  Convert.ToInt32(QD.AskSize_));
        //            break;
        //        default:
        //            break;
        //    }


        //}

        //Load data at Tradescript object (it starts running from 5th record) 
        //

    }
}
  

