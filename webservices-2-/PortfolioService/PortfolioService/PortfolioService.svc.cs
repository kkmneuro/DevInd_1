using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace PortfolioService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PortfolioService" in code, svc and config file together.
    public class PortfolioService : IPortfolioService
    {
        GeneralResult objGeneralResult = new GeneralResult();
        static string ConnectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection myConnection = new SqlConnection(ConnectionString);
        // SqlConnection myConnection = new SqlConnection(@"Data Source=203.190.146.73;" + @"Initial Catalog=BOExchange;User ID=sa;Password=admin123@");

        public GeneralResult AddDataPortfolio(int userId, string portfolioName)
        {

            try
            {
                myConnection.Open();

                SqlCommand cmd = new SqlCommand("WS_Exchange_AddDataPortfolio", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@userId", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@PortfolioName", SqlDbType.VarChar));
                SqlParameter SPResponce = new SqlParameter("@SPResponce", SqlDbType.Bit);
                SPResponce.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(SPResponce);

                cmd.Parameters["@userId"].Value = userId;
                cmd.Parameters["@PortfolioName"].Value = portfolioName;


                cmd.ExecuteNonQuery();

                objGeneralResult.Object = Convert.ToBoolean(cmd.Parameters["@SPResponce"].Value);

                if (objGeneralResult.Object == true)
                {
                    objGeneralResult.Result = ResultType.Success;
                    objGeneralResult.ErrorMessage = "Portfolio is added  successfully";
                }
                else
                {
                    objGeneralResult.Result = ResultType.Warning;
                    objGeneralResult.ErrorMessage = "Portfolio already exist";
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

        public GeneralResult AddDataPortfolioInstrument(int userId, string portfolioName, string Exchange, string Symbol, string AlternateSymbol, string ISIN, string MarketSegment, string Security, string ShortName)
        {
            char _SPInsertResponce;
            try
            {
                myConnection.Open();

                SqlCommand cmd = new SqlCommand("WS_Exchange_AddDataPortfolioInstrument", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@userId", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@PortfolioName", SqlDbType.VarChar));
                cmd.Parameters.Add(new SqlParameter("@Exchange", SqlDbType.VarChar));
                cmd.Parameters.Add(new SqlParameter("@Symbol", SqlDbType.VarChar));
                cmd.Parameters.Add(new SqlParameter("@AlternateSymbol", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@ISIN", SqlDbType.VarChar));
                cmd.Parameters.Add(new SqlParameter("@MarketSegment", SqlDbType.VarChar));
                cmd.Parameters.Add(new SqlParameter("@Security", SqlDbType.VarChar));
                cmd.Parameters.Add(new SqlParameter("@ShortName", SqlDbType.VarChar));



                SqlParameter SPResponce = new SqlParameter("@SPResponce", SqlDbType.Bit);
                SPResponce.Direction = ParameterDirection.Output;
                SqlParameter SPInsertResponce = new SqlParameter("@SPInsertResponce", SqlDbType.Char);
                SPResponce.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(SPResponce);
                cmd.Parameters.Add(SPInsertResponce);

                cmd.Parameters["@userId"].Value = userId;
                cmd.Parameters["@PortfolioName"].Value = portfolioName;
                cmd.Parameters["@Exchange"].Value = Exchange;
                cmd.Parameters["@Symbol"].Value = Symbol;
                cmd.Parameters["@AlternateSymbol"].Value = AlternateSymbol;
                cmd.Parameters["@ISIN"].Value = ISIN;
                cmd.Parameters["@MarketSegment"].Value = MarketSegment;
                cmd.Parameters["@Security"].Value = Security;
                cmd.Parameters["@ShortName"].Value = ShortName;
                cmd.Parameters["@SPInsertResponce"].Value = '0';
                cmd.Parameters["@SPResponce"].Value = '0';
                cmd.ExecuteNonQuery();

                objGeneralResult.Object = Convert.ToBoolean(cmd.Parameters["@SPResponce"].Value);
                _SPInsertResponce = Convert.ToChar(cmd.Parameters["@SPInsertResponce"].Value);

                if (objGeneralResult.Object == true)
                {
                    objGeneralResult.Result = ResultType.Success;
                    if (_SPInsertResponce == 'I')
                    {
                        objGeneralResult.ErrorMessage = "Portfolio data is added  successfully";
                    }
                    else if (_SPInsertResponce == 'E')
                        objGeneralResult.ErrorMessage = "Portfolio data is already exist in database";
                }
                else
                {
                    objGeneralResult.ErrorMessage = "Portfolio does not exist";
                    objGeneralResult.Result = ResultType.Warning;
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

        public GeneralResult RemoveDataPortfolio(int userId, string portfolioName)
        {
            try
            {
                myConnection.Open();

                SqlCommand cmd = new SqlCommand("WS_Exchange_RemoveDataPortfolio", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@userId", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@portfolioName", SqlDbType.VarChar));
                SqlParameter SPResponce = new SqlParameter("@SPResponce", SqlDbType.Bit);
                SPResponce.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(SPResponce);

                cmd.Parameters["@userId"].Value = userId;
                cmd.Parameters["@portfolioName"].Value = portfolioName;


                cmd.ExecuteNonQuery();

                objGeneralResult.Object = Convert.ToBoolean(cmd.Parameters["@SPResponce"].Value);

                if (objGeneralResult.Object == true)
                {
                    objGeneralResult.Result = ResultType.Success;
                    objGeneralResult.ErrorMessage = "Portfolio is removed  successfully";
                }
                else
                {
                    objGeneralResult.Result = ResultType.Warning;
                    objGeneralResult.ErrorMessage = "Portfolio does not exist";
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

        public GeneralResult RemoveDataPortfolioInstrument(int userId, string portfolioName, string exchange, string symbol)
        {
            try
            {
                myConnection.Open();

                SqlCommand cmd = new SqlCommand("WS_Exchange_RemoveDataPortfolioInstrument", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@userId", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@PortfolioName", SqlDbType.VarChar));
                cmd.Parameters.Add(new SqlParameter("@Exchange", SqlDbType.VarChar));
                cmd.Parameters.Add(new SqlParameter("@Symbol", SqlDbType.VarChar));
                SqlParameter SPResponce = new SqlParameter("@SPResponce", SqlDbType.Bit);
                SPResponce.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(SPResponce);

                cmd.Parameters["@userId"].Value = userId;
                cmd.Parameters["@PortfolioName"].Value = portfolioName;
                cmd.Parameters["@Exchange"].Value = exchange;
                cmd.Parameters["@Symbol"].Value = symbol;

                cmd.ExecuteNonQuery();

                objGeneralResult.Object = Convert.ToBoolean(cmd.Parameters["@SPResponce"].Value);

                if (objGeneralResult.Object == true)
                {
                    objGeneralResult.Result = ResultType.Success;
                    objGeneralResult.ErrorMessage = "Portfolio data is removed  successfully";
                }
                else
                {
                    objGeneralResult.Result = ResultType.Warning;
                    objGeneralResult.ErrorMessage = "Portfolio data does not exist";
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


        public List<DataPortfolioDTO> GetUserPortfolio(int userId)
        {
            List<DataPortfolioDTO> _dataPortfolioDTO = new List<DataPortfolioDTO>();

            DataTable data = new DataTable();

            try
            { 
                myConnection.Open();

                SqlCommand cmd = new SqlCommand("WS_Exchange_GetDataPortfolioInstrument", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@userId", SqlDbType.Int));

                cmd.Parameters["@userId"].Value = userId;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(data);
                DataTable _portfolos = null;

                if (data.Columns.Contains("PortfolioID"))
                {
                    _portfolos = data.DefaultView.ToTable(true, "PortfolioID");
                    foreach (DataRow dr in _portfolos.Rows)
                    {
                        DataPortfolioDTO _portfolio = new DataPortfolioDTO();


                        int portfolioid = Convert.ToInt32(dr["PortfolioID"].ToString());
                        DataRow[] _Instruments = data.Select("PortfolioID=" + portfolioid);
                        _portfolio.PortfolioName = _Instruments[0]["PortfolioName"].ToString();
                        foreach (DataRow dr1 in _Instruments)
                        {
                            InstrumentDTO _instrumentDTO = new InstrumentDTO();

                            _instrumentDTO.AlternateSymbol = dr1["AlternateSymbol"].ToString();
                            _instrumentDTO.Exchange = dr1["Exchange"].ToString();
                            _instrumentDTO.ISIN = dr1["ISIN"].ToString();
                            _instrumentDTO.MarketSegment = dr1["MarketSegment"].ToString();
                            _instrumentDTO.Security = dr1["Security"].ToString();
                            _instrumentDTO.ShortName = dr1["ShortName"].ToString();
                            _instrumentDTO.Symbol = dr1["Symbol"].ToString();

                            _portfolio.Instruments.Add(_instrumentDTO);
                        }
                        _dataPortfolioDTO.Add(_portfolio);
                    }
                }
                else
                {
                    throw new Exception("Data did not populated");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                myConnection.Close();
            }
            return _dataPortfolioDTO;
        }


        public void AddWorkspace(int AccountID, byte[] Workspace)
        {
            try
            {
                myConnection.Open();

                SqlCommand cmd = new SqlCommand("WS_Exchange_AddWorkspace", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@AccountId", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@Workspace", SqlDbType.VarBinary));
                cmd.Parameters["@AccountId"].Value = AccountID;
                cmd.Parameters["@Workspace"].Value = Workspace;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                myConnection.Close();
            }

        }

        public byte[] GetWorkspace(int AccountID)
        {
            DataTable data = new DataTable();
            try
            {
                myConnection.Open();

                SqlCommand cmd = new SqlCommand("WS_Exchange_GetWorkspace", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@AccountId", SqlDbType.Int));

                cmd.Parameters["@AccountId"].Value = AccountID;

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
            byte[] Workspace = (byte[])data.Rows[0]["Workspace"];
            return Workspace;
        }
    }
}

