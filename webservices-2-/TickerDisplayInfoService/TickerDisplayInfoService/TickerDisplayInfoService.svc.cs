using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace TickerDisplayInfoService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TickerDisplayInfoService" in code, svc and config file together.
    public class TickerDisplayInfoService : ITickerDisplayInfoService
    {
        List<string> tickerDisplayInfo = new List<string>();

        public List<string> GetTickerDisplayInfo(int AccountGroupId)
        {
             DataTable data = new DataTable();
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);           

            try
            {
                myConnection.Open();

                SqlCommand cmd = new SqlCommand("WS_Exchange_GetTickerDisplayInfo", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@AccountGroupID", SqlDbType.Int));
                cmd.Parameters["@AccountGroupID"].Value = AccountGroupId;
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
                    tickerDisplayInfo.Add(data.Rows[i]["TickerInfo"].ToString());
                }
            }
            return tickerDisplayInfo;
        }
    }
}
