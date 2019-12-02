using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using clsInterface4OME;
using clsInterface4OME.DSBO;
using ProtocolStructs;
using ProtocolStructs.NewPS;
using System.Data;

using BOADMIN_NEW.BOEngineServiceTCP;

namespace BOADMIN_NEW.Cls
{
    public class clsTradeManager
    {
        #region MEMBERS

        static clsTradeManager _clsTradeManager = null;

        public DS4Trade _DS4Trade = new DS4Trade();

        List<string> _lstAccouontID = new List<string>();
        List<string> _lstOrderNo = new List<string>();
        List<string> _lstTradeNo = new List<string>();
        List<string> _lstBrokerName = new List<string>();
        Dictionary<string, List<string>> dicBrokerNameAccountId = new Dictionary<string, List<string>>();

        #endregion MEMBERS

        public static clsTradeManager INSTANCE
        {
            get
            {
                if (_clsTradeManager == null)
                {
                    _clsTradeManager = new clsTradeManager();
                }
                return _clsTradeManager;
            }
        }
        private clsTradeManager()
        {

        }
        public void FillTradeDataSet(DateTime startDate, DateTime endDate)
        {
            dicBrokerNameAccountId.Clear();
            _lstAccouontID.Clear();
            _lstOrderNo.Clear();
            _lstTradeNo.Clear();
            _lstBrokerName.Clear();

            foreach (clsTrades item in clsProxyClassManager.INSTANCE.GetTradeDetails(startDate, endDate))
            {
                FillValuesToTradeDataSet(item);
            }
        }
               
        public void FillValuesToTradeDataSet(clsTrades trade)
        {
            try
            {               

                DS4Trade.dtTradeRow tradeRow = _DS4Trade.dtTrade.FindByOrderID(trade.OrderID);

                if (tradeRow == null)
                {
                        tradeRow = _DS4Trade.dtTrade.NewRow() as DS4Trade.dtTradeRow;                         //
                      
                        tradeRow.AccountID = trade.AccountID;
                        tradeRow.OrderID = trade.OrderID;
                        tradeRow.TradeNo = trade.TradeNo;
                        decimal d = Convert.ToDecimal(trade.OrderPrice.Trim());
                        tradeRow.OrderPrice = d.ToString("0.00");
                        tradeRow.Quantity = trade.Quantity;
                        tradeRow.Time = Convert.ToDateTime(trade.Time);
                        tradeRow.Type = trade.Type;
                        tradeRow.Validity = Convert.ToDateTime(trade.Validity);
                        decimal t = Convert.ToDecimal(trade.TriggerPrice.Trim());
                        tradeRow.TriggerPrice = t.ToString("0.00");
                        tradeRow.Symbol = trade.SymbolID;
                        tradeRow.Status = trade.Status;
                        tradeRow.OrderType = trade.OrderType;
                        tradeRow.Comment = trade.Comment;
                        tradeRow.BrokerName = trade.BrokerName;
                        tradeRow.Volume = trade.Volume;
                        tradeRow.FilledQuantity = trade.FilledQuantity;
                        tradeRow.LeaveQuantity = trade.LeaveQuantity;
                        tradeRow.AvgFillPRice = Convert.ToDecimal(trade.AvgFillPrice.ToString("0.00"));
                        tradeRow.SettledQty = trade.SettledQty;
                   
                    if (!_lstOrderNo.Contains(trade.OrderID.ToString()))
                    {
                        _lstOrderNo.Add(trade.OrderID.ToString());
                    }
                    if (!_lstTradeNo.Contains(trade.TradeNo.ToString()))
                    {
                        _lstTradeNo.Add(trade.TradeNo.ToString());
                    }

                    if (!_lstAccouontID.Contains(trade.AccountID.ToString()))
                    {
                        _lstAccouontID.Add(trade.AccountID.ToString());
                    }

                    if (!string.IsNullOrEmpty(trade.BrokerName)  && !_lstBrokerName.Contains(trade.BrokerName))
                    {
                        _lstBrokerName.Add(trade.BrokerName);
                    }
                    _DS4Trade.dtTrade.AdddtTradeRow(tradeRow);

                }
                else
                {
                    tradeRow.AccountID = trade.AccountID;
                    tradeRow.OrderID = trade.OrderID;
                    tradeRow.TradeNo = trade.TradeNo;
                    decimal d = Convert.ToDecimal(trade.OrderPrice.Trim());
                    tradeRow.OrderPrice = d.ToString("0.00");
                    tradeRow.Quantity = trade.Quantity;
                    tradeRow.Time = Convert.ToDateTime(trade.Time);
                    tradeRow.Type = trade.Type;
                    tradeRow.Validity = Convert.ToDateTime(trade.Validity);
                    decimal t = Convert.ToDecimal(trade.TriggerPrice.Trim());
                    tradeRow.TriggerPrice = t.ToString("0.00");
                    tradeRow.Symbol = trade.SymbolID;
                    tradeRow.Status = trade.Status;
                    tradeRow.OrderType = trade.OrderType;
                    tradeRow.Comment = trade.Comment;
                    tradeRow.BrokerName = trade.BrokerName;
                    tradeRow.Volume = trade.Volume;
                    tradeRow.FilledQuantity = trade.FilledQuantity;
                    tradeRow.LeaveQuantity = trade.LeaveQuantity;
                    tradeRow.AvgFillPRice = Convert.ToDecimal(trade.AvgFillPrice.ToString("0.00"));
                    tradeRow.SettledQty = trade.SettledQty;


                    if (!_lstOrderNo.Contains(trade.OrderID.ToString()))
                    {
                        _lstOrderNo.Add(trade.OrderID.ToString());
                    }
                    if (!_lstTradeNo.Contains(trade.TradeNo.ToString()))
                    {
                        _lstTradeNo.Add(trade.TradeNo.ToString());
                    }

                    if (!_lstAccouontID.Contains(trade.AccountID.ToString()))
                    {
                        _lstAccouontID.Add(trade.AccountID.ToString());
                    }

                    if (!string.IsNullOrEmpty(trade.BrokerName) && !_lstBrokerName.Contains(trade.BrokerName))
                    {
                        _lstBrokerName.Add(trade.BrokerName);
                    }
                }
            }

            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsTradeManager => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                   // "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in FillValuesToTradeDataSet()");
            }

            _DS4Trade.dtTrade.AcceptChanges();
        }

        public string[] GetAccountIDArray()
        {
            return _lstAccouontID.ToArray();
        }

        public string[] GetBrokerNameArray()
        {
            return _lstBrokerName.ToArray();
        }

        public string[] GetOrderNoArray()
        {
            return _lstOrderNo.ToArray();
        }
        public string[] GetTradeNoArray()
        {
            return _lstTradeNo.ToArray();
        }
    }
}
