using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace MailBoxService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MailBoxService" in code, svc and config file together.
    public class MailBoxService : IMailBoxService
    {
        List<MailBoxData> mailBoxData = new List<MailBoxData>();
        static string ConnectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection myConnection = new SqlConnection(ConnectionString);
        public List<MailBoxData> GetMailBoxData(string userID, string password, int participantID, DateTime fromDate, DateTime toDate)
        {
            DataTable dtMailBoxData = new DataTable();
            try
            {
                myConnection.Open();

                SqlCommand cmd = new SqlCommand("WS_Exchange_GetMailInfo", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@userID", SqlDbType.Char));
                cmd.Parameters.Add(new SqlParameter("@Password", SqlDbType.Char));
                cmd.Parameters.Add(new SqlParameter("@ParticipantID", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@FromDate", SqlDbType.DateTime));
                cmd.Parameters.Add(new SqlParameter("@ToDate", SqlDbType.DateTime));


                cmd.Parameters["@userID"].Value = userID;
                cmd.Parameters["@Password"].Value = password;
                cmd.Parameters["@ParticipantID"].Value = participantID;
                cmd.Parameters["@FromDate"].Value = fromDate;
                cmd.Parameters["@ToDate"].Value = toDate;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dtMailBoxData);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                myConnection.Close();
            }
            if (dtMailBoxData.Rows.Count > 0)
            {
                for (int i = 0; i < dtMailBoxData.Rows.Count; i++)
                {
                    MailBoxData objMailBox = new MailBoxData();

                    objMailBox.MsgTime = Convert.ToDateTime(dtMailBoxData.Rows[i]["MsgTime"]);
                    objMailBox.Sender = dtMailBoxData.Rows[i]["Sender"].ToString();
                    objMailBox.Recipient = dtMailBoxData.Rows[i]["Recipient"].ToString();
                    objMailBox.Subject = dtMailBoxData.Rows[i]["Subject"].ToString();
                    objMailBox.Discription = dtMailBoxData.Rows[i]["Description"].ToString();

                    mailBoxData.Add(objMailBox);
                }
            }
            return mailBoxData;
        }
    }
}



