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
    public class clsOrdersManager
    {
        #region MEMBERS

        static clsOrdersManager _clsOrdersManager = null;
        public DS4OrderNew _DS4Orders = new DS4OrderNew();
      
        List<string> _lstAccouontID = new List<string>();     
        List<string> _lstBrokerName = new List<string>();
        List<string> _lstOrderType = new List<string>();
        List<string> _lstType = new List<string>();

        #endregion MEMBERS

        //#region METHODS

        public static clsOrdersManager INSTANCE
        {
            get
            {
                if (_clsOrdersManager == null)
                {
                    _clsOrdersManager = new clsOrdersManager();
                }
                return _clsOrdersManager;
            }
        }
        private clsOrdersManager()
        {

        }
        public void FillOrderDataSet(DateTime startDate, DateTime endDate)
        {
           _lstAccouontID.Clear();
           _lstBrokerName.Clear();
           _lstOrderType.Clear();
           _lstType.Clear();

           foreach (clsTrades item in clsProxyClassManager.INSTANCE.GetTradesRecords(startDate, endDate))
            {
                FillValuesToOrderDataSet(item);
            }
        }
        public void FillValuesToOrderDataSet(clsTrades order)
        {
            try
            {

                DS4OrderNew.dtOrdersRow orderRow = _DS4Orders.dtOrders.FindByOrderID(order.OrderID);

                if (orderRow == null)
                {
                    orderRow = _DS4Orders.dtOrders.NewRow() as DS4OrderNew.dtOrdersRow;                         //

                    orderRow.AccountID = order.AccountID;
                    orderRow.OrderID = order.OrderID;
                    orderRow.TradeNo = order.TradeNo;
                    decimal d = Convert.ToDecimal(order.OrderPrice.Trim());
                    orderRow.OrderPrice = d.ToString("0.00");
                    orderRow.Quantity = order.Quantity;
                    orderRow.Time = Convert.ToDateTime(order.Time);
                    orderRow.Type = order.Type;
                    orderRow.Validity = Convert.ToDateTime(order.Validity);
                    decimal t = Convert.ToDecimal(order.TriggerPrice.Trim());
                    orderRow.TriggerPrice = t.ToString("0.00"); 
                    orderRow.Symbol = order.SymbolID;
                    orderRow.Status = order.Status;
                    orderRow.OrderType = order.OrderType;
                    orderRow.Comment = order.Comment;
                    orderRow.BrokerName = order.BrokerName;
                    orderRow.Volume = order.Volume;
                    orderRow.FilledQuantity = order.FilledQuantity;
                    orderRow.LeaveQuantity = order.LeaveQuantity;
                    orderRow.AvgFillPRice = Convert.ToDecimal(order.AvgFillPrice.ToString("0.00"));                   

                    if (!_lstAccouontID.Contains(order.AccountID.ToString()))
                    {
                        _lstAccouontID.Add(order.AccountID.ToString());
                    }

                    if (order.BrokerName != string.Empty && !_lstBrokerName.Contains(order.BrokerName))
                    {
                        _lstBrokerName.Add(order.BrokerName);
                    }
                    if (!_lstOrderType.Contains(order.OrderType))
                    {
                        _lstOrderType.Add(order.OrderType);
                    }
                    if (!_lstType.Contains(order.Type))
                    {
                        _lstType.Add(order.Type);
                    }      

                    _DS4Orders.dtOrders.AdddtOrdersRow(orderRow);

                }
                else
                {
                    orderRow.AccountID = order.AccountID;
                    orderRow.OrderID = order.OrderID;
                    orderRow.TradeNo = order.TradeNo;
                    decimal d = Convert.ToDecimal(order.OrderPrice.Trim());
                    orderRow.OrderPrice = d.ToString("0.00");
                    orderRow.Quantity = order.Quantity;
                    orderRow.Time = Convert.ToDateTime(order.Time);
                    orderRow.Type = order.Type;
                    orderRow.Validity = Convert.ToDateTime(order.Validity);
                    decimal t = Convert.ToDecimal(order.TriggerPrice.Trim());
                    orderRow.TriggerPrice = t.ToString("0.00");                 
                    orderRow.Symbol = order.SymbolID;
                    orderRow.Status = order.Status;
                    orderRow.OrderType = order.OrderType;
                    orderRow.Comment = order.Comment;
                    orderRow.BrokerName = order.BrokerName;
                    orderRow.Volume = order.Volume;
                    orderRow.FilledQuantity = order.FilledQuantity;
                    orderRow.LeaveQuantity = order.LeaveQuantity;
                    orderRow.AvgFillPRice = Convert.ToDecimal(order.AvgFillPrice.ToString("0.00"));               


                    if (!_lstAccouontID.Contains(order.AccountID.ToString()))
                    {
                        _lstAccouontID.Add(order.AccountID.ToString());
                    }

                    if (order.BrokerName != string.Empty && !_lstBrokerName.Contains(order.BrokerName))
                    {
                        _lstBrokerName.Add(order.BrokerName);
                    }
                    if (!_lstOrderType.Contains(order.OrderType))
                    {
                        _lstOrderType.Add(order.OrderType);
                    }
                    if (!_lstType.Contains(order.Type))
                    {
                        _lstType.Add(order.Type);
                    }      
                }
            }

            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsOrdersManager => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                   // "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in FillValuesToOrderDataSet()");
            }

            _DS4Orders.dtOrders.AcceptChanges();
        }
               
      
        public string[] GetAccountIDArray()
        {
            return _lstAccouontID.ToArray();
        }

        public string[] GetBrokerNameArray()
        {
            return _lstBrokerName.ToArray();
        }

        public string[] GetOrderTypeArray()
        {
            return _lstOrderType.ToArray();
        }

        public string[] GetTypeArray()
        {
            return _lstType.ToArray();
        }       
               
    }
}
