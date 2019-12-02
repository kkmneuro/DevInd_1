using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace AlertService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AlertService" in code, svc and config file together.
    public class AlertService : IAlertService
    {
        GeneralResult objGeneralResult = new GeneralResult();
        static string ConnectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection myConnection = new SqlConnection(ConnectionString);
       // SqlConnection myConnection = new SqlConnection(@"Data Source=203.190.146.73;" + @"Initial Catalog=BOExchange;User ID=sa;Password=admin123@");
    

        public GeneralResult AddAlert(int userId, AlertDTO alert)
        {
            try
            {
                myConnection.Open();

                SqlCommand cmd = new SqlCommand("WS_Exchange_AddAlert", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@UserId", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@AlertName", SqlDbType.VarChar));
                cmd.Parameters.Add(new SqlParameter("@AlertType", SqlDbType.VarChar));
                cmd.Parameters.Add(new SqlParameter("@Exchange", SqlDbType.VarChar));
                cmd.Parameters.Add(new SqlParameter("@Symbol", SqlDbType.VarChar));
                cmd.Parameters.Add(new SqlParameter("@Tag", SqlDbType.VarChar));

                SqlParameter SPResponce = new SqlParameter("@SPResponce", SqlDbType.Bit);
                SPResponce.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(SPResponce);

                cmd.Parameters["@userId"].Value = userId;
                cmd.Parameters["@AlertName"].Value = alert.AlertName;
                cmd.Parameters["@AlertType"].Value = alert.AlertType.ToString();
                cmd.Parameters["@Exchange"].Value = alert.Exchange;
                cmd.Parameters["@Symbol"].Value = alert.Symbol;
                cmd.Parameters["@Tag"].Value = alert.Tag;

                cmd.ExecuteNonQuery();

                objGeneralResult.Object = Convert.ToBoolean(cmd.Parameters["@SPResponce"].Value);

                if (objGeneralResult.Object == true)
                {
                    objGeneralResult.Result = ResultType.Success;
                    objGeneralResult.ErrorMessage = "Alert is added  successfully";
                }
                else
                {
                    objGeneralResult.Result = ResultType.Warning;
                    objGeneralResult.ErrorMessage = "Error in data insertion";
                }


            }
            catch (Exception ex)
            {
                objGeneralResult.Result = ResultType.Failure;
                objGeneralResult.ErrorMessage = ex.Message;
                objGeneralResult.Object = false;
            }
            finally
            {
                myConnection.Close();
            }

            return objGeneralResult;
        }

        public GeneralResult AddAlertScript(int userId, AlertScriptDTO alertScriptDTO)
        {
            try
            {
                myConnection.Open();

                SqlCommand cmd = new SqlCommand("WS_Exchange_AddAlertScript", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@UniquId", SqlDbType.VarChar));
                cmd.Parameters.Add(new SqlParameter("@UserId", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@Abbreviation", SqlDbType.VarChar));
                cmd.Parameters.Add(new SqlParameter("@AlertName", SqlDbType.VarChar));
                cmd.Parameters.Add(new SqlParameter("@Bars", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@BuyScript", SqlDbType.VarChar));
                cmd.Parameters.Add(new SqlParameter("@DayHours", SqlDbType.Bit));
                cmd.Parameters.Add(new SqlParameter("@DefaultScript", SqlDbType.VarChar));
                cmd.Parameters.Add(new SqlParameter("@Enabled", SqlDbType.Bit));
                cmd.Parameters.Add(new SqlParameter("@EndOfDay", SqlDbType.Bit));
                cmd.Parameters.Add(new SqlParameter("@Exchange", SqlDbType.VarChar));
                cmd.Parameters.Add(new SqlParameter("@ExitLongScript", SqlDbType.VarChar));
                cmd.Parameters.Add(new SqlParameter("@ExitShortScript", SqlDbType.VarChar));
                cmd.Parameters.Add(new SqlParameter("@GTC", SqlDbType.Bit));
                cmd.Parameters.Add(new SqlParameter("@GTCHours", SqlDbType.Bit));
                cmd.Parameters.Add(new SqlParameter("@Interval", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@IsUserDefined", SqlDbType.Bit));
                cmd.Parameters.Add(new SqlParameter("@Limit", SqlDbType.Bit));
                cmd.Parameters.Add(new SqlParameter("@Market", SqlDbType.Bit));
                cmd.Parameters.Add(new SqlParameter("@Period", SqlDbType.VarChar));
                cmd.Parameters.Add(new SqlParameter("@Portfolio", SqlDbType.VarChar));
                cmd.Parameters.Add(new SqlParameter("@Quantity", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@SellScript", SqlDbType.VarChar));
                cmd.Parameters.Add(new SqlParameter("@StopLimit", SqlDbType.Bit));
                cmd.Parameters.Add(new SqlParameter("@StopLimitValue", SqlDbType.VarChar));
                cmd.Parameters.Add(new SqlParameter("@StopMarket", SqlDbType.Bit));
                cmd.Parameters.Add(new SqlParameter("@Symbol", SqlDbType.VarChar));
                cmd.Parameters.Add(new SqlParameter("@TradeSignalScript", SqlDbType.VarChar));


                SqlParameter SPResponce = new SqlParameter("@SPResponce", SqlDbType.Bit);
                SPResponce.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(SPResponce);


                cmd.Parameters["@UniquId"].Value = alertScriptDTO.UniqueId.ToString();
                cmd.Parameters["@UserId"].Value = userId;
                cmd.Parameters["@Abbreviation"].Value = alertScriptDTO.Abbreviation;
                cmd.Parameters["@AlertName"].Value = alertScriptDTO.AlertName;
                cmd.Parameters["@Bars"].Value = alertScriptDTO.Bars;
                cmd.Parameters["@BuyScript"].Value = alertScriptDTO.BuyScript;
                cmd.Parameters["@DayHours"].Value = alertScriptDTO.DayHours;
                cmd.Parameters["@DefaultScript"].Value = alertScriptDTO.DefaultScript;
                cmd.Parameters["@Enabled"].Value = alertScriptDTO.Enabled;
                cmd.Parameters["@EndOfDay"].Value = alertScriptDTO.EndOfDay;
                cmd.Parameters["@Exchange"].Value = alertScriptDTO.Exchange;
                cmd.Parameters["@ExitLongScript"].Value = alertScriptDTO.ExitLongScript;
                cmd.Parameters["@ExitShortScript"].Value = alertScriptDTO.ExitShortScript;
                cmd.Parameters["@GTC"].Value = alertScriptDTO.GTC;
                cmd.Parameters["@GTCHours"].Value = alertScriptDTO.GTCHours;
                cmd.Parameters["@Interval"].Value = alertScriptDTO.Interval;
                cmd.Parameters["@IsUserDefined"].Value = alertScriptDTO.IsUserDefined;
                cmd.Parameters["@Limit"].Value = alertScriptDTO.Limit;
                cmd.Parameters["@Market"].Value = alertScriptDTO.Market;
                cmd.Parameters["@Period"].Value = alertScriptDTO.Period;
                cmd.Parameters["@Portfolio"].Value = alertScriptDTO.Portfolio;
                cmd.Parameters["@Quantity"].Value = alertScriptDTO.Quantity;
                cmd.Parameters["@SellScript"].Value = alertScriptDTO.SellScript;
                cmd.Parameters["@StopLimit"].Value = alertScriptDTO.StopLimit;
                cmd.Parameters["@StopLimitValue"].Value = alertScriptDTO.StopLimitValue;
                cmd.Parameters["@StopMarket"].Value = alertScriptDTO.StopMarket;
                cmd.Parameters["@Symbol"].Value = alertScriptDTO.Symbol;
                cmd.Parameters["@TradeSignalScript"].Value = alertScriptDTO.TradeSignalScript;

                cmd.ExecuteNonQuery();

                objGeneralResult.Object = Convert.ToBoolean(cmd.Parameters["@SPResponce"].Value);

                if (objGeneralResult.Object == true)
                {
                    objGeneralResult.Result = ResultType.Success;
                    objGeneralResult.ErrorMessage = "Alert Script is added  successfully";
                }
                else
                {
                    objGeneralResult.Result = ResultType.Warning;
                    objGeneralResult.ErrorMessage = "Error in data insertion";
                }


            }
            catch (Exception ex)
            {
                objGeneralResult.Result = ResultType.Failure;
                objGeneralResult.ErrorMessage = ex.Message;
                objGeneralResult.Object = false;
            }
            finally
            {
                myConnection.Close();
            }

            return objGeneralResult;
        }

        public GeneralResult RemoveAlertScript(int userId, string alertName)
        {
            try
            {
                myConnection.Open();

                SqlCommand cmd = new SqlCommand("WS_Exchange_RemoveAlertScript", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add(new SqlParameter("@UserId", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@AlertName", SqlDbType.VarChar));               

                SqlParameter SPResponce = new SqlParameter("@SPResponce", SqlDbType.Bit);
                SPResponce.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(SPResponce);

                cmd.Parameters["@UserId"].Value = userId;
                cmd.Parameters["@AlertName"].Value = alertName;
             

                cmd.ExecuteNonQuery();

                objGeneralResult.Object = Convert.ToBoolean(cmd.Parameters["@SPResponce"].Value);

                if (objGeneralResult.Object == true)
                {
                    objGeneralResult.Result = ResultType.Success;
                    objGeneralResult.ErrorMessage = "Alert Script is removed  successfully";
                }
                else
                {
                    objGeneralResult.Result = ResultType.Warning;
                    objGeneralResult.ErrorMessage = "Error in data deletion";
                }


            }
            catch (Exception ex)
            {
                objGeneralResult.Result = ResultType.Failure;
                objGeneralResult.ErrorMessage = ex.Message;
                objGeneralResult.Object = false;
            }
            finally
            {
                myConnection.Close();
            }
            return objGeneralResult;
        }

        public GeneralResult RemoveAlertScriptById(int userId, Guid alertId)
        {
            try
            {
                myConnection.Open();

                SqlCommand cmd = new SqlCommand("WS_Exchange_RemoveAlertScriptById", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add(new SqlParameter("@UserId", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@UniquId", SqlDbType.VarChar));

                SqlParameter SPResponce = new SqlParameter("@SPResponce", SqlDbType.Bit);
                SPResponce.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(SPResponce);

                cmd.Parameters["@UserId"].Value = userId;
                cmd.Parameters["@UniquId"].Value = alertId.ToString();


                cmd.ExecuteNonQuery();

                objGeneralResult.Object = Convert.ToBoolean(cmd.Parameters["@SPResponce"].Value);

                if (objGeneralResult.Object == true)
                {
                    objGeneralResult.Result = ResultType.Success;
                    objGeneralResult.ErrorMessage = "Alert Script is removed  successfully";
                }
                else
                {
                    objGeneralResult.Result = ResultType.Warning;
                    objGeneralResult.ErrorMessage = "Error in data deletion";
                }


            }
            catch (Exception ex)
            {
                objGeneralResult.Result = ResultType.Failure;
                objGeneralResult.ErrorMessage = ex.Message;
                objGeneralResult.Object = false;
            }
            finally
            {
                myConnection.Close();
            }
            return objGeneralResult;
        }

        public GeneralResult RemoveScanner(int userId, string scannerName)
        {
            try
            {
                myConnection.Open();

                SqlCommand cmd = new SqlCommand("WS_Exchange_RemoveScanner", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add(new SqlParameter("@UserId", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@ScannerName", SqlDbType.VarChar));

                SqlParameter SPResponce = new SqlParameter("@SPResponce", SqlDbType.Bit);
                SPResponce.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(SPResponce);

                cmd.Parameters["@UserId"].Value = userId;
                cmd.Parameters["@ScannerName"].Value = scannerName;


                cmd.ExecuteNonQuery();

                objGeneralResult.Object = Convert.ToBoolean(cmd.Parameters["@SPResponce"].Value);

                if (objGeneralResult.Object == true)
                {
                    objGeneralResult.Result = ResultType.Success;
                    objGeneralResult.ErrorMessage = "Scanner is removed  successfully";
                }
                else
                {
                    objGeneralResult.Result = ResultType.Warning;
                    objGeneralResult.ErrorMessage = "Error in data deletion";
                }


            }
            catch (Exception ex)
            {
                objGeneralResult.Result = ResultType.Failure;
                objGeneralResult.ErrorMessage = ex.Message;
                objGeneralResult.Object = false;
            }
            finally
            {
                myConnection.Close();
            }
            return objGeneralResult;
        }

        public GeneralResult SaveScanner(int userId, ScannerDTO scannerDTO)
        {
            try
            {
                myConnection.Open();

                SqlCommand cmd = new SqlCommand("WS_Exchange_SaveScanner", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;


               cmd.Parameters.Add(new SqlParameter("@UserId", SqlDbType.Int));
               cmd.Parameters.Add(new SqlParameter("@AlertScript", SqlDbType.VarChar));
               cmd.Parameters.Add(new SqlParameter("@BarHistory", SqlDbType.Int));
               cmd.Parameters.Add(new SqlParameter("@BarInterval", SqlDbType.Int));
               cmd.Parameters.Add(new SqlParameter("@Exchange", SqlDbType.VarChar));
               cmd.Parameters.Add(new SqlParameter("@IsLocked", SqlDbType.Bit));
               cmd.Parameters.Add(new SqlParameter("@IsPaused", SqlDbType.Bit));
               cmd.Parameters.Add(new SqlParameter("@Periodicity", SqlDbType.VarChar));
               cmd.Parameters.Add(new SqlParameter("@ScannerName", SqlDbType.VarChar));
               cmd.Parameters.Add(new SqlParameter("@Symbol", SqlDbType.VarChar));
                
                SqlParameter SPResponce = new SqlParameter("@SPResponce", SqlDbType.Bit);
                SPResponce.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(SPResponce);

               cmd.Parameters["@UserId"].Value = userId;
               cmd.Parameters["@AlertScript"].Value = scannerDTO.AlertScript;
               cmd.Parameters["@BarHistory"].Value = scannerDTO.BarHistory;
               cmd.Parameters["@BarInterval"].Value = scannerDTO.BarInterval;
               cmd.Parameters["@Exchange"].Value = scannerDTO.Exchange;
               cmd.Parameters["@IsLocked"].Value = scannerDTO.IsLocked;
               cmd.Parameters["@IsPaused"].Value = scannerDTO.IsPaused;
               cmd.Parameters["@Periodicity"].Value = scannerDTO.Periodicity;
               cmd.Parameters["@ScannerName"].Value = scannerDTO.ScannerName;
               cmd.Parameters["@Symbol"].Value = scannerDTO.Symbol;

                cmd.ExecuteNonQuery();

                objGeneralResult.Object = Convert.ToBoolean(cmd.Parameters["@SPResponce"].Value);

                if (objGeneralResult.Object == true)
                {
                    objGeneralResult.Result = ResultType.Success;
                    objGeneralResult.ErrorMessage = "Alert scanner is added  successfully";
                }
                else
                {
                    objGeneralResult.Result = ResultType.Warning;
                    objGeneralResult.ErrorMessage = "Error in data insertion";
                }


            }
            catch (Exception ex)
            {
                objGeneralResult.Result = ResultType.Failure;
                objGeneralResult.ErrorMessage = ex.Message;
                objGeneralResult.Object = false;
            }
            finally
            {
                myConnection.Close();
            }
            return objGeneralResult;
        }
    }
}
