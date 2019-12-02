using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace OHLCFundExchangeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "OHLCFundExchangeService" in code, svc and config file together.
    public class OHLCFundExchangeService : IOHLCFundExchangeService
    {
        List<OHLCData> ohlcData = new List<OHLCData>();
        public List<OHLCData> GetHistoricalDataBySymbolID(string endDate, int symbolId, int interval, string bars, PeriodEnum periodicity)
        {
            string _periodicity = string.Empty;

            switch (periodicity)
            {
                case PeriodEnum.Minute:
                    switch (interval)
                    {

                        case 1: _periodicity = "1MIN";
                            break;
                        case 5: _periodicity = "5MIN";
                            break;
                        case 15: _periodicity = "15MIN";
                            break;
                        case 30: _periodicity = "30MIN";
                            break;
                    }
                    break;
                case PeriodEnum.Hour: _periodicity = "60MIN";
                    break;
                case PeriodEnum.Day: _periodicity = "DAILY";
                    break;
                case PeriodEnum.Week: _periodicity = "WEEKLY";
                    break;
                case PeriodEnum.Month: _periodicity = "MONTHLY";
                    break;
                case PeriodEnum.Year: _periodicity = "YEARLY";
                    break;
            }

            return GetData(endDate, bars, symbolId.ToString(), _periodicity, "SymbolID");

        }

        private List<OHLCData> GetData(string _endDate, string _bars, string _symbolID, string _periodicity, string _searchCriteria)
        {
            DataTable data = new DataTable();
            DataTable partialData = new DataTable();
            DateTime EndDate = Convert.ToDateTime(_endDate);

            //string connectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            //SqlConnection myConnection = new SqlConnection(connectionString);

            string connectionString = ConfigurationManager.ConnectionStrings["mySqlConString"].ConnectionString;
            MySqlConnection MySqlConn = new MySqlConnection(connectionString);

            #region for symbolId
            if (_searchCriteria == "SymbolID")
            {

                try
                {
                    MySqlConn.Open();

                    MySqlCommand cmd = new MySqlCommand("WS_Get_FundExchange_Historical_Data", MySqlConn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@Enddate", SqlDbType.DateTime));
                    cmd.Parameters.Add(new SqlParameter("@bar", SqlDbType.Int));
                    cmd.Parameters.Add(new SqlParameter("@Symbol", SqlDbType.Int));
                    cmd.Parameters.Add(new SqlParameter("@Periodicity", SqlDbType.VarChar));

                    cmd.Parameters["@Enddate"].Value = EndDate;
                    cmd.Parameters["@bar"].Value = Convert.ToInt32(_bars);
                    cmd.Parameters["@Symbol"].Value = _symbolID;
                    cmd.Parameters["@Periodicity"].Value = _periodicity;

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

                    adapter.Fill(data);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    MySqlConn.Close();
                }
            }
            #endregion for symbolId

            #region for symbolName
            if (_searchCriteria == "SymbolName")
            {
                try
                {
                    //SqlCommand cmd = new SqlCommand("WS_Get_FundExchange_Historical_Data_Symbol", myConnection);
                    MySqlCommand cmd = new MySqlCommand("WS_Get_FundExchange_Historical_Data_Symbol", MySqlConn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //=============================

                    MySqlParameter _Enddate = new MySqlParameter("Enddate", MySqlDbType.DateTime);
                    _Enddate.Value = Convert.ToDateTime(_endDate);
                    MySqlParameter _Symbol = new MySqlParameter("Symbol", MySqlDbType.VarChar);
                    _Symbol.Value = _symbolID.Trim();
                    MySqlParameter _bar = new MySqlParameter("bar", MySqlDbType.Int32);
                    _bar.Value = Convert.ToInt32(_bars.Trim());
                    MySqlParameter _Periodicity = new MySqlParameter("Periodicity", MySqlDbType.VarChar);
                    _Periodicity.Value = _periodicity;

                    cmd.Parameters.Add(_Enddate);
                    cmd.Parameters.Add(_Symbol);
                    cmd.Parameters.Add(_bar);
                    cmd.Parameters.Add(_Periodicity);


                    //===========================================



                    //myConnection.Open();
                    MySqlConn.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

                    adapter.Fill(data);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    MySqlConn.Close();
                }
            }
            #endregion for symbolName
            if (data.Rows.Count > 0)
            {
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    OHLCData _ohlcData = new OHLCData();

                    _ohlcData.DateTime = Convert.ToDateTime(data.Rows[i]["FeedTime"]);
                    _ohlcData.Open = Convert.ToDouble(data.Rows[i]["OpenPrice"]);
                    _ohlcData.High = Convert.ToDouble(data.Rows[i]["HighPrice"]);
                    _ohlcData.Low = Convert.ToDouble(data.Rows[i]["LowPrice"]);
                    _ohlcData.Close = Convert.ToDouble(data.Rows[i]["ClosePrice"]);
                    _ohlcData.Volume = Convert.ToDouble(data.Rows[i]["Volume"]);

                    ohlcData.Add(_ohlcData);
                }
                DateTime lastFeed = Convert.ToDateTime(data.Rows[data.Rows.Count - 1]["FeedTime"].ToString());
                if (lastFeed < EndDate && _searchCriteria == "SymbolName")
                {
                    try
                    {
                        MySqlConn.Open();

                        MySqlCommand cmd = new MySqlCommand("WS_Get_FundExchange_Partial_Historical_Data_Symbol", MySqlConn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        MySqlParameter _Enddate = new MySqlParameter("Enddate", MySqlDbType.DateTime);
                        _Enddate.Value = Convert.ToDateTime(_endDate);
                        MySqlParameter _Symbol = new MySqlParameter("Symbol", MySqlDbType.VarChar);
                        _Symbol.Value = _symbolID.Trim();
                        MySqlParameter _Startdate = new MySqlParameter("Startdate", MySqlDbType.DateTime);
                        _Startdate.Value = lastFeed;
             

                        cmd.Parameters.Add(_Enddate);
                        cmd.Parameters.Add(_Symbol);
                        cmd.Parameters.Add(lastFeed);                


                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

                        adapter.Fill(partialData);
                        if (partialData.Rows.Count > 0)
                        {
                            ohlcData.RemoveAt(0);
                            OHLCData _ohlcData = new OHLCData();

                            _ohlcData.DateTime = EndDate;
                            _ohlcData.Open = Convert.ToDouble(partialData.Rows[0]["OpenPrice"]);
                            _ohlcData.Low = Convert.ToDouble(partialData.Compute("min(LowPrice)", string.Empty));
                            _ohlcData.High = Convert.ToDouble(partialData.Compute("MAX(HighPrice)", string.Empty));
                            _ohlcData.Volume = Convert.ToDouble(partialData.Compute("SUM(Volume)", string.Empty));
                            _ohlcData.Close = Convert.ToDouble(partialData.Rows[partialData.Rows.Count - 1]["ClosePrice"]);

                            ohlcData.Add(_ohlcData);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        MySqlConn.Close();
                    }
                }
            }

            return ohlcData;
        }

        private string FormatData(string str)
        {
            string result = string.Empty;
            if (str.Contains('/'))
            {
                string[] data = str.Split('/');
                result = data[0] + data[1];
            }
            else
                result = str;
            return result;
        }

        public List<OHLCData> GetHistoricalDataBySymbolName(string endDate, string symbol, int interval, string bars, PeriodEnum periodicity)
        {
            string _periodicity = string.Empty;

            switch (periodicity)
            {
                case PeriodEnum.Minute:
                    switch (interval)
                    {

                        case 1: _periodicity = "1MIN";
                            break;
                        case 5: _periodicity = "5MIN";
                            break;
                        case 15: _periodicity = "15MIN";
                            break;
                        case 30: _periodicity = "30MIN";
                            break;
                        //case 60: _periodicity = "60MIN";
                        //    break;
                    }
                    break;
                case PeriodEnum.Hour: _periodicity = "60MIN";
                    break;
                case PeriodEnum.Day: _periodicity = "DAILY";
                    break;
                case PeriodEnum.Week: _periodicity = "WEEKLY";
                    break;
                case PeriodEnum.Month: _periodicity = "MONTHLY";
                    break;
                case PeriodEnum.Year: _periodicity = "YEARLY";
                    break;
            }

            return GetData(endDate, bars, symbol, _periodicity, "SymbolName");
        }
    }
}
