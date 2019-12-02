using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace clsInterface4OME
{
    public class clsExecDetail
    {
        public static string strServerOrderID = "ServerOrderID";
        public static string strClientOrderID = "ClientOrderID";
        public static string strDateBooked = "DateBooked";
        public static string strAction = "Action";
        public static string strSide = "Side";
        public static string strDuration = "Duration";
        public static string strQuantity = "Quantity";
        public static string strLimitPrice = "LimitPrice";
        public static string strOrderType = "OrderType";
        public static string strOrderStatus = "OrderStatus";
        public static string strOrderStatus4Debug = "OrderStatus4Debug";
        public static string strDateFilled = "DateFilled";
        public static string strPriceFilled = "PriceFilled";
        public static string strQuantityFilled = "QuantityFilled";
        public static string strPending = "Pending";
        public static string strTakeProfit = "TakeProfit";
        public static string strStopLoss = "StopLoss";
        public static string strClosedPrice = "ClosedPrice";
        public static string strClosedDate = "ClosedDate";
        public static string strClosedQty = "ClosedQty";
        public static string strCancelQty = "CancelQty";
        public static string strAccID_ClientID = "AccID_ClientID";

        public static string strAvgFilledPrice = "AvgFilledPrice";
        public static string strAvgClose = "AvgClose";
        public static string strRPNL = "RPNL";

        //public static string strNAcntOpening_Balance = "Opening Balance";
        //public static string strNAcntAvail_Balance = "Avail Balance";
        //public static string strNAcntBuy_Filled = "Buy Filled";
        //public static string strNAcntBuy_P_L = "Buy P/L";
        //public static string strNAcntSell_Filled = "Sell Filled";
        //public static string strNAcntSell_P_L = "Sell P/L";
        //public static string strNAcntTotal_Value = "Total Value";
        //public static string strNAcntFilled_P_L = "Filled P/L";
        //public static string strNAcntSell_Pend = "Sell Pend";
        //public static string strNAcntBuy_Pend = "Buy Pend";
        //public static string strNAcntLot_Delivered = "Lot Delivered";
        //public static string strNAcntStorage = "Storage";
        //public static string strNAcntWithDrawals = "WithDrawals";
        //public static string strNAcntService_Fee = "Service Fee";
        //public static string strNAcntToday_P_L = "Today P/L";
        //public static string strNAcntTotal_P_L = "Total P/L";

        public static string strNAcntAccount = "Account";
        public static string strNAcntOpening_Balance = "Opening_Balance";
        public static string strNAcntAvail_Balance = "Avail_Balance";
        public static string strNAcntBuy_Filled = "Buy_Filled";
        public static string strNAcntBuy_P_L = "Buy_P_L";
        public static string strNAcntSell_Filled = "Sell_Filled";
        public static string strNAcntSell_P_L = "Sell_P_L";
        public static string strNAcntTotal_Value = "Total_Value";
        public static string strNAcntFilled_P_L = "Filled_P_L";
        public static string strNAcntSell_Pend = "Sell_Pend";
        public static string strNAcntBuy_Pend = "Buy_Pend";
        public static string strNAcntTot_Pend = "Total_Pending";
        public static string strNAcntClosed_P_L = "Closed_P_L";
        public static string strNAcntLot_Delivered = "Lot_Delivered";
        public static string strNAcntStorage = "Storage";
        public static string strNAcntWithDrawals = "WithDrawals";
        public static string strNAcntService_Fee = "Service_Fee";
        public static string strNAcntTotal_Fee = "Total_Fee";
        public static string strNAcntToday_P_L = "Today_P_L";
        public static string strNAcntTotal_P_L = "Total_P_L";
        public static string strNAcntFundIn = "Fund_In";
        public static string strNAcntFundOut = "Fund_Out";
        public static string strNAcntECardBuy = "E_CardBuy";
        public static string strNAcntClosedQty = "Closed_Qty";

        //public static string strAcntCoTotal_Stock = "TotalStock";
        //public static string strAcntCoToday_Stock = "TodayStock";
        //public static string strAcntCoStock_Price = "StockPrice";
        //public static string strAcntCoAvg_Price = "AvgPrice";
        //public static string strAcntCoTotal_Lots = "TotalLots";
        //public static string strAcntCoDiff_Lots = "DiffLots";
        //public static string strAcntCoAverage_Diff = "AverageDiff";
        //public static string strAcntCoTotal_Average = "TotalAverage";
        //public static string strAcntCoTotal_Price = "TotalPrice";

        //public static string strAcntCoTotal_Buy = "TotalBuy";
        //public static string strAcntCoTotal_Sell = "TotalSell";
        //public static string strAcntCoTotal_Open = "TotalOpen";
        //public static string strAcntCoToday_Buy = "TodayBuy";
        //public static string strAcntCoToday_Sell = "TodaySell";
        //public static string strAcntCoToday_Open = "TodayOpen";
        //public static string strAcntCoToday_PL = "TodayPL";
        //public static string strAcntCoTotal_PL = "TotalPL";



        public static string strAccount = "Account";
        public static string strOpeningBalance = "OpeningBalance";
        public static string strAvailBalance = "AvailBalance";
        public static string strRealizedPL = "RealizedPL";
        public static string strBuyOpen = "BuyOpen";
        public static string strSellOpen = "SellOpen";
        public static string strTotalValue = "TotalValue";
        public static string strStorage = "Storage";
        public static string strSellPend = "SellPend";
        public static string strBuyPend = "BuyPend";
        public static string strPendPL = "PendPL";
        public static string strLotDelivered = "LotDelivered";
        public static string strTotalBuyOpenPrice = "TotalBuyOpenPrice";
        public static string strTotalSellOpenPrice = "TotalSellOpenPrice";
        public static string strBalance = "Balance";
        public static string strLeverage = "Leverage";
        public static string strPNL = "PNL";
        public static string strServiceFee = "ServiceFee";
        public static string strTotalFee = "TotalFee";

        public static string strPrice = "Price";
        public static string strBidders = "NoOfBidders";

        //public static string strQuantity = "Quantity";

        public static string _strTotalrisk = "TotalRisk";
        public static string _strBuyPNL = "BUYPNL";
        public static string _strSellPNL = "SELLPNL";
        public static string _strTStorage = "TStorage";
        public static string _strTotalStorage = "TotalStorage";
        public static string _strTodayTC = "TodayTC";
        public static string _strTotalTC = "TotalTC";
        public static string _strMLMToday = "MLMToday";
        public static string _strMLMTotal = "MLMTotal";
        public static string _strMLMTPaid = "MLMTPaid";
        public static string _strMLMTPC = "MLMTPC";
        public static string _strTCCTODAY = "TCCTODAY";
        public static string _strTCCTotal = "TCCTotal";
        public static string _strAccountID = "AccountID";
        public static string _strBuyOpen = "BuyOpen";
        public static string _strSellOpen = "SellOpen";
        public static string strInstrument = "Instrument";
        public static string strMargin = "Margin";

        public static string RMSTotBuyOpenPrice = "TotBuyPrice";
        public static string RMSTotBuyOpenQty = "TotBuyQty";
        public static string RMSTotSellOpenQty = "TotSellQty";
        public static string RMSTotSellOpenPrice = "TotSellPrice";
        public static string RMSSymbolName = "Symbol";

        public static string strTGTodays_Profit = "Todays Profit";
        public static string strTGTotal_Profit = "Total Profit";
        public static string strTGToday_Loss = "Today Loss";
        public static string strTGToday_Close = "Total Loss";
        public static string strTGNet_P_L = "Net P/L";
        public static string strTGToday_Buy = "Today Buy";
        public static string strTGToday_Sell = "Today Sell";
        public static string strTGTotal_Buy = "Total Buy";
        //public static string strTGTotal_Close = "Total Close";
        public static string strTGTotal_Sell = "Total Sell";

        public static string strTGNet_Open = "Net Open";
        public static string strTGToday_Comm = "Today Comm";
        public static string strTGToday_Reg = "Today Reg";
        public static string strTGToday_Storage = "Today Storage";
        //public static string strTGToday_P_L = "Today P/L";
        //public static string strTGTotal_P_L = "Total P/L";

        public static string strTGToday_Fee = "Today Fee";
        public static string strTGTotal_Fee = "Total Fee";

        public static string strTGTTC_Paid = "TTC Paid";
        public static string strTGTMLM_Paid = "TMLM Paid";
        public static string strTGTR_Paid = "TR Paid";
        public static string strTGToday_Paid = "Today Paid";
        public static string strTGTotal_Paid = "Total Paid";
        public static string strTGToday_Volume = "Today Volume";
        public static string strTGTotal_Volume = "Total Volume";
        public static string strTGToday_Buy_Closed = "Today Buy Closed";
        public static string strTGToday_Sell_Closed = "Today Sell Closed";
        public static string strTGTotal_Closed = "Total Closed";
        public static string strChange = "Change";

        //public static string strPart1LP_Balance_Lots = "Balance Lots";
        //public static string strPart1LP_Balance_Price = "Balance Price";
        //public static string strPart1LP_Balance_Average = "Balance Average";
        //public static string strPart1LP_Pending_Buy = "Pending Buy";
        //public static string strPart1LP_Pending_Sell = "Pending Sell";
        //public static string strPart1LP_Today_Buy = "Today Buy";
        //public static string strPart1LP_Today_Sell = "Today Sell";
        //public static string strPart1LP_Today_Lots = "Today Lots";
        //public static string strPart1LP_Today_Price = "Today Price";
        //public static string strPart1LP_Today_Average = "Today Average";
        //public static string strPart1LP_Total_Buy = "Total Buy";
        //public static string strPart1LP_Total_Sell = "Total Sell";
        //public static string strPart1LP_Total_Lots = "Total Lots";
        //public static string strPart1LP_Total_Price = "Total Price";
        //public static string strPart1LP_Total_Average = "Total Average";
        //public static string strPart1LP_Open_P_L = "Open P/L";
        //public static string strPart1LP_Today_P_L = "Today P/L";
        //public static string strPart1LP_Total_P_L = "Total P/L";

        public static string strPart1LP_Balance_Lots = "Balance Lots";
        public static string strPart1LP_Balance_Price = "Balance Price";
        public static string strPart1LP_Balance_Average = "Balance Average";
        public static string strPart1LP_Pending_Buy = "Pending Buy";
        public static string strPart1LP_Pending_Sell = "Pending Sell";
        public static string strPart1LP_Today_Buy = "Today Buy";
        public static string strPart1LP_Today_Sell = "Today Sell";
        public static string strPart1LP_Today_Open = "Today Open";
        public static string strPart1LP_Today_Price = "Today Price";
        public static string strPart1LP_Today_Average = "Today Average";
        public static string strPart1LP_Today_OPL = "Today OPL";
        public static string strPart1LP_Today_CPL = "Today CPL";
        public static string strPart1LP_Total_Buy = "Total Buy";
        public static string strPart1LP_Total_Sell = "Total Sell";
        public static string strPart1LP_Total_Open = "Total Open";
        public static string strPart1LP_Total_Price = "Total Price";
        public static string strPart1LP_Total_Average = "Total Average";
        public static string strPart1LP_Open_P_L = "Open P L";
        public static string strPart1LP_Closed_P_L = "Closed P L";

        public static string strPartHDNBuyOpenQty = "BuyOpenQty";
        public static string strPartHDNBuyOpenPrice = "BuyOpenPrice";
        public static string strPartHDNBuyOpenAvgPrice = "BuyOpenAvgPrice";
        public static string strPartHDNSellOpenQty = "SellOpenQty";
        public static string strPartHDNSellOpenPrice = "SellOpenPrice";
        public static string strPartHDNSellOpenAvgPrice = "SellOpenAvgPrice";

        public static string strPartHDNBuyOpenQtyTotal = "BuyOpenQtyTotal";
        public static string strPartHDNBuyOpenPriceTotal = "BuyOpenPriceTotal";
        public static string strPartHDNBuyOpenAvgPriceTotal = "BuyOpenAvgPriceTotal";
        public static string strPartHDNSellOpenQtyTotal = "SellOpenQtyTotal";
        public static string strPartHDNSellOpenPriceTotal = "SellOpenPriceTotal";
        public static string strPartHDNSellOpenAvgPriceTotal = "SellOpenAvgPriceTotal";






        public static string strPart2LP_Today_Sell = " Today Sell";
        public static string strPart2LP_Today_Buy = " Today Buy";
        public static string strPart2LP_Total_Sell = " Total Sell";
        public static string strPart2LP_Total_Buy = " Total Buy";
        public static string strPart2LP_P_L_Today = " P/L Today";
        public static string strPart2LP_P_L_Total = " P/L Total";
        public static string strPart2LP_Open_Lots_Sell = " Open Lots Sell";
        public static string strPart2LP_Open_Lots_Buy = " Open Lots Buy";

        public static string strPart3LAS_Balance_Lots = "Balance Lots";
        public static string strPart3LAS_Balance_Price = "Balance Price";
        public static string strPart3LAS_Balance_Average = "Balance Average";
        public static string strPart3LAS_Pending_Buy = "Pending Buy";
        public static string strPart3LAS_Pending_Sell = "Pending Sell";
        public static string strPart3LAS_Today_Buy = "Today Buy";
        public static string strPart3LAS_Today_Sell = "Today Sell";
        public static string strPart3LAS_Today_Lots = "Today Lots";
        public static string strPart3LAS_Today_Price = "Today Price";
        public static string strPart3LAS_Today_Average = "Today Average";
        public static string strPart3LAS_Total_Buy = "Total Buy";
        public static string strPart3LAS_Total_Sell = "Total Sell";
        public static string strPart3LAS_Total_Lots = "Total Lots";
        public static string strPart3LAS_Total_Price = "Total Price";
        public static string strPart3LAS_Total_Average = "Total Average";
        public static string strPart3LAS_Open_P_L = "Open P/L";
        public static string strPart3LAS_Today_P_L = "Today P/L";
        public static string strPart3LAS_Total_P_L = "Total P/L";
        //.Today_Buy_CloseQty
        //.Today_Sell_CloseQty
        //.Total_Buy_CloseQty
        //.Total_Sell_CloseQty

        public static string strPart4LAS_Today_Buy_CloseQty = "Today Buy CloseQty";
        public static string strPart4LAS_Today_Sell_CloseQty = "Today Sell CloseQty";
        public static string strPart4LAS_Total_Buy_CloseQty = "Total Buy CloseQty";
        public static string strPart4LAS_Total_Sell_CloseQty = "Total Sell CloseQty";

        public static string strPart4LAS_Today_Sell = " Today Sell";
        public static string strPart4LAS_Today_Buy = " Today Buy";
        public static string strPart4LAS_Total_Sell = " Total Sell";
        public static string strPart4LAS_Total_Buy = " Total Buy";
        public static string strPart4LAS_P_L_Today = " P/L Today";
        public static string strPart4LAS_P_L_Total = " P/L Total";
        public static string strPart4LAS_Open_Lots_Sell = " Demand Sell";
        public static string strPart4LAS_Open_Lots_Buy = " Demand Buy";





        public static DataTable GetExecutionDetailStruct()
        {
            DataTable dtOrders = new DataTable();
            dtOrders.Columns.Add(new DataColumn(strServerOrderID, typeof(string)));// For OMS
            dtOrders.Columns.Add(new DataColumn(strClientOrderID, typeof(string)));// For Client UI 
            dtOrders.Columns.Add(new DataColumn(strDateBooked, typeof(DateTime)));
            dtOrders.Columns.Add(new DataColumn(strAction, typeof(string)));
            dtOrders.Columns.Add(new DataColumn(strSide, typeof(string)));
            dtOrders.Columns.Add(new DataColumn(strDuration, typeof(string)));
            dtOrders.Columns.Add(new DataColumn(strQuantity, typeof(int)));
            dtOrders.Columns.Add(new DataColumn(strLimitPrice, typeof(double)));
            dtOrders.Columns.Add(new DataColumn(strOrderType, typeof(string)));
            dtOrders.Columns.Add(new DataColumn(strOrderStatus, typeof(string)));
            dtOrders.Columns.Add(new DataColumn(strOrderStatus4Debug, typeof(string)));
            dtOrders.Columns.Add(new DataColumn(strDateFilled, typeof(DateTime)));
            dtOrders.Columns.Add(new DataColumn(strPriceFilled, typeof(string)));
            dtOrders.Columns.Add(new DataColumn(strQuantityFilled, typeof(int)));
            dtOrders.Columns.Add(new DataColumn(strPending, typeof(int)));
            dtOrders.Columns.Add(new DataColumn(strTakeProfit, typeof(string)));
            dtOrders.Columns.Add(new DataColumn(strStopLoss, typeof(double)));
            dtOrders.Columns.Add(new DataColumn(strClosedPrice, typeof(double)));
            dtOrders.Columns.Add(new DataColumn(strClosedDate, typeof(DateTime)));
            dtOrders.Columns.Add(new DataColumn(strClosedQty, typeof(int)));
            dtOrders.Columns.Add(new DataColumn(strAvgFilledPrice, typeof(double)));
            dtOrders.Columns.Add(new DataColumn(strAvgClose, typeof(double)));
            dtOrders.Columns.Add(new DataColumn(strRPNL, typeof(double)));
            return dtOrders;
        }
        public static string[] GetTradingColumnNames()
        {
            string[] lst = { 
        strTGTodays_Profit ,
        strTGTotal_Profit ,
        strTGToday_Loss ,
        strTGToday_Close ,
        strTGNet_P_L ,
        strTGToday_Buy ,
        strTGToday_Sell ,
        strTGTotal_Buy ,
        //strTGTotal_Close ,
        strTGTotal_Sell ,
        strTGNet_Open ,
        strTGToday_Comm ,
        strTGToday_Reg,
        strTGToday_Storage ,
        //strTGToday_P_L ,
        //strTGTotal_P_L ,
         strTGToday_Fee ,
        strTGTotal_Fee ,

        strTGTTC_Paid ,
        strTGTMLM_Paid ,
        strTGTR_Paid ,
        strTGToday_Paid ,
        strTGTotal_Paid ,
        strTGToday_Volume ,
        strTGTotal_Volume ,
        strTGToday_Buy_Closed ,
        strTGToday_Sell_Closed ,
        strTGTotal_Closed 
        };

            return lst;
        }
        //public static string[] GetAccountCompanyColumnNames()
        //{
        //    string[] lst = {
        //    strAcntCoTotal_Stock,
        //    strAcntCoToday_Stock,
        //    strAcntCoStock_Price,
        //    strAcntCoAvg_Price,
        //    strAcntCoTotal_Lots,
        //    strAcntCoDiff_Lots,
        //    strAcntCoAverage_Diff,
        //    strAcntCoTotal_Average,
        //    strAcntCoTotal_Price,
        //    strAcntCoTotal_Buy ,
        //    strAcntCoTotal_Sell,
        //    strAcntCoTotal_Open,
        //    strAcntCoToday_Buy ,
        //    strAcntCoToday_Sell,
        //    strAcntCoToday_Open,
        //    strAcntCoToday_PL ,
        //    strAcntCoTotal_PL 
        //    };
        //    return lst;
        //}
        public static string[] GetPart1Hidden()
        {
            string[] lst = {
                                strPartHDNBuyOpenQty 
                                ,strPartHDNBuyOpenPrice
                                ,strPartHDNBuyOpenAvgPrice 
                                ,strPartHDNSellOpenQty 
                                ,strPartHDNSellOpenPrice
                                ,strPartHDNSellOpenAvgPrice 

                                ,strPartHDNBuyOpenQtyTotal 
                                ,strPartHDNBuyOpenPriceTotal
                                ,strPartHDNBuyOpenAvgPriceTotal 
                                ,strPartHDNSellOpenQtyTotal 
                                ,strPartHDNSellOpenPriceTotal
                                ,strPartHDNSellOpenAvgPriceTotal

                            };
            return lst;
        }
        public static string[] GetPart1Part2()
        {
            string[] lst = {
                            // strPart1LP_Balance_Lots
                            //,strPart1LP_Balance_Price
                            //,strPart1LP_Balance_Average
                            //,strPart1LP_Pending_Buy
                            //,strPart1LP_Pending_Sell
                            //,strPart1LP_Today_Buy 
                            //,strPart1LP_Today_Sell
                            //,strPart1LP_Today_Lots
                            //,strPart1LP_Today_Price
                            //,strPart1LP_Today_Average
                            //,strPart1LP_Total_Buy 
                            //,strPart1LP_Total_Sell
                            //,strPart1LP_Total_Lots
                            //,strPart1LP_Total_Price
                            //,strPart1LP_Total_Average
                            //,strPart1LP_Open_P_L
                            //,strPart1LP_Today_P_L 
                            //,strPart1LP_Total_P_L
                            strPart1LP_Balance_Lots    
                            ,strPart1LP_Balance_Price	
                            ,strPart1LP_Balance_Average 
                            ,strPart1LP_Pending_Buy	
                            ,strPart1LP_Pending_Sell 
                            ,strPart1LP_Today_Buy   
                            ,strPart1LP_Today_Sell 
                            ,strPart1LP_Today_Open
                            ,strPart1LP_Today_Price	
                            ,strPart1LP_Today_Average	
                            ,strPart1LP_Today_OPL 
                            ,strPart1LP_Today_CPL
                            ,strPart1LP_Total_Buy	
                            ,strPart1LP_Total_Sell	
                            ,strPart1LP_Total_Open	
                            ,strPart1LP_Total_Price	
                            ,strPart1LP_Total_Average 
                            ,strPart1LP_Open_P_L   
                            ,strPart1LP_Closed_P_L


                            ,strPart2LP_Today_Sell
                            ,strPart2LP_Today_Buy
                            ,strPart2LP_Total_Sell
                            ,strPart2LP_Total_Buy
                            ,strPart2LP_P_L_Today
                            ,strPart2LP_P_L_Total
                            ,strPart2LP_Open_Lots_Sell
                            ,strPart2LP_Open_Lots_Buy
                           };
            return lst;
        }

        public static string[] GetPart3Part4()
        {
            string[] lst = {
                            strPart3LAS_Balance_Lots
                            ,strPart3LAS_Balance_Price
                            ,strPart3LAS_Balance_Average
                            ,strPart3LAS_Pending_Buy
                            ,strPart3LAS_Pending_Sell
                            ,strPart3LAS_Today_Buy 
                            ,strPart3LAS_Today_Sell
                            ,strPart3LAS_Today_Lots
                            ,strPart3LAS_Today_Price
                            ,strPart3LAS_Today_Average
                            ,strPart3LAS_Total_Buy 
                            ,strPart3LAS_Total_Sell
                            ,strPart3LAS_Total_Lots
                            ,strPart3LAS_Total_Price
                            ,strPart3LAS_Total_Average
                            ,strPart3LAS_Open_P_L
                            ,strPart3LAS_Today_P_L 
                            ,strPart3LAS_Total_P_L

                            ,strPart4LAS_Today_Buy_CloseQty 
                            ,strPart4LAS_Today_Sell_CloseQty
                            ,strPart4LAS_Total_Buy_CloseQty 
                            ,strPart4LAS_Total_Sell_CloseQty

                            ,strPart4LAS_Today_Sell
                            ,strPart4LAS_Today_Buy
                            ,strPart4LAS_Total_Sell
                            ,strPart4LAS_Total_Buy
                            ,strPart4LAS_P_L_Today
                            ,strPart4LAS_P_L_Total
                            ,strPart4LAS_Open_Lots_Sell
                            ,strPart4LAS_Open_Lots_Buy
                           };
            return lst;
        }
        public static string[] GetAccountColumnNames()
        {
            string[] lst = {strAccount,
            strOpeningBalance,
            strAvailBalance,
            strRealizedPL,
            strBuyOpen,
            strSellOpen,
            strTotalValue,
            strStorage,
            strSellPend,
            strBuyPend,
            strPendPL,
            strLotDelivered,
            strTotalBuyOpenPrice,
            strTotalSellOpenPrice,
            strBalance,
            strLeverage,
            strPNL,
            strServiceFee,
            strTotalFee};
            return lst;
        }

        public static DataTable GetNewAccountSummaryTable()
        {
            DataTable dtNewAccountSummary = new DataTable();
            dtNewAccountSummary.Columns.Add(new DataColumn(strNAcntAccount, typeof(string)));
            dtNewAccountSummary.Columns.Add(new DataColumn(strNAcntOpening_Balance, typeof(decimal)));
            dtNewAccountSummary.Columns.Add(new DataColumn(strNAcntAvail_Balance, typeof(decimal)));
            dtNewAccountSummary.Columns.Add(new DataColumn(strNAcntBuy_Filled, typeof(int)));
            dtNewAccountSummary.Columns.Add(new DataColumn(strNAcntBuy_P_L, typeof(decimal)));
            dtNewAccountSummary.Columns.Add(new DataColumn(strNAcntSell_Filled, typeof(int)));
            dtNewAccountSummary.Columns.Add(new DataColumn(strNAcntSell_P_L, typeof(decimal)));
            dtNewAccountSummary.Columns.Add(new DataColumn(strNAcntTotal_Value, typeof(decimal)));
            dtNewAccountSummary.Columns.Add(new DataColumn(strNAcntFundIn, typeof(decimal)));
            dtNewAccountSummary.Columns.Add(new DataColumn(strNAcntFundOut, typeof(decimal)));
            dtNewAccountSummary.Columns.Add(new DataColumn(strNAcntECardBuy, typeof(decimal)));
            dtNewAccountSummary.Columns.Add(new DataColumn(strNAcntFilled_P_L, typeof(decimal)));
            dtNewAccountSummary.Columns.Add(new DataColumn(strNAcntSell_Pend, typeof(int)));
            dtNewAccountSummary.Columns.Add(new DataColumn(strNAcntBuy_Pend, typeof(int)));
            dtNewAccountSummary.Columns.Add(new DataColumn(strNAcntTot_Pend, typeof(int)));
            dtNewAccountSummary.Columns.Add(new DataColumn(strNAcntClosedQty, typeof(decimal)));
            dtNewAccountSummary.Columns.Add(new DataColumn(strNAcntClosed_P_L, typeof(decimal)));
            dtNewAccountSummary.Columns.Add(new DataColumn(strNAcntLot_Delivered, typeof(int)));
            dtNewAccountSummary.Columns.Add(new DataColumn(strNAcntStorage, typeof(decimal)));
            dtNewAccountSummary.Columns.Add(new DataColumn(strNAcntWithDrawals, typeof(decimal)));
            dtNewAccountSummary.Columns.Add(new DataColumn(strNAcntService_Fee, typeof(decimal)));
            dtNewAccountSummary.Columns.Add(new DataColumn(strNAcntTotal_Fee, typeof(decimal)));
            dtNewAccountSummary.Columns.Add(new DataColumn(strNAcntToday_P_L, typeof(decimal)));
            dtNewAccountSummary.Columns.Add(new DataColumn(strNAcntTotal_P_L, typeof(decimal)));

            return dtNewAccountSummary;
        }
        public static DataTable GetAccountSummaryTable()
        {
            DataTable dtAccountSummary = new DataTable();
            dtAccountSummary.Columns.Add(new DataColumn(strAccount, typeof(string)));
            dtAccountSummary.Columns.Add(new DataColumn(strOpeningBalance, typeof(double)));
            dtAccountSummary.Columns.Add(new DataColumn(strAvailBalance, typeof(double)));
            dtAccountSummary.Columns.Add(new DataColumn(strRealizedPL, typeof(string)));
            dtAccountSummary.Columns.Add(new DataColumn(strBuyOpen, typeof(string)));
            dtAccountSummary.Columns.Add(new DataColumn(strSellOpen, typeof(string)));
            dtAccountSummary.Columns.Add(new DataColumn(strTotalValue, typeof(string)));
            dtAccountSummary.Columns.Add(new DataColumn(strStorage, typeof(string)));
            dtAccountSummary.Columns.Add(new DataColumn(strSellPend, typeof(string)));
            dtAccountSummary.Columns.Add(new DataColumn(strBuyPend, typeof(string)));
            dtAccountSummary.Columns.Add(new DataColumn(strPendPL, typeof(string)));
            dtAccountSummary.Columns.Add(new DataColumn(strLotDelivered, typeof(string)));
            dtAccountSummary.Columns.Add(new DataColumn(strTotalBuyOpenPrice, typeof(string)));
            dtAccountSummary.Columns.Add(new DataColumn(strTotalSellOpenPrice, typeof(string)));
            dtAccountSummary.Columns.Add(new DataColumn(strBalance, typeof(string)));
            dtAccountSummary.Columns.Add(new DataColumn(strLeverage, typeof(string)));
            dtAccountSummary.Columns.Add(new DataColumn(strPNL, typeof(string)));
            dtAccountSummary.Columns.Add(new DataColumn(strServiceFee, typeof(double)));
            dtAccountSummary.Columns.Add(new DataColumn(strTotalFee, typeof(double)));
            return dtAccountSummary;
        }

        public static DataTable GetTradeSummaryTable()
        {
            DataTable dtTradeSummary = new DataTable();
            dtTradeSummary.Columns.Add(new DataColumn(_strAccountID, typeof(string)));
            dtTradeSummary.Columns.Add(new DataColumn(_strTotalrisk, typeof(string)));
            dtTradeSummary.Columns.Add(new DataColumn(_strBuyOpen, typeof(string)));
            dtTradeSummary.Columns.Add(new DataColumn(_strSellOpen, typeof(string)));
            //dtTradeSummary.Columns.Add(new DataColumn(_strBuyPNL, typeof(string)));
            //dtTradeSummary.Columns.Add(new DataColumn(_strSellPNL, typeof(string)));
            //dtTradeSummary.Columns.Add(new DataColumn(_strTotalStorage, typeof(string)));
            //dtTradeSummary.Columns.Add(new DataColumn(_strTStorage, typeof(string)));
            //dtTradeSummary.Columns.Add(new DataColumn(_strTodayTC, typeof(string)));
            //dtTradeSummary.Columns.Add(new DataColumn(_strTotalTC, typeof(string)));
            //dtTradeSummary.Columns.Add(new DataColumn(_strMLMToday, typeof(string)));
            //dtTradeSummary.Columns.Add(new DataColumn(_strMLMTotal, typeof(string)));
            //dtTradeSummary.Columns.Add(new DataColumn(_strMLMTPaid, typeof(string)));
            //dtTradeSummary.Columns.Add(new DataColumn(_strMLMTPC, typeof(string)));
            //dtTradeSummary.Columns.Add(new DataColumn(_strTCCTODAY, typeof(string)));
            //dtTradeSummary.Columns.Add(new DataColumn(_strTCCTotal, typeof(string)));

            dtTradeSummary.Columns.Add(new DataColumn(_strBuyPNL, typeof(double)));
            dtTradeSummary.Columns.Add(new DataColumn(_strSellPNL, typeof(double)));
            dtTradeSummary.Columns.Add(new DataColumn(_strTotalStorage, typeof(double)));
            dtTradeSummary.Columns.Add(new DataColumn(_strTStorage, typeof(double)));
            dtTradeSummary.Columns.Add(new DataColumn(_strTodayTC, typeof(double)));
            dtTradeSummary.Columns.Add(new DataColumn(_strTotalTC, typeof(double)));
            dtTradeSummary.Columns.Add(new DataColumn(_strMLMToday, typeof(double)));
            dtTradeSummary.Columns.Add(new DataColumn(_strMLMTotal, typeof(double)));
            dtTradeSummary.Columns.Add(new DataColumn(_strMLMTPaid, typeof(double)));
            dtTradeSummary.Columns.Add(new DataColumn(_strMLMTPC, typeof(double)));
            dtTradeSummary.Columns.Add(new DataColumn(_strTCCTODAY, typeof(double)));
            dtTradeSummary.Columns.Add(new DataColumn(_strTCCTotal, typeof(double)));

            return dtTradeSummary;
        }
    }
}
