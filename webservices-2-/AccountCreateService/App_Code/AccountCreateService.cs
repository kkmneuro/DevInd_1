using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Configuration;
using System.Net.Mail;
using System.Net;
using System.Data;
using System.Data.SqlClient;


// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class AccountCreateService : IAccountCreateService
{
    public int SUCCESS_ID = -50052;
    public int FAILURE_ID = -50060;
    public int FAILURE_ID1 = -50062;
    public static int size = 0;
    string LoginID = string.Empty;
    string Password = string.Empty;

    Random objRandom = new Random();
    string lnqConnectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
    LoginCredential objLoginCredential = new LoginCredential();
    public string GetData(int value)
    {
        return string.Format("Rohit You entered: {0}     ", value);
    }

    public string GetDataUsingDataContract()
    {
        CompositeType composite = new CompositeType();
        string output = string.Empty;
        if (composite != null)
        {
            output = "composite.BoolValue = " + composite.BoolValue + "           composite.StringValue = " + composite.StringValue;
        }
        return output;
    }

    public List<BO_GetClientBankInformationResult> HandleBO_GetClientsBankInfo(int? clientID)
    {

        DataClassesDataContext s_GetClientsBankInfo;
        s_GetClientsBankInfo = new DataClassesDataContext(lnqConnectionString);
        lock (s_GetClientsBankInfo)
        {
            ISingleResult<BO_GetClientBankInformationResult> ret = s_GetClientsBankInfo.BO_GetClientBankInformation(clientID);
            int sp_retval = Convert.ToInt32(ret.ReturnValue);
            List<BO_GetClientBankInformationResult> ClientBankInformation = null;
            if (sp_retval == SUCCESS_ID)
            {
                CompositeType composite = new CompositeType();
                ClientBankInformation = ret.ToList();
                AccountCreateService.size = ClientBankInformation.Count;
            }
            else if (sp_retval == FAILURE_ID)
            {
                // Failure Code

            }
            return ClientBankInformation;
        }
    }


    public List<BO_GetLeverageListResult> HandleBO_GetLeverageList()
    {
        LeverageListDataContext s_GetLeverageList;
        s_GetLeverageList = new LeverageListDataContext(lnqConnectionString);
        lock (s_GetLeverageList)
        {
            ISingleResult<BO_GetLeverageListResult> ret = s_GetLeverageList.BO_GetLeverageList();
            int sp_retval = Convert.ToInt32(ret.ReturnValue);
            List<BO_GetLeverageListResult> LeverageList = null;
            if (sp_retval == SUCCESS_ID)
            {
                LeverageList = ret.ToList();
                AccountCreateService.size = LeverageList.Count;
            }
            else if (sp_retval == FAILURE_ID)
            {
                // Failure Code

            }
            return LeverageList;
        }

    }




    public List<BO_GetCountryMasterInfoResult> HandleBO_GetCountryList()
    {
        CountryListDataContext s_GetCountryList;
        s_GetCountryList = new CountryListDataContext(lnqConnectionString);
        lock (s_GetCountryList)
        {
            ISingleResult<BO_GetCountryMasterInfoResult> ret = s_GetCountryList.BO_GetCountryMasterInfo();
            int sp_retval = Convert.ToInt32(ret.ReturnValue);
            List<BO_GetCountryMasterInfoResult> CountryList = null;
            if (sp_retval == SUCCESS_ID)
            {
                CountryList = ret.ToList();
                AccountCreateService.size = CountryList.Count;
            }
            else if (sp_retval == FAILURE_ID)
            {
                // Failure Code

            }
            return CountryList;
        }

    }

    public int HandleBO_InsertBankDetails(string AccountHolderName, string BankAccountID, string BankName, int? BankCountryID,
                                            string BankCity, string BankZipCode, string BankAddress1,
                                            string BankAddress2, string BankPhone, string BankFax,
                                            string BankSwiftCode, int? ParticipantID, string BankAccountType,
                                            string BankIFSCode, ref int? BankId)
    {
        InsertInBankInfoDataContext s_InsertInBankInfo;
        s_InsertInBankInfo = new InsertInBankInfoDataContext(lnqConnectionString);
        lock (s_InsertInBankInfo)
        {
            int? bankId = BankId;
            int sp_retval = s_InsertInBankInfo.BO_InsertBankDetails(AccountHolderName, BankAccountID, BankName, BankCountryID,
                                                                   BankCity, BankZipCode, BankAddress1,
                                                                    BankAddress2, BankPhone, BankFax,
                                                                    BankSwiftCode, ParticipantID, BankAccountType,
                                                                    BankIFSCode, ref bankId);
            if (sp_retval == FAILURE_ID)
            {
                //Failure code
            }
            BankId = (int)bankId;
            return sp_retval;
        }

    }


    private string RandPassword()
    {
        char z = (char)objRandom.Next(65, 78);
        char y = (char)objRandom.Next(80, 90);
        char p = (char)objRandom.Next(97, 110);
        char x = (char)objRandom.Next(112, 122);
        int a = objRandom.Next(0, 9);
        int b = objRandom.Next(0, 9);
        string randval = z.ToString() + x + a + p + y + b;
        return randval;
    }
    private string RandLoginID()
    {
        char z = (char)objRandom.Next(65, 78);
        char p = (char)objRandom.Next(97, 110);
        char x = (char)objRandom.Next(112, 122);
        int a = objRandom.Next(0, 9);
        string randval = z.ToString() + x + a + p;
        return randval;
    }

    public LoginCredential CreateAccount(string firstName, string middleName, string lastName, string primaryEmailAddress, string secondaryEmailAddress,
                                                DateTime? DOB, string Gender, int? FK_NationalityID,
                                                string Address1, string Address2, int? FKCountryID,
                                                string City, string State, string Zip,
                                                string PrimaryPhone, string secondaryPhone, string FaxNumber,
                                                string Mobile, string PassportID, string SSN,
                                                string Age, string PAN, int? FKParticipantType,
                                                bool? status, bool? deleted, DateTime? registrationDate,
                                                int? FKAccountTypeID, int? FKAccountGroupID, ref int? participantId,
                                                decimal? MarkUpValue, ref int? ClientId, decimal? balanace,
                                                decimal? equity, decimal? usedMargin, int? fkleverage, bool? isHeadgingAllowed
                                                , bool? isTradeEnable, int? FK_Currency, decimal? buySideTurnOver, decimal? sellSideTurnOver,
                                                int? bankID, ref int? PKAccountID, string IP_Name, string IPAccount_ID, bool? IsLive, int? hedgeTypeID, string WhiteLevelName)
    {

        //Logging.FileHandling.WriteAllLog("Parameters are : firstName =" + firstName + ", middleName =" + middleName + ", lastName =" + lastName + ", primaryEmailAddress =" + primaryEmailAddress + ", secondaryEmailAddress =" + secondaryEmailAddress +
        //                                        ", DOB =" + DOB + ", Gender =" + Gender + ", FK_NationalityID =" + FK_NationalityID + ", Address1 =" + Address1 + ", Address2 =" + Address2 + ", FKCountryID =" + FKCountryID + ", City =" + City + ", State =" + State + ", Zip =" + Zip +
        //                                        ", PrimaryPhone =" + PrimaryPhone + ", secondaryPhone =" + secondaryPhone + ", FaxNumber =" + FaxNumber + ", Mobile =" + Mobile + ", PassportID =" + PassportID + ", SSN =" + SSN + ", Age =" + Age + ", PAN =" + PAN + ", FKParticipantType =" + FKParticipantType
        //                                        + ", status =" + status + ", deleted =" + deleted + ", registrationDate =" + registrationDate + ", FKAccountTypeID =" + FKAccountTypeID + ", FKAccountGroupID =" + FKAccountGroupID + ", participantId =" + participantId
        //                                        + ", MarkUpValue =" + MarkUpValue + ", ClientId =" + ClientId + ", balanace =" + balanace + ", equity =" + equity + ", usedMargin =" + usedMargin + ", fkleverage =" + fkleverage + ", isHeadgingAllowed =" + isHeadgingAllowed
        //                                        + ", isTradeEnable =" + isTradeEnable + ", FK_Currency =" + FK_Currency + ", buySideTurnOver =" + buySideTurnOver + ", sellSideTurnOver =" + sellSideTurnOver + ", bankID =" + bankID + ", PKAccountID =" + PKAccountID + ", IP_Name =" + IP_Name + ", IPAccount_ID =" + IPAccount_ID + ", hedgeTypeID =" + hedgeTypeID + ", WhiteLevelName =" + WhiteLevelName);
        
        Password = RandPassword();
        InsertParticipantDetailDataContext s_InsertParticipantDetails;
        InsertAccountDetailDataContext s_InsertAccountDetail;
        UpdateParticipantdetailDataContext s_UpdateParticipantdetail;
        InsertMailInfoDataContext s_InsertMailInfo;
        s_InsertParticipantDetails = new InsertParticipantDetailDataContext(lnqConnectionString);
        s_InsertAccountDetail = new InsertAccountDetailDataContext(lnqConnectionString);
        s_UpdateParticipantdetail = new UpdateParticipantdetailDataContext(lnqConnectionString);
        s_InsertMailInfo = new InsertMailInfoDataContext(lnqConnectionString);
        lock (s_InsertParticipantDetails)
        {
            int? clientId = ClientId;
            try
            {
                int sp_retval = s_InsertParticipantDetails.WS_Exchange_InsertParticipantDetail(firstName, middleName, lastName, primaryEmailAddress,
                                                                                      secondaryEmailAddress, DOB, Gender, FK_NationalityID,
                                                                                      Address1, Address2, FKCountryID, City, State, Zip,
                                                                                      PrimaryPhone, secondaryPhone, FaxNumber, Mobile, PassportID,
                                                                                      SSN, Age, PAN, FKParticipantType, LoginID,
                                                                                      Password, Password, status,
                                                                                      deleted, registrationDate, FKAccountTypeID, ref FKAccountGroupID,
                                                                                      ref participantId, MarkUpValue);

                if (sp_retval == SUCCESS_ID)
                {
                    string clientName = firstName + " " + middleName + " " + lastName;

                    if (IsLive == true)
                    {
                        LoginID = 'L' + participantId.ToString();
                    }
                    else
                    {
                        LoginID = "Demo" + participantId.ToString();
                    }



                    sp_retval = s_UpdateParticipantdetail.BO_UpdateParticipantDetail(participantId, firstName, middleName, lastName, primaryEmailAddress,
                                                                                      secondaryEmailAddress, DOB, Gender, FK_NationalityID,
                                                                                      Address1, Address2, FKCountryID, City, State, Zip,
                                                                                      PrimaryPhone, secondaryPhone, FaxNumber, Mobile, PassportID,
                                                                                      SSN, Age, PAN, FKParticipantType, LoginID,
                                                                                      Password, Password, status,
                                                                                      deleted, registrationDate, FKAccountTypeID, FKAccountGroupID, MarkUpValue);

                    DataTable data = new DataTable();
                    string SMTP_SERVER = string.Empty;
                    int SMTP_PORT = 0;
                    string mailUserAddress = string.Empty;
                    string mailUserPassword = string.Empty;
                   
                    SqlConnection myConnection = new SqlConnection(lnqConnectionString);

                    try
                    {
                        myConnection.Open();

                        SqlCommand cmd = new SqlCommand("WS_Exchange_GetMasterMailInfo", myConnection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@WhiteLevelName", SqlDbType.VarChar));

                        cmd.Parameters["@WhiteLevelName"].Value = WhiteLevelName.Trim();

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
                        SMTP_SERVER = data.Rows[0]["SMTP_SERVER"].ToString().Trim();
                        SMTP_PORT = Convert.ToInt32(data.Rows[0]["SMTP_PORT"].ToString().Trim());
                        mailUserAddress = data.Rows[0]["WhiteLevelMailId"].ToString().Trim();
                        mailUserPassword = data.Rows[0]["WhiteLevelMailPassword"].ToString().Trim();

                        if (WhiteLevelName.Trim().ToUpper() == "DAWISH")
                        {
                            string[] _subject = new string[] { "Welcome to Dawish Financial Management Limited", "Login Credentials for Dawish Financial Management Limited" };
                            string[] _body = new string[] { CreateMailMsg(clientName, LoginID, Password, WhiteLevelName.Trim(), primaryEmailAddress), CreateMailAccountDetailsMsg(clientName, LoginID, Password, WhiteLevelName.Trim(), primaryEmailAddress) };
                            bool result = sendMailAccountCredential(SMTP_SERVER, SMTP_PORT, mailUserAddress, mailUserPassword, primaryEmailAddress, _subject, _body);
                            sp_retval = s_InsertMailInfo.WS_Exchange_InsertMailInfo(LoginID, Password, participantId,WhiteLevelName,clientName, _subject[0], _body[0]);
                            sp_retval = s_InsertMailInfo.WS_Exchange_InsertMailInfo(LoginID, Password, participantId,WhiteLevelName,clientName, _subject[1], _body[1]);
                        }

                        else if (WhiteLevelName.ToUpper() == "JAGS")
                        {
                            string[] _subject = new string[] { "Welcome to Jags Technologies", "Login Credentials for Jags Technologies" };
                            string[] _body = new string[] { CreateMailMsg(clientName, LoginID, Password, WhiteLevelName, primaryEmailAddress), CreateMailAccountDetailsMsg(clientName, LoginID, Password, WhiteLevelName, primaryEmailAddress) };
                            bool result = sendMailAccountCredential(SMTP_SERVER, SMTP_PORT, mailUserAddress, mailUserPassword, primaryEmailAddress, _subject, _body);
                            sp_retval = s_InsertMailInfo.WS_Exchange_InsertMailInfo(LoginID, Password, participantId,WhiteLevelName,clientName, _subject[0], _body[0]);
                            sp_retval = s_InsertMailInfo.WS_Exchange_InsertMailInfo(LoginID, Password, participantId,WhiteLevelName,clientName, _subject[1], _body[1]);

                        }

                        else if (WhiteLevelName.ToUpper() == "AMIFX")
                        {
                            string[] _subject = new string[] { "Welcome to AMI Professional Services Limited", "Login Credentials for AMI Professional Services Limited" };
                            string[] _body = new string[] { CreateMailMsg(clientName, LoginID, Password, WhiteLevelName, primaryEmailAddress), CreateMailAccountDetailsMsg(clientName, LoginID, Password, WhiteLevelName, primaryEmailAddress) };
                            bool result = sendMailAccountCredential(SMTP_SERVER, SMTP_PORT, mailUserAddress, mailUserPassword, primaryEmailAddress, _subject, _body);
                            sp_retval = s_InsertMailInfo.WS_Exchange_InsertMailInfo(LoginID, Password, participantId, WhiteLevelName, clientName, _subject[0], _body[0]);
                            sp_retval = s_InsertMailInfo.WS_Exchange_InsertMailInfo(LoginID, Password, participantId, WhiteLevelName, clientName, _subject[1], _body[1]);

                        }
                    }                   

                    sp_retval = s_InsertAccountDetail.BO_InsertAccountDetails(participantId, FKAccountGroupID,
                        balanace, equity, deleted, usedMargin, fkleverage, isHeadgingAllowed,
                        isTradeEnable, FK_Currency, buySideTurnOver, sellSideTurnOver, bankID,
                        ref PKAccountID, IP_Name, IPAccount_ID, IsLive, hedgeTypeID);

                }
                else
                {
                    // Failure Code
                    sp_retval = FAILURE_ID1;
                }
                ClientId = (int)PKAccountID;
                objLoginCredential.loginId = LoginID;
                objLoginCredential.password = Password;
                return objLoginCredential;
            }
            catch (Exception e)
            {
                //Logging.FileHandling.WriteAllLog("Exception Message :" + e.Message + "Exception Source :" + e.Source);
                return objLoginCredential;
            }
        }
    }


    public int GetSize()
    {
        return AccountCreateService.size;
    }

    private bool sendMailAccountCredential(string smtp_srver,int smtp_port,string mailUserAddress,string mailUserPassword,string emailTo, string[] subject, string[] body)
    {
        bool rslt = false;
        if (mailUserAddress == null || mailUserAddress.Trim().Length == 0)
        {
            rslt = false;
        }
        if (mailUserPassword == null || mailUserPassword.Trim().Length == 0)
        {
            rslt = false;
        }
        if (emailTo == null || emailTo.Length == 0)
        {
            rslt = false;
        }
        
        SmtpClient smtpClient = new SmtpClient(smtp_srver, smtp_port);
        smtpClient.EnableSsl = true;
        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        smtpClient.UseDefaultCredentials = false;
        smtpClient.Credentials = new NetworkCredential(mailUserAddress, mailUserPassword);

        for (int i = 0; i < 2; i++)
        {
            using (MailMessage message = new MailMessage())
            {
                message.From = new MailAddress(mailUserAddress);
                message.Subject = subject[i];
                message.Body = body[i];
                //message.Subject = subject == null ? "" : subject;
                //message.Body = CreateMailMsg(clientName, logId, logPwd, whiteLvlName, emailTo);

                message.IsBodyHtml = true;

                //TODO: Check email is valid
                message.To.Add(emailTo);
                try
                {
                    smtpClient.Send(message);
                    rslt = true;
                }
                catch
                {
                    rslt = false;
                }
            }
           
        }
        return rslt;
    }

    private string CreateMailMsg(string ClientName, string loginId, string LoginPassword, string whiteLevelName, string mailId)
    {
        string JagsMsg = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\"><html xmlns=\"http://www.w3.org/1999/xhtml\"><head><meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" /><title>Jags Technologies - Exponen Trader Demo Account Registeration</title></head><body>" +
            "<div id=\"mpf0_readMsgBodyContainer\"><div id=\"mpf0_MsgContainer\"><title>Jags Technologies - Exponen Trader Demo Account Registeration</title><table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" bgcolor=\"f5f6f6\"><tbody><tr>" +
        "<td bgcolor=\"white\"><table width=\"580\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\"><tbody><tr><td style=\"font-family: Arial, Helvetica, sans-serif; font-size: 11px; color: #000000\">" +
        "Your Exponen Trader Demo Account </td></tr></tbody></table><br><table width=\"640\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" bgcolor=\"#ffffff\"><tbody><tr><td><table width=\"580\" border=\"0\" " +
        "align=\"center\" cellpadding=\"0\" cellspacing=\"0\"><tbody><tr><td style=\"font-family: Arial, Helvetica, sans-serif; font-size: 20px;\" align=\"left\"><b><font color=#2B63C4>JAGS</font><font color=#0096C4> TECHNOLOGIES </font></b></td><td width=\"352\" valign=\"top\" " +
        "style=\"padding-top:20px\"></td></tr></tbody></table><table width=\"580\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\"><tbody><tr><td height=\"10\" style=\"border-top:solid #CCC 1px\">&nbsp;</td></tr></tbody>" +
        "</table><table width=\"580\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\"><tbody><tr><td width=\"580\" style=\"padding-bottom:20px;font-family:Arial, Helvetica, sans-serif;font-size:12px;color:#9d9797;line-height:14px\">" +
        "<font style=\"font-family:'Futura Std Book' Arial, Helvetica, sans-serif;font-size:20px;color:#44484a;line-height:38px\">Dear " + ClientName + " </font><br><br><font style=\"font-family:Arial, Helvetica, sans-serif;font-size:15px;line-height:18px;color:#9d9797\">" +
        "Thank you for signing up a demo account with Exponen Trader. You can now login &amp; start trading, if you have not had a chance to download the platform,click below for the download.<br><p> <a href=\"#\" class=\"btn btn-primary btn-large\">" +
        "Download Exponen Trader </a> </p><p> <a href=\"#\" class=\"btn btn-primary btn-large\">Login To Web Trader </a> </p><p> <a href=\"#\" class=\"btn btn-primary btn-large\">Download Mobile Trader </a> </p><br><font style=\"font-family:'Futura Std Book' Arial, Helvetica, sans-serif;font-size:16px;color:#44484a;line-height:18px;text-transform:uppercase\">How to log in to your Exponen Trader Demo account</font><br>" +
        "<font style=\"font-family:Arial, Helvetica, sans-serif;font-size:12px;line-height:14px;color:#9d9797\"><ul><li>Installed and launch Exponen Trader by click on the desktop icon. </li><li>Enter your username and password in the appropriate fields in the 'Login Box' section. Please make sure to enter your username correct.</li>" +
        "<li>Press the 'Log In' button to access your demo account </li></ul>After you login, we strongly recommend you change your password. This can be done on the Exponen Trader itself &gt;&gt; Settings &gt;&gt; Password.<br><br>" +
        "<font style=\"font-family:'Futura Std Book' Arial, Helvetica, sans-serif;font-size:16px;color:#44484a;line-height:18px;text-transform:uppercase\">Using Your Demo account</font><br><br>" +
        "<font style=\"font-family:Arial, Helvetica, sans-serif;font-size:12px;line-height:14px;color:#9d9797\">Your Demo account will be open for 14 days. You have $##,### of practice funds to get started and we hope you enjoy your demo trading experience on the Exponen Trader.<br>" +
        "<br><font style=\"font-family:'Futura Std Book' Arial, Helvetica, sans-serif;font-size:16px;color:#44484a;line-height:18px;text-transform:uppercase\">Learn More About Our Products</font><br><br>" +
        "<font style=\"font-family:Arial, Helvetica, sans-serif;font-size:12px;line-height:14px;color:#9d9797\">If you are new to Exponen Trader and the products we offer, please visit our<a href=\"http://www.jagstechnologies.com\" target=\"_blank\">'Website'</a>.<br>" +
        "<br>If you have questions or need assistance, please contact Customer Service.<br><br>Best Regards,<br><br>Jags Technologies<br>Phone: +44 (0) 208 144 4845<br>" +
        "Email: <a href=\"mailto:info@jagstechnologies.com\">info@jagstechnologies.com</a><br>Website: <a href=\"http://www.jagstechnologies.com/\" target=\"_blank\">www.jagstechnologies.com</a><br>" +
        "</font></font></font></td></tr></tbody></table></td></tr></tbody></table><table width=\"580\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\"></table><table width=\"580\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\">" +
        "<tbody><tr><td height=\"30\">&nbsp;</td></tr></tbody></table></td></tr></tbody></table></font></div></div></body></html>";

        string DawishMsg = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\"><html xmlns=\"http://www.w3.org/1999/xhtml\"><head><meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" /><title>Dawish - Dawish Trader Demo Account Registeration</title></head><body>" +
            "<div id=\"mpf0_readMsgBodyContainer\"><div id=\"mpf0_MsgContainer\"><title>Dawish Financial Management - Dawish Trader Demo Account Registeration</title><table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" bgcolor=\"f5f6f6\"><tbody>" +
            "<tr><td bgcolor=\"white\"><table width=\"580\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\"></table><br><table width=\"640\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" bgcolor=\"#ffffff\">" +
            "<tbody><tr><td><table width=\"580\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\"><tbody><tr><td style=\"font-family: Arial, Helvetica, sans-serif; font-size: 20px;\" align=\"left\">" +
        "<b><font color=#2B63C4>Welcome:-</font></b></td><td width=\"352\" valign=\"top\" style=\"padding-top:20px\"></td></tr></tbody></table><table width=\"580\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\">" +
        "<tbody><tr><td height=\"10\" style=\"border-top:solid #CCC 1px\">&nbsp;</td></tr></tbody></table><table width=\"580\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\"><tbody><tr>" +
        "<font style=\"font-family:Arial, Helvetica, sans-serif;font-size:15px;line-height:18px;color:#9d9797\">Thank you for choosing Dawish Financial management Limited, NZ. You can analyze markets and perform trades using our trading terminal \"Dawish Intelli Trader\"." +
        "<br><br><font style=\"font-family:Arial, Helvetica, sans-serif;font-size:15px;line-height:18px;color:#9d9797\">At your disposal, there are:<br><ul><li>" +
        "<font style=\"font-family:'Futura Std Book' Arial, Helvetica, sans-serif;font-size:16px;color:#44484a;line-height:16px;text-transform\">All Kinds of Trade Orders</font></li>" +
        "<ul><font style=\"font-family:Arial, Helvetica, sans-serif;font-size:15px;line-height:18px;color:#9d9797\">It is necessary to use different orders to realize sophisticated trading strategies. For example, you may sometimes need to <reverse positions> or place pending orders to limit your possible losses. All these functions are available in our trading terminal.</ul>" +
        "</ul><ul><li><font style=\"font-family:'Futura Std Book' Arial, Helvetica, sans-serif;font-size:16px;color:#44484a;line-height:16px;text-transform\">50 Analytical Tools</font></li>" +
        "<ul><font style=\"font-family:Arial, Helvetica, sans-serif;font-size:15px;line-height:18px;color:#9d9797\">If one wants to know when to open and close trade positions, he or she should analyze the market. For these purposes, the terminal has about 30 embedded technical indicators and 20 line studies. They will help you to know the market movements better.</ul>" +
        "<ul><li><font style=\"font-family:'Futura Std Book' Arial, Helvetica, sans-serif;font-size:16px;color:#44484a;line-height:16px;text-transform\">Automated Trading and Custom Indicators</font></li>" +
        "<li><font style=\"font-family:Arial, Helvetica, sans-serif;font-size:15px;line-height:18px;color:#9d9797\">Expert Advisors that can fully automate both analyzing and trading processes. Thus, Expert Advisors can completely release you from the financial markets analyzing routine.</font></li>" +
        "<li><font style=\"font-family:Arial, Helvetica, sans-serif;font-size:15px;line-height:18px;color:#9d9797\">Custom Indicators that will help you to create your own analytical tools, similar to the embedded technical indicators.</font></li>" +
        "<li><font style=\"font-family:Arial, Helvetica, sans-serif;font-size:15px;line-height:18px;color:#9d9797\">Scripts that automate single, frequently repeated operations. For example, using a script, you can close all positions by a single keystroke.</font></li>" +
        "</ul><br><li><font style=\"font-family:'Futura Std Book' Arial, Helvetica, sans-serif;font-size:16px;color:#44484a;line-height:16px;text-transform\">Different Timeframes</font></li>" +
        "<ul><font style=\"font-family:Arial, Helvetica, sans-serif;font-size:15px;line-height:18px;color:#9d9797\">The charting in the client terminal can use 9 timeframes, from one minute to one month. If you need additional trend analysis on a larger timeframe or more precise detection of the entering point, there are no problems at all. Any chart for any symbol on any timeframe is on your desktop.</ul><br>" +
        "<li><font style=\"font-family:'Futura Std Book' Arial, Helvetica, sans-serif;font-size:16px;color:#44484a;line-height:16px;text-transform\">Trade Alerts</font></li>" +
        "<ul><font style=\"font-family:Arial, Helvetica, sans-serif;font-size:15px;line-height:18px;color:#9d9797\">When working on many charts with many symbols on different timeframes, one can easily miss some valuable opportunities. In order to avoid this, the terminal provides a system alerting about trade events. When price reaches a certain level, the alert will trigger and you will be aware of the current changes.</ul><br>" +
        "<li><font style=\"font-family:'Futura Std Book' Arial, Helvetica, sans-serif;font-size:16px;color:#44484a;line-height:16px;text-transform\">News</font></li>" +
        "<ul><font style=\"font-family:Arial, Helvetica, sans-serif;font-size:15px;line-height:18px;color:#9d9797\">News from world financial markets exert a strong influence on quotes. It is very important to get the latest news and analyze them in time. In the client terminal, you can do it easily and quickly.</ul><br>" +
        "</ul><font style=\"font-family:Arial, Helvetica, sans-serif;font-size:15px;line-height:18px;color:#9d9797\">The client terminal provides huge functionality. At the same time, it is rather easy to work with it due to its elaborate, user-friendly interface. However, if you have any questions concerning the software operation, you can refer to the embedded Help files. In it, you will find answers " +
        "to your questions for sure. Just press F1 or execute the <Help – Help Topics> menu command to call the Help.</font><br>" +
        "<font style=\"font-family:Arial, Helvetica, sans-serif;font-size:12px;line-height:14px;color:#9d9797\"><br><font style=\"font-family:'Futura Std Book' Arial, Helvetica, sans-serif;font-size:14px;color:#44484a;line-height:16px;text-transform\">Sincerely Yours,<br>" +
        "<br>Dawish Financial Management Limited, New Zealand<br><a href=\"http://www.dawishforex.com/\" target=\"_blank\">www.dawishforex.com</a><br></font><br><br></font></font></font></font></td></tr></tbody></table></td></tr></tbody></table><table width=\"580\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\">" +
        "</table><table width=\"580\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\"><tbody><tr><td height=\"30\">&nbsp;</td></tr></tbody></table></td></tr></tbody></table></font></div></div></body></html>";

        string AMIFXmsg = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\"><html xmlns=\"http://www.w3.org/1999/xhtml\"><head><meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" /><title>AMI - AMI Professional Demo Account Registeration</title></head><body>" +
            "<div id=\"mpf0_readMsgBodyContainer\"><div id=\"mpf0_MsgContainer\"><title>AMI Professional Services - AMI Trader Demo Account Registeration</title><table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" bgcolor=\"f5f6f6\"><tbody>" +
            "<tr><td bgcolor=\"white\"><table width=\"580\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\"></table><br><table width=\"640\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" bgcolor=\"#ffffff\">" +
            "<tbody><tr><td><table width=\"580\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\"><tbody><tr><td style=\"font-family: Arial, Helvetica, sans-serif; font-size: 20px;\" align=\"left\">" +
        "<b><font color=#2B63C4>Welcome:-</font></b></td><td width=\"352\" valign=\"top\" style=\"padding-top:20px\"></td></tr></tbody></table><table width=\"580\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\">" +
        "<tbody><tr><td height=\"10\" style=\"border-top:solid #CCC 1px\">&nbsp;</td></tr></tbody></table><table width=\"580\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\"><tbody><tr>" +
        "<font style=\"font-family:Arial, Helvetica, sans-serif;font-size:15px;line-height:18px;color:#9d9797\">Thank you for choosing AMI Professional Services Limited. You can analyze markets and perform trades using our trading terminal \"AMI Intelli Trader\"." +
        "<br><br><font style=\"font-family:Arial, Helvetica, sans-serif;font-size:15px;line-height:18px;color:#9d9797\">At your disposal, there are:<br><ul><li>" +
        "<font style=\"font-family:'Futura Std Book' Arial, Helvetica, sans-serif;font-size:16px;color:#44484a;line-height:16px;text-transform\">All Kinds of Trade Orders</font></li>" +
        "<ul><font style=\"font-family:Arial, Helvetica, sans-serif;font-size:15px;line-height:18px;color:#9d9797\">It is necessary to use different orders to realize sophisticated trading strategies. For example, you may sometimes need to <reverse positions> or place pending orders to limit your possible losses. All these functions are available in our trading terminal.</ul>" +
        "</ul><ul><li><font style=\"font-family:'Futura Std Book' Arial, Helvetica, sans-serif;font-size:16px;color:#44484a;line-height:16px;text-transform\">50 Analytical Tools</font></li>" +
        "<ul><font style=\"font-family:Arial, Helvetica, sans-serif;font-size:15px;line-height:18px;color:#9d9797\">If one wants to know when to open and close trade positions, he or she should analyze the market. For these purposes, the terminal has about 30 embedded technical indicators and 20 line studies. They will help you to know the market movements better.</ul>" +
        "<ul><li><font style=\"font-family:'Futura Std Book' Arial, Helvetica, sans-serif;font-size:16px;color:#44484a;line-height:16px;text-transform\">Automated Trading and Custom Indicators</font></li>" +
        "<li><font style=\"font-family:Arial, Helvetica, sans-serif;font-size:15px;line-height:18px;color:#9d9797\">Expert Advisors that can fully automate both analyzing and trading processes. Thus, Expert Advisors can completely release you from the financial markets analyzing routine.</font></li>" +
        "<li><font style=\"font-family:Arial, Helvetica, sans-serif;font-size:15px;line-height:18px;color:#9d9797\">Custom Indicators that will help you to create your own analytical tools, similar to the embedded technical indicators.</font></li>" +
        "<li><font style=\"font-family:Arial, Helvetica, sans-serif;font-size:15px;line-height:18px;color:#9d9797\">Scripts that automate single, frequently repeated operations. For example, using a script, you can close all positions by a single keystroke.</font></li>" +
        "</ul><br><li><font style=\"font-family:'Futura Std Book' Arial, Helvetica, sans-serif;font-size:16px;color:#44484a;line-height:16px;text-transform\">Different Timeframes</font></li>" +
        "<ul><font style=\"font-family:Arial, Helvetica, sans-serif;font-size:15px;line-height:18px;color:#9d9797\">The charting in the client terminal can use 9 timeframes, from one minute to one month. If you need additional trend analysis on a larger timeframe or more precise detection of the entering point, there are no problems at all. Any chart for any symbol on any timeframe is on your desktop.</ul><br>" +
        "<li><font style=\"font-family:'Futura Std Book' Arial, Helvetica, sans-serif;font-size:16px;color:#44484a;line-height:16px;text-transform\">Trade Alerts</font></li>" +
        "<ul><font style=\"font-family:Arial, Helvetica, sans-serif;font-size:15px;line-height:18px;color:#9d9797\">When working on many charts with many symbols on different timeframes, one can easily miss some valuable opportunities. In order to avoid this, the terminal provides a system alerting about trade events. When price reaches a certain level, the alert will trigger and you will be aware of the current changes.</ul><br>" +
        "<li><font style=\"font-family:'Futura Std Book' Arial, Helvetica, sans-serif;font-size:16px;color:#44484a;line-height:16px;text-transform\">News</font></li>" +
        "<ul><font style=\"font-family:Arial, Helvetica, sans-serif;font-size:15px;line-height:18px;color:#9d9797\">News from world financial markets exert a strong influence on quotes. It is very important to get the latest news and analyze them in time. In the client terminal, you can do it easily and quickly.</ul><br>" +
        "</ul><font style=\"font-family:Arial, Helvetica, sans-serif;font-size:15px;line-height:18px;color:#9d9797\">The client terminal provides huge functionality. At the same time, it is rather easy to work with it due to its elaborate, user-friendly interface. However, if you have any questions concerning the software operation, you can refer to the embedded Help files. In it, you will find answers " +
        "to your questions for sure. Just press F1 or execute the <Help – Help Topics> menu command to call the Help.</font><br>" +
        "<font style=\"font-family:Arial, Helvetica, sans-serif;font-size:12px;line-height:14px;color:#9d9797\"><br><font style=\"font-family:'Futura Std Book' Arial, Helvetica, sans-serif;font-size:14px;color:#44484a;line-height:16px;text-transform\">Sincerely Yours,<br>" +
        "<br>AMI Professional Services Limited,<br>Enterprise House, Cranes Farm Road, Basildon, Essex, SS14 3JB<br></font><br><br></font></font></font></font></td></tr></tbody></table></td></tr></tbody></table><table width=\"580\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\">" +
        "</table><table width=\"580\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\"><tbody><tr><td height=\"30\">&nbsp;</td></tr></tbody></table></td></tr></tbody></table></font></div></div></body></html>";

        if (whiteLevelName.ToUpper() == "DAWISH")
        {
            return DawishMsg;
        }
        else if (whiteLevelName.ToUpper() == "AMIFX")
        {
            return AMIFXmsg;
        }

            return JagsMsg;

    }

    private string CreateMailAccountDetailsMsg(string ClientName, string loginId, string LoginPassword, string whiteLevelName, string mailId)
    {
        string JagsMsg = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">" +
"<html xmlns=\"http://www.w3.org/1999/xhtml\"><head><meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />" +
"<title>Jags Technologies - Exponen Trader Demo Account Registeration</title></head><body><div id=\"mpf0_readMsgBodyContainer\" ><div id=\"mpf0_MsgContainer\">" +
"<title>Jags Technologies - Exponen Trader Demo Account Registeration</title><table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" bgcolor=\"f5f6f6\"><tbody>" +
"<tr><td bgcolor=\"white\"><table width=\"580\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\"><tbody><tr>" +
"<td style=\"font-family: Arial, Helvetica, sans-serif; font-size: 11px; color: #000000\">Your Exponen Trader Demo Account </td></tr></tbody></table><br>" +
"<table width=\"640\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" bgcolor=\"#ffffff\"><tbody><tr><td><table width=\"580\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\">" +
"<tbody><tr><td style=\"font-family: Arial, Helvetica, sans-serif; font-size: 20px;\" align=\"left\"><b><font color=#2B63C4>JAGS</font><font color=#0096C4> TECHNOLOGIES </font></b></td>" +
"<td width=\"352\" valign=\"top\" style=\"padding-top:20px\"></td></tr></tbody></table><table width=\"580\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\">" +
"<tbody><tr><td height=\"10\" style=\"border-top:solid #CCC 1px\">&nbsp;</td></tr></tbody></table>" +
"<table width=\"580\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\"><tbody><tr><td width=\"580\" style=\"padding-bottom:20px;font-family:Arial, Helvetica, sans-serif;font-size:12px;color:#9d9797;line-height:14px\">" +
"<font style=\"font-family:'Futura Std Book' Arial, Helvetica, sans-serif;font-size:20px;color:#44484a;line-height:38px\"><b><font color=#2B63C4>Registration Details :-</font></b><br>" +
"<font style=\"font-family:Arial, Helvetica, sans-serif;font-size:15px;line-height:18px;color:#9d9797\">Dear " + ClientName + "  !" +
"<br>Thank you for signing up.<br>An account has been opened for you with the following parameters:<br>Name  : " + ClientName + "<br>Email  : " + mailId + "<br>Login    : " + loginId +
"<br>Password : " + LoginPassword + "<br><br></font><font style=\"font-family:'Futura Std Book' Arial, Helvetica, sans-serif;font-size:14px;color:#44484a;line-height:16px;text-transform\">" +
"Best Regards,<br><br>Jags Technologies<br>Phone: +44 (0) 208 144 4845<br>Email: <a href=\"mailto:info@jagstechnologies.com\">info@jagstechnologies.com</a><br>Website: <a href=\"http://www.jagstechnologies.com/\" target=\"_blank\">" +
"www.jagstechnologies.com</a><br></font></font></font></font></td></tr></tbody></table><table width=\"580\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\">" +
"</table><table width=\"580\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\"><tbody><tr><td height=\"30\">&nbsp;</td></tr></tbody></table></font></div></div></body></html>";

        string DawishMsg = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">"+
"<html xmlns=\"http://www.w3.org/1999/xhtml\"><head><meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />"+
"<title>Dawish - Dawish Trader Demo Account Details</title></head><body><div id=\"mpf0_readMsgBodyContainer\" >"+
"<div  id=\"mpf0_MsgContainer\"><title>Dawish Financial Management - Dawish Trader Demo Account Details</title>"+
"<table width=\"640\" align=\"center\"  border=\"0\" cellspacing=\"0\" cellpadding=\"0\" bgcolor=\"f5f6f6\"><br><font style=\"font-family: Arial, Helvetica, sans-serif; font-size: 18px;\" align=\"left\">"+
"<b><font color=\"green\"><H3>Dawish Financial Management Limited,<br>New Zealand</H3></font></b><b><font color=#2B63C4>Registration Details :-</font></b><br><br>"+
"<font style=\"font-family:Arial, Helvetica, sans-serif;font-size:15px;line-height:18px;color:#9d9797\">Dear "+ClientName+"  !<br>Thank you for signing up.<br>An account has been opened for you with the following parameters:<br>"+
"Name  : " + ClientName + "<br>Email  : " + mailId + "<br>Login    : " + loginId + "<br>Password : "+LoginPassword+"<br>Investor : ####(read only password)<br><br></font>" +
"<font style=\"font-family:'Futura Std Book' Arial, Helvetica, sans-serif;font-size:14px;color:#44484a;line-height:16px;text-transform\">Sincerely Yours,<br><br>"+
"Dawish Financial Management Limited, New Zealand<br><a href=\"http://www.dawishforex.com/\" target=\"_blank\">www.dawishforex.com</a><br></font></font></font></font></td></tr></tbody></table>"+
"<table width=\"580\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\"></table><table width=\"580\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\"><tbody>"+
"<tr><td height=\"30\">&nbsp;</td></tr></tbody></table></font></div></div></body></html>";

        string AMIFXmsg = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">" +
"<html xmlns=\"http://www.w3.org/1999/xhtml\"><head><meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />" +
"<title>AMI - AMI Professional Services Trader Demo Account Details</title></head><body><div id=\"mpf0_readMsgBodyContainer\" >" +
"<div  id=\"mpf0_MsgContainer\"><title>AMI Professional Services - AMI Trader Demo Account Details</title>" +
"<table width=\"640\" align=\"center\"  border=\"0\" cellspacing=\"0\" cellpadding=\"0\" bgcolor=\"f5f6f6\"><br><font style=\"font-family: Arial, Helvetica, sans-serif; font-size: 18px;\" align=\"left\">" +
"<b><font color=\"green\"><H3>AMI Professional Services Limited,</H3><H5>Enterprise House, Cranes Farm Road, Basildon, Essex, SS14 3JB</H5></font></b><b><font color=#2B63C4>Registration Details :-</font></b><br><br>" +
"<font style=\"font-family:Arial, Helvetica, sans-serif;font-size:15px;line-height:18px;color:#9d9797\">Dear " + ClientName + "  !<br>Thank you for signing up.<br>An account has been opened for you with the following parameters:<br>" +
"Name  : " + ClientName + "<br>Email  : " + mailId + "<br>Login    : " + loginId + "<br>Password : " + LoginPassword + "<br>Investor : ####(read only password)<br><br></font>" +
"<font style=\"font-family:'Futura Std Book' Arial, Helvetica, sans-serif;font-size:12px;color:#44484a;line-height:14px;text-transform\">Sincerely Yours,<br><br>" +
"AMI Professional Services Limited,<br>Enterprise House, Cranes Farm Road, Basildon, Essex, SS14 3JB<br></font></font></font></font></td></tr></tbody></table>" +
"<table width=\"580\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\"></table><table width=\"580\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\"><tbody>" +
"<tr><td height=\"30\">&nbsp;</td></tr></tbody></table></font></div></div></body></html>";

        if (whiteLevelName.ToUpper() == "DAWISH")
        {
            return DawishMsg;
        }
        else if (whiteLevelName.ToUpper() == "AMIFX")
        {
            return AMIFXmsg;
        }
        else
            return JagsMsg;

    }

    private string GetMailDetails(string clientName, string logId, string pwd, string WhiteLevelName, string emailId)
    {
        string mailDetails = string.Empty;
        if (WhiteLevelName.ToUpper() == "DAWISH")
        {
            mailDetails = "Welcome:-" +
"~Thank you for choosing Dawish Financial management Limited, NZ. You can analyze markets and perform trades using our trading terminal \"Dawish Intelli Trader.\"" +
"~At your disposal, there are:" + "~*All Kinds of Trade Orders" +
"~It is necessary to use different orders to realize sophisticated trading strategies. For example, you may sometimes need to <reverse positions> or place pending orders to limit your possible losses. All these functions are available in our trading terminal. " +
"~*	50 Analytical Tools" + "~If one wants to know when to open and close trade positions, he or she should analyze the market. For these purposes, the terminal has about 30 embedded technical indicators and 20 line studies. They will help you to know the market movements better. " +
"~*	Automated Trading and Custom Indicators" + "~*	Expert Advisors that can fully automate both analyzing and trading processes. Thus, Expert Advisors can completely release you from the financial markets analyzing routine. " +
"~*	Custom Indicators that will help you to create your own analytical tools, similar to the embedded technical indicators. " +
"~*	Scripts that automate single, frequently repeated operations. For example, using a script, you can close all positions by a single keystroke. " +
"~Different Timeframes" + "~The charting in the client terminal can use 9 timeframes, from one minute to one month. If you need additional trend analysis on a larger timeframe or more precise detection of the entering point, there are no problems at all. Any chart for any symbol on any timeframe is on your desktop. " +
"~*	Trade Alerts" + "~When working on many charts with many symbols on different timeframes, one can easily miss some valuable opportunities. In order to avoid this, the terminal provides a system alerting about trade events. When price reaches a certain level, the alert will trigger and you will be aware of the current changes. " +
"~*	News" + "~News from world financial markets exert a strong influence on quotes. It is very important to get the latest news and analyze them in time. In the client terminal, you can do it easily and quickly. " +
"~The client terminal provides huge functionality. At the same time, it is rather easy to work with it due to its elaborate, user-friendly interface. However, if you have any questions concerning the software operation, you can refer to the embedded Help files. In it, you will find answers to your questions for sure. Just press F1 or execute the <Help – Help Topics> menu command to call the Help." +
"~" + "~" + "~Sincerely Yours," + "~Dawish Financial Management Limited, New Zealand" + "~www.dawishforex.com " + "~" + "~Registration:-" + "~" + "~Dear " + clientName + "!" + "~Thank you for signing up." + "~An account has been opened for you with the following parameters:" +
"~Name	: " + clientName + "~Email	: " + emailId + "~Login  : " + logId + "~Password :" + pwd + "~Investor : ………………………. (read only password)" + "~" + "~Sincerely Yours," +
"~Dawish Financial Management Limited, New Zealand" + "~www.dawishforex.com";
        }
        else if (WhiteLevelName.ToUpper() == "JAGS")
        {
            mailDetails = "Your Exponen Trader Demo Account" + "~" + "~JAGS TECHNOLOGIES" + "~" + "~Dear " + clientName + ",~" + "~Thank you for signing up a demo account with Exponen Trader. You can now login & start trading, if you have not had a chance to download the platform,click below for the download." +
"~Download Exponen Trader" + "~" + "~Login To Web Trader" + "~" + "~Download Mobile Trader" + "~" + "~" + "~YOUR DEMO ACCOUNT DETAILS" + "~Username - " + logId + "~Password - " + pwd + "~" +
"~HOW TO LOG IN TO YOUR EXPONEN TRADER DEMO ACCOUNT" + "~Installed and launch Exponen Trader by click on the desktop icon." +
"~Enter your username and password in the appropriate fields in the 'Login Box' section. Please make sure to enter your username correct." +
"~Press the 'Log In' button to access your demo account" + "~After you login, we strongly recommend you change your password. This can be done on the Exponen Trader itself >> Settings >> Password." +
"~" + "~USING YOUR DEMO ACCOUNT" + "~" + "~Your Demo account will be open for 14 days. You have $##,### of practice funds to get started and we hope you enjoy your demo trading experience on the Exponen Trader." +
"~" + "~LEARN MORE ABOUT OUR PRODUCTS" + "~" + "~If you are new to Exponen Trader and the products we offer, please visit our'Website'." + "~" + "~If you have questions or need assistance, please contact Customer Service." +
"~" + "~Best Regards," + "~" + "~Jags Technologies" + "~Phone: +44 (0) 208 144 4845" + "~Email: info@jagstechnologies.com" + "~Website: www.jagstechnologies.com";
        }

        return mailDetails;
    }
}

