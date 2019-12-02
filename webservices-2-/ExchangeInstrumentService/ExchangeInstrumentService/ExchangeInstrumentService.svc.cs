using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ExchangeInstrumentService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ExchangeInstrumentService" in code, svc and config file together.
    public class ExchangeInstrumentService : IExchangeInstrumentService
    {
        List<InstrumentData> istrumentData = new List<InstrumentData>();
        List<InstrumentInfo> istrumentInfo = new List<InstrumentInfo>();

        #region IExchangeInstrumentService Members

        public List<InstrumentData> GetInstrumentSpec(int participantsId)
        {
            DataTable data = new DataTable();
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);           

            try
            {
                myConnection.Open();

                SqlCommand cmd = new SqlCommand("WS_Exchange_GetInstrumentInfo", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ParticipantsID", SqlDbType.Int));
                cmd.Parameters["@ParticipantsID"].Value = participantsId;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                myConnection.Close();
            }
            if (data.Rows.Count > 0)
            {
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    InstrumentData instrumentData = new InstrumentData();

                    instrumentData.BuySideTurnover = data.Rows[i]["Buy_Side_Turnover"].ToString();            
                    instrumentData.ContractSize = data.Rows[i]["ContractSize"].ToString();
                    instrumentData.DeliveryEndDate = data.Rows[i]["Delivery_End_Date"].ToString();
                    instrumentData.DeliveryQuantity = data.Rows[i]["Delivery_Quantity"].ToString();
                    instrumentData.DeliveryStartDate = data.Rows[i]["Delivery_Start_Date"].ToString();
                    instrumentData.DeliveryType = data.Rows[i]["Delivery_Type"].ToString();
                    instrumentData.DeliveryUnit = data.Rows[i]["FK_Delivery_Unit"].ToString();
                    instrumentData.Descriptions = data.Rows[i]["Descriptions"].ToString();
                    instrumentData.Digits = data.Rows[i]["Digits"].ToString();
                    instrumentData.DPRInitialPercentage = data.Rows[i]["DPR_Initial_Percentage"].ToString();
                    instrumentData.DPRInterval = data.Rows[i]["DPR_Interval"].ToString();
                    instrumentData.DPRRangeHigher = data.Rows[i]["DPR_Range_Higher"].ToString();
                    instrumentData.EndDate = data.Rows[i]["End_Date"].ToString();
                    instrumentData.ExpiryDate = data.Rows[i]["Expiry_Date"].ToString();
                    instrumentData.FreezeLevel = data.Rows[i]["FreezeLevel"].ToString();
                    instrumentData.Hedged = data.Rows[i]["Hedged"].ToString();
                    instrumentData.InitialBuyMargin = data.Rows[i]["Initial_Buy_Margin"].ToString();
                    instrumentData.InitialSellMargin = data.Rows[i]["Initial_Sell_Margin"].ToString();
                    instrumentData.InstruementID = data.Rows[i]["PK_InstruementID"].ToString();
                    instrumentData.IsActive = data.Rows[i]["IsActive"].ToString();
                    instrumentData.LimitAndStopLevel = data.Rows[i]["LimitandStopLevel"].ToString();
                    instrumentData.LPID = data.Rows[i]["FK_LPID"].ToString();
                    instrumentData.MaintenanceBuyMargin = data.Rows[i]["Maintenance_Buy_Margin"].ToString();
                    instrumentData.MaintenanceSellMargin = data.Rows[i]["Maintenance_Sell_Margin"].ToString();
                    instrumentData.MarginCurrency = data.Rows[i]["MarginCurrency"].ToString();
                    instrumentData.MarketLot = data.Rows[i]["Market_Lot"].ToString();
                    instrumentData.MaximumAllowablePosition = data.Rows[i]["Maximum_Allowable_Position"].ToString();
                    instrumentData.MaximumLots = data.Rows[i]["Maximum_Lots"].ToString();
                    instrumentData.MaximumOrderValue = data.Rows[i]["Maximum_Order_Value"].ToString();
                    instrumentData.Orders = data.Rows[i]["FK_Orders"].ToString();
                    instrumentData.QuotationBaseValue = data.Rows[i]["Quotation_Base_Value"].ToString();
                    instrumentData.SecurityTypeChar = data.Rows[i]["SecurityTypeChar"].ToString();
                    instrumentData.SecurityTypeID = data.Rows[i]["FK_SecurityTypeID"].ToString();
                    instrumentData.SellSideTurnover = data.Rows[i]["Sell_Side_Turnover"].ToString();
                    instrumentData.SettlingCurrency = data.Rows[i]["SettlingCurrency"].ToString();
                    instrumentData.Source = data.Rows[i]["Source"].ToString();
                    instrumentData.Spread = data.Rows[i]["Spread"].ToString();
                    instrumentData.SpreadBalance = data.Rows[i]["SpreadBalance"].ToString();
                    instrumentData.StartDate = data.Rows[i]["Start_Date"].ToString();
                    instrumentData.Symbol = data.Rows[i]["Symbol"].ToString();
                    instrumentData.TenderEndDate = data.Rows[i]["Tender_End_Date"].ToString();
                    instrumentData.TenderStartDate = data.Rows[i]["Tender_start_Date"].ToString();
                    instrumentData.TickPrice = data.Rows[i]["TickPrice"].ToString();
                    instrumentData.TickSize = data.Rows[i]["TickSize"].ToString();
                    instrumentData.TradingCurrency = data.Rows[i]["TradingCurrency"].ToString();
                    instrumentData.ULAssest = data.Rows[i]["ULAssest"].ToString();                
                    instrumentData.TradingGateway = data.Rows[i]["TradingGateway"].ToString();
                    istrumentData.Add(instrumentData);
                }

            }
            return istrumentData;
        }
        #endregion



        public List<InstrumentInfo> GetInstrumentInfo(int participantsId)
        {
            DataTable data = new DataTable();
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);                

            try
            {
                myConnection.Open();

                SqlCommand cmd = new SqlCommand("WS_Exchange_GetInstrumentInfo", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ParticipantsID", SqlDbType.Int));
                cmd.Parameters["@LoginID"].Value = participantsId;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                myConnection.Close();
            }
            if (data.Rows.Count > 0)
            {
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    InstrumentInfo instrumentInfo = new InstrumentInfo();
                    instrumentInfo.Data = string.Empty;
                    for (int j = 0; j < data.Columns.Count; j++)
                    {
                        if (j < data.Columns.Count - 1)
                            instrumentInfo.Data = instrumentInfo.Data + data.Rows[i][j] + ",";
                        else
                            instrumentInfo.Data = instrumentInfo.Data + data.Rows[i][j];
                    }

                    istrumentInfo.Add(instrumentInfo);
                }

            }
            return istrumentInfo;
        }
    }
}